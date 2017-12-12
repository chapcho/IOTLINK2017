using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrackerSPD.DDEA;

namespace UDMOptimizer
{
    public partial class FrmDDEAProperty : Form
    {
        protected CDDEAConfigMS m_cConfig = null;
        protected CDDEAConfigMS m_cConfigBuffer = null;
        protected bool m_bDataChange = false;

        #region Iniitalize

        public FrmDDEAProperty(CDDEAConfigMS cConfig)
        {
            InitializeComponent();
            m_cConfig = cConfig;
            if (cConfig != null)
                m_cConfigBuffer = (CDDEAConfigMS)cConfig.Clone();
            else
                m_cConfig = new CDDEAConfigMS();
        }

        #endregion


        #region Properties

        public CDDEAConfigMS Config
        {
            get { return m_cConfigBuffer; }
        }

        public bool IsDataChange
        {
            get { return m_bDataChange; }
        }

        public bool IsConnectionCheck
        {
            get { return ucConnectionTest.ConnectSuccess; }
            set { ucConnectionTest.ConnectSuccess = value; }
        }

        #endregion


        #region Form Event

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_cConfigBuffer == null)
            {
                m_cConfigBuffer = new CDDEAConfigMS();
                m_bDataChange = true;
            }
            if (m_cConfig.MelsecSeriesType != EMMelsecSeriesType.Melsec_RSeries)
                m_cConfig = ucConnectSetting.SetConfig(m_cConfig);
            else
            {
                //ucConnectSetMxCom4.Config = m_cConfig;
                ucConnectSetMxCom4.SetConfig();
                ucConnectSetMxCom4.Config = m_cConfig;
            }

            if (m_cConfig == null)
            {
                this.Close();
                return;
            }
            if (m_cConfig.Equals(m_cConfigBuffer) == false)
            {
                DialogResult dlgResul = MessageBox.Show("저장한 내용과 다릅니다.\r\n\r\n현재 내용을 저장하시겠습니까?\r\n\r\nCancel하면 닫지 않습니다.",
                                                        "DDEA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlgResul == DialogResult.Yes)
                {
                    m_cConfigBuffer = (CDDEAConfigMS)m_cConfig.Clone();
                    m_bDataChange = true;
                }
                else if (dlgResul == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (ucConnectionTest.TestRunning == false)
                ucConnectionTest.CheckConnect();

            if (ucConnectionTest.ConnectSuccess == false)
            {
                MessageBox.Show("현재 설정으로는 PLC와 통신이 불가합니다.", "DDEA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                m_bDataChange = true;

            if (ucConnectionTest.TestRunning)
                ucConnectionTest.TestStop();

            ucConnectionTest.UEventConnect -= new UEventHandlerConnect(ucConnectionTest_UEventConnect);

            this.Close();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (m_cConfig.MelsecSeriesType != EMMelsecSeriesType.Melsec_RSeries)
                m_cConfig = ucConnectSetting.SetConfig(m_cConfig);
            else
            {
                ucConnectSetMxCom4.SetConfig();
                ucConnectSetMxCom4.Config = m_cConfig;
            }

            if (m_cConfigBuffer == null)
            {
                m_cConfigBuffer = (CDDEAConfigMS)m_cConfig.Clone();
                m_bDataChange = true;
            }
            else
            {
                if (m_cConfig.Equals(m_cConfigBuffer) == false)
                {
                    m_cConfigBuffer = (CDDEAConfigMS)m_cConfig.Clone();
                    m_bDataChange = true;
                }
            }

			btnClose_Click(this, null);
        }

        private void FrmDDEAProperty_Load(object sender, EventArgs e)
        {
            ucConnectionTest.UEventConnect += new UEventHandlerConnect(ucConnectionTest_UEventConnect);
            if (m_cConfig != null)
            {
                if (m_cConfig.MelsecSeriesType == EMMelsecSeriesType.Melsec_RSeries)
                {
                    cmbSeries.SelectedIndex = 0;
                    ucConnectSetMxCom4.Config = m_cConfig;
                }
                else
                {
                    cmbSeries.SelectedIndex = 1;
                    ucConnectSetting.GetConfig(m_cConfig);
                }
            }
        }

        void ucConnectionTest_UEventConnect(object sender)
        {
            if (m_cConfig.MelsecSeriesType != EMMelsecSeriesType.Melsec_RSeries)
                m_cConfig = ucConnectSetting.SetConfig(m_cConfig);
            else
            {
                ucConnectSetMxCom4.SetConfig();
                ucConnectSetMxCom4.Config = m_cConfig;
            }
            ucConnectionTest.Config = m_cConfig;
        }

        #endregion

        private void cmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeries.SelectedIndex == 0)
            {
                m_cConfig.MelsecSeriesType = EMMelsecSeriesType.Melsec_RSeries;
                ucConnectSetMxCom4.Config = m_cConfig;
                tabConfigSet.SelectedTabPage = tpRSeries;
                ucConnectSetMxCom4.Enabled = true;
                ucConnectSetting.Enabled = false;
            }
            else
            {
                m_cConfig.MelsecSeriesType = EMMelsecSeriesType.Melsec_Normal;
                tabConfigSet.SelectedTabPage = tpNoraml;
                ucConnectSetMxCom4.Enabled = false;
                ucConnectSetting.Enabled = true;
            }
        }
    }
}
