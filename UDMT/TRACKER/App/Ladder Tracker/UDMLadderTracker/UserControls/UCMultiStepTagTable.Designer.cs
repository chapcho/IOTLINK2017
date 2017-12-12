namespace UDMLadderTracker
{
    partial class UCMultiStepTagTable
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
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tpgStepList = new DevExpress.XtraTab.XtraTabPage();
            this.grdStepList = new DevExpress.XtraGrid.GridControl();
            this.grvStepList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStepAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSteplProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgTagList = new DevExpress.XtraTab.XtraTabPage();
            this.grdTagList = new DevExpress.XtraGrid.GridControl();
            this.grvTagList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTagAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaglDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagLogCount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpgStepList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStepList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStepList)).BeginInit();
            this.tpgTagList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTagList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.tpgStepList;
            this.tabMain.Size = new System.Drawing.Size(528, 637);
            this.tabMain.TabIndex = 1;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpgStepList,
            this.tpgTagList});
            // 
            // tpgStepList
            // 
            this.tpgStepList.Controls.Add(this.grdStepList);
            this.tpgStepList.Name = "tpgStepList";
            this.tpgStepList.Padding = new System.Windows.Forms.Padding(2);
            this.tpgStepList.Size = new System.Drawing.Size(522, 608);
            this.tpgStepList.Text = "Step 리스트";
            // 
            // grdStepList
            // 
            this.grdStepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStepList.Location = new System.Drawing.Point(2, 2);
            this.grdStepList.MainView = this.grvStepList;
            this.grdStepList.Name = "grdStepList";
            this.grdStepList.Size = new System.Drawing.Size(518, 604);
            this.grdStepList.TabIndex = 2;
            this.grdStepList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStepList});
            // 
            // grvStepList
            // 
            this.grvStepList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvStepList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStepList.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvStepList.Appearance.Row.Options.UseFont = true;
            this.grvStepList.ColumnPanelRowHeight = 45;
            this.grvStepList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStepAddress,
            this.colStepDescription,
            this.colStepDataType,
            this.colStepLogCount,
            this.colStepCommand,
            this.colSteplProgram,
            this.colStepIndex});
            this.grvStepList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvStepList.GridControl = this.grdStepList;
            this.grvStepList.GroupRowHeight = 40;
            this.grvStepList.IndicatorWidth = 45;
            this.grvStepList.Name = "grvStepList";
            this.grvStepList.OptionsBehavior.Editable = false;
            this.grvStepList.OptionsBehavior.ReadOnly = true;
            this.grvStepList.OptionsDetail.AllowZoomDetail = false;
            this.grvStepList.OptionsDetail.EnableMasterViewMode = false;
            this.grvStepList.OptionsDetail.ShowDetailTabs = false;
            this.grvStepList.OptionsDetail.SmartDetailExpand = false;
            this.grvStepList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvStepList.OptionsView.ColumnAutoWidth = false;
            this.grvStepList.OptionsView.EnableAppearanceEvenRow = true;
            this.grvStepList.OptionsView.ShowAutoFilterRow = true;
            this.grvStepList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvStepList.RowHeight = 25;
            this.grvStepList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStepList_CustomDrawRowIndicator);
            this.grvStepList.ShownEditor += new System.EventHandler(this.grvStepList_ShownEditor);
            this.grvStepList.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.grvStepList_CustomColumnSort);
            this.grvStepList.DoubleClick += new System.EventHandler(this.grvStepList_DoubleClick);
            // 
            // colStepAddress
            // 
            this.colStepAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colStepAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStepAddress.Caption = "주소";
            this.colStepAddress.FieldName = "Address";
            this.colStepAddress.MaxWidth = 70;
            this.colStepAddress.MinWidth = 70;
            this.colStepAddress.Name = "colStepAddress";
            this.colStepAddress.OptionsColumn.FixedWidth = true;
            this.colStepAddress.Visible = true;
            this.colStepAddress.VisibleIndex = 0;
            this.colStepAddress.Width = 70;
            // 
            // colStepDescription
            // 
            this.colStepDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepDescription.Caption = "코멘트";
            this.colStepDescription.FieldName = "Description";
            this.colStepDescription.MinWidth = 100;
            this.colStepDescription.Name = "colStepDescription";
            this.colStepDescription.Visible = true;
            this.colStepDescription.VisibleIndex = 1;
            this.colStepDescription.Width = 100;
            // 
            // colStepDataType
            // 
            this.colStepDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colStepDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStepDataType.Caption = "데이터타입";
            this.colStepDataType.FieldName = "DataType";
            this.colStepDataType.Name = "colStepDataType";
            this.colStepDataType.OptionsColumn.FixedWidth = true;
            this.colStepDataType.Visible = true;
            this.colStepDataType.VisibleIndex = 2;
            this.colStepDataType.Width = 50;
            // 
            // colStepLogCount
            // 
            this.colStepLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepLogCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colStepLogCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStepLogCount.Caption = "로그수";
            this.colStepLogCount.FieldName = "LogCount";
            this.colStepLogCount.MaxWidth = 50;
            this.colStepLogCount.MinWidth = 50;
            this.colStepLogCount.Name = "colStepLogCount";
            this.colStepLogCount.OptionsColumn.FixedWidth = true;
            this.colStepLogCount.Visible = true;
            this.colStepLogCount.VisibleIndex = 3;
            this.colStepLogCount.Width = 50;
            // 
            // colStepCommand
            // 
            this.colStepCommand.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepCommand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepCommand.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colStepCommand.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStepCommand.Caption = "명령어";
            this.colStepCommand.FieldName = "Instruction";
            this.colStepCommand.MinWidth = 100;
            this.colStepCommand.Name = "colStepCommand";
            this.colStepCommand.Visible = true;
            this.colStepCommand.VisibleIndex = 4;
            this.colStepCommand.Width = 106;
            // 
            // colSteplProgram
            // 
            this.colSteplProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colSteplProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSteplProgram.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colSteplProgram.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSteplProgram.Caption = "파일명";
            this.colSteplProgram.FieldName = "Program";
            this.colSteplProgram.MaxWidth = 70;
            this.colSteplProgram.MinWidth = 50;
            this.colSteplProgram.Name = "colSteplProgram";
            this.colSteplProgram.Visible = true;
            this.colSteplProgram.VisibleIndex = 5;
            this.colSteplProgram.Width = 57;
            // 
            // colStepIndex
            // 
            this.colStepIndex.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepIndex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepIndex.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colStepIndex.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStepIndex.Caption = "스텝번호";
            this.colStepIndex.FieldName = "StepIndex";
            this.colStepIndex.MaxWidth = 40;
            this.colStepIndex.MinWidth = 40;
            this.colStepIndex.Name = "colStepIndex";
            this.colStepIndex.OptionsColumn.FixedWidth = true;
            this.colStepIndex.Visible = true;
            this.colStepIndex.VisibleIndex = 6;
            this.colStepIndex.Width = 40;
            // 
            // tpgTagList
            // 
            this.tpgTagList.Controls.Add(this.grdTagList);
            this.tpgTagList.Name = "tpgTagList";
            this.tpgTagList.Padding = new System.Windows.Forms.Padding(2);
            this.tpgTagList.Size = new System.Drawing.Size(522, 608);
            this.tpgTagList.Text = "접점 리스트";
            // 
            // grdTagList
            // 
            this.grdTagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTagList.Location = new System.Drawing.Point(2, 2);
            this.grdTagList.MainView = this.grvTagList;
            this.grdTagList.Name = "grdTagList";
            this.grdTagList.Size = new System.Drawing.Size(518, 604);
            this.grdTagList.TabIndex = 2;
            this.grdTagList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTagList});
            // 
            // grvTagList
            // 
            this.grvTagList.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvTagList.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTagList.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvTagList.Appearance.Row.Options.UseFont = true;
            this.grvTagList.ColumnPanelRowHeight = 45;
            this.grvTagList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTagAddress,
            this.colTagDescription,
            this.colTaglDataType,
            this.colTagLogCount});
            this.grvTagList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTagList.GridControl = this.grdTagList;
            this.grvTagList.IndicatorWidth = 45;
            this.grvTagList.Name = "grvTagList";
            this.grvTagList.OptionsBehavior.Editable = false;
            this.grvTagList.OptionsBehavior.ReadOnly = true;
            this.grvTagList.OptionsDetail.AllowZoomDetail = false;
            this.grvTagList.OptionsDetail.EnableMasterViewMode = false;
            this.grvTagList.OptionsDetail.ShowDetailTabs = false;
            this.grvTagList.OptionsDetail.SmartDetailExpand = false;
            this.grvTagList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvTagList.OptionsView.ColumnAutoWidth = false;
            this.grvTagList.OptionsView.EnableAppearanceEvenRow = true;
            this.grvTagList.OptionsView.ShowAutoFilterRow = true;
            this.grvTagList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTagList.RowHeight = 25;
            this.grvTagList.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvTagList_CustomDrawRowIndicator);
            this.grvTagList.ShownEditor += new System.EventHandler(this.grvTagList_ShownEditor);
            this.grvTagList.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.grvTagList_CustomColumnSort);
            this.grvTagList.DoubleClick += new System.EventHandler(this.grvTagList_DoubleClick);
            // 
            // colTagAddress
            // 
            this.colTagAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagAddress.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colTagAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTagAddress.Caption = "주소";
            this.colTagAddress.FieldName = "Address";
            this.colTagAddress.MaxWidth = 70;
            this.colTagAddress.MinWidth = 70;
            this.colTagAddress.Name = "colTagAddress";
            this.colTagAddress.OptionsColumn.FixedWidth = true;
            this.colTagAddress.Visible = true;
            this.colTagAddress.VisibleIndex = 0;
            this.colTagAddress.Width = 70;
            // 
            // colTagDescription
            // 
            this.colTagDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagDescription.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colTagDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTagDescription.Caption = "코멘트";
            this.colTagDescription.FieldName = "Description";
            this.colTagDescription.MinWidth = 100;
            this.colTagDescription.Name = "colTagDescription";
            this.colTagDescription.Visible = true;
            this.colTagDescription.VisibleIndex = 1;
            this.colTagDescription.Width = 153;
            // 
            // colTaglDataType
            // 
            this.colTaglDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colTaglDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTaglDataType.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colTaglDataType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTaglDataType.Caption = "데이터타입";
            this.colTaglDataType.FieldName = "DataType";
            this.colTaglDataType.MaxWidth = 50;
            this.colTaglDataType.MinWidth = 50;
            this.colTaglDataType.Name = "colTaglDataType";
            this.colTaglDataType.OptionsColumn.FixedWidth = true;
            this.colTaglDataType.Visible = true;
            this.colTaglDataType.VisibleIndex = 2;
            this.colTaglDataType.Width = 50;
            // 
            // colTagLogCount
            // 
            this.colTagLogCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagLogCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagLogCount.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colTagLogCount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTagLogCount.Caption = "로그수";
            this.colTagLogCount.FieldName = "LogCount";
            this.colTagLogCount.MaxWidth = 50;
            this.colTagLogCount.MinWidth = 50;
            this.colTagLogCount.Name = "colTagLogCount";
            this.colTagLogCount.OptionsColumn.FixedWidth = true;
            this.colTagLogCount.Visible = true;
            this.colTagLogCount.VisibleIndex = 3;
            this.colTagLogCount.Width = 50;
            // 
            // UCMultiStepTagTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "UCMultiStepTagTable";
            this.Size = new System.Drawing.Size(528, 637);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpgStepList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdStepList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStepList)).EndInit();
            this.tpgTagList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTagList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage tpgStepList;
        private DevExpress.XtraGrid.GridControl grdStepList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStepList;
        private DevExpress.XtraGrid.Columns.GridColumn colStepAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colStepDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStepDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colStepLogCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStepCommand;
        private DevExpress.XtraGrid.Columns.GridColumn colSteplProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colStepIndex;
        private DevExpress.XtraTab.XtraTabPage tpgTagList;
        private DevExpress.XtraGrid.GridControl grdTagList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTagList;
        private DevExpress.XtraGrid.Columns.GridColumn colTagAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colTagDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colTaglDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colTagLogCount;
    }
}
