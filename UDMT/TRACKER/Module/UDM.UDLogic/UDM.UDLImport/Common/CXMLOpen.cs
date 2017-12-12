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
    public class CXMLOpen
    {
        protected Dictionary<string, CInstruction> m_DicInstructionList = new Dictionary<string, CInstruction>();
        protected Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;
        protected string m_sPLCMaker = string.Empty;

        #region Initialize/Dispose

        public CXMLOpen(EMPLCMaker emPLCMaker)
        {
            try
            {
                m_sPLCMaker = GetPLCMaker(emPLCMaker);

                string sTemp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string sFilePath = Path.Combine("Instruction List", "TotalInstruListNew.xml");

                if (File.Exists(sFilePath))
                    FileOpen(sFilePath);
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

        private void FileOpen(string sFilePath)
        {
            string sDebugCommand = string.Empty;
            try
            {
                CXmlReader cXmlReader = new CXmlReader();
                CXmlElement cXmlElement = null;

                CInstruction cInstruction = null;
                string sInstruction = string.Empty;

                bool bSourceLabelMakerCheck = false;

                bool bOK = false;
                bOK = cXmlReader.Open(sFilePath);

                bool bSourceLabelCheck = false;

                while(true)
                {
                    cXmlElement = cXmlReader.Read();

                    if (cXmlReader.EOF)
                        break;

                    if (cXmlElement.Name.Equals("Instruction"))
                    {
                        sInstruction = cXmlElement.GetValue("Name");
                        sDebugCommand = sInstruction;

                        cXmlElement = cXmlReader.Read();

                        while(!cXmlElement.Name.Equals("Instruction"))
                        {
                            if (cXmlElement.Name.Contains("Command"))
                            {
                                if (cXmlElement.GetValue("Maker") == m_sPLCMaker)
                                {
                                    cInstruction = new CInstruction();
                                    cInstruction.Instruction = sInstruction;

                                    MakeInstructionList(cXmlElement, cInstruction);

                                    sDebugCommand = cInstruction.Command;

                                    bSourceLabelMakerCheck = true;
                                }
                                else
                                    bSourceLabelMakerCheck = false;
                            }

                            if (bSourceLabelMakerCheck && cXmlElement.Name.Contains("SourceLabel") 
                                || bSourceLabelMakerCheck && cXmlElement.Name.Contains("CoilLabel"))
                            {
                                if (cXmlElement.Name.Contains("SourceLabel"))
                                    bSourceLabelCheck = true;
                                else
                                    bSourceLabelCheck = false;

                                cXmlElement = cXmlReader.Read();
                                sDebugCommand = cInstruction.Command;

                                while (!cXmlElement.Name.Contains("SourceLabel") && !cXmlElement.Name.Contains("CoilLabel"))
                                {
                                    MakeInstructionLabel(cXmlElement, cInstruction, bSourceLabelCheck);
                                    cXmlElement = cXmlReader.Read();
                                }
                            }
                            cXmlElement = cXmlReader.Read();
                        }//</Instruction> 일 때 빠져나옴
                    }
                }               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}], Command : {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sDebugCommand); ex.Data.Clear();
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

        private void MakeInstructionList(CXmlElement cXmlElement, CInstruction cInstruction)
        {
            cInstruction.Command = cXmlElement.GetValue("Name");

            if(cXmlElement.GetValue("SourceLabelNum") != string.Empty)
                cInstruction.SourceLabelNum = Int32.Parse(cXmlElement.GetValue("SourceLabelNum"));
            if (cXmlElement.GetValue("SourceLabelNum1") != string.Empty)
                cInstruction.SourceLabelNum_Sub1 = Int32.Parse(cXmlElement.GetValue("SourceLabelNum1"));
            if (cXmlElement.GetValue("SourceLabelNum2") != string.Empty)
                cInstruction.SourceLabelNum_Sub2 = Int32.Parse(cXmlElement.GetValue("SourceLabelNum2"));

            if(cXmlElement.GetValue("CoilLabelNum") != string.Empty)
                cInstruction.CoilLabelNum = Int32.Parse(cXmlElement.GetValue("CoilLabelNum"));
            if (cXmlElement.GetValue("CoilLabelNum1") != string.Empty)
                cInstruction.CoilLabelNum_Sub1 = Int32.Parse(cXmlElement.GetValue("CoilLabelNum1"));
            if (cXmlElement.GetValue("CoilLabelNum2") != string.Empty)
                cInstruction.CoilLabelNum_Sub2 = Int32.Parse(cXmlElement.GetValue("CoilLabelNum2"));

            if (m_DicRepeatedInstructionList != null && m_DicRepeatedInstructionList.ContainsKey(cInstruction.Command))
                m_DicRepeatedInstructionList[cInstruction.Command].Add(cInstruction);
            else if (m_DicInstructionList.ContainsKey(cInstruction.Command))
            {
                string sKey = cInstruction.Command;

                if(m_DicRepeatedInstructionList == null)
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

        private void MakeInstructionLabel(CXmlElement cXmlElement, CInstruction cInstruction, bool bSourceLabelCheck)
        {
            if (bSourceLabelCheck)
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

            if(cXmlElement.GetValue("Name") != string.Empty)
                cLabel.Name = cXmlElement.GetValue("Name");
            if (cXmlElement.GetValue("Datatype") != string.Empty)
                cLabel.lstDataType = GetDataTypes(cXmlElement.GetValue("Datatype"));
            if (cXmlElement.GetValue("Constant") != string.Empty)
                cLabel.Constant = GetConstant(cXmlElement.GetValue("Constant"));
            if (cXmlElement.GetValue("LabelIndex") != string.Empty)
                cLabel.LabelIndex = Int32.Parse(cXmlElement.GetValue("LabelIndex"));

            if (bSourceLabelCheck)
                cInstruction.SourceLabel.Add(cLabel);
            else
                cInstruction.CoilLabel.Add(cLabel);
        }

        #endregion
    }
}
