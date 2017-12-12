using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using UDM.General;
using UDM.Common;
using UDM.UDL;


namespace UDM.UDLImport
{
    public class CMelsecILImportType
    {
        // S: Source, D: Destination, N : Numeric
        // Melsec Q CPU 기준 645개 33 타입

        public static List<string> GetmCommandAll()
        {
            List<string> lstCommandAll = new List<string>();
            List<string> lstCommand = new List<string>();

            IsS0_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS0_D1_N2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_D2_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS0_N2_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS0_N4_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS1_D0_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_N1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS1_D1_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D1_S1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D2_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_D2_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N1_D1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS1_N1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N1_S1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS1_N2_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D0_N0(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS2_D2_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsS2_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsS3_D1_N0(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S1(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S1_D2(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S2_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S2_D2(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN1_S3_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_D1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_D1_N1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsN2_S1_N1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsN3_S1_D1(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsArithmetic(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsFile(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            //IsNetwork(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);
            IsProgram(string.Empty, out lstCommand); lstCommandAll.AddRange(lstCommand);
            IsProgramNumber(string.Empty, out  lstCommand); lstCommandAll.AddRange(lstCommand);

            return lstCommandAll;
        }

        public static EMCoilImport GetmType(string strCommand)
        {
            List<string> lstTemp = new List<string>();
            if (strCommand == string.Empty) return EMCoilImport.EMPTY;
            else if (IsS0_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N0;
            else if (IsS0_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D0_N1;
            else if (IsS0_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N0;
            else if (IsS0_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N1;
            //else if (IsS0_D1_N2(strCommand, out lstTemp)) return EMCoilImport.S0_D1_N2;
            else if (IsS0_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N0;
            else if (IsS0_D2_N1(strCommand, out lstTemp)) return EMCoilImport.S0_D2_N1;
            else if (IsS0_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N1_D1;
            else if (IsS0_N2_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N2_D1;
            //else if (IsS0_N4_D1(strCommand, out lstTemp)) return EMCoilImport.S0_N4_D1;
            else if (IsS1_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N0;
            //else if (IsS1_D0_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D0_N1;
            else if (IsS1_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N0;
            else if (IsS1_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N1;
            //else if (IsS1_D1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_N1_D1;
            else if (IsS1_D1_S1(strCommand, out lstTemp)) return EMCoilImport.S1_D1_S1;
            else if (IsS1_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S1_D2_N0;
            else if (IsS1_D2_N1(strCommand, out lstTemp)) return EMCoilImport.S1_D2_N1;
            else if (IsS1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.S1_N1_D1;
            //else if (IsS1_N1_D2(strCommand, out lstTemp)) return EMCoilImport.S1_N1_D2;
            else if (IsS1_N1_S1_D2(strCommand, out lstTemp)) return EMCoilImport.S1_N1_S1_D2;
            else if (IsS1_N2_D1(strCommand, out lstTemp)) return EMCoilImport.S1_N2_D1;
            else if (IsS2_D0_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D0_N0;
            else if (IsS2_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N0;
            //else if (IsS2_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D2_N0;
            else if (IsS2_D1_N1(strCommand, out lstTemp)) return EMCoilImport.S2_D1_N1;
            else if (IsS3_D1_N0(strCommand, out lstTemp)) return EMCoilImport.S3_D1_N0;
            //else if (IsN1_D1_N1(strCommand, out lstTemp)) return EMCoilImport.N1_D1_N1;
            //else if (IsN1_S1(strCommand, out lstTemp)) return EMCoilImport.N1_S1;
            //else if (IsN1_S1_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S1_D1;
            //else if (IsN1_S1_D2(strCommand, out lstTemp)) return EMCoilImport.N1_S1_D2;
            //else if (IsN1_S2_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S2_D1;
            else if (IsN1_S2_D2(strCommand, out lstTemp)) return EMCoilImport.N1_S2_D2;
            //else if (IsN1_S3_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S3_D1;
            else if (IsN2_D1_N1(strCommand, out lstTemp)) return EMCoilImport.N2_D1_N1;
            else if (IsN2_D1_N1_D1(strCommand, out lstTemp)) return EMCoilImport.N2_D1_N1_D1;
            else if (IsN2_S1_N1(strCommand, out lstTemp)) return EMCoilImport.N2_S1_N1;
            //else if (IsN3_S1_D1(strCommand, out lstTemp)) return EMCoilImport.N3_S1_D1;
            else if (IsArithmetic(strCommand, out lstTemp)) return EMCoilImport.Arithmetic;
            else if (IsS1_N2_S1_D1(strCommand, out lstTemp)) return EMCoilImport.S1_N2_S1_D1;
            else if (IsS2_D2_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D2_N0;
            //else if (IsFile(strCommand, out lstTemp)) return EMCoilImport.File;
            //else if (IsNetwork(strCommand, out lstTemp)) return EMCoilImport.Network;
            else if (IsProgram(strCommand, out lstTemp)) return EMCoilImport.Program;
            else if (IsProgramNumber(strCommand, out lstTemp)) return EMCoilImport.ProgramLabel;
            else if (IsS2_D3_N0(strCommand, out lstTemp)) return EMCoilImport.S2_D3_N0;
            else if (IsN1_S5_D1(strCommand, out lstTemp)) return EMCoilImport.N1_S5_D1;

            return EMCoilImport.NONE;
        }

        #region S# D# N#

        public static bool IsS0_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "ANB", "ORB", "MPS", "MRD", "MPP", "INV", "MEP", "MEF", "EGP"
                , "EGF", "FEND", "END", "STOP", "NOP", "NOPLE", "GOEND", "RET", "NEXT", "IXEND", "IXDEV" 
                , "LEDR", "CHKST", "CHK", "CHKCIR", "CHKEND", "SLT", "SLTR", "STRA", "STRAR", "PTRA", "PTRAR"
                , "PTRAEXE", "PTRAEXEP", "DI", "EI", "IRET", "COM", "NOPLF"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS0_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LD", "LDP", "LDF", "AND", "ANDP", "ANDF", "OR", "ORP", "ORF", "LDI", "ANI", "ORI", "ANDPI", "ORPI", "LDPI", "ANDFI"
                , "ORFI", "LDFI", "OUT", "OUTH", "SET", "RST", "PLS", "PLF", "PKEY", "INC", "INCP", "DINC", "DINCP", "DEC", "DECP", "DDEC", "DDECP"
                , "NEG", "NEGP", "DNEG", "DNEGP", "ENEG", "ENEGP", "SWAP", "SWAPP", "DATERD", "DATERDP", "FF", "SFT", "SFTP", "PIDINIT", "PIDCONT"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SFR", "SFRP", "SFL", "SFLP", "BSFR", "BSFRP", "BSFL", "BSFLP", "DSFR", "DSFRP", "DSFL", "DSFLP", "BSET", "BSETP"
                , "BRST", "BRSTP", "BKRST", "BKRSTP", "RFS", "TTMR", "ROR", "RORP", "RCR", "RCRP", "ROL", "ROLP", "RCL", "RCLP", "DROR", "DRORP", "DRCR"
                , "DRCRP", "DROL", "DROLP", "DRCL", "DRCLP", "MC" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;      
        }

        public static bool IsS0_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "XCH", "XCHP", "DXCH", "DXCHP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS0_D2_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BXCH", "BXCHP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS0_D0_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MCR", "FOR", "PAGE" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D0_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "MSG", "DATEWR", "DATEWRP", "IX", "LED", "LEDC", "RSET", "RSETP", "QDRSET"
                , "QDRSETP", "QCDSET", "QCDSETP", "IMASK" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SQR", "SQRP", "MOV", "MOVP", "DMOV", "DMOVP", "EMOV", "EMOVP", "$MOV", "$MOVP"
                , "CML", "CMLP", "DCML", "DCMLP", "SIN", "SINP", "COS", "COSP", "TAN", "TANP", "ASIN", "ASINP", "ACOS", "ACOSP", "ATAN"
                , "ATANP", "RAD", "RADP", "DEG", "DEGP", "LOG", "LOGP", "BSQR", "BSQRP", "BDSQR", "BDSQRP", "BSIN", "BSINP", "BCOS"
                , "BCOSP", "BTAN", "BTANP", "BASIN", "BASINP", "BACOS", "BACOSP", "BATAN", "BATANP","BCD", "BCDP", "DBCD", "DBCDP", "BIN"
                , "BINP", "DBIN", "DBINP", "SUM", "SUMP", "DSUM", "DSUMP", "SEG", "SEGP", "SECOND", "SECONDP", "HOUR", "HOURP", "FLT"
                , "FLTP", "DFLT", "DFLTP", "INT", "INTP", "DINT", "DINTP", "DBL", "DBLP", "WORD", "WORDP", "GRY", "GRYP", "DGRYP", "GBIN"
                , "GBINP", "DGBIN", "DGBINP", "FIFW", "FIFWP", "FIFR", "FIFRP", "FPOP", "FPOPP", "PR", "PRC", "BINDA", "BINDAP", "DBINDA"
                , "DBINDAP", "BINHA", "BINHAP", "DBINHA", "DBINHAP", "BCDDA", "BCDDAP", "DBCDDA", "DBCDDAP", "DABIN", "DABINP", "DDABIN"
                , "DDABINP", "HABIN", "HABINP", "DHABIN", "DHABINP", "DABCD", "DBACDP", "DDABCD", "DDABCDP", "COMRD", "COMRDP", "LEN", "LENP"
                , "PIDPRMW", "ADRSET"  };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;

        }

        public static bool IsS1_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BMOV", "BMOVP", "FMOV", "FMOVP", "BKBCD", "BKBCDP", "BKBIN", "BKBINP", "DECO", "DECOP", "ENCO", "ENCOP", "DIS", "DISP"
                , "UNI", "UNIP", "WTOB", "WTOBP", "BTOW", "BTOWP", "MAX", "MAXP", "MIN", "MINP", "DMAX", "DMAXP"
                , "DMIN", "DMINP", "WSUM", "WSUMP", "DWSUM", "DWSUMP", "UDCNT1", "UDCNT2", "STMR", "FINS", "FINSP", "FDEL", "FDELP"
                , "ACS", "ACSP", "HEX", "HEXP", "RIGHT", "RIGHTP", "LEFT", "LEFTP", "RBMOV", "RBMOVP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS1_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "VAL", "VALP", "DVAL", "DVALP"  };

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
            ListIL = new List<string> {"LD=", "AND=", "OR=", "LD<>", "AND<>", "OR<>", "LD>", "AND>"
                , "OR>", "LD<=", "AND<=", "OR<=", "LD<", "AND<", "OR<", "LD>=", "AND>=", "OR>=", "LDD=", "ANDD="
                , "ORD=", "LDD<>", "ANDD<>", "ORD<>", "LDD>", "ANDD>", "ORD>", "LDD<=", "ANDD<=", "ORD<=", "LDD<"
                , "ANDD<", "ORD<", "LDD>=", "ANDD>=", "ORD>=", "LDE=", "ANDE=", "ORE=", "LDE<>", "ANDE<>", "ORE<>"
                , "LDE>", "ANDE>", "ORE>", "LDE<=", "ANDE<=", "ORE<=", "LDE<", "ANDE<", "ORE<", "LDE>=", "ANDE>="
                , "ORE>=", "LD$=", "AND$=", "OR$=", "LD$<>", "AND$<>", "OR$<>", "LD$>", "AND$>", "OR$>", "LD$<="
                , "AND$<=", "OR$<=", "LD$<", "AND$<", "OR$<", "LD$>=", "AND$>=", "OR$>=" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "*", "*P", "/", "/P", "D*", "D*P", "D/", "D/P", "B*", "B*P"
                , "B/", "B/P", "DB*", "DB*P", "DB/", "DB/P", "E*", "E*P", "E/", "E/P", "DATE+", "DATE+P"
                , "DATE-", "DATE-P", "STR", "STRP", "DSTR", "DSTRP", "ESTR", "ESTRP", "EVAL", "EVALP"
                , "EMOD", "EMODP", "EREXP", "EREXPP", "ZP.ERRCLR", "ZP.PFWRT", "TEST", "DTEST", "EXP", "EXPP"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D2_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GP.INPUT", "JP.READ"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D3_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "JP.SWRITE" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "BKCMP=", "BKCMP<>", "BKCMP>", "BKCMP<=", "BKCMP<", "BKCMP>="
                , "BKCMP=P", "BKCMP<>P", "BKCMP>P", "BKCMP<=P", "BKCMP<P", "BKCMP>=P", "BK+", "BK+P", "BK-", "BK-P"
                , "BKAND", "BKANDP", "BKOR", "BKORP", "BKXOR", "BKXORP", "BKXNR", "BKXNRP", "SER", "SERP", "DSER", "DSERP"
                , "INSTR", "INSTRP"};

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS3_D1_N0(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "LIMIT", "LIMITP", "DLIMIT", "DLIMITP", "BAND", "BANDP", "DBAND", "DBANDP"
                , "ZONE", "ZONEP", "DZONE", "DZONEP", "ZP.CLOSE", "ZP.OPEN", "GP.OUTPUT" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        //public static bool IsS1_N2_S1_D1(string sCommand, out List<string> ListIL)
        //{
        //    ListIL = new List<string> { "GP.ECPRTCL",  };

        //    if (ListIL.Contains(sCommand))
        //        return true;
        //    else
        //        return false;
        //}


        #endregion

        #region S# N# D#

        public static bool IsS0_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsS0_N2_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "PLSY", "PWM", "DUTY"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }
        
        public static bool IsS1_N1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "SPD" };

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

        #region Exceptions

        public static bool IsN1_S2_D2(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "DP.DDRD", "DP.DDWR" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN2_D1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "FROM", "FROMP", "DFRO", "DFROP" };
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
            ListIL = new List<string> { "MDIR", "MDIRP", "MIDW", "MIDWP" };
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

        public static bool IsS1_N2_S1_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "GP.ECPRTCL" };
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN1_S5_D1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "G.RLPASET", "GP.RLPASET"};
            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsN2_S1_N1(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "TO", "TOP", "DTO", "DTOP" };
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
                ,"WXNR","WXNRP","DXNR","DXNRP" };

            if (ListIL.Contains(sCommand))
                return true;
            else
                return false;
        }

        public static bool IsProgram(string sCommand, out List<string> ListIL)
        {
            ListIL = new List<string> { "JMP", "CJ", "SCJ", "BREAK", "BREAKP", "CALL", "CALLP", "FCALL", "FCALLP", "ECALL", "ECALLP"
            , "IXSET"};

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

        #endregion
    }
}
