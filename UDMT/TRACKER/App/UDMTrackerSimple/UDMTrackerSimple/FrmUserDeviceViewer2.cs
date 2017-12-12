using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using TrackerCommon;
using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.UI.TimeChart;

namespace UDMTrackerSimple
{
    public partial class FrmUserDeviceViewer2 : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bVerified = false;
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private CMySqlLogReader m_cReader = null;
        private Dictionary<string, CTimeLogS> m_dicDeviceLogS = new Dictionary<string, CTimeLogS>(); 
        private Dictionary<string, bool> m_dicTabPage = new Dictionary<string, bool>(); 

        public FrmUserDeviceViewer2()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                XtraMessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                XtraMessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMultiProject.UserDeviceS == null || CMultiProject.UserDeviceS.Count == 0)
            {
                XtraMessageBox.Show("UserDevice Not Exist!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SetTimeRange()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
                dtLast = DateTime.Now;

            dtpkFrom.EditValue = (DateTime) dtLast.AddMinutes(-30);
            dtpkTo.EditValue = (DateTime) dtLast;
        }

        private void ClearView()
        {
            m_dicDeviceLogS.Clear();
            ClearGanttChart();
            ClearXbarRChart();
        }

        private void ClearGanttChart()
        {
            ucChart.Clear();

            txtWordValue.EditValue = null;
            txtInterval.EditValue = 0;

            dtpkIndicator1.EditValue = DateTime.MinValue;
            dtpkIndicator2.EditValue = DateTime.MinValue;
        }

        private void ClearXbarRChart()
        {
            UCXBarRChart ucXbarRChart = null;
            foreach (XtraTabPage tpPage in tabBarChart.TabPages)
            {
                if (tpPage.Controls.Count == 0)
                    continue;

                ucXbarRChart = (UCXBarRChart)tpPage.Controls[0];
                ucXbarRChart.Clear();

                ucXbarRChart.Dispose();
            }

            m_dicTabPage.Clear();
            tabBarChart.TabPages.Clear();
        }

        private void SetDeviceGrid()
        {
            try
            {
                ClearView();

                //CTimeLogS cLogS = null;
                CUserDevice cDevice = null;
                foreach(var who in CMultiProject.UserDeviceS)
                {
                    cDevice = who.Value;
                    //cLogS = m_cReader.GetTimeLogS(who.Key, m_dtFrom, m_dtTo);

                    //if (cLogS == null || cLogS.Count == 0)
                    //{
                        cDevice.ChangeCount = 0;
                        cDevice.LastTime = DateTime.MinValue;
                    //}
                    //else
                    //{
                    //    cDevice.ChangeCount = cLogS.Count;
                    //    cDevice.LastTime = cLogS.Last().Time;
                    //}

                    m_dicDeviceLogS.Add(who.Key, null);
                }

                grdDevice.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                grdDevice.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetDeviceGrid(List<string> lstDeviceKey)
        {
            try
            {
                CTimeLogS cLogS = null;
                CUserDevice cDevice = null;
                foreach (var who in CMultiProject.UserDeviceS)
                {
                    if (!lstDeviceKey.Contains(who.Key) || !m_dicDeviceLogS.ContainsKey(who.Key))
                        continue;

                    cDevice = who.Value;
                    cLogS = m_cReader.GetTimeLogS(who.Key, m_dtFrom, m_dtTo);

                    if (cLogS != null && cLogS.Count > 0)
                    {
                        cDevice.ChangeCount = cLogS.Count;
                        cDevice.LastTime = cLogS.Last().Time;
                    }

                    //if(m_dicDeviceLogS[who.Key] != null && m_dicDeviceLogS[who.Key].Count > 0)
                    //    m_dicDeviceLogS[who.Key].Clear();

                    m_dicDeviceLogS[who.Key] = null;
                    m_dicDeviceLogS[who.Key] = cLogS;
                }

                grdDevice.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                grdDevice.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void InitChart()
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

        private void RegisterTimeChartEventS()
        {
            ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
        }

        private Color GetColor()
        {
            Random rand = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[rand.Next(names.Length)];
            Color randColor = Color.FromKnownColor(randomColorName);

            return randColor;
        }

        private CGanttItem CreateGanttItem(CUserDevice cDevice)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cDevice.Address, cDevice.Name });
            cItem.Data = cDevice;

            return cItem;
        }

        private List<CGanttBar> CreateBarList(CTimeNodeS cNodeS, Color cColor, bool bShowBarText)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cNodeS.Count; i++)
            {
                cNode = cNodeS[i];
                cBar = CreateBar(cNode, cColor);
                if (bShowBarText)
                    cBar.Text = cNode.Value.ToString();
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
            cBar.Height = 16;

            return cBar;
        }

        private bool IsAlreadyExist(CUserDevice cDevice)
        {
            bool bOK = false;

            CRowItem cItem = ucChart.GanttTree.ItemS.FindHasData(cDevice);

            if (cItem != null)
                bOK = true;

            return bOK;
        }

        private void ShowGanttChart(List<string> lstDeviceKey, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                DateTime dtFirstVisible = DateTime.MinValue;

                ucChart.BeginUpdate();
                {
                    CGanttItem cItem = null;
                    List<CGanttBar> lstBar = null;
                    CTimeNodeS cNodeS = null;
                    CTimeLogS cLogS = null;
                    string sKey = string.Empty;
                    CUserDevice cDevice = null;
                    CTag cTag = null;
                    bool bShowBarText = false;

                    for (int i = 0; i < lstDeviceKey.Count; i++)
                    {
                        sKey = lstDeviceKey[i];
                        cDevice = CMultiProject.UserDeviceS[sKey];

                        if (cDevice.Tag == null)
                            continue;

                        if (IsAlreadyExist(cDevice))
                            continue;

                        cTag = cDevice.Tag;
                        cItem = CreateGanttItem(cDevice);
                        cLogS = m_dicDeviceLogS[cTag.Key];

                        if (cLogS != null)
                        {
                            cLogS.UpdateTimeRange();

                            if (i == 0)
                                dtFirstVisible = cLogS.FirstTime;
                            else
                            {
                                if (dtFirstVisible > cLogS.FirstTime)
                                    dtFirstVisible = cLogS.FirstTime;
                            }

                            cNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                            if (cNodeS == null)
                                cNodeS = new CTimeNodeS();
                        }
                        else
                            cNodeS = new CTimeNodeS();

                        if (cTag.DataType != EMDataType.Bool)
                            bShowBarText = true;

                        lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                        cItem.BarS.AddRange(lstBar);

                        ucChart.GanttTree.ItemS.Add(cItem);

                        lstBar.Clear();
                        lstBar = null;
                    }

                    ucChart.TimeLine.RangeFrom = dtFrom;
                    ucChart.TimeLine.RangeTo = dtTo;

                    if (dtFirstVisible != DateTime.MinValue)
                        ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                    else
                        ucChart.TimeLine.FirstVisibleTime = dtFrom;
                }
                ucChart.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ShowSeriesChart(List<string> lstDeviceKey, DateTime dtFrom, DateTime dtTo)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CSeriesItem cItem;
                CTimeLogS cLogS;
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                float nAxisMax = 0f;
                float nAxisMin = 0f;
                CUserDevice cDevice = null;
                foreach (string sKey in lstDeviceKey)
                {
                    nMax = -1;
                    nMax = -1;

                    cDevice = CMultiProject.UserDeviceS[sKey];

                    if (cDevice.Tag == null || cDevice.Tag.DataType == EMDataType.Bool)
                        continue;

                    cItem = new CSeriesItem(null);
                    cLogS = m_dicDeviceLogS[sKey];

                    cItem.Color = GetColor();
                    for (int j = 0; j < cLogS.Count; j++)
                    {
                        cLog = cLogS[j];

                        if (j == 0)
                        {
                            dtFirstVisible = cLog.Time;

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
                    cItem.Values = new object[] { sKey, cDevice.Name, nMin, nMax, cItem.Color, 1f };

                    ucChart.SeriesTree.ItemS.Add(cItem);

                    //cLogS.Clear();
                }

                ucChart.SeriesChart.Axis.Maximum = nAxisMax;
                ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShowXbarRChart(List<string> lstDeviceKey, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                CUserDevice cDevice = null;
                CTimeLogS cLogS = null;
                UCXBarRChart ucXbarRChart = null;
                XtraTabPage tpPage = null;
                bool bFirst = true;
                foreach (string sKey in lstDeviceKey)
                {
                    cDevice = CMultiProject.UserDeviceS[sKey];
                    cLogS = m_dicDeviceLogS[sKey];

                    if (cLogS.Count == 0)
                        continue;

                    string sCaption = string.Format("{0}/{1}", cDevice.Address, cDevice.Name);

                    tpPage = tabBarChart.TabPages.SingleOrDefault(x => x.Text == sCaption);

                    if (tpPage != null)
                        continue;

                    tpPage = new XtraTabPage();
                    tpPage.Text = sCaption;
                    
                    ucXbarRChart = new UCXBarRChart();
                    ucXbarRChart.Dock = DockStyle.Fill;
                    ucXbarRChart.UserDevice = cDevice;
                    ucXbarRChart.LogS = cLogS;
                    ucXbarRChart.From = dtFrom;
                    ucXbarRChart.To = dtTo;

                    if (bFirst)
                    {
                        ucXbarRChart.InitComponent();
                        bFirst = false;
                        m_dicTabPage.Add(sCaption, true);
                    }
                    else
                        m_dicTabPage.Add(sCaption, false);

                    tpPage.Controls.Add(ucXbarRChart);
                    tabBarChart.TabPages.Add(tpPage);
                }

                cLogS = null;
                ucXbarRChart = null;
                tpPage = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            try
            {
                if (cCol.Name == "colSeriesScale")
                {
                    float nScale = 1f;
                    bool bOK = float.TryParse(oValue.ToString(), out nScale);
                    CSeriesItem cItem = (CSeriesItem) cRow;
                    CSeriesPoint cPoint;
                    for (int i = 0; i < cItem.PointS.Count; i++)
                    {
                        cPoint = cItem.PointS[i];
                        cPoint.Value = Convert.ToSingle(cPoint.Data) * nScale;
                    }

                    ucChart.SeriesTree.UpdateLayout();
                }
                else if (cCol.Name == "colSeriesColor")
                {
                    CSeriesItem cItem = (CSeriesItem) cRow;

                    cItem.Color = (Color) oValue;
                    ucChart.SeriesTree.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
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

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            txtWordValue.Text = "";
            txtWordValue.Text = cBar.Text;
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

        private void grvDevice_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void FrmUserDeviceViewer2_Load(object sender, EventArgs e)
        {
            try
            {
                m_bVerified = VerifyParameter();

                if (!m_bVerified)
                    return;

                SetTimeRange();
                InitChart();
                RegisterTimeChartEventS();

                grdDevice.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                grdDevice.RefreshDataSource();

                ucChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
                ucChart.SeriesTree.ContextMenuStrip = cntxSeriesTreeMenu;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                m_dtFrom = (DateTime) dtpkFrom.EditValue;
                m_dtTo = (DateTime) dtpkTo.EditValue;

                if (m_dtFrom > m_dtTo)
                {
                    XtraMessageBox.Show("기간 설정이 잘못되었습니다.\r\n기간설정을 다시 진행해주세요!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                XtraMessageBox.Show(
                    "User Device수가 많을수록, 설정하신 기간이 길수록 LOG DATA를 불러오는데 시간이 오래 걸립니다.\r\n아래의 User Device를 선택하여 Show하면 해당 기간 동안의 LOG DATA를 불러옵니다.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    SetDeviceGrid();
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                foreach (var who in CMultiProject.UserDeviceS)
                {
                    who.Value.ChangeCount = 0;
                    who.Value.LastTime = DateTime.MinValue;
                }

                grdDevice.RefreshDataSource();

                ClearView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grvDevice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!m_bVerified || m_dicDeviceLogS.Count == 0)
                    return;

                int[] arrRow = grvDevice.GetSelectedRows();

                if (arrRow == null || arrRow.Length < 1)
                {
                    XtraMessageBox.Show("User Device List에서 User Device를 먼저 선택해주세요!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                List<string> lstDeviceKey = new List<string>();
                CUserDevice cDevice = null;
                object obj = null;
                foreach (int iRowHandle in arrRow)
                {
                    obj = grvDevice.GetRow(iRowHandle);

                    if (obj == null || obj.GetType() != typeof (CUserDevice))
                        continue;

                    cDevice = (CUserDevice) obj;

                    if (cDevice.Tag == null)
                        continue;

                    lstDeviceKey.Add(cDevice.Tag.Key);
                }

                if (lstDeviceKey.Count == 0)
                    return;

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    SetDeviceGrid(lstDeviceKey);
                    ShowGanttChart(lstDeviceKey, m_dtFrom, m_dtTo);
                    ShowXbarRChart(lstDeviceKey, m_dtFrom , m_dtTo);

                    tabChart.SelectedTabPage = tpBar;
                }
                SplashScreenManager.CloseForm(false);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnChartClear_Click(object sender, EventArgs e)
        {
            if (!m_bVerified)
                return;

            ClearGanttChart();
        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                List<CRowItem> lstSelectItem = ucChart.SeriesTree.GetSelectedItemList();

                foreach (CRowItem item in lstSelectItem)
                    ucChart.SeriesTree.ItemS.Remove(item);
                ucChart.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuSeriesChartView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                List<string> lstDeviceKey = new List<string>();
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                CUserDevice cDevice = null;
                foreach (CRowItem cItem in lstSelectItem)
                {
                    cDevice = (CUserDevice) cItem.Data;

                    if (cDevice.Tag == null)
                        continue;

                    if (cDevice.Tag.DataType == EMDataType.Bool)
                        continue;

                    if (!lstDeviceKey.Contains(cDevice.Tag.Key))
                        lstDeviceKey.Add(cDevice.Tag.Key);
                }

                if (lstDeviceKey.Count == 0)
                    return;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    ShowSeriesChart(lstDeviceKey, m_dtFrom, m_dtTo);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
                foreach (CRowItem item in lstSelectItem)
                    ucChart.GanttTree.ItemS.Remove(item);
                ucChart.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnChartShow_Click(object sender, EventArgs e)
        {
            grvDevice_DoubleClick(null, null);
        }

        private void btnLogTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bVerified)
                    return;

                if (m_dicDeviceLogS.Count == 0)
                {
                    XtraMessageBox.Show("기간 설정 후 Refresh 버튼을 먼저 눌러주세요!!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                CTimeLogS cTotalLogS = new CTimeLogS();
                foreach(CTimeLogS cLogS in m_dicDeviceLogS.Values)
                {
                    if(cLogS.Count > 0)
                        cTotalLogS.AddRange(cLogS);
                }

                if (cTotalLogS.Count == 0)
                {
                    XtraMessageBox.Show("해당 기간 내의 Time Log가 존재하지 않습니다.\r\n설정된 기간을 확인해주세요!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmLogTable frmLog = new FrmLogTable();
                frmLog.LogS = cTotalLogS;
                frmLog.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmUserDeviceViewer2_FormClosed(object sender, FormClosedEventArgs e)
        {

            foreach (var who in CMultiProject.UserDeviceS)
            {
                who.Value.ChangeCount = 0;
                who.Value.LastTime = DateTime.MinValue;
            }
        }

        private void btnMoveTimeLine_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtMove = (DateTime) dtpkMoveTo.EditValue;

                if (m_dtFrom > dtMove || m_dtTo < dtMove)
                {
                    XtraMessageBox.Show("Range 영역대에 포함되지 않는 기간입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ucChart.TimeLine.FirstVisibleTime = dtMove;
                ucChart.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkHideList_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkHideList.Checked)
            {
                grpDevice.Visible = true;
            }
            else
            {
                grpDevice.Visible = false;
            }
        }

        private void btnHideList_Click(object sender, EventArgs e)
        {
            chkHideList.Checked = false;
        }

        private void tabBarChart_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page == null)
                    return;

                if (m_dicTabPage.ContainsKey(e.Page.Text))
                {
                    if (m_dicTabPage[e.Page.Text]) return;
                }
                else
                    return;

                m_dicTabPage[e.Page.Text] = true;
                UCXBarRChart ucXBarRChart = (UCXBarRChart) e.Page.Controls[0];
             
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    ucXBarRChart.InitComponent();
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvDevice_DoubleClick(null, null);
        }


    }
}