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
	public partial class UCTimeChart : UserControl
	{

		#region Member Variables

        private int m_iSplitPos = 0;

		#endregion


		#region Initialize/Dispose

		public UCTimeChart()
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
			get { return ucTimeLine; }
		}

		public UCGanttTree GanttTree
		{
			get { return ucGanttTree; }
		}

		public UCGanttChart GanttChart
		{
			get { return ucGanttChart; }
		}

		#endregion


		#region Public Methods

		public void BeginUpdate()
		{
			ucGanttTree.BeginUpdate();
		}

		public void EndUpdate()
		{
			ucGanttTree.EndUpdate();
			ucTimeLine.EndUpdate();
			ucTimeScrollBar.EndUpdate();
		}

		public void Clear()
		{
			ucTimeLine.TimeZoneS.Clear();
			ucTimeLine.TimeIndicatorS.Clear();
			ucGanttTree.ItemS.Clear();
			//ucGanttTree.ColumnS.Clear();

			this.Refresh();
		}

		public new void Refresh()
		{
			ucGanttTree.UpdateLayout();
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

		}

		#endregion


        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }
	}
}
