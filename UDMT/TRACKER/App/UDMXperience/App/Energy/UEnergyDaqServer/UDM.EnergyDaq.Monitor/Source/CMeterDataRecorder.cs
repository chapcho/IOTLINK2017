using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.General.ThreadEx;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
{
    public class CMeterDataRecorder:CThreadQueBase<CMeterData>
    {
        public event UEventHandlerMeterMonitorDataRead UEventDataRead;

        #region Initialize/Dispose

        public CMeterDataRecorder()
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
            CEnergyLogS cLogS = CMeterValueTranslator.EnergyDataConvertor(cData);

            if (UEventDataRead != null)
                UEventDataRead(this, cLogS);
        }

        #endregion
    }
}
