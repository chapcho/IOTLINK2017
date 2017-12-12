using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.General.Threading;
using UDM.Log;

namespace UDMTrackerSimple
{
    public class CTrackerRecipeChecker : CThreadWithQueBase<CCycleInfo>
    {
        private Dictionary<string, CCycleInfoS> m_dicProcessCycleInfoS = new Dictionary<string, CCycleInfoS>(); 
        private Dictionary<string, int> m_dicRecipeCycleCount = new Dictionary<string, int>();
        private Dictionary<string, CNewRecipeView> m_dicNewRecipeS = new Dictionary<string, CNewRecipeView>();

        public UEventHandlerTrackerNewRecipe UEventNewRecipeChecked = null;
        public UEventHandlerTrackerNewRecipeChanged UEventNewRecipeChanged = null;

        private FrmNewRecipeViewer m_frmViewer = null;

        protected override bool BeforeRun()
        {
            m_dicProcessCycleInfoS.Clear();
            m_dicRecipeCycleCount.Clear();
            m_dicNewRecipeS.Clear();

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
            CPlcProc cProcess = null;
            int iUpperRange = -1;
            int iLowerRange = -1;
            bool bCycleCollectComplete = true;
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    CCycleInfo cInfo = m_cQue.DeQue();
                    if (cInfo == null) continue;
                    if (cInfo.CycleType != EMCycleRunType.Complete)
                    {
                        cInfo = null;
                        continue;
                    }

                    cProcess = CMultiProject.PlcProcS[cInfo.GroupKey];
                    iUpperRange = Convert.ToInt32(cProcess.TargetTactTime*1.3);
                    iLowerRange = Convert.ToInt32(cProcess.TargetTactTime*0.7);

                    if (cInfo.CycleTimeValue.TotalMilliseconds > iUpperRange ||
                        cInfo.CycleTimeValue.TotalMilliseconds < iLowerRange) continue;

                    bCycleCollectComplete = true;
                    cProcess = null;

                    CNewRecipeView cView = null;
                    string sCountKey = string.Format("{0}_{1}", cInfo.GroupKey, cInfo.CurrentRecipe);
                    if (m_dicRecipeCycleCount.ContainsKey(sCountKey))
                    {
                        cView = m_dicNewRecipeS[sCountKey];

                        if (cView.CurrentCount == cView.TargetCount)
                        {
                            cInfo = null;
                            continue;
                        }

                        cView.CurrentCount++;
                        m_dicRecipeCycleCount[sCountKey]++;
                    }
                    else
                    {
                        m_dicRecipeCycleCount.Add(sCountKey, 1);
                        cView = new CNewRecipeView();
                        cView.CurrentCount = 1;
                        cView.TargetCount = CMultiProject.RecipeUpdateCount;
                        cView.GroupKey = cInfo.GroupKey;
                        cView.Recipe = cInfo.CurrentRecipe;

                        m_dicNewRecipeS.Add(sCountKey, cView);
                    }

                    CCycleInfoS cInfoS = null;
                    if (m_dicProcessCycleInfoS.ContainsKey(cInfo.GroupKey))
                    {
                        cInfoS = m_dicProcessCycleInfoS[cInfo.GroupKey];
                        cInfoS.Add(cInfo.CycleID, cInfo);
                    }
                    else
                    {
                        cInfoS = new CCycleInfoS();
                        cInfoS.Add(cInfo.CycleID, cInfo);
                        m_dicProcessCycleInfoS.Add(cInfo.GroupKey, cInfoS);
                    }
                    cInfoS = null;

                    if (UEventNewRecipeChanged != null)
                        UEventNewRecipeChanged(m_dicNewRecipeS.Values.ToList());

                    if (m_dicRecipeCycleCount.Values.Where(x => x < CMultiProject.RecipeUpdateCount).Count() > 0)
                        bCycleCollectComplete = false;

                    if (bCycleCollectComplete)
                    {
                        if (UEventNewRecipeChecked != null)
                            UEventNewRecipeChecked(m_dicProcessCycleInfoS);
                    }

                    cInfo = null;
                }
                catch (Exception ex)
                {
                    CMultiProject.SystemLog.WriteLog("TrackerRecipeChecker DoThreadWork", ex.Message);
                    ex.Data.Clear();
                }
            }
        }
    }

    public class CNewRecipeView
    {
        public string GroupKey { get; set; }
        public string Recipe { get; set; }
        public int CurrentCount { get; set; }
        public int TargetCount { get; set; }
    }
}
