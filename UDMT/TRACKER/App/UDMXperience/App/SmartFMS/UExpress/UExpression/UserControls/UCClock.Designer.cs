namespace UExpression
{
	partial class UCClock
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
			this.components = new System.ComponentModel.Container();
			this.tmrTimer = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblDate = new UExpression.AutoFontSizeLabel();
			this.lblTime = new UExpression.AutoFontSizeLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrTimer
			// 
			this.tmrTimer.Interval = 500;
			this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.lblDate, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblTime, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 36);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// lblDate
			// 
			this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.lblDate.ForeColor = System.Drawing.Color.White;
			this.lblDate.Location = new System.Drawing.Point(3, 0);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(108, 36);
			this.lblDate.TabIndex = 0;
			this.lblDate.Text = "autoFontSizeLabel1";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTime
			// 
			this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTime.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.lblTime.ForeColor = System.Drawing.Color.White;
			this.lblTime.Location = new System.Drawing.Point(117, 0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(109, 36);
			this.lblTime.TabIndex = 1;
			this.lblTime.Text = "autoFontSizeLabel2";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UCClock
			// 
			this.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "UCClock";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(235, 42);
			this.Load += new System.EventHandler(this.UCClock_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCClock_Paint);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer tmrTimer;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private AutoFontSizeLabel lblDate;
		private AutoFontSizeLabel lblTime;
	}
}
