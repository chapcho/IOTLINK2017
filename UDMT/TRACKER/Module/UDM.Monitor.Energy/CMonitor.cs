using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

using UDM.General.Threading;
using UDM.Log;
using UDM.Monitor.Energy.Source;

namespace UDM.Monitor.Energy
{
    public class CMonitor : CThreadWithQueBase<CEnergyLogS>
    {

        #region Member Variables

        protected CMonitorSource m_cSource = new CMonitorSource();
        protected CMonitorLogger m_cLogger = new CMonitorLogger();
        protected CMonitorViewer m_cViewer = new CMonitorViewer();
        protected CEnergyConfig m_cEnergyConfig = null;
        public event EventHandler UEventTerminated;

        #endregion


        #region Initialize/Dispose

        public CMonitor()
        {

        }

        public new void Dispose()
        {
            base.Dispose();

            this.Clear();
        }

        #endregion


        #region Public Properties

        public CMonitorSource Source
        {
            get { return m_cSource; }
            set { m_cSource = value; }
        }

        public CMonitorLogger Logger
        {
            get { return m_cLogger; }
        }

        public CMonitorViewer Viewer
        {
            get { return m_cViewer; }
        }

        public CEnergyConfig Config
        {
            get { return m_cEnergyConfig; }
            set { m_cEnergyConfig = value; }
        }
       
        #endregion


        #region Public Methods

        public new void EnQue(CEnergyLogS cLogS)
        {
            base.EnQue(cLogS);
        }

        public void Clear()
        {
            m_cQue.Clear();
        }

        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            CMonitorStatus.MonitorBuffer = 0;

            bool bOK = true;

            try
            {
                m_cQue.Clear();

                m_cSource.EnergyConfig = m_cEnergyConfig;
                RunMonitorLogger();
                RunMonitorViewer();
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
			bool bOK = InitMonitorSource();
			if (bOK)
				bOK = RunMonitorSource();

			return bOK;
        }

        protected override bool BeforeStop()
        {
            bool bOK = true;

            StopMonitorSource();
            StopMonitorLogger();
            StopMonitorViewer();

            return bOK;
        }

        protected override bool AfterStop()
        {
            m_cQue.Clear();

            return true;
        }

        protected override void DoThreadWork()
        {
            CEnergyLogS cLogS = null;

            while (m_bRun)
            {
                try
                {
                    cLogS = m_cQue.DeQue();

                    if (cLogS != null)
                    {
                        DoLogRecieved(cLogS);

                        CMonitorStatus.RecieveDataCount += cLogS.Count;
                        if (CMonitorStatus.RecieveDataCount == 1000000)
                            CMonitorStatus.RecieveDataCount = 0; 

                        cLogS.Clear();
                        cLogS = null;
                    }
                    else
                        Thread.Sleep(100);

                    //Monitor Que size
                    CMonitorStatus.MonitorBuffer = m_cQue.Count;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    ex.Data.Clear();
                }
            }
        }

        protected bool RunMonitorViewer()
        {
            StopMonitorViewer();

            if (m_cViewer == null)
                m_cViewer = new CMonitorViewer();

            return m_cViewer.Run();
        }

        protected void StopMonitorViewer()
        {
            if (m_cViewer != null)
                m_cViewer.Stop();
        }

        protected bool RunMonitorLogger()
        {
            StopMonitorLogger();

            if (m_cLogger == null)
                m_cLogger = new CMonitorLogger();

            return m_cLogger.Run();
        }

        protected void StopMonitorLogger()
        {
            if (m_cLogger != null)
                m_cLogger.Stop();
        }

        protected bool InitMonitorSource()
        {
            StopMonitorSource();

            bool bOK = true;

            if (m_cSource != null)
            {
                
                m_cSource.UEventTerminated += new EventHandler(m_cSource_UEventTerminated);
                m_cSource.UEventValueChanged += new UEventHandlerMonitorValueChanged(m_cSource_UEventValueChanged);
            }

            return bOK;
        }

        protected bool RunMonitorSource()
        {
            bool bOK = m_cSource.Run();

            return bOK;
        }

        protected void StopMonitorSource()
        {
            if (m_cSource != null)
            {
                m_cSource.Stop();

                m_cSource.UEventValueChanged -= new UEventHandlerMonitorValueChanged(m_cSource_UEventValueChanged);
            }
        }

        protected void DoLogRecieved(CEnergyLogS cLogS)
        {
            if (m_cViewer.IsRunning)
                m_cViewer.EnQue((CEnergyLogS)cLogS.Clone());

            if (m_cLogger.IsRunning)
                m_cLogger.EnQue((CEnergyLogS)cLogS.Clone());
        }

        #endregion


        #region Event Methods

        private void m_cSource_UEventValueChanged(object sender, CEnergyLogS cLogS)
        {
            EnQue(cLogS);
        }

        private void m_cSource_UEventTerminated(object sender, EventArgs e)
        {
            Stop();

            if (UEventTerminated != null)
                UEventTerminated(this, e);
        }

        #endregion
    }
}
