namespace NewIOMaker.Form.Form_MultiCopy
{
    partial class MCOP
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
            this.MCspliter = new DevExpress.XtraEditors.SplitContainerControl();
            this.DragGroup = new DevExpress.XtraEditors.GroupControl();
            this.MClistBox = new System.Windows.Forms.ListBox();
            this.FileViewGroup = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.MCspliter)).BeginInit();
            this.MCspliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragGroup)).BeginInit();
            this.DragGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileViewGroup)).BeginInit();
            this.FileViewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // MCspliter
            // 
            this.MCspliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MCspliter.Horizontal = false;
            this.MCspliter.Location = new System.Drawing.Point(0, 0);
            this.MCspliter.Name = "MCspliter";
            this.MCspliter.Panel1.Controls.Add(this.DragGroup);
            this.MCspliter.Panel1.Text = "Panel1";
            this.MCspliter.Panel2.Controls.Add(this.FileViewGroup);
            this.MCspliter.Panel2.Text = "Panel2";
            this.MCspliter.Size = new System.Drawing.Size(725, 530);
            this.MCspliter.SplitterPosition = 98;
            this.MCspliter.TabIndex = 0;
            this.MCspliter.Text = "splitContainerControl1";
            // 
            // DragGroup
            // 
            this.DragGroup.Controls.Add(this.MClistBox);
            this.DragGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DragGroup.Location = new System.Drawing.Point(0, 0);
            this.DragGroup.Name = "DragGroup";
            this.DragGroup.Size = new System.Drawing.Size(725, 98);
            this.DragGroup.TabIndex = 0;
            this.DragGroup.Text = "Drag and Drop ";
            // 
            // MClistBox
            // 
            this.MClistBox.AllowDrop = true;
            this.MClistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MClistBox.FormattingEnabled = true;
            this.MClistBox.ItemHeight = 14;
            this.MClistBox.Items.AddRange(new object[] {
            "Key Using : Right Alt  :  Previous    Right Ctrl : Forward"});
            this.MClistBox.Location = new System.Drawing.Point(2, 21);
            this.MClistBox.Name = "MClistBox";
            this.MClistBox.Size = new System.Drawing.Size(721, 75);
            this.MClistBox.TabIndex = 2;
            this.MClistBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.MClistBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            // 
            // FileViewGroup
            // 
            this.FileViewGroup.Controls.Add(this.xtraTabControl1);
            this.FileViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileViewGroup.Location = new System.Drawing.Point(0, 0);
            this.FileViewGroup.Name = "FileViewGroup";
            this.FileViewGroup.Size = new System.Drawing.Size(725, 420);
            this.FileViewGroup.TabIndex = 0;
            this.FileViewGroup.Text = "Selected Key :    ";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 21);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Size = new System.Drawing.Size(721, 397);
            this.xtraTabControl1.TabIndex = 0;
            // 
            // MCOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MCspliter);
            this.Name = "MCOP";
            this.Size = new System.Drawing.Size(725, 530);
            ((System.ComponentModel.ISupportInitialize)(this.MCspliter)).EndInit();
            this.MCspliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DragGroup)).EndInit();
            this.DragGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileViewGroup)).EndInit();
            this.FileViewGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl MCspliter;
        private DevExpress.XtraEditors.GroupControl DragGroup;
        private System.Windows.Forms.ListBox MClistBox;
        private DevExpress.XtraEditors.GroupControl FileViewGroup;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    }
}
