namespace UDMTracker
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.exAppMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbon = new DevExpress.Utils.ImageCollection(this.components);
            this.exRibbonGallery = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.chkViewTagTable = new DevExpress.XtraBars.BarCheckItem();
            this.chkViewGroupTree = new DevExpress.XtraBars.BarCheckItem();
            this.chkViewMonitorStatus = new DevExpress.XtraBars.BarCheckItem();
            this.btnStartMonitor = new DevExpress.XtraBars.BarButtonItem();
            this.mnuStartMonitor = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnStartSimulation = new DevExpress.XtraBars.BarButtonItem();
            this.btnStopMonitor = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportTagAdd = new DevExpress.XtraBars.BarButtonItem();
            this.mnuImportTag = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnImportSymbolNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportTag = new DevExpress.XtraBars.BarButtonItem();
            this.mnuExportTag = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnExportSymbolForKepware = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdatePatternItem = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdatePattern = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateDataBase = new DevExpress.XtraBars.BarButtonItem();
            this.btnTestDBConnection = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportLog = new DevExpress.XtraBars.BarButtonItem();
            this.dtpkExportFrom = new DevExpress.XtraBars.BarEditItem();
            this.exEditorExportFrom = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkExportTo = new DevExpress.XtraBars.BarEditItem();
            this.exEditorExportTo = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnConfigSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewSymbolLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewCycleLog = new DevExpress.XtraBars.BarButtonItem();
            this.lblMonitorCountLabel = new DevExpress.XtraBars.BarStaticItem();
            this.lblMonitorCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnImportLogic = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewLogicDiagram = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaximized = new DevExpress.XtraBars.BarButtonItem();
            this.chkMonitorDetection = new DevExpress.XtraBars.BarCheckItem();
            this.chkMonitorPatternItem = new DevExpress.XtraBars.BarCheckItem();
            this.chkMonitorMasterPattern = new DevExpress.XtraBars.BarCheckItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnViewProcessTimeChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewStatisticsTable = new DevExpress.XtraBars.BarButtonItem();
            this.txtAddressFilter = new DevExpress.XtraBars.BarEditItem();
            this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.txtDescriptionFilter = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDescriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.btnApplyFilter = new DevExpress.XtraBars.BarButtonItem();
            this.chkViewDashBoard = new DevExpress.XtraBars.BarCheckItem();
            this.chkLsPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkMelsecPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkSiemens = new DevExpress.XtraBars.BarCheckItem();
            this.chkAbPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkDDEA = new DevExpress.XtraBars.BarCheckItem();
            this.chkOPC = new DevExpress.XtraBars.BarCheckItem();
            this.btnViewMonitorErrorLog = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuHomeFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomeView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomeSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModel = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuPlcMaker = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModelTag = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModelMasterPattern = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitor = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuMonitorSource = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorMode = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorExportLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuViewLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuViewStatistics = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.exEditorUseOPC = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exEditorUseDDEA = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rcmbOPCServer = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exRibbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnlGroupTree = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlGroupTreeContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucGroupTree = new UDM.Project.UCGroupTree();
            this.ucProjectManager = new UDM.Project.UCProjectManager(this.components);
            this.ucTagTable = new UDM.Project.UCTagTable();
            this.dpnlMonitorStatus = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlMonitorStatusContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucGroupStateTable = new UDM.Project.UCGroupStateTable();
            this.ucClock = new UDM.Project.UCClock();
            this.ucMonitorStatus = new UDM.Project.UCMonitorStatus();
            this.dpnlSystemLog = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlSystemLogContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSystemLogTable = new UDM.Project.UCSystemLogTable();
            this.dpnlTagTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlTagTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.mnuImportExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.grpMonitorRunView = new DevExpress.XtraEditors.GroupControl();
            this.sptMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucGroupCycleBoardS = new UDM.Project.UCGroupCycleBoardS();
            this.grdTag = new DevExpress.XtraGrid.GridControl();
            this.grvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuStartMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuImportTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseOPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseDDEA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcmbOPCServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.dpnlGroupTree.SuspendLayout();
            this.dpnlGroupTreeContainer.SuspendLayout();
            this.dpnlMonitorStatus.SuspendLayout();
            this.dpnlMonitorStatusContainer.SuspendLayout();
            this.dpnlSystemLog.SuspendLayout();
            this.dpnlSystemLogContainer.SuspendLayout();
            this.dpnlTagTable.SuspendLayout();
            this.dpnlTagTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitorRunView)).BeginInit();
            this.grpMonitorRunView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            this.SuspendLayout();
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.ApplicationButtonDropDownControl = this.exAppMenu;
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
            this.chkViewTagTable,
            this.chkViewGroupTree,
            this.chkViewMonitorStatus,
            this.btnStartMonitor,
            this.btnStopMonitor,
            this.btnStartSimulation,
            this.btnImportTagAdd,
            this.btnImportSymbolNew,
            this.btnExportTag,
            this.btnExportSymbolForKepware,
            this.btnUpdatePatternItem,
            this.btnUpdatePattern,
            this.btnEditMasterPattern,
            this.btnCreateDataBase,
            this.btnTestDBConnection,
            this.btnExportLog,
            this.dtpkExportFrom,
            this.dtpkExportTo,
            this.btnConfigSetting,
            this.btnViewSymbolLog,
            this.btnViewCycleLog,
            this.lblMonitorCountLabel,
            this.lblMonitorCount,
            this.btnImportLogic,
            this.btnViewLogicDiagram,
            this.btnMaximized,
            this.chkMonitorDetection,
            this.chkMonitorPatternItem,
            this.chkMonitorMasterPattern,
            this.lblStatus,
            this.btnViewProcessTimeChart,
            this.btnViewStatisticsTable,
            this.txtAddressFilter,
            this.txtDescriptionFilter,
            this.btnApplyFilter,
            this.chkViewDashBoard,
            this.chkLsPlc,
            this.chkMelsecPlc,
            this.chkSiemens,
            this.chkAbPlc,
            this.chkDDEA,
            this.chkOPC,
            this.btnViewMonitorErrorLog});
            this.exRibbonControl.LargeImages = this.imgListRibbonLarge;
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.MaxItemId = 108;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.PageHeaderItemLinks.Add(this.btnMaximized);
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome,
            this.mnuModel,
            this.mnuMonitor,
            this.mnuView,
            this.mnuHelp});
            this.exRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorExportFrom,
            this.exEditorExportTo,
            this.exEditorUseOPC,
            this.exEditorUseDDEA,
            this.rcmbOPCServer,
            this.exEditorAddressFilter,
            this.exEditorDescriptionFilter});
            this.exRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonControl.Size = new System.Drawing.Size(942, 147);
            this.exRibbonControl.StatusBar = this.exRibbonStatusBar;
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnSave);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnSaveAs);
            // 
            // exAppMenu
            // 
            this.exAppMenu.ItemLinks.Add(this.btnNew);
            this.exAppMenu.ItemLinks.Add(this.btnOpen);
            this.exAppMenu.ItemLinks.Add(this.btnSave);
            this.exAppMenu.ItemLinks.Add(this.btnSaveAs);
            this.exAppMenu.ItemLinks.Add(this.btnExit);
            this.exAppMenu.Name = "exAppMenu";
            this.exAppMenu.Ribbon = this.exRibbonControl;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
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
            // exRibbonGallery
            // 
            this.exRibbonGallery.Caption = "Skin";
            this.exRibbonGallery.Id = 6;
            this.exRibbonGallery.Name = "exRibbonGallery";
            // 
            // chkViewTagTable
            // 
            this.chkViewTagTable.BindableChecked = true;
            this.chkViewTagTable.Caption = "Tag\r\nTable";
            this.chkViewTagTable.Checked = true;
            this.chkViewTagTable.Id = 8;
            this.chkViewTagTable.LargeImageIndex = 15;
            this.chkViewTagTable.Name = "chkViewTagTable";
            this.chkViewTagTable.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewTagTable_CheckedChanged);
            // 
            // chkViewGroupTree
            // 
            this.chkViewGroupTree.BindableChecked = true;
            this.chkViewGroupTree.Caption = "Group Tree";
            this.chkViewGroupTree.Checked = true;
            this.chkViewGroupTree.Id = 9;
            this.chkViewGroupTree.LargeImageIndex = 28;
            this.chkViewGroupTree.Name = "chkViewGroupTree";
            this.chkViewGroupTree.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewGroupTree_CheckedChanged);
            // 
            // chkViewMonitorStatus
            // 
            this.chkViewMonitorStatus.BindableChecked = true;
            this.chkViewMonitorStatus.Caption = "Monitor Status";
            this.chkViewMonitorStatus.Checked = true;
            this.chkViewMonitorStatus.Id = 10;
            this.chkViewMonitorStatus.LargeImageIndex = 3;
            this.chkViewMonitorStatus.Name = "chkViewMonitorStatus";
            this.chkViewMonitorStatus.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewMonitorStatus_CheckedChanged);
            // 
            // btnStartMonitor
            // 
            this.btnStartMonitor.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnStartMonitor.Caption = "Start";
            this.btnStartMonitor.DropDownControl = this.mnuStartMonitor;
            this.btnStartMonitor.Id = 11;
            this.btnStartMonitor.LargeImageIndex = 9;
            this.btnStartMonitor.Name = "btnStartMonitor";
            this.btnStartMonitor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStartMonitor_ItemClick);
            // 
            // mnuStartMonitor
            // 
            this.mnuStartMonitor.ItemLinks.Add(this.btnStartSimulation);
            this.mnuStartMonitor.Name = "mnuStartMonitor";
            this.mnuStartMonitor.Ribbon = this.exRibbonControl;
            // 
            // btnStartSimulation
            // 
            this.btnStartSimulation.Caption = "Start Simulatoin";
            this.btnStartSimulation.Id = 13;
            this.btnStartSimulation.ImageIndex = 15;
            this.btnStartSimulation.Name = "btnStartSimulation";
            this.btnStartSimulation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStartSimulation_ItemClick);
            // 
            // btnStopMonitor
            // 
            this.btnStopMonitor.Caption = "Stop";
            this.btnStopMonitor.Id = 12;
            this.btnStopMonitor.LargeImageIndex = 10;
            this.btnStopMonitor.Name = "btnStopMonitor";
            this.btnStopMonitor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStopMonitor_ItemClick);
            // 
            // btnImportTagAdd
            // 
            this.btnImportTagAdd.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnImportTagAdd.Caption = "Import Tag List";
            this.btnImportTagAdd.DropDownControl = this.mnuImportTag;
            this.btnImportTagAdd.Id = 14;
            this.btnImportTagAdd.LargeImageIndex = 21;
            this.btnImportTagAdd.Name = "btnImportTagAdd";
            this.btnImportTagAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportTagAdd_ItemClick);
            // 
            // mnuImportTag
            // 
            this.mnuImportTag.ItemLinks.Add(this.btnImportSymbolNew);
            this.mnuImportTag.Name = "mnuImportTag";
            this.mnuImportTag.Ribbon = this.exRibbonControl;
            // 
            // btnImportSymbolNew
            // 
            this.btnImportSymbolNew.Caption = "Import New";
            this.btnImportSymbolNew.Id = 15;
            this.btnImportSymbolNew.ImageIndex = 0;
            this.btnImportSymbolNew.Name = "btnImportSymbolNew";
            this.btnImportSymbolNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportTagNew_ItemClick);
            // 
            // btnExportTag
            // 
            this.btnExportTag.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnExportTag.Caption = "Export Tag List";
            this.btnExportTag.DropDownControl = this.mnuExportTag;
            this.btnExportTag.Id = 16;
            this.btnExportTag.LargeImageIndex = 20;
            this.btnExportTag.Name = "btnExportTag";
            this.btnExportTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportTag_ItemClick);
            // 
            // mnuExportTag
            // 
            this.mnuExportTag.ItemLinks.Add(this.btnExportSymbolForKepware);
            this.mnuExportTag.Name = "mnuExportTag";
            this.mnuExportTag.Ribbon = this.exRibbonControl;
            // 
            // btnExportSymbolForKepware
            // 
            this.btnExportSymbolForKepware.Caption = "Export For Kepware";
            this.btnExportSymbolForKepware.Id = 17;
            this.btnExportSymbolForKepware.ImageIndex = 15;
            this.btnExportSymbolForKepware.Name = "btnExportSymbolForKepware";
            this.btnExportSymbolForKepware.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportTagForKepware_ItemClick);
            // 
            // btnUpdatePatternItem
            // 
            this.btnUpdatePatternItem.Caption = "Update Pattern Item";
            this.btnUpdatePatternItem.Id = 18;
            this.btnUpdatePatternItem.LargeImageIndex = 30;
            this.btnUpdatePatternItem.Name = "btnUpdatePatternItem";
            this.btnUpdatePatternItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdatePatternItem_ItemClick);
            // 
            // btnUpdatePattern
            // 
            this.btnUpdatePattern.Caption = "Update Master Pattern";
            this.btnUpdatePattern.Id = 19;
            this.btnUpdatePattern.LargeImageIndex = 30;
            this.btnUpdatePattern.Name = "btnUpdatePattern";
            this.btnUpdatePattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdateMasterPattern_ItemClick);
            // 
            // btnEditMasterPattern
            // 
            this.btnEditMasterPattern.Caption = "Edit Master Pattern";
            this.btnEditMasterPattern.Id = 20;
            this.btnEditMasterPattern.LargeImageIndex = 31;
            this.btnEditMasterPattern.Name = "btnEditMasterPattern";
            this.btnEditMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditMasterPattern_ItemClick);
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
            // btnConfigSetting
            // 
            this.btnConfigSetting.Caption = "Setting";
            this.btnConfigSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConfigSetting.Glyph")));
            this.btnConfigSetting.Id = 26;
            this.btnConfigSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConfigSetting.LargeGlyph")));
            this.btnConfigSetting.Name = "btnConfigSetting";
            this.btnConfigSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetting_ItemClick);
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
            // btnImportLogic
            // 
            this.btnImportLogic.Caption = "Import Logic";
            this.btnImportLogic.Id = 39;
            this.btnImportLogic.ImageIndex = 7;
            this.btnImportLogic.LargeImageIndex = 7;
            this.btnImportLogic.Name = "btnImportLogic";
            this.btnImportLogic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportLogic_ItemClick);
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
            // chkMonitorDetection
            // 
            this.chkMonitorDetection.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.chkMonitorDetection.BindableChecked = true;
            this.chkMonitorDetection.Caption = "Error\r\nDetect";
            this.chkMonitorDetection.Checked = true;
            this.chkMonitorDetection.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorDetection.Glyph")));
            this.chkMonitorDetection.GroupIndex = 2;
            this.chkMonitorDetection.Id = 88;
            this.chkMonitorDetection.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorDetection.LargeGlyph")));
            this.chkMonitorDetection.Name = "chkMonitorDetection";
            // 
            // chkMonitorPatternItem
            // 
            this.chkMonitorPatternItem.Caption = "Pattern Item";
            this.chkMonitorPatternItem.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorPatternItem.Glyph")));
            this.chkMonitorPatternItem.GroupIndex = 2;
            this.chkMonitorPatternItem.Id = 89;
            this.chkMonitorPatternItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorPatternItem.LargeGlyph")));
            this.chkMonitorPatternItem.Name = "chkMonitorPatternItem";
            // 
            // chkMonitorMasterPattern
            // 
            this.chkMonitorMasterPattern.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.chkMonitorMasterPattern.Caption = "Master\r\nPattern";
            this.chkMonitorMasterPattern.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorMasterPattern.Glyph")));
            this.chkMonitorMasterPattern.GroupIndex = 2;
            this.chkMonitorMasterPattern.Id = 90;
            this.chkMonitorMasterPattern.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMonitorMasterPattern.LargeGlyph")));
            this.chkMonitorMasterPattern.Name = "chkMonitorMasterPattern";
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
            // txtAddressFilter
            // 
            this.txtAddressFilter.Caption = "Address     ";
            this.txtAddressFilter.Edit = this.exEditorAddressFilter;
            this.txtAddressFilter.Id = 95;
            this.txtAddressFilter.Name = "txtAddressFilter";
            this.txtAddressFilter.Width = 100;
            // 
            // exEditorAddressFilter
            // 
            this.exEditorAddressFilter.AutoHeight = false;
            this.exEditorAddressFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAddressFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.exEditorAddressFilter.Name = "exEditorAddressFilter";
            // 
            // txtDescriptionFilter
            // 
            this.txtDescriptionFilter.Caption = "Description ";
            this.txtDescriptionFilter.Edit = this.exEditorDescriptionFilter;
            this.txtDescriptionFilter.Id = 96;
            this.txtDescriptionFilter.Name = "txtDescriptionFilter";
            this.txtDescriptionFilter.Width = 100;
            // 
            // exEditorDescriptionFilter
            // 
            this.exEditorDescriptionFilter.AutoHeight = false;
            this.exEditorDescriptionFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDescriptionFilter.Name = "exEditorDescriptionFilter";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Caption = "Apply Filter";
            this.btnApplyFilter.Id = 97;
            this.btnApplyFilter.LargeImageIndex = 11;
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApplyFilter_ItemClick);
            // 
            // chkViewDashBoard
            // 
            this.chkViewDashBoard.BindableChecked = true;
            this.chkViewDashBoard.Caption = "Dash   Board";
            this.chkViewDashBoard.Checked = true;
            this.chkViewDashBoard.Id = 99;
            this.chkViewDashBoard.LargeImageIndex = 35;
            this.chkViewDashBoard.Name = "chkViewDashBoard";
            // 
            // chkLsPlc
            // 
            this.chkLsPlc.BindableChecked = true;
            this.chkLsPlc.Caption = "LS        ";
            this.chkLsPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkLsPlc.Checked = true;
            this.chkLsPlc.Glyph = ((System.Drawing.Image)(resources.GetObject("chkLsPlc.Glyph")));
            this.chkLsPlc.GroupIndex = 3;
            this.chkLsPlc.Id = 100;
            this.chkLsPlc.Name = "chkLsPlc";
            this.chkLsPlc.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLsPlc_CheckedChanged);
            // 
            // chkMelsecPlc
            // 
            this.chkMelsecPlc.Caption = "Melsec  ";
            this.chkMelsecPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkMelsecPlc.Glyph = ((System.Drawing.Image)(resources.GetObject("chkMelsecPlc.Glyph")));
            this.chkMelsecPlc.GroupIndex = 3;
            this.chkMelsecPlc.Id = 101;
            this.chkMelsecPlc.Name = "chkMelsecPlc";
            this.chkMelsecPlc.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLsPlc_CheckedChanged);
            // 
            // chkSiemens
            // 
            this.chkSiemens.Caption = "Siemens";
            this.chkSiemens.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkSiemens.Glyph = ((System.Drawing.Image)(resources.GetObject("chkSiemens.Glyph")));
            this.chkSiemens.GroupIndex = 3;
            this.chkSiemens.Id = 102;
            this.chkSiemens.Name = "chkSiemens";
            this.chkSiemens.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLsPlc_CheckedChanged);
            // 
            // chkAbPlc
            // 
            this.chkAbPlc.Caption = "AB        ";
            this.chkAbPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkAbPlc.Glyph = ((System.Drawing.Image)(resources.GetObject("chkAbPlc.Glyph")));
            this.chkAbPlc.GroupIndex = 3;
            this.chkAbPlc.Id = 103;
            this.chkAbPlc.Name = "chkAbPlc";
            this.chkAbPlc.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkLsPlc_CheckedChanged);
            // 
            // chkDDEA
            // 
            this.chkDDEA.BindableChecked = true;
            this.chkDDEA.Caption = "DDEA ";
            this.chkDDEA.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkDDEA.Checked = true;
            this.chkDDEA.Glyph = ((System.Drawing.Image)(resources.GetObject("chkDDEA.Glyph")));
            this.chkDDEA.GroupIndex = 4;
            this.chkDDEA.Id = 104;
            this.chkDDEA.Name = "chkDDEA";
            // 
            // chkOPC
            // 
            this.chkOPC.Caption = "OPC   ";
            this.chkOPC.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkOPC.Glyph = ((System.Drawing.Image)(resources.GetObject("chkOPC.Glyph")));
            this.chkOPC.GroupIndex = 4;
            this.chkOPC.Id = 105;
            this.chkOPC.Name = "chkOPC";
            // 
            // btnViewMonitorErrorLog
            // 
            this.btnViewMonitorErrorLog.Caption = "View Monitor Event";
            this.btnViewMonitorErrorLog.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewMonitorErrorLog.Id = 107;
            this.btnViewMonitorErrorLog.LargeImageIndex = 36;
            this.btnViewMonitorErrorLog.Name = "btnViewMonitorErrorLog";
            this.btnViewMonitorErrorLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonitorEventViewer_Click);
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
            this.imgListRibbonLarge.Images.SetKeyName(36, "IgnoreMasterFilter_32x32.png");
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuHomeFile,
            this.mnuHomeView,
            this.mnuHomeSkin,
            this.mnuExit});
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Text = "Home";
            // 
            // mnuHomeFile
            // 
            this.mnuHomeFile.ItemLinks.Add(this.btnNew);
            this.mnuHomeFile.ItemLinks.Add(this.btnOpen);
            this.mnuHomeFile.ItemLinks.Add(this.btnSave);
            this.mnuHomeFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuHomeFile.Name = "mnuHomeFile";
            this.mnuHomeFile.Text = "File";
            // 
            // mnuHomeView
            // 
            this.mnuHomeView.ItemLinks.Add(this.chkViewTagTable);
            this.mnuHomeView.ItemLinks.Add(this.chkViewGroupTree);
            this.mnuHomeView.ItemLinks.Add(this.chkViewMonitorStatus);
            this.mnuHomeView.Name = "mnuHomeView";
            this.mnuHomeView.Text = "Views";
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
            // mnuModel
            // 
            this.mnuModel.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuPlcMaker,
            this.mnuModelTag,
            this.mnuModelMasterPattern,
            this.mnuFilter});
            this.mnuModel.Name = "mnuModel";
            this.mnuModel.Text = "Model";
            // 
            // mnuPlcMaker
            // 
            this.mnuPlcMaker.ItemLinks.Add(this.chkLsPlc);
            this.mnuPlcMaker.ItemLinks.Add(this.chkMelsecPlc);
            this.mnuPlcMaker.ItemLinks.Add(this.chkSiemens);
            this.mnuPlcMaker.Name = "mnuPlcMaker";
            this.mnuPlcMaker.Text = "PLC Maker";
            // 
            // mnuModelTag
            // 
            this.mnuModelTag.ItemLinks.Add(this.btnImportLogic);
            this.mnuModelTag.ItemLinks.Add(this.btnImportTagAdd);
            this.mnuModelTag.ItemLinks.Add(this.btnExportTag);
            this.mnuModelTag.Name = "mnuModelTag";
            this.mnuModelTag.Text = "Tag";
            // 
            // mnuModelMasterPattern
            // 
            this.mnuModelMasterPattern.ItemLinks.Add(this.btnUpdatePatternItem);
            this.mnuModelMasterPattern.ItemLinks.Add(this.btnUpdatePattern);
            this.mnuModelMasterPattern.ItemLinks.Add(this.btnEditMasterPattern);
            this.mnuModelMasterPattern.Name = "mnuModelMasterPattern";
            this.mnuModelMasterPattern.Text = "Master Pattern";
            // 
            // mnuFilter
            // 
            this.mnuFilter.ItemLinks.Add(this.txtAddressFilter, true);
            this.mnuFilter.ItemLinks.Add(this.txtDescriptionFilter);
            this.mnuFilter.ItemLinks.Add(this.btnApplyFilter, true);
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Text = "Group Tree Filter";
            // 
            // mnuMonitor
            // 
            this.mnuMonitor.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuMonitorSource,
            this.mnuMonitorDatabase,
            this.mnuMonitorMode,
            this.mnuMonitorControl,
            this.mnuMonitorExportLog});
            this.mnuMonitor.Name = "mnuMonitor";
            this.mnuMonitor.Text = "Monitor";
            // 
            // mnuMonitorSource
            // 
            this.mnuMonitorSource.ItemLinks.Add(this.chkDDEA);
            this.mnuMonitorSource.ItemLinks.Add(this.chkOPC);
            this.mnuMonitorSource.ItemLinks.Add(this.btnConfigSetting, true);
            this.mnuMonitorSource.Name = "mnuMonitorSource";
            this.mnuMonitorSource.Text = "Connection Setting";
            // 
            // mnuMonitorDatabase
            // 
            this.mnuMonitorDatabase.ItemLinks.Add(this.btnCreateDataBase);
            this.mnuMonitorDatabase.ItemLinks.Add(this.btnTestDBConnection);
            this.mnuMonitorDatabase.Name = "mnuMonitorDatabase";
            this.mnuMonitorDatabase.Text = "DataBase";
            // 
            // mnuMonitorMode
            // 
            this.mnuMonitorMode.ItemLinks.Add(this.chkMonitorPatternItem);
            this.mnuMonitorMode.ItemLinks.Add(this.chkMonitorMasterPattern);
            this.mnuMonitorMode.ItemLinks.Add(this.chkMonitorDetection);
            this.mnuMonitorMode.Name = "mnuMonitorMode";
            this.mnuMonitorMode.Text = "Mode Select";
            // 
            // mnuMonitorControl
            // 
            this.mnuMonitorControl.ItemLinks.Add(this.btnStartMonitor, true);
            this.mnuMonitorControl.ItemLinks.Add(this.btnStopMonitor);
            this.mnuMonitorControl.Name = "mnuMonitorControl";
            this.mnuMonitorControl.Text = "Control";
            // 
            // mnuMonitorExportLog
            // 
            this.mnuMonitorExportLog.ItemLinks.Add(this.btnExportLog);
            this.mnuMonitorExportLog.ItemLinks.Add(this.dtpkExportFrom);
            this.mnuMonitorExportLog.ItemLinks.Add(this.dtpkExportTo);
            this.mnuMonitorExportLog.Name = "mnuMonitorExportLog";
            this.mnuMonitorExportLog.Text = "Export Log";
            // 
            // mnuView
            // 
            this.mnuView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuViewLog,
            this.mnuViewStatistics});
            this.mnuView.Name = "mnuView";
            this.mnuView.Text = "View";
            // 
            // mnuViewLog
            // 
            this.mnuViewLog.ItemLinks.Add(this.btnViewSymbolLog);
            this.mnuViewLog.ItemLinks.Add(this.btnViewCycleLog);
            this.mnuViewLog.ItemLinks.Add(this.btnViewLogicDiagram);
            this.mnuViewLog.Name = "mnuViewLog";
            this.mnuViewLog.Text = "Log";
            // 
            // mnuViewStatistics
            // 
            this.mnuViewStatistics.ItemLinks.Add(this.btnViewProcessTimeChart);
            this.mnuViewStatistics.ItemLinks.Add(this.btnViewStatisticsTable);
            this.mnuViewStatistics.ItemLinks.Add(this.btnViewMonitorErrorLog);
            this.mnuViewStatistics.Name = "mnuViewStatistics";
            this.mnuViewStatistics.Text = "Statistics";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Visible = false;
            // 
            // exEditorUseOPC
            // 
            this.exEditorUseOPC.AutoHeight = false;
            this.exEditorUseOPC.Name = "exEditorUseOPC";
            this.exEditorUseOPC.CheckStateChanged += new System.EventHandler(this.exEditorUseOPC_CheckStateChanged);
            // 
            // exEditorUseDDEA
            // 
            this.exEditorUseDDEA.AutoHeight = false;
            this.exEditorUseDDEA.Name = "exEditorUseDDEA";
            this.exEditorUseDDEA.CheckStateChanged += new System.EventHandler(this.exEditorUseDDEA_CheckStateChanged);
            // 
            // rcmbOPCServer
            // 
            this.rcmbOPCServer.AutoHeight = false;
            this.rcmbOPCServer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rcmbOPCServer.Name = "rcmbOPCServer";
            // 
            // exRibbonStatusBar
            // 
            this.exRibbonStatusBar.ItemLinks.Add(this.lblMonitorCountLabel);
            this.exRibbonStatusBar.ItemLinks.Add(this.lblMonitorCount);
            this.exRibbonStatusBar.ItemLinks.Add(this.lblStatus);
            this.exRibbonStatusBar.Location = new System.Drawing.Point(0, 752);
            this.exRibbonStatusBar.Name = "exRibbonStatusBar";
            this.exRibbonStatusBar.Ribbon = this.exRibbonControl;
            this.exRibbonStatusBar.Size = new System.Drawing.Size(942, 31);
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlGroupTree,
            this.dpnlMonitorStatus,
            this.dpnlSystemLog,
            this.dpnlTagTable});
            this.exDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpnlGroupTree
            // 
            this.dpnlGroupTree.Controls.Add(this.dpnlGroupTreeContainer);
            this.dpnlGroupTree.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnlGroupTree.ID = new System.Guid("086b83c4-f0b7-4fec-b669-255321e18a2d");
            this.dpnlGroupTree.Location = new System.Drawing.Point(0, 147);
            this.dpnlGroupTree.Name = "dpnlGroupTree";
            this.dpnlGroupTree.OriginalSize = new System.Drawing.Size(215, 200);
            this.dpnlGroupTree.Size = new System.Drawing.Size(215, 605);
            this.dpnlGroupTree.Text = "Group Tree";
            this.dpnlGroupTree.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dpnlGroupTree_VisibilityChanged);
            // 
            // dpnlGroupTreeContainer
            // 
            this.dpnlGroupTreeContainer.Controls.Add(this.ucGroupTree);
            this.dpnlGroupTreeContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlGroupTreeContainer.Name = "dpnlGroupTreeContainer";
            this.dpnlGroupTreeContainer.Size = new System.Drawing.Size(207, 578);
            this.dpnlGroupTreeContainer.TabIndex = 0;
            // 
            // ucGroupTree
            // 
            this.ucGroupTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGroupTree.Editable = false;
            this.ucGroupTree.Location = new System.Drawing.Point(0, 0);
            this.ucGroupTree.Manager = this.ucProjectManager;
            this.ucGroupTree.Name = "ucGroupTree";
            this.ucGroupTree.Project = null;
            this.ucGroupTree.Size = new System.Drawing.Size(207, 578);
            this.ucGroupTree.TabIndex = 0;
            this.ucGroupTree.UEventInputTextRequest += new UDM.Project.UEventHandlerGroupTreeInputTextRequest(this.ucGrouplTree_UEventInputTextRequest);
            this.ucGroupTree.UEventSymbolAdding += new UDM.Project.UEventHandlerGroupTreeSymbolAdding(this.ucGroupTree_UEventSymbolAdding);
            this.ucGroupTree.UEventSymbolDoubleClicked += new UDM.Project.UEventHandlerGroupTreeSymbolDoubleClicked(this.ucGrouplTree_UEventSymbolDoubleClicked);
            this.ucGroupTree.UEventGroupUpdated += new UDM.Project.UEventHandlerGroupTreeGroupUpdate(this.ucGroupTree_UEventGroupUpdated);
            this.ucGroupTree.UEventGroupDoubleClicked += new UDM.Project.UEventHandlerGroupTreeGroupDoubleClicked(this.ucGrouplTree_UEventGroupDoubleClicked);
            // 
            // ucProjectManager
            // 
            this.ucProjectManager.Editable = true;
            this.ucProjectManager.GroupTreeView = this.ucGroupTree;
            this.ucProjectManager.Project = null;
            this.ucProjectManager.TagTableView = this.ucTagTable;
            this.ucProjectManager.UEventProjectCreated += new UDM.Project.UEventHandlerProjectCreated(this.ucProjectManager_UEventProjectCreated);
            this.ucProjectManager.UEventProjectOpened += new UDM.Project.UEventHandlerProjectOpened(this.ucProjectManager_UEventProjectOpened);
            this.ucProjectManager.UEventProjectCleared += new UDM.Project.UEventHandlerProjectCleared(this.ucProjectManager_UEventProjectCleared);
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTagTable.Editable = true;
            this.ucTagTable.Location = new System.Drawing.Point(0, 0);
            this.ucTagTable.Manager = this.ucProjectManager;
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.Project = null;
            this.ucTagTable.Size = new System.Drawing.Size(449, 282);
            this.ucTagTable.TabIndex = 0;
            this.ucTagTable.UEventInputTextRequest += new UDM.Project.UEventHandlerTagTableInputTextRequest(this.ucTagTable_UEventInputTextRequest);
            // 
            // dpnlMonitorStatus
            // 
            this.dpnlMonitorStatus.Controls.Add(this.dpnlMonitorStatusContainer);
            this.dpnlMonitorStatus.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnlMonitorStatus.ID = new System.Guid("a5baeb4d-d1fd-4bf0-99fd-35c5a20a24d4");
            this.dpnlMonitorStatus.Location = new System.Drawing.Point(672, 147);
            this.dpnlMonitorStatus.Name = "dpnlMonitorStatus";
            this.dpnlMonitorStatus.OriginalSize = new System.Drawing.Size(270, 200);
            this.dpnlMonitorStatus.Size = new System.Drawing.Size(270, 605);
            this.dpnlMonitorStatus.Text = "Monitor Status";
            this.dpnlMonitorStatus.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dpnlMonitorStatus_VisibilityChanged);
            // 
            // dpnlMonitorStatusContainer
            // 
            this.dpnlMonitorStatusContainer.Controls.Add(this.ucGroupStateTable);
            this.dpnlMonitorStatusContainer.Controls.Add(this.ucClock);
            this.dpnlMonitorStatusContainer.Controls.Add(this.ucMonitorStatus);
            this.dpnlMonitorStatusContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlMonitorStatusContainer.Name = "dpnlMonitorStatusContainer";
            this.dpnlMonitorStatusContainer.Size = new System.Drawing.Size(262, 578);
            this.dpnlMonitorStatusContainer.TabIndex = 0;
            // 
            // ucGroupStateTable
            // 
            this.ucGroupStateTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGroupStateTable.GroupS = null;
            this.ucGroupStateTable.Location = new System.Drawing.Point(0, 134);
            this.ucGroupStateTable.MonitorViewer = null;
            this.ucGroupStateTable.Name = "ucGroupStateTable";
            this.ucGroupStateTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucGroupStateTable.Size = new System.Drawing.Size(262, 444);
            this.ucGroupStateTable.TabIndex = 2;
            // 
            // ucClock
            // 
            this.ucClock.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucClock.Location = new System.Drawing.Point(0, 69);
            this.ucClock.Name = "ucClock";
            this.ucClock.Padding = new System.Windows.Forms.Padding(5);
            this.ucClock.Size = new System.Drawing.Size(262, 65);
            this.ucClock.TabIndex = 0;
            // 
            // ucMonitorStatus
            // 
            this.ucMonitorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucMonitorStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMonitorStatus.Location = new System.Drawing.Point(0, 0);
            this.ucMonitorStatus.Name = "ucMonitorStatus";
            this.ucMonitorStatus.Padding = new System.Windows.Forms.Padding(5);
            this.ucMonitorStatus.Size = new System.Drawing.Size(262, 69);
            this.ucMonitorStatus.TabIndex = 1;
            // 
            // dpnlSystemLog
            // 
            this.dpnlSystemLog.Controls.Add(this.dpnlSystemLogContainer);
            this.dpnlSystemLog.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnlSystemLog.FloatSize = new System.Drawing.Size(194, 87);
            this.dpnlSystemLog.FloatVertical = true;
            this.dpnlSystemLog.ID = new System.Guid("e30a9e30-823c-43f2-b93e-ced4f4b17b75");
            this.dpnlSystemLog.Location = new System.Drawing.Point(215, 564);
            this.dpnlSystemLog.Name = "dpnlSystemLog";
            this.dpnlSystemLog.OriginalSize = new System.Drawing.Size(200, 188);
            this.dpnlSystemLog.Size = new System.Drawing.Size(457, 188);
            this.dpnlSystemLog.Text = "System Log";
            // 
            // dpnlSystemLogContainer
            // 
            this.dpnlSystemLogContainer.Controls.Add(this.ucSystemLogTable);
            this.dpnlSystemLogContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlSystemLogContainer.Name = "dpnlSystemLogContainer";
            this.dpnlSystemLogContainer.Size = new System.Drawing.Size(449, 161);
            this.dpnlSystemLogContainer.TabIndex = 0;
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucSystemLogTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucSystemLogTable.Size = new System.Drawing.Size(449, 161);
            this.ucSystemLogTable.TabIndex = 0;
            // 
            // dpnlTagTable
            // 
            this.dpnlTagTable.Controls.Add(this.dpnlTagTableContainer);
            this.dpnlTagTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dpnlTagTable.FloatSize = new System.Drawing.Size(194, 88);
            this.dpnlTagTable.FloatVertical = true;
            this.dpnlTagTable.ID = new System.Guid("77b0e2e4-d0d0-4c35-920d-9027927ca517");
            this.dpnlTagTable.Location = new System.Drawing.Point(215, 147);
            this.dpnlTagTable.Name = "dpnlTagTable";
            this.dpnlTagTable.OriginalSize = new System.Drawing.Size(200, 309);
            this.dpnlTagTable.Size = new System.Drawing.Size(457, 309);
            this.dpnlTagTable.Text = "Tag Table";
            this.dpnlTagTable.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dpnlTagTable_VisibilityChanged);
            // 
            // dpnlTagTableContainer
            // 
            this.dpnlTagTableContainer.Controls.Add(this.ucTagTable);
            this.dpnlTagTableContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlTagTableContainer.Name = "dpnlTagTableContainer";
            this.dpnlTagTableContainer.Size = new System.Drawing.Size(449, 282);
            this.dpnlTagTableContainer.TabIndex = 0;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 2000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // mnuImportExport
            // 
            this.mnuImportExport.ItemLinks.Add(this.btnExportTag);
            this.mnuImportExport.Name = "mnuImportExport";
            this.mnuImportExport.Text = "Import/Export";
            // 
            // grpMonitorRunView
            // 
            this.grpMonitorRunView.Controls.Add(this.sptMain);
            this.grpMonitorRunView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMonitorRunView.Location = new System.Drawing.Point(215, 456);
            this.grpMonitorRunView.Name = "grpMonitorRunView";
            this.grpMonitorRunView.Size = new System.Drawing.Size(457, 108);
            this.grpMonitorRunView.TabIndex = 7;
            this.grpMonitorRunView.Text = "Monitor Running View";
            this.grpMonitorRunView.Visible = false;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(2, 21);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.ucGroupCycleBoardS);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grdTag);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(453, 85);
            this.sptMain.SplitterPosition = 254;
            this.sptMain.TabIndex = 0;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // ucGroupCycleBoardS
            // 
            this.ucGroupCycleBoardS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGroupCycleBoardS.GroupS = null;
            this.ucGroupCycleBoardS.Location = new System.Drawing.Point(0, 0);
            this.ucGroupCycleBoardS.MonitorViewer = null;
            this.ucGroupCycleBoardS.Name = "ucGroupCycleBoardS";
            this.ucGroupCycleBoardS.Size = new System.Drawing.Size(254, 85);
            this.ucGroupCycleBoardS.TabIndex = 2;
            // 
            // grdTag
            // 
            this.grdTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTag.Location = new System.Drawing.Point(0, 0);
            this.grdTag.MainView = this.grvTag;
            this.grdTag.Name = "grdTag";
            this.grdTag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdTag.Size = new System.Drawing.Size(194, 85);
            this.grdTag.TabIndex = 4;
            this.grdTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTag});
            // 
            // grvTag
            // 
            this.grvTag.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvTag.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvTag.ColumnPanelRowHeight = 35;
            this.grvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDataType,
            this.colCurrentValue,
            this.colChangeCount,
            this.colDescription});
            this.grvTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTag.GridControl = this.grdTag;
            this.grvTag.IndicatorWidth = 50;
            this.grvTag.Name = "grvTag";
            this.grvTag.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTag.OptionsDetail.AllowZoomDetail = false;
            this.grvTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvTag.OptionsDetail.ShowDetailTabs = false;
            this.grvTag.OptionsDetail.SmartDetailExpand = false;
            this.grvTag.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTag.OptionsView.ShowAutoFilterRow = true;
            this.grvTag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTag.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAddress, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDescription, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "주소";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 50;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 117;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDataType.Caption = "데이터타입";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "DataType";
            this.colDataType.MinWidth = 32;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
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
            // colCurrentValue
            // 
            this.colCurrentValue.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCurrentValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentValue.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCurrentValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCurrentValue.Caption = "현재Value";
            this.colCurrentValue.FieldName = "CurrentValue";
            this.colCurrentValue.MinWidth = 50;
            this.colCurrentValue.Name = "colCurrentValue";
            this.colCurrentValue.OptionsColumn.FixedWidth = true;
            this.colCurrentValue.OptionsColumn.ReadOnly = true;
            this.colCurrentValue.Visible = true;
            this.colCurrentValue.VisibleIndex = 3;
            this.colCurrentValue.Width = 50;
            // 
            // colChangeCount
            // 
            this.colChangeCount.AppearanceCell.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colChangeCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChangeCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colChangeCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChangeCount.Caption = "변화 Count";
            this.colChangeCount.FieldName = "ChangeCount";
            this.colChangeCount.MinWidth = 50;
            this.colChangeCount.Name = "colChangeCount";
            this.colChangeCount.OptionsColumn.FixedWidth = true;
            this.colChangeCount.OptionsColumn.ReadOnly = true;
            this.colChangeCount.Visible = true;
            this.colChangeCount.VisibleIndex = 4;
            this.colChangeCount.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            this.colDescription.Width = 200;
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 783);
            this.Controls.Add(this.grpMonitorRunView);
            this.Controls.Add(this.dpnlTagTable);
            this.Controls.Add(this.dpnlSystemLog);
            this.Controls.Add(this.dpnlMonitorStatus);
            this.Controls.Add(this.dpnlGroupTree);
            this.Controls.Add(this.exRibbonStatusBar);
            this.Controls.Add(this.exRibbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.StatusBar = this.exRibbonStatusBar;
            this.Text = "Optra Tracker V1.0(Build.150922)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuStartMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuImportTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExportTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseOPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUseDDEA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcmbOPCServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.dpnlGroupTree.ResumeLayout(false);
            this.dpnlGroupTreeContainer.ResumeLayout(false);
            this.dpnlMonitorStatus.ResumeLayout(false);
            this.dpnlMonitorStatusContainer.ResumeLayout(false);
            this.dpnlSystemLog.ResumeLayout(false);
            this.dpnlSystemLogContainer.ResumeLayout(false);
            this.dpnlTagTable.ResumeLayout(false);
            this.dpnlTagTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMonitorRunView)).EndInit();
            this.grpMonitorRunView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
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
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuModel;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuMonitor;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuView;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private DevExpress.XtraBars.Docking.DockManager exDockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpnlTagTable;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlTagTableContainer;
        private UDM.Project.UCTagTable ucTagTable;
        private DevExpress.XtraBars.Docking.DockPanel dpnlGroupTree;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlGroupTreeContainer;
        private DevExpress.XtraBars.BarCheckItem chkViewTagTable;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomeView;
        private DevExpress.Utils.ImageCollection imgListRibbon;
        private DevExpress.Utils.ImageCollection imgListRibbonLarge;
        private DevExpress.XtraBars.PopupMenu mnuStartMonitor;
        private DevExpress.XtraBars.PopupMenu mnuExportTag;
        private DevExpress.XtraBars.PopupMenu mnuImportTag;
        private DevExpress.XtraBars.BarCheckItem chkViewGroupTree;
        private DevExpress.XtraBars.BarCheckItem chkViewMonitorStatus;
        private DevExpress.XtraBars.Docking.DockPanel dpnlMonitorStatus;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlMonitorStatusContainer;
        private UDM.Project.UCGroupStateTable ucGroupStateTable;
        private UDM.Project.UCClock ucClock;
        private UDM.Project.UCMonitorStatus ucMonitorStatus;
        private System.Windows.Forms.Timer tmrTimer;
        private DevExpress.XtraBars.BarButtonItem btnStartMonitor;
        private DevExpress.XtraBars.BarButtonItem btnStopMonitor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuModelTag;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuModelMasterPattern;
        private DevExpress.XtraBars.BarButtonItem btnStartSimulation;
        private DevExpress.XtraBars.BarButtonItem btnImportTagAdd;
        private DevExpress.XtraBars.BarButtonItem btnImportSymbolNew;
        private DevExpress.XtraBars.BarButtonItem btnExportTag;
        private DevExpress.XtraBars.BarButtonItem btnExportSymbolForKepware;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePatternItem;
        private DevExpress.XtraBars.BarButtonItem btnUpdatePattern;
        private DevExpress.XtraBars.BarButtonItem btnEditMasterPattern;
        private DevExpress.XtraBars.BarButtonItem btnCreateDataBase;
        private DevExpress.XtraBars.BarButtonItem btnTestDBConnection;
        private DevExpress.XtraBars.BarButtonItem btnExportLog;
        private DevExpress.XtraBars.BarEditItem dtpkExportFrom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorExportFrom;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorSource;
        private DevExpress.XtraBars.BarEditItem dtpkExportTo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorExportTo;
        private DevExpress.XtraBars.BarButtonItem btnConfigSetting;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorUseOPC;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorUseDDEA;
        private DevExpress.XtraBars.BarButtonItem btnViewSymbolLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuViewLog;
        private DevExpress.XtraBars.BarButtonItem btnViewCycleLog;
        private UDM.Project.UCGroupTree ucGroupTree;
        private UDM.Project.UCProjectManager ucProjectManager;
        private DevExpress.XtraBars.Docking.DockPanel dpnlSystemLog;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlSystemLogContainer;
        private UDM.Project.UCSystemLogTable ucSystemLogTable;
        private DevExpress.XtraBars.BarStaticItem lblMonitorCountLabel;
        private DevExpress.XtraBars.BarStaticItem lblMonitorCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rcmbOPCServer;
        private DevExpress.XtraBars.BarButtonItem btnImportLogic;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuImportExport;
        private DevExpress.XtraBars.BarButtonItem btnViewLogicDiagram;
		private DevExpress.XtraBars.BarButtonItem btnMaximized;
        private DevExpress.XtraBars.BarCheckItem chkMonitorDetection;
        private DevExpress.XtraBars.BarCheckItem chkMonitorPatternItem;
        private DevExpress.XtraBars.BarCheckItem chkMonitorMasterPattern;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuViewStatistics;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarButtonItem btnViewProcessTimeChart;
        private DevExpress.XtraBars.BarButtonItem btnViewStatisticsTable;
        private DevExpress.XtraBars.BarEditItem txtAddressFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraBars.BarEditItem txtDescriptionFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDescriptionFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuFilter;
        private DevExpress.XtraBars.BarButtonItem btnApplyFilter;
		private DevExpress.XtraBars.BarCheckItem chkViewDashBoard;
        private DevExpress.XtraBars.BarCheckItem chkLsPlc;
        private DevExpress.XtraBars.BarCheckItem chkMelsecPlc;
        private DevExpress.XtraBars.BarCheckItem chkSiemens;
        private DevExpress.XtraBars.BarCheckItem chkAbPlc;
        private DevExpress.XtraBars.BarCheckItem chkDDEA;
        private DevExpress.XtraBars.BarCheckItem chkOPC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPlcMaker;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorMode;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorExportLog;
        private DevExpress.XtraEditors.GroupControl grpMonitorRunView;
        private DevExpress.XtraEditors.SplitContainerControl sptMain;
        private UDM.Project.UCGroupCycleBoardS ucGroupCycleBoardS;
        private DevExpress.XtraGrid.GridControl grdTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTag;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraBars.BarButtonItem btnViewMonitorErrorLog;
    }
}