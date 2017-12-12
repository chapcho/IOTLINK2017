namespace UDMLadderTracker
{
    partial class UCTextView
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
            this.lblTextBox = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblTextBox
            // 
            this.lblTextBox.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.lblTextBox.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.lblTextBox.Appearance.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.lblTextBox.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblTextBox.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblTextBox.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTextBox.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTextBox.AutoEllipsis = true;
            this.lblTextBox.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTextBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextBox.Location = new System.Drawing.Point(5, 5);
            this.lblTextBox.Name = "lblTextBox";
            this.lblTextBox.Size = new System.Drawing.Size(309, 65);
            this.lblTextBox.TabIndex = 0;
            this.lblTextBox.Text = "전체 생산량";
            // 
            // UCTextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTextBox);
            this.Name = "UCTextView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(319, 75);
            this.Load += new System.EventHandler(this.UCTrackerMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTextBox;

    }
}
