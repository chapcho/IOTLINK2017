using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    public static class CCommonUtil
    {

        public static EMDataType ToDataType(string sValue)
        {
            if (sValue == "Byte" || sValue == "BYTE" || sValue == "byte")
                return EMDataType.Byte;
            else if (sValue == "Word" || sValue == "WORD" || sValue == "word")
                return EMDataType.Word;
            else if (sValue == "DWord" || sValue == "DWORD" || sValue == "dword")
                return EMDataType.DWord;
            else
                return EMDataType.Bool;
        }

        public static EMDataType ToMelsecDataType(string sAddress)
        {
            EMDataType emDataType = EMDataType.Bool;
            string sUpper = sAddress.ToUpper();
            string sHeaderNumberCheck = sUpper.Substring(0, 1);
            if (sHeaderNumberCheck == "K")                       //무조건 32Bit단위로 읽음.K7일경우는 28bit -> k1 4bit Mask에서 확인
            {
                sUpper = sUpper.Substring(2, sUpper.Length - 2);
                emDataType = EMDataType.DWord;
            }
            else if (sHeaderNumberCheck == "@")
            {
                emDataType = EMDataType.Word;
            }
            else if (CheckHeaderBit(sUpper) == false)
                emDataType = EMDataType.Word;


            return emDataType;
        }

        public static bool CheckHeaderBit(string sSymName)
        {
            try
            {
                bool bBitOk = false;
                int iData = 0;

                string sResult = string.Empty;

                if (sSymName.Length < 2)
                {
                    sResult = sSymName.Substring(0, 1);
                    if (int.TryParse(sResult, out iData))
                        return false;
                }

                //Dot가 있으면 무조건 비트.
                if ((sSymName.Contains(".")) && (!bBitOk))
                {
                    bBitOk = true;
                    return bBitOk;
                }

                string[] sBitArr = { "B", "M", "X", "Y", "L", "F", "V", "S" };
                string[] sBitTwoArr = { "SB", "FX", "FY", "SM" };

                sResult = sSymName.Substring(0, 2);

                string sIndex = sSymName.Substring(2, sSymName.Length - 2);
                if (sResult == "ST" || sResult == "SD" || sResult == "SW" || sResult == "FD")
                    return false;
                if (sIndex.Contains("Z"))
                    return false;
                for (int i = 0; i < sBitTwoArr.Length; i++)
                {
                    if (sResult == sBitTwoArr[i])
                    {
                        bBitOk = true;
                        break;
                    }
                }

                if (!bBitOk)
                {
                    sResult = sSymName.Substring(0, 1);
                    for (int i = 0; i < sBitArr.Length; i++)
                    {
                        if (sResult == sBitArr[i])
                        {
                            bBitOk = true;
                            break;
                        }
                    }

                }

                return bBitOk;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", ex.InnerException);
            }
        }

        public static EMOperaterType ToOperatorType(string sValue)
        {
            if (sValue == "And" || sValue == "AND" || sValue == "and")
                return EMOperaterType.And;
            else if (sValue == "Or" || sValue == "OR" || sValue == "or")
                return EMOperaterType.Or;
            else
                return EMOperaterType.None;
        }

        public static EMGroupRoleType ToGroupRoleType(string sValue)
        {
            switch (sValue.ToUpper())
            {
                case "KEY": return EMGroupRoleType.Key;
                case "ABNORMAL": return EMGroupRoleType.Abnormal;
                case "TREND": return EMGroupRoleType.Trend;
                default: return EMGroupRoleType.General;
            }
        }

    }

}
