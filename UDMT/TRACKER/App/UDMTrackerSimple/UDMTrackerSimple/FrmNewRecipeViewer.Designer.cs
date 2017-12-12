namespace UDMTrackerSimple
{
    partial class FrmNewRecipeViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewRecipeViewer));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlBackground = new DevExpress.XtraEditors.PanelControl();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdRecipe = new DevExpress.XtraGrid.GridControl();
            this.grvRecipe = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbInfo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colGroupKey = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colRecipe = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbCount = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCurrentCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTargetCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).BeginInit();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnlBackground);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(440, 87);
            this.panelControl1.TabIndex = 0;
            // 
            // pnlBackground
            // 
            this.pnlBackground.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlBackground.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.pnlBackground.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.pnlBackground.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBackground.Appearance.Options.UseBackColor = true;
            this.pnlBackground.Appearance.Options.UseBorderColor = true;
            this.pnlBackground.Controls.Add(this.lblText);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(2, 2);
            this.pnlBackground.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBackground.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.pnlBackground.Size = new System.Drawing.Size(436, 83);
            this.pnlBackground.TabIndex = 6;
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(12, 14);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(412, 55);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "새로운 Recipe 감지!!!";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdRecipe);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 87);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(440, 208);
            this.panelControl2.TabIndex = 1;
            // 
            // grdRecipe
            // 
            this.grdRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecipe.Location = new System.Drawing.Point(2, 2);
            this.grdRecipe.MainView = this.grvRecipe;
            this.grdRecipe.Name = "grdRecipe";
            this.grdRecipe.Size = new System.Drawing.Size(436, 204);
            this.grdRecipe.TabIndex = 0;
            this.grdRecipe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRecipe});
            // 
            // grvRecipe
            // 
            this.grvRecipe.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbInfo,
            this.gbCount});
            this.grvRecipe.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colGroupKey,
            this.colRecipe,
            this.colCurrentCount,
            this.colTargetCount});
            this.grvRecipe.GridControl = this.grdRecipe;
            this.grvRecipe.Name = "grvRecipe";
            this.grvRecipe.OptionsBehavior.Editable = false;
            this.grvRecipe.OptionsBehavior.ReadOnly = true;
            this.grvRecipe.OptionsDetail.AllowZoomDetail = false;
            this.grvRecipe.OptionsDetail.EnableMasterViewMode = false;
            this.grvRecipe.OptionsDetail.ShowDetailTabs = false;
            this.grvRecipe.OptionsDetail.SmartDetailExpand = false;
            this.grvRecipe.OptionsView.ShowGroupPanel = false;
            this.grvRecipe.RowHeight = 30;
            // 
            // gbInfo
            // 
            this.gbInfo.AppearanceHeader.Options.UseTextOptions = true;
            this.gbInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbInfo.Caption = "정보";
            this.gbInfo.Columns.Add(this.colGroupKey);
            this.gbInfo.Columns.Add(this.colRecipe);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.VisibleIndex = 0;
            this.gbInfo.Width = 345;
            // 
            // colGroupKey
            // 
            this.colGroupKey.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceCell.Options.UseFont = true;
            this.colGroupKey.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.Caption = "공정";
            this.colGroupKey.FieldName = "GroupKey";
            this.colGroupKey.Name = "colGroupKey";
            this.colGroupKey.OptionsColumn.AllowEdit = false;
            this.colGroupKey.OptionsColumn.AllowMove = false;
            this.colGroupKey.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGroupKey.OptionsColumn.ReadOnly = true;
            this.colGroupKey.Visible = true;
            this.colGroupKey.Width = 167;
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRecipe.AppearanceCell.Options.UseFont = true;
            this.colRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.Caption = "NEW Recipe";
            this.colRecipe.FieldName = "Recipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.OptionsColumn.AllowEdit = false;
            this.colRecipe.OptionsColumn.AllowMove = false;
            this.colRecipe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRecipe.OptionsColumn.ReadOnly = true;
            this.colRecipe.Visible = true;
            this.colRecipe.Width = 178;
            // 
            // gbCount
            // 
            this.gbCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gbCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbCount.Caption = "For Master Pattern";
            this.gbCount.Columns.Add(this.colCurrentCount);
            this.gbCount.Columns.Add(this.colTargetCount);
            this.gbCount.Name = "gbCount";
            this.gbCount.VisibleIndex = 1;
            this.gbCount.Width = 200;
            // 
            // colCurrentCount
            // 
            this.colCurrentCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCurrentCount.AppearanceCell.Options.UseFont = true;
            this.colCurrentCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentCount.Caption = "현재 Count";
            this.colCurrentCount.FieldName = "CurrentCount";
            this.colCurrentCount.Name = "colCurrentCount";
            this.colCurrentCount.OptionsColumn.AllowEdit = false;
            this.colCurrentCount.OptionsColumn.AllowMove = false;
            this.colCurrentCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrentCount.OptionsColumn.FixedWidth = true;
            this.colCurrentCount.OptionsColumn.ReadOnly = true;
            this.colCurrentCount.Visible = true;
            this.colCurrentCount.Width = 100;
            // 
            // colTargetCount
            // 
            this.colTargetCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTargetCount.AppearanceCell.Options.UseFont = true;
            this.colTargetCount.AppearanceCell.Options.UseTextOptions = true;
            this.colTargetCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colTargetCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetCount.Caption = "목표 Count";
            this.colTargetCount.FieldName = "TargetCount";
            this.colTargetCount.Name = "colTargetCount";
            this.colTargetCount.OptionsColumn.AllowEdit = false;
            this.colTargetCount.OptionsColumn.AllowMove = false;
            this.colTargetCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTargetCount.OptionsColumn.FixedWidth = true;
            this.colTargetCount.OptionsColumn.ReadOnly = true;
            this.colTargetCount.Visible = true;
            this.colTargetCount.Width = 100;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 500;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // FrmNewRecipeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 295);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewRecipeViewer";
            this.Text = "New Recipe Alarm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewRecipeViewer_FormClosed);
            this.Load += new System.EventHandler(this.FrmNewRecipeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnlBackground;
        private DevExpress.XtraEditors.LabelControl lblText;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Timer tmrTimer;
        private DevExpress.XtraGrid.GridControl grdRecipe;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvRecipe;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbInfo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGroupKey;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRecipe;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCurrentCount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTargetCount;
    }
}