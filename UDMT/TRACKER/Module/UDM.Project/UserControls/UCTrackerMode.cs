using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDM.Project
{
    public partial class UCTrackerMode : DevExpress.XtraEditors.XtraUserControl
    {
        private UDM.Log.EMMonitorType m_emTrackerMode = Log.EMMonitorType.Detection;
        private string m_sText = "Error Detect Mode";
        public UCTrackerMode()
        {
            InitializeComponent();
        }

        public UDM.Log.EMMonitorType MonitorType
        {
            set 
            { 
                m_emTrackerMode = value;
                if (m_emTrackerMode == Log.EMMonitorType.MasterPattern)
                    m_sText = "Master Pattern Mode";
                else if (m_emTrackerMode == Log.EMMonitorType.PatternItem)
                    m_sText = "Pattern Item Mode";
                else
                    m_sText = "Error Detect Mode";

                lblMonitorStatus.Text = m_sText;
                lblMonitorStatus.Refresh();
            }
        }

        public void Run()
        {
            lblMonitorStatus.Appearance.BackColor = Color.Yellow;
            lblMonitorStatus.Appearance.BackColor2 = Color.Orange;
            lblMonitorStatus.Text = m_sText;
            lblMonitorStatus.Refresh();
        }

        public void Stop()
        {
            lblMonitorStatus.Appearance.BackColor = Color.FromArgb(201, 201, 201);
            lblMonitorStatus.Appearance.BackColor2 = Color.FromArgb(163, 163, 163);
            lblMonitorStatus.Text = m_sText;
            lblMonitorStatus.Refresh();
        }

        private void UCTrackerMode_Load(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
