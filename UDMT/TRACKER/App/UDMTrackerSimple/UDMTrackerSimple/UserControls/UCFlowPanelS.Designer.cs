namespace UDMTrackerSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFlowPanelS));
            this.tabFlow = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.pnlButton = new DevExpress.XtraEditors.PanelControl();
            this.btnCycleOver = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).BeginInit();
            this.tabFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFlow
            // 
            this.tabFlow.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFlow.AppearancePage.Header.Options.UseFont = true;
            this.tabFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFlow.Location = new System.Drawing.Point(22, 2);
            this.tabFlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.SelectedTabPage = this.xtraTabPage1;
            this.tabFlow.Size = new System.Drawing.Size(450, 477);
            this.tabFlow.TabIndex = 1;
            this.tabFlow.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.AutoScroll = true;
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(444, 438);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(488, 442);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnCycleOver);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton.Location = new System.Drawing.Point(0, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(494, 50);
            this.pnlButton.TabIndex = 2;
            this.pnlButton.Visible = false;
            // 
            // btnCycleOver
            // 
            this.btnCycleOver.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleOver.Appearance.Options.UseFont = true;
            this.btnCycleOver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCycleOver.Image = ((System.Drawing.Image)(resources.GetObject("btnCycleOver.Image")));
            this.btnCycleOver.Location = new System.Drawing.Point(243, 2);
            this.btnCycleOver.Name = "btnCycleOver";
            this.btnCycleOver.Size = new System.Drawing.Size(249, 46);
            this.btnCycleOver.TabIndex = 0;
            this.btnCycleOver.Text = "무언 정지 이상 원인 찾기";
            this.btnCycleOver.Click += new System.EventHandler(this.btnCycleOver_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tabFlow);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 50);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(494, 481);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(20, 477);
            this.panelControl2.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(472, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(20, 477);
            this.panelControl3.TabIndex = 1;
            // 
            // UCFlowPanelS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlButton);
            this.Name = "UCFlowPanelS";
            this.Size = new System.Drawing.Size(494, 531);
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).EndInit();
            this.tabFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButton)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabFlow;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl pnlButton;
        private DevExpress.XtraEditors.SimpleButton btnCycleOver;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;

    }
}
