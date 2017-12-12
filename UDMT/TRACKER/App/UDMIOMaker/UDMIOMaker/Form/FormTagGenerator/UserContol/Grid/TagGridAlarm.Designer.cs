namespace NewIOMaker.Form.Form_TagGenerator
{
    partial class TagGridAlarm
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
            this.exGridAlarm = new DevExpress.XtraGrid.GridControl();
            this.exGridViewAlarm = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.exGridAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridAlarm
            // 
            this.exGridAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridAlarm.Location = new System.Drawing.Point(0, 0);
            this.exGridAlarm.MainView = this.exGridViewAlarm;
            this.exGridAlarm.Name = "exGridAlarm";
            this.exGridAlarm.Size = new System.Drawing.Size(834, 512);
            this.exGridAlarm.TabIndex = 0;
            this.exGridAlarm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewAlarm});
            // 
            // exGridViewAlarm
            // 
            this.exGridViewAlarm.GridControl = this.exGridAlarm;
            this.exGridViewAlarm.Name = "exGridViewAlarm";
            // 
            // Control_Tag_Grid_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridAlarm);
            this.Name = "Control_Tag_Grid_Alarm";
            this.Size = new System.Drawing.Size(834, 512);
            ((System.ComponentModel.ISupportInitialize)(this.exGridAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridAlarm;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewAlarm;
    }
}
