using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CCommonImportType
    {
        private static List<string> m_lstSpecialCommand = new List<string>() {  "VTP", "XVTP", "SKP", "XSKP", "RTP", "XRTP", "TSP", "TBP", "TEP", "THP", "TMP", "TCP"
            , "XSMP", "XSHP", "XSEP", "XSBP", "XSCP", "XSSSP", "XVTPP", "STP", "XSTP", "EXP" };

        private static string m_sPLCMaker = string.Empty;

        public static void SetContentParameter(string sCommand, EMPLCMaker emPLCMaker, CContentS cContentS)
        {
            m_sPLCMaker = emPLCMaker.ToString();

            if(sCommand.EndsWith("P") && !m_lstSpecialCommand.Contains(sCommand))
                sCommand = sCommand.TrimEnd('P');

            List<string> lstTemp = new List<string>();
            if (sCommand == string.Empty) return;
            else if (IsCommon_S0_D0_N0(sCommand, out lstTemp)) SetCommon_S0_D0_N0(sCommand, cContentS);
            else if (IsCommon_S0_D0_N1(sCommand, out lstTemp)) SetCommon_S0_D0_N1(sCommand, cContentS);
            else if (IsCommon_S0_D1_N0(sCommand, out lstTemp)) SetCommon_S0_D1_N0(sCommand, cContentS);
            else if (IsCommon_S0_D1_N1(sCommand, out lstTemp)) SetCommon_S0_D1_N1(sCommand, cContentS);
            else if (IsCommon_S0_D1_N2(sCommand, out lstTemp)) SetCommon_S0_D1_N2(sCommand, cContentS);
            else if (IsCommon_S0_D2_N0(sCommand, out lstTemp)) SetCommon_S0_D2_N0(sCommand, cContentS);
            else if (IsCommon_S0_D2_N1(sCommand, out lstTemp)) SetCommon_S0_D2_N1(sCommand, cContentS);
            else if (IsCommon_S0_N1_D1(sCommand, out lstTemp)) SetCommon_S0_N1_D1(sCommand, cContentS);
            else if (IsCommon_S0_N2_D1(sCommand, out lstTemp)) SetCommon_S0_N2_D1(sCommand, cContentS);
            else if (IsCommon_S0_N3_D1(sCommand, out lstTemp)) SetCommon_S0_N3_D1(sCommand, cContentS);
            else if (IsCommon_S0_N3_D0(sCommand, out lstTemp)) SetCommon_S0_N3_D0(sCommand, cContentS);
            else if (IsCommon_S0_N5_D0(sCommand, out lstTemp)) SetCommon_S0_N5_D0(sCommand, cContentS);
            else if (IsCommon_S1_D0_N0(sCommand, out lstTemp)) SetCommon_S1_D0_N0(sCommand, cContentS);
            else if (IsCommon_S1_D0_N1(sCommand, out lstTemp)) SetCommon_S1_D0_N1(sCommand, cContentS);
            else if (IsCommon_S1_D1_N0(sCommand, out lstTemp)) SetCommon_S1_D1_N0(sCommand, cContentS);
            else if (IsCommon_S1_D1_N1(sCommand, out lstTemp)) SetCommon_S1_D1_N1(sCommand, cContentS);
            else if (IsCommon_S1_D1_N2(sCommand, out lstTemp)) SetCommon_S1_D1_N2(sCommand, cContentS);
            else if (IsCommon_S1_D1_N3(sCommand, out lstTemp)) SetCommon_S1_D1_N3(sCommand, cContentS);
            else if (IsCommon_S1_D1_N4(sCommand, out lstTemp)) SetCommon_S1_D1_N4(sCommand, cContentS);
            else if (IsCommon_S1_D1_N5(sCommand, out lstTemp)) SetCommon_S1_D1_N5(sCommand, cContentS);
            else if (IsCommon_S1_D1_N1_D1(sCommand, out lstTemp)) SetCommon_S1_D1_N1_D1(sCommand, cContentS);
            else if (IsCommon_S1_D1_S1(sCommand, out lstTemp)) SetCommon_S1_D1_S1(sCommand, cContentS);
            else if (IsCommon_S1_D2_N0(sCommand, out lstTemp)) SetCommon_S1_D2_N0(sCommand, cContentS);
            else if (IsCommon_S1_D2_N1(sCommand, out lstTemp)) SetCommon_S1_D2_N1(sCommand, cContentS);
            else if (IsCommon_S1_D3_N0(sCommand, out lstTemp)) SetCommon_S1_D3_N0(sCommand, cContentS);
            else if (IsCommon_S1_N1_D1(sCommand, out lstTemp)) SetCommon_S1_N1_D1(sCommand, cContentS);
            else if (IsCommon_S1_N1_D2(sCommand, out lstTemp)) SetCommon_S1_N1_D2(sCommand, cContentS);
            else if (IsCommon_S1_N1_S1_D2(sCommand, out lstTemp)) SetCommon_S1_N1_S1_D2(sCommand, cContentS);
            else if (IsCommon_S1_N2_D1(sCommand, out lstTemp)) SetCommon_S1_N2_D1(sCommand, cContentS);
            else if (IsCommon_S2_D0_N0(sCommand, out lstTemp)) SetCommon_S2_D0_N0(sCommand, cContentS);
            else if (IsCommon_S2_D1_N0(sCommand, out lstTemp)) SetCommon_S2_D1_N0(sCommand, cContentS);
            else if (IsCommon_S2_D2_N0(sCommand, out lstTemp)) SetCommon_S2_D2_N0(sCommand, cContentS);
            else if (IsCommon_S2_D3_N0(sCommand, out lstTemp)) SetCommon_S2_D3_N0(sCommand, cContentS);
            else if (IsCommon_S2_D1_N1(sCommand, out lstTemp)) SetCommon_S2_D1_N1(sCommand, cContentS);
            else if (IsCommon_S2_D1_S1(sCommand, out lstTemp)) SetCommon_S2_D1_S1(sCommand, cContentS);
            else if (IsCommon_S3_D0_N0(sCommand, out lstTemp)) SetCommon_S3_D0_N0(sCommand, cContentS);
            else if (IsCommon_S3_D0_N1(sCommand, out lstTemp)) SetCommon_S3_D0_N1(sCommand, cContentS);
            else if (IsCommon_S3_D1_N0(sCommand, out lstTemp)) SetCommon_S3_D1_N0(sCommand, cContentS);
            else if (IsCommon_S3_D1_N1(sCommand, out lstTemp)) SetCommon_S3_D1_N1(sCommand, cContentS);
            else if (IsCommon_S4_D1_N0(sCommand, out lstTemp)) SetCommon_S4_D1_N0(sCommand, cContentS);
            else if (IsCommon_N1_D1_N1(sCommand, out lstTemp)) SetCommon_N1_D1_N1(sCommand, cContentS);
            else if (IsCommon_N1_S1_D0(sCommand, out lstTemp)) SetCommon_N1_S1_D0(sCommand, cContentS);
            else if (IsCommon_N1_S1_D1(sCommand, out lstTemp)) SetCommon_N1_S1_D1(sCommand, cContentS);
            else if (IsCommon_N1_S1_D2(sCommand, out lstTemp)) SetCommon_N1_S1_D2(sCommand, cContentS);
            else if (IsCommon_N1_S2_D1(sCommand, out lstTemp)) SetCommon_N1_S2_D1(sCommand, cContentS);
            else if (IsCommon_N1_S2_D2(sCommand, out lstTemp)) SetCommon_N1_S2_D2(sCommand, cContentS);
            else if (IsCommon_N1_S3_D1(sCommand, out lstTemp)) SetCommon_N1_S3_D1(sCommand, cContentS);
            else if (IsCommon_N1_S5_D1(sCommand, out lstTemp)) SetCommon_N1_S5_D1(sCommand, cContentS);
            else if (IsCommon_N2_D1_N1(sCommand, out lstTemp)) SetCommon_N2_D1_N1(sCommand, cContentS);
            else if (IsCommon_N2_D1_N1_D1(sCommand, out lstTemp)) SetCommon_N2_D1_N1_D1(sCommand, cContentS);
            else if (IsCommon_N2_S1_N1(sCommand, out lstTemp)) SetCommon_N2_S1_N1(sCommand, cContentS);
            else if (IsCommon_N3_S1_D1(sCommand, out lstTemp)) SetCommon_N3_S1_D1(sCommand, cContentS);
            else if (IsCommon_D0_S2_N1(sCommand, out lstTemp)) SetCommon_D0_S2_N1(sCommand, cContentS);

        }

        #region Is Function

        public static bool IsCommon_S0_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RET", "AFI", "NOP", "NOPLE", "NEXT", "BREAK", "GOEND", "CHKST", "CHK", "CHKIR", "CHKEND", "SLT", "SLTR", "STRA", "STRAR", "PTRA", "PTRAR", "PTRAEXE", "INV", "BE", "BEC", "BEU", "LAR1"
                , "LAR2", "LOAD", "TAR1", "TAR2", "+AR1", "+AR2", "TAK", "PUSH", "POP", "ENT", "LEAVE", "ONS", "ONSF"  };
            //BREAK(MITSUBISHI S0D1N1), ONS, ONSF
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MCR", "PAGE", "FOR", "CJ", "SCJ", "JC", "JCN", "JU", "JNB", "LOOP", "TRANSFER"  };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "XIC", "XICF", "XIO", "OUT", "OUTF", "OUTN", "SET", "RST", "PLS", "PLF", "abMSG", "mMSG", "PKEY", "CMP", "INC", "DINC", "4INC", "8INC", "UINC", "DEC", "DDEC"
                , "4DEC", "8DEC", "UDEC", "NEG", "DNEG", "RNEG", "LNEG", "ENEG", "ABS", "DABS", "CLR", "JMP", "LABEL", "CALL", "FCALL", "SBRT", "DATERD", "ROR", "RCR", "ROL", "RCL", "DROR", "DRCR", "DROL"
                , "DRCR", "DRCL", "4ROR", "4RCR", "4ROL", "4RCL", "8ROR", "8RCR", "8ROL", "8RCL", "FF" };
                //ONSP, CMP(AB, LS는 S2D0N0), NEG(AB는 S1D1N0), ABS(AB S1D1N0), CALL, FCALL(MITSUBISHI S1D1N0), 
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "OSR", "OSP", "TON", "TONH", "TOFF", "RTO", "RTOH", "TMON", "TRTG", "CTU", "CTD", "CTR", "BSET", "BRST", "BSFL", "SFR", "SFL", "DSFR", "DSFL", "4SFR", "8SFR", "4SFL"
                , "8SFL", "WSFL", "WSFR", "TTMR", "STMR", "MC" };
            //TON AB는 S0D1N2, TOFF, RTO,CTU,CTD도 마찬가지
            if (ListIL.Contains(sCommand))
                return true;
            else
            {
                List<string> lstXGI = new List<string>{"TON", "TOF", "TP"} ;

                foreach (var who in lstXGI)
                {
                    if (sCommand.Contains(who))
                        return true;
                }

                return false;
            }
        }

        public static bool IsCommon_S0_D1_N2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SWAP", "DSWAP",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BSWAP", "GSWAP", "BWSFL", "BWSFR",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RFS" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_N2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PLSY", "MTR", "DUTY" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_N3_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TRAMP", "RTRAMP",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_N3_D0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "P2PSN" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S0_N5_D0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "P2PWWR", "P2PBRD", "P2PBWR", };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DATEWR", "RSET", "OPN"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BKRST", };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "EXPT", "PULT", "RODT", "SQRT", "BSQRT", "BDSQRT", "MOV", "DMOV", "$MOV", "EMOV", "4MOV", "8MOV", "CMOV", "DCMOV", "RMOV", "LMOV", "2SWAP", "G2SWAP", "NOT", "DNOT"
                ,"SIN", "BSIN", "COS", "BCOS", "TAN", "BTAN", "ASIN", "BASIN", "ACOS", "BACOS", "ATAN", "BATAN", "LN", "LNP", "LOG", "EXP", "DEG", "RAD", "TRN", "BCD", "DBCD", "4BCD", "8BCD", "BIN", "DBIN"
                , "4BIN", "8BIN", "SECOND", "HOUR", "BSUM", "DBSUM", "SEG", "ITOR", "ITOL", "DTOR", "DTOL", "RTOI", "RTOD", "LTOI", "LTOD", "RTOL", "LTOR", "UTOR", "UTOL", "UDTOR", "UDTOL", "RTOU", "RTOUD", "LTOU"
                , "LTOUD", "WTODW", "DWTOW", "ITOG", "DTOG", "GTOI", "GTOD", "FIWR", "FIFRD", "FILRD", "BINDA", "DBINDA", "BINHA", "DBINHA", "BCDDA", "DBCDDA", "DBAIN", "DDABIN", "HABIN", "DHABIN", "DABCD"
                , "DDABCD", "COMRD", "LEN", "BTI", "ITB", "ITD", "DTB", "DTR", "INVI", "INVD", "NEGI", "NEGD", "NEGR", "CAW", "CAD", "RND", "TRUNC", "RND+", "RND-", "ADRSET", "ORG", "XORG", "FLT", "XFLT"
                , "VTP", "XVTP", "PTV", "SKP", "XSKP", "NMV", "XNMV", "RTP", "XRTP", "MOF", "XMOF", "ZOE", "ZOD", "EMG", "XEMG", "ECLR", "XECLR", "XECON", "XDCON", "XSVON", "XSVOFF", "XSCLR", "XSECLR", "XRSTR" , "MOVE_INT"};
            //SEG (LS S2D1N0)
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "FMOV", "mBMOV", "lsBMOV", "GMOV", "GBMOV", "BKBCD", "BKBIN", "DECO", "ENCO", "DIS", "UNI", "WTOB", "BTOW", "SUM", "DSUM", "AVE", "DAVE", "UDCNT1", "UDCNT2", "SPD"
                , "FINS", "FDEL", "ASC", "HEX", "RIGHT", "LEFT", "IST", "XIST", "XVTPP", "XPTT", "STP", "XSTP", "POR", "XPOR", "SOR", "XSOR", "PSO", "XPSO", "INCH", "XINCH", "SNS", "XSNS", "SRS", "XSRS"
                ,"PRS", "XPRS", "EPRS", "XEPRS", "CLR", "XCLR", "PST", "XPST", "TSP", "XSES", "WRT", "XWRT", "XSVSAVE", "XLRD", "XLCLR", "RBMOV"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GBMOV", "GBMOVP", "LIN", "CIN", "TBP", "TEP", "THP", "TMP", "TCP"
                , "PWR", "XPWR", "TWR", "XTWR", "TMD", "XSMD", "SCAM", "XSWR", "XTRQ", "XLSET" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N3(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SSP", "XSSP", "SSS", "XSSS", "XCAMO", "XELIN", "VRD", "XVRD", "XSMP", "XSHP", "XSEP", "XSBP", "XSCP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N4(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SST", "XSST", "TEA", "TEAA", "XTEAA", "XSSSP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N5(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DST", "XDST", "VWR", "XVWR", "XSVPWR", "XSTC" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D1_S1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MID", "REPLACE",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SRD", "XSRD" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "ROTC" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_D3_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SSV" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "CTU_INT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_N1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_N1_S1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SORT", "DSORT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_N2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S2_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DCMP", "4CMP", "8CMP", "EQU", "DEQU", "EEQU", "$EQU", "LEQU", "4EQU", "8EQU", "UEQU", "UDEQU", "GEQ", "DGEQ", "EGEQ", "$GEQ", "LGEQ", "4GEQ", "8GEQ", "UGEQ", "UDGEQ"
                ,"GRT", "DGRT", "EGRT", "$GRT", "LGRT", "4GRT", "8GRT", "UGRT", "UDGRT", "LEQ", "DLEQ", "ELEQ", "$LEQ", "LLEQ", "4LEQ", "8LEQ", "ULEQ", "UDLEQ", "LES", "DLES", "ELES", "$LES", "LLES", "4LES"
                , "8LES", "ULES", "UDLES", "NEQ", "DNEQ", "ENEQ", "$NEQ", "LNEQ", "4NEQ", "8NEQ", "UNEQ", "UDNEQ", "BSFT", "WSFT",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S2_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TCMP", "DTCMP", "ADD", "DADD", "BADD", "DBADD", "$ADD", "EADD", "RADD", "LADD", "UADD", "DUADD", "SUB", "DSUB", "BSUB", "DBSUB", "$SUB", "ESUB", "RSUB", "LSUB", "USUB"
                , "DUSUB", "MUL", "DMUL", "BMUL", "DBMUL", "EMUL", "RMUL", "LMUL", "UMUL", "DUMUL", "DIV", "DDIV", "BDIV", "DBDIV", "EDIV", "RDIV", "LDIV", "UDIV", "DUDIV", "MVM", "SWPB", "AND", "WAND", "DAND"
                , "OR", "WOR", "DOR", "XOR", "WXOR", "DXOR", "XNR", "WXNR", "DXNR", "XPY", "ADDCLK", "SUBCLK", "TEST", "DTEST", "NDIS", "NUNI", "ADS", "ADU", "STR", "DSTR", "VAL", "DVAL", "RSTR", "LSTR", "STRR"
                , "STRL", "RBCD", "LBCD", "BCDR", "BCDL", "SLW", "SRW", "SLD", "SRD", "SSI", "SSD", "ZP.ERRCLR", "ZP.PFWRT" , "EXP", "EQ2_INT" };
            //ADD S1D1N0, SUB, WAND(D), , WOR, WXOR, WXNR
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsCommon_S2_D3_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RCVUDATA", "JP.SWRITE", "JP.SREAD" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S2_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GP.INPUT", "JP.READ", "JP.WRITE" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        
        public static bool IsCommon_S2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BKEQU", "BKDEQU", "BKGEQ", "BKDGEQ", "BKGRT", "BKDGRT", "BKLEQ", "BKDLEQ", "BKLES", "BKDLES", "BKNEQ", "BKDNEQ", "BKADD", "BKSUB", "BKAND", "BAND", "ABAND", " BKOR", "BOR"
                , "ABOR", "BKXOR", "BXOR", "ABXOR", "BKXNR", "BXNR", "ABXNR", "SR", "BRR", "BRL", "SER", "DSER", "MAX", "DMAX", "MIN", "DMIN", "MUX", "DMUX", "DETECT", "FIND", "GET", "PUT", "GETM"   };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S2_D1_S1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BTD" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S3_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GEQU", "GDEQU", "3EQU", "3DEQU", "GGEQ", "GDGEQ", "3GEQ", "3DGEQ", "GGRT", "GDGRT", "3GRT", "3DGRT", "GLEQ", "GDLEQ", "3LEQ", "3DLEQ", "GLES", "GDLES", "3LES", "3DLES"
                , "GNEQ", "GDNEQ", "3NEQ", "3DNEQ", "abLIM", "abDLIM", "MEQ", "IORF",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S3_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PUTM"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S3_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GSV", "mLIM", "lsLIM", "mDLIM", "lsDLIM", "SENDDTR", "SENDDRTS", "ZP.OPEN", "ZP.CLOSE", "GP.OUTPUT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S3_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GETE", "PUTE" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S4_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SNDUDATA",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S1_D0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S2_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DP.DDRD", "DP.DDWR"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S3_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N1_S5_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.RLPASET", "GP.RLPLASET"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "FROM", "DFROM", "TO", "DTO",  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N2_D1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RAMP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N2_S1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_N3_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_D0_S2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "CTUD" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsCommon_S1_N2_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GP.ECPRTCL" };
            //ADD S1D1N0, SUB, WAND(D), , WOR, WXOR, WXNR
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        #endregion

        #region Set Function

        private static void SetCommon_S2_D2_N0(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S1_N2_S1_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.N2.ToString();
                cContentS[3].Parameter = EMParametorType.N2.ToString();
                cContentS[4].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S0_D0_N0(string sCommand, CContentS cContentS)
        {
            //Nothing to do...

            if (sCommand.Contains("BREAK") && m_sPLCMaker.Contains("Mitsubishi"))
                SetCommon_S0_D1_N1(sCommand, cContentS);
            else if (sCommand.Contains("ONS") && (m_sPLCMaker.Contains("AB") || m_sPLCMaker.Contains("Mitsubishi")) && cContentS.Count == 1)
                SetCommon_S1_D0_N0(sCommand, cContentS);
            else if (sCommand.Contains("ONS") && m_sPLCMaker.Contains("Siemens"))
                SetCommon_S0_D1_N0(sCommand, cContentS);
        }

        private static void SetCommon_S0_D0_N1(string sCommand, CContentS cContentS)
        {
            if (sCommand.Contains("") && m_sPLCMaker.Contains("Mitsubishi") && cContentS.Count == 2)
                SetCommon_S0_N1_D1(sCommand, cContentS);
            else if(cContentS.Count == 1)
                cContentS[0].Parameter = EMParametorType.N1.ToString();
        }

        private static void SetCommon_S0_D1_N0(string sCommand, CContentS cContentS)
        {
            if (sCommand.Contains("CMP") && m_sPLCMaker.Contains("LS"))
                SetCommon_S2_D0_N0(sCommand, cContentS);
            else if ((sCommand.Contains("NEG") || sCommand.Contains("ABS")) && m_sPLCMaker.Contains("AB"))
                SetCommon_S1_D1_N0(sCommand, cContentS);
            else if(sCommand.Contains("FCALL") && cContentS.Count == 2)
                SetCommon_S1_D1_N0(sCommand, cContentS);
            else if(cContentS.Count == 1)
                cContentS[0].Parameter = EMParametorType.D1.ToString();
        }

        private static void SetCommon_S0_D1_N1(string sCommand, CContentS cContentS)
        {
            if ((sCommand.Contains("TON") || sCommand.Contains("TOFF") || sCommand.Contains("RTO") || sCommand.Contains("CTU") || sCommand.Contains("CTD")) && m_sPLCMaker.Contains("AB"))
                SetCommon_S0_D1_N2(sCommand, cContentS);
            else if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.D1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S0_D1_N2(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.D1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.N2.ToString();
            }
        }

        private static void SetCommon_S0_D2_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.D1.ToString();
                cContentS[1].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S0_D2_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.D1.ToString();
                cContentS[1].Parameter = EMParametorType.D2.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S0_N1_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S0_N2_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S0_N3_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.N3.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S0_N3_D0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.N3.ToString();
            }
        }

        private static void SetCommon_S0_N5_D0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.N3.ToString();
                cContentS[3].Parameter = EMParametorType.N4.ToString();
                cContentS[4].Parameter = EMParametorType.N5.ToString();
            }
        }

        private static void SetCommon_S1_D0_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 1)
                cContentS[0].Parameter = EMParametorType.S1.ToString();            
        }

        private static void SetCommon_S1_D0_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S1_D1_N0(string sCommand, CContentS cContentS)
        {
            if (sCommand.Contains("SEG") && m_sPLCMaker.Contains("LS"))
                SetCommon_S2_D1_N0(sCommand, cContentS);
            else if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S1_D1_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S1_D1_N2(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
                cContentS[3].Parameter = EMParametorType.N2.ToString();
            }
        }

        private static void SetCommon_S1_D1_N3(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
                cContentS[3].Parameter = EMParametorType.N2.ToString();
                cContentS[4].Parameter = EMParametorType.N3.ToString();

            }
        }

        private static void SetCommon_S1_D1_N4(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 6)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
                cContentS[3].Parameter = EMParametorType.N2.ToString();
                cContentS[4].Parameter = EMParametorType.N3.ToString();
                cContentS[5].Parameter = EMParametorType.N4.ToString();
            }
        }

        private static void SetCommon_S1_D1_N5(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 7)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
                cContentS[3].Parameter = EMParametorType.N2.ToString();
                cContentS[4].Parameter = EMParametorType.N3.ToString();
                cContentS[5].Parameter = EMParametorType.N4.ToString();
                cContentS[6].Parameter = EMParametorType.N5.ToString();
            }
        }

        private static void SetCommon_S1_D1_N1_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
                cContentS[3].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S1_D1_S1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.S2.ToString();
            }
        }

        private static void SetCommon_S1_D2_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S1_D2_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.D2.ToString();
                cContentS[3].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S1_D3_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.D2.ToString();
                cContentS[3].Parameter = EMParametorType.D3.ToString();
            }
        }

        private static void SetCommon_S1_N1_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S1_N1_D2(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S1_N1_S1_D2(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.S2.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
                cContentS[4].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_S1_N2_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.N1.ToString();
                cContentS[2].Parameter = EMParametorType.N2.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S2_D0_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
            }
        }

        private static void SetCommon_S2_D1_N0(string sCommand, CContentS cContentS)
        {
            if ((sCommand.Contains("ADD") || sCommand.Contains("SUB") || sCommand.Contains("AND") || sCommand.Contains("OR") || sCommand.Contains("XNR")) && m_sPLCMaker.Contains("Mitsubishi") && cContentS.Count == 2)
                SetCommon_S1_D1_N0(sCommand, cContentS);
            else if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S2_D3_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.D2.ToString();
                cContentS[4].Parameter = EMParametorType.D3.ToString();
            }
        }

        private static void SetCommon_S2_D1_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S2_D1_S1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.S3.ToString();
            }
        }

        private static void SetCommon_S3_D0_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.S3.ToString();
            }
        }

        private static void SetCommon_S3_D0_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.S3.ToString();
                cContentS[3].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S3_D1_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.S3.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_S3_D1_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.S3.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
                cContentS[4].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_S4_D1_N0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.S3.ToString();
                cContentS[3].Parameter = EMParametorType.S4.ToString();
                cContentS[4].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_N1_D1_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.D1.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_N1_S1_D0(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 2)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
            }
        }

        private static void SetCommon_N1_S1_D1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_N1_S1_D2(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_N1_S2_D1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.D2.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_N1_S2_D2(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.S2.ToString();
                cContentS[3].Parameter = EMParametorType.D1.ToString();
                cContentS[4].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_N1_S3_D1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.S2.ToString();
                cContentS[3].Parameter = EMParametorType.S3.ToString();
                cContentS[4].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_N1_S5_D1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 7)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.S1.ToString();
                cContentS[2].Parameter = EMParametorType.S2.ToString();
                cContentS[3].Parameter = EMParametorType.S3.ToString();
                cContentS[4].Parameter = EMParametorType.S4.ToString();
                cContentS[5].Parameter = EMParametorType.S5.ToString();
                cContentS[6].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_N2_D1_N1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.N3.ToString();
            }
        }

        private static void SetCommon_N2_D1_N1_D1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.D1.ToString();
                cContentS[3].Parameter = EMParametorType.N3.ToString();
                cContentS[4].Parameter = EMParametorType.D2.ToString();
            }
        }

        private static void SetCommon_N2_S1_N1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 4)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.S1.ToString();
                cContentS[3].Parameter = EMParametorType.N1.ToString();
            }
        }

        private static void SetCommon_N3_S1_D1(string sCommand, CContentS cContentS)
        {
            if (cContentS.Count == 5)
            {
                cContentS[0].Parameter = EMParametorType.N1.ToString();
                cContentS[1].Parameter = EMParametorType.N2.ToString();
                cContentS[2].Parameter = EMParametorType.N3.ToString();
                cContentS[3].Parameter = EMParametorType.S1.ToString();
                cContentS[4].Parameter = EMParametorType.D1.ToString();
            }
        }

        private static void SetCommon_D0_S2_N1(string sCommand, CContentS cContentS)
        {
            if(cContentS.Count == 3)
            {
                cContentS[0].Parameter = EMParametorType.S1.ToString();
                cContentS[1].Parameter = EMParametorType.S2.ToString();
                cContentS[2].Parameter = EMParametorType.N1.ToString();
            }
        }      


        #endregion

    }
}
