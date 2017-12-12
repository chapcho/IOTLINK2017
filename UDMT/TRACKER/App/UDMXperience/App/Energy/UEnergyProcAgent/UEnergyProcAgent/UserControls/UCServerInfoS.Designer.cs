namespace UEnergyProcAgent
{
    partial class UCServerInfoS
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCServerInfoS));
            this.trvServerInfoS = new DevExpress.XtraTreeList.TreeList();
            this.colLevel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cntxProjectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterProject1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxServerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterServer1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterServer2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearServer = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxChannelMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteChannel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trvServerInfoS)).BeginInit();
            this.cntxProjectMenu.SuspendLayout();
            this.cntxServerMenu.SuspendLayout();
            this.cntxChannelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvServerInfoS
            // 
            this.trvServerInfoS.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colLevel,
            this.colName,
            this.colAddress});
            this.trvServerInfoS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvServerInfoS.Location = new System.Drawing.Point(0, 0);
            this.trvServerInfoS.Name = "trvServerInfoS";
            this.trvServerInfoS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trvServerInfoS.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.trvServerInfoS.SelectImageList = this.imgList;
            this.trvServerInfoS.Size = new System.Drawing.Size(329, 432);
            this.trvServerInfoS.TabIndex = 0;
            this.trvServerInfoS.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.trvSeriesInfoS_PopupMenuShowing);
            this.trvServerInfoS.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.trvServerInfoS_CellValueChanged);
            // 
            // colLevel
            // 
            this.colLevel.AppearanceHeader.Options.UseTextOptions = true;
            this.colLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLevel.Caption = "Level";
            this.colLevel.FieldName = "Level";
            this.colLevel.MinWidth = 33;
            this.colLevel.Name = "colLevel";
            this.colLevel.OptionsColumn.AllowEdit = false;
            this.colLevel.OptionsColumn.ReadOnly = true;
            this.colLevel.Visible = true;
            this.colLevel.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Service / Channel";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "IP / Layer";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            // 
            // cntxProjectMenu
            // 
            this.cntxProjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddServer,
            this.mnuSplitterProject1,
            this.mnuClearProject,
            this.toolStripMenuItem2,
            this.mnuExpandAll,
            this.mnuCollapseAll});
            this.cntxProjectMenu.Name = "cntxProjectMenu";
            this.cntxProjectMenu.Size = new System.Drawing.Size(138, 104);
            // 
            // mnuAddServer
            // 
            this.mnuAddServer.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddServer.Image")));
            this.mnuAddServer.Name = "mnuAddServer";
            this.mnuAddServer.Size = new System.Drawing.Size(137, 22);
            this.mnuAddServer.Text = "Add  Server";
            this.mnuAddServer.Click += new System.EventHandler(this.mnuAddServer_Click);
            // 
            // mnuSplitterProject1
            // 
            this.mnuSplitterProject1.Name = "mnuSplitterProject1";
            this.mnuSplitterProject1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuClearProject
            // 
            this.mnuClearProject.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearProject.Image")));
            this.mnuClearProject.Name = "mnuClearProject";
            this.mnuClearProject.Size = new System.Drawing.Size(137, 22);
            this.mnuClearProject.Text = "Clear All";
            this.mnuClearProject.Click += new System.EventHandler(this.mnuClearProject_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuExpandAll
            // 
            this.mnuExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("mnuExpandAll.Image")));
            this.mnuExpandAll.Name = "mnuExpandAll";
            this.mnuExpandAll.Size = new System.Drawing.Size(137, 22);
            this.mnuExpandAll.Text = "Expand All";
            this.mnuExpandAll.Click += new System.EventHandler(this.mnuExpandAll_Click);
            // 
            // mnuCollapseAll
            // 
            this.mnuCollapseAll.Name = "mnuCollapseAll";
            this.mnuCollapseAll.Size = new System.Drawing.Size(137, 22);
            this.mnuCollapseAll.Text = "Collapse All";
            this.mnuCollapseAll.Click += new System.EventHandler(this.mnuCollapseAll_Click);
            // 
            // cntxServerMenu
            // 
            this.cntxServerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddChannel,
            this.mnuSplitterServer1,
            this.mnuDeleteServer,
            this.mnuSplitterServer2,
            this.mnuClearServer});
            this.cntxServerMenu.Name = "cntxMonitorGroupMenu";
            this.cntxServerMenu.Size = new System.Drawing.Size(145, 82);
            // 
            // mnuAddChannel
            // 
            this.mnuAddChannel.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddChannel.Image")));
            this.mnuAddChannel.Name = "mnuAddChannel";
            this.mnuAddChannel.Size = new System.Drawing.Size(144, 22);
            this.mnuAddChannel.Text = "Add Channel";
            this.mnuAddChannel.Click += new System.EventHandler(this.mnuAddChannel_Click);
            // 
            // mnuSplitterServer1
            // 
            this.mnuSplitterServer1.Name = "mnuSplitterServer1";
            this.mnuSplitterServer1.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuDeleteServer
            // 
            this.mnuDeleteServer.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteServer.Image")));
            this.mnuDeleteServer.Name = "mnuDeleteServer";
            this.mnuDeleteServer.Size = new System.Drawing.Size(144, 22);
            this.mnuDeleteServer.Text = "Delete this";
            this.mnuDeleteServer.Click += new System.EventHandler(this.mnuDeleteServer_Click);
            // 
            // mnuSplitterServer2
            // 
            this.mnuSplitterServer2.Name = "mnuSplitterServer2";
            this.mnuSplitterServer2.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuClearServer
            // 
            this.mnuClearServer.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearServer.Image")));
            this.mnuClearServer.Name = "mnuClearServer";
            this.mnuClearServer.Size = new System.Drawing.Size(144, 22);
            this.mnuClearServer.Text = "Clear All";
            this.mnuClearServer.Click += new System.EventHandler(this.mnuClearServer_Click);
            // 
            // cntxChannelMenu
            // 
            this.cntxChannelMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteChannel});
            this.cntxChannelMenu.Name = "mnuAddSymbols";
            this.cntxChannelMenu.Size = new System.Drawing.Size(132, 26);
            // 
            // mnuDeleteChannel
            // 
            this.mnuDeleteChannel.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteChannel.Image")));
            this.mnuDeleteChannel.Name = "mnuDeleteChannel";
            this.mnuDeleteChannel.Size = new System.Drawing.Size(131, 22);
            this.mnuDeleteChannel.Text = "Delete this";
            this.mnuDeleteChannel.Click += new System.EventHandler(this.mnuDeleteChannel_Click);
            // 
            // UCServerInfoS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trvServerInfoS);
            this.Name = "UCServerInfoS";
            this.Size = new System.Drawing.Size(329, 432);
            this.Load += new System.EventHandler(this.UCServerInfoS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trvServerInfoS)).EndInit();
            this.cntxProjectMenu.ResumeLayout(false);
            this.cntxServerMenu.ResumeLayout(false);
            this.cntxChannelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trvServerInfoS;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxProjectMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddServer;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterProject1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuExpandAll;
        private System.Windows.Forms.ToolStripMenuItem mnuCollapseAll;
        private System.Windows.Forms.ContextMenuStrip cntxServerMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddChannel;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterServer1;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteServer;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterServer2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearServer;
        private System.Windows.Forms.ContextMenuStrip cntxChannelMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteChannel;
    }
}
