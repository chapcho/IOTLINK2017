using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace UDM.Export
{
    public class CUIOSet
    {
        #region Fields

        private List<CUIOItem> _UIOItemList = new List<CUIOItem>();
        private List<CUIOBlock> _UIOBlockList = new List<CUIOBlock>();
        private List<CUIOModule> _UIOModuleList = new List<CUIOModule>();
        public Dictionary<string, string> _DicTagMapping = new Dictionary<string, string>();
        public int _MaxBlcokInModule = 2;


        #endregion

        #region Initialize/Dispose

        public CUIOSet(List<CUIOItem> UIOItemList)
        {
            _UIOItemList = UIOItemList;


            CUIOHelper.SortByUIO(_UIOItemList);

            CreateUIOBlockList(_UIOItemList);

            UpadteSameUIOBlockName();
        }

        public void Dispose()
        {
            _UIOItemList.Clear();
            _UIOBlockList.Clear();
            _UIOModuleList.Clear();
        }

        #endregion

        #region Public interface

        public List<CUIOItem> UIOITEMLIST
        {
            get { return _UIOItemList; }
        }

        public List<CUIOBlock> UIOBLOCKLIST
        {
            get { return _UIOBlockList; }
        }

        public List<CUIOModule> UIOMODULELIST
        {
            get { return _UIOModuleList; }
        }

        #endregion

        #region Public Methods

        public CUIOBlock FindBlock(string strBlock)
        {
            CUIOBlock FindUIOBlock = _UIOBlockList.Find(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock;
            });

            return FindUIOBlock;
        }

        public CUIOBlock FindBlockUnique(string strBlock)
        {
            CUIOBlock FindUIOBlock = _UIOBlockList.Find(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock && UIOBlock.SAMEBLOCKINDEX == 0 && !UIOBlock._bSpare;
            });

            return FindUIOBlock;
        }

        public CUIOItem FindUIOItem(int strAddressIndex)
        {
            CUIOItem FindUIO = _UIOItemList.Find(delegate(CUIOItem UIOItem)
            {
                return UIOItem.ADDRESSINDEX == strAddressIndex;
            });

            return FindUIO;
        }

        public List<CUIOBlock> FindBlockAll(string strBlock)
        {
            List<CUIOBlock> UIOItemList = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock;
            });

            return UIOItemList;
        }

        public List<CUIOBlock> FindBlockAllWithDataType(string strBlock, string strDataType)
        {
            List<CUIOBlock> UIOItemList = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock && UIOBlock.DATATYPE == strDataType;
            });

            return UIOItemList;
        }

        public List<CUIOBlock> FindBlockAllWithHeadType(string strHeadType)
        {
            List<CUIOBlock> FindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.HEADTYPE == strHeadType;
            });

            return FindUIOBlock;
        }

        public List<CUIOItem> FindUIOItemAllWithHeadType(string strHeadType)
        {
            List<CUIOItem> FindUIOItem = _UIOItemList.FindAll(delegate(CUIOItem UIOItem)
            {
                return UIOItem.HEADTYPE == strHeadType;
            });

            return FindUIOItem;
        }

        public List<CUIOItem> FindUIOItemByBlockRange(string strHeadType, int nStart, int nEnd)
        {
            List<CUIOItem> UIOItemList = _UIOItemList.FindAll(delegate(CUIOItem UIOItem)
            {
                return (nStart <= UIOItem.ADDRESSINDEX && nEnd >=UIOItem.ADDRESSINDEX)
                    && UIOItem.HEADTYPE == strHeadType;
            });

            return UIOItemList;
        }

        public void RemoveBlock(string strBlock)
        {
            _UIOBlockList.RemoveAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock;
            });
        }

        public List<CUIOBlock> FindBlockWithSheet(string strBlock, string strHeadType, string strSheet)
        {
            List<CUIOBlock> FindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock && UIOBlock.HEADTYPE == strHeadType && UIOBlock.SHEET == strSheet;
            });

            return FindUIOBlock;
        }


        public List<CUIOBlock> FindBlockWithInfo(string strBlock, string strDataType, string strInfo, string strLevel1)
        {
            List<CUIOBlock> FindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return UIOBlock.BLOCK == strBlock
                    && UIOBlock.DATATYPE == strDataType
                        && UIOBlock.GetTempInfo() == strInfo;
            });

            if (FindUIOBlock.Count == 0)
            {
                FindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                {
                    return UIOBlock.BLOCK == strBlock
                        && UIOBlock.DATATYPE == strDataType
                    && UIOBlock.GetTempInfo().Contains(strLevel1);
                });
            }

            return FindUIOBlock;
        }


        public void MakeSpareBlock(eExcelListType strListType)
        {
            List<string> ListHeadType = new List<string>();
            if (strListType == eExcelListType.IO)
            {
                SetSpareBlockIOList(PlcHelper.GetTypeInput());
            }
            else if (strListType == eExcelListType.DUMMY)
            {
                ListHeadType = PlcHelper.GetTypeListDummy();
                foreach (string strHeadType in ListHeadType)
                    SetSpareBlockDummyList(strHeadType);
            }
            else if (strListType == eExcelListType.LINK)
            {
                ListHeadType = PlcHelper.GetTypeListLink();
                foreach (string strHeadType in ListHeadType)
                    SetSpareBlockDummyList(strHeadType);
            }
            else if (strListType == eExcelListType.TIMECOUNT)
            {
                ListHeadType = PlcHelper.GetTypeListTimerCounter();
                foreach (string strHeadType in ListHeadType)
                    SetSpareBlockDummyList(strHeadType);
            }
        }

        public void MakeModuleBlock(eExcelListType strListType)
        {
            CUIOHelper.SortSameBlockList(_UIOBlockList);

            if (strListType == eExcelListType.IO)
            {
                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    CreateUIOModuleListByAB();
                else
                {
                    CreateUIOModuleListByAddress();

                    CreateUIOModuleListBySameBlock();
                }
            }
            else
                CreateUIOModuleList();
        }

        public void CreateUIOModuleList()
        {
            CUIOModule UIOModule = null;

            foreach (CUIOBlock UIOBlock in _UIOBlockList)
            {
                UIOModule = new CUIOModule(UIOBlock);
                if (!MergeUIOModule(UIOModule))
                {
                    _UIOModuleList.Add(UIOModule);
                }
            }
        }

        public void CreateUIOModuleListByAB()
        {
            int nMaxCount = GetMaxIO();
            for (int BlcokIndex = 0; BlcokIndex <= nMaxCount; BlcokIndex++)
            {
                List<CUIOBlock> FindUIOBlockList = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                {
                    return UIOBlock.BLOCKINDEX == BlcokIndex
                        && UIOBlock.LISTUIOITEM.Count != 0
                        && UIOBlock.SAMEBLOCKINDEX == 0;
                });

                CUIOBlock BlockTempInput = new CUIOBlock(PlcHelper.GetTypeInput(), BlcokIndex);
                CUIOBlock BlockTempOutput = new CUIOBlock(PlcHelper.GetTypeOutput(), BlcokIndex);

                foreach (CUIOBlock UIOBlock in FindUIOBlockList)
                {
                    if (UIOBlock.BLOCK == BlockTempInput.BLOCK)
                        BlockTempInput = UIOBlock;
                    if (UIOBlock.BLOCK == BlockTempOutput.BLOCK)
                        BlockTempOutput = UIOBlock;
                }

                CUIOModule UIOModule = new CUIOModule(BlockTempInput);
                if (FindUIOBlockList.Count == 0)
                    UIOModule.bSpare = true;

                UIOModule.AddUIOBlock(BlockTempOutput);
                _UIOModuleList.Add(UIOModule);
            }
        }


        public void CreateUIOModuleListBySameBlock()
        {
            int nMaxCount = GetMaxIO();
            for (int BlcokIndex = 0; BlcokIndex <= nMaxCount; BlcokIndex++)
            {
                List<CUIOBlock> FindUIOBlockList = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                {
                    return UIOBlock.BLOCKINDEX == BlcokIndex
                        && UIOBlock.LISTUIOITEM.Count != 0
                        && UIOBlock.SAMEBLOCKINDEX > 0;
                });

                if (FindUIOBlockList.Count == 0)
                    continue;

                for (int nSAMEBLOCKINDEX = 1; nSAMEBLOCKINDEX < 10; nSAMEBLOCKINDEX++)
                {
                    List<CUIOBlock> FindSameBlock = FindUIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                    {
                        return UIOBlock.SAMEBLOCKINDEX == nSAMEBLOCKINDEX;
                    });

                    if (FindSameBlock.Count > 0)
                    {
                        CUIOBlock BlockTempInput = new CUIOBlock(PlcHelper.GetTypeInput(), BlcokIndex);
                        BlockTempInput.SAMEBLOCKINDEX = nSAMEBLOCKINDEX;
                        CUIOBlock BlockTempOutput = new CUIOBlock(PlcHelper.GetTypeOutput(), BlcokIndex);
                        BlockTempOutput.SAMEBLOCKINDEX = nSAMEBLOCKINDEX;

                        foreach (CUIOBlock UIOBlock in FindSameBlock)
                        {
                            if (UIOBlock.BLOCK == BlockTempInput.BLOCK)
                                BlockTempInput = UIOBlock;
                            if (UIOBlock.BLOCK == BlockTempOutput.BLOCK)
                                BlockTempOutput = UIOBlock;
                        }

                        CUIOModule UIOModule = new CUIOModule(BlockTempInput);
                        if (FindUIOBlockList.Count == 0)
                            UIOModule.bSpare = true;

                        UIOModule.AddUIOBlock(BlockTempOutput);
                        _UIOModuleList.Add(UIOModule);
                    }
                }
            }
        }

        public void AddModules(List<CUIOBlock> BlockList, int strAddressIndexA, int strAddressIndexB)
        {
            CUIOModule UIOModule1 = null;
            CUIOModule UIOModule2 = null;
            CUIOBlock BlockTemp1 = new CUIOBlock(PlcHelper.GetTypeInput(), strAddressIndexA);
            CUIOBlock BlockTemp2 = new CUIOBlock(PlcHelper.GetTypeInput(), strAddressIndexB);
            CUIOBlock BlockTemp3 = new CUIOBlock(PlcHelper.GetTypeOutput(), strAddressIndexA);
            CUIOBlock BlockTemp4 = new CUIOBlock(PlcHelper.GetTypeOutput(), strAddressIndexB);
            BlockTemp1._bSpare = true;
            BlockTemp2._bSpare = true;
            BlockTemp3._bSpare = true;
            BlockTemp4._bSpare = true;

            foreach (CUIOBlock UIOBlock in BlockList)
            {
                if (UIOBlock.BLOCK == BlockTemp1.BLOCK)
                    BlockTemp1 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTemp2.BLOCK)
                    BlockTemp2 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTemp3.BLOCK)
                    BlockTemp3 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTemp4.BLOCK)
                    BlockTemp4 = UIOBlock;
            }

            if (BlockTemp2._bSpare && BlockTemp3._bSpare && !BlockTemp4._bSpare)
            {
                UIOModule1 = new CUIOModule(BlockTemp1);
                UIOModule1.AddUIOBlock(BlockTemp4);
                _UIOModuleList.Add(UIOModule1);
            }
            else
            {
                UIOModule1 = new CUIOModule(BlockTemp1);
                UIOModule1.AddUIOBlock(BlockTemp2);
                _UIOModuleList.Add(UIOModule1);

                UIOModule2 = new CUIOModule(BlockTemp3);
                UIOModule2.bSpare = true;

                UIOModule2.AddUIOBlock(BlockTemp4);
                _UIOModuleList.Add(UIOModule2);

                if (BlockTemp1._bSpare && BlockTemp2._bSpare && !(BlockTemp3._bSpare && BlockTemp2._bSpare))
                {
                    UIOModule1.bSpare = true;
                    UIOModule2.bSpare = false;

                    UIOModule1.bInputEmptyModule = true;
                    UIOModule2.bOutputModule = true;
                }
            }
        }

        public void CreateUIOModuleListByAddress()
        {
            int nAddressIndexA = 0;
            int nAddressIndexB = 0;

            int nMaxCount = GetMaxIO();
            for (int AddressIndex = 0; AddressIndex <= nMaxCount; AddressIndex++)
            {
                nAddressIndexA = AddressIndex;
                nAddressIndexB = AddressIndex + 1;
                List<CUIOBlock> FindUIOBlockList = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                {
                    return (UIOBlock.BLOCKINDEX == nAddressIndexA
                        || UIOBlock.BLOCKINDEX == nAddressIndexB)
                        && UIOBlock.LISTUIOITEM.Count != 0
                        && UIOBlock.SAMEBLOCKINDEX == 0;
                });

                AddModules(FindUIOBlockList, nAddressIndexA, nAddressIndexB);

                AddressIndex++;
            }
        }

        private int GetNextModuleStartIndex(int nStart)
        {
            int nModuleStart = nStart;

            List<CUIOBlock> lstFindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
            {
                return (UIOBlock.BLOCKINDEX == nStart
                || UIOBlock.BLOCKINDEX == nStart + 1)
                    && UIOBlock.LISTUIOITEM.Count != 0
                    && UIOBlock.SAMEBLOCKINDEX == 0;
            });

            if (lstFindUIOBlock.Count == 0)
            {
                nModuleStart += 2;
            }

            return nModuleStart;
        }

        public void CreateUIOModuleListByAddressSiemens(int nStartBlcok, int nSameBlock)
        {
            int nMaxCount = GetMaxIO();

            int nAddressIndexA = 0;
            int nAddressIndexB = 0;
            int nAddressIndexC = 0;
            int nAddressIndexD = 0;
            
            List<CUIOBlock> lstFindUIOBlock = new List<CUIOBlock>();

            for (int nBlockIndex = nStartBlcok; nBlockIndex <= nMaxCount; )
            {
                for (int n = 0; n < 5; n++)
                {
                    nBlockIndex = GetNextModuleStartIndex(nBlockIndex);
                    if (nBlockIndex % 10 == 0)
                        break;
                }

                nAddressIndexA = nBlockIndex;
                nAddressIndexB = nBlockIndex + 1;
                nAddressIndexC = nBlockIndex + 2;
                nAddressIndexD = nBlockIndex + 3;

                lstFindUIOBlock = _UIOBlockList.FindAll(delegate(CUIOBlock UIOBlock)
                {
                    return (UIOBlock.BLOCKINDEX == nAddressIndexA
                        || UIOBlock.BLOCKINDEX == nAddressIndexB
                        || UIOBlock.BLOCKINDEX == nAddressIndexC
                        || UIOBlock.BLOCKINDEX == nAddressIndexD)
                        && UIOBlock.LISTUIOITEM.Count != 0
                        && UIOBlock.SAMEBLOCKINDEX == nSameBlock;
                });

                if (lstFindUIOBlock.Count == 0)
                {
                    nBlockIndex += 4;
                    continue;
                }
                else
                    nBlockIndex += 4;


                AddModulesforSiemens(lstFindUIOBlock, nAddressIndexA, nAddressIndexB, nAddressIndexC, nAddressIndexD, nSameBlock);
            }
        }

        private void AddModulesforSiemens(List<CUIOBlock> BlockList, int nAddressIndexA, int nAddressIndexB,  int nAddressIndexC,  int nAddressIndexD, int nSameBlock) 
        {
            string sInputHead = PlcHelper.GetTypeInput();
            string sOutputHead = PlcHelper.GetTypeOutput();
            bool bMulti = nSameBlock != 0 ? true : false;

            CUIOBlock BlockTempInput1 = new CUIOBlock(sInputHead, nAddressIndexA, true, nSameBlock);
            CUIOBlock BlockTempInput2 = new CUIOBlock(sInputHead, nAddressIndexB, true, nSameBlock);
            CUIOBlock BlockTempInput3 = new CUIOBlock(sInputHead, nAddressIndexC, true, nSameBlock);
            CUIOBlock BlockTempInput4 = new CUIOBlock(sInputHead, nAddressIndexD, true, nSameBlock);
            CUIOBlock BlockTempOutput1 = new CUIOBlock(sOutputHead, nAddressIndexA, true, nSameBlock);
            CUIOBlock BlockTempOutput2 = new CUIOBlock(sOutputHead, nAddressIndexB, true, nSameBlock);
            CUIOBlock BlockTempOutput3 = new CUIOBlock(sOutputHead, nAddressIndexC, true, nSameBlock);
            CUIOBlock BlockTempOutput4 = new CUIOBlock(sOutputHead, nAddressIndexD, true, nSameBlock);

            foreach (CUIOBlock UIOBlock in BlockList)
            {
                if (UIOBlock.BLOCK == BlockTempInput1.BLOCK)
                    BlockTempInput1 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempInput2.BLOCK)
                    BlockTempInput2 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempInput3.BLOCK)
                    BlockTempInput3 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempInput4.BLOCK)
                    BlockTempInput4 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempOutput1.BLOCK)
                    BlockTempOutput1 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempOutput2.BLOCK)
                    BlockTempOutput2 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempOutput3.BLOCK)
                    BlockTempOutput3 = UIOBlock;
                if (UIOBlock.BLOCK == BlockTempOutput4.BLOCK)
                    BlockTempOutput4 = UIOBlock;
            }

            CUIOModule UIOModule1 = new CUIOModule(BlockTempInput1);
            UIOModule1.AddUIOBlock(BlockTempInput2);
            UIOModule1.AddUIOBlock(BlockTempInput3);
            UIOModule1.AddUIOBlock(BlockTempInput4);
            UIOModule1.bMulitDevice = bMulti;
            CUIOModule UIOModule2 = new CUIOModule(BlockTempOutput1);
            UIOModule2.AddUIOBlock(BlockTempOutput2);
            UIOModule2.AddUIOBlock(BlockTempOutput3);
            UIOModule2.AddUIOBlock(BlockTempOutput4);
            UIOModule2.bMulitDevice = bMulti;

            if (UIOModule1.ISEMPTY && !UIOModule2.ISEMPTY)
            {
                UIOModule1.UIOBLOCKLIST[0].MakeSpareUIO(string.Empty);
                UIOModule1.UIOBLOCKLIST[1].MakeSpareUIO(string.Empty);
                UIOModule1.UIOBLOCKLIST[2].MakeSpareUIO(string.Empty);
                UIOModule1.UIOBLOCKLIST[3].MakeSpareUIO(string.Empty);
            }
            else if (!UIOModule1.ISEMPTY && UIOModule2.ISEMPTY)
            {
                UIOModule2.UIOBLOCKLIST[0].MakeSpareUIO(string.Empty);
                UIOModule2.UIOBLOCKLIST[1].MakeSpareUIO(string.Empty);
                UIOModule2.UIOBLOCKLIST[2].MakeSpareUIO(string.Empty);
                UIOModule2.UIOBLOCKLIST[3].MakeSpareUIO(string.Empty);
            }

            _UIOModuleList.Add(UIOModule1);
            _UIOModuleList.Add(UIOModule2);
        }

        public void MakeSpeciferList()
        {
            _DicTagMapping.Clear();

            string strTempTag = string.Empty;
            string strBlockIndex = string.Empty;
            foreach (CUIOBlock UIOBlock in _UIOBlockList)
            {
                strTempTag = UIOBlock.GetTempTag();
                if (strTempTag != string.Empty)
                {
                    strBlockIndex = UIOBlock.TAGINDEX;

                    if (!_DicTagMapping.ContainsKey(strBlockIndex))
                    {
                        _DicTagMapping.Add(strBlockIndex, strTempTag);
                    }
                }
            }
        }

        #endregion

        #region Privates Methods

        private bool MergeUIOModule(CUIOModule UIOModule)
        {
            foreach (CUIOModule UIOModuleTemp in _UIOModuleList)
            {
                if (IsSameModule(UIOModule, UIOModuleTemp))
                {
                    UIOModuleTemp.AddUIOBlock(UIOModule.UIOBLOCKLIST);
                    return true;
                }
            }
            return false;
        }

        public void UpadteSameUIOBlockName()
        {
            int nSameBlock = 0;
            foreach (CUIOBlock UIOBlock in _UIOBlockList)
            {
                nSameBlock = 0;
                List<CUIOBlock> ListUIOBlock = FindBlockAllWithDataType(UIOBlock.BLOCK, UIOBlock.DATATYPE);
                CUIOHelper.SortBlockListByUIOCount(ListUIOBlock, false);

                foreach (CUIOBlock SameBlockItem in ListUIOBlock)
                    SameBlockItem.SAMEBLOCKINDEX = nSameBlock++;
            }

            CUIOHelper.SortSameBlockList(_UIOBlockList);
        }

        private void SetSpareBlockIOList(string strType)
        {
            int nMaxCount = GetMaxIO();
            
            string strAddress = string.Empty;
            CUIOBlock UIOBlockTemp = null;

            for (int AddressIndex = 0; AddressIndex <= nMaxCount; AddressIndex++)
            {
                UIOBlockTemp = new CUIOBlock(strType, AddressIndex);
                UIOBlockTemp._bSpare = true;

                CUIOBlock FindUIOBlock = FindBlock(UIOBlockTemp.BLOCK);

                if (FindUIOBlock == null)
                {
                    _UIOBlockList.Add(UIOBlockTemp);
                }
            }
        }

   
        private void SetSpareBlockDummyList(string strType)
        {
            int nMaxCount = GetMaxDummy(strType);

            List<string> ListBlockName = new List<string>();
            foreach (CUIOBlock UIOBlock in _UIOBlockList)
            {
                ListBlockName.Add(UIOBlock.BLOCK);
            }

            for (int AddressIndex = 0; AddressIndex <= nMaxCount; AddressIndex++)
            {
                CUIOBlock UIOBlockTemp = new CUIOBlock(strType, AddressIndex);

                if (!ListBlockName.Contains(UIOBlockTemp.BLOCK))
                    _UIOBlockList.Add(UIOBlockTemp);
            }
        }

        private int GetMaxIO()
        {
            int nMaxCount = 0;

            foreach (string strHeadType in PlcHelper.GetTypeListIO())
            {
                if (nMaxCount == PlcHelper.GetAddIOMaxExtendSize())
                    return nMaxCount;

                foreach (CUIOBlock UIOBlock in _UIOBlockList)
                {
                    if (UIOBlock.HEADTYPE == strHeadType)
                    {
                        if (_UIOBlockList[_UIOBlockList.Count - 1].BLOCKINDEX > PlcHelper.GetAddDummyMaxSize())
                            nMaxCount = PlcHelper.GetAddIOMaxExtendSize();
                        else
                            nMaxCount = PlcHelper.GetAddIOMaxSize();
                        break;
                    }
                }
            }
            return nMaxCount;
        }

        private int GetMaxDummy(string strType)
        {
            int nMaxCount = 0;
            foreach (CUIOBlock UIOBlock in _UIOBlockList)
            {
                if (UIOBlock.HEADTYPE == strType)
                {
                    if (_UIOBlockList[_UIOBlockList.Count - 1].BLOCKINDEX > PlcHelper.GetAddDummyMaxSize())
                        nMaxCount = PlcHelper.GetAddDummyMaxExtendSize();
                    else
                        nMaxCount = PlcHelper.GetAddDummyMaxSize();
                    break;
                }
            }
            return nMaxCount;
        }

        private bool IsSameModule(CUIOModule UIOModule, CUIOModule UIOModuleTemp)
        {
            if (UIOModule.HEADTYPE != UIOModuleTemp.HEADTYPE ||
                UIOModule.UIOBLOCKLIST.Count + UIOModuleTemp.UIOBLOCKLIST.Count > _MaxBlcokInModule)
                return false;

            return true;
        }


        private void CreateNewBlock(CUIOItem UIOItem)
        {
            List<CUIOBlock> ListBlockFind = FindBlockWithSheet(UIOItem.BLOCK, UIOItem.HEADTYPE, UIOItem.SHEET);

            foreach (CUIOBlock FindUIOBlock in ListBlockFind)
            {
                if (FindUIOBlock.AddUIOItem(UIOItem))
                    return;
            }

            CUIOBlock UIOBlock = new CUIOBlock(UIOItem);
            _UIOBlockList.Add(UIOBlock);
        }

        public void CreateUIOBlockList(List<CUIOItem> UIOItemList)
        {
            List<string> ListRedundancyAddress = GetRedundancyUIOItem(UIOItemList);
            List<CUIOItem> ListRedundancyUIOItem = new List<CUIOItem>();

            CUIOBlock UIOBlockNonAddress = new CUIOBlock("EMPTY", 0);
            UIOBlockNonAddress._bSpare = true;

            foreach (CUIOItem UIOItem in UIOItemList)
            {
                if (ListRedundancyAddress.Contains(UIOItem.ADDRESSTEMP))
                {
                    ListRedundancyUIOItem.Add(UIOItem);
                    continue;
                }

                CreateNewBlock(UIOItem);
            }

            if (UIOBlockNonAddress.LISTUIOITEM.Count > 0)
                _UIOBlockList.Add(UIOBlockNonAddress);
            if (ListRedundancyUIOItem.Count > 0)
                SetRedundancyUIOItem(ListRedundancyUIOItem);
        }


        private List<string> GetRedundancyUIOItem(List<CUIOItem> ListUIOItem)
        {
            List<string> lstAdress = new List<string>();
            Dictionary<string, CUIOItem> DicAddress = new Dictionary<string, CUIOItem>();
            Dictionary<string, CUIOItem> DicRedundancy = new Dictionary<string, CUIOItem>();
            foreach (CUIOItem UIOItem in ListUIOItem)
            {
                if (!DicAddress.ContainsKey(UIOItem.ADDRESSTEMP))
                    DicAddress.Add(UIOItem.ADDRESSTEMP, UIOItem);
                else if (!DicRedundancy.ContainsKey(UIOItem.ADDRESSTEMP))
                    DicRedundancy.Add(UIOItem.ADDRESSTEMP, UIOItem);

            }

            foreach (string sAddress in DicRedundancy.Keys)
                lstAdress.Add(sAddress);

            return lstAdress;
        }


        private void SetRedundancyUIOItem(List<CUIOItem> ListUIOItem)
        {
            List<CUIOItem> ListUnmatchUIOItem = new List<CUIOItem>();
            foreach (CUIOItem UIOItem in ListUIOItem)
            {
                string strDefaultInfo = UIOItem.GetDefaultInfo();
                List<CUIOBlock> ListBlockFind = FindBlockWithInfo(UIOItem.BLOCK, UIOItem.DATATYPE, strDefaultInfo, UIOItem.ListLevel[0]);

                if (ListBlockFind.Count == 0)
                {
                    ListUnmatchUIOItem.Add(UIOItem);
                    continue;
                }
                    
                bool bSuccessAddUIO = false;
                foreach (CUIOBlock FindUIOBlock in ListBlockFind)
                {
                    if (FindUIOBlock.AddUIOItem(UIOItem))
                    {
                        bSuccessAddUIO = true;
                        break;
                    }
                }

                if (!bSuccessAddUIO)
                    ListUnmatchUIOItem.Add(UIOItem);
            }

            foreach (CUIOItem UIOItem in ListUnmatchUIOItem)
                CreateNewBlock(UIOItem);
        }

        public void MakeSpareUIO(bool bSkipSameBlock)
        {
            foreach (CUIOBlock UIOBlock in UIOBLOCKLIST)
            {
                if (bSkipSameBlock && UIOBlock.SAMEBLOCKINDEX > 0)
                    continue;

                if (!UIOBlock._bSpare)
                    UIOBlock.MakeSpareUIO(string.Empty);

                CUIOHelper.SortByAddress(UIOBlock.LISTUIOITEM);
            }
        }

        #endregion
    }
}
