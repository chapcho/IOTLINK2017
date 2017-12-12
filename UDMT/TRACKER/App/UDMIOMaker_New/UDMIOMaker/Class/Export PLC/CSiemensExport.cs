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
    public class CSiemensExport
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private CPlcLogicData m_cData = null;
        private bool m_bExtend = false;
        private string m_sSavePath = string.Empty;

        private const int SIEMENS_GENERAL_NORMAL_RANGE = 8191;
        private const int SIEMENS_GENERAL_EXTEND_RANGE = 16383;
        private const int SIEMENS_WORD_NORMAL_RANGE = 819;
        private const int SIEMENS_WORD_EXTEND_RANGE = 1638;

        public CSiemensExport(EMPLCMaker emPLCMaker, CPlcLogicData cData)
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

        public bool ExportSiemensPLC()
        {
            bool bOK = false;

            bOK = ExportSDFFormat();

            return bOK;
        }

        public bool ExportSiemensIOList()
        {
            bool bOK = false;

            if (m_cData == null)
                return false;

            DataSet DSIOList = GetIOListDataSet();

            if (DSIOList.Tables.Count == 0)
                return false;

            bOK = CUtil.ExportIOList(CProjectManager.IOListPath, m_sSavePath, m_cData.Name, DSIOList, false);

            return bOK;
        }

        private int GetUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("T") || sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = SIEMENS_WORD_EXTEND_RANGE;
                else
                    iCount = SIEMENS_WORD_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = SIEMENS_GENERAL_EXTEND_RANGE;
                else
                    iCount = SIEMENS_GENERAL_NORMAL_RANGE;
            }

            return iCount;
        }


        public bool ExportSiemensDummyList(string sType)
        {
            bool bOK = false;

            if (m_cData == null)
                return false;

            DataSet DSDummyList = GetDummyListDataSet(sType);

            if (DSDummyList.Tables.Count == 0)
                return false;

            int iRowCount = -1;

            if (sType.Equals("M"))
                iRowCount = 8;
            else
                iRowCount = 10;

            bOK = CUtil.ExportDummyList(CProjectManager.DummyListPath, m_sSavePath, m_cData.Name, iRowCount, DSDummyList);

            return bOK;
        }

        private DataSet GetDummyListDataSet(string sType)
        {
            DataSet DS = new DataSet();
            
            SetDummyMapDataSet(DS, sType);

            return DS;
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
                CProjectManager.UpdateSystemMessage("Siemens Export DUMMY MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetDummyListMap(int iStartRow, CBlockUnit cUnit, DataTable DT, int iColIndex)
        {
            DataRow drRow = null;

            for (int i = 0; i < cUnit.MaximumItemLimit; i++)
            {
                if (iColIndex == 1)
                    drRow = DT.NewRow();
                else if (iColIndex == 2)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 10) * cUnit.MaximumItemLimit) + i];
                else if (iColIndex == 3)
                    drRow = DT.Rows[(((cUnit.RangeIndex % 30) - 20) * cUnit.MaximumItemLimit) + i];

                if(cUnit.AddressHeader.Equals("M"))
                    drRow[iStartRow] = string.Format("{0}\n-\n{1}", cUnit.AddressRange, CUtil.ConvertSiemensAddressRange(cUnit.RangeIndex + 1));
                else
                    drRow[iStartRow] = string.Format("{0}\n-\n{1}", cUnit.AddressRange.Replace(".", string.Empty), CUtil.ConvertSiemensAddressRange(cUnit.RangeIndex + 1).Replace(".", string.Empty));

                drRow[iStartRow + 1] = string.Empty;
                drRow[iStartRow + 2] = CUtil.GetSiemensNextAddress(cUnit.AddressHeader, cUnit.AddressRange, i);

                if (cUnit.TagItemS.Count > i)
                    drRow[iStartRow + 3] = cUnit.TagItemS[i].Description;

                if (iColIndex == 1)
                    DT.Rows.Add(drRow);
            }
        }

        private bool ExportSDFFormat()
        {
            bool bOK = false;

            try
            {
                if (m_cData == null)
                    return false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_COMMENT_Siemens";
                dlgSave.Filter = "*.sdf|*.sdf";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return false;

                bOK = WriteToSDF(dlgSave.FileName);

                dlgSave.Dispose();
                dlgSave = null;
                
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export SDF Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private bool WriteToSDF(string sPath)
        {
            bool bOK = false;

            try
            {
                FileStream fsOutput = new FileStream(sPath, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.Default); //Encoding Default로 해야 Import 가능!
                string sLine = string.Empty;

                foreach (var who in m_cData.TagS)
                {
                    if (who.Value.DataType != EMDataType.Block)
                        sLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", who.Value.Name, who.Value.Address,
                            who.Value.DataType.ToString().ToUpper(), who.Value.Description);
                    else
                    {
                        if(who.Value.UDTType != string.Empty)
                            sLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", who.Value.Name, who.Value.Address,
                            who.Value.UDTType.ToUpper(), who.Value.Description);
                        else
                            sLine = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", who.Value.Name, who.Value.Address,
                            who.Value.Address.ToUpper(), who.Value.Description);
                    }

                    srOutput.WriteLine(sLine);
                }

                srOutput.Close();
                fsOutput.Close();

                bOK = true;

                srOutput = null;
                fsOutput = null;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Export sdf Error {0}", ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
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
                    DT = GetIODataTable(iStartRangeIndex, 8);

                    if (DT != null)
                        DS.Tables.Add(DT);

                    iStartRangeIndex += 8;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Siemens Export IODataSet Error",
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
                if (!m_cData.AddressBlockS["I"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;
                if (!m_cData.AddressBlockS["Q"].UnitS.ContainsKey(iStartRangeIndex + i))
                    continue;

                cXUnit = m_cData.AddressBlockS["I"].UnitS[iStartRangeIndex + i];
                cYUnit = m_cData.AddressBlockS["Q"].UnitS[iStartRangeIndex + i];

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

                        drRow[0] = CUtil.GetVerticalAddress(string.Format("I{0}", cXUnitS[i].AddressRange));
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

                        drRow[4] = CUtil.GetVerticalAddress(string.Format("Q{0}", cYUnitS[i].AddressRange));
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
                        DT.TableName = "IQ_MAP_" + (iMapPageIndex++).ToString();

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
                        drRow[1] = "IQ";
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
                        drRow[7] = "IQ";
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
                CProjectManager.UpdateSystemMessage("Siemens Export MapDataSet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private string GetIOLastRange(string sFirstRange)
        {
            string sLastRange = string.Empty;

            sLastRange = string.Format("{0}7", sFirstRange.Substring(0, sFirstRange.Length - 1));

            return sLastRange;
        }

        private string GetIOMapLastRange(string sFirstRange)
        {
            string sLastRange = string.Empty;
            int iFirstValue = Convert.ToInt32(sFirstRange.Split('.')[0]);
            int iLastValue = iFirstValue + 7;

            sLastRange = iLastValue.ToString();

            int iLength = sLastRange.Length;

            if (iLength < 4)
            {
                for (int i = 0; i < 4 - iLength; i++)
                    sLastRange = sLastRange.Insert(0, "0");
            }

            sLastRange = string.Format("{0}.7", sLastRange);

            return sLastRange;
        }



    }
}
