using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Monitor.Plc.Source.LS;

namespace UDMPresenter
{
    public partial class FrmLsPlcConfig : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        protected CProject m_cProject = null;
        protected CLsConfig m_cLsConfig = null;
        protected CLsReader m_cReader = null;
        protected CTagS m_cReadTagS = null;
        protected delegate void UpdateTextCallBack(string sMessage);
        private List<string> m_lstOrgAddress = new List<string>();

        #endregion


        #region Initialize

        public FrmLsPlcConfig()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
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
            if (m_cProject == null)
            {
                this.Close();
                return;
            }
            m_cLsConfig = m_cProject.LsConfig;

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
            txtIPAddress.Text = m_cLsConfig.IP;
            int iVal = 0;
            bool bOK = int.TryParse(m_cLsConfig.Port, out iVal);
            spnEthernetProt.Value = iVal;
            spnInterval.Value = m_cLsConfig.Interval;
        }

        private void FrmLsPlcConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_cLsConfig.Interval = (int)spnInterval.Value;
            m_cLsConfig.IP = txtIPAddress.Text;
            m_cLsConfig.Port = spnEthernetProt.Value.ToString();

            if (btnStop.Enabled)
            {
                m_cReader.Stop();
                m_cReader.Dispose();
                m_cReader = null;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (m_cReader == null)
                m_cReader = new CLsReader();

            m_cReader.Config.Interval = (int)spnInterval.Value;
            m_cReader.Config.IP = txtIPAddress.Text;
            m_cReader.Config.Port = spnEthernetProt.Value.ToString();

            bool bOK = m_cReader.Connect();

            m_cReadTagS = CreateCollectTagS();

            if (m_cReadTagS.Count == 0) return;

            m_cReader.AddItemS(m_cReadTagS.Values.ToList());
            m_cReader.UEventValueChanged += Source_UEventValueChanged;
            
            txtTestData.Clear();
            if (bOK)
                bOK = m_cReader.Run();

            if (bOK == false)
            {
                MessageBox.Show("통신 연결 실패");
                m_cReadTagS = null;
                m_cReader.UEventValueChanged -= Source_UEventValueChanged;
                m_cReader.Dispose();
                m_cReader = null;
                return;
            }

            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m_cReadTagS = null;
            m_cReader.Stop();
            m_cReader.UEventValueChanged -= Source_UEventValueChanged;
            m_cReader.Dispose();
            m_cReader = null;

            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModule.SelectedIndex == 0)
            {
                m_cLsConfig.InterfaceType = EMLsInterfaceType.USB;
                txtIPAddress.Enabled = false;
                spnEthernetProt.Enabled = false;
            }
            else
            {
                m_cLsConfig.InterfaceType = EMLsInterfaceType.Ethernet;
                txtIPAddress.Enabled = true;
                spnEthernetProt.Enabled = true;
            }
        }


        #region Event Method

        void Source_UEventValueChanged(object sender, UDM.Log.CTimeLogS cLogS)
        {
            if (m_cReadTagS == null) return;
            for (int i = 0; i < cLogS.Count; i++)
            {
                if (m_cReadTagS.ContainsKey(cLogS[i].Key))
                {
                    CTag cTag = m_cReadTagS[cLogS[i].Key];
                    string sValue = string.Format("{0},   {1},   {2}", cLogS[i].Time.ToString("HH:mm:ss.fff"), cTag.Address, cLogS[i].Value);
                    UpdateMessage(sValue);
                }
            }
        }

        #endregion

    }
}