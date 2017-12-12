namespace UDMLadderTracker.UserControls
{
    partial class UCErrorStatisticChart
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
            this.ErrorChart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorChart
            // 
            this.ErrorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorChart.Location = new System.Drawing.Point(0, 0);
            this.ErrorChart.Name = "ErrorChart";
            this.ErrorChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.ErrorChart.Size = new System.Drawing.Size(404, 354);
            this.ErrorChart.TabIndex = 30;
            this.ErrorChart.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.ErrorChart_CustomDrawCrosshair);
            this.ErrorChart.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.ErrorChart_CustomDrawSeriesPoint);
            // 
            // UCErrorStatisticChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ErrorChart);
            this.Name = "UCErrorStatisticChart";
            this.Size = new System.Drawing.Size(404, 354);
            this.Load += new System.EventHandler(this.UCErrorStatisticChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl ErrorChart;
    }
}
