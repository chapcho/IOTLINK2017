using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME.Translator.Data
{
    public class PlcTranslationBlock : ICloneable
    {
        #region Member Variables

        public string m_strValue;             // 번역된 값.
        public string m_strHexPrint;         // Hex Read.
        private int m_iReadIndex;
        private int m_iBlockLength;
        private LanguageParseType m_ParseType;
        private PacketDataType m_packetDataType;

        #endregion

        #region Public Method

        public void DefinePacketDataType(LanguageParseType parseType) // COMMAND or PARAMETER
        {
            switch (m_strHexPrint.Substring(0, 2))
            {
                case "F0": // Z 특수 모듈 지정자
                    this.m_packetDataType = PacketDataType.INDEX_INDICATOR;
                    break;
                case "F1": // K 비트 지정자
                    this.m_packetDataType = PacketDataType.BIT_INDICATOR;
                    break;
                case "F2": // . 소수점 지정자
                    this.m_packetDataType = PacketDataType.POINT_INDICATOR;
                    break;
                case "F3": // @
                    this.m_packetDataType = PacketDataType.INDIRECT_INDICATOR;
                    break;
                case "F9": // J 
                    this.m_packetDataType = PacketDataType.LINK_DEVICE_INDICATOR;
                    break;
                case "F8": // U 특수디바이스 지정자
                    this.m_packetDataType = PacketDataType.SPECIAL_DEVICE_INDICATOR;
                    break;
                case "EE":
                    this.m_packetDataType = PacketDataType.STRING_INDICATOR;
                    break;
                case "E8": // K 숫자
                    this.m_packetDataType = PacketDataType.NUMERIC_INDICATOR;
                    break;
                default: // Address or Command
                    this.m_packetDataType = (parseType == LanguageParseType.PARAMETER) ? PacketDataType.ADDRESS_INDICATOR : PacketDataType.COMMAND;
                    break;
            }
        }

        public object Clone()
        {
            PlcTranslationBlock obj = new PlcTranslationBlock();
            obj.m_strValue = m_strValue;
            obj.m_strHexPrint = m_strHexPrint;
            obj.m_iReadIndex = m_iReadIndex;
            obj.m_iBlockLength = m_iBlockLength;
            obj.m_ParseType = m_ParseType;
            obj.m_packetDataType = m_packetDataType;
            return obj;
        }

        #endregion

        #region Public Properties

        public PacketDataType PacketType
        {
            get { return m_packetDataType; }
            set { m_packetDataType = value; }
        }

       public LanguageParseType ParseType
        {
            get { return m_ParseType; }
            set { m_ParseType = value; }
        }

        public PlcTranslationBlock()
        {
            m_iReadIndex = 0;
            m_iBlockLength = 0;
        }

        public int ReadIndex
        {
            get { return m_iReadIndex; }
            set { m_iReadIndex = value; }
        }

        public string Value
        {
            get { return m_strValue; }
            set { m_strValue = value; }
        }

        public string HexPrint
        {
            get { return m_strHexPrint; }
            set { m_strHexPrint = value;}
        }

        #endregion

    }
}
