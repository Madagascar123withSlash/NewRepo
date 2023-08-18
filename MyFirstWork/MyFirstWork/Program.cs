using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWork
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 frm = new Form1();
            DialogResult dr = frm.ShowDialog();//此方式弹出窗口，在设置DialogResult时窗体自动关闭
            if (dr == DialogResult.OK) 
            {
                Application.Run(new MainWindow());
            }

            //Application.Run(new Form1());
        }
    }
}
