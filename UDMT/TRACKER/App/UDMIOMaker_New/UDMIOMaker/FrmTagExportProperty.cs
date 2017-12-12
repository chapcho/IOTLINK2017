using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmTagExportProperty : DevExpress.XtraEditors.XtraForm
    {
        private List<string> m_lstDeletePLC = null;

        public FrmTagExportProperty()
        {
            InitializeComponent();
        }

        public List<string> DeletePLC
        {
            get { return m_lstDeletePLC; }
            set { m_lstDeletePLC = value; }
        }

        private void SetPLCList()
        {
            cboPLCList.Properties.Items.Clear();

            foreach (var who in CProjectManager.LogicDataS)
                cboPLCList.Properties.Items.Add(who.Key);

            if (CProjectManager.LogicDataS.Count != 0)
                cboPLCList.EditValue = CProjectManager.LogicDataS.First().Key;
        }

        private void SetPLCMakerList()
        {
            cboPLCMaker.Properties.Items.Clear();

            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Siemens);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Developer);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Works2);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.Mitsubishi_Works3);
            cboPLCMaker.Properties.Items.Add(EMPLCMaker.LS);

            if (CProjectManager.LogicDataS.Count != 0)
                cboPLCMaker.EditValue = CProjectManager.LogicDataS.First().Value.PLCMaker;
        }

        private bool ExportMaker(EMPLCMaker emPLCMaker, string sPLCName)
        {
            bool bOK = false;

            try
            {
                if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
                {
                    
                }
                else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                {
                    CSiemensExport cSiemensExport = new CSiemensExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                    bOK = cSiemensExport.ExportSiemensPLC();
                }
                else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                {
                    CMelsecExport cMelsecExport = new CMelsecExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                    bOK = cMelsecExport.ExportMelsecPLC();
                }
                else if (emPLCMaker.Equals(EMPLCMaker.LS))
                {
                    CLSExport cLSExport = new CLSExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                    bOK = cLSExport.ExportLSPLC();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export Maker Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private bool CheckMakerRedundancy(string sPLCName, EMPLCMaker emPLCMaker)
        {
            bool bOK = false;

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
                bOK = CheckABRedundancy(CProjectManager.LogicDataS[sPLCName]);
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                bOK = CheckSiemensRedundancy(CProjectManager.LogicDataS[sPLCName]);
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                bOK = CheckMelsecRedundancy(CProjectManager.LogicDataS[sPLCName]);
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                bOK = CheckLSRedundancy(CProjectManager.LogicDataS[sPLCName]);

            return bOK;
        }

        private bool CheckMelsecRedundancy(CPlcLogicData cData)
        {
            bool bOK = false;
            List<string> lstTotal = new List<string>();
            List<string> lstRedun = new List<string>();
            List<string> lstRedunAddress = new List<string>();

            foreach (var who in cData.TagS)
            {
                if (who.Value.Address == string.Empty)
                {
                    bOK = true;
                    lstRedun.Add(who.Key);
                }
                else
                {
                    if (!lstTotal.Contains(who.Value.Address))
                        lstTotal.Add(who.Value.Address);
                    else
                    {
                        bOK = true;
                        if (!lstRedunAddress.Contains(who.Value.Address))
                            lstRedunAddress.Add(who.Value.Address);
                    }
                }
            }

            foreach (string sAddress in lstRedunAddress)
            {
                foreach (var who in cData.TagS)
                {
                    if (who.Value.Address == sAddress)
                    {
                        if (!lstRedun.Contains(who.Key))
                            lstRedun.Add(who.Key);
                    }
                }
            }

            if (bOK)
            {
                if (
                    XtraMessageBox.Show("중복된 Address 및 비어있는 Address가 존재합니다.\r\n확인하시겠습니까?", "Error", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes)
                    ViewFrmRedundancy(cData.PLCMaker, lstRedun);
            }

            return bOK;
        }

        private bool CheckLSRedundancy(CPlcLogicData cData)
        {
            bool bOK = false;
            List<string> lstTotal = new List<string>();
            List<string> lstRedun = new List<string>();
            List<string> lstRedunAddress = new List<string>();

            foreach (var who in cData.TagS)
            {
                if (who.Value.Address == string.Empty)
                {
                    bOK = true;
                    lstRedun.Add(who.Key);
                }
                else
                {
                    if (!lstTotal.Contains(who.Value.Address))
                        lstTotal.Add(who.Value.Address);
                    else
                    {
                        bOK = true;
                        if (!lstRedunAddress.Contains(who.Value.Address))
                            lstRedunAddress.Add(who.Value.Address);
                    }
                }
            }

            foreach (string sAddress in lstRedunAddress)
            {
                foreach (var who in cData.TagS)
                {
                    if (who.Value.Address == sAddress)
                    {
                        if (!lstRedun.Contains(who.Key))
                            lstRedun.Add(who.Key);
                    }
                }
            }

            if (bOK)
            {
                if (
                    XtraMessageBox.Show("중복된 Address 및 비어있는 Address가 존재합니다.\r\n확인하시겠습니까?", "Error", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes)
                    ViewFrmRedundancy(cData.PLCMaker, lstRedun);
            }

            return bOK;
        }

        private void ViewFrmRedundancy(EMPLCMaker emPLCMaker, List<string> lstRedun)
        {
            FrmRedundancyChecker frmRedun = new FrmRedundancyChecker();
            frmRedun.PLCMaker = emPLCMaker;
            frmRedun.RedunKey = lstRedun;
            frmRedun.TopMost = true;

            if (frmRedun.ShowDialog() == DialogResult.OK)
            {
                if (frmRedun.DeletePLC != null && frmRedun.DeletePLC.Count > 0)
                    m_lstDeletePLC = frmRedun.DeletePLC;

                frmRedun.Dispose();
                frmRedun = null;
            }
        }

        private bool CheckSiemensRedundancy(CPlcLogicData cData)
        {
            bool bOK = false;
            List<string> lstTotal = new List<string>();
            List<string> lstRedunName = new List<string>();
            List<string> lstRedun = new List<string>();

            foreach (var who in cData.TagS)
            {
                if (who.Value.Name == string.Empty)
                {
                    bOK = true;
                    lstRedun.Add(who.Key);
                }
                else
                {
                    if (!lstTotal.Contains(who.Value.Name))
                        lstTotal.Add(who.Value.Name);
                    else
                    {
                        bOK = true;
                        if (!lstRedunName.Contains(who.Value.Name))
                            lstRedunName.Add(who.Value.Name);
                    }
                }
            }


            foreach (string sName in lstRedunName)
            {
                foreach (var who in cData.TagS)
                {
                    if (who.Value.Name == sName)
                    {
                        if (!lstRedun.Contains(who.Key))
                            lstRedun.Add(who.Key);
                    }
                }
            }

            if (bOK)
            {
                if (
                    XtraMessageBox.Show("중복된 PLC 심볼 및 비어있는 PLC 심볼이 존재합니다.\r\n확인하시겠습니까?", "Error",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes)
                    ViewFrmRedundancy(cData.PLCMaker, lstRedun);
            }

            return bOK;
        }

        private bool CheckABRedundancy(CPlcLogicData cData)
        {
            bool bOK = false;
            List<string> lstTotal = new List<string>();
            List<string> lstRedunAddress = new List<string>();
            List<string> lstRedun = new List<string>();

            foreach (var who in cData.TagS)
            {
                if (!lstTotal.Contains(who.Value.Address))
                    lstTotal.Add(who.Value.Address);
                else
                {
                    bOK = true;
                    if (!lstRedunAddress.Contains(who.Value.Address))
                        lstRedunAddress.Add(who.Value.Address);
                }
            }


            foreach (string sAddress in lstRedunAddress)
            {
                foreach (var who in cData.TagS)
                {
                    if (who.Value.Address == sAddress)
                    {
                        if (!lstRedun.Contains(who.Key))
                            lstRedun.Add(who.Key);
                    }
                }
            }

            if (bOK)
            {
                if (
                    XtraMessageBox.Show("중복된 PLC 심볼이 존재합니다.\r\n확인하시겠습니까?", "Error", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes)
                    ViewFrmRedundancy(cData.PLCMaker, lstRedun);
            }

            return bOK;
        }


        private void FrmTagExportProperty_Load(object sender, EventArgs e)
        {
            try
            {
                SetPLCList();
                SetPLCMakerList();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("TagExportProperty Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null || cboPLCMaker.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCList.EditValue;
                EMPLCMaker emPLCMaker = (EMPLCMaker) cboPLCMaker.EditValue;
                string sMessage = string.Format("내보내기 하고자 하시는 PLC의 이름은 {0} 이며, Maker는 {1} 입니다.\r\n내보내기 하시겠습니까?", sPLCName,
                    emPLCMaker.ToString());

                if (XtraMessageBox.Show(sMessage, "Export PLC Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                    return;

                bool bOK = false;

                if (CheckMakerRedundancy(sPLCName, emPLCMaker))
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = ExportMaker(emPLCMaker, sPLCName);
                }
                SplashScreenManager.CloseForm(false);

                if (bOK)
                {
                    XtraMessageBox.Show("Export PLC Tag Success!!!", "Export PLC", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Export PLC Tag Fail!!!", "Export PLC", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }

                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("TagExportProperty Export Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}