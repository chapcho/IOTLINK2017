using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CLineInfo
    {
        #region Member Variables

        private string m_sPlcProcName = "";
        private byte[] m_arryImage = null;
        
        private List<double> m_lstCycleTime = new List<double>();   // 운영시간
        private List<double> m_lstTactTime = new List<double>();    // 가동시간
        private List<double> m_lstIdleTime = new List<double>();    // 정지시간

        private CPlcProc m_cPlcProc = new CPlcProc();
        private CLineInfoTag m_cLimitSetCount = new CLineInfoTag();
        private CLineInfoTag m_cNowCount = new CLineInfoTag();
        private CLineInfoTag m_cGoodCount = new CLineInfoTag();
        private CLineInfoTag m_cNGCount = new CLineInfoTag();
        private CLineInfoTag m_cAutoRun = new CLineInfoTag();
        private CLineInfoTag m_cManualMode = new CLineInfoTag();
        private List<CLineInfoTag> m_lstETCViewTag = new List<CLineInfoTag>();

        [NonSerialized]
        private List<CLineInfoTag> m_lstAllTag = new List<CLineInfoTag>();
        private List<string> m_lstAllTagKey = new List<string>();

        #endregion

        public CLineInfo(string sPlcProcName)
        {
            m_sPlcProcName = sPlcProcName;
            m_cPlcProc = CMultiProject.PlcProcS[m_sPlcProcName];
        }

        #region Properties

        public byte[] ImageArry
        {
            get { return m_arryImage; }
            set { m_arryImage = value; }
        }

        public List<double> CycleTimeList
        {
            get { return m_lstCycleTime; }
            set { m_lstCycleTime = value; }
        }

        public List<double> TactTimeList
        {
            get { return m_lstTactTime; }
            set { m_lstTactTime = value; }
        }

        public List<double> IdleTimeList
        {
            get { return m_lstIdleTime; }
            set { m_lstIdleTime = value; }
        }

        public CPlcProc PlcProc
        {
            get { return m_cPlcProc; }
            set { m_cPlcProc = value; }
        }

        public CLineInfoTag LimitSetCount
        {
            get { return m_cLimitSetCount; }
            set { m_cLimitSetCount = value; }
        }

        public CLineInfoTag NowCount
        {
            get { return m_cNowCount; }
            set { m_cNowCount = value; }
        }

        public CLineInfoTag GoodCount
        {
            get { return m_cGoodCount; }
            set { m_cGoodCount = value; }
        }

        public CLineInfoTag NGCount
        {
            get { return m_cNGCount; }
            set { m_cNGCount = value; }
        }

        public CLineInfoTag AutoRun
        {
            get { return m_cAutoRun; }
            set { m_cAutoRun = value; }
        }

        public CLineInfoTag ManualMode
        {
            get { return m_cManualMode; }
            set { m_cManualMode = value; }
        }

        public List<CLineInfoTag> ETCViewTagList
        {
            get { return m_lstETCViewTag; }
            set { m_lstETCViewTag = value; }
        }

        public TimeSpan TotalCycleTime
        {
            get
            {
                double total = 0;
                for (int i = 0; i < m_lstCycleTime.Count; i++)
                {
                    total = total + m_lstCycleTime[i];
                }

                int iTotalSec = (int)total;

                TimeSpan tpCycle = new TimeSpan(0, 0, iTotalSec);
                return tpCycle;
            }
        }

        public TimeSpan TotalTactTime
        {
            get
            {
                double total = 0;
                for (int i = 0; i < m_lstTactTime.Count; i++)
                {
                    total = total + m_lstTactTime[i];
                }

                int iTotalSec = (int)total;

                TimeSpan tpTact = new TimeSpan(0, 0, iTotalSec);
                return tpTact;
            }
        }

        public TimeSpan TotalIdleTime
        {
            get
            {
                double total = 0;
                for (int i = 0; i < m_lstIdleTime.Count; i++)
                {
                    total = total + m_lstIdleTime[i];
                }

                int iTotalSec = (int)total;

                TimeSpan tpIdle = new TimeSpan(0, 0, iTotalSec);
                return tpIdle;
            }
        }
        public List<CLineInfoTag> ReadSymbolList
        {
            get
            {
                if (m_lstAllTag != null)
                    m_lstAllTag.Clear();

                m_lstAllTag = new List<CLineInfoTag>();

                if (m_cLimitSetCount.Tag != null)
                    m_lstAllTag.Add(m_cLimitSetCount);
                if (m_cNowCount.Tag != null)
                    m_lstAllTag.Add(m_cNowCount);
                if (m_cGoodCount.Tag != null)
                    m_lstAllTag.Add(m_cGoodCount);
                if (m_cNGCount.Tag != null)
                    m_lstAllTag.Add(m_cNGCount);
                if (m_lstETCViewTag != null && m_lstETCViewTag.Count > 0)
                    m_lstAllTag.AddRange(m_lstETCViewTag);

                return m_lstAllTag;
            }
        }

        public List<string> ReadSymbolListKeyList
        {
            get
            {
                if(m_lstAllTagKey == null)
                    m_lstAllTagKey = new List<string>();

                m_lstAllTagKey.Clear();

                if (m_cLimitSetCount.Tag != null)
                    m_lstAllTagKey.Add(m_cLimitSetCount.Tag.Key);
                if (m_cNowCount.Tag != null)
                    m_lstAllTagKey.Add(m_cNowCount.Tag.Key);
                if (m_cGoodCount.Tag != null)
                    m_lstAllTagKey.Add(m_cGoodCount.Tag.Key);
                if (m_cNGCount.Tag != null)
                    m_lstAllTagKey.Add(m_cNGCount.Tag.Key);
                if (m_lstETCViewTag != null && m_lstETCViewTag.Count > 0)
                {
                    foreach(CLineInfoTag cLineTag in m_lstETCViewTag)
                        m_lstAllTagKey.Add(cLineTag.Tag.Key);
                }

                return m_lstAllTagKey;
            }
        }

        #endregion

        #region Public Method

        #endregion

        #region Private Method
        #endregion
    }
}