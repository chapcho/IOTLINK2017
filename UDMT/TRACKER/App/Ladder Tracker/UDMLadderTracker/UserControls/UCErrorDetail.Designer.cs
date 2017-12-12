namespace UDMLadderTracker
{
    partial class UCErrorDetail
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
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpErrorList = new DevExpress.XtraTab.XtraTabPage();
            this.ucGrid = new UDMLadderTracker.UserControls.UCErrorLogGrid();
            this.tpAnalysis = new DevExpress.XtraTab.XtraTabPage();
            this.pnlView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpErrorList.SuspendLayout();
            this.tpAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Red;
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpErrorList;
            this.tabMain.Size = new System.Drawing.Size(939, 632);
            this.tabMain.TabIndex = 4;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpErrorList,
            this.tpAnalysis});
            // 
            // tpErrorList
            // 
            this.tpErrorList.Controls.Add(this.ucGrid);
            this.tpErrorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Size = new System.Drawing.Size(933, 598);
            this.tpErrorList.Text = "Error List";
            // 
            // ucGrid
            // 
            this.ucGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGrid.Location = new System.Drawing.Point(0, 0);
            this.ucGrid.Name = "ucGrid";
            this.ucGrid.Size = new System.Drawing.Size(933, 598);
            this.ucGrid.TabIndex = 0;
            // 
            // tpAnalysis
            // 
            this.tpAnalysis.Controls.Add(this.pnlView);
            this.tpAnalysis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpAnalysis.Name = "tpAnalysis";
            this.tpAnalysis.Size = new System.Drawing.Size(933, 598);
            this.tpAnalysis.Text = "Ladder View";
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.SystemColors.Control;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(933, 598);
            this.pnlView.TabIndex = 6;
            // 
            // UCErrorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "UCErrorDetail";
            this.Size = new System.Drawing.Size(939, 632);
            this.Load += new System.EventHandler(this.UCErrorDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpErrorList.ResumeLayout(false);
            this.tpAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpAnalysis;
        private DevExpress.XtraTab.XtraTabPage tpErrorList;
        private UserControls.UCErrorLogGrid ucGrid;
        private System.Windows.Forms.Panel pnlView;
    }
}
