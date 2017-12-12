namespace UDM.EnergyDaq.Config
{
    partial class FrmConfigSetting
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
            this.pnlConfigKey = new System.Windows.Forms.Panel();
            this.lblMs = new System.Windows.Forms.Label();
            this.txtIntervalTime = new System.Windows.Forms.TextBox();
            this.lblInterTime = new System.Windows.Forms.Label();
            this.cbConnectType = new System.Windows.Forms.ComboBox();
            this.lblConnectType = new System.Windows.Forms.Label();
            this.cbMeterModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtMeterName = new System.Windows.Forms.TextBox();
            this.lblMeterkey = new System.Windows.Forms.Label();
            this.pnlConnectSetting = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.TableLayoutPanel();
            this.btAddConfig = new DevExpress.XtraEditors.SimpleButton();
            this.btShowConfigs = new DevExpress.XtraEditors.SimpleButton();
            this.btClose = new DevExpress.XtraEditors.SimpleButton();
            this.pnlConfigKey.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfigKey
            // 
            this.pnlConfigKey.Controls.Add(this.lblMs);
            this.pnlConfigKey.Controls.Add(this.txtIntervalTime);
            this.pnlConfigKey.Controls.Add(this.lblInterTime);
            this.pnlConfigKey.Controls.Add(this.cbConnectType);
            this.pnlConfigKey.Controls.Add(this.lblConnectType);
            this.pnlConfigKey.Controls.Add(this.cbMeterModel);
            this.pnlConfigKey.Controls.Add(this.lblModel);
            this.pnlConfigKey.Controls.Add(this.txtMeterName);
            this.pnlConfigKey.Controls.Add(this.lblMeterkey);
            this.pnlConfigKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfigKey.Location = new System.Drawing.Point(10, 10);
            this.pnlConfigKey.Name = "pnlConfigKey";
            this.pnlConfigKey.Padding = new System.Windows.Forms.Padding(5);
            this.pnlConfigKey.Size = new System.Drawing.Size(548, 56);
            this.pnlConfigKey.TabIndex = 0;
            // 
            // lblMs
            // 
            this.lblMs.AutoSize = true;
            this.lblMs.Location = new System.Drawing.Point(205, 32);
            this.lblMs.Name = "lblMs";
            this.lblMs.Size = new System.Drawing.Size(33, 12);
            this.lblMs.TabIndex = 8;
            this.lblMs.Text = "(ms)";
            // 
            // txtIntervalTime
            // 
            this.txtIntervalTime.Location = new System.Drawing.Point(109, 27);
            this.txtIntervalTime.Name = "txtIntervalTime";
            this.txtIntervalTime.Size = new System.Drawing.Size(89, 21);
            this.txtIntervalTime.TabIndex = 7;
            // 
            // lblInterTime
            // 
            this.lblInterTime.AutoSize = true;
            this.lblInterTime.Location = new System.Drawing.Point(5, 33);
            this.lblInterTime.Name = "lblInterTime";
            this.lblInterTime.Size = new System.Drawing.Size(90, 12);
            this.lblInterTime.TabIndex = 6;
            this.lblInterTime.Text = "Interval Time : ";
            // 
            // cbConnectType
            // 
            this.cbConnectType.CausesValidation = false;
            this.cbConnectType.FormattingEnabled = true;
            this.cbConnectType.Location = new System.Drawing.Point(382, 28);
            this.cbConnectType.Name = "cbConnectType";
            this.cbConnectType.Size = new System.Drawing.Size(138, 20);
            this.cbConnectType.TabIndex = 5;
            this.cbConnectType.SelectedIndexChanged += new System.EventHandler(this.cbConnectType_SelectedIndexChanged);
            // 
            // lblConnectType
            // 
            this.lblConnectType.AutoSize = true;
            this.lblConnectType.Location = new System.Drawing.Point(279, 32);
            this.lblConnectType.Name = "lblConnectType";
            this.lblConnectType.Size = new System.Drawing.Size(97, 12);
            this.lblConnectType.TabIndex = 4;
            this.lblConnectType.Text = "Connect Type : ";
            // 
            // cbMeterModel
            // 
            this.cbMeterModel.FormattingEnabled = true;
            this.cbMeterModel.Location = new System.Drawing.Point(382, 2);
            this.cbMeterModel.Name = "cbMeterModel";
            this.cbMeterModel.Size = new System.Drawing.Size(138, 20);
            this.cbMeterModel.TabIndex = 3;
            this.cbMeterModel.SelectedIndexChanged += new System.EventHandler(this.cbMeterModel_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(324, 5);
            this.lblModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(52, 12);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model : ";
            // 
            // txtMeterName
            // 
            this.txtMeterName.Location = new System.Drawing.Point(109, 1);
            this.txtMeterName.Name = "txtMeterName";
            this.txtMeterName.Size = new System.Drawing.Size(145, 21);
            this.txtMeterName.TabIndex = 1;
            // 
            // lblMeterkey
            // 
            this.lblMeterkey.AutoSize = true;
            this.lblMeterkey.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMeterkey.Location = new System.Drawing.Point(5, 5);
            this.lblMeterkey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMeterkey.Name = "lblMeterkey";
            this.lblMeterkey.Size = new System.Drawing.Size(83, 12);
            this.lblMeterkey.TabIndex = 0;
            this.lblMeterkey.Text = "Meter Name :";
            // 
            // pnlConnectSetting
            // 
            this.pnlConnectSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnectSetting.Location = new System.Drawing.Point(10, 66);
            this.pnlConnectSetting.Name = "pnlConnectSetting";
            this.pnlConnectSetting.Size = new System.Drawing.Size(548, 321);
            this.pnlConnectSetting.TabIndex = 1;
            // 
            // pnlControl
            // 
            this.pnlControl.ColumnCount = 5;
            this.pnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlControl.Controls.Add(this.btAddConfig, 0, 0);
            this.pnlControl.Controls.Add(this.btShowConfigs, 2, 0);
            this.pnlControl.Controls.Add(this.btClose, 4, 0);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(10, 387);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.RowCount = 1;
            this.pnlControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlControl.Size = new System.Drawing.Size(548, 43);
            this.pnlControl.TabIndex = 2;
            // 
            // btAddConfig
            // 
            this.btAddConfig.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btAddConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btAddConfig.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btAddConfig.Location = new System.Drawing.Point(3, 3);
            this.btAddConfig.Name = "btAddConfig";
            this.btAddConfig.Size = new System.Drawing.Size(103, 37);
            this.btAddConfig.TabIndex = 0;
            this.btAddConfig.Text = "Add Config";
            this.btAddConfig.Click += new System.EventHandler(this.btAddConfig_Click);
            // 
            // btShowConfigs
            // 
            this.btShowConfigs.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btShowConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btShowConfigs.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btShowConfigs.Location = new System.Drawing.Point(221, 3);
            this.btShowConfigs.Name = "btShowConfigs";
            this.btShowConfigs.Size = new System.Drawing.Size(103, 37);
            this.btShowConfigs.TabIndex = 1;
            this.btShowConfigs.Text = "Show Configs";
            this.btShowConfigs.Click += new System.EventHandler(this.btShowConfigs_Click);
            // 
            // btClose
            // 
            this.btClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClose.Location = new System.Drawing.Point(439, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(106, 37);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // FrmConfigSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 434);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlConnectSetting);
            this.Controls.Add(this.pnlConfigKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmConfigSetting";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ConfigSetting";
            this.pnlConfigKey.ResumeLayout(false);
            this.pnlConfigKey.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConfigKey;
        private System.Windows.Forms.Label lblConnectType;
        private System.Windows.Forms.ComboBox cbMeterModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtMeterName;
        private System.Windows.Forms.Label lblMeterkey;
        private System.Windows.Forms.ComboBox cbConnectType;
        private System.Windows.Forms.Panel pnlConnectSetting;
        private System.Windows.Forms.TableLayoutPanel pnlControl;
        private DevExpress.XtraEditors.SimpleButton btAddConfig;
        private DevExpress.XtraEditors.SimpleButton btShowConfigs;
        private DevExpress.XtraEditors.SimpleButton btClose;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.TextBox txtIntervalTime;
        private System.Windows.Forms.Label lblInterTime;

        #region Private Methods
        

        #endregion
    }
}