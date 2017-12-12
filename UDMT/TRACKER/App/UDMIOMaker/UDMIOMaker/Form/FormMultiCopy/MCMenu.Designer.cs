namespace NewIOMaker.Form.Form_MultiCopy
{
    partial class MCMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCMenu));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.btnDefault = new DevExpress.XtraBars.Navigation.NavButton();
            this.UseImportFile = new DevExpress.XtraBars.Navigation.NavButton();
            this.UserKeyCategory = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tileNavItem1 = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileNavItem2 = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavSubItem2 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.tileNavItem3 = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavSubItem3 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            this.btnRun = new DevExpress.XtraBars.Navigation.NavButton();
            this.btnStop = new DevExpress.XtraBars.Navigation.NavButton();
            this.tileNavCategory4 = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.tileNavCategory5 = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.KeyListdockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.KeyListdockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane1.Buttons.Add(this.btnDefault);
            this.tileNavPane1.Buttons.Add(this.UseImportFile);
            this.tileNavPane1.Buttons.Add(this.UserKeyCategory);
            this.tileNavPane1.Buttons.Add(this.btnRun);
            this.tileNavPane1.Buttons.Add(this.btnStop);
            this.tileNavPane1.Categories.AddRange(new DevExpress.XtraBars.Navigation.TileNavCategory[] {
            this.tileNavCategory4,
            this.tileNavCategory5});
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane1.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Size = new System.Drawing.Size(833, 40);
            this.tileNavPane1.TabIndex = 0;
            this.tileNavPane1.Text = "tileNavPane1";
            // 
            // btnDefault
            // 
            this.btnDefault.Caption = "[   KEY INFORMATION   ]";
            this.btnDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDefault.Glyph")));
            this.btnDefault.IsMain = true;
            this.btnDefault.Name = "btnDefault";
            // 
            // UseImportFile
            // 
            this.UseImportFile.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.UseImportFile.Caption = "[   USE IMPORT FILE   ]";
            this.UseImportFile.Name = "UseImportFile";
            // 
            // UserKeyCategory
            // 
            this.UserKeyCategory.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.UserKeyCategory.Caption = "[   CURRENT KEY    ]";
            this.UserKeyCategory.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tileNavItem1,
            this.tileNavItem2,
            this.tileNavItem3});
            this.UserKeyCategory.Name = "UserKeyCategory";
            this.UserKeyCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.UserKeyCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.UserKeyCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.UserKeyCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            // 
            // tileNavItem1
            // 
            this.tileNavItem1.Caption = "Group1";
            this.tileNavItem1.Name = "tileNavItem1";
            this.tileNavItem1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavItem1.OwnerCollection = this.UserKeyCategory.Items;
            this.tileNavItem1.SubItems.AddRange(new DevExpress.XtraBars.Navigation.TileNavSubItem[] {
            this.tileNavSubItem1});
            // 
            // 
            // 
            this.tileNavItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Text = "Group1";
            this.tileNavItem1.Tile.Elements.Add(tileItemElement2);
            this.tileNavItem1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavItem1.Tile.Name = "tileBarItem1";
            // 
            // tileNavSubItem1
            // 
            this.tileNavSubItem1.Caption = "Key1";
            this.tileNavSubItem1.Name = "tileNavSubItem1";
            this.tileNavSubItem1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.tileNavSubItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "Key1";
            this.tileNavSubItem1.Tile.Elements.Add(tileItemElement1);
            this.tileNavSubItem1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavSubItem1.Tile.Name = "tileBarItem4";
            // 
            // tileNavItem2
            // 
            this.tileNavItem2.Caption = "Group2";
            this.tileNavItem2.Name = "tileNavItem2";
            this.tileNavItem2.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavItem2.OwnerCollection = this.UserKeyCategory.Items;
            this.tileNavItem2.SubItems.AddRange(new DevExpress.XtraBars.Navigation.TileNavSubItem[] {
            this.tileNavSubItem2});
            // 
            // 
            // 
            this.tileNavItem2.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.Text = "Group2";
            this.tileNavItem2.Tile.Elements.Add(tileItemElement4);
            this.tileNavItem2.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavItem2.Tile.Name = "tileBarItem2";
            // 
            // tileNavSubItem2
            // 
            this.tileNavSubItem2.Caption = "Key2";
            this.tileNavSubItem2.Name = "tileNavSubItem2";
            this.tileNavSubItem2.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.tileNavSubItem2.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Text = "Key2";
            this.tileNavSubItem2.Tile.Elements.Add(tileItemElement3);
            this.tileNavSubItem2.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavSubItem2.Tile.Name = "tileBarItem5";
            // 
            // tileNavItem3
            // 
            this.tileNavItem3.Caption = "Group3";
            this.tileNavItem3.Name = "tileNavItem3";
            this.tileNavItem3.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavItem3.OwnerCollection = this.UserKeyCategory.Items;
            this.tileNavItem3.SubItems.AddRange(new DevExpress.XtraBars.Navigation.TileNavSubItem[] {
            this.tileNavSubItem3});
            // 
            // 
            // 
            this.tileNavItem3.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.Text = "Group3";
            this.tileNavItem3.Tile.Elements.Add(tileItemElement6);
            this.tileNavItem3.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavItem3.Tile.Name = "tileBarItem3";
            // 
            // tileNavSubItem3
            // 
            this.tileNavSubItem3.Caption = "Key3";
            this.tileNavSubItem3.Name = "tileNavSubItem3";
            this.tileNavSubItem3.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.tileNavSubItem3.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Text = "Key3";
            this.tileNavSubItem3.Tile.Elements.Add(tileItemElement5);
            this.tileNavSubItem3.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavSubItem3.Tile.Name = "tileBarItem6";
            // 
            // btnRun
            // 
            this.btnRun.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnRun.Caption = "[   RUN   ]";
            this.btnRun.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRun.Glyph")));
            this.btnRun.Name = "btnRun";
            // 
            // btnStop
            // 
            this.btnStop.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.btnStop.Caption = "[   STOP   ]";
            this.btnStop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnStop.Glyph")));
            this.btnStop.Name = "btnStop";
            // 
            // tileNavCategory4
            // 
            this.tileNavCategory4.Caption = "Right Alt";
            this.tileNavCategory4.Name = "tileNavCategory4";
            this.tileNavCategory4.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavCategory4.OwnerCollection = this.tileNavPane1.Categories;
            // 
            // 
            // 
            this.tileNavCategory4.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Text = "Right Alt";
            this.tileNavCategory4.Tile.Elements.Add(tileItemElement7);
            this.tileNavCategory4.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavCategory4.Tile.Name = "tileBarItem2";
            // 
            // tileNavCategory5
            // 
            this.tileNavCategory5.Caption = "Right Ctrl";
            this.tileNavCategory5.Name = "tileNavCategory5";
            this.tileNavCategory5.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavCategory5.OwnerCollection = this.tileNavPane1.Categories;
            // 
            // 
            // 
            this.tileNavCategory5.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement8.Text = "Right Ctrl";
            this.tileNavCategory5.Tile.Elements.Add(tileItemElement8);
            this.tileNavCategory5.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavCategory5.Tile.Name = "tileBarItem3";
            // 
            // panelContainer1
            // 
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.panelContainer1.ID = new System.Guid("15f381fe-fb45-4773-ba17-6caf2cdb431a");
            this.panelContainer1.Location = new System.Drawing.Point(0, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(0, 0);
            this.panelContainer1.Size = new System.Drawing.Size(200, 200);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2,
            this.KeyListdockPanel});
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
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Close", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("a3c259cb-c9d5-4bd2-a46b-11f81067ec0e");
            this.dockPanel2.Location = new System.Drawing.Point(0, 40);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(392, 441);
            this.dockPanel2.Size = new System.Drawing.Size(392, 495);
            this.dockPanel2.Text = "Key Generator";
            this.dockPanel2.Click += new System.EventHandler(this.dockPanel2_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 29);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(386, 464);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // KeyListdockPanel
            // 
            this.KeyListdockPanel.Controls.Add(this.dockPanel1_Container);
            this.KeyListdockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.KeyListdockPanel.ID = new System.Guid("264dc45b-60e1-4373-8eea-d4b08c36f36f");
            this.KeyListdockPanel.Location = new System.Drawing.Point(392, 40);
            this.KeyListdockPanel.Name = "KeyListdockPanel";
            this.KeyListdockPanel.OriginalSize = new System.Drawing.Size(429, 200);
            this.KeyListdockPanel.Size = new System.Drawing.Size(429, 495);
            this.KeyListdockPanel.Text = "Key List";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(423, 467);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // MCMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KeyListdockPanel);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.tileNavPane1);
            this.Name = "MCMenu";
            this.Size = new System.Drawing.Size(833, 535);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.KeyListdockPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton btnDefault;
        private DevExpress.XtraBars.Navigation.NavButton btnRun;
        private DevExpress.XtraBars.Navigation.NavButton btnStop;
        private DevExpress.XtraBars.Navigation.TileNavCategory UserKeyCategory;
        private DevExpress.XtraBars.Navigation.TileNavItem tileNavItem1;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
        private DevExpress.XtraBars.Navigation.TileNavItem tileNavItem2;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem2;
        private DevExpress.XtraBars.Navigation.TileNavItem tileNavItem3;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem3;
        private DevExpress.XtraBars.Navigation.TileNavCategory tileNavCategory4;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Navigation.TileNavCategory tileNavCategory5;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel KeyListdockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Navigation.NavButton UseImportFile;

    }
}
