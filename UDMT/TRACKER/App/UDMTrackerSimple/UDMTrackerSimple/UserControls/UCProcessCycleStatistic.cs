using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using UDM.General.Statistics;
using UDM.Log;
using UDM.General.Threading;

namespace UDMTrackerSimple
{
    public partial class UCProcessCycleStatistic : DevExpress.XtraEditors.XtraUserControl
    {
        private CCycleInfoS m_cCycleInfoS = null;
        private string m_sGroupKey = string.Empty;

        private int m_iSelectedIndex = 0;

        private List<double> m_lstTact = new List<double>();
        private List<double> m_lstCycle = new List<double>();
        private List<double> m_lstIdle = new List<double>(); 

        private List<CCycleStatisticView> m_lstCycleView = new List<CCycleStatisticView>();

        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;

        private Thread m_Thread = null;

        private delegate void UpdateStatisticCallback(CCycleInfo cInfo);
        private delegate void UpdateStatisticCallback2();


        public UCProcessCycleStatistic()
        {
            InitializeComponent();

            lblTitle.MouseWheel += new MouseEventHandler(All_MouseWheel);
            exChart.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grdProcess.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grvProcess.MouseWheel += new MouseEventHandler(All_MouseWheel);
            groupSeries.MouseWheel += new MouseEventHandler(All_MouseWheel);
        }

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set
            {
                m_sGroupKey = value;
                lblTitle.Text = m_sGroupKey;
            }
        }

        public CCycleInfoS CycleInfoS
        {
            get { return m_cCycleInfoS; }
            set { m_cCycleInfoS = value; }
        }

        public int SelectedRangeIndex
        {
            get { return m_iSelectedIndex; }
            set { m_iSelectedIndex = value; }
        }

        public void Clear()
        {
            try
            {
                exChart.Series["Cycle"].Points.Clear();
                exChart.Series["Process"].Points.Clear();
                exChart.Series["Idle"].Points.Clear();
                exChart.Series["Min"].Points.Clear();
                exChart.Series["Max"].Points.Clear();
                exChart.Series["UPH"].Points.Clear();
                exChart.Series["Efficiency"].Points.Clear();

                m_lstCycle.Clear();
                m_lstTact.Clear();
                m_lstIdle.Clear();

                m_lstCycleView.Clear();

                grdProcess.DataSource = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleInfoStatistic(CCycleInfo cInfo)
        {
            try
            {
                if (m_cCycleInfoS == null)
                    return;
                SetCycleStatistic(cInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void GenerateStatisticViewEvent(int iSelectedIndex)
        {
            try
            {
                Clear();

                m_dtTo = DateTime.Now;

                if (iSelectedIndex == 0)
                    m_dtFrom = m_dtTo.AddDays(-1);
                else if (iSelectedIndex == 1)
                    m_dtFrom = m_dtTo.AddDays(-7);
                else if (iSelectedIndex == 2)
                    m_dtFrom = m_dtTo.AddMonths(-1);

                CCycleInfoS cInfoS = CMultiProject.LogReader.GetCycleInfoS(CMultiProject.ProjectID, m_sGroupKey,
                    m_dtFrom, m_dtTo);

                m_cCycleInfoS = cInfoS;

                InitCycleStatistic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseWheel(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void DoWork()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateStatisticCallback2 cUpdate = new UpdateStatisticCallback2(DoWork);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    if (m_cCycleInfoS == null || m_cCycleInfoS.Count == 0)
                        return;

                    m_lstCycleView.Clear();
                    CCycleInfo cLast = m_cCycleInfoS.CurrentCycleInfo;

                    foreach (CCycleInfo cInfo in m_cCycleInfoS.Values)
                    {
                        if (cLast == cInfo) continue;
                        if (cInfo.CycleStart.Subtract(m_dtFrom).TotalSeconds < 0) continue;
                        if (cInfo.CycleType == EMCycleRunType.Error) continue;
                        if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue) continue;
                        if (CMultiProject.PlcProcS.ContainsKey(cInfo.GroupKey) &&
                            cInfo.CycleTimeValue.TotalMilliseconds > CMultiProject.PlcProcS[cInfo.GroupKey].MaxTactTime)
                            continue;

                        m_lstTact.Add(cInfo.TactTimeValue.TotalMilliseconds);
                        m_lstCycle.Add(cInfo.CycleTimeValue.TotalMilliseconds);
                        m_lstIdle.Add(cInfo.IdleTimeValue.TotalMilliseconds);
                    }

                    if (m_lstCycle.Count == 0)
                        return;

                    double dAvrTact = CStatics.Mean(m_lstTact);

                    if (CMultiProject.DicProcessTimeAvr.ContainsKey(m_sGroupKey))
                        CMultiProject.DicProcessTimeAvr[m_sGroupKey] = dAvrTact / 1000;
                    else
                        CMultiProject.DicProcessTimeAvr.Add(m_sGroupKey, dAvrTact / 1000);

                    double dAvrCycle = CStatics.Mean(m_lstCycle);
                    double dAvrIdle = CStatics.Mean(m_lstIdle);

                    CCycleStatisticView cStatisticView = new CCycleStatisticView();
                    cStatisticView.CycleTime = dAvrCycle / 1000;
                    cStatisticView.TactTime = dAvrTact / 1000;
                    cStatisticView.IdleTime = dAvrIdle / 1000;
                    cStatisticView.Min = m_lstCycle.Min() / 1000;
                    cStatisticView.Max = m_lstCycle.Max() / 1000;
                    cStatisticView.UPH = 3600000 / dAvrCycle;
                    cStatisticView.Efficiency = (dAvrTact / dAvrCycle) * 100;

                    m_lstCycleView.Add(cStatisticView);

                    grdProcess.DataSource = null;
                    grdProcess.DataSource = m_lstCycleView;
                    grdProcess.RefreshDataSource();

                    Application.DoEvents();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : {0} [{1}]", e.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);
                e.Data.Clear();
            }
            finally
            {
                SetStatisticSeries();

                //if (m_Thread != null && m_Thread.ThreadState == ThreadState.Running)
                //{
                //    if (m_Thread.ThreadState == ThreadState.WaitSleepJoin)
                //        m_Thread.Interrupt();
                //    else
                //        m_Thread.Join();

                //    while (m_Thread.IsAlive)
                //        m_Thread.Abort();

                //    m_Thread = null;
                //}
            }
        }

        private void InitTimeRange()
        {
            try
            {
                m_dtTo = DateTime.Now;

                if (m_iSelectedIndex == 0)
                    m_dtFrom = m_dtTo.AddDays(-1);
                else if (m_iSelectedIndex == 1)
                    m_dtFrom = m_dtTo.AddDays(-7);
                else if (m_iSelectedIndex == 2)
                    m_dtFrom = m_dtTo.AddMonths(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetCycleStatistic(CCycleInfo cLast)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateStatisticCallback cUpdate = new UpdateStatisticCallback(SetCycleStatistic);
                    this.Invoke(cUpdate, new object[] {cLast});
                }
                else
                {
                    if (m_cCycleInfoS == null || m_cCycleInfoS.Count == 0)
                        return;

                    m_lstCycleView.Clear();

                    //CCycleInfo cLast = m_cCycleInfoS.ElementAt(m_cCycleInfoS.Count - 1).Value;

                    if (cLast.CycleType == EMCycleRunType.Error || cLast.CycleType == EMCycleRunType.ErrorEnd ||
                        cLast.CycleType == EMCycleRunType.None) return;
                    if (cLast.CycleStart == DateTime.MinValue || cLast.CycleEnd == DateTime.MinValue) return;
                    if (CMultiProject.PlcProcS.ContainsKey(cLast.GroupKey) &&
                        cLast.CycleTimeValue.TotalMilliseconds > CMultiProject.PlcProcS[cLast.GroupKey].MaxTactTime)
                        return;

                    double dLower = CMultiProject.PlcProcS[cLast.GroupKey].TargetTactTime*0.7;

                    if (cLast.CycleTimeValue.TotalMilliseconds < dLower) return;

                    m_lstTact.Add(cLast.TactTimeValue.TotalMilliseconds);
                    m_lstCycle.Add(cLast.CycleTimeValue.TotalMilliseconds);
                    m_lstIdle.Add(cLast.IdleTimeValue.TotalMilliseconds);

                    double dAvrTact = CStatics.Mean(m_lstTact);

                    if (CMultiProject.DicProcessTimeAvr.ContainsKey(m_sGroupKey))
                        CMultiProject.DicProcessTimeAvr[m_sGroupKey] = dAvrTact/1000;
                    else
                        CMultiProject.DicProcessTimeAvr.Add(m_sGroupKey, dAvrTact/1000);

                    double dAvrCycle = CStatics.Mean(m_lstCycle);
                    double dAvrIdle = CStatics.Mean(m_lstIdle);

                    CCycleStatisticView cStatisticView = new CCycleStatisticView();
                    cStatisticView.CycleTime = dAvrCycle/1000;
                    cStatisticView.TactTime = dAvrTact/1000;
                    cStatisticView.IdleTime = dAvrIdle/1000;
                    cStatisticView.Min = m_lstCycle.Min()/1000;
                    cStatisticView.Max = m_lstCycle.Max()/1000;
                    cStatisticView.UPH = 3600000/dAvrCycle;
                    cStatisticView.Efficiency = (dAvrTact/dAvrCycle)*100;

                    m_lstCycleView.Add(cStatisticView);

                    grdProcess.DataSource = null;
                    grdProcess.DataSource = m_lstCycleView;
                    grdProcess.RefreshDataSource();

                    SetStatisticSeries();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetStatisticSeries()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateStatisticCallback2 cUpdate = new UpdateStatisticCallback2(SetStatisticSeries);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (m_lstCycleView.Count == 0)
                        return;

                    CCycleStatisticView cView = m_lstCycleView.Last();

                    SeriesPoint cPoint = null;

                    if (chkCycle.Checked)
                    {
                        if (exChart.Series["Cycle"].Points.Count != 0)
                            exChart.Series["Cycle"].Points[0].Values[0] = cView.CycleTime;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.CycleTime});
                            exChart.Series["Cycle"].Points.Add(cPoint);
                        }
                    }
                    if (chkTact.Checked)
                    {
                        if (exChart.Series["Process"].Points.Count != 0)
                            exChart.Series["Process"].Points[0].Values[0] = cView.TactTime;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.TactTime});
                            exChart.Series["Process"].Points.Add(cPoint);
                        }
                    }
                    if (chkIdle.Checked)
                    {
                        if (exChart.Series["Idle"].Points.Count != 0)
                            exChart.Series["Idle"].Points[0].Values[0] = cView.IdleTime;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.IdleTime});
                            exChart.Series["Idle"].Points.Add(cPoint);
                        }
                    }
                    if (chkMax.Checked)
                    {
                        if (exChart.Series["Max"].Points.Count != 0)
                            exChart.Series["Max"].Points[0].Values[0] = m_lstCycle.Max()/1000;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {m_lstCycle.Max()/1000});
                            exChart.Series["Max"].Points.Add(cPoint);
                        }
                    }
                    if (chkMin.Checked)
                    {
                        if (exChart.Series["Min"].Points.Count != 0)
                            exChart.Series["Min"].Points[0].Values[0] = m_lstCycle.Min()/1000;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.Min});
                            exChart.Series["Min"].Points.Add(cPoint);
                        }
                    }
                    if (chkUPH.Checked)
                    {
                        if (exChart.Series["UPH"].Points.Count != 0)
                            exChart.Series["UPH"].Points[0].Values[0] = cView.UPH;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.UPH});
                            exChart.Series["UPH"].Points.Add(cPoint);
                        }
                    }
                    if (chkEffi.Checked)
                    {
                        if (exChart.Series["Efficiency"].Points.Count != 0)
                            exChart.Series["Efficiency"].Points[0].Values[0] = cView.Efficiency;
                        else
                        {
                            cPoint = new SeriesPoint(m_sGroupKey, new double[] {cView.Efficiency});
                            exChart.Series["Efficiency"].Points.Add(cPoint);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void InitCycleStatistic()
        {
            try
            {
                if (m_Thread != null && m_Thread.ThreadState != ThreadState.Stopped)
                {
                    if(m_Thread.ThreadState == ThreadState.WaitSleepJoin)
                        m_Thread.Interrupt();
                    else
                        m_Thread.Abort();

                    m_Thread = null;
                }

                m_Thread = new Thread(new ThreadStart(DoWork));
                m_Thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCGroupCycleStatistic_Load(object sender, EventArgs e)
        {
            try
            {
                InitTimeRange();

                Clear();

                InitCycleStatistic();
                SetStatisticSeries();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkCycle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCycle.Checked)
                {
                    exChart.Series["Cycle"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Cycle"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkTact_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTact.Checked)
                {
                    exChart.Series["Process"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Process"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMin_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMin.Checked)
                {
                    exChart.Series["Min"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Min"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkIdle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIdle.Checked)
                {
                    exChart.Series["Idle"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Idle"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMax_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMax.Checked)
                {
                    exChart.Series["Max"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Max"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkUPH_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUPH.Checked)
                {
                    exChart.Series["UPH"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["UPH"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkEffi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkEffi.Checked)
                {
                    exChart.Series["Efficiency"].Visible = true;
                    SetStatisticSeries();
                }
                else
                    exChart.Series["Efficiency"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }

    public partial class CCycleStatisticView
    {
        private double m_dCycle = 0;
        private double m_dTact = 0;
        private double m_dIdle = 0;
        private double m_dMin = 0;
        private double m_dMax = 0;
        private double m_dUPH = 0;
        private double m_dEfficiency = 0;
        private int m_iTotalCount = 0;
        private int m_iErrorCount = 0;
        private int m_iDelayCount = 0;
        private string m_sProcessKey = string.Empty;

        public string ProcessKey
        {
            get { return m_sProcessKey;}
            set { m_sProcessKey = value; }
        }

        public int TotalCount
        {
            get { return m_iTotalCount; }
            set { m_iTotalCount = value; }
        }

        public int ErrorCount
        {
            get { return m_iErrorCount;}
            set { m_iErrorCount = value; }
        }

        public int DelayCount
        {
            get { return m_iDelayCount; }
            set { m_iDelayCount = value; }
        }

        public double CycleTime
        {
            get { return Math.Round(m_dCycle, 2); }
            set { m_dCycle = value; }
        }

        public double TactTime
        {
            get { return Math.Round(m_dTact, 2); }
            set { m_dTact = value; }
        }

        public double IdleTime
        {
            get { return Math.Round(m_dIdle, 2); }
            set { m_dIdle = value; }
        }

        public double Min
        {
            get { return Math.Round(m_dMin, 2); }
            set { m_dMin = value; }
        }

        public double Max
        {
            get { return Math.Round(m_dMax, 2); }
            set { m_dMax = value; }
        }

        public double UPH
        {
            get { return Math.Round(m_dUPH, 2); }
            set { m_dUPH = value; }
        }

        public double Efficiency
        {
            get { return Math.Round(m_dEfficiency, 2); }
            set { m_dEfficiency = value; }
        }
    }
}

