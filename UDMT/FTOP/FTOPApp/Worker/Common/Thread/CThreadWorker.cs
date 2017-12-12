using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDM.Log;
using System.Data;

namespace FTOPApp
{
    public class CThreadWorker : CThreadWithQueBase<object>
    {
        public event UEventHandlerMessage UEventMessage = null;
        public event UEventHandlerThreadDequeEvent UEventTheredDeque = null;
        public event UEventHandlerThreadDequeServerEvent UEventTheredServerDeque = null;
        private MSSqlReader _dbWriter = new MSSqlReader();

        public CThreadWorker()
        {

        }

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        #region Thread Event

        protected override bool BeforeRun()
        {
            m_bRun = _dbWriter.Connect();
            if (m_bRun == false)
            {
                UpdateSystemMessage("LogWriter", "DB연결에 실패했습니다.");
                return false;
            }

            return m_bRun;

        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            if (m_bRun == false)
                return false;
            m_bRun = false;

            _dbWriter.Disconnect();

            return m_bRun;

        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {

            while (m_bRun)
            {
                //Thread.Sleep(1);
                try
                {
                    object oData = m_cQue.DeQue();
                    if (oData == null) continue;

                    if (oData.GetType() == typeof(FTag))
                    {
                        UEventTheredDeque(this, (FTag)oData);
                    }
                    else
                    {
                        Console.WriteLine("Not Mathcing Data....");
                    }
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("LogWriter", string.Format("Error Main Roof = {0}", ex.Message));
                    ex.Data.Clear();
                }
            }
    
        }

        #endregion
    }
}
