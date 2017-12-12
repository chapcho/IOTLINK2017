using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General.Threading;

namespace UDMEnergyViewer
{
    public class CMeterLogger : CThreadWithQueBase<CMeterData>
    {

        #region Member Variables

        public event UEventHandlerMeterMonitorDataRead UEventDataRead;

        #endregion


        #region Initialize/Dispose

        public CMeterLogger()
        {
            
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        protected override bool BeforeRun()
        {
            CMeterThreadStatus.Count = 0;
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
            CMeterData cData = null;

            while (m_bRun)
            {
                try
                {
                    cData = m_cQue.DeQue();

                    CMeterThreadStatus.Count = m_cQue.Count;

                    if (cData != null)
                        GenerateDataReadEvent(cData);
                    else
                        System.Threading.Thread.Sleep(100);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    ex.Data.Clear();
                }
            }
        }

        protected void GenerateDataReadEvent(CMeterData cData)
        {
            if (UEventDataRead != null)
                UEventDataRead(this, cData);
        }

        #endregion
    }
}
