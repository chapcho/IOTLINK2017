namespace UDMPresenter
{
	partial class FrmTimeChartViewer
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimeChartViewer));
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnZoomIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnZoomOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemUp = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnItemDown = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.cntxGanttTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowSeriesChart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGridGantMenuSplitter4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSubDepthView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGanttItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSeriesTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tpTagTable = new DevExpress.XtraTab.XtraTabPage();
            this.ucTagTable = new UDMPresenter.UCTagTable();
            this.grpTagControl = new DevExpress.XtraEditors.GroupControl();
            this.btnTagAllView = new DevExpress.XtraEditors.SimpleButton();
            this.tpStepTable = new DevExpress.XtraTab.XtraTabPage();
            this.grdCoilTagList = new DevExpress.XtraGrid.GridControl();
            this.grvCoilTagList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetworkNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grpStepControl = new DevExpress.XtraEditors.GroupControl();
            this.btnStepAllView = new DevExpress.XtraEditors.SimpleButton();
            this.tabTable = new DevExpress.XtraTab.XtraTabControl();
            this.spltMain = new DevExpress.XtraEditors.SplitterControl();
            this.pnlTimeInfo = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWordValue = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.pnlIndicator1 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.pnlIndicator2 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.pnlInterval = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.ucTimeChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.cntxGanttTreeMenu.SuspendLayout();
            this.cntxSeriesTreeMenu.SuspendLayout();
            this.tpTagTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTagControl)).BeginInit();
            this.grpTagControl.SuspendLayout();
            this.tpStepTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoilTagList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCoilTagList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStepControl)).BeginInit();
            this.grpStepControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).BeginInit();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeInfo)).BeginInit();
            this.pnlTimeInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.pnlIndicator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.pnlIndicator2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.pnlInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // exBarManager
            // 
            this.exBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.exBarMenu,
            this.exBarStatus});
            this.exBarManager.Controller = this.barAndDockingController1;
            this.exBarManager.DockControls.Add(this.barDockControlTop);
            this.exBarManager.DockControls.Add(this.barDockControlBottom);
            this.exBarManager.DockControls.Add(this.barDockControlLeft);
            this.exBarManager.DockControls.Add(this.barDockControlRight);
            this.exBarManager.Form = this;
            this.exBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblStatus,
            this.btnShow,
            this.dtpkFrom,
            this.dtpkTo,
            this.btnClear,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnItemUp,
            this.btnItemDown,
            this.barButtonItem1});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 10;
            this.exBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFrom,
            this.exEditorTo});
            this.exBarManager.StatusBar = this.exBarStatus;
            // 
            // exBarMenu
            // 
            this.exBarMenu.BarName = "Tools";
            this.exBarMenu.DockCol = 0;
            this.exBarMenu.DockRow = 0;
            this.exBarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.exBarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItemDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 10, 8, 15, 30, 42, 894);
            this.dtpkFrom.Id = 2;
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Width = 120;
            // 
            // exEditorFrom
            // 
            this.exEditorFrom.AutoHeight = false;
            this.exEditorFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            this.dtpkTo.EditValue = new System.DateTime(2015, 10, 8, 15, 31, 44, 382);
            this.dtpkTo.Id = 3;
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Width = 120;
            // 
            // exEditorTo
            // 
            this.exEditorTo.AutoHeight = false;
            this.exEditorTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTo.Name = "exEditorTo";
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
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 1;
            this.btnShow.LargeImageIndex = 14;
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
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 705);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 640);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 640);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "\r\nZoom In";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.LargeImageIndex = 0;
            this.barButtonItem1.Name = "barButtonItem1";
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
            this.imgListLarge.Images.SetKeyName(13, "Grid_32x32.png");
            this.imgListLarge.Images.SetKeyName(14, "Refresh_32x32.png");
            this.imgListLarge.Images.SetKeyName(15, "Cancel_32x32.png");
            // 
            // cntxGanttTreeMenu
            // 
            this.cntxGanttTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowSeriesChart,
            this.mnuGridGantMenuSplitter4,
            this.mnuItemSubDepthView,
            this.mnuGanttItemDelete});
            this.cntxGanttTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxGanttTreeMenu.Size = new System.Drawing.Size(235, 76);
            // 
            // mnuShowSeriesChart
            // 
            this.mnuShowSeriesChart.Image = ((System.Drawing.Image)(resources.GetObject("mnuShowSeriesChart.Image")));
            this.mnuShowSeriesChart.Name = "mnuShowSeriesChart";
            this.mnuShowSeriesChart.Size = new System.Drawing.Size(234, 22);
            this.mnuShowSeriesChart.Text = "선택된 접점 Series Chart 보기";
            this.mnuShowSeriesChart.Click += new System.EventHandler(this.mnuShowSeriesChart_Click);
            // 
            // mnuGridGantMenuSplitter4
            // 
            this.mnuGridGantMenuSplitter4.Name = "mnuGridGantMenuSplitter4";
            this.mnuGridGantMenuSplitter4.Size = new System.Drawing.Size(231, 6);
            this.mnuGridGantMenuSplitter4.Visible = false;
            // 
            // mnuItemSubDepthView
            // 
            this.mnuItemSubDepthView.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSubDepthView.Image")));
            this.mnuItemSubDepthView.Name = "mnuItemSubDepthView";
            this.mnuItemSubDepthView.Size = new System.Drawing.Size(234, 22);
            this.mnuItemSubDepthView.Text = "선택 접점 하위 조건 보기";
            this.mnuItemSubDepthView.Click += new System.EventHandler(this.mnuItemSubDepthView_Click);
            // 
            // mnuGanttItemDelete
            // 
            this.mnuGanttItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuGanttItemDelete.Image")));
            this.mnuGanttItemDelete.Name = "mnuGanttItemDelete";
            this.mnuGanttItemDelete.Size = new System.Drawing.Size(234, 22);
            this.mnuGanttItemDelete.Text = "선택 접점 삭제";
            this.mnuGanttItemDelete.Click += new System.EventHandler(this.mnuGanttItemDelete_Click);
            // 
            // cntxSeriesTreeMenu
            // 
            this.cntxSeriesTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesItemDelete});
            this.cntxSeriesTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxSeriesTreeMenu.Size = new System.Drawing.Size(155, 26);
            // 
            // mnuSeriesItemDelete
            // 
            this.mnuSeriesItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesItemDelete.Image")));
            this.mnuSeriesItemDelete.Name = "mnuSeriesItemDelete";
            this.mnuSeriesItemDelete.Size = new System.Drawing.Size(154, 22);
            this.mnuSeriesItemDelete.Text = "선택 접점 삭제";
            this.mnuSeriesItemDelete.Click += new System.EventHandler(this.mnuSeriesItemDelete_Click);
            // 
            // tpTagTable
            // 
            this.tpTagTable.Controls.Add(this.ucTagTable);
            this.tpTagTable.Controls.Add(this.grpTagControl);
            this.tpTagTable.Name = "tpTagTable";
            this.tpTagTable.Size = new System.Drawing.Size(306, 611);
            this.tpTagTable.Text = "Tag List";
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTagTable.Editable = true;
            this.ucTagTable.Location = new System.Drawing.Point(0, 54);
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.Size = new System.Drawing.Size(306, 557);
            this.ucTagTable.TabIndex = 11;
            // 
            // grpTagControl
            // 
            this.grpTagControl.Controls.Add(this.btnTagAllView);
            this.grpTagControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTagControl.Location = new System.Drawing.Point(0, 0);
            this.grpTagControl.Name = "grpTagControl";
            this.grpTagControl.Size = new System.Drawing.Size(306, 54);
            this.grpTagControl.TabIndex = 10;
            this.grpTagControl.Text = "Control";
            // 
            // btnTagAllView
            // 
            this.btnTagAllView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTagAllView.Location = new System.Drawing.Point(232, 21);
            this.btnTagAllView.Name = "btnTagAllView";
            this.btnTagAllView.Size = new System.Drawing.Size(72, 31);
            this.btnTagAllView.TabIndex = 0;
            this.btnTagAllView.Text = "전체 보기";
            this.btnTagAllView.ToolTip = "수집된 접점 전체 보기";
            this.btnTagAllView.Click += new System.EventHandler(this.btnTagAllView_Click);
            // 
            // tpStepTable
            // 
            this.tpStepTable.Controls.Add(this.grdCoilTagList);
            this.tpStepTable.Controls.Add(this.grpStepControl);
            this.tpStepTable.Name = "tpStepTable";
            this.tpStepTable.Size = new System.Drawing.Size(306, 611);
            this.tpStepTable.Text = "Step List";
            // 
            // grdCoilTagList
            // 
            this.grdCoilTagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCoilTagList.Location = new System.Drawing.Point(0, 54);
            this.grdCoilTagList.MainView = this.grvCoilTagList;
            this.grdCoilTagList.Name = "grdCoilTagList";
            this.grdCoilTagList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdCoilTagList.Size = new System.Drawing.Size(306, 557);
            this.grdCoilTagList.TabIndex = 10;
            this.grdCoilTagList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCoilTagList});
            // 
            // grvCoilTagList
            // 
            this.grvCoilTagList.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvCoilTagList.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvCoilTagList.ColumnPanelRowHeight = 35;
            this.grvCoilTagList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelect,
            this.colAddress,
            this.colDescription,
            this.colDataType,
            this.colProgram,
            this.colNetworkNum,
            this.colStep,
            this.colCommand});
            this.grvCoilTagList.GridControl = this.grdCoilTagList;
            this.grvCoilTagList.IndicatorWidth = 50;
            this.grvCoilTagList.Name = "grvCoilTagList";
            this.grvCoilTagList.OptionsDetail.EnableMasterViewMode = false;
            this.grvCoilTagList.OptionsDetail.ShowDetailTabs = false;
            this.grvCoilTagList.OptionsDetail.SmartDetailExpand = false;
            this.grvCoilTagList.OptionsSelection.MultiSelect = true;
            this.grvCoilTagList.OptionsView.ShowAutoFilterRow = true;
            this.grvCoilTagList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvCoilTagList_CustomDrawRowIndicator);
            // 
            // colIsSelect
            // 
            this.colIsSelect.AppearanceCell.Options.UseTextOptions = true;
            this.colIsSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSelect.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colIsSelect.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsSelect.Caption = "Used";
            this.colIsSelect.ColumnEdit = this.exEditorCheckBox;
            this.colIsSelect.FieldName = "CoilCollectUsed";
            this.colIsSelect.MinWidth = 40;
            this.colIsSelect.Name = "colIsSelect";
            this.colIsSelect.OptionsColumn.FixedWidth = true;
            this.colIsSelect.OptionsColumn.ReadOnly = true;
            this.colIsSelect.Visible = true;
            this.colIsSelect.VisibleIndex = 0;
            this.colIsSelect.Width = 40;
            // 
            // exEditorCheckBox
            // 
            this.exEditorCheckBox.AutoHeight = false;
            this.exEditorCheckBox.Name = "exEditorCheckBox";
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "CoilAddress";
            this.colAddress.MinWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDescription.Caption = "Label / Description";
            this.colDescription.FieldName = "CoilComment";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 100;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDataType.Caption = "Data Type";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "CoilDataType";
            this.colDataType.MinWidth = 70;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowFocus = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            this.colDataType.Width = 70;
            // 
            // exEditorDataType
            // 
            this.exEditorDataType.AutoHeight = false;
            this.exEditorDataType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDataType.Items.AddRange(new object[] {
            "Bool",
            "Word",
            "DWord"});
            this.exEditorDataType.Name = "exEditorDataType";
            // 
            // colProgram
            // 
            this.colProgram.AppearanceCell.Options.UseTextOptions = true;
            this.colProgram.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.Caption = "Program";
            this.colProgram.FieldName = "Program";
            this.colProgram.MinWidth = 100;
            this.colProgram.Name = "colProgram";
            this.colProgram.OptionsColumn.AllowEdit = false;
            this.colProgram.OptionsColumn.AllowFocus = false;
            this.colProgram.OptionsColumn.ReadOnly = true;
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 5;
            this.colProgram.Width = 100;
            // 
            // colNetworkNum
            // 
            this.colNetworkNum.AppearanceCell.Options.UseTextOptions = true;
            this.colNetworkNum.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNetworkNum.AppearanceHeader.Options.UseTextOptions = true;
            this.colNetworkNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNetworkNum.Caption = "Network";
            this.colNetworkNum.FieldName = "NetworkNumber";
            this.colNetworkNum.MinWidth = 30;
            this.colNetworkNum.Name = "colNetworkNum";
            this.colNetworkNum.OptionsColumn.AllowEdit = false;
            this.colNetworkNum.OptionsColumn.AllowFocus = false;
            this.colNetworkNum.OptionsColumn.ReadOnly = true;
            this.colNetworkNum.Visible = true;
            this.colNetworkNum.VisibleIndex = 6;
            this.colNetworkNum.Width = 30;
            // 
            // colStep
            // 
            this.colStep.AppearanceCell.Options.UseTextOptions = true;
            this.colStep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStep.AppearanceHeader.Options.UseTextOptions = true;
            this.colStep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStep.Caption = "Step";
            this.colStep.FieldName = "StepNumber";
            this.colStep.Name = "colStep";
            this.colStep.OptionsColumn.AllowEdit = false;
            this.colStep.OptionsColumn.AllowFocus = false;
            this.colStep.OptionsColumn.ReadOnly = true;
            this.colStep.Visible = true;
            this.colStep.VisibleIndex = 7;
            this.colStep.Width = 20;
            // 
            // colCommand
            // 
            this.colCommand.AppearanceCell.Options.UseTextOptions = true;
            this.colCommand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommand.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommand.Caption = "Command";
            this.colCommand.FieldName = "Command";
            this.colCommand.MinWidth = 100;
            this.colCommand.Name = "colCommand";
            this.colCommand.OptionsColumn.ReadOnly = true;
            this.colCommand.Visible = true;
            this.colCommand.VisibleIndex = 2;
            this.colCommand.Width = 100;
            // 
            // exEditorCreatorType
            // 
            this.exEditorCreatorType.AutoHeight = false;
            this.exEditorCreatorType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorCreatorType.Items.AddRange(new object[] {
            "ByLogic",
            "ByUser"});
            this.exEditorCreatorType.Name = "exEditorCreatorType";
            // 
            // exEditorFeatureType
            // 
            this.exEditorFeatureType.AutoHeight = false;
            this.exEditorFeatureType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorFeatureType.Items.AddRange(new object[] {
            "None",
            "AlwaysOn",
            "AlwaysOff",
            "ManualOperation",
            "NotAccessable"});
            this.exEditorFeatureType.Name = "exEditorFeatureType";
            // 
            // exEditorConfigMDC
            // 
            this.exEditorConfigMDC.AutoHeight = false;
            this.exEditorConfigMDC.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "설정", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.exEditorConfigMDC.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.exEditorConfigMDC.Name = "exEditorConfigMDC";
            this.exEditorConfigMDC.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grpStepControl
            // 
            this.grpStepControl.Controls.Add(this.btnStepAllView);
            this.grpStepControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStepControl.Location = new System.Drawing.Point(0, 0);
            this.grpStepControl.Name = "grpStepControl";
            this.grpStepControl.Size = new System.Drawing.Size(306, 54);
            this.grpStepControl.TabIndex = 9;
            this.grpStepControl.Text = "Control";
            // 
            // btnStepAllView
            // 
            this.btnStepAllView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStepAllView.Location = new System.Drawing.Point(232, 21);
            this.btnStepAllView.Name = "btnStepAllView";
            this.btnStepAllView.Size = new System.Drawing.Size(72, 31);
            this.btnStepAllView.TabIndex = 0;
            this.btnStepAllView.Text = "전체 보기";
            this.btnStepAllView.ToolTip = "수집된 접점 전체 보기";
            this.btnStepAllView.Click += new System.EventHandler(this.btnStepAllView_Click);
            // 
            // tabTable
            // 
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabTable.Location = new System.Drawing.Point(0, 65);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedTabPage = this.tpStepTable;
            this.tabTable.Size = new System.Drawing.Size(312, 640);
            this.tabTable.TabIndex = 21;
            this.tabTable.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpStepTable,
            this.tpTagTable});
            // 
            // spltMain
            // 
            this.spltMain.Location = new System.Drawing.Point(312, 65);
            this.spltMain.Name = "spltMain";
            this.spltMain.Size = new System.Drawing.Size(5, 640);
            this.spltMain.TabIndex = 22;
            this.spltMain.TabStop = false;
            // 
            // pnlTimeInfo
            // 
            this.pnlTimeInfo.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlTimeInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTimeInfo.Controls.Add(this.panel1);
            this.pnlTimeInfo.Controls.Add(this.pnlIndicator1);
            this.pnlTimeInfo.Controls.Add(this.pnlIndicator2);
            this.pnlTimeInfo.Controls.Add(this.pnlInterval);
            this.pnlTimeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimeInfo.Location = new System.Drawing.Point(317, 65);
            this.pnlTimeInfo.Name = "pnlTimeInfo";
            this.pnlTimeInfo.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.pnlTimeInfo.Size = new System.Drawing.Size(691, 37);
            this.pnlTimeInfo.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWordValue);
            this.panel1.Controls.Add(this.txtWordValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(30, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 22);
            this.panel1.TabIndex = 6;
            // 
            // lblWordValue
            // 
            this.lblWordValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblWordValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblWordValue.Location = new System.Drawing.Point(16, 0);
            this.lblWordValue.Name = "lblWordValue";
            this.lblWordValue.Size = new System.Drawing.Size(63, 22);
            this.lblWordValue.TabIndex = 2;
            this.lblWordValue.Text = "Bar Value : ";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.EditValue = "";
            this.txtWordValue.Location = new System.Drawing.Point(79, 0);
            this.txtWordValue.MenuManager = this.exBarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(94, 20);
            this.txtWordValue.TabIndex = 1;
            // 
            // pnlIndicator1
            // 
            this.pnlIndicator1.Controls.Add(this.lblIndicator1);
            this.pnlIndicator1.Controls.Add(this.dtpkIndicator1);
            this.pnlIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIndicator1.Location = new System.Drawing.Point(203, 10);
            this.pnlIndicator1.Name = "pnlIndicator1";
            this.pnlIndicator1.Size = new System.Drawing.Size(175, 22);
            this.pnlIndicator1.TabIndex = 5;
            // 
            // lblIndicator1
            // 
            this.lblIndicator1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator1.Location = new System.Drawing.Point(15, 0);
            this.lblIndicator1.Name = "lblIndicator1";
            this.lblIndicator1.Size = new System.Drawing.Size(60, 22);
            this.lblIndicator1.TabIndex = 2;
            this.lblIndicator1.Text = "측정선 1 :";
            // 
            // dtpkIndicator1
            // 
            this.dtpkIndicator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator1.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator1.Location = new System.Drawing.Point(75, 0);
            this.dtpkIndicator1.MenuManager = this.exBarManager;
            this.dtpkIndicator1.Name = "dtpkIndicator1";
            this.dtpkIndicator1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator1.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator1.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator1.TabIndex = 1;
            // 
            // pnlIndicator2
            // 
            this.pnlIndicator2.Controls.Add(this.lblIndicator2);
            this.pnlIndicator2.Controls.Add(this.dtpkIndicator2);
            this.pnlIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlIndicator2.Location = new System.Drawing.Point(378, 10);
            this.pnlIndicator2.Name = "pnlIndicator2";
            this.pnlIndicator2.Size = new System.Drawing.Size(170, 22);
            this.pnlIndicator2.TabIndex = 3;
            // 
            // lblIndicator2
            // 
            this.lblIndicator2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIndicator2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIndicator2.Location = new System.Drawing.Point(10, 0);
            this.lblIndicator2.Name = "lblIndicator2";
            this.lblIndicator2.Size = new System.Drawing.Size(60, 22);
            this.lblIndicator2.TabIndex = 2;
            this.lblIndicator2.Text = "측정선 2 :";
            // 
            // dtpkIndicator2
            // 
            this.dtpkIndicator2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpkIndicator2.EditValue = new System.DateTime(2015, 10, 8, 0, 0, 0, 0);
            this.dtpkIndicator2.Location = new System.Drawing.Point(70, 0);
            this.dtpkIndicator2.MenuManager = this.exBarManager;
            this.dtpkIndicator2.Name = "dtpkIndicator2";
            this.dtpkIndicator2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkIndicator2.Properties.DisplayFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.EditFormat.FormatString = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.EditMask = "HH:mm:ss.fff";
            this.dtpkIndicator2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpkIndicator2.Size = new System.Drawing.Size(100, 20);
            this.dtpkIndicator2.TabIndex = 1;
            // 
            // pnlInterval
            // 
            this.pnlInterval.Controls.Add(this.lblInterval);
            this.pnlInterval.Controls.Add(this.txtInterval);
            this.pnlInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInterval.Location = new System.Drawing.Point(548, 10);
            this.pnlInterval.Name = "pnlInterval";
            this.pnlInterval.Size = new System.Drawing.Size(138, 22);
            this.pnlInterval.TabIndex = 4;
            // 
            // lblInterval
            // 
            this.lblInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInterval.Location = new System.Drawing.Point(8, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(56, 22);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Interval : ";
            // 
            // txtInterval
            // 
            this.txtInterval.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtInterval.EditValue = "0";
            this.txtInterval.Location = new System.Drawing.Point(64, 0);
            this.txtInterval.MenuManager = this.exBarManager;
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInterval.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInterval.Properties.ReadOnly = true;
            this.txtInterval.Size = new System.Drawing.Size(74, 20);
            this.txtInterval.TabIndex = 1;
            // 
            // ucTimeChart
            // 
            this.ucTimeChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTimeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTimeChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucTimeChart.Location = new System.Drawing.Point(317, 102);
            this.ucTimeChart.Name = "ucTimeChart";
            this.ucTimeChart.Size = new System.Drawing.Size(691, 603);
            this.ucTimeChart.TabIndex = 24;
            // 
            // FrmTimeChartViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.ucTimeChart);
            this.Controls.Add(this.pnlTimeInfo);
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.tabTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimeChartViewer";
            this.Text = "Log Chart View";
            this.Load += new System.EventHandler(this.FrmTimeChartViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.cntxGanttTreeMenu.ResumeLayout(false);
            this.cntxSeriesTreeMenu.ResumeLayout(false);
            this.tpTagTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTagControl)).EndInit();
            this.grpTagControl.ResumeLayout(false);
            this.tpStepTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCoilTagList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCoilTagList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStepControl)).EndInit();
            this.grpStepControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabTable)).EndInit();
            this.tabTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTimeInfo)).EndInit();
            this.pnlTimeInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.pnlIndicator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.pnlIndicator2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.pnlInterval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.BarManager exBarManager;
		private DevExpress.XtraBars.Bar exBarMenu;
		private DevExpress.XtraBars.BarEditItem dtpkFrom;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
		private DevExpress.XtraBars.BarEditItem dtpkTo;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
		private DevExpress.XtraBars.BarLargeButtonItem btnZoomIn;
		private DevExpress.XtraBars.BarLargeButtonItem btnZoomOut;
		private DevExpress.XtraBars.BarLargeButtonItem btnItemUp;
		private DevExpress.XtraBars.BarLargeButtonItem btnItemDown;
		private DevExpress.XtraBars.BarLargeButtonItem btnShow;
		private DevExpress.XtraBars.BarLargeButtonItem btnClear;
		private DevExpress.XtraBars.Bar exBarStatus;
		private DevExpress.XtraBars.BarStaticItem lblStatus;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imgListLarge;
        private System.Windows.Forms.ContextMenuStrip cntxGanttTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuShowSeriesChart;
        private System.Windows.Forms.ToolStripSeparator mnuGridGantMenuSplitter4;
        private System.Windows.Forms.ToolStripMenuItem mnuGanttItemDelete;
        private System.Windows.Forms.ContextMenuStrip cntxSeriesTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesItemDelete;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucTimeChart;
        private DevExpress.XtraEditors.PanelControl pnlTimeInfo;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblWordValue;
        private DevExpress.XtraEditors.TextEdit txtWordValue;
        private System.Windows.Forms.Panel pnlIndicator1;
        private DevExpress.XtraEditors.LabelControl lblIndicator1;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator1;
        private System.Windows.Forms.Panel pnlIndicator2;
        private DevExpress.XtraEditors.LabelControl lblIndicator2;
        private DevExpress.XtraEditors.TimeEdit dtpkIndicator2;
        private System.Windows.Forms.Panel pnlInterval;
        private DevExpress.XtraEditors.LabelControl lblInterval;
        private DevExpress.XtraEditors.TextEdit txtInterval;
        private DevExpress.XtraEditors.SplitterControl spltMain;
        private DevExpress.XtraTab.XtraTabControl tabTable;
        private DevExpress.XtraTab.XtraTabPage tpStepTable;
        private DevExpress.XtraTab.XtraTabPage tpTagTable;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSubDepthView;
        private DevExpress.XtraGrid.GridControl grdCoilTagList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCoilTagList;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colNetworkNum;
        private DevExpress.XtraGrid.Columns.GridColumn colStep;
        private DevExpress.XtraGrid.Columns.GridColumn colCommand;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraEditors.GroupControl grpStepControl;
        private DevExpress.XtraEditors.SimpleButton btnStepAllView;
        private UCTagTable ucTagTable;
        private DevExpress.XtraEditors.GroupControl grpTagControl;
        private DevExpress.XtraEditors.SimpleButton btnTagAllView;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
	}
}