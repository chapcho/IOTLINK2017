using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME
{
    #region Enums

    public enum PlcLadderTracerRunningState
    {
        Wait = 1,
        CommandRead = 2,
        ParameterRead = 3,
        ParameterWait = 4,
        CommentRead = 5,
        EndRead = 6
    }
    [Flags]
    public enum PlcLaddeInitialState
    {
        Init = 0,
        SymbolFileRead = 1,
        HeaderLengthRead = 2,
        SourceFilePathRead = 4
    }

    #endregion

    interface ILadderTranslator
    {
        void SetLadderProgramOutputFilePath(string outputFilePath);
        void TranslatorReportSave();
        PlcLadderTracerRunningState GetTranslatorState();
    }
}
