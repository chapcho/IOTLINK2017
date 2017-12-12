using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    public class CSymbolComparer : IComparer<CDDEASymbol>
    {
        public int Compare(CDDEASymbol x, CDDEASymbol y)
        {
            int iValue = x.AddressMajor.CompareTo(y.AddressMajor);

            return iValue;
        }
    }

    public class CSymbolMinorComparer : IComparer<CDDEASymbol>
    {
        public int Compare(CDDEASymbol x, CDDEASymbol y)
        {
            int iValue = x.AddressMinor.CompareTo(y.AddressMinor);

            return iValue;
        }
    }

    public class CSymbolHeadComparer : IComparer<CDDEASymbol>
    {
        public int Compare(CDDEASymbol x, CDDEASymbol y)
        {
            int iValue = x.AddressHeader.CompareTo(y.AddressHeader);

            return iValue;
        }
    }

}
