using System;
using System.Collections.Generic;
using System.Text;

namespace UDM.Export
{
    public class CUIOBlock
    {
        #region Fields

        public string SHEET = string.Empty;
        public string BLOCK = string.Empty;
        public string MODULE = string.Empty;
        public string NETWORK = string.Empty;
        public string INFO = string.Empty;
        public string DATATYPE = string.Empty;
        public string HEADTYPE = string.Empty;
        public string BLOCKSPECIPER = string.Empty;  // for AB PLC
        public int BLOCKINDEX = 0;

        public bool _bSpare = false;

        public int SAMEBLOCKINDEX = 0;
        private CUIOItem _HeadUIO = null;
        private List<CUIOItem> _UIOitemList = new List<CUIOItem>();

        #endregion

        #region Constructors

        public CUIOBlock(string strHead, int nBlockIndex)
        {
            HEADTYPE = strHead;
            BLOCKINDEX = nBlockIndex;
            BLOCK = PlcHelper.GetBlock(strHead, nBlockIndex);
        }

        public CUIOBlock(string strHead, int nBlockIndex, bool bSpare, int nSameBlock)
        {
            _bSpare = bSpare;
            SAMEBLOCKINDEX = nSameBlock;
            HEADTYPE = strHead;
            BLOCKINDEX = nBlockIndex;
            BLOCK = PlcHelper.GetBlock(strHead, nBlockIndex);
        }

        public CUIOBlock(CUIOItem UIOItem)
        {
            HEADTYPE = UIOItem.HEADTYPE;
            if (!PlcHelper.GetTypeListAll().Contains(HEADTYPE))
                _bSpare = true;
            if (DATATYPE == string.Empty)
                DATATYPE = PlcHelper.GetDefaltDataType(HEADTYPE);

            BLOCKINDEX = PlcHelper.GetBlockIndex(UIOItem.BLOCK);
            BLOCK = PlcHelper.GetBlock(HEADTYPE, BLOCKINDEX);

            SHEET = UIOItem.SHEET;
            MODULE = UIOItem.MODULE;
            NETWORK = UIOItem.NETWORK;

            INFO = UIOItem.INFO;

            if (UIOItem._bHead)
                _HeadUIO = UIOItem;
            else
               LISTUIOITEM.Add(UIOItem);
        }

        public void AddEmptyUIOItem(string strDefaultSymbol)
        {
            CUIOItem UIOItem = new CUIOItem();
            UIOItem.DATATYPE = DATATYPE;
            UIOItem.SYMBOL = strDefaultSymbol;

            if (PlcHelper.GetAddTypeHexaBitList().Contains(HEADTYPE))
                UIOItem.ADDRESS = FindSpareAddHexa();
            else
                UIOItem.ADDRESS = FindSpareAdd();

            UIOItem.UpdateProperty();
            UIOItem.SHEET = SHEET;
            UIOItem.MODULE = MODULE;
            UIOItem.NETWORK = NETWORK;
            UIOItem.INFO = INFO;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                UIOItem.TAG = GetTempTag();

            _UIOitemList.Add(UIOItem);
        }

        public bool AddUIOItem(CUIOItem UIOItem)
        {
            if (UIOItem._bHead)
            {
                if (_HeadUIO == null)
                {
                    _HeadUIO = UIOItem;
                    return true;
                }
                else
                    return false;
            }

            List<CUIOItem> UIOItemList = CUIOHelper.FindUIOItem(LISTUIOITEM, UIOItem.ADDRESSTEMP);
            if (UIOItemList.Count == 0)
                _UIOitemList.Add(UIOItem);
            else
                return false;

            return true;
        }
  
      

        #endregion
      
        #region Public interface

        public List<CUIOItem> LISTUIOITEM
        {
            get { return _UIOitemList; }
        }

        public CUIOItem UIOHEAD
        {
            get { return _HeadUIO; }
            set { _HeadUIO = value; }
        }

        public int MAXITEM
        {
            get
            {
                return PlcHelper.GetBlockMaxItem(HEADTYPE);
            }
        }

        public bool ISHEXABLOCK
        {
            get
            {
                if (PlcHelper.GetAddTypeHexaBlockList().Contains(PlcHelper.GetAddHeadType(BLOCK)))
                    return true;
                else
                    return false;
            }
        }

        public string TAGINDEX
        {
            get
            {
                string strTagIndex = string.Empty;

                if (HEADTYPE == "H"
                    || (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT && PlcHelper.GetTypeListIO().Contains(HEADTYPE)))
                    strTagIndex = BLOCK.Substring(0, 5);
                else
                    strTagIndex = BLOCK.Substring(0, 3);


                return strTagIndex;
            }
        }

        public string TAGBASE
        {
            get
            {
                string strTagBase = string.Empty;
                foreach (CUIOItem UIOItem in LISTUIOITEM)
                    strTagBase = UIOItem.GetUserAddforAB();

                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS && PlcHelper.GetTypeListIO().Contains(HEADTYPE))
                {
                    if (BLOCK.Substring(1, 2) == "00")
                        strTagBase = "CNET";
                    else
                        strTagBase = string.Format("Local:{0}:{1}", Convert.ToInt32(BLOCK.Substring(1, 2)), HEADTYPE);
                }
                else if (strTagBase.Contains(".Data"))
                    strTagBase = strTagBase.Split('.')[0];
                else
                    strTagBase = TAGINDEX;

                return strTagBase;
            }
        }

        #endregion

        #region Public Methods

        public bool HasSameAddressItem()
        {
            foreach (CUIOItem UIO in _UIOitemList)
            {
                foreach (CUIOItem _UIO in _UIOitemList)
                    if (UIO != _UIO)
                        if (UIO.ADDRESS == _UIO.ADDRESS)
                            return true;
            }

            return false;
        }

        public bool RemoveUIOBlock(CUIOItem UIOItem)
        {
            return _UIOitemList.Remove(UIOItem);
        }

        public void CopyBlockProperty(CUIOBlock UIOBlockCopy)
        {
            if (UIOBlockCopy.DATATYPE == string.Empty)
                DATATYPE = PlcHelper.GetDefaltDataType(UIOBlockCopy.HEADTYPE);
            else
                DATATYPE = UIOBlockCopy.HEADTYPE;

            for (int n = 0; n < UIOBlockCopy.LISTUIOITEM.Count; n++)
            {
                LISTUIOITEM[n].SYMBOL = UIOBlockCopy.LISTUIOITEM[n].SYMBOL;
                LISTUIOITEM[n].COMMENT = UIOBlockCopy.LISTUIOITEM[n].COMMENT;
            }

            if (UIOBlockCopy._HeadUIO != null)
                MakeSpareUIOHead(UIOBlockCopy._HeadUIO);
        }

        public bool RemoveList(string UIOItemName)
        {
            List<CUIOItem> _UIOItemRemoveList = new List<CUIOItem>();

            foreach (CUIOItem UIOItem in _UIOitemList)
                if (UIOItem.UIO == UIOItemName)
                    _UIOItemRemoveList.Add(UIOItem);

            foreach (CUIOItem UIOItem in _UIOItemRemoveList)
                _UIOitemList.Remove(UIOItem);

            if (_UIOItemRemoveList.Count > 0)
                return true;
            else
                return false;
        }

        public void ClearUIOitem()
        {
            _UIOitemList.Clear();
        }

        public void UpdateModuleName(string NewName)
        {
            foreach (CUIOItem UIOItem in _UIOitemList)
                UIOItem.MODULE = NewName.Replace("\n", string.Empty).Replace("\"", string.Empty);
        }

        public void UpdateInfoName(string NewName)
        {
            foreach (CUIOItem UIOItem in _UIOitemList)
                UIOItem.INFO = NewName.Replace("\n", string.Empty).Replace("\"", string.Empty);
        }

        public void UpdateNetWorkName(string NewName)
        {
            foreach (CUIOItem UIOItem in _UIOitemList)
                UIOItem.NETWORK = NewName.Replace("\n", string.Empty).Replace("\"", string.Empty);
        }


        public void MakeSpareUIO(string strDefaultSymbol)
        {
            int nMaxUIOItemInBlock = MAXITEM;
            int nCurrentUIOItemInBlock = LISTUIOITEM.Count;

            if (nCurrentUIOItemInBlock < nMaxUIOItemInBlock)
            {
                for (int n = 0; n < nMaxUIOItemInBlock - nCurrentUIOItemInBlock; n++)
                    AddEmptyUIOItem(strDefaultSymbol);
            }
        }

        public void MakeSpareUIOHead(CUIOItem UIOItemHead)
        {
            CUIOItem UIOItem = new CUIOItem();
            UIOItem.DATATYPE = UIOItemHead.DATATYPE;
            UIOItem.SYMBOL = UIOItemHead.SYMBOL;
            UIOItem.ADDRESS = FindSpareAddHead();

            UIOItem.UpdateProperty();
            UIOItem.SHEET = UIOItemHead.SHEET;
            UIOItem.MODULE = UIOItemHead.MODULE;
            UIOItem.NETWORK = UIOItemHead.NETWORK;
            UIOItem.INFO = UIOItemHead.INFO;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                UIOItem.TAG = GetTempTag();

            _HeadUIO = UIOItem;
        }


        public bool SetAssignTag(Dictionary<string, string> DicTagBlock)
        {
            bool bOk = false;
            foreach (var who in DicTagBlock)
            {
                if (who.Key == TAGINDEX)
                {
                    SetTag(who.Value);
                    bOk = true;
                    break;
                }
            }

            if (!bOk && PlcHelper.GetTypeListIO().Contains(HEADTYPE) && PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
            {
                SetTag(TAGBASE);
                bOk = true;
            }

            return bOk;
        }

        public void SetKeyInTag(Dictionary<string, string> DicTagBlock, string strTag)
        {

            if (!DicTagBlock.ContainsKey(TAGINDEX))
            {
                if (PlcHelper.GetTypeListIO().Contains(HEADTYPE) && BLOCK.Substring(1, 2) == "00") //CNET 영역
                    SetTag(strTag);
                else
                {
                    List<string> ListTag = new List<string>();
                    foreach (var who in DicTagBlock)
                    {
                        if (who.Value.Contains("-"))
                            ListTag.Add(who.Value);
                        else
                            ListTag.Add(who.Value + "-0");
                    }

                    if (ListTag.Contains(strTag + "-0"))
                    {
                        for (int n = 1; n < 100; n++)
                        {
                            if (FindsSapreTag(ListTag, strTag, n) == null)
                            {
                                strTag = string.Format("{0}-{1}", strTag, n);
                                break;
                            }
                        }
                    }
                }
                DicTagBlock.Add(TAGINDEX, strTag);
            }

            foreach (CUIOItem UIOItem in LISTUIOITEM)
                UIOItem.TAG = strTag;
        }

        public string GetTempInfo()
        {
            if (INFO != string.Empty)
                return INFO;

            string TempInfo = string.Empty;

            foreach (CUIOItem UIOItem in LISTUIOITEM)
            {
                if (UIOItem.SYMBOL == eTableControl.SPARE)
                    continue;
                
                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    TempInfo = UIOItem.GetDefaultInfoFromComment();
                else
                    TempInfo = UIOItem.GetDefaultInfo();

                if (TempInfo != string.Empty)
                    break;
            }

            if (TempInfo == string.Empty && _HeadUIO != null)
            {
                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    TempInfo = _HeadUIO.GetDefaultInfoFromComment();
                else
                    TempInfo = _HeadUIO.GetDefaultInfo();

            }

            return TempInfo;
        }

        public string GetTempTag()
        {
            string TempTag = string.Empty;

            foreach (CUIOItem UIOItem in LISTUIOITEM)
            {
                if (UIOItem.TAG != string.Empty)
                {
                    TempTag = UIOItem.TAG;
                    break;
                }
            }
            if (TempTag == string.Empty && _HeadUIO != null)
                TempTag = _HeadUIO.TAG;

            return TempTag;
        }


        public void SetTag(string strTag)
        {
            foreach (CUIOItem UIOItem in LISTUIOITEM)
            {
                UIOItem.TAG = strTag;
            }
        }

        public void SetComment(string strComment, bool bEmptyComment)
        {
            foreach (CUIOItem UIOItem in LISTUIOITEM)
            {
                if (!bEmptyComment || UIOItem.COMMENT == string.Empty)
                    UIOItem.COMMENT = strComment;
            }
        }

        public void SetSpecifer(Dictionary<string, string> _DicTagMapping)
        {
            string strBlockIndex = string.Empty;
            string strTempTag = string.Empty;
            string strUserAdd = string.Empty;
            
            strBlockIndex = TAGINDEX;

            if (_DicTagMapping.ContainsKey(strBlockIndex))
            {
                strTempTag = _DicTagMapping[strBlockIndex];

                if (strTempTag.Contains("-") && !strTempTag.Contains("[") && !strTempTag.Contains("]")
                    && PlcHelper.RelaceNumber(strTempTag, "#").Contains("-#"))
                {
                    string strTag = strTempTag.Split('-')[0];
                    string strTagExtend = strTempTag.Split('-')[1];

                    if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE))
                        BLOCKSPECIPER = string.Format("{0}[{1}{2}].00", strTag, strTagExtend, BLOCK.Substring(3, 2));
                    else
                        BLOCKSPECIPER = string.Format("{0}[{1}{2}0]", strTag, strTagExtend, BLOCK.Substring(3, 2));
                }
                else if (HEADTYPE == "H" || (PlcHelper._PLCMAKER != ePLC_MAKER.AB_COMMENT && PlcHelper.GetTypeListIO().Contains(HEADTYPE)))
                {
                    BLOCKSPECIPER = string.Format("{0}.00", strTempTag);
                }
                else
                {
                    if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE))
                        BLOCKSPECIPER = string.Format("{0}[{1}].00", strTempTag, BLOCK.Substring(3, 2));
                    else
                        BLOCKSPECIPER = string.Format("{0}[{1}0]", strTempTag, BLOCK.Substring(3, 2));
                }
            }
            else
            {
                if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE))
                    BLOCKSPECIPER = string.Format("{0}.00", BLOCK);
                else
                    BLOCKSPECIPER = string.Format("{0}0", BLOCK);
            }

            foreach (CUIOItem UIOItem in LISTUIOITEM)
                UIOItem.SPECIPER = UIOItem.GetUserAddforAB();

            if (_HeadUIO != null)
                _HeadUIO.SPECIPER = _HeadUIO.GetUserAddforAB();
        }


        #endregion

        #region Privates Methods

        private string FindSpareAdd()
        {
            string AddressIndex = string.Empty;

            List<string> ListDot = PlcHelper.GetAddTypeDotList();
            List<string> ListHexa = PlcHelper.GetAddTypeHexaBitList();

            for (int n = 0; n < MAXITEM; n++)
                if (FindUIOItemByAddBit(n) == null)
                {
                    if (ListDot.Contains(HEADTYPE))
                    {
                        if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                            AddressIndex = string.Format(".{0}", n.ToString("00"));
                        else
                            AddressIndex = string.Format(".{0}", n);
                    }
                    else
                    {
                        AddressIndex = string.Format("{0}", n);
                    }
                    break;
                }

            return BLOCK + AddressIndex;
        }


        private string FindSpareAddHexa()
        {
            string AddressIndex = string.Empty;

            List<string> ListDot = PlcHelper.GetAddTypeDotList();
            List<string> ListHexa = PlcHelper.GetAddTypeHexaBitList();

            for (int n = 0; n < MAXITEM; n++)
                if (FindUIOItemByAddBitHexa(n) == null)
                {
                    if (ListDot.Contains(HEADTYPE))
                    {
                        AddressIndex = string.Format(".{0:X}", n);
                    }
                    else
                    {
                        AddressIndex = string.Format("{0:X}", n);
                    }
                    break;
                }

            return BLOCK + AddressIndex;
        }


        private string FindSpareAddHead()
        {
            string AddressIndex = string.Empty;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                AddressIndex = "00";
            else
                AddressIndex = "0";

            return BLOCK + AddressIndex;
        }

       

        public CUIOItem FindUIOItemByAddBit(int nBitIndex)
        {
            CUIOItem FindUIOItem = _UIOitemList.Find(delegate(CUIOItem UIOItem)
            {
                return nBitIndex == Convert.ToInt32(UIOItem.ADDRESSTEMP.Replace(UIOItem.BLOCK, string.Empty).Replace(".", string.Empty));
            });

            return FindUIOItem;
        }

        public CUIOItem FindUIOItemByAddBitHexa(int nBitIndex)
        {
            CUIOItem FindUIOItem = _UIOitemList.Find(delegate(CUIOItem UIOItem)
            {
                return nBitIndex == Convert.ToInt32(UIOItem.ADDRESSTEMP.Replace(UIOItem.BLOCK, string.Empty).Replace(".", string.Empty),16);
            });

            return FindUIOItem;
        }

        public string FindsSapreTag(List<string> ListTag, string strTag, int nIndex)
        {
            string FindTag = ListTag.Find(delegate(string Tag)
            {
                return strTag + "-" + nIndex.ToString() == Tag;
            });

            return FindTag;
        }

        #endregion

    }
}
