namespace UDM.EnergyDaq.Config
{
    partial class UCEthernetSetting
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
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtStartAdd = new System.Windows.Forms.TextBox();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.txtWordCount = new System.Windows.Forms.TextBox();
            this.gpbDataBlock = new System.Windows.Forms.GroupBox();
            this.lblDataBlockCount = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblChannelCount = new System.Windows.Forms.Label();
            this.NUDChannel = new System.Windows.Forms.NumericUpDown();
            this.gpbDataBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDChannel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIPAddress.Location = new System.Drawing.Point(21, 21);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(72, 17);
            this.lblIPAddress.TabIndex = 0;
            this.lblIPAddress.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPort.Location = new System.Drawing.Point(21, 53);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 17);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port No.";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(149, 17);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(131, 21);
            this.txtIpAddress.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(149, 50);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(131, 21);
            this.txtPort.TabIndex = 3;
            // 
            // txtStartAdd
            // 
            this.txtStartAdd.Location = new System.Drawing.Point(139, 20);
            this.txtStartAdd.Name = "txtStartAdd";
            this.txtStartAdd.Size = new System.Drawing.Size(154, 21);
            this.txtStartAdd.TabIndex = 4;
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStartAddress.Location = new System.Drawing.Point(13, 25);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(90, 17);
            this.lblStartAddress.TabIndex = 5;
            this.lblStartAddress.Text = "Start Address";
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblWordCount.Location = new System.Drawing.Point(13, 59);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(85, 17);
            this.lblWordCount.TabIndex = 6;
            this.lblWordCount.Text = "Word Count";
            // 
            // txtWordCount
            // 
            this.txtWordCount.Location = new System.Drawing.Point(139, 53);
            this.txtWordCount.Name = "txtWordCount";
            this.txtWordCount.Size = new System.Drawing.Size(154, 21);
            this.txtWordCount.TabIndex = 7;
            // 
            // gpbDataBlock
            // 
            this.gpbDataBlock.Controls.Add(this.lblDataBlockCount);
            this.gpbDataBlock.Controls.Add(this.btnAdd);
            this.gpbDataBlock.Controls.Add(this.txtStartAdd);
            this.gpbDataBlock.Controls.Add(this.txtWordCount);
            this.gpbDataBlock.Controls.Add(this.lblStartAddress);
            this.gpbDataBlock.Controls.Add(this.lblWordCount);
            this.gpbDataBlock.Location = new System.Drawing.Point(24, 87);
            this.gpbDataBlock.Name = "gpbDataBlock";
            this.gpbDataBlock.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gpbDataBlock.Size = new System.Drawing.Size(323, 130);
            this.gpbDataBlock.TabIndex = 8;
            this.gpbDataBlock.TabStop = false;
            this.gpbDataBlock.Text = "Data Block";
            // 
            // lblDataBlockCount
            // 
            this.lblDataBlockCount.AutoSize = true;
            this.lblDataBlockCount.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDataBlockCount.Location = new System.Drawing.Point(14, 100);
            this.lblDataBlockCount.Name = "lblDataBlockCount";
            this.lblDataBlockCount.Size = new System.Drawing.Size(136, 14);
            this.lblDataBlockCount.TabIndex = 9;
            this.lblDataBlockCount.Text = "Data Block Count :     0";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(197, 97);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblChannelCount
            // 
            this.lblChannelCount.AutoSize = true;
            this.lblChannelCount.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChannelCount.Location = new System.Drawing.Point(322, 54);
            this.lblChannelCount.Name = "lblChannelCount";
            this.lblChannelCount.Size = new System.Drawing.Size(97, 12);
            this.lblChannelCount.TabIndex = 9;
            this.lblChannelCount.Text = "ChannelCount";
            // 
            // NUDChannel
            // 
            this.NUDChannel.Location = new System.Drawing.Point(442, 49);
            this.NUDChannel.Name = "NUDChannel";
            this.NUDChannel.Size = new System.Drawing.Size(72, 21);
            this.NUDChannel.TabIndex = 10;
            this.NUDChannel.ValueChanged += new System.EventHandler(this.NUDChannel_ValueChanged);
            // 
            // UCEthernetSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NUDChannel);
            this.Controls.Add(this.lblChannelCount);
            this.Controls.Add(this.gpbDataBlock);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIPAddress);
            this.Name = "UCEthernetSetting";
            this.Size = new System.Drawing.Size(548, 250);
            this.gpbDataBlock.ResumeLayout(false);
            this.gpbDataBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDChannel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtStartAdd;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.TextBox txtWordCount;
        private System.Windows.Forms.GroupBox gpbDataBlock;
        private System.Windows.Forms.Label lblDataBlockCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblChannelCount;
        private System.Windows.Forms.NumericUpDown NUDChannel;
    }
}
