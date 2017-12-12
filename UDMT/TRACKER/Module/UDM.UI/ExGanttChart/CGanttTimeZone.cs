using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.ExGanttChart
{
    public class CGanttTimeZone : IDisposable
    {

        #region Member Variables

        private string m_sKey = string.Empty;
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private Color m_cColor = Color.Beige;
        private string m_sText = string.Empty;

        #endregion


        #region Initialize/Dispose

        public CGanttTimeZone(string sKey)
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

        public DateTime Start
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public DateTime End
        {
            get { return m_dtEnd; }
            set { m_dtEnd = value; }
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

        #endregion


        #region Public Methods


        #endregion
    }
}
