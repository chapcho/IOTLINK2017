namespace UDMPLCLogicAnalyzer
{
    partial class UCPLCDataGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCPLCDataGrid));
            this.grpMain = new DevExpress.XtraEditors.GroupControl();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.cntxTotalTag = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLadderView = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCPU = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.cntxTotalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 15F);
            this.grpMain.AppearanceCaption.Options.UseFont = true;
            this.grpMain.Controls.Add(this.grdData);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(955, 434);
            this.grpMain.TabIndex = 0;
            this.grpMain.Text = "PLC Name";
            // 
            // grdData
            // 
            this.grdData.ContextMenuStrip = this.cntxTotalTag;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(2, 31);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(951, 401);
            this.grdData.TabIndex = 0;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // cntxTotalTag
            // 
            this.cntxTotalTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLadderView});
            this.cntxTotalTag.Name = "cntxTotalTag";
            this.cntxTotalTag.Size = new System.Drawing.Size(275, 26);
            // 
            // btnLadderView
            // 
            this.btnLadderView.Image = ((System.Drawing.Image)(resources.GetObject("btnLadderView.Image")));
            this.btnLadderView.Name = "btnLadderView";
            this.btnLadderView.Size = new System.Drawing.Size(274, 22);
            this.btnLadderView.Text = "해당 출력 접점과 관련된 Ladder 보기";
            this.btnLadderView.Click += new System.EventHandler(this.btnLadderView_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.GroupRow.BackColor = System.Drawing.Color.Red;
            this.grvData.Appearance.GroupRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grvData.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.grvData.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.grvData.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvData.Appearance.GroupRow.Options.UseFont = true;
            this.grvData.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvData.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvData.Appearance.Row.Options.UseFont = true;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colComment,
            this.colStepNumber,
            this.colProgram,
            this.colNumber,
            this.colCPU});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 2;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.grvData.OptionsBehavior.ReadOnly = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvData.PaintStyleName = "Flat";
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCPU, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNumber, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Tag.Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 193;
            // 
            // colComment
            // 
            this.colComment.Caption = "Comment";
            this.colComment.FieldName = "Tag.Name";
            this.colComment.Name = "colComment";
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 3;
            this.colComment.Width = 423;
            // 
            // colStepNumber
            // 
            this.colStepNumber.Caption = "Step";
            this.colStepNumber.FieldName = "StepNumber";
            this.colStepNumber.Name = "colStepNumber";
            this.colStepNumber.Visible = true;
            this.colStepNumber.VisibleIndex = 1;
            this.colStepNumber.Width = 175;
            // 
            // colProgram
            // 
            this.colProgram.Caption = "Program";
            this.colProgram.FieldName = "Program";
            this.colProgram.Name = "colProgram";
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 0;
            this.colProgram.Width = 144;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "Number";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 1;
            // 
            // colCPU
            // 
            this.colCPU.Caption = "CPU Name";
            this.colCPU.FieldName = "Tag.Creator";
            this.colCPU.Name = "colCPU";
            this.colCPU.Visible = true;
            this.colCPU.VisibleIndex = 1;
            // 
            // UCPLCDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "UCPLCDataGrid";
            this.Size = new System.Drawing.Size(955, 434);
            this.Load += new System.EventHandler(this.UCPLCDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.cntxTotalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpMain;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colStepNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private System.Windows.Forms.ContextMenuStrip cntxTotalTag;
        private System.Windows.Forms.ToolStripMenuItem btnLadderView;
        private DevExpress.XtraGrid.Columns.GridColumn colCPU;
    }
}
