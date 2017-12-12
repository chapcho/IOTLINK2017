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
using UDM.Common;
using UDM.Log;
using UDMTrackerSimple.UserControls;

namespace UDMTrackerSimple
{
    public partial class UCErrorCardView : DevExpress.XtraEditors.XtraUserControl
    {
        private CPlcProcS m_cProcessS = null;
        private CErrorInfoS m_cErrorInfoS = null;

        private List<int> m_lstErrorID = new List<int>();
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();

        public event UCErrorCardWidget.UEventHandlerErrorGroupItemClicked UEventErrorGroupClicked;

        public UCErrorCardView()
        {
            InitializeComponent();

            widgetView.AllowDocumentStateChangeAnimation = DefaultBoolean.True;
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
                bool bOK = false;

                if (m_cErrorInfoS == null)
                    return;

                List<IGrouping<int,CErrorInfo>> lstGroupErrorInfoSum = m_cErrorInfoS.GroupBy(x => x.ErrorID).ToList();

                foreach (IGrouping<int, CErrorInfo> grpErrorSum in lstGroupErrorInfoSum)
                {
                    CErrorInfo cInfo = grpErrorSum.ElementAt(0);

                    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                    {
                        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                        if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                        {
                            cErrorSum.lstErrorInfo.Add(cInfo);
                        }
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
            widgetView.Documents.Clear();
            m_lstErrorID.Clear();
        }

        public void SetView(CPlcProcS cProcessS)
        {
            Document doc = null;
            int iDocCount = 0;

            m_cProcessS = cProcessS;

            if (m_cProcessS == null)
                return;

            int iCapacityCount = ((int)m_cProcessS.Count / widgetView.StackGroups.Count) + 1;
            widgetView.StackGroupProperties.Capacity = iCapacityCount;
            
            docManager.View.QueryControl += WidgetView_QueryControl;

            foreach (CPlcProc cProcess in m_cProcessS.Values)
            {
                if (widgetView.Documents.Exists(x => x.Caption == cProcess.Name))
                    continue;

                doc = new Document();
                doc.Caption = cProcess.Name;
                doc.Height = 125;
                doc.Tag = cProcess;
                doc.AppearanceCaption.FontSizeDelta = 3;
                doc.AppearanceActiveCaption.FontSizeDelta = 3;

                widgetView.Documents.Add(doc);

                if (iDocCount%3 == 0)
                    doc.ColumnIndex = 0;
                else if (iDocCount%3 == 1)
                    doc.ColumnIndex = 1;
                else if (iDocCount % 3 == 2)
                    doc.ColumnIndex = 2;

                iDocCount++;
            }
        }

        public void UpdateError()
        {
            string sGroupKey = string.Empty;

            CErrorInfoSummary cErrorSum = null;

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

            foreach (Document doc in widgetView.Documents)
            {
                if(doc.Control == null)
                    continue;

                UCErrorCardWidget ucCard = (UCErrorCardWidget) doc.Control;
                UCErrorStatisticChart ucChart = (UCErrorStatisticChart) doc.MaximizedControl;

                sGroupKey = doc.Caption;

                ucCard.UpdateError(m_lstErrorInfoSum[sGroupKey]);
                ucChart.ErrorInfoSummary = m_lstErrorInfoSum[sGroupKey];
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            string sGroupKey = string.Empty;
            CErrorInfoSummary cErrorSum = null;

            //Error 발생 시 상위 Error Update
            if (m_lstErrorID.Contains(cErrorInfo.ErrorID))
                return;

            m_lstErrorID.Add(cErrorInfo.ErrorID);

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

                UCErrorCardWidget ucCard = (UCErrorCardWidget)doc.Control;
                UCErrorStatisticChart ucChart = (UCErrorStatisticChart)doc.MaximizedControl;

                sGroupKey = doc.Caption;

                if (sGroupKey != cErrorInfo.GroupKey)
                    continue;

                ucCard.UpdateError(m_lstErrorInfoSum[sGroupKey]);
                ucChart.ErrorInfoSummary = m_lstErrorInfoSum[sGroupKey];
            }

            //if (!cErrorInfo.IsVisible || (cErrorInfo.IsVisible && cErrorInfo.DetailErrorMessage == string.Empty))
            
        }

        private void WidgetView_QueryControl(object sender, QueryControlEventArgs e)
        {
            UCErrorCardWidget widget = new UCErrorCardWidget();
            UCErrorStatisticChart ErrorChart = new UCErrorStatisticChart();

            widget.BackColor = Color.White;
            widget.UEventErrorGroupClicked += ucErrorCardView_UEventErrorGrouItemClick;

            CPlcProc cProcess = (CPlcProc)e.Document.Tag;

            widget.Process = cProcess;

            if (m_lstErrorInfoSum.ContainsKey(cProcess.Name))
                widget.ErrorInfoSummary = m_lstErrorInfoSum[cProcess.Name];

            e.Control = widget;
            (e.Document as Document).MaximizedControl = ErrorChart;
            
            ErrorChart.ProcessKey = cProcess.Name;
            ErrorChart.ErrorInfoSummary = widget.ErrorInfoSummary;

        }

        private void ucErrorCardView_UEventErrorGrouItemClick(object sender, CErrorInfoSummary cErrorInfoSum)
        {
            if (UEventErrorGroupClicked != null)
                UEventErrorGroupClicked(sender, cErrorInfoSum);
        }


    }
}
