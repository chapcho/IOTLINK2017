namespace IOTLManager.UserControls
{
    partial class UCSocketServer
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSendPacket = new System.Windows.Forms.TextBox();
            this.txtReceivePacket = new System.Windows.Forms.TextBox();
            this.txtConnected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeverStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSendPacket);
            this.splitContainer1.Panel1.Controls.Add(this.txtReceivePacket);
            this.splitContainer1.Panel1.Controls.Add(this.txtConnected);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSeverStart);
            this.splitContainer1.Panel2.Controls.Add(this.btnServerStop);
            this.splitContainer1.Size = new System.Drawing.Size(279, 230);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtSendPacket
            // 
            this.txtSendPacket.Location = new System.Drawing.Point(167, 66);
            this.txtSendPacket.Name = "txtSendPacket";
            this.txtSendPacket.ReadOnly = true;
            this.txtSendPacket.Size = new System.Drawing.Size(99, 21);
            this.txtSendPacket.TabIndex = 1;
            this.txtSendPacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReceivePacket
            // 
            this.txtReceivePacket.Location = new System.Drawing.Point(167, 39);
            this.txtReceivePacket.Name = "txtReceivePacket";
            this.txtReceivePacket.ReadOnly = true;
            this.txtReceivePacket.Size = new System.Drawing.Size(99, 21);
            this.txtReceivePacket.TabIndex = 1;
            this.txtReceivePacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtConnected
            // 
            this.txtConnected.Location = new System.Drawing.Point(167, 12);
            this.txtConnected.Name = "txtConnected";
            this.txtConnected.ReadOnly = true;
            this.txtConnected.Size = new System.Drawing.Size(99, 21);
            this.txtConnected.TabIndex = 1;
            this.txtConnected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "■ Send Packets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "■ Receive Packets";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "■ Connected Clients";
            // 
            // btnSeverStart
            // 
            this.btnSeverStart.Location = new System.Drawing.Point(128, 21);
            this.btnSeverStart.Name = "btnSeverStart";
            this.btnSeverStart.Size = new System.Drawing.Size(68, 57);
            this.btnSeverStart.TabIndex = 1;
            this.btnSeverStart.Text = "서버시작";
            this.btnSeverStart.UseVisualStyleBackColor = true;
            this.btnSeverStart.Click += new System.EventHandler(this.btnSeverStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(202, 21);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(64, 57);
            this.btnServerStop.TabIndex = 1;
            this.btnServerStop.Text = "서버중지";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // UCSocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UCSocketServer";
            this.Size = new System.Drawing.Size(279, 230);
            this.Load += new System.EventHandler(this.UCSocketServer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSeverStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.TextBox txtSendPacket;
        private System.Windows.Forms.TextBox txtReceivePacket;
        private System.Windows.Forms.TextBox txtConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
