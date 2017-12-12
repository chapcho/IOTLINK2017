using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;
using UDM.UDLImport;

namespace UDMTrackerSimple
{
    public partial class FrmTagFinder : DevExpress.XtraEditors.XtraForm
    {
        private CPlcLogicData m_cCurData = null;
        private CTag m_cCurTag = null;
        private FrmLadderView m_frmLadderView = null;


        public FrmTagFinder()
        {
            InitializeComponent();
        }

        private void InitPLCList()
        {
            if (CMultiProject.PlcLogicDataS == null || CMultiProject.PlcLogicDataS.Count == 0)
                return;

            foreach (var who in CMultiProject.PlcLogicDataS)
                cboPLCList.Properties.Items.Add(who.Value.PlcName);

            cboPLCList.EditValue = CMultiProject.PlcLogicDataS.First().Value.PlcName;
            m_cCurData = CMultiProject.PlcLogicDataS.First().Value;
        }

        private CPlcLogicData GetPlcLogicData(string sName)
        {
            CPlcLogicData cData = null;

            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                if (who.Value.PlcName == sName)
                {
                    cData = who.Value;
                    break;
                }
            }

            return cData;
        }

        private string GetAddressDigit(string sAddress)
        {
            string sNewAddress = string.Empty;

            sAddress = sAddress.ToUpper();
            if (m_cCurData.Maker.ToString().Contains("Mitsubishi"))
                sNewAddress = GetMelsecAddressDigit(sAddress);
            else if (m_cCurData.Maker.Equals(EMPLCMaker.LS))
                sNewAddress = GetLSAddressDigit(sAddress);
            else if (m_cCurData.Maker.Equals(EMPLCMaker.Siemens))
                sNewAddress = GetSiemensAddressDigit(sAddress);
            else
                sNewAddress = sAddress;

            return sNewAddress;
        }

        private string GetMelsecAddressDigit(string sAddress)
        {
            string sNewAddress = string.Empty;

            string sHeader = string.Empty;
            string sAddressIndex = string.Empty;
            int iLength = -1;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sAddressIndex = sAddress.Remove(0, 1);

                iLength = sAddressIndex.Length;

                if (iLength < 4)
                {
                    for (int i = 0; i < 4 - iLength; i++)
                        sAddressIndex = sAddressIndex.Insert(0, "0");
                }
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sAddressIndex = sAddress.Remove(0, 2);

                iLength = sAddressIndex.Length;

                if (iLength < 4)
                {
                    for (int i = 0; i < 4 - iLength; i++)
                        sAddressIndex = sAddressIndex.Insert(0, "0");
                }
            }

            sNewAddress = sHeader + sAddressIndex;

            return sNewAddress;
        }

        private string GetLSAddressDigit(string sAddress)
        {
            string sNewAddress = string.Empty;

            if (sAddress.Contains("%"))
                return sAddress;



            return sNewAddress;
        }

        private string GetSiemensAddressDigit(string sAddress)
        {
            string sNewAddress = string.Empty;

            if (sAddress.Contains("DB"))
                return sAddress;

            string sHeader = string.Empty;
            string sAddressIndex = string.Empty;
            int iLength = -1;

            sHeader = sAddress.Substring(0, 1);
            sAddressIndex = sAddress.Remove(0, 1);

            iLength = sAddressIndex.Length;

            if (iLength < 4)
            {
                for (int i = 0; i < 4 - iLength; i++)
                    sAddressIndex = sAddressIndex.Insert(0, "0");
            }

            sNewAddress = sHeader + sAddressIndex;

            return sNewAddress;
        }

        private void FrmTagFinder_Load(object sender, EventArgs e)
        {
            try
            {
                InitPLCList();
                ucStepSelector.ClearStepRole();

                m_frmLadderView = new FrmLadderView();
                m_frmLadderView.TopMost = true;

                ucStepSelector.UEventStepRoleDoubleClicked += UCStepSelector_StepRoleDoubleClick;
            }
            catch (Exception ex)
            {
                Console.WriteLine("FrmTagFinder_Load Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboPLCList_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object obj = cboPLCList.EditValue;

                if (obj == null || obj.GetType() != typeof (string))
                    return;

                string sName = (string) obj;

                m_cCurData = GetPlcLogicData(sName);
                ucStepSelector.ClearStepRole();
                txtTagAddress.EditValue = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("cboPLCList_EditValueChanged Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string sAddress = txtTagAddress.Text;

                if (sAddress == string.Empty || m_cCurData == null)
                    return;

                string sChannel = m_cCurData.PlcChannel;
                string sNewAddress = GetAddressDigit(sAddress);

                string sKey = string.Format("[{0}]{1}[1]", sChannel, sNewAddress);

                if (m_cCurData.TagS.ContainsKey(sKey))
                {
                    m_cCurTag = m_cCurData.TagS[sKey];
                    ucStepSelector.ShowStepRole(m_cCurTag, m_cCurData, false);
                }
                else
                    XtraMessageBox.Show("해당하는 PLC에 찾고자하신 태그가 존재하지 않습니다.", "Not Exist Tag", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnFind_Click Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ucStepSelector.ClearStepRole();
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnClear_Click Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UCStepSelector_StepRoleDoubleClick(CStep cStep)
        {
            try
            {
                if (!m_frmLadderView.IsLoad)
                {
                    m_frmLadderView.Show();
                    m_frmLadderView.IsLoad = true;
                }

                m_frmLadderView.SetLadderStep(m_cCurData, cStep, 0, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("UCStepSelector_StepRoleDoubleClick Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmTagFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_frmLadderView.Dispose();
            m_frmLadderView = null;
        }

        private void txtTagAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnFind_Click(null, null);
        }

    }
}