namespace UDMPLCLogicAnalyzer
{
    partial class FrmCompareLogicImport
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
            this.grpLogicList = new DevExpress.XtraEditors.GroupControl();
            this.rdgLogicList = new DevExpress.XtraEditors.RadioGroup();
            this.grpFilePath = new DevExpress.XtraEditors.GroupControl();
            this.exPropertyView = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.exEditorFiles = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.rowProjectID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowAwlFilePath = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSdfFilePath = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogicList)).BeginInit();
            this.grpLogicList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgLogicList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilePath)).BeginInit();
            this.grpFilePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exPropertyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLogicList
            // 
            this.grpLogicList.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpLogicList.Appearance.Options.UseFont = true;
            this.grpLogicList.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpLogicList.AppearanceCaption.Options.UseFont = true;
            this.grpLogicList.Controls.Add(this.rdgLogicList);
            this.grpLogicList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLogicList.Location = new System.Drawing.Point(0, 0);
            this.grpLogicList.Name = "grpLogicList";
            this.grpLogicList.Size = new System.Drawing.Size(263, 227);
            this.grpLogicList.TabIndex = 0;
            this.grpLogicList.Text = "Logic List";
            // 
            // rdgLogicList
            // 
            this.rdgLogicList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdgLogicList.Location = new System.Drawing.Point(2, 26);
            this.rdgLogicList.Name = "rdgLogicList";
            this.rdgLogicList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rdgLogicList.Properties.Appearance.Options.UseFont = true;
            this.rdgLogicList.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rdgLogicList.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Blue;
            this.rdgLogicList.Properties.AppearanceFocused.Options.UseFont = true;
            this.rdgLogicList.Properties.AppearanceFocused.Options.UseForeColor = true;
            this.rdgLogicList.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "test")});
            this.rdgLogicList.Size = new System.Drawing.Size(259, 199);
            this.rdgLogicList.TabIndex = 0;
            this.rdgLogicList.SelectedIndexChanged += new System.EventHandler(this.rdgLogicList_SelectedIndexChanged);
            // 
            // grpFilePath
            // 
            this.grpFilePath.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpFilePath.Appearance.Options.UseFont = true;
            this.grpFilePath.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grpFilePath.AppearanceCaption.Options.UseFont = true;
            this.grpFilePath.Controls.Add(this.exPropertyView);
            this.grpFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilePath.Location = new System.Drawing.Point(263, 0);
            this.grpFilePath.Name = "grpFilePath";
            this.grpFilePath.Size = new System.Drawing.Size(808, 227);
            this.grpFilePath.TabIndex = 1;
            this.grpFilePath.Text = "Compare Logic File Path";
            // 
            // exPropertyView
            // 
            this.exPropertyView.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.exPropertyView.Appearance.RowHeaderPanel.Options.UseFont = true;
            this.exPropertyView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.exPropertyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exPropertyView.Location = new System.Drawing.Point(2, 26);
            this.exPropertyView.Name = "exPropertyView";
            this.exPropertyView.OptionsBehavior.Editable = false;
            this.exPropertyView.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.exPropertyView.OptionsBehavior.ResizeHeaderPanel = false;
            this.exPropertyView.OptionsBehavior.ResizeRowHeaders = false;
            this.exPropertyView.OptionsBehavior.ResizeRowValues = false;
            this.exPropertyView.OptionsView.FixRowHeaderPanelWidth = true;
            this.exPropertyView.OptionsView.ShowFocusedFrame = false;
            this.exPropertyView.Padding = new System.Windows.Forms.Padding(10);
            this.exPropertyView.RecordWidth = 160;
            this.exPropertyView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorFiles});
            this.exPropertyView.RowHeaderWidth = 40;
            this.exPropertyView.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowProjectID,
            this.rowAwlFilePath,
            this.rowSdfFilePath});
            this.exPropertyView.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowForFocusedRow;
            this.exPropertyView.Size = new System.Drawing.Size(804, 199);
            this.exPropertyView.TabIndex = 14;
            // 
            // exEditorFiles
            // 
            this.exEditorFiles.Name = "exEditorFiles";
            // 
            // rowProjectID
            // 
            this.rowProjectID.Height = 22;
            this.rowProjectID.Name = "rowProjectID";
            this.rowProjectID.Properties.Caption = "Project Name";
            this.rowProjectID.Properties.FieldName = "PlcName";
            this.rowProjectID.Properties.ReadOnly = true;
            // 
            // rowAwlFilePath
            // 
            this.rowAwlFilePath.Height = 22;
            this.rowAwlFilePath.Name = "rowAwlFilePath";
            this.rowAwlFilePath.Properties.Caption = "Logic File Path";
            this.rowAwlFilePath.Properties.FieldName = "LogicFilePath";
            this.rowAwlFilePath.Properties.ReadOnly = true;
            // 
            // rowSdfFilePath
            // 
            this.rowSdfFilePath.Height = 22;
            this.rowSdfFilePath.Name = "rowSdfFilePath";
            this.rowSdfFilePath.Properties.Caption = "Symbol File Path";
            this.rowSdfFilePath.Properties.FieldName = "SymbolFilePath";
            this.rowSdfFilePath.Properties.ReadOnly = true;
            // 
            // FrmCompareLogicImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 227);
            this.Controls.Add(this.grpFilePath);
            this.Controls.Add(this.grpLogicList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompareLogicImport";
            this.Text = "비교 Logic을 삽입한다.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCompareLogicImport_FormClosing);
            this.Load += new System.EventHandler(this.FrmCompareLogicImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogicList)).EndInit();
            this.grpLogicList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgLogicList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpFilePath)).EndInit();
            this.grpFilePath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exPropertyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpLogicList;
        private DevExpress.XtraEditors.RadioGroup rdgLogicList;
        private DevExpress.XtraEditors.GroupControl grpFilePath;
        private DevExpress.XtraVerticalGrid.PropertyGridControl exPropertyView;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit exEditorFiles;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowProjectID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowAwlFilePath;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSdfFilePath;
    }
}