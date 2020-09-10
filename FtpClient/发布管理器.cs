using Common;
using FtpDAL;
using FtpModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class 发布管理器 : Form
    {
        public 发布管理器()
        {
            InitializeComponent();
        }
        private MyFtpHelper ftpHelper = null;
        private List<Project> projectList = null;
        private IniFile ini;
        #region 匿名委托 
        public void ThreadUpdateListView(string msg)
        {
            this.BeginInvoke(new EventHandler(delegate { this.listView1.Items.Insert(0, new ListViewItem(msg.Replace("//","/"))); }));
        }

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            Chaxun();
            var iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fbq.ini");
            ini = new IniFile(iniPath);
            try
            {
                cb_bin.Checked = ReadInivalue("cb_bin");
                cb_root.Checked = ReadInivalue("cb_root"); 
                cb_scripts.Checked = ReadInivalue("cb_scripts"); 
                cb_views.Checked = ReadInivalue("cb_views"); 
                var value = Convert.ToInt64(ini.ReadInivalue("cb_项目"));
                cb_项目.SelectedItem = projectList.FirstOrDefault(u => u.Id == value);
            }
            catch (Exception)
            {
            }
        }


        private bool ReadInivalue(string Key)
        {
            return ini.ReadInivalue(Key) == "1"; 
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//右键点击显示右键菜单
            {
                if (e.RowIndex == -1)//选中表头 只显示新建
                {
                    for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                        if (!contextMenuStrip1.Items[i].Text.Contains("新建"))
                            contextMenuStrip1.Items[i].Visible = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                        contextMenuStrip1.Items[i].Visible = true;
                }
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建项目();
        }


        private void 新建项目()
        {
            var fm = new 项目配置();
            fm.ShowDialog();
            if (fm.DialogResult == DialogResult.OK)
                Chaxun();
        }

        private void 编辑项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProject();
        }

        private void Chaxun()
        {
            projectList = PubDal.projectDal.GetList().OrderBy(u => u.Pxh).ToList();
            this.dataGridView1.DataSource = projectList;
            dataGridView1.ClearSelection();
            projectList.ForEach(u => cb_项目.Items.Add(u));
            cb_项目.ValueMember = "Id";
            cb_项目.DisplayMember = "Name";
        }


        private long getValueId()
        {
            return Convert.ToInt64(getValue("Id"));
        }

        public string getValue(string key)
        {
            return dataGridView1.SelectedRows[0].Cells[key].Value == null ? string.Empty : dataGridView1.SelectedRows[0].Cells[key].Value.ToString();
        }

        private void 查看FtpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFtp();
        }


        private void ShowFtp()
        {
            var fm = new Ftp目录();
            fm.model = GetFirstOrDefault();
            fm.Show();
        }

        private Project GetFirstOrDefault()
        {
            return projectList.FirstOrDefault(u => u.Id == getValueId());
        }



        /// <summary>
        /// 获取本地文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<string> GetLocalFiles(Project model)
        {
            List<string> files = new List<string>();
            if (cb_root.Checked)
            {
                var rootfiles = Directory.GetFiles(model.LocalDir, "*.*"); //根目录文件
                foreach (var item in rootfiles)
                {
                    if (item.EndsWith(".csproj") || item.EndsWith(".user")) continue;
                    else files.Add(item);
                }
            }
            if (cb_scripts.Checked)
            {
                var scriptsPath = Path.Combine(model.LocalDir, "Scripts");
                if (Directory.Exists(scriptsPath))
                    files.AddRange(Directory.GetFiles(scriptsPath, "*.*", SearchOption.AllDirectories));//Script目录文件
            }
            if (cb_views.Checked)
            {
                var viewsPath = Path.Combine(model.LocalDir, "Views");
                if (Directory.Exists(viewsPath))
                    files.AddRange(Directory.GetFiles(viewsPath, "*.*", SearchOption.AllDirectories));//Views目录文件
            }
            if (cb_bin.Checked)
            {
                var binPath = Path.Combine(model.LocalDir, "bin");
                if (Directory.Exists(binPath))
                    files.AddRange(Directory.GetFiles(binPath, "*.dll"));//bin目录文件
            }
            return files;
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="type"></param>
        private void Publish(PublishTypeEnum type, Project model = null)
        {
            if (model == null) model = GetFirstOrDefault();
            ftpHelper = new MyFtpHelper(model);
            ftpHelper.RelatePath = string.Format("{0}/{1}", ftpHelper.RelatePath, model.Name);
            var localFiles = GetLocalFiles(model);
            Thread Thread = new Thread(new ThreadStart(delegate
            {
                ThreadUpdateListView(DateTime.Now + ":刷新本地目录完成");
                switch (type)
                {
                    case PublishTypeEnum.完整发布:
                        完整发布(localFiles, model);
                        break; 
                    case PublishTypeEnum.增量发布:
                        增量发布(localFiles, model);
                        break;
                    case PublishTypeEnum.完整发布虚拟:
                        完整发布虚拟(localFiles, model);
                        break;
                    case PublishTypeEnum.增量发布虚拟:
                        增量发布虚拟(localFiles, model);
                        break;
                }
                ThreadUpdateListView(DateTime.Now + ":发布完成");
            }));
            Thread.Start();
        }

        private void 增量发布虚拟(List<string> files, Project model)
        {
            ThreadUpdateListView(model.Name + "增量发布虚拟");
            foreach (var item in files)
            {
                var filehash = PubDal.filehashDal.GetModel(item, model.Id);
                var newHash = HashHelper.GetHash(item);
                if (filehash.Id == 0)
                {
                    PubDal.filehashDal.Add(new FileHash(item, newHash, model.Id));
                    ThreadUpdateListView("虚拟同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                }
                else
                {
                    if (filehash.Hash != newHash)
                    {
                        filehash.Hash = newHash;
                        PubDal.filehashDal.Update(filehash);
                        ThreadUpdateListView("虚拟同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));

                    }
                }
            }
        }

        /// <summary>
        /// 完整发布虚拟(更新本地文件hash值)
        /// </summary>
        /// <param name="files"></param>
        /// <param name="model"></param>
        private void 完整发布虚拟(List<string> files, Project model)
        {
            ThreadUpdateListView(model.Name + "完整发布虚拟");
            foreach (var item in files)
            {
                var filehash = PubDal.filehashDal.GetModel(item, model.Id); ;
                var newHash = HashHelper.GetHash(item);
                if (filehash.Id == 0)//不存在则新增
                {
                    PubDal.filehashDal.Add(new FileHash(item, newHash, model.Id));
                    ThreadUpdateListView("虚拟同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                }
                else
                {
                    //存在并且Hash值发生了改变
                    if (filehash.Hash != newHash)
                    {
                        filehash.Hash = newHash;//Hash不同才修改
                        PubDal.filehashDal.Update(filehash);
                        ThreadUpdateListView("虚拟同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                    }
                }

            }
        }

        /// <summary>
        /// 完整发布
        /// </summary>
        /// <param name="files"></param>
        /// <param name="model"></param>
        private void 完整发布(List<string> files, Project model)
        {
            ThreadUpdateListView(model.Name + "完整发布");
            foreach (var item in files)
            {
                bool isOk;
                ftpHelper.RelatePath = model.WebDir + item.Replace(model.LocalDir, "");
                ftpHelper.UpLoad(item, out isOk);//完整发布先上传再做其他的
                if (isOk)
                {
                    var filehash = PubDal.filehashDal.GetModel(item, model.Id);
                    var newHash = HashHelper.GetHash(item);
                    if (filehash.Id == 0)//新增                    
                        PubDal.filehashDal.Add(new FileHash(item, newHash, model.Id));
                    else
                    {
                        if (filehash.Hash != newHash)
                        {
                            filehash.Hash = newHash;//Hash不同才修改
                            PubDal.filehashDal.Update(filehash);
                        }
                    }
                    ThreadUpdateListView("同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                }
                else
                    ThreadUpdateListView("同步失败--------------" + item);
            }
        }
        /// <summary>
        /// 增量发布
        /// </summary>
        /// <param name="files"></param>
        /// <param name="model"></param>
        private void 增量发布(List<string> files, Project model)
        {
            ThreadUpdateListView(model.Name + "增量发布");
            foreach (var item in files)
            {
                bool isOk;
                var filehash = PubDal.filehashDal.GetModel(item, model.Id);
                var newHash = HashHelper.GetHash(item);
                ftpHelper.RelatePath = model.WebDir + item.Replace(model.LocalDir, "");

                if (filehash.Id == 0)
                {
                    ftpHelper.UpLoad(item, out isOk);//没有记录证明上传过的需要上传
                    if (isOk)
                    {
                        PubDal.filehashDal.Add(new FileHash(item, newHash, model.Id));
                        ThreadUpdateListView("同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                    }
                    else
                        ThreadUpdateListView("同步失败--------------" + item);
                }
                else
                {
                    if (filehash.Hash != newHash)
                    {
                        ftpHelper.UpLoad(item, out isOk);//Hash值发生了改变的文件需要上传
                        if (isOk)
                        {
                            filehash.Hash = newHash;
                            PubDal.filehashDal.Update(filehash);
                            ThreadUpdateListView("同步完成：" + model.WebDir + item.Replace(model.LocalDir, "").Replace(@"\", "/"));
                        }
                        else
                            ThreadUpdateListView("同步失败--------------" + item);
                    }
                }
            }
        }
        /// <summary>
        /// 编辑项目
        /// </summary>
        private void EditProject()
        {
            var fm = new 项目配置();
            fm.model = PubDal.projectDal.GetModel(getValueId());
            fm.ShowDialog();
            if (fm.DialogResult == DialogResult.OK)
                Chaxun();
        }

        private void 增量发布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publish(PublishTypeEnum.增量发布);
        }

        private void 删除项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var model = GetFirstOrDefault();
            var dr = MessageBox.Show("确定删除选定的对象？" + model.Name, "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                PubDal.projectDal.Delete(model);
                Chaxun();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            ShowFtp();
        }

        private void 完整发布虚拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publish(PublishTypeEnum.完整发布虚拟);
        }

        private void 增量发布虚拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publish(PublishTypeEnum.增量发布虚拟);
        }

        private void 新增项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建项目();
        }

        private void 清空更新日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
        }

        private void 获取文件配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 显示排序号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var flag = this.dataGridView1.Columns["排序号"].Visible;
            this.dataGridView1.Columns["排序号"].Visible = !flag;
            if (flag) 显示排序号ToolStripMenuItem.Text = "显示排序号";
            else 显示排序号ToolStripMenuItem.Text = "隐藏排序号";
        }
        private void 资源管理器中打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", getValue("LocalDir"));
        }

        private void 完整发布binToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 完整发布ViewsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_增量发布_Click(object sender, EventArgs e)
        {
            Publish(PublishTypeEnum.增量发布, cb_项目.SelectedItem as Project);
        }

        private void cb_项目_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.WriteInivalue("cb_项目", ((Project)cb_项目.SelectedItem).Id);
        }

        private void btn_完整发布_Click(object sender, EventArgs e)
        {          
            ShowDialogAll(cb_项目.SelectedItem as Project);
        }

        private void 完整发布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialogAll(GetFirstOrDefault());            
        }
        /// <summary>
        /// 完整发布确认对话框
        /// </summary>
        /// <param name="model"></param>
        private void ShowDialogAll(Project model)
        {
            var dr = MessageBox.Show("完整发布耗时较多,确定完整发布？" + model.Name, "完整发布", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK) Publish(PublishTypeEnum.完整发布, model);
        }

        private void cb_root_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteInivalue("cb_root", cb_root.Checked);
        }

        private void cb_scripts_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteInivalue("cb_scripts", cb_scripts.Checked);
        }

        private void cb_views_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteInivalue("cb_views", cb_views.Checked);
        }

        private void cb_bin_CheckedChanged(object sender, EventArgs e)
        {
            ini.WriteInivalue("cb_bin", cb_bin.Checked);
        }
    }
}