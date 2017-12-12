namespace NewIOMaker.Form.Form_TagGenerator
{
    partial class TagMain
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
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.pageGroup1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup(this.components);
            this.flyout1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.TagMainMenu = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.navigationHome = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPLC = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationHMI = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationTool = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyout1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.TagMainMenu.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.pageGroup1,
            this.flyout1});
            // 
            // pageGroup1
            // 
            this.pageGroup1.Name = "pageGroup1";
            // 
            // flyout1
            // 
            this.flyout1.Name = "flyout1";
            this.flyout1.Properties.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.flyout1.Properties.Appearance.Options.UseBackColor = true;
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
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
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.hideContainerLeft.Controls.Add(this.panelContainer1);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(36, 668);
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPanel1;
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Controls.Add(this.dockPanel3);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.FloatSize = new System.Drawing.Size(581, 537);
            this.panelContainer1.ID = new System.Guid("09414a0b-a6ba-42b2-9443-23cfe10d251f");
            this.panelContainer1.Location = new System.Drawing.Point(36, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(436, 200);
            this.panelContainer1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.SavedIndex = 0;
            this.panelContainer1.Size = new System.Drawing.Size(436, 668);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            this.panelContainer1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Close", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.FloatSize = new System.Drawing.Size(581, 537);
            this.dockPanel1.ID = new System.Guid("cad9c5ab-67f5-44c8-ab3b-66aa00b2cbea");
            this.dockPanel1.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(430, 637);
            this.dockPanel1.Size = new System.Drawing.Size(430, 639);
            this.dockPanel1.Text = "Main Menu";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.TagMainMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(430, 639);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // TagMainMenu
            // 
            this.TagMainMenu.Controls.Add(this.navigationHome);
            this.TagMainMenu.Controls.Add(this.navigationPLC);
            this.TagMainMenu.Controls.Add(this.navigationHMI);
            this.TagMainMenu.Controls.Add(this.navigationTool);
            this.TagMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagMainMenu.Location = new System.Drawing.Point(0, 0);
            this.TagMainMenu.Name = "TagMainMenu";
            this.TagMainMenu.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPage[] {
            this.navigationHome,
            this.navigationPLC,
            this.navigationHMI,
            this.navigationTool});
            this.TagMainMenu.RegularSize = new System.Drawing.Size(430, 639);
            this.TagMainMenu.SelectedPage = this.navigationHome;
            this.TagMainMenu.SelectedPageIndex = 0;
            this.TagMainMenu.Size = new System.Drawing.Size(430, 639);
            this.TagMainMenu.TabIndex = 0;
            this.TagMainMenu.Text = "Home";
            // 
            // navigationHome
            // 
            this.navigationHome.Caption = "Home";
            this.navigationHome.Name = "navigationHome";
            this.navigationHome.Size = new System.Drawing.Size(367, 578);
            // 
            // navigationPLC
            // 
            this.navigationPLC.Caption = "PLC";
            this.navigationPLC.Name = "navigationPLC";
            this.navigationPLC.Size = new System.Drawing.Size(367, 578);
            // 
            // navigationHMI
            // 
            this.navigationHMI.Caption = "HMI";
            this.navigationHMI.Name = "navigationHMI";
            this.navigationHMI.Size = new System.Drawing.Size(367, 578);
            // 
            // navigationTool
            // 
            this.navigationTool.Caption = "Tool";
            this.navigationTool.Name = "navigationTool";
            this.navigationTool.Size = new System.Drawing.Size(367, 578);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Close", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.FloatSize = new System.Drawing.Size(581, 537);
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("43915397-dd66-4107-86b0-8d9c0a899805");
            this.dockPanel2.Location = new System.Drawing.Point(3, 26);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(430, 637);
            this.dockPanel2.Size = new System.Drawing.Size(430, 639);
            this.dockPanel2.Text = "Alarm";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(430, 639);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Close", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel3.FloatSize = new System.Drawing.Size(581, 537);
            this.dockPanel3.FloatVertical = true;
            this.dockPanel3.ID = new System.Guid("b637ee90-5332-4e54-ae0a-a207a75f5ea7");
            this.dockPanel3.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(430, 637);
            this.dockPanel3.Size = new System.Drawing.Size(430, 639);
            this.dockPanel3.Text = "Log";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(430, 639);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // TagMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.hideContainerLeft);
            this.Name = "TagMain";
            this.Size = new System.Drawing.Size(949, 668);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyout1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.TagMainMenu.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Navigation.NavigationPane TagMainMenu;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.PageGroup pageGroup1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Flyout flyout1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationHome;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPLC;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationHMI;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationTool;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
    }
}
