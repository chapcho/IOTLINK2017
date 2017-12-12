using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using UDM.General;
using System.IO;
using System.Reflection;

namespace UDM.Export
{
    /// <summary>
    /// This class represents a String Helper.
    /// </summary>
    public class PlcHelper
    {
        public static string _PLCMAKER = ePLC_MAKER.MITSUBISHI_DEVELOPER.ToString();

        public static List<string> GetAddTypeHexaBitList()
        {
            try
            {
                string strHexaSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strHexaSet = string.Empty; break;
                    case (ePLC_MAKER.SIEMENS): strHexaSet = string.Empty; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strHexaSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.HEXABITLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strHexaSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.HEXABITLIST; break;
                    default: break;
                }

                return new List<string>(strHexaSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static List<string> GetAddTypeHexaBlockList()
        {
            try
            {
                string strArraySet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strArraySet = string.Empty; break;
                    case (ePLC_MAKER.SIEMENS): strArraySet = string.Empty; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strArraySet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.HEXABLCOKLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strArraySet = eADDRESS_TYPE_MITSUBISHI_WORKS2.HEXABLCOKLIST; break;
                    default: break;
                }

                return new List<string>(strArraySet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
                throw error;
            }
        }


        public static List<string> GetAddTypeWordList()
        {
            try
            {
                string strArraySet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strArraySet = eADDRESS_TYPE_AB.WORDLIST; break;
                    case (ePLC_MAKER.SIEMENS): strArraySet = eADDRESS_TYPE_SIEMENS.WORDLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strArraySet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.WORDLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strArraySet = eADDRESS_TYPE_MITSUBISHI_WORKS2.WORDLIST; break;
                    default: break;
                }

                return new List<string>(strArraySet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
                throw error;
            }
        }


        public static List<string> GetAddTypeDotList()
        {
            try
            {
                string strArraySet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strArraySet = eADDRESS_TYPE_AB.DOTLIST; break;
                    case (ePLC_MAKER.SIEMENS): strArraySet = eADDRESS_TYPE_SIEMENS.DOTLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strArraySet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.DOTLIST; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strArraySet = eADDRESS_TYPE_MITSUBISHI_WORKS2.DOTLIST; break;
                    default: break;
                }

                return new List<string>(strArraySet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
                throw error;
            }
        }




        public static List<string> GetTypeListAll()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.LISTALL; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.LISTALL; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.LISTALL; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.LISTALL; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static int GetAddIOMaxSize()
        {
            try
            {
                int nSize = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): nSize = eADDRESS_SPARE_AB.MAXIO; break;
                    case (ePLC_MAKER.SIEMENS): nSize = eADDRESS_SPARE_SIEMENS.MAXIO; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): nSize = eADDRESS_SPARE_MITSUBISHI_DEVELOPER.MAXIO; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): nSize = eADDRESS_SPARE_MITSUBISHI_WORKS2.MAXIO; break;
                    default: break;
                }

                return nSize;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static int GetAddIOMaxExtendSize()
        {
            try
            {
                int nSize = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): nSize = eADDRESS_SPARE_AB.MAXIO_EXTEND; break;
                    case (ePLC_MAKER.SIEMENS): nSize = eADDRESS_SPARE_SIEMENS.MAXIO_EXTEND; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): nSize = eADDRESS_SPARE_MITSUBISHI_DEVELOPER.MAXIO_EXTEND; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): nSize = eADDRESS_SPARE_MITSUBISHI_WORKS2.MAXIO_EXTEND; break;
                    default: break;
                }

                return nSize;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static int GetAddDummyMaxSize()
        {
            try
            {
                int nSize = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): nSize = eADDRESS_SPARE_AB.MAXDUMMY; break;
                    case (ePLC_MAKER.SIEMENS): nSize = eADDRESS_SPARE_SIEMENS.MAXDUMMY; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): nSize = eADDRESS_SPARE_MITSUBISHI_DEVELOPER.MAXDUMMY; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): nSize = eADDRESS_SPARE_MITSUBISHI_WORKS2.MAXDUMMY; break;
                    default: break;
                }

                return nSize;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static int GetAddDummyMaxExtendSize()
        {
            try
            {
                int nSize = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): nSize = eADDRESS_SPARE_AB.MAXDUMMY_EXTEND; break;
                    case (ePLC_MAKER.SIEMENS): nSize = eADDRESS_SPARE_SIEMENS.MAXDUMMY_EXTEND; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): nSize = eADDRESS_SPARE_MITSUBISHI_DEVELOPER.MAXDUMMY_EXTEND; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): nSize = eADDRESS_SPARE_MITSUBISHI_WORKS2.MAXDUMMY_EXTEND; break;
                    default: break;
                }

                return nSize;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetDefaltDataType(string strHeadType)
        {
            try
            {
                string strDataType = GetAddSymbolType(eADDRESS_DATATYPE.BIT);


                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetTypeListTimer().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.TIMER);
                        if (GetTypeListCount().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.COUNTER);
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (GetTypeListTimer().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.TIMER);
                        if (GetTypeListCount().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.COUNTER);
                        if (eADDRESS_DATATYPE_SIEMENS.DB == strHeadType)
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.DB);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (GetTypeListTimer().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.TIMER);
                        if (GetTypeListCount().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.COUNTER);
                        if (GetAddTypeWordList().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.WORD_UNSIGNED);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetTypeListTimer().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.WORD_UNSIGNED);
                        if (GetTypeListCount().Contains(strHeadType))
                            strDataType = GetAddSymbolType(eADDRESS_DATATYPE.WORD_UNSIGNED);
                        break;
                    default: break;
                }

                return strDataType;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetAddSymbolType(string strDataType)
        {
            try
            {
                string strSymbolType = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        {
                            if (strDataType == eADDRESS_DATATYPE.BIT)
                                strSymbolType = eADDRESS_DATATYPE_AB.BIT;
                            if (strDataType == eADDRESS_DATATYPE.WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_BIT)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY16_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_BIT)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY32_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_BIT)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY64_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY16_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY32_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY64_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY16_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY32_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY64_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY16_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY32_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY64_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY16_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY32_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_AB.ARRAY64_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.TIMER)
                                strSymbolType = eADDRESS_DATATYPE_AB.TIMER;
                            if (strDataType == eADDRESS_DATATYPE.COUNTER)
                                strSymbolType = eADDRESS_DATATYPE_AB.COUNTER;
                            break;
                        }
                    case (ePLC_MAKER.SIEMENS):
                        {
                            if (strDataType == eADDRESS_DATATYPE.BIT)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.BIT;
                            if (strDataType == eADDRESS_DATATYPE.WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_BIT)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY16_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_BIT)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY32_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_BIT)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY64_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY16_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY32_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY64_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY16_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY32_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY64_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY16_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY32_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY64_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY16_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY32_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.ARRAY64_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.TIMER)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.TIMER;
                            if (strDataType == eADDRESS_DATATYPE.COUNTER)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.COUNTER;
                            if (strDataType == eADDRESS_DATATYPE.DB)
                                strSymbolType = eADDRESS_DATATYPE_SIEMENS.DB;
                            break;
                        }
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        {
                            if (strDataType == eADDRESS_DATATYPE.BIT)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.BIT;
                            if (strDataType == eADDRESS_DATATYPE.WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_BIT)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY16_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_BIT)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY32_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_BIT)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY64_BIT;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY16_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY32_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY64_WORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY16_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY32_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_WORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY64_WORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY16_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY32_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_SIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY64_DWORD_SIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY16_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY16_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY32_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY32_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.ARRAY64_DWORD_UNSIGNED)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.ARRAY64_DWORD_UNSIGNED;
                            if (strDataType == eADDRESS_DATATYPE.TIMER)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.TIMER;
                            if (strDataType == eADDRESS_DATATYPE.COUNTER)
                                strSymbolType = eADDRESS_DATATYPE_MITSUBISHI.COUNTER;
                            break;
                        }
                    default: break;
                }
                return strSymbolType;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static List<string> GetSelectedListType(eExcelListType emExcelListType)
        {
            List<string> ListType = new List<string>();

            if (eExcelListType.ALL == emExcelListType)
                ListType = PlcHelper.GetTypeListAll();
            if (eExcelListType.IO == emExcelListType)
                ListType = PlcHelper.GetTypeListIO();
            if (eExcelListType.DUMMY == emExcelListType)
                ListType = PlcHelper.GetTypeListDummy();
            if (eExcelListType.LINK == emExcelListType)
                ListType = PlcHelper.GetTypeListLink();
            if (eExcelListType.TIMECOUNT == emExcelListType)
                ListType = PlcHelper.GetTypeListTimerCounter();

            return ListType;
        }


        public static List<string> GetTypeListIO()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPEIO; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPEIO; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPEIO; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPEIO; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static List<string> GetTypeListDummy()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS): strTypeSet = eADDRESS_TYPE_AB.TYPEDUMMY + ";" + eADDRESS_TYPE_AB.TYPESPCIAL; break;
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPEDUMMY + ";" + eADDRESS_TYPE_AB.TYPESPCIAL; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPEDUMMY; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPEDUMMY; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPEDUMMY; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static List<string> GetTypeListLink()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPELINK; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPELINK; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPELINK; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPELINK; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static List<string> GetTypeListTimer()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPETIMER; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPETIMER; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPETIMER; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPETIMER; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static List<string> GetTypeListCount()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPECOUNT; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPECOUNT; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPECOUNT; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPECOUNT; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static List<string> GetTypeSpecial()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPESPCIAL; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = string.Empty; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = string.Empty; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = string.Empty; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static List<string> GetTypeListTimerCounter()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eADDRESS_TYPE_AB.TYPETIMER + ";" + eADDRESS_TYPE_AB.TYPECOUNT; break;
                    case (ePLC_MAKER.SIEMENS): strTypeSet = eADDRESS_TYPE_SIEMENS.TYPETIMER + ";" + eADDRESS_TYPE_AB.TYPECOUNT; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.TYPETIMER + ";" + eADDRESS_TYPE_AB.TYPECOUNT; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eADDRESS_TYPE_MITSUBISHI_WORKS2.TYPETIMER + ";" + eADDRESS_TYPE_AB.TYPECOUNT; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }




        public static List<string> GetSymbolDefaultRow()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT): strTypeSet = eSymbolColumn_AB.TYPE + ";"
                                            + eSymbolColumn_AB.SCOPE + ";"
                                            + eSymbolColumn_AB.NAME + ";"
                                            + eSymbolColumn_AB.DESCRIPTION + ";"
                                            + eSymbolColumn_AB.DATATYPE + ";"
                                            + eSymbolColumn_AB.SPECIFIER;// + ";"
                        //     + eSymbolColumn_AB.ATTRIBUTES;
                        break;

                    case (ePLC_MAKER.SIEMENS): strTypeSet = string.Empty; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strTypeSet = eSymbolColumn_GXDEVELOPER.DEVICE + ";"
                                                                        + eSymbolColumn_GXDEVELOPER.LABEL + ";"
                                                                        + eSymbolColumn_GXDEVELOPER.COMMENT; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eSymbolColumnGXWorks.CLASS + ";"
                                                                        + eSymbolColumnGXWorks.LABELNAME + ";"
                                                                        + eSymbolColumnGXWorks.DATATYPE + ";"
                                                                        + eSymbolColumnGXWorks.CONSTANT + ";"
                                                                        + eSymbolColumnGXWorks.DEVICE + ";"
                                                                        + eSymbolColumnGXWorks.ADDRESS + ";"
                                                                        + eSymbolColumnGXWorks.COMMENT + ";"
                                                                        + eSymbolColumnGXWorks.REMARK + ";"
                                                                        + eSymbolColumnGXWorks.RELATIONWITHSYSTEMLABEL + ";"
                                                                        + eSymbolColumnGXWorks.SYSTEMLABELNAME + ";"
                                                                        + eSymbolColumnGXWorks.ATTRIBUTE; break;
                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static List<string> GetOPCDefaultRow()
        {
            try
            {
                string strTypeSet = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                    case (ePLC_MAKER.SIEMENS):
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                    case (ePLC_MAKER.MITSUBISHI_WORKS2): strTypeSet = eSymbolColumnOPC.TAGNAME + ";"
                                                                        + eSymbolColumnOPC.ADDRESS + ";"
                                                                        + eSymbolColumnOPC.DATATYPE + ";"
                                                                        + eSymbolColumnOPC.RESPECTDATATYPE + ";"
                                                                        + eSymbolColumnOPC.CLIENTACCESS + ";"
                                                                        + eSymbolColumnOPC.SCANRATE + ";"
                                                                        + eSymbolColumnOPC.RAWLOW + ";"
                                                                        + eSymbolColumnOPC.RAWHIGH + ";"
                                                                        + eSymbolColumnOPC.SCALEDLOW + ";"
                                                                        + eSymbolColumnOPC.SCALEDHIGH + ";"
                                                                        + eSymbolColumnOPC.SCALEDDATATYPE + ";"
                                                                        + eSymbolColumnOPC.CLAMPLOW + ";"
                                                                        + eSymbolColumnOPC.CLAMPHIGH + ";"
                                                                        + eSymbolColumnOPC.ENGUNITS + ";"
                                                                        + eSymbolColumnOPC.DESCRIPTION; break;

                    default: break;
                }

                return new List<string>(strTypeSet.Split(new string[] { ";" }, StringSplitOptions.None));
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static bool CheckInOutType(string strType, string strModuleIOType)
        {
            bool bCheck = false;

            if (strType == PlcHelper.GetTypeInput() && strModuleIOType.Contains("IN"))
                bCheck = true;
            else if (strType == PlcHelper.GetTypeOutput() && strModuleIOType.Contains("OUT"))
                bCheck = true;
            else if (strModuleIOType == eFrmModule.MIX)
                bCheck = true;
            else
                bCheck = false;

            return bCheck;
        }



        public static Dictionary<int, string> GetModuleDataList(DataTable DT)
        {
            try
            {
                Dictionary<int, string> _dicIOTYPE = new Dictionary<int, string>();
                string strIOType = string.Empty;

                for (int nRow = 0; nRow < DT.Rows.Count; nRow++)
                {
                    if (DT.Rows[nRow][eFrmModule.MODULETYPE].ToString() != string.Empty)
                    {
                        string strModuleIOType = DT.Rows[nRow][eFrmModule.MODULETYPE].ToString();
                        string strModuleSize = strModuleIOType.Substring(strModuleIOType.Length - 3, 3).Replace("*", string.Empty);

                        if (strModuleIOType.Contains(","))
                        {
                            if (strModuleIOType == "IN*16,OUT*32")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                            }
                            if (strModuleIOType == "IN*32,OUT*64")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                            }
                            if (strModuleIOType == "IN*64,OUT*128")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.INPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                                _dicIOTYPE.Add(++nRow, eFrmModule.OUTPUT);
                            }

                            if (strModuleIOType == "IN*16,OUT*16")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.MIX);
                            }
                            if (strModuleIOType == "IN*32,OUT*32")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                            }
                            if (strModuleIOType == "IN*64,OUT*64")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                            }
                            if (strModuleIOType == "IN*128,OUT*128")
                            {
                                _dicIOTYPE.Add(nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                                _dicIOTYPE.Add(++nRow, eFrmModule.MIX);
                            }
                            continue;
                        }

                        if (strModuleIOType == eFrmModule.SPECIAL)
                            _dicIOTYPE.Add(nRow, eFrmModule.MIX);
                        if (strModuleIOType == eFrmModule.INTELLIGENT)
                        {
                            _dicIOTYPE.Add(nRow, string.Empty);
                            _dicIOTYPE.Add(++nRow, string.Empty);
                        }

                        if (strModuleSize == "16")
                        {
                            strIOType = strModuleIOType.Split('*')[0];
                            _dicIOTYPE.Add(nRow, strIOType);
                        }
                        if (strModuleSize == "32")
                        {
                            strIOType = strModuleIOType.Split('*')[0];
                            _dicIOTYPE.Add(nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                        }
                        if (strModuleSize == "64")
                        {
                            strIOType = strModuleIOType.Split('*')[0];
                            _dicIOTYPE.Add(nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                        }
                        if (strModuleSize == "128")
                        {
                            strIOType = strModuleIOType.Split('*')[0];
                            _dicIOTYPE.Add(nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                            _dicIOTYPE.Add(++nRow, strIOType);
                        }
                    }
                    else
                        _dicIOTYPE.Add(nRow, string.Empty);
                }

                return _dicIOTYPE;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static Dictionary<int, string> GetModuleNameList(DataTable DT)
        {
            try
            {
                Dictionary<int, string> _dicIOTYPE = new Dictionary<int, string>();
                string strModuleIOType = string.Empty;

                for (int nRow = 0; nRow < DT.Rows.Count; nRow++)
                {
                    strModuleIOType = DT.Rows[nRow][eFrmModule.MODULENAME].ToString();
                    _dicIOTYPE.Add(nRow, strModuleIOType);
                }

                return _dicIOTYPE;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static Dictionary<int, string> GetModuleInfoList(DataTable DT)
        {
            try
            {
                Dictionary<int, string> _dicIOTYPE = new Dictionary<int, string>();
                string strModuleIOType = string.Empty;

                for (int nRow = 0; nRow < DT.Rows.Count; nRow++)
                {
                    if (DT.Rows[nRow][eFrmModule.INFO].ToString() != string.Empty)
                    {
                        strModuleIOType = DT.Rows[nRow][eFrmModule.INFO].ToString();
                        _dicIOTYPE.Add(nRow, strModuleIOType);
                    }
                    else if (DT.Rows[nRow][eFrmModule.MODULENAME].ToString() != string.Empty)
                    {
                        _dicIOTYPE.Add(nRow, strModuleIOType);
                    }
                    else
                        _dicIOTYPE.Add(nRow, string.Empty);

                }

                return _dicIOTYPE;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static Dictionary<int, string> GetDummyInfoList(DataSet DS)
        {
            try
            {
                Dictionary<int, string> _dicIOTYPE = new Dictionary<int, string>();
                string strModuleIOType = string.Empty;

                foreach (DataTable DT in DS.Tables)
                {
                    for (int nRow = 0; nRow < DT.Rows.Count; nRow++)
                    {
                        if (DT.Rows[nRow][eFrmModule.INFO].ToString() != string.Empty)
                        {
                            strModuleIOType = DT.Rows[nRow][eFrmModule.INFO].ToString();
                            _dicIOTYPE.Add(nRow, strModuleIOType);
                        }
                        else if (DT.Rows[nRow][eFrmModule.MODULENAME].ToString() != string.Empty)
                        {
                            _dicIOTYPE.Add(nRow, strModuleIOType);
                        }
                        else
                            _dicIOTYPE.Add(nRow, string.Empty);
                    }
                }

                return _dicIOTYPE;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetAddress(string BLOCK, string BIT)
        {
            try
            {
                string strAddress = string.Empty;
                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(GetAddHeadType(BLOCK)))
                            strAddress = BLOCK + eModelRow.ADDRESSSPLIT + BIT;
                        else
                            strAddress = BLOCK + BIT;
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (GetAddTypeWordList().Contains(GetAddHeadType(BLOCK)))
                            strAddress = BLOCK + eModelRow.ADDRESSSPLIT + BIT;
                        else
                            strAddress = BLOCK + BIT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strAddress = BLOCK + BIT; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeWordList().Contains(GetAddHeadType(BLOCK)))
                            strAddress = BLOCK + eModelRow.ADDRESSSPLIT + BIT;
                        else
                            strAddress = BLOCK + BIT; break;
                    default: break;

                }
                return strAddress;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static int GetFormMaxBlcokInModule(eExcelListType ExcelListType)
        {
            try
            {
                int nMaxBlcokInModule = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxBlcokInModule = eFormSheet_AB_ALIAS.BLOCKCOUNT_INMODULE_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxBlcokInModule = eFormSheet_AB_ALIAS.BLOCKCOUNT_INMODULE_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxBlcokInModule = eFormSheet_AB_ALIAS.BLOCKCOUNT_INMODULE_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxBlcokInModule = eFormSheet_AB_ALIAS.BLOCKCOUNT_INMODULE_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.AB_COMMENT):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxBlcokInModule = eFormSheet_AB_COMMENT.BLOCKCOUNT_INMODULE_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxBlcokInModule = eFormSheet_AB_COMMENT.BLOCKCOUNT_INMODULE_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxBlcokInModule = eFormSheet_AB_COMMENT.BLOCKCOUNT_INMODULE_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxBlcokInModule = eFormSheet_AB_COMMENT.BLOCKCOUNT_INMODULE_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxBlcokInModule = eFormSheet_Siemens.BLOCKCOUNT_INMODULE_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxBlcokInModule = eFormSheet_Siemens.BLOCKCOUNT_INMODULE_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxBlcokInModule = eFormSheet_Siemens.BLOCKCOUNT_INMODULE_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxBlcokInModule = eFormSheet_Siemens.BLOCKCOUNT_INMODULE_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxBlcokInModule = eFormSheet_MelsecDeveloper.BLOCKCOUNT_INMODULE_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxBlcokInModule = eFormSheet_MelsecDeveloper.BLOCKCOUNT_INMODULE_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxBlcokInModule = eFormSheet_MelsecDeveloper.BLOCKCOUNT_INMODULE_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxBlcokInModule = eFormSheet_MelsecDeveloper.BLOCKCOUNT_INMODULE_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxBlcokInModule = eFormSheet_MelsecWorks2.BLOCKCOUNT_INMODULE_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxBlcokInModule = eFormSheet_MelsecWorks2.BLOCKCOUNT_INMODULE_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxBlcokInModule = eFormSheet_MelsecWorks2.BLOCKCOUNT_INMODULE_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxBlcokInModule = eFormSheet_MelsecWorks2.BLOCKCOUNT_INMODULE_TIMECOUNT;
                        break;
                    default: break;
                }

                return nMaxBlcokInModule;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static int GetFormMaxMoudelInSheet(eExcelListType ExcelListType)
        {
            try
            {
                int nMaxMoudelInSheet = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxMoudelInSheet = eFormSheet_AB_ALIAS.MODULECOUNT_INSHEET_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxMoudelInSheet = eFormSheet_AB_ALIAS.MODULECOUNT_INSHEET_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxMoudelInSheet = eFormSheet_AB_ALIAS.MODULECOUNT_INSHEET_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxMoudelInSheet = eFormSheet_AB_ALIAS.MODULECOUNT_INSHEET_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.AB_COMMENT):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxMoudelInSheet = eFormSheet_AB_COMMENT.MODULECOUNT_INSHEET_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxMoudelInSheet = eFormSheet_AB_COMMENT.MODULECOUNT_INSHEET_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxMoudelInSheet = eFormSheet_AB_COMMENT.MODULECOUNT_INSHEET_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxMoudelInSheet = eFormSheet_AB_COMMENT.MODULECOUNT_INSHEET_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxMoudelInSheet = eFormSheet_Siemens.MODULECOUNT_INSHEET_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxMoudelInSheet = eFormSheet_Siemens.MODULECOUNT_INSHEET_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxMoudelInSheet = eFormSheet_Siemens.MODULECOUNT_INSHEET_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxMoudelInSheet = eFormSheet_Siemens.MODULECOUNT_INSHEET_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxMoudelInSheet = eFormSheet_MelsecDeveloper.MODULECOUNT_INSHEET_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxMoudelInSheet = eFormSheet_MelsecDeveloper.MODULECOUNT_INSHEET_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxMoudelInSheet = eFormSheet_MelsecDeveloper.MODULECOUNT_INSHEET_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxMoudelInSheet = eFormSheet_MelsecDeveloper.MODULECOUNT_INSHEET_TIMECOUNT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (ExcelListType == eExcelListType.IO)
                            nMaxMoudelInSheet = eFormSheet_MelsecWorks2.MODULECOUNT_INSHEET_IO;
                        if (ExcelListType == eExcelListType.DUMMY)
                            nMaxMoudelInSheet = eFormSheet_MelsecWorks2.MODULECOUNT_INSHEET_DUMMY;
                        if (ExcelListType == eExcelListType.LINK)
                            nMaxMoudelInSheet = eFormSheet_MelsecWorks2.MODULECOUNT_INSHEET_LINK;
                        if (ExcelListType == eExcelListType.TIMECOUNT)
                            nMaxMoudelInSheet = eFormSheet_MelsecWorks2.MODULECOUNT_INSHEET_TIMECOUNT;
                        break;
                    default: break;
                }

                return nMaxMoudelInSheet;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetOpenfileType()
        {
            string strOpenfileType = string.Empty;

            switch (_PLCMAKER)
            {
                case (ePLC_MAKER.AB_ALIAS):
                case (ePLC_MAKER.AB_COMMENT): strOpenfileType = "CSV Files|*.csv|Excel Files|*.xls;*.xlsx"; ; break;
                case (ePLC_MAKER.SIEMENS): strOpenfileType = "Excel Files|*.xlsx;*.xls|SDF Files|*.sdf";  break;
                case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strOpenfileType = "CSV(Developer) Files|*.csv|Excel Files|*.xlsx;*.xls"; ; break;
                case (ePLC_MAKER.MITSUBISHI_WORKS2): strOpenfileType = "CSV(Works2) Files|*.csv|Excel Files|*.xlsx;*.xls"; ; break;
                default: break;
            }

            return strOpenfileType;
        }

        public static string GetLogicfileType()
        {
            string strOpenfileType = string.Empty;

            switch (_PLCMAKER)
            {
                case (ePLC_MAKER.AB_ALIAS):
                case (ePLC_MAKER.AB_COMMENT): strOpenfileType = "CSV Files|*.csv|Excel Files|*.xls;*.xlsx"; ; break;
                case (ePLC_MAKER.SIEMENS): strOpenfileType = "SDF Files|*.sdf|Excel Files|*.xlsx;*.xls"; ; break;
                case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strOpenfileType = "CSV(Instruction List) Files|*.csv"; ; break;
                case (ePLC_MAKER.MITSUBISHI_WORKS2): strOpenfileType = "CSV(Works2) Files|*.csv|Excel Files|*.xlsx;*.xls"; ; break;
                default: break;
            }

            return strOpenfileType;
        }

        public static string GetOpenModulefileType()
        {
            string strOpenfileType = string.Empty;

            switch (_PLCMAKER)
            {
                case (ePLC_MAKER.AB_ALIAS):
                case (ePLC_MAKER.AB_COMMENT): strOpenfileType = "Excel Files|*.xls;*.xlsx"; ; break;
                case (ePLC_MAKER.SIEMENS): strOpenfileType = "CFG Files|*.cfg"; ; break;
                case (ePLC_MAKER.MITSUBISHI_DEVELOPER): strOpenfileType = "Excel Files|*.xlsx;*.xls"; ; break;
                case (ePLC_MAKER.MITSUBISHI_WORKS2): strOpenfileType = "Excel Files|*.xlsx;"; ; break;
                default: break;
            }

            return strOpenfileType;
        }


        public static bool IsRegistedType(string Address)
        {
            try
            {
                bool bRegisted = true;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (!GetTypeListAll().Contains(GetAddHeadType(Address)))
                            bRegisted = false; break;
                    case (ePLC_MAKER.SIEMENS):
                        if (!GetTypeListAll().Contains(GetAddHeadType(Address)))
                            bRegisted = false; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (!GetTypeListAll().Contains(GetAddHeadType(Address)))
                            bRegisted = false; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (!GetTypeListAll().Contains(GetAddHeadType(Address)))
                            bRegisted = false; break;
                    default: break;
                }

                return bRegisted;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        #region SymbolTable Methods

        public static void InitializeDataSetforSymboTable(DataSet DS)
        {
            try
            {
                DS.Tables.Clear();
                DS.Tables.Add();

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.TYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.SCOPE);
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.NAME);
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.DESCRIPTION);
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.DATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumn_AB.SPECIFIER);
                        // DS.Tables[0].Columns.Add(eSymbolColumn_AB.ATTRIBUTES);
                        DS.Tables[0].Rows.Add("0.2"); // AB Import format Version
                        DS.Tables[0].Rows.Add(GetSymbolDefaultRow().ToArray());
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        DS.Tables[0].Columns.Add(eSymbolColumn_SIEMENS.SYMBOL);
                        DS.Tables[0].Columns.Add(eSymbolColumn_SIEMENS.ADDRESS);
                        DS.Tables[0].Columns.Add(eSymbolColumn_SIEMENS.DATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumn_SIEMENS.COMMENT);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        DS.Tables[0].Columns.Add(eSymbolColumn_GXDEVELOPER.DEVICE);
                        DS.Tables[0].Columns.Add(eSymbolColumn_GXDEVELOPER.LABEL);
                        DS.Tables[0].Columns.Add(eSymbolColumn_GXDEVELOPER.COMMENT);
                        // DS.Tables[0].Rows.Add(GetSymbolDefaultRow().ToArray());
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.CLASS);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.LABELNAME);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.DATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.CONSTANT);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.DEVICE);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.ADDRESS);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.COMMENT);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.REMARK);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.RELATIONWITHSYSTEMLABEL);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.SYSTEMLABELNAME);
                        DS.Tables[0].Columns.Add(eSymbolColumnGXWorks.ATTRIBUTE);
                        DS.Tables[0].Rows.Add(eSymbolColumnGXWorks.DEFAULT);
                        DS.Tables[0].Rows.Add(GetSymbolDefaultRow().ToArray());
                        break;
                    default: break;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static void InitializeDataSetforOPC(DataSet DS)
        {
            try
            {
                DS.Tables.Clear();
                DS.Tables.Add();

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                    case (ePLC_MAKER.SIEMENS):
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.TAGNAME);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.ADDRESS);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.DATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.RESPECTDATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.CLIENTACCESS);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.SCANRATE);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.RAWLOW);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.RAWHIGH);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.SCALEDLOW);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.SCALEDHIGH);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.SCALEDDATATYPE);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.CLAMPLOW);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.CLAMPHIGH);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.ENGUNITS);
                        DS.Tables[0].Columns.Add(eSymbolColumnOPC.DESCRIPTION);
                        DS.Tables[0].Rows.Add(GetOPCDefaultRow().ToArray());
                        break;
                    default: break;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string[] GetValueArraySymboltable(CUIOItem UIOItem)
        {
            try
            {
                List<string> ListUIOValue = new List<string>();

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        ListUIOValue = CUIOHelper.GetValueArrayForAB(UIOItem);
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        ListUIOValue = CUIOHelper.GetValueArrayForSiemens(UIOItem);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        ListUIOValue = CUIOHelper.GetValueArrayForDeveloper(UIOItem);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        ListUIOValue = CUIOHelper.GetValueArrayForWorks2(UIOItem);
                        break;
                    default: break;
                }

                string[] strArray = new string[ListUIOValue.Count];
                ListUIOValue.CopyTo(strArray);

                return strArray;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }



        public static string GetDefaultSymbolTableName()
        {
            try
            {
                string strDefaultSymbolTableName = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        strDefaultSymbolTableName = eSymbolColumn_AB.DEFAULT;
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        strDefaultSymbolTableName = eSymbolColumn_SIEMENS.DEFAULT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strDefaultSymbolTableName = eSymbolColumn_GXDEVELOPER.DEFAULT;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strDefaultSymbolTableName = eSymbolColumnGXWorks.DEFAULT;
                        break;
                    default: break;
                }


                return strDefaultSymbolTableName;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        #endregion

        #region Address Methods

        public static int GetAddIndex(string AddressTemp) { return GetAddIndex(AddressTemp, string.Empty); }
        public static int GetAddIndex(string AddressTemp, string strDataType/* string.Empty*/)
        {
            try
            {
                int nAddressIndex = 0;
                string strHead = GetAddHeadType(AddressTemp);
                string strBody = PlcHelper.GetAddressBody(AddressTemp, strHead.Length).Replace(".", string.Empty);

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (strDataType == string.Empty
                            || strDataType == GetAddSymbolType(eADDRESS_DATATYPE.BIT)
                            || strDataType == GetAddSymbolType(eADDRESS_DATATYPE.TIMER)
                            || strDataType == GetAddSymbolType(eADDRESS_DATATYPE.COUNTER)
                            || strDataType == GetAddSymbolType(eADDRESS_DATATYPE.DWORD_UNSIGNED) && strBody.Length == 6) //DINT, B010203
                            nAddressIndex = Convert.ToInt32(strBody);
                        else
                            nAddressIndex = Convert.ToInt32(strBody + "00");
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        nAddressIndex = Convert.ToInt32(strBody);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strBody = PlcHelper.GetAddressBody(AddressTemp, strHead.Length).Split('.')[0];
                        if (GetAddTypeHexaBitList().Contains(strHead))
                            nAddressIndex = Convert.ToInt32(strBody, 16);
                        else
                            nAddressIndex = Convert.ToInt32(strBody, 10);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeHexaBitList().Contains(strHead))
                            nAddressIndex = Convert.ToInt32(strBody, 16);
                        else
                            nAddressIndex = Convert.ToInt32(strBody, 10);
                        break;

                    default: break;
                }

                return nAddressIndex;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static string GetAddTemp(string strHead, int nAddressIndex) { return GetAddTemp(strHead, nAddressIndex, string.Empty); }
        public static string GetAddTemp(string strHead, int nAddressIndex, string strDataType /*string.Empty*/)
        {
            try
            {
                string strAddressTemp = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(strHead))
                        {
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("000000"));
                            if (strDataType == GetAddSymbolType(eADDRESS_DATATYPE.BIT))
                                strAddressTemp = InsetString(strAddressTemp, 2, eModelRow.ADDRESSSPLIT);
                        }
                        else
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("00000"));

                        break;

                    case (ePLC_MAKER.SIEMENS):
                        if (GetAddTypeDotList().Contains(strHead))
                        {
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("00000"));
                            strAddressTemp = InsetString(strAddressTemp, 1, eModelRow.ADDRESSSPLIT);
                        }
                        else
                        {
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("0000"));
                        }
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (PlcHelper.GetAddTypeHexaBitList().Contains(strHead))
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("X4"));
                        else
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("0000"));
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeWordList().Contains(strHead))
                        {
                            strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("X5"));
                            strAddressTemp = InsetString(strAddressTemp, 1, eModelRow.ADDRESSSPLIT);
                        }
                        else
                        {
                            if (PlcHelper.GetAddTypeHexaBitList().Contains(strHead))
                                strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("X4"));
                            else
                                strAddressTemp = string.Format("{0}{1}", strHead, nAddressIndex.ToString("0000"));
                        }

                        break;
                    default: break;
                }

                return strAddressTemp.ToUpper();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetAddHeadType(string Address)
        {
            try
            {
                string strType = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        strType = Address.Substring(0, 1); break;
                    case (ePLC_MAKER.SIEMENS):
                        strType = RemoveNumber(Address).Replace(".", string.Empty); break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (Address.StartsWith("SM") || Address.StartsWith("SW") || Address.StartsWith("SD") || Address.StartsWith("K") || (!Address.StartsWith("Z") && Address.Contains("Z")))
                            break;
                        if (Address.StartsWith("ZR"))
                            strType = Address.Substring(0, 2);
                        else
                            strType = Address.Substring(0, 1); break;
                    default: break;
                }

                return strType.ToUpper();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }


        public static string GetAddressBody(string text, int start)
        {
            try
            {
                string AddressBody = text;

                if (text.Length > start)
                    AddressBody = text.Substring(start, text.Length - start);

                return AddressBody;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }



        public static int GetAddBit(string AddressTemp)
        {
            try
            {
                string strHead = GetAddHeadType(AddressTemp);
                string strBit = GetAddressLast(AddressTemp, 1);
                int nBit = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(strHead))
                            strBit = GetAddressLast(AddressTemp, 2);

                        nBit = Convert.ToInt32(strBit);
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        nBit = Convert.ToInt32(strBit);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (GetAddTypeHexaBitList().Contains(strHead))
                            nBit = Convert.ToInt32(strBit, 16);
                        else
                            nBit = Convert.ToInt32(strBit, 10);
                        break;

                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeHexaBitList().Contains(strHead))
                            nBit = Convert.ToInt32(strBit, 16);
                        else
                            nBit = Convert.ToInt32(strBit, 10);
                        break;
                }
                return nBit;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetAddBlock(string AddressTemp)
        {
            try
            {
                string strBlock = string.Empty;
                string strHead = GetAddHeadType(AddressTemp);

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(strHead))
                            strBlock = AddressTemp.Substring(0, AddressTemp.Length - 2);
                        else
                            strBlock = AddressTemp.Substring(0, AddressTemp.Length - 1); break;
                    case (ePLC_MAKER.SIEMENS):
                        strBlock = AddressTemp.Substring(0, AddressTemp.Length - 1); break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strBlock = AddressTemp.Substring(0, AddressTemp.Length - 1); break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strBlock = AddressTemp.Substring(0, AddressTemp.Length - 1); break;
                    default: break;
                }

                return strBlock.TrimEnd('.');
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }



        public static string GetAddWithBlockIndex(int nBlockIndex, string strHeadType)
        {
            try
            {
                string strDefaultAdd = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(strHeadType))
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}.00", nBlockIndex), 7, "0");
                        else
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}0", nBlockIndex), 5, "0");
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (GetAddTypeDotList().Contains(strHeadType))
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}", nBlockIndex), 4, "0");
                        else
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}", nBlockIndex), 2, "0");
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (GetAddTypeHexaBlockList().Contains(strHeadType))
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0:X}0", nBlockIndex), 4, "0");
                        else
                            strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}0", nBlockIndex), 4, "0");
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeDotList().Contains(strHeadType))
                        {
                            if (GetAddTypeHexaBlockList().Contains(strHeadType))
                                strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0:X}.0", nBlockIndex), 6, "0");
                            else
                                strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}.0", nBlockIndex), 6, "0");
                        }
                        else
                        {
                            if (GetAddTypeHexaBlockList().Contains(strHeadType))
                                strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0:X}0", nBlockIndex), 4, "0");
                            else
                                strDefaultAdd = strHeadType + InsertStringAlign(string.Format("{0}0", nBlockIndex), 4, "0");
                        }
                        break;
                    default: break;
                }

                return strDefaultAdd;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        #endregion

        #region Block Methods

        public static int GetBlockIndex(string strBlock)
        {
            try
            {
                int nAddressIndex = 0;
                string strHead = GetAddHeadType(strBlock);
                string strBody = PlcHelper.GetAddressBody(strBlock, strHead.Length).Replace(".", string.Empty);

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (!CStringHelper.IsDigitString(strBody))
                            return 0;
                        nAddressIndex = Convert.ToInt32(strBody);
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (!CStringHelper.IsDigitString(strBody))
                            return 0;
                        nAddressIndex = Convert.ToInt32(strBody);
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (GetAddTypeHexaBlockList().Contains(strHead))
                            nAddressIndex = Convert.ToInt32(strBody, 16);
                        else
                            nAddressIndex = Convert.ToInt32(strBody, 10);
                        break;

                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeHexaBlockList().Contains(strHead))
                            nAddressIndex = Convert.ToInt32(strBody, 16);
                        else
                            nAddressIndex = Convert.ToInt32(strBody, 10);
                        break;

                    default: break;
                }

                return nAddressIndex;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetBlock(string strHead, int nBlockIndex)
        {
            try
            {
                string strBlock = string.Empty;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("0000"));
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (GetAddTypeDotList().Contains(strHead))
                            strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("0000"));
                        else
                            strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("000"));
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (PlcHelper.GetAddTypeHexaBlockList().Contains(strHead))
                            strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("X3"));
                        else
                            strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("000"));
                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeWordList().Contains(strHead))
                        {
                            if (PlcHelper.GetAddTypeHexaBlockList().Contains(strHead))
                                strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("X4"));
                            else
                                strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("0000"));
                        }
                        else
                        {
                            if (PlcHelper.GetAddTypeHexaBlockList().Contains(strHead))
                                strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("X3"));
                            else
                                strBlock = string.Format("{0}{1}", strHead, nBlockIndex.ToString("000"));
                        }

                        break;
                    default: break;
                }

                return strBlock.ToUpper();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }




        #endregion



        public static int GetBlockMaxItem(string HEADTYPE)
        {
            try
            {
                int nMaxUIOItemInBlock = 0;

                switch (_PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        if (GetAddTypeDotList().Contains(HEADTYPE))
                            nMaxUIOItemInBlock = 32;
                        else
                            nMaxUIOItemInBlock = 10;
                        break;
                    case (ePLC_MAKER.SIEMENS):
                        if (GetAddTypeDotList().Contains(HEADTYPE))
                            nMaxUIOItemInBlock = 8;
                        else
                            nMaxUIOItemInBlock = 10;
                        break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        if (GetAddTypeHexaBitList().Contains(HEADTYPE))
                            nMaxUIOItemInBlock = 16;
                        else
                            nMaxUIOItemInBlock = 10;

                        break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        if (GetAddTypeHexaBitList().Contains(HEADTYPE))
                            nMaxUIOItemInBlock = 16;
                        else
                            nMaxUIOItemInBlock = 10;

                        break;
                    default: break;
                }

                return nMaxUIOItemInBlock;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetTypeInput()
        {
            string HeadName = string.Empty;

            switch (_PLCMAKER)
            {
                case (ePLC_MAKER.AB_ALIAS):
                case (ePLC_MAKER.AB_COMMENT): HeadName = eADDRESS_TYPE_AB.INPUT; break;
                case (ePLC_MAKER.SIEMENS): HeadName = eADDRESS_TYPE_SIEMENS.INPUT; break;
                case (ePLC_MAKER.MITSUBISHI_DEVELOPER): HeadName = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.INPUT; break;
                case (ePLC_MAKER.MITSUBISHI_WORKS2): HeadName = eADDRESS_TYPE_MITSUBISHI_WORKS2.INPUT; break;
                default: break;
            }

            return HeadName;
        }

        public static string GetTypeOutput()
        {
            string HeadName = string.Empty;

            switch (_PLCMAKER)
            {
                case (ePLC_MAKER.AB_ALIAS):
                case (ePLC_MAKER.AB_COMMENT): HeadName = eADDRESS_TYPE_AB.OUTPUT; break;
                case (ePLC_MAKER.SIEMENS): HeadName = eADDRESS_TYPE_SIEMENS.OUTPUT; break;
                case (ePLC_MAKER.MITSUBISHI_DEVELOPER): HeadName = eADDRESS_TYPE_MITSUBISHI_DEVELOPER.OUTPUT; break;
                case (ePLC_MAKER.MITSUBISHI_WORKS2): HeadName = eADDRESS_TYPE_MITSUBISHI_WORKS2.OUTPUT; break;
                default: break;
            }

            return HeadName;
        }


        public static List<string> SplitListString(string str, string delimStr)
        {
            string[] delimiter = new string[] { delimStr };


            return new List<string>(str.Split(delimiter, StringSplitOptions.None));
        }

        public static List<string> SplitListString(string str, string delimStr, bool bRemoveEmptyEntries)
        {
            string[] delimiter = new string[] { delimStr };

            if (bRemoveEmptyEntries)
                return new List<string>(str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries));

            return new List<string>(str.Split(delimiter, StringSplitOptions.None));
        }

        public static string InsetString(string text, int EndCount, string InsertText)
        {
            string AddressBit = text;

            if (text.Length > EndCount)
                AddressBit = text.Substring(0, text.Length - EndCount) + InsertText + text.Substring(text.Length - EndCount, EndCount);

            return AddressBit;
        }

        public static string RemoveNumber(string text)
        {
            return Regex.Replace(text, @"\d", "");
        }

        public static string GetAddressLast(string text, int EndCount)
        {
            string AddressBit = text;

            if (text.Length > EndCount)
                AddressBit = text.Substring(text.Length - EndCount, EndCount);

            return AddressBit;
        }

        public static string NextHexaString(string name)
        {
            string strCurrentBlockHead = name.Substring(0, 1);
            string strCurrentBlockAddress = name.Substring(1, name.Length - 1);
            string strNextBlockAddress = string.Empty;
            int nAddress = Convert.ToInt32(strCurrentBlockAddress, 16);

            strNextBlockAddress = string.Format("{0:X}", ++nAddress);
            return strCurrentBlockHead + InsertStringAlign(strNextBlockAddress, strCurrentBlockAddress.Length, "0");
        }

        public static string NextDecString(string name)
        {
            string strCurrentBlockHead = name.Substring(0, 1);
            string strCurrentBlockAddress = name.Substring(1, name.Length - 1);
            string strNextBlockAddress = string.Empty;
            int nAddress = Convert.ToInt32(strCurrentBlockAddress);

            strNextBlockAddress = string.Format("{0}", ++nAddress);
            return strCurrentBlockHead + InsertStringAlign(strNextBlockAddress, strCurrentBlockAddress.Length, "0");
        }

        public static string InsertStringAlign(string strText, int nSize, string strInsert)
        {
            if (strText == string.Empty)
                return strText;

            for (int n = strText.Length; n < nSize; n++)
                strText = strText.Insert(0, strInsert);

            return strText;
        }


        public static string RelaceNumber(string text, string strReplace)
        {
            StringBuilder line = new StringBuilder();
            foreach (char ch in text)
            {
                if (CStringHelper.IsDigitString(ch.ToString()))
                {
                    if (line.Length == 0 || line.ToString(line.Length - 1, 1) != strReplace)
                        line.Append(strReplace);
                }
                else
                {
                    line.Append(ch);
                }
            }
            return line.ToString();
        }

        public static string GetSubStringBetween(string text, char bra, char ket)
        {
            if (text == null) return null;
            int braIndex = text.IndexOf(bra);
            if (braIndex > -1)
            {
                int ketIndex = text.IndexOf(ket);
                if (ketIndex > braIndex)
                {
                    return text.Substring(braIndex + 1, ketIndex - braIndex - 1);
                }
            }
            return String.Empty;
        }


        public static bool IsKoreanString(string text)
        {
            bool bHangul = false;

            char[] cLoginUserID = text.ToCharArray(0, text.Length);
            foreach (char c1 in cLoginUserID)
            {
                if (char.GetUnicodeCategory(c1) ==
                     System.Globalization.UnicodeCategory.OtherLetter)
                {
                    bHangul = true;
                    break;
                }
                else
                    bHangul = false;
            }
            return bHangul;

        }

        
        public static string GetLastSubStringBetween(string text, char bra, char ket)
        {
            if (text == null) return null;
            int braIndex = text.LastIndexOf(bra);
            if (braIndex > -1)
            {
                int ketIndex = text.LastIndexOf(ket);
                if (ketIndex > braIndex)
                {
                    return text.Substring(braIndex + 1, ketIndex - braIndex - 1);
                }
            }
            return String.Empty;
        }


        public static int CompareString(string textA1, string textB1)
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


        public static int CompareString(string textA1, string textB1, string textA2, string textB2, string textA3, string textB3)
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
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval1 = textA1.CompareTo(textB1);
                    if (retval1 != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval1;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        int retval2 = textA2.CompareTo(textB2);
                        if (retval2 != 0)
                        {
                            // If the strings are not of equal length,
                            // the longer string is greater.
                            //
                            return retval2;
                        }
                        else
                        {
                            return textA3.CompareTo(textB3);
                        }
                    }
                }
            }
        }

        public static string GetExcelTemplatePathIOLIST()
        {
            try
            {
                string strExcelTemplatePath = string.Empty;

                switch (PlcHelper._PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB\\IO_LIST_Template.xls"; break;
                    case (ePLC_MAKER.AB_COMMENT):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB_COMMENT\\IO_LIST_Template.xls"; break;
                    case (ePLC_MAKER.SIEMENS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\SIEMENS\\IO_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\IO_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\IO_LIST_Template.xls"; break;
                    default: break;
                }

                return strExcelTemplatePath;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetExcelTemplatePathDUMMYLIST()
        {
            try
            {
                string strExcelTemplatePath = string.Empty;

                switch (PlcHelper._PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB\\DUMMY_LIST_Template.xls"; break;
                    case (ePLC_MAKER.AB_COMMENT):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB_COMMENT\\DUMMY_LIST_Template.xls"; break;
                    case (ePLC_MAKER.SIEMENS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\SIEMENS\\DUMMY_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\DUMMY_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\DUMMY_LIST_Template.xls"; break;
                    default: break;
                }

                return strExcelTemplatePath;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetExcelTemplatePathLINKLIST()
        {
            try
            {
                string strExcelTemplatePath = string.Empty;

                switch (PlcHelper._PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB\\LINK_LIST_Template.xls"; break;
                    case (ePLC_MAKER.AB_COMMENT):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB_COMMENT\\LINK_LIST_Template.xls"; break;
                    case (ePLC_MAKER.SIEMENS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\SIEMENS\\LINK_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\LINK_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\LINK_LIST_Template.xls"; break;
                    default: break;
                }

                return strExcelTemplatePath;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetExcelTemplatePathTIMECOUNTERLIST()
        {
            try
            {
                string strExcelTemplatePath = string.Empty;

                switch (PlcHelper._PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB\\TIMER&COUNTER_LIST_Template.xls"; break;
                    case (ePLC_MAKER.AB_COMMENT):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\AB_COMMENT\\TIMER&COUNTER_LIST_Template.xls"; break;
                    case (ePLC_MAKER.SIEMENS):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\SIEMENS\\TIMER&COUNTER_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\TIMER&COUNTER_LIST_Template.xls"; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strExcelTemplatePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ExcelTemplate\\TIMER&COUNTER_LIST_Template.xls"; break;
                    default: break;
                }

                return strExcelTemplatePath;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

        public static string GetModuleConfigurationPath()
        {
            try
            {
                string strPath = string.Empty;

                switch (PlcHelper._PLCMAKER)
                {
                    case (ePLC_MAKER.AB_ALIAS):
                    case (ePLC_MAKER.AB_COMMENT):
                        strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\IOMAKER\\Configuration\\ModuleConfig_AB.xml"; break;
                    case (ePLC_MAKER.SIEMENS):
                        strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\IOMAKER\\Configuration\\ModuleConfig_S7.xml"; break;
                    case (ePLC_MAKER.MITSUBISHI_DEVELOPER):
                        strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\IOMAKER\\Configuration\\ModuleConfig_Melsec.xml"; break;
                    case (ePLC_MAKER.MITSUBISHI_WORKS2):
                        strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\IOMAKER\\Configuration\\ModuleConfig_Melsec.xml"; break;
                    default: break;
                }

                return strPath;
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}]", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw error;
            }
        }

    }
}