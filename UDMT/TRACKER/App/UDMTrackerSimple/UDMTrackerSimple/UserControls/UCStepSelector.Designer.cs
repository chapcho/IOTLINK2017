namespace UDMTrackerSimple
{
    partial class UCStepSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStepSelector));
            this.grdStep = new DevExpress.XtraGrid.GridControl();
            this.grvStep = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.exEditorImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgList = new DevExpress.Utils.ImageCollection(this.components);
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoilAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoilDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoleType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdStep
            // 
            this.grdStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStep.Location = new System.Drawing.Point(0, 0);
            this.grdStep.MainView = this.grvStep;
            this.grdStep.Name = "grdStep";
            this.grdStep.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.exEditorImage});
            this.grdStep.Size = new System.Drawing.Size(626, 307);
            this.grdStep.TabIndex = 0;
            this.grdStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStep});
            // 
            // grvStep
            // 
            this.grvStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgram,
            this.colRole,
            this.colAddress,
            this.colCoilAddress,
            this.colCoilDesc,
            this.colRoleType});
            this.grvStep.GridControl = this.grdStep;
            this.grvStep.Name = "grvStep";
            this.grvStep.OptionsBehavior.Editable = false;
            this.grvStep.OptionsBehavior.ReadOnly = true;
            this.grvStep.OptionsDetail.EnableMasterViewMode = false;
            this.grvStep.OptionsDetail.ShowDetailTabs = false;
            this.grvStep.OptionsDetail.SmartDetailExpand = false;
            this.grvStep.OptionsView.ShowGroupPanel = false;
            this.grvStep.RowHeight = 30;
            this.grvStep.DoubleClick += new System.EventHandler(this.grvStep_DoubleClick);
            // 
            // colProgram
            // 
            this.colProgram.AppearanceCell.Options.UseTextOptions = true;
            this.colProgram.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.AppearanceHeader.Options.UseTextOptions = true;
            this.colProgram.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProgram.Caption = "프로그램";
            this.colProgram.FieldName = "Program";
            this.colProgram.Name = "colProgram";
            this.colProgram.Visible = true;
            this.colProgram.VisibleIndex = 0;
            this.colProgram.Width = 139;
            // 
            // colRole
            // 
            this.colRole.AppearanceCell.Options.UseTextOptions = true;
            this.colRole.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRole.AppearanceHeader.Options.UseTextOptions = true;
            this.colRole.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRole.Caption = "역할";
            this.colRole.ColumnEdit = this.exEditorImage;
            this.colRole.FieldName = "ImageIndex";
            this.colRole.MaxWidth = 60;
            this.colRole.MinWidth = 60;
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 1;
            this.colRole.Width = 60;
            // 
            // exEditorImage
            // 
            this.exEditorImage.AutoHeight = false;
            this.exEditorImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.exEditorImage.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.exEditorImage.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 3, 3)});
            this.exEditorImage.LargeImages = this.imgList;
            this.exEditorImage.Name = "exEditorImage";
            // 
            // imgList
            // 
            this.imgList.ImageSize = new System.Drawing.Size(32, 26);
            this.imgList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.Images.SetKeyName(0, "A접점.png");
            this.imgList.Images.SetKeyName(1, "B접점.png");
            this.imgList.Images.SetKeyName(2, "출력접점.png");
            this.imgList.Images.SetKeyName(3, "변수접점.png");
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "주소";
            this.colAddress.FieldName = "Address";
            this.colAddress.MaxWidth = 100;
            this.colAddress.MinWidth = 80;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 92;
            // 
            // colCoilAddress
            // 
            this.colCoilAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colCoilAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoilAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoilAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoilAddress.Caption = "코일 주소";
            this.colCoilAddress.FieldName = "CoilAddress";
            this.colCoilAddress.MaxWidth = 90;
            this.colCoilAddress.MinWidth = 80;
            this.colCoilAddress.Name = "colCoilAddress";
            this.colCoilAddress.Visible = true;
            this.colCoilAddress.VisibleIndex = 3;
            this.colCoilAddress.Width = 80;
            // 
            // colCoilDesc
            // 
            this.colCoilDesc.AppearanceHeader.Options.UseTextOptions = true;
            this.colCoilDesc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCoilDesc.Caption = "코일 설명";
            this.colCoilDesc.FieldName = "CoilDesc";
            this.colCoilDesc.Name = "colCoilDesc";
            this.colCoilDesc.Visible = true;
            this.colCoilDesc.VisibleIndex = 4;
            this.colCoilDesc.Width = 242;
            // 
            // colRoleType
            // 
            this.colRoleType.Caption = "StepRole";
            this.colRoleType.FieldName = "EMStepRole";
            this.colRoleType.Name = "colRoleType";
            // 
            // UCStepSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdStep);
            this.Name = "UCStepSelector";
            this.Size = new System.Drawing.Size(626, 307);
            ((System.ComponentModel.ISupportInitialize)(this.grdStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEditorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdStep;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStep;
        private DevExpress.XtraGrid.Columns.GridColumn colProgram;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCoilAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colCoilDesc;
        private DevExpress.XtraGrid.Columns.GridColumn colRoleType;
        private DevExpress.Utils.ImageCollection imgList;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox exEditorImage;
    }
}
