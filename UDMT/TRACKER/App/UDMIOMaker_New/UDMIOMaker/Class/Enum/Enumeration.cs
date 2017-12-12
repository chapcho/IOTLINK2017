using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDMIOMaker
{
    public enum EMMappingMessage
    {
        Manual_Mapping,
        Auto_Mapping,
        Mapping_Cancel,
        Mapping_Check_Description,
        Mapping_Check_Address
    }


    public enum EMIOMakerMode
    {
        Design,
        Mapping,
        Verification
    }

    public enum EMUsedLogic
    {
        Used,
        Used_OnlyLogic,
        NotUsed
    }

    public enum EMSymbolRole
    {
        Contact,
        Coil,
        Both,
        NotUsed
    }

    public enum EMMappingType
    {
        Match,
        Insert,
        Convert
    }

    public enum EMCommonFileState
    {
        Opened,
        Closed
    }

    public enum EMCommonHMIPrograms
    {
        XP_Builder
    }

    public enum EMCommonCsvType
    {
        Comma,
        Tab
    }

    public enum EMPLCVerificationMenu
    {
        Open,
        Analysis,
        LogicAdd,
        ExportToExcel,
        ExportToWord,
        ExportToPdf,

    }

    public enum EMPLCColumns
    {
        address,
        symbol,
        memory,
        contact,
        logic,
    }
}
