using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CloseTimer.Interval = 10;
            CloseTimer.Tick += CloseTimer_Tick;
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {//Opacity从1开始减
            if (this.Opacity >= 0.025) { this.Opacity -= 0.025; }
            else { this.CloseTimer.Enabled = false;
                this.Close();
            }
        }

        //窗体渐变
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0,0,this.Width,this.Height);
            //Rectangle rec = new Rectangle(0,0,100,100);
            LinearGradientBrush brush = new LinearGradientBrush(rec, Color.FromArgb(225, 101, 122), Color.FromArgb(93, 127, 124), LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(brush, rec);
        }


        //以下两个事件将实现边框拖动
        private Point mousePoint;
        private void label_title_MouseDown(object sender, MouseEventArgs e)
        {//这里先获取鼠标在按下时的坐标即初始距离
            mousePoint = e.Location;
        }

        private void label_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //只有左键的情况下
            //重新设置窗体的当前位置
            { //窗体当前位置+鼠标滑动的距离(鼠标当前距离-鼠标初始距离)
                this.Location = new Point(this.Location.X + e.X - mousePoint.X, this.Location.Y + e.Y - mousePoint.Y);
            }
        }

        private Timer CloseTimer = new Timer();//创建定时器
        private void pic_close_Click(object sender, EventArgs e)
        {
            CloseTimer.Enabled = true;//开定时器
        }

        private void text_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.btn_login_Click(null, null);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;//使用ShowDialog方式弹出窗体时，只要设置了DialogResult，窗体都将自动关闭。该逻辑在底层默认执行。
        }
    }
}
