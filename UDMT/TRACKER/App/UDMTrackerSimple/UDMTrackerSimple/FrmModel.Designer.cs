namespace UDMTrackerSimple
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModel));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.exModelRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnConvert = new DevExpress.XtraBars.BarButtonItem();
            this.btnConfigSet = new DevExpress.XtraBars.BarButtonItem();
            this.txtDescriptionFilter = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDescriptionFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.btnClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnFilterApply = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddPlc = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcessAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnProcessSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecipeSet = new DevExpress.XtraBars.BarButtonItem();
            this.btnErrorMonitoringAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.btnViewMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllCreateMaster = new DevExpress.XtraBars.BarButtonItem();
            this.cboSelectedCreateMaster = new DevExpress.XtraBars.BarEditItem();
            this.exEditorProcess = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lblText = new DevExpress.XtraBars.BarStaticItem();
            this.btnAbnormalStructure = new DevExpress.XtraBars.BarButtonItem();
            this.btnMasterPatternClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnManualMasterPattern = new DevExpress.XtraBars.BarButtonItem();
            this.chkRecipeUpdate = new DevExpress.XtraBars.BarCheckItem();
            this.spnCycleCount = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.chkAbnormalPriority = new DevExpress.XtraBars.BarCheckItem();
            this.btnNonDetectTimeSetting = new DevExpress.XtraBars.BarButtonItem();
            this.spnCollectDepth = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnDepthApply = new DevExpress.XtraBars.BarButtonItem();
            this.imgListRibbonLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.pgBaseSet = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMasterPattern = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exEditorAddressFilter = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exMasterPatternMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.sptModelMain = new UDM.UI.MySplitContainerControl();
            this.sptTree = new UDM.UI.MySplitContainerControl();
            this.TabTable = new DevExpress.XtraTab.XtraTabControl();
            this.tpPLC = new DevExpress.XtraTab.XtraTabPage();
            this.grpPlcList = new DevExpress.XtraEditors.GroupControl();
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colPLCName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMaker = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPLCID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cntxPLCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRenamePLC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeletePLC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitterMonitor1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPLCChangeConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdatePLCProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tpProcess = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucProcessTree = new UDMTrackerSimple.UCProcessTree();
            this.tabUserSet = new DevExpress.XtraTab.XtraTabControl();
            this.tpUserDevice = new DevExpress.XtraTab.XtraTabPage();
            this.grdUserAll = new DevExpress.XtraGrid.GridControl();
            this.cntxlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDeleteSymbolS = new System.Windows.Forms.ToolStripMenuItem();
            this.grvUserAll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exShowCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlUserControl = new DevExpress.XtraEditors.PanelControl();
            this.btnUserDeviceAllClear = new DevExpress.XtraEditors.SimpleButton();
            this.tpRobotCycle = new DevExpress.XtraTab.XtraTabPage();
            this.grdRobotCycle = new DevExpress.XtraGrid.GridControl();
            this.grvRobotCycle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlRobotControl = new DevExpress.XtraEditors.PanelControl();
            this.btnRobotAllClear = new DevExpress.XtraEditors.SimpleButton();
            this.grpTagTable = new DevExpress.XtraEditors.GroupControl();
            this.grdTotalTagS = new DevExpress.XtraGrid.GridControl();
            this.cntxTotalTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLadderView = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkFilterAddress = new DevExpress.XtraEditors.CheckButton();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnValidateCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnTagDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnTagAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tbandPlcMaker = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.tbandConnetType = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.tbandPlcName = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.btnShowAllTag = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.exModelRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptModelMain)).BeginInit();
            this.sptModelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptTree)).BeginInit();
            this.sptTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabTable)).BeginInit();
            this.TabTable.SuspendLayout();
            this.tpPLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcList)).BeginInit();
            this.grpPlcList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.cntxPLCMenu.SuspendLayout();
            this.tpProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabUserSet)).BeginInit();
            this.tabUserSet.SuspendLayout();
            this.tpUserDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAll)).BeginInit();
            this.cntxlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserControl)).BeginInit();
            this.pnlUserControl.SuspendLayout();
            this.tpRobotCycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRobotCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobotCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRobotControl)).BeginInit();
            this.pnlRobotControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTagTable)).BeginInit();
            this.grpTagTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).BeginInit();
            this.cntxTotalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exModelRibbon
            // 
            this.exModelRibbon.ExpandCollapseItem.Id = 0;
            this.exModelRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exModelRibbon.ExpandCollapseItem,
            this.btnConvert,
            this.btnConfigSet,
            this.txtDescriptionFilter,
            this.btnClear,
            this.btnFilterApply,
            this.btnAddPlc,
            this.btnProcessAdd,
            this.btnProcessSetting,
            this.btnRecipeSet,
            this.btnErrorMonitoringAdd,
            this.btnExit,
            this.btnCreateMasterPattern,
            this.btnViewMasterPattern,
            this.btnAllCreateMaster,
            this.cboSelectedCreateMaster,
            this.lblText,
            this.btnAbnormalStructure,
            this.btnMasterPatternClear,
            this.btnManualMasterPattern,
            this.chkRecipeUpdate,
            this.spnCycleCount,
            this.chkAbnormalPriority,
            this.btnNonDetectTimeSetting,
            this.spnCollectDepth,
            this.btnDepthApply});
            this.exModelRibbon.LargeImages = this.imgListRibbonLarge;
            this.exModelRibbon.Location = new System.Drawing.Point(0, 0);
            this.exModelRibbon.MaxItemId = 6;
            this.exModelRibbon.Name = "exModelRibbon";
            this.exModelRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgBaseSet});
            this.exModelRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorAddressFilter,
            this.exEditorDescriptionFilter,
            this.exEditorProcess,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.exModelRibbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exModelRibbon.ShowToolbarCustomizeItem = false;
            this.exModelRibbon.Size = new System.Drawing.Size(1744, 147);
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
            // txtDescriptionFilter
            // 
            this.txtDescriptionFilter.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtDescriptionFilter.Edit = this.exEditorDescriptionFilter;
            this.txtDescriptionFilter.EditValue = "";
            this.txtDescriptionFilter.EditWidth = 150;
            this.txtDescriptionFilter.Id = 10;
            this.txtDescriptionFilter.Name = "txtDescriptionFilter";
            // 
            // exEditorDescriptionFilter
            // 
            this.exEditorDescriptionFilter.AutoHeight = false;
            this.exEditorDescriptionFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDescriptionFilter.Name = "exEditorDescriptionFilter";
            this.exEditorDescriptionFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            // btnFilterApply
            // 
            this.btnFilterApply.Caption = "Filter 적용";
            this.btnFilterApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnFilterApply.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFilterApply.Glyph")));
            this.btnFilterApply.Id = 12;
            this.btnFilterApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFilterApply.LargeGlyph")));
            this.btnFilterApply.Name = "btnFilterApply";
            this.btnFilterApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFilterApply_ItemClick);
            // 
            // btnAddPlc
            // 
            this.btnAddPlc.Caption = "Add PLC Logic";
            this.btnAddPlc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddPlc.Id = 15;
            this.btnAddPlc.ImageUri.Uri = "AddItem";
            this.btnAddPlc.Name = "btnAddPlc";
            this.btnAddPlc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddPlc_ItemClick);
            // 
            // btnProcessAdd
            // 
            this.btnProcessAdd.Caption = "Add Process";
            this.btnProcessAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProcessAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProcessAdd.Glyph")));
            this.btnProcessAdd.Id = 17;
            this.btnProcessAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProcessAdd.LargeGlyph")));
            this.btnProcessAdd.Name = "btnProcessAdd";
            this.btnProcessAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcessAdd_ItemClick);
            // 
            // btnProcessSetting
            // 
            this.btnProcessSetting.Caption = "Setting Process";
            this.btnProcessSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnProcessSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnProcessSetting.Glyph")));
            this.btnProcessSetting.Id = 18;
            this.btnProcessSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnProcessSetting.LargeGlyph")));
            this.btnProcessSetting.Name = "btnProcessSetting";
            this.btnProcessSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProcessSetting_ItemClick);
            // 
            // btnRecipeSet
            // 
            this.btnRecipeSet.Caption = "Setting CarType";
            this.btnRecipeSet.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnRecipeSet.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRecipeSet.Glyph")));
            this.btnRecipeSet.Id = 1;
            this.btnRecipeSet.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRecipeSet.LargeGlyph")));
            this.btnRecipeSet.Name = "btnRecipeSet";
            this.btnRecipeSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecipeSet_ItemClick);
            // 
            // btnErrorMonitoringAdd
            // 
            this.btnErrorMonitoringAdd.Caption = "이상 신호 모니터링 공정 추가";
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
            // btnCreateMasterPattern
            // 
            this.btnCreateMasterPattern.Caption = "Create Master Pattern";
            this.btnCreateMasterPattern.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnCreateMasterPattern.Id = 4;
            this.btnCreateMasterPattern.ImageIndex = 25;
            this.btnCreateMasterPattern.LargeImageIndex = 25;
            this.btnCreateMasterPattern.Name = "btnCreateMasterPattern";
            this.btnCreateMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateMasterPattern_ItemClick);
            // 
            // btnViewMasterPattern
            // 
            this.btnViewMasterPattern.Caption = "Show Master Pattern";
            this.btnViewMasterPattern.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnViewMasterPattern.Id = 1;
            this.btnViewMasterPattern.LargeImageIndex = 31;
            this.btnViewMasterPattern.Name = "btnViewMasterPattern";
            this.btnViewMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnViewMasterPattern_ItemClick);
            // 
            // btnAllCreateMaster
            // 
            this.btnAllCreateMaster.Caption = "모든 공정 자동 마스터 패턴 생성";
            this.btnAllCreateMaster.DropDownEnabled = false;
            this.btnAllCreateMaster.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllCreateMaster.Glyph")));
            this.btnAllCreateMaster.Id = 2;
            this.btnAllCreateMaster.Name = "btnAllCreateMaster";
            this.btnAllCreateMaster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllCreateMaster_ItemClick);
            // 
            // cboSelectedCreateMaster
            // 
            this.cboSelectedCreateMaster.Caption = "선택 공정 마스터 패턴 생성";
            this.cboSelectedCreateMaster.Edit = this.exEditorProcess;
            this.cboSelectedCreateMaster.EditWidth = 100;
            this.cboSelectedCreateMaster.Glyph = ((System.Drawing.Image)(resources.GetObject("cboSelectedCreateMaster.Glyph")));
            this.cboSelectedCreateMaster.Id = 3;
            this.cboSelectedCreateMaster.Name = "cboSelectedCreateMaster";
            this.cboSelectedCreateMaster.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.cboSelectedCreateMaster.EditValueChanged += new System.EventHandler(this.cboSelectedCreateMaster_EditValueChanged);
            // 
            // exEditorProcess
            // 
            this.exEditorProcess.AutoHeight = false;
            this.exEditorProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorProcess.Name = "exEditorProcess";
            this.exEditorProcess.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // lblText
            // 
            this.lblText.Caption = "이상 접점 Description Filter";
            this.lblText.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblText.Id = 4;
            this.lblText.Name = "lblText";
            this.lblText.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnAbnormalStructure
            // 
            this.btnAbnormalStructure.Caption = "이상 신호 Tree Structure";
            this.btnAbnormalStructure.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAbnormalStructure.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAbnormalStructure.Glyph")));
            this.btnAbnormalStructure.Id = 5;
            this.btnAbnormalStructure.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAbnormalStructure.LargeGlyph")));
            this.btnAbnormalStructure.Name = "btnAbnormalStructure";
            this.btnAbnormalStructure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbnormalStructure_ItemClick);
            // 
            // btnMasterPatternClear
            // 
            this.btnMasterPatternClear.Caption = "Remove Master Pattern";
            this.btnMasterPatternClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMasterPatternClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMasterPatternClear.Glyph")));
            this.btnMasterPatternClear.Id = 6;
            this.btnMasterPatternClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMasterPatternClear.LargeGlyph")));
            this.btnMasterPatternClear.Name = "btnMasterPatternClear";
            this.btnMasterPatternClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMasterPatternClear_ItemClick);
            // 
            // btnManualMasterPattern
            // 
            this.btnManualMasterPattern.Caption = "공정별 수동 마스터 패턴 생성";
            this.btnManualMasterPattern.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManualMasterPattern.Glyph")));
            this.btnManualMasterPattern.Id = 1;
            this.btnManualMasterPattern.Name = "btnManualMasterPattern";
            this.btnManualMasterPattern.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManualMasterPattern_ItemClick);
            // 
            // chkRecipeUpdate
            // 
            this.chkRecipeUpdate.BindableChecked = true;
            this.chkRecipeUpdate.Caption = "Auto Update (Process Car Type)";
            this.chkRecipeUpdate.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkRecipeUpdate.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.chkRecipeUpdate.Checked = true;
            this.chkRecipeUpdate.Id = 4;
            this.chkRecipeUpdate.Name = "chkRecipeUpdate";
            this.chkRecipeUpdate.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkRecipeUpdate_CheckedChanged);
            // 
            // spnCycleCount
            // 
            this.spnCycleCount.Caption = "Auto Update Cycle Count : ";
            this.spnCycleCount.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.spnCycleCount.Edit = this.repositoryItemSpinEdit1;
            this.spnCycleCount.EditValue = "10";
            this.spnCycleCount.EditWidth = 40;
            this.spnCycleCount.Id = 1;
            this.spnCycleCount.Name = "spnCycleCount";
            this.spnCycleCount.EditValueChanged += new System.EventHandler(this.spnCycleCount_EditValueChanged);
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // chkAbnormalPriority
            // 
            this.chkAbnormalPriority.Caption = "이상 신호 우선순위 적용";
            this.chkAbnormalPriority.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkAbnormalPriority.Glyph = ((System.Drawing.Image)(resources.GetObject("chkAbnormalPriority.Glyph")));
            this.chkAbnormalPriority.Id = 2;
            this.chkAbnormalPriority.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkAbnormalPriority.LargeGlyph")));
            this.chkAbnormalPriority.Name = "chkAbnormalPriority";
            this.chkAbnormalPriority.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkAbnormalPriority_CheckedChanged);
            // 
            // btnNonDetectTimeSetting
            // 
            this.btnNonDetectTimeSetting.Caption = "이상 감지 기능 비가동 시간 설정";
            this.btnNonDetectTimeSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNonDetectTimeSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNonDetectTimeSetting.Glyph")));
            this.btnNonDetectTimeSetting.Id = 3;
            this.btnNonDetectTimeSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNonDetectTimeSetting.LargeGlyph")));
            this.btnNonDetectTimeSetting.Name = "btnNonDetectTimeSetting";
            this.btnNonDetectTimeSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNonDetectTimeSetting_ItemClick);
            // 
            // spnCollectDepth
            // 
            this.spnCollectDepth.Caption = "Symbol  Depth :";
            this.spnCollectDepth.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.spnCollectDepth.Edit = this.repositoryItemSpinEdit2;
            this.spnCollectDepth.EditValue = 3;
            this.spnCollectDepth.EditWidth = 40;
            this.spnCollectDepth.Id = 4;
            this.spnCollectDepth.Name = "spnCollectDepth";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // btnDepthApply
            // 
            this.btnDepthApply.Caption = "Depth 적용";
            this.btnDepthApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDepthApply.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDepthApply.Glyph")));
            this.btnDepthApply.Id = 5;
            this.btnDepthApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDepthApply.LargeGlyph")));
            this.btnDepthApply.Name = "btnDepthApply";
            this.btnDepthApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepthApply_ItemClick);
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
            this.mnuMasterPattern,
            this.mnuFilter,
            this.mnuExit});
            this.pgBaseSet.Name = "pgBaseSet";
            this.pgBaseSet.Text = "기본 설정";
            // 
            // mnuControl
            // 
            this.mnuControl.ItemLinks.Add(this.btnClear);
            this.mnuControl.ItemLinks.Add(this.btnAddPlc);
            this.mnuControl.ItemLinks.Add(this.btnProcessAdd);
            this.mnuControl.ItemLinks.Add(this.btnErrorMonitoringAdd);
            this.mnuControl.ItemLinks.Add(this.btnProcessSetting, true);
            this.mnuControl.ItemLinks.Add(this.btnRecipeSet, true);
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Text = "Setting";
            // 
            // mnuMasterPattern
            // 
            this.mnuMasterPattern.ItemLinks.Add(this.btnCreateMasterPattern);
            this.mnuMasterPattern.ItemLinks.Add(this.btnMasterPatternClear);
            this.mnuMasterPattern.ItemLinks.Add(this.btnViewMasterPattern);
            this.mnuMasterPattern.ItemLinks.Add(this.chkRecipeUpdate);
            this.mnuMasterPattern.ItemLinks.Add(this.spnCycleCount);
            this.mnuMasterPattern.Name = "mnuMasterPattern";
            this.mnuMasterPattern.Text = "Master Pattern";
            // 
            // mnuFilter
            // 
            this.mnuFilter.ItemLinks.Add(this.lblText);
            this.mnuFilter.ItemLinks.Add(this.txtDescriptionFilter);
            this.mnuFilter.ItemLinks.Add(this.btnFilterApply);
            this.mnuFilter.ItemLinks.Add(this.chkAbnormalPriority, true);
            this.mnuFilter.ItemLinks.Add(this.btnAbnormalStructure);
            this.mnuFilter.ItemLinks.Add(this.btnNonDetectTimeSetting);
            this.mnuFilter.ItemLinks.Add(this.spnCollectDepth, true);
            this.mnuFilter.ItemLinks.Add(this.btnDepthApply);
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Text = "Abnormal Setting";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // exEditorAddressFilter
            // 
            this.exEditorAddressFilter.AutoHeight = false;
            this.exEditorAddressFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorAddressFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.exEditorAddressFilter.Name = "exEditorAddressFilter";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 920);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.exModelRibbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1744, 31);
            // 
            // exMasterPatternMenu
            // 
            this.exMasterPatternMenu.ItemLinks.Add(this.btnAllCreateMaster);
            this.exMasterPatternMenu.ItemLinks.Add(this.cboSelectedCreateMaster);
            this.exMasterPatternMenu.ItemLinks.Add(this.btnManualMasterPattern);
            this.exMasterPatternMenu.Name = "exMasterPatternMenu";
            this.exMasterPatternMenu.Ribbon = this.exModelRibbon;
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
            this.sptModelMain.Size = new System.Drawing.Size(1744, 773);
            this.sptModelMain.SplitterPosition = 508;
            this.sptModelMain.TabIndex = 2;
            this.sptModelMain.Text = "splitContainerControl1";
            this.sptModelMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptModelMain_MouseDoubleClick);
            // 
            // sptTree
            // 
            this.sptTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTree.Horizontal = false;
            this.sptTree.Location = new System.Drawing.Point(0, 0);
            this.sptTree.Name = "sptTree";
            this.sptTree.Panel1.Controls.Add(this.TabTable);
            this.sptTree.Panel1.MinSize = 300;
            this.sptTree.Panel1.Text = "Panel1";
            this.sptTree.Panel2.Controls.Add(this.tabUserSet);
            this.sptTree.Panel2.Text = "Panel2";
            this.sptTree.Size = new System.Drawing.Size(508, 773);
            this.sptTree.SplitterPosition = 406;
            this.sptTree.TabIndex = 1;
            this.sptTree.Text = "splitContainerControl1";
            this.sptTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptTree_MouseDoubleClick);
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
            this.TabTable.SelectedTabPage = this.tpPLC;
            this.TabTable.Size = new System.Drawing.Size(508, 406);
            this.TabTable.TabIndex = 1;
            this.TabTable.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpPLC,
            this.tpProcess});
            // 
            // tpPLC
            // 
            this.tpPLC.Controls.Add(this.grpPlcList);
            this.tpPLC.Name = "tpPLC";
            this.tpPLC.Size = new System.Drawing.Size(502, 373);
            this.tpPLC.Text = "PLC";
            // 
            // grpPlcList
            // 
            this.grpPlcList.Controls.Add(this.exTreeList);
            this.grpPlcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlcList.Location = new System.Drawing.Point(0, 0);
            this.grpPlcList.Name = "grpPlcList";
            this.grpPlcList.Size = new System.Drawing.Size(502, 373);
            this.grpPlcList.TabIndex = 0;
            this.grpPlcList.Text = "PLC List View";
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colPLCName,
            this.colMaker,
            this.colType,
            this.colPLCID});
            this.exTreeList.ContextMenuStrip = this.cntxPLCMenu;
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(2, 21);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.PopulateServiceColumns = true;
            this.exTreeList.OptionsBehavior.ReadOnly = true;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.exTreeList.RowHeight = 25;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(498, 350);
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
            this.colPLCName.MinWidth = 34;
            this.colPLCName.Name = "colPLCName";
            this.colPLCName.Visible = true;
            this.colPLCName.VisibleIndex = 0;
            this.colPLCName.Width = 140;
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
            this.colMaker.Width = 128;
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
            this.colType.Width = 115;
            // 
            // colPLCID
            // 
            this.colPLCID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.colPLCID.AppearanceCell.Options.UseFont = true;
            this.colPLCID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.colPLCID.AppearanceHeader.Options.UseFont = true;
            this.colPLCID.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLCID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLCID.Caption = "ID";
            this.colPLCID.FieldName = "ID";
            this.colPLCID.Name = "colPLCID";
            this.colPLCID.Visible = true;
            this.colPLCID.VisibleIndex = 3;
            this.colPLCID.Width = 97;
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
            // tpProcess
            // 
            this.tpProcess.Controls.Add(this.groupControl1);
            this.tpProcess.Name = "tpProcess";
            this.tpProcess.Size = new System.Drawing.Size(502, 373);
            this.tpProcess.Text = "Process";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucProcessTree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(502, 373);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Process List View";
            // 
            // ucProcessTree
            // 
            this.ucProcessTree.AbnormalFilter = null;
            this.ucProcessTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProcessTree.IsProcessEdit = false;
            this.ucProcessTree.Location = new System.Drawing.Point(2, 21);
            this.ucProcessTree.Name = "ucProcessTree";
            this.ucProcessTree.Size = new System.Drawing.Size(498, 350);
            this.ucProcessTree.TabIndex = 0;
            // 
            // tabUserSet
            // 
            this.tabUserSet.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.tabUserSet.AppearancePage.Header.Options.UseFont = true;
            this.tabUserSet.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tabUserSet.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabUserSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUserSet.Location = new System.Drawing.Point(0, 0);
            this.tabUserSet.Name = "tabUserSet";
            this.tabUserSet.SelectedTabPage = this.tpUserDevice;
            this.tabUserSet.Size = new System.Drawing.Size(508, 357);
            this.tabUserSet.TabIndex = 1;
            this.tabUserSet.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUserDevice,
            this.tpRobotCycle});
            // 
            // tpUserDevice
            // 
            this.tpUserDevice.Controls.Add(this.grdUserAll);
            this.tpUserDevice.Controls.Add(this.pnlUserControl);
            this.tpUserDevice.Name = "tpUserDevice";
            this.tpUserDevice.Size = new System.Drawing.Size(502, 322);
            this.tpUserDevice.Text = "User Device";
            // 
            // grdUserAll
            // 
            this.grdUserAll.AllowDrop = true;
            this.grdUserAll.ContextMenuStrip = this.cntxlMenu;
            this.grdUserAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserAll.Location = new System.Drawing.Point(0, 0);
            this.grdUserAll.MainView = this.grvUserAll;
            this.grdUserAll.Name = "grdUserAll";
            this.grdUserAll.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exShowCheck});
            this.grdUserAll.Size = new System.Drawing.Size(502, 282);
            this.grdUserAll.TabIndex = 7;
            this.grdUserAll.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserAll});
            this.grdUserAll.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdUserAll_DragDrop);
            this.grdUserAll.DragOver += new System.Windows.Forms.DragEventHandler(this.grdUserAll_DragOver);
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
            // grvUserAll
            // 
            this.grvUserAll.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvUserAll.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUserAll.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvUserAll.Appearance.Row.Options.UseFont = true;
            this.grvUserAll.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvUserAll.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvUserAll.ColumnPanelRowHeight = 25;
            this.grvUserAll.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserAddress,
            this.colUserType,
            this.colUserName,
            this.colUserShow});
            this.grvUserAll.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserAll.GridControl = this.grdUserAll;
            this.grvUserAll.IndicatorWidth = 50;
            this.grvUserAll.Name = "grvUserAll";
            this.grvUserAll.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUserAll.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUserAll.OptionsDetail.AllowZoomDetail = false;
            this.grvUserAll.OptionsDetail.EnableMasterViewMode = false;
            this.grvUserAll.OptionsDetail.ShowDetailTabs = false;
            this.grvUserAll.OptionsDetail.SmartDetailExpand = false;
            this.grvUserAll.OptionsSelection.MultiSelect = true;
            this.grvUserAll.OptionsView.EnableAppearanceEvenRow = true;
            this.grvUserAll.OptionsView.ShowGroupPanel = false;
            this.grvUserAll.RowHeight = 25;
            this.grvUserAll.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserAddress, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvUserAll.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvUserAll_CustomDrawRowIndicator);
            // 
            // colUserAddress
            // 
            this.colUserAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserAddress.Caption = "Address";
            this.colUserAddress.FieldName = "Address";
            this.colUserAddress.MinWidth = 80;
            this.colUserAddress.Name = "colUserAddress";
            this.colUserAddress.OptionsColumn.AllowEdit = false;
            this.colUserAddress.OptionsColumn.FixedWidth = true;
            this.colUserAddress.OptionsColumn.ReadOnly = true;
            this.colUserAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colUserAddress.Visible = true;
            this.colUserAddress.VisibleIndex = 2;
            this.colUserAddress.Width = 80;
            // 
            // colUserType
            // 
            this.colUserType.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserType.Caption = "Type";
            this.colUserType.FieldName = "DataType";
            this.colUserType.MinWidth = 70;
            this.colUserType.Name = "colUserType";
            this.colUserType.OptionsColumn.AllowEdit = false;
            this.colUserType.OptionsColumn.FixedWidth = true;
            this.colUserType.OptionsColumn.ReadOnly = true;
            this.colUserType.Visible = true;
            this.colUserType.VisibleIndex = 3;
            this.colUserType.Width = 100;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colUserName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.Caption = "Name ( Input Text )";
            this.colUserName.FieldName = "Name";
            this.colUserName.MinWidth = 200;
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.FixedWidth = true;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 200;
            // 
            // colUserShow
            // 
            this.colUserShow.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserShow.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserShow.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserShow.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colUserShow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserShow.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserShow.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserShow.Caption = "Show";
            this.colUserShow.ColumnEdit = this.exShowCheck;
            this.colUserShow.FieldName = "DetailViewShow";
            this.colUserShow.MinWidth = 50;
            this.colUserShow.Name = "colUserShow";
            this.colUserShow.OptionsColumn.AllowEdit = false;
            this.colUserShow.OptionsColumn.FixedWidth = true;
            this.colUserShow.OptionsColumn.ReadOnly = true;
            this.colUserShow.Visible = true;
            this.colUserShow.VisibleIndex = 0;
            this.colUserShow.Width = 50;
            // 
            // exShowCheck
            // 
            this.exShowCheck.AutoHeight = false;
            this.exShowCheck.Name = "exShowCheck";
            // 
            // pnlUserControl
            // 
            this.pnlUserControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlUserControl.Controls.Add(this.btnUserDeviceAllClear);
            this.pnlUserControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserControl.Location = new System.Drawing.Point(0, 282);
            this.pnlUserControl.Name = "pnlUserControl";
            this.pnlUserControl.Size = new System.Drawing.Size(502, 40);
            this.pnlUserControl.TabIndex = 8;
            // 
            // btnUserDeviceAllClear
            // 
            this.btnUserDeviceAllClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUserDeviceAllClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserDeviceAllClear.Image = ((System.Drawing.Image)(resources.GetObject("btnUserDeviceAllClear.Image")));
            this.btnUserDeviceAllClear.Location = new System.Drawing.Point(394, 0);
            this.btnUserDeviceAllClear.Name = "btnUserDeviceAllClear";
            this.btnUserDeviceAllClear.Size = new System.Drawing.Size(108, 40);
            this.btnUserDeviceAllClear.TabIndex = 0;
            this.btnUserDeviceAllClear.Text = "All Clear";
            this.btnUserDeviceAllClear.Click += new System.EventHandler(this.btnUserDeviceAllClear_Click);
            // 
            // tpRobotCycle
            // 
            this.tpRobotCycle.Controls.Add(this.grdRobotCycle);
            this.tpRobotCycle.Controls.Add(this.pnlRobotControl);
            this.tpRobotCycle.Name = "tpRobotCycle";
            this.tpRobotCycle.Size = new System.Drawing.Size(502, 322);
            this.tpRobotCycle.Text = "Robot Cycle";
            // 
            // grdRobotCycle
            // 
            this.grdRobotCycle.AllowDrop = true;
            this.grdRobotCycle.ContextMenuStrip = this.cntxlMenu;
            this.grdRobotCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRobotCycle.Location = new System.Drawing.Point(0, 0);
            this.grdRobotCycle.MainView = this.grvRobotCycle;
            this.grdRobotCycle.Name = "grdRobotCycle";
            this.grdRobotCycle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdRobotCycle.Size = new System.Drawing.Size(502, 282);
            this.grdRobotCycle.TabIndex = 8;
            this.grdRobotCycle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRobotCycle});
            this.grdRobotCycle.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdRobotCycle_DragDrop);
            this.grdRobotCycle.DragOver += new System.Windows.Forms.DragEventHandler(this.grdRobotCycle_DragOver);
            // 
            // grvRobotCycle
            // 
            this.grvRobotCycle.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvRobotCycle.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRobotCycle.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvRobotCycle.Appearance.Row.Options.UseFont = true;
            this.grvRobotCycle.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvRobotCycle.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvRobotCycle.ColumnPanelRowHeight = 25;
            this.grvRobotCycle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.grvRobotCycle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRobotCycle.GridControl = this.grdRobotCycle;
            this.grvRobotCycle.IndicatorWidth = 50;
            this.grvRobotCycle.Name = "grvRobotCycle";
            this.grvRobotCycle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRobotCycle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvRobotCycle.OptionsDetail.AllowZoomDetail = false;
            this.grvRobotCycle.OptionsDetail.EnableMasterViewMode = false;
            this.grvRobotCycle.OptionsDetail.ShowDetailTabs = false;
            this.grvRobotCycle.OptionsDetail.SmartDetailExpand = false;
            this.grvRobotCycle.OptionsSelection.MultiSelect = true;
            this.grvRobotCycle.OptionsView.EnableAppearanceEvenRow = true;
            this.grvRobotCycle.OptionsView.ShowGroupPanel = false;
            this.grvRobotCycle.RowHeight = 25;
            this.grvRobotCycle.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvRobotCycle.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRobotCycle_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Address";
            this.gridColumn1.MinWidth = 80;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Comment";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.MinWidth = 200;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 200;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // pnlRobotControl
            // 
            this.pnlRobotControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRobotControl.Controls.Add(this.btnRobotAllClear);
            this.pnlRobotControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRobotControl.Location = new System.Drawing.Point(0, 282);
            this.pnlRobotControl.Name = "pnlRobotControl";
            this.pnlRobotControl.Size = new System.Drawing.Size(502, 40);
            this.pnlRobotControl.TabIndex = 9;
            // 
            // btnRobotAllClear
            // 
            this.btnRobotAllClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRobotAllClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRobotAllClear.Image = ((System.Drawing.Image)(resources.GetObject("btnRobotAllClear.Image")));
            this.btnRobotAllClear.Location = new System.Drawing.Point(394, 0);
            this.btnRobotAllClear.Name = "btnRobotAllClear";
            this.btnRobotAllClear.Size = new System.Drawing.Size(108, 40);
            this.btnRobotAllClear.TabIndex = 0;
            this.btnRobotAllClear.Text = "All Clear";
            this.btnRobotAllClear.Click += new System.EventHandler(this.btnRobotAllClear_Click);
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
            this.grpTagTable.Size = new System.Drawing.Size(1226, 773);
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
            this.grdTotalTagS.Location = new System.Drawing.Point(2, 71);
            this.grdTotalTagS.MainView = this.grvTotalTagS;
            this.grdTotalTagS.Name = "grdTotalTagS";
            this.grdTotalTagS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdTotalTagS.Size = new System.Drawing.Size(1222, 700);
            this.grdTotalTagS.TabIndex = 1;
            this.grdTotalTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotalTagS});
            this.grdTotalTagS.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdTotalTagS_DragDrop);
            this.grdTotalTagS.DragOver += new System.Windows.Forms.DragEventHandler(this.grdTotalTagS_DragOver);
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.btnShowAllTag);
            this.panelControl1.Controls.Add(this.chkFilterAddress);
            this.panelControl1.Controls.Add(this.btnTest);
            this.panelControl1.Controls.Add(this.btnValidateCheck);
            this.panelControl1.Controls.Add(this.btnTagDelete);
            this.panelControl1.Controls.Add(this.btnTagAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1222, 46);
            this.panelControl1.TabIndex = 2;
            // 
            // chkFilterAddress
            // 
            this.chkFilterAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.chkFilterAddress.Appearance.Options.UseFont = true;
            this.chkFilterAddress.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkFilterAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkFilterAddress.Image = ((System.Drawing.Image)(resources.GetObject("chkFilterAddress.Image")));
            this.chkFilterAddress.Location = new System.Drawing.Point(515, 2);
            this.chkFilterAddress.Name = "chkFilterAddress";
            this.chkFilterAddress.Size = new System.Drawing.Size(150, 42);
            this.chkFilterAddress.TabIndex = 4;
            this.chkFilterAddress.Text = "User Address\r\nFilter";
            this.chkFilterAddress.ToolTip = "체크 버튼입니다.\r\n누르면 새로운 창이 열리고 사용자가 선택한 PLC 주소를 입력하면 \r\nTag Table에 필터되어 표시됩니다.\r\n체크해제하면 " +
    "전체 Tag가 표시됩니다.";
            this.chkFilterAddress.CheckedChanged += new System.EventHandler(this.chkFilterAddress_CheckedChanged);
            // 
            // btnTest
            // 
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTest.Location = new System.Drawing.Point(1058, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(162, 42);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Siemens Timer TEST";
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnValidateCheck
            // 
            this.btnValidateCheck.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnValidateCheck.Appearance.Options.UseFont = true;
            this.btnValidateCheck.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnValidateCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnValidateCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnValidateCheck.Image")));
            this.btnValidateCheck.Location = new System.Drawing.Point(273, 2);
            this.btnValidateCheck.Name = "btnValidateCheck";
            this.btnValidateCheck.Size = new System.Drawing.Size(242, 42);
            this.btnValidateCheck.TabIndex = 2;
            this.btnValidateCheck.Text = "Selected Tag Validate Check";
            this.btnValidateCheck.Click += new System.EventHandler(this.btnValidateCheck_Click);
            // 
            // btnTagDelete
            // 
            this.btnTagDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnTagDelete.Appearance.Options.UseFont = true;
            this.btnTagDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnTagDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTagDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnTagDelete.Image")));
            this.btnTagDelete.Location = new System.Drawing.Point(124, 2);
            this.btnTagDelete.Name = "btnTagDelete";
            this.btnTagDelete.Size = new System.Drawing.Size(149, 42);
            this.btnTagDelete.TabIndex = 1;
            this.btnTagDelete.Text = "Remove Tag";
            this.btnTagDelete.Click += new System.EventHandler(this.btnTagDelete_Click);
            // 
            // btnTagAdd
            // 
            this.btnTagAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnTagAdd.Appearance.Options.UseFont = true;
            this.btnTagAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnTagAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTagAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnTagAdd.Image")));
            this.btnTagAdd.Location = new System.Drawing.Point(2, 2);
            this.btnTagAdd.Name = "btnTagAdd";
            this.btnTagAdd.Size = new System.Drawing.Size(122, 42);
            this.btnTagAdd.TabIndex = 0;
            this.btnTagAdd.Text = "Add Tag";
            this.btnTagAdd.Click += new System.EventHandler(this.btnTagAdd_Click);
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
            // btnShowAllTag
            // 
            this.btnShowAllTag.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnShowAllTag.Appearance.Options.UseFont = true;
            this.btnShowAllTag.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnShowAllTag.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowAllTag.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAllTag.Image")));
            this.btnShowAllTag.Location = new System.Drawing.Point(919, 2);
            this.btnShowAllTag.Name = "btnShowAllTag";
            this.btnShowAllTag.Size = new System.Drawing.Size(139, 42);
            this.btnShowAllTag.TabIndex = 5;
            this.btnShowAllTag.Text = "Show All Tag";
            this.btnShowAllTag.Click += new System.EventHandler(this.btnShowAllTag_Click);
            // 
            // FrmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 951);
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
            this.Text = "Project 설정";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModel_FormClosing);
            this.Load += new System.EventHandler(this.FrmModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exModelRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDescriptionFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgListRibbonLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorAddressFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exMasterPatternMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptModelMain)).EndInit();
            this.sptModelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptTree)).EndInit();
            this.sptTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabTable)).EndInit();
            this.TabTable.ResumeLayout(false);
            this.tpPLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcList)).EndInit();
            this.grpPlcList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.cntxPLCMenu.ResumeLayout(false);
            this.tpProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabUserSet)).EndInit();
            this.tabUserSet.ResumeLayout(false);
            this.tpUserDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserAll)).EndInit();
            this.cntxlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvUserAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exShowCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUserControl)).EndInit();
            this.pnlUserControl.ResumeLayout(false);
            this.tpRobotCycle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRobotCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobotCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRobotControl)).EndInit();
            this.pnlRobotControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTagTable)).EndInit();
            this.grpTagTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).EndInit();
            this.cntxTotalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exModelRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgBaseSet;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnConvert;
        private DevExpress.XtraBars.BarButtonItem btnConfigSet;
        private UDM.UI.MySplitContainerControl sptModelMain;
        private DevExpress.XtraEditors.GroupControl grpPlcList;
        private DevExpress.XtraEditors.GroupControl grpTagTable;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorAddressFilter;
        private DevExpress.XtraBars.BarEditItem txtDescriptionFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit exEditorDescriptionFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuFilter;
        private DevExpress.XtraBars.BarButtonItem btnClear;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuControl;
        private DevExpress.XtraBars.BarButtonItem btnFilterApply;
        private UDM.UI.MySplitContainerControl sptTree;
        private System.Windows.Forms.ContextMenuStrip cntxlMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSymbolS;
        private DevExpress.XtraBars.BarButtonItem btnAddPlc;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandPlcMaker;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandConnetType;
        private DevExpress.XtraTreeList.Columns.TreeListBand tbandPlcName;
        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPLCName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaker;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cntxPLCMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuDeletePLC;
        private System.Windows.Forms.ToolStripSeparator mnuSplitterMonitor1;
        private System.Windows.Forms.ToolStripMenuItem mnuPLCChangeConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuRenamePLC;
        private DevExpress.XtraBars.BarButtonItem btnProcessAdd;
        private DevExpress.XtraTab.XtraTabControl TabTable;
        private DevExpress.XtraTab.XtraTabPage tpPLC;
        private DevExpress.XtraTab.XtraTabPage tpProcess;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCProcessTree ucProcessTree;
        private DevExpress.XtraBars.BarButtonItem btnProcessSetting;
        private DevExpress.XtraTab.XtraTabControl tabUserSet;
        private DevExpress.XtraTab.XtraTabPage tpUserDevice;
        private DevExpress.XtraGrid.GridControl grdUserAll;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserAll;
        private DevExpress.XtraGrid.Columns.GridColumn colUserAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colUserType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exShowCheck;
        private DevExpress.XtraTab.XtraTabPage tpRobotCycle;
        private DevExpress.XtraGrid.GridControl grdRobotCycle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRobotCycle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem btnRecipeSet;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraBars.BarButtonItem btnErrorMonitoringAdd;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private DevExpress.XtraGrid.Columns.GridColumn colCoil;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTagDelete;
        private DevExpress.XtraEditors.SimpleButton btnTagAdd;
        private DevExpress.XtraEditors.SimpleButton btnValidateCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colUsed;
        private System.Windows.Forms.ToolStripMenuItem btnUpdatePLCProgram;
        private DevExpress.XtraBars.BarButtonItem btnCreateMasterPattern;
        private DevExpress.Utils.ImageCollection imgListRibbonLarge;
        private DevExpress.XtraBars.BarButtonItem btnViewMasterPattern;
        private DevExpress.XtraBars.BarButtonItem btnAllCreateMaster;
        private DevExpress.XtraBars.BarEditItem cboSelectedCreateMaster;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorProcess;
        private DevExpress.XtraBars.PopupMenu exMasterPatternMenu;
        private DevExpress.XtraBars.BarStaticItem lblText;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMasterPattern;
        private System.Windows.Forms.ContextMenuStrip cntxTotalTag;
        private System.Windows.Forms.ToolStripMenuItem btnLadderView;
        private DevExpress.XtraBars.BarButtonItem btnAbnormalStructure;
        private DevExpress.XtraBars.BarButtonItem btnMasterPatternClear;
        private DevExpress.XtraBars.BarButtonItem btnManualMasterPattern;
        private DevExpress.XtraBars.BarCheckItem chkRecipeUpdate;
        private DevExpress.XtraBars.BarEditItem spnCycleCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarCheckItem chkAbnormalPriority;
        private DevExpress.XtraBars.BarButtonItem btnNonDetectTimeSetting;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraBars.BarEditItem spnCollectDepth;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraBars.BarButtonItem btnDepthApply;
        private DevExpress.XtraEditors.CheckButton chkFilterAddress;
        private DevExpress.XtraEditors.PanelControl pnlUserControl;
        private DevExpress.XtraEditors.SimpleButton btnUserDeviceAllClear;
        private DevExpress.XtraEditors.PanelControl pnlRobotControl;
        private DevExpress.XtraEditors.SimpleButton btnRobotAllClear;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPLCID;
        private DevExpress.XtraEditors.SimpleButton btnShowAllTag;
    }
}