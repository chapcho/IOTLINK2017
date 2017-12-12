using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using System.Text.RegularExpressions;

namespace UDM.Converter
{
    public static class CPlcMelsec
    {
        private static string Bit = "X|Y|M|L|V|S|B|SB|SM|F|FX|FY|DY|DX";
        private static string Word = "W|SW|D|R|Z|ZR|T|C|FD|ST";
        private static string Numeric = "K|H";

        private static string HeadHexa = "B|W|X|Y|SB|SW|DY|DX";
        private static string HeadOne = "B|W|X|Y|M|L|F|V|S|D|T|C|R|Z";
        private static string HeadTwo = "ZR|SW|SB|SD|SM|DY|DX|FX|FY|FD|ST";

        public static bool IsAddress(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                bool bOk = false;

                sAddress = GetNormalAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^({0}|{1})", Bit , Word) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsNumeric(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", Numeric) + "{1}[0-9-]"))      // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
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


        public static bool IsHeadOne(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = GetNormalAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", HeadOne) + "{1}[0-9.]"))      // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
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


        public static bool IsHeadTwo(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = GetNormalAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", HeadTwo) + "{2}[0-9.]"))
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


        public static bool IsBit(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                if (sAddress.Contains("."))
                    return true;

                sAddress = GetNormalAddress(sAddress);

                if (IsHeadOne(sAddress))
                {
                    if (("|" + Bit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                        bOk = true;
                }
                else
                {
                    if (("|" + Bit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
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

        public static bool IsWord(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                sAddress = GetNormalAddress(sAddress);

                if (IsHeadOne(sAddress))
                {
                    if (("|" + Word + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                        bOk = true;
                }
                else
                {
                    if (("|" + Word + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
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

        public static bool IsHexa(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                sAddress = GetNormalAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^({0})", HeadHexa) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        private static string GetNormalAddress(string sAddress)
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
    }
}
