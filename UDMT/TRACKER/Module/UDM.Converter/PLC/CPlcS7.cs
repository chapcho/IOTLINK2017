using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using System.Text.RegularExpressions;
using UDM.Common;

namespace UDM.Converter
{
    public static class CPlcS7
    {
        public static string Bit = "I|Q|M";
        public static string Byte = "IB|QB|MB";
        public static string Word = "IW|QW|MW";
        public static string DWord = "ID|QD|MD";

        public static string HeadOne = "I|Q|M";
        public static string HeadTwo = "IW|QW|MW|IW|QW|MW|ID|QD|MD";

        public static bool IsAddress(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return false;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", HeadOne) + "{1}[0-9.]"))      
                    return true;
                else if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", HeadTwo) + "{2}[0-9.]"))
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

        public static EMDataType GetDataType(string sAddress)
        {
            try
            {
                if (sAddress == string.Empty)
                    return EMDataType.None;

                if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", Bit) + "{1}[0-9.]"))      // Regex  -> "@"^[B|W|X|Y|M|L|F|V|S|D|T|C|R|Z]{1}[0-9.]"
                    return EMDataType.Bool;
                else if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", Byte) + "{2}[0-9.]"))
                    return EMDataType.Byte;
                else if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", Word) + "{2}[0-9.]"))
                    return EMDataType.Word;
                else if (Regex.IsMatch(sAddress, string.Format(@"^[{0}]", DWord) + "{2}[0-9.]"))
                    return EMDataType.DWord;
                else
                    return EMDataType.None;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] [{2}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sAddress); ex.Data.Clear();
                return EMDataType.None;
            }
        }
    }
}
