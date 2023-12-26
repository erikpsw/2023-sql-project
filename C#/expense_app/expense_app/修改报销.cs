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
using System.IO;

namespace expense_app
{
    public partial class 修改报销 : Form
    {
        String userID;
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        报销总页面 f;
        bool add_image = false;
        List<int> Project_ID_list = new List<int>();
        List<int> Category_ID_list = new List<int>();
        List<string> Project_list = new List<string>();
        List<string> Category_list = new List<string>();
        Byte[] imageByte=null;
        int expense_id, project_id, category_id;
        String amount, note;
        int Category_index, Project_index;
        public 修改报销(String UserID,int expense_id1,int project_id1,int category_id1,String amount1,String note1, 报销总页面 form1)
        {
            f = form1;
            expense_id = expense_id1;
            project_id = project_id1;
            category_id = category_id1;
            amount = amount1;
            note = note1;
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

        private void 修改报销_Load(object sender, EventArgs e)
        {
            String sql1 = "select projectID,projectName from Projects";
            SqlCommand cmd = new SqlCommand(sql1, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Project_ID_list.Add((int)rd[0]);
                comboBox1.Items.Add(rd[1]);
                Project_list.Add(rd[1].ToString());
            }
            rd.Close();
            sql1 = "select CategoryID,CategoryName from ExpenseCategories";
            cmd = new SqlCommand(sql1, conn);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Category_ID_list.Add((int)rd[0]);
                comboBox2.Items.Add(rd[1]);
                Category_list.Add(rd[1].ToString());
            }
            rd.Close();
            Category_index = Category_ID_list.FindIndex(item => item == category_id);
            Project_index = Project_ID_list.FindIndex(item => item == project_id);
            comboBox1.Text = Project_list[Project_index];
            comboBox2.Text = Category_list[Category_index];
            textBox1.Text = amount;
            textBox2.Text = note;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project_index = comboBox1.SelectedIndex;
            Category_index = comboBox2.SelectedIndex;
            DateTime currentTime = DateTime.Now;
            SqlCommand cmd;
            if (add_image)
            {
                String sql1 = "UPDATE Expenses SET CategoryID = @CategoryID,Amount = @Amount,SubmitTime = @SubmitTime,Note = @Note,ProjectID = @ProjectID,Image=@Image where ExpenseID=@ExpenseID";
                cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@Image", SqlDbType.VarBinary, 1000000);
                cmd.Parameters["@Image"].Value = imageByte;
            }
            else {
                String sql1 = "UPDATE Expenses SET CategoryID = @CategoryID,Amount = @Amount,SubmitTime = @SubmitTime,Note = @Note,ProjectID = @ProjectID where ExpenseID=@ExpenseID";
                cmd = new SqlCommand(sql1, conn);
            }
            cmd.Parameters.Add("@ExpenseID", SqlDbType.Int);
            cmd.Parameters.Add("@ProjectID",SqlDbType.Int);
            cmd.Parameters.Add("@UserID",SqlDbType.VarChar,50);
            cmd.Parameters.Add("@CategoryID",SqlDbType.Int);
            cmd.Parameters.Add("@Amount",SqlDbType.Decimal);
            cmd.Parameters.Add("@SubmitTime",SqlDbType.DateTime);
            cmd.Parameters.Add("@Note",SqlDbType.Text);
            cmd.Parameters["@ProjectID"].Value=Project_ID_list[Project_index];
            cmd.Parameters["@UserID"].Value=userID;
            cmd.Parameters["@CategoryID"].Value=Category_ID_list[Category_index];
            cmd.Parameters["@Amount"].Value=textBox1.Text;
            cmd.Parameters["@SubmitTime"].Value=currentTime;
            cmd.Parameters["@Note"].Value=textBox2.Text;
            cmd.Parameters["@ExpenseID"].Value = expense_id;
            //Debug.WriteLine(sql1);
           
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fname = openFileDialog1.FileName;
                FileStream fs = new FileStream(fname,FileMode.Open,FileAccess.Read);
                BinaryReader br=new BinaryReader(fs);
                imageByte=br.ReadBytes((int)fs.Length);
                label4.Text = "√";
                add_image = true;
            }
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }
}
}
