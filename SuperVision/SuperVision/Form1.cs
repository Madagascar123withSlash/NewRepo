using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

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
                picReadSerialPort.PortName = "COM6";
                picReadSerialPort.StopBits = StopBits.One;
                picReadSerialPort.DataBits = 8;
                picReadSerialPort.Parity = Parity.None;
                picReadSerialPort.ReadBufferSize = 1024000;
                picReadSerialPort.ReadTimeout = 1000;
                picReadSerialPort.RtsEnable = true;
                picReadSerialPort.DtrEnable = true;
                //picReadSerialPort.Handshake = Handshake.RequestToSend;
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


        }

        private void btn_picStream_Click(object sender, EventArgs e)
        {


            send_menu_cmd("040807.");
            
            
        }
        List<byte[]> streamList = new List<byte[]>();
        System.Text.UTF8Encoding decoder = new UTF8Encoding();
        int byteCnt = 0;
        private void GetRecvMsg(object sender,SerialDataReceivedEventArgs e)
        {

            if (picReadSerialPort.BytesToRead > 0)
            {
                
                var picValue = new byte[picReadSerialPort.BytesToRead];
                picReadSerialPort.Read(picValue, 0, picReadSerialPort.BytesToRead);
                byteCnt+= picValue.Length;
                streamList.Add(picValue);
                string strdecode = decoder.GetString(picValue);
                if (strdecode.IndexOf("040807") > 0 )
                {
                    Console.WriteLine("111111");
                }
                //Console.WriteLine(strdecode);
                //Console.WriteLine(strdecode.Length.ToString());
                //Console.WriteLine("列表大小：" + streamList.Count.ToString());
            }
            
        }
        private byte[] picbuffer;
        private void btn_dataProcess_Click(object sender, EventArgs e)
        {
            byte[] dataFlow = new byte[byteCnt];
            int memberCnt =0;//list里面成员大小的累计
            foreach (byte[] l in streamList) 
            {
                Buffer.BlockCopy(l, 0, dataFlow, memberCnt, l.Length);
                memberCnt+= l.Length;
            }
            string flowdecode = decoder.GetString(dataFlow);
            int at = flowdecode.IndexOf("JFIF", 0)-6;
            int end = flowdecode.IndexOf("040807", 100);
            picbuffer = new byte[end-at];
            Buffer.BlockCopy(dataFlow, at, picbuffer, 0, end - at);
            //Console.WriteLine(decoder.GetString(picbuffer));
        }

        private void btn_displayPic_Click(object sender, EventArgs e)
        {
            try
            {
                var bitmap = Image.FromStream(new MemoryStream(picbuffer));//数据流自带图像信息，直接转化。
                this.pictureBox_main.Image = bitmap;

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
