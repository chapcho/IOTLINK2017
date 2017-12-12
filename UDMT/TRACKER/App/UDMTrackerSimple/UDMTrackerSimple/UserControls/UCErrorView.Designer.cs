namespace UDMTrackerSimple
{
    partial class UCErrorView
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
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.widgetError = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            this.docErrorDetail = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.rowDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.columnDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErrorDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).BeginInit();
            this.SuspendLayout();
            // 
            // docManager
            // 
            this.docManager.ContainerControl = this;
            this.docManager.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.docManager.View = this.widgetError;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetError});
            // 
            // widgetError
            // 
            this.widgetError.AllowStartupAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.widgetError.AppearanceActiveDocumentCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widgetError.AppearanceActiveDocumentCaption.Options.UseFont = true;
            this.widgetError.AppearanceDocumentCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widgetError.AppearanceDocumentCaption.Options.UseFont = true;
            this.widgetError.Columns.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition[] {
            this.columnDefinition1});
            this.widgetError.DocumentProperties.AllowClose = false;
            this.widgetError.DocumentProperties.AllowFloat = false;
            this.widgetError.DocumentProperties.AllowResize = false;
            this.widgetError.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.docErrorDetail});
            this.widgetError.LayoutMode = DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.TableLayout;
            this.widgetError.Rows.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition[] {
            this.rowDefinition1});
            this.widgetError.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.widgetError_QueryControl);
            // 
            // docErrorDetail
            // 
            this.docErrorDetail.Caption = "Error Detail";
            this.docErrorDetail.ControlName = "ucErrorDetail";
            this.docErrorDetail.ControlTypeName = "UDMTrackerSimple.UCErrorDetail";
            this.docErrorDetail.Properties.ShowBorders = DevExpress.Utils.DefaultBoolean.False;
            // 
            // columnDefinition1
            // 
            this.columnDefinition1.Length.UnitValue = 0.8D;
            // 
            // UCErrorView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCErrorView";
            this.Size = new System.Drawing.Size(963, 625);
            this.Load += new System.EventHandler(this.UCErrorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docErrorDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetError;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document docErrorDetail;
        private DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition rowDefinition1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition1;

    }
}
