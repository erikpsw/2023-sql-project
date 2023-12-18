using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Diagnostics;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        String name,userID;
        String conStr = @"Server=.\TONGJI;
            Database=account;integrated security=true";
        SqlConnection conn;
        public Form2(String name1,String UserID)
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
    }
}
