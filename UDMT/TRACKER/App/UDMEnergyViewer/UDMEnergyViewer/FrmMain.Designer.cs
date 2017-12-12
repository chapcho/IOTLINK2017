namespace UDMEnergyViewer
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
            this.exScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::UDMEnergyViewer.FrmWaitForm), true, true);
            this.exRibbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imgListRibbon = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.exSkinGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnMonitorStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonitorStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportLogic = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportTag = new DevExpress.XtraBars.BarButtonItem();
            this.mnuImportTag = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnExportTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnApplyPlcConfig = new DevExpress.XtraBars.BarButtonItem();
            this.txtPlcIP = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPlcIP = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtPlcPort = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPlcPort = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cmbPlcSourceType = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPlcSourceType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnApplyLogConfig = new DevExpress.XtraBars.BarButtonItem();
            this.spnPlcInterval = new DevExpress.XtraBars.BarEditItem();
            this.exEditorPlcInterval = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.txtLogPath = new DevExpress.XtraBars.BarEditItem();
            this.exEditorLogPath = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnShowChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPlcLog = new DevExpress.XtraBars.BarButtonItem();
            this.mnuPlcLog = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnClearPLCLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddMeterLog = new DevExpress.XtraBars.BarButtonItem();
            this.mnuMeterLog = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnClearMeterLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnPlcTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenLogFolder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.txtEnergyIP = new DevExpress.XtraBars.BarEditItem();
            this.exEditorEnergyIP = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtEnergyPort = new DevExpress.XtraBars.BarEditItem();
            this.exEditorEnergyPort = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.spnEnergyChannelS = new DevExpress.XtraBars.BarEditItem();
            this.exEditorEnergyInterval = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnClassifyCoil = new DevExpress.XtraBars.BarButtonItem();
            this.btnEnergyAnalysis = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalibration = new DevExpress.XtraBars.BarButtonItem();
            this.btnRegressionUnitView = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitorControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuOpenLogFolder = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.munExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuModel = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuTag = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuPLCInterface = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuLogging = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuChart = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.pnlTagTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlTagTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucTagTable = new UDMEnergyViewer.UCTagTable();
            this.pnlMonitorStatus = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlMonitorStatusContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucClock = new UDMEnergyViewer.UCClock();
            this.ucMonitorLight = new UDMEnergyViewer.UCMonitorStatus();
            this.pnlSymbolTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlSymbolTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSymbolTable = new UDMEnergyViewer.UCSymbolTable();
            this.pnlLogTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlLogTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucLogTable = new UDMEnergyViewer.UCSystemLogTable();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuImportTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcSourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLogPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPlcLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMeterLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.pnlTagTable.SuspendLayout();
            this.pnlTagTableContainer.SuspendLayout();
            this.pnlMonitorStatus.SuspendLayout();
            this.pnlMonitorStatusContainer.SuspendLayout();
            this.pnlSymbolTable.SuspendLayout();
            this.pnlSymbolTableContainer.SuspendLayout();
            this.pnlLogTable.SuspendLayout();
            this.pnlLogTableContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // exScreenManager
            // 
            this.exScreenManager.ClosingDelay = 500;
            // 
            // exRibbonMenu
            // 
            this.exRibbonMenu.ExpandCollapseItem.Id = 0;
            this.exRibbonMenu.Images = this.imgListRibbon;
            this.exRibbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonMenu.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.exSkinGallery,
            this.btnMonitorStart,
            this.btnMonitorStop,
            this.btnImportLogic,
            this.btnImportTag,
            this.btnApplyPlcConfig,
            this.txtPlcIP,
            this.txtPlcPort,
            this.cmbPlcSourceType,
            this.btnApplyLogConfig,
            this.spnPlcInterval,
            this.txtLogPath,
            this.btnShowChart,
            this.btnAddPlcLog,
            this.btnAddMeterLog,
            this.btnPlcTest,
            this.btnOpenLogFolder,
            this.barButtonItem1,
            this.btnExit,
            this.btnClearPLCLog,
            this.btnClearMeterLog,
            this.btnExportTag,
            this.txtEnergyIP,
            this.txtEnergyPort,
            this.spnEnergyChannelS,
            this.btnClassifyCoil,
            this.btnEnergyAnalysis,
            this.btnCalibration,
            this.btnRegressionUnitView});
            this.exRibbonMenu.LargeImages = this.imgListRibbonLarge;
            this.exRibbonMenu.Location = new System.Drawing.Point(0, 0);
            this.exRibbonMenu.MaxItemId = 37;
            this.exRibbonMenu.Name = "exRibbonMenu";
            this.exRibbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome,
            this.mnuModel,
            this.mnuView});
            this.exRibbonMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorPlcIP,
            this.exEditorPlcPort,
            this.exEditorPlcSourceType,
            this.exEditorPlcInterval,
            this.exEditorLogPath,
            this.exEditorEnergyIP,
            this.exEditorEnergyPort,
            this.exEditorEnergyInterval});
            this.exRibbonMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonMenu.Size = new System.Drawing.Size(1056, 147);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnSave);
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
            // exSkinGallery
            // 
            this.exSkinGallery.Caption = "skinRibbonGalleryBarItem1";
            this.exSkinGallery.Id = 4;
            this.exSkinGallery.Name = "exSkinGallery";
            // 
            // btnMonitorStart
            // 
            this.btnMonitorStart.Caption = "Start";
            this.btnMonitorStart.Id = 5;
            this.btnMonitorStart.LargeImageIndex = 9;
            this.btnMonitorStart.Name = "btnMonitorStart";
            this.btnMonitorStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonitorStart_ItemClick);
            // 
            // btnMonitorStop
            // 
            this.btnMonitorStop.Caption = "Stop";
            this.btnMonitorStop.Id = 6;
            this.btnMonitorStop.LargeImageIndex = 10;
            this.btnMonitorStop.Name = "btnMonitorStop";
            this.btnMonitorStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonitorStop_ItemClick);
            // 
            // btnImportLogic
            // 
            this.btnImportLogic.Caption = "Import Logic";
            this.btnImportLogic.Id = 7;
            this.btnImportLogic.LargeImageIndex = 17;
            this.btnImportLogic.Name = "btnImportLogic";
            this.btnImportLogic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportLogic_ItemClick);
            // 
            // btnImportTag
            // 
            this.btnImportTag.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnImportTag.Caption = "Import Tag";
            this.btnImportTag.DropDownControl = this.mnuImportTag;
            this.btnImportTag.Id = 8;
            this.btnImportTag.LargeImageIndex = 21;
            this.btnImportTag.Name = "btnImportTag";
            this.btnImportTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportTag_ItemClick);
            // 
            // mnuImportTag
            // 
            this.mnuImportTag.ItemLinks.Add(this.btnExportTag);
            this.mnuImportTag.Name = "mnuImportTag";
            this.mnuImportTag.Ribbon = this.exRibbonMenu;
            // 
            // btnExportTag
            // 
            this.btnExportTag.Caption = "Export Tag";
            this.btnExportTag.Id = 29;
            this.btnExportTag.Name = "btnExportTag";
            this.btnExportTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportTag_ItemClick);
            // 
            // btnApplyPlcConfig
            // 
            this.btnApplyPlcConfig.Caption = "Apply";
            this.btnApplyPlcConfig.Id = 9;
            this.btnApplyPlcConfig.LargeImageIndex = 30;
            this.btnApplyPlcConfig.Name = "btnApplyPlcConfig";
            this.btnApplyPlcConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApplyPlcConfig_ItemClick);
            // 
            // txtPlcIP
            // 
            this.txtPlcIP.Caption = "IP/Port ";
            this.txtPlcIP.Edit = this.exEditorPlcIP;
            this.txtPlcIP.EditValue = "";
            this.txtPlcIP.Id = 11;
            this.txtPlcIP.Name = "txtPlcIP";
            this.txtPlcIP.Width = 100;
            // 
            // exEditorPlcIP
            // 
            this.exEditorPlcIP.Appearance.Options.UseTextOptions = true;
            this.exEditorPlcIP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorPlcIP.AutoHeight = false;
            this.exEditorPlcIP.Mask.EditMask = "([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\\.([0-9]|[1-9][0-9]|1[0-9][0-9" +
    "]|2[0-4][0-9]|25[0-5])){3}";
            this.exEditorPlcIP.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.exEditorPlcIP.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorPlcIP.Name = "exEditorPlcIP";
            // 
            // txtPlcPort
            // 
            this.txtPlcPort.Edit = this.exEditorPlcPort;
            this.txtPlcPort.EditValue = "";
            this.txtPlcPort.Id = 13;
            this.txtPlcPort.Name = "txtPlcPort";
            // 
            // exEditorPlcPort
            // 
            this.exEditorPlcPort.Appearance.Options.UseTextOptions = true;
            this.exEditorPlcPort.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorPlcPort.AutoHeight = false;
            this.exEditorPlcPort.Name = "exEditorPlcPort";
            // 
            // cmbPlcSourceType
            // 
            this.cmbPlcSourceType.Caption = "Type    ";
            this.cmbPlcSourceType.Edit = this.exEditorPlcSourceType;
            this.cmbPlcSourceType.Id = 14;
            this.cmbPlcSourceType.Name = "cmbPlcSourceType";
            this.cmbPlcSourceType.Width = 100;
            this.cmbPlcSourceType.EditValueChanged += new System.EventHandler(this.cmbPlcSourceType_EditValueChanged);
            // 
            // exEditorPlcSourceType
            // 
            this.exEditorPlcSourceType.Appearance.Options.UseTextOptions = true;
            this.exEditorPlcSourceType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorPlcSourceType.AutoHeight = false;
            this.exEditorPlcSourceType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPlcSourceType.Items.AddRange(new object[] {
            "USB",
            "Ethernet"});
            this.exEditorPlcSourceType.Name = "exEditorPlcSourceType";
            // 
            // btnApplyLogConfig
            // 
            this.btnApplyLogConfig.Caption = "Apply";
            this.btnApplyLogConfig.Id = 15;
            this.btnApplyLogConfig.LargeImageIndex = 11;
            this.btnApplyLogConfig.Name = "btnApplyLogConfig";
            this.btnApplyLogConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApplyLogConfig_ItemClick);
            // 
            // spnPlcInterval
            // 
            this.spnPlcInterval.Edit = this.exEditorPlcInterval;
            this.spnPlcInterval.EditValue = 1;
            this.spnPlcInterval.Id = 17;
            this.spnPlcInterval.Name = "spnPlcInterval";
            // 
            // exEditorPlcInterval
            // 
            this.exEditorPlcInterval.AutoHeight = false;
            this.exEditorPlcInterval.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorPlcInterval.Name = "exEditorPlcInterval";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Caption = "Path ";
            this.txtLogPath.Edit = this.exEditorLogPath;
            this.txtLogPath.Id = 18;
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Width = 150;
            // 
            // exEditorLogPath
            // 
            this.exEditorLogPath.AutoHeight = false;
            this.exEditorLogPath.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorLogPath.Name = "exEditorLogPath";
            // 
            // btnShowChart
            // 
            this.btnShowChart.Caption = "Show Chart";
            this.btnShowChart.Id = 19;
            this.btnShowChart.LargeImageIndex = 25;
            this.btnShowChart.Name = "btnShowChart";
            this.btnShowChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowChart_ItemClick);
            // 
            // btnAddPlcLog
            // 
            this.btnAddPlcLog.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnAddPlcLog.Caption = "Add PLC Log";
            this.btnAddPlcLog.DropDownControl = this.mnuPlcLog;
            this.btnAddPlcLog.Id = 20;
            this.btnAddPlcLog.LargeImageIndex = 35;
            this.btnAddPlcLog.Name = "btnAddPlcLog";
            this.btnAddPlcLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPlcLog_ItemClick);
            // 
            // mnuPlcLog
            // 
            this.mnuPlcLog.ItemLinks.Add(this.btnClearPLCLog);
            this.mnuPlcLog.Name = "mnuPlcLog";
            this.mnuPlcLog.Ribbon = this.exRibbonMenu;
            // 
            // btnClearPLCLog
            // 
            this.btnClearPLCLog.Caption = "Clear";
            this.btnClearPLCLog.Id = 27;
            this.btnClearPLCLog.Name = "btnClearPLCLog";
            this.btnClearPLCLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearPlcLog_ItemClick);
            // 
            // btnAddMeterLog
            // 
            this.btnAddMeterLog.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnAddMeterLog.Caption = "Add Meter Log";
            this.btnAddMeterLog.DropDownControl = this.mnuMeterLog;
            this.btnAddMeterLog.Id = 21;
            this.btnAddMeterLog.LargeImageIndex = 36;
            this.btnAddMeterLog.Name = "btnAddMeterLog";
            this.btnAddMeterLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddMeterLog_ItemClick);
            // 
            // mnuMeterLog
            // 
            this.mnuMeterLog.ItemLinks.Add(this.btnClearMeterLog);
            this.mnuMeterLog.Name = "mnuMeterLog";
            this.mnuMeterLog.Ribbon = this.exRibbonMenu;
            // 
            // btnClearMeterLog
            // 
            this.btnClearMeterLog.Caption = "Clear";
            this.btnClearMeterLog.Id = 28;
            this.btnClearMeterLog.Name = "btnClearMeterLog";
            this.btnClearMeterLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearMeterLog_ItemClick);
            // 
            // btnPlcTest
            // 
            this.btnPlcTest.Caption = "Test";
            this.btnPlcTest.Id = 23;
            this.btnPlcTest.LargeImageIndex = 14;
            this.btnPlcTest.Name = "btnPlcTest";
            this.btnPlcTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPlcTest_ItemClick);
            // 
            // btnOpenLogFolder
            // 
            this.btnOpenLogFolder.Caption = "Open Log Folder";
            this.btnOpenLogFolder.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenLogFolder.Id = 24;
            this.btnOpenLogFolder.LargeImageIndex = 2;
            this.btnOpenLogFolder.Name = "btnOpenLogFolder";
            this.btnOpenLogFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenLogFolder_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem1.Id = 25;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExit.Id = 26;
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // txtEnergyIP
            // 
            this.txtEnergyIP.Caption = "TCP/IP       ";
            this.txtEnergyIP.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtEnergyIP.Edit = this.exEditorEnergyIP;
            this.txtEnergyIP.Id = 30;
            this.txtEnergyIP.Name = "txtEnergyIP";
            this.txtEnergyIP.Width = 110;
            // 
            // exEditorEnergyIP
            // 
            this.exEditorEnergyIP.AutoHeight = false;
            this.exEditorEnergyIP.Name = "exEditorEnergyIP";
            // 
            // txtEnergyPort
            // 
            this.txtEnergyPort.Caption = "Port/Channel ";
            this.txtEnergyPort.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtEnergyPort.Edit = this.exEditorEnergyPort;
            this.txtEnergyPort.Id = 31;
            this.txtEnergyPort.Name = "txtEnergyPort";
            // 
            // exEditorEnergyPort
            // 
            this.exEditorEnergyPort.AutoHeight = false;
            this.exEditorEnergyPort.Name = "exEditorEnergyPort";
            // 
            // spnEnergyChannelS
            // 
            this.spnEnergyChannelS.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.spnEnergyChannelS.Edit = this.exEditorEnergyInterval;
            this.spnEnergyChannelS.Id = 32;
            this.spnEnergyChannelS.Name = "spnEnergyChannelS";
            // 
            // exEditorEnergyInterval
            // 
            this.exEditorEnergyInterval.AutoHeight = false;
            this.exEditorEnergyInterval.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorEnergyInterval.Name = "exEditorEnergyInterval";
            // 
            // btnClassifyCoil
            // 
            this.btnClassifyCoil.Caption = "Unit Tag Classification";
            this.btnClassifyCoil.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnClassifyCoil.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClassifyCoil.Glyph")));
            this.btnClassifyCoil.Id = 33;
            this.btnClassifyCoil.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClassifyCoil.LargeGlyph")));
            this.btnClassifyCoil.Name = "btnClassifyCoil";
            this.btnClassifyCoil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClassifyCoil_ItemClick);
            // 
            // btnEnergyAnalysis
            // 
            this.btnEnergyAnalysis.Caption = "Energy Analysis";
            this.btnEnergyAnalysis.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnEnergyAnalysis.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEnergyAnalysis.Glyph")));
            this.btnEnergyAnalysis.Id = 34;
            this.btnEnergyAnalysis.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEnergyAnalysis.LargeGlyph")));
            this.btnEnergyAnalysis.Name = "btnEnergyAnalysis";
            this.btnEnergyAnalysis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEnergyAnalysis_ItemClick);
            // 
            // btnCalibration
            // 
            this.btnCalibration.Caption = "Data Calibration";
            this.btnCalibration.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCalibration.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCalibration.Glyph")));
            this.btnCalibration.Id = 35;
            this.btnCalibration.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCalibration.LargeGlyph")));
            this.btnCalibration.Name = "btnCalibration";
            this.btnCalibration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCalibration_ItemClick);
            // 
            // btnRegressionUnitView
            // 
            this.btnRegressionUnitView.Caption = "Regression Unit View";
            this.btnRegressionUnitView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnRegressionUnitView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRegressionUnitView.Glyph")));
            this.btnRegressionUnitView.Id = 36;
            this.btnRegressionUnitView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRegressionUnitView.LargeGlyph")));
            this.btnRegressionUnitView.Name = "btnRegressionUnitView";
            this.btnRegressionUnitView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegressionUnitView_ItemClick);
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
            this.imgListRibbonLarge.Images.SetKeyName(35, "AddFile_32x32_PLC.png");
            this.imgListRibbonLarge.Images.SetKeyName(36, "AddItem_32x32_Meter.png");
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuProject,
            this.mnuSkins,
            this.mnuMonitorControl,
            this.mnuOpenLogFolder,
            this.munExit});
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Text = "Home";
            // 
            // mnuProject
            // 
            this.mnuProject.ItemLinks.Add(this.btnNew);
            this.mnuProject.ItemLinks.Add(this.btnOpen);
            this.mnuProject.ItemLinks.Add(this.btnSave);
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Text = "Project";
            // 
            // mnuSkins
            // 
            this.mnuSkins.ItemLinks.Add(this.exSkinGallery);
            this.mnuSkins.Name = "mnuSkins";
            this.mnuSkins.Text = "Skins";
            // 
            // mnuMonitorControl
            // 
            this.mnuMonitorControl.ItemLinks.Add(this.btnMonitorStart);
            this.mnuMonitorControl.ItemLinks.Add(this.btnMonitorStop);
            this.mnuMonitorControl.Name = "mnuMonitorControl";
            this.mnuMonitorControl.Text = "Monitor";
            // 
            // mnuOpenLogFolder
            // 
            this.mnuOpenLogFolder.ItemLinks.Add(this.btnOpenLogFolder);
            this.mnuOpenLogFolder.Name = "mnuOpenLogFolder";
            this.mnuOpenLogFolder.Text = "Log";
            // 
            // munExit
            // 
            this.munExit.ItemLinks.Add(this.btnExit);
            this.munExit.Name = "munExit";
            this.munExit.Text = "Exit";
            // 
            // mnuModel
            // 
            this.mnuModel.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuTag,
            this.mnuPLCInterface,
            this.mnuLogging});
            this.mnuModel.Name = "mnuModel";
            this.mnuModel.Text = "Model";
            // 
            // mnuTag
            // 
            this.mnuTag.ItemLinks.Add(this.btnImportLogic);
            this.mnuTag.ItemLinks.Add(this.btnImportTag);
            this.mnuTag.Name = "mnuTag";
            this.mnuTag.Text = "Tag";
            // 
            // mnuPLCInterface
            // 
            this.mnuPLCInterface.ItemLinks.Add(this.btnApplyPlcConfig);
            this.mnuPLCInterface.ItemLinks.Add(this.cmbPlcSourceType, true, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.spnPlcInterval, false, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.txtPlcIP, false, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.txtPlcPort, false, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.txtEnergyIP, true, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.txtEnergyPort, false, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.spnEnergyChannelS, false, "", "", true);
            this.mnuPLCInterface.ItemLinks.Add(this.btnPlcTest, true);
            this.mnuPLCInterface.Name = "mnuPLCInterface";
            this.mnuPLCInterface.Text = "PLC/Energy Interface";
            // 
            // mnuLogging
            // 
            this.mnuLogging.ItemLinks.Add(this.btnApplyLogConfig);
            this.mnuLogging.ItemLinks.Add(this.txtLogPath);
            this.mnuLogging.Name = "mnuLogging";
            this.mnuLogging.Text = "Data Logging";
            // 
            // mnuView
            // 
            this.mnuView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuChart});
            this.mnuView.Name = "mnuView";
            this.mnuView.Text = "View";
            // 
            // mnuChart
            // 
            this.mnuChart.ItemLinks.Add(this.btnAddPlcLog);
            this.mnuChart.ItemLinks.Add(this.btnAddMeterLog);
            this.mnuChart.ItemLinks.Add(this.btnCalibration);
            this.mnuChart.ItemLinks.Add(this.btnClassifyCoil);
            this.mnuChart.ItemLinks.Add(this.btnShowChart, true);
            this.mnuChart.ItemLinks.Add(this.btnEnergyAnalysis);
            this.mnuChart.ItemLinks.Add(this.btnRegressionUnitView);
            this.mnuChart.Name = "mnuChart";
            this.mnuChart.Text = "Chart";
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.pnlTagTable,
            this.pnlMonitorStatus,
            this.pnlSymbolTable,
            this.pnlLogTable});
            this.exDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // pnlTagTable
            // 
            this.pnlTagTable.Controls.Add(this.pnlTagTableContainer);
            this.pnlTagTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnlTagTable.ID = new System.Guid("d9bdd206-3fdd-4dd3-b89a-a13e4058db75");
            this.pnlTagTable.Location = new System.Drawing.Point(0, 147);
            this.pnlTagTable.Name = "pnlTagTable";
            this.pnlTagTable.OriginalSize = new System.Drawing.Size(266, 200);
            this.pnlTagTable.Size = new System.Drawing.Size(266, 489);
            this.pnlTagTable.Text = "Tag Table";
            // 
            // pnlTagTableContainer
            // 
            this.pnlTagTableContainer.Controls.Add(this.ucTagTable);
            this.pnlTagTableContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlTagTableContainer.Name = "pnlTagTableContainer";
            this.pnlTagTableContainer.Size = new System.Drawing.Size(258, 462);
            this.pnlTagTableContainer.TabIndex = 0;
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTagTable.Editable = true;
            this.ucTagTable.Location = new System.Drawing.Point(0, 0);
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.Size = new System.Drawing.Size(258, 462);
            this.ucTagTable.TabIndex = 0;
            // 
            // pnlMonitorStatus
            // 
            this.pnlMonitorStatus.Controls.Add(this.pnlMonitorStatusContainer);
            this.pnlMonitorStatus.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.pnlMonitorStatus.ID = new System.Guid("1f696577-99af-4ddc-ad48-a68e26f63c58");
            this.pnlMonitorStatus.Location = new System.Drawing.Point(777, 147);
            this.pnlMonitorStatus.Name = "pnlMonitorStatus";
            this.pnlMonitorStatus.OriginalSize = new System.Drawing.Size(279, 200);
            this.pnlMonitorStatus.Size = new System.Drawing.Size(279, 489);
            this.pnlMonitorStatus.Text = "Monitor Status";
            // 
            // pnlMonitorStatusContainer
            // 
            this.pnlMonitorStatusContainer.Controls.Add(this.ucClock);
            this.pnlMonitorStatusContainer.Controls.Add(this.ucMonitorLight);
            this.pnlMonitorStatusContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlMonitorStatusContainer.Name = "pnlMonitorStatusContainer";
            this.pnlMonitorStatusContainer.Size = new System.Drawing.Size(271, 462);
            this.pnlMonitorStatusContainer.TabIndex = 0;
            // 
            // ucClock
            // 
            this.ucClock.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucClock.Location = new System.Drawing.Point(0, 75);
            this.ucClock.Name = "ucClock";
            this.ucClock.Padding = new System.Windows.Forms.Padding(5);
            this.ucClock.Size = new System.Drawing.Size(271, 68);
            this.ucClock.TabIndex = 1;
            // 
            // ucMonitorLight
            // 
            this.ucMonitorLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucMonitorLight.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMonitorLight.Location = new System.Drawing.Point(0, 0);
            this.ucMonitorLight.Name = "ucMonitorLight";
            this.ucMonitorLight.Padding = new System.Windows.Forms.Padding(5);
            this.ucMonitorLight.Size = new System.Drawing.Size(271, 75);
            this.ucMonitorLight.TabIndex = 0;
            // 
            // pnlSymbolTable
            // 
            this.pnlSymbolTable.Controls.Add(this.pnlSymbolTableContainer);
            this.pnlSymbolTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.pnlSymbolTable.ID = new System.Guid("c7eccc90-f9b2-45a0-b1d5-1635b4dca9c9");
            this.pnlSymbolTable.Location = new System.Drawing.Point(266, 147);
            this.pnlSymbolTable.Name = "pnlSymbolTable";
            this.pnlSymbolTable.OriginalSize = new System.Drawing.Size(200, 275);
            this.pnlSymbolTable.Size = new System.Drawing.Size(511, 275);
            this.pnlSymbolTable.Text = "수집 대상 Symbol Table";
            // 
            // pnlSymbolTableContainer
            // 
            this.pnlSymbolTableContainer.Controls.Add(this.ucSymbolTable);
            this.pnlSymbolTableContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlSymbolTableContainer.Name = "pnlSymbolTableContainer";
            this.pnlSymbolTableContainer.Size = new System.Drawing.Size(503, 248);
            this.pnlSymbolTableContainer.TabIndex = 0;
            // 
            // B
            // 
            this.ucSymbolTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSymbolTable.Editable = true;
            this.ucSymbolTable.Location = new System.Drawing.Point(0, 0);
            this.ucSymbolTable.Name = "B";
            this.ucSymbolTable.Size = new System.Drawing.Size(503, 248);
            this.ucSymbolTable.TabIndex = 0;
            this.ucSymbolTable.UserAddSymbolList = ((System.Collections.Generic.List<string>)(resources.GetObject("B.UserAddSymbolList")));
            // 
            // pnlLogTable
            // 
            this.pnlLogTable.Controls.Add(this.pnlLogTableContainer);
            this.pnlLogTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.pnlLogTable.ID = new System.Guid("3b8fd646-010a-49f6-8d3e-9a5acc61dfc2");
            this.pnlLogTable.Location = new System.Drawing.Point(266, 436);
            this.pnlLogTable.Name = "pnlLogTable";
            this.pnlLogTable.OriginalSize = new System.Drawing.Size(200, 200);
            this.pnlLogTable.Size = new System.Drawing.Size(511, 200);
            this.pnlLogTable.Text = "System Log Table";
            // 
            // pnlLogTableContainer
            // 
            this.pnlLogTableContainer.Controls.Add(this.ucLogTable);
            this.pnlLogTableContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlLogTableContainer.Name = "pnlLogTableContainer";
            this.pnlLogTableContainer.Size = new System.Drawing.Size(503, 173);
            this.pnlLogTableContainer.TabIndex = 0;
            // 
            // ucLogTable
            // 
            this.ucLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucLogTable.Name = "ucLogTable";
            this.ucLogTable.Size = new System.Drawing.Size(503, 173);
            this.ucLogTable.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 636);
            this.Controls.Add(this.pnlLogTable);
            this.Controls.Add(this.pnlSymbolTable);
            this.Controls.Add(this.pnlMonitorStatus);
            this.Controls.Add(this.pnlTagTable);
            this.Controls.Add(this.exRibbonMenu);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonMenu;
            this.Text = "UDM Energy Viewer";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuImportTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcSourceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorPlcInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorLogPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPlcLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMeterLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnergyInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.pnlTagTable.ResumeLayout(false);
            this.pnlTagTableContainer.ResumeLayout(false);
            this.pnlMonitorStatus.ResumeLayout(false);
            this.pnlMonitorStatusContainer.ResumeLayout(false);
            this.pnlSymbolTable.ResumeLayout(false);
            this.pnlSymbolTableContainer.ResumeLayout(false);
            this.pnlLogTable.ResumeLayout(false);
            this.pnlLogTableContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonMenu;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuProject;
		private DevExpress.Utils.ImageCollection imgListRibbon;
		private DevExpress.Utils.ImageCollection imgListRibbonLarge;
		private DevExpress.XtraBars.Docking.DockManager exDockManager;
		private DevExpress.XtraBars.BarButtonItem btnNew;
		private DevExpress.XtraBars.BarButtonItem btnOpen;
		private DevExpress.XtraBars.BarButtonItem btnSave;
		private DevExpress.XtraBars.Docking.DockPanel pnlTagTable;
		private DevExpress.XtraBars.Docking.ControlContainer pnlTagTableContainer;
		private UCTagTable ucTagTable;
		private DevExpress.XtraBars.Docking.DockPanel pnlMonitorStatus;
		private DevExpress.XtraBars.Docking.ControlContainer pnlMonitorStatusContainer;
		private UCClock ucClock;
		private UCMonitorStatus ucMonitorLight;
		private DevExpress.XtraBars.Docking.DockPanel pnlSymbolTable;
		private DevExpress.XtraBars.Docking.ControlContainer pnlSymbolTableContainer;
		private UCSymbolTable ucSymbolTable;
		private DevExpress.XtraBars.Docking.DockPanel pnlLogTable;
		private DevExpress.XtraBars.Docking.ControlContainer pnlLogTableContainer;
		private UCSystemLogTable ucLogTable;
		private DevExpress.XtraBars.SkinRibbonGalleryBarItem exSkinGallery;
		private DevExpress.XtraBars.BarButtonItem btnMonitorStart;
		private DevExpress.XtraBars.BarButtonItem btnMonitorStop;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkins;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitorControl;
		private DevExpress.XtraSplashScreen.SplashScreenManager exScreenManager;
		private DevExpress.XtraBars.BarButtonItem btnImportLogic;
		private DevExpress.XtraBars.BarButtonItem btnImportTag;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuModel;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuTag;
		private DevExpress.XtraBars.BarButtonItem btnApplyPlcConfig;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPLCInterface;
		private DevExpress.XtraBars.BarEditItem txtPlcIP;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorPlcIP;
		private DevExpress.XtraBars.BarEditItem txtPlcPort;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorPlcPort;
		private DevExpress.XtraBars.BarEditItem cmbPlcSourceType;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPlcSourceType;
		private DevExpress.XtraBars.BarButtonItem btnApplyLogConfig;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuLogging;
		private DevExpress.XtraBars.BarEditItem spnPlcInterval;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorPlcInterval;		
		private DevExpress.XtraBars.BarEditItem txtLogPath;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorLogPath;
		private DevExpress.XtraBars.BarButtonItem btnShowChart;
		private DevExpress.XtraBars.BarButtonItem btnAddPlcLog;
		private DevExpress.XtraBars.BarButtonItem btnAddMeterLog;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuView;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuChart;
		private DevExpress.XtraBars.BarButtonItem btnPlcTest;
        private DevExpress.XtraBars.BarButtonItem btnOpenLogFolder;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuOpenLogFolder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup munExit;
        private DevExpress.XtraBars.BarButtonItem btnClearPLCLog;
        private DevExpress.XtraBars.PopupMenu mnuPlcLog;
        private DevExpress.XtraBars.PopupMenu mnuMeterLog;
        private DevExpress.XtraBars.BarButtonItem btnClearMeterLog;
        private DevExpress.XtraBars.BarButtonItem btnExportTag;
        private DevExpress.XtraBars.PopupMenu mnuImportTag;
        private DevExpress.XtraBars.BarEditItem txtEnergyIP;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorEnergyIP;
        private DevExpress.XtraBars.BarEditItem txtEnergyPort;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorEnergyPort;
        private DevExpress.XtraBars.BarEditItem spnEnergyChannelS;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorEnergyInterval;
        private DevExpress.XtraBars.BarButtonItem btnClassifyCoil;
        private DevExpress.XtraBars.BarButtonItem btnEnergyAnalysis;
        private DevExpress.XtraBars.BarButtonItem btnCalibration;
        private DevExpress.XtraBars.BarButtonItem btnRegressionUnitView;	
	}
}

