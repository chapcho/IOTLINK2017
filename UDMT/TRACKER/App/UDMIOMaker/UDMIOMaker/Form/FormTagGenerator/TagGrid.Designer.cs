namespace NewIOMaker.Form.FormTagGenerator
{
    partial class TagGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagGrid));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupPLC = new DevExpress.XtraEditors.GroupControl();
            this.exGridPLC = new DevExpress.XtraGrid.GridControl();
            this.exGridViewPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupHMI = new DevExpress.XtraEditors.GroupControl();
            this.exGridHMI = new DevExpress.XtraGrid.GridControl();
            this.exGridViewHMI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupHMI = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ButtonMapping = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.ButtonConvertor = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonInsertor = new DevExpress.XtraBars.BarButtonItem();
            this.bntEmptyAddressColor = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAlarm = new DevExpress.XtraBars.BarButtonItem();
            this.btnAlarmView = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmptyAddressColor = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.BackupAlert = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.popupPLC = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPLC)).BeginInit();
            this.groupPLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).BeginInit();
            this.exGridPLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupHMI)).BeginInit();
            this.groupHMI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupPLC);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupHMI);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(904, 605);
            this.splitContainerControl1.SplitterPosition = 510;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "Tagspliter";
            // 
            // groupPLC
            // 
            this.groupPLC.Controls.Add(this.exGridPLC);
            this.groupPLC.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Assign", ((System.Drawing.Image)(resources.GetObject("groupPLC.CustomHeaderButtons"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Comment", ((System.Drawing.Image)(resources.GetObject("groupPLC.CustomHeaderButtons1"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("DataType", ((System.Drawing.Image)(resources.GetObject("groupPLC.CustomHeaderButtons2"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Symbol", ((System.Drawing.Image)(resources.GetObject("groupPLC.CustomHeaderButtons3"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Address", ((System.Drawing.Image)(resources.GetObject("groupPLC.CustomHeaderButtons4"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1)});
            this.groupPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPLC.Location = new System.Drawing.Point(0, 0);
            this.groupPLC.Name = "groupPLC";
            this.groupPLC.Size = new System.Drawing.Size(510, 605);
            this.groupPLC.TabIndex = 1;
            // 
            // exGridPLC
            // 
            this.exGridPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridPLC.Location = new System.Drawing.Point(2, 21);
            this.exGridPLC.MainView = this.exGridViewPLC;
            this.exGridPLC.Name = "exGridPLC";
            this.exGridPLC.Size = new System.Drawing.Size(506, 582);
            this.exGridPLC.TabIndex = 0;
            this.exGridPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewPLC});
            // 
            // exGridViewPLC
            // 
            this.exGridViewPLC.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.exGridViewPLC.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.exGridViewPLC.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.exGridViewPLC.Appearance.FocusedCell.Options.UseBackColor = true;
            this.exGridViewPLC.Appearance.FocusedCell.Options.UseForeColor = true;
            this.exGridViewPLC.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.exGridViewPLC.Appearance.FocusedRow.Options.UseBackColor = true;
            this.exGridViewPLC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridViewPLC.GridControl = this.exGridPLC;
            this.exGridViewPLC.GroupPanelText = "[ PLC 그룹화 ] 원하는 항목을 드래그하세요";
            this.exGridViewPLC.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridViewPLC.IndicatorWidth = 60;
            this.exGridViewPLC.Name = "exGridViewPLC";
            this.exGridViewPLC.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exGridViewPLC.OptionsPrint.PrintHeader = false;
            this.exGridViewPLC.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridViewPLC.OptionsSelection.MultiSelect = true;
            this.exGridViewPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridViewPLC.OptionsView.ShowAutoFilterRow = true;
            this.exGridViewPLC.OptionsView.ShowFooter = true;
            // 
            // groupHMI
            // 
            this.groupHMI.Controls.Add(this.exGridHMI);
            this.groupHMI.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("이름", ((System.Drawing.Image)(resources.GetObject("groupHMI.CustomHeaderButtons"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("타입", ((System.Drawing.Image)(resources.GetObject("groupHMI.CustomHeaderButtons1"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("디바이스", ((System.Drawing.Image)(resources.GetObject("groupHMI.CustomHeaderButtons2"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("설명", ((System.Drawing.Image)(resources.GetObject("groupHMI.CustomHeaderButtons3"))), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1)});
            this.groupHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHMI.Location = new System.Drawing.Point(0, 0);
            this.groupHMI.Name = "groupHMI";
            this.groupHMI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupHMI.Size = new System.Drawing.Size(382, 605);
            this.groupHMI.TabIndex = 1;
            // 
            // exGridHMI
            // 
            this.exGridHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridHMI.Location = new System.Drawing.Point(2, 21);
            this.exGridHMI.MainView = this.exGridViewHMI;
            this.exGridHMI.Name = "exGridHMI";
            this.exGridHMI.Size = new System.Drawing.Size(378, 582);
            this.exGridHMI.TabIndex = 0;
            this.exGridHMI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewHMI});
            // 
            // exGridViewHMI
            // 
            this.exGridViewHMI.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridViewHMI.GridControl = this.exGridHMI;
            this.exGridViewHMI.GroupPanelText = "[ HMI 그룹화 ] 원하는 항목을 드래그하세요";
            this.exGridViewHMI.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridViewHMI.IndicatorWidth = 60;
            this.exGridViewHMI.Name = "exGridViewHMI";
            this.exGridViewHMI.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exGridViewHMI.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.exGridViewHMI.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.exGridViewHMI.OptionsPrint.PrintHeader = false;
            this.exGridViewHMI.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridViewHMI.OptionsSelection.MultiSelect = true;
            this.exGridViewHMI.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridViewHMI.OptionsView.AllowGlyphSkinning = true;
            this.exGridViewHMI.OptionsView.ShowAutoFilterRow = true;
            this.exGridViewHMI.OptionsView.ShowFooter = true;
            // 
            // popupHMI
            // 
            this.popupHMI.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonMapping),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.popupHMI.Manager = this.barManager1;
            this.popupHMI.Name = "popupHMI";
            // 
            // ButtonMapping
            // 
            this.ButtonMapping.Caption = "연결하기 ( F5 )";
            this.ButtonMapping.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonMapping.Glyph")));
            this.ButtonMapping.Id = 0;
            this.ButtonMapping.Name = "ButtonMapping";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "기타";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonConvertor),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonInsertor),
            new DevExpress.XtraBars.LinkPersistInfo(this.bntEmptyAddressColor)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // ButtonConvertor
            // 
            this.ButtonConvertor.Caption = "다른 타입 연결 ( F6 ) ";
            this.ButtonConvertor.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonConvertor.Glyph")));
            this.ButtonConvertor.Id = 2;
            this.ButtonConvertor.Name = "ButtonConvertor";
            // 
            // ButtonInsertor
            // 
            this.ButtonInsertor.Caption = "HMI 비트 넣기 ( F7 )";
            this.ButtonInsertor.Glyph = ((System.Drawing.Image)(resources.GetObject("ButtonInsertor.Glyph")));
            this.ButtonInsertor.Id = 3;
            this.ButtonInsertor.Name = "ButtonInsertor";
            // 
            // bntEmptyAddressColor
            // 
            this.bntEmptyAddressColor.Caption = "주소 없는 영역 표시 ( F10 )";
            this.bntEmptyAddressColor.Glyph = ((System.Drawing.Image)(resources.GetObject("bntEmptyAddressColor.Glyph")));
            this.bntEmptyAddressColor.Id = 8;
            this.bntEmptyAddressColor.Name = "bntEmptyAddressColor";
            this.bntEmptyAddressColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntEmptyAddressColor_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this.exGridPLC;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonMapping,
            this.barSubItem1,
            this.ButtonConvertor,
            this.ButtonInsertor,
            this.btnAlarm,
            this.btnAlarmView,
            this.btnEmptyAddressColor,
            this.bntEmptyAddressColor});
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(506, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 582);
            this.barDockControlBottom.Size = new System.Drawing.Size(506, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 582);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(506, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 582);
            // 
            // btnAlarm
            // 
            this.btnAlarm.Caption = "ADD Alarm ( F8 )";
            this.btnAlarm.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAlarm.Glyph")));
            this.btnAlarm.Id = 4;
            this.btnAlarm.Name = "btnAlarm";
            // 
            // btnAlarmView
            // 
            this.btnAlarmView.Caption = "View Alarm ( F9 )";
            this.btnAlarmView.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAlarmView.Glyph")));
            this.btnAlarmView.Id = 5;
            this.btnAlarmView.Name = "btnAlarmView";
            // 
            // btnEmptyAddressColor
            // 
            this.btnEmptyAddressColor.Edit = null;
            this.btnEmptyAddressColor.Id = 9;
            this.btnEmptyAddressColor.Name = "btnEmptyAddressColor";
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.CustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty};
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // popupPLC
            // 
            this.popupPLC.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAlarm),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAlarmView)});
            this.popupPLC.Manager = this.barManager1;
            this.popupPLC.Name = "popupPLC";
            // 
            // TagGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "TagGrid";
            this.Size = new System.Drawing.Size(904, 605);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPLC)).EndInit();
            this.groupPLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).EndInit();
            this.exGridPLC.ResumeLayout(false);
            this.exGridPLC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupHMI)).EndInit();
            this.groupHMI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl exGridPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewPLC;
        private DevExpress.XtraGrid.GridControl exGridHMI;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewHMI;
        private DevExpress.XtraBars.PopupMenu popupHMI;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ButtonMapping;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem ButtonConvertor;
        private DevExpress.XtraBars.BarButtonItem ButtonInsertor;
        private DevExpress.XtraBars.Alerter.AlertControl BackupAlert;
        private DevExpress.XtraBars.BarButtonItem btnAlarm;
        private DevExpress.XtraBars.BarButtonItem btnAlarmView;
        private DevExpress.XtraBars.PopupMenu popupPLC;
        private DevExpress.XtraEditors.GroupControl groupPLC;
        private DevExpress.XtraEditors.GroupControl groupHMI;
        private DevExpress.XtraBars.BarEditItem btnEmptyAddressColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraBars.BarButtonItem bntEmptyAddressColor;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
