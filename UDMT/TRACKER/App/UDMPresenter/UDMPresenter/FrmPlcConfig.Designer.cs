namespace UDMPresenter
{
    partial class FrmPlcConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlcConfig));
            this.grpSaveLogPath = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spnLogFileSaveTime = new DevExpress.XtraEditors.SpinEdit();
            this.btnChangePath = new DevExpress.XtraEditors.SimpleButton();
            this.txtLogPath = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ucConnectSetMxCom4 = new UDM.DDEA.UCConnectSetMxCom4();
            this.ucConnectionTest = new UDM.DDEA.UCConnectionTest();
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).BeginInit();
            this.grpSaveLogPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
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
            this.grpSaveLogPath.TabIndex = 3;
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 87);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ucConnectSetMxCom4);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.ucConnectionTest);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(491, 675);
            this.splitContainerControl1.SplitterPosition = 115;
            this.splitContainerControl1.TabIndex = 6;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // ucConnectSetMxCom4
            // 
            this.ucConnectSetMxCom4.Config = null;
            this.ucConnectSetMxCom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectSetMxCom4.Location = new System.Drawing.Point(0, 0);
            this.ucConnectSetMxCom4.Name = "ucConnectSetMxCom4";
            this.ucConnectSetMxCom4.SelectedIndex = -1;
            this.ucConnectSetMxCom4.Size = new System.Drawing.Size(491, 115);
            this.ucConnectSetMxCom4.TabIndex = 6;
            // 
            // ucConnectionTest
            // 
            this.ucConnectionTest.Config = null;
            this.ucConnectionTest.ConnectSuccess = false;
            this.ucConnectionTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectionTest.Location = new System.Drawing.Point(0, 0);
            this.ucConnectionTest.Name = "ucConnectionTest";
            this.ucConnectionTest.Size = new System.Drawing.Size(491, 555);
            this.ucConnectionTest.TabIndex = 7;
            // 
            // FrmPlcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 762);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.grpSaveLogPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlcConfig";
            this.Text = "PLC 통신 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlcConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmPlcConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).EndInit();
            this.grpSaveLogPath.ResumeLayout(false);
            this.grpSaveLogPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private UDM.DDEA.UCConnectSetMxCom4 ucConnectSetMxCom4;
        private UDM.DDEA.UCConnectionTest ucConnectionTest;



    }
}