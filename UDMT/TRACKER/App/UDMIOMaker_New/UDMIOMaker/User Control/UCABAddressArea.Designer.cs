namespace UDMIOMaker
{
    partial class UCABAddressArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCABAddressArea));
            this.grdAddressArea = new DevExpress.XtraGrid.GridControl();
            this.grvAddressArea = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRangeIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exbarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSymbolAssign = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAreaDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAreaCopy = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAreaCut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAreaPaste = new DevExpress.XtraBars.BarLargeButtonItem();
            this.mnuAddressArea = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuAddressArea)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAddressArea
            // 
            this.grdAddressArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAddressArea.Location = new System.Drawing.Point(0, 0);
            this.grdAddressArea.MainView = this.grvAddressArea;
            this.grdAddressArea.Name = "grdAddressArea";
            this.grdAddressArea.Size = new System.Drawing.Size(676, 563);
            this.grdAddressArea.TabIndex = 2;
            this.grdAddressArea.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAddressArea});
            // 
            // grvAddressArea
            // 
            this.grvAddressArea.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvAddressArea.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvAddressArea.Appearance.SelectedRow.BackColor = System.Drawing.Color.Orange;
            this.grvAddressArea.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Orange;
            this.grvAddressArea.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvAddressArea.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAddressArea.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvAddressArea.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colI,
            this.colO,
            this.colH,
            this.colN,
            this.colS,
            this.colB,
            this.colT,
            this.colC,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.colRangeIndex});
            this.grvAddressArea.GridControl = this.grdAddressArea;
            this.grvAddressArea.IndicatorWidth = 40;
            this.grvAddressArea.Name = "grvAddressArea";
            this.grvAddressArea.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.grvAddressArea.OptionsBehavior.Editable = false;
            this.grvAddressArea.OptionsBehavior.ReadOnly = true;
            this.grvAddressArea.OptionsDetail.EnableMasterViewMode = false;
            this.grvAddressArea.OptionsDetail.SmartDetailExpand = false;
            this.grvAddressArea.OptionsSelection.MultiSelect = true;
            this.grvAddressArea.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvAddressArea.OptionsView.ColumnAutoWidth = false;
            this.grvAddressArea.OptionsView.ShowGroupPanel = false;
            this.grvAddressArea.OptionsView.ShowIndicator = false;
            this.grvAddressArea.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvAddressArea_RowCellStyle);
            this.grvAddressArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grvAddressArea_KeyUp);
            this.grvAddressArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvAddressArea_MouseUp);
            this.grvAddressArea.DoubleClick += new System.EventHandler(this.grvAddressArea_DoubleClick);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colAddress.AppearanceCell.Options.UseBackColor = true;
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "ADDRESS 영역";
            this.colAddress.FieldName = "AddressArea";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowMove = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            this.colAddress.Width = 100;
            // 
            // colI
            // 
            this.colI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colI.AppearanceHeader.Options.UseFont = true;
            this.colI.AppearanceHeader.Options.UseTextOptions = true;
            this.colI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colI.Caption = "I";
            this.colI.FieldName = "IArea";
            this.colI.MaxWidth = 60;
            this.colI.MinWidth = 60;
            this.colI.Name = "colI";
            this.colI.OptionsColumn.AllowEdit = false;
            this.colI.OptionsColumn.AllowMove = false;
            this.colI.OptionsColumn.FixedWidth = true;
            this.colI.Visible = true;
            this.colI.VisibleIndex = 1;
            this.colI.Width = 60;
            // 
            // colO
            // 
            this.colO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colO.AppearanceHeader.Options.UseFont = true;
            this.colO.AppearanceHeader.Options.UseTextOptions = true;
            this.colO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colO.Caption = "O";
            this.colO.FieldName = "OArea";
            this.colO.MaxWidth = 60;
            this.colO.MinWidth = 60;
            this.colO.Name = "colO";
            this.colO.OptionsColumn.AllowEdit = false;
            this.colO.OptionsColumn.AllowMove = false;
            this.colO.OptionsColumn.FixedWidth = true;
            this.colO.Visible = true;
            this.colO.VisibleIndex = 2;
            this.colO.Width = 60;
            // 
            // colH
            // 
            this.colH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colH.AppearanceHeader.Options.UseFont = true;
            this.colH.AppearanceHeader.Options.UseTextOptions = true;
            this.colH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colH.Caption = "H";
            this.colH.FieldName = "HArea";
            this.colH.MaxWidth = 60;
            this.colH.MinWidth = 60;
            this.colH.Name = "colH";
            this.colH.OptionsColumn.AllowEdit = false;
            this.colH.OptionsColumn.AllowMove = false;
            this.colH.OptionsColumn.FixedWidth = true;
            this.colH.Visible = true;
            this.colH.VisibleIndex = 3;
            this.colH.Width = 60;
            // 
            // colN
            // 
            this.colN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colN.AppearanceHeader.Options.UseFont = true;
            this.colN.AppearanceHeader.Options.UseTextOptions = true;
            this.colN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colN.Caption = "N";
            this.colN.FieldName = "NArea";
            this.colN.MaxWidth = 60;
            this.colN.MinWidth = 60;
            this.colN.Name = "colN";
            this.colN.OptionsColumn.AllowEdit = false;
            this.colN.OptionsColumn.AllowMove = false;
            this.colN.OptionsColumn.FixedWidth = true;
            this.colN.Visible = true;
            this.colN.VisibleIndex = 4;
            this.colN.Width = 60;
            // 
            // colS
            // 
            this.colS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colS.AppearanceHeader.Options.UseFont = true;
            this.colS.AppearanceHeader.Options.UseTextOptions = true;
            this.colS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colS.Caption = "S";
            this.colS.FieldName = "SArea";
            this.colS.MaxWidth = 60;
            this.colS.MinWidth = 60;
            this.colS.Name = "colS";
            this.colS.OptionsColumn.AllowEdit = false;
            this.colS.OptionsColumn.AllowMove = false;
            this.colS.OptionsColumn.FixedWidth = true;
            this.colS.Visible = true;
            this.colS.VisibleIndex = 5;
            this.colS.Width = 60;
            // 
            // colB
            // 
            this.colB.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colB.AppearanceHeader.Options.UseFont = true;
            this.colB.AppearanceHeader.Options.UseTextOptions = true;
            this.colB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colB.Caption = "B";
            this.colB.FieldName = "BArea";
            this.colB.MaxWidth = 60;
            this.colB.MinWidth = 60;
            this.colB.Name = "colB";
            this.colB.OptionsColumn.AllowEdit = false;
            this.colB.OptionsColumn.AllowMove = false;
            this.colB.OptionsColumn.FixedWidth = true;
            this.colB.Visible = true;
            this.colB.VisibleIndex = 6;
            this.colB.Width = 60;
            // 
            // colT
            // 
            this.colT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colT.AppearanceHeader.Options.UseFont = true;
            this.colT.AppearanceHeader.Options.UseTextOptions = true;
            this.colT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT.Caption = "T";
            this.colT.FieldName = "TArea";
            this.colT.MaxWidth = 60;
            this.colT.MinWidth = 60;
            this.colT.Name = "colT";
            this.colT.OptionsColumn.AllowEdit = false;
            this.colT.OptionsColumn.AllowMove = false;
            this.colT.OptionsColumn.FixedWidth = true;
            this.colT.Visible = true;
            this.colT.VisibleIndex = 7;
            this.colT.Width = 60;
            // 
            // colC
            // 
            this.colC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colC.AppearanceHeader.Options.UseFont = true;
            this.colC.AppearanceHeader.Options.UseTextOptions = true;
            this.colC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colC.Caption = "C";
            this.colC.FieldName = "CArea";
            this.colC.MaxWidth = 60;
            this.colC.MinWidth = 60;
            this.colC.Name = "colC";
            this.colC.OptionsColumn.AllowEdit = false;
            this.colC.OptionsColumn.AllowMove = false;
            this.colC.OptionsColumn.FixedWidth = true;
            this.colC.Visible = true;
            this.colC.VisibleIndex = 8;
            this.colC.Width = 60;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "IsIFull";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "IsOFull";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "IsHFull";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.FieldName = "IsNFull";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.FieldName = "IsSFull";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn6";
            this.gridColumn6.FieldName = "IsBFull";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "gridColumn8";
            this.gridColumn8.FieldName = "IsTFull";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "IsCFull";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // colRangeIndex
            // 
            this.colRangeIndex.Caption = "gridColumn10";
            this.colRangeIndex.FieldName = "RangeIndex";
            this.colRangeIndex.Name = "colRangeIndex";
            // 
            // exbarManager
            // 
            this.exbarManager.DockControls.Add(this.barDockControlTop);
            this.exbarManager.DockControls.Add(this.barDockControlBottom);
            this.exbarManager.DockControls.Add(this.barDockControlLeft);
            this.exbarManager.DockControls.Add(this.barDockControlRight);
            this.exbarManager.Form = this;
            this.exbarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSymbolAssign,
            this.btnAreaDelete,
            this.btnAreaCopy,
            this.btnAreaCut,
            this.btnAreaPaste});
            this.exbarManager.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(676, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 563);
            this.barDockControlBottom.Size = new System.Drawing.Size(676, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(676, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // btnSymbolAssign
            // 
            this.btnSymbolAssign.Caption = "해당 영역 심볼 할당 (Insert)";
            this.btnSymbolAssign.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolAssign.Glyph")));
            this.btnSymbolAssign.Id = 0;
            this.btnSymbolAssign.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSymbolAssign.LargeGlyph")));
            this.btnSymbolAssign.Name = "btnSymbolAssign";
            this.btnSymbolAssign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSymbolAssign_ItemClick);
            // 
            // btnAreaDelete
            // 
            this.btnAreaDelete.Caption = "해당 영역 지우기 (Delete)";
            this.btnAreaDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAreaDelete.Glyph")));
            this.btnAreaDelete.Id = 1;
            this.btnAreaDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAreaDelete.LargeGlyph")));
            this.btnAreaDelete.Name = "btnAreaDelete";
            // 
            // btnAreaCopy
            // 
            this.btnAreaCopy.Caption = "해당 영역 복사하기 (F5)";
            this.btnAreaCopy.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAreaCopy.Glyph")));
            this.btnAreaCopy.Id = 2;
            this.btnAreaCopy.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAreaCopy.LargeGlyph")));
            this.btnAreaCopy.Name = "btnAreaCopy";
            // 
            // btnAreaCut
            // 
            this.btnAreaCut.Caption = "해당 영역 잘라내기 (F6)";
            this.btnAreaCut.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAreaCut.Glyph")));
            this.btnAreaCut.Id = 3;
            this.btnAreaCut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAreaCut.LargeGlyph")));
            this.btnAreaCut.Name = "btnAreaCut";
            // 
            // btnAreaPaste
            // 
            this.btnAreaPaste.Caption = "해당 영역 붙여넣기 (F7)";
            this.btnAreaPaste.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAreaPaste.Glyph")));
            this.btnAreaPaste.Id = 4;
            this.btnAreaPaste.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAreaPaste.LargeGlyph")));
            this.btnAreaPaste.Name = "btnAreaPaste";
            // 
            // mnuAddressArea
            // 
            this.mnuAddressArea.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSymbolAssign),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAreaDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAreaCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAreaCut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAreaPaste)});
            this.mnuAddressArea.Manager = this.exbarManager;
            this.mnuAddressArea.Name = "mnuAddressArea";
            // 
            // UCABAddressArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAddressArea);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UCABAddressArea";
            this.Size = new System.Drawing.Size(676, 563);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddressArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAddressArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exbarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuAddressArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAddressArea;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAddressArea;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colI;
        private DevExpress.XtraGrid.Columns.GridColumn colO;
        private DevExpress.XtraGrid.Columns.GridColumn colH;
        private DevExpress.XtraGrid.Columns.GridColumn colN;
        private DevExpress.XtraGrid.Columns.GridColumn colS;
        private DevExpress.XtraGrid.Columns.GridColumn colB;
        private DevExpress.XtraGrid.Columns.GridColumn colT;
        private DevExpress.XtraGrid.Columns.GridColumn colC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn colRangeIndex;
        private DevExpress.XtraBars.BarManager exbarManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnSymbolAssign;
        private DevExpress.XtraBars.BarLargeButtonItem btnAreaDelete;
        private DevExpress.XtraBars.BarLargeButtonItem btnAreaCopy;
        private DevExpress.XtraBars.BarLargeButtonItem btnAreaCut;
        private DevExpress.XtraBars.BarLargeButtonItem btnAreaPaste;
        private DevExpress.XtraBars.PopupMenu mnuAddressArea;
    }
}
