using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.General.Threading;

namespace UDMEnergyViewer
{
    public class CMeterMonitor : CThreadBase
    {

        #region Member Variables

        private CMeterConfig m_cConfig = new CMeterConfig();
        private CMeterReader m_cReader = null;
        private CMeterLogger m_cLogger = new CMeterLogger();
        private CMeterLogWriter m_cLoggerwriter = null;

        #endregion


        #region Initialize/Dispose

        public CMeterMonitor()
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

        public CMeterConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        public CMeterReader MeterReader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        public CMeterLogger MonitorLogger
        {
            get { return m_cLogger; }
        }

        public CMeterLogWriter MeterLogWriter
        {
            get { return m_cLoggerwriter; }
            set { m_cLoggerwriter = value;  }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            if (m_cReader != null)
            {
                m_cReader.Dispose();
                m_cReader = null;
            }

            m_cReader = new CMeterReader();
            m_cReader.Config = m_cConfig;

            bool bOK = false;

            try
            {
                bOK = m_cReader.Connect();
                if (bOK)
                    RunMonitorLogger();
                else
                    m_cReader = null;

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

        protected override bool AfterStop()
        {
            if (m_cReader != null)
            {
                m_cReader.Dispose();
                m_cReader = null;
            }

            return true;
        }

        protected override void DoThreadWork()
        {
            if (m_cReader == null)
                return;

            bool bBroken = false;

            CMeterData cData = null;
            while(m_bRun)
            {
                cData = m_cReader.ReadData(out bBroken);

                if(!bBroken)
                {
                    m_bRun = false;
                    break;
                }

                if(cData != null && cData.Data.Length>10)
                    DoDataRecieved(cData);

                
            }

            if (!bBroken)
                Stop();
        }

        protected bool RunMonitorLogger()
        {
            StopMonitorLogger();

            if (m_cLogger == null)
                m_cLogger = new CMeterLogger();

            return m_cLogger.Run();
        }

        protected void StopMonitorLogger()
        {
            if (m_cLogger != null)
                m_cLogger.Stop();
        }

        protected void DoDataRecieved(CMeterData cData)
        {
            try
            {
                if (m_cLogger.IsRunning)
                    m_cLogger.EnQue(cData);
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }


        #endregion
    }
}
