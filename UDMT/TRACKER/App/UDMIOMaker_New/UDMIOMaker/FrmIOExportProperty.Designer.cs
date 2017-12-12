namespace UDMIOMaker
{
    partial class FrmIOExportProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIOExportProperty));
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTypeList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAreaInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkExtendExport = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grdAddressType = new DevExpress.XtraGrid.GridControl();
            this.grvAddressType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddressType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddressStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddressEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtExportMaxArea = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExtendExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportMaxArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPLCList
            // 
            this.cboPLCList.Location = new System.Drawing.Point(12, 32);
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCList.Size = new System.Drawing.Size(322, 20);
            this.cboPLCList.TabIndex = 6;
            this.cboPLCList.SelectedIndexChanged += new System.EventHandler(this.cboPLCList_SelectedIndexChanged);
            this.cboPLCList.SelectedValueChanged += new System.EventHandler(this.cboPLCList_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "PLC List ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(12, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Type List ";
            // 
            // cboTypeList
            // 
            this.cboTypeList.Location = new System.Drawing.Point(12, 78);
            this.cboTypeList.Name = "cboTypeList";
            this.cboTypeList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTypeList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTypeList.Size = new System.Drawing.Size(322, 20);
            this.cboTypeList.TabIndex = 8;
            this.cboTypeList.SelectedIndexChanged += new System.EventHandler(this.cboTypeList_SelectedIndexChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnAreaInfo);
            this.panelControl2.Controls.Add(this.btnExport);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 350);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(346, 48);
            this.panelControl2.TabIndex = 10;
            // 
            // btnAreaInfo
            // 
            this.btnAreaInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAreaInfo.Appearance.Options.UseBackColor = true;
            this.btnAreaInfo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAreaInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAreaInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnAreaInfo.Image")));
            this.btnAreaInfo.Location = new System.Drawing.Point(0, 0);
            this.btnAreaInfo.Name = "btnAreaInfo";
            this.btnAreaInfo.Size = new System.Drawing.Size(98, 48);
            this.btnAreaInfo.TabIndex = 14;
            this.btnAreaInfo.Text = "영역 정보\r\n확인";
            this.btnAreaInfo.Click += new System.EventHandler(this.btnAreaInfo_Click);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(157, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 48);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "내보내기";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(265, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 48);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "취소";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkExtendExport
            // 
            this.chkExtendExport.Location = new System.Drawing.Point(12, 287);
            this.chkExtendExport.Name = "chkExtendExport";
            this.chkExtendExport.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkExtendExport.Properties.Appearance.Options.UseFont = true;
            this.chkExtendExport.Properties.Caption = "최대 ADDRESS 영역까지 내보내기";
            this.chkExtendExport.Size = new System.Drawing.Size(234, 19);
            this.chkExtendExport.TabIndex = 11;
            this.chkExtendExport.CheckedChanged += new System.EventHandler(this.chkExtendExport_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdAddressType);
            this.panelControl1.Location = new System.Drawing.Point(12, 130);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(322, 150);
            this.panelControl1.TabIndex = 12;
            // 
            // grdAddressType
            // 
            this.grdAddressType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAddressType.Location = new System.Drawing.Point(2, 2);
            this.grdAddressType.MainView = this.grvAddressType;
            this.grdAddressType.Name = "grdAddressType";
            this.grdAddressType.Size = new System.Drawing.Size(318, 146);
            this.grdAddressType.TabIndex = 3;
            this.grdAddressType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAddressType});
            // 
            // grvAddressType
            // 
            this.grvAddressType.Appearance.SelectedRow.BackColor = System.Drawing.Color.Orange;
            this.grvAddressType.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAddressType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddressType,
            this.colAddressStart,
            this.colAddressEnd});
            this.grvAddressType.GridControl = this.grdAddressType;
            this.grvAddressType.IndicatorWidth = 40;
            this.grvAddressType.Name = "grvAddressType";
            this.grvAddressType.OptionsBehavior.Editable = false;
            this.grvAddressType.OptionsBehavior.ReadOnly = true;
            this.grvAddressType.OptionsDetail.EnableMasterViewMode = false;
            this.grvAddressType.OptionsDetail.SmartDetailExpand = false;
            this.grvAddressType.OptionsSelection.MultiSelect = true;
            this.grvAddressType.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvAddressType.OptionsView.ShowGroupPanel = false;
            this.grvAddressType.OptionsView.ShowIndicator = false;
            // 
            // colAddressType
            // 
            this.colAddressType.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colAddressType.AppearanceCell.Options.UseBackColor = true;
            this.colAddressType.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressType.AppearanceHeader.Options.UseFont = true;
            this.colAddressType.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressType.Caption = "Type";
            this.colAddressType.FieldName = "BlockName";
            this.colAddressType.MaxWidth = 70;
            this.colAddressType.MinWidth = 70;
            this.colAddressType.Name = "colAddressType";
            this.colAddressType.OptionsColumn.AllowEdit = false;
            this.colAddressType.OptionsColumn.AllowMove = false;
            this.colAddressType.OptionsColumn.ReadOnly = true;
            this.colAddressType.Visible = true;
            this.colAddressType.VisibleIndex = 0;
            this.colAddressType.Width = 70;
            // 
            // colAddressStart
            // 
            this.colAddressStart.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colAddressStart.AppearanceCell.Options.UseBackColor = true;
            this.colAddressStart.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressStart.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressStart.AppearanceHeader.Options.UseFont = true;
            this.colAddressStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressStart.Caption = "START";
            this.colAddressStart.FieldName = "StartAddress";
            this.colAddressStart.Name = "colAddressStart";
            this.colAddressStart.OptionsColumn.AllowEdit = false;
            this.colAddressStart.OptionsColumn.AllowMove = false;
            this.colAddressStart.OptionsColumn.ReadOnly = true;
            this.colAddressStart.Visible = true;
            this.colAddressStart.VisibleIndex = 1;
            this.colAddressStart.Width = 125;
            // 
            // colAddressEnd
            // 
            this.colAddressEnd.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colAddressEnd.AppearanceCell.Options.UseBackColor = true;
            this.colAddressEnd.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressEnd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressEnd.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressEnd.AppearanceHeader.Options.UseFont = true;
            this.colAddressEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressEnd.Caption = "END";
            this.colAddressEnd.FieldName = "EndAddress";
            this.colAddressEnd.Name = "colAddressEnd";
            this.colAddressEnd.OptionsColumn.AllowEdit = false;
            this.colAddressEnd.OptionsColumn.AllowMove = false;
            this.colAddressEnd.OptionsColumn.ReadOnly = true;
            this.colAddressEnd.Visible = true;
            this.colAddressEnd.VisibleIndex = 2;
            this.colAddressEnd.Width = 128;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(12, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "사용 중인 영역 ";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(12, 320);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(142, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "현재 내보내기 최대 영역";
            // 
            // txtExportMaxArea
            // 
            this.txtExportMaxArea.Location = new System.Drawing.Point(160, 317);
            this.txtExportMaxArea.Name = "txtExportMaxArea";
            this.txtExportMaxArea.Properties.ReadOnly = true;
            this.txtExportMaxArea.Size = new System.Drawing.Size(172, 20);
            this.txtExportMaxArea.TabIndex = 15;
            // 
            // FrmIOExportProperty
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 398);
            this.Controls.Add(this.chkExtendExport);
            this.Controls.Add(this.txtExportMaxArea);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.cboTypeList);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboPLCList);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIOExportProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IO/DUMMY List 내보내기";
            this.Load += new System.EventHandler(this.FrmIOExportProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExtendExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExportMaxArea.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTypeList;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnAreaInfo;
        private DevExpress.XtraEditors.CheckEdit chkExtendExport;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl grdAddressType;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAddressType;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressType;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressStart;
        private DevExpress.XtraGrid.Columns.GridColumn colAddressEnd;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtExportMaxArea;
    }
}