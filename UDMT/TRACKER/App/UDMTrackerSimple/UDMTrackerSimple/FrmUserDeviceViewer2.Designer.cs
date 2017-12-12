namespace UDMTrackerSimple
{
    partial class FrmUserDeviceViewer2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserDeviceViewer2));
            this.imgListLarge = new System.Windows.Forms.ImageList(this.components);
            this.exBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.exBarMenu = new DevExpress.XtraBars.Bar();
            this.chkHideList = new DevExpress.XtraBars.BarCheckItem();
            this.dtpkFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.exBarStatus = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.exEditorColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.exEditorMin = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.exEditorPLC = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.grpDevice = new DevExpress.XtraEditors.GroupControl();
            this.grdDevice = new DevExpress.XtraGrid.GridControl();
            this.grvDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorLastTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnHideList = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogTable = new DevExpress.XtraEditors.SimpleButton();
            this.btnChartShow = new DevExpress.XtraEditors.SimpleButton();
            this.tpBar = new DevExpress.XtraTab.XtraTabPage();
            this.tabBarChart = new DevExpress.XtraTab.XtraTabControl();
            this.tpGantt = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucChart = new UDM.UI.TimeChart.UCGanttSeriesChart();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnMoveTimeLine = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtpkMoveTo = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWordValue = new DevExpress.XtraEditors.TextEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblIndicator1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator1 = new DevExpress.XtraEditors.TimeEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIndicator2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkIndicator2 = new DevExpress.XtraEditors.TimeEdit();
            this.btnChartClear = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtInterval = new DevExpress.XtraEditors.TextEdit();
            this.tabChart = new DevExpress.XtraTab.XtraTabControl();
            this.cntxGanttTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesChartView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGanttItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxSeriesTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSeriesItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDevice)).BeginInit();
            this.grpDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLastTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.tpBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabBarChart)).BeginInit();
            this.tpGantt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkMoveTo.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabChart)).BeginInit();
            this.tabChart.SuspendLayout();
            this.cntxGanttTreeMenu.SuspendLayout();
            this.cntxSeriesTreeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
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
            this.dtpkFrom,
            this.btnClear,
            this.btnExit,
            this.btnRefresh,
            this.dtpkTo,
            this.chkHideList,
            this.btnShow});
            this.exBarManager.LargeImages = this.imgListLarge;
            this.exBarManager.MaxItemId = 27;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.chkHideList, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkFrom, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.dtpkTo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShow, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true)});
            this.exBarMenu.OptionsBar.DrawSizeGrip = true;
            this.exBarMenu.OptionsBar.MultiLine = true;
            this.exBarMenu.OptionsBar.UseWholeRow = true;
            this.exBarMenu.Text = "Tools";
            // 
            // chkHideList
            // 
            this.chkHideList.BindableChecked = true;
            this.chkHideList.Caption = "List Visible";
            this.chkHideList.Checked = true;
            this.chkHideList.Glyph = ((System.Drawing.Image)(resources.GetObject("chkHideList.Glyph")));
            this.chkHideList.Id = 23;
            this.chkHideList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkHideList.LargeGlyph")));
            this.chkHideList.Name = "chkHideList";
            this.chkHideList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.chkHideList.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkHideList_CheckedChanged);
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Caption = "From";
            this.dtpkFrom.Edit = this.exEditorFrom;
            this.dtpkFrom.EditValue = new System.DateTime(2015, 2, 24, 21, 32, 0, 275);
            this.dtpkFrom.EditWidth = 150;
            this.dtpkFrom.Id = 1;
            this.dtpkFrom.Name = "dtpkFrom";
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
            this.dtpkTo.EditValue = new System.DateTime(2016, 6, 2, 12, 43, 51, 878);
            this.dtpkTo.EditWidth = 151;
            this.dtpkTo.Id = 21;
            this.dtpkTo.Name = "dtpkTo";
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
            this.btnShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShow.Glyph")));
            this.btnShow.Id = 25;
            this.btnShow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShow.LargeGlyph")));
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
            this.exBarStatus.OptionsBar.AllowQuickCustomization = false;
            this.exBarStatus.OptionsBar.DrawDragBorder = false;
            this.exBarStatus.OptionsBar.UseWholeRow = true;
            this.exBarStatus.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1532, 65);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 547);
            this.barDockControlBottom.Size = new System.Drawing.Size(1532, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 65);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 482);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1532, 65);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 482);
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
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.grdDevice);
            this.grpDevice.Controls.Add(this.panelControl3);
            this.grpDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDevice.Location = new System.Drawing.Point(0, 0);
            this.grpDevice.MinimumSize = new System.Drawing.Size(470, 0);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Size = new System.Drawing.Size(470, 482);
            this.grpDevice.TabIndex = 4;
            this.grpDevice.Text = "User Device List";
            // 
            // grdDevice
            // 
            this.grdDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDevice.Location = new System.Drawing.Point(2, 49);
            this.grdDevice.MainView = this.grvDevice;
            this.grdDevice.MenuManager = this.exBarManager;
            this.grdDevice.Name = "grdDevice";
            this.grdDevice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorLastTime});
            this.grdDevice.Size = new System.Drawing.Size(466, 431);
            this.grdDevice.TabIndex = 0;
            this.grdDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDevice});
            // 
            // grvDevice
            // 
            this.grvDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDescription,
            this.colLogCount,
            this.colLastTime});
            this.grvDevice.GridControl = this.grdDevice;
            this.grvDevice.IndicatorWidth = 30;
            this.grvDevice.Name = "grvDevice";
            this.grvDevice.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvDevice.OptionsBehavior.Editable = false;
            this.grvDevice.OptionsBehavior.ReadOnly = true;
            this.grvDevice.OptionsSelection.MultiSelect = true;
            this.grvDevice.OptionsView.ShowAutoFilterRow = true;
            this.grvDevice.OptionsView.ShowGroupPanel = false;
            this.grvDevice.OptionsView.ShowIndicator = false;
            this.grvDevice.RowHeight = 25;
            this.grvDevice.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDevice_CustomDrawRowIndicator);
            this.grvDevice.DoubleClick += new System.EventHandler(this.grvDevice_DoubleClick);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 90;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Name";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 77;
            // 
            // colLogCount
            // 
            this.colLogCount.AppearanceCell.Options.UseTextOptions = true;
            this.colLogCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLogCount.Caption = "Log Count";
            this.colLogCount.FieldName = "ChangeCount";
            this.colLogCount.Name = "colLogCount";
            this.colLogCount.OptionsColumn.FixedWidth = true;
            this.colLogCount.Visible = true;
            this.colLogCount.VisibleIndex = 2;
            this.colLogCount.Width = 70;
            // 
            // colLastTime
            // 
            this.colLastTime.AppearanceCell.Options.UseTextOptions = true;
            this.colLastTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastTime.Caption = "LastTime";
            this.colLastTime.ColumnEdit = this.exEditorLastTime;
            this.colLastTime.FieldName = "LastTime";
            this.colLastTime.Name = "colLastTime";
            this.colLastTime.OptionsColumn.FixedWidth = true;
            this.colLastTime.Visible = true;
            this.colLastTime.VisibleIndex = 3;
            this.colLastTime.Width = 120;
            // 
            // exEditorLastTime
            // 
            this.exEditorLastTime.AutoHeight = false;
            this.exEditorLastTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorLastTime.DisplayFormat.FormatString = "MM.dd HH:mm:ss.fff";
            this.exEditorLastTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorLastTime.EditFormat.FormatString = "MM.dd HH:mm:ss.fff";
            this.exEditorLastTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorLastTime.Mask.EditMask = "MM.dd HH:mm:ss.fff";
            this.exEditorLastTime.Name = "exEditorLastTime";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnHideList);
            this.panelControl3.Controls.Add(this.btnLogTable);
            this.panelControl3.Controls.Add(this.btnChartShow);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 21);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(466, 28);
            this.panelControl3.TabIndex = 1;
            // 
            // btnHideList
            // 
            this.btnHideList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHideList.Image = ((System.Drawing.Image)(resources.GetObject("btnHideList.Image")));
            this.btnHideList.Location = new System.Drawing.Point(2, 2);
            this.btnHideList.Name = "btnHideList";
            this.btnHideList.Size = new System.Drawing.Size(80, 24);
            this.btnHideList.TabIndex = 2;
            this.btnHideList.Text = "Hide";
            this.btnHideList.Click += new System.EventHandler(this.btnHideList_Click);
            // 
            // btnLogTable
            // 
            this.btnLogTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogTable.Image = ((System.Drawing.Image)(resources.GetObject("btnLogTable.Image")));
            this.btnLogTable.Location = new System.Drawing.Point(291, 2);
            this.btnLogTable.Name = "btnLogTable";
            this.btnLogTable.Size = new System.Drawing.Size(93, 24);
            this.btnLogTable.TabIndex = 1;
            this.btnLogTable.Text = "Log Table";
            this.btnLogTable.Click += new System.EventHandler(this.btnLogTable_Click);
            // 
            // btnChartShow
            // 
            this.btnChartShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChartShow.Image = ((System.Drawing.Image)(resources.GetObject("btnChartShow.Image")));
            this.btnChartShow.Location = new System.Drawing.Point(384, 2);
            this.btnChartShow.Name = "btnChartShow";
            this.btnChartShow.Size = new System.Drawing.Size(80, 24);
            this.btnChartShow.TabIndex = 0;
            this.btnChartShow.Text = "Show";
            this.btnChartShow.Click += new System.EventHandler(this.btnChartShow_Click);
            // 
            // tpBar
            // 
            this.tpBar.Controls.Add(this.tabBarChart);
            this.tpBar.Name = "tpBar";
            this.tpBar.Size = new System.Drawing.Size(1046, 453);
            this.tpBar.Text = "Xbar-R Chart";
            // 
            // tabBarChart
            // 
            this.tabBarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBarChart.Location = new System.Drawing.Point(0, 0);
            this.tabBarChart.Name = "tabBarChart";
            this.tabBarChart.Size = new System.Drawing.Size(1046, 453);
            this.tabBarChart.TabIndex = 0;
            this.tabBarChart.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabBarChart_SelectedPageChanged);
            // 
            // tpGantt
            // 
            this.tpGantt.Controls.Add(this.panelControl2);
            this.tpGantt.Name = "tpGantt";
            this.tpGantt.Size = new System.Drawing.Size(1046, 453);
            this.tpGantt.Text = "Gantt/Series Chart";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ucChart);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1046, 453);
            this.panelControl2.TabIndex = 56;
            // 
            // ucChart
            // 
            this.ucChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.ucChart.Location = new System.Drawing.Point(2, 27);
            this.ucChart.Name = "ucChart";
            this.ucChart.Size = new System.Drawing.Size(1042, 424);
            this.ucChart.TabIndex = 57;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnMoveTimeLine);
            this.panelControl1.Controls.Add(this.panel7);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Controls.Add(this.panel4);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.btnChartClear);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1042, 25);
            this.panelControl1.TabIndex = 55;
            // 
            // btnMoveTimeLine
            // 
            this.btnMoveTimeLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMoveTimeLine.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveTimeLine.Image")));
            this.btnMoveTimeLine.Location = new System.Drawing.Point(274, 2);
            this.btnMoveTimeLine.Name = "btnMoveTimeLine";
            this.btnMoveTimeLine.Size = new System.Drawing.Size(83, 21);
            this.btnMoveTimeLine.TabIndex = 8;
            this.btnMoveTimeLine.Text = "Apply";
            this.btnMoveTimeLine.Click += new System.EventHandler(this.btnMoveTimeLine_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dtpkMoveTo);
            this.panel7.Controls.Add(this.labelControl4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(76, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 21);
            this.panel7.TabIndex = 7;
            // 
            // dtpkMoveTo
            // 
            this.dtpkMoveTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpkMoveTo.EditValue = new System.DateTime(2017, 5, 11, 0, 0, 0, 0);
            this.dtpkMoveTo.Location = new System.Drawing.Point(70, 0);
            this.dtpkMoveTo.MenuManager = this.exBarManager;
            this.dtpkMoveTo.Name = "dtpkMoveTo";
            this.dtpkMoveTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkMoveTo.Properties.Mask.EditMask = "yy.MM.dd HH:mm";
            this.dtpkMoveTo.Size = new System.Drawing.Size(111, 20);
            this.dtpkMoveTo.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl4.Location = new System.Drawing.Point(0, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 21);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "  Move To : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.txtWordValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(404, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 21);
            this.panel2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl1.Location = new System.Drawing.Point(10, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Bar Value :";
            // 
            // txtWordValue
            // 
            this.txtWordValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtWordValue.Location = new System.Drawing.Point(69, 0);
            this.txtWordValue.MenuManager = this.exBarManager;
            this.txtWordValue.Name = "txtWordValue";
            this.txtWordValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWordValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWordValue.Properties.ReadOnly = true;
            this.txtWordValue.Size = new System.Drawing.Size(98, 20);
            this.txtWordValue.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblIndicator1);
            this.panel4.Controls.Add(this.dtpkIndicator1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(571, 2);
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
            this.panel3.Location = new System.Drawing.Point(742, 2);
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
            // btnChartClear
            // 
            this.btnChartClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChartClear.Image = ((System.Drawing.Image)(resources.GetObject("btnChartClear.Image")));
            this.btnChartClear.Location = new System.Drawing.Point(2, 2);
            this.btnChartClear.Name = "btnChartClear";
            this.btnChartClear.Size = new System.Drawing.Size(74, 21);
            this.btnChartClear.TabIndex = 4;
            this.btnChartClear.Text = "Clear";
            this.btnChartClear.Click += new System.EventHandler(this.btnChartClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.txtInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(907, 2);
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
            // tabChart
            // 
            this.tabChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChart.Location = new System.Drawing.Point(0, 0);
            this.tabChart.Name = "tabChart";
            this.tabChart.SelectedTabPage = this.tpGantt;
            this.tabChart.Size = new System.Drawing.Size(1052, 482);
            this.tabChart.TabIndex = 6;
            this.tabChart.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpBar,
            this.tpGantt});
            // 
            // cntxGanttTreeMenu
            // 
            this.cntxGanttTreeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxGanttTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesChartView,
            this.toolStripSeparator1,
            this.mnuGanttItemDelete});
            this.cntxGanttTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxGanttTreeMenu.Size = new System.Drawing.Size(227, 62);
            // 
            // mnuSeriesChartView
            // 
            this.mnuSeriesChartView.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesChartView.Image")));
            this.mnuSeriesChartView.Name = "mnuSeriesChartView";
            this.mnuSeriesChartView.Size = new System.Drawing.Size(226, 26);
            this.mnuSeriesChartView.Text = "선택 접점 Series Chart 보기";
            this.mnuSeriesChartView.Click += new System.EventHandler(this.mnuSeriesChartView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // mnuGanttItemDelete
            // 
            this.mnuGanttItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuGanttItemDelete.Image")));
            this.mnuGanttItemDelete.Name = "mnuGanttItemDelete";
            this.mnuGanttItemDelete.Size = new System.Drawing.Size(226, 26);
            this.mnuGanttItemDelete.Text = "선택 접점 삭제";
            this.mnuGanttItemDelete.Click += new System.EventHandler(this.mnuGanttItemDelete_Click);
            // 
            // cntxSeriesTreeMenu
            // 
            this.cntxSeriesTreeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntxSeriesTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeriesItemDelete});
            this.cntxSeriesTreeMenu.Name = "cntxGridGanttMenu";
            this.cntxSeriesTreeMenu.Size = new System.Drawing.Size(159, 30);
            // 
            // mnuSeriesItemDelete
            // 
            this.mnuSeriesItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuSeriesItemDelete.Image")));
            this.mnuSeriesItemDelete.Name = "mnuSeriesItemDelete";
            this.mnuSeriesItemDelete.Size = new System.Drawing.Size(158, 26);
            this.mnuSeriesItemDelete.Text = "선택 접점 삭제";
            this.mnuSeriesItemDelete.Click += new System.EventHandler(this.mnuSeriesItemDelete_Click);
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 65);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpDevice);
            this.sptMain.Panel1.MinSize = 470;
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.tabChart);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1532, 482);
            this.sptMain.SplitterPosition = 470;
            this.sptMain.TabIndex = 11;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // FrmUserDeviceViewer2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 570);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUserDeviceViewer2";
            this.Text = "User Device Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserDeviceViewer2_FormClosed);
            this.Load += new System.EventHandler(this.FrmUserDeviceViewer2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDevice)).EndInit();
            this.grpDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLastTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.tpBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabBarChart)).EndInit();
            this.tpGantt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkMoveTo.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWordValue.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator1.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkIndicator2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabChart)).EndInit();
            this.tabChart.ResumeLayout(false);
            this.cntxGanttTreeMenu.ResumeLayout(false);
            this.cntxSeriesTreeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imgListLarge;
        private DevExpress.XtraBars.BarManager exBarManager;
        private DevExpress.XtraBars.Bar exBarMenu;
        private DevExpress.XtraBars.BarEditItem dtpkFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorFrom;
        private DevExpress.XtraBars.BarEditItem dtpkTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTo;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnClear;
        private DevExpress.XtraBars.BarLargeButtonItem btnExit;
        private DevExpress.XtraBars.Bar exBarStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPLC;
        private DevExpress.XtraEditors.GroupControl grpDevice;
        private DevExpress.XtraGrid.GridControl grdDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colLogCount;
        private DevExpress.XtraGrid.Columns.GridColumn colLastTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorLastTime;
        private DevExpress.XtraTab.XtraTabControl tabChart;
        private DevExpress.XtraTab.XtraTabPage tpGantt;
        private DevExpress.XtraEditors.PanelControl panelControl2;
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
        private DevExpress.XtraTab.XtraTabPage tpBar;
        private System.Windows.Forms.ContextMenuStrip cntxGanttTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesChartView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuGanttItemDelete;
        private System.Windows.Forms.ContextMenuStrip cntxSeriesTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSeriesItemDelete;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnChartShow;
        private UDM.UI.TimeChart.UCGanttSeriesChart ucChart;
        private DevExpress.XtraEditors.SimpleButton btnChartClear;
        private DevExpress.XtraEditors.SimpleButton btnLogTable;
        private DevExpress.XtraEditors.SimpleButton btnMoveTimeLine;
        private System.Windows.Forms.Panel panel7;
        private DevExpress.XtraEditors.TimeEdit dtpkMoveTo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraBars.BarCheckItem chkHideList;
        private DevExpress.XtraEditors.SimpleButton btnHideList;
        private DevExpress.XtraTab.XtraTabControl tabBarChart;
        private DevExpress.XtraBars.BarLargeButtonItem btnShow;
        private UDM.UI.MySplitContainerControl sptMain;
    }
}