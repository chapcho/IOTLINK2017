namespace UDM.EnergyDaq.Config
{
    partial class FrmConfigShow
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
            this.dgvConfigShow = new System.Windows.Forms.DataGridView();
            this.colMeterkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConnectType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMeterModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWordCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConfigShow
            // 
            this.dgvConfigShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMeterkey,
            this.colConnectType,
            this.colMeterModel,
            this.colPort,
            this.colChannel,
            this.colStartAddress,
            this.colWordCount,
            this.colInterTime});
            this.dgvConfigShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfigShow.Location = new System.Drawing.Point(5, 5);
            this.dgvConfigShow.Name = "dgvConfigShow";
            this.dgvConfigShow.RowTemplate.Height = 23;
            this.dgvConfigShow.Size = new System.Drawing.Size(845, 511);
            this.dgvConfigShow.TabIndex = 0;
            // 
            // colMeterkey
            // 
            this.colMeterkey.HeaderText = "Meter Key";
            this.colMeterkey.Name = "colMeterkey";
            // 
            // colConnectType
            // 
            this.colConnectType.HeaderText = "ConnectType";
            this.colConnectType.Name = "colConnectType";
            // 
            // colMeterModel
            // 
            this.colMeterModel.HeaderText = "Meter Model";
            this.colMeterModel.Name = "colMeterModel";
            // 
            // colPort
            // 
            this.colPort.HeaderText = "Port(IP/Serial)";
            this.colPort.Name = "colPort";
            // 
            // colChannel
            // 
            this.colChannel.HeaderText = "Channel Count";
            this.colChannel.Name = "colChannel";
            // 
            // colStartAddress
            // 
            this.colStartAddress.HeaderText = "Start Address";
            this.colStartAddress.Name = "colStartAddress";
            // 
            // colWordCount
            // 
            this.colWordCount.HeaderText = "Word Count";
            this.colWordCount.Name = "colWordCount";
            // 
            // colInterTime
            // 
            this.colInterTime.HeaderText = "Interval Time";
            this.colInterTime.Name = "colInterTime";
            // 
            // FrmConfigShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 521);
            this.Controls.Add(this.dgvConfigShow);
            this.Name = "FrmConfigShow";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Config Show From";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConfigShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMeterkey;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConnectType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMeterModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWordCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterTime;
    }
}