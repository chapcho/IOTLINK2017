namespace UDMLadderTracker
{
    partial class UCFlowPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFlowPanel));
            this.pnlArrow = new System.Windows.Forms.Panel();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblStepText = new DevExpress.XtraEditors.LabelControl();
            this.pnlArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlArrow
            // 
            this.pnlArrow.BackColor = System.Drawing.Color.White;
            this.pnlArrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlArrow.BackgroundImage")));
            this.pnlArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlArrow.Controls.Add(this.lblCount);
            this.pnlArrow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArrow.Location = new System.Drawing.Point(2, 0);
            this.pnlArrow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlArrow.Name = "pnlArrow";
            this.pnlArrow.Size = new System.Drawing.Size(349, 29);
            this.pnlArrow.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCount.Location = new System.Drawing.Point(19, 4);
            this.lblCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(11, 24);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "1";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblStepText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 29);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(349, 47);
            this.pnlMain.TabIndex = 1;
            // 
            // lblStepText
            // 
            this.lblStepText.Appearance.BackColor = System.Drawing.Color.Cyan;
            this.lblStepText.Appearance.BackColor2 = System.Drawing.Color.Cyan;
            this.lblStepText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStepText.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStepText.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblStepText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStepText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStepText.AutoEllipsis = true;
            this.lblStepText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStepText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblStepText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepText.Location = new System.Drawing.Point(2, 2);
            this.lblStepText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStepText.Name = "lblStepText";
            this.lblStepText.Size = new System.Drawing.Size(345, 43);
            this.lblStepText.TabIndex = 8;
            this.lblStepText.Text = "후크핀 상승";
            // 
            // UCFlowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlArrow);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCFlowPanel";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(353, 76);
            this.pnlArrow.ResumeLayout(false);
            this.pnlArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlArrow;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblCount;
        private DevExpress.XtraEditors.LabelControl lblStepText;

    }
}
