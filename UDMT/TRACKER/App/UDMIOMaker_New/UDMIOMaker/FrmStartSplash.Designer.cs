namespace UDMIOMaker
{
    partial class FrmStartSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStartSplash));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureUDM = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUDM.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(27, 217);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(471, 11);
            this.marqueeProgressBarControl1.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 194);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Starting...";
            // 
            // pictureUDM
            // 
            this.pictureUDM.EditValue = ((object)(resources.GetObject("pictureUDM.EditValue")));
            this.pictureUDM.Location = new System.Drawing.Point(27, 12);
            this.pictureUDM.Name = "pictureUDM";
            this.pictureUDM.Properties.AllowFocused = false;
            this.pictureUDM.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureUDM.Properties.Appearance.Options.UseBackColor = true;
            this.pictureUDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureUDM.Properties.ShowMenu = false;
            this.pictureUDM.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureUDM.Size = new System.Drawing.Size(471, 172);
            this.pictureUDM.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(153, 243);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(198, 14);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Copyright to UDMTEK © 2014-2016";
            // 
            // FrmStartSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 269);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.pictureUDM);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStartSplash";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUDM.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureUDM;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
