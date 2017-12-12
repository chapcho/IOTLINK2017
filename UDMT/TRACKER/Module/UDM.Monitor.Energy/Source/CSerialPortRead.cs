using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General.Threading;

namespace UDM.Monitor.Energy
{
    public class CSerialPortRead:CThreadBase
    {
        protected CModbusRTUConnecter m_cMeterDataReader = null;
        protected CSerialPortConfig m_cSerialConfig = null;
        protected CMeterLogger m_cMeterLogger = new CMeterLogger();
        protected int m_iSleepTime = 1000;

        #region Initialize/Dispose

        public CSerialPortRead()
        {

        }

        public new void Dispose()
        {
            if (m_bRun)
                Stop();

            base.Dispose();
        }

        #endregion

        #region Public Properties

        public CSerialPortConfig Config
        {
            get { return m_cSerialConfig; }
            set { m_cSerialConfig = value; }
        }

        public CMeterLogger MonitorLogger
        {
            get { return m_cMeterLogger; }
            set { m_cMeterLogger = value; }
        }
        #endregion

        #region Public Method

        #endregion

        #region Private Method

        protected override bool BeforeRun()
        {
            if (m_cMeterDataReader != null)
            {
                m_cMeterDataReader.Dispose();
                m_cMeterDataReader = null;
            }

            m_cMeterDataReader = new CModbusRTUConnecter(m_cSerialConfig);
            m_cMeterDataReader.DataLogger = m_cMeterLogger;
            m_iSleepTime = 1000 - m_cSerialConfig.DeviceConfigList.Count * 50;

            bool bOK = false;
            try
            {
                bOK = m_cMeterDataReader.Connect();

                if (bOK)
                    RunMonitorLogger();
                else
                    m_cMeterDataReader = null;

                m_bRun = true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                bOK = false;
                ex.Data.Clear();
            }

            return bOK;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            m_bRun = false;

            StopMonitorLogger();

            return true;
        }

        protected override void DoThreadWork()
        {
            if (m_cMeterDataReader == null)
                return;

            bool bBroken = false;

            while(m_bRun)
            {
                bBroken = m_cMeterDataReader.ReadDataS();

                if(!bBroken)
                {
                    m_bRun = false;
                    break;
                }

                System.Threading.Thread.Sleep(m_iSleepTime);
            }
        }

        protected override bool AfterStop()
        {
            if (m_cMeterDataReader != null)
            {
                m_cMeterDataReader.Dispose();
                m_cMeterDataReader = null;
            }

            return true;
        }

        protected bool RunMonitorLogger()
        {
            StopMonitorLogger();

            if (m_cMeterLogger == null)
                m_cMeterLogger = new CMeterLogger();

            return m_cMeterLogger.Run();
        }

        protected void StopMonitorLogger()
        {
            if (m_cMeterLogger != null)
                m_cMeterLogger.Stop();
        }

        #endregion
    }
}
