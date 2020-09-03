using BingYing;
using FtpModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class Ftp目录 : Form
    {
        public Ftp目录()
        {
            InitializeComponent();
        }
        public string dirstr = "";
        public Project model = null;
        private MyFtpHelper ftpHelper = null;
        private List<RetunFileInfo> ListInfoList = null;

        #region 匿名委托  
        /// <summary>
        /// 非创建线程中更新ListView
        /// </summary>        
        public void ThreadUpdateListView()
        {
            try
            {
                this.BeginInvoke(new EventHandler(delegate { this.ShowList(); }));
            }
            catch (Exception)
            {

               
            }
          
        }

        #endregion     

        private void Ftp目录_Load(object sender, EventArgs e)
        {
            ftpHelper = new MyFtpHelper(model);
            if (!model.WebDir.IsNullOrEmpty() && model.WebDir != "/")
                ftpHelper.RelatePath = ftpHelper.RelatePath + "/" + model.Name;
            this.ListDirectory();
            this.Text = model.Name;
            tb_WebDir.Text = ftpHelper.RelatePath;
        }


        private List<RetunFileInfo> GetList()
        {
            List<RetunFileInfo> ls = new List<RetunFileInfo>();
            bool isOk = false;
            var arrAccept = ftpHelper.ListDirectory(out isOk);//调用Ftp目录显示功能
            for (int i = 0; i < 5; i++)
            {
                if (!isOk)
                    arrAccept = ftpHelper.ListDirectory(out isOk);
                else
                    break;
            }
            if (isOk)
            {
                foreach (string accept in arrAccept)
                {
                    var li = new RetunFileInfo(accept.Substring(39), accept.Substring(0, 16));
                    if (accept.IndexOf("<DIR>") != -1)
                    {
                        li.Type = "目录";
                        li.Size = "0字节";
                    }
                    else
                    {
                        li.Type = "文件";
                        li.Size = ftpHelper.CountSize(accept.Substring(17, (39 - 17)));
                    }
                    ls.Add(li);
                }
            }
            return ls;
        }


        private void ShowList()
        {
            this.listView1.Items.Clear();
            ListInfoList = ListInfoList.OrderBy(u => u.Type).ToList();
            foreach (var item in ListInfoList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Name;
                lvi.SubItems.Add(item.Size);
                lvi.SubItems.Add(item.CreateTime);
                lvi.SubItems.Add(item.Type);
                this.listView1.Items.Add(lvi);
            }
            lblMsg.Text = "列出目录成功";
            tb_WebDir.Text = ftpHelper.RelatePath;
            if (ftpHelper.RelatePath.IsNullOrEmpty() || ftpHelper.RelatePath == "/" || ftpHelper.RelatePath == @"\")
                btn_上一级.Enabled = false;
            else
                btn_上一级.Enabled = true;
        }

        /// <summary>
        /// 列出目录
        /// </summary>
        private void ListDirectory()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                ListInfoList = GetList();
                ThreadUpdateListView();
            }));
            thread.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!tb_WebDir.Text.IsNullOrEmpty())
            {
                ftpHelper.SetPrePath();
                this.ListDirectory();
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listView1.GetItemAt(e.X, e.Y);
                if (item == null) return;
                item.Selected = true;
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            DownLoad(item.Text);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var item = listView1.SelectedItems[0];
            if (item == null) return;
            Delete(item.Text, item.SubItems[3].Text);
        }

        /// <summary>
        /// 删除文件夹或者文件
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        private void Delete(string Name, string Type)
        {

            DialogResult dr = MessageBox.Show("确定删除选定的对象？" + Name, "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK)
            {
                var path = "ftp://" + ftpHelper.IpAddr + ftpHelper.RelatePath + "/" + Name;
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    if (Type == "目录")
                    {
                        if (ftpHelper.DeleteDirectory(path))
                        {
                            ListInfoList = GetList();
                            ThreadUpdateListView();
                        }
                    }
                    else
                    {
                        if (ftpHelper.DeleteFile(path))
                        {
                            ListInfoList = GetList();
                            ThreadUpdateListView();
                        }
                    }
                }));
                thread.Start();
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="name"></param>
        private void DownLoad(string name)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = name,
                Filter = "All Files|(*.*)",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "另存为"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //下载文件
                ftpHelper.RelatePath = ftpHelper.RelatePath + "/" + Path.GetFileName(sfd.FileName);
                bool isOk = false;
                ftpHelper.DownLoad(sfd.FileName, out isOk);
                if (isOk)
                {
                    lblMsg.Text = "下载成功";
                }
                else
                {
                    lblMsg.Text = "下载失败";
                }
                ftpHelper.SetPrePath();
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        private void 创建文件夹()
        {
            var fm = new 新建文件夹();
            fm.ShowDialog(this);
            if (fm.DialogResult == DialogResult.OK)
            {
                if (!dirstr.IsNullOrEmpty())
                {
                    var uri = "ftp://" + ftpHelper.IpAddr + ftpHelper.RelatePath + "/" + dirstr;
                    if (ftpHelper.MakeDir(uri))
                        this.ListDirectory();
                }
            }
        }

        private void 创建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            创建文件夹();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var item = listView1.SelectedItems[0];
            var Type = item.SubItems[3].Text;
            if (Type == "目录")
            {
                ftpHelper.RelatePath = ftpHelper.RelatePath + "/" + item.Text;
                this.ListDirectory();
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            var str = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var item in str)
            {
                var isOk = false;
                ftpHelper.RelatePath = ftpHelper.RelatePath + "/" + Path.GetFileName(item);
                ftpHelper.UpLoad(item, out isOk);
                ftpHelper.SetPrePath();
                if (isOk)
                {
                    lblMsg.Text = "上传成功";
                    this.ListDirectory();
                }
                else
                {
                    lblMsg.Text = "上传失败";
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ListDirectory();
        }
    }
}