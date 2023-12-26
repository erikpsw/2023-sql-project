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
    public partial class 费用数据分析 : Form
    {
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 费用数据分析()
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

        private void 费用数据分析_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "select CategoryName from ExpenseCategories";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0]);
            }
            rd.Close();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sql = "select Projects.ProjectID,ProjectName,sum(Expenses.Amount) as Sum_Expense from Expenses, ExpenseCategories,Projects where ExpenseCategories.CategoryName = '" + comboBox1.Text + "' and ExpenseCategories.CategoryID = Expenses.CategoryID and Projects.ProjectID=Expenses.ProjectID group by all Projects.ProjectID order by ProjectID";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            dataGridView1.DataSource = table;
            conn.Close();
        }
    }
}
