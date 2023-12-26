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
        BindingSource bs;
        SqlDataAdapter adapter;
        int expense_id,project_id,category_id;
        String name, userID,amount, note;
        String conStr = @"Server=.\sqlexpress;
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
            string sql1 = "EXEC get_expense " + userID;
            adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            bs = new BindingSource();
            bs.DataSource = dt;
            label1.Text = "欢迎  " + name;
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            conn.Close();
        }

        private void 报销总页面_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 执行需要在窗体关闭后完成的操作

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f3 = new 新增报销(userID, this);
            f3.ShowDialog();
        }

        //更新
        public void refresh()
        {
            string sql1 = "EXEC get_expense " + userID;
            adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                DataRowView selectedRow = (DataRowView)bs.Current;
                object columnValue = selectedRow["ID"];
                Debug.WriteLine(columnValue);
                conn.Open();
                String sql1 = "select * from Expenses where ExpenseID="+columnValue;
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                expense_id= (int)rd[0];
                project_id = (int)rd[1];
                category_id = (int)rd[3];
                amount = rd[4].ToString();
                note = rd[6].ToString();
                rd.Close();
                conn.Close();
                Form f = new 修改报销(userID, expense_id, project_id, category_id, amount, note, this);
                f.ShowDialog();
  
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                conn.Open();
                DataRowView selectedRow = (DataRowView)bs.Current;
                object columnValue = selectedRow["ID"];
                String sql = "select image from Expenses where ExpenseID=" + columnValue;
                Debug.WriteLine(sql);
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

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                conn.Open();
                DataRowView selectedRow = (DataRowView)bs.Current;
                object columnValue = selectedRow["ID"];
                String sql1 = "delete from Expenses where ExpenseID=" + columnValue;
                SqlCommand cmd = new SqlCommand(sql1, conn);
                Debug.WriteLine(sql1);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("删除成功");
                    refresh();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }
    }
    
}
