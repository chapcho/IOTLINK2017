namespace UDMTrackerSimple
{
    partial class UCUserDevice
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.grpCurrentValue = new DevExpress.XtraEditors.GroupControl();
            this.chkHexa = new DevExpress.XtraEditors.CheckEdit();
            this.lblCurrentValue = new DevExpress.XtraEditors.LabelControl();
            this.grpLastTime = new DevExpress.XtraEditors.GroupControl();
            this.lblLastTime = new DevExpress.XtraEditors.LabelControl();
            this.grpAddress = new DevExpress.XtraEditors.GroupControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.grpDescription = new DevExpress.XtraEditors.GroupControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentValue)).BeginInit();
            this.grpCurrentValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkHexa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLastTime)).BeginInit();
            this.grpLastTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).BeginInit();
            this.grpAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDescription)).BeginInit();
            this.grpDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 400);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(290, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(10, 400);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(10, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(280, 10);
            this.pnlTop.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 390);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(280, 10);
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlMain.Controls.Add(this.grpCurrentValue);
            this.pnlMain.Controls.Add(this.grpLastTime);
            this.pnlMain.Controls.Add(this.grpAddress);
            this.pnlMain.Controls.Add(this.grpDescription);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(280, 380);
            this.pnlMain.TabIndex = 4;
            // 
            // grpCurrentValue
            // 
            this.grpCurrentValue.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpCurrentValue.AppearanceCaption.Options.UseFont = true;
            this.grpCurrentValue.Controls.Add(this.chkHexa);
            this.grpCurrentValue.Controls.Add(this.lblCurrentValue);
            this.grpCurrentValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCurrentValue.Location = new System.Drawing.Point(2, 252);
            this.grpCurrentValue.Name = "grpCurrentValue";
            this.grpCurrentValue.Size = new System.Drawing.Size(276, 128);
            this.grpCurrentValue.TabIndex = 3;
            this.grpCurrentValue.Text = "Current Value";
            // 
            // chkHexa
            // 
            this.chkHexa.Location = new System.Drawing.Point(213, 29);
            this.chkHexa.Name = "chkHexa";
            this.chkHexa.Properties.Caption = "Hexa";
            this.chkHexa.Size = new System.Drawing.Size(58, 19);
            this.chkHexa.TabIndex = 3;
            this.chkHexa.CheckedChanged += new System.EventHandler(this.chkHexa_CheckedChanged);
            // 
            // lblCurrentValue
            // 
            this.lblCurrentValue.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.lblCurrentValue.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblCurrentValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCurrentValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCurrentValue.AutoEllipsis = true;
            this.lblCurrentValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrentValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblCurrentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentValue.Location = new System.Drawing.Point(2, 26);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(272, 100);
            this.lblCurrentValue.TabIndex = 2;
            this.lblCurrentValue.Text = "4294967295";
            // 
            // grpLastTime
            // 
            this.grpLastTime.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpLastTime.AppearanceCaption.Options.UseFont = true;
            this.grpLastTime.Controls.Add(this.lblLastTime);
            this.grpLastTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLastTime.Location = new System.Drawing.Point(2, 162);
            this.grpLastTime.Name = "grpLastTime";
            this.grpLastTime.Size = new System.Drawing.Size(276, 90);
            this.grpLastTime.TabIndex = 2;
            this.grpLastTime.Text = "Last Time";
            // 
            // lblLastTime
            // 
            this.lblLastTime.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblLastTime.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblLastTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLastTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLastTime.AutoEllipsis = true;
            this.lblLastTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLastTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblLastTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastTime.Location = new System.Drawing.Point(2, 26);
            this.lblLastTime.Name = "lblLastTime";
            this.lblLastTime.Size = new System.Drawing.Size(272, 62);
            this.lblLastTime.TabIndex = 2;
            this.lblLastTime.Text = "20160108\r\n10:30:02.091";
            // 
            // grpAddress
            // 
            this.grpAddress.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpAddress.AppearanceCaption.Options.UseFont = true;
            this.grpAddress.Controls.Add(this.lblAddress);
            this.grpAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAddress.Location = new System.Drawing.Point(2, 92);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(276, 70);
            this.grpAddress.TabIndex = 0;
            this.grpAddress.Text = "Address";
            // 
            // lblAddress
            // 
            this.lblAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAddress.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblAddress.AutoEllipsis = true;
            this.lblAddress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAddress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(2, 26);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(272, 42);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "X200";
            // 
            // grpDescription
            // 
            this.grpDescription.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpDescription.AppearanceCaption.Options.UseFont = true;
            this.grpDescription.Controls.Add(this.lblDescription);
            this.grpDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDescription.Location = new System.Drawing.Point(2, 2);
            this.grpDescription.Name = "grpDescription";
            this.grpDescription.Size = new System.Drawing.Size(276, 90);
            this.grpDescription.TabIndex = 1;
            this.grpDescription.Text = "Description";
            // 
            // lblDescription
            // 
            this.lblDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescription.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(2, 26);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(272, 62);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "로봇 1 동작 1 \r\n작동 불량";
            // 
            // UCUserDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "UCUserDevice";
            this.Size = new System.Drawing.Size(300, 400);
            this.Load += new System.EventHandler(this.UCUserDevice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentValue)).EndInit();
            this.grpCurrentValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkHexa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLastTime)).EndInit();
            this.grpLastTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpAddress)).EndInit();
            this.grpAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDescription)).EndInit();
            this.grpDescription.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.GroupControl grpCurrentValue;
        private DevExpress.XtraEditors.CheckEdit chkHexa;
        private DevExpress.XtraEditors.LabelControl lblCurrentValue;
        private DevExpress.XtraEditors.GroupControl grpLastTime;
        private DevExpress.XtraEditors.LabelControl lblLastTime;
        private DevExpress.XtraEditors.GroupControl grpAddress;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.GroupControl grpDescription;
        private DevExpress.XtraEditors.LabelControl lblDescription;
    }
}
