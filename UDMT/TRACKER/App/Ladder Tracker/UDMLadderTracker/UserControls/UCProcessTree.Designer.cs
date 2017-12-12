namespace UDMLadderTracker
{
    partial class UCProcessTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCProcessTree));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colProcess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cntxProcessMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRenameGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSymbolMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxRoleTypeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuClearSymbol = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.cntxProcessMenu.SuspendLayout();
            this.cntxSymbolMenu.SuspendLayout();
            this.cntxRoleTypeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.CaptionHeight = 30;
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colProcess,
            this.colDescription});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.FooterPanelHeight = 21;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeList.RowHeight = 30;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(308, 458);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragDrop);
            this.exTreeList.DragOver += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragOver);
            this.exTreeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDoubleClick);
            this.exTreeList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDown);
            this.exTreeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseMove);
            // 
            // colProcess
            // 
            this.colProcess.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcess.AppearanceCell.Options.UseFont = true;
            this.colProcess.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcess.AppearanceHeader.Options.UseFont = true;
            this.colProcess.Caption = "Process";
            this.colProcess.FieldName = "Name";
            this.colProcess.MinWidth = 33;
            this.colProcess.Name = "colProcess";
            this.colProcess.Visible = true;
            this.colProcess.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.Options.UseFont = true;
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
            this.imgList.Images.SetKeyName(3, "ContentArrangeInRows_16x16.png");
            // 
            // cntxProcessMenu
            // 
            this.cntxProcessMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxProcessMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteGroup,
            this.mnuSplitterMonitor1,
            this.mnuRenameGroup});
            this.cntxProcessMenu.Name = "cntxMonitorGroupMenu";
            this.cntxProcessMenu.Size = new System.Drawing.Size(136, 62);
            // 
            // mnuDeleteGroup
            // 
            this.mnuDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteGroup.Image")));
            this.mnuDeleteGroup.Name = "mnuDeleteGroup";
            this.mnuDeleteGroup.Size = new System.Drawing.Size(135, 26);
            this.mnuDeleteGroup.Text = "Delete this";
            this.mnuDeleteGroup.Click += new System.EventHandler(this.mnuDeleteGroup_Click);
            // 
            // mnuSplitterMonitor1
            // 
            this.mnuSplitterMonitor1.Name = "mnuSplitterMonitor1";
            this.mnuSplitterMonitor1.Size = new System.Drawing.Size(132, 6);
            // 
            // mnuRenameGroup
            // 
            this.mnuRenameGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameGroup.Image")));
            this.mnuRenameGroup.Name = "mnuRenameGroup";
            this.mnuRenameGroup.Size = new System.Drawing.Size(135, 26);
            this.mnuRenameGroup.Text = "Rename";
            this.mnuRenameGroup.Click += new System.EventHandler(this.mnuRenameGroup_Click);
            // 
            // cntxSymbolMenu
            // 
            this.cntxSymbolMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxSymbolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteSymbol});
            this.cntxSymbolMenu.Name = "mnuAddSymbols";
            this.cntxSymbolMenu.Size = new System.Drawing.Size(136, 30);
            // 
            // mnuDeleteSymbol
            // 
            this.mnuDeleteSymbol.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteSymbol.Image")));
            this.mnuDeleteSymbol.Name = "mnuDeleteSymbol";
            this.mnuDeleteSymbol.Size = new System.Drawing.Size(135, 26);
            this.mnuDeleteSymbol.Text = "Delete this";
            this.mnuDeleteSymbol.Click += new System.EventHandler(this.mnuDeleteSymbol_Click);
            // 
            // cntxRoleTypeMenu
            // 
            this.cntxRoleTypeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxRoleTypeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearSymbol});
            this.cntxRoleTypeMenu.Name = "mnuAddSymbols";
            this.cntxRoleTypeMenu.Size = new System.Drawing.Size(106, 30);
            // 
            // mnuClearSymbol
            // 
            this.mnuClearSymbol.Image = ((System.Drawing.Image)(resources.GetObject("mnuClearSymbol.Image")));
            this.mnuClearSymbol.Name = "mnuClearSymbol";
            this.mnuClearSymbol.Size = new System.Drawing.Size(105, 26);
            this.mnuClearSymbol.Text = "Clear";
            this.mnuClearSymbol.Click += new System.EventHandler(this.mnuClearSymbol_Click);
            // 
            // UCProcessTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCProcessTree";
            this.Size = new System.Drawing.Size(308, 458);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.cntxProcessMenu.ResumeLayout(false);
            this.cntxSymbolMenu.ResumeLayout(false);
            this.cntxRoleTypeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProcess;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxProcessMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteGroup;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor1;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameGroup;
        private System.Windows.Forms.ContextMenuStrip cntxSymbolMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip cntxRoleTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuClearSymbol;
    }
}
