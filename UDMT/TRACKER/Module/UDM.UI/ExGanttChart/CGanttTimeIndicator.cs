using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.ExGanttChart
{
    public class CGanttTimeIndicator : IDisposable
    {

        #region Member Variables

        private string m_sKey = string.Empty;
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private Color m_cColor = Color.Beige;
        private string m_sText = string.Empty;
        private int m_iX = 0;
        private int m_iY = 0;

        #endregion


        #region Initialize/Dispose

        public CGanttTimeIndicator(string sKey)
        {
            m_sKey = sKey;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
        }

        public DateTime Time
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public Color BackColor
        {
            get { return m_cColor; }
            set { m_cColor = value; }
        }

        public string Text
        {
            get { return m_sText; }
            set { m_sText = value; }
        }

        public int X
        {
            get { return m_iX; }
            set { m_iX = value; }
        }

        public int Y
        {
            get { return m_iY; }
            set { m_iY = value; }
        }

        #endregion


        #region Public Methods


        #endregion
    }
}
