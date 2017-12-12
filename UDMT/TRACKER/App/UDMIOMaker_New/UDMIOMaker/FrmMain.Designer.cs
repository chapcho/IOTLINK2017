namespace UDMIOMaker
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::UDMIOMaker.FrmStartSplash), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.FrmRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenPLC = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenHMI = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportHMI = new DevExpress.XtraBars.BarButtonItem();
            this.mnuExportHMI = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAllHMI = new DevExpress.XtraBars.BarButtonItem();
            this.cboSectionExport = new DevExpress.XtraBars.BarEditItem();
            this.exEditorSectionExport = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cboMappingColor = new DevExpress.XtraBars.BarEditItem();
            this.exEditorColorMatch = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.lblConvert = new DevExpress.XtraBars.BarStaticItem();
            this.lblMatch = new DevExpress.XtraBars.BarStaticItem();
            this.lblInsert = new DevExpress.XtraBars.BarStaticItem();
            this.cboInsert = new DevExpress.XtraBars.BarEditItem();
            this.exEditorColorInsert = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.cboConvert = new DevExpress.XtraBars.BarEditItem();
            this.exEditorColorConvert = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.barItemSkin = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnExportIO = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportDummy = new DevExpress.XtraBars.BarButtonItem();
            this.chkViewIOList = new DevExpress.XtraBars.BarCheckItem();
            this.btnAutoVerification = new DevExpress.XtraBars.BarButtonItem();
            this.txtOptionName = new DevExpress.XtraBars.BarEditItem();
            this.exEditorVerfiOption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnOptionAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerificationExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerificationPDF = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearVerifPLC = new DevExpress.XtraBars.BarButtonItem();
            this.btnVideoMatch = new DevExpress.XtraBars.BarButtonItem();
            this.btnVideoIOList = new DevExpress.XtraBars.BarButtonItem();
            this.btnVideoVerification = new DevExpress.XtraBars.BarButtonItem();
            this.chkOptionApply = new DevExpress.XtraBars.BarButtonItem();
            this.btnAutoMapping = new DevExpress.XtraBars.BarButtonItem();
            this.lblUserOption = new DevExpress.XtraBars.BarStaticItem();
            this.btnHMIClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnAutoHMIVerif = new DevExpress.XtraBars.BarButtonItem();
            this.txtHMIOptionName = new DevExpress.XtraBars.BarEditItem();
            this.exEditorHMIVerifOption = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnHMIOptionAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerifHMIExcelExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerifHMIPDFExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnMappingCheck = new DevExpress.XtraBars.BarButtonItem();
            this.btnStandardDicView = new DevExpress.XtraBars.BarButtonItem();
            this.btnSymbolStandardization = new DevExpress.XtraBars.BarButtonItem();
            this.btnStandardizationApply = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportErrorList = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddressRangeView = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenPLCTag = new DevExpress.XtraBars.BarButtonItem();
            this.btnSymbolNameEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnModuleSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnPLCTagExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewPLC = new DevExpress.XtraBars.BarButtonItem();
            this.btnModeChange = new DevExpress.XtraBars.BarButtonItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnIOList = new DevExpress.XtraBars.BarButtonItem();
            this.btnAboutIOMaker = new DevExpress.XtraBars.BarButtonItem();
            this.btnFileExportGuide = new DevExpress.XtraBars.BarButtonItem();
            this.mnuExportGuide = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnMelsecGuide = new DevExpress.XtraBars.BarButtonItem();
            this.btnSiemensGuide = new DevExpress.XtraBars.BarButtonItem();
            this.btnABGuide = new DevExpress.XtraBars.BarButtonItem();
            this.btnManual = new DevExpress.XtraBars.BarButtonItem();
            this.btnPDFClear = new DevExpress.XtraBars.BarButtonItem();
            this.lblFactory = new DevExpress.XtraBars.BarStaticItem();
            this.lblLine = new DevExpress.XtraBars.BarStaticItem();
            this.txtFactory = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLine = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.chkStandardizationView = new DevExpress.XtraBars.BarCheckItem();
            this.pgHMIMapping = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuPLC = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHMI = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMappingOption = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgPLCSymbolStandardization = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuStandardFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuStandardPLC = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuDesignPLC = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuStandardization = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuStandardExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgPLCVerification = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuPLCVerifFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuPLCVerification = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuUserDefine = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgHMIVerification = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuHMIVerifFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHMIVerification = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuDefHMIVerif = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHMIExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgHelper = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuManual = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuHelpExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.mnuStatusbar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mnuExportPLC = new DevExpress.XtraBars.PopupMenu(this.components);
            this.MouseStatus = new DevExpress.XtraBars.BarButtonItem();
            this.LabelWorkTime = new DevExpress.XtraBars.BarStaticItem();
            this.barMainStatus = new DevExpress.XtraBars.BarStaticItem();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpMapping = new DevExpress.XtraTab.XtraTabPage();
            this.sptMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdPLC = new DevExpress.XtraGrid.GridControl();
            this.grvPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMapping = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLCGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLCKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlPLCEdit = new DevExpress.XtraEditors.PanelControl();
            this.chkPLCEditable = new System.Windows.Forms.CheckBox();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblPLCRowCount = new DevExpress.XtraEditors.LabelControl();
            this.txtPLCRowCount = new DevExpress.XtraEditors.TextEdit();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.grdHMI = new DevExpress.XtraGrid.GridControl();
            this.grvHMI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHMIDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConvert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRedundancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkStation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistedMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHMIEdit = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkHMIEditable = new System.Windows.Forms.CheckBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lblHMIRowCount = new DevExpress.XtraEditors.LabelControl();
            this.txtHMIRowCount = new DevExpress.XtraEditors.TextEdit();
            this.tpPLCVerification = new DevExpress.XtraTab.XtraTabPage();
            this.sptVerification = new DevExpress.XtraEditors.SplitContainerControl();
            this.tabPLCVerif = new DevExpress.XtraTab.XtraTabControl();
            this.tpIOTree = new DevExpress.XtraTab.XtraTabPage();
            this.ucVerifyIOTree = new UDMIOMaker.UCVerifyTree();
            this.tpGrid = new DevExpress.XtraTab.XtraTabPage();
            this.grdVerifPLC = new DevExpress.XtraGrid.GridControl();
            this.grvVerifPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerifPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsedLogic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbolRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpLadderView = new DevExpress.XtraTab.XtraTabPage();
            this.pnlView = new DevExpress.XtraEditors.PanelControl();
            this.pnlLadderView = new DevExpress.XtraEditors.PanelControl();
            this.pnlLadderViewBtn = new DevExpress.XtraEditors.PanelControl();
            this.btnClearLadderView = new DevExpress.XtraEditors.SimpleButton();
            this.tpTagList = new DevExpress.XtraTab.XtraTabPage();
            this.ucVerifyAllTree = new UDMIOMaker.UCVerifyTree();
            this.tabPLCVerif2 = new DevExpress.XtraTab.XtraTabControl();
            this.tpReport = new DevExpress.XtraTab.XtraTabPage();
            this.sheetVerification = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.panelControl22 = new DevExpress.XtraEditors.PanelControl();
            this.btnReportInit = new DevExpress.XtraEditors.SimpleButton();
            this.tpReportElement = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ucVerifyElemTree = new UDMIOMaker.UCVerifyTree();
            this.panelControl21 = new DevExpress.XtraEditors.PanelControl();
            this.btnReportTreeClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnVerifSettingApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnReportElemSetting = new DevExpress.XtraEditors.SimpleButton();
            this.tpHMIVerification = new DevExpress.XtraTab.XtraTabPage();
            this.sptHMIVerification = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdVerifHMI = new DevExpress.XtraGrid.GridControl();
            this.grvVerifHMI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerifNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifHMIName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifHMIDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifHMIAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifHMIDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifIsMatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifIsInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifIsConvert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifIsRedundancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerifIsEmpty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpFilterOption = new System.Windows.Forms.GroupBox();
            this.chkNullEmpty = new DevExpress.XtraEditors.CheckButton();
            this.chkRedundancy = new DevExpress.XtraEditors.CheckButton();
            this.chkMapping = new DevExpress.XtraEditors.CheckButton();
            this.sheetHMIVerification = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.tpHelp = new DevExpress.XtraTab.XtraTabPage();
            this.tabHelp = new DevExpress.XtraTab.XtraTabControl();
            this.tpManual = new DevExpress.XtraTab.XtraTabPage();
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.tpIOList = new DevExpress.XtraTab.XtraTabPage();
            this.pnlIOList = new DevExpress.XtraEditors.PanelControl();
            this.IOSpreadSheet = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.panelControl23 = new DevExpress.XtraEditors.PanelControl();
            this.chkExcelEditable = new DevExpress.XtraEditors.CheckButton();
            this.panelControl24 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSavePathOpen = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl26 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl25 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl27 = new DevExpress.XtraEditors.PanelControl();
            this.btnOpenExcelPath = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcelSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkExcelEdit = new DevExpress.XtraEditors.CheckEdit();
            this.tpDesign = new DevExpress.XtraTab.XtraTabPage();
            this.tabDesign = new DevExpress.XtraTab.XtraTabControl();
            this.tpDesignDesign = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDesign2 = new DevExpress.XtraEditors.PanelControl();
            this.grdDesignPLC = new DevExpress.XtraGrid.GridControl();
            this.grvDesignPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDesignPLC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlDesignControl = new DevExpress.XtraEditors.PanelControl();
            this.chkDesignPLCEditable = new System.Windows.Forms.CheckBox();
            this.panelControl17 = new DevExpress.XtraEditors.PanelControl();
            this.btnAllTagView = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.btnSymbolDelete = new DevExpress.XtraEditors.SimpleButton();
            this.sptDesign = new DevExpress.XtraEditors.SplitterControl();
            this.pnlDesign1 = new DevExpress.XtraEditors.PanelControl();
            this.tabIOData = new DevExpress.XtraTab.XtraTabControl();
            this.tpIOData = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ucIOModule = new UDMIOMaker.UCIOModule();
            this.panelControl16 = new DevExpress.XtraEditors.PanelControl();
            this.btnModuleInfoSetting = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl19 = new DevExpress.XtraEditors.PanelControl();
            this.chkIOUsed = new DevExpress.XtraEditors.CheckEdit();
            this.chkIOExtend = new DevExpress.XtraEditors.CheckEdit();
            this.tpAddressRangeData = new DevExpress.XtraTab.XtraTabPage();
            this.grpAddressArea = new DevExpress.XtraEditors.GroupControl();
            this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl15 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboListType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl13 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboPLCList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRangeDetailView = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
            this.chkUsed = new DevExpress.XtraEditors.CheckEdit();
            this.chkExtend = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl20 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl18 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl10 = new DevExpress.XtraEditors.PanelControl();
            this.tpDesignStandardization = new DevExpress.XtraTab.XtraTabPage();
            this.grdStd = new DevExpress.XtraGrid.GridControl();
            this.grvStd = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrentDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTargetDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLv10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnStandardApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnStandardization = new DevExpress.XtraEditors.SimpleButton();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl14 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.chkStandardization = new DevExpress.XtraEditors.CheckButton();
            this.chkStdLNotExist = new DevExpress.XtraEditors.CheckButton();
            this.chkStdLExist = new DevExpress.XtraEditors.CheckButton();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.grpStdL = new DevExpress.XtraEditors.GroupControl();
            this.grdStdL = new DevExpress.XtraGrid.GridControl();
            this.grvStdL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStdDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.btnHideStdL = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnLibraryAdd = new DevExpress.XtraEditors.SimpleButton();
            this.exbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.btnConnectHMI = new DevExpress.XtraBars.BarButtonItem();
            this.btnConnectDataType = new DevExpress.XtraBars.BarButtonItem();
            this.btnInputHMIBit = new DevExpress.XtraBars.BarButtonItem();
            this.btnMappingCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllMappingCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerifMappingCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupAutoMapping = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheckConnectPLC = new DevExpress.XtraBars.BarButtonItem();
            this.btnConnectHMITag = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecommend = new DevExpress.XtraBars.BarButtonItem();
            this.btnAllLevelClear = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddLibrary = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevelLeftMove = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevelRightMove = new DevExpress.XtraBars.BarButtonItem();
            this.btnReplace = new DevExpress.XtraBars.BarButtonItem();
            this.mnuMappingHMI = new DevExpress.XtraBars.PopupMenu(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.mnuVerifHMI = new DevExpress.XtraBars.PopupMenu(this.components);
            this.mnuMappingPLC = new DevExpress.XtraBars.PopupMenu(this.components);
            this.mnuStandard = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FrmRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSectionExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorConvert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorVerfiOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorHMIVerifOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPLCEdit)).BeginInit();
            this.pnlPLCEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLCRowCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHMIEdit)).BeginInit();
            this.pnlHMIEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHMIRowCount.Properties)).BeginInit();
            this.tpPLCVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptVerification)).BeginInit();
            this.sptVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPLCVerif)).BeginInit();
            this.tabPLCVerif.SuspendLayout();
            this.tpIOTree.SuspendLayout();
            this.tpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerifPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerifPLC)).BeginInit();
            this.tpLadderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlView)).BeginInit();
            this.pnlView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLadderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLadderViewBtn)).BeginInit();
            this.pnlLadderViewBtn.SuspendLayout();
            this.tpTagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPLCVerif2)).BeginInit();
            this.tabPLCVerif2.SuspendLayout();
            this.tpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl22)).BeginInit();
            this.panelControl22.SuspendLayout();
            this.tpReportElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).BeginInit();
            this.panelControl21.SuspendLayout();
            this.tpHMIVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptHMIVerification)).BeginInit();
            this.sptHMIVerification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerifHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerifHMI)).BeginInit();
            this.grpFilterOption.SuspendLayout();
            this.tpHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabHelp)).BeginInit();
            this.tabHelp.SuspendLayout();
            this.tpManual.SuspendLayout();
            this.tpIOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIOList)).BeginInit();
            this.pnlIOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl23)).BeginInit();
            this.panelControl23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl24)).BeginInit();
            this.panelControl24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePathOpen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcelEdit.Properties)).BeginInit();
            this.tpDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabDesign)).BeginInit();
            this.tabDesign.SuspendLayout();
            this.tpDesignDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesign2)).BeginInit();
            this.pnlDesign2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDesignPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDesignPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignControl)).BeginInit();
            this.pnlDesignControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesign1)).BeginInit();
            this.pnlDesign1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabIOData)).BeginInit();
            this.tabIOData.SuspendLayout();
            this.tpIOData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl16)).BeginInit();
            this.panelControl16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).BeginInit();
            this.panelControl19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIOUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIOExtend.Properties)).BeginInit();
            this.tpAddressRangeData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAddressArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).BeginInit();
            this.panelControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl15)).BeginInit();
            this.panelControl15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboListType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).BeginInit();
            this.panelControl13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).BeginInit();
            this.panelControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExtend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).BeginInit();
            this.tpDesignStandardization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStdL)).BeginInit();
            this.grpStdL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStdL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStdL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMappingHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuVerifHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMappingPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuStandard)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager
            // 
            splashScreenManager.ClosingDelay = 500;
            // 
            // FrmRibbon
            // 
            this.FrmRibbon.ExpandCollapseItem.Id = 0;
            this.FrmRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.FrmRibbon.ExpandCollapseItem,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnExit,
            this.btnOpenPLC,
            this.btnOpenHMI,
            this.btnExportHMI,
            this.cboMappingColor,
            this.lblConvert,
            this.lblMatch,
            this.lblInsert,
            this.cboInsert,
            this.cboConvert,
            this.barItemSkin,
            this.btnAllHMI,
            this.cboSectionExport,
            this.btnExportIO,
            this.btnExportDummy,
            this.chkViewIOList,
            this.btnAutoVerification,
            this.txtOptionName,
            this.btnOptionAdd,
            this.btnVerificationExcel,
            this.btnVerificationPDF,
            this.btnClearVerifPLC,
            this.btnVideoMatch,
            this.btnVideoIOList,
            this.btnVideoVerification,
            this.chkOptionApply,
            this.btnAutoMapping,
            this.lblUserOption,
            this.btnHMIClear,
            this.btnAutoHMIVerif,
            this.txtHMIOptionName,
            this.btnHMIOptionAdd,
            this.btnVerifHMIExcelExport,
            this.btnVerifHMIPDFExport,
            this.btnMappingCheck,
            this.btnStandardDicView,
            this.btnSymbolStandardization,
            this.btnStandardizationApply,
            this.btnExportErrorList,
            this.btnAddressRangeView,
            this.btnOpenPLCTag,
            this.btnSymbolNameEdit,
            this.btnModuleSetting,
            this.btnPLCTagExport,
            this.btnNewPLC,
            this.btnModeChange,
            this.btnNew,
            this.btnIOList,
            this.btnAboutIOMaker,
            this.btnFileExportGuide,
            this.btnMelsecGuide,
            this.btnSiemensGuide,
            this.btnABGuide,
            this.btnManual,
            this.btnPDFClear,
            this.lblFactory,
            this.lblLine,
            this.txtFactory,
            this.txtLine,
            this.chkStandardizationView});
            this.FrmRibbon.Location = new System.Drawing.Point(0, 0);
            this.FrmRibbon.MaxItemId = 25;
            this.FrmRibbon.Name = "FrmRibbon";
            this.FrmRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHMIMapping,
            this.pgPLCSymbolStandardization,
            this.pgPLCVerification,
            this.pgHMIVerification,
            this.pgHelper});
            this.FrmRibbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorColorMatch,
            this.exEditorColorInsert,
            this.exEditorColorConvert,
            this.exEditorSectionExport,
            this.exEditorVerfiOption,
            this.exEditorHMIVerifOption,
            this.repositoryItemPopupContainerEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.FrmRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.FrmRibbon.Size = new System.Drawing.Size(1339, 147);
            this.FrmRibbon.StatusBar = this.mnuStatusbar;
            this.FrmRibbon.SelectedPageChanged += new System.EventHandler(this.FrmRibbon_SelectedPageChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpen.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpen.Glyph")));
            this.btnOpen.Id = 1;
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
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "Save As";
            this.btnSaveAs.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSaveAs.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Glyph")));
            this.btnSaveAs.Id = 4;
            this.btnSaveAs.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.LargeGlyph")));
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "종료";
            this.btnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 5;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnOpenPLC
            // 
            this.btnOpenPLC.Caption = "PLC\r\n파일 열기";
            this.btnOpenPLC.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenPLC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenPLC.Glyph")));
            this.btnOpenPLC.Id = 6;
            this.btnOpenPLC.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenPLC.LargeGlyph")));
            this.btnOpenPLC.Name = "btnOpenPLC";
            this.btnOpenPLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenPLC_ItemClick);
            // 
            // btnOpenHMI
            // 
            this.btnOpenHMI.Caption = "HMI Tag 파일 열기";
            this.btnOpenHMI.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenHMI.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenHMI.Glyph")));
            this.btnOpenHMI.Id = 7;
            this.btnOpenHMI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenHMI.LargeGlyph")));
            this.btnOpenHMI.Name = "btnOpenHMI";
            this.btnOpenHMI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenHMI_ItemClick);
            // 
            // btnExportHMI
            // 
            this.btnExportHMI.ActAsDropDown = true;
            this.btnExportHMI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnExportHMI.Caption = "HMI Tag 내보내기";
            this.btnExportHMI.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExportHMI.DropDownControl = this.mnuExportHMI;
            this.btnExportHMI.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportHMI.Glyph")));
            this.btnExportHMI.Id = 9;
            this.btnExportHMI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportHMI.LargeGlyph")));
            this.btnExportHMI.Name = "btnExportHMI";
            this.btnExportHMI.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnExportHMI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportHMI_ItemClick);
            // 
            // mnuExportHMI
            // 
            this.mnuExportHMI.ItemLinks.Add(this.btnAllHMI);
            this.mnuExportHMI.ItemLinks.Add(this.cboSectionExport);
            this.mnuExportHMI.Name = "mnuExportHMI";
            this.mnuExportHMI.Ribbon = this.FrmRibbon;
            // 
            // btnAllHMI
            // 
            this.btnAllHMI.Caption = "All Export";
            this.btnAllHMI.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllHMI.Glyph")));
            this.btnAllHMI.Id = 9;
            this.btnAllHMI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAllHMI.LargeGlyph")));
            this.btnAllHMI.Name = "btnAllHMI";
            this.btnAllHMI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllHMI_ItemClick);
            // 
            // cboSectionExport
            // 
            this.cboSectionExport.Caption = "Section Export";
            this.cboSectionExport.Edit = this.exEditorSectionExport;
            this.cboSectionExport.Glyph = ((System.Drawing.Image)(resources.GetObject("cboSectionExport.Glyph")));
            this.cboSectionExport.Id = 11;
            this.cboSectionExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cboSectionExport.LargeGlyph")));
            this.cboSectionExport.Name = "cboSectionExport";
            this.cboSectionExport.Width = 150;
            this.cboSectionExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cboSectionExport_ItemClick);
            // 
            // exEditorSectionExport
            // 
            this.exEditorSectionExport.AutoHeight = false;
            this.exEditorSectionExport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorSectionExport.Name = "exEditorSectionExport";
            this.exEditorSectionExport.NullText = "Choice a Group..";
            // 
            // cboMappingColor
            // 
            this.cboMappingColor.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.cboMappingColor.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.cboMappingColor.Edit = this.exEditorColorMatch;
            this.cboMappingColor.Id = 10;
            this.cboMappingColor.Name = "cboMappingColor";
            this.cboMappingColor.Width = 150;
            // 
            // exEditorColorMatch
            // 
            this.exEditorColorMatch.AutoHeight = false;
            this.exEditorColorMatch.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColorMatch.ColorAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.exEditorColorMatch.Name = "exEditorColorMatch";
            // 
            // lblConvert
            // 
            this.lblConvert.Caption = "Edit";
            this.lblConvert.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblConvert.Id = 3;
            this.lblConvert.Name = "lblConvert";
            this.lblConvert.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblMatch
            // 
            this.lblMatch.Caption = "Match";
            this.lblMatch.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblMatch.Id = 2;
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblInsert
            // 
            this.lblInsert.Caption = "Insert";
            this.lblInsert.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblInsert.Id = 3;
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // cboInsert
            // 
            this.cboInsert.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.cboInsert.Edit = this.exEditorColorInsert;
            this.cboInsert.Id = 4;
            this.cboInsert.Name = "cboInsert";
            this.cboInsert.Width = 150;
            // 
            // exEditorColorInsert
            // 
            this.exEditorColorInsert.AutoHeight = false;
            this.exEditorColorInsert.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColorInsert.ColorAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.exEditorColorInsert.Name = "exEditorColorInsert";
            // 
            // cboConvert
            // 
            this.cboConvert.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.cboConvert.Edit = this.exEditorColorConvert;
            this.cboConvert.Id = 5;
            this.cboConvert.Name = "cboConvert";
            this.cboConvert.Width = 150;
            // 
            // exEditorColorConvert
            // 
            this.exEditorColorConvert.AutoHeight = false;
            this.exEditorColorConvert.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorColorConvert.ColorAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.exEditorColorConvert.Name = "exEditorColorConvert";
            // 
            // barItemSkin
            // 
            this.barItemSkin.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barItemSkin.Id = 6;
            this.barItemSkin.Name = "barItemSkin";
            // 
            // btnExportIO
            // 
            this.btnExportIO.Caption = "I/O List";
            this.btnExportIO.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportIO.Glyph")));
            this.btnExportIO.Id = 12;
            this.btnExportIO.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportIO.LargeGlyph")));
            this.btnExportIO.Name = "btnExportIO";
            this.btnExportIO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportIO_ItemClick);
            // 
            // btnExportDummy
            // 
            this.btnExportDummy.Caption = "Dummy List";
            this.btnExportDummy.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportDummy.Glyph")));
            this.btnExportDummy.Id = 13;
            this.btnExportDummy.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportDummy.LargeGlyph")));
            this.btnExportDummy.Name = "btnExportDummy";
            this.btnExportDummy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportDummy_ItemClick);
            // 
            // chkViewIOList
            // 
            this.chkViewIOList.Caption = "IO/DUMMY LIST 보기";
            this.chkViewIOList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkViewIOList.Glyph = ((System.Drawing.Image)(resources.GetObject("chkViewIOList.Glyph")));
            this.chkViewIOList.Id = 15;
            this.chkViewIOList.ItemAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chkViewIOList.ItemAppearance.Pressed.Options.UseBackColor = true;
            this.chkViewIOList.ItemInMenuAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.chkViewIOList.ItemInMenuAppearance.Pressed.Options.UseBackColor = true;
            this.chkViewIOList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkViewIOList.LargeGlyph")));
            this.chkViewIOList.Name = "chkViewIOList";
            this.chkViewIOList.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkViewIOList_CheckedChanged);
            // 
            // btnAutoVerification
            // 
            this.btnAutoVerification.Caption = "리포트 생성";
            this.btnAutoVerification.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAutoVerification.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAutoVerification.Glyph")));
            this.btnAutoVerification.Id = 18;
            this.btnAutoVerification.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAutoVerification.LargeGlyph")));
            this.btnAutoVerification.Name = "btnAutoVerification";
            this.btnAutoVerification.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoVerification_ItemClick);
            // 
            // txtOptionName
            // 
            this.txtOptionName.Caption = "Option 이름  ";
            this.txtOptionName.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtOptionName.Edit = this.exEditorVerfiOption;
            this.txtOptionName.Glyph = ((System.Drawing.Image)(resources.GetObject("txtOptionName.Glyph")));
            this.txtOptionName.Id = 19;
            this.txtOptionName.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("txtOptionName.LargeGlyph")));
            this.txtOptionName.Name = "txtOptionName";
            this.txtOptionName.Width = 250;
            // 
            // exEditorVerfiOption
            // 
            this.exEditorVerfiOption.AutoHeight = false;
            this.exEditorVerfiOption.Name = "exEditorVerfiOption";
            this.exEditorVerfiOption.NullText = "Define User Verification Option..";
            // 
            // btnOptionAdd
            // 
            this.btnOptionAdd.Caption = "Option 추가";
            this.btnOptionAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOptionAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOptionAdd.Glyph")));
            this.btnOptionAdd.Id = 20;
            this.btnOptionAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOptionAdd.LargeGlyph")));
            this.btnOptionAdd.Name = "btnOptionAdd";
            this.btnOptionAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOptionAdd_ItemClick);
            // 
            // btnVerificationExcel
            // 
            this.btnVerificationExcel.Caption = "Excel 내보내기";
            this.btnVerificationExcel.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVerificationExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerificationExcel.Glyph")));
            this.btnVerificationExcel.Id = 21;
            this.btnVerificationExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerificationExcel.LargeGlyph")));
            this.btnVerificationExcel.Name = "btnVerificationExcel";
            this.btnVerificationExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerificationExcel_ItemClick);
            // 
            // btnVerificationPDF
            // 
            this.btnVerificationPDF.Caption = "PDF\r\n내보내기";
            this.btnVerificationPDF.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVerificationPDF.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerificationPDF.Glyph")));
            this.btnVerificationPDF.Id = 22;
            this.btnVerificationPDF.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerificationPDF.LargeGlyph")));
            this.btnVerificationPDF.Name = "btnVerificationPDF";
            this.btnVerificationPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerificationPDF_ItemClick);
            // 
            // btnClearVerifPLC
            // 
            this.btnClearVerifPLC.Caption = "PLC 심볼 지우기";
            this.btnClearVerifPLC.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnClearVerifPLC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClearVerifPLC.Glyph")));
            this.btnClearVerifPLC.Id = 23;
            this.btnClearVerifPLC.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnClearVerifPLC.LargeGlyph")));
            this.btnClearVerifPLC.Name = "btnClearVerifPLC";
            this.btnClearVerifPLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearVerifPLC_ItemClick);
            // 
            // btnVideoMatch
            // 
            this.btnVideoMatch.Caption = "PLC-HMI 매핑";
            this.btnVideoMatch.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVideoMatch.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVideoMatch.Glyph")));
            this.btnVideoMatch.Id = 26;
            this.btnVideoMatch.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVideoMatch.LargeGlyph")));
            this.btnVideoMatch.Name = "btnVideoMatch";
            // 
            // btnVideoIOList
            // 
            this.btnVideoIOList.Caption = "IO/Dummy List 내보내기";
            this.btnVideoIOList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVideoIOList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVideoIOList.Glyph")));
            this.btnVideoIOList.Id = 27;
            this.btnVideoIOList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVideoIOList.LargeGlyph")));
            this.btnVideoIOList.Name = "btnVideoIOList";
            // 
            // btnVideoVerification
            // 
            this.btnVideoVerification.Caption = "PLC 자동 검도";
            this.btnVideoVerification.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVideoVerification.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVideoVerification.Glyph")));
            this.btnVideoVerification.Id = 28;
            this.btnVideoVerification.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVideoVerification.LargeGlyph")));
            this.btnVideoVerification.Name = "btnVideoVerification";
            // 
            // chkOptionApply
            // 
            this.chkOptionApply.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.chkOptionApply.Caption = "옵션 적용";
            this.chkOptionApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkOptionApply.Down = true;
            this.chkOptionApply.Glyph = ((System.Drawing.Image)(resources.GetObject("chkOptionApply.Glyph")));
            this.chkOptionApply.Id = 33;
            this.chkOptionApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkOptionApply.LargeGlyph")));
            this.chkOptionApply.Name = "chkOptionApply";
            this.chkOptionApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.chkOptionApply_ItemClick);
            // 
            // btnAutoMapping
            // 
            this.btnAutoMapping.Caption = "자동 매핑\r\n옵션 세팅";
            this.btnAutoMapping.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAutoMapping.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAutoMapping.Glyph")));
            this.btnAutoMapping.Id = 34;
            this.btnAutoMapping.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAutoMapping.LargeGlyph")));
            this.btnAutoMapping.Name = "btnAutoMapping";
            this.btnAutoMapping.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoMapping_ItemClick);
            // 
            // lblUserOption
            // 
            this.lblUserOption.Caption = "리포트에 추가하고자 하는 항목에 해당하는 Rows를 선택하세요.";
            this.lblUserOption.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblUserOption.Id = 35;
            this.lblUserOption.Name = "lblUserOption";
            this.lblUserOption.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnHMIClear
            // 
            this.btnHMIClear.Caption = "HMI 지우기";
            this.btnHMIClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnHMIClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHMIClear.Glyph")));
            this.btnHMIClear.Id = 36;
            this.btnHMIClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHMIClear.LargeGlyph")));
            this.btnHMIClear.Name = "btnHMIClear";
            this.btnHMIClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHMIClear_ItemClick);
            // 
            // btnAutoHMIVerif
            // 
            this.btnAutoHMIVerif.Caption = "HMI 자동\r\n검도 진행";
            this.btnAutoHMIVerif.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAutoHMIVerif.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAutoHMIVerif.Glyph")));
            this.btnAutoHMIVerif.Id = 37;
            this.btnAutoHMIVerif.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAutoHMIVerif.LargeGlyph")));
            this.btnAutoHMIVerif.Name = "btnAutoHMIVerif";
            this.btnAutoHMIVerif.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAutoHMIVerif_ItemClick);
            // 
            // txtHMIOptionName
            // 
            this.txtHMIOptionName.Caption = "Option 이름  ";
            this.txtHMIOptionName.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtHMIOptionName.Edit = this.exEditorHMIVerifOption;
            this.txtHMIOptionName.Glyph = ((System.Drawing.Image)(resources.GetObject("txtHMIOptionName.Glyph")));
            this.txtHMIOptionName.Id = 38;
            this.txtHMIOptionName.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("txtHMIOptionName.LargeGlyph")));
            this.txtHMIOptionName.Name = "txtHMIOptionName";
            this.txtHMIOptionName.Width = 250;
            // 
            // exEditorHMIVerifOption
            // 
            this.exEditorHMIVerifOption.AutoHeight = false;
            this.exEditorHMIVerifOption.Name = "exEditorHMIVerifOption";
            this.exEditorHMIVerifOption.NullText = "Define User Verification Option..";
            // 
            // btnHMIOptionAdd
            // 
            this.btnHMIOptionAdd.Caption = "Option 추가 ";
            this.btnHMIOptionAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnHMIOptionAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHMIOptionAdd.Glyph")));
            this.btnHMIOptionAdd.Id = 39;
            this.btnHMIOptionAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHMIOptionAdd.LargeGlyph")));
            this.btnHMIOptionAdd.Name = "btnHMIOptionAdd";
            this.btnHMIOptionAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHMIOptionAdd_ItemClick);
            // 
            // btnVerifHMIExcelExport
            // 
            this.btnVerifHMIExcelExport.Caption = "Excel 내보내기";
            this.btnVerifHMIExcelExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVerifHMIExcelExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerifHMIExcelExport.Glyph")));
            this.btnVerifHMIExcelExport.Id = 40;
            this.btnVerifHMIExcelExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerifHMIExcelExport.LargeGlyph")));
            this.btnVerifHMIExcelExport.Name = "btnVerifHMIExcelExport";
            this.btnVerifHMIExcelExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerifHMIExcelExport_ItemClick);
            // 
            // btnVerifHMIPDFExport
            // 
            this.btnVerifHMIPDFExport.Caption = "PDF\r\n내보내기";
            this.btnVerifHMIPDFExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnVerifHMIPDFExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerifHMIPDFExport.Glyph")));
            this.btnVerifHMIPDFExport.Id = 41;
            this.btnVerifHMIPDFExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerifHMIPDFExport.LargeGlyph")));
            this.btnVerifHMIPDFExport.Name = "btnVerifHMIPDFExport";
            this.btnVerifHMIPDFExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerifHMIPDFExport_ItemClick);
            // 
            // btnMappingCheck
            // 
            this.btnMappingCheck.Caption = "HMI 매핑 확인";
            this.btnMappingCheck.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnMappingCheck.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMappingCheck.Glyph")));
            this.btnMappingCheck.Id = 43;
            this.btnMappingCheck.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMappingCheck.LargeGlyph")));
            this.btnMappingCheck.Name = "btnMappingCheck";
            this.btnMappingCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMappingCheck_ItemClick);
            // 
            // btnStandardDicView
            // 
            this.btnStandardDicView.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.btnStandardDicView.Caption = "심볼 표준 라이브러리";
            this.btnStandardDicView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStandardDicView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStandardDicView.Glyph")));
            this.btnStandardDicView.Id = 44;
            this.btnStandardDicView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStandardDicView.LargeGlyph")));
            this.btnStandardDicView.Name = "btnStandardDicView";
            this.btnStandardDicView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStandardDicView_ItemClick);
            // 
            // btnSymbolStandardization
            // 
            this.btnSymbolStandardization.Caption = "심볼 표준화 진행";
            this.btnSymbolStandardization.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSymbolStandardization.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolStandardization.Glyph")));
            this.btnSymbolStandardization.Id = 45;
            this.btnSymbolStandardization.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolStandardization.LargeGlyph")));
            this.btnSymbolStandardization.Name = "btnSymbolStandardization";
            this.btnSymbolStandardization.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSymbolStandardization_ItemClick);
            // 
            // btnStandardizationApply
            // 
            this.btnStandardizationApply.Caption = "심볼 표준화 적용";
            this.btnStandardizationApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnStandardizationApply.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStandardizationApply.Glyph")));
            this.btnStandardizationApply.Id = 46;
            this.btnStandardizationApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnStandardizationApply.LargeGlyph")));
            this.btnStandardizationApply.Name = "btnStandardizationApply";
            this.btnStandardizationApply.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStandardizationApply_ItemClick);
            // 
            // btnExportErrorList
            // 
            this.btnExportErrorList.Caption = "에러 리스트 내보내기";
            this.btnExportErrorList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExportErrorList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportErrorList.Glyph")));
            this.btnExportErrorList.Id = 1;
            this.btnExportErrorList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportErrorList.LargeGlyph")));
            this.btnExportErrorList.Name = "btnExportErrorList";
            this.btnExportErrorList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportErrorList_ItemClick);
            // 
            // btnAddressRangeView
            // 
            this.btnAddressRangeView.Caption = "Address 영역 설정";
            this.btnAddressRangeView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAddressRangeView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddressRangeView.Glyph")));
            this.btnAddressRangeView.Id = 2;
            this.btnAddressRangeView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddressRangeView.LargeGlyph")));
            this.btnAddressRangeView.Name = "btnAddressRangeView";
            this.btnAddressRangeView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddressRangeView_ItemClick);
            // 
            // btnOpenPLCTag
            // 
            this.btnOpenPLCTag.Caption = "PLC 심볼 가져오기";
            this.btnOpenPLCTag.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenPLCTag.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenPLCTag.Glyph")));
            this.btnOpenPLCTag.Id = 3;
            this.btnOpenPLCTag.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenPLCTag.LargeGlyph")));
            this.btnOpenPLCTag.Name = "btnOpenPLCTag";
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "PLC 심볼 파일 열기 형식 가이드";
            toolTipItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem1.Appearance.Options.UseImage = true;
            toolTipItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem1.Image")));
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "PLC Maker                 파일 형식\r\n\r\nMitsubishi(Melsec)       *.CSV\r\nSiemens       " +
    "             *.SDF\r\nAB (Rockwell)            *.L5K\r\n";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = "※ PLC 별 파일 내보내기 상세 방법은 도움말 참조";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.btnOpenPLCTag.SuperTip = superToolTip1;
            this.btnOpenPLCTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenPLCTag_ItemClick);
            // 
            // btnSymbolNameEdit
            // 
            this.btnSymbolNameEdit.Caption = "PLC 심볼 이름 설정";
            this.btnSymbolNameEdit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSymbolNameEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolNameEdit.Glyph")));
            this.btnSymbolNameEdit.Id = 4;
            this.btnSymbolNameEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolNameEdit.LargeGlyph")));
            this.btnSymbolNameEdit.Name = "btnSymbolNameEdit";
            this.btnSymbolNameEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSymbolNameEdit_ItemClick);
            // 
            // btnModuleSetting
            // 
            this.btnModuleSetting.Caption = "PLC 모듈 정보 설정";
            this.btnModuleSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnModuleSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnModuleSetting.Glyph")));
            this.btnModuleSetting.Id = 5;
            this.btnModuleSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModuleSetting.LargeGlyph")));
            this.btnModuleSetting.Name = "btnModuleSetting";
            this.btnModuleSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModuleSetting_ItemClick);
            // 
            // btnPLCTagExport
            // 
            this.btnPLCTagExport.Caption = "PLC 심볼 내보내기";
            this.btnPLCTagExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnPLCTagExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPLCTagExport.Glyph")));
            this.btnPLCTagExport.Id = 6;
            this.btnPLCTagExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPLCTagExport.LargeGlyph")));
            this.btnPLCTagExport.Name = "btnPLCTagExport";
            this.btnPLCTagExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPLCTagExport_ItemClick);
            // 
            // btnNewPLC
            // 
            this.btnNewPLC.Caption = "PLC 심볼 새로 만들기";
            this.btnNewPLC.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNewPLC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNewPLC.Glyph")));
            this.btnNewPLC.Id = 7;
            this.btnNewPLC.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNewPLC.LargeGlyph")));
            this.btnNewPLC.Name = "btnNewPLC";
            this.btnNewPLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewPLC_ItemClick);
            // 
            // btnModeChange
            // 
            this.btnModeChange.Caption = "IO Maker Mode 변경";
            this.btnModeChange.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnModeChange.Glyph = ((System.Drawing.Image)(resources.GetObject("btnModeChange.Glyph")));
            this.btnModeChange.Id = 8;
            this.btnModeChange.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnModeChange.LargeGlyph")));
            this.btnModeChange.Name = "btnModeChange";
            this.btnModeChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModeChange_ItemClick);
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNew.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNew.Glyph")));
            this.btnNew.Id = 9;
            this.btnNew.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNew.LargeGlyph")));
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnIOList
            // 
            this.btnIOList.Caption = "IO/DUMMY LIST 내보내기";
            this.btnIOList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnIOList.Glyph = ((System.Drawing.Image)(resources.GetObject("btnIOList.Glyph")));
            this.btnIOList.Id = 10;
            this.btnIOList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnIOList.LargeGlyph")));
            this.btnIOList.Name = "btnIOList";
            this.btnIOList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIOList_ItemClick);
            // 
            // btnAboutIOMaker
            // 
            this.btnAboutIOMaker.Caption = "About IO Maker";
            this.btnAboutIOMaker.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnAboutIOMaker.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAboutIOMaker.Glyph")));
            this.btnAboutIOMaker.Id = 11;
            this.btnAboutIOMaker.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAboutIOMaker.LargeGlyph")));
            this.btnAboutIOMaker.Name = "btnAboutIOMaker";
            this.btnAboutIOMaker.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAboutIOMaker_ItemClick);
            // 
            // btnFileExportGuide
            // 
            this.btnFileExportGuide.ActAsDropDown = true;
            this.btnFileExportGuide.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnFileExportGuide.Caption = "PLC 별 파일 내보내기 가이드";
            this.btnFileExportGuide.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnFileExportGuide.DropDownControl = this.mnuExportGuide;
            this.btnFileExportGuide.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFileExportGuide.Glyph")));
            this.btnFileExportGuide.Id = 12;
            this.btnFileExportGuide.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFileExportGuide.LargeGlyph")));
            this.btnFileExportGuide.Name = "btnFileExportGuide";
            this.btnFileExportGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFileExportGuide_ItemClick);
            // 
            // mnuExportGuide
            // 
            this.mnuExportGuide.ItemLinks.Add(this.btnMelsecGuide);
            this.mnuExportGuide.ItemLinks.Add(this.btnSiemensGuide);
            this.mnuExportGuide.ItemLinks.Add(this.btnABGuide);
            this.mnuExportGuide.Name = "mnuExportGuide";
            this.mnuExportGuide.Ribbon = this.FrmRibbon;
            // 
            // btnMelsecGuide
            // 
            this.btnMelsecGuide.Caption = "MITUSIBHI (MELSEC)";
            this.btnMelsecGuide.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMelsecGuide.Glyph")));
            this.btnMelsecGuide.Id = 13;
            this.btnMelsecGuide.Name = "btnMelsecGuide";
            this.btnMelsecGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMelsecGuide_ItemClick);
            // 
            // btnSiemensGuide
            // 
            this.btnSiemensGuide.Caption = "SIEMENS";
            this.btnSiemensGuide.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSiemensGuide.Glyph")));
            this.btnSiemensGuide.Id = 14;
            this.btnSiemensGuide.Name = "btnSiemensGuide";
            this.btnSiemensGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSiemensGuide_ItemClick);
            // 
            // btnABGuide
            // 
            this.btnABGuide.Caption = "AB (ROCKWELL)";
            this.btnABGuide.Glyph = ((System.Drawing.Image)(resources.GetObject("btnABGuide.Glyph")));
            this.btnABGuide.Id = 15;
            this.btnABGuide.Name = "btnABGuide";
            this.btnABGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnABGuide_ItemClick);
            // 
            // btnManual
            // 
            this.btnManual.Caption = "IO Maker 매뉴얼";
            this.btnManual.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnManual.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManual.Glyph")));
            this.btnManual.Id = 17;
            this.btnManual.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManual.LargeGlyph")));
            this.btnManual.Name = "btnManual";
            this.btnManual.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManual_ItemClick);
            // 
            // btnPDFClear
            // 
            this.btnPDFClear.Caption = "PDF Viewer 지우기";
            this.btnPDFClear.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnPDFClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPDFClear.Glyph")));
            this.btnPDFClear.Id = 18;
            this.btnPDFClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPDFClear.LargeGlyph")));
            this.btnPDFClear.Name = "btnPDFClear";
            this.btnPDFClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPDFClear_ItemClick);
            // 
            // lblFactory
            // 
            this.lblFactory.Caption = "Factory : ";
            this.lblFactory.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblFactory.Id = 19;
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblLine
            // 
            this.lblLine.Caption = "Line : ";
            this.lblLine.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblLine.Id = 20;
            this.lblLine.Name = "lblLine";
            this.lblLine.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txtFactory
            // 
            this.txtFactory.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtFactory.Edit = this.repositoryItemTextEdit1;
            this.txtFactory.Enabled = false;
            this.txtFactory.Id = 21;
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.Width = 100;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // txtLine
            // 
            this.txtLine.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.txtLine.Edit = this.repositoryItemTextEdit2;
            this.txtLine.Enabled = false;
            this.txtLine.Id = 22;
            this.txtLine.Name = "txtLine";
            this.txtLine.Width = 100;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AllowFocused = false;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            // 
            // chkStandardizationView
            // 
            this.chkStandardizationView.BindableChecked = true;
            this.chkStandardizationView.Caption = "심볼 표준 라이브러리 보기";
            this.chkStandardizationView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkStandardizationView.Checked = true;
            this.chkStandardizationView.Glyph = ((System.Drawing.Image)(resources.GetObject("chkStandardizationView.Glyph")));
            this.chkStandardizationView.Id = 24;
            this.chkStandardizationView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkStandardizationView.LargeGlyph")));
            this.chkStandardizationView.Name = "chkStandardizationView";
            this.chkStandardizationView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkStandardizationView_CheckedChanged);
            // 
            // pgHMIMapping
            // 
            this.pgHMIMapping.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuFile,
            this.mnuPLC,
            this.mnuHMI,
            this.mnuMappingOption,
            this.mnuSkin,
            this.mnuExit});
            this.pgHMIMapping.Name = "pgHMIMapping";
            this.pgHMIMapping.Text = "PLC-HMI 매핑";
            // 
            // mnuFile
            // 
            this.mnuFile.ItemLinks.Add(this.btnNew);
            this.mnuFile.ItemLinks.Add(this.btnOpen);
            this.mnuFile.ItemLinks.Add(this.btnSave);
            this.mnuFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "File";
            // 
            // mnuPLC
            // 
            this.mnuPLC.ItemLinks.Add(this.btnOpenPLC);
            this.mnuPLC.ItemLinks.Add(this.btnClearVerifPLC);
            this.mnuPLC.ItemLinks.Add(this.btnExportErrorList);
            this.mnuPLC.Name = "mnuPLC";
            this.mnuPLC.Text = "PLC";
            // 
            // mnuHMI
            // 
            this.mnuHMI.ItemLinks.Add(this.btnOpenHMI);
            this.mnuHMI.ItemLinks.Add(this.btnMappingCheck);
            this.mnuHMI.ItemLinks.Add(this.btnHMIClear);
            this.mnuHMI.ItemLinks.Add(this.btnExportHMI);
            this.mnuHMI.Name = "mnuHMI";
            this.mnuHMI.Text = "HMI";
            // 
            // mnuMappingOption
            // 
            this.mnuMappingOption.ItemLinks.Add(this.lblMatch);
            this.mnuMappingOption.ItemLinks.Add(this.lblInsert);
            this.mnuMappingOption.ItemLinks.Add(this.lblConvert);
            this.mnuMappingOption.ItemLinks.Add(this.cboMappingColor);
            this.mnuMappingOption.ItemLinks.Add(this.cboInsert);
            this.mnuMappingOption.ItemLinks.Add(this.cboConvert);
            this.mnuMappingOption.ItemLinks.Add(this.chkOptionApply);
            this.mnuMappingOption.ItemLinks.Add(this.btnAutoMapping);
            this.mnuMappingOption.Name = "mnuMappingOption";
            this.mnuMappingOption.Text = "Mapping Option";
            // 
            // mnuSkin
            // 
            this.mnuSkin.ItemLinks.Add(this.barItemSkin);
            this.mnuSkin.Name = "mnuSkin";
            this.mnuSkin.Text = "Skin";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnModeChange);
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // pgPLCSymbolStandardization
            // 
            this.pgPLCSymbolStandardization.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuStandardFile,
            this.mnuStandardPLC,
            this.mnuDesignPLC,
            this.mnuStandardization,
            this.mnuStandardExit});
            this.pgPLCSymbolStandardization.Name = "pgPLCSymbolStandardization";
            this.pgPLCSymbolStandardization.Text = "PLC 심볼 설계 및 표준화";
            // 
            // mnuStandardFile
            // 
            this.mnuStandardFile.ItemLinks.Add(this.btnNew);
            this.mnuStandardFile.ItemLinks.Add(this.btnOpen);
            this.mnuStandardFile.ItemLinks.Add(this.btnSave);
            this.mnuStandardFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuStandardFile.Name = "mnuStandardFile";
            this.mnuStandardFile.Text = "File";
            // 
            // mnuStandardPLC
            // 
            this.mnuStandardPLC.ItemLinks.Add(this.btnNewPLC);
            this.mnuStandardPLC.ItemLinks.Add(this.btnOpenPLCTag);
            this.mnuStandardPLC.ItemLinks.Add(this.btnPLCTagExport);
            this.mnuStandardPLC.ItemLinks.Add(this.btnIOList);
            this.mnuStandardPLC.ItemLinks.Add(this.btnClearVerifPLC);
            this.mnuStandardPLC.ItemLinks.Add(this.chkViewIOList);
            this.mnuStandardPLC.Name = "mnuStandardPLC";
            this.mnuStandardPLC.Text = "PLC";
            // 
            // mnuDesignPLC
            // 
            this.mnuDesignPLC.ItemLinks.Add(this.btnAddressRangeView);
            this.mnuDesignPLC.ItemLinks.Add(this.btnSymbolNameEdit);
            this.mnuDesignPLC.ItemLinks.Add(this.btnModuleSetting);
            this.mnuDesignPLC.Name = "mnuDesignPLC";
            this.mnuDesignPLC.Text = "Design";
            // 
            // mnuStandardization
            // 
            this.mnuStandardization.ItemLinks.Add(this.chkStandardizationView);
            this.mnuStandardization.ItemLinks.Add(this.btnSymbolStandardization);
            this.mnuStandardization.ItemLinks.Add(this.btnStandardizationApply);
            this.mnuStandardization.Name = "mnuStandardization";
            this.mnuStandardization.Text = "Standardization";
            // 
            // mnuStandardExit
            // 
            this.mnuStandardExit.ItemLinks.Add(this.btnModeChange);
            this.mnuStandardExit.ItemLinks.Add(this.btnExit);
            this.mnuStandardExit.Name = "mnuStandardExit";
            this.mnuStandardExit.Text = "Exit";
            // 
            // pgPLCVerification
            // 
            this.pgPLCVerification.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuPLCVerifFile,
            this.mnuPLCVerification,
            this.mnuUserDefine,
            this.mnuExport,
            this.mnuExit1});
            this.pgPLCVerification.Name = "pgPLCVerification";
            this.pgPLCVerification.Text = "PLC 자동 검도";
            // 
            // mnuPLCVerifFile
            // 
            this.mnuPLCVerifFile.ItemLinks.Add(this.btnNew);
            this.mnuPLCVerifFile.ItemLinks.Add(this.btnOpen);
            this.mnuPLCVerifFile.ItemLinks.Add(this.btnSave);
            this.mnuPLCVerifFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuPLCVerifFile.Name = "mnuPLCVerifFile";
            this.mnuPLCVerifFile.Text = "File";
            // 
            // mnuPLCVerification
            // 
            this.mnuPLCVerification.ItemLinks.Add(this.btnOpenPLC);
            this.mnuPLCVerification.ItemLinks.Add(this.btnClearVerifPLC);
            this.mnuPLCVerification.ItemLinks.Add(this.btnAutoVerification);
            this.mnuPLCVerification.Name = "mnuPLCVerification";
            this.mnuPLCVerification.Text = "PLC";
            // 
            // mnuUserDefine
            // 
            this.mnuUserDefine.ItemLinks.Add(this.lblUserOption);
            this.mnuUserDefine.ItemLinks.Add(this.txtOptionName);
            this.mnuUserDefine.ItemLinks.Add(this.btnOptionAdd);
            this.mnuUserDefine.Name = "mnuUserDefine";
            this.mnuUserDefine.Text = "User Define Verification";
            this.mnuUserDefine.Visible = false;
            // 
            // mnuExport
            // 
            this.mnuExport.ItemLinks.Add(this.btnVerificationExcel);
            this.mnuExport.ItemLinks.Add(this.btnVerificationPDF);
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Text = "Report Export";
            // 
            // mnuExit1
            // 
            this.mnuExit1.ItemLinks.Add(this.btnModeChange);
            this.mnuExit1.ItemLinks.Add(this.btnExit);
            this.mnuExit1.Name = "mnuExit1";
            this.mnuExit1.Text = "Exit";
            // 
            // pgHMIVerification
            // 
            this.pgHMIVerification.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuHMIVerifFile,
            this.mnuHMIVerification,
            this.mnuDefHMIVerif,
            this.mnuHMIExit,
            this.mnuExit2});
            this.pgHMIVerification.Name = "pgHMIVerification";
            this.pgHMIVerification.Text = "HMI 자동 검도";
            // 
            // mnuHMIVerifFile
            // 
            this.mnuHMIVerifFile.ItemLinks.Add(this.btnNew);
            this.mnuHMIVerifFile.ItemLinks.Add(this.btnOpen);
            this.mnuHMIVerifFile.ItemLinks.Add(this.btnSave);
            this.mnuHMIVerifFile.ItemLinks.Add(this.btnSaveAs);
            this.mnuHMIVerifFile.Name = "mnuHMIVerifFile";
            this.mnuHMIVerifFile.Text = "File";
            // 
            // mnuHMIVerification
            // 
            this.mnuHMIVerification.ItemLinks.Add(this.btnOpenHMI);
            this.mnuHMIVerification.ItemLinks.Add(this.btnHMIClear);
            this.mnuHMIVerification.ItemLinks.Add(this.btnAutoHMIVerif);
            this.mnuHMIVerification.Name = "mnuHMIVerification";
            this.mnuHMIVerification.Text = "HMI";
            // 
            // mnuDefHMIVerif
            // 
            this.mnuDefHMIVerif.ItemLinks.Add(this.lblUserOption);
            this.mnuDefHMIVerif.ItemLinks.Add(this.txtHMIOptionName);
            this.mnuDefHMIVerif.ItemLinks.Add(this.btnHMIOptionAdd);
            this.mnuDefHMIVerif.Name = "mnuDefHMIVerif";
            this.mnuDefHMIVerif.Text = "User Define Verification";
            // 
            // mnuHMIExit
            // 
            this.mnuHMIExit.ItemLinks.Add(this.btnVerifHMIExcelExport);
            this.mnuHMIExit.ItemLinks.Add(this.btnVerifHMIPDFExport);
            this.mnuHMIExit.Name = "mnuHMIExit";
            this.mnuHMIExit.Text = "Report Export";
            // 
            // mnuExit2
            // 
            this.mnuExit2.ItemLinks.Add(this.btnModeChange);
            this.mnuExit2.ItemLinks.Add(this.btnExit);
            this.mnuExit2.Name = "mnuExit2";
            this.mnuExit2.Text = "Exit";
            // 
            // pgHelper
            // 
            this.pgHelper.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuManual,
            this.mnuHelpExit});
            this.pgHelper.Name = "pgHelper";
            this.pgHelper.Text = "도움말";
            // 
            // mnuManual
            // 
            this.mnuManual.ItemLinks.Add(this.btnAboutIOMaker);
            this.mnuManual.ItemLinks.Add(this.btnFileExportGuide);
            this.mnuManual.ItemLinks.Add(this.btnManual);
            this.mnuManual.ItemLinks.Add(this.btnPDFClear);
            this.mnuManual.Name = "mnuManual";
            this.mnuManual.Text = "About";
            // 
            // mnuHelpExit
            // 
            this.mnuHelpExit.ItemLinks.Add(this.btnExit);
            this.mnuHelpExit.Name = "mnuHelpExit";
            this.mnuHelpExit.Text = "Exit";
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            // 
            // mnuStatusbar
            // 
            this.mnuStatusbar.ItemLinks.Add(this.lblFactory);
            this.mnuStatusbar.ItemLinks.Add(this.txtFactory);
            this.mnuStatusbar.ItemLinks.Add(this.lblLine);
            this.mnuStatusbar.ItemLinks.Add(this.txtLine);
            this.mnuStatusbar.Location = new System.Drawing.Point(0, 788);
            this.mnuStatusbar.Name = "mnuStatusbar";
            this.mnuStatusbar.Ribbon = this.FrmRibbon;
            this.mnuStatusbar.Size = new System.Drawing.Size(1339, 31);
            // 
            // mnuExportPLC
            // 
            this.mnuExportPLC.ItemLinks.Add(this.btnExportIO);
            this.mnuExportPLC.ItemLinks.Add(this.btnExportDummy);
            this.mnuExportPLC.Name = "mnuExportPLC";
            this.mnuExportPLC.Ribbon = this.FrmRibbon;
            // 
            // MouseStatus
            // 
            this.MouseStatus.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.MouseStatus.Id = 35;
            this.MouseStatus.Name = "MouseStatus";
            // 
            // LabelWorkTime
            // 
            this.LabelWorkTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.LabelWorkTime.Id = 51;
            this.LabelWorkTime.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("LabelWorkTime.LargeGlyph")));
            this.LabelWorkTime.Name = "LabelWorkTime";
            this.LabelWorkTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barMainStatus
            // 
            this.barMainStatus.Id = 34;
            this.barMainStatus.Name = "barMainStatus";
            this.barMainStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 147);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpMapping;
            this.tabMain.Size = new System.Drawing.Size(1339, 641);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMapping,
            this.tpPLCVerification,
            this.tpHMIVerification,
            this.tpHelp,
            this.tpIOList,
            this.tpDesign});
            // 
            // tpMapping
            // 
            this.tpMapping.Controls.Add(this.sptMain);
            this.tpMapping.Name = "tpMapping";
            this.tpMapping.Size = new System.Drawing.Size(1333, 612);
            this.tpMapping.Text = "Mapping";
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grdPLC);
            this.sptMain.Panel1.Controls.Add(this.pnlPLCEdit);
            this.sptMain.Panel1.Controls.Add(this.barDockControlLeft);
            this.sptMain.Panel1.Controls.Add(this.barDockControlRight);
            this.sptMain.Panel1.Controls.Add(this.barDockControlBottom);
            this.sptMain.Panel1.Controls.Add(this.barDockControlTop);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grdHMI);
            this.sptMain.Panel2.Controls.Add(this.pnlHMIEdit);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1333, 612);
            this.sptMain.SplitterPosition = 690;
            this.sptMain.TabIndex = 0;
            // 
            // grdPLC
            // 
            this.grdPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPLC.Location = new System.Drawing.Point(0, 30);
            this.grdPLC.LookAndFeel.SkinName = "Metropolis";
            this.grdPLC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdPLC.MainView = this.grvPLC;
            this.grdPLC.MenuManager = this.FrmRibbon;
            this.grdPLC.Name = "grdPLC";
            this.grdPLC.Size = new System.Drawing.Size(690, 582);
            this.grdPLC.TabIndex = 8;
            this.grdPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPLC});
            this.grdPLC.DoubleClick += new System.EventHandler(this.grdPLC_DoubleClick);
            // 
            // grvPLC
            // 
            this.grvPLC.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvPLC.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvPLC.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvPLC.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvPLC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMapping,
            this.colPLC,
            this.colPLCGroup,
            this.colName,
            this.colAddress,
            this.colDescription,
            this.colDataType,
            this.colPLCKey});
            this.grvPLC.GridControl = this.grdPLC;
            this.grvPLC.GroupPanelText = "Tab 키를 누르면 HMI Tag 표로 Focus 전환 됩니다.";
            this.grvPLC.IndicatorWidth = 60;
            this.grvPLC.Name = "grvPLC";
            this.grvPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvPLC.OptionsDetail.EnableMasterViewMode = false;
            this.grvPLC.OptionsDetail.SmartDetailExpand = false;
            this.grvPLC.OptionsFind.AlwaysVisible = true;
            this.grvPLC.OptionsSelection.MultiSelect = true;
            this.grvPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvPLC.OptionsView.ShowAutoFilterRow = true;
            this.grvPLC.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvPLC_CustomDrawRowIndicator);
            this.grvPLC.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvPLC_RowCellStyle);
            this.grvPLC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvPLC_KeyDown);
            this.grvPLC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grvPLC_KeyUp);
            this.grvPLC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvPLC_MouseUp);
            // 
            // colMapping
            // 
            this.colMapping.AppearanceCell.Options.UseTextOptions = true;
            this.colMapping.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMapping.AppearanceHeader.Options.UseTextOptions = true;
            this.colMapping.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMapping.Caption = "Is Mapping";
            this.colMapping.FieldName = "IsHMIMapping";
            this.colMapping.Name = "colMapping";
            this.colMapping.OptionsColumn.AllowEdit = false;
            this.colMapping.OptionsColumn.AllowMove = false;
            this.colMapping.OptionsColumn.AllowShowHide = false;
            this.colMapping.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMapping.OptionsColumn.FixedWidth = true;
            this.colMapping.OptionsColumn.ReadOnly = true;
            this.colMapping.Visible = true;
            this.colMapping.VisibleIndex = 0;
            this.colMapping.Width = 70;
            // 
            // colPLC
            // 
            this.colPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLC.Caption = "PLC";
            this.colPLC.FieldName = "Channel";
            this.colPLC.Name = "colPLC";
            this.colPLC.OptionsColumn.AllowEdit = false;
            this.colPLC.OptionsColumn.AllowShowHide = false;
            this.colPLC.Visible = true;
            this.colPLC.VisibleIndex = 1;
            this.colPLC.Width = 110;
            // 
            // colPLCGroup
            // 
            this.colPLCGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colPLCGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPLCGroup.Caption = "Group";
            this.colPLCGroup.FieldName = "Creator";
            this.colPLCGroup.Name = "colPLCGroup";
            this.colPLCGroup.OptionsColumn.AllowEdit = false;
            this.colPLCGroup.Visible = true;
            this.colPLCGroup.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 110;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddress.AppearanceCell.Options.UseFont = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowShowHide = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 110;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 110;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowShowHide = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 6;
            this.colDataType.Width = 70;
            // 
            // colPLCKey
            // 
            this.colPLCKey.Caption = "Key";
            this.colPLCKey.FieldName = "Key";
            this.colPLCKey.Name = "colPLCKey";
            // 
            // pnlPLCEdit
            // 
            this.pnlPLCEdit.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlPLCEdit.Appearance.Options.UseBackColor = true;
            this.pnlPLCEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPLCEdit.Controls.Add(this.chkPLCEditable);
            this.pnlPLCEdit.Controls.Add(this.panelControl3);
            this.pnlPLCEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPLCEdit.Location = new System.Drawing.Point(0, 0);
            this.pnlPLCEdit.Name = "pnlPLCEdit";
            this.pnlPLCEdit.Size = new System.Drawing.Size(690, 30);
            this.pnlPLCEdit.TabIndex = 13;
            // 
            // chkPLCEditable
            // 
            this.chkPLCEditable.AutoSize = true;
            this.chkPLCEditable.BackColor = System.Drawing.Color.White;
            this.chkPLCEditable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkPLCEditable.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkPLCEditable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPLCEditable.Location = new System.Drawing.Point(0, 0);
            this.chkPLCEditable.Name = "chkPLCEditable";
            this.chkPLCEditable.Size = new System.Drawing.Size(99, 30);
            this.chkPLCEditable.TabIndex = 0;
            this.chkPLCEditable.Text = "PLC 수정 가능";
            this.chkPLCEditable.UseVisualStyleBackColor = false;
            this.chkPLCEditable.CheckedChanged += new System.EventHandler(this.chkPLCEditable_CheckedChanged);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.lblPLCRowCount);
            this.panelControl3.Controls.Add(this.txtPLCRowCount);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(531, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(159, 30);
            this.panelControl3.TabIndex = 3;
            // 
            // lblPLCRowCount
            // 
            this.lblPLCRowCount.Location = new System.Drawing.Point(0, 7);
            this.lblPLCRowCount.Name = "lblPLCRowCount";
            this.lblPLCRowCount.Size = new System.Drawing.Size(84, 14);
            this.lblPLCRowCount.TabIndex = 0;
            this.lblPLCRowCount.Text = "선택된 PLC 수 :";
            // 
            // txtPLCRowCount
            // 
            this.txtPLCRowCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPLCRowCount.EditValue = ((short)(0));
            this.txtPLCRowCount.Location = new System.Drawing.Point(112, 4);
            this.txtPLCRowCount.MenuManager = this.FrmRibbon;
            this.txtPLCRowCount.Name = "txtPLCRowCount";
            this.txtPLCRowCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPLCRowCount.Properties.ReadOnly = true;
            this.txtPLCRowCount.Size = new System.Drawing.Size(47, 20);
            this.txtPLCRowCount.TabIndex = 1;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 612);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(690, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 612);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 612);
            this.barDockControlBottom.Size = new System.Drawing.Size(690, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(690, 0);
            // 
            // grdHMI
            // 
            this.grdHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHMI.Location = new System.Drawing.Point(0, 30);
            this.grdHMI.LookAndFeel.SkinName = "Metropolis";
            this.grdHMI.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdHMI.MainView = this.grvHMI;
            this.grdHMI.MenuManager = this.FrmRibbon;
            this.grdHMI.Name = "grdHMI";
            this.grdHMI.Size = new System.Drawing.Size(638, 582);
            this.grdHMI.TabIndex = 15;
            this.grdHMI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHMI});
            this.grdHMI.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdHMI_ProcessGridKey);
            // 
            // grvHMI
            // 
            this.grvHMI.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvHMI.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvHMI.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvHMI.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvHMI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colGroup,
            this.colHMIName,
            this.colHMIDataType,
            this.colHMIAddress,
            this.colHMIDesc,
            this.colMatch,
            this.colInsert,
            this.colConvert,
            this.colRedundancy,
            this.colWorkStation,
            this.colEdit,
            this.colExistedMatch});
            this.grvHMI.GridControl = this.grdHMI;
            this.grvHMI.GroupCount = 2;
            this.grvHMI.IndicatorWidth = 60;
            this.grvHMI.Name = "grvHMI";
            this.grvHMI.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvHMI.OptionsDetail.EnableMasterViewMode = false;
            this.grvHMI.OptionsDetail.SmartDetailExpand = false;
            this.grvHMI.OptionsFind.AlwaysVisible = true;
            this.grvHMI.OptionsSelection.MultiSelect = true;
            this.grvHMI.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvHMI.OptionsView.ShowAutoFilterRow = true;
            this.grvHMI.OptionsView.ShowIndicator = false;
            this.grvHMI.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroup, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWorkStation, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvHMI.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvHMI_CustomDrawRowIndicator);
            this.grvHMI.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvHMI_RowCellStyle);
            this.grvHMI.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvHMI_CellValueChanged);
            this.grvHMI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvHMI_KeyDown);
            this.grvHMI.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grvHMI_KeyUp);
            this.grvHMI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvHMI_MouseUp);
            this.grvHMI.DoubleClick += new System.EventHandler(this.grvHMI_DoubleClick);
            // 
            // colNumber
            // 
            this.colNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.Caption = "#번호";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.OptionsColumn.FixedWidth = true;
            this.colNumber.Width = 70;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "그룹";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 1;
            this.colGroup.Width = 103;
            // 
            // colHMIName
            // 
            this.colHMIName.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIName.Caption = "이름";
            this.colHMIName.FieldName = "Name";
            this.colHMIName.Name = "colHMIName";
            this.colHMIName.OptionsColumn.AllowEdit = false;
            this.colHMIName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colHMIName.Visible = true;
            this.colHMIName.VisibleIndex = 0;
            this.colHMIName.Width = 137;
            // 
            // colHMIDataType
            // 
            this.colHMIDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colHMIDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDataType.Caption = "타입";
            this.colHMIDataType.FieldName = "DataType";
            this.colHMIDataType.Name = "colHMIDataType";
            this.colHMIDataType.OptionsColumn.AllowEdit = false;
            this.colHMIDataType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colHMIDataType.OptionsColumn.FixedWidth = true;
            this.colHMIDataType.Visible = true;
            this.colHMIDataType.VisibleIndex = 3;
            this.colHMIDataType.Width = 70;
            // 
            // colHMIAddress
            // 
            this.colHMIAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colHMIAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIAddress.Caption = "디바이스";
            this.colHMIAddress.FieldName = "Address";
            this.colHMIAddress.Name = "colHMIAddress";
            this.colHMIAddress.OptionsColumn.AllowEdit = false;
            this.colHMIAddress.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colHMIAddress.Visible = true;
            this.colHMIAddress.VisibleIndex = 1;
            this.colHMIAddress.Width = 137;
            // 
            // colHMIDesc
            // 
            this.colHMIDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colHMIDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHMIDesc.Caption = "설명";
            this.colHMIDesc.FieldName = "Description";
            this.colHMIDesc.Name = "colHMIDesc";
            this.colHMIDesc.OptionsColumn.AllowEdit = false;
            this.colHMIDesc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colHMIDesc.Visible = true;
            this.colHMIDesc.VisibleIndex = 2;
            this.colHMIDesc.Width = 145;
            // 
            // colMatch
            // 
            this.colMatch.Caption = "Is Match";
            this.colMatch.FieldName = "IsMatch";
            this.colMatch.Name = "colMatch";
            this.colMatch.OptionsColumn.AllowEdit = false;
            // 
            // colInsert
            // 
            this.colInsert.Caption = "Is Insert";
            this.colInsert.FieldName = "IsInsert";
            this.colInsert.Name = "colInsert";
            this.colInsert.OptionsColumn.AllowEdit = false;
            // 
            // colConvert
            // 
            this.colConvert.Caption = "Is Convert";
            this.colConvert.FieldName = "IsConvert";
            this.colConvert.Name = "colConvert";
            this.colConvert.OptionsColumn.AllowEdit = false;
            // 
            // colRedundancy
            // 
            this.colRedundancy.Caption = "Is Redundancy";
            this.colRedundancy.FieldName = "IsRedundancy";
            this.colRedundancy.Name = "colRedundancy";
            // 
            // colWorkStation
            // 
            this.colWorkStation.AppearanceCell.Options.UseTextOptions = true;
            this.colWorkStation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkStation.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkStation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkStation.Caption = "공정";
            this.colWorkStation.FieldName = "GroupKey";
            this.colWorkStation.Name = "colWorkStation";
            this.colWorkStation.OptionsColumn.AllowEdit = false;
            this.colWorkStation.Visible = true;
            this.colWorkStation.VisibleIndex = 1;
            // 
            // colEdit
            // 
            this.colEdit.Caption = "Is Edit";
            this.colEdit.FieldName = "IsEdit";
            this.colEdit.Name = "colEdit";
            // 
            // colExistedMatch
            // 
            this.colExistedMatch.Caption = "ExistedMatch";
            this.colExistedMatch.FieldName = "IsExistedMatch";
            this.colExistedMatch.Name = "colExistedMatch";
            // 
            // pnlHMIEdit
            // 
            this.pnlHMIEdit.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlHMIEdit.Appearance.Options.UseBackColor = true;
            this.pnlHMIEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHMIEdit.Controls.Add(this.panelControl2);
            this.pnlHMIEdit.Controls.Add(this.chkHMIEditable);
            this.pnlHMIEdit.Controls.Add(this.panelControl4);
            this.pnlHMIEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHMIEdit.Location = new System.Drawing.Point(0, 0);
            this.pnlHMIEdit.Name = "pnlHMIEdit";
            this.pnlHMIEdit.Size = new System.Drawing.Size(638, 30);
            this.pnlHMIEdit.TabIndex = 14;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(100, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(23, 30);
            this.panelControl2.TabIndex = 4;
            // 
            // chkHMIEditable
            // 
            this.chkHMIEditable.AutoSize = true;
            this.chkHMIEditable.BackColor = System.Drawing.Color.White;
            this.chkHMIEditable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkHMIEditable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHMIEditable.Location = new System.Drawing.Point(0, 0);
            this.chkHMIEditable.Name = "chkHMIEditable";
            this.chkHMIEditable.Size = new System.Drawing.Size(100, 30);
            this.chkHMIEditable.TabIndex = 0;
            this.chkHMIEditable.Text = "HMI 수정 가능";
            this.chkHMIEditable.UseVisualStyleBackColor = false;
            this.chkHMIEditable.CheckedChanged += new System.EventHandler(this.chkHMIEditable_CheckedChanged);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.lblHMIRowCount);
            this.panelControl4.Controls.Add(this.txtHMIRowCount);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl4.Location = new System.Drawing.Point(479, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(159, 30);
            this.panelControl4.TabIndex = 3;
            // 
            // lblHMIRowCount
            // 
            this.lblHMIRowCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHMIRowCount.Location = new System.Drawing.Point(0, 8);
            this.lblHMIRowCount.Name = "lblHMIRowCount";
            this.lblHMIRowCount.Size = new System.Drawing.Size(85, 14);
            this.lblHMIRowCount.TabIndex = 2;
            this.lblHMIRowCount.Text = "선택된 HMI 수 :";
            // 
            // txtHMIRowCount
            // 
            this.txtHMIRowCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtHMIRowCount.EditValue = ((short)(0));
            this.txtHMIRowCount.Location = new System.Drawing.Point(111, 5);
            this.txtHMIRowCount.MenuManager = this.FrmRibbon;
            this.txtHMIRowCount.Name = "txtHMIRowCount";
            this.txtHMIRowCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtHMIRowCount.Properties.ReadOnly = true;
            this.txtHMIRowCount.Size = new System.Drawing.Size(47, 20);
            this.txtHMIRowCount.TabIndex = 3;
            // 
            // tpPLCVerification
            // 
            this.tpPLCVerification.Controls.Add(this.sptVerification);
            this.tpPLCVerification.Name = "tpPLCVerification";
            this.tpPLCVerification.Size = new System.Drawing.Size(1333, 612);
            this.tpPLCVerification.Text = "PLC Verification";
            // 
            // sptVerification
            // 
            this.sptVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptVerification.Location = new System.Drawing.Point(0, 0);
            this.sptVerification.Name = "sptVerification";
            this.sptVerification.Panel1.Controls.Add(this.tabPLCVerif);
            this.sptVerification.Panel1.Text = "Panel1";
            this.sptVerification.Panel2.Controls.Add(this.tabPLCVerif2);
            this.sptVerification.Panel2.Text = "Panel2";
            this.sptVerification.Size = new System.Drawing.Size(1333, 612);
            this.sptVerification.SplitterPosition = 492;
            this.sptVerification.TabIndex = 0;
            this.sptVerification.Text = "splitContainerControl1";
            // 
            // tabPLCVerif
            // 
            this.tabPLCVerif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPLCVerif.Location = new System.Drawing.Point(0, 0);
            this.tabPLCVerif.Name = "tabPLCVerif";
            this.tabPLCVerif.SelectedTabPage = this.tpIOTree;
            this.tabPLCVerif.Size = new System.Drawing.Size(492, 612);
            this.tabPLCVerif.TabIndex = 10;
            this.tabPLCVerif.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpGrid,
            this.tpLadderView,
            this.tpIOTree,
            this.tpTagList});
            // 
            // tpIOTree
            // 
            this.tpIOTree.Controls.Add(this.ucVerifyIOTree);
            this.tpIOTree.Name = "tpIOTree";
            this.tpIOTree.Size = new System.Drawing.Size(486, 583);
            this.tpIOTree.Text = "IO 리스트";
            // 
            // ucVerifyIOTree
            // 
            this.ucVerifyIOTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVerifyIOTree.Location = new System.Drawing.Point(0, 0);
            this.ucVerifyIOTree.Name = "ucVerifyIOTree";
            this.ucVerifyIOTree.Size = new System.Drawing.Size(486, 583);
            this.ucVerifyIOTree.TabIndex = 0;
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.grdVerifPLC);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.PageVisible = false;
            this.tpGrid.Size = new System.Drawing.Size(486, 583);
            this.tpGrid.Text = "검도 표";
            // 
            // grdVerifPLC
            // 
            this.grdVerifPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVerifPLC.Location = new System.Drawing.Point(0, 0);
            this.grdVerifPLC.LookAndFeel.SkinName = "Metropolis";
            this.grdVerifPLC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdVerifPLC.MainView = this.grvVerifPLC;
            this.grdVerifPLC.MenuManager = this.FrmRibbon;
            this.grdVerifPLC.Name = "grdVerifPLC";
            this.grdVerifPLC.Size = new System.Drawing.Size(486, 583);
            this.grdVerifPLC.TabIndex = 9;
            this.grdVerifPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerifPLC});
            this.grdVerifPLC.DoubleClick += new System.EventHandler(this.grdVerifPLC_DoubleClick);
            // 
            // grvVerifPLC
            // 
            this.grvVerifPLC.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvVerifPLC.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerifPLC.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVerifPLC.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVerifPLC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerifPLC,
            this.colVerifName,
            this.colVerifAddress,
            this.colVerifDescription,
            this.colUsedLogic,
            this.colSymbolRole});
            this.grvVerifPLC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerifPLC.GridControl = this.grdVerifPLC;
            this.grvVerifPLC.Name = "grvVerifPLC";
            this.grvVerifPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvVerifPLC.OptionsBehavior.Editable = false;
            this.grvVerifPLC.OptionsBehavior.ReadOnly = true;
            this.grvVerifPLC.OptionsDetail.EnableMasterViewMode = false;
            this.grvVerifPLC.OptionsDetail.SmartDetailExpand = false;
            this.grvVerifPLC.OptionsFind.AlwaysVisible = true;
            this.grvVerifPLC.OptionsSelection.MultiSelect = true;
            this.grvVerifPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvVerifPLC.OptionsView.ShowAutoFilterRow = true;
            // 
            // colVerifPLC
            // 
            this.colVerifPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifPLC.Caption = "PLC";
            this.colVerifPLC.FieldName = "Channel";
            this.colVerifPLC.Name = "colVerifPLC";
            this.colVerifPLC.OptionsColumn.AllowEdit = false;
            this.colVerifPLC.OptionsColumn.AllowShowHide = false;
            this.colVerifPLC.Visible = true;
            this.colVerifPLC.VisibleIndex = 0;
            this.colVerifPLC.Width = 72;
            // 
            // colVerifName
            // 
            this.colVerifName.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colVerifName.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifName.Caption = "Name";
            this.colVerifName.FieldName = "Name";
            this.colVerifName.Name = "colVerifName";
            this.colVerifName.OptionsColumn.AllowEdit = false;
            this.colVerifName.OptionsColumn.AllowShowHide = false;
            this.colVerifName.Visible = true;
            this.colVerifName.VisibleIndex = 1;
            this.colVerifName.Width = 72;
            // 
            // colVerifAddress
            // 
            this.colVerifAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colVerifAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifAddress.Caption = "Address";
            this.colVerifAddress.FieldName = "Address";
            this.colVerifAddress.Name = "colVerifAddress";
            this.colVerifAddress.OptionsColumn.AllowEdit = false;
            this.colVerifAddress.OptionsColumn.AllowShowHide = false;
            this.colVerifAddress.Visible = true;
            this.colVerifAddress.VisibleIndex = 2;
            this.colVerifAddress.Width = 72;
            // 
            // colVerifDescription
            // 
            this.colVerifDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colVerifDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifDescription.Caption = "Description";
            this.colVerifDescription.FieldName = "Description";
            this.colVerifDescription.Name = "colVerifDescription";
            this.colVerifDescription.OptionsColumn.AllowEdit = false;
            this.colVerifDescription.OptionsColumn.AllowShowHide = false;
            this.colVerifDescription.Visible = true;
            this.colVerifDescription.VisibleIndex = 3;
            this.colVerifDescription.Width = 72;
            // 
            // colUsedLogic
            // 
            this.colUsedLogic.AppearanceCell.Options.UseTextOptions = true;
            this.colUsedLogic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUsedLogic.AppearanceHeader.Options.UseTextOptions = true;
            this.colUsedLogic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUsedLogic.Caption = "Used Logic";
            this.colUsedLogic.FieldName = "UsedLogic";
            this.colUsedLogic.Name = "colUsedLogic";
            this.colUsedLogic.Visible = true;
            this.colUsedLogic.VisibleIndex = 4;
            // 
            // colSymbolRole
            // 
            this.colSymbolRole.AppearanceCell.Options.UseTextOptions = true;
            this.colSymbolRole.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSymbolRole.AppearanceHeader.Options.UseTextOptions = true;
            this.colSymbolRole.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSymbolRole.Caption = "Symbol Role";
            this.colSymbolRole.FieldName = "SymbolRole";
            this.colSymbolRole.Name = "colSymbolRole";
            this.colSymbolRole.Visible = true;
            this.colSymbolRole.VisibleIndex = 5;
            // 
            // tpLadderView
            // 
            this.tpLadderView.Controls.Add(this.pnlView);
            this.tpLadderView.Name = "tpLadderView";
            this.tpLadderView.PageVisible = false;
            this.tpLadderView.Size = new System.Drawing.Size(486, 583);
            this.tpLadderView.Text = "래더 뷰";
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.pnlLadderView);
            this.pnlView.Controls.Add(this.pnlLadderViewBtn);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(486, 583);
            this.pnlView.TabIndex = 0;
            // 
            // pnlLadderView
            // 
            this.pnlLadderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLadderView.Location = new System.Drawing.Point(2, 46);
            this.pnlLadderView.Name = "pnlLadderView";
            this.pnlLadderView.Size = new System.Drawing.Size(482, 535);
            this.pnlLadderView.TabIndex = 1;
            // 
            // pnlLadderViewBtn
            // 
            this.pnlLadderViewBtn.Controls.Add(this.btnClearLadderView);
            this.pnlLadderViewBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLadderViewBtn.Location = new System.Drawing.Point(2, 2);
            this.pnlLadderViewBtn.Name = "pnlLadderViewBtn";
            this.pnlLadderViewBtn.Size = new System.Drawing.Size(482, 44);
            this.pnlLadderViewBtn.TabIndex = 0;
            // 
            // btnClearLadderView
            // 
            this.btnClearLadderView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearLadderView.Location = new System.Drawing.Point(381, 2);
            this.btnClearLadderView.Name = "btnClearLadderView";
            this.btnClearLadderView.Size = new System.Drawing.Size(99, 40);
            this.btnClearLadderView.TabIndex = 0;
            this.btnClearLadderView.Text = "래더 뷰 지우기";
            this.btnClearLadderView.Click += new System.EventHandler(this.btnClearLadderView_Click);
            // 
            // tpTagList
            // 
            this.tpTagList.Controls.Add(this.ucVerifyAllTree);
            this.tpTagList.Name = "tpTagList";
            this.tpTagList.Size = new System.Drawing.Size(486, 583);
            this.tpTagList.Text = "태그 리스트";
            // 
            // ucVerifyAllTree
            // 
            this.ucVerifyAllTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVerifyAllTree.Location = new System.Drawing.Point(0, 0);
            this.ucVerifyAllTree.Name = "ucVerifyAllTree";
            this.ucVerifyAllTree.Size = new System.Drawing.Size(486, 583);
            this.ucVerifyAllTree.TabIndex = 1;
            // 
            // tabPLCVerif2
            // 
            this.tabPLCVerif2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPLCVerif2.Location = new System.Drawing.Point(0, 0);
            this.tabPLCVerif2.Name = "tabPLCVerif2";
            this.tabPLCVerif2.SelectedTabPage = this.tpReport;
            this.tabPLCVerif2.Size = new System.Drawing.Size(836, 612);
            this.tabPLCVerif2.TabIndex = 1;
            this.tabPLCVerif2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpReportElement,
            this.tpReport});
            // 
            // tpReport
            // 
            this.tpReport.Controls.Add(this.sheetVerification);
            this.tpReport.Controls.Add(this.panelControl22);
            this.tpReport.Name = "tpReport";
            this.tpReport.Size = new System.Drawing.Size(830, 583);
            this.tpReport.Text = "리포트";
            // 
            // sheetVerification
            // 
            this.sheetVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetVerification.Location = new System.Drawing.Point(0, 38);
            this.sheetVerification.MenuManager = this.FrmRibbon;
            this.sheetVerification.Name = "sheetVerification";
            this.sheetVerification.ReadOnly = true;
            this.sheetVerification.Size = new System.Drawing.Size(830, 545);
            this.sheetVerification.TabIndex = 0;
            this.sheetVerification.Text = "spreadsheetControl1";
            // 
            // panelControl22
            // 
            this.panelControl22.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl22.Appearance.Options.UseBackColor = true;
            this.panelControl22.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl22.Controls.Add(this.btnReportInit);
            this.panelControl22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl22.Location = new System.Drawing.Point(0, 0);
            this.panelControl22.Name = "panelControl22";
            this.panelControl22.Size = new System.Drawing.Size(830, 38);
            this.panelControl22.TabIndex = 1;
            // 
            // btnReportInit
            // 
            this.btnReportInit.Appearance.BackColor = System.Drawing.Color.White;
            this.btnReportInit.Appearance.Options.UseBackColor = true;
            this.btnReportInit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReportInit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReportInit.Image = ((System.Drawing.Image)(resources.GetObject("btnReportInit.Image")));
            this.btnReportInit.Location = new System.Drawing.Point(700, 0);
            this.btnReportInit.Name = "btnReportInit";
            this.btnReportInit.Size = new System.Drawing.Size(130, 38);
            this.btnReportInit.TabIndex = 7;
            this.btnReportInit.Text = "리포트 초기화";
            this.btnReportInit.Click += new System.EventHandler(this.btnReportInit_Click);
            // 
            // tpReportElement
            // 
            this.tpReportElement.Controls.Add(this.groupControl2);
            this.tpReportElement.Controls.Add(this.panelControl21);
            this.tpReportElement.Name = "tpReportElement";
            this.tpReportElement.Size = new System.Drawing.Size(830, 583);
            this.tpReportElement.Text = "리포트 항목";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ucVerifyElemTree);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 55);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(830, 528);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "리포트 항목 요소";
            // 
            // ucVerifyElemTree
            // 
            this.ucVerifyElemTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVerifyElemTree.Location = new System.Drawing.Point(2, 21);
            this.ucVerifyElemTree.Name = "ucVerifyElemTree";
            this.ucVerifyElemTree.Size = new System.Drawing.Size(826, 505);
            this.ucVerifyElemTree.TabIndex = 0;
            // 
            // panelControl21
            // 
            this.panelControl21.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl21.Appearance.Options.UseBackColor = true;
            this.panelControl21.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl21.Controls.Add(this.btnReportTreeClear);
            this.panelControl21.Controls.Add(this.btnVerifSettingApply);
            this.panelControl21.Controls.Add(this.btnReportElemSetting);
            this.panelControl21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl21.Location = new System.Drawing.Point(0, 0);
            this.panelControl21.Name = "panelControl21";
            this.panelControl21.Size = new System.Drawing.Size(830, 55);
            this.panelControl21.TabIndex = 0;
            // 
            // btnReportTreeClear
            // 
            this.btnReportTreeClear.Appearance.BackColor = System.Drawing.Color.White;
            this.btnReportTreeClear.Appearance.Options.UseBackColor = true;
            this.btnReportTreeClear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReportTreeClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReportTreeClear.Image = ((System.Drawing.Image)(resources.GetObject("btnReportTreeClear.Image")));
            this.btnReportTreeClear.Location = new System.Drawing.Point(577, 0);
            this.btnReportTreeClear.Name = "btnReportTreeClear";
            this.btnReportTreeClear.Size = new System.Drawing.Size(130, 55);
            this.btnReportTreeClear.TabIndex = 6;
            this.btnReportTreeClear.Text = "리포트 트리\r\n지우기";
            this.btnReportTreeClear.Click += new System.EventHandler(this.btnReportTreeClear_Click);
            // 
            // btnVerifSettingApply
            // 
            this.btnVerifSettingApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnVerifSettingApply.Appearance.Options.UseBackColor = true;
            this.btnVerifSettingApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnVerifSettingApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVerifSettingApply.Image = ((System.Drawing.Image)(resources.GetObject("btnVerifSettingApply.Image")));
            this.btnVerifSettingApply.Location = new System.Drawing.Point(707, 0);
            this.btnVerifSettingApply.Name = "btnVerifSettingApply";
            this.btnVerifSettingApply.Size = new System.Drawing.Size(123, 55);
            this.btnVerifSettingApply.TabIndex = 5;
            this.btnVerifSettingApply.Text = "설정 항목 \r\n리포트 적용";
            this.btnVerifSettingApply.Click += new System.EventHandler(this.btnVerifSettingApply_Click);
            // 
            // btnReportElemSetting
            // 
            this.btnReportElemSetting.Appearance.BackColor = System.Drawing.Color.White;
            this.btnReportElemSetting.Appearance.Options.UseBackColor = true;
            this.btnReportElemSetting.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReportElemSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReportElemSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnReportElemSetting.Image")));
            this.btnReportElemSetting.Location = new System.Drawing.Point(0, 0);
            this.btnReportElemSetting.Name = "btnReportElemSetting";
            this.btnReportElemSetting.Size = new System.Drawing.Size(88, 55);
            this.btnReportElemSetting.TabIndex = 4;
            this.btnReportElemSetting.Text = "항목\r\n설정";
            this.btnReportElemSetting.Click += new System.EventHandler(this.btnReportElemSetting_Click);
            // 
            // tpHMIVerification
            // 
            this.tpHMIVerification.Controls.Add(this.sptHMIVerification);
            this.tpHMIVerification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpHMIVerification.Name = "tpHMIVerification";
            this.tpHMIVerification.Size = new System.Drawing.Size(1333, 612);
            this.tpHMIVerification.Text = "HMI Verification";
            // 
            // sptHMIVerification
            // 
            this.sptHMIVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptHMIVerification.Location = new System.Drawing.Point(0, 0);
            this.sptHMIVerification.Name = "sptHMIVerification";
            this.sptHMIVerification.Panel1.Controls.Add(this.grdVerifHMI);
            this.sptHMIVerification.Panel1.Controls.Add(this.grpFilterOption);
            this.sptHMIVerification.Panel1.Text = "Panel1";
            this.sptHMIVerification.Panel2.Controls.Add(this.sheetHMIVerification);
            this.sptHMIVerification.Panel2.Text = "Panel2";
            this.sptHMIVerification.Size = new System.Drawing.Size(1333, 612);
            this.sptHMIVerification.SplitterPosition = 492;
            this.sptHMIVerification.TabIndex = 1;
            this.sptHMIVerification.Text = "splitContainerControl1";
            // 
            // grdVerifHMI
            // 
            this.grdVerifHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVerifHMI.Location = new System.Drawing.Point(0, 59);
            this.grdVerifHMI.LookAndFeel.SkinName = "Metropolis";
            this.grdVerifHMI.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdVerifHMI.MainView = this.grvVerifHMI;
            this.grdVerifHMI.MenuManager = this.FrmRibbon;
            this.grdVerifHMI.Name = "grdVerifHMI";
            this.grdVerifHMI.Size = new System.Drawing.Size(492, 553);
            this.grdVerifHMI.TabIndex = 16;
            this.grdVerifHMI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerifHMI});
            // 
            // grvVerifHMI
            // 
            this.grvVerifHMI.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvVerifHMI.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerifHMI.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVerifHMI.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVerifHMI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerifNumber,
            this.colVerifGroup,
            this.colVerifHMIName,
            this.colVerifHMIDataType,
            this.colVerifHMIAddress,
            this.colVerifHMIDesc,
            this.colVerifIsMatch,
            this.colVerifIsInsert,
            this.colVerifIsConvert,
            this.colVerifIsRedundancy,
            this.colVerifIsEmpty});
            this.grvVerifHMI.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerifHMI.GridControl = this.grdVerifHMI;
            this.grvVerifHMI.IndicatorWidth = 60;
            this.grvVerifHMI.Name = "grvVerifHMI";
            this.grvVerifHMI.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvVerifHMI.OptionsBehavior.Editable = false;
            this.grvVerifHMI.OptionsBehavior.ReadOnly = true;
            this.grvVerifHMI.OptionsDetail.EnableMasterViewMode = false;
            this.grvVerifHMI.OptionsDetail.SmartDetailExpand = false;
            this.grvVerifHMI.OptionsFind.AlwaysVisible = true;
            this.grvVerifHMI.OptionsSelection.MultiSelect = true;
            this.grvVerifHMI.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvVerifHMI.OptionsView.ShowAutoFilterRow = true;
            this.grvVerifHMI.OptionsView.ShowIndicator = false;
            this.grvVerifHMI.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvVerifHMI_RowCellStyle);
            this.grvVerifHMI.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvVerifHMI_MouseUp);
            this.grvVerifHMI.DoubleClick += new System.EventHandler(this.grvVerifHMI_DoubleClick);
            // 
            // colVerifNumber
            // 
            this.colVerifNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifNumber.Caption = "#번호";
            this.colVerifNumber.FieldName = "Number";
            this.colVerifNumber.Name = "colVerifNumber";
            this.colVerifNumber.OptionsColumn.AllowEdit = false;
            this.colVerifNumber.OptionsColumn.FixedWidth = true;
            this.colVerifNumber.Visible = true;
            this.colVerifNumber.VisibleIndex = 0;
            this.colVerifNumber.Width = 70;
            // 
            // colVerifGroup
            // 
            this.colVerifGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifGroup.Caption = "그룹";
            this.colVerifGroup.FieldName = "Group";
            this.colVerifGroup.Name = "colVerifGroup";
            this.colVerifGroup.OptionsColumn.AllowEdit = false;
            this.colVerifGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colVerifGroup.Visible = true;
            this.colVerifGroup.VisibleIndex = 1;
            this.colVerifGroup.Width = 83;
            // 
            // colVerifHMIName
            // 
            this.colVerifHMIName.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifHMIName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIName.Caption = "이름";
            this.colVerifHMIName.FieldName = "Name";
            this.colVerifHMIName.Name = "colVerifHMIName";
            this.colVerifHMIName.OptionsColumn.AllowEdit = false;
            this.colVerifHMIName.Visible = true;
            this.colVerifHMIName.VisibleIndex = 2;
            this.colVerifHMIName.Width = 83;
            // 
            // colVerifHMIDataType
            // 
            this.colVerifHMIDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifHMIDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifHMIDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIDataType.Caption = "타입";
            this.colVerifHMIDataType.FieldName = "DataType";
            this.colVerifHMIDataType.Name = "colVerifHMIDataType";
            this.colVerifHMIDataType.OptionsColumn.AllowEdit = false;
            this.colVerifHMIDataType.Visible = true;
            this.colVerifHMIDataType.VisibleIndex = 3;
            this.colVerifHMIDataType.Width = 83;
            // 
            // colVerifHMIAddress
            // 
            this.colVerifHMIAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colVerifHMIAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifHMIAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIAddress.Caption = "디바이스";
            this.colVerifHMIAddress.FieldName = "Address";
            this.colVerifHMIAddress.Name = "colVerifHMIAddress";
            this.colVerifHMIAddress.OptionsColumn.AllowEdit = false;
            this.colVerifHMIAddress.Visible = true;
            this.colVerifHMIAddress.VisibleIndex = 4;
            this.colVerifHMIAddress.Width = 83;
            // 
            // colVerifHMIDesc
            // 
            this.colVerifHMIDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colVerifHMIDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVerifHMIDesc.Caption = "설명";
            this.colVerifHMIDesc.FieldName = "Description";
            this.colVerifHMIDesc.Name = "colVerifHMIDesc";
            this.colVerifHMIDesc.OptionsColumn.AllowEdit = false;
            this.colVerifHMIDesc.Visible = true;
            this.colVerifHMIDesc.VisibleIndex = 5;
            this.colVerifHMIDesc.Width = 88;
            // 
            // colVerifIsMatch
            // 
            this.colVerifIsMatch.Caption = "Is Match";
            this.colVerifIsMatch.FieldName = "IsMatch";
            this.colVerifIsMatch.Name = "colVerifIsMatch";
            this.colVerifIsMatch.OptionsColumn.AllowEdit = false;
            // 
            // colVerifIsInsert
            // 
            this.colVerifIsInsert.Caption = "Is Insert";
            this.colVerifIsInsert.FieldName = "IsInsert";
            this.colVerifIsInsert.Name = "colVerifIsInsert";
            this.colVerifIsInsert.OptionsColumn.AllowEdit = false;
            // 
            // colVerifIsConvert
            // 
            this.colVerifIsConvert.Caption = "Is Convert";
            this.colVerifIsConvert.FieldName = "IsConvert";
            this.colVerifIsConvert.Name = "colVerifIsConvert";
            this.colVerifIsConvert.OptionsColumn.AllowEdit = false;
            // 
            // colVerifIsRedundancy
            // 
            this.colVerifIsRedundancy.Caption = "Is Redundancy";
            this.colVerifIsRedundancy.FieldName = "IsRedundancy";
            this.colVerifIsRedundancy.Name = "colVerifIsRedundancy";
            // 
            // colVerifIsEmpty
            // 
            this.colVerifIsEmpty.Caption = "Is Empty";
            this.colVerifIsEmpty.FieldName = "IsEmpty";
            this.colVerifIsEmpty.Name = "colVerifIsEmpty";
            // 
            // grpFilterOption
            // 
            this.grpFilterOption.Controls.Add(this.chkNullEmpty);
            this.grpFilterOption.Controls.Add(this.chkRedundancy);
            this.grpFilterOption.Controls.Add(this.chkMapping);
            this.grpFilterOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilterOption.Location = new System.Drawing.Point(0, 0);
            this.grpFilterOption.Name = "grpFilterOption";
            this.grpFilterOption.Size = new System.Drawing.Size(492, 59);
            this.grpFilterOption.TabIndex = 17;
            this.grpFilterOption.TabStop = false;
            this.grpFilterOption.Text = "Filter Option";
            // 
            // chkNullEmpty
            // 
            this.chkNullEmpty.Appearance.BackColor = System.Drawing.Color.White;
            this.chkNullEmpty.Appearance.Options.UseBackColor = true;
            this.chkNullEmpty.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkNullEmpty.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkNullEmpty.Location = new System.Drawing.Point(163, 18);
            this.chkNullEmpty.Name = "chkNullEmpty";
            this.chkNullEmpty.Size = new System.Drawing.Size(80, 38);
            this.chkNullEmpty.TabIndex = 7;
            this.chkNullEmpty.Text = "Null/Empty";
            this.chkNullEmpty.CheckedChanged += new System.EventHandler(this.chkMappingNotRedun_CheckedChanged);
            // 
            // chkRedundancy
            // 
            this.chkRedundancy.Appearance.BackColor = System.Drawing.Color.White;
            this.chkRedundancy.Appearance.Options.UseBackColor = true;
            this.chkRedundancy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkRedundancy.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkRedundancy.Location = new System.Drawing.Point(83, 18);
            this.chkRedundancy.Name = "chkRedundancy";
            this.chkRedundancy.Size = new System.Drawing.Size(80, 38);
            this.chkRedundancy.TabIndex = 8;
            this.chkRedundancy.Text = "중복";
            this.chkRedundancy.CheckedChanged += new System.EventHandler(this.chkRedundancy_CheckedChanged);
            // 
            // chkMapping
            // 
            this.chkMapping.Appearance.BackColor = System.Drawing.Color.White;
            this.chkMapping.Appearance.Options.UseBackColor = true;
            this.chkMapping.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkMapping.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkMapping.Location = new System.Drawing.Point(3, 18);
            this.chkMapping.Name = "chkMapping";
            this.chkMapping.Size = new System.Drawing.Size(80, 38);
            this.chkMapping.TabIndex = 6;
            this.chkMapping.Text = "1:1 매핑";
            this.chkMapping.CheckedChanged += new System.EventHandler(this.chkMappingRedun_CheckedChanged);
            // 
            // sheetHMIVerification
            // 
            this.sheetHMIVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sheetHMIVerification.Location = new System.Drawing.Point(0, 0);
            this.sheetHMIVerification.MenuManager = this.FrmRibbon;
            this.sheetHMIVerification.Name = "sheetHMIVerification";
            this.sheetHMIVerification.ReadOnly = true;
            this.sheetHMIVerification.Size = new System.Drawing.Size(836, 612);
            this.sheetHMIVerification.TabIndex = 0;
            this.sheetHMIVerification.Text = "spreadsheetControl1";
            // 
            // tpHelp
            // 
            this.tpHelp.Controls.Add(this.tabHelp);
            this.tpHelp.Name = "tpHelp";
            this.tpHelp.Size = new System.Drawing.Size(1333, 612);
            this.tpHelp.Text = "Help";
            // 
            // tabHelp
            // 
            this.tabHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHelp.Location = new System.Drawing.Point(0, 0);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.SelectedTabPage = this.tpManual;
            this.tabHelp.Size = new System.Drawing.Size(1333, 612);
            this.tabHelp.TabIndex = 1;
            this.tabHelp.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpManual});
            // 
            // tpManual
            // 
            this.tpManual.Controls.Add(this.pdfViewer);
            this.tpManual.Name = "tpManual";
            this.tpManual.Size = new System.Drawing.Size(1327, 583);
            this.tpManual.Text = "PDF Viewer";
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(1327, 583);
            this.pdfViewer.TabIndex = 0;
            // 
            // tpIOList
            // 
            this.tpIOList.Controls.Add(this.pnlIOList);
            this.tpIOList.Name = "tpIOList";
            this.tpIOList.Size = new System.Drawing.Size(1333, 612);
            this.tpIOList.Text = "I/O List";
            // 
            // pnlIOList
            // 
            this.pnlIOList.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlIOList.Appearance.Options.UseBackColor = true;
            this.pnlIOList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlIOList.Controls.Add(this.IOSpreadSheet);
            this.pnlIOList.Controls.Add(this.panelControl23);
            this.pnlIOList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIOList.Location = new System.Drawing.Point(0, 0);
            this.pnlIOList.Name = "pnlIOList";
            this.pnlIOList.Size = new System.Drawing.Size(1333, 612);
            this.pnlIOList.TabIndex = 0;
            // 
            // IOSpreadSheet
            // 
            this.IOSpreadSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOSpreadSheet.Location = new System.Drawing.Point(0, 38);
            this.IOSpreadSheet.MenuManager = this.FrmRibbon;
            this.IOSpreadSheet.Name = "IOSpreadSheet";
            this.IOSpreadSheet.Size = new System.Drawing.Size(1333, 574);
            this.IOSpreadSheet.TabIndex = 0;
            this.IOSpreadSheet.Text = "spreadsheetControl1";
            // 
            // panelControl23
            // 
            this.panelControl23.Controls.Add(this.chkExcelEditable);
            this.panelControl23.Controls.Add(this.panelControl24);
            this.panelControl23.Controls.Add(this.panelControl27);
            this.panelControl23.Controls.Add(this.btnOpenExcelPath);
            this.panelControl23.Controls.Add(this.btnExcelSave);
            this.panelControl23.Controls.Add(this.chkExcelEdit);
            this.panelControl23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl23.Location = new System.Drawing.Point(0, 0);
            this.panelControl23.Name = "panelControl23";
            this.panelControl23.Size = new System.Drawing.Size(1333, 38);
            this.panelControl23.TabIndex = 1;
            // 
            // chkExcelEditable
            // 
            this.chkExcelEditable.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.chkExcelEditable.Checked = true;
            this.chkExcelEditable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkExcelEditable.Image = ((System.Drawing.Image)(resources.GetObject("chkExcelEditable.Image")));
            this.chkExcelEditable.Location = new System.Drawing.Point(112, 2);
            this.chkExcelEditable.Name = "chkExcelEditable";
            this.chkExcelEditable.Size = new System.Drawing.Size(149, 34);
            this.chkExcelEditable.TabIndex = 5;
            this.chkExcelEditable.Text = "Excel 수정 가능";
            this.chkExcelEditable.CheckedChanged += new System.EventHandler(this.chkExcelEditable_CheckedChanged);
            // 
            // panelControl24
            // 
            this.panelControl24.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl24.Controls.Add(this.labelControl6);
            this.panelControl24.Controls.Add(this.btnSavePathOpen);
            this.panelControl24.Controls.Add(this.panelControl26);
            this.panelControl24.Controls.Add(this.panelControl25);
            this.panelControl24.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl24.Location = new System.Drawing.Point(532, 2);
            this.panelControl24.Name = "panelControl24";
            this.panelControl24.Size = new System.Drawing.Size(556, 34);
            this.panelControl24.TabIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelControl6.Location = new System.Drawing.Point(12, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 24);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = " 저장 경로 : ";
            // 
            // btnSavePathOpen
            // 
            this.btnSavePathOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSavePathOpen.Location = new System.Drawing.Point(93, 5);
            this.btnSavePathOpen.MenuManager = this.FrmRibbon;
            this.btnSavePathOpen.Name = "btnSavePathOpen";
            this.btnSavePathOpen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSavePathOpen.Properties.ReadOnly = true;
            this.btnSavePathOpen.Size = new System.Drawing.Size(463, 20);
            this.btnSavePathOpen.TabIndex = 2;
            this.btnSavePathOpen.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSavePathOpen_ButtonClick);
            // 
            // panelControl26
            // 
            this.panelControl26.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl26.Location = new System.Drawing.Point(0, 29);
            this.panelControl26.Name = "panelControl26";
            this.panelControl26.Size = new System.Drawing.Size(556, 5);
            this.panelControl26.TabIndex = 1;
            // 
            // panelControl25
            // 
            this.panelControl25.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl25.Location = new System.Drawing.Point(0, 0);
            this.panelControl25.Name = "panelControl25";
            this.panelControl25.Size = new System.Drawing.Size(556, 5);
            this.panelControl25.TabIndex = 0;
            // 
            // panelControl27
            // 
            this.panelControl27.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl27.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl27.Location = new System.Drawing.Point(1088, 2);
            this.panelControl27.Name = "panelControl27";
            this.panelControl27.Size = new System.Drawing.Size(25, 34);
            this.panelControl27.TabIndex = 4;
            // 
            // btnOpenExcelPath
            // 
            this.btnOpenExcelPath.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenExcelPath.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenExcelPath.Image")));
            this.btnOpenExcelPath.Location = new System.Drawing.Point(1113, 2);
            this.btnOpenExcelPath.Name = "btnOpenExcelPath";
            this.btnOpenExcelPath.Size = new System.Drawing.Size(122, 34);
            this.btnOpenExcelPath.TabIndex = 2;
            this.btnOpenExcelPath.Text = "저장 경로 열기";
            this.btnOpenExcelPath.Visible = false;
            this.btnOpenExcelPath.Click += new System.EventHandler(this.btnOpenExcelPath_Click);
            // 
            // btnExcelSave
            // 
            this.btnExcelSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExcelSave.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelSave.Image")));
            this.btnExcelSave.Location = new System.Drawing.Point(1235, 2);
            this.btnExcelSave.Name = "btnExcelSave";
            this.btnExcelSave.Size = new System.Drawing.Size(96, 34);
            this.btnExcelSave.TabIndex = 1;
            this.btnExcelSave.Text = "저장하기";
            this.btnExcelSave.Click += new System.EventHandler(this.btnExcelSave_Click);
            // 
            // chkExcelEdit
            // 
            this.chkExcelEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkExcelEdit.EditValue = true;
            this.chkExcelEdit.Location = new System.Drawing.Point(2, 2);
            this.chkExcelEdit.MenuManager = this.FrmRibbon;
            this.chkExcelEdit.Name = "chkExcelEdit";
            this.chkExcelEdit.Properties.AutoHeight = false;
            this.chkExcelEdit.Properties.Caption = " Excel 수정 가능";
            this.chkExcelEdit.Size = new System.Drawing.Size(110, 34);
            this.chkExcelEdit.TabIndex = 0;
            this.chkExcelEdit.Visible = false;
            this.chkExcelEdit.CheckedChanged += new System.EventHandler(this.chkExcelEdit_CheckedChanged);
            // 
            // tpDesign
            // 
            this.tpDesign.Controls.Add(this.tabDesign);
            this.tpDesign.Name = "tpDesign";
            this.tpDesign.Size = new System.Drawing.Size(1333, 612);
            this.tpDesign.Text = "Design";
            // 
            // tabDesign
            // 
            this.tabDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDesign.Location = new System.Drawing.Point(0, 0);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.SelectedTabPage = this.tpDesignDesign;
            this.tabDesign.Size = new System.Drawing.Size(1333, 612);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpDesignDesign,
            this.tpDesignStandardization});
            // 
            // tpDesignDesign
            // 
            this.tpDesignDesign.Controls.Add(this.pnlDesign2);
            this.tpDesignDesign.Controls.Add(this.sptDesign);
            this.tpDesignDesign.Controls.Add(this.pnlDesign1);
            this.tpDesignDesign.Name = "tpDesignDesign";
            this.tpDesignDesign.Size = new System.Drawing.Size(1327, 583);
            this.tpDesignDesign.Text = "PLC 심볼 설계";
            // 
            // pnlDesign2
            // 
            this.pnlDesign2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDesign2.Controls.Add(this.grdDesignPLC);
            this.pnlDesign2.Controls.Add(this.pnlDesignControl);
            this.pnlDesign2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesign2.Location = new System.Drawing.Point(605, 0);
            this.pnlDesign2.Name = "pnlDesign2";
            this.pnlDesign2.Size = new System.Drawing.Size(722, 583);
            this.pnlDesign2.TabIndex = 2;
            // 
            // grdDesignPLC
            // 
            this.grdDesignPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDesignPLC.Location = new System.Drawing.Point(0, 40);
            this.grdDesignPLC.LookAndFeel.SkinName = "Metropolis";
            this.grdDesignPLC.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdDesignPLC.MainView = this.grvDesignPLC;
            this.grdDesignPLC.MenuManager = this.FrmRibbon;
            this.grdDesignPLC.Name = "grdDesignPLC";
            this.grdDesignPLC.Size = new System.Drawing.Size(722, 543);
            this.grdDesignPLC.TabIndex = 9;
            this.grdDesignPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDesignPLC});
            // 
            // grvDesignPLC
            // 
            this.grvDesignPLC.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvDesignPLC.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvDesignPLC.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDesignPLC.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDesignPLC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDesignPLC,
            this.colDesignName,
            this.colDesignAddress,
            this.colDesignDescription,
            this.colDesignDataType,
            this.colDesignKey,
            this.colDesignNote});
            this.grvDesignPLC.GridControl = this.grdDesignPLC;
            this.grvDesignPLC.IndicatorWidth = 60;
            this.grvDesignPLC.Name = "grvDesignPLC";
            this.grvDesignPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvDesignPLC.OptionsDetail.EnableMasterViewMode = false;
            this.grvDesignPLC.OptionsDetail.SmartDetailExpand = false;
            this.grvDesignPLC.OptionsFind.AlwaysVisible = true;
            this.grvDesignPLC.OptionsSelection.MultiSelect = true;
            this.grvDesignPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvDesignPLC.OptionsView.ShowAutoFilterRow = true;
            this.grvDesignPLC.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDesignPLC_CustomDrawRowIndicator);
            this.grvDesignPLC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDesignPLC_CellValueChanged);
            this.grvDesignPLC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvDesignPLC_MouseUp);
            // 
            // colDesignPLC
            // 
            this.colDesignPLC.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignPLC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignPLC.Caption = "PLC";
            this.colDesignPLC.FieldName = "Channel";
            this.colDesignPLC.Name = "colDesignPLC";
            this.colDesignPLC.OptionsColumn.AllowEdit = false;
            this.colDesignPLC.Visible = true;
            this.colDesignPLC.VisibleIndex = 0;
            this.colDesignPLC.Width = 126;
            // 
            // colDesignName
            // 
            this.colDesignName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignName.AppearanceCell.Options.UseFont = true;
            this.colDesignName.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignName.Caption = "Name";
            this.colDesignName.FieldName = "Name";
            this.colDesignName.Name = "colDesignName";
            this.colDesignName.OptionsColumn.AllowEdit = false;
            this.colDesignName.Visible = true;
            this.colDesignName.VisibleIndex = 1;
            this.colDesignName.Width = 121;
            // 
            // colDesignAddress
            // 
            this.colDesignAddress.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignAddress.AppearanceCell.Options.UseFont = true;
            this.colDesignAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignAddress.Caption = "Address";
            this.colDesignAddress.FieldName = "Address";
            this.colDesignAddress.Name = "colDesignAddress";
            this.colDesignAddress.OptionsColumn.AllowEdit = false;
            this.colDesignAddress.Visible = true;
            this.colDesignAddress.VisibleIndex = 2;
            this.colDesignAddress.Width = 246;
            // 
            // colDesignDescription
            // 
            this.colDesignDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDesignDescription.AppearanceCell.Options.UseFont = true;
            this.colDesignDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDesignDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDescription.Caption = "Description";
            this.colDesignDescription.FieldName = "Description";
            this.colDesignDescription.MinWidth = 300;
            this.colDesignDescription.Name = "colDesignDescription";
            this.colDesignDescription.OptionsColumn.AllowEdit = false;
            this.colDesignDescription.Visible = true;
            this.colDesignDescription.VisibleIndex = 3;
            this.colDesignDescription.Width = 300;
            // 
            // colDesignDataType
            // 
            this.colDesignDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignDataType.Caption = "DataType";
            this.colDesignDataType.FieldName = "DataType";
            this.colDesignDataType.MinWidth = 120;
            this.colDesignDataType.Name = "colDesignDataType";
            this.colDesignDataType.OptionsColumn.AllowEdit = false;
            this.colDesignDataType.Visible = true;
            this.colDesignDataType.VisibleIndex = 4;
            this.colDesignDataType.Width = 120;
            // 
            // colDesignKey
            // 
            this.colDesignKey.Caption = "Key";
            this.colDesignKey.FieldName = "Key";
            this.colDesignKey.Name = "colDesignKey";
            // 
            // colDesignNote
            // 
            this.colDesignNote.AppearanceCell.Options.UseTextOptions = true;
            this.colDesignNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesignNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesignNote.Caption = "Type";
            this.colDesignNote.FieldName = "Note";
            this.colDesignNote.Name = "colDesignNote";
            // 
            // pnlDesignControl
            // 
            this.pnlDesignControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDesignControl.Controls.Add(this.chkDesignPLCEditable);
            this.pnlDesignControl.Controls.Add(this.panelControl17);
            this.pnlDesignControl.Controls.Add(this.btnAllTagView);
            this.pnlDesignControl.Controls.Add(this.btnAddSymbol);
            this.pnlDesignControl.Controls.Add(this.btnSymbolDelete);
            this.pnlDesignControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDesignControl.Location = new System.Drawing.Point(0, 0);
            this.pnlDesignControl.Name = "pnlDesignControl";
            this.pnlDesignControl.Size = new System.Drawing.Size(722, 40);
            this.pnlDesignControl.TabIndex = 1;
            // 
            // chkDesignPLCEditable
            // 
            this.chkDesignPLCEditable.AutoSize = true;
            this.chkDesignPLCEditable.BackColor = System.Drawing.Color.White;
            this.chkDesignPLCEditable.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDesignPLCEditable.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkDesignPLCEditable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDesignPLCEditable.Location = new System.Drawing.Point(161, 0);
            this.chkDesignPLCEditable.Name = "chkDesignPLCEditable";
            this.chkDesignPLCEditable.Size = new System.Drawing.Size(99, 40);
            this.chkDesignPLCEditable.TabIndex = 1;
            this.chkDesignPLCEditable.Text = "PLC 수정 가능";
            this.chkDesignPLCEditable.UseVisualStyleBackColor = false;
            this.chkDesignPLCEditable.CheckedChanged += new System.EventHandler(this.chkDesignPLCEditable_CheckedChanged);
            // 
            // panelControl17
            // 
            this.panelControl17.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl17.Location = new System.Drawing.Point(150, 0);
            this.panelControl17.Name = "panelControl17";
            this.panelControl17.Size = new System.Drawing.Size(11, 40);
            this.panelControl17.TabIndex = 13;
            // 
            // btnAllTagView
            // 
            this.btnAllTagView.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAllTagView.Appearance.Options.UseBackColor = true;
            this.btnAllTagView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAllTagView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAllTagView.Image = ((System.Drawing.Image)(resources.GetObject("btnAllTagView.Image")));
            this.btnAllTagView.Location = new System.Drawing.Point(0, 0);
            this.btnAllTagView.Name = "btnAllTagView";
            this.btnAllTagView.Size = new System.Drawing.Size(150, 40);
            this.btnAllTagView.TabIndex = 12;
            this.btnAllTagView.Text = "모든 태그 보기";
            this.btnAllTagView.Click += new System.EventHandler(this.btnAllTagView_Click);
            // 
            // btnAddSymbol
            // 
            this.btnAddSymbol.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAddSymbol.Appearance.Options.UseBackColor = true;
            this.btnAddSymbol.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAddSymbol.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddSymbol.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSymbol.Image")));
            this.btnAddSymbol.Location = new System.Drawing.Point(508, 0);
            this.btnAddSymbol.Name = "btnAddSymbol";
            this.btnAddSymbol.Size = new System.Drawing.Size(107, 40);
            this.btnAddSymbol.TabIndex = 10;
            this.btnAddSymbol.Text = "심볼 추가";
            this.btnAddSymbol.Click += new System.EventHandler(this.btnAddSymbol_Click);
            // 
            // btnSymbolDelete
            // 
            this.btnSymbolDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnSymbolDelete.Appearance.Options.UseBackColor = true;
            this.btnSymbolDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnSymbolDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSymbolDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnSymbolDelete.Image")));
            this.btnSymbolDelete.Location = new System.Drawing.Point(615, 0);
            this.btnSymbolDelete.Name = "btnSymbolDelete";
            this.btnSymbolDelete.Size = new System.Drawing.Size(107, 40);
            this.btnSymbolDelete.TabIndex = 11;
            this.btnSymbolDelete.Text = "심볼 제거";
            this.btnSymbolDelete.Click += new System.EventHandler(this.btnSymbolDelete_Click);
            // 
            // sptDesign
            // 
            this.sptDesign.Location = new System.Drawing.Point(600, 0);
            this.sptDesign.Name = "sptDesign";
            this.sptDesign.Size = new System.Drawing.Size(5, 583);
            this.sptDesign.TabIndex = 1;
            this.sptDesign.TabStop = false;
            // 
            // pnlDesign1
            // 
            this.pnlDesign1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDesign1.Controls.Add(this.tabIOData);
            this.pnlDesign1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDesign1.Location = new System.Drawing.Point(0, 0);
            this.pnlDesign1.MinimumSize = new System.Drawing.Size(600, 0);
            this.pnlDesign1.Name = "pnlDesign1";
            this.pnlDesign1.Size = new System.Drawing.Size(600, 583);
            this.pnlDesign1.TabIndex = 0;
            // 
            // tabIOData
            // 
            this.tabIOData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIOData.Location = new System.Drawing.Point(0, 0);
            this.tabIOData.Name = "tabIOData";
            this.tabIOData.SelectedTabPage = this.tpIOData;
            this.tabIOData.Size = new System.Drawing.Size(600, 583);
            this.tabIOData.TabIndex = 0;
            this.tabIOData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpIOData,
            this.tpAddressRangeData});
            // 
            // tpIOData
            // 
            this.tpIOData.Controls.Add(this.groupControl1);
            this.tpIOData.Controls.Add(this.panelControl16);
            this.tpIOData.Name = "tpIOData";
            this.tpIOData.Size = new System.Drawing.Size(594, 554);
            this.tpIOData.Text = "IO 모듈 정보";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ucIOModule);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 52);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(594, 502);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Address 영역 별 IO 모듈 정보";
            // 
            // ucIOModule
            // 
            this.ucIOModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIOModule.Location = new System.Drawing.Point(2, 21);
            this.ucIOModule.Name = "ucIOModule";
            this.ucIOModule.Size = new System.Drawing.Size(590, 479);
            this.ucIOModule.TabIndex = 0;
            // 
            // panelControl16
            // 
            this.panelControl16.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl16.Appearance.Options.UseBackColor = true;
            this.panelControl16.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl16.Controls.Add(this.btnModuleInfoSetting);
            this.panelControl16.Controls.Add(this.panelControl19);
            this.panelControl16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl16.Location = new System.Drawing.Point(0, 0);
            this.panelControl16.Name = "panelControl16";
            this.panelControl16.Size = new System.Drawing.Size(594, 52);
            this.panelControl16.TabIndex = 9;
            // 
            // btnModuleInfoSetting
            // 
            this.btnModuleInfoSetting.Appearance.BackColor = System.Drawing.Color.White;
            this.btnModuleInfoSetting.Appearance.Options.UseBackColor = true;
            this.btnModuleInfoSetting.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnModuleInfoSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnModuleInfoSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnModuleInfoSetting.Image")));
            this.btnModuleInfoSetting.Location = new System.Drawing.Point(0, 0);
            this.btnModuleInfoSetting.Name = "btnModuleInfoSetting";
            this.btnModuleInfoSetting.Size = new System.Drawing.Size(86, 52);
            this.btnModuleInfoSetting.TabIndex = 3;
            this.btnModuleInfoSetting.Text = "모듈\r\n설정";
            this.btnModuleInfoSetting.Click += new System.EventHandler(this.btnModuleInfoSetting_Click);
            // 
            // panelControl19
            // 
            this.panelControl19.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl19.Controls.Add(this.chkIOUsed);
            this.panelControl19.Controls.Add(this.chkIOExtend);
            this.panelControl19.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl19.Location = new System.Drawing.Point(453, 0);
            this.panelControl19.Name = "panelControl19";
            this.panelControl19.Size = new System.Drawing.Size(141, 52);
            this.panelControl19.TabIndex = 2;
            // 
            // chkIOUsed
            // 
            this.chkIOUsed.EditValue = true;
            this.chkIOUsed.Location = new System.Drawing.Point(11, 27);
            this.chkIOUsed.MenuManager = this.FrmRibbon;
            this.chkIOUsed.Name = "chkIOUsed";
            this.chkIOUsed.Properties.Caption = "사용된 영역만 보기";
            this.chkIOUsed.Size = new System.Drawing.Size(127, 19);
            this.chkIOUsed.TabIndex = 1;
            this.chkIOUsed.CheckedChanged += new System.EventHandler(this.cboIOUsed_CheckedChanged);
            // 
            // chkIOExtend
            // 
            this.chkIOExtend.EditValue = true;
            this.chkIOExtend.Location = new System.Drawing.Point(11, 6);
            this.chkIOExtend.MenuManager = this.FrmRibbon;
            this.chkIOExtend.Name = "chkIOExtend";
            this.chkIOExtend.Properties.Caption = "최대 영역까지 보기";
            this.chkIOExtend.Size = new System.Drawing.Size(127, 19);
            this.chkIOExtend.TabIndex = 0;
            this.chkIOExtend.CheckedChanged += new System.EventHandler(this.chkIOExtend_CheckedChanged);
            // 
            // tpAddressRangeData
            // 
            this.tpAddressRangeData.Controls.Add(this.grpAddressArea);
            this.tpAddressRangeData.Controls.Add(this.panelControl9);
            this.tpAddressRangeData.Controls.Add(this.panelControl8);
            this.tpAddressRangeData.Name = "tpAddressRangeData";
            this.tpAddressRangeData.Size = new System.Drawing.Size(594, 554);
            this.tpAddressRangeData.Text = "Address 영역 정보";
            // 
            // grpAddressArea
            // 
            this.grpAddressArea.Appearance.BackColor = System.Drawing.Color.White;
            this.grpAddressArea.Appearance.Options.UseBackColor = true;
            this.grpAddressArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAddressArea.Location = new System.Drawing.Point(0, 79);
            this.grpAddressArea.Name = "grpAddressArea";
            this.grpAddressArea.Size = new System.Drawing.Size(594, 475);
            this.grpAddressArea.TabIndex = 7;
            this.grpAddressArea.Text = "타입 별 Address 영역";
            // 
            // panelControl9
            // 
            this.panelControl9.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl9.Appearance.Options.UseBackColor = true;
            this.panelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl9.Controls.Add(this.panelControl15);
            this.panelControl9.Controls.Add(this.panelControl13);
            this.panelControl9.Controls.Add(this.btnRangeDetailView);
            this.panelControl9.Controls.Add(this.panelControl12);
            this.panelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl9.Location = new System.Drawing.Point(0, 27);
            this.panelControl9.Name = "panelControl9";
            this.panelControl9.Size = new System.Drawing.Size(594, 52);
            this.panelControl9.TabIndex = 8;
            // 
            // panelControl15
            // 
            this.panelControl15.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl15.Controls.Add(this.labelControl2);
            this.panelControl15.Controls.Add(this.cboListType);
            this.panelControl15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl15.Location = new System.Drawing.Point(174, 0);
            this.panelControl15.Name = "panelControl15";
            this.panelControl15.Size = new System.Drawing.Size(131, 52);
            this.panelControl15.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "List Type";
            // 
            // cboListType
            // 
            this.cboListType.Location = new System.Drawing.Point(9, 26);
            this.cboListType.MenuManager = this.FrmRibbon;
            this.cboListType.Name = "cboListType";
            this.cboListType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboListType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboListType.Size = new System.Drawing.Size(115, 20);
            this.cboListType.TabIndex = 1;
            this.cboListType.SelectedValueChanged += new System.EventHandler(this.cboListType_SelectedValueChanged);
            // 
            // panelControl13
            // 
            this.panelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl13.Controls.Add(this.labelControl1);
            this.panelControl13.Controls.Add(this.cboPLCList);
            this.panelControl13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl13.Location = new System.Drawing.Point(0, 0);
            this.panelControl13.Name = "panelControl13";
            this.panelControl13.Size = new System.Drawing.Size(174, 52);
            this.panelControl13.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "PLC List";
            // 
            // cboPLCList
            // 
            this.cboPLCList.Location = new System.Drawing.Point(9, 26);
            this.cboPLCList.MenuManager = this.FrmRibbon;
            this.cboPLCList.Name = "cboPLCList";
            this.cboPLCList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPLCList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPLCList.Size = new System.Drawing.Size(159, 20);
            this.cboPLCList.TabIndex = 1;
            this.cboPLCList.SelectedValueChanged += new System.EventHandler(this.cboPLCList_SelectedValueChanged);
            // 
            // btnRangeDetailView
            // 
            this.btnRangeDetailView.Appearance.BackColor = System.Drawing.Color.White;
            this.btnRangeDetailView.Appearance.Options.UseBackColor = true;
            this.btnRangeDetailView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRangeDetailView.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRangeDetailView.Image = ((System.Drawing.Image)(resources.GetObject("btnRangeDetailView.Image")));
            this.btnRangeDetailView.Location = new System.Drawing.Point(367, 0);
            this.btnRangeDetailView.Name = "btnRangeDetailView";
            this.btnRangeDetailView.Size = new System.Drawing.Size(86, 52);
            this.btnRangeDetailView.TabIndex = 3;
            this.btnRangeDetailView.Text = "영역\r\n설정";
            this.btnRangeDetailView.Click += new System.EventHandler(this.btnRangeDetailView_Click);
            // 
            // panelControl12
            // 
            this.panelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl12.Controls.Add(this.chkUsed);
            this.panelControl12.Controls.Add(this.chkExtend);
            this.panelControl12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl12.Location = new System.Drawing.Point(453, 0);
            this.panelControl12.Name = "panelControl12";
            this.panelControl12.Size = new System.Drawing.Size(141, 52);
            this.panelControl12.TabIndex = 2;
            // 
            // chkUsed
            // 
            this.chkUsed.EditValue = true;
            this.chkUsed.Location = new System.Drawing.Point(11, 27);
            this.chkUsed.MenuManager = this.FrmRibbon;
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Properties.Caption = "사용된 영역만 보기";
            this.chkUsed.Size = new System.Drawing.Size(127, 19);
            this.chkUsed.TabIndex = 1;
            this.chkUsed.CheckedChanged += new System.EventHandler(this.chkUsed_CheckedChanged);
            // 
            // chkExtend
            // 
            this.chkExtend.Location = new System.Drawing.Point(11, 6);
            this.chkExtend.MenuManager = this.FrmRibbon;
            this.chkExtend.Name = "chkExtend";
            this.chkExtend.Properties.Caption = "최대 영역까지 보기";
            this.chkExtend.Size = new System.Drawing.Size(127, 19);
            this.chkExtend.TabIndex = 0;
            this.chkExtend.CheckedChanged += new System.EventHandler(this.chkExtend_CheckedChanged);
            // 
            // panelControl8
            // 
            this.panelControl8.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl8.Appearance.Options.UseBackColor = true;
            this.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl8.Controls.Add(this.labelControl4);
            this.panelControl8.Controls.Add(this.labelControl3);
            this.panelControl8.Controls.Add(this.panelControl20);
            this.panelControl8.Controls.Add(this.panelControl18);
            this.panelControl8.Controls.Add(this.labelControl5);
            this.panelControl8.Controls.Add(this.labelControl7);
            this.panelControl8.Controls.Add(this.panelControl11);
            this.panelControl8.Controls.Add(this.panelControl10);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl8.Location = new System.Drawing.Point(0, 0);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(594, 27);
            this.panelControl8.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(459, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(129, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "추가된 영역 모두 사용";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(292, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 14);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "추가된 영역 일부 사용";
            // 
            // panelControl20
            // 
            this.panelControl20.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.panelControl20.Appearance.Options.UseBackColor = true;
            this.panelControl20.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl20.Location = new System.Drawing.Point(426, 4);
            this.panelControl20.Name = "panelControl20";
            this.panelControl20.Size = new System.Drawing.Size(27, 20);
            this.panelControl20.TabIndex = 11;
            // 
            // panelControl18
            // 
            this.panelControl18.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.panelControl18.Appearance.Options.UseBackColor = true;
            this.panelControl18.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl18.Location = new System.Drawing.Point(259, 4);
            this.panelControl18.Name = "panelControl18";
            this.panelControl18.Size = new System.Drawing.Size(27, 20);
            this.panelControl18.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(167, 7);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(86, 14);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "영역 모두 사용";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(40, 7);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(86, 14);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "영역 일부 사용";
            // 
            // panelControl11
            // 
            this.panelControl11.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelControl11.Appearance.Options.UseBackColor = true;
            this.panelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl11.Location = new System.Drawing.Point(132, 4);
            this.panelControl11.Name = "panelControl11";
            this.panelControl11.Size = new System.Drawing.Size(27, 20);
            this.panelControl11.TabIndex = 6;
            // 
            // panelControl10
            // 
            this.panelControl10.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.panelControl10.Appearance.Options.UseBackColor = true;
            this.panelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl10.Location = new System.Drawing.Point(7, 4);
            this.panelControl10.Name = "panelControl10";
            this.panelControl10.Size = new System.Drawing.Size(27, 20);
            this.panelControl10.TabIndex = 7;
            // 
            // tpDesignStandardization
            // 
            this.tpDesignStandardization.Controls.Add(this.grdStd);
            this.tpDesignStandardization.Controls.Add(this.panelControl1);
            this.tpDesignStandardization.Controls.Add(this.splitterControl2);
            this.tpDesignStandardization.Controls.Add(this.grpStdL);
            this.tpDesignStandardization.Name = "tpDesignStandardization";
            this.tpDesignStandardization.Size = new System.Drawing.Size(1327, 583);
            this.tpDesignStandardization.Text = "PLC 심볼 표준화";
            // 
            // grdStd
            // 
            this.grdStd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStd.Location = new System.Drawing.Point(0, 43);
            this.grdStd.MainView = this.grvStd;
            this.grdStd.MenuManager = this.FrmRibbon;
            this.grdStd.Name = "grdStd";
            this.grdStd.Size = new System.Drawing.Size(982, 540);
            this.grdStd.TabIndex = 5;
            this.grdStd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStd});
            // 
            // grvStd
            // 
            this.grvStd.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.grvStd.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvStd.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvStd.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvStd.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrentDesc,
            this.colTargetDesc,
            this.colStandardCheck,
            this.colStandardAddress,
            this.colLv1,
            this.colLv2,
            this.colLv3,
            this.colLv4,
            this.colLv5,
            this.colLv6,
            this.colLv7,
            this.colLv8,
            this.colLv9,
            this.colLv10});
            this.grvStd.GridControl = this.grdStd;
            this.grvStd.IndicatorWidth = 40;
            this.grvStd.Name = "grvStd";
            this.grvStd.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvStd.OptionsDetail.AllowZoomDetail = false;
            this.grvStd.OptionsDetail.EnableMasterViewMode = false;
            this.grvStd.OptionsDetail.SmartDetailExpand = false;
            this.grvStd.OptionsFind.AlwaysVisible = true;
            this.grvStd.OptionsSelection.MultiSelect = true;
            this.grvStd.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvStd.OptionsView.ShowAutoFilterRow = true;
            this.grvStd.OptionsView.ShowGroupPanel = false;
            this.grvStd.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStd_CustomDrawRowIndicator);
            this.grvStd.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvStd_RowCellStyle);
            this.grvStd.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvStd_CellValueChanged);
            this.grvStd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvStd_MouseUp);
            // 
            // colCurrentDesc
            // 
            this.colCurrentDesc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colCurrentDesc.AppearanceHeader.Options.UseFont = true;
            this.colCurrentDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrentDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrentDesc.Caption = "Symbol Name";
            this.colCurrentDesc.FieldName = "CurrentDesc";
            this.colCurrentDesc.Name = "colCurrentDesc";
            this.colCurrentDesc.OptionsColumn.AllowEdit = false;
            this.colCurrentDesc.OptionsColumn.ReadOnly = true;
            this.colCurrentDesc.Visible = true;
            this.colCurrentDesc.VisibleIndex = 0;
            this.colCurrentDesc.Width = 255;
            // 
            // colTargetDesc
            // 
            this.colTargetDesc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colTargetDesc.AppearanceHeader.Options.UseFont = true;
            this.colTargetDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colTargetDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTargetDesc.Caption = "Convert Name";
            this.colTargetDesc.FieldName = "TargetDesc";
            this.colTargetDesc.Name = "colTargetDesc";
            this.colTargetDesc.OptionsColumn.AllowEdit = false;
            this.colTargetDesc.OptionsColumn.ReadOnly = true;
            this.colTargetDesc.Visible = true;
            this.colTargetDesc.VisibleIndex = 1;
            this.colTargetDesc.Width = 258;
            // 
            // colStandardCheck
            // 
            this.colStandardCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colStandardCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colStandardCheck.AppearanceHeader.Options.UseFont = true;
            this.colStandardCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colStandardCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardCheck.Caption = "표준화 확인";
            this.colStandardCheck.FieldName = "IsStandard";
            this.colStandardCheck.Name = "colStandardCheck";
            this.colStandardCheck.OptionsColumn.AllowEdit = false;
            this.colStandardCheck.OptionsColumn.FixedWidth = true;
            this.colStandardCheck.OptionsColumn.ReadOnly = true;
            this.colStandardCheck.Visible = true;
            this.colStandardCheck.VisibleIndex = 3;
            this.colStandardCheck.Width = 80;
            // 
            // colStandardAddress
            // 
            this.colStandardAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colStandardAddress.AppearanceHeader.Options.UseFont = true;
            this.colStandardAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colStandardAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardAddress.Caption = "Address";
            this.colStandardAddress.FieldName = "Address";
            this.colStandardAddress.Name = "colStandardAddress";
            this.colStandardAddress.OptionsColumn.AllowEdit = false;
            this.colStandardAddress.OptionsColumn.ReadOnly = true;
            this.colStandardAddress.Visible = true;
            this.colStandardAddress.VisibleIndex = 2;
            this.colStandardAddress.Width = 158;
            // 
            // colLv1
            // 
            this.colLv1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv1.AppearanceHeader.Options.UseFont = true;
            this.colLv1.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv1.Caption = "Level1";
            this.colLv1.FieldName = "Lv1Name";
            this.colLv1.MaxWidth = 100;
            this.colLv1.MinWidth = 90;
            this.colLv1.Name = "colLv1";
            this.colLv1.OptionsColumn.FixedWidth = true;
            this.colLv1.Visible = true;
            this.colLv1.VisibleIndex = 4;
            this.colLv1.Width = 90;
            // 
            // colLv2
            // 
            this.colLv2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv2.AppearanceHeader.Options.UseFont = true;
            this.colLv2.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv2.Caption = "Level2";
            this.colLv2.FieldName = "Lv2Name";
            this.colLv2.MaxWidth = 100;
            this.colLv2.MinWidth = 90;
            this.colLv2.Name = "colLv2";
            this.colLv2.OptionsColumn.FixedWidth = true;
            this.colLv2.Visible = true;
            this.colLv2.VisibleIndex = 5;
            this.colLv2.Width = 90;
            // 
            // colLv3
            // 
            this.colLv3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv3.AppearanceHeader.Options.UseFont = true;
            this.colLv3.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv3.Caption = "Level3";
            this.colLv3.FieldName = "Lv3Name";
            this.colLv3.MaxWidth = 100;
            this.colLv3.MinWidth = 90;
            this.colLv3.Name = "colLv3";
            this.colLv3.OptionsColumn.FixedWidth = true;
            this.colLv3.Visible = true;
            this.colLv3.VisibleIndex = 6;
            this.colLv3.Width = 90;
            // 
            // colLv4
            // 
            this.colLv4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv4.AppearanceHeader.Options.UseFont = true;
            this.colLv4.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv4.Caption = "Level4";
            this.colLv4.FieldName = "Lv4Name";
            this.colLv4.MaxWidth = 100;
            this.colLv4.MinWidth = 90;
            this.colLv4.Name = "colLv4";
            this.colLv4.OptionsColumn.FixedWidth = true;
            this.colLv4.Visible = true;
            this.colLv4.VisibleIndex = 7;
            this.colLv4.Width = 90;
            // 
            // colLv5
            // 
            this.colLv5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv5.AppearanceHeader.Options.UseFont = true;
            this.colLv5.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv5.Caption = "Level5";
            this.colLv5.FieldName = "Lv5Name";
            this.colLv5.MaxWidth = 100;
            this.colLv5.MinWidth = 90;
            this.colLv5.Name = "colLv5";
            this.colLv5.OptionsColumn.FixedWidth = true;
            this.colLv5.Visible = true;
            this.colLv5.VisibleIndex = 8;
            this.colLv5.Width = 90;
            // 
            // colLv6
            // 
            this.colLv6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv6.AppearanceHeader.Options.UseFont = true;
            this.colLv6.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv6.Caption = "Level6";
            this.colLv6.FieldName = "Lv6Name";
            this.colLv6.MaxWidth = 100;
            this.colLv6.MinWidth = 90;
            this.colLv6.Name = "colLv6";
            this.colLv6.OptionsColumn.FixedWidth = true;
            this.colLv6.Visible = true;
            this.colLv6.VisibleIndex = 9;
            this.colLv6.Width = 90;
            // 
            // colLv7
            // 
            this.colLv7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv7.AppearanceHeader.Options.UseFont = true;
            this.colLv7.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv7.Caption = "Level7";
            this.colLv7.FieldName = "Lv7Name";
            this.colLv7.MaxWidth = 100;
            this.colLv7.MinWidth = 90;
            this.colLv7.Name = "colLv7";
            this.colLv7.OptionsColumn.FixedWidth = true;
            this.colLv7.Width = 90;
            // 
            // colLv8
            // 
            this.colLv8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv8.AppearanceHeader.Options.UseFont = true;
            this.colLv8.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv8.Caption = "Level8";
            this.colLv8.FieldName = "Lv8Name";
            this.colLv8.MaxWidth = 100;
            this.colLv8.MinWidth = 90;
            this.colLv8.Name = "colLv8";
            this.colLv8.OptionsColumn.FixedWidth = true;
            this.colLv8.Width = 90;
            // 
            // colLv9
            // 
            this.colLv9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv9.AppearanceHeader.Options.UseFont = true;
            this.colLv9.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv9.Caption = "Level9";
            this.colLv9.FieldName = "Lv9Name";
            this.colLv9.MaxWidth = 100;
            this.colLv9.MinWidth = 90;
            this.colLv9.Name = "colLv9";
            this.colLv9.OptionsColumn.FixedWidth = true;
            this.colLv9.Width = 90;
            // 
            // colLv10
            // 
            this.colLv10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colLv10.AppearanceHeader.Options.UseFont = true;
            this.colLv10.AppearanceHeader.Options.UseTextOptions = true;
            this.colLv10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLv10.Caption = "Level10";
            this.colLv10.FieldName = "Lv10Name";
            this.colLv10.MaxWidth = 100;
            this.colLv10.MinWidth = 90;
            this.colLv10.Name = "colLv10";
            this.colLv10.OptionsColumn.FixedWidth = true;
            this.colLv10.Width = 90;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnStandardApply);
            this.panelControl1.Controls.Add(this.btnStandardization);
            this.panelControl1.Controls.Add(this.lblFilter);
            this.panelControl1.Controls.Add(this.panelControl6);
            this.panelControl1.Controls.Add(this.panelControl14);
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Controls.Add(this.chkStandardization);
            this.panelControl1.Controls.Add(this.chkStdLNotExist);
            this.panelControl1.Controls.Add(this.chkStdLExist);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(982, 43);
            this.panelControl1.TabIndex = 4;
            // 
            // btnStandardApply
            // 
            this.btnStandardApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnStandardApply.Appearance.Options.UseBackColor = true;
            this.btnStandardApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnStandardApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStandardApply.Image = ((System.Drawing.Image)(resources.GetObject("btnStandardApply.Image")));
            this.btnStandardApply.Location = new System.Drawing.Point(114, 0);
            this.btnStandardApply.Name = "btnStandardApply";
            this.btnStandardApply.Size = new System.Drawing.Size(114, 43);
            this.btnStandardApply.TabIndex = 13;
            this.btnStandardApply.Text = "표준화 적용";
            this.btnStandardApply.Click += new System.EventHandler(this.btnStandardApply_Click);
            // 
            // btnStandardization
            // 
            this.btnStandardization.Appearance.BackColor = System.Drawing.Color.White;
            this.btnStandardization.Appearance.Options.UseBackColor = true;
            this.btnStandardization.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnStandardization.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStandardization.Image = ((System.Drawing.Image)(resources.GetObject("btnStandardization.Image")));
            this.btnStandardization.Location = new System.Drawing.Point(0, 0);
            this.btnStandardization.Name = "btnStandardization";
            this.btnStandardization.Size = new System.Drawing.Size(114, 43);
            this.btnStandardization.TabIndex = 12;
            this.btnStandardization.Text = "표준화 진행";
            this.btnStandardization.Click += new System.EventHandler(this.btnStandardization_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFilter.Location = new System.Drawing.Point(479, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(45, 43);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.Text = " Filter : ";
            this.lblFilter.UseMnemonic = false;
            // 
            // panelControl6
            // 
            this.panelControl6.Appearance.BackColor = System.Drawing.Color.Orange;
            this.panelControl6.Appearance.Options.UseBackColor = true;
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Location = new System.Drawing.Point(822, 11);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(27, 20);
            this.panelControl6.TabIndex = 6;
            // 
            // panelControl14
            // 
            this.panelControl14.Appearance.BackColor = System.Drawing.Color.PaleGreen;
            this.panelControl14.Appearance.Options.UseBackColor = true;
            this.panelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl14.Location = new System.Drawing.Point(532, 11);
            this.panelControl14.Name = "panelControl14";
            this.panelControl14.Size = new System.Drawing.Size(27, 20);
            this.panelControl14.TabIndex = 2;
            // 
            // panelControl5
            // 
            this.panelControl5.Appearance.BackColor = System.Drawing.Color.Salmon;
            this.panelControl5.Appearance.Options.UseBackColor = true;
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Location = new System.Drawing.Point(656, 11);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(27, 20);
            this.panelControl5.TabIndex = 4;
            // 
            // chkStandardization
            // 
            this.chkStandardization.Appearance.BackColor = System.Drawing.Color.White;
            this.chkStandardization.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkStandardization.Appearance.Options.UseBackColor = true;
            this.chkStandardization.Appearance.Options.UseFont = true;
            this.chkStandardization.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkStandardization.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkStandardization.Location = new System.Drawing.Point(524, 0);
            this.chkStandardization.Name = "chkStandardization";
            this.chkStandardization.Size = new System.Drawing.Size(126, 43);
            this.chkStandardization.TabIndex = 10;
            this.chkStandardization.Text = "         표준화 진행";
            this.chkStandardization.CheckedChanged += new System.EventHandler(this.chkStandardization_CheckedChanged);
            // 
            // chkStdLNotExist
            // 
            this.chkStdLNotExist.Appearance.BackColor = System.Drawing.Color.White;
            this.chkStdLNotExist.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkStdLNotExist.Appearance.Options.UseBackColor = true;
            this.chkStdLNotExist.Appearance.Options.UseFont = true;
            this.chkStdLNotExist.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkStdLNotExist.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkStdLNotExist.Location = new System.Drawing.Point(650, 0);
            this.chkStdLNotExist.Name = "chkStdLNotExist";
            this.chkStdLNotExist.Size = new System.Drawing.Size(166, 43);
            this.chkStdLNotExist.TabIndex = 8;
            this.chkStdLNotExist.Text = "        라이브러리 존재 X";
            this.chkStdLNotExist.CheckedChanged += new System.EventHandler(this.chkStdLNotExist_CheckedChanged);
            // 
            // chkStdLExist
            // 
            this.chkStdLExist.Appearance.BackColor = System.Drawing.Color.White;
            this.chkStdLExist.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkStdLExist.Appearance.Options.UseBackColor = true;
            this.chkStdLExist.Appearance.Options.UseFont = true;
            this.chkStdLExist.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chkStdLExist.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkStdLExist.Location = new System.Drawing.Point(816, 0);
            this.chkStdLExist.Name = "chkStdLExist";
            this.chkStdLExist.Size = new System.Drawing.Size(166, 43);
            this.chkStdLExist.TabIndex = 9;
            this.chkStdLExist.Text = "        라이브러리 존재 O";
            this.chkStdLExist.CheckedChanged += new System.EventHandler(this.chkStdLExist_CheckedChanged);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl2.Location = new System.Drawing.Point(982, 0);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 583);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // grpStdL
            // 
            this.grpStdL.Controls.Add(this.grdStdL);
            this.grpStdL.Controls.Add(this.panelControl7);
            this.grpStdL.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpStdL.Location = new System.Drawing.Point(987, 0);
            this.grpStdL.MinimumSize = new System.Drawing.Size(340, 0);
            this.grpStdL.Name = "grpStdL";
            this.grpStdL.Size = new System.Drawing.Size(340, 583);
            this.grpStdL.TabIndex = 3;
            this.grpStdL.Text = "심볼 표준화 라이브러리";
            // 
            // grdStdL
            // 
            this.grdStdL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStdL.Location = new System.Drawing.Point(2, 61);
            this.grdStdL.MainView = this.grvStdL;
            this.grdStdL.Name = "grdStdL";
            this.grdStdL.Size = new System.Drawing.Size(336, 520);
            this.grdStdL.TabIndex = 2;
            this.grdStdL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStdL});
            // 
            // grvStdL
            // 
            this.grvStdL.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOldName,
            this.colStandardName,
            this.colStdDescription});
            this.grvStdL.GridControl = this.grdStdL;
            this.grvStdL.IndicatorWidth = 40;
            this.grvStdL.Name = "grvStdL";
            this.grvStdL.OptionsDetail.AllowZoomDetail = false;
            this.grvStdL.OptionsDetail.EnableMasterViewMode = false;
            this.grvStdL.OptionsDetail.SmartDetailExpand = false;
            this.grvStdL.OptionsView.AllowCellMerge = true;
            this.grvStdL.OptionsView.ShowAutoFilterRow = true;
            this.grvStdL.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colStandardName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvStdL.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStdL_CustomDrawRowIndicator);
            // 
            // colOldName
            // 
            this.colOldName.AppearanceCell.Options.UseTextOptions = true;
            this.colOldName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOldName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOldName.AppearanceHeader.Options.UseFont = true;
            this.colOldName.AppearanceHeader.Options.UseTextOptions = true;
            this.colOldName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOldName.Caption = "기존 이름";
            this.colOldName.FieldName = "CurrentName";
            this.colOldName.Name = "colOldName";
            this.colOldName.Visible = true;
            this.colOldName.VisibleIndex = 0;
            // 
            // colStandardName
            // 
            this.colStandardName.AppearanceCell.Options.UseTextOptions = true;
            this.colStandardName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStandardName.AppearanceHeader.Options.UseFont = true;
            this.colStandardName.AppearanceHeader.Options.UseTextOptions = true;
            this.colStandardName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStandardName.Caption = "표준 이름";
            this.colStandardName.FieldName = "TargetName";
            this.colStandardName.Name = "colStandardName";
            this.colStandardName.Visible = true;
            this.colStandardName.VisibleIndex = 1;
            // 
            // colStdDescription
            // 
            this.colStdDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colStdDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStdDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStdDescription.AppearanceHeader.Options.UseFont = true;
            this.colStdDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colStdDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStdDescription.Caption = "설명";
            this.colStdDescription.FieldName = "Description";
            this.colStdDescription.Name = "colStdDescription";
            this.colStdDescription.Visible = true;
            this.colStdDescription.VisibleIndex = 2;
            // 
            // panelControl7
            // 
            this.panelControl7.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl7.Appearance.Options.UseBackColor = true;
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Controls.Add(this.btnHideStdL);
            this.panelControl7.Controls.Add(this.btnDelete);
            this.panelControl7.Controls.Add(this.btnLibraryAdd);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(2, 21);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(336, 40);
            this.panelControl7.TabIndex = 3;
            // 
            // btnHideStdL
            // 
            this.btnHideStdL.Appearance.BackColor = System.Drawing.Color.White;
            this.btnHideStdL.Appearance.Options.UseBackColor = true;
            this.btnHideStdL.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnHideStdL.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHideStdL.Image = ((System.Drawing.Image)(resources.GetObject("btnHideStdL.Image")));
            this.btnHideStdL.Location = new System.Drawing.Point(266, 0);
            this.btnHideStdL.Name = "btnHideStdL";
            this.btnHideStdL.Size = new System.Drawing.Size(70, 40);
            this.btnHideStdL.TabIndex = 20;
            this.btnHideStdL.Text = "숨김";
            this.btnHideStdL.Click += new System.EventHandler(this.btnHideStdL_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(70, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "제거";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLibraryAdd
            // 
            this.btnLibraryAdd.Appearance.BackColor = System.Drawing.Color.White;
            this.btnLibraryAdd.Appearance.Options.UseBackColor = true;
            this.btnLibraryAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLibraryAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLibraryAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryAdd.Image")));
            this.btnLibraryAdd.Location = new System.Drawing.Point(0, 0);
            this.btnLibraryAdd.Name = "btnLibraryAdd";
            this.btnLibraryAdd.Size = new System.Drawing.Size(70, 40);
            this.btnLibraryAdd.TabIndex = 18;
            this.btnLibraryAdd.Text = "추가";
            this.btnLibraryAdd.Click += new System.EventHandler(this.btnLibraryAdd_Click);
            // 
            // exbarManager
            // 
            this.exbarManager.DockControls.Add(this.barDockControl1);
            this.exbarManager.DockControls.Add(this.barDockControl2);
            this.exbarManager.DockControls.Add(this.barDockControl3);
            this.exbarManager.DockControls.Add(this.barDockControl4);
            this.exbarManager.Form = this;
            this.exbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnConnectHMI,
            this.btnConnectDataType,
            this.btnInputHMIBit,
            this.btnMappingCancel,
            this.btnAllMappingCancel,
            this.btnVerifMappingCancel,
            this.btnGroupAutoMapping,
            this.btnCheckConnectPLC,
            this.btnConnectHMITag,
            this.btnRecommend,
            this.btnAllLevelClear,
            this.btnAddLibrary,
            this.btnLevelLeftMove,
            this.btnLevelRightMove,
            this.btnReplace});
            this.exbarManager.MaxItemId = 16;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1339, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 819);
            this.barDockControl2.Size = new System.Drawing.Size(1339, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 819);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1339, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 819);
            // 
            // btnConnectHMI
            // 
            this.btnConnectHMI.Caption = "연결하기 ( F5 )";
            this.btnConnectHMI.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConnectHMI.Glyph")));
            this.btnConnectHMI.Id = 1;
            this.btnConnectHMI.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConnectHMI.LargeGlyph")));
            this.btnConnectHMI.Name = "btnConnectHMI";
            this.btnConnectHMI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectHMI_ItemClick);
            // 
            // btnConnectDataType
            // 
            this.btnConnectDataType.Caption = "다른 Data Type 연결하기 ( F6 )";
            this.btnConnectDataType.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConnectDataType.Glyph")));
            this.btnConnectDataType.Id = 2;
            this.btnConnectDataType.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConnectDataType.LargeGlyph")));
            this.btnConnectDataType.Name = "btnConnectDataType";
            this.btnConnectDataType.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnConnectDataType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectDataType_ItemClick);
            // 
            // btnInputHMIBit
            // 
            this.btnInputHMIBit.Caption = "연속된 PLC 주소 넣기 ( F8 )";
            this.btnInputHMIBit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnInputHMIBit.Glyph")));
            this.btnInputHMIBit.Id = 3;
            this.btnInputHMIBit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInputHMIBit.LargeGlyph")));
            this.btnInputHMIBit.Name = "btnInputHMIBit";
            this.btnInputHMIBit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInputHMIBit_ItemClick);
            // 
            // btnMappingCancel
            // 
            this.btnMappingCancel.Caption = "연결해제 ( F6 )";
            this.btnMappingCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnMappingCancel.Glyph")));
            this.btnMappingCancel.Id = 4;
            this.btnMappingCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnMappingCancel.LargeGlyph")));
            this.btnMappingCancel.Name = "btnMappingCancel";
            this.btnMappingCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMappingCancel_ItemClick);
            // 
            // btnAllMappingCancel
            // 
            this.btnAllMappingCancel.Caption = "중복된 HMI 모두 연결해제 ( F7 )";
            this.btnAllMappingCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllMappingCancel.Glyph")));
            this.btnAllMappingCancel.Id = 5;
            this.btnAllMappingCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAllMappingCancel.LargeGlyph")));
            this.btnAllMappingCancel.Name = "btnAllMappingCancel";
            this.btnAllMappingCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllMappingCancel_ItemClick);
            // 
            // btnVerifMappingCancel
            // 
            this.btnVerifMappingCancel.Caption = "연결 해제";
            this.btnVerifMappingCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnVerifMappingCancel.Glyph")));
            this.btnVerifMappingCancel.Id = 6;
            this.btnVerifMappingCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnVerifMappingCancel.LargeGlyph")));
            this.btnVerifMappingCancel.Name = "btnVerifMappingCancel";
            this.btnVerifMappingCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerifMappingCancel_ItemClick);
            // 
            // btnGroupAutoMapping
            // 
            this.btnGroupAutoMapping.Caption = "해당 그룹 자동 매핑 진행 ( F9 )";
            this.btnGroupAutoMapping.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGroupAutoMapping.Glyph")));
            this.btnGroupAutoMapping.Id = 7;
            this.btnGroupAutoMapping.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGroupAutoMapping.LargeGlyph")));
            this.btnGroupAutoMapping.Name = "btnGroupAutoMapping";
            this.btnGroupAutoMapping.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupAutoMapping_ItemClick);
            // 
            // btnCheckConnectPLC
            // 
            this.btnCheckConnectPLC.Caption = "연결된 PLC 확인 ( F10 )";
            this.btnCheckConnectPLC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCheckConnectPLC.Glyph")));
            this.btnCheckConnectPLC.Id = 8;
            this.btnCheckConnectPLC.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCheckConnectPLC.LargeGlyph")));
            this.btnCheckConnectPLC.Name = "btnCheckConnectPLC";
            this.btnCheckConnectPLC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheckConnectPLC_ItemClick);
            // 
            // btnConnectHMITag
            // 
            this.btnConnectHMITag.Caption = "연결된 HMI Tag 보기 ( F11 )";
            this.btnConnectHMITag.Glyph = ((System.Drawing.Image)(resources.GetObject("btnConnectHMITag.Glyph")));
            this.btnConnectHMITag.Id = 9;
            this.btnConnectHMITag.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnConnectHMITag.LargeGlyph")));
            this.btnConnectHMITag.Name = "btnConnectHMITag";
            this.btnConnectHMITag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectHMITag_ItemClick);
            // 
            // btnRecommend
            // 
            this.btnRecommend.Caption = "매핑 PLC 태그 추천 ( F12 )";
            this.btnRecommend.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRecommend.Glyph")));
            this.btnRecommend.Id = 10;
            this.btnRecommend.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRecommend.LargeGlyph")));
            this.btnRecommend.Name = "btnRecommend";
            this.btnRecommend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecommend_ItemClick);
            // 
            // btnAllLevelClear
            // 
            this.btnAllLevelClear.Caption = "모든 레벨 Clear";
            this.btnAllLevelClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAllLevelClear.Glyph")));
            this.btnAllLevelClear.Id = 11;
            this.btnAllLevelClear.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAllLevelClear.LargeGlyph")));
            this.btnAllLevelClear.Name = "btnAllLevelClear";
            this.btnAllLevelClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAllLevelClear_ItemClick);
            // 
            // btnAddLibrary
            // 
            this.btnAddLibrary.Caption = "라이브러리 추가";
            this.btnAddLibrary.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddLibrary.Glyph")));
            this.btnAddLibrary.Id = 12;
            this.btnAddLibrary.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAddLibrary.LargeGlyph")));
            this.btnAddLibrary.Name = "btnAddLibrary";
            this.btnAddLibrary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddLibrary_ItemClick);
            // 
            // btnLevelLeftMove
            // 
            this.btnLevelLeftMove.Caption = "레벨 왼쪽으로 이동";
            this.btnLevelLeftMove.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLevelLeftMove.Glyph")));
            this.btnLevelLeftMove.Id = 13;
            this.btnLevelLeftMove.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLevelLeftMove.LargeGlyph")));
            this.btnLevelLeftMove.Name = "btnLevelLeftMove";
            this.btnLevelLeftMove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevelLeftMove_ItemClick);
            // 
            // btnLevelRightMove
            // 
            this.btnLevelRightMove.Caption = "레벨 오른쪽으로 이동";
            this.btnLevelRightMove.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLevelRightMove.Glyph")));
            this.btnLevelRightMove.Id = 14;
            this.btnLevelRightMove.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLevelRightMove.LargeGlyph")));
            this.btnLevelRightMove.Name = "btnLevelRightMove";
            this.btnLevelRightMove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevelRightMove_ItemClick);
            // 
            // btnReplace
            // 
            this.btnReplace.Caption = "선택 영역 문자열 변경";
            this.btnReplace.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReplace.Glyph")));
            this.btnReplace.Id = 15;
            this.btnReplace.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReplace.LargeGlyph")));
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReplace_ItemClick);
            // 
            // mnuMappingHMI
            // 
            this.mnuMappingHMI.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnectHMI),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMappingCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAllMappingCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnectDataType),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInputHMIBit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGroupAutoMapping),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCheckConnectPLC),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRecommend)});
            this.mnuMappingHMI.Manager = this.exbarManager;
            this.mnuMappingHMI.Name = "mnuMappingHMI";
            // 
            // mnuVerifHMI
            // 
            this.mnuVerifHMI.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnVerifMappingCancel)});
            this.mnuVerifHMI.Manager = this.exbarManager;
            this.mnuVerifHMI.Name = "mnuVerifHMI";
            // 
            // mnuMappingPLC
            // 
            this.mnuMappingPLC.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnectHMITag)});
            this.mnuMappingPLC.Manager = this.exbarManager;
            this.mnuMappingPLC.Name = "mnuMappingPLC";
            // 
            // mnuStandard
            // 
            this.mnuStandard.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAllLevelClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddLibrary),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReplace)});
            this.mnuStandard.Manager = this.exbarManager;
            this.mnuStandard.Name = "mnuStandard";
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 819);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.mnuStatusbar);
            this.Controls.Add(this.FrmRibbon);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Ribbon = this.FrmRibbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.mnuStatusbar;
            this.Text = "UDM IO Maker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.FrmRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorSectionExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorColorConvert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorVerfiOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorHMIVerifOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuExportPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPLCEdit)).EndInit();
            this.pnlPLCEdit.ResumeLayout(false);
            this.pnlPLCEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPLCRowCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHMIEdit)).EndInit();
            this.pnlHMIEdit.ResumeLayout(false);
            this.pnlHMIEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHMIRowCount.Properties)).EndInit();
            this.tpPLCVerification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptVerification)).EndInit();
            this.sptVerification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPLCVerif)).EndInit();
            this.tabPLCVerif.ResumeLayout(false);
            this.tpIOTree.ResumeLayout(false);
            this.tpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerifPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerifPLC)).EndInit();
            this.tpLadderView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlView)).EndInit();
            this.pnlView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLadderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLadderViewBtn)).EndInit();
            this.pnlLadderViewBtn.ResumeLayout(false);
            this.tpTagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPLCVerif2)).EndInit();
            this.tabPLCVerif2.ResumeLayout(false);
            this.tpReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl22)).EndInit();
            this.panelControl22.ResumeLayout(false);
            this.tpReportElement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl21)).EndInit();
            this.panelControl21.ResumeLayout(false);
            this.tpHMIVerification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptHMIVerification)).EndInit();
            this.sptHMIVerification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerifHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerifHMI)).EndInit();
            this.grpFilterOption.ResumeLayout(false);
            this.tpHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabHelp)).EndInit();
            this.tabHelp.ResumeLayout(false);
            this.tpManual.ResumeLayout(false);
            this.tpIOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIOList)).EndInit();
            this.pnlIOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl23)).EndInit();
            this.panelControl23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl24)).EndInit();
            this.panelControl24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePathOpen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcelEdit.Properties)).EndInit();
            this.tpDesign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabDesign)).EndInit();
            this.tabDesign.ResumeLayout(false);
            this.tpDesignDesign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesign2)).EndInit();
            this.pnlDesign2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDesignPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDesignPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesignControl)).EndInit();
            this.pnlDesignControl.ResumeLayout(false);
            this.pnlDesignControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDesign1)).EndInit();
            this.pnlDesign1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabIOData)).EndInit();
            this.tabIOData.ResumeLayout(false);
            this.tpIOData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl16)).EndInit();
            this.panelControl16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl19)).EndInit();
            this.panelControl19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIOUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIOExtend.Properties)).EndInit();
            this.tpAddressRangeData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpAddressArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl9)).EndInit();
            this.panelControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl15)).EndInit();
            this.panelControl15.ResumeLayout(false);
            this.panelControl15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboListType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl13)).EndInit();
            this.panelControl13.ResumeLayout(false);
            this.panelControl13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLCList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl12)).EndInit();
            this.panelControl12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExtend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            this.panelControl8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl10)).EndInit();
            this.tpDesignStandardization.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStdL)).EndInit();
            this.grpStdL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStdL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStdL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMappingHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuVerifHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMappingPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuStandard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl FrmRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHMIMapping;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuFile;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar mnuStatusbar;
        private DevExpress.XtraBars.BarButtonItem MouseStatus;
        private DevExpress.XtraBars.BarStaticItem LabelWorkTime;
        private DevExpress.XtraBars.BarStaticItem barMainStatus;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgPLCVerification;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHelper;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem btnOpenPLC;
        private DevExpress.XtraBars.BarButtonItem btnOpenHMI;
        private DevExpress.XtraBars.BarButtonItem btnExportHMI;
        private DevExpress.XtraBars.BarEditItem cboMappingColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColorMatch;
        private DevExpress.XtraBars.BarStaticItem lblConvert;
        private DevExpress.XtraBars.BarStaticItem lblMatch;
        private DevExpress.XtraBars.BarStaticItem lblInsert;
        private DevExpress.XtraBars.BarEditItem cboInsert;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColorInsert;
        private DevExpress.XtraBars.BarEditItem cboConvert;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exEditorColorConvert;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPLC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHMI;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMappingOption;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPLCVerification;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuUserDefine;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuManual;
        private DevExpress.XtraBars.PopupMenu mnuExportHMI;
        private DevExpress.XtraBars.BarButtonItem btnAllHMI;
        private DevExpress.XtraBars.BarEditItem cboSectionExport;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorSectionExport;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem barItemSkin;
        private DevExpress.XtraBars.PopupMenu mnuExportPLC;
        private DevExpress.XtraBars.BarButtonItem btnExportIO;
        private DevExpress.XtraBars.BarButtonItem btnExportDummy;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpMapping;
        private DevExpress.XtraTab.XtraTabPage tpPLCVerification;
        private DevExpress.XtraTab.XtraTabPage tpHelp;
        private DevExpress.XtraEditors.SplitContainerControl sptMain;
        private DevExpress.XtraGrid.GridControl grdPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPLC;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraEditors.PanelControl pnlPLCEdit;
        private System.Windows.Forms.CheckBox chkPLCEditable;
        private DevExpress.XtraEditors.PanelControl pnlHMIEdit;
        private System.Windows.Forms.CheckBox chkHMIEditable;
        private DevExpress.XtraGrid.GridControl grdHMI;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHMI;
        private DevExpress.XtraGrid.Columns.GridColumn colMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraTab.XtraTabPage tpIOList;
        private DevExpress.XtraEditors.PanelControl pnlIOList;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl IOSpreadSheet;
        private DevExpress.XtraBars.BarCheckItem chkViewIOList;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIName;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colHMIDesc;
        private DevExpress.XtraBars.PopupMenu mnuMappingHMI;
        private DevExpress.XtraBars.BarButtonItem btnConnectHMI;
        private DevExpress.XtraBars.BarButtonItem btnConnectDataType;
        private DevExpress.XtraBars.BarButtonItem btnInputHMIBit;
        private DevExpress.XtraBars.BarManager exbarManager;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lblPLCRowCount;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtPLCRowCount;
        private DevExpress.XtraEditors.LabelControl lblHMIRowCount;
        private DevExpress.XtraEditors.TextEdit txtHMIRowCount;
        private DevExpress.XtraGrid.Columns.GridColumn colMatch;
        private DevExpress.XtraGrid.Columns.GridColumn colInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colConvert;
        private DevExpress.XtraBars.BarButtonItem btnMappingCancel;
        private DevExpress.XtraBars.BarButtonItem btnAutoVerification;
        private DevExpress.XtraBars.BarEditItem txtOptionName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorVerfiOption;
        private DevExpress.XtraBars.BarButtonItem btnOptionAdd;
        private DevExpress.XtraBars.BarButtonItem btnVerificationExcel;
        private DevExpress.XtraBars.BarButtonItem btnVerificationPDF;
        private DevExpress.XtraBars.BarButtonItem btnClearVerifPLC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit1;
        private DevExpress.XtraEditors.SplitContainerControl sptVerification;
        private DevExpress.XtraGrid.GridControl grdVerifPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerifPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifName;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUsedLogic;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbolRole;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl sheetVerification;
        private DevExpress.XtraBars.BarButtonItem btnVideoMatch;
        private DevExpress.XtraBars.BarButtonItem btnVideoIOList;
        private DevExpress.XtraBars.BarButtonItem btnVideoVerification;
        private DevExpress.XtraBars.BarButtonItem chkOptionApply;
        private DevExpress.XtraGrid.Columns.GridColumn colRedundancy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.BarButtonItem btnAutoMapping;
        private DevExpress.XtraBars.BarButtonItem btnAllMappingCancel;
        private DevExpress.XtraBars.BarStaticItem lblUserOption;
        private DevExpress.XtraBars.BarButtonItem btnHMIClear;
        private DevExpress.XtraBars.BarButtonItem btnAutoHMIVerif;
        private DevExpress.XtraBars.BarEditItem txtHMIOptionName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit exEditorHMIVerifOption;
        private DevExpress.XtraBars.BarButtonItem btnHMIOptionAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHMIVerification;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHMIVerification;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDefHMIVerif;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHMIExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit2;
        private DevExpress.XtraTab.XtraTabPage tpHMIVerification;
        private DevExpress.XtraEditors.SplitContainerControl sptHMIVerification;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl sheetHMIVerification;
        private DevExpress.XtraGrid.GridControl grdVerifHMI;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerifHMI;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifHMIName;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifHMIDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifHMIAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifHMIDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifIsMatch;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifIsInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifIsConvert;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifIsRedundancy;
        private DevExpress.XtraGrid.Columns.GridColumn colVerifIsEmpty;
        private DevExpress.XtraBars.BarButtonItem btnVerifMappingCancel;
        private DevExpress.XtraBars.PopupMenu mnuVerifHMI;
        private DevExpress.XtraBars.BarButtonItem btnVerifHMIExcelExport;
        private DevExpress.XtraBars.BarButtonItem btnVerifHMIPDFExport;
        private DevExpress.XtraBars.BarButtonItem btnGroupAutoMapping;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.GroupBox grpFilterOption;
        private DevExpress.XtraEditors.CheckButton chkRedundancy;
        private DevExpress.XtraEditors.CheckButton chkNullEmpty;
        private DevExpress.XtraEditors.CheckButton chkMapping;
        private DevExpress.XtraGrid.Columns.GridColumn colPLCKey;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkStation;
        private DevExpress.XtraBars.BarButtonItem btnCheckConnectPLC;
        private DevExpress.XtraBars.BarButtonItem btnConnectHMITag;
        private DevExpress.XtraBars.PopupMenu mnuMappingPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraTab.XtraTabControl tabPLCVerif;
        private DevExpress.XtraTab.XtraTabPage tpGrid;
        private DevExpress.XtraTab.XtraTabPage tpLadderView;
        private DevExpress.XtraEditors.PanelControl pnlView;
        private DevExpress.XtraEditors.PanelControl pnlLadderView;
        private DevExpress.XtraEditors.PanelControl pnlLadderViewBtn;
        private DevExpress.XtraEditors.SimpleButton btnClearLadderView;
        private DevExpress.XtraGrid.Columns.GridColumn colPLCGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colExistedMatch;
        private DevExpress.XtraBars.BarButtonItem btnMappingCheck;
        private DevExpress.XtraBars.BarButtonItem btnRecommend;
        private DevExpress.XtraBars.BarButtonItem btnStandardDicView;
        private DevExpress.XtraBars.BarButtonItem btnSymbolStandardization;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgPLCSymbolStandardization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuStandardFile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuStandardPLC;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuStandardization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuStandardExit;
        private DevExpress.XtraBars.BarButtonItem btnStandardizationApply;
        private DevExpress.XtraBars.PopupMenu mnuStandard;
        private DevExpress.XtraBars.BarButtonItem btnExportErrorList;
        private DevExpress.XtraBars.BarButtonItem btnAllLevelClear;
        private DevExpress.XtraBars.BarButtonItem btnAddLibrary;
        private DevExpress.XtraBars.BarButtonItem btnLevelLeftMove;
        private DevExpress.XtraBars.BarButtonItem btnLevelRightMove;
        private DevExpress.XtraBars.BarButtonItem btnReplace;
        private DevExpress.XtraTab.XtraTabPage tpDesign;
        private DevExpress.XtraBars.BarButtonItem btnAddressRangeView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDesignPLC;
        private DevExpress.XtraTab.XtraTabControl tabDesign;
        private DevExpress.XtraTab.XtraTabPage tpDesignDesign;
        private DevExpress.XtraEditors.PanelControl pnlDesign2;
        private DevExpress.XtraGrid.GridControl grdDesignPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDesignPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignName;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignKey;
        private DevExpress.XtraEditors.PanelControl pnlDesignControl;
        private DevExpress.XtraEditors.SplitterControl sptDesign;
        private DevExpress.XtraEditors.PanelControl pnlDesign1;
        private DevExpress.XtraTab.XtraTabPage tpDesignStandardization;
        private System.Windows.Forms.CheckBox chkDesignPLCEditable;
        private DevExpress.XtraBars.BarButtonItem btnOpenPLCTag;
        private DevExpress.XtraEditors.SimpleButton btnAddSymbol;
        private DevExpress.XtraEditors.SimpleButton btnSymbolDelete;
        private DevExpress.XtraGrid.GridControl grdStd;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStd;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colTargetDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colLv1;
        private DevExpress.XtraGrid.Columns.GridColumn colLv2;
        private DevExpress.XtraGrid.Columns.GridColumn colLv3;
        private DevExpress.XtraGrid.Columns.GridColumn colLv4;
        private DevExpress.XtraGrid.Columns.GridColumn colLv5;
        private DevExpress.XtraGrid.Columns.GridColumn colLv6;
        private DevExpress.XtraGrid.Columns.GridColumn colLv7;
        private DevExpress.XtraGrid.Columns.GridColumn colLv8;
        private DevExpress.XtraGrid.Columns.GridColumn colLv9;
        private DevExpress.XtraGrid.Columns.GridColumn colLv10;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.CheckButton chkStandardization;
        private DevExpress.XtraEditors.PanelControl panelControl14;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.CheckButton chkStdLNotExist;
        private DevExpress.XtraEditors.CheckButton chkStdLExist;
        private DevExpress.XtraEditors.GroupControl grpStdL;
        private DevExpress.XtraGrid.GridControl grdStdL;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStdL;
        private DevExpress.XtraGrid.Columns.GridColumn colOldName;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardName;
        private DevExpress.XtraGrid.Columns.GridColumn colStdDescription;
        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.SimpleButton btnHideStdL;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnLibraryAdd;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraTab.XtraTabControl tabIOData;
        private DevExpress.XtraTab.XtraTabPage tpIOData;
        private DevExpress.XtraTab.XtraTabPage tpAddressRangeData;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl11;
        private DevExpress.XtraEditors.PanelControl panelControl10;
        private DevExpress.XtraEditors.GroupControl grpAddressArea;
        private DevExpress.XtraEditors.PanelControl panelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl12;
        private DevExpress.XtraEditors.CheckEdit chkUsed;
        private DevExpress.XtraEditors.CheckEdit chkExtend;
        private DevExpress.XtraEditors.ComboBoxEdit cboPLCList;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRangeDetailView;
        private DevExpress.XtraBars.BarButtonItem btnSymbolNameEdit;
        private DevExpress.XtraBars.BarButtonItem btnModuleSetting;
        private DevExpress.XtraEditors.PanelControl panelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboListType;
        private DevExpress.XtraEditors.PanelControl panelControl13;
        private UCIOModule ucIOModule;
        private DevExpress.XtraEditors.PanelControl panelControl16;
        private DevExpress.XtraEditors.SimpleButton btnModuleInfoSetting;
        private DevExpress.XtraEditors.PanelControl panelControl19;
        private DevExpress.XtraEditors.CheckEdit chkIOUsed;
        private DevExpress.XtraEditors.CheckEdit chkIOExtend;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl17;
        private DevExpress.XtraEditors.SimpleButton btnAllTagView;
        private DevExpress.XtraBars.BarButtonItem btnPLCTagExport;
        private DevExpress.XtraBars.BarButtonItem btnNewPLC;
        private DevExpress.XtraBars.BarButtonItem btnModeChange;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuPLCVerifFile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHMIVerifFile;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignNote;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnIOList;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl20;
        private DevExpress.XtraEditors.PanelControl panelControl18;
        private DevExpress.XtraTab.XtraTabPage tpIOTree;
        private UCVerifyTree ucVerifyIOTree;
        private DevExpress.XtraTab.XtraTabPage tpTagList;
        private DevExpress.XtraTab.XtraTabControl tabPLCVerif2;
        private DevExpress.XtraTab.XtraTabPage tpReport;
        private DevExpress.XtraTab.XtraTabPage tpReportElement;
        private UCVerifyTree ucVerifyAllTree;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private UCVerifyTree ucVerifyElemTree;
        private DevExpress.XtraEditors.PanelControl panelControl21;
        private DevExpress.XtraEditors.SimpleButton btnVerifSettingApply;
        private DevExpress.XtraEditors.SimpleButton btnReportElemSetting;
        private DevExpress.XtraEditors.SimpleButton btnReportTreeClear;
        private DevExpress.XtraEditors.PanelControl panelControl22;
        private DevExpress.XtraEditors.SimpleButton btnReportInit;
        private DevExpress.XtraBars.BarButtonItem btnAboutIOMaker;
        private DevExpress.XtraBars.BarButtonItem btnFileExportGuide;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuHelpExit;
        private DevExpress.XtraBars.PopupMenu mnuExportGuide;
        private DevExpress.XtraBars.BarButtonItem btnMelsecGuide;
        private DevExpress.XtraBars.BarButtonItem btnSiemensGuide;
        private DevExpress.XtraBars.BarButtonItem btnABGuide;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private DevExpress.XtraTab.XtraTabControl tabHelp;
        private DevExpress.XtraTab.XtraTabPage tpManual;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;
        private DevExpress.XtraBars.BarButtonItem btnManual;
        private DevExpress.XtraBars.BarButtonItem btnPDFClear;
        private DevExpress.XtraBars.BarStaticItem lblFactory;
        private DevExpress.XtraBars.BarStaticItem lblLine;
        private DevExpress.XtraBars.BarEditItem txtFactory;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem txtLine;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarCheckItem chkStandardizationView;
        private DevExpress.XtraEditors.SimpleButton btnStandardApply;
        private DevExpress.XtraEditors.SimpleButton btnStandardization;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.PanelControl panelControl23;
        private DevExpress.XtraEditors.SimpleButton btnExcelSave;
        private DevExpress.XtraEditors.CheckEdit chkExcelEdit;
        private DevExpress.XtraEditors.SimpleButton btnOpenExcelPath;
        private DevExpress.XtraEditors.PanelControl panelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ButtonEdit btnSavePathOpen;
        private DevExpress.XtraEditors.PanelControl panelControl26;
        private DevExpress.XtraEditors.PanelControl panelControl25;
        private DevExpress.XtraEditors.PanelControl panelControl27;
        private DevExpress.XtraEditors.CheckButton chkExcelEditable;
    }
}

