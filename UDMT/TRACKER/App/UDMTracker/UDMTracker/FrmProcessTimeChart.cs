using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;

namespace UDMTracker
{
    public partial class FrmProcessTimeChart : Form
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CProject m_cProject = null;
        private CMySqlLogReader m_cReader = null;
        
        #endregion


        #region Intialize/Dispose

        public FrmProcessTimeChart()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods

        public void ShowChart(CGroupLogS cLogS)
        {
            Clear();

            CGroupLogS cViewLogS = new CGroupLogS();
            cViewLogS.AddRange(cLogS);

            CreateSeries(m_cProject.GroupS);

            CGroup cGroup;
            CGroupLog cFirstLog = null;
            CGroupLog cFoundLog = null;
            List<CGroupLog> lstLog = new List<CGroupLog>();
            int iIndex = 1;
            for (int i = 0; i < cViewLogS.Count; i++)
            {
                if(cFirstLog == null)
                {
                    cFirstLog = cViewLogS[i];
                    lstLog.Add(cFirstLog);
                    
                    cViewLogS.RemoveAt(i);
                    i--;

                    for (int j = 0; j < m_cProject.GroupS.Count; j++)
                    {
                        cGroup = m_cProject.GroupS[j];
                        if (cFirstLog.Key == cGroup.Key)
                            continue;

                        cFoundLog = PopGroupLogS(cViewLogS, cGroup.Key, cFirstLog.Product);
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
            if (m_cProject == null)
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private CGroupLog PopGroupLogS(CGroupLogS cLogS, string sGroupKey, string sProudct)
        {
            CGroupLog cLogFound = null;

            CGroupLog cLog = null;
            for(int i=0;i<cLogS.Count;i++)
            {
                cLog = cLogS[i];
                if(cLog.Key == sGroupKey && cLog.Product == sProudct)
                {
                    cLogFound = cLog;
                    cLogS.RemoveAt(i);
                    break;
                }
            }

            return cLogFound;
        }

        private void CreateSeries(CGroupS cGroupS)
        {
            exChart.BeginInit();

            Series exSeries = null;
            SideBySideBarSeriesLabel exLabel = null;
            for (int i = 0; i < cGroupS.Count; i++)
            {
                exSeries = new Series(cGroupS[i].Key, ViewType.Bar);
                ((System.ComponentModel.ISupportInitialize)(exSeries)).BeginInit();
                {
                    exSeries.ArgumentScaleType = ScaleType.Qualitative;
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

        private void CreateSeriesPoint(List<CGroupLog> lstLog, int iIndex)
        {
            CGroupLog cLog;
            Series exSeries = null;
            SeriesPoint exPoint = null;
            double nTime = 0;
            for (int i = 0; i < lstLog.Count; i++)
            {
                cLog = lstLog[i];
                nTime = cLog.CycleEnd.Subtract(cLog.CycleStart).TotalSeconds;

                exSeries = exChart.Series[cLog.Key];
                exPoint = new SeriesPoint(iIndex, new object[] { nTime });
                exPoint.Tag = cLog;
                exPoint.ToolTipHint = "Group : [" + cLog.Key + "]\r\nRecipe : [" + cLog.Recipe + "]\r\nProduct : [" + cLog.Product + "]";
                exSeries.Points.Add(exPoint);
            }
        }

        #endregion


        #region Event Methods

        private void FrmProcessTimeChart_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();

            Clear();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CGroupLogS cLogS = m_cReader.GetGroupLogS(dtFrom, dtTo);
            if (cLogS != null)
                ShowChart(cLogS);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void exChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            if (e.SeriesPoint.Tag == null)
                return;

            CGroupLog cLog = (CGroupLog)e.SeriesPoint.Tag;
            if(cLog.StateType == EMGroupStateType.Error || cLog.StateType == EMGroupStateType.ErrorEnd)
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
