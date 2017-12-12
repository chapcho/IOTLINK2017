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

namespace UDMLadderTracker
{
    public class CTrackerAnalyzer : CThreadWithQueBase<Dictionary<EMTrackerLogType, CTimeLogS>>
    {
        #region Member Variables

        private bool m_bFirst = true;
        private bool m_bCycleCheck = false;
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
        public event UEventHandlerTrackerInterlockError UEventInterlockError = null;
        public event UEventHandlerTrackerRobotCycleActive UEventRobotCycleOn = null;

        #endregion


        #region Properties

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

        /// <summary>
        /// Master Pattern Mode일때만 수집됨
        /// </summary>
        //public CTimeLogS InterlockCheckTimeLogS
        //{
        //    get { return m_cInterlockStateLogS; }
        //    set { m_cInterlockStateLogS = value; }
        //}

        #endregion


        #region Private Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private void AnalyzeNormal(CTimeLogS cLogS)
        {
            bool bChange = false;
            List<string> lstRobotTagKey = new List<string>();
            foreach (CTimeLog log in cLogS)
            {
                if (m_dicViewTag.ContainsKey(log.Key))
                {
                    CViewTag cTag = m_dicViewTag[log.Key];
                    cTag.CurrentValue = log.Value;
                    cTag.ChangeCount++;
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

                if (CMultiProject.MonitorType == EMMonitorType.Detection)
                {
                    foreach (var who in CMultiProject.PlcProcS)
                    {
                        CPlcProc cProcess = who.Value;
                        //Total Error는 동일 시점에서 들어온다는 전제임. 동일 시점에 발생하지 않으면 Error검출 불가!!
                        if (cLogS.Where(b => b.Key == cProcess.TotalAbnormalSymbolKey && b.Value > 0).Count() > 0 && cProcess.AbnormalSymbolS.IsContainKey(log.Key))
                        {
                            UpdateSystemMessage("Analyzer", string.Format("종합이상 Abnormal 발생 Log 확인 {0} / Abnormal Key : {1}", cProcess.TotalAbnormalSymbolKey, log.Key));
                            CheckAbnormalSymbol(who.Key, cProcess, log);
                        }
                        if (cProcess.AbnormalSymbolS.IsContainKey(log.Key))
                            UpdateSystemMessage("Analyzer", string.Format("Abnormal에 등록되어있는 Log발견{0}", log.Key));
                    }
                }

            }
            if (lstRobotTagKey.Count > 0)
            {
                m_ucRobotCycle.SetActiveTagS(lstRobotTagKey);
                //다른 Tag가 2번이상 동작했는데 한번도 동작하지 않는 RobotCycle Tag는 정지
                List<int> lstCycleCount = m_ucRobotCycle.CycleCountList.Values.Where(b => b > 2).ToList();
                if (lstCycleCount != null && lstCycleCount.Count > 0)
                {
                    List<string> lstProcess = m_ucRobotCycle.CycleCountList.Where(b => b.Value == 0).Select(b=>b.Key).ToList();
                    //m_ucRobotCycle.StopNotActiveTag(lstProcess);
                    m_ucRobotCycle.HideNotActiveControl(lstProcess);
                    foreach (string sKey in lstProcess)
                    {
                        if (UEventRobotCycleOn != null)
                            UEventRobotCycleOn(sKey, "No Active");
                    }
                }
            }

            m_CollectSymbolGrid.RefreshDataSource();
            if (bChange)
            {
                m_UserAllGrid.RefreshDataSource();
                m_UserWordGrid.RefreshDataSource();
            }
        }

        private void AnalyzeCycle(CTimeLogS cLogS)
        {
            bool bRecipe = false;

            foreach (CTimeLog log in cLogS)
            {
                if (m_cRecipeCheckTagS.ContainsKey(log.Key))
                    bRecipe = true;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    CPlcProc proc = who.Value;

                    if (bRecipe && proc.SelectRecipeWord.Key == log.Key)
                        proc.CurrentRecipe = GetRecipeName(log.Value);

                    if (proc.InOutTagS.Count == 0)
                        continue;

                    if (proc.InOutTagS.ContainsKey(log.Key) && log.Value > 0)
                    {
                        if (UEventCycleStart != null)
                            UEventCycleStart(who.Key, log.Time);

                        proc.CycleEndFlag = true;
                    }
                }
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
                    CErrorInfo cErrorInfo = CreateErrorInfo(sKey, cSymbol, cLog.Value);
                    //에러 발생했으므로 Event 발생
                    if (UEventInterlockError != null)
                        UEventInterlockError(cSymbol, cErrorInfo);
                }
            }
        }

        /// <summary>
        /// Master Pattern Mode일 경우만 동작
        /// On/Off Interlock판단을 위한 Log저장
        /// </summary>
        /// <param name="cLogS"></param>
        private void CheckInterlockState(CTimeLogS cLogS)
        {
            //for (int i = 0; i < cLogS.Count; i++)
            //{
            //    foreach (var who in CMultiProject.PlcProcS)
            //    {
            //        if (who.Value.AbnormalSymbolS.Count == 0) continue;
            //        if (who.Value.AbnormalSymbolS.ContainsKey(cLogS[i].Key))
            //        {
            //            m_cInterlockStateLogS.Add((CTimeLog)cLogS[i].Clone());
            //        }
            //    }
            //}
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
                    iSumValue += 0x1 << i;
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
            m_bFirst = true;
            m_bRun = true;

            AddRecipeCheckTagS();

            UpdateSystemMessage("Analyzer", string.Format("현재 수집 모드는 {0}", CMultiProject.MonitorType));
            List<string> lstTagKey = CMultiProject.PlcProcS.GetCollectTagKeyList(CMultiProject.MonitorType);
            UpdateSystemMessage("Analyzer",string.Format("BeforeRun Tag 수: {0}",lstTagKey.Count));
            lstTagKey.AddRange(CMultiProject.ProjectInfo.GetCollectTagKeyList());
            UpdateSystemMessage("Analyzer", string.Format("BeforeRun UserDevice + Robot 포함 Tag 수: {0}", lstTagKey.Count));
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
                    cCollTag.Description = cTag.Description;

                    m_dicViewTag.Add(cCollTag.Key, cCollTag);
                }
            }
            UpdateSystemMessage("Analyzer", string.Format("BeforeRun 수집대상 Tag 수: {0}", m_dicViewTag.Count));
            m_CollectSymbolGrid.DataSource = m_dicViewTag.Values.ToList();
            m_dicCycleStopwatch.Clear();

            foreach (var who in CMultiProject.PlcProcS)
                m_dicCycleStopwatch.Add(who.Key, new Stopwatch());
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
            Stopwatch swMain = new Stopwatch();
            int iStep = 0;
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    iStep = 0;
                    //Cycle 분석
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
                        continue;
                    }
                    iStep++;
                    AnalyzeCycle(cLogS);
                    iStep++;
                    AnalyzeNormal(cLogS);
                    iStep++;
                    cLogS.Clear();
                    cLogS = null;
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
