namespace UDMLadderTracker
{
    partial class UCErrorCauseAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCErrorCauseAnalysis));
            this.grpError = new DevExpress.XtraEditors.GroupControl();
            this.grdCauseTag = new DevExpress.XtraGrid.GridControl();
            this.grvCauseTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStepRoleS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorStepRoleS = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.pnlHide = new DevExpress.XtraEditors.PanelControl();
            this.btnHide = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpError)).BeginInit();
            this.grpError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCauseTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCauseTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHide)).BeginInit();
            this.pnlHide.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpError
            // 
            this.grpError.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpError.AppearanceCaption.Options.UseFont = true;
            this.grpError.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grpError.CaptionImage")));
            this.grpError.Controls.Add(this.grdCauseTag);
            this.grpError.Controls.Add(this.pnlHide);
            this.grpError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpError.Location = new System.Drawing.Point(0, 0);
            this.grpError.Name = "grpError";
            this.grpError.Size = new System.Drawing.Size(404, 472);
            this.grpError.TabIndex = 0;
            this.grpError.Text = "에러 원인 리스트";
            // 
            // grdCauseTag
            // 
            this.grdCauseTag.AllowDrop = true;
            this.grdCauseTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCauseTag.Location = new System.Drawing.Point(2, 39);
            this.grdCauseTag.MainView = this.grvCauseTag;
            this.grdCauseTag.Name = "grdCauseTag";
            this.grdCauseTag.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorStepRoleS});
            this.grdCauseTag.Size = new System.Drawing.Size(400, 397);
            this.grdCauseTag.TabIndex = 6;
            this.grdCauseTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCauseTag});
            // 
            // grvCauseTag
            // 
            this.grvCauseTag.ColumnPanelRowHeight = 30;
            this.grvCauseTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colDescription,
            this.colStepRoleS});
            this.grvCauseTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvCauseTag.GridControl = this.grdCauseTag;
            this.grvCauseTag.Name = "grvCauseTag";
            this.grvCauseTag.OptionsBehavior.Editable = false;
            this.grvCauseTag.OptionsBehavior.ReadOnly = true;
            this.grvCauseTag.OptionsDetail.EnableMasterViewMode = false;
            this.grvCauseTag.OptionsDetail.ShowDetailTabs = false;
            this.grvCauseTag.OptionsDetail.SmartDetailExpand = false;
            this.grvCauseTag.OptionsView.ShowGroupPanel = false;
            this.grvCauseTag.OptionsView.ShowIndicator = false;
            this.grvCauseTag.RowHeight = 40;
            this.grvCauseTag.DoubleClick += new System.EventHandler(this.grvCauseTag_DoubleClick);
            // 
            // colKey
            // 
            this.colKey.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKey.AppearanceCell.Options.UseFont = true;
            this.colKey.AppearanceCell.Options.UseTextOptions = true;
            this.colKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colKey.AppearanceHeader.Options.UseFont = true;
            this.colKey.AppearanceHeader.Options.UseTextOptions = true;
            this.colKey.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 114;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceCell.Options.UseFont = true;
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 161;
            // 
            // colStepRoleS
            // 
            this.colStepRoleS.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStepRoleS.AppearanceCell.Options.UseFont = true;
            this.colStepRoleS.AppearanceCell.Options.UseTextOptions = true;
            this.colStepRoleS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepRoleS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStepRoleS.AppearanceHeader.Options.UseFont = true;
            this.colStepRoleS.AppearanceHeader.Options.UseTextOptions = true;
            this.colStepRoleS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStepRoleS.Caption = "StepRoleS";
            this.colStepRoleS.ColumnEdit = this.exEditorStepRoleS;
            this.colStepRoleS.FieldName = "StepRoleS";
            this.colStepRoleS.Name = "colStepRoleS";
            this.colStepRoleS.Width = 125;
            // 
            // exEditorStepRoleS
            // 
            this.exEditorStepRoleS.AutoHeight = false;
            this.exEditorStepRoleS.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorStepRoleS.Name = "exEditorStepRoleS";
            // 
            // pnlHide
            // 
            this.pnlHide.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlHide.Appearance.Options.UseBackColor = true;
            this.pnlHide.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlHide.Controls.Add(this.btnHide);
            this.pnlHide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHide.Location = new System.Drawing.Point(2, 436);
            this.pnlHide.Name = "pnlHide";
            this.pnlHide.Size = new System.Drawing.Size(400, 34);
            this.pnlHide.TabIndex = 7;
            // 
            // btnHide
            // 
            this.btnHide.Appearance.BackColor = System.Drawing.Color.White;
            this.btnHide.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Appearance.Options.UseBackColor = true;
            this.btnHide.Appearance.Options.UseFont = true;
            this.btnHide.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHide.Location = new System.Drawing.Point(317, 2);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(81, 30);
            this.btnHide.TabIndex = 0;
            this.btnHide.Text = "Hide";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // UCErrorCauseAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpError);
            this.Name = "UCErrorCauseAnalysis";
            this.Size = new System.Drawing.Size(404, 472);
            ((System.ComponentModel.ISupportInitialize)(this.grpError)).EndInit();
            this.grpError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCauseTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCauseTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorStepRoleS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHide)).EndInit();
            this.pnlHide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpError;
        private DevExpress.XtraGrid.GridControl grdCauseTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCauseTag;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colStepRoleS;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox exEditorStepRoleS;
        private DevExpress.XtraEditors.PanelControl pnlHide;
        private DevExpress.XtraEditors.SimpleButton btnHide;
    }
}
