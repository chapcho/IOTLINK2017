using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CSeriesViewItemInfoS : Dictionary<CSeriesItem, CSeriesViewItemInfo>, IDisposable
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public CSeriesViewItemInfoS()
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


		#endregion
	}
}
