namespace UDMPresenter
{
    partial class FrmOpcConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpcConfig));
            this.grpSaveLogPath = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spnLogFileSaveTime = new DevExpress.XtraEditors.SpinEdit();
            this.btnChangePath = new DevExpress.XtraEditors.SimpleButton();
            this.txtLogPath = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbChannelList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spnUpdateRate = new DevExpress.XtraEditors.SpinEdit();
            this.cmbServerList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).BeginInit();
            this.grpSaveLogPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpdateRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSaveLogPath
            // 
            this.grpSaveLogPath.Controls.Add(this.labelControl5);
            this.grpSaveLogPath.Controls.Add(this.txtProjectName);
            this.grpSaveLogPath.Controls.Add(this.labelControl4);
            this.grpSaveLogPath.Controls.Add(this.labelControl3);
            this.grpSaveLogPath.Controls.Add(this.spnLogFileSaveTime);
            this.grpSaveLogPath.Controls.Add(this.btnChangePath);
            this.grpSaveLogPath.Controls.Add(this.txtLogPath);
            this.grpSaveLogPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSaveLogPath.Location = new System.Drawing.Point(0, 0);
            this.grpSaveLogPath.Name = "grpSaveLogPath";
            this.grpSaveLogPath.Size = new System.Drawing.Size(491, 87);
            this.grpSaveLogPath.TabIndex = 4;
            this.grpSaveLogPath.Text = "로그 저장 설정";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "프로젝트 이름";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(94, 31);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(245, 20);
            this.txtProjectName.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "저장 경로";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(418, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "저장 주기";
            // 
            // spnLogFileSaveTime
            // 
            this.spnLogFileSaveTime.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnLogFileSaveTime.Location = new System.Drawing.Point(414, 57);
            this.spnLogFileSaveTime.Name = "spnLogFileSaveTime";
            this.spnLogFileSaveTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnLogFileSaveTime.Properties.IsFloatValue = false;
            this.spnLogFileSaveTime.Properties.Mask.EditMask = "N00";
            this.spnLogFileSaveTime.Properties.MaxValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spnLogFileSaveTime.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnLogFileSaveTime.Size = new System.Drawing.Size(65, 20);
            this.spnLogFileSaveTime.TabIndex = 2;
            // 
            // btnChangePath
            // 
            this.btnChangePath.Location = new System.Drawing.Point(345, 56);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.Size = new System.Drawing.Size(63, 21);
            this.btnChangePath.TabIndex = 1;
            this.btnChangePath.Text = "변경";
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(94, 57);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(245, 20);
            this.txtLogPath.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnConnect);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.cmbChannelList);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spnUpdateRate);
            this.groupControl1.Controls.Add(this.cmbServerList);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 87);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(491, 138);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "OPC Server 설정";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 81);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(106, 14);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Channel/Device List";
            // 
            // cmbChannelList
            // 
            this.cmbChannelList.Location = new System.Drawing.Point(8, 101);
            this.cmbChannelList.Name = "cmbChannelList";
            this.cmbChannelList.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbChannelList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbChannelList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChannelList.Size = new System.Drawing.Size(360, 20);
            this.cmbChannelList.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(414, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Update Rate";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Server List";
            // 
            // spnUpdateRate
            // 
            this.spnUpdateRate.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnUpdateRate.Location = new System.Drawing.Point(388, 48);
            this.spnUpdateRate.Name = "spnUpdateRate";
            this.spnUpdateRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnUpdateRate.Properties.IsFloatValue = false;
            this.spnUpdateRate.Properties.Mask.EditMask = "N00";
            this.spnUpdateRate.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spnUpdateRate.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnUpdateRate.Size = new System.Drawing.Size(91, 20);
            this.spnUpdateRate.TabIndex = 3;
            // 
            // cmbServerList
            // 
            this.cmbServerList.Location = new System.Drawing.Point(8, 48);
            this.cmbServerList.Name = "cmbServerList";
            this.cmbServerList.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbServerList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbServerList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServerList.Size = new System.Drawing.Size(360, 20);
            this.cmbServerList.TabIndex = 0;
            this.cmbServerList.SelectedIndexChanged += new System.EventHandler(this.cmbServerList_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(388, 97);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 28);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect Test";
            this.btnConnect.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmOpcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 226);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpSaveLogPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpcConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPC Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpcConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmOpcConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).EndInit();
            this.grpSaveLogPath.ResumeLayout(false);
            this.grpSaveLogPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpdateRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpSaveLogPath;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spnLogFileSaveTime;
        private DevExpress.XtraEditors.SimpleButton btnChangePath;
        private DevExpress.XtraEditors.TextEdit txtLogPath;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spnUpdateRate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbServerList;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbChannelList;
        private DevExpress.XtraEditors.SimpleButton btnConnect;

    }
}