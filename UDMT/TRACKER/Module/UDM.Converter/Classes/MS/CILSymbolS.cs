using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILSymbolS : Dictionary<string, CILSymbol>
    {
        #region Memeber Variables

        #endregion

        #region Initialize/Dispose

        public CILSymbolS()
        {

        }

        protected CILSymbolS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        public void Dispose()
        {
            Clear();
        }

        #endregion

        #region Public Properties

        public bool IsOneEvent
        {
            get
            {
                if (this.Count == 1)
                    return true;
                else
                    return false;
            }
        }


        #endregion

        #region Public Methods

      

        public int GetTotalSize(EMDataType emDataType)
        {
            int nCount = 0;
            Dictionary<string, string> DicAddress = new Dictionary<string, string>();
            foreach (var who in this)
            {
                CILSymbol cILSymbol = who.Value;
                if (cILSymbol.DataType == emDataType)
                {
                    nCount++;
                    DicAddress.Add(cILSymbol.Address, cILSymbol.Address);
                }
            }

            return nCount;
        }

        public string GetSymbol(string sProgram, string sAddress)
        {
            if (sAddress.StartsWith("K"))
                sAddress = sAddress.Substring(2, sAddress.Length - 2);
            if (sAddress.Contains('.'))
                sAddress = sAddress.Split('.')[0];
            if (sAddress.StartsWith("DX"))
                sAddress = sAddress.Replace("DX", "X");
            if (sAddress.StartsWith("DY"))
                sAddress = sAddress.Replace("DY", "Y");

            string sKey = string.Format("{0}.{1}", sProgram, sAddress);
            string sCommonKey = string.Format("{0}.{1}", "COMMENT", sAddress);

            if (this.ContainsKey(sKey))
                return string.Format("[{0}]{1}", sProgram, this[sKey].Name);
            else if (this.ContainsKey(sCommonKey))
                return this[sCommonKey].Name;
            else
                return string.Empty;
        }

        public string GetAddressNSymbol(string sProgram, string sAddress)
        {
            string sAddressNSymbol = string.Empty;
            string sSymbol = GetSymbol(sProgram, sAddress);
            if (sSymbol == string.Empty)
                sAddressNSymbol = sAddress;
            else
                sAddressNSymbol = string.Format("{0} : {1}", sAddress, sSymbol);

            return sAddressNSymbol;
        }



        public object Clone()
        {
            return null;
        }

        #endregion

        #region protected Methods


        #endregion
    }
}
