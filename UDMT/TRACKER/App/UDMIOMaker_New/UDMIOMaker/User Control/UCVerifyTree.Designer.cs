namespace UDMIOMaker
{
    partial class UCVerifyTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCVerifyTree));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colClassification = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDataType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.exEditorDataType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colUsed = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.exEditorUsed = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDoubleCoil = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.exEditorDoubleCoil = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cntxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClearCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewCondition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLadderView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSymbolDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDoubleCoil)).BeginInit();
            this.cntxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.AllowDrop = true;
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colClassification,
            this.colAddress,
            this.colName,
            this.colDescription,
            this.colDataType,
            this.colUsed,
            this.colDoubleCoil});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.DragNodes = true;
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.EnableFiltering = true;
            this.exTreeList.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Smart;
            this.exTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exTreeList.OptionsSelection.MultiSelect = true;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeList.OptionsView.ShowAutoFilterRow = true;
            this.exTreeList.OptionsView.ShowIndicator = false;
            this.exTreeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorUsed,
            this.exEditorDoubleCoil,
            this.exEditorDataType});
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(757, 572);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.exTreeList_PopupMenuShowing);
            this.exTreeList.Load += new System.EventHandler(this.exTreeList_Load);
            this.exTreeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragDrop);
            this.exTreeList.DragOver += new System.Windows.Forms.DragEventHandler(this.exTreeList_DragOver);
            this.exTreeList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseDown);
            this.exTreeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exTreeList_MouseMove);
            // 
            // colClassification
            // 
            this.colClassification.AppearanceCell.Options.UseTextOptions = true;
            this.colClassification.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClassification.AppearanceHeader.Options.UseTextOptions = true;
            this.colClassification.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClassification.Caption = "분류";
            this.colClassification.FieldName = "Classification";
            this.colClassification.MinWidth = 33;
            this.colClassification.Name = "colClassification";
            this.colClassification.OptionsColumn.AllowMove = false;
            this.colClassification.OptionsColumn.FixedWidth = true;
            this.colClassification.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.colClassification.Visible = true;
            this.colClassification.VisibleIndex = 0;
            this.colClassification.Width = 150;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "주소";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowMove = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 95;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "이름";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "설명";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 160;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "타입";
            this.colDataType.ColumnEdit = this.exEditorDataType;
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowMove = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            this.colDataType.Width = 70;
            // 
            // exEditorDataType
            // 
            this.exEditorDataType.AutoHeight = false;
            this.exEditorDataType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorDataType.Name = "exEditorDataType";
            // 
            // colUsed
            // 
            this.colUsed.AppearanceCell.Options.UseTextOptions = true;
            this.colUsed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUsed.AppearanceHeader.Options.UseTextOptions = true;
            this.colUsed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUsed.Caption = "사용 유무";
            this.colUsed.ColumnEdit = this.exEditorUsed;
            this.colUsed.FieldName = "Use";
            this.colUsed.Name = "colUsed";
            this.colUsed.OptionsColumn.AllowMove = false;
            this.colUsed.OptionsColumn.FixedWidth = true;
            this.colUsed.Visible = true;
            this.colUsed.VisibleIndex = 5;
            this.colUsed.Width = 60;
            // 
            // exEditorUsed
            // 
            this.exEditorUsed.AutoHeight = false;
            this.exEditorUsed.Name = "exEditorUsed";
            // 
            // colDoubleCoil
            // 
            this.colDoubleCoil.AppearanceCell.Options.UseTextOptions = true;
            this.colDoubleCoil.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoubleCoil.AppearanceHeader.Options.UseTextOptions = true;
            this.colDoubleCoil.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDoubleCoil.Caption = "이중 코일";
            this.colDoubleCoil.ColumnEdit = this.exEditorDoubleCoil;
            this.colDoubleCoil.FieldName = "DoubleCoil";
            this.colDoubleCoil.Name = "colDoubleCoil";
            this.colDoubleCoil.OptionsColumn.AllowMove = false;
            this.colDoubleCoil.OptionsColumn.FixedWidth = true;
            this.colDoubleCoil.Visible = true;
            this.colDoubleCoil.VisibleIndex = 6;
            this.colDoubleCoil.Width = 60;
            // 
            // exEditorDoubleCoil
            // 
            this.exEditorDoubleCoil.AutoHeight = false;
            this.exEditorDoubleCoil.Name = "exEditorDoubleCoil";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(3, "yellow_bullet__16x16.png");
            // 
            // cntxMenu
            // 
            this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearCondition,
            this.btnViewCondition,
            this.toolStripSeparator1,
            this.btnLadderView,
            this.btnSymbolDelete});
            this.cntxMenu.Name = "cntxMenu";
            this.cntxMenu.Size = new System.Drawing.Size(247, 98);
            // 
            // btnClearCondition
            // 
            this.btnClearCondition.Image = ((System.Drawing.Image)(resources.GetObject("btnClearCondition.Image")));
            this.btnClearCondition.Name = "btnClearCondition";
            this.btnClearCondition.Size = new System.Drawing.Size(246, 22);
            this.btnClearCondition.Text = "하위 조건 지우기";
            this.btnClearCondition.Click += new System.EventHandler(this.btnClearCondition_Click);
            // 
            // btnViewCondition
            // 
            this.btnViewCondition.Image = ((System.Drawing.Image)(resources.GetObject("btnViewCondition.Image")));
            this.btnViewCondition.Name = "btnViewCondition";
            this.btnViewCondition.Size = new System.Drawing.Size(246, 22);
            this.btnViewCondition.Text = "하위 조건 보기";
            this.btnViewCondition.Click += new System.EventHandler(this.btnViewCondition_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // btnLadderView
            // 
            this.btnLadderView.Image = ((System.Drawing.Image)(resources.GetObject("btnLadderView.Image")));
            this.btnLadderView.Name = "btnLadderView";
            this.btnLadderView.Size = new System.Drawing.Size(246, 22);
            this.btnLadderView.Text = "해당 접점이 사용된 Ladder 보기";
            this.btnLadderView.Click += new System.EventHandler(this.btnLadderView_Click);
            // 
            // btnSymbolDelete
            // 
            this.btnSymbolDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnSymbolDelete.Image")));
            this.btnSymbolDelete.Name = "btnSymbolDelete";
            this.btnSymbolDelete.Size = new System.Drawing.Size(246, 22);
            this.btnSymbolDelete.Text = "해당 노드 지우기";
            this.btnSymbolDelete.Visible = false;
            this.btnSymbolDelete.Click += new System.EventHandler(this.btnSymbolDelete_Click);
            // 
            // UCVerifyTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCVerifyTree";
            this.Size = new System.Drawing.Size(757, 572);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorDoubleCoil)).EndInit();
            this.cntxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colClassification;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDataType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUsed;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDoubleCoil;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorUsed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit exEditorDoubleCoil;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorDataType;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem btnClearCondition;
        private System.Windows.Forms.ToolStripMenuItem btnViewCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnLadderView;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem btnSymbolDelete;
    }
}
