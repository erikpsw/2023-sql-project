namespace WinFormsApp1
         
{
    using Microsoft.VisualBasic.Devices;
    using Microsoft.VisualBasic.Logging;
    using System.Data.SqlClient;
    using static System.ComponentModel.Design.ObjectSelectorEditor;

    public partial class Form1 : Form
    {

        String conStr = @"Server=.\TONGJI;
            Database=account; Integrated Security=true;";

        public Form1()
        {
            

            InitializeComponent();
            SqlConnection conn = new SqlConnection(conStr); //��������
            try
            {
                conn.Open(); //������
                MessageBox.Show("���ݿ����Ӳ��Գɹ���", "�ɹ�");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ʧ��");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr); //��������
            String sql = textBox1.Text ; 
            Console.Write(sql);
            SqlCommand cmd = new SqlCommand(sql, conn);//�����������
        }
    }
}