namespace UDMEnergyViewer
{
    partial class FrmTagRecommand
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcTag = new DevExpress.XtraGrid.GridControl();
            this.gvTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrorRange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTolerance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spnTolerance = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnTolerance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcTag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 291);
            this.panel1.TabIndex = 0;
            // 
            // gcTag
            // 
            this.gcTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTag.Location = new System.Drawing.Point(0, 0);
            this.gcTag.MainView = this.gvTag;
            this.gcTag.Name = "gcTag";
            this.gcTag.Size = new System.Drawing.Size(719, 291);
            this.gcTag.TabIndex = 0;
            this.gcTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTag});
            // 
            // gvTag
            // 
            this.gvTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCycle,
            this.colAddress,
            this.colDescription,
            this.colFit,
            this.colErrorRange,
            this.colTolerance});
            this.gvTag.GridControl = this.gcTag;
            this.gvTag.Name = "gvTag";
            this.gvTag.OptionsBehavior.Editable = false;
            this.gvTag.OptionsSelection.MultiSelect = true;
            // 
            // colCycle
            // 
            this.colCycle.AppearanceCell.Options.UseTextOptions = true;
            this.colCycle.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycle.AppearanceHeader.Options.UseTextOptions = true;
            this.colCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCycle.Caption = "Cycle";
            this.colCycle.FieldName = "Cycle";
            this.colCycle.Name = "colCycle";
            this.colCycle.Visible = true;
            this.colCycle.VisibleIndex = 0;
            this.colCycle.Width = 60;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 1;
            this.colAddress.Width = 92;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 177;
            // 
            // colFit
            // 
            this.colFit.AppearanceCell.Options.UseTextOptions = true;
            this.colFit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFit.AppearanceHeader.Options.UseTextOptions = true;
            this.colFit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFit.Caption = "Fit(%)";
            this.colFit.FieldName = "Fit";
            this.colFit.Name = "colFit";
            this.colFit.Visible = true;
            this.colFit.VisibleIndex = 3;
            this.colFit.Width = 118;
            // 
            // colErrorRange
            // 
            this.colErrorRange.AppearanceCell.Options.UseTextOptions = true;
            this.colErrorRange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorRange.AppearanceHeader.Options.UseTextOptions = true;
            this.colErrorRange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colErrorRange.Caption = "Error Range(ms)";
            this.colErrorRange.FieldName = "ErrorRange";
            this.colErrorRange.Name = "colErrorRange";
            this.colErrorRange.Visible = true;
            this.colErrorRange.VisibleIndex = 5;
            this.colErrorRange.Width = 124;
            // 
            // colTolerance
            // 
            this.colTolerance.AppearanceCell.Options.UseTextOptions = true;
            this.colTolerance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTolerance.AppearanceHeader.Options.UseTextOptions = true;
            this.colTolerance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTolerance.Caption = "Tolerance(ms)";
            this.colTolerance.FieldName = "Tolerance";
            this.colTolerance.Name = "colTolerance";
            this.colTolerance.Visible = true;
            this.colTolerance.VisibleIndex = 4;
            this.colTolerance.Width = 130;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.labelControl2);
            this.panel2.Controls.Add(this.spnTolerance);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 33);
            this.panel2.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(162, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 24);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(138, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "sec";
            // 
            // spnTolerance
            // 
            this.spnTolerance.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spnTolerance.Location = new System.Drawing.Point(80, 6);
            this.spnTolerance.Name = "spnTolerance";
            this.spnTolerance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnTolerance.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnTolerance.Size = new System.Drawing.Size(52, 20);
            this.spnTolerance.TabIndex = 3;
            this.spnTolerance.EditValueChanged += new System.EventHandler(this.spnTolerance_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tolerance :";
            // 
            // btnShow
            // 
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShow.Location = new System.Drawing.Point(569, 0);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 33);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(644, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmTagRecommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 324);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmTagRecommand";
            this.Text = "Tag Recommandation";
            this.Load += new System.EventHandler(this.FrmTagSelector_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTag)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnTolerance.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcTag;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTag;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colFit;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colCycle;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colErrorRange;
        private DevExpress.XtraGrid.Columns.GridColumn colTolerance;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spnTolerance;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}