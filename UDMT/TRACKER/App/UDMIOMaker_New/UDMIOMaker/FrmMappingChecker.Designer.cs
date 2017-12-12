namespace UDMIOMaker
{
    partial class FrmMappingChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMappingChecker));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grpCheckOption = new System.Windows.Forms.GroupBox();
            this.chkAddress = new DevExpress.XtraEditors.CheckEdit();
            this.chkDescription = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpCheckOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 110);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(218, 44);
            this.panelControl1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 40);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(131, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 40);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpCheckOption
            // 
            this.grpCheckOption.Controls.Add(this.chkAddress);
            this.grpCheckOption.Controls.Add(this.chkDescription);
            this.grpCheckOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheckOption.Location = new System.Drawing.Point(0, 0);
            this.grpCheckOption.Name = "grpCheckOption";
            this.grpCheckOption.Size = new System.Drawing.Size(218, 110);
            this.grpCheckOption.TabIndex = 1;
            this.grpCheckOption.TabStop = false;
            this.grpCheckOption.Text = "체크 옵션 (PLC)";
            // 
            // chkAddress
            // 
            this.chkAddress.Location = new System.Drawing.Point(6, 73);
            this.chkAddress.Name = "chkAddress";
            this.chkAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkAddress.Properties.Appearance.Options.UseFont = true;
            this.chkAddress.Properties.Caption = "Address";
            this.chkAddress.Size = new System.Drawing.Size(112, 20);
            this.chkAddress.TabIndex = 3;
            // 
            // chkDescription
            // 
            this.chkDescription.EditValue = true;
            this.chkDescription.Location = new System.Drawing.Point(6, 35);
            this.chkDescription.Name = "chkDescription";
            this.chkDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkDescription.Properties.Appearance.Options.UseFont = true;
            this.chkDescription.Properties.Caption = "Description";
            this.chkDescription.Size = new System.Drawing.Size(112, 20);
            this.chkDescription.TabIndex = 2;
            // 
            // FrmMappingChecker
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 154);
            this.Controls.Add(this.grpCheckOption);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMappingChecker";
            this.Text = "HMI 태그 매핑 체크 옵션";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpCheckOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.GroupBox grpCheckOption;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.CheckEdit chkAddress;
        private DevExpress.XtraEditors.CheckEdit chkDescription;
    }
}