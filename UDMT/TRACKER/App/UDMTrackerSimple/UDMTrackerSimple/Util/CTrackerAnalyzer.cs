using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TrackerCommon;
using UDM.Common;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public class CTrackerAnalyzer : CThreadWithQueBase<Dictionary<EMTrackerLogType, CTimeLogS>>
    {
        #region Member Variables

        private bool m_bFirst = true;
        private bool m_bAutoDetect = false;
        private bool m_bOptimizeMode = false;
        private string m_sSelectedProcess = string.Empty;

        private Dictionary<string, CTimeLogS> m_dicProcessTimeLogS = new Dictionary<string, CTimeLogS>();
        //private CTimeLogS m_cInterlockStateLogS = new CTimeLogS();
        private CTagS m_cRecipeCheckTagS = new CTagS();
        //실시간처리 Component
        private UCRobotCycle m_ucRobotCycle = null;
        private DevExpress.XtraGrid.GridControl m_CollectSymbolGrid = null;
        private DevExpress.XtraGrid.GridControl m_UserAllGrid = null;
        private DevExpress.XtraGrid.GridControl m_UserWordGrid = null;

        private Dictionary<string, CViewTag> m_dicViewTag = new Dictionary<string,CViewTag>();
        private Dictionary<string, Stopwatch> m_dicCycleStopwatch = new Dictionary<string, Stopwatch>();

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerTrackerCycleChange UEventCycleStart = null;
        public event UEventHandlerTrackerCycleChange UEventCycleEnd = null;
        public event UEventHandlerTrackerCycleChange UEventCycleCheck = null;
        public event UEventHandlerTrackerMaxCycleOver UEventMaxCycleOver = null;
        public event UEventHandlerTrackerInterlockError UEventInterlockError = null;
        public event UEventHandlerTrackerRobotCycleActive UEventRobotCycleOn = null;
        public event UEventHandlerTrackerMainRecipeValue UEventRecipeValue = null;
        public event UEventHandlerGridUpdated UEventRuntimeGridUpdate = null;
        public event UEventHandlerGridUpdated UEventUserDeviceGridUpdate = null;
        public event UEventHandlerTrackerUpdateFlowChart UEventUpdateFlowChart = null;


        #endregion


        #region Properties

        public bool IsOptimizeMode
        {
            get { return m_bOptimizeMode; }
            set { m_bOptimizeMode = value; }
        }

        public string SelectedProcess
        {
            get { return m_sSelectedProcess; }
            set { m_sSelectedProcess = value; }
        }

        public bool IsAutoDetect
        {
            get { return m_bAutoDetect;}
            set { m_bAutoDetect = value; }
        }

        public UCRobotCycle RobotCycle
        {
            get { return m_ucRobotCycle; }
            set { m_ucRobotCycle = value; }
        }

        public DevExpress.XtraGrid.GridControl CollectGrid
        {
            set { m_CollectSymbolGrid = value; }
        }

        public DevExpress.XtraGrid.GridControl UserAllGrid
        {
            set { m_UserAllGrid = value; }
        }

        public DevExpress.XtraGrid.GridControl UserWordGrid
        {
            set { m_UserWordGrid = value; }
        }

        #endregion

        public void GenerateCycleOver(string sProcessName)
        {
            CPlcProc cProcess = CMultiProject.PlcProcS[sProcessName];

            if (!cProcess.CycleStartFlag) return;
            //if (cProcess.CycleErrorFlag) return;

            //SetAllProcessErrorFlag();

            cProcess.CycleErrorFlag = true;

            UpdateSystemMessage("Analyzer" + sProcessName, string.Format("수동 Cycle Over Event발생!! 현재까지 수집된 KeySymbol Log : {0}", m_dicProcessTimeLogS[sProcessName].Count));

            if (UEventMaxCycleOver != null)
                UEventMaxCycleOver(sProcessName, m_dicProcessTimeLogS[sProcessName], false);
        }

        #region Private Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private void AnalyzeNormal(CTimeLogS cLogS)
        {
            try
            {
                bool bChange = false;
                bool bNonDetect = false;
                List<string> lstRobotTagKey = new List<string>();
                //List<CLineInfoTag> lstLineTag = new List<CLineInfoTag>();

                if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(DateTime.Now))
                    bNonDetect = true;

                foreach (CTimeLog log in cLogS)
                {
                    if (m_dicViewTag.ContainsKey(log.Key))
                    {
                        CViewTag cTag = m_dicViewTag[log.Key];
                        cTag.CurrentValue = log.Value;
                        cTag.ChangeCount++;

                        cTag = null;
                    }

                    if (CMultiProject.UserDeviceS.ContainsKey(log.Key))
                    {
                        CMultiProject.UserDeviceS[log.Key].Value = log.Value;
                        CMultiProject.UserDeviceS[log.Key].LastTime = log.Time;
                        CMultiProject.UserDeviceS[log.Key].ChangeCount++;
                        bChange = true;
                    }

                    if (CMultiProject.ProjectInfo.RobotCycleTagS.ContainsKey(log.Key) && log.Value > 0)
                    {
                        if (UEventRobotCycleOn != null)
                            UEventRobotCycleOn(log.Key, "RUN");
                        lstRobotTagKey.Add(log.Key);
                    }

                    //if (CMultiProject.LineInfoS.AllSymbolListKeyList().Contains(log.Key))
                    //{
                    //    CLineInfoTag cLineTag = new CLineInfoTag();
                    //    cLineTag.Tag = CMultiProject.TotalTagS[log.Key];
                    //    cLineTag.Value = log.Value;
                    //    lstLineTag.Add(cLineTag);
                    //}

                    foreach (var who in CMultiProject.PlcProcS)
                    {
                        CPlcProc cProcess = who.Value;
                        AddProcessCycleTimeLog(who.Key, cProcess, log);

                        //if (cLogS.Where(b => b.Key == cProcess.TotalAbnormalSymbolKey).Count() == 0 && !cProcess.CycleErrorFlag)
                        //    continue;


                        if (!bNonDetect)
                        {
                            if (cProcess.AbnormalSymbolS == null || cProcess.AbnormalSymbolS.Count == 0)
                                continue;

                            if (!cProcess.AbnormalSymbolS.IsContainKey(log.Key))
                                continue;

                            CheckAbnormalSymbol(who.Key, cProcess, log);
                            //if (!who.Value.IsNormalAbnormalSymbol && cLogS.Where(b => b.Key == cProcess.TotalAbnormalSymbolKey && b.Value > 0).Count() > 0)
                            //{
                            //    UpdateSystemMessage("Analyzer",
                            //        string.Format("종합이상 Abnormal 발생 Log 확인 {0} / Abnormal Key : {1}",
                            //            cProcess.TotalAbnormalSymbolKey, log.Key));
                            //    CheckAbnormalSymbol(who.Key, cProcess, log);
                            //}
                            //else if(who.Value.IsNormalAbnormalSymbol && cLogS.Where(b => b.Key == cProcess.TotalAbnormalSymbolKey && b.Value == 0).Count() > 0)
                            //{
                            //    UpdateSystemMessage("Analyzer",
                            //        string.Format("종합이상 Normal(정상) 발생 Log 확인 {0} / Abnormal Key : {1}",
                            //            cProcess.TotalAbnormalSymbolKey, log.Key));
                            //    CheckAbnormalSymbol(who.Key, cProcess, log);
                            //}
                        }
                        cProcess = null;
                    }
                }

                //if (lstLineTag.Count > 0)
                //{
                //    CMultiProject.LineInfoS.ValueChanged(lstLineTag);
                //}

                if (lstRobotTagKey.Count > 0)
                {
                    m_ucRobotCycle.SetActiveTagS(lstRobotTagKey);
                    //다른 Tag가 2번이상 동작했는데 한번도 동작하지 않는 RobotCycle Tag는 정지
                    List<int> lstCycleCount = m_ucRobotCycle.CycleCountList.Values.Where(b => b > 2).ToList();
                    if (lstCycleCount != null && lstCycleCount.Count > 0)
                    {
                        List<string> lstProcess =
                            m_ucRobotCycle.CycleCountList.Where(b => b.Value == 0).Select(b => b.Key).ToList();
                        //m_ucRobotCycle.StopNotActiveTag(lstProcess);
                        m_ucRobotCycle.HideNotActiveControl(lstProcess);
                        foreach (string sKey in lstProcess)
                        {
                            if (UEventRobotCycleOn != null)
                                UEventRobotCycleOn(sKey, "No Active");
                        }
                    }
                }

                if (UEventRuntimeGridUpdate != null)
                    UEventRuntimeGridUpdate();

                if (bChange)
                {
                    if (UEventUserDeviceGridUpdate != null)
                        UEventUserDeviceGridUpdate();
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Analyzer", "Analyze Normal Error");
                ex.Data.Clear();
            }
        }

        private void AnalyzeRecipe(CTimeLogS cLogS)
        {
            try
            {
                if (m_cRecipeCheckTagS.Count == 0)
                    return;

                foreach (CTimeLog cLog in cLogS)
                {
                    if (m_cRecipeCheckTagS.ContainsKey(cLog.Key) && cLog.Value != 0)
                        AnalyzeRecipe(cLog);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Analyzer", "Analyze REcipe Error");
                ex.Data.Clear();
            }
        }

        private void AnalyzeCycle(CTimeLogS cLogS)
        {
            try
            {
                foreach (CTimeLog log in cLogS)
                {
                    foreach (var who in CMultiProject.PlcProcS)
                    {
                        CPlcProc proc = who.Value;

                        if (proc.CycleCheckTag != null && proc.CycleCheckTag.Key == log.Key)
                        {
                            if (UEventCycleCheck != null)
                                UEventCycleCheck(who.Key, log.Time);
                        }

                        if (proc.CycleEndConditionS != null && proc.CycleStartFlag && proc.CycleEndConditionS.ContainsKey(log.Key))
                        {
                            CCondition cCondition = proc.CycleEndConditionS.GetSelectedKeyData(log.Key);

                            if ((cCondition.TargetValue == 100 && log.Value > 0) || cCondition.TargetValue == log.Value)
                            {
                                if (UEventCycleEnd != null)
                                    UEventCycleEnd(who.Key, log.Time);
                                proc.CycleStartFlag = false;
                                proc.CycleEndFlag = true;
                                m_dicCycleStopwatch[who.Key].Stop();
                                UpdateSystemMessage("Analyzer", string.Format("{0} Cycle End {1} ms", who.Key, m_dicCycleStopwatch[who.Key].ElapsedMilliseconds));
                                m_dicCycleStopwatch[who.Key].Reset();
                            }
                        }

                        if (proc.CycleStartConditionS != null && proc.CycleStartConditionS.ContainsKey(log.Key))
                        {
                            CCondition cCondition = proc.CycleStartConditionS.GetSelectedKeyData(log.Key);

                            if ((cCondition.TargetValue == 100 && log.Value > 0) || cCondition.TargetValue == log.Value)
                            {
                                if (UEventCycleStart != null)
                                {
                                    m_dicProcessTimeLogS[who.Key].Clear();
                                    m_dicProcessTimeLogS[who.Key].Add((CTimeLog)log.Clone());
                                    UEventCycleStart(who.Key, log.Time);
                                }
                                proc.CycleStartFlag = true;
                                UpdateSystemMessage("Analyzer", string.Format("{0} Cycle Start", who.Key));
                                m_dicCycleStopwatch[who.Key].Start();
                            }

                            cCondition = null;
                        }

                        proc = null;
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Analyzer", "Analyze Cycle Error");
                ex.Data.Clear();
            }
        }

        private void AnalyzeRecipe(CTimeLog cLog)
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.SelectRecipeWord == null) continue;
                if (cLog.Key == who.Value.SelectRecipeWord.Key)
                {
                    who.Value.CurrentRecipe = GetRecipeName(cLog.Value); //cLog.Value.ToString(); 

                    if (who.Value.CurrentRecipe != null && who.Value.CurrentRecipe != string.Empty)
                        CMultiProject.PlcFlowChart.UpdateFlowChartRecipe(who.Value.Name, who.Value.CurrentRecipe);
                    //if (who.Value.CurrentRecipe != null && who.Value.CurrentRecipe != "")
                        //CMultiProject.PlcSummaryS.UpdateCarTypeS(who.Key, who.Value.CurrentRecipe);
                }
            }
        }

        /// <summary>
        /// cycle 가동시 1회만 발생
        /// </summary>
        private void CheckCycleOver()
        {
            try
            {
                if (m_bFirst) return;
                if (CMultiProject.MonitorType != EMMonitorType.Detection) return;

                //대린테크 대응시 자동 Cycle Over Detecting 기능은 막아야함
                bool bNonDetect = false;

                if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(DateTime.Now))
                    bNonDetect = true;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.CycleStartFlag == false) continue;
                    if (who.Value.CycleErrorFlag) continue;
                    if (m_dicCycleStopwatch.ContainsKey(who.Key) == false) continue;
                    long nRunTime = m_dicCycleStopwatch[who.Key].ElapsedMilliseconds;
                    long nMaxTime = who.Value.MaxTactTime;
                    if (nMaxTime < nRunTime)
                    {
                        who.Value.CycleErrorFlag = true;

                        //if (bNonDetect)
                        //{
                            if (UEventMaxCycleOver != null)
                                UEventMaxCycleOver(who.Key, null, true);
                        //}
                        //else
                        //{
                        //    UpdateSystemMessage("Analyzer" + who.Key, string.Format("Auto Cycle Over Event발생!! 현재까지 수집된 KeySymbol Log : {0}", m_dicProcessTimeLogS[who.Key].Count));
                        //    //if (UEventMaxCycleOver != null)
                        //    //    UEventMaxCycleOver(who.Key, null, true);
                        //    if (UEventMaxCycleOver != null)
                        //        UEventMaxCycleOver(who.Key, m_dicProcessTimeLogS[who.Key], false);
                        //}
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void AddProcessCycleTimeLog(string sKey, CPlcProc cProcess,CTimeLog cLog)
        {
            if (cProcess.KeySymbolS.ContainsKey(cLog.Key) || cProcess.RecipeWordS.ContainsKey(cLog.Key))
            {
                m_dicProcessTimeLogS[sKey].Add((CTimeLog)cLog.Clone());

                if (UEventUpdateFlowChart != null)
                    UEventUpdateFlowChart(sKey, (CTimeLog)cLog.Clone());
            }
        }

        private void CheckAbnormalSymbol(string sKey, CPlcProc cProcess, CTimeLog cLog)
        {
            //if (cProcess.AbnormalSymbolS.IsContainKey(cLog.Key))
            {
                CAbnormalSymbol cSymbol = cProcess.AbnormalSymbolS.GetAbnormalSymbol(cLog);

                if (cSymbol != null)
                {
                    UpdateSystemMessage("InterlockError",
                        string.Format("{0}의 {1} 접점 Error발생 {2}", sKey, cLog.Key, cLog.Value));
                    //Error Info 생성
                    cProcess.CycleErrorFlag = true;
                    //SetAllProcessErrorFlag();
                    CErrorInfo cErrorInfo = CreateErrorInfo(sKey, cSymbol, cLog.Value);
                    //에러 발생했으므로 Event 발생
                    if (UEventInterlockError != null)
                        UEventInterlockError(cSymbol, cErrorInfo);
                }

                cSymbol = null;
            }
        }

        private CErrorInfo CreateErrorInfo(string sProcessKey, CAbnormalSymbol cAbnormalSymbol, int iValue)
        {
            if (cAbnormalSymbol == null) return null;

            CErrorInfo cErrInfo = new CErrorInfo();

            cErrInfo.ProjectID = CMultiProject.ProjectID;
            if (CMultiProject.PlcProcS.ContainsKey(sProcessKey))
                cErrInfo.CycleID = CMultiProject.PlcProcS[sProcessKey].CycleID + 1;
            else
                return null;

            cErrInfo.GroupKey = sProcessKey;
            cErrInfo.ErrorType = "Interlock";
            cErrInfo.ErrorLogS = new CTimeLogS();
            cErrInfo.ErrorMessage = cAbnormalSymbol.Tag.Description;
            cErrInfo.ErrorTime = DateTime.Now;
            cErrInfo.SymbolKey = cAbnormalSymbol.Tag.Key;
            cErrInfo.ErrorID = CMultiProject.ErrorIDCur++;
            cErrInfo.Value = iValue;

            UpdateSystemMessage("Analyzer", string.Format("{0}의 {2} ErrorInfo가 생성 ID : {1}", sProcessKey, cErrInfo.ErrorID, cAbnormalSymbol.Tag.Key));
            return cErrInfo;
        }

        private string GetRecipeName(int iValue)
        {
            CRecipeSection cRecipeSection = CMultiProject.ProjectInfo.ViewRecipe;
            string sResult = "";

            int iSumValue = 0;
            cRecipeSection.BitPosList.Sort();

            for (int i = 0; i < cRecipeSection.BitPosList.Count; i++)
            {
                int iBitValue = iValue & (0x1 << cRecipeSection.BitPosList[i]);
                if (iBitValue > 0)
                    iSumValue += 0x1 << cRecipeSection.BitPosList[i];
            }

            for (int i = 0; i < cRecipeSection.SectionItemList.Count; i++)
            {
                CRecipeSectionItem cItem = cRecipeSection.SectionItemList[i];
                if (cItem.ItemValue == iSumValue)
                {
                    sResult = cItem.ItemName;
                    break;
                }
            }
            return sResult;
        }

        private void AddRecipeCheckTagS()
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.SelectRecipeWord != null)
                    m_cRecipeCheckTagS.Add(who.Value.SelectRecipeWord);
            }
        }


        #endregion


        #region Thread Method

        protected override bool BeforeRun()
        {
            try
            {
                m_bFirst = true;
                m_bRun = true;

                AddRecipeCheckTagS();

                UpdateSystemMessage("Analyzer", string.Format("현재 수집 모드는 {0}", CMultiProject.MonitorType));
                List<string> lstTagKey = CMultiProject.PlcProcS.GetCollectTagKeyList(CMultiProject.MonitorType, m_bOptimizeMode, m_sSelectedProcess);
                UpdateSystemMessage("Analyzer", string.Format("BeforeRun Tag 수: {0}", lstTagKey.Count));
                lstTagKey.AddRange(CMultiProject.ProjectInfo.GetCollectTagKeyList());
                UpdateSystemMessage("Analyzer", string.Format("BeforeRun UserDevice + Robot 포함 Tag 수: {0}", lstTagKey.Count));
                //if (CMultiProject.LineInfo.ReadReadSymbolListKeyList.Count != 0)
                //    lstTagKey.AddRange(CMultiProject.LineInfo.ReadReadSymbolListKeyList);
                //UpdateSystemMessage("Analyzer", string.Format("BeforeRun UserDevice + Robot 포함 Tag 수: {0}", lstTagKey.Count));
                UpdateSystemMessage("Analyzer", string.Format("BeforeRun UserDevice + Robot + 생산 정보 포함 Tag 수: {0}", lstTagKey.Count));
                m_dicViewTag.Clear();

                foreach (string key in lstTagKey)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(key) && m_dicViewTag.ContainsKey(key) == false)
                    {
                        CTag cTag = CMultiProject.TotalTagS[key];

                        CViewTag cCollTag = new CViewTag();
                        cCollTag.Address = cTag.Address;
                        cCollTag.DataType = cTag.DataType;
                        cCollTag.Key = cTag.Key;
                        cCollTag.Name = cTag.Name;
                        cCollTag.Description = cTag.Description;
                        cCollTag.Channel = cTag.Channel;

                        m_dicViewTag.Add(cCollTag.Key, cCollTag);
                    }
                }
                UpdateSystemMessage("Analyzer", string.Format("BeforeRun 수집대상 Tag 수: {0}", m_dicViewTag.Count));
                m_CollectSymbolGrid.DataSource = m_dicViewTag.Values.ToList();
                m_CollectSymbolGrid.RefreshDataSource();
                m_dicCycleStopwatch.Clear();
                m_dicProcessTimeLogS.Clear();
                foreach (var who in CMultiProject.PlcProcS)
                {
                    m_dicCycleStopwatch.Add(who.Key, new Stopwatch());
                    m_dicProcessTimeLogS.Add(who.Key, new CTimeLogS());
                }
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
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

            m_ucRobotCycle.StopMonitor();
            
            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            int iStep = 0;

            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    iStep = 0;
                    //Cycle 분석
                    CheckCycleOver();
                    iStep++;
                    Dictionary<EMTrackerLogType, CTimeLogS> cdicLogS = m_cQue.DeQue();
                    
                    if (cdicLogS == null) continue;
                    if (cdicLogS.Count == 0)
                    {
                        UpdateSystemMessage("Analyzer", "TimeLog가 없습니다.");
                        continue;
                    }

                    iStep++;
                    CTimeLogS cLogS = cdicLogS.First().Value;
                    iStep++;
                    EMTrackerLogType emType = cdicLogS.First().Key;
                    iStep++;
                    if (cLogS == null) continue;
                    iStep++;            
                    if (m_bFirst)
                    {
                        m_bFirst = false;
                        //continue;
                    }
                    iStep++;
                    AnalyzeRecipe(cLogS);
                    iStep++;
                    AnalyzeNormal(cLogS);
                    iStep++;
                    AnalyzeCycle(cLogS);
                    iStep++;
                    cLogS.Clear();
                    cLogS = null;
                    iStep++;

                    cdicLogS.Clear();
                    cdicLogS = null;

                    iStep++;
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Analyzer", string.Format("Error Main Roof = {0}, FailStep {1}", ex.Message,iStep));
                    ex.Data.Clear();
                }
            }
        }

        #endregion

    }
}