namespace UDM.Tile
{
	partial class UCTileControl
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
			DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
			this.TileControl = new DevExpress.XtraEditors.TileControl();
			this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
			this.tileItem1 = new DevExpress.XtraEditors.TileItem();
			this.SuspendLayout();
			// 
			// TileControl
			// 
			this.TileControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.TileControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TileControl.Groups.Add(this.tileGroup1);
			this.TileControl.ItemSize = 300;
			this.TileControl.Location = new System.Drawing.Point(0, 0);
			this.TileControl.Name = "TileControl";
			this.TileControl.Size = new System.Drawing.Size(850, 491);
			this.TileControl.TabIndex = 0;
			this.TileControl.Text = "tileControl1";
			// 
			// tileGroup1
			// 
			this.tileGroup1.Items.Add(this.tileItem1);
			this.tileGroup1.Name = "tileGroup1";
			this.tileGroup1.Text = "tileGroup1";
			// 
			// tileItem1
			// 
			this.tileItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
			this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.Green;
			this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
			tileItemElement1.Text = "tileItem1";
			this.tileItem1.Elements.Add(tileItemElement1);
			this.tileItem1.Name = "tileItem1";
			// 
			// UCTileControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TileControl);
			this.Name = "UCTileControl";
			this.Size = new System.Drawing.Size(850, 491);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.TileControl TileControl;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
        private DevExpress.XtraEditors.TileItem tileItem1;
	}
}
