﻿namespace UDMTrackerSimple
{
	partial class UCCheckNavBarControl
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
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// UCCheckNavBarControl
			// 
			this.CustomDrawGroupCaption += new DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventHandler(this.UCCheckNavBarControl_CustomDrawGroupCaption);
			this.CustomDrawLink += new DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventHandler(this.UCCheckNavBarControl_CustomDrawLink);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCCheckNavBarControl_MouseClick);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

	}
}
