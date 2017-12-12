using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CMelsecILType
    {
        public static bool IsLoad(string sCommand)
        {
            if (sCommand.Contains("LD") && sCommand.Substring(0, 2) == "LD")
                return true;
            else
                return false;               
        }

        public static bool IsContactIL(string sCommand)
        {
            if ((sCommand.Contains("LD") && sCommand.Substring(0, 2) == "LD")
                || (sCommand.Contains("OR") && sCommand.Substring(0, 2) == "OR" && sCommand != "ORB")
                || (sCommand.Contains("AN") && sCommand.Substring(0, 2) == "AN" && sCommand != "ANB"))
                return true;
            else
                return false;
        }

        public static bool IsConnenctionIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "ANB", "ORB", "MPS", "MRD", "MPP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommandOnlyIL(string sCommand)
        {
            List<string> ListIL = new List<string> {"NOP",  "NOPLF", "PAGE", "END", "FEND", "RET", "JMP", "NEXT"
            , "IRET", "IMASK", "DI", "EI", "RET", "COM", "IXEND", "IXDEV", "EI"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsOneCommandIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MCR", "FOR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsConnenctionOperationIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "INV", "MEP", "MEF", "EGP", "EGF" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsSkipIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "NOP", "NOPLF", "PAGE", "END", "FEND"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsRoutineControlIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MC", "MCR", "FOR", "NEXT", "LABEL", "RET", "CJ", "SCJ", "BREAK", "BREAKP"
                , "CALL", "CALLP", "FCALL", "FCALLP", "ECALL", "ECALLP"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCompareCommand(string sCommand)
        {
            if (sCommand.Contains("=") || sCommand.Contains("<") || sCommand.Contains(">") || sCommand.Contains("$"))
                return true;

            return false;
        }

        public static bool IsArithmeticOperationIL(string sCommand)
        {
            List<string> ListEndOperator = new List<string> { "+", "-", "*", "/", "D+", "D-", "D*", "D/", "B+", "B-", "B*", "B/", "E+", "E-", "E*", "E/"
            , "+P", "-P", "*P", "/P", "D+P", "D-P", "D*P", "D/P", "B+P", "B-P", "B*P", "B/P", "E+P", "E-P", "E*P", "E/P"
            , "INC","INCP","DINC","DINCP","DEC","DECP","DDEC","DDECP"};
            if (ListEndOperator.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsSubDataMove(string sCommand)
        {
            List<string> ListILEx = new List<string> { "SWAP", "SWAPP", "FPOP", "FPOPP", "ZPOP", "ZPOPP" };
            if (ListILEx.Contains(sCommand))
                return true;

            sCommand = sCommand.TrimEnd('P');
            List<string> ListIL = new List<string> { "CML", "INC", "DEC", "BSET", "BRST", "$MOV", "ROR"
                , "RCR", "ROL", "RCL", "NEG", "RND", "WAND", "WOR", "WXOR", "WXNR", "SUM", "DSUM", "UNI", "LEN"
                , "BASIN", "BACOS", "BATAN", "LIMIT", "BAND", "ZONE", "BCD", "BIN", "INT", "WORD", "GRY", "GBIN"
                , "DABIN", "HABIN", "DABCD", "INSTR", "TEST", "DTEST", "MOV", "DINC", "DDEC", "DCML", "EMOV"
                , "DROR", "DRCR", "DROL", "DRCL", "DNEG", "ENEG", "DAND", "DOR", "DXOR", "DXNR", "WSUM", "SIN"
                , "COS", "TAN", "ASIN", "ACOS", "ATAN", "RAD", "DEG", "SQR", "EXP", "LOG", "BSQR", "BDSQR", "DLIMIT"
                , "DBAND", "DZONE", "DBCD", "DBIN", "FLT", "DFLT", "DINT", "DBL", "DGRY", "DGBIN", "DDABIN", "DHABIN"
                , "DDABCD", "EREXP", "EVAL", "SER", "DSER", "DMOV", "BSIN", "BCOS", "BTAN", "BINHA", "BCDDA", "MAX"
                , "MIN", "FMOV", "BKAND", "BKOR", "BKXOR", "BKXNR", "BKBCD", "BKBIN", "WTOB", "BMOV", "DECO", "BINDA"
                , "DWSUM", "DMAX", "DMIN", "DBINHA", "DBCDDA", "EMOD", "DBINDA", "SFT", "BKRST", "SFR", "SFL", "BSFR"
                , "BSFL", "DSFR", "DSFL", "XCH", "DXCH", "BXCH", "SRND", "DIS", "COMRD", "BTOW", "VAL", "DVAL", "MIDR"
                , "MIDW", "STR", "DSTR", "ASC", "HEX", "RIGHT", "LEFT", "ESTR", "FIFW", "FIFR",  "FDEL", "FINS"
                , "FROM", "DFRO", "SORT", "DSORT", "NDIS", "NUNI", "ENCO", "SEG", "ZPUSH", "EROMWR"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

    }

}
