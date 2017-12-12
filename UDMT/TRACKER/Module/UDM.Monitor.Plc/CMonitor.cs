using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using UDM.General.Threading;
using UDM.Common;
using UDM.Log;
using UDM.Monitor.Plc.Source;
using System.IO;

namespace UDM.Monitor.Plc
{
    public class CMonitor : CThreadWithQueBase<CTimeLogS>
    {

        #region Member Variables

        protected CTagS m_cTagS = null;
        protected CGroupS m_cGroupS = null;
        protected CMonitorSource m_cSource = new CMonitorSource();
        protected CMonitorAnalyser m_cAnalyser = new CMonitorAnalyser();
        protected CMonitorLogger m_cLogger = new CMonitorLogger();
        protected CMonitorViewer m_cViewer = new CMonitorViewer();
        protected EMMonitorType m_emMonitorType = EMMonitorType.Detection;

        public event EventHandler UEventTerminated;
        delegate string dele_RemoveBracketFromKeyAddress(string sKey);

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

        dele_RemoveBracketFromKeyAddress removeBracketDele = s => s.IndexOf('[') > 0 ? s.Substring(0, s.IndexOf('[')) : s;

        #endregion


        #region Public Properties

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        public CGroupS GroupS
        {
            get { return m_cGroupS; }
            set { m_cGroupS = value; }
        }

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

        public EMMonitorType MonitorType
        {
            get { return m_emMonitorType; }
            set { m_emMonitorType = value; }
        }
       
        #endregion


        #region Public Methods

        public new void EnQue(CTimeLogS cLogS)
        {
            base.EnQue(cLogS);
        }

        public void Clear()
        {
            m_cQue.Clear();

            if (m_cTagS != null)
                m_cTagS = null;

            m_cTagS = new CTagS();
        }

        public CTimeLogS ReadInstant(List<CTag> lstTag)
        {
            if (m_bRun == false || m_cSource == null || m_cSource.IsRunning == false)
                return null;

            CTimeLogS cLogS = m_cSource.ReadInstant(lstTag);

            return cLogS;
        }

        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            CMonitorStatus.MonitorBuffer = 0;

            if (m_cTagS == null)
                return false;

            bool bOK = true;

            try
            {
                m_cQue.Clear();

                RunMonitorLogger();
                RunMonitorViewer();
                RunMonitorAnalyser();
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
            StopMonitorAnalyser();
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
            CTimeLogS cLogS = null;
            CTimeLog cLog = null;

            while (m_bRun)
            {
                try
                {
                    cLogS = m_cQue.DeQue();

                    if (cLogS != null)
                    {
                        for (int i = 0; i < cLogS.Count; i++)
                        {
                            cLog = cLogS[i];
                            if (cLog != null && cLog.Key != "")
                                DoLogRecieved(cLog);
                        }

                        CMonitorStatus.RecieveDataCount += cLogS.Count;
                        if (CMonitorStatus.RecieveDataCount == 1000000)
                            CMonitorStatus.RecieveDataCount = 0; 

                        cLogS.Clear();
                        cLogS = null;
                    }
                    else
                        Thread.Sleep(10);

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

        protected bool RunMonitorAnalyser()
        {
            StopMonitorAnalyser();

            m_cAnalyser.GroupS = m_cGroupS;
            m_cAnalyser.UEventGroupStateChanged += new UEventHandlerMonitorGroupStateChanged(m_cAnalyser_UEventGroupStateChanged);

            return m_cAnalyser.Run();
        }

        protected void StopMonitorAnalyser()
        {
            m_cAnalyser.Stop();

            m_cAnalyser.UEventGroupStateChanged -= new UEventHandlerMonitorGroupStateChanged(m_cAnalyser_UEventGroupStateChanged);
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
            m_cSource.TagS = m_cTagS;

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

        protected void DoLogRecieved(CTimeLog cLog)
        {
            if (m_cAnalyser.IsRunning && cLog != null)
                m_cAnalyser.EnQue((CTimeLog)cLog.Clone());

            if (m_cViewer.IsRunning)
                m_cViewer.EnQue((CLogBase)cLog.Clone());

            if (m_cLogger.IsRunning)
                m_cLogger.EnQue((CLogBase)cLog.Clone());
        }

        protected void DoLogRecieved(CGroupLog cLog)
        {
            cLog.MonitorType = m_emMonitorType;

            if (m_cViewer.IsRunning)
                m_cViewer.EnQue((CLogBase)cLog.Clone());

            if (m_cLogger.IsRunning)
                m_cLogger.EnQue((CLogBase)cLog.Clone());
        }

        #endregion


        #region Event Methods

        private void m_cSource_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            EnQue(cLogS);
        }

        private void m_cAnalyser_UEventGroupStateChanged(object sender, CGroupLog cLog)
        {
            DoLogRecieved(cLog);
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
