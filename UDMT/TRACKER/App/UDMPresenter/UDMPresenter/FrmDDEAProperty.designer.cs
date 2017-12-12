using UDM.DDEA;
namespace UDMPresenter
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
            this.ucConnectionTest = new UDM.DDEA.UCConnectionTest();
            this.ucConnectSetting = new UDM.DDEA.UCConnectSetting();
            this.tabSetting = new DevExpress.XtraTab.XtraTabControl();
            this.tpMxComp3 = new DevExpress.XtraTab.XtraTabPage();
            this.tpMxComp4 = new DevExpress.XtraTab.XtraTabPage();
            this.grpSaveLogPath = new DevExpress.XtraEditors.GroupControl();
            this.cmbMxComp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spnLogFileSaveTime = new DevExpress.XtraEditors.SpinEdit();
            this.btnChangePath = new DevExpress.XtraEditors.SimpleButton();
            this.txtLogPath = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSetting)).BeginInit();
            this.tabSetting.SuspendLayout();
            this.tpMxComp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).BeginInit();
            this.grpSaveLogPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMxComp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ucConnectionTest
            // 
            this.ucConnectionTest.Config = null;
            this.ucConnectionTest.ConnectSuccess = false;
            this.ucConnectionTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectionTest.Location = new System.Drawing.Point(278, 87);
            this.ucConnectionTest.Name = "ucConnectionTest";
            this.ucConnectionTest.Size = new System.Drawing.Size(446, 771);
            this.ucConnectionTest.TabIndex = 87;
            // 
            // ucConnectSetting
            // 
            this.ucConnectSetting.Config = null;
            this.ucConnectSetting.DataChange = false;
            this.ucConnectSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectSetting.Location = new System.Drawing.Point(0, 0);
            this.ucConnectSetting.Name = "ucConnectSetting";
            this.ucConnectSetting.Size = new System.Drawing.Size(272, 742);
            this.ucConnectSetting.TabIndex = 85;
            // 
            // tabSetting
            // 
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSetting.Location = new System.Drawing.Point(0, 87);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedTabPage = this.tpMxComp3;
            this.tabSetting.Size = new System.Drawing.Size(278, 771);
            this.tabSetting.TabIndex = 88;
            this.tabSetting.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMxComp3,
            this.tpMxComp4});
            // 
            // tpMxComp3
            // 
            this.tpMxComp3.Controls.Add(this.ucConnectSetting);
            this.tpMxComp3.Name = "tpMxComp3";
            this.tpMxComp3.Size = new System.Drawing.Size(272, 742);
            this.tpMxComp3.Text = "Q Series";
            // 
            // tpMxComp4
            // 
            this.tpMxComp4.Name = "tpMxComp4";
            this.tpMxComp4.Size = new System.Drawing.Size(272, 742);
            this.tpMxComp4.Text = "R Series";
            // 
            // grpSaveLogPath
            // 
            this.grpSaveLogPath.Controls.Add(this.cmbMxComp);
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
            this.grpSaveLogPath.Size = new System.Drawing.Size(724, 87);
            this.grpSaveLogPath.TabIndex = 89;
            this.grpSaveLogPath.Text = "로그 저장 설정";
            // 
            // cmbMxComp
            // 
            this.cmbMxComp.EditValue = "Q Series Under";
            this.cmbMxComp.Location = new System.Drawing.Point(503, 31);
            this.cmbMxComp.Name = "cmbMxComp";
            this.cmbMxComp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMxComp.Properties.Items.AddRange(new object[] {
            "Q Series Under",
            "R Series"});
            this.cmbMxComp.Size = new System.Drawing.Size(209, 20);
            this.cmbMxComp.TabIndex = 8;
            this.cmbMxComp.SelectedIndexChanged += new System.EventHandler(this.cmbMxComp_SelectedIndexChanged);
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
            this.txtProjectName.Size = new System.Drawing.Size(403, 20);
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
            this.labelControl3.Location = new System.Drawing.Point(589, 60);
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
            this.spnLogFileSaveTime.Location = new System.Drawing.Point(647, 57);
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
            this.btnChangePath.Location = new System.Drawing.Point(503, 57);
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
            this.txtLogPath.Size = new System.Drawing.Size(403, 20);
            this.txtLogPath.TabIndex = 0;
            // 
            // FrmDDEAProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 858);
            this.Controls.Add(this.ucConnectionTest);
            this.Controls.Add(this.tabSetting);
            this.Controls.Add(this.grpSaveLogPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 680);
            this.Name = "FrmDDEAProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "통신 환경 설정 ( Melsec )";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDDEAProperty_FormClosing);
            this.Load += new System.EventHandler(this.FrmDDEAProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabSetting)).EndInit();
            this.tabSetting.ResumeLayout(false);
            this.tpMxComp3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSaveLogPath)).EndInit();
            this.grpSaveLogPath.ResumeLayout(false);
            this.grpSaveLogPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMxComp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnLogFileSaveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UDM.DDEA.UCConnectionTest ucConnectionTest;
        private UDM.DDEA.UCConnectSetting ucConnectSetting;
        private DevExpress.XtraTab.XtraTabControl tabSetting;
        private DevExpress.XtraTab.XtraTabPage tpMxComp3;
        private DevExpress.XtraTab.XtraTabPage tpMxComp4;
        private DevExpress.XtraEditors.GroupControl grpSaveLogPath;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spnLogFileSaveTime;
        private DevExpress.XtraEditors.SimpleButton btnChangePath;
        private DevExpress.XtraEditors.TextEdit txtLogPath;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMxComp;

    }
}