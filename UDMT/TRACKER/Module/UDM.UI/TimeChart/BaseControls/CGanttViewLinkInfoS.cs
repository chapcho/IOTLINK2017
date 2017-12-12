using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UDM.UI.TimeChart
{
	public class CGanttViewLinkInfoS : Dictionary<CGanttLink, CGanttViewLinkInfo>, IDisposable
	{

		#region Member Variables


		#endregion


		#region Initialize/Dispose

		public CGanttViewLinkInfoS()
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

		public CGanttLink FindLink(Point pntPos)
		{
			Pen pen = new Pen(Color.Black, 8f);

			CGanttLink cLink = null;
			CGanttViewLinkInfo cLinkInfo = null;
			for (int i = 0; i < this.Count; i++)
			{
				cLinkInfo = this.ElementAt(i).Value;
				if (cLinkInfo.PathInfo.IsOutlineVisible(pntPos, pen))
				{
					cLink = this.ElementAt(i).Key;
					break;
				}
			}

			pen.Dispose();
			pen = null;

			return cLink;
		}

		public List<CGanttLink> GetLinkList(CGanttBar cBar)
		{
			List<CGanttLink> lstLink = new List<CGanttLink>();

			CGanttLink cLink;
			for(int i=0;i<this.Count;i++)
			{
				cLink = this.ElementAt(i).Key;
				if(cLink.BarFrom == cBar || cLink.BarTo == cBar)
					lstLink.Add(cLink);
			}

			return lstLink;
		}

		public void Remove(CGanttBar cBar)
		{
			CGanttLink cLink;
			for (int i = 0; i < this.Count; i++)
			{
				cLink = this.ElementAt(i).Key;
				if (cLink.BarFrom == cBar || cLink.BarTo == cBar)
				{
					this.Remove(cLink);
					i--;
				}
			}
		}

		#endregion
	}
}
