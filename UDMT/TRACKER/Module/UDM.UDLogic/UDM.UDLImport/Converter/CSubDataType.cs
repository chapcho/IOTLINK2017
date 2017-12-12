using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;
using System.Text.RegularExpressions;

namespace UDM.UDLImport
{
    public class CSubDataType
    {
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.Mitsubishi;
        private CContentS m_cContentS = null;
        private string m_sCommand = string.Empty;

        private CContent m_sSource = null;
        private CContent m_sSource_Sub1 = null;
        private CContent m_sSource_Sub2 = null;
        private CContent m_sDestination = null;
        private CContent m_sDestination_Sub1 = null;
        private CContent m_sDestination_Sub2 = null;
        private CContent m_sNumeric = null;
        private CContent m_sNumeric_Sub1 = null;
        private CContent m_sNumeric_Sub2 = null;

        private bool m_bCheckDoubleWord = false;

        #region Initialize/Dispose

        public CSubDataType(string sCommand, CContentS cContentS, EMPLCMaker emPLCMaker)
        {               
            m_sCommand = sCommand;
            m_cContentS = cContentS;
            m_emPLCMaker = emPLCMaker;

            CreateCommonCoilType();
        }

        #endregion

        #region Public Methods

        public CSubData GetSubData()
        {
            CSubData cSubData = null;

            try
            {
                switch (m_sCommand)
                {
                    #region Get_D1
                    ////case "PKEY" :
                    //case "CML":
                    //case "INC":
                    //case "4INC":
                    //case "8INC":
                    //case "DEC":
                    //case "4DEC":
                    //case "8DEC":
                    //case "SWAP":
                    //case "2SWAP" :
                    //case "ROR":
                    //case "RCR":
                    //case "ROL":
                    //case "RCL":
                    //case "NEG":
                    //case "RND":
                    //case "WAND":
                    //case "WOR":
                    //case "WXOR":
                    //case "WXNR":
                    //case "BSUM":
                    //case "SFR":
                    //case "SFL":
                    //case "BCD":
                    //case "BIN":
                    //case "GRY":
                    //case "SEG":
                    //case "GBIN":

                    ////case "DSUM":                                          // S ~ S+1                   
                    //case "INT":                                           // S ~ S+1                   
                    //case "WORD":                                          // S ~ S+1                   
                    //case "HABIN":                                         // S ~ S+1 (아스키 4자리)    
                    //case "DABCD":                                         // S ~ S+1 (아스키 4자리)    
                    //case "DABIN":                                         // S ~ S+2 (아스키 6자리)   
                    //case "LIM":                                         // S1 < S3(입력값) < S2            
                    ////case "BAND":                                          // S1 > S3(입력값) < S2            
                    //case "ZONE":                                          // S3 < 0 일떄 "S3 + S1(음수)" , S3 = 0 일떄 "0" , S3 > 0 일때 "S3 + S2(양수)"
                    //case "UNI":                                           // n에 따라 다름 (S, S ~ S+1 , S ~ S+2 , S ~ S+3)
                    //case "LEN":                                           // S ~ S+n (문자 끝나는 00H 까지)
                    //case "INSTR":                                         // S2 ~ S2+n(문자 끝나는 00H 까지) = "검색할 대상" , S1 ~ S1+n(문자 끝나는 00H 까지) = "검색할 단어"
                    //case "TEST":                                          // S1(1Word) 중 S2 번쨰 위치의 값
                    //case "DTEST":                                         // S1 ~ S1+1 중 S2 번쨰 위치의 값
                    //case "MOV": cILData = Get_D(cILLine); break;
                    //// S => D   

                    #endregion

                    #region Get_D2

                    //case "DCMOV" : //S1, D1
                    //case "DADD" : //S1,2 D1
                    //case "DSUB" : //S1,2 D1
                    //case "UDADD" : //S2, D1
                    //case "UDSUB" : //S2, D1
                    //case "UDIV" : //S2, D1
                    //case "RADD" : //S2, D1
                    //case "RSUB": //S2, D1
                    //case "RMUL": //S2, D1
                    //case "RDIV": //S2, D1            
                    //case "DINC": //D1
                    //case "DDEC": //D1
                    //case "DNOT": //S1, D1
                    case "DIV": //S2, D1
                    //case "MUL": //S2, D1
                    //case "DBADD": //S1,2, D1
                    //case "DBSUB": //S1,2, D1
                    //case "BMUL": //S1,2, D1
                    case "BDIV": //S1,2, D1
                    //case "EADD": //S1,2, D1
                    //case "ESUB": //S1,2, D1
                    //case "EMUL": //S2, D1
                    case "EDIV": //S2, D1
                    //case "DBCD": //S1, D1
                    //case "DBIN": //S1, D1
                    //case "DTOR": //S1, D1
                    //case "RTOD": //S1, D1
                    //case "WTODW": //S2, D1
                    //case "DTOG":  //S1, D1
                    //case "DMOV": //S1, D1
                    //case "DSWAP":  //D2
                    //case "DAND":  //S2, D1
                    //case "DOR":  //S2, D1
                    //case "DXOR":  //S2, D1
                    //case "DXNR":  //S2, D1
                    //case "DROR":  //S1, D1
                    //case "DRCR": //S1, D1
                    //case "DROL": //S1, D1
                    //case "DRCL": //S1, D1
                    case "SER": //S3, D1
                    case "DSER": //S3, D1
                    //case "SUM":  //S2, D1
                    //case "DDABIN": //S1, D1
                    //case "DHABIN": //S1, D1
                    //case "DDABCD": //S1, D1
                    //case "STRR": //S1, D1
                    //case "SIN": //S1, D1
                    //case "COS": //S1, D1
                    //case "TAN": //S1, D1
                    //case "ASIN": //S1, D1
                    //case "ACOS": //S1, D1
                    //case "ATAN": //S1, D1
                    //case "RAD": //S1, D1
                    //case "DEG": //S1, D1
                    //case "SQRT": //S1, D1
                    //case "EXP": //S1, D1
                    //case "LN":  //S1, D1
                    //case "BSQRT": //S1, D1
                    //case "BDSQRT": //S1, D1
                    //case "EMOV": //S1, D1
                    //case "DLIM": //S3, D1                                       // S1 ~ S1+1 < S3 ~ S3+1(입력값) < S2 ~ S2+1
                    //case "BCDR": //S2, D1
                    case "SECOND":
                    case "DBDIV": //S1,2, D1 //Double Word Check, Double Word Size 2개 수집
                    case "DDIV":

                        cSubData = Get_D2(); break;
                    // D ~ D+1                      

                    #endregion

                    #region Get_D3

                    case "BSIN": //S1, D1                                         // S
                    case "BCOS": //S1, D1                                         // S
                    case "BTAN": //S1, D1
                    case "BASIN": //S1, D1
                    case "BACOS": //S1, D1
                    case "BATAN": //S1, D1
                    case "BINHA":         //S1, D1                                 // S
                    case "BCDDA": //S1, D1                                         // S
                    case "MAX":   //S2, D1                                        // S ~ S+(n-1)
                    case "MIN":  //S2, D1
                    case "DATE+":
                    case "DATE-":
                    case "HOUR":
                        cSubData = Get_D3(); break;         // S ~ S+(n-1)
                    #endregion

                    #region Get_D4

                    //case "UDDIV": //S2, D1
                    //case "UDMUL":    //S2, D1                
                    //case "DMUL": //S2, D1
                    //case "LADD": //S2, D1
                    //case "LSUB": //S2, D1
                    //case "LMUL": //S2, D1
                    //case "LDIV": //S2, D1
                    //case "DBMUL": //S1,2, D1
                    //case "DSUM": //S2, D1
                    case "BINDA": //S1, D1
                    case "DMAX":  //S2, D1                //Exception! Double Word, Word, Word 총 3개 수집                                     
                    case "DMIN":  //S2, D1
                        cSubData = Get_D4(); break;        // S ~ S+(2n-1)            
                    // 4개가 합쳐져서 값이 나타나는 것 UDDIV, UDMUL, DMUL, LADD
                    #endregion

                    #region Get_D5

                    case "DBINHA": //S1, D1                                       // S ~ S+1                  
                    case "DBCDDA": //S1, D1                                       // S ~ S+1      
                    case "RBCD":  //S2, D1
                        cSubData = Get_D5(); break;        // S1 ~ S1+1 , S2
                    // D ~ D+4
                    #endregion

                    #region Get_D6

                    case "DBINDA": //S1, D1
                        cSubData = Get_D6(); break;      // S ~ S+1        
                    // D ~ D+5

                    #endregion

                    #region Get_Dn

                    case "BSWAP":  //N1, D2
                    case "GBMOV": //S1, N1, D1 
                    case "BAND": //S2, N1, D1 
                    case "BOR":  //S2, N1, D1 
                    case "BXOR": //S2, N1, D1 
                    case "BXNR": //S2, N1, D1 
                    case "BKEQU": //S2, N1, D1 
                    case "BKGEQ": //S2, N1, D1 
                    case "BKGRT": //S2, N1, D1 
                    case "BKLEQ": //S2, N1, D1 
                    case "BKLES": //S2, N1, D1 
                    case "BKNEQ": //S2, N1, D1 
                    case "BKADD": //S2, N1, D1 
                    case "BKSUB": //S2, N1, D1 
                    case "GMOV": //S1, N1, D1 
                    case "FMOV": //S1, N1, D1 
                    case "BKBCD": //S1, N1, D1 
                    case "BKBIN": //S1, N1, D1 
                    case "mBMOV": //S1, N1, D1 
                    case "BKOR": //S2, N1, D1 
                    case "BKXOR": //S2, N1, D1 
                    case "BKXNR": //S2, N1, D1 
                    case "BKAND": //S2, N1, D1 
                    case "WSFR": //S0, N1, D1 
                    case "WSFL": //S0, N1, D1 
                    case "DIS": //S1, N1, D1 
                    case "WTOB": //S1, N1, D1 
                    case "BSFR"://S0, N1, D1 
                    case "BSFL": //S0, N1, D1 
                        cSubData = Get_Dn(); break;
                    // D ~ D+(n-1)
                    #endregion

                    #region Get_Special

                    case "DATERD": cSubData = Get_DATERD(); break;

                    case "DECO": cSubData = Get_DECO(); break; //S1, N1, D1 

                    case "ENCO": cSubData = Get_ENCO(); break; //S1, N1, D1 

                    case "FROM":
                        //case "DFROM" :
                        cSubData = Get_FROM(); break;   //S0, N3, D1  //  타호기 공유메모리

                    case "TO":
                        //case "DTO" :
                        cSubData = Get_TO(); break;  //S0, N3, D1  //  타호기 공유메모리

                    #endregion

                    default: Console.WriteLine("Error : Do not Support Command SubDataMove {0} [SubDataMove Analysis]", m_sCommand); break;

                    //WSFT, WSFL, WSFR, SR, GSWAP
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cSubData;
        }
        
        #endregion
        
        #region Private Methods

        private void CreateCommonCoilType()
        {
            try
            {
                if (CheckS0_D1_N0()) SetS0_D1_N0();
                else if (CheckS0_D2_N0()) SetS0_D2_N0();
                else if (CheckS0_D1_N1()) SetS0_D1_N1();
                else if (CheckS0_N3_D1()) SetS0_N3_D1();
                else if (CheckS0_D2_N1()) SetS0_D2_N1();
                else if (CheckS1_D1_N0()) SetS1_D1_N0();
                else if (CheckS1_D1_N1()) SetS1_D1_N1();
                else if (CheckS2_D1_N0()) SetS2_D1_N0();
                else if (CheckS2_D1_N1()) SetS2_D1_N1();
                else if (CheckS3_D1_N0()) SetS3_D1_N0();
                else
                    Console.WriteLine("Do Not Support [{0}] Command!", m_sCommand);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private EMSubDataType GetSubDataType(CTag cTag)
        {
            EMSubDataType emSubDataType = EMSubDataType.Unknown;

            string sAddress = cTag.Address;

            if (sAddress.Contains("."))
                emSubDataType = EMSubDataType.WordDotBit;
            else if (cTag.DataType == EMDataType.Bool)
                emSubDataType = EMSubDataType.Bit;
            else if (cTag.DataType == EMDataType.Word)
                emSubDataType = EMSubDataType.Word;
            else if (cTag.DataType == EMDataType.DWord)
            {
                emSubDataType = EMSubDataType.DWord;
                m_bCheckDoubleWord = true;
            }

                return emSubDataType;
        }

        private int GetSize(string sNumeric)
        {
            int nNumber = 0;

            if (sNumeric.StartsWith("Z"))
                return -1;

            if (sNumeric.Contains('Z'))
                sNumeric = sNumeric.Split('Z')[0];

            if (sNumeric.StartsWith("K"))
                nNumber = Convert.ToInt32(sNumeric.Substring(1, sNumeric.Length - 1), 10);
            else if (sNumeric.StartsWith("H"))
                nNumber = Convert.ToInt32(sNumeric.Substring(1, sNumeric.Length - 1), 16);
            else if(!Regex.IsMatch(sNumeric, @"[A-Z]"))
                nNumber = Convert.ToInt32(sNumeric, 10);

            return nNumber;
        }
        
        #region GetSubData

        private CSubData Get_DATERD()
        {
            CSubData cSubData = null;

            return cSubData;
        }

        private CSubData Get_D2()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = 2;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_D3()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = 3;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_D4()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = 4;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_D5()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = 5;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_D6()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = 6;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_Dn()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = GetSize(m_sNumeric.Argument);

            if (iSize == -1)
                return null;

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_DECO() //확실치 않음
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);

            int iSize = (int)Math.Pow(2, GetSize(m_sNumeric.Argument));

            if(emSubDataType == EMSubDataType.Word || emSubDataType == EMSubDataType.Bit && m_sDestination.Tag.Address.StartsWith("K"))
            {
                if (iSize % 16 == 0)
                    iSize--;

                iSize = iSize / 16 + 1;
            }

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_ENCO()
        {
            return Get_DECO();
        }

        private CSubData Get_FROM()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = GetSize(m_sNumeric_Sub2.Argument);

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        private CSubData Get_TO()
        {
            if (m_sDestination.Tag == null || m_sDestination.Tag.Address.StartsWith("@") || m_sDestination.Tag.Address.StartsWith("#"))
                return null;

            EMSubDataType emSubDataType = GetSubDataType(m_sDestination.Tag);
            int iSize = GetSize(m_sNumeric_Sub2.Argument);

            CSubData cSubData = new CSubData(m_sDestination.Tag.Address, iSize, emSubDataType, m_bCheckDoubleWord, m_emPLCMaker);

            return cSubData;
        }

        #endregion

        #region CheckCommonCoilType

        private bool CheckS0_D2_N0()
        {
            List<string> ListIL = new List<string> { "DSWAP" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS2_D1_N0()
        {
            List<string> ListIL = new List<string> { "DADD", "DSUB", "UDADD" ,"UDIV" ,"UDSUB" ,"RADD" ,"RSUB" ,"RMUL" ,"RDIV" ,"DIV" ,"MUL" ,"DBADD" ,"DBSUB" 
                ,"BMUL" ,"BDIV" ,"EADD" ,"ESUB" ,"EMUL" ,"EDIV" ,"WTODW" ,"DAND" ,"DOR" ,"DXOR" ,"DXNR", "SUM", "BCDR" ,"MAX" ,"MIN", "UDDIV" ,"UDMUL" ,"DMUL" 
                ,"DDIV" ,"LADD" ,"LSUB" ,"LMUL" ,"LDIV" ,"DBMUL" ,"DBDIV" ,"DSUM" ,"DMAX" ,"DMIN" ,"RBCD", "DATE+", "DATE-"};
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS1_D1_N0()
        {
            List<string> ListIL = new List<string> { "DCMOV" ,"DNOT" ,"DBCD" ,"DBIN" ,"DTOR" ,"RTOD" ,"DTOG" ,"DMOV" ,"DROR" ,"DRCR" ,"DROL" ,"DRCL" ,"DDABIN" ,"DHABIN" ,"DDABCD" 
                ,"STRR" ,"SIN" ,"COS" ,"TAN" ,"ASIN" ,"ACOS" ,"ATAN" ,"RAD" ,"DEG" ,"SQRT" ,"EXP" ,"LN" ,"BSQRT" ,"BDSQRT" ,"EMOV" ,"BSIN" ,"BCOS" ,"BTAN" ,"BASIN" ,"BACOS" ,"BATAN" 
                ,"BINHA" ,"BCDDA", "BINDA", "DBINHA" ,"DBCDDA" ,"DBINDA", "SECOND", "HOUR"};
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS0_D1_N0()
        {
            List<string> ListIL = new List<string> { "DINC" ,"DDEC" ,"DATERD" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS0_D1_N1()
        {
            List<string> ListIL = new List<string> { "WSFR", "WSFL", "BSFR", "BSFL" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS1_D1_N1()
        {
            List<string> ListIL = new List<string> { "GBMOV", "GMOV" ,"FMOV" ,"BKBCD" ,"BKBIN" ,"mBMOV", "DIS", "WTOB", "DECO", "ENCO" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS2_D1_N1()
        {
            List<string> ListIL = new List<string> { "BAND" ,"BOR" ,"BXOR" ,"BXNR" ,"BKEQU" ,"BKGEQ" ,"BKGRT" ,"BKLEQ" ,"BKLES" ,"BKNEQ" ,"BKADD" ,"BKSUB" 
                ,"BKOR" ,"BKXOR" ,"BKAND" ,"BKXNR" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS0_N3_D1()
        {
            List<string> ListIL = new List<string> { "FROM", "TO", "DFROM", "DTO" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS0_D2_N1()
        {
             List<string> ListIL = new List<string> { "BSWAP" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private bool CheckS3_D1_N0()
        {
            List<string> ListIL = new List<string> { "SER", "DSER", "DLIM" };
            if (ListIL.Contains(m_sCommand))
                return true;
            else
                return false;
        }

        private void SetS0_D2_N0()
        {
            if (m_cContentS.Count != 2)
                return;

            m_sDestination = m_cContentS[0];
            m_sDestination_Sub1 = m_cContentS[1];
            
        }

        private void SetS2_D1_N0()
        {
            if (m_cContentS.Count != 3)
            {
                if (m_cContentS.Count == 2)
                {
                    SetS1_D1_N0();
                    return;
                }
                else
                    return;
            }

            m_sSource = m_cContentS[0];
            m_sSource_Sub1 = m_cContentS[1];
            m_sDestination = m_cContentS[2];
        }

        private void SetS1_D1_N0()
        {
            if (m_cContentS.Count != 2)
                return;

            m_sSource = m_cContentS[0];
            m_sDestination = m_cContentS[1];
        }

        private void SetS0_D1_N0()
        {
            if (m_cContentS.Count != 1)
                return;

            m_sDestination = m_cContentS[0];
        }

        private void SetS0_D1_N1()
        {
            if (m_cContentS.Count != 2)
                return;

            m_sDestination = m_cContentS[0];
            m_sNumeric = m_cContentS[1];
        }

        private void SetS1_D1_N1()
        {
            if (m_cContentS.Count != 3)
                return;

            m_sSource = m_cContentS[0];
            m_sDestination = m_cContentS[1];
            m_sNumeric = m_cContentS[2];
        }

        private void SetS2_D1_N1()
        {
            if (m_cContentS.Count != 4)
                return;

            m_sSource = m_cContentS[0];
            m_sSource_Sub1 = m_cContentS[1];
            m_sDestination = m_cContentS[2];
            m_sNumeric = m_cContentS[3];
        }

        private void SetS0_N3_D1()
        {
            if (m_cContentS.Count != 4)
                return;

            m_sNumeric = m_cContentS[0];
            m_sNumeric_Sub1 = m_cContentS[1];
            m_sNumeric_Sub2 = m_cContentS[2];
            m_sDestination = m_cContentS[3];                
        }

        private void SetS0_D2_N1()
        {
            if (m_cContentS.Count != 3)
                return;

            m_sDestination = m_cContentS[0];
            m_sDestination_Sub1 = m_cContentS[1];
            m_sNumeric = m_cContentS[2];
        }

        private void SetS3_D1_N0()
        {
            if (m_cContentS.Count != 4)
                return;

            m_sSource = m_cContentS[0];
            m_sSource_Sub1 = m_cContentS[1];
            m_sSource_Sub2 = m_cContentS[2];
            m_sDestination = m_cContentS[3];
        }

        #endregion


        #endregion




    }
}
