namespace UDMTracker
{
	partial class FrmTileItemDetailView
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnErr1 = new DevExpress.XtraEditors.SimpleButton();
			this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tblPanel.SuspendLayout();
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
			this.btnErr1.Location = new System.Drawing.Point(3, 3);
			this.btnErr1.Name = "btnErr1";
			this.btnErr1.Size = new System.Drawing.Size(647, 490);
			this.btnErr1.TabIndex = 0;
			this.btnErr1.Text = "지연!";
			this.btnErr1.Click += new System.EventHandler(this.btnErr1_Click);
			// 
			// tblPanel
			// 
			this.tblPanel.ColumnCount = 1;
			this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanel.Controls.Add(this.btnErr1, 0, 0);
			this.tblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblPanel.Location = new System.Drawing.Point(0, 0);
			this.tblPanel.Name = "tblPanel";
			this.tblPanel.RowCount = 1;
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPanel.Size = new System.Drawing.Size(653, 496);
			this.tblPanel.TabIndex = 1;
			// 
			// FrmDetailView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 496);
			this.Controls.Add(this.tblPanel);
			this.Name = "FrmDetailView";
			this.Text = "FrmDetailView";
			this.Load += new System.EventHandler(this.FrmDetailView_Load);
			this.tblPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UDM.Tile.UCTileItemDetailView ucTileItemDetailView;
		private DevExpress.XtraEditors.SimpleButton btnErr1;
		private System.Windows.Forms.TableLayoutPanel tblPanel;


	}
}