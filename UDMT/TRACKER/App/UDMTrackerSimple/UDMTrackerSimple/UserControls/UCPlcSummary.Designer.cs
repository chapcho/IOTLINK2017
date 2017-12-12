namespace UDMTrackerSimple
{
    partial class UCPlcSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPlcSummary));
            this.grpProcessFlowChart = new DevExpress.XtraEditors.GroupControl();
            this.tabFlow = new DevExpress.XtraTab.XtraTabControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnProductionStateInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCycleOver = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.grpCarType = new DevExpress.XtraEditors.GroupControl();
            this.ucCarTypeS = new UDMTrackerSimple.UCCarTypeS();
            this.sptSummary = new UDM.UI.MySplitContainerControl();
            this.sptFlow = new UDM.UI.MySplitContainerControl();
            this.grpErrorMonitoring = new DevExpress.XtraEditors.PanelControl();
            this.sptSummaryError = new UDM.UI.MySplitContainerControl();
            this.ucSumErrorAlarmView = new UDMTrackerSimple.UCErrorAlarmView();
            this.grpErrorInformation = new DevExpress.XtraEditors.GroupControl();
            this.ucErrorSummaryPanelS = new UDMTrackerSimple.UCErrorSummaryPanelS();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnErrorClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).BeginInit();
            this.grpProcessFlowChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCarType)).BeginInit();
            this.grpCarType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptSummary)).BeginInit();
            this.sptSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptFlow)).BeginInit();
            this.sptFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorMonitoring)).BeginInit();
            this.grpErrorMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptSummaryError)).BeginInit();
            this.sptSummaryError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInformation)).BeginInit();
            this.grpErrorInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProcessFlowChart
            // 
            this.grpProcessFlowChart.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpProcessFlowChart.AppearanceCaption.Options.UseFont = true;
            this.grpProcessFlowChart.Controls.Add(this.tabFlow);
            this.grpProcessFlowChart.Controls.Add(this.panelControl2);
            this.grpProcessFlowChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcessFlowChart.Location = new System.Drawing.Point(0, 0);
            this.grpProcessFlowChart.Name = "grpProcessFlowChart";
            this.grpProcessFlowChart.Size = new System.Drawing.Size(687, 687);
            this.grpProcessFlowChart.TabIndex = 37;
            this.grpProcessFlowChart.Text = "Process Flow Chart";
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
            this.tabFlow.Location = new System.Drawing.Point(2, 70);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.Size = new System.Drawing.Size(683, 615);
            this.tabFlow.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnProductionStateInfo);
            this.panelControl2.Controls.Add(this.btnCycleOver);
            this.panelControl2.Controls.Add(this.btnNext);
            this.panelControl2.Controls.Add(this.btnPrev);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 26);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(683, 44);
            this.panelControl2.TabIndex = 4;
            // 
            // btnProductionStateInfo
            // 
            this.btnProductionStateInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductionStateInfo.Appearance.Options.UseFont = true;
            this.btnProductionStateInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnProductionStateInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnProductionStateInfo.Image")));
            this.btnProductionStateInfo.Location = new System.Drawing.Point(298, 2);
            this.btnProductionStateInfo.Name = "btnProductionStateInfo";
            this.btnProductionStateInfo.Size = new System.Drawing.Size(150, 40);
            this.btnProductionStateInfo.TabIndex = 3;
            this.btnProductionStateInfo.Text = "생산현황정보";
            this.btnProductionStateInfo.Visible = false;
            this.btnProductionStateInfo.Click += new System.EventHandler(this.btnProductionStateInfo_Click);
            // 
            // btnCycleOver
            // 
            this.btnCycleOver.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleOver.Appearance.Options.UseFont = true;
            this.btnCycleOver.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCycleOver.Image = ((System.Drawing.Image)(resources.GetObject("btnCycleOver.Image")));
            this.btnCycleOver.Location = new System.Drawing.Point(448, 2);
            this.btnCycleOver.Name = "btnCycleOver";
            this.btnCycleOver.Size = new System.Drawing.Size(233, 40);
            this.btnCycleOver.TabIndex = 2;
            this.btnCycleOver.Text = "무언 정지 이상 원인 찾기";
            this.btnCycleOver.Click += new System.EventHandler(this.btnCycleOver_Click);
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(62, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrev.Location = new System.Drawing.Point(2, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(60, 40);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // grpCarType
            // 
            this.grpCarType.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCarType.Appearance.Options.UseFont = true;
            this.grpCarType.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCarType.AppearanceCaption.Options.UseFont = true;
            this.grpCarType.Controls.Add(this.ucCarTypeS);
            this.grpCarType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCarType.Location = new System.Drawing.Point(0, 0);
            this.grpCarType.Name = "grpCarType";
            this.grpCarType.Size = new System.Drawing.Size(0, 0);
            this.grpCarType.TabIndex = 39;
            this.grpCarType.Text = "Process Car Type";
            this.grpCarType.Visible = false;
            // 
            // ucCarTypeS
            // 
            this.ucCarTypeS.Appearance.BackColor = System.Drawing.Color.White;
            this.ucCarTypeS.Appearance.Options.UseBackColor = true;
            this.ucCarTypeS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCarTypeS.Location = new System.Drawing.Point(0, 25);
            this.ucCarTypeS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucCarTypeS.Name = "ucCarTypeS";
            this.ucCarTypeS.Size = new System.Drawing.Size(0, 0);
            this.ucCarTypeS.TabIndex = 40;
            // 
            // sptSummary
            // 
            this.sptSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptSummary.Location = new System.Drawing.Point(0, 0);
            this.sptSummary.Name = "sptSummary";
            this.sptSummary.Panel1.Controls.Add(this.sptFlow);
            this.sptSummary.Panel1.Text = "Panel1";
            this.sptSummary.Panel2.Controls.Add(this.grpErrorMonitoring);
            this.sptSummary.Panel2.Text = "Panel2";
            this.sptSummary.Size = new System.Drawing.Size(1263, 687);
            this.sptSummary.SplitterPosition = 697;
            this.sptSummary.TabIndex = 38;
            this.sptSummary.Text = "splitContainerControl1";
            this.sptSummary.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptSummary_MouseDoubleClick);
            // 
            // sptFlow
            // 
            this.sptFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptFlow.Location = new System.Drawing.Point(0, 0);
            this.sptFlow.Name = "sptFlow";
            this.sptFlow.Panel1.Controls.Add(this.grpCarType);
            this.sptFlow.Panel1.Text = "Panel1";
            this.sptFlow.Panel2.Controls.Add(this.grpProcessFlowChart);
            this.sptFlow.Panel2.Text = "Panel2";
            this.sptFlow.Size = new System.Drawing.Size(697, 687);
            this.sptFlow.SplitterPosition = 0;
            this.sptFlow.TabIndex = 40;
            this.sptFlow.Text = "splitContainerControl1";
            // 
            // grpErrorMonitoring
            // 
            this.grpErrorMonitoring.Controls.Add(this.sptSummaryError);
            this.grpErrorMonitoring.Controls.Add(this.pnlHeader);
            this.grpErrorMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorMonitoring.Location = new System.Drawing.Point(0, 0);
            this.grpErrorMonitoring.Name = "grpErrorMonitoring";
            this.grpErrorMonitoring.Size = new System.Drawing.Size(556, 687);
            this.grpErrorMonitoring.TabIndex = 2;
            // 
            // sptSummaryError
            // 
            this.sptSummaryError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptSummaryError.Horizontal = false;
            this.sptSummaryError.Location = new System.Drawing.Point(2, 28);
            this.sptSummaryError.Name = "sptSummaryError";
            this.sptSummaryError.Panel1.Controls.Add(this.ucSumErrorAlarmView);
            this.sptSummaryError.Panel1.Text = "Panel1";
            this.sptSummaryError.Panel2.Controls.Add(this.grpErrorInformation);
            this.sptSummaryError.Panel2.Text = "Panel2";
            this.sptSummaryError.Size = new System.Drawing.Size(552, 657);
            this.sptSummaryError.SplitterPosition = 323;
            this.sptSummaryError.TabIndex = 0;
            this.sptSummaryError.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sptSummaryError_MouseClick);
            // 
            // ucSumErrorAlarmView
            // 
            this.ucSumErrorAlarmView.AutoScroll = true;
            this.ucSumErrorAlarmView.AutoSize = true;
            this.ucSumErrorAlarmView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSumErrorAlarmView.Location = new System.Drawing.Point(0, 0);
            this.ucSumErrorAlarmView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSumErrorAlarmView.Name = "ucSumErrorAlarmView";
            this.ucSumErrorAlarmView.Size = new System.Drawing.Size(552, 323);
            this.ucSumErrorAlarmView.TabIndex = 0;
            // 
            // grpErrorInformation
            // 
            this.grpErrorInformation.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpErrorInformation.AppearanceCaption.Options.UseFont = true;
            this.grpErrorInformation.Controls.Add(this.ucErrorSummaryPanelS);
            this.grpErrorInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorInformation.Location = new System.Drawing.Point(0, 0);
            this.grpErrorInformation.Name = "grpErrorInformation";
            this.grpErrorInformation.Size = new System.Drawing.Size(552, 324);
            this.grpErrorInformation.TabIndex = 0;
            this.grpErrorInformation.Text = "Error Information";
            // 
            // ucErrorSummaryPanelS
            // 
            this.ucErrorSummaryPanelS.Appearance.BackColor = System.Drawing.Color.White;
            this.ucErrorSummaryPanelS.Appearance.Options.UseBackColor = true;
            this.ucErrorSummaryPanelS.AutoScroll = true;
            this.ucErrorSummaryPanelS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorSummaryPanelS.Location = new System.Drawing.Point(2, 26);
            this.ucErrorSummaryPanelS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucErrorSummaryPanelS.Name = "ucErrorSummaryPanelS";
            this.ucErrorSummaryPanelS.Size = new System.Drawing.Size(548, 296);
            this.ucErrorSummaryPanelS.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.labelControl1);
            this.pnlHeader.Controls.Add(this.btnErrorClear);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(552, 26);
            this.pnlHeader.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(177, 22);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = " Error Monitoring";
            // 
            // btnErrorClear
            // 
            this.btnErrorClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorClear.Appearance.Options.UseFont = true;
            this.btnErrorClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnErrorClear.Image = ((System.Drawing.Image)(resources.GetObject("btnErrorClear.Image")));
            this.btnErrorClear.Location = new System.Drawing.Point(475, 2);
            this.btnErrorClear.Name = "btnErrorClear";
            this.btnErrorClear.Size = new System.Drawing.Size(75, 22);
            this.btnErrorClear.TabIndex = 1;
            this.btnErrorClear.Text = "Clear";
            this.btnErrorClear.Click += new System.EventHandler(this.btnErrorClear_Click);
            // 
            // UCPlcSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptSummary);
            this.Name = "UCPlcSummary";
            this.Size = new System.Drawing.Size(1263, 687);
            this.Load += new System.EventHandler(this.UCPlcSummary_Load);
            this.Resize += new System.EventHandler(this.UCPlcSummary_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessFlowChart)).EndInit();
            this.grpProcessFlowChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCarType)).EndInit();
            this.grpCarType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptSummary)).EndInit();
            this.sptSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptFlow)).EndInit();
            this.sptFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorMonitoring)).EndInit();
            this.grpErrorMonitoring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptSummaryError)).EndInit();
            this.sptSummaryError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInformation)).EndInit();
            this.grpErrorInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpProcessFlowChart;
        private DevExpress.XtraTab.XtraTabControl tabFlow;
        private DevExpress.XtraEditors.GroupControl grpCarType;
        private UCCarTypeS ucCarTypeS;
        private UDM.UI.MySplitContainerControl sptSummary;
        private UDM.UI.MySplitContainerControl sptSummaryError;
        private UCErrorAlarmView ucSumErrorAlarmView;
        private DevExpress.XtraEditors.GroupControl grpErrorInformation;
        private UCErrorSummaryPanelS ucErrorSummaryPanelS;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnErrorClear;
        private DevExpress.XtraEditors.PanelControl grpErrorMonitoring;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCycleOver;
        private DevExpress.XtraEditors.SimpleButton btnProductionStateInfo;
        private UDM.UI.MySplitContainerControl sptFlow;
    }
}
