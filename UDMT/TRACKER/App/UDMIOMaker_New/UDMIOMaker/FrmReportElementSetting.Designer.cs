namespace UDMIOMaker
{
    partial class FrmReportElementSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportElementSetting));
            this.pnlSetting = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnitAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdReportUnit = new DevExpress.XtraGrid.GridControl();
            this.grvReportUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colElement = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).BeginInit();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReportUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSetting
            // 
            this.pnlSetting.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlSetting.Appearance.Options.UseBackColor = true;
            this.pnlSetting.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSetting.Controls.Add(this.btnOK);
            this.pnlSetting.Controls.Add(this.btnClose);
            this.pnlSetting.Controls.Add(this.btnDelete);
            this.pnlSetting.Controls.Add(this.btnUnitAdd);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSetting.Location = new System.Drawing.Point(0, 309);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(395, 45);
            this.pnlSetting.TabIndex = 13;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(221, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 45);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "적용";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(308, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 45);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnDelete.Size = new System.Drawing.Size(85, 45);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "제거";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUnitAdd
            // 
            this.btnUnitAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnUnitAdd.Appearance.Options.UseBackColor = true;
            this.btnUnitAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUnitAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUnitAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitAdd.Image")));
            this.btnUnitAdd.Location = new System.Drawing.Point(0, 0);
            this.btnUnitAdd.Name = "btnUnitAdd";
            this.btnUnitAdd.Size = new System.Drawing.Size(85, 45);
            this.btnUnitAdd.TabIndex = 11;
            this.btnUnitAdd.Text = "추가";
            this.btnUnitAdd.Click += new System.EventHandler(this.btnUnitAdd_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.grdReportUnit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(395, 309);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "리포트 항목";
            // 
            // grdReportUnit
            // 
            this.grdReportUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReportUnit.Location = new System.Drawing.Point(2, 21);
            this.grdReportUnit.LookAndFeel.SkinName = "Metropolis";
            this.grdReportUnit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdReportUnit.MainView = this.grvReportUnit;
            this.grdReportUnit.Name = "grdReportUnit";
            this.grdReportUnit.Size = new System.Drawing.Size(391, 286);
            this.grdReportUnit.TabIndex = 10;
            this.grdReportUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReportUnit});
            // 
            // grvReportUnit
            // 
            this.grvReportUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colElement});
            this.grvReportUnit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvReportUnit.GridControl = this.grdReportUnit;
            this.grvReportUnit.GroupPanelText = "PLC 태그에 포함된 단어를 Space bar로 구분하여 입력해주세요.";
            this.grvReportUnit.IndicatorWidth = 60;
            this.grvReportUnit.Name = "grvReportUnit";
            this.grvReportUnit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvReportUnit.OptionsDetail.EnableMasterViewMode = false;
            this.grvReportUnit.OptionsDetail.SmartDetailExpand = false;
            this.grvReportUnit.OptionsSelection.MultiSelect = true;
            this.grvReportUnit.OptionsView.ShowIndicator = false;
            // 
            // colElement
            // 
            this.colElement.AppearanceCell.Options.UseTextOptions = true;
            this.colElement.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colElement.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colElement.AppearanceHeader.Options.UseFont = true;
            this.colElement.AppearanceHeader.Options.UseTextOptions = true;
            this.colElement.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colElement.Caption = "Report Element";
            this.colElement.FieldName = "Element";
            this.colElement.Name = "colElement";
            this.colElement.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colElement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colElement.OptionsColumn.AllowMove = false;
            this.colElement.Visible = true;
            this.colElement.VisibleIndex = 0;
            // 
            // FrmReportElementSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 354);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pnlSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportElementSetting";
            this.Text = "리포트 항목 설정";
            this.Load += new System.EventHandler(this.FrmReportElementSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).EndInit();
            this.pnlSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReportUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReportUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlSetting;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnUnitAdd;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdReportUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReportUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colElement;
    }
}