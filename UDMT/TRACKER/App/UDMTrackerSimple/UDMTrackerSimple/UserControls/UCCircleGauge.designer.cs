namespace UDMTrackerSimple
{
	partial class UCCircleGauge
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
			this.exGauge = new DevExpress.XtraGauges.Win.GaugeControl();
			this.exCircularGauge = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
			this.exLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
			this.exRangeBar = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent();
			this.exBaseRange = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
			this.pnlMain = new DevExpress.XtraEditors.PanelControl();
			this.lblTitle = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.exCircularGauge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exLabel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exRangeBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exBaseRange)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// exGauge
			// 
			this.exGauge.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.exGauge.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGauge.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.exCircularGauge});
			this.exGauge.Location = new System.Drawing.Point(0, 0);
			this.exGauge.Name = "exGauge";
			this.exGauge.Size = new System.Drawing.Size(100, 87);
			this.exGauge.TabIndex = 0;
			// 
			// exCircularGauge
			// 
			this.exCircularGauge.Bounds = new System.Drawing.Rectangle(6, 6, 88, 75);
			this.exCircularGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.exLabel});
			this.exCircularGauge.Name = "exCircularGauge";
			this.exCircularGauge.RangeBars.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent[] {
            this.exRangeBar});
			this.exCircularGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.exBaseRange});
			// 
			// exLabel
			// 
			this.exLabel.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exLabel.Name = "circularGauge1_Label1";
			this.exLabel.Size = new System.Drawing.SizeF(140F, 60F);
			this.exLabel.Text = "57s";
			this.exLabel.UseColorScheme = false;
			this.exLabel.ZOrder = -1001;
			// 
			// exRangeBar
			// 
			this.exRangeBar.AppearanceRangeBar.BackgroundBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:LightGrey");
			this.exRangeBar.AppearanceRangeBar.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
			this.exRangeBar.ArcScale = this.exBaseRange;
			this.exRangeBar.Name = "circularGauge1_RangeBar2";
			this.exRangeBar.ShowBackground = true;
			this.exRangeBar.StartOffset = 70F;
			this.exRangeBar.ZOrder = -10;
			// 
			// exBaseRange
			// 
			this.exBaseRange.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.exBaseRange.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.exBaseRange.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.exBaseRange.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
			this.exBaseRange.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 8.5F);
			this.exBaseRange.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
			this.exBaseRange.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
			this.exBaseRange.EndAngle = 405F;
			this.exBaseRange.MajorTickCount = 0;
			this.exBaseRange.MajorTickmark.FormatString = "{0:F0}";
			this.exBaseRange.MajorTickmark.ShapeOffset = -14F;
			this.exBaseRange.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
			this.exBaseRange.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
			this.exBaseRange.MaxValue = 100F;
			this.exBaseRange.MinorTickCount = 0;
			this.exBaseRange.MinorTickmark.ShapeOffset = -7F;
			this.exBaseRange.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
			this.exBaseRange.Name = "scale1";
			this.exBaseRange.StartAngle = 135F;
			this.exBaseRange.UseColorScheme = false;
			this.exBaseRange.Value = 30F;
			// 
			// pnlMain
			// 
			this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
			this.pnlMain.Appearance.Options.UseBackColor = true;
			this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlMain.Controls.Add(this.exGauge);
			this.pnlMain.Controls.Add(this.lblTitle);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(100, 100);
			this.pnlMain.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblTitle.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblTitle.Location = new System.Drawing.Point(0, 87);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(100, 13);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Gauge Title";
			// 
			// UCCircleGauge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.pnlMain);
			this.Name = "UCCircleGauge";
			this.Size = new System.Drawing.Size(100, 100);
			this.Load += new System.EventHandler(this.UCCircleGauge_Load);
			((System.ComponentModel.ISupportInitialize)(this.exCircularGauge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exLabel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exRangeBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exBaseRange)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGauges.Win.GaugeControl exGauge;
		private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge exCircularGauge;
		private DevExpress.XtraGauges.Win.Base.LabelComponent exLabel;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent exRangeBar;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent exBaseRange;
		private DevExpress.XtraEditors.PanelControl pnlMain;
		private DevExpress.XtraEditors.LabelControl lblTitle;

	}
}
