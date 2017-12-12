namespace UDMTrackerSimple
{
    partial class UCClock2
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
            this.components = new System.ComponentModel.Container();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 500;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // lblTime
            // 
            this.lblTime.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblTime.Appearance.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.lblTime.Appearance.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Bold);
            this.lblTime.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTime.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Location = new System.Drawing.Point(5, 5);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(840, 63);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "2016년 03월 22일  10 : 00 : 00";
            // 
            // UCClock2
            // 
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTime);
            this.Name = "UCClock2";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(850, 73);
            this.Load += new System.EventHandler(this.UCClock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrTimer;
        private DevExpress.XtraEditors.LabelControl lblTime;
    }
}
