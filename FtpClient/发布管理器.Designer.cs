namespace FtpClient
{
    partial class 发布管理器
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(发布管理器));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看FtpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增量发布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增量发布虚拟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完整发布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完整发布binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.完整发布ViewsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资源管理器中打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示排序号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空更新日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new FtpClient.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.排序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DomainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.项目名称,
            this.排序号,
            this.IpAddr,
            this.UserName,
            this.Password,
            this.WebDir,
            this.LocalDir,
            this.DomainName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(227, 716);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看FtpToolStripMenuItem,
            this.增量发布ToolStripMenuItem,
            this.增量发布虚拟ToolStripMenuItem,
            this.完整发布ToolStripMenuItem,
            this.完整发布binToolStripMenuItem,
            this.完整发布ViewsToolStripMenuItem1,
            this.新建项目ToolStripMenuItem,
            this.编辑项目ToolStripMenuItem,
            this.删除项目ToolStripMenuItem,
            this.资源管理器中打开文件夹ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(244, 244);
            // 
            // 查看FtpToolStripMenuItem
            // 
            this.查看FtpToolStripMenuItem.Name = "查看FtpToolStripMenuItem";
            this.查看FtpToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.查看FtpToolStripMenuItem.Text = "查看Ftp";
            this.查看FtpToolStripMenuItem.Click += new System.EventHandler(this.查看FtpToolStripMenuItem_Click);
            // 
            // 增量发布ToolStripMenuItem
            // 
            this.增量发布ToolStripMenuItem.Name = "增量发布ToolStripMenuItem";
            this.增量发布ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.增量发布ToolStripMenuItem.Text = "增量发布";
            this.增量发布ToolStripMenuItem.Click += new System.EventHandler(this.增量发布ToolStripMenuItem_Click);
            // 
            // 增量发布虚拟ToolStripMenuItem
            // 
            this.增量发布虚拟ToolStripMenuItem.Name = "增量发布虚拟ToolStripMenuItem";
            this.增量发布虚拟ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.增量发布虚拟ToolStripMenuItem.Text = "增量发布(虚拟)";
            this.增量发布虚拟ToolStripMenuItem.Click += new System.EventHandler(this.增量发布虚拟ToolStripMenuItem_Click);
            // 
            // 完整发布ToolStripMenuItem
            // 
            this.完整发布ToolStripMenuItem.Name = "完整发布ToolStripMenuItem";
            this.完整发布ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.完整发布ToolStripMenuItem.Text = "完整发布";
            this.完整发布ToolStripMenuItem.Click += new System.EventHandler(this.完整发布ToolStripMenuItem_Click);
            // 
            // 完整发布binToolStripMenuItem
            // 
            this.完整发布binToolStripMenuItem.Name = "完整发布binToolStripMenuItem";
            this.完整发布binToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.完整发布binToolStripMenuItem.Text = "完整发布bin";
            this.完整发布binToolStripMenuItem.Click += new System.EventHandler(this.完整发布binToolStripMenuItem_Click);
            // 
            // 完整发布ViewsToolStripMenuItem1
            // 
            this.完整发布ViewsToolStripMenuItem1.Name = "完整发布ViewsToolStripMenuItem1";
            this.完整发布ViewsToolStripMenuItem1.Size = new System.Drawing.Size(243, 24);
            this.完整发布ViewsToolStripMenuItem1.Text = "完整发布Views";
            this.完整发布ViewsToolStripMenuItem1.Click += new System.EventHandler(this.完整发布ViewsToolStripMenuItem1_Click);
            // 
            // 新建项目ToolStripMenuItem
            // 
            this.新建项目ToolStripMenuItem.Name = "新建项目ToolStripMenuItem";
            this.新建项目ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.新建项目ToolStripMenuItem.Text = "新建项目";
            this.新建项目ToolStripMenuItem.Click += new System.EventHandler(this.新建项目ToolStripMenuItem_Click);
            // 
            // 编辑项目ToolStripMenuItem
            // 
            this.编辑项目ToolStripMenuItem.Name = "编辑项目ToolStripMenuItem";
            this.编辑项目ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.编辑项目ToolStripMenuItem.Text = "编辑项目";
            this.编辑项目ToolStripMenuItem.Click += new System.EventHandler(this.编辑项目ToolStripMenuItem_Click);
            // 
            // 删除项目ToolStripMenuItem
            // 
            this.删除项目ToolStripMenuItem.Name = "删除项目ToolStripMenuItem";
            this.删除项目ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.删除项目ToolStripMenuItem.Text = "删除项目";
            this.删除项目ToolStripMenuItem.Click += new System.EventHandler(this.删除项目ToolStripMenuItem_Click);
            // 
            // 资源管理器中打开文件夹ToolStripMenuItem
            // 
            this.资源管理器中打开文件夹ToolStripMenuItem.Name = "资源管理器中打开文件夹ToolStripMenuItem";
            this.资源管理器中打开文件夹ToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.资源管理器中打开文件夹ToolStripMenuItem.Text = "资源管理器中打开文件夹";
            this.资源管理器中打开文件夹ToolStripMenuItem.Click += new System.EventHandler(this.资源管理器中打开文件夹ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 804);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1485, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目ToolStripMenuItem,
            this.日志ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1485, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 项目ToolStripMenuItem
            // 
            this.项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增项目ToolStripMenuItem,
            this.显示排序号ToolStripMenuItem});
            this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
            this.项目ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.项目ToolStripMenuItem.Text = "项目";
            // 
            // 新增项目ToolStripMenuItem
            // 
            this.新增项目ToolStripMenuItem.Name = "新增项目ToolStripMenuItem";
            this.新增项目ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.新增项目ToolStripMenuItem.Text = "新建项目";
            this.新增项目ToolStripMenuItem.Click += new System.EventHandler(this.新增项目ToolStripMenuItem_Click);
            // 
            // 显示排序号ToolStripMenuItem
            // 
            this.显示排序号ToolStripMenuItem.Name = "显示排序号ToolStripMenuItem";
            this.显示排序号ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.显示排序号ToolStripMenuItem.Text = "显示排序号";
            this.显示排序号ToolStripMenuItem.Click += new System.EventHandler(this.显示排序号ToolStripMenuItem_Click);
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空更新日志ToolStripMenuItem});
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.日志ToolStripMenuItem.Text = "日志";
            // 
            // 清空更新日志ToolStripMenuItem
            // 
            this.清空更新日志ToolStripMenuItem.Name = "清空更新日志ToolStripMenuItem";
            this.清空更新日志ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.清空更新日志ToolStripMenuItem.Text = "清空更新日志";
            this.清空更新日志ToolStripMenuItem.Click += new System.EventHandler(this.清空更新日志ToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(248, 83);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1228, 716);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "更新日志";
            this.columnHeader1.Width = 750;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // 项目名称
            // 
            this.项目名称.DataPropertyName = "Name";
            this.项目名称.FillWeight = 125.1337F;
            this.项目名称.HeaderText = "项目名称";
            this.项目名称.MinimumWidth = 6;
            this.项目名称.Name = "项目名称";
            this.项目名称.ReadOnly = true;
            // 
            // 排序号
            // 
            this.排序号.DataPropertyName = "Pxh";
            this.排序号.FillWeight = 74.86631F;
            this.排序号.HeaderText = "排序号";
            this.排序号.MinimumWidth = 6;
            this.排序号.Name = "排序号";
            this.排序号.ReadOnly = true;
            this.排序号.Visible = false;
            // 
            // IpAddr
            // 
            this.IpAddr.DataPropertyName = "IpAddr";
            this.IpAddr.HeaderText = "地址";
            this.IpAddr.MinimumWidth = 6;
            this.IpAddr.Name = "IpAddr";
            this.IpAddr.ReadOnly = true;
            this.IpAddr.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "账号";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "密码";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // WebDir
            // 
            this.WebDir.DataPropertyName = "WebDir";
            this.WebDir.HeaderText = "远程目录";
            this.WebDir.MinimumWidth = 6;
            this.WebDir.Name = "WebDir";
            this.WebDir.ReadOnly = true;
            this.WebDir.Visible = false;
            // 
            // LocalDir
            // 
            this.LocalDir.DataPropertyName = "LocalDir";
            this.LocalDir.HeaderText = "本地目录";
            this.LocalDir.MinimumWidth = 6;
            this.LocalDir.Name = "LocalDir";
            this.LocalDir.ReadOnly = true;
            this.LocalDir.Visible = false;
            // 
            // DomainName
            // 
            this.DomainName.DataPropertyName = "DomainName";
            this.DomainName.HeaderText = "域名";
            this.DomainName.MinimumWidth = 6;
            this.DomainName.Name = "DomainName";
            this.DomainName.ReadOnly = true;
            this.DomainName.Visible = false;
            // 
            // 发布管理器
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 826);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "发布管理器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发布管理器";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 完整发布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增量发布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看FtpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 增量发布虚拟ToolStripMenuItem;
        private MyListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripMenuItem 项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空更新日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示排序号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资源管理器中打开文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 完整发布binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 完整发布ViewsToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 排序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn DomainName;
    }
}

