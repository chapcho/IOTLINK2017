namespace UDMIOMaker
{
    partial class UCIOModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCIOModule));
            this.exTreeList = new DevExpress.XtraTreeList.TreeList();
            this.colAddressRange = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colInput = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOutput = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModuleName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // exTreeList
            // 
            this.exTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colAddressRange,
            this.colInput,
            this.colOutput,
            this.colDescription,
            this.colModuleName});
            this.exTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exTreeList.Location = new System.Drawing.Point(0, 0);
            this.exTreeList.Name = "exTreeList";
            this.exTreeList.OptionsBehavior.Editable = false;
            this.exTreeList.OptionsBehavior.ReadOnly = true;
            this.exTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.exTreeList.OptionsView.ShowIndicator = false;
            this.exTreeList.SelectImageList = this.imgList;
            this.exTreeList.Size = new System.Drawing.Size(575, 474);
            this.exTreeList.TabIndex = 0;
            this.exTreeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.exTreeList_NodeCellStyle);
            // 
            // colAddressRange
            // 
            this.colAddressRange.AppearanceCell.Options.UseTextOptions = true;
            this.colAddressRange.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressRange.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colAddressRange.AppearanceHeader.Options.UseFont = true;
            this.colAddressRange.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddressRange.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddressRange.Caption = "Address 영역";
            this.colAddressRange.FieldName = "Address 영역";
            this.colAddressRange.MinWidth = 120;
            this.colAddressRange.Name = "colAddressRange";
            this.colAddressRange.OptionsColumn.FixedWidth = true;
            this.colAddressRange.Visible = true;
            this.colAddressRange.VisibleIndex = 0;
            this.colAddressRange.Width = 120;
            // 
            // colInput
            // 
            this.colInput.AppearanceCell.ForeColor = System.Drawing.Color.Transparent;
            this.colInput.AppearanceCell.Options.UseForeColor = true;
            this.colInput.AppearanceCell.Options.UseTextOptions = true;
            this.colInput.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInput.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colInput.AppearanceHeader.Options.UseFont = true;
            this.colInput.AppearanceHeader.Options.UseTextOptions = true;
            this.colInput.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInput.Caption = "I";
            this.colInput.FieldName = "Input";
            this.colInput.Name = "colInput";
            this.colInput.OptionsColumn.FixedWidth = true;
            this.colInput.Visible = true;
            this.colInput.VisibleIndex = 1;
            this.colInput.Width = 20;
            // 
            // colOutput
            // 
            this.colOutput.AppearanceCell.ForeColor = System.Drawing.Color.Transparent;
            this.colOutput.AppearanceCell.Options.UseForeColor = true;
            this.colOutput.AppearanceCell.Options.UseTextOptions = true;
            this.colOutput.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutput.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colOutput.AppearanceHeader.Options.UseFont = true;
            this.colOutput.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutput.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutput.Caption = "O";
            this.colOutput.FieldName = "Output";
            this.colOutput.Name = "colOutput";
            this.colOutput.OptionsColumn.FixedWidth = true;
            this.colOutput.Visible = true;
            this.colOutput.VisibleIndex = 2;
            this.colOutput.Width = 20;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colDescription.AppearanceHeader.Options.UseFont = true;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "설명";
            this.colDescription.FieldName = "설명";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 136;
            // 
            // colModuleName
            // 
            this.colModuleName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colModuleName.AppearanceHeader.Options.UseFont = true;
            this.colModuleName.AppearanceHeader.Options.UseTextOptions = true;
            this.colModuleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleName.Caption = "모듈 이름";
            this.colModuleName.FieldName = "모듈 이름";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 4;
            this.colModuleName.Width = 136;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "AlignHorizontalTop_16x16.png");
            this.imgList.Images.SetKeyName(1, "Open_16x16.png");
            this.imgList.Images.SetKeyName(2, "green_bullet__16x16.png");
            this.imgList.Images.SetKeyName(3, "ContentArrangeInRows_16x16.png");
            // 
            // UCIOModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exTreeList);
            this.Name = "UCIOModule";
            this.Size = new System.Drawing.Size(575, 474);
            ((System.ComponentModel.ISupportInitialize)(this.exTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList exTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddressRange;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModuleName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOutput;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colInput;
    }
}
