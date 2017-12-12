namespace UDMPLCLogicAnalyzer
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.rbMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogicAnalysis = new DevExpress.XtraBars.BarButtonItem();
            this.rpHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgAnalysis = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpSingle = new DevExpress.XtraTab.XtraTabPage();
            this.sptAnalyzer = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpPLCData = new DevExpress.XtraEditors.GroupControl();
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
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.btnCompareDouble = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnRemovePLC = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAnalyzer = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSpare2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddPLC = new DevExpress.XtraEditors.SimpleButton();
            this.pnlSpace = new DevExpress.XtraEditors.PanelControl();
            this.tabAnalyzer = new DevExpress.XtraTab.XtraTabControl();
            this.tpDoubleCoil = new DevExpress.XtraTab.XtraTabPage();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.cntxDoubleCoil = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpLogicCompare = new DevExpress.XtraTab.XtraTabPage();
            this.sptLogicCompare = new DevExpress.XtraEditors.SplitContainerControl();
            this.sptTagCompare = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabCompare = new DevExpress.XtraTab.XtraTabControl();
            this.tpBase = new DevExpress.XtraTab.XtraTabPage();
            this.grdTagCompare = new DevExpress.XtraGrid.GridControl();
            this.grvTagCompare = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompareTagAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseTagAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagPlcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFailComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogicCompare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagCompare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompareIsCoil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatchPersent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpChangeLogic = new DevExpress.XtraTab.XtraTabPage();
            this.grdAfterChangeLogic = new DevExpress.XtraGrid.GridControl();
            this.grvAfterChangeLogic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpAddLogic = new DevExpress.XtraTab.XtraTabPage();
            this.grdAfterAddLogic = new DevExpress.XtraGrid.GridControl();
            this.grvAfterAddLogic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabLogicAnalysisDetail = new DevExpress.XtraTab.XtraTabControl();
            this.tpAnalysisResult = new DevExpress.XtraTab.XtraTabPage();
            this.txtAnalysisResult = new System.Windows.Forms.TextBox();
            this.tpLogicStepDetail = new DevExpress.XtraTab.XtraTabPage();
            this.sptTagStepRole = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpBaseTagStep = new DevExpress.XtraEditors.GroupControl();
            this.grdBaseTagStep = new DevExpress.XtraGrid.GridControl();
            this.grvBaseTagStep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBaseTagStepKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseTagRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpCompareTagStep = new DevExpress.XtraEditors.GroupControl();
            this.grdCompareTagStep = new DevExpress.XtraGrid.GridControl();
            this.grvCompareTagStep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCompareTagStepKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompareTagRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sptLadderView = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpBaseLadder = new DevExpress.XtraEditors.GroupControl();
            this.ucLadderPanelBase = new UDMPLCLogicAnalyzer.UCLadderPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucLadderPanelCompare = new UDMPLCLogicAnalyzer.UCLadderPanel();
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptAnalyzer)).BeginInit();
            this.sptAnalyzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPLCData)).BeginInit();
            this.grpPLCData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).BeginInit();
            this.cntxTotalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpare2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAnalyzer)).BeginInit();
            this.tabAnalyzer.SuspendLayout();
            this.tpDoubleCoil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.cntxDoubleCoil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.tpLogicCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptLogicCompare)).BeginInit();
            this.sptLogicCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptTagCompare)).BeginInit();
            this.sptTagCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCompare)).BeginInit();
            this.tabCompare.SuspendLayout();
            this.tpBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTagCompare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagCompare)).BeginInit();
            this.tpChangeLogic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAfterChangeLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAfterChangeLogic)).BeginInit();
            this.tpAddLogic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAfterAddLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAfterAddLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLogicAnalysisDetail)).BeginInit();
            this.tabLogicAnalysisDetail.SuspendLayout();
            this.tpAnalysisResult.SuspendLayout();
            this.tpLogicStepDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptTagStepRole)).BeginInit();
            this.sptTagStepRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBaseTagStep)).BeginInit();
            this.grpBaseTagStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseTagStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaseTagStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompareTagStep)).BeginInit();
            this.grpCompareTagStep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompareTagStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompareTagStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptLadderView)).BeginInit();
            this.sptLadderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBaseLadder)).BeginInit();
            this.grpBaseLadder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMain
            // 
            this.rbMain.ExpandCollapseItem.Id = 0;
            this.rbMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rbMain.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnExit,
            this.btnLogicAnalysis});
            this.rbMain.Location = new System.Drawing.Point(0, 0);
            this.rbMain.MaxItemId = 6;
            this.rbMain.Name = "rbMain";
            this.rbMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpHome});
            this.rbMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.rbMain.Size = new System.Drawing.Size(1513, 80);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 1;
            this.btnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNew.LargeGlyph")));
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.Glyph")));
            this.btnOpen.Id = 2;
            this.btnOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.LargeGlyph")));
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 3;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 4;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnLogicAnalysis
            // 
            this.btnLogicAnalysis.Caption = "Logic Analysis";
            this.btnLogicAnalysis.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogicAnalysis.Glyph")));
            this.btnLogicAnalysis.Id = 5;
            this.btnLogicAnalysis.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogicAnalysis.LargeGlyph")));
            this.btnLogicAnalysis.Name = "btnLogicAnalysis";
            this.btnLogicAnalysis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogicAnalysis_ItemClick);
            // 
            // rpHome
            // 
            this.rpHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgFile,
            this.rpgAnalysis});
            this.rpHome.Name = "rpHome";
            this.rpHome.Text = "HOME";
            // 
            // rpgFile
            // 
            this.rpgFile.ItemLinks.Add(this.btnNew);
            this.rpgFile.ItemLinks.Add(this.btnOpen);
            this.rpgFile.ItemLinks.Add(this.btnSave);
            this.rpgFile.ItemLinks.Add(this.btnExit);
            this.rpgFile.Name = "rpgFile";
            this.rpgFile.Text = "File";
            // 
            // rpgAnalysis
            // 
            this.rpgAnalysis.ItemLinks.Add(this.btnLogicAnalysis);
            this.rpgAnalysis.Name = "rpgAnalysis";
            this.rpgAnalysis.Text = "Analysis";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 80);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpSingle;
            this.tabMain.Size = new System.Drawing.Size(1513, 878);
            this.tabMain.TabIndex = 1;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSingle,
            this.tpLogicCompare});
            // 
            // tpSingle
            // 
            this.tpSingle.Controls.Add(this.sptAnalyzer);
            this.tpSingle.Name = "tpSingle";
            this.tpSingle.Size = new System.Drawing.Size(1507, 849);
            this.tpSingle.Text = "Analyzer";
            // 
            // sptAnalyzer
            // 
            this.sptAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptAnalyzer.Location = new System.Drawing.Point(0, 0);
            this.sptAnalyzer.Name = "sptAnalyzer";
            this.sptAnalyzer.Panel1.Controls.Add(this.grpPLCData);
            this.sptAnalyzer.Panel1.Text = "Panel1";
            this.sptAnalyzer.Panel2.Controls.Add(this.tabAnalyzer);
            this.sptAnalyzer.Panel2.Text = "Panel2";
            this.sptAnalyzer.Size = new System.Drawing.Size(1507, 849);
            this.sptAnalyzer.SplitterPosition = 771;
            this.sptAnalyzer.TabIndex = 1;
            this.sptAnalyzer.Text = "splitContainerControl1";
            // 
            // grpPLCData
            // 
            this.grpPLCData.Controls.Add(this.grdTotalTagS);
            this.grpPLCData.Controls.Add(this.pnlControl);
            this.grpPLCData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPLCData.Location = new System.Drawing.Point(0, 0);
            this.grpPLCData.Name = "grpPLCData";
            this.grpPLCData.Size = new System.Drawing.Size(771, 849);
            this.grpPLCData.TabIndex = 0;
            this.grpPLCData.Text = "PLC Logic Data";
            // 
            // grdTotalTagS
            // 
            this.grdTotalTagS.AllowDrop = true;
            this.grdTotalTagS.ContextMenuStrip = this.cntxTotalTag;
            this.grdTotalTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdTotalTagS.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdTotalTagS.Location = new System.Drawing.Point(2, 70);
            this.grdTotalTagS.MainView = this.grvTotalTagS;
            this.grdTotalTagS.Name = "grdTotalTagS";
            this.grdTotalTagS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdTotalTagS.Size = new System.Drawing.Size(767, 777);
            this.grdTotalTagS.TabIndex = 2;
            this.grdTotalTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotalTagS});
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
            this.btnLadderView.Click += new System.EventHandler(this.btnLadderView_Click);
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
            this.grvTotalTagS.GroupRowHeight = 40;
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
            this.colAddress.Width = 216;
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
            this.colDataType.Width = 144;
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
            this.colDescription.Width = 180;
            // 
            // colChannel
            // 
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Channel";
            this.colChannel.FieldName = "Channel";
            this.colChannel.Name = "colChannel";
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
            this.colName.Width = 237;
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
            this.colCoil.VisibleIndex = 3;
            this.colCoil.Width = 60;
            // 
            // colUsed
            // 
            this.colUsed.Caption = "Logic Used";
            this.colUsed.FieldName = "UseOnlyInLogic";
            this.colUsed.MaxWidth = 50;
            this.colUsed.MinWidth = 50;
            this.colUsed.Name = "colUsed";
            this.colUsed.Visible = true;
            this.colUsed.VisibleIndex = 4;
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
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCompareDouble);
            this.pnlControl.Controls.Add(this.panelControl3);
            this.pnlControl.Controls.Add(this.btnRemovePLC);
            this.pnlControl.Controls.Add(this.panelControl1);
            this.pnlControl.Controls.Add(this.btnAnalyzer);
            this.pnlControl.Controls.Add(this.pnlSpare2);
            this.pnlControl.Controls.Add(this.btnAddPLC);
            this.pnlControl.Controls.Add(this.pnlSpace);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(2, 21);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(767, 49);
            this.pnlControl.TabIndex = 0;
            // 
            // btnCompareDouble
            // 
            this.btnCompareDouble.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCompareDouble.Image = ((System.Drawing.Image)(resources.GetObject("btnCompareDouble.Image")));
            this.btnCompareDouble.Location = new System.Drawing.Point(215, 2);
            this.btnCompareDouble.Name = "btnCompareDouble";
            this.btnCompareDouble.Size = new System.Drawing.Size(215, 45);
            this.btnCompareDouble.TabIndex = 8;
            this.btnCompareDouble.Text = "비교 PLC 이중코일";
            this.btnCompareDouble.Click += new System.EventHandler(this.btnCompareDouble_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(210, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(5, 45);
            this.panelControl3.TabIndex = 7;
            // 
            // btnRemovePLC
            // 
            this.btnRemovePLC.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemovePLC.Image = ((System.Drawing.Image)(resources.GetObject("btnRemovePLC.Image")));
            this.btnRemovePLC.Location = new System.Drawing.Point(511, 2);
            this.btnRemovePLC.Name = "btnRemovePLC";
            this.btnRemovePLC.Size = new System.Drawing.Size(122, 45);
            this.btnRemovePLC.TabIndex = 6;
            this.btnRemovePLC.Text = "Remove PLC";
            this.btnRemovePLC.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(633, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(5, 45);
            this.panelControl1.TabIndex = 5;
            // 
            // btnAnalyzer
            // 
            this.btnAnalyzer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAnalyzer.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyzer.Image")));
            this.btnAnalyzer.Location = new System.Drawing.Point(7, 2);
            this.btnAnalyzer.Name = "btnAnalyzer";
            this.btnAnalyzer.Size = new System.Drawing.Size(203, 45);
            this.btnAnalyzer.TabIndex = 4;
            this.btnAnalyzer.Text = "기준 PLC 이중코일";
            this.btnAnalyzer.Click += new System.EventHandler(this.btnAnalyzer_Click);
            // 
            // pnlSpare2
            // 
            this.pnlSpare2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSpare2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpare2.Location = new System.Drawing.Point(2, 2);
            this.pnlSpare2.Name = "pnlSpare2";
            this.pnlSpare2.Size = new System.Drawing.Size(5, 45);
            this.pnlSpare2.TabIndex = 3;
            // 
            // btnAddPLC
            // 
            this.btnAddPLC.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddPLC.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPLC.Image")));
            this.btnAddPLC.Location = new System.Drawing.Point(638, 2);
            this.btnAddPLC.Name = "btnAddPLC";
            this.btnAddPLC.Size = new System.Drawing.Size(122, 45);
            this.btnAddPLC.TabIndex = 2;
            this.btnAddPLC.Text = "Add PLC";
            this.btnAddPLC.Click += new System.EventHandler(this.btnAddPLC_Click);
            // 
            // pnlSpace
            // 
            this.pnlSpace.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSpace.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpace.Location = new System.Drawing.Point(760, 2);
            this.pnlSpace.Name = "pnlSpace";
            this.pnlSpace.Size = new System.Drawing.Size(5, 45);
            this.pnlSpace.TabIndex = 1;
            // 
            // tabAnalyzer
            // 
            this.tabAnalyzer.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tabAnalyzer.Appearance.Options.UseFont = true;
            this.tabAnalyzer.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tabAnalyzer.AppearancePage.Header.Options.UseFont = true;
            this.tabAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAnalyzer.Location = new System.Drawing.Point(0, 0);
            this.tabAnalyzer.Name = "tabAnalyzer";
            this.tabAnalyzer.SelectedTabPage = this.tpDoubleCoil;
            this.tabAnalyzer.Size = new System.Drawing.Size(731, 849);
            this.tabAnalyzer.TabIndex = 0;
            this.tabAnalyzer.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDoubleCoil});
            // 
            // tpDoubleCoil
            // 
            this.tpDoubleCoil.Controls.Add(this.grdData);
            this.tpDoubleCoil.Name = "tpDoubleCoil";
            this.tpDoubleCoil.Size = new System.Drawing.Size(725, 813);
            this.tpDoubleCoil.Text = "이중코일";
            // 
            // grdData
            // 
            this.grdData.ContextMenuStrip = this.cntxDoubleCoil;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(725, 813);
            this.grdData.TabIndex = 1;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // cntxDoubleCoil
            // 
            this.cntxDoubleCoil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cntxDoubleCoil.Name = "cntxTotalTag";
            this.cntxDoubleCoil.Size = new System.Drawing.Size(195, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "선택 접점 Ladder 보기";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.GroupRow.BackColor = System.Drawing.Color.Red;
            this.grvData.Appearance.GroupRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grvData.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.grvData.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.grvData.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvData.Appearance.GroupRow.Options.UseFont = true;
            this.grvData.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvData.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvData.Appearance.Row.Options.UseFont = true;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colComment,
            this.colStepNumber,
            this.colProgram,
            this.colNumber,
            this.colCPU});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 2;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grvData.OptionsBehavior.ReadOnly = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.OptionsView.ShowIndicator = false;
            this.grvData.PaintStyleName = "Flat";
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCPU, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNumber, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Tag.Address";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 193;
            // 
            // colComment
            // 
            this.colComment.Caption = "Comment";
            this.colComment.FieldName = "Tag.Name";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;
            this.colComment.Width = 423;
            // 
            // colStepNumber
            // 
            this.colStepNumber.Caption = "Step";
            this.colStepNumber.FieldName = "StepNumber";
            this.colStepNumber.Name = "colStepNumber";
            this.colStepNumber.Visible = true;
            this.colStepNumber.VisibleIndex = 1;
            this.colStepNumber.Width = 175;
            // 
            // colProgram
            // 
            this.colProgram.Caption = "Program";
            this.colProgram.FieldName = "Program";
            this.colProgram.Name = "colProgram";
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 0;
            this.colProgram.Width = 144;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "Number";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 2;
            // 
            // colCPU
            // 
            this.colCPU.Caption = "CPU Name";
            this.colCPU.FieldName = "Tag.Creator";
            this.colCPU.Name = "colCPU";
            this.colCPU.Visible = true;
            this.colCPU.VisibleIndex = 3;
            // 
            // tpLogicCompare
            // 
            this.tpLogicCompare.Controls.Add(this.sptLogicCompare);
            this.tpLogicCompare.Name = "tpLogicCompare";
            this.tpLogicCompare.Size = new System.Drawing.Size(1507, 849);
            this.tpLogicCompare.Text = "Logic Compare";
            // 
            // sptLogicCompare
            // 
            this.sptLogicCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptLogicCompare.Location = new System.Drawing.Point(0, 0);
            this.sptLogicCompare.Name = "sptLogicCompare";
            this.sptLogicCompare.Panel1.Controls.Add(this.sptTagCompare);
            this.sptLogicCompare.Panel1.Text = "Panel1";
            this.sptLogicCompare.Panel2.Controls.Add(this.sptLadderView);
            this.sptLogicCompare.Panel2.Text = "Panel2";
            this.sptLogicCompare.Size = new System.Drawing.Size(1507, 849);
            this.sptLogicCompare.SplitterPosition = 947;
            this.sptLogicCompare.TabIndex = 0;
            this.sptLogicCompare.Text = "splitContainerControl1";
            this.sptLogicCompare.SplitterMoved += new System.EventHandler(this.sptLogicCompare_SplitterMoved);
            // 
            // sptTagCompare
            // 
            this.sptTagCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTagCompare.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.sptTagCompare.Horizontal = false;
            this.sptTagCompare.Location = new System.Drawing.Point(0, 0);
            this.sptTagCompare.Name = "sptTagCompare";
            this.sptTagCompare.Panel1.Controls.Add(this.tabCompare);
            this.sptTagCompare.Panel1.Text = "Panel1";
            this.sptTagCompare.Panel2.Controls.Add(this.tabLogicAnalysisDetail);
            this.sptTagCompare.Panel2.Text = "Panel2";
            this.sptTagCompare.Size = new System.Drawing.Size(947, 849);
            this.sptTagCompare.SplitterPosition = 276;
            this.sptTagCompare.TabIndex = 1;
            this.sptTagCompare.Text = "splitContainerControl1";
            // 
            // tabCompare
            // 
            this.tabCompare.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCompare.AppearancePage.Header.Options.UseFont = true;
            this.tabCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCompare.Location = new System.Drawing.Point(0, 0);
            this.tabCompare.Name = "tabCompare";
            this.tabCompare.SelectedTabPage = this.tpBase;
            this.tabCompare.Size = new System.Drawing.Size(947, 568);
            this.tabCompare.TabIndex = 2;
            this.tabCompare.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpBase,
            this.tpChangeLogic,
            this.tpAddLogic});
            this.tabCompare.TabIndexChanged += new System.EventHandler(this.tabCompare_TabIndexChanged);
            // 
            // tpBase
            // 
            this.tpBase.Controls.Add(this.grdTagCompare);
            this.tpBase.Name = "tpBase";
            this.tpBase.Size = new System.Drawing.Size(941, 530);
            this.tpBase.Text = "PLC 1 기준 분석";
            // 
            // grdTagCompare
            // 
            this.grdTagCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTagCompare.Location = new System.Drawing.Point(0, 0);
            this.grdTagCompare.MainView = this.grvTagCompare;
            this.grdTagCompare.MenuManager = this.rbMain;
            this.grdTagCompare.Name = "grdTagCompare";
            this.grdTagCompare.Size = new System.Drawing.Size(941, 530);
            this.grdTagCompare.TabIndex = 0;
            this.grdTagCompare.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTagCompare});
            // 
            // grvTagCompare
            // 
            this.grvTagCompare.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvTagCompare.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTagCompare.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvTagCompare.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvTagCompare.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvTagCompare.Appearance.Row.Options.UseFont = true;
            this.grvTagCompare.ColumnPanelRowHeight = 40;
            this.grvTagCompare.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompareTagAddress,
            this.colBaseTagAddress,
            this.colTagPlcName,
            this.colFailComment,
            this.colTagComment,
            this.colLogicCompare,
            this.colTagCompare,
            this.colCompareIsCoil,
            this.colMatchPersent});
            this.grvTagCompare.FixedLineWidth = 3;
            this.grvTagCompare.GridControl = this.grdTagCompare;
            this.grvTagCompare.GroupCount = 1;
            this.grvTagCompare.IndicatorWidth = 50;
            this.grvTagCompare.Name = "grvTagCompare";
            this.grvTagCompare.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagCompare.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagCompare.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTagCompare.OptionsBehavior.Editable = false;
            this.grvTagCompare.OptionsDetail.EnableMasterViewMode = false;
            this.grvTagCompare.OptionsDetail.ShowDetailTabs = false;
            this.grvTagCompare.OptionsDetail.SmartDetailExpand = false;
            this.grvTagCompare.OptionsSelection.MultiSelect = true;
            this.grvTagCompare.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagCompare.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvTagCompare.OptionsView.ShowAutoFilterRow = true;
            this.grvTagCompare.OptionsView.ShowGroupPanel = false;
            this.grvTagCompare.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTagPlcName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvTagCompare.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvTagCompare_RowClick);
            this.grvTagCompare.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvTagCompare_CustomDrawRowIndicator);
            // 
            // colCompareTagAddress
            // 
            this.colCompareTagAddress.Caption = "비교 Address";
            this.colCompareTagAddress.FieldName = "CompareTag.Address";
            this.colCompareTagAddress.Name = "colCompareTagAddress";
            this.colCompareTagAddress.Visible = true;
            this.colCompareTagAddress.VisibleIndex = 1;
            this.colCompareTagAddress.Width = 140;
            // 
            // colBaseTagAddress
            // 
            this.colBaseTagAddress.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colBaseTagAddress.AppearanceCell.Options.UseBackColor = true;
            this.colBaseTagAddress.Caption = "기준 Address";
            this.colBaseTagAddress.FieldName = "BaseTag.Address";
            this.colBaseTagAddress.Name = "colBaseTagAddress";
            this.colBaseTagAddress.Visible = true;
            this.colBaseTagAddress.VisibleIndex = 0;
            this.colBaseTagAddress.Width = 140;
            // 
            // colTagPlcName
            // 
            this.colTagPlcName.Caption = "PLC Name";
            this.colTagPlcName.FieldName = "PLCID";
            this.colTagPlcName.Name = "colTagPlcName";
            this.colTagPlcName.Visible = true;
            this.colTagPlcName.VisibleIndex = 1;
            // 
            // colFailComment
            // 
            this.colFailComment.Caption = "비교 Comment";
            this.colFailComment.FieldName = "CompareTagComment";
            this.colFailComment.Name = "colFailComment";
            this.colFailComment.Visible = true;
            this.colFailComment.VisibleIndex = 3;
            this.colFailComment.Width = 140;
            // 
            // colTagComment
            // 
            this.colTagComment.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colTagComment.AppearanceCell.Options.UseBackColor = true;
            this.colTagComment.Caption = "기준 Comment";
            this.colTagComment.FieldName = "BaseTagComment";
            this.colTagComment.Name = "colTagComment";
            this.colTagComment.Visible = true;
            this.colTagComment.VisibleIndex = 2;
            this.colTagComment.Width = 140;
            // 
            // colLogicCompare
            // 
            this.colLogicCompare.Caption = "Logic Match";
            this.colLogicCompare.FieldName = "IsLogicMatch";
            this.colLogicCompare.Name = "colLogicCompare";
            this.colLogicCompare.Width = 92;
            // 
            // colTagCompare
            // 
            this.colTagCompare.Caption = "Tag Match";
            this.colTagCompare.FieldName = "IsTagMatch";
            this.colTagCompare.Name = "colTagCompare";
            this.colTagCompare.Visible = true;
            this.colTagCompare.VisibleIndex = 5;
            this.colTagCompare.Width = 92;
            // 
            // colCompareIsCoil
            // 
            this.colCompareIsCoil.Caption = "IsCoil";
            this.colCompareIsCoil.FieldName = "IsCoil";
            this.colCompareIsCoil.Name = "colCompareIsCoil";
            this.colCompareIsCoil.Visible = true;
            this.colCompareIsCoil.VisibleIndex = 4;
            this.colCompareIsCoil.Width = 70;
            // 
            // colMatchPersent
            // 
            this.colMatchPersent.Caption = "Coil Match(%)";
            this.colMatchPersent.FieldName = "PersentString";
            this.colMatchPersent.Name = "colMatchPersent";
            this.colMatchPersent.Visible = true;
            this.colMatchPersent.VisibleIndex = 6;
            this.colMatchPersent.Width = 112;
            // 
            // tpChangeLogic
            // 
            this.tpChangeLogic.Controls.Add(this.grdAfterChangeLogic);
            this.tpChangeLogic.Name = "tpChangeLogic";
            this.tpChangeLogic.Size = new System.Drawing.Size(941, 530);
            this.tpChangeLogic.Text = "시운전 후 변경된 로직";
            // 
            // grdAfterChangeLogic
            // 
            this.grdAfterChangeLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAfterChangeLogic.Location = new System.Drawing.Point(0, 0);
            this.grdAfterChangeLogic.MainView = this.grvAfterChangeLogic;
            this.grdAfterChangeLogic.MenuManager = this.rbMain;
            this.grdAfterChangeLogic.Name = "grdAfterChangeLogic";
            this.grdAfterChangeLogic.Size = new System.Drawing.Size(941, 530);
            this.grdAfterChangeLogic.TabIndex = 1;
            this.grdAfterChangeLogic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAfterChangeLogic});
            // 
            // grvAfterChangeLogic
            // 
            this.grvAfterChangeLogic.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvAfterChangeLogic.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAfterChangeLogic.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvAfterChangeLogic.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvAfterChangeLogic.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvAfterChangeLogic.Appearance.Row.Options.UseFont = true;
            this.grvAfterChangeLogic.ColumnPanelRowHeight = 40;
            this.grvAfterChangeLogic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grvAfterChangeLogic.FixedLineWidth = 3;
            this.grvAfterChangeLogic.GridControl = this.grdAfterChangeLogic;
            this.grvAfterChangeLogic.GroupCount = 1;
            this.grvAfterChangeLogic.IndicatorWidth = 50;
            this.grvAfterChangeLogic.Name = "grvAfterChangeLogic";
            this.grvAfterChangeLogic.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterChangeLogic.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterChangeLogic.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvAfterChangeLogic.OptionsBehavior.Editable = false;
            this.grvAfterChangeLogic.OptionsDetail.EnableMasterViewMode = false;
            this.grvAfterChangeLogic.OptionsDetail.ShowDetailTabs = false;
            this.grvAfterChangeLogic.OptionsDetail.SmartDetailExpand = false;
            this.grvAfterChangeLogic.OptionsSelection.MultiSelect = true;
            this.grvAfterChangeLogic.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterChangeLogic.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvAfterChangeLogic.OptionsView.ShowAutoFilterRow = true;
            this.grvAfterChangeLogic.OptionsView.ShowGroupPanel = false;
            this.grvAfterChangeLogic.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvAfterChangeLogic.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvAddLogicCheck_RowClick);
            this.grvAfterChangeLogic.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvAddLogicCheck_CustomDrawRowIndicator);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "비교 Address";
            this.gridColumn2.FieldName = "CompareTag.Address";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 140;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "기준 Address";
            this.gridColumn3.FieldName = "BaseTag.Address";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 140;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PLC Name";
            this.gridColumn4.FieldName = "PLCID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "비교 Comment";
            this.gridColumn5.FieldName = "CompareTagComment";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 140;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.Caption = "기준 Comment";
            this.gridColumn6.FieldName = "BaseTagComment";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 140;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Logic Match";
            this.gridColumn7.FieldName = "IsLogicMatch";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 92;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tag Match";
            this.gridColumn8.FieldName = "IsTagMatch";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 92;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IsCoil";
            this.gridColumn9.FieldName = "IsCoil";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Width = 70;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Coil Match(%)";
            this.gridColumn10.FieldName = "PersentString";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 112;
            // 
            // tpAddLogic
            // 
            this.tpAddLogic.Controls.Add(this.grdAfterAddLogic);
            this.tpAddLogic.Name = "tpAddLogic";
            this.tpAddLogic.Size = new System.Drawing.Size(941, 530);
            this.tpAddLogic.Text = "시운전 후 추가된 로직";
            // 
            // grdAfterAddLogic
            // 
            this.grdAfterAddLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAfterAddLogic.Location = new System.Drawing.Point(0, 0);
            this.grdAfterAddLogic.MainView = this.grvAfterAddLogic;
            this.grdAfterAddLogic.MenuManager = this.rbMain;
            this.grdAfterAddLogic.Name = "grdAfterAddLogic";
            this.grdAfterAddLogic.Size = new System.Drawing.Size(941, 530);
            this.grdAfterAddLogic.TabIndex = 2;
            this.grdAfterAddLogic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAfterAddLogic});
            // 
            // grvAfterAddLogic
            // 
            this.grvAfterAddLogic.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvAfterAddLogic.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAfterAddLogic.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvAfterAddLogic.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvAfterAddLogic.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvAfterAddLogic.Appearance.Row.Options.UseFont = true;
            this.grvAfterAddLogic.ColumnPanelRowHeight = 40;
            this.grvAfterAddLogic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
            this.grvAfterAddLogic.FixedLineWidth = 3;
            this.grvAfterAddLogic.GridControl = this.grdAfterAddLogic;
            this.grvAfterAddLogic.GroupCount = 1;
            this.grvAfterAddLogic.IndicatorWidth = 50;
            this.grvAfterAddLogic.Name = "grvAfterAddLogic";
            this.grvAfterAddLogic.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterAddLogic.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterAddLogic.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvAfterAddLogic.OptionsBehavior.Editable = false;
            this.grvAfterAddLogic.OptionsDetail.EnableMasterViewMode = false;
            this.grvAfterAddLogic.OptionsDetail.ShowDetailTabs = false;
            this.grvAfterAddLogic.OptionsDetail.SmartDetailExpand = false;
            this.grvAfterAddLogic.OptionsSelection.MultiSelect = true;
            this.grvAfterAddLogic.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.grvAfterAddLogic.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvAfterAddLogic.OptionsView.ShowAutoFilterRow = true;
            this.grvAfterAddLogic.OptionsView.ShowGroupPanel = false;
            this.grvAfterAddLogic.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvAfterAddLogic.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvAfterAddLogic_RowClick);
            this.grvAfterAddLogic.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvAfterAddLogic_CustomDrawRowIndicator);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "비교 Address";
            this.gridColumn11.FieldName = "CompareTag.Address";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 140;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn12.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn12.Caption = "기준 Address";
            this.gridColumn12.FieldName = "BaseTag.Address";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 140;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PLC Name";
            this.gridColumn13.FieldName = "PLCID";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "비교 Comment";
            this.gridColumn14.FieldName = "CompareTagComment";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 140;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn15.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn15.Caption = "기준 Comment";
            this.gridColumn15.FieldName = "BaseTagComment";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 140;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Logic Match";
            this.gridColumn16.FieldName = "IsLogicMatch";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 92;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Tag Match";
            this.gridColumn17.FieldName = "IsTagMatch";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Width = 92;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "IsCoil";
            this.gridColumn18.FieldName = "IsCoil";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Width = 70;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Coil Match(%)";
            this.gridColumn19.FieldName = "PersentString";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 4;
            this.gridColumn19.Width = 112;
            // 
            // tabLogicAnalysisDetail
            // 
            this.tabLogicAnalysisDetail.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLogicAnalysisDetail.AppearancePage.Header.Options.UseFont = true;
            this.tabLogicAnalysisDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLogicAnalysisDetail.Location = new System.Drawing.Point(0, 0);
            this.tabLogicAnalysisDetail.Name = "tabLogicAnalysisDetail";
            this.tabLogicAnalysisDetail.SelectedTabPage = this.tpAnalysisResult;
            this.tabLogicAnalysisDetail.Size = new System.Drawing.Size(947, 276);
            this.tabLogicAnalysisDetail.TabIndex = 3;
            this.tabLogicAnalysisDetail.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpAnalysisResult,
            this.tpLogicStepDetail});
            // 
            // tpAnalysisResult
            // 
            this.tpAnalysisResult.Controls.Add(this.txtAnalysisResult);
            this.tpAnalysisResult.Name = "tpAnalysisResult";
            this.tpAnalysisResult.Size = new System.Drawing.Size(941, 238);
            this.tpAnalysisResult.Text = "분석 결과";
            // 
            // txtAnalysisResult
            // 
            this.txtAnalysisResult.BackColor = System.Drawing.Color.White;
            this.txtAnalysisResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnalysisResult.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnalysisResult.Location = new System.Drawing.Point(0, 0);
            this.txtAnalysisResult.Multiline = true;
            this.txtAnalysisResult.Name = "txtAnalysisResult";
            this.txtAnalysisResult.ReadOnly = true;
            this.txtAnalysisResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnalysisResult.Size = new System.Drawing.Size(941, 238);
            this.txtAnalysisResult.TabIndex = 0;
            // 
            // tpLogicStepDetail
            // 
            this.tpLogicStepDetail.Controls.Add(this.sptTagStepRole);
            this.tpLogicStepDetail.Name = "tpLogicStepDetail";
            this.tpLogicStepDetail.Size = new System.Drawing.Size(941, 238);
            this.tpLogicStepDetail.Text = "Logic Detail";
            // 
            // sptTagStepRole
            // 
            this.sptTagStepRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTagStepRole.Location = new System.Drawing.Point(0, 0);
            this.sptTagStepRole.Name = "sptTagStepRole";
            this.sptTagStepRole.Panel1.Controls.Add(this.grpBaseTagStep);
            this.sptTagStepRole.Panel1.Text = "Panel1";
            this.sptTagStepRole.Panel2.Controls.Add(this.grpCompareTagStep);
            this.sptTagStepRole.Panel2.Text = "Panel2";
            this.sptTagStepRole.Size = new System.Drawing.Size(941, 238);
            this.sptTagStepRole.SplitterPosition = 475;
            this.sptTagStepRole.TabIndex = 2;
            this.sptTagStepRole.Text = "splitContainerControl1";
            // 
            // grpBaseTagStep
            // 
            this.grpBaseTagStep.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpBaseTagStep.Appearance.Options.UseFont = true;
            this.grpBaseTagStep.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpBaseTagStep.AppearanceCaption.Options.UseFont = true;
            this.grpBaseTagStep.Controls.Add(this.grdBaseTagStep);
            this.grpBaseTagStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBaseTagStep.Location = new System.Drawing.Point(0, 0);
            this.grpBaseTagStep.Name = "grpBaseTagStep";
            this.grpBaseTagStep.Size = new System.Drawing.Size(475, 238);
            this.grpBaseTagStep.TabIndex = 1;
            this.grpBaseTagStep.Text = "기준 로직 사용된 Step List";
            // 
            // grdBaseTagStep
            // 
            this.grdBaseTagStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBaseTagStep.Location = new System.Drawing.Point(2, 26);
            this.grdBaseTagStep.MainView = this.grvBaseTagStep;
            this.grdBaseTagStep.MenuManager = this.rbMain;
            this.grdBaseTagStep.Name = "grdBaseTagStep";
            this.grdBaseTagStep.Size = new System.Drawing.Size(471, 210);
            this.grdBaseTagStep.TabIndex = 0;
            this.grdBaseTagStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaseTagStep});
            // 
            // grvBaseTagStep
            // 
            this.grvBaseTagStep.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvBaseTagStep.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaseTagStep.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvBaseTagStep.Appearance.Row.Options.UseFont = true;
            this.grvBaseTagStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBaseTagStepKey,
            this.colBaseTagRoleType});
            this.grvBaseTagStep.GridControl = this.grdBaseTagStep;
            this.grvBaseTagStep.Name = "grvBaseTagStep";
            this.grvBaseTagStep.OptionsBehavior.Editable = false;
            this.grvBaseTagStep.OptionsView.ShowGroupPanel = false;
            this.grvBaseTagStep.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvBaseTagStep_RowStyle);
            // 
            // colBaseTagStepKey
            // 
            this.colBaseTagStepKey.Caption = "Step Number";
            this.colBaseTagStepKey.FieldName = "StepKey";
            this.colBaseTagStepKey.Name = "colBaseTagStepKey";
            this.colBaseTagStepKey.Visible = true;
            this.colBaseTagStepKey.VisibleIndex = 0;
            this.colBaseTagStepKey.Width = 214;
            // 
            // colBaseTagRoleType
            // 
            this.colBaseTagRoleType.Caption = "Type";
            this.colBaseTagRoleType.FieldName = "RoleType";
            this.colBaseTagRoleType.Name = "colBaseTagRoleType";
            this.colBaseTagRoleType.Visible = true;
            this.colBaseTagRoleType.VisibleIndex = 1;
            this.colBaseTagRoleType.Width = 122;
            // 
            // grpCompareTagStep
            // 
            this.grpCompareTagStep.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpCompareTagStep.AppearanceCaption.Options.UseFont = true;
            this.grpCompareTagStep.Controls.Add(this.grdCompareTagStep);
            this.grpCompareTagStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCompareTagStep.Location = new System.Drawing.Point(0, 0);
            this.grpCompareTagStep.Name = "grpCompareTagStep";
            this.grpCompareTagStep.Size = new System.Drawing.Size(461, 238);
            this.grpCompareTagStep.TabIndex = 2;
            this.grpCompareTagStep.Text = "비교 로직 사용된 Step List";
            // 
            // grdCompareTagStep
            // 
            this.grdCompareTagStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCompareTagStep.Location = new System.Drawing.Point(2, 26);
            this.grdCompareTagStep.MainView = this.grvCompareTagStep;
            this.grdCompareTagStep.MenuManager = this.rbMain;
            this.grdCompareTagStep.Name = "grdCompareTagStep";
            this.grdCompareTagStep.Size = new System.Drawing.Size(457, 210);
            this.grdCompareTagStep.TabIndex = 0;
            this.grdCompareTagStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCompareTagStep});
            // 
            // grvCompareTagStep
            // 
            this.grvCompareTagStep.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvCompareTagStep.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCompareTagStep.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvCompareTagStep.Appearance.Row.Options.UseFont = true;
            this.grvCompareTagStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCompareTagStepKey,
            this.colCompareTagRoleType});
            this.grvCompareTagStep.GridControl = this.grdCompareTagStep;
            this.grvCompareTagStep.Name = "grvCompareTagStep";
            this.grvCompareTagStep.OptionsBehavior.Editable = false;
            this.grvCompareTagStep.OptionsView.ShowGroupPanel = false;
            this.grvCompareTagStep.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvBaseTagStep_RowStyle);
            // 
            // colCompareTagStepKey
            // 
            this.colCompareTagStepKey.Caption = "Step Number";
            this.colCompareTagStepKey.FieldName = "StepKey";
            this.colCompareTagStepKey.Name = "colCompareTagStepKey";
            this.colCompareTagStepKey.Visible = true;
            this.colCompareTagStepKey.VisibleIndex = 0;
            this.colCompareTagStepKey.Width = 214;
            // 
            // colCompareTagRoleType
            // 
            this.colCompareTagRoleType.Caption = "Type";
            this.colCompareTagRoleType.FieldName = "RoleType";
            this.colCompareTagRoleType.Name = "colCompareTagRoleType";
            this.colCompareTagRoleType.Visible = true;
            this.colCompareTagRoleType.VisibleIndex = 1;
            this.colCompareTagRoleType.Width = 122;
            // 
            // sptLadderView
            // 
            this.sptLadderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptLadderView.Horizontal = false;
            this.sptLadderView.Location = new System.Drawing.Point(0, 0);
            this.sptLadderView.Name = "sptLadderView";
            this.sptLadderView.Panel1.Controls.Add(this.grpBaseLadder);
            this.sptLadderView.Panel1.Text = "Panel1";
            this.sptLadderView.Panel2.Controls.Add(this.groupControl1);
            this.sptLadderView.Panel2.Text = "Panel2";
            this.sptLadderView.Size = new System.Drawing.Size(555, 849);
            this.sptLadderView.SplitterPosition = 480;
            this.sptLadderView.TabIndex = 0;
            this.sptLadderView.Text = "splitContainerControl1";
            // 
            // grpBaseLadder
            // 
            this.grpBaseLadder.Controls.Add(this.ucLadderPanelBase);
            this.grpBaseLadder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBaseLadder.Location = new System.Drawing.Point(0, 0);
            this.grpBaseLadder.Name = "grpBaseLadder";
            this.grpBaseLadder.Size = new System.Drawing.Size(555, 480);
            this.grpBaseLadder.TabIndex = 0;
            this.grpBaseLadder.Text = "기준 Ladder";
            // 
            // ucLadderPanelBase
            // 
            this.ucLadderPanelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLadderPanelBase.IsLoad = false;
            this.ucLadderPanelBase.Location = new System.Drawing.Point(2, 21);
            this.ucLadderPanelBase.LogicData = null;
            this.ucLadderPanelBase.Name = "ucLadderPanelBase";
            this.ucLadderPanelBase.Size = new System.Drawing.Size(551, 457);
            this.ucLadderPanelBase.Step = null;
            this.ucLadderPanelBase.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucLadderPanelCompare);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(555, 364);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "비교 Ladder";
            // 
            // ucLadderPanelCompare
            // 
            this.ucLadderPanelCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLadderPanelCompare.IsLoad = false;
            this.ucLadderPanelCompare.Location = new System.Drawing.Point(2, 21);
            this.ucLadderPanelCompare.LogicData = null;
            this.ucLadderPanelCompare.Name = "ucLadderPanelCompare";
            this.ucLadderPanelCompare.Size = new System.Drawing.Size(551, 341);
            this.ucLadderPanelCompare.Step = null;
            this.ucLadderPanelCompare.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 958);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.rbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Ribbon = this.rbMain;
            this.Text = "PLC Logic Analyzer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpSingle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptAnalyzer)).EndInit();
            this.sptAnalyzer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPLCData)).EndInit();
            this.grpPLCData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).EndInit();
            this.cntxTotalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpare2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAnalyzer)).EndInit();
            this.tabAnalyzer.ResumeLayout(false);
            this.tpDoubleCoil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.cntxDoubleCoil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.tpLogicCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptLogicCompare)).EndInit();
            this.sptLogicCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptTagCompare)).EndInit();
            this.sptTagCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCompare)).EndInit();
            this.tabCompare.ResumeLayout(false);
            this.tpBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTagCompare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagCompare)).EndInit();
            this.tpChangeLogic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAfterChangeLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAfterChangeLogic)).EndInit();
            this.tpAddLogic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAfterAddLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAfterAddLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLogicAnalysisDetail)).EndInit();
            this.tabLogicAnalysisDetail.ResumeLayout(false);
            this.tpAnalysisResult.ResumeLayout(false);
            this.tpAnalysisResult.PerformLayout();
            this.tpLogicStepDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptTagStepRole)).EndInit();
            this.sptTagStepRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBaseTagStep)).EndInit();
            this.grpBaseTagStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseTagStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaseTagStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCompareTagStep)).EndInit();
            this.grpCompareTagStep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompareTagStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCompareTagStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptLadderView)).EndInit();
            this.sptLadderView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBaseLadder)).EndInit();
            this.grpBaseLadder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rbMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFile;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpSingle;
        private DevExpress.XtraEditors.SplitContainerControl sptAnalyzer;
        private DevExpress.XtraEditors.GroupControl grpPLCData;
        private DevExpress.XtraTab.XtraTabPage tpLogicCompare;
        private DevExpress.XtraEditors.PanelControl pnlControl;
        private DevExpress.XtraEditors.SimpleButton btnAnalyzer;
        private DevExpress.XtraEditors.PanelControl pnlSpare2;
        private DevExpress.XtraEditors.SimpleButton btnAddPLC;
        private DevExpress.XtraEditors.PanelControl pnlSpace;
        private DevExpress.XtraTab.XtraTabControl tabAnalyzer;
        private DevExpress.XtraTab.XtraTabPage tpDoubleCoil;
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
        private DevExpress.XtraEditors.SimpleButton btnRemovePLC;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private System.Windows.Forms.ContextMenuStrip cntxTotalTag;
        private System.Windows.Forms.ToolStripMenuItem btnLadderView;
        private DevExpress.XtraEditors.SplitContainerControl sptLogicCompare;
        private DevExpress.XtraGrid.GridControl grdTagCompare;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTagCompare;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseTagAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTagPlcName;
        private DevExpress.XtraGrid.Columns.GridColumn colFailComment;
        private DevExpress.XtraGrid.Columns.GridColumn colTagComment;
        private DevExpress.XtraGrid.Columns.GridColumn colLogicCompare;
        private DevExpress.XtraEditors.SplitContainerControl sptTagCompare;
        private DevExpress.XtraEditors.GroupControl grpBaseTagStep;
        private DevExpress.XtraGrid.GridControl grdBaseTagStep;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaseTagStep;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseTagStepKey;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseTagRoleType;
        private DevExpress.XtraEditors.SplitContainerControl sptTagStepRole;
        private DevExpress.XtraEditors.GroupControl grpCompareTagStep;
        private DevExpress.XtraGrid.GridControl grdCompareTagStep;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCompareTagStep;
        private DevExpress.XtraGrid.Columns.GridColumn colCompareTagStepKey;
        private DevExpress.XtraGrid.Columns.GridColumn colCompareTagRoleType;
        private DevExpress.XtraEditors.SplitContainerControl sptLadderView;
        private DevExpress.XtraEditors.GroupControl grpBaseLadder;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCLadderPanel ucLadderPanelBase;
        private UCLadderPanel ucLadderPanelCompare;
        private DevExpress.XtraGrid.Columns.GridColumn colTagCompare;
        private DevExpress.XtraGrid.Columns.GridColumn colCompareTagAddress;
        private DevExpress.XtraEditors.SimpleButton btnCompareDouble;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colStepNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCPU;
        private System.Windows.Forms.ContextMenuStrip cntxDoubleCoil;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompareIsCoil;
        private DevExpress.XtraGrid.Columns.GridColumn colMatchPersent;
        private DevExpress.XtraTab.XtraTabControl tabCompare;
        private DevExpress.XtraTab.XtraTabPage tpBase;
        private DevExpress.XtraTab.XtraTabPage tpChangeLogic;
        private DevExpress.XtraGrid.GridControl grdAfterChangeLogic;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAfterChangeLogic;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraBars.BarButtonItem btnLogicAnalysis;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAnalysis;
        private DevExpress.XtraTab.XtraTabControl tabLogicAnalysisDetail;
        private DevExpress.XtraTab.XtraTabPage tpAnalysisResult;
        private System.Windows.Forms.TextBox txtAnalysisResult;
        private DevExpress.XtraTab.XtraTabPage tpLogicStepDetail;
        private DevExpress.XtraTab.XtraTabPage tpAddLogic;
        private DevExpress.XtraGrid.GridControl grdAfterAddLogic;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAfterAddLogic;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
    }
}

