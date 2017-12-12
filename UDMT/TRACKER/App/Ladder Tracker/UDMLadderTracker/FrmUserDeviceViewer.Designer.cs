namespace UDMLadderTracker
{
    partial class FrmUserDeviceViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserDeviceViewer));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView5 = new DevExpress.XtraCharts.LineSeriesView();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.chkDaily = new DevExpress.XtraBars.BarCheckItem();
            this.chkWeekly = new DevExpress.XtraBars.BarCheckItem();
            this.chkMonthly = new DevExpress.XtraBars.BarCheckItem();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.exEditorMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tabTable = new DevExpress.XtraTab.XtraTabControl();
            this.tpLogView = new DevExpress.XtraTab.XtraTabPage();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.ucChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdUserLog = new DevExpress.XtraGrid.GridControl();
            this.grvUserLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpTrendView = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.pnlTrendChart = new DevExpress.XtraEditors.PanelControl();
            this.exChart = new DevExpress.XtraCharts.ChartControl();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.grdAbnormal = new DevExpress.XtraGrid.GridControl();
            this.grvAbnormal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtUpperValue = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.pnlTrendControl = new DevExpress.XtraEditors.PanelControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpkDateTime = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl17 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurValue = new DevExpress.XtraEditors.TextEdit();
            this.panelControl16 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl13 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl20 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
            this.txtLower = new DevExpress.XtraEditors.TextEdit();
            this.btnApplyLower = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl10 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.txtUpper = new DevExpress.XtraEditors.TextEdit();
            this.btnApplyUpper = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl19 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpkToWhole = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl14 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkFromWhole = new DevExpress.XtraEditors.TimeEdit();
            this.panelControl15 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl18 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtMin = new DevExpress.XtraEditors.TextEdit();
            this.chkMin = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.txtAverage = new DevExpress.XtraEditors.TextEdit();
            this.chkAvr = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.txtMax = new DevExpress.XtraEditors.TextEdit();
            this.chkMax = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdUserTrend = new DevExpress.XtraGrid.GridControl();
            this.grvUserTrend = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLowerBount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpperBound = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).BeginInit();
            this.tabTable.SuspendLayout();
            this.tpLogView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserLog)).BeginInit();
            this.tpTrendView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrendChart)).BeginInit();
            this.pnlTrendChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbnormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbnormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrendControl)).BeginInit();
            this.pnlTrendControl.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
            this.panelControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            this.panelControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkToWhole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFromWhole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserTrend)).BeginInit();
            this.SuspendLayout();
            // 
            // imgListLarge
            // 
            this.imgListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLarge.ImageStream")));
            this.imgListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLarge.Images.SetKeyName(0, "ZoomIn_32x32.png");
            this.imgListLarge.Images.SetKeyName(1, "ZoomOut_32x32.png");
            this.imgListLarge.Images.SetKeyName(2, "MoveUp_32x32.png");
            this.imgListLarge.Images.SetKeyName(3, "MoveDown_32x32.png");
            this.imgListLarge.Images.SetKeyName(4, "Find_32x32.png");
            this.imgListLarge.Images.SetKeyName(5, "Clear_32x32.png");
            this.imgListLarge.Images.SetKeyName(6, "AddItem_32x32.png");
            this.imgListLarge.Images.SetKeyName(7, "DeleteList_32x32.png");
            this.imgListLarge.Images.SetKeyName(8, "SaveAll_32x32.png");
            this.imgListLarge.Images.SetKeyName(9, "Add_16x16.png");
            this.imgListLarge.Images.SetKeyName(10, "ImportCSV_32x32.png");
            this.imgListLarge.Images.SetKeyName(11, "Gantt_32x32.png");
            this.imgListLarge.Images.SetKeyName(12, "RemoveItem_32x32.png");
            this.imgListLarge.Images.SetKeyName(13, "Cancel_32x32.png");
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu,
            this.exBarStatus});
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.dtpkFrom,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnShow,
            this.btnExit,
            this.btnRefresh,
            this.chkDaily,
            this.chkWeekly,
            this.chkMonthly});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 21;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo,
            this.exEditorColor,
            this.exEditorMin,
            this.exEditorMax,
            this.exEditorPLC});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkDaily),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkWeekly),
            new DevExpress.XtraBars.LinkPersistInfo(this.chkMonthly),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 24, 21, 32, 0, 275);
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 120;
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
            // chkDaily
            // 
            this.chkDaily.Caption = "Daily";
            this.chkDaily.Id = 18;
            this.chkDaily.Name = "chkDaily";
            this.chkDaily.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkDaily_CheckedChanged);
            // 
            // chkWeekly
            // 
            this.chkWeekly.Caption = "Weekly";
            this.chkWeekly.Id = 19;
            this.chkWeekly.Name = "chkWeekly";
            this.chkWeekly.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkWeekly_CheckedChanged);
            // 
            // chkMonthly
            // 
            this.chkMonthly.BindableChecked = true;
            this.chkMonthly.Caption = "Monthly";
            this.chkMonthly.Checked = true;
            this.chkMonthly.Id = 20;
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonthly_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Apply";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 17;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 9;
            this.btnShow.LargeImageIndex = 11;
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Clear";
            this.btnClear.Id = 4;
            this.btnClear.LargeImageIndex = 12;
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Caption = "Zoom In";
            this.btnZoomIn.Id = 5;
            this.btnZoomIn.LargeImageIndex = 0;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomIn_ItemClick);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Caption = "Zoom Out";
            this.btnZoomOut.Id = 6;
            this.btnZoomOut.LargeImageIndex = 1;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnZoomOut_ItemClick);
            // 
            // btnItemUp
            // 
            this.btnItemUp.Caption = "Item Up";
            this.btnItemUp.Id = 7;
            this.btnItemUp.LargeImageIndex = 2;
            this.btnItemUp.Name = "btnItemUp";
            this.btnItemUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemUp_ItemClick);
            // 
            // btnItemDown
            // 
            this.btnItemDown.Caption = "Item Down";
            this.btnItemDown.Id = 8;
            this.btnItemDown.LargeImageIndex = 3;
            this.btnItemDown.Name = "btnItemDown";
            this.btnItemDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDown_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 10;
            this.btnExit.LargeImageIndex = 13;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // exBarStatus
            // 
            this.exBarStatus.BarName = "Status bar";
            this.exBarStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.exBarStatus.DockCol = 0;
            this.exBarStatus.DockRow = 0;
            this.exBarStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.exBarStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus)});
            this.exBarStatus.OptionsBar.AllowQuickCustomization = false;
            this.exBarStatus.OptionsBar.DrawDragBorder = false;
            this.exBarStatus.OptionsBar.UseWholeRow = true;
            this.exBarStatus.Text = "Status bar";
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1195, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 630);
            this.barDockControlBottom.Size = new System.Drawing.Size(1195, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 565);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1195, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 565);
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
            // exEditorColor
            // 
            this.exEditorColor.AutoHeight = false;
            this.exEditorColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColor.Name = "exEditorColor";
            // 
            // exEditorMin
            // 
            this.exEditorMin.AutoHeight = false;
            this.exEditorMin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMin.Name = "exEditorMin";
            this.exEditorMin.NullText = "0";
            // 
            // exEditorMax
            // 
            this.exEditorMax.AutoHeight = false;
            this.exEditorMax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMax.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorMax.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.exEditorMax.Name = "exEditorMax";
            this.exEditorMax.NullText = "10";
            // 
            // exEditorPLC
            // 
            this.exEditorPLC.AutoHeight = false;
            this.exEditorPLC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPLC.Name = "exEditorPLC";
            // 
            // tabTable
            // 
            this.tabTable.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.tabTable.Appearance.Options.UseBackColor = true;
            this.tabTable.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTable.Location = new System.Drawing.Point(0, 65);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedTabPage = this.tpLogView;
            this.tabTable.Size = new System.Drawing.Size(1195, 565);
            this.tabTable.TabIndex = 54;
            this.tabTable.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpLogView,
            this.tpTrendView});
            // 
            // tpLogView
            // 
            this.tpLogView.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpLogView.Appearance.Header.Options.UseFont = true;
            this.tpLogView.Controls.Add(this.pnlChart);
            this.tpLogView.Controls.Add(this.panelControl1);
            this.tpLogView.Controls.Add(this.splitterControl2);
            this.tpLogView.Controls.Add(this.groupControl2);
            this.tpLogView.Name = "tpLogView";
            this.tpLogView.Size = new System.Drawing.Size(1189, 532);
            this.tpLogView.Text = "Log View";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.ucChart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(304, 25);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(885, 507);
            this.pnlChart.TabIndex = 56;
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.ucChart.Location = new System.Drawing.Point(2, 2);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(881, 503);
            this.ucChart.TabIndex = 24;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(304, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(885, 25);
            this.panelControl1.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(400, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 21);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(414, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 21);
            this.panel4.TabIndex = 2;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(11, 0);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator1.TabIndex = 4;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(71, 0);
            this.dtpkIndicator1.MenuManager = this.exBarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblIndicator2);
            this.panel3.Controls.Add(this.dtpkIndicator2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(585, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 21);
            this.panel3.TabIndex = 2;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(5, 0);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(60, 21);
            this.lblIndicator2.TabIndex = 4;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(65, 0);
            this.dtpkIndicator2.MenuManager = this.exBarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(750, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 21);
            this.panel1.TabIndex = 0;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(3, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(56, 21);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(59, 0);
            this.txtInterval.MenuManager = this.exBarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(74, 20);
            this.txtInterval.TabIndex = 3;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(299, 0);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 532);
            this.splitterControl2.TabIndex = 7;
            this.splitterControl2.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grdUserLog);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(299, 532);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "User Device";
            // 
            // grdUserLog
            // 
            this.grdUserLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserLog.Location = new System.Drawing.Point(2, 25);
            this.grdUserLog.LookAndFeel.SkinName = "Office 2013";
            this.grdUserLog.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdUserLog.MainView = this.grvUserLog;
            this.grdUserLog.Name = "grdUserLog";
            this.grdUserLog.Size = new System.Drawing.Size(295, 505);
            this.grdUserLog.TabIndex = 6;
            this.grdUserLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserLog});
            // 
            // grvUserLog
            // 
            this.grvUserLog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvUserLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colAddress,
            this.colDataType});
            this.grvUserLog.GridControl = this.grdUserLog;
            this.grvUserLog.Name = "grvUserLog";
            this.grvUserLog.OptionsBehavior.Editable = false;
            this.grvUserLog.OptionsBehavior.ReadOnly = true;
            this.grvUserLog.OptionsCustomization.AllowColumnMoving = false;
            this.grvUserLog.OptionsDetail.AllowZoomDetail = false;
            this.grvUserLog.OptionsDetail.EnableMasterViewMode = false;
            this.grvUserLog.OptionsDetail.SmartDetailExpand = false;
            this.grvUserLog.OptionsSelection.MultiSelect = true;
            this.grvUserLog.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvUserLog.OptionsView.ShowGroupPanel = false;
            this.grvUserLog.OptionsView.ShowIndicator = false;
            this.grvUserLog.RowHeight = 30;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseForeColor = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseForeColor = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType.AppearanceCell.Options.UseFont = true;
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colDataType.AppearanceHeader.Options.UseFont = true;
            this.colDataType.AppearanceHeader.Options.UseForeColor = true;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            // 
            // tpTrendView
            // 
            this.tpTrendView.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTrendView.Appearance.Header.Options.UseFont = true;
            this.tpTrendView.Controls.Add(this.groupControl4);
            this.tpTrendView.Controls.Add(this.splitterControl3);
            this.tpTrendView.Controls.Add(this.groupControl3);
            this.tpTrendView.Controls.Add(this.splitterControl1);
            this.tpTrendView.Controls.Add(this.groupControl1);
            this.tpTrendView.Name = "tpTrendView";
            this.tpTrendView.Size = new System.Drawing.Size(1189, 532);
            this.tpTrendView.Text = "Trend View(Word)";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.pnlTrendChart);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(286, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(903, 373);
            this.groupControl4.TabIndex = 11;
            this.groupControl4.Text = "Chart";
            // 
            // pnlTrendChart
            // 
            this.pnlTrendChart.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlTrendChart.Appearance.Options.UseBackColor = true;
            this.pnlTrendChart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTrendChart.Controls.Add(this.exChart);
            this.pnlTrendChart.Controls.Add(this.pnlGrid);
            this.pnlTrendChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrendChart.Location = new System.Drawing.Point(2, 25);
            this.pnlTrendChart.Name = "pnlTrendChart";
            this.pnlTrendChart.Size = new System.Drawing.Size(899, 346);
            this.pnlTrendChart.TabIndex = 1;
            // 
            // exChart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "20";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.VisualRange.SideMarginsValue = 1.33333D;
            xyDiagram1.AxisX.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "50";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.WholeRange.SideMarginsValue = 3.3333333333333335D;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            this.exChart.Diagram = xyDiagram1;
            this.exChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.exChart.Location = new System.Drawing.Point(0, 0);
            this.exChart.Name = "exChart";
            this.exChart.RuntimeHitTesting = true;
            series1.Name = "Value";
            sideBySideBarSeriesView1.Color = System.Drawing.Color.DodgerBlue;
            series1.View = sideBySideBarSeriesView1;
            series2.Name = "Lower";
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(208)))), ((int)(((byte)(80)))));
            series2.View = lineSeriesView1;
            series3.Name = "Upper";
            lineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            lineSeriesView2.LineMarkerOptions.Size = 5;
            series3.View = lineSeriesView2;
            series4.Name = "Min";
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            series4.View = lineSeriesView3;
            series4.Visible = false;
            series5.Name = "Max";
            series5.View = lineSeriesView4;
            series5.Visible = false;
            series6.Name = "Avr";
            series6.View = lineSeriesView5;
            series6.Visible = false;
            this.exChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4,
        series5,
        series6};
            this.exChart.Size = new System.Drawing.Size(650, 346);
            this.exChart.TabIndex = 7;
            this.exChart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.exChart_CustomDrawCrosshair);
            this.exChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exChart_MouseDoubleClick);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlGrid.Controls.Add(this.grdAbnormal);
            this.pnlGrid.Controls.Add(this.txtUpperValue);
            this.pnlGrid.Controls.Add(this.labelControl8);
            this.pnlGrid.Controls.Add(this.labelControl1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGrid.Location = new System.Drawing.Point(650, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(249, 346);
            this.pnlGrid.TabIndex = 8;
            // 
            // grdAbnormal
            // 
            this.grdAbnormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAbnormal.Location = new System.Drawing.Point(0, 58);
            this.grdAbnormal.LookAndFeel.SkinName = "Office 2013";
            this.grdAbnormal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdAbnormal.MainView = this.grvAbnormal;
            this.grdAbnormal.Name = "grdAbnormal";
            this.grdAbnormal.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.grdAbnormal.Size = new System.Drawing.Size(249, 288);
            this.grdAbnormal.TabIndex = 7;
            this.grdAbnormal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbnormal});
            // 
            // grvAbnormal
            // 
            this.grvAbnormal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvAbnormal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTime,
            this.colValue});
            this.grvAbnormal.GridControl = this.grdAbnormal;
            this.grvAbnormal.Name = "grvAbnormal";
            this.grvAbnormal.OptionsBehavior.Editable = false;
            this.grvAbnormal.OptionsBehavior.ReadOnly = true;
            this.grvAbnormal.OptionsCustomization.AllowColumnMoving = false;
            this.grvAbnormal.OptionsDetail.AllowZoomDetail = false;
            this.grvAbnormal.OptionsDetail.EnableMasterViewMode = false;
            this.grvAbnormal.OptionsDetail.SmartDetailExpand = false;
            this.grvAbnormal.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvAbnormal.OptionsView.ShowGroupPanel = false;
            this.grvAbnormal.OptionsView.ShowIndicator = false;
            this.grvAbnormal.RowHeight = 30;
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceCell.Options.UseFont = true;
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTime.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colTime.AppearanceHeader.Options.UseFont = true;
            this.colTime.AppearanceHeader.Options.UseForeColor = true;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.ColumnEdit = this.repositoryItemTimeEdit1;
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 154;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.EditFormat.FormatString = "yyyy.MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "yyyy.MM.dd HH:mm:ss";
            this.repositoryItemTimeEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colValue.AppearanceCell.Options.UseFont = true;
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colValue.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colValue.AppearanceHeader.Options.UseFont = true;
            this.colValue.AppearanceHeader.Options.UseForeColor = true;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 95;
            // 
            // txtUpperValue
            // 
            this.txtUpperValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUpperValue.Location = new System.Drawing.Point(0, 36);
            this.txtUpperValue.MenuManager = this.exBarManager;
            this.txtUpperValue.Name = "txtUpperValue";
            this.txtUpperValue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpperValue.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtUpperValue.Properties.Appearance.Options.UseFont = true;
            this.txtUpperValue.Properties.Appearance.Options.UseForeColor = true;
            this.txtUpperValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUpperValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtUpperValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUpperValue.Size = new System.Drawing.Size(249, 22);
            this.txtUpperValue.TabIndex = 10;
            // 
            // labelControl8
            // 
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl8.Location = new System.Drawing.Point(0, 22);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(249, 14);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "Upper Value";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelControl1.Size = new System.Drawing.Size(249, 22);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Abnormal";
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl3.Location = new System.Drawing.Point(286, 373);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(903, 5);
            this.splitterControl3.TabIndex = 10;
            this.splitterControl3.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.pnlTrendControl);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl3.Location = new System.Drawing.Point(286, 378);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(903, 154);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Control";
            // 
            // pnlTrendControl
            // 
            this.pnlTrendControl.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlTrendControl.Appearance.Options.UseBackColor = true;
            this.pnlTrendControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTrendControl.Controls.Add(this.groupBox4);
            this.pnlTrendControl.Controls.Add(this.panelControl20);
            this.pnlTrendControl.Controls.Add(this.groupBox2);
            this.pnlTrendControl.Controls.Add(this.panelControl19);
            this.pnlTrendControl.Controls.Add(this.groupBox3);
            this.pnlTrendControl.Controls.Add(this.panelControl18);
            this.pnlTrendControl.Controls.Add(this.groupBox1);
            this.pnlTrendControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrendControl.Location = new System.Drawing.Point(2, 25);
            this.pnlTrendControl.Name = "pnlTrendControl";
            this.pnlTrendControl.Size = new System.Drawing.Size(899, 127);
            this.pnlTrendControl.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpkDateTime);
            this.groupBox4.Controls.Add(this.panelControl17);
            this.groupBox4.Controls.Add(this.labelControl7);
            this.groupBox4.Controls.Add(this.txtCurValue);
            this.groupBox4.Controls.Add(this.panelControl16);
            this.groupBox4.Controls.Add(this.labelControl6);
            this.groupBox4.Controls.Add(this.panelControl13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(657, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 127);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected Value Info.";
            this.groupBox4.Visible = false;
            // 
            // dtpkDateTime
            // 
            this.dtpkDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpkDateTime.EditValue = new System.DateTime(2016, 3, 14, 0, 0, 0, 0);
            this.dtpkDateTime.Location = new System.Drawing.Point(3, 86);
            this.dtpkDateTime.Name = "dtpkDateTime";
            this.dtpkDateTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDateTime.Properties.Appearance.Options.UseFont = true;
            this.dtpkDateTime.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpkDateTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpkDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkDateTime.Properties.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.dtpkDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkDateTime.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.dtpkDateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkDateTime.Properties.Mask.EditMask = "yyyy.MM.dd HH:mm";
            this.dtpkDateTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkDateTime.Properties.ReadOnly = true;
            this.dtpkDateTime.Size = new System.Drawing.Size(198, 22);
            this.dtpkDateTime.TabIndex = 13;
            // 
            // panelControl17
            // 
            this.panelControl17.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl17.Appearance.Options.UseBackColor = true;
            this.panelControl17.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl17.Location = new System.Drawing.Point(3, 81);
            this.panelControl17.Name = "panelControl17";
            this.panelControl17.Size = new System.Drawing.Size(198, 5);
            this.panelControl17.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl7.Location = new System.Drawing.Point(3, 67);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(198, 14);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Date Time";
            // 
            // txtCurValue
            // 
            this.txtCurValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCurValue.Location = new System.Drawing.Point(3, 47);
            this.txtCurValue.MenuManager = this.exBarManager;
            this.txtCurValue.Name = "txtCurValue";
            this.txtCurValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtCurValue.Properties.ReadOnly = true;
            this.txtCurValue.Size = new System.Drawing.Size(198, 20);
            this.txtCurValue.TabIndex = 10;
            // 
            // panelControl16
            // 
            this.panelControl16.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl16.Appearance.Options.UseBackColor = true;
            this.panelControl16.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl16.Location = new System.Drawing.Point(3, 42);
            this.panelControl16.Name = "panelControl16";
            this.panelControl16.Size = new System.Drawing.Size(198, 5);
            this.panelControl16.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl6.Location = new System.Drawing.Point(3, 28);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(198, 14);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Value";
            // 
            // panelControl13
            // 
            this.panelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl13.Location = new System.Drawing.Point(3, 18);
            this.panelControl13.Name = "panelControl13";
            this.panelControl13.Size = new System.Drawing.Size(198, 10);
            this.panelControl13.TabIndex = 4;
            // 
            // panelControl20
            // 
            this.panelControl20.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl20.Location = new System.Drawing.Point(636, 0);
            this.panelControl20.Name = "panelControl20";
            this.panelControl20.Size = new System.Drawing.Size(21, 127);
            this.panelControl20.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelControl11);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.panelControl10);
            this.groupBox2.Controls.Add(this.panelControl9);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.panelControl8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(432, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bound Setting";
            // 
            // panelControl11
            // 
            this.panelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl11.Controls.Add(this.txtLower);
            this.panelControl11.Controls.Add(this.btnApplyLower);
            this.panelControl11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl11.Location = new System.Drawing.Point(3, 88);
            this.panelControl11.Name = "panelControl11";
            this.panelControl11.Size = new System.Drawing.Size(198, 22);
            this.panelControl11.TabIndex = 6;
            // 
            // txtLower
            // 
            this.txtLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLower.Location = new System.Drawing.Point(0, 0);
            this.txtLower.MenuManager = this.exBarManager;
            this.txtLower.Name = "txtLower";
            this.txtLower.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtLower.Size = new System.Drawing.Size(134, 20);
            this.txtLower.TabIndex = 2;
            // 
            // btnApplyLower
            // 
            this.btnApplyLower.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApplyLower.Appearance.Options.UseBackColor = true;
            this.btnApplyLower.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApplyLower.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApplyLower.Location = new System.Drawing.Point(134, 0);
            this.btnApplyLower.LookAndFeel.SkinName = "Office 2013";
            this.btnApplyLower.Name = "btnApplyLower";
            this.btnApplyLower.Size = new System.Drawing.Size(64, 22);
            this.btnApplyLower.TabIndex = 8;
            this.btnApplyLower.Text = "Apply";
            this.btnApplyLower.Click += new System.EventHandler(this.btnApplyLower_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl3.Location = new System.Drawing.Point(3, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(198, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Lower";
            // 
            // panelControl10
            // 
            this.panelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl10.Location = new System.Drawing.Point(3, 64);
            this.panelControl10.Name = "panelControl10";
            this.panelControl10.Size = new System.Drawing.Size(198, 10);
            this.panelControl10.TabIndex = 4;
            // 
            // panelControl9
            // 
            this.panelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl9.Controls.Add(this.txtUpper);
            this.panelControl9.Controls.Add(this.btnApplyUpper);
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl9.Location = new System.Drawing.Point(3, 42);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(198, 22);
            this.panelControl9.TabIndex = 3;
            // 
            // txtUpper
            // 
            this.txtUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUpper.Location = new System.Drawing.Point(0, 0);
            this.txtUpper.MenuManager = this.exBarManager;
            this.txtUpper.Name = "txtUpper";
            this.txtUpper.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUpper.Size = new System.Drawing.Size(134, 20);
            this.txtUpper.TabIndex = 2;
            // 
            // btnApplyUpper
            // 
            this.btnApplyUpper.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApplyUpper.Appearance.Options.UseBackColor = true;
            this.btnApplyUpper.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApplyUpper.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApplyUpper.Location = new System.Drawing.Point(134, 0);
            this.btnApplyUpper.LookAndFeel.SkinName = "Office 2013";
            this.btnApplyUpper.Name = "btnApplyUpper";
            this.btnApplyUpper.Size = new System.Drawing.Size(64, 22);
            this.btnApplyUpper.TabIndex = 8;
            this.btnApplyUpper.Text = "Apply";
            this.btnApplyUpper.Click += new System.EventHandler(this.btnApplyUpper_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(3, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(198, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Upper";
            // 
            // panelControl8
            // 
            this.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl8.Location = new System.Drawing.Point(3, 18);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(198, 10);
            this.panelControl8.TabIndex = 2;
            // 
            // panelControl19
            // 
            this.panelControl19.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl19.Location = new System.Drawing.Point(411, 0);
            this.panelControl19.Name = "panelControl19";
            this.panelControl19.Size = new System.Drawing.Size(21, 127);
            this.panelControl19.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpkToWhole);
            this.groupBox3.Controls.Add(this.panelControl14);
            this.groupBox3.Controls.Add(this.labelControl4);
            this.groupBox3.Controls.Add(this.dtpkFromWhole);
            this.groupBox3.Controls.Add(this.panelControl15);
            this.groupBox3.Controls.Add(this.labelControl5);
            this.groupBox3.Controls.Add(this.panelControl12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(207, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Whole Range";
            // 
            // dtpkToWhole
            // 
            this.dtpkToWhole.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpkToWhole.EditValue = new System.DateTime(2016, 3, 14, 0, 0, 0, 0);
            this.dtpkToWhole.Location = new System.Drawing.Point(3, 88);
            this.dtpkToWhole.Name = "dtpkToWhole";
            this.dtpkToWhole.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkToWhole.Properties.Appearance.Options.UseFont = true;
            this.dtpkToWhole.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpkToWhole.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpkToWhole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkToWhole.Properties.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.dtpkToWhole.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkToWhole.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.dtpkToWhole.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkToWhole.Properties.Mask.EditMask = "yyyy.MM.dd";
            this.dtpkToWhole.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkToWhole.Properties.ReadOnly = true;
            this.dtpkToWhole.Size = new System.Drawing.Size(198, 22);
            this.dtpkToWhole.TabIndex = 12;
            // 
            // panelControl14
            // 
            this.panelControl14.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl14.Appearance.Options.UseBackColor = true;
            this.panelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl14.Location = new System.Drawing.Point(3, 83);
            this.panelControl14.Name = "panelControl14";
            this.panelControl14.Size = new System.Drawing.Size(198, 5);
            this.panelControl14.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl4.Location = new System.Drawing.Point(3, 69);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(198, 14);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "To";
            // 
            // dtpkFromWhole
            // 
            this.dtpkFromWhole.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpkFromWhole.EditValue = new System.DateTime(2016, 3, 14, 0, 0, 0, 0);
            this.dtpkFromWhole.Location = new System.Drawing.Point(3, 47);
            this.dtpkFromWhole.Name = "dtpkFromWhole";
            this.dtpkFromWhole.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFromWhole.Properties.Appearance.Options.UseFont = true;
            this.dtpkFromWhole.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpkFromWhole.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpkFromWhole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkFromWhole.Properties.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.dtpkFromWhole.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkFromWhole.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.dtpkFromWhole.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpkFromWhole.Properties.Mask.EditMask = "yyyy.MM.dd";
            this.dtpkFromWhole.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkFromWhole.Properties.ReadOnly = true;
            this.dtpkFromWhole.Size = new System.Drawing.Size(198, 22);
            this.dtpkFromWhole.TabIndex = 9;
            // 
            // panelControl15
            // 
            this.panelControl15.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl15.Appearance.Options.UseBackColor = true;
            this.panelControl15.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl15.Location = new System.Drawing.Point(3, 42);
            this.panelControl15.Name = "panelControl15";
            this.panelControl15.Size = new System.Drawing.Size(198, 5);
            this.panelControl15.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl5.Location = new System.Drawing.Point(3, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(198, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "From";
            // 
            // panelControl12
            // 
            this.panelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl12.Location = new System.Drawing.Point(3, 18);
            this.panelControl12.Name = "panelControl12";
            this.panelControl12.Size = new System.Drawing.Size(198, 10);
            this.panelControl12.TabIndex = 3;
            // 
            // panelControl18
            // 
            this.panelControl18.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl18.Location = new System.Drawing.Point(186, 0);
            this.panelControl18.Name = "panelControl18";
            this.panelControl18.Size = new System.Drawing.Size(21, 127);
            this.panelControl18.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelControl2);
            this.groupBox1.Controls.Add(this.panelControl7);
            this.groupBox1.Controls.Add(this.panelControl6);
            this.groupBox1.Controls.Add(this.panelControl5);
            this.groupBox1.Controls.Add(this.panelControl4);
            this.groupBox1.Controls.Add(this.panelControl3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistic";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.txtMin);
            this.panelControl2.Controls.Add(this.chkMin);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(3, 92);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(180, 22);
            this.panelControl2.TabIndex = 0;
            // 
            // txtMin
            // 
            this.txtMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMin.Location = new System.Drawing.Point(75, 0);
            this.txtMin.MenuManager = this.exBarManager;
            this.txtMin.Name = "txtMin";
            this.txtMin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMin.Properties.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(105, 20);
            this.txtMin.TabIndex = 1;
            // 
            // chkMin
            // 
            this.chkMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkMin.Location = new System.Drawing.Point(0, 0);
            this.chkMin.MenuManager = this.exBarManager;
            this.chkMin.Name = "chkMin";
            this.chkMin.Properties.Caption = "Min";
            this.chkMin.Size = new System.Drawing.Size(75, 19);
            this.chkMin.TabIndex = 0;
            this.chkMin.CheckedChanged += new System.EventHandler(this.chkMin_CheckedChanged);
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(3, 82);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(180, 10);
            this.panelControl7.TabIndex = 5;
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.txtAverage);
            this.panelControl6.Controls.Add(this.chkAvr);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(3, 60);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(180, 22);
            this.panelControl6.TabIndex = 4;
            // 
            // txtAverage
            // 
            this.txtAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAverage.Location = new System.Drawing.Point(75, 0);
            this.txtAverage.MenuManager = this.exBarManager;
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtAverage.Properties.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(105, 20);
            this.txtAverage.TabIndex = 1;
            // 
            // chkAvr
            // 
            this.chkAvr.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAvr.Location = new System.Drawing.Point(0, 0);
            this.chkAvr.MenuManager = this.exBarManager;
            this.chkAvr.Name = "chkAvr";
            this.chkAvr.Properties.Caption = "Average";
            this.chkAvr.Size = new System.Drawing.Size(75, 19);
            this.chkAvr.TabIndex = 0;
            this.chkAvr.CheckedChanged += new System.EventHandler(this.chkAvr_CheckedChanged);
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(3, 50);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(180, 10);
            this.panelControl5.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.txtMax);
            this.panelControl4.Controls.Add(this.chkMax);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(3, 28);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(180, 22);
            this.panelControl4.TabIndex = 2;
            // 
            // txtMax
            // 
            this.txtMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMax.Location = new System.Drawing.Point(75, 0);
            this.txtMax.MenuManager = this.exBarManager;
            this.txtMax.Name = "txtMax";
            this.txtMax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtMax.Properties.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(105, 20);
            this.txtMax.TabIndex = 1;
            // 
            // chkMax
            // 
            this.chkMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkMax.Location = new System.Drawing.Point(0, 0);
            this.chkMax.MenuManager = this.exBarManager;
            this.chkMax.Name = "chkMax";
            this.chkMax.Properties.Caption = "Max";
            this.chkMax.Size = new System.Drawing.Size(75, 19);
            this.chkMax.TabIndex = 0;
            this.chkMax.CheckedChanged += new System.EventHandler(this.chkMax_CheckedChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(3, 18);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(180, 10);
            this.panelControl3.TabIndex = 1;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(281, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 532);
            this.splitterControl1.TabIndex = 8;
            this.splitterControl1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdUserTrend);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(281, 532);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "User Device (Word)";
            // 
            // grdUserTrend
            // 
            this.grdUserTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserTrend.Location = new System.Drawing.Point(2, 25);
            this.grdUserTrend.LookAndFeel.SkinName = "Office 2013";
            this.grdUserTrend.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdUserTrend.MainView = this.grvUserTrend;
            this.grdUserTrend.Name = "grdUserTrend";
            this.grdUserTrend.Size = new System.Drawing.Size(277, 505);
            this.grdUserTrend.TabIndex = 6;
            this.grdUserTrend.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserTrend});
            // 
            // grvUserTrend
            // 
            this.grvUserTrend.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvUserTrend.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName2,
            this.colAddress2,
            this.colDataType2,
            this.colLowerBount,
            this.colUpperBound});
            this.grvUserTrend.GridControl = this.grdUserTrend;
            this.grvUserTrend.Name = "grvUserTrend";
            this.grvUserTrend.OptionsBehavior.Editable = false;
            this.grvUserTrend.OptionsBehavior.ReadOnly = true;
            this.grvUserTrend.OptionsCustomization.AllowColumnMoving = false;
            this.grvUserTrend.OptionsDetail.AllowZoomDetail = false;
            this.grvUserTrend.OptionsDetail.EnableMasterViewMode = false;
            this.grvUserTrend.OptionsDetail.SmartDetailExpand = false;
            this.grvUserTrend.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvUserTrend.OptionsView.ShowGroupPanel = false;
            this.grvUserTrend.OptionsView.ShowIndicator = false;
            this.grvUserTrend.RowHeight = 30;
            this.grvUserTrend.DoubleClick += new System.EventHandler(this.grvUserTrend_DoubleClick);
            // 
            // colName2
            // 
            this.colName2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName2.AppearanceCell.Options.UseFont = true;
            this.colName2.AppearanceCell.Options.UseTextOptions = true;
            this.colName2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName2.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colName2.AppearanceHeader.Options.UseFont = true;
            this.colName2.AppearanceHeader.Options.UseForeColor = true;
            this.colName2.AppearanceHeader.Options.UseTextOptions = true;
            this.colName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName2.Caption = "Name";
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 0;
            this.colName2.Width = 72;
            // 
            // colAddress2
            // 
            this.colAddress2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress2.AppearanceCell.Options.UseFont = true;
            this.colAddress2.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress2.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colAddress2.AppearanceHeader.Options.UseFont = true;
            this.colAddress2.AppearanceHeader.Options.UseForeColor = true;
            this.colAddress2.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress2.Caption = "Address";
            this.colAddress2.FieldName = "Address";
            this.colAddress2.Name = "colAddress2";
            this.colAddress2.Visible = true;
            this.colAddress2.VisibleIndex = 1;
            this.colAddress2.Width = 72;
            // 
            // colDataType2
            // 
            this.colDataType2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType2.AppearanceCell.Options.UseFont = true;
            this.colDataType2.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDataType2.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colDataType2.AppearanceHeader.Options.UseFont = true;
            this.colDataType2.AppearanceHeader.Options.UseForeColor = true;
            this.colDataType2.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType2.Caption = "DataType";
            this.colDataType2.FieldName = "DataType";
            this.colDataType2.Name = "colDataType2";
            this.colDataType2.Width = 79;
            // 
            // colLowerBount
            // 
            this.colLowerBount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLowerBount.AppearanceCell.Options.UseFont = true;
            this.colLowerBount.AppearanceCell.Options.UseTextOptions = true;
            this.colLowerBount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLowerBount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLowerBount.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colLowerBount.AppearanceHeader.Options.UseFont = true;
            this.colLowerBount.AppearanceHeader.Options.UseForeColor = true;
            this.colLowerBount.AppearanceHeader.Options.UseTextOptions = true;
            this.colLowerBount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLowerBount.Caption = "Lower";
            this.colLowerBount.FieldName = "LowerBound";
            this.colLowerBount.Name = "colLowerBount";
            this.colLowerBount.Visible = true;
            this.colLowerBount.VisibleIndex = 2;
            this.colLowerBount.Width = 68;
            // 
            // colUpperBound
            // 
            this.colUpperBound.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUpperBound.AppearanceCell.Options.UseFont = true;
            this.colUpperBound.AppearanceCell.Options.UseTextOptions = true;
            this.colUpperBound.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpperBound.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUpperBound.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colUpperBound.AppearanceHeader.Options.UseFont = true;
            this.colUpperBound.AppearanceHeader.Options.UseForeColor = true;
            this.colUpperBound.AppearanceHeader.Options.UseTextOptions = true;
            this.colUpperBound.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpperBound.Caption = "Upper";
            this.colUpperBound.FieldName = "UpperBound";
            this.colUpperBound.Name = "colUpperBound";
            this.colUpperBound.Visible = true;
            this.colUpperBound.VisibleIndex = 3;
            this.colUpperBound.Width = 73;
            // 
            // FrmUserDeviceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 655);
            this.Controls.Add(this.tabTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUserDeviceViewer";
            this.Text = "User Device Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUserDeviceViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).EndInit();
            this.tabTable.ResumeLayout(false);
            this.tpLogView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserLog)).EndInit();
            this.tpTrendView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrendChart)).EndInit();
            this.pnlTrendChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbnormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbnormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpperValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTrendControl)).EndInit();
            this.pnlTrendControl.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
            this.panelControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            this.panelControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUpper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkToWhole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFromWhole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAvr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserTrend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMax;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private DevExpress.XtraTab.XtraTabControl tabTable;
        private DevExpress.XtraTab.XtraTabPage tpLogView;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraTab.XtraTabPage tpTrendView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucChart;
        private DevExpress.XtraGrid.GridControl grdUserLog;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserLog;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdUserTrend;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserTrend;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress2;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType2;
        private DevExpress.XtraGrid.Columns.GridColumn colLowerBount;
        private DevExpress.XtraGrid.Columns.GridColumn colUpperBound;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl pnlTrendControl;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.PanelControl pnlTrendChart;
        private DevExpress.XtraCharts.ChartControl exChart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtMin;
        private DevExpress.XtraEditors.CheckEdit chkMin;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.TextEdit txtAverage;
        private DevExpress.XtraEditors.CheckEdit chkAvr;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtMax;
        private DevExpress.XtraEditors.CheckEdit chkMax;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl9;
        private DevExpress.XtraEditors.TextEdit txtUpper;
        private DevExpress.XtraEditors.SimpleButton btnApplyUpper;
        private DevExpress.XtraEditors.PanelControl panelControl13;
        private DevExpress.XtraEditors.PanelControl panelControl12;
        private DevExpress.XtraEditors.PanelControl panelControl11;
        private DevExpress.XtraEditors.TextEdit txtLower;
        private DevExpress.XtraEditors.SimpleButton btnApplyLower;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl10;
        private DevExpress.XtraEditors.TimeEdit dtpkDateTime;
        private DevExpress.XtraEditors.PanelControl panelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtCurValue;
        private DevExpress.XtraEditors.PanelControl panelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl20;
        private DevExpress.XtraEditors.PanelControl panelControl19;
        private DevExpress.XtraEditors.TimeEdit dtpkToWhole;
        private DevExpress.XtraEditors.PanelControl panelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TimeEdit dtpkFromWhole;
        private DevExpress.XtraEditors.PanelControl panelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl18;
        private DevExpress.XtraBars.BarCheckItem chkDaily;
        private DevExpress.XtraBars.BarCheckItem chkWeekly;
        private DevExpress.XtraBars.BarCheckItem chkMonthly;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl grdAbnormal;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbnormal;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUpperValue;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
    }
}