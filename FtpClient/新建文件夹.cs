using System;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class 新建文件夹 : Form
    {
        public 新建文件夹()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Ftp目录 frm = (Ftp目录)this.Owner;
            frm.dirstr = this.tb_Name.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
