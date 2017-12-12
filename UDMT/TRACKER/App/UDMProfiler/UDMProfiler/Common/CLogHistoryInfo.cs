using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDMProfiler
{
    public class CLogHistoryInfo
    {
        #region Member Variables
        protected EMCollectModeType m_emMode = EMCollectModeType.Normal;

        protected string m_sProjectID = "00000000";
        protected string m_sPLCID = "00000000-0";
        protected string m_sMachine = "";
        protected string m_sUserID = "";
        protected string m_sUserName = "";
        protected int m_iLogCount = 0;
        protected DateTime m_dtStart = DateTime.MinValue;
        protected DateTime m_dtEnd = DateTime.MinValue;

        protected CTimeLogS m_cTimeLogS = new CTimeLogS();
        #endregion

        #region Initilaize/Dispose

        public CLogHistoryInfo()
        {
        }

        #endregion


        #region Public Properties

        public EMCollectModeType CollectMode
        {
            get { return m_emMode; }
            set { m_emMode = value; }
        }
        public string ProjectID
        {
            get { return m_sProjectID; }
            set { m_sProjectID = value; }
        }
        public string PLCID
        {
            get { return m_sPLCID; }
            set { m_sPLCID = value; }
        }

        public string Machine
        {
            get { return m_sMachine; }
            set { m_sMachine = value; }
        }

        public string UserID
        {
            get { return m_sUserID; }
            set { m_sUserID = value; }
        }

        public string UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }

        public int LogCount
        {
            get { return m_iLogCount; }
            set { m_iLogCount = value; }
        }

        public DateTime StartTime
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public DateTime EndTime
        {
            get { return m_dtEnd; }
            set { m_dtEnd = value; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        #endregion


        #region Public Methods


        public void Clear()
        {
            if (m_cTimeLogS != null)
                m_cTimeLogS.Clear();
        }

        public CLogHistoryInfo Clone()
        {
            CLogHistoryInfo cHistory = new CLogHistoryInfo();

            cHistory.CollectMode = m_emMode;
            cHistory.ProjectID = m_sProjectID;
            cHistory.PLCID = m_sPLCID;
            cHistory.Machine = m_sMachine;
            cHistory.UserID = m_sUserID;
            cHistory.UserName = m_sUserName;
            cHistory.LogCount = m_iLogCount;
            cHistory.StartTime = m_dtStart;
            cHistory.EndTime = m_dtEnd;
            cHistory.TimeLogS = m_cTimeLogS;

            return cHistory;
        }
        #endregion

        #region Private Methods

        #endregion

    }
}
