namespace UDMTrackerSimple
{
    partial class UCCycleCardWidget
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
            this.vgrdSummary = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowCycleCount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTact = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowIdle = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUph = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEfficiency = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ucCycleInfo = new UCCircleGauge();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblMaxText = new DevExpress.XtraEditors.LabelControl();
            this.lblMaxTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.vgrdSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vgrdSummary
            // 
            this.vgrdSummary.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdSummary.Appearance.RecordValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdSummary.Appearance.RecordValue.Options.UseFont = true;
            this.vgrdSummary.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vgrdSummary.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.vgrdSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vgrdSummary.Location = new System.Drawing.Point(131, 0);
            this.vgrdSummary.LookAndFeel.SkinName = "Office 2013";
            this.vgrdSummary.LookAndFeel.UseDefaultLookAndFeel = false;
            this.vgrdSummary.Name = "vgrdSummary";
            this.vgrdSummary.OptionsBehavior.Editable = false;
            this.vgrdSummary.OptionsBehavior.ResizeHeaderPanel = false;
            this.vgrdSummary.OptionsBehavior.ResizeRowHeaders = false;
            this.vgrdSummary.OptionsBehavior.ResizeRowValues = false;
            this.vgrdSummary.OptionsBehavior.SmartExpand = false;
            this.vgrdSummary.OptionsSelectionAndFocus.EnableAppearanceFocusedRow = false;
            this.vgrdSummary.OptionsView.FixRowHeaderPanelWidth = true;
            this.vgrdSummary.OptionsView.MaxRowAutoHeight = 30;
            this.vgrdSummary.OptionsView.MinRowAutoHeight = 30;
            this.vgrdSummary.RecordWidth = 105;
            this.vgrdSummary.RowHeaderWidth = 105;
            this.vgrdSummary.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowCycleCount,
            this.rowTact,
            this.rowIdle,
            this.rowUph,
            this.rowEfficiency});
            this.vgrdSummary.Size = new System.Drawing.Size(216, 159);
            this.vgrdSummary.TabIndex = 2;
            // 
            // rowCycleCount
            // 
            this.rowCycleCount.Name = "rowCycleCount";
            this.rowCycleCount.Properties.Caption = "Count";
            this.rowCycleCount.Properties.FieldName = "CycleCount";
            // 
            // rowTact
            // 
            this.rowTact.Name = "rowTact";
            this.rowTact.Properties.Caption = "Tact";
            this.rowTact.Properties.FieldName = "TactTime";
            // 
            // rowIdle
            // 
            this.rowIdle.Name = "rowIdle";
            this.rowIdle.Properties.Caption = "Idle";
            this.rowIdle.Properties.FieldName = "IdleTime";
            // 
            // rowUph
            // 
            this.rowUph.Name = "rowUph";
            this.rowUph.Properties.Caption = "UPH";
            this.rowUph.Properties.FieldName = "Uph";
            // 
            // rowEfficiency
            // 
            this.rowEfficiency.Name = "rowEfficiency";
            this.rowEfficiency.Properties.Caption = "Efficiency";
            this.rowEfficiency.Properties.FieldName = "Efficiency";
            // 
            // ucCycleInfo
            // 
            this.ucCycleInfo.BackColor = System.Drawing.Color.White;
            this.ucCycleInfo.CircleText = "0s";
            this.ucCycleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCycleInfo.Location = new System.Drawing.Point(2, 2);
            this.ucCycleInfo.MaxBarColor = System.Drawing.Color.LightGray;
            this.ucCycleInfo.MaxValue = 30F;
            this.ucCycleInfo.Name = "ucCycleInfo";
            this.ucCycleInfo.Size = new System.Drawing.Size(127, 133);
            this.ucCycleInfo.TabIndex = 3;
            this.ucCycleInfo.TitleText = "Tact Time";
            this.ucCycleInfo.Value = 30F;
            this.ucCycleInfo.ValueBarColor = System.Drawing.Color.GreenYellow;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.ucCycleInfo);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(131, 159);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.BorderColor = System.Drawing.Color.Black;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Appearance.Options.UseBorderColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl2.Controls.Add(this.lblMaxText);
            this.panelControl2.Controls.Add(this.lblMaxTitle);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 135);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(127, 22);
            this.panelControl2.TabIndex = 4;
            // 
            // lblMaxText
            // 
            this.lblMaxText.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxText.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaxText.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMaxText.Location = new System.Drawing.Point(99, 0);
            this.lblMaxText.Name = "lblMaxText";
            this.lblMaxText.Size = new System.Drawing.Size(28, 18);
            this.lblMaxText.TabIndex = 1;
            this.lblMaxText.Text = "60s";
            // 
            // lblMaxTitle
            // 
            this.lblMaxTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTitle.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaxTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMaxTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMaxTitle.Name = "lblMaxTitle";
            this.lblMaxTitle.Size = new System.Drawing.Size(35, 18);
            this.lblMaxTitle.TabIndex = 0;
            this.lblMaxTitle.Text = "Max ";
            // 
            // UCCycleCardWidget
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vgrdSummary);
            this.Controls.Add(this.panelControl1);
            this.Name = "UCCycleCardWidget";
            this.Size = new System.Drawing.Size(347, 159);
            ((System.ComponentModel.ISupportInitialize)(this.vgrdSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl vgrdSummary;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCycleCount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTact;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowIdle;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUph;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEfficiency;
        private UCCircleGauge ucCycleInfo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblMaxText;
        private DevExpress.XtraEditors.LabelControl lblMaxTitle;
    }
}
