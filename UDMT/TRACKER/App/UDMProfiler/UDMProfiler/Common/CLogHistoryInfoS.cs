using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMProfiler
{
    public class CLogHistoryInfoS : Dictionary<string, Dictionary<EMCollectModeType, CLogHistoryInfo>>
    {
        #region Member Variables

        protected DateTime m_dtFirst = DateTime.MinValue;
        protected DateTime m_dtLast = DateTime.MinValue;

        #endregion


        #region Initialize/Dispose

        public CLogHistoryInfoS()
        {

        }
        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties
        public DateTime FirstTime
        {
            get { return m_dtFirst; }
            set { m_dtFirst = value; }
        }

        public DateTime LastTime
        {
            get { return m_dtLast; }
            set { m_dtLast = value; }
        }

        #endregion


        #region Public Methods
        #endregion


        #region Private Methods
        #endregion
    }
}