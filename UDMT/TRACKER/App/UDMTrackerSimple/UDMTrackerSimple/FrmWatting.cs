using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace UDMTrackerSimple
{
    public partial class FrmWatting : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private string m_sLargeText = "Please Wait";
        private string m_sSmallText = "Wait";
        private string m_sProgressText = "Waitting...";
        private bool m_bHold = false;
        private delegate void UpdateTextCallBack(string sLarge, string sSmall, string sProgress, bool bHold);

        #endregion


        #region Initialize

        public FrmWatting()
        {
            InitializeComponent();
        }

        public FrmWatting(string sLargeText, string sSmallText, string sProgressText)
        {
            m_sLargeText = sLargeText;
            m_sSmallText = sSmallText;
            m_sProgressText = sProgressText;
        }

        #endregion


        #region Perperties

        public string BigText
        {
            get { return m_sLargeText; }
            set { m_sLargeText = value; }
        }

        public string SmailText
        {
            get { return m_sSmallText; }
            set { m_sSmallText = value; }
        }

        public string ProgressText
        {
            get { return m_sProgressText; }
            set { m_sProgressText = value; }
        }

        public bool IsOpenForm
        {
            get { return IsFormOpened(typeof(FrmWatting)) == null ? false : true; }
        }

        #endregion

        private void FrmWatting_Load(object sender, EventArgs e)
        {
            //progressWat.
            lblBigText.Text = m_sLargeText;
            lblSmallText.Text = InsertLine(m_sSmallText);
            lblPrograssText.Text = m_sProgressText;
        }

        private void picLogo_MouseClick(object sender, MouseEventArgs e)
        {
            //로고 누르면 인터넷 연결되어 있으면 회사 사이트 이동
            Process.Start("http://www.udmtek.com/");
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.LinkData = "http://www.udmtek.com/";
            Process.Start(e.Link.LinkData.ToString());
        }

        public void UpdateString(string sBigText, string sSmallText, string sProgressText, bool bHold)
        {
            m_sLargeText = sBigText;
            m_sSmallText = sSmallText;
            m_sProgressText = sProgressText;
            m_bHold = bHold;
            if (this.InvokeRequired)
            {
                UpdateTextCallBack cbUdateText = new UpdateTextCallBack(UpdateString);
                this.Invoke(cbUdateText, new object[] { sBigText, sSmallText, sProgressText, bHold });
            }
            else
            {
                lblBigText.Text = sBigText;
                lblSmallText.Text = sSmallText;
                lblPrograssText.Text = sProgressText;
            }
        }

        private Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
        }

        private string InsertLine(string sData)
        {
            string sResult = sData;
                        
            if (sData.Length > 50)
            {
                sResult = "";
                int iCount = 0;
                for (int i = 0; i < sData.Length; i++)
                {
                    char c = sData[i];
                    if (iCount == 50)
                    {
                        sResult += "\r\n";
                        sResult += c;
                    }
                    else if (iCount == 100)
                    {
                        sResult += "\r\n";
                        sResult += c;
                    }
                    else
                        sResult += c;
                    if (c == '\n')
                        iCount = 0;
                    else
                        iCount++;
                }
                
            }

            return sResult;
        }

    }
}