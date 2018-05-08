namespace IOTLManager.UserControls
{
    partial class UCConfigIOTLinkManager
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCompServerDBAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnCompServerLogFind = new System.Windows.Forms.Button();
            this.txtCompServerLogFolder = new System.Windows.Forms.TextBox();
            this.txtCompServerDBPort = new System.Windows.Forms.TextBox();
            this.txtCompServerPort = new System.Windows.Forms.TextBox();
            this.txtCompServerDBUserPw = new System.Windows.Forms.TextBox();
            this.txtCompServerDBUserID = new System.Windows.Forms.TextBox();
            this.txtCompServerDBName = new System.Windows.Forms.TextBox();
            this.txtCompServerIPAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSmartBongServerPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSmartBongServerPort);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCompServerDBAddr);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnLoadConfig);
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.btnCompServerLogFind);
            this.groupBox1.Controls.Add(this.txtCompServerLogFolder);
            this.groupBox1.Controls.Add(this.txtCompServerDBPort);
            this.groupBox1.Controls.Add(this.txtCompServerPort);
            this.groupBox1.Controls.Add(this.txtCompServerDBUserPw);
            this.groupBox1.Controls.Add(this.txtCompServerDBUserID);
            this.groupBox1.Controls.Add(this.txtCompServerDBName);
            this.groupBox1.Controls.Add(this.txtCompServerIPAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 304);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comp Server";
            // 
            // txtCompServerDBAddr
            // 
            this.txtCompServerDBAddr.Location = new System.Drawing.Point(141, 189);
            this.txtCompServerDBAddr.Name = "txtCompServerDBAddr";
            this.txtCompServerDBAddr.Size = new System.Drawing.Size(226, 21);
            this.txtCompServerDBAddr.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "DB IP";
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Image = global::IOTLManager.Properties.Resources.Technology_32x32;
            this.btnLoadConfig.Location = new System.Drawing.Point(480, 215);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(61, 62);
            this.btnLoadConfig.TabIndex = 8;
            this.btnLoadConfig.Text = "Load";
            this.btnLoadConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Image = global::IOTLManager.Properties.Resources.SavePageSetup_32x32;
            this.btnSaveConfig.Location = new System.Drawing.Point(380, 215);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(61, 62);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnCompServerLogFind
            // 
            this.btnCompServerLogFind.Image = global::IOTLManager.Properties.Resources.Up_16x16;
            this.btnCompServerLogFind.Location = new System.Drawing.Point(373, 114);
            this.btnCompServerLogFind.Name = "btnCompServerLogFind";
            this.btnCompServerLogFind.Size = new System.Drawing.Size(40, 21);
            this.btnCompServerLogFind.TabIndex = 2;
            this.btnCompServerLogFind.UseVisualStyleBackColor = true;
            this.btnCompServerLogFind.Click += new System.EventHandler(this.btnCompServerLogFind_Click);
            // 
            // txtCompServerLogFolder
            // 
            this.txtCompServerLogFolder.AllowDrop = true;
            this.txtCompServerLogFolder.Location = new System.Drawing.Point(86, 114);
            this.txtCompServerLogFolder.Name = "txtCompServerLogFolder";
            this.txtCompServerLogFolder.Size = new System.Drawing.Size(281, 21);
            this.txtCompServerLogFolder.TabIndex = 2;
            // 
            // txtCompServerDBPort
            // 
            this.txtCompServerDBPort.Location = new System.Drawing.Point(142, 218);
            this.txtCompServerDBPort.Name = "txtCompServerDBPort";
            this.txtCompServerDBPort.Size = new System.Drawing.Size(84, 21);
            this.txtCompServerDBPort.TabIndex = 4;
            // 
            // txtCompServerPort
            // 
            this.txtCompServerPort.AllowDrop = true;
            this.txtCompServerPort.Location = new System.Drawing.Point(330, 28);
            this.txtCompServerPort.Name = "txtCompServerPort";
            this.txtCompServerPort.Size = new System.Drawing.Size(84, 21);
            this.txtCompServerPort.TabIndex = 1;
            // 
            // txtCompServerDBUserPw
            // 
            this.txtCompServerDBUserPw.Location = new System.Drawing.Point(141, 274);
            this.txtCompServerDBUserPw.MaxLength = 20;
            this.txtCompServerDBUserPw.Name = "txtCompServerDBUserPw";
            this.txtCompServerDBUserPw.PasswordChar = '*';
            this.txtCompServerDBUserPw.Size = new System.Drawing.Size(226, 21);
            this.txtCompServerDBUserPw.TabIndex = 6;
            // 
            // txtCompServerDBUserID
            // 
            this.txtCompServerDBUserID.Location = new System.Drawing.Point(141, 246);
            this.txtCompServerDBUserID.MaxLength = 20;
            this.txtCompServerDBUserID.Name = "txtCompServerDBUserID";
            this.txtCompServerDBUserID.Size = new System.Drawing.Size(226, 21);
            this.txtCompServerDBUserID.TabIndex = 5;
            // 
            // txtCompServerDBName
            // 
            this.txtCompServerDBName.Location = new System.Drawing.Point(141, 162);
            this.txtCompServerDBName.Name = "txtCompServerDBName";
            this.txtCompServerDBName.Size = new System.Drawing.Size(226, 21);
            this.txtCompServerDBName.TabIndex = 3;
            // 
            // txtCompServerIPAddress
            // 
            this.txtCompServerIPAddress.AllowDrop = true;
            this.txtCompServerIPAddress.Location = new System.Drawing.Point(86, 28);
            this.txtCompServerIPAddress.Name = "txtCompServerIPAddress";
            this.txtCompServerIPAddress.Size = new System.Drawing.Size(166, 21);
            this.txtCompServerIPAddress.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "LOG Dir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "DB PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "DB사용자 PW";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "DB사용자 ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "데이터베이스이름";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 491);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "스봉서버PORT";
            // 
            // txtSmartBongServerPort
            // 
            this.txtSmartBongServerPort.AllowDrop = true;
            this.txtSmartBongServerPort.Location = new System.Drawing.Point(329, 69);
            this.txtSmartBongServerPort.Name = "txtSmartBongServerPort";
            this.txtSmartBongServerPort.Size = new System.Drawing.Size(84, 21);
            this.txtSmartBongServerPort.TabIndex = 12;
            // 
            // UCConfigIOTLinkManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCConfigIOTLinkManager";
            this.Size = new System.Drawing.Size(777, 491);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCompServerLogFind;
        private System.Windows.Forms.TextBox txtCompServerLogFolder;
        private System.Windows.Forms.TextBox txtCompServerPort;
        private System.Windows.Forms.TextBox txtCompServerIPAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCompServerDBUserPw;
        private System.Windows.Forms.TextBox txtCompServerDBUserID;
        private System.Windows.Forms.TextBox txtCompServerDBName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.TextBox txtCompServerDBPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompServerDBAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSmartBongServerPort;
        private System.Windows.Forms.Label label9;
    }
}
