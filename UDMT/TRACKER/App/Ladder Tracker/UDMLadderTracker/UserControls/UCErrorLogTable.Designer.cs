namespace UDMLadderTracker
{
    partial class UCErrorLogTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCErrorLogTable));
            this.pnlGridView = new DevExpress.XtraEditors.PanelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpDetail = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucErrorReport = new UDMLadderTracker.UCErrorReport();
            this.tpErrorList = new DevExpress.XtraTab.XtraTabPage();
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
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDateNow = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.radioMonthly = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioWeekly = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioDaily = new System.Windows.Forms.RadioButton();
            this.dateEditMin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditMax = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridView)).BeginInit();
            this.pnlGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tpErrorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            this.panel52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMax.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMax.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGridView
            // 
            this.pnlGridView.Controls.Add(this.tabMain);
            this.pnlGridView.Controls.Add(this.grpControl);
            this.pnlGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridView.Location = new System.Drawing.Point(0, 0);
            this.pnlGridView.Name = "pnlGridView";
            this.pnlGridView.Size = new System.Drawing.Size(972, 580);
            this.pnlGridView.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(2, 105);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpDetail;
            this.tabMain.Size = new System.Drawing.Size(968, 473);
            this.tabMain.TabIndex = 3;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpErrorList,
            this.tpDetail});
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.groupControl1);
            this.tpDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(962, 439);
            this.tpDetail.Text = "Process Detail";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.ucErrorReport);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(962, 439);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Error Report";
            // 
            // ucErrorReport
            // 
            this.ucErrorReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorReport.ErrorInfoS = null;
            this.ucErrorReport.Location = new System.Drawing.Point(2, 25);
            this.ucErrorReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucErrorReport.Name = "ucErrorReport";
            this.ucErrorReport.ProcessS = null;
            this.ucErrorReport.Size = new System.Drawing.Size(958, 412);
            this.ucErrorReport.TabIndex = 7;
            // 
            // tpErrorList
            // 
            this.tpErrorList.Controls.Add(this.grdError);
            this.tpErrorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Size = new System.Drawing.Size(962, 439);
            this.tpErrorList.Text = "Total List";
            // 
            // grdError
            // 
            this.grdError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdError.Location = new System.Drawing.Point(0, 0);
            this.grdError.MainView = this.grvError;
            this.grdError.Name = "grdError";
            this.grdError.Size = new System.Drawing.Size(962, 439);
            this.grdError.TabIndex = 1;
            this.grdError.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvError});
            // 
            // grvError
            // 
            this.grvError.Appearance.GroupRow.BackColor = System.Drawing.Color.LimeGreen;
            this.grvError.Appearance.GroupRow.BackColor2 = System.Drawing.Color.GreenYellow;
            this.grvError.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 16F);
            this.grvError.Appearance.GroupRow.ForeColor = System.Drawing.Color.Blue;
            this.grvError.Appearance.GroupRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvError.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvError.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvError.Appearance.GroupRow.Options.UseFont = true;
            this.grvError.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvError.Appearance.GroupRow.Options.UseImage = true;
            this.grvError.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.grvError.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvError.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvError.Appearance.Row.Options.UseFont = true;
            this.grvError.ColumnPanelRowHeight = 30;
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
            this.grvError.Name = "grvError";
            this.grvError.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvError.OptionsBehavior.Editable = false;
            this.grvError.OptionsBehavior.ReadOnly = true;
            this.grvError.OptionsDetail.AllowZoomDetail = false;
            this.grvError.OptionsDetail.EnableMasterViewMode = false;
            this.grvError.OptionsDetail.ShowDetailTabs = false;
            this.grvError.OptionsDetail.SmartDetailExpand = false;
            this.grvError.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvError.OptionsView.AllowCellMerge = true;
            this.grvError.OptionsView.EnableAppearanceEvenRow = true;
            this.grvError.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.grvError.OptionsView.ShowAutoFilterRow = true;
            this.grvError.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvError.OptionsView.ShowGroupedColumns = true;
            this.grvError.OptionsView.ShowIndicator = false;
            this.grvError.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.grvError.RowHeight = 20;
            this.grvError.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroupKey, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvError.DoubleClick += new System.EventHandler(this.grvError_DoubleClick);
            // 
            // colErrorID
            // 
            this.colErrorID.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colGroupKey.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupKey.Caption = "Group";
            this.colGroupKey.FieldName = "GroupKey";
            this.colGroupKey.Name = "colGroupKey";
            this.colGroupKey.OptionsColumn.FixedWidth = true;
            this.colGroupKey.OptionsColumn.ReadOnly = true;
            this.colGroupKey.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colGroupKey.Visible = true;
            this.colGroupKey.VisibleIndex = 0;
            this.colGroupKey.Width = 93;
            // 
            // colErrorMessage
            // 
            this.colErrorMessage.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorMessage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colDetailErrorMessage.AppearanceCell.Options.UseTextOptions = true;
            this.colDetailErrorMessage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            // grpControl
            // 
            this.grpControl.Appearance.BackColor = System.Drawing.Color.White;
            this.grpControl.Appearance.Options.UseBackColor = true;
            this.grpControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpControl.AppearanceCaption.Options.UseFont = true;
            this.grpControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpControl.Controls.Add(this.panel6);
            this.grpControl.Controls.Add(this.btnApply);
            this.grpControl.Controls.Add(this.panel3);
            this.grpControl.Controls.Add(this.btnReport);
            this.grpControl.Controls.Add(this.panel2);
            this.grpControl.Controls.Add(this.btnDateNow);
            this.grpControl.Controls.Add(this.panel1);
            this.grpControl.Controls.Add(this.panel52);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControl.Location = new System.Drawing.Point(2, 2);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(968, 103);
            this.grpControl.TabIndex = 2;
            this.grpControl.Text = "Menu";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(642, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(184, 76);
            this.panel6.TabIndex = 32;
            // 
            // btnApply
            // 
            this.btnApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApply.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnApply.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnApply.Appearance.Options.UseBackColor = true;
            this.btnApply.Appearance.Options.UseFont = true;
            this.btnApply.Appearance.Options.UseForeColor = true;
            this.btnApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnApply.Location = new System.Drawing.Point(522, 25);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(120, 76);
            this.btnApply.TabIndex = 30;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(502, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 76);
            this.panel3.TabIndex = 31;
            // 
            // btnReport
            // 
            this.btnReport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnReport.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnReport.Appearance.Options.UseBackColor = true;
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnReport.Location = new System.Drawing.Point(826, 25);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(120, 76);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "Save\r\nReport";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(946, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 76);
            this.panel2.TabIndex = 28;
            // 
            // btnDateNow
            // 
            this.btnDateNow.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDateNow.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDateNow.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnDateNow.Appearance.Options.UseBackColor = true;
            this.btnDateNow.Appearance.Options.UseFont = true;
            this.btnDateNow.Appearance.Options.UseForeColor = true;
            this.btnDateNow.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDateNow.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDateNow.Image = ((System.Drawing.Image)(resources.GetObject("btnDateNow.Image")));
            this.btnDateNow.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDateNow.Location = new System.Drawing.Point(382, 25);
            this.btnDateNow.Name = "btnDateNow";
            this.btnDateNow.Size = new System.Drawing.Size(120, 76);
            this.btnDateNow.TabIndex = 27;
            this.btnDateNow.Text = "Move\r\nDate Now";
            this.btnDateNow.Click += new System.EventHandler(this.btnDateNow_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(362, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 76);
            this.panel1.TabIndex = 26;
            // 
            // panel52
            // 
            this.panel52.BackColor = System.Drawing.Color.White;
            this.panel52.Controls.Add(this.panelControl1);
            this.panel52.Controls.Add(this.dateEditMin);
            this.panel52.Controls.Add(this.labelControl1);
            this.panel52.Controls.Add(this.dateEditMax);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(2, 25);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(360, 76);
            this.panel52.TabIndex = 25;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.DimGray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.radioMonthly);
            this.panelControl1.Controls.Add(this.panel5);
            this.panelControl1.Controls.Add(this.radioWeekly);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.radioDaily);
            this.panelControl1.Location = new System.Drawing.Point(16, 7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(328, 34);
            this.panelControl1.TabIndex = 3;
            // 
            // radioMonthly
            // 
            this.radioMonthly.AutoSize = true;
            this.radioMonthly.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioMonthly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMonthly.Location = new System.Drawing.Point(232, 0);
            this.radioMonthly.Name = "radioMonthly";
            this.radioMonthly.Size = new System.Drawing.Size(86, 34);
            this.radioMonthly.TabIndex = 30;
            this.radioMonthly.Text = "Monthly";
            this.radioMonthly.UseVisualStyleBackColor = true;
            this.radioMonthly.CheckedChanged += new System.EventHandler(this.radioMonthly_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(188, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 34);
            this.panel5.TabIndex = 29;
            // 
            // radioWeekly
            // 
            this.radioWeekly.AutoSize = true;
            this.radioWeekly.Checked = true;
            this.radioWeekly.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioWeekly.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioWeekly.Location = new System.Drawing.Point(106, 0);
            this.radioWeekly.Name = "radioWeekly";
            this.radioWeekly.Size = new System.Drawing.Size(82, 34);
            this.radioWeekly.TabIndex = 28;
            this.radioWeekly.TabStop = true;
            this.radioWeekly.Text = "Weekly";
            this.radioWeekly.UseVisualStyleBackColor = true;
            this.radioWeekly.CheckedChanged += new System.EventHandler(this.radioWeekly_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(65, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(41, 34);
            this.panel4.TabIndex = 27;
            // 
            // radioDaily
            // 
            this.radioDaily.AutoSize = true;
            this.radioDaily.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioDaily.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDaily.Location = new System.Drawing.Point(0, 0);
            this.radioDaily.Name = "radioDaily";
            this.radioDaily.Size = new System.Drawing.Size(65, 34);
            this.radioDaily.TabIndex = 0;
            this.radioDaily.Text = "Daily";
            this.radioDaily.UseVisualStyleBackColor = true;
            this.radioDaily.CheckedChanged += new System.EventHandler(this.radioDaily_CheckedChanged);
            // 
            // dateEditMin
            // 
            this.dateEditMin.EditValue = new System.DateTime(2015, 11, 30, 20, 44, 13, 0);
            this.dateEditMin.Location = new System.Drawing.Point(16, 43);
            this.dateEditMin.Name = "dateEditMin";
            this.dateEditMin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dateEditMin.Properties.Appearance.Options.UseFont = true;
            this.dateEditMin.Properties.Appearance.Options.UseTextOptions = true;
            this.dateEditMin.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateEditMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMin.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dateEditMin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMin.Size = new System.Drawing.Size(152, 26);
            this.dateEditMin.TabIndex = 0;
            this.dateEditMin.EditValueChanged += new System.EventHandler(this.dateEditMin_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(174, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "~";
            // 
            // dateEditMax
            // 
            this.dateEditMax.EditValue = new System.DateTime(2016, 1, 28, 20, 44, 13, 0);
            this.dateEditMax.Location = new System.Drawing.Point(192, 43);
            this.dateEditMax.Name = "dateEditMax";
            this.dateEditMax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dateEditMax.Properties.Appearance.Options.UseFont = true;
            this.dateEditMax.Properties.Appearance.Options.UseTextOptions = true;
            this.dateEditMax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateEditMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMax.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditMax.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dateEditMax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditMax.Properties.ReadOnly = true;
            this.dateEditMax.Size = new System.Drawing.Size(152, 26);
            this.dateEditMax.TabIndex = 1;
            this.dateEditMax.EditValueChanged += new System.EventHandler(this.dateEditMax_EditValueChanged);
            // 
            // UCErrorLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGridView);
            this.Name = "UCErrorLogTable";
            this.Size = new System.Drawing.Size(972, 580);
            this.Load += new System.EventHandler(this.UCErrorLogTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridView)).EndInit();
            this.pnlGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tpErrorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panel52.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMax.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditMax.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlGridView;
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
        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEditMax;
        private DevExpress.XtraEditors.DateEdit dateEditMin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel52;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnDateNow;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton radioMonthly;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioWeekly;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioDaily;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCErrorReport ucErrorReport;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpDetail;
        private DevExpress.XtraTab.XtraTabPage tpErrorList;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailErrorMessage;
    }
}
