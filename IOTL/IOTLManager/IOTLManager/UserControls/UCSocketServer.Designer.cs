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
            this.txtSendPacket = new System.Windows.Forms.TextBox();
            this.txtReceivePacket = new System.Windows.Forms.TextBox();
            this.txtConnected = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeverStart = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerIPAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvClientList = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSocketTransparent = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSendPacket
            // 
            this.txtSendPacket.Location = new System.Drawing.Point(422, 63);
            this.txtSendPacket.Name = "txtSendPacket";
            this.txtSendPacket.ReadOnly = true;
            this.txtSendPacket.Size = new System.Drawing.Size(99, 21);
            this.txtSendPacket.TabIndex = 1;
            this.txtSendPacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReceivePacket
            // 
            this.txtReceivePacket.Location = new System.Drawing.Point(422, 33);
            this.txtReceivePacket.Name = "txtReceivePacket";
            this.txtReceivePacket.ReadOnly = true;
            this.txtReceivePacket.Size = new System.Drawing.Size(99, 21);
            this.txtReceivePacket.TabIndex = 1;
            this.txtReceivePacket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtConnected
            // 
            this.txtConnected.Location = new System.Drawing.Point(422, 3);
            this.txtConnected.Name = "txtConnected";
            this.txtConnected.ReadOnly = true;
            this.txtConnected.Size = new System.Drawing.Size(99, 21);
            this.txtConnected.TabIndex = 1;
            this.txtConnected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "■ Send Packets";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "■ Receive Packets";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "■ Connected Clients";
            // 
            // btnSeverStart
            // 
            this.btnSeverStart.Location = new System.Drawing.Point(3, 93);
            this.btnSeverStart.Name = "btnSeverStart";
            this.btnSeverStart.Size = new System.Drawing.Size(113, 34);
            this.btnSeverStart.TabIndex = 1;
            this.btnSeverStart.Text = "서버시작";
            this.btnSeverStart.UseVisualStyleBackColor = true;
            this.btnSeverStart.Click += new System.EventHandler(this.btnSeverStart_Click);
            // 
            // btnServerStop
            // 
            this.btnServerStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServerStop.Location = new System.Drawing.Point(142, 93);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(99, 34);
            this.btnServerStop.TabIndex = 1;
            this.btnServerStop.Text = "서버중지";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.9927F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.62774F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.19708F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.73134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.64179F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtServerIPAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConnected, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtReceivePacket, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSendPacket, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtServerPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSeverStart, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnServerStop, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkSocketTransparent, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 252);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "■ Server IP";
            // 
            // txtServerIPAddress
            // 
            this.txtServerIPAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtServerIPAddress.Location = new System.Drawing.Point(141, 4);
            this.txtServerIPAddress.Name = "txtServerIPAddress";
            this.txtServerIPAddress.ReadOnly = true;
            this.txtServerIPAddress.Size = new System.Drawing.Size(100, 21);
            this.txtServerIPAddress.TabIndex = 1;
            this.txtServerIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "■ Server Port";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtServerPort.Location = new System.Drawing.Point(141, 34);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 21);
            this.txtServerPort.TabIndex = 1;
            this.txtServerPort.Text = "3000";
            this.txtServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.lvClientList);
            this.groupBox2.Location = new System.Drawing.Point(269, 93);
            this.groupBox2.Name = "groupBox2";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox2, 4);
            this.groupBox2.Size = new System.Drawing.Size(264, 156);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client List";
            // 
            // lvClientList
            // 
            this.lvClientList.BackColor = System.Drawing.SystemColors.Info;
            this.lvClientList.CheckBoxes = true;
            this.lvClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvClientList.FullRowSelect = true;
            this.lvClientList.GridLines = true;
            this.lvClientList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvClientList.Location = new System.Drawing.Point(3, 17);
            this.lvClientList.MultiSelect = false;
            this.lvClientList.Name = "lvClientList";
            this.lvClientList.Size = new System.Drawing.Size(258, 136);
            this.lvClientList.TabIndex = 0;
            this.lvClientList.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 272);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP Socket Server";
            // 
            // chkSocketTransparent
            // 
            this.chkSocketTransparent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSocketTransparent.AutoSize = true;
            this.chkSocketTransparent.Location = new System.Drawing.Point(3, 67);
            this.chkSocketTransparent.Name = "chkSocketTransparent";
            this.chkSocketTransparent.Size = new System.Drawing.Size(92, 16);
            this.chkSocketTransparent.TabIndex = 3;
            this.chkSocketTransparent.Text = "Transparent";
            this.chkSocketTransparent.UseVisualStyleBackColor = true;
            // 
            // UCSocketServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCSocketServer";
            this.Size = new System.Drawing.Size(542, 272);
            this.Load += new System.EventHandler(this.UCSocketServer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSeverStart;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.TextBox txtSendPacket;
        private System.Windows.Forms.TextBox txtReceivePacket;
        private System.Windows.Forms.TextBox txtConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerIPAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvClientList;
        private System.Windows.Forms.CheckBox chkSocketTransparent;
    }
}
