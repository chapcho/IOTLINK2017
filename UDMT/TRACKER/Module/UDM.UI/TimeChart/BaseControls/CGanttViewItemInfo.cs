using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CGanttViewItemInfo : IDisposable
	{

		#region Member Variables

		protected int m_iBarIndexFrom = -1;
		protected int m_iBarIndexTo = -1;

		#endregion


		#region Initialize/Dispose

		public CGanttViewItemInfo(int iBarIndexFrom, int iBarIndexTo)
		{
			m_iBarIndexFrom = iBarIndexFrom;
			m_iBarIndexTo = iBarIndexTo;
		}

		public void Dispose()
		{
			m_iBarIndexFrom = -1;
			m_iBarIndexTo = -1;
		}

		#endregion


		#region Public Properties

		public int BarIndexFrom
		{
			get { return m_iBarIndexFrom; }
			set { m_iBarIndexFrom = value; }
		}
		
		public int BarIndexTo
		{
			get { return m_iBarIndexTo; }
			set { m_iBarIndexTo = value; }
		}

		#endregion


		#region Public Methods


		#endregion
	}
}
