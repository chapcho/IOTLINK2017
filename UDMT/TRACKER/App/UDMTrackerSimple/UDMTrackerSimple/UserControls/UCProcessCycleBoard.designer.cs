namespace UDMTrackerSimple
{
	partial class UCProcessCycleBoard
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.ucCycleTimeInfo = new UDMTrackerSimple.UCCircleGauge2Row();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.ucCycleTimeInfo);
            this.pnlMain.Controls.Add(this.panelControl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMain.Size = new System.Drawing.Size(239, 148);
            this.pnlMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lblTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(5, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(229, 19);
            this.panelControl1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(229, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Group Name";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);
            // 
            // ucCycleTimeInfo
            // 
            this.ucCycleTimeInfo.BackColor = System.Drawing.Color.White;
            this.ucCycleTimeInfo.BottomLabelCaption = "목표 CT";
            this.ucCycleTimeInfo.BottomLabelText = "0.00s";
            this.ucCycleTimeInfo.CircleText = "0s";
            this.ucCycleTimeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCycleTimeInfo.Location = new System.Drawing.Point(5, 24);
            this.ucCycleTimeInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucCycleTimeInfo.MaxBarColor = System.Drawing.Color.LightGray;
            this.ucCycleTimeInfo.MaxValue = 30F;
            this.ucCycleTimeInfo.Name = "ucCycleTimeInfo";
            this.ucCycleTimeInfo.Size = new System.Drawing.Size(229, 119);
            this.ucCycleTimeInfo.TabIndex = 1;
            this.ucCycleTimeInfo.TitleText = "Cycle Time";
            this.ucCycleTimeInfo.TopLabelCaption = "평균 CT";
            this.ucCycleTimeInfo.TopLabelText = "0.00s";
            this.ucCycleTimeInfo.Value = 30F;
            this.ucCycleTimeInfo.ValueBarColor = System.Drawing.Color.GreenYellow;
            this.ucCycleTimeInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucCycleTimeInfo_MouseDown);
            this.ucCycleTimeInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucCycleTimeInfo_MouseMove);
            this.ucCycleTimeInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucCycleTimeInfo_MouseUp);
            // 
            // UCProcessCycleBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "UCProcessCycleBoard";
            this.Size = new System.Drawing.Size(239, 148);
            this.Load += new System.EventHandler(this.UCGroupBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private UCCircleGauge2Row ucCycleTimeInfo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
	}
}
