using System;
using System.Collections.Generic;
using System.Data;

namespace UDM.Export
{
    public class CUIOModule
    {

        #region Fields

        public string MODULE = string.Empty;
        public string NETWORK = string.Empty;
        public string INFO = string.Empty;
        public string SOLT = string.Empty;
        public string SOLTEXTEND = string.Empty;

        public string HEADTYPE = string.Empty;
        public bool bSpare = false;
        public bool bOutputModule = false;
        public bool bInputEmptyModule = false;
        public bool bMulitDevice = false;   

        private List<CUIOBlock> _UIOBlcokList = new List<CUIOBlock>();

        #endregion

        #region Constructors

        public CUIOModule(CUIOBlock UIOBlock)
        {
            MODULE = UIOBlock.MODULE;
            NETWORK = UIOBlock.NETWORK;
            INFO = UIOBlock.INFO;
            HEADTYPE = PlcHelper.GetAddHeadType(UIOBlock.BLOCK);
            AddUIOBlock(UIOBlock);
        }

        #endregion

        #region Public interface
      
        public List<CUIOBlock> UIOBLOCKLIST
        {
            get { return _UIOBlcokList; }
        }

        public bool ISNEWSHEET
        {
            get
            {
                if (_UIOBlcokList.Count == 0)
                    return false;

                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                    return false;

                int nAddress = 0;

                if (_UIOBlcokList[0].ISHEXABLOCK)
                {
                    nAddress = Convert.ToInt32(PlcHelper.GetAddressBody(_UIOBlcokList[0].BLOCK, _UIOBlcokList[0].HEADTYPE.Length), 16);
                    if (nAddress % 8 == 0)
                        return true;
                }
                else
                {
                    nAddress = Convert.ToInt32(PlcHelper.GetAddressBody(_UIOBlcokList[0].BLOCK, _UIOBlcokList[0].HEADTYPE.Length), 10);
                    if (nAddress % 10 == 0 && _UIOBlcokList[0].HEADTYPE == PlcHelper.GetTypeInput())
                        return true;
                }

                return false;
            }
        }

        public bool ISEMPTY
        {
            get
            {
                foreach (CUIOBlock UIOBlock in _UIOBlcokList)
                    if (UIOBlock.LISTUIOITEM.Count > 0 || UIOBlock.UIOHEAD != null)
                        return false;

                return true;
            }
        }

        public bool HASSAMEBLCOK
        {
            get
            {
                foreach (CUIOBlock UIOBlock in _UIOBlcokList)
                    if (UIOBlock.SAMEBLOCKINDEX > 0)
                        return true;

                return false;
            }
        }
        
        #endregion

        #region Public Methods

        public void AddUIOBlock(CUIOBlock UIOBlock)
        {
            _UIOBlcokList.Add(UIOBlock);
        }

        public void AddUIOBlock(List<CUIOBlock> UIOBlocks)
        {
            foreach (CUIOBlock UIOBlock in UIOBlocks)
            {
                _UIOBlcokList.Add(UIOBlock);
            }
        }

        public bool RemoveUIOBlock(CUIOBlock UIOBlock)
        {
            return _UIOBlcokList.Remove(UIOBlock);
        }

        public bool RemoveUIOBlock(string UIOBlockName)
        {
            List<CUIOBlock> _UIOBlockRemoveList = new List<CUIOBlock>();

            foreach (CUIOBlock UIOModule in _UIOBlcokList)
                if (UIOModule.MODULE == UIOBlockName)
                    _UIOBlockRemoveList.Add(UIOModule);

            foreach (CUIOBlock UIOModule in _UIOBlockRemoveList)
                _UIOBlcokList.Remove(UIOModule);

            if (_UIOBlockRemoveList.Count > 0)
                return true;
            else
                return false;
        }

        public void ClearUIOBlock()
        {
            _UIOBlcokList.Clear();
        }

        public List<string> GetBlockList()
        {
            List<string> blockList = new List<string>();
            foreach (CUIOBlock UIOBlock in _UIOBlcokList)
                foreach (CUIOItem UIOItem in UIOBlock.LISTUIOITEM)
                if (!blockList.Contains(UIOItem.BLOCK))
                    blockList.Add(UIOItem.BLOCK);

            return blockList;
        }

        public void SetModuleName(Dictionary<int, string> dicIOTYPE)
        {
            if (PlcHelper.GetAddIOMaxSize() > _UIOBlcokList[0].BLOCKINDEX)
                if (dicIOTYPE.ContainsKey(_UIOBlcokList[0].BLOCKINDEX))
                {
                    if (dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Contains(";"))
                    {
                        if (HEADTYPE == PlcHelper.GetTypeInput())
                            MODULE = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Split(';')[0];
                        else
                            MODULE = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Split(';')[1];
                    }
                    else
                        MODULE = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX];
                }
        }

        public void SetModuleInfo(Dictionary<int, string> dicIOTYPE)
        {
            if (bMulitDevice)
            {
                if (INFO == string.Empty)
                    MakeTempInfo();
                return;
            }

            if (PlcHelper.GetAddIOMaxSize() > _UIOBlcokList[0].BLOCKINDEX)
                if (dicIOTYPE.ContainsKey(_UIOBlcokList[0].BLOCKINDEX))
                {
                    if (dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Contains(";"))
                    {
                        if (HEADTYPE == PlcHelper.GetTypeInput())
                            INFO = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Split(';')[0];
                        else
                            INFO = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX].Split(';')[1];
                    }
                    else
                        INFO = dicIOTYPE[_UIOBlcokList[0].BLOCKINDEX];
                }

            if (INFO == string.Empty)
                MakeTempInfo();
        }

        public void SetModuleSolt(DataTable DT)
        {
            if (DT.Rows.Count <= _UIOBlcokList[0].BLOCKINDEX)
                return;

            SOLT = DT.Rows[_UIOBlcokList[0].BLOCKINDEX][eFrmModule.SLOT].ToString();

            if (_UIOBlcokList.Count == 2)
                SOLTEXTEND =   DT.Rows[_UIOBlcokList[1].BLOCKINDEX][eFrmModule.SLOT].ToString();
        }

        public void SetDummyInfo(DataTable DT)
        {
            INFO = DT.Rows[_UIOBlcokList[0].BLOCKINDEX][_UIOBlcokList[0].HEADTYPE].ToString();

            if (INFO == string.Empty)
                MakeTempInfo();
        }

        public void MakeTempInfo()
        {
            string TempInfo = string.Empty;

            foreach (CUIOBlock UIOBlock in _UIOBlcokList)
            {
                if (TempInfo != string.Empty)
                    break;

                TempInfo = UIOBlock.GetTempInfo();
            }

            INFO = TempInfo;
        }

        public string GetDefaultSheet()
        {
            string strTempSheet = string.Empty;

            foreach (CUIOBlock UIOBlock in _UIOBlcokList)
            {
                if (UIOBlock.SHEET != string.Empty)
                {
                    strTempSheet = UIOBlock.SHEET;
                    break;
                }
            }

            return strTempSheet;
        }

        public string GetUserTag()
        {
            string strUserTag = string.Empty;

            foreach (CUIOBlock UIOBlock in _UIOBlcokList)
            {
                if (CUIOHelper.GetUsedTag(UIOBlock.BLOCKSPECIPER) != string.Empty)
                {
                    strUserTag = UIOBlock.BLOCKSPECIPER;
                    break;
                }
            }

            return strUserTag;
        }
       
        #endregion

        #region Privates Methods

        private int GetSameBlockCount(string UIOBlockName)
        {
            int nSameBlock = 0;

            foreach (CUIOBlock UIOBlock in _UIOBlcokList)
                if (UIOBlockName == UIOBlock.BLOCK)
                    nSameBlock++;

            return nSameBlock;
        }

        #endregion


    }
}