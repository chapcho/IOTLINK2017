using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerPlcSummaryErrorAlarmDoubleClicked();

    public partial class UCPlcSummary : DevExpress.XtraEditors.XtraUserControl
    {
        private CMySqlLogReader m_cReader = null;
        private List<string> m_lstContainProcessName = new List<string>();

        public event UEventHandlerPlcSummaryErrorAlarmDoubleClicked UEventAlarmDoubleClicked = null;
        public event UEventHandlerManualCycleOver UEventManualCycleOver = null;
        public event UEventHandlerManualCycleOverTagKey UEventManualCycleOverTagKey = null;

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateErrorPanelClickCallback(string sProcessKey);
        private int m_iSummarySplitPos = 0;
        private int m_iSummaryErrorSplitPos = 0;

        #region Properties

        public UCPlcSummary()
        {
            InitializeComponent();
        }

        public CMySqlLogReader LogReader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        public List<string> ProcessNameList
        {
            get { return m_lstContainProcessName; }
            set { m_lstContainProcessName = value; }
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            ucSumErrorAlarmView.Run();

            UCFlowPanelS ucFlowS = null;
            for(int i = 0 ; i < tabFlow.TabPages.Count ; i++)
            {
                ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                ucFlowS.ClearActive();
                ucFlowS.IsRunning = true;
            }

            ucFlowS = null;
        }

        public void Stop()
        {
            ucSumErrorAlarmView.Stop();
            ucErrorSummaryPanelS.ClearPanelS();

            UCFlowPanelS ucFlowS = null;
            for (int i = 0; i < tabFlow.TabPages.Count; i++)
            {
                ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                ucFlowS.IsRunning = false;
            }

            ucFlowS = null;
        }

        public void Clear()
        {
            ucCarTypeS.Clear();
            ucCarTypeS.Dispose();

            ucSumErrorAlarmView.ClearControls();
            ucSumErrorAlarmView.Dispose();
            ucErrorSummaryPanelS.ClearPanelS();
            ucErrorSummaryPanelS.Dispose();

            m_lstContainProcessName.Clear();

            ClearFlowChart();
        }

        public void ClearView()
        {
            ucCarTypeS.Clear();
            ucSumErrorAlarmView.ClearControls();
            ucErrorSummaryPanelS.ClearPanelS();
            m_lstContainProcessName.Clear();
            ClearFlowChart();
        }

        public void SetView(string sPlcKey)
        {
            ClearView();

            SetContainProcessName(sPlcKey);

            ucCarTypeS.Clear();
            ucCarTypeS.ShowBoard(sPlcKey);

            ucSumErrorAlarmView.SetView(sPlcKey);
            ShowFlowChart();
        }

        public void SetView()
        {
            ClearView();

            m_lstContainProcessName.AddRange(CMultiProject.PlcProcS.Keys);

            ucCarTypeS.Clear();
            ucCarTypeS.ShowBoard();

            ucSumErrorAlarmView.SetView();
            ShowFlowChart();
        }

        public void UpdateCarTypeS(string sProcess, string sRecipe)
        {
            ucCarTypeS.UpdateCarTypeS(sProcess, sRecipe);
            UpdateFlowChartRecipe(sProcess, sRecipe);
        }

        public void ClearFlowChartActive()
        {
            UCFlowPanelS ucFlowS = null;
            for (int i = 0; i < tabFlow.TabPages.Count; i++)
            {
                if (tabFlow.TabPages[i].Controls.Count == 0) continue;
                ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                ucFlowS.ClearActive();
            }

            ucFlowS = null;

        }

        public void UpdateFlowChart(CTimeLogS cLogS)
        {
            UCFlowPanelS ucFlowS = null;
            for (int i = 0; i < tabFlow.TabPages.Count; i++)
            {
                ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                ucFlowS.UpdateFlowChart(cLogS);
            }
            ucFlowS = null;
        }

        public void UpdateFlowChart(string sProcessKey, CTimeLog cLog)
        {
            XtraTabPage tpPage = tabFlow.TabPages.SingleOrDefault(x => x.Text == sProcessKey);

            if (tpPage == null)
                return;

            UCFlowPanelS ucFlowS = (UCFlowPanelS)tpPage.Controls[0];
            ucFlowS.UpdateFlowChart(cLog);

            ucFlowS = null;

            //UCFlowPanelS ucFlowS = null;
            //for (int i = 0; i < tabFlow.TabPages.Count; i++)
            //{
            //    ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
            //    ucFlowS.UpdateFlowChart(cLogS);
            //}
            //ucFlowS = null;
        }

        public void CreateFlowChart()
        {
            int iCount = 0;
            tabFlow.TabPages.Clear();

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (!m_lstContainProcessName.Contains(who.Key))
                    continue;

                CreateFlowChartTabPage(iCount++, who.Value);
            }
        }

        public void ShowFlowChart()
        {
            int iCount = 0;
            tabFlow.TabPages.Clear();
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (!m_lstContainProcessName.Contains(who.Key))
                    continue;

                ShowFlowChart(iCount++, who.Value);
            }
        }

        public void ClearFlowChart()
        {
            if (tabFlow.TabPages.Count > 0)
            {
                UCFlowPanelS ucFlowPanelS = null;

                foreach (XtraTabPage tpPage in tabFlow.TabPages)
                {
                    if (tpPage.Controls[0].GetType() == typeof (UCFlowPanelS))
                    {
                        ucFlowPanelS = (UCFlowPanelS) tpPage.Controls[0];
                        ucFlowPanelS.Clear();

                        ucFlowPanelS.Dispose();
                    }
                }

                tabFlow.TabPages.Clear();
            }
        }

        public void ErrorPanelResize()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ErrorPanelResize);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                sptSummaryError.Panel1.Height = ucSumErrorAlarmView.Capacity;
                sptSummaryError.Panel1.MinSize = ucSumErrorAlarmView.Capacity;
                sptSummaryError.SplitterPosition = ucSumErrorAlarmView.Capacity;

                sptSummary.SplitterPosition = (int) (Screen.PrimaryScreen.Bounds.Size.Width*0.4);
            }
        }

        public void ClearErrorPanel(string sProcessKey)
        {
            ucErrorSummaryPanelS.ClearErrorListPanelS(sProcessKey);
            ucSumErrorAlarmView.ClearError(sProcessKey);
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            ucSumErrorAlarmView.UpdateError(cErrorInfo);
            ucErrorSummaryPanelS.UpdateErrorListPanelS(cErrorInfo);

        }

        public void UpdateError(CErrorInfo cErrorInfo, int iPriority)
        {
            ucSumErrorAlarmView.UpdateError(cErrorInfo, iPriority);
            ucErrorSummaryPanelS.UpdateErrorListPanelS(cErrorInfo);
        }

        public void UpdateCycleOverError(string sProcessKey)
        {
            ucSumErrorAlarmView.UpdateCycleOverError(sProcessKey);
        }


        #endregion

        #region Private Methods

        private void SetContainProcessName(string sPlcKey)
        {
            m_lstContainProcessName.Clear();

            foreach (var who in CMultiProject.PlcProcS)
            {
                if(who.Value.PlcLogicDataS == null)
                    who.Value.PlcLogicDataS = new CPlcLogicDataS();

                if(who.Value.PlcLogicDataS.ContainsKey(sPlcKey))
                    m_lstContainProcessName.Add(who.Key);
            }
        }

        private void UpdateFlowChartRecipe(string sProcessKey, string sRecipe)
        {
            XtraTabPage tpPage = tabFlow.TabPages.SingleOrDefault(x => x.Text == sProcessKey);

            if (tpPage == null || tpPage.Controls.Count == 0)
                return;

            UCFlowPanelS ucFlowS = (UCFlowPanelS)tpPage.Controls[sProcessKey];
            ucFlowS.UpdateRecipe(sRecipe);
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "")
            {
                XtraMessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                XtraMessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SetTagFinder()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetTagFinder);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    FrmTagFinder frmFinder = new FrmTagFinder();
                    frmFinder.TopMost = true;
                    frmFinder.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucErrorAlarm_DoubleClicked()
        {
            if (UEventAlarmDoubleClicked != null)
                UEventAlarmDoubleClicked();
        }

        private void ucErrorAlarm_Clicked(string sProcessKey)
        {
            if(this.InvokeRequired)
            {
                UpdateErrorPanelClickCallback cUpdate = new UpdateErrorPanelClickCallback(ucErrorAlarm_Clicked);
                this.Invoke(cUpdate, new object[] { sProcessKey });
            }
            else
            {
                for(int i = 0 ; i < tabFlow.TabPages.Count; i++)
                {
                    if(tabFlow.TabPages[i].Text == sProcessKey)
                    {
                        tabFlow.SelectedTabPage = tabFlow.TabPages[i];
                        break;
                    }
                }
            }
        }

        private void FlowChartPrevView()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(FlowChartPrevView);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                if (tabFlow.TabPages.Count == 0)
                    return;

                int iCurrentIndex = tabFlow.SelectedTabPageIndex;

                if (iCurrentIndex == 0)
                    return;

                int iPrevIndex = iCurrentIndex - 1;

                tabFlow.SelectedTabPageIndex = iPrevIndex;
            }
        }
        
        private void FlowChartNextView()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(FlowChartNextView);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                if (tabFlow.TabPages.Count == 0)
                    return;

                int iCurrentIndex = tabFlow.SelectedTabPageIndex;

                if (iCurrentIndex == tabFlow.TabPages.Count - 1)
                    return;

                int iNextIndex = iCurrentIndex + 1;

                tabFlow.SelectedTabPageIndex = iNextIndex;
            }
        }

        private bool CreateFlowChartTabPage(int iNumber, CPlcProc cProcess)
        {
            if (cProcess.KeySymbolS == null || cProcess.KeySymbolS.Count == 0)
            {
                //UpdateSystemMessage("FlowChart", cProcess.Name + "에 KeySymbol이 없어 Flow Chart를 생성할 수 없습니다.");
                return false;
            }

            if (cProcess.RecipeFlowItemS == null) cProcess.RecipeFlowItemS = new Dictionary<string, CFlowChartItemS>();

            cProcess.RecipeFlowItemS.Clear();

            int iCount = 0;
            CFlowChartItemS cItemS = null;
            CFlowChartItem cItem = null;

            if (!CMultiProject.MasterPatternS.ContainsKey(cProcess.Name))
                return false;

            CMasterPattern cPattern = CMultiProject.MasterPatternS[cProcess.Name];
            string sRecipe = string.Empty;

            CFlow cFlow = null;
            foreach (var who in cPattern)
            {
                sRecipe = who.Key;
                iCount = 0;
                cItemS = new CFlowChartItemS();

                if (who.Value.Count == 0)
                    continue;

                if (who.Value.Count == 1)
                    cFlow = who.Value.First();
                else
                {
                    int iFrequency = 0;
                    foreach (CFlow cShape in who.Value)
                    {
                        if (iFrequency < cShape.Frequency)
                        {
                            iFrequency = cShape.Frequency;
                            cFlow = cShape;
                        }
                    }
                }

                if (cFlow == null) continue;

                foreach (var who2 in cFlow.FlowItemS)
                {
                    if (!cProcess.KeySymbolS.ContainsKey(who2.Key))
                        continue;

                    cItem = new CFlowChartItem();
                    cItem.Key = who2.Key;
                    cItem.Address = CMultiProject.TotalTagS[who2.Key].Address;
                    cItem.Description = CMultiProject.TotalTagS[who2.Key].GetDescription();
                    cItem.TargetValue = 1;
                    cItem.FlowStartTime = who2.Value.TimeNodeS.First().Start;
                    cItem.StepKey = GetMasterStepKey(who2.Key);
                    cItem.PlcID = GetLogicDataPlcID(who2.Key);
                    cItemS.Add(iCount++, cItem);
                }
                cProcess.RecipeFlowItemS.Add(sRecipe, cItemS);
            }

            ShowFlowChart(iNumber, cProcess);

            return true;
        }

        private string GetMasterStepKey(string sTagKey)
        {
            string sStepKey = string.Empty;

            if (!CMultiProject.TotalTagS.ContainsKey(sTagKey))
                return string.Empty;

            CTag cTag = CMultiProject.TotalTagS[sTagKey];
            CPlcLogicData cData = CMultiProject.GetPlcLogicData(cTag);

            if (cData == null)
                return string.Empty;

            List<CStep> lstStep = new List<CStep>();
            CStep cStep = null;

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell) && cTag.Address.Contains(".DN"))
            {
                string sKey = cTag.Key.Replace(".DN", string.Empty);

                if (CMultiProject.TotalTagS.ContainsKey(sKey))
                    cTag = CMultiProject.TotalTagS[sKey];
            }

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if (cData.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(cData.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (cData.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = cData.StepS[who.StepKey];

                        if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                            lstStep.Add(cStep);
                    }
                }
            }

            if (lstStep.Count > 0)
            {
                if (lstStep.Count > 0)
                    cStep = lstStep[0];
                //if (lstStep.Count == 1)
                //    cStep = lstStep[0];
                //else if (lstStep.Count > 1)
                //{
                //    FrmStepSelector frmSelector = new FrmStepSelector();
                //    frmSelector.StepList = lstStep;
                //    frmSelector.TopMost = true;
                //    frmSelector.ShowDialog();

                //    if (frmSelector.IsSelectStep)
                //    {
                //        cStep = frmSelector.GetSelectedStep();
                //    }

                //    frmSelector.Dispose();
                //    frmSelector = null;
                //}
            }

            if (cStep != null)
                sStepKey = cStep.Key;

            cTag = null;
            cData = null;
            cStep = null;
            lstStep.Clear();
            lstStep = null;

            return sStepKey;
        }

        private string GetLogicDataPlcID(string sTagKey)
        {
            string sPlcID = string.Empty;

            if (!CMultiProject.TotalTagS.ContainsKey(sTagKey))
                return string.Empty;

            CTag cTag = CMultiProject.TotalTagS[sTagKey];
            CPlcLogicData cData = CMultiProject.GetPlcLogicData(cTag);

            if (cData == null)
                return string.Empty;

            sPlcID = cData.PLCID;

            return sPlcID;
        }

        private bool CheckContainCoilTag(CCoil cCoil, CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cCoil.ContentS)
            {
                if (who.Tag != null && who.Tag.Key == cTag.Key)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private void ShowFlowChart(int iNumber, CPlcProc cProcess)
        {
            if (cProcess.RecipeFlowItemS == null)
                cProcess.RecipeFlowItemS = new Dictionary<string, CFlowChartItemS>();

            if (cProcess.RecipeFlowItemS.Count == 0)
            {
                if (CMultiProject.MasterPatternS.ContainsKey(cProcess.Name) && CMultiProject.MasterPatternS[cProcess.Name].Count != 0)
                    CreateFlowChartTabPage(iNumber, cProcess);
                return;
            }

            XtraTabPage tabPage = new XtraTabPage();
            UCFlowPanelS ucFlowPanelS = new UCFlowPanelS();
            ucFlowPanelS.Dock = DockStyle.Fill;
            ucFlowPanelS.Name = cProcess.Name;
            ucFlowPanelS.PlcProcess = cProcess;
            ucFlowPanelS.ShowFlowChartInit();
            ucFlowPanelS.UEventManualCycleOverClicked += ucFlowPanelS_ManualCycleOverClick;
            ucFlowPanelS.UEventManualCycleOverTagKeyClicked += ucFlowPanelS_ManualCycleOverTagKeyClick;

            tabPage.Name = cProcess.Name;
            tabPage.Text = cProcess.Name;

            tabPage.Appearance.Header.Font = new Font("Tahoma", 15, FontStyle.Bold);
            tabPage.Appearance.HeaderActive.Font = new Font("Tahoma", 15, FontStyle.Bold);
            tabPage.Appearance.HeaderDisabled.Font = new Font("Tahoma", 15, FontStyle.Bold);
            tabPage.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 15, FontStyle.Bold);

            tabFlow.TabPages.Add(tabPage);

            tabPage.Controls.Add(ucFlowPanelS);
            tabPage.Refresh();
        }

        private void LoadPanel()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(LoadPanel);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                ucSumErrorAlarmView.UEventPanelDoubleClick += ucErrorAlarm_DoubleClicked;
                ucSumErrorAlarmView.UEventPanelClick += ucErrorAlarm_Clicked;

                //sptSummary.SplitterPosition = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.4);
                //grpProcessFlowChart.Width = (int)(sptSummary.Panel1.Width * 0.4);
                //grpCarType.Width = (int)(sptSummary.Panel1.Width * 0.3);
            }
        }

        private void CycleOverClick()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(CycleOverClick);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                XtraTabPage tpPage = tabFlow.SelectedTabPage;

                if (tpPage.Controls.Count == 0 || tpPage.Controls[0].GetType() != typeof (UCFlowPanelS))
                    return;

                UCFlowPanelS ucPanelS = (UCFlowPanelS) tpPage.Controls[0];
                ucPanelS.SetProcessCycleOver();

                ucPanelS = null;
            }
        }


        #endregion


        private void ucFlowPanelS_ManualCycleOverClick(string sProcess)
        {
            if (UEventManualCycleOver != null)
                UEventManualCycleOver(sProcess);
        }

        private void ucFlowPanelS_ManualCycleOverTagKeyClick(string sProcess, string sTagKey)
        {
            if (UEventManualCycleOverTagKey != null)
                UEventManualCycleOverTagKey(sProcess, sTagKey);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            FlowChartPrevView();
        }

        private void btnTagFind_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                SetTagFinder();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnErrorClear_Click(object sender, EventArgs e)
        {
            ucSumErrorAlarmView.ClearAllError();
            ucErrorSummaryPanelS.ClearPanelS();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FlowChartNextView();
        }

        private void UCPlcSummary_Load(object sender, EventArgs e)
        {
            LoadPanel();
            m_iSummarySplitPos = sptSummary.SplitterPosition;
            m_iSummaryErrorSplitPos = sptSummaryError.SplitterPosition;
        }

        private void UCPlcSummary_Resize(object sender, EventArgs e)
        {
            ErrorPanelResize();
        }

        private void btnCycleOver_Click(object sender, EventArgs e)
        {
            try
            {
                CycleOverClick();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnProductionStateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //XtraTabPage tpPage = tabFlow.SelectedTabPage;

                //if (tpPage.Controls.Count == 0 || tpPage.Controls[0].GetType() != typeof(UCFlowPanelS))
                //    return;

                //bool bOpen = false;
                //foreach (Form frm in Application.OpenForms)
                //{
                //    if (frm.GetType() == typeof(FrmProductionStateInfo))
                //    {
                //        FrmProductionStateInfo frmProductioninfo = (FrmProductionStateInfo)frm;
                //        if (frmProductioninfo.PlcProcName == tpPage.Text)
                //            bOpen = true;
                //    }
                //}

                //if(!bOpen)
                //{
                //    FrmProductionStateInfo frmProductioninfo = new FrmProductionStateInfo();
                //    frmProductioninfo.PlcProcName = tpPage.Text;
                //    frmProductioninfo.Show();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
        
        private void sptSummary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptSummary.SplitterPosition > 0)
            {
                m_iSummarySplitPos = sptSummary.SplitterPosition;
                sptSummary.SplitterPosition = 0;
            }
            else
                sptSummary.SplitterPosition = m_iSummarySplitPos;
        }

        private void sptSummaryError_MouseClick(object sender, MouseEventArgs e)
        {
            if (sptSummary.SplitterPosition > 0)
            {
                m_iSummaryErrorSplitPos = sptSummaryError.SplitterPosition;
                sptSummaryError.SplitterPosition = 0;
            }
            else
                sptSummaryError.SplitterPosition = m_iSummaryErrorSplitPos;
        }
    }
}