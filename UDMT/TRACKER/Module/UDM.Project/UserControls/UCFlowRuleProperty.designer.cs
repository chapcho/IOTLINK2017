namespace UDM.Project
{
    partial class UCFlowRuleProperty
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
			this.exProperty = new DevExpress.XtraVerticalGrid.PropertyGridControl();
			this.exEditorPointType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.exEditorValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.catLink = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowLink = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.catInterval = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowInterval = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.catTolerance = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowTolerance = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.catPointOption = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
			this.rowPointTypeFrom = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			this.rowPointTypeTo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorPointType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).BeginInit();
			this.SuspendLayout();
			// 
			// exProperty
			// 
			this.exProperty.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exProperty.Location = new System.Drawing.Point(0, 0);
			this.exProperty.Name = "exProperty";
			this.exProperty.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
			this.exProperty.OptionsView.ShowFocusedFrame = false;
			this.exProperty.RecordWidth = 86;
			this.exProperty.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorPointType,
            this.exEditorValue});
			this.exProperty.RowHeaderWidth = 114;
			this.exProperty.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catLink,
            this.catInterval,
            this.catTolerance,
            this.catPointOption});
			this.exProperty.Size = new System.Drawing.Size(251, 255);
			this.exProperty.TabIndex = 0;
			// 
			// exEditorPointType
			// 
			this.exEditorPointType.AutoHeight = false;
			this.exEditorPointType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.exEditorPointType.Items.AddRange(new object[] {
            "Start",
            "End"});
			this.exEditorPointType.Name = "exEditorPointType";
			// 
			// exEditorValue
			// 
			this.exEditorValue.AutoHeight = false;
			this.exEditorValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.exEditorValue.IsFloatValue = false;
			this.exEditorValue.Mask.EditMask = "N00";
			this.exEditorValue.Name = "exEditorValue";
			// 
			// catLink
			// 
			this.catLink.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowLink});
			this.catLink.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catLink.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catLink.Name = "catLink";
			this.catLink.OptionsRow.AllowMove = false;
			this.catLink.OptionsRow.AllowMoveToCustomizationForm = false;
			this.catLink.OptionsRow.AllowSize = false;
			this.catLink.OptionsRow.DblClickExpanding = false;
			this.catLink.Properties.Caption = "Link Option";
			// 
			// rowLink
			// 
			this.rowLink.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowLink.Height = 25;
			this.rowLink.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowLink.Name = "rowLink";
			this.rowLink.Properties.Caption = "HasLink";
			this.rowLink.Properties.FieldName = "HasLink";
			// 
			// catInterval
			// 
			this.catInterval.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowInterval});
			this.catInterval.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catInterval.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catInterval.Name = "catInterval";
			this.catInterval.Properties.Caption = "Link Interval Option";
			// 
			// rowInterval
			// 
			this.rowInterval.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowInterval.Height = 25;
			this.rowInterval.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowInterval.Name = "rowInterval";
			this.rowInterval.Properties.Caption = "Interval";
			this.rowInterval.Properties.FieldName = "Interval";
			this.rowInterval.Properties.RowEdit = this.exEditorValue;
			// 
			// catTolerance
			// 
			this.catTolerance.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowTolerance});
			this.catTolerance.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catTolerance.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catTolerance.Name = "catTolerance";
			this.catTolerance.OptionsRow.AllowMove = false;
			this.catTolerance.OptionsRow.AllowMoveToCustomizationForm = false;
			this.catTolerance.OptionsRow.AllowSize = false;
			this.catTolerance.OptionsRow.DblClickExpanding = false;
			this.catTolerance.Properties.Caption = "Link Tolerance Option";
			// 
			// rowTolerance
			// 
			this.rowTolerance.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowTolerance.Height = 25;
			this.rowTolerance.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowTolerance.Name = "rowTolerance";
			this.rowTolerance.Properties.Caption = "Tolerance";
			this.rowTolerance.Properties.FieldName = "Tolerance";
			this.rowTolerance.Properties.RowEdit = this.exEditorValue;
			// 
			// catPointOption
			// 
			this.catPointOption.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPointTypeFrom,
            this.rowPointTypeTo});
			this.catPointOption.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catPointOption.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.catPointOption.Name = "catPointOption";
			this.catPointOption.OptionsRow.AllowMove = false;
			this.catPointOption.OptionsRow.AllowMoveToCustomizationForm = false;
			this.catPointOption.OptionsRow.AllowSize = false;
			this.catPointOption.OptionsRow.DblClickExpanding = false;
			this.catPointOption.Properties.Caption = "Point Edge Option";
			// 
			// rowPointTypeFrom
			// 
			this.rowPointTypeFrom.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowPointTypeFrom.Height = 25;
			this.rowPointTypeFrom.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowPointTypeFrom.Name = "rowPointTypeFrom";
			this.rowPointTypeFrom.Properties.Caption = "PointType From";
			this.rowPointTypeFrom.Properties.FieldName = "PointTypeFrom";
			this.rowPointTypeFrom.Properties.RowEdit = this.exEditorPointType;
			// 
			// rowPointTypeTo
			// 
			this.rowPointTypeTo.Fixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowPointTypeTo.Height = 25;
			this.rowPointTypeTo.InternalFixed = DevExpress.XtraVerticalGrid.Rows.FixedStyle.Top;
			this.rowPointTypeTo.Name = "rowPointTypeTo";
			this.rowPointTypeTo.Properties.Caption = "PointType To";
			this.rowPointTypeTo.Properties.FieldName = "PointTypeTo";
			this.rowPointTypeTo.Properties.RowEdit = this.exEditorPointType;
			// 
			// UCFlowRuleProperty
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exProperty);
			this.Name = "UCFlowRuleProperty";
			this.Size = new System.Drawing.Size(251, 255);
			this.Load += new System.EventHandler(this.UCFlowRule_Load);
			((System.ComponentModel.ISupportInitialize)(this.exProperty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorPointType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.exEditorValue)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl exProperty;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catLink;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLink;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowInterval;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorPointType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTolerance;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPointTypeFrom;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPointTypeTo;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catInterval;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catTolerance;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catPointOption;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit exEditorValue;
    }
}
