namespace UDM.Project
{
    partial class UCGroupTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCGroupTree));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cntxGroupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxProjectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterProjectlMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterProjectlMenu2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearGroupS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxRoleTypeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterSymbolMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSymbolMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteSymbol = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.cntxGroupMenu.SuspendLayout();
            this.cntxProjectMenu.SuspendLayout();
            this.cntxRoleTypeMenu.SuspendLayout();
            this.cntxSymbolMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colDescription});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.ReadOnly = true;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(315, 515);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragDrop);
            this.exTreeList.DragOver += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragOver);
            this.exTreeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
            this.exTreeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDoubleClick);
            this.exTreeList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDown);
            this.exTreeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseMove);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 33;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            // 
            // cntxGroupMenu
            // 
            this.cntxGroupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteGroup,
            this.mnuSplitterMonitor1,
            this.mnuRenameGroup,
            this.mnuSplitterMonitor2,
            this.mnuClearGroup});
            this.cntxGroupMenu.Name = "cntxMonitorGroupMenu";
            this.cntxGroupMenu.Size = new System.Drawing.Size(132, 82);
            // 
            // mnuDeleteGroup
            // 
            this.mnuDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteGroup.Image")));
            this.mnuDeleteGroup.Name = "mnuDeleteGroup";
            this.mnuDeleteGroup.Size = new System.Drawing.Size(131, 22);
            this.mnuDeleteGroup.Text = "Delete this";
            this.mnuDeleteGroup.Click += new System.EventHandler(this.mnuDeleteGroup_Click);
            // 
            // mnuSplitterMonitor1
            // 
            this.mnuSplitterMonitor1.Name = "mnuSplitterMonitor1";
            this.mnuSplitterMonitor1.Size = new System.Drawing.Size(128, 6);
            // 
            // mnuRenameGroup
            // 
            this.mnuRenameGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameGroup.Image")));
            this.mnuRenameGroup.Name = "mnuRenameGroup";
            this.mnuRenameGroup.Size = new System.Drawing.Size(131, 22);
            this.mnuRenameGroup.Text = "Rename";
            this.mnuRenameGroup.Click += new System.EventHandler(this.mnuRenameGroup_Click);
            // 
            // mnuSplitterMonitor2
            // 
            this.mnuSplitterMonitor2.Name = "mnuSplitterMonitor2";
            this.mnuSplitterMonitor2.Size = new System.Drawing.Size(128, 6);
            // 
            // mnuClearGroup
            // 
            this.mnuClearGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearGroup.Image")));
            this.mnuClearGroup.Name = "mnuClearGroup";
            this.mnuClearGroup.Size = new System.Drawing.Size(131, 22);
            this.mnuClearGroup.Text = "Clear All";
            this.mnuClearGroup.Click += new System.EventHandler(this.mnuClearGroup_Click);
            // 
            // cntxProjectMenu
            // 
            this.cntxProjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddGroup,
            this.mnuSplitterProjectlMenu1,
            this.mnuRenameProject,
            this.mnuSplitterProjectlMenu2,
            this.mnuClearGroupS,
            this.toolStripMenuItem1,
            this.mnuExpandAll,
            this.mnuCollapseAll});
            this.cntxProjectMenu.Name = "cntxProjectMenu";
            this.cntxProjectMenu.Size = new System.Drawing.Size(138, 132);
            // 
            // mnuAddGroup
            // 
            this.mnuAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddGroup.Image")));
            this.mnuAddGroup.Name = "mnuAddGroup";
            this.mnuAddGroup.Size = new System.Drawing.Size(137, 22);
            this.mnuAddGroup.Text = "Add  Group";
            this.mnuAddGroup.Click += new System.EventHandler(this.mnuAddGroup_Click);
            // 
            // mnuSplitterProjectlMenu1
            // 
            this.mnuSplitterProjectlMenu1.Name = "mnuSplitterProjectlMenu1";
            this.mnuSplitterProjectlMenu1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuRenameProject
            // 
            this.mnuRenameProject.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameProject.Image")));
            this.mnuRenameProject.Name = "mnuRenameProject";
            this.mnuRenameProject.Size = new System.Drawing.Size(137, 22);
            this.mnuRenameProject.Text = "Rename";
            this.mnuRenameProject.Click += new System.EventHandler(this.mnuRenameProject_Click);
            // 
            // mnuSplitterProjectlMenu2
            // 
            this.mnuSplitterProjectlMenu2.Name = "mnuSplitterProjectlMenu2";
            this.mnuSplitterProjectlMenu2.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuClearGroupS
            // 
            this.mnuClearGroupS.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearGroupS.Image")));
            this.mnuClearGroupS.Name = "mnuClearGroupS";
            this.mnuClearGroupS.Size = new System.Drawing.Size(137, 22);
            this.mnuClearGroupS.Text = "Clear All";
            this.mnuClearGroupS.Click += new System.EventHandler(this.mnuClearGroupS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
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
            // cntxRoleTypeMenu
            // 
            this.cntxRoleTypeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddSymbolS,
            this.mnuSplitterSymbolMenu1,
            this.mnuClearSymbolS});
            this.cntxRoleTypeMenu.Name = "mnuAddSymbols";
            this.cntxRoleTypeMenu.Size = new System.Drawing.Size(155, 54);
            // 
            // mnuAddSymbolS
            // 
            this.mnuAddSymbolS.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddSymbolS.Image")));
            this.mnuAddSymbolS.Name = "mnuAddSymbolS";
            this.mnuAddSymbolS.Size = new System.Drawing.Size(154, 22);
            this.mnuAddSymbolS.Text = "Add Symbol(s)";
            this.mnuAddSymbolS.Click += new System.EventHandler(this.mnuAddSymbolS_Click);
            // 
            // mnuSplitterSymbolMenu1
            // 
            this.mnuSplitterSymbolMenu1.Name = "mnuSplitterSymbolMenu1";
            this.mnuSplitterSymbolMenu1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuClearSymbolS
            // 
            this.mnuClearSymbolS.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearSymbolS.Image")));
            this.mnuClearSymbolS.Name = "mnuClearSymbolS";
            this.mnuClearSymbolS.Size = new System.Drawing.Size(154, 22);
            this.mnuClearSymbolS.Text = "Clear All";
            this.mnuClearSymbolS.Click += new System.EventHandler(this.mnuClearSymbolS_Click);
            // 
            // cntxSymbolMenu
            // 
            this.cntxSymbolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteSymbol});
            this.cntxSymbolMenu.Name = "mnuAddSymbols";
            this.cntxSymbolMenu.Size = new System.Drawing.Size(132, 26);
            // 
            // mnuDeleteSymbol
            // 
            this.mnuDeleteSymbol.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteSymbol.Image")));
            this.mnuDeleteSymbol.Name = "mnuDeleteSymbol";
            this.mnuDeleteSymbol.Size = new System.Drawing.Size(131, 22);
            this.mnuDeleteSymbol.Text = "Delete this";
            this.mnuDeleteSymbol.Click += new System.EventHandler(this.mnuDeleteSymbol_Click);
            // 
            // UCGroupTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCGroupTree";
            this.Size = new System.Drawing.Size(315, 515);
            this.Load += new System.EventHandler(this.UCModelTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.cntxGroupMenu.ResumeLayout(false);
            this.cntxProjectMenu.ResumeLayout(false);
            this.cntxRoleTypeMenu.ResumeLayout(false);
            this.cntxSymbolMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.ContextMenuStrip cntxGroupMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameGroup;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor1;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearGroup;
        private System.Windows.Forms.ContextMenuStrip cntxProjectMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddGroup;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterProjectlMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearGroupS;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterProjectlMenu2;
        private System.Windows.Forms.ToolStripMenuItem mnuExpandAll;
        private System.Windows.Forms.ToolStripMenuItem mnuCollapseAll;
        private System.Windows.Forms.ContextMenuStrip cntxRoleTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSymbolS;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterSymbolMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearSymbolS;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cntxSymbolMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbol;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
    }
}
