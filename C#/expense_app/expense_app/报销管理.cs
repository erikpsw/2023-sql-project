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
    public partial class 报销管理 : Form
    {
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 报销管理()
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
        }

        private void 管理_Load(object sender, EventArgs e)
        {
            string sql1 = "select * from view_all_expense";
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            dataGridView1.DataSource = table;
        }
    }
}
