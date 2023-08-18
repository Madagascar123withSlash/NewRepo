using Seagull.BarTender.SystemDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWork
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string main_ConnectionTyp = "Serial";
        //创建取图的websocket-token
        private CancellationToken pic_ctoken = new CancellationToken(); 
        //创建websocket-token
        private CancellationToken ctoken = new CancellationToken();
        //创建socket
        private Socket tcpClient;
        private System.Net.WebSockets.ClientWebSocket websocketClient;
        //创建取消数据源
        private CancellationTokenSource cts = new CancellationTokenSource();    
        private void btn_connect_Click(object sender, EventArgs e)
        {
            websocketClient = new System.Net.WebSockets.ClientWebSocket();
            //实例化socket
            if (this.btn_connect.Text == "连接")
            {
                if (this.text_port.Text == "6432")
                {
                    string url = $"ws://{this.text_ip.Text}:{this.text_port.Text}/websocket";
                    Uri uri = new Uri(url);
                    try
                    {
                        websocketClient.ConnectAsync(uri, ctoken).Wait();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("websocket连接失败：" + ex.Message);
                        return;
                    }
                    MessageBox.Show("连接成功");
                    this.btn_connect.Text = "断开";
                    Task.Run(new Action(() =>
                    {
                        GetWebsocketValue();
                    }));
                }
                else
                {


                    tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //string PCip = "192.168.100.23";
                    //int PCport = 6432;
                    //EndPoint bindip = new IPEndPoint(IPAddress.Parse(PCip), 0);
                    EndPoint EP = new IPEndPoint(IPAddress.Parse(this.text_ip.Text), int.Parse(this.text_port.Text));

                    try
                    {
                        //tcpClient.Bind(bindip);
                        tcpClient.Connect(EP);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接失败：" + ex.Message);
                        return;
                    }
                    MessageBox.Show("连接成功");
                    this.btn_connect.Text = "断开";
                    Task.Run(new Action(() =>
                    {
                        GetSocketValue();
                    }));
                }
            }
            else
            {
                if (this.text_port.Text == "6432")
                {
                    //websocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", ctoken).Wait();
                    websocketClient.Dispose();
                    this.btn_connect.Text = "连接";
                    MessageBox.Show("断开成功");
                }
                else
                {
                    tcpClient.Close();
                    cts.Cancel();
                    this.btn_connect.Text = "连接";
                }
            }
        }
        private async void GetWebsocketValue()
        {
            byte[] buffer = new byte[10];
            string str = "";
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); //申明解码器
            ArraySegment<byte> webBuffer = new ArraySegment<byte>(buffer);
            while (websocketClient.State == WebSocketState.Open )
            {
                try
                {
                    var result = await websocketClient.ReceiveAsync(webBuffer, ctoken);
                    if (webBuffer.Count != 0)
                    {
                        string strChar = encoding.GetString(webBuffer.Array);
                        foreach (var item in strChar)
                        {
                            str += item.ToString();
                        }
                        ShowText(str);
                        str = "";
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        private void GetSocketValue()
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); //申明解码器
            while(!cts.IsCancellationRequested) 
            {
                byte[] buffer = new byte[1024];
                int length = -1;
                try
                {
                    length = tcpClient.Receive(buffer, SocketFlags.None);
                    Console.WriteLine("数据长度 ：" + length.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("线程内出错:" + e);
                    break;
                }
                if (length > 0)
                {
                    string strChar = encoding.GetString(buffer);//将ascii解码为字符串
                    string resultString = "";
                    foreach (char s in strChar)
                    {
                        if (s != '\0')
                        {
                            
                            resultString += s.ToString();
                        }
                    }
                    //string result = BitConverter.ToString(buffer);
                    ShowText(resultString);
                }
                
            }
        }
        //线程安全，所以要用委托
        delegate void ShowTextCallback(string text);   
        private void ShowText(string text) 
        {
            if (this.richTextBox_tcpReceive.InvokeRequired)
            {
                ShowTextCallback stcb = new ShowTextCallback(ShowText);
                this.Invoke(stcb,new object[] {text });
            }
            else
            {
                this.richTextBox_tcpReceive.Text += text;
            }
        }
        //创建串口端口
        private SerialPort serialPort;
        private void btn_serialConnect_Click(object sender, EventArgs e)
        {
            if (this.btn_serialConnect.Text == "打开")
            {
                serialPort = new SerialPort();
                serialPort.BaudRate = int.Parse(this.text_serialBaudrate.Text);
                serialPort.PortName = this.text_serialPort.Text;
                try
                {
                    serialPort.Open();
                    MessageBox.Show("连接成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接失败：" + ex.Message);
                }
                this.btn_serialConnect.Text = "关闭";
            }
            else
            {
                serialPort.Close();
                this.btn_serialConnect.Text = "打开";
                MessageBox.Show("关闭成功");
            }
        }
        private void send_menu_cmd(string cmd)
        {
            string hex_1 = "02";
            string hex_2 = "f0";
            string hex_3 = "03";
            byte[] cmd_head = new byte[3];
            cmd_head[0] = Convert.ToByte(hex_1, 16);
            cmd_head[1] = Convert.ToByte(hex_2, 16);
            cmd_head[2] = Convert.ToByte(hex_3, 16);
            byte[] cmd_main = new byte[cmd.Length];
            cmd_main = Encoding.ASCII.GetBytes(cmd);
            byte[] cmd_combine = new byte[cmd.Length + 3];
            cmd_head.CopyTo(cmd_combine, 0);
            cmd_main.CopyTo(cmd_combine, 3);
            if (main_ConnectionTyp == "websocket")
            {
                ArraySegment<byte> _cmd_combine = new ArraySegment<byte>(cmd_combine);
                websocketClientPic.SendAsync(_cmd_combine, WebSocketMessageType.Text, true, pic_ctoken).Wait();
            }
            else if (main_ConnectionTyp == "Serial")
            {
                picReadSerialPort.Write(cmd_combine,0,cmd_combine.Length);
            }
            
        }
        private void btn_tcpSend_Click(object sender, EventArgs e)
        {
            string hex_1 = "02";
            string hex_2 = "f0";
            string hex_3 = "03";
            byte[] cmd_head = new byte[3];
            cmd_head[0] = Convert.ToByte(hex_1, 16);
            cmd_head[1] = Convert.ToByte(hex_2, 16);
            cmd_head[2] = Convert.ToByte(hex_3, 16);
            string str = this.richTextBox_tcpSend.Text;
            if (str != "")
            {
                byte[] buffer = new byte[str.Length];
                buffer = Encoding.ASCII.GetBytes(str);
                byte[] kollect = new byte[buffer.Length + 3];
                cmd_head.CopyTo(kollect, 0);
                buffer.CopyTo(kollect, 3);
                if (this.text_port.Text == "6432")
                {

                    ArraySegment<byte> kollect_ = new ArraySegment<byte>(kollect);
                    websocketClient.SendAsync(kollect_, WebSocketMessageType.Text, true, ctoken).Wait();
                }          
                else
                {
                    tcpClient.Send(kollect);
                }
            }
        }
        private string GetDefaultPrinter()
        {
            var printers = new Seagull.BarTender.Print.Printers();
            string printerName = printers.Default.PrinterName;
            return printerName;
        }


        private void btn_browsefile_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();//获取文件
            ofd.Multiselect = false;
            ofd.Title = "选择文件";
            ofd.Filter = "btw文件(*.btw)|*.btw";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
            }
            this.text_fileDir.Text = filepath;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            
            string printername = GetDefaultPrinter();

        }

        private void btn_browsepic_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();//获取文件
            ofd.Multiselect = false;
            ofd.Title = "选择文件";
            ofd.Filter = "jpg文件(*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
            }
            this.text_picDir.Text = filepath;
        }

        private void btn_showPic_Click(object sender, EventArgs e)
        {
            Bitmap picture = new Bitmap(this.text_picDir.Text);
            this.pictureBox_window.Image = picture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Text.ASCIIEncoding decoder = new System.Text.ASCIIEncoding(); //申明unicode解码器
            System.Text.UTF8Encoding decoder = new UTF8Encoding();//申明UTF8解码器
            //websocketClient = new System.Net.WebSockets.ClientWebSocket();
            //string url = $"ws://{this.text_displayerip.Text}:{this.text_displayerport.Text}/websocket";
            //websocketClient.ConnectAsync(new Uri(url), pic_ctoken).Wait();
            //send_menu_cmd("040807.");
            //var result = new byte[1024*4];
            //var resultBefor = new byte[1024*4];
            //var totalResultBuffer = new byte[1024*100];
            //int flag = 0 ;
            var img = new byte[1024000];
            GetWebsocketPicture();
            //while (true)
            //{
            //    websocketClient.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());
            //    Thread.Sleep(200);
            //    bool continueFlag = false;
            //    for (int i = 0; i <= 10; i++) 
            //    {
            //        if (result[i] != resultBefor[i])
            //        {
            //            continueFlag = true;
            //        }
            //    }
            //    if (continueFlag == false)
            //    {
            //        break;
            //    }
            //    result.CopyTo(resultBefor, 0);
            //    result.CopyTo(totalResultBuffer, 1024*4*flag);
            //    flag += 1;

            //}
            string resultstr = string.Empty;
            string decodestr = decoder.GetString(picbuffer);//解码数据流
            int at = decodestr.IndexOf("JFIF", 0);
            int end = decodestr.IndexOf("040807",100);
            Buffer.BlockCopy(picbuffer, at, img, 0, end - at);
            string imghead = decoder.GetString(img);
            Console.WriteLine(decodestr);
            foreach (var item in picbuffer)
            {
                resultstr += item.ToString();
            }
            Console.WriteLine(resultstr);
            
        }
        private System.Net.WebSockets.ClientWebSocket websocketClientPic;
        private byte[] picbuffer = new byte[102400];
        private int picLength = 0;
        private void GetWebsocketPicture()
        {
            main_ConnectionTyp = "websocket";
            websocketClientPic = new System.Net.WebSockets.ClientWebSocket();
            string url = $"ws://{this.text_displayerip.Text}:{this.text_displayerport.Text}/websocket";
            websocketClientPic.ConnectAsync(new Uri(url), pic_ctoken).Wait();
            send_menu_cmd("040807.");
            var result = new byte[1024*4];
            int dataEnd = 0 ;
            int dataCnt = 0 ;
            while (websocketClientPic.State == WebSocketState.Open)
            {
                websocketClientPic.ReceiveAsync(new ArraySegment<byte>(result), new CancellationToken());
                for (int i = 4095;i >= 0;i--)
                {
                    if (result[i] != 0)
                    {
                        dataEnd = i+1;
                        break;
                    }
                    if (i == 0)
                    {
                        dataEnd = 0;
                    }
                }
                if (dataEnd != 0) 
                {
                    picLength = dataEnd;
                    Buffer.BlockCopy(result, 0, picbuffer, dataCnt, picLength);
                    dataCnt += dataEnd;
                }

            }
        }

        private SerialPort picReadSerialPort;
        private void btn_picReadConnect_Click(object sender, EventArgs e)
        {
            if (this.btn_picReadConnect.Text == "连接串口")
            {
                picReadSerialPort = new SerialPort();
                picReadSerialPort.BaudRate = int.Parse(this.text_picReadBaudrate.Text);
                picReadSerialPort.PortName = this.text_picReadPort.Text;
                try
                {
                    picReadSerialPort.Open();
                    MessageBox.Show("连接成功");
                    this.btn_picReadConnect.Text = "串口关闭";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接失败：" + ex.Message);
                }
                
            }
            else
            {
                picReadSerialPort.Close();
                MessageBox.Show("关闭成功");
                this.btn_picReadConnect.Text = "连接串口";
            }
        }

        private void btn_picReadGetPic_Click(object sender, EventArgs e)
        {
            send_menu_cmd("050203.");
            while (true)
            {
                if (picReadSerialPort.BytesToRead > 0)
                {
                    var picValue = new byte[picReadSerialPort.BytesToRead];
                    picReadSerialPort.Read(picValue, 0, picReadSerialPort.BytesToRead);
                    Console.WriteLine(picReadSerialPort.BytesToRead.ToString());
                    break;
                }
            }
        }
    }
}
