using System;
using System.Collections.Generic;
using System.Text;
using UDM.General;

namespace UDM.Export
{
    public class CUIOHelper
    {
        public CUIOHelper()
        {
        
        }

        #region Symbol Table Export

        public static List<string> GetValueArrayForWorks2(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            ListUIOValue.Add("VAR_GLOBAL"); //CLASS     
            ListUIOValue.Add(UIOItem.SYMBOL); //LABELNAME ;
            ListUIOValue.Add(PlcHelper.GetAddSymbolType(UIOItem.DATATYPE)); //DATATYPE  
            ListUIOValue.Add(string.Empty);//CONSTANT  
            ListUIOValue.Add(UIOItem.ADDRESS); //DEVICE    
            ListUIOValue.Add(string.Empty); //ADDRESS   
            ListUIOValue.Add(string.Empty); //COMMENT   
            ListUIOValue.Add(string.Empty); //REMARK
            ListUIOValue.Add(string.Empty); //RELATIONWITHSYSTEMLABEL 
            ListUIOValue.Add(string.Empty); //SYSTEMLABELNAME 
            ListUIOValue.Add(string.Empty); //ATTRIBUTE

            return ListUIOValue;
        }

        public static List<string> GetValueArrayForDeveloper(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            ListUIOValue.Add(UIOItem.ADDRESS); //DEVICE ;
            ListUIOValue.Add(string.Empty);//LABEL  
            ListUIOValue.Add("\"" + UIOItem.SYMBOL + "\""); //COMMENT    

            return ListUIOValue;
        }

        public static List<string> GetValueArrayForSiemens(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            ListUIOValue.Add(UIOItem.SYMBOL); //SYMBOL    
            ListUIOValue.Add(UIOItem.ADDRESS); //ADDRESS ;
            ListUIOValue.Add(UIOItem.DATATYPE); //DATATYPE ;
            ListUIOValue.Add(UIOItem.COMMENT);//COMMENT  

            return ListUIOValue;
        }

        public static List<string> GetValueArrayForAB(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            string strType = eTAG_GROUP_AB.ALIAS;
            string strComment = UIOItem.COMMENT;
            
            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
            {
                strType = eTAG_GROUP_AB.COMMENT;
                strComment = ABLineIndentent(strComment);
            }

            strComment = DecodingComment(strComment);

            ListUIOValue.Add(strType); //TYPE    
            ListUIOValue.Add(string.Empty); //SCOPE    
            ListUIOValue.Add(UIOItem.SYMBOL); //NAME    
            ListUIOValue.Add("\"" + strComment + "\""); //DESCRIPTION    
            ListUIOValue.Add(string.Empty); //DATATYPE    
            ListUIOValue.Add("\"" + UIOItem.SPECIPER + "\""); //SPECIFIER    
            //  ListUIOValue.Add("(RADIX := Decimal)"); //ATTRIBUTES 

            return ListUIOValue;
        }

        #endregion

        #region Symbol OPC Export

        public static string[] GetValueArrayForOPCv4(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            string strOPCTag = UIOItem.SYMBOL;

            if (strOPCTag == string.Empty)
                strOPCTag = UIOItem.ADDRESS;
            if (UIOItem.TAG != string.Empty)
                strOPCTag = string.Format("{0} [ {1} ]", strOPCTag, UIOItem.TAG);

            ListUIOValue.Add(UIOItem.ADDRESS.Replace(".", "_"));            //TAGNAME
            ListUIOValue.Add(UIOItem.ADDRESS);           //ADDRESS
            ListUIOValue.Add(UIOItem.DATATYPE);          //DATATYPE
            ListUIOValue.Add("1");                       //RESPECTDATATYPE
            ListUIOValue.Add("RO");           //CLIENTACCESS
            ListUIOValue.Add("50");          //SCANRATE
            ListUIOValue.Add("");         //RAWLOW
            ListUIOValue.Add("");                      //RAWHIGH
            ListUIOValue.Add("");    //SCALEDLOW
            ListUIOValue.Add("");   //SCALEDHIGH
            ListUIOValue.Add("");  //SCALEDDATATYPE
            ListUIOValue.Add("");               //CLAMPLOW
            ListUIOValue.Add("");     //CLAMPHIGH
            ListUIOValue.Add("");    //ENGUNITS
            ListUIOValue.Add(strOPCTag);   //DESCRIPTION

            return ListUIOValue.ToArray();
        }

        public static string[] GetValueArrayForOPCv5(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();

            string strOPCTag = UIOItem.SYMBOL;

            ListUIOValue.Add(strOPCTag.Replace(".", "_"));            //TAGNAME
            ListUIOValue.Add(UIOItem.ADDRESS);           //ADDRESS
            ListUIOValue.Add(UIOItem.DATATYPE);          //DATATYPE
            ListUIOValue.Add("1");                       //RESPECTDATATYPE
            ListUIOValue.Add("RO");           //CLIENTACCESS
            ListUIOValue.Add("50");          //SCANRATE
            ListUIOValue.Add("");         //RAWLOW
            ListUIOValue.Add("");                      //RAWHIGH
            ListUIOValue.Add("");    //SCALEDLOW
            ListUIOValue.Add("");   //SCALEDHIGH
            ListUIOValue.Add("");  //SCALEDDATATYPE
            ListUIOValue.Add("");               //CLAMPLOW
            ListUIOValue.Add("");     //CLAMPHIGH
            ListUIOValue.Add("");    //ENGUNITS
            ListUIOValue.Add(UIOItem.COMMENT);   //DESCRIPTION

            return ListUIOValue.ToArray();
        }

        public static string[] GetValueArrayForOPC_ABPLC(CUIOItem UIOItem)
        {
            List<string> ListUIOValue = new List<string>();
            string strOPCTag = string.Empty;

            strOPCTag = UIOItem.SYMBOL;

            ListUIOValue.Add(UIOItem.SPECIPER.Replace(".", "_"));            //TAGNAME
            ListUIOValue.Add(UIOItem.SPECIPER);           //ADDRESS
            ListUIOValue.Add(UIOItem.DATATYPE);          //DATATYPE
            ListUIOValue.Add("1");                       //RESPECTDATATYPE
            ListUIOValue.Add("RO");           //CLIENTACCESS
            ListUIOValue.Add("50");          //SCANRATE
            ListUIOValue.Add("");         //RAWLOW
            ListUIOValue.Add("");                      //RAWHIGH
            ListUIOValue.Add("");    //SCALEDLOW
            ListUIOValue.Add("");   //SCALEDHIGH
            ListUIOValue.Add("");  //SCALEDDATATYPE
            ListUIOValue.Add("");               //CLAMPLOW
            ListUIOValue.Add("");     //CLAMPHIGH
            ListUIOValue.Add("");    //ENGUNITS
            ListUIOValue.Add(strOPCTag);   //DESCRIPTION

            return ListUIOValue.ToArray();
        }

        #endregion

        #region Convert Check

        public static string CheckStausAB(CUIOItem UIOItem, string CheckOption)
        {
            string strRusult = eUIOStatus.OK;

            if (CheckOption == eUIOStatusList.ADDRESSEMPTY)
            {
                if (UIOItem.ADDRESS == string.Empty)
                    strRusult = eUIOStatus.ERROR_ADDRESS_EMPTY;
            }

            if (CheckOption == eUIOStatusList.ADDRESSLENGTH)
            {
                if (UIOItem.ADDRESS.Length > 10)
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.ADDRESSTYPE)
            {
                if (UIOItem.ADDRESS.Contains(" "))
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                if (UIOItem.ADDRESS[UIOItem.ADDRESS.Length - 1] == '.')
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;

                if (!PlcHelper.GetTypeListAll().Contains(UIOItem.HEADTYPE))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
            }

            if (CheckOption == eUIOStatusList.SYMBOLEMPTY)
            {
                if (UIOItem.SYMBOL == string.Empty)
                    strRusult = eUIOStatus.ERROR_SYMBOL_EMPTY;

            }

            if (CheckOption == eUIOStatusList.SYMBOLLENGTH)
            {
                if (UIOItem.SYMBOL.Length > ePLC_SYMBOLLENGTH.AB)
                    strRusult = eUIOStatus.ERROR_SYMBOL_LENGTH;
            }

            if (CheckOption == eUIOStatusList.SYMBOLTYPE)
            {
                //    strRusult = eUIOStatus.ERROR_SYMBOL_UNKNOWN;
            }

            return strRusult;
           
        }

        public static string CheckStausSiemens(CUIOItem UIOItem, string CheckOption)
        {
            string strRusult = eUIOStatus.OK;

            if (CheckOption == eUIOStatusList.ADDRESSEMPTY)
            {
                if (UIOItem.ADDRESS == string.Empty)
                    strRusult = eUIOStatus.ERROR_ADDRESS_EMPTY;
            }

            if (CheckOption == eUIOStatusList.ADDRESSLENGTH)
            {
                if (UIOItem.ADDRESS.Length > 10)
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.ADDRESSTYPE)
            {
                if (UIOItem.ADDRESS.Contains(" "))
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                if (UIOItem.ADDRESS[UIOItem.ADDRESS.Length-1] == '.')
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;

                if (!PlcHelper.GetTypeListAll().Contains(UIOItem.HEADTYPE))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
                if (!CStringHelper.IsDigitString(PlcHelper.GetAddressBody(UIOItem.ADDRESS, UIOItem.HEADTYPE.Length).Replace(".", string.Empty)))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
            }


            if (CheckOption == eUIOStatusList.SYMBOLEMPTY)
            {
                if (UIOItem.SYMBOL == string.Empty)
                    strRusult = eUIOStatus.ERROR_SYMBOL_EMPTY;

            }

            if (CheckOption == eUIOStatusList.SYMBOLLENGTH)
            {
                if (UIOItem.SYMBOL.Length > ePLC_SYMBOLLENGTH.SIEMENS)
                    strRusult = eUIOStatus.ERROR_SYMBOL_LENGTH;
            }

            if (CheckOption == eUIOStatusList.SYMBOLTYPE)
            {
                //    strRusult = eUIOStatus.ERROR_SYMBOL_UNKNOWN;
            }

            return strRusult;
        }

        public static string CheckStausMITSUBISHI_DEVELOPER(CUIOItem UIOItem, string CheckOption)
        {
            string strRusult = eUIOStatus.OK;

            if (CheckOption == eUIOStatusList.ADDRESSEMPTY)
            {
                if (UIOItem.ADDRESS == string.Empty)
                    strRusult = eUIOStatus.ERROR_ADDRESS_EMPTY;
            }

            if (CheckOption == eUIOStatusList.ADDRESSLENGTH)
            {
                if (UIOItem.ADDRESS.Length > 10)
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.ADDRESSTYPE)
            {
                if (UIOItem.ADDRESS.Contains(" "))
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;

                if (!PlcHelper.GetTypeListAll().Contains(UIOItem.HEADTYPE))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
                if (!CStringHelper.IsHexaString(PlcHelper.GetAddressBody(UIOItem.ADDRESS, UIOItem.HEADTYPE.Length)))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
            }


            if (CheckOption == eUIOStatusList.SYMBOLEMPTY)
            {
                if (UIOItem.SYMBOL == string.Empty)
                    strRusult = eUIOStatus.ERROR_SYMBOL_EMPTY;

            }

            if (CheckOption == eUIOStatusList.SYMBOLLENGTH)
            {
                if (UIOItem.SYMBOL.Length > ePLC_SYMBOLLENGTH.MITSUBISHI_DEVELOPER)
                {
                    strRusult = eUIOStatus.ERROR_SYMBOL_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.SYMBOLTYPE)
            {
   
            }

            if (CheckOption == eUIOStatusList.LOGIC_DOUBLECOIL)
            {

            }

            if (CheckOption == eUIOStatusList.ADDRESSNOTUSED)
            {
                if (UIOItem._bNotUsedLogic)
                    strRusult = eUIOStatus.ERROR_ADDRESS_NOTUSED;
            }

            return strRusult;
        }

        public static string CheckStausMITSUBISHI_WORKS2(CUIOItem UIOItem, string CheckOption)
        {
            string strRusult = eUIOStatus.OK;

            if (CheckOption == eUIOStatusList.ADDRESSEMPTY)
            {
                if (UIOItem.ADDRESS == string.Empty)
                    strRusult = eUIOStatus.ERROR_ADDRESS_EMPTY;
            }

            if (CheckOption == eUIOStatusList.ADDRESSLENGTH)
            {
                if (UIOItem.ADDRESS.Length > 10)
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.ADDRESSTYPE)
            {
                if (UIOItem.ADDRESS.Contains(" "))
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;

                if (!PlcHelper.GetTypeListAll().Contains(PlcHelper.GetAddHeadType(UIOItem.ADDRESS)))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
                if (!CStringHelper.IsHexaString(PlcHelper.GetAddressBody(UIOItem.ADDRESS, UIOItem.HEADTYPE.Length).Replace(".", string.Empty)))
                {
                    strRusult = eUIOStatus.ERROR_ADDRESS_UNKNOWN;
                }
            }


            if (CheckOption == eUIOStatusList.SYMBOLEMPTY)
            {
                if (UIOItem.SYMBOL == string.Empty)
                    strRusult = eUIOStatus.ERROR_SYMBOL_EMPTY;

            }

            if (CheckOption == eUIOStatusList.SYMBOLLENGTH)
            {
                if (UIOItem.SYMBOL.Length > ePLC_SYMBOLLENGTH.MITSUBISHI_DEVELOPER)
                {
                    strRusult = eUIOStatus.ERROR_SYMBOL_LENGTH;
                }
            }

            if (CheckOption == eUIOStatusList.SYMBOLTYPE)
            {

            }
            return strRusult;
        }

      

        public static void SplitUIO(List<CUIOItem> UIOItemList, bool bUsingUIO)
        {
            foreach (CUIOItem UIOItem in UIOItemList)
                UIOItem.SplitLevel(bUsingUIO);
        }

        public static List<CUIOItem> ExistAddressInUIOItems(List<CUIOItem> UIOItemList, List<string> ListAdress)
        {

            List<CUIOItem> ListExist = new List<CUIOItem>();

            List<string> ListTypeAll = PlcHelper.GetTypeListAll();

            foreach (string strAddress in ListAdress)
            {
                if (strAddress == string.Empty || !ListTypeAll.Contains(strAddress.Substring(0,1)))
                    continue;

                CUIOItem uIOItem = new CUIOItem();

                if (!strAddress.StartsWith("ZR") && strAddress.Contains("Z"))
                    uIOItem.ADDRESS = strAddress.Split('Z')[0];
                else if (strAddress.Contains("."))
                    uIOItem.ADDRESS = strAddress.Split('.')[0];
                else 
                    uIOItem.ADDRESS = strAddress;

                uIOItem.UpdateProperty();
                List<CUIOItem> ListFindUIO = FindUIOItem(UIOItemList, uIOItem.ADDRESSTEMP);
                if (ListFindUIO.Count > 0)
                {
                    foreach (CUIOItem UIOItem in ListFindUIO)
                        ListExist.Add(UIOItem);
                }
            }

            return ListExist;
        }


        public static List<string> GetMakerGroupLogic(List<CUIOItem> ListUIOItem)
        {
            List<string> ListItems = new List<string>();

            foreach (CUIOItem UIOItem in ListUIOItem)
            {
                if (UIOItem.SYMBOL != string.Empty)
                {
                    if (!ListItems.Contains(string.Format("{0}", UIOItem.ListLevel[0].ToUpper())))
                        ListItems.Add(string.Format("{0}", UIOItem.ListLevel[0].ToUpper()));
                }
            }

            ListItems.Sort(CompareName);
            return ListItems;
        }


        public static Dictionary<string,string> GetDicAddressSymbol(List<CUIOItem> UIOItemList)
        {
            Dictionary<string, string> DicAddSym = new Dictionary<string, string>();

            foreach (CUIOItem UIOItem in UIOItemList)
            {
                if (!DicAddSym.ContainsKey(UIOItem.ADDRESS))
                    DicAddSym.Add(UIOItem.ADDRESS, UIOItem.SYMBOL);
            }

            return DicAddSym;
        }


        #endregion

        #region AB Tag

        public static string GetUserAddress(string strAddress, string strSymbol, Dictionary<string, string> DicTagIdexing, string strTagGroup)
        {
            if (strAddress == string.Empty || strSymbol == string.Empty)
                return string.Empty;

            string strUserAddrss = string.Empty;

            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT
                && strTagGroup == eTAG_GROUP_AB.COMMENT 
                && (PlcHelper.RelaceNumber(strAddress, "#") == "I#.#"
            || PlcHelper.RelaceNumber(strAddress, "#") == "O#.#"))
            {
                strUserAddrss = GetIOItemABComment(strAddress, strSymbol);
            }
            else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS
             && (PlcHelper.RelaceNumber(strAddress, "#").Contains("Local:#:I.Data")
            || PlcHelper.RelaceNumber(strAddress, "#").Contains("Local:#:O.Data")))
            {
                strUserAddrss = GetIOItemABDnet(strAddress, strSymbol);
            }
            else if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_ALIAS
             && (PlcHelper.RelaceNumber(strAddress, "#").Contains(":#:I.Data")
               || PlcHelper.RelaceNumber(strAddress, "#").Contains(":I.Slot[#]")
               || PlcHelper.RelaceNumber(strAddress, "#").Contains(":#:O.Data")
               || PlcHelper.RelaceNumber(strAddress, "#").Contains(":O.Slot[#]")))
            {
                strUserAddrss = GetIOItemABCnet(strAddress, strSymbol);
            }
            else if (IsDummyTypeForAB(strAddress, strSymbol, DicTagIdexing))
            {
                string strUserFormat = DicTagIdexing[GetUsedTag(strAddress)];

                if (strAddress.Contains("[") && strAddress.Contains("]"))
                {
                    int nNode = Convert.ToInt32(PlcHelper.GetSubStringBetween(strAddress, '[', ']'));
                    if (nNode >= 1000 && !PlcHelper.GetAddTypeDotList().Contains(PlcHelper.GetAddHeadType(strUserFormat)))
                    {
                        string strNewTag = string.Format("{0}-{1}", strAddress.Split('[')[0], nNode / 1000);
                        strAddress = string.Format("{0}[{1}]", strNewTag, nNode % 1000);
                    }
                    else if (nNode >= 100 && PlcHelper.GetAddTypeDotList().Contains(PlcHelper.GetAddHeadType(strUserFormat)))
                    {
                        string strNewTag = string.Format("{0}-{1}", strAddress.Split('[')[0], nNode / 100);
                        strAddress = string.Format("{0}[{1}]{2}", strNewTag, nNode % 100, strAddress.Split(']')[1]);
                    }
                }

                strUserAddrss = GetDummyItemAB(strAddress, DicTagIdexing);
            }
            else
            {
                if ((strAddress.Contains(":I.") || strAddress.Contains(":O.")) && !strAddress.Contains("["))
                {
                    strUserAddrss = strAddress + ";" + strSymbol;
                }
            }

            return strUserAddrss;
        }

        public static string EncodingComment(string strComment)
        {
            if (strComment == string.Empty)
                return string.Empty;

            StringBuilder EncodingConvert = new StringBuilder();
            strComment = strComment.Replace("$N", " ");
            strComment = strComment.Replace("$Q", "\"");
            strComment = strComment.Replace("$'", "'");

            for (int n = 0; n < strComment.Length; n++)
            {
                if (strComment[n] == '$' && CStringHelper.IsHexaString(strComment[n + 1].ToString()))
                {
                    char cHexaA = (char)Convert.ToInt32(strComment[n + 1].ToString() + strComment[n + 2].ToString() + strComment[n + 3].ToString() + strComment[n + 4].ToString(), 16);
                    EncodingConvert.Append(cHexaA);
                    n += 4;
                }
                else
                {
                    EncodingConvert.Append(strComment[n]);
                }
            }

            return EncodingConvert.ToString();
        }

        public static string DecodingComment(string strComment)
        {
            if (strComment == string.Empty)
                return string.Empty;

            StringBuilder DecodingConvert = new StringBuilder();

            for (int n = 0; n < strComment.Length; n++)
            {
                if (!PlcHelper.IsKoreanString(strComment[n].ToString()))
                    DecodingConvert.Append(strComment[n]);
                else
                {
                    string strHex = string.Format("{0:X}", Convert.ToInt32(strComment[n]));
                    DecodingConvert.Append("$" + strHex.ToLower());
                }
            }

            return DecodingConvert.ToString().Replace("\"", "$Q").Replace("'", "$'");
        }

        public static string ABLineIndentent(string strComment)
        {
            if (strComment == string.Empty)
                return string.Empty;

            string strIndentent = string.Empty;
            
            List<string> ListComment = PlcHelper.SplitListString(strComment," ");
            int nChangeLine = 0;
            string strFirst = string.Empty;
            foreach (string strWord in ListComment)
            {
                if (strFirst == string.Empty)
                {
                    strFirst = strWord;
                }
                else if ((strIndentent + strWord).Replace("$N", "").Length / 10 >= nChangeLine)
                {
                    nChangeLine++;
                    strIndentent += "$N" + strWord;
                }
                else
                    strIndentent += " " + strWord;
            }

            return strFirst + strIndentent;
        }

        public static bool SetDummyTagMapping(string strTag, string strDataType, Dictionary<string, string> DicTagMapping)
        {
            if (strTag == string.Empty)
            {
                return false;
            }
            else if (strDataType != string.Empty)
            {
                if (!strDataType.Contains("COUNTER") && !strDataType.Contains("TIMER") && !strDataType.Contains("INT") && !strDataType.Contains("BOOL") && !strDataType.Contains("AB:1756"))
                {

                    Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.TAG_DATATYPE_USERDATA, strTag, strDataType));
                    return false;
                }
                else if (strDataType.Contains(","))
                {
                    Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.TAG_DATATYPE_NODEMULTI, strTag, strDataType));
                    return false;
                }
                else if (strDataType.Contains("[") && strDataType.Contains("]"))
                {
                    if (strDataType.Contains("INT") && Convert.ToInt32(PlcHelper.GetSubStringBetween(strDataType, '[', ']')) > 1000)
                    {
                        Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.TAG_DATATYPE_NODESIZE, strTag, strDataType));
                        return false;
                    }
                }
            }

            SetDummyTag(strTag, strDataType, DicTagMapping);
            return true;
        }

        public static bool SetDummyTagMappingFromExcel(string strAddress,string strAddressTemp, string strDataType, Dictionary<string, string> DicTagMapping)
        {
            if (PlcHelper._PLCMAKER == ePLC_MAKER.AB_COMMENT)
            {
                string strAddressHead = strAddressTemp.Substring(0, 1);
                if (strAddressHead == "T")
                    strDataType = "TIMER[1000]";
                else if (strAddressHead  == "C")
                    strDataType = "CONTER[1000]";
                else if (strAddressHead == "S")
                    strDataType = "BOOL[1000]";
                else if (strAddressHead == "H")
                    strDataType = "DINT";
                else  
                    strDataType = "DINT[100]";

                SetDummyTag(GetUsedTag(strAddress), strDataType, DicTagMapping);
                return true;
            }
            else if (strDataType == string.Empty)
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1}", eERROR_AB.TAG_DATATYPE_EMPTY, strAddress));
                return false;
            }
            else if (strDataType != "COUNTER" && strDataType != "TIMER" && strDataType != "BOOL")
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.TAG_DATATYPE_USERDATA, strAddress, strDataType));
                return false;
            }
            else if (strAddress.Contains(","))
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.TAG_DATATYPE_NODEMULTI, strAddress, strDataType));
                return false;
            }
            else
            {
                if (strAddress.Contains("[") && strAddress.Contains("]"))
                    if (strAddress.Contains("."))
                        strDataType = string.Format("DINT[{0}]", Convert.ToInt32(PlcHelper.GetSubStringBetween(strAddress, '[', ']')));
                    else
                        strDataType = string.Format("{0}[{1}]", strDataType, Convert.ToInt32(PlcHelper.GetSubStringBetween(strAddress, '[', ']')));

                SetDummyTag(GetUsedTag(strAddress), strDataType, DicTagMapping);
                return true;
            }
        }

        public static void SetDummyTag(string strTag, string strDatatype, Dictionary<string, string> DicTagMapping)
        {
            if (strDatatype.Contains("INT"))
            {
                AddDummyTag(strTag, strDatatype, 100, DicTagMapping);
            }
            else if (strDatatype.Contains("COUNTER") || strDatatype.Contains("TIMER") || strDatatype.Contains("BOOL"))
            {
                AddDummyTag(strTag, strDatatype, 1000, DicTagMapping);
            }
        }

        public static void AddDummyTag(string strTag, string strDatatype, int nMaxSize, Dictionary<string, string> DicTagMapping)
        {
            int nSize = 0;

            if (strDatatype.Contains("[") && strDatatype.Contains("]"))
                nSize = Convert.ToInt32(PlcHelper.GetSubStringBetween(strDatatype, '[', ']'));

            if (!DicTagMapping.ContainsKey(strTag))
                DicTagMapping.Add(strTag, strDatatype);

            if (nSize > nMaxSize)
                for (int n = 1; n <= (nSize - 1) / nMaxSize; n++)
                {
                    string strExtendTag = SetExtendTag(strTag, n);
                    if (!DicTagMapping.ContainsKey(strExtendTag))
                        DicTagMapping.Add(strExtendTag, strDatatype);
                }
        }

        public static Dictionary<string, string> GetTagBlock(List<CUIOBlock> ListBlock)
        {
            Dictionary<string, string> DicBlockTag = new Dictionary<string, string>();
            string strTag = string.Empty;

            foreach (CUIOBlock UIOBlock in ListBlock)
            {
                strTag = UIOBlock.GetTempTag();
                if (strTag == string.Empty)
                    continue;

                if (!DicBlockTag.ContainsKey(UIOBlock.TAGINDEX))
                    DicBlockTag.Add(UIOBlock.TAGINDEX,strTag);
            }

            return DicBlockTag;
        }

        public static string GetDummyItemAB(string strAddress, Dictionary<string, string> DicTagIdexing)
        {
            string sTag = GetUsedTag(strAddress);
            if (!DicTagIdexing.ContainsKey(sTag)) 
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}", eERROR_AB.TAG_BASE_EMPTY,  strAddress));
                return string.Empty;
            }

            string strUserTag = DicTagIdexing[sTag];   //B172[92].8  or T172[124]
            string strUserAddrss = string.Empty;
            int nNode = 0;

            if (strAddress.Contains("[") && strAddress.Contains("]"))
                nNode = Convert.ToInt32(PlcHelper.GetSubStringBetween(strAddress, '[', ']'));


            if (strUserTag.Substring(0, 1) == "H")
            {
                strUserAddrss = "H" + Convert.ToInt32(PlcHelper.GetAddressBody(strUserTag, 1)).ToString("0000");
            }
            else if (PlcHelper.GetAddTypeDotList().Contains(PlcHelper.GetAddHeadType(strUserTag)))
            {
                strUserAddrss = strUserTag + Convert.ToInt32(nNode).ToString("00");
            }
            else
            {
                strUserAddrss = strUserTag + Convert.ToInt32(nNode).ToString("000");
            }


            if (strAddress.Split('.').Length == 2)
                strUserAddrss += "." + Convert.ToInt32(strAddress.Split('.')[1]).ToString("00");

            return strUserAddrss + ";" + GetUsedTag(strAddress);
        }

        public static string GetIOItemABComment(string strAddress, string strSymbol)
        {
            string strUserAddrss = string.Empty;
            string strTag = strSymbol;

            List<string> ListUserFormat = PlcHelper.SplitListString(strAddress, "."); //I0412.2


            strUserAddrss = ListUserFormat[0] + "." + Convert.ToInt32(ListUserFormat[1]).ToString("00");

            return strUserAddrss + ";" + strTag;
        }

        public static string GetIOItemABDnet(string strAddress, string strSymbol)
        {
            string strUserAddrss = string.Empty;
            string strTag = string.Empty;

            List<string> ListUserFormat = PlcHelper.SplitListString(strAddress, ":"); //Local:11:I.Data[3].9

            strUserAddrss = ListUserFormat[2].Substring(0, 1);
            strUserAddrss += Convert.ToInt32(ListUserFormat[1]).ToString("00");

            if (ListUserFormat[2].Contains("[") && ListUserFormat[2].Contains("]"))
            {
                string strNode = PlcHelper.GetSubStringBetween(ListUserFormat[2], '[', ']');
                if (strNode.Length > 2)
                {
                    Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.ALIAS_NODE_SIZE, strSymbol, strAddress));
                    return string.Empty;
                }

                strUserAddrss += Convert.ToInt32(strNode).ToString("00");
            }
            else
                strUserAddrss += "00";

            strTag = strUserAddrss;

            if (PlcHelper.SplitListString(ListUserFormat[2], ".").Count == 3)  // Check bool type
            {
                if (ListUserFormat[2].Contains("]."))
                    strUserAddrss += "." + Convert.ToInt32(PlcHelper.SplitListString(ListUserFormat[2], "].")[1]).ToString("00");   //Local:11:I.Data[3].9
                else
                    strUserAddrss += "." + Convert.ToInt32(PlcHelper.SplitListString(ListUserFormat[2], ".Data.")[1]).ToString("00");  //Local:10:I.Data.7
            }

            return strUserAddrss += ";" + strAddress.Split('.')[0];
        }

        public static string GetIOItemABCnet(string strAddress, string strSymbol)
        {
            string strUserAddrss = string.Empty;

            if (strAddress.Contains("Slot["))  //CNET31:1:I.Data.18  <-  CNET31:I.Slot[1].Data.18
            {
                List<string> ListTemp = PlcHelper.SplitListString(strAddress, ":");

                if (PlcHelper.SplitListString(strAddress, ".").Count == 4) // Check bool type
                {
                    strAddress = string.Format("{0}:{1}:{2}.Data.{3}", ListTemp[0]
                                            , PlcHelper.GetLastSubStringBetween(strAddress, '[', ']')
                                            , PlcHelper.SplitListString(ListTemp[1], ".")[0]
                                            , PlcHelper.SplitListString(ListTemp[1], ".")[3]);
                }
                else
                {
                    strAddress = string.Format("{0}:{1}:{2}.Data", ListTemp[0]
                        , PlcHelper.GetLastSubStringBetween(strAddress, '[', ']')
                        , PlcHelper.SplitListString(ListTemp[1], ".")[0]);
                }
            }

            List<string> ListUserFormat = PlcHelper.SplitListString(strAddress, ":"); //CNET31:1:I.Data.18 

            strUserAddrss = ListUserFormat[2].Substring(0, 1);
            strUserAddrss += "00";

            if (ListUserFormat[1].Length > 2)
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( TYPE: {2} )", eERROR_AB.ALIAS_NODE_SIZE, strSymbol, strAddress));
                return string.Empty;
            }
            else
                strUserAddrss += Convert.ToInt32(ListUserFormat[1]).ToString("00");

            if (PlcHelper.SplitListString(ListUserFormat[2], ".").Count == 3)  // Check bool type
                strUserAddrss += "." + Convert.ToInt32(PlcHelper.SplitListString(ListUserFormat[2], ".Data.")[1]).ToString("00");  //CNET31:1:I.Data.18 

            return strUserAddrss += ";" + ListUserFormat[0];
        }

        public static bool IsDummyTypeForAB(string strAddress, string strSymbol, Dictionary<string, string> DicTagIdexing)
        {
            if (strAddress == string.Empty)
                return false;

            if (PlcHelper.RelaceNumber(strSymbol, "#").StartsWith("I#") || PlcHelper.RelaceNumber(strSymbol, "#").StartsWith("O#"))
                return false;

            if (strAddress.Contains(".") && !CStringHelper.IsDigitString(strAddress.Split('.')[1]))
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( Alias for: {2} )", eERROR_AB.ALIAS_TYPE_SPECIALBIT, strSymbol, strAddress));
                return false;
            }
            else
            {
                if (!PlcHelper.RelaceNumber(strAddress, "#").Contains("[#]") && !DicTagIdexing.ContainsKey(strAddress.Split('.')[0]))
                {
                  //  Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( Alias for: {2} )", eERROR_AB.ALIAS_TYPE_DOUBLE, strSymbol, strAddress));
                    return false;
                }
            }

            if (!DicTagIdexing.ContainsKey(GetUsedTag(strAddress)))
            {
                Console.WriteLine(string.Format("Convert Error [{0,-30}]\t : {1,-50}\t( Alias for: {2} )", eERROR_AB.ALIAS_FOR_CANNOT_FIND, strSymbol, strAddress));
                return false;
            }

            return true;
        }

        public static string GetUsedTag(string strAddress)
        {
            string strTag = string.Empty;
            if (strAddress.Contains("["))
                strTag = strAddress.Split('[')[0];
            else if (strAddress.Split('.').Length == 2)
                strTag = strAddress.Split('.')[0];

            return strTag;
        }

        public static string GetTempBlock(CUIOBlock UIOBlock)
        {
            string TempBlock = string.Empty;

            if (UIOBlock.HEADTYPE == "H")
                TempBlock = UIOBlock.GetTempTag();
            else
                TempBlock = UIOBlock.BLOCKSPECIPER.Split('.')[0];

            return TempBlock;
        }

        public static void ExportAsanSpecial(CUIOItem UIOItem)
        {
            if (UIOItem.HEADTYPE == "I" || UIOItem.HEADTYPE == "O")
            {
                if (UIOItem.ADDRESSINDEX < 20000)
                {
                    UIOItem.SYMBOL = UIOItem.SYMBOL.Replace("I0", "I").Replace("O0", "O");
                    UIOItem.SPECIPER = UIOItem.SPECIPER.Replace("I0", "I").Replace("O0", "O");
                    UIOItem.ADDRESS = UIOItem.ADDRESS.Replace("I0", "I").Replace("O0", "O");
                    UIOItem.ADDRESSTEMP = UIOItem.ADDRESSTEMP.Replace("I0", "I").Replace("O0", "O");
                    UIOItem.BLOCK = UIOItem.BLOCK.Replace("I0", "I").Replace("O0", "O");
                }
            }
        }

        public static void ConvertKMSpecial(CUIOItem UIOItem)
        {
            if (UIOItem.SYMBOL == "NOT-USED" || UIOItem.SYMBOL == "NOT_USED")
                UIOItem.SYMBOL = eTableControl.SPARE;

            if (UIOItem.SYMBOL.Replace(" " ,string.Empty) == string.Empty)
                UIOItem.SYMBOL = eTableControl.SPARE;

            if (UIOItem.SYMBOL == string.Empty)
                UIOItem.SYMBOL = eTableControl.SPARE;

//             if (PlcHelper.GetTypeListIO().Contains(UIOItem.HEADTYPE))
//             {
//                 if (UIOItem.INFO == string.Empty && UIOItem.SHEET != "CSV")
//                 {
//                     if (UIOItem.SHEET.Contains("-I"))
//                         UIOItem.INFO = UIOItem.SHEET.Split(new string[] { "-I" }, StringSplitOptions.None)[0];
//                     else if (UIOItem.SHEET.Contains("-Q"))
//                         UIOItem.INFO = UIOItem.SHEET.Split(new string[] { "-Q" }, StringSplitOptions.None)[0];
//                     else
//                         UIOItem.INFO = UIOItem.SHEET;
//                 }
//             }
        }

        public static void ExportAsanSpecial(CUIOBlock UIOBlock)
        {
            if (UIOBlock.HEADTYPE == "I" || UIOBlock.HEADTYPE == "O")
            {
                if (UIOBlock.BLOCKINDEX < 200)
                {
                    UIOBlock.BLOCK = UIOBlock.BLOCK.Replace("I0", "I").Replace("O0", "O");
                }
            }
        }

        public static CUIOSet MakeSpecifer(List<CUIOItem> ListUIOItem)
        {
            CUIOSet UIOSet = new CUIOSet(ListUIOItem);
            UIOSet.MakeSpeciferList();
            foreach (CUIOBlock UIOBlock in UIOSet.UIOBLOCKLIST)
                UIOBlock.SetSpecifer(UIOSet._DicTagMapping);

            return UIOSet;
        }

        #endregion

        #region Sort Method

        public static void SortByUIO(List<CUIOItem> UIOItemList)
        {
            UIOItemList.Sort(CompareUIO);
        }

        public static void SortBySymbol(List<CUIOItem> UIOItemList)
        {
            UIOItemList.Sort(CompareUIOSymbol);
        }

        public static void SortByAddress(List<CUIOItem> UIOItemList)
        {
            UIOItemList.Sort(CompareUIOAddress);
        }

        public static void SortSameBlockList(List<CUIOBlock> UIOBlockList)
        {
            UIOBlockList.Sort(CompareUIOBlock);
        }

        public static void SortBlockListByUIOCount(List<CUIOBlock> UIOBlockList, bool bAscending)
        {
            if (bAscending)
                UIOBlockList.Sort(CompareUIOBlockByUIOCountAccending);
            else
                UIOBlockList.Sort(CompareUIOBlockByUIOCountDescending);
        }


        private static int CompareUIO(CUIOItem x, CUIOItem y)
        {
            return PlcHelper.CompareString(
                x.HEADTYPE, y.HEADTYPE,
                x.SHEET, y.SHEET,
                string.Format("{0:00000000}", x.ADDRESSINDEX), string.Format("{0:00000000}", y.ADDRESSINDEX)
                );
        }

        private static int CompareUIOAddress(CUIOItem x, CUIOItem y)
        {
            return PlcHelper.CompareString(string.Format("{0:00000000}", x.ADDRESSINDEX), string.Format("{0:00000000}", y.ADDRESSINDEX));
        }

        private static int CompareUIOSymbol(CUIOItem x, CUIOItem y)
        {
            return PlcHelper.CompareString(x.SYMBOL, y.SYMBOL);
        }
     
        private static int CompareUIOBlock(CUIOBlock x, CUIOBlock y)
        {
            return PlcHelper.CompareString(
                string.Format("{0:00000000}", x.SAMEBLOCKINDEX), string.Format("{0:00000000}", y.SAMEBLOCKINDEX),
               x.HEADTYPE, y.HEADTYPE, string.Format("{0:00000000}", x.BLOCKINDEX), string.Format("{0:00000000}", y.BLOCKINDEX));
        }

        private static int CompareUIOBlockByUIOCountAccending(CUIOBlock x, CUIOBlock y)
        {
            return PlcHelper.CompareString(string.Format("{0:00000000}", x.LISTUIOITEM.Count), string.Format("{0:00000000}", y.LISTUIOITEM.Count));
        }

        private static int CompareUIOBlockByUIOCountDescending(CUIOBlock x, CUIOBlock y)
        {
            return PlcHelper.CompareString(string.Format("{0:00000000}", y.LISTUIOITEM.Count), string.Format("{0:00000000}", x.LISTUIOITEM.Count));
        }

        private static int CompareName(string x, string y)
        {
            return PlcHelper.CompareString(x, y);
        }

    
        
        #endregion

        #region Find Method

        public static List<CUIOItem> FindUIOItem(List<CUIOItem> ListUIOItem, string strAddress)
        {
            List<CUIOItem> UIOItemList = ListUIOItem.FindAll(delegate(CUIOItem UIOItem)
            {
                return UIOItem.ADDRESSTEMP == strAddress;
            });

            return UIOItemList;
        }

        public static List<CUIOItem> FindUIOItemBySymbol(List<CUIOItem> ListUIOItem, string strSymbol)
        {
            List<CUIOItem> UIOItemList = ListUIOItem.FindAll(delegate(CUIOItem UIOItem)
            {
                return UIOItem.SYMBOL == strSymbol;
            });

            return UIOItemList;
        }

        public static List<CUIOItem> FindUIOItembyFirstLevel(List<CUIOItem> ListUIOItem, string strFirstLevel)
        {
            List<CUIOItem> UIOItemList = ListUIOItem.FindAll(delegate(CUIOItem UIOItem)
            {

                return UIOItem.ListLevel[0].Contains(strFirstLevel) || strFirstLevel.Contains(UIOItem.ListLevel[0]);
            });

            return UIOItemList;
        }

        public static CUIOItem FindUIOItemByID(List<CUIOItem> ListUIOItem, string strID)
        {
            CUIOItem FindUIO = ListUIOItem.Find(delegate(CUIOItem UIOItem)
            {
                return UIOItem.ID == strID;
            });

            return FindUIO;
        }

        public static string SetExtendTag(string strTag, int nExtend)
        {
            string strExtendTag = string.Empty;

            strExtendTag = string.Format("{0}-{1}", strTag, nExtend);

            return strExtendTag;
        }

        #endregion

    }
}
