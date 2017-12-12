using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Xpf.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;
using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using ThreadState = System.Threading.ThreadState;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerOptimizerMonitorStartEvent(bool bMonitorStartFirst, bool bAllProcess, string sProcess);
    public delegate void UEventHandlerOptimizerMonitorStopEvent(bool bMonitoringEnd);

    public partial class FrmCollectOptimizer : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bRun = false;
        private bool m_bLoad = false;
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private CMySqlLogReader m_cReader = null;
        private List<COptimizerView> m_lstOptimizerView = new List<COptimizerView>();
        private List<COptimizerSelection> m_lstOptimizerSelection = new List<COptimizerSelection>(); 
        private Stopwatch m_sw = new Stopwatch();

        private string m_sCurProcess = string.Empty;
        private string m_sCurRecipe = string.Empty;
        private Thread m_Thread = null;

        public event UEventHandlerOptimizerMonitorStartEvent UEventOptimizerMonitorStart = null;
        public event UEventHandlerOptimizerMonitorStopEvent UEventOptimizerMonitorStop = null;

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateSystemMessageCallback(string sSender, string sMessage);
        private delegate void UpdateProcessLogMessageCallback(string sProcess, string sSender, string sMessage);

        public FrmCollectOptimizer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        public bool IsLoad
        {
            get { return m_bLoad; }
            set { m_bLoad = value; }
        }

        public List<COptimizerView> OptimizerViewList
        {
            get { return m_lstOptimizerView;}
            set { m_lstOptimizerView = value; }
        }

        public List<COptimizerSelection> OptimizerSelectionList
        {
            get { return m_lstOptimizerSelection; }
            set { m_lstOptimizerSelection = value; }
        }

        private void SetMonitorAlarm(bool bStart)
        {
            if (bStart)
            {
                lblMonitorStatus.Text = "MONITOR ON";

                lblMonitorStatus.Appearance.BackColor = Color.LimeGreen;
                lblMonitorStatus.Appearance.BackColor2 = Color.GreenYellow;

                lblOperTime.Appearance.BackColor = Color.LimeGreen;
                lblOperTime.Appearance.BackColor2 = Color.GreenYellow;
            }
            else
            {
                lblMonitorStatus.Text = "MONITOR OFF";

                lblMonitorStatus.Appearance.BackColor = Color.FromArgb(201, 201, 201);
                lblMonitorStatus.Appearance.BackColor2 = Color.FromArgb(163, 163, 163);

                lblOperTime.Appearance.BackColor = Color.FromArgb(201, 201, 201);
                lblOperTime.Appearance.BackColor2 = Color.FromArgb(163, 163, 163);
            }
        }

        private void ShowProcessCollectTagS()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ShowProcessCollectTagS);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    exTreeList.Nodes.Clear();

                    exTreeList.BeginUpdate();
                    {
                        TreeListNode trnProcess = null;
                        foreach (var who in CMultiProject.PlcProcS)
                        {
                            trnProcess = CreateTreeNode(null, who.Value.Name, "", 0);
                            UpdateTreeNode(trnProcess, who.Value);

                            trnProcess.Expanded = true;
                        }
                    }
                    exTreeList.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UpdateTreeNode(TreeListNode trnParent, CPlcProc cProcess)
        {
            trnParent.Nodes.Clear();

            TreeListNode trnTag = null;
            foreach (CCollectTag cTag in cProcess.CollectCandidateTagS.Values)
            {
                trnTag = CreateTreeNode(trnParent, CMultiProject.TotalTagS[cTag.Key].Address,
                    CMultiProject.TotalTagS[cTag.Key].Description, 2);

                if(cTag.SameTimeSignalKeyList == null)
                    cTag.SameTimeSignalKeyList = new List<string>();

                if (cTag.SameTimeSignalKeyList.Count != 0)
                {
                    foreach (string sKey in cTag.SameTimeSignalKeyList)
                        CreateTreeNode(trnTag, CMultiProject.TotalTagS[sKey].Address, CMultiProject.TotalTagS[sKey].Description, 3);
                }
            }
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sName, string sDesc, int iImageIndex)
        {
            TreeListNode trnNode = null;
            bool bError = false;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] {sName, sDesc});
            else
                trnNode = trnParent.Nodes.Add(new object[] {sName, sDesc});

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;

            return trnNode;
        }

        public void UpdateOptimizer(string sProcess, string sRecipe)
        {
            try
            {
                m_sCurProcess = sProcess;
                m_sCurRecipe = sRecipe;

                if (m_Thread != null)
                {
                    //if (m_Thread.ThreadState == ThreadState.WaitSleepJoin)
                    //    m_Thread.Interrupt();
                    //else
                        m_Thread.Abort();

                    m_Thread = null;
                }

                m_Thread = new Thread(new ThreadStart(DoThreadWork));
                m_Thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void DoThreadWork()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(DoThreadWork);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    Thread.Sleep(5000);

                    COptimizerView cView = null;
                    if (!m_lstOptimizerView.Any(x => x.Process == m_sCurProcess && x.Recipe == m_sCurRecipe))
                    {
                        cView = new COptimizerView();
                        cView.Process = m_sCurProcess;
                        cView.Recipe = m_sCurRecipe;
                        cView.TargetCount = CMultiProject.OptimizationOption.CycleTargetCount;
                        cView.CurrentCount++;
                        cView.TargetFrequency = CMultiProject.OptimizationOption.OptimizationFrequency;
                        cView.MonitorStatus = "START";

                        m_lstOptimizerView.Add(cView);

                        UpdateOptimizerMessage("Collector",
                            string.Format("새로운 \'{0}\' 공정 \'{1}\' Recipe가 감지되었습니다.", m_sCurProcess, m_sCurRecipe));
                    }
                    else
                    {
                        cView =
                            m_lstOptimizerView.SingleOrDefault(
                                x => x.Process == m_sCurProcess && x.Recipe == m_sCurRecipe);

                        if (cView == null)
                            return;

                        cView.CurrentCount++;

                        if (cView.CurrentFrequency < cView.TargetFrequency)
                            cView.MonitorStatus = "START";

                        if (cView.CurrentCount >= cView.TargetCount)
                        {
                            cView.MonitorStatus = "END";
                            UpdateOptimizerMessage("Collector",
                                string.Format("\'{0}\' 공정 \'{1}\' Recipe에 대한 사이클 수집을 완료했습니다.", m_sCurProcess,
                                    m_sCurRecipe));
                        }

                        if (!m_lstOptimizerView.Any(x => x.Process == m_sCurProcess && x.MonitorStatus != "END"))
                        {
                            COptimizerSelection cSelection =
                                m_lstOptimizerSelection.SingleOrDefault(x => x.Process == m_sCurProcess);

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

                    grdMonitor.RefreshDataSource();
                    grdStatus.RefreshDataSource();

                    CheckEndMonitoring();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            finally
            {
                //if (m_Thread != null && m_Thread.ThreadState == ThreadState.Running)
                //{
                //    if (m_Thread.ThreadState == ThreadState.WaitSleepJoin)
                //        m_Thread.Interrupt();
                //    else
                //        m_Thread.Join();

                //    while (m_Thread.IsAlive)
                //        m_Thread.Abort();

                //    m_Thread = null;
                //}
            }
        }

        public void StartOptimization(bool bAllProcess, string sProcess, bool bLastFrequency, bool bFrequencyCompl)
        {
            try
            {
                //SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                CShowWaitForm.ShowForm("Optimization", "수집 태그 최적화 작업을 진행중입니다..", "Processing...", true);
                {
                    if (!bAllProcess)
                    {
                        if (bFrequencyCompl)
                        {
                            if (bLastFrequency)
                            {
                                UpdateOptimizerMessage("Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                UpdateOptimizationMessage(sProcess, "Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(true);
                                StartCollectOptimization(false, sProcess, true);
                            }
                            else
                            {
                                UpdateOptimizerMessage("Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                UpdateOptimizationMessage(sProcess, "Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(false);
                                StartCollectOptimization(false, sProcess, false);

                                foreach (var who in m_lstOptimizerSelection)
                                    who.IsOptimized = false;

                                SetOptimizerMonitoringStart(false);

                            }
                        }
                        else
                        {
                            if (bLastFrequency)
                            {
                                UpdateOptimizerMessage("Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                UpdateOptimizationMessage(sProcess, "Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(false);
                                StartCollectOptimization(false, sProcess, true);
                                SetOptimizerMonitoringStart(false);
                            }
                            else
                            {
                                UpdateOptimizerMessage("Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                UpdateOptimizationMessage(sProcess, "Optimizer",
                                    "\'" + sProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(false);
                                StartCollectOptimization(false, sProcess, false);
                                SetOptimizerMonitoringStart(false);
                            }
                        }
                    }
                    else if (bFrequencyCompl)
                    {
                        if (bLastFrequency)
                        {
                            UpdateOptimizerMessage("Optimizer", "모든 공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                            SetOptimizerMonitoringStop(true);
                            StartCollectOptimization(true, string.Empty, true);
                        }
                        else
                        {
                            SetOptimizerMonitoringStop(false);
                            StartCollectOptimization(true, string.Empty, false);

                            foreach (var who in m_lstOptimizerSelection)
                                who.IsOptimized = false;

                            SetOptimizerMonitoringStart(false);
                        }
                    }
                }
                CShowWaitForm.CloseForm();
                //SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void CheckEndMonitoring()
        {
            try
            {
                if (CMultiProject.OptimizationOption.IsEachProcessMonitor)
                {
                    COptimizerSelection cSelection = m_lstOptimizerSelection.SingleOrDefault(x => x.Process == m_sCurProcess);

                    if (cSelection != null && cSelection.IsOptimized)
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing == true && x.IsOptimized == false))
                            {
                                if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing == true && x.CurrentFrequency < x.TargetFrequency))
                                {
                                    UpdateOptimizerMessage("Optimizer", "\'" + m_sCurProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                    SetOptimizerMonitoringStop(true);
                                    StartCollectOptimization(false, m_sCurProcess, true);
                                }
                                else
                                {
                                    //분석 후 모니터링 종료
                                    UpdateOptimizerMessage("Optimizer",
                                        "\'" + m_sCurProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                    SetOptimizerMonitoringStop(false);
                                    StartCollectOptimization(false, m_sCurProcess, false);

                                    foreach (var who in m_lstOptimizerSelection)
                                        who.IsOptimized = false;

                                    SetOptimizerMonitoringStart(false);
                                }
                            }
                            else
                            {
                                //분석 후 다시 모니터링 진행
                                UpdateOptimizerMessage("Optimizer",
                                    "\'" + m_sCurProcess + "\'공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(false);
                                StartCollectOptimization(false, m_sCurProcess, false);
                                SetOptimizerMonitoringStart(false);
                            }
                        }
                        SplashScreenManager.CloseForm(false);
                    }
                }
                else
                {
                    if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing && x.IsOptimized == false))
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            if (!m_lstOptimizerSelection.Any(x => x.IsOptimizing == true && x.CurrentFrequency < x.TargetFrequency))
                            {
                                UpdateOptimizerMessage("Optimizer", "모든 공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(true);
                                StartCollectOptimization(true, string.Empty, true);
                            }
                            else
                            {
                                //분석 후 모니터링 종료
                                UpdateOptimizerMessage("Optimizer", "모든 공정에 대한 사이클 수집을 완료했습니다. 모니터링을 종료합니다.");
                                SetOptimizerMonitoringStop(false);
                                StartCollectOptimization(true, string.Empty, false);

                                foreach (var who in m_lstOptimizerSelection)
                                    who.IsOptimized = false;

                                SetOptimizerMonitoringStart(false);
                            }
                        }
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void StartCollectOptimization(bool bAllProcess, string sProcess, bool bLastFrequency)
        {
            try
            {
                if (m_cReader == null || m_cReader.IsConnected == false)
                {
                    AutoClosingMessageBox.Show("DB Connection Fail!!!", "DB Reader가 연결되지 않았습니다.",5000);
                    return;
                }

                COptimizerSelection cSelection = m_lstOptimizerSelection.SingleOrDefault(x => x.Process == sProcess);
                if (!bAllProcess && cSelection == null)
                    return;

                if (bAllProcess)
                {
                    foreach (var who in m_lstOptimizerSelection)
                    {
                        if (!who.IsOptimizing)
                            continue;

                        cSelection = m_lstOptimizerSelection.SingleOrDefault(x => x.Process == who.Process);

                        if (cSelection == null)
                            continue;

                        UpdateOptimizerMessage("Optimizer",
                            "\'" + who.Process + "\'공정의 수집 신호 최적화 작업을 시작합니다.(" +
                            string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                        UpdateOptimizationMessage(sProcess, "Optimizer",
                            "\'" + who.Process + "\'공정의 수집 신호 최적화 작업을 시작합니다.(" +
                            string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));

                        if (!cSelection.FrequencyRemoveKeyList.ContainsKey(cSelection.CurrentFrequency))
                            cSelection.FrequencyRemoveKeyList.Add(cSelection.CurrentFrequency,
                                SetProcessTagOptimization(who.Process));

                        UpdateOptimizerMessage("Optimizer",
                            "\'" + who.Process + "\'공정의 수집 신호 최적화 작업을 종료합니다.(" +
                            string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                        UpdateOptimizationMessage(sProcess, "Optimizer",
                            "\'" + who.Process + "\'공정의 수집 신호 최적화 작업을 종료합니다.(" +
                            string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                    }
                }
                else
                {
                    UpdateOptimizerMessage("Optimizer",
                        "\'" + sProcess + "\'공정의 수집 신호 최적화 작업을 시작합니다.(" +
                        string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                    UpdateOptimizationMessage(sProcess, "Optimizer",
                        "\'" + sProcess + "\'공정의 수집 신호 최적화 작업을 시작합니다.(" +
                        string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));

                    cSelection.FrequencyRemoveKeyList.Add(cSelection.CurrentFrequency,
                        SetProcessTagOptimization(sProcess));

                    UpdateOptimizerMessage("Optimizer",
                        "\'" + sProcess + "\'공정의 수집 신호 최적화 작업을 종료합니다.(" +
                        string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                    UpdateOptimizationMessage(sProcess, "Optimizer",
                        "\'" + sProcess + "\'공정의 수집 신호 최적화 작업을 종료합니다.(" +
                        string.Format("{0}/{1})", cSelection.CurrentFrequency, cSelection.TargetFrequency));
                }

                if (bLastFrequency)
                    FinalRemoveCollectTagList(bAllProcess, sProcess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FinalRemoveCollectTagList(bool bAllProcess, string sProcess)
        {
            try
            {
                List<string> lstFinalRemoveKey = null;
                CPlcProc cProcess = null;
                if (bAllProcess)
                {
                    foreach (var who in m_lstOptimizerSelection)
                    {
                        if (!who.IsOptimizing)
                            continue;

                        cProcess = CMultiProject.PlcProcS[who.Process];

                        lstFinalRemoveKey = GetFinalRemoveKey(who.Process);

                        UpdateOptimizerMessage("Optimizer", string.Format("\'{0}\'공정 최종 최적화 결과 태그 개수가 {1} → {2} 로 최적화 되었습니다.", cProcess.Name, cProcess.CollectCandidateTagS.Count, cProcess.CollectCandidateTagS.Count - lstFinalRemoveKey.Count));
                        UpdateOptimizationMessage(cProcess.Name, "Optimizer", string.Format("\'{0}\'공정 최종 최적화 결과 태그 개수가 {1} → {2} 로 최적화 되었습니다.", cProcess.Name, cProcess.CollectCandidateTagS.Count, cProcess.CollectCandidateTagS.Count - lstFinalRemoveKey.Count));

                        foreach (string sKey in lstFinalRemoveKey)
                            cProcess.CollectCandidateTagS.Remove(sKey);
                    }
                }
                else
                {
                    cProcess = CMultiProject.PlcProcS[sProcess];

                    lstFinalRemoveKey = GetFinalRemoveKey(sProcess);

                    UpdateOptimizerMessage("Optimizer", string.Format("\'{0}\'공정 최종 최적화 결과 태그 개수가 {1} → {2} 로 최적화 되었습니다.", cProcess.Name, cProcess.CollectCandidateTagS.Count, cProcess.CollectCandidateTagS.Count - lstFinalRemoveKey.Count));
                    UpdateOptimizationMessage(cProcess.Name, "Optimizer", string.Format("\'{0}\'공정 최종 최적화 결과 태그 개수가 {1} → {2} 로 최적화 되었습니다.", cProcess.Name, cProcess.CollectCandidateTagS.Count, cProcess.CollectCandidateTagS.Count - lstFinalRemoveKey.Count));

                    foreach (string sKey in lstFinalRemoveKey)
                        cProcess.CollectCandidateTagS.Remove(sKey);
                }

                if(lstFinalRemoveKey != null)
                    lstFinalRemoveKey.Clear();

                ShowProcessCollectTagS();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private List<string> GetFinalRemoveKey(string sProcess)
        {
            List<string> lstFinalRemoveKey = new List<string>();
            try
            {
                COptimizerSelection cSelection = null;

                cSelection = m_lstOptimizerSelection.SingleOrDefault(x => x.Process == sProcess);

                if (cSelection == null)
                    return lstFinalRemoveKey;

                int iMinCountIndex = 0;
                int nMinRemoveCount = 0;
                for (int i = 0; i < cSelection.FrequencyRemoveKeyList.Count; i++)
                {
                    if (i == 0)
                    {
                        nMinRemoveCount = cSelection.FrequencyRemoveKeyList.ElementAt(i).Value.Count;
                        iMinCountIndex = 0;
                    }
                    else if (cSelection.FrequencyRemoveKeyList.ElementAt(i).Value.Count < nMinRemoveCount)
                    {
                        nMinRemoveCount = cSelection.FrequencyRemoveKeyList.ElementAt(i).Value.Count;
                        iMinCountIndex = i;
                    }
                }

                bool bOK = true;
                List<string> lstMaxKey = cSelection.FrequencyRemoveKeyList.ElementAt(iMinCountIndex).Value;
                foreach (string sKey in lstMaxKey)
                {
                    for (int i = 0; i < cSelection.FrequencyRemoveKeyList.Count; i++)
                    {
                        if (i == iMinCountIndex)
                            continue;

                        bOK = true;
                        if (!cSelection.FrequencyRemoveKeyList.ElementAt(i).Value.Contains(sKey))
                            bOK = false;
                    }

                    if (bOK)
                        lstFinalRemoveKey.Add(sKey);
                }

                cSelection.FrequencyRemoveKeyList.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return lstFinalRemoveKey;
        }

        private List<string> SetProcessTagOptimization(string sProcess)
        {
            List<string> lstRemoveKey = new List<string>();

            try
            {
                Dictionary<string, CCycleInfoS> dicRecipeCycleInfoS = new Dictionary<string, CCycleInfoS>();

                CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
                CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, sProcess, "Learning",
                    m_dtFrom, m_dtTo);
                CTimeLogS cTotalLogS = new CTimeLogS();
                Dictionary<string, int> dicSignalFrequency = new Dictionary<string, int>();

                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                {
                    UpdateOptimizerMessage("Optimizer",
                        "해당 기간 동안의 \'" + sProcess + "\' 공정에 대한 Learning Cycle 정보가 존재하지 않습니다.");
                    return lstRemoveKey;
                }

                //차종별로 CYcle 묶음
                CCycleInfoS cInfoS = null;
                foreach (var who in cCycleInfoS)
                {
                    if (dicRecipeCycleInfoS.ContainsKey(who.Value.CurrentRecipe))
                    {
                        cInfoS = dicRecipeCycleInfoS[who.Value.CurrentRecipe];
                        cInfoS.Add(who.Value.CycleID, who.Value);
                    }
                    else
                    {
                        cInfoS = new CCycleInfoS();
                        cInfoS.Add(who.Value.CycleID, who.Value);

                        dicRecipeCycleInfoS.Add(who.Value.CurrentRecipe, cInfoS);
                    }
                }
                
                CTimeLogS cLogS = null;
                foreach (var who in dicRecipeCycleInfoS)
                {
                    cInfoS = who.Value;
                    foreach (CCycleInfo cInfo in cInfoS.Values)
                    {
                        foreach (string sKey in cProcess.CollectCandidateTagS.Keys)
                        {
                            if (lstRemoveKey.Contains(sKey))
                                continue;

                            cLogS = m_cReader.GetTimeLogS(sKey, cInfo.CycleStart, cInfo.CycleEnd);

                            if (cLogS == null || cLogS.Count == 0)
                                continue;

                            if (cLogS.Count >= CMultiProject.OptimizationOption.RemoveSignalFrequency)
                            {
                                UpdateOptimizationMessage(cProcess.Name, sKey, string.Format("\'{0}\'공정 \'Address : {1}, Desc : {2} 신호\'는 사이클 내 제거 가능한 신호 빈도수를 초과하여 자동 삭제됩니다", cProcess.Name, CMultiProject.TotalTagS[sKey].Address, CMultiProject.TotalTagS[sKey].Description));
                                lstRemoveKey.Add(sKey);
                                continue;
                            }

                            cTotalLogS.AddRange(cLogS);
                            cLogS.Clear();
                            cLogS = null;
                        }
                    }
                }

                foreach (string sKey in cProcess.CollectCandidateTagS.Keys)
                {
                    if (lstRemoveKey.Contains(sKey))
                        continue;

                    if (CMultiProject.OptimizationOption.RemoveFixValue && cTotalLogS.Where(x => x.Key == sKey).Count() <= 2)
                    {
                        UpdateOptimizationMessage(cProcess.Name, sKey, string.Format("\'{0}\'공정 \'Address : {1}, Desc : {2}\' 신호는 Always ON/OFF 신호이므로 자동 삭제됩니다. COUNT : {3}", cProcess.Name, CMultiProject.TotalTagS[sKey].Address, CMultiProject.TotalTagS[sKey].Description, cTotalLogS.Where(x => x.Key == sKey).Count()));
                        lstRemoveKey.Add(sKey);
                    }

                    dicSignalFrequency.Add(sKey, cTotalLogS.Where(x => x.Key == sKey).Count());
                }

                if (CMultiProject.OptimizationOption.RemoveSameTimeSignal)
                {
                    int iFrequency = -1;
                    List<string> lstSameFrequencyKey = null;
                    foreach (var who in dicSignalFrequency)
                    {
                        iFrequency = who.Value;

                        if (lstRemoveKey.Contains(who.Key))
                            continue;

                        lstSameFrequencyKey =
                            dicSignalFrequency.Where(x => x.Value == iFrequency).Select(x => x.Key).ToList();

                        if (lstSameFrequencyKey.Count == 1)
                            continue;

                        RemoveSameFrequency(cProcess, lstSameFrequencyKey, who.Key, cTotalLogS, lstRemoveKey);
                    }
                }

                COptimizerSelection cSelection = m_lstOptimizerSelection.SingleOrDefault(x => x.Process == cProcess.Name);

                if(cSelection != null)
                    UpdateOptimizerMessage("Optimizer", string.Format("Frequency : {0}/{1}, \'{2}\'공정 최적화 결과 태그 개수가 {3} → {4} 로 최적화 되었습니다.", cSelection.CurrentFrequency, cSelection.TargetFrequency, cProcess.Name, cProcess.CollectCandidateTagS.Count, cProcess.CollectCandidateTagS.Count - lstRemoveKey.Count));

                //foreach (string sKey in lstRemoveKey)
                //    cProcess.CollectCandidateTagS.Remove(sKey);

                if (cTotalLogS != null)
                    cTotalLogS.Clear();
                cTotalLogS = null;

                if(cCycleInfoS != null)
                    cCycleInfoS.Clear();
                cCycleInfoS = null;

                dicRecipeCycleInfoS.Clear();
                dicSignalFrequency.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                return lstRemoveKey;
            }
            return lstRemoveKey;
        }

        private void RemoveSameFrequency(CPlcProc cProcess, List<string> lstSameFrequencyKey, string sCurKey, CTimeLogS cTotalLogS, List<string> lstRemoveKey)
        {
            try
            {
                CTimeLogS cCurLogS = cTotalLogS.GetTimeLogS(sCurKey);
                CTimeLogS cLogS = null;
                foreach (string sKey in lstSameFrequencyKey)
                {
                    if (sKey == sCurKey || lstRemoveKey.Contains(sKey))
                        continue;

                    cLogS = cTotalLogS.GetTimeLogS(sKey);
                    if (cCurLogS.IsSameSignal(cLogS))
                    {
                        UpdateOptimizationMessage(cProcess.Name, sKey, string.Format("\'{0}\'공정의 \'Address : {1}, Desc : {2}\' 신호는 \'Address : {3}, Desc : {4}\' 신호의 값과 동일합니다.", cProcess.Name, CMultiProject.TotalTagS[sCurKey].Address, CMultiProject.TotalTagS[sCurKey].Description, CMultiProject.TotalTagS[sKey].Address, CMultiProject.TotalTagS[sKey].Description));

                        if(cProcess.CollectCandidateTagS.ContainsKey(sCurKey) && !cProcess.CollectCandidateTagS[sCurKey].SameTimeSignalKeyList.Contains(sKey))
                            cProcess.CollectCandidateTagS[sCurKey].SameTimeSignalKeyList.Add(sKey);

                        lstRemoveKey.Add(sKey);
                    }

                    if(cLogS != null)
                        cLogS.Clear();
                    cLogS = null;
                }

                if(cCurLogS != null)
                    cCurLogS.Clear();
                cCurLogS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private bool IsFirstSignalPriority(string sFirst, string sSecond)
        {
            //First Key가 우선순위가 높으면 True, Second가 높으면 False
            bool bOK = false;

            CTag cFirstTag = CMultiProject.TotalTagS[sFirst];
            CTag cSecondTag = CMultiProject.TotalTagS[sSecond];

            if (cFirstTag.PLCMaker.ToString().Contains("Mitsubishi"))
            {

                
            }
            else if (cFirstTag.PLCMaker.Equals(EMPLCMaker.Siemens))
            {

            }
            else
                bOK = true;

            return bOK;
        }

        private void SetOptimizerMonitoringStart(bool bFirst)
        {
            try
            {
                if (!CMultiProject.OptimizationOption.IsEachProcessMonitor)
                {
                    if (UEventOptimizerMonitorStart != null)
                        UEventOptimizerMonitorStart(bFirst, true, string.Empty);

                    UpdateOptimizerMessage("Optimizer", "모든 공정 모니터링을 시작했습니다.");
                }
                else
                {
                    foreach (var who in m_lstOptimizerSelection)
                    {
                        if (!who.IsOptimizing)
                            continue;

                        if (!who.IsOptimized)
                        {
                            if (UEventOptimizerMonitorStart != null)
                                UEventOptimizerMonitorStart(bFirst, false, who.Process);

                            CMultiProject.OptimizationOption.CurrentProcess = who.Process;

                            UpdateOptimizerMessage("Optimizer", "\'" + who.Process + "\'공정 모니터링을 시작했습니다. 신호 개수 : " + CMultiProject.PlcProcS[who.Process].CollectCandidateTagS.Count);

                            UpdateOptimizationMessage(who.Process, "Optimizer", "\'" + who.Process + "\'공정 모니터링을 시작했습니다. 신호 개수 : " + CMultiProject.PlcProcS[who.Process].CollectCandidateTagS.Count);
                            break;
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

        private void SetOptimizerMonitoringStop(bool bMonitoringEnd)
        {
            try
            {
                if (UEventOptimizerMonitorStop != null)
                    UEventOptimizerMonitorStop(bMonitoringEnd);

                if (bMonitoringEnd)
                {
                    btnMonitorStop_Click(null, null);
                    XtraMessageBox.Show("Collect Optimization Success!!!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void InitProcessObject()
        {
            if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                return;

            m_lstOptimizerSelection.Clear();

            XtraTabPage tpPage = null;
            UCSystemLogTable ucLogTable = null;
            COptimizerSelection cSelection = null;
            foreach (string sKey in CMultiProject.PlcProcS.Keys)
            {
                cSelection = new COptimizerSelection();
                cSelection.Process = sKey;
                cSelection.IsOptimizing = true;

                m_lstOptimizerSelection.Add(cSelection);

                if (tabLog.TabPages.Any(x => x.Text == sKey))
                    continue;

                tpPage = new XtraTabPage();
                tpPage.Text = sKey;
                
                ucLogTable = new UCSystemLogTable();
                ucLogTable.IsAutoFilterRowView = true;
                ucLogTable.Dock = DockStyle.Fill;
                tpPage.Controls.Add(ucLogTable);
                tabLog.TabPages.Add(tpPage);
            }

            grdProcess.DataSource = m_lstOptimizerSelection;
            grdProcess.RefreshDataSource();

            grdMonitor.DataSource = m_lstOptimizerView;
            grdMonitor.RefreshDataSource();

            grdStatus.DataSource = m_lstOptimizerView;
            grdStatus.RefreshDataSource();
        }

        public void UpdateGrid()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(UpdateGrid);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    grdMonitor.RefreshDataSource();
                    grdStatus.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateOptimizerMessage(string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateSystemMessageCallback cUpdate = new UpdateSystemMessageCallback(UpdateOptimizerMessage);
                    this.Invoke(cUpdate, new object[] {sSender, sMessage});
                }
                else
                {
                    ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    CMultiProject.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateOptimizationMessage(string sProcess, string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateProcessLogMessageCallback cUpdate = new UpdateProcessLogMessageCallback(UpdateOptimizationMessage);
                    this.Invoke(cUpdate, new object[] {sProcess, sSender, sMessage});
                }
                else
                {
                    UCSystemLogTable ucLogTable = null;

                    if (!tabLog.TabPages.Any(x => x.Text == sProcess))
                        return;

                    XtraTabPage tpPage = tabLog.TabPages.SingleOrDefault(x => x.Text == sProcess);
                    ucLogTable = (UCSystemLogTable)tpPage.Controls[0];

                    if (ucLogTable == null)
                        return;

                    ucLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    CMultiProject.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void MonitorStart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(MonitorStart);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (XtraMessageBox.Show("현재 Monitoring Mode는 '수집 최적화 모드'입니다.\r\n수집을 시작하시겠습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    m_bRun = true;
                    btnMonitorStop.Enabled = true;
                    btnMonitorStart.Enabled = false;
                    tabSetting.Enabled = false;
                    dtpkFrom.Enabled = false;
                    dtpkTo.Enabled = false;
                    btnOptimize.Enabled = false;

                    m_dtFrom = DateTime.Now;
                    dtpkFrom.EditValue = m_dtFrom;

                    m_lstOptimizerView.Clear();
                    foreach (var who in m_lstOptimizerSelection)
                    {
                        who.IsOptimized = false;
                        who.FrequencyRemoveKeyList.Clear();
                        who.TargetFrequency = CMultiProject.OptimizationOption.OptimizationFrequency;
                        who.CurrentFrequency = 0;

                        if (who.IsOptimizing)
                            CMultiProject.PlcProcS[who.Process].IsOptimizerSelectedProcess = true;
                    }

                    grdMonitor.RefreshDataSource();
                    grdStatus.RefreshDataSource();

                    lblOperTime.Text = "00:00:00";
                    timer.Start();
                    m_sw.Reset();
                    m_sw.Start();

                    SetMonitorAlarm(true);
                    tabMain.SelectedTabPage = tpMonitor;
                    SetOptimizerMonitoringStart(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void MonitorStop()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(MonitorStop);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (m_lstOptimizerSelection.Any(x => x.IsOptimizing && x.IsOptimized == false))
                    {
                        if (
                            XtraMessageBox.Show("현재 수집이 완료되지 않은 공정/RECIPE가 존재합니다.\r\n그래도 수집을 멈추시겠습니까?", "Warning",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                    }

                    m_bRun = false;
                    btnMonitorStop.Enabled = false;
                    btnMonitorStart.Enabled = true;
                    tabSetting.Enabled = true;
                    dtpkFrom.Enabled = true;
                    dtpkTo.Enabled = true;
                    btnOptimize.Enabled = true;

                    timer.Stop();
                    m_sw.Stop();

                    SetMonitorAlarm(false);
                    SetOptimizerMonitoringStop(false);
                    UpdateOptimizerMessage("Optimizer", "모든 공정 모니터링을 종료했습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmCollectOptimizer_Load(object sender, EventArgs e)
        {
            try
            {
                btnMonitorStop.Enabled = false;
                m_dtFrom = DateTime.Now.AddDays(-1);
                m_dtTo = DateTime.Now;

                dtpkFrom.EditValue = m_dtFrom;
                dtpkTo.EditValue = m_dtTo;

                InitProcessObject();

                if(CMultiProject.OptimizationOption == null)
                    CMultiProject.OptimizationOption = new COptimizationOption();

                exProperty.SelectedObject = CMultiProject.OptimizationOption;
                exProperty.Refresh();

                ShowProcessCollectTagS();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMonitorStart_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorStart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMonitorStop_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorStop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmCollectOptimizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_bRun)
                {
                    XtraMessageBox.Show("모니터링이 진행 중입니다!!!\r\n먼저 모니터링을 종료하세요.", "ERROR", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                this.Hide();
                e.Cancel = e.CloseReason == CloseReason.UserClosing;
                m_bLoad = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvMonitor_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string sStatus = string.Empty;
                var grvView = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                if (e.Column.FieldName == "MonitorStatus")
                {
                    var category = grvView.GetRowCellValue(e.RowHandle, grvView.Columns["MonitorStatus"]);

                    if (category != null)
                        sStatus = (string) category;

                    if (sStatus.Equals("START"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
                        e.Appearance.BackColor2 = Color.LimeGreen;
                    }
                    else if(sStatus.Equals("END"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.Yellow;
                    }
                    else if (sStatus.Equals("WAIT"))
                    {
                        e.Appearance.BackColor = Color.LightGray;
                        e.Appearance.BackColor2 = Color.LightGray;
                    }
                    else if (sStatus.Equals("COMPL"))
                    {
                        e.Appearance.BackColor = Color.DodgerBlue;
                        e.Appearance.BackColor2 = Color.DodgerBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvStatus_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string sStatus = string.Empty;
                var grvView = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                if (e.Column.FieldName == "MonitorStatus")
                {
                    var category = grvView.GetRowCellValue(e.RowHandle, grvView.Columns["MonitorStatus"]);

                    if (category != null)
                        sStatus = (string)category;

                    if (sStatus.Equals("START"))
                    {
                        e.Appearance.BackColor = Color.LimeGreen;
                        e.Appearance.BackColor2 = Color.LimeGreen;
                    }
                    else if (sStatus.Equals("END"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.BackColor2 = Color.Yellow;
                    }
                    else if (sStatus.Equals("WAIT"))
                    {
                        e.Appearance.BackColor = Color.LightGray;
                        e.Appearance.BackColor2 = Color.LightGray;
                    }
                    else if (sStatus.Equals("COMPL"))
                    {
                        e.Appearance.BackColor = Color.DodgerBlue;
                        e.Appearance.BackColor2 = Color.DodgerBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!m_bRun)
                    return;

                lblOperTime.Text = m_sw.Elapsed.ToString(@"hh\:mm\:ss");

                m_dtTo = DateTime.Now;
                dtpkTo.EditValue = m_dtTo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
                    return;

                m_dtFrom = (DateTime) dtpkFrom.EditValue;
                m_dtTo = (DateTime) dtpkTo.EditValue;

                if (m_dtFrom > m_dtTo)
                {
                    XtraMessageBox.Show("기간 설정을 다시 해주세요!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (
                    XtraMessageBox.Show("해당 기간 동안의 사이클을 기반으로 선택된 공정에 대한 수집 최적화 작업을 진행하시겠습니까?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string sProcess = string.Empty;
                foreach (var who in m_lstOptimizerSelection)
                {
                    if (who.IsOptimizing)
                        sProcess += string.Format("{0},", who.Process);
                }

                sProcess = sProcess.Substring(0, sProcess.Length - 1);
                List<string> lstRemoveKey = null;
                CPlcProc cProcess = null;

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    UpdateOptimizerMessage("Optimizer", "\'" + sProcess + "\' 공정의 수집 신호 최적화 작업을 시작합니다.");
                    foreach (COptimizerSelection cSelection in m_lstOptimizerSelection)
                    {
                        if (cSelection.IsOptimizing)
                        {
                            UpdateOptimizationMessage(sProcess, "Optimizer", "\'" + sProcess + "\' 공정의 수집 신호 최적화 작업을 시작합니다.");

                            lstRemoveKey = SetProcessTagOptimization(cSelection.Process);
                            cProcess = CMultiProject.PlcProcS[cSelection.Process];

                            foreach (string sKey in lstRemoveKey)
                                cProcess.CollectCandidateTagS.Remove(sKey);

                            UpdateOptimizationMessage(sProcess, "Optimizer", "\'" + sProcess + "\' 공정의 수집 신호 최적화 작업을 종료합니다.");
                        }
                    }
                    UpdateOptimizerMessage("Optimizer", "\'" + sProcess + "\' 공정의 수집 신호 최적화 작업을 종료합니다.");
                    ShowProcessCollectTagS();
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmCollectOptimizer_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bLoad = false;
        }
    }

    public class COptimizerSelection
    {
        private string m_sProcess = string.Empty;
        private bool m_bOptimizing = true;
        private bool m_bOptimized = false;
        private Dictionary<int, List<string>> m_dicFrequencyRemoveKey = new Dictionary<int, List<string>>();
        private int m_nTargetFrequency = 0;
        private int m_nCurrentFrequency = 0;

        public Dictionary<int, List<string>> FrequencyRemoveKeyList
        {
            get { return m_dicFrequencyRemoveKey;}
            set { m_dicFrequencyRemoveKey = value; }
        }

        public int TargetFrequency
        {
            get { return m_nTargetFrequency; }
            set { m_nTargetFrequency = value; }
        }

        public int CurrentFrequency
        {
            get { return m_nCurrentFrequency; }
            set { m_nCurrentFrequency = value; }
        }

        public string Process
        {
            get { return m_sProcess;}
            set { m_sProcess = value; }
        }

        public bool IsOptimizing
        {
            get { return m_bOptimizing;}
            set { m_bOptimizing = value; }
        }

        public bool IsOptimized
        {
            get { return m_bOptimized; }
            set { m_bOptimized = value; }
        }

    }

    public class COptimizerView
    {
        private string m_sProcess = string.Empty;
        private string m_sRecipe = string.Empty;
        private int m_nCurrent = 0;
        private int m_nTarget = 20;
        private string m_sStatus = string.Empty;
        private int m_nTargetFrequency = 2;
        private int m_nCurrentFrequency = 0;

        public int TargetFrequency
        {
            get { return m_nTargetFrequency;}
            set { m_nTargetFrequency = value; }
        }

        public int CurrentFrequency
        {
            get { return m_nCurrentFrequency;}
            set { m_nCurrentFrequency = value; }
        }

        public string Process
        {
            get { return m_sProcess; }
            set { m_sProcess = value; }
        }

        public string Recipe
        {
            get { return m_sRecipe;}
            set { m_sRecipe = value; }
        }

        public int CurrentCount
        {
            get { return m_nCurrent; }
            set { m_nCurrent = value; }
        }

        public int TargetCount
        {
            get { return m_nTarget ; }
            set { m_nTarget = value; }
        }

        public string MonitorStatus
        {
            get { return m_sStatus; }
            set { m_sStatus = value; }
        }

    }

}