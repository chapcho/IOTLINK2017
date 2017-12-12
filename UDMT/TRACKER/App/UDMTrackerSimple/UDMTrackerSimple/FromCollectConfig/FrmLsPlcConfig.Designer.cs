namespace UDMTrackerSimple
{
    partial class FrmLsPlcConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLsPlcConfig));
            this.pnlSet = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTestData = new System.Windows.Forms.TextBox();
            this.grpAddress = new DevExpress.XtraEditors.GroupControl();
            this.txtTestAddress = new System.Windows.Forms.TextBox();
            this.grpPlcInfoControl = new DevExpress.XtraEditors.GroupControl();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grpConnectSet = new DevExpress.XtraEditors.GroupControl();
            this.spnEthernetProt = new DevExpress.XtraEditors.SpinEdit();
            this.lblEthernetPort = new DevExpress.XtraEditors.LabelControl();
            this.spnInterval = new DevExpress.XtraEditors.SpinEdit();
            this.lblScanInterval = new DevExpress.XtraEditors.LabelControl();
            this.txtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.lblEthernetIPAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblModule = new DevExpress.XtraEditors.LabelControl();
            this.cmbModule = new System.Windows.Forms.ComboBox();
            this.pnlSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).BeginInit();
            this.grpAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcInfoControl)).BeginInit();
            this.grpPlcInfoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpConnectSet)).BeginInit();
            this.grpConnectSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnEthernetProt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSet
            // 
            this.pnlSet.Controls.Add(this.groupControl1);
            this.pnlSet.Controls.Add(this.grpAddress);
            this.pnlSet.Controls.Add(this.grpPlcInfoControl);
            this.pnlSet.Controls.Add(this.grpConnectSet);
            this.pnlSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSet.Location = new System.Drawing.Point(0, 0);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(270, 478);
            this.pnlSet.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTestData);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(114, 204);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(156, 274);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "수집 데이터 표시";
            // 
            // txtTestData
            // 
            this.txtTestData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestData.Location = new System.Drawing.Point(2, 21);
            this.txtTestData.Multiline = true;
            this.txtTestData.Name = "txtTestData";
            this.txtTestData.ReadOnly = true;
            this.txtTestData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTestData.Size = new System.Drawing.Size(152, 251);
            this.txtTestData.TabIndex = 1;
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.txtTestAddress);
            this.grpAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpAddress.Location = new System.Drawing.Point(0, 204);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(114, 274);
            this.grpAddress.TabIndex = 5;
            this.grpAddress.Text = "수집 주소 입력";
            // 
            // txtTestAddress
            // 
            this.txtTestAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestAddress.Location = new System.Drawing.Point(2, 21);
            this.txtTestAddress.Multiline = true;
            this.txtTestAddress.Name = "txtTestAddress";
            this.txtTestAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTestAddress.Size = new System.Drawing.Size(110, 251);
            this.txtTestAddress.TabIndex = 106;
            this.txtTestAddress.Text = "F00090\r\nF00091\r\nF00092\r\nF00093\r\nF00094\r\nF00095\r\nF00096\r\nF00097\r\n";
            // 
            // grpPlcInfoControl
            // 
            this.grpPlcInfoControl.Controls.Add(this.btnStop);
            this.grpPlcInfoControl.Controls.Add(this.btnStart);
            this.grpPlcInfoControl.Controls.Add(this.panelControl2);
            this.grpPlcInfoControl.Controls.Add(this.panelControl3);
            this.grpPlcInfoControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPlcInfoControl.Location = new System.Drawing.Point(0, 152);
            this.grpPlcInfoControl.Name = "grpPlcInfoControl";
            this.grpPlcInfoControl.Size = new System.Drawing.Size(270, 52);
            this.grpPlcInfoControl.TabIndex = 1;
            this.grpPlcInfoControl.Text = "모니터 제어";
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnStop.Enabled = false;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnStop.Location = new System.Drawing.Point(158, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 29);
            this.btnStop.TabIndex = 83;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnStart.Location = new System.Drawing.Point(12, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 29);
            this.btnStart.TabIndex = 82;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(258, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(10, 29);
            this.panelControl2.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(2, 21);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(10, 29);
            this.panelControl3.TabIndex = 4;
            // 
            // grpConnectSet
            // 
            this.grpConnectSet.Controls.Add(this.spnEthernetProt);
            this.grpConnectSet.Controls.Add(this.lblEthernetPort);
            this.grpConnectSet.Controls.Add(this.spnInterval);
            this.grpConnectSet.Controls.Add(this.lblScanInterval);
            this.grpConnectSet.Controls.Add(this.txtIPAddress);
            this.grpConnectSet.Controls.Add(this.lblEthernetIPAddress);
            this.grpConnectSet.Controls.Add(this.lblModule);
            this.grpConnectSet.Controls.Add(this.cmbModule);
            this.grpConnectSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConnectSet.Location = new System.Drawing.Point(0, 0);
            this.grpConnectSet.Name = "grpConnectSet";
            this.grpConnectSet.Size = new System.Drawing.Size(270, 152);
            this.grpConnectSet.TabIndex = 0;
            this.grpConnectSet.Text = "기본 설정";
            // 
            // spnEthernetProt
            // 
            this.spnEthernetProt.EditValue = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.spnEthernetProt.Enabled = false;
            this.spnEthernetProt.Location = new System.Drawing.Point(108, 89);
            this.spnEthernetProt.Name = "spnEthernetProt";
            this.spnEthernetProt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnEthernetProt.Properties.IsFloatValue = false;
            this.spnEthernetProt.Properties.Mask.EditMask = "N00";
            this.spnEthernetProt.Properties.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.spnEthernetProt.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnEthernetProt.Size = new System.Drawing.Size(146, 20);
            this.spnEthernetProt.TabIndex = 134;
            // 
            // lblEthernetPort
            // 
            this.lblEthernetPort.Location = new System.Drawing.Point(14, 92);
            this.lblEthernetPort.Name = "lblEthernetPort";
            this.lblEthernetPort.Size = new System.Drawing.Size(88, 14);
            this.lblEthernetPort.TabIndex = 133;
            this.lblEthernetPort.Text = "Ethernet Port : ";
            // 
            // spnInterval
            // 
            this.spnInterval.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnInterval.Location = new System.Drawing.Point(108, 116);
            this.spnInterval.Name = "spnInterval";
            this.spnInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnInterval.Properties.IsFloatValue = false;
            this.spnInterval.Properties.Mask.EditMask = "N00";
            this.spnInterval.Properties.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.spnInterval.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnInterval.Size = new System.Drawing.Size(146, 20);
            this.spnInterval.TabIndex = 132;
            // 
            // lblScanInterval
            // 
            this.lblScanInterval.Location = new System.Drawing.Point(14, 119);
            this.lblScanInterval.Name = "lblScanInterval";
            this.lblScanInterval.Size = new System.Drawing.Size(83, 14);
            this.lblScanInterval.TabIndex = 131;
            this.lblScanInterval.Text = "Scan Interval : ";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.EditValue = "192.168.0.150";
            this.txtIPAddress.Enabled = false;
            this.txtIPAddress.Location = new System.Drawing.Point(108, 63);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIPAddress.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIPAddress.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtIPAddress.Properties.Mask.EditMask = "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(" +
    "25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[" +
    "0-4][0-9])|(25[0-5]))";
            this.txtIPAddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtIPAddress.Size = new System.Drawing.Size(146, 20);
            this.txtIPAddress.TabIndex = 130;
            // 
            // lblEthernetIPAddress
            // 
            this.lblEthernetIPAddress.Location = new System.Drawing.Point(14, 66);
            this.lblEthernetIPAddress.Name = "lblEthernetIPAddress";
            this.lblEthernetIPAddress.Size = new System.Drawing.Size(76, 14);
            this.lblEthernetIPAddress.TabIndex = 129;
            this.lblEthernetIPAddress.Text = "Ethernet IP : ";
            // 
            // lblModule
            // 
            this.lblModule.Location = new System.Drawing.Point(14, 33);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(68, 14);
            this.lblModule.TabIndex = 116;
            this.lblModule.Text = "연결 Type : ";
            // 
            // cmbModule
            // 
            this.cmbModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModule.FormattingEnabled = true;
            this.cmbModule.Items.AddRange(new object[] {
            "USB",
            "Ethernet"});
            this.cmbModule.Location = new System.Drawing.Point(108, 30);
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.Size = new System.Drawing.Size(146, 22);
            this.cmbModule.TabIndex = 115;
            this.cmbModule.SelectedIndexChanged += new System.EventHandler(this.cmbModule_SelectedIndexChanged);
            // 
            // FrmLsPlcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 478);
            this.Controls.Add(this.pnlSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLsPlcConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "통신 환경 설정 ( LS )";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLsPlcConfig_FormClosed);
            this.Load += new System.EventHandler(this.FrmLsPlcConfig_Load);
            this.pnlSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).EndInit();
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlcInfoControl)).EndInit();
            this.grpPlcInfoControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpConnectSet)).EndInit();
            this.grpConnectSet.ResumeLayout(false);
            this.grpConnectSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnEthernetProt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSet;
        private DevExpress.XtraEditors.GroupControl grpConnectSet;
        private DevExpress.XtraEditors.LabelControl lblModule;
        private System.Windows.Forms.ComboBox cmbModule;
        private DevExpress.XtraEditors.TextEdit txtIPAddress;
        private DevExpress.XtraEditors.LabelControl lblEthernetIPAddress;
        private DevExpress.XtraEditors.SpinEdit spnInterval;
        private DevExpress.XtraEditors.LabelControl lblScanInterval;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtTestData;
        private DevExpress.XtraEditors.GroupControl grpAddress;
        private System.Windows.Forms.TextBox txtTestAddress;
        private DevExpress.XtraEditors.GroupControl grpPlcInfoControl;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SpinEdit spnEthernetProt;
        private DevExpress.XtraEditors.LabelControl lblEthernetPort;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnStart;
    }
}