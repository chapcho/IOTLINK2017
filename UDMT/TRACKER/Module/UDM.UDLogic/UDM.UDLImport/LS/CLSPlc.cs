using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CLSPlc
    {
        private static string LSBit = "P|M|K|F|L|S";
        private static string LSWord = "D|R|U|T|C|Z|N|ZR";
        private static string LSNumeric = "H"; //Header가 안붙는 경우도 Numeric, Decimal
        private static string LSHeadHexa = "P|M|K|F|L";
        private static string LSHeadOne = "P|M|K|F|L|S|D|R|U|T|C|Z|N";
        private static string LSHeadTwo = "ZR";

        public static bool IsLSAddress(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                bool bOk = false;

                sAddress = GetNormalLSAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^({0}|{1})", LSBit, LSWord) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsLSHeadOne(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = GetNormalLSAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", LSHeadOne) + "{1}[0-9.]"))      // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
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

        public static bool IsLSHeadTwo(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = GetNormalLSAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", LSHeadTwo) + "{2}[0-9.]"))
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

        public static bool IsLSNumeric(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = GetNormalLSAddress(sAddress);

                bool bOK = false;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", LSNumeric) + "{1}[0-9A-Fa-f]")
                    || Regex.IsMatch(sAddress, string.Format(@"^[0-9]+")) && !Regex.IsMatch(sAddress, @"[A-Za-z]"))    // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
                    bOK = true;

                return bOK;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        public static bool IsLSBit(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                if (sAddress.Contains("."))
                    return true;

                sAddress = GetNormalLSAddress(sAddress);

                if (IsLSHeadOne(sAddress))
                {
                    if (("|" + LSBit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                        bOk = true;
                }
                else
                {
                    if (("|" + LSBit + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
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

        public static bool IsLSWord(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                sAddress = GetNormalLSAddress(sAddress);

                if (IsLSHeadOne(sAddress))
                {
                    if (("|" + LSWord + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 1))))
                        bOk = true;
                }
                else
                {
                    if (("|" + LSWord + "|").Contains(string.Format("|{0}|", sAddress.Substring(0, 2))))
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

        public static bool IsLSHexa(string sAddress)
        {
            try
            {
                bool bOk = false;

                if (sAddress == string.Empty)
                    return bOk;

                sAddress = GetNormalLSAddress(sAddress);

                if (Regex.IsMatch(sAddress, string.Format(@"^({0})", LSHeadHexa) + "[0-9ABCDEF.]+"))
                    bOk = true;

                return bOk;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return false;
            }
        }

        private static string GetNormalLSAddress(string sAddress)
        {
            sAddress = sAddress.ToUpper();

            if (sAddress.StartsWith("#") && sAddress.Length > 1)
                sAddress = sAddress.Remove(0, 1);

            if (!sAddress.StartsWith("Z") && sAddress.Contains("Z") && sAddress.Contains("[") && sAddress.Contains("]"))
                sAddress = sAddress.Split('[')[0];

            return sAddress;
        }
    }
}
