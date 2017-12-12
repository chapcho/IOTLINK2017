namespace UDM.Tile
{
	partial class UCTileItemErrorAlert
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
			this.btnErr1 = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// btnErr1
			// 
			this.btnErr1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.btnErr1.Appearance.BackColor2 = System.Drawing.Color.Red;
			this.btnErr1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnErr1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
			this.btnErr1.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnErr1.Appearance.Options.UseBackColor = true;
			this.btnErr1.Appearance.Options.UseBorderColor = true;
			this.btnErr1.Appearance.Options.UseFont = true;
			this.btnErr1.Appearance.Options.UseForeColor = true;
			this.btnErr1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
			this.btnErr1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnErr1.Location = new System.Drawing.Point(0, 0);
			this.btnErr1.Name = "btnErr1";
			this.btnErr1.Size = new System.Drawing.Size(426, 289);
			this.btnErr1.TabIndex = 2;
			this.btnErr1.Text = "지연!";
			// 
			// UCTileItemErrorAlert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnErr1);
			this.Name = "UCTileItemErrorAlert";
			this.Size = new System.Drawing.Size(426, 289);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnErr1;



	}
}
