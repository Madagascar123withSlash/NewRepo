namespace MyFirstWork
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl_dataTransfer = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_tcpSend = new System.Windows.Forms.Button();
            this.richTextBox_tcpSend = new System.Windows.Forms.RichTextBox();
            this.richTextBox_tcpReceive = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.text_serialBaudrate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_serialConnect = new System.Windows.Forms.Button();
            this.text_serialPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.text_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_browsefile = new System.Windows.Forms.Button();
            this.text_fileDir = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_showPic = new System.Windows.Forms.Button();
            this.btn_browsepic = new System.Windows.Forms.Button();
            this.text_picDir = new System.Windows.Forms.TextBox();
            this.btn_getScannerPic = new System.Windows.Forms.Button();
            this.text_displayerport = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text_displayerip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_window = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_picReadPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.text_picReadBaudrate = new System.Windows.Forms.TextBox();
            this.btn_picReadConnect = new System.Windows.Forms.Button();
            this.btn_picReadGetPic = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl_dataTransfer.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_window)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 575);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tabControl_dataTransfer);
            this.tabPage1.Controls.Add(this.text_serialBaudrate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btn_serialConnect);
            this.tabPage1.Controls.Add(this.text_serialPort);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btn_connect);
            this.tabPage1.Controls.Add(this.text_port);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.text_ip);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "socket-server";
            // 
            // tabControl_dataTransfer
            // 
            this.tabControl_dataTransfer.Controls.Add(this.tabPage3);
            this.tabControl_dataTransfer.Controls.Add(this.tabPage4);
            this.tabControl_dataTransfer.Location = new System.Drawing.Point(20, 148);
            this.tabControl_dataTransfer.Name = "tabControl_dataTransfer";
            this.tabControl_dataTransfer.SelectedIndex = 0;
            this.tabControl_dataTransfer.Size = new System.Drawing.Size(976, 386);
            this.tabControl_dataTransfer.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_tcpSend);
            this.tabPage3.Controls.Add(this.richTextBox_tcpSend);
            this.tabPage3.Controls.Add(this.richTextBox_tcpReceive);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(968, 353);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tcp_transfer";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_tcpSend
            // 
            this.btn_tcpSend.Location = new System.Drawing.Point(813, 6);
            this.btn_tcpSend.Name = "btn_tcpSend";
            this.btn_tcpSend.Size = new System.Drawing.Size(75, 34);
            this.btn_tcpSend.TabIndex = 12;
            this.btn_tcpSend.Text = "发送";
            this.btn_tcpSend.UseVisualStyleBackColor = true;
            this.btn_tcpSend.Click += new System.EventHandler(this.btn_tcpSend_Click);
            // 
            // richTextBox_tcpSend
            // 
            this.richTextBox_tcpSend.Location = new System.Drawing.Point(467, 3);
            this.richTextBox_tcpSend.Name = "richTextBox_tcpSend";
            this.richTextBox_tcpSend.Size = new System.Drawing.Size(347, 341);
            this.richTextBox_tcpSend.TabIndex = 11;
            this.richTextBox_tcpSend.Text = "";
            // 
            // richTextBox_tcpReceive
            // 
            this.richTextBox_tcpReceive.Location = new System.Drawing.Point(6, 6);
            this.richTextBox_tcpReceive.Name = "richTextBox_tcpReceive";
            this.richTextBox_tcpReceive.ReadOnly = true;
            this.richTextBox_tcpReceive.Size = new System.Drawing.Size(347, 341);
            this.richTextBox_tcpReceive.TabIndex = 10;
            this.richTextBox_tcpReceive.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(968, 353);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // text_serialBaudrate
            // 
            this.text_serialBaudrate.Location = new System.Drawing.Point(601, 82);
            this.text_serialBaudrate.Name = "text_serialBaudrate";
            this.text_serialBaudrate.Size = new System.Drawing.Size(129, 26);
            this.text_serialBaudrate.TabIndex = 9;
            this.text_serialBaudrate.Text = "115200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "波特率：";
            // 
            // btn_serialConnect
            // 
            this.btn_serialConnect.Location = new System.Drawing.Point(837, 85);
            this.btn_serialConnect.Name = "btn_serialConnect";
            this.btn_serialConnect.Size = new System.Drawing.Size(75, 34);
            this.btn_serialConnect.TabIndex = 7;
            this.btn_serialConnect.Text = "打开";
            this.btn_serialConnect.UseVisualStyleBackColor = true;
            this.btn_serialConnect.Click += new System.EventHandler(this.btn_serialConnect_Click);
            // 
            // text_serialPort
            // 
            this.text_serialPort.Location = new System.Drawing.Point(169, 82);
            this.text_serialPort.Name = "text_serialPort";
            this.text_serialPort.Size = new System.Drawing.Size(208, 26);
            this.text_serialPort.TabIndex = 6;
            this.text_serialPort.Text = "COM3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "串口号：";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(837, 27);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 34);
            this.btn_connect.TabIndex = 4;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(601, 30);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(129, 26);
            this.text_port.TabIndex = 3;
            this.text_port.Text = "23";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标端口号：";
            // 
            // text_ip
            // 
            this.text_ip.Location = new System.Drawing.Point(169, 27);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(208, 26);
            this.text_ip.TabIndex = 1;
            this.text_ip.Text = "192.168.100.144";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标IP地址：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_print);
            this.tabPage2.Controls.Add(this.btn_browsefile);
            this.tabPage2.Controls.Add(this.text_fileDir);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "printer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(853, 69);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(123, 37);
            this.btn_print.TabIndex = 2;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_browsefile
            // 
            this.btn_browsefile.Location = new System.Drawing.Point(853, 3);
            this.btn_browsefile.Name = "btn_browsefile";
            this.btn_browsefile.Size = new System.Drawing.Size(123, 36);
            this.btn_browsefile.TabIndex = 1;
            this.btn_browsefile.Text = "浏览";
            this.btn_browsefile.UseVisualStyleBackColor = true;
            this.btn_browsefile.Click += new System.EventHandler(this.btn_browsefile_Click);
            // 
            // text_fileDir
            // 
            this.text_fileDir.Location = new System.Drawing.Point(8, 6);
            this.text_fileDir.Name = "text_fileDir";
            this.text_fileDir.ReadOnly = true;
            this.text_fileDir.Size = new System.Drawing.Size(757, 26);
            this.text_fileDir.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_picReadGetPic);
            this.tabPage5.Controls.Add(this.btn_picReadConnect);
            this.tabPage5.Controls.Add(this.text_picReadBaudrate);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.text_picReadPort);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.btn_showPic);
            this.tabPage5.Controls.Add(this.btn_browsepic);
            this.tabPage5.Controls.Add(this.text_picDir);
            this.tabPage5.Controls.Add(this.btn_getScannerPic);
            this.tabPage5.Controls.Add(this.text_displayerport);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.text_displayerip);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.pictureBox_window);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1004, 542);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "displayer";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_showPic
            // 
            this.btn_showPic.Location = new System.Drawing.Point(893, 485);
            this.btn_showPic.Name = "btn_showPic";
            this.btn_showPic.Size = new System.Drawing.Size(47, 26);
            this.btn_showPic.TabIndex = 8;
            this.btn_showPic.Text = "显示";
            this.btn_showPic.UseVisualStyleBackColor = true;
            this.btn_showPic.Click += new System.EventHandler(this.btn_showPic_Click);
            // 
            // btn_browsepic
            // 
            this.btn_browsepic.Location = new System.Drawing.Point(847, 485);
            this.btn_browsepic.Name = "btn_browsepic";
            this.btn_browsepic.Size = new System.Drawing.Size(47, 26);
            this.btn_browsepic.TabIndex = 7;
            this.btn_browsepic.Text = "浏览";
            this.btn_browsepic.UseVisualStyleBackColor = true;
            this.btn_browsepic.Click += new System.EventHandler(this.btn_browsepic_Click);
            // 
            // text_picDir
            // 
            this.text_picDir.Enabled = false;
            this.text_picDir.Location = new System.Drawing.Point(592, 485);
            this.text_picDir.Name = "text_picDir";
            this.text_picDir.Size = new System.Drawing.Size(243, 26);
            this.text_picDir.TabIndex = 6;
            // 
            // btn_getScannerPic
            // 
            this.btn_getScannerPic.Location = new System.Drawing.Point(697, 168);
            this.btn_getScannerPic.Name = "btn_getScannerPic";
            this.btn_getScannerPic.Size = new System.Drawing.Size(243, 35);
            this.btn_getScannerPic.TabIndex = 5;
            this.btn_getScannerPic.Text = "抓图";
            this.btn_getScannerPic.UseVisualStyleBackColor = true;
            this.btn_getScannerPic.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_displayerport
            // 
            this.text_displayerport.Location = new System.Drawing.Point(697, 114);
            this.text_displayerport.Name = "text_displayerport";
            this.text_displayerport.Size = new System.Drawing.Size(243, 26);
            this.text_displayerport.TabIndex = 4;
            this.text_displayerport.Text = "6432";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(588, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "设备端口";
            // 
            // text_displayerip
            // 
            this.text_displayerip.Location = new System.Drawing.Point(697, 43);
            this.text_displayerip.Name = "text_displayerip";
            this.text_displayerip.Size = new System.Drawing.Size(243, 26);
            this.text_displayerip.TabIndex = 2;
            this.text_displayerip.Text = "192.168.100.144";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "设备地址";
            // 
            // pictureBox_window
            // 
            this.pictureBox_window.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_window.Name = "pictureBox_window";
            this.pictureBox_window.Size = new System.Drawing.Size(564, 542);
            this.pictureBox_window.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_window.TabIndex = 0;
            this.pictureBox_window.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(588, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "串口号";
            // 
            // text_picReadPort
            // 
            this.text_picReadPort.Location = new System.Drawing.Point(697, 292);
            this.text_picReadPort.Name = "text_picReadPort";
            this.text_picReadPort.Size = new System.Drawing.Size(53, 26);
            this.text_picReadPort.TabIndex = 10;
            this.text_picReadPort.Text = "COM6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(784, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "波特率";
            // 
            // text_picReadBaudrate
            // 
            this.text_picReadBaudrate.Location = new System.Drawing.Point(887, 289);
            this.text_picReadBaudrate.Name = "text_picReadBaudrate";
            this.text_picReadBaudrate.Size = new System.Drawing.Size(53, 26);
            this.text_picReadBaudrate.TabIndex = 12;
            this.text_picReadBaudrate.Text = "115200";
            // 
            // btn_picReadConnect
            // 
            this.btn_picReadConnect.Location = new System.Drawing.Point(592, 375);
            this.btn_picReadConnect.Name = "btn_picReadConnect";
            this.btn_picReadConnect.Size = new System.Drawing.Size(158, 35);
            this.btn_picReadConnect.TabIndex = 13;
            this.btn_picReadConnect.Text = "连接串口";
            this.btn_picReadConnect.UseVisualStyleBackColor = true;
            this.btn_picReadConnect.Click += new System.EventHandler(this.btn_picReadConnect_Click);
            // 
            // btn_picReadGetPic
            // 
            this.btn_picReadGetPic.Location = new System.Drawing.Point(782, 375);
            this.btn_picReadGetPic.Name = "btn_picReadGetPic";
            this.btn_picReadGetPic.Size = new System.Drawing.Size(158, 35);
            this.btn_picReadGetPic.TabIndex = 14;
            this.btn_picReadGetPic.Text = "获取图像";
            this.btn_picReadGetPic.UseVisualStyleBackColor = true;
            this.btn_picReadGetPic.Click += new System.EventHandler(this.btn_picReadGetPic_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 575);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl_dataTransfer.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_window)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_serialConnect;
        private System.Windows.Forms.TextBox text_serialPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_serialBaudrate;
        private System.Windows.Forms.RichTextBox richTextBox_tcpReceive;
        private System.Windows.Forms.TabControl tabControl_dataTransfer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_tcpSend;
        private System.Windows.Forms.RichTextBox richTextBox_tcpSend;
        private System.Windows.Forms.Button btn_browsefile;
        private System.Windows.Forms.TextBox text_fileDir;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox pictureBox_window;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_displayerip;
        private System.Windows.Forms.TextBox text_displayerport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_picDir;
        private System.Windows.Forms.Button btn_getScannerPic;
        private System.Windows.Forms.Button btn_browsepic;
        private System.Windows.Forms.Button btn_showPic;
        private System.Windows.Forms.TextBox text_picReadPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_picReadBaudrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_picReadConnect;
        private System.Windows.Forms.Button btn_picReadGetPic;
    }
}