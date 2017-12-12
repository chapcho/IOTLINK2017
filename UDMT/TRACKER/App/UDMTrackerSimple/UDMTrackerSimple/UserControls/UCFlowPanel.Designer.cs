namespace UDMTrackerSimple
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFlowPanel));
            this.pnlArrow = new System.Windows.Forms.Panel();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.cntxError = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnErrorGen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditText = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStepText = new DevExpress.XtraEditors.LabelControl();
            this.pnlArrow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.cntxError.SuspendLayout();
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
            this.pnlArrow.Name = "pnlArrow";
            this.pnlArrow.Size = new System.Drawing.Size(305, 23);
            this.pnlArrow.TabIndex = 0;
            this.pnlArrow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.pnlArrow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.pnlArrow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // lblCount
            // 
            this.lblCount.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCount.Location = new System.Drawing.Point(17, 3);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(9, 19);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "1";
            // 
            // pnlMain
            // 
            this.pnlMain.ContextMenuStrip = this.cntxError;
            this.pnlMain.Controls.Add(this.lblStepText);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 23);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(305, 36);
            this.pnlMain.TabIndex = 1;
            // 
            // cntxError
            // 
            this.cntxError.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnErrorGen,
            this.btnEditText});
            this.cntxError.Name = "cntxError";
            this.cntxError.Size = new System.Drawing.Size(267, 70);
            // 
            // btnErrorGen
            // 
            this.btnErrorGen.Image = ((System.Drawing.Image)(resources.GetObject("btnErrorGen.Image")));
            this.btnErrorGen.Name = "btnErrorGen";
            this.btnErrorGen.Size = new System.Drawing.Size(266, 22);
            this.btnErrorGen.Text = "해당 신호 기준 무언 정지 원인 찾기";
            this.btnErrorGen.Click += new System.EventHandler(this.btnErrorGen_Click);
            // 
            // btnEditText
            // 
            this.btnEditText.Image = ((System.Drawing.Image)(resources.GetObject("btnEditText.Image")));
            this.btnEditText.Name = "btnEditText";
            this.btnEditText.Size = new System.Drawing.Size(266, 22);
            this.btnEditText.Text = "Flow Chart 텍스트 변경";
            this.btnEditText.Click += new System.EventHandler(this.btnEditText_Click);
            // 
            // lblStepText
            // 
            this.lblStepText.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.lblStepText.Appearance.BackColor2 = System.Drawing.Color.Gainsboro;
            this.lblStepText.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStepText.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStepText.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.lblStepText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStepText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStepText.AutoEllipsis = true;
            this.lblStepText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStepText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblStepText.ContextMenuStrip = this.cntxError;
            this.lblStepText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepText.Location = new System.Drawing.Point(2, 2);
            this.lblStepText.Name = "lblStepText";
            this.lblStepText.Size = new System.Drawing.Size(301, 32);
            this.lblStepText.TabIndex = 8;
            this.lblStepText.Text = "후크핀 상승";
            this.lblStepText.DoubleClick += new System.EventHandler(this.lblStepText_DoubleClick);
            this.lblStepText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblStepText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblStepText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // UCFlowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlArrow);
            this.Name = "UCFlowPanel";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Size = new System.Drawing.Size(309, 59);
            this.pnlArrow.ResumeLayout(false);
            this.pnlArrow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.cntxError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlArrow;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblCount;
        private DevExpress.XtraEditors.LabelControl lblStepText;
        private System.Windows.Forms.ContextMenuStrip cntxError;
        private System.Windows.Forms.ToolStripMenuItem btnErrorGen;
        private System.Windows.Forms.ToolStripMenuItem btnEditText;

    }
}
