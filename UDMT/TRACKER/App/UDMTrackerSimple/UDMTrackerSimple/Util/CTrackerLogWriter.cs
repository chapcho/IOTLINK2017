using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
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
                UpdateSystemMessage(sSender: System.Reflection.MethodBase.GetCurrentMethod().Name, sMessage: "DB연결에 실패했습니다.");
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
            CMultiProject.CurrentCollectSymbolS.EndTime = DateTime.Now;
            CMultiProject.CurrentCollectSymbolS.WriteCSVData();

            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            int iStep = 0;
            int iGCCount = 0;
            bool bOK = false;
            Stopwatch swMain = new Stopwatch();
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    object oData = m_cQue.DeQue();

                    if (oData == null) continue;

                    if (!m_cWriter.IsConnected)
                        m_cWriter.Connect();

                    if (oData.GetType() == typeof(CTimeLogS))
                    {
                        CTimeLogS cLogS = (CTimeLogS)oData;
                        iStep = 1;
                        bOK = m_cWriter.WriteTimeLogS(cLogS);
                        iStep = 2;
                        //if (bOK)
                        //{
                        //    if (iGCCount == 0) m_cWriter.WriteTagStatus_Start(CMultiProject.ProjectID, cLogS, CMultiProject.TotalTagS);
                        //    else m_cWriter.WriteTagStatus_Update(CMultiProject.ProjectID, cLogS);
                        //}
                        foreach (CTimeLog log in cLogS)
                        {
                            if (CMultiProject.TotalTagS.ContainsKey(log.Key))
                                CMultiProject.TotalTagS[log.Key].LogCount++;
                            if (CMultiProject.CurrentCollectSymbolS != null && CMultiProject.CurrentCollectSymbolS.ContainsKey(log.Key))
                            {
                                CMultiProject.CurrentCollectSymbolS[log.Key].ChangeCount++;
                                CMultiProject.CurrentCollectSymbolS[log.Key].LastUpdateTime = log.Time;
                                CMultiProject.CurrentCollectSymbolS[log.Key].Value = log.SValue;
                                CMultiProject.CurrentCollectSymbolS.TotalChangeCount++;
                            }
                        }
                        //Memory 최적화
                        cLogS.Dispose();
                        cLogS = null;
                    }
                    else if (oData.GetType() == typeof(CCycleInfo))
                    {
                        CCycleInfo cCycleInfo = (CCycleInfo)oData;
                        iStep = 3;
                        m_cWriter.WriteCycleInfo(cCycleInfo);
                        iStep = 4;
                        UpdateSystemMessage("LogWriter", string.Format("Cycle Info : ID = {0}, Group : {1}", cCycleInfo.CycleID, cCycleInfo.GroupKey));

                        //Memory 최적화
                        cCycleInfo = null;
                    }
                    else if (oData.GetType() == typeof(CErrorInfo))
                    {
                        CErrorInfo cErrorInfo = (CErrorInfo)oData;
                        iStep = 5;
                        bOK = m_cWriter.WriteErrorInfo(cErrorInfo);
                        iStep = 6;
                        if(bOK)
                            UpdateSystemMessage("LogWriter", string.Format("Error Info Write OK : ID = {0}", cErrorInfo.ErrorID));
                        else
                            UpdateSystemMessage("LogWriter", string.Format("Error Info Write Error : ID = {0}", cErrorInfo.ErrorID));

                        iStep = 7;
                        if (cErrorInfo.ErrorLogS.Count > 0)
                            m_cWriter.WriteErrorLogS(cErrorInfo.ErrorID, cErrorInfo.ErrorLogS);
                        iStep = 8;

                        //Memory 최적화
                        cErrorInfo.ErrorLogS.Dispose();
                        cErrorInfo = null;
                    }

                    iGCCount++;

                    if (iGCCount % 100000 == 0)
                    {
                        Thread.Sleep(1);
                        UpdateSystemMessage("Log Writer", string.Format("GC Collect 수행 Start {0:N0}", GC.GetTotalMemory(false)));
                        GC.Collect();
                        UpdateSystemMessage("Log Writer", string.Format("GC Collect 수행 End {0:N0}", GC.GetTotalMemory(true)));
                    }

                    oData = null;
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("LogWriter", string.Format("Error Main Roof = {0}, Fail Step : {1}", ex.Message, iStep));
                    ex.Data.Clear();
                }
            }
        }

    }
}
