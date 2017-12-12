using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CGanttBarS : List<CGanttBar>, IDisposable
	{

		#region Member Variables

		protected CGanttItem m_cItem = null;

		#endregion


		#region Initialize/Dispose

		public CGanttBarS(CGanttItem cItem)
		{
			m_cItem = cItem;
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public CGanttItem Item
		{
			get { return m_cItem; }
			set { m_cItem = value; }
		}

		#endregion


		#region Public Methods

		public new void Add(CGanttBar cBar)
		{
			if(cBar == null)
				return;

			cBar.Item = m_cItem;

			base.Add(cBar);
		}

		public void AddRange(List<CGanttBar> lstBar)
		{
			for(int i=0;i<lstBar.Count;i++)
				lstBar[i].Item = m_cItem;

			base.AddRange(lstBar);
		}

		public CGanttBar Find(int iIndexFrom, int iIndexTo, DateTime dtTime)
		{
			if (iIndexFrom == -1 || iIndexFrom > iIndexTo)
				return null;

			CGanttBar cBar = null;
			CGanttBar cTemp;
			for(int i=iIndexFrom; i< iIndexTo + 1;i++)
			{
				cTemp = this[i];
				if(dtTime >= cTemp.StartTime && dtTime <= cTemp.EndTime)
				{
					cBar = cTemp;
					break;
				}
			}

			return cBar;
		}

		public CGanttBar FindHasData(object oData)
		{
			CGanttBar cBar = null;
			CGanttBar cTemp;
			for (int i = 0; i < this.Count; i++)
			{
				cTemp = this[i];
				if (cTemp.Data == oData)
				{
					cBar = cTemp;
					break;
				}
			}

			return cBar;
		}

		public new void Sort()
		{
			this.Sort(new CGanttBarComparer());
		}

		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
