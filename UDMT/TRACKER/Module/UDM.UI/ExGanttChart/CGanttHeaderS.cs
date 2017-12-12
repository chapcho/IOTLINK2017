using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttHeaderS : List<CGanttHeader>, IDisposable
    {

        #region Member Variables


        UCGanttChart m_ucGanttChart = null;
        private int m_iTotalWidth = 0;
        
        #endregion


        #region Initialize/Dispose

        public CGanttHeaderS(UCGanttChart ucGanttChart)
        {
            m_ucGanttChart = ucGanttChart;
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public int TotalColumnWidth
        {
            get { return m_iTotalWidth; }
        }

        #endregion


        #region Public Methods

        public new void Add(CGanttHeader cHeader)
        {
            if(cHeader != null)
            {
                base.Add(cHeader);

                InitColumnHeader();
            }
            
        }

        public new void Remove(CGanttHeader cHeader)
        {
            if (cHeader != null)
            {
                base.Remove(cHeader);

                InitColumnHeader();
            }
        }

        public new void RemoveAt(int iIndex)
        {
            if (this.Count > iIndex)
            {
                CGanttHeader cHeader = this[iIndex];
                base.RemoveAt(iIndex);

                InitColumnHeader();

            }
        }

        public new void Clear()
        {
            base.Clear();

            InitColumnHeader();
        }

        #endregion


        #region Private Methods

        protected void InitColumnHeader()
        {
            m_iTotalWidth = 0;
            m_ucGanttChart.exGant.BeginUpdate();
            m_ucGanttChart.exGant.Columns.Clear();

            exontrol.EXG2ANTTLib.Column exColumn;
            CGanttHeader cHeader;
            m_iTotalWidth = 0;
            for (int i = 0; i < this.Count; i++)
            {
                cHeader = this[i];
                exColumn = m_ucGanttChart.exGant.Columns.Add(cHeader.Caption);
                exColumn.DisplayFilterButton = true;
                exColumn.DisplayFilterPattern = true;
                exColumn.WidthAutoResize = false;
                exColumn.Width = cHeader.Width;
                exColumn.HeaderAlignment = exontrol.EXG2ANTTLib.AlignmentEnum.CenterAlignment;
                exColumn.Alignment = exontrol.EXG2ANTTLib.AlignmentEnum.CenterAlignment;
                m_iTotalWidth += cHeader.Width;
            }

            m_ucGanttChart.exGant.Chart.PaneWidthLeft = m_iTotalWidth;
            m_ucGanttChart.exGant.EndUpdate();
        }

        #endregion

    }
}
