using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CLSILType
    {
        public static bool IsLoad(string sCommand)
        {
            if (sCommand.Contains("LOAD") && sCommand.Substring(0, 4) == "LOAD")
                return true;
            else
                return false;
        }

        public static bool IsContactIL(string sCommand)
        {
            if ((sCommand.Contains("LOAD") && sCommand.Substring(0, 4) == "LOAD")
                || (sCommand.Contains("OR") && sCommand.Substring(0, 2) == "OR" && sCommand != "OR LOAD")
                || (sCommand.Contains("AND") && sCommand.Substring(0, 3) == "AND" && sCommand != "AND LOAD"))
                return true;
            else
                return false;
        }

        public static bool IsConnenctionIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "AND LOAD", "OR LOAD", "MPUSH", "MLOAD", "MPOP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommandOnlyIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "NOP","END", "RET", "JMP", "NEXT" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsOneCommandIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MCS", "MCSCLR", "FOR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsConnenctionOperationIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "NOT" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsSkipIL(string sCommand) 
        {
            List<string> ListIL = new List<string> { "NOP", "END" , "LOAD_ON"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsRoutineControlIL(string sCommand)
        {
            List<string> ListIL = new List<string> { "MCS", "MCSCLR", "FOR", "NEXT", "SBRT", "LABEL", "RET", "CALL", "CALLP", "BREAK"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCompareCommand(string sCommand)
        {
            List<string> ListIL = new List<string> { "TCMP", "TCMPP", "DTCMP", "DTCMPP", "GEQ", "GEQP", "GDEQ", "GDEQP", "GGT", "GGTP", "GDGT", "GDGTP", "GLT", "GLTP", "GDLT", "GDLTP", "GGE", "GGEP"
            , "GDGE", "GDGEP", "GLE", "GLEP", "GDLE", "GDLEP", "GNE", "GNEP", "GDNE", "GDNEP" };

            if (sCommand.Contains("=") || sCommand.Contains("<") || sCommand.Contains(">"))
                return true;
            else if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsArithmeticOperationIL(string sCommand)
        {
            List<string> ListEndOperator = new List<string> { "ADD", "ADDP", "DADD", "DADDP", "ADDU", "ADDUP", "DADDU", "DADDUP"
                , "RADD", "RADDP", "$ADD", "$ADDP", "ADDB", "ADDBP", "SUB", "SUBP", "DSUB", "DSUBP", "SUBU", "SUBUP", "DSUBU", "DSUBUP", "RSUB"
                , "RSUBP", "SUBB", "SUBBP", "MUL", "MULP", "DMUL", "DMULP", "MULU", "MULUP", "DMULU", "DMULUP", "RMUL", "RMULP", "MULB", "MULBP"
                , "DIV", "DIVP", "DIVU", "DIVUP", "DDIVU", "DDIVUP", "RDIV", "RDIVP", "DIVB", "DIVBP", "INC", "INCP", "DINC", "DINCP", "INC4", "INC4P", "INC8", "INC8P", "INCU", "INCUP"
            , "DEC", "DECP", "DDEC", "DDECP", "DEC4", "DEC4P", "DEC8", "DEC8P", "DECU", "DECUP"};
            if (ListEndOperator.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsModuleSlotIL(string sCommand)
        {
            List<string> ListEndOperator = new List<string> { "SNDUDATA", "RCVUDATA", "SENDDTR", "SENDRTS", "GET", "GETP", "GETE", "GETEP"
                , "PUT", "PUTP", "PUTE", "PUTEP", "GETM", "GETMP", "PUTM", "PUTMP" };
            if (ListEndOperator.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsSubDataMove(string sCommand)
        {
            List<string> ListIL = new List<string> { "INC", "INCP", "DINC", "DINCP", "INC4", "INC4P", "INC8", "INC8P", "INCU", "INCUP"
            , "DEC", "DECP", "DDEC", "DDECP", "DEC4", "DEC4P", "DEC8", "DEC8P", "DECU", "DECUP", "MOV", "MOVP", "DMOV", "DMOVP", "MOV4", "MOV4P"
                , "MOV8", "MOV8P", "CMOV", "CMOVP", "DCMOV", "DCMOVP", "RMOV", "RMOVP", "LMOV", "LMOVP", "$MOV", "$MOVP", "GMOV", "GMOVP", "FMOV"
                , "FMOVP", "BMOV", "BMOVP", "GBMOV", "GBMOVP", "NEG", "NEGP", "DNEG", "DENGP", "RNEG", "RNEGP", "LNEG", "LNEGP", "WAND", "WANDP", "DAND"
                , "DANDP", "GWAND", "GWANDP", "BAND", "BANDP", "ABAND", "ABANDP", "WOR", "WORP", "DOR", "DORP", "GWOR", "GWORP", "BOR", "BORP", "ABOR"
                , "ABORP", "WXOR", "WXORP", "DXOR", "DXORP", "GWXOR", "GWXORP", "BXOR", "BXORP", "ABXOR", "ABXORP", "WXNR", "WXNRP", "DXNR", "DXNRP"
                , " GWXNR", "GWXNRP", "BXNR", "BXNRP", "ABXNR", "ABXNRP", "BSUM", "BSUMP", "DBSUM", "DBSUMP", "BRST", "BRSTP", "ENCO", "ENCOP", "DECO", "DECOP"
                , "DIS", "DISP", "UNI", "UNIP", "WTOB", "WTOBP", "BTOW", "BTOWP", "IORF", "IORFP", "SCH", "SCHP", "DSCH", "DSCHP", "MAX", "MAXP", "DMAX", "DMAXP"
                , "MIN", "MINP", "DMIN", "DMINP", "SUM", "SUMP", "DSUM", "DSUMP", "AVE", "AVEP", "DAVE", "DAVEP", "MUX", "MUXP", "DMUX", "DMUXP", "DETECT", "DETECTP"
                , "RAMP", "RAMPP", "SORTP", "SORT", "TRAMP", "RTRAMP", "ADS", "ADSP", "ADU", "ADUP", "SEG", "SEGP", "LIMIT", "LIMITP", "DLIMIT", "DLIMITP", "BCD", "BCDP"
                , "DBCD", "DBCDP", "BCD4", "BCD4P", "BCD8", "BCD8P", "GBCD", "GBCDP", "BIN", "BINP", "DBIN", "DBINP", "BIN4", "BIN4P", "BIN8", "BIN8P", "GBIN", "GBINP"
                , "BSFT", "BSFTP", "BSFL", "BSFLP", "DBSFL", "DBSFLP", "BSFL4", "BSFL4P", "BSFL8", "BSFL8P", "BSFR", "BSFRP", "DBSFR", "DBSFRP", "BSFR4", "BSFR4P", "BSFR8"
                , "BSFR8P", "WSFT", "WSFTP", "WSFL", "WSFLP", "WSFR", "WSFRP", "SR", "BRR", "BRRP", "BRL", "BRLP", "SQRT", "SQRTP", "ABS", "DABSP", "ABSP", "DABS", "SWAP", "SWAPP"
                , "XCHG", "XCHGP", "DXCHG", "DXCHGP", "GXCHG", "GXCHGP", "SWAP", "SWAPP", "GSWAP", "GSWAPP", "SWAP2", "SWAP2P", "GSWAP2", "GSWAP2P", "SIN", "SINP", "COS", "COSP"
                , "TAN", "TANP", "ASIN", "ASINP", "ACOS", "ACOSP", "ATAN", "ATANP", "LN", "LNP", "LOG", "LOGP", "EXP", "EXPP", "EXPT", "EXPTP", "DEG", "DEGP", "RAD", "RADP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
    }
}
