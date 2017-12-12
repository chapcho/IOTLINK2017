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
    public class CMonitorViewer : CThreadWithQueBase<CLogBase>
    {

        #region Member Variables

        public event UEventHandlerMonitorValueChanged UEventValueChanged;
        public event UEventHandlerMonitorGroupStateChanged UEventGroupStateChanged;

        #endregion


        #region Initalize/Dispose

        public CMonitorViewer()
        {

        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Pubilc Methods


        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            m_cQue.Clear();

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


        private void GenerateValueChangeEvent(CTimeLogS cLogS)
        {
            try
            {
                if (UEventValueChanged != null)
                    UEventValueChanged(this, cLogS);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void GenerateGroupLogEvent(CGroupLog cLog)
        {
            try
            {
                if (UEventGroupStateChanged != null)
                    UEventGroupStateChanged(this, cLog);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected override void DoThreadWork()
        {
            CTimeLogS cLogS = null;
            CLogBase cLog = null;
            Type typeLog;

            while (m_bRun)
            {
                try
                {
                    cLog = m_cQue.DeQue();

                    if (cLog != null)
                    {
                        typeLog = cLog.GetType();
                        if (typeLog == typeof(CTimeLog))
                        {
                            if (cLogS == null)
                                cLogS = new CTimeLogS();

                            cLogS.Add((CTimeLog)cLog);

                            if (cLogS.Count > 99)
                            {
                                GenerateValueChangeEvent(cLogS);
                                cLogS = null;
                            }
                        }
                        else if (typeLog == typeof(CGroupLog))
                        {
                            if (cLogS != null)
                            {
                                GenerateValueChangeEvent(cLogS);
                                cLogS = null;
                            }

                            GenerateGroupLogEvent((CGroupLog)cLog);
                        }
                    }
                    else
                    {
                        if (cLogS != null)
                        {
                            GenerateValueChangeEvent(cLogS);
                            cLogS = null;
                        }

                        Thread.Sleep(100);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                }
            }
        }

        #endregion
    }
}
