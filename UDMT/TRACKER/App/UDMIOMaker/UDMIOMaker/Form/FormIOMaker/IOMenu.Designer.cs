namespace NewIOMaker.Form.Form_IOMaker
{
    partial class IOMenu
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.IOGriddockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ExcelViewer = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.dockPanel2Document = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.IOGriddockPanel.SuspendLayout();
            this.ExcelViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel2Document)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.IOGriddockPanel,
            this.ExcelViewer});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.controlContainer1);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("5e01f55c-b388-4074-9015-40c72ae5bc2c");
            this.dockPanel1.Location = new System.Drawing.Point(738, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 542);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(3, 26);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(194, 514);
            this.controlContainer1.TabIndex = 0;
            // 
            // IOGriddockPanel
            // 
            this.IOGriddockPanel.Controls.Add(this.dockPanel1_Container);
            this.IOGriddockPanel.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Close", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.IOGriddockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.IOGriddockPanel.ID = new System.Guid("68224322-319a-4f58-91ad-b5cff1fe6522");
            this.IOGriddockPanel.Location = new System.Drawing.Point(0, 0);
            this.IOGriddockPanel.Name = "IOGriddockPanel";
            this.IOGriddockPanel.OriginalSize = new System.Drawing.Size(628, 200);
            this.IOGriddockPanel.Size = new System.Drawing.Size(628, 542);
            this.IOGriddockPanel.Text = "IO Grid Viewer";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 29);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(622, 511);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ExcelViewer
            // 
            this.ExcelViewer.Controls.Add(this.dockPanel2_Container);
            this.ExcelViewer.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.ExcelViewer.DockedAsTabbedDocument = true;
            this.ExcelViewer.ID = new System.Guid("471cca04-244b-4f8b-ba38-8e1214d9b529");
            this.ExcelViewer.Location = new System.Drawing.Point(0, 0);
            this.ExcelViewer.Name = "ExcelViewer";
            this.ExcelViewer.OriginalSize = new System.Drawing.Size(200, 200);
            this.ExcelViewer.Size = new System.Drawing.Size(302, 512);
            this.ExcelViewer.Text = "Excel";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(302, 512);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.dockPanel2Document});
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.dockPanel2Document});
            // 
            // dockPanel2Document
            // 
            this.dockPanel2Document.Caption = "Excel";
            this.dockPanel2Document.ControlName = "ExcelViewer";
            this.dockPanel2Document.FloatLocation = new System.Drawing.Point(0, 0);
            this.dockPanel2Document.FloatSize = new System.Drawing.Size(200, 200);
            this.dockPanel2Document.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.dockPanel2Document.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.dockPanel2Document.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // IOMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IOGriddockPanel);
            this.Name = "IOMenu";
            this.Size = new System.Drawing.Size(938, 542);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.IOGriddockPanel.ResumeLayout(false);
            this.ExcelViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockPanel2Document)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel IOGriddockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.DockPanel ExcelViewer;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document dockPanel2Document;


    }
}
