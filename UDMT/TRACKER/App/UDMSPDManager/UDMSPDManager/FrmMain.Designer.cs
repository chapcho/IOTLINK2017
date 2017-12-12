namespace UDMSPDManager
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
            this.tabCollectApp = new DevExpress.XtraTab.XtraTabControl();
            this.pnlStatus = new DevExpress.XtraEditors.PanelControl();
            this.grpClientStatus = new DevExpress.XtraEditors.GroupControl();
            this.chkShowSysLog = new DevExpress.XtraEditors.CheckButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnManagerServer = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grpTrackerStatus = new DevExpress.XtraEditors.GroupControl();
            this.btnTrackerConnect = new DevExpress.XtraEditors.SimpleButton();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnlSystemMessage = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucSystemLogTable = new UDMSPDManager.UCSystemLogTable();
            this.tmrTrackerCheck = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatus)).BeginInit();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpClientStatus)).BeginInit();
            this.grpClientStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTrackerStatus)).BeginInit();
            this.grpTrackerStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dpnlSystemMessage.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.cntxNotify.SuspendLayout();
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
            this.tabCollectApp.Location = new System.Drawing.Point(0, 104);
            this.tabCollectApp.Name = "tabCollectApp";
            this.tabCollectApp.Size = new System.Drawing.Size(784, 380);
            this.tabCollectApp.TabIndex = 1;
            this.tabCollectApp.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabCollectApp_SelectedPageChanged);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlStatus.Controls.Add(this.grpClientStatus);
            this.pnlStatus.Controls.Add(this.panelControl3);
            this.pnlStatus.Controls.Add(this.grpTrackerStatus);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(784, 104);
            this.pnlStatus.TabIndex = 3;
            // 
            // grpClientStatus
            // 
            this.grpClientStatus.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grpClientStatus.AppearanceCaption.Options.UseFont = true;
            this.grpClientStatus.Controls.Add(this.chkShowSysLog);
            this.grpClientStatus.Controls.Add(this.panelControl2);
            this.grpClientStatus.Controls.Add(this.btnTest);
            this.grpClientStatus.Controls.Add(this.panelControl1);
            this.grpClientStatus.Controls.Add(this.btnManagerServer);
            this.grpClientStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpClientStatus.Location = new System.Drawing.Point(149, 0);
            this.grpClientStatus.Name = "grpClientStatus";
            this.grpClientStatus.Size = new System.Drawing.Size(635, 104);
            this.grpClientStatus.TabIndex = 7;
            this.grpClientStatus.Text = "Manager Status";
            // 
            // chkShowSysLog
            // 
            this.chkShowSysLog.Checked = true;
            this.chkShowSysLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkShowSysLog.Image = ((System.Drawing.Image)(resources.GetObject("chkShowSysLog.Image")));
            this.chkShowSysLog.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.chkShowSysLog.Location = new System.Drawing.Point(550, 28);
            this.chkShowSysLog.Name = "chkShowSysLog";
            this.chkShowSysLog.Size = new System.Drawing.Size(73, 74);
            this.chkShowSysLog.TabIndex = 6;
            this.chkShowSysLog.Text = "System\r\nLog";
            this.chkShowSysLog.CheckedChanged += new System.EventHandler(this.chkShowSysLog_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(623, 28);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(10, 74);
            this.panelControl2.TabIndex = 9;
            // 
            // btnTest
            // 
            this.btnTest.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnTest.Appearance.BackColor2 = System.Drawing.Color.OrangeRed;
            this.btnTest.Appearance.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
            this.btnTest.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTest.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTest.Appearance.Options.UseBackColor = true;
            this.btnTest.Appearance.Options.UseFont = true;
            this.btnTest.Appearance.Options.UseForeColor = true;
            this.btnTest.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTest.ImageIndex = 0;
            this.btnTest.Location = new System.Drawing.Point(162, 28);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(187, 74);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "TEST";
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(132, 28);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(30, 74);
            this.panelControl1.TabIndex = 8;
            // 
            // btnManagerServer
            // 
            this.btnManagerServer.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnManagerServer.Appearance.BackColor2 = System.Drawing.Color.OrangeRed;
            this.btnManagerServer.Appearance.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
            this.btnManagerServer.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnManagerServer.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnManagerServer.Appearance.Options.UseBackColor = true;
            this.btnManagerServer.Appearance.Options.UseFont = true;
            this.btnManagerServer.Appearance.Options.UseForeColor = true;
            this.btnManagerServer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnManagerServer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnManagerServer.ImageIndex = 0;
            this.btnManagerServer.Location = new System.Drawing.Point(2, 28);
            this.btnManagerServer.Name = "btnManagerServer";
            this.btnManagerServer.Size = new System.Drawing.Size(130, 74);
            this.btnManagerServer.TabIndex = 5;
            this.btnManagerServer.Text = "NG";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(134, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(15, 104);
            this.panelControl3.TabIndex = 9;
            // 
            // grpTrackerStatus
            // 
            this.grpTrackerStatus.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.grpTrackerStatus.AppearanceCaption.Options.UseFont = true;
            this.grpTrackerStatus.Controls.Add(this.btnTrackerConnect);
            this.grpTrackerStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpTrackerStatus.Location = new System.Drawing.Point(0, 0);
            this.grpTrackerStatus.Name = "grpTrackerStatus";
            this.grpTrackerStatus.Size = new System.Drawing.Size(134, 104);
            this.grpTrackerStatus.TabIndex = 0;
            this.grpTrackerStatus.Text = "Tracker Status";
            // 
            // btnTrackerConnect
            // 
            this.btnTrackerConnect.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnTrackerConnect.Appearance.BackColor2 = System.Drawing.Color.OrangeRed;
            this.btnTrackerConnect.Appearance.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
            this.btnTrackerConnect.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTrackerConnect.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnTrackerConnect.Appearance.Options.UseBackColor = true;
            this.btnTrackerConnect.Appearance.Options.UseFont = true;
            this.btnTrackerConnect.Appearance.Options.UseForeColor = true;
            this.btnTrackerConnect.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnTrackerConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrackerConnect.ImageIndex = 0;
            this.btnTrackerConnect.Location = new System.Drawing.Point(2, 28);
            this.btnTrackerConnect.Name = "btnTrackerConnect";
            this.btnTrackerConnect.Size = new System.Drawing.Size(130, 74);
            this.btnTrackerConnect.TabIndex = 1;
            this.btnTrackerConnect.Text = "NG";
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
            this.dpnlSystemMessage.ID = new System.Guid("a0b72200-b570-4f7e-8159-74d3fa80ac88");
            this.dpnlSystemMessage.Location = new System.Drawing.Point(0, 484);
            this.dpnlSystemMessage.Name = "dpnlSystemMessage";
            this.dpnlSystemMessage.OriginalSize = new System.Drawing.Size(200, 178);
            this.dpnlSystemMessage.Size = new System.Drawing.Size(784, 178);
            this.dpnlSystemMessage.Text = "System Message";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucSystemLogTable);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(776, 151);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucSystemLogTable
            // 
            this.ucSystemLogTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSystemLogTable.Location = new System.Drawing.Point(0, 0);
            this.ucSystemLogTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSystemLogTable.Name = "ucSystemLogTable";
            this.ucSystemLogTable.Size = new System.Drawing.Size(776, 151);
            this.ucSystemLogTable.TabIndex = 7;
            // 
            // tmrTrackerCheck
            // 
            this.tmrTrackerCheck.Interval = 2000;
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
            this.cntxNotify.Size = new System.Drawing.Size(153, 98);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuHide
            // 
            this.mnuHide.Name = "mnuHide";
            this.mnuHide.Size = new System.Drawing.Size(152, 22);
            this.mnuHide.Text = "Hide";
            this.mnuHide.Click += new System.EventHandler(this.mnuHide_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.ControlBox = false;
            this.Controls.Add(this.tabCollectApp);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.dpnlSystemMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "SPD Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tabCollectApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatus)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpClientStatus)).EndInit();
            this.grpClientStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTrackerStatus)).EndInit();
            this.grpTrackerStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dpnlSystemMessage.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.cntxNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabCollectApp;
        private DevExpress.XtraEditors.PanelControl pnlStatus;
        private DevExpress.XtraEditors.GroupControl grpClientStatus;
        private DevExpress.XtraEditors.SimpleButton btnManagerServer;
        private DevExpress.XtraEditors.GroupControl grpTrackerStatus;
        private DevExpress.XtraEditors.SimpleButton btnTrackerConnect;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraEditors.CheckButton chkShowSysLog;
        private DevExpress.XtraBars.Docking.DockPanel dpnlSystemMessage;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private UCSystemLogTable ucSystemLogTable;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private System.Windows.Forms.Timer tmrTrackerCheck;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cntxNotify;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;

    }
}

