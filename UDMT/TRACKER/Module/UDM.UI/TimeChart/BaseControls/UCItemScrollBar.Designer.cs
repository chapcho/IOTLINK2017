namespace UDM.UI.TimeChart
{
	partial class UCItemScrollBar
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
			this.scbItem = new DevExpress.XtraEditors.VScrollBar();
			this.SuspendLayout();
			// 
			// scbItem
			// 
			this.scbItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scbItem.Location = new System.Drawing.Point(0, 0);
			this.scbItem.Name = "scbItem";
			this.scbItem.Size = new System.Drawing.Size(200, 100);
			this.scbItem.TabIndex = 0;
			this.scbItem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scbItem_Scroll);
			// 
			// UCItemScrollBar
			// 
			this.Controls.Add(this.scbItem);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.VScrollBar scbItem;
	}
}
