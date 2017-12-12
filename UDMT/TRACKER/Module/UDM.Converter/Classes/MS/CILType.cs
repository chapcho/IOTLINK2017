using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILType
    {
        public static bool IsContactIL(string sCommand)
        {
            if ((sCommand.Contains("LD") && sCommand.Substring(0, 2) == "LD")
                || (sCommand.Contains("OR") && sCommand.Substring(0, 2) == "OR" && sCommand != "ORB")
                || (sCommand.Contains("AN") && sCommand.Substring(0, 2) == "AN" && sCommand != "ANB"))
                return true;
            else
                return false;
        }

        public static bool IsILLoad(string sCommand)
        {
            if (sCommand.Contains("LD") && sCommand.Substring(0, 2) == "LD")
                return true;
            else
                return false;
        }

        public static bool IsILAnd(string sCommand)
        {
            if (sCommand.Contains("AN") && sCommand.Substring(0, 2) == "AN" && sCommand != "ANB")
                return true;
            else
                return false;
        }

        public static bool IsILOr(string sCommand)
        {
            if ((sCommand.Contains("OR") && sCommand.Substring(0, 2) == "OR") && sCommand != "ORB")
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

        public static bool IsConnenctionOperationIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "INV", "MEP", "MEF", "EGP", "EGF" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsOutputIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "OUT", "OUTH", "SET", "RST", "PLS", "PLF", "FF", "DELTA", "DELTAP", "RSTART", "PLS", "PLSY", "MC" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsShiftIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "SFT", "SFTP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsRoutineControlIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MC", "MCR", "FOR", "NEXT", EMCoilImport.ProgramLabel.ToString(), "RET" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsTerminationIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "FEND", "END" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsDataTransferIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MOV", "MOVP", "DMOV", "DMOVP", "EMOV", "EMOVP", "CML", "CMLP", "BMOV", "BMOVP", "FMOV", "FMOVP", "XCH", "XCHP", "DXCH", "DXCHP", "SWAP", "SWAPP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool Is3ParameterIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "BMOV", "BMOVP", "FMOV", "FMOVP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool Is2ParameterIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "BMOV", "BMOVP", "FMOV", "FMOVP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsLogicalOperlationIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "WAND", "DAND", "BKAND", "WOR", "BKOR", "WXOR", "BKXOR", "WXNR", "DXNR", "BKXNR"
                                                    ,"WANDP", "DANDP", "BKANDP", "WORP", "BKORP", "WXORP", "BKXORP", "WXNRP", "DXNRP", "BKXNRP"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsCharacterStringProcessingIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "BINDA", "DBINDA", "BINHA", "DBINHA", "BCDDA", "DBCDDA", "DABIN", "DDABIN", "HABIN", "DHABIN", "DABCD", "DDABCD"
                                                    ,"BINDAP", "DBINDAP", "BINHAP", "DBINHAP", "BCDDAP", "DBCDDAP", "DABINP", "DDABINP", "HABINP", "DHABINP", "DABCDP", "DDABCDP"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsDataConversionIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "BCD", "DBCD", "BIN", "DBIN", "FLT", "DFLT", "INT", "DINT", "DBL", "WORD", "GRY", "DGRY", "GBIN", "DGBIN", "NEG", "DNEG", "ENEG", "BKBCD"
                                                    ,"BCDP", "DBCDP", "BINP", "DBINP", "FLTP", "DFLTP", "INTP", "DINTP", "DBLP", "WORDP", "GRYP", "DGRYP", "GBINP", "DGBINP", "NEGP", "DNEGP", "ENEGP", "BKBCDP"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }



        public static bool StructuredProgram(string sCommand)
        {
            List<string> ListIL = new List<string> { "CALL", "FCALL", "ECALL", "EFCALL"
                                                    ,"CALPL", "FCALLP", "ECALLP", "EFCALLP"};
            if (ListIL.Contains(sCommand))
                return true;
            else
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


        public static bool IsClockIL(string sCommand)
        {
            List<string> ListEndOperator = new List<string> { "DATERD", "DATEWR", "DATE+", "DATE-", "SECOND", "HOUR"
                                                            ,"DATERDP", "DATEWRP", "DATE+P", "DATE-P", "SECONDP", "HOURP"};
            if (ListEndOperator.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsTableOperationIL(string sCommand)
        {
            List<string> ListEndOperator = new List<string> { "FIFW", "FIFWP", "FIFR", "FIFRP", "FPOP", "FPOPP", "FINS", "FINSP", "FDEL", "FDELP" };
            if (ListEndOperator.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsSkipIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "NOP", "NOPLF", "PAGE", "END", "FEND" };
            if (ListIL.Contains(sCommand))
                return true;
            else if (sCommand.StartsWith("P") && CStringHelper.IsDigitString(sCommand.Substring(1, sCommand.Length - 1)))
                return true;
            else
                return false;
        }

        public static bool IsCommandOnlyIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "NOP", "NOPLF", "PAGE", "END", "FEND", "RET", "JMP", "IMASK", "DI", "EI"
                , "IRET", "RET", "COM", "IXEND", "IXDEV", "EI", "FOR", "NEXT", EMCoilImport.ProgramLabel.ToString() };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsOneCommandIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MCR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsSystemIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "UNIRD", "UNIRDP", "TRACE", "TRACER", "FWRITE", "FREAD", "PLOADP", "PUNLOADP", "PSWAPP", "RBMOV", "RBMOVP"
                ,"FROM","FROMP","S.TO","S.TOP" };
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





