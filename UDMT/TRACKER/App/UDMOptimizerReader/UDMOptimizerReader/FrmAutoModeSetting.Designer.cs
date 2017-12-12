namespace UDMOptimizerReader
{
    partial class FrmAutoModeSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoModeSetting));
            this.tStart = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tStop = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDBPath = new DevExpress.XtraEditors.TextEdit();
            this.btnPathChange = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoMode = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.tStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tStart
            // 
            this.tStart.EditValue = new System.DateTime(2017, 2, 20, 0, 0, 0, 0);
            this.tStart.Location = new System.Drawing.Point(221, 26);
            this.tStart.Name = "tStart";
            this.tStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStart.Properties.Appearance.Options.UseFont = true;
            this.tStart.Properties.Appearance.Options.UseTextOptions = true;
            this.tStart.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tStart.Properties.DisplayFormat.FormatString = "HH : mm";
            this.tStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tStart.Size = new System.Drawing.Size(197, 26);
            this.tStart.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(92, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(123, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Restart Time : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(116, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 19);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Stop Time : ";
            // 
            // tStop
            // 
            this.tStop.EditValue = new System.DateTime(2017, 2, 20, 0, 0, 0, 0);
            this.tStop.Location = new System.Drawing.Point(221, 70);
            this.tStop.Name = "tStop";
            this.tStop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStop.Properties.Appearance.Options.UseFont = true;
            this.tStop.Properties.Appearance.Options.UseTextOptions = true;
            this.tStop.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tStop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tStop.Properties.DisplayFormat.FormatString = "HH : mm";
            this.tStop.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tStop.Properties.EditFormat.FormatString = "HH : mm";
            this.tStop.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tStop.Size = new System.Drawing.Size(197, 26);
            this.tStop.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(69, 117);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(146, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "DB Backup Path : ";
            // 
            // txtDBPath
            // 
            this.txtDBPath.EditValue = "";
            this.txtDBPath.Location = new System.Drawing.Point(221, 114);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtDBPath.Properties.Appearance.Options.UseFont = true;
            this.txtDBPath.Size = new System.Drawing.Size(672, 26);
            this.txtDBPath.TabIndex = 6;
            // 
            // btnPathChange
            // 
            this.btnPathChange.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPathChange.Appearance.Options.UseFont = true;
            this.btnPathChange.Location = new System.Drawing.Point(221, 146);
            this.btnPathChange.Name = "btnPathChange";
            this.btnPathChange.Size = new System.Drawing.Size(137, 28);
            this.btnPathChange.TabIndex = 7;
            this.btnPathChange.Text = "Change Path";
            this.btnPathChange.Click += new System.EventHandler(this.btnPathChange_Click);
            // 
            // chkAutoMode
            // 
            this.chkAutoMode.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.chkAutoMode.Image = ((System.Drawing.Image)(resources.GetObject("chkAutoMode.Image")));
            this.chkAutoMode.Location = new System.Drawing.Point(741, 25);
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.Size = new System.Drawing.Size(152, 67);
            this.chkAutoMode.TabIndex = 8;
            this.chkAutoMode.Text = "Auto Mode";
            // 
            // FrmAutoModeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 187);
            this.Controls.Add(this.chkAutoMode);
            this.Controls.Add(this.btnPathChange);
            this.Controls.Add(this.txtDBPath);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.tStop);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutoModeSetting";
            this.ShowIcon = false;
            this.Text = "Auto Mode Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAutoModeSetting_FormClosing);
            this.Load += new System.EventHandler(this.FrmAutoModeSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit tStart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TimeEdit tStop;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDBPath;
        private DevExpress.XtraEditors.SimpleButton btnPathChange;
        private DevExpress.XtraEditors.CheckButton chkAutoMode;
    }
}