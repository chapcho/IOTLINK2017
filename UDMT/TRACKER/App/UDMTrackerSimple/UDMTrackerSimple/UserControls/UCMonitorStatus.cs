using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class UCMonitorStatus : DevExpress.XtraEditors.XtraUserControl
    {
        public UCMonitorStatus()
        {
            InitializeComponent();
        }

        public void Run(string sText)
        {
            lblMonitorStatus.Appearance.BackColor = Color.YellowGreen;
            lblMonitorStatus.Appearance.BackColor2 = Color.GreenYellow;
            lblMonitorStatus.Text = sText;
            lblMonitorStatus.Refresh();
        }

        public void Stop(string sText)
        {
            lblMonitorStatus.Appearance.BackColor = Color.FromArgb(201, 201, 201);
            lblMonitorStatus.Appearance.BackColor2 = Color.FromArgb(163, 163, 163);
            lblMonitorStatus.Text = sText;
            lblMonitorStatus.Refresh();
        }

        public void Error(string sText)
        {
            lblMonitorStatus.Appearance.BackColor = Color.Red;
            lblMonitorStatus.Appearance.BackColor2 = Color.OrangeRed;
            lblMonitorStatus.Text = sText;
            lblMonitorStatus.Refresh();
        }

        private void UCMonitorStauts_Load(object sender, EventArgs e)
        {
            Stop("MONITOR OFF");
        }
    }
}
