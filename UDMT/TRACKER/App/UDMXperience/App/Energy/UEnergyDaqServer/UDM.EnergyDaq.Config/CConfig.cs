using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.EnergyDaq.Config
{
    [Serializable]
    public class CConfig : IDisposable
    {
        #region Member Variables

        protected EMConnectType m_emConnectType = EMConnectType.DummyMeter;
        protected EMMeterModel m_emMeterModel = EMMeterModel.DummyMeter;
        protected string m_sMeterKey = string.Empty;
        protected int m_iIntervalTime = 1000;
        protected int m_iChannelCount = 1;

        #endregion


        #region Initilaize/Dispose

        public CConfig()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public EMConnectType ConnectType
        {
            get { return m_emConnectType; }
            set { m_emConnectType = value; }
        }

        public EMMeterModel MeterModel
        {
            get { return m_emMeterModel; }
            set { m_emMeterModel = value; }
        }

        public string MeterKey
        {
            get { return m_sMeterKey; }
            set { m_sMeterKey = value; }
        }

        public int IntervalTime
        {
            get { return m_iIntervalTime; }
            set { m_iIntervalTime = value; }
        }

        public int ChannelCount
        {
            get { return m_iChannelCount; }
            set { m_iChannelCount = value; }
        }
        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
