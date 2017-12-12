namespace UDMOptimizer
{
    partial class FrmAnovaAnalysis
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnovaAnalysis));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("0", new object[] {
            ((object)(4.8D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("1", new object[] {
            ((object)(7.7D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("2", new object[] {
            ((object)(1.1D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("3", new object[] {
            ((object)(8.6D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("4", new object[] {
            ((object)(9.4D))});
            DevExpress.XtraCharts.PointSeriesView pointSeriesView1 = new DevExpress.XtraCharts.PointSeriesView();
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cboProcess = new DevExpress.XtraBars.BarEditItem();
            this.exEditorGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.exChart = new DevExpress.XtraCharts.ChartControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.grdGroup = new DevExpress.XtraGrid.GridControl();
            this.grvGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colRecipe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddGroup = new DevExpress.XtraEditors.SimpleButton();
            this.cboPatternItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.rdgSubject = new DevExpress.XtraEditors.RadioGroup();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabResult = new DevExpress.XtraTab.XtraTabControl();
            this.tpResult = new DevExpress.XtraTab.XtraTabPage();
            this.grdStatistic = new DevExpress.XtraGrid.GridControl();
            this.grvStatistic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupStatistic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMean = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpLevene = new DevExpress.XtraEditors.GroupControl();
            this.grdLevene = new DevExpress.XtraGrid.GridControl();
            this.grvLevene = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatistic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.grdAnova = new DevExpress.XtraGrid.GridControl();
            this.grvAnova = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumSq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeanSq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBackground = new DevExpress.XtraEditors.PanelControl();
            this.lblDescFalse = new DevExpress.XtraEditors.LabelControl();
            this.lblDescTrue = new DevExpress.XtraEditors.LabelControl();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.tpVerify3 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grpDunnettT3 = new DevExpress.XtraEditors.GroupControl();
            this.grdDunnettT3 = new DevExpress.XtraGrid.GridControl();
            this.grvDunnettT3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDuGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLowerCI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpperCI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.grpScheffe = new DevExpress.XtraEditors.GroupControl();
            this.grdScheffe = new DevExpress.XtraGrid.GridControl();
            this.grvScheffe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroupScheffe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiffScheffe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPValueScheffe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUCL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnAnalysis = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPatternItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).BeginInit();
            this.tabResult.SuspendLayout();
            this.tpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLevene)).BeginInit();
            this.grpLevene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLevene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLevene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.tpVerify3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDunnettT3)).BeginInit();
            this.grpDunnettT3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDunnettT3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDunnettT3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpScheffe)).BeginInit();
            this.grpScheffe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScheffe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScheffe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.cboProcess,
            this.btnClear,
            this.btnRefresh,
            this.btnExit});
            this.exBarManager.MaxItemId = 17;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroup,
            this.exEditorFrom,
            this.exEditorTo});
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.FloatLocation = new System.Drawing.Point(1965, 149);
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboProcess, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // cboProcess
            // 
            this.cboProcess.Caption = "공정";
            this.cboProcess.Edit = this.exEditorGroup;
            this.cboProcess.Id = 1;
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.Width = 148;
            // 
            // exEditorGroup
            // 
            this.exEditorGroup.AutoHeight = false;
            this.exEditorGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroup.Name = "exEditorGroup";
            this.exEditorGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 11;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.LargeImageIndex = 14;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 5;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 12;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.LargeImageIndex = 15;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1084, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 962);
            this.barDockControlBottom.Size = new System.Drawing.Size(1084, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 897);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1084, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 897);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorFrom.Name = "exEditorFrom";
            // 
            // exEditorTo
            // 
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(506, 897);
            this.panelControl1.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.exChart);
            this.groupControl2.Controls.Add(this.splitterControl2);
            this.groupControl2.Controls.Add(this.grdGroup);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 55);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(502, 840);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "그룹";
            // 
            // exChart
            // 
            xyDiagram1.AxisX.Label.Visible = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.exChart.Diagram = xyDiagram1;
            this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.exChart.Location = new System.Drawing.Point(2, 21);
            this.exChart.Name = "exChart";
            series1.Name = "Series 1";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5});
            series1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesView1.PointMarkerOptions.Size = 5;
            series1.View = pointSeriesView1;
            this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.exChart.Size = new System.Drawing.Size(498, 625);
            this.exChart.TabIndex = 0;
            this.exChart.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            this.exChart.ToolTipOptions.ShowForPoints = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl2.Location = new System.Drawing.Point(2, 646);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(498, 5);
            this.splitterControl2.TabIndex = 1;
            this.splitterControl2.TabStop = false;
            // 
            // grdGroup
            // 
            this.grdGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdGroup.Location = new System.Drawing.Point(2, 651);
            this.grdGroup.MainView = this.grvGroup;
            this.grdGroup.MenuManager = this.exBarManager;
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupFrom,
            this.exEditorGroupTo});
            this.grdGroup.Size = new System.Drawing.Size(498, 187);
            this.grdGroup.TabIndex = 5;
            this.grdGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGroup});
            // 
            // grvGroup
            // 
            this.grvGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupName,
            this.colFrom,
            this.colTo,
            this.colRecipe,
            this.gridColumn1});
            this.grvGroup.GridControl = this.grdGroup;
            this.grvGroup.Name = "grvGroup";
            this.grvGroup.OptionsCustomization.AllowSort = false;
            this.grvGroup.OptionsDetail.AllowZoomDetail = false;
            this.grvGroup.OptionsDetail.EnableMasterViewMode = false;
            this.grvGroup.OptionsDetail.ShowDetailTabs = false;
            this.grvGroup.OptionsDetail.SmartDetailExpand = false;
            this.grvGroup.OptionsView.ShowGroupPanel = false;
            // 
            // colGroupName
            // 
            this.colGroupName.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupName.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupName.Caption = "그룹 이름";
            this.colGroupName.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.OptionsColumn.AllowEdit = false;
            this.colGroupName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGroupName.OptionsColumn.ReadOnly = true;
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 0;
            this.colGroupName.Width = 65;
            // 
            // colFrom
            // 
            this.colFrom.AppearanceCell.Options.UseTextOptions = true;
            this.colFrom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFrom.AppearanceHeader.Options.UseTextOptions = true;
            this.colFrom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFrom.Caption = "From";
            this.colFrom.ColumnEdit = this.exEditorGroupFrom;
            this.colFrom.FieldName = "From";
            this.colFrom.Name = "colFrom";
            this.colFrom.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFrom.Visible = true;
            this.colFrom.VisibleIndex = 1;
            this.colFrom.Width = 138;
            // 
            // exEditorGroupFrom
            // 
            this.exEditorGroupFrom.AutoHeight = false;
            this.exEditorGroupFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorGroupFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorGroupFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorGroupFrom.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorGroupFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorGroupFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorGroupFrom.Name = "exEditorGroupFrom";
            // 
            // colTo
            // 
            this.colTo.AppearanceCell.Options.UseTextOptions = true;
            this.colTo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTo.AppearanceHeader.Options.UseTextOptions = true;
            this.colTo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTo.Caption = "To";
            this.colTo.ColumnEdit = this.exEditorGroupTo;
            this.colTo.FieldName = "To";
            this.colTo.Name = "colTo";
            this.colTo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTo.Visible = true;
            this.colTo.VisibleIndex = 2;
            this.colTo.Width = 141;
            // 
            // exEditorGroupTo
            // 
            this.exEditorGroupTo.AutoHeight = false;
            this.exEditorGroupTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorGroupTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorGroupTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorGroupTo.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorGroupTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorGroupTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorGroupTo.Name = "exEditorGroupTo";
            // 
            // colRecipe
            // 
            this.colRecipe.AppearanceCell.Options.UseTextOptions = true;
            this.colRecipe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.AppearanceHeader.Options.UseTextOptions = true;
            this.colRecipe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRecipe.Caption = "Recipe";
            this.colRecipe.FieldName = "Recipe";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.OptionsColumn.AllowEdit = false;
            this.colRecipe.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRecipe.OptionsColumn.FixedWidth = true;
            this.colRecipe.OptionsColumn.ReadOnly = true;
            this.colRecipe.Visible = true;
            this.colRecipe.VisibleIndex = 3;
            this.colRecipe.Width = 60;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Count";
            this.gridColumn1.FieldName = "Count";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowShowHide = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 60;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(502, 53);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "분석 대상 선택";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnAddGroup);
            this.panelControl4.Controls.Add(this.cboPatternItem);
            this.panelControl4.Controls.Add(this.rdgSubject);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 21);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(498, 30);
            this.panelControl4.TabIndex = 4;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddGroup.Location = new System.Drawing.Point(401, 2);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(95, 26);
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.Text = "그룹 추가";
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // cboPatternItem
            // 
            this.cboPatternItem.Location = new System.Drawing.Point(202, 5);
            this.cboPatternItem.MenuManager = this.exBarManager;
            this.cboPatternItem.Name = "cboPatternItem";
            this.cboPatternItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPatternItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPatternItem.Size = new System.Drawing.Size(184, 20);
            this.cboPatternItem.TabIndex = 10;
            this.cboPatternItem.Visible = false;
            this.cboPatternItem.SelectedIndexChanged += new System.EventHandler(this.cboPatternItem_SelectedIndexChanged);
            // 
            // rdgSubject
            // 
            this.rdgSubject.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdgSubject.Location = new System.Drawing.Point(2, 2);
            this.rdgSubject.MenuManager = this.exBarManager;
            this.rdgSubject.Name = "rdgSubject";
            this.rdgSubject.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgSubject.Properties.Appearance.Options.UseBackColor = true;
            this.rdgSubject.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cycle Time", true, "C"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Pattern Item", true, "P")});
            this.rdgSubject.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            this.rdgSubject.Size = new System.Drawing.Size(194, 26);
            this.rdgSubject.TabIndex = 9;
            this.rdgSubject.SelectedIndexChanged += new System.EventHandler(this.rdgSubject_SelectedIndexChanged);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(506, 65);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 897);
            this.splitterControl1.TabIndex = 5;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabResult);
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(511, 65);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(573, 897);
            this.panelControl2.TabIndex = 6;
            // 
            // tabResult
            // 
            this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResult.Location = new System.Drawing.Point(2, 33);
            this.tabResult.Name = "tabResult";
            this.tabResult.SelectedTabPage = this.tpResult;
            this.tabResult.Size = new System.Drawing.Size(569, 862);
            this.tabResult.TabIndex = 1;
            this.tabResult.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpResult,
            this.tpVerify3});
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.grdStatistic);
            this.tpResult.Controls.Add(this.grpLevene);
            this.tpResult.Controls.Add(this.groupControl4);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(563, 833);
            this.tpResult.Text = "결과";
            // 
            // grdStatistic
            // 
            this.grdStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStatistic.Location = new System.Drawing.Point(0, 0);
            this.grdStatistic.MainView = this.grvStatistic;
            this.grdStatistic.MenuManager = this.exBarManager;
            this.grdStatistic.Name = "grdStatistic";
            this.grdStatistic.Size = new System.Drawing.Size(563, 337);
            this.grdStatistic.TabIndex = 5;
            this.grdStatistic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStatistic});
            // 
            // grvStatistic
            // 
            this.grvStatistic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupStatistic,
            this.colCount,
            this.colMean,
            this.colStv,
            this.colMin,
            this.colMax});
            this.grvStatistic.GridControl = this.grdStatistic;
            this.grvStatistic.Name = "grvStatistic";
            this.grvStatistic.OptionsBehavior.Editable = false;
            this.grvStatistic.OptionsBehavior.ReadOnly = true;
            this.grvStatistic.OptionsDetail.AllowZoomDetail = false;
            this.grvStatistic.OptionsDetail.EnableMasterViewMode = false;
            this.grvStatistic.OptionsDetail.ShowDetailTabs = false;
            this.grvStatistic.OptionsDetail.SmartDetailExpand = false;
            this.grvStatistic.OptionsView.ShowGroupPanel = false;
            this.grvStatistic.RowHeight = 30;
            // 
            // colGroupStatistic
            // 
            this.colGroupStatistic.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupStatistic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupStatistic.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupStatistic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupStatistic.Caption = "그룹 이름";
            this.colGroupStatistic.FieldName = "GroupName";
            this.colGroupStatistic.Name = "colGroupStatistic";
            this.colGroupStatistic.OptionsColumn.AllowEdit = false;
            this.colGroupStatistic.OptionsColumn.ReadOnly = true;
            this.colGroupStatistic.Visible = true;
            this.colGroupStatistic.VisibleIndex = 0;
            // 
            // colCount
            // 
            this.colCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.Caption = "N";
            this.colCount.FieldName = "Count";
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.ReadOnly = true;
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 1;
            // 
            // colMean
            // 
            this.colMean.AppearanceCell.Options.UseTextOptions = true;
            this.colMean.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMean.AppearanceHeader.Options.UseTextOptions = true;
            this.colMean.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMean.Caption = "평균";
            this.colMean.FieldName = "Mean";
            this.colMean.Name = "colMean";
            this.colMean.OptionsColumn.AllowEdit = false;
            this.colMean.OptionsColumn.ReadOnly = true;
            this.colMean.Visible = true;
            this.colMean.VisibleIndex = 2;
            // 
            // colStv
            // 
            this.colStv.AppearanceCell.Options.UseTextOptions = true;
            this.colStv.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStv.AppearanceHeader.Options.UseTextOptions = true;
            this.colStv.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStv.Caption = "표준 편차";
            this.colStv.FieldName = "Stv";
            this.colStv.Name = "colStv";
            this.colStv.OptionsColumn.AllowEdit = false;
            this.colStv.OptionsColumn.ReadOnly = true;
            this.colStv.Visible = true;
            this.colStv.VisibleIndex = 3;
            // 
            // colMin
            // 
            this.colMin.AppearanceCell.Options.UseTextOptions = true;
            this.colMin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMin.AppearanceHeader.Options.UseTextOptions = true;
            this.colMin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMin.Caption = "최소 값";
            this.colMin.FieldName = "Min";
            this.colMin.Name = "colMin";
            this.colMin.OptionsColumn.AllowEdit = false;
            this.colMin.OptionsColumn.ReadOnly = true;
            this.colMin.Visible = true;
            this.colMin.VisibleIndex = 4;
            // 
            // colMax
            // 
            this.colMax.AppearanceCell.Options.UseTextOptions = true;
            this.colMax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMax.AppearanceHeader.Options.UseTextOptions = true;
            this.colMax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMax.Caption = "최대 값";
            this.colMax.FieldName = "Max";
            this.colMax.Name = "colMax";
            this.colMax.OptionsColumn.AllowEdit = false;
            this.colMax.OptionsColumn.ReadOnly = true;
            this.colMax.Visible = true;
            this.colMax.VisibleIndex = 5;
            // 
            // grpLevene
            // 
            this.grpLevene.Controls.Add(this.grdLevene);
            this.grpLevene.Controls.Add(this.lblText);
            this.grpLevene.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpLevene.Location = new System.Drawing.Point(0, 337);
            this.grpLevene.Name = "grpLevene";
            this.grpLevene.Size = new System.Drawing.Size(563, 111);
            this.grpLevene.TabIndex = 6;
            this.grpLevene.Text = "분산 동질성 검정 (등분산성 검증)";
            // 
            // grdLevene
            // 
            this.grdLevene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLevene.Location = new System.Drawing.Point(2, 21);
            this.grdLevene.MainView = this.grvLevene;
            this.grdLevene.MenuManager = this.exBarManager;
            this.grdLevene.Name = "grdLevene";
            this.grdLevene.Size = new System.Drawing.Size(559, 53);
            this.grdLevene.TabIndex = 6;
            this.grdLevene.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLevene});
            // 
            // grvLevene
            // 
            this.grvLevene.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatistic,
            this.gridColumn6});
            this.grvLevene.GridControl = this.grdLevene;
            this.grvLevene.Name = "grvLevene";
            this.grvLevene.OptionsBehavior.Editable = false;
            this.grvLevene.OptionsBehavior.ReadOnly = true;
            this.grvLevene.OptionsDetail.AllowZoomDetail = false;
            this.grvLevene.OptionsDetail.EnableMasterViewMode = false;
            this.grvLevene.OptionsDetail.ShowDetailTabs = false;
            this.grvLevene.OptionsDetail.SmartDetailExpand = false;
            this.grvLevene.OptionsView.ShowGroupPanel = false;
            this.grvLevene.RowHeight = 30;
            // 
            // colStatistic
            // 
            this.colStatistic.AppearanceCell.Options.UseTextOptions = true;
            this.colStatistic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatistic.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatistic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatistic.Caption = "Levene 통계량";
            this.colStatistic.FieldName = "Statistic";
            this.colStatistic.Name = "colStatistic";
            this.colStatistic.OptionsColumn.AllowEdit = false;
            this.colStatistic.OptionsColumn.ReadOnly = true;
            this.colStatistic.Visible = true;
            this.colStatistic.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "유의확률";
            this.gridColumn6.FieldName = "PValue";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // lblText
            // 
            this.lblText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblText.Location = new System.Drawing.Point(2, 74);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(559, 35);
            this.lblText.TabIndex = 7;
            this.lblText.Text = "※  유의 확률(p-value) < 0.05 : 각 그룹 간의 분산이 동일하지 않음  → Dunnett 사후 분석 확인\r\n※  유의 확률(p-va" +
    "lue) > 0.05 : 각 그룹 간의 분산이 동일함            →  Scheffe 사후 분석 확인";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.grdAnova);
            this.groupControl4.Controls.Add(this.pnlBackground);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl4.Location = new System.Drawing.Point(0, 448);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(563, 385);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "ANOVA 결과";
            // 
            // grdAnova
            // 
            this.grdAnova.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAnova.Location = new System.Drawing.Point(2, 21);
            this.grdAnova.MainView = this.grvAnova;
            this.grdAnova.MenuManager = this.exBarManager;
            this.grdAnova.Name = "grdAnova";
            this.grdAnova.Size = new System.Drawing.Size(559, 162);
            this.grdAnova.TabIndex = 8;
            this.grdAnova.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAnova});
            // 
            // grvAnova
            // 
            this.grvAnova.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colSumSq,
            this.colDf,
            this.colMeanSq,
            this.colFValue,
            this.colPValue});
            this.grvAnova.GridControl = this.grdAnova;
            this.grvAnova.Name = "grvAnova";
            this.grvAnova.OptionsBehavior.Editable = false;
            this.grvAnova.OptionsBehavior.ReadOnly = true;
            this.grvAnova.OptionsDetail.AllowZoomDetail = false;
            this.grvAnova.OptionsDetail.EnableMasterViewMode = false;
            this.grvAnova.OptionsDetail.ShowDetailTabs = false;
            this.grvAnova.OptionsDetail.SmartDetailExpand = false;
            this.grvAnova.OptionsView.ShowGroupPanel = false;
            this.grvAnova.RowHeight = 30;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colGroup.Caption = " ";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            // 
            // colSumSq
            // 
            this.colSumSq.AppearanceCell.Options.UseTextOptions = true;
            this.colSumSq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumSq.AppearanceHeader.Options.UseTextOptions = true;
            this.colSumSq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSumSq.Caption = "제곱합";
            this.colSumSq.FieldName = "SS";
            this.colSumSq.Name = "colSumSq";
            this.colSumSq.OptionsColumn.AllowEdit = false;
            this.colSumSq.OptionsColumn.ReadOnly = true;
            this.colSumSq.Visible = true;
            this.colSumSq.VisibleIndex = 1;
            // 
            // colDf
            // 
            this.colDf.AppearanceCell.Options.UseTextOptions = true;
            this.colDf.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDf.AppearanceHeader.Options.UseTextOptions = true;
            this.colDf.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDf.Caption = "자유도";
            this.colDf.FieldName = "DF";
            this.colDf.Name = "colDf";
            this.colDf.OptionsColumn.AllowEdit = false;
            this.colDf.OptionsColumn.ReadOnly = true;
            this.colDf.Visible = true;
            this.colDf.VisibleIndex = 2;
            // 
            // colMeanSq
            // 
            this.colMeanSq.AppearanceCell.Options.UseTextOptions = true;
            this.colMeanSq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMeanSq.AppearanceHeader.Options.UseTextOptions = true;
            this.colMeanSq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMeanSq.Caption = "평균제곱";
            this.colMeanSq.FieldName = "MS";
            this.colMeanSq.Name = "colMeanSq";
            this.colMeanSq.OptionsColumn.AllowEdit = false;
            this.colMeanSq.OptionsColumn.ReadOnly = true;
            this.colMeanSq.Visible = true;
            this.colMeanSq.VisibleIndex = 3;
            // 
            // colFValue
            // 
            this.colFValue.AppearanceCell.Options.UseTextOptions = true;
            this.colFValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colFValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFValue.Caption = "거짓";
            this.colFValue.FieldName = "FValue";
            this.colFValue.Name = "colFValue";
            this.colFValue.OptionsColumn.AllowEdit = false;
            this.colFValue.OptionsColumn.ReadOnly = true;
            this.colFValue.Visible = true;
            this.colFValue.VisibleIndex = 4;
            // 
            // colPValue
            // 
            this.colPValue.AppearanceCell.Options.UseTextOptions = true;
            this.colPValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colPValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPValue.Caption = "유의확률";
            this.colPValue.FieldName = "PValue";
            this.colPValue.Name = "colPValue";
            this.colPValue.OptionsColumn.AllowEdit = false;
            this.colPValue.OptionsColumn.ReadOnly = true;
            this.colPValue.Visible = true;
            this.colPValue.VisibleIndex = 5;
            // 
            // pnlBackground
            // 
            this.pnlBackground.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlBackground.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.pnlBackground.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.pnlBackground.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBackground.Appearance.Options.UseBackColor = true;
            this.pnlBackground.Appearance.Options.UseBorderColor = true;
            this.pnlBackground.Controls.Add(this.lblDescFalse);
            this.pnlBackground.Controls.Add(this.lblDescTrue);
            this.pnlBackground.Controls.Add(this.lblResult);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBackground.Location = new System.Drawing.Point(2, 183);
            this.pnlBackground.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBackground.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBackground.MaximumSize = new System.Drawing.Size(563, 200);
            this.pnlBackground.MinimumSize = new System.Drawing.Size(563, 200);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.pnlBackground.Size = new System.Drawing.Size(563, 200);
            this.pnlBackground.TabIndex = 9;
            // 
            // lblDescFalse
            // 
            this.lblDescFalse.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescFalse.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDescFalse.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDescFalse.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescFalse.Location = new System.Drawing.Point(12, 47);
            this.lblDescFalse.Name = "lblDescFalse";
            this.lblDescFalse.Size = new System.Drawing.Size(539, 139);
            this.lblDescFalse.TabIndex = 5;
            this.lblDescFalse.Text = "유의확률(p-value)가 0.05보다 작으므로\r\n그룹 평균 간에 유의미한 차이가 있음";
            this.lblDescFalse.Visible = false;
            // 
            // lblDescTrue
            // 
            this.lblDescTrue.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescTrue.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDescTrue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDescTrue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescTrue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescTrue.Location = new System.Drawing.Point(12, 47);
            this.lblDescTrue.Name = "lblDescTrue";
            this.lblDescTrue.Size = new System.Drawing.Size(539, 139);
            this.lblDescTrue.TabIndex = 4;
            this.lblDescTrue.Text = "유의확률(p-value)가 0.05보다 크므로\r\n그룹 평균 간에 유의미한 차이가 없음";
            this.lblDescTrue.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Location = new System.Drawing.Point(12, 14);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(539, 33);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result";
            // 
            // tpVerify3
            // 
            this.tpVerify3.Controls.Add(this.panelControl3);
            this.tpVerify3.Name = "tpVerify3";
            this.tpVerify3.Size = new System.Drawing.Size(563, 833);
            this.tpVerify3.Text = "사후 분석";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.grpDunnettT3);
            this.panelControl3.Controls.Add(this.splitterControl3);
            this.panelControl3.Controls.Add(this.grpScheffe);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(563, 833);
            this.panelControl3.TabIndex = 0;
            // 
            // grpDunnettT3
            // 
            this.grpDunnettT3.Controls.Add(this.grdDunnettT3);
            this.grpDunnettT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDunnettT3.Location = new System.Drawing.Point(2, 228);
            this.grpDunnettT3.Name = "grpDunnettT3";
            this.grpDunnettT3.Size = new System.Drawing.Size(559, 603);
            this.grpDunnettT3.TabIndex = 14;
            this.grpDunnettT3.Text = "Dunnett T3 분석";
            // 
            // grdDunnettT3
            // 
            this.grdDunnettT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDunnettT3.Location = new System.Drawing.Point(2, 21);
            this.grdDunnettT3.MainView = this.grvDunnettT3;
            this.grdDunnettT3.MenuManager = this.exBarManager;
            this.grdDunnettT3.Name = "grdDunnettT3";
            this.grdDunnettT3.Size = new System.Drawing.Size(555, 580);
            this.grdDunnettT3.TabIndex = 7;
            this.grdDunnettT3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDunnettT3});
            // 
            // grvDunnettT3
            // 
            this.grvDunnettT3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDuGroup,
            this.colDiff,
            this.colLowerCI,
            this.colUpperCI});
            this.grvDunnettT3.GridControl = this.grdDunnettT3;
            this.grvDunnettT3.Name = "grvDunnettT3";
            this.grvDunnettT3.OptionsBehavior.Editable = false;
            this.grvDunnettT3.OptionsBehavior.ReadOnly = true;
            this.grvDunnettT3.OptionsDetail.AllowZoomDetail = false;
            this.grvDunnettT3.OptionsDetail.EnableMasterViewMode = false;
            this.grvDunnettT3.OptionsDetail.ShowDetailTabs = false;
            this.grvDunnettT3.OptionsDetail.SmartDetailExpand = false;
            this.grvDunnettT3.OptionsView.ShowGroupPanel = false;
            // 
            // colDuGroup
            // 
            this.colDuGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colDuGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDuGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colDuGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDuGroup.Caption = " ";
            this.colDuGroup.FieldName = "Group";
            this.colDuGroup.Name = "colDuGroup";
            this.colDuGroup.OptionsColumn.AllowEdit = false;
            this.colDuGroup.OptionsColumn.ReadOnly = true;
            this.colDuGroup.Visible = true;
            this.colDuGroup.VisibleIndex = 0;
            this.colDuGroup.Width = 120;
            // 
            // colDiff
            // 
            this.colDiff.AppearanceCell.Options.UseTextOptions = true;
            this.colDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiff.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiff.Caption = "평균오차";
            this.colDiff.FieldName = "Diff";
            this.colDiff.Name = "colDiff";
            this.colDiff.OptionsColumn.AllowEdit = false;
            this.colDiff.OptionsColumn.ReadOnly = true;
            this.colDiff.Visible = true;
            this.colDiff.VisibleIndex = 1;
            this.colDiff.Width = 135;
            // 
            // colLowerCI
            // 
            this.colLowerCI.AppearanceCell.Options.UseTextOptions = true;
            this.colLowerCI.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLowerCI.AppearanceHeader.Options.UseTextOptions = true;
            this.colLowerCI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLowerCI.Caption = "신뢰 하한값";
            this.colLowerCI.FieldName = "LowerCI";
            this.colLowerCI.Name = "colLowerCI";
            this.colLowerCI.OptionsColumn.AllowEdit = false;
            this.colLowerCI.OptionsColumn.ReadOnly = true;
            this.colLowerCI.Visible = true;
            this.colLowerCI.VisibleIndex = 2;
            this.colLowerCI.Width = 135;
            // 
            // colUpperCI
            // 
            this.colUpperCI.AppearanceCell.Options.UseTextOptions = true;
            this.colUpperCI.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpperCI.AppearanceHeader.Options.UseTextOptions = true;
            this.colUpperCI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpperCI.Caption = "신뢰 상한값";
            this.colUpperCI.FieldName = "UpperCI";
            this.colUpperCI.Name = "colUpperCI";
            this.colUpperCI.OptionsColumn.AllowEdit = false;
            this.colUpperCI.OptionsColumn.ReadOnly = true;
            this.colUpperCI.Visible = true;
            this.colUpperCI.VisibleIndex = 3;
            this.colUpperCI.Width = 141;
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl3.Location = new System.Drawing.Point(2, 223);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(559, 5);
            this.splitterControl3.TabIndex = 13;
            this.splitterControl3.TabStop = false;
            // 
            // grpScheffe
            // 
            this.grpScheffe.Controls.Add(this.grdScheffe);
            this.grpScheffe.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpScheffe.Location = new System.Drawing.Point(2, 2);
            this.grpScheffe.Name = "grpScheffe";
            this.grpScheffe.Size = new System.Drawing.Size(559, 221);
            this.grpScheffe.TabIndex = 11;
            this.grpScheffe.Text = "Scheffe 분석";
            // 
            // grdScheffe
            // 
            this.grdScheffe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdScheffe.Location = new System.Drawing.Point(2, 21);
            this.grdScheffe.MainView = this.grvScheffe;
            this.grdScheffe.MenuManager = this.exBarManager;
            this.grdScheffe.Name = "grdScheffe";
            this.grdScheffe.Size = new System.Drawing.Size(555, 198);
            this.grdScheffe.TabIndex = 6;
            this.grdScheffe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvScheffe});
            // 
            // grvScheffe
            // 
            this.grvScheffe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroupScheffe,
            this.colDiffScheffe,
            this.colSig,
            this.colPValueScheffe,
            this.colLCL,
            this.colUCL});
            this.grvScheffe.GridControl = this.grdScheffe;
            this.grvScheffe.Name = "grvScheffe";
            this.grvScheffe.OptionsBehavior.Editable = false;
            this.grvScheffe.OptionsBehavior.ReadOnly = true;
            this.grvScheffe.OptionsDetail.AllowZoomDetail = false;
            this.grvScheffe.OptionsDetail.EnableMasterViewMode = false;
            this.grvScheffe.OptionsDetail.ShowDetailTabs = false;
            this.grvScheffe.OptionsDetail.SmartDetailExpand = false;
            this.grvScheffe.OptionsView.ShowGroupPanel = false;
            // 
            // colGroupScheffe
            // 
            this.colGroupScheffe.AppearanceCell.Options.UseTextOptions = true;
            this.colGroupScheffe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupScheffe.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupScheffe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupScheffe.Caption = " ";
            this.colGroupScheffe.FieldName = "Group";
            this.colGroupScheffe.Name = "colGroupScheffe";
            this.colGroupScheffe.OptionsColumn.AllowEdit = false;
            this.colGroupScheffe.OptionsColumn.ReadOnly = true;
            this.colGroupScheffe.Visible = true;
            this.colGroupScheffe.VisibleIndex = 0;
            this.colGroupScheffe.Width = 150;
            // 
            // colDiffScheffe
            // 
            this.colDiffScheffe.AppearanceCell.Options.UseTextOptions = true;
            this.colDiffScheffe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiffScheffe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiffScheffe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiffScheffe.Caption = "평균차";
            this.colDiffScheffe.FieldName = "Diff";
            this.colDiffScheffe.Name = "colDiffScheffe";
            this.colDiffScheffe.OptionsColumn.AllowEdit = false;
            this.colDiffScheffe.OptionsColumn.ReadOnly = true;
            this.colDiffScheffe.Visible = true;
            this.colDiffScheffe.VisibleIndex = 1;
            this.colDiffScheffe.Width = 100;
            // 
            // colSig
            // 
            this.colSig.AppearanceCell.Options.UseTextOptions = true;
            this.colSig.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSig.AppearanceHeader.Options.UseTextOptions = true;
            this.colSig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSig.Caption = " ";
            this.colSig.FieldName = "Sig";
            this.colSig.Name = "colSig";
            this.colSig.OptionsColumn.AllowEdit = false;
            this.colSig.OptionsColumn.ReadOnly = true;
            this.colSig.Visible = true;
            this.colSig.VisibleIndex = 2;
            this.colSig.Width = 37;
            // 
            // colPValueScheffe
            // 
            this.colPValueScheffe.AppearanceCell.Options.UseTextOptions = true;
            this.colPValueScheffe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPValueScheffe.AppearanceHeader.Options.UseTextOptions = true;
            this.colPValueScheffe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPValueScheffe.Caption = "유의확률";
            this.colPValueScheffe.FieldName = "PValue";
            this.colPValueScheffe.Name = "colPValueScheffe";
            this.colPValueScheffe.OptionsColumn.AllowEdit = false;
            this.colPValueScheffe.OptionsColumn.ReadOnly = true;
            this.colPValueScheffe.Visible = true;
            this.colPValueScheffe.VisibleIndex = 3;
            this.colPValueScheffe.Width = 76;
            // 
            // colLCL
            // 
            this.colLCL.AppearanceCell.Options.UseTextOptions = true;
            this.colLCL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLCL.AppearanceHeader.Options.UseTextOptions = true;
            this.colLCL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLCL.Caption = "신뢰 하한값";
            this.colLCL.FieldName = "LCL";
            this.colLCL.Name = "colLCL";
            this.colLCL.OptionsColumn.AllowEdit = false;
            this.colLCL.OptionsColumn.ReadOnly = true;
            this.colLCL.Visible = true;
            this.colLCL.VisibleIndex = 4;
            this.colLCL.Width = 76;
            // 
            // colUCL
            // 
            this.colUCL.AppearanceCell.Options.UseTextOptions = true;
            this.colUCL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUCL.AppearanceHeader.Options.UseTextOptions = true;
            this.colUCL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUCL.Caption = "신뢰 상한값";
            this.colUCL.FieldName = "UCL";
            this.colUCL.Name = "colUCL";
            this.colUCL.OptionsColumn.AllowEdit = false;
            this.colUCL.OptionsColumn.ReadOnly = true;
            this.colUCL.Visible = true;
            this.colUCL.VisibleIndex = 5;
            this.colUCL.Width = 92;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.btnAnalysis);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(2, 2);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(569, 31);
            this.panelControl6.TabIndex = 0;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAnalysis.Location = new System.Drawing.Point(2, 2);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(148, 27);
            this.btnAnalysis.TabIndex = 2;
            this.btnAnalysis.Text = "통계적 분석 진행";
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmAnovaAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 962);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 2000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 1000);
            this.Name = "FrmAnovaAnalysis";
            this.Text = "통계적 분석";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnovaAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FrmAnovaAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPatternItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabResult)).EndInit();
            this.tabResult.ResumeLayout(false);
            this.tpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLevene)).EndInit();
            this.grpLevene.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLevene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLevene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAnova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.tpVerify3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDunnettT3)).EndInit();
            this.grpDunnettT3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDunnettT3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDunnettT3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpScheffe)).EndInit();
            this.grpScheffe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScheffe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScheffe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarEditItem cboProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraCharts.ChartControl exChart;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddGroup;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraTab.XtraTabControl tabResult;
        private DevExpress.XtraTab.XtraTabPage tpVerify3;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton btnAnalysis;
        private DevExpress.XtraEditors.ComboBoxEdit cboPatternItem;
        private DevExpress.XtraEditors.RadioGroup rdgSubject;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl grpScheffe;
        private DevExpress.XtraGrid.GridControl grdScheffe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvScheffe;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupScheffe;
        private DevExpress.XtraGrid.Columns.GridColumn colDiffScheffe;
        private DevExpress.XtraGrid.Columns.GridColumn colSig;
        private DevExpress.XtraGrid.Columns.GridColumn colPValueScheffe;
        private DevExpress.XtraGrid.Columns.GridColumn colLCL;
        private DevExpress.XtraGrid.Columns.GridColumn colUCL;
        private DevExpress.XtraEditors.GroupControl grpDunnettT3;
        private DevExpress.XtraGrid.GridControl grdDunnettT3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDunnettT3;
        private DevExpress.XtraGrid.Columns.GridColumn colDuGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colDiff;
        private DevExpress.XtraGrid.Columns.GridColumn colLowerCI;
        private DevExpress.XtraGrid.Columns.GridColumn colUpperCI;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraGrid.GridControl grdGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn colFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorGroupFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorGroupTo;
        private DevExpress.XtraGrid.Columns.GridColumn colRecipe;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraTab.XtraTabPage tpResult;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl grdAnova;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAnova;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colSumSq;
        private DevExpress.XtraGrid.Columns.GridColumn colDf;
        private DevExpress.XtraGrid.Columns.GridColumn colMeanSq;
        private DevExpress.XtraGrid.Columns.GridColumn colFValue;
        private DevExpress.XtraGrid.Columns.GridColumn colPValue;
        private DevExpress.XtraEditors.PanelControl pnlBackground;
        private DevExpress.XtraEditors.LabelControl lblDescFalse;
        private DevExpress.XtraEditors.LabelControl lblDescTrue;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraGrid.GridControl grdStatistic;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStatistic;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupStatistic;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colMean;
        private DevExpress.XtraGrid.Columns.GridColumn colStv;
        private DevExpress.XtraGrid.Columns.GridColumn colMin;
        private DevExpress.XtraGrid.Columns.GridColumn colMax;
        private DevExpress.XtraEditors.GroupControl grpLevene;
        private DevExpress.XtraGrid.GridControl grdLevene;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLevene;
        private DevExpress.XtraGrid.Columns.GridColumn colStatistic;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl lblText;
    }
}