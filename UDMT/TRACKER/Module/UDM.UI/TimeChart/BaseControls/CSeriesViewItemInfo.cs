using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UDM.UI.TimeChart
{
	public class CSeriesViewItemInfo : IDisposable
	{

		#region Member Variables

		protected int m_iPointIndexFrom = -1;
		protected int m_iPointIndexTo = -1;
		protected GraphicsPath m_gPath = new GraphicsPath();

		#endregion


		#region Initialize/Dispose

		public CSeriesViewItemInfo(int iPointIndexFrom, int iPointIndexTo)
		{
			m_iPointIndexFrom = iPointIndexFrom;
			m_iPointIndexTo = iPointIndexTo;
		}

		public void Dispose()
		{
			m_iPointIndexFrom = -1;
			m_iPointIndexTo = -1;

			m_gPath.Reset();
		}

		#endregion


		#region Public Properties

		public int PointIndexFrom
		{
			get { return m_iPointIndexFrom; }
			set { m_iPointIndexFrom = value; }
		}
		
		public int PointIndexTo
		{
			get { return m_iPointIndexTo; }
			set { m_iPointIndexTo = value; }
		}

		public GraphicsPath PathInfo
		{
			get { return m_gPath; }
			set { m_gPath = value; }
		}

		#endregion


		#region Public Methods


		#endregion
	}
}
