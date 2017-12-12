namespace UDMTrackerSimple
{
    partial class UCAllErrorAlarmView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAllErrorAlarmView));
            this.ucErrorAlarmView = new UDMTrackerSimple.UCErrorAlarmView();
            this.pnlGrid = new DevExpress.XtraEditors.PanelControl();
            this.grdLine = new DevExpress.XtraGrid.GridControl();
            this.grvLine = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gbPLC = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colLine = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gbError = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colProcess = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.exEditorTime = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btnErrorClear = new DevExpress.XtraEditors.SimpleButton();
            this.grpStatistic = new DevExpress.XtraEditors.GroupControl();
            this.ucErrorChartS = new UDMTrackerSimple.UCErrorSummaryChartS();
            this.pnlChart = new DevExpress.XtraEditors.PanelControl();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.pnlMonitoring = new DevExpress.XtraEditors.PanelControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sptErrorInfo = new UDM.UI.MySplitContainerControl();
            this.grpErrorInfo = new DevExpress.XtraEditors.GroupControl();
            this.ucErrorPanelS = new UDMTrackerSimple.UCErrorSummaryPanelS();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatistic)).BeginInit();
            this.grpStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoring)).BeginInit();
            this.pnlMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptErrorInfo)).BeginInit();
            this.sptErrorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInfo)).BeginInit();
            this.grpErrorInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucErrorAlarmView
            // 
            this.ucErrorAlarmView.AutoScroll = true;
            this.ucErrorAlarmView.AutoSize = true;
            this.ucErrorAlarmView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorAlarmView.Location = new System.Drawing.Point(2, 28);
            this.ucErrorAlarmView.Name = "ucErrorAlarmView";
            this.ucErrorAlarmView.Size = new System.Drawing.Size(408, 412);
            this.ucErrorAlarmView.TabIndex = 4;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdLine);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGrid.Location = new System.Drawing.Point(2, 440);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(408, 250);
            this.pnlGrid.TabIndex = 5;
            // 
            // grdLine
            // 
            this.grdLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLine.Location = new System.Drawing.Point(2, 2);
            this.grdLine.MainView = this.grvLine;
            this.grdLine.Name = "grdLine";
            this.grdLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorTime});
            this.grdLine.Size = new System.Drawing.Size(404, 246);
            this.grdLine.TabIndex = 0;
            this.grdLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLine});
            // 
            // grvLine
            // 
            this.grvLine.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvLine.Appearance.Row.Options.UseFont = true;
            this.grvLine.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbPLC,
            this.gbError});
            this.grvLine.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colLine,
            this.colProcess,
            this.colTime,
            this.colCount});
            this.grvLine.GridControl = this.grdLine;
            this.grvLine.Name = "grvLine";
            this.grvLine.OptionsBehavior.Editable = false;
            this.grvLine.OptionsBehavior.ReadOnly = true;
            this.grvLine.OptionsDetail.AllowZoomDetail = false;
            this.grvLine.OptionsDetail.EnableMasterViewMode = false;
            this.grvLine.OptionsDetail.ShowDetailTabs = false;
            this.grvLine.OptionsDetail.SmartDetailExpand = false;
            this.grvLine.OptionsView.ShowGroupPanel = false;
            this.grvLine.OptionsView.ShowIndicator = false;
            this.grvLine.RowHeight = 30;
            // 
            // gbPLC
            // 
            this.gbPLC.AppearanceHeader.Options.UseTextOptions = true;
            this.gbPLC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbPLC.Caption = "PLC";
            this.gbPLC.Columns.Add(this.colLine);
            this.gbPLC.Columns.Add(this.colCount);
            this.gbPLC.Name = "gbPLC";
            this.gbPLC.VisibleIndex = 0;
            this.gbPLC.Width = 174;
            // 
            // colLine
            // 
            this.colLine.AppearanceCell.Options.UseTextOptions = true;
            this.colLine.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.AppearanceHeader.Options.UseTextOptions = true;
            this.colLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLine.Caption = "라인";
            this.colLine.FieldName = "PlcName";
            this.colLine.Name = "colLine";
            this.colLine.OptionsColumn.AllowEdit = false;
            this.colLine.OptionsColumn.AllowMove = false;
            this.colLine.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colLine.OptionsColumn.ReadOnly = true;
            this.colLine.Visible = true;
            this.colLine.Width = 114;
            // 
            // colCount
            // 
            this.colCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCount.Caption = "이상 개수";
            this.colCount.FieldName = "TotalCount";
            this.colCount.Name = "colCount";
            this.colCount.OptionsColumn.AllowEdit = false;
            this.colCount.OptionsColumn.AllowMove = false;
            this.colCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCount.OptionsColumn.FixedWidth = true;
            this.colCount.OptionsColumn.ReadOnly = true;
            this.colCount.Visible = true;
            this.colCount.Width = 60;
            // 
            // gbError
            // 
            this.gbError.AppearanceHeader.Options.UseTextOptions = true;
            this.gbError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbError.Caption = "최근 이상 발생";
            this.gbError.Columns.Add(this.colProcess);
            this.gbError.Columns.Add(this.colTime);
            this.gbError.Name = "gbError";
            this.gbError.VisibleIndex = 1;
            this.gbError.Width = 216;
            // 
            // colProcess
            // 
            this.colProcess.AppearanceCell.Options.UseTextOptions = true;
            this.colProcess.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcess.Caption = "공정";
            this.colProcess.FieldName = "ProcessName";
            this.colProcess.Name = "colProcess";
            this.colProcess.OptionsColumn.AllowEdit = false;
            this.colProcess.OptionsColumn.AllowMove = false;
            this.colProcess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colProcess.OptionsColumn.ReadOnly = true;
            this.colProcess.Visible = true;
            this.colProcess.Width = 109;
            // 
            // colTime
            // 
            this.colTime.AppearanceCell.Options.UseTextOptions = true;
            this.colTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTime.Caption = "시간";
            this.colTime.ColumnEdit = this.exEditorTime;
            this.colTime.FieldName = "LastTime";
            this.colTime.MinWidth = 100;
            this.colTime.Name = "colTime";
            this.colTime.OptionsColumn.AllowEdit = false;
            this.colTime.OptionsColumn.AllowMove = false;
            this.colTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTime.OptionsColumn.ReadOnly = true;
            this.colTime.Visible = true;
            this.colTime.Width = 107;
            // 
            // exEditorTime
            // 
            this.exEditorTime.AutoHeight = false;
            this.exEditorTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorTime.DisplayFormat.FormatString = "MM.dd HH:mm:ss";
            this.exEditorTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.EditFormat.FormatString = "MM.dd HH:mm:ss";
            this.exEditorTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.exEditorTime.Mask.EditMask = "MM.dd HH:mm:ss";
            this.exEditorTime.Mask.UseMaskAsDisplayFormat = true;
            this.exEditorTime.Name = "exEditorTime";
            // 
            // btnErrorClear
            // 
            this.btnErrorClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrorClear.Appearance.Options.UseFont = true;
            this.btnErrorClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnErrorClear.Image = ((System.Drawing.Image)(resources.GetObject("btnErrorClear.Image")));
            this.btnErrorClear.Location = new System.Drawing.Point(331, 2);
            this.btnErrorClear.Name = "btnErrorClear";
            this.btnErrorClear.Size = new System.Drawing.Size(75, 22);
            this.btnErrorClear.TabIndex = 0;
            this.btnErrorClear.Text = "Clear";
            this.btnErrorClear.Click += new System.EventHandler(this.btnErrorClear_Click);
            // 
            // grpStatistic
            // 
            this.grpStatistic.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatistic.AppearanceCaption.Options.UseFont = true;
            this.grpStatistic.Controls.Add(this.ucErrorChartS);
            this.grpStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatistic.Location = new System.Drawing.Point(0, 0);
            this.grpStatistic.MinimumSize = new System.Drawing.Size(0, 350);
            this.grpStatistic.Name = "grpStatistic";
            this.grpStatistic.Size = new System.Drawing.Size(846, 411);
            this.grpStatistic.TabIndex = 7;
            this.grpStatistic.Text = "라인 별 이상 통계";
            // 
            // ucErrorChartS
            // 
            this.ucErrorChartS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorChartS.Location = new System.Drawing.Point(2, 26);
            this.ucErrorChartS.Name = "ucErrorChartS";
            this.ucErrorChartS.Size = new System.Drawing.Size(842, 383);
            this.ucErrorChartS.TabIndex = 0;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.sptMain);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1272, 696);
            this.pnlChart.TabIndex = 8;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(2, 2);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.pnlMonitoring);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.sptErrorInfo);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(1268, 692);
            this.sptMain.SplitterPosition = 412;
            this.sptMain.TabIndex = 11;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // pnlMonitoring
            // 
            this.pnlMonitoring.Controls.Add(this.ucErrorAlarmView);
            this.pnlMonitoring.Controls.Add(this.pnlHeader);
            this.pnlMonitoring.Controls.Add(this.pnlGrid);
            this.pnlMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonitoring.Location = new System.Drawing.Point(0, 0);
            this.pnlMonitoring.MinimumSize = new System.Drawing.Size(400, 0);
            this.pnlMonitoring.Name = "pnlMonitoring";
            this.pnlMonitoring.Size = new System.Drawing.Size(412, 692);
            this.pnlMonitoring.TabIndex = 9;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.Controls.Add(this.labelControl1);
            this.pnlHeader.Controls.Add(this.btnErrorClear);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(408, 26);
            this.pnlHeader.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(143, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = " 라인 별 모니터링";
            // 
            // sptErrorInfo
            // 
            this.sptErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptErrorInfo.Horizontal = false;
            this.sptErrorInfo.Location = new System.Drawing.Point(0, 0);
            this.sptErrorInfo.Name = "sptErrorInfo";
            this.sptErrorInfo.Panel1.Controls.Add(this.grpStatistic);
            this.sptErrorInfo.Panel1.Text = "Panel1";
            this.sptErrorInfo.Panel2.Controls.Add(this.grpErrorInfo);
            this.sptErrorInfo.Panel2.Text = "Panel2";
            this.sptErrorInfo.Size = new System.Drawing.Size(846, 692);
            this.sptErrorInfo.SplitterPosition = 411;
            this.sptErrorInfo.TabIndex = 10;
            this.sptErrorInfo.Text = "splitContainerControl1";
            this.sptErrorInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptErrorInfo_MouseDoubleClick);
            // 
            // grpErrorInfo
            // 
            this.grpErrorInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpErrorInfo.AppearanceCaption.Options.UseFont = true;
            this.grpErrorInfo.Controls.Add(this.ucErrorPanelS);
            this.grpErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorInfo.Location = new System.Drawing.Point(0, 0);
            this.grpErrorInfo.Name = "grpErrorInfo";
            this.grpErrorInfo.Size = new System.Drawing.Size(846, 271);
            this.grpErrorInfo.TabIndex = 9;
            this.grpErrorInfo.Text = "실시간 라인 별 이상 정보";
            // 
            // ucErrorPanelS
            // 
            this.ucErrorPanelS.Appearance.BackColor = System.Drawing.Color.White;
            this.ucErrorPanelS.Appearance.Options.UseBackColor = true;
            this.ucErrorPanelS.AutoScroll = true;
            this.ucErrorPanelS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucErrorPanelS.Location = new System.Drawing.Point(2, 26);
            this.ucErrorPanelS.Name = "ucErrorPanelS";
            this.ucErrorPanelS.Size = new System.Drawing.Size(842, 243);
            this.ucErrorPanelS.TabIndex = 0;
            // 
            // UCAllErrorAlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChart);
            this.Name = "UCAllErrorAlarmView";
            this.Size = new System.Drawing.Size(1272, 696);
            this.Load += new System.EventHandler(this.UCAllErrorAlarmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatistic)).EndInit();
            this.grpStatistic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlChart)).EndInit();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitoring)).EndInit();
            this.pnlMonitoring.ResumeLayout(false);
            this.pnlMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptErrorInfo)).EndInit();
            this.sptErrorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpErrorInfo)).EndInit();
            this.grpErrorInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCErrorAlarmView ucErrorAlarmView;
        private DevExpress.XtraEditors.SimpleButton btnErrorClear;
        private DevExpress.XtraEditors.PanelControl pnlGrid;
        private DevExpress.XtraGrid.GridControl grdLine;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvLine;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbPLC;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLine;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCount;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbError;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProcess;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit exEditorTime;
        private DevExpress.XtraEditors.GroupControl grpStatistic;
        private DevExpress.XtraEditors.PanelControl pnlChart;
        private DevExpress.XtraEditors.GroupControl grpErrorInfo;
        private UCErrorSummaryPanelS ucErrorPanelS;
        private UCErrorSummaryChartS ucErrorChartS;
        private DevExpress.XtraEditors.PanelControl pnlMonitoring;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UDM.UI.MySplitContainerControl sptMain;
        private UDM.UI.MySplitContainerControl sptErrorInfo;
    }
}
