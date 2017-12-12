using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.Export;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.Linq.Expressions;
using System.Diagnostics;


namespace NewIOMaker
{
    public delegate void UEventHandlerExcelExportProcess(object sender, int nProcess);

    public class IOListExport
    {
        public event UEventHandlerExcelExportProcess UEventExcelExportProcess;

        public List<ABTag> LstIoTag;
        public List<ABTag> LstBaseTag;
        public List<ABTag> LstSTag;
        public List<ABTag> LstEtcTag;
        public List<ABTag> LstTandCTag;
        public List<ABTag> LstDummyTag;

        public SortedDictionary<string, List<ABTag>> DicDummyTagS;

        #region Initialize/Dispose

        public IOListExport(CTagS TagS)
        {
            GetABTags(TagS);
        }

        #endregion

        #region TAG Converting

        private void GetABTags(CTagS TagS)
        {
            LstBaseTag = new List<ABTag>();
            LstIoTag = new List<ABTag>();
            LstSTag = new List<ABTag>();
            LstTandCTag = new List<ABTag>();
            LstDummyTag = new List<ABTag>();
            LstEtcTag = new List<ABTag>();
            DicDummyTagS = new SortedDictionary<string, List<ABTag>>();

            foreach (var tag in TagS)
            {

                if (tag.Value.Address.Contains(":I.Data") || tag.Value.Address.Contains(":O.Data"))
                    //tag.Value.Address.Contains(":I.Slot") || tag.Value.Address.Contains(":O.Slot") )
                {
                    LstIoTag.Add(GetTagValueIO(tag.Value));
                }
                else if (tag.Value.Address.Contains(":S."))
                {
                    LstSTag.Add(GetTagValueS(tag.Value));
                }
                else if (tag.Value.Name == tag.Value.Address)
                {
                    LstBaseTag.Add(GetTagValueBASE(tag.Value));                                  
                }
                else if (tag.Value.DataType == EMDataType.Timer || tag.Value.DataType == EMDataType.Time || tag.Value.DataType == EMDataType.Counter)
                {
                    LstTandCTag.Add(GetTagValueS(tag.Value));
                }
                else if (tag.Value.Address.Contains(":I") || tag.Value.Address.Contains(":O"))
                {
                    LstEtcTag.Add(GetTagValueS(tag.Value));
                }
                else
                {
                    if (!DicDummyTagS.ContainsKey(GetDummyName(tag.Value.Address)))
                    {
                        List<ABTag> tagS = new List<ABTag> {GetTagValueDummy(tag.Value)};
                        DicDummyTagS.Add(GetDummyName(tag.Value.Address), tagS);
                    }
                    else
                    {
                        DicDummyTagS[GetDummyName(tag.Value.Address)].Add(GetTagValueDummy(tag.Value));
                    }
                }
            }

            DicArraySort();

            LstIoTag.Sort(CompareID);
        }

        private void DicArraySort()
        {
            foreach (KeyValuePair<string, List<ABTag>> tagGroup in DicDummyTagS)
            {
                tagGroup.Value.Sort((a, b) => a.ABARRAYSIZE.CompareTo(b.ABARRAYSIZE));
            }
        }

        private static int PartCompare(int a , int b )
        {
            return a.CompareTo(b);
        }

        private ABTag GetTagValueIO(CTag tag)
        {
            ABTag abTag = new ABTag();
            abTag.ABBaseTag = BaseTagChecker(tag.Address);
            abTag.ABADDRESSINDEX = GenerateAddressIndex(tag.Address);
            abTag.ABID = GenerateID(tag.Address);
            abTag.ABINFO = GenerateINFO(GenerateID(tag.Address));
            abTag.ABADDRESSTEMP = GenerateAddressTemp(tag.Address);
            abTag.ABDATATYPE = tag.DataType.ToString().ToUpper();
            abTag.ABGROUP = GetIorO(tag.Address);
            abTag.ABADDRESS = tag.Address;
            abTag.ABMODULE = tag.Program;
            abTag.ABSYMBOL = tag.Name;
            abTag.ABUPDATETIME = DateTime.Now.TimeOfDay.ToString();
            abTag.Description = tag.Description;

            return abTag;
        }

        private ABTag GetTagValueBASE(CTag tag)
        {
            ABTag abTag = new ABTag();
            abTag.Address = tag.Address;
            abTag.DataType = tag.DataType;
            abTag.Name = tag.Name;
            abTag.ABBaseTag = true;
            abTag.ABARRAYSIZE = GetArraySize(tag.Address);
            abTag.ABABITSIZE = GetBitSize(tag.Address);
            abTag.ABMODULE = tag.Program;
            abTag.Description = tag.Description;
            abTag.ABUPDATETIME = DateTime.Now.TimeOfDay.ToString();
            abTag.ABID = GetDummyID(tag.Address);
            abTag.ABINFO = GetDummyIDInfo(tag.Address);

            return abTag;
        }

        private ABTag GetTagValueS(CTag tag)
        {
            ABTag abTag = new ABTag();
            abTag.Address = tag.Address;
            abTag.DataType = tag.DataType;
            abTag.Name = tag.Name;
            abTag.ABBaseTag = BaseTagChecker(tag.Address);
            abTag.ABADDRESSINDEX = GenerateAddressIndex(tag.Address);
            abTag.ABID = GenerateID(tag.Address);
            abTag.ABINFO = GenerateSLocalNumber(tag.Address);
            abTag.ABADDRESSTEMP = GenerateAddressTemp(tag.Address);
            abTag.ABDATATYPE = tag.DataType.ToString().ToUpper();
            abTag.ABADDRESS = tag.Address;
            abTag.ABMODULE = tag.Program;
            abTag.ABSYMBOL = tag.Name;
            abTag.ABUPDATETIME = DateTime.Now.TimeOfDay.ToString();
            abTag.Description = tag.Description;
            return abTag;
        }

        private ABTag GetTagValueDummy(CTag tag)
        {
            ABTag abTag = new ABTag();
            abTag.Address = tag.Address;
            abTag.DataType = tag.DataType;
            abTag.Name = tag.Name;
            abTag.ABBaseTag = true;
            abTag.ABARRAYSIZE = GetArraySize(tag.Address);
            abTag.ABABITSIZE = GetBitSize(tag.Address);
            abTag.ABMODULE = tag.Program;
            abTag.Description = tag.Description;
            abTag.ABUPDATETIME = DateTime.Now.TimeOfDay.ToString();
            abTag.ABID = GetDummyID(tag.Address);
            abTag.ABINFO = GetDummyIDInfo(tag.Address);

            return abTag;
        }

        private string GetDummyName(string Address)
        {
            if (Address.Contains("."))
                return Address.Split('.')[0];
            else
                return Address;
        }

        private string GetDummyIDInfo(string Address)
        {
            if (Address.Contains("["))
                return Address.Split('[')[0];
            else
                return Address;
        }

        private string GetDummyID(string Address)
        {
            if (Address.Contains("."))
                return Address.Split('.')[0];
            else
                return Address;
        }

        private string GetArraySize(string address)
        {
            if (address.Contains("["))
            {
                string value = address.Split('[')[1].Replace("]", "");

                if (address.Contains("."))
                    return value.Split('.')[0];
                else
                    return value;
            }
            else
                return "";

        }

        private string GetBitSize(string address)
        {
            if(address.Contains("."))
            {
                return address.Split('.')[1];
            }
            else
            {
                return "";
            }
        }

        private int GenerateAddressIndex(string Address)
        {

            return 1;
        }

        private string GenerateID(string Address)
        {
            try
            {
                Match RexModule = Regex.Match(Address, @":" + @"\s*(.+?)\s*" + ":");
                Match RexSize = Regex.Match(Address, @"[" + @"\s*(.+?)\s*" + "]");
                string arraySize = string.Empty;
                string module = string.Empty;
                string bit = string.Empty;

                if (Address.Contains("["))
                {
                    int size = int.Parse(Address.Split('[')[1].Split(']')[0]);
                    if (size >= 100)
                        return "OverSize";
                    arraySize = string.Format("{0:00}", size);
                }

                string io = Address.Split(':')[2].Split('.')[0];
                if (arraySize == string.Empty)
                    module = string.Format("{0:0000}", int.Parse(RexModule.Groups[1].Value));
                else
                    module = string.Format("{0:00}", int.Parse(RexModule.Groups[1].Value));

                string[] bitArray = Address.Split('.');
                if (bitArray.Length > 2)
                    bit = "." + bitArray[2];

                return io + module + arraySize + bit;
            }
            catch (Exception ex)
            {
                return "GenerateID Fail";
            }
        }

        private string GenerateINFO(string Address)
        {
            string value = string.Empty;
            if (Address.Contains("."))
                value = Address.Split('.')[0];
            else
                value = Address;

            return value.Replace("I", "").Replace("O", "");
        }

        private string GenerateAddressTemp(string Address)
        {
            return "";
        }

        private string GenerateSLocalNumber(string Address)
        {
            if(Address.Contains(":"))
            {
                return Address.Split(':')[1];
            }
            else
            {
                return "";
            }
        }

        private string GetIorO(string value)
        {
            if (value.Contains(":I.Data"))
                return "I";
            else if (value.Contains(":O.Data"))
                return "O";
            else
                return "";
        }

        #endregion

        #region Excel

        public bool ExportToExcel(List<ABTag> listTag, string inputPath, string outputPath, string coverName)
        {

            var excelApp = new Application();
            var excelWorkbook = excelApp.Workbooks.Open(inputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            CreateCoverSheet(excelWorkbook, 0, coverName);
            //CreateMapSheet(excelWorkbook, GetMapData(listTag));

            var hyperAddress = new List<string>();
            var sortingData = GetSortingData(listTag);
            var count = 0;
            foreach (var sheet in sortingData)
            {
                CreateSheet(excelWorkbook, listTag, sheet.Value);
                hyperAddress.Add(GetSheetName(sheet.Value));

                if (UEventExcelExportProcess != null)
                {
                    IOListExport_UEventExcelExportProcess(null, count++ * 100 / sortingData.Count);
                }
            }

            CreateMapSheet(excelWorkbook, hyperAddress);

            var startSheet = (Worksheet)excelWorkbook.Sheets[1];
            startSheet.Select(Type.Missing);
            DeleteTemplate(excelWorkbook);

            var xlFileFormat = XlFileFormat.xlWorkbookNormal;
            if (outputPath.Substring(outputPath.Length - 1, 1) == "x")
                xlFileFormat = XlFileFormat.xlWorkbookDefault;
            excelWorkbook.SaveAs(outputPath, xlFileFormat, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;

            // Release the Application object   
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            excelApp = null;

            return true;
        }

        public bool ExportToExcelDummy(SortedDictionary<string, List<ABTag>> dicTagS, string inputPath, string outputPath, string coverName)
        {
            //Stopwatch sw = new Stopwatch();
            var excelApp = new Application();
            var excelWorkbook = excelApp.Workbooks.Open(inputPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            CreateCoverSheet(excelWorkbook, 0, coverName);
            CreateMapSheetDummy(excelWorkbook, dicTagS);
            var count = 0;
            foreach (KeyValuePair<string, List<ABTag>> tag in dicTagS)
            {
                CreateSheetDummy(excelWorkbook, tag.Key, tag.Value);

                if (UEventExcelExportProcess != null)
                {
                    IOListExport_UEventExcelExportProcess(null, count++ * 100 / dicTagS.Count);
                }
            }

            var startSheet = (Worksheet) excelWorkbook.Sheets[1];
            startSheet.Select(Type.Missing);

            DeleteTemplate(excelWorkbook);
            
            var xlFileFormat = XlFileFormat.xlWorkbookNormal;
            if (outputPath.Substring(outputPath.Length - 1, 1) == "x")
                xlFileFormat = XlFileFormat.xlWorkbookDefault;

            excelWorkbook.SaveAs(outputPath, xlFileFormat, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);

            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            return true;
        }

        private void DeleteTemplate(Workbook excelWorkbook)
        {
            for (var i = excelWorkbook.Worksheets.Count; i > 0; i--)
            {
                var wkSheet = (Worksheet) excelWorkbook.Sheets[i];
                if (wkSheet.Name.Contains("TEMPLATE"))
                {
                    wkSheet.Delete();
                }
            }
        }

        void IOListExport_UEventExcelExportProcess(object sender, int nProcess)
        {
            if (UEventExcelExportProcess != null)
            {
                if (nProcess > 99)
                    nProcess = 99;

                UEventExcelExportProcess(null, nProcess);
            }
        }

        #region Create Sheet

        private static void CreateCoverSheet(Workbook excelWorkbook, int nStartRow, string strCoverName)
        {
            // Create a new Sheet
            Worksheet excelSheet = new Worksheet();

            excelSheet = (Worksheet)excelWorkbook.Sheets[1];

            excelSheet.Cells[18, 24] = strCoverName;
            excelSheet.Cells[24, 24] = DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void CreateMapSheet(Workbook excelWorkbook, List<string> HyperLinkAddress)
        {
            Worksheet excelSheet = new Worksheet();
            double value = (double)HyperLinkAddress.Count / (double)IOListABSheetFormat.MAPSHEETITEMCOUNT;
            int sheetCount = (int)Math.Ceiling(value);

            for (int i = 0; i < sheetCount; i++)
            {
                excelSheet = (Worksheet)excelWorkbook.Sheets[i + 2];
                excelSheet.Copy(Type.Missing, excelSheet);
                if (i == 0)
                {
                    excelSheet.Name = "MAP";
                    SettingMapSheet(excelSheet, HyperLinkAddress , i);
                }
                else
                {
                    excelSheet.Name = "MAP-" + i;
                    SettingMapSheet(excelSheet, HyperLinkAddress, i * IOListABSheetFormat.MAPSHEETITEMCOUNT);
                }
                    
            }
        }

        private void SettingMapSheet(Worksheet excelSheet, List<string> HyperLinkAddress, int start)
        {
            int MapCount = start;
            for (int row = IOListABSheetFormat.MAPROWSTART; row < IOListABSheetFormat.MAPROWEND; row++)
            {
                if (row % 2 == 1)
                {
                    if (HyperLinkAddress.Count <= MapCount)
                        return;

                    var cell = (Range)excelSheet.Cells[row, IOListABSheetFormat.MAPCOLADDRESS_1];
                    string HyperlinkAddress = "'" + HyperLinkAddress[MapCount] + "'!A1";
                    excelSheet.Hyperlinks.Add(excelSheet.get_Range(cell, cell), string.Empty, HyperlinkAddress, Type.Missing, Type.Missing);
                    excelSheet.Cells[row, IOListABSheetFormat.MAPCOLDESCRIPTION_1] = HyperLinkAddress[MapCount];
                    excelSheet.Cells[row, IOListABSheetFormat.MAPCOLADDRESS_1] = HyperLinkAddress[MapCount++];

                    if (HyperLinkAddress.Count <= MapCount)
                        return;

                    var cell2 = (Range)excelSheet.Cells[row, IOListABSheetFormat.MAPCOLADDRESS_2];
                    string HyperlinkAddress2 = "'" + HyperLinkAddress[MapCount] + "'!A1";
                    excelSheet.Hyperlinks.Add(excelSheet.get_Range(cell2, cell2), string.Empty, HyperlinkAddress2, Type.Missing, Type.Missing);
                    excelSheet.Cells[row, IOListABSheetFormat.MAPCOLDESCRIPTION_2] = HyperLinkAddress[MapCount];
                    excelSheet.Cells[row, IOListABSheetFormat.MAPCOLADDRESS_2] = HyperLinkAddress[MapCount++];

                    var Mergecell1 = (Range)excelSheet.Cells[row, IOListABSheetFormat.MAPCOLDESCRIPTION_1];
                    var Mergecell2 = (Range)excelSheet.Cells[row+1, IOListABSheetFormat.MAPCOLDESCRIPTION_1];

                    excelSheet.Range[Mergecell1, Mergecell2].Merge();
                }
                else
                {
                    //excelSheet.Cells[row, IOListABSheetFormat.MAPCOLADDRESS_1] = Mapdata[MapCount++].Replace("-", "-Q");
                }

            }
        }

        private void CreateSheet(Workbook excelWorkbook, List<ABTag> listTag, ABTag tag)
        {
            var excelSheet = new Worksheet();
            excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];
            excelSheet.Copy(Type.Missing, excelSheet);
            excelSheet.Name = GetSheetName(tag);

            SettingSheet(excelSheet, tag, listTag);

        }

        int i = 1;
        private bool CreateSheetDummy(Workbook excelWorkbook, List<ABTag> listTag, ABTag tag)
        {
            if (DummyArrayChecker(tag))
            {
                string SheetName = tag.ABID.Replace("[", "(").Replace("]", ")");

                Worksheet excelSheet = new Worksheet();
                excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];
                excelSheet.Copy(Type.Missing, excelSheet);
                excelSheet.Name = SheetName + i++;

                SettingSheetDummy(excelSheet, tag, listTag);
                return true;
            }
            else
                return false;
        }

        private void SettingSheet(Worksheet excelSheet, ABTag tag, List<ABTag> listTag)
        {
            int Icount = 0;
            int Qcount = 0;
            string specifier = string.Empty;

            excelSheet.Cells[2, 2] = GetSheetMainName(tag) + " [" + tag.ABMODULE + "]";

            for (int row = IOListABSheetFormat.ROWSTART_I; row < IOListABSheetFormat.defaultSize; row++)
            {
                if (IOListABSheetFormat.ROWSTART_Q <= row)
                {
                    specifier = GetSpecifierOtoI(tag.ABADDRESS) + "." + string.Format("{0:0}", Qcount);
                    excelSheet.Cells[row, IOListABSheetFormat.COlSPECIFIER] = specifier;
                    excelSheet.Cells[row, IOListABSheetFormat.COLNUMBERING] = "O" + tag.ABINFO + "." + string.Format("{0:00}", Qcount++);

                }
                else
                {
                    specifier = GetSpecifierItoO(tag.ABADDRESS) + "." + string.Format("{0:0}", Icount);
                    excelSheet.Cells[row, IOListABSheetFormat.COlSPECIFIER] = specifier;
                    excelSheet.Cells[row, IOListABSheetFormat.COLNUMBERING] = "I" + tag.ABINFO + "." + string.Format("{0:00}", Icount++);

                }

                InputValues(excelSheet, row, specifier, tag, listTag);
            }

            string excelRange = string.Format("{0}{1}:{2}{3}", "A", 1, "A", 1);
            string hyperlinkTargetAddress = "'MAP'!A1";
            excelSheet.Hyperlinks.Add(excelSheet.get_Range(excelRange, excelRange), string.Empty, hyperlinkTargetAddress, Type.Missing, Type.Missing);
            excelSheet.get_Range(excelRange, excelRange).Font.Size = 10;
        }

        private void SettingSheetDummy(Worksheet excelSheet, ABTag tag, List<ABTag> listTag)
        {
            int count = 0;
            string specifier = string.Empty;

            excelSheet.Cells[2, 2] = tag.ABID + " [" + tag.ABMODULE + "]";

            for (int row = IOListABSheetFormat.ROWSTART_I; row < IOListABSheetFormat.defaultSize; row++)
            {
                if (IOListABSheetFormat.ROWSTART_Q <= row)
                {

                }
                else
                {
                    specifier = tag.ABID + "." + string.Format("{0:0}", count++);
                    excelSheet.Cells[row, IOListABSheetFormat.COlSPECIFIER] = specifier;
                }

                InputValues(excelSheet, row, specifier, tag, listTag);
            }

            string excelRange = string.Format("{0}{1}:{2}{3}", "A", 1, "A", 1);
            string hyperlinkTargetAddress = "'MAP'!A1";
            excelSheet.Hyperlinks.Add(excelSheet.get_Range(excelRange, excelRange), string.Empty, hyperlinkTargetAddress, Type.Missing, Type.Missing);
            excelSheet.get_Range(excelRange, excelRange).Font.Size = 10;
        }

        private void InputValues(Worksheet excelSheet, int row, string specifier, ABTag tag, List<ABTag> listTag)
        {
            List<ABTag> FindTag = listTag.FindAll(findTag => findTag.ABADDRESS == specifier);

            if (FindTag.Count == 1)
            {
                excelSheet.Cells[row, IOListABSheetFormat.COlSYMBOLNAME] = FindTag[0].ABSYMBOL;
                excelSheet.Cells[row, IOListABSheetFormat.COlDATATYPE] = FindTag[0].ABDATATYPE;
            }
            else if (FindTag.Count >= 2)
            {
                List<string> list = new List<string>();
                foreach (ABTag findtag in FindTag)
                    list.Add(findtag.ABSYMBOL);

                excelSheet.Cells[row, IOListABSheetFormat.COlSYMBOLNAME] = FindTag[0].ABSYMBOL;
                excelSheet.Cells[row, IOListABSheetFormat.COlDATATYPE] = FindTag[0].ABDATATYPE;

                var flatList = string.Join(",", list.ToArray());
                var cell = (Range)excelSheet.Cells[row, IOListABSheetFormat.COlSYMBOLNAME];
                cell.Validation.Delete();
                cell.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertInformation, XlFormatConditionOperator.xlBetween, flatList, Type.Missing);
                cell.Validation.IgnoreBlank = true;
                cell.Validation.InCellDropdown = true;

                ((Range)excelSheet.Cells[row, IOListABSheetFormat.COlSYMBOLNAME]).Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Silver);
            }

        }

        private void CreateMapSheetDummy(Workbook excelWorkbook, SortedDictionary<string, List<ABTag>> KeyS)
        {
            
            Worksheet excelSheet = new Worksheet();
            double value = KeyS.Keys.Count / (double)IOListABSheetFormat.MAPSHEETITEMCOUNTDUMMY;
            int sheetCount = (int)Math.Ceiling(value);

            for (int i = 0; i < sheetCount; i++)
            {
                excelSheet = (Worksheet)excelWorkbook.Sheets[i + 2];
                excelSheet.Copy(Type.Missing, excelSheet);
                if (i == 0)
                {
                    excelSheet.Name = "MAP";
                    SettingMapSheetDummy(excelSheet, KeyS, i);
                }
                else
                {
                    excelSheet.Name = "MAP-" + i;
                    SettingMapSheetDummy(excelSheet, KeyS, i * IOListABSheetFormat.MAPSHEETITEMCOUNTDUMMY);
                }
            }

        }

        private void SettingMapSheetDummy(Worksheet excelSheet, SortedDictionary<string, List<ABTag>> KeyS, int start)
        {
            int MapCount = start;
            List<string> HyperLinkAddress = KeyListSorting(KeyS.Keys.ToList());

            for (int i = 1; i < 5; i++) 
            {
                for (int row = IOListABSheetFormat.MAPDUMMYROWSTART; row < IOListABSheetFormat.MAPDUMMYROWEND; row++)
                {

                    if (HyperLinkAddress.Count <= MapCount)
                        return;

                    InputCellDummy(excelSheet, row, HyperLinkAddress[MapCount++], i);
                }

            }
        }

        private void  InputCellDummy(Worksheet excelSheet, int row, string HyperLinkAddress, int number)
        {

            int Address = IOListABSheetFormat.MAPCOLADDRESS_1, description = IOListABSheetFormat.MAPCOLDESCRIPTION_1;
            if(number == 1)
            {
                Address = IOListABSheetFormat.MAPCOLADDRESS_1;
                description = IOListABSheetFormat.MAPCOLDESCRIPTION_1;
            }
            else if(number == 2)
            {
                Address = IOListABSheetFormat.MAPCOLADDRESS_2;
                description = IOListABSheetFormat.MAPCOLDESCRIPTION_2;
            }
            else if (number == 3)
            {
                Address = IOListABSheetFormat.MAPCOLADDRESS_3;
                description = IOListABSheetFormat.MAPCOLDESCRIPTION_3;
            }
            else if (number == 4)
            {
                Address = IOListABSheetFormat.MAPCOLADDRESS_4;
                description = IOListABSheetFormat.MAPCOLDESCRIPTION_4;
            }

            var cell = (Range)excelSheet.Cells[row, Address];
            string HyperlinkAddress = "'" + HyperLinkAddress.Replace("[","(").Replace("]",")") + "'!A1";
            excelSheet.Hyperlinks.Add(excelSheet.get_Range(cell, cell), string.Empty, HyperlinkAddress, Type.Missing, Type.Missing);
            excelSheet.Cells[row, description] = HyperLinkAddress;
            excelSheet.Cells[row, Address] = HyperLinkAddress;
        }

        private void CreateSheetDummy(Workbook excelWorkbook, string key, List<ABTag> tag)
        {
            if (key.Contains(":I") || key.Contains(":O"))
                return;

            Worksheet excelSheet = new Worksheet();
            excelSheet = (Worksheet)excelWorkbook.Sheets[excelWorkbook.Sheets.Count];
            excelSheet.Copy(Type.Missing, excelSheet);
            excelSheet.Name = key.Replace("[", "(").Replace("]", ")");

            SettingSheetDummy(excelSheet, key, tag);

        }

        private void SettingSheetDummy(Worksheet excelSheet, string key, List<ABTag> tag)
        {
            tag.Sort(CompareAddress);

            int tagIndex = 0;
            excelSheet.Cells[2, 2] = key;

            for (int row = IOListABSheetFormat.ROWSTART_I; row < IOListABSheetFormat.defaultSize; row++)
            {
                if (tagIndex == tag.Count)
                    return;

                excelSheet.Cells[row, IOListABSheetFormat.COlSPECIFIER] = tag[tagIndex].Address;
                excelSheet.Cells[row, IOListABSheetFormat.COlDATATYPE] = tag[tagIndex].DataType.ToString();
                excelSheet.Cells[row, IOListABSheetFormat.COlDESCRIPTION] = tag[tagIndex].Description;
                excelSheet.Cells[row, IOListABSheetFormat.COlSYMBOLNAME] = tag[tagIndex++].Name;

                string excelRange = string.Format("{0}{1}:{2}{3}", "A", 1, "A", 1);
                string hyperlinkTargetAddress = "'MAP'!A1";
                excelSheet.Hyperlinks.Add(excelSheet.get_Range(excelRange, excelRange), string.Empty, hyperlinkTargetAddress, Type.Missing, Type.Missing);
                excelSheet.get_Range(excelRange, excelRange).Font.Size = 10;
            }
        }
        
        #endregion

        #endregion

        #region public Methods

        private string GetSheetName(ABTag tag)
        {
            string name = string.Empty;

            try
            {
                string[] addrss = tag.ABSYMBOL.Split('_');

                name = addrss[0] + " " + addrss[1] + " " + addrss[2] + "-" + tag.ABINFO;
                return name;
            }
            catch (Exception ex)
            {
                return name;
            }

        }

        private string GetSheetMainName(ABTag tag)
        {
            string name = string.Empty;

            try
            {
                string[] addrss = tag.ABSYMBOL.Split('_');

                name = addrss[0] + " " + addrss[1] + " " + addrss[2];
                return name;
            }
            catch (Exception ex)
            {
                return name;
            }
        }

        private string GetSpecifierOtoI(string address)
        {
            try
            {
                string[] arr = address.Split('.');

                return arr[0].Replace(":I",":O") + "." + arr[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }

        private string GetSpecifierItoO(string address)
        {
            try
            {
                string[] arr = address.Split('.');

                return arr[0].Replace(":O", ":I") + "." + arr[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }

        private Dictionary<string, ABTag> GetSortingData(List<ABTag> tags)
        {
            Dictionary<string, ABTag> temp = new Dictionary<string, ABTag>();
            Dictionary<string, ABTag> IDInfoData = new Dictionary<string, ABTag>();

            foreach (ABTag tag in tags)
            {
                if (!temp.ContainsKey(tag.ABINFO))
                    temp.Add(tag.ABINFO, tag);
            }

            foreach (var item in temp.OrderBy(i => i.Key))
                IDInfoData.Add(item.Key, item.Value);

            temp.Clear();

            return IDInfoData;
        }

        private Dictionary<string, ABTag> GetDummyGroup(List<ABTag> tags)
        {
            Dictionary<string, ABTag> temp = new Dictionary<string, ABTag>();
            Dictionary<string, ABTag> IDInfoData = new Dictionary<string, ABTag>();

            foreach (ABTag tag in tags)
            {
                if (!temp.ContainsKey(tag.ABID))
                    temp.Add(tag.ABID, tag);
            }

            foreach (var item in temp.OrderBy(i => i.Key))
                IDInfoData.Add(item.Key, item.Value);

            temp.Clear();

            var myList = IDInfoData.ToList();
            myList.Sort((cp1, cp2) => cp1.Value.ABARRAYSIZE.CompareTo(cp2.Value.ABARRAYSIZE));

            return IDInfoData;
        }

        private List<string> GetMapData(List<ABTag> tags)
        {
            List<string> IDinfos = new List<string>();
            foreach (ABTag tag in tags)
            {
                if (!IDinfos.Contains(tag.ABINFO))
                    IDinfos.Add(tag.ABINFO);
            }

            List<string> map = new List<string>();
            foreach (string IDinfo in IDinfos)
            {
                ABTag tagInfo = tags.FirstOrDefault(xx => xx.ABINFO == IDinfo);
                map.Add(GetSheetName(tagInfo));
            }

            return map;
        }

        private bool BaseTagChecker(string Address)
        {
            if (Address.Contains(".") || Address.Contains(":"))
                return false;
            else
                return true;
        }

        #region Dummy

        private bool DummyArrayChecker(ABTag tag)
        {
            if (tag.Address.Contains("["))
                return true;
            else
                return false;
        }

        #endregion

        #endregion

        #region Sorting

        private static int CompareID(ABTag x, ABTag y)
        {
            return CompareString(string.Format("{0:00000000}", x.ABID), string.Format("{0:00000000}", y.ABID));
        }

        private static int CompareString(string textA1, string textB1)
        {
            if (textA1 == null)
            {
                if (textB1 == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (textB1 == null)
                    return 1;
                else

                    return textA1.CompareTo(textB1);
            }
        }

        private int CompareAddress(ABTag x, ABTag y)
        {
            return CompareInt(GetPointNumber(x.Address), GetPointNumber(y.Address));
        }

        private string GetPointNumber(string value)
        {
            if (value.Contains("."))
            {
                return value.Split('.')[1];
            }
            else
                return "";
        }

        private int CompareInt(string A, string B)
        {
            string textA1 = NumberChecker(A);
            string textB1 = NumberChecker(B);

            if (textA1 == null || textA1 == "")
            {
                if (textB1 == null || textB1 == "")
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (textB1 == null || textB1 == "")
                    return 1;
                else
                {
                    int a = int.Parse(textA1);
                    int b = int.Parse(textB1);
                    return a.CompareTo(b);
                }

            }

        }

        private string NumberChecker(string value)
        {
            bool OK = true;

            foreach (char ch in value)
            {
                if (!Char.IsDigit(ch))
                    OK = false;
            }

            if (OK)
                return value;
            else
                return "";
        }

        private List<string> KeyListSorting(List<string> KeyList)
        {
            Dictionary<string, List<string>> DicTemp = new Dictionary<string, List<string>>();
            List<string> lstSort = new List<string>();
            List<string> lstTemp = new List<string>();

            foreach (string key in KeyList)
            {
                if (key.Contains("["))
                {
                    if (!DicTemp.ContainsKey(GetKeyGroup(key)))
                        DicTemp.Add(GetKeyGroup(key), new List<string>() { key });
                    else
                        DicTemp[GetKeyGroup(key)].Add(key);
                }
                else
                    lstTemp.Add(key);
            }

            foreach (KeyValuePair<string, List<string>> temp in DicTemp)
                temp.Value.Sort(GetArrayNumber);

            foreach (KeyValuePair<string, List<string>> temp in DicTemp)
                lstSort.AddRange(temp.Value.ToArray());

            foreach (string t in lstTemp)
                lstSort.Add(t);

            return lstSort;
        }

        private string GetKeyGroup(string key)
        {
            return key.Split('[')[0];
        }

        private int GetArrayNumber(string a , string b)
        {

            string tempA = a.Split('[')[1].Replace("]", "");
            string tempB = b.Split('[')[1].Replace("]", "");
            return CompareInt(tempA, tempB);
        }

        #endregion


    }
}
