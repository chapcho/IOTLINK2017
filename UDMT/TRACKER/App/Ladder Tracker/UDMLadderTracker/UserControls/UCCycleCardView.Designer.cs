namespace UDMTrackerSimple
{
    partial class UCCycleCardView
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
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).BeginInit();
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
            this.widgetView.AllowStartupAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.widgetView.DocumentProperties.AllowClose = false;
            this.widgetView.DocumentProperties.AllowFloat = false;
            this.widgetView.DocumentProperties.AllowMaximize = false;
            this.widgetView.DocumentProperties.AllowResize = false;
            this.widgetView.StackGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup[] {
            this.stackGroup1,
            this.stackGroup2,
            this.stackGroup3});
            this.widgetView.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.widgetView_QueryControl);
            // 
            // stackGroup1
            // 
            this.stackGroup1.Length.UnitType = DevExpress.XtraBars.Docking2010.Views.Widget.LengthUnitType.Pixel;
            this.stackGroup1.Length.UnitValue = 355D;
            // 
            // stackGroup2
            // 
            this.stackGroup2.Length.UnitType = DevExpress.XtraBars.Docking2010.Views.Widget.LengthUnitType.Pixel;
            this.stackGroup2.Length.UnitValue = 355D;
            // 
            // stackGroup3
            // 
            this.stackGroup3.Length.UnitType = DevExpress.XtraBars.Docking2010.Views.Widget.LengthUnitType.Pixel;
            this.stackGroup3.Length.UnitValue = 355D;
            // 
            // UCCycleCardView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "UCCycleCardView";
            this.Size = new System.Drawing.Size(1085, 600);
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup2;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup3;
    }
}
