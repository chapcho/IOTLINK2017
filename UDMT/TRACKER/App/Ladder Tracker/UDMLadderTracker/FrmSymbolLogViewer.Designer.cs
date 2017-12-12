namespace UDMLadderTracker
{
    partial class FrmSymbolLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolLogViewer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.cboPLC = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnShowSeries = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.spnAxisMin = new DevExpress.XtraBars.BarEditItem();
            this.exEditorMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.spnAxisMax = new DevExpress.XtraBars.BarEditItem();
            this.exEditorMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnAxisApply = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.spltMain = new DevExpress.XtraEditors.SplitterControl();
            this.ucChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            this.cntxGanttTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesChartView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSubDepthView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGanttItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSeriesTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTable = new DevExpress.XtraTab.XtraTabControl();
            this.tpCoilTable = new DevExpress.XtraTab.XtraTabPage();
            this.ucCoilTagTable = new UDMLadderTracker.UCMultiTagTable();
            this.grpStepControl = new DevExpress.XtraEditors.GroupControl();
            this.btnStepAllView = new DevExpress.XtraEditors.SimpleButton();
            this.tpAllTable = new DevExpress.XtraTab.XtraTabPage();
            this.ucTagTable = new UDMLadderTracker.UCMultiTagTable();
            this.grpTagControl = new DevExpress.XtraEditors.GroupControl();
            this.btnTagAllView = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            this.cntxGanttTreeMenu.SuspendLayout();
            this.cntxSeriesTreeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).BeginInit();
            this.tabTable.SuspendLayout();
            this.tpCoilTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStepControl)).BeginInit();
            this.grpStepControl.SuspendLayout();
            this.tpAllTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTagControl)).BeginInit();
            this.grpTagControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.dtpkTo,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.btnShow,
            this.btnExit,
            this.spnAxisMin,
            this.spnAxisMax,
            this.btnAxisApply,
            this.btnShowSeries,
            this.cboPLC,
            this.btnRefresh});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 18;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboPLC, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnShowSeries, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // cboPLC
            // 
            this.cboPLC.Caption = "PLC";
            this.cboPLC.Edit = this.exEditorPLC;
            this.cboPLC.Id = 16;
            this.cboPLC.Name = "cboPLC";
            this.cboPLC.Width = 120;
            // 
            // exEditorPLC
            // 
            this.exEditorPLC.AutoHeight = false;
            this.exEditorPLC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPLC.Name = "exEditorPLC";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 17;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 24, 21, 32, 0, 275);
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 150;
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
            // dtpkTo
            // 
            this.dtpkTo.Caption = "To";
            this.dtpkTo.Edit = this.exEditorTo;
            this.dtpkTo.EditValue = new System.DateTime(2015, 2, 24, 21, 33, 2, 912);
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 150;
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
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 9;
            this.btnShow.LargeImageIndex = 11;
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
            // 
            // btnShowSeries
            // 
            this.btnShowSeries.Caption = "Show Series";
            this.btnShowSeries.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowSeries.Glyph")));
            this.btnShowSeries.Id = 14;
            this.btnShowSeries.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowSeries.LargeGlyph")));
            this.btnShowSeries.Name = "btnShowSeries";
            this.btnShowSeries.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowSeries_ItemClick);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.lblStatus),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spnAxisMin, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.spnAxisMax, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAxisApply, true)});
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
            // spnAxisMin
            // 
            this.spnAxisMin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spnAxisMin.Caption = "Min";
            this.spnAxisMin.Edit = this.exEditorMin;
            this.spnAxisMin.Id = 11;
            this.spnAxisMin.Name = "spnAxisMin";
            this.spnAxisMin.Width = 70;
            // 
            // exEditorMin
            // 
            this.exEditorMin.AutoHeight = false;
            this.exEditorMin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorMin.Name = "exEditorMin";
            this.exEditorMin.NullText = "0";
            // 
            // spnAxisMax
            // 
            this.spnAxisMax.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.spnAxisMax.Caption = "Max";
            this.spnAxisMax.Edit = this.exEditorMax;
            this.spnAxisMax.Id = 12;
            this.spnAxisMax.Name = "spnAxisMax";
            this.spnAxisMax.Width = 70;
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
            // btnAxisApply
            // 
            this.btnAxisApply.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnAxisApply.Caption = "Apply";
            this.btnAxisApply.Id = 13;
            this.btnAxisApply.Name = "btnAxisApply";
            this.btnAxisApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAxisApply_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1333, 82);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 672);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1333, 34);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 82);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 590);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1333, 82);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 590);
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
            // exEditorColor
            // 
            this.exEditorColor.AutoHeight = false;
            this.exEditorColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColor.Name = "exEditorColor";
            // 
            // spltMain
            // 
            this.spltMain.Location = new System.Drawing.Point(378, 82);
            this.spltMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spltMain.Name = "spltMain";
            this.spltMain.Size = new System.Drawing.Size(6, 590);
            this.spltMain.TabIndex = 5;
            this.spltMain.TabStop = false;
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("Malgun Gothic", 10F);
            this.ucChart.Location = new System.Drawing.Point(384, 114);
            this.ucChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(949, 558);
            this.ucChart.TabIndex = 23;
            // 
            // cntxGanttTreeMenu
            // 
            this.cntxGanttTreeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxGanttTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesChartView,
            this.toolStripSeparator1,
            this.mnuSubDepthView,
            this.mnuGanttItemDelete});
            this.cntxGanttTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxGanttTreeMenu.Size = new System.Drawing.Size(272, 88);
            // 
            // mnuSeriesChartView
            // 
            this.mnuSeriesChartView.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesChartView.Image")));
            this.mnuSeriesChartView.Name = "mnuSeriesChartView";
            this.mnuSeriesChartView.Size = new System.Drawing.Size(271, 26);
            this.mnuSeriesChartView.Text = "선택 접점 Series Chart 보기";
            this.mnuSeriesChartView.Click += new System.EventHandler(this.mnuSeriesChartView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(268, 6);
            // 
            // mnuSubDepthView
            // 
            this.mnuSubDepthView.Image = ((System.Drawing.Image)(resources.GetObject("mnuSubDepthView.Image")));
            this.mnuSubDepthView.Name = "mnuSubDepthView";
            this.mnuSubDepthView.Size = new System.Drawing.Size(271, 26);
            this.mnuSubDepthView.Text = "선택 접점 하위 조건 보기";
            this.mnuSubDepthView.Click += new System.EventHandler(this.mnuSubDepthView_Click);
            // 
            // mnuGanttItemDelete
            // 
            this.mnuGanttItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuGanttItemDelete.Image")));
            this.mnuGanttItemDelete.Name = "mnuGanttItemDelete";
            this.mnuGanttItemDelete.Size = new System.Drawing.Size(271, 26);
            this.mnuGanttItemDelete.Text = "선택 접점 삭제";
            this.mnuGanttItemDelete.Click += new System.EventHandler(this.mnuGanttItemDelete_Click);
            // 
            // cntxSeriesTreeMenu
            // 
            this.cntxSeriesTreeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxSeriesTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesItemDelete});
            this.cntxSeriesTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxSeriesTreeMenu.Size = new System.Drawing.Size(185, 30);
            // 
            // mnuSeriesItemDelete
            // 
            this.mnuSeriesItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesItemDelete.Image")));
            this.mnuSeriesItemDelete.Name = "mnuSeriesItemDelete";
            this.mnuSeriesItemDelete.Size = new System.Drawing.Size(184, 26);
            this.mnuSeriesItemDelete.Text = "선택 접점 삭제";
            this.mnuSeriesItemDelete.Click += new System.EventHandler(this.mnuSeriesItemDelete_Click);
            // 
            // tabTable
            // 
            this.tabTable.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.tabTable.Appearance.Options.UseBackColor = true;
            this.tabTable.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabTable.Location = new System.Drawing.Point(0, 82);
            this.tabTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedTabPage = this.tpCoilTable;
            this.tabTable.Size = new System.Drawing.Size(378, 590);
            this.tabTable.TabIndex = 53;
            this.tabTable.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpCoilTable,
            this.tpAllTable});
            // 
            // tpCoilTable
            // 
            this.tpCoilTable.Controls.Add(this.ucCoilTagTable);
            this.tpCoilTable.Controls.Add(this.grpStepControl);
            this.tpCoilTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpCoilTable.Name = "tpCoilTable";
            this.tpCoilTable.Size = new System.Drawing.Size(371, 554);
            this.tpCoilTable.Text = "출력 접점";
            // 
            // ucCoilTagTable
            // 
            this.ucCoilTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCoilTagTable.Editable = true;
            this.ucCoilTagTable.Location = new System.Drawing.Point(0, 69);
            this.ucCoilTagTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucCoilTagTable.Name = "ucCoilTagTable";
            this.ucCoilTagTable.PlcLogicData = null;
            this.ucCoilTagTable.Size = new System.Drawing.Size(371, 485);
            this.ucCoilTagTable.TabIndex = 11;
            // 
            // grpStepControl
            // 
            this.grpStepControl.Controls.Add(this.btnStepAllView);
            this.grpStepControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStepControl.Location = new System.Drawing.Point(0, 0);
            this.grpStepControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpStepControl.Name = "grpStepControl";
            this.grpStepControl.Size = new System.Drawing.Size(371, 69);
            this.grpStepControl.TabIndex = 10;
            this.grpStepControl.Text = "Control";
            // 
            // btnStepAllView
            // 
            this.btnStepAllView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStepAllView.Location = new System.Drawing.Point(287, 27);
            this.btnStepAllView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStepAllView.Name = "btnStepAllView";
            this.btnStepAllView.Size = new System.Drawing.Size(82, 40);
            this.btnStepAllView.TabIndex = 0;
            this.btnStepAllView.Text = "전체 보기";
            this.btnStepAllView.ToolTip = "수집된 접점 전체 보기";
            this.btnStepAllView.Click += new System.EventHandler(this.btnStepAllView_Click);
            // 
            // tpAllTable
            // 
            this.tpAllTable.Controls.Add(this.ucTagTable);
            this.tpAllTable.Controls.Add(this.grpTagControl);
            this.tpAllTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpAllTable.Name = "tpAllTable";
            this.tpAllTable.Size = new System.Drawing.Size(371, 554);
            this.tpAllTable.Text = "모든 접점";
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTagTable.Editable = true;
            this.ucTagTable.Location = new System.Drawing.Point(0, 69);
            this.ucTagTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.PlcLogicData = null;
            this.ucTagTable.Size = new System.Drawing.Size(371, 485);
            this.ucTagTable.TabIndex = 12;
            // 
            // grpTagControl
            // 
            this.grpTagControl.Controls.Add(this.btnTagAllView);
            this.grpTagControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTagControl.Location = new System.Drawing.Point(0, 0);
            this.grpTagControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpTagControl.Name = "grpTagControl";
            this.grpTagControl.Size = new System.Drawing.Size(371, 69);
            this.grpTagControl.TabIndex = 11;
            this.grpTagControl.Text = "Control";
            // 
            // btnTagAllView
            // 
            this.btnTagAllView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTagAllView.Location = new System.Drawing.Point(287, 27);
            this.btnTagAllView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTagAllView.Name = "btnTagAllView";
            this.btnTagAllView.Size = new System.Drawing.Size(82, 40);
            this.btnTagAllView.TabIndex = 0;
            this.btnTagAllView.Text = "전체 보기";
            this.btnTagAllView.ToolTip = "수집된 접점 전체 보기";
            this.btnTagAllView.Click += new System.EventHandler(this.btnTagAllView_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(384, 82);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(949, 32);
            this.panelControl1.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.txtWordValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(220, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 28);
            this.panel2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(12, 0);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 28);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Bar Value :";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.Location = new System.Drawing.Point(79, 0);
            this.txtWordValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWordValue.MenuManager = this.exBarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(112, 24);
            this.txtWordValue.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(411, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(195, 28);
            this.panel4.TabIndex = 2;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(12, 0);
            this.lblIndicator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(69, 28);
            this.lblIndicator1.TabIndex = 4;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(81, 0);
            this.dtpkIndicator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpkIndicator1.MenuManager = this.exBarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(114, 24);
            this.dtpkIndicator1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblIndicator2);
            this.panel3.Controls.Add(this.dtpkIndicator2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(606, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 28);
            this.panel3.TabIndex = 2;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(6, 0);
            this.lblIndicator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(69, 28);
            this.lblIndicator2.TabIndex = 4;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(75, 0);
            this.dtpkIndicator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpkIndicator2.MenuManager = this.exBarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(114, 24);
            this.dtpkIndicator2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(795, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(152, 28);
            this.panel1.TabIndex = 0;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(3, 0);
            this.lblInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(64, 28);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(67, 0);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInterval.MenuManager = this.exBarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(85, 24);
            this.txtInterval.TabIndex = 3;
            // 
            // FrmSymbolLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 706);
            this.Controls.Add(this.ucChart);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.tabTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSymbolLogViewer";
            this.Text = "Symbol Log Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSymbolLogViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            this.cntxGanttTreeMenu.ResumeLayout(false);
            this.cntxSeriesTreeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).EndInit();
            this.tabTable.ResumeLayout(false);
            this.tpCoilTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpStepControl)).EndInit();
            this.grpStepControl.ResumeLayout(false);
            this.tpAllTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTagControl)).EndInit();
            this.grpTagControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
        private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
        private DevExpress.XtraEditors.SplitterControl spltMain;
		private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucChart;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private System.Windows.Forms.ContextMenuStrip cntxGanttTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuGanttItemDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesChartView;
        private System.Windows.Forms.ContextMenuStrip cntxSeriesTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesItemDelete;
        private DevExpress.XtraBars.BarEditItem spnAxisMin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMin;
        private DevExpress.XtraBars.BarEditItem spnAxisMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMax;
        private DevExpress.XtraBars.BarButtonItem btnAxisApply;
        private DevExpress.XtraBars.BarLargeButtonItem btnShowSeries;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtWordValue;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraTab.XtraTabControl tabTable;
        private DevExpress.XtraTab.XtraTabPage tpCoilTable;
        private DevExpress.XtraEditors.GroupControl grpStepControl;
        private DevExpress.XtraEditors.SimpleButton btnStepAllView;
        private DevExpress.XtraTab.XtraTabPage tpAllTable;
        private DevExpress.XtraEditors.GroupControl grpTagControl;
        private DevExpress.XtraEditors.SimpleButton btnTagAllView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSubDepthView;
        private UCMultiTagTable ucCoilTagTable;
        private UCMultiTagTable ucTagTable;
        private DevExpress.XtraBars.BarEditItem cboPLC;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
    }
}