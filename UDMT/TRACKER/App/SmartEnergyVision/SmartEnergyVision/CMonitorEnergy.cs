using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Log;
using UDM.Monitor.Energy;
using System.Windows.Forms;
using UDM.Log.DB;

namespace SmartEnergyVision
{
    public class CMonitorEnergy:IDisposable
    {
        protected CMonitor m_cEnergyMonitor = null;
        protected CEnergyConfig m_cConfig = null;
        protected bool m_bIsRunning = false;
        protected CPostSqlLogWriter m_cDBWriter = new CPostSqlLogWriter();

        public event UEventHandlerRealTimeDataRead UEventRealTimeDataRead;

        #region Inialize/Dispose

        public CMonitorEnergy()
        {
            m_cEnergyMonitor = new CMonitor();
        }

        public void Dispose()
        {
            m_cEnergyMonitor.Dispose();
            m_cConfig.Dispose();
        }
        #endregion

        #region Public Properties

        public CMonitor EnergyMonitor
        {
            get { return m_cEnergyMonitor; }
            set { m_cEnergyMonitor = value; }
        }

        public CEnergyConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }
        #endregion

        #region Public MethodS

        public void RunEnergyMonitor()
        {
            m_cEnergyMonitor.Config = m_cConfig;

            if (ConnectDB() == false)
                return;

            m_cEnergyMonitor.UEventTerminated += m_cMonitor_TerminatedEvent;
            m_cEnergyMonitor.Source.UEventMeterLogCreate += m_cMonitor_RealTimeLogReadEvent;

            m_cEnergyMonitor.Logger.UEventValueChanged += Logger_UEventValueChanged;
            bool bOk = m_cEnergyMonitor.Run();
            m_bIsRunning = bOk;
        }

        public bool CheckEnergyMonitorRunState()
        {
            return m_cEnergyMonitor.IsRunning;
        }

        public void StopEnergyMonitor()
        {
            
            m_cEnergyMonitor.Stop();
            m_cEnergyMonitor.Logger.UEventValueChanged -= Logger_UEventValueChanged;

            DisconnectDB();
            m_bIsRunning = false;
        }



        #endregion

        #region Private MethodS

        private bool ConnectDB()
        {
            DisconnectDB();

            m_cDBWriter = new CPostSqlLogWriter();
            bool bOK = m_cDBWriter.Connect();
            if(bOK == false)
            {
                DisconnectDB();
                MessageBox.Show("Cannot connect to Database!!", "Energy Vision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bOK;
        }

        private bool DisconnectDB()
        {
            if(m_cDBWriter != null)
            {
                m_cDBWriter.Disconnect();
                m_cDBWriter.Dispose();
                m_cDBWriter = null;
            }

            return true;
        }
        #endregion

        #region Event Methods

        private void m_cMonitor_TerminatedEvent(object sender, EventArgs e)
        {
            StopEnergyMonitor();
            MessageBox.Show("Energy Monitor is stopped.");
        }

        private void m_cMonitor_RealTimeLogReadEvent(object sender,CEnergyLog clog)
        {
            if (UEventRealTimeDataRead != null)
                UEventRealTimeDataRead(this, clog);
        }

        private void Logger_UEventValueChanged(object sender, CEnergyLogS cLogS)
        {
            m_cDBWriter.WriteEnergyLogS(cLogS);
        }

        #endregion
    }
}
