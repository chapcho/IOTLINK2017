namespace UDMTrackerSimple
{
    partial class UCAllErrorAlarmView2
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAllErrorAlarmView2));
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.pnlMonitoring = new DevExpress.XtraEditors.PanelControl();
            this.ucErrorAlarmView = new UDMTrackerSimple.UCErrorAlarmView();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnErrorClear = new DevExpress.XtraEditors.SimpleButton();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.sptErrorInfo = new UDM.UI.MySplitContainerControl();
            this.grpStatistic = new DevExpress.XtraEditors.GroupControl();
            this.sptStatistic = new UDM.UI.MySplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ErrorPieChart = new DevExpress.XtraCharts.ChartControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdLine = new DevExpress.XtraGrid.GridControl();
            this.grvLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpErrorInfo = new DevExpress.XtraEditors.GroupControl();
            this.ucErrorPanelS = new UDMTrackerSimple.UCErrorSummaryPanelS();
            this.exEditorTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoring)).BeginInit();
            this.pnlMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptErrorInfo)).BeginInit();
            this.sptErrorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatistic)).BeginInit();
            this.grpStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptStatistic)).BeginInit();
            this.sptStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInfo)).BeginInit();
            this.grpErrorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMonitoring
            // 
            this.pnlMonitoring.Controls.Add(this.ucErrorAlarmView);
            this.pnlMonitoring.Controls.Add(this.pnlHeader);
            this.pnlMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonitoring.Location = new System.Drawing.Point(0, 0);
            this.pnlMonitoring.MinimumSize = new System.Drawing.Size(400, 0);
            this.pnlMonitoring.Name = "pnlMonitoring";
            this.pnlMonitoring.Size = new System.Drawing.Size(796, 727);
            this.pnlMonitoring.TabIndex = 10;
            // 
            // ucErrorAlarmView
            // 
            this.ucErrorAlarmView.AutoScroll = true;
            this.ucErrorAlarmView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorAlarmView.Location = new System.Drawing.Point(2, 28);
            this.ucErrorAlarmView.Name = "ucErrorAlarmView";
            this.ucErrorAlarmView.Size = new System.Drawing.Size(792, 697);
            this.ucErrorAlarmView.TabIndex = 4;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.Controls.Add(this.labelControl1);
            this.pnlHeader.Controls.Add(this.btnErrorClear);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(792, 26);
            this.pnlHeader.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(199, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = " Process Monitoring";
            // 
            // btnErrorClear
            // 
            this.btnErrorClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorClear.Appearance.Options.UseFont = true;
            this.btnErrorClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnErrorClear.Image = ((System.Drawing.Image)(resources.GetObject("btnErrorClear.Image")));
            this.btnErrorClear.Location = new System.Drawing.Point(715, 2);
            this.btnErrorClear.Name = "btnErrorClear";
            this.btnErrorClear.Size = new System.Drawing.Size(75, 22);
            this.btnErrorClear.TabIndex = 0;
            this.btnErrorClear.Text = "Clear";
            this.btnErrorClear.Click += new System.EventHandler(this.btnErrorClear_Click);
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.sptMain);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1445, 731);
            this.pnlChart.TabIndex = 11;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(2, 2);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.pnlMonitoring);
            this.sptMain.Panel1.MinSize = 400;
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.sptErrorInfo);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1441, 727);
            this.sptMain.SplitterPosition = 796;
            this.sptMain.TabIndex = 11;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // sptErrorInfo
            // 
            this.sptErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptErrorInfo.Horizontal = false;
            this.sptErrorInfo.Location = new System.Drawing.Point(0, 0);
            this.sptErrorInfo.Name = "sptErrorInfo";
            this.sptErrorInfo.Panel1.Controls.Add(this.grpStatistic);
            this.sptErrorInfo.Panel1.Text = "Panel1";
            this.sptErrorInfo.Panel2.Controls.Add(this.grpErrorInfo);
            this.sptErrorInfo.Panel2.Text = "Panel2";
            this.sptErrorInfo.Size = new System.Drawing.Size(635, 727);
            this.sptErrorInfo.SplitterPosition = 307;
            this.sptErrorInfo.TabIndex = 10;
            this.sptErrorInfo.Text = "splitContainerControl1";
            this.sptErrorInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptErrorInfo_MouseDoubleClick);
            // 
            // grpStatistic
            // 
            this.grpStatistic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatistic.AppearanceCaption.Options.UseFont = true;
            this.grpStatistic.Controls.Add(this.sptStatistic);
            this.grpStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatistic.Location = new System.Drawing.Point(0, 0);
            this.grpStatistic.MinimumSize = new System.Drawing.Size(0, 300);
            this.grpStatistic.Name = "grpStatistic";
            this.grpStatistic.Size = new System.Drawing.Size(635, 307);
            this.grpStatistic.TabIndex = 7;
            this.grpStatistic.Text = "Error Occurrence Status";
            // 
            // sptStatistic
            // 
            this.sptStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptStatistic.Location = new System.Drawing.Point(2, 26);
            this.sptStatistic.Name = "sptStatistic";
            this.sptStatistic.Panel1.Controls.Add(this.panelControl1);
            this.sptStatistic.Panel1.Text = "Panel1";
            this.sptStatistic.Panel2.Controls.Add(this.panelControl2);
            this.sptStatistic.Panel2.Text = "Panel2";
            this.sptStatistic.Size = new System.Drawing.Size(631, 279);
            this.sptStatistic.SplitterPosition = 345;
            this.sptStatistic.TabIndex = 0;
            this.sptStatistic.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.ErrorPieChart);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(345, 279);
            this.panelControl1.TabIndex = 0;
            // 
            // ErrorPieChart
            // 
            this.ErrorPieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorPieChart.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Center;
            this.ErrorPieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ErrorPieChart.Location = new System.Drawing.Point(0, 0);
            this.ErrorPieChart.Name = "ErrorPieChart";
            this.ErrorPieChart.RuntimeHitTesting = true;
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Error";
            series1.View = pieSeriesView1;
            this.ErrorPieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ErrorPieChart.Size = new System.Drawing.Size(345, 279);
            this.ErrorPieChart.TabIndex = 3;
            chartTitle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "Error";
            this.ErrorPieChart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.ErrorPieChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ErrorPieChart_CustomDrawSeriesPoint);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.grdLine);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(276, 279);
            this.panelControl2.TabIndex = 1;
            // 
            // grdLine
            // 
            this.grdLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLine.Location = new System.Drawing.Point(0, 0);
            this.grdLine.MainView = this.grvLine;
            this.grdLine.Name = "grdLine";
            this.grdLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.grdLine.Size = new System.Drawing.Size(276, 279);
            this.grdLine.TabIndex = 1;
            this.grdLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLine});
            // 
            // grvLine
            // 
            this.grvLine.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grvLine.Appearance.Row.Options.UseFont = true;
            this.grvLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPLC,
            this.colProcess,
            this.colCount,
            this.colTime,
            this.colMessage});
            this.grvLine.GridControl = this.grdLine;
            this.grvLine.IndicatorWidth = 30;
            this.grvLine.Name = "grvLine";
            this.grvLine.OptionsBehavior.Editable = false;
            this.grvLine.OptionsBehavior.ReadOnly = true;
            this.grvLine.OptionsDetail.AllowZoomDetail = false;
            this.grvLine.OptionsDetail.EnableMasterViewMode = false;
            this.grvLine.OptionsDetail.ShowDetailTabs = false;
            this.grvLine.OptionsDetail.SmartDetailExpand = false;
            this.grvLine.OptionsView.ShowGroupPanel = false;
            this.grvLine.RowHeight = 30;
            this.grvLine.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvLine_CustomDrawRowIndicator);
            // 
            // colPLC
            // 
            this.colPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.Caption = "PLC";
            this.colPLC.FieldName = "PlcName";
            this.colPLC.Name = "colPLC";
            this.colPLC.OptionsColumn.AllowEdit = false;
            this.colPLC.OptionsColumn.AllowMove = false;
            this.colPLC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPLC.OptionsColumn.ReadOnly = true;
            this.colPLC.Width = 164;
            // 
            // colProcess
            // 
            this.colProcess.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcess.AppearanceCell.Options.UseFont = true;
            this.colProcess.AppearanceCell.Options.UseTextOptions = true;
            this.colProcess.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProcess.AppearanceHeader.Options.UseFont = true;
            this.colProcess.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.Caption = "Process";
            this.colProcess.FieldName = "GroupKey";
            this.colProcess.Name = "colProcess";
            this.colProcess.OptionsColumn.AllowEdit = false;
            this.colProcess.OptionsColumn.AllowMove = false;
            this.colProcess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProcess.OptionsColumn.FixedWidth = true;
            this.colProcess.OptionsColumn.ReadOnly = true;
            this.colProcess.Visible = true;
            this.colProcess.VisibleIndex = 0;
            this.colProcess.Width = 100;
            // 
            // colCount
            // 
            this.colCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCount.AppearanceCell.Options.UseFont = true;
            this.colCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCount.AppearanceHeader.Options.UseFont = true;
            this.colCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.Caption = "Error Count";
            this.colCount.FieldName = "ErrorCount";
            this.colCount.MinWidth = 80;
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.AllowMove = false;
            this.colCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCount.OptionsColumn.FixedWidth = true;
            this.colCount.OptionsColumn.ReadOnly = true;
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 1;
            this.colCount.Width = 70;
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceCell.Options.UseFont = true;
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceHeader.Options.UseFont = true;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Recent Error time";
            this.colTime.ColumnEdit = this.repositoryItemTimeEdit1;
            this.colTime.FieldName = "RecentTime";
            this.colTime.MinWidth = 150;
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.AllowEdit = false;
            this.colTime.OptionsColumn.AllowMove = false;
            this.colTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTime.OptionsColumn.FixedWidth = true;
            this.colTime.OptionsColumn.ReadOnly = true;
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 2;
            this.colTime.Width = 200;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.EditFormat.FormatString = "MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // colMessage
            // 
            this.colMessage.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMessage.AppearanceCell.Options.UseFont = true;
            this.colMessage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMessage.AppearanceHeader.Options.UseFont = true;
            this.colMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMessage.Caption = "Recent Error Message";
            this.colMessage.FieldName = "RecentError";
            this.colMessage.Name = "colMessage";
            this.colMessage.OptionsColumn.AllowEdit = false;
            this.colMessage.OptionsColumn.AllowMove = false;
            this.colMessage.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMessage.OptionsColumn.ReadOnly = true;
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 3;
            this.colMessage.Width = 20;
            // 
            // grpErrorInfo
            // 
            this.grpErrorInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpErrorInfo.AppearanceCaption.Options.UseFont = true;
            this.grpErrorInfo.Controls.Add(this.ucErrorPanelS);
            this.grpErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorInfo.Location = new System.Drawing.Point(0, 0);
            this.grpErrorInfo.Name = "grpErrorInfo";
            this.grpErrorInfo.Size = new System.Drawing.Size(635, 410);
            this.grpErrorInfo.TabIndex = 9;
            this.grpErrorInfo.Text = "Real-Time Error Information";
            // 
            // ucErrorPanelS
            // 
            this.ucErrorPanelS.Appearance.BackColor = System.Drawing.Color.White;
            this.ucErrorPanelS.Appearance.Options.UseBackColor = true;
            this.ucErrorPanelS.AutoScroll = true;
            this.ucErrorPanelS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorPanelS.Location = new System.Drawing.Point(2, 26);
            this.ucErrorPanelS.Name = "ucErrorPanelS";
            this.ucErrorPanelS.Size = new System.Drawing.Size(631, 382);
            this.ucErrorPanelS.TabIndex = 0;
            // 
            // exEditorTime
            // 
            this.exEditorTime.AutoHeight = false;
            this.exEditorTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTime.DisplayFormat.FormatString = "MM.dd HH:mm:ss";
            this.exEditorTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.EditFormat.FormatString = "MM.dd HH:mm:ss";
            this.exEditorTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.Mask.EditMask = "MM.dd HH:mm:ss";
            this.exEditorTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTime.Name = "exEditorTime";
            // 
            // UCAllErrorAlarmView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChart);
            this.Name = "UCAllErrorAlarmView2";
            this.Size = new System.Drawing.Size(1445, 731);
            this.Load += new System.EventHandler(this.UCAllErrorAlarmView2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoring)).EndInit();
            this.pnlMonitoring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptErrorInfo)).EndInit();
            this.sptErrorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpStatistic)).EndInit();
            this.grpStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptStatistic)).EndInit();
            this.sptStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInfo)).EndInit();
            this.grpErrorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMonitoring;
        private UCErrorAlarmView ucErrorAlarmView;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnErrorClear;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraEditors.GroupControl grpErrorInfo;
        private UCErrorSummaryPanelS ucErrorPanelS;
        private DevExpress.XtraEditors.GroupControl grpStatistic;
        private UDM.UI.MySplitContainerControl sptStatistic;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdLine;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLine;
        private DevExpress.XtraGrid.Columns.GridColumn colPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colProcess;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTime;
        private DevExpress.XtraCharts.ChartControl ErrorPieChart;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private UDM.UI.MySplitContainerControl sptMain;
        private UDM.UI.MySplitContainerControl sptErrorInfo;
    }
}
