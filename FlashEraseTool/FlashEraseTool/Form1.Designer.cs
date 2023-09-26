namespace FlashEraseTool
{
    partial class mainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.lb_port = new System.Windows.Forms.Label();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.btn_erase = new System.Windows.Forms.Button();
            this.btn_refreshPort = new System.Windows.Forms.Button();
            this.richTextBox_recv = new System.Windows.Forms.RichTextBox();
            this.richTextBox_message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_port.Location = new System.Drawing.Point(16, 50);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(52, 21);
            this.lb_port.TabIndex = 0;
            this.lb_port.Text = "端口";
            // 
            // cb_port
            // 
            this.cb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_port.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(79, 45);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(121, 29);
            this.cb_port.TabIndex = 1;
            // 
            // btn_erase
            // 
            this.btn_erase.AutoSize = true;
            this.btn_erase.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_erase.Location = new System.Drawing.Point(590, 45);
            this.btn_erase.Name = "btn_erase";
            this.btn_erase.Size = new System.Drawing.Size(97, 31);
            this.btn_erase.TabIndex = 2;
            this.btn_erase.Text = "擦除";
            this.btn_erase.UseVisualStyleBackColor = true;
            this.btn_erase.Click += new System.EventHandler(this.btn_erase_Click);
            // 
            // btn_refreshPort
            // 
            this.btn_refreshPort.AutoSize = true;
            this.btn_refreshPort.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_refreshPort.Location = new System.Drawing.Point(239, 45);
            this.btn_refreshPort.Name = "btn_refreshPort";
            this.btn_refreshPort.Size = new System.Drawing.Size(104, 31);
            this.btn_refreshPort.TabIndex = 3;
            this.btn_refreshPort.Text = "刷新";
            this.btn_refreshPort.UseVisualStyleBackColor = true;
            this.btn_refreshPort.Click += new System.EventHandler(this.btn_refreshPort_Click);
            // 
            // richTextBox_recv
            // 
            this.richTextBox_recv.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_recv.Location = new System.Drawing.Point(20, 93);
            this.richTextBox_recv.Name = "richTextBox_recv";
            this.richTextBox_recv.ReadOnly = true;
            this.richTextBox_recv.Size = new System.Drawing.Size(441, 451);
            this.richTextBox_recv.TabIndex = 4;
            this.richTextBox_recv.Text = "";
            // 
            // richTextBox_message
            // 
            this.richTextBox_message.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.richTextBox_message.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox_message.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_message.Location = new System.Drawing.Point(493, 93);
            this.richTextBox_message.Name = "richTextBox_message";
            this.richTextBox_message.Size = new System.Drawing.Size(288, 451);
            this.richTextBox_message.TabIndex = 5;
            this.richTextBox_message.Text = "";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 566);
            this.Controls.Add(this.richTextBox_message);
            this.Controls.Add(this.richTextBox_recv);
            this.Controls.Add(this.btn_refreshPort);
            this.Controls.Add(this.btn_erase);
            this.Controls.Add(this.cb_port);
            this.Controls.Add(this.lb_port);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainWindow";
            this.Text = "FlashErase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.Button btn_erase;
        private System.Windows.Forms.Button btn_refreshPort;
        private System.Windows.Forms.RichTextBox richTextBox_recv;
        private System.Windows.Forms.RichTextBox richTextBox_message;
    }
}

