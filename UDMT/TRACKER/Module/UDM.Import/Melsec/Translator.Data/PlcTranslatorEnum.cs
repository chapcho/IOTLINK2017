using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME.Translator.Data
{

    #region Enums

    public enum PlcProducer
    {
        MELSEC,
        AB,
        SIMENS,
        LS
    }

    public enum StepDrawType
    {
        LOAD,
        AND,
        OR,
        OUT
    }

    public enum ParameterType
    {
        ADDRESS,
        NUMERIC,
        STRING
    }

    public enum PacketDataType
    {
        ADDRESS_INDICATOR ,       
        INDEX_INDICATOR,             // Z
        NUMERIC_INDICATOR,        // K
        BIT_INDICATOR,                  // K
        POINT_INDICATOR,             // .
        LINK_DEVICE_INDICATOR,   // J F9
//        SERIAL_DEVICE_INDICATOR,   // ZR B0
        INDIRECT_INDICATOR,         // @
        STRING_INDICATOR,            // "
        SPECIAL_DEVICE_INDICATOR, // U\\
        COMMAND
    }

    public enum LanguageSymbolType
    {
        RESERVESYMBOL,
        DEVICEADDRESS
    }

    public enum LanguageParseType
    {
        COMMAND,
        PARAMETER
    }

    #endregion
}
