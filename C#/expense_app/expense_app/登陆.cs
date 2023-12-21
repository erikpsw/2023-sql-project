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
using System.Diagnostics;

namespace expense_app
{
    
    public partial class 登陆 : Form
    {
        String conStr = @"Server=.\SQLEXPRESS;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 登陆()
        {
            conn = new SqlConnection(conStr); //创建连接
            InitializeComponent();

            try
            {
                conn.Open(); //打开连接
                MessageBox.Show("数据库连接测试成功！", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "D555555555";
            textBox2.Text = "P555555555";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String userid = textBox1.Text ;
            String password = textBox2.Text;
            String sql = "EXEC login @UserID=" + userid + ", @Password=" + password;
            Debug.WriteLine(sql);

            SqlCommand cmd = new SqlCommand(sql, conn);
            int res;
            SqlDataReader data; 
            try
            {
                data = cmd.ExecuteReader();
                data.Read();
                Debug.WriteLine(data[1]);
                res = (int)data[0];
     
                string name1 = data[1].ToString();
                data.Close();
                if(res == 1)
                {
                    MessageBox.Show("登录成功");
                    String sql1 = "select * from Admins where AdminID='"+ userid+"'";
                    cmd = new SqlCommand(sql1, conn);
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        rd.Close();
                        管理总页面 f2 = new 管理总页面(name1, userid);
                        conn.Close();
                        this.Hide(); // 隐藏当前窗体
                        f2.ShowDialog();
                    }
                    else {
                        rd.Close();
                        报销总页面 f2 = new 报销总页面(name1, userid);
                        conn.Close();
                        this.Hide(); // 隐藏当前窗体
                        f2.ShowDialog();
                    }

                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
