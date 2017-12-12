namespace NewIOMaker.Form.FormCommon.UserControl
{
    partial class ControlVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlVideo));
            this.MediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // MediaPlayer1
            // 
            this.MediaPlayer1.Enabled = true;
            this.MediaPlayer1.Location = new System.Drawing.Point(45, 42);
            this.MediaPlayer1.Name = "MediaPlayer1";
            this.MediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer1.OcxState")));
            this.MediaPlayer1.Size = new System.Drawing.Size(311, 280);
            this.MediaPlayer1.TabIndex = 0;
            // 
            // ControlVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MediaPlayer1);
            this.Name = "ControlVideo";
            this.Size = new System.Drawing.Size(398, 383);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer1;

    }
}
