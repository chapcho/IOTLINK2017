using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UDM.UI.TimeChart
{
	public class CGanttLinkS : List<CGanttLink>, IDisposable
	{
		#region Member Variables



		#endregion


		#region Initialize/Dispose

		public CGanttLinkS()
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

		public void Remove(CGanttBar cBar)
		{
			CGanttLink cLink;
			for(int i=0;i<this.Count;i++)
			{
				cLink = this[i];
				if (cLink.BarFrom == cBar || cLink.BarTo == cBar)
				{
					RemoveAt(i);
					i--;
				}
			}
		}

		public List<CGanttLink> GetLinkList(CGanttBar cBar)
		{
			List<CGanttLink> lstLink = new List<CGanttLink>();

			CGanttLink cLink;
			for (int i = 0; i < this.Count; i++)
			{
				cLink = this[i];
				if (cLink.BarFrom == cBar || cLink.BarTo == cBar)
					lstLink.Add(cLink);
			}

			return lstLink;
		}


		public CGanttLink FindHasData(object oData)
		{
			CGanttLink cLink = null;
			CGanttLink cTemp;
			for(int i=0;i<this.Count;i++)
			{
				cTemp = this[i];
				if(cTemp.Data == oData)
				{
					cLink = cTemp;
					break;
				}
			}

			return cLink;
		}

		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
