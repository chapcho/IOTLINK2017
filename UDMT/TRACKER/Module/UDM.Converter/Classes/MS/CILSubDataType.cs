using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILSubDataType
    {
        public static CILSubData GetILSubData(CILLine cILLine)
        {
            try
            {
                CILSubData cILData = null;
                string sCommand = cILLine.Command.TrimEnd('P');

                if (cILLine.Destination == string.Empty)
                {
                   // Console.WriteLine("GetILSubData [Destination is Empty] : " + cILLine.ItemAll);
                    return null;
                }

                switch (sCommand)
                {
                    case "CML":
                    case "INC":
                    case "DEC":
                    case "SWAP":
                    case "ROR":
                    case "RCR":
                    case "ROL":
                    case "RCL":
                    case "NEG":
                    case "RND":
                    case "WAND":
                    case "WOR":
                    case "WXOR":
                    case "WXNR":
                    case "SUM":
                    case "SFR":
                    case "SFL":
                    case "BCD":
                    case "BIN":
                    case "GRY":
                    case "SEG":
                    case "GBIN":

                    case "DSUM":                                          // S ~ S+1                   
                    case "INT":                                           // S ~ S+1                   
                    case "WORD":                                          // S ~ S+1                   
                    case "HABIN":                                         // S ~ S+1 (아스키 4자리)    
                    case "DABCD":                                         // S ~ S+1 (아스키 4자리)    

                    case "BASIN":                                         // S ~ S+2                   
                    case "BACOS":                                         // S ~ S+2                   
                    case "BATAN":                                         // S ~ S+2                   
                    case "DABIN":                                         // S ~ S+2 (아스키 6자리)    

                    case "LIMIT":                                         // S1 < S3(입력값) < S2            
                    case "BAND":                                          // S1 > S3(입력값) < S2            
                    case "ZONE":                                          // S3 < 0 일떄 "S3 + S1(음수)" , S3 = 0 일떄 "0" , S3 > 0 일때 "S3 + S2(양수)"

                    case "UNI":                                           // n에 따라 다름 (S, S ~ S+1 , S ~ S+2 , S ~ S+3)

                    case "LEN":                                           // S ~ S+n (문자 끝나는 00H 까지)
                    case "INSTR":                                         // S2 ~ S2+n(문자 끝나는 00H 까지) = "검색할 대상" , S1 ~ S1+n(문자 끝나는 00H 까지) = "검색할 단어"

                    case "TEST":                                          // S1(1Word) 중 S2 번쨰 위치의 값
                    case "DTEST":                                         // S1 ~ S1+1 중 S2 번쨰 위치의 값

                    case "MOV": cILData = Get_D(cILLine); break;
                    // S => D   

                    case "DINC":
                    case "DDEC":
                    case "DCML":
                    case "EMOV":
                    case "DROR":
                    case "DRCR":
                    case "DROL":
                    case "DRCL":
                    case "DNEG":
                    case "ENEG":
                    case "DAND":
                    case "DOR":
                    case "DXOR":
                    case "DXNR":
                    case "SIN":
                    case "COS":
                    case "TAN":
                    case "ASIN":
                    case "ACOS":
                    case "ATAN":
                    case "RAD":
                    case "DEG":
                    case "SQR":
                    case "EXP":
                    case "LOG":
                    case "BDSQR":
                    case "DBCD":
                    case "DBIN":
                    case "DFLT":
                    case "DINT":
                    case "DGRY":
                    case "DGBIN":

                    case "BSQR":                                          // S                        
                    case "FLT":                                           // S                        
                    case "DBL":                                           // S                        

                    case "DHABIN":                                        // S ~ S+3 (아스키 8자리)   
                    case "DDABCD":                                        // S ~ S+3 (아스키 8자리)   

                    case "DDABIN":                                        // S ~ S+5 (아스키 11자리)  

                    case "WSUM":                                          // S ~ S+(n-1)

                    case "DLIMIT":                                        // S1 ~ S1+1 < S3 ~ S3+1(입력값) < S2 ~ S2+1
                    case "DBAND":                                         // S1 ~ S1+1 > S3 ~ S3+1(입력값) < S2 ~ S2+1
                    case "DZONE":                                         // S3 ~ S3+1 < 0 일떄 "S3 ~ S3+1" + "S1 ~ S1+1 (음수)" , S3 ~ S3+1 = 0 일떄 "0" , S3 ~ S3+1 > 0 일때 "S3 ~ S3+1" + "S2 + S2+1(양수)"

                    case "EREXP":                                         // S1 ~ S1+4 , S2

                    case "EVAL":                                          // S ~ S+n(문자 끝나는 00H 까지)

                    case "SER":                                           // S2 ~ S2+(n-1) 중 S1 갯수 
                    case "DSER":                                          // S2 ~ S2+(n-1) 중 S1 갯수 
                    case "/":

                    case "DMOV": cILData = Get_D2(cILLine); break;
                    // D ~ D+1

                    case "BSIN":                                          // S
                    case "BCOS":                                          // S
                    case "BTAN":                                          // S
                    case "BINHA":                                         // S
                    case "BCDDA":                                         // S

                    case "MAX":                                           // S ~ S+(n-1)
                    case "MIN": cILData = Get_D3(cILLine); break;         // S ~ S+(n-1)
                    // D ~ D+2

                    case "BINDA":                                         // S
                    case "D/":

                    case "DWSUM":                                         // S ~ S+(2n-1)             
                    case "DMAX":                                          // S ~ S+(2n-1)             
                    case "DMIN": cILData = Get_D4(cILLine); break;        // S ~ S+(2n-1)            
                    // D ~ D+3

                    case "DBINHA":                                        // S ~ S+1                  
                    case "DBCDDA":                                        // S ~ S+1      

                    case "EMOD": cILData = Get_D5(cILLine); break;        // S1 ~ S1+1 , S2
                    // D ~ D+4

                    case "DBINDA": cILData = Get_D6(cILLine); break;      // S ~ S+1        
                    // D ~ D+5

                    case "FMOV":
                    case "BKOR":
                    case "BKXOR":
                    case "BKXNR":
                    case "BKBCD":
                    case "BKBIN":
                    case "WTOB":
                    case "BKRST":
                    case "BSFR":
                    case "BSFL":
                    case "DSFR":
                    case "DSFL":
                    case "DIS":
              
                    case "BKAND":                                           // S1 ~ S1+(n-1)과 S2 ~ S2+(n-1) 비교. 또는 S1 ~ S1+(n-1)과 S2 비교. 

                    case "BMOV": cILData = Get_Dn(cILLine); break;
                    // D ~ D+(n-1)

                    case "DECO": cILData = Get_DECO(cILLine); break;

                    case "ENCO": cILData = Get_ENCO(cILLine); break;

                    case "FROM": cILData = Get_FROM(cILLine); break;   //  타호기 공유메모리

                    case "TO": cILData = Get_TO(cILLine); break;   //  타호기 공유메모리
                        

//                    case "BSET":  //ahn
//                     case "BRST": cILData = Get_DBit(cILLine); break;        // 미구현  
//                     // 1워드 중 n번째 1비트만 변함.
// 
//                     case "SRND": cILData = Get_S_Word(cILLine); break;      // 미구현
//                     // Source 1Word에 난수발생
// 
//                     case "SFT": cILData = Get_SFT(cILLine); break;          // 미구현
//                     // D-1 ~ D (2BIT)
// 
//                     case "XCH": cILData = Get_XCH(cILLine); break;          // 미구현
//                     // D1 <=> D2 교환 1 Word 
// 
//                     case "DXCH": cILData = Get_DXCH(cILLine); break;        // 미구현
//                     // Word D1 D2 교환 2 Word 
// 
//                     case "BXCH": cILData = Get_BXCH(cILLine); break;        // 미구현
//                     // Word D1 D2 교환 n Word
// 
//                     case "VAL": cILData = Get_D2_DSub(cILLine); break;      // 미구현  
//                     // D1 , D1+1 , D2 
// 
//                     case "DVAL": cILData = Get_D2_D2Sub(cILLine); break;    // 미구현  
//                     // D1 , D1+1 , D2 , D2+1
// 
//                     case "$MOV": cILData = Get_MOV_00H(cILLine); break;    // 미구현  
//                     // D ~ 00H 있는 부분까지 이동...
// 
//                     case "COMRD": cILData = Get_COMRD(cILLine); break;     　// 미구현  
//                     // D , D ~ D+1 , D ~ D+2 , ..... , D ~ D+15                 S에 따라 다름 (32문자까지)
// 
//                     case "BTOW": cILData = Get_BTOW(cILLine); break;     　　// 미구현  
//                     // n=홀수 D ~ D+{(n-1)/2} , n=짝수 D ~ D+{n/2)-1}           ||  Ex) n=5 D ~ D+2 , n=6 D ~ D+2

                    //  case "FIFW":
                    //  case "FIFR":
                    //  case "FPOP":
                    //  case "FDEL":
                    //  case "FINS":

                    //  case "MIDR":
                    //  case "MIDW":

                    //  case "STR": 
                    //  case "DSTR":
                    //  case "ESTR":       

                    //  case "ASC": 
                    //  case "HEX": 

                    //  case "RIGHT":
                    //  case "LEFT":

                    //  case "NDIS":
                    //  case "NUNI":

                    //  case "ZPUSH": 
                    //  case "ZPOP": 


                    #region Temp

                    //  case "SORT":
                    //  case "DSORT":

                    //  case "DFRO": 　　　 　　타호기 공유메모리

                    //  case "EROMWR":          Developer 8.82L 없는 명령어. 사용되는 Ver 모름.

                    #endregion

                    default: break;
                }

                return cILData;
            }
            catch (Exception error)
            {
                Console.WriteLine("GetILSubData [Exception] : " + cILLine.ItemAll); error.Data.Clear();
                return null;
            }
        }

        private static CILSubData Get_D(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_D2(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 2;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_D3(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 3;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_D4(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 4;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_D5(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 5;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_D6(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 6;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_Dn(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = GetNumber(cILLine.Numeric);

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_FROM(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = GetNumber(cILLine.Numeric_Sub2);

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_TO(CILLine cILLine)
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Source);
            int nSize = GetNumber(cILLine.Numeric_Sub2);

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, true);

            return cILData;
        }

        private static CILSubData Get_DBit(CILLine cILLine)  // 개발안됨.
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = GetNumber(cILLine.Numeric);

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }
                
        private static CILSubData Get_S_Word(CILLine cILLine) // 개발안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Source);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Source, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_SFT(CILLine cILLine) // 개발안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = -2;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_XCH(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }

        private static CILSubData Get_DXCH(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);

            return cILData;
        }
        
        private static CILSubData Get_BXCH(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);
            
            return cILData;
        }

        private static CILSubData Get_DECO(CILLine cILLine)
        {
            EMSubDataType eSubDataTypeDst = GetHeadDataType(cILLine.Destination);
            EMSubDataType eSubDataTypeSrc = GetHeadDataType(cILLine.Source);
            int nSizeDst = (int)Math.Pow(2, GetNumber(cILLine.Numeric));
            int nSizeSrc = (int)Math.Pow(2, GetNumber(cILLine.Numeric));

            if (eSubDataTypeDst == EMSubDataType.Word
             || eSubDataTypeDst == EMSubDataType.Bit && cILLine.Destination.StartsWith("K"))
            {
                if (nSizeDst % 16 == 0)
                    nSizeDst--;

                nSizeDst = nSizeDst / 16 + 1;
            }

            if (eSubDataTypeSrc == EMSubDataType.Word
            || eSubDataTypeSrc == EMSubDataType.Bit && cILLine.Source.StartsWith("K"))
            {
                if (nSizeSrc % 16 == 0)
                    nSizeSrc--;

                nSizeSrc = nSizeSrc / 16 + 1;
            }

            CILSubData cILDataDst = new CILSubData(cILLine.Destination, nSizeDst, eSubDataTypeDst, false);
            CILSubData cILDataSrc = new CILSubData(cILLine.Source, nSizeSrc, eSubDataTypeSrc, true);
            cILDataDst.SubDataListSrc = cILDataSrc.SubDataListSrc;

            return cILDataDst;
        }

        private static CILSubData Get_ENCO(CILLine cILLine)
        {
            return Get_DECO(cILLine);
        }

        private static CILSubData Get_D2_DSub(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false); // 삭제

            //     CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, cILLine.Destination_Sub1);
            //     cILData.SubDataList.Add(cILLine.Destination_Sub1);

            return cILData;
        }
        
        private static CILSubData Get_D2_D2Sub(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);
            
            return cILData;
        }
        
        private static CILSubData Get_MOV_00H(CILLine cILLine)  //개발 안됨
        {
             EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);
            
            return cILData;
        }

        private static CILSubData Get_COMRD(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);
            
            return cILData;
        }

        private static CILSubData Get_BTOW(CILLine cILLine)  //개발 안됨
        {
            EMSubDataType eSubDataType = GetHeadDataType(cILLine.Destination);
            int nSize = 1;

            CILSubData cILData = new CILSubData(cILLine.Destination, nSize, eSubDataType, false);
            
            return cILData;
        }



        public static string GetNextArrayAddress(string sAddress, int nBitSize, int nNext)    // K4M1000
        {
            string sAddressTemp = sAddress.Substring(2, sAddress.Length - 2);
            string sNextAddress = string.Empty;
            string sAddressType = GetAddressType(sAddressTemp);
            string sAddressIndex = sAddressTemp.Substring(sAddressType.Length, sAddressTemp.Length - sAddressType.Length);


            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            if (CPlcMelsec.IsHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nBitSize + (16 * nNext));
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nBitSize + (16 * nNext));
            }

            return sNextAddress;
        }

        public static string GetNextWordDotBitAddress(string sAddress, int nBitSize)    // D1000.F
        {
            string sNextAddress = string.Empty;
            string sAddressType = GetAddressType(sAddress);
            string sAddressIndex = sAddress.Substring(sAddressType.Length, sAddress.Length - sAddressType.Length);

            if (sAddressIndex.Contains('.'))
            {
                nBitSize += Convert.ToInt32(sAddressIndex.Split('.')[1], 16);
                sAddressIndex = sAddressIndex.Split('.')[0];
            }

            int nAddressWord = nBitSize / 16;
            int nAddressBit = nBitSize % 16;

            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            if (CPlcMelsec.IsHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}.{2:X}", sAddressType, nAddress + nAddressWord, nAddressBit);
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}.{2:X}", sAddressType, nAddress + nAddressWord, nAddressBit);
            }

            return sNextAddress;
        }

        public static string GetNextAddress(string sAddress, int nNext)    // D1000 , B1000 normal Address
        {
            string sNextAddress = string.Empty;
            string sAddressType = GetAddressType(sAddress);
            string sAddressIndex = sAddress.Substring(sAddressType.Length, sAddress.Length - sAddressType.Length);

            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            if (CPlcMelsec.IsHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nNext);
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nNext);
            }

            return sNextAddress;
        }

        public static string GetAddressType(string sAddress)
        {
            string sAddressType = string.Empty;

            if (CPlcMelsec.IsHeadOne(sAddress))
                sAddressType = sAddress.Substring(0, 1);
            else if (CPlcMelsec.IsHeadTwo(sAddress))
                sAddressType = sAddress.Substring(0, 2);

            return sAddressType;
        }

        public static EMSubDataType GetHeadDataType(string sAddress)
        {
            string sAddressTemp = sAddress;

            if ("SD520" == sAddress)
            {
            }

            if (sAddress.StartsWith("K"))
            {
                sAddressTemp = sAddress.Substring(2, sAddress.Length - 2);

                if (sAddressTemp == string.Empty)
                    return EMSubDataType.Unknown;
            }

            if (CPlcMelsec.IsBit(sAddress))
                return EMSubDataType.Bit;
            else if (sAddress.Contains("."))
                return EMSubDataType.WordDotBit;
            else
                return EMSubDataType.Word;
        }

        public static int GetNumber(string sNumeric)
        {
            int nNumber = 0;

            if (sNumeric.Contains('Z'))
                sNumeric = sNumeric.Split('Z')[0];

            if (sNumeric.StartsWith("K"))
                nNumber = Convert.ToInt32(sNumeric.Substring(1, sNumeric.Length - 1), 10);
            if (sNumeric.StartsWith("H"))
                nNumber = Convert.ToInt32(sNumeric.Substring(1, sNumeric.Length - 1), 16);

            return nNumber;
        }

    }
}
