namespace UDMTrackerSimple
{
    partial class UCErrorSummaryChart
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
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.ErrorChart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.ErrorChart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(722, 343);
            this.pnlChart.TabIndex = 37;
            // 
            // ErrorChart
            // 
            this.ErrorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorChart.Location = new System.Drawing.Point(2, 2);
            this.ErrorChart.Name = "ErrorChart";
            this.ErrorChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.ErrorChart.Size = new System.Drawing.Size(718, 339);
            this.ErrorChart.TabIndex = 31;
            this.ErrorChart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.ErrorChart_CustomDrawCrosshair);
            this.ErrorChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ErrorChart_CustomDrawSeriesPoint);
            // 
            // UCErrorSummaryChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChart);
            this.Name = "UCErrorSummaryChart";
            this.Size = new System.Drawing.Size(722, 343);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraCharts.ChartControl ErrorChart;


    }
}
