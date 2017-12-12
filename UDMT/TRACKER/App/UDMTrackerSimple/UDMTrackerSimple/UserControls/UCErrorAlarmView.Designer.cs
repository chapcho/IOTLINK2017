namespace UDMTrackerSimple
{
    partial class UCErrorAlarmView
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
            this.widgetView = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            this.stackGroup1 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup2 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup3 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup4 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup4)).BeginInit();
            this.SuspendLayout();
            // 
            // docManager
            // 
            this.docManager.ContainerControl = this;
            this.docManager.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.docManager.View = this.widgetView;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetView});
            // 
            // widgetView
            // 
            this.widgetView.Appearance.BackColor = System.Drawing.Color.White;
            this.widgetView.Appearance.Options.UseBackColor = true;
            this.widgetView.DocumentProperties.AllowClose = false;
            this.widgetView.DocumentProperties.AllowDock = false;
            this.widgetView.DocumentProperties.AllowFloat = false;
            this.widgetView.DocumentProperties.AllowMaximize = false;
            this.widgetView.DocumentProperties.AllowResize = false;
            this.widgetView.DocumentProperties.ShowBorders = false;
            this.widgetView.DocumentProperties.ShowMaximizeButton = false;
            this.widgetView.StackGroupProperties.Capacity = 4;
            this.widgetView.StackGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup[] {
            this.stackGroup1,
            this.stackGroup2,
            this.stackGroup3,
            this.stackGroup4});
            this.widgetView.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.False;
            // 
            // UCErrorAlarmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "UCErrorAlarmView";
            this.Size = new System.Drawing.Size(786, 438);
            this.Load += new System.EventHandler(this.UCErrorAlarmView_Resize);
            this.Resize += new System.EventHandler(this.UCErrorAlarmView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup2;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup3;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup4;

    }
}
