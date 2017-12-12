using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;

using UDM.Log.DB;
using UDM.Log;
using UDM.Monitor.Energy;

namespace SmartEnergyVision
{
    public partial class FrmMain : XtraForm
    {

        #region Member Variables

        protected FrmSetting m_frmSetting = null;

        protected float m_fMaxCurrent = 100;
        protected float m_fMaxVoltage = 800;
        protected float m_fMinCurrent = 0;
        protected float m_fMinVoltage = 0;

        protected DataTable m_dtTotalPower = null;

        protected CEnergyDataAnalysis m_cEnergyDataAnalysis = null;
        protected CMonitorEnergy m_cMonitor = null;
        protected CEnergyConfig m_cConfig = null;
        #endregion


        #region Intialize/Dispose

        public FrmMain()
        {
            InitializeComponent();
            FormartRealPowerDT();
            m_cEnergyDataAnalysis = new CEnergyDataAnalysis();
            m_cMonitor = new CMonitorEnergy();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Mehtods


        #endregion


        #region Private Methods

        private void SetGaugesMaxValue(float PhaseA, float PhaseB, float PhaseC)
        {
            if (PhaseA > m_fMaxCurrent)
                m_fMaxCurrent = PhaseA+10;
            if (PhaseB > m_fMaxCurrent)
                m_fMaxCurrent = PhaseB + 10;
            if (PhaseC > m_fMaxCurrent)
                m_fMaxCurrent = PhaseC + 10;

            arcScaleComponent1.MaxValue = m_fMaxCurrent;
            arcScaleComponent2.MaxValue = m_fMaxCurrent;
            arcScaleComponent3.MaxValue = m_fMaxCurrent;
        }

        private void MakeRTVoltageDT(float PhaseA, float PhaseB, float PhaseC, bool isPhase)
        {
           
            //this.ccRTRealTimeVoltageChart.DataSource = m_dtRTVoltage;
            this.ccRTRealTimeVoltageChart.Series[0].Points[0].Values[0] = PhaseA;// .ArgumentDataMember = "PhaseName";
            this.ccRTRealTimeVoltageChart.Series[0].Points[1].Values[0] = PhaseB;
            this.ccRTRealTimeVoltageChart.Series[0].Points[2].Values[0] = PhaseC;
            //this.ccRTRealTimeVoltageChart.Series[0].ValueDataMembers[0] = "PhaseData";

            this.ccRTRealTimeVoltageChart.RefreshData();
        }
       
        private void MakeRealPowerDT(int RealPower,DateTime time)
        {
            string sTime = time.ToString("HH:mm");
            
            if(sTime[sTime.Length-1]=='0')
            {
                bool isFind = false;
                foreach(DataRow dr in m_dtTotalPower.Rows)
                {
                    if(dr[0]== sTime)
                    {
                        dr[2] = RealPower;
                        isFind = true;
                    }
                }

                if(!isFind)
                {
                    DataRow dr = m_dtTotalPower.NewRow();
                    dr[0] = sTime;
                    dr[2] = RealPower;

                    m_dtTotalPower.Rows.Add(dr);
                }

                this.ccRTRealTimeVoltageChart.DataSource = m_dtTotalPower;
                this.ccRTRealTimeVoltageChart.Series[0].ArgumentDataMember = "DateTime";
                this.ccRTRealTimeVoltageChart.Series[0].ValueDataMembers[0] = "RealValue";

                this.ccRTRealTimeVoltageChart.Series[1].ArgumentDataMember = "DateTime";
                this.ccRTRealTimeVoltageChart.Series[1].ValueDataMembers[0] = "RefValue";

                this.ccRTRealTimeVoltageChart.RefreshData();
            }
        }

        private void FormartRealPowerDT()
        {
            m_dtTotalPower = new DataTable();

            m_dtTotalPower.Columns.Add(new DataColumn("DateTime", typeof(string)));
            m_dtTotalPower.Columns.Add(new DataColumn("RefValue", typeof(Int32)));
            m_dtTotalPower.Columns.Add(new DataColumn("RealValue", typeof(Int32)));
        }

        private void PerDayDataAnalysis()
        {
            int RunCount = 0;
            int PauseCount = 0;
            int StopCount = 0;
            int RunPower = 0;
            int PausePower = 0;
            int StopPower = 0;

            DataTable BraChart = m_cEnergyDataAnalysis.PerDayDataAnalysis(out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);

            this.crADPreDayPieChart.Series[0].Points[0].Values[0] = RunCount;
            this.crADPreDayPieChart.Series[0].Points[1].Values[0] = PauseCount;
            this.crADPreDayPieChart.Series[0].Points[2].Values[0] = StopCount;
            this.crADPreDayPieChart.Series[1].Points[0].Values[0] = RunPower;
            this.crADPreDayPieChart.Series[1].Points[1].Values[0] = PausePower;
            this.crADPreDayPieChart.Series[1].Points[2].Values[0] = StopPower;

            this.crADPreDayPieChart.RefreshData();

            for(int i =0;i<24;i++)
            {
                DataRow dr = BraChart.Rows[i];

                this.ccADPerDayBarChart.Series[0].Points[i].Values[0] = Convert.ToDouble( dr[1]);
            }
            this.ccADPerDayBarChart.RefreshData();
        }

        private void PerWeekDataAnalysis()
        {
            int RunCount = 0;
            int PauseCount = 0;
            int StopCount = 0;
            int RunPower = 0;
            int PausePower = 0;
            int StopPower = 0;

            DataTable BraChart = m_cEnergyDataAnalysis.PerWeekDataAnalysis(out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);


            this.ccADPreWeekPieChart.Series[0].Points[0].Values[0] = RunCount;
            this.ccADPreWeekPieChart.Series[0].Points[1].Values[0] = PauseCount;
            this.ccADPreWeekPieChart.Series[0].Points[2].Values[0] = StopCount;
            this.ccADPreWeekPieChart.Series[1].Points[0].Values[0] = RunPower;
            this.ccADPreWeekPieChart.Series[1].Points[1].Values[0] = PausePower;
            this.ccADPreWeekPieChart.Series[1].Points[2].Values[0] = StopPower;

            this.ccADPreWeekPieChart.RefreshData();

            for (int i = 0; i < 7; i++)
            {
                DataRow dr = BraChart.Rows[i];

                this.ccADPerWeekBarChart.Series[0].Points[i].Values[0] = Convert.ToDouble(dr[1]);
            }
            this.ccADPerWeekBarChart.RefreshData();
        }

        private void PerMonthDataAnalysis()
        {
            int RunCount = 0;
            int PauseCount = 0;
            int StopCount = 0;
            int RunPower = 0;
            int PausePower = 0;
            int StopPower = 0;

            DataTable BraChart = m_cEnergyDataAnalysis.PerMonthDataAnalysis(out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);


            this.ccADPreMonthPieChart.Series[0].Points[0].Values[0] = RunCount;
            this.ccADPreMonthPieChart.Series[0].Points[1].Values[0] = PauseCount;
            this.ccADPreMonthPieChart.Series[0].Points[2].Values[0] = StopCount;
            this.ccADPreMonthPieChart.Series[1].Points[0].Values[0] = RunPower;
            this.ccADPreMonthPieChart.Series[1].Points[1].Values[0] = PausePower;
            this.ccADPreMonthPieChart.Series[1].Points[2].Values[0] = StopPower;

            this.ccADPreMonthPieChart.RefreshData();

            for (int i = 0; i < 5; i++)
            {
                DataRow dr = BraChart.Rows[i];

                this.ccADPreMonthBarChart.Series[0].Points[i].Values[0] = Convert.ToDouble(dr[1]);
            }
            this.ccADPreMonthBarChart.RefreshData();
        }

        #endregion


        #region Event Methods

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

 
        private void btnSetting_Click(object sender, EventArgs e)
        {
            m_frmSetting = new FrmSetting();
            m_frmSetting.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(m_frmSetting!=null)
            {
                m_cConfig = m_frmSetting.EnergyConfig;
            }

            m_cEnergyDataAnalysis.Config = m_cConfig;
            m_cMonitor.Config = m_cConfig;
            m_cMonitor.UEventRealTimeDataRead += cMonitorRealTimeDataRead;

            lblMeterStatus.Text = "Running";
            //PerDayDataAnalysis();
            //PerWeekDataAnalysis();
            //PerMonthDataAnalysis();
            m_cMonitor.RunEnergyMonitor();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            m_cMonitor.StopEnergyMonitor();
            m_cMonitor.UEventRealTimeDataRead -= cMonitorRealTimeDataRead;
            lblMeterStatus.Text = "Stop";
        }

        private void cMonitorRealTimeDataRead(object sender, CEnergyLog cLog)
        {
            try
            {
                float fPhaseACurrent = cLog.CurrentA;
                float fPhaseBCurrent = cLog.CurrentB;
                float fPhaseCCurrent = cLog.CurrentC;
                float fValA = cLog.VoltageA;
                float fValB = cLog.VoltageB;
                float fValC = cLog.VoltageC;
                float fValAB = cLog.VoltageAB;
                float fValBC = cLog.VoltageBC;
                float fValCA = cLog.VoltageCA;
                float fTotalKw = cLog.TotalKwh;
                float fTotalKvar = cLog.TotalKvarh;

                SetGaugesMaxValue(fPhaseACurrent, fPhaseBCurrent, fPhaseCCurrent);


                arcScaleRangeBarComponent1.Value = fPhaseACurrent;
                arcScaleRangeBarComponent2.Value = fPhaseBCurrent;
                arcScaleRangeBarComponent3.Value = fPhaseCCurrent;
                lblRTPhaseACurrent.Text = fPhaseACurrent.ToString("0000.00");
                lblRTPhaseBCurrent.Text = fPhaseBCurrent.ToString("0000.00");
                lblRTPhaseCCurrent.Text = fPhaseCCurrent.ToString("0000.00");


                if (fValA < 1 && fValB < 1 && fValC < 1)
                {
                    MakeRTVoltageDT(fValAB, fValBC, fValCA, false);
                }
                else
                    MakeRTVoltageDT(fValA, fValB, fValC, true);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        #endregion

        private void ccRTRealTimeVoltageChart_Click(object sender, EventArgs e)
        {

        }


       

        
    }
}