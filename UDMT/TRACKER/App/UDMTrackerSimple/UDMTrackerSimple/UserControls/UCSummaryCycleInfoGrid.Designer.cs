namespace UDMTrackerSimple
{
    partial class UCSummaryCycleInfoGrid
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
            this.grdSummary = new DevExpress.XtraGrid.GridControl();
            this.grvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEfficiency = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSummary
            // 
            this.grdSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSummary.Location = new System.Drawing.Point(0, 0);
            this.grdSummary.LookAndFeel.SkinName = "Office 2013";
            this.grdSummary.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdSummary.MainView = this.grvSummary;
            this.grdSummary.Name = "grdSummary";
            this.grdSummary.Size = new System.Drawing.Size(541, 307);
            this.grdSummary.TabIndex = 0;
            this.grdSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSummary});
            // 
            // grvSummary
            // 
            this.grvSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGroup,
            this.colState,
            this.colCycleCount,
            this.colErrorCount,
            this.colTact,
            this.colIdle,
            this.colUPH,
            this.colEfficiency});
            this.grvSummary.GridControl = this.grdSummary;
            this.grvSummary.Name = "grvSummary";
            this.grvSummary.OptionsBehavior.Editable = false;
            this.grvSummary.OptionsBehavior.ReadOnly = true;
            this.grvSummary.OptionsCustomization.AllowColumnMoving = false;
            this.grvSummary.OptionsDetail.AllowZoomDetail = false;
            this.grvSummary.OptionsDetail.EnableMasterViewMode = false;
            this.grvSummary.OptionsDetail.SmartDetailExpand = false;
            this.grvSummary.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.grvSummary.OptionsView.ShowGroupPanel = false;
            this.grvSummary.OptionsView.ShowIndicator = false;
            this.grvSummary.RowHeight = 30;
            this.grvSummary.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvSummary_CustomDrawCell);
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceCell.Options.UseFont = true;
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGroup.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colGroup.AppearanceHeader.Options.UseFont = true;
            this.colGroup.AppearanceHeader.Options.UseForeColor = true;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.Caption = "Group";
            this.colGroup.FieldName = "GroupKey";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 0;
            // 
            // colState
            // 
            this.colState.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colState.AppearanceCell.Options.UseFont = true;
            this.colState.AppearanceCell.Options.UseTextOptions = true;
            this.colState.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colState.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colState.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colState.AppearanceHeader.Options.UseFont = true;
            this.colState.AppearanceHeader.Options.UseForeColor = true;
            this.colState.AppearanceHeader.Options.UseTextOptions = true;
            this.colState.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colState.Caption = "State";
            this.colState.FieldName = "CycleType";
            this.colState.Name = "colState";
            this.colState.Visible = true;
            this.colState.VisibleIndex = 1;
            // 
            // colCycleCount
            // 
            this.colCycleCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleCount.AppearanceCell.Options.UseFont = true;
            this.colCycleCount.AppearanceCell.Options.UseTextOptions = true;
            this.colCycleCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCycleCount.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colCycleCount.AppearanceHeader.Options.UseFont = true;
            this.colCycleCount.AppearanceHeader.Options.UseForeColor = true;
            this.colCycleCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycleCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycleCount.Caption = "#Cycle";
            this.colCycleCount.FieldName = "CycleCount";
            this.colCycleCount.Name = "colCycleCount";
            this.colCycleCount.Visible = true;
            this.colCycleCount.VisibleIndex = 3;
            // 
            // colErrorCount
            // 
            this.colErrorCount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceCell.Options.UseFont = true;
            this.colErrorCount.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colErrorCount.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colErrorCount.AppearanceHeader.Options.UseFont = true;
            this.colErrorCount.AppearanceHeader.Options.UseForeColor = true;
            this.colErrorCount.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorCount.Caption = "#Error";
            this.colErrorCount.FieldName = "ErrorCount";
            this.colErrorCount.Name = "colErrorCount";
            this.colErrorCount.Visible = true;
            this.colErrorCount.VisibleIndex = 2;
            // 
            // colTact
            // 
            this.colTact.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTact.AppearanceCell.Options.UseFont = true;
            this.colTact.AppearanceCell.Options.UseTextOptions = true;
            this.colTact.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTact.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTact.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colTact.AppearanceHeader.Options.UseFont = true;
            this.colTact.AppearanceHeader.Options.UseForeColor = true;
            this.colTact.AppearanceHeader.Options.UseTextOptions = true;
            this.colTact.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTact.Caption = "Tact";
            this.colTact.FieldName = "TactTime";
            this.colTact.Name = "colTact";
            this.colTact.Visible = true;
            this.colTact.VisibleIndex = 4;
            // 
            // colIdle
            // 
            this.colIdle.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdle.AppearanceCell.Options.UseFont = true;
            this.colIdle.AppearanceCell.Options.UseTextOptions = true;
            this.colIdle.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colIdle.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIdle.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colIdle.AppearanceHeader.Options.UseFont = true;
            this.colIdle.AppearanceHeader.Options.UseForeColor = true;
            this.colIdle.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdle.Caption = "Idle";
            this.colIdle.FieldName = "IdleTime";
            this.colIdle.Name = "colIdle";
            this.colIdle.Visible = true;
            this.colIdle.VisibleIndex = 5;
            // 
            // colUPH
            // 
            this.colUPH.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUPH.AppearanceCell.Options.UseFont = true;
            this.colUPH.AppearanceCell.Options.UseTextOptions = true;
            this.colUPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUPH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUPH.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colUPH.AppearanceHeader.Options.UseFont = true;
            this.colUPH.AppearanceHeader.Options.UseForeColor = true;
            this.colUPH.AppearanceHeader.Options.UseTextOptions = true;
            this.colUPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUPH.Caption = "UPH";
            this.colUPH.FieldName = "Uph";
            this.colUPH.Name = "colUPH";
            this.colUPH.Visible = true;
            this.colUPH.VisibleIndex = 6;
            // 
            // colEfficiency
            // 
            this.colEfficiency.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEfficiency.AppearanceCell.Options.UseFont = true;
            this.colEfficiency.AppearanceCell.Options.UseTextOptions = true;
            this.colEfficiency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEfficiency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEfficiency.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colEfficiency.AppearanceHeader.Options.UseFont = true;
            this.colEfficiency.AppearanceHeader.Options.UseForeColor = true;
            this.colEfficiency.AppearanceHeader.Options.UseTextOptions = true;
            this.colEfficiency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEfficiency.Caption = "Efficiency";
            this.colEfficiency.FieldName = "Efficiency";
            this.colEfficiency.Name = "colEfficiency";
            this.colEfficiency.Visible = true;
            this.colEfficiency.VisibleIndex = 7;
            // 
            // UCSummaryCycleInfoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdSummary);
            this.Name = "UCSummaryCycleInfoGrid";
            this.Size = new System.Drawing.Size(541, 307);
            ((System.ComponentModel.ISupportInitialize)(this.grdSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
        private DevExpress.XtraGrid.Columns.GridColumn colCycleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colTact;
        private DevExpress.XtraGrid.Columns.GridColumn colIdle;
        private DevExpress.XtraGrid.Columns.GridColumn colUPH;
        private DevExpress.XtraGrid.Columns.GridColumn colEfficiency;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorCount;
    }
}
