namespace UExpression
{
	partial class UCSplitPanel
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
			this.pnlHead = new System.Windows.Forms.Panel();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlBase = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pnlHead
			// 
			this.pnlHead.BackColor = System.Drawing.SystemColors.Control;
			this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHead.Location = new System.Drawing.Point(0, 0);
			this.pnlHead.Name = "pnlHead";
			this.pnlHead.Size = new System.Drawing.Size(200, 100);
			this.pnlHead.TabIndex = 0;
			// 
			// pnlBody
			// 
			this.pnlBody.BackColor = System.Drawing.Color.White;
			this.pnlBody.Location = new System.Drawing.Point(0, 0);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Size = new System.Drawing.Size(200, 100);
			this.pnlBody.TabIndex = 0;
			// 
			// pnlBase
			// 
			this.pnlBase.Location = new System.Drawing.Point(0, 0);
			this.pnlBase.Name = "pnlBase";
			this.pnlBase.Padding = new System.Windows.Forms.Padding(1);
			this.pnlBase.Size = new System.Drawing.Size(200, 100);
			this.pnlBase.TabIndex = 0;
			// 
			// UCSplitPanel
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BackColorChanged += new System.EventHandler(this.UCSplitPanel_BackColorChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHead;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel pnlBase;
	}
}
