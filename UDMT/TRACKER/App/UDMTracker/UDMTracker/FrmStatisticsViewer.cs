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

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;
using UDM.General.Statistics;

namespace UDMTracker
{
    public partial class FrmStatisticsViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CProject m_cProject = null;
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Intialize/Dispose

        public FrmStatisticsViewer()
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

        public void ShowTable(CGroupLogS cGroupLogS)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return;

            List<CStatisticsViewRow> lstRow = Analyse(cGroupLogS);
            grdMain.DataSource = lstRow;
            grdMain.Refresh();
        }

        public void Clear()
        {
            List<CStatisticsViewRow> lstRow = null;

            if(grdMain.DataSource != null)
            {
                lstRow = (List<CStatisticsViewRow>)grdMain.DataSource;
                lstRow.Clear();
                lstRow = null;
            }

            lstRow = new List<CStatisticsViewRow>();

            CGroup cGroup;
            CStatisticsViewRow cRow;
            for(int i=0;i<m_cProject.GroupS.Count;i++)
            {
                cGroup = m_cProject.GroupS[i];
                cRow = new CStatisticsViewRow();
				cRow.GroupInfo = new CGroupInfo();
				cRow.IdleInfo = new CIdleInfo();
				cRow.CycleInfo = new CCycleInfo();
				cRow.RecoveryInfo = new CRecoveryInfo();

                cRow.GroupInfo.GroupKey = cGroup.Key;
				cRow.CycleInfo.TotalCount = 0;
				cRow.CycleInfo.ErrorCount = 0;
				cRow.CycleInfo.Mean = 0;
				cRow.CycleInfo.Maximum = 0;
				cRow.CycleInfo.Minimum = 0;
				cRow.CycleInfo.StandardDev = 0;
				cRow.CycleInfo.Cp = 0;
				cRow.CycleInfo.Cpk = 0;
				cRow.IdleInfo.Mean = 0;
				cRow.IdleInfo.Minimum = 0;
				cRow.IdleInfo.Maximum = 0;
				cRow.RecoveryInfo.All = 0;
				cRow.RecoveryInfo.Mean = 0;
				cRow.RecoveryInfo.Minimum = 0;
				cRow.RecoveryInfo.Maximum = 0;

                lstRow.Add(cRow);
            }
			grdMain.DataSource = lstRow;
			grdMain.Refresh();
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

        private List<CStatisticsViewRow> Analyse(CGroupLogS cLogS)
        {
            List<CStatisticsViewRow> lstRow = new List<CStatisticsViewRow>();

            CGroup cGroup;
            CStatisticsViewRow cRow;
            CGroupLog cLog;
			CGroupLog cNextCycleLog;

            double nCycleTime;
			double nIdleTime;
			double nRecoveryTime;

			DateTime dtErrorTime = DateTime.MinValue;
			DateTime dtErrorEndTime = DateTime.MinValue;

            List<double> lstCycleTime = new List<double>();
			List<double> lstIdleTime = new List<double>();
			List<double> lstRecoveryTime = new List<double>();
            for(int i=0;i<m_cProject.GroupS.Count;i++)
            {
                cGroup = m_cProject.GroupS[i];

                cRow = new CStatisticsViewRow();
				cRow.GroupInfo = new CGroupInfo();
				cRow.CycleInfo = new CCycleInfo();
				cRow.IdleInfo = new CIdleInfo();
				cRow.RecoveryInfo = new CRecoveryInfo();

                cRow.GroupInfo.GroupKey = cGroup.Key;

                for(int j=0;j<cLogS.Count;j++)
                {
                    cLog = cLogS[j];

                    if (cLog.Key == cGroup.Key)
                    {
						// Get Cycle Info List
                        nCycleTime = GetCycleTime(cLog);

                        if(cRow.CycleInfo.Minimum == 0)
							cRow.CycleInfo.Minimum = nCycleTime;
						else if (cRow.CycleInfo.Minimum > nCycleTime)
							cRow.CycleInfo.Minimum = nCycleTime;

						if (cRow.CycleInfo.Maximum == 0)
							cRow.CycleInfo.Maximum = nCycleTime;
						else if (cRow.CycleInfo.Maximum < nCycleTime)
							cRow.CycleInfo.Maximum = nCycleTime;

						lstCycleTime.Add(nCycleTime);

						cRow.CycleInfo.TotalCount += 1;
						if (cLog.StateType == EMGroupStateType.Error || cLog.StateType == EMGroupStateType.ErrorEnd)
							cRow.CycleInfo.ErrorCount += 1;

						// Get Idle Info List
						// 현재 Log와 그 다음 Log를 비교하기 때문에 횟수 - 1이 된다.
						// 여기서 For 문의 j가 0 부터 시작했으므로 - 2가 된다.
						int k = j + 1;
						while(k <= cLogS.Count-2)
						{
							cNextCycleLog = cLogS[k];
							if(cLog.Key == cNextCycleLog.Key)
							{
								nIdleTime = GetTime(cLog.CycleEnd, cNextCycleLog.CycleStart);

								if (cRow.IdleInfo.Minimum == 0)
									cRow.IdleInfo.Minimum = nIdleTime;
								else if (cRow.IdleInfo.Minimum > nIdleTime)
									cRow.IdleInfo.Minimum = nIdleTime;

								if (cRow.IdleInfo.Maximum == 0)
									cRow.IdleInfo.Maximum = nIdleTime;
								else if (cRow.IdleInfo.Maximum < nIdleTime)
									cRow.IdleInfo.Maximum = nIdleTime;

								lstIdleTime.Add(nIdleTime);
								break;
							}
							k++;
						}

						// Get Recovery Info List

						// Recovery는 Error 이후 Error End 상태로 변환 사이를 계산
						// ErrorEnd의 CycleEnd - Error의 CycleStart 시간으로 계산
						if (cLog.StateType == EMGroupStateType.Error)
							dtErrorTime = cLog.CycleStart;

						//Error가 발생한 후의 ErrorEnd 시간 추출
						if(dtErrorTime != DateTime.MinValue)
						{
							if (cLog.StateType == EMGroupStateType.ErrorEnd)
								dtErrorEndTime = cLog.CycleEnd;

							nRecoveryTime = GetTime(dtErrorTime, dtErrorEndTime);

							if (cRow.RecoveryInfo.Minimum == 0)
								cRow.RecoveryInfo.Minimum = nRecoveryTime;
							else if (cRow.RecoveryInfo.Minimum > nRecoveryTime)
								cRow.RecoveryInfo.Minimum = nRecoveryTime;

							if (cRow.RecoveryInfo.Maximum == 0)
								cRow.RecoveryInfo.Maximum = nRecoveryTime;
							else if (cRow.RecoveryInfo.Maximum < nRecoveryTime)
								cRow.RecoveryInfo.Maximum = nRecoveryTime;

							lstRecoveryTime.Add(nRecoveryTime);
						}
                    }
                }

				cRow.CycleInfo.Minimum = Math.Round(cRow.CycleInfo.Minimum, 2);
				cRow.CycleInfo.Maximum = Math.Round(cRow.CycleInfo.Maximum, 2);
				cRow.CycleInfo.Mean = CStatics.Mean(lstCycleTime);
				if (cRow.CycleInfo.Mean == -1)
					cRow.CycleInfo.Mean = 0;
				cRow.CycleInfo.Mean = Math.Round(cRow.CycleInfo.Mean, 2);
				cRow.CycleInfo.StandardDev = CStatics.StandardDeviation(lstCycleTime);
				cRow.CycleInfo.StandardDev = Math.Round(cRow.CycleInfo.StandardDev, 2);
				cRow.CycleInfo.Cp = CStatics.Cp(cRow.CycleInfo.Maximum, cRow.CycleInfo.Minimum, cRow.CycleInfo.StandardDev);
				cRow.CycleInfo.Cp = Math.Round(cRow.CycleInfo.Cp, 2);
				cRow.CycleInfo.Cpk = CStatics.Cpk(cRow.CycleInfo.Maximum, cRow.CycleInfo.Mean, cRow.CycleInfo.StandardDev);
				cRow.CycleInfo.Cpk = Math.Round(cRow.CycleInfo.Cpk, 2);

				cRow.IdleInfo.Mean = CStatics.Mean(lstIdleTime);
				if (cRow.IdleInfo.Mean == -1)
					cRow.IdleInfo.Mean = 0;
				cRow.IdleInfo.Mean = Math.Round(cRow.IdleInfo.Mean, 2);
				cRow.IdleInfo.Minimum = Math.Round(cRow.IdleInfo.Minimum, 2);
				cRow.IdleInfo.Maximum = Math.Round(cRow.IdleInfo.Maximum, 2);

				cRow.RecoveryInfo.All = lstRecoveryTime.Sum();
				cRow.RecoveryInfo.All = Math.Round(cRow.RecoveryInfo.All, 2);
				cRow.RecoveryInfo.Mean = CStatics.Mean(lstRecoveryTime);
				if (cRow.RecoveryInfo.Mean == -1)
					cRow.RecoveryInfo.Mean = 0;
				cRow.RecoveryInfo.Mean = Math.Round(cRow.RecoveryInfo.Mean, 2);
				cRow.RecoveryInfo.Minimum = Math.Round(cRow.RecoveryInfo.Minimum, 2);
				cRow.RecoveryInfo.Maximum = Math.Round(cRow.RecoveryInfo.Maximum, 2);

                lstCycleTime.Clear();
				lstIdleTime.Clear();
				lstRecoveryTime.Clear();

                lstRow.Add(cRow);
            }

            return lstRow;
        }

        private double GetCycleTime(CGroupLog cLog)
        {
            double nValue = cLog.CycleEnd.Subtract(cLog.CycleStart).TotalSeconds;
            return nValue;
        }

		private double GetTime(DateTime dtCycleEnd, DateTime dtCycleStart)
		{
			double nValue = dtCycleStart.Subtract(dtCycleEnd).TotalSeconds;
			return nValue;
		}

        #endregion


        #region Event Methods
        
        private void FrmKPIViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                CGroupLogS cLogS = m_cReader.GetGroupLogS(dtFrom, dtTo);
                if (cLogS != null)
                    ShowTable(cLogS);
            }
            SplashScreenManager.CloseForm(false);
            
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion        

		private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{

			DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;

			CGroupLogS cLogS = m_cReader.GetGroupLogS(dtFrom, dtTo);
			if (cLogS != null)
			{
				FrmStatisticsChartViewer frmViewer = new FrmStatisticsChartViewer();
				frmViewer.StatisticsViewRowS = Analyse(cLogS);
				frmViewer.Show();
			}
		}
    }

    #region View Class

    public class CStatisticsViewRow
    {
        public CGroupInfo GroupInfo { get; set; }
		public CCycleInfo CycleInfo { get; set; }
		public CIdleInfo IdleInfo { get; set; }
		public CRecoveryInfo RecoveryInfo { get; set; }
    }

	public class CGroupInfo
	{
		public string GroupKey { get; set; }
	}
	public class CCycleInfo
	{
		public int TotalCount { get; set; }
		public int ErrorCount { get; set; }
		public double Mean { get; set; }
		public double Minimum { get; set; }
		public double Maximum { get; set; }
		public double StandardDev { get; set; }
		public double Cp { get; set; }
		public double Cpk { get; set; }
	}

	public class CIdleInfo
	{
		public double Mean { get; set; }
		public double Minimum { get; set; }
		public double Maximum { get; set; }
	}

	public class CRecoveryInfo
	{
		public double All { get; set; }
		public double Mean { get; set; }
		public double Minimum { get; set; }
		public double Maximum { get; set; }
	}

    #endregion
}