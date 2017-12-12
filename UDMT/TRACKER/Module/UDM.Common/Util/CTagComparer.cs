using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    public class CTagComparer : IComparer<CTag>
    {
        public int Compare(CTag x, CTag y)
        {
            int iValue = x.Address.CompareTo(y.Address);

            return iValue;
        }
    }
    
    public class CTagMajorComparer : IComparer<CTag>
    {
        public int Compare(CTag x, CTag y)
        {
            int iValue = x.AddressMajor.CompareTo(y.AddressMajor);

            return iValue;
        }
    }
}
