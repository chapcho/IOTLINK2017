namespace UDMTracker
{
    partial class FrmAlertViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlertViewer));
            this.pnlBackGround = new DevExpress.XtraEditors.PanelControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.lblGroup = new DevExpress.XtraEditors.LabelControl();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackGround)).BeginInit();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlBackGround.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.pnlBackGround.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlBackGround.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBackGround.Appearance.Options.UseBackColor = true;
            this.pnlBackGround.Appearance.Options.UseBorderColor = true;
            this.pnlBackGround.Controls.Add(this.lblMessage);
            this.pnlBackGround.Controls.Add(this.lblGroup);
            this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGround.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGround.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlBackGround.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.pnlBackGround.Size = new System.Drawing.Size(938, 720);
            this.pnlBackGround.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(10, 134);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(918, 574);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "개소 이상 감지";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // lblGroup
            // 
            this.lblGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblGroup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblGroup.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroup.Location = new System.Drawing.Point(10, 12);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(918, 122);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "GROUP";
            this.lblGroup.Click += new System.EventHandler(this.lblGroup_Click);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 1000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // FrmAlertViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 720);
            this.Controls.Add(this.pnlBackGround);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAlertViewer";
            this.Text = "Alert View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAlertViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBackGround)).EndInit();
            this.pnlBackGround.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBackGround;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.LabelControl lblGroup;
        private System.Windows.Forms.Timer tmrTimer;

    }
}