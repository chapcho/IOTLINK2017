namespace UDMProfiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.btnPLCSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogPathSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenLogPath = new DevExpress.XtraBars.BarButtonItem();
            this.exRibbonGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.chkProjectView = new DevExpress.XtraBars.BarCheckItem();
            this.chkPLCView = new DevExpress.XtraBars.BarCheckItem();
            this.chkSystemMessage = new DevExpress.XtraBars.BarCheckItem();
            this.pgHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuFile = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSetting = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuMonitoring = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuExit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgPLCAnalysis = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuTimeLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuChart = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pgHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tmrSystemLog = new System.Windows.Forms.Timer();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager();
            this.dpnlProject = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucMainTree = new UDMProfiler.UCProjectTree();
            this.dpnlPLC = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.dpnlMessage = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSystemLogTable = new UDMProfiler.UCSystemLogTable();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.dpnlProject.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dpnlPLC.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.dpnlMessage.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.ExpandCollapseItem.Id = 0;
            this.exRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonControl.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnPLCSetting,
            this.btnLogImport,
            this.btnLogPathSetting,
            this.btnOpenLogPath,
            this.exRibbonGallery,
            this.btnExit,
            this.chkProjectView,
            this.chkPLCView,
            this.chkSystemMessage});
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.MaxItemId = 5;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pgHome,
            this.pgPLCAnalysis,
            this.pgHelp});
            this.exRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.exRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.exRibbonControl.ShowCategoryInCaption = false;
            this.exRibbonControl.Size = new System.Drawing.Size(1050, 147);
            this.exRibbonControl.StatusBar = this.ribbonStatusBar;
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
            // btnPLCSetting
            // 
            this.btnPLCSetting.Caption = "PLC Setting";
            this.btnPLCSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnPLCSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPLCSetting.Glyph")));
            this.btnPLCSetting.Id = 5;
            this.btnPLCSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPLCSetting.LargeGlyph")));
            this.btnPLCSetting.Name = "btnPLCSetting";
            this.btnPLCSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPLCSetting_ItemClick);
            // 
            // btnLogImport
            // 
            this.btnLogImport.Caption = "Imoort CSV";
            this.btnLogImport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogImport.Glyph")));
            this.btnLogImport.Id = 6;
            this.btnLogImport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogImport.LargeGlyph")));
            this.btnLogImport.Name = "btnLogImport";
            this.btnLogImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogImport_ItemClick);
            // 
            // btnLogPathSetting
            // 
            this.btnLogPathSetting.Caption = "Log Path Setting";
            this.btnLogPathSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnLogPathSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogPathSetting.Glyph")));
            this.btnLogPathSetting.Id = 7;
            this.btnLogPathSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogPathSetting.LargeGlyph")));
            this.btnLogPathSetting.Name = "btnLogPathSetting";
            // 
            // btnOpenLogPath
            // 
            this.btnOpenLogPath.Caption = "Open Log Path";
            this.btnOpenLogPath.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnOpenLogPath.Glyph = ((System.Drawing.Image)(resources.GetObject("btnOpenLogPath.Glyph")));
            this.btnOpenLogPath.Id = 8;
            this.btnOpenLogPath.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnOpenLogPath.LargeGlyph")));
            this.btnOpenLogPath.Name = "btnOpenLogPath";
            // 
            // exRibbonGallery
            // 
            this.exRibbonGallery.Caption = "Skin";
            this.exRibbonGallery.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.exRibbonGallery.Id = 12;
            this.exRibbonGallery.Name = "exRibbonGallery";
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 13;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // chkProjectView
            // 
            this.chkProjectView.BindableChecked = true;
            this.chkProjectView.Caption = "Project Information";
            this.chkProjectView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkProjectView.Checked = true;
            this.chkProjectView.Id = 2;
            this.chkProjectView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkProjectView.LargeGlyph")));
            this.chkProjectView.Name = "chkProjectView";
            this.chkProjectView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkProjectView_CheckedChanged);
            // 
            // chkPLCView
            // 
            this.chkPLCView.BindableChecked = true;
            this.chkPLCView.Caption = "PLC\r\nInformation";
            this.chkPLCView.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkPLCView.Checked = true;
            this.chkPLCView.Id = 3;
            this.chkPLCView.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkPLCView.LargeGlyph")));
            this.chkPLCView.Name = "chkPLCView";
            this.chkPLCView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkPLCView_CheckedChanged);
            // 
            // chkSystemMessage
            // 
            this.chkSystemMessage.BindableChecked = true;
            this.chkSystemMessage.Caption = "System Message";
            this.chkSystemMessage.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.chkSystemMessage.Checked = true;
            this.chkSystemMessage.Id = 4;
            this.chkSystemMessage.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("chkSystemMessage.LargeGlyph")));
            this.chkSystemMessage.Name = "chkSystemMessage";
            this.chkSystemMessage.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.chkSystemMessage_CheckedChanged);
            // 
            // pgHome
            // 
            this.pgHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuFile,
            this.mnuSetting,
            this.mnuMonitoring,
            this.mnuView,
            this.mnuSkins,
            this.mnuExit});
            this.pgHome.Name = "pgHome";
            this.pgHome.Text = "Home";
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
            // mnuSetting
            // 
            this.mnuSetting.ItemLinks.Add(this.btnPLCSetting);
            this.mnuSetting.ItemLinks.Add(this.btnLogPathSetting);
            this.mnuSetting.ItemLinks.Add(this.btnOpenLogPath);
            this.mnuSetting.Name = "mnuSetting";
            this.mnuSetting.Text = "Setting";
            // 
            // mnuMonitoring
            // 
            this.mnuMonitoring.Name = "mnuMonitoring";
            this.mnuMonitoring.Text = "Monitoring";
            // 
            // mnuView
            // 
            this.mnuView.ItemLinks.Add(this.chkProjectView);
            this.mnuView.ItemLinks.Add(this.chkPLCView);
            this.mnuView.ItemLinks.Add(this.chkSystemMessage);
            this.mnuView.Name = "mnuView";
            this.mnuView.Text = "View";
            // 
            // mnuSkins
            // 
            this.mnuSkins.ItemLinks.Add(this.exRibbonGallery);
            this.mnuSkins.Name = "mnuSkins";
            this.mnuSkins.Text = "Skins";
            // 
            // mnuExit
            // 
            this.mnuExit.ItemLinks.Add(this.btnExit);
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            // 
            // pgPLCAnalysis
            // 
            this.pgPLCAnalysis.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuTimeLog,
            this.mnuChart});
            this.pgPLCAnalysis.Name = "pgPLCAnalysis";
            this.pgPLCAnalysis.Text = "PLC Analysis";
            // 
            // mnuTimeLog
            // 
            this.mnuTimeLog.ItemLinks.Add(this.btnLogImport);
            this.mnuTimeLog.Name = "mnuTimeLog";
            this.mnuTimeLog.Text = "Log";
            // 
            // mnuChart
            // 
            this.mnuChart.Name = "mnuChart";
            this.mnuChart.Text = "Chart";
            // 
            // pgHelp
            // 
            this.pgHelp.Name = "pgHelp";
            this.pgHelp.Text = "Help";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style13;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 733);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.exRibbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1050, 31);
            // 
            // tmrSystemLog
            // 
            this.tmrSystemLog.Interval = 3600000;
            this.tmrSystemLog.Tick += new System.EventHandler(this.tmrSystemLog_Tick);
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlProject,
            this.dpnlPLC,
            this.dpnlMessage});
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
            // dpnlProject
            // 
            this.dpnlProject.Controls.Add(this.dockPanel1_Container);
            this.dpnlProject.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnlProject.ID = new System.Guid("c2020e96-633e-42e2-afcc-66b27b3a2f54");
            this.dpnlProject.Location = new System.Drawing.Point(0, 147);
            this.dpnlProject.Name = "dpnlProject";
            this.dpnlProject.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnlProject.Size = new System.Drawing.Size(200, 586);
            this.dpnlProject.Text = "프로젝트 정보";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucMainTree);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 559);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucMainTree
            // 
            this.ucMainTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMainTree.Location = new System.Drawing.Point(0, 0);
            this.ucMainTree.Name = "ucMainTree";
            this.ucMainTree.Size = new System.Drawing.Size(192, 559);
            this.ucMainTree.TabIndex = 0;
            // 
            // dpnlPLC
            // 
            this.dpnlPLC.Controls.Add(this.dockPanel2_Container);
            this.dpnlPLC.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dpnlPLC.ID = new System.Guid("22391491-9a85-4db8-b04b-de644f20c8c0");
            this.dpnlPLC.Location = new System.Drawing.Point(200, 147);
            this.dpnlPLC.Name = "dpnlPLC";
            this.dpnlPLC.OriginalSize = new System.Drawing.Size(200, 400);
            this.dpnlPLC.Size = new System.Drawing.Size(850, 400);
            this.dpnlPLC.Text = "PLC 정보";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.tabMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(842, 373);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(842, 373);
            this.tabMain.TabIndex = 0;
            // 
            // dpnlMessage
            // 
            this.dpnlMessage.Controls.Add(this.dockPanel3_Container);
            this.dpnlMessage.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnlMessage.ID = new System.Guid("295862d2-58f1-484a-a22c-e0e097d0d093");
            this.dpnlMessage.Location = new System.Drawing.Point(200, 598);
            this.dpnlMessage.Name = "dpnlMessage";
            this.dpnlMessage.OriginalSize = new System.Drawing.Size(200, 135);
            this.dpnlMessage.Size = new System.Drawing.Size(850, 135);
            this.dpnlMessage.Text = "System Message";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.ucSystemLogTable);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(842, 108);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Size = new System.Drawing.Size(842, 108);
            this.ucSystemLogTable.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 764);
            this.Controls.Add(this.dpnlMessage);
            this.Controls.Add(this.dpnlPLC);
            this.Controls.Add(this.dpnlProject);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.exRibbonControl);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.dpnlProject.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dpnlPLC.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.dpnlMessage.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHome;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgPLCAnalysis;
        private DevExpress.XtraBars.Ribbon.RibbonPage pgHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuFile;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.BarButtonItem btnPLCSetting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSetting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuMonitoring;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkins;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuExit;
        private System.Windows.Forms.Timer tmrSystemLog;
        private DevExpress.XtraBars.BarButtonItem btnLogImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuTimeLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuChart;
        private DevExpress.XtraBars.Docking.DockManager exDockManager;
        private DevExpress.XtraBars.Docking.DockPanel dpnlMessage;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpnlPLC;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpnlProject;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private UCSystemLogTable ucSystemLogTable;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private UCProjectTree ucMainTree;
        private DevExpress.XtraBars.BarButtonItem btnLogPathSetting;
        private DevExpress.XtraBars.BarButtonItem btnOpenLogPath;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem exRibbonGallery;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarCheckItem chkProjectView;
        private DevExpress.XtraBars.BarCheckItem chkPLCView;
        private DevExpress.XtraBars.BarCheckItem chkSystemMessage;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

    }
}