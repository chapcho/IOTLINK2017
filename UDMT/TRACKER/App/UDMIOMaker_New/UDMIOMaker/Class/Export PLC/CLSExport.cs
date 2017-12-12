using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;

namespace UDMIOMaker
{
    public class CLSExport
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private CPlcLogicData m_cData = null;
        private bool m_bExtend = false;
        private string m_sSavePath = string.Empty;

        private const int LS_GENERAL_NORMAL_RANGE = 1023;
        private const int LS_GENERAL_EXTEND_RANGE = 2047;
        private const int LS_TC_NORMAL_RANGE = 102;
        private const int LS_TC_EXTEND_RANGE = 204;
        private const int LS_L_NORMAL_RANGE = 5630;
        private const int LS_L_EXTEND_RANGE = 11263;
        private const int LS_N_NORMAL_RANGE = 11263;
        private const int LS_N_EXTEND_RANGE = 21503;
        private const int LS_MD_NORMAL_RANGE = 12000;
        private const int LS_MD_EXTEND_RANGE = 25000;


        public CLSExport(EMPLCMaker emPLCMaker, CPlcLogicData cData)
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
            get { return m_sSavePath; }
            set { m_sSavePath = value; }
        }

        public bool ExportLSPLC()
        {
            bool bOK = false;

            bOK = ExportLSTagFormat();

            return bOK;
        }

        public bool ExportLSIOList()
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

        public bool ExportLSDummyList(string sType)
        {
            bool bOK = false;

            if (m_cData == null)
                return false;

            DataSet DSDummyList = GetDummyListDataSet(sType);

            if (DSDummyList.Tables.Count == 0)
                return false;

            int iRowCount = -1;

            if (sType.Equals("M") || sType.Equals("L"))
                iRowCount = 16;
            else
                iRowCount = 10;

            bOK = CUtil.ExportDummyList(CProjectManager.DummyListPath, m_sSavePath, m_cData.Name, iRowCount, DSDummyList);

            return bOK;
        }

        private DataSet GetDummyListDataSet(string sType)
        {
            DataSet DS = new DataSet();

            if (sType.Equals("D"))
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
                int iRowCount = 10;
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
                        {
                            if (DS.Tables.Contains(DT.TableName))
                                continue;

                            DS.Tables.Add(DT);
                        }

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

                    if (cUnit.RangeIndex % iRowCount == 0)
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
                CProjectManager.UpdateSystemMessage("LS Export DUMMY Word MapDataSet Error",
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
                int iRowCount = 10;
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
                CProjectManager.UpdateSystemMessage("LS Export Dummy Bit DataSet Error",
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

            if (sFirstRange.Length < 6)
            {
                int iCount = 6 - sFirstRange.Length;
                for (int i = 0; i < iCount; i++)
                    sFirstRange = sFirstRange.Insert(0, "0");
            }

            string sLastRange = CUtil.ConvertLSAddressRange(iStartRangeIndex + iRangeCount);
            sLastRange = sLastRange.Substring(0, sLastRange.Length - 1);

            if (sLastRange.Length < 6)
            {
                int iCount = 6 - sLastRange.Length;
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

            if (cUnitS.Count % 2 == 1)
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
                            CUtil.GetVerticalAddress(string.Format("{0}{1}", sType,
                                cUnitS[i].AddressRange.Substring(0, cUnitS[i].AddressRange.Length - 1)));
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
                            CUtil.GetVerticalAddress(string.Format("{0}{1}", sType,
                                cUnitS[i].AddressRange.Substring(0, cUnitS[i].AddressRange.Length - 1)));
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
                        {
                            if(DS.Tables.Contains(DT.TableName))
                                continue;
                             
                            DS.Tables.Add(DT);
                        }

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

                    if (i % 30 < 10)
                        SetDummyListMap(0, cUnit, DT, 1);
                    else if (i % 30 < 20)
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
                CProjectManager.UpdateSystemMessage("LS Export DUMMY MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetWordDummyListMap(int iStartRow, CBlockUnit cUnit, DataTable DT, int iColIndex, int iStartAddressRangeIndex, int iRowCount)
        {
            DataRow drRow = null;

            if (iColIndex == 1)
                drRow = DT.NewRow();
            else if (iColIndex == 2)
                drRow = DT.Rows[((cUnit.RangeIndex % (30 * iRowCount)) - (10 * iRowCount))];
            else if (iColIndex == 3)
                drRow = DT.Rows[((cUnit.RangeIndex % (30 * iRowCount)) - (20 * iRowCount))];

            string sStartRange = CUtil.ConvertLSAddressRange(iStartAddressRangeIndex).Remove(0, 1);
            string sLastRange = CUtil.ConvertLSAddressRange(iStartAddressRangeIndex + 1).Remove(0, 1);

            drRow[iStartRow] = string.Format("{0}\n-\n{1}",sStartRange, sLastRange);
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

            if (iColIndex == 1)
                DT.Rows.Add(drRow);
        }

        private void SetDummyListMap(int iStartRow, CBlockUnit cUnit, DataTable DT, int iColIndex)
        {
            DataRow drRow = null;
            int iWordCount = 0;

            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                if (iColIndex == 1)
                    drRow = DT.NewRow();
                else if (iColIndex == 2)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 10) * cUnit.MaximumItemLimit) + i];
                else if (iColIndex == 3)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 20) * cUnit.MaximumItemLimit) + i];

                if (cUnit.AddressHeader.Equals("T") || cUnit.AddressHeader.Equals("C"))
                {
                    string sFirstRange = cUnit.AddressRange;
                    string sLastRange = CUtil.ConvertLSAddressRange(cUnit.RangeIndex + 1);

                    if (sFirstRange.StartsWith("0") && sFirstRange.Length > 5)
                        sFirstRange = sFirstRange.Remove(0, 1);

                    if (sLastRange.StartsWith("0") && sLastRange.Length > 5)
                        sLastRange = sLastRange.Remove(0, 1);

                    drRow[iStartRow] = string.Format("{0}\n-\n{1}", sFirstRange, sLastRange);
                }
                else
                    drRow[iStartRow] = string.Format("{0}\n-\n{1}", cUnit.AddressRange, CUtil.ConvertLSAddressRange(cUnit.RangeIndex + 1));

                drRow[iStartRow + 1] = string.Empty;
                drRow[iStartRow + 2] = CUtil.GetLSNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);

                if (cUnit.AddressHeader.Equals("M") && cUnit.TagItemS.Count > i && !cUnit.TagItemS[i].DataType.Equals(EMDataType.Bool))
                    iWordCount++;

                if (cUnit.TagItemS.Count > i)
                    drRow[iStartRow + 3] = cUnit.TagItemS[i + iWordCount].Description;

                if (iColIndex == 1)
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

        private int GetUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("L"))
            {
                if (m_bExtend)
                    iCount = LS_L_EXTEND_RANGE;
                else
                    iCount = LS_L_NORMAL_RANGE;
            }
            else if (sType.Equals("N"))
            {
                if (m_bExtend)
                    iCount = LS_N_EXTEND_RANGE;
                else
                    iCount = LS_N_NORMAL_RANGE;
            }
            else if (sType.Equals("M") || sType.Equals("D"))
            {
                if (m_bExtend)
                    iCount = LS_MD_EXTEND_RANGE;
                else
                    iCount = LS_MD_NORMAL_RANGE;
            }
            else if (sType.Equals("T") || sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = LS_TC_EXTEND_RANGE;
                else
                    iCount = LS_TC_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = LS_GENERAL_EXTEND_RANGE;
                else
                    iCount = LS_GENERAL_NORMAL_RANGE;
            }

            return iCount;
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
                CProjectManager.UpdateSystemMessage("LS Export IODataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private DataTable GetIODataTable(int iStartRangeIndex, int iRangeCount)
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;



            string sTableName = string.Format("{0}-{1}", m_cData.IOModuleBlock.UnitS[iStartRangeIndex].AddressRange,
                GetIOMapLastRange(m_cData.IOModuleBlock.UnitS[iStartRangeIndex].AddressRange));

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
                if (!m_cData.AddressBlockS["P"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;
                if (!m_cData.AddressBlockS["K"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;

                cXUnit = m_cData.AddressBlockS["P"].UnitS[iStartRangeIndex + i];
                cYUnit = m_cData.AddressBlockS["K"].UnitS[iStartRangeIndex + i];

                if (cXUnit.IsUsed)
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

                        drRow[0] = CUtil.GetVerticalAddress(string.Format("P{0}", cXUnitS[i].AddressRange));
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

                        cItem = cYUnitS[i].TagItemS[j];

                        if(!cItem.DataType.Equals(EMDataType.Bool))
                            continue;

                        if (DT.Rows.Count > iRowIndex)
                            drRow = DT.Rows[iRowIndex++];
                        else
                        {
                            bNew = true;
                            drRow = DT.NewRow();
                            iRowIndex++;
                        }

                        drRow[4] = CUtil.GetVerticalAddress(string.Format("K{0}", cYUnitS[i].AddressRange));
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

                    if (i % 96 == 0)
                    {
                        if (i != 0)
                            DS.Tables.Add(DT);

                        DT = new DataTable();
                        DT.TableName = "IO_MAP_" + (iMapPageIndex++).ToString();

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

                    if (i % 48 == 0)
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
                        drRow[1] = "IO";
                        drRow[2] = string.Format("'{0}", cUnit.AddressRange);
                        drRow[3] = "-";
                        drRow[4] = string.Format("'{0}", GetIOLastRange(cUnit.AddressRange));
                        drRow[5] = string.Format("{0}\r\n{1}", cUnit.Module, cUnit.Description);

                        DT.Rows.Add(drRow);
                    }
                    else
                    {
                        drRow = DT.Rows[i % 48];

                        drRow[6] = cUnit.Slot;
                        drRow[7] = "IO";
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
                CProjectManager.UpdateSystemMessage("LS Export MapDataSet Error",
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

        private string GetIOMapLastRange(string sFirstRange)
        {
            string sLastRange = string.Empty;
            int iFirstValue = Convert.ToInt32(sFirstRange.Substring(0, sFirstRange.Length - 1));
            int iLastValue = iFirstValue + 15;

            sLastRange = iLastValue.ToString();

            int iLength = sLastRange.Length;

            if (iLength < 5)
            {
                for (int i = 0; i < 5 - iLength; i++)
                    sLastRange = sLastRange.Insert(0, "0");
            }

            sLastRange = string.Format("{0}F", sLastRange);

            return sLastRange;
        }


        private bool ExportLSTagFormat()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_LS";
                dlgSave.Filter = "*.csv|*.csv";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                DataTable DT = GetLSTable();
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

        private DataTable GetLSTable()
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sColumn1 = "변수";
            string sColumn2 = "타입";
            string sColumn3 = "디바이스";
            string sColumn4 = "사용 유무";
            string sColumn5 = "설명문";

            DT.Columns.Add(sColumn1);
            DT.Columns.Add(sColumn2);
            DT.Columns.Add(sColumn3);
            DT.Columns.Add(sColumn4);
            DT.Columns.Add(sColumn5);
           
            drRow = DT.NewRow();
            drRow[0] = sColumn1;
            drRow[1] = sColumn2;
            drRow[2] = sColumn3;
            drRow[3] = sColumn4;
            drRow[4] = sColumn5;

            DT.Rows.Add(drRow);

            foreach (var who in m_cData.TagS)
            {
                drRow = DT.NewRow();

                drRow[0] = who.Value.Name;
                drRow[1] = GetDataType(who.Value.DataType, who.Value.Address).ToUpper();
                drRow[2] = who.Value.Address.ToUpper();
                drRow[3] = 0;
                drRow[4] = who.Value.Description;

                DT.Rows.Add(drRow);
            }

            return DT;
        }

        private bool WriteToCSV(string sPath, DataTable DT)
        {
            bool bOK = false;

            try
            {
                FileStream fsOutput = new FileStream(sPath, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.Default);
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)

                        str.Append(string.Format("{0},", field));

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

        private string GetDataType(EMDataType emDataType, string sAddress)
        {
            string sDataType = string.Empty;

            switch (emDataType)
            {
                case EMDataType.Bool: sDataType = "BIT"; break;
                case EMDataType.Word: sDataType = "WORD"; break;
                default: sDataType = emDataType.ToString(); break;
            }

            if (sAddress.StartsWith("T") || sAddress.StartsWith("C"))
                sDataType = "BIT/WORD";

            return sDataType;
        }

    }
}
