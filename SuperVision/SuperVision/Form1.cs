using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using static System.Net.Mime.MediaTypeNames;

namespace SuperVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mat img1 = new Mat("C:\\Users\\Thinkpad\\Desktop\\test.jpg");
        private void btn_showpic_Click(object sender, EventArgs e)
        {
            Cv2.ImShow("123", img1);
            Cv2.WaitKey(0);
        }
        private SerialPort picReadSerialPort;
        private void btn_picReadConnect_Click(object sender, EventArgs e)
        {
            if (this.btn_picReadConnect.Text == "连接串口")
            {
                picReadSerialPort = new SerialPort();
                picReadSerialPort.BaudRate = 115200;
                picReadSerialPort.PortName = "COM13";
                picReadSerialPort.StopBits = StopBits.One;
                picReadSerialPort.DataBits = 8;
                picReadSerialPort.Parity = Parity.None;
                picReadSerialPort.ReadBufferSize = 1024000;
                picReadSerialPort.ReadTimeout = 1000;
                picReadSerialPort.RtsEnable = true;
                picReadSerialPort.DtrEnable = true;
                picReadSerialPort.Handshake = Handshake.RequestToSend;
                picReadSerialPort.DataReceived += new SerialDataReceivedEventHandler(GetRecvMsg);
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
        private void send_trigger_cmd()
        {
            string hex_1 = "02";
            string hex_2 = "f4";
            string hex_3 = "03";
            byte[] cmd_trigger = new byte[3];
            cmd_trigger[0] = Convert.ToByte(hex_1, 16);
            cmd_trigger[1] = Convert.ToByte(hex_2, 16);
            cmd_trigger[2] = Convert.ToByte(hex_3, 16);
            picReadSerialPort.Write(cmd_trigger,0,cmd_trigger.Length);
            Console.WriteLine("触发使能");
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

            picReadSerialPort.Write(cmd_combine, 0, cmd_combine.Length);
            Console.WriteLine("发送消息：" + cmd);

        }

        private void btn_picStream_Click(object sender, EventArgs e)
        {

            send_menu_cmd("0E01008!;024DF0!.");
            //send_menu_cmd("0401000;0402171300;0403061300;04021664;04030764;0409062.");
            Thread.Sleep(100);
            //send_trigger_cmd();
            Thread.Sleep(100);
            send_menu_cmd("040807.");
            
            
        }
        List<byte[]> streamList = new List<byte[]>();
        System.Text.UTF8Encoding decoder = new UTF8Encoding();//不能使用UTF8解码数据流，会导致索引数据流位置时数据位变短
        System.Text.ASCIIEncoding encoder = new ASCIIEncoding();//暂时使用ascII解码
        int byteCnt = 0;
        private void GetRecvMsg(object sender,SerialDataReceivedEventArgs e)
        {

            if (picReadSerialPort.BytesToRead > 0)
            {
                int toReadCnt = picReadSerialPort.BytesToRead;//不能在下面的语句中直接使用ByteToRead，因为两个语句执行期间，串口缓冲区中的数据也在变化
                var picValue = new byte[toReadCnt];
                picReadSerialPort.Read(picValue, 0, toReadCnt);
                byteCnt+= picValue.Length;
                streamList.Add(picValue);
                string strdecode = decoder.GetString(picValue);
                if (strdecode.IndexOf("040807\u0015") >= 0)
                {
                    streamList.Clear();
                }
                if (strdecode.IndexOf("040807\u0006") >= 0 )
                {
                    btn_dataProcess_Click();
                    btn_displayPic_Click();
                    send_menu_cmd("040807.");
                }
                //Console.WriteLine("开始：" + strdecode);
                //Console.WriteLine(strdecode.Length.ToString());
                //Console.WriteLine("列表大小：" + streamList.Count.ToString());
            }
            
        }
        private byte[] picbuffer;
        private void btn_dataProcess_Click()
        {
            byte[] dataFlow = new byte[byteCnt];
            int memberCnt = 0;//list里面成员大小的累计,以byte为单位
            foreach (byte[] l in streamList)
            {
                Buffer.BlockCopy(l, 0, dataFlow, memberCnt, l.Length);
                memberCnt += l.Length;
            }
            string flowdecode = encoder.GetString(dataFlow);
            int at = flowdecode.IndexOf("JFIF", 0) - 6;
            int end = flowdecode.IndexOf("040807", 100);
            picbuffer = new byte[end - at];
            Buffer.BlockCopy(dataFlow, at, picbuffer, 0, end - at);
            //Console.WriteLine(decoder.GetString(picbuffer));
        }
        private void btn_dataProcess_Click(object sender, EventArgs e)
        {
            byte[] dataFlow = new byte[byteCnt];
            int memberCnt =0;//list里面成员大小的累计,以byte为单位
            foreach (byte[] l in streamList) 
            {
                Buffer.BlockCopy(l, 0, dataFlow, memberCnt, l.Length);
                memberCnt+= l.Length;
            }
            string flowdecode = encoder.GetString(dataFlow);
            Console.WriteLine("解码后的字符串长度：" + flowdecode.Length.ToString());
            int at = flowdecode.IndexOf("JFIF", 0)-6;
            int end = flowdecode.IndexOf("040807\u0006",100);
            picbuffer = new byte[end-at];
            Buffer.BlockCopy(dataFlow, at, picbuffer, 0, end - at);
            //Console.WriteLine(decoder.GetString(picbuffer));
        }
        private void btn_displayPic_Click()
        {
            try
            {
                var image = System.Drawing.Image.FromStream(new MemoryStream(picbuffer));//数据流自带图像信息，直接转化。
                var bitmap = new Bitmap(image);
                this.pictureBox_main.Image = image;
                //var mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                //Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2GRAY);
                //var clahe = Cv2.CreateCLAHE();
                //clahe.ClipLimit = 2.0;
                //clahe.TilesGridSize = new OpenCvSharp.Size(8, 8);
                //clahe.Apply(mat, mat);
                //var element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(30, 30));
                //Cv2.MorphologyEx(mat, mat, MorphTypes.Close, element);


                //var outputBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
                //this.pictureBox_main.Image = outputBitmap;
                Console.WriteLine("图片大小：" + picbuffer.Length.ToString());

            }
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
            catch (Exception) 
            {
                var errorArray = picbuffer.ToArray();
                string errorStringBase64 = Convert.ToBase64String(errorArray);
                string errorStringUTF8 = System.Text.Encoding.UTF8.GetString(errorArray);


                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyMMdd HHmmssfff") + ".txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("data:image/jpg;base64," + errorStringBase64);
                sw.Close();
                fs.Close();
                Console.WriteLine("已忽略异常");
                Console.WriteLine(Directory.GetCurrentDirectory());
            }
            streamList.Clear();
            byteCnt = 0;

        }
        private void saveHexString(byte[] data)
        {
            string sb = BitConverter.ToString(data);


            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyMMdd HHmmssfff") + "good.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(sb);
            sw.Close();
            fs.Close();
        }
        private void saveHexString(string data)
        {
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + DateTime.Now.ToString("yyMMdd HHmmssfff") + "good.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(data);
            sw.Close();
            fs.Close();
        }
        private void btn_displayPic_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream picStream = new MemoryStream(picbuffer);
                var image = System.Drawing.Image.FromStream(picStream, true);//数据流自带图像信息，直接转化。

                var bitmap = new Bitmap(image);
                this.pictureBox_main.Image = image;
                Console.WriteLine("图像宽：" + image.Width.ToString());
                Console.WriteLine("图像高：" + image.Height.ToString());

                //var errorArray = picbuffer.ToArray();
                //string errorStringBase64 = Convert.ToBase64String(errorArray);
                //saveHexString("data:image/jpg;base64," + errorStringBase64);

                var mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                Cv2.ImShow("12", mat);
                Cv2.WaitKey(0);
                //Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2GRAY);
                //var clahe = Cv2.CreateCLAHE();
                //clahe.ClipLimit = 2.0;
                //clahe.TilesGridSize = new OpenCvSharp.Size(8,8);
                //clahe.Apply(mat, mat);
                //var element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(30, 30));
                //Cv2.MorphologyEx(mat, mat, MorphTypes.Close, element);


                //var outputBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
                //this.pictureBox_main.Image = outputBitmap;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            streamList.Clear();
            byteCnt = 0;

        }
    }
}
