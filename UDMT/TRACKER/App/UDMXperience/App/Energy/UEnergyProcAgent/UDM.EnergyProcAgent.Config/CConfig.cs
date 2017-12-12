using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.EnergyProcAgent.Config
{
    [Serializable]
    public class CConfig : IDisposable
    {

        #region Member Variables

        protected string m_sName = "EnergyProcAgent";
        
        protected CServerInfoS m_cServerInfoS = new CServerInfoS();
        protected CSummaryInfoS m_cSummaryInfoS = new CSummaryInfoS();

        protected CLoggerInfo m_cLoggerInfo = new CLoggerInfo();        

        #endregion


        #region Initialize/Dispose

        public CConfig()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public CServerInfoS ServerInfoS
        {
            get { return m_cServerInfoS; }
            set { m_cServerInfoS = value; }
        }

        public CSummaryInfoS SummaryInfoS
        {
            get { return m_cSummaryInfoS; }
            set { m_cSummaryInfoS = value; }
        }

        public CLoggerInfo LoggerInfo
        {
            get { return m_cLoggerInfo; }
            set { m_cLoggerInfo = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            if (m_cServerInfoS != null)
                m_cServerInfoS.Clear();

            if (m_cSummaryInfoS != null)
                m_cSummaryInfoS.Clear();
        }

        #endregion


        #region Private Methods


        #endregion


        #region Event Methods


        #endregion

    }
}
