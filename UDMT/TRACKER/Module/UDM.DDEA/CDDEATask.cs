using System;
using UDM.Log;
using UDM.Log.Csv;
using System.IO;
using UDM.General.Threading;
using System.Collections.Generic;

namespace UDM.DDEA
{
    public class CDDEATask : CThreadWithQueBase<CTimeLogS>
    {
        #region Member Variables

        protected CCsvLogWriter m_cCSVLogWrite = new CCsvLogWriter();

        protected string m_sProjectName = string.Empty;
        protected string m_sProjectPath = string.Empty;
        protected DateTime m_dtFileCreated = DateTime.MinValue;
        protected int m_iCollectTime = 10;
        protected int m_iMaxLogFilePathCount = 10;
        protected bool m_bStartFlag = true;
        protected bool m_bStopFlag = false;
        protected CDDEAProject m_cProject;
        public event UEventHandlerMainMessage UEventMessage;

        #endregion

        #region Initialize/Dispose

        public CDDEATask(CDDEAProject cProject)
        {
            m_cProject = cProject;
            m_sProjectPath = m_cProject.LogSavePath;
            m_sProjectName = m_cProject.Name;
        }

        public CDDEATask(string sProjName, string sBasePath, int iLogSaveTime, int iMaxFileCount)
        {
            m_cProject = new CDDEAProject("");
            m_cProject.LogSavePath = sBasePath;
            m_cProject.LogSaveTime = iLogSaveTime;
            m_cProject.Name = sProjName;
            m_sProjectName = sProjName;
            m_sProjectPath = sBasePath;
            m_iMaxLogFilePathCount = iMaxFileCount;
        }

        #endregion


        #region Properties

        public List<string> NowLogFilePathList
        {
            get { return m_cProject.LogFilePahtList; }
        }

        #endregion


        #region Public Methods

        #endregion

        #region Private Method

        private bool CreateCSV(DateTime dtTime)
        {
            try
            {
                if (m_sProjectPath == "" || m_sProjectPath == string.Empty)
                    m_sProjectPath = "C:";
                string path = "";
                //if (m_cProject.CollectMode == EMCollectMode.Frag)
                //    path = m_sProjectPath + "\\LogData\\" + m_sProjectName + "\\전체수집\\";
                //else if (m_cProject.CollectMode == EMCollectMode.StandardCoil)
                //    path = m_sProjectPath + "\\LogData\\" + m_sProjectName + "\\출력수집\\";
                //else
                //    path = m_sProjectPath + "\\LogData\\" + m_sProjectName + "\\부분수집\\";

                path = m_sProjectPath + "\\" + m_sProjectName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string sFile = string.Empty;

                if (m_bStartFlag == false)
                {
                    //if (m_cProject.CollectMode == EMCollectMode.Frag)
                    //    sFile = string.Format(path + @"\{0}_Fragment_{1}.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    //else if (m_cProject.CollectMode == EMCollectMode.StandardCoil)
                    //    sFile = string.Format(path + @"\{0}_Standard_{1}.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    //else
                    //    sFile = string.Format(path + @"\{0}_Normal_{1}.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    sFile = string.Format(path + @"\{0}_{1}.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                }
                else
                {
                    //if (m_cProject.CollectMode == EMCollectMode.Frag)
                    //    sFile = string.Format(path + @"\{0}_Fragment_{1}_Start.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    //else if (m_cProject.CollectMode == EMCollectMode.StandardCoil)
                    //    sFile = string.Format(path + @"\{0}_Standard_{1}_Start.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    //else
                    //    sFile = string.Format(path + @"\{0}_Normal_{1}_Start.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    sFile = string.Format(path + @"\{0}_{1}_Start.csv", m_sProjectName, dtTime.ToString("HHmmss"));
                    m_bStartFlag = false;
                }
                if (!File.Exists(sFile))
                {
                    bool bOK = m_cCSVLogWrite.Open(sFile);
                    if (!bOK)
                        return false;

                    SetEventMessage("파일 생성 : " + sFile);
                    if (m_cProject.LogFilePahtList.Count > m_iMaxLogFilePathCount)
                    {
                        m_cProject.LogFilePahtList.Add(sFile);
                        List<string> lstLast10Path = new List<string>();
                        for (int i = 1; i <= m_iMaxLogFilePathCount; i++)
                        {
                            int iIndex = m_cProject.LogFilePahtList.Count - i;
                            lstLast10Path.Add(m_cProject.LogFilePahtList[iIndex]);
                        }
                        m_cProject.LogFilePahtList = lstLast10Path;
                    }
                    else
                        m_cProject.LogFilePahtList.Add(sFile);

                    SetEventMessage("NewLogPath", sFile);
                }
            }
            catch (Exception ex)
            {
                SetEventMessage("파일 생성 중 문제 발생 : " + ex.Message);
                return false;
            }

            return true;
        }

        private void SetEventMessage(string sMessage)
        {
            if (UEventMessage != null)
                UEventMessage(this, "LogWrite", sMessage);
        }

        private void SetEventMessage(string sSender, string sMessage)
        {
            if (UEventMessage != null)
                UEventMessage(this, sSender, sMessage);
        }

        #endregion

        #region Event handler

        public void EventDataChanged(CTimeLogS cSymbolLogS)
        {
            if (cSymbolLogS != null)
                m_cQue.EnQue((CTimeLogS)cSymbolLogS.Clone());
        }

        #endregion

        #region Thread Method

        protected override bool BeforeRun()
        {
            m_bStopFlag = false;
            DateTime dtNow = DateTime.Now;
            m_dtFileCreated = dtNow;
            m_iCollectTime = m_cProject.LogSaveTime;
            m_sProjectPath = m_cProject.LogSavePath;
            m_sProjectName = m_cProject.Name;
            m_bRun = CreateCSV(dtNow);
            
            return m_bRun;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            SetEventMessage("로그 기록을 중지 합니다.");
            m_cCSVLogWrite.Close();
            
            m_bStopFlag = true;
            m_bRun = false;
            return true;
        }


        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            while (m_bRun)
            {
                System.Threading.Thread.Sleep(1);
                if (m_cQue.Count == 0) continue;

                CTimeLogS cSymbolLogS = m_cQue.DeQue();

                if (cSymbolLogS != null)
                {
                    DateTime dtNow = DateTime.Now;
                    try
                    {
                        TimeSpan tsSpan = dtNow.Subtract(m_dtFileCreated);
                        
                        m_cCSVLogWrite.WriteTimeLogS(cSymbolLogS);
                        if (tsSpan.TotalMinutes > m_iCollectTime)
                        {
                            m_dtFileCreated = dtNow;
                            m_cCSVLogWrite.Close();
                            CreateCSV(dtNow);
                        }
                        cSymbolLogS.Clear();
                        cSymbolLogS = null;
                    }
                    catch (Exception ex)
                    {
                        SetEventMessage("로그 기록 중 문제가 발생 : " + ex.Message);
                        ex.Data.Clear();
                    }
                }
            }
        }
        #endregion
    }
}
