namespace UExpression.UserControls
{
	partial class UCCurrentInfo
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblCurrentText = new DevExpress.XtraEditors.LabelControl();
			this.lblLeakText = new DevExpress.XtraEditors.LabelControl();
			this.lblVoltageText = new DevExpress.XtraEditors.LabelControl();
			this.lblCarbonText = new DevExpress.XtraEditors.LabelControl();
			this.lblCurrent = new DevExpress.XtraEditors.LabelControl();
			this.lblLeak = new DevExpress.XtraEditors.LabelControl();
			this.lblVoltage = new DevExpress.XtraEditors.LabelControl();
			this.lblCarbon = new DevExpress.XtraEditors.LabelControl();
			this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
			this.circularGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
			this.arcScaleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
			this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
			this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.lblCurrentText, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblLeakText, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblVoltageText, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblCarbonText, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.lblCurrent, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblLeak, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblVoltage, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblCarbon, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.gaugeControl1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 10;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 275);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblCurrentText
			// 
			this.lblCurrentText.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblCurrentText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.lblCurrentText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lblCurrentText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblCurrentText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCurrentText.Location = new System.Drawing.Point(508, 3);
			this.lblCurrentText.Name = "lblCurrentText";
			this.lblCurrentText.Size = new System.Drawing.Size(163, 35);
			this.lblCurrentText.TabIndex = 0;
			this.lblCurrentText.Text = "전력 사용량(kWh)";
			// 
			// lblLeakText
			// 
			this.lblLeakText.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblLeakText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.lblLeakText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lblLeakText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblLeakText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLeakText.Location = new System.Drawing.Point(508, 57);
			this.lblLeakText.Name = "lblLeakText";
			this.lblLeakText.Size = new System.Drawing.Size(163, 35);
			this.lblLeakText.TabIndex = 1;
			this.lblLeakText.Text = "누설 전류(mA)";
			// 
			// lblVoltageText
			// 
			this.lblVoltageText.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblVoltageText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.lblVoltageText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lblVoltageText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblVoltageText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblVoltageText.Location = new System.Drawing.Point(508, 111);
			this.lblVoltageText.Name = "lblVoltageText";
			this.lblVoltageText.Size = new System.Drawing.Size(163, 35);
			this.lblVoltageText.TabIndex = 2;
			this.lblVoltageText.Text = "전압 모듈(V)";
			// 
			// lblCarbonText
			// 
			this.lblCarbonText.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblCarbonText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.lblCarbonText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lblCarbonText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblCarbonText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCarbonText.Location = new System.Drawing.Point(508, 165);
			this.lblCarbonText.Name = "lblCarbonText";
			this.lblCarbonText.Size = new System.Drawing.Size(163, 35);
			this.lblCarbonText.TabIndex = 3;
			this.lblCarbonText.Text = "탄소 배출량(kCO₂)";
			// 
			// lblCurrent
			// 
			this.lblCurrent.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblCurrent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCurrent.Location = new System.Drawing.Point(340, 3);
			this.lblCurrent.Name = "lblCurrent";
			this.lblCurrent.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.lblCurrent.Size = new System.Drawing.Size(162, 35);
			this.lblCurrent.TabIndex = 4;
			this.lblCurrent.Text = "labelControl1";
			// 
			// lblLeak
			// 
			this.lblLeak.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblLeak.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblLeak.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblLeak.Location = new System.Drawing.Point(340, 57);
			this.lblLeak.Name = "lblLeak";
			this.lblLeak.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.lblLeak.Size = new System.Drawing.Size(162, 35);
			this.lblLeak.TabIndex = 5;
			this.lblLeak.Text = "labelControl2";
			// 
			// lblVoltage
			// 
			this.lblVoltage.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblVoltage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblVoltage.Location = new System.Drawing.Point(340, 111);
			this.lblVoltage.Name = "lblVoltage";
			this.lblVoltage.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.lblVoltage.Size = new System.Drawing.Size(162, 35);
			this.lblVoltage.TabIndex = 6;
			this.lblVoltage.Text = "labelControl3";
			// 
			// lblCarbon
			// 
			this.lblCarbon.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F);
			this.lblCarbon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblCarbon.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCarbon.Location = new System.Drawing.Point(340, 165);
			this.lblCarbon.Name = "lblCarbon";
			this.lblCarbon.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.lblCarbon.Size = new System.Drawing.Size(162, 35);
			this.lblCarbon.TabIndex = 7;
			this.lblCarbon.Text = "labelControl4";
			// 
			// gaugeControl1
			// 
			this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge1});
			this.gaugeControl1.Location = new System.Drawing.Point(3, 3);
			this.gaugeControl1.Name = "gaugeControl1";
			this.tableLayoutPanel1.SetRowSpan(this.gaugeControl1, 10);
			this.gaugeControl1.Size = new System.Drawing.Size(331, 269);
			this.gaugeControl1.TabIndex = 8;
			// 
			// circularGauge1
			// 
			this.circularGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
			this.circularGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 319, 257);
			this.circularGauge1.Name = "circularGauge1";
			this.circularGauge1.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
			this.circularGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponent1});
			// 
			// arcScaleComponent1
			// 
			this.arcScaleComponent1.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F);
			this.arcScaleComponent1.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
			this.arcScaleComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 140F);
			this.arcScaleComponent1.EndAngle = 30F;
			this.arcScaleComponent1.MajorTickCount = 9;
			this.arcScaleComponent1.MajorTickmark.FormatString = "{0:F0}";
			this.arcScaleComponent1.MajorTickmark.ShapeOffset = -3.5F;
			this.arcScaleComponent1.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style1_4;
			this.arcScaleComponent1.MajorTickmark.TextOffset = -15F;
			this.arcScaleComponent1.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
			this.arcScaleComponent1.MaxValue = 90F;
			this.arcScaleComponent1.MinorTickCount = 4;
			this.arcScaleComponent1.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style1_3;
			this.arcScaleComponent1.MinValue = 10F;
			this.arcScaleComponent1.Name = "scale1";
			this.arcScaleComponent1.StartAngle = -210F;
			this.arcScaleComponent1.Value = 80F;
			// 
			// arcScaleBackgroundLayerComponent1
			// 
			this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponent1;
			this.arcScaleBackgroundLayerComponent1.Name = "bg";
			this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.619F);
			this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularThreeFourth_Style1;
			this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(250F, 202F);
			this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
			// 
			// arcScaleNeedleComponent1
			// 
			this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponent1;
			this.arcScaleNeedleComponent1.Name = "needle";
			this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style1;
			this.arcScaleNeedleComponent1.StartOffset = -4.5F;
			this.arcScaleNeedleComponent1.ZOrder = -50;
			// 
			// UCCurrentInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "UCCurrentInfo";
			this.Size = new System.Drawing.Size(674, 275);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private DevExpress.XtraEditors.LabelControl lblCurrentText;
		private DevExpress.XtraEditors.LabelControl lblLeakText;
		private DevExpress.XtraEditors.LabelControl lblVoltageText;
		private DevExpress.XtraEditors.LabelControl lblCarbonText;
		private DevExpress.XtraEditors.LabelControl lblCurrent;
		private DevExpress.XtraEditors.LabelControl lblLeak;
		private DevExpress.XtraEditors.LabelControl lblVoltage;
		private DevExpress.XtraEditors.LabelControl lblCarbon;
		private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
		private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge1;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent1;
		private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
	}
}
