namespace UDMTrackerSimple
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdNonDetect = new DevExpress.XtraGrid.GridControl();
            this.grvNonDetect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorStart = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorEnd = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCycleExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dptkFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptkTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNonDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNonDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
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
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(405, 78);
            this.btnExport.LookAndFeel.SkinName = "Office 2013";
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 60);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Error Export";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdNonDetect);
            this.groupBox1.Controls.Add(this.panelControl3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 255);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "이상 감지 기능 비가동 시간 설정";
            // 
            // grdNonDetect
            // 
            this.grdNonDetect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNonDetect.Location = new System.Drawing.Point(3, 18);
            this.grdNonDetect.MainView = this.grvNonDetect;
            this.grdNonDetect.Name = "grdNonDetect";
            this.grdNonDetect.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorStart,
            this.exEditorEnd});
            this.grdNonDetect.Size = new System.Drawing.Size(533, 191);
            this.grdNonDetect.TabIndex = 4;
            this.grdNonDetect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNonDetect});
            // 
            // grvNonDetect
            // 
            this.grvNonDetect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStart,
            this.colEndTime});
            this.grvNonDetect.GridControl = this.grdNonDetect;
            this.grvNonDetect.IndicatorWidth = 40;
            this.grvNonDetect.Name = "grvNonDetect";
            this.grvNonDetect.OptionsView.ShowGroupPanel = false;
            this.grvNonDetect.RowHeight = 25;
            this.grvNonDetect.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvNonDetect_CustomDrawRowIndicator);
            // 
            // colStart
            // 
            this.colStart.AppearanceCell.Options.UseTextOptions = true;
            this.colStart.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStart.AppearanceHeader.Options.UseFont = true;
            this.colStart.AppearanceHeader.Options.UseTextOptions = true;
            this.colStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStart.Caption = "Start Time";
            this.colStart.ColumnEdit = this.exEditorStart;
            this.colStart.FieldName = "StartTime";
            this.colStart.Name = "colStart";
            this.colStart.OptionsColumn.AllowMove = false;
            this.colStart.Visible = true;
            this.colStart.VisibleIndex = 0;
            // 
            // exEditorStart
            // 
            this.exEditorStart.AutoHeight = false;
            this.exEditorStart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorStart.DisplayFormat.FormatString = "HH:mm";
            this.exEditorStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorStart.EditFormat.FormatString = "HH:mm";
            this.exEditorStart.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorStart.Mask.EditMask = "HH:mm";
            this.exEditorStart.Name = "exEditorStart";
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.colEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEndTime.AppearanceHeader.Options.UseFont = true;
            this.colEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.Caption = "End Time";
            this.colEndTime.ColumnEdit = this.exEditorEnd;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.OptionsColumn.AllowMove = false;
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 1;
            // 
            // exEditorEnd
            // 
            this.exEditorEnd.AutoHeight = false;
            this.exEditorEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorEnd.DisplayFormat.FormatString = "HH:mm";
            this.exEditorEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorEnd.EditFormat.FormatString = "HH:mm";
            this.exEditorEnd.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorEnd.Mask.EditMask = "HH:mm";
            this.exEditorEnd.Name = "exEditorEnd";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnDelete);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(3, 209);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(533, 43);
            this.panelControl3.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(449, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 43);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(84, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 43);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "제거";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 43);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCycleExport
            // 
            this.btnCycleExport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCycleExport.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCycleExport.Appearance.Options.UseBackColor = true;
            this.btnCycleExport.Appearance.Options.UseFont = true;
            this.btnCycleExport.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCycleExport.Image = ((System.Drawing.Image)(resources.GetObject("btnCycleExport.Image")));
            this.btnCycleExport.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnCycleExport.Location = new System.Drawing.Point(405, 145);
            this.btnCycleExport.LookAndFeel.SkinName = "Office 2013";
            this.btnCycleExport.Name = "btnCycleExport";
            this.btnCycleExport.Size = new System.Drawing.Size(122, 60);
            this.btnCycleExport.TabIndex = 9;
            this.btnCycleExport.Text = "Cycle Export";
            this.btnCycleExport.Click += new System.EventHandler(this.btnCycleExport_Click);
            // 
            // FrmReportExporter
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 466);
            this.Controls.Add(this.btnCycleExport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dptkTo);
            this.Controls.Add(this.dptkFrom);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(555, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(555, 500);
            this.Name = "FrmReportExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReportExporter_FormClosing);
            this.Load += new System.EventHandler(this.FrmReportExporter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dptkFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptkTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLine.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNonDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNonDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl grdNonDetect;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNonDetect;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorStart;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorEnd;
        private DevExpress.XtraEditors.SimpleButton btnCycleExport;
    }
}