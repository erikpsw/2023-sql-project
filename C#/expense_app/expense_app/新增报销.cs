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
    public partial class 新增报销 : Form
    {
        bool add_image = false;
        String userID;
        String conStr = @"Server=.\sqlexpress;
            Database=account;integrated security=true";
        SqlConnection conn;
        报销总页面 f;
        List<string> Project_ID_list = new List<string>();
        List<string> Category_ID_list = new List<string>();
        Byte[] imageByte=null;
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
            
            SqlCommand cmd;
            if (add_image)
            {
                String sql1 = "Exec SubmitExpense @ProjectID,@UserID,@CategoryID,@Amount,@SubmitTime,@Note,@Image";
                cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@Image", SqlDbType.VarBinary, 1000000).Value = imageByte;
            }
            else {
                String sql1 = "Exec SubmitExpense @ProjectID,@UserID,@CategoryID,@Amount,@SubmitTime,@Note,@Image";
                cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.Add("@Image", SqlDbType.VarBinary, 1000000).Value = DBNull.Value;
            }
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
