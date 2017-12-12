using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using UDM.Common;
using UDM.General.Threading;
using UDM.Log;

namespace UDM.Monitor.Plc
{
    public class CMonitorAnalyser : CThreadWithQueBase<CTimeLog>
    {

        #region Member Variables

        protected CGroupS m_cGroupS = null;
        protected CMonitorGroupS m_cMonitorGroupS = null;

        public event UEventHandlerMonitorGroupStateChanged UEventGroupStateChanged;

        #endregion


        #region Initalize/Dispose

        public CMonitorAnalyser()
        {

        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties

        public CGroupS GroupS
        {
            get { return m_cGroupS; }
            set { m_cGroupS = value; }
        }

        #endregion


        #region Pubilc Methods

        public void Clear()
        {
            ClearQue();
        }

        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            Clear();

            if (m_cMonitorGroupS != null)
            {
                m_cMonitorGroupS.Clear();
                m_cMonitorGroupS = null;
            }

            m_cMonitorGroupS = new CMonitorGroupS(m_cGroupS);

            return true;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            return true;
        }

        protected override bool AfterStop()
        {
            return true;
        }

        protected override void DoThreadWork()
        {
            DateTime dtNextTimeTick = DateTime.MinValue;
            DateTime dtCurrent = DateTime.MinValue;
            CTimeLog cLog;
            CGroupLogS cGroupLogS;

            while (m_bRun)
            {
                try
                {                    
                    cLog = m_cQue.DeQue();

                    if (cLog != null)
                    {
                        cGroupLogS = m_cMonitorGroupS.AddLog(cLog);
                        if (cGroupLogS != null)
                            DoGroupStateChanged(cGroupLogS);
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }

                    // Time out checking
                    dtCurrent = DateTime.Now;
                    if (dtCurrent > dtNextTimeTick)
                    {
                        cGroupLogS = m_cMonitorGroupS.CheckTimeOut(dtCurrent);
                        if (cGroupLogS != null)
                            DoGroupStateChanged(cGroupLogS);

                        dtNextTimeTick = dtCurrent.AddSeconds(1);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                }
            }
        }       

        private void DoGroupStateChanged(CGroupLogS cLogS)
        {
            CGroupLog cLog;
            for (int i = 0; i < cLogS.Count; i++)
            {
                cLog = cLogS[i];
                if (UEventGroupStateChanged != null)
                    UEventGroupStateChanged(this, cLog);
            }
        }

        #endregion
    }
}
