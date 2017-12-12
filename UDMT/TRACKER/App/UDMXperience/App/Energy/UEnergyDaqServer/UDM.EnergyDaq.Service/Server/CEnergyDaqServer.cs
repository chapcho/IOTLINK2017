using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.General.RemoteService;
using UDM.Log.Energy;
using UDM.EnergyDaq.Config;
using UDM.Monitor;
using UDM.EnergyDaq.Monitor;

namespace UDM.EnergyDaq.Service
{
    public class CEnergyDaqServer : CServer<IEnergyDaqService, CEnergyDaqService>
    {
        #region Member Variables
        protected CConfigS m_cConfigS = null;
        protected CEnergyMonitor m_cMonitor = null;
        protected bool m_bIsRunning = false;
        public event UEventHandlerLogListRequire UEventLogKeyListRequire;
        #endregion


        #region Initilaize/Dispose

        public CEnergyDaqServer()
        {
            base.ServiceName = "UDMEnergyDaqSerivce";
            m_cMonitor = new CEnergyMonitor();

        }

        public new void Dispose()
        {
            base.Dispose();
            m_cMonitor.Dispose();

        }

        #endregion


        #region Public Properties

        public CConfigS ConfigS
        {
            get { return m_cConfigS; }
            set { m_cConfigS = value; }
        }

        #endregion


        #region Public Methods

        public void BeforeRunMonitor()
        {
            if (UEventLogKeyListRequire != null)
                m_cService.UEventLogListRequire += UEventLogKeyListRequire;
        }

        public void RunMonitor()
        {
            m_cMonitor.ConfigS = m_cConfigS;

            m_cMonitor.UEventTerminated += m_cMonitor_TerminatedEvent;
            m_cMonitor.UEventMonitorDeQue += m_cMonitor_LogSDeQueEvent;
            m_cMonitor.Run();
            m_bIsRunning = m_cMonitor.IsRunning;
        }

        public void AfterStopMonitor()
        {
            if (UEventLogKeyListRequire != null)
                m_cService.UEventLogListRequire -= UEventLogKeyListRequire;
        }

        public void StopMonitor()
        {
            m_cMonitor.Stop();
            m_bIsRunning = m_cMonitor.IsRunning;

            m_cMonitor.UEventTerminated -= m_cMonitor_TerminatedEvent;
            m_cMonitor.UEventMonitorDeQue -= m_cMonitor_LogSDeQueEvent;
        }

        public void SendToClient(CEnergyLogS cLogS)
        {
            m_cService.SendToClient(cLogS);
        }


        #endregion


        #region Private Methods


        #endregion


        #region Override Methods

        protected override void OnServerStarted()
        {
            base.OnServerStarted();
        }

        protected override void OnServerStoped()
        {
            base.OnServerStoped();
        }


        #endregion


        #region Event Methods

        private void m_cMonitor_TerminatedEvent(object sender, EventArgs e)
        {
            StopMonitor();
            MessageBox.Show("Energy Monitor is stopped.");
        }

        private void m_cMonitor_LogSDeQueEvent(object sender, CEnergyLogS cLogs)
        {
            SendToClient(cLogs);
        }

        #endregion
    }
}
