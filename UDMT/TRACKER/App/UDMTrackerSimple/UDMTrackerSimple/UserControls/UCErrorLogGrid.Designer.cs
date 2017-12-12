namespace UDMTrackerSimple.UserControls
{
    partial class UCErrorLogGrid
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
            this.grdError = new DevExpress.XtraGrid.GridControl();
            this.grvError = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colErrorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorSolution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaintTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailErrorMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdRawData = new DevExpress.XtraGrid.GridControl();
            this.grvRawData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRawData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRawData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdError
            // 
            this.grdError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdError.Location = new System.Drawing.Point(0, 0);
            this.grdError.MainView = this.grvError;
            this.grdError.Name = "grdError";
            this.grdError.Size = new System.Drawing.Size(733, 521);
            this.grdError.TabIndex = 0;
            this.grdError.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvError});
            // 
            // grvError
            // 
            this.grvError.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvError.Appearance.GroupPanel.Options.UseFont = true;
            this.grvError.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvError.Appearance.Row.Options.UseFont = true;
            this.grvError.ColumnPanelRowHeight = 45;
            this.grvError.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErrorID,
            this.colTime,
            this.colGroupKey,
            this.colErrorMessage,
            this.colErrorCategory,
            this.colErrorSolution,
            this.colMaintTime,
            this.colAddress,
            this.colDetailErrorMessage});
            this.grvError.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvError.GridControl = this.grdError;
            this.grvError.GroupCount = 1;
            this.grvError.Name = "grvError";
            this.grvError.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvError.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvError.OptionsBehavior.Editable = false;
            this.grvError.OptionsBehavior.ReadOnly = true;
            this.grvError.OptionsDetail.AllowZoomDetail = false;
            this.grvError.OptionsDetail.EnableMasterViewMode = false;
            this.grvError.OptionsDetail.ShowDetailTabs = false;
            this.grvError.OptionsDetail.SmartDetailExpand = false;
            this.grvError.OptionsSelection.MultiSelect = true;
            this.grvError.OptionsView.AllowCellMerge = true;
            this.grvError.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grvError.OptionsView.ShowAutoFilterRow = true;
            this.grvError.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvError.OptionsView.ShowGroupedColumns = true;
            this.grvError.OptionsView.ShowGroupPanel = false;
            this.grvError.OptionsView.ShowIndicator = false;
            this.grvError.RowHeight = 40;
            this.grvError.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvError.DoubleClick += new System.EventHandler(this.grvError_DoubleClick);
            // 
            // colErrorID
            // 
            this.colErrorID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorID.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorID.AppearanceHeader.Options.UseFont = true;
            this.colErrorID.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorID.Caption = "ID";
            this.colErrorID.FieldName = "ErrorID";
            this.colErrorID.Name = "colErrorID";
            this.colErrorID.OptionsColumn.FixedWidth = true;
            this.colErrorID.OptionsColumn.ReadOnly = true;
            this.colErrorID.Width = 55;
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceHeader.Options.UseFont = true;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTime.FieldName = "ErrorTime";
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.FixedWidth = true;
            this.colTime.OptionsColumn.ReadOnly = true;
            this.colTime.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 1;
            this.colTime.Width = 132;
            // 
            // colGroupKey
            // 
            this.colGroupKey.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroupKey.AppearanceHeader.Options.UseFont = true;
            this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.Caption = "Group";
            this.colGroupKey.FieldName = "GroupKey";
            this.colGroupKey.Name = "colGroupKey";
            this.colGroupKey.OptionsColumn.FixedWidth = true;
            this.colGroupKey.OptionsColumn.ReadOnly = true;
            this.colGroupKey.Visible = true;
            this.colGroupKey.VisibleIndex = 0;
            this.colGroupKey.Width = 115;
            // 
            // colErrorMessage
            // 
            this.colErrorMessage.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorMessage.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorMessage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorMessage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorMessage.AppearanceHeader.Options.UseFont = true;
            this.colErrorMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorMessage.Caption = "Error Message";
            this.colErrorMessage.FieldName = "ErrorMessage";
            this.colErrorMessage.Name = "colErrorMessage";
            this.colErrorMessage.OptionsColumn.FixedWidth = true;
            this.colErrorMessage.OptionsColumn.ReadOnly = true;
            this.colErrorMessage.Visible = true;
            this.colErrorMessage.VisibleIndex = 2;
            this.colErrorMessage.Width = 250;
            // 
            // colErrorCategory
            // 
            this.colErrorCategory.Caption = "Error Category";
            this.colErrorCategory.FieldName = "ErrorCategory";
            this.colErrorCategory.Name = "colErrorCategory";
            this.colErrorCategory.OptionsColumn.ReadOnly = true;
            // 
            // colErrorSolution
            // 
            this.colErrorSolution.Caption = "Error Solution";
            this.colErrorSolution.FieldName = "ErrorSolution";
            this.colErrorSolution.Name = "colErrorSolution";
            this.colErrorSolution.OptionsColumn.ReadOnly = true;
            // 
            // colMaintTime
            // 
            this.colMaintTime.Caption = "Maintenance Time";
            this.colMaintTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.colMaintTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMaintTime.FieldName = "MaintTime";
            this.colMaintTime.Name = "colMaintTime";
            this.colMaintTime.OptionsColumn.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Detail Address";
            this.colAddress.FieldName = "DetailErrorAddress";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 134;
            // 
            // colDetailErrorMessage
            // 
            this.colDetailErrorMessage.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetailErrorMessage.AppearanceCell.Options.UseFont = true;
            this.colDetailErrorMessage.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailErrorMessage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDetailErrorMessage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetailErrorMessage.AppearanceHeader.Options.UseFont = true;
            this.colDetailErrorMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colDetailErrorMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDetailErrorMessage.Caption = "Detail Error Message";
            this.colDetailErrorMessage.FieldName = "DetailErrorMessage";
            this.colDetailErrorMessage.Name = "colDetailErrorMessage";
            this.colDetailErrorMessage.OptionsColumn.FixedWidth = true;
            this.colDetailErrorMessage.OptionsColumn.ReadOnly = true;
            this.colDetailErrorMessage.Visible = true;
            this.colDetailErrorMessage.VisibleIndex = 3;
            this.colDetailErrorMessage.Width = 250;
            // 
            // grdRawData
            // 
            this.grdRawData.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdRawData.Location = new System.Drawing.Point(733, 0);
            this.grdRawData.MainView = this.grvRawData;
            this.grdRawData.Name = "grdRawData";
            this.grdRawData.Size = new System.Drawing.Size(467, 521);
            this.grdRawData.TabIndex = 1;
            this.grdRawData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRawData});
            this.grdRawData.Visible = false;
            // 
            // grvRawData
            // 
            this.grvRawData.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvRawData.Appearance.GroupPanel.Options.UseFont = true;
            this.grvRawData.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvRawData.Appearance.Row.Options.UseFont = true;
            this.grvRawData.ColumnPanelRowHeight = 45;
            this.grvRawData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11});
            this.grvRawData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvRawData.GridControl = this.grdRawData;
            this.grvRawData.Name = "grvRawData";
            this.grvRawData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvRawData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvRawData.OptionsBehavior.Editable = false;
            this.grvRawData.OptionsBehavior.ReadOnly = true;
            this.grvRawData.OptionsDetail.AllowZoomDetail = false;
            this.grvRawData.OptionsDetail.EnableMasterViewMode = false;
            this.grvRawData.OptionsDetail.ShowDetailTabs = false;
            this.grvRawData.OptionsDetail.SmartDetailExpand = false;
            this.grvRawData.OptionsSelection.MultiSelect = true;
            this.grvRawData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.grvRawData.OptionsView.ShowAutoFilterRow = true;
            this.grvRawData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRawData.OptionsView.ShowGroupedColumns = true;
            this.grvRawData.OptionsView.ShowGroupPanel = false;
            this.grvRawData.OptionsView.ShowIndicator = false;
            this.grvRawData.RowHeight = 40;
            this.grvRawData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ErrorID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 55;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Time";
            this.gridColumn2.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "ErrorTime";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 132;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Group";
            this.gridColumn3.FieldName = "GroupKey";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceCell.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.Caption = "Error Type";
            this.gridColumn10.FieldName = "ErrorType";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Error Message";
            this.gridColumn4.FieldName = "ErrorMessage";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 250;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Error Category";
            this.gridColumn5.FieldName = "ErrorCategory";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Error Solution";
            this.gridColumn6.FieldName = "ErrorSolution";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Maintenance Time";
            this.gridColumn7.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "MaintTime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Detail Address";
            this.gridColumn8.FieldName = "DetailErrorAddress";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 134;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Detail Error Message";
            this.gridColumn9.FieldName = "DetailErrorMessage";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 250;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "RecoveryTime";
            this.gridColumn11.FieldName = "RecoveryTime";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            // 
            // UCErrorLogGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdError);
            this.Controls.Add(this.grdRawData);
            this.Name = "UCErrorLogGrid";
            this.Size = new System.Drawing.Size(1200, 521);
            this.Load += new System.EventHandler(this.UCErrorLogGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRawData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRawData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdError;
        private DevExpress.XtraGrid.Views.Grid.GridView grvError;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorID;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupKey;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorSolution;
        private DevExpress.XtraGrid.Columns.GridColumn colMaintTime;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailErrorMessage;
        private DevExpress.XtraGrid.GridControl grdRawData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRawData;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;

    }
}
