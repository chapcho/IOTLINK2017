namespace UDMTrackerSimple
{
    partial class FrmAllTagUserAddressFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllTagUserAddressFilter));
            this.txtAddressList = new System.Windows.Forms.TextBox();
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddressList
            // 
            this.txtAddressList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddressList.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAddressList.Location = new System.Drawing.Point(0, 0);
            this.txtAddressList.Multiline = true;
            this.txtAddressList.Name = "txtAddressList";
            this.txtAddressList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddressList.Size = new System.Drawing.Size(482, 474);
            this.txtAddressList.TabIndex = 0;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.simpleButton1);
            this.pnlControl.Controls.Add(this.btnClose);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 474);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(482, 48);
            this.pnlControl.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(270, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 44);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Set";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(375, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 44);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmAllTagUserAddressFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 522);
            this.ControlBox = false;
            this.Controls.Add(this.txtAddressList);
            this.Controls.Add(this.pnlControl);
            this.Name = "FrmAllTagUserAddressFilter";
            this.Text = "All Tag Address Filter";
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddressList;
        private DevExpress.XtraEditors.PanelControl pnlControl;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}