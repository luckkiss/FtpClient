using BingYing;
using Common;
using FtpDAL;
using FtpModel;
using System;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class 项目配置 : Form
    {
        public 项目配置()
        {
            InitializeComponent();
        }
        public Project model = null;
        private void 项目配置_Load(object sender, EventArgs e)
        {
            if (model != null && model.Id > 0)
            {
                this.Text = "项目编辑";
                tb_Name.Text = model.Name;
                tb_IpAddr.Text = model.IpAddr;
                tb_UserName.Text = model.UserName;
                tb_Password.Text = model.Password;
                tb_WebDir.Text = model.WebDir;
                tb_LocalDir.Text = model.LocalDir;
                tb_DomainName.Text = model.DomainName;
                numericUpDown_Pxh.Value = model.Pxh;
            }
            else
            {
                model = new Project();
                this.Text = "项目新增";
                numericUpDown_Pxh.Value = 10;
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (tb_Name.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Name不能为空");
                return;
            }
            if (tb_IpAddr.Text.IsNullOrEmpty())
            {
                MessageBox.Show("IpAddr不能为空");
                return;
            }
            if (tb_UserName.Text.IsNullOrEmpty())
            {
                MessageBox.Show("UserName不能为空");
                return;
            }
            if (tb_Password.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Password不能为空");
                return;
            }
            SetModel(model);
            if (model.Id == 0)
            {
                PubDal.projectDal.Add(model);
            }
            else
            {
                PubDal.projectDal.Update(model);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetModel(Project model)
        {
            model.Name = tb_Name.Text.Trim();
            model.IpAddr = tb_IpAddr.Text.Trim();
            model.UserName = tb_UserName.Text.Trim();
            model.Password = tb_Password.Text.Trim(); 
            model.WebDir = tb_WebDir.Text.Trim().IsNullOrEmpty()?"/": tb_WebDir.Text.Trim();           
            model.LocalDir = tb_LocalDir.Text.Trim();
            model.DomainName = tb_DomainName.Text.Trim();
            model.Pxh = (int)numericUpDown_Pxh.Value;
        }
    }
}
