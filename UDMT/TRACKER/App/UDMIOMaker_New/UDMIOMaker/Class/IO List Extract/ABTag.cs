using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace UDMIOMaker
{
    public class ABTag : CTag
    {
        public string ABID = string.Empty;
        public string ABUIO = string.Empty;
        public string ABSYMBOL = string.Empty;
        public string ABADDRESS = string.Empty;
        public string ABADDRESSTEMP = string.Empty;
        public string ABDATATYPE = string.Empty;
        public string ABHEADTYPE = string.Empty;
        public string ABTAG = string.Empty;
        public string ABSPECIPER = string.Empty;  //for AB PLC
        public string ABSHEET = string.Empty;
        public string ABBLOCK = string.Empty;
        public string ABNETWORK = string.Empty;
        public string ABMODULE = string.Empty;
        public string ABINFO = string.Empty;
        public string ABCOMMENT = string.Empty;
        public string ABUPDATETIME = string.Empty;
        public string ABGROUP = string.Empty;
        public string ABARRAYSIZE = string.Empty;
        public string ABABITSIZE = string.Empty;

        public List<string> ABListLevel = new List<string>();

        public string ABCHECKDATA = eUIOStatus.OK;
        public string ABCHECKLIBRARY = eLIBCheckResult.UNCHECK;

        public int ABADDRESSINDEX = 0;
        public bool ABSkipEPlan = false;
        public bool ABHead = false;
        public bool ABBaseTag = false;

    }
}
