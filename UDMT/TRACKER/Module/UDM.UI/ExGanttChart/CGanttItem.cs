using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttItem : CGanttObject
    {

        #region Member Variables

        protected int m_iHandle = -1;
        protected string m_sPath = "";
        protected string[] m_saCellText = null;
        protected EMGanttBarType m_emBarType = EMGanttBarType.BTask;
        protected EMGanttEdgeType m_emEdgeType = EMGanttEdgeType.Both;
        protected EMGanttEdgeShapeType m_emShapeType = EMGanttEdgeShapeType.Empty;
        protected bool m_bBarAddable = false;
        protected int m_iOffSet = 0;
        protected int m_iBarCount = 0;
        protected object m_oData = null;


        #endregion


        #region Initialize/Dispose

        public CGanttItem(string sKey)
        {
            m_sKey = sKey;
            m_sPath = sKey;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public int Handle
        {
            get { return m_iHandle; }
            set { m_iHandle = value; }
        }

        public string Path
        {
            get { return m_sPath; }
            set { m_sPath = value; }
        }
        
        public string[] CellTextS
        {
            get { return m_saCellText; }
            set { m_saCellText = value; }
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
            get { return m_emShapeType; }
            set { m_emShapeType = value; }
        }

        public bool IsBarAddable
        {
            get { return m_bBarAddable; }
            set { m_bBarAddable = value; }
        }

        public int OffSet
        {
            get { return m_iOffSet; }
            set { m_iOffSet = value; }
        }

        public int BarCount
        {
            get { return m_iBarCount; }
            set { m_iBarCount = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        internal bool IsExist
        {
            get { return IsCreatedInChart(); }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        protected bool IsCreatedInChart()
        {
            if (m_iHandle > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
