using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashEraseTool
{


    public partial class mainWindow : Form
    {
        string[] portnames = SerialPort.GetPortNames();
        string receivedText = string.Empty;
        public mainWindow()
        {
            InitializeComponent();
            this.richTextBox_recv.ScrollToCaret();


            foreach (var port in portnames)
            {
                this.cb_port.Items.Add(port);
            }
            if (portnames.Length != 0)
            {
                this.cb_port.SelectedIndex = 0;
            }
        }


        bool bootModeFlag;
        bool eraseFlag;
        bool step2Flag;//线程将同步启动但因为时序不同分开运行，分为2个阶段
        private void btn_erase_Click(object sender, EventArgs e)
        {
            this.richTextBox_recv.Clear();

            bootModeFlag = false;
            eraseFlag = false;
            step2Flag = false;
            bool ret =  SerialPortConnect();
            if (ret) 
            {
                Task.Run(new Action(() => { ThreadBootModeTrigger(); }));
                Task.Run(new Action(() => { ThreadCheckBoot("SigmaStar"); }));
                Task.Run(new Action(() => { ThreadBootErase(); }));
                Console.WriteLine("所有线程开启成功！");
            }

        }
        private void ThreadBootErase()
        {
            while (true)
            {
                if (step2Flag)
                {
                    Console.WriteLine("开始flash擦除！");
                    int index = -1;
                    Thread.Sleep(1000);
                    BootModeErase();
                    step2Flag=false;
                    
                    while (!eraseFlag)
                    {
                        GetText();
                        index = receivedText.IndexOf("complete");
                        if (index >= 0)
                        {
                            eraseFlag = true;
                        }

                    }
                    if (eraseFlag == true)
                    {
                        eraseFlag=false;
                        port.Close();
                        ShowDialog();
                        MessageBox.Show("擦除完成！");
                        break;
                    }

                }
            }
        }
        private void ThreadCheckBoot(string Text)
        {
            Console.WriteLine("进入到检查内容线程！");
            int index = -1;
            while (!bootModeFlag)
            {
                GetText();
                try {    
                index = receivedText.IndexOf(Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("位于ThreadCheckBoot线程内：" + ex.Message);
                }
                if (index >= 0)
                {
                    Console.WriteLine("进入Boot模式成功！");
                    bootModeFlag = true;
                    step2Flag = true;
                }
                Thread.Sleep(100);
            }
        }
        private void ThreadBootModeTrigger()
        {
            while (!bootModeFlag)
            {
                BootModeTrigger();
                Thread.Sleep(500);
            }
        }
        private void BootModeTrigger()
        {
            string hex_1 = "0A";
            string hex_2 = "0D";
            byte[] keyboardEnter = new byte[2];
            keyboardEnter[0] = Convert.ToByte(hex_1,16);
            keyboardEnter[1] = Convert.ToByte(hex_2,16);
            port.Write(keyboardEnter,0, 2);
        }
        private void BootModeErase()
        {
            string cmdstr = "nand erase 0x0 0x10000";
            byte[] cmdbyte = new byte[cmdstr.Length];
            cmdbyte = Encoding.ASCII.GetBytes(cmdstr);
            byte[] cmdCombine = new byte[cmdbyte.Length + 2];
            cmdbyte.CopyTo(cmdCombine,0);
            cmdCombine[cmdbyte.Length] = Convert.ToByte("0A",16);
            cmdCombine[cmdbyte.Length + 1] = Convert.ToByte("0D", 16);//把回车拼接到最后
            port.Write(cmdCombine,0,cmdCombine.Length);

        }

        private SerialPort port;

        private bool SerialPortConnect()
        {
            port = new SerialPort();
            port.BaudRate = 115200;
            port.PortName = this.cb_port.Text;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.DtrEnable = true;
            port.RtsEnable = true;
            port.DataReceived += new SerialDataReceivedEventHandler(GetRecvMsg);
            try
            {
                port.Open();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败：" +  ex.Message);
                return false;
            }
        }
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        private void GetRecvMsg(object sender, SerialDataReceivedEventArgs e)
        {
            if (port.BytesToRead > 0)
            {
                int toReadCnt = port.BytesToRead;
                var recvValue = new byte[toReadCnt];
                port.Read(recvValue, 0, toReadCnt);
                string text = encoding.GetString(recvValue);
                SetText(text);
            }
        }
        delegate void SetTextCallBack(string text);
        private void SetText(string text)
        {
            if (this.richTextBox_recv.InvokeRequired) {
                SetTextCallBack stcb = new SetTextCallBack(SetText);
                this.Invoke(stcb, new object[] { text });
            }
            else
            {
                this.richTextBox_recv.Text += text;
            }
        }
        delegate void GetTextCallBack();
        private void GetText()
        {
            if (this.richTextBox_recv.InvokeRequired)
            {
                GetTextCallBack gtcb = new GetTextCallBack(GetText);
                this.Invoke(gtcb);
            }
            else
            {
                receivedText = this.richTextBox_recv.Text;  
            }
        }
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_refreshPort_Click(object sender, EventArgs e)
        {
            this.cb_port.Items.Clear();
            string[] refreshPortnames = SerialPort.GetPortNames();
            foreach (var  port in refreshPortnames)
            {
                this.cb_port.Items.Add(port);
            }
            if (refreshPortnames.Length != 0)
            {
                this.cb_port.SelectedIndex = 0;
            }
        }
    }
}
