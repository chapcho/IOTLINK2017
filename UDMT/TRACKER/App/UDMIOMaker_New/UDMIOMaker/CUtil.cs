using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using UDM.Common;
using UDM.Export;

namespace UDMIOMaker
{
    public static class CUtil
    {
        public static event UEventHandlerExcelExportProcess UEventExcelProcess;

        public static string ConvertMelsecAddressRange(int iIndex, bool bHexa)
        {
            string sAddressRange = string.Empty;
            try
            {
                string sIndex = iIndex.ToString();

                if (bHexa)
                    sIndex = string.Format("{0:X}", iIndex);

                if (sIndex.Length < 3)
                {
                    int iCount = 3 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
                sAddressRange = sIndex;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ConvertMelsecAddressRange Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return string.Format("{0}0", sAddressRange.ToUpper());
        }

        public static string ConvertLSAddressRange(int iIndex)
        {
            string sAddressRange = string.Empty;
            try
            {
                string sIndex = iIndex.ToString();

                if (sIndex.Length < 5)
                {
                    int iCount = 5 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
                sAddressRange = sIndex;

            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ConvertLSAddressRange Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Format("{0}0", sAddressRange.ToUpper());
        }

        public static string ConvertSiemensAddressRange(int iIndex)
        {
            string sAddressRange = string.Empty;
            try
            {
                string sIndex = iIndex.ToString();

                if (sIndex.Length < 4)
                {
                    int iCount = 4 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
                sAddressRange = sIndex;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ConvertSiemensAddressRange Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Format("{0}.0", sAddressRange.ToUpper());
        }

        public static string ConvertABAddressRange(int iIndex)
        {
            string sAddressRange = string.Empty;
            try
            {
                string sIndex = iIndex.ToString();

                if (sIndex.Length < 4)
                {
                    int iCount = 4 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
                sAddressRange = sIndex;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ConvertABAddressRange Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Format("{0}", sAddressRange.ToUpper());
        }

        public static string GetABNextNormalAddress(string sHeader, string sValue, int iSize)
        {
            string sAddress = string.Empty;
            try
            {
                int iValue = Convert.ToInt32(sValue);

                if (iSize == -1)
                    sAddress = string.Format("{0}{1}", sHeader, iValue);
                else
                    sAddress = string.Format("{0}{1}.{2}", sHeader, iValue, iSize);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetABNextNormalAddress Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sAddress.ToUpper();
        }

        public static string GetABNextAliasAddress(string sHeader, string sValue, int iSize)
        {
            string sAddress = string.Empty;
            try
            {
                string sIndex1 = sValue.Substring(0, sValue.Length - 3);
                string sIndex2 = sValue.Remove(0, sValue.Length - 3);

                int iValue1 = Convert.ToInt32(sIndex1);
                int iValue2 = Convert.ToInt32(sIndex2);

                if (iValue1 == 0)
                    sIndex1 = "";
                else
                    sIndex1 = iValue1.ToString();

                if (iValue2 == 0)
                    sIndex2 = "";
                else
                    sIndex2 = iValue2.ToString();

                if (iSize == -1)
                    sAddress = string.Format("{0}{1}[{2}]", sHeader, sIndex1, sIndex2);
                else
                    sAddress = string.Format("{0}{1}[{2}].{3}", sHeader, sIndex1, sIndex2, iSize);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetABNextAliasAddress Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sAddress.ToUpper();
        }

        public static string GetMelsecNextAddress(string sHeader, string sValue, int iSize)
        {
            string sAddress = string.Empty;
            try
            {
                bool bWord = false;
                string sWordValue = sValue.Substring(0, sValue.Length - 1);

                if (sWordValue == string.Empty)
                    return string.Empty;

                if (sHeader.Equals("D") || sHeader.Equals("W"))
                    bWord = true;

                if (bWord)
                {
                    if (sWordValue.Length < 4)
                    {
                        int iCount = 4 - sWordValue.Length;

                        for (int i = 0; i < iCount; i++)
                            sWordValue = sWordValue.Insert(0, "0");
                    }

                    sAddress = string.Format("{0}{1}.{2:X}", sHeader, sWordValue, iSize);
                }
                else
                    sAddress = string.Format("{0}{1}{2:X}", sHeader, sWordValue, iSize);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetMelsecNextAddress Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sAddress.ToUpper();
        }

        public static string GetLSNextAddress(string sHeader, string sValue, int iSize)
        {
            string sAddress = string.Empty;
            try
            {
                bool bWord = false;
                string sWordValue = sValue.Substring(0, sValue.Length - 1);

                if (sWordValue == string.Empty)
                    return string.Empty;

                if (sHeader.Equals("D"))
                    bWord = true;

                if (bWord)
                {
                    if (sWordValue.Length < 5)
                    {
                        int iCount = 6 - sWordValue.Length;

                        for (int i = 0; i < iCount; i++)
                            sWordValue = sWordValue.Insert(0, "0");
                    }

                    sAddress = string.Format("{0}{1}.{2:X}", sHeader, sWordValue, iSize);
                }
                else
                    sAddress = string.Format("{0}{1}{2:X}", sHeader, sWordValue, iSize);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetLSNextAddress Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sAddress.ToUpper();
        }

        public static string GetSiemensNextAddress(string sHeader, string sValue, int iSize)
        {
            string sAddress = string.Empty;
            try
            {
                bool bWord = false;
                string sWordValue = sValue.Split('.')[0];

                if (sHeader.Equals("T") || sHeader.Equals("C") || sHeader.Equals("DB"))
                    bWord = true;

                if (bWord)
                {
                    int iValue = Convert.ToInt32(sWordValue);
                    sWordValue = iValue.ToString();

                    if (sWordValue.Length < 3)
                    {
                        int iDigit = 3 - sWordValue.Length;
                        for (int i = 0; i < iDigit; i++)
                            sWordValue = sWordValue.Insert(0, "0");
                    }
                }

                if (bWord)
                    sAddress = string.Format("{0}{1}{2}", sHeader, sWordValue, iSize);
                else
                    sAddress = string.Format("{0}{1}.{2}", sHeader, sWordValue, iSize);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetSiemensNextAddress Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sAddress.ToUpper();
        }

        public static string CheckMelsecAddressExist(string sAddress, string sChannel, string sAddressHeader, bool bHexa)
        {
            string sTempKey = string.Empty;
            try
            {
                string sKey = string.Empty;
                string sIndex = string.Empty;
                string sTemp = string.Empty;
                int iValue = -1;

                sIndex = sAddress.Remove(0, 1); //Header 제외 대문자 (자릿수 0포함)
                sKey = string.Format("[{0}]{1}{2}[1]", sChannel, sAddressHeader, sIndex);

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    sTempKey = sKey;
                    return sTempKey;
                }

                if (sAddress.Contains("."))
                {
                    sTemp = sIndex.Split('.')[1];
                    sIndex = sIndex.Split('.')[0];

                    if (bHexa)
                    {
                        iValue = Convert.ToInt32(sIndex, 16);
                        sKey = string.Format("[{0}]{1}{2}.{3}[1]", sChannel, sAddressHeader,
                            iValue.ToString("X").ToUpper(), sTemp);
                    }
                    else
                    {
                        iValue = Convert.ToInt32(sIndex);
                        sKey = string.Format("[{0}]{1}{2}.{3}[1]", sChannel, sAddressHeader, iValue.ToString().ToUpper(),
                            sTemp);
                    }
                }
                else
                {
                    if (bHexa)
                    {
                        iValue = Convert.ToInt32(sIndex, 16);
                        sKey = string.Format("[{0}]{1}{2}[1]", sChannel, sAddressHeader, iValue.ToString("X").ToUpper());
                    }
                    else
                    {
                        iValue = Convert.ToInt32(sIndex);
                        sKey = string.Format("[{0}]{1}{2}[1]", sChannel, sAddressHeader, iValue.ToString().ToUpper());
                    }
                }

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    sTempKey = sKey;
                    return sTempKey;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Chekc Melsec Address Exist Up", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sTempKey;
        }

        public static string CheckSiemensAddressExist(string sAddress, string sChannel)
        {
            string sKey = string.Empty;
            try
            {
                sKey = string.Format("[{0}]{1}[1]", sChannel, sAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                    return sKey;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckSiemensAddressExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Empty;
        }

        public static string CheckLSAddressExist(string sAddress, string sChannel)
        {
            string sKey = string.Empty;
            try
            {
                sKey = string.Format("[{0}]{1}[1]", sChannel, sAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                    return sKey;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckLSAddressExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Empty;
        }

        public static string CheckABSymbolExist(string sNormalAddress, string sAliasAddress, string sChannel)
        {
            string sKey = string.Empty;
            try
            {
                string sTempKey = string.Empty;

                sTempKey = string.Format("[{0}]{1}[1]", sChannel, sNormalAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sTempKey))
                    return sTempKey;

                sTempKey = string.Format("[{0}]{1}[1]", sChannel, sAliasAddress);

                if (CProjectManager.PLCTagS.ContainsKey(sTempKey))
                    return sTempKey;

                //CPlcLogicData cData = CProjectManager.LogicDataS[sChannel];
                //foreach (var who in cData.TagS)
                //{
                //    if (sNormalAddress == who.Value.Address || sAliasAddress == who.Value.Address)
                //    {
                //        sKey = who.Key;
                //        break;
                //    }
                //}

            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckABSYmbolExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sKey;
        }

        public static string CheckMelsecWordAddressExist(string sChannel, string sAddressHeader, string sAddressRange, bool bHexa)
        {
            string sWordAddress = string.Empty;
            try
            {
                string sAddressIndex = sAddressRange.Substring(0, sAddressRange.Length - 1);

                if (sAddressIndex.Length < 4)
                {
                    int iCount = 4 - sAddressIndex.Length;
                    for (int i = 0; i < iCount; i++)
                        sAddressIndex = sAddressIndex.Insert(0, "0");
                }

                string sAddress = string.Format("{0}{1}", sAddressHeader, sAddressIndex);
                EMDataType emDataType = EMDataType.None;

                string sTemp = CheckMelsecAddressExist(sAddress, sChannel, sAddressHeader, bHexa);

                if (sTemp != string.Empty)
                {
                    emDataType = CProjectManager.PLCTagS[sTemp].DataType;

                    if (emDataType != EMDataType.Bool)
                        sWordAddress = sAddress;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckMelsecWordAddressExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sWordAddress;
        }

        public static string CheckLSWordAddressExist(string sChannel, string sAddressHeader, string sAddressRange)
        {
            string sWordAddress = string.Empty;
            try
            {
                string sAddressIndex = sAddressRange.Substring(0, sAddressRange.Length - 1);

                if (sAddressIndex.Length < 5)
                {
                    int iCount = 5 - sAddressIndex.Length;
                    for (int i = 0; i < iCount; i++)
                        sAddressIndex = sAddressIndex.Insert(0, "0");
                }

                string sAddress = string.Format("{0}{1}", sAddressHeader, sAddressIndex);
                EMDataType emDataType = EMDataType.None;

                string sTemp = CheckLSAddressExist(sAddress, sChannel);

                if (sTemp != string.Empty)
                {
                    emDataType = CProjectManager.PLCTagS[sTemp].DataType;

                    if (emDataType != EMDataType.Bool)
                        sWordAddress = sTemp;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckLSWordAddressExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return sWordAddress;
        }

        public static string CheckABWordAddressExist(string sChannel, string sAddressHeader, string sAddressRange)
        {
            string sWordKey = string.Empty;
            try
            {
                string sNormalAddress = GetABNextNormalAddress(sAddressHeader, sAddressRange, -1);
                string sAliasAddress = GetABNextAliasAddress(sAddressHeader, sAddressRange, -1);

                string sTempKey = CheckABSymbolExist(sNormalAddress, sAliasAddress, sChannel);
                EMDataType emDataType = EMDataType.None;

                if (sTempKey != string.Empty)
                {
                    emDataType = CProjectManager.PLCTagS[sTempKey].DataType;

                    if (emDataType != EMDataType.Bool)
                        sWordKey = sTempKey;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("CheckABWordAddressExist Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return sWordKey;
        }


        public static CTagItem GetMelsecTagItem(string sAddress, string sKey)
        {
            CTagItem cItem = new CTagItem();
            try
            {
                cItem.Address = sAddress;
                cItem.Key = sKey;

                if (CProjectManager.PLCTagS[sKey].PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer))
                    cItem.Description = CProjectManager.PLCTagS[sKey].Description;
                else
                    cItem.Description = CProjectManager.PLCTagS[sKey].Name;

                cItem.DataType = CProjectManager.PLCTagS[sKey].DataType;
                cItem.IsInsertTag = CProjectManager.PLCTagS[sKey].IsHMIMapping;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetMelsecTagItem Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return cItem;
        }

        public static CTagItem GetABTagItem(string sKey)
        {
            CTagItem cItem = new CTagItem();
            try
            {
                CTag cTag = CProjectManager.PLCTagS[sKey];

                cItem.Address = cTag.Address;
                cItem.Key = sKey;
                cItem.Name = cTag.Name;
                cItem.Note = cTag.Note;
                cItem.Description = cTag.Description;
                cItem.DataType = cTag.DataType;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetABTagItem Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return cItem;
        }

        public static CTagItem GetLSTagItem(string sKey)
        {  
            CTagItem cItem = new CTagItem();
            try
            {
                CTag cTag = CProjectManager.PLCTagS[sKey];

                cItem.Address = cTag.Address;
                cItem.Key = sKey;
                cItem.Name = cTag.Name;
                cItem.Description = cTag.Description;
                cItem.DataType = cTag.DataType;
                cItem.IsInsertTag = CProjectManager.PLCTagS[sKey].IsHMIMapping;
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetLSTagItem Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return cItem;
        }

        public static CTagItem GetSiemensTagItem(string sAddress, string sKey)
        {
            CTagItem cItem = new CTagItem();
            try
            {
                cItem.Address = sAddress;
                cItem.Key = sKey;
                cItem.Description = CProjectManager.PLCTagS[sKey].Name;
                cItem.DataType = CProjectManager.PLCTagS[sKey].DataType;
                cItem.IsInsertTag = CProjectManager.PLCTagS[sKey].IsHMIMapping;

            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("GetLSTagItem Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return cItem;
        }



        public static bool ExportDummyList(string sInputPath, string sOutputPath, string sCoverName, int iRowCount, DataSet DS)
        {
            bool bOK = false;
            try
            {
                int iTotalCount = DS.Tables.Count;
                int iCurCount = 0;

                Application excelApp = new Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(sInputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                CreateCoverSheet(excelWorkbook, sCoverName);

                foreach (System.Data.DataTable DT in DS.Tables)
                {
                    if (DT.TableName.Length > 31)
                        DT.TableName = DT.TableName.Substring(0, 31);

                    if (DT.TableName.Contains("MAP"))
                        CreateDummyMapSheet(excelWorkbook, DT, iRowCount);
                    else
                        CreateDummyBitSheet(excelWorkbook, DT);

                    if (UEventExcelProcess != null)
                        UEventExcelProcess("Dummy List", ((++iCurCount * 100) / iTotalCount));
                }

                foreach (Worksheet ws in excelWorkbook.Sheets)
                {
                    if (ws.Name.ToUpper().Contains("TEMPLATE"))
                        ws.Visible = XlSheetVisibility.xlSheetVeryHidden;
                }

                foreach (System.Data.DataTable DT in DS.Tables)
                {
                    if (!DT.TableName.Contains("MAP"))
                        SetDummyBitHyperLinks(DT, excelWorkbook);
                }

                bOK = true;

                // Save and Close the Workbook
                excelWorkbook.SaveAs(sOutputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

                // Release the Application object   
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                excelApp = null;

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();


            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private static void CreateDummyMapSheet(Workbook excelWorkbook, System.Data.DataTable DT, int iRowCount)
        {
            try
            {
                Worksheet excelSheet = null;
                excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count - 1];
                excelSheet.Copy(Type.Missing, excelSheet);
                excelSheet.Name = DT.TableName;

                SetDummyMapRawData(DT, excelSheet, iRowCount);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Create Dumy Map Sheet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private static void CreateDummyBitSheet(Workbook excelWorkbook, System.Data.DataTable DT)
        {
            try
            {
                Worksheet excelSheet = null;
                excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];
                excelSheet.Copy(Type.Missing, excelSheet);
                excelSheet.Name = DT.TableName;

                SetDummyBitRawData(DT, excelSheet);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Create Dummy Bit Sheet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private static void SetDummyBitRawData(System.Data.DataTable DT, Worksheet excelSheet)
        {
            int iStartRow = 6;
            DataRow drRow = null;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (i % 16 == 0 && i != 0)
                {
                    Range sourceRange = excelSheet.get_Range("B6", "N21");
                    sourceRange.Copy();

                    Range destinationRange = excelSheet.get_Range("B" + (i + 6).ToString(), "B" + (i + 6).ToString());
                    destinationRange.PasteSpecial(XlPasteType.xlPasteAll,
                        XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                }
            }

            excelSheet.Cells[2, 3] = DT.TableName;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                drRow = DT.Rows[i];

                //X Area
                excelSheet.Cells[iStartRow, 3] = drRow[0].ToString();
                excelSheet.Cells[iStartRow, 4] = drRow[1].ToString();
                excelSheet.Cells[iStartRow, 5] = drRow[2].ToString();
                excelSheet.Cells[iStartRow, 6] = drRow[3].ToString();
                excelSheet.Cells[iStartRow, 7] = drRow[4].ToString();

                //Y Area
                excelSheet.Cells[iStartRow, 10] = drRow[5].ToString();
                excelSheet.Cells[iStartRow, 11] = drRow[6].ToString();
                excelSheet.Cells[iStartRow, 12] = drRow[7].ToString();
                excelSheet.Cells[iStartRow, 13] = drRow[8].ToString();
                excelSheet.Cells[iStartRow, 14] = drRow[9].ToString();
                iStartRow++;
            }
        }

        private static void SetDummyMapStyle(Worksheet excelSheet, int iRowCount)
        {
            int iStartRow = 4;
            string sExcelRange = string.Empty;
            string sExcelLineRange = string.Empty;
            Range excelRange = null;
            Range excelLineRange = null;
            DataRow drRow = null;

            //Cell Merge 및 테두리
            while ((10 * iRowCount) > iStartRow)
            {
                sExcelLineRange = string.Format("B{0}:E{1}", iStartRow, iStartRow + iRowCount - 1);
                excelLineRange = excelSheet.get_Range(sExcelLineRange, sExcelLineRange);
                excelLineRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                sExcelRange = string.Format("B{0}:B{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                sExcelRange = string.Format("C{0}:C{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                sExcelLineRange = string.Format("G{0}:J{1}", iStartRow, iStartRow + iRowCount - 1);
                excelLineRange = excelSheet.get_Range(sExcelLineRange, sExcelLineRange);
                excelLineRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                sExcelRange = string.Format("G{0}:G{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                sExcelRange = string.Format("H{0}:H{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                sExcelLineRange = string.Format("L{0}:O{1}", iStartRow, iStartRow + iRowCount - 1);
                excelLineRange = excelSheet.get_Range(sExcelLineRange, sExcelLineRange);
                excelLineRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                sExcelRange = string.Format("L{0}:L{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                sExcelRange = string.Format("M{0}:M{1}", iStartRow, iStartRow + iRowCount - 1);
                excelRange = excelSheet.get_Range(sExcelRange, sExcelRange);
                excelRange.Merge();

                iStartRow += iRowCount;
            }
        }

        private static void SetDummyMapRawData(System.Data.DataTable DT, Worksheet excelSheet, int iRowCount)
        {
            int iStartRow = 4;
            DataRow drRow = null;

            SetDummyMapStyle(excelSheet, iRowCount);

            foreach (var who in DT.Rows)
            {
                drRow = (DataRow)who;

                //First Block
                excelSheet.Cells[iStartRow, 2] = drRow[0].ToString();
                excelSheet.Cells[iStartRow, 3] = drRow[1].ToString();
                excelSheet.Cells[iStartRow, 4] = drRow[2].ToString();
                excelSheet.Cells[iStartRow, 5] = drRow[3].ToString();

                //Second Block
                excelSheet.Cells[iStartRow, 7] = drRow[4].ToString();
                excelSheet.Cells[iStartRow, 8] = drRow[5].ToString();
                excelSheet.Cells[iStartRow, 9] = drRow[6].ToString();
                excelSheet.Cells[iStartRow, 10] = drRow[7].ToString();

                //Third Block
                excelSheet.Cells[iStartRow, 12] = drRow[8].ToString();
                excelSheet.Cells[iStartRow, 13] = drRow[9].ToString();
                excelSheet.Cells[iStartRow, 14] = drRow[10].ToString();
                excelSheet.Cells[iStartRow, 15] = drRow[11].ToString();

                iStartRow++;
            }

            Range range = excelSheet.get_Range("B3", "D" + iStartRow);
            range.Columns.AutoFit();

            range = excelSheet.get_Range("G3", "I" + iStartRow);
            range.Columns.AutoFit();

            range = excelSheet.get_Range("L3", "N" + iStartRow);
            range.Columns.AutoFit();
        }

        public static bool ExportIOList(string sInputPath, string sOutputPath, string sCoverName, DataSet DS, bool b16bit)
        {
            bool bOK = false;
            try
            {
                int iTotalCount = DS.Tables.Count;
                int iCurCount = 0;

                Application excelApp = new Application();
                Workbook excelWorkbook = excelApp.Workbooks.Open(sInputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                CreateCoverSheet(excelWorkbook, sCoverName);

                foreach (System.Data.DataTable DT in DS.Tables)
                {
                    if (DT.TableName.Length > 31)
                        DT.TableName = DT.TableName.Substring(0, 31);

                    if(DT.TableName.Contains("MAP"))
                        CreateMapSheet(excelWorkbook, DT, b16bit);
                    else
                        CreateIOSheet(excelWorkbook, DT, b16bit);

                    if (UEventExcelProcess != null)
                        UEventExcelProcess("IO List", ((++iCurCount*100)/iTotalCount));
                }

                foreach (Worksheet ws in excelWorkbook.Sheets)
                {
                    if (ws.Name.ToUpper().Contains("TEMPLATE"))
                        ws.Visible = XlSheetVisibility.xlSheetVeryHidden;
                }

                foreach (System.Data.DataTable DT in DS.Tables)
                {
                    if(!DT.TableName.Contains("MAP"))
                        SetHyperLinks(DT, excelWorkbook);
                }

                bOK = true;

                // Save and Close the Workbook
                excelWorkbook.SaveAs(sOutputPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelWorkbook.Close(true, Type.Missing, Type.Missing);
                excelWorkbook = null;

                // Release the Application object   
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                excelApp = null;

                // Collect the unreferenced objects
                GC.Collect();
                GC.WaitForPendingFinalizers();


            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        public static string GetVerticalAddress(string sAddress)
        {
            string sNewAddress = string.Empty;

            foreach (var who in sAddress)
                sNewAddress += string.Format("{0}\n", who);

            sNewAddress = sNewAddress.Substring(0, sNewAddress.Length - 2);

            return sNewAddress;
        }

        private static void CreateMapSheet(Workbook excelWorkbook, System.Data.DataTable DT, bool b16Bit)
        {
            try
            {
                Worksheet excelSheet = null;
                excelSheet = (Worksheet) excelWorkbook.Sheets[excelWorkbook.Sheets.Count - 2];
                excelSheet.Copy(Type.Missing, excelSheet);
                excelSheet.Name = DT.TableName;

                SetMapRawData(DT, excelSheet, b16Bit);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Create Map Sheet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private static void SetMapRawData(System.Data.DataTable DT, Worksheet excelSheet, bool b16Bit)
        {
            int iStartRow = 4;
            int iRowCount = 1;
            DataRow drRow = null;

            int iIndex = b16Bit == true ? 16 : 8;
            int iStartIndex = 4;
            string sExcelLineRange = string.Empty;
            Range excelLineRange = null;
            Borders excelBorder = null;

            foreach (var who in DT.Rows)
            {
                drRow = (DataRow) who;

                if (iRowCount%iIndex == 0)
                {
                    int iEndIndex = 4 + (iIndex * (iRowCount / iIndex));

                    sExcelLineRange = string.Format("B{0}:H{1}", iStartIndex, iEndIndex - 1);
                    excelLineRange = excelSheet.get_Range(sExcelLineRange, sExcelLineRange);

                    excelBorder = excelLineRange.Borders;
                    excelBorder[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    sExcelLineRange = string.Format("J{0}:P{1}", iStartIndex, iEndIndex - 1);
                    excelLineRange = excelSheet.get_Range(sExcelLineRange, sExcelLineRange);

                    excelBorder = excelLineRange.Borders;
                    excelBorder[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    excelBorder[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;

                    iStartIndex = iEndIndex;
                }

                //Left
                excelSheet.Cells[iStartRow, 3] = drRow[0].ToString();
                excelSheet.Cells[iStartRow, 4] = drRow[1].ToString();
                excelSheet.Cells[iStartRow, 5] = drRow[2].ToString();
                excelSheet.Cells[iStartRow, 6] = drRow[3].ToString();
                excelSheet.Cells[iStartRow, 7] = drRow[4].ToString();
                excelSheet.Cells[iStartRow, 8] = drRow[5].ToString();

                //Right
                excelSheet.Cells[iStartRow, 11] = drRow[6].ToString();
                excelSheet.Cells[iStartRow, 12] = drRow[7].ToString();
                excelSheet.Cells[iStartRow, 13] = drRow[8].ToString();
                excelSheet.Cells[iStartRow, 14] = drRow[9].ToString();
                excelSheet.Cells[iStartRow, 15] = drRow[10].ToString();
                excelSheet.Cells[iStartRow, 16] = drRow[11].ToString();

                iRowCount++;
                iStartRow++;
            }

            Range range = excelSheet.get_Range("D3", "G51");
            range.Columns.AutoFit();

            range = excelSheet.get_Range("L3", "O51");
            range.Columns.AutoFit();
        }

        private static void CreateIOSheet(Workbook excelWorkbook, System.Data.DataTable DT, bool b16Bit)
        {
            try
            {
                Worksheet excelSheet = null;
                if (b16Bit)
                    excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count - 1];
                else
                    excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];
                excelSheet.Copy(Type.Missing, excelSheet);
                excelSheet.Name = DT.TableName;

                SetIORawData(DT, excelSheet, b16Bit);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Export IO Create IO Sheet Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private static void SetIORawData(System.Data.DataTable DT, Worksheet excelSheet, bool b16Bit)
        {
            int iStartRow = 7;
            DataRow drRow = null;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (b16Bit)
                {
                    if (i%16 == 0 && i != 0)
                    {
                        Range sourceRange = excelSheet.get_Range("B7", "L22");
                        sourceRange.Copy();

                        Range destinationRange = excelSheet.get_Range("B" + (i + 7).ToString(), "B" + (i + 7).ToString());
                        destinationRange.PasteSpecial(XlPasteType.xlPasteAll,
                            XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    }
                }
                else
                {
                    if (i % 8 == 0 && i != 0)
                    {
                        Range sourceRange = excelSheet.get_Range("B7", "L14");
                        sourceRange.Copy();

                        Range destinationRange = excelSheet.get_Range("B" + (i + 7).ToString(), "B" + (i + 7).ToString());
                        destinationRange.PasteSpecial(XlPasteType.xlPasteAll,
                            XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    }
                }
            }


            for (int i = 0; i < DT.Rows.Count; i++)
            {
                drRow = DT.Rows[i];

                if (i == 0)
                {
                    excelSheet.Cells[3, 3] = drRow[0].ToString();
                    excelSheet.Cells[3, 6] = drRow[1].ToString();
                }
                else
                {
                    //X Area
                    excelSheet.Cells[iStartRow, 3] = drRow[0].ToString();
                    excelSheet.Cells[iStartRow, 4] = drRow[1].ToString();
                    excelSheet.Cells[iStartRow, 5] = drRow[2].ToString();
                    excelSheet.Cells[iStartRow, 6] = drRow[3].ToString();

                    //Y Area
                    excelSheet.Cells[iStartRow, 9] = drRow[4].ToString();
                    excelSheet.Cells[iStartRow, 10] = drRow[5].ToString();
                    excelSheet.Cells[iStartRow, 11] = drRow[6].ToString();
                    excelSheet.Cells[iStartRow, 12] = drRow[7].ToString();
                    iStartRow++;
                }
            }

            //Range range = excelSheet.get_Range("D4", "P51");
            //range.Columns.AutoFit();
        }

        private static void CreateCoverSheet(Workbook excelWorkbook, string strCoverName)
        {
            // Create a new Sheet
            Worksheet excelSheet = null;

            excelSheet = (Worksheet)excelWorkbook.Sheets[1];

            excelSheet.Cells[18, 24] = strCoverName;
            excelSheet.Cells[24, 24] = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private static void SetDummyBitHyperLinks(System.Data.DataTable DT, Workbook excelWorkbook)
        {
            Worksheet excelSheet = (Worksheet)excelWorkbook.Sheets[DT.TableName];
            string sFirstAddressRange = DT.TableName.Split('-')[0];
            string sLastAddressRange = DT.TableName.Split('-')[1];
            string sExcelRange = "A1:A1";
            string sHyperLinkTargetSheetName = string.Empty;

            List<string> lstSheet = new List<string>();
            foreach (Worksheet sheet in excelWorkbook.Sheets)
                lstSheet.Add(sheet.Name);

            sHyperLinkTargetSheetName = GetDummyBithyperlinkTargetSheet(lstSheet, excelWorkbook, DT, sFirstAddressRange, sLastAddressRange);

            if (sHyperLinkTargetSheetName != string.Empty)
            {
                sHyperLinkTargetSheetName = "'" + sHyperLinkTargetSheetName + "'!A1";

                excelSheet.Hyperlinks.Add(excelSheet.get_Range(sExcelRange, sExcelRange), string.Empty,
                    sHyperLinkTargetSheetName, Type.Missing, Type.Missing);
            }
        }

        private static string GetDummyBithyperlinkTargetSheet(List<string> lstSheet, Workbook excelWorkbook, System.Data.DataTable dt, string sFirstAddressRange, string sLastAddressRange)
        {
            string hyperlinkTargetSheet = string.Empty;
            try
            {
                string sExcelRange = string.Empty;
                string sAddressRange = string.Empty;
                string sColumnCaption = String.Empty;
                List<string> Mapsheets = new List<string>();
                foreach (string strMap in lstSheet)
                {
                    if (strMap.Contains("MAP") && !strMap.Contains("TEMPLATE"))
                        Mapsheets.Add(strMap);
                }

                sAddressRange = string.Format("{0}\n-\n{1}", sFirstAddressRange, sLastAddressRange);

                DataSet DS = dt.DataSet;
                Worksheet excelSheet = null;

                foreach (string strMap in Mapsheets)
                {
                    System.Data.DataTable DT = DS.Tables[strMap];
                    int nRowCount = DT.Rows.Count;
                    int nColCount = DT.Columns.Count;

                    for (int nCol = 0; nCol < nColCount; nCol++)
                    {
                        for (int nRow = 0; nRow < nRowCount; nRow++)
                        {
                            if (DT.Rows[nRow][nCol].ToString() == sAddressRange)
                            {
                                excelSheet = (Worksheet)excelWorkbook.Sheets[strMap];

                                if (nCol == 0)
                                    sColumnCaption = "B";
                                else if (nCol == 4)
                                    sColumnCaption = "G";
                                else if (nCol == 8)
                                    sColumnCaption = "L";

                                sExcelRange = string.Format("{0}{1}:{2}{3}", sColumnCaption, nRow + 4, sColumnCaption, nRow + 4);
                                hyperlinkTargetSheet = "'" + dt.TableName + "'!A1";

                                excelSheet.Hyperlinks.Add(excelSheet.get_Range(sExcelRange, sExcelRange), string.Empty,
                                    hyperlinkTargetSheet, Type.Missing, Type.Missing);

                                return strMap;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util Dummy Bit HyperLinks Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Empty;
        }

        private static void SetHyperLinks(System.Data.DataTable DT, Workbook excelWorkbook)
        {
            Worksheet excelSheet = (Worksheet) excelWorkbook.Sheets[DT.TableName];
            string sAddressRange = DT.TableName.Split('-')[0];
            string sExcelRange = "A1:A1";
            string sHyperLinkTargetSheetName = string.Empty;

            List<string> lstSheet = new List<string>();
            foreach(Worksheet sheet in excelWorkbook.Sheets)
                lstSheet.Add(sheet.Name);

            sHyperLinkTargetSheetName = GethyperlinkTargetSheet(lstSheet, excelWorkbook, DT, sAddressRange);

            if (sHyperLinkTargetSheetName != string.Empty)
            {
                sHyperLinkTargetSheetName = "'" + sHyperLinkTargetSheetName + "'!A1";

                excelSheet.Hyperlinks.Add(excelSheet.get_Range(sExcelRange, sExcelRange), string.Empty,
                    sHyperLinkTargetSheetName, Type.Missing, Type.Missing);
            }
        }

        private static string GethyperlinkTargetSheet(List<string> lstSheet, Workbook excelWorkbook, System.Data.DataTable dt, string sAddressRange)
        {
            string hyperlinkTargetSheet = string.Empty;
            try
            {
                string sExcelRange = string.Empty;
                List<string> Mapsheets = new List<string>();
                foreach (string strMap in lstSheet)
                {
                    if (strMap.Contains("MAP") && !strMap.Contains("TEMPLATE"))
                        Mapsheets.Add(strMap);
                }

                sAddressRange = string.Format("'{0}", sAddressRange);

                DataSet DS = dt.DataSet;
                Worksheet excelSheet = null;

                foreach (string strMap in Mapsheets)
                {
                    System.Data.DataTable DT = DS.Tables[strMap];
                    int nRowCount = DT.Rows.Count;
                    int nColCount = DT.Columns.Count;

                    for (int nCol = 0; nCol < nColCount; nCol++)
                    {
                        for (int nRow = 0; nRow < nRowCount; nRow++)
                        {
                            if (DT.Rows[nRow][nCol].ToString() == sAddressRange)
                            {
                                excelSheet = (Worksheet) excelWorkbook.Sheets[strMap];

                                sExcelRange = string.Format("{0}{1}:{2}{3}", nCol == 2 ? "E" : "M" , nRow + 4,
                                    nCol == 2 ? "E" : "M", nRow + 4);
                                hyperlinkTargetSheet = "'" + dt.TableName + "'!A1";

                                excelSheet.Hyperlinks.Add(excelSheet.get_Range(sExcelRange, sExcelRange), string.Empty,
                                    hyperlinkTargetSheet, Type.Missing, Type.Missing);

                                return strMap;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Util HyperLinks Error",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return string.Empty;
        }

        private static string CalculateFinalColumn(int nColumn)
        {
            // Calculate the final column letter
            string finalColLetter = string.Empty;
            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int colCharsetLen = colCharset.Length;

            if (nColumn > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (nColumn - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                    (nColumn - 1) % colCharsetLen, 1);

            return finalColLetter;
        }

    }


    public class EMBLOCK_MITUBISHI
    {
        public const string TYPE_LIST = "X;Y;M;L;D;B;W;T;C";
        public const string HEXA_LIST = "X;Y;B;W";
        public const string TYPE_IO = "X;Y";
        public const string TYPE_DUMMY = "M;D;L";
        public const string TYPE_LINK = "B;W";
        public const string TYPE_TIMER_COUNT = "T;C";
    }

    public class EMBLOCK_LS
    {public const string TYPE_LIST = "P;M;L;D;K;N;T;C";
        public const string HEXA_LIST = "";
        public const string TYPE_IO = "P;K";
        public const string TYPE_DUMMY = "M;D";
        public const string TYPE_LINK = "L;N";
        public const string TYPE_TIMER_COUNT = "T;C";
    }

    public class EMBLOCK_SIEMENS
    {
        public const string TYPE_LIST = "I;Q;M;T;C";
        public const string HEXA_LIST = "";
        public const string TYPE_IO = "I;Q";
        public const string TYPE_DUMMY = "M";
        //public const string TYPE_LINK = "";
        public const string TYPE_TIMER_COUNT = "T;C";
    }

    public class EMBLOCK_AB
    {
        public const string TYPE_LIST = "I;O;B;H;N;S;C;T";
        public const string HEXA_LIST = "";
        public const string TYPE_IO = "I;O";
        public const string TYPE_DUMMY = "B;H;N;S";
        public const string TYPE_LINK = "";
        public const string TYPE_TIMER_COUNT = "T;C";
    }


}
