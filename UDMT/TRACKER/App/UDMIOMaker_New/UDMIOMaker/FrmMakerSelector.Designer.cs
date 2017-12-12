namespace UDMIOMaker
{
    partial class FrmMakerSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMakerSelector));
            this.imgPlc = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlPlcMaker = new DevExpress.XtraEditors.PanelControl();
            this.chkSiemensMaker = new DevExpress.XtraEditors.CheckButton();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.chkABMaker = new DevExpress.XtraEditors.CheckButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.chkMelsecMaker = new DevExpress.XtraEditors.CheckButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkLSMaker = new DevExpress.XtraEditors.CheckButton();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).BeginInit();
            this.panelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlcMaker)).BeginInit();
            this.pnlPlcMaker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlc
            // 
            this.imgPlc.ImageSize = new System.Drawing.Size(64, 64);
            this.imgPlc.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgPlc.ImageStream")));
            this.imgPlc.Images.SetKeyName(0, "AB_Plc.png");
            this.imgPlc.Images.SetKeyName(1, "LS_Plc.png");
            this.imgPlc.Images.SetKeyName(2, "Melsec_Plc.png");
            this.imgPlc.Images.SetKeyName(3, "Siemens_Plc.png");
            this.imgPlc.Images.SetKeyName(4, "DDEA2.png");
            this.imgPlc.Images.SetKeyName(5, "OPC2.png");
            this.imgPlc.Images.SetKeyName(6, "Setting1_128x128.png");
            this.imgPlc.Images.SetKeyName(7, "Synchronize1_48x48.png");
            // 
            // panelControl8
            // 
            this.panelControl8.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl8.Appearance.Options.UseBackColor = true;
            this.panelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl8.Controls.Add(this.labelControl1);
            this.panelControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl8.Location = new System.Drawing.Point(0, 0);
            this.panelControl8.Name = "panelControl8";
            this.panelControl8.Size = new System.Drawing.Size(495, 44);
            this.panelControl8.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(171, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "PLC Maker를 선택하세요.";
            // 
            // pnlPlcMaker
            // 
            this.pnlPlcMaker.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPlcMaker.Controls.Add(this.chkSiemensMaker);
            this.pnlPlcMaker.Controls.Add(this.panelControl5);
            this.pnlPlcMaker.Controls.Add(this.chkABMaker);
            this.pnlPlcMaker.Controls.Add(this.panelControl4);
            this.pnlPlcMaker.Controls.Add(this.chkMelsecMaker);
            this.pnlPlcMaker.Controls.Add(this.panelControl2);
            this.pnlPlcMaker.Controls.Add(this.chkLSMaker);
            this.pnlPlcMaker.Controls.Add(this.panelControl6);
            this.pnlPlcMaker.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlcMaker.Location = new System.Drawing.Point(0, 44);
            this.pnlPlcMaker.Name = "pnlPlcMaker";
            this.pnlPlcMaker.Size = new System.Drawing.Size(495, 103);
            this.pnlPlcMaker.TabIndex = 13;
            // 
            // chkSiemensMaker
            // 
            this.chkSiemensMaker.AllowAllUnchecked = true;
            this.chkSiemensMaker.Appearance.Options.UseTextOptions = true;
            this.chkSiemensMaker.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkSiemensMaker.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.chkSiemensMaker.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSiemensMaker.GroupIndex = 1;
            this.chkSiemensMaker.ImageIndex = 3;
            this.chkSiemensMaker.ImageList = this.imgPlc;
            this.chkSiemensMaker.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chkSiemensMaker.Location = new System.Drawing.Point(369, 0);
            this.chkSiemensMaker.Name = "chkSiemensMaker";
            this.chkSiemensMaker.Size = new System.Drawing.Size(90, 103);
            this.chkSiemensMaker.TabIndex = 16;
            this.chkSiemensMaker.TabStop = false;
            this.chkSiemensMaker.Text = "Siemens";
            this.chkSiemensMaker.CheckedChanged += new System.EventHandler(this.chkSiemensMaker_CheckedChanged);
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl5.Location = new System.Drawing.Point(349, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(20, 103);
            this.panelControl5.TabIndex = 15;
            // 
            // chkABMaker
            // 
            this.chkABMaker.AllowAllUnchecked = true;
            this.chkABMaker.Appearance.Options.UseTextOptions = true;
            this.chkABMaker.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkABMaker.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.chkABMaker.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkABMaker.Enabled = false;
            this.chkABMaker.GroupIndex = 1;
            this.chkABMaker.ImageIndex = 0;
            this.chkABMaker.ImageList = this.imgPlc;
            this.chkABMaker.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chkABMaker.Location = new System.Drawing.Point(259, 0);
            this.chkABMaker.Name = "chkABMaker";
            this.chkABMaker.Size = new System.Drawing.Size(90, 103);
            this.chkABMaker.TabIndex = 14;
            this.chkABMaker.TabStop = false;
            this.chkABMaker.Text = "Allen Bradley";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(239, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(20, 103);
            this.panelControl4.TabIndex = 13;
            // 
            // chkMelsecMaker
            // 
            this.chkMelsecMaker.AllowAllUnchecked = true;
            this.chkMelsecMaker.Appearance.Options.UseTextOptions = true;
            this.chkMelsecMaker.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkMelsecMaker.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.chkMelsecMaker.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkMelsecMaker.GroupIndex = 1;
            this.chkMelsecMaker.ImageIndex = 2;
            this.chkMelsecMaker.ImageList = this.imgPlc;
            this.chkMelsecMaker.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chkMelsecMaker.Location = new System.Drawing.Point(149, 0);
            this.chkMelsecMaker.Name = "chkMelsecMaker";
            this.chkMelsecMaker.Size = new System.Drawing.Size(90, 103);
            this.chkMelsecMaker.TabIndex = 12;
            this.chkMelsecMaker.TabStop = false;
            this.chkMelsecMaker.Text = "Mitsubishi";
            this.chkMelsecMaker.CheckedChanged += new System.EventHandler(this.chkMelsecMaker_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(129, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(20, 103);
            this.panelControl2.TabIndex = 11;
            // 
            // chkLSMaker
            // 
            this.chkLSMaker.AllowAllUnchecked = true;
            this.chkLSMaker.Appearance.Options.UseTextOptions = true;
            this.chkLSMaker.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkLSMaker.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.chkLSMaker.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkLSMaker.GroupIndex = 1;
            this.chkLSMaker.ImageIndex = 1;
            this.chkLSMaker.ImageList = this.imgPlc;
            this.chkLSMaker.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.chkLSMaker.Location = new System.Drawing.Point(39, 0);
            this.chkLSMaker.Name = "chkLSMaker";
            this.chkLSMaker.Size = new System.Drawing.Size(90, 103);
            this.chkLSMaker.TabIndex = 8;
            this.chkLSMaker.TabStop = false;
            this.chkLSMaker.Text = "LS 산전";
            this.chkLSMaker.CheckedChanged += new System.EventHandler(this.chkLSMaker_CheckedChanged);
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl6.Location = new System.Drawing.Point(0, 0);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(39, 103);
            this.panelControl6.TabIndex = 17;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 162);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(495, 47);
            this.panelControl1.TabIndex = 14;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(325, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 47);
            this.btnOK.TabIndex = 20;
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
            this.btnClose.Location = new System.Drawing.Point(410, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 47);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 147);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(495, 15);
            this.panelControl3.TabIndex = 15;
            // 
            // FrmMakerSelector
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 209);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlPlcMaker);
            this.Controls.Add(this.panelControl8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMakerSelector";
            this.Text = "PLC Maker 선택";
            ((System.ComponentModel.ISupportInitialize)(this.imgPlc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl8)).EndInit();
            this.panelControl8.ResumeLayout(false);
            this.panelControl8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlcMaker)).EndInit();
            this.pnlPlcMaker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgPlc;
        private DevExpress.XtraEditors.PanelControl panelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnlPlcMaker;
        private DevExpress.XtraEditors.CheckButton chkSiemensMaker;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.CheckButton chkABMaker;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.CheckButton chkMelsecMaker;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckButton chkLSMaker;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl3;

    }
}