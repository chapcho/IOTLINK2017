namespace UEnergyDaqServer
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
            this.exRibbonMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lstSmallImage = new DevExpress.Utils.ImageCollection(this.components);
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.exSkinGallery = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStop = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.btnSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarButtonItem();
            this.lstLargeImage = new DevExpress.Utils.ImageCollection(this.components);
            this.mnuHome = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mnuProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuControl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mnuConfigSetting = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.exDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.pnlConfigShow = new System.Windows.Forms.Panel();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.pnlDataView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSmallImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLargeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.pnlConfigShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // exRibbonMenu
            // 
            this.exRibbonMenu.ExpandCollapseItem.Id = 0;
            this.exRibbonMenu.Images = this.lstSmallImage;
            this.exRibbonMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exRibbonMenu.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.exSkinGallery,
            this.btnStart,
            this.btnStop,
            this.btnExit,
            this.lblStatus,
            this.btnSetting,
            this.btnShow});
            this.exRibbonMenu.LargeImages = this.lstLargeImage;
            this.exRibbonMenu.Location = new System.Drawing.Point(0, 0);
            this.exRibbonMenu.MaxItemId = 4;
            this.exRibbonMenu.Name = "exRibbonMenu";
            this.exRibbonMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mnuHome});
            this.exRibbonMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.exRibbonMenu.Size = new System.Drawing.Size(884, 147);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnNew);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnOpen);
            this.exRibbonMenu.Toolbar.ItemLinks.Add(this.btnSave);
            // 
            // lstSmallImage
            // 
            this.lstSmallImage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("lstSmallImage.ImageStream")));
            this.lstSmallImage.Images.SetKeyName(0, "New_16x16.png");
            this.lstSmallImage.Images.SetKeyName(1, "Open_16x16.png");
            this.lstSmallImage.Images.SetKeyName(2, "Save_16x16.png");
            this.lstSmallImage.Images.SetKeyName(3, "SaveAs_16x16.png");
            // 
            // btnNew
            // 
            this.btnNew.Caption = "New";
            this.btnNew.Id = 1;
            this.btnNew.ImageIndex = 0;
            this.btnNew.LargeImageIndex = 0;
            this.btnNew.Name = "btnNew";
            this.btnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNew_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Open";
            this.btnOpen.Id = 2;
            this.btnOpen.ImageIndex = 1;
            this.btnOpen.LargeImageIndex = 1;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 3;
            this.btnSave.ImageIndex = 2;
            this.btnSave.LargeImageIndex = 2;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "SaveAs";
            this.btnSaveAs.Id = 4;
            this.btnSaveAs.LargeImageIndex = 3;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // exSkinGallery
            // 
            this.exSkinGallery.Caption = "Skin";
            this.exSkinGallery.Id = 5;
            this.exSkinGallery.Name = "exSkinGallery";
            // 
            // btnStart
            // 
            this.btnStart.Caption = "Start";
            this.btnStart.Id = 6;
            this.btnStart.LargeImageIndex = 4;
            this.btnStart.Name = "btnStart";
            this.btnStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStart_ItemClick);
            // 
            // btnStop
            // 
            this.btnStop.Caption = "Stop";
            this.btnStop.Id = 7;
            this.btnStop.LargeImageIndex = 5;
            this.btnStop.Name = "btnStop";
            this.btnStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStop_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 8;
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // lblStatus
            // 
            this.lblStatus.Caption = "Ready";
            this.lblStatus.Id = 10;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "Setting";
            this.btnSetting.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSetting.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSetting.Glyph")));
            this.btnSetting.Id = 1;
            this.btnSetting.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSetting.LargeGlyph")));
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetting_ItemClick);
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnShow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShow.Glyph")));
            this.btnShow.Id = 3;
            this.btnShow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShow.LargeGlyph")));
            this.btnShow.Name = "btnShow";
            this.btnShow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShow_ItemClick);
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
            // 
            // mnuHome
            // 
            this.mnuHome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mnuProject,
            this.mnuSkin,
            this.mnuControl,
            this.mnuConfigSetting});
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
            this.mnuControl.ItemLinks.Add(this.btnExit);
            this.mnuControl.Name = "mnuControl";
            this.mnuControl.Text = "Control";
            // 
            // mnuConfigSetting
            // 
            this.mnuConfigSetting.ItemLinks.Add(this.btnSetting);
            this.mnuConfigSetting.ItemLinks.Add(this.btnShow);
            this.mnuConfigSetting.Name = "mnuConfigSetting";
            this.mnuConfigSetting.Text = "Config Setting";
            // 
            // exDockManager
            // 
            this.exDockManager.Form = this;
            this.exDockManager.MenuManager = this.barManager2;
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
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.exDockManager;
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 554);
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 554);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 554);
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.DockManager = this.exDockManager;
            this.barManager2.Form = this;
            this.barManager2.MaxItemId = 0;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 554);
            this.barDockControl2.Size = new System.Drawing.Size(884, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 554);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(884, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 554);
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Location = new System.Drawing.Point(0, 0);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Ribbon = this.exRibbonMenu;
            this.popupControlContainer1.Size = new System.Drawing.Size(250, 130);
            this.popupControlContainer1.TabIndex = 10;
            this.popupControlContainer1.Visible = false;
            // 
            // pnlConfigShow
            // 
            this.pnlConfigShow.Controls.Add(this.treeList1);
            this.pnlConfigShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConfigShow.Location = new System.Drawing.Point(0, 147);
            this.pnlConfigShow.Name = "pnlConfigShow";
            this.pnlConfigShow.Padding = new System.Windows.Forms.Padding(3);
            this.pnlConfigShow.Size = new System.Drawing.Size(172, 407);
            this.pnlConfigShow.TabIndex = 19;
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(3, 3);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(166, 401);
            this.treeList1.TabIndex = 0;
            // 
            // pnlDataView
            // 
            this.pnlDataView.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDataView.Location = new System.Drawing.Point(172, 147);
            this.pnlDataView.Name = "pnlDataView";
            this.pnlDataView.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDataView.Size = new System.Drawing.Size(712, 407);
            this.pnlDataView.TabIndex = 20;
            // 
            // FrmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 554);
            this.Controls.Add(this.pnlDataView);
            this.Controls.Add(this.pnlConfigShow);
            this.Controls.Add(this.exRibbonMenu);
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "FrmMain";
            this.Ribbon = this.exRibbonMenu;
            this.Text = "UDM Energy Daq. Server V1.0";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exRibbonMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstSmallImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLargeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.pnlConfigShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl exRibbonMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage mnuHome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuProject;
        private DevExpress.Utils.ImageCollection lstSmallImage;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAs;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem exSkinGallery;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStop;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.Utils.ImageCollection lstLargeImage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuSkin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuControl;
        private DevExpress.XtraBars.Docking.DockManager exDockManager;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem btnSetting;
        private DevExpress.XtraBars.BarButtonItem btnShow;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mnuConfigSetting;
        private System.Windows.Forms.Panel pnlDataView;
        private System.Windows.Forms.Panel pnlConfigShow;
        private DevExpress.XtraTreeList.TreeList treeList1;
    }
}

