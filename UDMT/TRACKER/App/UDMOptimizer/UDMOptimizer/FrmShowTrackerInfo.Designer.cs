namespace UDMOptimizer
{
    partial class FrmShowTrackerInfo
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
            this.tabTrackerInfo = new DevExpress.XtraTab.XtraTabControl();
            this.tpLogData = new DevExpress.XtraTab.XtraTabPage();
            this.grpCollectInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdLogInfo = new DevExpress.XtraGrid.GridControl();
            this.grvLogInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollectStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpFlowInfo = new DevExpress.XtraTab.XtraTabPage();
            this.grpInfo = new DevExpress.XtraEditors.GroupControl();
            this.exPropertyView = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.exEditorFiles = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowProjectName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProjectFilePath = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowProjectID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPLCCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.sptLogInfo = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpCycleInfo = new DevExpress.XtraEditors.GroupControl();
            this.grdCycleInfo = new DevExpress.XtraGrid.GridControl();
            this.grvCycleInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCycleStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollectCycleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabTrackerInfo)).BeginInit();
            this.tabTrackerInfo.SuspendLayout();
            this.tpLogData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCollectInfo)).BeginInit();
            this.grpCollectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exPropertyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptLogInfo)).BeginInit();
            this.sptLogInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleInfo)).BeginInit();
            this.grpCycleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCycleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCycleInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTrackerInfo
            // 
            this.tabTrackerInfo.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.tabTrackerInfo.AppearancePage.Header.Options.UseFont = true;
            this.tabTrackerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTrackerInfo.Location = new System.Drawing.Point(0, 124);
            this.tabTrackerInfo.Name = "tabTrackerInfo";
            this.tabTrackerInfo.SelectedTabPage = this.tpLogData;
            this.tabTrackerInfo.Size = new System.Drawing.Size(843, 612);
            this.tabTrackerInfo.TabIndex = 0;
            this.tabTrackerInfo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLogData,
            this.tpFlowInfo});
            // 
            // tpLogData
            // 
            this.tpLogData.Controls.Add(this.sptLogInfo);
            this.tpLogData.Name = "tpLogData";
            this.tpLogData.Size = new System.Drawing.Size(837, 577);
            this.tpLogData.Text = "Log Information";
            // 
            // grpCollectInfo
            // 
            this.grpCollectInfo.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grpCollectInfo.AppearanceCaption.Options.UseFont = true;
            this.grpCollectInfo.Controls.Add(this.grdLogInfo);
            this.grpCollectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCollectInfo.Location = new System.Drawing.Point(0, 0);
            this.grpCollectInfo.Name = "grpCollectInfo";
            this.grpCollectInfo.Size = new System.Drawing.Size(837, 170);
            this.grpCollectInfo.TabIndex = 1;
            this.grpCollectInfo.Text = "수집 기간 (수집 시작 과 종료)";
            // 
            // grdLogInfo
            // 
            this.grdLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogInfo.Location = new System.Drawing.Point(2, 27);
            this.grdLogInfo.MainView = this.grvLogInfo;
            this.grdLogInfo.Name = "grdLogInfo";
            this.grdLogInfo.Size = new System.Drawing.Size(833, 141);
            this.grdLogInfo.TabIndex = 0;
            this.grdLogInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLogInfo});
            // 
            // grvLogInfo
            // 
            this.grvLogInfo.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grvLogInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvLogInfo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLogInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLogInfo.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grvLogInfo.Appearance.Row.Options.UseFont = true;
            this.grvLogInfo.Appearance.Row.Options.UseTextOptions = true;
            this.grvLogInfo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLogInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollectStart,
            this.colCollectEnd,
            this.colLogCount,
            this.colCollectCycleCount});
            this.grvLogInfo.GridControl = this.grdLogInfo;
            this.grvLogInfo.IndicatorWidth = 50;
            this.grvLogInfo.Name = "grvLogInfo";
            this.grvLogInfo.OptionsBehavior.Editable = false;
            this.grvLogInfo.OptionsDetail.EnableMasterViewMode = false;
            this.grvLogInfo.OptionsDetail.ShowDetailTabs = false;
            this.grvLogInfo.OptionsDetail.SmartDetailExpand = false;
            this.grvLogInfo.OptionsView.ShowGroupPanel = false;
            this.grvLogInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvLogInfo_RowClick);
            this.grvLogInfo.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvLogInfo_CustomDrawRowIndicator);
            // 
            // colCollectStart
            // 
            this.colCollectStart.Caption = "Collect Start";
            this.colCollectStart.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.colCollectStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCollectStart.FieldName = "StartTime";
            this.colCollectStart.Name = "colCollectStart";
            this.colCollectStart.Visible = true;
            this.colCollectStart.VisibleIndex = 0;
            this.colCollectStart.Width = 297;
            // 
            // colCollectEnd
            // 
            this.colCollectEnd.Caption = "Collect End";
            this.colCollectEnd.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.colCollectEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCollectEnd.FieldName = "EndTime";
            this.colCollectEnd.Name = "colCollectEnd";
            this.colCollectEnd.Visible = true;
            this.colCollectEnd.VisibleIndex = 1;
            this.colCollectEnd.Width = 297;
            // 
            // colLogCount
            // 
            this.colLogCount.Caption = "Log Count";
            this.colLogCount.FieldName = "LogCount";
            this.colLogCount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 3;
            this.colLogCount.Width = 100;
            // 
            // tpFlowInfo
            // 
            this.tpFlowInfo.Name = "tpFlowInfo";
            this.tpFlowInfo.Size = new System.Drawing.Size(837, 391);
            this.tpFlowInfo.Text = "Flow Chart Information";
            // 
            // grpInfo
            // 
            this.grpInfo.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grpInfo.AppearanceCaption.Options.UseFont = true;
            this.grpInfo.Controls.Add(this.exPropertyView);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(843, 124);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.Text = "Open Data Information";
            // 
            // exPropertyView
            // 
            this.exPropertyView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.exPropertyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exPropertyView.Location = new System.Drawing.Point(2, 27);
            this.exPropertyView.Name = "exPropertyView";
            this.exPropertyView.OptionsBehavior.Editable = false;
            this.exPropertyView.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exPropertyView.OptionsBehavior.ResizeHeaderPanel = false;
            this.exPropertyView.OptionsBehavior.ResizeRowHeaders = false;
            this.exPropertyView.OptionsBehavior.ResizeRowValues = false;
            this.exPropertyView.OptionsView.FixRowHeaderPanelWidth = true;
            this.exPropertyView.OptionsView.ShowFocusedFrame = false;
            this.exPropertyView.Padding = new System.Windows.Forms.Padding(10);
            this.exPropertyView.RecordWidth = 164;
            this.exPropertyView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFiles});
            this.exPropertyView.RowHeaderWidth = 36;
            this.exPropertyView.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowProjectName,
            this.rowProjectFilePath,
            this.rowProjectID,
            this.rowPLCCount});
            this.exPropertyView.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowForFocusedRow;
            this.exPropertyView.Size = new System.Drawing.Size(839, 95);
            this.exPropertyView.TabIndex = 13;
            // 
            // exEditorFiles
            // 
            this.exEditorFiles.Name = "exEditorFiles";
            // 
            // rowProjectName
            // 
            this.rowProjectName.Height = 22;
            this.rowProjectName.Name = "rowProjectName";
            this.rowProjectName.Properties.Caption = "Project Name";
            this.rowProjectName.Properties.FieldName = "ProjectName";
            this.rowProjectName.Properties.ReadOnly = true;
            // 
            // rowProjectFilePath
            // 
            this.rowProjectFilePath.Height = 22;
            this.rowProjectFilePath.Name = "rowProjectFilePath";
            this.rowProjectFilePath.Properties.Caption = "Project File Path";
            this.rowProjectFilePath.Properties.FieldName = "ProjectPath";
            this.rowProjectFilePath.Properties.ReadOnly = true;
            // 
            // rowProjectID
            // 
            this.rowProjectID.Height = 22;
            this.rowProjectID.Name = "rowProjectID";
            this.rowProjectID.Properties.Caption = "Project ID";
            this.rowProjectID.Properties.FieldName = "ProjectID";
            this.rowProjectID.Properties.ReadOnly = true;
            // 
            // rowPLCCount
            // 
            this.rowPLCCount.Height = 22;
            this.rowPLCCount.Name = "rowPLCCount";
            this.rowPLCCount.Properties.Caption = "PLC Count";
            this.rowPLCCount.Properties.FieldName = "PlcIDList.Count";
            this.rowPLCCount.Properties.ReadOnly = true;
            // 
            // sptLogInfo
            // 
            this.sptLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptLogInfo.Horizontal = false;
            this.sptLogInfo.Location = new System.Drawing.Point(0, 0);
            this.sptLogInfo.Name = "sptLogInfo";
            this.sptLogInfo.Panel1.Controls.Add(this.grpCollectInfo);
            this.sptLogInfo.Panel1.Text = "Panel1";
            this.sptLogInfo.Panel2.Controls.Add(this.grpCycleInfo);
            this.sptLogInfo.Panel2.Text = "Panel2";
            this.sptLogInfo.Size = new System.Drawing.Size(837, 577);
            this.sptLogInfo.SplitterPosition = 170;
            this.sptLogInfo.TabIndex = 2;
            this.sptLogInfo.Text = "splitContainerControl1";
            // 
            // grpCycleInfo
            // 
            this.grpCycleInfo.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grpCycleInfo.AppearanceCaption.Options.UseFont = true;
            this.grpCycleInfo.Controls.Add(this.grdCycleInfo);
            this.grpCycleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCycleInfo.Location = new System.Drawing.Point(0, 0);
            this.grpCycleInfo.Name = "grpCycleInfo";
            this.grpCycleInfo.Size = new System.Drawing.Size(837, 402);
            this.grpCycleInfo.TabIndex = 2;
            this.grpCycleInfo.Text = "선택된 수집기간 중 Cycle 정보";
            // 
            // grdCycleInfo
            // 
            this.grdCycleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCycleInfo.Location = new System.Drawing.Point(2, 27);
            this.grdCycleInfo.MainView = this.grvCycleInfo;
            this.grdCycleInfo.Name = "grdCycleInfo";
            this.grdCycleInfo.Size = new System.Drawing.Size(833, 373);
            this.grdCycleInfo.TabIndex = 0;
            this.grdCycleInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCycleInfo});
            // 
            // grvCycleInfo
            // 
            this.grvCycleInfo.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.grvCycleInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCycleInfo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCycleInfo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCycleInfo.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.grvCycleInfo.Appearance.Row.Options.UseFont = true;
            this.grvCycleInfo.Appearance.Row.Options.UseTextOptions = true;
            this.grvCycleInfo.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCycleInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycleStart,
            this.colCycleEnd,
            this.colCycleType,
            this.colCycleID,
            this.colCycleProcess,
            this.colCycleTime});
            this.grvCycleInfo.GridControl = this.grdCycleInfo;
            this.grvCycleInfo.GroupCount = 1;
            this.grvCycleInfo.IndicatorWidth = 50;
            this.grvCycleInfo.Name = "grvCycleInfo";
            this.grvCycleInfo.OptionsBehavior.Editable = false;
            this.grvCycleInfo.OptionsDetail.EnableMasterViewMode = false;
            this.grvCycleInfo.OptionsDetail.ShowDetailTabs = false;
            this.grvCycleInfo.OptionsDetail.SmartDetailExpand = false;
            this.grvCycleInfo.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvCycleInfo.OptionsView.ShowGroupPanel = false;
            this.grvCycleInfo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCycleProcess, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCycleStart
            // 
            this.colCycleStart.Caption = "Start Time";
            this.colCycleStart.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.colCycleStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCycleStart.FieldName = "CycleStart";
            this.colCycleStart.Name = "colCycleStart";
            this.colCycleStart.Visible = true;
            this.colCycleStart.VisibleIndex = 1;
            this.colCycleStart.Width = 278;
            // 
            // colCycleEnd
            // 
            this.colCycleEnd.Caption = "End Time";
            this.colCycleEnd.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.colCycleEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCycleEnd.FieldName = "CycleEnd";
            this.colCycleEnd.Name = "colCycleEnd";
            this.colCycleEnd.Visible = true;
            this.colCycleEnd.VisibleIndex = 2;
            this.colCycleEnd.Width = 278;
            // 
            // colCycleType
            // 
            this.colCycleType.Caption = "Type";
            this.colCycleType.FieldName = "CycleType";
            this.colCycleType.Name = "colCycleType";
            this.colCycleType.Visible = true;
            this.colCycleType.VisibleIndex = 0;
            this.colCycleType.Width = 130;
            // 
            // colCollectCycleCount
            // 
            this.colCollectCycleCount.Caption = "Cycle Count";
            this.colCollectCycleCount.FieldName = "CycleCount";
            this.colCollectCycleCount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colCollectCycleCount.Name = "colCollectCycleCount";
            this.colCollectCycleCount.Visible = true;
            this.colCollectCycleCount.VisibleIndex = 2;
            this.colCollectCycleCount.Width = 100;
            // 
            // colCycleID
            // 
            this.colCycleID.Caption = "Number";
            this.colCycleID.FieldName = "CycleID";
            this.colCycleID.Name = "colCycleID";
            this.colCycleID.Width = 68;
            // 
            // colCycleProcess
            // 
            this.colCycleProcess.Caption = "Process";
            this.colCycleProcess.FieldName = "GroupKey";
            this.colCycleProcess.Name = "colCycleProcess";
            this.colCycleProcess.Visible = true;
            this.colCycleProcess.VisibleIndex = 2;
            this.colCycleProcess.Width = 67;
            // 
            // colCycleTime
            // 
            this.colCycleTime.Caption = "Cycle(s)";
            this.colCycleTime.FieldName = "CycleTime";
            this.colCycleTime.Name = "colCycleTime";
            this.colCycleTime.Visible = true;
            this.colCycleTime.VisibleIndex = 3;
            this.colCycleTime.Width = 100;
            // 
            // FrmShowTrackerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 736);
            this.Controls.Add(this.tabTrackerInfo);
            this.Controls.Add(this.grpInfo);
            this.Name = "FrmShowTrackerInfo";
            this.Text = "Show Tracker Information";
            this.Load += new System.EventHandler(this.FrmShowTrackerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabTrackerInfo)).EndInit();
            this.tabTrackerInfo.ResumeLayout(false);
            this.tpLogData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCollectInfo)).EndInit();
            this.grpCollectInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLogInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLogInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInfo)).EndInit();
            this.grpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exPropertyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptLogInfo)).EndInit();
            this.sptLogInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleInfo)).EndInit();
            this.grpCycleInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCycleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCycleInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabTrackerInfo;
        private DevExpress.XtraTab.XtraTabPage tpLogData;
        private DevExpress.XtraTab.XtraTabPage tpFlowInfo;
        private DevExpress.XtraEditors.GroupControl grpInfo;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exPropertyView;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit exEditorFiles;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProjectName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProjectFilePath;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProjectID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPLCCount;
        private DevExpress.XtraGrid.GridControl grdLogInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLogInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectStart;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private DevExpress.XtraEditors.GroupControl grpCollectInfo;
        private DevExpress.XtraEditors.SplitContainerControl sptLogInfo;
        private DevExpress.XtraEditors.GroupControl grpCycleInfo;
        private DevExpress.XtraGrid.GridControl grdCycleInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCycleInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleStart;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleType;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectCycleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleID;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleTime;
    }
}