namespace UDM.Project
{
	partial class UCGroupStateChart
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
			this.pnlView = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlView
			// 
			this.pnlView.AutoScroll = true;
			this.pnlView.BackColor = System.Drawing.Color.White;
			this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlView.Location = new System.Drawing.Point(0, 0);
			this.pnlView.Name = "pnlView";
			this.pnlView.Size = new System.Drawing.Size(133, 135);
			this.pnlView.TabIndex = 0;
			// 
			// UCGroupStateChart
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.pnlView);
			this.Name = "UCGroupStateChart";
			this.Size = new System.Drawing.Size(133, 135);
			this.Load += new System.EventHandler(this.UCGroupStateChart_Load);
			this.Resize += new System.EventHandler(this.UCGroupStateChart_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlView;






	}
}
