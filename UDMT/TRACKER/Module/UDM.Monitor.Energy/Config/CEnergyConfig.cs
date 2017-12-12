using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    [Serializable]
    public class CEnergyConfig : IDisposable
    {
        protected EMConnectType m_emConnectType = EMConnectType.Ethernet;
        protected EMModbusFunctionCode m_emFunctionCode = EMModbusFunctionCode.ReadMultipleRegister;
        protected EMMeterModule m_emMeterModule = EMMeterModule.Accura3300S;
        protected int m_iIntervalTime = 1000;
        protected int m_iRunPauseRate = 0;
        protected int m_iPauseStopRate = 0;

        #region Initialize/Dispose

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

        public EMModbusFunctionCode FunctionCode
        {
            get { return m_emFunctionCode; }
            set { m_emFunctionCode = value; }
        }

        public EMMeterModule MeterModule
        {
            get { return m_emMeterModule; }
            set { m_emMeterModule = value; }
        }

        public int RunningPauseRate
        {
            get { return m_iRunPauseRate; }
            set { m_iRunPauseRate = value; }
        }

        public int PauseStopRate
        {
            get { return m_iPauseStopRate; }
            set { m_iPauseStopRate = value; }
        }

        public int IntervalTime
        {
            get { return m_iIntervalTime; }
            set { m_iIntervalTime = value; }
        }
        #endregion
    }
}
