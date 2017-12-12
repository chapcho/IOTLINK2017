using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCFlowChart : DevExpress.XtraEditors.XtraUserControl
    {
        public event UEventHandlerManualCycleOverTagKey UEventManualCycleOverTagKey = null;
        private List<BaseDocument> m_lstDocument = new List<BaseDocument>();

        public UEventHandlerMonitorPanelDoubleClicked UEventPanelDoubleClick;

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateUpdateFlowChartCallback(string sProcessKey, CTimeLog cLog);
        private delegate void UpdateErrorAlarmClickCallback(string sProcessKey);
        private delegate void UpdateRecipeChangeCallback(string sProcessKey, string sRecipe);

        #region Initialize/Dispose

        public UCFlowChart()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(Run);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    ucAlarm.Run();

                    UCFlowPanelS ucPanelS = null;
                    foreach (BaseDocument doc in m_lstDocument)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Control.GetType() != typeof (UCFlowPanelS))
                            continue;

                        ucPanelS = (UCFlowPanelS) doc.Control;
                        ucPanelS.ClearActive();
                        ucPanelS.IsRunning = true;
                    }

                    ucPanelS = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(Stop);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    ucAlarm.Stop();

                    UCFlowPanelS ucPanelS = null;
                    foreach (BaseDocument doc in m_lstDocument)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Control.GetType() != typeof(UCFlowPanelS))
                            continue;

                        ucPanelS = (UCFlowPanelS)doc.Control;
                        ucPanelS.IsRunning = false;
                    }
                    ucPanelS = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearFlowChartActive()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ClearFlowChartActive);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    UCFlowPanelS ucPanelS = null;
                    foreach (BaseDocument doc in m_lstDocument)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Control.GetType() != typeof(UCFlowPanelS))
                            continue;

                        ucPanelS = (UCFlowPanelS)doc.Control;
                        ucPanelS.ClearActive();
                    }
                    ucPanelS = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateFlowChart(string sProcessKey, CTimeLog cLog)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateUpdateFlowChartCallback cUpdate = new UpdateUpdateFlowChartCallback(UpdateFlowChart);
                    this.Invoke(cUpdate, new object[] { sProcessKey, cLog });
                }
                else
                {
                    BaseDocument doc = m_lstDocument.SingleOrDefault(x => x.Caption == sProcessKey);

                    if (doc == null || doc.Control == null || doc.Control.GetType() != typeof(UCFlowPanelS))
                        return;

                    UCFlowPanelS ucFlowS = (UCFlowPanelS) doc.Control;
                    ucFlowS.UpdateFlowChart(cLog);

                    ucFlowS = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearAlarmPanel(string sProcessKey)
        {
            try
            {
                ucAlarm.ClearError(sProcessKey);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            ucAlarm.UpdateProcessStatusError(cErrorInfo.GroupKey);
        }

        public void UpdateFlowChartRecipe(string sProcess, string sRecipe)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateRecipeChangeCallback cUpdate = new UpdateRecipeChangeCallback(UpdateFlowChartRecipe);
                    this.Invoke(cUpdate, new object[] { sProcess, sRecipe });
                }
                else
                {
                    if (tabView.Documents == null)
                        return;

                    foreach (BaseDocument doc in tabView.Documents)
                    {
                        if (doc.Caption == sProcess && doc.Control != null && doc.Control.GetType() == typeof(UCFlowPanelS))
                        {
                            UCFlowPanelS ucPanelS = (UCFlowPanelS)doc.Control;

                            if (ucPanelS != null)
                                ucPanelS.UpdateRecipe(sRecipe);

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(string sProcessKey)
        {
            try
            {
                ucAlarm.UpdateProcessStatusError(sProcessKey);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == string.Empty)
                    return;

                Clear();

                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                    return;

                ucAlarm.SetFlowChartProcessSummaryView(CMultiProject.PlcProcS.Where(x => x.Value.IsErrorMonitoring == false).Select(x => x.Key).ToList());
                ShowFlowChart();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void CreateFlowChart()
        {
            try
            {
                int iCount = 0;
                ClearFlowChartDocuments();

                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    CreateFlowChartItemS(iCount++, cProcess);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ShowFlowChart()
        {
            try
            {
                int iCount = 0;
                ClearFlowChartDocuments();

                foreach(CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    ShowFlowChart(iCount++, cProcess);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                ucAlarm.ClearControls();
                ClearFlowChartDocuments();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearFlowChartDocuments()
        {
            try
            {
                UCFlowPanelS ucPanelS = null;
                BaseDocument doc = null;
                while (tabView.Documents.Count > 0)
                {
                    doc = tabView.Documents.First();
                    if (doc.Control != null)
                    {
                        if (doc.Control.GetType() == typeof(UCFlowPanelS))
                        {
                            ucPanelS = (UCFlowPanelS)doc.Control;
                            ucPanelS.Clear();
                            ucPanelS.Dispose();
                        }
                    }

                    doc.Dispose();
                    tabView.Documents.Remove(doc);
                }

                while (m_lstDocument.Count > 0)
                {
                    doc = m_lstDocument.First();
                    if (doc.Control != null)
                    {
                        if (doc.Control.GetType() == typeof(UCFlowPanelS))
                        {
                            ucPanelS = (UCFlowPanelS)doc.Control;
                            ucPanelS.Clear();
                            ucPanelS.Dispose();
                        }
                    }
                    doc.Dispose();
                    m_lstDocument.Remove(doc);
                }

                m_lstDocument.Clear();
                ucPanelS = null;
                tabView.Documents.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }


        #endregion


        #region Private Methods

        //private void SetNavigationBar()
        //{
        //    try
        //    {
        //        if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
        //            return;

        //        NavBarItem navItem = null;
        //        foreach (string sName in CMultiProject.PlcProcS.Keys)
        //        {
        //            if (navBarProcess.ItemLinks.Where(x => x.ItemName == sName).Count() > 0)
        //                continue;

        //            navItem = new NavBarItem(sName);
        //            navItem.Name = sName;
        //            navItem.Appearance.Font = new Font("Tahoma", 15, FontStyle.Bold);
        //            navItem.AppearanceDisabled.Font = new Font("Tahoma", 15, FontStyle.Bold);
        //            navItem.AppearanceHotTracked.Font = new Font("Tahoma", 15, FontStyle.Bold);
        //            navItem.AppearancePressed.Font = new Font("Tahoma", 15, FontStyle.Bold);
        //            navItem.SmallImageIndex = 0;
        //            navBarProcess.ItemLinks.Add(navItem);
        //        }

        //        navBar.Update();
        //    }
        //    catch (Exception ex)
        //    {
        //        CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
        //        ex.Data.Clear();
        //    }
        //}

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

        private void CreateFlowChartItemS(int iNumber, CPlcProc cProcess)
        {
            try
            {
                if (cProcess.KeySymbolS == null || cProcess.KeySymbolS.Count == 0)
                    return;

                if (cProcess.RecipeFlowItemS == null)
                    cProcess.RecipeFlowItemS = new Dictionary<string, CFlowChartItemS>();
                cProcess.RecipeFlowItemS.Clear();

                int iCount = 0;
                CFlowChartItemS cItemS = null;
                CFlowChartItem cItem = null;
                if (!CMultiProject.MasterPatternS.ContainsKey(cProcess.Name))
                    return;

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
                        cItem.RecipeElement = who2.Value.RecipeElement;
                        cItem.ConditionElement = who2.Value.ConditionElement;
                        cItemS.Add(iCount++, cItem);
                    }
                    cProcess.RecipeFlowItemS.Add(sRecipe, cItemS);
                }
                ShowFlowChart(iNumber, cProcess);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ShowFlowChart(int iNumber, CPlcProc cProcess)
        {
            try
            {
                if(cProcess.RecipeFlowItemS == null)
                    cProcess.RecipeFlowItemS = new Dictionary<string, CFlowChartItemS>();

                if (cProcess.RecipeFlowItemS.Count == 0)
                {
                    if (CMultiProject.MasterPatternS.ContainsKey(cProcess.Name) && CMultiProject.MasterPatternS[cProcess.Name].Count != 0)
                        CreateFlowChartItemS(iNumber, cProcess);
                    return;
                }

                docManager.BeginUpdate();
                {
                    UCFlowPanelS ucFlowPanelS = new UCFlowPanelS();
                    ucFlowPanelS.Dock = DockStyle.Fill;
                    ucFlowPanelS.Name = cProcess.Name;
                    ucFlowPanelS.PlcProcess = cProcess;
                    ucFlowPanelS.ShowFlowChartInit();
                    ucFlowPanelS.UEventManualCycleOverTagKeyClicked += ucFlowPanelS_ManualCycleOverTagKeyClick;

                    if (iNumber == 0 && tabView.DocumentGroups.Count != 3)
                    {
                        int iCount = 3 - tabView.DocumentGroups.Count;
                        if (iCount > 0)
                        {
                            DocumentGroup docGroup = null;
                            for (int i = 0; i < iCount; i++)
                            {
                                docGroup = new DocumentGroup();
                                tabView.DocumentGroups.Add(docGroup);
                            }
                        }
                    }

                    BaseDocument doc = docManager.View.AddDocument(ucFlowPanelS);
                    doc.Caption = cProcess.Name;
                    doc.Properties.AllowClose = DefaultBoolean.False;
                    Document docTab = doc as Document;

                    if (docTab != null)
                    {
                        docTab.Properties.AllowClose = DefaultBoolean.False;
                        docTab.Properties.ShowPinButton = DefaultBoolean.False;
                        docTab.Appearance.Header.Font = new Font("Tahoma", 15, FontStyle.Bold);
                        docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 15, FontStyle.Bold);
                        docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 15, FontStyle.Bold);
                        docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 15, FontStyle.Bold);
                        docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 15, FontStyle.Bold);
                        docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                        docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                    }

                    m_lstDocument.Add(doc);

                    if (iNumber%3 == 1)
                        tabView.Controller.MoveToDocumentGroup(docTab, true);
                    else if (iNumber%3 == 2)
                    {
                        tabView.Controller.MoveToDocumentGroup(docTab, true);
                        tabView.Controller.MoveToDocumentGroup(docTab, true);
                    }
                }
                docManager.EndUpdate();
                docManager.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucFlowPanelS_ManualCycleOverTagKeyClick(string sProcess, string sTagKey)
        {
            try
            {
                if (UEventManualCycleOverTagKey != null)
                    UEventManualCycleOverTagKey(sProcess, sTagKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucErrorAlarm_PanelClicked(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorAlarmClickCallback cUpdate = new UpdateErrorAlarmClickCallback(ucErrorAlarm_PanelClicked);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    if (tabView.Documents == null)
                        return;

                    foreach (BaseDocument doc in tabView.Documents)
                    {
                        if (doc.Caption == sProcessKey)
                        {
                            tabView.Controller.Activate(doc);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucErrorAlarm_PanelDoubleClicked()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ucErrorAlarm_PanelDoubleClicked);
                    this.Invoke(cUpdate, new object[] {  });
                }
                else
                {
                    if (UEventPanelDoubleClick != null)
                        UEventPanelDoubleClick();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void UCFlowChart_Load(object sender, EventArgs e)
        {
            try
            {
                ucAlarm.UEventPanelClick += ucErrorAlarm_PanelClicked;
                ucAlarm.UEventPanelDoubleClick += ucErrorAlarm_PanelDoubleClicked;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCFlowChart", ex.Message);
                ex.Data.Clear();
            }
        }



    }
}
