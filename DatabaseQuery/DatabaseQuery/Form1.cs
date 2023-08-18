using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string connString = "server=192.168.1.251;user=sa;password=Aa123456;database=superlead";
        private void btn_checkbyMac_Click(object sender, EventArgs e)
        {
            try
            {


                var conn = new SqlConnection(connString);
                conn.Open();
                string command = $"select * from [dbo].[Mactable] where MAC = '{this.text_checkbyMac.Text}'";
                SqlCommand cmd = new SqlCommand(command, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int index = dataGridView1.Rows.Add(row);
                    for (int i = 0; i<7; i++)
                    {
                        dataGridView1.Rows[index].Cells[i].Value = reader[i].ToString();
                
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库访问异常：" + ex.Message);
            }
        }
    }
}
