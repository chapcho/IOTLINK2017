namespace UDMTrackerSimple
{
    partial class UCErrorCardWidget
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblErrorCount = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDetailError = new DevExpress.XtraEditors.LabelControl();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblMostError = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.63636F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 107);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 51);
            this.tableLayoutPanel1.TabIndex = 21;
            this.tableLayoutPanel1.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblErrorCount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(235, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel4.Size = new System.Drawing.Size(127, 45);
            this.panel4.TabIndex = 1;
            this.panel4.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // lblErrorCount
            // 
            this.lblErrorCount.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblErrorCount.Location = new System.Drawing.Point(112, 5);
            this.lblErrorCount.Name = "lblErrorCount";
            this.lblErrorCount.Size = new System.Drawing.Size(15, 37);
            this.lblErrorCount.TabIndex = 17;
            this.lblErrorCount.Text = "0";
            this.lblErrorCount.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDetailError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 45);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // lblDetailError
            // 
            this.lblDetailError.AllowHtmlString = true;
            this.lblDetailError.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailError.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDetailError.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDetailError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailError.Location = new System.Drawing.Point(0, 0);
            this.lblDetailError.Name = "lblDetailError";
            this.lblDetailError.Size = new System.Drawing.Size(0, 0);
            this.lblDetailError.TabIndex = 20;
            this.lblDetailError.DoubleClick += new System.EventHandler(this.tableLayoutPanel1_DoubleClick);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 500;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(369, 160);
            this.panelControl1.TabIndex = 22;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.lblMostError);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(365, 105);
            this.panelControl2.TabIndex = 22;
            // 
            // lblMostError
            // 
            this.lblMostError.AllowHtmlString = true;
            this.lblMostError.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostError.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblMostError.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMostError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMostError.Location = new System.Drawing.Point(0, 0);
            this.lblMostError.Name = "lblMostError";
            this.lblMostError.Size = new System.Drawing.Size(0, 0);
            this.lblMostError.TabIndex = 21;
            // 
            // UCErrorCardWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCErrorCardWidget";
            this.Size = new System.Drawing.Size(369, 160);
            this.DoubleClick += new System.EventHandler(this.UCErrorCardWidget_DoubleClick);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        public DevExpress.XtraEditors.LabelControl lblErrorCount;
        public DevExpress.XtraEditors.LabelControl lblDetailError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmrTimer;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.LabelControl lblMostError;
    }
}
