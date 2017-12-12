namespace UDMIOMaker
{
    partial class FrmStepSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStepSelector));
            this.grdStep = new DevExpress.XtraGrid.GridControl();
            this.grvStep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstruction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdStep
            // 
            this.grdStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStep.Location = new System.Drawing.Point(0, 0);
            this.grdStep.MainView = this.grvStep;
            this.grdStep.Name = "grdStep";
            this.grdStep.Size = new System.Drawing.Size(784, 268);
            this.grdStep.TabIndex = 0;
            this.grdStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStep});
            // 
            // grvStep
            // 
            this.grvStep.ColumnPanelRowHeight = 40;
            this.grvStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAddress,
            this.colInstruction,
            this.colStepKey,
            this.colProgram,
            this.colStepRole,
            this.colStepIndex});
            this.grvStep.GridControl = this.grdStep;
            this.grvStep.IndicatorWidth = 40;
            this.grvStep.Name = "grvStep";
            this.grvStep.OptionsBehavior.Editable = false;
            this.grvStep.OptionsBehavior.ReadOnly = true;
            this.grvStep.OptionsDetail.AllowZoomDetail = false;
            this.grvStep.OptionsDetail.EnableMasterViewMode = false;
            this.grvStep.OptionsDetail.SmartDetailExpand = false;
            this.grvStep.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvStep.OptionsView.ShowGroupPanel = false;
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
            // colStepKey
            // 
            this.colStepKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepKey.Caption = "StepKey";
            this.colStepKey.FieldName = "StepKey";
            this.colStepKey.Name = "colStepKey";
            // 
            // colProgram
            // 
            this.colProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.Caption = "File";
            this.colProgram.FieldName = "Program";
            this.colProgram.Name = "colProgram";
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 2;
            // 
            // colStepRole
            // 
            this.colStepRole.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepRole.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepRole.Caption = "Step Role";
            this.colStepRole.FieldName = "RoleType";
            this.colStepRole.Name = "colStepRole";
            this.colStepRole.Visible = true;
            this.colStepRole.VisibleIndex = 4;
            // 
            // colStepIndex
            // 
            this.colStepIndex.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepIndex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepIndex.Caption = "Step Index";
            this.colStepIndex.FieldName = "StepIndex";
            this.colStepIndex.Name = "colStepIndex";
            this.colStepIndex.Visible = true;
            this.colStepIndex.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 268);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(784, 52);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(703, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.BackColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseBackColor = true;
            this.btnOK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(0, 0);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 52);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.grvStep_DoubleClick);
            // 
            // FrmStepSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 320);
            this.Controls.Add(this.grdStep);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStepSelector";
            this.Text = "Step Selector";
            this.Load += new System.EventHandler(this.FrmStepSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStep;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStep;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colInstruction;
        private DevExpress.XtraGrid.Columns.GridColumn colStepKey;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn colStepRole;
        private DevExpress.XtraGrid.Columns.GridColumn colStepIndex;
    }
}