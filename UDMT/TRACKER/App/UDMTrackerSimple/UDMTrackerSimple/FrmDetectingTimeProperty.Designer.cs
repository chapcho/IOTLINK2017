namespace UDMTrackerSimple
{
    partial class FrmDetectingTimeProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetectingTimeProperty));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNonDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNonDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(359, 87);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(316, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "라인 비가동 시간, 식사 시간, 휴식 시간대를 설정해주세요.";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(328, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "아래에 설정하신 시간대에는 이상 감지를 진행하지 않습니다.";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdNonDetect);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 87);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(359, 264);
            this.panelControl2.TabIndex = 1;
            // 
            // grdNonDetect
            // 
            this.grdNonDetect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNonDetect.Location = new System.Drawing.Point(2, 2);
            this.grdNonDetect.MainView = this.grvNonDetect;
            this.grdNonDetect.Name = "grdNonDetect";
            this.grdNonDetect.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorStart,
            this.exEditorEnd});
            this.grdNonDetect.Size = new System.Drawing.Size(355, 260);
            this.grdNonDetect.TabIndex = 0;
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
            this.panelControl3.Location = new System.Drawing.Point(0, 351);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(359, 44);
            this.panelControl3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(275, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 44);
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
            this.btnDelete.Size = new System.Drawing.Size(84, 44);
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
            this.btnAdd.Size = new System.Drawing.Size(84, 44);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(324, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "시간 표현은 24시 표현 방법으로 진행! ( 오후 4시 = 16:00 )";
            // 
            // FrmDetectingTimeProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 395);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetectingTimeProperty";
            this.Text = "이상 감지 기능 비가동 시간 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDetectingTimeProperty_FormClosing);
            this.Load += new System.EventHandler(this.FrmDetectingTimeProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNonDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNonDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdNonDetect;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNonDetect;
        private DevExpress.XtraGrid.Columns.GridColumn colStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorStart;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorEnd;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}