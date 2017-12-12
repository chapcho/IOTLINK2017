namespace UDMOptimizer
{
    partial class UCStatusView
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
            this.sptMian = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpSPDStatus = new DevExpress.XtraEditors.GroupControl();
            this.grdSpdStatus = new DevExpress.XtraGrid.GridControl();
            this.grvSpdStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSPDNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpdStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpProcessStatus = new DevExpress.XtraEditors.GroupControl();
            this.grdProcessStatus = new DevExpress.XtraGrid.GridControl();
            this.grvProcessStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProcessName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpRobotStatus = new DevExpress.XtraEditors.GroupControl();
            this.grdRobotStatus = new DevExpress.XtraGrid.GridControl();
            this.grvRobotStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRobotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRobotStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sptMian)).BeginInit();
            this.sptMian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSPDStatus)).BeginInit();
            this.grpSPDStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSpdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessStatus)).BeginInit();
            this.grpProcessStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcessStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRobotStatus)).BeginInit();
            this.grpRobotStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRobotStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobotStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // sptMian
            // 
            this.sptMian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMian.Horizontal = false;
            this.sptMian.Location = new System.Drawing.Point(0, 0);
            this.sptMian.Name = "sptMian";
            this.sptMian.Panel1.Controls.Add(this.grpSPDStatus);
            this.sptMian.Panel1.Text = "Panel1";
            this.sptMian.Panel2.Controls.Add(this.splitContainerControl1);
            this.sptMian.Panel2.Text = "Panel2";
            this.sptMian.Size = new System.Drawing.Size(465, 576);
            this.sptMian.SplitterPosition = 157;
            this.sptMian.TabIndex = 0;
            this.sptMian.Text = "splitContainerControl1";
            // 
            // grpSPDStatus
            // 
            this.grpSPDStatus.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpSPDStatus.AppearanceCaption.Options.UseFont = true;
            this.grpSPDStatus.Controls.Add(this.grdSpdStatus);
            this.grpSPDStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSPDStatus.Location = new System.Drawing.Point(0, 0);
            this.grpSPDStatus.Name = "grpSPDStatus";
            this.grpSPDStatus.Size = new System.Drawing.Size(465, 157);
            this.grpSPDStatus.TabIndex = 0;
            this.grpSPDStatus.Text = "SPD Status";
            // 
            // grdSpdStatus
            // 
            this.grdSpdStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSpdStatus.Location = new System.Drawing.Point(2, 27);
            this.grdSpdStatus.MainView = this.grvSpdStatus;
            this.grdSpdStatus.Name = "grdSpdStatus";
            this.grdSpdStatus.Size = new System.Drawing.Size(461, 128);
            this.grdSpdStatus.TabIndex = 1;
            this.grdSpdStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSpdStatus});
            // 
            // grvSpdStatus
            // 
            this.grvSpdStatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvSpdStatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSpdStatus.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvSpdStatus.Appearance.Row.Options.UseFont = true;
            this.grvSpdStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grvSpdStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSPDNumber,
            this.colSpdStatus});
            this.grvSpdStatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSpdStatus.GridControl = this.grdSpdStatus;
            this.grvSpdStatus.GroupRowHeight = 30;
            this.grvSpdStatus.IndicatorWidth = 30;
            this.grvSpdStatus.Name = "grvSpdStatus";
            this.grvSpdStatus.OptionsBehavior.Editable = false;
            this.grvSpdStatus.OptionsBehavior.ReadOnly = true;
            this.grvSpdStatus.OptionsCustomization.AllowColumnMoving = false;
            this.grvSpdStatus.OptionsCustomization.AllowColumnResizing = false;
            this.grvSpdStatus.OptionsCustomization.AllowFilter = false;
            this.grvSpdStatus.OptionsCustomization.AllowSort = false;
            this.grvSpdStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvSpdStatus.OptionsView.ShowGroupPanel = false;
            this.grvSpdStatus.RowHeight = 25;
            this.grvSpdStatus.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvSpdStatus_CustomDrawRowIndicator);
            this.grvSpdStatus.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvSpdStatus_CustomDrawCell);
            // 
            // colSPDNumber
            // 
            this.colSPDNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colSPDNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSPDNumber.Caption = "SPD Name";
            this.colSPDNumber.FieldName = "Name";
            this.colSPDNumber.Name = "colSPDNumber";
            this.colSPDNumber.Visible = true;
            this.colSPDNumber.VisibleIndex = 0;
            // 
            // colSpdStatus
            // 
            this.colSpdStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colSpdStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSpdStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colSpdStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSpdStatus.Caption = "Status";
            this.colSpdStatus.FieldName = "Status";
            this.colSpdStatus.Name = "colSpdStatus";
            this.colSpdStatus.Visible = true;
            this.colSpdStatus.VisibleIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grpProcessStatus);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grpRobotStatus);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(465, 414);
            this.splitContainerControl1.SplitterPosition = 160;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grpProcessStatus
            // 
            this.grpProcessStatus.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpProcessStatus.AppearanceCaption.Options.UseFont = true;
            this.grpProcessStatus.Controls.Add(this.grdProcessStatus);
            this.grpProcessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcessStatus.Location = new System.Drawing.Point(0, 0);
            this.grpProcessStatus.Name = "grpProcessStatus";
            this.grpProcessStatus.Size = new System.Drawing.Size(465, 160);
            this.grpProcessStatus.TabIndex = 1;
            this.grpProcessStatus.Text = "Process Status";
            // 
            // grdProcessStatus
            // 
            this.grdProcessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProcessStatus.Location = new System.Drawing.Point(2, 27);
            this.grdProcessStatus.MainView = this.grvProcessStatus;
            this.grdProcessStatus.Name = "grdProcessStatus";
            this.grdProcessStatus.Size = new System.Drawing.Size(461, 131);
            this.grdProcessStatus.TabIndex = 1;
            this.grdProcessStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProcessStatus});
            // 
            // grvProcessStatus
            // 
            this.grvProcessStatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvProcessStatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProcessStatus.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvProcessStatus.Appearance.Row.Options.UseFont = true;
            this.grvProcessStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grvProcessStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProcessName,
            this.colProcessStatus});
            this.grvProcessStatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProcessStatus.GridControl = this.grdProcessStatus;
            this.grvProcessStatus.GroupRowHeight = 30;
            this.grvProcessStatus.IndicatorWidth = 30;
            this.grvProcessStatus.Name = "grvProcessStatus";
            this.grvProcessStatus.OptionsBehavior.Editable = false;
            this.grvProcessStatus.OptionsBehavior.ReadOnly = true;
            this.grvProcessStatus.OptionsCustomization.AllowColumnMoving = false;
            this.grvProcessStatus.OptionsCustomization.AllowColumnResizing = false;
            this.grvProcessStatus.OptionsCustomization.AllowFilter = false;
            this.grvProcessStatus.OptionsCustomization.AllowSort = false;
            this.grvProcessStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProcessStatus.OptionsView.ShowGroupPanel = false;
            this.grvProcessStatus.RowHeight = 25;
            this.grvProcessStatus.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvProcessStatus_CustomDrawRowIndicator);
            this.grvProcessStatus.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvProcessStatus_CustomDrawCell);
            // 
            // colProcessName
            // 
            this.colProcessName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcessName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessName.Caption = "Process Name";
            this.colProcessName.FieldName = "Name";
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.Visible = true;
            this.colProcessName.VisibleIndex = 0;
            // 
            // colProcessStatus
            // 
            this.colProcessStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colProcessStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colProcessStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProcessStatus.Caption = "Status";
            this.colProcessStatus.FieldName = "Status";
            this.colProcessStatus.Name = "colProcessStatus";
            this.colProcessStatus.Visible = true;
            this.colProcessStatus.VisibleIndex = 1;
            // 
            // grpRobotStatus
            // 
            this.grpRobotStatus.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpRobotStatus.AppearanceCaption.Options.UseFont = true;
            this.grpRobotStatus.Controls.Add(this.grdRobotStatus);
            this.grpRobotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRobotStatus.Location = new System.Drawing.Point(0, 0);
            this.grpRobotStatus.Name = "grpRobotStatus";
            this.grpRobotStatus.Size = new System.Drawing.Size(465, 249);
            this.grpRobotStatus.TabIndex = 2;
            this.grpRobotStatus.Text = "Robot Cycle Status";
            // 
            // grdRobotStatus
            // 
            this.grdRobotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRobotStatus.Location = new System.Drawing.Point(2, 27);
            this.grdRobotStatus.MainView = this.grvRobotStatus;
            this.grdRobotStatus.Name = "grdRobotStatus";
            this.grdRobotStatus.Size = new System.Drawing.Size(461, 220);
            this.grdRobotStatus.TabIndex = 1;
            this.grdRobotStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRobotStatus});
            // 
            // grvRobotStatus
            // 
            this.grvRobotStatus.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvRobotStatus.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRobotStatus.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.grvRobotStatus.Appearance.Row.Options.UseFont = true;
            this.grvRobotStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grvRobotStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRobotName,
            this.colRobotStatus});
            this.grvRobotStatus.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRobotStatus.GridControl = this.grdRobotStatus;
            this.grvRobotStatus.GroupRowHeight = 30;
            this.grvRobotStatus.IndicatorWidth = 30;
            this.grvRobotStatus.Name = "grvRobotStatus";
            this.grvRobotStatus.OptionsBehavior.Editable = false;
            this.grvRobotStatus.OptionsBehavior.ReadOnly = true;
            this.grvRobotStatus.OptionsCustomization.AllowColumnMoving = false;
            this.grvRobotStatus.OptionsCustomization.AllowColumnResizing = false;
            this.grvRobotStatus.OptionsCustomization.AllowFilter = false;
            this.grvRobotStatus.OptionsCustomization.AllowSort = false;
            this.grvRobotStatus.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvRobotStatus.OptionsView.ShowGroupPanel = false;
            this.grvRobotStatus.RowHeight = 25;
            this.grvRobotStatus.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRobotStatus_CustomDrawRowIndicator);
            this.grvRobotStatus.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvRobotStatus_CustomDrawCell);
            // 
            // colRobotName
            // 
            this.colRobotName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRobotName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRobotName.Caption = "Robot Name";
            this.colRobotName.FieldName = "Name";
            this.colRobotName.Name = "colRobotName";
            this.colRobotName.Visible = true;
            this.colRobotName.VisibleIndex = 0;
            // 
            // colRobotStatus
            // 
            this.colRobotStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colRobotStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRobotStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colRobotStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRobotStatus.Caption = "Status";
            this.colRobotStatus.FieldName = "Status";
            this.colRobotStatus.Name = "colRobotStatus";
            this.colRobotStatus.Visible = true;
            this.colRobotStatus.VisibleIndex = 1;
            // 
            // UCStatusView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sptMian);
            this.Name = "UCStatusView";
            this.Size = new System.Drawing.Size(465, 576);
            ((System.ComponentModel.ISupportInitialize)(this.sptMian)).EndInit();
            this.sptMian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSPDStatus)).EndInit();
            this.grpSPDStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSpdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSpdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpProcessStatus)).EndInit();
            this.grpProcessStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProcessStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRobotStatus)).EndInit();
            this.grpRobotStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRobotStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRobotStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sptMian;
        private DevExpress.XtraEditors.GroupControl grpSPDStatus;
        private DevExpress.XtraGrid.GridControl grdSpdStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSpdStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSPDNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSpdStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl grpProcessStatus;
        private DevExpress.XtraGrid.GridControl grdProcessStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProcessStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessName;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessStatus;
        private DevExpress.XtraEditors.GroupControl grpRobotStatus;
        private DevExpress.XtraGrid.GridControl grdRobotStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRobotStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colRobotName;
        private DevExpress.XtraGrid.Columns.GridColumn colRobotStatus;

    }
}
