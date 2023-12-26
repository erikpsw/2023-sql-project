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
    
    public partial class 登录 : Form
    {
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 登录()
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
            //textBox1.Text = "D555555555";
            //textBox2.Text = "P555555555";
            textBox1.Text = "A123456789";
            textBox2.Text = "P123456789";

        }
        // 添加 SetUsername 和 SetPassword 方法
        public void SetUsername(string username)
        {
            textBox1.Text = username;
        }

        public void SetPassword(string password)
        {
            textBox2.Text = password;
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
                res = (int)data[0];

                if(res == 1)
                {
                    string name1 = data[1].ToString();
                    data.Close();
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
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册 f3 = new 注册();
            f3.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f3 = new 忘记密码();
            f3.ShowDialog();
        }
    }
}
