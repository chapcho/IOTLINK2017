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

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerMonitorPanelDoubleClicked();
    public delegate void UEventHandlerMonitorAllPanelDoubleClicked(string sProcessKey);
    public delegate void UEventHandlerMonitorPanelClicked(string sProcessKey);

    public partial class UCErrorAlarmWidget : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iErrorCount = 0;
        private bool m_bRun = false;
        public UEventHandlerMonitorPanelDoubleClicked UEventPanelDoubleClick;
        public UEventHandlerMonitorPanelClicked UEventPanelClick;
        public UEventHandlerMonitorAllPanelDoubleClicked UEventAllPanelDoubleClick;

        private int m_iCurPriority = -1;
        private bool m_bStatusView = false;

        public UCErrorAlarmWidget()
        {
            InitializeComponent();

            lblText.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblProcess.MouseWheel += new MouseEventHandler(All_MouseWheel);
            pnlBackground.MouseWheel += new MouseEventHandler(All_MouseWheel);
        }

        public UCErrorAlarmWidget(string sProcessText)
        {
            InitializeComponent();

            lblProcess.Text = sProcessText;
        }

        public string ProcessText
        {
            get { return lblProcess.Text; }
            set { lblProcess.Text = value; }
        }

        public string MainText
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        public void Run()
        {
            m_bRun = true;

            pnlBackground.Appearance.BackColor = Color.LimeGreen;
            pnlBackground.Appearance.BackColor2 = Color.Transparent;
        }

        public void Stop()
        {
            m_bRun = false;
            m_iCurPriority = -1;

            pnlBackground.Appearance.BackColor = Color.Gray;
            pnlBackground.Appearance.BackColor2 = Color.Transparent;
        }

        public void ProcessStatusView()
        {
            try
            {
                lblText.Visible = false;
                lblProcess.Dock = DockStyle.Fill;

                m_bStatusView = true;

                float nSize = (pnlBackground.Width > pnlBackground.Height) ? pnlBackground.Height : pnlBackground.Width;
                FontFamily fontFamily = lblProcess.Font.FontFamily;
                float nFontSize = (float)nSize / 100f;
                if (nFontSize < 0.1f)
                    nFontSize = 0.1f;

                Font fontCaption = null;
                if (!m_bStatusView)
                    fontCaption = new Font(fontFamily, nFontSize * 15f, FontStyle.Bold);
                else
                    fontCaption = new Font(fontFamily, nFontSize * 20f, FontStyle.Bold);

                Font fontValue = new Font(fontFamily, nFontSize * 20f, FontStyle.Bold);

                lblProcess.Font = fontCaption;
                lblText.Font = fontValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError()
        {
            try
            {
                if (!m_bRun)
                    return;

                m_iErrorCount++;

                if (!m_bStatusView)
                    lblText.Visible = true;

                pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                pnlBackground.Appearance.BackColor2 = Color.Red;

                lblText.Text = m_iErrorCount.ToString();
                tmrTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOverError()
        {
            try
            {
                if (!m_bRun)
                    return;

                if (!m_bStatusView)
                    lblText.Visible = true;

                pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                pnlBackground.Appearance.BackColor2 = Color.Red;
                lblText.Text = "Max Over";
                tmrTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdatePlcError(string sErrorMessage)
        {
            try
            {
                if (!m_bRun)
                    return;

                if (!m_bStatusView)
                    lblText.Visible = true;

                pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                pnlBackground.Appearance.BackColor2 = Color.Red;

                FontFamily fontFamily = lblText.Font.FontFamily;
                Font fontText = new Font(fontFamily, 20f, FontStyle.Bold);
                lblText.Font = fontText;

                lblText.Text = sErrorMessage;
                tmrTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdatePlcError(string sErrorMessage, int iPriority)
        {
            try
            {
                if (!m_bRun)
                    return;

                if (m_iCurPriority > iPriority)
                    return;

                if (!m_bStatusView)
                    lblText.Visible = true;

                pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                pnlBackground.Appearance.BackColor2 = Color.Red;

                FontFamily fontFamily = lblText.Font.FontFamily;
                Font fontText = new Font(fontFamily, 20f, FontStyle.Bold);
                lblText.Font = fontText;

                lblText.Text = sErrorMessage;
                tmrTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearText()
        {
            try
            {
                if (!m_bRun)
                    return;

                m_iErrorCount = 0;
                m_iCurPriority = -1;
                lblText.Text = "0";

                lblText.Visible = false;
                pnlBackground.Appearance.BackColor = Color.LimeGreen;
                pnlBackground.Appearance.BackColor2 = Color.Transparent;

                tmrTimer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Color cColor1 = pnlBackground.Appearance.BackColor;
                Color cColor2 = pnlBackground.Appearance.BackColor2;

                pnlBackground.Appearance.BackColor = cColor2;
                pnlBackground.Appearance.BackColor2 = cColor1;

                pnlBackground.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void pnlBackground_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (UEventPanelDoubleClick != null)
                    UEventPanelDoubleClick();

                if (UEventAllPanelDoubleClick != null)
                    UEventAllPanelDoubleClick(lblProcess.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void pnlBackground_Resize(object sender, EventArgs e)
        {
            try
            {
                float nSize = (pnlBackground.Width > pnlBackground.Height) ? pnlBackground.Height : pnlBackground.Width;
                FontFamily fontFamily = lblProcess.Font.FontFamily;
                float nFontSize = (float) nSize/100f;
                if (nFontSize < 0.1f)
                    nFontSize = 0.1f;

                Font fontCaption = null;
                if (!m_bStatusView)
                    fontCaption = new Font(fontFamily, nFontSize*15f, FontStyle.Bold);
                else
                    fontCaption = new Font(fontFamily, nFontSize*20f, FontStyle.Bold);

                Font fontValue = new Font(fontFamily, nFontSize*20f, FontStyle.Bold);

                lblProcess.Font = fontCaption;
                lblText.Font = fontValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void pnlBackground_Click(object sender, EventArgs e)
        {
            try
            {
                if (UEventPanelClick != null)
                    UEventPanelClick(lblProcess.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseUp(e);
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

    }
}
