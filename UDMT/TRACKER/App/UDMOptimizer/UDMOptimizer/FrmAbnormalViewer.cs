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
using UDM.Common;
using UDM.General.Statistics;
using UDM.Log;
using UDM.Log.DB;
using System.Globalization;
using UDMOptimizer;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmAbnormalViewer : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private int m_iChartSplitPos = 0;
        private int m_iMainSplitPos = 0;
        private string m_sProcess = string.Empty;
        private CMySqlLogReader m_cReader = null;
        private CTimeNodeS m_cNodeS = null;
        private DataTable m_tbCycleAllData = null;
        private List<CErrorAnalyzeData> m_lstErrorList = new List<CErrorAnalyzeData>();

        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;

        #endregion

        #region Initialize

        public FrmAbnormalViewer()
        {
            InitializeComponent();
            m_cReader = CMultiProject.LogReader;
        }
        #endregion

        #region Properties
        #endregion

        #region Private Method

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

        private void InitChart()
        {
            exAbnormalChart.Series.Clear();
        }

        private void InitProcess()
        {
            cboProcess.EditValue = null;
            exEditorGroup.Items.Clear();

            foreach (var who in CMultiProject.PlcProcS)
                exEditorGroup.Items.Add(who.Key);

            if (exEditorGroup.Items.Count > 0)
                cboProcess.EditValue = exEditorGroup.Items[0];
        }

        private void InitComponent()
        {
            try
            {
                DateTime dtLast = m_cReader.GetLastTimeLogTime();

                if (dtLast == DateTime.MinValue)
                {
                    dtpkFrom.EditValue = null;
                    dtpkTo.EditValue = null;

                    XtraMessageBox.Show("현재 DB에 로그가 존재하지 않습니다!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dtpkFrom.EditValue = (DateTime)dtLast.AddDays(-2);
                    dtpkTo.EditValue = (DateTime)dtLast;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void ShowTable()
        {
            try
            {
                DataView dv = m_tbCycleAllData.DefaultView;
                dv.Sort = "Start desc";
                DataTable tbSortAbnormal = dv.ToTable();

                grdKey.DataSource = m_tbCycleAllData;
                grdKey.RefreshDataSource();

                grdErrorList.DataSource = m_lstErrorList;
                grdErrorList.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void UpdateChart()
        {
            try
            {
                exAbnormalChart.Series.Clear();

                UpdateAbnormalChart();
                //exAbnormalChart.
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void CreateDataTable()
        {
            m_tbCycleAllData = new DataTable();
            m_tbCycleAllData.Columns.Add("Type");
            m_tbCycleAllData.Columns.Add("AvgOver");
            m_tbCycleAllData.Columns.Add("Symbol");
            m_tbCycleAllData.Columns.Add("Start");
            m_tbCycleAllData.Columns.Add("End");
            m_tbCycleAllData.Columns.Add("Duration");
            m_tbCycleAllData.Columns.Add("RecipeValue");

        }

        private void UpdateAbnormalChart()
        {
            try
            {
                CTimeLogS cLogS = null;
                CTimeNodeS cErrorTotalNodeS = new CTimeNodeS();

                double dProcMaxAVG = 0;

                CreateDataTable();

                //최대 평균 찾기
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    if (cProcess.IsErrorMonitoring) continue;

                    double dAVG = CMultiProject.CycleAnalyDataS[cProcess.Name].CycleAnalyzedData.Average.TotalMilliseconds;
                    if (dAVG > dProcMaxAVG)
                        dProcMaxAVG = dAVG;
                }
                List<CPlcProc> lstErrorProc = CMultiProject.PlcProcS.Values.Where(b => b.IsErrorMonitoring).ToList();

                foreach (CPlcProc cProcess in lstErrorProc)
                {
                    string sKey = cProcess.TotalAbnormalSymbolKey;

                    CTag cAbnormalTag = CMultiProject.TotalTagS[sKey];
                    cLogS = m_cReader.GetTimeLogS(sKey, m_dtFrom, m_dtTo);
                    if (cLogS.Count > 0)
                    {
                        CTimeNodeS cNodeS = new CTimeNodeS(cAbnormalTag, cLogS, m_dtFrom, m_dtTo);
                        cErrorTotalNodeS.AddRange(cNodeS);

                        foreach (CTimeNode cNode in cNodeS)
                        {
                            DataRow dr = m_tbCycleAllData.NewRow();
                            dr["Type"] = "Error";
                            dr["AvgOver"] = false;
                            dr["Symbol"] = cAbnormalTag.Address;
                            dr["Start"] = cNode.Start.ToString("yy.MM.dd HH:mm:ss");
                            dr["End"] = cNode.End.ToString("yy.MM.dd HH:mm:ss");
                            dr["Duration"] = new TimeSpan(0, 0, 0, 0, (int)cNode.Duration).TotalSeconds;
                            dr["RecipeValue"] = "";//cNode.Duration;
                            //m_cNodeS.AddRange(cNodeS);
                            m_tbCycleAllData.Rows.Add(dr);
                        }
                    }
                }

                CCycleAnalyDataList cCycleDataList = CMultiProject.CycleAnalyDataS[m_sProcess];
                string sToolTip = "";
                Series cCycleDurationSeries = new Series("Cycle", ViewType.Bar);
                Series cErrorDurationSeries = new Series("Error", ViewType.Bar);

                for (int i = 0; i < cCycleDataList.Count; i++)
                {
                    double dDuration = 0.0;
                    CCycleAnalyData cCycleData = cCycleDataList[i];
                    sToolTip = string.Format("Type : Cycle\r\nStart Time : {0}\r\nEnd Time : {1}", cCycleData.StartTime, cCycleData.EndTime);
                    dDuration = cCycleData.Duration.TotalSeconds;

                    SeriesPoint cDurationPoint = new SeriesPoint(i, dDuration);
                    cDurationPoint.ToolTipHint = sToolTip;
                    cDurationPoint.Tag = cCycleData;

                    if (cCycleData.IsCycleOver)
                        cDurationPoint.Color = Color.DarkGreen;
                    else
                        cDurationPoint.Color = Color.LimeGreen;

                    cCycleDurationSeries.Points.Add(cDurationPoint);
                    cCycleDurationSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                    DataRow dr = m_tbCycleAllData.NewRow();
                    dr["Type"] = "Cycle";
                    dr["AvgOver"] = cCycleData.IsCycleOver;
                    dr["Symbol"] = CMultiProject.TotalTagS[cCycleData.RecipeKey].Address;
                    dr["Start"] = cCycleData.StartTime.ToString("yy.MM.dd HH:mm:ss");
                    dr["End"] = cCycleData.EndTime.ToString("yy.MM.dd HH:mm:ss");
                    dr["Duration"] = cCycleData.Duration.TotalSeconds;
                    dr["RecipeValue"] = cCycleData.RecipeValue;

                    m_tbCycleAllData.Rows.Add(dr);

                    List<CTimeNode> lstFindTimeNode = cErrorTotalNodeS.FindAll(b => cCycleData.StartTime <= b.Start && cCycleData.EndTime >= b.Start).ToList();
                    SeriesPoint cErrorDurationPoint = null;

                    if (lstFindTimeNode != null && lstFindTimeNode.Count > 0)
                    {
                        //무조건 하나만 찍음.
                        CTimeNode cNode = lstFindTimeNode[0];
                        sToolTip = string.Format("Type : Error\r\nStart : {0}\r\nEnd : {1}", cNode.Start, cNode.End);
                        dDuration = new TimeSpan(0, 0, 0, 0, (int)cNode.Duration).TotalSeconds;
                        cErrorDurationPoint = new SeriesPoint(i, dDuration);
                        cErrorDurationPoint.ToolTipHint = sToolTip;
                        cErrorDurationPoint.Tag = cNode;
                        cErrorDurationPoint.Color = Color.Red;
                        cErrorDurationSeries.Points.Add(cErrorDurationPoint);
                        cErrorDurationSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

                        foreach (CTimeNode cErrorNode in lstFindTimeNode)
                        {
                            CErrorAnalyzeData cErrorData = new CErrorAnalyzeData();
                            cErrorData.CycleNumber = i;
                            cErrorData.Key = cErrorNode.Key;
                            cErrorData.Start = cErrorNode.Start;
                            cErrorData.End = cErrorNode.End;
                            cErrorData.CycleFromStartToError = cErrorNode.Start.Subtract(cCycleData.StartTime).TotalSeconds;
                            cErrorData.Duration = new TimeSpan(0, 0, 0, 0, (int)cErrorNode.Duration).TotalSeconds;
                            if (i < cCycleDataList.Count - 1)
                            {
                                CCycleAnalyData cCycleNextData = cCycleDataList[i + 1];
                                cErrorData.NextCycleStart = cCycleNextData.StartTime.Subtract(cErrorNode.End).TotalSeconds;
                            }
                            else
                                cErrorData.NextCycleStart = 0.0;
                            cErrorData.TimeNode = cErrorNode;
                            m_lstErrorList.Add(cErrorData);
                        }

                    }
                }

                ShowTable();

                exAbnormalChart.Series.Add(cCycleDurationSeries);
                exAbnormalChart.RefreshData();

                exAbnormalChart.Series.Add(cErrorDurationSeries);
                exAbnormalChart.RefreshData();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion

        #region Form Event

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_sProcess = (string)cboProcess.EditValue;
            m_dtFrom = (DateTime)dtpkFrom.EditValue;
            m_dtTo = (DateTime)dtpkTo.EditValue;

            if (m_dtFrom > m_dtTo)
            {
                XtraMessageBox.Show("조회 기간을 확인 해 주세요!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format("Update Analyze Data"), "Show Chart");
            {
                //ShowCycleLogTable();
                UpdateChart();
            }
            SplashScreenManager.CloseDefaultSplashScreen();
            
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exAbnormalChart.Series.Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle +1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void FrmAbnormalViewer_Load(object sender, EventArgs e)
        {
            bool bVerified = VerifyParameter();

            if (!bVerified)
            {
                this.Close();
                return;
            }

            InitChart();
            InitComponent();
            InitProcess();

            tmrLoad.Start();
        }

        private void exAbnormalChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ChartControl chart = (ChartControl)sender;
            //ChartHitInfo hitinfo = chart.CalcHitInfo(e.Location);

            //if (hitinfo.InSeries)
            //{
            //    SeriesPoint cPoint = hitinfo.SeriesPoint;
            //    if (cPoint.Tag.GetType() != typeof(CTimeNode))
            //        return;
            //    string sAddress = hitinfo.HitObject.ToString();
            //    string values = cPoint.Values[0].ToString();
                
            //    CTimeNode cNode = (CTimeNode)cPoint.Tag;

            //    FrmAbnormalCycleVeiwer frmCycle = new FrmAbnormalCycleVeiwer();
            //    frmCycle.Key = sAddress;
            //    frmCycle.TimeNode = cNode;

            //    frmCycle.ShowDialog();
            //}
        }

        private void exAbnormalChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void exCycleChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach (CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void grvKey_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvKey_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Type"]);
                if (category == "Error")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
                else
                {
                    category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["AvgOver"]);
                    if (category == "true" || category == "True")
                    {
                        e.Appearance.BackColor = Color.DarkGreen;
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void grvErrorList_DoubleClick(object sender, EventArgs e)
        {
            int iHandle = grvErrorList.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = grvErrorList.GetRow(iHandle);
            if ((oData.GetType() == typeof(CErrorAnalyzeData)))
            {
                CErrorAnalyzeData cErrorData = (CErrorAnalyzeData)oData;
                FrmAbnormalCycleVeiwer frmCycle = new FrmAbnormalCycleVeiwer();
                frmCycle.Key = cErrorData.Key;
                frmCycle.TimeNode = cErrorData.TimeNode;
                frmCycle.Show();
            }
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;

            if (dtpkFrom.EditValue != null)
                btnRefresh_ItemClick(null, null);
        }

        private void sptChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptChart.SplitterPosition > 0)
            {
                m_iChartSplitPos = sptChart.SplitterPosition;
                sptChart.SplitterPosition = 0;
            }
            else
                sptChart.SplitterPosition = m_iChartSplitPos;
        }

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iMainSplitPos;
        }

        #endregion
    }

    public class CErrorAnalyzeData
    {
        public int CycleNumber { get; set; }
        public string Key { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double CycleFromStartToError { get; set; }
        public double Duration { get; set; }
        public double NextCycleStart { get; set; }
        public CTimeNode TimeNode { get; set; }
    }
}