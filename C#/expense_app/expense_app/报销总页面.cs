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
    public partial class 报销总页面 : Form
    {

        String name, userID;
        String conStr = @"Server=.\SQLEXPRESS;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 报销总页面(String Name,String UserID)
        {
            name = Name;
            userID = UserID;
            conn = new SqlConnection(conStr); //创建连接
            InitializeComponent();
            try
            {
                conn.Open(); //打开连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "失败");
            }
        }

        private void 报销总页面_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void 报销总页面_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 执行需要在窗体关闭后完成的操作
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f3 = new 新增报销(userID,this);
            f3.ShowDialog();
        }

        //更新
        public void refresh()
        {
            string sql1 = "EXEC get_expense " + userID;
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            label1.Text = "欢迎  " + name;
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            dataGridView1.DataSource = table;
        }
    }
}
