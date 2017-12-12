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

namespace UDMLadderTracker
{
    public partial class UCErrorDetail : DevExpress.XtraEditors.XtraUserControl
    {
        private delegate void UpdateDoubleClickCallback(object sender, CErrorInfo cInfo);

        public UCErrorDetail()
        {
            InitializeComponent();
        }

        public void UpdateView(CErrorInfoS cInfoS)
        {
            ucGrid.UpdateView(cInfoS);
        }

        public void ClearGrid()
        {
            ucGrid.ClearGrid();
        }

        public void ClearAnalysis()
        {
            //ucErrorAnalysis.Clear();
        }

        private void ucErrorCauseGrid_UEventDoubleClick(object sender, CTag cErrorCauseTag, CErrorInfo cInfo)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                //ucErrorAnalysis.ShowErrorCauseDiagram(cErrorCauseTag, cInfo);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = cLogic.StepS.Where(b => b.Value.Address == cTag.Address).Select(b => b.Value).ToList();

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.ShowDialog();

                    cStep = frmSelector.GetSelectedStep();

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            return cStep;
        }

        private void SetLadderStep(CStep cStep, CErrorInfo cErrorInfo, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
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
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlView.Controls.Add(ucStep);
                this.Size = ucStep.Size;
            }
        }

        private void ucErrorGrid_UEventDoubleClick(object sender, CErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateDoubleClickCallback cUpdate = new UpdateDoubleClickCallback(ucErrorGrid_UEventDoubleClick);
                this.Invoke(cUpdate, new object[] { sender, cErrorInfo });
            }
            else
            {
                if (CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                {
                    if (cErrorInfo.ErrorLogS == null || cErrorInfo.ErrorLogS.Count == 0)
                        cErrorInfo.ErrorLogS = CMultiProject.LogReader.GetErrorLogS(cErrorInfo.ErrorID);

                    if (cErrorInfo.ErrorLogS == null)
                        cErrorInfo.ErrorLogS = new CTimeLogS();

                    pnlView.Controls.Clear();
                    CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                    CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];

                    CStep cStep = null;

                    if (cErrorInfo.AbnormalSymbolKey != string.Empty)
                    {
                        CAbnormalSymbol cSymbol = CMultiProject.PlcProcS[cErrorInfo.GroupKey].AbnormalSymbolS.GetAbnormalSymbol(cErrorInfo.AbnormalSymbolKey);
                        Dictionary<int, string> dicTraceSymbolKey = null;

                        if (cErrorInfo.CoilKey != string.Empty)
                            dicTraceSymbolKey = cSymbol.SubCoil.GetTraceSymbolKey(cErrorInfo.CoilKey);
                        else
                            dicTraceSymbolKey = cSymbol.SubCoil.GetTraceSymbolKey(cErrorInfo.SymbolKey);

                        for (int i = 0; i < dicTraceSymbolKey.Count; i++)
                        {
                            cStep = cLogic.StepS[dicTraceSymbolKey[i]];
                            if(i != dicTraceSymbolKey.Count - 1)
                                SetLadderStep(cStep, cErrorInfo, i, false);
                            else
                                SetLadderStep(cStep, cErrorInfo, i, true);
                        }
                    }
                    else if (cErrorInfo.CoilKey != string.Empty)
                    {
                        cStep = GetMasterStep(CMultiProject.TotalTagS[cErrorInfo.CoilKey], cLogic);
                        SetLadderStep(cStep, cErrorInfo, 0, true);
                    }
                    else
                    {
                        cStep = GetMasterStep(cTag, cLogic);
                        SetLadderStep(cStep, cErrorInfo, 0, true);
                        
                    }
                    tabMain.SelectedTabPageIndex = 1;
                }
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            if (cTag == null) return;
            CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];
            CStep cStep = GetMasterStep(cTag, cLogic);

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
                ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )", cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlView.Controls.Add(ucStep);
            }
        }

        private void UCErrorDetail_Load(object sender, EventArgs e)
        {
            ucGrid.UErrorCauseTagDoubleClickEvent += ucErrorCauseGrid_UEventDoubleClick;
            ucGrid.UErrorLogGridDoubleClickEvent += ucErrorGrid_UEventDoubleClick;
        }
    }
}
