using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttBar: CGanttObject

    {

        #region Member Variables

        protected int m_iHandle = -1;
        protected DateTime m_dtStart = DateTime.MinValue;
        protected DateTime m_dtEnd = DateTime.MinValue;
        protected string m_sText = "";
        protected EMGanttBarType m_emBarType = EMGanttBarType.BTask;
        protected EMGanttEdgeType m_emEdgeType = EMGanttEdgeType.Both;
        protected EMGanttEdgeShapeType m_emEdgeShapeType = EMGanttEdgeShapeType.Empty;
        protected object m_oData = null;

        #endregion


        #region Initialize/Dispose

        public CGanttBar()
        {

        }

        public new void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public int Handle
        {
            get { return m_iHandle; }
            set { m_iHandle = value; }
        }

        public DateTime  Start
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public DateTime End
        {
            get { return m_dtEnd; }
            set { m_dtEnd = value; }
        }

        public EMGanttBarType BarType
        {
            get { return m_emBarType; }
            set { m_emBarType = value; }
        }

        public EMGanttEdgeType EdgeType
        {
            get { return m_emEdgeType; }
            set { m_emEdgeType = value; }
        }

        public EMGanttEdgeShapeType EdgeShapeType
        {
            get { return m_emEdgeShapeType; }
            set { m_emEdgeShapeType = value; }
        }

        public string Text
        {
            get { return m_sText; }
            set { m_sText = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
