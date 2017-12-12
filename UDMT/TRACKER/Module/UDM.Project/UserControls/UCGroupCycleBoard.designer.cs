namespace UDM.Project
{
	partial class UCGroupCycleBoard
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
			this.pnlMain = new DevExpress.XtraEditors.PanelControl();
			this.splt2 = new DevExpress.XtraEditors.SplitterControl();
			this.splt1 = new DevExpress.XtraEditors.SplitterControl();
			this.lblTitle = new DevExpress.XtraEditors.LabelControl();
			this.ucCycleTimeHistory = new UDM.Project.UCSeriesChart();
			this.ucProductInfo = new UDM.Project.UCCircleGauge();
			this.ucCycleTimeInfo = new UDM.Project.UCCircleGauge2Row();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
			this.pnlMain.Appearance.Options.UseBackColor = true;
			this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnlMain.Controls.Add(this.ucCycleTimeHistory);
			this.pnlMain.Controls.Add(this.splt2);
			this.pnlMain.Controls.Add(this.ucProductInfo);
			this.pnlMain.Controls.Add(this.splt1);
			this.pnlMain.Controls.Add(this.ucCycleTimeInfo);
			this.pnlMain.Controls.Add(this.lblTitle);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
			this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
			this.pnlMain.Size = new System.Drawing.Size(1121, 147);
			this.pnlMain.TabIndex = 0;
			// 
			// splt2
			// 
			this.splt2.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.splt2.Appearance.Options.UseBackColor = true;
			this.splt2.Location = new System.Drawing.Point(377, 27);
			this.splt2.Name = "splt2";
			this.splt2.Size = new System.Drawing.Size(5, 115);
			this.splt2.TabIndex = 4;
			this.splt2.TabStop = false;
			// 
			// splt1
			// 
			this.splt1.Appearance.BackColor = System.Drawing.Color.DimGray;
			this.splt1.Appearance.Options.UseBackColor = true;
			this.splt1.Location = new System.Drawing.Point(236, 27);
			this.splt1.Name = "splt1";
			this.splt1.Size = new System.Drawing.Size(5, 115);
			this.splt1.TabIndex = 2;
			this.splt1.TabStop = false;
			// 
			// lblTitle
			// 
			this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitle.Location = new System.Drawing.Point(5, 5);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.lblTitle.Size = new System.Drawing.Size(1111, 22);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Group Name";
			// 
			// ucCycleTimeHistory
			// 
			this.ucCycleTimeHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucCycleTimeHistory.Location = new System.Drawing.Point(382, 27);
			this.ucCycleTimeHistory.Name = "ucCycleTimeHistory";
			this.ucCycleTimeHistory.Size = new System.Drawing.Size(734, 115);
			this.ucCycleTimeHistory.TabIndex = 5;
			this.ucCycleTimeHistory.TitleText = "Cycle Time History";
			// 
			// ucProductInfo
			// 
			this.ucProductInfo.BackColor = System.Drawing.Color.White;
			this.ucProductInfo.CircleText = "0";
			this.ucProductInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.ucProductInfo.Location = new System.Drawing.Point(241, 27);
			this.ucProductInfo.MaxBarColor = System.Drawing.Color.LightGray;
			this.ucProductInfo.MaxValue = 30F;
			this.ucProductInfo.Name = "ucProductInfo";
			this.ucProductInfo.Size = new System.Drawing.Size(136, 115);
			this.ucProductInfo.TabIndex = 3;
			this.ucProductInfo.TitleText = "Product";
			this.ucProductInfo.Value = 30F;
			this.ucProductInfo.ValueBarColor = System.Drawing.Color.DeepSkyBlue;
			// 
			// ucCycleTimeInfo
			// 
			this.ucCycleTimeInfo.BackColor = System.Drawing.Color.White;
			this.ucCycleTimeInfo.BottomLabelCaption = "Maximum";
			this.ucCycleTimeInfo.BottomLabelText = "0.00s";
			this.ucCycleTimeInfo.CircleText = "0s";
			this.ucCycleTimeInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.ucCycleTimeInfo.Location = new System.Drawing.Point(5, 27);
			this.ucCycleTimeInfo.MaxBarColor = System.Drawing.Color.LightGray;
			this.ucCycleTimeInfo.MaxValue = 30F;
			this.ucCycleTimeInfo.Name = "ucCycleTimeInfo";
			this.ucCycleTimeInfo.Size = new System.Drawing.Size(231, 115);
			this.ucCycleTimeInfo.TabIndex = 1;
			this.ucCycleTimeInfo.TitleText = "Cycle Time";
			this.ucCycleTimeInfo.TopLabelCaption = "Average";
			this.ucCycleTimeInfo.TopLabelText = "0.00s";
			this.ucCycleTimeInfo.Value = 30F;
			this.ucCycleTimeInfo.ValueBarColor = System.Drawing.Color.GreenYellow;
			// 
			// UCGroupCycleBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlMain);
			this.Name = "UCGroupCycleBoard";
			this.Size = new System.Drawing.Size(1121, 147);
			this.Load += new System.EventHandler(this.UCGroupBoard_Load);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl pnlMain;
		private DevExpress.XtraEditors.LabelControl lblTitle;
		private UCCircleGauge2Row ucCycleTimeInfo;
		private DevExpress.XtraEditors.SplitterControl splt1;
		private UCCircleGauge ucProductInfo;
		private DevExpress.XtraEditors.SplitterControl splt2;
		private UCSeriesChart ucCycleTimeHistory;
	}
}
