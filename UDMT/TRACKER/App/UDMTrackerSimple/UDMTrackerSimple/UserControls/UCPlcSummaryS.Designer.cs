namespace UDMTrackerSimple
{
    partial class UCPlcSummaryS
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
            this.tabView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).BeginInit();
            this.SuspendLayout();
            // 
            // docManager
            // 
            this.docManager.ContainerControl = this;
            this.docManager.DocumentActivationScope = DevExpress.XtraBars.Docking2010.Views.DocumentActivationScope.DocumentsHost;
            this.docManager.View = this.tabView;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabView});
            // 
            // tabView
            // 
            this.tabView.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.Header.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.tabView.AppearancePage.HeaderSelected.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.HeaderSelected.Options.UseFont = true;
            this.tabView.AppearancePage.PageClient.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabView.AppearancePage.PageClient.Options.UseFont = true;
            this.tabView.DocumentGroupProperties.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.tabView.DocumentProperties.ShowPinButton = false;
            this.tabView.FloatingDocumentContainer = DevExpress.XtraBars.Docking2010.Views.FloatingDocumentContainer.DocumentsHost;
            this.tabView.BeginDocumentsHostDocking += new DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventHandler(this.tabView_BeginDocumentsHostDocking);
            this.tabView.EndDocumentsHostDocking += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.tabView_EndDocumentsHostDocking);
            this.tabView.RegisterDocumentsHostWindow += new DevExpress.XtraBars.Docking2010.DocumentsHostWindowEventHandler(this.tabView_RegisterDocumentsHostWindow);
            this.tabView.UnregisterDocumentsHostWindow += new DevExpress.XtraBars.Docking2010.DocumentsHostWindowEventHandler(this.tabView_UnregisterDocumentsHostWindow);
            // 
            // UCPlcSummaryS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCPlcSummaryS";
            this.Size = new System.Drawing.Size(449, 388);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabView;

    }
}
