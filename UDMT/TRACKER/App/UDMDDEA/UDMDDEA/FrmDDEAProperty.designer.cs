namespace UDMDDEA
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
			this.ucConnectionTest = new UDM.DDEA.UCConnectionTest();
			this.ucConnectSetting = new UDM.DDEA.UCConnectSetting();
			((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
			this.grpControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.SuspendLayout();
			// 
			// grpControl
			// 
			this.grpControl.Controls.Add(this.panelControl1);
			this.grpControl.Controls.Add(this.panelControl2);
			this.grpControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpControl.Location = new System.Drawing.Point(277, 585);
			this.grpControl.Name = "grpControl";
			this.grpControl.Size = new System.Drawing.Size(447, 79);
			this.grpControl.TabIndex = 86;
			this.grpControl.Text = "저장";
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnSet);
			this.panelControl1.Controls.Add(this.btnClose);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelControl1.Location = new System.Drawing.Point(89, 22);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(255, 55);
			this.panelControl1.TabIndex = 82;
			// 
			// btnSet
			// 
			this.btnSet.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
			this.btnSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
			this.btnSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnSet.Location = new System.Drawing.Point(0, 0);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(90, 55);
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
			this.btnClose.Location = new System.Drawing.Point(165, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 55);
			this.btnClose.TabIndex = 79;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelControl2.Location = new System.Drawing.Point(2, 22);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(87, 55);
			this.panelControl2.TabIndex = 81;
			// 
			// ucConnectionTest
			// 
			this.ucConnectionTest.ConnectSuccess = false;
			this.ucConnectionTest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucConnectionTest.Location = new System.Drawing.Point(277, 0);
			this.ucConnectionTest.Name = "ucConnectionTest";
			this.ucConnectionTest.Size = new System.Drawing.Size(447, 585);
			this.ucConnectionTest.TabIndex = 87;
			// 
			// ucConnectSetting
			// 
			this.ucConnectSetting.Config = null;
			this.ucConnectSetting.DataChange = false;
			this.ucConnectSetting.Dock = System.Windows.Forms.DockStyle.Left;
			this.ucConnectSetting.Location = new System.Drawing.Point(0, 0);
			this.ucConnectSetting.Name = "ucConnectSetting";
			this.ucConnectSetting.Size = new System.Drawing.Size(277, 664);
			this.ucConnectSetting.TabIndex = 85;
			// 
			// FrmDDEAProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 664);
			this.ControlBox = false;
			this.Controls.Add(this.ucConnectionTest);
			this.Controls.Add(this.grpControl);
			this.Controls.Add(this.ucConnectSetting);
			this.MinimumSize = new System.Drawing.Size(740, 680);
			this.Name = "FrmDDEAProperty";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "통신 환경 설정";
			this.Load += new System.EventHandler(this.FrmDDEAProperty_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
			this.grpControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private UDM.DDEA.UCConnectionTest ucConnectionTest;
        private DevExpress.XtraEditors.GroupControl grpControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSet;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private UDM.DDEA.UCConnectSetting ucConnectSetting;

    }
}