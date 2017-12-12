using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DevExpress.XtraSplashScreen;
using UDM.General.Threading;
using UDM.Log;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerOptimizerMessage(string sSender, string sMessage);
    public delegate void UEventHandlerOptimizationMessage(string sProcess, string sSender, string sMessage);
    public delegate void UEventHandlerOptimizerUpdateGrid();
    public delegate void UEventHandlerOptimizerStartOptimization(bool bAllProcess, string sProcess, bool bLastFrequency, bool bFrequencyCompl);

    public class CTrackerCollectOptimizer : CThreadWithQueBase<CCycleInfo>
    {
        private List<COptimizerView> m_lstOptimizerView = null;
        private List<COptimizerSelection> m_lstOptimizerSelection = null;

        public event UEventHandlerOptimizerMessage UEventSystemMessage = null;
        public event UEventHandlerOptimizerStartOptimization UEventOptimization = null;
        public event UEventHandlerOptimizerUpdateGrid UEventUpdateGrid = null;
        public event UEventHandlerOptimizationMessage UEventOptimizationMessage = null;

        public List<COptimizerView> OptimizerViewList
        {
            get { return m_lstOptimizerView; }
            set { m_lstOptimizerView = value; }
        }

        public List<COptimizerSelection> OptimizerSelectionList
        {
            get { return m_lstOptimizerSelection; }
            set { m_lstOptimizerSelection = value; }
        }

        private void UpdateOptimizer(string sProcess, string sRecipe)
        {
            try
            {
                if (CMultiProject.OptimizationOption.IsEachProcessMonitor && CMultiProject.OptimizationOption.CurrentProcess != sProcess)
                    return;

                if (!m_lstOptimizerSelection.Any(x => x.Process == sProcess && x.IsOptimizing))
                    return;

                COptimizerView cView = null;
                if (!m_lstOptimizerView.Any(x => x.Process == sProcess && x.Recipe == sRecipe))
                {
                    cView = new COptimizerView();
                    cView.Process = sProcess;
                    cView.Recipe = sRecipe;
                    cView.TargetCount = CMultiProject.OptimizationOption.CycleTargetCount;
                    cView.CurrentCount++;
                    cView.TargetFrequency = CMultiProject.OptimizationOption.OptimizationFrequency;
                    cView.MonitorStatus = "START";

                    m_lstOptimizerView.Add(cView);

                    if (UEventSystemMessage != null)
                        UEventSystemMessage("Collector",
                            string.Format("새로운 \'{0}\' 공정 \'{1}\' Recipe가 감지되었습니다.", sProcess, sRecipe));

                    if (UEventOptimizationMessage != null)
                        UEventOptimizationMessage(sProcess, "Collector",
                            string.Format("새로운 \'{0}\' 공정 \'{1}\' Recipe가 감지되었습니다.", sProcess, sRecipe));
                }
                else
                {
                    cView =
                        m_lstOptimizerView.SingleOrDefault(
                            x => x.Process == sProcess && x.Recipe == sRecipe);

                    if (cView == null)
                        return;

                    cView.CurrentCount++;

                    if (cView.CurrentFrequency < cView.TargetFrequency)
                        cView.MonitorStatus = "START";

                    if (cView.CurrentCount >= cView.TargetCount)
                    {
                        cView.MonitorStatus = "END";
                        if (UEventSystemMessage != null)
                            UEventSystemMessage("Collector",
                                string.Format("\'{0}\' 공정 \'{1}\' Recipe에 대한 사이클 수집을 완료했습니다.", sProcess,
                                    sRecipe));

                        if(UEventOptimizationMessage != null)
                            UEventOptimizationMessage(sProcess, "Collector",
                                string.Format("\'{0}\' 공정 \'{1}\' Recipe에 대한 사이클 수집을 완료했습니다.", sProcess,
                                    sRecipe));
                    }

                    if (!m_lstOptimizerView.Any(x => x.Process == sProcess && x.MonitorStatus != "END"))
                    {
                        COptimizerSelection cSelection =
                            m_lstOptimizerSelection.SingleOrDefault(x => x.Process == sProcess);

                        if (cSelection != null)
                        {
                            cSelection.IsOptimized = true;
                            cSelection.CurrentFrequency++;

                            foreach (var who in m_lstOptimizerView)
                            {
                                if (who.Process == cSelection.Process)
                                {
                                    who.CurrentFrequency++;
                                    who.CurrentCount = 0;
                                }
                            }
                        }
                    }
                }

                if (UEventUpdateGrid != null)
                    UEventUpdateGrid();

                CheckEndMonitoring(sProcess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void CheckEndMonitoring(string sProcess)
        {
            try
            {
                if (CMultiProject.OptimizationOption.IsEachProcessMonitor)
                {
                    COptimizerSelection cSelection =
                        m_lstOptimizerSelection.SingleOrDefault(x => x.Process == sProcess);

                    if (cSelection != null && cSelection.IsOptimized)
                    {
                        if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing && x.IsOptimized == false))
                        {
                            if (
                                !m_lstOptimizerSelection.Any(
                                    x => x.IsOptimizing && x.CurrentFrequency < x.TargetFrequency))
                            {
                                if (UEventOptimization != null)
                                    UEventOptimization(false, sProcess, true, true);
                            }
                            else
                            {
                                if (UEventOptimization != null)
                                    UEventOptimization(false, sProcess, false, true);
                            }
                        }
                        else
                        {
                            if (cSelection.CurrentFrequency >= cSelection.TargetFrequency)
                            {
                                if (UEventOptimization != null)
                                    UEventOptimization(false, sProcess, true, false);
                            }
                            else
                            {
                                if (UEventOptimization != null)
                                    UEventOptimization(false, sProcess, false, false);
                            }
                        }
                    }
                }
                else
                {
                    if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing && x.IsOptimized == false))
                    {
                        if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing && x.CurrentFrequency < x.TargetFrequency))
                        {
                            if (UEventOptimization != null)
                                UEventOptimization(true, sProcess, true, true);
                        }
                        else
                        {
                            if (UEventOptimization != null)
                                UEventOptimization(true, sProcess, false, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        protected override bool BeforeRun()
        {
            if (m_lstOptimizerSelection == null || m_lstOptimizerView == null)
                return false;

            return true;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
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
                Thread.Sleep(1);
                try
                {
                    CCycleInfo cInfo = m_cQue.DeQue();
                    if (cInfo == null) continue;
                    if (cInfo.CycleType != EMCycleRunType.Learning)
                    {
                        cInfo = null;
                        continue;
                    }

                    UpdateOptimizer(cInfo.GroupKey, cInfo.CurrentRecipe);
                    cInfo = null;
                }
                catch (Exception ex)
                {
                    CMultiProject.SystemLog.WriteLog("TrackerCollectOptimizer DoThreadWork", ex.Message);
                    ex.Data.Clear();
                }
            }
        }

    }

}

