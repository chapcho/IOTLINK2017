using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Log;
using UDM.Monitor.Energy;
using UDM.Log.DB;
using System.Windows.Forms;
using System.Data;

namespace SmartEnergyVision
{
    public class CEnergyDataAnalysis:IDisposable
    {
        #region Member Variables

        protected CPostSqlLogReader m_cDBRead = null;
        protected CEnergyConfig m_cConfig = null;
        #endregion

        #region Initialize/Dispose

        public CEnergyDataAnalysis()
        {
            m_cDBRead = new CPostSqlLogReader();
        }

        public void Dispose()
        {
            m_cDBRead.Dispose();
        }

        #endregion

        #region Public Properties

        public CEnergyConfig Config
        {
            set { m_cConfig = value; }
        }

        //public DataTable RealTimeDT
        //{
        //    get { return m_dtPowerDT; }
        //    set { m_dtPowerDT = value; }
        //}

        #endregion

        #region public Methods

        public DataTable RealTimePowerDataAnalysis()
        {
            DataTable dt = CreateRealTimePowerDT();

            return dt;
        }

        public DataTable PerDayDataAnalysis(out int RunCount, out int PauseCount, out int StopCount, out int RunPower, out int PausePower, out int StopPower)
        {
            DateTime perDay = DateTime.Now.AddDays(-1);

            DateTime dtFrom = new DateTime(perDay.Year, perDay.Month, perDay.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(perDay.Year, perDay.Month, perDay.Day, 23, 59, 0);

            CEnergyLogS Logs = m_cDBRead.GetEnergyLogS(dtFrom, dtTo);

            DataTable barChartData = OneDayBarDataAnalysis(Logs);

            PieChartDataAnalysis(Logs, out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);

            return barChartData;
        }

        public DataTable PerWeekDataAnalysis(out int RunCount, out int PauseCount, out int StopCount, out int RunPower, out int PausePower, out int StopPower)
        {
            DateTime perDay = DateTime.Now.AddDays(-1);
            DateTime Per7Day = DateTime.Now.AddDays(-7);
            DateTime dtFrom = new DateTime(Per7Day.Year, Per7Day.Month, Per7Day.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(perDay.Year, perDay.Month, perDay.Day, 23, 59, 0);

            CEnergyLogS Logs = m_cDBRead.GetEnergyLogS(dtFrom, dtTo);

            DataTable barChartData = OneWeekBarDataAnalysis(Logs);
            PieChartDataAnalysis(Logs, out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);

            return barChartData;
        }

        public DataTable PerMonthDataAnalysis(out int RunCount, out int PauseCount, out int StopCount, out int RunPower, out int PausePower, out int StopPower)
        {
            DateTime perDay = DateTime.Now.AddDays(-1);
            DateTime Per35Day = DateTime.Now.AddDays(35);
            DateTime dtFrom = new DateTime(Per35Day.Year, Per35Day.Month, Per35Day.Day, 0, 0, 0);
            DateTime dtTo = new DateTime(perDay.Year, perDay.Month, perDay.Day, 23, 59, 0);

            CEnergyLogS Logs = m_cDBRead.GetEnergyLogS(dtFrom, dtTo);

            DataTable barChartData = OneMouthBarDataAnalysis(Logs);
            PieChartDataAnalysis(Logs, out RunCount, out PauseCount, out StopCount, out RunPower, out PausePower, out StopPower);

            return barChartData;
        }

        #endregion

        #region Private Methods

        private DataTable CreateRealTimePowerDT()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Time", typeof(string)));
            dt.Columns.Add(new DataColumn("RefValue", typeof(int)));
            dt.Columns.Add(new DataColumn("RefValue", typeof(int)));

            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.NewRow();

                dr[0] = i.ToString() + ":00";
                dr[1] = 0;
                dr[2] = 0;

                dr[0] = i.ToString() + ":30";
                dr[1] = 0;
                dr[2] = 0;
            }

            return dt;
        }

        private bool ConnectDB()
        {
            bool bOK = m_cDBRead.Connect();

            return bOK;
        }

        private bool DisConnectDB()
        {
            bool bOk = m_cDBRead.Disconnect();
            return bOk;
        }

        private void PieChartDataAnalysis(CEnergyLogS Logs, out int RunCount,out int PauseCount, out int StopCount, out int RunPower, out int PausePower, out int StopPower)
        {
            RunCount = 0;
            PauseCount =0;
            StopCount =0;
            RunPower =0;
            PausePower =0;
            StopPower =0;

            int iBasePower = 0;
            bool bFrist = true;
            foreach(CEnergyLog clog in Logs)
            {
                if (bFrist)
                    iBasePower = clog.TotalKwh;

                bFrist = false;
                if(clog.ActiveTotal > m_cConfig.RunningPauseRate)
                {
                    RunCount++;
                    RunPower = RunPower + clog.TotalKwh - iBasePower;
                }
                else if(clog.ActiveTotal<m_cConfig.PauseStopRate)
                {
                    StopCount++;
                    StopPower = StopPower + clog.TotalKwh - iBasePower;
                }
                else
                {
                    PauseCount++;
                    PausePower = PausePower + clog.TotalKwh - iBasePower;
                }
            }
        }

        private DataTable OneDayBarDataAnalysis(CEnergyLogS Logs)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Time",typeof(int)));
            dt.Columns.Add(new DataColumn("RealPH", typeof(int)));

            int lastTimeValue = 0;

            for (int i = 0; i < Logs.Count;i++ )
            {
                CEnergyLog log = Logs[i];

                if(i==0)
                    lastTimeValue = log.TotalKwh;
                
                if(i==Logs.Count -1)
                {
                    int iPower = log.TotalKwh - lastTimeValue;
                    int iTime = log.Time.Hour;

                    DataRow dr = dt.NewRow();
                    dr[0] = iTime;
                    dr[1] = iPower;
                    lastTimeValue = log.TotalKwh;

                    dt.Rows.Add(dr);
                }
                else
                {
                    if(log.Time.Hour != Logs[i+1].Time.Hour)
                    {
                        int iPower = log.TotalKwh - lastTimeValue;
                        int iTime = log.Time.Hour;

                        DataRow dr = dt.NewRow();
                        dr[0] = iTime;
                        dr[1] = iPower;
                        lastTimeValue = log.TotalKwh;

                        dt.Rows.Add(dr);
                    }
                }
                
            }

            return dt;
        }

        private DataTable OneWeekBarDataAnalysis(CEnergyLogS Logs)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Time",typeof(int)));
            dt.Columns.Add(new DataColumn("RealPH", typeof(int)));

            int lastTimeValue = 0;

            for (int i = 0; i < Logs.Count; i++)
            {
                CEnergyLog log = Logs[i];

                if (i == 0)
                    lastTimeValue = log.TotalKwh;

                if (i == Logs.Count - 1)
                {
                    int iPower = log.TotalKwh - lastTimeValue;
                    int iTime = log.Time.Day;

                    DataRow dr = dt.NewRow();
                    dr[0] = iTime;
                    dr[1] = iPower;
                    lastTimeValue = log.TotalKwh;

                    dt.Rows.Add(dr);
                }
                else
                {
                    if (log.Time.Day != Logs[i + 1].Time.Day)
                    {
                        int iPower = log.TotalKwh - lastTimeValue;
                        int iTime = log.Time.Day;

                        DataRow dr = dt.NewRow();
                        dr[0] = iTime;
                        dr[1] = iPower;
                        lastTimeValue = log.TotalKwh;

                        dt.Rows.Add(dr);
                    }
                }

            }

            return dt;
        }

        private DataTable OneMouthBarDataAnalysis(CEnergyLogS Logs)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Time", typeof(int)));
            dt.Columns.Add(new DataColumn("RealPH", typeof(int)));

            int lastTimeValue = 0;
            int LastWeekEnd = 0;
            int weekCount =1;

            for (int i = 0; i < Logs.Count; i++)
            {
                CEnergyLog log = Logs[i];

                if (i == 0)
                {
                    lastTimeValue = log.TotalKwh;
                    LastWeekEnd = log.Time.Day;
                }                   

                if (i == Logs.Count - 1)
                {
                    int iPower = log.TotalKwh - lastTimeValue;

                    DataRow dr = dt.NewRow();
                    dr[0] = weekCount;
                    weekCount++;
                    dr[1] = iPower;
                    lastTimeValue = log.TotalKwh;
                    LastWeekEnd = log.Time.Day;
                    dt.Rows.Add(dr);
                }
                else
                {
                    if ((log.Time.Day != Logs[i + 1].Time.Day) && (log.Time.Day-LastWeekEnd == 7))
                    {
                        int iPower = log.TotalKwh - lastTimeValue;

                        DataRow dr = dt.NewRow();
                        dr[0] = weekCount;
                        weekCount++;
                        dr[1] = iPower;
                        lastTimeValue = log.TotalKwh;
                        LastWeekEnd = log.Time.Day;
                        dt.Rows.Add(dr);
           
                    }
                }

            }

            return dt;
        }
        #endregion
    }
}
