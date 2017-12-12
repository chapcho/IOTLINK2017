namespace UDMTrackerSimple
{
    partial class UCFlowChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFlowChart));
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockProcess = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucAlarm = new UDMTrackerSimple.UCErrorAlarmView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockProcess.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockProcess});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.controlContainer1);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel1.DockedAsTabbedDocument = true;
            this.dockPanel1.FloatLocation = new System.Drawing.Point(2469, 417);
            this.dockPanel1.ID = new System.Guid("24233420-8b8a-4ec6-98e2-6053471d4588");
            this.dockPanel1.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedIndex = 1;
            this.dockPanel1.SavedMdiDocument = true;
            this.dockPanel1.Size = new System.Drawing.Size(289, 603);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(289, 603);
            this.controlContainer1.TabIndex = 0;
            // 
            // dockProcess
            // 
            this.dockProcess.Appearance.BackColor = System.Drawing.Color.White;
            this.dockProcess.Appearance.Options.UseBackColor = true;
            this.dockProcess.Controls.Add(this.dockPanel1_Container);
            this.dockProcess.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockProcess.ID = new System.Guid("22e970b5-75c4-431a-9d09-c223d106b1c0");
            this.dockProcess.Location = new System.Drawing.Point(0, 0);
            this.dockProcess.Name = "dockProcess";
            this.dockProcess.Options.AllowDockAsTabbedDocument = false;
            this.dockProcess.Options.AllowDockBottom = false;
            this.dockProcess.Options.AllowDockFill = false;
            this.dockProcess.Options.AllowDockTop = false;
            this.dockProcess.Options.AllowFloating = false;
            this.dockProcess.Options.FloatOnDblClick = false;
            this.dockProcess.Options.ShowCloseButton = false;
            this.dockProcess.Options.ShowMaximizeButton = false;
            this.dockProcess.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockProcess.Size = new System.Drawing.Size(200, 634);
            this.dockProcess.Text = "Process Status";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucAlarm);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 607);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucAlarm
            // 
            this.ucAlarm.AutoScroll = true;
            this.ucAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAlarm.Location = new System.Drawing.Point(0, 0);
            this.ucAlarm.Name = "ucAlarm";
            this.ucAlarm.Size = new System.Drawing.Size(192, 607);
            this.ucAlarm.TabIndex = 0;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(3, "ContentArrangeInRows_16x16.png");
            this.imgList.Images.SetKeyName(4, "Windows_16x16.png");
            // 
            // docManager
            // 
            this.docManager.ContainerControl = this;
            this.docManager.View = this.tabView;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabView});
            // 
            // tabView
            // 
            this.tabView.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.Header.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderSelected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderSelected.Options.UseFont = true;
            this.tabView.DocumentGroupProperties.ShowDocumentSelectorButton = false;
            this.tabView.DocumentProperties.AllowClose = false;
            this.tabView.DocumentProperties.AllowFloat = false;
            this.tabView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.tabView.WindowsDialogProperties.NameColumnWidth = 5;
            this.tabView.WindowsDialogProperties.PathColumnWidth = 5;
            this.tabView.WindowsDialogProperties.Size = new System.Drawing.Size(400, 300);
            // 
            // UCFlowChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockProcess);
            this.Name = "UCFlowChart";
            this.Size = new System.Drawing.Size(1073, 634);
            this.Load += new System.EventHandler(this.UCFlowChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockProcess.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockProcess;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabView;
        private System.Windows.Forms.ImageList imgList;
        private UCErrorAlarmView ucAlarm;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;



    }
}
