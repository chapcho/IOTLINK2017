namespace UDMTrackerSimple
{
	partial class UCFlowGanttEditor2
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
			this.ucTimeChart = new UDM.UI.TimeChart.UCTimeChart();
			this.SuspendLayout();
			// 
			// ucTimeChart
			// 
			this.ucTimeChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucTimeChart.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.ucTimeChart.Location = new System.Drawing.Point(0, 0);
			this.ucTimeChart.Name = "ucTimeChart";
			this.ucTimeChart.Size = new System.Drawing.Size(530, 423);
			this.ucTimeChart.TabIndex = 0;
			// 
			// UCFlowGanttEditor2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ucTimeChart);
			this.Name = "UCFlowGanttEditor2";
			this.Size = new System.Drawing.Size(530, 423);
			this.Load += new System.EventHandler(this.UCFlowGanttEditor2_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private UDM.UI.TimeChart.UCTimeChart ucTimeChart;
	}
}
