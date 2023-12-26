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

namespace expense_app
{
    public partial class 忘记密码 : Form
    {
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 忘记密码()
        {
            InitializeComponent();
            conn = new SqlConnection(conStr); //创建连接
            try
            {
                conn.Open(); //打开连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
            finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string a, b, c;
            string sql = "select Fullname,Telephone,Email from Users where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 50);
            cmd.Parameters["@UserID"].Value = textBox1.Text;
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                a = rd["Fullname"].ToString();
                b = rd["Telephone"].ToString();
                c = rd["Email"].ToString();
            }
            else
            {
                MessageBox.Show("未注册！");
            }
            conn.Close();
        }

        private void 忘记密码_Load(object sender, EventArgs e)
        {

        }
    }
}
