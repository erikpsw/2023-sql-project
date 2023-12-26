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
    public partial class 项目数据分析 : Form
    {
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        public 项目数据分析()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            int index = comboBox1.SelectedIndex;
            String sql1 = "EXEC get_project @ProjectID";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmd.Parameters["@ProjectID"].Value = comboBox1.Text;
            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            textBox1.Text = rd[0].ToString();
            textBox3.Text = rd[1].ToString();
            rd.Close();

            string sql2 = "SELECT SUM(Amount) FROM Expenses WHERE ProjectID = @ProjectID";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmd2.Parameters["@ProjectID"].Value = comboBox1.Text;
            SqlDataReader rdr = cmd2.ExecuteReader();

            rdr.Read();
            textBox2.Text = rdr[0].ToString();
            rdr.Close();

            String sql = "select ExpenseCategories.CategoryID,CategoryName,sum(Expenses.Amount) as Sum_Expense from Expenses, ExpenseCategories where ProjectID = '" + comboBox1.Text + "' and ExpenseCategories.CategoryID = Expenses.CategoryID group by all ExpenseCategories.CategoryID,CategoryName order by CategoryID";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            dataGridView1.DataSource = table;
            rd.Close();
            rdr.Close();
            conn.Close();
        }

        private void 项目数据分析_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql = "select projectID from Projects";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                comboBox1.Items.Add(rd[0]);
            }
            rd.Close();
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
        }
    }
}
