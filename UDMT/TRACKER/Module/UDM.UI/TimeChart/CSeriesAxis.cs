using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UDM.UI.TimeChart
{
	public class CSeriesAxis : IDisposable
	{
		#region Member Variables

		protected bool m_bShowMinorGrid = true;
		protected int m_iMajorTickCount = 10;
		protected int m_iMinorTickCount = 2;
		
		protected float m_nMaximum = 1;
		protected float m_nMinimum = 0;

		#endregion


		#region Initialize/Dispose

		public CSeriesAxis()
		{

		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public bool ShowMinorGrid
		{
			get { return m_bShowMinorGrid; }
			set { m_bShowMinorGrid = value; }
		}

		public int MajorTickCount
		{
			get { return m_iMajorTickCount; }
			set { m_iMajorTickCount = value; }
		}

		public int MinorTickCount
		{
			get { return m_iMinorTickCount; }
			set { m_iMinorTickCount = value; }
		}

		public float Maximum
		{
			get { return m_nMaximum; }
			set { m_nMaximum = value; }
		}

		public float Minimumn
		{
			get { return m_nMinimum; }
			set { m_nMinimum = value; }
		}

		#endregion


		#region Public Methods



		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
