using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General.Threading;
using UDM.Log;

namespace UDM.Monitor.Energy
{
    public class CMeterLogger : CThreadWithQueBase<CMeterData>
    {
        public event UEventHandlerMeterMonitorDataRead UEventDataRead;

        #region Initialize/Dispose

        public CMeterLogger()
        {

        }

        #endregion

        #region Private Methods

        protected override bool BeforeRun()
        {
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
            CEnergyLog clog = CAccura3300SDataTranslator.TranslatData(cData);

            if (UEventDataRead != null)
                UEventDataRead(this, clog);
        }

        #endregion
    }
}
