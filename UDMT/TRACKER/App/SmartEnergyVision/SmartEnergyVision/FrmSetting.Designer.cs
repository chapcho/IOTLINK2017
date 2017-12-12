namespace SmartEnergyVision
{
    partial class FrmSetting
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
            this.pnlSettingMainPanel = new System.Windows.Forms.Panel();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.cbConnectType = new System.Windows.Forms.ComboBox();
            this.lblConnectType = new System.Windows.Forms.Label();
            this.pnlButtonPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApp = new System.Windows.Forms.Button();
            this.pnlConnectSetting = new System.Windows.Forms.Panel();
            this.pnlPerSettingValue = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntervalTime = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStopRate = new System.Windows.Forms.TextBox();
            this.txtRunningRate = new System.Windows.Forms.TextBox();
            this.lblStopRate = new System.Windows.Forms.Label();
            this.lblRunRate = new System.Windows.Forms.Label();
            this.pnlSettingMainPanel.SuspendLayout();
            this.pnlButtonPanel.SuspendLayout();
            this.pnlPerSettingValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettingMainPanel
            // 
            this.pnlSettingMainPanel.Controls.Add(this.btnCreateDB);
            this.pnlSettingMainPanel.Controls.Add(this.cbConnectType);
            this.pnlSettingMainPanel.Controls.Add(this.lblConnectType);
            this.pnlSettingMainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettingMainPanel.Location = new System.Drawing.Point(10, 10);
            this.pnlSettingMainPanel.Name = "pnlSettingMainPanel";
            this.pnlSettingMainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSettingMainPanel.Size = new System.Drawing.Size(477, 33);
            this.pnlSettingMainPanel.TabIndex = 0;
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCreateDB.Location = new System.Drawing.Point(379, 5);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(93, 23);
            this.btnCreateDB.TabIndex = 2;
            this.btnCreateDB.Text = "Create DB";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // cbConnectType
            // 
            this.cbConnectType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbConnectType.FormattingEnabled = true;
            this.cbConnectType.Items.AddRange(new object[] {
            "Ethernet",
            "Serial Port",
            "Demo Data Source"});
            this.cbConnectType.Location = new System.Drawing.Point(136, 5);
            this.cbConnectType.Name = "cbConnectType";
            this.cbConnectType.Size = new System.Drawing.Size(126, 22);
            this.cbConnectType.TabIndex = 1;
            this.cbConnectType.SelectedIndexChanged += new System.EventHandler(this.cbConnectType_SelectedIndexChanged);
            // 
            // lblConnectType
            // 
            this.lblConnectType.AutoSize = true;
            this.lblConnectType.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblConnectType.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectType.Location = new System.Drawing.Point(5, 5);
            this.lblConnectType.Name = "lblConnectType";
            this.lblConnectType.Size = new System.Drawing.Size(131, 22);
            this.lblConnectType.TabIndex = 0;
            this.lblConnectType.Text = "Connect Type :";
            // 
            // pnlButtonPanel
            // 
            this.pnlButtonPanel.Controls.Add(this.btnClose);
            this.pnlButtonPanel.Controls.Add(this.btnApp);
            this.pnlButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonPanel.Location = new System.Drawing.Point(10, 439);
            this.pnlButtonPanel.Name = "pnlButtonPanel";
            this.pnlButtonPanel.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pnlButtonPanel.Size = new System.Drawing.Size(477, 29);
            this.pnlButtonPanel.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(340, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApp
            // 
            this.btnApp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApp.Location = new System.Drawing.Point(30, 0);
            this.btnApp.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(107, 29);
            this.btnApp.TabIndex = 0;
            this.btnApp.Text = "Apply";
            this.btnApp.UseVisualStyleBackColor = true;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            // 
            // pnlConnectSetting
            // 
            this.pnlConnectSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnectSetting.Location = new System.Drawing.Point(10, 43);
            this.pnlConnectSetting.Name = "pnlConnectSetting";
            this.pnlConnectSetting.Padding = new System.Windows.Forms.Padding(5);
            this.pnlConnectSetting.Size = new System.Drawing.Size(477, 305);
            this.pnlConnectSetting.TabIndex = 2;
            // 
            // pnlPerSettingValue
            // 
            this.pnlPerSettingValue.Controls.Add(this.label3);
            this.pnlPerSettingValue.Controls.Add(this.txtIntervalTime);
            this.pnlPerSettingValue.Controls.Add(this.lblInterval);
            this.pnlPerSettingValue.Controls.Add(this.label2);
            this.pnlPerSettingValue.Controls.Add(this.label1);
            this.pnlPerSettingValue.Controls.Add(this.txtStopRate);
            this.pnlPerSettingValue.Controls.Add(this.txtRunningRate);
            this.pnlPerSettingValue.Controls.Add(this.lblStopRate);
            this.pnlPerSettingValue.Controls.Add(this.lblRunRate);
            this.pnlPerSettingValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPerSettingValue.Location = new System.Drawing.Point(10, 348);
            this.pnlPerSettingValue.Name = "pnlPerSettingValue";
            this.pnlPerSettingValue.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPerSettingValue.Size = new System.Drawing.Size(477, 94);
            this.pnlPerSettingValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(269, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "ms";
            // 
            // txtIntervalTime
            // 
            this.txtIntervalTime.Location = new System.Drawing.Point(120, 61);
            this.txtIntervalTime.Name = "txtIntervalTime";
            this.txtIntervalTime.Size = new System.Drawing.Size(142, 22);
            this.txtIntervalTime.TabIndex = 7;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblInterval.Location = new System.Drawing.Point(46, 60);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(67, 17);
            this.lblInterval.TabIndex = 6;
            this.lblInterval.Text = "Interval : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(269, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "kW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(269, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "kW";
            // 
            // txtStopRate
            // 
            this.txtStopRate.Location = new System.Drawing.Point(120, 35);
            this.txtStopRate.Name = "txtStopRate";
            this.txtStopRate.Size = new System.Drawing.Size(142, 22);
            this.txtStopRate.TabIndex = 3;
            // 
            // txtRunningRate
            // 
            this.txtRunningRate.Location = new System.Drawing.Point(120, 6);
            this.txtRunningRate.Name = "txtRunningRate";
            this.txtRunningRate.Size = new System.Drawing.Size(142, 22);
            this.txtRunningRate.TabIndex = 2;
            // 
            // lblStopRate
            // 
            this.lblStopRate.AutoSize = true;
            this.lblStopRate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStopRate.Location = new System.Drawing.Point(31, 35);
            this.lblStopRate.Name = "lblStopRate";
            this.lblStopRate.Size = new System.Drawing.Size(82, 17);
            this.lblStopRate.TabIndex = 1;
            this.lblStopRate.Text = "Stop Rate : ";
            // 
            // lblRunRate
            // 
            this.lblRunRate.AutoSize = true;
            this.lblRunRate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRunRate.Location = new System.Drawing.Point(9, 9);
            this.lblRunRate.Name = "lblRunRate";
            this.lblRunRate.Size = new System.Drawing.Size(104, 17);
            this.lblRunRate.TabIndex = 0;
            this.lblRunRate.Text = "Running Rate : ";
            this.lblRunRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 478);
            this.Controls.Add(this.pnlPerSettingValue);
            this.Controls.Add(this.pnlConnectSetting);
            this.Controls.Add(this.pnlButtonPanel);
            this.Controls.Add(this.pnlSettingMainPanel);
            this.Name = "FrmSetting";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Setting";
            this.pnlSettingMainPanel.ResumeLayout(false);
            this.pnlSettingMainPanel.PerformLayout();
            this.pnlButtonPanel.ResumeLayout(false);
            this.pnlPerSettingValue.ResumeLayout(false);
            this.pnlPerSettingValue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettingMainPanel;
        private System.Windows.Forms.ComboBox cbConnectType;
        private System.Windows.Forms.Label lblConnectType;
        private System.Windows.Forms.Panel pnlButtonPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApp;
        private System.Windows.Forms.Panel pnlConnectSetting;
        private System.Windows.Forms.Panel pnlPerSettingValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStopRate;
        private System.Windows.Forms.TextBox txtRunningRate;
        private System.Windows.Forms.Label lblStopRate;
        private System.Windows.Forms.Label lblRunRate;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIntervalTime;
        private System.Windows.Forms.Button btnCreateDB;
    }
}