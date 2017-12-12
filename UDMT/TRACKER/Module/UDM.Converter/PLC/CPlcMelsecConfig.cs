using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using System.Text.RegularExpressions;

namespace UDM.Converter
{
    public static class CPlcMelsecConfig
    {
        public static int MoveLimitCount = 128;
        public static int OtherLimitCount = 8;
        public static List<string> lstMoveSupport = new List<string>{ "DECO", "ENCO"};
    }
}
