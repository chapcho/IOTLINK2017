using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Import.ME.Translator.Data;


namespace UDM.Import.ME.Translator.Data
{
    [Serializable]
    public class PlcCommand : ICloneable
    {

        #region Member Variables

        private int m_iCpuStep;
        private StepDrawType m_DrawType;
        private PlcProducer m_Producer;
        private string m_sParameterTypes;
        private string m_sVersion;
        private string m_sCommand;
        private string m_sDescription;
        private string m_sHexPrint;
        private int m_iRadix;
        private LanguageSymbolType m_SymbolType;

        #endregion


        #region Public Properties
 
        public int Radix
        {
            get { return m_iRadix; }
            set { m_iRadix = value; }
        }

        public LanguageSymbolType SymbolType
        {
            get { return m_SymbolType; }
            set { m_SymbolType = value; }
        }

        public int Step
        {
            get { return m_iCpuStep; }
            set { m_iCpuStep = value; }
        }

        public StepDrawType DrawType
        {
            get { return m_DrawType; }
            set { m_DrawType = value; }
        }

        public PlcProducer Producer
        {
            get { return m_Producer; }
            set { m_Producer = value; }
        }

        public string ParameterTypes
        {
            get { return m_sParameterTypes; }
            set { m_sParameterTypes = value; }
        }

        public string Version
        {
            get { return m_sVersion; }
            set { m_sVersion = value; }
        }

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public string HexPrint
        {
            get { return m_sHexPrint; }
            set { m_sHexPrint = value; }
        }

        #endregion

        #region Initialize

        public PlcCommand()
        {

        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            PlcCommand obj = new PlcCommand();
            obj.m_DrawType = m_DrawType;
            obj.m_iCpuStep = m_iCpuStep;
            obj.m_sParameterTypes = m_sParameterTypes;
            obj.m_Producer = m_Producer;
            obj.m_sHexPrint = m_sHexPrint;
            obj.m_sDescription = m_sDescription;
            obj.m_SymbolType = m_SymbolType;
            obj.m_sVersion = m_sVersion;
            obj.m_iRadix = m_iRadix;
            return obj;
        }

        public string GetParameterType(int idx)
        {
            return m_sParameterTypes.Length >= idx ? m_sParameterTypes[idx].ToString() : "";
        }
        #endregion

    }
}
