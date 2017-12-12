using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using UDM.EnergyDaq.Config;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
{
    public class CMonitorSource:IDisposable
    {
        #region Member Variables

        private bool m_bRun = false;
        public event EventHandler UEventTerminated;
        public event UEventHandlerMeterLogCreate UEventMeterLogCreate;

        protected List<CMeterDataReader> m_lstDataReaderS = null;
 
        protected CConfigS m_cEnergyConfigS = null;
 

        #endregion


        #region Initialize/Dispose

        public CMonitorSource()
        {
            m_lstDataReaderS = new List<CMeterDataReader>();
        }

        public void Dispose()
        {
            if(m_lstDataReaderS!=null)
                m_lstDataReaderS.Clear();
        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
            set { m_bRun = value; }
        }

        public CConfigS EnergyConfigS
        {
            get { return m_cEnergyConfigS; }
            set { m_cEnergyConfigS = value; }
        }

        #endregion


        #region Public Methods

        public bool Run()
        {
            Stop();

            bool bOK = true;

            foreach(CConfig tempConfig in m_cEnergyConfigS)
            {
                CMeterDataReader cTempReader = new CMeterDataReader(tempConfig);

                cTempReader.UEventMeterLogCreate += MonitorLogger_UEventDataRead;
                cTempReader.Run();

                m_lstDataReaderS.Add(cTempReader);
            }
           

            return bOK;
        }

        public void Stop()
        {

            foreach(CMeterDataReader tempRead in m_lstDataReaderS)
            {
                tempRead.UEventMeterLogCreate -= MonitorLogger_UEventDataRead;
                tempRead.Stop();
            }

            m_bRun = false;
        }


        #endregion


        #region Private Methods


        #endregion

        #region Event Methods

        protected void MonitorLogger_UEventDataRead(object sender, CEnergyLogS clogs)
        {
            GenerateLogCreateEvent(clogs);
        }

        protected void GenerateLogCreateEvent(CEnergyLogS cLog)
        {
            if (UEventMeterLogCreate != null)
                UEventMeterLogCreate(this, cLog);
        }

        protected void GenerateTerminatedEvent()
        {
            if (UEventTerminated != null)
                UEventTerminated(this, new EventArgs());
        }
        #endregion
    }
}
