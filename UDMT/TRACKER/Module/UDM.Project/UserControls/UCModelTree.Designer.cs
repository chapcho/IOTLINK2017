namespace UDM.Project
{
    partial class UCModelTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCModelTree));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cntxMachineMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteMachine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameMachine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearRoleTypeS = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxProcessMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddMachine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearMachineS = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxLineMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterProjectlMenu1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterProjectlMenu2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearProcessS = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cntxMachineMenu.SuspendLayout();
            this.cntxProcessMenu.SuspendLayout();
            this.cntxLineMenu.SuspendLayout();
            this.cntxRoleTypeMenu.SuspendLayout();
            this.cntxSymbolMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.ShowFocusedFrame = false;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(315, 515);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
            this.exTreeList.DragOver += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragOver);
            this.exTreeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDoubleClick);
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragDrop);
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
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "Suggestion_16x16.png");
            // 
            // cntxMachineMenu
            // 
            this.cntxMachineMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteMachine,
            this.toolStripMenuItem4,
            this.mnuRenameMachine,
            this.toolStripMenuItem2,
            this.mnuClearRoleTypeS});
            this.cntxMachineMenu.Name = "mnuAddSymbols";
            this.cntxMachineMenu.Size = new System.Drawing.Size(132, 82);
            // 
            // mnuDeleteMachine
            // 
            this.mnuDeleteMachine.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteMachine.Image")));
            this.mnuDeleteMachine.Name = "mnuDeleteMachine";
            this.mnuDeleteMachine.Size = new System.Drawing.Size(131, 22);
            this.mnuDeleteMachine.Text = "Delete this";
            this.mnuDeleteMachine.Click += new System.EventHandler(this.mnuDeleteMachine_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(128, 6);
            // 
            // mnuRenameMachine
            // 
            this.mnuRenameMachine.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameMachine.Image")));
            this.mnuRenameMachine.Name = "mnuRenameMachine";
            this.mnuRenameMachine.Size = new System.Drawing.Size(131, 22);
            this.mnuRenameMachine.Text = "Rename";
            this.mnuRenameMachine.Click += new System.EventHandler(this.mnuRenameMachine_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 6);
            // 
            // mnuClearRoleTypeS
            // 
            this.mnuClearRoleTypeS.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearRoleTypeS.Image")));
            this.mnuClearRoleTypeS.Name = "mnuClearRoleTypeS";
            this.mnuClearRoleTypeS.Size = new System.Drawing.Size(131, 22);
            this.mnuClearRoleTypeS.Text = "Clear All";
            this.mnuClearRoleTypeS.Click += new System.EventHandler(this.mnuClearRoleTypeS_Click);
            // 
            // cntxProcessMenu
            // 
            this.cntxProcessMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddMachine,
            this.mnuSplitterMonitor1,
            this.mnuDeleteProcess,
            this.toolStripMenuItem3,
            this.mnuRenameProcess,
            this.mnuSplitterMonitor2,
            this.mnuClearMachineS});
            this.cntxProcessMenu.Name = "cntxMonitorGroupMenu";
            this.cntxProcessMenu.Size = new System.Drawing.Size(147, 110);
            // 
            // mnuAddMachine
            // 
            this.mnuAddMachine.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddMachine.Image")));
            this.mnuAddMachine.Name = "mnuAddMachine";
            this.mnuAddMachine.Size = new System.Drawing.Size(146, 22);
            this.mnuAddMachine.Text = "Add Machine";
            this.mnuAddMachine.Click += new System.EventHandler(this.mnuAddMachine_Click);
            // 
            // mnuSplitterMonitor1
            // 
            this.mnuSplitterMonitor1.Name = "mnuSplitterMonitor1";
            this.mnuSplitterMonitor1.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuDeleteProcess
            // 
            this.mnuDeleteProcess.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteProcess.Image")));
            this.mnuDeleteProcess.Name = "mnuDeleteProcess";
            this.mnuDeleteProcess.Size = new System.Drawing.Size(146, 22);
            this.mnuDeleteProcess.Text = "Delete this";
            this.mnuDeleteProcess.Click += new System.EventHandler(this.mnuDeleteProcess_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuRenameProcess
            // 
            this.mnuRenameProcess.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameProcess.Image")));
            this.mnuRenameProcess.Name = "mnuRenameProcess";
            this.mnuRenameProcess.Size = new System.Drawing.Size(146, 22);
            this.mnuRenameProcess.Text = "Rename";
            this.mnuRenameProcess.Click += new System.EventHandler(this.mnuRenameProcess_Click);
            // 
            // mnuSplitterMonitor2
            // 
            this.mnuSplitterMonitor2.Name = "mnuSplitterMonitor2";
            this.mnuSplitterMonitor2.Size = new System.Drawing.Size(143, 6);
            // 
            // mnuClearMachineS
            // 
            this.mnuClearMachineS.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearMachineS.Image")));
            this.mnuClearMachineS.Name = "mnuClearMachineS";
            this.mnuClearMachineS.Size = new System.Drawing.Size(146, 22);
            this.mnuClearMachineS.Text = "Clear All";
            this.mnuClearMachineS.Click += new System.EventHandler(this.mnuClearMachineS_Click);
            // 
            // cntxLineMenu
            // 
            this.cntxLineMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddProcess,
            this.mnuSplitterProjectlMenu1,
            this.mnuRenameLine,
            this.mnuSplitterProjectlMenu2,
            this.mnuClearProcessS,
            this.toolStripMenuItem1,
            this.mnuExpandAll,
            this.mnuCollapseAll});
            this.cntxLineMenu.Name = "cntxProjectMenu";
            this.cntxLineMenu.Size = new System.Drawing.Size(145, 132);
            // 
            // mnuAddProcess
            // 
            this.mnuAddProcess.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddProcess.Image")));
            this.mnuAddProcess.Name = "mnuAddProcess";
            this.mnuAddProcess.Size = new System.Drawing.Size(144, 22);
            this.mnuAddProcess.Text = "Add  Process";
            this.mnuAddProcess.Click += new System.EventHandler(this.mnuAddProcess_Click);
            // 
            // mnuSplitterProjectlMenu1
            // 
            this.mnuSplitterProjectlMenu1.Name = "mnuSplitterProjectlMenu1";
            this.mnuSplitterProjectlMenu1.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuRenameLine
            // 
            this.mnuRenameLine.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameLine.Image")));
            this.mnuRenameLine.Name = "mnuRenameLine";
            this.mnuRenameLine.Size = new System.Drawing.Size(144, 22);
            this.mnuRenameLine.Text = "Rename";
            this.mnuRenameLine.Click += new System.EventHandler(this.mnuRenameLine_Click);
            // 
            // mnuSplitterProjectlMenu2
            // 
            this.mnuSplitterProjectlMenu2.Name = "mnuSplitterProjectlMenu2";
            this.mnuSplitterProjectlMenu2.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuClearProcessS
            // 
            this.mnuClearProcessS.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearProcessS.Image")));
            this.mnuClearProcessS.Name = "mnuClearProcessS";
            this.mnuClearProcessS.Size = new System.Drawing.Size(144, 22);
            this.mnuClearProcessS.Text = "Clear All";
            this.mnuClearProcessS.Click += new System.EventHandler(this.mnuClearProcessS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuExpandAll
            // 
            this.mnuExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("mnuExpandAll.Image")));
            this.mnuExpandAll.Name = "mnuExpandAll";
            this.mnuExpandAll.Size = new System.Drawing.Size(144, 22);
            this.mnuExpandAll.Text = "Expand All";
            this.mnuExpandAll.Click += new System.EventHandler(this.mnuExpandAll_Click);
            // 
            // mnuCollapseAll
            // 
            this.mnuCollapseAll.Name = "mnuCollapseAll";
            this.mnuCollapseAll.Size = new System.Drawing.Size(144, 22);
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
            // UCModelTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCModelTree";
            this.Size = new System.Drawing.Size(315, 515);
            this.Load += new System.EventHandler(this.UCModelTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.cntxMachineMenu.ResumeLayout(false);
            this.cntxProcessMenu.ResumeLayout(false);
            this.cntxLineMenu.ResumeLayout(false);
            this.cntxRoleTypeMenu.ResumeLayout(false);
            this.cntxSymbolMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.ContextMenuStrip cntxMachineMenu;
        private System.Windows.Forms.ContextMenuStrip cntxProcessMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameProcess;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor1;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearMachineS;
        private System.Windows.Forms.ContextMenuStrip cntxLineMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddProcess;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterProjectlMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearProcessS;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterProjectlMenu2;
        private System.Windows.Forms.ToolStripMenuItem mnuExpandAll;
        private System.Windows.Forms.ToolStripMenuItem mnuCollapseAll;
        private System.Windows.Forms.ContextMenuStrip cntxRoleTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddSymbolS;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterSymbolMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearSymbolS;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameLine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddMachine;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameMachine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearRoleTypeS;
        private System.Windows.Forms.ContextMenuStrip cntxSymbolMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbol;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteProcess;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteMachine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}
