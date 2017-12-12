using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;

namespace UDM.UDLImport
{
    public class CS7TagImport
    {
        protected List<string> m_lstSDFFile = null;
        protected List<CUDLTag> m_lstUDLTag = null;

        protected string m_sChannel = "[CH_DV]";

        #region Initialze/Dispose

        public CS7TagImport(List<string> sFile)
        {
            m_lstSDFFile = sFile;
            m_lstUDLTag = new List<CUDLTag>();
        }

        #endregion

        #region Public Properites

        public List<CUDLTag> UDLTagList
        {
            get { return m_lstUDLTag; }
            set { m_lstUDLTag = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        #endregion

        #region Public Methods

        public void TagFileAnalysis()
        {
            try
            {
                string nodedata = string.Empty;

                int iCount = m_lstSDFFile.Count;

                for(int i =0;i<iCount;i++)
                {
                    nodedata = m_lstSDFFile[i];

                    if(nodedata.Length>11)
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

                        if (CheckIsBlockTag(sDatatype))
                            BlockTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else if (CheckIsUDTTag(sDatatype))
                            UDTTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else if (CheckIsSimpleType(sDatatype))
                            SimpleTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                        else
                            UDTTypeTagAnalysis(sSymbol, sAddress, sDatatype, sComment);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public CTagS GetAddressListTagS()
        {
            CTagS cTempTagS = new CTagS();
            try
            {
                int iCount = m_lstUDLTag.Count;

                for(int i=0;i<iCount;i++)
                {
                    CTag tempTag = classTagGenerator(m_lstUDLTag[i]);

                    if(tempTag.Address =="")
                    {
                        if (!cTempTagS.ContainsKey(tempTag.Key))
                        {
                            cTempTagS.Add(tempTag.Key, tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Symbel : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }
                    }
                    else
                    {
                        if(!cTempTagS.ContainsKey(tempTag.Address))
                        {
                            cTempTagS.Add(tempTag.Address, tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Address : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return cTempTagS;
        }

        public CTagS GetSymbelListTagS()
        {
            CTagS cTempTagS = new CTagS();
            try
            {
                int iCount = m_lstUDLTag.Count;

                for (int i = 0; i < iCount; i++)
                {
                    CTag tempTag = classTagGenerator(m_lstUDLTag[i]);

                    if (tempTag.Key == "")
                    {

                        if (!cTempTagS.ContainsKey(tempTag.Address))
                        {
                            cTempTagS.Add(tempTag.Address, tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Address : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }
                        
                    }
                    else
                    {
                        if (!cTempTagS.ContainsKey(tempTag.Key))
                        {
                            cTempTagS.Add(tempTag.Key, tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Symbel : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return cTempTagS;
        }

        public CTagS GetKeyListTagS()
        {
            CTagS cTempTagS = new CTagS();

            try
            {
                int iCount = m_lstUDLTag.Count;

                for (int i = 0; i < iCount; i++)
                {
                    CTag tempTag = classTagGenerator(m_lstUDLTag[i]);

                    if (tempTag.Key == "")
                    {

                        if (!cTempTagS.ContainsKey(tempTag.Address))
                        {
                            cTempTagS.Add(m_sChannel + tempTag.Address + "[1]", tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Address : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }

                    }
                    else
                    {
                        if (!cTempTagS.ContainsKey(tempTag.Key))
                        {
                            cTempTagS.Add(tempTag.Key, tempTag);
                        }
                        else
                        {
                            Console.WriteLine("There are one tag using repetitive Symbel : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cTempTagS;
        }

        #endregion

        #region private Methods

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
                CUDLTag mTag = new CUDLTag();

                mTag.Name = sSymbol;
                mTag.Address = sAddress;
                mTag.Description = sComment;
                mTag.PLCMaker = EMPLCMaker.Siemens;
                switch (sDatatype)
                {
                    case "BOOL": mTag.Datatype= EMDataType.Bool; break;
                    case "BYTE": mTag.Datatype= EMDataType.Byte; break;
                    case "INT": mTag.Datatype= EMDataType.Int; break;
                    case "DINT": mTag.Datatype = EMDataType.DInt; break;
                    case "WORD": mTag.Datatype= EMDataType.Word; break;
                    case "DWORD": mTag.Datatype = EMDataType.DWord; break;
                    case "TIMER": mTag.Datatype = EMDataType.Timer; break;
                    case "REAL": mTag.Datatype= EMDataType.Real; break;
                    case "COUNTER": mTag.Datatype = EMDataType.Counter; break;
                    case "TIME": mTag.Datatype= EMDataType.Time; break;
                    case "STRING": mTag.Datatype = EMDataType.String; break;
                    case "S5TIME": mTag.Datatype = EMDataType.S5Time; break;
                    case "TIME_OF_DAY": mTag.Datatype = EMDataType.Time_Of_Day; break;
                    case "DATE_AND_TIME": mTag.Datatype = EMDataType.Date_And_Time; break;
                    case "DATE": mTag.Datatype= EMDataType.Date; break;
                    case "ANY": mTag.Datatype= EMDataType.Any; break;
                    case "CHAR": mTag.Datatype= EMDataType.Char; break;
                }

                m_lstUDLTag.Add(mTag);
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
                CUDLTag mTag = new CUDLTag();

                mTag.Name = sSymbol;
                mTag.Address = sAddress;
                mTag.Description = sComment;
                mTag.Datatype = EMDataType.Block;
                mTag.UDTType = sDatatype;
                mTag.PLCMaker = EMPLCMaker.Siemens;
                m_lstUDLTag.Add(mTag);

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
                CUDLTag mTag = new CUDLTag();

                mTag.Name = sSymbol;
                mTag.Address = sAddress;
                mTag.Description = sComment;
                mTag.Datatype = EMDataType.UserDefDataType;
                mTag.UDTType = sDatatype;
                mTag.PLCMaker = EMPLCMaker.Siemens;

                m_lstUDLTag.Add(mTag);
               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private CTag classTagGenerator(CUDLTag tagData)
        {
            CTag cTempTag = new CTag();
            try
            {
                cTempTag.Name = tagData.Name;
                cTempTag.Address = tagData.Address;
                cTempTag.Description = tagData.Description;
                cTempTag.DataType = tagData.Datatype;

                cTempTag.Size = 1;

                if (m_sChannel != "")
                {
                    cTempTag.Key = m_sChannel + tagData.Name + "[1]";
                    cTempTag.Channel = m_sChannel;
                }
                else
                {
                    cTempTag.Key = tagData.Name + "[1]";
                }

                if(cTempTag.DataType == EMDataType.UserDefDataType|| cTempTag.DataType == EMDataType.Block)
                {
                    cTempTag.UDTType = tagData.UDTType;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return cTempTag;
        }

        #endregion
    }
}
