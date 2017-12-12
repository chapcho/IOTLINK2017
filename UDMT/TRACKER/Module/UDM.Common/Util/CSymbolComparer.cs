using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    public class CSymbolComparer : IComparer<CSymbol>
    {
        public int Compare(CSymbol x, CSymbol y)
        {
            int iValue = x.Tag.AddressMajor.CompareTo(y.Tag.AddressMajor);

            return iValue;
        }
    }

    public class CSymbolMinorComparer : IComparer<CSymbol>
    {
        public int Compare(CSymbol x, CSymbol y)
        {
            int iValue = x.Tag.AddressMinor.CompareTo(y.Tag.AddressMinor);

            return iValue;
        }
    }

    public class CSymbolHeadComparer : IComparer<CSymbol>
    {
        public int Compare(CSymbol x, CSymbol y)
        {
            int iValue = x.Tag.AddressHeader.CompareTo(y.Tag.AddressHeader);

            return iValue;
        }
    }

}
