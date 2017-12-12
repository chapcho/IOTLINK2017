namespace UDMTracker
{
    partial class FrmRunningTimeDifferenceReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRunningTimeDifferenceReport));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdReport = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.splitSavePatternBtnGrp = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnGenStepRunningTimeSeq = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSavePatternBtnGrp)).BeginInit();
            this.splitSavePatternBtnGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdReport);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(892, 465);
            this.splitContainerControl1.SplitterPosition = 425;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdReport
            // 
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Location = new System.Drawing.Point(0, 0);
            this.grdReport.MainView = this.gridView1;
            this.grdReport.Name = "grdReport";
            this.grdReport.Size = new System.Drawing.Size(892, 425);
            this.grdReport.TabIndex = 0;
            this.grdReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdReport;
            this.gridView1.Name = "gridView1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.btnExcelExport);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitSavePatternBtnGrp);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(892, 35);
            this.splitContainerControl2.SplitterPosition = 130;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExcelExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelExport.Image")));
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(0, 0);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(130, 35);
            this.btnExcelExport.TabIndex = 0;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // splitSavePatternBtnGrp
            // 
            this.splitSavePatternBtnGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSavePatternBtnGrp.Location = new System.Drawing.Point(0, 0);
            this.splitSavePatternBtnGrp.Name = "splitSavePatternBtnGrp";
            this.splitSavePatternBtnGrp.Panel1.Text = "Panel1";
            this.splitSavePatternBtnGrp.Panel2.Controls.Add(this.btnGenStepRunningTimeSeq);
            this.splitSavePatternBtnGrp.Panel2.Text = "Panel2";
            this.splitSavePatternBtnGrp.Size = new System.Drawing.Size(757, 35);
            this.splitSavePatternBtnGrp.TabIndex = 0;
            this.splitSavePatternBtnGrp.Text = "splitSavePatternBtnGrp";
            // 
            // btnGenStepRunningTimeSeq
            // 
            this.btnGenStepRunningTimeSeq.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGenStepRunningTimeSeq.Image = ((System.Drawing.Image)(resources.GetObject("btnGenStepRunningTimeSeq.Image")));
            this.btnGenStepRunningTimeSeq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenStepRunningTimeSeq.Location = new System.Drawing.Point(0, 0);
            this.btnGenStepRunningTimeSeq.Name = "btnGenStepRunningTimeSeq";
            this.btnGenStepRunningTimeSeq.Size = new System.Drawing.Size(100, 35);
            this.btnGenStepRunningTimeSeq.TabIndex = 0;
            this.btnGenStepRunningTimeSeq.Text = "생성";
            this.btnGenStepRunningTimeSeq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenStepRunningTimeSeq.UseVisualStyleBackColor = true;
            this.btnGenStepRunningTimeSeq.Click += new System.EventHandler(this.btnGenStepRunningTimeSeq_Click);
            // 
            // FrmRunningTimeDifferenceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 465);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRunningTimeDifferenceReport";
            this.Text = "FrmRunningTimeDifferenceReport";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSavePatternBtnGrp)).EndInit();
            this.splitSavePatternBtnGrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private System.Windows.Forms.Button btnExcelExport;
        private DevExpress.XtraGrid.GridControl grdReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitContainerControl splitSavePatternBtnGrp;
        private System.Windows.Forms.Button btnGenStepRunningTimeSeq;

    }
}