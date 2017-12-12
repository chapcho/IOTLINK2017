using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using UDM.Common;
using System.Drawing;

namespace UDM.Export
{
    public class CUIODataSet
    {
        #region Fields

        DataSet _DataSet = new DataSet();
        eExcelListType _ExcelListType = eExcelListType.IO;
        int _MaxMoudelInSheet = 4;

        #endregion

        #region Initialize/Dispose

        public CUIODataSet(eExcelListType ExcelListType)
        {
            _ExcelListType = ExcelListType;
            _MaxMoudelInSheet = PlcHelper.GetFormMaxMoudelInSheet(ExcelListType);
        }

        public void Dispose()
        {
          
        }

        #endregion

        public DataSet CreateDataSet(CTagS cTagS)
        {
            CUIOSet cUIOSet = CreateUIOSet(cTagS);
            cUIOSet._MaxBlcokInModule = PlcHelper.GetFormMaxBlcokInModule(_ExcelListType);

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                cUIOSet.MakeSpeciferList();

            cUIOSet.MakeSpareUIO(false);
            cUIOSet.MakeSpareBlock(_ExcelListType);
            cUIOSet.MakeModuleBlock(_ExcelListType);

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
            {
                foreach (CUIOBlock UIOBlock in cUIOSet.UIOBLOCKLIST)
                    UIOBlock.SetSpecifer(cUIOSet._DicTagMapping);
            }

            if (_ExcelListType == eExcelListType.IO)
            {
                if ((PlcHelper._PLCMAKER == ePLC_MAKER.MITSUBISHI_DEVELOPER || PlcHelper._PLCMAKER == ePLC_MAKER.MITSUBISHI_WORKS2))
                    CreateDataSetMapforMelsecIOList(cUIOSet);
                else
                    CreateDataSetMapIOList(cUIOSet);
            }
            else
            {
                CreateDataSetMapDummy(cUIOSet);
            }

            CreateDataSetUIO(cUIOSet);

            return _DataSet;
        }


        private CUIOSet CreateUIOSet(CTagS cTagS)
        {
            try
            {
                List<CUIOItem> lstUIOItem = new List<CUIOItem>();
                List<string> ListType = PlcHelper.GetSelectedListType(_ExcelListType);
                foreach (CTag cTag in cTagS.Values)
                {
                    CUIOItem cUIOItem = new CUIOItem();
                    cUIOItem.ADDRESS = cTag.Address;
                    cUIOItem.SYMBOL = cTag.Description;
                    cUIOItem.UpdateProperty();

                    if (!ListType.Contains(cUIOItem.HEADTYPE))
                        continue;

                    if (cUIOItem.ADDRESSTEMP != string.Empty)
                        lstUIOItem.Add(cUIOItem);
                    else
                        Console.WriteLine("Coverting Missing : {0}", cTag.Address);
                }


                CUIOSet cUIOSet = new CUIOSet(lstUIOItem);
                return cUIOSet;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
                return null;
            }
        }

      
        private void CreateDataSetMapIOList(CUIOSet _UIOSet)
        {
            try
            {
                int nNewModule = 0;

                string strCurrentTable = string.Empty;
                int nCurrentSameBlock = 0;
                List<string> ListTable = new List<string>();
                Point PT = new Point(-1, -1);

                foreach (CUIOModule UIOModule in _UIOSet.UIOMODULELIST)
                {
                    if (IsMapSkip(UIOModule))
                        continue;

                    if ((PT.X == -1 && PT.Y == -1)
                        || nNewModule <= UIOModule.UIOBLOCKLIST[0].BLOCKINDEX
                        || nCurrentSameBlock != UIOModule.UIOBLOCKLIST[0].SAMEBLOCKINDEX)
                    {
                        strCurrentTable = string.Format(eTableControl.MAP + "({0})", PlcHelper.GetAddWithBlockIndex(UIOModule.UIOBLOCKLIST[0].BLOCKINDEX, UIOModule.UIOBLOCKLIST[0].HEADTYPE));

                        if (UIOModule.HASSAMEBLCOK)
                            strCurrentTable = GetRedunducyTableName(strCurrentTable, UIOModule);

                        if (strCurrentTable.Contains(".00"))
                            strCurrentTable = strCurrentTable.Replace(".00", string.Empty);

                        if (nNewModule <= UIOModule.UIOBLOCKLIST[0].BLOCKINDEX)
                            nNewModule = 999999;

                        MakeNewMapTable(strCurrentTable);
                        nCurrentSameBlock = UIOModule.UIOBLOCKLIST[0].SAMEBLOCKINDEX;
                        PT = new Point(0, 0);
                    }

                    PT = InsertValueInMapTable(strCurrentTable, UIOModule, PT, ListTable);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }


        private CFilterGridIndex MakefilterGridIndexMap()
        {
            CFilterGridIndex filterGridIndex = new CFilterGridIndex();

            if (_ExcelListType == eExcelListType.IO)
                filterGridIndex.SetMapIOFormat(0, 1);
            else
                filterGridIndex.SetMapDummyFormat(0, 1);

            return filterGridIndex;
        }


        private Point InsertValueInMapTable(string strTable, CUIOModule Module, Point pStart, List<string> ListTable)
        {
            try
            {
                DataTable DT = _DataSet.Tables[strTable];

                int nRow = pStart.Y;
                int nCol = pStart.X;

                if (_ExcelListType != eExcelListType.IO)
                {
                    string strTargetSheet = PlcHelper.GetAddWithBlockIndex(Module.UIOBLOCKLIST[0].BLOCKINDEX, Module.UIOBLOCKLIST[0].HEADTYPE);
                    if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    {
                        if (Module.GetUserTag() == string.Empty)
                            return pStart;
                        else
                            strTargetSheet = GetTagTableName(Module, ListTable);
                    }


                    if (Module.HASSAMEBLCOK)
                        strTargetSheet = GetRedunducyTableName(strTargetSheet, Module);

                    if (strTargetSheet.Contains(".00"))
                        strTargetSheet = strTargetSheet.Replace(".00", string.Empty);

                    DT.Rows[nRow + 2][nCol + 2] = strTargetSheet;
                    DT.Rows[nRow + 2][nCol + 3] = Module.INFO;

                    ListTable.Add(strTargetSheet);

                    pStart.Y++;

                    if (pStart.Y >= 32)
                    {
                        pStart.Y = 0;
                        pStart.X += 3;
                    }
                    if (pStart.X > 9)
                    {
                        pStart.Y = -1;
                        pStart.X = -1;
                    }
                }
                else
                {
                    for (int n = 0; n < Module.UIOBLOCKLIST.Count; n++)
                    {

                        string strTargetSheet = PlcHelper.GetAddWithBlockIndex(Module.UIOBLOCKLIST[n].BLOCKINDEX, Module.UIOBLOCKLIST[n].HEADTYPE);

                        if (strTargetSheet.Contains(".00"))
                            strTargetSheet = strTargetSheet.Replace(".00", string.Empty);

                    
                            if (Module.UIOBLOCKLIST[n].SAMEBLOCKINDEX > 0)
                                DT.Rows[nRow + n + 2][nCol + 2] = GetRedunducyTableName(strTargetSheet, Module);
                            else
                                DT.Rows[nRow + n + 2][nCol + 2] = strTargetSheet;

                        if (n % 2 == 0)
                        {
                            DT.Rows[nRow + n + 2][nCol + 3] = Module.INFO;
                            if (Module.SOLT != string.Empty)
                                if (Module.SOLT.Contains(ePLC_SLOT.BASE00))
                                    DT.Rows[nRow + n + 2][nCol + 1] = Module.SOLT + eSplit.EXCELYELLOW;
                                else
                                    DT.Rows[nRow + n + 2][nCol + 1] = Module.SOLT + eSplit.EXCELAQUA;
                        }
                        else
                        {
                            DT.Rows[nRow + n + 2][nCol + 3] = Module.MODULE + (Module.NETWORK != string.Empty ? "(" + Module.NETWORK + ")" : string.Empty);
                            if (Module.SOLTEXTEND != string.Empty)
                                if (Module.SOLT.Contains(ePLC_SLOT.BASE00))
                                    DT.Rows[nRow + n + 2][nCol + 1] = Module.SOLTEXTEND + eSplit.EXCELYELLOW;
                                else
                                    DT.Rows[nRow + n + 2][nCol + 1] = Module.SOLTEXTEND + eSplit.EXCELAQUA;
                        }


                        pStart.Y++;
                    }

                    if (pStart.Y >= 64)
                    {
                        pStart.Y = 0;
                        pStart.X += 3;
                    }
                    if (pStart.X > 3)
                    {
                        pStart.Y = -1;
                        pStart.X = -1;
                    }
                }

                return pStart;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }



        private string GetRedunducyTableName(string strCurrentTable, CUIOModule UIOModule)
        {
            string strNewTable = string.Empty;
            string strSheet = UIOModule.GetDefaultSheet();
            int nSameBlock = UIOModule.UIOBLOCKLIST[0].SAMEBLOCKINDEX;

            //             strNewTable = string.Format("{0}({1})-{2}", strCurrentTable, nSameBlock, strSheet);
            //             if (strNewTable.Length > 32)
            strNewTable = string.Format("{0}#{1}", strCurrentTable, nSameBlock);

            return strNewTable;
        }

        private void CreateDataSetMapDummy(CUIOSet _UIOSet)
        {
            try
            {
                string strCurrentTable = string.Empty;
                string strCurrentMoudleDataType = string.Empty;
                List<string> ListTable = new List<string>();
                Point PT = new Point(-1, -1);

                foreach (CUIOModule UIOModule in _UIOSet.UIOMODULELIST)
                {
                    if (IsMapSkip(UIOModule))
                        continue;

                    if ((PT.X == -1 && PT.Y == -1)
                        || strCurrentMoudleDataType != UIOModule.HEADTYPE)
                    {
                        strCurrentTable = string.Format(eTableControl.MAP + "({0})", PlcHelper.GetAddWithBlockIndex(UIOModule.UIOBLOCKLIST[0].BLOCKINDEX, UIOModule.UIOBLOCKLIST[0].HEADTYPE));

                        if (UIOModule.HASSAMEBLCOK)
                            strCurrentTable = GetRedunducyTableName(strCurrentTable, UIOModule);

                        if (strCurrentTable.Contains(".00"))
                            strCurrentTable = strCurrentTable.Replace(".00", string.Empty);

                        MakeNewMapTable(strCurrentTable);
                        strCurrentMoudleDataType = UIOModule.HEADTYPE;
                        PT = new Point(0, 0);
                    }

                    PT = InsertValueInMapTable(strCurrentTable, UIOModule, PT, ListTable);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void CreateDataSetMapforMelsecIOList(CUIOSet _UIOSet)
        {
            try
            {
                string strCurrentTable = string.Empty;
                string strCurrentMoudleDataType = string.Empty;
                List<string> ListTable = new List<string>();
                Point PT = new Point(-1, -1);

                foreach (CUIOModule UIOModule in _UIOSet.UIOMODULELIST)
                {
                    if (UIOModule.bInputEmptyModule || (!UIOModule.bOutputModule && UIOModule.HEADTYPE == PlcHelper.GetTypeOutput()))
                        continue;

                    if ((PT.X == -1 && PT.Y == -1) || (_ExcelListType != eExcelListType.IO ? strCurrentMoudleDataType != UIOModule.HEADTYPE : false))
                    {
                        strCurrentTable = string.Format(eTableControl.MAP + "(XY{0}0)", PlcHelper.GetAddressBody(UIOModule.UIOBLOCKLIST[0].BLOCK, 1));

                        if (UIOModule.HASSAMEBLCOK)
                            strCurrentTable = GetRedunducyTableName(strCurrentTable, UIOModule);

                        MakeNewMapTable(strCurrentTable);
                        strCurrentMoudleDataType = UIOModule.HEADTYPE;
                        PT = new Point(0, 0);
                    }
                    PT = InsertValueInMapTable(strCurrentTable, UIOModule, PT, ListTable);
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void CreateDataSetUIO(CUIOSet _UIOSet)
        {
            try
            {
                string strCurrentTable = string.Empty;
                string strCurrentMoudleDataType = string.Empty;
                List<string> ListTable = new List<string>();

                int nModuleItem = 0;

                foreach (CUIOModule UIOModule in _UIOSet.UIOMODULELIST)
                {
                    if (UIOModule.ISEMPTY)
                        continue;

                    if (nModuleItem % _MaxMoudelInSheet == 0 || (UIOModule.ISNEWSHEET && !UIOModule.bSpare) ||
                       (_ExcelListType != eExcelListType.IO ? strCurrentMoudleDataType != UIOModule.HEADTYPE : false))
                    {
                        strCurrentTable = PlcHelper.GetAddWithBlockIndex(UIOModule.UIOBLOCKLIST[0].BLOCKINDEX, UIOModule.UIOBLOCKLIST[0].HEADTYPE);

                        strCurrentMoudleDataType = UIOModule.HEADTYPE;

                        if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                        {
                    
                            if (_ExcelListType != eExcelListType.IO)
                                strCurrentTable = GetTagTableName(UIOModule, ListTable);

                            if (strCurrentTable.Contains(".00"))
                                strCurrentTable = strCurrentTable.Replace(".00", string.Empty);
                        }

                        if (UIOModule.HASSAMEBLCOK)
                            strCurrentTable = GetRedunducyTableName(strCurrentTable, UIOModule);


                        if (ListTable.Contains(strCurrentTable))
                        {
                            Console.WriteLine(string.Format("Error Export Excel : Exist Same Table - {0}", strCurrentTable));
                            continue;
                        }
                        else
                            ListTable.Add(strCurrentTable);

                        MakeNewUIOTable(strCurrentTable);

                        nModuleItem = 0;
                    }
                    InsertValueInTable(strCurrentTable, UIOModule);

                    nModuleItem++;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }

        private void MakeNewUIOTable(string strtableName)
        {
            try
            {
                if (_DataSet == null)
                    _DataSet = new DataSet();

                _DataSet.Tables.Add(strtableName);

                int nMaxCol = eFrmFIO.MAXCOL;
                int nMaxRow = eFrmFIO.MAXROW;

                for (int nCol = 1; nCol <= nMaxCol; nCol++)
                    _DataSet.Tables[strtableName].Columns.Add("F" + nCol.ToString());        //Add(nCol.ToString(), "F" + nCol.ToString());
                for (int nRow = 0; nRow < nMaxRow; nRow++)
                    _DataSet.Tables[strtableName].Rows.Add();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }


        private string GetTagTableName(CUIOModule UIOModule, List<string> ListTable)
        {
            string strNewTagTable = UIOModule.GetUserTag();

            if (ListTable.Contains(strNewTagTable))
                strNewTagTable = strNewTagTable + eSplit.EXCELCOPY + ListTable.Count.ToString();

            return strNewTagTable;
        }

        private void MakeNewMapTable(string strtableName)
        {
            try
            {
                if (_DataSet == null)
                    _DataSet = new DataSet();

                _DataSet.Tables.Add(strtableName);
                for (int nCol = 1; nCol <= 20; nCol++)
                    _DataSet.Tables[strtableName].Columns.Add("F" + nCol.ToString());        //Add(nCol.ToString(), "F" + nCol.ToString());
                for (int nRow = 0; nRow < 100; nRow++)
                    _DataSet.Tables[strtableName].Rows.Add();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private bool IsMapSkip(CUIOModule UIOModule)
        {
            if (UIOModule.bSpare || UIOModule.ISEMPTY)
                return true;

            if (((PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT) && UIOModule.ISEMPTY))
                return true;

            return false;
        }

        private CFilterGridIndex MakefilterGridIndex(bool bHexa)
        {
            CFilterGridIndex filterGridIndex = new CFilterGridIndex();

            if (_ExcelListType == eExcelListType.IO)
            {
                if (PlcHelper._PLCMAKER == ePLC_MAKER.SIEMENS)
                    filterGridIndex.SetIo8Format(0, 1);
                else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    filterGridIndex.SetIo32FormatForAbComment(0, 1);
                else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
                    filterGridIndex.SetIo32Format(0, 1);
                else
                    filterGridIndex.SetIo16Format(0, 1);
            }
            else
            {
                if (PlcHelper._PLCMAKER == ePLC_MAKER.SIEMENS)
                    filterGridIndex.SetDummy8Format(0, 1);
                else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
                {
                    if (_ExcelListType == eExcelListType.TIMECOUNT)
                        filterGridIndex.SetTimeCount10Format(0, 1);
                    else
                        filterGridIndex.SetDummy32Format(0, 1);
                }
                else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                {
                    if (_ExcelListType == eExcelListType.TIMECOUNT)
                        filterGridIndex.SetTimeCount10FormatForAbComment(0, 1);
                    else
                        filterGridIndex.SetDummy32FormatForAbComment(0, 1);
                }
                else
                {
                    if (bHexa)
                        filterGridIndex.SetDummy16Format(0, 1);
                    else
                        filterGridIndex.SetDummy10Format(0, 1);
                }
            }

            return filterGridIndex;
        }

        private void InsertValueInTable(string strTable, CUIOModule Module)
        {
            CFilterGridIndex FG = MakefilterGridIndex(PlcHelper.GetAddTypeHexaBitList().Contains(Module.HEADTYPE));
            DataTable DT = _DataSet.Tables[strTable];
            Point pStart = new Point();

            foreach (CUIOBlock UIOBlock in Module.UIOBLOCKLIST)
            {
                string strBlock = UIOBlock.BLOCK;
                //string strBlock = PlcHelper.GetAddWithBlockIndex(UIOBlock.BLOCKINDEX, UIOBlock.HEADTYPE);

                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT && !PlcHelper.GetTypeListIO().Contains(UIOBlock.HEADTYPE))
                    strBlock = CUIOHelper.GetTempBlock(UIOBlock);
                if (strBlock.Contains(".00"))
                    strBlock = strBlock.Replace(".00", string.Empty);

                if (UIOBlock.HEADTYPE == PlcHelper.GetTypeOutput())
                    pStart = ValueInTableBlock(FG.BLOCK, DT, strBlock + eSplit.EXCELYELLOW);
                else
                    pStart = ValueInTableBlock(FG.BLOCK, DT, strBlock);

                if (UIOBlock.UIOHEAD != null && PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
                    DT.Rows[pStart.Y][pStart.X + 2] = UIOBlock.UIOHEAD.SYMBOL;

                for (int n = 0; n < UIOBlock.LISTUIOITEM.Count; n++)
                    ValueInTableItems(pStart.Y + n, pStart.X + 1, FG, DT, UIOBlock.LISTUIOITEM[n]);
            }

            ValueInTableBlock(FG.NETWORK, DT, Module.NETWORK == string.Empty ? eTableControl.NET : Module.NETWORK);
            ValueInTableBlock(FG.MODULECARD, DT, Module.MODULE == string.Empty ? eTableControl.MODULE : Module.MODULE);
            ValueInTableBlock(FG.INFO, DT, Module.INFO == string.Empty ? eTableControl.INFO : Module.INFO);

        }

        private void ValueInTableItems(int nRow, int nCol, CFilterGridIndex FG, DataTable DT, CUIOItem UIO)
        {
            bool bBlockNBit = true;
            bool bOutput = false;
            if (UIO.HEADTYPE == PlcHelper.GetTypeOutput())
                bOutput = true;
            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
                bBlockNBit = false;

            int nColIndex = FG.ADDRESSCOL.IndexOf(nCol);

            if (FG.ADDRESSCOL[nColIndex] == -1)
                return;

            if (FG.ADDRESSCOL.Count > 0)
            {
                if (bBlockNBit)
                {
                    DT.Rows[nRow][FG.ADDRESSCOL[nColIndex]] = UIO.ADDRESSTEMP.Replace(UIO.BLOCK, string.Empty).Replace(".", string.Empty).ToUpper();
                    DT.Rows[nRow][FG.ADDRESSCOL[nColIndex] + 1] = UIO.ADDRESSTEMP.ToUpper();
                }
                else
                {
                    DT.Rows[nRow][FG.ADDRESSCOL[nColIndex] - 1] = UIO.ADDRESSTEMP.ToUpper() + (bOutput ? eSplit.EXCELYELLOW : string.Empty);
                }
            }

            if (FG.SYMBOLNAMECOL.Count > 0 && PlcHelper._PLCMAKER != ePLC_MAKER.AB_COMMENT)
                DT.Rows[nRow][FG.SYMBOLNAMECOL[nColIndex]] = UIO.SYMBOL;
            if (FG.TAGCOL.Count > 0)
                DT.Rows[nRow][FG.TAGCOL[nColIndex]] = UIO.TAG;
            if (FG.COMMENT.Count > 0)
                DT.Rows[nRow][FG.COMMENT[nColIndex]] = UIO.COMMENT;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT && UIO.ADDRESSTEMP.StartsWith("S"))
                DT.Rows[nRow][FG.COMMENT[nColIndex]] = UIO.SYMBOL;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
            {
                DT.Rows[nRow][FG.SYMBOLNAMECOL[nColIndex] + 1] = UIO.COMMENT;
                DT.Rows[nRow][FG.SYMBOLNAMECOL[nColIndex] + 2] = UIO.DATATYPE;
                DT.Rows[nRow][FG.SYMBOLNAMECOL[nColIndex] + 3] = UIO.SPECIPER;
            }
        }

        private Point ValueInTableBlock(List<Point> lstPoint, DataTable DT, string strValue)
        {
            lstPoint.Sort(CompareFIOBlock);
            foreach (Point PT in lstPoint)
            {
                if (DT.Rows[PT.Y][PT.X].ToString() == string.Empty)
                {
                    DT.Rows[PT.Y][PT.X] = strValue;
                    return PT;
                }
            }
            return new Point(-1, -1);
        }

        private int CompareFIOBlock(Point A, Point B)
        {
            if (A == null)
            {
                if (B == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (B == null)
                    return 1;
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = A.X.CompareTo(B.X);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return A.Y.CompareTo(B.Y);
                    }
                }
            }


        }

    }
}
