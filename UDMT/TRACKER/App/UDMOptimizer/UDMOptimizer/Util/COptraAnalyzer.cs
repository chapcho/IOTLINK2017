using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TrackerCommon;
using TrackerProject;
using UDM.Common;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMOptimizer
{
    public class COptraAnalyzer : CThreadWithQueBase<Dictionary<EMOptraLogType, CTimeLogS>>
    {
        #region Member Variables

        private bool m_bFirst = true;
        private bool m_bAutoDetect = false;
        private Dictionary<string, CTimeLogS> m_dicProcessTimeLogS = new Dictionary<string, CTimeLogS>();
        private int m_iCycleCount = 0;
        //private CTimeLogS m_cInterlockStateLogS = new CTimeLogS();
        private CTagS m_cRecipeCheckTagS = new CTagS();
        //실시간처리 Component
        //private UCRobotCycle m_ucRobotCycle = null;
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


        #endregion


        #region Properties

        public bool IsAutoDetect
        {
            get { return m_bAutoDetect;}
            set { m_bAutoDetect = value; }
        }

        //public UCRobotCycle RobotCycle
        //{
        //    get { return m_ucRobotCycle; }
        //    set { m_ucRobotCycle = value; }
        //}

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

            //if (!cProcess.CycleStartFlag) return;
            //if (cProcess.CycleErrorFlag) return;

            //SetAllProcessErrorFlag();

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
                List<string> lstRobotTagKey = new List<string>();
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

        private void AnalyzeRecipe(CTimeLog cLog)
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                //if (who.Value.SelectRecipeWord == null) continue;
                //if (cLog.Key == who.Value.SelectRecipeWord.Key)
                //    who.Value.CurrentRecipe = GetRecipeName(cLog.Value);
            }
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
            //foreach (var who in CMultiProject.PlcProcS)
            //{
            //    if (who.Value.SelectRecipeWord != null)
            //        m_cRecipeCheckTagS.Add(who.Value.SelectRecipeWord);
            //}
        }


        #endregion


        #region Thread Method

        protected override bool BeforeRun()
        {
            m_bFirst = true;
            m_bRun = true;

            AddRecipeCheckTagS();

            List<string> lstTagKey = new List<string>(); 
            //CMultiProject.PlcProcS.GetCollectTagKeyList(CMultiProject.MonitorType);
            UpdateSystemMessage("Analyzer",string.Format("BeforeRun Tag 수: {0}",lstTagKey.Count));
            lstTagKey.AddRange(CMultiProject.ProjectInfo.GetCollectTagKeyList());
            UpdateSystemMessage("Analyzer", string.Format("BeforeRun UserDevice + Robot 포함 Tag 수: {0}", lstTagKey.Count));
            m_dicViewTag.Clear();
            m_iCycleCount = 0;
            
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
            m_dicCycleStopwatch.Clear();
            m_dicProcessTimeLogS.Clear();
            foreach (var who in CMultiProject.PlcProcS)
            {
                m_dicCycleStopwatch.Add(who.Key, new Stopwatch());
                m_dicProcessTimeLogS.Add(who.Key, new CTimeLogS());
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

            //m_ucRobotCycle.StopMonitor();
            
            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            Stopwatch swMain = new Stopwatch();
            int iGCCount = 0;

            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    //Cycle 분석
                    Dictionary<EMOptraLogType, CTimeLogS> cdicLogS = m_cQue.DeQue();
                    
                    if (cdicLogS == null) continue;
                    if (cdicLogS.Count == 0)
                    {
                        UpdateSystemMessage("Analyzer", "TimeLog가 없습니다.");
                        continue;
                    }

                    iGCCount++;

                    if (iGCCount%100000 == 0)
                    {
                        Thread.Sleep(1);
                        UpdateSystemMessage("Analyzer", string.Format("GC Collect 수행 Start {0:N0}", GC.GetTotalMemory(false)));
                        GC.Collect();
                        UpdateSystemMessage("Analyzer", string.Format("GC Collect 수행 End {0:N0}", GC.GetTotalMemory(true)));
                    }

                    CTimeLogS cLogS = cdicLogS.First().Value;
                    EMOptraLogType emType = cdicLogS.First().Key;
                    if (cLogS == null) continue;
                    if (m_bFirst)
                    {
                        m_bFirst = false;
                        //continue;
                    }
                    //AnalyzeRecipe(cLogS);
                    //AnalyzeCycle(cLogS);
                    AnalyzeNormal(cLogS);
                    cLogS.Clear();
                    cLogS = null;

                    cdicLogS.Clear();
                    cdicLogS = null;
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Analyzer", string.Format("Error Main Roof = {0}", ex.Message));
                    ex.Data.Clear();
                }
            }
        }

        #endregion

    }
}
