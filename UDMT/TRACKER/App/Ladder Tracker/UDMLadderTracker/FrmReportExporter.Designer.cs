namespace UDMLadderTracker
{
    partial class FrmReportExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportExporter));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dptkFrom = new DevExpress.XtraEditors.TimeEdit();
            this.dptkTo = new DevExpress.XtraEditors.TimeEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLine = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dptkFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptkTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl1.Location = new System.Drawing.Point(126, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(269, 47);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "생산 이력 리포트";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl2.Location = new System.Drawing.Point(12, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(149, 32);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "리포트 시작 : ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl3.Location = new System.Drawing.Point(12, 171);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(149, 32);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "리포트 종료 : ";
            // 
            // dptkFrom
            // 
            this.dptkFrom.EditValue = new System.DateTime(2016, 3, 17, 0, 0, 0, 0);
            this.dptkFrom.Location = new System.Drawing.Point(167, 125);
            this.dptkFrom.Name = "dptkFrom";
            this.dptkFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptkFrom.Properties.Appearance.Options.UseFont = true;
            this.dptkFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptkFrom.Properties.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.dptkFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptkFrom.Properties.EditFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.dptkFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptkFrom.Properties.Mask.EditMask = "yyyy.MM.dd HH:mm";
            this.dptkFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dptkFrom.Size = new System.Drawing.Size(214, 32);
            this.dptkFrom.TabIndex = 3;
            // 
            // dptkTo
            // 
            this.dptkTo.EditValue = new System.DateTime(2016, 3, 17, 0, 0, 0, 0);
            this.dptkTo.Location = new System.Drawing.Point(167, 173);
            this.dptkTo.Name = "dptkTo";
            this.dptkTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptkTo.Properties.Appearance.Options.UseFont = true;
            this.dptkTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptkTo.Properties.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.dptkTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptkTo.Properties.EditFormat.FormatString = "yyyy.MM.dd HH:mm";
            this.dptkTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptkTo.Properties.Mask.EditMask = "yyyy.MM.dd HH:mm";
            this.dptkTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dptkTo.Size = new System.Drawing.Size(214, 32);
            this.dptkTo.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(400, 78);
            this.btnExport.LookAndFeel.SkinName = "Office 2013";
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 127);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelControl4.Location = new System.Drawing.Point(92, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 32);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "LINE : ";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(167, 80);
            this.txtLine.Name = "txtLine";
            this.txtLine.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine.Properties.Appearance.Options.UseFont = true;
            this.txtLine.Size = new System.Drawing.Size(214, 32);
            this.txtLine.TabIndex = 7;
            // 
            // FrmReportExporter
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 215);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dptkTo);
            this.Controls.Add(this.dptkFrom);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmReportExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Report";
            this.Load += new System.EventHandler(this.FrmReportExporter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dptkFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptkTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeEdit dptkFrom;
        private DevExpress.XtraEditors.TimeEdit dptkTo;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLine;
    }
}