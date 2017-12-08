using IOTL.Common;
using IOTL.Common.DB;
using IOTL.Common.Log;
using IOTL.Common.Threading;
using System;
using System.Diagnostics;
using System.Threading;

namespace IOTLManager.Util
{
    public class IOTLCompressorLogWriter : ThreadWithQueBase<object>
    {

        private MySqlLogWriter m_cLogDBWriter = null;
        public event UEventHandlerIOTLMessage UEventIOTLMessage = null;
        public event UEventHandlerFileLog UEventFileLog = null;

        public IOTLCompressorLogWriter(String initialDataBaseName)
        {
            m_cLogDBWriter = new MySqlLogWriter(initialDataBaseName);
            m_cLogDBWriter.UEventFileLog += UpdateFileLog; ;
        }

        public MySqlLogWriter LogDBWriter
        {
            get { return m_cLogDBWriter; }
        }

        public bool IsConnected
        {
            get
            {
                if (m_cLogDBWriter is null)
                {
                    return false;
                }

                return m_cLogDBWriter.IsConnected;
            }
        }



        #region Base Class Inheritanced Method (추상클래스로 부터 상속받은 클래스 구현)

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool AfterStop()
        {
            m_cLogDBWriter.UEventFileLog -= UpdateFileLog;
            return true;
        }

        protected override bool BeforeRun()
        {
            m_bRun = m_cLogDBWriter.Connect();
            if (m_bRun == false)
            {
                UpdateSystemMessage(sender:System.Reflection.MethodBase.GetCurrentMethod().Name, message:"DB연결에 실패했습니다.");
            }
            else
            {
                UpdateSystemMessage(sender: System.Reflection.MethodBase.GetCurrentMethod().Name, message: "DB에 연결되었습니다.");
            }

            return m_bRun;
        }

        private void UpdateFileLog(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string logMessage)
        {
            if (UEventFileLog != null)
                UEventFileLog(emFileLogType, emFileLogDepth, logMessage);
        }

        private void UpdateSystemMessage(string sender, string message)
        {
            if (UEventIOTLMessage != null)
                UEventIOTLMessage(sender, message);
        }

        protected override bool BeforeStop()
        {
            if (m_bRun == false)
                return false;

            m_bRun = false;
            m_cLogDBWriter.Disconnect();

            return m_bRun;
        }

        protected override void DoThreadWork()
        {
            int iStep = 0;
            int iGCCount = 0;
            bool bOK = false;
            Stopwatch swMain = new Stopwatch();

            while (m_bRun)
            {
                Thread.Sleep(10);

                try
                {
                    object oData = m_cQue.DeQue();

                    if (oData == null)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    if (!LogDBWriter.IsConnected)
                        LogDBWriter.Connect();

                    if (oData.GetType() == typeof(CTimeLogS))
                    {
                        CTimeLogS cLogS = (CTimeLogS)oData;

                        bOK = LogDBWriter.WriteTimeLogS(cLogS);

                        //Memory 최적화
                        cLogS.Dispose();
                        cLogS = null;
                    }
                    else if(oData.GetType() == typeof(CTimeLog))
                    {
                        // bOK = LogDBWriter.WriteTimeLog((CTimeLog)oData);
                        bOK = LogDBWriter.WriteIOTLCompDataSingle((CTimeLog)oData);
                    }
                    //else if (oData.GetType() == typeof(CCycleInfo))
                    //{
                    //    CCycleInfo cCycleInfo = (CCycleInfo)oData;
                    //    iStep = 3;
                    //    m_cWriter.WriteCycleInfo(cCycleInfo);
                    //    iStep = 4;
                    //    UpdateSystemMessage("LogWriter", string.Format("Cycle Info : ID = {0}, Group : {1}", cCycleInfo.CycleID, cCycleInfo.GroupKey));

                    //    //Memory 최적화
                    //    cCycleInfo = null;
                    //}
                    //else if (oData.GetType() == typeof(CErrorInfo))
                    //{
                    //    CErrorInfo cErrorInfo = (CErrorInfo)oData;
                    //    iStep = 5;
                    //    bOK = m_cWriter.WriteErrorInfo(cErrorInfo);
                    //    iStep = 6;
                    //    if (bOK)
                    //        UpdateSystemMessage("LogWriter", string.Format("Error Info Write OK : ID = {0}", cErrorInfo.ErrorID));
                    //    else
                    //        UpdateSystemMessage("LogWriter", string.Format("Error Info Write Error : ID = {0}", cErrorInfo.ErrorID));

                    //    iStep = 7;
                    //    if (cErrorInfo.ErrorLogS.Count > 0)
                    //        m_cWriter.WriteErrorLogS(cErrorInfo.ErrorID, cErrorInfo.ErrorLogS);
                    //    iStep = 8;

                    //    //Memory 최적화
                    //    cErrorInfo.ErrorLogS.Dispose();
                    //    cErrorInfo = null;
                    //}

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

        #endregion


    }
}
