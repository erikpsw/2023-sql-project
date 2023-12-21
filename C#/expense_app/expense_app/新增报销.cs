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
    public partial class 新增报销 : Form
    {
        String userID;
        String conStr = @"Server=.\SQLEXPRESS;
            Database=account;integrated security=true";
        SqlConnection conn;
        报销总页面 f;
        List<string> Project_ID_list = new List<string>();
        List<string> Category_ID_list = new List<string>();
        public 新增报销(String UserID, 报销总页面 form1)
        {
            f = form1;
            userID=UserID;
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

        private void 新增报销_Load(object sender, EventArgs e)
        {
            String sql1 = "select projectID,projectName from Projects";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Project_ID_list.Add(rd[0].ToString());
                comboBox1.Items.Add(rd[1]);
            }
            rd.Close();
            sql1 = "select CategoryID,CategoryName from ExpenseCategories";
            cmd = new SqlCommand(sql1, conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category_ID_list.Add(rd[0].ToString());
                comboBox2.Items.Add(rd[1]);
            }
            rd.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Project_index = comboBox1.SelectedIndex;
            int Category_index = comboBox2.SelectedIndex;
            DateTime currentTime = DateTime.Now;
            String sql1 = "Exec SubmitExpense "+Project_ID_list[Project_index]+",'"+userID+"',"+Category_ID_list[Category_index]+","+textBox1.Text+",'"+currentTime .ToString()+"','"+textBox2.Text+"'";
            Debug.WriteLine(sql1);
            SqlCommand cmd = new SqlCommand(sql1, conn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("提交成功");
                f.refresh();
                this.Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.ToString());
            }

        }


}
}
