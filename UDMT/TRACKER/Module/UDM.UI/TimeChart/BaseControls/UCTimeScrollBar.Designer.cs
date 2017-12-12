namespace UDM.UI.TimeChart
{
	partial class UCTimeScrollBar
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
			this.scbRange = new DevExpress.XtraEditors.HScrollBar();
			this.SuspendLayout();
			// 
			// scbRange
			// 
			this.scbRange.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scbRange.Location = new System.Drawing.Point(0, 0);
			this.scbRange.Name = "scbRange";
			this.scbRange.Size = new System.Drawing.Size(200, 100);
			this.scbRange.TabIndex = 0;
			this.scbRange.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scbRange_Scroll);
			// 
			// UCTimeScrollBar
			// 
			this.Controls.Add(this.scbRange);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.HScrollBar scbRange;


	}
}
