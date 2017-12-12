using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using UDM.Common;
using UDM.General.Threading;
using UDM.Log;


namespace UDM.Monitor.Energy
{

    public class CMonitorLogger : CThreadWithQueBase<CEnergyLogS>
    {

        #region Member Variables

        public event UEventHandlerMonitorValueChanged UEventValueChanged;
        
        
        #endregion


        #region Initalize/Dispose

        public CMonitorLogger()
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


        private void GenerateValueChangeEvent(CEnergyLogS cLogS)
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
                        GenerateValueChangeEvent(cLogS);
                        cLogS = null;
                    }
                    else
                    {
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
