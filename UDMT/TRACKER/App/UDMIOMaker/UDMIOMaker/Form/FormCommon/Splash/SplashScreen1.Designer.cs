namespace NewIOMaker.Form.FormCommon
{
    partial class MainSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSplash));
            this.CopyRightlabel = new DevExpress.XtraEditors.LabelControl();
            this.Startlabel = new DevExpress.XtraEditors.LabelControl();
            this.ProgressBarUDM = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.pictureUDM = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarUDM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUDM.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // CopyRightlabel
            // 
            this.CopyRightlabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CopyRightlabel.Location = new System.Drawing.Point(216, 235);
            this.CopyRightlabel.Name = "CopyRightlabel";
            this.CopyRightlabel.Size = new System.Drawing.Size(131, 14);
            this.CopyRightlabel.TabIndex = 6;
            this.CopyRightlabel.Text = "Copyright © 2014-2016";
            // 
            // Startlabel
            // 
            this.Startlabel.Location = new System.Drawing.Point(17, 183);
            this.Startlabel.Name = "Startlabel";
            this.Startlabel.Size = new System.Drawing.Size(55, 14);
            this.Startlabel.TabIndex = 7;
            this.Startlabel.Text = "Starting...";
            // 
            // ProgressBarUDM
            // 
            this.ProgressBarUDM.EditValue = "Loading";
            this.ProgressBarUDM.Location = new System.Drawing.Point(17, 203);
            this.ProgressBarUDM.Name = "ProgressBarUDM";
            this.ProgressBarUDM.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal;
            this.ProgressBarUDM.Size = new System.Drawing.Size(536, 16);
            this.ProgressBarUDM.TabIndex = 5;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            // 
            // pictureUDM
            // 
            this.pictureUDM.EditValue = ((object)(resources.GetObject("pictureUDM.EditValue")));
            this.pictureUDM.Location = new System.Drawing.Point(15, 12);
            this.pictureUDM.Name = "pictureUDM";
            this.pictureUDM.Properties.AllowFocused = false;
            this.pictureUDM.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureUDM.Properties.Appearance.Options.UseBackColor = true;
            this.pictureUDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureUDM.Properties.ShowMenu = false;
            this.pictureUDM.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureUDM.Size = new System.Drawing.Size(538, 146);
            this.pictureUDM.TabIndex = 10;
            // 
            // MainSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 258);
            this.Controls.Add(this.pictureUDM);
            this.Controls.Add(this.Startlabel);
            this.Controls.Add(this.CopyRightlabel);
            this.Controls.Add(this.ProgressBarUDM);
            this.Name = "MainSplash";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarUDM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUDM.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl CopyRightlabel;
        private DevExpress.XtraEditors.LabelControl Startlabel;
        private DevExpress.XtraEditors.PictureEdit pictureUDM;
        private DevExpress.XtraEditors.MarqueeProgressBarControl ProgressBarUDM;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
