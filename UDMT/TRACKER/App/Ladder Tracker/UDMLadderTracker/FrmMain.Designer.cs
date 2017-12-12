namespace UDMLadderTracker
{
    partial class FrmMain
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
			//this.frmMonitorMaximized.IsExit = true;
				
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tilecolName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tilecolValue = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exShowWord = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.exAppMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.chkShowSysLog = new DevExpress.XtraBars.BarCheckItem();
            this.chkShowMonitorStatus = new DevExpress.XtraBars.BarCheckItem();
            this.chkMainTabHeader = new DevExpress.XtraBars.BarCheckItem();
            this.toggMainEditorMode = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.imgListRibbon = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.exRibbonGallery = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnUpdatePatternItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnFlowChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateDataBase = new DevExpress.XtraBars.BarButtonItem();
            this.btnTestDBConnection = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportLog = new DevExpress.XtraBars.BarButtonItem();
            this.dtpkExportFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorExportFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkExportTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorExportTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnViewSymbolLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewCycleLog = new DevExpress.XtraBars.BarButtonItem();
            this.lblMonitorCountLabel = new DevExpress.XtraBars.BarStaticItem();
            this.lblMonitorCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnViewLogicDiagram = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaximized = new DevExpress.XtraBars.BarButtonItem();
            this.chkMonitorFlowItem = new DevExpress.XtraBars.BarCheckItem();
            this.chkMonitorErrorDetection = new DevExpress.XtraBars.BarCheckItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnViewProcessTimeChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewStatisticsTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewSymbolLog2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewLogicDiagram2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcessSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnRobotCycleView = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserDeviceView = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportPDF = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.pgHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuHomeFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorMode = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomeSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgDatabase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuStatistics = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuTool = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuMonitorExportLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exEditorUseOPC = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorUseDDEA = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rcmbOPCServer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.exEditorDescriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.exRibbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnlSystemLog = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlSystemLogContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSystemLogTable = new UDMLadderTracker.UCSystemLogTable();
            this.mnuImportExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exValueProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.imgSubMenu = new DevExpress.Utils.ImageCollection(this.components);
            this.btnMonitorStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonitorStart = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMainTabBtn = new System.Windows.Forms.Panel();
            this.btnCurrentValue = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnErrorReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowLogView = new DevExpress.XtraEditors.DropDownButton();
            this.exLogViewItem = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnOption = new DevExpress.XtraEditors.DropDownButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnExitHMI = new DevExpress.XtraEditors.SimpleButton();
            this.btnErrorDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnMain = new DevExpress.XtraEditors.SimpleButton();
            this.grpMonitorStatus = new DevExpress.XtraEditors.GroupControl();
            this.ucStatusView = new UDMLadderTracker.UCStatusView();
            this.ucClock = new UDMLadderTracker.UCClock();
            this.ucTrackerMode = new UDMLadderTracker.UCTrackerMode();
            this.ucMonitorStatus = new UDMLadderTracker.UCMonitorStatus();
            this.tpErrorNew = new DevExpress.XtraTab.XtraTabPage();
            this.ucErrorView = new UDMLadderTracker.UCErrorView();
            this.tpUserDevice = new DevExpress.XtraTab.XtraTabPage();
            this.sptUserMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpUserDashBoard = new DevExpress.XtraEditors.GroupControl();
            this.grdUserDevice = new DevExpress.XtraGrid.GridControl();
            this.grvUserDevice = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tilecolAddress = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpUserDeviceValue = new DevExpress.XtraEditors.GroupControl();
            this.grdUserAll = new DevExpress.XtraGrid.GridControl();
            this.grvUserAll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserUpCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShowWord = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpErrorLog = new DevExpress.XtraTab.XtraTabPage();
            this.ucErrorLogTable = new UDMLadderTracker.UCErrorLogTable();
            this.tpCurrentSymbol = new DevExpress.XtraTab.XtraTabPage();
            this.grpCycleCollectTag = new DevExpress.XtraEditors.GroupControl();
            this.grdRuntimeValue = new DevExpress.XtraGrid.GridControl();
            this.grvRuntimeValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.grpRobotCycleTime = new DevExpress.XtraEditors.GroupControl();
            this.ucRobotCycle = new UDMLadderTracker.UCRobotCycle();
            this.tpMain = new DevExpress.XtraTab.XtraTabPage();
            this.tabMainError = new DevExpress.XtraTab.XtraTabControl();
            this.tpErrorList = new DevExpress.XtraTab.XtraTabPage();
            this.ucErrorListPanelS = new UDMLadderTracker.UCErrorListPanelS();
            this.tpAnalysis = new DevExpress.XtraTab.XtraTabPage();
            this.pnlView = new System.Windows.Forms.Panel();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            this.grpProcessFlowChart = new DevExpress.XtraEditors.GroupControl();
            this.tabFlow = new DevExpress.XtraTab.XtraTabControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tmrSystemLog = new System.Windows.Forms.Timer(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu3 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu4 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu5 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tmrSPDStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.tmrLoadFirst = new System.Windows.Forms.Timer(this.components);
            this.popupMenu6 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseOPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseDDEA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcmbOPCServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.dpnlSystemLog.SuspendLayout();
            this.dpnlSystemLogContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exValueProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSubMenu)).BeginInit();
            this.pnlMainTabBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exLogViewItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitorStatus)).BeginInit();
            this.grpMonitorStatus.SuspendLayout();
            this.tpErrorNew.SuspendLayout();
            this.tpUserDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptUserMain)).BeginInit();
            this.sptUserMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserDashBoard)).BeginInit();
            this.grpUserDashBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserDeviceValue)).BeginInit();
            this.grpUserDeviceValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpErrorLog.SuspendLayout();
            this.tpCurrentSymbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleCollectTag)).BeginInit();
            this.grpCycleCollectTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRuntimeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRuntimeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRobotCycleTime)).BeginInit();
            this.grpRobotCycleTime.SuspendLayout();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMainError)).BeginInit();
            this.tabMainError.SuspendLayout();
            this.tpErrorList.SuspendLayout();
            this.tpAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).BeginInit();
            this.grpProcessFlowChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu6)).BeginInit();
            this.SuspendLayout();
            // 
            // tilecolName
            // 
            this.tilecolName.Caption = "Name";
            this.tilecolName.FieldName = "Name";
            this.tilecolName.Name = "tilecolName";
            this.tilecolName.Visible = true;
            this.tilecolName.VisibleIndex = 1;
            // 
            // tilecolValue
            // 
            this.tilecolValue.Caption = "Value";
            this.tilecolValue.FieldName = "Value";
            this.tilecolValue.Name = "tilecolValue";
            this.tilecolValue.Visible = true;
            this.tilecolValue.VisibleIndex = 2;
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Items.AddRange(new object[] {
            "Bool",
            "Word",
            "DWord"});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // exShowWord
            // 
            this.exShowWord.AutoHeight = false;
            this.exShowWord.Name = "exShowWord";
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.ApplicationButtonDropDownControl = this.exAppMenu;
            this.exRibbonControl.AutoHideEmptyItems = true;
            this.exRibbonControl.ExpandCollapseItem.Id = 0;
            this.exRibbonControl.Images = this.imgListRibbon;
            this.exRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonControl.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnExit,
            this.exRibbonGallery,
            this.btnUpdatePatternItem,
            this.btnFlowChart,
            this.btnCreateDataBase,
            this.btnTestDBConnection,
            this.btnExportLog,
            this.dtpkExportFrom,
            this.dtpkExportTo,
            this.btnViewSymbolLog,
            this.btnViewCycleLog,
            this.lblMonitorCountLabel,
            this.lblMonitorCount,
            this.btnViewLogicDiagram,
            this.btnMaximized,
            this.chkMonitorFlowItem,
            this.chkMonitorErrorDetection,
            this.lblStatus,
            this.btnViewProcessTimeChart,
            this.btnViewStatisticsTable,
            this.btnProjectSet,
            this.chkShowSysLog,
            this.chkShowMonitorStatus,
            this.toggMainEditorMode,
            this.chkMainTabHeader,
            this.btnViewSymbolLog2,
            this.btnViewLogicDiagram2,
            this.btnProcessSetting,
            this.btnRobotCycleView,
            this.btnUserDeviceView,
            this.btnReport,
            this.btnExportPDF});
            this.exRibbonControl.LargeImages = this.imgListRibbonLarge;
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exRibbonControl.MaxItemId = 1;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHome,
            this.pgDatabase,
            this.pgView,
            this.mnuTool});
            this.exRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorExportFrom,
            this.exEditorExportTo,
            this.exEditorUseOPC,
            this.exEditorUseDDEA,
            this.rcmbOPCServer,
            this.exEditorAddressFilter,
            this.exEditorDescriptionFilter,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.exRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exRibbonControl.ShowCategoryInCaption = false;
            this.exRibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.exRibbonControl.Size = new System.Drawing.Size(1704, 176);
            this.exRibbonControl.StatusBar = this.exRibbonStatusBar;
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnSave);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnSaveAs);
            this.exRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // exAppMenu
            // 
            this.exAppMenu.ItemLinks.Add(this.chkShowSysLog);
            this.exAppMenu.ItemLinks.Add(this.chkShowMonitorStatus);
            this.exAppMenu.ItemLinks.Add(this.chkMainTabHeader);
            this.exAppMenu.ItemLinks.Add(this.toggMainEditorMode);
            this.exAppMenu.Name = "exAppMenu";
            this.exAppMenu.Ribbon = this.exRibbonControl;
            // 
            // chkShowSysLog
            // 
            this.chkShowSysLog.Caption = "Show System Log";
            this.chkShowSysLog.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkShowSysLog.Glyph = ((System.Drawing.Image)(resources.GetObject("chkShowSysLog.Glyph")));
            this.chkShowSysLog.Id = 1;
            this.chkShowSysLog.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.chkShowSysLog.ItemAppearance.Normal.Options.UseFont = true;
            this.chkShowSysLog.Name = "chkShowSysLog";
            this.chkShowSysLog.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowSysLog_CheckedChanged);
            // 
            // chkShowMonitorStatus
            // 
            this.chkShowMonitorStatus.Caption = "Show Monitor Status";
            this.chkShowMonitorStatus.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkShowMonitorStatus.Glyph = ((System.Drawing.Image)(resources.GetObject("chkShowMonitorStatus.Glyph")));
            this.chkShowMonitorStatus.Id = 2;
            this.chkShowMonitorStatus.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.chkShowMonitorStatus.ItemAppearance.Normal.Options.UseFont = true;
            this.chkShowMonitorStatus.Name = "chkShowMonitorStatus";
            this.chkShowMonitorStatus.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkShowMonitorStatus_CheckedChanged);
            // 
            // chkMainTabHeader
            // 
            this.chkMainTabHeader.BindableChecked = true;
            this.chkMainTabHeader.Caption = "Show Main Header";
            this.chkMainTabHeader.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkMainTabHeader.Checked = true;
            this.chkMainTabHeader.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMainTabHeader.Glyph")));
            this.chkMainTabHeader.Id = 4;
            this.chkMainTabHeader.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.chkMainTabHeader.ItemAppearance.Normal.Options.UseFont = true;
            this.chkMainTabHeader.Name = "chkMainTabHeader";
            this.chkMainTabHeader.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMainTabHeader_CheckedChanged);
            // 
            // toggMainEditorMode
            // 
            this.toggMainEditorMode.BindableChecked = true;
            this.toggMainEditorMode.Caption = "EditorMode";
            this.toggMainEditorMode.Checked = true;
            this.toggMainEditorMode.Glyph = ((System.Drawing.Image)(resources.GetObject("toggMainEditorMode.Glyph")));
            this.toggMainEditorMode.Id = 3;
            this.toggMainEditorMode.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.toggMainEditorMode.ItemAppearance.Normal.Options.UseFont = true;
            this.toggMainEditorMode.Name = "toggMainEditorMode";
            this.toggMainEditorMode.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.toggMainEditorMode_CheckedChanged);
            // 
            // imgListRibbon
            // 
            this.imgListRibbon.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListRibbon.ImageStream")));
            this.imgListRibbon.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.imgListRibbon.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.imgListRibbon.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.imgListRibbon.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.imgListRibbon.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.imgListRibbon.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.imgListRibbon.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.imgListRibbon.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.imgListRibbon.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.imgListRibbon.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.imgListRibbon.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.imgListRibbon.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.imgListRibbon.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.imgListRibbon.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.imgListRibbon.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            this.imgListRibbon.Images.SetKeyName(15, "ExportToCSV_16x16.png");
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Id = 2;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.LargeImageIndex = 1;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 3;
            this.btnSave.ImageIndex = 4;
            this.btnSave.LargeImageIndex = 4;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "Save As";
            this.btnSaveAs.Id = 4;
            this.btnSaveAs.ImageIndex = 5;
            this.btnSaveAs.LargeImageIndex = 5;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 5;
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // exRibbonGallery
            // 
            this.exRibbonGallery.Caption = "Skin";
            this.exRibbonGallery.Id = 6;
            this.exRibbonGallery.Name = "exRibbonGallery";
            // 
            // btnUpdatePatternItem
            // 
            this.btnUpdatePatternItem.Caption = "Pattern Item";
            this.btnUpdatePatternItem.Enabled = false;
            this.btnUpdatePatternItem.Id = 18;
            this.btnUpdatePatternItem.LargeImageIndex = 30;
            this.btnUpdatePatternItem.Name = "btnUpdatePatternItem";
            // 
            // btnFlowChart
            // 
            this.btnFlowChart.Caption = "Flow Chart Setting";
            this.btnFlowChart.Id = 19;
            this.btnFlowChart.LargeImageIndex = 30;
            this.btnFlowChart.Name = "btnFlowChart";
            this.btnFlowChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateMasterPattern_ItemClick);
            // 
            // btnCreateDataBase
            // 
            this.btnCreateDataBase.Caption = "Create DataBase";
            this.btnCreateDataBase.Id = 21;
            this.btnCreateDataBase.LargeImageIndex = 13;
            this.btnCreateDataBase.Name = "btnCreateDataBase";
            this.btnCreateDataBase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateDataBase_ItemClick);
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Caption = "Test  DataBase";
            this.btnTestDBConnection.Id = 22;
            this.btnTestDBConnection.LargeImageIndex = 14;
            this.btnTestDBConnection.Name = "btnTestDBConnection";
            this.btnTestDBConnection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTestDBConnection_ItemClick);
            // 
            // btnExportLog
            // 
            this.btnExportLog.Caption = "Export Log";
            this.btnExportLog.Id = 23;
            this.btnExportLog.LargeImageIndex = 20;
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportLog_ItemClick);
            // 
            // dtpkExportFrom
            // 
            this.dtpkExportFrom.Caption = "From ";
            this.dtpkExportFrom.Edit = this.exEditorExportFrom;
            this.dtpkExportFrom.EditValue = new System.DateTime(2015, 2, 6, 9, 57, 18, 820);
            this.dtpkExportFrom.Id = 24;
            this.dtpkExportFrom.Name = "dtpkExportFrom";
            this.dtpkExportFrom.Width = 120;
            // 
            // exEditorExportFrom
            // 
            this.exEditorExportFrom.AutoHeight = false;
            this.exEditorExportFrom.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorExportFrom.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorExportFrom.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorExportFrom.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorExportFrom.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorExportFrom.Name = "exEditorExportFrom";
            // 
            // dtpkExportTo
            // 
            this.dtpkExportTo.Caption = "To    ";
            this.dtpkExportTo.Edit = this.exEditorExportTo;
            this.dtpkExportTo.EditValue = new System.DateTime(2015, 2, 6, 9, 59, 4, 525);
            this.dtpkExportTo.Id = 25;
            this.dtpkExportTo.Name = "dtpkExportTo";
            this.dtpkExportTo.Width = 120;
            // 
            // exEditorExportTo
            // 
            this.exEditorExportTo.AutoHeight = false;
            this.exEditorExportTo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorExportTo.DisplayFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorExportTo.EditFormat.FormatString = "yy.MM.dd HH:mm";
            this.exEditorExportTo.Mask.EditMask = "yy.MM.dd HH:mm";
            this.exEditorExportTo.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorExportTo.Name = "exEditorExportTo";
            // 
            // btnViewSymbolLog
            // 
            this.btnViewSymbolLog.Caption = "View Symbol Chart";
            this.btnViewSymbolLog.Id = 30;
            this.btnViewSymbolLog.LargeImageIndex = 25;
            this.btnViewSymbolLog.Name = "btnViewSymbolLog";
            this.btnViewSymbolLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewSymbolLog_ItemClick);
            // 
            // btnViewCycleLog
            // 
            this.btnViewCycleLog.Caption = "View Cycle Chart";
            this.btnViewCycleLog.Id = 31;
            this.btnViewCycleLog.LargeImageIndex = 27;
            this.btnViewCycleLog.Name = "btnViewCycleLog";
            this.btnViewCycleLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewCycleLog_ItemClick);
            // 
            // lblMonitorCountLabel
            // 
            this.lblMonitorCountLabel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblMonitorCountLabel.Caption = "Log Count/1sec :";
            this.lblMonitorCountLabel.Id = 32;
            this.lblMonitorCountLabel.Name = "lblMonitorCountLabel";
            this.lblMonitorCountLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblMonitorCount
            // 
            this.lblMonitorCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblMonitorCount.Caption = "0";
            this.lblMonitorCount.Id = 33;
            this.lblMonitorCount.Name = "lblMonitorCount";
            this.lblMonitorCount.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnViewLogicDiagram
            // 
            this.btnViewLogicDiagram.Caption = "View Logic Diagram";
            this.btnViewLogicDiagram.Id = 51;
            this.btnViewLogicDiagram.LargeImageIndex = 16;
            this.btnViewLogicDiagram.Name = "btnViewLogicDiagram";
            this.btnViewLogicDiagram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewLogicDiagram_ItemClick);
            // 
            // btnMaximized
            // 
            this.btnMaximized.Caption = "Monitor-Full-Screen";
            this.btnMaximized.Id = 53;
            this.btnMaximized.Name = "btnMaximized";
            // 
            // chkMonitorFlowItem
            // 
            this.chkMonitorFlowItem.BindableChecked = true;
            this.chkMonitorFlowItem.Caption = "Flow Item";
            this.chkMonitorFlowItem.Checked = true;
            this.chkMonitorFlowItem.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorFlowItem.Glyph")));
            this.chkMonitorFlowItem.GroupIndex = 2;
            this.chkMonitorFlowItem.Id = 89;
            this.chkMonitorFlowItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorFlowItem.LargeGlyph")));
            this.chkMonitorFlowItem.Name = "chkMonitorFlowItem";
            this.chkMonitorFlowItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonitorFlowItem_CheckedChanged);
            // 
            // chkMonitorErrorDetection
            // 
            this.chkMonitorErrorDetection.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.chkMonitorErrorDetection.Caption = "Error Detect";
            this.chkMonitorErrorDetection.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorErrorDetection.Glyph")));
            this.chkMonitorErrorDetection.GroupIndex = 2;
            this.chkMonitorErrorDetection.Id = 90;
            this.chkMonitorErrorDetection.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorErrorDetection.LargeGlyph")));
            this.chkMonitorErrorDetection.Name = "chkMonitorErrorDetection";
            this.chkMonitorErrorDetection.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonitorErrorDetection_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 92;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnViewProcessTimeChart
            // 
            this.btnViewProcessTimeChart.Caption = "View Process Time Chart";
            this.btnViewProcessTimeChart.Id = 93;
            this.btnViewProcessTimeChart.LargeImageIndex = 33;
            this.btnViewProcessTimeChart.Name = "btnViewProcessTimeChart";
            this.btnViewProcessTimeChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewProcessTimeChart_ItemClick);
            // 
            // btnViewStatisticsTable
            // 
            this.btnViewStatisticsTable.Caption = "View Statistics";
            this.btnViewStatisticsTable.Id = 94;
            this.btnViewStatisticsTable.LargeImageIndex = 34;
            this.btnViewStatisticsTable.Name = "btnViewStatisticsTable";
            this.btnViewStatisticsTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewStatisticsTable_ItemClick);
            // 
            // btnProjectSet
            // 
            this.btnProjectSet.Caption = "Project Setting";
            this.btnProjectSet.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProjectSet.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProjectSet.Glyph")));
            this.btnProjectSet.Id = 106;
            this.btnProjectSet.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProjectSet.LargeGlyph")));
            this.btnProjectSet.Name = "btnProjectSet";
            this.btnProjectSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectSet_ItemClick);
            // 
            // btnViewSymbolLog2
            // 
            this.btnViewSymbolLog2.Caption = "View Symbol Chart";
            this.btnViewSymbolLog2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewSymbolLog2.Id = 5;
            this.btnViewSymbolLog2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnViewSymbolLog2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewSymbolLog2.LargeImageIndex = 25;
            this.btnViewSymbolLog2.Name = "btnViewSymbolLog2";
            this.btnViewSymbolLog2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewSymbolLog_ItemClick);
            // 
            // btnViewLogicDiagram2
            // 
            this.btnViewLogicDiagram2.Caption = "View Logic Diagram";
            this.btnViewLogicDiagram2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewLogicDiagram2.Id = 7;
            this.btnViewLogicDiagram2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnViewLogicDiagram2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewLogicDiagram2.LargeImageIndex = 16;
            this.btnViewLogicDiagram2.Name = "btnViewLogicDiagram2";
            this.btnViewLogicDiagram2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewLogicDiagram_ItemClick);
            // 
            // btnProcessSetting
            // 
            this.btnProcessSetting.Caption = "Process Setting";
            this.btnProcessSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProcessSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProcessSetting.Glyph")));
            this.btnProcessSetting.Id = 14;
            this.btnProcessSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProcessSetting.LargeGlyph")));
            this.btnProcessSetting.Name = "btnProcessSetting";
            // 
            // btnRobotCycleView
            // 
            this.btnRobotCycleView.Caption = "View Robot Cycle Statistics";
            this.btnRobotCycleView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRobotCycleView.Glyph")));
            this.btnRobotCycleView.Id = 15;
            this.btnRobotCycleView.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRobotCycleView.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRobotCycleView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRobotCycleView.LargeGlyph")));
            this.btnRobotCycleView.Name = "btnRobotCycleView";
            this.btnRobotCycleView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRobotCycleView_ItemClick);
            // 
            // btnUserDeviceView
            // 
            this.btnUserDeviceView.Caption = "View User Device Chart";
            this.btnUserDeviceView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserDeviceView.Glyph")));
            this.btnUserDeviceView.Id = 16;
            this.btnUserDeviceView.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserDeviceView.ItemAppearance.Normal.Options.UseFont = true;
            this.btnUserDeviceView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserDeviceView.LargeGlyph")));
            this.btnUserDeviceView.Name = "btnUserDeviceView";
            this.btnUserDeviceView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserDeviceView_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Export To Report";
            this.btnReport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnReport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReport.Glyph")));
            this.btnReport.Id = 17;
            this.btnReport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReport.LargeGlyph")));
            this.btnReport.Name = "btnReport";
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Caption = "Export To Report";
            this.btnExportPDF.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.Glyph")));
            this.btnExportPDF.Id = 18;
            this.btnExportPDF.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExportPDF.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportPDF.LargeGlyph")));
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportPDF_ItemClick);
            // 
            // imgListRibbonLarge
            // 
            this.imgListRibbonLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.imgListRibbonLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgListRibbonLarge.ImageStream")));
            this.imgListRibbonLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(9, "Next_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(10, "Pause_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(11, "Apply_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(12, "Customization_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(13, "Database_Add_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(14, "Database_Test_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(15, "Grid_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(16, "Tree_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(17, "Insert_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(18, "SideBySideRangeBar_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(19, "Cards_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(20, "ExportToCSV_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(21, "ImportCSV_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(22, "key_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(23, "time_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(24, "Customization_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(25, "Gantt_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(26, "Clip_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(27, "HistoryItem_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(28, "Tree2_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(29, "AddItem_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(30, "Apply_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(31, "CellsAutoHeight-_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(32, "StepArea_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(33, "Chart_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(34, "Summary_32x32.png");
            this.imgListRibbonLarge.Images.SetKeyName(35, "GaugeStyleRightQuarterCircular_32x32.png");
            // 
            // pgHome
            // 
            this.pgHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuHomeFile,
            this.mnuMonitorMode,
            this.mnuModel,
            this.mnuHomeSkin,
            this.mnuExit});
            this.pgHome.Name = "pgHome";
            this.pgHome.Text = "Home";
            // 
            // mnuHomeFile
            // 
            this.mnuHomeFile.ItemLinks.Add(this.btnOpen);
            this.mnuHomeFile.ItemLinks.Add(this.btnSave);
            this.mnuHomeFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuHomeFile.Name = "mnuHomeFile";
            this.mnuHomeFile.Text = "File";
            // 
            // mnuMonitorMode
            // 
            this.mnuMonitorMode.ItemLinks.Add(this.chkMonitorFlowItem);
            this.mnuMonitorMode.ItemLinks.Add(this.chkMonitorErrorDetection);
            this.mnuMonitorMode.Name = "mnuMonitorMode";
            this.mnuMonitorMode.Text = "Tracker Mode Select";
            // 
            // mnuModel
            // 
            this.mnuModel.ItemLinks.Add(this.btnProjectSet);
            this.mnuModel.ItemLinks.Add(this.btnFlowChart);
            this.mnuModel.Name = "mnuModel";
            this.mnuModel.Text = "Model";
            // 
            // mnuHomeSkin
            // 
            this.mnuHomeSkin.ItemLinks.Add(this.exRibbonGallery);
            this.mnuHomeSkin.Name = "mnuHomeSkin";
            this.mnuHomeSkin.Text = "Skins";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // pgDatabase
            // 
            this.pgDatabase.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuDatabase});
            this.pgDatabase.Name = "pgDatabase";
            this.pgDatabase.Text = "Data Base";
            // 
            // mnuDatabase
            // 
            this.mnuDatabase.ItemLinks.Add(this.btnCreateDataBase);
            this.mnuDatabase.ItemLinks.Add(this.btnTestDBConnection);
            this.mnuDatabase.Name = "mnuDatabase";
            this.mnuDatabase.Text = "DataBase";
            // 
            // pgView
            // 
            this.pgView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuLog,
            this.mnuStatistics,
            this.mnuReport});
            this.pgView.Name = "pgView";
            this.pgView.Text = "Log View";
            this.pgView.Visible = false;
            // 
            // mnuLog
            // 
            this.mnuLog.ItemLinks.Add(this.btnViewSymbolLog);
            this.mnuLog.ItemLinks.Add(this.btnViewCycleLog);
            this.mnuLog.ItemLinks.Add(this.btnViewLogicDiagram);
            this.mnuLog.Name = "mnuLog";
            this.mnuLog.Text = "Log";
            // 
            // mnuStatistics
            // 
            this.mnuStatistics.ItemLinks.Add(this.btnViewProcessTimeChart);
            this.mnuStatistics.ItemLinks.Add(this.btnViewStatisticsTable);
            this.mnuStatistics.Name = "mnuStatistics";
            this.mnuStatistics.Text = "Statistics";
            // 
            // mnuReport
            // 
            this.mnuReport.ItemLinks.Add(this.btnReport);
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Text = "Report";
            // 
            // mnuTool
            // 
            this.mnuTool.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuMonitorExportLog});
            this.mnuTool.Name = "mnuTool";
            this.mnuTool.Text = "Tool";
            this.mnuTool.Visible = false;
            // 
            // mnuMonitorExportLog
            // 
            this.mnuMonitorExportLog.ItemLinks.Add(this.btnExportLog);
            this.mnuMonitorExportLog.ItemLinks.Add(this.dtpkExportFrom);
            this.mnuMonitorExportLog.ItemLinks.Add(this.dtpkExportTo);
            this.mnuMonitorExportLog.Name = "mnuMonitorExportLog";
            this.mnuMonitorExportLog.Text = "Export Log";
            // 
            // exEditorUseOPC
            // 
            this.exEditorUseOPC.AutoHeight = false;
            this.exEditorUseOPC.Name = "exEditorUseOPC";
            // 
            // exEditorUseDDEA
            // 
            this.exEditorUseDDEA.AutoHeight = false;
            this.exEditorUseDDEA.Name = "exEditorUseDDEA";
            // 
            // rcmbOPCServer
            // 
            this.rcmbOPCServer.AutoHeight = false;
            this.rcmbOPCServer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcmbOPCServer.Name = "rcmbOPCServer";
            // 
            // exEditorAddressFilter
            // 
            this.exEditorAddressFilter.AutoHeight = false;
            this.exEditorAddressFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAddressFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.exEditorAddressFilter.Name = "exEditorAddressFilter";
            // 
            // exEditorDescriptionFilter
            // 
            this.exEditorDescriptionFilter.AutoHeight = false;
            this.exEditorDescriptionFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDescriptionFilter.Name = "exEditorDescriptionFilter";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy/MM/dd";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.repositoryItemDateEdit2.Appearance.Options.UseFont = true;
            this.repositoryItemDateEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemDateEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit2.EditFormat.FormatString = "yyyy/MM/dd";
            this.repositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // exRibbonStatusBar
            // 
            this.exRibbonStatusBar.ItemLinks.Add(this.lblMonitorCountLabel);
            this.exRibbonStatusBar.ItemLinks.Add(this.lblMonitorCount);
            this.exRibbonStatusBar.ItemLinks.Add(this.lblStatus);
            this.exRibbonStatusBar.Location = new System.Drawing.Point(0, 882);
            this.exRibbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exRibbonStatusBar.Name = "exRibbonStatusBar";
            this.exRibbonStatusBar.Ribbon = this.exRibbonControl;
            this.exRibbonStatusBar.Size = new System.Drawing.Size(1704, 33);
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlSystemLog});
            this.exDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpnlSystemLog
            // 
            this.dpnlSystemLog.Controls.Add(this.dpnlSystemLogContainer);
            this.dpnlSystemLog.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnlSystemLog.FloatSize = new System.Drawing.Size(548, 300);
            this.dpnlSystemLog.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dpnlSystemLog.ID = new System.Guid("e30a9e30-823c-43f2-b93e-ced4f4b17b75");
            this.dpnlSystemLog.Location = new System.Drawing.Point(0, 826);
            this.dpnlSystemLog.Name = "dpnlSystemLog";
            this.dpnlSystemLog.OriginalSize = new System.Drawing.Size(200, 188);
            this.dpnlSystemLog.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnlSystemLog.SavedIndex = 0;
            this.dpnlSystemLog.Size = new System.Drawing.Size(1469, 188);
            this.dpnlSystemLog.Text = "System Log";
            this.dpnlSystemLog.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dpnlSystemLogContainer
            // 
            this.dpnlSystemLogContainer.Controls.Add(this.ucSystemLogTable);
            this.dpnlSystemLogContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlSystemLogContainer.Name = "dpnlSystemLogContainer";
            this.dpnlSystemLogContainer.Size = new System.Drawing.Size(1461, 161);
            this.dpnlSystemLogContainer.TabIndex = 0;
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucSystemLogTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucSystemLogTable.Size = new System.Drawing.Size(1461, 161);
            this.ucSystemLogTable.TabIndex = 0;
            // 
            // mnuImportExport
            // 
            this.mnuImportExport.Name = "mnuImportExport";
            this.mnuImportExport.Text = "Import/Export";
            // 
            // exValueProgressBar
            // 
            this.exValueProgressBar.Appearance.BackColor = System.Drawing.Color.Lime;
            this.exValueProgressBar.Appearance.BackColor2 = System.Drawing.Color.Green;
            this.exValueProgressBar.AppearanceDisabled.BackColor = System.Drawing.Color.Lime;
            this.exValueProgressBar.AppearanceDisabled.BackColor2 = System.Drawing.Color.Green;
            this.exValueProgressBar.AppearanceFocused.BackColor = System.Drawing.Color.Lime;
            this.exValueProgressBar.AppearanceFocused.BackColor2 = System.Drawing.Color.Green;
            this.exValueProgressBar.AppearanceReadOnly.BackColor = System.Drawing.Color.Lime;
            this.exValueProgressBar.AppearanceReadOnly.BackColor2 = System.Drawing.Color.Green;
            this.exValueProgressBar.EndColor = System.Drawing.Color.Lime;
            this.exValueProgressBar.Maximum = 35767;
            this.exValueProgressBar.Minimum = -32768;
            this.exValueProgressBar.Name = "exValueProgressBar";
            this.exValueProgressBar.PercentView = false;
            this.exValueProgressBar.ReadOnly = true;
            this.exValueProgressBar.ShowTitle = true;
            // 
            // imgSubMenu
            // 
            this.imgSubMenu.ImageSize = new System.Drawing.Size(48, 48);
            this.imgSubMenu.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgSubMenu.ImageStream")));
            this.imgSubMenu.Images.SetKeyName(0, "Stock Index Up48x48.png");
            this.imgSubMenu.Images.SetKeyName(1, "Stock Index Down_48x48.png");
            // 
            // btnMonitorStop
            // 
            this.btnMonitorStop.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnMonitorStop.Appearance.Options.UseFont = true;
            this.btnMonitorStop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMonitorStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonitorStop.Enabled = false;
            this.btnMonitorStop.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitorStop.Image")));
            this.btnMonitorStop.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnMonitorStop.Location = new System.Drawing.Point(1481, 0);
            this.btnMonitorStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMonitorStop.Name = "btnMonitorStop";
            this.btnMonitorStop.Size = new System.Drawing.Size(120, 75);
            this.btnMonitorStop.TabIndex = 36;
            this.btnMonitorStop.Click += new System.EventHandler(this.btnMonitorStop_Click);
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.btnMonitorStart.Appearance.Options.UseFont = true;
            this.btnMonitorStart.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMonitorStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonitorStart.Image = ((System.Drawing.Image)(resources.GetObject("btnMonitorStart.Image")));
            this.btnMonitorStart.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnMonitorStart.Location = new System.Drawing.Point(1361, 0);
            this.btnMonitorStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(120, 75);
            this.btnMonitorStart.TabIndex = 34;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // pnlMainTabBtn
            // 
            this.pnlMainTabBtn.BackColor = System.Drawing.Color.White;
            this.pnlMainTabBtn.Controls.Add(this.btnCurrentValue);
            this.pnlMainTabBtn.Controls.Add(this.btnUserDevice);
            this.pnlMainTabBtn.Controls.Add(this.btnErrorReport);
            this.pnlMainTabBtn.Controls.Add(this.btnShowLogView);
            this.pnlMainTabBtn.Controls.Add(this.btnOption);
            this.pnlMainTabBtn.Controls.Add(this.panel2);
            this.pnlMainTabBtn.Controls.Add(this.btnMonitorStart);
            this.pnlMainTabBtn.Controls.Add(this.btnMonitorStop);
            this.pnlMainTabBtn.Controls.Add(this.panel6);
            this.pnlMainTabBtn.Controls.Add(this.btnExitHMI);
            this.pnlMainTabBtn.Controls.Add(this.btnErrorDetail);
            this.pnlMainTabBtn.Controls.Add(this.btnMain);
            this.pnlMainTabBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTabBtn.Location = new System.Drawing.Point(0, 176);
            this.pnlMainTabBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMainTabBtn.Name = "pnlMainTabBtn";
            this.pnlMainTabBtn.Size = new System.Drawing.Size(1704, 75);
            this.pnlMainTabBtn.TabIndex = 19;
            // 
            // btnCurrentValue
            // 
            this.btnCurrentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentValue.Appearance.Options.UseFont = true;
            this.btnCurrentValue.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCurrentValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCurrentValue.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCurrentValue.Location = new System.Drawing.Point(480, 0);
            this.btnCurrentValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCurrentValue.Name = "btnCurrentValue";
            this.btnCurrentValue.Size = new System.Drawing.Size(120, 75);
            this.btnCurrentValue.TabIndex = 43;
            this.btnCurrentValue.Text = "Robot\r\nCycle";
            this.btnCurrentValue.Click += new System.EventHandler(this.btnCurrentValue_Click);
            // 
            // btnUserDevice
            // 
            this.btnUserDevice.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserDevice.Appearance.Options.UseFont = true;
            this.btnUserDevice.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUserDevice.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUserDevice.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserDevice.Location = new System.Drawing.Point(360, 0);
            this.btnUserDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUserDevice.Name = "btnUserDevice";
            this.btnUserDevice.Size = new System.Drawing.Size(120, 75);
            this.btnUserDevice.TabIndex = 16;
            this.btnUserDevice.Text = "User\r\nDevice";
            this.btnUserDevice.Click += new System.EventHandler(this.btnUserDevice_Click);
            // 
            // btnErrorReport
            // 
            this.btnErrorReport.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorReport.Appearance.Options.UseFont = true;
            this.btnErrorReport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnErrorReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnErrorReport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnErrorReport.Location = new System.Drawing.Point(240, 0);
            this.btnErrorReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnErrorReport.Name = "btnErrorReport";
            this.btnErrorReport.Size = new System.Drawing.Size(120, 75);
            this.btnErrorReport.TabIndex = 47;
            this.btnErrorReport.Text = "Error\r\n Report";
            this.btnErrorReport.Click += new System.EventHandler(this.btnErrorReport_Click);
            // 
            // btnShowLogView
            // 
            this.btnShowLogView.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLogView.Appearance.Options.UseFont = true;
            this.btnShowLogView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnShowLogView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowLogView.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.btnShowLogView.DropDownControl = this.exLogViewItem;
            this.btnShowLogView.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnShowLogView.Location = new System.Drawing.Point(1098, 0);
            this.btnShowLogView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShowLogView.MenuManager = this.exRibbonControl;
            this.btnShowLogView.Name = "btnShowLogView";
            this.btnShowLogView.Size = new System.Drawing.Size(120, 75);
            this.btnShowLogView.TabIndex = 41;
            this.btnShowLogView.Text = "View";
            // 
            // exLogViewItem
            // 
            this.exLogViewItem.ItemLinks.Add(this.btnViewSymbolLog2);
            this.exLogViewItem.ItemLinks.Add(this.btnViewLogicDiagram2);
            this.exLogViewItem.ItemLinks.Add(this.btnRobotCycleView);
            this.exLogViewItem.ItemLinks.Add(this.btnUserDeviceView);
            this.exLogViewItem.ItemLinks.Add(this.btnExportPDF);
            this.exLogViewItem.Name = "exLogViewItem";
            this.exLogViewItem.Ribbon = this.exRibbonControl;
            // 
            // btnOption
            // 
            this.btnOption.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.Appearance.Options.UseFont = true;
            this.btnOption.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOption.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.btnOption.DropDownControl = this.exAppMenu;
            this.btnOption.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOption.Location = new System.Drawing.Point(1218, 0);
            this.btnOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOption.MenuManager = this.exRibbonControl;
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(120, 75);
            this.btnOption.TabIndex = 38;
            this.btnOption.Text = "Option";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1338, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(23, 75);
            this.panel2.TabIndex = 45;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1601, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(23, 75);
            this.panel6.TabIndex = 39;
            // 
            // btnExitHMI
            // 
            this.btnExitHMI.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitHMI.Appearance.Options.UseFont = true;
            this.btnExitHMI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExitHMI.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExitHMI.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExitHMI.Location = new System.Drawing.Point(1624, 0);
            this.btnExitHMI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExitHMI.Name = "btnExitHMI";
            this.btnExitHMI.Size = new System.Drawing.Size(80, 75);
            this.btnExitHMI.TabIndex = 46;
            this.btnExitHMI.Text = "Exit";
            this.btnExitHMI.Click += new System.EventHandler(this.btnExitHMI_Click);
            // 
            // btnErrorDetail
            // 
            this.btnErrorDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorDetail.Appearance.Options.UseFont = true;
            this.btnErrorDetail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnErrorDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnErrorDetail.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnErrorDetail.Location = new System.Drawing.Point(120, 0);
            this.btnErrorDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnErrorDetail.Name = "btnErrorDetail";
            this.btnErrorDetail.Size = new System.Drawing.Size(120, 75);
            this.btnErrorDetail.TabIndex = 13;
            this.btnErrorDetail.Text = "Error\r\nDetail";
            this.btnErrorDetail.Click += new System.EventHandler(this.btnErrorDetail_Click);
            // 
            // btnMain
            // 
            this.btnMain.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Appearance.Options.UseFont = true;
            this.btnMain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMain.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(120, 75);
            this.btnMain.TabIndex = 44;
            this.btnMain.Text = "Main";
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // grpMonitorStatus
            // 
            this.grpMonitorStatus.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpMonitorStatus.AppearanceCaption.Options.UseFont = true;
            this.grpMonitorStatus.Controls.Add(this.ucStatusView);
            this.grpMonitorStatus.Controls.Add(this.ucClock);
            this.grpMonitorStatus.Controls.Add(this.ucTrackerMode);
            this.grpMonitorStatus.Controls.Add(this.ucMonitorStatus);
            this.grpMonitorStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpMonitorStatus.Location = new System.Drawing.Point(1374, 274);
            this.grpMonitorStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMonitorStatus.Name = "grpMonitorStatus";
            this.grpMonitorStatus.Size = new System.Drawing.Size(330, 608);
            this.grpMonitorStatus.TabIndex = 29;
            this.grpMonitorStatus.Text = "Monitor Status";
            this.grpMonitorStatus.Visible = false;
            // 
            // ucStatusView
            // 
            this.ucStatusView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatusView.Location = new System.Drawing.Point(2, 294);
            this.ucStatusView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucStatusView.Name = "ucStatusView";
            this.ucStatusView.Size = new System.Drawing.Size(326, 312);
            this.ucStatusView.TabIndex = 15;
            // 
            // ucClock
            // 
            this.ucClock.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucClock.Location = new System.Drawing.Point(2, 211);
            this.ucClock.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucClock.Name = "ucClock";
            this.ucClock.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ucClock.Size = new System.Drawing.Size(326, 83);
            this.ucClock.TabIndex = 11;
            // 
            // ucTrackerMode
            // 
            this.ucTrackerMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTrackerMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTrackerMode.Location = new System.Drawing.Point(2, 122);
            this.ucTrackerMode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucTrackerMode.MonitorType = UDM.Log.EMMonitorType.Detection;
            this.ucTrackerMode.Name = "ucTrackerMode";
            this.ucTrackerMode.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ucTrackerMode.Size = new System.Drawing.Size(326, 89);
            this.ucTrackerMode.TabIndex = 14;
            // 
            // ucMonitorStatus
            // 
            this.ucMonitorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucMonitorStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMonitorStatus.Location = new System.Drawing.Point(2, 33);
            this.ucMonitorStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucMonitorStatus.Name = "ucMonitorStatus";
            this.ucMonitorStatus.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ucMonitorStatus.Size = new System.Drawing.Size(326, 89);
            this.ucMonitorStatus.TabIndex = 13;
            // 
            // tpErrorNew
            // 
            this.tpErrorNew.Appearance.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tpErrorNew.Appearance.HeaderActive.Options.UseBackColor = true;
            this.tpErrorNew.Controls.Add(this.ucErrorView);
            this.tpErrorNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpErrorNew.Name = "tpErrorNew";
            this.tpErrorNew.Size = new System.Drawing.Size(1367, 566);
            this.tpErrorNew.Text = "Error";
            // 
            // ucErrorView
            // 
            this.ucErrorView.Appearance.BackColor = System.Drawing.Color.White;
            this.ucErrorView.Appearance.Options.UseBackColor = true;
            this.ucErrorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorView.ErrorInfoS = null;
            this.ucErrorView.Location = new System.Drawing.Point(0, 0);
            this.ucErrorView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucErrorView.Name = "ucErrorView";
            this.ucErrorView.ProcessS = null;
            this.ucErrorView.Size = new System.Drawing.Size(1367, 566);
            this.ucErrorView.TabIndex = 0;
            // 
            // tpUserDevice
            // 
            this.tpUserDevice.Appearance.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tpUserDevice.Appearance.HeaderActive.Options.UseBackColor = true;
            this.tpUserDevice.Controls.Add(this.sptUserMain);
            this.tpUserDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpUserDevice.Name = "tpUserDevice";
            this.tpUserDevice.Size = new System.Drawing.Size(1367, 566);
            this.tpUserDevice.Text = "User Device";
            // 
            // sptUserMain
            // 
            this.sptUserMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptUserMain.Location = new System.Drawing.Point(0, 0);
            this.sptUserMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sptUserMain.Name = "sptUserMain";
            this.sptUserMain.Panel1.Controls.Add(this.grpUserDashBoard);
            this.sptUserMain.Panel1.MinSize = 350;
            this.sptUserMain.Panel1.Text = "Panel1";
            this.sptUserMain.Panel2.Controls.Add(this.grpUserDeviceValue);
            this.sptUserMain.Panel2.Text = "Panel2";
            this.sptUserMain.Size = new System.Drawing.Size(1367, 566);
            this.sptUserMain.SplitterPosition = 300;
            this.sptUserMain.TabIndex = 23;
            this.sptUserMain.Text = "splitContainerControl1";
            // 
            // grpUserDashBoard
            // 
            this.grpUserDashBoard.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpUserDashBoard.AppearanceCaption.Options.UseFont = true;
            this.grpUserDashBoard.Controls.Add(this.grdUserDevice);
            this.grpUserDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserDashBoard.Location = new System.Drawing.Point(0, 0);
            this.grpUserDashBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpUserDashBoard.Name = "grpUserDashBoard";
            this.grpUserDashBoard.Size = new System.Drawing.Size(350, 566);
            this.grpUserDashBoard.TabIndex = 25;
            this.grpUserDashBoard.Text = "User Device Dash Board ( Only Word )";
            // 
            // grdUserDevice
            // 
            this.grdUserDevice.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdUserDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserDevice.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserDevice.Location = new System.Drawing.Point(2, 33);
            this.grdUserDevice.MainView = this.grvUserDevice;
            this.grdUserDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserDevice.Name = "grdUserDevice";
            this.grdUserDevice.Size = new System.Drawing.Size(346, 531);
            this.grdUserDevice.TabIndex = 24;
            this.grdUserDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserDevice,
            this.gridView2});
            // 
            // grvUserDevice
            // 
            this.grvUserDevice.Appearance.ItemFocused.ForeColor = System.Drawing.Color.Black;
            this.grvUserDevice.Appearance.ItemFocused.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.grvUserDevice.Appearance.ItemFocused.Options.UseForeColor = true;
            this.grvUserDevice.Appearance.ItemNormal.Options.UseTextOptions = true;
            this.grvUserDevice.Appearance.ItemNormal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvUserDevice.Appearance.ItemNormal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvUserDevice.Appearance.ItemSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grvUserDevice.Appearance.ItemSelected.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.grvUserDevice.Appearance.ItemSelected.Options.UseBackColor = true;
            this.grvUserDevice.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.grvUserDevice.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvUserDevice.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grvUserDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tilecolAddress,
            this.tilecolName,
            this.tilecolValue});
            this.grvUserDevice.GridControl = this.grdUserDevice;
            this.grvUserDevice.Name = "grvUserDevice";
            this.grvUserDevice.OptionsBehavior.Editable = false;
            this.grvUserDevice.OptionsTiles.HighlightFocusedTileOnGridLoad = true;
            this.grvUserDevice.OptionsTiles.IndentBetweenGroups = 30;
            this.grvUserDevice.OptionsTiles.IndentBetweenItems = 20;
            this.grvUserDevice.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(10);
            this.grvUserDevice.OptionsTiles.ItemSize = new System.Drawing.Size(300, 110);
            this.grvUserDevice.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.grvUserDevice.OptionsTiles.RowCount = 10;
            tileViewItemElement1.AnchorIndent = 0;
            tileViewItemElement1.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            tileViewItemElement1.Appearance.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement1.Appearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tileViewItemElement1.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement1.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement1.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement1.Column = this.tilecolName;
            tileViewItemElement1.Height = 40;
            tileViewItemElement1.StretchHorizontal = true;
            tileViewItemElement1.Text = "tilecolName";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement2.AnchorIndent = 2;
            tileViewItemElement2.Appearance.Normal.BackColor = System.Drawing.Color.YellowGreen;
            tileViewItemElement2.Appearance.Normal.BackColor2 = System.Drawing.Color.GreenYellow;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement2.Appearance.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tileViewItemElement2.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement2.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement2.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement2.Column = this.tilecolValue;
            tileViewItemElement2.Height = 50;
            tileViewItemElement2.StretchHorizontal = true;
            tileViewItemElement2.Text = "tilecolValue";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileViewItemElement3.Appearance.Normal.BackColor = System.Drawing.Color.Black;
            tileViewItemElement3.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement3.Column = null;
            tileViewItemElement3.Height = 2;
            tileViewItemElement3.StretchHorizontal = true;
            tileViewItemElement3.Text = "";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(0, 40);
            tileViewItemElement4.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement4.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement4.Column = null;
            tileViewItemElement4.StretchVertical = true;
            tileViewItemElement4.Text = "";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(-10, 0);
            tileViewItemElement4.Width = 10;
            tileViewItemElement5.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement5.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement5.Column = null;
            tileViewItemElement5.StretchVertical = true;
            tileViewItemElement5.Text = "";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(10, 0);
            tileViewItemElement5.Width = 10;
            tileViewItemElement6.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement6.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement6.Column = null;
            tileViewItemElement6.Height = 10;
            tileViewItemElement6.StretchHorizontal = true;
            tileViewItemElement6.Text = "";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(0, -10);
            tileViewItemElement7.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            tileViewItemElement7.Appearance.Normal.Options.UseBackColor = true;
            tileViewItemElement7.Column = null;
            tileViewItemElement7.Height = 10;
            tileViewItemElement7.StretchHorizontal = true;
            tileViewItemElement7.Text = "";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(0, 10);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement1);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement2);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement3);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement4);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement5);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement6);
            this.grvUserDevice.TileTemplate.Add(tileViewItemElement7);
            // 
            // tilecolAddress
            // 
            this.tilecolAddress.Caption = "Address";
            this.tilecolAddress.FieldName = "Address";
            this.tilecolAddress.Name = "tilecolAddress";
            this.tilecolAddress.Visible = true;
            this.tilecolAddress.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdUserDevice;
            this.gridView2.Name = "gridView2";
            // 
            // grpUserDeviceValue
            // 
            this.grpUserDeviceValue.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpUserDeviceValue.AppearanceCaption.Options.UseFont = true;
            this.grpUserDeviceValue.Controls.Add(this.grdUserAll);
            this.grpUserDeviceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUserDeviceValue.Location = new System.Drawing.Point(0, 0);
            this.grpUserDeviceValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpUserDeviceValue.Name = "grpUserDeviceValue";
            this.grpUserDeviceValue.Size = new System.Drawing.Size(1011, 566);
            this.grpUserDeviceValue.TabIndex = 7;
            this.grpUserDeviceValue.Text = "User Device RunTime Value";
            // 
            // grdUserAll
            // 
            this.grdUserAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserAll.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserAll.Location = new System.Drawing.Point(2, 33);
            this.grdUserAll.MainView = this.grvUserAll;
            this.grdUserAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserAll.Name = "grdUserAll";
            this.grdUserAll.Size = new System.Drawing.Size(1007, 531);
            this.grdUserAll.TabIndex = 6;
            this.grdUserAll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserAll,
            this.gridView1});
            // 
            // grvUserAll
            // 
            this.grvUserAll.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvUserAll.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvUserAll.ColumnPanelRowHeight = 35;
            this.grvUserAll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserAddress,
            this.colUserType,
            this.colUserValue,
            this.colUserUpCount,
            this.colUserName,
            this.colLastTime,
            this.colShowWord});
            this.grvUserAll.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserAll.GridControl = this.grdUserAll;
            this.grvUserAll.IndicatorWidth = 50;
            this.grvUserAll.Name = "grvUserAll";
            this.grvUserAll.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUserAll.OptionsDetail.AllowZoomDetail = false;
            this.grvUserAll.OptionsDetail.EnableMasterViewMode = false;
            this.grvUserAll.OptionsDetail.ShowDetailTabs = false;
            this.grvUserAll.OptionsDetail.SmartDetailExpand = false;
            this.grvUserAll.OptionsView.EnableAppearanceEvenRow = true;
            this.grvUserAll.OptionsView.ShowAutoFilterRow = true;
            this.grvUserAll.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUserAll.OptionsView.ShowGroupPanel = false;
            this.grvUserAll.RowHeight = 30;
            this.grvUserAll.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserType, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvUserAll.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvUserAll_CustomDrawRowIndicator);
            this.grvUserAll.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvUserAll_CustomDrawCell);
            this.grvUserAll.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvUserAll_CellValueChanged);
            this.grvUserAll.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvUserAll_CellValueChanging);
            // 
            // colUserAddress
            // 
            this.colUserAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colUserAddress.AppearanceCell.Options.UseFont = true;
            this.colUserAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colUserAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colUserAddress.AppearanceHeader.Options.UseFont = true;
            this.colUserAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserAddress.Caption = "Address";
            this.colUserAddress.FieldName = "Address";
            this.colUserAddress.MinWidth = 100;
            this.colUserAddress.Name = "colUserAddress";
            this.colUserAddress.OptionsColumn.FixedWidth = true;
            this.colUserAddress.OptionsColumn.ReadOnly = true;
            this.colUserAddress.Visible = true;
            this.colUserAddress.VisibleIndex = 2;
            this.colUserAddress.Width = 120;
            // 
            // colUserType
            // 
            this.colUserType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colUserType.AppearanceCell.Options.UseFont = true;
            this.colUserType.AppearanceCell.Options.UseTextOptions = true;
            this.colUserType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colUserType.AppearanceHeader.Options.UseFont = true;
            this.colUserType.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserType.Caption = "Type";
            this.colUserType.ColumnEdit = this.repositoryItemComboBox4;
            this.colUserType.FieldName = "DataType";
            this.colUserType.MinWidth = 70;
            this.colUserType.Name = "colUserType";
            this.colUserType.OptionsColumn.FixedWidth = true;
            this.colUserType.OptionsColumn.ReadOnly = true;
            this.colUserType.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colUserType.Visible = true;
            this.colUserType.VisibleIndex = 3;
            this.colUserType.Width = 100;
            // 
            // colUserValue
            // 
            this.colUserValue.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colUserValue.AppearanceCell.Options.UseFont = true;
            this.colUserValue.AppearanceCell.Options.UseTextOptions = true;
            this.colUserValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUserValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colUserValue.AppearanceHeader.Options.UseFont = true;
            this.colUserValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserValue.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserValue.Caption = "Value";
            this.colUserValue.FieldName = "Value";
            this.colUserValue.MinWidth = 70;
            this.colUserValue.Name = "colUserValue";
            this.colUserValue.OptionsColumn.FixedWidth = true;
            this.colUserValue.OptionsColumn.ReadOnly = true;
            this.colUserValue.Visible = true;
            this.colUserValue.VisibleIndex = 4;
            this.colUserValue.Width = 100;
            // 
            // colUserUpCount
            // 
            this.colUserUpCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colUserUpCount.AppearanceCell.Options.UseFont = true;
            this.colUserUpCount.AppearanceCell.Options.UseTextOptions = true;
            this.colUserUpCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUserUpCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colUserUpCount.AppearanceHeader.Options.UseFont = true;
            this.colUserUpCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserUpCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserUpCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserUpCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserUpCount.Caption = "Count";
            this.colUserUpCount.FieldName = "ChangeCount";
            this.colUserUpCount.MinWidth = 70;
            this.colUserUpCount.Name = "colUserUpCount";
            this.colUserUpCount.OptionsColumn.FixedWidth = true;
            this.colUserUpCount.OptionsColumn.ReadOnly = true;
            this.colUserUpCount.Visible = true;
            this.colUserUpCount.VisibleIndex = 5;
            this.colUserUpCount.Width = 100;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colUserName.AppearanceCell.Options.UseFont = true;
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.Caption = "Name";
            this.colUserName.FieldName = "Name";
            this.colUserName.MinWidth = 300;
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.FixedWidth = true;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 300;
            // 
            // colLastTime
            // 
            this.colLastTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colLastTime.AppearanceCell.Options.UseFont = true;
            this.colLastTime.AppearanceCell.Options.UseTextOptions = true;
            this.colLastTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colLastTime.AppearanceHeader.Options.UseFont = true;
            this.colLastTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colLastTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLastTime.Caption = "Last Time";
            this.colLastTime.FieldName = "DurationTime";
            this.colLastTime.MinWidth = 100;
            this.colLastTime.Name = "colLastTime";
            this.colLastTime.OptionsColumn.AllowEdit = false;
            this.colLastTime.OptionsColumn.FixedWidth = true;
            this.colLastTime.OptionsColumn.ReadOnly = true;
            this.colLastTime.Width = 100;
            // 
            // colShowWord
            // 
            this.colShowWord.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colShowWord.AppearanceCell.Options.UseFont = true;
            this.colShowWord.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colShowWord.AppearanceHeader.Options.UseFont = true;
            this.colShowWord.AppearanceHeader.Options.UseTextOptions = true;
            this.colShowWord.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colShowWord.Caption = "Show";
            this.colShowWord.ColumnEdit = this.exShowWord;
            this.colShowWord.FieldName = "DetailViewShow";
            this.colShowWord.MinWidth = 70;
            this.colShowWord.Name = "colShowWord";
            this.colShowWord.OptionsColumn.FixedWidth = true;
            this.colShowWord.Visible = true;
            this.colShowWord.VisibleIndex = 0;
            this.colShowWord.Width = 100;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdUserAll;
            this.gridView1.Name = "gridView1";
            // 
            // tpErrorLog
            // 
            this.tpErrorLog.Appearance.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tpErrorLog.Appearance.HeaderActive.Options.UseBackColor = true;
            this.tpErrorLog.Controls.Add(this.ucErrorLogTable);
            this.tpErrorLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpErrorLog.Name = "tpErrorLog";
            this.tpErrorLog.Size = new System.Drawing.Size(1367, 566);
            this.tpErrorLog.Text = "Error Log List";
            // 
            // ucErrorLogTable
            // 
            this.ucErrorLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorLogTable.ErrorInfoS = null;
            this.ucErrorLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucErrorLogTable.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucErrorLogTable.Name = "ucErrorLogTable";
            this.ucErrorLogTable.Size = new System.Drawing.Size(1367, 566);
            this.ucErrorLogTable.TabIndex = 25;
            // 
            // tpCurrentSymbol
            // 
            this.tpCurrentSymbol.Appearance.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tpCurrentSymbol.Appearance.HeaderActive.Options.UseBackColor = true;
            this.tpCurrentSymbol.Controls.Add(this.grpCycleCollectTag);
            this.tpCurrentSymbol.Controls.Add(this.splitterControl1);
            this.tpCurrentSymbol.Controls.Add(this.grpRobotCycleTime);
            this.tpCurrentSymbol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpCurrentSymbol.Name = "tpCurrentSymbol";
            this.tpCurrentSymbol.Size = new System.Drawing.Size(1367, 566);
            this.tpCurrentSymbol.Text = "Robot Cycle";
            // 
            // grpCycleCollectTag
            // 
            this.grpCycleCollectTag.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpCycleCollectTag.AppearanceCaption.Options.UseFont = true;
            this.grpCycleCollectTag.Controls.Add(this.grdRuntimeValue);
            this.grpCycleCollectTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCycleCollectTag.Location = new System.Drawing.Point(564, 0);
            this.grpCycleCollectTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpCycleCollectTag.Name = "grpCycleCollectTag";
            this.grpCycleCollectTag.Size = new System.Drawing.Size(803, 566);
            this.grpCycleCollectTag.TabIndex = 5;
            this.grpCycleCollectTag.Text = "Collect Tag Runtime Value";
            // 
            // grdRuntimeValue
            // 
            this.grdRuntimeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRuntimeValue.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRuntimeValue.Location = new System.Drawing.Point(2, 33);
            this.grdRuntimeValue.MainView = this.grvRuntimeValue;
            this.grdRuntimeValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRuntimeValue.Name = "grdRuntimeValue";
            this.grdRuntimeValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdRuntimeValue.Size = new System.Drawing.Size(799, 531);
            this.grdRuntimeValue.TabIndex = 4;
            this.grdRuntimeValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRuntimeValue,
            this.gridView3});
            // 
            // grvRuntimeValue
            // 
            this.grvRuntimeValue.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvRuntimeValue.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvRuntimeValue.ColumnPanelRowHeight = 35;
            this.grvRuntimeValue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDataType,
            this.colCurrentValue,
            this.colChangeCount,
            this.colDescription});
            this.grvRuntimeValue.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRuntimeValue.GridControl = this.grdRuntimeValue;
            this.grvRuntimeValue.IndicatorWidth = 50;
            this.grvRuntimeValue.Name = "grvRuntimeValue";
            this.grvRuntimeValue.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRuntimeValue.OptionsDetail.AllowZoomDetail = false;
            this.grvRuntimeValue.OptionsDetail.EnableMasterViewMode = false;
            this.grvRuntimeValue.OptionsDetail.ShowDetailTabs = false;
            this.grvRuntimeValue.OptionsDetail.SmartDetailExpand = false;
            this.grvRuntimeValue.OptionsView.EnableAppearanceEvenRow = true;
            this.grvRuntimeValue.OptionsView.ShowAutoFilterRow = true;
            this.grvRuntimeValue.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRuntimeValue.OptionsView.ShowGroupPanel = false;
            this.grvRuntimeValue.RowHeight = 30;
            this.grvRuntimeValue.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAddress, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDescription, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 100;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 120;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colDataType.AppearanceCell.Options.UseFont = true;
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colDataType.AppearanceHeader.Options.UseFont = true;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDataType.Caption = "Type";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "DataType";
            this.colDataType.MinWidth = 70;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            this.colDataType.Width = 100;
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
            // colCurrentValue
            // 
            this.colCurrentValue.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colCurrentValue.AppearanceCell.Options.UseFont = true;
            this.colCurrentValue.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCurrentValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colCurrentValue.AppearanceHeader.Options.UseFont = true;
            this.colCurrentValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentValue.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCurrentValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCurrentValue.Caption = "Value";
            this.colCurrentValue.FieldName = "CurrentValue";
            this.colCurrentValue.MinWidth = 70;
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.OptionsColumn.AllowEdit = false;
            this.colCurrentValue.OptionsColumn.FixedWidth = true;
            this.colCurrentValue.OptionsColumn.ReadOnly = true;
            this.colCurrentValue.Visible = true;
            this.colCurrentValue.VisibleIndex = 3;
            this.colCurrentValue.Width = 100;
            // 
            // colChangeCount
            // 
            this.colChangeCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colChangeCount.AppearanceCell.Options.UseFont = true;
            this.colChangeCount.AppearanceCell.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colChangeCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colChangeCount.AppearanceHeader.Options.UseFont = true;
            this.colChangeCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChangeCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colChangeCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChangeCount.Caption = "Count";
            this.colChangeCount.FieldName = "ChangeCount";
            this.colChangeCount.MinWidth = 70;
            this.colChangeCount.Name = "colChangeCount";
            this.colChangeCount.OptionsColumn.AllowEdit = false;
            this.colChangeCount.OptionsColumn.FixedWidth = true;
            this.colChangeCount.OptionsColumn.ReadOnly = true;
            this.colChangeCount.Visible = true;
            this.colChangeCount.VisibleIndex = 4;
            this.colChangeCount.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 20;
            // 
            // exEditorCheckBox
            // 
            this.exEditorCheckBox.AutoHeight = false;
            this.exEditorCheckBox.Name = "exEditorCheckBox";
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
            // gridView3
            // 
            this.gridView3.GridControl = this.grdRuntimeValue;
            this.gridView3.Name = "gridView3";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(558, 0);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 566);
            this.splitterControl1.TabIndex = 38;
            this.splitterControl1.TabStop = false;
            // 
            // grpRobotCycleTime
            // 
            this.grpRobotCycleTime.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpRobotCycleTime.AppearanceCaption.Options.UseFont = true;
            this.grpRobotCycleTime.Controls.Add(this.ucRobotCycle);
            this.grpRobotCycleTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpRobotCycleTime.Location = new System.Drawing.Point(0, 0);
            this.grpRobotCycleTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpRobotCycleTime.Name = "grpRobotCycleTime";
            this.grpRobotCycleTime.Size = new System.Drawing.Size(558, 566);
            this.grpRobotCycleTime.TabIndex = 37;
            this.grpRobotCycleTime.Text = "Robot Cycle Time";
            // 
            // ucRobotCycle
            // 
            this.ucRobotCycle.CycleTagS = null;
            this.ucRobotCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRobotCycle.Location = new System.Drawing.Point(2, 33);
            this.ucRobotCycle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucRobotCycle.Name = "ucRobotCycle";
            this.ucRobotCycle.Size = new System.Drawing.Size(554, 531);
            this.ucRobotCycle.TabIndex = 6;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tabMainError);
            this.tpMain.Controls.Add(this.sptMain);
            this.tpMain.Controls.Add(this.grpProcessFlowChart);
            this.tpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(1367, 566);
            this.tpMain.Text = "Main";
            // 
            // tabMainError
            // 
            this.tabMainError.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabMainError.AppearancePage.Header.Options.UseFont = true;
            this.tabMainError.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tabMainError.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMainError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainError.Location = new System.Drawing.Point(0, 0);
            this.tabMainError.Name = "tabMainError";
            this.tabMainError.SelectedTabPage = this.tpErrorList;
            this.tabMainError.Size = new System.Drawing.Size(1004, 566);
            this.tabMainError.TabIndex = 39;
            this.tabMainError.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpErrorList,
            this.tpAnalysis});
            // 
            // tpErrorList
            // 
            this.tpErrorList.Controls.Add(this.ucErrorListPanelS);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Size = new System.Drawing.Size(997, 524);
            this.tpErrorList.Text = "Process Error Monitoring";
            // 
            // ucErrorListPanelS
            // 
            this.ucErrorListPanelS.AutoScroll = true;
            this.ucErrorListPanelS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorListPanelS.Location = new System.Drawing.Point(0, 0);
            this.ucErrorListPanelS.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucErrorListPanelS.Name = "ucErrorListPanelS";
            this.ucErrorListPanelS.Size = new System.Drawing.Size(997, 524);
            this.ucErrorListPanelS.TabIndex = 0;
            // 
            // tpAnalysis
            // 
            this.tpAnalysis.Controls.Add(this.pnlView);
            this.tpAnalysis.Name = "tpAnalysis";
            this.tpAnalysis.Size = new System.Drawing.Size(997, 524);
            this.tpAnalysis.Text = "Ladder View";
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.SystemColors.Control;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(997, 524);
            this.pnlView.TabIndex = 6;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.sptMain.Location = new System.Drawing.Point(1004, 0);
            this.sptMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(6, 566);
            this.sptMain.TabIndex = 38;
            this.sptMain.TabStop = false;
            // 
            // grpProcessFlowChart
            // 
            this.grpProcessFlowChart.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpProcessFlowChart.AppearanceCaption.Options.UseFont = true;
            this.grpProcessFlowChart.Controls.Add(this.tabFlow);
            this.grpProcessFlowChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpProcessFlowChart.Location = new System.Drawing.Point(1010, 0);
            this.grpProcessFlowChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpProcessFlowChart.Name = "grpProcessFlowChart";
            this.grpProcessFlowChart.Size = new System.Drawing.Size(357, 566);
            this.grpProcessFlowChart.TabIndex = 35;
            this.grpProcessFlowChart.Text = "Process Flow Chart";
            // 
            // tabFlow
            // 
            this.tabFlow.AppearancePage.Header.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.tabFlow.AppearancePage.Header.Options.UseFont = true;
            this.tabFlow.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Green;
            this.tabFlow.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.tabFlow.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabFlow.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFlow.Location = new System.Drawing.Point(2, 33);
            this.tabFlow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.Size = new System.Drawing.Size(353, 531);
            this.tabFlow.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.tabMain.Location = new System.Drawing.Point(0, 274);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpMain;
            this.tabMain.Size = new System.Drawing.Size(1374, 608);
            this.tabMain.TabIndex = 14;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMain,
            this.tpErrorNew,
            this.tpErrorLog,
            this.tpUserDevice,
            this.tpCurrentSymbol});
            // 
            // tmrSystemLog
            // 
            this.tmrSystemLog.Interval = 3600000;
            this.tmrSystemLog.Tick += new System.EventHandler(this.tmrSystemLog_Tick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.exRibbonControl;
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            this.popupMenu2.Ribbon = this.exRibbonControl;
            // 
            // popupMenu3
            // 
            this.popupMenu3.Name = "popupMenu3";
            this.popupMenu3.Ribbon = this.exRibbonControl;
            // 
            // popupMenu4
            // 
            this.popupMenu4.Name = "popupMenu4";
            this.popupMenu4.Ribbon = this.exRibbonControl;
            // 
            // popupMenu5
            // 
            this.popupMenu5.Name = "popupMenu5";
            this.popupMenu5.Ribbon = this.exRibbonControl;
            // 
            // tmrSPDStatusCheck
            // 
            this.tmrSPDStatusCheck.Interval = 10000;
            this.tmrSPDStatusCheck.Tick += new System.EventHandler(this.tmrSPDStatusCheck_Tick);
            // 
            // tmrLoadFirst
            // 
            this.tmrLoadFirst.Interval = 5000;
            this.tmrLoadFirst.Tick += new System.EventHandler(this.tmrLoadFirst_Tick);
            // 
            // popupMenu6
            // 
            this.popupMenu6.Name = "popupMenu6";
            this.popupMenu6.Ribbon = this.exRibbonControl;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1704, 23);
            this.panel1.TabIndex = 37;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 915);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpMonitorStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMainTabBtn);
            this.Controls.Add(this.exRibbonStatusBar);
            this.Controls.Add(this.exRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1200, 712);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.StatusBar = this.exRibbonStatusBar;
            this.Text = "Ladder Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseOPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseDDEA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcmbOPCServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.dpnlSystemLog.ResumeLayout(false);
            this.dpnlSystemLogContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exValueProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSubMenu)).EndInit();
            this.pnlMainTabBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exLogViewItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitorStatus)).EndInit();
            this.grpMonitorStatus.ResumeLayout(false);
            this.tpErrorNew.ResumeLayout(false);
            this.tpUserDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptUserMain)).EndInit();
            this.sptUserMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpUserDashBoard)).EndInit();
            this.grpUserDashBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpUserDeviceValue)).EndInit();
            this.grpUserDeviceValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpErrorLog.ResumeLayout(false);
            this.tpCurrentSymbol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCycleCollectTag)).EndInit();
            this.grpCycleCollectTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRuntimeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRuntimeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRobotCycleTime)).EndInit();
            this.grpRobotCycleTime.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMainError)).EndInit();
            this.tabMainError.ResumeLayout(false);
            this.tpErrorList.ResumeLayout(false);
            this.tpAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).EndInit();
            this.grpProcessFlowChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomeFile;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar exRibbonStatusBar;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu exAppMenu;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomeSkin;
        private DevExpress.XtraBars.RibbonGalleryBarItem exRibbonGallery;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgView;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuTool;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private DevExpress.XtraBars.Docking.DockManager exDockManager;
        private DevExpress.Utils.ImageCollection imgListRibbon;
        private DevExpress.Utils.ImageCollection imgListRibbonLarge;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePatternItem;
        private DevExpress.XtraBars.BarButtonItem btnFlowChart;
        private DevExpress.XtraBars.BarButtonItem btnCreateDataBase;
        private DevExpress.XtraBars.BarButtonItem btnTestDBConnection;
        private DevExpress.XtraBars.BarButtonItem btnExportLog;
        private DevExpress.XtraBars.BarEditItem dtpkExportFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorExportFrom;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDatabase;
        private DevExpress.XtraBars.BarEditItem dtpkExportTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorExportTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorUseOPC;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorUseDDEA;
        private DevExpress.XtraBars.BarButtonItem btnViewSymbolLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuLog;
        private DevExpress.XtraBars.BarButtonItem btnViewCycleLog;
        private DevExpress.XtraBars.Docking.DockPanel dpnlSystemLog;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlSystemLogContainer;
        private UCSystemLogTable ucSystemLogTable;
        private DevExpress.XtraBars.BarStaticItem lblMonitorCountLabel;
        private DevExpress.XtraBars.BarStaticItem lblMonitorCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rcmbOPCServer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuImportExport;
        private DevExpress.XtraBars.BarButtonItem btnViewLogicDiagram;
        private DevExpress.XtraBars.BarButtonItem btnMaximized;
        private DevExpress.XtraBars.BarCheckItem chkMonitorFlowItem;
        private DevExpress.XtraBars.BarCheckItem chkMonitorErrorDetection;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuStatistics;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnViewProcessTimeChart;
        private DevExpress.XtraBars.BarButtonItem btnViewStatisticsTable;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDescriptionFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorMode;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorExportLog;
        private DevExpress.XtraEditors.SimpleButton btnMonitorStop;
        private DevExpress.XtraEditors.SimpleButton btnMonitorStart;
        private System.Windows.Forms.Panel pnlMainTabBtn;
        private DevExpress.XtraEditors.SimpleButton btnUserDevice;
        private DevExpress.Utils.ImageCollection imgSubMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuModel;
        private DevExpress.XtraBars.BarButtonItem btnProjectSet;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar exValueProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exShowWord;
        private DevExpress.XtraEditors.DropDownButton btnOption;
        private DevExpress.XtraBars.BarCheckItem chkShowSysLog;
        private DevExpress.XtraBars.BarCheckItem chkShowMonitorStatus;
        private DevExpress.XtraBars.BarToggleSwitchItem toggMainEditorMode;
        private DevExpress.XtraEditors.GroupControl grpMonitorStatus;
        private UCClock ucClock;
        private UCTrackerMode ucTrackerMode;
        private UCMonitorStatus ucMonitorStatus;
        private DevExpress.XtraBars.BarCheckItem chkMainTabHeader;
        private DevExpress.XtraEditors.DropDownButton btnShowLogView;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu exLogViewItem;
        private DevExpress.XtraBars.BarButtonItem btnViewSymbolLog2;
        private DevExpress.XtraBars.BarButtonItem btnViewLogicDiagram2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpMain;
        private DevExpress.XtraTab.XtraTabPage tpCurrentSymbol;
        private DevExpress.XtraEditors.GroupControl grpCycleCollectTag;
        private DevExpress.XtraGrid.GridControl grdRuntimeValue;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRuntimeValue;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeCount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraTab.XtraTabPage tpErrorLog;
        private UCErrorLogTable ucErrorLogTable;
        private DevExpress.XtraTab.XtraTabPage tpUserDevice;
        private DevExpress.XtraEditors.SplitContainerControl sptUserMain;
        private DevExpress.XtraEditors.GroupControl grpUserDashBoard;
        private DevExpress.XtraGrid.GridControl grdUserDevice;
        private DevExpress.XtraGrid.Views.Tile.TileView grvUserDevice;
        private DevExpress.XtraGrid.Columns.TileViewColumn tilecolAddress;
        private DevExpress.XtraGrid.Columns.TileViewColumn tilecolName;
        private DevExpress.XtraGrid.Columns.TileViewColumn tilecolValue;
        private DevExpress.XtraEditors.GroupControl grpUserDeviceValue;
        private DevExpress.XtraGrid.GridControl grdUserAll;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserAll;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colUserType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserValue;
        private DevExpress.XtraGrid.Columns.GridColumn colUserUpCount;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastTime;
        private DevExpress.XtraGrid.Columns.GridColumn colShowWord;
        private DevExpress.XtraTab.XtraTabPage tpErrorNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private UCErrorView ucErrorView;
        private DevExpress.XtraBars.BarButtonItem btnProcessSetting;
        private DevExpress.XtraEditors.GroupControl grpRobotCycleTime;
        private UCRobotCycle ucRobotCycle;
        private DevExpress.XtraEditors.SimpleButton btnCurrentValue;
        private DevExpress.XtraBars.BarButtonItem btnRobotCycleView;
        private DevExpress.XtraBars.BarButtonItem btnUserDeviceView;
        private UCStatusView ucStatusView;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuReport;
        private DevExpress.XtraEditors.SimpleButton btnMain;
        private DevExpress.XtraEditors.SimpleButton btnErrorDetail;
        private System.Windows.Forms.Timer tmrSystemLog;
        private DevExpress.XtraBars.BarButtonItem btnExportPDF;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.PopupMenu popupMenu3;
        private DevExpress.XtraBars.PopupMenu popupMenu4;
        private DevExpress.XtraBars.PopupMenu popupMenu5;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.Timer tmrSPDStatusCheck;
        private System.Windows.Forms.Timer tmrLoadFirst;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraBars.PopupMenu popupMenu6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnExitHMI;
        private DevExpress.XtraEditors.SimpleButton btnErrorReport;
        private DevExpress.XtraEditors.GroupControl grpProcessFlowChart;
        private DevExpress.XtraTab.XtraTabControl tabFlow;
        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraTab.XtraTabControl tabMainError;
        private DevExpress.XtraTab.XtraTabPage tpErrorList;
        private DevExpress.XtraTab.XtraTabPage tpAnalysis;
        private System.Windows.Forms.Panel pnlView;
        private UCErrorListPanelS ucErrorListPanelS;
    }
}