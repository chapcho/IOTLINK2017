namespace UDMTrackerSimple
{
    partial class FrmUpdateResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateResult));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.exGridMain = new DevExpress.XtraGrid.GridControl();
            this.exGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorResult = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgList = new DevExpress.Utils.ImageCollection(this.components);
            this.colSender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnApply);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 358);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(641, 51);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(507, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 51);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "업데이트 취소";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // exGridMain
            // 
            this.exGridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridMain.Location = new System.Drawing.Point(0, 0);
            this.exGridMain.MainView = this.exGridView;
            this.exGridMain.Name = "exGridMain";
            this.exGridMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorResult});
            this.exGridMain.Size = new System.Drawing.Size(641, 358);
            this.exGridMain.TabIndex = 3;
            this.exGridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridView});
            // 
            // exGridView
            // 
            this.exGridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Transparent;
            this.exGridView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.exGridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.exGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResult,
            this.colSender,
            this.colMessage});
            this.exGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.exGridView.GridControl = this.exGridMain;
            this.exGridView.IndicatorWidth = 40;
            this.exGridView.Name = "exGridView";
            this.exGridView.OptionsBehavior.Editable = false;
            this.exGridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.exGridView.OptionsBehavior.ReadOnly = true;
            this.exGridView.OptionsDetail.EnableMasterViewMode = false;
            this.exGridView.OptionsDetail.ShowDetailTabs = false;
            this.exGridView.OptionsDetail.SmartDetailExpand = false;
            this.exGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.exGridView.OptionsView.ShowGroupPanel = false;
            this.exGridView.RowHeight = 30;
            this.exGridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.exGridView_CustomDrawRowIndicator);
            // 
            // colResult
            // 
            this.colResult.AppearanceCell.Options.UseTextOptions = true;
            this.colResult.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult.AppearanceHeader.Options.UseTextOptions = true;
            this.colResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colResult.Caption = "Result";
            this.colResult.ColumnEdit = this.exEditorResult;
            this.colResult.FieldName = "ImageIndex";
            this.colResult.MaxWidth = 70;
            this.colResult.MinWidth = 70;
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 0;
            this.colResult.Width = 70;
            // 
            // exEditorResult
            // 
            this.exEditorResult.AutoHeight = false;
            this.exEditorResult.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorResult.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("성공", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("실패", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("정보", 2, 2)});
            this.exEditorResult.Name = "exEditorResult";
            this.exEditorResult.SmallImages = this.imgList;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.Images.SetKeyName(0, "Apply_16x16.png");
            this.imgList.Images.SetKeyName(1, "Cancel_16x16.png");
            this.imgList.Images.SetKeyName(2, "Info_16x16.png");
            // 
            // colSender
            // 
            this.colSender.AppearanceCell.Options.UseTextOptions = true;
            this.colSender.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSender.AppearanceHeader.Options.UseTextOptions = true;
            this.colSender.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSender.Caption = "Sender";
            this.colSender.FieldName = "Sender";
            this.colSender.Name = "colSender";
            this.colSender.Visible = true;
            this.colSender.VisibleIndex = 1;
            this.colSender.Width = 138;
            // 
            // colMessage
            // 
            this.colMessage.AppearanceHeader.Options.UseTextOptions = true;
            this.colMessage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMessage.Caption = "Message";
            this.colMessage.FieldName = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.Visible = true;
            this.colMessage.VisibleIndex = 2;
            this.colMessage.Width = 391;
            // 
            // btnApply
            // 
            this.btnApply.Appearance.BackColor = System.Drawing.Color.White;
            this.btnApply.Appearance.Options.UseBackColor = true;
            this.btnApply.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.Location = new System.Drawing.Point(373, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(134, 51);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "업데이트 적용";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // FrmUpdateResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 409);
            this.Controls.Add(this.exGridMain);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateResult";
            this.Text = "PLC 프로그램 업데이트 결과 창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUpdateResult_FormClosing);
            this.Load += new System.EventHandler(this.FrmUpdateResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exGridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl exGridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox exEditorResult;
        private DevExpress.Utils.ImageCollection imgList;
        private DevExpress.XtraGrid.Columns.GridColumn colSender;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnApply;
    }
}