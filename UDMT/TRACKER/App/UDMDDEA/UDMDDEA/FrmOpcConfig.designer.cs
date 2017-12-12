namespace UDMDDEA
{
    partial class FrmOpcConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpcConfig));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbChannelList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spnUpdateRate = new DevExpress.XtraEditors.SpinEdit();
            this.cmbServerList = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpdateRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.cmbChannelList);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spnUpdateRate);
            this.groupControl1.Controls.Add(this.cmbServerList);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(491, 142);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "OPC Server 설정";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 81);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(106, 14);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Channel/Device List";
            // 
            // cmbChannelList
            // 
            this.cmbChannelList.Location = new System.Drawing.Point(8, 101);
            this.cmbChannelList.Name = "cmbChannelList";
            this.cmbChannelList.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbChannelList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbChannelList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChannelList.Size = new System.Drawing.Size(400, 20);
            this.cmbChannelList.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(414, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Update Rate";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 14);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Server List";
            // 
            // spnUpdateRate
            // 
            this.spnUpdateRate.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnUpdateRate.Location = new System.Drawing.Point(414, 48);
            this.spnUpdateRate.Name = "spnUpdateRate";
            this.spnUpdateRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnUpdateRate.Properties.IsFloatValue = false;
            this.spnUpdateRate.Properties.Mask.EditMask = "N00";
            this.spnUpdateRate.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spnUpdateRate.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnUpdateRate.Size = new System.Drawing.Size(65, 20);
            this.spnUpdateRate.TabIndex = 3;
            // 
            // cmbServerList
            // 
            this.cmbServerList.Location = new System.Drawing.Point(8, 48);
            this.cmbServerList.Name = "cmbServerList";
            this.cmbServerList.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbServerList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbServerList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServerList.Size = new System.Drawing.Size(400, 20);
            this.cmbServerList.TabIndex = 0;
            this.cmbServerList.SelectedIndexChanged += new System.EventHandler(this.cmbServerList_SelectedIndexChanged);
            // 
            // FrmOpcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 142);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpcConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPC Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpcConfig_FormClosing);
            this.Load += new System.EventHandler(this.FrmOpcConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnUpdateRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServerList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spnUpdateRate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbServerList;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbChannelList;

    }
}