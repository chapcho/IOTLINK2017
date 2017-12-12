namespace NewIOMaker
{
    partial class IOPLCVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IOPLCVerification));
            this.exGridPLC = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSymbol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMomory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupPLC = new DevExpress.XtraEditors.GroupControl();
            this.groupViewer = new DevExpress.XtraEditors.GroupControl();
            this.ViewTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::NewIOMaker.Form.FormIOMaker.WaitForm1), true, true, typeof(System.Windows.Forms.UserControl));
            this.alert = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitControl)).BeginInit();
            this.splitControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupPLC)).BeginInit();
            this.groupPLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupViewer)).BeginInit();
            this.groupViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridPLC
            // 
            this.exGridPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridPLC.Location = new System.Drawing.Point(2, 21);
            this.exGridPLC.MainView = this.exGridView;
            this.exGridPLC.Name = "exGridPLC";
            this.exGridPLC.Size = new System.Drawing.Size(426, 331);
            this.exGridPLC.TabIndex = 2;
            this.exGridPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colSymbol,
            this.colMomory,
            this.colContact,
            this.colLogic});
            this.exGridView.GridControl = this.exGridPLC;
            this.exGridView.GroupPanelText = "1.원하는 항목을 드래그하세요 2. 마우스 우클릭으로 메뉴 설명을 확인하세요 3. 더블클릭하여 래더를 확인하세요";
            this.exGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsBehavior.ReadOnly = true;
            this.exGridView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.exGridView.OptionsSelection.MultiSelect = true;
            this.exGridView.OptionsView.ShowAutoFilterRow = true;
            this.exGridView.OptionsView.ShowChildrenInGroupPanel = true;
            this.exGridView.OptionsView.ShowFooter = true;
            this.exGridView.OptionsView.ShowGroupedColumns = true;
            // 
            // colAddress
            // 
            this.colAddress.Caption = " 주소";
            this.colAddress.FieldName = "address";
            this.colAddress.Image = ((System.Drawing.Image)(resources.GetObject("colAddress.Image")));
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 82;
            // 
            // colSymbol
            // 
            this.colSymbol.Caption = " 심볼 ( 태그 , 코멘트 )";
            this.colSymbol.FieldName = "symbol";
            this.colSymbol.Image = ((System.Drawing.Image)(resources.GetObject("colSymbol.Image")));
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.Visible = true;
            this.colSymbol.VisibleIndex = 1;
            this.colSymbol.Width = 98;
            // 
            // colMomory
            // 
            this.colMomory.Caption = "심볼 사용";
            this.colMomory.FieldName = "memory";
            this.colMomory.Image = ((System.Drawing.Image)(resources.GetObject("colMomory.Image")));
            this.colMomory.Name = "colMomory";
            this.colMomory.Visible = true;
            this.colMomory.VisibleIndex = 2;
            this.colMomory.Width = 98;
            // 
            // colContact
            // 
            this.colContact.Caption = " 접점";
            this.colContact.FieldName = "contact";
            this.colContact.Image = ((System.Drawing.Image)(resources.GetObject("colContact.Image")));
            this.colContact.Name = "colContact";
            this.colContact.Visible = true;
            this.colContact.VisibleIndex = 3;
            this.colContact.Width = 63;
            // 
            // colLogic
            // 
            this.colLogic.Caption = " 로직";
            this.colLogic.FieldName = "logic";
            this.colLogic.Image = ((System.Drawing.Image)(resources.GetObject("colLogic.Image")));
            this.colLogic.Name = "colLogic";
            this.colLogic.Visible = true;
            this.colLogic.VisibleIndex = 4;
            this.colLogic.Width = 69;
            // 
            // splitControl
            // 
            this.splitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitControl.Location = new System.Drawing.Point(0, 0);
            this.splitControl.Name = "splitControl";
            this.splitControl.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitControl.Panel1.Text = "Panel1";
            this.splitControl.Panel2.Text = "Panel2";
            this.splitControl.Size = new System.Drawing.Size(913, 610);
            this.splitControl.SplitterPosition = 430;
            this.splitControl.TabIndex = 3;
            this.splitControl.Text = "splitContainerControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupPLC);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupViewer);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(430, 610);
            this.splitContainerControl1.SplitterPosition = 354;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupPLC
            // 
            this.groupPLC.Controls.Add(this.exGridPLC);
            this.groupPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPLC.Location = new System.Drawing.Point(0, 0);
            this.groupPLC.Name = "groupPLC";
            this.groupPLC.Size = new System.Drawing.Size(430, 354);
            this.groupPLC.TabIndex = 3;
            // 
            // groupViewer
            // 
            this.groupViewer.Controls.Add(this.ViewTabControl);
            this.groupViewer.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Ladder Viewer", null)});
            this.groupViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupViewer.Location = new System.Drawing.Point(0, 0);
            this.groupViewer.Name = "groupViewer";
            this.groupViewer.Size = new System.Drawing.Size(430, 244);
            this.groupViewer.TabIndex = 4;
            // 
            // ViewTabControl
            // 
            this.ViewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewTabControl.Location = new System.Drawing.Point(2, 21);
            this.ViewTabControl.Name = "ViewTabControl";
            this.ViewTabControl.Size = new System.Drawing.Size(426, 221);
            this.ViewTabControl.TabIndex = 0;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem5)});
            this.popupMenu.Manager = this.barManager1;
            this.popupMenu.Name = "popupMenu";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "주소 : PLC 프로그램에 사용된 물리적 주소";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "심볼 : PLC 주소를 가르키는 영역 [Siemans-Symbol] [AB-Tag] [Mitshibishi-Comment]";
            this.barStaticItem2.Id = 2;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "심볼 사용 : Symbol의 사용 여부를 체크 [심볼-심볼 테이블에만 선언] [로직-심볼 테이블에는 없고 로직에만 사용] [심볼/로직-두 경우 모" +
    "두 사용] ";
            this.barStaticItem4.Id = 4;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Caption = "접점 : PLC 프로그램에서 사용된 물리적 주소의 접점 정보를 체크 [ 조건-입력 조건으로만 사용] [코일-출력 조건으로만 사용] [조건/코일-두" +
    " 경우 모두 사용] [NONE-미사용]";
            this.barStaticItem5.Id = 5;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barListItem1,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barStaticItem4,
            this.barStaticItem5});
            this.barManager1.MaxItemId = 6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(913, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 610);
            this.barDockControlBottom.Size = new System.Drawing.Size(913, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 610);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(913, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 610);
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "barListItem1";
            this.barListItem1.Id = 0;
            this.barListItem1.Name = "barListItem1";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "barStaticItem3";
            this.barStaticItem3.Id = 3;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // IOPLCVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "IOPLCVerification";
            this.Size = new System.Drawing.Size(913, 610);
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitControl)).EndInit();
            this.splitControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupPLC)).EndInit();
            this.groupPLC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupViewer)).EndInit();
            this.groupViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewTabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridPLC;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraEditors.SplitContainerControl splitControl;
        private DevExpress.XtraEditors.GroupControl groupPLC;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSymbol;
        private DevExpress.XtraGrid.Columns.GridColumn colMomory;
        private DevExpress.XtraGrid.Columns.GridColumn colContact;
        private DevExpress.XtraGrid.Columns.GridColumn colLogic;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Alerter.AlertControl alert;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupViewer;
        private DevExpress.XtraTab.XtraTabControl ViewTabControl;
    }
}
