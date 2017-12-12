namespace UDMOptimizer
{
    partial class FrmStepSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStepSelector));
            this.ucStepTable = new UDMOptimizer.UCStepTable();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucStepTable
            // 
            this.ucStepTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStepTable.Location = new System.Drawing.Point(0, 0);
            this.ucStepTable.Name = "ucStepTable";
            this.ucStepTable.Size = new System.Drawing.Size(426, 494);
            this.ucStepTable.StepList = null;
            this.ucStepTable.TabIndex = 0;
            this.ucStepTable.UEventStepTableDoulbeClicked += new UDMOptimizer.UEventHandlerStepTableDoubleClicked(this.ucStepTable_UEventStepTableDoulbeClicked);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Controls.Add(this.btnOK);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 494);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Padding = new System.Windows.Forms.Padding(3);
            this.pnlControl.Size = new System.Drawing.Size(426, 30);
            this.pnlControl.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(353, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmStepSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 524);
            this.Controls.Add(this.ucStepTable);
            this.Controls.Add(this.pnlControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStepSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Step Selector";
            this.Load += new System.EventHandler(this.FrmStepSelector_Load);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCStepTable ucStepTable;
        private System.Windows.Forms.Panel pnlControl;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;

    }
}