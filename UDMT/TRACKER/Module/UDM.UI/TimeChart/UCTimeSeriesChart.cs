using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{	
	public partial class UCGanttSeriesChart : UserControl
	{

		#region Member Variables

        private int m_iMainSplitPos = 0;
        private int m_iItemSplitPos = 0;

		#endregion


		#region Initialize/Dispose

		public UCGanttSeriesChart()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public new Font Font
		{
			get { return base.Font; }
			set { SetFont(value); }
		}

		public UCTimeLine TimeLine
		{
			get  {return ucTimeLine;}
		}

		public UCGanttTree GanttTree
		{
			get {return ucGanttTree;}
		}

		public UCGanttChart GanttChart
		{
			get {return ucGanttChart;}
		}

		public UCSeriesTree SeriesTree
		{
			get {return ucSeriesTree;}
		}

		public UCSeriesChart SeriesChart
		{
			get {return ucSeriesChart;}
		}

		#endregion


		#region Public Methods

		public void BeginUpdate()
		{
			ucGanttTree.BeginUpdate();
			ucSeriesTree.BeginUpdate();
		}

		public void EndUpdate()
		{
			ucGanttTree.EndUpdate();
			ucSeriesTree.EndUpdate();
			ucTimeLine.EndUpdate();
			ucTimeScrollBar.EndUpdate();
            ucSeriesChart.EndUpdate();
		}

		public void Clear()
		{
			ucTimeLine.TimeZoneS.Clear();
			ucTimeLine.TimeIndicatorS.Clear();
			ucGanttTree.ItemS.Clear();
			//ucGanttTree.ColumnS.Clear();
			ucSeriesTree.ItemS.Clear();
			//ucSeriesTree.ColumnS.Clear();

			this.Refresh();
		}

		public new void Refresh()
		{
			ucGanttTree.UpdateLayout();
			ucSeriesTree.UpdateLayout();
			ucTimeLine.UpdateLayout();
			ucTimeScrollBar.UpdateLayout();
		}

		#endregion


		#region Private Methods

		protected void SetFont(Font font)
		{
			base.Font = font;

			this.BeginUpdate();
			{
				ucGanttTree.Font = font;
				ucTimeLine.Font = font;
				ucGanttChart.Font = font;
				ucTimeScrollBar.Font = font;
			}
			this.EndUpdate();
		}

		#endregion


		#region Event Methods

		private void UCTimeChart_Load(object sender, EventArgs e)
		{	
			ucGanttTree.Select();
		}

		#endregion

        private void sptSeriesChart_SplitterMoving(object sender, DevExpress.XtraEditors.SplitMovingEventArgs e)
        {
            sptGanttChart.SplitterMoving -= sptGanttChart_SplitterMoving;
            {
                sptGanttChart.SplitterPosition = sptGanttChart.SplitterPosition;
            }
            sptGanttChart.SplitterMoving += sptGanttChart_SplitterMoving;
        }

        private void sptGanttChart_SplitterMoving(object sender, DevExpress.XtraEditors.SplitMovingEventArgs e)
        {
            sptSeriesChart.SplitterMoving -= sptSeriesChart_SplitterMoving;
            {
                sptSeriesChart.SplitterPosition = sptSeriesChart.SplitterPosition;
            }
            sptSeriesChart.SplitterMoving += sptSeriesChart_SplitterMoving;
        }

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iMainSplitPos;
        }

        private void sptGanttChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (sptGanttChart.SplitterPosition > 0)
            {
                m_iItemSplitPos = sptGanttChart.SplitterPosition;
                sptGanttChart.SplitterPosition = 0;
                sptSeriesChart.SplitterPosition = 0;
            }
            else
            {
                sptGanttChart.SplitterPosition = m_iItemSplitPos;
                sptSeriesChart.SplitterPosition = m_iItemSplitPos;
            }
        }
	}
}
