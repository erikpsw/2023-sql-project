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
using expense_app;
namespace expense_app
{
    public partial class 注册 : Form
    {
        public SqlConnection conn;
        string constr = @"server=.\sqlexpress;database=account;integrated security=true;";
        public 注册()
        {
            InitializeComponent();
        }

        private void 注册_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("AddUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 50).Value = textBox1.Text;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = textBox2.Text;
            cmd.Parameters.Add("@Fullname", SqlDbType.Text).Value = textBox3.Text;
            cmd.Parameters.Add("@Telephone", SqlDbType.NChar,11).Value = textBox4.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = textBox5.Text;
            try
            {
                
                conn.Open();
                cmd.ExecuteNonQuery();
                if (comboBox1.Text=="管理员")
                {
                    string sql1 = "INSERT INTO Admins (AdminID) VALUES (@UserID)";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.Parameters.Add("@UserID", SqlDbType.VarChar, 50).Value = textBox1.Text;
                    cmd1.ExecuteNonQuery();
                }
                MessageBox.Show("注册成功");
                this.Close();
                // 查找已经存在的 "登录" 窗体实例
                登录 loginForm = Application.OpenForms.OfType<登录>().FirstOrDefault();
                loginForm.SetUsername(textBox1.Text);
                loginForm.SetPassword(textBox2.Text);
                loginForm.Activate();
                
            }
            catch (SqlException ex)
            {
                // 获取详细的错误信息
                string errorMessage = "注册失败。错误类型：" + ex.Message;
                MessageBox.Show(errorMessage, "失败");
            }
            finally
            { conn.Close(); }
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
