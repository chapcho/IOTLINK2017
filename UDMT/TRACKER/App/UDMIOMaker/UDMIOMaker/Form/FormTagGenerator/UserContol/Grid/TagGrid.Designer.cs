namespace NewIOMaker.Form.Form_TagGenerator
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.exGridPLC = new DevExpress.XtraGrid.GridControl();
            this.exGridViewPLC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.exGridHMI = new DevExpress.XtraGrid.GridControl();
            this.exGridViewHMI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupHMI = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ButtonMapping = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.ButtonConvertor = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonInsertor = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupHMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.exGridPLC);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.exGridHMI);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(904, 605);
            this.splitContainerControl1.SplitterPosition = 442;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // exGridPLC
            // 
            this.exGridPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridPLC.Location = new System.Drawing.Point(0, 0);
            this.exGridPLC.MainView = this.exGridViewPLC;
            this.exGridPLC.Name = "exGridPLC";
            this.exGridPLC.Size = new System.Drawing.Size(442, 605);
            this.exGridPLC.TabIndex = 0;
            this.exGridPLC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewPLC});
            // 
            // exGridViewPLC
            // 
            this.exGridViewPLC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridViewPLC.GridControl = this.exGridPLC;
            this.exGridViewPLC.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridViewPLC.IndicatorWidth = 60;
            this.exGridViewPLC.Name = "exGridViewPLC";
            this.exGridViewPLC.OptionsPrint.PrintHeader = false;
            this.exGridViewPLC.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridViewPLC.OptionsSelection.MultiSelect = true;
            this.exGridViewPLC.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.exGridViewPLC.OptionsView.ShowAutoFilterRow = true;
            this.exGridViewPLC.OptionsView.ShowFooter = true;
            // 
            // exGridHMI
            // 
            this.exGridHMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridHMI.Location = new System.Drawing.Point(0, 0);
            this.exGridHMI.MainView = this.exGridViewHMI;
            this.exGridHMI.Name = "exGridHMI";
            this.exGridHMI.Size = new System.Drawing.Size(450, 605);
            this.exGridHMI.TabIndex = 0;
            this.exGridHMI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewHMI});
            // 
            // exGridViewHMI
            // 
            this.exGridViewHMI.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridViewHMI.GridControl = this.exGridHMI;
            this.exGridViewHMI.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "")});
            this.exGridViewHMI.IndicatorWidth = 60;
            this.exGridViewHMI.Name = "exGridViewHMI";
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
            this.ButtonMapping.Caption = "Mapping Address ( F5 )";
            this.ButtonMapping.Id = 0;
            this.ButtonMapping.Name = "ButtonMapping";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "ETC";
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonConvertor),
            new DevExpress.XtraBars.LinkPersistInfo(this.ButtonInsertor)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // ButtonConvertor
            // 
            this.ButtonConvertor.Caption = "Different Type Convertor";
            this.ButtonConvertor.Id = 2;
            this.ButtonConvertor.Name = "ButtonConvertor";
            // 
            // ButtonInsertor
            // 
            this.ButtonInsertor.Caption = "HMI Insert Bit";
            this.ButtonInsertor.Id = 3;
            this.ButtonInsertor.Name = "ButtonInsertor";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ButtonMapping,
            this.barSubItem1,
            this.ButtonConvertor,
            this.ButtonInsertor});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(904, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 605);
            this.barDockControlBottom.Size = new System.Drawing.Size(904, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 605);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(904, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 605);
            // 
            // TagGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TagGrid";
            this.Size = new System.Drawing.Size(904, 605);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupHMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
