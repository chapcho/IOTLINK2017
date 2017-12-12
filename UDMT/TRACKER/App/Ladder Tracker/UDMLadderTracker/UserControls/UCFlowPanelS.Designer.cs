namespace UDMLadderTracker
{
    partial class UCFlowPanelS
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
            this.tabFlow = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).BeginInit();
            this.tabFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFlow
            // 
            this.tabFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFlow.Location = new System.Drawing.Point(0, 0);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.SelectedTabPage = this.xtraTabPage1;
            this.tabFlow.Size = new System.Drawing.Size(687, 716);
            this.tabFlow.TabIndex = 0;
            this.tabFlow.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.AutoScroll = true;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(680, 680);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(680, 680);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // UCFlowPanelS
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tabFlow);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCFlowPanelS";
            this.Size = new System.Drawing.Size(687, 716);
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).EndInit();
            this.tabFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabFlow;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;

    }
}
