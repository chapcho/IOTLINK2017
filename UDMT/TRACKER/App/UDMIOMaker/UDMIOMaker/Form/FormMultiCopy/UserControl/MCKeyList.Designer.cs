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
            this.popupKeyList = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnRemoveKey = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridView)).BeginInit();
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
            this.KeyListGridControl.Size = new System.Drawing.Size(496, 337);
            this.KeyListGridControl.TabIndex = 0;
            this.KeyListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.KeyListGridView});
            // 
            // KeyListGridView
            // 
            this.KeyListGridView.GridControl = this.KeyListGridControl;
            this.KeyListGridView.Name = "KeyListGridView";
            this.KeyListGridView.OptionsBehavior.Editable = false;
            this.KeyListGridView.OptionsBehavior.ReadOnly = true;
            this.KeyListGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.KeyListGridView.OptionsSelection.MultiSelect = true;
            this.KeyListGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.KeyListGridView.OptionsView.ShowFooter = true;
            // 
            // popupKeyList
            // 
            this.popupKeyList.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRemoveKey)});
            this.popupKeyList.Manager = this.barManager1;
            this.popupKeyList.Name = "popupKeyList";
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
            this.barStaticItem1});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(496, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 337);
            this.barDockControlBottom.Size = new System.Drawing.Size(496, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 337);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(496, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 337);
            // 
            // btnRemoveKey
            // 
            this.btnRemoveKey.Caption = "Remove";
            this.btnRemoveKey.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveKey.Glyph")));
            this.btnRemoveKey.Id = 0;
            this.btnRemoveKey.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRemoveKey.LargeGlyph")));
            this.btnRemoveKey.Name = "btnRemoveKey";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "더블클릭으로 키를 선택하세요";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
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
            this.Size = new System.Drawing.Size(496, 337);
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListGridView)).EndInit();
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
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
    }
}
