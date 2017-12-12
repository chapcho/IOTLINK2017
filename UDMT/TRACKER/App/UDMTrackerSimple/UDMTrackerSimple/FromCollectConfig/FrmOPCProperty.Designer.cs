namespace UDMTrackerSimple
{
	partial class FrmOPCProperty
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.ucOPCProperty = new UCOPCProperty();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Controls.Add(this.btnOK);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 161);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Padding = new System.Windows.Forms.Padding(3);
            this.pnlControl.Size = new System.Drawing.Size(452, 30);
            this.pnlControl.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(379, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucOPCProperty
            // 
            this.ucOPCProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOPCProperty.Editable = false;
            this.ucOPCProperty.Location = new System.Drawing.Point(0, 0);
            this.ucOPCProperty.Name = "ucOPCProperty";
            this.ucOPCProperty.OPCConfig = null;
            this.ucOPCProperty.Size = new System.Drawing.Size(452, 161);
            this.ucOPCProperty.TabIndex = 4;
            // 
            // FrmOPCProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 191);
            this.Controls.Add(this.ucOPCProperty);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmOPCProperty";
            this.Text = "OPC Property";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmOPCProperty_FormClosed);
            this.Load += new System.EventHandler(this.FrmOPCProperty_Load);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlControl;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOK;
		private UCOPCProperty ucOPCProperty;
	}
}