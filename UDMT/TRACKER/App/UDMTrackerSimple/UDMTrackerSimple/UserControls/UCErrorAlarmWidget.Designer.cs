namespace UDMTrackerSimple
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
            this.lblProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblProcess.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblProcess.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcess.Location = new System.Drawing.Point(12, 14);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(221, 48);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "GROUP";
            this.lblProcess.Click += new System.EventHandler(this.pnlBackground_Click);
            this.lblProcess.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            this.lblProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblProcess.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblProcess.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(12, 62);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(221, 88);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "0";
            this.lblText.Visible = false;
            this.lblText.Click += new System.EventHandler(this.pnlBackground_Click);
            this.lblText.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            this.lblText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.lblText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.lblText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // pnlBackground
            // 
            this.pnlBackground.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pnlBackground.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.pnlBackground.Appearance.BorderColor = System.Drawing.Color.Transparent;
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
            this.pnlBackground.Size = new System.Drawing.Size(245, 164);
            this.pnlBackground.TabIndex = 5;
            this.pnlBackground.Click += new System.EventHandler(this.pnlBackground_Click);
            this.pnlBackground.DoubleClick += new System.EventHandler(this.pnlBackground_DoubleClick);
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.All_MouseDown);
            this.pnlBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.All_MouseMove);
            this.pnlBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.All_MouseUp);
            this.pnlBackground.Resize += new System.EventHandler(this.pnlBackground_Resize);
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
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlBackground);
            this.Name = "UCErrorAlarmWidget";
            this.Size = new System.Drawing.Size(245, 164);
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
