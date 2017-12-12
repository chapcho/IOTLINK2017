using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDMOptimizer
{
    public class CCollectInfo
    {
        #region Member Variables

        private DateTime m_dtStartTime = DateTime.MinValue;
        private DateTime m_dtEndTime = DateTime.MinValue;
        private CTimeLogS m_cLogS = new CTimeLogS();
        private CCycleInfoS m_cCycleInfoS = new CCycleInfoS();

        #endregion


        #region Properties

        public DateTime StartTime
        {
            get { return m_dtStartTime; }
            set { m_dtStartTime = value; }
        }

        public DateTime EndTime
        {
            get { return m_dtEndTime; }
            set { m_dtEndTime = value; }
        }

        public int LogCount
        {
            get { return m_cLogS.Count; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }
        
        public CCycleInfoS CycleInfoS
        {
            get { return m_cCycleInfoS; }
            set { m_cCycleInfoS = value; }
        }
        
        public int CycleCount
        {
            get
            {
                if (m_cCycleInfoS != null)
                    return m_cCycleInfoS.Count;
                return 0;
            }
        }

        #endregion

    }
}
