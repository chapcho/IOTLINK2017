namespace UExpression
{
	partial class UCMonitorState
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
			this.ucSplitPanel1 = new UExpression.UCSplitPanel(this.components);
			this.ucClock1 = new UExpression.UCClock();
			this.label1 = new System.Windows.Forms.Label();
			this.ucSplitPanel1.BodyPanel.SuspendLayout();
			this.ucSplitPanel1.HeaderPanel.SuspendLayout();
			this.ucSplitPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ucSplitPanel1
			// 
			// 
			// ucSplitPanel1.BodyPanel
			// 
			this.ucSplitPanel1.BodyPanel.BackColor = System.Drawing.Color.Transparent;
			this.ucSplitPanel1.BodyPanel.Controls.Add(this.ucClock1);
			this.ucSplitPanel1.BodyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucSplitPanel1.BodyPanel.Location = new System.Drawing.Point(0, 55);
			this.ucSplitPanel1.BodyPanel.Name = "BodyPanel";
			this.ucSplitPanel1.BodyPanel.Padding = new System.Windows.Forms.Padding(5);
			this.ucSplitPanel1.BodyPanel.Size = new System.Drawing.Size(256, 48);
			this.ucSplitPanel1.BodyPanel.TabIndex = 0;
			this.ucSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
			// 
			// ucSplitPanel1.HeaderPanel
			// 
			this.ucSplitPanel1.HeaderPanel.BackColor = System.Drawing.Color.Transparent;
			this.ucSplitPanel1.HeaderPanel.Controls.Add(this.label1);
			this.ucSplitPanel1.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucSplitPanel1.HeaderPanel.Location = new System.Drawing.Point(0, 0);
			this.ucSplitPanel1.HeaderPanel.Name = "HeaderPanel";
			this.ucSplitPanel1.HeaderPanel.Size = new System.Drawing.Size(256, 55);
			this.ucSplitPanel1.HeaderPanel.TabIndex = 0;
			this.ucSplitPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucSplitPanel1.Name = "ucSplitPanel1";
			this.ucSplitPanel1.Opacity = 100;
			this.ucSplitPanel1.Size = new System.Drawing.Size(256, 103);
			this.ucSplitPanel1.SplitterColor = System.Drawing.Color.White;
			this.ucSplitPanel1.SplitterHeight = 1;
			this.ucSplitPanel1.TabIndex = 0;
			this.ucSplitPanel1.UseOpacity = false;
			// 
			// ucClock1
			// 
			this.ucClock1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.ucClock1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.ucClock1.Appearance.Options.UseBackColor = true;
			this.ucClock1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucClock1.Location = new System.Drawing.Point(5, 5);
			this.ucClock1.Name = "ucClock1";
			this.ucClock1.Padding = new System.Windows.Forms.Padding(3);
			this.ucClock1.Size = new System.Drawing.Size(246, 38);
			this.ucClock1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Malgun Gothic", 25F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 55);
			this.label1.TabIndex = 0;
			this.label1.Text = "Monitor ON";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UCMonitorState
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ucSplitPanel1);
			this.Name = "UCMonitorState";
			this.Size = new System.Drawing.Size(256, 103);
			this.BackColorChanged += new System.EventHandler(this.UCMonitorState_BackColorChanged);
			this.ucSplitPanel1.BodyPanel.ResumeLayout(false);
			this.ucSplitPanel1.HeaderPanel.ResumeLayout(false);
			this.ucSplitPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UCSplitPanel ucSplitPanel1;
		private System.Windows.Forms.Label label1;
		private UCClock ucClock1;
	}
}
