using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using UDM.UDL;
using UDM.Common;
using System.Resources;
using System.Reflection;

namespace UDM.UDLImport
{
    public class CSfcXmlOpen
    {
        protected Dictionary<string, CUDLBlock> m_dicSystemBlockS = new Dictionary<string, CUDLBlock>();

        protected EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        protected List<string> m_lstByteSizeDatatype = new List<string>() { "Byte", "Char" };
        protected List<string> m_lstWordSizeDatatype = new List<string>() { "Word", "Int", "S5Time","Date" };
        protected List<string> m_lstDwordSizeDatatype = new List<string>() { "Dword", "Dint", "Real", "Time", "Time_Of_Day","Date_And_Time" };

        #region Initialize/Dispose

        public CSfcXmlOpen(EMPLCMaker plcmaker)
        {
            m_emPLCMaker = plcmaker;

            FileOpen();


        }

        #endregion

        #region Public Properties

        public Dictionary<string,CUDLBlock> SystemBlockS
        {
            get { return m_dicSystemBlockS; }
        }

        #endregion

        #region Private Methods

        private void FileOpen()
        {
            try
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.LoadXml(Properties.Resources.SystemFuncAndFBList);

                XmlNode MainNode = xmlFile.SelectSingleNode("SystemFC_FB_List");

                XmlNodeList sfbList = MainNode.ChildNodes;

                foreach (XmlNode sfb in sfbList)
                {
                    XmlElement sfbElement = (XmlElement)sfb;

                    string sPLCMaker = sfbElement.GetAttribute("PLCMaker").ToString();
                    if(sPLCMaker == m_emPLCMaker.ToString())
                    {
                        string sSFBName = sfbElement.GetAttribute("Name").ToString();
                        string sSFBSymbol = sfbElement.GetAttribute("Symbol").ToString();
                        string ssFBDescription = sfbElement.GetAttribute("Dexcription").ToString();

                        CUDLBlock tempBlock = new CUDLBlock();
                        tempBlock.BlockName = sSFBName;
                        tempBlock.BlockAddress = sSFBSymbol;
                        tempBlock.Comment = ssFBDescription;

                        if (sSFBName.StartsWith("SFC"))
                            tempBlock.BlockType = EMBlockType.Function;
                        else if (sSFBName.StartsWith("SFB"))
                            tempBlock.BlockType = EMBlockType.FunctionBlock;

                        XmlNodeList LabelList = sfb.ChildNodes;

                        CheckLabelS(tempBlock, LabelList);

                        m_dicSystemBlockS.Add(sSFBName, tempBlock);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CheckLabelS(CUDLBlock tempBlock, XmlNodeList laberList)
        {
            try
            {
                foreach(XmlNode labelNode in laberList)
                {
                    CUDLTag tempTag = new CUDLTag();
                    XmlElement labelElement = (XmlElement)labelNode;

                    string sLabelName = labelElement.GetAttribute("Name").ToString();
                    string sDatatype = labelElement.GetAttribute("Datatype").ToString();
                    string sUsage = labelElement.GetAttribute("Usage").ToString();
                    string sAddress = labelElement.GetAttribute("Address").ToString();

                    sAddress = LabelAddressTrans(sAddress, sDatatype);

                    tempTag.Name = tempBlock.BlockAddress + "." + sLabelName;
                    tempTag.Address = tempBlock.BlockName + "." + sLabelName;

                    tempTag.Datatype = FindDatatype(sDatatype);

                    if (sUsage == "Input")
                        tempBlock.InputTags.Add(tempTag);
                    else if (sUsage == "Output")
                        tempBlock.OutputTags.Add(tempTag);
                    else if (sUsage == "InOut")
                        tempBlock.InOutTags.Add(tempTag);
                    else if (sUsage == "Temp")
                        tempBlock.TempTags.Add(tempTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private string LabelAddressTrans(string sAddress,string sdatatype)
        {
            string NewAddress = string.Empty;

            try
            {
                if(sAddress!=string.Empty)
                {
                    double tempDoub = Convert.ToDouble(sAddress);

                    if (sdatatype == "Bool")
                        NewAddress = "DBX" + sAddress;
                    else if (m_lstByteSizeDatatype.Contains(sdatatype))
                    {
                        int iTemp = Convert.ToInt32(tempDoub);
                        NewAddress = "DBB" + iTemp.ToString();
                    }
                    else if (m_lstWordSizeDatatype.Contains(sdatatype))
                    {
                        int iTemp = Convert.ToInt32(tempDoub);
                        NewAddress = "DBD" + iTemp.ToString();
                    }
                    else if (sdatatype == "Any")
                    {
                        int iTemp = Convert.ToInt32(tempDoub);
                        NewAddress = "DBW" + iTemp.ToString();
                    }
                    else if (sdatatype == "String")
                    {
                        int iTemp = Convert.ToInt32(tempDoub);
                        NewAddress = "DBW" + iTemp.ToString();
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return NewAddress;
        }

        private EMDataType FindDatatype (string sdatatype)
        {
            EMDataType datatype = EMDataType.None;

            switch(sdatatype)
            {
                case "Bool": datatype = EMDataType.Bool; break;
                case "Byte": datatype = EMDataType.Byte; break;
                case "Char": datatype = EMDataType.Char; break;
                case "Int": datatype = EMDataType.Int; break;
                case "Word": datatype = EMDataType.Word; break;
                case "S5Time": datatype = EMDataType.S5Time; break;
                case "Date": datatype = EMDataType.Date; break;
                case "Dword": datatype = EMDataType.DWord; break;
                case "Dint": datatype = EMDataType.DInt; break;
                case "Real": datatype = EMDataType.Real; break;
                case "Time": datatype = EMDataType.Time; break;
                case "Time_Of_Day": datatype = EMDataType.Time_Of_Day; break;
                case "Date_And_Time": datatype = EMDataType.Date_And_Time; break;
                case "String": datatype = EMDataType.String; break;
                case "Any": datatype = EMDataType.Any; break;
            }

            return datatype;
        }
        #endregion


    }
}
