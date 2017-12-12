namespace UDMPresenter
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.exRibbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.exSkinGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnImportLogic = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportTagNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportLog = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportTagAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportTagForKepware = new DevExpress.XtraBars.BarButtonItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.cmbSettingList = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnSaveLogPath = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearAllTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnModel = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveProject = new DevExpress.XtraBars.BarButtonItem();
            this.txtScanTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnShowLogFolder = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfigEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectClear = new DevExpress.XtraBars.BarButtonItem();
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuPlcSetting = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuDDEAControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitor = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuSymbols = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.exRibbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.pnlSymbolState = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlProjectList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.radioGroupProjectList = new DevExpress.XtraEditors.RadioGroup();
            this.pnlTagTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlTagTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucTagTable = new UDMPresenter.UCTagTable();
            this.pnlSymbolTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.pnlSymbolTableContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tabCollectView = new DevExpress.XtraTab.XtraTabControl();
            this.tpRealTagView = new DevExpress.XtraTab.XtraTabPage();
            this.grdRunSymbolView = new DevExpress.XtraGrid.GridControl();
            this.grvRunSymbolView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCollectUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpTagList = new DevExpress.XtraTab.XtraTabPage();
            this.ucSymbolTable = new UDMPresenter.UCSymbolTable();
            this.exScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::UDMPresenter.FrmWaitForm), true, true);
            this.tmrDataRefresh = new System.Windows.Forms.Timer(this.components);
            this.tileNavCategory1 = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpSystemMessage = new DevExpress.XtraEditors.GroupControl();
            this.ucSystemMessage = new UDMPresenter.UCSystemLogTable();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.pnlSymbolState.SuspendLayout();
            this.panelContainer2.SuspendLayout();
            this.pnlProjectList.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupProjectList.Properties)).BeginInit();
            this.pnlTagTable.SuspendLayout();
            this.pnlTagTableContainer.SuspendLayout();
            this.pnlSymbolTable.SuspendLayout();
            this.pnlSymbolTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectView)).BeginInit();
            this.tabCollectView.SuspendLayout();
            this.tpRealTagView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRunSymbolView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRunSymbolView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tpTagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).BeginInit();
            this.grpSystemMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // exRibbonMenu
            // 
            this.exRibbonMenu.ExpandCollapseItem.Id = 0;
            this.exRibbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonMenu.ExpandCollapseItem,
            this.btnNew,
            this.btnSave,
            this.btnSaveAs,
            this.btnOpen,
            this.lblStatus,
            this.exSkinGallery,
            this.btnImportLogic,
            this.btnImportTagNew,
            this.btnExportTag,
            this.btnImportLog,
            this.btnShowChart,
            this.btnImportTagAdd,
            this.btnExportTagForKepware,
            this.btnStart,
            this.btnStop,
            this.cmbSettingList,
            this.btnSaveLogPath,
            this.btnAddTag,
            this.btnClearAllTag,
            this.btnModel,
            this.btnOpenTest,
            this.btnSaveTest,
            this.btnAddProject,
            this.btnRemoveProject,
            this.txtScanTime,
            this.btnShowLogFolder,
            this.btnConfigEdit,
            this.btnProjectClear});
            this.exRibbonMenu.Location = new System.Drawing.Point(0, 0);
            this.exRibbonMenu.MaxItemId = 43;
            this.exRibbonMenu.Name = "exRibbonMenu";
            this.exRibbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome,
            this.mnuMonitor,
            this.mnuView});
            this.exRibbonMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemRatingControl1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemTextEdit1});
            this.exRibbonMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exRibbonMenu.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.exRibbonMenu.Size = new System.Drawing.Size(1110, 147);
            this.exRibbonMenu.StatusBar = this.exRibbonStatusBar;
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnSave);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnSaveAs);
            this.exRibbonMenu.Click += new System.EventHandler(this.exRibbonMenu_Click);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Enabled = false;
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 2;
            this.btnSave.ImageIndex = 4;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.LargeImageIndex = 4;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "Save As...";
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Glyph")));
            this.btnSaveAs.Id = 3;
            this.btnSaveAs.ImageIndex = 5;
            this.btnSaveAs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.LargeGlyph")));
            this.btnSaveAs.LargeImageIndex = 5;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.Glyph")));
            this.btnOpen.Id = 4;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.LargeGlyph")));
            this.btnOpen.LargeImageIndex = 1;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 5;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // exSkinGallery
            // 
            this.exSkinGallery.Caption = "Skins";
            this.exSkinGallery.Id = 6;
            this.exSkinGallery.Name = "exSkinGallery";
            // 
            // btnImportLogic
            // 
            this.btnImportLogic.Caption = "Import Logic";
            this.btnImportLogic.Id = 7;
            this.btnImportLogic.LargeImageIndex = 7;
            this.btnImportLogic.Name = "btnImportLogic";
            this.btnImportLogic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportLogic_ItemClick);
            // 
            // btnImportTagNew
            // 
            this.btnImportTagNew.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnImportTagNew.Caption = "Import Tag (Clear)";
            this.btnImportTagNew.Id = 8;
            this.btnImportTagNew.LargeImageIndex = 21;
            this.btnImportTagNew.Name = "btnImportTagNew";
            this.btnImportTagNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportTagNew_ItemClick);
            // 
            // btnExportTag
            // 
            this.btnExportTag.Caption = "Export Tag";
            this.btnExportTag.Id = 9;
            this.btnExportTag.LargeImageIndex = 20;
            this.btnExportTag.Name = "btnExportTag";
            this.btnExportTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportTag_ItemClick);
            // 
            // btnImportLog
            // 
            this.btnImportLog.Caption = "Import Log";
            this.btnImportLog.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImportLog.Glyph")));
            this.btnImportLog.Id = 10;
            this.btnImportLog.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnImportLog.LargeGlyph")));
            this.btnImportLog.LargeImageIndex = 21;
            this.btnImportLog.Name = "btnImportLog";
            this.btnImportLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportLog_ItemClick);
            // 
            // btnShowChart
            // 
            this.btnShowChart.Caption = "Show Chart";
            this.btnShowChart.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowChart.Glyph")));
            this.btnShowChart.Id = 11;
            this.btnShowChart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowChart.LargeGlyph")));
            this.btnShowChart.LargeImageIndex = 25;
            this.btnShowChart.Name = "btnShowChart";
            this.btnShowChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowChart_ItemClick);
            // 
            // btnImportTagAdd
            // 
            this.btnImportTagAdd.Caption = "Import Tag (Add)";
            this.btnImportTagAdd.Id = 12;
            this.btnImportTagAdd.Name = "btnImportTagAdd";
            this.btnImportTagAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportTagAdd_ItemClick);
            // 
            // btnExportTagForKepware
            // 
            this.btnExportTagForKepware.Caption = "Import Tag(Add)";
            this.btnExportTagForKepware.Id = 13;
            this.btnExportTagForKepware.Name = "btnExportTagForKepware";
            // 
            // btnStart
            // 
            this.btnStart.Caption = "시작";
            this.btnStart.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStart.Id = 15;
            this.btnStart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStart.LargeGlyph")));
            this.btnStart.Name = "btnStart";
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "정지";
            this.btnStop.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStop.Enabled = false;
            this.btnStop.Id = 16;
            this.btnStop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStop.LargeGlyph")));
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // cmbSettingList
            // 
            this.cmbSettingList.Caption = "설정리스트";
            this.cmbSettingList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.cmbSettingList.Edit = this.repositoryItemComboBox1;
            this.cmbSettingList.Id = 18;
            this.cmbSettingList.Name = "cmbSettingList";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // btnSaveLogPath
            // 
            this.btnSaveLogPath.Caption = "Log\r\n저장경로";
            this.btnSaveLogPath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSaveLogPath.Id = 19;
            this.btnSaveLogPath.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveLogPath.LargeGlyph")));
            this.btnSaveLogPath.Name = "btnSaveLogPath";
            this.btnSaveLogPath.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveLogPath_ItemClick);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Caption = "Add Tag";
            this.btnAddTag.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddTag.Id = 21;
            this.btnAddTag.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddTag.LargeGlyph")));
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddTag_ItemClick);
            // 
            // btnClearAllTag
            // 
            this.btnClearAllTag.Caption = "Clear All Tag";
            this.btnClearAllTag.Id = 22;
            this.btnClearAllTag.Name = "btnClearAllTag";
            this.btnClearAllTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearAllTag_ItemClick);
            // 
            // btnModel
            // 
            this.btnModel.Caption = "수집 대상\r\n선별";
            this.btnModel.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnModel.Id = 30;
            this.btnModel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModel.LargeGlyph")));
            this.btnModel.Name = "btnModel";
            this.btnModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModel_ItemClick);
            // 
            // btnOpenTest
            // 
            this.btnOpenTest.Caption = "OpenTest";
            this.btnOpenTest.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenTest.Id = 31;
            this.btnOpenTest.Name = "btnOpenTest";
            this.btnOpenTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenTest_ItemClick);
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Caption = "SaveTest";
            this.btnSaveTest.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSaveTest.Id = 32;
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveTest_ItemClick);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Caption = "Add";
            this.btnAddProject.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddProject.Id = 33;
            this.btnAddProject.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddProject.LargeGlyph")));
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddProject_ItemClick);
            // 
            // btnRemoveProject
            // 
            this.btnRemoveProject.Caption = "Remove";
            this.btnRemoveProject.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnRemoveProject.Enabled = false;
            this.btnRemoveProject.Id = 34;
            this.btnRemoveProject.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveProject.LargeGlyph")));
            this.btnRemoveProject.Name = "btnRemoveProject";
            this.btnRemoveProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemoveProject_ItemClick);
            // 
            // txtScanTime
            // 
            this.txtScanTime.Caption = "Scan Time : ";
            this.txtScanTime.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtScanTime.Description = "통신 설정하면 받아 옴.";
            this.txtScanTime.Edit = this.repositoryItemTextEdit1;
            this.txtScanTime.EditValue = 0D;
            this.txtScanTime.Id = 36;
            this.txtScanTime.Name = "txtScanTime";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // btnShowLogFolder
            // 
            this.btnShowLogFolder.Caption = "Open Log\r\nFolder";
            this.btnShowLogFolder.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnShowLogFolder.Id = 37;
            this.btnShowLogFolder.ImageUri.Uri = "Up";
            this.btnShowLogFolder.Name = "btnShowLogFolder";
            this.btnShowLogFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowLogFolder_ItemClick);
            // 
            // btnConfigEdit
            // 
            this.btnConfigEdit.Caption = "통신 설정 수정";
            this.btnConfigEdit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnConfigEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConfigEdit.Glyph")));
            this.btnConfigEdit.Id = 40;
            this.btnConfigEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConfigEdit.LargeGlyph")));
            this.btnConfigEdit.Name = "btnConfigEdit";
            this.btnConfigEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConfigEdit_ItemClick);
            // 
            // btnProjectClear
            // 
            this.btnProjectClear.Caption = "All Clear";
            this.btnProjectClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProjectClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProjectClear.Glyph")));
            this.btnProjectClear.Id = 42;
            this.btnProjectClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProjectClear.LargeGlyph")));
            this.btnProjectClear.Name = "btnProjectClear";
            this.btnProjectClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectClear_ItemClick);
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuFile,
            this.mnuProject,
            this.mnuPlcSetting,
            this.mnuDDEAControl,
            this.mnuSkins});
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Text = "Home";
            // 
            // mnuFile
            // 
            this.mnuFile.ItemLinks.Add(this.btnOpen);
            this.mnuFile.ItemLinks.Add(this.btnSave);
            this.mnuFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "File";
            // 
            // mnuProject
            // 
            this.mnuProject.ItemLinks.Add(this.btnAddProject);
            this.mnuProject.ItemLinks.Add(this.btnRemoveProject);
            this.mnuProject.ItemLinks.Add(this.btnProjectClear);
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Text = "Project";
            // 
            // mnuPlcSetting
            // 
            this.mnuPlcSetting.Enabled = false;
            this.mnuPlcSetting.ItemLinks.Add(this.btnConfigEdit);
            this.mnuPlcSetting.ItemLinks.Add(this.btnShowLogFolder);
            this.mnuPlcSetting.Name = "mnuPlcSetting";
            this.mnuPlcSetting.Text = "Option";
            // 
            // mnuDDEAControl
            // 
            this.mnuDDEAControl.Enabled = false;
            this.mnuDDEAControl.ItemLinks.Add(this.btnStart, true);
            this.mnuDDEAControl.ItemLinks.Add(this.btnStop);
            this.mnuDDEAControl.Name = "mnuDDEAControl";
            this.mnuDDEAControl.Text = "수집기 제어";
            // 
            // mnuSkins
            // 
            this.mnuSkins.ItemLinks.Add(this.exSkinGallery);
            this.mnuSkins.Name = "mnuSkins";
            this.mnuSkins.Text = "Skins";
            // 
            // mnuMonitor
            // 
            this.mnuMonitor.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuSymbols});
            this.mnuMonitor.Name = "mnuMonitor";
            this.mnuMonitor.Text = "Model";
            // 
            // mnuSymbols
            // 
            this.mnuSymbols.Enabled = false;
            this.mnuSymbols.ItemLinks.Add(this.btnModel);
            this.mnuSymbols.Name = "mnuSymbols";
            this.mnuSymbols.Text = "Symbols";
            // 
            // mnuView
            // 
            this.mnuView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuLog});
            this.mnuView.Name = "mnuView";
            this.mnuView.Text = "View";
            // 
            // mnuLog
            // 
            this.mnuLog.Enabled = false;
            this.mnuLog.ItemLinks.Add(this.btnImportLog);
            this.mnuLog.ItemLinks.Add(this.btnShowChart);
            this.mnuLog.Name = "mnuLog";
            this.mnuLog.Text = "Log";
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            this.repositoryItemRatingControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "DDEA";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.Caption = "OPC";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // exRibbonStatusBar
            // 
            this.exRibbonStatusBar.ItemLinks.Add(this.lblStatus);
            this.exRibbonStatusBar.ItemLinks.Add(this.txtScanTime);
            this.exRibbonStatusBar.Location = new System.Drawing.Point(0, 736);
            this.exRibbonStatusBar.Name = "exRibbonStatusBar";
            this.exRibbonStatusBar.Ribbon = this.exRibbonMenu;
            this.exRibbonStatusBar.Size = new System.Drawing.Size(1110, 31);
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.pnlSymbolState});
            this.exDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer2});
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
            // pnlSymbolState
            // 
            this.pnlSymbolState.Controls.Add(this.controlContainer1);
            this.pnlSymbolState.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.pnlSymbolState.FloatLocation = new System.Drawing.Point(2581, 367);
            this.pnlSymbolState.FloatVertical = true;
            this.pnlSymbolState.ID = new System.Guid("e735c509-9d23-438e-a713-ad40ae19479d");
            this.pnlSymbolState.Location = new System.Drawing.Point(-32768, -32768);
            this.pnlSymbolState.Name = "pnlSymbolState";
            this.pnlSymbolState.OriginalSize = new System.Drawing.Size(482, 471);
            this.pnlSymbolState.SavedIndex = 0;
            this.pnlSymbolState.Size = new System.Drawing.Size(200, 200);
            this.pnlSymbolState.Text = "실시간 수집대상 표시 Table";
            this.pnlSymbolState.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(3, 22);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(194, 175);
            this.controlContainer1.TabIndex = 0;
            // 
            // panelContainer2
            // 
            this.panelContainer2.Controls.Add(this.pnlProjectList);
            this.panelContainer2.Controls.Add(this.pnlTagTable);
            this.panelContainer2.Controls.Add(this.pnlSymbolTable);
            this.panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.panelContainer2.FloatVertical = true;
            this.panelContainer2.ID = new System.Guid("4be8385e-f824-4972-9f10-e01c532a8712");
            this.panelContainer2.Location = new System.Drawing.Point(0, 147);
            this.panelContainer2.Name = "panelContainer2";
            this.panelContainer2.OriginalSize = new System.Drawing.Size(200, 526);
            this.panelContainer2.Size = new System.Drawing.Size(1110, 526);
            this.panelContainer2.Text = "panelContainer2";
            // 
            // pnlProjectList
            // 
            this.pnlProjectList.Controls.Add(this.dockPanel1_Container);
            this.pnlProjectList.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.pnlProjectList.ID = new System.Guid("d0656418-d77d-4525-b90a-86770661797c");
            this.pnlProjectList.Location = new System.Drawing.Point(0, 0);
            this.pnlProjectList.Name = "pnlProjectList";
            this.pnlProjectList.OriginalSize = new System.Drawing.Size(210, 526);
            this.pnlProjectList.Size = new System.Drawing.Size(210, 526);
            this.pnlProjectList.Text = "Project List";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.radioGroupProjectList);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(202, 499);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // radioGroupProjectList
            // 
            this.radioGroupProjectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupProjectList.Location = new System.Drawing.Point(0, 0);
            this.radioGroupProjectList.MenuManager = this.exRibbonMenu;
            this.radioGroupProjectList.Name = "radioGroupProjectList";
            this.radioGroupProjectList.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.radioGroupProjectList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupProjectList.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupProjectList.Properties.Appearance.Options.UseFont = true;
            this.radioGroupProjectList.Properties.Columns = 1;
            this.radioGroupProjectList.Size = new System.Drawing.Size(202, 499);
            this.radioGroupProjectList.TabIndex = 0;
            this.radioGroupProjectList.SelectedIndexChanged += new System.EventHandler(this.radioGroupProjectList_SelectedIndexChanged);
            // 
            // pnlTagTable
            // 
            this.pnlTagTable.Controls.Add(this.pnlTagTableContainer);
            this.pnlTagTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.pnlTagTable.FloatVertical = true;
            this.pnlTagTable.ID = new System.Guid("d831cdab-c075-466e-9b0d-05019a09fe8d");
            this.pnlTagTable.Location = new System.Drawing.Point(210, 0);
            this.pnlTagTable.Name = "pnlTagTable";
            this.pnlTagTable.OriginalSize = new System.Drawing.Size(410, 526);
            this.pnlTagTable.Size = new System.Drawing.Size(410, 526);
            this.pnlTagTable.Text = "Tag Table";
            this.pnlTagTable.ClosingPanel += new DevExpress.XtraBars.Docking.DockPanelCancelEventHandler(this.pnlTagTable_ClosingPanel);
            // 
            // pnlTagTableContainer
            // 
            this.pnlTagTableContainer.Controls.Add(this.ucTagTable);
            this.pnlTagTableContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlTagTableContainer.Name = "pnlTagTableContainer";
            this.pnlTagTableContainer.Size = new System.Drawing.Size(402, 499);
            this.pnlTagTableContainer.TabIndex = 0;
            // 
            // ucTagTable
            // 
            this.ucTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTagTable.Editable = false;
            this.ucTagTable.Location = new System.Drawing.Point(0, 0);
            this.ucTagTable.Name = "ucTagTable";
            this.ucTagTable.Size = new System.Drawing.Size(402, 499);
            this.ucTagTable.TabIndex = 0;
            // 
            // pnlSymbolTable
            // 
            this.pnlSymbolTable.Controls.Add(this.pnlSymbolTableContainer);
            this.pnlSymbolTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.pnlSymbolTable.FloatVertical = true;
            this.pnlSymbolTable.ID = new System.Guid("b58d6406-e653-4c28-9363-fd6f547d994f");
            this.pnlSymbolTable.Location = new System.Drawing.Point(620, 0);
            this.pnlSymbolTable.Name = "pnlSymbolTable";
            this.pnlSymbolTable.OriginalSize = new System.Drawing.Size(490, 526);
            this.pnlSymbolTable.Size = new System.Drawing.Size(490, 526);
            this.pnlSymbolTable.Text = "수집 접점 View";
            this.pnlSymbolTable.ClosingPanel += new DevExpress.XtraBars.Docking.DockPanelCancelEventHandler(this.pnlSymbolTable_ClosingPanel);
            // 
            // pnlSymbolTableContainer
            // 
            this.pnlSymbolTableContainer.Controls.Add(this.tabCollectView);
            this.pnlSymbolTableContainer.Location = new System.Drawing.Point(4, 23);
            this.pnlSymbolTableContainer.Name = "pnlSymbolTableContainer";
            this.pnlSymbolTableContainer.Size = new System.Drawing.Size(482, 499);
            this.pnlSymbolTableContainer.TabIndex = 0;
            // 
            // tabCollectView
            // 
            this.tabCollectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCollectView.Location = new System.Drawing.Point(0, 0);
            this.tabCollectView.Name = "tabCollectView";
            this.tabCollectView.SelectedTabPage = this.tpRealTagView;
            this.tabCollectView.Size = new System.Drawing.Size(482, 499);
            this.tabCollectView.TabIndex = 1;
            this.tabCollectView.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTagList,
            this.tpRealTagView});
            // 
            // tpRealTagView
            // 
            this.tpRealTagView.Controls.Add(this.grdRunSymbolView);
            this.tpRealTagView.Name = "tpRealTagView";
            this.tpRealTagView.Size = new System.Drawing.Size(476, 470);
            this.tpRealTagView.Text = "실시간 정보";
            // 
            // grdRunSymbolView
            // 
            this.grdRunSymbolView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRunSymbolView.Enabled = false;
            this.grdRunSymbolView.Location = new System.Drawing.Point(0, 0);
            this.grdRunSymbolView.MainView = this.grvRunSymbolView;
            this.grdRunSymbolView.Name = "grdRunSymbolView";
            this.grdRunSymbolView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdRunSymbolView.Size = new System.Drawing.Size(476, 470);
            this.grdRunSymbolView.TabIndex = 5;
            this.grdRunSymbolView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRunSymbolView,
            this.gridView2});
            // 
            // grvRunSymbolView
            // 
            this.grvRunSymbolView.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.grvRunSymbolView.Appearance.Row.Options.UseBackColor = true;
            this.grvRunSymbolView.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvRunSymbolView.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvRunSymbolView.ColumnPanelRowHeight = 35;
            this.grvRunSymbolView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDescription,
            this.colDataType,
            this.colCollectUse,
            this.colCurrentValue,
            this.colChangeCount});
            this.grvRunSymbolView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRunSymbolView.GridControl = this.grdRunSymbolView;
            this.grvRunSymbolView.IndicatorWidth = 50;
            this.grvRunSymbolView.Name = "grvRunSymbolView";
            this.grvRunSymbolView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRunSymbolView.OptionsDetail.AllowZoomDetail = false;
            this.grvRunSymbolView.OptionsDetail.EnableMasterViewMode = false;
            this.grvRunSymbolView.OptionsDetail.ShowDetailTabs = false;
            this.grvRunSymbolView.OptionsDetail.SmartDetailExpand = false;
            this.grvRunSymbolView.OptionsView.EnableAppearanceEvenRow = true;
            this.grvRunSymbolView.OptionsView.ShowAutoFilterRow = true;
            this.grvRunSymbolView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRunSymbolView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAddress, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvRunSymbolView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRunSymbolView_CustomDrawRowIndicator);
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
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDescription.Caption = "Note";
            this.colDescription.FieldName = "IndexNote";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 629;
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
            // colCollectUse
            // 
            this.colCollectUse.AppearanceCell.Options.UseTextOptions = true;
            this.colCollectUse.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCollectUse.AppearanceHeader.Options.UseTextOptions = true;
            this.colCollectUse.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCollectUse.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCollectUse.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCollectUse.Caption = "수집가능";
            this.colCollectUse.ColumnEdit = this.exEditorCheckBox;
            this.colCollectUse.FieldName = "CollectUse";
            this.colCollectUse.Name = "colCollectUse";
            this.colCollectUse.OptionsColumn.FixedWidth = true;
            this.colCollectUse.OptionsColumn.ReadOnly = true;
            this.colCollectUse.Visible = true;
            this.colCollectUse.VisibleIndex = 1;
            this.colCollectUse.Width = 40;
            // 
            // exEditorCheckBox
            // 
            this.exEditorCheckBox.AutoHeight = false;
            this.exEditorCheckBox.Name = "exEditorCheckBox";
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
            // gridView2
            // 
            this.gridView2.GridControl = this.grdRunSymbolView;
            this.gridView2.Name = "gridView2";
            // 
            // tpTagList
            // 
            this.tpTagList.Controls.Add(this.ucSymbolTable);
            this.tpTagList.Name = "tpTagList";
            this.tpTagList.Size = new System.Drawing.Size(476, 470);
            this.tpTagList.Text = "수집 접점 List";
            // 
            // ucSymbolTable
            // 
            this.ucSymbolTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSymbolTable.Editable = true;
            this.ucSymbolTable.Location = new System.Drawing.Point(0, 0);
            this.ucSymbolTable.Name = "ucSymbolTable";
            this.ucSymbolTable.Size = new System.Drawing.Size(476, 470);
            this.ucSymbolTable.TabIndex = 0;
            this.ucSymbolTable.UserAddSymbolList = ((System.Collections.Generic.List<string>)(resources.GetObject("ucSymbolTable.UserAddSymbolList")));
            this.ucSymbolTable.UEventSymbolAdded += new UDMPresenter.UEventHandlerSymbolTableSymbolAdded(this.ucSymbolTable_UEventSymbolAdded);
            this.ucSymbolTable.UEventSymbolRemoved += new UDMPresenter.UEventHandlerSymbolTableSymbolRemoved(this.ucSymbolTable_UEventSymbolRemoved);
            // 
            // exScreenManager
            // 
            this.exScreenManager.ClosingDelay = 500;
            // 
            // tmrDataRefresh
            // 
            this.tmrDataRefresh.Tick += new System.EventHandler(this.tmrDataRefresh_Tick);
            // 
            // tileNavCategory1
            // 
            this.tileNavCategory1.Name = "tileNavCategory1";
            this.tileNavCategory1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavCategory1.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavCategory1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavCategory1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // grpSystemMessage
            // 
            this.grpSystemMessage.Controls.Add(this.ucSystemMessage);
            this.grpSystemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSystemMessage.Location = new System.Drawing.Point(0, 673);
            this.grpSystemMessage.Name = "grpSystemMessage";
            this.grpSystemMessage.Size = new System.Drawing.Size(1110, 63);
            this.grpSystemMessage.TabIndex = 14;
            this.grpSystemMessage.Text = "System Message";
            // 
            // ucSystemMessage
            // 
            this.ucSystemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemMessage.Location = new System.Drawing.Point(2, 21);
            this.ucSystemMessage.Name = "ucSystemMessage";
            this.ucSystemMessage.Size = new System.Drawing.Size(1106, 40);
            this.ucSystemMessage.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 767);
            this.Controls.Add(this.grpSystemMessage);
            this.Controls.Add(this.panelContainer2);
            this.Controls.Add(this.exRibbonStatusBar);
            this.Controls.Add(this.exRibbonMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonMenu;
            this.StatusBar = this.exRibbonStatusBar;
            this.Text = "UDM Presenter V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.pnlSymbolState.ResumeLayout(false);
            this.panelContainer2.ResumeLayout(false);
            this.pnlProjectList.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupProjectList.Properties)).EndInit();
            this.pnlTagTable.ResumeLayout(false);
            this.pnlTagTableContainer.ResumeLayout(false);
            this.pnlSymbolTable.ResumeLayout(false);
            this.pnlSymbolTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectView)).EndInit();
            this.tabCollectView.ResumeLayout(false);
            this.tpRealTagView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRunSymbolView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRunSymbolView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tpTagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).EndInit();
            this.grpSystemMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonMenu;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuProject;
		private DevExpress.XtraBars.Docking.DockManager exDockManager;
		private DevExpress.XtraBars.BarButtonItem btnNew;
		private DevExpress.XtraBars.BarButtonItem btnSave;
		private DevExpress.XtraBars.BarButtonItem btnSaveAs;
		private DevExpress.XtraBars.BarButtonItem btnOpen;
		private DevExpress.XtraBars.BarStaticItem lblStatus;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar exRibbonStatusBar;
		private DevExpress.XtraBars.SkinRibbonGalleryBarItem exSkinGallery;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkins;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuMonitor;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSymbols;
		private DevExpress.XtraBars.BarButtonItem btnImportLogic;
		private DevExpress.XtraBars.BarButtonItem btnImportTagNew;
		private DevExpress.XtraBars.BarButtonItem btnExportTag;
		private DevExpress.XtraBars.BarButtonItem btnImportLog;
		private DevExpress.XtraBars.BarButtonItem btnShowChart;
		private DevExpress.XtraBars.Ribbon.RibbonPage mnuView;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuLog;
		private DevExpress.XtraBars.Docking.DockPanel pnlSymbolTable;
		private DevExpress.XtraBars.Docking.ControlContainer pnlSymbolTableContainer;
		private DevExpress.XtraBars.Docking.DockPanel pnlTagTable;
		private DevExpress.XtraBars.Docking.ControlContainer pnlTagTableContainer;
		private UCSymbolTable ucSymbolTable;
        private UCTagTable ucTagTable;
		private DevExpress.XtraBars.BarButtonItem btnImportTagAdd;
		private DevExpress.XtraBars.BarButtonItem btnExportTagForKepware;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDDEAControl;
        private DevExpress.XtraBars.BarEditItem cmbSettingList;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraSplashScreen.SplashScreenManager exScreenManager;
        private DevExpress.XtraBars.BarButtonItem btnSaveLogPath;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
        private System.Windows.Forms.Timer tmrDataRefresh;
        private DevExpress.XtraBars.BarButtonItem btnAddTag;
        private DevExpress.XtraBars.BarButtonItem btnClearAllTag;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPlcSetting;
        private DevExpress.XtraBars.BarButtonItem btnModel;
        private DevExpress.XtraBars.BarButtonItem btnOpenTest;
        private DevExpress.XtraBars.BarButtonItem btnSaveTest;
        private DevExpress.XtraBars.Navigation.TileNavCategory tileNavCategory1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking.DockPanel pnlProjectList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.RadioGroup radioGroupProjectList;
        private DevExpress.XtraBars.BarButtonItem btnAddProject;
        private DevExpress.XtraBars.BarButtonItem btnRemoveProject;
        private DevExpress.XtraEditors.GroupControl grpSystemMessage;
        private UCSystemLogTable ucSystemMessage;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer2;
        private DevExpress.XtraBars.Docking.DockPanel pnlSymbolState;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraGrid.GridControl grdRunSymbolView;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRunSymbolView;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarEditItem txtScanTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem btnShowLogFolder;
        private DevExpress.XtraTab.XtraTabControl tabCollectView;
        private DevExpress.XtraTab.XtraTabPage tpRealTagView;
        private DevExpress.XtraTab.XtraTabPage tpTagList;
        private DevExpress.XtraBars.BarButtonItem btnConfigEdit;
        private DevExpress.XtraBars.BarButtonItem btnProjectClear;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuFile;
	}
}

