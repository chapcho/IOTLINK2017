using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CSeriesPointComparer: IComparer<CSeriesPoint>
    {
		public int Compare(CSeriesPoint x, CSeriesPoint y)
        {
			int iValue = x.Time.CompareTo(y.Time);

            return iValue;
        }
    }
}
