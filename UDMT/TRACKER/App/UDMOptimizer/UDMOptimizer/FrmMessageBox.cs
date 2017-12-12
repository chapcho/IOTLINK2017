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

namespace UDMOptimizer
{
    public partial class FrmMessageBox : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private string m_sLargeText = "Please Wait";
        private string m_sSmallText = "Wait";
        private bool m_bHold = false;
        private delegate void UpdateTextCallBack(string sLarge, string sSmall, bool bHold);

        #endregion


        #region Initialize

        public FrmMessageBox()
        {
            InitializeComponent();
        }

        public FrmMessageBox(string sLargeText, string sSmallText)
        {
            m_sLargeText = sLargeText;
            m_sSmallText = sSmallText;
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

        public void UpdateString(string sBigText, string sSmallText, bool bHold)
        {
            
            m_sLargeText = sBigText;
            m_sSmallText = sSmallText;
            m_bHold = bHold;
            if (this.InvokeRequired)
            {
                UpdateTextCallBack cbUdateText = new UpdateTextCallBack(UpdateString);
                this.Invoke(cbUdateText, new object[] { sBigText, sSmallText, bHold });
            }
            else
            {
                lblBigText.Text = sBigText;
                lblSmallText.Text = sSmallText;
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