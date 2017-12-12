using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using System.Text.RegularExpressions;

namespace UDM.Converter
{
    public static class CPlcAb
    {
        public static List<string> HEXA = new List<string> { "B", "W", "X", "Y", "SW", "SB", "DY", "DX" };
        public static List<string> DEC = new List<string> { "M", "L", "F", "D", "T", "C", "R", "ZR" };

        public static List<string> BIT = new List<string> { "X", "Y", "M", "L", "F", "B", "SB" };
        public static List<string> WORD = new List<string> { "W", "SW", "D", "R", "ZR", "T", "C", "DY", "DX" };

        public static List<string> HeadOneChar = new List<string> { "B", "W", "X", "Y", "M", "L", "F", "D", "T", "C", "R", "Z" };
        public static List<string> HeadTwoChar = new List<string> { "ZR", "SW", "SB", "SD", "DY", "DX", "SM" };
        public static List<string> HeadListAll = new List<string> { "B", "W", "X", "Y", "M", "L", "F", "D", "T", "C", "R", "Z", "ZR", "SW", "SB", "SD", "DY", "DX" };

        public static bool IsAddress(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                sAddress = sAddress.ToUpper().TrimStart('K');

                string sHead = Regex.Replace(sAddress, @"[\d-]", string.Empty);

                if (HeadListAll.Contains(sHead))
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
    }
}
