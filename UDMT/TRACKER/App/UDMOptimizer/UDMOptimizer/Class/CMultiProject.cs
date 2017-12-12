using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.General.Serialize;
using UDM.Log;
using UDM.Log.DB;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ionic.Zip;
using UDM.Log.Csv;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TrackerProject;

namespace UDMOptimizer
{
    public static class CMultiProject
    {
        #region Member Variables

        //Base Info(단일 파일)
        private static CProjectBaseInfo m_cBaseInfo = new CProjectBaseInfo();
        //MasterPattern Info(단일 파일)
        private static CProjectMasterPatternInfo m_cMasterPatternInfo = new CProjectMasterPatternInfo();
        //PLC별 Logic Data(개별 파일)
        private static CPlcLogicDataS m_cPlcLogicDataS = new CPlcLogicDataS();
        //PLC별 통신 설정(단일 파일)
        private static CPlcConfigS m_cPlcConfigS = new CPlcConfigS();
        //Cycle Log
        private static CCycleAnalyDataS m_cCycleAnalyDataS = new CCycleAnalyDataS();

        //휘발성 Data
        private static string m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
        private static CTagS m_cTotalTagS = new CTagS();
        private static List<string> m_lstUsedProjectID = new List<string>();
        private static CMySqlLogReader m_cReader = null;
        private static CSystemLog m_cSysLog = null;
        private static CTimeLogS m_cTimeLogS = new CTimeLogS();
        //private static Dictionary<DateTime, CTimeLogS> m_dicTimeLogS = new Dictionary<DateTime, CTimeLogS>();
        private static bool m_bEditable = true;
        private static int m_iErrorCur = 0;
        private static CErrorInfoS m_cErrorInfoS = new CErrorInfoS();
        private static CAnalyzeProcS m_cAnalyzeProcS = new CAnalyzeProcS();
        private static Dictionary<int, CCollectSymbolS> m_dicCollectSymbolS = new Dictionary<int, CCollectSymbolS>();
        private static string m_sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysql.exe";
        private static string m_sDBDumpPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
        #endregion


        #region Properties

        public static CSystemLog SystemLog
        {
            get { return m_cSysLog; }
            set { m_cSysLog = value; }
        }

        public static bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }

        public static CProjectBaseInfo ProjectInfo
        {
            get { return m_cBaseInfo; ;}
            set { m_cBaseInfo = value; }
        }

        public static string ProjectName
        {
            get { return m_cBaseInfo.ProjectName; }
            set { m_cBaseInfo.ProjectName = value; }
        }

        /// <summary>
        /// ID는 프로그램에서 1회 발급하며 Open시에 폴더가 생성되었는지 확인하고 없으면 생성
        /// </summary>
        public static string ProjectID
        {
            get { return m_cBaseInfo.ProjectID; }
            set { m_cBaseInfo.ProjectID = value; }
        }

        public static string ProjectPath
        {
            get { return m_cBaseInfo.ProjectPath; }
            set { m_cBaseInfo.ProjectPath = value; }
        }

        public static Dictionary<int, CRecipeWord> RecipeWordList
        {
            get { return m_cBaseInfo.RecipeWordList; }
            set { m_cBaseInfo.RecipeWordList = value; }
        }

        public static CPlcProcS PlcProcS
        {
            get { return m_cBaseInfo.PlcProcS; }
            set { m_cBaseInfo.PlcProcS = value; }
        }

        public static CAnalyzeProcS AnalyzeProcS
        {
            get { return m_cAnalyzeProcS; }
            set { m_cAnalyzeProcS = value; }
        }

        public static CUserDeviceS UserDeviceS
        {
            get { return m_cBaseInfo.UserDeviceS; }
            set { m_cBaseInfo.UserDeviceS = value; }
        }

        public static CPlcConfigS PlcConfigS
        {
            get { return m_cPlcConfigS; }
            set { m_cPlcConfigS = value; }
        }

        public static CPlcLogicDataS PlcLogicDataS
        {
            get { return m_cPlcLogicDataS; }
            set { m_cPlcLogicDataS = value; }
        }

        /// <summary>
        /// Plc Logic Data들의 TagS를 모두 모은것(중복이 있을 수 없음)
        /// </summary>
        public static CTagS TotalTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        public static List<string> UsedProjectID
        {
            get { return m_lstUsedProjectID; }
            set { m_lstUsedProjectID = value; }
        }

        public static CMySqlLogReader LogReader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        public static List<string> PlcIDList
        {
            get { return m_cBaseInfo.PlcIDList; }
            set { m_cBaseInfo.PlcIDList = value; }
        }

        public static string ConfigFilePath
        {
            get { return m_sProjectBaseFolder + "\\PLC 통신설정.plccfg"; }
        }

        public static CCycleAnalyDataS CycleAnalyDataS
        {
            get { return m_cCycleAnalyDataS; }
            set { m_cCycleAnalyDataS = value; }
        }

        public static CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        public static Dictionary<int, CCollectSymbolS> CollectSymbolInfoList
        {
            get { return m_dicCollectSymbolS; }
            set {m_dicCollectSymbolS = value;}
        }

        public static string ExcuteDBPath
        {
            get { return m_sDBPath; }
            set { m_sDBPath = value; }
        }

        public static string ExcuteDBBackupPath
        {
            get { return m_sDBDumpPath; }
            set { m_sDBDumpPath = value; }
        }

        #endregion


        #region Public Method
        private static void Clear()
        {
            m_cBaseInfo.Clear();
            m_cPlcConfigS.Clear();
            m_cPlcLogicDataS.Clear();
            m_lstUsedProjectID.Clear();
            m_cTotalTagS.Clear();

            m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
        }

        public static void Create(string sName)
        {
            CreateProjectID();
            ProjectName = sName;

        }

        /// <summary>
        /// File 확장자는 umpp
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public static bool Open(string sPath, out string sMessage)
        {
            sMessage = "";
            bool bOK = false;
            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));
            CMultiProject.Clear();
            bOK = ExtractFileToDirectory(sPath, sFolderPath);
            if (!bOK)
            {
                sMessage = "압축을 푸는데 실패했습니다.";
                return false;
            }

            CShowWaitForm.UpdateText("Open Project", "Open Base Information", "Start...");
            string sProjectPath = GetProjectFilePath(sFolderPath);
            bOK = OpenBaseInfo(sProjectPath);
            if (!bOK)
            {
                sMessage = "Base Project를 여는데 실패했습니다.";
                //return false;
            }

            ReadInfoFromDB();
            CShowWaitForm.UpdateText("Open Project", "Open Master Pattern", "Start...");
            bOK = OpenMasterInfo(sProjectPath);
            if (!bOK)
                sMessage += "Master Project를 여는데 실패했습니다.";

            if (Directory.Exists(m_sProjectBaseFolder))
            {
                bOK = DeleteProjectFolder(m_sProjectBaseFolder);
                if (!bOK)
                    sMessage += "프로젝트 폴더를 지우는데 실패했습니다.";
            }
            CShowWaitForm.UpdateText("Open Project", "Open PLC Logic", "Start...");
            bOK = OpenPlcInfoS(out sMessage, sFolderPath);
            if (!bOK)
            {
                sMessage = "PLC Data를 여는데 실패했습니다.";
                return false;
            }
            //bOK = OpenCycleAnalyDataS(m_cBaseInfo.ProjectID, sFolderPath);
            //if (!bOK)
            //{
            //    sMessage = "데이터를 여는데 실패했습니다.";
            //    return false;
            //}
            bOK = CopyAndPasteFolder(sFolderPath, m_sProjectBaseFolder);
            if (!bOK)
            {
                sMessage = "Project Folder에 있는 Project Start Up Folder로 Copy&Paste 하지 못했습니다.";
                return false;
            }

            if (Directory.Exists(sFolderPath + "\\InitSymbolInfo"))
            {
                string[] saFilePath = Directory.GetFiles(sFolderPath + "\\InitSymbolInfo");
                if (saFilePath != null)
                {
                    for (int i = 0; i < saFilePath.Length; i++)
                    {
                        //if (saFilePath[i].Contains(ProjectID) == false) continue;
                        string sFilePath = saFilePath[i];
                        CCollectSymbolS cSymbolS = new CCollectSymbolS();
                        bOK = cSymbolS.ReadCSVData(sFilePath);
                        if (bOK)
                            m_dicCollectSymbolS.Add(cSymbolS.CollectIndex, cSymbolS);
                    }
                }
            }

            bOK = DeleteProjectFolder(sFolderPath);
            if (!bOK)
            {
                sMessage = "프로젝트 폴더를 지우는데 실패했습니다.";
                return false;
            }

            foreach (var who in m_cPlcLogicDataS)
                m_cTotalTagS.AddRange(who.Value.TagS);

            foreach (CTag cTag in m_cTotalTagS.Values)
            {
                if (cTag.Description == "")
                    cTag.Description = cTag.Name;
            }
            
            //StuffProcess(m_cBaseInfo.PlcProcS);
            /*
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var who in m_cBaseInfo.PlcProcS)
            {
                CPlcProc cProc = who.Value;
                if (m_cCycleAnalyDataS.ContainsKey(who.Key))
                {
                    for (int i = 0; i < m_cCycleAnalyDataS[who.Key].Count; i++)
                    {
                        CCycleAnalyData cData = m_cCycleAnalyDataS[who.Key][i];
                        cData.ProcessKey = who.Key;
                        CTimeLogS cLogS = m_cReader.GetTimeLogS(cProc.ProcessTotalTagKey, cData.StartTime, cData.EndTime);
                        if (cLogS == null)
                            cData.IsLogEmpty = true;
                        else
                            cData.CycleLogS = (CTimeLogS)cLogS.Clone();
                    }
                }
            }
            sw.Stop();
            MessageBox.Show(string.Format("{0}ms", sw.ElapsedMilliseconds));
            */
            return bOK;
        }

        /// <summary>
        /// File확장자는 umpp
        /// 프로젝트 파일은 어디에 저장되어도 상관없지만 나머지 파일은 설치 폴더에 존재함.
        /// </summary>
        /// <param name="sPath">*.umpp</param>
        /// <returns></returns>
        public static bool Save(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = "";

            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            if (!Directory.Exists(sFolderPath))
                Directory.CreateDirectory(sFolderPath);
            CShowWaitForm.UpdateText("Save Project", "Save Base Information", "Start...");
            string sBasePath = sFolderPath + sFileName;
            bOK = SaveBaseInfo(sBasePath);
            if (!bOK)
            {
                sMessage = "기본 프로젝트를 저장하는데 실패했습니다.";
                return false;
            }
            CShowWaitForm.UpdateText("Save Project", "Save PLC Logic", "Start...");
            bOK = SavePlcInfoS(out sMessage, m_sProjectBaseFolder);
            if (!bOK)
            {
                sMessage = "PLC 데이터를 Project Start Path에 저장하는데 실패했습니다.";
                return false;
            }

            bOK = CopyAndPasteFolder(m_sProjectBaseFolder, sFolderPath);
            if (!bOK)
            {
                sMessage = "Project Base Folder에 있는 Project Folder를 Copy&Paste 하지 못했습니다.";
                return false;
            }
            //bOK = SaveCycleAnalyDataS(m_cBaseInfo.ProjectID, sFolderPath, m_cCycleAnalyDataS);
            //if (!bOK)
            //{
            //    sMessage = "데이터를 저장하는데 실패했습니다.";
            //    return false;
            //}
            bOK = ZipCompression(sFolderPath);
            if (!bOK)
            {
                sMessage = "데이터를 압축하는데 실패했습니다.";
                return false;
            }

            bOK = DeleteProjectFolder(sFolderPath);
            if (!bOK)
            {
                sMessage = "프로젝트 폴더를 지우는데 실패했습니다.";
                return false;
            }

            return bOK;
        }

        public static bool OpenPlcConfigS(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();
            CPlcConfigS cConfigS = (CPlcConfigS)(cSerializer.Read(sPath));

            if (cConfigS != null)
            {
                m_cPlcConfigS = cConfigS;

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            return bOK;
        }

        private static bool OpenMasterInfo(string sPath)
        {
            bool bOK = false;

            string sBasePath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sMasterPath = sBasePath + "_M.umpp";
            CNetSerializer cSerializer = new CNetSerializer();
            
            CProjectMasterPatternInfo cMasterInfo = (CProjectMasterPatternInfo)(cSerializer.Read(sMasterPath));
            if (cMasterInfo != null)
            {
                m_cMasterPatternInfo = cMasterInfo;
                bOK = true;
            }
            
            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }


        public static bool SavePlcConfigS(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cPlcConfigS);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static bool CheckSamePlcChannel(string sChannel)
        {
            foreach (var who in m_cPlcLogicDataS)
            {
                if (who.Value.PlcChannel == sChannel)
                    return true;
            }

            return false;
        }

        public static List<CTag> GetTagList(CStep cStep)
        {
            List<CTag> lstTag = new List<CTag>();

            CTag cTag;

            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                if (lstTag.Contains(cTag) == false)
                    lstTag.Add(cTag);
            }

            return lstTag;
        }

        public static List<CStep> GetCoilStepList(CTag cTag)
        {
            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cLogicData = null;

            if (!m_cTotalTagS.ContainsKey(cTag.Key))
                return lstStep;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = cLogicData.StepS[cRole.StepKey];
                        lstStep.Add(cStep);
                    }
                }
            }

            return lstStep;
        }

        public static List<CStep> GetStepList(string sKey)
        {
            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(sKey))
                {
                    cLogicData = cData;
                    break;
                }
            }

            CStep cStep;
            for (int i = 0; i < cLogicData.StepS.Count; i++)
            {
                cStep = cLogicData.StepS.ElementAt(i).Value;
                if (cStep.RefTagS.KeyList.Contains(sKey))
                {
                    lstStep.Add(cStep);
                }
            }

            return lstStep;
        }

        public static CPlcLogicData GetPlcLogicData(CTag cTag)
        {
            CPlcLogicData cData = null;

            foreach (CPlcLogicData cLogicData in m_cPlcLogicDataS.Values)
            {
                if (cLogicData.TagS.ContainsKey(cTag.Key))
                {
                    cData = cLogicData;
                    break;
                }
            }

            return cData;
        }

        public static CTimeLogS ReadTimeLogSForProcessSetting(string sProcessKey)
        {
            CTimeLogS cLogS = new CTimeLogS();
            string sPath = m_sProjectBaseFolder + "\\ProcessSettingTimeLog";
            if (Directory.Exists(sPath) == false) return cLogS;

            string sFilePath = sPath + "\\" + sProcessKey + ".csv";
            if (File.Exists(sFilePath) == false) return cLogS;

            CCsvLogReader cLogRead = new CCsvLogReader();
            bool bOK = cLogRead.Open(sFilePath);
            if (bOK == false) return cLogS;
            cLogS = cLogRead.ReadTimeLogS();
            cLogRead.Close();

            return cLogS;
        }

        public static bool WriteTimeLogSForProcessSetting(string sProcessKey, CTimeLogS cLogS)
        {
            string sPath = m_sProjectBaseFolder + "\\ProcessSettingTimeLog";
            if (Directory.Exists(sPath) == false)
                Directory.CreateDirectory(sPath);

            string sFilePath = sPath + "\\" + sProcessKey + ".csv";
            if (File.Exists(sFilePath)) return true;

            CCsvLogWriter cLogWrite = new CCsvLogWriter();
            bool bOK = cLogWrite.Open(sFilePath);
            bOK = cLogWrite.WriteTimeLogS(cLogS);
            cLogWrite.Close();

            return bOK;
        }


        public static void ComposeProcessLogicData()
        {
            //foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            //{
            //    if(cProcess.KeySymbolList == null)
            //        cProcess.KeySymbolList = new List<string>();

            //    if(cProcess.KeySymbolS != null)
            //        cProcess.KeySymbolList.AddRange(cProcess.KeySymbolS.Keys);

            //    if(cProcess.AbnormalSymbolList == null)
            //        cProcess.AbnormalSymbolList = new List<string>();

            //    if(cProcess.AbnormalSymbolS != null)
            //        cProcess.AbnormalSymbolList.AddRange(cProcess.AbnormalSymbolS.Keys);
            //}

            //CPlcLogicData cData = null;

            //if (m_cBaseInfo.PlcProcS.Count != 0)
            //{
            //    foreach (var who in m_cBaseInfo.PlcProcS)
            //    {
            //        if (who.Value.PlcLogicDataS == null || who.Value.PlcLogicDataS.Count == 0)
            //        {
            //            who.Value.PlcLogicDataS = new CPlcLogicDataS();

            //            if (!who.Value.IsErrorMonitoring)
            //            {
            //                foreach (var who2 in who.Value.ProcessTotalTagKey)
            //                {
            //                    cData = GetPlcLogicData(CMultiProject.TotalTagS[who2]);

            //                    if (cData != null && !who.Value.PlcLogicDataS.ContainsKey(cData.PLCID))
            //                        who.Value.PlcLogicDataS.Add(cData.PLCID, cData);
            //                }
            //            }
            //            else if (who.Value.TotalAbnormalSymbolKey != string.Empty)
            //            {
            //                cData = GetPlcLogicData(CMultiProject.TotalTagS[who.Value.TotalAbnormalSymbolKey]);

            //                if (cData != null && !who.Value.PlcLogicDataS.ContainsKey(cData.PLCID))
            //                    who.Value.PlcLogicDataS.Add(cData.PLCID, cData);
            //            }
            //        }
            //    }
            //}
        }

        public static void ComposePlcProcAbnormalSymbolS()
        {
            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                //if(cProcess.KeySymbolS == null)
                //    cProcess.KeySymbolS = new CKeySymbolS();

                if (cProcess.AbnormalSymbolS == null)
                    cProcess.AbnormalSymbolS = new CAbnormalSymbolS();

                if (cProcess.AbnormalSymbolList == null)
                    cProcess.AbnormalSymbolList = new List<string>();


                //CKeySymbol cKeySymbol = null;
                //CPlcLogicData cData = null;
                //CTag cTag = null;
                //foreach (string sKey in cProcess.KeySymbolList)
                //{
                //    if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                //        continue;

                //    cTag = CMultiProject.TotalTagS[sKey];

                //    if (!cProcess.KeySymbolS.ContainsKey(cTag.Key))
                //    {
                //        cKeySymbol = new CKeySymbol(cTag);
                //        cProcess.KeySymbolS.Add(cKeySymbol.Tag.Key, cKeySymbol);
                //    }

                //    if (cProcess.ChartViewTagS == null)
                //        cProcess.ChartViewTagS = new CTagS();

                //    if (!cProcess.ChartViewTagS.ContainsKey(cTag.Key))
                //        cProcess.ChartViewTagS.Add(cTag.Key, cTag);

                //    cData = GetPlcLogicData(cTag);

                //    if(!cProcess.PlcLogicDataS.ContainsKey(cData.PLCID))
                //        cProcess.PlcLogicDataS.Add(cData.PLCID, cData);
                //}

                //cProcess.UpdateKeySymbolS();
                cProcess.AbnormalFilter = GetAbnormalFilter();

                if (cProcess.TotalAbnormalSymbolKey == null || cProcess.TotalAbnormalSymbolKey == string.Empty)
                    continue;

                CTag cTag = CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey];

                cProcess.ComposeAbnormalSymbolS(cTag, CMultiProject.PlcLogicDataS[cTag.Creator], CMultiProject.TotalTagS);
                cProcess.UpdateAbnormalSymbolS();
            }
        }

        #endregion


        #region Private Method

        private static void ReadInfoFromDB()
        {
            try
            {
                m_cErrorInfoS = m_cReader.GetErrorInfoS(ProjectID);

                if (m_cErrorInfoS == null)
                    m_cErrorInfoS = new CErrorInfoS();

                CreateNextErrorID();
                CreateNextCycleID();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CreateNextErrorID()
        {
            try
            {
                int iLastErrorID = m_cReader.GetLastErrorInfoID(ProjectID);

                if (++iLastErrorID != m_iErrorCur)
                    m_iErrorCur = iLastErrorID;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        public static void CreateNextCycleID()
        {
            try
            {
                if (m_cBaseInfo.PlcProcS == null) return;

                foreach (var who in m_cBaseInfo.PlcProcS)
                {
                    int iLastCycleID = m_cReader.GetLastCycleID(ProjectID, who.Key);
                    who.Value.CycleID = ++iLastCycleID;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        public static List<string> GetAbnormalFilter()
        {
            List<string> lstFilter = new List<string>();
            lstFilter.Add("이상");
            lstFilter.Add("NG");
            lstFilter.Add("에러");
            lstFilter.Add("FAULT");
            lstFilter.Add("Fault");
            lstFilter.Add("ABNORMAL");
            lstFilter.Add("Abnormal");
            lstFilter.Add("Error");
            lstFilter.Add("ERROR");
            lstFilter.Add("Err");
            lstFilter.Add("ERR");
            lstFilter.Add("안전");
            lstFilter.Add("SAFET");
            lstFilter.Add("비상");
            lstFilter.Add("Warning");
            lstFilter.Add("WARNING");
            lstFilter.Add("Alarm");
            lstFilter.Add("ALARM");
            lstFilter.Add("OVER");
            lstFilter.Add("Over");
            lstFilter.Add("TRIP");
            lstFilter.Add("Trip");
            lstFilter.Add("트립");
            lstFilter.Add("OFF");
            lstFilter.Add("Off");
            lstFilter.Add("과부하");
            lstFilter.Add("STOP");
            lstFilter.Add("Stop");
            lstFilter.Add("UNMATC");
            lstFilter.Add("불일치");
            lstFilter.Add("GATE");

            return lstFilter;
        }

        private static bool ExtractFileToDirectory(string sZipPath, string sDirectory)
        {
            bool bOK = false;

            try
            {
                ZipFile zip = new ZipFile(sZipPath);
                Directory.CreateDirectory(sDirectory);
                zip.ExtractAll(sDirectory, ExtractExistingFileAction.OverwriteSilently);

                bOK = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ExtractFileToDirectory Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool SavePlcInfoS(out string sMessage, string sPath)
        {
            bool bOK = false;
            sMessage = "";

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);
                string sConfigPath = sPath + "\\PLC 통신설정.plccfg";
                bOK = SavePlcConfigS(sConfigPath);
                if (bOK == false)
                {
                    sMessage = "통신 설정을 저장하는데 실패했습니다.";
                    return false;
                }

                List<string> lstSaveError = SavePlcLogicDataList(m_cBaseInfo.PlcIDList, sPath);
                if (lstSaveError.Count > 0)
                {
                    for (int i = 0; i < lstSaveError.Count; i++)
                        Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstSaveError[i]));
                    sMessage = "LogicData를 저장하는데 실패했습니다.";
                    bOK = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SavePlcInfoS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool SaveCycleAnalyDataS(string sProjectID, string sPath, CCycleAnalyDataS cCycleAnalyDataS)
        {
            bool bOK = false;

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);
                string sFilePath = sPath + "\\" + sProjectID + "Analy.cdat";

                CNetSerializer cSerializer = new CNetSerializer();

                bOK = cSerializer.Write(sFilePath, cCycleAnalyDataS);

                cSerializer.Dispose();
                cSerializer = null;

                if (bOK == false)
                {
                    return false;
                }
                bOK = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("SavePlcInfoS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;

        }

        private static bool ZipCompression(string sFolderPath)
        {
            bool bOK = false;
            try
            {
                ZipFile zip = new ZipFile();
                zip.UseUnicodeAsNecessary = true;
                zip.AddDirectory(sFolderPath);
                zip.Save(sFolderPath + ".umpp");

                bOK = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Compression Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool DeleteProjectFolder(string sFolderPath)
        {
            bool bOK = false;

            try
            {
                if (Directory.Exists(sFolderPath))
                {
                    Directory.Delete(sFolderPath, true);
                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteProjectFolder Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool CopyAndPasteFolder(string sCopyPath, string sPastePath)
        {
            bool bOK = false;

            try
            {
                if (!Directory.Exists(sPastePath))
                    Directory.CreateDirectory(sPastePath);

                string[] sFiles = Directory.GetFiles(sCopyPath);
                string[] sFolders = Directory.GetDirectories(sCopyPath);

                string sName = string.Empty;
                string sDest = string.Empty;

                foreach (string sFile in sFiles)
                {
                    sName = Path.GetFileName(sFile);

                    if (sName.Contains(".umpp"))
                        continue;

                    sDest = Path.Combine(sPastePath, sName);

                    if(!File.Exists(sDest))
                        File.Copy(sFile, sDest);

                    bOK = true;
                }

                foreach (string sFolder in sFolders)
                {
                    sName = Path.GetFileName(sFolder);
                    sDest = Path.Combine(sPastePath, sName);
                    bOK = CopyAndPasteFolder(sFolder, sDest);

                    if (!bOK)
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteProjectFolder Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public static bool OpenPlcInfoS(out string sMessage, string sPath)
        {
            bool bOK = false;
            sMessage = string.Empty;
            int iStep = 0;

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);
                string sConfigPath = sPath + "\\PLC 통신설정.plccfg";
                iStep = 1;
                bOK = OpenPlcConfigS(sConfigPath);
                iStep = 2;
                if (bOK == false)
                {
                    sMessage = "통신 설정을 오픈하는데 실패했습니다.";
                    return false;
                }

                iStep = 3;
                List<string> lstPLC = m_cBaseInfo.PlcIDList.FindAll(b => b.Contains(m_cBaseInfo.ProjectID));
                m_cBaseInfo.PlcIDList = lstPLC;
                List<string> lstOpenError = OpenPlcLogicDataList(lstPLC, sPath);
                iStep = 4;
                if (lstOpenError.Count > 0)
                {
                    for (int i = 0; i < lstOpenError.Count; i++)
                        Console.WriteLine(string.Format("Open Plc Logic Fail -> {0}", lstOpenError[i]));
                    sMessage = "LogicData를 오픈하는데 실패했습니다.";
                    bOK = false;
                }
                iStep = 5;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenPlcInfoS Error " + ex.Message + " " + iStep);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private static void TraceStateOnContact(CTagS cCauseTagS, List<CStep> lstTotalStep, CTag cCauseTag, CTimeLogS cLogS)
        {
            CTagStepRole cRole;
            CTimeLog cLog;

            if (cCauseTag.DataType == EMDataType.Bool && cCauseTag.IsEndContact())
            {
                if (!cCauseTagS.ContainsKey(cCauseTag.Key))
                    cCauseTagS.Add(cCauseTag);
            }
            else
            {
                for (int i = 0; i < cCauseTag.StepRoleS.Count; i++)
                {
                    cRole = cCauseTag.StepRoleS[i];
                    if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                    {
                        List<CStep> lstStep = GetCoilStepList(cCauseTag);

                        foreach (CStep cStep in lstStep)
                        {
                            if (lstTotalStep.Contains(cStep))
                                continue;

                            foreach (CContact cContact in cStep.ContactS)
                            {
                                if (cContact == null)
                                    continue;

                                cLog = GetContactLog(cContact, cLogS);

                                if (cLog == null)
                                    continue;

                                if (CheckContactState(cContact, cLog))
                                    TraceStateOnContact(cCauseTagS, lstTotalStep, cContact.RefTagS[cLog.Key], cLogS);
                                else
                                    continue;
                            }
                        }
                        lstStep.Clear();
                    }
                }
            }
        }

        private static CTimeLog GetContactLog(CContact cContact, CTimeLogS cLogS)
        {
            CTimeLog cLog = null;

            foreach (CTimeLog cTempLog in cLogS)
            {
                if (cContact.RefTagS.ContainsKey(cTempLog.Key))
                {
                    cLog = cTempLog;
                    break;
                }
            }

            return cLog;
        }

        private static bool CheckContactState(CContact cContact, CTimeLog cLog)
        {
            bool bStateOn = false;
            try
            {
                int iValue = cLog.Value;

                if (cContact.ContactType == EMContactType.Bit)
                {
                    if (iValue == 1 && (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF"))
                        || iValue == 0 && (cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF")))
                        bStateOn = true;
                    else
                        bStateOn = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : {0} [{1}]", e.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                e.Data.Clear();
            }

            return bStateOn;
        }

        private static string GetProjectFilePath(string sFolderPath)
        {
            string sPath = string.Empty;

            string[] sFiles = Directory.GetFiles(sFolderPath);

            string sName = string.Empty;

            foreach (string sFile in sFiles)
            {
                sName = Path.GetFileName(sFile);

                if (sName.Contains(".umpp"))
                {
                    sPath = sName;
                    break;
                }
            }

            sPath = sFolderPath + "\\" + sPath;

            return sPath;
        }

        private static bool OpenBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CProjectBaseInfo cBaseInfo = (CProjectBaseInfo)(cSerializer.Read(sPath));
            if (cBaseInfo != null)
            {
                m_cBaseInfo = cBaseInfo;
                m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath + "\\" + ProjectID;
                m_cBaseInfo.ProjectPath = sPath;

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            return bOK;
        }

        private static bool SaveBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cBaseInfo);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstPlcID"></param>
        /// <returns>Load Error Path</returns>
        private static List<string> OpenPlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            if (m_cPlcLogicDataS == null)
                m_cPlcLogicDataS = new CPlcLogicDataS();
            else
                m_cPlcLogicDataS.Clear();

            List<string> sLoadError = new List<string>();
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(lstPlcID, sID =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                string sFilePath = sPath + "\\" + sID + ".pcd";
                string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO" + ".pcd";
                string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO" + ".pcd";

                try
                {
                    if (File.Exists(sFilePath))
                    {
                        CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sFilePath));
                        if (cPlcLogicData != null)
                        {
                            cPlcLogicData.Compose();
                            m_cPlcLogicDataS.Add(cPlcLogicData.PLCID, cPlcLogicData);
                        }
                        else
                            sLoadError.Add(sFilePath);

                        cSerializer.Dispose();
                        cSerializer = null;

                    }
                    else if (File.Exists(sFileStepPath))
                    {
                        CPlcLogicData cData = new CPlcLogicData();
                        cData.PLCID = sID;

                        if (m_cPlcConfigS.ContainsKey(sID))
                        {
                            cData.PlcName = m_cPlcConfigS[sID].PlcName;
                            cData.PlcChannel = m_cPlcConfigS[sID].PlcChannel;
                            cData.Maker = m_cPlcConfigS[sID].PLCMaker;
                            cData.CollectType = m_cPlcConfigS[sID].CollectType;
                        }

                        cData.TagS = (CTagS)(cSerializer.Read(sFileTagPath));

                        if (cData.TagS == null)
                            sLoadError.Add(sFileTagPath);

                        cData.StepS = (CStepS)(cSerializer.Read(sFileStepPath));

                        if (cData.StepS == null)
                            sLoadError.Add(sFileStepPath);

                        cData.Compose();
                        m_cPlcLogicDataS.Add(cData.PLCID, cData);

                        cSerializer.Dispose();
                        cSerializer = null;
                    }

                    //Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }

            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        private static bool OpenCycleAnalyDataS(string sProjectID, string sPath)
        {
            if (m_cCycleAnalyDataS == null)
                m_cCycleAnalyDataS = new CCycleAnalyDataS();
            else
                m_cCycleAnalyDataS.Clear();

            bool bOK = false;

            var exceptions = new ConcurrentQueue<Exception>();

            CNetSerializer cSerializer = new CNetSerializer();
            string sFilePath = sPath + "\\" + sProjectID + "Analy.cdat";
            try
            {
                CCycleAnalyDataS cCycleAnalyDataS = (CCycleAnalyDataS)(cSerializer.Read(sFilePath));
                if (cCycleAnalyDataS != null)
                {
                    m_cCycleAnalyDataS = cCycleAnalyDataS;
                }

                cSerializer.Dispose();
                cSerializer = null;
                Thread.Sleep(1000);
                bOK = true;
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
                return false;
            }

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return bOK;
        }

        public static bool OpenPlcLogicDataList(string sPath, out string sID)
        {
            if (m_cPlcLogicDataS == null)
                m_cPlcLogicDataS = new CPlcLogicDataS();
           
            var exceptions = new ConcurrentQueue<Exception>();
            bool bOK = false;
            sID = "";
            CNetSerializer cSerializer = new CNetSerializer();
                
            try
            {
                CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sPath));
                if (cPlcLogicData != null)
                {
                    cPlcLogicData.Compose();
                    m_cPlcLogicDataS.Add(cPlcLogicData.PLCID, cPlcLogicData);
                    sID = cPlcLogicData.PLCID;
                    bOK = true;
                }

                cSerializer.Dispose();
                cSerializer = null;

            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return bOK;
        }

        private static List<string> SavePlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            List<string> lstResult = new List<string>();
            if (m_cPlcLogicDataS == null)
                lstResult.Add("m_cPlcLogicDataS = null");
            else
            {
                var exceptions = new ConcurrentQueue<Exception>();

                string[] saExistFiles = Directory.GetFiles(sPath);
                foreach (string sfile in saExistFiles)   
                {
                    if (sfile.Contains("pcd"))  // 기존pcd 파일 삭제
                    {
                        File.Delete(sfile);
                    }
                }

                Parallel.ForEach(lstPlcID, sID =>
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFilePath = sPath + "\\" + sID + ".pcd";
                    try
                    {
                        if (m_cPlcLogicDataS.ContainsKey(sID))
                        {
                            bool bOK = cSerializer.Write(sFilePath, m_cPlcLogicDataS[sID]);

                            if (bOK == false)
                                lstResult.Add(sFilePath);
                        }
                        else
                            lstResult.Add(sID + "  Not Found !! ");
                        cSerializer.Dispose();
                        cSerializer = null;
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }

                });

                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }

            return lstResult;
        }

        /// <summary>
        /// 사용하지 않은 Random 8자리 숫자 String
        /// </summary>
        /// <returns></returns>
        private static bool CreateProjectID()
        {
            if (m_cReader == null || !m_cReader.IsConnected)
            {
                XtraMessageBox.Show("Mysql DB가 제대로 설치되지 않았습니다.\r\nDB Install을 다시 진행해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            m_lstUsedProjectID = m_cReader.GetUsedProjectIDList();
            while (true)
            {
                Random iRandom = new Random();
                int iValue = iRandom.Next();
                string sResult = string.Format("{0:x8}", iValue).ToUpper();
                if (m_lstUsedProjectID.Contains(sResult) == false)
                {
                    ProjectID = sResult;
                    m_sProjectBaseFolder += "\\" + sResult;

                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// Project ID + PlcLogicData 갯수
        /// </summary>
        /// <returns>PlcLogicData에 있는 값이면 Empty Return</returns>
        public static string CreatePlcId()
        {
            string sResult = ProjectID + "-" + m_cPlcLogicDataS.Count.ToString();

            if (m_cPlcLogicDataS.ContainsKey(sResult))
                return "";

            m_cBaseInfo.PlcIDList.Add(sResult);

            return sResult;
        }

        #endregion
    }
}
