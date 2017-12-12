namespace NewIOMaker.Form.Form_TagGenerator
{
    partial class TagGridLog
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
            this.exGridLog = new DevExpress.XtraGrid.GridControl();
            this.exGridViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.exGridLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // exGridLog
            // 
            this.exGridLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGridLog.Location = new System.Drawing.Point(0, 0);
            this.exGridLog.MainView = this.exGridViewLog;
            this.exGridLog.Name = "exGridLog";
            this.exGridLog.Size = new System.Drawing.Size(753, 512);
            this.exGridLog.TabIndex = 0;
            this.exGridLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.exGridViewLog});
            // 
            // exGridViewLog
            // 
            this.exGridViewLog.GridControl = this.exGridLog;
            this.exGridViewLog.Name = "exGridViewLog";
            // 
            // Control_Tag_Grid_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exGridLog);
            this.Name = "Control_Tag_Grid_Log";
            this.Size = new System.Drawing.Size(753, 512);
            ((System.ComponentModel.ISupportInitialize)(this.exGridLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exGridViewLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl exGridLog;
        private DevExpress.XtraGrid.Views.Grid.GridView exGridViewLog;
    }
}
