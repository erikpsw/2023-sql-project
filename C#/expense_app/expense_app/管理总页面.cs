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
    public partial class 管理总页面 : Form
    {
        String name, userID;
        String conStr = @"Server=.\SQLEXPRESS;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 管理总页面(String name1, String UserID)
        {
            name = name1;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            string sql1 = "EXEC get_expense " + userID;
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            label1.Text = "欢迎您  "+name;
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            foreach (DataColumn column in table.Columns)
            {
                Debug.Write(column.ColumnName + "\t");
            }
            Debug.WriteLine("");

            // 输出表的行数据
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Debug.Write(item.ToString() + "\t");
                }
                Debug.WriteLine("");
            }
            dataGridView1.DataSource = table;
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f3 = new 报销管理();
            f3.ShowDialog();
        }

        private void 项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            Form f3 = new 项目管理(userID);
            f3.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
