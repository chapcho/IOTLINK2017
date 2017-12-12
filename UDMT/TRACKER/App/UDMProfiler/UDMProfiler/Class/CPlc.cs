using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerSPD.DDEA;
using TrackerSPD.LS;
using TrackerSPD.OPC;
using UDM.Common;


namespace UDMProfiler
{
    [Serializable]
    public class CPlc
    {
        private string m_sPlcID = string.Empty;
        private string m_sPlcName = string.Empty;
        private string m_sChannel = string.Empty;
        private EMPLCMaker m_emPlcMaker = EMPLCMaker.ALL;
        private CTagS m_cTagS = new CTagS();
        private CStepS m_cStepS = new CStepS();
        private EMCollectType m_emCollectType = EMCollectType.None;

        protected CLsConfig m_cLsConfig = new CLsConfig();
        protected CDDEAConfigMS m_cMelsecConfig = new CDDEAConfigMS();
        protected COPCConfig m_cOPCConfig = new COPCConfig();

        #region Initialize/Dispose

        #endregion

        #region Properties

        public string PlcID
        {
            get { return m_sPlcID;}
            set { m_sPlcID = value; }
        }

        public string PlcName
        {
            get { return m_sPlcName;}
            set { m_sPlcName = value; }
        }

        public string PlcChannel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public EMPLCMaker PlcMaker
        {
            get { return m_emPlcMaker; }
            set { m_emPlcMaker = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS;}
            set { m_cTagS = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS;}
            set { m_cStepS = value; }
        }

        public EMCollectType CollectType
        {
            get { return m_emCollectType;}
            set { m_emCollectType = value; }
        }

        public COPCConfig OPCConfig
        {
            get { return m_cOPCConfig; }
            set { m_cOPCConfig = value; }
        }

        public CDDEAConfigMS MelsecConfig
        {
            get { return m_cMelsecConfig; }
            set { m_cMelsecConfig = value; }
        }

        public CLsConfig LsConfig
        {
            get { return m_cLsConfig; }
            set { m_cLsConfig = value; }
        }

        #endregion

        #region Public Methods

        public void Compose()
        {
            if (m_cStepS == null || m_cTagS == null)
                return;

            m_cStepS.Compose(m_cTagS);
            m_cStepS.ComposeTagRoleS();
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
