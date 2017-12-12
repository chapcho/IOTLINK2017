namespace UDMOptimizer
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
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDepth = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInverse = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(691, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colGroup,
            this.colDescription,
            this.colDepth,
            this.colAState,
            this.colInverse});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.RowHeight = 30;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(786, 583);
            this.exTreeList.TabIndex = 2;
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
            this.colDepth.Visible = true;
            this.colDepth.VisibleIndex = 2;
            this.colDepth.Width = 59;
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
            this.colAState.Visible = true;
            this.colAState.VisibleIndex = 3;
            this.colAState.Width = 55;
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
            this.colInverse.Visible = true;
            this.colInverse.VisibleIndex = 4;
            this.colInverse.Width = 55;
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
            this.panelControl1.Size = new System.Drawing.Size(786, 46);
            this.panelControl1.TabIndex = 3;
            // 
            // FrmAbnormalTreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 629);
            this.Controls.Add(this.exTreeList);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmAbnormalTreeViewer";
            this.Text = "FrmAbnormalTreeViewer";
            this.Load += new System.EventHandler(this.FrmAbnormalTreeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDepth;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInverse;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}