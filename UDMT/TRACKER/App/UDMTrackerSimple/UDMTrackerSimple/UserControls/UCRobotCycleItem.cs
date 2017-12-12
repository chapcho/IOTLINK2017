using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using UDM.Common;

namespace UDMTrackerSimple
{
    public partial class UCRobotCycleItem : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private int m_iStep = 0;
        private CTag m_cTag = null;
        private Stopwatch m_swItemActive = new Stopwatch();
        private TimeSpan m_tsTotalSec = new TimeSpan(0, 0, 0, 0, 0);
        private TimeSpan m_tsMaxSec = new TimeSpan(0, 0, 0, 10, 0);
        private DataTable m_tblInfo = new DataTable();
        List<double> m_lstCycleTime = new List<double>();
        List<CRobotItem> m_lstRobotItem = new List<CRobotItem>();
        System.Timers.Timer m_Timer = null;
        private string m_sMaxCycle = "";
        private string m_sAvgCycle = "";
        private bool m_bNotActive = false;
        private delegate void UpdateElapseTimeCallback();
        private delegate void UpdateStateTypeCallback(double nCycleTime);

        private int m_iCount = 0;

        #endregion


        #region Initialize

        public UCRobotCycleItem()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CTag RbtTag
        {
            get { return m_cTag; }
            set 
            { 
                m_cTag = value;
                CreateTable();
                
            }
        }

        public bool IsNotActive
        {
            get { return m_bNotActive; }
        }

        #endregion


        #region Public Method

        public void ClearData()
        {
            m_sMaxCycle = "";
            m_sAvgCycle = "";
            m_tsTotalSec = new TimeSpan(0, 0, 0, 0, 0);
            m_tsMaxSec = new TimeSpan(0, 0, 0, 10, 0);
            m_iCount = 0;
            m_lstCycleTime.Clear();
        }

        public void StopMonitor()
        {
            m_iStep = 0;

            if (m_Timer != null)
            {
                m_Timer.Stop();
                m_Timer.Dispose();
                m_Timer = null;
            }
            m_swItemActive.Stop();
            m_swItemActive.Reset();
            m_tsTotalSec = new TimeSpan(0, 0, 0, 0, 0);
            m_tsMaxSec = new TimeSpan(0, 0, 0, 0, 0);
            m_lstCycleTime.Clear();
            ucCycleTimeInfo.MaxValue = 100;
        }

        public void StopNotActiveTag()
        {
            if (m_bNotActive) return;
            StopMonitor();
            ucCycleTimeInfo.ValueBarColor = Color.DimGray;
            ucCycleTimeInfo.Value = 100;
            m_bNotActive = true;
        }

        public void SetActive()
        {
            if (m_iStep == 2)
            {
                m_swItemActive.Stop();
                m_tsTotalSec = m_swItemActive.Elapsed;
                m_lstCycleTime.Add(m_tsTotalSec.TotalSeconds);
                SetAvgValue();
                if (m_tsMaxSec < m_tsTotalSec)
                {
                    m_tsMaxSec = m_tsTotalSec;
                    m_sMaxCycle = string.Format("{0:f3}s", m_tsMaxSec.TotalSeconds);
                    SetMaxData(m_sMaxCycle);
                }

                ucCycleTimeInfo.Value = 0;
                m_swItemActive.Reset();
                m_swItemActive.Start();
                m_bNotActive = false;
            }
            else
            {
                if (m_Timer == null)
                {
                    m_Timer = new System.Timers.Timer(800);
                    m_Timer.Elapsed += m_Timer_Elapsed;
                    m_Timer.Start();
                }
                m_swItemActive.Start();
                m_iStep = 2;
            }

            UpDateRow();
        }

        #endregion


        #region Private Method

        private delegate void UpdateCallback(string sData);

        private void SetAvgData(string sData)
        {
            if (this.InvokeRequired)
            {
                UpdateCallback cUpdate = new UpdateCallback(SetAvgData);
                this.Invoke(cUpdate, new object[] { sData });
            }
            else
            {
                ucCycleTimeInfo.TopLabelText = sData;
            }
        }


        private void SetMaxData(string sData)
        {
            if (this.InvokeRequired)
            {
                UpdateCallback cUpdate = new UpdateCallback(SetMaxData);
                this.Invoke(cUpdate, new object[] { sData });
            }
            else
            {
                ucCycleTimeInfo.BottomLabelText = sData;
            }
        }

        private void CreateTable()
        {
            if (m_cTag == null) return;
            //표시항목 Tag Address, Tag Comment, 평균시간, Max시간
            lblRbtName.Text = m_cTag.Description;
            
            m_lstRobotItem.Add(new CRobotItem("Count", (m_iCount++).ToString()));
            m_lstRobotItem.Add(new CRobotItem("Address", m_cTag.Address));
            m_lstRobotItem.Add(new CRobotItem("Max Time", m_sMaxCycle));
            m_lstRobotItem.Add(new CRobotItem("Avg Time", m_sAvgCycle));

            grdInfo.DataSource = null;
            grdInfo.DataSource = m_lstRobotItem;
            grdInfo.RefreshDataSource();
        }

        private void UpDateRow()
        {
            m_lstRobotItem[0].Value = (m_iCount++).ToString();
            m_lstRobotItem[2].Value = m_sMaxCycle;
            m_lstRobotItem[3].Value = m_sAvgCycle;

            grdInfo.RefreshDataSource();
        }

        private void SetAvgValue()
        {
            if (m_lstCycleTime.Count == 0) return;
            int iCount = m_lstCycleTime.Count;
            double nSum = 0;
            for (int i = 0; i < iCount; i++)
                nSum += m_lstCycleTime[i];

            double nAvg = nSum / iCount;
            m_sAvgCycle = string.Format("{0:f3}s", nAvg);
            SetAvgData(m_sAvgCycle);
        }

        void m_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ucCycleTimeInfo.Value = (float)m_swItemActive.Elapsed.TotalSeconds;
            ElapseTime();
        }

        private void ElapseTime()
        {
            if (this.InvokeRequired)
            {
                UpdateElapseTimeCallback cbUpdateState = new UpdateElapseTimeCallback(ElapseTime);
                this.Invoke(cbUpdateState, new object[]{});
            }
            else
            {
                int iValue = (int)m_swItemActive.Elapsed.TotalSeconds;
                ucCycleTimeInfo.CircleText = iValue.ToString() + "s";
                ucCycleTimeInfo.Value = (float)m_swItemActive.Elapsed.TotalSeconds;
                ucCycleTimeInfo.MaxValue = (int)m_tsMaxSec.TotalSeconds;
            }
        }

        protected void SetElaspeTime(int iValue)
        {
            ucCycleTimeInfo.CircleText = iValue.ToString() + "s";
            ucCycleTimeInfo.Value = (float)iValue;
        }

        private void SetGroupStatus(double nCycleTime)
        {
            if (this.InvokeRequired)
            {
                UpdateStateTypeCallback cbUpdateState = new UpdateStateTypeCallback(SetGroupStatus);
                this.Invoke(cbUpdateState, new object[] { nCycleTime });
            }
            else
            {
                SetElaspeTime((int)nCycleTime);
            }
        }
		
        #endregion

    }

    class CRobotItem
    {
        public string Item { get; set; }
        public string Value { get; set; }

        public CRobotItem(string sItem, string sValue) 
        {
            Item = sItem;
            Value = sValue;
        }
    }
}
