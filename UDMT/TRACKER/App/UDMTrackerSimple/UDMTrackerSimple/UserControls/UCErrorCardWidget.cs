using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public enum EMIndicatorType
    {
        Wait = 1,
        Error = 2,
        Idle = 3,
        Run = 4
    }


    public partial class UCErrorCardWidget : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorInfoSummary m_cErrorInfoSummary = null;
        private CPlcProc m_cProcess = null;
        private int m_iErrorCount = 0;

        public delegate void UEventHandlerErrorGroupItemClicked(object sender, CErrorInfoSummary cErrorInfoSummary);
        public event UEventHandlerErrorGroupItemClicked UEventErrorGroupClicked;

        public UCErrorCardWidget()
        {
            InitializeComponent();
        }

        public CPlcProc Process
        {
            get { return m_cProcess; }
            set { m_cProcess = value; }
        }

        public CErrorInfoSummary ErrorInfoSummary
        {
            get { return m_cErrorInfoSummary; }
            set
            {
                m_cErrorInfoSummary = value;
                SetErrorCardWidget();
            }
        }

        public void UpdateError(CErrorInfoSummary cErrorInfoSum)
        {
            m_cErrorInfoSummary = cErrorInfoSum;

            //if (!pnlBackGround.Visible)
            //{
            //    m_iErrorCount = 1;
            //    pnlBackGround.Visible = true;
            //    tmrTimer.Start();
            //}
            //else
            //    m_iErrorCount++;

            //lblText.Text = m_iErrorCount.ToString();

            SetErrorCardWidget();
        }

        private void SetErrorCardWidget()
        {
            if (m_cErrorInfoSummary == null)
                return;

            Dictionary<string, CErrorInfoS> ErrorCategory = null;
            double dMostErrorCount = -1;
            string sMostError = string.Empty;

            lblErrorCount.Text = m_cErrorInfoSummary.ErrorCount.ToString();

            if (m_cErrorInfoSummary.ErrorCount != 0)
            {
                ErrorCategory = m_cErrorInfoSummary.GetErrorReportValue();

                foreach (var who in ErrorCategory)
                {
                    if (who.Value.Count > dMostErrorCount)
                    {
                        dMostErrorCount = who.Value.Count;
                        sMostError = who.Key;
                    }
                }
            }

            double MostErrorPercentage = (dMostErrorCount / m_cErrorInfoSummary.ErrorCount) ;

            lblMostError.Text = sMostError;
            lblDetailError.Text = "#Error : " + dMostErrorCount.ToString() + "<br><color=165,70,113>" +
                                  MostErrorPercentage.ToString("P");
        }

        private void UCErrorCardWidget_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            if (UEventErrorGroupClicked != null)
                UEventErrorGroupClicked(this, m_cErrorInfoSummary);
        }

        private void pnlBackGround_Click(object sender, EventArgs e)
        {
            //if (pnlBackGround.Visible)
            //{
            //    pnlBackGround.Visible = false;
            //    tmrTimer.Stop();
            //}
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            //Color cColor1 = pnlBackGround.Appearance.BackColor;
            //Color cColor2 = pnlBackGround.Appearance.BackColor2;

            //pnlBackGround.Appearance.BackColor = cColor2;
            //pnlBackGround.Appearance.BackColor2 = cColor1;

            //pnlBackGround.Refresh();
        }


    }
}
