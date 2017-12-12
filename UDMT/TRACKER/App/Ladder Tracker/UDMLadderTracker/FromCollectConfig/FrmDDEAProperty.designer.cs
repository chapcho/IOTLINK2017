using TrackerSPD.DDEA;
namespace UDMLadderTracker
{
    partial class FrmDDEAProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDDEAProperty));
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ucConnectionTest = new TrackerSPD.DDEA.UCConnectionTest();
            this.tabConfigSet = new DevExpress.XtraTab.XtraTabControl();
            this.tpRSeries = new DevExpress.XtraTab.XtraTabPage();
            this.ucConnectSetMxCom4 = new TrackerSPD.DDEA.UCConnectSetMxCom4();
            this.tpNoraml = new DevExpress.XtraTab.XtraTabPage();
            this.ucConnectSetting = new TrackerSPD.DDEA.UCConnectSetting();
            this.pnlConfig = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.cmbSeries = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUnitType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabConfigSet)).BeginInit();
            this.tabConfigSet.SuspendLayout();
            this.tpRSeries.SuspendLayout();
            this.tpNoraml.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConfig)).BeginInit();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeries.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.panelControl1);
            this.grpControl.Controls.Add(this.panelControl2);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpControl.Location = new System.Drawing.Point(318, 563);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(451, 79);
            this.grpControl.TabIndex = 86;
            this.grpControl.Text = "저장";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSet);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(89, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(255, 56);
            this.panelControl1.TabIndex = 82;
            // 
            // btnSet
            // 
            this.btnSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btnSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSet.Location = new System.Drawing.Point(2, 2);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(90, 52);
            this.btnSet.TabIndex = 80;
            this.btnSet.Text = "Save";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(163, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 52);
            this.btnClose.TabIndex = 79;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 21);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(87, 56);
            this.panelControl2.TabIndex = 81;
            // 
            // ucConnectionTest
            // 
            this.ucConnectionTest.Config = null;
            this.ucConnectionTest.ConnectSuccess = false;
            this.ucConnectionTest.Location = new System.Drawing.Point(317, 0);
            this.ucConnectionTest.Name = "ucConnectionTest";
            this.ucConnectionTest.Size = new System.Drawing.Size(452, 563);
            this.ucConnectionTest.TabIndex = 87;
            // 
            // tabConfigSet
            // 
            this.tabConfigSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfigSet.Location = new System.Drawing.Point(0, 46);
            this.tabConfigSet.Name = "tabConfigSet";
            this.tabConfigSet.SelectedTabPage = this.tpRSeries;
            this.tabConfigSet.Size = new System.Drawing.Size(318, 596);
            this.tabConfigSet.TabIndex = 89;
            this.tabConfigSet.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpRSeries,
            this.tpNoraml});
            // 
            // tpRSeries
            // 
            this.tpRSeries.Controls.Add(this.ucConnectSetMxCom4);
            this.tpRSeries.Name = "tpRSeries";
            this.tpRSeries.Size = new System.Drawing.Size(312, 567);
            this.tpRSeries.Text = "R-Series";
            // 
            // ucConnectSetMxCom4
            // 
            this.ucConnectSetMxCom4.Config = null;
            this.ucConnectSetMxCom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectSetMxCom4.Location = new System.Drawing.Point(0, 0);
            this.ucConnectSetMxCom4.Name = "ucConnectSetMxCom4";
            this.ucConnectSetMxCom4.Size = new System.Drawing.Size(312, 567);
            this.ucConnectSetMxCom4.TabIndex = 0;
            // 
            // tpNoraml
            // 
            this.tpNoraml.Controls.Add(this.ucConnectSetting);
            this.tpNoraml.Name = "tpNoraml";
            this.tpNoraml.Size = new System.Drawing.Size(315, 678);
            this.tpNoraml.Text = "Normal";
            // 
            // ucConnectSetting
            // 
            this.ucConnectSetting.Config = null;
            this.ucConnectSetting.DataChange = false;
            this.ucConnectSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectSetting.Location = new System.Drawing.Point(0, 0);
            this.ucConnectSetting.Name = "ucConnectSetting";
            this.ucConnectSetting.Size = new System.Drawing.Size(315, 678);
            this.ucConnectSetting.TabIndex = 0;
            // 
            // pnlConfig
            // 
            this.pnlConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlConfig.Controls.Add(this.tabConfigSet);
            this.pnlConfig.Controls.Add(this.panelControl3);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(318, 642);
            this.pnlConfig.TabIndex = 90;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.lblUnitType);
            this.panelControl3.Controls.Add(this.cmbSeries);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(318, 46);
            this.panelControl3.TabIndex = 89;
            // 
            // cmbSeries
            // 
            this.cmbSeries.EditValue = "R-Series";
            this.cmbSeries.Location = new System.Drawing.Point(134, 12);
            this.cmbSeries.Name = "cmbSeries";
            this.cmbSeries.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbSeries.Properties.Appearance.Options.UseFont = true;
            this.cmbSeries.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbSeries.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cmbSeries.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbSeries.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbSeries.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbSeries.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.cmbSeries.Properties.AppearanceFocused.Options.UseFont = true;
            this.cmbSeries.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.cmbSeries.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSeries.Properties.Items.AddRange(new object[] {
            "R-Series",
            "Q/A Series"});
            this.cmbSeries.Size = new System.Drawing.Size(147, 24);
            this.cmbSeries.TabIndex = 1;
            this.cmbSeries.SelectedIndexChanged += new System.EventHandler(this.cmbSeries_SelectedIndexChanged);
            // 
            // lblUnitType
            // 
            this.lblUnitType.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblUnitType.Location = new System.Drawing.Point(12, 15);
            this.lblUnitType.Name = "lblUnitType";
            this.lblUnitType.Size = new System.Drawing.Size(81, 18);
            this.lblUnitType.TabIndex = 111;
            this.lblUnitType.Text = "Series Select";
            // 
            // FrmDDEAProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 642);
            this.ControlBox = false;
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.ucConnectionTest);
            this.MinimumSize = new System.Drawing.Size(740, 680);
            this.Name = "FrmDDEAProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "통신 환경 설정 ( Melsec )";
            this.Load += new System.EventHandler(this.FrmDDEAProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabConfigSet)).EndInit();
            this.tabConfigSet.ResumeLayout(false);
            this.tpRSeries.ResumeLayout(false);
            this.tpNoraml.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlConfig)).EndInit();
            this.pnlConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeries.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TrackerSPD.DDEA.UCConnectionTest ucConnectionTest;
        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSet;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl tabConfigSet;
        private DevExpress.XtraTab.XtraTabPage tpRSeries;
        private UCConnectSetMxCom4 ucConnectSetMxCom4;
        private DevExpress.XtraTab.XtraTabPage tpNoraml;
        private UCConnectSetting ucConnectSetting;
        private DevExpress.XtraEditors.PanelControl pnlConfig;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl lblUnitType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSeries;

    }
}