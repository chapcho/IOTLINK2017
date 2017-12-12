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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using UDM.General.Statistics;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCXBarRChart : DevExpress.XtraEditors.XtraUserControl
    {
        private CUserDevice m_cDevice = null;
        private CTimeLogS m_cLogS = null;
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private CTimeNodeS m_cNodeS = null;
        private CTimeNodeS m_cAbnormalNodeS = new CTimeNodeS();

        public UCXBarRChart()
        {
            InitializeComponent();
        }

        public CUserDevice UserDevice
        {
            get { return m_cDevice; }
            set { m_cDevice = value; }
        }

        public CTimeLogS LogS
        {
            get { return m_cLogS; }
            set { m_cLogS = value; }
        }

        public DateTime From
        {
            get { return m_dtFrom; }
            set { m_dtFrom = value; }
        }

        public DateTime To
        {
            get { return m_dtTo; }
            set { m_dtTo = value; }
        }

        private void SetTimeNodeS()
        {
            try
            {
                List<double> lstValue = new List<double>();

                if (m_cLogS == null || m_cLogS.Count == 0)
                    return;

                if (m_cNodeS == null)
                    m_cNodeS = new CTimeNodeS(m_cDevice.Tag, m_cLogS, m_dtFrom, m_dtTo);

                if (m_cNodeS.Count > 0)
                {
                    foreach (CTimeNode cNode in m_cNodeS)
                    {
                        if (m_cDevice.Tag.DataType == EMDataType.Bool)
                            cNode.Value = Convert.ToInt32(cNode.Duration);

                        lstValue.Add(cNode.Value);
                    }
                }

                grdBarData.DataSource = m_cNodeS;
                grdBarData.RefreshDataSource();

                m_cDevice.Average = CStatics.Mean(lstValue);
                m_cDevice.Max = lstValue.Max();
                m_cDevice.Min = lstValue.Min();

                double dUpper = m_cDevice.Average*1.5;
                double dLower = m_cDevice.Average*0.5;

                txtMax.Text = m_cDevice.Max.ToString();
                txtMin.Text = m_cDevice.Min.ToString();
                txtAverage.Text = Math.Round(m_cDevice.Average, 2).ToString();

                txtUpper.Text = Math.Round(dUpper, 2).ToString();
                txtLower.Text = Math.Round(dLower, 2).ToString();
                m_cDevice.UpperBound = dUpper;
                m_cDevice.LowerBound = dLower;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetChart()
        {
            try
            {
                if (m_cNodeS == null || m_cNodeS.Count == 0)
                    return;

                m_cAbnormalNodeS.Clear();
                m_cNodeS.UpdateTimeRange();

                SeriesPoint cValuePoint;
                SeriesPoint cUpperPoint;
                SeriesPoint cLowerPoint;
                SeriesPoint cTrendValuePoint;
                SeriesPoint cTrendUpperPoint;
                SeriesPoint cTrendLowerPoint;
                CTimeNode cNode = null;
                for (int i = 0; i < m_cNodeS.Count; i++)
                {
                    cNode = m_cNodeS[i];

                    if (m_cDevice.UpperBound != 0)
                    {
                        cTrendUpperPoint = new SeriesPoint(i + 1, new double[] { m_cDevice.UpperBound });
                        cTrendUpperPoint.ToolTipHint = "UpperValue : " + m_cDevice.UpperBound;
                        exTrendChart.Series["Upper"].Points.Add(cTrendUpperPoint);

                        cUpperPoint = new SeriesPoint(i + 1, new double[] { m_cDevice.UpperBound });
                        cUpperPoint.ToolTipHint = "UpperValue : " + m_cDevice.UpperBound;
                        exChart.Series["Upper"].Points.Add(cUpperPoint);
                    }

                    if (m_cDevice.LowerBound != 0)
                    {
                        cLowerPoint = new SeriesPoint(i + 1, new double[] { m_cDevice.LowerBound });
                        cLowerPoint.ToolTipHint = "LowerValue : " + m_cDevice.LowerBound;
                        exChart.Series["Lower"].Points.Add(cLowerPoint);

                        cTrendLowerPoint = new SeriesPoint(i + 1, new double[] { m_cDevice.LowerBound });
                        cTrendLowerPoint.ToolTipHint = "LowerValue : " + m_cDevice.LowerBound;
                        exTrendChart.Series["Lower"].Points.Add(cTrendLowerPoint);
                    }

                    cValuePoint = new SeriesPoint(i + 1, new double[] { cNode.Value });
                    cValuePoint.Tag = cNode;

                    cTrendValuePoint = new SeriesPoint(i + 1, new double[] { cNode.Value });

                    if (m_cDevice.UpperBound != 0 && cNode.Value > m_cDevice.UpperBound)
                    {
                        cValuePoint.Color = Color.Red;
                        cValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value +
                                                  "\r\nOver Value : " + (cNode.Value - m_cDevice.UpperBound).ToString();

                        cTrendValuePoint.Color = Color.Red;
                        cTrendValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value +
                                                  "\r\nOver Value : " + (cNode.Value - m_cDevice.UpperBound).ToString();

                        m_cAbnormalNodeS.Add(cNode);
                    }
                    else if (m_cDevice.LowerBound != 0 && cNode.Value < m_cDevice.LowerBound)
                    {
                        cValuePoint.Color = Color.Gold;
                        cValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value +
                                                  "\r\nUnder Value : " + (m_cDevice.LowerBound - cNode.Value).ToString();

                        cTrendValuePoint.Color = Color.Gold;
                        cTrendValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value +
                                                  "\r\nUnder Value : " + (m_cDevice.LowerBound - cNode.Value).ToString();

                        m_cAbnormalNodeS.Add(cNode);
                    }
                    else
                    {
                        cValuePoint.Color = Color.DodgerBlue;
                        cValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value;

                        cTrendValuePoint.Color = Color.DodgerBlue;
                        cTrendValuePoint.ToolTipHint = "Time : " + cNode.Start + "\r\nValue : " + cNode.Value;
                    }

                    exChart.Series["Value"].Points.Add(cValuePoint);
                    exTrendChart.Series["Value"].Points.Add(cTrendValuePoint);
                }

                grdRangeOver.DataSource = m_cAbnormalNodeS;
                grdRangeOver.RefreshDataSource();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                if(m_cNodeS != null)
                    m_cNodeS.Clear();

                m_cNodeS = null;
                m_cDevice = null;
                m_cLogS = null;

                m_cAbnormalNodeS.Clear();

                ClearView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ClearView()
        {
            try
            {
                exChart.Series["Value"].Points.Clear();
                exChart.Series["Upper"].Points.Clear();
                exChart.Series["Lower"].Points.Clear();
                exChart.Series["Avr"].Points.Clear();

                exTrendChart.Series["Value"].Points.Clear();
                exTrendChart.Series["Upper"].Points.Clear();
                exTrendChart.Series["Lower"].Points.Clear();

                txtMax.Text = "";
                txtMin.Text = "";
                txtAverage.Text = "";
                txtCurValue.Text = "";
                dtpkDateTime.EditValue = DateTime.MinValue;
                txtUpper.Text = "";
                txtLower.Text = "";

                grdRangeOver.DataSource = null;
                grdRangeOver.RefreshDataSource();

                grdBarData.DataSource = null;
                grdBarData.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void InitComponent()
        {
            try
            {
                if (m_cDevice == null)
                    return;

                ClearView();

                txtAddress.Text = m_cDevice.Address;
                txtDesc.Text = m_cDevice.Name;

                txtUpper.Text = Math.Round(m_cDevice.UpperBound, 2).ToString();
                txtLower.Text = Math.Round(m_cDevice.LowerBound, 2).ToString();

                SetTimeNodeS();
                SetChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvBarData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void UCXBarRChart_Load(object sender, EventArgs e)
        {
            try
            {
                //InitComponent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            try
            {
                foreach (CrosshairElement element in e.CrosshairElements)
                {
                    SeriesPoint exPoint = element.SeriesPoint;
                    element.LabelElement.Text = exPoint.ToolTipHint;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ChartHitInfo hitinfo = this.exChart.CalcHitInfo(e.Location);

                if (hitinfo.InSeries)
                {
                    SeriesPoint cPoint = hitinfo.SeriesPoint;

                    if (cPoint == null || cPoint.Tag == null || cPoint.Tag.GetType() != typeof(CTimeNode))
                        return;

                    CTimeNode cNode = (CTimeNode)cPoint.Tag;

                    txtCurValue.Text = cNode.Value.ToString();
                    dtpkDateTime.EditValue = cNode.Start;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnApplyUpper_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUpper.EditValue == null)
                    return;

                string sValue = txtUpper.EditValue.ToString();
                double dValue = Convert.ToDouble(sValue);

                if (dValue == 0)
                    return;

                m_cDevice.UpperBound = dValue;

                exChart.Series["Upper"].Points.Clear();
                exChart.Series["Lower"].Points.Clear();
                exTrendChart.Series["Upper"].Points.Clear();
                exTrendChart.Series["Lower"].Points.Clear();

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    SetChart();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnApplyLower_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLower.EditValue == null)
                    return;

                string sValue = txtLower.EditValue.ToString();
                double dValue = Convert.ToDouble(sValue);

                if (dValue == 0)
                    return;

                m_cDevice.LowerBound = dValue;

                exChart.Series["Upper"].Points.Clear();
                exChart.Series["Lower"].Points.Clear();
                exTrendChart.Series["Upper"].Points.Clear();
                exTrendChart.Series["Lower"].Points.Clear();

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    SetChart();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvBarData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //int iRowHandle = grvBarData.FocusedRowHandle;

                //if (iRowHandle < 0)
                //    return;

                //object obj = grvBarData.GetRow(iRowHandle);

                //if (obj == null || obj.GetType() != typeof(CTimeNode))
                //    return;

                //CTimeNode cNode = (CTimeNode)obj;

                //XYDiagram diagram = (XYDiagram) exChart.Diagram;
                //diagram.AxisX.

                //CTimeNode cPointNode = null;
                //foreach (SeriesPoint cPoint in exChart.Series["Value"].Points)
                //{
                //    if (cPoint.Tag == null)
                //        continue;

                //    cPointNode = (CTimeNode) cPoint.Tag;

                //    if (cPointNode == cNode)
                //    {

                //        break;
                //    }
                //}

                ////int iIndex = m_cNodeS.IndexOf(cNode);
                ////SeriesPoint cPoint = exChart.Series["Value"].Points.Where(x => x.Data)

                ////XYDiagram diagram = (XYDiagram)exChart.Diagram;
                ////diagram.ScrollingOptions.
                //////exChart.Series["Value"].Points.Where()

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grdRangeOver_DoubleClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                {
                    InitComponent();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuDeleteBar_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cNodeS == null || m_cNodeS.Count == 0)
                    return;

                int[] arrRow = grvBarData.GetSelectedRows();

                if (arrRow == null || arrRow.Length == 0)
                    return;

                CTimeNode cNode = null;
                object obj = null;
                foreach (int iRowHandle in arrRow)
                {
                    obj = grvBarData.GetRow(iRowHandle);

                    if (obj == null || obj.GetType() != typeof (CTimeNode))
                        continue;

                    cNode = (CTimeNode) obj;
                    m_cNodeS.Remove(cNode);
                }

                grdBarData.RefreshDataSource();
                grvBarData.FocusedRowHandle = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void spnRange_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal nMaxValue = spnRange.Value;

                XYDiagram diagram = (XYDiagram) exChart.Diagram;
                diagram.AxisX.VisualRange.MaxValue = nMaxValue;
                exChart.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTrendChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            try
            {
                foreach (CrosshairElement element in e.CrosshairElements)
                {
                    SeriesPoint exPoint = element.SeriesPoint;
                    element.LabelElement.Text = exPoint.ToolTipHint;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvRangeOver_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                var View = sender as GridView;

                if (e.RowHandle < 0)
                    return;

                if (e.Column == colValue)
                {
                    int iValue = (int)View.GetRowCellValue(e.RowHandle, colValue);

                    if (iValue > m_cDevice.UpperBound)
                        e.Appearance.ForeColor = Color.Red;
                    else if (iValue < m_cDevice.LowerBound)
                        e.Appearance.ForeColor = Color.Gold;
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
