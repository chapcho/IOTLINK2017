namespace UDMProfiler
{
    partial class UCProjectTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCProjectTree));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList();
            this.cntxProjectMenu = new System.Windows.Forms.ContextMenuStrip();
            this.mnuDeleteProject = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxPlcMenu = new System.Windows.Forms.ContextMenuStrip();
            this.mnuDeletePlc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRenamePlc = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.cntxProjectMenu.SuspendLayout();
            this.cntxPlcMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.CaptionHeight = 30;
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colInfo});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.FooterPanelHeight = 21;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeList.OptionsView.ShowIndicator = false;
            this.exTreeList.RowHeight = 30;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(271, 486);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.TreeLevelWidth = 15;
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDown);
            // 
            // colInfo
            // 
            this.colInfo.Caption = "Information";
            this.colInfo.FieldName = "Information";
            this.colInfo.MinWidth = 33;
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 0;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "ContentArrangeInRows_16x16.png");
            this.imgList.Images.SetKeyName(1, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(2, "Open_16x16.png");
            this.imgList.Images.SetKeyName(3, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(4, "Windows_16x16.png");
            this.imgList.Images.SetKeyName(5, "Info_16x16.png");
            // 
            // cntxProjectMenu
            // 
            this.cntxProjectMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxProjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteProject});
            this.cntxProjectMenu.Name = "mnuAddSymbols";
            this.cntxProjectMenu.Size = new System.Drawing.Size(136, 30);
            // 
            // mnuDeleteProject
            // 
            this.mnuDeleteProject.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteProject.Image")));
            this.mnuDeleteProject.Name = "mnuDeleteProject";
            this.mnuDeleteProject.Size = new System.Drawing.Size(135, 26);
            this.mnuDeleteProject.Text = "Delete this";
            this.mnuDeleteProject.Click += new System.EventHandler(this.mnuDeleteProject_Click);
            // 
            // cntxPlcMenu
            // 
            this.cntxPlcMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxPlcMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeletePlc,
            this.mnuRenamePlc});
            this.cntxPlcMenu.Name = "mnuAddSymbols";
            this.cntxPlcMenu.Size = new System.Drawing.Size(157, 78);
            // 
            // mnuDeletePlc
            // 
            this.mnuDeletePlc.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeletePlc.Image")));
            this.mnuDeletePlc.Name = "mnuDeletePlc";
            this.mnuDeletePlc.Size = new System.Drawing.Size(156, 26);
            this.mnuDeletePlc.Text = "Delete this";
            this.mnuDeletePlc.Click += new System.EventHandler(this.mnuDeletePlc_Click);
            // 
            // mnuRenamePlc
            // 
            this.mnuRenamePlc.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenamePlc.Image")));
            this.mnuRenamePlc.Name = "mnuRenamePlc";
            this.mnuRenamePlc.Size = new System.Drawing.Size(156, 26);
            this.mnuRenamePlc.Text = "Rename this";
            this.mnuRenamePlc.Click += new System.EventHandler(this.mnuRenamePlc_Click);
            // 
            // UCProjectTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCProjectTree";
            this.Size = new System.Drawing.Size(271, 486);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.cntxProjectMenu.ResumeLayout(false);
            this.cntxPlcMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInfo;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxProjectMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteProject;
        private System.Windows.Forms.ContextMenuStrip cntxPlcMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePlc;
        private System.Windows.Forms.ToolStripMenuItem mnuRenamePlc;

    }
}
