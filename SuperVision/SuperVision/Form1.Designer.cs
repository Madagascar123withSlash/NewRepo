namespace SuperVision
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.btn_showpic = new System.Windows.Forms.Button();
            this.btn_picReadConnect = new System.Windows.Forms.Button();
            this.btn_picStream = new System.Windows.Forms.Button();
            this.btn_dataProcess = new System.Windows.Forms.Button();
            this.btn_displayPic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.Location = new System.Drawing.Point(1, 1);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(589, 452);
            this.pictureBox_main.TabIndex = 0;
            this.pictureBox_main.TabStop = false;
            // 
            // btn_showpic
            // 
            this.btn_showpic.Location = new System.Drawing.Point(621, 12);
            this.btn_showpic.Name = "btn_showpic";
            this.btn_showpic.Size = new System.Drawing.Size(154, 39);
            this.btn_showpic.TabIndex = 1;
            this.btn_showpic.Text = "测试";
            this.btn_showpic.UseVisualStyleBackColor = true;
            this.btn_showpic.Click += new System.EventHandler(this.btn_showpic_Click);
            // 
            // btn_picReadConnect
            // 
            this.btn_picReadConnect.Location = new System.Drawing.Point(621, 75);
            this.btn_picReadConnect.Name = "btn_picReadConnect";
            this.btn_picReadConnect.Size = new System.Drawing.Size(154, 42);
            this.btn_picReadConnect.TabIndex = 2;
            this.btn_picReadConnect.Text = "连接串口";
            this.btn_picReadConnect.UseVisualStyleBackColor = true;
            this.btn_picReadConnect.Click += new System.EventHandler(this.btn_picReadConnect_Click);
            // 
            // btn_picStream
            // 
            this.btn_picStream.Location = new System.Drawing.Point(621, 141);
            this.btn_picStream.Name = "btn_picStream";
            this.btn_picStream.Size = new System.Drawing.Size(154, 45);
            this.btn_picStream.TabIndex = 3;
            this.btn_picStream.Text = "获取数据流";
            this.btn_picStream.UseVisualStyleBackColor = true;
            this.btn_picStream.Click += new System.EventHandler(this.btn_picStream_Click);
            // 
            // btn_dataProcess
            // 
            this.btn_dataProcess.Location = new System.Drawing.Point(621, 204);
            this.btn_dataProcess.Name = "btn_dataProcess";
            this.btn_dataProcess.Size = new System.Drawing.Size(154, 45);
            this.btn_dataProcess.TabIndex = 4;
            this.btn_dataProcess.Text = "数据拼接";
            this.btn_dataProcess.UseVisualStyleBackColor = true;
            this.btn_dataProcess.Click += new System.EventHandler(this.btn_dataProcess_Click);
            // 
            // btn_displayPic
            // 
            this.btn_displayPic.Location = new System.Drawing.Point(621, 266);
            this.btn_displayPic.Name = "btn_displayPic";
            this.btn_displayPic.Size = new System.Drawing.Size(154, 45);
            this.btn_displayPic.TabIndex = 5;
            this.btn_displayPic.Text = "展示图像";
            this.btn_displayPic.UseVisualStyleBackColor = true;
            this.btn_displayPic.Click += new System.EventHandler(this.btn_displayPic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_displayPic);
            this.Controls.Add(this.btn_dataProcess);
            this.Controls.Add(this.btn_picStream);
            this.Controls.Add(this.btn_picReadConnect);
            this.Controls.Add(this.btn_showpic);
            this.Controls.Add(this.pictureBox_main);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Button btn_showpic;
        private System.Windows.Forms.Button btn_picReadConnect;
        private System.Windows.Forms.Button btn_picStream;
        private System.Windows.Forms.Button btn_dataProcess;
        private System.Windows.Forms.Button btn_displayPic;
    }
}

