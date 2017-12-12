namespace UDMLadderTracker.UserControls
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
            this.pnlCauseError = new DevExpress.XtraEditors.PanelControl();
            this.ucErrorCause = new UDMLadderTracker.UCErrorCauseAnalysis();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCauseError)).BeginInit();
            this.pnlCauseError.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdError
            // 
            this.grdError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdError.Location = new System.Drawing.Point(0, 0);
            this.grdError.MainView = this.grvError;
            this.grdError.Name = "grdError";
            this.grdError.Size = new System.Drawing.Size(841, 521);
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
            // pnlCauseError
            // 
            this.pnlCauseError.Controls.Add(this.ucErrorCause);
            this.pnlCauseError.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCauseError.Location = new System.Drawing.Point(846, 0);
            this.pnlCauseError.Name = "pnlCauseError";
            this.pnlCauseError.Size = new System.Drawing.Size(317, 521);
            this.pnlCauseError.TabIndex = 1;
            this.pnlCauseError.Visible = false;
            // 
            // ucErrorCause
            // 
            this.ucErrorCause.CauseTagS = null;
            this.ucErrorCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorCause.ErrorInfo = null;
            this.ucErrorCause.Location = new System.Drawing.Point(2, 2);
            this.ucErrorCause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucErrorCause.Name = "ucErrorCause";
            this.ucErrorCause.Size = new System.Drawing.Size(313, 517);
            this.ucErrorCause.TabIndex = 0;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.sptMain.Location = new System.Drawing.Point(841, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(5, 521);
            this.sptMain.TabIndex = 2;
            this.sptMain.TabStop = false;
            this.sptMain.Visible = false;
            // 
            // UCErrorLogGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdError);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.pnlCauseError);
            this.Name = "UCErrorLogGrid";
            this.Size = new System.Drawing.Size(1163, 521);
            this.Load += new System.EventHandler(this.UCErrorLogGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCauseError)).EndInit();
            this.pnlCauseError.ResumeLayout(false);
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
        private DevExpress.XtraEditors.PanelControl pnlCauseError;
        private UCErrorCauseAnalysis ucErrorCause;
        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailErrorMessage;

    }
}
