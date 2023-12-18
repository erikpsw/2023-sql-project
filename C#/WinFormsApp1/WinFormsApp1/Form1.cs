namespace WinFormsApp1
         
{
    using Microsoft.VisualBasic.Devices;
    using Microsoft.VisualBasic.Logging;
    using System.Data.SqlClient;
    using static System.ComponentModel.Design.ObjectSelectorEditor;
    using System.Diagnostics;
     
    public partial class Form1 : Form
    {

        String conStr = @"Server=.\TONGJI;
            Database=account;integrated security=true";
        SqlConnection conn;
        public Form1()
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
                if(res == 1)
                {
                    MessageBox.Show("登录成功");

                    string name1 = data[1]?.ToString();
                    if (name1 != null)
                    {
                        Form2 f2 = new Form2(name1, userid);
                        // 其他逻辑
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


            // 处理返回值
            //Debug.WriteLine("返回值: " + returnValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "A123456789";
            textBox2.Text = "P123456789";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}