namespace UDMIOMaker
{
    partial class FrmStdSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStdSetting));
            this.grdStd = new DevExpress.XtraGrid.GridControl();
            this.grvStd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnLibraryAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdStd
            // 
            this.grdStd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStd.Location = new System.Drawing.Point(0, 0);
            this.grdStd.MainView = this.grvStd;
            this.grdStd.Name = "grdStd";
            this.grdStd.Size = new System.Drawing.Size(617, 577);
            this.grdStd.TabIndex = 1;
            this.grdStd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStd});
            // 
            // grvStd
            // 
            this.grvStd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOldName,
            this.colStandardName,
            this.colDescription});
            this.grvStd.GridControl = this.grdStd;
            this.grvStd.IndicatorWidth = 40;
            this.grvStd.Name = "grvStd";
            this.grvStd.OptionsDetail.AllowZoomDetail = false;
            this.grvStd.OptionsDetail.EnableMasterViewMode = false;
            this.grvStd.OptionsDetail.SmartDetailExpand = false;
            this.grvStd.OptionsView.AllowCellMerge = true;
            this.grvStd.OptionsView.ShowAutoFilterRow = true;
            this.grvStd.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStd_CustomDrawRowIndicator);
            // 
            // colOldName
            // 
            this.colOldName.AppearanceCell.Options.UseTextOptions = true;
            this.colOldName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOldName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOldName.AppearanceHeader.Options.UseFont = true;
            this.colOldName.AppearanceHeader.Options.UseTextOptions = true;
            this.colOldName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOldName.Caption = "기존 이름";
            this.colOldName.FieldName = "CurrentName";
            this.colOldName.Name = "colOldName";
            this.colOldName.Visible = true;
            this.colOldName.VisibleIndex = 0;
            // 
            // colStandardName
            // 
            this.colStandardName.AppearanceCell.Options.UseTextOptions = true;
            this.colStandardName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStandardName.AppearanceHeader.Options.UseFont = true;
            this.colStandardName.AppearanceHeader.Options.UseTextOptions = true;
            this.colStandardName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardName.Caption = "표준 이름";
            this.colStandardName.FieldName = "TargetName";
            this.colStandardName.Name = "colStandardName";
            this.colStandardName.Visible = true;
            this.colStandardName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "설명";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnApply);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnLibraryAdd);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 577);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(617, 50);
            this.panelControl1.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(449, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 50);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(85, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 50);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "제거";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLibraryAdd
            // 
            this.btnLibraryAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnLibraryAdd.Appearance.Options.UseBackColor = true;
            this.btnLibraryAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLibraryAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLibraryAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryAdd.Image")));
            this.btnLibraryAdd.Location = new System.Drawing.Point(0, 0);
            this.btnLibraryAdd.Name = "btnLibraryAdd";
            this.btnLibraryAdd.Size = new System.Drawing.Size(85, 50);
            this.btnLibraryAdd.TabIndex = 18;
            this.btnLibraryAdd.Text = "추가";
            this.btnLibraryAdd.Click += new System.EventHandler(this.btnLibraryAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(536, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 50);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApply.Appearance.Options.UseBackColor = true;
            this.btnApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(170, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(129, 50);
            this.btnApply.TabIndex = 21;
            this.btnApply.Text = "추가한 내용\r\n적용하기";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FrmStdSetting
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 627);
            this.Controls.Add(this.grdStd);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStdSetting";
            this.Text = "심볼 표준 라이브러리";
            this.Load += new System.EventHandler(this.FrmStdSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStd;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnLibraryAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colOldName;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.SimpleButton btnApply;
    }
}