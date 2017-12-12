namespace UDM.TEST
{
    partial class FormModelTree
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
            this.button_Import_PLC = new System.Windows.Forms.Button();
            this.ucDevTree = new UDM.UI.DevTree.UCDevTree();
            this.ucGrid = new UDM.UI.DevGrid.UCGrid();
            this.SuspendLayout();
            // 
            // button_Import_PLC
            // 
            this.button_Import_PLC.Location = new System.Drawing.Point(12, 12);
            this.button_Import_PLC.Name = "button_Import_PLC";
            this.button_Import_PLC.Size = new System.Drawing.Size(128, 37);
            this.button_Import_PLC.TabIndex = 0;
            this.button_Import_PLC.Text = "Import PLC";
            this.button_Import_PLC.UseVisualStyleBackColor = true;
            this.button_Import_PLC.Click += new System.EventHandler(this.button_Import_PLC_Click);
            // 
            // ucDevTree
            // 
            this.ucDevTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDevTree.Editable = false;
            this.ucDevTree.Location = new System.Drawing.Point(12, 55);
            this.ucDevTree.Name = "ucDevTree";
            this.ucDevTree.Project = null;
            this.ucDevTree.Size = new System.Drawing.Size(301, 463);
            this.ucDevTree.TabIndex = 2;
            // 
            // ucGrid
            // 
            this.ucGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucGrid.DataSource = null;
            this.ucGrid.Location = new System.Drawing.Point(319, 55);
            this.ucGrid.Name = "ucGrid";
            this.ucGrid.Size = new System.Drawing.Size(469, 463);
            this.ucGrid.TabIndex = 1;
            // 
            // FormModelTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.ucDevTree);
            this.Controls.Add(this.ucGrid);
            this.Controls.Add(this.button_Import_PLC);
            this.Name = "FormModelTree";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Import_PLC;
        private UI.DevGrid.UCGrid ucGrid;
        private UI.DevTree.UCDevTree ucDevTree;

    }
}

