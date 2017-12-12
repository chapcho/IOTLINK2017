using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using UDM.General.Xml;
using UDM.Common;
using UDM.UDL;
using System.IO;
using System.Reflection;

namespace UDM.UDLImport
{
    public class CInstruXmlOpen
    {
        protected Dictionary<string, CInstruction> m_DicInstructionList = new Dictionary<string, CInstruction>();
        protected Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;
        protected string m_sPLCMaker = string.Empty;

        #region Initialize/Dispose

        public CInstruXmlOpen(EMPLCMaker emPLCMaker)
        {
            try
            {
                m_sPLCMaker = GetPLCMaker(emPLCMaker);
                FileOpen();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Properties

        public Dictionary<string, CInstruction> DicInstructionList
        {
            get { return m_DicInstructionList; }
        }

        public Dictionary<string, List<CInstruction>> DicRepeatedInstructionList
        {
            get { return m_DicRepeatedInstructionList; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void FileOpen()
        {
            XmlElement NodeDebug = null;

            try
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.LoadXml(Properties.Resources.TotalInstruListNew);

                XmlNode MainNode = xmlFile.SelectSingleNode("InstructionList");
                XmlNodeList InstructionList = MainNode.ChildNodes;

                foreach(XmlNode Instruction in InstructionList)
                {
                    XmlElement InstrucElement = (XmlElement)Instruction;
                    NodeDebug = InstrucElement;

                    string sInstruName = InstrucElement.GetAttribute("Name").ToString();

                    if (Instruction.ChildNodes.Count != 0)
                    {
                        XmlNodeList CommandList = Instruction.ChildNodes;
                        CheckCommandS(CommandList, sInstruName);
                    }
                    else
                        continue;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]\n Error Node : {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, NodeDebug.GetAttribute("Name").ToString()); 
                ex.Data.Clear();
            }
        }

        private void CheckCommandS(XmlNodeList CommandList, string sInstruName)
        {
            XmlElement NodeDebug = null;

            try
            {
                CInstruction cInstruction = null; 

                foreach (XmlNode Command in CommandList)
                {
                    XmlElement CommandElement = (XmlElement)Command;
                    NodeDebug = CommandElement;

                    string sPLCMaker = CommandElement.GetAttribute("Maker").ToString();

                    if (sPLCMaker == m_sPLCMaker)
                    {
                        cInstruction = new CInstruction();
                        MakeInstructionList(CommandElement, cInstruction, sInstruName);

                        if(Command.ChildNodes.Count != 0)
                        {
                            XmlNodeList LabelList = Command.ChildNodes;
                            CheckLabelS(LabelList, cInstruction);
                        }
                    }
                    else
                        continue;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]\n Error Node : {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, NodeDebug.GetAttribute("Name").ToString());
                ex.Data.Clear();
            }
        }

        private void CheckLabelS(XmlNodeList LabelList, CInstruction cInstruction)
        {
            XmlElement NodeDebug = null;

            try
            {
                bool bCheckSourceLabel = false;

                foreach(XmlNode Label in LabelList)
                {
                    XmlElement LabelElement = (XmlElement)Label;
                    NodeDebug = LabelElement;

                    if (LabelElement.Name.Equals("SourceLabel"))
                        bCheckSourceLabel = true;
                    else if (LabelElement.Name.Equals("CoilLabel"))
                        bCheckSourceLabel = false;

                    XmlNodeList LabelContentList = Label.ChildNodes;
                    CheckLabelContentS(LabelContentList, cInstruction, bCheckSourceLabel);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]\n Error Node : {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, NodeDebug.GetAttribute("Name").ToString());
                ex.Data.Clear();
            }
        }

        private void CheckLabelContentS(XmlNodeList LabelContentList, CInstruction cInstruction, bool bCheckSourceLabel)
        {
            XmlElement NodeDebug = null;

            try
            {
                foreach(XmlNode LabelContent in LabelContentList)
                {
                    XmlElement LabelContentElement = (XmlElement)LabelContent;
                    NodeDebug = LabelContentElement;
                    MakeInstructionLabel(LabelContentElement, cInstruction, bCheckSourceLabel);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]\n Error Node : {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, NodeDebug.GetAttribute("Name").ToString());
                ex.Data.Clear();
            }
        }

        private void MakeInstructionList(XmlElement CommandElement, CInstruction cInstruction, string sInstruName)
        {
            try
            {
                string sCommand = CommandElement.GetAttribute("Name").ToString();
                string sSourceLabelNum = CommandElement.GetAttribute("SourceLabelNum").ToString();
                string sSourceLabelNum1 = CommandElement.GetAttribute("SourceLabelNum1").ToString();
                string sSourceLabelNum2 = CommandElement.GetAttribute("SourceLabelNum2").ToString();
                string sCoilLabelNum = CommandElement.GetAttribute("CoilLabelNum").ToString();
                string sCoilLabelNum1 = CommandElement.GetAttribute("CoilLabelNum1").ToString();
                string sCoilLabelNum2 = CommandElement.GetAttribute("CoilLabelNum2").ToString();

                cInstruction.Instruction = sInstruName;
                cInstruction.Command = sCommand;
                cInstruction.SourceLabelNum = Int32.Parse(sSourceLabelNum);
                cInstruction.CoilLabelNum = Int32.Parse(sCoilLabelNum);

                if (sSourceLabelNum1 != string.Empty)
                    cInstruction.SourceLabelNum_Sub1 = Int32.Parse(sSourceLabelNum1);
                if (sSourceLabelNum2 != string.Empty)
                    cInstruction.SourceLabelNum_Sub2 = Int32.Parse(sSourceLabelNum2);
                if (sCoilLabelNum1 != string.Empty)
                    cInstruction.CoilLabelNum_Sub1 = Int32.Parse(sCoilLabelNum1);
                if (sCoilLabelNum2 != string.Empty)
                    cInstruction.CoilLabelNum_Sub2 = Int32.Parse(sCoilLabelNum2);

                if (m_DicRepeatedInstructionList != null && m_DicRepeatedInstructionList.ContainsKey(cInstruction.Command))
                    m_DicRepeatedInstructionList[cInstruction.Command].Add(cInstruction);
                else if (m_DicInstructionList.ContainsKey(cInstruction.Command))
                {
                    string sKey = cInstruction.Command;

                    if (m_DicRepeatedInstructionList == null)
                        m_DicRepeatedInstructionList = new Dictionary<string, List<CInstruction>>();

                    CInstruction cRepeatedInstruction = m_DicInstructionList[sKey];

                    m_DicRepeatedInstructionList.Add(sKey, new List<CInstruction>());
                    m_DicRepeatedInstructionList[sKey].Add(cRepeatedInstruction);

                    m_DicInstructionList.Remove(sKey);

                    m_DicRepeatedInstructionList[sKey].Add(cInstruction);
                }
                else
                    m_DicInstructionList.Add(cInstruction.Command, cInstruction);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void MakeInstructionLabel(XmlElement LabelElement, CInstruction cInstruction, bool bCheckSourceLabel)
        {
            try
            {
                if (bCheckSourceLabel)
                {
                    if (cInstruction.SourceLabel == null)
                        cInstruction.SourceLabel = new List<CLabel>();
                }
                else
                {
                    if (cInstruction.CoilLabel == null)
                        cInstruction.CoilLabel = new List<CLabel>();
                }

                CLabel cLabel = new CLabel();

                string sName = LabelElement.GetAttribute("Name").ToString();
                string sDataType = LabelElement.GetAttribute("Datatype").ToString();
                string sLabelIndex = LabelElement.GetAttribute("LabelIndex").ToString();
                string sConstant = LabelElement.GetAttribute("Constant").ToString();

                cLabel.Name = sName;
                cLabel.LabelIndex = Int32.Parse(sLabelIndex);
                cLabel.Constant = GetConstant(sConstant);
                
                if(sDataType != string.Empty)
                    cLabel.lstDataType = GetDataTypes(sDataType);

                if (bCheckSourceLabel)
                    cInstruction.SourceLabel.Add(cLabel);
                else
                    cInstruction.CoilLabel.Add(cLabel);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetPLCMaker(EMPLCMaker emPLCMaker)
        {
            string sPLCMaker = string.Empty;

            try
            {
                switch (emPLCMaker)
                {
                    case EMPLCMaker.Mitsubishi :
                    case EMPLCMaker.Mitsubishi_Developer :
                    case EMPLCMaker.Mitsubishi_Works2 :
                    case EMPLCMaker.Mitsubishi_Works3: sPLCMaker = "Mitsubishi"; break;
                        
                    case EMPLCMaker.Siemens : sPLCMaker = "Siemens"; break;

                    case EMPLCMaker.LS : sPLCMaker = "LS"; break;

                    case EMPLCMaker.Rockwell : sPLCMaker = "AB"; break;    
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return sPLCMaker;
        }

        private List<EMDataType> GetDataTypes(string sDataType)
        {
            List<EMDataType> lstemDataType = new List<EMDataType>();
            List<string> lstDefinedDataType = new List<string> { "None", "Bool", "Byte", "Word", "DWord", "Block", "Any", "Int", "DInt"
                , "Real", "Timer", "Time", "Counter", "Char", "String", "S5Time", "Date", "Time_Of_Day", "Date_And_Time", "UserDefDataType" };

            try
            {
                if (sDataType.Contains(","))
                {
                    string[] sSplitDataType = sDataType.Split(',');

                    for (int i = 0; i < sSplitDataType.Length; i++)
                    {
                        EMDataType TempDataType = GetDataType(sSplitDataType[i]);
                        lstemDataType.Add(TempDataType);
                    }
                }
                else
                {
                    EMDataType TempDataType = GetDataType(sDataType);
                    lstemDataType.Add(TempDataType);
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return lstemDataType;
        }

        private EMDataType GetDataType(string sDataType)
        {
            EMDataType emDataType =EMDataType.None;
            try
            {
                switch(sDataType)
                {
                    case "Bool": emDataType = EMDataType.Bool; break;
                    case "Byte": emDataType = EMDataType.Byte; break;
                    case "Word": emDataType = EMDataType.Word; break;
                    case "DWord": emDataType = EMDataType.DWord; break;
                    case "Block": emDataType = EMDataType.Block; break;
                    case "Any": emDataType = EMDataType.Any; break;
                    case "Int": emDataType = EMDataType.Int; break;
                    case "DInt": emDataType = EMDataType.DInt; break;
                    case "Real": emDataType = EMDataType.Real; break;
                    case "Timer": emDataType = EMDataType.Timer; break;
                    case "Time": emDataType = EMDataType.Time; break;
                    case "Counter": emDataType = EMDataType.Counter; break;
                    case "Char": emDataType = EMDataType.Char; break;
                    case "String": emDataType = EMDataType.String; break;
                    case "S5Time": emDataType = EMDataType.S5Time; break;
                    case "Date": emDataType = EMDataType.Date; break;
                    case "Time_Of_Day": emDataType = EMDataType.Time_Of_Day; break;
                    case "Date_And_Time": emDataType = EMDataType.Date_And_Time; break;
                    case "UserDefDataType": emDataType = EMDataType.UserDefDataType; break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return emDataType;
        }

        private bool GetConstant(string sConstant)
        {
            bool bOK = false;
            try
            {
                switch(sConstant)
                {
                    case "TRUE" :
                    case "true" :
                    case "True": bOK = true; break;

                    case "FALSE" :
                    case "false" :
                    case "False": bOK = false; break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bOK;
        }

        #endregion
    }
}
