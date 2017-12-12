namespace UDM.EnergyDaq.Config
{
    partial class UCSerialPortSetting
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
            this.gpbSerialPortSetting = new System.Windows.Forms.GroupBox();
            this.cbStopBit = new System.Windows.Forms.ComboBox();
            this.lblStopBit = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cbWriteTimeOut = new System.Windows.Forms.ComboBox();
            this.lblWriteTime = new System.Windows.Forms.Label();
            this.cbReadTime = new System.Windows.Forms.ComboBox();
            this.lblReadTime = new System.Windows.Forms.Label();
            this.cbWriteBufSize = new System.Windows.Forms.ComboBox();
            this.lblWriteBuffer = new System.Windows.Forms.Label();
            this.cbReadBufSize = new System.Windows.Forms.ComboBox();
            this.lblReadBuffer = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.lblPortName = new System.Windows.Forms.Label();
            this.gbDevice = new System.Windows.Forms.GroupBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.txtWordCount = new System.Windows.Forms.TextBox();
            this.lblWordCount = new System.Windows.Forms.Label();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.txtDeviceIndex = new System.Windows.Forms.TextBox();
            this.lblDeviceIndex = new System.Windows.Forms.Label();
            this.lblDevicName = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.gpbSerialPortSetting.SuspendLayout();
            this.gbDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbSerialPortSetting
            // 
            this.gpbSerialPortSetting.Controls.Add(this.cbStopBit);
            this.gpbSerialPortSetting.Controls.Add(this.lblStopBit);
            this.gpbSerialPortSetting.Controls.Add(this.cbParity);
            this.gpbSerialPortSetting.Controls.Add(this.lblParity);
            this.gpbSerialPortSetting.Controls.Add(this.cbWriteTimeOut);
            this.gpbSerialPortSetting.Controls.Add(this.lblWriteTime);
            this.gpbSerialPortSetting.Controls.Add(this.cbReadTime);
            this.gpbSerialPortSetting.Controls.Add(this.lblReadTime);
            this.gpbSerialPortSetting.Controls.Add(this.cbWriteBufSize);
            this.gpbSerialPortSetting.Controls.Add(this.lblWriteBuffer);
            this.gpbSerialPortSetting.Controls.Add(this.cbReadBufSize);
            this.gpbSerialPortSetting.Controls.Add(this.lblReadBuffer);
            this.gpbSerialPortSetting.Controls.Add(this.cbBaudRate);
            this.gpbSerialPortSetting.Controls.Add(this.lblBaudRate);
            this.gpbSerialPortSetting.Controls.Add(this.cbPortName);
            this.gpbSerialPortSetting.Controls.Add(this.lblPortName);
            this.gpbSerialPortSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbSerialPortSetting.Location = new System.Drawing.Point(6, 5);
            this.gpbSerialPortSetting.Name = "gpbSerialPortSetting";
            this.gpbSerialPortSetting.Size = new System.Drawing.Size(536, 150);
            this.gpbSerialPortSetting.TabIndex = 0;
            this.gpbSerialPortSetting.TabStop = false;
            this.gpbSerialPortSetting.Text = "Serial Port";
            // 
            // cbStopBit
            // 
            this.cbStopBit.FormattingEnabled = true;
            this.cbStopBit.Location = new System.Drawing.Point(416, 115);
            this.cbStopBit.Name = "cbStopBit";
            this.cbStopBit.Size = new System.Drawing.Size(98, 20);
            this.cbStopBit.TabIndex = 15;
            // 
            // lblStopBit
            // 
            this.lblStopBit.AutoSize = true;
            this.lblStopBit.Location = new System.Drawing.Point(295, 118);
            this.lblStopBit.Name = "lblStopBit";
            this.lblStopBit.Size = new System.Drawing.Size(48, 12);
            this.lblStopBit.TabIndex = 14;
            this.lblStopBit.Text = "Stop Bit";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(416, 85);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(98, 20);
            this.cbParity.TabIndex = 13;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(295, 90);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(37, 12);
            this.lblParity.TabIndex = 12;
            this.lblParity.Text = "Parity";
            // 
            // cbWriteTimeOut
            // 
            this.cbWriteTimeOut.FormattingEnabled = true;
            this.cbWriteTimeOut.Location = new System.Drawing.Point(416, 52);
            this.cbWriteTimeOut.Name = "cbWriteTimeOut";
            this.cbWriteTimeOut.Size = new System.Drawing.Size(98, 20);
            this.cbWriteTimeOut.TabIndex = 11;
            // 
            // lblWriteTime
            // 
            this.lblWriteTime.AutoSize = true;
            this.lblWriteTime.Location = new System.Drawing.Point(295, 57);
            this.lblWriteTime.Name = "lblWriteTime";
            this.lblWriteTime.Size = new System.Drawing.Size(88, 12);
            this.lblWriteTime.TabIndex = 10;
            this.lblWriteTime.Text = "Write Time Out";
            // 
            // cbReadTime
            // 
            this.cbReadTime.FormattingEnabled = true;
            this.cbReadTime.Location = new System.Drawing.Point(416, 20);
            this.cbReadTime.Name = "cbReadTime";
            this.cbReadTime.Size = new System.Drawing.Size(98, 20);
            this.cbReadTime.TabIndex = 9;
            // 
            // lblReadTime
            // 
            this.lblReadTime.AutoSize = true;
            this.lblReadTime.Location = new System.Drawing.Point(295, 25);
            this.lblReadTime.Name = "lblReadTime";
            this.lblReadTime.Size = new System.Drawing.Size(90, 12);
            this.lblReadTime.TabIndex = 8;
            this.lblReadTime.Text = "Read Time Out";
            // 
            // cbWriteBufSize
            // 
            this.cbWriteBufSize.FormattingEnabled = true;
            this.cbWriteBufSize.Location = new System.Drawing.Point(167, 115);
            this.cbWriteBufSize.Name = "cbWriteBufSize";
            this.cbWriteBufSize.Size = new System.Drawing.Size(98, 20);
            this.cbWriteBufSize.TabIndex = 7;
            // 
            // lblWriteBuffer
            // 
            this.lblWriteBuffer.AutoSize = true;
            this.lblWriteBuffer.Location = new System.Drawing.Point(30, 121);
            this.lblWriteBuffer.Name = "lblWriteBuffer";
            this.lblWriteBuffer.Size = new System.Drawing.Size(97, 12);
            this.lblWriteBuffer.TabIndex = 6;
            this.lblWriteBuffer.Text = "Write Buffer Size";
            // 
            // cbReadBufSize
            // 
            this.cbReadBufSize.FormattingEnabled = true;
            this.cbReadBufSize.Location = new System.Drawing.Point(167, 85);
            this.cbReadBufSize.Name = "cbReadBufSize";
            this.cbReadBufSize.Size = new System.Drawing.Size(98, 20);
            this.cbReadBufSize.TabIndex = 16;
            // 
            // lblReadBuffer
            // 
            this.lblReadBuffer.AutoSize = true;
            this.lblReadBuffer.Location = new System.Drawing.Point(30, 90);
            this.lblReadBuffer.Name = "lblReadBuffer";
            this.lblReadBuffer.Size = new System.Drawing.Size(99, 12);
            this.lblReadBuffer.TabIndex = 4;
            this.lblReadBuffer.Text = "Read Buffer Size";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(167, 52);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(98, 20);
            this.cbBaudRate.TabIndex = 3;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(30, 57);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(63, 12);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // cbPortName
            // 
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(167, 20);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(98, 20);
            this.cbPortName.TabIndex = 1;
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(30, 25);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(65, 12);
            this.lblPortName.TabIndex = 0;
            this.lblPortName.Text = "Port Name";
            // 
            // gbDevice
            // 
            this.gbDevice.Controls.Add(this.txtDeviceName);
            this.gbDevice.Controls.Add(this.lblDevicName);
            this.gbDevice.Controls.Add(this.btnAddDevice);
            this.gbDevice.Controls.Add(this.txtWordCount);
            this.gbDevice.Controls.Add(this.lblWordCount);
            this.gbDevice.Controls.Add(this.txtStartAddress);
            this.gbDevice.Controls.Add(this.lblStartAddress);
            this.gbDevice.Controls.Add(this.txtDeviceIndex);
            this.gbDevice.Controls.Add(this.lblDeviceIndex);
            this.gbDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDevice.Location = new System.Drawing.Point(6, 155);
            this.gbDevice.Name = "gbDevice";
            this.gbDevice.Size = new System.Drawing.Size(536, 116);
            this.gbDevice.TabIndex = 1;
            this.gbDevice.TabStop = false;
            this.gbDevice.Text = "Serial Device";
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(32, 85);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(99, 25);
            this.btnAddDevice.TabIndex = 6;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // txtWordCount
            // 
            this.txtWordCount.Location = new System.Drawing.Point(416, 47);
            this.txtWordCount.Name = "txtWordCount";
            this.txtWordCount.Size = new System.Drawing.Size(98, 21);
            this.txtWordCount.TabIndex = 5;
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Location = new System.Drawing.Point(295, 52);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(70, 12);
            this.lblWordCount.TabIndex = 4;
            this.lblWordCount.Text = "Word Count";
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(416, 20);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(98, 21);
            this.txtStartAddress.TabIndex = 3;
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.Location = new System.Drawing.Point(295, 25);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(81, 12);
            this.lblStartAddress.TabIndex = 2;
            this.lblStartAddress.Text = "Start Address";
            // 
            // txtDeviceIndex
            // 
            this.txtDeviceIndex.Location = new System.Drawing.Point(167, 47);
            this.txtDeviceIndex.Name = "txtDeviceIndex";
            this.txtDeviceIndex.Size = new System.Drawing.Size(98, 21);
            this.txtDeviceIndex.TabIndex = 1;
            // 
            // lblDeviceIndex
            // 
            this.lblDeviceIndex.AutoSize = true;
            this.lblDeviceIndex.Location = new System.Drawing.Point(30, 52);
            this.lblDeviceIndex.Name = "lblDeviceIndex";
            this.lblDeviceIndex.Size = new System.Drawing.Size(78, 12);
            this.lblDeviceIndex.TabIndex = 0;
            this.lblDeviceIndex.Text = "Device Index";
            // 
            // lblDevicName
            // 
            this.lblDevicName.AutoSize = true;
            this.lblDevicName.Location = new System.Drawing.Point(30, 25);
            this.lblDevicName.Name = "lblDevicName";
            this.lblDevicName.Size = new System.Drawing.Size(81, 12);
            this.lblDevicName.TabIndex = 7;
            this.lblDevicName.Text = "Device Name";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(167, 20);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(98, 21);
            this.txtDeviceName.TabIndex = 8;
            // 
            // UCSerialPortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDevice);
            this.Controls.Add(this.gpbSerialPortSetting);
            this.Name = "UCSerialPortSetting";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(548, 279);
            this.gpbSerialPortSetting.ResumeLayout(false);
            this.gpbSerialPortSetting.PerformLayout();
            this.gbDevice.ResumeLayout(false);
            this.gbDevice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSerialPortSetting;
        private System.Windows.Forms.Label lblWriteBuffer;
        private System.Windows.Forms.ComboBox cbReadBufSize;
        private System.Windows.Forms.Label lblReadBuffer;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.ComboBox cbStopBit;
        private System.Windows.Forms.Label lblStopBit;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cbWriteTimeOut;
        private System.Windows.Forms.Label lblWriteTime;
        private System.Windows.Forms.ComboBox cbReadTime;
        private System.Windows.Forms.Label lblReadTime;
        private System.Windows.Forms.ComboBox cbWriteBufSize;
        private System.Windows.Forms.GroupBox gbDevice;
        private System.Windows.Forms.TextBox txtDeviceIndex;
        private System.Windows.Forms.Label lblDeviceIndex;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.TextBox txtWordCount;
        private System.Windows.Forms.Label lblWordCount;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label lblDevicName;
    }
}
