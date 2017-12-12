namespace UDM.Ladder
{
    partial class FrmLadderDiagram
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
            this.ucLadderStep = new UDM.Ladder.UCLadderStep();
            this.SuspendLayout();
            // 
            // ucLadderStep
            // 
            this.ucLadderStep.AutoSizeParent = true;
            this.ucLadderStep.Brand = UDM.Ladder.EditorBrand.MELSEC;
            this.ucLadderStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLadderStep.Location = new System.Drawing.Point(0, 0);
            this.ucLadderStep.Name = "ucLadderStep";
            this.ucLadderStep.ScaleDefault = 1F;
            this.ucLadderStep.Size = new System.Drawing.Size(657, 412);
            this.ucLadderStep.Step = null;
            this.ucLadderStep.SymbolLogS = null;
            this.ucLadderStep.TabIndex = 0;
            // 
            // FrmLadderDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 412);
            this.Controls.Add(this.ucLadderStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmLadderDiagram";
            this.Text = "Ladder Step";
            this.ResumeLayout(false);

        }

        #endregion

        private UCLadderStep ucLadderStep;
    }
}