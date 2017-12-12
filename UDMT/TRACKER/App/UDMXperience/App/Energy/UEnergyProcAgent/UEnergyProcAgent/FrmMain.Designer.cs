namespace UEnergyProcAgent
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
            this.exRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lstSmallImage = new DevExpress.Utils.ImageCollection(this.components);
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.exSkinGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.lstLargeImage = new DevExpress.Utils.ImageCollection(this.components);
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnlProjectView = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlServerInfoContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucProjectView = new UEnergyProcAgent.UCProjectTreeView();
            this.exDocManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dpnlConfig = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnlConfigContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSmallImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLargeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            this.dpnlProjectView.SuspendLayout();
            this.dpnlServerInfoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exDocManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.dpnlConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // exRibbonControl
            // 
            this.exRibbonControl.ExpandCollapseItem.Id = 0;
            this.exRibbonControl.Images = this.lstSmallImage;
            this.exRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonControl.ExpandCollapseItem,
            this.lblStatus,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.exSkinGallery,
            this.btnStart,
            this.btnStop,
            this.btnExit});
            this.exRibbonControl.LargeImages = this.lstLargeImage;
            this.exRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.exRibbonControl.MaxItemId = 11;
            this.exRibbonControl.Name = "exRibbonControl";
            this.exRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome});
            this.exRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonControl.Size = new System.Drawing.Size(884, 147);
            this.exRibbonControl.StatusBar = this.exStatusBar;
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonControl.Toolbar.ItemLinks.Add(this.btnSave);
            // 
            // lstSmallImage
            // 
            this.lstSmallImage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("lstSmallImage.ImageStream")));
            this.lstSmallImage.Images.SetKeyName(0, "New_16x16.png");
            this.lstSmallImage.Images.SetKeyName(1, "Open_16x16.png");
            this.lstSmallImage.Images.SetKeyName(2, "Save_16x16.png");
            this.lstSmallImage.Images.SetKeyName(3, "SaveAs_16x16.png");
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 1;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 2;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Id = 3;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.LargeImageIndex = 1;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 4;
            this.btnSave.ImageIndex = 2;
            this.btnSave.LargeImageIndex = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "SaveAs";
            this.btnSaveAs.Id = 5;
            this.btnSaveAs.LargeImageIndex = 3;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // exSkinGallery
            // 
            this.exSkinGallery.Caption = "skinRibbonGalleryBarItem1";
            this.exSkinGallery.Id = 6;
            this.exSkinGallery.Name = "exSkinGallery";
            // 
            // btnStart
            // 
            this.btnStart.Caption = "Start";
            this.btnStart.Id = 7;
            this.btnStart.LargeImageIndex = 4;
            this.btnStart.Name = "btnStart";
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "Stop";
            this.btnStop.Id = 8;
            this.btnStop.LargeImageIndex = 5;
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 9;
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // lstLargeImage
            // 
            this.lstLargeImage.ImageSize = new System.Drawing.Size(32, 32);
            this.lstLargeImage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("lstLargeImage.ImageStream")));
            this.lstLargeImage.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.lstLargeImage.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.lstLargeImage.Images.SetKeyName(2, "Ribbon_Save_32x32.png");
            this.lstLargeImage.Images.SetKeyName(3, "Ribbon_SaveAs_32x32.png");
            this.lstLargeImage.Images.SetKeyName(4, "Next_32x32.png");
            this.lstLargeImage.Images.SetKeyName(5, "Pause_32x32.png");
            this.lstLargeImage.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.lstLargeImage.Images.SetKeyName(7, "Technology_32x32.png");
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuProject,
            this.mnuSkin,
            this.mnuControl});
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Text = "Home";
            // 
            // mnuProject
            // 
            this.mnuProject.ItemLinks.Add(this.btnNew);
            this.mnuProject.ItemLinks.Add(this.btnOpen);
            this.mnuProject.ItemLinks.Add(this.btnSave);
            this.mnuProject.ItemLinks.Add(this.btnSaveAs);
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Text = "Project";
            // 
            // mnuSkin
            // 
            this.mnuSkin.ItemLinks.Add(this.exSkinGallery);
            this.mnuSkin.Name = "mnuSkin";
            this.mnuSkin.Text = "Skin";
            // 
            // mnuControl
            // 
            this.mnuControl.ItemLinks.Add(this.btnStart);
            this.mnuControl.ItemLinks.Add(this.btnStop);
            this.mnuControl.ItemLinks.Add(this.btnExit, true);
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Text = "Control";
            // 
            // exStatusBar
            // 
            this.exStatusBar.ItemLinks.Add(this.lblStatus);
            this.exStatusBar.Location = new System.Drawing.Point(0, 490);
            this.exStatusBar.Name = "exStatusBar";
            this.exStatusBar.Ribbon = this.exRibbonControl;
            this.exStatusBar.Size = new System.Drawing.Size(884, 31);
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlConfig});
            this.exDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnlProjectView});
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
            // dpnlProjectView
            // 
            this.dpnlProjectView.Controls.Add(this.dpnlServerInfoContainer);
            this.dpnlProjectView.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnlProjectView.ID = new System.Guid("07ca93e8-dd48-4a71-ba3f-d04599060a68");
            this.dpnlProjectView.Location = new System.Drawing.Point(0, 147);
            this.dpnlProjectView.Name = "dpnlProjectView";
            this.dpnlProjectView.OriginalSize = new System.Drawing.Size(263, 200);
            this.dpnlProjectView.Size = new System.Drawing.Size(263, 343);
            this.dpnlProjectView.Text = "Project View";
            // 
            // dpnlServerInfoContainer
            // 
            this.dpnlServerInfoContainer.Controls.Add(this.ucProjectView);
            this.dpnlServerInfoContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlServerInfoContainer.Name = "dpnlServerInfoContainer";
            this.dpnlServerInfoContainer.Size = new System.Drawing.Size(255, 316);
            this.dpnlServerInfoContainer.TabIndex = 0;
            // 
            // ucProjectView
            // 
            this.ucProjectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProjectView.IsEditable = true;
            this.ucProjectView.Location = new System.Drawing.Point(0, 0);
            this.ucProjectView.Name = "ucProjectView";
            this.ucProjectView.Project = null;
            this.ucProjectView.Size = new System.Drawing.Size(255, 316);
            this.ucProjectView.TabIndex = 0;
            // 
            // exDocManager
            // 
            this.exDocManager.ContainerControl = this;
            this.exDocManager.MenuManager = this.exRibbonControl;
            this.exDocManager.View = this.tabbedView1;
            this.exDocManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // dpnlConfig
            // 
            this.dpnlConfig.Controls.Add(this.dpnlConfigContainer);
            this.dpnlConfig.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnlConfig.ID = new System.Guid("fbbb1575-2011-4b01-bbe1-4d8c479d73a3");
            this.dpnlConfig.Location = new System.Drawing.Point(263, 147);
            this.dpnlConfig.Name = "dpnlConfig";
            this.dpnlConfig.OriginalSize = new System.Drawing.Size(301, 200);
            this.dpnlConfig.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnlConfig.SavedIndex = 1;
            this.dpnlConfig.Size = new System.Drawing.Size(301, 343);
            this.dpnlConfig.Text = "Config";
            this.dpnlConfig.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dpnlConfigContainer
            // 
            this.dpnlConfigContainer.Location = new System.Drawing.Point(4, 23);
            this.dpnlConfigContainer.Name = "dpnlConfigContainer";
            this.dpnlConfigContainer.Size = new System.Drawing.Size(293, 316);
            this.dpnlConfigContainer.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 521);
            this.Controls.Add(this.dpnlProjectView);
            this.Controls.Add(this.exStatusBar);
            this.Controls.Add(this.exRibbonControl);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonControl;
            this.StatusBar = this.exStatusBar;
            this.Text = "UDM Energy Data Processing Agent V1.0";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSmallImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLargeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            this.dpnlProjectView.ResumeLayout(false);
            this.dpnlServerInfoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exDocManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.dpnlConfig.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuProject;
        private DevExpress.Utils.ImageCollection lstSmallImage;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.Utils.ImageCollection lstLargeImage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar exStatusBar;
        private DevExpress.XtraBars.Docking.DockManager exDockManager;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem exSkinGallery;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Docking.DockPanel dpnlProjectView;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlServerInfoContainer;
        private DevExpress.XtraBars.Docking2010.DocumentManager exDocManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private UCProjectTreeView ucProjectView;
        private DevExpress.XtraBars.Docking.DockPanel dpnlConfig;
        private DevExpress.XtraBars.Docking.ControlContainer dpnlConfigContainer;
    }
}

