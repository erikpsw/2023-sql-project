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
    public partial class 项目管理 : Form
    {
        String conStr = @"Server=.\SQLEXPRESS;
            Database=account;integrated security=true";
        SqlConnection conn;
        List<string> ID_list = new List<string>();
        public 项目管理()
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

        private void 项目管理_Load(object sender, EventArgs e)
        {
            String sql1 = "select projectID,projectName from Projects";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            
            while (rd.Read())
            {
                ID_list.Add(rd[0].ToString());
                comboBox1.Items.Add(rd[1]);
            }
            rd.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }   
    }
}
