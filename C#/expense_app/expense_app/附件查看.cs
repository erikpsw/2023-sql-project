using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace expense_app
{
    public partial class 附件查看 : Form
    {
        byte[] imagebyte;
        public 附件查看(byte[] imagebyte1)
        {
            InitializeComponent();
            imagebyte = imagebyte1;
        }

        private void 附件查看_Load(object sender, EventArgs e)
        {

            if (imagebyte.Length > 0)
            {
                MemoryStream ms = new MemoryStream(imagebyte);
                this.BackgroundImage = Image.FromStream(ms);
            }
        }
    }
}
