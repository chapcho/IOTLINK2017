using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using UDM.Log;
using UDMLadderTracker.UserControls;

namespace UDMLadderTracker
{
    public partial class UCErrorAlarmView : DevExpress.XtraEditors.XtraUserControl
    {
        private CPlcProcS m_cProcessS = null;
        private CErrorInfoS m_cErrorInfoS = null;

        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        private delegate void CUpdateErrorCallBack(CErrorInfo cInfo);
        private delegate void CUpdateErrorClearCallBack(string sProcessKey);

        public UCErrorAlarmView()
        {
            InitializeComponent();
        }

        public CPlcProcS ProcessS
        {
            get { return m_cProcessS; }
            set { m_cProcessS = value; }
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set
            {
                m_cErrorInfoS = value;
                CErrorInfoSummary cErrorSum = null;
                m_lstErrorInfoSum.Clear();

                if (m_cErrorInfoS == null)
                    return;

                foreach (CErrorInfo cInfo in m_cErrorInfoS)
                {
                    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                    {
                        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                        if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                            cErrorSum.lstErrorInfo.Add(cInfo);
                    }
                    else
                    {
                        cErrorSum = new CErrorInfoSummary();
                        cErrorSum.GroupKey = cInfo.GroupKey;
                        cErrorSum.lstErrorInfo.Add(cInfo);

                        m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                    }
                }
            }
        }

        public void ClearControls()
        {
            if(widgetView.Documents == null || widgetView.Documents.Count == 0)
                return;

            bool bMaximized = false;

            foreach (Document doc in widgetView.Documents)
            {
                if (doc.IsMaximized)
                    bMaximized = true;
            }

            if(!bMaximized)
                widgetView.Documents.Clear();
        }

        public void SetView(CPlcProcS cProcessS)
        {
            m_lstErrorInfoSum.Clear();

            Document doc = null;

            m_cProcessS = cProcessS;

            if (m_cProcessS == null)
                return;

            int iCapacityCount = ((int)m_cProcessS.Count / widgetView.StackGroups.Count) + 1;
            widgetView.StackGroupProperties.Capacity = iCapacityCount;
            
            foreach (CPlcProc cProcess in m_cProcessS.Values)
            {
                if (widgetView.Documents.Exists(x => x.Caption == cProcess.Name))
                    continue;

                doc = new Document();
                doc.Height = 350;
                doc.Caption = cProcess.Name;
                doc.Tag = cProcess;
                doc.AppearanceCaption.FontSizeDelta = 3;
               doc.AppearanceActiveCaption.FontSizeDelta = 3;

                widgetView.Documents.Add(doc);
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorCallBack cUpdate = new CUpdateErrorCallBack(UpdateError);
                this.Invoke(cUpdate, new object[] { cErrorInfo});
            }
            else
            {
                CErrorInfoSummary cErrorSum = null;

                if (m_lstErrorInfoSum.ContainsKey(cErrorInfo.GroupKey))
                {
                    cErrorSum = m_lstErrorInfoSum[cErrorInfo.GroupKey];

                    if (!cErrorSum.lstErrorInfo.Contains(cErrorInfo))
                        cErrorSum.lstErrorInfo.Add(cErrorInfo);
                }
                else
                {
                    cErrorSum = new CErrorInfoSummary();
                    cErrorSum.GroupKey = cErrorInfo.GroupKey;
                    cErrorSum.lstErrorInfo.Add(cErrorInfo);

                    m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                }

                foreach (Document doc in widgetView.Documents)
                {
                    if (doc.Control == null)
                        continue;

                    CPlcProc cProcess = (CPlcProc)doc.Tag;

                    if (cProcess.Name != cErrorInfo.GroupKey)
                        continue;

                    if (doc.Control.GetType() == typeof(UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget)doc.Control;
                        ucCard.UpdateError();
                    }

                    if (doc.MaximizedControl.GetType() == typeof(UCErrorLogGrid))
                    {
                        UCErrorLogGrid ucGrid = (UCErrorLogGrid)doc.MaximizedControl;
                        CErrorInfoS cInfoS = new CErrorInfoS();
                        cInfoS.AddRange(m_lstErrorInfoSum[cProcess.Name].lstErrorInfo);
                        ucGrid.UpdateView(cInfoS);
                    }
                }
            }
        }

        public void ClearError(string sProcessKey)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorClearCallBack cUpdate = new CUpdateErrorClearCallBack(ClearError);
                this.Invoke(cUpdate, new object[] { sProcessKey });
            }
            else
            {
                if (m_lstErrorInfoSum.ContainsKey(sProcessKey))
                    m_lstErrorInfoSum.Remove(sProcessKey);

                foreach (Document doc in widgetView.Documents)
                {
                    if (doc.Control == null || doc.Caption != sProcessKey)
                        continue;

                    if (doc.Control.GetType() == typeof(UCErrorAlarmWidget))
                    {
                        UCErrorAlarmWidget ucCard = (UCErrorAlarmWidget)doc.Control;
                        ucCard.ClearText();
                    }

                    if (doc.MaximizedControl.GetType() == typeof(UCErrorLogGrid))
                    {
                        UCErrorLogGrid ucGrid = (UCErrorLogGrid)doc.MaximizedControl;
                        ucGrid.ClearGrid();
                    }
                }
            }
        }

        private void UCErrorAlarmView_Load(object sender, EventArgs e)
        {
            docManager.View.QueryControl += WidgetView_QueryControl;
        }

        private void WidgetView_QueryControl(object sender, QueryControlEventArgs e)
        {
            UCErrorAlarmWidget widget = new UCErrorAlarmWidget();
            UCErrorLogGrid ucErrorGrid = new UCErrorLogGrid();

            CPlcProc cProcess = (CPlcProc)e.Document.Tag;
            CErrorInfoS cInfoS = new CErrorInfoS();

            widget.ProcessText = cProcess.Name;

            if (m_lstErrorInfoSum.ContainsKey(cProcess.Name))
                cInfoS.AddRange(m_lstErrorInfoSum[cProcess.Name].lstErrorInfo);

            Document doc = e.Document as Document;

            e.Control = widget;
            (e.Document as Document).MaximizedControl = ucErrorGrid;

            ucErrorGrid.UpdateView(cInfoS);
        }

        private void UCErrorAlarmView_Resize(object sender, EventArgs e)
        {
            docManager.Update();
        }
    }
}
