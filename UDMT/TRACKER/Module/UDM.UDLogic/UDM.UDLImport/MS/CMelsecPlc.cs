using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CMelsecPlc
    {
        private static string mBit = "X|Y|M|L|V|S|B|SB|SM|F|FX|FY|DY|DX";
        private static string mWord = "W|SW|D|R|Z|ZR|T|C|FD|ST|E";
        private static string mNumeric = "K|H";

        private static string mHeadHexa = "B|W|X|Y|SB|SW|DY|DX";
        private static string mHeadOne = "B|W|X|Y|M|L|F|V|S|D|T|C|R|Z|E";
        private static string mHeadTwo = "ZR|SW|SB|SD|SM|DY|DX|FX|FY|FD|ST";

        public static bool IsMelsecAddress(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                bool bOk = false;

                sAddress = GetNormalMelsecAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^({0}|{1})", mBit, mWord) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsMelsecNumeric(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", mNumeric) + "{1}[0-9A-Fa-f]"))      // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
                    return true;
                else
                    return false;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsMelsecHeadOne(string sAddress)
        {
            bool bOk = false;

            try
            {

                if (sAddress == string.Empty)
                    bOk = false;

                sAddress = GetNormalMelsecAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", mHeadOne) + "{1}[0-9.]"))
                    // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
                    bOk = true;
                else if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", mHeadOne) + "{1}[A-F.]"))
                    // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}
                    bOk = true;
                else
                    bOk = false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
            return bOk;
        }

        public static bool IsMelsecHeadTwo(string sAddress)
        {
            bool bOK = false;

            try
            {
                if (sAddress == string.Empty)
                    bOK = false;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", mHeadTwo) + "{2}[0-9.]"))
                    bOK = true;
                else
                    bOK = false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
            return bOK;
        }

        public static bool IsMelsecBit(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                sAddress = GetNormalMelsecAddress(sAddress);

                if (sAddress.Contains("."))
                    return true;

                if (IsMelsecHeadOne(sAddress))
                {
                    if (("|" + mBit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                        bOk = true;
                }
                else
                {
                    if (("|" + mBit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
                        bOk = true;
                }

                return bOk;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsMelsecWord(string sAddress)
        {
            try
            {
                bool bOk = false;

            if (sAddress == string.Empty)
                return bOk;

            sAddress = GetNormalMelsecAddress(sAddress);

            if (IsMelsecHeadOne(sAddress))
            {
                if (("|" + mWord + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                    bOk = true;
            }
            else
            {
                if (("|" + mWord + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
                    bOk = true;
            }

            return bOk;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsMelsecHexa(string sAddress)
        {
            try
            {
                bool bOk = false;

                sAddress = GetNormalMelsecAddress(sAddress);

                if (sAddress == string.Empty)
                    return bOk;

                if (Regex.IsMatch(sAddress, string.Format(@"^({0})", mHeadHexa) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        private static string GetNormalMelsecAddress(string sAddress)
        {
            sAddress = sAddress.ToUpper();

            if (sAddress.StartsWith("@") && sAddress.Length > 1)
                sAddress = sAddress.Remove(0, 1);

            if (sAddress.StartsWith("K") && sAddress.Length > 1)
                sAddress = sAddress.Remove(0, 2);

            if (!sAddress.StartsWith("Z") && sAddress.Contains('Z'))
                sAddress = sAddress.Split('Z')[0];

            return sAddress;
        }

        public static bool CheckAddressDesignatedIndirect(string sAddress)
        {
            bool bOK = false;

            sAddress = sAddress.ToUpper();

            if (sAddress.StartsWith("@") && sAddress.Length > 1)
                bOK = true;

            return bOK;
        }

        public static bool CheckAddressDesignatedDigit(string sAddress)
        {
            bool bOK = false;

            sAddress = sAddress.ToUpper();

            if (sAddress.StartsWith("K") && sAddress.Length > 1)
                bOK = true;

            return bOK;
        }
    }
}
