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

namespace UDMTrackerSimple
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
        //생산 정보 표시 Data(단일파일 확장자= .pinfo)
        private static CLineInfoS m_cLineInfoS = new CLineInfoS();

        //휘발성 Data
        private static string m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
        private static int m_iErrorCur = 0;
        private static CTagS m_cTotalTagS = new CTagS();
        private static List<string> m_lstUsedProjectID = new List<string>();
        private static CErrorInfoS m_cErrorInfoS = new CErrorInfoS();
        private static CMySqlLogReader m_cReader = null;
        private static CSystemLog m_cSysLog = null;

        private static Dictionary<string, CCycleInfoS> m_cTotalCycleInfoS = null;

        private static bool m_bEditable = true;
        private static bool m_bRun = false;

        //private static UCProcessCycleBoardS m_ucProcessCycleBoardS = null;
        //private static UCCycleInfoDashBoard m_ucCycleInfoDashBoard = null;
        //private static UCProcessCycleStatisticS m_ucGroupCycleStatisticS = null;
        private static UCErrorView m_ucErrorView = null;
        private static UCErrorLogTable m_ucErrorLogTable = null;
        private static UCRobotCycle m_ucRobotCycle = null;
        //private static UCPlcSummaryS m_ucPlcSummaryS = null;
        //private static UCPlcCycleS m_ucPlcCycleS = null;
        private static UCStepLadderView m_ucStepLadderView = null;
        private static UCAllErrorAlarmView2 m_ucSummary = null;
        private static UCPlcCycle m_ucPlcCycle = null;
        private static UCFlowChart m_ucFlowChart = null;

        private static List<string> m_lstAbnormalFilter = null;
        private static List<string> m_lstAddressFilter = null;

        private static Dictionary<string, double> m_dicProcessTimeAvr = new Dictionary<string, double>();
        
        private static TrackerProject.CProjectBaseInfo m_cTBaseData = new TrackerProject.CProjectBaseInfo();
        private static TrackerProject.CProjectMasterPatternInfo m_cTMasterPatternInfo = new TrackerProject.CProjectMasterPatternInfo();
        private static CCollectSymbolS m_cCollectSymbolS = null;

        #endregion


        #region Properties

        public static COptimizationOption OptimizationOption
        {
            get { return m_cBaseInfo.OptimizationOption; }
            set { m_cBaseInfo.OptimizationOption = value; }
        }

        public static CNonDetectTimeS NonDetectTimeS
        {
            get { return m_cBaseInfo.NonDetectTimeS; }
            set { m_cBaseInfo.NonDetectTimeS = value; }
        }

        public static bool IsProjectBaseView
        {
            get { return m_cBaseInfo.ProjectBaseView; }
            set { m_cBaseInfo.ProjectBaseView = value; }
        }

        public  static bool IsAutoUpdateRecipe
        {
            get { return m_cMasterPatternInfo.IsAutoUpdateRecipe; }
            set { m_cMasterPatternInfo.IsAutoUpdateRecipe = value; }
        }

        public static bool IsApplyAbnormalPriority
        {
            get { return m_cBaseInfo.ApplyAbnormalPriority; }
            set { m_cBaseInfo.ApplyAbnormalPriority = value; }
        }

        public static int RecipeUpdateCount
        {
            get { return m_cMasterPatternInfo.RecipeUpdateCount; }
            set { m_cMasterPatternInfo.RecipeUpdateCount = value; }
        }

        public static string ProjectBaseFolder
        {
            get { return m_sProjectBaseFolder; }
            set { m_sProjectBaseFolder = value; }
        }

        public static CProjectMasterPatternInfo ProjectMasterPatternInfo
        {
            get { return m_cMasterPatternInfo; }
            set { m_cMasterPatternInfo = value; }
        }

        public static CSystemLog SystemLog
        {
            get { return m_cSysLog; }
            set { m_cSysLog = value; }
        }

        /// <summary>
        /// Process 별 통계적으로 계산되는 Process Time Average
        /// </summary>
        public static Dictionary<string, double> DicProcessTimeAvr
        {
            get { return m_dicProcessTimeAvr; }
            set { m_dicProcessTimeAvr = value; }
        }

        public static EMMonitorModeType LearningStep
        {
            get { return m_cBaseInfo.LearningStep; }
            set { m_cBaseInfo.LearningStep = value; }
        }

        public static EMMonitorModeType MasterStep
        {
            get { return m_cBaseInfo.MasterStep; }
            set { m_cBaseInfo.MasterStep = value; }
        }

        public static bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }

        public static bool IsRun
        {
            get { return m_bRun; }
            set { m_bRun = value; }
        }

        public static List<string> AbnormalFilter
        {
            get { return m_lstAbnormalFilter; }
            set { m_lstAbnormalFilter = value; }
        }

        public static List<string> AddressFilter
        {
            get { return m_lstAddressFilter; }
            set { m_lstAddressFilter = value; }
        }

        public static UCAllErrorAlarmView2 PlcSummary
        {
            get { return m_ucSummary; }
            set { m_ucSummary = value; }
        }

        public static UCPlcCycle PlcCycle
        {
            get { return m_ucPlcCycle; }
            set { m_ucPlcCycle = value; }
        }

        public static UCFlowChart PlcFlowChart
        {
            get { return m_ucFlowChart; }
            set { m_ucFlowChart = value; }
        }

        public static UCErrorView ErrorView
        {
            get { return m_ucErrorView; }
            set { m_ucErrorView = value; }
        }

        public static UCErrorLogTable ErrorLogTable
        {
            get { return m_ucErrorLogTable; }
            set { m_ucErrorLogTable = value; }
        }

        public static UCRobotCycle RobotCycle
        {
            get { return m_ucRobotCycle; }
            set { m_ucRobotCycle = value; }
        }
        public static UCStepLadderView StepLadderView
        {
            get { return m_ucStepLadderView; }
            set { m_ucStepLadderView = value; }
        }

        public static CProjectBaseInfo ProjectInfo
        {
            get { return m_cBaseInfo; ;}
            set { m_cBaseInfo = value; }
        }

        public static Dictionary<string, CCycleInfoS> TotalCycleInfoS
        {
            get { return m_cTotalCycleInfoS; }
            set { m_cTotalCycleInfoS = value; }
        }

        public static int ErrorIDCur
        {
            get { return m_iErrorCur; }
            set { m_iErrorCur = value; }
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

        public static CMasterPatternS MasterPatternS
        {
            get { return m_cMasterPatternInfo.MasterPatternS; }
            set { m_cMasterPatternInfo.MasterPatternS = value; }
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

        public static CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set { m_cErrorInfoS = value; }
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

        public static EMMonitorType MonitorType
        {
            get { return m_cBaseInfo.MonitorType; }
            set { m_cBaseInfo.MonitorType = value; }
        }

        public static CLineInfoS LineInfoS
        {
            get { return m_cLineInfoS; }
            set { m_cLineInfoS = value; }
        }

        public static bool Account
        {
            get { return m_cBaseInfo.Account; }
            set { m_cBaseInfo.Account = value; }
        }

        public static CCollectSymbolS CurrentCollectSymbolS
        {
            get { return m_cCollectSymbolS;}
            set { m_cCollectSymbolS = value; }
        }

        #endregion


        #region Public Method

        public static void ClearMemory()
        {
            foreach (CErrorInfo cErrorInfo in ErrorInfoS)
            {
                if (cErrorInfo.ErrorLogS != null && cErrorInfo.ErrorLogS.Count > 0)
                    cErrorInfo.ErrorLogS.Clear();
            }

            ErrorInfoS.Clear();
            ErrorLogTable.Clear();
            ErrorView.ClearControl();
            ErrorView.SetErrorView(ErrorInfoS, PlcProcS);
        }

        public static void Create(string sName)
        {
            Clear();

            CreateProjectID();
            ProjectName = sName;

            ClearCurrentID();
            Refresh();
        }

        public static void ClearCurrentID()
        {
            if (m_cTotalCycleInfoS == null)
                m_cTotalCycleInfoS = new Dictionary<string, CCycleInfoS>();
            m_cTotalCycleInfoS.Clear();
            //m_iErrorCur = 0;
            //m_cErrorInfoS.Clear();
            CreateTotalCycleInfoS();

            //Refresh();
        }

        /// <summary>
        /// File 확장자는 umpp
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public static bool Open(string sPath, out string sMessage)
        {
            Clear();
            sMessage = "";
            bool bOK = false;

            if (!File.Exists(sPath))
                return false;

            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            if (Directory.Exists(sFolderPath))
                DeleteProjectFolder(sFolderPath);

            if (Directory.Exists(sFolderPath) == false)
            {
                bOK = ExtractFileToDirectory(sPath, sFolderPath);
                if (!bOK)
                {
                    sMessage = "압축을 푸는데 실패했습니다.";
                    if (Directory.Exists(sFolderPath))
                        DeleteProjectFolder(sFolderPath);
                    return false;
                }
            }
            string sProjectPath = GetProjectFilePath(sFolderPath);
            CShowWaitForm.UpdateText("Open Project", "Open Base Information", "Start...");
            bOK = OpenBaseInfo(sProjectPath);
            if (!bOK)
            {
                sMessage = "Base Project를 여는데 실패했습니다.";
                if (Directory.Exists(sFolderPath))
                    DeleteProjectFolder(sFolderPath);
                return false;
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
                sMessage += "PLC Data를 여는데 실패했습니다.";
            else
            {
                foreach (var who in m_cPlcLogicDataS)
                    m_cTotalTagS.AddRange(who.Value.TagS);
            }

            //bOK = OpenLineInfo(m_sProjectBaseFolder, out sMessage);
            //if (!bOK)
            //{
            //    sMessage = "라인 정보를 여는데 실패했습니다.";
            //    if (Directory.Exists(sFolderPath))
            //        DeleteProjectFolder(sFolderPath);
            //    return false;
            //}

            if (bOK == false)
            {
                if (Directory.Exists(sFolderPath))
                    DeleteProjectFolder(sFolderPath);
                return false;
            }

            bOK = CopyAndPasteFolder(sFolderPath, m_sProjectBaseFolder);
            if (!bOK)
            {
                sMessage = "Project Folder에 있는 Project Start Up Folder로 Copy&Paste 하지 못했습니다.";
                if (Directory.Exists(sFolderPath))
                    DeleteProjectFolder(sFolderPath);
                return false;
            }
            bOK = DeleteProjectFolder(sFolderPath);
            if (!bOK)
            {
                sMessage = "프로젝트 폴더를 지우는데 실패했습니다.";
                return false;
            }

            ClearCurrentID();

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

            string sBasePath = sFolderPath + sFileName;
            CShowWaitForm.UpdateText("Save Project", "Save Base Information", "Start...");
            bOK = SaveBaseInfo(sBasePath);
            if (!bOK)
            {
                sMessage = "기본 프로젝트를 저장하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }
            CShowWaitForm.UpdateText("Save Project", "Save Master Pattern", "Start...");
            bOK = SaveMasterInfo(sBasePath);
            if (!bOK)
            {
                sMessage = "마스터패턴 프로젝트를 저장하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }
            CShowWaitForm.UpdateText("Save Project", "Save PLC Logic", "Start...");
            bOK = SavePlcInfoS(out sMessage, m_sProjectBaseFolder);
            if (!bOK)
            {
                sMessage = "PLC 데이터를 Project Start Path에 저장하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }

            //bOK = SaveLineInfo(m_sProjectBaseFolder, out sMessage);
            //if (!bOK)
            //{
            //    sMessage = "라인 정보를 저장하는데 실패했습니다.";
            //    return false;
            //}

            bOK = CopyAndPasteFolder(m_sProjectBaseFolder, sFolderPath);
            if (!bOK)
            {
                sMessage = "Project Base Folder에 있는 Project Folder를 Copy&Paste 하지 못했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }

            bOK = ZipCompression(sFolderPath);
            if (!bOK)
            {
                sMessage = "데이터를 압축하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
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

        public static void Refresh()
        {
            if (m_ucPlcCycle != null)
                m_ucPlcCycle.SetView();

            if (m_ucErrorView != null)
                m_ucErrorView.SetErrorView(ErrorInfoS, PlcProcS);

            if (m_ucErrorLogTable != null)
            {
                //m_ucErrorLogTable.ErrorInfoS = ErrorInfoS;
                m_ucErrorLogTable.ShowGrid();
            }

            if (m_ucRobotCycle != null)
            {
                m_ucRobotCycle.Clear();
                m_ucRobotCycle.CycleTagS = m_cBaseInfo.RobotCycleTagS;
            }

            if (m_ucSummary != null)
                m_ucSummary.SetView();

            if(m_ucFlowChart != null)
                m_ucFlowChart.SetView();

            if (m_ucStepLadderView != null)
                m_ucStepLadderView.Clear();
        }

        public static void ComposePlcSymbolS()
        {
            try
            {
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    foreach (CKeySymbol cKeySymbol in cProcess.KeySymbolS.Values)
                    {
                        if (cKeySymbol.TagKey != null &&cKeySymbol.TagKey != string.Empty)
                            cKeySymbol.Tag = CMultiProject.TotalTagS[cKeySymbol.TagKey];

                        if(cProcess.ChartViewTagS == null)
                            cProcess.ChartViewTagS = new CTagS();

                        if(!cProcess.ChartViewTagS.ContainsKey(cKeySymbol.TagKey))
                            cProcess.ChartViewTagS.Add(cKeySymbol.Tag);

                        if(cKeySymbol.AllSubDepthTagKeyList == null)
                            cKeySymbol.AllSubDepthTagKeyList = new List<string>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public static void ComposeProcessLogicData()
        {
            CPlcLogicData cData = null;

            if (m_cBaseInfo.PlcProcS.Count != 0)
            {
                foreach (var who in m_cBaseInfo.PlcProcS)
                {
                    if (who.Value.PlcLogicDataS == null || who.Value.PlcLogicDataS.Count == 0)
                    {
                        who.Value.PlcLogicDataS = new CPlcLogicDataS();

                        if (!who.Value.IsErrorMonitoring)
                        {
                            foreach (var who2 in who.Value.KeySymbolS.Values)
                            {
                                if (who2.Tag == null)
                                {
                                    Console.WriteLine("Tag 값이 없습니다.");
                                    break;
                                }
                                cData = GetPlcLogicData(who2.Tag);

                                if (cData != null && !who.Value.PlcLogicDataS.ContainsKey(cData.PLCID))
                                    who.Value.PlcLogicDataS.Add(cData.PLCID, cData);
                            }
                        }
                        else if (who.Value.TotalAbnormalSymbolKey != string.Empty)
                        {
                            cData = GetPlcLogicData(CMultiProject.TotalTagS[who.Value.TotalAbnormalSymbolKey]);

                            if (cData != null && !who.Value.PlcLogicDataS.ContainsKey(cData.PLCID))
                                who.Value.PlcLogicDataS.Add(cData.PLCID, cData);
                        }
                    }
                }
            }
        }

        public static void UpdatePlcProcHierarchyAbnormalSymbolS()
        {
            try
            {
                List<string> lstAllAbnormalSymbolKeyList = new List<string>();
                List<string> lstTemp = null;
                foreach(CPlcProc cProcess in PlcProcS.Values)
                {
                    if(cProcess.AbnormalSymbolS == null)
                    {
                        cProcess.AbnormalSymbolS = new CAbnormalSymbolS();
                        continue;
                    }

                    if (cProcess.AbnormalSymbolS.Count == 0)
                        continue;

                    lstTemp = cProcess.AbnormalSymbolS.GetAbnormalSymbolKeyList();
                    lstAllAbnormalSymbolKeyList.AddRange(lstTemp);

                    if(lstTemp != null && lstTemp.Count > 0)
                        lstTemp.Clear();
                    lstTemp = null;
                }

                CSubCoil cSubCoil = null;
                foreach(CPlcProc cProcess in PlcProcS.Values)
                {
                    foreach(CAbnormalSymbol cSymbol in cProcess.AbnormalSymbolS.Values)
                    {
                        if (cSymbol.SubCoil == null)
                            continue;

                        cSubCoil = cSymbol.SubCoil;

                        UpdatePlcProcHierarchyAbnormalSymbolS(cSubCoil, lstAllAbnormalSymbolKeyList);
                    }

                    cSubCoil = null;
                }

                if(lstAllAbnormalSymbolKeyList != null && lstAllAbnormalSymbolKeyList.Count > 0)
                    lstAllAbnormalSymbolKeyList.Clear();

                lstAllAbnormalSymbolKeyList = null;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public static void ComposePlcProcAbnormalSymbolS()
        {
            if (CMultiProject.AbnormalFilter == null || CMultiProject.AbnormalFilter.Count == 0)
                CMultiProject.AbnormalFilter = GetAbnormalFilter();

            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                if (cProcess.AbnormalSymbolS == null)
                    cProcess.AbnormalSymbolS = new CAbnormalSymbolS();

                if (cProcess.AbnormalSymbolList == null)
                    cProcess.AbnormalSymbolList = new List<string>();

                cProcess.AbnormalFilter = GetAbnormalFilter();

                if (cProcess.TotalAbnormalSymbolKey == string.Empty)
                    continue;

                cProcess.ComposeAbnormalSymbolS(CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey]);
                cProcess.UpdateAbnormalSymbolS();
                UpdatePlcProcHierarchyAbnormalSymbolS();
            }
        }

        public static bool OpenPlcConfigS(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();
            CPlcConfigS cConfigS = (CPlcConfigS)(cSerializer.Read(sPath));

            if (cConfigS != null)
            {
                m_cPlcConfigS = cConfigS;

                bOK = true;
            }

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static bool SavePlcConfigS(string sPath)
        {
            bool bOK = false;

            foreach (var who in m_cPlcConfigS)
            {
                if (m_cPlcLogicDataS.ContainsKey(who.Key))
                {
                    who.Value.PlcName = m_cPlcLogicDataS[who.Key].PlcName;
                    who.Value.PlcChannel = m_cPlcLogicDataS[who.Key].PlcChannel;
                }
            }

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

        public static CTagS GetErrorCauseTagS(CErrorInfo cInfo)
        {
            CTagS cCauseTagS = new CTagS();

            string sProcessKey = cInfo.GroupKey;
            CKeySymbol cSymbol = PlcProcS[sProcessKey].KeySymbolS[cInfo.SymbolKey];
            DateTime dtCycleStart = cInfo.CycleStart;
            DateTime dtErrorTime = cInfo.ErrorTime;

            CMasterPattern cMasterPattern = null;
            int iCauseCount = 0;

            CTagS cEndSubDepthTagS = new CTagS();
            CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(ProjectID, sProcessKey);
            string sRecipe = string.Empty;

            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return cCauseTagS;

            CCycleInfo cErrorCycleInfo = cCycleInfoS.GetCycleInfo(cInfo.CycleStart, cInfo.ErrorTime);

            if (cErrorCycleInfo != null)
                sRecipe = cErrorCycleInfo.CurrentRecipe;

            //foreach(var who in cSymbol.SubDepthTagList)
            //    cEndSubDepthTagS.Add(who);

            if (cEndSubDepthTagS.Count == 0)
                return cCauseTagS;

            cMasterPattern = GetErrorSubDepthMasterPattern(sProcessKey, cCycleInfoS, cEndSubDepthTagS, dtCycleStart, dtErrorTime);

            if (cMasterPattern == null || cMasterPattern.Count == 0)
                return cCauseTagS;

            CTimeLogS cLogS = m_cReader.GetTimeLogS(cEndSubDepthTagS.Keys.ToList(), dtCycleStart, dtErrorTime);

            CFlow cFlow = null;

            if (cMasterPattern.ContainsKey(sRecipe))
                cFlow = cMasterPattern[sRecipe].First();
            else
                cFlow = cMasterPattern.First().Value.First();

            foreach (CFlowItem cItem in cFlow.FlowItemS.Values)
            {
                Thread.Sleep(1);

                if (cLogS.Where(x => x.Key == cItem.Key && x.Value > 0).Count() == 0)
                {
                    cCauseTagS.Add(cEndSubDepthTagS[cItem.Key]);
                    iCauseCount++;
                }

                if (iCauseCount == 5)
                    break;
            }

            return cCauseTagS;
        }

        public static CTagS GetInterlockErrorCauseTagS(CErrorInfo cInfo)
        {
            CTagS cCauseTagS = new CTagS();

            try
            {
                CTag cInterlockTag = m_cTotalTagS[cInfo.SymbolKey];
                List<CStep> lstStep = GetCoilStepList(cInterlockTag);
                List<CStep> lstTotalStep = new List<CStep>();

                CTimeLog cLog;

                CheckErroInfoLogS(cInfo);

                foreach (CStep cStep in lstStep)
                {
                    lstTotalStep.Add(cStep);

                    foreach (CContact cContact in cStep.ContactS)
                    {
                        if (cContact == null)
                            continue;

                        Thread.Sleep(1);

                        cLog = GetContactLog(cContact, cInfo.ErrorLogS);

                        if (cLog == null)
                            continue;

                        if (CheckContactState(cContact, cLog))
                            TraceStateOnContact(cCauseTagS, lstTotalStep, cContact.RefTagS[cLog.Key], cInfo.ErrorLogS);
                        else
                            continue;
                    }

                    lstTotalStep.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : {0} [{1}]", e.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                e.Data.Clear();
            }
            return cCauseTagS;
        }

        public static List<string> GetLinkTagKeyList(CTag cTag)
        {
            List<string> lstKey = null;

            try
            {
                if (m_cTotalTagS == null || m_cTotalTagS.Count == 0)
                    return null;

                lstKey = m_cTotalTagS.Where(x => x.Value.Address == cTag.Address).Select(x => x.Key).ToList();

                if (lstKey.Count == null || lstKey.Count == 0)
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return lstKey;
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

        public static void Clear()
        {
            m_cBaseInfo.Clear();
            m_cMasterPatternInfo.Clear();

            m_cPlcConfigS.Clear();
            m_cPlcLogicDataS.Clear();
            m_lstUsedProjectID.Clear();
            m_cErrorInfoS.Clear();
            m_cTotalTagS.Clear();
            m_cLineInfoS.Clear();

            if (m_ucErrorView != null)
                m_ucErrorView.ClearControl();

            if (m_ucErrorLogTable != null)
                m_ucErrorLogTable.Clear();

            if (m_ucRobotCycle != null)
                m_ucRobotCycle.Clear();

            if (m_ucPlcCycle != null)
                m_ucPlcCycle.Clear();

            if(m_ucSummary != null)
                m_ucSummary.Clear();

            if(m_ucFlowChart != null)
                m_ucFlowChart.Clear();

            m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
        }

        public static List<string> GetAbnormalFilter()
        {
            List<string> lstFilter = new List<string>();
            lstFilter.Add("이상");
            lstFilter.Add("NG");
            lstFilter.Add("에러");
            lstFilter.Add("FAULT");
            lstFilter.Add("ABNORMAL");
            lstFilter.Add("ERROR");
            lstFilter.Add("ERR");
            lstFilter.Add("안전");
            lstFilter.Add("SAFE");
            lstFilter.Add("비상");
            lstFilter.Add("WARNING");
            lstFilter.Add("ALARM");
            lstFilter.Add("OVER");
            lstFilter.Add("TRIP");
            lstFilter.Add("트립");
            lstFilter.Add("OFF");
            lstFilter.Add("과부하");
            lstFilter.Add("STOP");
            lstFilter.Add("UNMATC");
            lstFilter.Add("불일치");
            lstFilter.Add("비가동");
            lstFilter.Add("비기동");
            lstFilter.Add("차단");
            lstFilter.Add("불량");
            lstFilter.Add("지연");
            lstFilter.Add("고장");
            //lstFilter.Add("교환");
            //lstFilter.Add("부하");
            //lstFilter.Add("감지");
            lstFilter.Add("GATE");
            //lstFilter.Add("체크");
            //lstFilter.Add("확인");
            //lstFilter.Add("CHK");
            lstFilter.Add("정상");
            lstFilter.Add("NORMAL");
            lstFilter.Add("STOP");
            lstFilter.Add("AUX");

            return lstFilter;
        }

        #endregion


        #region Private Method

        private static void UpdatePlcProcHierarchyAbnormalSymbolS(CSubCoil cCoil, List<string> lstAllAbnormalKeyList)
        {
            if (cCoil.SubCoilS == null || cCoil.SubCoilS.Count == 0)
                return;

            List<CSubCoil> lstRemoveCoil = new List<CSubCoil>();
            foreach(CSubCoil cSubCoil in cCoil.SubCoilS)
            {
                if (lstAllAbnormalKeyList.Contains(cSubCoil.CoilKey))
                    lstRemoveCoil.Add(cSubCoil);
                else
                    UpdatePlcProcHierarchyAbnormalSymbolS(cSubCoil, lstAllAbnormalKeyList);
            }

            if(lstRemoveCoil.Count > 0)
            {
                foreach (CSubCoil cSubCoil in lstRemoveCoil)
                    cCoil.SubCoilS.Remove(cSubCoil);
            }

            lstRemoveCoil.Clear();
            lstRemoveCoil = null;
        }



        private static bool ExtractFileToDirectory(string sZipPath, string sDirectory)
        {
            bool bOK = false;

            try
            {
                ZipFile zip = new ZipFile(sZipPath);

                if (Directory.Exists(sDirectory))
                    Directory.Delete(sDirectory, true);

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

        private static bool SaveLineInfo(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = "";
            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);
                string sLineInfoPath = sPath + "\\LineInfo.pinfo";

                CNetSerializer cSerializer = new CNetSerializer();

                //bOK = cSerializer.Write(sLineInfoPath, m_cLineInfo);
                bOK = cSerializer.Write(sLineInfoPath, m_cLineInfoS);


                cSerializer.Dispose();
                cSerializer = null;

                if (bOK == false)
                {
                    sMessage = "라인 정보를 저장하는데 실패했습니다.";
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SaveLineInfo Error " + ex.Message);
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

        private static bool OpenPlcInfoS(out string sMessage, string sPath)
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
                List<string> lstOpenError = OpenPlcLogicDataList(m_cBaseInfo.PlcIDList, sPath);
                iStep = 4;
                if (lstOpenError.Count > 0)
                {
                    for (int i = 0; i < lstOpenError.Count; i++)
                        Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstOpenError[i]));
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

        private static bool OpenLineInfo(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = "";

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);
                string sConfigPath = sPath + "\\LineInfo.pinfo";

                CNetSerializer cSerializer = new CNetSerializer();
                //CLineInfo cLineInfo = (CLineInfo)(cSerializer.Read(sConfigPath));
                CLineInfoS cLineInfoS = (CLineInfoS)(cSerializer.Read(sConfigPath));

                if (cLineInfoS != null)
                {
                    m_cLineInfoS = cLineInfoS;

                    cSerializer.Dispose();
                    cSerializer = null;

                    bOK = true;
                }
                else
                    sMessage = "라인 정보를 오픈하는데 실패했습니다.";
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenLineInfo Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;

        }

        private static void CheckErroInfoLogS(CErrorInfo cInfo)
        {
            if (cInfo.ErrorLogS != null && cInfo.ErrorLogS.Count != 0)
                return;

            cInfo.ErrorLogS = m_cReader.GetErrorLogS(cInfo.ErrorID);
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

        private static CMasterPattern GetErrorSubDepthMasterPattern(string sProcessKey, CCycleInfoS cCycleInfoS, CTagS cTagS, DateTime dtCycleStart, DateTime dtErrorTime)
        {
            CMasterPattern cMasterPattern = new CMasterPattern();
            cMasterPattern.Key = sProcessKey;

            CCycleInfo cInfo;
            CFlowItemS cItemS;
            CFlowItem cItem;
            CTimeNode cNode;
            CFlowRule cRule = new CFlowRule();
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                if (i == 0)
                    continue;

                Thread.Sleep(1);

                cInfo = cCycleInfoS.ElementAt(i).Value;

                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cTagS, cInfo.CycleStart, cInfo.CycleEnd);

                if (cItemS == null)
                    continue;

                for (int j = 0; j < cItemS.Count; j++)
                {
                    cItem = cItemS[j];
                    for (int k = 0; k < cItem.TimeNodeS.Count; k++)
                    {
                        cNode = cItem.TimeNodeS[k];
                        cNode.IsEnd = true;
                        cNode.IsStart = true;
                    }
                }
                cMasterPattern.Update(cInfo.CurrentRecipe, cItemS, cRule);
            }

            return cMasterPattern;
        }

        private static bool CheckContainAbnormalFilter(string sDescription)
        {
            bool bOK = false;

            foreach (string sFilter in m_lstAbnormalFilter)
            {
                if (sDescription.Contains(sFilter))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private static bool CheckContainAddressFilter(string sAddress)
        {
            bool bOK = true;

            foreach (string sFilter in m_lstAddressFilter)
            {
                if (sAddress.StartsWith(sFilter))
                {
                    bOK = true;
                    break;
                }
                else
                    bOK = false;
            }

            return bOK;

        }

        private static bool CheckMotionOnTag(CPlcProc cProcess, string sTagkey)
        {
            bool bOK = false;

            DateTime dtFrom = cProcess.CycleStartTimeLine;
            DateTime dtTo = cProcess.CycleEndTimeLine;

            CTimeLogS cLogS = m_cReader.GetTimeLogS(sTagkey, dtFrom, dtTo);

            if (cLogS == null)
                return false;

            if (cLogS.Count > 0)
                bOK = true;
            else if (cLogS.Count == 0)
            {
                CTimeLogS cTempLogS = m_cReader.GetTimeLogS(sTagkey);

                if (cTempLogS == null || cTempLogS.Count == 0)
                    return false;

                CTimeLog cTempLog = cTempLogS.GetLastLog(sTagkey, dtFrom);

                if (cTempLog != null && cTempLog.Value == 1)
                    bOK = true;
                else
                    bOK = false;
            }

            return bOK;
        }

        /// <summary>
        /// Project ID를 새로 발급해야만 함.
        /// </summary>


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

        private static CProjectBaseInfo TypeConvertTBaseToBase()
        {
            bool bOK = false;
            CProjectBaseInfo cBaseInfo = new CProjectBaseInfo();
            cBaseInfo.CollectSymbolSubDepth = m_cTBaseData.CollectSymbolSubDepth;

            if (m_cTBaseData.NonDetectTimeS != null)
            {
                CNonDetectTimeS cNonDetectTimeS = new CNonDetectTimeS();
                foreach (TrackerProject.CNonDetectTime cNonDTime in m_cTBaseData.NonDetectTimeS)
                {
                    CNonDetectTime cTime = new CNonDetectTime();
                    cTime.StartTime = cNonDTime.StartTime;
                    cTime.EndTime = cNonDTime.EndTime;
                    cNonDetectTimeS.Add(cTime);
                }
                cBaseInfo.NonDetectTimeS = cNonDetectTimeS;
            }

            cBaseInfo.ProjectBaseView = m_cTBaseData.ProjectBaseView;
            cBaseInfo.ApplyAbnormalPriority = m_cTBaseData.ApplyAbnormalPriority;
            cBaseInfo.DBPath = m_cTBaseData.DBPath;
            cBaseInfo.DBBackupPath = m_cTBaseData.DBBackupPath;
            switch (m_cTBaseData.LearningStep)
            {
                case TrackerProject.EMMonitorModeType.CollectEnd:
                    cBaseInfo.LearningStep = EMMonitorModeType.CollectEnd;
                    break;
                case TrackerProject.EMMonitorModeType.GruopEnd:
                    cBaseInfo.LearningStep = EMMonitorModeType.GruopEnd;
                    break;
                case TrackerProject.EMMonitorModeType.None:
                    cBaseInfo.LearningStep = EMMonitorModeType.None;
                    break;
                case TrackerProject.EMMonitorModeType.UpdateEnd:
                    cBaseInfo.LearningStep = EMMonitorModeType.UpdateEnd;
                    break;
            }
            switch (m_cTBaseData.MasterStep)
            {
                case TrackerProject.EMMonitorModeType.CollectEnd:
                    cBaseInfo.MasterStep = EMMonitorModeType.CollectEnd;
                    break;
                case TrackerProject.EMMonitorModeType.GruopEnd:
                    cBaseInfo.MasterStep = EMMonitorModeType.GruopEnd;
                    break;
                case TrackerProject.EMMonitorModeType.None:
                    cBaseInfo.MasterStep = EMMonitorModeType.None;
                    break;
                case TrackerProject.EMMonitorModeType.UpdateEnd:
                    cBaseInfo.MasterStep = EMMonitorModeType.UpdateEnd;
                    break;
            }

            cBaseInfo.ProjectName = m_cTBaseData.ProjectName;
            cBaseInfo.ProjectID = m_cTBaseData.ProjectID;
            cBaseInfo.ProjectPath = m_cTBaseData.ProjectPath;
            cBaseInfo.UserDeviceS = m_cTBaseData.UserDeviceS;
            cBaseInfo.RecipeWordList = m_cTBaseData.RecipeWordList;

            CPlcProcS cProcS = new CPlcProcS();
            foreach (var who in m_cTBaseData.PlcProcS)
            {
                //object cData = Convert.ChangeType(who.Value, typeof(TrackerProject.CPlcProc));
                CPlcProc cProc = new CPlcProc();
                cProc.AbnormalSymbolPriority = who.Value.AbnormalSymbolPriority;
                cProc.CollectSubDepth = who.Value.CollectSubDepth;
                cProc.IsErrorMonitoring = who.Value.IsErrorMonitoring;
                cProc.CycleCheckTag = who.Value.CycleCheckTag;
                cProc.AbnormalSymbolList = who.Value.AbnormalSymbolList;
                cProc.IsNormalAbnormalSymbol = who.Value.IsNormalAbnormalSymbol;
                cProc.RecipeFlowItemS = who.Value.RecipeFlowItemS;
                cProc.TotalAbnormalSymbolKey = who.Value.TotalAbnormalSymbolKey;
                cProc.AbnormalFilter = who.Value.AbnormalFilter;
                cProc.PlcLogicDataS = who.Value.PlcLogicDataS;
                cProc.Name = who.Value.Name;
                cProc.TargetTactTime = who.Value.TargetTactTime;
                cProc.CycleStartConditionS = who.Value.CycleStartConditionS;
                cProc.CycleEndConditionS = who.Value.CycleEndConditionS;
                cProc.KeySymbolS = who.Value.KeySymbolS;
                cProc.AbnormalSymbolS = who.Value.AbnormalSymbolS;
                cProc.CycleStartTimeLine = who.Value.CycleStartTimeLine;
                cProc.CycleEndTimeLine = who.Value.CycleEndTimeLine;
                cProc.ChartStartTime = who.Value.ChartStartTime;
                cProc.ChartEndTime = who.Value.ChartEndTime;
                cProc.ChartViewTagS = who.Value.ChartViewTagS;
                cProc.ChartViewTimeLogS = who.Value.ChartViewTimeLogS;
                cProc.CollectCandidateTagS = who.Value.CollectCandidateTagS;

                cProc.CycleErrorFlag = who.Value.CycleErrorFlag;
                cProc.CycleStartFlag = who.Value.CycleStartFlag;
                cProc.CycleEndFlag = who.Value.CycleEndFlag;
                cProc.CycleID = who.Value.CycleID;
                cProc.RecipeWordS = who.Value.RecipeWordS;
                cProc.SelectRecipeWord = who.Value.SelectRecipeWord;
                cProc.CurrentRecipe = who.Value.CurrentRecipe;

                cProcS.Add(who.Key, cProc);
            }
            cBaseInfo.PlcProcS = cProcS;
            cBaseInfo.PlcIDList = m_cTBaseData.PlcIDList;
            cBaseInfo.MonitorType = m_cTBaseData.MonitorType;
            cBaseInfo.RobotCycleTagS = m_cTBaseData.RobotCycleTagS;
            cBaseInfo.ViewRecipe = m_cTBaseData.ViewRecipe;
            cBaseInfo.Account = m_cTBaseData.Account;

            return cBaseInfo;
        }

        private static bool OpenBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();
            CProjectBaseInfo cBaseInfo = null;
            try
            {
                cBaseInfo = (cSerializer.Read(sPath)) as CProjectBaseInfo;
            }
            catch (Exception ex) { ex.Data.Clear(); }

            if (cBaseInfo != null)
            {
                m_cBaseInfo = cBaseInfo;
                m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath + "\\" + ProjectID;
                m_cBaseInfo.ProjectPath = sPath;

                //m_cMasterPatternInfo.ProjectID = m_cBaseInfo.ProjectID;
                //m_cMasterPatternInfo.ProjectName = m_cBaseInfo.ProjectName;
                //m_cMasterPatternInfo.MasterPatternS = (CMasterPatternS)m_cBaseInfo.MasterPatternS.Clone();

                bOK = true;
            }
            else
            {
                m_cTBaseData = (TrackerProject.CProjectBaseInfo)(cSerializer.Read(sPath));
                if (m_cTBaseData != null)
                {
                    m_cBaseInfo = TypeConvertTBaseToBase();
                    m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath + "\\" + ProjectID;
                    m_cBaseInfo.ProjectPath = sPath;
                    bOK = true;
                }
            }

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static bool SaveTotalTag(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cTotalTagS);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private static bool TypeConvertBaseToTBase()
        {
            bool bOK = false;

            m_cTBaseData.CollectSymbolSubDepth = m_cBaseInfo.CollectSymbolSubDepth;

            TrackerProject.CNonDetectTimeS cNonDetectTimeS = new TrackerProject.CNonDetectTimeS();
            foreach (CNonDetectTime cNonDTime in m_cBaseInfo.NonDetectTimeS)
            {
                TrackerProject.CNonDetectTime cTime = new TrackerProject.CNonDetectTime();
                cTime.StartTime = cNonDTime.StartTime;
                cTime.EndTime = cNonDTime.EndTime;
                cNonDetectTimeS.Add(cTime);
            }
            m_cTBaseData.NonDetectTimeS = cNonDetectTimeS;

            m_cTBaseData.ProjectBaseView = m_cBaseInfo.ProjectBaseView;
            m_cTBaseData.ApplyAbnormalPriority = m_cBaseInfo.ApplyAbnormalPriority;
            m_cTBaseData.DBPath = m_cBaseInfo.DBPath;
            m_cTBaseData.DBBackupPath = m_cBaseInfo.DBBackupPath;
            switch (m_cBaseInfo.LearningStep)
            {
                case EMMonitorModeType.CollectEnd:
                    m_cTBaseData.LearningStep = TrackerProject.EMMonitorModeType.CollectEnd;
                    break;
                case EMMonitorModeType.GruopEnd:
                    m_cTBaseData.LearningStep = TrackerProject.EMMonitorModeType.GruopEnd;
                    break;
                case EMMonitorModeType.None:
                    m_cTBaseData.LearningStep = TrackerProject.EMMonitorModeType.None;
                    break;
                case EMMonitorModeType.UpdateEnd:
                    m_cTBaseData.LearningStep = TrackerProject.EMMonitorModeType.UpdateEnd;
                    break;
            }
            switch (m_cBaseInfo.MasterStep)
            {
                case EMMonitorModeType.CollectEnd:
                    m_cTBaseData.MasterStep = TrackerProject.EMMonitorModeType.CollectEnd;
                    break;
                case EMMonitorModeType.GruopEnd:
                    m_cTBaseData.MasterStep = TrackerProject.EMMonitorModeType.GruopEnd;
                    break;
                case EMMonitorModeType.None:
                    m_cTBaseData.MasterStep = TrackerProject.EMMonitorModeType.None;
                    break;
                case EMMonitorModeType.UpdateEnd:
                    m_cTBaseData.MasterStep = TrackerProject.EMMonitorModeType.UpdateEnd;
                    break;
            }

            m_cTBaseData.ProjectName = m_cBaseInfo.ProjectName;
            m_cTBaseData.ProjectID = m_cBaseInfo.ProjectID;
            m_cTBaseData.ProjectPath = m_cBaseInfo.ProjectPath;
            m_cTBaseData.UserDeviceS = m_cBaseInfo.UserDeviceS;
            m_cTBaseData.RecipeWordList = m_cBaseInfo.RecipeWordList;

            TrackerProject.CPlcProcS cProcS = new TrackerProject.CPlcProcS();
            foreach (var who in m_cBaseInfo.PlcProcS)
            {
                //object cData = Convert.ChangeType(who.Value, typeof(TrackerProject.CPlcProc));
                TrackerProject.CPlcProc cProc = new TrackerProject.CPlcProc();
                cProc.AbnormalSymbolPriority = who.Value.AbnormalSymbolPriority;
                cProc.CollectSubDepth = who.Value.CollectSubDepth;
                cProc.IsErrorMonitoring = who.Value.IsErrorMonitoring;
                cProc.CycleCheckTag = who.Value.CycleCheckTag;
                cProc.AbnormalSymbolList = who.Value.AbnormalSymbolList;
                cProc.IsNormalAbnormalSymbol = who.Value.IsNormalAbnormalSymbol;
                cProc.RecipeFlowItemS = who.Value.RecipeFlowItemS;
                cProc.TotalAbnormalSymbolKey = who.Value.TotalAbnormalSymbolKey;
                cProc.AbnormalFilter = who.Value.AbnormalFilter;
                cProc.PlcLogicDataS = who.Value.PlcLogicDataS;
                cProc.Name = who.Value.Name;
                cProc.TargetTactTime = who.Value.TargetTactTime;
                cProc.CycleStartConditionS = who.Value.CycleStartConditionS;
                cProc.CycleEndConditionS = who.Value.CycleEndConditionS;
                cProc.KeySymbolS = who.Value.KeySymbolS;
                cProc.AbnormalSymbolS = who.Value.AbnormalSymbolS;
                cProc.CycleStartTimeLine = who.Value.CycleStartTimeLine;
                cProc.CycleEndTimeLine = who.Value.CycleEndTimeLine;
                cProc.ChartStartTime = who.Value.ChartStartTime;
                cProc.ChartEndTime = who.Value.ChartEndTime;
                cProc.ChartViewTagS = who.Value.ChartViewTagS;
                cProc.ChartViewTimeLogS = who.Value.ChartViewTimeLogS;
                cProc.CollectCandidateTagS = who.Value.CollectCandidateTagS;

                cProc.CycleErrorFlag = who.Value.CycleErrorFlag;
                cProc.CycleStartFlag = who.Value.CycleStartFlag;
                cProc.CycleEndFlag = who.Value.CycleEndFlag;
                cProc.CycleID = who.Value.CycleID;
                cProc.RecipeWordS = who.Value.RecipeWordS;
                cProc.SelectRecipeWord = who.Value.SelectRecipeWord;
                cProc.CurrentRecipe = who.Value.CurrentRecipe;

                cProcS.Add(who.Key, cProc);
            }
            m_cTBaseData.PlcProcS = cProcS;
            m_cTBaseData.PlcIDList = m_cBaseInfo.PlcIDList;
            m_cTBaseData.MonitorType = m_cBaseInfo.MonitorType;
            m_cTBaseData.RobotCycleTagS = m_cBaseInfo.RobotCycleTagS;
            m_cTBaseData.ViewRecipe = m_cBaseInfo.ViewRecipe;
            m_cTBaseData.Account = m_cBaseInfo.Account;

            return bOK;
        }

        private static bool SaveBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            try
            {
                TypeConvertBaseToTBase();
                bOK = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            if (bOK)
                bOK = cSerializer.Write(sPath, m_cTBaseData);
            else
                bOK = cSerializer.Write(sPath, m_cBaseInfo);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private static void TypeConvertMasterToTMaster()
        {
            m_cTMasterPatternInfo.IsAutoUpdateRecipe = m_cMasterPatternInfo.IsAutoUpdateRecipe;
            m_cTMasterPatternInfo.RecipeUpdateCount = m_cMasterPatternInfo.RecipeUpdateCount;
            m_cTMasterPatternInfo.ProjectName = m_cMasterPatternInfo.ProjectName;
            m_cTMasterPatternInfo.ProjectID = m_cMasterPatternInfo.ProjectID;
            m_cTMasterPatternInfo.MasterPatternS = m_cMasterPatternInfo.MasterPatternS;
        }

        private static bool SaveMasterInfo(string sPath)
        {
            bool bOK = false;

            string sBasePath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sMasterPath = sBasePath + "_M.umpp";
            try
            {
                TypeConvertMasterToTMaster();
                bOK = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            CNetSerializer cSerializer = new CNetSerializer();
            if (bOK)
                bOK = cSerializer.Write(sMasterPath, m_cTMasterPatternInfo);
            else
                bOK = cSerializer.Write(sMasterPath, m_cMasterPatternInfo);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private static CProjectMasterPatternInfo TypeConvertTMasterToMaster()
        {
            CProjectMasterPatternInfo cMasterInfo = new CProjectMasterPatternInfo();
            cMasterInfo.IsAutoUpdateRecipe = m_cTMasterPatternInfo.IsAutoUpdateRecipe;
            cMasterInfo.RecipeUpdateCount = m_cTMasterPatternInfo.RecipeUpdateCount;
            cMasterInfo.ProjectName = m_cTMasterPatternInfo.ProjectName;
            cMasterInfo.ProjectID = m_cTMasterPatternInfo.ProjectID;
            cMasterInfo.MasterPatternS = m_cTMasterPatternInfo.MasterPatternS;

            return cMasterInfo;
        }

        private static bool OpenMasterInfo(string sPath)
        {
            bool bOK = false;

            string sBasePath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sMasterPath = sBasePath + "_M.umpp";
            CProjectMasterPatternInfo cMasterInfo = null;
            CNetSerializer cSerializer = new CNetSerializer();
            try
            {
                cMasterInfo = (cSerializer.Read(sMasterPath)) as CProjectMasterPatternInfo;
            }
            catch (Exception ex) { ex.Data.Clear(); }
            
            if (cMasterInfo != null)
            {
                m_cMasterPatternInfo = cMasterInfo;
                bOK = true;
            }
            else
            {
                m_cTMasterPatternInfo = (TrackerProject.CProjectMasterPatternInfo)(cSerializer.Read(sMasterPath));
                if (m_cTMasterPatternInfo != null)
                {
                    m_cMasterPatternInfo = TypeConvertTMasterToMaster();
                    bOK = true;
                }
            }

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

                foreach (string sID in lstPlcID)
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO" + ".pcd";
                    string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO" + ".pcd";

                    if (m_cPlcLogicDataS.ContainsKey(sID))
                    {
                        bool bOK = cSerializer.Write(sFileTagPath, m_cPlcLogicDataS[sID].TagS);

                        if (bOK == false)
                            lstResult.Add(sFileTagPath);

                        bOK = cSerializer.Write(sFileStepPath, m_cPlcLogicDataS[sID].StepS);

                        if (bOK == false)
                            lstResult.Add(sFileStepPath);
                    }
                    else
                        lstResult.Add(sID + "  Not Found !! ");

                    cSerializer.Dispose();
                    cSerializer = null;
                }

                //Parallel.ForEach(lstPlcID, sID =>
                //{
                //    CNetSerializer cSerializer = new CNetSerializer();
                //    string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO" + ".pcd";
                //    string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO" + ".pcd";
                //    try
                //    {
                //        if (m_cPlcLogicDataS.ContainsKey(sID))
                //        {
                //            bool bOK = cSerializer.Write(sFileTagPath, m_cPlcLogicDataS[sID].TagS);

                //            if (bOK == false)
                //                lstResult.Add(sFileTagPath);

                //            bOK = cSerializer.Write(sFileStepPath, m_cPlcLogicDataS[sID].StepS);

                //            if (bOK == false)
                //                lstResult.Add(sFileStepPath);
                //        }
                //        else
                //            lstResult.Add(sID + "  Not Found !! ");

                //        cSerializer.Dispose();
                //        cSerializer = null;
                //    }
                //    catch (Exception ex)
                //    {
                //        exceptions.Enqueue(ex);
                //    }

                //});

                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }

            return lstResult;
        }

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

        private static void CreateTotalCycleInfoS()
        {
            foreach (var who in m_cBaseInfo.PlcProcS)
            {
                CCycleInfoS cCycleInfoS = new CCycleInfoS();
                CCycleInfo cCycleInfo = new CCycleInfo();

                cCycleInfo.CycleID = who.Value.CycleID;

                cCycleInfoS.Add(who.Value.CycleID, cCycleInfo);
                m_cTotalCycleInfoS.Add(who.Key, cCycleInfoS);
            }
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

        public static void CreateCollectSymbolS()
        {
            m_cCollectSymbolS.CreateCollectIndex(m_sProjectBaseFolder, ProjectID);
            m_cCollectSymbolS.MonitorType = MonitorType.ToString();
            m_cCollectSymbolS.StartTime = DateTime.Now;
        }


        #endregion
    }
}
