using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Repository;

using MathNet.Numerics;

using UDM.UI.TimeChart;
using UDM.Log;
using UDM.Common;
using MathNet.Numerics.LinearAlgebra.Double;

namespace UDMEnergyViewer
{
    public partial class FrmAnalysis : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, CTagItemS> m_DicUnitTagItemS = null;
        private CMeterItemS m_cMeterItemS = null;
        private CMeterUnit m_cMeterUnitCur = null;
        private CTimeLogS m_cEnergyUnitTimeLogS = new CTimeLogS();
        private int m_iMergeDepth = 1;
        private int m_iRegressionDegree = 1;
        private string m_sAddressKeyCur = string.Empty;

        List<double> m_lstdXPoint = new List<double>();
        List<double> m_lstdYPoint = new List<double>();
        private double m_dBasePower = 0.0;
        private double[] m_dThetaArray = null;

        private DataTable m_dtEnergy = null;

        bool m_bGanttLayBack = false;

        public FrmAnalysis()
        {
            InitializeComponent();
        }

        #region Properties

        #endregion


        private void ClearChart()
        {
            Chart.Series["Energy Variation"].Points.Clear();
            Chart.Series["Regression Line"].Points.Clear();
            txtEquation.EditValue = "";
        }

        private void ClearData()
        {
            if (gcTag.DataSource == null)
                return;

            List<CTag> lstTag = (List<CTag>)gcTag.DataSource;

            lstTag.Clear();

            gcTag.RefreshDataSource();
        }

        private void InitTagInformation()
        {
            ClearData();

            List<CTag> lstTag = new List<CTag>();
            string sDisaggregationCur = cboDisaggregation.EditValue.ToString();
             foreach(CTagItem cItem in m_DicUnitTagItemS[sDisaggregationCur].Values)
                 lstTag.Add(cItem.Tag);

            gcTag.DataSource = lstTag;
            gcTag.RefreshDataSource();
        }

        private void InitDisaggregation()
        {
            m_DicUnitTagItemS = CProjectManager.Project.UnitTagItemS;

            if (m_DicUnitTagItemS.Count != 0)
            {
                RepositoryItemComboBox exEditorDisaggregation = (RepositoryItemComboBox)cboDisaggregation.Edit;
                exEditorDisaggregation.Items.AddRange(m_DicUnitTagItemS.Keys);
            }            
        }

        private void InitData()
        {
            m_dtEnergy = new DataTable();
            m_dtEnergy.Columns.Add("Time");
            m_dtEnergy.Columns.Add("Energy Consumption");
            m_dtEnergy.Columns.Add("Energy Variation");
        }

        private void InitChart()
        {
            Chart.Series["Energy Variation"].Points.Clear();
            Chart.Series["Regression Line"].Points.Clear();
        }

        private void InitTimeRange()
        {
            dtFrom.EditValue = m_cEnergyUnitTimeLogS.GetFirstTimeLog().Time;
            dtTo.EditValue = m_cEnergyUnitTimeLogS.GetLastLog().Time;
        }

        private void ShowData(string sDisaggregationCur, string sAddressKey)
        {
            m_dtEnergy.Rows.Clear();
            m_cEnergyUnitTimeLogS.Clear();
            ClearChart();

            if (m_cMeterUnitCur == null)
                return;

            int MeterUnitIndex = m_cMeterItemS[sDisaggregationCur].IndexOf(m_cMeterUnitCur);
            DateTime dtValueOnTime = DateTime.MinValue;
            DateTime dtValueOffTime = DateTime.MinValue;
            CTimeLogS cTagTimeLogS = m_DicUnitTagItemS[sDisaggregationCur][sAddressKey].LogS;
            CTimeLogS cTempLogS = null;
            int iMergeDepth = 0;
            bool bCheckValueOn = false;

            foreach(CTimeLog cLog in cTagTimeLogS)
            {
                if (iMergeDepth == m_iMergeDepth)
                    break;

                if (cLog.Value == 1)
                {
                    dtValueOnTime = cLog.Time;
                    bCheckValueOn = true;
                }
                else
                {
                    if (bCheckValueOn)
                    {
                        dtValueOffTime = cLog.Time;
                        cTempLogS = m_cMeterItemS[sDisaggregationCur][MeterUnitIndex].LogS.GetTimeLogS(dtValueOnTime, dtValueOffTime);
                        m_cEnergyUnitTimeLogS.AddRange(cTempLogS);
                        iMergeDepth++;
                    }
                }
            }

            m_cEnergyUnitTimeLogS.Sort();

            DateTime dtFirstTime = m_cEnergyUnitTimeLogS.GetFirstTimeLog().Time;
            float fPrevEnergyValue = m_cEnergyUnitTimeLogS.GetFirstTimeLog().FValue;
            m_dBasePower = (double)fPrevEnergyValue;

            foreach (CTimeLog cLog in m_cEnergyUnitTimeLogS)
            {
                DataRow drRow = m_dtEnergy.NewRow();
                drRow[0] = (double)cLog.Time.Subtract(dtFirstTime).TotalSeconds;
                drRow[1] = cLog.FValue;
                drRow[2] = cLog.FValue - fPrevEnergyValue;
                fPrevEnergyValue = cLog.FValue;

                m_dtEnergy.Rows.Add(drRow);
            }

            m_lstdXPoint.Clear();
            m_lstdYPoint.Clear();

            for (int i = 0; i < m_dtEnergy.Rows.Count; i++)
            {
                DataRow drRow = m_dtEnergy.Rows[i];
                m_lstdXPoint.Add(double.Parse(drRow[0].ToString()));
                m_lstdYPoint.Add(double.Parse(drRow[2].ToString()));
            }

            gcData.DataSource = m_dtEnergy;
            gcData.RefreshDataSource();

            InitTimeRange();
        }

        private void ShowChart()
        {
            Chart.Series["Energy Variation"].Points.Clear();

            SeriesPoint cPoint;
            //DateTime dtEnergyTime = DateTime.MinValue;
            //double dEnergyValue = 0;

            for(int i = 0 ; i < m_lstdXPoint.Count ; i++)
            {
                if (i != 0 && m_lstdYPoint[i] == 0)
                    continue;

                cPoint = new SeriesPoint(m_lstdXPoint[i], new double[] { m_lstdYPoint[i] });
                Chart.Series["Energy Variation"].Points.Add(cPoint);
            }

            //for (int i = 0; i < m_dtEnergy.Rows.Count; i++)
            //{
            //    DataRow drRow = m_dtEnergy.Rows[i];
            //    dtEnergyTime = (DateTime)drRow[0];
            //    dEnergyValue = (double)drRow[2];

            //    cPoint = new SeriesPoint(dtEnergyTime, new double[] { dEnergyValue });
            //    Chart.Series["Energy Variation"].Points.Add(cPoint);
            //}
        }

        private void ShowRegressionLine()
        {
            Chart.Series["Regression Line"].Points.Clear();

            SeriesPoint cPoint;

            var degree = m_iRegressionDegree;
            var X = new DenseMatrix(m_lstdXPoint.Count, degree + 1);
            X.SetColumn(0, DenseVector.Create(m_lstdXPoint.Count, i => 1));

            if (degree != 0)
                X.SetColumn(1, m_lstdXPoint.ToArray());

            for (int i = 2; i <= degree; i++)
                X.SetColumn(i, X.Column(1).PointwiseMultiply(X.Column(i - 1)));

            var Y = DenseMatrix.OfColumns(m_lstdYPoint.Count, 1, new[] { new DenseVector(m_lstdYPoint.ToArray()) });
            var qrTheta = X.QR().Solve(Y).ToColumnWiseArray();

            var xMax = m_lstdXPoint.Max();
            var xMin = m_lstdXPoint.Min();
            var interval = (xMax - xMin) / Convert.ToDouble(m_lstdXPoint.Count);

            for(var i = xMin ; i < xMax ; i+= interval)
            {
                double yPlot = yPrediction(i, qrTheta);
                cPoint = new SeriesPoint(i, new double [] { yPlot });
                Chart.Series["Regression Line"].Points.Add(cPoint);
            }
        }

        private double yPrediction(double xPlot, double[] theta)
        {
            var yPlot = 0.0;
            m_dThetaArray = theta;

            for (int i = 0; i < theta.Length; i++ )
                yPlot += theta[i] * Math.Pow(xPlot, i);

            return yPlot;
        }

        private void PrintEquation()
        {
            string sEquation = string.Empty;
            string sTemp = string.Empty;

            for (int i = m_dThetaArray.Length - 1; i >= 0; i--)
            {
                sTemp = string.Format("{0}X^{1} + ", m_dThetaArray[i], i);
                sEquation += sTemp;
            }
            sEquation += m_dBasePower.ToString();

            txtEquation.EditValue = string.Format("Y = {0}", sEquation);
        }

        #region Event

        private void FrmAnalysis_Load(object sender, EventArgs e)
        {
            m_DicUnitTagItemS = CProjectManager.Project.UnitTagItemS;
            m_cMeterItemS = CProjectManager.Project.MeterItemS;

            InitDisaggregation();
            InitData();
            InitChart();
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowChart();
            ShowRegressionLine();
            PrintEquation();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearChart();
        }

        private void cboDisaggregation_EditValueChanged(object sender, EventArgs e)
        {
            ClearChart();
            cboEnergyUnit.EditValue = "";

            string sDisaggregation = cboDisaggregation.EditValue.ToString();
            List<CMeterUnit> lstMeterUnit = m_cMeterItemS[sDisaggregation];
            List<string> lstMeterUnitName = new List<string>();

            foreach(CMeterUnit cUnit in lstMeterUnit)
                lstMeterUnitName.Add(cUnit.Key);

            RepositoryItemComboBox exEditorEnergyUnit = (RepositoryItemComboBox)cboEnergyUnit.Edit;
            exEditorEnergyUnit.Items.AddRange(lstMeterUnitName);

            InitTagInformation();
        }

        private void cboEnergyUnit_EditValueChanged(object sender, EventArgs e)
        {
            string sDisaggregationCur = cboDisaggregation.EditValue.ToString();

            if (sDisaggregationCur == string.Empty)
                return;

            string sMeterUnitCur = cboEnergyUnit.EditValue.ToString();

            List<CMeterUnit> lstMeterUnit = m_cMeterItemS[sDisaggregationCur];

            foreach (CMeterUnit cUnit in lstMeterUnit)
            {
                if (cUnit.Key == sMeterUnitCur)
                {
                    m_cMeterUnitCur = cUnit;
                    break;
                }
            }
        }

        private void spinMergeDepth_EditValueChanged(object sender, EventArgs e)
        {
            m_iMergeDepth = int.Parse(spinMergeDepth.EditValue.ToString());
        }

        private void spinDegree_EditValueChanged(object sender, EventArgs e)
        {
            m_iRegressionDegree = int.Parse(spinDegree.EditValue.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sAddressKey = m_sAddressKeyCur;

            if (m_sAddressKeyCur == string.Empty)
                return;

            if(CProjectManager.Project.RegressionUnitS.ContainsKey(sAddressKey))
            {
                if (MessageBox.Show("해당 Unit에 대한 Regression 정보가 이미 저장되어 있습니다. 새롭게 갱신하시겠습니까?", "Energy Analysis", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            DateTime ToTime = (DateTime)dtTo.EditValue;
            DateTime FromTime = (DateTime)dtFrom.EditValue;

            CRegressionUnit cRegresUnit = new CRegressionUnit();
            cRegresUnit.Tag = CProjectManager.Project.TagItemS[sAddressKey].Tag;
            cRegresUnit.BaseEnergy = m_dBasePower;
            cRegresUnit.Degree = (int)spinDegree.EditValue;
            cRegresUnit.Disaggregation = cboDisaggregation.EditValue.ToString();
            cRegresUnit.EnergyUnit = cboEnergyUnit.EditValue.ToString();
            cRegresUnit.MergeDepth = (int)spinMergeDepth.EditValue;
            cRegresUnit.Theta = m_dThetaArray;
            cRegresUnit.TimeSpan = ToTime.Subtract(FromTime).TotalSeconds;

            CProjectManager.Project.RegressionUnitS.Add(cRegresUnit.Tag.Key, cRegresUnit);

            MessageBox.Show("Save Success!", "Energy Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnShowData_Click(object sender, EventArgs e)
        {
            string sDisaggregationCur = cboDisaggregation.EditValue.ToString();

            if (sDisaggregationCur == string.Empty)
                return;

            List<CTag> lstAllTag = (List<CTag>)gcTag.DataSource;
            int[] indexArr = gvTag.GetSelectedRows();

            if (indexArr.Length == 0)
                return;

            string sAddressKey = lstAllTag[indexArr[0]].Key;
            m_sAddressKeyCur = sAddressKey;

            ShowData(sDisaggregationCur, sAddressKey);
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}