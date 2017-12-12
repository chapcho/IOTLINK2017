namespace UDMTrackerSimple
{
    partial class UCRecipeView
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
            this.grpRecipeWord = new DevExpress.XtraEditors.GroupControl();
            this.grdRecipeTagS = new DevExpress.XtraGrid.GridControl();
            this.grvRecipeTagS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sptMain = new DevExpress.XtraEditors.SplitterControl();
            this.vgrdRecipe = new DevExpress.XtraVerticalGrid.VGridControl();
            this.catRecipe = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rowItem = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowValue = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowBitList = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowKey = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipeWord)).BeginInit();
            this.grpRecipeWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRecipeWord
            // 
            this.grpRecipeWord.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRecipeWord.AppearanceCaption.Options.UseFont = true;
            this.grpRecipeWord.Controls.Add(this.grdRecipeTagS);
            this.grpRecipeWord.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpRecipeWord.Location = new System.Drawing.Point(0, 0);
            this.grpRecipeWord.Name = "grpRecipeWord";
            this.grpRecipeWord.Size = new System.Drawing.Size(233, 158);
            this.grpRecipeWord.TabIndex = 0;
            this.grpRecipeWord.Text = "Recipe Word";
            // 
            // grdRecipeTagS
            // 
            this.grdRecipeTagS.AllowDrop = true;
            this.grdRecipeTagS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRecipeTagS.Location = new System.Drawing.Point(2, 25);
            this.grdRecipeTagS.MainView = this.grvRecipeTagS;
            this.grdRecipeTagS.Name = "grdRecipeTagS";
            this.grdRecipeTagS.Size = new System.Drawing.Size(229, 131);
            this.grdRecipeTagS.TabIndex = 8;
            this.grdRecipeTagS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRecipeTagS});
            // 
            // grvRecipeTagS
            // 
            this.grvRecipeTagS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.grvRecipeTagS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRecipeTagS.GridControl = this.grdRecipeTagS;
            this.grvRecipeTagS.Name = "grvRecipeTagS";
            this.grvRecipeTagS.OptionsBehavior.Editable = false;
            this.grvRecipeTagS.OptionsBehavior.ReadOnly = true;
            this.grvRecipeTagS.OptionsDetail.EnableMasterViewMode = false;
            this.grvRecipeTagS.OptionsDetail.ShowDetailTabs = false;
            this.grvRecipeTagS.OptionsDetail.SmartDetailExpand = false;
            this.grvRecipeTagS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvRecipeTagS.OptionsView.ShowGroupPanel = false;
            this.grvRecipeTagS.RowHeight = 25;
            this.grvRecipeTagS.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvRecipeTagS_CustomDrawRowIndicator);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Key";
            this.gridColumn2.FieldName = "Key";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 114;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Description";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 146;
            // 
            // sptMain
            // 
            this.sptMain.Location = new System.Drawing.Point(233, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Size = new System.Drawing.Size(5, 158);
            this.sptMain.TabIndex = 1;
            this.sptMain.TabStop = false;
            // 
            // vgrdRecipe
            // 
            this.vgrdRecipe.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vgrdRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgrdRecipe.Location = new System.Drawing.Point(238, 0);
            this.vgrdRecipe.Name = "vgrdRecipe";
            this.vgrdRecipe.OptionsBehavior.Editable = false;
            this.vgrdRecipe.OptionsBehavior.SmartExpand = false;
            this.vgrdRecipe.OptionsSelectionAndFocus.EnableAppearanceFocusedRow = false;
            this.vgrdRecipe.RecordWidth = 150;
            this.vgrdRecipe.RowHeaderWidth = 126;
            this.vgrdRecipe.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catRecipe});
            this.vgrdRecipe.Size = new System.Drawing.Size(680, 158);
            this.vgrdRecipe.TabIndex = 2;
            this.vgrdRecipe.CustomDrawRowHeaderCell += new DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventHandler(this.vgrdRecipe_CustomDrawRowHeaderCell);
            // 
            // catRecipe
            // 
            this.catRecipe.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catRecipe.Appearance.Options.UseFont = true;
            this.catRecipe.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowItem,
            this.rowValue,
            this.rowBitList,
            this.rowKey});
            this.catRecipe.Height = 30;
            this.catRecipe.Name = "catRecipe";
            this.catRecipe.OptionsRow.AllowFocus = false;
            this.catRecipe.OptionsRow.AllowMove = false;
            this.catRecipe.Properties.Caption = "Recipe Information";
            // 
            // rowItem
            // 
            this.rowItem.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowItem.Appearance.Options.UseFont = true;
            this.rowItem.Appearance.Options.UseTextOptions = true;
            this.rowItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rowItem.Height = 40;
            this.rowItem.Name = "rowItem";
            this.rowItem.Properties.Caption = "Item";
            this.rowItem.Properties.FieldName = "RecipeItem";
            this.rowItem.Properties.ReadOnly = true;
            // 
            // rowValue
            // 
            this.rowValue.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowValue.Appearance.Options.UseFont = true;
            this.rowValue.Appearance.Options.UseTextOptions = true;
            this.rowValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rowValue.Height = 40;
            this.rowValue.Name = "rowValue";
            this.rowValue.Properties.Caption = "Value";
            this.rowValue.Properties.FieldName = "RecipeValue";
            this.rowValue.Properties.ReadOnly = true;
            // 
            // rowBitList
            // 
            this.rowBitList.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowBitList.Appearance.Options.UseFont = true;
            this.rowBitList.Appearance.Options.UseTextOptions = true;
            this.rowBitList.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rowBitList.Height = 40;
            this.rowBitList.Name = "rowBitList";
            this.rowBitList.Properties.Caption = "Bit List";
            this.rowBitList.Properties.FieldName = "BitPosString";
            this.rowBitList.Properties.ReadOnly = true;
            // 
            // rowKey
            // 
            this.rowKey.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowKey.Appearance.Options.UseFont = true;
            this.rowKey.Appearance.Options.UseTextOptions = true;
            this.rowKey.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rowKey.Height = 40;
            this.rowKey.Name = "rowKey";
            this.rowKey.Properties.Caption = "Recipe Word";
            this.rowKey.Properties.FieldName = "RecipeWord";
            this.rowKey.Properties.ReadOnly = true;
            // 
            // UCRecipeView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vgrdRecipe);
            this.Controls.Add(this.sptMain);
            this.Controls.Add(this.grpRecipeWord);
            this.Name = "UCRecipeView";
            this.Size = new System.Drawing.Size(918, 158);
            this.Load += new System.EventHandler(this.UCRecipeView_Load);
            this.Resize += new System.EventHandler(this.UCRecipeView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grpRecipeWord)).EndInit();
            this.grpRecipeWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecipeTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRecipeTagS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdRecipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpRecipeWord;
        private DevExpress.XtraGrid.GridControl grdRecipeTagS;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRecipeTagS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SplitterControl sptMain;
        private DevExpress.XtraVerticalGrid.VGridControl vgrdRecipe;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catRecipe;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowItem;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowValue;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowBitList;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowKey;
    }
}
