using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.General;
using UDM.General.Csv;

namespace UDMIOMaker
{
    public class CMelsecExport
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private CPlcLogicData m_cData = null;
        private bool m_bExtend = false;
        private string m_sSavePath = string.Empty;

        private const int MELSEC_GENERAL_NORMAL_RANGE = 511;
        private const int MELSEC_GENERAL_EXTEND_RANGE = 1023;
        private const int MELSEC_D_NORMAL_RANGE = 8191;
        private const int MELSEC_D_EXTEND_RANGE = 12287;
        private const int MELSEC_T_NORMAL_RANGE = 204;
        private const int MELSEC_T_EXTEND_RANGE = 204;
        private const int MELSEC_C_NORMAL_RANGE = 102;
        private const int MELSEC_C_EXTEND_RANGE = 102;


        public CMelsecExport(EMPLCMaker emPLCMaker, CPlcLogicData cData)
        {
            m_emPLCMaker = emPLCMaker;
            m_cData = cData;
        }

        public bool IsExtendArea
        {
            get { return m_bExtend;}
            set { m_bExtend = value; }
        }

        public string SavePath
        {
            get { return m_sSavePath;}
            set { m_sSavePath = value; }
        }

        public bool ExportMelsecPLC()
        {
            bool bOK = false;

            if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer))
                bOK = ExportDeveloperFormat();
            else if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Works2))
                bOK = ExportWorks2LabelUsedFormat();
            //else if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Works2_Label_Used_X))
            //    bOK = ExportWorks2LabelNotUsedFormat();
            else if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Works3))
                bOK = ExportWorks3Format();
            else
                bOK = false;

            return bOK;
        }

        public bool ExportMelsecIOList()
        {
            bool bOK = false;

            if (m_cData == null)
                return false;

            DataSet DSIOList = GetIOListDataSet();

            if (DSIOList.Tables.Count == 0)
                return false;

            bOK = CUtil.ExportIOList(CProjectManager.IOListPath, m_sSavePath, m_cData.Name, DSIOList, true);

            return bOK;
        }

        public bool ExportMelsecDummyList(string sType)
        {
            bool bOK = false;

            if (m_cData == null)
                return false;

            DataSet DSDummyList = GetDummyListDataSet(sType);

            if (DSDummyList.Tables.Count == 0)
                return false;

            int iRowCount = -1;

            if (sType.Equals("B") || sType.Equals("W"))
                iRowCount = 16;
            else
                iRowCount = 10;

            bOK = CUtil.ExportDummyList(CProjectManager.DummyListPath, m_sSavePath, m_cData.Name, iRowCount, DSDummyList);

            return bOK;
        }

        private DataSet GetDummyListDataSet(string sType)
        {
            DataSet DS = new DataSet();

            if (sType.Equals("D") || sType.Equals("W"))
            {
                SetWordDummyMapDataSet(DS, sType);
                SetDummyBitDataSet(DS, sType);
            }
            else
                SetDummyMapDataSet(DS, sType);

            return DS;
        }

        private void SetWordDummyMapDataSet(DataSet DS, string sType)
        {
            try
            {
                int iMapPageIndex = 1;
                int iStartAddressRangeIndex = -1;
                int iRowCount = sType == "D" ? 10 : 16;
                DataTable DT = null;
                DataRow drRow = null;
                CBlockUnit cUnit = null;

                int iCount = GetUnitCount(sType);

                for (int i = 0; i <= iCount; i++)
                {
                    if (!m_cData.AddressBlockS[sType].UnitS.ContainsKey(i))
                        continue;

                    cUnit = m_cData.AddressBlockS[sType].UnitS[i];

                    if (i % (iRowCount * 30) == 0)
                    {
                        if (i != 0)
                            DS.Tables.Add(DT);

                        DT = new DataTable();
                        DT.TableName = sType + "_MAP_" + (iMapPageIndex++).ToString();

                        DT.Columns.Add("Range1");
                        DT.Columns.Add("Info1");
                        DT.Columns.Add("Address1");
                        DT.Columns.Add("Desc1");
                        DT.Columns.Add("Range2");
                        DT.Columns.Add("Info2");
                        DT.Columns.Add("Address2");
                        DT.Columns.Add("Desc2");
                        DT.Columns.Add("Range3");
                        DT.Columns.Add("Info3");
                        DT.Columns.Add("Address3");
                        DT.Columns.Add("Desc3");
                    }

                    if (cUnit.RangeIndex%iRowCount == 0)
                        iStartAddressRangeIndex++;

                    if (i % (30 * iRowCount) < (10 * iRowCount))
                        SetWordDummyListMap(0, cUnit, DT, 1, iStartAddressRangeIndex, iRowCount);
                    else if (i % (30 * iRowCount) < (20 * iRowCount))
                        SetWordDummyListMap(4, cUnit, DT, 2, iStartAddressRangeIndex, iRowCount);
                    else
                        SetWordDummyListMap(8, cUnit, DT, 3, iStartAddressRangeIndex, iRowCount);

                    if (i == (iCount - 1))
                    {
                        if (!DS.Tables.Contains(DT.TableName))
                            DS.Tables.Add(DT);
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Export DUMMY Word MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetDummyBitDataSet(DataSet DS, string sType)
        {
            try
            {
                int iStartRangeIndex = 0;
                int iRowCount = sType == "D" ? 10 : 16;
                int iCount = GetUnitCount(sType);

                DataTable DT;
                while (iStartRangeIndex <= iCount)
                {
                    DT = GetDummyDataTable(iStartRangeIndex, iRowCount, sType);

                    if (DT != null)
                        DS.Tables.Add(DT);

                    iStartRangeIndex += iRowCount;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Export Dummy Bit DataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private DataTable GetDummyDataTable(int iStartRangeIndex, int iRangeCount, string sType)
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sFirstRange = m_cData.AddressBlockS[sType].UnitS[iStartRangeIndex].AddressRange;
            sFirstRange = sFirstRange.Substring(0, sFirstRange.Length - 1);

            if (sFirstRange.Length < 4)
            {
                int iCount = 4 - sFirstRange.Length;
                for (int i = 0; i < iCount; i++)
                    sFirstRange = sFirstRange.Insert(0, "0");
            }

            string sLastRange = CUtil.ConvertMelsecAddressRange(iStartRangeIndex + iRangeCount, m_cData.AddressBlockS[sType].IsHexa);
            sLastRange = sLastRange.Substring(0, sLastRange.Length - 1);

            if (sLastRange.Length < 4)
            {
                int iCount = 4 - sLastRange.Length;
                for (int i = 0; i < iCount; i++)
                    sLastRange = sLastRange.Insert(0, "0");
            }

            string sTableName = string.Format("{0}-{1}", sFirstRange, sLastRange);
            DT.TableName = sTableName;

            DT.Columns.Add("Word1");
            DT.Columns.Add("Name1");
            DT.Columns.Add("Address1");
            DT.Columns.Add("Type1");
            DT.Columns.Add("Info1");
            DT.Columns.Add("Word2");
            DT.Columns.Add("Name2");
            DT.Columns.Add("Address2");
            DT.Columns.Add("Type2");
            DT.Columns.Add("Info2");

            List<CBlockUnit> cUnitS = new List<CBlockUnit>();
            CBlockUnit cUnit = null;

            for (int i = 0; i < iRangeCount; i++)
            {
                if (!m_cData.AddressBlockS[sType].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;

                cUnit = m_cData.AddressBlockS[sType].UnitS[iStartRangeIndex + i];

                if (cUnit.IsUsed)
                    cUnitS.Add(cUnit);
            }

            if (cUnitS.Count == 0 && cUnitS.Count == 0)
                return null;

            CTagItem cItem;
            int iRowIndex = 0;
            int iLeftCount = cUnitS.Count / 2;
            bool bNew = false;
            string sWordDesc = string.Empty;

            if (cUnitS.Count%2 == 1)
                iLeftCount += 1;

            for (int i = 0; i < cUnitS.Count; i++)
            {
                if (i < iLeftCount)
                {
                    for (int j = 0; j < cUnitS[i].TagItemS.Count; j++)
                    {
                        if (j == 0)
                            cUnitS[i].TagItemS.Sort((x, y) => string.Compare(x.Address, y.Address));

                        cItem = cUnitS[i].TagItemS[j];
                        if (!cItem.DataType.Equals(EMDataType.Bool))
                        {
                            sWordDesc = cItem.Description;
                            continue;
                        }

                        drRow = DT.NewRow();

                        drRow[0] =
                            CUtil.GetVerticalAddress(string.Format("{0}{1}", sType, cUnitS[i].AddressRange));
                        drRow[1] = cItem.Description;
                        drRow[2] = cItem.Address;
                        drRow[3] = cItem.DataType.ToString().ToUpper();
                        drRow[4] = sWordDesc;

                        DT.Rows.Add(drRow);
                    }
                }
                else
                {
                    bNew = false;

                    for (int j = 0; j < cUnitS[i].TagItemS.Count; j++)
                    {
                        if (j == 0)
                            cUnitS[i].TagItemS.Sort((x, y) => string.Compare(x.Address, y.Address));

                        cItem = cUnitS[i].TagItemS[j];
                        if (!cItem.DataType.Equals(EMDataType.Bool))
                        {
                            sWordDesc = cItem.Description;
                            continue;
                        }

                        if (DT.Rows.Count > iRowIndex)
                            drRow = DT.Rows[iRowIndex++];
                        else
                        {
                            bNew = true;
                            drRow = DT.NewRow();
                            iRowIndex++;
                        }

                        drRow[5] =
                            CUtil.GetVerticalAddress(string.Format("{0}{1}", sType, cUnitS[i].AddressRange));
                        drRow[6] = cItem.Description;
                        drRow[7] = cItem.Address;
                        drRow[8] = cItem.DataType.ToString().ToUpper();
                        drRow[9] = sWordDesc;

                        if (bNew)
                            DT.Rows.Add(drRow);
                    }
                }
            }

            cUnitS.Clear();
            cUnit = null;

            return DT;
        }

        private int GetUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("D"))
            {
                if (m_bExtend)
                    iCount = MELSEC_D_EXTEND_RANGE;
                else
                    iCount = MELSEC_D_NORMAL_RANGE;
            }
            else if (sType.Equals("T"))
            {
                if (m_bExtend)
                    iCount = MELSEC_T_EXTEND_RANGE;
                else
                    iCount = MELSEC_T_NORMAL_RANGE;
            }
            else if (sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = MELSEC_C_EXTEND_RANGE;
                else
                    iCount = MELSEC_C_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = MELSEC_GENERAL_EXTEND_RANGE;
                else
                    iCount = MELSEC_GENERAL_NORMAL_RANGE;
            }

            return iCount;
        }

        private void SetDummyMapDataSet(DataSet DS, string sType)
        {
            try
            {
                int iMapPageIndex = 1;
                DataTable DT = null;
                DataRow drRow = null;
                CBlockUnit cUnit = null;

                int iCount = GetUnitCount(sType);

                for (int i = 0; i <= iCount; i++)
                {
                    if (!m_cData.AddressBlockS[sType].UnitS.ContainsKey(i))
                        continue;

                    cUnit = m_cData.AddressBlockS[sType].UnitS[i];

                    if (i % 30 == 0)
                    {
                        if (i != 0)
                            DS.Tables.Add(DT);

                        DT = new DataTable();
                        DT.TableName = sType + "_MAP_" + (iMapPageIndex++).ToString();

                        DT.Columns.Add("Range1");
                        DT.Columns.Add("Info1");
                        DT.Columns.Add("Address1");
                        DT.Columns.Add("Desc1");
                        DT.Columns.Add("Range2");
                        DT.Columns.Add("Info2");
                        DT.Columns.Add("Address2");
                        DT.Columns.Add("Desc2");
                        DT.Columns.Add("Range3");
                        DT.Columns.Add("Info3");
                        DT.Columns.Add("Address3");
                        DT.Columns.Add("Desc3");
                    }

                    if (i%30 < 10)
                        SetDummyListMap(0, cUnit, DT, 1);
                    else if (i%30 < 20)
                        SetDummyListMap(4, cUnit, DT, 2);
                    else
                        SetDummyListMap(8, cUnit, DT, 3);

                    if (i == (iCount - 1))
                    {
                        if (!DS.Tables.Contains(DT.TableName))
                            DS.Tables.Add(DT);
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Export DUMMY MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetWordDummyListMap(int iStartRow, CBlockUnit cUnit, DataTable DT, int iColIndex, int iStartAddressRangeIndex, int iRowCount)
        {
            DataRow drRow = null;

            if(iColIndex == 1)
                drRow = DT.NewRow();
            else if (iColIndex == 2)
                drRow = DT.Rows[((cUnit.RangeIndex % (30 * iRowCount)) - (10 * iRowCount))];
            else if (iColIndex == 3)
                drRow = DT.Rows[((cUnit.RangeIndex % (30 * iRowCount)) - (20 * iRowCount))];
                

            drRow[iStartRow] = string.Format("{0}\n-\n{1}",
                CUtil.ConvertMelsecAddressRange(iStartAddressRangeIndex, cUnit.IsHexa), CUtil.ConvertMelsecAddressRange(iStartAddressRangeIndex + 1, cUnit.IsHexa));
            drRow[iStartRow + 1] = string.Empty;
            drRow[iStartRow + 2] = string.Format("{0}{1}", cUnit.AddressHeader, cUnit.AddressRange.Substring(0, cUnit.AddressRange.Length - 1));

            foreach (var who in cUnit.TagItemS)
            {
                if (who.DataType != EMDataType.Bool)
                {
                    drRow[iStartRow + 3] = who.Description;
                    break;
                }
            }

            if(iColIndex == 1)
                DT.Rows.Add(drRow);
        }
        
        private void SetDummyListMap(int iStartRow, CBlockUnit cUnit, DataTable DT, int iColIndex)
        {
            DataRow drRow = null;

            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                if(iColIndex == 1)
                    drRow = DT.NewRow();
                else if (iColIndex == 2)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 10) * cUnit.MaximumItemLimit) + i];
                else if (iColIndex == 3)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 20) * cUnit.MaximumItemLimit) + i];

                drRow[iStartRow] = string.Format("{0}\n-\n{1}", cUnit.AddressRange,
                    CUtil.ConvertMelsecAddressRange(cUnit.RangeIndex + 1, cUnit.IsHexa));
                drRow[iStartRow + 1] = string.Empty;
                drRow[iStartRow + 2] = CUtil.GetMelsecNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);

                if (cUnit.TagItemS.Count > i)
                    drRow[iStartRow + 3] = cUnit.TagItemS[i].Description;

                if(iColIndex == 1)
                    DT.Rows.Add(drRow);
            }
        }

        private DataSet GetIOListDataSet()
        {
            DataSet DSTotal = new DataSet();
            SetMapDataSet(DSTotal);
            SetIODataSet(DSTotal);

            return DSTotal;
        }

        private void SetIODataSet(DataSet DS)
        {
            try
            {
                int iStartRangeIndex = 0;

                int iCount = GetUnitCount(string.Empty);

                DataTable DT;
                while (iStartRangeIndex <= iCount)
                {
                    DT = GetIODataTable(iStartRangeIndex, 16);

                    if (DT != null)
                        DS.Tables.Add(DT);

                    iStartRangeIndex += 16;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Export IODataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private DataTable GetIODataTable(int iStartRangeIndex, int iRangeCount)
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sLastRange = string.Format("{0}FF",
                m_cData.IOModuleBlock.UnitS[iStartRangeIndex].AddressRange.Substring(0,
                    m_cData.IOModuleBlock.UnitS[iStartRangeIndex].AddressRange.Length - 2));

            string sTableName = string.Format("{0}-{1}", m_cData.IOModuleBlock.UnitS[iStartRangeIndex].AddressRange, sLastRange);

            DT.TableName = sTableName;

            DT.Columns.Add("XRange");
            DT.Columns.Add("XName");
            DT.Columns.Add("XAddress");
            DT.Columns.Add("XType");
            DT.Columns.Add("YRange");
            DT.Columns.Add("YName");
            DT.Columns.Add("YAddress");
            DT.Columns.Add("YType");

            List<CBlockUnit> cXUnitS = new List<CBlockUnit>();
            List<CBlockUnit> cYUnitS = new List<CBlockUnit>();
            CBlockUnit cXUnit = null;
            CBlockUnit cYUnit = null;
            int iMaxUnitCount = -1;
            for (int i = 0; i < iRangeCount; i++)
            {
                if(!m_cData.AddressBlockS["X"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;
                if (!m_cData.AddressBlockS["Y"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;

                    cXUnit = m_cData.AddressBlockS["X"].UnitS[iStartRangeIndex + i];
                    cYUnit = m_cData.AddressBlockS["Y"].UnitS[iStartRangeIndex + i];

                if(cXUnit.IsUsed)
                    cXUnitS.Add(cXUnit);
                if (cYUnit.IsUsed)
                    cYUnitS.Add(cYUnit);
            }

            if (cXUnitS.Count == 0 && cYUnitS.Count == 0)
                return null;

            string sModuleInfo = string.Format("{0}\r\n{1}", m_cData.IOModuleBlock.UnitS[iStartRangeIndex].Module,
                m_cData.IOModuleBlock.UnitS[iStartRangeIndex].Description);

            drRow = DT.NewRow();
            drRow[0] = sTableName;
            drRow[1] = sModuleInfo;

            DT.Rows.Add(drRow);

            iMaxUnitCount = cXUnitS.Count > cYUnitS.Count ? cXUnitS.Count : cYUnitS.Count;
            CTagItem cItem;
            int iRowIndex = 1;

            for (int i = 0; i < iMaxUnitCount; i++)
            {
                if (cXUnitS.Count > i)
                {
                    for (int j = 0; j < cXUnitS[i].TagItemS.Count; j++)
                    {
                        if (j == 0)
                            cXUnitS[i].TagItemS.Sort((x, y) => string.Compare(x.Address, y.Address));

                        drRow = DT.NewRow();
                        cItem = cXUnitS[i].TagItemS[j];

                        drRow[0] = CUtil.GetVerticalAddress(string.Format("X{0}", cXUnitS[i].AddressRange));
                        drRow[1] = cItem.Description;
                        drRow[2] = cItem.Address;
                        drRow[3] = cItem.DataType.ToString().ToUpper();

                        DT.Rows.Add(drRow);
                    }
                }

                if (cYUnitS.Count > i)
                {
                    bool bNew = false;

                    for (int j = 0; j < cYUnitS[i].TagItemS.Count; j++)
                    {
                        bNew = false;

                        if (j == 0)
                            cYUnitS[i].TagItemS.Sort((x, y) => string.Compare(x.Address, y.Address));

                        if (DT.Rows.Count > iRowIndex)
                            drRow = DT.Rows[iRowIndex++];
                        else
                        {
                            bNew = true;
                            drRow = DT.NewRow();
                            iRowIndex++;
                        }

                        cItem = cYUnitS[i].TagItemS[j];

                        drRow[4] = CUtil.GetVerticalAddress(string.Format("Y{0}", cYUnitS[i].AddressRange));
                        drRow[5] = cItem.Description;
                        drRow[6] = cItem.Address;
                        drRow[7] = cItem.DataType.ToString().ToUpper();

                        if (bNew)
                            DT.Rows.Add(drRow);
                    }
                }
            }

            cXUnitS.Clear();
            cYUnitS.Clear();
            cXUnitS = null;
            cYUnitS = null;
            cXUnit = null;
            cYUnit = null;

            return DT;
        }

        private void SetMapDataSet(DataSet DS)
        {
            try
            {
                int iMapPageIndex = 1;
                bool bLeft = false;
                DataTable DT = null;
                DataRow drRow = null;
                CBlockUnit cUnit = null;

                int iCount = GetUnitCount(string.Empty);

                for (int i = 0; i <= iCount; i++)
                {
                    if (!m_cData.IOModuleBlock.UnitS.ContainsKey(i))
                        continue;

                    cUnit = m_cData.IOModuleBlock.UnitS[i];

                    if (i%96 == 0)
                    {
                        if (i != 0)
                            DS.Tables.Add(DT);

                        DT = new DataTable();
                        DT.TableName = "XY_MAP_" + (iMapPageIndex++).ToString();

                        DT.Columns.Add("SlotX");
                        DT.Columns.Add("Range1");
                        DT.Columns.Add("Range2");
                        DT.Columns.Add("Range3");
                        DT.Columns.Add("Ragne4");
                        DT.Columns.Add("InfoX");
                        DT.Columns.Add("SlotY");
                        DT.Columns.Add("Range5");
                        DT.Columns.Add("Range6");
                        DT.Columns.Add("Range7");
                        DT.Columns.Add("Ragne8");
                        DT.Columns.Add("InfoY");
                    }

                    if (i%48 == 0)
                    {
                        if (!bLeft)
                            bLeft = true;
                        else
                            bLeft = false;
                    }

                    if (bLeft)
                    {
                        drRow = DT.NewRow();

                        drRow[0] = cUnit.Slot;
                        drRow[1] = "XY";
                        drRow[2] = string.Format("'{0}", cUnit.AddressRange);
                        drRow[3] = "-";
                        drRow[4] = string.Format("'{0}", GetIOLastRange(cUnit.AddressRange));
                        drRow[5] = string.Format("{0}\r\n{1}", cUnit.Module, cUnit.Description);

                        DT.Rows.Add(drRow);
                    }
                    else
                    {
                        drRow = DT.Rows[i%48];

                        drRow[6] = cUnit.Slot;
                        drRow[7] = "XY";
                        drRow[8] = string.Format("'{0}", cUnit.AddressRange);
                        drRow[9] = "-";
                        drRow[10] = string.Format("'{0}", GetIOLastRange(cUnit.AddressRange));
                        drRow[11] = string.Format("{0}\r\n{1}", cUnit.Module, cUnit.Description);
                    }

                    if (i == (iCount - 1))
                    {
                        if (!DS.Tables.Contains(DT.TableName))
                            DS.Tables.Add(DT);
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec Export MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private string GetIOLastRange(string sFirstRange)
        {
            string sLastRange = string.Empty;

            sLastRange = string.Format("{0}F", sFirstRange.Substring(0, sFirstRange.Length - 1));

            return sLastRange;
        }

        private bool ExportWorks3Format()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_Works3";
                dlgSave.Filter = "*.csv|*.csv";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                DataTable DT = GetWorks3Table();
                bOK = WriteToCSV(dlgSave.FileName, DT);

                dlgSave.Dispose();
                dlgSave = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Export Works3 Format Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool ExportWorks2LabelNotUsedFormat()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_Works2_Label_Used";
                dlgSave.Filter = "*.csv|*.csv";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                DataTable DT = GetWorks2LabelNotUsedTable();
                bOK = WriteToCSV(dlgSave.FileName, DT);

                dlgSave.Dispose();
                dlgSave = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Export Works2 Format Label Not Used Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool ExportWorks2LabelUsedFormat()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_Works2_Label_Used";
                dlgSave.Filter = "*.csv|*.csv";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                DataTable DT = GetWorks2LabelUsedTable();
                bOK = WriteToCSV(dlgSave.FileName, DT);

                dlgSave.Dispose();
                dlgSave = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Export Works2 Format Label Used Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool WriteToCSV(string sPath, DataTable DT)
        {
            bool bOK = false;

            try
            {
                FileStream fsOutput = new FileStream(sPath, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(1200));
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)

                        str.Append(string.Format("{0}\t", field));

                    str.Remove(str.Length - 1, 1);

                    str.Append("\r\n");

                }

                str.Remove(str.Length - 2, 2);
                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();

                bOK = true;

                fsOutput = null;
                srOutput = null;
                str = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Export Comma Delimited Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool ExportDeveloperFormat()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_Developer";
                dlgSave.Filter = "*.csv|*.csv";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                CCsvWriter cWriter = new CCsvWriter(true);
                cWriter.Header = GetDeveloperHeader();
                cWriter.CsvType = EMCsvType.Comma;

                cWriter.Open(dlgSave.FileName);

                string sLine = string.Empty;

                foreach (var who in m_cData.TagS)
                {
                    if(who.Value.Description != string.Empty)
                        sLine = string.Format("{0},{1},{2}", who.Value.Address, who.Value.Note, who.Value.Description);
                    else
                        sLine = string.Format("{0},{1},{2}", who.Value.Address, who.Value.Note, who.Value.Name);

                    cWriter.WriteLine(sLine);
                }

                bOK = true;

                cWriter.Close();
                cWriter = null;

                dlgSave.Dispose();
                dlgSave = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Export Developer Format Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;

        }

        private List<string> GetDeveloperHeader()
        {
            List<string> lstHeader = new List<string>();

            lstHeader.Add("Device");
            lstHeader.Add("Label");
            lstHeader.Add("Comment");
            return lstHeader;
        }

        private DataTable GetWorks2LabelUsedTable()
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sFirstRow = string.Format("IO_Maker_Export_{0}_PLC", m_cData.Name);

            string sColumn1 = "Class";
            string sColumn2 = "Label Name";
            string sColumn3 = "Data Type";
            string sColumn4 = "Constant";
            string sColumn5 = "Device";
            string sColumn6 = "Address";
            string sColumn7 = "Comment";
            string sColumn8 = "Remark";
            string sColumn9 = "Relation with System Label";
            string sColumn10 = "System Label Name";
            string sColumn11 = "Attribute";
        
            DT.Columns.Add(sColumn1);
            DT.Columns.Add(sColumn2);
            DT.Columns.Add(sColumn3);
            DT.Columns.Add(sColumn4);
            DT.Columns.Add(sColumn5);
            DT.Columns.Add(sColumn6);
            DT.Columns.Add(sColumn7);
            DT.Columns.Add(sColumn8);
            DT.Columns.Add(sColumn9);
            DT.Columns.Add(sColumn10);
            DT.Columns.Add(sColumn11);

            drRow = DT.NewRow();
            drRow[0] = sFirstRow;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sColumn1;
            drRow[1] = sColumn2;
            drRow[2] = sColumn3;
            drRow[3] = sColumn4;
            drRow[4] = sColumn5;
            drRow[5] = sColumn6;
            drRow[6] = sColumn7;
            drRow[7] = sColumn8;
            drRow[8] = sColumn9;
            drRow[9] = sColumn10;
            drRow[10] = sColumn11;

            DT.Rows.Add(drRow);

            foreach (var who in m_cData.TagS)
            {
                drRow = DT.NewRow();

                drRow[0] = "VAR_GLOBAL";
                drRow[1] = who.Value.Name;
                drRow[2] = who.Value.DataType.ToString().ToUpper();
                drRow[4] = who.Value.Address;
                drRow[6] = who.Value.Description;

                DT.Rows.Add(drRow);
            }

            return DT;
        }

        private DataTable GetWorks2LabelNotUsedTable()
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sFirstRow = string.Format("IO_Maker_Export_{0}_PLC", m_cData.Name);

            string sColumn1 = "Device Name";
            string sColumn2 = "Comment";

            DT.Columns.Add(sColumn1);
            DT.Columns.Add(sColumn2);

            drRow = DT.NewRow();
            drRow[0] = sFirstRow;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sColumn1;
            drRow[1] = sColumn2;
            
            DT.Rows.Add(drRow);

            foreach (var who in m_cData.TagS)
            {
                drRow = DT.NewRow();

                drRow[0] = who.Value.Address;
                drRow[1] = who.Value.Name;

                DT.Rows.Add(drRow);
            }

            return DT;
        }

        private DataTable GetWorks3Table()
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sFirstRow = string.Format("IO_Maker_Export_{0}_PLC", m_cData.Name);

            string sColumn1 = "Class";
            string sColumn2 = "Label Name";
            string sColumn3 = "Data Type";
            string sColumn4 = "Constant";
            string sColumn5 = "Initial Value";
            string sColumn6 = "Assign (Device/Label)";
            string sColumn7 = "Address";
            string sColumn8 = "Comment";
            string sColumn9 = "Comment 2";
            string sColumn10 = "Comment 3";
            string sColumn11 = "Comment 4";
            string sColumn12 = "Comment 5";
            string sColumn13 = "Japanese/日本語";
            string sColumn14 = "English";
            string sColumn15 = "Chinese Simplified/简体中文";
            string sColumn16 = "Korean/한국어";
            string sColumn17 = "Chinese Traditional/繁體中文";
            string sColumn18 = "Reserved1";
            string sColumn19 = "Reserved2";
            string sColumn20 = "Reserved3";
            string sColumn21 = "Reserved4";
            string sColumn22 = "Reserved5";
            string sColumn23 = "Reserved6";
            string sColumn24 = "Remark";
            string sColumn25 = "System Label Relation";
            string sColumn26 = "System Label Name";
            string sColumn27 = "Attribute";
            string sColumn28 = "Access from External Device";

            DT.Columns.Add(sColumn1);
            DT.Columns.Add(sColumn2);
            DT.Columns.Add(sColumn3);
            DT.Columns.Add(sColumn4);
            DT.Columns.Add(sColumn5);
            DT.Columns.Add(sColumn6);
            DT.Columns.Add(sColumn7);
            DT.Columns.Add(sColumn8);
            DT.Columns.Add(sColumn9);
            DT.Columns.Add(sColumn10);
            DT.Columns.Add(sColumn11);
            DT.Columns.Add(sColumn12);
            DT.Columns.Add(sColumn13);
            DT.Columns.Add(sColumn14);
            DT.Columns.Add(sColumn15);
            DT.Columns.Add(sColumn16);
            DT.Columns.Add(sColumn17);
            DT.Columns.Add(sColumn18);
            DT.Columns.Add(sColumn19);
            DT.Columns.Add(sColumn20);
            DT.Columns.Add(sColumn21);
            DT.Columns.Add(sColumn22);
            DT.Columns.Add(sColumn23);
            DT.Columns.Add(sColumn24);
            DT.Columns.Add(sColumn25);
            DT.Columns.Add(sColumn26);
            DT.Columns.Add(sColumn27);
            DT.Columns.Add(sColumn28);

            drRow = DT.NewRow();
            drRow[0] = sFirstRow;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sColumn1;
            drRow[1] = sColumn2;
            drRow[2] = sColumn3;
            drRow[3] = sColumn4;
            drRow[4] = sColumn5;
            drRow[5] = sColumn6;
            drRow[6] = sColumn7;
            drRow[7] = sColumn8;
            drRow[8] = sColumn9;
            drRow[9] = sColumn10;
            drRow[10] = sColumn11;
            drRow[11] = sColumn12;
            drRow[12] = sColumn13;
            drRow[13] = sColumn14;
            drRow[14] = sColumn15;
            drRow[15] = sColumn16;
            drRow[16] = sColumn17;
            drRow[17] = sColumn18;
            drRow[18] = sColumn19;
            drRow[19] = sColumn20;
            drRow[20] = sColumn21;
            drRow[21] = sColumn22;
            drRow[22] = sColumn23;
            drRow[23] = sColumn24;
            drRow[24] = sColumn25;
            drRow[25] = sColumn26;
            drRow[26] = sColumn27;
            drRow[27] = sColumn28;

            DT.Rows.Add(drRow);

            foreach (var who in m_cData.TagS)
            {
                drRow = DT.NewRow();

                drRow[0] = "VAR_GLOBAL";
                drRow[1] = who.Value.Name;
                drRow[2] = who.Value.DataType.ToString().ToUpper();
                drRow[5] = who.Value.Address;
                drRow[7] = who.Value.Description;

                DT.Rows.Add(drRow);
            }

            return DT;
        }


    }
}
