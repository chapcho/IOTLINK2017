namespace UDMTrackerSimple
{
    partial class FrmLogTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogTable));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpkTo = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtpkFrom = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grdLog = new DevExpress.XtraGrid.GridControl();
            this.grvLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(548, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range Filter";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(458, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(339, 18);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(83, 24);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtpkTo);
            this.panel6.Controls.Add(this.labelControl5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(181, 18);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(158, 24);
            this.panel6.TabIndex = 8;
            // 
            // dtpkTo
            // 
            this.dtpkTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpkTo.EditValue = new System.DateTime(2017, 5, 11, 0, 0, 0, 0);
            this.dtpkTo.Location = new System.Drawing.Point(32, 0);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkTo.Properties.Mask.EditMask = "yy.MM.dd HH:mm";
            this.dtpkTo.Size = new System.Drawing.Size(110, 20);
            this.dtpkTo.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl5.Location = new System.Drawing.Point(0, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 24);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = " To : ";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelControl3);
            this.panel5.Controls.Add(this.dtpkFrom);
            this.panel5.Controls.Add(this.labelControl2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(178, 24);
            this.panel5.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.Location = new System.Drawing.Point(153, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(22, 24);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "  ~";
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpkFrom.EditValue = new System.DateTime(2017, 5, 11, 0, 0, 0, 0);
            this.dtpkFrom.Location = new System.Drawing.Point(43, 0);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkFrom.Properties.Mask.EditMask = "yy.MM.dd HH:mm";
            this.dtpkFrom.Size = new System.Drawing.Size(110, 20);
            this.dtpkFrom.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 24);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = " From : ";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 548);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(548, 42);
            this.panelControl2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(462, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdLog
            // 
            this.grdLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLog.Location = new System.Drawing.Point(0, 49);
            this.grdLog.MainView = this.grvLog;
            this.grdLog.Name = "grdLog";
            this.grdLog.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorTime});
            this.grdLog.Size = new System.Drawing.Size(548, 499);
            this.grdLog.TabIndex = 2;
            this.grdLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLog});
            // 
            // grvLog
            // 
            this.grvLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colTime,
            this.colValue});
            this.grvLog.GridControl = this.grdLog;
            this.grvLog.IndicatorWidth = 50;
            this.grvLog.Name = "grvLog";
            this.grvLog.OptionsBehavior.Editable = false;
            this.grvLog.OptionsBehavior.ReadOnly = true;
            this.grvLog.OptionsView.ShowAutoFilterRow = true;
            this.grvLog.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvLog_CustomDrawRowIndicator);
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "Time";
            this.colTime.ColumnEdit = this.exEditorTime;
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 1;
            // 
            // exEditorTime
            // 
            this.exEditorTime.AutoHeight = false;
            this.exEditorTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTime.DisplayFormat.FormatString = "yy.MM.dd HH:mm:ss.fff";
            this.exEditorTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.EditFormat.FormatString = "yy.MM.dd HH:mm:ss.fff";
            this.exEditorTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.Mask.EditMask = "yy.MM.dd HH:mm:ss.fff";
            this.exEditorTime.Name = "exEditorTime";
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.FixedWidth = true;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 2;
            // 
            // FrmLogTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 590);
            this.Controls.Add(this.grdLog);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 38);
            this.Name = "FrmLogTable";
            this.Text = "Time Log Table";
            this.Load += new System.EventHandler(this.FrmLogTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkTo.Properties)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpkFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdLog;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLog;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTime;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeEdit dtpkFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.TimeEdit dtpkTo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}