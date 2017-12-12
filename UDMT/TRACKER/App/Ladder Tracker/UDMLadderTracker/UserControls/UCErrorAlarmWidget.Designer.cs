namespace UDMLadderTracker
{
    partial class UCErrorAlarmWidget
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
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBackground = new DevExpress.XtraEditors.PanelControl();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProcess
            // 
            this.lblProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblProcess.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblProcess.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcess.Location = new System.Drawing.Point(12, 14);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(515, 62);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "GROUP";
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(12, 76);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(515, 253);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "0";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // pnlBackground
            // 
            this.pnlBackground.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBackground.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.pnlBackground.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBackground.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBackground.Appearance.Options.UseBackColor = true;
            this.pnlBackground.Appearance.Options.UseBorderColor = true;
            this.pnlBackground.Controls.Add(this.lblText);
            this.pnlBackground.Controls.Add(this.lblProcess);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBackground.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.pnlBackground.Size = new System.Drawing.Size(539, 343);
            this.pnlBackground.TabIndex = 5;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 500;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // UCErrorAlarmWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBackground);
            this.Name = "UCErrorAlarmWidget";
            this.Size = new System.Drawing.Size(539, 343);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackground)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraEditors.LabelControl lblText;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl pnlBackground;
        private System.Windows.Forms.Timer tmrTimer;

    }
}
