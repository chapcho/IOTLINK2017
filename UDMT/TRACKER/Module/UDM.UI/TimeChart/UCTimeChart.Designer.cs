namespace UDM.UI.TimeChart
{
	partial class UCTimeChart
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
            this.pnlGanttTreeArea = new System.Windows.Forms.Panel();
            this.ucGanttTree = new UDM.UI.TimeChart.UCGanttTree();
            this.pnlGanttTreeHeader = new System.Windows.Forms.Panel();
            this.pnlGanttChartArea = new System.Windows.Forms.Panel();
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.ucItemScrollBar = new UDM.UI.TimeChart.UCItemScrollBar();
            this.ucGanttChart = new UDM.UI.TimeChart.UCGanttChart();
            this.ucTimeLine = new UDM.UI.TimeChart.UCTimeLine();
            this.ucTimeScrollBar = new UDM.UI.TimeChart.UCTimeScrollBar();
            this.sptMain = new UDM.UI.MySplitContainerControl();
            this.pnlGanttTreeArea.SuspendLayout();
            this.pnlGanttChartArea.SuspendLayout();
            this.pnlGanttChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucGanttChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).BeginInit();
            this.sptMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGanttTreeArea
            // 
            this.pnlGanttTreeArea.Controls.Add(this.ucGanttTree);
            this.pnlGanttTreeArea.Controls.Add(this.pnlGanttTreeHeader);
            this.pnlGanttTreeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttTreeArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttTreeArea.Name = "pnlGanttTreeArea";
            this.pnlGanttTreeArea.Size = new System.Drawing.Size(287, 591);
            this.pnlGanttTreeArea.TabIndex = 1;
            // 
            // ucGanttTree
            // 
            this.ucGanttTree.ColumnHeight = 20;
            this.ucGanttTree.DefaultBarHeight = 12;
            this.ucGanttTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGanttTree.FirstVisibleItem = null;
            this.ucGanttTree.FirstVisibleItemIndex = 0;
            this.ucGanttTree.FocusedItem = null;
            this.ucGanttTree.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ucGanttTree.IsItemMovable = true;
            this.ucGanttTree.ItemHeight = 20;
            this.ucGanttTree.Location = new System.Drawing.Point(0, 19);
            this.ucGanttTree.Name = "ucGanttTree";
            this.ucGanttTree.ScrollValue = 0;
            this.ucGanttTree.ShowAutoFilter = false;
            this.ucGanttTree.ShowCheckBox = false;
            this.ucGanttTree.ShowHScrollBarAlways = true;
            this.ucGanttTree.Size = new System.Drawing.Size(287, 572);
            this.ucGanttTree.TabIndex = 0;
            // 
            // pnlGanttTreeHeader
            // 
            this.pnlGanttTreeHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGanttTreeHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGanttTreeHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttTreeHeader.Name = "pnlGanttTreeHeader";
            this.pnlGanttTreeHeader.Size = new System.Drawing.Size(287, 19);
            this.pnlGanttTreeHeader.TabIndex = 1;
            // 
            // pnlGanttChartArea
            // 
            this.pnlGanttChartArea.Controls.Add(this.pnlGanttChart);
            this.pnlGanttChartArea.Controls.Add(this.ucTimeScrollBar);
            this.pnlGanttChartArea.Controls.Add(this.ucTimeLine);
            this.pnlGanttChartArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttChartArea.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttChartArea.Name = "pnlGanttChartArea";
            this.pnlGanttChartArea.Size = new System.Drawing.Size(365, 591);
            this.pnlGanttChartArea.TabIndex = 3;
            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.Controls.Add(this.ucItemScrollBar);
            this.pnlGanttChart.Controls.Add(this.ucGanttChart);
            this.pnlGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttChart.Location = new System.Drawing.Point(0, 45);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(365, 528);
            this.pnlGanttChart.TabIndex = 3;
            // 
            // ucItemScrollBar
            // 
            this.ucItemScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.ucItemScrollBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucItemScrollBar.ItemTree = this.ucGanttTree;
            this.ucItemScrollBar.Location = new System.Drawing.Point(348, 0);
            this.ucItemScrollBar.Name = "ucItemScrollBar";
            this.ucItemScrollBar.Size = new System.Drawing.Size(17, 528);
            this.ucItemScrollBar.TabIndex = 2;
            // 
            // ucGanttChart
            // 
            this.ucGanttChart.BackColor = System.Drawing.Color.White;
            this.ucGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGanttChart.ErrorImage = null;
            this.ucGanttChart.GanttTree = this.ucGanttTree;
            this.ucGanttChart.Image = null;
            this.ucGanttChart.InitialImage = null;
            this.ucGanttChart.IsEditable = false;
            this.ucGanttChart.Location = new System.Drawing.Point(0, 0);
            this.ucGanttChart.Name = "ucGanttChart";
            this.ucGanttChart.Size = new System.Drawing.Size(365, 528);
            this.ucGanttChart.TabIndex = 1;
            this.ucGanttChart.TabStop = false;
            this.ucGanttChart.TimeLine = this.ucTimeLine;
            // 
            // ucTimeLine
            // 
            this.ucTimeLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTimeLine.ErrorImage = null;
            this.ucTimeLine.FirstVisibleTime = new System.DateTime(1, 1, 1, 0, 0, 1, 0);
            this.ucTimeLine.Image = null;
            this.ucTimeLine.InitialImage = null;
            this.ucTimeLine.Location = new System.Drawing.Point(0, 0);
            this.ucTimeLine.Name = "ucTimeLine";
            this.ucTimeLine.RangeFrom = new System.DateTime(((long)(0)));
            this.ucTimeLine.RangeTo = new System.DateTime(((long)(0)));
            this.ucTimeLine.ScrollValue = 1;
            this.ucTimeLine.Size = new System.Drawing.Size(365, 45);
            this.ucTimeLine.TabIndex = 0;
            this.ucTimeLine.TabStop = false;
            this.ucTimeLine.UnitWidth = 20F;
            // 
            // ucTimeScrollBar
            // 
            this.ucTimeScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucTimeScrollBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucTimeScrollBar.Location = new System.Drawing.Point(0, 573);
            this.ucTimeScrollBar.Name = "ucTimeScrollBar";
            this.ucTimeScrollBar.Size = new System.Drawing.Size(365, 18);
            this.ucTimeScrollBar.TabIndex = 3;
            this.ucTimeScrollBar.TimeLine = this.ucTimeLine;
            // 
            // sptMain
            // 
            this.sptMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMain.Location = new System.Drawing.Point(0, 0);
            this.sptMain.Name = "sptMain";
            this.sptMain.Panel1.Controls.Add(this.pnlGanttTreeArea);
            this.sptMain.Panel1.Text = "Panel1";
            this.sptMain.Panel2.Controls.Add(this.pnlGanttChartArea);
            this.sptMain.Panel2.Text = "Panel2";
            this.sptMain.Size = new System.Drawing.Size(662, 591);
            this.sptMain.SplitterPosition = 287;
            this.sptMain.TabIndex = 4;
            this.sptMain.Text = "splitContainerControl1";
            this.sptMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sptMain_MouseDoubleClick);
            // 
            // UCTimeChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sptMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UCTimeChart";
            this.Size = new System.Drawing.Size(662, 591);
            this.Load += new System.EventHandler(this.UCTimeChart_Load);
            this.pnlGanttTreeArea.ResumeLayout(false);
            this.pnlGanttChartArea.ResumeLayout(false);
            this.pnlGanttChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucGanttChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucTimeLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptMain)).EndInit();
            this.sptMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlGanttTreeArea;
		private UCGanttTree ucGanttTree;
        private System.Windows.Forms.Panel pnlGanttTreeHeader;
		private System.Windows.Forms.Panel pnlGanttChartArea;
		private System.Windows.Forms.Panel pnlGanttChart;
		private UCItemScrollBar ucItemScrollBar;
		private UCGanttChart ucGanttChart;
		private UCTimeLine ucTimeLine;
        private UCTimeScrollBar ucTimeScrollBar;
        private MySplitContainerControl sptMain;
	}
}
