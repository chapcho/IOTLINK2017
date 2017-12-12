namespace NewIOMaker.Form.Form_MultiCopy
{
    partial class MCKeyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCKeyList));
            this.KeyListGridControl = new DevExpress.XtraGrid.GridControl();
            this.KeyListGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.popupKeyList = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDoublClick = new DevExpress.XtraBars.BarStaticItem();
            this.btnSelecKey = new DevExpress.XtraBars.BarButtonItem();
            this.UpdateKey = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemoveKey = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupKeyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyListGridControl
            // 
            this.KeyListGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyListGridControl.Location = new System.Drawing.Point(0, 0);
            this.KeyListGridControl.MainView = this.KeyListGridView;
            this.KeyListGridControl.Name = "KeyListGridControl";
            this.KeyListGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemToggleSwitch1,
            this.repositoryItemCheckEdit2});
            this.KeyListGridControl.Size = new System.Drawing.Size(432, 549);
            this.KeyListGridControl.TabIndex = 0;
            this.KeyListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.KeyListGridView});
            // 
            // KeyListGridView
            // 
            this.KeyListGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.KeyListGridView.GridControl = this.KeyListGridControl;
            this.KeyListGridView.Name = "KeyListGridView";
            this.KeyListGridView.OptionsBehavior.ReadOnly = true;
            this.KeyListGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.KeyListGridView.OptionsSelection.MultiSelect = true;
            this.KeyListGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.KeyListGridView.OptionsView.ShowFooter = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Key List";
            this.gridColumn2.FieldName = "Key List";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Option";
            this.gridColumn1.ColumnEdit = this.repositoryItemToggleSwitch1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // popupKeyList
            // 
            this.popupKeyList.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDoublClick),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSelecKey),
            new DevExpress.XtraBars.LinkPersistInfo(this.UpdateKey),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveKey)});
            this.popupKeyList.Manager = this.barManager1;
            this.popupKeyList.Name = "popupKeyList";
            // 
            // btnDoublClick
            // 
            this.btnDoublClick.Caption = "더블클릭으로 키를 선택하세요";
            this.btnDoublClick.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDoublClick.Glyph")));
            this.btnDoublClick.Id = 1;
            this.btnDoublClick.Name = "btnDoublClick";
            this.btnDoublClick.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnSelecKey
            // 
            this.btnSelecKey.Caption = "Select Key";
            this.btnSelecKey.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSelecKey.Glyph")));
            this.btnSelecKey.Id = 3;
            this.btnSelecKey.Name = "btnSelecKey";
            // 
            // UpdateKey
            // 
            this.UpdateKey.Caption = "Update Key";
            this.UpdateKey.Glyph = ((System.Drawing.Image)(resources.GetObject("UpdateKey.Glyph")));
            this.UpdateKey.Id = 2;
            this.UpdateKey.Name = "UpdateKey";
            // 
            // btnRemoveKey
            // 
            this.btnRemoveKey.Caption = "Remove";
            this.btnRemoveKey.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveKey.Glyph")));
            this.btnRemoveKey.Id = 0;
            this.btnRemoveKey.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveKey.LargeGlyph")));
            this.btnRemoveKey.Name = "btnRemoveKey";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnRemoveKey,
            this.btnDoublClick,
            this.UpdateKey,
            this.btnSelecKey});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(432, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 549);
            this.barDockControlBottom.Size = new System.Drawing.Size(432, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 549);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(432, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 549);
            // 
            // MCKeyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KeyListGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MCKeyList";
            this.Size = new System.Drawing.Size(432, 549);
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupKeyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl KeyListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView KeyListGridView;
        private DevExpress.XtraBars.PopupMenu popupKeyList;
        private DevExpress.XtraBars.BarButtonItem btnRemoveKey;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem btnDoublClick;
        private DevExpress.XtraBars.BarButtonItem UpdateKey;
        private DevExpress.XtraBars.BarButtonItem btnSelecKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}
