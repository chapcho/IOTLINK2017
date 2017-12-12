using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log.DB;
using UDM.Common;
using UDM.Log;
using UDM.General.Statistics;
using DevExpress.XtraCharts;
using DevExpress.XtraSplashScreen;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmAnovaAnalysis : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private string m_sSubject = "";

        private double[][] m_daAnalysisValue = null;

        private DataTable m_tbGroup = null;
        private DataTable m_tbLevene = null;
        private DataTable m_tbAnova = null;
        private DataTable m_tbScheffe = null;
        private DataTable m_tbT3 = null;

        private List<CAnovaGroup> m_lstAnovaGroup = new List<CAnovaGroup>();
        private List<CAnovaStatistic> m_lstStatisticData = new List<CAnovaStatistic>();
        private Dictionary<string, List<double>> m_dicGroupValue = new Dictionary<string, List<double>>();

        private CMySqlLogReader m_cReader = null;

        #endregion

        #region Initialize

        public FrmAnovaAnalysis()
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
        private void InitProcess()
        {
            try
            {
                cboProcess.EditValue = null;
                exEditorGroup.Items.Clear();

                foreach (var who in CMultiProject.PlcProcS)
                    exEditorGroup.Items.Add(who.Key);

                if (exEditorGroup.Items.Count > 0)
                    cboProcess.EditValue = exEditorGroup.Items[0];
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        private void InitComboPatternItem()
        {
            //try
            //{
            //    string sProcess = (string)cboProcess.EditValue;
            //    CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
            //    List<string> lstKeyS = new List<string>();

            //    CTag cTag = null;
            //    foreach (string sKey in cProcess.RecipeWordS.Keys)
            //    {
            //        if (!CMultiProject.TotalTagS.ContainsKey(sKey))
            //            continue;

            //        cTag = CMultiProject.TotalTagS[sKey];
            //        //lstKeyS.Add(cTag.Address + " : " + cTag.Description);
            //        lstKeyS.Add(cTag.Key);
            //    }

            //    foreach (string sKey in cProcess.ProcessTagS.Keys)
            //    {
            //        if (!CMultiProject.TotalTagS.ContainsKey(sKey))
            //            continue;

            //        cTag = CMultiProject.TotalTagS[sKey];
            //        //lstKeyS.Add(cTag.Address + " : " + cTag.Description);
            //        lstKeyS.Add(cTag.Key);
            //    }

            //    cboPatternItem.Properties.Items.AddRange(lstKeyS);

            //    if (cboPatternItem.Properties.Items.Count > 0)
            //        cboPatternItem.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{
            //    Console.Write(ex.Message);
            //    CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            //    ex.Data.Clear();
            //}
        }
        private void SetStatisticData()
        {
            try
            {
                m_lstStatisticData = new List<CAnovaStatistic>();
                m_dicGroupValue = new Dictionary<string, List<double>>();

                foreach (CAnovaGroup cGroup in m_lstAnovaGroup)
                {
                    CAnovaStatistic cStatistic = SetAnovaStatistic(cGroup);
                    m_lstStatisticData.Add(cStatistic);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        private void InitGroupGrid()
        {
            try
            {
                m_lstAnovaGroup = new List<CAnovaGroup>();

                foreach (DataRow dr in m_tbGroup.Rows)
                {
                    CAnovaGroup cGroup = new CAnovaGroup();
                    cGroup.GroupName = dr["GroupName"].ToString();
                    cGroup.From = DateTime.Parse(dr["From"].ToString());
                    cGroup.To = DateTime.Parse(dr["To"].ToString());
                    cGroup.Recipe = dr["Recipe"].ToString();
                    cGroup.Count = Int32.Parse(dr["Count"].ToString());

                    m_lstAnovaGroup.Add(cGroup);
                }
                grdGroup.DataSource = m_lstAnovaGroup;
                grdGroup.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        private void InitStatisticGrid()
        {
            try
            {
                grdStatistic.DataSource = m_lstStatisticData;
                grdStatistic.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
        }
        private void InitLeveneGrid()
        {
            try
            {
                CRLeveneResult cRLevene = CREngineHelper.DoLeveneTest(m_daAnalysisValue);

                if (cRLevene == null) return;

                m_tbLevene = new DataTable();
                m_tbLevene.Columns.Add("Statistic", typeof(string));
                m_tbLevene.Columns.Add("PValue", typeof(string));

                DataRow dr = m_tbLevene.NewRow();
                dr["Statistic"] = cRLevene.Statistic.ToString();
                dr["PValue"] = cRLevene.PValue.ToString();
                m_tbLevene.Rows.Add(dr);

                grdLevene.DataSource = m_tbLevene;
                grdLevene.RefreshDataSource();

                //if (cRLevene.PValue > 0.05) //등분산성 성립 - Anova분석
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
        }
        private void InitAnovaGrid()
        {
            try
            {
                CRAnovaResult cRAnova = CREngineHelper.DoAnovaTest(m_daAnalysisValue);

                if (cRAnova == null) return;

                m_tbAnova = new DataTable();

                m_tbAnova.Columns.Add("Group", typeof(string));
                m_tbAnova.Columns.Add("DF", typeof(string));
                m_tbAnova.Columns.Add("SS", typeof(string));
                m_tbAnova.Columns.Add("MS", typeof(string));
                m_tbAnova.Columns.Add("FValue", typeof(string));
                m_tbAnova.Columns.Add("PValue", typeof(string));

                DataRow dr = m_tbAnova.NewRow();
                dr["Group"] = "집단-간";
                dr["DF"] = cRAnova.GroupDF.ToString();
                dr["SS"] = cRAnova.GroupSS.ToString();
                dr["MS"] = cRAnova.GroupMS.ToString();
                dr["FValue"] = cRAnova.FValue.ToString();
                dr["PValue"] = cRAnova.PValue.ToString();
                m_tbAnova.Rows.Add(dr);

                dr = m_tbAnova.NewRow();
                dr["Group"] = "집단-내";
                dr["DF"] = cRAnova.ErrorDF.ToString();
                dr["SS"] = cRAnova.ErrorSS.ToString();
                dr["MS"] = cRAnova.ErrorMS.ToString();
                dr["FValue"] = " ";
                dr["PValue"] = " ";
                m_tbAnova.Rows.Add(dr);

                dr = m_tbAnova.NewRow();
                dr["Group"] = "합계";
                dr["DF"] = (cRAnova.GroupDF + cRAnova.ErrorDF).ToString();
                dr["SS"] = (cRAnova.GroupSS + cRAnova.ErrorSS).ToString();
                dr["MS"] = " ";
                dr["FValue"] = " ";
                dr["PValue"] = " ";
                m_tbAnova.Rows.Add(dr);

                grdAnova.DataSource = m_tbAnova;
                grdAnova.RefreshDataSource();

                if (cRAnova.PValue < 0.05)
                {
                    lblResult.Text = "H0(귀무가설) 기각, H1(대립가설) 채택";
                    pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                    pnlBackground.Appearance.BackColor2 = Color.Red;

                    lblDescFalse.Visible = true;
                    lblDescTrue.Visible = false;
                }
                else
                {
                    lblResult.Text = "H0(귀무가설) 채택, H1(대립가설) 기각";
                    pnlBackground.Appearance.BackColor = Color.LimeGreen;
                    pnlBackground.Appearance.BackColor2 = Color.NavajoWhite;

                    lblDescFalse.Visible = false;
                    lblDescTrue.Visible = true;
                }

                timer.Start();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
        }

        private void InitScheffeGrid()
        {
            try
            {
                CRScheffeResult cRScheffe = CREngineHelper.DoScheffeTest(m_daAnalysisValue);

                if (cRScheffe == null) return;

                m_tbScheffe = new DataTable();

                m_tbScheffe.Columns.Add("Group", typeof(string));
                m_tbScheffe.Columns.Add("Diff", typeof(string));
                m_tbScheffe.Columns.Add("PValue", typeof(string));
                m_tbScheffe.Columns.Add("Sig", typeof(string));
                m_tbScheffe.Columns.Add("LCL", typeof(string));
                m_tbScheffe.Columns.Add("UCL", typeof(string));

                for (int i = 0; i < cRScheffe.GroupName.Length; i++)
                {
                    DataRow dr = m_tbScheffe.NewRow();
                    dr["Group"] = cRScheffe.GroupName[i].ToString();
                    dr["Diff"] = cRScheffe.GroupDiff[i].ToString();
                    dr["PValue"] = cRScheffe.GroupPValue[i].ToString();
                    dr["Sig"] = cRScheffe.GroupSig[i].ToString();

                    if (cRScheffe.GroupSig[i].ToString() == "1")
                        dr["Sig"] = ".";
                    else
                        dr["Sig"] = "**";

                    dr["LCL"] = cRScheffe.GroupLCL[i].ToString();
                    dr["UCL"] = cRScheffe.GroupUCL[i].ToString();
                    m_tbScheffe.Rows.Add(dr);
                }

                grdScheffe.DataSource = m_tbScheffe;
                grdScheffe.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
        }

        private void InitDunnettT3Grid()
        {
            try
            {
                CRDunnettT3Result cRDunnettT3 = CREngineHelper.DoDunnettT3Test(m_daAnalysisValue);

                if (cRDunnettT3 == null) return;

                m_tbT3 = new DataTable();

                m_tbT3.Columns.Add("Group", typeof(string));
                m_tbT3.Columns.Add("Diff", typeof(string));
                m_tbT3.Columns.Add("LowerCI", typeof(string));
                m_tbT3.Columns.Add("UpperCI", typeof(string));

                for (int i = 0; i < cRDunnettT3.GroupName.Length; i++)
                {
                    DataRow dr = m_tbT3.NewRow();
                    dr["Group"] = cRDunnettT3.GroupName[i].ToString();
                    dr["Diff"] = cRDunnettT3.GroupDiff[i].ToString();
                    dr["LowerCI"] = cRDunnettT3.GroupLowerCI[i].ToString();
                    dr["UpperCI"] = cRDunnettT3.GroupUpperCI[i].ToString();
                    m_tbT3.Rows.Add(dr);
                }

                grdDunnettT3.DataSource = m_tbT3;
                grdDunnettT3.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
        }


        private CAnovaStatistic SetAnovaStatistic(CAnovaGroup cGroup)
        {
            CAnovaStatistic cStatistic = new CAnovaStatistic();
            try
            {
                int iCount = 0;
                double dMean = 0;
                double dStv = 0;
                double dMin = 0;
                double dMax = 0;

                string sProcess = (string)cboProcess.EditValue;
                CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
                CCycleAnalyzedData cProcessCycleData = CMultiProject.CycleAnalyDataS[sProcess].CycleAnalyzedData;
                
                List<double> lstValue = new List<double>();

                if (m_sSubject == "P")
                {
                    string sKey = (string)cboPatternItem.EditValue;
                    CTimeLogS cLogS = m_cReader.GetTimeLogS(sKey, cGroup.From, cGroup.To);
                    CTimeNodeS cTimeNodeS = new CTimeNodeS(CMultiProject.TotalTagS[sKey], cLogS, cGroup.From, cGroup.To);

                    foreach (CTimeNode cNode in cTimeNodeS)
                    {
                        if ((cProcessCycleData.Average.TotalMilliseconds * 1.5) < cNode.Duration)
                            continue;

                        lstValue.Add(cNode.Duration);
                    }
                }
                else if (m_sSubject == "C")
                {
                    //CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, cGroup.From, cGroup.To);
                    //foreach (CCycleInfo cCycle in cCycleInfoS.Values)
                    //{
                    //    if ((cProcessCycleData.Average.TotalMilliseconds * 1.5) < cNode.Duration)
                    //        continue;

                    //    lstValue.Add(cCycle.CycleTimeValue.TotalSeconds);
                    //}

                    CCycleAnalyDataList cCycleData = CMultiProject.CycleAnalyDataS[sProcess];
                    List<CCycleAnalyData> lstData = cCycleData.Where(x => x.StartTime >= cGroup.From && x.EndTime <= cGroup.To).ToList();

                    foreach (CCycleAnalyData ccycle in lstData)
                    {
                        if ((cProcessCycleData.Average.TotalMilliseconds * 1.5) < ccycle.Duration.TotalMilliseconds)
                            continue;

                        lstValue.Add(ccycle.Duration.TotalMilliseconds);
                    }
                }

                iCount = lstValue.Count;
                dMean = Math.Round(CStatics.Mean(lstValue), 2);
                dStv = Math.Round(CStatics.StandardDeviation(lstValue), 2);
                dMin = Math.Round(CStatics.Min(lstValue), 2);
                dMax = Math.Round(CStatics.Max(lstValue), 2);

                cStatistic.GroupName = cGroup.GroupName;
                cStatistic.Count = iCount;
                cStatistic.Mean = dMean != -1 ? dMean : 0;
                cStatistic.Stv = !double.IsNaN(dStv) ? dStv : 0;
                cStatistic.Min = dMin != -1 ? dMin : 0;
                cStatistic.Max = dMax != -1 ? dMax : 0;

                if (!m_dicGroupValue.ContainsKey(cGroup.GroupName))
                    m_dicGroupValue.Add(cGroup.GroupName, lstValue);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return cStatistic;
        }

        private void SetRandomChart()
        {
            exChart.Series.Clear();
            try
            {
                int iXcenter = 20;
                Random random = new Random();

                for (int i = 0; i < m_dicGroupValue.Count; i++)
                {
                    string sKey = m_dicGroupValue.ElementAt(i).Key;
                    List<double> lstValue = m_dicGroupValue.ElementAt(i).Value;

                    Series cRandomSeries = new Series(sKey, ViewType.Point);
                    cRandomSeries.Points.AddRange(CalculatePoints(random, lstValue, iXcenter));
                    iXcenter = iXcenter + 10;
                    exChart.Series.Add(cRandomSeries);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private SeriesPoint[] CalculatePoints(Random random, List<double> lstGetValue, int xCenter)
        {
            SeriesPoint[] seriesPoints = new SeriesPoint[lstGetValue.Count];
            for (int i = 0; i < lstGetValue.Count; i++)
            {
                PointF point = CalcRandomPoint(random, lstGetValue.Count, xCenter, lstGetValue[i]);
                seriesPoints[i] = new SeriesPoint(point.X, new double[] { point.Y });
            }
            return seriesPoints;
        }

        private PointF CalcRandomPoint(Random random, int iCount, int xCenter, double dPointY)
        {
            const int dispersion = 2;
            const int expectedSum = 6;
            PointF point = new PointF();
            double sum = 0;
            for (int i = 0; i < iCount; i++)
                sum += random.NextDouble();
            double radius = (sum - expectedSum) * dispersion;
            double angle = random.Next(360) * Math.PI / 180;
            //point.X = (float)(xCenter + radius * Math.Cos(angle));
            //point.Y = (float)(yCenter + radius * Math.Sin(angle));
            point.X = (float)(random.Next(xCenter - 10, xCenter + 10));
            point.Y = (float)(dPointY);

            return point;
        }

        private void Clear()
        {
            if (m_tbGroup != null)
                m_tbGroup.Clear();

            m_lstAnovaGroup.Clear();
            m_lstStatisticData.Clear();
            m_dicGroupValue.Clear();

            grdGroup.DataSource = null;
            grdGroup.RefreshDataSource();

            grdStatistic.DataSource = null;
            grdStatistic.RefreshDataSource();

            grdLevene.DataSource = null;
            grdLevene.RefreshDataSource();

            grdAnova.DataSource = null;
            grdAnova.RefreshDataSource();

            grdScheffe.DataSource = null;
            grdScheffe.RefreshDataSource();

            grdDunnettT3.DataSource = null;
            grdDunnettT3.RefreshDataSource();

            exChart.Series.Clear();
        }

        private void StatisticGridClear()
        {
            grdStatistic.DataSource = null;
            grdStatistic.RefreshDataSource();

            grdLevene.DataSource = null;
            grdLevene.RefreshDataSource();

            grdAnova.DataSource = null;
            grdAnova.RefreshDataSource();

            grdScheffe.DataSource = null;
            grdScheffe.RefreshDataSource();

            grdDunnettT3.DataSource = null;
            grdDunnettT3.RefreshDataSource();
        }
        #endregion

        #region Form Event

        private void FrmAnovaAnalysis_Load(object sender, EventArgs e)
        {
            bool bOK = VerifyParameter();

            if (!bOK)
                return;

            InitProcess();

            rdgSubject.SelectedIndex = 1;
            rdgSubject.SelectedIndex = 0;

            exChart.Series.Clear();
        }
        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string sProcess = (string)cboProcess.EditValue;
                string sSubject = "";

                if (rdgSubject.SelectedIndex == 0)
                    sSubject = "C";
                else
                    sSubject = "P";

                FrmAnovaAddGroup frmAddGroup = new FrmAnovaAddGroup();
                frmAddGroup.Process = sProcess;
                frmAddGroup.Subject = sSubject;

                if (sSubject == "P")
                {
                    string sItem = (string)cboPatternItem.Text;
                    frmAddGroup.PatternItem = sItem;
                }

                if (m_tbGroup != null)
                    frmAddGroup.GroupTable = m_tbGroup;

                frmAddGroup.ShowDialog();

                if (frmAddGroup.Apply)
                {
                    SplashScreenManager.ShowDefaultWaitForm();
                    {
                        m_tbGroup = frmAddGroup.GroupTable;
                        InitGroupGrid();
                        SetStatisticData();
                        SetRandomChart();
                    }
                    SplashScreenManager.CloseDefaultWaitForm();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void rdgSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdGroup.DataSource != null)
            {
                //DialogResult dlgResult = XtraMessageBox.Show("분석 대상에 대한 그룹이 존재합니다.\r\n다시 설정하시겠습니까?", "UDM Tracker Simple",
                //                                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (dlgResult == DialogResult.Yes)
                Clear();
            }

            if (rdgSubject.SelectedIndex == 0)
            {
                cboPatternItem.Visible = false;
                m_sSubject = "C";
            }
            else
            {
                cboPatternItem.Visible = true;
                m_sSubject = "P";

                InitComboPatternItem();
            }
            grdGroup.DataSource = null;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_dicGroupValue.Count < 2)
                {
                    XtraMessageBox.Show("통계적 분석 진행을 위해선\r\n분석 그룹이 2개 이상 존재해야 합니다.", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SplashScreenManager.ShowForm(FindForm(), typeof(FrmWaitForm), true, true, false);
                {
                    bool bOK = CREngineHelper.Connect();

                    if (!bOK) return;
                    if (!CREngineHelper.IsConnected) return;

                    m_daAnalysisValue = new double[m_dicGroupValue.Count][];
                    for (int i = 0; i < m_dicGroupValue.Count; i++)
                    {
                        List<double> lstValue = m_dicGroupValue.ElementAt(i).Value;
                        m_daAnalysisValue[i] = new double[lstValue.Count];
                        for (int j = 0; j < lstValue.Count; j++)
                        {
                            m_daAnalysisValue[i][j] = lstValue[j];
                        }
                    }

                    InitStatisticGrid(); // 기술통계
                    InitLeveneGrid();    // 등분산성 분석
                    InitAnovaGrid();     // Anova 분석
                    InitScheffeGrid();   // Scheffe 분석
                    InitDunnettT3Grid(); // DunnettT3 분석
                }
                SplashScreenManager.CloseForm(false);

                rdgSubject.Enabled = false;
                cboPatternItem.Enabled = false;
                btnAddGroup.Enabled = false;
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAnalysis", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                XtraMessageBox.Show("통계적 분석 진행에 실패하였습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StatisticGridClear();
                ex.Data.Clear();
            }
        }


        private void cboPatternItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdGroup.DataSource != null)
                Clear();
        }

        private void FrmAnovaAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            CREngineHelper.Disconnect();
        }

        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {

        }

    }

    public class CAnovaGroup
    {
        public string GroupName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Recipe { get; set; }

        public int Count { get; set; }
    }
    public class CAnovaStatistic
    {
        public string GroupName { get; set; }

        public int Count { get; set; }

        public double Mean { get; set; }

        public double Stv { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }
    }
}
