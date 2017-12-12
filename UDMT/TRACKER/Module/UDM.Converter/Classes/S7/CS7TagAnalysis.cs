using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7TagAnalysis
    {
        // Create by Qin Shiming At 2015.06.22
        //Second edit at 2015.07.03 by Qin Shiming

        #region MemberVariables
        protected CTagS m_dAddressTags = null;
        //protected CTagS m_dSymbolTags = null;

        protected List<string> m_lFileList = null;
        protected string m_sChannel = "[CH_DV]";
        protected List<string> m_lTotalError = null;

        protected int m_iInputTagCount = 0;
        protected int m_iOutputTagCount = 0;
        protected int m_iMemTagCount = 0;
       
        #endregion

        #region Initialze/Dispose

        public CS7TagAnalysis(List<string> sFile)
        {
            m_dAddressTags = new CTagS();
            //m_dSymbolTags = new CTagS();
            m_lTotalError = new List<string>();
            m_lFileList = sFile;
        }

        #endregion

        #region Public Properites

        public CTagS AddressTagDic
        {
            get { return m_dAddressTags; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        //public CTagS symboltagdic
        //{
        //    get { return m_dsymboltags; }
        //}

        public int InputTagCount
        {
            get { return m_iInputTagCount; }
        }

        public int OutputTagCount
        {
            get { return m_iOutputTagCount; }
        }
        public int MemoryTagCount
        {
            get { return m_iMemTagCount; }
        }
        public List<string> TotalError
        {
            get { return m_lTotalError; }
        }
        #endregion

        #region Public Methods

        public void TagFileAnalysis()
        {
            try
            {
                string nodedata = string.Empty;

                int iCount = m_lFileList.Count;

                for (int i = 0; i < iCount; i++)
                {
                    nodedata = m_lFileList[i];

                    if (nodedata.Length > 11)
                    {
                        string sSymbol = string.Empty;
                        string sAddress = string.Empty;
                        string sDatatype = string.Empty;
                        string sComment = string.Empty;

                        TextCutting(nodedata, ref sSymbol, ref sAddress, ref sDatatype, ref sComment);

                        sSymbol = NonAddressEdittor(sSymbol);
                        sAddress = AddressEdittor(sAddress);
                        sDatatype = AddressEdittor(sDatatype);
                        sComment = NonAddressEdittor(sComment);

                        sSymbol = "\"" + sSymbol + "\"";

                        if (sAddress.StartsWith("I"))
                            m_iInputTagCount= m_iInputTagCount + 1;
                        else if (sAddress.StartsWith("Q"))
                            m_iOutputTagCount = m_iOutputTagCount + 1;
                        else if (sAddress.StartsWith("M"))
                            m_iMemTagCount = m_iMemTagCount + 1;
                        
                        if (CheckIsBlockTag(sDatatype))
                            BlockTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else if (CheckIsUDTTag(sDatatype))
                            UDTTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else if (CheckIsSimpleType(sDatatype))
                            SimpleTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else
                            UDTTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);

                        if (sSymbol.Contains("종합이상")||(sSymbol.Contains("TOTAL")&& sSymbol.Contains("ERR")))
                        {
                            if(!m_lTotalError.Contains(sAddress))
                                m_lTotalError.Add(sAddress);
                        }
                        else if (sComment.Contains(" ERROR ")|| sComment.Contains(" ABNORMAL "))
                        {
                            if (!m_lTotalError.Contains(sAddress))
                                m_lTotalError.Add(sAddress);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void TextCutting(string nodedata, ref string sSymbol, ref string sAddress, ref string sDatatype, ref string sComment)
        {
            try
            {
                if (nodedata.StartsWith("\""))
                    nodedata = nodedata.Substring(1);

                if (nodedata.Length > 10)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        string sTemp = string.Empty;

                        sTemp = TextCutter(nodedata);

                        switch (i)
                        {
                            case 0: sSymbol = sTemp; break;
                            case 1: sAddress = sTemp; break;
                            case 2: sDatatype = sTemp; break;
                            case 3: sComment = sTemp; break;
                        }
                        if (nodedata.IndexOf("\",\"") > 0)
                        {
                            int iPos = nodedata.IndexOf("\",\"");
                            nodedata = nodedata.Substring(iPos + 3);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string TextCutter(string nodedata)
        {
            string sTemp = string.Empty;
            try
            {
                if (nodedata.IndexOf("\",\"") > 0)
                {
                    int iPos = nodedata.IndexOf("\",\"");
                    sTemp = nodedata.Remove(iPos);
                }
                else
                {
                    int iLength = nodedata.Length;
                    sTemp = nodedata.Remove(iLength - 1);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return sTemp;
        }

        private string AddressEdittor(string nodedata)
        {
            try
            {
                nodedata = nodedata.Replace(" ", "");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return nodedata;
        }

        private string NonAddressEdittor(string nodedata)
        {
            try
            {
                while (nodedata.StartsWith(" "))
                {
                    nodedata = nodedata.Substring(1);
                }

                int length = nodedata.Length;

                while (nodedata.EndsWith(" "))
                {
                    nodedata = nodedata.Remove(length - 1);
                    length = nodedata.Length;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return nodedata;
        }

        private bool CheckIsBlockTag(string nodedata)
        {
            bool bIsBlock = false;
            try
            {
                if (nodedata.StartsWith("DB"))
                    bIsBlock = true;
                else if (nodedata.StartsWith("FB"))
                    bIsBlock = true;
                else if (nodedata.StartsWith("FC"))
                    bIsBlock = true;
                else if (nodedata.StartsWith("OB"))
                    bIsBlock = true;
                else if (nodedata.StartsWith("SFC"))
                    bIsBlock = true;
                else if (nodedata.StartsWith("SFB"))
                    bIsBlock = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bIsBlock;
        }

        private bool CheckIsUDTTag(string nodedata)
        {
            bool bIsUDT = false;
            try
            {
                if (nodedata.StartsWith("UDT"))
                    bIsUDT = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bIsUDT;
        }

        private bool CheckIsSimpleType(string nodedata)
        {
            bool bIsSimpleType = false;
            try
            {
                switch (nodedata)
                {
                    case "BOOL":
                    case "BYTE":
                    case "INT":
                    case "DINT":
                    case "WORD":
                    case "DWORD":
                    case "TIMER":
                    case "REAL":
                    case "COUNTER":
                    case "TIME":
                    case "STRING":
                    case "S5TIME":
                    case "TIME_OF_DAY":
                    case "DATE_AND_TIME":
                    case "DATE":
                    case "ANY":
                    case "CHAR": bIsSimpleType = true; break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bIsSimpleType;
        }

        private void SimpleTypeTagAnalysis(string sSymbol, string sAddress, string sDatatype, string sComment)
        {
            try
            {
                CTag cTag = null;
                cTag = new CTag();
                cTag.Name = sSymbol;
                cTag.Address = sAddress;
                
                if (sAddress == "")
                    cTag.Key = m_sChannel + sSymbol + "[1]";
                else
                    cTag.Key = m_sChannel + sAddress + "[1]";

                cTag.Channel = m_sChannel;
                cTag.Size = 1;
                cTag.Description = sSymbol;

                switch (sDatatype)
                {
                    case "BOOL": cTag.DataType = EMDataType.Bool; break;
                    case "BYTE": cTag.DataType = EMDataType.Byte; break;
                    case "INT": cTag.DataType = EMDataType.Int; break;
                    case "DINT": cTag.DataType = EMDataType.DInt; break;
                    case "WORD": cTag.DataType = EMDataType.Word; break;
                    case "DWORD": cTag.DataType = EMDataType.DWord;break;
                    case "TIMER": cTag.DataType = EMDataType.Timer; break;
                    case "REAL": cTag.DataType = EMDataType.Real; break;
                    case "COUNTER": cTag.DataType = EMDataType.Counter; break;
                    case "TIME": cTag.DataType = EMDataType.Time; break;
                    case "STRING": cTag.DataType = EMDataType.String; break;
                    case "S5TIME": cTag.DataType = EMDataType.S5Time; break;
                    case "TIME_OF_DAY": cTag.DataType = EMDataType.Time_Of_Day; break;
                    case "DATE_AND_TIME": cTag.DataType = EMDataType.Date_And_Time; break;
                    case "DATE": cTag.DataType = EMDataType.Date; break;
                    case "ANY": cTag.DataType = EMDataType.Any; break;
                    case "CHAR": cTag.DataType = EMDataType.Char; break;
                }

                //m_dAddressTags.Add(sAddress, cTag);
                m_dAddressTags.Add(cTag.Key, cTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void BlockTypeTagAnalysis(string sSymbol, string sAddress, string sDatatype, string sComment)
        {
            try
            {
                CTag cTag = null;
                cTag = new CTag();
                cTag.Name = sSymbol;
                cTag.Address = sAddress;
                if (sAddress == "")
                    cTag.Key = m_sChannel + sSymbol + "[1]";
                else
                    cTag.Key = m_sChannel + sAddress + "[1]";
                cTag.Channel = m_sChannel;
                cTag.Size = 1;

                cTag.Description = sSymbol;
                cTag.DataType = EMDataType.Block;
                cTag.UDTType = sDatatype;

                m_dAddressTags.Add(cTag.Key, cTag);
                //m_dAddressTags.Add(sAddress, cTag);
                //m_dSymbolTags.Add(sSymbol, mTag);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UDTTypeTagAnalysis(string sSymbol, string sAddress, string sDatatype, string sComment)
        {
            try
            {
                CTag cTag = null;
                cTag = new CTag();
                cTag.Name = sSymbol;
                cTag.Address = sAddress;

                if (sAddress == "")
                    cTag.Key = m_sChannel + sSymbol + "[1]";
                else
                    cTag.Key = m_sChannel + sAddress + "[1]";

                cTag.Channel = m_sChannel;
                cTag.Size = 1;

                cTag.Description = sSymbol;
                cTag.DataType = EMDataType.UserDefDataType;
                cTag.UDTType = sDatatype;

                m_dAddressTags.Add(cTag.Key, cTag);
                //m_dAddressTags.Add(sAddress, cTag);
                //m_dSymbolTags.Add(sSymbol, mTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        #endregion
    }
}
