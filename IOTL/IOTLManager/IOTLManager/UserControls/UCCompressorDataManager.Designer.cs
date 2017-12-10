namespace IOTLManager.UserControls
{
    partial class UCCompressorDataManager
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
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.ucSocketServer1 = new IOTL.Common.UserControls.UCSocketServer();
            this.chkWebCntlSendTimer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timerWebCntlSender = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(551, 4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(178, 40);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Monitor Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // ucSocketServer1
            // 
            this.ucSocketServer1.BackColor = System.Drawing.Color.Aquamarine;
            this.ucSocketServer1.ConnectedClientCount = 0;
            this.ucSocketServer1.Location = new System.Drawing.Point(3, 3);
            this.ucSocketServer1.Name = "ucSocketServer1";
            this.ucSocketServer1.ReceivedPacketCount = 0;
            this.ucSocketServer1.SendPacketCount = 0;
            this.ucSocketServer1.ServerCaption = "TCP Socket Server";
            this.ucSocketServer1.Size = new System.Drawing.Size(542, 340);
            this.ucSocketServer1.SocketServerIsStarted = false;
            this.ucSocketServer1.TabIndex = 0;
            // 
            // chkWebCntlSendTimer
            // 
            this.chkWebCntlSendTimer.AutoSize = true;
            this.chkWebCntlSendTimer.Location = new System.Drawing.Point(6, 20);
            this.chkWebCntlSendTimer.Name = "chkWebCntlSendTimer";
            this.chkWebCntlSendTimer.Size = new System.Drawing.Size(108, 16);
            this.chkWebCntlSendTimer.TabIndex = 2;
            this.chkWebCntlSendTimer.Text = "웹제어명령전송";
            this.chkWebCntlSendTimer.UseVisualStyleBackColor = true;
            this.chkWebCntlSendTimer.CheckedChanged += new System.EventHandler(this.chkWebCntlSendTimer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkWebCntlSendTimer);
            this.groupBox1.Location = new System.Drawing.Point(555, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "제어 방식";
            // 
            // timerWebCntlSender
            // 
            this.timerWebCntlSender.Tick += new System.EventHandler(this.timerWebCntlSender_Tick);
            // 
            // UCCompressorDataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.ucSocketServer1);
            this.Name = "UCCompressorDataManager";
            this.Size = new System.Drawing.Size(732, 346);
            this.Load += new System.EventHandler(this.UCCompressorDataManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IOTL.Common.UserControls.UCSocketServer ucSocketServer1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.CheckBox chkWebCntlSendTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timerWebCntlSender;
    }
}
