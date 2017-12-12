using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using TrackerSPD.DDEA;
using TrackerSPD.LS;
using TrackerSPD.OPC;
using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;


namespace UDMTrackerSimple
{
    public class CProjectRealTimeLadderView : IDisposable
    {
        #region Member Varialbes

        protected string m_sName = "";
        protected string m_sSaveLogPath = @"D:\RealTimeLadderViewLog";
        protected int m_iSaveLogTime = 1;
        protected int m_iMaxLogfileCount = 10;
       
        protected CStepS m_cStepS = new CStepS();
        protected CSymbolS m_cSymbolS = new CSymbolS();

        protected CPlcConfig m_cPlcConfig = new CPlcConfig();
        protected CDDEAConfigMS m_cDDEAConfig = null;
        protected COPCConfig m_cOPCConfig = new COPCConfig();
        protected CLsConfig m_cLsConfig = new CLsConfig();
        protected EMPLCMaker m_emPlcMaker = EMPLCMaker.LS;
        protected EMCollectType m_emEMCollectType = EMCollectType.OPC;
        
        protected List<string> m_lstLogFilePath = new List<string>();

        [NonSerialized]
        protected bool m_bRun = false;
        [NonSerialized]
        protected CDDEARead m_cReader = null;
        [NonSerialized]
        protected CLsReader m_cLsReader = null;
        [NonSerialized]
        protected CDDEATask m_cLogTask = null;
        [NonSerialized]
        protected CTimeLogS m_cTimeLogS = null;
        [NonSerialized]
        protected CDDEASymbolS m_cDDEASymbolS = null;

        public event UEventHandlerMainMessage UEventMessage;

        #endregion

        #region Inialize/Dispose

        public CProjectRealTimeLadderView()
        {

        }

        public void Dispose()
        {
            //Clear();
        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string SaveLogPath
        {
            get { return m_sSaveLogPath; }
            set { m_sSaveLogPath = value; }
        }

        public int SaveLogFileTime
        {
            get { return m_iSaveLogTime; }
            set { m_iSaveLogTime = value; }
        }

        public int MaxLogFileCount
        {
            get { return m_iMaxLogfileCount; }
            set { m_iMaxLogfileCount = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

        public CSymbolS SymbolS
        {
            get { return m_cSymbolS; }
            set { m_cSymbolS = value; }
        }

        public List<string> LogFilePathList
        {
            get { return m_lstLogFilePath; }
            set { m_lstLogFilePath = value; }
        }

        public EMCollectType CollectorType
        {
            get { return m_emEMCollectType; }
            set { m_emEMCollectType = value; }
        }

        public bool Run
        {
            get { return m_bRun; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        public CDDEASymbolS DDEASymbolS
        {
            get { return m_cDDEASymbolS; }
        }

        public CPlcConfig PlcCnfig
        {
            get { return m_cPlcConfig; }
            set { m_cPlcConfig = value; }
        }

        #endregion

        #region Public Method

        public bool CollectStart()
        {
            if (m_bRun) return false;

            if (m_emEMCollectType == EMCollectType.DDEA)
            {
                m_bRun = RunDDEACollect();
            }
            else if (m_emEMCollectType == EMCollectType.LSDDE)
            {
            }
            else
            {
            }

            return m_bRun;
        }

        public bool CollectStop()
        {
            try
            {
                if (!m_bRun) return true;

                if (m_emEMCollectType == EMCollectType.OPC)
                {
                    m_cLogTask.Stop();

                    m_cLogTask.UEventMessage -= m_cLogTask_UEventMessage;
                    m_cLogTask.Dispose();

                    m_lstLogFilePath = m_cLogTask.NowLogFilePathList;

                    m_cLogTask = null;
                }
                else
                {
                    m_cReader.Stop();
                    m_cReader.UEventMessage -= m_cReader_UEventMessage;
                    m_cReader.Dispose();

                    m_lstLogFilePath = m_cReader.LogFilePathList;

                    m_cReader = null;
                }

                m_bRun = false;

                GetTimeLogS(m_lstLogFilePath.ToArray());

            }
            catch(Exception ex)
            {
                m_bRun = true;
                throw ex;
            }
            return m_bRun;

        }

        #endregion



        #region Private Method
        private bool RunDDEACollect()
        {
            try
            {
                CDDEAProject cDDEAProject = new CDDEAProject(m_sName);
                cDDEAProject.Config = m_cPlcConfig.MelsecConfig;
                cDDEAProject.SetNormalBundleList(m_cSymbolS);
                cDDEAProject.CollectMode = EMCollectMode.Normal;
                cDDEAProject.ConnectApp = EMConnectAppType.Profiler;
                cDDEAProject.LogSavePath = m_sSaveLogPath;
                cDDEAProject.LogSaveTime = 1;

                CDDEASymbolS cSymbolS = new CDDEASymbolS();
                foreach (CNormalMode nor in cDDEAProject.NormalBundleList)
                {
                    cSymbolS.AddSymbolList(nor.BitSymbolList);
                    cSymbolS.AddSymbolList(nor.WordSymbolList);
                    cSymbolS.AddSymbolList(nor.IndexSymbolList);
                    cSymbolS.AddSymbolList(nor.IncludeIndexSymbolList);
                }
                if (cDDEAProject.NormalBundleList.Count == 0)
                    return false;

                m_cReader = new TrackerSPD.DDEA.CDDEARead(cDDEAProject, m_cPlcConfig.MelsecConfig.MelsecSeriesType);
                m_cReader.UEventMessage += m_cReader_UEventMessage;

                bool bOK = m_cReader.Run();
                if (bOK == false)
                {
                    return false;
                }
                m_cDDEASymbolS = cSymbolS;
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }



        private void GetTimeLogS(string[] saPath)
        {
            CCsvLogReader cLogReader = new CCsvLogReader();
            bool bOK = cLogReader.Open(saPath);
            if (bOK)
                m_cTimeLogS = cLogReader.ReadTimeLogS();
            else
                m_cTimeLogS = null;
        }
        #endregion


        #region Event

        void m_cReader_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (m_cReader != null && UEventMessage != null)
            {
                if (sSender == "NewLogPath")
                    m_lstLogFilePath.Add(sMessage);
                else
                    UEventMessage(sender, sSender, sMessage);
            }
        }

        void m_cLogTask_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (m_cLogTask != null && UEventMessage != null)
            {
                UEventMessage(sender, sSender, sMessage);
            }
        }

        void Source_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            if (m_cLogTask != null)
            {
                m_cLogTask.EventDataChanged(cLogS);

                foreach (CTimeLog log in cLogS)
                {
                    if (this.SymbolS.ContainsKey(log.Key))
                    {
                        this.SymbolS[log.Key].ChangeCount++;
                        this.SymbolS[log.Key].CurrentValue = log.Value.ToString();
                    }
                }
            }
        }
        #endregion
    }
}
