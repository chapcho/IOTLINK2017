﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCCycleCardWidget : DevExpress.XtraEditors.XtraUserControl
    {
        private CCycleInfo m_cCycleInfo = null;

        protected EMGroupStateType m_emStateType = EMGroupStateType.End;
        protected int m_iElapseTime = 0;
        protected double m_nAvgCycleTime = 0;
        protected double m_nMaxCycleTime = 0;


        private delegate void UpdateStateTypeCallback(EMGroupStateType emStateType, double nCycleTime);
        private delegate void UpdateElapseTimeCallback();


        public UCCycleCardWidget()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
        }

        public CCycleInfo CycleInfo
        {
            get { return m_cCycleInfo; }
            set
            {
                m_cCycleInfo = value; 
                SetCycleInfo();
            }
        }

        public double MaxCycleTime
        {
            get { return m_nMaxCycleTime; }
            set { SetMaxCycleTime(value); }
        }

        public void InitComponent()
        {
            //SetElaspeTime(0);
            UpdateCycle();
        }

        private void SetCycleInfo()
        {
            List<CCycleInfo> lstCycleInfo = new List<CCycleInfo>();
            lstCycleInfo.Add(m_cCycleInfo);

            vgrdSummary.DataSource = lstCycleInfo;

            vgrdSummary.RefreshDataSource();
        }

        public void UpdateCycle()
        {
            vgrdSummary.RefreshDataSource();
        }

        public void SetGroupStatus(EMGroupStateType emStateType, double nCycleTime)
        {
            if (this.InvokeRequired)
            {
                UpdateStateTypeCallback cbUpdateState = new UpdateStateTypeCallback(SetGroupStatus);
                this.Invoke(cbUpdateState, new object[] { emStateType, nCycleTime });
            }
            else
            {
                if (emStateType == EMGroupStateType.Start)
                {
                    ucCycleInfo.ValueBarColor = Color.GreenYellow;

                    SetElaspeTime(0);
                }
                else if (emStateType == EMGroupStateType.End)
                {
                    SetElaspeTime(0);
                }
                else if (emStateType == EMGroupStateType.Error)
                {
                    ucCycleInfo.ValueBarColor = Color.Red;
                }
                else if (emStateType == EMGroupStateType.ErrorEnd)
                {
                    SetElaspeTime(0);
                }

                m_emStateType = emStateType;
            }
        }

        public void ElapseTime()
        {
            if (this.InvokeRequired)
            {
                UpdateElapseTimeCallback cbUpdateState = new UpdateElapseTimeCallback(ElapseTime);
                this.Invoke(cbUpdateState);
            }
            else
            {
                if (m_emStateType == EMGroupStateType.Start || m_emStateType == EMGroupStateType.Error)
                {
                    m_iElapseTime += 1;
                    ucCycleInfo.CircleText = m_iElapseTime.ToString() + "s";
                    ucCycleInfo.Value = (float)m_iElapseTime;
                }
            }
        }

        protected void SetElaspeTime(int iValue)
        {
            m_iElapseTime = iValue;
            ucCycleInfo.CircleText = iValue.ToString() + "s";
            ucCycleInfo.Value = (float)iValue;
        }

        protected void SetMaxCycleTime(double nValue)
        {
            m_nMaxCycleTime = nValue;
            lblMaxText.Text = nValue.ToString("F2") + "s";
            ucCycleInfo.MaxValue = (float)nValue;
        }
    }
}
