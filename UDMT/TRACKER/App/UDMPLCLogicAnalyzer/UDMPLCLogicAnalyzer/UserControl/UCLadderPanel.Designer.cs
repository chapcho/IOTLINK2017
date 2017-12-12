namespace UDMPLCLogicAnalyzer
{
    partial class UCLadderPanel
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
            this.pnlLadder = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLadder
            // 
            this.pnlLadder.AutoScroll = true;
            this.pnlLadder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLadder.Location = new System.Drawing.Point(0, 0);
            this.pnlLadder.Name = "pnlLadder";
            this.pnlLadder.Size = new System.Drawing.Size(734, 408);
            this.pnlLadder.TabIndex = 1;
            // 
            // UCLadderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLadder);
            this.Name = "UCLadderPanel";
            this.Size = new System.Drawing.Size(734, 408);
            this.Load += new System.EventHandler(this.UCLadderPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLadder;
    }
}
