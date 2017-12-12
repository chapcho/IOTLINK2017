using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using UDM.General;
using UDM.Common;


namespace UDM.Converter
{
    public class CILImportType
    {
        // S: Source, D: Destination, N : Numeric
        // Melsec Q CPU 기준 645개 33 타입

        public static List<string> GetCommandAll()
        {
            List<string> lstCommandAll = new List<string>();
            List<string> lstCommand = new List<string>();

            IsS0_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N2_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N4_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_S1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D2_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D2_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N1_S1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N2_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D2_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS3_D1_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S2_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S2_D2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN1_S3_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_D1_N1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_S1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN3_S1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsArithmetic(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsFile(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsNetwork(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsProgram(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsProgramNumber(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);

            return lstCommandAll;
        }

        public static EMCoilImport GetType(string strCommand)
        {
            List<string> lstTemp = new List<string>();
            if (strCommand == string.Empty) return EMCoilImport.EMPTY;
            if (IsS0_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N0;
            if (IsS0_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N1;
            if (IsS0_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N0;
            if (IsS0_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N1;
            if (IsS0_D1_N2(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N2;
            if (IsS0_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N0;
            if (IsS0_D2_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N1;
            if (IsS0_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N1_D1;
            if (IsS0_N2_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N2_D1;
            if (IsS0_N4_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N4_D1;
            if (IsS1_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N0;
            if (IsS1_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N1;
            if (IsS1_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N0;
            if (IsS1_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N1;
            if (IsS1_D1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N1_D1;
            if (IsS1_D1_S1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_S1;
            if (IsS1_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D2_N0;
            if (IsS1_D2_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D2_N1;
            if (IsS1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S1_N1_D1;
            if (IsS1_N1_D2(strCommand, out lstTemp)) return EMCoilImport.S1_N1_D2;
            if (IsS1_N1_S1_D2(strCommand, out lstTemp)) return EMCoilImport.S1_N1_S1_D2;
            if (IsS1_N2_D1(strCommand, out lstTemp)) return EMCoilImport.S1_N2_D1;
            if (IsS2_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D0_N0;
            if (IsS2_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N0;
            if (IsS2_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D2_N0;
            if (IsS2_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N1;
            if (IsS3_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S3_D1_N0;
            if (IsN1_D1_N1(strCommand, out lstTemp)) return EMCoilImport.N1_D1_N1;
            if (IsN1_S1(strCommand, out lstTemp)) return EMCoilImport.N1_S1;
            if (IsN1_S1_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S1_D1;
            if (IsN1_S1_D2(strCommand, out lstTemp)) return EMCoilImport.N1_S1_D2;
            if (IsN1_S2_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S2_D1;
            if (IsN1_S2_D2(strCommand, out lstTemp)) return EMCoilImport.N1_S2_D2;
            if (IsN1_S3_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S3_D1;
            if (IsN2_D1_N1(strCommand, out lstTemp)) return EMCoilImport.N2_D1_N1;
            if (IsN2_D1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.N2_D1_N1_D1;
            if (IsN2_S1_N1(strCommand, out lstTemp)) return EMCoilImport.N2_S1_N1;
            if (IsN3_S1_D1(strCommand, out lstTemp)) return EMCoilImport.N3_S1_D1;
            if (IsArithmetic(strCommand, out lstTemp)) return EMCoilImport.Arithmetic;
            if (IsFile(strCommand, out lstTemp)) return EMCoilImport.File;
            if (IsNetwork(strCommand, out lstTemp)) return EMCoilImport.Network;
            if (IsProgram(strCommand, out lstTemp)) return EMCoilImport.Program;
            if (IsProgramNumber(strCommand, out lstTemp)) return EMCoilImport.ProgramLabel;

            return EMCoilImport.NONE;
        }

        #region S# D# N#

        public static bool IsS0_D0_N0(string sCommand,out  List<string> ListIL)
        {
            ListIL = new List<string> { "ANB", "ORB", "MPS", "MRD", "MPP", "INV", "MEP", "MEF", "EGP"
                , "EGF", "FEND", "END", "STOP", "NOP", "NOPLE", "GOEND", "DI", "EI", "IRET", "NEXT", "RET", "COM"
                , "IXEND", "IXDEV", "LEDR", "CHKST", "CHK", "CHKCIR", "CHKEND", "SLT", "SLTR", "STRA", "STRAR", "PTRA"
                , "PTRAR", "PTRAEXE", "PTRAEXEP", "PLOW", "PLOWP", "WDT", "WDTP", "TRACE", "TRACER", "NOPLF" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LD", "LDI", "AND", "ANI", "OR", "ORI", "LDP","LDPI", "LDF", "LDFI"
                , "ANDP", "ANDF", "ANDPI", "ANDFI", "ORP", "ORF","ORPI","ORFI", "SET", "RST", "OUT", "OUTH", "PLS", "PLF", "FF", "DELTA", "DELTAP", "SFT"
                , "SFTP", "INC", "INCP", "DINC", "DINCP", "DEC", "DECP", "DDEC", "DDECP", "NEG", "NEGP"
                , "DNEG", "DNEGP", "ENEG", "ENEGP", "SWAP", "SWAPP", "RND", "RNDP", "DATERD"
                , "DATERDP", "PKEY", "ZPUSH", "ZPUSHP", "ZPOP", "ZPOPP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MCR", "PAGE", "FOR", "S.ZCOM" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TTMR", "ROR", "RORP", "RCR", "RCRP", "ROL", "ROLP", "RCL"
                , "RCLP", "DROR", "DRORP", "DRCR", "DRCRP", "DROL", "DROLP", "DRCL", "DRCLP", "SFR", "SFRP", "SFL"
                , "SFLP", "BSFR", "BSFRP", "BSFL", "BSFLP", "DSFR", "DSFRP", "DSFL", "DSFLP", "BSET", "BSETP"
                , "BRST", "BRSTP", "BKRST", "BKRSTP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D1_N2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SFTWL", "SFTWLP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "IMASK", "IX", "LED", "LEDC", "RSET", "RSETP", "DATEWR", "DATEWRP"
                , "MSG", "S.CGMODE", "S.TRUCK", "S.SPREF", "QDRSET", "QDRSETP", "QCDSET", "ZCDSETP", "PSTOP", "PSTOPP"
                , "POFF", "POFFP", "PSCAN", "PSCANP", "ANI", "ANDPI","ANDFI", "SRND", "SRNDP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BCD", "BCDP", "DBCD", "DBCDP", "BIN", "BINP", "DBIN", "DBINP"
                , "FLT", "FLTP", "DFLT", "DFLTP", "INT", "INTP", "DINT", "DINTP", "DBL", "DBLP", "WORD", "WORDP", "GRY"
                , "GRYP", "DGRY", "DGRYP", "GBIN", "GBINP", "DGBIN", "DGBIN", "DGBINP", "MOV", "MOVP", "DMOV", "DMOVP"
                , "EMOV", "EMOVP", "$MOV", "$MOVP", "CML", "CMLP", "DCML", "DCMLP", "SUM", "SUMP", "DSUM", "DSUMP", "SEG"
                , "SEGP", "FIFW", "FIFWP", "FIFR", "FIFRP", "FPOP", "FPOPP", "PR", "PRC", "BINDA", "BINDAP", "DBINDA", "DBINDAP"
                , "BINHA", "BINHAP", "DBINHA", "DBINHAP", "BCDDA", "BCDDAP", "DBCDDA", "DBCDDAP", "DABIN", "DABINP", "DDABIN"
                , "DDABINP", "HABIN", "HABINP", "DHABIN", "DHABINP", "DABCD", "DABCDP", "DDABCD", "DDABCDP", "COMRD", "COMRDP"
                , "EVAL", "EVALP", "LENP", "SIN", "SINP", "COS", "COSP", "TAN", "TANP", "ASIN", "ASINP", "ACOS", "ACOSP", "ATAN"
                , "ATANP", "RAD", "RADP", "DEG", "DEGP", "SQR", "SQRP", "EXP", "EXPP", "LOG", "LOGP", "BSIN", "BSINP", "BCOS"
                , "BCOSP", "BTAN", "BTANP", "BASIN", "BASINP", "BACOS", "BACOSP", "BATAN", "BATANP", "SECOND", "SECONDP", "HOUR"
                , "HOURP", "ADRSET", "ADRSETP", "PLOADP", "PUNLOADP", "BSQR", "BSQRP", "BDSQR", "BDSQRP", "LEN", "LENP"
                , "S.SOCRCVS", "SP.SOCRCVS" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "XCH", "XCHP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DXCH", "DXCHP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RFS" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BKBCD", "BKBCDP", "BKBIN", "BKBINP", "BMOV", "BMOVP", "FMOV"
                , "FMOVP", "BXCH", "BXCHP", "UDCNT1", "UDCNT2", "DECO", "DECOP", "ENCO", "ENCOP", "DIS", "DISP"
                , "UNI", "UNIP", "WTOB", "WTOBP", "BTOW", "BTOWP", "MAX", "MAXP", "MIN", "MINP", "DMAX", "DMAXP"
                , "DMIN", "DMINP", "WSUM", "WSUMP", "DWSUM", "DWSUMP", "FINS", "FINSP", "FDEL", "FDELP", "ASC"
                , "ASCP", "HEX", "HEXP", "RIGHT", "RIGHTP", "LEFT", "LEFTP", "RBMOV", "RBMOVP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "VAL", "VALP", "DVAL", "DVALP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MTR" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LD=", "AND=", "OR=", "LD<>", "AND<>", "OR<>", "LD>", "AND>"
                , "OR>", "LD<=", "AND<=", "OR<=", "LD<", "AND<", "OR<", "LD>=", "AND>=", "OR>=", "LDD=", "ANDD="
                , "ORD=", "LDD<>", "ANDD<>", "ORD<>", "LDD>", "ANDD>", "ORD>", "LDD<=", "ANDD<=", "ORD<=", "LDD<"
                , "ANDD<", "ORD<", "LDD>=", "ANDD>=", "ORD>=", "LDE=", "ANDE=", "ORE=", "LDE<>", "ANDE<>", "ORE<>"
                , "LDE>", "ANDE>", "ORE>", "LDE<=", "ANDE<=", "ORE<=", "LDE<", "ANDE<", "ORE<", "LDE>=", "ANDE>="
                , "ORE>=", "LD$=", "AND$=", "OR$=", "LD$<>", "AND$<>", "OR$<>", "LD$>", "AND$>", "OR$>", "LD$<="
                , "AND$<=", "OR$<=", "LD$<", "AND$<", "OR$<", "LD$>=", "AND$>=", "OR$>=", "S.STMODE"
                ,"S.SOCRMODE","SP.SOCRMODE","S.SOCCSET","SP.SOCCSET" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "*", "*P", "/", "/P", "D*", "D*P", "D/", "D/P", "B*", "B*P"
                , "B/", "B/P", "DB*", "DB*P", "DB/", "DB/P", "E*", "E*P", "E/", "E/P", "BK+", "BK+P", "BK-", "BK-P"
                , "TEST", "TESTP", "DTEST", "DTESTP", "STR", "STRP", "DSTR", "DSTRP", "ESTR", "ESTRP", "EMOD"
                , "EMODP", "EREXP", "EREXPP", "DATE+", "DATE+P", "DATE-", "DATE", "PSWAPP"
                ,"S.SOCCINF","SP.SOCCINF","S.SOCOPEN","SP.SOCOPEN","S.SOCCLOS","SP.SOCCLOS" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "S.SOCRCV", "SP.SOCRCV" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsS2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BKCMP=", "BKCMP<>", "BKCMP>", "BKCMP<=", "BKCMP<", "BKCMP>="
                , "BKCMP=P", "BKCMP<>P", "BKCMP>P", "BKCMP<=P", "BKCMP<P", "BKCMP>=P", "BKAND", "BKANDP", "BKOR"
                , "BKORP", "BKXOR", "BKXORP", "BKXNR", "BKXNRP", "SER", "SERP", "DSER", "DSERP", "INSTR", "INSTRP"
                ,"S.SOCRDATA","SP.SOCRDATA" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LIMIT", "LIMITP", "DLIMIT", "DLIMITP", "BAND", "BANDP"
                , "DBAND", "DBANDP", "ZONE", "ZONEP", "DZONE", "DZONEP","S.SOCSND","SP.SOCSND" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        #endregion

        #region S# N# D#

        public static bool IsS0_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MC", "ZRRDB", "ZRRDBP", "Z.RTREAD", "ZP.RTREAD", "S.RTREAD", "SP.RTREAD" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_N2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PLSY", "PWM", "DUTY", "SPD" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_N4_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "S.TO", "S.TOP", "SP.TO", "SP.DDRD", "S.DDRD", "SP.DDWR", "S.DDWR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "STMR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsS1_N1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "KEY" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_N2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "ROTC" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        #endregion

        #region Import Exception

        public static bool IsN2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "FROM", "FROMP", "DFRO", "DFROP", "G.BBLKRD" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        public static bool IsN2_D1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "RAMP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_S1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "NDIS", "NDISP", "NUNI", "NUNIP", "MIDR", "MIDRP", "MIDW", "MIDWP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "UNIRD", "UNIRDP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_N1_S1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SORT", "DSORT" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        public static bool IsN1_S2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.BIDOUT", "G.OUTPUT", "GP.OUTPUT", "ZP.OPEN", "ZP.CLOSE" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_S2_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "ZP.CSET", "ZP.CSETP", "DP.DDWR", "DP.DDWRP", "DP.DDRD",  "ZP.BUFRCV" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        public static bool IsN1_S3_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.CCPASET", "ZP.BUFSND" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_S1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "Z.RTWRITE", "ZP.RTWRITE", "ZRWRB", "ZRWRBP", "S.RTWRITE" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "ZP.PSTRT1", "ZP.PSTRT2", "ZP.PSTRT3", "ZP.PSTRT4", "Z.PFWRT", "ZP.PFWRT", "G.PRR"
                , "ZP.ERRCLR","ZP.UINI", "DP.CHGV", "DP.CHGVS", "D.CHGV", "D.CHGVS"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_S1_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "D.ROT", "G.BIDIN", "G.INPUT", "GP.INPUT" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN2_S1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.BBLKWR", "TO", "TOP", "DTO", "DTOP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN3_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.CPRTCL" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "EROMWR", "EROMWRP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }



        #endregion

        #region Import Special


        public static bool IsArithmetic(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "+","+P","-","-P","D+","D+P","D-","D-P","B+","B+P","B-","B-P","DB+","DB+P","DB-","DB-P"
                ,"E+","E+P","E-","E-P","$+","$+P","WAND","WANDP","DAND","DANDP","WOR","WORP","DOR","DORP","WXOR","WXORP","DXOR","DXORP"
                ,"WXNR","WXNRP","DXNR","DXNRP","FCALL","FCALP","ECALL","ECALLP","EFCALL","EFCALLP","D.CHGA","D.CHGT","D.CHGT2"
                ,"D.CHGV","D.DDRD","D.DDWR","D.GINT","D.SFCS","D.SVST", "DP.SVST", "DP.SVSTP", "DP.SFCS", "DP.SFCSP","DP.CHGA","DP.CHGA" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsFile(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SP.FWRITE", "SP.FREAD" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsProgram(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "CJ", "SCJ", "JMP", "BREAK", "BREAKP", "IXSET", "CALL", "CALLP" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsProgramNumber(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string>();
            if (sCommand.StartsWith("P"))
            {
                if (CStringHelper.IsDigitString(sCommand.Substring(1, sCommand.Length - 1)))
                {
                    return true;
                }
            }

            return false;
        }


        public static bool IsNetwork(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "J.ZCOM","JP.ZCOM","G.ZCOM","GP.ZCOM","J.ZNRD","JP.ZNRD","J.ZBWR","JP.ZBWR","J.ZNWR","JP.ZNWR" 
                ,"G.RTOP","GP.RTOP","G.RFRP","GP.RFRP","J.SEND","JP.SEND","J.RECV","JP.RECV","JP.ZNFR","G.SEND","GP.SEND","G.RECV","GP.RECV","GP.ZNFR"
                ,"J.ZNTO","JP.ZNTO","G.ZNTO","GP.ZNTO","ZP.ZNTO","JP.ZNFR","G.SEND","GP.SEND","G.RECV","GP.RECV","GP.ZNFR","J.READ","JP.READ","J.WRITE"
                ,"JP.WRITE","J.REQ","JP.REQ","ZP.ZNTO","J.READ","JP.READ","J.WRITE","JP.WRITE","J.REQ","JP.REQ","GP.READ","G.READ","G.WRITE","GP.WRITE"
                ,"G.REQ","GP.REQ","J.SREAD","JP.SREAD","J.SWRITE","JP.SWRITE","G.SREAD","GP.SREAD","G.SWRITE","GP.SWRITE","G.RIRD","GP.RIRD","G.RIWT","GP.RIWT"
                ,"G.RIRCV","GP.RIRCV","G.RISEND","GP.RISEND","G.RIFR","GP.RIFR","G.RITO","GP.RITO","G.RLPASET","GP.RLPASET" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }


        #endregion

    }
}
