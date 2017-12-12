using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UDM.Import.ME.DataStruct
{
    [Serializable]
    public class PLCLadderNodeS : List<PlcLadderNode>, ICloneable
    {
        public PLCLadderNodeS() { }
        public PLCLadderNodeS(List<PlcLadderNode> list) : base(list) { }

        public object Clone()
        {
            PLCLadderNodeS clone = new PLCLadderNodeS();
            foreach (PlcLadderNode src in this)
            {
                clone.Add(src);
            }
            return clone;
        }
    }

    [Serializable]
    public class PlcLadderNode
    {

        #region Member Variables

        [XmlAttribute]
        protected int m_iNo;
        [XmlAttribute]
        protected int m_iLineNo;
        [XmlAttribute]
        protected string m_sPlcCommand;
        [XmlAttribute]
        protected string m_sPlcCommandHexDump;
        [XmlAttribute]
        protected string[] m_saParameters;
        [XmlAttribute]
        protected string m_sNote;

        #endregion

        #region Initialize/Dispose

        public PlcLadderNode()
        {
            m_iNo = 0;
            m_iLineNo = 0;
            m_sPlcCommand = String.Empty;
            m_sPlcCommandHexDump = String.Empty;
            m_sNote = String.Empty;
        }

        #endregion

        #region Public Properties

        public int No
        {
            get { return m_iNo; }
            set { m_iNo = value; }
        }
        public int LineNo
        {
            get { return m_iLineNo; }
            set { m_iLineNo = value; }
        }
        public string PlcCommand
        {
            get { return m_sPlcCommand; }
            set { m_sPlcCommand = value; }
        }
        public string PlcCommandHexDump
        {
            get { return m_sPlcCommandHexDump; }
            set { m_sPlcCommandHexDump = value; }
        }
        public string[] Parameters
        {
            get { return m_saParameters; }
            set { m_saParameters = value; }
        }
        public string Note
        {
            get { return m_sNote; }
            set { m_sNote = value; }
        }

        #endregion

    }

    [Serializable]
    public class PLCSymbolS : List<PLCLadderSymbol>, ICloneable
    {
        public PLCSymbolS() { }
        public PLCSymbolS(List<PLCLadderSymbol> list) : base(list) { }

        public object Clone()
        {
            PLCSymbolS clone = new PLCSymbolS();
            foreach (PLCLadderSymbol src in this)
            {
                clone.Add(src);
            }
            return clone;
        }
    }

    [Serializable]
    public class PLCLadderSymbol
    {
        [XmlAttribute]
        public string command { get; set; }
        [XmlAttribute]
        public string printedHex { get; set; }
        [XmlAttribute]
        public int wordWidth;
        [XmlAttribute]
        public int ndor { get; set; }
        [XmlAttribute]
        public int stepCnt { get; set; }
        [XmlAttribute]
        public string paramTypeString { get; set; }
        [XmlAttribute]
        public string description { get; set; }

        public PLCLadderSymbol(string plcCommand, int ndor, string printedHex, string description, int widthType, string paramTypeStr, int stepCnt)
        {
            this.command = plcCommand;
            this.ndor = ndor;
            this.printedHex = printedHex;
            this.description = description;
            this.wordWidth = widthType;
            this.paramTypeString = paramTypeStr;
            this.stepCnt = stepCnt;
        }

        public PLCLadderSymbol()
        {
            // TODO: Complete member initialization
        }

        public void Init()
        {
            command = ""; ndor = 1; printedHex = ""; description = ""; paramTypeString = ""; 
        }
    }

}
