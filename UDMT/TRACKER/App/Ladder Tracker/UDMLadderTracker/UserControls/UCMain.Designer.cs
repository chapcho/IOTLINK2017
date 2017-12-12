namespace UDMLadderTracker
{
    partial class UCMain
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
            this.grpProcessFlowChart = new DevExpress.XtraEditors.GroupControl();
            this.btnFlowChartHide = new DevExpress.XtraEditors.SimpleButton();
            this.tabFlow = new DevExpress.XtraTab.XtraTabControl();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpErrorList = new DevExpress.XtraTab.XtraTabPage();
            this.tpAnalysis = new DevExpress.XtraTab.XtraTabPage();
            this.pnlView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).BeginInit();
            this.grpProcessFlowChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpAnalysis.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProcessFlowChart
            // 
            this.grpProcessFlowChart.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpProcessFlowChart.AppearanceCaption.Options.UseFont = true;
            this.grpProcessFlowChart.Controls.Add(this.btnFlowChartHide);
            this.grpProcessFlowChart.Controls.Add(this.tabFlow);
            this.grpProcessFlowChart.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpProcessFlowChart.Location = new System.Drawing.Point(744, 0);
            this.grpProcessFlowChart.Name = "grpProcessFlowChart";
            this.grpProcessFlowChart.Size = new System.Drawing.Size(289, 659);
            this.grpProcessFlowChart.TabIndex = 35;
            this.grpProcessFlowChart.Text = "Process Flow Chart";
            this.grpProcessFlowChart.Visible = false;
            // 
            // btnFlowChartHide
            // 
            this.btnFlowChartHide.Appearance.BackColor = System.Drawing.Color.White;
            this.btnFlowChartHide.Appearance.Options.UseBackColor = true;
            this.btnFlowChartHide.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnFlowChartHide.Location = new System.Drawing.Point(222, 3);
            this.btnFlowChartHide.Name = "btnFlowChartHide";
            this.btnFlowChartHide.Size = new System.Drawing.Size(65, 20);
            this.btnFlowChartHide.TabIndex = 4;
            this.btnFlowChartHide.Text = "Hide";
            // 
            // tabFlow
            // 
            this.tabFlow.AppearancePage.Header.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Italic);
            this.tabFlow.AppearancePage.Header.Options.UseFont = true;
            this.tabFlow.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.Green;
            this.tabFlow.AppearancePage.HeaderActive.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tabFlow.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabFlow.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFlow.Location = new System.Drawing.Point(2, 26);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.Size = new System.Drawing.Size(285, 631);
            this.tabFlow.TabIndex = 3;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.sptMain.Location = new System.Drawing.Point(739, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(5, 659);
            this.sptMain.TabIndex = 37;
            this.sptMain.TabStop = false;
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
            this.tabMain.Size = new System.Drawing.Size(739, 659);
            this.tabMain.TabIndex = 38;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpErrorList,
            this.tpAnalysis});
            // 
            // tpErrorList
            // 
            this.tpErrorList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpErrorList.Name = "tpErrorList";
            this.tpErrorList.Size = new System.Drawing.Size(733, 625);
            this.tpErrorList.Text = "Error List";
            // 
            // tpAnalysis
            // 
            this.tpAnalysis.Controls.Add(this.pnlView);
            this.tpAnalysis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpAnalysis.Name = "tpAnalysis";
            this.tpAnalysis.Size = new System.Drawing.Size(733, 625);
            this.tpAnalysis.Text = "Ladder View";
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.SystemColors.Control;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(733, 625);
            this.pnlView.TabIndex = 6;
            // 
            // UCMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.grpProcessFlowChart);
            this.Name = "UCMain";
            this.Size = new System.Drawing.Size(1033, 659);
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).EndInit();
            this.grpProcessFlowChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpAnalysis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpProcessFlowChart;
        private DevExpress.XtraEditors.SimpleButton btnFlowChartHide;
        private DevExpress.XtraTab.XtraTabControl tabFlow;
        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpErrorList;
        private DevExpress.XtraTab.XtraTabPage tpAnalysis;
        private System.Windows.Forms.Panel pnlView;
    }
}
