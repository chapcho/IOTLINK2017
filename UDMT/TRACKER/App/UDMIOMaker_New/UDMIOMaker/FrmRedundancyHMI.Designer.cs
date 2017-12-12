namespace UDMIOMaker
{
    partial class FrmRedundancyHMI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRedundancyHMI));
            this.grdHMI = new DevExpress.XtraGrid.GridControl();
            this.grvHMI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConvert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRedundancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdHMI
            // 
            this.grdHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHMI.Location = new System.Drawing.Point(0, 0);
            this.grdHMI.LookAndFeel.SkinName = "Metropolis";
            this.grdHMI.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdHMI.MainView = this.grvHMI;
            this.grdHMI.Name = "grdHMI";
            this.grdHMI.Size = new System.Drawing.Size(684, 300);
            this.grdHMI.TabIndex = 16;
            this.grdHMI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHMI});
            // 
            // grvHMI
            // 
            this.grvHMI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colGroup,
            this.colHMIName,
            this.colHMIDataType,
            this.colHMIAddress,
            this.colHMIDesc,
            this.colMatch,
            this.colInsert,
            this.colConvert,
            this.colRedundancy});
            this.grvHMI.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHMI.GridControl = this.grdHMI;
            this.grvHMI.IndicatorWidth = 60;
            this.grvHMI.Name = "grvHMI";
            this.grvHMI.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvHMI.OptionsDetail.EnableMasterViewMode = false;
            this.grvHMI.OptionsDetail.SmartDetailExpand = false;
            this.grvHMI.OptionsSelection.MultiSelect = true;
            this.grvHMI.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvHMI.OptionsView.ShowGroupPanel = false;
            this.grvHMI.OptionsView.ShowIndicator = false;
            this.grvHMI.RowHeight = 30;
            this.grvHMI.DoubleClick += new System.EventHandler(this.grvHMI_DoubleClick);
            // 
            // colNumber
            // 
            this.colNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.Caption = "#번호";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "그룹";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            // 
            // colHMIName
            // 
            this.colHMIName.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIName.Caption = "이름";
            this.colHMIName.FieldName = "Name";
            this.colHMIName.Name = "colHMIName";
            this.colHMIName.OptionsColumn.AllowEdit = false;
            this.colHMIName.Visible = true;
            this.colHMIName.VisibleIndex = 1;
            // 
            // colHMIDataType
            // 
            this.colHMIDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colHMIDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDataType.Caption = "DataType";
            this.colHMIDataType.FieldName = "DataType";
            this.colHMIDataType.Name = "colHMIDataType";
            this.colHMIDataType.OptionsColumn.AllowEdit = false;
            this.colHMIDataType.Visible = true;
            this.colHMIDataType.VisibleIndex = 2;
            // 
            // colHMIAddress
            // 
            this.colHMIAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colHMIAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIAddress.Caption = "Address";
            this.colHMIAddress.FieldName = "Address";
            this.colHMIAddress.Name = "colHMIAddress";
            this.colHMIAddress.OptionsColumn.AllowEdit = false;
            this.colHMIAddress.Visible = true;
            this.colHMIAddress.VisibleIndex = 3;
            // 
            // colHMIDesc
            // 
            this.colHMIDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDesc.Caption = "Description";
            this.colHMIDesc.FieldName = "Description";
            this.colHMIDesc.Name = "colHMIDesc";
            this.colHMIDesc.OptionsColumn.AllowEdit = false;
            this.colHMIDesc.Visible = true;
            this.colHMIDesc.VisibleIndex = 4;
            // 
            // colMatch
            // 
            this.colMatch.Caption = "Is Match";
            this.colMatch.FieldName = "IsMatch";
            this.colMatch.Name = "colMatch";
            this.colMatch.OptionsColumn.AllowEdit = false;
            // 
            // colInsert
            // 
            this.colInsert.Caption = "Is Insert";
            this.colInsert.FieldName = "IsInsert";
            this.colInsert.Name = "colInsert";
            this.colInsert.OptionsColumn.AllowEdit = false;
            // 
            // colConvert
            // 
            this.colConvert.Caption = "Is Convert";
            this.colConvert.FieldName = "IsConvert";
            this.colConvert.Name = "colConvert";
            this.colConvert.OptionsColumn.AllowEdit = false;
            // 
            // colRedundancy
            // 
            this.colRedundancy.Caption = "Is Redundancy";
            this.colRedundancy.FieldName = "IsRedundancy";
            this.colRedundancy.Name = "colRedundancy";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 300);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(684, 47);
            this.panelControl2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(602, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 47);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmRedundancyHMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 347);
            this.Controls.Add(this.grdHMI);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRedundancyHMI";
            this.Text = "중복된 매핑된 HMI 태그 리스트";
            this.Load += new System.EventHandler(this.FrmRedundancyHMI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdHMI;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHMI;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIName;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colMatch;
        private DevExpress.XtraGrid.Columns.GridColumn colInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colConvert;
        private DevExpress.XtraGrid.Columns.GridColumn colRedundancy;
        private DevExpress.XtraEditors.SimpleButton btnClose;

    }
}