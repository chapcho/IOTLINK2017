using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UDM.Common;

namespace UDM.DDEA
{
    [Serializable]
    public class CDDEASymbolS : Dictionary<string, CDDEASymbol>
    {
        #region Member Veriables

        protected CDDEASymbolS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
        protected List<string> m_lstStep = new List<string>();

        #endregion


        #region Initialize

        public CDDEASymbolS()
        {

        }

        #endregion


        #region Properties

        public List<string> StepList
        {
            get { return m_lstStep; }
            set { m_lstStep = value; }
        }

        #endregion


        #region Public Method

        #region 일반함수

        public List<CDDEASymbol> AddSymbolList(List<CDDEASymbol> lstAddSymbol)
        {
            List<CDDEASymbol> lstAddedSymbol = new List<CDDEASymbol>();
            foreach (CDDEASymbol sym in lstAddSymbol)
            {
                if (!this.ContainsKey(sym.Key))
                {
                    this.Add(sym.Key, sym);
                    lstAddedSymbol.Add(sym);
                }
            }
            return lstAddedSymbol;
        }

        public void AddSymbol(CDDEASymbol cSymbol)
        {
            if (cSymbol == null) return;
            if (!this.ContainsKey(cSymbol.Key))
                this.Add(cSymbol.Key, cSymbol);
        }

        public void AddSymbolS(CDDEASymbolS cAddSymbolS)
        {
            foreach (var sym in cAddSymbolS)
            {
                if (!this.ContainsKey(sym.Key))
                    this.Add(sym.Value.Key, sym.Value);
            }
        }

        public List<CDDEASymbol> ChangeToList()
        {
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();

            foreach (var who in this)
            {
                lstResult.Add(who.Value);
            }

            return lstResult;
        }

        public void CreateSymbolS(CRefTagS cTagS, CTagS cAllTagS)
        {
            foreach (string sKey in cTagS.KeyList)
            {
                if (cAllTagS.ContainsKey(sKey))
                {
                    this.AddSymbol(new CDDEASymbol(cAllTagS[sKey]));
                }
            }
        }

        #endregion

        public void CreateWordLength(CDDEASymbol cSymbol)
        {
            //Length가 1이상 일경우 새로운Word를 생성한다 단, 새로 생성된 접점은 Length가 0이다.
            if (cSymbol.DataType == EMDataType.Word && cSymbol.AddressCount > 1)
            {
                for (int i = 1; i < cSymbol.AddressCount; i++)
                {
                    int iAddress = cSymbol.AddressMajor + i;
                    string sAddress = cSymbol.AddressHeader + iAddress.ToString();
                    if (cSymbol.CheckAddressHexa(sAddress))
                    {
                        string sHexa = string.Format("{0:x}", iAddress);
                        sAddress = cSymbol.AddressHeader + sHexa;
                    }

                    CDDEASymbol cSubSymbol = new CDDEASymbol(sAddress, true);
                    cSubSymbol.CreateMelsecDDEASymbol(sAddress);
                    cSubSymbol.BaseAddress = sAddress;
                    cSubSymbol.AddressCount = 0;

                    if (this.ContainsKey(cSubSymbol.Key) == false)
                        this.AddSymbol(cSubSymbol);
                    cSymbol.DWordSecondAddress = sAddress;
                }
            }
        }

        #endregion


        #region Protected Method

        #endregion
    }
}
