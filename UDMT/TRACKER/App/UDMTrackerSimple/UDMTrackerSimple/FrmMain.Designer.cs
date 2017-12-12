namespace UDMTrackerSimple
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exShowWord = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.exAppMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.chkShowSysLog = new DevExpress.XtraBars.BarCheckItem();
            this.chkShowMonitorStatus = new DevExpress.XtraBars.BarCheckItem();
            this.chkMainTabHeader = new DevExpress.XtraBars.BarCheckItem();
            this.toggMainEditorMode = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.toggAdministratorMode = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.imgListRibbon = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.exRibbonGallery = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnUpdatePatternItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnMakeMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.exMasterPatternMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnGenerateAllMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.cboGenerateSelectedMasterPattern = new DevExpress.XtraBars.BarEditItem();
            this.exEditorProcess = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnEditMasterPattern = new DevExpress.XtraBars.BarButtonItem();
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
            this.chkLearningMode = new DevExpress.XtraBars.BarCheckItem();
            this.chkErrorDetectMode = new DevExpress.XtraBars.BarCheckItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnViewProcessTimeChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewStatisticsTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewSymbolLog2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewCycleLog2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewLogicDiagram2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewProcessTimeChart2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewStatisticsTable2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcessSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnRobotCycleView = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserDeviceView = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewNewCycleLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnLSOPCServerOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnLSLogicExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnDBBackup = new DevExpress.XtraBars.BarButtonItem();
            this.btnDBOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnDBPath = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDBPath = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnDBBackupPath = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDBBackupPath = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.chkPlcBaseView = new DevExpress.XtraBars.BarCheckItem();
            this.chkProjectBaseView = new DevExpress.XtraBars.BarCheckItem();
            this.btnScreenViewApply = new DevExpress.XtraBars.BarButtonItem();
            this.chkMysqlDB = new DevExpress.XtraBars.BarCheckItem();
            this.chkMariaDB = new DevExpress.XtraBars.BarCheckItem();
            this.btnMoveTopScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveBottomScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnLayoutSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnLayoutLoad = new DevExpress.XtraBars.BarButtonItem();
            this.btnLayoutReset = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdateErrorDB = new DevExpress.XtraBars.BarButtonItem();
            this.btnCollectOptimization = new DevExpress.XtraBars.BarButtonItem();
            this.chkOptimizationMode = new DevExpress.XtraBars.BarCheckItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.pgHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuHomeFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorMode = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuOpti = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomeSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgDatabase = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuLSConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuStatistics = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuTool = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuMonitorExportLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgScreenView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuScreenView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuViewType = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.ucSystemLogTable = new UDMTrackerSimple.UCSystemLogTable();
            this.mnuImportExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exValueProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.imgSubMenu = new DevExpress.Utils.ImageCollection(this.components);
            this.btnMonitorStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnMonitorStart = new DevExpress.XtraEditors.SimpleButton();
            this.pnlMainTabBtn = new System.Windows.Forms.Panel();
            this.btnRTLadderView = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnCurrentValue = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnErrorLogList = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnErrorDetail = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCycle = new System.Windows.Forms.Panel();
            this.btnCycle = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSummary = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShowLogView = new DevExpress.XtraEditors.DropDownButton();
            this.exLogViewItem = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnOption = new DevExpress.XtraEditors.DropDownButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnExitHMI = new DevExpress.XtraEditors.SimpleButton();
            this.btnMain = new DevExpress.XtraEditors.SimpleButton();
            this.tmrSystemLog = new System.Windows.Forms.Timer(this.components);
            this.popupMenu3 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu4 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu5 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tmrSPDStatusCheck = new System.Windows.Forms.Timer(this.components);
            this.tmrLoadFirst = new System.Windows.Forms.Timer(this.components);
            this.popupMenu6 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.popupMenu7 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenu8 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tmrLoadSecond = new System.Windows.Forms.Timer(this.components);
            this.tmrNewRecipe = new System.Windows.Forms.Timer(this.components);
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.docSummary = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docFlowChart = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docCycle = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docError = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docErrorLogTable = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.docSymbolValue = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBBackupPath)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docFlowChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErrorLogTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSymbolValue)).BeginInit();
            this.SuspendLayout();
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
            // exRibbon
            // 
            this.exRibbon.ApplicationButtonDropDownControl = this.exAppMenu;
            this.exRibbon.AutoHideEmptyItems = true;
            this.exRibbon.ExpandCollapseItem.Id = 0;
            this.exRibbon.Font = new System.Drawing.Font("Tahoma", 9F);
            this.exRibbon.Images = this.imgListRibbon;
            this.exRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbon.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnExit,
            this.exRibbonGallery,
            this.btnUpdatePatternItem,
            this.btnMakeMasterPattern,
            this.btnEditMasterPattern,
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
            this.chkLearningMode,
            this.chkErrorDetectMode,
            this.lblStatus,
            this.btnViewProcessTimeChart,
            this.btnViewStatisticsTable,
            this.btnProjectSet,
            this.chkShowSysLog,
            this.chkShowMonitorStatus,
            this.toggMainEditorMode,
            this.chkMainTabHeader,
            this.btnViewSymbolLog2,
            this.btnViewCycleLog2,
            this.btnViewLogicDiagram2,
            this.btnViewProcessTimeChart2,
            this.btnViewStatisticsTable2,
            this.btnProcessSetting,
            this.btnRobotCycleView,
            this.btnUserDeviceView,
            this.btnReport,
            this.btnExportPDF,
            this.btnViewNewCycleLog,
            this.btnGenerateAllMasterPattern,
            this.cboGenerateSelectedMasterPattern,
            this.btnLSOPCServerOpen,
            this.btnLSLogicExport,
            this.btnDBBackup,
            this.btnDBOpen,
            this.btnDBPath,
            this.btnDBBackupPath,
            this.btnRefresh,
            this.chkPlcBaseView,
            this.chkProjectBaseView,
            this.btnScreenViewApply,
            this.toggAdministratorMode,
            this.chkMysqlDB,
            this.chkMariaDB,
            this.btnMoveTopScreen,
            this.btnMoveBottomScreen,
            this.btnLayoutSave,
            this.btnLayoutLoad,
            this.btnLayoutReset,
            this.btnUpdateErrorDB,
            this.btnCollectOptimization,
            this.chkOptimizationMode});
            this.exRibbon.LargeImages = this.imgListRibbonLarge;
            this.exRibbon.Location = new System.Drawing.Point(0, 0);
            this.exRibbon.MaxItemId = 20;
            this.exRibbon.Name = "exRibbon";
            this.exRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHome,
            this.pgDatabase,
            this.pgView,
            this.mnuTool,
            this.pgScreenView});
            this.exRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorExportFrom,
            this.exEditorExportTo,
            this.exEditorUseOPC,
            this.exEditorUseDDEA,
            this.rcmbOPCServer,
            this.exEditorAddressFilter,
            this.exEditorDescriptionFilter,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.exEditorProcess,
            this.exEditorDBPath,
            this.exEditorDBBackupPath});
            this.exRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exRibbon.ShowCategoryInCaption = false;
            this.exRibbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.exRibbon.Size = new System.Drawing.Size(1415, 147);
            this.exRibbon.StatusBar = this.exRibbonStatusBar;
            this.exRibbon.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbon.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbon.Toolbar.ItemLinks.Add(this.btnSave);
            this.exRibbon.Toolbar.ItemLinks.Add(this.btnSaveAs);
            this.exRibbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // exAppMenu
            // 
            this.exAppMenu.ItemLinks.Add(this.btnRefresh);
            this.exAppMenu.ItemLinks.Add(this.chkShowSysLog);
            this.exAppMenu.ItemLinks.Add(this.chkShowMonitorStatus);
            this.exAppMenu.ItemLinks.Add(this.chkMainTabHeader);
            this.exAppMenu.ItemLinks.Add(this.toggMainEditorMode);
            this.exAppMenu.ItemLinks.Add(this.toggAdministratorMode);
            this.exAppMenu.Name = "exAppMenu";
            this.exAppMenu.Ribbon = this.exRibbon;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Monitor Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 1;
            this.btnRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
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
            this.chkShowMonitorStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.chkMainTabHeader.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // toggAdministratorMode
            // 
            this.toggAdministratorMode.BindableChecked = true;
            this.toggAdministratorMode.Caption = "AdministratorMode";
            this.toggAdministratorMode.Checked = true;
            this.toggAdministratorMode.Glyph = ((System.Drawing.Image)(resources.GetObject("toggAdministratorMode.Glyph")));
            this.toggAdministratorMode.Id = 5;
            this.toggAdministratorMode.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggAdministratorMode.ItemAppearance.Normal.Options.UseFont = true;
            this.toggAdministratorMode.Name = "toggAdministratorMode";
            this.toggAdministratorMode.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.toggAdministratorMode_CheckedChanged);
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
            // btnMakeMasterPattern
            // 
            this.btnMakeMasterPattern.ActAsDropDown = true;
            this.btnMakeMasterPattern.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnMakeMasterPattern.Caption = "마스터 패턴\r\n생성";
            this.btnMakeMasterPattern.DropDownControl = this.exMasterPatternMenu;
            this.btnMakeMasterPattern.Id = 19;
            this.btnMakeMasterPattern.LargeImageIndex = 25;
            this.btnMakeMasterPattern.Name = "btnMakeMasterPattern";
            this.btnMakeMasterPattern.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnMakeMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateMasterPattern_ItemClick);
            // 
            // exMasterPatternMenu
            // 
            this.exMasterPatternMenu.ItemLinks.Add(this.btnGenerateAllMasterPattern);
            this.exMasterPatternMenu.ItemLinks.Add(this.cboGenerateSelectedMasterPattern);
            this.exMasterPatternMenu.Name = "exMasterPatternMenu";
            this.exMasterPatternMenu.Ribbon = this.exRibbon;
            // 
            // btnGenerateAllMasterPattern
            // 
            this.btnGenerateAllMasterPattern.Caption = "모든 공정 마스터 패턴 생성";
            this.btnGenerateAllMasterPattern.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateAllMasterPattern.Glyph")));
            this.btnGenerateAllMasterPattern.Id = 2;
            this.btnGenerateAllMasterPattern.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGenerateAllMasterPattern.LargeGlyph")));
            this.btnGenerateAllMasterPattern.Name = "btnGenerateAllMasterPattern";
            this.btnGenerateAllMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerateAllMasterPattern_ItemClick);
            // 
            // cboGenerateSelectedMasterPattern
            // 
            this.cboGenerateSelectedMasterPattern.Caption = "선택 공정 마스터 패턴 생성";
            this.cboGenerateSelectedMasterPattern.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.cboGenerateSelectedMasterPattern.Edit = this.exEditorProcess;
            this.cboGenerateSelectedMasterPattern.EditWidth = 100;
            this.cboGenerateSelectedMasterPattern.Id = 4;
            this.cboGenerateSelectedMasterPattern.Name = "cboGenerateSelectedMasterPattern";
            this.cboGenerateSelectedMasterPattern.EditValueChanged += new System.EventHandler(this.cboGenerateSelectedMasterPattern_EditValueChanged);
            this.cboGenerateSelectedMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cboGenerateSelectedMasterPattern_ItemClick);
            // 
            // exEditorProcess
            // 
            this.exEditorProcess.AutoHeight = false;
            this.exEditorProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorProcess.Name = "exEditorProcess";
            this.exEditorProcess.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnEditMasterPattern
            // 
            this.btnEditMasterPattern.Caption = "마스터 패턴\r\n보기";
            this.btnEditMasterPattern.Id = 20;
            this.btnEditMasterPattern.LargeImageIndex = 31;
            this.btnEditMasterPattern.Name = "btnEditMasterPattern";
            this.btnEditMasterPattern.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEditMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditMasterPattern_ItemClick);
            // 
            // btnCreateDataBase
            // 
            this.btnCreateDataBase.Caption = "Create DB";
            this.btnCreateDataBase.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCreateDataBase.Glyph")));
            this.btnCreateDataBase.Id = 21;
            this.btnCreateDataBase.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCreateDataBase.LargeGlyph")));
            this.btnCreateDataBase.LargeImageIndex = 13;
            this.btnCreateDataBase.Name = "btnCreateDataBase";
            this.btnCreateDataBase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateDataBase_ItemClick);
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Caption = "DB\r\nConnet Check";
            this.btnTestDBConnection.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTestDBConnection.Glyph")));
            this.btnTestDBConnection.Id = 22;
            this.btnTestDBConnection.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTestDBConnection.LargeGlyph")));
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
            this.dtpkExportFrom.EditWidth = 120;
            this.dtpkExportFrom.Id = 24;
            this.dtpkExportFrom.Name = "dtpkExportFrom";
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
            this.dtpkExportTo.EditWidth = 120;
            this.dtpkExportTo.Id = 25;
            this.dtpkExportTo.Name = "dtpkExportTo";
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
            this.lblMonitorCountLabel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // lblMonitorCount
            // 
            this.lblMonitorCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblMonitorCount.Caption = "0";
            this.lblMonitorCount.Id = 33;
            this.lblMonitorCount.Name = "lblMonitorCount";
            this.lblMonitorCount.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lblMonitorCount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // chkLearningMode
            // 
            this.chkLearningMode.BindableChecked = true;
            this.chkLearningMode.Caption = "Study Mode";
            this.chkLearningMode.Checked = true;
            this.chkLearningMode.Glyph = ((System.Drawing.Image)(resources.GetObject("chkLearningMode.Glyph")));
            this.chkLearningMode.GroupIndex = 2;
            this.chkLearningMode.Id = 89;
            this.chkLearningMode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkLearningMode.LargeGlyph")));
            this.chkLearningMode.Name = "chkLearningMode";
            this.chkLearningMode.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonitorPatternItem_CheckedChanged);
            // 
            // chkErrorDetectMode
            // 
            this.chkErrorDetectMode.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.chkErrorDetectMode.Caption = "Detection Mode";
            this.chkErrorDetectMode.Glyph = ((System.Drawing.Image)(resources.GetObject("chkErrorDetectMode.Glyph")));
            this.chkErrorDetectMode.GroupIndex = 2;
            this.chkErrorDetectMode.Id = 90;
            this.chkErrorDetectMode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkErrorDetectMode.LargeGlyph")));
            this.chkErrorDetectMode.Name = "chkErrorDetectMode";
            this.chkErrorDetectMode.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMonitorMasterPattern_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 92;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            this.lblStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // btnViewCycleLog2
            // 
            this.btnViewCycleLog2.Caption = "View Cycle Chart";
            this.btnViewCycleLog2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewCycleLog2.Id = 6;
            this.btnViewCycleLog2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnViewCycleLog2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewCycleLog2.LargeImageIndex = 27;
            this.btnViewCycleLog2.Name = "btnViewCycleLog2";
            this.btnViewCycleLog2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewCycleLog2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewCycleLog_ItemClick);
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
            // btnViewProcessTimeChart2
            // 
            this.btnViewProcessTimeChart2.Caption = "View Process Time Chart";
            this.btnViewProcessTimeChart2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewProcessTimeChart2.Id = 8;
            this.btnViewProcessTimeChart2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnViewProcessTimeChart2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewProcessTimeChart2.LargeImageIndex = 33;
            this.btnViewProcessTimeChart2.Name = "btnViewProcessTimeChart2";
            this.btnViewProcessTimeChart2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewProcessTimeChart2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewProcessTimeChart_ItemClick);
            // 
            // btnViewStatisticsTable2
            // 
            this.btnViewStatisticsTable2.Caption = "View Statistics";
            this.btnViewStatisticsTable2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewStatisticsTable2.Id = 9;
            this.btnViewStatisticsTable2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnViewStatisticsTable2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewStatisticsTable2.LargeImageIndex = 34;
            this.btnViewStatisticsTable2.Name = "btnViewStatisticsTable2";
            this.btnViewStatisticsTable2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnViewStatisticsTable2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewStatisticsTable_ItemClick);
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
            this.btnRobotCycleView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // btnViewNewCycleLog
            // 
            this.btnViewNewCycleLog.Caption = "View New Cycle Chart";
            this.btnViewNewCycleLog.Id = 1;
            this.btnViewNewCycleLog.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewNewCycleLog.ItemAppearance.Normal.Options.UseFont = true;
            this.btnViewNewCycleLog.LargeImageIndex = 27;
            this.btnViewNewCycleLog.Name = "btnViewNewCycleLog";
            this.btnViewNewCycleLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewNewCycleLog_ItemClick);
            // 
            // btnLSOPCServerOpen
            // 
            this.btnLSOPCServerOpen.Caption = "LS PLC OPC Server Open";
            this.btnLSOPCServerOpen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLSOPCServerOpen.Id = 5;
            this.btnLSOPCServerOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLSOPCServerOpen.LargeGlyph")));
            this.btnLSOPCServerOpen.Name = "btnLSOPCServerOpen";
            this.btnLSOPCServerOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLSOPCServerOpen_ItemClick);
            // 
            // btnLSLogicExport
            // 
            this.btnLSLogicExport.Caption = "LS PLC \r\nLogic Export";
            this.btnLSLogicExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLSLogicExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLSLogicExport.Glyph")));
            this.btnLSLogicExport.Id = 6;
            this.btnLSLogicExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLSLogicExport.LargeGlyph")));
            this.btnLSLogicExport.Name = "btnLSLogicExport";
            this.btnLSLogicExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLSLogicExport_ItemClick);
            // 
            // btnDBBackup
            // 
            this.btnDBBackup.Caption = "Backup DB";
            this.btnDBBackup.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDBBackup.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDBBackup.Glyph")));
            this.btnDBBackup.Id = 7;
            this.btnDBBackup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDBBackup.LargeGlyph")));
            this.btnDBBackup.Name = "btnDBBackup";
            this.btnDBBackup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBBackup_ItemClick);
            // 
            // btnDBOpen
            // 
            this.btnDBOpen.Caption = "Open \r\nBackup DB";
            this.btnDBOpen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDBOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDBOpen.Glyph")));
            this.btnDBOpen.Id = 8;
            this.btnDBOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDBOpen.LargeGlyph")));
            this.btnDBOpen.Name = "btnDBOpen";
            this.btnDBOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBOpen_ItemClick);
            // 
            // btnDBPath
            // 
            this.btnDBPath.Caption = "DB Path            ";
            this.btnDBPath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDBPath.Edit = this.exEditorDBPath;
            this.btnDBPath.EditWidth = 200;
            this.btnDBPath.Id = 9;
            this.btnDBPath.Name = "btnDBPath";
            this.btnDBPath.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDBPath.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBPath_ItemPress);
            // 
            // exEditorDBPath
            // 
            this.exEditorDBPath.AutoHeight = false;
            this.exEditorDBPath.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorDBPath.Name = "exEditorDBPath";
            // 
            // btnDBBackupPath
            // 
            this.btnDBBackupPath.Caption = "DB Backup Path ";
            this.btnDBBackupPath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDBBackupPath.Edit = this.exEditorDBBackupPath;
            this.btnDBBackupPath.EditWidth = 200;
            this.btnDBBackupPath.Id = 10;
            this.btnDBBackupPath.Name = "btnDBBackupPath";
            this.btnDBBackupPath.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDBBackupPath.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBBackupPath_ItemPress);
            // 
            // exEditorDBBackupPath
            // 
            this.exEditorDBBackupPath.AutoHeight = false;
            this.exEditorDBBackupPath.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorDBBackupPath.Name = "exEditorDBBackupPath";
            // 
            // chkPlcBaseView
            // 
            this.chkPlcBaseView.BindableChecked = true;
            this.chkPlcBaseView.Caption = "PLC Base View";
            this.chkPlcBaseView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkPlcBaseView.Checked = true;
            this.chkPlcBaseView.Id = 2;
            this.chkPlcBaseView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkPlcBaseView.LargeGlyph")));
            this.chkPlcBaseView.Name = "chkPlcBaseView";
            this.chkPlcBaseView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkPlcBaseView_CheckedChanged);
            // 
            // chkProjectBaseView
            // 
            this.chkProjectBaseView.Caption = "Project Base View";
            this.chkProjectBaseView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkProjectBaseView.Id = 3;
            this.chkProjectBaseView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkProjectBaseView.LargeGlyph")));
            this.chkProjectBaseView.Name = "chkProjectBaseView";
            this.chkProjectBaseView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkProjectBaseView_CheckedChanged);
            // 
            // btnScreenViewApply
            // 
            this.btnScreenViewApply.Caption = "View Apply";
            this.btnScreenViewApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnScreenViewApply.Glyph = ((System.Drawing.Image)(resources.GetObject("btnScreenViewApply.Glyph")));
            this.btnScreenViewApply.Id = 4;
            this.btnScreenViewApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnScreenViewApply.LargeGlyph")));
            this.btnScreenViewApply.Name = "btnScreenViewApply";
            this.btnScreenViewApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnScreenViewApply_ItemClick);
            // 
            // chkMysqlDB
            // 
            this.chkMysqlDB.Caption = "MYSQL DB";
            this.chkMysqlDB.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkMysqlDB.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.chkMysqlDB.Id = 6;
            this.chkMysqlDB.Name = "chkMysqlDB";
            this.chkMysqlDB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.chkMysqlDB.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMysqlDB_CheckedChanged);
            // 
            // chkMariaDB
            // 
            this.chkMariaDB.Caption = "Maria DB";
            this.chkMariaDB.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkMariaDB.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.chkMariaDB.Id = 7;
            this.chkMariaDB.Name = "chkMariaDB";
            this.chkMariaDB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.chkMariaDB.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkMariaDB_CheckedChanged);
            // 
            // btnMoveTopScreen
            // 
            this.btnMoveTopScreen.Caption = "Move Top";
            this.btnMoveTopScreen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMoveTopScreen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMoveTopScreen.Glyph")));
            this.btnMoveTopScreen.Id = 8;
            this.btnMoveTopScreen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMoveTopScreen.LargeGlyph")));
            this.btnMoveTopScreen.Name = "btnMoveTopScreen";
            this.btnMoveTopScreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveTopScreen_ItemClick);
            // 
            // btnMoveBottomScreen
            // 
            this.btnMoveBottomScreen.Caption = "Move Bottom";
            this.btnMoveBottomScreen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMoveBottomScreen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMoveBottomScreen.Glyph")));
            this.btnMoveBottomScreen.Id = 9;
            this.btnMoveBottomScreen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMoveBottomScreen.LargeGlyph")));
            this.btnMoveBottomScreen.Name = "btnMoveBottomScreen";
            this.btnMoveBottomScreen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoveBottomScreen_ItemClick);
            // 
            // btnLayoutSave
            // 
            this.btnLayoutSave.Caption = "Layout Save";
            this.btnLayoutSave.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLayoutSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutSave.Glyph")));
            this.btnLayoutSave.Id = 12;
            this.btnLayoutSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutSave.LargeGlyph")));
            this.btnLayoutSave.Name = "btnLayoutSave";
            this.btnLayoutSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLayoutSave_ItemClick);
            // 
            // btnLayoutLoad
            // 
            this.btnLayoutLoad.Caption = "Layout Load";
            this.btnLayoutLoad.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLayoutLoad.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutLoad.Glyph")));
            this.btnLayoutLoad.Id = 13;
            this.btnLayoutLoad.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutLoad.LargeGlyph")));
            this.btnLayoutLoad.Name = "btnLayoutLoad";
            this.btnLayoutLoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLayoutLoad_ItemClick);
            // 
            // btnLayoutReset
            // 
            this.btnLayoutReset.Caption = "Layout Reset";
            this.btnLayoutReset.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLayoutReset.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutReset.Glyph")));
            this.btnLayoutReset.Id = 14;
            this.btnLayoutReset.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLayoutReset.LargeGlyph")));
            this.btnLayoutReset.Name = "btnLayoutReset";
            this.btnLayoutReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLayoutReset_ItemClick);
            // 
            // btnUpdateErrorDB
            // 
            this.btnUpdateErrorDB.Caption = "Update Error DB";
            this.btnUpdateErrorDB.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnUpdateErrorDB.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUpdateErrorDB.Glyph")));
            this.btnUpdateErrorDB.Id = 15;
            this.btnUpdateErrorDB.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUpdateErrorDB.LargeGlyph")));
            this.btnUpdateErrorDB.Name = "btnUpdateErrorDB";
            this.btnUpdateErrorDB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateErrorDB_ItemClick);
            // 
            // btnCollectOptimization
            // 
            this.btnCollectOptimization.Caption = "Collect Optimizer";
            this.btnCollectOptimization.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCollectOptimization.Glyph")));
            this.btnCollectOptimization.Id = 16;
            this.btnCollectOptimization.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCollectOptimization.LargeGlyph")));
            this.btnCollectOptimization.Name = "btnCollectOptimization";
            toolTipTitleItem1.Text = "수집할 태그에 대한 수집 최적화 작업을 진행합니다.";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "각 공정별 CANDIDATE KEY를 대상으로 일정 사이클을 수집하여 주기적/상시적으로 동작하는 접점을 설정된 내용을 기반으로 자동 분류합니다.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCollectOptimization.SuperTip = superToolTip1;
            this.btnCollectOptimization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCollectOptimization_ItemClick);
            // 
            // chkOptimizationMode
            // 
            this.chkOptimizationMode.Caption = "Collect Optimizer";
            this.chkOptimizationMode.Glyph = ((System.Drawing.Image)(resources.GetObject("chkOptimizationMode.Glyph")));
            this.chkOptimizationMode.Id = 19;
            this.chkOptimizationMode.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkOptimizationMode.LargeGlyph")));
            this.chkOptimizationMode.Name = "chkOptimizationMode";
            this.chkOptimizationMode.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkOptimizationMode_CheckedChanged);
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
            this.mnuOpti,
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
            this.mnuHomeFile.Text = "Project";
            // 
            // mnuMonitorMode
            // 
            this.mnuMonitorMode.ItemLinks.Add(this.chkLearningMode);
            this.mnuMonitorMode.ItemLinks.Add(this.chkErrorDetectMode);
            this.mnuMonitorMode.Name = "mnuMonitorMode";
            this.mnuMonitorMode.Text = "Mode Select";
            // 
            // mnuOpti
            // 
            this.mnuOpti.ItemLinks.Add(this.btnCollectOptimization);
            this.mnuOpti.Name = "mnuOpti";
            this.mnuOpti.Text = "Collection";
            // 
            // mnuModel
            // 
            this.mnuModel.ItemLinks.Add(this.btnProjectSet);
            this.mnuModel.Name = "mnuModel";
            this.mnuModel.Text = "Setting";
            // 
            // mnuHomeSkin
            // 
            this.mnuHomeSkin.ItemLinks.Add(this.exRibbonGallery);
            this.mnuHomeSkin.Name = "mnuHomeSkin";
            this.mnuHomeSkin.Text = "Skin";
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
            this.mnuDatabase,
            this.mnuLSConfig});
            this.pgDatabase.Name = "pgDatabase";
            this.pgDatabase.Text = "Data Base";
            // 
            // mnuDatabase
            // 
            this.mnuDatabase.ItemLinks.Add(this.chkMysqlDB);
            this.mnuDatabase.ItemLinks.Add(this.chkMariaDB);
            this.mnuDatabase.ItemLinks.Add(this.btnDBPath);
            this.mnuDatabase.ItemLinks.Add(this.btnDBBackupPath);
            this.mnuDatabase.ItemLinks.Add(this.btnCreateDataBase, true);
            this.mnuDatabase.ItemLinks.Add(this.btnDBBackup);
            this.mnuDatabase.ItemLinks.Add(this.btnDBOpen);
            this.mnuDatabase.ItemLinks.Add(this.btnTestDBConnection);
            this.mnuDatabase.ItemLinks.Add(this.btnUpdateErrorDB);
            this.mnuDatabase.Name = "mnuDatabase";
            this.mnuDatabase.Text = "DataBase";
            // 
            // mnuLSConfig
            // 
            this.mnuLSConfig.ItemLinks.Add(this.btnLSOPCServerOpen);
            this.mnuLSConfig.ItemLinks.Add(this.btnLSLogicExport);
            this.mnuLSConfig.Name = "mnuLSConfig";
            this.mnuLSConfig.Text = "LS산전 통신/로직 설정";
            this.mnuLSConfig.Visible = false;
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
            // pgScreenView
            // 
            this.pgScreenView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuScreenView,
            this.mnuViewType});
            this.pgScreenView.Name = "pgScreenView";
            this.pgScreenView.Text = "View";
            // 
            // mnuScreenView
            // 
            this.mnuScreenView.ItemLinks.Add(this.btnMoveTopScreen);
            this.mnuScreenView.ItemLinks.Add(this.btnMoveBottomScreen);
            this.mnuScreenView.ItemLinks.Add(this.btnLayoutReset);
            this.mnuScreenView.ItemLinks.Add(this.btnLayoutSave);
            this.mnuScreenView.ItemLinks.Add(this.btnLayoutLoad);
            this.mnuScreenView.Name = "mnuScreenView";
            this.mnuScreenView.Text = "Screen";
            // 
            // mnuViewType
            // 
            this.mnuViewType.ItemLinks.Add(this.chkPlcBaseView);
            this.mnuViewType.ItemLinks.Add(this.chkProjectBaseView);
            this.mnuViewType.ItemLinks.Add(this.btnScreenViewApply);
            this.mnuViewType.Name = "mnuViewType";
            this.mnuViewType.Text = "View Type";
            this.mnuViewType.Visible = false;
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
            this.exRibbonStatusBar.Location = new System.Drawing.Point(0, 769);
            this.exRibbonStatusBar.Name = "exRibbonStatusBar";
            this.exRibbonStatusBar.Ribbon = this.exRibbon;
            this.exRibbonStatusBar.Size = new System.Drawing.Size(1415, 27);
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
            this.btnMonitorStop.Location = new System.Drawing.Point(1205, 0);
            this.btnMonitorStop.Name = "btnMonitorStop";
            this.btnMonitorStop.Size = new System.Drawing.Size(105, 58);
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
            this.btnMonitorStart.Location = new System.Drawing.Point(1100, 0);
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.Size = new System.Drawing.Size(105, 58);
            this.btnMonitorStart.TabIndex = 34;
            this.btnMonitorStart.Click += new System.EventHandler(this.btnMonitorStart_Click);
            // 
            // pnlMainTabBtn
            // 
            this.pnlMainTabBtn.BackColor = System.Drawing.Color.White;
            this.pnlMainTabBtn.Controls.Add(this.btnRTLadderView);
            this.pnlMainTabBtn.Controls.Add(this.panel9);
            this.pnlMainTabBtn.Controls.Add(this.btnCurrentValue);
            this.pnlMainTabBtn.Controls.Add(this.panel8);
            this.pnlMainTabBtn.Controls.Add(this.btnErrorLogList);
            this.pnlMainTabBtn.Controls.Add(this.panel7);
            this.pnlMainTabBtn.Controls.Add(this.btnErrorDetail);
            this.pnlMainTabBtn.Controls.Add(this.pnlCycle);
            this.pnlMainTabBtn.Controls.Add(this.btnCycle);
            this.pnlMainTabBtn.Controls.Add(this.panel4);
            this.pnlMainTabBtn.Controls.Add(this.btnSummary);
            this.pnlMainTabBtn.Controls.Add(this.panel3);
            this.pnlMainTabBtn.Controls.Add(this.btnShowLogView);
            this.pnlMainTabBtn.Controls.Add(this.btnOption);
            this.pnlMainTabBtn.Controls.Add(this.panel2);
            this.pnlMainTabBtn.Controls.Add(this.btnMonitorStart);
            this.pnlMainTabBtn.Controls.Add(this.btnMonitorStop);
            this.pnlMainTabBtn.Controls.Add(this.panel6);
            this.pnlMainTabBtn.Controls.Add(this.btnExitHMI);
            this.pnlMainTabBtn.Controls.Add(this.btnMain);
            this.pnlMainTabBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTabBtn.Location = new System.Drawing.Point(0, 147);
            this.pnlMainTabBtn.Name = "pnlMainTabBtn";
            this.pnlMainTabBtn.Size = new System.Drawing.Size(1415, 58);
            this.pnlMainTabBtn.TabIndex = 19;
            // 
            // btnRTLadderView
            // 
            this.btnRTLadderView.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRTLadderView.Appearance.Options.UseFont = true;
            this.btnRTLadderView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRTLadderView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRTLadderView.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRTLadderView.Location = new System.Drawing.Point(630, 0);
            this.btnRTLadderView.Name = "btnRTLadderView";
            this.btnRTLadderView.Size = new System.Drawing.Size(100, 58);
            this.btnRTLadderView.TabIndex = 49;
            this.btnRTLadderView.Text = "Real Time\r\nLadder";
            this.btnRTLadderView.Visible = false;
            this.btnRTLadderView.Click += new System.EventHandler(this.btnRTLadderView_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(625, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 58);
            this.panel9.TabIndex = 55;
            // 
            // btnCurrentValue
            // 
            this.btnCurrentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrentValue.Appearance.Options.UseFont = true;
            this.btnCurrentValue.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCurrentValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCurrentValue.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCurrentValue.Location = new System.Drawing.Point(525, 0);
            this.btnCurrentValue.Name = "btnCurrentValue";
            this.btnCurrentValue.Size = new System.Drawing.Size(100, 58);
            this.btnCurrentValue.TabIndex = 43;
            this.btnCurrentValue.Text = "User\r\nDevice";
            this.btnCurrentValue.Click += new System.EventHandler(this.btnCurrentValue_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(520, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 58);
            this.panel8.TabIndex = 54;
            // 
            // btnErrorLogList
            // 
            this.btnErrorLogList.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorLogList.Appearance.Options.UseFont = true;
            this.btnErrorLogList.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnErrorLogList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnErrorLogList.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnErrorLogList.Location = new System.Drawing.Point(420, 0);
            this.btnErrorLogList.Name = "btnErrorLogList";
            this.btnErrorLogList.Size = new System.Drawing.Size(100, 58);
            this.btnErrorLogList.TabIndex = 14;
            this.btnErrorLogList.Text = "Error\r\nStatistic";
            this.btnErrorLogList.Click += new System.EventHandler(this.btnErrorLogList_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(415, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 58);
            this.panel7.TabIndex = 53;
            // 
            // btnErrorDetail
            // 
            this.btnErrorDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorDetail.Appearance.Options.UseFont = true;
            this.btnErrorDetail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnErrorDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnErrorDetail.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnErrorDetail.Location = new System.Drawing.Point(315, 0);
            this.btnErrorDetail.Name = "btnErrorDetail";
            this.btnErrorDetail.Size = new System.Drawing.Size(100, 58);
            this.btnErrorDetail.TabIndex = 13;
            this.btnErrorDetail.Text = "Error\r\nDetail";
            this.btnErrorDetail.Click += new System.EventHandler(this.btnErrorDetail_Click);
            // 
            // pnlCycle
            // 
            this.pnlCycle.BackColor = System.Drawing.Color.White;
            this.pnlCycle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCycle.Location = new System.Drawing.Point(310, 0);
            this.pnlCycle.Name = "pnlCycle";
            this.pnlCycle.Size = new System.Drawing.Size(5, 58);
            this.pnlCycle.TabIndex = 52;
            // 
            // btnCycle
            // 
            this.btnCycle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycle.Appearance.Options.UseFont = true;
            this.btnCycle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCycle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCycle.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnCycle.Location = new System.Drawing.Point(210, 0);
            this.btnCycle.Name = "btnCycle";
            this.btnCycle.Size = new System.Drawing.Size(100, 58);
            this.btnCycle.TabIndex = 9;
            this.btnCycle.Text = "Cycle";
            this.btnCycle.Click += new System.EventHandler(this.btnCycle_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(205, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 58);
            this.panel4.TabIndex = 51;
            // 
            // btnSummary
            // 
            this.btnSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummary.Appearance.Options.UseFont = true;
            this.btnSummary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSummary.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSummary.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSummary.Location = new System.Drawing.Point(105, 0);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(100, 58);
            this.btnSummary.TabIndex = 48;
            this.btnSummary.Text = "Flow\r\nChart";
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(100, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 58);
            this.panel3.TabIndex = 50;
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
            this.btnShowLogView.Location = new System.Drawing.Point(870, 0);
            this.btnShowLogView.MenuManager = this.exRibbon;
            this.btnShowLogView.Name = "btnShowLogView";
            this.btnShowLogView.Size = new System.Drawing.Size(105, 58);
            this.btnShowLogView.TabIndex = 41;
            this.btnShowLogView.Text = "View";
            // 
            // exLogViewItem
            // 
            this.exLogViewItem.ItemLinks.Add(this.btnViewSymbolLog2);
            this.exLogViewItem.ItemLinks.Add(this.btnViewCycleLog2);
            this.exLogViewItem.ItemLinks.Add(this.btnViewNewCycleLog);
            this.exLogViewItem.ItemLinks.Add(this.btnViewLogicDiagram2);
            this.exLogViewItem.ItemLinks.Add(this.btnViewProcessTimeChart2);
            this.exLogViewItem.ItemLinks.Add(this.btnViewStatisticsTable2);
            this.exLogViewItem.ItemLinks.Add(this.btnRobotCycleView);
            this.exLogViewItem.ItemLinks.Add(this.btnUserDeviceView);
            this.exLogViewItem.ItemLinks.Add(this.btnExportPDF);
            this.exLogViewItem.Name = "exLogViewItem";
            this.exLogViewItem.Ribbon = this.exRibbon;
            // 
            // btnOption
            // 
            this.btnOption.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOption.Appearance.Options.UseFont = true;
            this.btnOption.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOption.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOption.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.btnOption.DropDownControl = this.exAppMenu;
            this.btnOption.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOption.Location = new System.Drawing.Point(975, 0);
            this.btnOption.MenuManager = this.exRibbon;
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(105, 58);
            this.btnOption.TabIndex = 38;
            this.btnOption.Text = "Option";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1080, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 58);
            this.panel2.TabIndex = 45;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1310, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(20, 58);
            this.panel6.TabIndex = 39;
            // 
            // btnExitHMI
            // 
            this.btnExitHMI.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitHMI.Appearance.Options.UseFont = true;
            this.btnExitHMI.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExitHMI.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExitHMI.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExitHMI.Location = new System.Drawing.Point(1330, 0);
            this.btnExitHMI.Name = "btnExitHMI";
            this.btnExitHMI.Size = new System.Drawing.Size(85, 58);
            this.btnExitHMI.TabIndex = 46;
            this.btnExitHMI.Text = "Exit";
            this.btnExitHMI.Click += new System.EventHandler(this.btnExitHMI_Click);
            // 
            // btnMain
            // 
            this.btnMain.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Appearance.Options.UseFont = true;
            this.btnMain.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMain.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(100, 58);
            this.btnMain.TabIndex = 47;
            this.btnMain.Text = "Summary";
            this.btnMain.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // tmrSystemLog
            // 
            this.tmrSystemLog.Interval = 3600000;
            this.tmrSystemLog.Tick += new System.EventHandler(this.tmrSystemLog_Tick);
            // 
            // popupMenu3
            // 
            this.popupMenu3.Name = "popupMenu3";
            this.popupMenu3.Ribbon = this.exRibbon;
            // 
            // popupMenu4
            // 
            this.popupMenu4.Name = "popupMenu4";
            this.popupMenu4.Ribbon = this.exRibbon;
            // 
            // popupMenu5
            // 
            this.popupMenu5.Name = "popupMenu5";
            this.popupMenu5.Ribbon = this.exRibbon;
            // 
            // tmrSPDStatusCheck
            // 
            this.tmrSPDStatusCheck.Interval = 10000;
            this.tmrSPDStatusCheck.Tick += new System.EventHandler(this.tmrSPDStatusCheck_Tick);
            // 
            // tmrLoadFirst
            // 
            this.tmrLoadFirst.Interval = 500;
            this.tmrLoadFirst.Tick += new System.EventHandler(this.tmrLoadFirst_Tick);
            // 
            // popupMenu6
            // 
            this.popupMenu6.Name = "popupMenu6";
            this.popupMenu6.Ribbon = this.exRibbon;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1415, 18);
            this.panel1.TabIndex = 37;
            // 
            // popupMenu7
            // 
            this.popupMenu7.Name = "popupMenu7";
            this.popupMenu7.Ribbon = this.exRibbon;
            // 
            // popupMenu8
            // 
            this.popupMenu8.Name = "popupMenu8";
            this.popupMenu8.Ribbon = this.exRibbon;
            // 
            // tmrLoadSecond
            // 
            this.tmrLoadSecond.Interval = 2000;
            this.tmrLoadSecond.Tick += new System.EventHandler(this.tmrLoadSecond_Tick);
            // 
            // tmrNewRecipe
            // 
            this.tmrNewRecipe.Interval = 10000;
            this.tmrNewRecipe.Tick += new System.EventHandler(this.tmrNewRecipe_Tick);
            // 
            // docManager
            // 
            this.docManager.ContainerControl = this;
            this.docManager.MenuManager = this.exRibbon;
            this.docManager.View = this.tabView;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabView});
            // 
            // tabView
            // 
            this.tabView.DocumentGroupProperties.ShowDocumentSelectorButton = false;
            this.tabView.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabView.DocumentProperties.AllowClose = false;
            this.tabView.DocumentProperties.AllowFloat = false;
            this.tabView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.tabView.DocumentProperties.ShowInDocumentSelector = false;
            this.tabView.DocumentProperties.ShowPinButton = false;
            this.tabView.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.docSummary,
            this.docFlowChart,
            this.docCycle,
            this.docError,
            this.docErrorLogTable,
            this.docSymbolValue});
            this.tabView.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tabView.PopupMenuShowing += new DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventHandler(this.tabView_PopupMenuShowing);
            this.tabView.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.tabView_QueryControl);
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.docSummary,
            this.docFlowChart,
            this.docCycle,
            this.docError,
            this.docErrorLogTable,
            this.docSymbolValue});
            // 
            // docSummary
            // 
            this.docSummary.Caption = "Summary";
            this.docSummary.ControlName = "";
            this.docSummary.ControlTypeName = "UCAllErrorAlarmView2";
            // 
            // docFlowChart
            // 
            this.docFlowChart.Caption = "FlowChart";
            this.docFlowChart.ControlName = "";
            this.docFlowChart.ControlTypeName = "UCFlowChart";
            // 
            // docCycle
            // 
            this.docCycle.Caption = "Cycle";
            this.docCycle.ControlName = "";
            this.docCycle.ControlTypeName = "UCPlcCycle";
            // 
            // docError
            // 
            this.docError.Caption = "Error Detail";
            this.docError.ControlName = "";
            this.docError.ControlTypeName = "UCErrorView";
            // 
            // docErrorLogTable
            // 
            this.docErrorLogTable.Caption = "Error Statistic";
            this.docErrorLogTable.ControlName = "";
            this.docErrorLogTable.ControlTypeName = "UCErrorLogTable";
            // 
            // docSymbolValue
            // 
            this.docSymbolValue.Caption = "User Device";
            this.docSymbolValue.ControlName = "";
            this.docSymbolValue.ControlTypeName = "UCSymbolValue";
            // 
            // FrmMain
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 796);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMainTabBtn);
            this.Controls.Add(this.exRibbonStatusBar);
            this.Controls.Add(this.exRibbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 500);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbon;
            this.StatusBar = this.exRibbonStatusBar;
            this.Text = "UDM Tracker (UDMTEK)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBBackupPath)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docFlowChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErrorLogTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSymbolValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbon;
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
        private DevExpress.XtraBars.BarButtonItem btnMakeMasterPattern;
        private DevExpress.XtraBars.BarButtonItem btnEditMasterPattern;
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
        private DevExpress.XtraBars.BarCheckItem chkLearningMode;
        private DevExpress.XtraBars.BarCheckItem chkErrorDetectMode;
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
        private DevExpress.XtraEditors.SimpleButton btnErrorLogList;
        private DevExpress.XtraEditors.SimpleButton btnCycle;
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
        private DevExpress.XtraBars.BarCheckItem chkMainTabHeader;
        private DevExpress.XtraEditors.DropDownButton btnShowLogView;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu exLogViewItem;
        private DevExpress.XtraBars.BarButtonItem btnViewSymbolLog2;
        private DevExpress.XtraBars.BarButtonItem btnViewCycleLog2;
        private DevExpress.XtraBars.BarButtonItem btnViewLogicDiagram2;
        private DevExpress.XtraBars.BarButtonItem btnViewProcessTimeChart2;
        private DevExpress.XtraBars.BarButtonItem btnViewStatisticsTable2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem btnProcessSetting;
        private DevExpress.XtraEditors.SimpleButton btnCurrentValue;
        private DevExpress.XtraBars.BarButtonItem btnRobotCycleView;
        private DevExpress.XtraBars.BarButtonItem btnUserDeviceView;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuReport;
        private DevExpress.XtraEditors.SimpleButton btnErrorDetail;
        private System.Windows.Forms.Timer tmrSystemLog;
        private DevExpress.XtraBars.BarButtonItem btnExportPDF;
        private DevExpress.XtraBars.PopupMenu exMasterPatternMenu;
        private DevExpress.XtraBars.PopupMenu popupMenu3;
        private DevExpress.XtraBars.PopupMenu popupMenu4;
        private DevExpress.XtraBars.PopupMenu popupMenu5;
        private System.Windows.Forms.Timer tmrSPDStatusCheck;
        private System.Windows.Forms.Timer tmrLoadFirst;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraBars.PopupMenu popupMenu6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnExitHMI;
        private DevExpress.XtraEditors.SimpleButton btnMain;
        private DevExpress.XtraEditors.SimpleButton btnSummary;
        private DevExpress.XtraBars.BarButtonItem btnViewNewCycleLog;
        private DevExpress.XtraBars.PopupMenu popupMenu7;
        private DevExpress.XtraBars.PopupMenu popupMenu8;
        private DevExpress.XtraBars.BarButtonItem btnGenerateAllMasterPattern;
        private DevExpress.XtraBars.BarEditItem cboGenerateSelectedMasterPattern;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorProcess;
        private DevExpress.XtraBars.BarButtonItem btnLSOPCServerOpen;
        private DevExpress.XtraBars.BarButtonItem btnLSLogicExport;
        private DevExpress.XtraBars.BarButtonItem btnDBBackup;
        private DevExpress.XtraBars.BarButtonItem btnDBOpen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuLSConfig;
        private DevExpress.XtraEditors.SimpleButton btnRTLadderView;
        private System.Windows.Forms.Timer tmrLoadSecond;
        private DevExpress.XtraBars.BarEditItem btnDBPath;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorDBPath;
        private DevExpress.XtraBars.BarEditItem btnDBBackupPath;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorDBBackupPath;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnlCycle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer tmrNewRecipe;
        private DevExpress.XtraBars.BarCheckItem chkPlcBaseView;
        private DevExpress.XtraBars.BarCheckItem chkProjectBaseView;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgScreenView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuScreenView;
        private DevExpress.XtraBars.BarButtonItem btnScreenViewApply;
        private DevExpress.XtraBars.BarToggleSwitchItem toggAdministratorMode;
        private DevExpress.XtraBars.BarCheckItem chkMysqlDB;
        private DevExpress.XtraBars.BarCheckItem chkMariaDB;
        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabView;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docSummary;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docFlowChart;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docCycle;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docError;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docErrorLogTable;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document docSymbolValue;
        private DevExpress.XtraBars.BarButtonItem btnMoveTopScreen;
        private DevExpress.XtraBars.BarButtonItem btnMoveBottomScreen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuViewType;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.BarButtonItem btnLayoutSave;
        private DevExpress.XtraBars.BarButtonItem btnLayoutLoad;
        private DevExpress.XtraBars.BarButtonItem btnLayoutReset;
        private DevExpress.XtraBars.BarButtonItem btnUpdateErrorDB;
        private DevExpress.XtraBars.BarButtonItem btnCollectOptimization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuOpti;
        private DevExpress.XtraBars.BarCheckItem chkOptimizationMode;
    }
}