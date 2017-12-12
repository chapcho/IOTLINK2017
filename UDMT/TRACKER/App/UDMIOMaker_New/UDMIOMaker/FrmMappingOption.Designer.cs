namespace UDMIOMaker
{
    partial class FrmMappingOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMappingOption));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdConvertUnit = new DevExpress.XtraGrid.GridControl();
            this.grvConvertUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUnitAdd = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSetting = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnItemDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnItemUp = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grpgroupName = new System.Windows.Forms.GroupBox();
            this.cboGroupList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportSetting = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportSetting = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConvertUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConvertUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).BeginInit();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.grpgroupName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGroupList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.grdConvertUnit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 56);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(567, 419);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "문자열 변환 설정";
            // 
            // grdConvertUnit
            // 
            this.grdConvertUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConvertUnit.Location = new System.Drawing.Point(2, 21);
            this.grdConvertUnit.LookAndFeel.SkinName = "Metropolis";
            this.grdConvertUnit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdConvertUnit.MainView = this.grvConvertUnit;
            this.grdConvertUnit.Name = "grdConvertUnit";
            this.grdConvertUnit.Size = new System.Drawing.Size(563, 396);
            this.grdConvertUnit.TabIndex = 10;
            this.grdConvertUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvConvertUnit});
            // 
            // grvConvertUnit
            // 
            this.grvConvertUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrent,
            this.colTarget});
            this.grvConvertUnit.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvConvertUnit.GridControl = this.grdConvertUnit;
            this.grvConvertUnit.GroupPanelText = "숫자 표현은 #로 표시 (R01 → R##)";
            this.grvConvertUnit.IndicatorWidth = 60;
            this.grvConvertUnit.Name = "grvConvertUnit";
            this.grvConvertUnit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvConvertUnit.OptionsDetail.EnableMasterViewMode = false;
            this.grvConvertUnit.OptionsDetail.SmartDetailExpand = false;
            this.grvConvertUnit.OptionsSelection.MultiSelect = true;
            this.grvConvertUnit.OptionsView.ShowIndicator = false;
            // 
            // colCurrent
            // 
            this.colCurrent.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCurrent.AppearanceHeader.Options.UseFont = true;
            this.colCurrent.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrent.Caption = "Current";
            this.colCurrent.FieldName = "Current";
            this.colCurrent.Name = "colCurrent";
            this.colCurrent.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCurrent.OptionsColumn.AllowMove = false;
            this.colCurrent.Visible = true;
            this.colCurrent.VisibleIndex = 0;
            // 
            // colTarget
            // 
            this.colTarget.AppearanceCell.Options.UseTextOptions = true;
            this.colTarget.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarget.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTarget.AppearanceHeader.Options.UseFont = true;
            this.colTarget.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarget.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarget.Caption = "Target";
            this.colTarget.FieldName = "Target";
            this.colTarget.Name = "colTarget";
            this.colTarget.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTarget.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTarget.OptionsColumn.AllowMove = false;
            this.colTarget.Visible = true;
            this.colTarget.VisibleIndex = 1;
            // 
            // btnUnitAdd
            // 
            this.btnUnitAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnUnitAdd.Appearance.Options.UseBackColor = true;
            this.btnUnitAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUnitAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUnitAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitAdd.Image")));
            this.btnUnitAdd.Location = new System.Drawing.Point(170, 0);
            this.btnUnitAdd.Name = "btnUnitAdd";
            this.btnUnitAdd.Size = new System.Drawing.Size(85, 55);
            this.btnUnitAdd.TabIndex = 11;
            this.btnUnitAdd.Text = "추가";
            this.btnUnitAdd.Click += new System.EventHandler(this.btnUnitAdd_Click);
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
            this.pnlSetting.Controls.Add(this.btnItemDown);
            this.pnlSetting.Controls.Add(this.btnItemUp);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSetting.Location = new System.Drawing.Point(0, 475);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(567, 55);
            this.pnlSetting.TabIndex = 12;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(255, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 55);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "제거";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Appearance.BackColor = System.Drawing.Color.White;
            this.btnItemDown.Appearance.Options.UseBackColor = true;
            this.btnItemDown.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnItemDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnItemDown.Image = ((System.Drawing.Image)(resources.GetObject("btnItemDown.Image")));
            this.btnItemDown.Location = new System.Drawing.Point(85, 0);
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.Size = new System.Drawing.Size(85, 55);
            this.btnItemDown.TabIndex = 15;
            this.btnItemDown.Text = "Down";
            this.btnItemDown.Click += new System.EventHandler(this.btnItemDown_Click);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Appearance.BackColor = System.Drawing.Color.White;
            this.btnItemUp.Appearance.Options.UseBackColor = true;
            this.btnItemUp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnItemUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnItemUp.Image = ((System.Drawing.Image)(resources.GetObject("btnItemUp.Image")));
            this.btnItemUp.Location = new System.Drawing.Point(0, 0);
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.Size = new System.Drawing.Size(85, 55);
            this.btnItemUp.TabIndex = 14;
            this.btnItemUp.Text = "Up";
            this.btnItemUp.Click += new System.EventHandler(this.btnItemUp_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.grpgroupName);
            this.panelControl2.Controls.Add(this.btnImportSetting);
            this.panelControl2.Controls.Add(this.btnExportSetting);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(567, 56);
            this.panelControl2.TabIndex = 14;
            // 
            // grpgroupName
            // 
            this.grpgroupName.Controls.Add(this.cboGroupList);
            this.grpgroupName.Controls.Add(this.labelControl1);
            this.grpgroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpgroupName.Location = new System.Drawing.Point(0, 0);
            this.grpgroupName.Name = "grpgroupName";
            this.grpgroupName.Size = new System.Drawing.Size(375, 56);
            this.grpgroupName.TabIndex = 14;
            this.grpgroupName.TabStop = false;
            this.grpgroupName.Text = "HMI 태그 그룹";
            // 
            // cboGroupList
            // 
            this.cboGroupList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboGroupList.EditValue = "";
            this.cboGroupList.Location = new System.Drawing.Point(54, 20);
            this.cboGroupList.Name = "cboGroupList";
            this.cboGroupList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.cboGroupList.Properties.Appearance.Options.UseFont = true;
            this.cboGroupList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGroupList.Size = new System.Drawing.Size(304, 26);
            this.cboGroupList.TabIndex = 1;
            this.cboGroupList.SelectedValueChanged += new System.EventHandler(this.cboGroupList_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(3, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 35);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "그룹 : ";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(393, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 55);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(480, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 55);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnImportSetting
            // 
            this.btnImportSetting.Appearance.BackColor = System.Drawing.Color.White;
            this.btnImportSetting.Appearance.Options.UseBackColor = true;
            this.btnImportSetting.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnImportSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImportSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnImportSetting.Image")));
            this.btnImportSetting.Location = new System.Drawing.Point(375, 0);
            this.btnImportSetting.Name = "btnImportSetting";
            this.btnImportSetting.Size = new System.Drawing.Size(96, 56);
            this.btnImportSetting.TabIndex = 23;
            this.btnImportSetting.Text = "Setting\r\nImport";
            this.btnImportSetting.Click += new System.EventHandler(this.btnImportSetting_Click);
            // 
            // btnExportSetting
            // 
            this.btnExportSetting.Appearance.BackColor = System.Drawing.Color.White;
            this.btnExportSetting.Appearance.Options.UseBackColor = true;
            this.btnExportSetting.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExportSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnExportSetting.Image")));
            this.btnExportSetting.Location = new System.Drawing.Point(471, 0);
            this.btnExportSetting.Name = "btnExportSetting";
            this.btnExportSetting.Size = new System.Drawing.Size(96, 56);
            this.btnExportSetting.TabIndex = 22;
            this.btnExportSetting.Text = "Setting\r\nExport";
            this.btnExportSetting.Click += new System.EventHandler(this.btnExportSetting_Click);
            // 
            // FrmMappingOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 530);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.pnlSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMappingOption";
            this.Text = "매핑 옵션 세팅";
            this.Load += new System.EventHandler(this.FrmMappingOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConvertUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConvertUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSetting)).EndInit();
            this.pnlSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.grpgroupName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboGroupList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdConvertUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView grvConvertUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrent;
        private DevExpress.XtraGrid.Columns.GridColumn colTarget;
        private DevExpress.XtraEditors.SimpleButton btnUnitAdd;
        private DevExpress.XtraEditors.PanelControl pnlSetting;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnItemDown;
        private DevExpress.XtraEditors.SimpleButton btnItemUp;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.GroupBox grpgroupName;
        private DevExpress.XtraEditors.ComboBoxEdit cboGroupList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnImportSetting;
        private DevExpress.XtraEditors.SimpleButton btnExportSetting;
    }
}