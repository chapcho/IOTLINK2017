namespace UDMTrackerSimple
{
    partial class FrmAbnormalTreeViewer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbnormalTreeViewer));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDepth = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInverse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPriority = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tgsPriority = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tgsPriority.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGroup,
            this.colDescription,
            this.colDepth,
            this.colAState,
            this.colInverse,
            this.colPriority});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 28);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.RowHeight = 30;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(780, 555);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.exTreeList_CellValueChanging);
            this.exTreeList.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.exTreeList_CellValueChanged);
            // 
            // colGroup
            // 
            this.colGroup.Caption = "분류";
            this.colGroup.FieldName = "분류";
            this.colGroup.MinWidth = 33;
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.OptionsColumn.AllowMove = false;
            this.colGroup.OptionsColumn.AllowSort = false;
            this.colGroup.OptionsColumn.ReadOnly = true;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 206;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "설명";
            this.colDescription.FieldName = "설명";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.OptionsColumn.AllowSort = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 393;
            // 
            // colDepth
            // 
            this.colDepth.AppearanceCell.Options.UseTextOptions = true;
            this.colDepth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepth.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepth.Caption = "Depth";
            this.colDepth.FieldName = "Depth";
            this.colDepth.Name = "colDepth";
            this.colDepth.OptionsColumn.AllowEdit = false;
            this.colDepth.OptionsColumn.AllowMove = false;
            this.colDepth.OptionsColumn.AllowSort = false;
            this.colDepth.OptionsColumn.FixedWidth = true;
            this.colDepth.OptionsColumn.ReadOnly = true;
            this.colDepth.Visible = true;
            this.colDepth.VisibleIndex = 2;
            this.colDepth.Width = 50;
            // 
            // colAState
            // 
            this.colAState.AppearanceCell.Options.UseTextOptions = true;
            this.colAState.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAState.AppearanceHeader.Options.UseTextOptions = true;
            this.colAState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAState.Caption = "A 접점";
            this.colAState.FieldName = "A 접점";
            this.colAState.Name = "colAState";
            this.colAState.OptionsColumn.AllowEdit = false;
            this.colAState.OptionsColumn.AllowMove = false;
            this.colAState.OptionsColumn.AllowSort = false;
            this.colAState.OptionsColumn.FixedWidth = true;
            this.colAState.OptionsColumn.ReadOnly = true;
            this.colAState.Visible = true;
            this.colAState.VisibleIndex = 3;
            this.colAState.Width = 80;
            // 
            // colInverse
            // 
            this.colInverse.AppearanceCell.Options.UseTextOptions = true;
            this.colInverse.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInverse.AppearanceHeader.Options.UseTextOptions = true;
            this.colInverse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInverse.Caption = "Inverse";
            this.colInverse.FieldName = "Inverse";
            this.colInverse.Name = "colInverse";
            this.colInverse.OptionsColumn.AllowEdit = false;
            this.colInverse.OptionsColumn.AllowMove = false;
            this.colInverse.OptionsColumn.AllowSort = false;
            this.colInverse.OptionsColumn.FixedWidth = true;
            this.colInverse.OptionsColumn.ReadOnly = true;
            this.colInverse.Visible = true;
            this.colInverse.VisibleIndex = 4;
            this.colInverse.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.AppearanceCell.Options.UseTextOptions = true;
            this.colPriority.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriority.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriority.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriority.Caption = "Priority";
            this.colPriority.FieldName = "Priority";
            this.colPriority.Name = "colPriority";
            this.colPriority.OptionsColumn.AllowEdit = false;
            this.colPriority.OptionsColumn.AllowMove = false;
            this.colPriority.OptionsColumn.AllowSort = false;
            this.colPriority.OptionsColumn.FixedWidth = true;
            this.colPriority.OptionsColumn.ReadOnly = true;
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 5;
            this.colPriority.Width = 50;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(3, "ContentArrangeInRows_16x16.png");
            this.imgList.Images.SetKeyName(4, "Windows_16x16.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 583);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(780, 46);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(685, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.tgsPriority);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(780, 28);
            this.panelControl2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(488, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(195, 24);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "이상 신호 Priority 수정 가능 여부 : ";
            // 
            // tgsPriority
            // 
            this.tgsPriority.Dock = System.Windows.Forms.DockStyle.Right;
            this.tgsPriority.Location = new System.Drawing.Point(683, 2);
            this.tgsPriority.Name = "tgsPriority";
            this.tgsPriority.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tgsPriority.Properties.OffText = "Off";
            this.tgsPriority.Properties.OnText = "On";
            this.tgsPriority.Size = new System.Drawing.Size(95, 25);
            this.tgsPriority.TabIndex = 0;
            this.tgsPriority.Toggled += new System.EventHandler(this.tgsPriority_Toggled);
            // 
            // FrmAbnormalTreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 629);
            this.Controls.Add(this.exTreeList);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAbnormalTreeViewer";
            this.Text = "이상 신호 Tree Structure Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAbnormalTreeViewer_FormClosed);
            this.Load += new System.EventHandler(this.FrmAbnormalTreeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tgsPriority.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDepth;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInverse;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPriority;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ToggleSwitch tgsPriority;
    }
}