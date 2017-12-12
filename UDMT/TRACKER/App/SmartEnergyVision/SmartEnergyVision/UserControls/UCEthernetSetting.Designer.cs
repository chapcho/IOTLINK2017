namespace SmartEnergyVision
{
    partial class UCEthernetSetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
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
            this.gpbDataBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIPAddress.Location = new System.Drawing.Point(18, 21);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(72, 17);
            this.lblIPAddress.TabIndex = 0;
            this.lblIPAddress.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPort.Location = new System.Drawing.Point(18, 53);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 17);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port No.";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(128, 17);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(133, 21);
            this.txtIpAddress.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(128, 50);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(133, 21);
            this.txtPort.TabIndex = 3;
            // 
            // txtStartAdd
            // 
            this.txtStartAdd.Location = new System.Drawing.Point(119, 20);
            this.txtStartAdd.Name = "txtStartAdd";
            this.txtStartAdd.Size = new System.Drawing.Size(133, 21);
            this.txtStartAdd.TabIndex = 4;
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStartAddress.Location = new System.Drawing.Point(11, 25);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(90, 17);
            this.lblStartAddress.TabIndex = 5;
            this.lblStartAddress.Text = "Start Address";
            // 
            // lblWordCount
            // 
            this.lblWordCount.AutoSize = true;
            this.lblWordCount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblWordCount.Location = new System.Drawing.Point(11, 59);
            this.lblWordCount.Name = "lblWordCount";
            this.lblWordCount.Size = new System.Drawing.Size(85, 17);
            this.lblWordCount.TabIndex = 6;
            this.lblWordCount.Text = "Word Count";
            // 
            // txtWordCount
            // 
            this.txtWordCount.Location = new System.Drawing.Point(119, 53);
            this.txtWordCount.Name = "txtWordCount";
            this.txtWordCount.Size = new System.Drawing.Size(133, 21);
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
            this.gpbDataBlock.Location = new System.Drawing.Point(21, 87);
            this.gpbDataBlock.Name = "gpbDataBlock";
            this.gpbDataBlock.Padding = new System.Windows.Forms.Padding(5);
            this.gpbDataBlock.Size = new System.Drawing.Size(277, 130);
            this.gpbDataBlock.TabIndex = 8;
            this.gpbDataBlock.TabStop = false;
            this.gpbDataBlock.Text = "Data Block";
            // 
            // lblDataBlockCount
            // 
            this.lblDataBlockCount.AutoSize = true;
            this.lblDataBlockCount.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDataBlockCount.Location = new System.Drawing.Point(12, 100);
            this.lblDataBlockCount.Name = "lblDataBlockCount";
            this.lblDataBlockCount.Size = new System.Drawing.Size(136, 14);
            this.lblDataBlockCount.TabIndex = 9;
            this.lblDataBlockCount.Text = "Data Block Count :     0";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(169, 97);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // UCEthernetSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbDataBlock);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIPAddress);
            this.Name = "UCEthernetSetting";
            this.Size = new System.Drawing.Size(470, 250);
            this.gpbDataBlock.ResumeLayout(false);
            this.gpbDataBlock.PerformLayout();
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
    }
}
