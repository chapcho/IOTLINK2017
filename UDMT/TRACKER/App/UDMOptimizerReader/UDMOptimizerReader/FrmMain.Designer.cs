namespace UDMOptimizerReader
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabCollectApp = new DevExpress.XtraTab.XtraTabControl();
            this.chkShowSysLog = new DevExpress.XtraEditors.CheckButton();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnlSystemMessage = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSystemLogTable = new UDMOptimizerReader.UCSystemLogTable();
            this.tmrAutoMode = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpTagSetting = new DevExpress.XtraTab.XtraTabPage();
            this.sptTagSetting = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpSeletedTag = new DevExpress.XtraEditors.GroupControl();
            this.grdUserSelectTag = new DevExpress.XtraGrid.GridControl();
            this.grvUserSelectTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grpAllTag = new DevExpress.XtraEditors.GroupControl();
            this.grdTotalTagS = new DevExpress.XtraGrid.GridControl();
            this.grvTotalTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOPCCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorGroupCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorGroupRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorStepRoleCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tpMain = new DevExpress.XtraTab.XtraTabPage();
            this.grdBitDevice = new DevExpress.XtraGrid.GridControl();
            this.grvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCollectUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorCreatorType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorFeatureType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.exEditorConfigMDC = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.tpSPDSingles = new DevExpress.XtraTab.XtraTabPage();
            this.btnOpenDB = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnDBBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnDBClera = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenLogic = new DevExpress.XtraEditors.SimpleButton();
            this.btnSPDStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnSPDStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadSPD = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUseOnlyInLogic = new System.Windows.Forms.CheckBox();
            this.rbMaria = new System.Windows.Forms.RadioButton();
            this.rbMysql = new System.Windows.Forms.RadioButton();
            this.chkMemory = new System.Windows.Forms.CheckBox();
            this.chkOutput = new System.Windows.Forms.CheckBox();
            this.chkInput = new System.Windows.Forms.CheckBox();
            this.labelComponent7 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveProject = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenProject = new DevExpress.XtraEditors.SimpleButton();
            this.btnAutoCollect = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSendTag = new DevExpress.XtraEditors.SimpleButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelComponent3 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dpnlSystemMessage.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.cntxNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpTagSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptTagSetting)).BeginInit();
            this.sptTagSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSeletedTag)).BeginInit();
            this.grpSeletedTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserSelectTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserSelectTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAllTag)).BeginInit();
            this.grpAllTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).BeginInit();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBitDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).BeginInit();
            this.tpSPDSingles.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent7)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCollectApp
            // 
            this.tabCollectApp.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tabCollectApp.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.tabCollectApp.Appearance.Options.UseFont = true;
            this.tabCollectApp.Appearance.Options.UseForeColor = true;
            this.tabCollectApp.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Italic);
            this.tabCollectApp.AppearancePage.Header.Options.UseFont = true;
            this.tabCollectApp.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Blue;
            this.tabCollectApp.AppearancePage.HeaderActive.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tabCollectApp.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabCollectApp.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabCollectApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCollectApp.Location = new System.Drawing.Point(0, 0);
            this.tabCollectApp.Name = "tabCollectApp";
            this.tabCollectApp.Size = new System.Drawing.Size(1178, 421);
            this.tabCollectApp.TabIndex = 1;
            this.tabCollectApp.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabCollectApp_SelectedPageChanged);
            // 
            // chkShowSysLog
            // 
            this.chkShowSysLog.Checked = true;
            this.chkShowSysLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkShowSysLog.Image = ((System.Drawing.Image)(resources.GetObject("chkShowSysLog.Image")));
            this.chkShowSysLog.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkShowSysLog.Location = new System.Drawing.Point(0, 0);
            this.chkShowSysLog.Name = "chkShowSysLog";
            this.chkShowSysLog.Size = new System.Drawing.Size(73, 76);
            this.chkShowSysLog.TabIndex = 6;
            this.chkShowSysLog.Text = "System\r\nLog";
            this.chkShowSysLog.Visible = false;
            this.chkShowSysLog.CheckedChanged += new System.EventHandler(this.chkShowSysLog_CheckedChanged);
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlSystemMessage});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
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
            // dpnlSystemMessage
            // 
            this.dpnlSystemMessage.Controls.Add(this.dockPanel1_Container);
            this.dpnlSystemMessage.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnlSystemMessage.FloatVertical = true;
            this.dpnlSystemMessage.ID = new System.Guid("a0b72200-b570-4f7e-8159-74d3fa80ac88");
            this.dpnlSystemMessage.Location = new System.Drawing.Point(0, 533);
            this.dpnlSystemMessage.Name = "dpnlSystemMessage";
            this.dpnlSystemMessage.OriginalSize = new System.Drawing.Size(200, 129);
            this.dpnlSystemMessage.Size = new System.Drawing.Size(1518, 129);
            this.dpnlSystemMessage.Text = "System Message";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucSystemLogTable);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1510, 102);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Size = new System.Drawing.Size(1510, 102);
            this.ucSystemLogTable.TabIndex = 7;
            // 
            // tmrAutoMode
            // 
            this.tmrAutoMode.Interval = 2000;
            this.tmrAutoMode.Tick += new System.EventHandler(this.tmrAutoMode_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "SPD Manager";
            this.notifyIcon.ContextMenuStrip = this.cntxNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SPD Manager";
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
            // tabMain
            // 
            this.tabMain.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.tabMain.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.tabMain.Appearance.Options.UseFont = true;
            this.tabMain.Appearance.Options.UseForeColor = true;
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Italic);
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Blue;
            this.tabMain.AppearancePage.HeaderActive.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 76);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpTagSetting;
            this.tabMain.Size = new System.Drawing.Size(1184, 457);
            this.tabMain.TabIndex = 5;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpTagSetting,
            this.tpMain,
            this.tpSPDSingles});
            // 
            // tpTagSetting
            // 
            this.tpTagSetting.Controls.Add(this.sptTagSetting);
            this.tpTagSetting.Name = "tpTagSetting";
            this.tpTagSetting.Size = new System.Drawing.Size(1178, 421);
            this.tpTagSetting.Text = "User Tag 추가";
            // 
            // sptTagSetting
            // 
            this.sptTagSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptTagSetting.Location = new System.Drawing.Point(0, 0);
            this.sptTagSetting.Name = "sptTagSetting";
            this.sptTagSetting.Panel1.Controls.Add(this.grpSeletedTag);
            this.sptTagSetting.Panel1.Text = "Panel1";
            this.sptTagSetting.Panel2.Controls.Add(this.grpAllTag);
            this.sptTagSetting.Panel2.Text = "Panel2";
            this.sptTagSetting.Size = new System.Drawing.Size(1178, 421);
            this.sptTagSetting.SplitterPosition = 498;
            this.sptTagSetting.TabIndex = 0;
            this.sptTagSetting.Text = "splitContainerControl1";
            // 
            // grpSeletedTag
            // 
            this.grpSeletedTag.Controls.Add(this.grdUserSelectTag);
            this.grpSeletedTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSeletedTag.Location = new System.Drawing.Point(0, 0);
            this.grpSeletedTag.Name = "grpSeletedTag";
            this.grpSeletedTag.Size = new System.Drawing.Size(498, 421);
            this.grpSeletedTag.TabIndex = 0;
            this.grpSeletedTag.Text = "Selected Tags";
            // 
            // grdUserSelectTag
            // 
            this.grdUserSelectTag.AllowDrop = true;
            this.grdUserSelectTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserSelectTag.Location = new System.Drawing.Point(2, 21);
            this.grdUserSelectTag.MainView = this.grvUserSelectTag;
            this.grdUserSelectTag.Name = "grdUserSelectTag";
            this.grdUserSelectTag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdUserSelectTag.Size = new System.Drawing.Size(494, 398);
            this.grdUserSelectTag.TabIndex = 9;
            this.grdUserSelectTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserSelectTag});
            this.grdUserSelectTag.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdUserSelectTag_DragDrop);
            this.grdUserSelectTag.DragOver += new System.Windows.Forms.DragEventHandler(this.grdUserSelectTag_DragOver);
            // 
            // grvUserSelectTag
            // 
            this.grvUserSelectTag.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvUserSelectTag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUserSelectTag.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvUserSelectTag.Appearance.Row.Options.UseFont = true;
            this.grvUserSelectTag.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvUserSelectTag.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvUserSelectTag.ColumnPanelRowHeight = 25;
            this.grvUserSelectTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.grvUserSelectTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUserSelectTag.GridControl = this.grdUserSelectTag;
            this.grvUserSelectTag.IndicatorWidth = 50;
            this.grvUserSelectTag.Name = "grvUserSelectTag";
            this.grvUserSelectTag.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUserSelectTag.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvUserSelectTag.OptionsDetail.AllowZoomDetail = false;
            this.grvUserSelectTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvUserSelectTag.OptionsDetail.ShowDetailTabs = false;
            this.grvUserSelectTag.OptionsDetail.SmartDetailExpand = false;
            this.grvUserSelectTag.OptionsSelection.MultiSelect = true;
            this.grvUserSelectTag.OptionsView.EnableAppearanceEvenRow = true;
            this.grvUserSelectTag.OptionsView.ShowGroupPanel = false;
            this.grvUserSelectTag.RowHeight = 25;
            this.grvUserSelectTag.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvUserSelectTag.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvUserSelectTag_CustomDrawRowIndicator);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Address";
            this.gridColumn4.FieldName = "Tag.Address";
            this.gridColumn4.MinWidth = 80;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Comment";
            this.gridColumn5.FieldName = "Tag.Description";
            this.gridColumn5.MinWidth = 200;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 200;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DataType";
            this.gridColumn6.FieldName = "Tag.DataType";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Channel";
            this.gridColumn7.FieldName = "Tag.Channel";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // grpAllTag
            // 
            this.grpAllTag.Controls.Add(this.grdTotalTagS);
            this.grpAllTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAllTag.Location = new System.Drawing.Point(0, 0);
            this.grpAllTag.Name = "grpAllTag";
            this.grpAllTag.Size = new System.Drawing.Size(675, 421);
            this.grpAllTag.TabIndex = 0;
            this.grpAllTag.Text = "All Tags";
            // 
            // grdTotalTagS
            // 
            this.grdTotalTagS.AllowDrop = true;
            this.grdTotalTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdTotalTagS.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdTotalTagS.Location = new System.Drawing.Point(2, 21);
            this.grdTotalTagS.MainView = this.grvTotalTagS;
            this.grdTotalTagS.Name = "grdTotalTagS";
            this.grdTotalTagS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorGroupCombo,
            this.exEditorGroupRoleCombo,
            this.exEditorStepRoleCombo});
            this.grdTotalTagS.Size = new System.Drawing.Size(671, 398);
            this.grdTotalTagS.TabIndex = 2;
            this.grdTotalTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTotalTagS});
            // 
            // grvTotalTagS
            // 
            this.grvTotalTagS.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTotalTagS.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grvTotalTagS.Appearance.Row.Options.UseFont = true;
            this.grvTotalTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.gridColumn1,
            this.colSize,
            this.gridColumn2,
            this.colDescription,
            this.colGroupRoleType,
            this.colStepRoleType,
            this.colCoil,
            this.colUsed,
            this.gridColumn8,
            this.colOPCCheck});
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvTotalTagS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvTotalTagS_CustomDrawRowIndicator);
            this.grvTotalTagS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseDown);
            this.grvTotalTagS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grvTotalTagS_MouseMove);
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
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Address";
            this.gridColumn1.FieldName = "Tag.Address";
            this.gridColumn1.MinWidth = 80;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 141;
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
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "DataType";
            this.gridColumn2.FieldName = "Tag.DataType";
            this.gridColumn2.MinWidth = 100;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 116;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Tag.Description";
            this.colDescription.MinWidth = 100;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 180;
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
            // colCoil
            // 
            this.colCoil.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoil.Caption = "Select";
            this.colCoil.FieldName = "CollectUse";
            this.colCoil.MaxWidth = 60;
            this.colCoil.MinWidth = 60;
            this.colCoil.Name = "colCoil";
            this.colCoil.Visible = true;
            this.colCoil.VisibleIndex = 0;
            this.colCoil.Width = 81;
            // 
            // colUsed
            // 
            this.colUsed.Caption = "Used";
            this.colUsed.FieldName = "Tag.UseOnlyInLogic";
            this.colUsed.MaxWidth = 50;
            this.colUsed.MinWidth = 50;
            this.colUsed.Name = "colUsed";
            this.colUsed.Visible = true;
            this.colUsed.VisibleIndex = 4;
            this.colUsed.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Channel";
            this.gridColumn8.FieldName = "Tag.Channel";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // colOPCCheck
            // 
            this.colOPCCheck.Caption = "OPC";
            this.colOPCCheck.FieldName = "Tag.IsCollectUsed";
            this.colOPCCheck.Name = "colOPCCheck";
            this.colOPCCheck.Visible = true;
            this.colOPCCheck.VisibleIndex = 6;
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
            // tpMain
            // 
            this.tpMain.Controls.Add(this.grdBitDevice);
            this.tpMain.Name = "tpMain";
            this.tpMain.Size = new System.Drawing.Size(1178, 421);
            this.tpMain.Text = "수집 대상";
            // 
            // grdBitDevice
            // 
            this.grdBitDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBitDevice.Location = new System.Drawing.Point(0, 0);
            this.grdBitDevice.MainView = this.grvTag;
            this.grdBitDevice.Name = "grdBitDevice";
            this.grdBitDevice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorCheckBox,
            this.exEditorDataType,
            this.exEditorCreatorType,
            this.exEditorFeatureType,
            this.exEditorConfigMDC});
            this.grdBitDevice.Size = new System.Drawing.Size(1178, 421);
            this.grdBitDevice.TabIndex = 8;
            this.grdBitDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTag});
            // 
            // grvTag
            // 
            this.grvTag.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvTag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTag.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvTag.Appearance.Row.Options.UseFont = true;
            this.grvTag.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.grvTag.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.grvTag.ColumnPanelRowHeight = 50;
            this.grvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colDataType,
            this.colCollectUse,
            this.colCurrentValue,
            this.colChangeCount,
            this.colChannel});
            this.grvTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTag.GridControl = this.grdBitDevice;
            this.grvTag.GroupCount = 1;
            this.grvTag.IndicatorWidth = 50;
            this.grvTag.Name = "grvTag";
            this.grvTag.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvTag.OptionsBehavior.Editable = false;
            this.grvTag.OptionsDetail.AllowZoomDetail = false;
            this.grvTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvTag.OptionsDetail.ShowDetailTabs = false;
            this.grvTag.OptionsDetail.SmartDetailExpand = false;
            this.grvTag.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTag.OptionsView.ShowAutoFilterRow = true;
            this.grvTag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTag.RowHeight = 30;
            this.grvTag.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colChannel, DevExpress.Data.ColumnSortOrder.Ascending),
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
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Tag.Address";
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
            this.colDataType.Caption = "Data Type";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "Tag.DataType";
            this.colDataType.MinWidth = 32;
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 3;
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
            this.colCollectUse.Caption = "수집 가능";
            this.colCollectUse.ColumnEdit = this.exEditorCheckBox;
            this.colCollectUse.FieldName = "CollectUse";
            this.colCollectUse.Name = "colCollectUse";
            this.colCollectUse.OptionsColumn.FixedWidth = true;
            this.colCollectUse.OptionsColumn.ReadOnly = true;
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
            this.colCurrentValue.VisibleIndex = 2;
            this.colCurrentValue.Width = 50;
            // 
            // colChangeCount
            // 
            this.colChangeCount.AppearanceCell.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colChangeCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colChangeCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChangeCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colChangeCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChangeCount.Caption = "Comment";
            this.colChangeCount.FieldName = "Tag.Description";
            this.colChangeCount.MinWidth = 50;
            this.colChangeCount.Name = "colChangeCount";
            this.colChangeCount.OptionsColumn.FixedWidth = true;
            this.colChangeCount.OptionsColumn.ReadOnly = true;
            this.colChangeCount.Visible = true;
            this.colChangeCount.VisibleIndex = 1;
            this.colChangeCount.Width = 300;
            // 
            // colChannel
            // 
            this.colChannel.AppearanceHeader.Options.UseTextOptions = true;
            this.colChannel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannel.Caption = "Channel";
            this.colChannel.FieldName = "Tag.Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 0;
            this.colChannel.Width = 227;
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
            // tpSPDSingles
            // 
            this.tpSPDSingles.Controls.Add(this.tabCollectApp);
            this.tpSPDSingles.Name = "tpSPDSingles";
            this.tpSPDSingles.Size = new System.Drawing.Size(1178, 421);
            this.tpSPDSingles.Text = "SPD View";
            // 
            // btnOpenDB
            // 
            this.btnOpenDB.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenDB.Location = new System.Drawing.Point(88, 0);
            this.btnOpenDB.Name = "btnOpenDB";
            this.btnOpenDB.Size = new System.Drawing.Size(90, 76);
            this.btnOpenDB.TabIndex = 21;
            this.btnOpenDB.Text = "DB Open";
            this.btnOpenDB.Click += new System.EventHandler(this.btnOpenDB_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnDBBackup);
            this.panel7.Controls.Add(this.btnDBClera);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(178, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(105, 76);
            this.panel7.TabIndex = 18;
            // 
            // btnDBBackup
            // 
            this.btnDBBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDBBackup.Location = new System.Drawing.Point(0, 39);
            this.btnDBBackup.Name = "btnDBBackup";
            this.btnDBBackup.Size = new System.Drawing.Size(105, 37);
            this.btnDBBackup.TabIndex = 20;
            this.btnDBBackup.Text = "DB Backup";
            this.btnDBBackup.Click += new System.EventHandler(this.btnDBBackup_Click);
            // 
            // btnDBClera
            // 
            this.btnDBClera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDBClera.Location = new System.Drawing.Point(0, 0);
            this.btnDBClera.Name = "btnDBClera";
            this.btnDBClera.Size = new System.Drawing.Size(105, 39);
            this.btnDBClera.TabIndex = 19;
            this.btnDBClera.Text = "DB Clear";
            this.btnDBClera.Click += new System.EventHandler(this.btnDBClera_Click);
            // 
            // btnOpenLogic
            // 
            this.btnOpenLogic.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenLogic.Location = new System.Drawing.Point(674, 0);
            this.btnOpenLogic.Name = "btnOpenLogic";
            this.btnOpenLogic.Size = new System.Drawing.Size(90, 76);
            this.btnOpenLogic.TabIndex = 17;
            this.btnOpenLogic.Text = "Open\r\nLogicData";
            this.btnOpenLogic.Click += new System.EventHandler(this.btnOpenLogic_Click);
            // 
            // btnSPDStart
            // 
            this.btnSPDStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSPDStart.Location = new System.Drawing.Point(989, 0);
            this.btnSPDStart.Name = "btnSPDStart";
            this.btnSPDStart.Size = new System.Drawing.Size(90, 76);
            this.btnSPDStart.TabIndex = 15;
            this.btnSPDStart.Text = "SPD Start";
            this.btnSPDStart.Click += new System.EventHandler(this.btnSPDStart_Click);
            // 
            // btnSPDStop
            // 
            this.btnSPDStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSPDStop.Enabled = false;
            this.btnSPDStop.Location = new System.Drawing.Point(1094, 0);
            this.btnSPDStop.Name = "btnSPDStop";
            this.btnSPDStop.Size = new System.Drawing.Size(90, 76);
            this.btnSPDStop.TabIndex = 13;
            this.btnSPDStop.Text = "SPD Stop";
            this.btnSPDStop.Click += new System.EventHandler(this.btnSPDStop_Click);
            // 
            // btnLoadSPD
            // 
            this.btnLoadSPD.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoadSPD.Location = new System.Drawing.Point(779, 0);
            this.btnLoadSPD.Name = "btnLoadSPD";
            this.btnLoadSPD.Size = new System.Drawing.Size(90, 76);
            this.btnLoadSPD.TabIndex = 9;
            this.btnLoadSPD.Text = "Load\r\nSPD";
            this.btnLoadSPD.Click += new System.EventHandler(this.btnLoadSPD_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUseOnlyInLogic);
            this.panel1.Controls.Add(this.rbMaria);
            this.panel1.Controls.Add(this.rbMysql);
            this.panel1.Controls.Add(this.chkMemory);
            this.panel1.Controls.Add(this.chkOutput);
            this.panel1.Controls.Add(this.chkInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1184, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 533);
            this.panel1.TabIndex = 7;
            // 
            // chkUseOnlyInLogic
            // 
            this.chkUseOnlyInLogic.AutoSize = true;
            this.chkUseOnlyInLogic.Location = new System.Drawing.Point(33, 399);
            this.chkUseOnlyInLogic.Name = "chkUseOnlyInLogic";
            this.chkUseOnlyInLogic.Size = new System.Drawing.Size(109, 18);
            this.chkUseOnlyInLogic.TabIndex = 12;
            this.chkUseOnlyInLogic.Text = "UseOnlyInLogic";
            this.chkUseOnlyInLogic.UseVisualStyleBackColor = true;
            // 
            // rbMaria
            // 
            this.rbMaria.AutoSize = true;
            this.rbMaria.Location = new System.Drawing.Point(182, 340);
            this.rbMaria.Name = "rbMaria";
            this.rbMaria.Size = new System.Drawing.Size(71, 18);
            this.rbMaria.TabIndex = 11;
            this.rbMaria.Text = "Maria DB";
            this.rbMaria.UseVisualStyleBackColor = true;
            // 
            // rbMysql
            // 
            this.rbMysql.AutoSize = true;
            this.rbMysql.Checked = true;
            this.rbMysql.Location = new System.Drawing.Point(182, 317);
            this.rbMysql.Name = "rbMysql";
            this.rbMysql.Size = new System.Drawing.Size(73, 18);
            this.rbMysql.TabIndex = 10;
            this.rbMysql.TabStop = true;
            this.rbMysql.Text = "Mysql DB";
            this.rbMysql.UseVisualStyleBackColor = true;
            // 
            // chkMemory
            // 
            this.chkMemory.AutoSize = true;
            this.chkMemory.Checked = true;
            this.chkMemory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMemory.Location = new System.Drawing.Point(33, 365);
            this.chkMemory.Name = "chkMemory";
            this.chkMemory.Size = new System.Drawing.Size(69, 18);
            this.chkMemory.TabIndex = 9;
            this.chkMemory.Text = "Memory";
            this.chkMemory.UseVisualStyleBackColor = true;
            // 
            // chkOutput
            // 
            this.chkOutput.AutoSize = true;
            this.chkOutput.Checked = true;
            this.chkOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutput.Location = new System.Drawing.Point(33, 341);
            this.chkOutput.Name = "chkOutput";
            this.chkOutput.Size = new System.Drawing.Size(66, 18);
            this.chkOutput.TabIndex = 8;
            this.chkOutput.Text = "Output";
            this.chkOutput.UseVisualStyleBackColor = true;
            // 
            // chkInput
            // 
            this.chkInput.AutoSize = true;
            this.chkInput.Checked = true;
            this.chkInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInput.Location = new System.Drawing.Point(33, 317);
            this.chkInput.Name = "chkInput";
            this.chkInput.Size = new System.Drawing.Size(56, 18);
            this.chkInput.TabIndex = 7;
            this.chkInput.Text = "Input";
            this.chkInput.UseVisualStyleBackColor = true;
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
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Channel";
            this.gridColumn3.FieldName = "Channel";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 87;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel3);
            this.panel10.Controls.Add(this.btnAutoCollect);
            this.panel10.Controls.Add(this.panel2);
            this.panel10.Controls.Add(this.panel7);
            this.panel10.Controls.Add(this.btnOpenDB);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Controls.Add(this.chkShowSysLog);
            this.panel10.Controls.Add(this.btnOpenLogic);
            this.panel10.Controls.Add(this.panel5);
            this.panel10.Controls.Add(this.btnLoadSPD);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Controls.Add(this.btnSendTag);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.btnSPDStart);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.btnSPDStop);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1184, 76);
            this.panel10.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveProject);
            this.panel3.Controls.Add(this.btnOpenProject);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(388, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 76);
            this.panel3.TabIndex = 25;
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveProject.Location = new System.Drawing.Point(0, 39);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(105, 37);
            this.btnSaveProject.TabIndex = 20;
            this.btnSaveProject.Text = "Save Project";
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenProject.Location = new System.Drawing.Point(0, 0);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(105, 39);
            this.btnOpenProject.TabIndex = 19;
            this.btnOpenProject.Text = "Open Project";
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // btnAutoCollect
            // 
            this.btnAutoCollect.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAutoCollect.Location = new System.Drawing.Point(298, 0);
            this.btnAutoCollect.Name = "btnAutoCollect";
            this.btnAutoCollect.Size = new System.Drawing.Size(90, 76);
            this.btnAutoCollect.TabIndex = 24;
            this.btnAutoCollect.Text = "Auto Mode\r\nSetting";
            this.btnAutoCollect.Click += new System.EventHandler(this.btnAutoCollect_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(283, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 76);
            this.panel2.TabIndex = 23;
            this.panel2.Visible = false;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(73, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(15, 76);
            this.panel13.TabIndex = 20;
            this.panel13.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(764, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(15, 76);
            this.panel5.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(869, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(15, 76);
            this.panel4.TabIndex = 18;
            // 
            // btnSendTag
            // 
            this.btnSendTag.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSendTag.Location = new System.Drawing.Point(884, 0);
            this.btnSendTag.Name = "btnSendTag";
            this.btnSendTag.Size = new System.Drawing.Size(90, 76);
            this.btnSendTag.TabIndex = 17;
            this.btnSendTag.Text = "SendTag";
            this.btnSendTag.Click += new System.EventHandler(this.btnSendTag_Click);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(974, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(15, 76);
            this.panel12.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(1079, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(15, 76);
            this.panel11.TabIndex = 9;
            // 
            // labelComponent3
            // 
            this.labelComponent3.AppearanceText.Font = new System.Drawing.Font("Tahoma", 27F);
            this.labelComponent3.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent3.Name = "stateIndicatorGauge2_Label2";
            this.labelComponent3.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 150F);
            this.labelComponent3.Size = new System.Drawing.SizeF(200F, 50F);
            this.labelComponent3.Text = "Connection";
            this.labelComponent3.ZOrder = -1001;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 662);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dpnlSystemMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "OPT Reader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dpnlSystemMessage.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.cntxNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpTagSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptTagSetting)).EndInit();
            this.sptTagSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSeletedTag)).EndInit();
            this.grpSeletedTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserSelectTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserSelectTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAllTag)).EndInit();
            this.grpAllTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTotalTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorGroupRoleCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleCombo)).EndInit();
            this.tpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBitDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorCreatorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFeatureType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorConfigMDC)).EndInit();
            this.tpSPDSingles.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent7)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabCollectApp;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraEditors.CheckButton chkShowSysLog;
        private DevExpress.XtraBars.Docking.DockPanel dpnlSystemMessage;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private UCSystemLogTable ucSystemLogTable;
        private System.Windows.Forms.Timer tmrAutoMode;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cntxNotify;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpMain;
        private DevExpress.XtraTab.XtraTabPage tpSPDSingles;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent7;
        private DevExpress.XtraEditors.SimpleButton btnLoadSPD;
        private DevExpress.XtraEditors.SimpleButton btnSPDStart;
        private DevExpress.XtraEditors.SimpleButton btnSPDStop;
        private DevExpress.XtraEditors.SimpleButton btnOpenLogic;
        private DevExpress.XtraGrid.GridControl grdBitDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTag;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colCollectUse;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorCheckBox;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorCreatorType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorFeatureType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit exEditorConfigMDC;
        private DevExpress.XtraEditors.SimpleButton btnDBClera;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox chkMemory;
        private System.Windows.Forms.CheckBox chkOutput;
        private System.Windows.Forms.CheckBox chkInput;
        private DevExpress.XtraGrid.Columns.GridColumn colChannel;
        private DevExpress.XtraEditors.SimpleButton btnDBBackup;
        private System.Windows.Forms.RadioButton rbMaria;
        private System.Windows.Forms.RadioButton rbMysql;
        private DevExpress.XtraEditors.SimpleButton btnOpenDB;
        private System.Windows.Forms.CheckBox chkUseOnlyInLogic;
        private DevExpress.XtraTab.XtraTabPage tpTagSetting;
        private DevExpress.XtraEditors.SplitContainerControl sptTagSetting;
        private DevExpress.XtraEditors.GroupControl grpSeletedTag;
        private DevExpress.XtraGrid.GridControl grdUserSelectTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUserSelectTag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.GroupControl grpAllTag;
        private DevExpress.XtraGrid.GridControl grdTotalTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTotalTagS;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colStepRoleType;
        private DevExpress.XtraGrid.Columns.GridColumn colCoil;
        private DevExpress.XtraGrid.Columns.GridColumn colUsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorGroupRoleCombo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleCombo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton btnSendTag;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent3;
        private DevExpress.XtraGrid.Columns.GridColumn colOPCCheck;
        private DevExpress.XtraEditors.SimpleButton btnAutoCollect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnSaveProject;
        private DevExpress.XtraEditors.SimpleButton btnOpenProject;

    }
}

