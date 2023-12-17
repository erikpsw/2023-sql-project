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
            Database=account; Integrated Security=true;";
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
            try
            {
                res = (Int32)cmd.ExecuteScalar();
                Debug.WriteLine(res);
                if(res == 1)
                {
                    MessageBox.Show("登录成功");
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
    }
}