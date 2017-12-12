using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.DDEA
{
    [Serializable]
    public class CDDEASymbolList : List<CDDEASymbol>
    {
        #region Initialize

        public CDDEASymbolList()
        {

        }

        #endregion

        #region Public Method

        /// <summary>
        /// 중복될 수 있음.
        /// </summary>
        /// <param name="cSymbol"></param>
        public void CreateWordLength(CDDEASymbol cSymbol)
        {
            //Length가 1이상 일경우 새로운Word를 생성한다 단, 새로 생성된 접점은 Length가 0이다.
            if (cSymbol.DataType == EMDataType.Word)
            {
                cSymbol.BaseAddress = cSymbol.Address;
                if (cSymbol.AddressCount > 1)
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
                        this.AddSymbol(cSubSymbol);
                        cSymbol.DWordSecondAddress = sAddress;
                    }
                }
            }
        }

        public void AddSymbol(CDDEASymbol cSymbol)
        {
            CDDEASymbol sym = this.Find(b => b.Key == cSymbol.Key);
            if (sym == null)
                this.Add(cSymbol);
        }
        
        public void AddSymbolS(CDDEASymbolS cAddSymbolS)
        {
            foreach (var sym in cAddSymbolS)
            {
                CDDEASymbol cSymbol = this.Find(b => b.Key == sym.Value.Key);
                if(cSymbol == null)
                    this.Add(sym.Value);
            }
        }

        public void AddSymbolList(List<CDDEASymbol> lstAddSymbol)
        {
            foreach (CDDEASymbol sym in lstAddSymbol)
            {
                CDDEASymbol cSymbol = this.Find(b => b.Key == sym.Key);
                if(cSymbol == null)
                    this.Add(sym);
            }
        }

        public List<CDDEASymbol> FindEqulBaseAddressSymbol(string sBaseAddress)
        {
            List<CDDEASymbol> lstResult = this.FindAll(b => b.BaseAddress == sBaseAddress);

            return lstResult;
        }

        public List<CDDEASymbol> FindEqulAddressSymbolList(string sAddress)
        {
            List<CDDEASymbol> lstResult = this.FindAll(b => b.Address == sAddress);

            return lstResult;
        }

        public CDDEASymbol FindEqulAddressSymbol(string sAddress)
        {
            CDDEASymbol cResult = this.Find(b => b.Address == sAddress);

            return cResult;
        }

        public CDDEASymbolS ChangeToDDEASymbolS()
        {
            if (this.Count == 0) return null;

            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            foreach (CDDEASymbol sym in this)
            {
                cSymbolS.AddSymbol(sym);
            }
            return cSymbolS;
        }

        #endregion
    }
}
