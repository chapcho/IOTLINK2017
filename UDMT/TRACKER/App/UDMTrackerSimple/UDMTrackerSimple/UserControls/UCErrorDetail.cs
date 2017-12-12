using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;
using UDM.Common;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Ladder;
using System.Text.RegularExpressions;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using UDM.Flow;

namespace UDMTrackerSimple
{
    public delegate void UpdateScrollMoveCallback(object sender, MouseEventArgs e);

    public partial class UCErrorDetail : DevExpress.XtraEditors.XtraUserControl
    {
        private delegate void UpdateDoubleClickCallback(object sender, CErrorInfo cInfo);
        private delegate void UpdateFilterCallback(bool bAbnormal, bool bUnknown);


        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;

        public UCErrorDetail()
        {
            InitializeComponent();
        }

        public bool PanelFilter
        {
            get { return pnlFilter.Visible; }
            set { pnlFilter.Visible = value; }
        }

        public void UpdateView(CErrorInfoS cInfoS)
        {
            ucGrid.UpdateView(cInfoS);
        }

        public void ClearGrid()
        {
            ucGrid.ClearGrid();
            tabView.TabPages.Clear();
            ucFlowResultViewer.Clear();
        }

        public void ClearAnalysis()
        {
            //ucErrorAnalysis.Clear();
        }

        public void InitialDetailView()
        {
            tabMain.SelectedTabPage = tpErrorList;
        }

        private void SetFilterView(bool bAbnormal, bool bUnknown)
        {
            if (this.InvokeRequired)
            {
                UpdateFilterCallback cUpdate = new UpdateFilterCallback(SetFilterView);
                this.Invoke(cUpdate, new object[] {bAbnormal, bUnknown});
            }
            else
            {
                ucGrid.SetFilterView(bAbnormal, bUnknown);
            }
        }


        private void ucErrorCauseGrid_UEventDoubleClick(object sender, CTag cErrorCauseTag, CErrorInfo cInfo)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                //ucErrorAnalysis.ShowErrorCauseDiagram(cErrorCauseTag, cInfo);
            }
            SplashScreenManager.CloseDefaultWaitForm();
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

        private CStep GetLinkStep(CTag cTag)
        {
            if (cTag == null) return null;
            CStep cStep = null;

            List<string> lstLinkTagKey = CMultiProject.GetLinkTagKeyList(cTag);

            if (lstLinkTagKey == null)
                return null;

            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cData = null;
            CTag cLinkTag = null;

            foreach (string sKey in lstLinkTagKey)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                    continue;

                cLinkTag = CMultiProject.TotalTagS[sKey];

                if (!CMultiProject.PlcLogicDataS.ContainsKey(cLinkTag.Creator))
                    continue;

                cData = CMultiProject.PlcLogicDataS[cLinkTag.Creator];

                foreach (var who in cLinkTag.StepRoleS)
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

                            if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cLinkTag))
                                lstStep.Add(cStep);
                        }
                    }
                }

                cStep = null;
                cLinkTag = null;
                cData = null;
            }

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.TopMost = true;
                    frmSelector.ShowDialog();

                    if (frmSelector.IsSelectStep)
                        cStep = frmSelector.GetSelectedStep();

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }

            lstStep.Clear();
            lstStep = null;

            return cStep;
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();

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
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(cLogic.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = cLogic.StepS[who.StepKey];

                        if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                            lstStep.Add(cStep);
                    }
                }
            }

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.ShowDialog();

                    if (frmSelector.IsSelectStep)
                    {
                        cStep = frmSelector.GetSelectedStep();
                    }

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            else
                cStep = GetLinkStep(cTag);

            return cStep;
        }

        private void SetLadderStep(CStep cStep, CErrorInfo cErrorInfo, int iStepLevel, bool bView, int iTabIndex)
        {
            if (cStep != null)
            {
                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
                    return;

                XtraTabPage tpPage = tabView.TabPages[iTabIndex];
                Panel pnlView = tpPage.Controls[0] as Panel;

                if (pnlView == null)
                    return;

                CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                UCLadderStep ucStep = new UCLadderStep(cStep, cErrorInfo.ErrorLogS, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.AutoScroll = false;
                ucStep.ScaleDefault = 1f; // 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel;
                ucStep.IsViewStep = bView;
                ucStep.StepName =
                    string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cStep.Channel, cStep.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                ucStep.UEventRightSelectedCellData += ucStep_UEventSelectedRightCellData;
                ucStep.MouseUp += ucStep_MouseUp;
                ucStep.MouseDown += ucStep_MouseDown;
                ucStep.MouseMove += ucStep_MouseMove;
                //this.Size = ucStep.Size;
                pnlView.Controls.Add(ucStep);
                ucStep.TextPanel.Focus();
            }
        }

        private void ShowPatternChart(CErrorInfo cErrorInfo)
        {
            try
            {
                if (!CMultiProject.PlcProcS.ContainsKey(cErrorInfo.GroupKey))
                    return;

                CPlcProc cProcess = CMultiProject.PlcProcS[cErrorInfo.GroupKey];

                CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(cProcess.Name, cProcess.KeySymbolS,
                    cErrorInfo.CycleStart,
                    cErrorInfo.ErrorTime, cErrorInfo.ErrorLogS, true);
                if (cItemS == null || cItemS.Count == 0)
                    return;

                CFlowCompareResultS cResultS = CMultiProject.MasterPatternS.Compare(cErrorInfo.GroupKey,
                    cErrorInfo.CurrentRecipe, cItemS, true);
                if (cResultS == null)
                {
                    cResultS = new CFlowCompareResultS();
                    cResultS.FlowItemS = cItemS;
                }

                cResultS.Key = cProcess.Name;
                if (cResultS.MasterFlow != null)
                    cResultS.MasterFlow.Normalize(cErrorInfo.CycleStart);

                ucFlowResultViewer.ShowChart(cResultS);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void SetTabView(int iCount)
        {
            XtraTabPage tpPage = null;
            Panel pnlView = null;
            for (int i = 0; i < iCount; i++)
            {
                tpPage = new XtraTabPage();
                tpPage.Text = "Error Path " + (i + 1).ToString();

                pnlView = new Panel();
                pnlView.Dock = DockStyle.Fill;
                pnlView.AutoScroll = true;
                pnlView.Scroll += pnlView_Scroll;
                pnlView.MouseWheel += pnlView_MouseWheel;
                tpPage.Controls.Add(pnlView);

                tabView.TabPages.Add(tpPage);
            }
        }

        private void pnlView_MouseWheel(object sender, MouseEventArgs e)
        {
            Panel pnl = (Panel)sender;

            if (pnl.VerticalScroll.Visible)
                pnlView_Scroll(pnl, null);
        }

        private void pnlView_Scroll(object sender, ScrollEventArgs e)
        {
            Panel pnl = (Panel)sender;

            int iSumHeight = 0;
            Control conTopLadder = pnl.GetChildAtPoint(new Point(0,0));
            UCLadderStep ucTopLadder = (UCLadderStep)conTopLadder;

            for (int i = 0; i < pnl.Controls.Count; i++)
            {
                UCLadderStep ucLadder = (UCLadderStep)pnl.Controls[i];

                if (ucLadder == ucTopLadder)
                {
                    ucLadder.TopPanel.SendToBack();
                    ucLadder.TextPanel.SendToBack();
                    ucLadder.TextPanel.Dock = DockStyle.None;
                    ucLadder.TextPanel.BringToFront();
                    ucLadder.TextPanel.Width = ucLadder.Width;
                    ucLadder.TopPanel.Height = ucLadder.TextPanel.Height;
                    ucLadder.TextPanel.Location = new Point(ucLadder.TextPanel.Location.X, pnl.VerticalScroll.Value);

                    if(i != pnl.Controls.Count -1)
                    {
                        for(int j = pnl.Controls.Count -1; j > i; j--)
                            iSumHeight += pnl.Controls[j].Height;

                        ucLadder.TextPanel.Location = new Point(ucLadder.TextPanel.Location.X, pnl.VerticalScroll.Value - iSumHeight);
                    }
                }
                else
                {
                    ucLadder.TopPanel.Height = 5;
                    ucLadder.TopPanel.BringToFront();
                    ucLadder.TextPanel.SendToBack();
                    ucLadder.TextPanel.Dock = DockStyle.Top;
                    ucLadder.TextPanel.Width = ucLadder.Width;
                }
            }
        } 

        private void ucErrorGrid_UEventDoubleClick(object sender, CErrorInfo cErrorInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateDoubleClickCallback cUpdate = new UpdateDoubleClickCallback(ucErrorGrid_UEventDoubleClick);
                    this.Invoke(cUpdate, new object[] {sender, cErrorInfo});
                }
                else
                {
                    if (CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                    {
                        if (cErrorInfo.ErrorLogS == null || cErrorInfo.ErrorLogS.Count == 0)
                            cErrorInfo.ErrorLogS = CMultiProject.LogReader.GetErrorLogS(cErrorInfo.ErrorID);

                        if (cErrorInfo.ErrorLogS == null)
                            cErrorInfo.ErrorLogS = new CTimeLogS();

                        tabView.TabPages.Clear();
                        ucFlowResultViewer.Clear();

                        SetTabView(1);

                        CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                        CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];

                        CStep cStep = null;

                        if (cErrorInfo.AbnormalSymbolKey != string.Empty)
                        {
                            CPlcProc cProcess = CMultiProject.PlcProcS[cErrorInfo.GroupKey];

                            if (cProcess.TotalAbnormalSymbolKey == string.Empty)
                                return;

                            cStep = GetMasterStep(CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey], cLogic);

                            CAbnormalSymbol cSymbol =
                                cProcess.AbnormalSymbolS.GetAbnormalSymbol(cErrorInfo.AbnormalSymbolKey);
                            Dictionary<int, string> dicTraceSymbolKey = null;

                            //dicTraceSymbolKey = cSymbol.SubCoil.GetTraceSymbolKey(cErrorInfo.ErrorLogS, cErrorInfo.Value == 0 ? true : false);

                            CErrorPathS cErrorPathS = cSymbol.SubCoil.GetTraceErrorPath(cErrorInfo.ErrorLogS);

                            if (cErrorPathS == null || cErrorPathS.Count == 0)
                                SetLadderStep(cStep, cErrorInfo, 0, false, 0);
                            else
                            {
                                tabView.TabPages.Clear();
                                SetTabView(cErrorPathS.Count);

                                for (int i = 0; i < cErrorPathS.Count; i++)
                                    SetLadderStep(cStep, cErrorInfo, 0, false, i);

                                CErrorPath cPath = null;
                                for (int i = 0; i < cErrorPathS.Count; i++)
                                {
                                    cPath = cErrorPathS[i];

                                    for (int j = 0; j < cPath.Count; j++)
                                    {
                                        if (!cPath.ContainsKey(j))
                                            continue;

                                        cStep = cLogic.StepS[cPath[j]];
                                        if (j != cPath.Count - 1)
                                            SetLadderStep(cStep, cErrorInfo, j + 1, false, i);
                                        else
                                            SetLadderStep(cStep, cErrorInfo, j + 1, true, i);
                                    }
                                }
                            }
                        }
                        else if (cErrorInfo.CoilKey != string.Empty)
                        {
                            int iLevel = 0;
                            if (CMultiProject.PlcProcS.ContainsKey(cErrorInfo.GroupKey))
                            {
                                CPlcProc cProcess = CMultiProject.PlcProcS[cErrorInfo.GroupKey];

                                if (cProcess.TotalAbnormalSymbolKey != string.Empty &&
                                    cProcess.TotalAbnormalSymbolKey != cErrorInfo.CoilKey)
                                {
                                    cStep = GetMasterStep(CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey],
                                        cLogic);
                                    SetLadderStep(cStep, cErrorInfo, iLevel++, false, 0);
                                }
                            }

                            cStep = GetMasterStep(CMultiProject.TotalTagS[cErrorInfo.CoilKey], cLogic);
                            SetLadderStep(cStep, cErrorInfo, iLevel, true, 0);
                        }
                        else
                        {
                            cStep = GetMasterStep(cTag, cLogic);
                            SetLadderStep(cStep, cErrorInfo, 0, true, 0);
                        }

                        //if (cErrorInfo.ErrorType.Equals("CycleOver"))
                        //{
                        //    ShowPatternChart(cErrorInfo);
                        //    tabMain.SelectedTabPageIndex = 2;
                        //}
                        //else
                            tabMain.SelectedTabPageIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            if (cTag == null) return;
            CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];
            CStep cStep = GetMasterStep(cTag, cLogic);

            XtraTabPage tpPage = tabView.SelectedTabPage;
            Panel pnlView = tpPage.Controls[0] as Panel;

            if (pnlView == null)
                return;

            if (cStep != null)
            {
                List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                for (int i = 0; i < pnlView.Controls.Count; i++)
                {
                    UCLadderStep ucView = (UCLadderStep)pnlView.Controls[i];
                    if (ucView.StepLevel > iStepLevel)
                        lstRemove.Add(ucView);
                    else
                    {
                        if (ucView.Step.Key == cStep.Key)
                        {
                            MessageBox.Show("같은 Step이 열려 있습니다.");
                            return;
                        }
                    }
                }
                for (int i = 0; i < lstRemove.Count; i++)
                    pnlView.Controls.Remove(lstRemove[i]);

                UCLadderStep ucStep = new UCLadderStep(cStep, cLogS, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.ScaleDefault = 1f;// 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel + 1;
                ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )", cStep.Program, cStep.StepIndex, cStep.Address, cStep.Channel, cStep.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                ucStep.UEventRightSelectedCellData += ucStep_UEventSelectedRightCellData;
                ucStep.MouseUp += ucStep_MouseUp;
                ucStep.MouseDown += ucStep_MouseDown;
                ucStep.MouseMove += ucStep_MouseMove;
                pnlView.Controls.Add(ucStep);
                ucStep.TextPanel.Focus();
            }
        }

        private void ucStep_UEventSelectedRightCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            try
            {
                if (cTag == null) return;
                CStep cStep = GetLinkStep(cTag);

                XtraTabPage tpPage = tabView.SelectedTabPage;
                Panel pnlView = tpPage.Controls[0] as Panel;

                if (pnlView == null)
                    return;

                if (cStep != null)
                {
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlView.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep)pnlView.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                            lstRemove.Add(ucView);
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.");
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                        pnlView.Controls.Remove(lstRemove[i]);

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.ScaleDefault = 1f; // 0.6f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel + 1;

                    ucStep.StepName = string.Format(
                        "CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cStep.Address, cStep.Channel, cStep.Description);
                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                    ucStep.UEventRightSelectedCellData += ucStep_UEventSelectedRightCellData;
                    ucStep.MouseUp += ucStep_MouseUp;
                    ucStep.MouseDown += ucStep_MouseDown;
                    ucStep.MouseMove += ucStep_MouseMove;
                    pnlView.Controls.Add(ucStep);
                    ucStep.TextPanel.Focus();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }



        private void UCErrorDetail_Load(object sender, EventArgs e)
        {
            ucGrid.UErrorCauseTagDoubleClickEvent += ucErrorCauseGrid_UEventDoubleClick;
            ucGrid.UErrorLogGridDoubleClickEvent += ucErrorGrid_UEventDoubleClick;
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemUp();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemDown();
        }

        private void btnPatternClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.Clear();
        }

        private void chkAbnormalSymbol_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAbnormalSymbol.Checked)
                chkUnknownStop.Checked = false;

            SetFilterView(chkAbnormalSymbol.Checked, chkUnknownStop.Checked);
        }

        private void chkUnknownStop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnknownStop.Checked)
                chkAbnormalSymbol.Checked = false;

            SetFilterView(chkAbnormalSymbol.Checked, chkUnknownStop.Checked);
        }

        private void btnExportRawData_Click(object sender, EventArgs e)
        {
            try
            {
                ucGrid.ExportExcelRawData();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkCellMerge_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCellMerge.Checked)
                    ucGrid.IsAllowCellMerge = true;
                else
                    ucGrid.IsAllowCellMerge = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void ucStep_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucStep_MouseMove);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    if (!m_bScrollMove)
                        return;

                    XtraTabPage tpPage = tabView.SelectedTabPage;

                    if (tpPage == null)
                        return;

                    Panel pnlLadder = (Panel)tpPage.Controls[0];
                    Point point = pnlLadder.PointToClient(Cursor.Position);

                    int iDelta = m_iScrollPosition - point.Y;
                    int iPosition = pnlLadder.VerticalScroll.Value + iDelta;

                    if (iPosition > pnlLadder.VerticalScroll.Maximum)
                        iPosition = pnlLadder.VerticalScroll.Maximum;
                    else if (iPosition < pnlLadder.VerticalScroll.Minimum)
                        iPosition = pnlLadder.VerticalScroll.Minimum;

                    pnlLadder.VerticalScroll.Value = iPosition;
                    m_iScrollPosition = point.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucStep_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucStep_MouseDown);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    XtraTabPage tpPage = tabView.SelectedTabPage;

                    if (tpPage == null)
                        return;

                    Panel pnlLadder = (Panel)tpPage.Controls[0];
                    Point point = pnlLadder.PointToClient(Cursor.Position);

                    m_bScrollMove = true;
                    m_iScrollPosition = point.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucStep_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucStep_MouseUp);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    UCLadderStep ucStep = (UCLadderStep)sender;

                    m_bScrollMove = false;
                    XtraTabPage tpPage = tabView.SelectedTabPage;

                    if (tpPage == null)
                        return;

                    Panel pnlLadder = (Panel)tpPage.Controls[0];
                    Point point = pnlLadder.PointToClient(Cursor.Position);

                    int iDelta = m_iScrollPosition - point.Y;
                    int iPosition = pnlLadder.VerticalScroll.Value + iDelta;

                    if (iPosition > pnlLadder.VerticalScroll.Maximum)
                        iPosition = pnlLadder.VerticalScroll.Maximum;
                    else if (iPosition < pnlLadder.VerticalScroll.Minimum)
                        iPosition = pnlLadder.VerticalScroll.Minimum;

                    pnlLadder.VerticalScroll.Value = iPosition;
                    pnlView_MouseWheel(pnlLadder, e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
