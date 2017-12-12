using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;
using UDM.Log.Energy;
using UDM.General.ThreadEx;
using System.Threading;

namespace UDM.EnergyDaq.Monitor
{
    public class CEnergyMonitor:CThreadQueBase<CEnergyLogS>
    {
        #region Member Variables

        protected CMonitorSource m_cSource = new CMonitorSource();
        protected CConfigS m_cConfigS = null;
        public event EventHandler UEventTerminated;
        public UEventHandlerMonitorLogDeQue UEventMonitorDeQue;
        #endregion


        #region Initilaize/Dispose
        public CEnergyMonitor()
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
            get{return m_cSource;}
            set{m_cSource = value;}
        }

        public CConfigS ConfigS
        {
            get { return m_cConfigS; }
            set { m_cConfigS = value; }
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

                m_cSource.EnergyConfigS = m_cConfigS;
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

        protected void DoLogRecieved(CEnergyLogS cLogS)
        {
            GenerateMonitorDeQueEvent(cLogS);
        }

        protected bool InitMonitorSource()
        {
            StopMonitorSource();

            bool bOK = true;

            if (m_cSource != null)
            {

                m_cSource.UEventTerminated += new EventHandler(m_cSource_UEventTerminated);
                m_cSource.UEventMeterLogCreate += new UEventHandlerMeterLogCreate(m_cSource_UEventSourceDataRead);
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

                m_cSource.UEventMeterLogCreate -= new UEventHandlerMeterLogCreate(m_cSource_UEventSourceDataRead);
            }
        }

        protected void GenerateMonitorDeQueEvent(CEnergyLogS cLogs)
        {
            if (UEventMonitorDeQue != null)
                UEventMonitorDeQue(this, cLogs);
        }

        #endregion


        #region Event Methods

        private void m_cSource_UEventSourceDataRead(object sender, CEnergyLogS cLogS)
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
