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
using UDM.UDLImport;

namespace UDMIOMaker
{
    public partial class FrmRedundancyChecker : DevExpress.XtraEditors.XtraForm
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private List<string> m_lstRedunKey = null;
        private List<string> m_lstDeletePLC = null; 

        public FrmRedundancyChecker()
        {
            InitializeComponent();
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }

        public List<string> RedunKey
        {
            get { return m_lstRedunKey; }
            set { m_lstRedunKey = value; }
        }

        public List<string> DeletePLC
        {
            get { return m_lstDeletePLC; }
            set { m_lstDeletePLC = value; }
        }

        private void ShowRedunTag()
        {
            CTagS cTagS = new CTagS();

            foreach (string sKey in m_lstRedunKey)
            {
                if(CProjectManager.PLCTagS.ContainsKey(sKey))
                    cTagS.Add(sKey, CProjectManager.PLCTagS[sKey]);

                grdDesignPLC.DataSource = cTagS.Values.ToList();
                grdDesignPLC.RefreshDataSource();
            }
        }

        private List<string> DeleteSymbolS(int[] arrPLC)
        {
            List<string> lstPLCName = new List<string>();

            string sKey = string.Empty;
            foreach (int iRowHandle in arrPLC)
            {
                sKey = (string)grvDesignPLC.GetRowCellDisplayText(iRowHandle, colDesignKey);
                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    if (!lstPLCName.Contains(CProjectManager.PLCTagS[sKey].Channel))
                        lstPLCName.Add(CProjectManager.PLCTagS[sKey].Channel);

                    CProjectManager.LogicDataS[CProjectManager.PLCTagS[sKey].Channel].TagS.Remove(sKey);
                    CProjectManager.PLCTagS.Remove(sKey);
                }
            }

            return lstPLCName;
        }

        private void SetMakerPLCAddress(EMPLCMaker emPLCMaker, string sKey)
        {
            CTag cTag = CProjectManager.PLCTagS[sKey];

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensPLCAddress(cTag);
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecPLCAddress(cTag);
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                SetLSPLCAddress(cTag);
        }

        private void SetMelsecPLCAddress(CTag cTag)
        {
            try
            {
                if (!cTag.Address.Contains("."))
                    SetMelsecAddressNotContainDot(cTag);
                else
                    SetMelsecAddressContainDot(cTag);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetMelsecAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1).Split('.')[0];
                sDotValue = sAddress.Remove(0, 1).Split('.')[1];
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2).Split('.')[0];
                sDotValue = sAddress.Remove(0, 2).Split('.')[1];
            }

            if (CMelsecPlc.IsMelsecHexa(sAddress))
                bHexa = true;
            else
                bHexa = false;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);
            }
            else
            {
                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();
            }

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress;
        }

        private void SetMelsecAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

            if (CMelsecPlc.IsMelsecHexa(sAddress))
                bHexa = true;
            else
                bHexa = false;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);
            }
            else
            {
                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();
            }

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress;
        }

        private void SetSiemensPLCAddress(CTag cTag)
        {
            try
            {
                if (!cTag.Address.Contains("."))
                    SetSiemensAddressNotContainDot(cTag);
                else
                    SetSiemensAddressContainDot(cTag);

                if (cTag.DataType.Equals(EMDataType.Block))
                    cTag.UDTType = cTag.Address;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Siemens PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSPLCAddress(CTag cTag)
        {
            try
            {
                if (!cTag.Address.Contains("."))
                    SetLSAddressNotContainDot(cTag);
                else
                    SetLSAddressContainDot(cTag);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("LS PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1).Split('.')[0];
            sDotValue = sAddress.Remove(0, 1).Split('.')[1];

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 5)
            {
                int iCount = 5 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress.ToUpper();
        }

        private void SetLSAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;
            bool bHexa = false;


            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1);


            if (sAddress.StartsWith("T") || sAddress.StartsWith("C") || sAddress.StartsWith("N"))
                bHexa = false;
            else
                bHexa = true;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);

                if (sIndex.Length < 6)
                {
                    int iCount = 6 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
            }
            else
            {
                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();

                if (sIndex.Length < 5)
                {
                    int iCount = 5 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
            }

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress.ToUpper();
        }

        private void SetSiemensAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;

            if (!sAddress.StartsWith("DB"))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1).Split('.')[0];
                sDotValue = sAddress.Remove(0, 1).Split('.')[1];
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2).Split('.')[0];
                sDotValue = sAddress.Remove(0, 2).Split('.')[1];
            }

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress;
        }

        private void SetSiemensAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;

            if (!sAddress.StartsWith("DB"))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress;
        }




        private void FrmRedundancyChecker_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_lstRedunKey == null || m_lstRedunKey.Count == 0)
                    return;

                if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
                    colDesignNote.Visible = true;
                else
                    colDesignNote.Visible = false;

                ShowRedunTag();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmRedundancyCheck Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSymbolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int[] arrPLC = grvDesignPLC.GetSelectedRows();

                if (arrPLC == null || arrPLC.Length < 1)
                    return;

                if (
                    XtraMessageBox.Show("선택하신 " + arrPLC.Length + " 개의 심볼을 제거하시겠습니까?", "Delete Symbol",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                m_lstDeletePLC = DeleteSymbolS(arrPLC);
                ShowRedunTag();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Delete FrmRedun Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvDesignPLC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colDesignAddress)
                {
                    string sKey = (string) grvDesignPLC.GetRowCellValue(e.RowHandle, colDesignKey);
                    string sPLCName = (string) grvDesignPLC.GetRowCellValue(e.RowHandle, colDesignPLC);
                    EMPLCMaker emPLCmaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

                    SetMakerPLCAddress(emPLCmaker, sKey);

                    grdDesignPLC.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Design PLC CellValueChanged Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }



    }
}