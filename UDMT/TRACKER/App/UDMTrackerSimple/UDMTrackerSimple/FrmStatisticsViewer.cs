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

using UDM.Log;
using UDM.Log.DB;
using UDM.General.Statistics;

namespace UDMTrackerSimple
{
    public partial class FrmStatisticsViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Intialize/Dispose

        public FrmStatisticsViewer()
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

        public void ShowTable(CCycleInfoS cCycleInfoS)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            List<CStatisticsViewRow> lstRow = Analyse(cCycleInfoS);
            ucProcessStatisticS.lstStatisticView = lstRow;
        }

        public void Clear()
        {
            List<CStatisticsViewRow> lstRow = null;

            ucProcessStatisticS.Clear();

            lstRow = new List<CStatisticsViewRow>();

            CPlcProc cProcess;
            CStatisticsViewRow cRow;
            for(int i=0;i<CMultiProject.PlcProcS.Count;i++)
            {
                cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                cRow = new CStatisticsViewRow();
				cRow.GroupInfo = new CGroupInfo();
				cRow.IdleInfo = new CIdleInfo();
				cRow.CycleInfoView = new CCycleInfoView();
				cRow.RecoveryInfo = new CRecoveryInfo();

                cRow.GroupInfo.GroupKey = cProcess.Name;
				cRow.CycleInfoView.TotalCount = 0;
				cRow.CycleInfoView.ErrorCount = 0;
				cRow.CycleInfoView.Mean = 0;
				cRow.CycleInfoView.Maximum = 0;
				cRow.CycleInfoView.Minimum = 0;
				cRow.CycleInfoView.StandardDev = 0;
				cRow.CycleInfoView.Cp = 0;
				cRow.CycleInfoView.Cpk = 0;
				cRow.IdleInfo.Mean = 0;
				cRow.IdleInfo.Minimum = 0;
				cRow.IdleInfo.Maximum = 0;
				cRow.RecoveryInfo.All = 0;
				cRow.RecoveryInfo.Mean = 0;
				cRow.RecoveryInfo.Minimum = 0;
				cRow.RecoveryInfo.Maximum = 0;

                lstRow.Add(cRow);
            }
        }

        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "")
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

        private List<CStatisticsViewRow> Analyse(CCycleInfoS cCycleInfoS)
        {
            List<CCycleInfo> cLogS = new List<CCycleInfo>();
            cLogS.AddRange(cCycleInfoS.Values);

            List<CStatisticsViewRow> lstRow = new List<CStatisticsViewRow>();

            CPlcProc cProcess;
            CStatisticsViewRow cRow;
            CCycleInfo cLog;
            CCycleInfo cNextCycleLog;

            double nCycleTime;
			double nIdleTime;
			double nRecoveryTime;

			DateTime dtErrorTime = DateTime.MinValue;
			DateTime dtErrorEndTime = DateTime.MinValue;

            List<double> lstCycleTime = new List<double>();
			List<double> lstIdleTime = new List<double>();
			List<double> lstRecoveryTime = new List<double>();
            for(int i=0;i<CMultiProject.PlcProcS.Count;i++)
            {
                cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                cRow = new CStatisticsViewRow();
				cRow.GroupInfo = new CGroupInfo();
				cRow.CycleInfoView = new CCycleInfoView();
				cRow.IdleInfo = new CIdleInfo();
				cRow.RecoveryInfo = new CRecoveryInfo();

                cRow.GroupInfo.GroupKey = cProcess.Name;

                for(int j=0;j<cLogS.Count;j++)
                {
                    cLog = cLogS[j];

                    if (cLog.CycleEnd == DateTime.MinValue || cLog.CycleStart == DateTime.MinValue) continue;

                    if (cLog.GroupKey.Contains(cProcess.Name))
                    {
						// Get Cycle Info List
                        nCycleTime = GetCycleTime(cLog);

                        if(cRow.CycleInfoView.Minimum == 0)
							cRow.CycleInfoView.Minimum = nCycleTime;
						else if (cRow.CycleInfoView.Minimum > nCycleTime)
							cRow.CycleInfoView.Minimum = nCycleTime;

						if (cRow.CycleInfoView.Maximum == 0)
							cRow.CycleInfoView.Maximum = nCycleTime;
						else if (cRow.CycleInfoView.Maximum < nCycleTime)
							cRow.CycleInfoView.Maximum = nCycleTime;

						lstCycleTime.Add(nCycleTime);

						cRow.CycleInfoView.TotalCount += 1;
                        if (cLog.CycleType == EMCycleRunType.Error || cLog.CycleType == EMCycleRunType.ErrorEnd)
							cRow.CycleInfoView.ErrorCount += 1;

						// Get Idle Info List
						// 현재 Log와 그 다음 Log를 비교하기 때문에 횟수 - 1이 된다.
						// 여기서 For 문의 j가 0 부터 시작했으므로 - 2가 된다.
						int k = j + 1;
						while(k <= cLogS.Count-2)
						{
							cNextCycleLog = cLogS[k];
                            if (cLog.GroupKey.Contains(cNextCycleLog.GroupKey))
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
						if (cLog.CycleType == EMCycleRunType.Error)
							dtErrorTime = cLog.CycleStart;

						//Error가 발생한 후의 ErrorEnd 시간 추출
						if(dtErrorTime != DateTime.MinValue)
						{
                            if (cLog.CycleType == EMCycleRunType.ErrorEnd)
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

				cRow.CycleInfoView.Minimum = Math.Round(cRow.CycleInfoView.Minimum, 2);
				cRow.CycleInfoView.Maximum = Math.Round(cRow.CycleInfoView.Maximum, 2);
				cRow.CycleInfoView.Mean = CStatics.Mean(lstCycleTime);
				if (cRow.CycleInfoView.Mean == -1)
					cRow.CycleInfoView.Mean = 0;
				cRow.CycleInfoView.Mean = Math.Round(cRow.CycleInfoView.Mean, 2);
				cRow.CycleInfoView.StandardDev = CStatics.StandardDeviation(lstCycleTime);
				cRow.CycleInfoView.StandardDev = Math.Round(cRow.CycleInfoView.StandardDev, 2);
				cRow.CycleInfoView.Cp = CStatics.Cp(cRow.CycleInfoView.Maximum, cRow.CycleInfoView.Minimum, cRow.CycleInfoView.StandardDev);
				cRow.CycleInfoView.Cp = Math.Round(cRow.CycleInfoView.Cp, 2);
				cRow.CycleInfoView.Cpk = CStatics.Cpk(cRow.CycleInfoView.Maximum, cRow.CycleInfoView.Mean, cRow.CycleInfoView.StandardDev);
				cRow.CycleInfoView.Cpk = Math.Round(cRow.CycleInfoView.Cpk, 2);

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

        private double GetCycleTime(CCycleInfo cLog)
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
            {
                this.Close();
                return;
            }

            InitComponent();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CCycleInfoS cTotalInfoS = new CCycleInfoS();
            CCycleInfoS cCycleInfoS = null;
            int iCycleInfoTempKey = 0;


            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.IsErrorMonitoring)
                        continue;

                    cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.Key, dtFrom, dtTo);

                    if (cCycleInfoS == null)
                        continue;

                    foreach (CCycleInfo cInfo in cCycleInfoS.Values)
                        cTotalInfoS.Add(iCycleInfoTempKey++, cInfo);
                }

                if (cTotalInfoS.Count != 0)
                    ShowTable(cTotalInfoS);
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

    }

    #region View Class

    public class CStatisticsViewRow
    {
        public CGroupInfo GroupInfo { get; set; }
		public CCycleInfoView CycleInfoView { get; set; }
		public CIdleInfo IdleInfo { get; set; }
		public CRecoveryInfo RecoveryInfo { get; set; }
    }

	public class CGroupInfo
	{
		public string GroupKey { get; set; }
	}

	public class CCycleInfoView
	{
	    private double dMean = 0;
	    private double dMin = 0;
	    private double dMax = 0;
	    private double dstd = 0;
	    private double dCp = 0;
	    private double dCpk = 0;

		public int TotalCount { get; set; }
		public int ErrorCount { get; set; }

	    public double Mean
	    {
            get { return Math.Round(dMean, 2); }
            set { dMean = value; }
	    }
		
        public double Minimum 
        {
            get { return Math.Round(dMin, 2); }
            set { dMin = value; } 
        }

	    public double Maximum
	    {
            get { return Math.Round(dMax, 2); }
            set { dMax = value; }
	    }

	    public double StandardDev
	    {
            get { return Math.Round(dstd, 2); }
            set { dstd = value; }
	    }

	    public double Cp
	    {
            get { return Math.Round(dCp, 2); }
            set { dCp = value; }
	    }

	    public double Cpk
	    {
            get { return Math.Round(dCpk, 2); }
            set { dCpk = value; }
	    }
	}

	public class CIdleInfo
	{
        private double dMean = 0;
        private double dMin = 0;
        private double dMax = 0;

        public double Mean
        {
            get { return Math.Round(dMean, 2); }
            set { dMean = value; }
        }

        public double Minimum
        {
            get { return Math.Round(dMin, 2); }
            set { dMin = value; }
        }

        public double Maximum
        {
            get { return Math.Round(dMax, 2); }
            set { dMax = value; }
        }
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