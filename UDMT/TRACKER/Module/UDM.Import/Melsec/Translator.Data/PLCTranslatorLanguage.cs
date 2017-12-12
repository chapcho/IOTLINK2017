using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UDM.Import.ME.Translator.Data
{

/*
    public class PlcCommand : PlcTranslationBlock, ICloneable
    {
        public int m_iCpuStep;
        public StepDrawType m_DrawType;
        public PlcProducer m_Producer;
        public string m_sParameterTypes;
        public string m_sVersion;

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

        public string GetParameterType(int idx)
        {
            return m_sParameterTypes.Length >= idx ? m_sParameterTypes[idx].ToString() : "";
        }

        public string Version
        {
            get { return m_sVersion; }
            set { m_sVersion = value; }
        }

        public object Clone()
        {
            PlcCommand obj = new PlcCommand();
            obj.m_DrawType = m_DrawType;
            obj.m_iCpuStep = m_iCpuStep;
            obj.m_sParameterTypes = m_sParameterTypes;
            obj.m_Producer = m_Producer;
            obj.m_strHexPrint = m_strHexPrint;
            obj.m_strValue = m_strValue;
            return obj;
        }
    }

    public class PlcCommandS : Dictionary<string, PlcCommand>
    {
        public PlcCommandS()
        {
        }

        public bool AddCommand(PlcCommand newCommand)
        {
            PlcCommand plcCommand = new PlcCommand();
            if( !this.TryGetValue(newCommand.HexPrint, out plcCommand) )
            {
                this.Add(newCommand.HexPrint , newCommand);
                return true;
            }
            return false;
        }

        public void ReplaceCommand(PlcCommand plcCommand)
        {
            PlcCommand targetCommand = new PlcCommand();
            if (this.TryGetValue(plcCommand.HexPrint, out targetCommand))
            {
                this.Remove(plcCommand.HexPrint);
            }

            this.Add(plcCommand.HexPrint, plcCommand);
        }

    }



    public class PlcProgramLine
    {
        private readonly int MAX_PLC_LANGUAGE_PARAMETER_COUNT = 10;

        public int m_iNo;
        public int m_iStepAmount;
        public PlcCommand m_PlcCommand;
        public PlcParameter[] m_plcParameters; //  = new PlcParameter[MAX_PLC_LANGUAGE_PARAMETER_COUNT];
        public List<PlcParameter> m_lstPlcParameter;

        PlcProgramLine()
        {
            m_iNo = 0;
            m_iStepAmount = 0;
            m_PlcCommand = new PlcCommand();
            m_plcParameters  = new PlcParameter[ MAX_PLC_LANGUAGE_PARAMETER_COUNT ];
            m_lstPlcParameter = new List<PlcParameter>();
        }
        public int No
        {
            get { return m_iNo; }
            set { m_iNo = value; }
        }
        public int StepAmount
        {
            get { return m_iStepAmount; }
            set { m_iStepAmount = value; }
        }
        public PlcCommand PlcCommand
        {
            get { return m_PlcCommand; }
            set { m_PlcCommand = value; }
        }
        public void AddParameter(PlcParameter plcParameter)
        {
            m_lstPlcParameter.Add(plcParameter);
        }
    }
    */
}
