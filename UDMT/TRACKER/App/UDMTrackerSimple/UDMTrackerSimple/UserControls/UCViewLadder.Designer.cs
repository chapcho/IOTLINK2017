namespace UDMTrackerSimple
{
    partial class UCViewLadder
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
            this.grpMain = new DevExpress.XtraEditors.GroupControl();
            this.pnlView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Appearance.BackColor = System.Drawing.Color.White;
            this.grpMain.Appearance.Options.UseBackColor = true;
            this.grpMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 15F);
            this.grpMain.AppearanceCaption.Options.UseFont = true;
            this.grpMain.Controls.Add(this.pnlView);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(881, 363);
            this.grpMain.TabIndex = 0;
            this.grpMain.Text = "LadderName";
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.Color.White;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(2, 39);
            this.pnlView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(877, 322);
            this.pnlView.TabIndex = 5;
            // 
            // UCViewLadder
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCViewLadder";
            this.Size = new System.Drawing.Size(881, 363);
            this.Load += new System.EventHandler(this.UCViewLadder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpMain;
        private System.Windows.Forms.Panel pnlView;
    }
}
