namespace WinFormsApp1
         
{
    using Microsoft.VisualBasic.Devices;
    using Microsoft.VisualBasic.Logging;
    using System.Data.SqlClient;
    using static System.ComponentModel.Design.ObjectSelectorEditor;

    public partial class Form1 : Form
    {

        String conStr = @"Server=.\TONGJI;
            Database=account; Integrated Security=true;";

        public Form1()
        {
            

            InitializeComponent();
            SqlConnection conn = new SqlConnection(conStr); //创建连接
            try
            {
                conn.Open(); //打开连接
                MessageBox.Show("数据库连接测试成功！", "成功");
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr); //创建连接
            String sql = textBox1.Text ; 
            Console.Write(sql);
            SqlCommand cmd = new SqlCommand(sql, conn);//创建命令对象
        }
    }
}