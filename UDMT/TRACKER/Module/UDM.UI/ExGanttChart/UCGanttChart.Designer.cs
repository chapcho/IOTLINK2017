namespace UDM.UI.ExGanttChart
{
    partial class UCGanttChart
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
			this.exGant = new exontrol.EXG2ANTTLib.exg2antt();
			this.SuspendLayout();
			// 
			// exGant
			// 
			this.exGant.BackColorAlternate = System.Drawing.Color.Black;
			this.exGant.BackColorHeader = System.Drawing.SystemColors.Control;
			this.exGant.BackColorHeader32 = -2147483633;
			this.exGant.BackColorLevelHeader = System.Drawing.SystemColors.Control;
			this.exGant.BackColorLock = System.Drawing.SystemColors.Window;
			this.exGant.BackColorSortBar = System.Drawing.SystemColors.ControlDark;
			this.exGant.BackColorSortBar32 = -2147483632;
			this.exGant.BackColorSortBarCaption = System.Drawing.SystemColors.Control;
			this.exGant.BackColorSortBarCaption32 = -2147483633;
			this.exGant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.exGant.DefaultItemHeight = 18;
			this.exGant.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGant.FilterBarBackColor = System.Drawing.SystemColors.Control;
			this.exGant.FilterBarBackColor32 = -2147483633;
			this.exGant.FilterBarForeColor = System.Drawing.SystemColors.WindowText;
			this.exGant.ForeColorHeader = System.Drawing.SystemColors.WindowText;
			this.exGant.ForeColorLock = System.Drawing.SystemColors.WindowText;
			this.exGant.ForeColorSortBar = System.Drawing.SystemColors.ControlDark;
			this.exGant.GridLineColor = System.Drawing.SystemColors.ControlDark;
			this.exGant.HyperLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(101)))), ((int)(((byte)(255)))));
			this.exGant.Location = new System.Drawing.Point(0, 0);
			this.exGant.MarkSearchColumn = false;
			this.exGant.Name = "exGant";
			this.exGant.PictureLevelHeader = null;
			this.exGant.SelBackColor = System.Drawing.Color.PaleTurquoise;
			this.exGant.SelBackColor32 = 15658671;
			this.exGant.SelForeColor = System.Drawing.SystemColors.HighlightText;
			this.exGant.SingleSort = false;
			this.exGant.Size = new System.Drawing.Size(508, 315);
			this.exGant.SortBarHeight = 306;
			this.exGant.TabIndex = 2;
			this.exGant.TooltipCellsColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(101)))), ((int)(((byte)(255)))));
			this.exGant.InsideZoom += new exontrol.EXG2ANTTLib.exg2antt.InsideZoomEventHandler(this.exGant_InsideZoom);
			// 
			// UCGanttChart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.exGant);
			this.Name = "UCGanttChart";
			this.Size = new System.Drawing.Size(508, 315);
			this.Load += new System.EventHandler(this.UCGanttChart_Load);
			this.ResumeLayout(false);

        }

        #endregion

        internal exontrol.EXG2ANTTLib.exg2antt exGant;
    }
}
