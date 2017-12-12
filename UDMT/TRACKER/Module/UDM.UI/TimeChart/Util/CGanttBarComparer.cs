using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CGanttBarComparer: IComparer<CGanttBar>
    {
		public int Compare(CGanttBar x, CGanttBar y)
        {
			int iValue = x.StartTime.CompareTo(y.StartTime);

            return iValue;
        }
    }
}
