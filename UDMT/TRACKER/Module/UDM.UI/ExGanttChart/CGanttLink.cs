using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttLink : CGanttObject
    {

        #region Member Variables

        protected CGanttBar m_cBarFrom = null;
        protected CGanttBar m_cBarTo = null;
        protected Color m_cColor = Color.Black;
        protected EMGanttPointType m_emPointTypeFrom = EMGanttPointType.Start;
        protected EMGanttPointType m_emPointTypeTo = EMGanttPointType.Start;        
        protected string m_sText = "";
        protected object m_oData = null;

        #endregion


        #region Initialize/Dispose

        public CGanttLink()
        {

        }

        public new void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public CGanttBar BarFrom
        {
            get { return m_cBarFrom; }
            set { m_cBarFrom = value; }
        }

        public CGanttBar BarTo
        {
            get { return m_cBarTo; }
            set { m_cBarTo = value; }
        }

        public Color Color
        {
            get { return m_cColor; }
            set { m_cColor = value; }
        }

        public EMGanttPointType PointTypeFrom
        {
            get { return m_emPointTypeFrom; }
            set { m_emPointTypeFrom = value; }
        }

        public EMGanttPointType PointTypeTo
        {
            get { return m_emPointTypeTo; }
            set { m_emPointTypeTo = value; }
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
