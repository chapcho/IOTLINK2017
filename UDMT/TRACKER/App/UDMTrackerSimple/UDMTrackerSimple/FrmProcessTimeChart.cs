using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public partial class FrmProcessTimeChart : Form
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;
        
        #endregion


        #region Intialize/Dispose

        public FrmProcessTimeChart()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods

        public void ShowChart(CCycleInfoS cCycleLogS)
        {
            Clear();

            List<CCycleInfo> cViewLogS = new List<CCycleInfo>();

            cViewLogS.AddRange(cCycleLogS.Values);

            CreateSeries();

            CPlcProc cProcess;
            CCycleInfo cFirstLog = null;
            CCycleInfo cFoundLog = null;
            List<CCycleInfo> lstLog = new List<CCycleInfo>();
            int iIndex = 1;
            for (int i = 0; i < cViewLogS.Count; i++)
            {
                if(cFirstLog == null)
                {
                    cFirstLog = cViewLogS[i];
                    lstLog.Add(cFirstLog);

                    cViewLogS.RemoveAt(i);
                    i--;

                    for (int j = 0; j < CMultiProject.PlcProcS.Count; j++)
                    {
                        cProcess = CMultiProject.PlcProcS.ElementAt(j).Value;
                        if (cFirstLog.GroupKey == cProcess.Name)
                            continue;

                        cFoundLog = PopGroupLogS(cViewLogS, cProcess.Name, cFirstLog.CycleID);
                        if(cFoundLog != null)
                            lstLog.Add(cFoundLog);
                    }

                    CreateSeriesPoint(lstLog, iIndex);

                    cFirstLog = null;
                    lstLog.Clear();

                    iIndex += 1;
                }
            }
            exChart.Refresh();
        }

        public void Clear()
        {
            exChart.Series.Clear();
            exChart.Refresh();
        }

        #endregion


        #region Private Methods

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

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
            {
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;

                m_bVerified = false;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
                dtpkTo.EditValue = (DateTime)dtLast;
            }
        }

        private CCycleInfo PopGroupLogS(List<CCycleInfo> cLogS, string sGroupKey, int iCycleID)
        {
            CCycleInfo cLogFound = null;

            CCycleInfo cLog = null;
            for(int i=0;i<cLogS.Count;i++)
            {
                cLog = cLogS[i];
                if(cLog.GroupKey == sGroupKey && cLog.CycleID == iCycleID)
                {
                    cLogFound = cLog;
                    cLogS.RemoveAt(i);
                    break;
                }
            }

            return cLogFound;
        }

        private void CreateSeries()
        {
            exChart.BeginInit();

            Series exSeries = null;
            SideBySideBarSeriesLabel exLabel = null;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                if (CMultiProject.PlcProcS.ElementAt(i).Value.IsErrorMonitoring)
                    continue;

                exSeries = new Series(CMultiProject.PlcProcS.ElementAt(i).Key, ViewType.Bar);
                ((System.ComponentModel.ISupportInitialize)(exSeries)).BeginInit();
                {
                    exSeries.ArgumentScaleType = ScaleType.Numerical;
                    exSeries.ValueScaleType = ScaleType.Numerical;
                    exLabel = new SideBySideBarSeriesLabel();
                    exLabel.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
                    exSeries.Label = exLabel;
                    exSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                }
                ((System.ComponentModel.ISupportInitialize)(exSeries)).EndInit();

                exChart.Series.Add(exSeries);
            }
            
            exChart.EndInit();
        }

        private void CreateSeriesPoint(List<CCycleInfo> lstLog, int iIndex)
        {
            CCycleInfo cLog;
            Series exSeries = null;
            SeriesPoint exPoint = null;
            double nTime = 0;
            for (int i = 0; i < lstLog.Count; i++)
            {
                cLog = lstLog[i];
                nTime = cLog.CycleEnd.Subtract(cLog.CycleStart).TotalSeconds;

                exSeries = exChart.Series[cLog.GroupKey];
                exPoint = new SeriesPoint(iIndex, new object[] { nTime });
                exPoint.Tag = cLog;
                exPoint.ToolTipHint = "Process : [" + cLog.GroupKey + "]\r\nRecipe : [" + cLog.CurrentRecipe + "]";
                exSeries.Points.Add(exPoint);
            }
        }

        #endregion


        #region Event Methods

        private void FrmProcessTimeChart_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                this.Close();

            InitComponent();

            Clear();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CCycleInfoS cTotalInfoS = new CCycleInfoS();
            CCycleInfoS cCycleInfoS = null;
            int iTempCycleKey = 0;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.IsErrorMonitoring)
                        continue;

                    cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.Key, dtFrom, dtTo);

                    if (cCycleInfoS == null)
                        continue;

                    foreach (CCycleInfo cInfo in cCycleInfoS.Values)
                    {
                        if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue) continue;

                        cTotalInfoS.Add(iTempCycleKey++, cInfo);
                    }
                }

                if (cTotalInfoS.Count != 0)
                    ShowChart(cTotalInfoS);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void exChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            if (e.SeriesPoint.Tag == null)
                return;

            CCycleInfo cLog = (CCycleInfo)e.SeriesPoint.Tag;
            if (cLog.CycleType == EMCycleRunType.Error || cLog.CycleType == EMCycleRunType.ErrorEnd)
            {
                BarDrawOptions exOption = e.SeriesDrawOptions as BarDrawOptions;
                if (exOption == null)
                    return;

                exOption.FillStyle.FillMode = FillMode.Solid;
                exOption.Color = Color.OrangeRed;
            }
        }

        private void exChart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            foreach(CrosshairElement element in e.CrosshairElements)
            {
                SeriesPoint exPoint = element.SeriesPoint;
                element.LabelElement.Text = exPoint.ToolTipHint;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion
    }

}
