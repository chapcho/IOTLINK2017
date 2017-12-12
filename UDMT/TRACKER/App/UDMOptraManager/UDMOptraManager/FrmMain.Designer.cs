namespace UDMOptraManager
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
            DevExpress.XtraBars.Ribbon.ReduceOperation reduceOperation5 = new DevExpress.XtraBars.Ribbon.ReduceOperation();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState65 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState66 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState67 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState68 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState69 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState70 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState71 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState72 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState73 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState74 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState75 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState76 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState77 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState78 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState79 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState80 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnManualStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnManualStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnReset = new DevExpress.XtraBars.BarButtonItem();
            this.dtpkOperStart = new DevExpress.XtraBars.BarEditItem();
            this.exEditorOperStart = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.dtpkOperEnd = new DevExpress.XtraBars.BarEditItem();
            this.exEditorOperEnd = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.lblOperStart = new DevExpress.XtraBars.BarStaticItem();
            this.lblOperEnd = new DevExpress.XtraBars.BarStaticItem();
            this.lblOptraPath = new DevExpress.XtraBars.BarStaticItem();
            this.btnExcuteFilePath = new DevExpress.XtraBars.BarEditItem();
            this.exEditorExecuteFilePath = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.chkAutoControlApply = new DevExpress.XtraBars.BarCheckItem();
            this.btnLSOPCOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogicExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnHide = new DevExpress.XtraBars.BarButtonItem();
            this.lblDBBackCycle = new DevExpress.XtraBars.BarHeaderItem();
            this.cmbCBBackCycle = new DevExpress.XtraBars.BarEditItem();
            this.exEditorDBCycle = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.lblDB = new DevExpress.XtraBars.BarStaticItem();
            this.btnDBFilePath = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.chkAutoReportExport = new DevExpress.XtraBars.BarCheckItem();
            this.pgHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuManualControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuAutoControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuDBControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuLSConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuEx = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrAutoRestart = new System.Windows.Forms.Timer(this.components);
            this.grpSystemMessage = new DevExpress.XtraEditors.GroupControl();
            this.tabSystemMessage = new DevExpress.XtraTab.XtraTabControl();
            this.tpTrackerManager = new DevExpress.XtraTab.XtraTabPage();
            this.ucManagerSystemLogTable = new UDMOptraManager.UCSystemLogTable();
            this.tpTracker = new DevExpress.XtraTab.XtraTabPage();
            this.ucTrackerSystemLogTable = new UDMOptraManager.UCSystemLogTable();
            this.sptMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpProject = new DevExpress.XtraEditors.GroupControl();
            this.grdProjectInfo = new DevExpress.XtraGrid.GridControl();
            this.grvProjectInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpStatus = new DevExpress.XtraEditors.GroupControl();
            this.pnlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gaugeControl3 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge4 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.IndiOPC = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.labelComponent8 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent9 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.pnlOPC = new DevExpress.XtraEditors.PanelControl();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge3 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.IndiAutoControl = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.labelComponent4 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent5 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.pnlMonitoringStatus = new DevExpress.XtraEditors.PanelControl();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge2 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.IndiMonitoring = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.labelComponent3 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent7 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.pnlOptraStatus = new DevExpress.XtraEditors.PanelControl();
            this.gaugeOptra = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGauge1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.IndiOptra = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.labelComponent2 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.sptBottom = new DevExpress.XtraEditors.SplitterControl();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.labelComponent6 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.tmrSystemLog = new System.Windows.Forms.Timer(this.components);
            this.tmrStartMonitoring = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoDBRecreate = new System.Windows.Forms.Timer(this.components);
            this.tmrUnkownErrorAction = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExecuteFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.cntxNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).BeginInit();
            this.grpSystemMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSystemMessage)).BeginInit();
            this.tabSystemMessage.SuspendLayout();
            this.tpTrackerManager.SuspendLayout();
            this.tpTracker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProject)).BeginInit();
            this.grpProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProjectInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatus)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.pnlLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiOPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOPC)).BeginInit();
            this.pnlOPC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiAutoControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoringStatus)).BeginInit();
            this.pnlMonitoringStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOptraStatus)).BeginInit();
            this.pnlOptraStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiOptra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent6)).BeginInit();
            this.SuspendLayout();
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.AllowMinimizeRibbon = false;
            this.exRibbonControl.ExpandCollapseItem.Id = 0;
            this.exRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonControl.ExpandCollapseItem,
            this.btnManualStart,
            this.btnManualStop,
            this.btnExit,
            this.btnReset,
            this.dtpkOperStart,
            this.dtpkOperEnd,
            this.lblOperStart,
            this.lblOperEnd,
            this.lblOptraPath,
            this.btnExcuteFilePath,
            this.chkAutoControlApply,
            this.btnLSOPCOpen,
            this.btnLogicExport,
            this.btnHide,
            this.lblDBBackCycle,
            this.cmbCBBackCycle,
            this.lblDB,
            this.btnDBFilePath,
            this.chkAutoReportExport});
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.MaxItemId = 22;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHome});
            this.exRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorOperStart,
            this.exEditorOperEnd,
            this.exEditorExecuteFilePath,
            this.exEditorDBCycle,
            this.repositoryItemButtonEdit1});
            this.exRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exRibbonControl.ShowCategoryInCaption = false;
            this.exRibbonControl.Size = new System.Drawing.Size(1155, 147);
            this.exRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnManualStart
            // 
            this.btnManualStart.Caption = "Tracker Start";
            this.btnManualStart.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManualStart.Glyph")));
            this.btnManualStart.Id = 2;
            this.btnManualStart.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManualStart.LargeGlyph")));
            this.btnManualStart.Name = "btnManualStart";
            this.btnManualStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManualStart_ItemClick);
            // 
            // btnManualStop
            // 
            this.btnManualStop.Caption = "Tracker Stop";
            this.btnManualStop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnManualStop.Glyph")));
            this.btnManualStop.Id = 3;
            this.btnManualStop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnManualStop.LargeGlyph")));
            this.btnManualStop.Name = "btnManualStop";
            this.btnManualStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManualStop_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 4;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnReset
            // 
            this.btnReset.Caption = "리셋";
            this.btnReset.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnReset.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReset.Glyph")));
            this.btnReset.Id = 8;
            this.btnReset.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnReset.LargeGlyph")));
            this.btnReset.Name = "btnReset";
            // 
            // dtpkOperStart
            // 
            this.dtpkOperStart.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.dtpkOperStart.Edit = this.exEditorOperStart;
            this.dtpkOperStart.EditValue = new System.DateTime(2016, 11, 1, 7, 0, 0, 0);
            this.dtpkOperStart.Id = 9;
            this.dtpkOperStart.Name = "dtpkOperStart";
            this.dtpkOperStart.Width = 150;
            this.dtpkOperStart.EditValueChanged += new System.EventHandler(this.dtpkOperStart_EditValueChanged);
            // 
            // exEditorOperStart
            // 
            this.exEditorOperStart.Appearance.Options.UseTextOptions = true;
            this.exEditorOperStart.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorOperStart.AutoHeight = false;
            this.exEditorOperStart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOperStart.DisplayFormat.FormatString = "HH : mm";
            this.exEditorOperStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperStart.EditFormat.FormatString = "HH : mm";
            this.exEditorOperStart.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperStart.Mask.EditMask = "HH : mm";
            this.exEditorOperStart.Name = "exEditorOperStart";
            // 
            // dtpkOperEnd
            // 
            this.dtpkOperEnd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.dtpkOperEnd.Edit = this.exEditorOperEnd;
            this.dtpkOperEnd.EditValue = new System.DateTime(2016, 11, 1, 0, 0, 0, 0);
            this.dtpkOperEnd.Id = 10;
            this.dtpkOperEnd.Name = "dtpkOperEnd";
            this.dtpkOperEnd.Width = 150;
            this.dtpkOperEnd.EditValueChanged += new System.EventHandler(this.dtpkOperEnd_EditValueChanged);
            // 
            // exEditorOperEnd
            // 
            this.exEditorOperEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exEditorOperEnd.Appearance.Options.UseFont = true;
            this.exEditorOperEnd.Appearance.Options.UseTextOptions = true;
            this.exEditorOperEnd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorOperEnd.AutoHeight = false;
            this.exEditorOperEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorOperEnd.DisplayFormat.FormatString = "HH : mm";
            this.exEditorOperEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperEnd.EditFormat.FormatString = "HH : mm";
            this.exEditorOperEnd.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorOperEnd.Mask.EditMask = "HH : mm";
            this.exEditorOperEnd.Name = "exEditorOperEnd";
            // 
            // lblOperStart
            // 
            this.lblOperStart.Caption = "Auto Start Time :";
            this.lblOperStart.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblOperStart.Id = 11;
            this.lblOperStart.Name = "lblOperStart";
            this.lblOperStart.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblOperEnd
            // 
            this.lblOperEnd.Caption = "Auto Stop Time :";
            this.lblOperEnd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblOperEnd.Id = 12;
            this.lblOperEnd.Name = "lblOperEnd";
            this.lblOperEnd.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblOptraPath
            // 
            this.lblOptraPath.Caption = "Excute File Path :";
            this.lblOptraPath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblOptraPath.Id = 13;
            this.lblOptraPath.Name = "lblOptraPath";
            this.lblOptraPath.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnExcuteFilePath
            // 
            this.btnExcuteFilePath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExcuteFilePath.Edit = this.exEditorExecuteFilePath;
            this.btnExcuteFilePath.EditValue = "D:\\OPTRA_작업\\bin\\UDMTrackerSimple.exe";
            this.btnExcuteFilePath.Id = 16;
            this.btnExcuteFilePath.Name = "btnExcuteFilePath";
            this.btnExcuteFilePath.Width = 150;
            this.btnExcuteFilePath.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcuteFilePath_ItemPress);
            // 
            // exEditorExecuteFilePath
            // 
            this.exEditorExecuteFilePath.AutoHeight = false;
            this.exEditorExecuteFilePath.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.exEditorExecuteFilePath.Name = "exEditorExecuteFilePath";
            // 
            // chkAutoControlApply
            // 
            this.chkAutoControlApply.Caption = "Apply Auto Control Option";
            this.chkAutoControlApply.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkAutoControlApply.Glyph = ((System.Drawing.Image)(resources.GetObject("chkAutoControlApply.Glyph")));
            this.chkAutoControlApply.Id = 1;
            this.chkAutoControlApply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkAutoControlApply.LargeGlyph")));
            this.chkAutoControlApply.Name = "chkAutoControlApply";
            this.chkAutoControlApply.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkAutoControlApply_CheckedChanged);
            // 
            // btnLSOPCOpen
            // 
            this.btnLSOPCOpen.Caption = "LS산전 OPC 서버 열기";
            this.btnLSOPCOpen.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLSOPCOpen.Id = 2;
            this.btnLSOPCOpen.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLSOPCOpen.LargeGlyph")));
            this.btnLSOPCOpen.Name = "btnLSOPCOpen";
            this.btnLSOPCOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLSOPCOpen_ItemClick);
            // 
            // btnLogicExport
            // 
            this.btnLogicExport.Caption = "LS산전\r\n로직 추출";
            this.btnLogicExport.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLogicExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogicExport.Glyph")));
            this.btnLogicExport.Id = 3;
            this.btnLogicExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogicExport.LargeGlyph")));
            this.btnLogicExport.Name = "btnLogicExport";
            this.btnLogicExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogicExport_ItemClick);
            // 
            // btnHide
            // 
            this.btnHide.Caption = "Hide";
            this.btnHide.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHide.Glyph")));
            this.btnHide.Id = 10;
            this.btnHide.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHide.LargeGlyph")));
            this.btnHide.Name = "btnHide";
            this.btnHide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHide_ItemClick);
            // 
            // lblDBBackCycle
            // 
            this.lblDBBackCycle.Caption = "DB Backup Cycle";
            this.lblDBBackCycle.Id = 15;
            this.lblDBBackCycle.Name = "lblDBBackCycle";
            // 
            // cmbCBBackCycle
            // 
            this.cmbCBBackCycle.Caption = "DB Backup Cycle  ";
            this.cmbCBBackCycle.Edit = this.exEditorDBCycle;
            this.cmbCBBackCycle.Id = 16;
            this.cmbCBBackCycle.Name = "cmbCBBackCycle";
            this.cmbCBBackCycle.Width = 200;
            this.cmbCBBackCycle.EditValueChanged += new System.EventHandler(this.cmbCBBackCycle_EditValueChanged);
            // 
            // exEditorDBCycle
            // 
            this.exEditorDBCycle.Appearance.Options.UseTextOptions = true;
            this.exEditorDBCycle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorDBCycle.AppearanceDropDown.Options.UseTextOptions = true;
            this.exEditorDBCycle.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorDBCycle.AppearanceFocused.Options.UseTextOptions = true;
            this.exEditorDBCycle.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorDBCycle.AppearanceReadOnly.Options.UseTextOptions = true;
            this.exEditorDBCycle.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorDBCycle.AutoHeight = false;
            this.exEditorDBCycle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDBCycle.Items.AddRange(new object[] {
            "Monthly",
            "Quarterly",
            "Half a year"});
            this.exEditorDBCycle.Name = "exEditorDBCycle";
            this.exEditorDBCycle.NullText = "Monthly";
            this.exEditorDBCycle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // lblDB
            // 
            this.lblDB.Caption = "DB Backup Cycle";
            this.lblDB.Glyph = ((System.Drawing.Image)(resources.GetObject("lblDB.Glyph")));
            this.lblDB.Id = 19;
            this.lblDB.Name = "lblDB";
            this.lblDB.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnDBFilePath
            // 
            this.btnDBFilePath.Caption = "DB Save Path      ";
            this.btnDBFilePath.Edit = this.repositoryItemButtonEdit1;
            this.btnDBFilePath.Id = 20;
            this.btnDBFilePath.Name = "btnDBFilePath";
            this.btnDBFilePath.Width = 200;
            this.btnDBFilePath.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBFilePath_ItemPress);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // chkAutoReportExport
            // 
            this.chkAutoReportExport.Caption = "Apply Auto Export Report";
            this.chkAutoReportExport.Glyph = ((System.Drawing.Image)(resources.GetObject("chkAutoReportExport.Glyph")));
            this.chkAutoReportExport.Id = 21;
            this.chkAutoReportExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkAutoReportExport.LargeGlyph")));
            this.chkAutoReportExport.Name = "chkAutoReportExport";
            // 
            // pgHome
            // 
            this.pgHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuManualControl,
            this.mnuAutoControl,
            this.mnuDBControl,
            this.mnuLSConfig,
            this.mnuEx});
            this.pgHome.Name = "pgHome";
            reduceOperation5.Behavior = DevExpress.XtraBars.Ribbon.ReduceOperationBehavior.Single;
            reduceOperation5.Group = null;
            reduceOperation5.ItemLinkIndex = 0;
            reduceOperation5.ItemLinksCount = 0;
            reduceOperation5.Operation = DevExpress.XtraBars.Ribbon.ReduceOperationType.LargeButtons;
            this.pgHome.ReduceOperations.Add(reduceOperation5);
            this.pgHome.Text = "Home";
            // 
            // mnuManualControl
            // 
            this.mnuManualControl.ItemLinks.Add(this.btnManualStart);
            this.mnuManualControl.ItemLinks.Add(this.btnManualStop);
            this.mnuManualControl.Name = "mnuManualControl";
            this.mnuManualControl.ShowCaptionButton = false;
            this.mnuManualControl.Text = "Manual Control";
            // 
            // mnuAutoControl
            // 
            this.mnuAutoControl.ItemLinks.Add(this.lblOptraPath);
            this.mnuAutoControl.ItemLinks.Add(this.lblOperStart);
            this.mnuAutoControl.ItemLinks.Add(this.lblOperEnd);
            this.mnuAutoControl.ItemLinks.Add(this.btnExcuteFilePath);
            this.mnuAutoControl.ItemLinks.Add(this.dtpkOperStart);
            this.mnuAutoControl.ItemLinks.Add(this.dtpkOperEnd);
            this.mnuAutoControl.ItemLinks.Add(this.chkAutoControlApply);
            this.mnuAutoControl.Name = "mnuAutoControl";
            this.mnuAutoControl.Text = "Auto Control";
            // 
            // mnuDBControl
            // 
            this.mnuDBControl.ItemLinks.Add(this.cmbCBBackCycle);
            this.mnuDBControl.ItemLinks.Add(this.btnDBFilePath);
            this.mnuDBControl.ItemLinks.Add(this.chkAutoReportExport);
            this.mnuDBControl.Name = "mnuDBControl";
            this.mnuDBControl.Text = "DB Control";
            // 
            // mnuLSConfig
            // 
            this.mnuLSConfig.ItemLinks.Add(this.btnLSOPCOpen);
            this.mnuLSConfig.ItemLinks.Add(this.btnLogicExport);
            this.mnuLSConfig.Name = "mnuLSConfig";
            this.mnuLSConfig.Text = "LS산전 통신/로직 설정";
            this.mnuLSConfig.Visible = false;
            // 
            // mnuEx
            // 
            this.mnuEx.ItemLinks.Add(this.btnHide);
            this.mnuEx.ItemLinks.Add(this.btnExit);
            this.mnuEx.Name = "mnuEx";
            this.mnuEx.ShowCaptionButton = false;
            this.mnuEx.Text = "Hide/Exit";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "UDM Tracker Manager";
            this.notifyIcon.ContextMenuStrip = this.cntxNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "UDM Tracker Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // cntxNotify
            // 
            this.cntxNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuHide,
            this.toolStripSeparator1,
            this.mnuExit});
            this.cntxNotify.Name = "cntxNotify";
            this.cntxNotify.Size = new System.Drawing.Size(104, 76);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuHide
            // 
            this.mnuHide.Name = "mnuHide";
            this.mnuHide.Size = new System.Drawing.Size(103, 22);
            this.mnuHide.Text = "Hide";
            this.mnuHide.Click += new System.EventHandler(this.mnuHide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(103, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // tmrAutoRestart
            // 
            this.tmrAutoRestart.Interval = 60000;
            this.tmrAutoRestart.Tick += new System.EventHandler(this.tmrAutoRestart_Tick);
            // 
            // grpSystemMessage
            // 
            this.grpSystemMessage.Controls.Add(this.tabSystemMessage);
            this.grpSystemMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpSystemMessage.Location = new System.Drawing.Point(0, 451);
            this.grpSystemMessage.Name = "grpSystemMessage";
            this.grpSystemMessage.Size = new System.Drawing.Size(1155, 197);
            this.grpSystemMessage.TabIndex = 37;
            this.grpSystemMessage.Text = "System Message";
            // 
            // tabSystemMessage
            // 
            this.tabSystemMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSystemMessage.Location = new System.Drawing.Point(2, 21);
            this.tabSystemMessage.Name = "tabSystemMessage";
            this.tabSystemMessage.SelectedTabPage = this.tpTrackerManager;
            this.tabSystemMessage.Size = new System.Drawing.Size(1151, 174);
            this.tabSystemMessage.TabIndex = 1;
            this.tabSystemMessage.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTrackerManager,
            this.tpTracker});
            // 
            // tpTrackerManager
            // 
            this.tpTrackerManager.Controls.Add(this.ucManagerSystemLogTable);
            this.tpTrackerManager.Name = "tpTrackerManager";
            this.tpTrackerManager.Size = new System.Drawing.Size(1145, 145);
            this.tpTrackerManager.Text = "Tracker Manager";
            // 
            // ucManagerSystemLogTable
            // 
            this.ucManagerSystemLogTable.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucManagerSystemLogTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucManagerSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManagerSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucManagerSystemLogTable.Name = "ucManagerSystemLogTable";
            this.ucManagerSystemLogTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucManagerSystemLogTable.Size = new System.Drawing.Size(1145, 145);
            this.ucManagerSystemLogTable.TabIndex = 0;
            // 
            // tpTracker
            // 
            this.tpTracker.Controls.Add(this.ucTrackerSystemLogTable);
            this.tpTracker.Name = "tpTracker";
            this.tpTracker.Size = new System.Drawing.Size(1145, 145);
            this.tpTracker.Text = "Tracker";
            // 
            // ucTrackerSystemLogTable
            // 
            this.ucTrackerSystemLogTable.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ucTrackerSystemLogTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTrackerSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTrackerSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucTrackerSystemLogTable.Name = "ucTrackerSystemLogTable";
            this.ucTrackerSystemLogTable.Padding = new System.Windows.Forms.Padding(5);
            this.ucTrackerSystemLogTable.Size = new System.Drawing.Size(1145, 145);
            this.ucTrackerSystemLogTable.TabIndex = 1;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 147);
            this.sptMain.MinimumSize = new System.Drawing.Size(0, 300);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.grpProject);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.grpStatus);
            this.sptMain.Panel2.MinSize = 300;
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1155, 300);
            this.sptMain.SplitterPosition = 630;
            this.sptMain.TabIndex = 39;
            this.sptMain.Text = "splitContainerControl1";
            // 
            // grpProject
            // 
            this.grpProject.Controls.Add(this.grdProjectInfo);
            this.grpProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProject.Location = new System.Drawing.Point(0, 0);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(630, 300);
            this.grpProject.TabIndex = 0;
            this.grpProject.Text = "Tracker Project Info.";
            // 
            // grdProjectInfo
            // 
            this.grdProjectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProjectInfo.Location = new System.Drawing.Point(2, 21);
            this.grdProjectInfo.MainView = this.grvProjectInfo;
            this.grdProjectInfo.MenuManager = this.exRibbonControl;
            this.grdProjectInfo.Name = "grdProjectInfo";
            this.grdProjectInfo.Size = new System.Drawing.Size(626, 277);
            this.grdProjectInfo.TabIndex = 0;
            this.grdProjectInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProjectInfo});
            // 
            // grvProjectInfo
            // 
            this.grvProjectInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colItem,
            this.colValue});
            this.grvProjectInfo.GridControl = this.grdProjectInfo;
            this.grvProjectInfo.Name = "grvProjectInfo";
            this.grvProjectInfo.OptionsBehavior.Editable = false;
            this.grvProjectInfo.OptionsBehavior.ReadOnly = true;
            this.grvProjectInfo.OptionsDetail.EnableMasterViewMode = false;
            this.grvProjectInfo.OptionsDetail.ShowDetailTabs = false;
            this.grvProjectInfo.OptionsDetail.SmartDetailExpand = false;
            this.grvProjectInfo.OptionsView.AllowCellMerge = true;
            this.grvProjectInfo.OptionsView.ShowGroupPanel = false;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceHeader.Options.UseFont = true;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.FieldName = "Group";
            this.colGroup.MaxWidth = 90;
            this.colGroup.MinWidth = 90;
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.ReadOnly = true;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            this.colGroup.Width = 90;
            // 
            // colItem
            // 
            this.colItem.AppearanceCell.Options.UseTextOptions = true;
            this.colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colItem.AppearanceHeader.Options.UseFont = true;
            this.colItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.Caption = "Category";
            this.colItem.FieldName = "Item";
            this.colItem.MaxWidth = 100;
            this.colItem.MinWidth = 100;
            this.colItem.Name = "colItem";
            this.colItem.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colItem.OptionsColumn.ReadOnly = true;
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 1;
            this.colItem.Width = 100;
            // 
            // colValue
            // 
            this.colValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colValue.AppearanceHeader.Options.UseFont = true;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colValue.OptionsColumn.ReadOnly = true;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 2;
            this.colValue.Width = 275;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.pnlLayout);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Location = new System.Drawing.Point(0, 0);
            this.grpStatus.MinimumSize = new System.Drawing.Size(300, 300);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(520, 300);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.Text = "상태 표시";
            // 
            // pnlLayout
            // 
            this.pnlLayout.ColumnCount = 2;
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.Controls.Add(this.gaugeControl3, 0, 1);
            this.pnlLayout.Controls.Add(this.pnlOPC, 0, 1);
            this.pnlLayout.Controls.Add(this.pnlMonitoringStatus, 1, 0);
            this.pnlLayout.Controls.Add(this.pnlOptraStatus, 0, 0);
            this.pnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLayout.Location = new System.Drawing.Point(2, 21);
            this.pnlLayout.Name = "pnlLayout";
            this.pnlLayout.RowCount = 2;
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLayout.Size = new System.Drawing.Size(516, 277);
            this.pnlLayout.TabIndex = 0;
            // 
            // gaugeControl3
            // 
            this.gaugeControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl3.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge4});
            this.gaugeControl3.Location = new System.Drawing.Point(3, 141);
            this.gaugeControl3.Name = "gaugeControl3";
            this.gaugeControl3.Size = new System.Drawing.Size(252, 133);
            this.gaugeControl3.TabIndex = 3;
            // 
            // stateIndicatorGauge4
            // 
            this.stateIndicatorGauge4.Bounds = new System.Drawing.Rectangle(6, 6, 240, 121);
            this.stateIndicatorGauge4.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.IndiOPC});
            this.stateIndicatorGauge4.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent8,
            this.labelComponent9});
            this.stateIndicatorGauge4.Name = "stateIndicatorGauge4";
            // 
            // IndiOPC
            // 
            this.IndiOPC.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.IndiOPC.Name = "stateIndicatorComponent1";
            this.IndiOPC.Size = new System.Drawing.SizeF(200F, 200F);
            this.IndiOPC.StateIndex = 0;
            indicatorState65.Name = "State1";
            indicatorState65.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer1;
            indicatorState66.Name = "State2";
            indicatorState66.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            indicatorState67.Name = "State3";
            indicatorState67.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer3;
            indicatorState68.Name = "State4";
            indicatorState68.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4;
            this.IndiOPC.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState65,
            indicatorState66,
            indicatorState67,
            indicatorState68});
            // 
            // labelComponent8
            // 
            this.labelComponent8.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent8.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent8.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent8.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 100F);
            this.labelComponent8.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent8.Text = "OPC";
            this.labelComponent8.ZOrder = -1001;
            // 
            // labelComponent9
            // 
            this.labelComponent9.AppearanceText.Font = new System.Drawing.Font("Tahoma", 27F);
            this.labelComponent9.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent9.Name = "stateIndicatorGauge2_Label2";
            this.labelComponent9.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 150F);
            this.labelComponent9.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent9.Text = "Connection";
            this.labelComponent9.ZOrder = -1001;
            // 
            // pnlOPC
            // 
            this.pnlOPC.Controls.Add(this.gaugeControl2);
            this.pnlOPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOPC.Location = new System.Drawing.Point(261, 141);
            this.pnlOPC.Name = "pnlOPC";
            this.pnlOPC.Size = new System.Drawing.Size(252, 133);
            this.pnlOPC.TabIndex = 2;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge3});
            this.gaugeControl2.Location = new System.Drawing.Point(2, 2);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(248, 129);
            this.gaugeControl2.TabIndex = 2;
            // 
            // stateIndicatorGauge3
            // 
            this.stateIndicatorGauge3.Bounds = new System.Drawing.Rectangle(6, 6, 236, 117);
            this.stateIndicatorGauge3.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.IndiAutoControl});
            this.stateIndicatorGauge3.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent4,
            this.labelComponent5});
            this.stateIndicatorGauge3.Name = "stateIndicatorGauge3";
            // 
            // IndiAutoControl
            // 
            this.IndiAutoControl.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.IndiAutoControl.Name = "stateIndicatorComponent1";
            this.IndiAutoControl.Size = new System.Drawing.SizeF(200F, 200F);
            this.IndiAutoControl.StateIndex = 0;
            indicatorState69.Name = "State1";
            indicatorState69.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer1;
            indicatorState70.Name = "State2";
            indicatorState70.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            indicatorState71.Name = "State3";
            indicatorState71.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer3;
            indicatorState72.Name = "State4";
            indicatorState72.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4;
            this.IndiAutoControl.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState69,
            indicatorState70,
            indicatorState71,
            indicatorState72});
            // 
            // labelComponent4
            // 
            this.labelComponent4.AppearanceText.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent4.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent4.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent4.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 100F);
            this.labelComponent4.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent4.Text = "Apply";
            this.labelComponent4.ZOrder = -1001;
            // 
            // labelComponent5
            // 
            this.labelComponent5.AppearanceText.Font = new System.Drawing.Font("Tahoma", 24F);
            this.labelComponent5.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent5.Name = "stateIndicatorGauge2_Label2";
            this.labelComponent5.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 150F);
            this.labelComponent5.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent5.Text = "Auto Control";
            this.labelComponent5.ZOrder = -1001;
            // 
            // pnlMonitoringStatus
            // 
            this.pnlMonitoringStatus.Controls.Add(this.gaugeControl1);
            this.pnlMonitoringStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonitoringStatus.Location = new System.Drawing.Point(261, 3);
            this.pnlMonitoringStatus.Name = "pnlMonitoringStatus";
            this.pnlMonitoringStatus.Size = new System.Drawing.Size(252, 132);
            this.pnlMonitoringStatus.TabIndex = 1;
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge2});
            this.gaugeControl1.Location = new System.Drawing.Point(2, 2);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(248, 128);
            this.gaugeControl1.TabIndex = 1;
            // 
            // stateIndicatorGauge2
            // 
            this.stateIndicatorGauge2.Bounds = new System.Drawing.Rectangle(6, 6, 236, 116);
            this.stateIndicatorGauge2.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.IndiMonitoring});
            this.stateIndicatorGauge2.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent3,
            this.labelComponent7});
            this.stateIndicatorGauge2.Name = "stateIndicatorGauge2";
            // 
            // IndiMonitoring
            // 
            this.IndiMonitoring.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.IndiMonitoring.Name = "stateIndicatorComponent1";
            this.IndiMonitoring.Size = new System.Drawing.SizeF(200F, 200F);
            this.IndiMonitoring.StateIndex = 0;
            indicatorState73.Name = "State1";
            indicatorState73.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer1;
            indicatorState74.Name = "State2";
            indicatorState74.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            indicatorState75.Name = "State3";
            indicatorState75.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer3;
            indicatorState76.Name = "State4";
            indicatorState76.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4;
            this.IndiMonitoring.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState73,
            indicatorState74,
            indicatorState75,
            indicatorState76});
            // 
            // labelComponent3
            // 
            this.labelComponent3.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent3.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent3.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent3.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 100F);
            this.labelComponent3.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent3.Text = "Tracker";
            this.labelComponent3.ZOrder = -1001;
            // 
            // labelComponent7
            // 
            this.labelComponent7.AppearanceText.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent7.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent7.Name = "stateIndicatorGauge2_Label2";
            this.labelComponent7.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 150F);
            this.labelComponent7.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent7.Text = "Monitoring";
            this.labelComponent7.ZOrder = -1001;
            // 
            // pnlOptraStatus
            // 
            this.pnlOptraStatus.Controls.Add(this.gaugeOptra);
            this.pnlOptraStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptraStatus.Location = new System.Drawing.Point(3, 3);
            this.pnlOptraStatus.Name = "pnlOptraStatus";
            this.pnlOptraStatus.Size = new System.Drawing.Size(252, 132);
            this.pnlOptraStatus.TabIndex = 0;
            // 
            // gaugeOptra
            // 
            this.gaugeOptra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeOptra.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGauge1});
            this.gaugeOptra.Location = new System.Drawing.Point(2, 2);
            this.gaugeOptra.Name = "gaugeOptra";
            this.gaugeOptra.Size = new System.Drawing.Size(248, 128);
            this.gaugeOptra.TabIndex = 0;
            // 
            // stateIndicatorGauge1
            // 
            this.stateIndicatorGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 236, 116);
            this.stateIndicatorGauge1.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.IndiOptra});
            this.stateIndicatorGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent2});
            this.stateIndicatorGauge1.Name = "stateIndicatorGauge1";
            // 
            // IndiOptra
            // 
            this.IndiOptra.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.IndiOptra.Name = "stateIndicatorComponent1";
            this.IndiOptra.Size = new System.Drawing.SizeF(200F, 200F);
            this.IndiOptra.StateIndex = 0;
            indicatorState77.Name = "State1";
            indicatorState77.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer1;
            indicatorState78.Name = "State2";
            indicatorState78.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer2;
            indicatorState79.Name = "State3";
            indicatorState79.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer3;
            indicatorState80.Name = "State4";
            indicatorState80.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.Equalizer4;
            this.IndiOptra.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState77,
            indicatorState78,
            indicatorState79,
            indicatorState80});
            // 
            // labelComponent2
            // 
            this.labelComponent2.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent2.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent2.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent2.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent2.Text = "Tracker";
            this.labelComponent2.ZOrder = -1001;
            // 
            // sptBottom
            // 
            this.sptBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sptBottom.Location = new System.Drawing.Point(0, 446);
            this.sptBottom.Name = "sptBottom";
            this.sptBottom.Size = new System.Drawing.Size(1155, 5);
            this.sptBottom.TabIndex = 40;
            this.sptBottom.TabStop = false;
            // 
            // labelComponent1
            // 
            this.labelComponent1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent1.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent1.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent1.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent1.Text = "OPTRA 실행";
            this.labelComponent1.ZOrder = -1001;
            // 
            // labelComponent6
            // 
            this.labelComponent6.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComponent6.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent6.Name = "stateIndicatorGauge1_Label1";
            this.labelComponent6.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 100F);
            this.labelComponent6.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent6.Text = "OPTRA";
            this.labelComponent6.ZOrder = -1001;
            // 
            // tmrSystemLog
            // 
            this.tmrSystemLog.Interval = 3600000;
            this.tmrSystemLog.Tick += new System.EventHandler(this.tmrSystemLog_Tick);
            // 
            // tmrStartMonitoring
            // 
            this.tmrStartMonitoring.Interval = 60000;
            this.tmrStartMonitoring.Tick += new System.EventHandler(this.tmrStartMonitoring_Tick);
            // 
            // tmrAutoDBRecreate
            // 
            this.tmrAutoDBRecreate.Interval = 300000;
            this.tmrAutoDBRecreate.Tick += new System.EventHandler(this.tmrAutoDBRecreate_Tick);
            // 
            // tmrUnkownErrorAction
            // 
            this.tmrUnkownErrorAction.Interval = 180000;
            this.tmrUnkownErrorAction.Tick += new System.EventHandler(this.tmrUnkownErrorAction_Tick);
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 648);
            this.ControlBox = false;
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.sptBottom);
            this.Controls.Add(this.grpSystemMessage);
            this.Controls.Add(this.exRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDM Tracker Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorOperEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorExecuteFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDBCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.cntxNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSystemMessage)).EndInit();
            this.grpSystemMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabSystemMessage)).EndInit();
            this.tabSystemMessage.ResumeLayout(false);
            this.tpTrackerManager.ResumeLayout(false);
            this.tpTracker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProject)).EndInit();
            this.grpProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProjectInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatus)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.pnlLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiOPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOPC)).EndInit();
            this.pnlOPC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiAutoControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoringStatus)).EndInit();
            this.pnlMonitoringStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOptraStatus)).EndInit();
            this.pnlOptraStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IndiOptra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHome;
        private DevExpress.XtraBars.BarButtonItem btnManualStart;
        private DevExpress.XtraBars.BarButtonItem btnManualStop;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer tmrAutoRestart;
        private System.Windows.Forms.ContextMenuStrip cntxNotify;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuManualControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuEx;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraEditors.GroupControl grpSystemMessage;
        private UCSystemLogTable ucManagerSystemLogTable;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuAutoControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuLSConfig;
        private DevExpress.XtraBars.BarButtonItem btnReset;
        private DevExpress.XtraBars.BarEditItem dtpkOperStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorOperStart;
        private DevExpress.XtraBars.BarEditItem dtpkOperEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorOperEnd;
        private DevExpress.XtraBars.BarStaticItem lblOperStart;
        private DevExpress.XtraBars.BarStaticItem lblOperEnd;
        private DevExpress.XtraBars.BarStaticItem lblOptraPath;
        private DevExpress.XtraBars.BarEditItem btnExcuteFilePath;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorExecuteFilePath;
        private DevExpress.XtraBars.BarCheckItem chkAutoControlApply;
        private DevExpress.XtraBars.BarButtonItem btnLSOPCOpen;
        private DevExpress.XtraBars.BarButtonItem btnLogicExport;
        private DevExpress.XtraTab.XtraTabControl tabSystemMessage;
        private DevExpress.XtraTab.XtraTabPage tpTrackerManager;
        private DevExpress.XtraTab.XtraTabPage tpTracker;
        private DevExpress.XtraEditors.SplitContainerControl sptMain;
        private DevExpress.XtraEditors.GroupControl grpProject;
        private DevExpress.XtraEditors.GroupControl grpStatus;
        private DevExpress.XtraEditors.SplitterControl sptBottom;
        private UCSystemLogTable ucTrackerSystemLogTable;
        private DevExpress.XtraGrid.GridControl grdProjectInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProjectInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private System.Windows.Forms.TableLayoutPanel pnlLayout;
        private DevExpress.XtraEditors.PanelControl pnlOPC;
        private DevExpress.XtraEditors.PanelControl pnlMonitoringStatus;
        private DevExpress.XtraEditors.PanelControl pnlOptraStatus;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeOptra;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent IndiOptra;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl3;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge4;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent IndiOPC;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent8;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent9;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge3;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent IndiAutoControl;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent4;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent5;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGauge2;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent IndiMonitoring;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent3;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent7;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent2;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent6;
        private System.Windows.Forms.Timer tmrSystemLog;
        private System.Windows.Forms.Timer tmrStartMonitoring;
        private DevExpress.XtraBars.BarButtonItem btnHide;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuDBControl;
        private DevExpress.XtraBars.BarHeaderItem lblDBBackCycle;
        private DevExpress.XtraBars.BarEditItem cmbCBBackCycle;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDBCycle;
        private DevExpress.XtraBars.BarStaticItem lblDB;
        private DevExpress.XtraBars.BarEditItem btnDBFilePath;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Timer tmrAutoDBRecreate;
        private DevExpress.XtraBars.BarCheckItem chkAutoReportExport;
        private System.Windows.Forms.Timer tmrUnkownErrorAction;
    }
}

