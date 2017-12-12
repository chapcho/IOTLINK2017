using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;

namespace UDM.General
{
    public static class CStringHelper
    {
        public static bool IsHexaString(string sValue)
        {
            Regex regex = new Regex(@"^[0-9A-F]+$", RegexOptions.IgnoreCase);

            if (regex.IsMatch(sValue))
                return true;
            else
                return false;
        }

        public static bool IsDigitString(string sValue)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(sValue))
                return true;
            else
                return false;
        }
    }
}
