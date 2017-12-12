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
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using UDM.Log;
using UDMTrackerSimple.UserControls;

namespace UDMTrackerSimple
{
    public partial class UCErrorAlarmView : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iScrollPos = -1;
        private int m_iCapacity = -1;

        private List<CPlcProc> m_cProcessS = null;
        //private CErrorInfoS m_cErrorInfoS = null;

        //private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        public UEventHandlerMonitorPanelDoubleClicked UEventPanelDoubleClick;
        public UEventHandlerMonitorPanelClicked UEventPanelClick;
        public UEventHandlerMonitorAllPanelDoubleClicked UEventAllPanelDoubleClick;

        private delegate void CUpdateErrorClearCallBack2();
        private delegate void CUpdateErrorCallBack(CErrorInfo cInfo);
        private delegate void CUpdateErrorCallBack2(CErrorInfo cInfo, int iPriority);
        private delegate void CUpdateErrorClearCallBack(string sProcessKey);
        private delegate void CUpdatePlcErrorCallBack(string sPlcName, string sProcessKey, string sErrorMessage);
        private delegate void CUpdatePlcErrorCallBack2(string sPlcName, string sProcessKey, string sErrorMessage, int iPriority);
        private delegate void CUpdateProcessErrorCallBack(string sProcessKey, string sErrorMessage);
        private delegate void CUpdateProcessErrorCallBack2(string sProcessKey, string sErrorMessage, int iPriority);
        private delegate void UpdateScrollMoveCallback2(object sender, MouseEventArgs e);

        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;

        public UCErrorAlarmView()
        {
            InitializeComponent();
        }

        public int Capacity
        {
            get { return m_iCapacity; }
        }

        //public CErrorInfoS ErrorInfoS
        //{
        //    get { return m_cErrorInfoS; }
        //    set { m_cErrorInfoS = value; }
        //}

        public void Run()
        {
            try
            {
                foreach (Document doc in widgetView.Documents)
                {
                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                foreach (Document doc in widgetView.Documents)
                {
                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.ClearText();
                        ucCard.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearControls()
        {
            try
            {
                if (widgetView.Documents == null || widgetView.Documents.Count == 0)
                    return;

                m_cProcessS = null;

                UCErrorAlarmWidget ucWidget = null;
                BaseDocument doc = null;
                while (widgetView.Documents.Count > 0)
                {
                    doc = widgetView.Documents.First();
                    ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.Dispose();

                    doc.Dispose();
                    widgetView.Documents.Remove(doc);
                }
                ucWidget = null;
                widgetView.Documents.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView(string sPlcKey)
        {
            try

            {
                m_cProcessS =
                    CMultiProject.PlcProcS.Where(x => x.Value.PlcLogicDataS.ContainsKey(sPlcKey))
                        .Select(x => x.Value)
                        .ToList();

                if (m_cProcessS == null)
                    return;

                widgetView.Documents.Clear();
                widgetView.StackGroups.Clear();

                int iWidgetHeight = 145;
                double dStackCnt = 4;

                if (m_cProcessS.Count > 20)
                {
                    dStackCnt = ((double) m_cProcessS.Count)/6;
                    iWidgetHeight = 120;
                    this.AutoScroll = true;
                }
                else
                {
                    this.AutoScroll = false;
                }
                for (int i = 0; i < dStackCnt; i++)
                    widgetView.StackGroups.Add(new StackGroup());

                double dCapacityCount = ((double) m_cProcessS.Count)/widgetView.StackGroups.Count;
                int iCapacityCount = (int) Math.Ceiling(dCapacityCount);

                if (iCapacityCount == 0)
                    iCapacityCount = 1;

                widgetView.StackGroupProperties.Capacity = iCapacityCount;

                m_iCapacity = iCapacityCount*iWidgetHeight; //145;

                foreach (CPlcProc cProcess in m_cProcessS)
                {
                    if (widgetView.Documents.Exists(x => x.Caption == cProcess.Name))
                        continue;

                    BaseDocument doc =
                        docManager.View.AddDocument(new UCErrorAlarmWidget(cProcess.Name) {Tag = cProcess});
                    doc.Caption = cProcess.Name;
                }

                foreach (Document doc in widgetView.Documents)
                {
                    doc.Height = iWidgetHeight; //145;

                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                        ucCard.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                        ucCard.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                m_cProcessS = CMultiProject.PlcProcS.Values.ToList();

                if (m_cProcessS == null)
                    return;

                widgetView.Documents.Clear();
                widgetView.StackGroups.Clear();

                int iWidgetHeight = 145;
                double dStackCnt = 4;

                if (m_cProcessS.Count > 20)
                {
                    dStackCnt = ((double) m_cProcessS.Count)/6;
                    iWidgetHeight = 120;
                    this.AutoScroll = true;
                }
                else
                    this.AutoScroll = false;

                for (int i = 0; i < dStackCnt; i++)
                    widgetView.StackGroups.Add(new StackGroup());

                double dCapacityCount = ((double) m_cProcessS.Count)/widgetView.StackGroups.Count;
                int iCapacityCount = (int) Math.Ceiling(dCapacityCount);

                if (iCapacityCount == 0)
                    iCapacityCount = 1;

                widgetView.StackGroupProperties.Capacity = iCapacityCount;

                m_iCapacity = iCapacityCount*iWidgetHeight; //145;

                foreach (CPlcProc cProcess in m_cProcessS)
                {
                    if (widgetView.Documents.Exists(x => x.Caption == cProcess.Name))
                        continue;

                    BaseDocument doc =
                        docManager.View.AddDocument(new UCErrorAlarmWidget(cProcess.Name) {Tag = cProcess});
                    doc.Caption = cProcess.Name;
                }

                foreach (Document doc in widgetView.Documents)
                {
                    doc.Height = iWidgetHeight; //145;

                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                        ucCard.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                        ucCard.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetPlcView(List<string> lstPlcName)
        {
            try
            {
                widgetView.Documents.Clear();
                widgetView.StackGroups.Clear();


                int iWidgetHeight = 145;
                double dStackCnt = 1;

                for (int i = 0; i < dStackCnt; i++)
                    widgetView.StackGroups.Add(new StackGroup());

                double dCapacityCount = ((double) lstPlcName.Count)/widgetView.StackGroups.Count;
                int iCapacityCount = (int) Math.Ceiling(dCapacityCount);

                if (iCapacityCount == 0)
                    iCapacityCount = 1;

                widgetView.StackGroupProperties.Capacity = iCapacityCount;

                m_iCapacity = iCapacityCount*iWidgetHeight; //145;

                foreach (string sPlcName in lstPlcName)
                {
                    if (widgetView.Documents.Exists(x => x.Caption == sPlcName))
                        continue;

                    BaseDocument doc = docManager.View.AddDocument(new UCErrorAlarmWidget(sPlcName));
                    doc.Caption = sPlcName;
                }

                foreach (Document doc in widgetView.Documents)
                {
                    doc.Height = iWidgetHeight; //145;

                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                        ucCard.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                        ucCard.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetProcessView(List<string> lstProcessName)
        {
            try
            {
                widgetView.Documents.Clear();
                widgetView.StackGroups.Clear();

                int iWidgetHeight = 145;

                double dStackCnt = 1;

                if (lstProcessName.Count > 6)
                    dStackCnt = 2;

                for (int i = 0; i < dStackCnt; i++)
                    widgetView.StackGroups.Add(new StackGroup());

                double dCapacityCount = ((double) lstProcessName.Count)/widgetView.StackGroups.Count;
                int iCapacityCount = (int) Math.Ceiling(dCapacityCount);

                if (iCapacityCount == 0)
                    iCapacityCount = 1;

                widgetView.StackGroupProperties.Capacity = iCapacityCount;
                m_iCapacity = iCapacityCount*iWidgetHeight; //145;

                foreach (string sPlcName in lstProcessName)
                {
                    if (widgetView.Documents.Exists(x => x.Caption == sPlcName))
                        continue;

                    BaseDocument doc = docManager.View.AddDocument(new UCErrorAlarmWidget(sPlcName));
                    doc.Caption = sPlcName;
                }

                foreach (Document doc in widgetView.Documents)
                {
                    doc.Height = iWidgetHeight; //145;

                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                        ucCard.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                        ucCard.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                        ucCard.MouseMove += ucWidget_MouseMove;
                        ucCard.MouseWheel += ucWidget_MouseWheel;
                        ucCard.MouseDown += ucWidget_MouseDown;
                        ucCard.MouseUp += ucWidget_MouseUp;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetFlowChartProcessSummaryView(List<string> lstProcessName)
        {
            try
            {
                widgetView.Documents.Clear();
                widgetView.StackGroups.Clear();

                int iWidgetHeight = 50;

                widgetView.StackGroups.Add(new StackGroup());
                double dCapacityCount = ((double) lstProcessName.Count)/widgetView.StackGroups.Count;
                int iCapacityCount = (int) Math.Ceiling(dCapacityCount);

                widgetView.StackGroupProperties.Capacity = iCapacityCount;
                m_iCapacity = iCapacityCount*iWidgetHeight;

                foreach (string sPlcName in lstProcessName)
                {
                    if (widgetView.Documents.Exists(x => x.Caption == sPlcName))
                        continue;

                    BaseDocument doc = docManager.View.AddDocument(new UCErrorAlarmWidget(sPlcName));
                    doc.Caption = sPlcName;
                }

                foreach (Document doc in widgetView.Documents)
                {
                    doc.Height = iWidgetHeight; //145;

                    if (doc.Control == null)
                        continue;

                    if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                        ucCard.ProcessStatusView();
                        ucCard.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
                        ucCard.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
                        ucCard.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorCallBack cUpdate = new CUpdateErrorCallBack(UpdateError);
                    this.Invoke(cUpdate, new object[] {cErrorInfo});
                }
                else
                {
                    if (!cErrorInfo.IsVisible)
                        return;

                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == cErrorInfo.GroupKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.UpdateError();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorCallBack2 cUpdate = new CUpdateErrorCallBack2(UpdateError);
                    this.Invoke(cUpdate, new object[] {cErrorInfo, iPriority});
                }
                else
                {
                    if (!cErrorInfo.IsVisible)
                        return;

                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == cErrorInfo.GroupKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.UpdateError();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOverError(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorClearCallBack cUpdate = new CUpdateErrorClearCallBack(UpdateCycleOverError);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sProcessKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.UpdateCycleOverError();

                    //foreach (Document doc in widgetView.Documents)
                    //{
                    //    if (doc.Control == null)
                    //        continue;

                    //    if (doc.Control.GetType() == typeof(UCErrorAlarmWidget))
                    //    {
                    //        CPlcProc cProcess = (CPlcProc)doc.Control.Tag;

                    //        if (cProcess.Name != sProcessKey)
                    //            continue;

                    //        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget)doc.Control;
                    //        ucCard.UpdateCycleOverError();
                    //        break;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdatePlcError(string sPlcName, string sGroupKey, string sErrorMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdatePlcErrorCallBack cUpdate = new CUpdatePlcErrorCallBack(UpdatePlcError);
                    this.Invoke(cUpdate, new object[] {sPlcName, sGroupKey, sErrorMessage});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sPlcName);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.Tag = sGroupKey;
                    ucWidget.UpdatePlcError(sErrorMessage);

                    Document document = (Document) doc as Document;

                    if (document != null)
                        document.Parent.Items.Move(0, document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdatePlcError(string sPlcName, string sGroupKey, string sErrorMessage, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdatePlcErrorCallBack2 cUpdate = new CUpdatePlcErrorCallBack2(UpdatePlcError);
                    this.Invoke(cUpdate, new object[] {sPlcName, sGroupKey, sErrorMessage, iPriority});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sPlcName);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.Tag = sGroupKey;
                    ucWidget.UpdatePlcError(sErrorMessage, iPriority);

                    Document document = (Document) doc as Document;

                    if (document != null)
                        document.Parent.Items.Move(0, document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateProcessError(string sGroupKey, string sErrorMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateProcessErrorCallBack cUpdate = new CUpdateProcessErrorCallBack(UpdateProcessError);
                    this.Invoke(cUpdate, new object[] {sGroupKey, sErrorMessage});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sGroupKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.Tag = sGroupKey;
                    ucWidget.UpdatePlcError(sErrorMessage);

                    Document document = (Document) doc as Document;

                    if (document != null)
                        document.Parent.Items.Move(0, document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateProcessStatusError(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorClearCallBack cUpdate = new CUpdateErrorClearCallBack(UpdateProcessStatusError);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sProcessKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.UpdateError();

                    Document document = (Document) doc as Document;
                    document.Parent.Items.Move(0, document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateProcessError(string sGroupKey, string sErrorMessage, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateProcessErrorCallBack2 cUpdate = new CUpdateProcessErrorCallBack2(UpdateProcessError);
                    this.Invoke(cUpdate, new object[] {sGroupKey, sErrorMessage, iPriority});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sGroupKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.Tag = sGroupKey;
                    ucWidget.UpdatePlcError(sErrorMessage, iPriority);

                    Document document = (Document) doc as Document;

                    if (document != null)
                        document.Parent.Items.Move(0, document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearError(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorClearCallBack cUpdate = new CUpdateErrorClearCallBack(ClearError);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    BaseDocument doc = widgetView.Documents.SingleOrDefault(x => x.Caption == sProcessKey);

                    if (doc == null || doc.Control == null)
                        return;

                    UCErrorAlarmWidget ucWidget = (UCErrorAlarmWidget) doc.Control;
                    ucWidget.ClearText();

                    //foreach (Document doc in widgetView.Documents)
                    //{
                    //    if (doc.Control == null)
                    //        continue;

                    //    if (doc.Control.GetType() == typeof(UCErrorAlarmWidget))
                    //    {
                    //        CPlcProc cProcess = (CPlcProc)doc.Control.Tag;

                    //        if (cProcess.Name != sProcessKey)
                    //            continue;

                    //        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget)doc.Control;
                    //        ucCard.ClearText();
                    //        break;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearPlcError(string sProcessKey)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorClearCallBack cUpdate = new CUpdateErrorClearCallBack(ClearPlcError);
                    this.Invoke(cUpdate, new object[] {sProcessKey});
                }
                else
                {
                    foreach (Document doc in widgetView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                        {
                            UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;

                            if (ucCard.Tag != null && ucCard.Tag.GetType() == typeof (string) &&
                                ucCard.Tag.ToString() == sProcessKey)
                            {
                                ucCard.ClearText();
                                break;
                            }
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


        public void ClearAllError()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateErrorClearCallBack2 cUpdate = new CUpdateErrorClearCallBack2(ClearAllError);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    foreach (Document doc in widgetView.Documents)
                    {
                        if (doc.Control == null)
                            continue;

                        if (doc.Control.GetType() == typeof (UCErrorAlarmWidget))
                        {
                            UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget) doc.Control;
                            ucCard.ClearText();
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

        private void ucWidget_UEventErrorPanelDoubleClicked()
        {
            try
            {
                if (UEventPanelDoubleClick != null)
                    UEventPanelDoubleClick();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_UEventErrorPanelClicked(string sProcessKey)
        {
            try
            {
                if (UEventPanelClick != null)
                    UEventPanelClick(sProcessKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_UEventErrorAllPanelDoubleClicked(string sProcessKey)
        {
            try

            {
                if (UEventAllPanelDoubleClick != null)
                    UEventAllPanelDoubleClick(sProcessKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucWidget_MouseWheel);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {

                    int iValue = this.VerticalScroll.Value;

                    int iPosition = this.AutoScrollPosition.Y - e.Delta;

                    if (iPosition < 0)
                        iPosition = 0;
                    //else if (iPosition < this.VerticalScroll.Minimum)
                    //    iPosition = this.VerticalScroll.Minimum;

                    this.AutoScrollPosition = new Point(this.AutoScrollPosition.X, 50);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucWidget_MouseDown);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    m_bScrollMove = true;
                    m_iScrollPosition = Cursor.Position.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
        
        private void ucWidget_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucWidget_MouseUp);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    m_bScrollMove = false;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = this.VerticalScroll.Value + iDelta;

                    if (iPosition > this.VerticalScroll.Maximum)
                        iPosition = this.VerticalScroll.Maximum;
                    else if (iPosition < this.VerticalScroll.Minimum)
                        iPosition = this.VerticalScroll.Minimum;

                    this.VerticalScroll.Value = iPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucWidget_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucWidget_MouseMove);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    if (!m_bScrollMove)
                        return;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = this.VerticalScroll.Value + iDelta;

                    if (iPosition > this.VerticalScroll.Maximum)
                        iPosition = this.VerticalScroll.Maximum;
                    else if (iPosition < this.VerticalScroll.Minimum)
                        iPosition = this.VerticalScroll.Minimum;

                    this.VerticalScroll.Value = iPosition;
                    m_iScrollPosition = Cursor.Position.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void UCErrorAlarmView_Resize(object sender, EventArgs e)
        {
            try
            {
                docManager.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
