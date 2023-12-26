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
using expense_app;

namespace expense_app
{
    public partial class 项目管理 : Form
    {
        String userID;
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        List<string> ID_list = new List<string>();
        public 项目管理(String UserID)
        {
            userID = UserID;
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

        private void 项目管理_Load(object sender, EventArgs e)
        {
            conn.Open();
            String sql1 = "select projectID,projectName from Projects";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                ID_list.Add(rd[0].ToString());
                comboBox1.Items.Add(rd[1]);
            }
            rd.Close();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            int index = comboBox1.SelectedIndex;
            String sql1 = "EXEC get_project " + ID_list[index];
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            textBox1.Text = rd[1].ToString();
            textBox2.Text = rd[0].ToString();
            rd.Close();

            sql1 = "EXEC get_Project_expense " + ID_list[index]; ;
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            dataGridView1.DataSource = table;
            rd.Close();

            string sql2 = "select ExpenseID from Expenses where ProjectID=@ProjectID";
            SqlCommand cmd1 = new SqlCommand(sql2, conn);
            cmd1.Parameters.Add("@ProjectID", SqlDbType.Int);
            cmd1.Parameters["@ProjectID"].Value = ID_list[index];
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            SqlDataReader rdr = cmd1.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr[0]);
                comboBox3.Items.Add(rdr[0]);
            }
            rdr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "EXEC UpdateExpenseStatus @ExpenseID,@ApproverID,@NewStatus";
            SqlCommand cmd = new SqlCommand(sql, conn);
            DateTime currentTime = DateTime.Now;
            cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
            cmd.Parameters.Add("@NewStatus", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ApproverID", SqlDbType.VarChar, 50);
            cmd.Parameters["@ExpenseID"].Value = comboBox2.Text;
            cmd.Parameters["@NewStatus"].Value = "Approved";
            cmd.Parameters["@ApproverID"].Value = userID;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("通过审批");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = @"EXEC UpdateExpenseStatus @ExpenseID,@NewStatus,@ApproverID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            DateTime currentTime = DateTime.Now;
            cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
            cmd.Parameters.Add("@NewStatus", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ApproverID", SqlDbType.VarChar, 50);
            cmd.Parameters["@ExpenseID"].Value = comboBox2.Text;
            cmd.Parameters["@NewStatus"].Value = "Disapproved";
            cmd.Parameters["@ApproverID"].Value = userID;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("审批不通过");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        
        {
            conn.Open();
            int index = comboBox1.SelectedIndex;
            String sql1 = "EXEC get_project " + ID_list[index];
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            textBox1.Text = rd[1].ToString();
            textBox2.Text = rd[0].ToString();
            rd.Close();
            sql1 = "EXEC get_Project_expense " + ID_list[index]; ;
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            // 输出表的列名
            dataGridView1.DataSource = table;
            rd.Close();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = @"Delete from Expenses where ExpenseID=@ExpenseID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
            cmd.Parameters["@ExpenseID"].Value = comboBox2.Text;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "失败");
            }
            finally
            {
                conn.Close();
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("请选择报销ID");
            }
            else {
                String sql = "select image from Expenses where ExpenseID=" + comboBox2.Text;
                Debug.WriteLine(sql);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                byte[] imagebyte;
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    imagebyte = (byte[])result;
                    Form imagef = new 附件查看(imagebyte);
                    imagef.ShowDialog();
                }
                else
                {
                    MessageBox.Show("未上传附件");
                }
               
                conn.Close();
            }
       
        }
    }
}
