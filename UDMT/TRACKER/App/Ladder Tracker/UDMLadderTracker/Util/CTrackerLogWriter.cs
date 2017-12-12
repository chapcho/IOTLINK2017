using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMLadderTracker
{
    public class CTrackerLogWriter : CThreadWithQueBase<object>
    {
        #region Member Variables

        private CMySqlLogWriter m_cWriter = new CMySqlLogWriter();
        public event UEventHandlerTrackerMessage UEventMessage = null;

        #endregion

        #region Properties

        public CMySqlLogWriter LogWriter
        {
            get { return m_cWriter; }
        }

        public bool IsConnected
        {
            get
            {
                if (m_cWriter == null)
                    return false;
                return m_cWriter.IsConnected;
            }
        }

        #endregion

        #region Privete Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        #endregion

        protected override bool BeforeRun()
        {
            m_bRun = m_cWriter.Connect();
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

            m_cWriter.Disconnect();

            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            Stopwatch swMain = new Stopwatch();
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    object oData = m_cQue.DeQue();

                    if (oData == null) continue;

                    if(oData.GetType() == typeof(CTimeLogS))
                    {
                        CTimeLogS cLogS = (CTimeLogS)oData;
                        m_cWriter.WriteTimeLogS(cLogS);
                        foreach (CTimeLog log in cLogS)
                        {
                            if (CMultiProject.TotalTagS.ContainsKey(log.Key))
                                CMultiProject.TotalTagS[log.Key].LogCount++;
                        }

                        //Memory 최적화
                        cLogS.Dispose();
                    }
                    else if (oData.GetType() == typeof(CCycleInfo))
                    {
                        CCycleInfo cCycleInfo = (CCycleInfo)oData;
                        m_cWriter.WriteCycleInfo(cCycleInfo);

                        UpdateSystemMessage("LogWriter", string.Format("Cycle Info : ID = {0}, Group : {1}", cCycleInfo.CycleID, cCycleInfo.GroupKey));

                        //Memory 최적화
                        cCycleInfo = null;
                    }
                    else if (oData.GetType() == typeof(CErrorInfo))
                    {
                        CErrorInfo cErrorInfo = (CErrorInfo)oData;

                        bool bOK = m_cWriter.WriteErrorInfo(cErrorInfo);

                        if(bOK)
                            UpdateSystemMessage("LogWriter", string.Format("Error Info Write OK : ID = {0}", cErrorInfo.ErrorID));
                        else
                            UpdateSystemMessage("LogWriter", string.Format("Error Info Write Error : ID = {0}", cErrorInfo.ErrorID));

                        if (cErrorInfo.ErrorLogS.Count > 0)
                            m_cWriter.WriteErrorLogS(cErrorInfo.ErrorID, cErrorInfo.ErrorLogS);

                        //Memory 최적화
                        cErrorInfo.ErrorLogS.Dispose();
                        cErrorInfo = null;
                    }
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("LogWriter", string.Format("Error Main Roof = {0}", ex.Message));
                    ex.Data.Clear();
                }
            }
        }

    }
}
