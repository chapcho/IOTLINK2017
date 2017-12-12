using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCPlcSummaryS : DevExpress.XtraEditors.XtraUserControl
    {
        private bool m_bregisterDoc = false;
        private bool m_bDocking = false;
        private List<BaseDocument> m_lstDocument = new List<BaseDocument>();

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateCarTypeSCallback(string sProcess, string sRecipe);
        private delegate void UpdateFlowChartCallback(CTimeLogS cLogS);
        private delegate void UpdateFlowChartCallback2(string sProcessKey, CTimeLog cLog);
        private delegate void UpdateErrorCallback(CErrorInfo cInfo);
        private delegate void UpdateErrorCallback2(CErrorInfo cInfo, int iPriority);
        private delegate void UpdateCycleOverCallback(string sProcess);
        private delegate void UpdateReturnDocumentHostCallback(BaseDocument doc);
        private delegate void UpdateReturnDocumentToDocumentHostCallback(BaseDocumentCollection docCollection);

        public event UEventHandlerPlcSummaryErrorAlarmDoubleClicked UEventAlarmDoubleClicked = null;
        public event UEventHandlerManualCycleOver UEventManualCycleOver = null;
        public event UEventHandlerManualCycleOverTagKey UEventManualCycleOverTagKey = null;

        public UEventHandlerReturnDocumentHostToDocument UEventReturnDocumentHost = null;

        public UCPlcSummaryS()
        {
            InitializeComponent();
        }

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
                    UCPlcSummary ucPlcSummary = null;
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof (UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView) doc.Control;
                                ucError.Run();
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.Run();
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;
                                ucPlcSummary.Run();
                            }
                        }
                    }

                    ucPlcSummary = null;
                    ucError2 = null;
                    ucError = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
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
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            ucError = (UCAllErrorAlarmView) doc.Control;
                            ucError.Stop();
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.Stop();
                            }
                        }
                        else
                        {
                            ucPlcSummary = (UCPlcSummary) doc.Control;
                            ucPlcSummary.Stop();
                        }
                    }

                    ucPlcSummary = null;
                    ucError2 = null;
                    ucError = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                if (!CMultiProject.IsProjectBaseView)
                    SetPlcBaseView();
                else
                    SetProjectBaseView();

            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                UCPlcSummary ucPlcSummary = null;
                UCAllErrorAlarmView ucError = null;
                UCAllErrorAlarmView2 ucError2 = null;

                BaseDocument doc = null;
                while (tabView.Documents.Count > 0)
                {
                    doc = tabView.Documents.First();

                    if (doc.Control != null)
                    {
                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof (UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView) doc.Control;
                                ucError.Clear();
                                ucError.UEventAllPanelDoubleClick -= ucPlcSummary_AllErrorAlarmDoubleClicked;
                                ucError.Dispose();
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.Clear();
                                ucError2.UEventAllPanelDoubleClick -= ucPlcSummary_ProjectBaseAllErrorAlarmDoubleClicked;
                                ucError2.Dispose();
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;
                                ucPlcSummary.Clear();
                                ucPlcSummary.UEventAlarmDoubleClicked -= ucPlcSummary_ErrorAlarmDoubleClicked;
                                ucPlcSummary.UEventManualCycleOver -= ucPlcSummary_ManualCycleOverClicked;
                                ucPlcSummary.UEventManualCycleOverTagKey -= ucPlcSummary_ManualCycleOverTagKeyClicked;
                                ucPlcSummary.Dispose();
                            }
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
                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof (UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView) doc.Control;
                                ucError.Clear();
                                ucError.UEventAllPanelDoubleClick -= ucPlcSummary_AllErrorAlarmDoubleClicked;
                                ucError.Dispose();
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.Clear();
                                ucError2.UEventAllPanelDoubleClick -= ucPlcSummary_ProjectBaseAllErrorAlarmDoubleClicked;
                                ucError2.Dispose();
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;
                                ucPlcSummary.Clear();
                                ucPlcSummary.UEventAlarmDoubleClicked -= ucPlcSummary_ErrorAlarmDoubleClicked;
                                ucPlcSummary.UEventManualCycleOver -= ucPlcSummary_ManualCycleOverClicked;
                                ucPlcSummary.UEventManualCycleOverTagKey -= ucPlcSummary_ManualCycleOverTagKeyClicked;
                                ucPlcSummary.Dispose();
                            }
                        }
                    }

                    doc.Dispose();
                    m_lstDocument.Remove(doc);
                }

                m_lstDocument.Clear();
                ucError = null;
                ucPlcSummary = null;
                ucError2 = null;
                tabView.Documents.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCarTypeS(string sProcess, string sRecipe)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCarTypeSCallback cUpdate = new UpdateCarTypeSCallback(UpdateCarTypeS);
                    this.Invoke(cUpdate, new object[] {sProcess, sRecipe});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;

                        if (!ucPlcSummary.ProcessNameList.Contains(sProcess))
                            continue;

                        ucPlcSummary.UpdateCarTypeS(sProcess, sRecipe);
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
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
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.ClearFlowChartActive();
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateFlowChart(CTimeLogS cLogS)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateFlowChartCallback cUpdate = new UpdateFlowChartCallback(UpdateFlowChart);
                    this.Invoke(cUpdate, new object[] {cLogS});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.UpdateFlowChart(cLogS);

                        Thread.Sleep(1);
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateFlowChart(string sProcessKey, CTimeLog cLog)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateFlowChartCallback2 cUpdate = new UpdateFlowChartCallback2(UpdateFlowChart);
                    this.Invoke(cUpdate, new object[] {sProcessKey, cLog});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;

                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;

                        if (!ucPlcSummary.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcSummary.UpdateFlowChart(sProcessKey, cLog);
                        break;
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void CreateFlowChart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(CreateFlowChart);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.CreateFlowChart();
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ShowFlowChart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ShowFlowChart);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.ShowFlowChart();
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearFlowChart()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ClearFlowChart);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.ClearFlowChart();
                    }
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ErrorPanelResize()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(ErrorPanelResize);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    tabView.DocumentGroupProperties.ShowTabHeader = true;

                    //강제 Event
                    tabView.DocumentGroupProperties.ShowDocumentSelectorButton = false;
                    tabView.DocumentGroupProperties.ShowDocumentSelectorButton = true;

                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링" || doc.Caption == "공정 종합 모니터링")
                            continue;

                        if (doc.Control.GetType() != typeof (UCPlcSummary))
                            continue;

                        ucPlcSummary = (UCPlcSummary) doc.Control;
                        ucPlcSummary.ErrorPanelResize();
                    }
                    ucPlcSummary = null;

                    docManager.Update();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorCallback cUpdate = new UpdateErrorCallback(UpdateError);
                    this.Invoke(cUpdate, new object[] {cErrorInfo});
                }
                else
                {
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof (UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView) doc.Control;
                                ucError.UpdateError(cErrorInfo);
                                Document docTab = doc as Document;

                                if (docTab != null)
                                    tabView.Controller.Select(docTab);
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.UpdateError(cErrorInfo);
                                Document docTab = doc as Document;

                                if (docTab != null)
                                    tabView.Controller.Select(docTab);
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;

                                if (!ucPlcSummary.ProcessNameList.Contains(cErrorInfo.GroupKey))
                                    continue;

                                ucPlcSummary.UpdateError(cErrorInfo);
                                break;
                            }
                        }
                    }
                    ucError = null;
                    ucPlcSummary = null;
                    ucError2 = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorCallback2 cUpdate = new UpdateErrorCallback2(UpdateError);
                    this.Invoke(cUpdate, new object[] { cErrorInfo, iPriority });
                }
                else
                {
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView)doc.Control;
                                ucError.UpdateError(cErrorInfo, iPriority);
                                Document docTab = doc as Document;

                                if (docTab != null)
                                    tabView.Controller.Select(docTab);
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.UpdateError(cErrorInfo, iPriority);
                                Document docTab = doc as Document;

                                if (docTab != null)
                                    tabView.Controller.Select(docTab);
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof(UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary)doc.Control;

                                if (!ucPlcSummary.ProcessNameList.Contains(cErrorInfo.GroupKey))
                                    continue;

                                ucPlcSummary.UpdateError(cErrorInfo, iPriority);
                                break;
                            }
                        }
                    }
                    ucError = null;
                    ucError2 = null;
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOverError(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleOverCallback cUpdate = new UpdateCycleOverCallback(UpdateCycleOverError);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            //ucError = (UCAllErrorAlarmView)doc.Control;
                            //ucError.UpdateError(cErrorInfo);
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            ucError2 = (UCAllErrorAlarmView2)doc.Control;
                            ucError2.UpdateCycleOverError(sProcessKey);
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;

                                if (!ucPlcSummary.ProcessNameList.Contains(sProcessKey))
                                    continue;

                                ucPlcSummary.UpdateCycleOverError(sProcessKey);
                            }
                        }
                    }
                    ucError2 = null;
                    ucError = null;
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearErrorPanel(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleOverCallback cUpdate = new UpdateCycleOverCallback(ClearErrorPanel);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    UCAllErrorAlarmView ucError = null;
                    UCAllErrorAlarmView2 ucError2 = null;
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Caption == "라인 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof (UCAllErrorAlarmView))
                            {
                                ucError = (UCAllErrorAlarmView) doc.Control;
                                ucError.ClearError(sProcessKey);
                            }
                        }
                        else if (doc.Caption == "공정 종합 모니터링")
                        {
                            if (doc.Control.GetType() == typeof(UCAllErrorAlarmView2))
                            {
                                ucError2 = (UCAllErrorAlarmView2)doc.Control;
                                ucError2.ClearError(sProcessKey);
                            }
                        }
                        else
                        {
                            if (doc.Control.GetType() == typeof (UCPlcSummary))
                            {
                                ucPlcSummary = (UCPlcSummary) doc.Control;

                                if (!ucPlcSummary.ProcessNameList.Contains(sProcessKey))
                                    continue;

                                ucPlcSummary.ClearErrorPanel(sProcessKey);
                            }
                        }
                    }
                    ucError2 = null;
                    ucError = null;
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ReturnDocumentHost(BaseDocument doc)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateReturnDocumentHostCallback cUpdate = new UpdateReturnDocumentHostCallback(ReturnDocumentHost);
                    this.Invoke(cUpdate, new object[] {doc});
                }
                else
                {
                    UCPlcSummary ucPlcSummary = null;
                    BaseDocument docNew = null;

                    ucPlcSummary = (UCPlcSummary) doc.Control;

                    docNew = docManager.View.AddDocument(ucPlcSummary);
                    docNew.Caption = doc.Caption;
                    docNew.Properties.AllowClose = DefaultBoolean.False;
                    Document docTab = docNew as Document;

                    if (docTab != null)
                    {
                        docTab.Properties.AllowClose = DefaultBoolean.False;
                        docTab.Properties.ShowPinButton = DefaultBoolean.False;
                        docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                        docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                    }

                    tabView.Documents.Add(docNew);
                    tabView.DocumentGroupProperties.ShowTabHeader = true;
                    docManager.Update();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }


        #endregion


        #region Private Methods

        private void SetPlcBaseView()
        {
            try
            {
                if (CMultiProject.PlcLogicDataS == null || CMultiProject.PlcLogicDataS.Count == 0)
                    return;

                Clear();
                docManager.BeginUpdate();
                {
                    if (CMultiProject.PlcLogicDataS != null && CMultiProject.PlcLogicDataS.Count >= 2)
                        SetAllProcessMonitoringView();

                    foreach (var who in CMultiProject.PlcLogicDataS)
                    {
                        UCPlcSummary ucPlcSummary = new UCPlcSummary();
                        ucPlcSummary.Name = who.Key;
                        ucPlcSummary.Dock = DockStyle.Fill;
                        ucPlcSummary.LogReader = CMultiProject.LogReader;
                        ucPlcSummary.UEventAlarmDoubleClicked += ucPlcSummary_ErrorAlarmDoubleClicked;
                        ucPlcSummary.UEventManualCycleOver += ucPlcSummary_ManualCycleOverClicked;
                        ucPlcSummary.UEventManualCycleOverTagKey += ucPlcSummary_ManualCycleOverTagKeyClicked;
                        ucPlcSummary.SetView(who.Key);

                        BaseDocument doc = docManager.View.AddDocument(ucPlcSummary);
                        doc.Caption = who.Value.PlcName;
                        doc.Properties.AllowClose = DefaultBoolean.False;
                        Document docTab = doc as Document;

                        if (docTab != null)
                        {
                            docTab.Properties.AllowClose = DefaultBoolean.False;
                            docTab.Properties.ShowPinButton = DefaultBoolean.False;
                            docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                            docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                            docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                            docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                            docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                            docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                            docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                        }

                        m_lstDocument.Add(doc);
                    }
                }
                docManager.EndUpdate();
                docManager.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetProjectBaseView()
        {
            try
            {
                if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == string.Empty)
                    return;

                Clear();
                docManager.BeginUpdate();
                {
                    SetProjectBaseAllProcessView();

                    UCFlowChart ucPlcSummary = new UCFlowChart();
                    ucPlcSummary.Name = CMultiProject.ProjectID;
                    ucPlcSummary.Dock = DockStyle.Fill;
                    ucPlcSummary.SetView();

                    //BaseDocument doc = docManager.View.AddFloatDocument(ucPlcSummary);
                    BaseDocument doc = docManager.View.AddDocument(ucPlcSummary);
                    doc.Caption = CMultiProject.ProjectName;
                    doc.Tag = CMultiProject.ProjectID;

                    //UCPlcSummary ucPlcSummary = new UCPlcSummary();
                    //ucPlcSummary.Name = CMultiProject.ProjectID;
                    //ucPlcSummary.Dock = DockStyle.Fill;
                    //ucPlcSummary.LogReader = CMultiProject.LogReader;
                    //ucPlcSummary.UEventAlarmDoubleClicked += ucPlcSummary_ErrorAlarmDoubleClicked;
                    //ucPlcSummary.UEventManualCycleOver += ucPlcSummary_ManualCycleOverClicked;
                    //ucPlcSummary.UEventManualCycleOverTagKey += ucPlcSummary_ManualCycleOverTagKeyClicked;
                    //ucPlcSummary.SetView();

                    ////BaseDocument doc = docManager.View.AddFloatDocument(ucPlcSummary);
                    //BaseDocument doc = docManager.View.AddDocument(ucPlcSummary);
                    //doc.Caption = CMultiProject.ProjectName;
                    //doc.Tag = CMultiProject.ProjectID;

                    //Mexico 대응
                    //docManager.View.AddFloatingDocumentsHost(doc);
                    doc.Properties.AllowClose = DefaultBoolean.False;
                    Document docTab = doc as Document;

                    if (docTab != null)
                    {
                        docTab.Properties.AllowClose = DefaultBoolean.False;
                        docTab.Properties.ShowPinButton = DefaultBoolean.False;
                        docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                        docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                        docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                    }

                    m_lstDocument.Add(doc);
                }
                docManager.EndUpdate();
                docManager.Update();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetAllProcessMonitoringView()
        {
            try
            {
                UCAllErrorAlarmView ucErrorAlarm = new UCAllErrorAlarmView();
                ucErrorAlarm.Dock = DockStyle.Fill;
                ucErrorAlarm.UEventAllPanelDoubleClick += ucPlcSummary_AllErrorAlarmDoubleClicked;
                ucErrorAlarm.SetView();

                BaseDocument doc = docManager.View.AddDocument(ucErrorAlarm);
                doc.Caption = "라인 종합 모니터링";
                doc.Properties.AllowClose = DefaultBoolean.False;

                Document docTab = doc as Document;

                if (docTab != null)
                {
                    docTab.Properties.AllowClose = DefaultBoolean.False;
                    docTab.Properties.ShowPinButton = DefaultBoolean.False;
                    docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                    docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                }

                m_lstDocument.Add(doc);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetProjectBaseAllProcessView()
        {
            try
            {
                UCAllErrorAlarmView2 ucErrorAlarm = new UCAllErrorAlarmView2();
                ucErrorAlarm.Dock = DockStyle.Fill;
                ucErrorAlarm.UEventAllPanelDoubleClick += ucPlcSummary_ProjectBaseAllErrorAlarmDoubleClicked;
                ucErrorAlarm.SetView();

                BaseDocument doc = docManager.View.AddDocument(ucErrorAlarm);
                doc.Caption = "공정 종합 모니터링";
                doc.Properties.AllowClose = DefaultBoolean.False;

                Document docTab = doc as Document;

                if (docTab != null)
                {
                    docTab.Properties.AllowClose = DefaultBoolean.False;
                    docTab.Properties.ShowPinButton = DefaultBoolean.False;
                    docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                    docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                    docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                }

                m_lstDocument.Add(doc);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucPlcSummary_ErrorAlarmDoubleClicked()
        {
            if (UEventAlarmDoubleClicked != null)
                UEventAlarmDoubleClicked();
        }

        private void ucPlcSummary_AllErrorAlarmDoubleClicked(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleOverCallback cUpdate =
                        new UpdateCycleOverCallback(ucPlcSummary_AllErrorAlarmDoubleClicked);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    UCAllErrorAlarmView ucError = null;
                    UCPlcSummary ucPlcSummary = null;
                    foreach (BaseDocument doc in m_lstDocument)
                    {
                        if (doc.Caption == "라인 종합 모니터링")
                            continue;
                        else if(doc.Caption == sProcessKey)
                        {
                            Document docTab = doc as Document;

                            if (docTab != null)
                                tabView.Controller.Select(docTab);

                            break;
                        }
                    }
                    ucError = null;
                    ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucPlcSummary_ProjectBaseAllErrorAlarmDoubleClicked(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleOverCallback cUpdate = new UpdateCycleOverCallback(ucPlcSummary_ProjectBaseAllErrorAlarmDoubleClicked);
                    this.Invoke(cUpdate, new object[] { sProcessKey });
                }
                else
                {
                    if (UEventAlarmDoubleClicked != null)
                        UEventAlarmDoubleClicked();

                    //UCAllErrorAlarmView ucError = null;
                    //UCPlcSummary ucPlcSummary = null;
                    //foreach (BaseDocument doc in m_lstDocument)
                    //{
                    //    if (doc.Caption == "공정 종합 모니터링")
                    //        continue;
                    //    else if (doc.Caption == sProcessKey)
                    //    {
                    //        Document docTab = doc as Document;

                    //        if (docTab != null)
                    //            tabView.Controller.Select(docTab);

                    //        break;
                    //    }
                    //}
                    //ucError = null;
                    //ucPlcSummary = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }


        private void ucPlcSummary_ManualCycleOverClicked(string sProcess)
        {
            if (UEventManualCycleOver != null)
                UEventManualCycleOver(sProcess);
        }

        private void ucPlcSummary_ManualCycleOverTagKeyClicked(string sProcess, string sTagKey)
        {
            if (UEventManualCycleOverTagKey != null)
                UEventManualCycleOverTagKey(sProcess, sTagKey);
        }

        private void ReturnDocumentHostToDocument(BaseDocumentCollection docCollection)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateReturnDocumentToDocumentHostCallback cUpdate =
                        new UpdateReturnDocumentToDocumentHostCallback(ReturnDocumentHostToDocument);
                    this.Invoke(cUpdate, new object[] {docCollection});
                }
                else
                {
                    if (m_bregisterDoc && !m_bDocking)
                    {
                        UCPlcSummary ucPlcSummary = null;
                        BaseDocument docNew = null;
                        if (docCollection != null)
                        {
                            foreach (BaseDocument doc in docCollection)
                            {
                                if (doc.Control == null)
                                    continue;

                                if (doc.Control.GetType() == typeof (UCPlcCycle))
                                {
                                    if (UEventReturnDocumentHost != null)
                                        UEventReturnDocumentHost(doc);
                                    continue;
                                }

                                ucPlcSummary = (UCPlcSummary) doc.Control;

                                docNew = docManager.View.AddDocument(ucPlcSummary);
                                docNew.Caption = doc.Caption;
                                docNew.Properties.AllowClose = DefaultBoolean.False;
                                Document docTab = docNew as Document;

                                if (docTab != null)
                                {
                                    docTab.Properties.AllowClose = DefaultBoolean.False;
                                    docTab.Properties.ShowPinButton = DefaultBoolean.False;
                                    docTab.Appearance.Header.Font = new Font("Tahoma", 20, FontStyle.Bold);
                                    docTab.Appearance.HeaderActive.Font = new Font("Tahoma", 20, FontStyle.Bold);
                                    docTab.Appearance.HeaderDisabled.Font = new Font("Tahoma", 20, FontStyle.Bold);
                                    docTab.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 20, FontStyle.Bold);
                                    docTab.Appearance.HeaderSelected.Font = new Font("Tahoma", 20, FontStyle.Bold);
                                    docTab.Parent.Properties.HeaderButtonsShowMode = TabButtonShowMode.Never;
                                    docTab.Parent.Properties.HeaderButtons = TabButtons.None;
                                }

                                tabView.DocumentGroupProperties.ShowTabHeader = true;
                                tabView.Documents.Add(docNew);
                                m_lstDocument.Add(docNew);
                            }

                            BaseDocument docRemove = null;
                            while (docCollection.Count > 0)
                            {
                                docRemove = docCollection.First();

                                if (m_lstDocument.Contains(docRemove))
                                    m_lstDocument.Remove(docRemove);

                                docRemove.Dispose();
                                docCollection.Remove(docRemove);
                            }

                            docManager.Update();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcSummaryS", ex.Message);
                ex.Data.Clear();
            }
        }


        #endregion


        private void tabView_UnregisterDocumentsHostWindow(object sender, DevExpress.XtraBars.Docking2010.DocumentsHostWindowEventArgs e)
        {
            ReturnDocumentHostToDocument(e.HostWindow.DocumentManager.View.Documents);
            m_bregisterDoc = false;
        }

        private void tabView_BeginDocumentsHostDocking(object sender, DocumentCancelEventArgs e)
        {
            m_bDocking = true;
        }

        private void tabView_EndDocumentsHostDocking(object sender, DocumentEventArgs e)
        {
            m_bDocking = false;
        }

        private void tabView_RegisterDocumentsHostWindow(object sender, DevExpress.XtraBars.Docking2010.DocumentsHostWindowEventArgs e)
        {
            m_bregisterDoc = true;
        }

    }
}
