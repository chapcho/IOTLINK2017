namespace NewIOMaker.Form.FormCommon.UserControl
{
    partial class ControlOption
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
            this.OptionSpliter = new DevExpress.XtraEditors.SplitContainerControl();
            this.MappingLog = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.IOListLog = new DevExpress.XtraEditors.GroupControl();
            this.BackupLog = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.OptionSpliter)).BeginInit();
            this.OptionSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IOListLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupLog)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionSpliter
            // 
            this.OptionSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionSpliter.Location = new System.Drawing.Point(0, 0);
            this.OptionSpliter.Name = "OptionSpliter";
            this.OptionSpliter.Panel1.Controls.Add(this.MappingLog);
            this.OptionSpliter.Panel1.Text = "Panel1";
            this.OptionSpliter.Panel2.Controls.Add(this.splitContainerControl1);
            this.OptionSpliter.Panel2.Text = "Panel2";
            this.OptionSpliter.Size = new System.Drawing.Size(700, 494);
            this.OptionSpliter.SplitterPosition = 230;
            this.OptionSpliter.TabIndex = 0;
            this.OptionSpliter.Text = "OptionSpliter";
            // 
            // MappingLog
            // 
            this.MappingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingLog.Location = new System.Drawing.Point(0, 0);
            this.MappingLog.Name = "MappingLog";
            this.MappingLog.Size = new System.Drawing.Size(230, 494);
            this.MappingLog.TabIndex = 0;
            this.MappingLog.Text = "Mapping Log";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.IOListLog);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.BackupLog);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(458, 494);
            this.splitContainerControl1.SplitterPosition = 226;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // IOListLog
            // 
            this.IOListLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IOListLog.Location = new System.Drawing.Point(0, 0);
            this.IOListLog.Name = "IOListLog";
            this.IOListLog.Size = new System.Drawing.Size(226, 494);
            this.IOListLog.TabIndex = 0;
            this.IOListLog.Text = "IOList Log";
            // 
            // BackupLog
            // 
            this.BackupLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupLog.Location = new System.Drawing.Point(0, 0);
            this.BackupLog.Name = "BackupLog";
            this.BackupLog.Size = new System.Drawing.Size(220, 494);
            this.BackupLog.TabIndex = 0;
            this.BackupLog.Text = "Backup Log";
            // 
            // ControlOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OptionSpliter);
            this.Name = "ControlOption";
            this.Size = new System.Drawing.Size(700, 494);
            ((System.ComponentModel.ISupportInitialize)(this.OptionSpliter)).EndInit();
            this.OptionSpliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MappingLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IOListLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl OptionSpliter;
        private DevExpress.XtraEditors.GroupControl MappingLog;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl IOListLog;
        private DevExpress.XtraEditors.GroupControl BackupLog;
    }
}
