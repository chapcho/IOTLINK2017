using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CGanttViewItemInfoS : Dictionary<CGanttItem, CGanttViewItemInfo>, IDisposable
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public CGanttViewItemInfoS()
		{

		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties


		#endregion


		#region Public Methods

		public CGanttBar FindBar(CGanttItem cItem, DateTime dtTime)
		{
			if (this.ContainsKey(cItem) == false)
				return null;

			CGanttViewItemInfo cItemInfo = this[cItem];
			CGanttBar cBar = cItem.BarS.Find(cItemInfo.BarIndexFrom, cItemInfo.BarIndexTo, dtTime);

			return cBar;
		}

		#endregion
	}
}
