﻿using IOTL.Common;
using IOTL.Common.DB;
using IOTL.Common.Log;
using IOTL.Common.Threading;
using IOTLManager.CsvLog;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace IOTLManager.Util
{
    public class IOTLCompressorLogWriter : ThreadWithQueBase<object>
    {
        private MySqlLogWriter m_cLogDBWriter = null;
        // 수신한 데이터를 이후에  Import 할 수 있는 형태로 저장하기 위해.
        protected CCsvLogWriter m_cCSVLogWrite = new CCsvLogWriter();

        protected DateTime m_dtFileCreated = DateTime.MinValue;
        protected string m_sProjectName = string.Empty;
        protected string m_sProjectPath = "C:\\Log";

        public event UEventHandlerIOTLMessage UEventIOTLMessage = null;
        public event UEventHandlerFileLog UEventFileLog = null;

        public IOTLCompressorLogWriter(ConfigMariaDB dbConnectionInfo)
        {
            m_cLogDBWriter = new MySqlLogWriter(dbConnectionInfo);
            m_cLogDBWriter.UEventFileLog += UpdateFileLog; ;
        }

        public MySqlLogWriter LogDBWriter
        {
            get { return m_cLogDBWriter; }
        }

        public string ProjectPath
        {
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
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

            DateTime dtNow = DateTime.Now;
            

            // Compressor로 부터 받은 데이터를 기록.
            m_bRun = CreateCSV(dtNow);

            return m_bRun;
        }

        private bool CreateCSV(DateTime dtNow)
        {
            string path = m_sProjectPath;

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string sFile = m_sProjectPath + "\\" + "iotlCompLog"+ dtNow.ToString("yyyyMMddHHmmssfff")+".csv";

                if (!File.Exists(sFile))
                {
                    bool bOK = m_cCSVLogWrite.Open(sFile);
                    if (!bOK)
                        return false;

                    m_dtFileCreated = dtNow;

                    UpdateSystemMessage(this.ToString(), "파일 생성 : " + sFile);
                }
                return true;
            }
            catch(Exception ex)
            {
                UpdateSystemMessage(this.ToString(), "Error : 파일 생성 중 문제 발생(" + ex.Message + ")");
                return false;
            }
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
            m_cCSVLogWrite.Close();

            return m_bRun;
        }

        protected override void DoThreadWork()
        {
            int iStep = 0;
            int iGCCount = 0;
            bool bOK = false;
            int iRetVal = 0;
            int iSleepCount = 0;
            Stopwatch swMain = new Stopwatch();

            while (m_bRun)
            {
                Thread.Sleep(10);

                try
                {
                    object oData = m_cQue.DeQue();

                    if (oData == null)
                    {
                        Thread.Sleep(90);
                        // DB 연결이 오래도록 활성화 되지 않은면, 끊어 지는 문제를 처리 해야 한다.
                        iSleepCount++;
                        if(iSleepCount > 10000) // 통신이 없는 900초 마다 세션 재시작.
                        {
                            if (LogDBWriter.IsConnected)
                            {
                                LogDBWriter.Disconnect();
                                Thread.Sleep(200);
                                LogDBWriter.Connect();
                                if(LogDBWriter.IsConnected)
                                    UpdateSystemMessage("Log Writer", "Refresh DB Connection !");
                                else
                                    UpdateSystemMessage("Log Writer", "[Error] DB Connection Fail !!!");
                            }

                            iSleepCount = 0;
                        }
                        continue;
                    }
                    else
                    {
                        iSleepCount = 0;
                    }

                    DateTime dtNow = DateTime.Now;
                    TimeSpan tsSpan = dtNow.Subtract(m_dtFileCreated);

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
                        iRetVal = CompressorLogWriterProc((CTimeLog)oData);

                        if(!((CTimeLog)oData).ReadFromCSV)
                            bOK = m_cCSVLogWrite.WriteTimeLog((CTimeLog)oData);
                    }

                    // Log 파일은 1시간마다 생성한다.
                    if (tsSpan.TotalMinutes > 60)
                    {
                        m_cCSVLogWrite.Close();
                        CreateCSV(dtNow);
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

        private int CompressorLogWriterProc(CTimeLog oData)
        {
            int iRetVal = 0;
            string resultMessage = string.Empty;

            iRetVal = LogDBWriter.SaveCompressorMachineLogSingle((CTimeLog)oData);

            switch(iRetVal)
            {
                case 1:
                    resultMessage = "Ok";
                    break;
                case 0:
                    resultMessage = "No Register:등록되지 않은 단말로 부터의 데이터 수신";
                    break;
                default:
                    resultMessage = "수신한 Socket Data 처리중 확인 되지 않은 오류가 있습니다. resultCode :" + iRetVal.ToString();
                    break;
            }

            UpdateSystemMessage("IOTLCompressorLogWriter", resultMessage);

            return iRetVal;
        }

        #endregion


    }
}
