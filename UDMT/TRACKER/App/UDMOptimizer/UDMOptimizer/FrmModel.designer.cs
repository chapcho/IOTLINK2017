namespace UDMOptimizer
{
    partial class FrmModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModel));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.exModelRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnConvert = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfigSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPlc = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcessAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnErrorMonitoringAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbnormalStructure = new DevExpress.XtraBars.BarButtonItem();
            this.btnTagTest = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection();
            this.pgBaseSet = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuDebug = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuTest = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.exEditorDescriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.exEditorProcess = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exMasterPatternMenu = new DevExpress.XtraBars.PopupMenu();
            this.cntxPLCMenu = new System.Windows.Forms.ContextMenuStrip();
            this.mnuRenamePLC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletePLC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPLCChangeConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdatePLCProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList();
            this.cntxlMenu = new System.Windows.Forms.ContextMenuStrip();
            this.mnuDeleteSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxTotalTag = new System.Windows.Forms.ContextMenuStrip();
            this.btnLadderView = new System.Windows.Forms.ToolStripMenuItem();
            this.tbandPlcMaker = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.tbandConnetType = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.tbandPlcName = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu3 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu4 = new DevExpress.XtraBars.PopupMenu();
            this.grpTagTable = new DevExpress.XtraEditors.GroupControl();
            this.grdTotalTagS = new DevExpress.XtraGrid.GridControl();
            this.grvTotalTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorStepRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnValidateCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnTagDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnTagAdd = new DevExpress.XtraEditors.SimpleButton();
            this.sptTree = new DevExpress.XtraEditors.SplitContainerControl();
            this.TabTable = new DevExpress.XtraTab.XtraTabControl();
            this.tpProcess = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucProcessTree = new UDMOptimizer.UCProcessTree();
            this.tpPLC = new DevExpress.XtraTab.XtraTabPage();
            this.grpPlcList = new DevExpress.XtraEditors.GroupControl();
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colPLCName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaker = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.sptModelMain = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.exModelRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).BeginInit();
            this.cntxPLCMenu.SuspendLayout();
            this.cntxlMenu.SuspendLayout();
            this.cntxTotalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTagTable)).BeginInit();
            this.grpTagTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptTree)).BeginInit();
            this.sptTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabTable)).BeginInit();
            this.TabTable.SuspendLayout();
            this.tpProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tpPLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcList)).BeginInit();
            this.grpPlcList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptModelMain)).BeginInit();
            this.sptModelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // exModelRibbon
            // 
            this.exModelRibbon.ExpandCollapseItem.Id = 0;
            this.exModelRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exModelRibbon.ExpandCollapseItem,
            this.btnConvert,
            this.btnConfigSet,
            this.btnClear,
            this.btnAddPlc,
            this.btnProcessAdd,
            this.btnErrorMonitoringAdd,
            this.btnExit,
            this.btnAbnormalStructure,
            this.btnTagTest});
            this.exModelRibbon.LargeImages = this.imgListRibbonLarge;
            this.exModelRibbon.Location = new System.Drawing.Point(0, 0);
            this.exModelRibbon.MaxItemId = 5;
            this.exModelRibbon.Name = "exModelRibbon";
            this.exModelRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgBaseSet});
            this.exModelRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorAddressFilter,
            this.exEditorDescriptionFilter,
            this.exEditorProcess});
            this.exModelRibbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exModelRibbon.ShowToolbarCustomizeItem = false;
            this.exModelRibbon.Size = new System.Drawing.Size(1227, 147);
            this.exModelRibbon.StatusBar = this.ribbonStatusBar;
            this.exModelRibbon.Toolbar.ShowCustomizeItem = false;
            this.exModelRibbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnConvert
            // 
            this.btnConvert.Caption = "Convert";
            this.btnConvert.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnConvert.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConvert.Glyph")));
            this.btnConvert.Id = 5;
            this.btnConvert.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConvert.LargeGlyph")));
            this.btnConvert.Name = "btnConvert";
            // 
            // btnConfigSet
            // 
            this.btnConfigSet.Caption = "Config";
            this.btnConfigSet.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnConfigSet.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConfigSet.Glyph")));
            this.btnConfigSet.Id = 8;
            this.btnConfigSet.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConfigSet.LargeGlyph")));
            this.btnConfigSet.Name = "btnConfigSet";
            // 
            // btnClear
            // 
            this.btnClear.Caption = "All Clear && New";
            this.btnClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 11;
            this.btnClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClear.LargeGlyph")));
            this.btnClear.Name = "btnClear";
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear_ItemClick);
            // 
            // btnAddPlc
            // 
            this.btnAddPlc.Caption = "ADD PLC";
            this.btnAddPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddPlc.Id = 15;
            this.btnAddPlc.ImageUri.Uri = "AddItem";
            this.btnAddPlc.Name = "btnAddPlc";
            this.btnAddPlc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPlc_ItemClick);
            // 
            // btnProcessAdd
            // 
            this.btnProcessAdd.Caption = "Create Process";
            this.btnProcessAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProcessAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProcessAdd.Glyph")));
            this.btnProcessAdd.Id = 17;
            this.btnProcessAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProcessAdd.LargeGlyph")));
            this.btnProcessAdd.Name = "btnProcessAdd";
            this.btnProcessAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcessAdd_ItemClick);
            // 
            // btnErrorMonitoringAdd
            // 
            this.btnErrorMonitoringAdd.Caption = "ADD Process\r\n(Only Error Check)";
            this.btnErrorMonitoringAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnErrorMonitoringAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnErrorMonitoringAdd.Glyph")));
            this.btnErrorMonitoringAdd.Id = 2;
            this.btnErrorMonitoringAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnErrorMonitoringAdd.LargeGlyph")));
            this.btnErrorMonitoringAdd.Name = "btnErrorMonitoringAdd";
            this.btnErrorMonitoringAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnErrorMonitoringAdd_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 3;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnAbnormalStructure
            // 
            this.btnAbnormalStructure.Caption = "Error Device Tree Structure";
            this.btnAbnormalStructure.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAbnormalStructure.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAbnormalStructure.Glyph")));
            this.btnAbnormalStructure.Id = 5;
            this.btnAbnormalStructure.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAbnormalStructure.LargeGlyph")));
            this.btnAbnormalStructure.Name = "btnAbnormalStructure";
            this.btnAbnormalStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbnormalStructure_ItemClick);
            // 
            // btnTagTest
            // 
            this.btnTagTest.Caption = "Tag Test";
            this.btnTagTest.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnTagTest.Id = 2;
            this.btnTagTest.Name = "btnTagTest";
            this.btnTagTest.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnTagTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTagTest_ItemClick);
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
            // pgBaseSet
            // 
            this.pgBaseSet.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuControl,
            this.mnuDebug,
            this.mnuExit,
            this.mnuTest});
            this.pgBaseSet.Name = "pgBaseSet";
            this.pgBaseSet.Text = "Home";
            // 
            // mnuControl
            // 
            this.mnuControl.ItemLinks.Add(this.btnClear);
            this.mnuControl.ItemLinks.Add(this.btnAddPlc);
            this.mnuControl.ItemLinks.Add(this.btnProcessAdd);
            this.mnuControl.ItemLinks.Add(this.btnErrorMonitoringAdd);
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Text = "Setting";
            // 
            // mnuDebug
            // 
            this.mnuDebug.ItemLinks.Add(this.btnAbnormalStructure);
            this.mnuDebug.Name = "mnuDebug";
            this.mnuDebug.Text = "Abnormal Tree";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // mnuTest
            // 
            this.mnuTest.ItemLinks.Add(this.btnTagTest);
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Text = "TEST";
            this.mnuTest.Visible = false;
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
            // exEditorProcess
            // 
            this.exEditorProcess.AutoHeight = false;
            this.exEditorProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorProcess.Name = "exEditorProcess";
            this.exEditorProcess.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 736);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.exModelRibbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1227, 31);
            // 
            // exMasterPatternMenu
            // 
            this.exMasterPatternMenu.Name = "exMasterPatternMenu";
            this.exMasterPatternMenu.Ribbon = this.exModelRibbon;
            // 
            // cntxPLCMenu
            // 
            this.cntxPLCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRenamePLC,
            this.mnuDeletePLC,
            this.mnuSplitterMonitor1,
            this.mnuPLCChangeConfig,
            this.btnUpdatePLCProgram});
            this.cntxPLCMenu.Name = "cntxMonitorGroupMenu";
            this.cntxPLCMenu.Size = new System.Drawing.Size(188, 98);
            // 
            // mnuRenamePLC
            // 
            this.mnuRenamePLC.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenamePLC.Image")));
            this.mnuRenamePLC.Name = "mnuRenamePLC";
            this.mnuRenamePLC.Size = new System.Drawing.Size(187, 22);
            this.mnuRenamePLC.Text = "Rename";
            this.mnuRenamePLC.Click += new System.EventHandler(this.mnuRenamePLC_Click);
            // 
            // mnuDeletePLC
            // 
            this.mnuDeletePLC.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeletePLC.Image")));
            this.mnuDeletePLC.Name = "mnuDeletePLC";
            this.mnuDeletePLC.Size = new System.Drawing.Size(187, 22);
            this.mnuDeletePLC.Text = "Delete this";
            this.mnuDeletePLC.Click += new System.EventHandler(this.mnuDeletePLC_Click);
            // 
            // mnuSplitterMonitor1
            // 
            this.mnuSplitterMonitor1.Name = "mnuSplitterMonitor1";
            this.mnuSplitterMonitor1.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuPLCChangeConfig
            // 
            this.mnuPLCChangeConfig.Image = ((System.Drawing.Image)(resources.GetObject("mnuPLCChangeConfig.Image")));
            this.mnuPLCChangeConfig.Name = "mnuPLCChangeConfig";
            this.mnuPLCChangeConfig.Size = new System.Drawing.Size(187, 22);
            this.mnuPLCChangeConfig.Text = "Change Config";
            this.mnuPLCChangeConfig.Click += new System.EventHandler(this.mnuPLCChangeConfig_Click);
            // 
            // btnUpdatePLCProgram
            // 
            this.btnUpdatePLCProgram.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePLCProgram.Image")));
            this.btnUpdatePLCProgram.Name = "btnUpdatePLCProgram";
            this.btnUpdatePLCProgram.Size = new System.Drawing.Size(187, 22);
            this.btnUpdatePLCProgram.Text = "Update PLC Program";
            this.btnUpdatePLCProgram.Click += new System.EventHandler(this.btnUpdatePLCProgram_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "green_bullet__16x16.png");
            // 
            // cntxlMenu
            // 
            this.cntxlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeleteSymbolS});
            this.cntxlMenu.Name = "mnuAddSymbols";
            this.cntxlMenu.Size = new System.Drawing.Size(216, 26);
            // 
            // mnuDeleteSymbolS
            // 
            this.mnuDeleteSymbolS.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteSymbolS.Image")));
            this.mnuDeleteSymbolS.Name = "mnuDeleteSymbolS";
            this.mnuDeleteSymbolS.Size = new System.Drawing.Size(215, 22);
            this.mnuDeleteSymbolS.Text = "Delete Selected Symbol(s)";
            this.mnuDeleteSymbolS.Click += new System.EventHandler(this.mnuDeleteSymbolS_Click);
            // 
            // cntxTotalTag
            // 
            this.cntxTotalTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLadderView});
            this.cntxTotalTag.Name = "cntxTotalTag";
            this.cntxTotalTag.Size = new System.Drawing.Size(275, 26);
            // 
            // btnLadderView
            // 
            this.btnLadderView.Image = ((System.Drawing.Image)(resources.GetObject("btnLadderView.Image")));
            this.btnLadderView.Name = "btnLadderView";
            this.btnLadderView.Size = new System.Drawing.Size(274, 22);
            this.btnLadderView.Text = "해당 출력 접점과 관련된 Ladder 보기";
            this.btnLadderView.Click += new System.EventHandler(this.btnLadderView_Click_1);
            // 
            // tbandPlcMaker
            // 
            this.tbandPlcMaker.Caption = "PLC Maker";
            this.tbandPlcMaker.Name = "tbandPlcMaker";
            this.tbandPlcMaker.Width = 100;
            // 
            // tbandConnetType
            // 
            this.tbandConnetType.Caption = "Connet Type";
            this.tbandConnetType.Name = "tbandConnetType";
            this.tbandConnetType.Width = 100;
            // 
            // tbandPlcName
            // 
            this.tbandPlcName.Caption = "PLC Name";
            this.tbandPlcName.Name = "tbandPlcName";
            this.tbandPlcName.Width = 100;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.exModelRibbon;
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            this.popupMenu2.Ribbon = this.exModelRibbon;
            // 
            // popupMenu3
            // 
            this.popupMenu3.Name = "popupMenu3";
            this.popupMenu3.Ribbon = this.exModelRibbon;
            // 
            // popupMenu4
            // 
            this.popupMenu4.Name = "popupMenu4";
            this.popupMenu4.Ribbon = this.exModelRibbon;
            // 
            // grpTagTable
            // 
            this.grpTagTable.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grpTagTable.AppearanceCaption.Options.UseFont = true;
            this.grpTagTable.Controls.Add(this.grdTotalTagS);
            this.grpTagTable.Controls.Add(this.panelControl1);
            this.grpTagTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTagTable.Location = new System.Drawing.Point(0, 0);
            this.grpTagTable.Name = "grpTagTable";
            this.grpTagTable.Size = new System.Drawing.Size(826, 589);
            this.grpTagTable.TabIndex = 0;
            this.grpTagTable.Text = "Tag Table";
            // 
            // grdTotalTagS
            // 
            this.grdTotalTagS.AllowDrop = true;
            this.grdTotalTagS.ContextMenuStrip = this.cntxTotalTag;
            this.grdTotalTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdTotalTagS.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdTotalTagS.Location = new System.Drawing.Point(2, 79);
            this.grdTotalTagS.MainView = this.grvTotalTagS;
            this.grdTotalTagS.Name = "grdTotalTagS";
            this.grdTotalTagS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdTotalTagS.Size = new System.Drawing.Size(822, 508);
            this.grdTotalTagS.TabIndex = 1;
            this.grdTotalTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotalTagS,
            this.gridView1});
            this.grdTotalTagS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdTotalTagS_DragDrop);
            this.grdTotalTagS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdTotalTagS_DragOver);
            // 
            // grvTotalTagS
            // 
            this.grvTotalTagS.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTotalTagS.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.Row.Options.UseFont = true;
            this.grvTotalTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colAddress,
            this.colSize,
            this.colDataType,
            this.colDescription,
            this.colChannel,
            this.colGroupRoleType,
            this.colStepRoleType,
            this.colName,
            this.colCoil,
            this.colUsed});
            this.grvTotalTagS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTotalTagS.GridControl = this.grdTotalTagS;
            this.grvTotalTagS.GroupCount = 1;
            this.grvTotalTagS.GroupRowHeight = 30;
            this.grvTotalTagS.IndicatorWidth = 60;
            this.grvTotalTagS.Name = "grvTotalTagS";
            this.grvTotalTagS.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTotalTagS.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grvTotalTagS.OptionsDetail.EnableMasterViewMode = false;
            this.grvTotalTagS.OptionsDetail.ShowDetailTabs = false;
            this.grvTotalTagS.OptionsDetail.SmartDetailExpand = false;
            this.grvTotalTagS.OptionsSelection.MultiSelect = true;
            this.grvTotalTagS.OptionsView.ShowAutoFilterRow = true;
            this.grvTotalTagS.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvTotalTagS.OptionsView.ShowGroupedColumns = true;
            this.grvTotalTagS.RowHeight = 30;
            this.grvTotalTagS.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colChannel, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvTotalTagS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvTotalTagS_CustomDrawRowIndicator);
            this.grvTotalTagS.ShownEditor += new System.EventHandler(this.grvTotalTagS_ShownEditor);
            this.grvTotalTagS.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvTotalTagS_CustomUnboundColumnData);
            this.grvTotalTagS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseDown);
            this.grvTotalTagS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseMove);
            this.grvTotalTagS.DoubleClick += new System.EventHandler(this.grvTotalTagS_DoubleClick);
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.MinWidth = 100;
            this.colKey.Name = "colKey";
            this.colKey.OptionsColumn.AllowEdit = false;
            this.colKey.OptionsColumn.ReadOnly = true;
            this.colKey.Width = 152;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 80;
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 141;
            // 
            // colSize
            // 
            this.colSize.AppearanceCell.Options.UseTextOptions = true;
            this.colSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.MinWidth = 40;
            this.colSize.Name = "colSize";
            this.colSize.OptionsColumn.AllowEdit = false;
            this.colSize.OptionsColumn.ReadOnly = true;
            this.colSize.Width = 77;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.MinWidth = 100;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            this.colDataType.Width = 116;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 180;
            // 
            // colChannel
            // 
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Channel";
            this.colChannel.FieldName = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 4;
            this.colChannel.Width = 87;
            // 
            // colGroupRoleType
            // 
            this.colGroupRoleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroupRoleType.Caption = "GroupRole";
            this.colGroupRoleType.FieldName = "_GroupRole_";
            this.colGroupRoleType.Name = "colGroupRoleType";
            this.colGroupRoleType.OptionsColumn.AllowEdit = false;
            this.colGroupRoleType.OptionsColumn.ReadOnly = true;
            this.colGroupRoleType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colGroupRoleType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colGroupRoleType.Width = 96;
            // 
            // colStepRoleType
            // 
            this.colStepRoleType.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepRoleType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepRoleType.Caption = "StepRole";
            this.colStepRoleType.FieldName = "_StepRoleType_";
            this.colStepRoleType.Name = "colStepRoleType";
            this.colStepRoleType.OptionsColumn.AllowEdit = false;
            this.colStepRoleType.OptionsColumn.ReadOnly = true;
            this.colStepRoleType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colStepRoleType.Width = 99;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 80;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 93;
            // 
            // colCoil
            // 
            this.colCoil.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoil.Caption = "IsCoil";
            this.colCoil.FieldName = "IsHMIMapping";
            this.colCoil.MaxWidth = 60;
            this.colCoil.MinWidth = 60;
            this.colCoil.Name = "colCoil";
            this.colCoil.Visible = true;
            this.colCoil.VisibleIndex = 5;
            this.colCoil.Width = 60;
            // 
            // colUsed
            // 
            this.colUsed.Caption = "Used";
            this.colUsed.FieldName = "UseOnlyInLogic";
            this.colUsed.MaxWidth = 50;
            this.colUsed.MinWidth = 50;
            this.colUsed.Name = "colUsed";
            this.colUsed.Visible = true;
            this.colUsed.VisibleIndex = 6;
            this.colUsed.Width = 50;
            // 
            // exEditorGroupCombo
            // 
            this.exEditorGroupCombo.AutoHeight = false;
            this.exEditorGroupCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupCombo.Name = "exEditorGroupCombo";
            this.exEditorGroupCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // exEditorGroupRoleCombo
            // 
            this.exEditorGroupRoleCombo.AutoHeight = false;
            this.exEditorGroupRoleCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorGroupRoleCombo.Items.AddRange(new object[] {
            "",
            "Key",
            "SubKey",
            "General",
            "Trend",
            "Alarm"});
            this.exEditorGroupRoleCombo.Name = "exEditorGroupRoleCombo";
            this.exEditorGroupRoleCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // exEditorStepRoleCombo
            // 
            this.exEditorStepRoleCombo.AutoHeight = false;
            this.exEditorStepRoleCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorStepRoleCombo.Items.AddRange(new object[] {
            "",
            "Coil",
            "Contact"});
            this.exEditorStepRoleCombo.Name = "exEditorStepRoleCombo";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdTotalTagS;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.btnValidateCheck);
            this.panelControl1.Controls.Add(this.btnTagDelete);
            this.panelControl1.Controls.Add(this.btnTagAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(822, 54);
            this.panelControl1.TabIndex = 2;
            // 
            // btnValidateCheck
            // 
            this.btnValidateCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnValidateCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnValidateCheck.Image")));
            this.btnValidateCheck.Location = new System.Drawing.Point(257, 2);
            this.btnValidateCheck.Name = "btnValidateCheck";
            this.btnValidateCheck.Size = new System.Drawing.Size(225, 50);
            this.btnValidateCheck.TabIndex = 2;
            this.btnValidateCheck.Text = "Selected Tag Validate Check";
            this.btnValidateCheck.Click += new System.EventHandler(this.btnValidateCheck_Click);
            // 
            // btnTagDelete
            // 
            this.btnTagDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTagDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnTagDelete.Image")));
            this.btnTagDelete.Location = new System.Drawing.Point(115, 2);
            this.btnTagDelete.Name = "btnTagDelete";
            this.btnTagDelete.Size = new System.Drawing.Size(142, 50);
            this.btnTagDelete.TabIndex = 1;
            this.btnTagDelete.Text = "Remove \r\nSelected Tag";
            this.btnTagDelete.Click += new System.EventHandler(this.btnTagDelete_Click);
            // 
            // btnTagAdd
            // 
            this.btnTagAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTagAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnTagAdd.Image")));
            this.btnTagAdd.Location = new System.Drawing.Point(2, 2);
            this.btnTagAdd.Name = "btnTagAdd";
            this.btnTagAdd.Size = new System.Drawing.Size(113, 50);
            this.btnTagAdd.TabIndex = 0;
            this.btnTagAdd.Text = "Create Tag";
            this.btnTagAdd.Click += new System.EventHandler(this.btnTagAdd_Click);
            // 
            // sptTree
            // 
            this.sptTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTree.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptTree.Horizontal = false;
            this.sptTree.Location = new System.Drawing.Point(0, 0);
            this.sptTree.Name = "sptTree";
            this.sptTree.Panel1.Controls.Add(this.TabTable);
            this.sptTree.Panel1.MinSize = 300;
            this.sptTree.Panel1.Text = "Panel1";
            this.sptTree.Panel2.Text = "Panel2";
            this.sptTree.Size = new System.Drawing.Size(396, 589);
            this.sptTree.SplitterPosition = 0;
            this.sptTree.TabIndex = 1;
            this.sptTree.Text = "splitContainerControl1";
            // 
            // TabTable
            // 
            this.TabTable.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Italic);
            this.TabTable.AppearancePage.Header.Options.UseFont = true;
            this.TabTable.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Green;
            this.TabTable.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TabTable.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.TabTable.AppearancePage.HeaderActive.Options.UseFont = true;
            this.TabTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabTable.Location = new System.Drawing.Point(0, 0);
            this.TabTable.Name = "TabTable";
            this.TabTable.SelectedTabPage = this.tpProcess;
            this.TabTable.Size = new System.Drawing.Size(396, 584);
            this.TabTable.TabIndex = 1;
            this.TabTable.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpPLC,
            this.tpProcess});
            // 
            // tpProcess
            // 
            this.tpProcess.Controls.Add(this.groupControl1);
            this.tpProcess.Name = "tpProcess";
            this.tpProcess.Size = new System.Drawing.Size(390, 551);
            this.tpProcess.Text = "Process";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucProcessTree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(390, 551);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Process List View";
            // 
            // ucProcessTree
            // 
            this.ucProcessTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessTree.Editable = true;
            this.ucProcessTree.Location = new System.Drawing.Point(2, 21);
            this.ucProcessTree.Name = "ucProcessTree";
            this.ucProcessTree.ShowErrorProcess = true;
            this.ucProcessTree.Size = new System.Drawing.Size(386, 528);
            this.ucProcessTree.TabIndex = 0;
            // 
            // tpPLC
            // 
            this.tpPLC.Controls.Add(this.grpPlcList);
            this.tpPLC.Name = "tpPLC";
            this.tpPLC.Size = new System.Drawing.Size(390, 551);
            this.tpPLC.Text = "PLC";
            // 
            // grpPlcList
            // 
            this.grpPlcList.Controls.Add(this.exTreeList);
            this.grpPlcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlcList.Location = new System.Drawing.Point(0, 0);
            this.grpPlcList.Name = "grpPlcList";
            this.grpPlcList.Size = new System.Drawing.Size(390, 551);
            this.grpPlcList.TabIndex = 0;
            this.grpPlcList.Text = "PLC List View";
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colPLCName,
            this.colMaker,
            this.colType});
            this.exTreeList.ContextMenuStrip = this.cntxPLCMenu;
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(2, 21);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.ReadOnly = true;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.exTreeList.RowHeight = 25;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(386, 528);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDoubleClick);
            // 
            // colPLCName
            // 
            this.colPLCName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPLCName.AppearanceCell.Options.UseFont = true;
            this.colPLCName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPLCName.AppearanceHeader.Options.UseFont = true;
            this.colPLCName.Caption = "Name";
            this.colPLCName.FieldName = "Name";
            this.colPLCName.MinWidth = 33;
            this.colPLCName.Name = "colPLCName";
            this.colPLCName.Visible = true;
            this.colPLCName.VisibleIndex = 0;
            this.colPLCName.Width = 135;
            // 
            // colMaker
            // 
            this.colMaker.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaker.AppearanceCell.Options.UseFont = true;
            this.colMaker.AppearanceCell.Options.UseTextOptions = true;
            this.colMaker.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaker.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMaker.AppearanceHeader.Options.UseFont = true;
            this.colMaker.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaker.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaker.Caption = "Maker";
            this.colMaker.FieldName = "PLCMaker";
            this.colMaker.Name = "colMaker";
            this.colMaker.Visible = true;
            this.colMaker.VisibleIndex = 1;
            this.colMaker.Width = 120;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colType.AppearanceCell.Options.UseFont = true;
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colType.AppearanceHeader.Options.UseFont = true;
            this.colType.AppearanceHeader.Options.UseTextOptions = true;
            this.colType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType.Caption = "Collect Type";
            this.colType.FieldName = "CollectType";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 2;
            this.colType.Width = 119;
            // 
            // sptModelMain
            // 
            this.sptModelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptModelMain.Location = new System.Drawing.Point(0, 147);
            this.sptModelMain.Name = "sptModelMain";
            this.sptModelMain.Panel1.Controls.Add(this.sptTree);
            this.sptModelMain.Panel1.MinSize = 300;
            this.sptModelMain.Panel1.Text = "Panel1";
            this.sptModelMain.Panel2.Controls.Add(this.grpTagTable);
            this.sptModelMain.Panel2.MinSize = 300;
            this.sptModelMain.Panel2.Text = "Panel2";
            this.sptModelMain.Size = new System.Drawing.Size(1227, 589);
            this.sptModelMain.SplitterPosition = 396;
            this.sptModelMain.TabIndex = 2;
            this.sptModelMain.Text = "splitContainerControl1";
            // 
            // FrmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 767);
            this.Controls.Add(this.sptModelMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.exModelRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FrmModel";
            this.Ribbon = this.exModelRibbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Project Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModel_FormClosing);
            this.Load += new System.EventHandler(this.FrmModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exModelRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).EndInit();
            this.cntxPLCMenu.ResumeLayout(false);
            this.cntxlMenu.ResumeLayout(false);
            this.cntxTotalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTagTable)).EndInit();
            this.grpTagTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptTree)).EndInit();
            this.sptTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabTable)).EndInit();
            this.TabTable.ResumeLayout(false);
            this.tpProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tpPLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcList)).EndInit();
            this.grpPlcList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptModelMain)).EndInit();
            this.sptModelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exModelRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgBaseSet;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnConvert;
        private DevExpress.XtraBars.BarButtonItem btnConfigSet;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDescriptionFilter;
        private DevExpress.XtraBars.BarButtonItem btnClear;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuControl;
        private System.Windows.Forms.ContextMenuStrip cntxlMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbolS;
        private DevExpress.XtraBars.BarButtonItem btnAddPlc;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandPlcMaker;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandConnetType;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandPlcName;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxPLCMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePLC;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor1;
        private System.Windows.Forms.ToolStripMenuItem mnuPLCChangeConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuRenamePLC;
        private DevExpress.XtraBars.BarButtonItem btnProcessAdd;
        private DevExpress.XtraBars.BarButtonItem btnErrorMonitoringAdd;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private System.Windows.Forms.ToolStripMenuItem btnUpdatePLCProgram;
        private DevExpress.Utils.ImageCollection imgListRibbonLarge;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorProcess;
        private DevExpress.XtraBars.PopupMenu exMasterPatternMenu;
        private System.Windows.Forms.ContextMenuStrip cntxTotalTag;
        private System.Windows.Forms.ToolStripMenuItem btnLadderView;
        private DevExpress.XtraBars.BarButtonItem btnAbnormalStructure;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDebug;
        private DevExpress.XtraBars.BarButtonItem btnTagTest;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuTest;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraBars.PopupMenu popupMenu3;
        private DevExpress.XtraBars.PopupMenu popupMenu4;
        private DevExpress.XtraEditors.GroupControl grpTagTable;
        private DevExpress.XtraGrid.GridControl grdTotalTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTotalTagS;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colChannel;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colStepRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCoil;
        private DevExpress.XtraGrid.Columns.GridColumn colUsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnValidateCheck;
        private DevExpress.XtraEditors.SimpleButton btnTagDelete;
        private DevExpress.XtraEditors.SimpleButton btnTagAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitContainerControl sptTree;
        private DevExpress.XtraTab.XtraTabControl TabTable;
        private DevExpress.XtraTab.XtraTabPage tpProcess;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCProcessTree ucProcessTree;
        private DevExpress.XtraTab.XtraTabPage tpPLC;
        private DevExpress.XtraEditors.GroupControl grpPlcList;
        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPLCName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaker;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraEditors.SplitContainerControl sptModelMain;
    }
}