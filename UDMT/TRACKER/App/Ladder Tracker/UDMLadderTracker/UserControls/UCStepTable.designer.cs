﻿namespace UDMLadderTracker
{
    partial class UCStepTable
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
            this.grdStep = new DevExpress.XtraGrid.GridControl();
            this.grvStep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstruction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFile = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStep
            // 
            this.grdStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStep.Location = new System.Drawing.Point(0, 0);
            this.grdStep.MainView = this.grvStep;
            this.grdStep.Name = "grdStep";
            this.grdStep.Size = new System.Drawing.Size(394, 569);
            this.grdStep.TabIndex = 0;
            this.grdStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStep});
            // 
            // grvStep
            // 
            this.grvStep.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.grvStep.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvStep.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grvStep.Appearance.Row.Options.UseFont = true;
            this.grvStep.ColumnPanelRowHeight = 40;
            this.grvStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colInstruction,
            this.colFile});
            this.grvStep.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvStep.GridControl = this.grdStep;
            this.grvStep.IndicatorWidth = 40;
            this.grvStep.Name = "grvStep";
            this.grvStep.OptionsBehavior.Editable = false;
            this.grvStep.OptionsBehavior.ReadOnly = true;
            this.grvStep.OptionsDetail.EnableMasterViewMode = false;
            this.grvStep.OptionsDetail.ShowDetailTabs = false;
            this.grvStep.OptionsDetail.SmartDetailExpand = false;
            this.grvStep.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvStep.RowHeight = 25;
            this.grvStep.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvStep_CustomDrawRowIndicator);
            this.grvStep.DoubleClick += new System.EventHandler(this.grvStep_DoubleClick);
            // 
            // colAddress
            // 
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 0;
            // 
            // colInstruction
            // 
            this.colInstruction.AppearanceHeader.Options.UseTextOptions = true;
            this.colInstruction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInstruction.Caption = "Instruction";
            this.colInstruction.FieldName = "Instruction";
            this.colInstruction.Name = "colInstruction";
            this.colInstruction.Visible = true;
            this.colInstruction.VisibleIndex = 1;
            // 
            // colFile
            // 
            this.colFile.AppearanceHeader.Options.UseTextOptions = true;
            this.colFile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFile.Caption = "File";
            this.colFile.FieldName = "Program";
            this.colFile.Name = "colFile";
            this.colFile.Visible = true;
            this.colFile.VisibleIndex = 2;
            // 
            // UCStepTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdStep);
            this.Name = "UCStepTable";
            this.Size = new System.Drawing.Size(394, 569);
            this.Load += new System.EventHandler(this.UCStepTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStep;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStep;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colInstruction;
        private DevExpress.XtraGrid.Columns.GridColumn colFile;

    }
}