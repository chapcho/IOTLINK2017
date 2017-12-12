namespace UDMProfiler
{
    partial class UCPlcSetting
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
            this.pnlPlcInfo = new DevExpress.XtraEditors.PanelControl();
            this.pnlCollectorInfo = new DevExpress.XtraEditors.PanelControl();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlcInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCollectorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPlcInfo
            // 
            this.pnlPlcInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlPlcInfo.Appearance.Options.UseBackColor = true;
            this.pnlPlcInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPlcInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlcInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPlcInfo.Name = "pnlPlcInfo";
            this.pnlPlcInfo.Size = new System.Drawing.Size(569, 475);
            this.pnlPlcInfo.TabIndex = 0;
            // 
            // pnlCollectorInfo
            // 
            this.pnlCollectorInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlCollectorInfo.Appearance.Options.UseBackColor = true;
            this.pnlCollectorInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCollectorInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCollectorInfo.Location = new System.Drawing.Point(574, 0);
            this.pnlCollectorInfo.Name = "pnlCollectorInfo";
            this.pnlCollectorInfo.Size = new System.Drawing.Size(314, 475);
            this.pnlCollectorInfo.TabIndex = 1;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.sptMain.Location = new System.Drawing.Point(569, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(5, 475);
            this.sptMain.TabIndex = 2;
            this.sptMain.TabStop = false;
            // 
            // UCPlcSetting
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPlcInfo);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.pnlCollectorInfo);
            this.Name = "UCPlcSetting";
            this.Size = new System.Drawing.Size(888, 475);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlcInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCollectorInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlPlcInfo;
        private DevExpress.XtraEditors.PanelControl pnlCollectorInfo;
        private DevExpress.XtraEditors.SplitterControl sptMain;
    }
}
