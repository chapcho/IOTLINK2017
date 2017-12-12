using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Monitor.Plc.Source.LS;
using UDM.Monitor.Plc;
using UDM.Common;

namespace UDMTracker
{
    public partial class FrmLsPlcConfig : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        protected CLsConfig m_cLsConfig = null;
        protected CLsConfig m_cLsConfigBuffer = new CLsConfig();
        protected CMonitor cMonitor = null;
        protected delegate void UpdateTextCallBack(string sMessage);
        private List<string> m_lstOrgAddress = new List<string>();

        #endregion


        #region Initialize

        public FrmLsPlcConfig(CLsConfig cLsConfig)
        {
            InitializeComponent();
            m_cLsConfig = cLsConfig;
        }

        #endregion


        #region Properties

        public bool ChangeConfig { get; set; }

        public CLsConfig LsConfig
        {
            get { return m_cLsConfigBuffer; }
        }

        #endregion


        #region Private Method

        protected void UpdateMessage(string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateMessage);
                    this.Invoke(cbUpdateText, new object[] { sMessage });
                }
                else
                {
                    txtTestData.AppendText(sMessage + "\r\n");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        /// <summary>
        /// 수집 대상 접점이 OPC에서 수집 될때 주소가 다르므로 변경시켜줘야함.
        /// </summary>
        /// <param name="sAddress"></param>
        /// <returns></returns>
        private List<string> GetAddressList(string sAddress)
        {
            List<string> lstResult = new List<string>();
            string[] sSplit = sAddress.Split('\n');

            txtTestAddress.Clear();
            m_lstOrgAddress.Clear();

            if (sSplit.Length > 0)
            {
                for (int i = 0; i < sSplit.Length; i++)
                {
                    if (sSplit[i] == "") continue;

                    if (CheckAddress(sSplit[i]) == false) continue;
                    txtTestAddress.AppendText(sSplit[i] + "\n");
                    m_lstOrgAddress.Add(sSplit[i]);
                    lstResult.Add(sSplit[i]);
                }
            }
            return lstResult;
        }

        private bool CheckAddress(string sAddress)
        {
            string[] saSingleHeader = { "D", "P", "M", "L", "F", "R", "K", "C", "T" };

            string sHeader = sAddress.Substring(0, 1).ToUpper();
            for (int i = 0; i<saSingleHeader.Length; i++)
            {
                if (sHeader == saSingleHeader[i]) return true;
            }
            if (sAddress.Contains("ZR")) return true;

            return false;
        }

        private CTagS CreateCollectTagS()
        {
            CTagS cTagS = new CTagS();
            string sAddress = txtTestAddress.Text.Replace("\r", "");
            List<string> lstAddress = GetAddressList(sAddress);

            for (int i = 0; i < lstAddress.Count; i++)
            {
                CTag cTag = new CTag();
                cTag.Address = lstAddress[i];
                cTag.DataType = GetDataType(lstAddress[i]);
                cTag.Channel = "CH.DV";
                cTag.PLCMaker = EMPLCMaker.LS;
                cTag.Key = cTag.Channel + "." + cTag.Address;

                cTagS.Add(cTag);
            }

            return cTagS;
        }

        private EMDataType GetDataType(string sAddress)
        {
            EMDataType emType = EMDataType.Bool;

            if (sAddress.Contains("D") || sAddress.Contains("T") || sAddress.Contains("C") || 
                sAddress.Contains("ZR"))
                emType = EMDataType.Word;

            return emType;
        }

        #endregion

        private void FrmLsPlcConfig_Load(object sender, EventArgs e)
        {
            if (m_cLsConfig != null)
            {
                if (m_cLsConfig.InterfaceType == EMLsInterfaceType.Ethernet)
                {
                    cmbModule.SelectedIndex = 1;
                    txtIPAddress.Enabled = true;
                    spnEthernetProt.Enabled = true;
                }
                else
                {
                    cmbModule.SelectedIndex = 0;
                    txtIPAddress.Enabled = false;
                    spnEthernetProt.Enabled = false;
                }
                m_cLsConfigBuffer.InterfaceType = m_cLsConfig.InterfaceType;
                m_cLsConfigBuffer.IP = m_cLsConfig.IP;
                m_cLsConfigBuffer.Port = m_cLsConfig.Port;
                m_cLsConfigBuffer.Interval = m_cLsConfig.Interval;

                txtIPAddress.Text = m_cLsConfig.IP;
                int iVal = 0;
                bool bOK = int.TryParse(m_cLsConfig.Port, out iVal);
                spnEthernetProt.Value = iVal;
                spnInterval.Value = m_cLsConfig.Interval;
            }
            else
                m_cLsConfigBuffer.InterfaceType = EMLsInterfaceType.USB;
        }

        private void FrmLsPlcConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_cLsConfigBuffer.Interval = (int)spnInterval.Value;
            m_cLsConfigBuffer.IP = txtIPAddress.Text;
            m_cLsConfigBuffer.Port = spnEthernetProt.Value.ToString();

            if (m_cLsConfigBuffer.InterfaceType != m_cLsConfig.InterfaceType ||
                m_cLsConfigBuffer.Interval != m_cLsConfig.Interval ||
                m_cLsConfigBuffer.IP != m_cLsConfig.IP ||
                m_cLsConfigBuffer.Port != m_cLsConfig.Port)
            {
                DialogResult dlgResult = MessageBox.Show("변경사항이 있습니다. 적용하시겠습니까?", "UDM Tracker",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                    ChangeConfig = true;
            }
            if (btnStop.Enabled)
            {
                cMonitor.Source.Stop();
                cMonitor.Dispose();
                cMonitor = null;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {            
            m_cLsConfigBuffer.Interval = (int)spnInterval.Value;
            m_cLsConfigBuffer.IP = txtIPAddress.Text;
            m_cLsConfigBuffer.Port = spnEthernetProt.Value.ToString();

            if (cMonitor == null)
                cMonitor = new CMonitor();
            cMonitor.Source.TagS = CreateCollectTagS();

            if (cMonitor.Source.TagS.Count == 0) return;

            cMonitor.Source.LsConfig = m_cLsConfigBuffer;
            cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.LS;
            cMonitor.Source.UEventValueChanged += Source_UEventValueChanged;
            
            txtTestData.Clear();

            bool bOK = cMonitor.Source.Run();

            if (bOK == false)
            {
                MessageBox.Show("통신 연결 실패");
                cMonitor.Source.UEventValueChanged -= Source_UEventValueChanged;
                cMonitor.Source.Dispose();
                cMonitor.Source = null;
                cMonitor.Dispose();
                cMonitor = null;
                return;
            }

            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            cMonitor.Source.Stop();
            cMonitor.Source.UEventValueChanged -= Source_UEventValueChanged;
            cMonitor.Source.Dispose();
            cMonitor.Source = null;
            cMonitor.Dispose();
            cMonitor = null;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModule.SelectedIndex == 0)
            {
                m_cLsConfigBuffer.InterfaceType = EMLsInterfaceType.USB;
                txtIPAddress.Enabled = false;
                spnEthernetProt.Enabled = false;
            }
            else
            {
                m_cLsConfigBuffer.InterfaceType = EMLsInterfaceType.Ethernet;
                txtIPAddress.Enabled = true;
                spnEthernetProt.Enabled = true;
            }
        }


        #region Event Method

        void Source_UEventValueChanged(object sender, UDM.Log.CTimeLogS cLogS)
        {
            for (int i = 0; i < cLogS.Count; i++)
            {
                if (cMonitor.Source.TagS.ContainsKey(cLogS[i].Key))
                {
                    CTag cTag = cMonitor.Source.TagS[cLogS[i].Key];
                    string sValue = string.Format("{0},   {1},   {2}", cLogS[i].Time.ToString("HH:mm:ss.fff"), cTag.Address, cLogS[i].Value);
                    UpdateMessage(sValue);
                }
            }
        }

        #endregion

    }
}