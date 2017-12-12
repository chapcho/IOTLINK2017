namespace UDMIOMaker
{
    partial class FrmParsingOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParsingOption));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grpCheckOption = new System.Windows.Forms.GroupBox();
            this.chkBar = new DevExpress.XtraEditors.CheckEdit();
            this.chkUnderbar = new DevExpress.XtraEditors.CheckEdit();
            this.chkSpace = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.grpCheckOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnderbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpace.Properties)).BeginInit();
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
            this.panelControl1.Location = new System.Drawing.Point(0, 144);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(247, 44);
            this.panelControl1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 44);
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
            this.btnClose.Location = new System.Drawing.Point(162, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 44);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpCheckOption
            // 
            this.grpCheckOption.Controls.Add(this.chkSpace);
            this.grpCheckOption.Controls.Add(this.chkBar);
            this.grpCheckOption.Controls.Add(this.chkUnderbar);
            this.grpCheckOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCheckOption.Location = new System.Drawing.Point(0, 0);
            this.grpCheckOption.Name = "grpCheckOption";
            this.grpCheckOption.Size = new System.Drawing.Size(247, 144);
            this.grpCheckOption.TabIndex = 2;
            this.grpCheckOption.TabStop = false;
            this.grpCheckOption.Text = "심볼 파싱 옵션 ";
            // 
            // chkBar
            // 
            this.chkBar.Location = new System.Drawing.Point(6, 73);
            this.chkBar.Name = "chkBar";
            this.chkBar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkBar.Properties.Appearance.Options.UseFont = true;
            this.chkBar.Properties.Caption = "- : Bar";
            this.chkBar.Size = new System.Drawing.Size(112, 20);
            this.chkBar.TabIndex = 3;
            // 
            // chkUnderbar
            // 
            this.chkUnderbar.EditValue = true;
            this.chkUnderbar.Location = new System.Drawing.Point(6, 35);
            this.chkUnderbar.Name = "chkUnderbar";
            this.chkUnderbar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkUnderbar.Properties.Appearance.Options.UseFont = true;
            this.chkUnderbar.Properties.Caption = "_ : Under Bar";
            this.chkUnderbar.Size = new System.Drawing.Size(112, 20);
            this.chkUnderbar.TabIndex = 2;
            // 
            // chkSpace
            // 
            this.chkSpace.Location = new System.Drawing.Point(6, 108);
            this.chkSpace.Name = "chkSpace";
            this.chkSpace.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkSpace.Properties.Appearance.Options.UseFont = true;
            this.chkSpace.Properties.Caption = "  : Space";
            this.chkSpace.Size = new System.Drawing.Size(138, 20);
            this.chkSpace.TabIndex = 4;
            // 
            // FrmParsingOption
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 188);
            this.Controls.Add(this.grpCheckOption);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmParsingOption";
            this.Text = "심볼 Parsing 옵션";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.grpCheckOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUnderbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpace.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox grpCheckOption;
        private DevExpress.XtraEditors.CheckEdit chkSpace;
        private DevExpress.XtraEditors.CheckEdit chkBar;
        private DevExpress.XtraEditors.CheckEdit chkUnderbar;
    }
}