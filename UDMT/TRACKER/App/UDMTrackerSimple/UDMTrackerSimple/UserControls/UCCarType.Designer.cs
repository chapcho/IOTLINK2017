namespace UDMTrackerSimple
{
    partial class UCCarType
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
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlCarType = new DevExpress.XtraEditors.PanelControl();
            this.lblCarType = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(273, 48);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Group Name";
            // 
            // pnlCarType
            // 
            this.pnlCarType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCarType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarType.Location = new System.Drawing.Point(0, 48);
            this.pnlCarType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCarType.Name = "pnlCarType";
            this.pnlCarType.Size = new System.Drawing.Size(273, 137);
            this.pnlCarType.TabIndex = 2;
            // 
            // lblCarType
            // 
            this.lblCarType.Appearance.Font = new System.Drawing.Font("Tahoma", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarType.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCarType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCarType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCarType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCarType.Location = new System.Drawing.Point(0, 48);
            this.lblCarType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCarType.Name = "lblCarType";
            this.lblCarType.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.lblCarType.Size = new System.Drawing.Size(273, 137);
            this.lblCarType.TabIndex = 3;
            this.lblCarType.Text = "Type";
            // 
            // UCCarType
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCarType);
            this.Controls.Add(this.pnlCarType);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCCarType";
            this.Size = new System.Drawing.Size(273, 185);
            this.Resize += new System.EventHandler(this.UCCarType_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCarType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PanelControl pnlCarType;
        private DevExpress.XtraEditors.LabelControl lblCarType;
    }
}
