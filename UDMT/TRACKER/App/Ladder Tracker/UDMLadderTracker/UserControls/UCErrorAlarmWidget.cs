using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMLadderTracker
{
    public partial class UCErrorAlarmWidget : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iErrorCount = 0;

        public UCErrorAlarmWidget()
        {
            InitializeComponent();
        }

        public string ProcessText
        {
            get { return lblProcess.Text; }
            set { lblProcess.Text = value; }
        }

        public void UpdateError()
        {
            m_iErrorCount++;

            lblText.Text = m_iErrorCount.ToString();
            tmrTimer.Start();
        }

        public void ClearText()
        {
            m_iErrorCount = 0;
            lblText.Text = "0";
            tmrTimer.Stop();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            Color cColor1 = pnlBackground.Appearance.BackColor;
            Color cColor2 = pnlBackground.Appearance.BackColor2;

            pnlBackground.Appearance.BackColor = cColor2;
            pnlBackground.Appearance.BackColor2 = cColor1;

            pnlBackground.Refresh();
        }
    }
}
