using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UDM.UDL;

namespace UDM.UDLImport
{
    public class CLSILImportType
    {
        
        // S: Source, D: Destination, N : Numeric

        #region Initialize/Dispose

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public static List<string> GetLSCommandAll()
        {
            List<string> lstCommandAll = new List<string>();
            List<string> lstCommand = new List<string>();

            IsS0_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N3(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N5(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N3(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N4(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N5(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D2_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D2_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS3_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS3_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS3_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS3_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS4_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N3_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N2_D2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_S1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_D1_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsD1_S2_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsProgram(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsLABEL(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);


            return lstCommandAll;
        }

        public static EMCoilImport GetLSType(string strCommand)
        {
            List<string> lstTemp = new List<string>();

            if (strCommand == string.Empty) return EMCoilImport.EMPTY;
            else if (IsS0_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N0;
            else if (IsS0_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N0;
            else if (IsS0_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N1;
            else if (IsS0_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N0;
            else if (IsS0_D2_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N1;
            else if (IsS0_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N1;
            else if (IsS0_D0_N2(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N2;
            else if (IsS0_D0_N3(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N3;
            else if (IsS0_D0_N5(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N5;
            else if (IsS1_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N0;
            else if (IsS1_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N1;
            else if (IsS1_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N0;
            else if (IsS1_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N1;
            else if (IsS1_D1_N2(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N2;
            else if (IsS1_D1_N3(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N3;
            else if (IsS1_D1_N4(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N4;
            else if (IsS1_D1_N5(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N5;
            else if (IsS1_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D2_N0;
            else if (IsS2_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D0_N0;
            else if (IsS2_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N0;
            else if (IsS2_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N1;
            else if (IsS2_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S2_D0_N1;
            else if (IsS2_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D2_N0;
            else if (IsS3_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S3_D0_N0;
            else if (IsS3_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S3_D0_N1;
            else if (IsS3_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S3_D1_N0;
            else if (IsS3_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S3_D1_N1;
            else if (IsS4_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S4_D1_N0;
            else if (IsS0_N3_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N3_D1;
            else if (IsS1_N2_D2(strCommand, out lstTemp)) return EMCoilImport.S1_N2_D2;
            else if (IsS1_D1_S1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_S1;
            else if (IsN2_D1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.N2_D1_N1_D1;
            else if (IsD1_S2_N1(strCommand, out lstTemp)) return EMCoilImport.D1_S2_N1;
            else if (IsProgram(strCommand, out lstTemp)) return EMCoilImport.Program;
            else if (IsLABEL(strCommand, out lstTemp)) return EMCoilImport.ProgramLabel;

            return EMCoilImport.NONE;
        }

        #region S# D# N#

        public static bool IsS0_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LOAD_ON", "AND LOAD", "OR LOAD", "MPUSH", "MLOAD", "MPOP", "NOT", "END", "STOP", "ESTOP", "NOP", "RET"
                , "NEXT", "EI", "DI", "EERRST" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        } 

        public static bool IsS0_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LOAD", "LOADP", "LOADN", "AND", "ANDP", "ANDN", "OR", "ORP", "ORN", "LOAD NOT", "AND NOT", "OR NOT"
            , "OUT", "OUTP", "OUTN", "OUT NOT", "SET", "RST", "INC", "INCP", "DINC", "DINCP", "INC4", "INC4P", "INC8", "INC8P", "INCU", "INCUP"
            , "DEC", "DECP", "DDEC", "DDECP", "DEC4", "DEC4P", "DEC8", "DEC8P", "DECU", "DECUP", "NEG", "NEGP", "DNEG", "DNEGP", "RNEG", "RNEGP"
            , "LNEG", "LNEGP", "ABS", "ABSP", "DABS", "DABSP", "SWAP", "SWAPP", "DATEWR", "DATEWRP", "FF" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TON", "TOFF", "TMR", "TMON", "TRTG", "CTU", "CTD", "CTR", "GSWAP", "GSWAPP", "BSFL", "BSFLP", "DBSFL"
                , "DBSFLP", "BSFL4", "BSFL4P", "BSFL8", "BSFL8P", "BSFR", "BSFRP", "DBSFR", "DBSFRP", "BSFR4", "BSFR4P", "BSFR8", "BSFR8P"
                , "BRST", "BRSTP", "ROL", "ROLP", "DROL", "DROLP", "ROL4", "ROL4P", "ROL8", "ROL8P", "ROR", "RORP", "DROR", "DRORP", "ROR4"
                , "ROR4P", "ROR8", "ROR8P", "RCL", "RCLP", "DRCL", "DRCLP", "RCL4", "RCL4P", "RCL8", "RCL8P", "RCR", "RCRP", "DRCR", "DRCRP"
                , "RCR4", "RCR4P", "RCR8", "RCR8P"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "XCHG", "XCHGP", "DXCHG", "DXCHGP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS0_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GXCHG", "GXCHGP", "WSFLP", "WSFL", "WSFR", "WSFRP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS0_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MCS", "MCSCLR", "FOR", "EIN", "DIN", "PIDRUN", "PIDPAUSE", "PIDINT", "PIDAT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D0_N2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PIDHBD", "PIDCAS" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D0_N3(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "P2PSN" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D0_N5(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "P2PWRD", "P2PWWR", "P2PBRD", "P2PBWR" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DATERD", "DATERDP", "RSET", "RSETP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PIDPRMT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SQRT", "SQRTP", "BSQRT", "BSQRTP", "BDSQRT", "BDSQRTP", "MOV", "MOVP", "DMOV", "DMOVP", "MOV4", "MOV4P"
                , "MOV8", "MOV8P", "CMOV", "CMOVP", "DCMOV", "DCMOVP", "RMOV", "RMOVP", "LMOV", "LMOVP", "$MOV", "$MOVP", "SWAP2", "SWAP2P"
                , "SIN", "SINP", "COS", "COSP", "TAN", "TANP", "ASIN", "ASINP", "ACOS", "ACOSP", "ATAN", "ATANP", "LN", "LNP", "LOG", "LOGP"
                , "EXP", "EXPP", "DEG", "DEGP", "RAD", "RADP", "BCD", "BCDP", "DBCD", "DBCDP", "BCD4", "BCD4P", "BCD8", "BCD8P", "BIN", "BINP"
                , "DBIN", "DBINP", "BIN4", "BIN4P", "BIN8", "BIN8P", "SECOND", "SECONDP", "BSUM", "BSUMP", "DBSUM", "DBSUMP", "I2R", "I2RP"
                , "I2L", "I2LP", "D2R", "DR2P", "D2L", "D2LP", "R2I", "R2IP", "R2D", "R2DP", "R2L", "R2LP", "L2R", "L2RP", "U2R", "U2RP", "U2L"
                , "U2LP", "UD2R", "UD2RP", "UD2L", "UD2LP", "R2U", "R2UP", "R2UD", "R2UDP", "L2U", "L2UP", "L2UD", "L2UDP", "WTODW", "WTODWP"
                , "DWTOW", "DWTOWP", "FIWR", "FIWRP", "FIFRD", "FIFRDP", "FILRD", "FILRDP", "FINS", "FINSP", "FIDEL", "FIDELP", "BINDA", "BINDAP"
                , "DBINDA", "DBINDAP", "BINHA", "BINHAP", "DBINHA", "DBINHAP", "BCDDA", "BCDDAP", "DBCDDA", "DBCDDAP", "DABIN", "DABINP", "DDABIN"
                , "DDABINP", "HABIN", "HABINP", "DHABIN", "DHABINP", "DABCD", "DABCDP", "DDABCD", "DDABCDP", "LEN", "LENP", "STRR", "STRRP", "STRL"
                , "STRLP", "XORG", "ORG", "FLT", "XFLT", "VTP", "XVTP", "PTV", "SKP", "XSKP", "NMV", "XNMV", "RTP", "XRTP", "MOF", "XMOF", "ZOE"
                , "ZOD", "EMG", "XEMG", "ECLR", "XECLR", "XECON", "XDCON", "XSVON", "XSVOFF", "XSCLR", "XSECLR", "XRSTR"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GMOV", "GMOVP", "FMOV", "FMOVP", "BMOV", "BMOVP", "GSWAP2", "GSWAP2P", "ABAND", "ABANDP", "ABOR", "ABORP"
                , "ABXOR", "ABXORP", "ABXNR", "ABXNRP", "GBCD", "GBCDP", "GBIN", "GBINP", "ENCO", "ENCOP", "DECO", "DECOP", "DIS", "DISP", "UNI"
                , "UNIP", " WTOB", "WTOBP", "BTOW", "BTOWP", "MAX", "MAXP", "DMAX", "DMAXP", "MIN", "MINP", "DMIN", "DMINP", "SUM", "SUMP", "DSUM"
                , "DSUMP", "AVE", "AVEP", "DAVE", "DAVEP", "SEG", "SEGP", "ASC", "ASCP", "HEX", "HEXP", "RIGHT", "RIGHTP", "LEFT", "LEFTP", "IST"
                , "XIST", "XVTPP", "XPTT", "STP", "XSTP", "POR", "XPOR", "SOR", "XSOR", "PSO", "XPSO", "INCH", "XINCH", "SNS", "XSNS", "SRS", "XSRS"
                ,"PRS", "XPRS", "EPRS", "XEPRS", "CLR", "XCLR", "PST", "XPST", "TSP", "XSES", "WRT", "XWRT", "XSVSAVE", "XLRD", "XLCLR" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GBMOV", "GBMOVP", "LIN", "CIN", "TBP", "TEP", "THP", "TMP", "TCP"
                , "PWR", "XPWR", "TWR", "XTWR", "TMD", "XSMD", "SCAM", "XSWR", "XTRQ", "XLSET" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N3(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SSP", "XSSP", "SSS", "XSSS", "XCAMO", "XELIN", "VRD", "XVRD", "XSMP", "XSHP", "XSEP", "XSBP", "XSCP"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N4(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SST", "XSST", "TEA", "TEAA", "XTEAA", "XSSSP"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N5(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DST", "XDST", "VWR", "XVWR", "XSVPWR", "XSTC"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "VAL", "VALP", "DVAL", "DVALP", "SRD", "XSRD"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> {"CMP", "CMPP", "DCMP", "DCMPP", "CMP4", "CMP4P", "CMP8", "CMP8P", "LOAD=", "AND=", "OR=", "LOADD=", "ANDD=", "ORD="
            , "LOADR=", "ANDR=", "ORR=", "LOADL=", "ANDL=", "ORL=", "LOAD$=", "AND$=", "OR$=", "LOAD4=", "AND4=", "OR4=", "LOAD8=", "AND8=", "OR8=", "ULOAD="
            , "UAND=", "UOR=", "ULOADD=", "UANDD=", "UORD=", "LOAD>=", "AND>=", "OR>=", "LOADD>=", "ANDD>=", "ORD>="
            , "LOADR>=", "ANDR>=", "ORR>=", "LOADL>=", "ANDL>=", "ORL>=", "LOAD$>=", "AND$>=", "OR$>=", "LOAD4>=", "AND4>=", "OR4>=", "LOAD8>=", "AND8>=", "OR8>=", "ULOAD>="
            , "UAND>=", "UOR>=", "ULOADD>=", "UANDD>=", "UORD>=",  "LOAD<=", "AND<=", "OR<=", "LOADD<=", "ANDD<=", "ORD<="
            , "LOADR<=", "ANDR<=", "ORR<=", "LOADL<=", "ANDL<=", "ORL<=", "LOAD$<=", "AND$<=", "OR$<=", "LOAD4<=", "AND4<=", "OR4<=", "LOAD8<=", "AND8<=", "OR8<=", "ULOAD<="
            , "UAND<=", "UOR<=", "ULOADD<=", "UANDD<=", "UORD<=", "LOAD<>", "AND<>", "OR<>", "LOADD<>", "ANDD<>", "ORD<>"
            , "LOADR<>", "ANDR<>", "ORR<>", "LOADL<>", "ANDL<>", "ORL<>", "LOAD$<>", "AND$<>", "OR$<>", "LOAD4<>", "AND4<>", "OR4<>", "LOAD8<>", "AND8<>", "OR8<>", "ULOAD<>"
            , "UAND<>", "UOR<>", "ULOADD<>", "UANDD<>", "UORD<>", "LOAD<", "AND<", "OR<", "LOADD<", "ANDD<", "ORD<"
            , "LOADR<", "ANDR<", "ORR<", "LOADL<", "ANDL<", "ORL<", "LOAD$<", "AND$<", "OR$<", "LOAD4<", "AND4<", "OR4<", "LOAD8<", "AND8<", "OR8<", "ULOAD<"
            , "UAND<", "UOR<", "ULOADD<", "UANDD<", "UORD<", "LOAD>", "AND>", "OR>", "LOADD>", "ANDD>", "ORD>"
            , "LOADR>", "ANDR>", "ORR>", "LOADL>", "ANDL>", "ORL>", "LOAD$>", "AND$>", "OR$>", "LOAD4>", "AND4>", "OR4>", "LOAD8>", "AND8>", "OR8>", "ULOAD>"
            , "UAND>", "UOR>", "ULOADD>", "UANDD>", "UORD>", "BSFT", "BSFTP", "WSFT", "WSFTP", "EBREAD", "EBWRITE"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TCMP", "TCMPP", "DTCMP", "DTCMPP", "ADD", "ADDP", "DADD", "DADDP", "ADDU", "ADDUP", "DADDU", "DADDUP"
                , "RADD", "RADDP", "$ADD", "$ADDP", "ADDB", "ADDBP", "SUB", "SUBP", "DSUB", "DSUBP", "SUBU", "SUBUP", "DSUBU", "DSUBUP", "RSUB"
                , "RSUBP", "SUBB", "SUBBP", "MUL", "MULP", "DMUL", "DMULP", "MULU", "MULUP", "DMULU", "DMULUP", "RMUL", "RMULP", "MULB", "MULBP"
                , "DIV", "DIVP", "DIVU", "DIVUP", "DDIVU", "DDIVUP", "RDIV", "RDIVP", "DIVB", "DIVBP", "WAND", "WANDP", "DAND", "DANDP", "WOR"
                , "WORP", "DOR", "DORP", "WXOR", "WXORP", "DXOR", "DXORP", "WXNR", "WXNRP", "DXNR", "DXNRP", "EXPT", "EXPTP", "ADDCLK", "ADDCLKP"
                , "SUBCLK", "SUBCLKP", "ADS", "ADSP", "ADU", "ADUP", "STR", "STRP", "DSTR", "DSTRP", "RSTR", "RTSRP", "LSTR", "LSTRP", "RBCD"
                , "RBCDP", "LBCD", "LBCDP", "BCDR", "BCDRP", "BCDL", "BCDLP", "EMOV", "EMOVP", "EDMOV", "EDMOVP", "MOVE_INT"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GEQ", "GEQP", "GDEQ", "GDEQP", "GGT", "GGTP", "GDGT", "GDGTP", "GLT", "GLTP", "GDLT", "GDLTP", "GGE", "GGEP"
            , "GDGE", "GDGEP", "GLE", "GLEP", "GDLE", "GDLEP", "GNE", "GNEP", "GDNE", "GDNEP", "GADD", "GADDP", "GSUB", "GSUBP", "GWOR", "GWORP"
            , "GWAND", "GWANDP", "GWXOR", "GWXORP", "GWXNR", "GWXNRP", "BAND", "BANDP", "BOR", "BORP", "BXOR", "BXORP", "BXNR", "BXNRP", "SR"
            , "BRR", "BRRP", "BRL", "BRLP", "SCH", "SCHP", "DSCH", "DSCHP", "MUX", "MUXP", "DMUX", "DMUXP", "DETECT", "DETECTP", "FIND", "FINDP"
            , "GET", "GETP", "PUT", "PUTP", "GETM", "GETMP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "EBCMP"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LOADG=", "ANDG=", "ORG=", "LOADDG=", "ANDDG=", "ORDG=", "LOADG>", "ANDG>", "ORG>", "LOADDG>", "ANDDG>", "ORDG>"
                ,"LOADG<", "ANDG<", "ORG<", "LOADDG<", "ANDDG<", "ORDG<", "LOADG<>", "ANDG<>", "ORG<>", "LOADDG<>", "ANDDG<>", "ORDG<>","LOADG<=", "ANDG<="
                , "ORG<=", "LOADDG<=", "ANDDG<=", "ORDG<=", "LOADG>=", "ANDG>=", "ORG>=", "LOADDG>=", "ANDDG>=", "ORDG>=" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LOAD3=", "AND3=", "OR3=", "LOADD3=", "ANDD3=", "ORD3=", "LOAD3>", "AND3>", "OR3>", "LOADD3>", "ANDD3>", "ORD3>"
                , "LOAD3>=", "AND3>=", "OR3>=", "LOADD3>=", "ANDD3>=", "ORD3>=", "LOAD3<=", "AND3<=", "OR3<=", "LOADD3<=", "ANDD3<=", "ORD3<=", "LOAD3<>"
                , "AND3<>", "OR3<>", "LOADD3<>", "ANDD3<>", "ORD3<>", "LOAD3<", "AND3<", "OR3<", "LOADD3<", "ANDD3<", "ORD3<", "IORF", "IORFP"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PUTM", "PUTMP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LIMIT", "LIMITP", "DLIMIT", "DLIMITP", "DZONE", "DZONEP", "DDZONE", "DDZONEP", "DZONES", "DZONESP", "DDZONES"
                , "DDZONESP", "VZONE", "VZONEP", "DVZONE", "DVZONEP", "SCAL", "SCALP", "DSCAL", "DSCALP", "RSCAL", "RSCALP", "SCAL2", "SCAL2P", "DSCAL2"
                , "DSCAL2P", "RSCAL2", "RSCAL2P", "SENDDTR", "SENDRTS", "BAND", "BANDP", "DBAND", "DBANDP", "EQ2_INT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GETE", "GETEP", "PUTE", "PUTEP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS4_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SNDUDATA", "RCVUDATA" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        #endregion

        #region S# N# D#

        public static bool IsS0_N3_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TRAMP", "RTRAMP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_N2_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SORT", "SORTP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        #endregion


        #region Exceptions

        public static bool IsS1_D1_S1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MID", "MIDP", "REPLACE", "REPLACEP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN2_D1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RAMP", "RAMPP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsD1_S2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "CTUD" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        
        #endregion

        #region Import Special

        public static bool IsProgram(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "JMP", "BREAK", "CALL", "CALLP", "SBRT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsLABEL(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string>() { "LABEL" };

            if(ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        
        #endregion


        #endregion


        #region Private Methods

        #endregion
    }
}
