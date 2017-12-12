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
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using UDM.Log;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerReturnDocumentHostToDocument(BaseDocument doc);

    public partial class UCPlcCycleS : DevExpress.XtraEditors.XtraUserControl
    {
        private bool m_bregisterDoc = false;
        private bool m_bDocking = false;
        private List<BaseDocument> m_lstDocument = new List<BaseDocument>();

        private delegate void UpdateNoneParameterCallback();
        private delegate void UpdateCycleStatisticSCallback(CCycleInfo cInfo);
        private delegate void UpdateCycleOverCallback(string sProcessKey);
        private delegate void UpdateCycleStartCallback(string sProcessKey, DateTime dtActTime);
        private delegate void UpdateCycleEndCallback(string sProcessKey, DateTime dtActTime, bool bError, int iMaxTime);
        private delegate void UpdateCycleStateCallback(string sProcessKey, EMCycleRunType emCycleType);
        private delegate void UpdateCycleInfoSCallback(string sProcessKey, CCycleInfo cInfo);
        private delegate void UpdateReturnDocumentHostCallback(BaseDocument doc);
        private delegate void UpdateReturnDocumentToDocumentHostCallback(BaseDocumentCollection docCollection);

        public UEventHandlerReturnDocumentHostToDocument UEventReturnDocumentHost = null;

        public UCPlcCycleS()
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
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) // tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;
                        ucPlcCycle.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;
                        ucPlcCycle.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                UCPlcCycle ucPlcCycle = null;

                BaseDocument doc = null;
                while (tabView.Documents.Count > 0)
                {
                    doc = tabView.Documents.First();

                    if (doc.Control != null && doc.Control.GetType() == typeof (UCPlcCycle))
                    {
                        ucPlcCycle = (UCPlcCycle) doc.Control;
                        ucPlcCycle.Clear();
                        ucPlcCycle.Dispose();
                    }

                    doc.Dispose();
                    tabView.Documents.Remove(doc);
                }

                while (m_lstDocument.Count > 0)
                {
                    doc = m_lstDocument.First();

                    if (doc.Control != null && doc.Control.GetType() == typeof (UCPlcCycle))
                    {
                        ucPlcCycle = (UCPlcCycle) doc.Control;
                        ucPlcCycle.Clear();
                        ucPlcCycle.Dispose();
                    }

                    doc.Dispose();
                    m_lstDocument.Remove(doc);
                }

                m_lstDocument.Clear();
                doc = null;
                ucPlcCycle = null;
                tabView.Documents.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void CycleResizePanelS()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(CycleResizePanelS);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    tabView.DocumentGroupProperties.ShowTabHeader = true;

                    tabView.DocumentGroupProperties.ShowDocumentSelectorButton = false;
                    tabView.DocumentGroupProperties.ShowDocumentSelectorButton = true;

                    //UCPlcCycle ucPlcCycle = null;
                    //foreach (BaseDocument doc in tabView.Documents)
                    //{
                    //    ucPlcCycle = (UCPlcCycle)doc.Control;
                    //    ucPlcCycle.CycleResizePanel();

                    //    ucPlcCycle = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleStatisticS(CCycleInfo cCycleInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleStatisticSCallback cUpdate = new UpdateCycleStatisticSCallback(UpdateCycleStatisticS);
                    this.Invoke(cUpdate, new object[] {cCycleInfo});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) // tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(cCycleInfo.GroupKey))
                            continue;

                        ucPlcCycle.UpdateCycleStatisticS(cCycleInfo);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOver(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleOverCallback cUpdate = new UpdateCycleOverCallback(UpdateCycleOver);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) // tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcCycle.UpdateCycleOver(sProcessKey);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleStart(string sProcessKey, DateTime dtActTime)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleStartCallback cUpdate = new UpdateCycleStartCallback(UpdateCycleStart);
                    this.Invoke(cUpdate, new object[] {sProcessKey, dtActTime});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) // tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcCycle.UpdateCycleStart(sProcessKey, dtActTime);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleEnd(string sProcessKey, DateTime dtActTime, bool bError, int iMaxTime)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleEndCallback cUpdate = new UpdateCycleEndCallback(UpdateCycleEnd);
                    this.Invoke(cUpdate, new object[] {sProcessKey, dtActTime, bError, iMaxTime});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) // tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcCycle.UpdateCycleEnd(sProcessKey, dtActTime, bError, iMaxTime);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleState(string sProcessKey, EMCycleRunType emCycleType)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleStateCallback cUpdate = new UpdateCycleStateCallback(UpdateCycleState);
                    this.Invoke(cUpdate, new object[] {sProcessKey, emCycleType});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcCycle.UpdateCycleState(sProcessKey, emCycleType);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleInfoS(string sProcessKey, CCycleInfo cCycleInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCycleInfoSCallback cUpdate = new UpdateCycleInfoSCallback(UpdateCycleInfoS);
                    this.Invoke(cUpdate, new object[] {sProcessKey, cCycleInfo});
                }
                else
                {
                    UCPlcCycle ucPlcCycle = null;
                    foreach (BaseDocument doc in m_lstDocument) //tabView.Documents)
                    {
                        if (doc.Control == null || doc.Control.GetType() != typeof (UCPlcCycle))
                            continue;

                        ucPlcCycle = (UCPlcCycle) doc.Control;

                        if (!ucPlcCycle.ProcessNameList.Contains(sProcessKey))
                            continue;

                        ucPlcCycle.UpdateCycleInfoS(sProcessKey, cCycleInfo);
                    }
                    ucPlcCycle = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
                    UCPlcCycle ucPlcCycle = null;
                    BaseDocument docNew = null;

                    ucPlcCycle = (UCPlcCycle) doc.Control;

                    docNew = docManager.View.AddDocument(ucPlcCycle);
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
                    docManager.Update();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
                    foreach (var who in CMultiProject.PlcLogicDataS)
                    {
                        UCPlcCycle ucPlcCycle = new UCPlcCycle();
                        ucPlcCycle.Name = who.Key;
                        ucPlcCycle.Dock = DockStyle.Fill;
                        ucPlcCycle.SetView(who.Key);

                        BaseDocument doc = docManager.View.AddDocument(ucPlcCycle);
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
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
                    UCPlcCycle ucPlcCycle = new UCPlcCycle();
                    ucPlcCycle.Name = CMultiProject.ProjectID;
                    ucPlcCycle.Dock = DockStyle.Fill;
                    ucPlcCycle.SetView();

                    BaseDocument doc = docManager.View.AddDocument(ucPlcCycle);
                    doc.Caption = CMultiProject.ProjectName;
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
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
                ex.Data.Clear();
            }
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
                        UCPlcCycle ucPlcCycle = null;
                        BaseDocument docNew = null;
                        if (docCollection != null)
                        {
                            foreach (BaseDocument doc in docCollection)
                            {
                                if (doc.Control == null)
                                    continue;

                                if (doc.Control.GetType() == typeof (UCPlcSummary))
                                {
                                    if (UEventReturnDocumentHost != null)
                                        UEventReturnDocumentHost(doc);
                                    continue;
                                }

                                ucPlcCycle = (UCPlcCycle) doc.Control;

                                docNew = docManager.View.AddDocument(ucPlcCycle);
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
                                m_lstDocument.Add(docNew);
                            }

                            BaseDocument docRemove2 = null;
                            BaseDocument docRemove = null;
                            while (docCollection.Count > 0)
                            {
                                docRemove = docCollection.First();

                                if (m_lstDocument.Contains(docRemove))
                                    m_lstDocument.Remove(docRemove);

                                //if (m_lstDocument.SingleOrDefault(x => x.Caption == docRemove.Caption) != null)
                                //{
                                //    docRemove2 = m_lstDocument.Single(x => x.Caption == docRemove.Caption);
                                //    docRemove2.Dispose();
                                //    m_lstDocument.Remove(docRemove2);
                                //}

                                docRemove.Dispose();
                            }
                            docManager.Update();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycleS", ex.Message);
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
