namespace WinFormsApp1
         
{
    using Microsoft.VisualBasic.Devices;
    using Microsoft.VisualBasic.Logging;
    using System.Data.SqlClient;
    using static System.ComponentModel.Design.ObjectSelectorEditor;
    using System.Diagnostics;
     
    public partial class Form1 : Form
    {

        String conStr = @"Server=.\TONGJI;
            Database=account; Integrated Security=true;";
        SqlConnection conn;
        public Form1()
        {

            conn = new SqlConnection(conStr); //��������
            InitializeComponent();
 
            try
            {
                conn.Open(); //������
                MessageBox.Show("���ݿ����Ӳ��Գɹ���", "�ɹ�");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ʧ��");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String userid = textBox1.Text ;
            String password = textBox2.Text;
            String sql = "EXEC login @UserID=" + userid + ", @Password=" + password;
            Debug.WriteLine(sql);

            SqlCommand cmd = new SqlCommand(sql, conn);
            int res;
            try
            {
                res = (Int32)cmd.ExecuteScalar();
                Debug.WriteLine(res);
                if(res == 1)
                {
                    MessageBox.Show("��¼�ɹ�");
                }
                else
                {
                    MessageBox.Show("��¼ʧ��");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            // ������ֵ
            //Debug.WriteLine("����ֵ: " + returnValue);
        }
    }
}