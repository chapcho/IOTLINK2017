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
using UDM.Log.Csv;

namespace UDMLadderTracker
{
    public static class CMultiProject
    {
        #region Member Variables

        //Base Info(단일 파일)
        private static CProjectBaseInfo m_cBaseInfo = new CProjectBaseInfo();
        //PLC별 Logic Data(개별 파일)
        private static CPlcLogicDataS m_cPlcLogicDataS = new CPlcLogicDataS();
        //PLC별 통신 설정(단일 파일)
        private static CPlcConfigS m_cPlcConfigS = new CPlcConfigS();

        //휘발성 Data
        private static string m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
        private static int m_iErrorCur = 0;
        private static CTagS m_cTotalTagS = new CTagS();
        private static List<string> m_lstUsedProjectID = new List<string>();
        private static CErrorInfoS m_cErrorInfoS = new CErrorInfoS();
        private static CMySqlLogReader m_cReader = null;

        private static Dictionary<string, CCycleInfoS> m_cTotalCycleInfoS = null; 

        private static bool m_bEditable = true;
        private static UCErrorView m_ucErrorView = null;
        private static UCErrorLogTable m_ucErrorLogTable = null;
        private static UCRobotCycle m_ucRobotCycle = null;
        private static UCStatusView m_ucStatusView = null;
        private static UCErrorListPanelS m_ucErrorPanelS = null;

        private static List<string> m_lstAbnormalFilter = null;

        private static Dictionary<string, double> m_dicProcessTimeAvr = new Dictionary<string, double>(); 

        #endregion


        #region Properties


        /// <summary>
        /// Process 별 통계적으로 계산되는 Process Time Average
        /// </summary>
        public static Dictionary<string, double> DicProcessTimeAvr
        {
            get { return m_dicProcessTimeAvr;}
            set { m_dicProcessTimeAvr = value;}
        }

        public static bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }

        public static List<string> AbnormalFilter
        {
            get { return m_lstAbnormalFilter; }
            set { m_lstAbnormalFilter = value; }
        }

        public static EMMonitorModeType PatternItemStep
        {
            get { return m_cBaseInfo.PatternItemStep; }
            set { m_cBaseInfo.PatternItemStep = value; }
        }

        public static UCErrorListPanelS ErrorPanelS
        {
            get { return m_ucErrorPanelS; }
            set { m_ucErrorPanelS = value; }
        }

        public static UCErrorView ErrorView
        {
            get { return m_ucErrorView;}
            set { m_ucErrorView = value; }
        }

        public static UCErrorLogTable ErrorLogTable
        {
            get { return m_ucErrorLogTable;}
            set { m_ucErrorLogTable = value; }
        }

        public static UCRobotCycle RobotCycle
        {
            get { return m_ucRobotCycle; }
            set { m_ucRobotCycle = value; }
        }

        public static UCStatusView StatusView
        {
            get { return m_ucStatusView;}
            set { m_ucStatusView = value; }
        }

        public static CProjectBaseInfo ProjectInfo
        {
            get { return m_cBaseInfo;;}
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
            get { return m_cBaseInfo.MasterPatternS; }
            set { m_cBaseInfo.MasterPatternS = value; }
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


        #endregion


        #region Public Method

        public static void Create(string sName)
        {
            Clear();

            CreateProjectID();
            ProjectName = sName;

            ClearCurrentID();
        }

        public static void ClearCurrentID()
        {
            if (m_cTotalCycleInfoS == null)
                m_cTotalCycleInfoS = new Dictionary<string, CCycleInfoS>();
            m_cTotalCycleInfoS.Clear();
            CreateTotalCycleInfoS();

            Refresh();
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

            bOK = OpenBaseInfo(sPath);
            if (bOK == false)
            {
                sMessage = "기본 프로젝트를 여는데 실패했습니다.";
                return false;
            }
            ReadInfoFromDB();

            string sConfigPath = m_sProjectBaseFolder + "\\PLC 통신설정.plccfg";
            bOK = OpenPlcConfigS(sConfigPath);
            if (bOK == false)
            {
                sMessage = "통신설정을 여는데 실패했습니다.";
                return false;
            }

            List<string> lstLoadError = OpenPlcLogicDataList(m_cBaseInfo.PlcIDList);
            if (lstLoadError.Count > 0)
            {
                for (int i = 0; i < lstLoadError.Count; i++)
                    Console.WriteLine(string.Format("Open Plc Logic Fail -> {0}", lstLoadError[i]));
                sMessage = "LogicData를 여는데 실패했습니다.";
                bOK = false;
            }
            foreach (var who in m_cPlcLogicDataS)
            {
                m_cTotalTagS.AddRange(who.Value.TagS);
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
            bOK = SaveBaseInfo(sPath);
            if (bOK == false)
            {
                sMessage = "기본 프로젝트를 저장하는데 실패했습니다.";
                return false;
            }

            if (Directory.Exists(m_sProjectBaseFolder) == false)
                Directory.CreateDirectory(m_sProjectBaseFolder);
            string sConfigPath = m_sProjectBaseFolder + "\\PLC 통신설정.plccfg";
            bOK = SavePlcConfigS(sConfigPath);
            if (bOK == false)
            {
                sMessage = "통신 설정을 저장하는데 실패했습니다.";
                return false;
            }

            List<string> lstSaveError = SavePlcLogicDataList(m_cBaseInfo.PlcIDList);
            if (lstSaveError.Count > 0)
            {
                for (int i = 0; i < lstSaveError.Count; i++)
                    Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstSaveError[i]));
                sMessage = "LogicData를 저장하는데 실패했습니다.";
                bOK = false;
            }

            return bOK;
        }

        public static void Refresh()
        {
            if (m_ucErrorView != null)
                m_ucErrorView.SetErrorView(ErrorInfoS, PlcProcS);

            if (m_ucErrorLogTable != null)
            {
                m_ucErrorLogTable.ErrorInfoS = ErrorInfoS;
                m_ucErrorLogTable.ShowGrid();
            }

            if (m_ucRobotCycle != null)
            {
                m_ucRobotCycle.Clear();
                m_ucRobotCycle.CycleTagS = m_cBaseInfo.RobotCycleTagS;
            }

            if (m_ucStatusView != null)
            {
                m_ucStatusView.SetProcessList(PlcProcS);
                m_ucStatusView.SetRobotCycleTag(ProjectInfo.RobotCycleTagS);
                m_ucStatusView.SetSPDList(PlcLogicDataS.Keys.ToList());
            }

            if (m_ucErrorPanelS != null)
            {
                m_ucErrorPanelS.ClearPanelS();
                m_ucErrorPanelS.SetErrorListPanelS();
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

                        foreach (var who2 in who.Value.InOutTagS)
                        {
                            cData = GetPlcLogicData(who2.Value);

                            if (!who.Value.PlcLogicDataS.ContainsValue(cData))
                                who.Value.PlcLogicDataS.Add(cData.PLCID, cData);
                        }
                    }
                }
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
                
                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

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
            foreach(var who in m_cPlcLogicDataS)
            {
                if(who.Value.PlcChannel == sChannel)
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
                if(lstTag.Contains(cTag) == false)
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

            if(cErrorCycleInfo!= null)
                sRecipe = cErrorCycleInfo.CurrentRecipe;

            foreach(var who in cSymbol.SubDepthTagList)
                cEndSubDepthTagS.Add(who);

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

        public static void UpdateKeySymbolS(CPlcProc cProcess)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                cProcess.UpdateKeySymbolS();

                if (m_lstAbnormalFilter == null)
                    return;

                foreach (var who in cProcess.KeySymbolS)
                    UpdateKeySymbol(who.Value);
            }
            SplashScreenManager.CloseDefaultWaitForm();
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

        #endregion


        #region Private Method

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
                for (int i = 0; i < cCauseTag.StepRoleS.Count; i ++)
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

        private static CMasterPattern GetErrorSubDepthMasterPattern(string sProcessKey, CCycleInfoS cCycleInfoS,  CTagS cTagS, DateTime dtCycleStart, DateTime dtErrorTime)
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

        private static void UpdateKeySymbol(CKeySymbol cSymbol)
        {
            List<CTag> lstSubDepthTag = null;
            List<CTag> lstSubDepthTagRenew = new List<CTag>();

            if (cSymbol.SubDepthTagList != null && cSymbol.SubDepthTagList.Count > 0)
            {
                lstSubDepthTagRenew.Clear();

                lstSubDepthTag = cSymbol.SubDepthTagList;

                foreach (CTag cTag in lstSubDepthTag)
                {
                    if (!CheckContainAbnormalFilter(cTag.Description))
                        lstSubDepthTagRenew.Add(cTag);
                }

                cSymbol.SubDepthTagList.Clear();
                cSymbol.SubDepthTagList.AddRange(lstSubDepthTagRenew);
            }

            if (cSymbol.FirstTagList != null && cSymbol.FirstTagList.Count > 0)
            {
                lstSubDepthTagRenew.Clear();

                lstSubDepthTag = cSymbol.FirstTagList;

                foreach (CTag cTag in lstSubDepthTag)
                {
                    if (!CheckContainAbnormalFilter(cTag.Description))
                        lstSubDepthTagRenew.Add(cTag);
                }

                cSymbol.FirstTagList.Clear();
                cSymbol.FirstTagList.AddRange(lstSubDepthTagRenew);
            }

            if (cSymbol.AllSubDepthTagList != null && cSymbol.AllSubDepthTagList.Count > 0)
            {
                lstSubDepthTagRenew.Clear();

                lstSubDepthTag = cSymbol.AllSubDepthTagList;

                foreach (CTag cTag in lstSubDepthTag)
                {
                    if (!CheckContainAbnormalFilter(cTag.Description))
                        lstSubDepthTagRenew.Add(cTag);
                }

                cSymbol.AllSubDepthTagList.Clear();
                cSymbol.AllSubDepthTagList.AddRange(lstSubDepthTagRenew);
            }
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

        /// <summary>
        /// Project ID를 새로 발급해야만 함.
        /// </summary>
        private static void Clear()
        {
            m_cBaseInfo.Clear();
            m_cPlcConfigS.Clear();
            m_cPlcLogicDataS.Clear();
            m_lstUsedProjectID.Clear();
            m_cErrorInfoS.Clear();
            m_cTotalTagS.Clear();

            if(m_ucErrorView != null)
                m_ucErrorView.ClearControl();

            if (m_ucErrorLogTable != null)
                m_ucErrorLogTable.Clear();

            if(m_ucRobotCycle != null)
                m_ucRobotCycle.Clear();

            if(m_ucStatusView != null)
                m_ucStatusView.ClearData();

            if(m_ucErrorPanelS != null)
                m_ucErrorPanelS.ClearPanelS();

            m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath;
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
        private static List<string> OpenPlcLogicDataList(List<string> lstPlcID)
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
                string sFilePath = m_sProjectBaseFolder + "\\" + sID + ".pcd";
                try
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
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }

            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        private static List<string> SavePlcLogicDataList(List<string> lstPlcID)
        {
            List<string> lstResult = new List<string>();
            if (m_cPlcLogicDataS == null)
                lstResult.Add("m_cPlcLogicDataS = null");
            else
            {
                var exceptions = new ConcurrentQueue<Exception>();

                Parallel.ForEach(lstPlcID, sID =>
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFilePath = m_sProjectBaseFolder + "\\" + sID + ".pcd";
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


        #endregion
    }
}
