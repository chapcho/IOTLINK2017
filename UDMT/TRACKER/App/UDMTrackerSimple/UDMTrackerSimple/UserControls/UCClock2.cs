using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGauges.Core.Model;
using UDM.Log;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerChangeTime(DateTime dtTime, CTeamInfo cInfo);
    public delegate void UEventHandlerOperationTimeChecker(bool bStartTime);

    public partial class UCClock2 : DevExpress.XtraEditors.XtraUserControl
    {
        private CTeamInfoS m_cTeamInfoS = null;
        private bool m_bAlarmOn = false;
        private int m_iMinute = 0;
        System.Globalization.CultureInfo m_cCulture = new System.Globalization.CultureInfo("ko-KR");
        public event UEventHandlerChangeTime UEventChangeTime = null;
        public event UEventHandlerOperationTimeChecker UEventOperationTimeChecker = null;

        public UEventHandlerTrackerMessage UEventMessage = null;

        private bool m_bFirst = true;
        private bool m_bOperFirst = true;

        public UCClock2()
        {
            InitializeComponent();
        }

        public CTeamInfoS TeamInfoS
        {
            get { return m_cTeamInfoS; }
            set { m_cTeamInfoS = value; }
        }

        public bool IsOperFirst
        {
            get { return m_bOperFirst; }
            set { m_bOperFirst = value; }
        }

        private void SetTeamInfo(DateTime dtNow)
        {
            int iNowHour = dtNow.Hour;
            int iNowMin = dtNow.Minute;

            foreach (var who in m_cTeamInfoS)
            {
                if (who.Value.From.Hour == iNowHour && who.Value.From.Minute == iNowMin && m_bAlarmOn == false)
                {
                    if (UEventChangeTime != null)
                        UEventChangeTime(DateTime.Now, who.Value);
                    m_bAlarmOn = true;
                    m_iMinute = iNowMin;
                }
                else if (m_bAlarmOn)
                {
                    if (m_iMinute + 1 <= iNowMin) m_bAlarmOn = false;
                }
            }
        }

        private void ClearDayMemory(DateTime dtNow)
        {
            if (dtNow.Hour.Equals(23) && dtNow.Minute.Equals(59))
            {
                if (m_bFirst)
                {
                    if (UEventMessage != null)
                        UEventMessage("Clear Memory",
                            string.Format("GC Collect 수행 Start {0:N0}", GC.GetTotalMemory(false)));

                    CMultiProject.ClearMemory();
                    GC.Collect();

                    if (UEventMessage != null)
                        UEventMessage("Clear Memory", string.Format("GC Collect 수행 End {0:N0}", GC.GetTotalMemory(true)));
                }

                m_bFirst = false;
            }
            else
                m_bFirst = true;
        }
         
        private void OperationTimeCheck(DateTime dtNow)
        {
            if (CMultiProject.OperStartTime != DateTime.MinValue && CMultiProject.OperEndTime != DateTime.MinValue)
            {
                if (dtNow.Hour == CMultiProject.OperStartTime.Hour && dtNow.Minute == CMultiProject.OperStartTime.Minute)
                {
                    if (m_bOperFirst)
                    {
                        m_bOperFirst = false;

                        if (UEventOperationTimeChecker != null)
                            UEventOperationTimeChecker(true);

                        if (UEventMessage != null)
                        { 
                            UEventMessage("Operation Start Time", "Monitoring Auto Start!!");
                        }

                    }
                }
                else if (dtNow.Hour == CMultiProject.OperEndTime.Hour && dtNow.Minute == CMultiProject.OperEndTime.Minute)
                {                    
                    if (!m_bOperFirst)
                    {
                        m_bOperFirst = true;

                        if (UEventOperationTimeChecker != null)
                            UEventOperationTimeChecker(false);

                        if (UEventMessage != null)
                        {
                            UEventMessage("Operation End Time", "Monitoring Auto Stop!!");
                        }
                    }
                }
                //else
                    //m_bOperFirst = true;
            }
        }

        private void UCClock_Load(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            string sTime = string.Format("{0}   {1}", dtNow.ToString("yyyy년 MM월 dd일 ddd요일", m_cCulture).ToUpper(), dtNow.ToString("tt hh : mm : ss"));
            lblTime.Text = sTime;

            tmrTimer.Start();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            
            string sTime = string.Format("{0}   {1}", dtNow.ToString("yyyy년 MM월 dd일 ddd요일", m_cCulture).ToUpper(), dtNow.ToString("tt hh : mm : ss"));
            lblTime.Text = sTime;

            lblTime.Refresh();

            if (m_cTeamInfoS != null)
                SetTeamInfo(dtNow);

            ClearDayMemory(dtNow);
            OperationTimeCheck(dtNow);
        }
    }
}

