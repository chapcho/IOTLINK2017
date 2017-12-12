namespace UDMDDEA
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.exAppMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.exRibbonGallery = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.btnPLCConfig = new DevExpress.XtraBars.BarButtonItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetailInfo = new DevExpress.XtraBars.BarButtonItem();
            this.chkLsPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkMelsecPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkABPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkSeimensPlc = new DevExpress.XtraBars.BarCheckItem();
            this.chkDDEA = new DevExpress.XtraBars.BarCheckItem();
            this.chkOpc = new DevExpress.XtraBars.BarCheckItem();
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuHomeFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomePlcMaker = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHomeSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuDetailView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.sptMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpProjectView = new DevExpress.XtraTab.XtraTabPage();
            this.grdComInfo = new DevExpress.XtraGrid.GridControl();
            this.grvComInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCommGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpSymbolStatus = new DevExpress.XtraTab.XtraTabPage();
            this.grdTag = new DevExpress.XtraGrid.GridControl();
            this.grvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.grpSystemMessage = new DevExpress.XtraEditors.GroupControl();
            this.ucSystemMessage = new UDMDDEA.UCSystemLogTable();
            this.tmrSystemLog = new System.Windows.Forms.Timer(this.components);
            this.tmrDataRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpProjectView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvComInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tpSymbolStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).BeginInit();
            this.grpSystemMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.ApplicationButtonDropDownControl = this.exAppMenu;
            this.exRibbonControl.ExpandCollapseItem.Id = 0;
            this.exRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonControl.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnExit,
            this.exRibbonGallery,
            this.btnPLCConfig,
            this.btnStart,
            this.btnStop,
            this.btnDetailInfo,
            this.chkLsPlc,
            this.chkMelsecPlc,
            this.chkABPlc,
            this.chkSeimensPlc,
            this.chkDDEA,
            this.chkOpc});
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.MaxItemId = 17;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome,
            this.mnuHelp});
            this.exRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonControl.Size = new System.Drawing.Size(875, 147);
            this.exRibbonControl.StatusBar = this.ribbonStatusBar;
            this.exRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // exAppMenu
            // 
            this.exAppMenu.ItemLinks.Add(this.btnNew);
            this.exAppMenu.ItemLinks.Add(this.btnOpen);
            this.exAppMenu.ItemLinks.Add(this.btnSave);
            this.exAppMenu.ItemLinks.Add(this.btnExit);
            this.exAppMenu.Name = "exAppMenu";
            this.exAppMenu.Ribbon = this.exRibbonControl;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNew.LargeGlyph")));
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.Glyph")));
            this.btnOpen.Id = 2;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.LargeGlyph")));
            this.btnOpen.LargeImageIndex = 1;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 3;
            this.btnSave.ImageIndex = 4;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.LargeImageIndex = 4;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 5;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "Save As";
            this.btnSaveAs.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Glyph")));
            this.btnSaveAs.Id = 4;
            this.btnSaveAs.ImageIndex = 5;
            this.btnSaveAs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.LargeGlyph")));
            this.btnSaveAs.LargeImageIndex = 5;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // exRibbonGallery
            // 
            this.exRibbonGallery.Caption = "ribbonGalleryBarItem1";
            this.exRibbonGallery.Id = 6;
            this.exRibbonGallery.Name = "exRibbonGallery";
            // 
            // btnPLCConfig
            // 
            this.btnPLCConfig.Caption = "PLC\r\n통신 설정";
            this.btnPLCConfig.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPLCConfig.Glyph")));
            this.btnPLCConfig.Id = 7;
            this.btnPLCConfig.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPLCConfig.LargeGlyph")));
            this.btnPLCConfig.Name = "btnPLCConfig";
            this.btnPLCConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPLCConfig_ItemClick);
            // 
            // btnStart
            // 
            this.btnStart.Caption = "시작";
            this.btnStart.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStart.Glyph")));
            this.btnStart.Id = 8;
            this.btnStart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStart.LargeGlyph")));
            this.btnStart.Name = "btnStart";
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "정지";
            this.btnStop.Enabled = false;
            this.btnStop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStop.Glyph")));
            this.btnStop.Id = 9;
            this.btnStop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStop.LargeGlyph")));
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // btnDetailInfo
            // 
            this.btnDetailInfo.Caption = "가동 중\r\n상세정보";
            this.btnDetailInfo.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDetailInfo.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDetailInfo.Glyph")));
            this.btnDetailInfo.Id = 10;
            this.btnDetailInfo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDetailInfo.LargeGlyph")));
            this.btnDetailInfo.Name = "btnDetailInfo";
            this.btnDetailInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailInfo_ItemClick);
            // 
            // chkLsPlc
            // 
            this.chkLsPlc.Caption = "LS";
            this.chkLsPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkLsPlc.Enabled = false;
            this.chkLsPlc.GroupIndex = 1;
            this.chkLsPlc.Id = 11;
            this.chkLsPlc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkLsPlc.LargeGlyph")));
            this.chkLsPlc.Name = "chkLsPlc";
            // 
            // chkMelsecPlc
            // 
            this.chkMelsecPlc.BindableChecked = true;
            this.chkMelsecPlc.Caption = "Melsec";
            this.chkMelsecPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkMelsecPlc.Checked = true;
            this.chkMelsecPlc.GroupIndex = 1;
            this.chkMelsecPlc.Id = 12;
            this.chkMelsecPlc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkMelsecPlc.LargeGlyph")));
            this.chkMelsecPlc.Name = "chkMelsecPlc";
            // 
            // chkABPlc
            // 
            this.chkABPlc.Caption = "AB";
            this.chkABPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkABPlc.Enabled = false;
            this.chkABPlc.GroupIndex = 1;
            this.chkABPlc.Id = 13;
            this.chkABPlc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkABPlc.LargeGlyph")));
            this.chkABPlc.Name = "chkABPlc";
            // 
            // chkSeimensPlc
            // 
            this.chkSeimensPlc.Caption = "Seimens";
            this.chkSeimensPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkSeimensPlc.Enabled = false;
            this.chkSeimensPlc.GroupIndex = 1;
            this.chkSeimensPlc.Id = 14;
            this.chkSeimensPlc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkSeimensPlc.LargeGlyph")));
            this.chkSeimensPlc.Name = "chkSeimensPlc";
            // 
            // chkDDEA
            // 
            this.chkDDEA.BindableChecked = true;
            this.chkDDEA.Caption = "DDEA";
            this.chkDDEA.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkDDEA.Checked = true;
            this.chkDDEA.GroupIndex = 2;
            this.chkDDEA.Id = 15;
            this.chkDDEA.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkDDEA.LargeGlyph")));
            this.chkDDEA.Name = "chkDDEA";
            // 
            // chkOpc
            // 
            this.chkOpc.Caption = "OPC";
            this.chkOpc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkOpc.Enabled = false;
            this.chkOpc.GroupIndex = 2;
            this.chkOpc.Id = 16;
            this.chkOpc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkOpc.LargeGlyph")));
            this.chkOpc.Name = "chkOpc";
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuHomeFile,
            this.mnuHomePlcMaker,
            this.mnuConfig,
            this.mnuControl,
            this.mnuExit,
            this.mnuHomeSkin});
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
            this.mnuHomeFile.Visible = false;
            // 
            // mnuHomePlcMaker
            // 
            this.mnuHomePlcMaker.ItemLinks.Add(this.chkLsPlc);
            this.mnuHomePlcMaker.ItemLinks.Add(this.chkMelsecPlc);
            this.mnuHomePlcMaker.ItemLinks.Add(this.chkABPlc);
            this.mnuHomePlcMaker.ItemLinks.Add(this.chkSeimensPlc);
            this.mnuHomePlcMaker.Name = "mnuHomePlcMaker";
            this.mnuHomePlcMaker.Text = "PLC Maker";
            // 
            // mnuConfig
            // 
            this.mnuConfig.ItemLinks.Add(this.chkDDEA);
            this.mnuConfig.ItemLinks.Add(this.chkOpc);
            this.mnuConfig.ItemLinks.Add(this.btnPLCConfig, true);
            this.mnuConfig.Name = "mnuConfig";
            this.mnuConfig.Text = "설정";
            // 
            // mnuControl
            // 
            this.mnuControl.ItemLinks.Add(this.btnStart);
            this.mnuControl.ItemLinks.Add(this.btnStop);
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Text = "제어";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // mnuHomeSkin
            // 
            this.mnuHomeSkin.ItemLinks.Add(this.exRibbonGallery);
            this.mnuHomeSkin.Name = "mnuHomeSkin";
            this.mnuHomeSkin.Text = "Skins";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuDetailView});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Visible = false;
            // 
            // mnuDetailView
            // 
            this.mnuDetailView.ItemLinks.Add(this.btnDetailInfo);
            this.mnuDetailView.Name = "mnuDetailView";
            this.mnuDetailView.Text = "상세보기";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 736);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.exRibbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(875, 31);
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptMain.Horizontal = false;
            this.sptMain.Location = new System.Drawing.Point(0, 147);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.tabMain);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grpSystemMessage);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(875, 589);
            this.sptMain.SplitterPosition = 160;
            this.sptMain.TabIndex = 4;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpProjectView;
            this.tabMain.Size = new System.Drawing.Size(875, 424);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpProjectView,
            this.tpSymbolStatus});
            // 
            // tpProjectView
            // 
            this.tpProjectView.Controls.Add(this.grdComInfo);
            this.tpProjectView.Name = "tpProjectView";
            this.tpProjectView.Size = new System.Drawing.Size(869, 395);
            this.tpProjectView.Text = "설정된 정보";
            // 
            // grdComInfo
            // 
            this.grdComInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdComInfo.Location = new System.Drawing.Point(0, 0);
            this.grdComInfo.MainView = this.grvComInfo;
            this.grdComInfo.MenuManager = this.exRibbonControl;
            this.grdComInfo.Name = "grdComInfo";
            this.grdComInfo.Size = new System.Drawing.Size(869, 395);
            this.grdComInfo.TabIndex = 2;
            this.grdComInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvComInfo,
            this.gridView2});
            // 
            // grvComInfo
            // 
            this.grvComInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCommGroup,
            this.colCommItem,
            this.colCommValue});
            this.grvComInfo.GridControl = this.grdComInfo;
            this.grvComInfo.Name = "grvComInfo";
            this.grvComInfo.OptionsBehavior.Editable = false;
            this.grvComInfo.OptionsView.AllowCellMerge = true;
            // 
            // colCommGroup
            // 
            this.colCommGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colCommGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommGroup.Caption = "Group";
            this.colCommGroup.FieldName = "Group";
            this.colCommGroup.Name = "colCommGroup";
            this.colCommGroup.OptionsColumn.ReadOnly = true;
            this.colCommGroup.Visible = true;
            this.colCommGroup.VisibleIndex = 0;
            this.colCommGroup.Width = 200;
            // 
            // colCommItem
            // 
            this.colCommItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommItem.Caption = "Item";
            this.colCommItem.FieldName = "Item";
            this.colCommItem.Name = "colCommItem";
            this.colCommItem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommItem.OptionsColumn.ReadOnly = true;
            this.colCommItem.Visible = true;
            this.colCommItem.VisibleIndex = 1;
            this.colCommItem.Width = 200;
            // 
            // colCommValue
            // 
            this.colCommValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colCommValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCommValue.Caption = "Value";
            this.colCommValue.FieldName = "Value";
            this.colCommValue.Name = "colCommValue";
            this.colCommValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommValue.OptionsColumn.ReadOnly = true;
            this.colCommValue.Visible = true;
            this.colCommValue.VisibleIndex = 2;
            this.colCommValue.Width = 590;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdComInfo;
            this.gridView2.Name = "gridView2";
            // 
            // tpSymbolStatus
            // 
            this.tpSymbolStatus.Controls.Add(this.grdTag);
            this.tpSymbolStatus.Name = "tpSymbolStatus";
            this.tpSymbolStatus.Size = new System.Drawing.Size(1008, 395);
            this.tpSymbolStatus.Text = "수집 중인 접점 상태";
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
            this.grdTag.Size = new System.Drawing.Size(1008, 395);
            this.grdTag.TabIndex = 3;
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
            this.colDescription,
            this.colDataType,
            this.colCollectUse,
            this.colCurrentValue,
            this.colChangeCount});
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAddress, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "설정", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.exEditorConfigMDC.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.exEditorConfigMDC.Name = "exEditorConfigMDC";
            this.exEditorConfigMDC.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grpSystemMessage
            // 
            this.grpSystemMessage.Controls.Add(this.ucSystemMessage);
            this.grpSystemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSystemMessage.Location = new System.Drawing.Point(0, 0);
            this.grpSystemMessage.Name = "grpSystemMessage";
            this.grpSystemMessage.Size = new System.Drawing.Size(875, 160);
            this.grpSystemMessage.TabIndex = 0;
            this.grpSystemMessage.Text = "System Message";
            // 
            // ucSystemMessage
            // 
            this.ucSystemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemMessage.Location = new System.Drawing.Point(2, 21);
            this.ucSystemMessage.Name = "ucSystemMessage";
            this.ucSystemMessage.Size = new System.Drawing.Size(871, 137);
            this.ucSystemMessage.TabIndex = 3;
            // 
            // tmrSystemLog
            // 
            this.tmrSystemLog.Interval = 3600000;
            this.tmrSystemLog.Tick += new System.EventHandler(this.tmrSystemLog_Tick);
            // 
            // tmrDataRefresh
            // 
            this.tmrDataRefresh.Tick += new System.EventHandler(this.tmrDataRefresh_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 767);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.exRibbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "UDM DDEA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exAppMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpProjectView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvComInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tpSymbolStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).EndInit();
            this.grpSystemMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomeFile;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomeSkin;
        private DevExpress.XtraBars.RibbonGalleryBarItem exRibbonGallery;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private DevExpress.XtraEditors.SplitContainerControl sptMain;
        private DevExpress.XtraEditors.GroupControl grpSystemMessage;
        private UDMDDEA.UCSystemLogTable ucSystemMessage;
        private DevExpress.XtraBars.BarButtonItem btnPLCConfig;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuConfig;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuControl;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpProjectView;
        private DevExpress.XtraGrid.GridControl grdComInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvComInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colCommGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colCommItem;
        private DevExpress.XtraGrid.Columns.GridColumn colCommValue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabPage tpSymbolStatus;
        private DevExpress.XtraGrid.GridControl grdTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTag;
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
        private System.Windows.Forms.Timer tmrSystemLog;
        private DevExpress.XtraSplashScreen.SplashScreenManager exScreenManager;
        private System.Windows.Forms.Timer tmrDataRefresh;
        private DevExpress.XtraBars.BarButtonItem btnDetailInfo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDetailView;
        private DevExpress.XtraBars.BarCheckItem chkLsPlc;
        private DevExpress.XtraBars.BarCheckItem chkMelsecPlc;
        private DevExpress.XtraBars.BarCheckItem chkABPlc;
        private DevExpress.XtraBars.BarCheckItem chkSeimensPlc;
        private DevExpress.XtraBars.BarCheckItem chkDDEA;
        private DevExpress.XtraBars.BarCheckItem chkOpc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHomePlcMaker;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu exAppMenu;
    }
}