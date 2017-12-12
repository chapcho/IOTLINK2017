using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using UDM.General;

namespace UDM.Export
{
    public class CUIOItem
    {

        #region Fields

        public string ID = string.Empty;
        public string UIO = string.Empty;
        public string SYMBOL = string.Empty;
        public string ADDRESS = string.Empty;
        public string ADDRESSTEMP = string.Empty;
        public string DATATYPE = string.Empty;
        public string HEADTYPE = string.Empty;
        public string TAG = string.Empty;
        public string SPECIPER = string.Empty;  //for AB PLC
        public string SHEET = string.Empty;
        public string BLOCK = string.Empty;
        public string NETWORK = string.Empty;
        public string MODULE = string.Empty;
        public string INFO = string.Empty;
        public string COMMENT = string.Empty;
        public string UPDATETIME = string.Empty;
        public string GROUP = string.Empty;

        public List<string> ListLevel = new List<string>();


        public int ADDRESSINDEX = 0;
        public bool _bSkipEPlan = false;
        public bool _bHead = false;
        public bool _bBaseTag = false;
        public bool _bNotUsedLogic = false;

        #endregion

        #region Constructors

        public CUIOItem()
        {
            UPDATETIME = DateTime.Now.ToString();

            for (int n = 0; n < 8; n++)
                ListLevel.Add(string.Empty);
        }

        #endregion

        #region Public Methods

        public string[] GetValueArray()
        {
            List<string> ListUIOValue = new List<string>();

            ListUIOValue.Add("ID");
            ListUIOValue.Add(UIO);
            ListUIOValue.Add(SYMBOL);
            ListUIOValue.Add(TAG);
            ListUIOValue.Add(ADDRESS);

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS)
                ListUIOValue.Add(SPECIPER);
            else
                ListUIOValue.Add(BLOCK);

            ListUIOValue.Add(DATATYPE);
            ListUIOValue.Add(COMMENT);
            ListUIOValue.Add(SHEET);
            ListUIOValue.Add(UPDATETIME);

            for (int n = 0; n < ListLevel.Count; n++)
                ListUIOValue.Add(ListLevel[n]);

            ListUIOValue.Add(HEADTYPE);

            return ListUIOValue.ToArray();
        }

        public void RemoveCRLF()
        {
            this.SYMBOL = SYMBOL.Replace("\n", string.Empty);
            this.UIO = UIO.Replace("\n", string.Empty);
            this.ADDRESS = ADDRESS.Replace("\n", string.Empty);
            this.ADDRESSTEMP = ADDRESSTEMP.Replace("\n", string.Empty);
            this.DATATYPE = DATATYPE.Replace("\n", string.Empty);
            this.TAG = TAG.Replace("\n", string.Empty);
            this.SHEET = SHEET.Replace("\n", string.Empty);

            this.BLOCK = BLOCK.Replace("\n", string.Empty);
            this.NETWORK = NETWORK.Replace("\n", string.Empty);
            this.MODULE = MODULE.Replace("\n", string.Empty);
            this.INFO = INFO.Replace("\n", string.Empty);
            this.COMMENT = COMMENT.Replace("\n", string.Empty);
        }

        public void UpdateProperty()
        {
            try
            {
                if (ADDRESS == string.Empty)
                    return;

                HEADTYPE = PlcHelper.GetAddHeadType(ADDRESS);
                
                if (HEADTYPE == string.Empty)
                    return;

                if (DATATYPE == string.Empty)
                    DATATYPE = PlcHelper.GetDefaltDataType(HEADTYPE);

                if (PlcHelper._PLCMAKER == ePLC_MAKER.MITSUBISHI_WORKS2)
                {
                    if (DATATYPE == PlcHelper.GetAddSymbolType(eADDRESS_DATATYPE.BIT) && !ADDRESS.Contains(eModelRow.ADDRESSSPLIT))
                        DATATYPE = PlcHelper.GetAddSymbolType(eADDRESS_DATATYPE.DWORD_UNSIGNED);
                }
                else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                {

                    if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE) && !ADDRESS.Contains(eModelRow.ADDRESSSPLIT))
                    {
                        DATATYPE = PlcHelper.GetAddSymbolType(eADDRESS_DATATYPE.DWORD_UNSIGNED);
                        _bHead = true;
                    }
                }

                if ((PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS || PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT) && SPECIPER == string.Empty)
                    SPECIPER = GetUserAddforAB();

                ADDRESSINDEX = PlcHelper.GetAddIndex(ADDRESS, DATATYPE);
                ADDRESSTEMP = PlcHelper.GetAddTemp(HEADTYPE, ADDRESSINDEX, DATATYPE);
                BLOCK = PlcHelper.GetAddBlock(ADDRESSTEMP);
                SplitLevel(false);
                INFO = GetDefaultInfo();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, ADDRESS); error.Data.Clear();
            }
        }

        public void SetModuleName(Dictionary<int, string> dicIOTYPE)
        {
            try
            {
                if (BLOCK != string.Empty)
                    if (PlcHelper.GetAddIOMaxSize() > PlcHelper.GetBlockIndex(BLOCK))
                        if (dicIOTYPE.ContainsKey(PlcHelper.GetBlockIndex(BLOCK)))
                        {
                            if (dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Contains(";"))
                            {
                                if (HEADTYPE == PlcHelper.GetTypeInput())
                                    MODULE = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Split(';')[0];
                                else
                                    MODULE = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Split(';')[1];
                            }
                            else
                                MODULE = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)];
                        }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public void SetModuleInfo(Dictionary<int, string> dicIOTYPE)
        {
            try
            {
                if (BLOCK != string.Empty)
                    if (PlcHelper.GetAddIOMaxSize() > PlcHelper.GetBlockIndex(BLOCK))
                        if (dicIOTYPE.ContainsKey(PlcHelper.GetBlockIndex(BLOCK)))
                            {
                                if (dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Contains(";"))
                                {
                                    if (HEADTYPE == PlcHelper.GetTypeInput())
                                        INFO = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Split(';')[0];
                                    else
                                        INFO = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)].Split(';')[1];
                                }
                                else
                                    INFO = dicIOTYPE[PlcHelper.GetBlockIndex(BLOCK)];
                            }

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public void SetDummyInfo(DataTable DT)
        {
            try
            {
                if (BLOCK != string.Empty && HEADTYPE != string.Empty)
                    if (PlcHelper.GetAddDummyMaxExtendSize() > PlcHelper.GetBlockIndex(BLOCK))
                        INFO = DT.Rows[PlcHelper.GetBlockIndex(BLOCK)][HEADTYPE].ToString();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public void SplitLevel(bool bUsingUIO)
        {
            List<string> listLevel = new List<string>();
            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
                listLevel = PlcHelper.SplitListString(bUsingUIO ? UIO : COMMENT, " ");
            else
                listLevel = PlcHelper.SplitListString(bUsingUIO ? UIO : SYMBOL, "_");

            int nCount = listLevel.Count;

            for (int n = 0; n < nCount; n++)
                listLevel.Remove(string.Empty);

            nCount = listLevel.Count;

            for (int n = 8; n > nCount; n--)
                listLevel.Add(string.Empty);

            for (int n = 0; n < 8; n++)
                ListLevel[n] = listLevel[n];
        }

        public string GetDefaultInfo()
        {
            if (INFO != string.Empty)
                return INFO;

            string TempInfo = string.Empty;

            SplitLevel(false);

            TempInfo = ListLevel[0];

            if (ListLevel[1] != string.Empty)
                TempInfo += " " + ListLevel[1];
            else
                return TempInfo;

            if (ListLevel[2] != string.Empty)
                TempInfo += " " + ListLevel[2];


            return TempInfo;
        }

        public string GetDefaultInfoFromComment()
        {
            if (INFO != string.Empty)
                return INFO;

            string TempInfo = string.Empty;
            List<string> listLevel = PlcHelper.SplitListString(COMMENT, " ");

            int n = 0;
            foreach (string strLevel in listLevel)
            {
                if (n > 2)
                    break;
                TempInfo += strLevel + " ";
                n++;
            }

            return TempInfo.TrimEnd(' ');
        }

        public string GetUserAddforAB()
        {
            string strUserAdd = string.Empty;

            string strLocal = ADDRESSTEMP.Substring(1, 2);
            string strNode = ADDRESSTEMP.Substring(3, 2);
            string strBit = string.Empty;
            string strTag = TAG;

            if (ADDRESSTEMP.Contains("."))
                strBit = "." + Convert.ToInt32(ADDRESSTEMP.Split('.')[1]).ToString();

            if (PlcHelper.GetTypeListIO().Contains(HEADTYPE))
            {
                if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT && !strTag.Contains(":"))
                {
                    strUserAdd = string.Format("{0}{1}", strTag, strBit);
                }
                else
                {
                    if (TAG == string.Empty)
                        strTag = "CNET";

                    if (strLocal == "00")
                        strUserAdd = string.Format("{0}:{1}:{2}.Data{3}", strTag, Convert.ToInt32(strNode), HEADTYPE, strBit);   //CNET_32:1:I.Data.18
                    else if (strNode == "00")
                        strUserAdd = string.Format("Local:{0}:{1}.Data{2}", Convert.ToInt32(strLocal), HEADTYPE, strBit);   //Local:10:I.Data.7
                    else
                        strUserAdd = string.Format("Local:{0}:{1}.Data[{2}]{3}", Convert.ToInt32(strLocal), HEADTYPE, Convert.ToInt32(strNode), strBit);  //Local:11:I.Data[3].9
                }
            }
            else if (HEADTYPE == "H")
            {
                strUserAdd = string.Format("{0}{1}", strTag, strBit);
            }
            else
            {
                if (TAG == string.Empty)
                    strTag = ADDRESSTEMP.Substring(0, 3);

                if (strTag.Contains("-") && !strTag.Contains("[") && !strTag.Contains("]") && PlcHelper.RelaceNumber(strTag, "#").Contains("-#"))
                {
                    string strTempTag = strTag.Split('-')[0];
                    int nNode = Convert.ToInt32(strTag.Split('-')[1]);
                    if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE))
                        strUserAdd = string.Format("{0}[{1}]{2}", strTempTag, Convert.ToInt32(ADDRESSTEMP.Split('.')[0].Substring(3, 2)) + nNode * 100, strBit);
                    else
                        strUserAdd = string.Format("{0}[{1}]", strTempTag, Convert.ToInt32(ADDRESSTEMP.Split('.')[0].Substring(3, 3)) + nNode * 1000);
                }
                else
                {
                    if (PlcHelper.GetAddTypeDotList().Contains(HEADTYPE))
                        strUserAdd = string.Format("{0}[{1}]{2}", strTag, Convert.ToInt32(ADDRESSTEMP.Split('.')[0].Substring(3, 2)), strBit);
                    else
                        strUserAdd = string.Format("{0}[{1}]", strTag, Convert.ToInt32(ADDRESSTEMP.Split('.')[0].Substring(3, 3)));
                }
            }
            return strUserAdd;
        }

        #endregion

        #region Privates Methods

        #endregion

    }
}
