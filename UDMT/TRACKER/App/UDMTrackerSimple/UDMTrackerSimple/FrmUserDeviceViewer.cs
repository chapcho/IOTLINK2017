using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using UDM.General.Statistics;
using UDM.Log;
using UDM.Log.DB;
using UDM.UI.TimeChart;

namespace UDMTrackerSimple
{
    public partial class FrmUserDeviceViewer : DevExpress.XtraEditors.XtraForm
    {
        private CUserDeviceS m_cUserDeviceS = null;
        private CMySqlLogReader m_cReader = null;
        private bool m_bVerify = false;

        private CUserDevice m_cDeviceCur = null;
        private CTimeLogS m_cTimeLogS = null;
        private CTimeLogS m_cAbnormalLogS = new CTimeLogS();

        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;

        public FrmUserDeviceViewer()
        {
            InitializeComponent();

            m_cUserDeviceS = CMultiProject.UserDeviceS;
            m_cReader = CMultiProject.LogReader;
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void VerifyUserParameter()
        {
            if (m_cUserDeviceS == null || m_cUserDeviceS.Count == 0)
            {
                MessageBox.Show("지정한 User Device가 존재하지 않습니다. 화면을 닫습니다.", "Warning!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                m_bVerify = false;
            }
            else
                m_bVerify = true;
        }

        private void InitTimeRange()
        {
            m_dtTo = CMultiProject.LogReader.GetLastTimeLogTime();

            if (m_dtTo == DateTime.MinValue)
            {
                m_dtFrom = DateTime.MinValue;
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;
            }
            else
            {
                m_dtFrom = m_dtTo.AddMinutes(-30);

                dtpkFrom.EditValue = m_dtFrom;
                dtpkTo.EditValue = m_dtTo;
            }
        }

        private void ShowUserLogTable()
        {
            grdUserLog.DataSource = null;
            grdUserLog.DataSource = m_cUserDeviceS.Values;
            grdUserLog.RefreshDataSource();
        }

        private void ShowUserTrendTable()
        {
            grdUserTrend.DataSource = null;
            grdUserTrend.DataSource = m_cUserDeviceS.Values.Where(x => x.DataType != EMDataType.Bool).ToList();
            grdUserTrend.RefreshDataSource();
        }

        private void InitLogChart()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesItem", "Item");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMin", "Min");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMax", "Max");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesColor", "Color");
            cColumn.IsReadOnly = false;
            cColumn.Editor = exEditorColor;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesScale", "Scale");
            cColumn.IsReadOnly = false;
            ucChart.SeriesTree.ColumnS.Add(cColumn);
        }

        private void TrendClear()
        {
            exChart.Series["Value"].Points.Clear();
            exChart.Series["Upper"].Points.Clear();
            exChart.Series["Lower"].Points.Clear();
            exChart.Series["Min"].Points.Clear();
            exChart.Series["Max"].Points.Clear();
            exChart.Series["Avr"].Points.Clear();

            chkMin.Checked = false;
            chkMax.Checked = false;
            chkAvr.Checked = false;

            txtMax.Text = "";
            txtMin.Text = "";
            txtAverage.Text = "";
            txtCurValue.Text = "";
            txtUpper.Text = "";
            txtLower.Text = "";
            txtUpperValue.Text = "";

            grdAbnormal.DataSource = null;
        }

        private Color GetColor()
        {
            Random rand = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[rand.Next(names.Length)];
            Color randColor = Color.FromKnownColor(randomColorName);

            return randColor;
        }

        private void ShowLogChart(List<CUserDevice> cDeviceS)
        {
            DateTime dtFirstVisible = DateTime.MinValue;
            DateTime dtTemp = DateTime.MinValue;

            ucChart.Clear();

            ucChart.BeginUpdate();
            {
                CUserDevice cDevice = null;

                for (int i = 0; i < cDeviceS.Count; i++)
                {
                    cDevice = cDeviceS[i];

                    if (cDevice.Tag.DataType == EMDataType.Bool)
                        dtTemp = CreateGanttChartItem(cDevice);
                    else if (cDevice.Tag.DataType == EMDataType.DWord || cDevice.Tag.DataType == EMDataType.Word)
                        dtTemp = CreateSeriesChartItem(cDevice);
                    else
                        continue;

                    if (dtFirstVisible == DateTime.MinValue)
                        dtFirstVisible = dtTemp;
                    else if (dtFirstVisible > dtTemp)
                        dtFirstVisible = dtTemp;
                }

                ucChart.TimeLine.RangeFrom = m_dtFrom;
                ucChart.TimeLine.RangeTo = m_dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = m_dtFrom;
            }
            ucChart.EndUpdate();
        }

        private DateTime CreateGanttChartItem(CUserDevice cDevice)
        {
            DateTime dtFirstTime = DateTime.MinValue;

            CGanttItem cItem = null;
            List<CGanttBar> lstBar = null;
            CTimeNodeS cNodeS = null;
            CTimeLogS cLogS = null;

            cItem = new CGanttItem(new object[] { cDevice.Tag.Address, cDevice.Tag.Description });
            cItem.Data = cDevice;

            cLogS = m_cReader.GetTimeLogS(cDevice.Tag.Key, m_dtFrom, m_dtTo);

            if (cLogS != null)
            {
                if (cLogS.Count < 2) return DateTime.MinValue;

                List<CTimeLog> cOnLogS = cLogS.Where(x => x.Value == 1).ToList();
                if (cOnLogS == null || cOnLogS.Count == 0) return DateTime.MinValue;

                List<CTimeLog> cOffLogS = cLogS.Where(x => x.Value == 0).ToList();
                if (cOffLogS == null || cOffLogS.Count == 0) return DateTime.MinValue;

                cLogS.UpdateTimeRange();

                dtFirstTime = cLogS.FirstTime;

                cNodeS = new CTimeNodeS(cDevice.Tag, cLogS, m_dtFrom, m_dtTo);
                if (cNodeS == null)
                    cNodeS = new CTimeNodeS();
            }
            else
                cNodeS = new CTimeNodeS();

            lstBar = CreateBarList(cNodeS, Color.DodgerBlue);
            cItem.BarS.AddRange(lstBar);

            ucChart.GanttTree.ItemS.Add(cItem);

            lstBar.Clear();
            lstBar = null;

            return dtFirstTime;
        }

        private List<CGanttBar> CreateBarList(CTimeNodeS cNodeS, Color cColor)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cNodeS.Count; i++)
            {
                cNode = cNodeS[i];
                cBar = CreateBar(cNode, cColor);
                lstBar.Add(cBar);
            }

            return lstBar;
        }

        private CGanttBar CreateBar(CTimeNode cNode, Color cColor)
        {
            CGanttBar cBar = new CGanttBar();
            cBar.StartTime = cNode.Start;
            cBar.EndTime = cNode.End;
            cBar.Data = cNode;
            cBar.Color = cColor;

            return cBar;
        }

        private DateTime CreateSeriesChartItem(CUserDevice cDevice)
        {
            DateTime dtFirstTime = DateTime.MinValue;

            CSeriesItem cItem;
            CTimeLogS cLogS;
            CTimeLog cLog;
            CSeriesPoint cPoint;
            float nMax = -1;
            float nMin = -1;
            float nAxisMax = ucChart.SeriesChart.Axis.Maximum;
            float nAxisMin = ucChart.SeriesChart.Axis.Minimumn;

            cItem = new CSeriesItem(null);
            cLogS = m_cReader.GetTimeLogS(cDevice.Tag.Key, m_dtFrom, m_dtTo);

            if (cLogS == null || cLogS.Count == 0)
                return DateTime.MinValue;

            cItem.Color = GetColor();
            for (int j = 0; j < cLogS.Count; j++)
            {
                cLog = cLogS[j];

                if (j == 0)
                {
                    dtFirstTime = cLog.Time;

                    nMax = cLog.Value;
                    nMin = cLog.Value;
                }
                else if (cLog.Value > nMax)
                    nMax = cLog.Value;
                else if (nMin > cLog.Value)
                    nMin = cLog.Value;

                if (cLog.Value > nAxisMax)
                    nAxisMax = cLog.Value;
                else if (cLog.Value < nAxisMin)
                    nAxisMin = cLog.Value;

                cPoint = new CSeriesPoint(cLog.Time, cLog.Value);
                cPoint.Data = cLog.Value;
                cItem.PointS.Add(cPoint);
            }
            cItem.Values = new object[] { cDevice.Tag.Key, cDevice.Tag.Description, nMin, nMax, cItem.Color, 1f };

            ucChart.SeriesTree.ItemS.Add(cItem);

            ucChart.SeriesChart.Axis.Maximum = nAxisMax;
            ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

            cLogS.Clear();


            return dtFirstTime;
        }

        private void ShowTrendChart(CUserDevice cDevice)
        {
            TrendClear();
            m_cAbnormalLogS.Clear();

            m_cDeviceCur = cDevice;

            SeriesPoint cValuePoint;
            SeriesPoint cUpperPoint;
            SeriesPoint cLowerPoint;
            CTimeLog cLog;

            List<double> lstValue = new List<double>();

            CTimeLogS cLogS = m_cReader.GetTimeLogS(cDevice.Tag.Key, m_dtFrom, m_dtTo);

            if (cLogS != null)
            {
                cLogS.UpdateTimeRange();
                m_cTimeLogS = cLogS;

                for (int i = 0; i < cLogS.Count; i++)
                {
                    cLog = cLogS[i];
                    lstValue.Add(cLog.Value);

                    if (i == 0)
                        dtpkFromWhole.EditValue = cLog.Time;
                    else if (i == cLogS.Count - 1)
                        dtpkToWhole.EditValue = cLog.Time;

                    cUpperPoint = new SeriesPoint(i + 1, new double[] {cDevice.UpperBound});
                    cLowerPoint = new SeriesPoint(i + 1, new double[] { cDevice.LowerBound });
                    cValuePoint = new SeriesPoint(i + 1, new double[] { cLog.Value });
                    cValuePoint.Tag = cLog;

                    if(cLog.Value > cDevice.UpperBound)
                    { 
                        cValuePoint.Color = Color.Red;
                        cValuePoint.ToolTipHint = "Time : " + cLog.Time + "\r\nValue : " + cLog.Value +
                                                  "\r\nOver Value : " + (cLog.Value - cDevice.UpperBound).ToString();
                        m_cAbnormalLogS.Add(cLog);
                    }
                    else if (cLog.Value < cDevice.LowerBound)
                    {
                        cValuePoint.Color = Color.Red;
                        cValuePoint.ToolTipHint = "Time : " + cLog.Time + "\r\nValue : " + cLog.Value +
                                                  "\r\nUnder Value : " + (cDevice.LowerBound - cLog.Value).ToString();
                    }
                    else
                    {
                        cValuePoint.Color = Color.Blue;
                        cValuePoint.ToolTipHint = "Time : " + cLog.Time + "\r\nValue : " + cLog.Value;
                    }

                    cUpperPoint.ToolTipHint = "UpperValue : " + cDevice.UpperBound;
                    cLowerPoint.ToolTipHint = "LowerValue : " + cDevice.LowerBound;

                    exChart.Series["Value"].Points.Add(cValuePoint);
                    exChart.Series["Upper"].Points.Add(cUpperPoint);
                    exChart.Series["Lower"].Points.Add(cLowerPoint);
                }

                if (lstValue.Count == 0)
                    return;

                cDevice.Min = lstValue.Min();
                cDevice.Max = lstValue.Max();
                cDevice.Average = CStatics.Mean(lstValue);

                txtMin.Text = cDevice.Min.ToString();
                txtMax.Text = cDevice.Max.ToString();
                txtAverage.Text = cDevice.Average.ToString();

                txtUpper.Text = cDevice.UpperBound.ToString();
                txtLower.Text = cDevice.LowerBound.ToString();

                ShowAbnormalGrid();
            }
        }

        private void ShowAbnormalGrid()
        {
            if (m_cAbnormalLogS == null || m_cAbnormalLogS.Count == 0)
                return;

            grdAbnormal.DataSource = null;
            grdAbnormal.DataSource = m_cAbnormalLogS;
            grdAbnormal.RefreshDataSource();

            txtUpperValue.Text = m_cDeviceCur.UpperBound.ToString();
        }

        private void RegisterTimeChartEventS()
        {
            ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
        }

        private void FrmUserDeviceViewer_Load(object sender, EventArgs e)
        {
            bool bOK = VerifyParameter();
            if (!bOK)
            {
                this.Close();
                return;
            }

            VerifyUserParameter();

            if(!m_bVerify)
                this.Close();

            RegisterTimeChartEventS();
            InitTimeRange();
            InitLogChart();
            ShowUserLogTable();
            ShowUserTrendTable();
        }

        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            if (cCol.Name == "colSeriesScale")
            {
                float nScale = 1f;
                bool bOK = float.TryParse(oValue.ToString(), out nScale);
                CSeriesItem cItem = (CSeriesItem)cRow;
                CSeriesPoint cPoint;
                for (int i = 0; i < cItem.PointS.Count; i++)
                {
                    cPoint = cItem.PointS[i];
                    cPoint.Value = (float)cPoint.Data * nScale;
                }

                ucChart.SeriesTree.UpdateLayout();
            }
            else if (cCol.Name == "colSeriesColor")
            {
                CSeriesItem cItem = (CSeriesItem)cRow;

                cItem.Color = (Color)oValue;
                ucChart.SeriesTree.UpdateLayout();
            }
        }

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {

        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
            {

                ucChart.TimeLine.TimeIndicatorS.Clear();
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan =
                    ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();

                ucChart.TimeLine.UpdateLayout();
            }
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucChart.TimeLine.TimeIndicatorS.Count == 0) return;
            else if (ucChart.TimeLine.TimeIndicatorS.Count == 1)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            else
            {
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);

            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucChart.TimeLine.UpdateLayout();

            if (ucChart.TimeLine.TimeIndicatorS.Count > 0)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
            {
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
            else
            {
                txtInterval.Text = "0";
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_dtFrom = (DateTime) dtpkFrom.EditValue;
            m_dtTo = (DateTime) dtpkTo.EditValue;
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabTable.SelectedTabPageIndex == 0)
            {
                List<CUserDevice> cUserDeviceS = new List<CUserDevice>();

                int[] iaRowIndex = grvUserLog.GetSelectedRows();

                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CUserDevice cDevice = (CUserDevice) grvUserLog.GetRow(iaRowIndex[i]);
                        cUserDeviceS.Add(cDevice);
                    }

                    SplashScreenManager.ShowDefaultWaitForm();
                    {
                        ShowLogChart(cUserDeviceS);
                    }
                    SplashScreenManager.CloseDefaultWaitForm();
                }
            }
            else
                grvUserTrend_DoubleClick(null, null);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabTable.SelectedTabPageIndex == 0)
                ucChart.Clear();
            else
                TrendClear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(tabTable.SelectedTabPageIndex == 0)
                ucChart.TimeLine.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabTable.SelectedTabPageIndex == 0)
                ucChart.TimeLine.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabTable.SelectedTabPageIndex == 0)
            {
                List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
                if (lstItem == null || lstItem.Count == 0)
                    return;

                ucChart.GanttTree.ItemUp(lstItem);
                lstItem.Clear();
            }
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tabTable.SelectedTabPageIndex == 0)
            {
                List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
                if (lstItem == null || lstItem.Count == 0)
                    return;

                ucChart.GanttTree.ItemDown(lstItem);
                lstItem.Clear();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grvUserTrend_DoubleClick(object sender, EventArgs e)
        {
            CUserDevice cDevice;

            int[] iaRowIndex = grvUserTrend.GetSelectedRows();

            if (iaRowIndex != null)
            {
                cDevice = (CUserDevice)grvUserTrend.GetRow(iaRowIndex[0]);

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    ShowTrendChart(cDevice);
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }

        private void chkMax_CheckedChanged(object sender, EventArgs e)
        {
            if (m_cDeviceCur == null || m_cTimeLogS == null || m_cTimeLogS.Count == 0)
                return;

            if (chkMax.Checked)
            {
                exChart.Series["Max"].Visible = true;

                CTimeLog cLog;
                SeriesPoint cPoint;

                for (int i = 0; i < m_cTimeLogS.Count; i++)
                {
                    cLog = m_cTimeLogS[i];
                    cPoint = new SeriesPoint(i + 1, new double[] { m_cDeviceCur.Max });
                    cPoint.ToolTipHint = "Max : " + m_cDeviceCur.Max.ToString();

                    exChart.Series["Max"].Points.Add(cPoint);
                }
            }
            else
                exChart.Series["Max"].Visible = false;
        }

        private void chkAvr_CheckedChanged(object sender, EventArgs e)
        {
            if (m_cDeviceCur == null || m_cTimeLogS == null || m_cTimeLogS.Count == 0)
                return;

            if (chkAvr.Checked)
            {
                exChart.Series["Avr"].Visible = true;

                CTimeLog cLog;
                SeriesPoint cPoint;

                for (int i = 0; i < m_cTimeLogS.Count; i++)
                {
                    cLog = m_cTimeLogS[i];
                    cPoint = new SeriesPoint(i + 1, new double[] { m_cDeviceCur.Average });
                    cPoint.ToolTipHint = "Average : " + m_cDeviceCur.Average.ToString();

                    exChart.Series["Avr"].Points.Add(cPoint);
                }
            }
            else
                exChart.Series["Avr"].Visible = false;
        }

        private void chkMin_CheckedChanged(object sender, EventArgs e)
        {
            if (m_cDeviceCur == null || m_cTimeLogS == null || m_cTimeLogS.Count == 0)
                return;

            if (chkMin.Checked)
            {
                exChart.Series["Min"].Visible = true;

                CTimeLog cLog;
                SeriesPoint cPoint;

                for (int i = 0; i < m_cTimeLogS.Count; i++)
                {
                    cLog = m_cTimeLogS[i];
                    cPoint = new SeriesPoint(i + 1, new double[] { m_cDeviceCur.Min });
                    cPoint.ToolTipHint = "Min : " + m_cDeviceCur.Min.ToString();

                    exChart.Series["Min"].Points.Add(cPoint);
                }
            }
            else
                exChart.Series["Min"].Visible = false;
        }

        private void btnApplyUpper_Click(object sender, EventArgs e)
        {
            if (txtUpper.EditValue == null)
                return;

            string sValue = txtUpper.EditValue.ToString();
            double dValue = Convert.ToDouble(sValue);

            m_cDeviceCur.UpperBound = dValue;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                grdUserTrend.RefreshDataSource();
                ShowTrendChart(m_cDeviceCur);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnApplyLower_Click(object sender, EventArgs e)
        {
            if (txtLower.EditValue == null)
                return;

            string sValue = txtLower.EditValue.ToString();
            double dValue = Convert.ToDouble(sValue);

            m_cDeviceCur.LowerBound = dValue;

            SplashScreenManager.ShowDefaultWaitForm();
            {
            grdUserTrend.RefreshDataSource();
            ShowTrendChart(m_cDeviceCur);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void exChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void exChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hitinfo = this.exChart.CalcHitInfo(e.Location);

            if (hitinfo.InSeries)
            {
                SeriesPoint cPoint = hitinfo.SeriesPoint;

                if (cPoint == null || cPoint.Tag == null || cPoint.Tag.GetType() != typeof(CTimeLog))
                    return;

                CTimeLog cLog = (CTimeLog) cPoint.Tag;

                if (cLog.Value < m_cDeviceCur.UpperBound)
                    return;

                FrmDeviceDetailViewer frmView = new FrmDeviceDetailViewer();
                frmView.Time = cLog.Time;
                frmView.Show();
            }
        }
    }
}