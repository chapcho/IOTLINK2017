namespace FTOPApp
{
    partial class UCPLCRegister
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
            DevExpress.XtraSplashScreen.SplashScreenManager ClientScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true, typeof(System.Windows.Forms.UserControl));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPLCRegister));
            this.GridGroup = new DevExpress.XtraEditors.GroupControl();
            this.exGrid = new DevExpress.XtraGrid.GridControl();
            this.exGrdiVeiw = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConvert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRedundancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Corperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistedMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridGroup)).BeginInit();
            this.GridGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdiVeiw)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientScreen
            // 
            ClientScreen.ClosingDelay = 500;
            // 
            // GridGroup
            // 
            this.GridGroup.Controls.Add(this.exGrid);
            this.GridGroup.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Tag Register", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("RUN", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons1")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("STOP", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons2")))),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("DCOM", ((System.Drawing.Image)(resources.GetObject("GridGroup.CustomHeaderButtons3"))))});
            this.GridGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridGroup.Location = new System.Drawing.Point(0, 0);
            this.GridGroup.Name = "GridGroup";
            this.GridGroup.Size = new System.Drawing.Size(542, 558);
            this.GridGroup.TabIndex = 3;
            // 
            // exGrid
            // 
            this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrid.Location = new System.Drawing.Point(2, 45);
            this.exGrid.LookAndFeel.SkinName = "Metropolis";
            this.exGrid.MainView = this.exGrdiVeiw;
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(538, 511);
            this.exGrid.TabIndex = 16;
            this.exGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGrdiVeiw});
            // 
            // exGrdiVeiw
            // 
            this.exGrdiVeiw.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.exGrdiVeiw.Appearance.GroupPanel.ForeColor = System.Drawing.Color.SteelBlue;
            this.exGrdiVeiw.Appearance.GroupPanel.Options.UseFont = true;
            this.exGrdiVeiw.Appearance.GroupPanel.Options.UseForeColor = true;
            this.exGrdiVeiw.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.exGrdiVeiw.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.exGrdiVeiw.Appearance.SelectedRow.Options.UseBackColor = true;
            this.exGrdiVeiw.Appearance.SelectedRow.Options.UseForeColor = true;
            this.exGrdiVeiw.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colPLC,
            this.colAddress,
            this.colTarget,
            this.colDataType,
            this.colMatch,
            this.colInsert,
            this.colConvert,
            this.colRedundancy,
            this.Corperation,
            this.colEdit,
            this.colExistedMatch});
            this.exGrdiVeiw.GridControl = this.exGrid;
            this.exGrdiVeiw.GroupCount = 2;
            this.exGrdiVeiw.IndicatorWidth = 60;
            this.exGrdiVeiw.Name = "exGrdiVeiw";
            this.exGrdiVeiw.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exGrdiVeiw.OptionsDetail.EnableMasterViewMode = false;
            this.exGrdiVeiw.OptionsDetail.SmartDetailExpand = false;
            this.exGrdiVeiw.OptionsFind.AlwaysVisible = true;
            this.exGrdiVeiw.OptionsSelection.MultiSelect = true;
            this.exGrdiVeiw.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGrdiVeiw.OptionsView.ShowAutoFilterRow = true;
            this.exGrdiVeiw.OptionsView.ShowIndicator = false;
            this.exGrdiVeiw.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Corperation, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPLC, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.colNumber.OptionsColumn.FixedWidth = true;
            this.colNumber.Width = 70;
            // 
            // colPLC
            // 
            this.colPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.Caption = "LINE";
            this.colPLC.FieldName = "OPCChannel";
            this.colPLC.Name = "colPLC";
            this.colPLC.OptionsColumn.AllowEdit = false;
            this.colPLC.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPLC.OptionsColumn.FixedWidth = true;
            this.colPLC.Visible = true;
            this.colPLC.VisibleIndex = 0;
            this.colPLC.Width = 101;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "PLCAddress";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 265;
            // 
            // colTarget
            // 
            this.colTarget.AppearanceCell.Options.UseTextOptions = true;
            this.colTarget.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarget.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarget.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarget.Caption = "전송 대상";
            this.colTarget.FieldName = "SendTarget";
            this.colTarget.Name = "colTarget";
            this.colTarget.OptionsColumn.AllowEdit = false;
            this.colTarget.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTarget.OptionsColumn.FixedWidth = true;
            this.colTarget.Visible = true;
            this.colTarget.VisibleIndex = 0;
            this.colTarget.Width = 154;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DatType";
            this.colDataType.FieldName = "PLCDataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 1;
            this.colDataType.Width = 119;
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
            // Corperation
            // 
            this.Corperation.AppearanceCell.Options.UseTextOptions = true;
            this.Corperation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Corperation.AppearanceHeader.Options.UseTextOptions = true;
            this.Corperation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Corperation.Caption = "Corporation";
            this.Corperation.FieldName = "CORP_CD";
            this.Corperation.Name = "Corperation";
            this.Corperation.OptionsColumn.AllowEdit = false;
            this.Corperation.Visible = true;
            this.Corperation.VisibleIndex = 0;
            this.Corperation.Width = 121;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Is Edit";
            this.colEdit.FieldName = "IsEdit";
            this.colEdit.Name = "colEdit";
            // 
            // colExistedMatch
            // 
            this.colExistedMatch.Caption = "ExistedMatch";
            this.colExistedMatch.FieldName = "IsExistedMatch";
            this.colExistedMatch.Name = "colExistedMatch";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Address";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 111;
            // 
            // UCPLCRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridGroup);
            this.Name = "UCPLCRegister";
            this.Size = new System.Drawing.Size(542, 558);
            ((System.ComponentModel.ISupportInitialize)(this.GridGroup)).EndInit();
            this.GridGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGrdiVeiw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GridGroup;
        private DevExpress.XtraGrid.GridControl exGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView exGrdiVeiw;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTarget;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colMatch;
        private DevExpress.XtraGrid.Columns.GridColumn colInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colConvert;
        private DevExpress.XtraGrid.Columns.GridColumn colRedundancy;
        private DevExpress.XtraGrid.Columns.GridColumn Corperation;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colExistedMatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;


    }
}
