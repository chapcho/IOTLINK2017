using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Export;
using UDM.UDLImport;

namespace UDMIOMaker
{
    partial class FrmMain
    {
        private Dictionary<int, CRangeView> m_dicRangeView = new Dictionary<int, CRangeView>();
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private string m_sPLCName = string.Empty;

        private FrmSymbolNameEdit m_frmSymbolNameEdit = null;

        private UCMelsecAddressArea m_ucMelsecArea = null;
        private UCSiemensAddressArea m_ucSiemensArea = null;
        private UCABAddressArea m_ucABArea = null;
        private UCLSAddressArea m_ucLSArea = null;

        private string m_sIOSavePath = string.Empty;

        private void LoadFrmNameEdit()
        {
            m_frmSymbolNameEdit = new FrmSymbolNameEdit();
            m_frmSymbolNameEdit.TopMost = true;
            m_frmSymbolNameEdit.UEventNameEdit += FrmSymbolNameEdit_UEventNameEdit;
        }

        private void DisposeFrmNameEdit()
        {
            m_frmSymbolNameEdit.UEventNameEdit -= FrmSymbolNameEdit_UEventNameEdit;
            m_frmSymbolNameEdit.Dispose();
            m_frmSymbolNameEdit = null;
        }

        private void CreateAddressBlockS(CPlcLogicData cData)
        {
            if (cData.PLCMaker.Equals(EMPLCMaker.ALL))
                return;

            //PLC가 없는 상황(신규 라인)에 대해서도 대응해야 함.

            //if (cData.TagS.Count != 0)
            //{
            if (cData.AddressBlockS == null)
                cData.AddressBlockS = new CBlockS();
            else
                cData.AddressBlockS.Clear();

            SetLogicDataAddressBlockS(cData);
            //}
        }

        private void SetLogicDataAddressBlockS(CPlcLogicData cData)
        {
            if (cData.PLCMaker.Equals(EMPLCMaker.Rockwell))
                SetABBlockS(cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensBlockS(cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.LS))
                SetLSBlockS(cData);
            else
                SetMelsecBlockS(cData);
        }

        private void SetMelsecBlockS(CPlcLogicData cData)
        {
            List<string> lstAddressBlock = GetTypeValue(EMBLOCK_MITUBISHI.TYPE_LIST);

            CBlock cBlock;
            foreach (string sAddressBlock in lstAddressBlock)
            {
                if (!cData.AddressBlockS.ContainsKey(sAddressBlock)) //&& cData.TagS.Count != 0)
                {
                    cBlock = new CBlock(sAddressBlock, GetMelsecMaximumLimit(sAddressBlock),
                        GetMelsecIsHaxa(sAddressBlock), cData.TagS.GetFirst().Channel, EMPLCMaker.Mitsubishi);
                    cData.AddressBlockS.Add(sAddressBlock, cBlock);
                }
            }

            if (cData.IOModuleBlock == null)
                SetMelsecIOBlock(cData);
        }

        private void SetLSBlockS(CPlcLogicData cData)
        {
            List<string> lstAddressBlock = GetTypeValue(EMBLOCK_LS.TYPE_LIST);

            CBlock cBlock;
            foreach (string sAddressBlock in lstAddressBlock)
            {
                if (!cData.AddressBlockS.ContainsKey(sAddressBlock)) //&& cData.TagS.Count != 0)
                {
                    cBlock = new CBlock(sAddressBlock, GetLSMaximumLimit(sAddressBlock),
                        false, cData.TagS.GetFirst().Channel, EMPLCMaker.LS);
                    cData.AddressBlockS.Add(sAddressBlock, cBlock);
                }
            }

            if (cData.IOModuleBlock == null)
                SetLSIOBlock(cData);
        }

        private void SetABBlockS(CPlcLogicData cData)
        {
            List<string> lstAddressBlock = GetTypeValue(EMBLOCK_AB.TYPE_LIST);

            CBlock cBlock;
            foreach (string sAddressBlock in lstAddressBlock)
            {
                if (!cData.AddressBlockS.ContainsKey(sAddressBlock)) //&& cData.TagS.Count != 0)
                {
                    cBlock = new CBlock(sAddressBlock, 1500, false, cData.TagS.GetFirst().Channel, EMPLCMaker.Rockwell);
                    cData.AddressBlockS.Add(sAddressBlock, cBlock);
                }
            }

            //if (cData.IOModuleBlock == null)
            //    SetMelsecIOBlock(cData);
        }

        private void SetLSIOBlock(CPlcLogicData cData)
        {
            CBlock cIOModuleBlock = new CBlock("IO", 2047, true, cData.TagS.GetFirst().Channel, EMPLCMaker.LS);
            cData.IOModuleBlock = cIOModuleBlock;
        }

        private void SetSiemensBlockS(CPlcLogicData cData)
        {
            List<string> lstAddressBlock = GetTypeValue(EMBLOCK_SIEMENS.TYPE_LIST);

            CBlock cBlock;
            foreach (string sAddressBlock in lstAddressBlock)
            {
                if (!cData.AddressBlockS.ContainsKey(sAddressBlock)) //&& cData.TagS.Count != 0)
                {
                    cBlock = new CBlock(sAddressBlock, GetSiemensMaximumLimit(sAddressBlock),
                        false, cData.TagS.GetFirst().Channel, EMPLCMaker.Siemens);
                    cData.AddressBlockS.Add(sAddressBlock, cBlock);
                }
            }

            if (cData.IOModuleBlock == null)
                SetSiemensIOBlock(cData);
        }

        private void SetMelsecIOBlock(CPlcLogicData cData)
        {
            CBlock cIOModuleBlock = new CBlock("IO", 1023, true, cData.TagS.GetFirst().Channel, EMPLCMaker.Mitsubishi);
            cData.IOModuleBlock = cIOModuleBlock;
        }

        private void SetSiemensIOBlock(CPlcLogicData cData)
        {
            CBlock cIOModuleBlock = new CBlock("IO", 16383, true, cData.TagS.GetFirst().Channel, EMPLCMaker.Siemens);
            cData.IOModuleBlock = cIOModuleBlock;
        }

        private List<string> GetTypeValue(string sType)
        {
            List<string> lstValue = new List<string>();
            List<string> sTemp = null;

            if (sType.Contains(";"))
                sTemp = sType.Split(';').ToList();

            if (sTemp != null && sTemp.Count > 0)
            {
                foreach (var who in sTemp)
                    lstValue.Add(who);
            }

            return lstValue;
        }

        private int GetMelsecMaximumLimit(string sHeader)
        {
            int iLimit = -1;

            if (sHeader.Equals("D"))
                iLimit = 12287; //12287 = 2FFF (2FFF.F)
            else if (sHeader.Equals("T"))
                iLimit = 204; //2047 (2047.F)
            else if (sHeader.Equals("C"))
                iLimit = 102; //1023 (1023.F)
            else
                iLimit = 1023; //1023 = 3FF (3FFF)

            return iLimit;
        }

        private int GetLSMaximumLimit(string sHeader)
        {
            int iLimit = -1;

            if (sHeader.Equals("L"))
                iLimit = 11263;
            else if (sHeader.Equals("N"))
                iLimit = 21503;
            else if (sHeader.Equals("T") || sHeader.Equals("C") || sHeader.Equals("K") || sHeader.Equals("P"))
                iLimit = 2047;
            else
                iLimit = 25000;

            return iLimit;
        }

        private int GetSiemensMaximumLimit(string sHeader)
        {
            int iLimit = -1;

            if (sHeader.Equals("DB"))
                iLimit = 1023;
            else if (sHeader.Equals("T") || sHeader.Equals("C"))
                iLimit = 65535; //65535 (FFFF)
            else
                iLimit = 16383; //16383 = 3FFF (3FFF.0)까지만, 원래는 FFFF.0(65535.0)까지 가능

            return iLimit;
        }

        private bool GetMelsecIsHaxa(string sHeader)
        {
            bool bHexa = false;

            string sHexa = EMBLOCK_MITUBISHI.HEXA_LIST;

            if (sHexa.Contains(sHeader))
                bHexa = true;

            return bHexa;
        }

        private void ChangePLCTagS(string sPLCName)
        {
            if (sPLCName == null)
                return;

            string sKey = string.Empty;
            CTag cTag;
            foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
            {
                foreach (var who2 in who.Value.UnitS)
                {
                    if (who2.Value.IsDelete)
                        DeleteMakerTag(who2.Value, sPLCName);
                    else
                    {
                        foreach (var who3 in who2.Value.TagItemS)
                        {
                            if (CProjectManager.PLCTagS.ContainsKey(who3.Key))
                            {
                                if (CProjectManager.LogicDataS[sPLCName].PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) ||
                                    CProjectManager.LogicDataS[sPLCName].PLCMaker.Equals(EMPLCMaker.LS))
                                    CProjectManager.PLCTagS[who3.Key].Description = who3.Description;
                                else
                                    CProjectManager.PLCTagS[who3.Key].Name = who3.Description;

                                CProjectManager.StdTagS[who3.Key].CurrentDesc = who3.Description;
                            }
                            else if (who3.Description != string.Empty) //Edit해서 추가했거나, -NULL-
                                SetMakerTag(who3, sPLCName);
                        }
                    }
                }
            }
        }

        private void SetMakerTag(CTagItem cItem, string sPLCName)
        {
            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensTag(cItem, sPLCName);
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecTag(cItem, sPLCName, emPLCMaker);
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                SetLSTag(cItem, sPLCName, emPLCMaker);
        }

        private void DeleteMakerTag(CBlockUnit cUnit, string sPLCName)
        {
            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                DeleteSiemensTag(cUnit, sPLCName);
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                DeleteMelsecTag(cUnit, sPLCName);
        }

        private void SetLSTag(CTagItem cItem, string sPLCName, EMPLCMaker emPLCMaker)
        {
            string sKey = string.Format("[{0}]{1}[1]", sPLCName, cItem.Address);

            CTag cTag = new CTag();
            cTag.Address = cItem.Address;
            cTag.Description = cItem.Description;
            cTag.Channel = sPLCName;
            cTag.DataType = cItem.DataType;
            cTag.Key = sKey;
            cTag.PLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;
            cTag.IsHMIMapping = true;
            //cTag.Creator = GetPLCGroupKey(cItem.Description);
            CProjectManager.LogicDataS[sPLCName].TagS.Add(cTag.Key, cTag);
            CProjectManager.PLCTagS.Add(cTag.Key, cTag);

            CStdTag cStdTag = new CStdTag();
            cStdTag.CurrentDesc = cItem.Description;
            cStdTag.Address = cItem.Address;
            cStdTag.Key = sKey;
            CProjectManager.StdTagS.Add(cStdTag.Key, cStdTag);
        }

        private void SetMelsecTag(CTagItem cItem, string sPLCName, EMPLCMaker emPLCMaker)
        {
            string sKey = string.Format("[{0}]{1}[1]", sPLCName, cItem.Address);

            CTag cTag = new CTag();
            cTag.Address = cItem.Address;

            if (emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer))
                cTag.Description = cItem.Description;
            else
                cTag.Name = cItem.Description;

            cTag.Channel = sPLCName;
            cTag.DataType = cItem.DataType;
            cTag.Key = sKey;
            cTag.PLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;
            cTag.IsHMIMapping = true;

            //cTag.Creator = GetPLCGroupKey(cItem.Description);
            CProjectManager.LogicDataS[sPLCName].TagS.Add(cTag.Key, cTag);
            CProjectManager.PLCTagS.Add(cTag.Key, cTag);

            CStdTag cStdTag = new CStdTag();
            cStdTag.CurrentDesc = cItem.Description;
            cStdTag.Address = cItem.Address;
            cStdTag.Key = sKey;
            CProjectManager.StdTagS.Add(cStdTag.Key, cStdTag);
        }

        private void SetSiemensTag(CTagItem cItem, string sPLCName)
        {
            string sKey = string.Format("[{0}]{1}[1]", sPLCName, cItem.Address);

            CTag cTag = new CTag();
            cTag.Address = cItem.Address;
            cTag.Name = cItem.Description;
            cTag.Channel = sPLCName;
            cTag.DataType = cItem.DataType;
            cTag.UDTType = cItem.Address;
            cTag.Key = sKey;
            cTag.PLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;
            cTag.IsHMIMapping = true;
            CProjectManager.LogicDataS[sPLCName].TagS.Add(cTag.Key, cTag);
            CProjectManager.PLCTagS.Add(cTag.Key, cTag);

            CStdTag cStdTag = new CStdTag();
            cStdTag.CurrentDesc = cItem.Description;
            cStdTag.Address = cItem.Address;
            cStdTag.Key = sKey;
            CProjectManager.StdTagS.Add(cStdTag.Key, cStdTag);
        }

        private void DeleteSiemensTag(CBlockUnit cUnit, string sPLCName)
        {
            string sAddress = string.Empty;
            string sKey = string.Empty;

            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                sAddress = CUtil.GetSiemensNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);
                sKey = string.Format("[{0}]{1}[1]", sPLCName, sAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    CProjectManager.PLCTagS.Remove(sKey);
                    CProjectManager.LogicDataS[sPLCName].TagS.Remove(sKey);
                    CProjectManager.StdTagS.Remove(sKey);
                }
            }
        }

        private void DeleteMelsecTag(CBlockUnit cUnit, string sPLCName)
        {
            string sAddress = string.Empty;
            string sKey = string.Empty;

            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                sAddress = CUtil.GetMelsecNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);
                sKey = string.Format("[{0}]{1}[1]", sPLCName, sAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    CProjectManager.PLCTagS.Remove(sKey);
                    CProjectManager.LogicDataS[sPLCName].TagS.Remove(sKey);
                    CProjectManager.StdTagS.Remove(sKey);
                }
            }
        }

        private void ClassifyABTagS(CPlcLogicData cData)
        {
            List<string> lstRemoveKey = new List<string>();
            bool bOK = false;

            foreach (var who in cData.TagS)
            {
                bOK = false;

                if (who.Value.Address == string.Empty)
                {
                    lstRemoveKey.Add(who.Key);
                    continue;
                }

                if (who.Value.DataType.Equals(EMDataType.Counter) || who.Value.DataType.Equals(EMDataType.Timer))
                    bOK = true;

                if (!bOK && CheckABAddressHeader(who.Value.Address))
                    bOK = true;

                if (!bOK && CheckABAddressHeader(who.Value.Name))
                    bOK = true;

                if (!bOK)
                    lstRemoveKey.Add(who.Key);
            }

            foreach (string sKey in lstRemoveKey)
            {
                if (cData.TagS.ContainsKey(sKey))
                    cData.TagS.Remove(sKey);
            }
        }

        private bool CheckABAddressHeader(string sAddress)
        {
            bool bOK = false;

            List<string> lstValue = GetTypeValue(EMBLOCK_AB.TYPE_LIST);
            string sFormat = string.Empty;
            string sFormat2 = string.Empty;

            foreach (string sValue in lstValue)
            {
                if (sValue.Equals("T") || sValue.Equals("C"))
                    continue;

                sFormat = string.Format(@"{0}[0-9]+[\[]*", sValue);
                sFormat2 = string.Format(@"{0}[0-9]*[\[]+", sValue);

                if (sAddress.StartsWith(sValue))
                {
                    if (Regex.IsMatch(sAddress, sFormat) || Regex.IsMatch(sAddress, sFormat2))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private void ShowDesignPLCGrid()
        {
            grdDesignPLC.DataSource = null;
            grdDesignPLC.DataSource = CProjectManager.PLCTagS.Values.ToList();
            grdDesignPLC.RefreshDataSource();
        }

        private bool NewPLCSymbol(string sChannel, EMPLCMaker emPLCMaker)
        {
            bool bOK = false;

            try
            {
                CPlcLogicData cData = new CPlcLogicData();
                cData.PLCMaker = emPLCMaker;
                cData.Name = sChannel;
                m_emPLCMaker = emPLCMaker;
                m_sPLCName = sChannel;

                CProjectManager.LogicDataS.Add(sChannel, cData);
                CreateAddressBlockS(cData);
                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Tag Import",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool ImportPLCTag(string sChannel)
        {
            bool bOK = true;

            try
            {
                CPlcLogicData cData = null;

                FrmMakerSelector frmMaker = new FrmMakerSelector();
                frmMaker.Channel = sChannel;

                if (frmMaker.ShowDialog() == DialogResult.Cancel)
                    return false;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    cData = new CPlcLogicData();
                    cData.TagS = frmMaker.TagS;
                    //cData.StepS = cLogic.StepS; //StepExtract
                    cData.PLCMaker = frmMaker.PLCMaker;
                    m_emCurPLCMaker = frmMaker.PLCMaker;
                    cData.Name = sChannel;

                    frmMaker.Dispose();
                    frmMaker = null;

                    if (m_emCurPLCMaker.Equals(EMPLCMaker.Rockwell))
                    {
                        ClassifyABTagS(cData);
                        colDesignNote.Visible = true;
                    }
                    else
                        colDesignNote.Visible = false;

                    CProjectManager.LogicDataS.Add(cData.Name, cData);
                    CProjectManager.PLCTagS.AddRange(cData.TagS);
                    CreateAddressBlockS(cData);
                }
                SplashScreenManager.CloseForm(false);

                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Tag Import",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool CheckMakerRedundancy(CPlcLogicData cData)
        {
            bool bOK = false;

            if (cData.PLCMaker.Equals(EMPLCMaker.Rockwell))
                bOK = CheckABRedundancy(cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.Siemens))
                bOK = CheckSiemensRedundancy(cData);
            else if (cData.PLCMaker.ToString().Contains("Mitsubishi"))
                bOK = CheckMelsecRedundancy(cData);
            else if (cData.PLCMaker.Equals(EMPLCMaker.LS))
                bOK = CheckLSRedundancy(cData);

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
                {
                    SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    {
                        List<string> lstPLC = frmRedun.DeletePLC;

                        foreach (string sName in lstPLC)
                        {
                            if (CProjectManager.LogicDataS.ContainsKey(sName))
                                CreateAddressBlockS(CProjectManager.LogicDataS[sName]);
                        }
                        RefreshDesign();
                    }
                    SplashScreenManager.CloseForm(false);
                }

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

        private string GetSameNameKey(string sName, string sAddress, bool bSameName)
        {
            string sKey = string.Empty;

            foreach (var who in CProjectManager.PLCTagS)
            {
                if (bSameName)
                {
                    if (who.Value.Name == sName && who.Value.Address != sAddress)
                    {
                        sKey = who.Key;
                        break;
                    }
                }
                else
                {
                    if (who.Value.Address == sAddress && who.Value.Name != sName)
                    {
                        sKey = who.Key;
                        break;
                    }
                }
            }

            return sKey;
        }



        private void RefreshDesign()
        {
            grdDesignPLC.DataSource = null;
            grdDesignPLC.DataSource = CProjectManager.PLCTagS.Values.ToList();
            grdDesignPLC.RefreshDataSource();

            grdStd.DataSource = null;
            grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
            grdStd.RefreshDataSource();

            SetMakerAddressArea();
            ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
        }

        private List<string> DeleteSymbolS(int[] arrPLC)
        {
            List<string> lstPLCName = new List<string>();

            string sKey = string.Empty;
            foreach (int iRowHandle in arrPLC)
            {
                sKey = (string) grvDesignPLC.GetRowCellDisplayText(iRowHandle, colDesignKey);
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

        private void SetPLCList()
        {
            cboPLCList.Properties.Items.Clear();

            if (CProjectManager.LogicDataS.Count != 0)
            {
                foreach (var who in CProjectManager.LogicDataS)
                    cboPLCList.Properties.Items.Add(who.Key);

                m_sPLCName = CProjectManager.LogicDataS.First().Key;
                m_emPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;
                cboPLCList.EditValue = m_sPLCName;
            }
        }

        private void SetListType()
        {
            cboListType.Properties.Items.Clear();

            cboListType.Properties.Items.Add("ALL_LIST");
            cboListType.Properties.Items.Add("IO_LIST");
            cboListType.Properties.Items.Add("DUMMY_LIST");
            cboListType.Properties.Items.Add("LINK_LIST");
            cboListType.Properties.Items.Add("TIMER_COUNT_LIST");

            cboListType.EditValue = "ALL_LIST";
        }

        private void ClearAddressAreaInfo()
        {
            cboPLCList.EditValue = null;
            cboPLCList.Properties.Items.Clear();

            cboListType.EditValue = null;
            cboListType.Properties.Items.Clear();

            m_dicRangeView.Clear();

            grpAddressArea.Controls.Clear();
        }

        private void ClearIOModuleInfo()
        {
            ucIOModule.ClearTree();
        }

        private void ClearDesignPLC()
        {
            m_sIOSavePath = string.Empty;
            btnSavePathOpen.EditValue = null;

            grdDesignPLC.DataSource = null;
            grdDesignPLC.RefreshDataSource();

            chkViewIOList.Checked = false;
            m_bExport = false;
            IOSpreadSheet.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default);
            IOSpreadSheet.CreateNewDocument();
        }


        private void SetMakerAddressArea()
        {
            if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
                SetABAddressArea(m_sPLCName);
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensAddressArea(m_sPLCName);
            else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecAddressArea(m_sPLCName);
            else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                SetLSAddressArea(m_sPLCName);

            tabIOData.SelectedTabPage = tpAddressRangeData;
        }

        private void SetMelsecAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();

                CBlock cBlock;
                CRangeView cView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 12287; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetMelsecAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetMelsecAreaInfo(cView, cBlock);
                        }
                    }

                    cBlock = null;
                }
                SetMelsecUserControl();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();

                CBlock cBlock;
                CRangeView cView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 25000; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetLSAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetLSAreaInfo(cView, cBlock);
                        }
                    }

                    cBlock = null;
                }
                SetLSUserControl();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("LS Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucLSArea = new UCLSAddressArea();
            m_ucLSArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucLSArea);

            m_ucLSArea.PLCName = m_sPLCName;
            m_ucLSArea.IsViewPopmenu = false;
            m_ucLSArea.RangeViewS = m_dicRangeView;
            m_ucLSArea.GroupPanelText = "Cell을 더블클릭하시면 해당 Cell의 영역에 포함된 PLC 심볼이 왼쪽 표에 나타납니다.";
            m_ucLSArea.UEventGridDoubleClick += ucAddressArea_GridDoubleClick;

            ShowAddressArea();
        }

        private void SetLSAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "P":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.PArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsPFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertPArea = true;
                    break;
                case "K":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.KArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsKFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertKArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "L":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.LArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsLFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertLArea = true;
                    break;
                case "D":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDArea = true;
                    break;
                case "N":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.NArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsNFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertNArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }


        private void SetSiemensAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();

                CBlock cBlock;
                CRangeView cView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 65535; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetSiemensAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetSiemensAreaInfo(cView, cBlock);
                        }
                    }

                    cBlock = null;
                }
                SetSiemensUserControl();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Siemens Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetABAddressArea(string sPLCName)
        {
            try
            {
                m_dicRangeView.Clear();

                CBlock cBlock;
                CRangeView cView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    for (int i = 0; i <= 1500; i++)
                    {
                        if (!m_dicRangeView.ContainsKey(i))
                        {
                            cView = new CRangeView();
                            cView.RangeIndex = i;
                            cView.PLCMaker = cBlock.PLCMaker;

                            if (cBlock.UnitS.ContainsKey(i))
                                SetABAreaInfo(cView, cBlock);

                            m_dicRangeView.Add(i, cView);
                        }
                        else
                        {
                            cView = m_dicRangeView[i];
                            if (cBlock.UnitS.ContainsKey(i))
                                SetABAreaInfo(cView, cBlock);
                        }
                    }

                    cBlock = null;
                }
                SetABUserControl();
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("AB Address Area", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetABAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "I":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.IArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsIFull = true;
                    break;
                case "O":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.OArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsOFull = true;
                    break;
                case "H":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.HArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsHFull = true;
                    break;
                case "N":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.NArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsNFull = true;
                    break;
                case "B":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.BArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsBFull = true;
                    break;
                case "S":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.SArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsSFull = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    break;
            }
        }

        private void SetABUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucABArea = new UCABAddressArea();
            m_ucABArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucABArea);

            m_ucABArea.PLCName = m_sPLCName;
            m_ucABArea.IsViewPopmenu = false;
            m_ucABArea.RangeViewS = m_dicRangeView;
            m_ucABArea.GroupPanelText = "Cell을 더블클릭하시면 해당 Cell의 영역에 포함된 PLC 심볼이 왼쪽 표에 나타납니다.";
            m_ucABArea.UEventGridDoubleClick += ucAddressArea_GridDoubleClick;

            ShowAddressArea();
        }

        private void SetSiemensAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "I":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.IArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsIFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertIArea = true;
                    break;
                case "Q":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.QArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsQFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertQArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "DB":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DBArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDBFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDBArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }

        private void SetSiemensUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucSiemensArea = new UCSiemensAddressArea();
            m_ucSiemensArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucSiemensArea);

            m_ucSiemensArea.PLCName = m_sPLCName;
            m_ucSiemensArea.IsViewPopmenu = false;
            m_ucSiemensArea.RangeViewS = m_dicRangeView;
            m_ucSiemensArea.GroupPanelText = "Cell을 더블클릭하시면 해당 Cell의 영역에 포함된 PLC 심볼이 왼쪽 표에 나타납니다.";
            m_ucSiemensArea.UEventGridDoubleClick += ucAddressArea_GridDoubleClick;

            ShowAddressArea();
        }

        private void SetMelsecUserControl()
        {
            grpAddressArea.Controls.Clear();

            m_ucMelsecArea = new UCMelsecAddressArea();
            m_ucMelsecArea.Dock = DockStyle.Fill;
            grpAddressArea.Controls.Add(m_ucMelsecArea);

            m_ucMelsecArea.PLCName = m_sPLCName;
            m_ucMelsecArea.IsViewPopmenu = false;
            m_ucMelsecArea.RangeViewS = m_dicRangeView;
            m_ucMelsecArea.GroupPanelText = "Cell을 더블클릭하시면 해당 Cell의 영역에 포함된 PLC 심볼이 왼쪽 표에 나타납니다.";
            m_ucMelsecArea.UEventMelsecGridDoubleClick += ucAddressArea_GridDoubleClick;

            ShowAddressArea();
        }

        private void SetMelsecAreaInfo(CRangeView cView, CBlock cBlock)
        {
            switch (cBlock.BlockName)
            {
                case "X":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.XArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsXFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertXArea = true;
                    break;
                case "Y":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.YArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsYFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertYArea = true;
                    break;
                case "M":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.MArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsMFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertMArea = true;
                    break;
                case "L":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.LArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsLFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertLArea = true;
                    break;
                case "D":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.DArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsDFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertDArea = true;
                    break;
                case "B":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.BArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsBFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertBArea = true;
                    break;
                case "W":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.WArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsWFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertWArea = true;
                    break;
                case "T":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.TArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsTFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertTArea = true;
                    break;
                case "C":
                    if (cBlock.UnitS[cView.RangeIndex].IsUsed)
                        cView.CArea = "...";
                    if (cBlock.UnitS[cView.RangeIndex].IsFullUsed)
                        cView.IsCFull = true;
                    if (cBlock.UnitS[cView.RangeIndex].IsInsertArea)
                        cView.IsInsertCArea = true;
                    break;
            }
        }

        private void ShowAddressArea()
        {
            if (cboListType.EditValue == null)
                return;

            string sList = (string) cboListType.EditValue;
            SetListTypeChangeView(sList);
        }

        private void ShowIOModuleTree(bool bExtend, bool bUsed)
        {
            SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
            {
                ucIOModule.ShowTree(bExtend, bUsed);
                ucIOModule.Refresh();
            }
            SplashScreenManager.CloseForm(false);
        }

        private List<string> GetParseDescription(List<string> lstDescription)
        {
            List<string> lstParse = new List<string>();

            List<string> lstTemp = null;

            Dictionary<int, List<string>> dicSplit = new Dictionary<int, List<string>>();
            List<string> lstSplit = null;
            int iMinCount = -1;
            string sSplit = string.Empty;
            bool bSame = true;

            for (int i = 0; i < lstDescription.Count; i++)
            {
                lstSplit = new List<string>();
                lstTemp = lstDescription[i].Split('_').ToList();

                if (lstTemp == null)
                    continue;

                if (i == 0)
                    iMinCount = lstTemp.Count;

                if (iMinCount > lstTemp.Count)
                    iMinCount = lstTemp.Count;

                lstSplit.AddRange(lstTemp);
                dicSplit.Add(i, lstSplit);
            }

            for (int i = 0; i < iMinCount; i++)
            {
                foreach (var who in dicSplit)
                {
                    if (sSplit == string.Empty)
                        sSplit = who.Value[i];
                    else if (sSplit != who.Value[i])
                    {
                        bSame = false;
                        break;
                    }
                    else if (sSplit == who.Value[i])
                        bSame = true;
                }

                if (bSame)
                    lstParse.Add(sSplit);
                else
                    lstParse.Add(string.Empty);

                sSplit = string.Empty;
            }
            return lstParse;
        }

        private void SetListTypeChangeView(string sType)
        {
            if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                if (m_ucABArea != null)
                    m_ucABArea.ShowAddressArea(sType, chkExtend.Checked, chkUsed.Checked);
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (m_ucSiemensArea != null)
                    m_ucSiemensArea.ShowAddressArea(sType, chkExtend.Checked, chkUsed.Checked);
            }
            else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (m_ucMelsecArea != null)
                    m_ucMelsecArea.ShowAddressArea(sType, chkExtend.Checked, chkUsed.Checked);
            }
            else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (m_ucLSArea != null)
                    m_ucLSArea.ShowAddressArea(sType, chkExtend.Checked, chkUsed.Checked);
            }
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



        private void grvDesignPLC_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (!m_frmSymbolNameEdit.IsLoad)
                    return;

                int[] arrRow = grvDesignPLC.GetSelectedRows();
                List<string> lstDescription = new List<string>();

                CTag cTag;
                foreach (int iRowHandle in arrRow)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvDesignPLC.GetRow(iRowHandle).GetType() != typeof (CTag))
                        continue;

                    cTag = (CTag) grvDesignPLC.GetRow(iRowHandle);

                    if (cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || cTag.PLCMaker.Equals(EMPLCMaker.LS))
                        lstDescription.Add(cTag.Description);
                    else
                        lstDescription.Add(cTag.Name);
                }

                List<string> lstParse = GetParseDescription(lstDescription);

                if (lstParse.Count != 0)
                    m_frmSymbolNameEdit.SetParseView(lstParse);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("DesignPLC Mouse Up Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmSymbolNameEdit_UEventNameEdit(string sDescription)
        {
            try
            {
                int[] arrRow = grvDesignPLC.GetSelectedRows();

                if (arrRow.Length < 1)
                {
                    XtraMessageBox.Show("Name을 변경하고자 하는 Symbol을 선택하지 않았습니다.\r\nSymbol을 선택하세요.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CTag cTag;
                foreach (int iRowHandle in arrRow)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvDesignPLC.GetRow(iRowHandle).GetType() != typeof (CTag))
                        continue;

                    cTag = (CTag) grvDesignPLC.GetRow(iRowHandle);

                    if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_emPLCMaker.Equals(EMPLCMaker.LS))
                        cTag.Description = sDescription;
                    else
                        cTag.Name = sDescription;
                }

                grdDesignPLC.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmSymbolEdit FrmMain Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSymbolNameEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tabDesign.SelectedTabPage = tpDesignDesign;

                m_frmSymbolNameEdit.Show();
                m_frmSymbolNameEdit.IsLoad = true;

                int[] arrRow = grvDesignPLC.GetSelectedRows();
                List<string> lstDescription = new List<string>();

                CTag cTag;
                foreach (int iRowHandle in arrRow)
                {
                    if (iRowHandle < 0)
                        continue;

                    if (grvDesignPLC.GetRow(iRowHandle).GetType() != typeof (CTag))
                        continue;

                    cTag = (CTag) grvDesignPLC.GetRow(iRowHandle);
                    lstDescription.Add(cTag.Description);
                }

                List<string> lstParse = GetParseDescription(lstDescription);

                if (lstParse.Count != 0)
                    m_frmSymbolNameEdit.SetParseView(lstParse);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Name Edit Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRangeDetailView_Click(object sender, EventArgs e)
        {
            btnAddressRangeView_ItemClick(null, null);
        }

        private void btnAddressRangeView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tabDesign.SelectedTabPage = tpDesignDesign;

                string sPLCName = string.Empty;

                if (cboPLCList.EditValue == null)
                    return;

                sPLCName = (string) cboPLCList.EditValue;

                if (!CProjectManager.LogicDataS.ContainsKey(sPLCName))
                    return;

                FrmAddressRangeSetting frmView = new FrmAddressRangeSetting();
                if (frmView.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    {
                        ChangePLCTagS(frmView.PLCName);
                        CreateAddressBlockS(CProjectManager.LogicDataS[sPLCName]);
                    }
                    SplashScreenManager.CloseForm(false);
                }
                else
                {
                    SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    {
                        CreateAddressBlockS(CProjectManager.LogicDataS[sPLCName]);
                    }
                    SplashScreenManager.CloseForm(false);
                }

                RefreshDesign();

                frmView.Dispose();
                frmView = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Address Range View Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOpenPLCTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;
                string sChannel = string.Empty;

                sChannel = GetUserInputText("Input PLC Name", "Please enter text below...", false);

                if (sChannel == string.Empty)
                {
                    XtraMessageBox.Show("PLC Name is Empty!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CProjectManager.LogicDataS.ContainsKey(sChannel))
                {
                    XtraMessageBox.Show("Already Exist PLC Name!!", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                bOK = ImportPLCTag(sChannel);

                if (!bOK)
                    return;

                chkViewIOList.Checked = false;
                m_bExport = false;
                IOSpreadSheet.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default);
                IOSpreadSheet.CreateNewDocument();

                ShowDesignPLCGrid();
                ShowStdGrid();
                SetPLCList();
                SetListType();
                ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
                CheckMakerRedundancy(CProjectManager.LogicDataS[m_sPLCName]);

                CProjectManager.UpdateSystemMessage("Mapping", "PLC Open OK");
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Open PLC Tag Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkDesignPLCEditable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDesignPLCEditable.Checked)
                {
                    colDesignDescription.OptionsColumn.AllowEdit = true;
                    colDesignAddress.OptionsColumn.AllowEdit = true;
                    colDesignName.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    colDesignDescription.OptionsColumn.AllowEdit = false;
                    colDesignAddress.OptionsColumn.AllowEdit = false;
                    colDesignName.OptionsColumn.AllowEdit = false;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Design PLC Editable Check Box",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void btnAddSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmSymbolAddProperty frmAddProperty = new FrmSymbolAddProperty();
                frmAddProperty.PLCName = m_sPLCName;

                if (frmAddProperty.ShowDialog() == DialogResult.OK)
                {
                    CTag cTag = frmAddProperty.Tag;

                    CProjectManager.PLCTagS.Add(cTag.Key, cTag);
                    CProjectManager.LogicDataS[cTag.Channel].TagS.Add(cTag.Key, cTag);

                    CStdTag cStdTag = new CStdTag();

                    if (cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || cTag.PLCMaker.Equals(EMPLCMaker.LS))
                        cStdTag.CurrentDesc = cTag.Description;
                    else
                        cStdTag.CurrentDesc = cTag.Name;

                    cStdTag.Key = cTag.Key;
                    cStdTag.Address = cTag.Address;

                    CProjectManager.StdTagS.Add(cStdTag.Key, cStdTag);

                    SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    {
                        CreateAddressBlockS(CProjectManager.LogicDataS[cTag.Channel]);
                        RefreshDesign();
                    }
                    SplashScreenManager.CloseForm(false);
                }

                frmAddProperty.Dispose();
                frmAddProperty = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Add Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSymbolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int[] arrPLC = grvDesignPLC.GetSelectedRows();

                if (arrPLC == null || arrPLC.Length < 1)
                    return;

                if (
                    XtraMessageBox.Show("선택하신 " + arrPLC.Length + " 개의 심볼을 제거하시겠습니까?", "Delete Symbol",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    List<string> lstPLC = DeleteSymbolS(arrPLC);

                    foreach (string sName in lstPLC)
                    {
                        if (CProjectManager.LogicDataS.ContainsKey(sName))
                            CreateAddressBlockS(CProjectManager.LogicDataS[sName]);
                    }
                    RefreshDesign();
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Symbol Delete Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvDesignPLC_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnModuleSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tabDesign.SelectedTabPage = tpDesignDesign;

                FrmModuleSetting frmModule = new FrmModuleSetting();
                frmModule.PLCName = CProjectManager.LogicDataS.First().Key;
                frmModule.UEventModuleApplyClicked += FrmModuleSetting_ModuleApplyClick;
                frmModule.TopMost = true;
                frmModule.Show();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmModuleSetting_ModuleApplyClick()
        {
            try
            {
                ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Module Setting Apply Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnModuleInfoSetting_Click(object sender, EventArgs e)
        {
            btnModuleSetting_ItemClick(null, null);
        }

        private void chkIOExtend_CheckedChanged(object sender, EventArgs e)
        {
            ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
        }

        private void cboIOUsed_CheckedChanged(object sender, EventArgs e)
        {
            ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
        }

        private void ucAddressArea_GridDoubleClick(List<string> lstKey)
        {
            try
            {
                List<CTag> lstTag = new List<CTag>();

                foreach (string sKey in lstKey)
                {
                    if (CProjectManager.PLCTagS.ContainsKey(sKey))
                        lstTag.Add(CProjectManager.PLCTagS[sKey]);
                }

                grdDesignPLC.DataSource = null;
                grdDesignPLC.DataSource = lstTag;
                grdDesignPLC.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Address Adres Double Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboListType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboListType.EditValue == null)
                    return;

                string sType = (string) cboListType.EditValue;
                SetListTypeChangeView(sType);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("cboListType Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkExtend_CheckedChanged(object sender, EventArgs e)
        {
            ShowAddressArea();
        }

        private void chkUsed_CheckedChanged(object sender, EventArgs e)
        {
            ShowAddressArea();
        }

        private void cboPLCList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCList.EditValue;
                m_sPLCName = sPLCName;
                m_emPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

                SetMakerAddressArea();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("cboPLCList Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }



        private void btnAllTagView_Click(object sender, EventArgs e)
        {
            grdDesignPLC.DataSource = null;
            grdDesignPLC.DataSource = CProjectManager.PLCTagS.Values.ToList();
            grdDesignPLC.RefreshDataSource();
        }

        private void btnPLCTagExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmTagExportProperty frmTagExport = new FrmTagExportProperty();
                frmTagExport.TopMost = true;

                if (frmTagExport.ShowDialog() == DialogResult.Cancel)
                {
                    if (frmTagExport.DeletePLC != null && frmTagExport.DeletePLC.Count > 0)
                    {
                        SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                        {
                            List<string> lstPLC = frmTagExport.DeletePLC;

                            foreach (string sName in lstPLC)
                            {
                                if (CProjectManager.LogicDataS.ContainsKey(sName))
                                    CreateAddressBlockS(CProjectManager.LogicDataS[sName]);
                            }
                            RefreshDesign();
                        }
                        SplashScreenManager.CloseForm(false);
                    }
                }

                frmTagExport.Dispose();
                frmTagExport = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Tag Export Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnNewPLC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.LogicDataS.Count != 0)
                {
                    if (
                        XtraMessageBox.Show("해당 프로젝트의 기존 PLC 심볼에 대한 정보가 남아있습니다.\r\n새로운 PLC 심볼 파일을 생성하시겠습니까?", "New PLC",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        return;
                }

                ClearPLC();

                FrmAddPLC frmAddPLC = new FrmAddPLC();
                if (frmAddPLC.ShowDialog() == DialogResult.OK)
                {
                    if (CProjectManager.LogicDataS.ContainsKey(frmAddPLC.InputText))
                    {
                        XtraMessageBox.Show("Already Exist PLC Name!!", "Warning", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    {
                        NewPLCSymbol(frmAddPLC.InputText, frmAddPLC.PLCMaker);
                    }
                    SplashScreenManager.CloseForm(false);

                    ShowDesignPLCGrid();
                    ShowStdGrid();
                    SetPLCList();
                    SetListType();
                    ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);

                    CProjectManager.UpdateSystemMessage("New PLC", "PLC Create OK");
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("New PLC Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportIO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_emExcelListType = eExcelListType.IO;
                ExportIOList();

                CProjectManager.UpdateSystemMessage("Design", "Export IO OK");
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export IO Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnIOList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmIOExportProperty frmIOExportProperty = new FrmIOExportProperty();

                if (frmIOExportProperty.ShowDialog() == DialogResult.OK)
                {
                    m_bExport = true;
                    LoadExeltoSheet(frmIOExportProperty.SavePath);
                    m_sIOSavePath = frmIOExportProperty.SavePath;
                    btnSavePathOpen.EditValue = m_sIOSavePath;
                    CProjectManager.UpdateSystemMessage("Design", "Export IO/DUMMY OK");
                }

                frmIOExportProperty.Dispose();
                frmIOExportProperty = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export IO/DUMMY LIST Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportDummy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_emExcelListType = eExcelListType.DUMMY;
                ExportIOList();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export Dummy Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
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

        private void chkViewIOList_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_bExport && chkViewIOList.Checked)
            {
                XtraMessageBox.Show("Please Export I/O, Dummy List First!!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                chkViewIOList.Checked = false;
                return;
            }

            if (chkViewIOList.Checked)
            {
                tabMain.SelectedTabPage = tpIOList;
                chkViewIOList.Caption = "전체보기";
            }
            else
            {
                tabMain.SelectedTabPage = tpDesign;
                chkViewIOList.Caption = "IO/DUMMY LIST 보기";
            }
        }

        private void chkExcelEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcelEdit.Checked)
                IOSpreadSheet.ReadOnly = false;
            else
                IOSpreadSheet.ReadOnly = true;
        }

        private void chkExcelEditable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcelEditable.Checked)
                IOSpreadSheet.ReadOnly = false;
            else
                IOSpreadSheet.ReadOnly = true;
        }

        private void btnExcelSave_Click(object sender, EventArgs e)
        {
            if (m_sIOSavePath == string.Empty)
                return;

            IOSpreadSheet.SaveDocumentAs();

            XtraMessageBox.Show("Save Success!!!", "IO/DUMMY LIST SAVE", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnOpenExcelPath_Click(object sender, EventArgs e)
        {
            if (m_sIOSavePath == string.Empty)
                return;

            string sFolderPath = m_sIOSavePath.Substring(0, m_sIOSavePath.LastIndexOf("\\"));
            Process.Start(sFolderPath);
        }

        private void btnSavePathOpen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (m_sIOSavePath == string.Empty)
                    return;

                string sFolderPath = m_sIOSavePath.Substring(0, m_sIOSavePath.LastIndexOf("\\"));
                Process.Start(sFolderPath);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("SavePathOpen Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }
}
