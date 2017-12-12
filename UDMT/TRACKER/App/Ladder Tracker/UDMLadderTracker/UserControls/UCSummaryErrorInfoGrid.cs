using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;
using UDMTrackerSimple.UserControls;

namespace UDMTrackerSimple
{
    public partial class UCSummaryErrorInfoGrid : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoS m_cErrorInfoS = null;
        private CGroupS m_cGroupS = null;
        private int m_iMinWidth = 0;

        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();
        private delegate void UpdateErrorCallback();
        private delegate void UpdateErrorCallback2(CErrorInfoSummary cErrorInfoSum);

        public delegate void UEventHandlerErrorGroupTileItemClicked(object sender, CErrorInfoSummary cErrorInfoSummary);
        public delegate void UEventHandlerErrorRefreshButtonClicked(object sender);
        public delegate void UEventHandlerErrorClearButtonClicked(object sender);

        public event UEventHandlerErrorGroupTileItemClicked UEventErrorGroupTileClicked;
        public event UEventHandlerErrorClearButtonClicked UEventErrorClearButtonClicked;
        public event UEventHandlerErrorRefreshButtonClicked UEventErrorRefreshButtonClicked;

        public UCSummaryErrorInfoGrid()
        {
            InitializeComponent();
        }

        public CErrorInfoS ErrorInfoS
        {
            get { return m_cErrorInfoS; }
            set
            {
                m_cErrorInfoS = value;
                CErrorInfoSummary cErrorSum = null;

                if (m_cErrorInfoS == null)
                    return;

                foreach (CErrorInfo cInfo in m_cErrorInfoS)
                {
                    if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                    {
                        cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];
                        
                        if(!cErrorSum.lstErrorInfo.Contains(cInfo))
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

                grdError.DataSource = m_lstErrorInfoSum.Values;
                grdError.RefreshDataSource();
            }
        }

        public CGroupS GroupS
        {
            get { return m_cGroupS; }
            set
            {
                m_cGroupS = value;
                SetGroupS();
            }
        }

        public void ClearControls()
        {
            if (pnlErrorChart.Controls != null && pnlErrorChart.Controls.Count > 0)
                pnlErrorChart.Controls.Clear();
        }

        public void RefreshErrorInfoSummary()
        {
            if (this.InvokeRequired)
            {
                UpdateErrorCallback cErrorCallback = new UpdateErrorCallback(RefreshErrorInfoSummary);
                this.Invoke(cErrorCallback, new object[] {});
            }
            else
            {
                CErrorInfoSummary cErrorSum = null;

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

                grdError.DataSource = null;
                grdError.DataSource = m_lstErrorInfoSum.Values;

                grdError.RefreshDataSource();

                UpdateErrorChart();
            }
        }

        public void ClearGrid()
        {
            grdError.DataSource = null;
        }

        private void UpdateErrorChart()
        {
            SetGroupS();
        }

        private void SetGroupS()
        {
            if (this.InvokeRequired)
            {
                UpdateErrorCallback cUpdate = new UpdateErrorCallback(SetGroupS);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                bool bLastGroup = false;

                if (m_cGroupS == null) return;

                ClearControls();

                for (int i = 0; i < m_cGroupS.Count; i++)
                {
                    if (i == m_cGroupS.Count - 1)
                        bLastGroup = true;
                    else
                        bLastGroup = false;

                    AddGroupChart(m_cGroupS[i], bLastGroup);
                }

                SetUnitSize();
            }
        }

        private void SetGroup(CErrorInfoSummary cErrorInfoSum)
        {
            if (this.InvokeRequired)
            {
                UpdateErrorCallback2 cUpdate = new UpdateErrorCallback2(SetGroup);
                this.Invoke(cUpdate, new object[] {cErrorInfoSum});
            }
            else
            {
                ClearControls();

                UCErrorStatisticChart ucViewer = new UCErrorStatisticChart();
                ucViewer.Dock = DockStyle.Fill;
                ucViewer.SetDetailErrorChart(cErrorInfoSum);

                pnlErrorChart.Controls.Add(ucViewer);
            }
        }

        private void AddGroupChart(CGroup cGroup, bool bLastGroup)
        {
            try
            {
                UCErrorStatisticChart ucViewer = new UCErrorStatisticChart();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Left;
                pnlSplitter.Width = 5;

                ucViewer.ProcessKey = cGroup.Key;

                if (m_lstErrorInfoSum != null && m_lstErrorInfoSum.ContainsKey(cGroup.Key))
                    ucViewer.ErrorInfoSummary = m_lstErrorInfoSum[cGroup.Key];

                ucViewer.Width = m_iMinWidth;
                ucViewer.Dock = DockStyle.Left;

                pnlErrorChart.Controls.Add(ucViewer);

                if(!bLastGroup)
                    pnlErrorChart.Controls.Add(pnlSplitter);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void SetUnitSize()
        {
            ControlCollection controls = pnlErrorChart.Controls;
            if (controls.Count == 0)
                return;

            try
            {
                int iUnitWidth = pnlErrorChart.ClientRectangle.Width / controls.Count;

                if (iUnitWidth < m_iMinWidth)
                    iUnitWidth = m_iMinWidth;

                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCErrorStatisticChart))
                        control.Width = iUnitWidth - 5;
                }

                pnlErrorChart.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void grvErrorTile_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            CErrorInfoSummary cErrorInfoSum = (CErrorInfoSummary)grvErrorTile.GetRow(e.Item.RowHandle);

            if (cErrorInfoSum == null)
                return;

            SetGroup(cErrorInfoSum);

            if (UEventErrorGroupTileClicked != null)
                UEventErrorGroupTileClicked(this, cErrorInfoSum);

        }

        private void btnChartClear_Click(object sender, EventArgs e)
        {
            ClearControls();

            if (UEventErrorClearButtonClicked != null)
                UEventErrorClearButtonClicked(this);
        }

        private void UCSummaryErrorInfoGrid_Load(object sender, EventArgs e)
        {

        }

        private void UCSummaryErrorInfoGrid_Resize(object sender, EventArgs e)
        {
            try
            {
                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetGroupS();

            if (UEventErrorRefreshButtonClicked != null)
                UEventErrorRefreshButtonClicked(this);
        }
    }
}
