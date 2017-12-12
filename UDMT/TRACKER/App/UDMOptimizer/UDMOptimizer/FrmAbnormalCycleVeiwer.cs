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
using UDM.UI.TimeChart;
using TrackerProject;


namespace UDMOptimizer
{
    public partial class FrmAbnormalCycleVeiwer : XtraForm
    {
        #region Member Variables

        private string m_sKey = string.Empty;
        private CGanttItem m_cGanttGroup = null;
        private DateTime m_dtStartDate = new DateTime();
        private DateTime m_dtEndDate = new DateTime();
        private CTimeNode m_SelNode = new CTimeNode();
        private CMySqlLogReader m_cReader = null;

        #endregion

        #region Initialize

        public FrmAbnormalCycleVeiwer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;

        }
        #endregion

        #region Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }
        public CTimeNode TimeNode
        {
            get { return m_SelNode; }
            set { m_SelNode = value; }
        }
        #endregion

        #region Public Method

        public void ClearChart()
        {
            ucChart.Clear();
            InitChart();
        }

        #endregion

        #region Private Method

        private void InitChart()
        {
            CColumnItem cColumn = null;

            ucChart.GanttTree.ColumnS.Clear();

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);
        }
        private void RegisterTimeChartEventS()
        {
            //ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
        }
        private void InitInterval()
        {
            txtWordValue.Text = "";
            txtInterval.Text = "";
            dtpkIndicator1.EditValue = "00:00:00.000";
            dtpkIndicator2.EditValue = "00:00:00.000";
        }

        #region GanttChart Method
        private void SetGanttChart()
        {
            //try
            //{
            //    ClearChart();

            //    foreach (CPlcProc cProc in CMultiProject.PlcProcS.Values)
            //    {
            //        if (cProc.IsErrorMonitoring) continue;

            //        CCycleAnalyDataList cCycleDataList = CMultiProject.CycleAnalyDataS[cProc.Name];
            //        List<CCycleAnalyData> lstData = cCycleDataList.Where(x => x.StartTime <= m_dtStartDate && x.EndTime >= m_dtStartDate).ToList();

            //        DateTime dtFrom = new DateTime();
            //        DateTime dtTo = new DateTime();

            //        CTimeLogS cTotalLogS = new CTimeLogS();

            //        List<string> lstAllTag = new List<string>();

            //        lstAllTag.AddRange(cProc.RecipeWordS.Select(b => b.Key).ToList());
            //        lstAllTag.AddRange(cProc.ProcessTagS.Select(b => b.Key).ToList());

            //        if (lstData.Count > 0)
            //        {
            //            CCycleAnalyData cCycleAnalyData = lstData[0];

            //            dtFrom = cCycleAnalyData.StartTime;
            //            dtTo = cCycleAnalyData.EndTime;

            //            cTotalLogS = m_cReader.GetTimeLogS(lstAllTag, dtFrom, dtTo);
            //        }

            //        List<string> lstSort = new List<string>();

            //        if (cTotalLogS != null && cTotalLogS.Count > 0)
            //        {
            //            lstSort.AddRange(cProc.RecipeWordS.Select(b => b.Key).ToList());
            //            for (int i = 0; i < cTotalLogS.Count; i++)
            //            {
            //                CTimeLog cLog = cTotalLogS[i];
            //                if (lstSort.Contains(cLog.Key) == false && cLog.Value != 0)
            //                {
            //                    lstSort.Add(cLog.Key);
            //                }
            //            }
            //        }
                    
            //        ShowGanttChart(cProc.Name, lstSort, dtFrom, dtTo, cTotalLogS);

            //        //Cycle 간격 확인용
            //        ucChart.TimeLine.TimeIndicatorS.Clear();
            //        ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(m_dtStartDate, Color.Red));
            //        ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(m_dtEndDate, Color.Red));

            //        dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            //        dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

            //        ucChart.TimeLine.UpdateLayout();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.Message);
            //    CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            //    ex.Data.Clear();
            //}
        }
        private void ShowGanttChart(string sProcess, List<string> lstKey, DateTime dtFrom, DateTime dtTo, CTimeLogS cTotalLogS)
        {
            try
            {
                DateTime dtFirstVisible = DateTime.MinValue;

                ucChart.BeginUpdate();
                {
                    CGanttItem cItem = null;
                    List<CGanttBar> lstBar = null;
                    CTimeNodeS cNodeS = null;
                    CTimeLogS cLogS = new CTimeLogS();
                    bool bShowBarText = false;
                    CTagS cTagS = new CTagS();
                    bool bFirst = true;


                    foreach (string sKey in lstKey)
                    {
                        if (CMultiProject.TotalTagS.ContainsKey(sKey) == false)
                            continue;
                        CTag cTag = CMultiProject.TotalTagS[sKey];
                        cTagS.Add(cTag);
                    }

                    InitInterval();
                    CreateMasterGanttItem(sProcess, m_dtStartDate, m_dtEndDate);

                    foreach (CTag cTag in cTagS.Values)
                    {
                        cItem = CreateGanttItem(cTag);

                        if (cTotalLogS != null)
                            cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                        if (cLogS != null && cLogS.Count > 0)
                        {
                            if (cLogS.Count < 2) continue;

                            cLogS.UpdateTimeRange();

                            if (bFirst)
                            {
                                dtFirstVisible = cLogS.FirstTime;
                                bFirst = false;
                            }
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

                        if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                            bShowBarText = true;

                        lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                        cItem.BarS.AddRange(lstBar);

                        //if (bCoilTagShow)
                        //    ShowSubItemChart(cItem, dtFrom, dtTo);

                        m_cGanttGroup.ItemS.Add(cItem);

                        //ShowSubItemChart(cItem, dtFrom, dtTo);
                        //m_cGanttGroup.Expand();

                        lstBar.Clear();
                        lstBar = null;
                    }

                    ucChart.TimeLine.RangeFrom = m_dtStartDate;
                    ucChart.TimeLine.RangeTo = dtTo;

                    if (dtFirstVisible != DateTime.MinValue)
                        ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                    else
                        ucChart.TimeLine.FirstVisibleTime = m_dtStartDate;
                }
                ucChart.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void CreateMasterGanttItem(string sProcess, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                CCycleAnalyDataList cCycleData = CMultiProject.CycleAnalyDataS[sProcess];
                List<CCycleAnalyData> lstData = cCycleData.Where(x => x.StartTime <= dtFrom && x.EndTime >= dtFrom).ToList();

                m_cGanttGroup = (CGanttItem)ucChart.GanttTree.ItemS.FindHasData(sProcess);
                if (m_cGanttGroup == null)
                {
                    m_cGanttGroup = new CGanttItem(new string[] { sProcess, "" });
                    m_cGanttGroup.Data = sProcess;
                    ucChart.GanttTree.ItemS.Add(m_cGanttGroup);
                }

                m_cGanttGroup.BarS.Clear();

                CGanttBar cBar = new CGanttBar();
                if(lstData.Count > 0)
                {
                    CCycleAnalyData cCycleInfo = lstData[0];

                    cBar.StartTime = cCycleInfo.StartTime;
                    cBar.EndTime = cCycleInfo.EndTime;
                    cBar.Data = cCycleInfo;
                    cBar.Color = Color.Green;
                }
                m_cGanttGroup.BarS.Add(cBar);

                //foreach (CCycleAnalyData cCycleInfo in lstData)
                //{
                //    CGanttBar cBar = new CGanttBar();
                //    cBar.StartTime = cCycleInfo.StartTime;
                //    cBar.EndTime = cCycleInfo.EndTime;
                //    cBar.Data = cCycleInfo;
                //    cBar.Color = Color.Green;
                //    m_cGanttGroup.BarS.Add(cBar);
                //}
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        private void ShowSubItemChart(CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            CTag cCoilTag = (CTag)cParentItem.Data;
            List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cCoilTag);
            CStep cStep = null;

            if (lstCoilStep == null || lstCoilStep.Count == 0)
                return;
            else
                cStep = lstCoilStep[0];

            CreateStepSubDepthItem(cStep, cCoilTag, cParentItem, dtFrom, dtTo);
        }
        private void CreateStepSubDepthItem(CStep cStep, CTag cCoilTag, CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                ucChart.BeginUpdate();
                {
                    CGanttItem cItem = null;
                    List<CGanttBar> lstBar = null;
                    CTimeNodeS cSubNodeS = null;
                    CTimeLogS cLogS = new CTimeLogS();
                    //CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(cStep.RefTagS.KeyList, dtFrom, dtTo);
                    CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(cStep.RefTagS.KeyList, dtFrom, dtTo);
                    CTag cTag = null;
                    bool bShowBarText = false;

                    if (cTotalLogS == null || cTotalLogS.Count == 0)
                        return;

                    CTagS cTotalTagS = CMultiProject.TotalTagS;

                    foreach (string sKey in cStep.RefTagS.KeyList)
                    {
                        if (sKey == cCoilTag.Key)
                            continue;
                        if (cTotalTagS.ContainsKey(sKey) == false)
                        {
                            Console.WriteLine(string.Format("{0} 가 없습니다.Logic 변환 오류 가능성 높음", sKey));
                            continue;
                        }
                        cTag = cTotalTagS[sKey];
                        cItem = CreateGanttItem(cTag);
                        cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                        if (cLogS != null)
                        {
                            cSubNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                            if (cSubNodeS == null)
                                cSubNodeS = new CTimeNodeS();
                        }
                        else
                            cSubNodeS = new CTimeNodeS();

                        if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                            bShowBarText = true;

                        lstBar = CreateBarList(cSubNodeS, Color.LightBlue, bShowBarText);
                        cItem.BarS.AddRange(lstBar);

                        cParentItem.ItemS.Add(cItem);

                        lstBar.Clear();
                        lstBar = null;
                        cLogS.Clear();
                    }
                }
                ucChart.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
            cItem.Data = cTag;

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
            cBar.Height = 6;

            return cBar;
        }
        #endregion

        #endregion

        #region Form Event
        private void FrmAbnormalCycleVeiwer_Load(object sender, EventArgs e)
        {
            if (m_sKey != string.Empty)
                txtAddress.EditValue = m_sKey;

            txtStartTime.EditValue = m_SelNode.Start.ToString();
            txtEndTime.EditValue = m_SelNode.End.ToString();

            m_dtStartDate = m_SelNode.Start;
            m_dtEndDate = m_SelNode.End;

            RegisterTimeChartEventS();
            tmrLoad.Start();
        }
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region UCChart Event
        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            try
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

                    //ucChart.SeriesTree.UpdateLayout();
                }
                else if (cCol.Name == "colSeriesColor")
                {
                    CSeriesItem cItem = (CSeriesItem)cRow;

                    cItem.Color = (Color)oValue;
                    //ucChart.SeriesTree.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            try
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
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAbnormalCycleViewer", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
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
        #endregion

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            tmrLoad.Enabled = false;

            SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format("All Process Data Loading"), "Show Gantt Chart");
            {
                SetGanttChart();
            }
            SplashScreenManager.CloseDefaultSplashScreen();
        }

        #endregion
    }
}
