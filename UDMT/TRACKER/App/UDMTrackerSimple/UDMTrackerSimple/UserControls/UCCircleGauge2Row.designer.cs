namespace UDMTrackerSimple
{
	partial class UCCircleGauge2Row
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
            this.pnlGauge = new System.Windows.Forms.Panel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblTopText = new DevExpress.XtraEditors.LabelControl();
            this.lblTopCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblBottomCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblBottomText = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.exCircularGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRangeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBaseRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlGauge.SuspendLayout();
            this.pnlDetail.SuspendLayout();
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
            this.exGauge.Size = new System.Drawing.Size(107, 83);
            this.exGauge.TabIndex = 0;
            this.exGauge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.exGauge.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.exGauge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // exCircularGauge
            // 
            this.exCircularGauge.Bounds = new System.Drawing.Rectangle(6, 6, 95, 71);
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
            this.exLabel.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
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
            this.pnlMain.Controls.Add(this.pnlGauge);
            this.pnlMain.Controls.Add(this.pnlDetail);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(201, 96);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlGauge
            // 
            this.pnlGauge.Controls.Add(this.exGauge);
            this.pnlGauge.Controls.Add(this.lblTitle);
            this.pnlGauge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGauge.Location = new System.Drawing.Point(0, 0);
            this.pnlGauge.Name = "pnlGauge";
            this.pnlGauge.Size = new System.Drawing.Size(107, 96);
            this.pnlGauge.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitle.Location = new System.Drawing.Point(0, 83);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(107, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Gauge Title";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.lblTopText);
            this.pnlDetail.Controls.Add(this.lblTopCaption);
            this.pnlDetail.Controls.Add(this.lblBottomCaption);
            this.pnlDetail.Controls.Add(this.lblBottomText);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(107, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(0, 10, 5, 10);
            this.pnlDetail.Size = new System.Drawing.Size(94, 96);
            this.pnlDetail.TabIndex = 1;
            this.pnlDetail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.pnlDetail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.pnlDetail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            this.pnlDetail.Resize += new System.EventHandler(this.pnlDetail_Resize);
            // 
            // lblTopText
            // 
            this.lblTopText.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopText.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTopText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTopText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTopText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopText.Location = new System.Drawing.Point(0, 23);
            this.lblTopText.Name = "lblTopText";
            this.lblTopText.Size = new System.Drawing.Size(89, 18);
            this.lblTopText.TabIndex = 1;
            this.lblTopText.Text = "60.33s";
            this.lblTopText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblTopText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblTopText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // lblTopCaption
            // 
            this.lblTopCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopCaption.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTopCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTopCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTopCaption.Location = new System.Drawing.Point(0, 10);
            this.lblTopCaption.Name = "lblTopCaption";
            this.lblTopCaption.Size = new System.Drawing.Size(89, 13);
            this.lblTopCaption.TabIndex = 0;
            this.lblTopCaption.Text = "AVG";
            this.lblTopCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblTopCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblTopCaption.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // lblBottomCaption
            // 
            this.lblBottomCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomCaption.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBottomCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblBottomCaption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBottomCaption.Location = new System.Drawing.Point(0, 54);
            this.lblBottomCaption.Name = "lblBottomCaption";
            this.lblBottomCaption.Size = new System.Drawing.Size(89, 13);
            this.lblBottomCaption.TabIndex = 3;
            this.lblBottomCaption.Text = "MAX";
            this.lblBottomCaption.Click += new System.EventHandler(this.lblBottomCaption_Click);
            this.lblBottomCaption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblBottomCaption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblBottomCaption.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // lblBottomText
            // 
            this.lblBottomText.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomText.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBottomText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBottomText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblBottomText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBottomText.Location = new System.Drawing.Point(0, 67);
            this.lblBottomText.Name = "lblBottomText";
            this.lblBottomText.Size = new System.Drawing.Size(89, 19);
            this.lblBottomText.TabIndex = 2;
            this.lblBottomText.Text = "60.33s";
            this.lblBottomText.Click += new System.EventHandler(this.lblBottomText_Click);
            this.lblBottomText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblBottomText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblBottomText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // UCCircleGauge2Row
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "UCCircleGauge2Row";
            this.Size = new System.Drawing.Size(201, 96);
            this.Load += new System.EventHandler(this.UCCircleGauge2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exCircularGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exRangeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exBaseRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlGauge.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGauges.Win.GaugeControl exGauge;
		private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge exCircularGauge;
		private DevExpress.XtraGauges.Win.Base.LabelComponent exLabel;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent exRangeBar;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent exBaseRange;
		private DevExpress.XtraEditors.PanelControl pnlMain;
		private System.Windows.Forms.Panel pnlDetail;
		private DevExpress.XtraEditors.LabelControl lblBottomCaption;
		private DevExpress.XtraEditors.LabelControl lblBottomText;
		private DevExpress.XtraEditors.LabelControl lblTopText;
		private DevExpress.XtraEditors.LabelControl lblTopCaption;
		private System.Windows.Forms.Panel pnlGauge;
        private DevExpress.XtraEditors.LabelControl lblTitle;

	}
}
