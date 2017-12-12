namespace UDMLadderTracker
{
    partial class FrmLadderView
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
            this.pnlView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.SystemColors.Control;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(792, 558);
            this.pnlView.TabIndex = 4;
            // 
            // FrmLadderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 558);
            this.Controls.Add(this.pnlView);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmLadderView";
            this.Text = "Ladder View";
            this.Load += new System.EventHandler(this.FrmLadderView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
    }
}