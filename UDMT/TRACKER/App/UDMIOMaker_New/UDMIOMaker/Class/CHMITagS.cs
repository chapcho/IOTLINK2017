using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UDMIOMaker
{
    [Serializable]
    public class CHMITagS : Dictionary<string, CHMITag>, IDisposable
    {
        

        #region Initialize/Dispose

        public CHMITagS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CHMITagS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public bool CheckPLCTagMapping(string sPLCKey)
        {
            bool bOK = false;

            foreach (var who in this)
            {
                if (who.Value.PLCTagKey == sPLCKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        public bool IsContainConvertName(string sName, string sExistKey)
        {
            bool bOK = false;

            if (sName == string.Empty)
                return false;

            foreach (var who in this)
            {
                if (who.Value.ConvertName == sName && who.Value.Name != sExistKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        public string GetSameConvertNameHMIKey(string sName, string sExistKey)
        {
            string sKey = string.Empty;

            foreach (var who in this)
            {
                if (who.Value.ConvertName == sName && who.Value.Name != sExistKey)
                {
                    sKey = who.Key;
                    break;
                }
            }

            return sKey;
        }

        public List<string> GetHMITagKey(string sPLCKey)
        {
            List<string> lstHMIKey = new List<string>();

            foreach (var who in this)
            {
                if (who.Value.PLCTagKey == sPLCKey)
                    lstHMIKey.Add(who.Key);
            }

            return lstHMIKey;
        }

        public List<string> GetHMITagKey(string sAddress, string sDescription)
        {
            List<string> lstHMIKey = new List<string>();

            foreach(var who in this)
            {
                if (who.Value.Address == sAddress && who.Value.Description == sDescription)
                    lstHMIKey.Add(who.Key);
            }

            return lstHMIKey;
        }


        #endregion

        #region Private Methods

        #endregion

    }
}
