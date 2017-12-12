using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UDM.UI.TimeChart
{
	public class CSeriesPointS : List<CSeriesPoint>, IDisposable
	{

		#region Member Variables

		protected CSeriesItem m_cItem = null;

		protected float m_nMaxValue = 0f;
		protected float m_nMinValue = 0f;

		#endregion


		#region Initialize/Dispose

		public CSeriesPointS(CSeriesItem cItem)
		{
			m_cItem = cItem;
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		public CSeriesItem Item
		{
			get { return m_cItem; }
			set { m_cItem = value; }
		}

		public float MaxValue
		{
			get { return m_nMaxValue; }
		}

		public float MinValue
		{
			get { return m_nMinValue; }
		}

		#endregion


		#region Public Methods

		public new void Add(CSeriesPoint cPoint)
		{
			if (cPoint == null)
				return;

			cPoint.Item = m_cItem;

			if (this.Count == 0)
			{
				m_nMaxValue = cPoint.Value;
				m_nMinValue = cPoint.Value;
			}

			if (cPoint.Value > m_nMaxValue)
				m_nMaxValue = cPoint.Value;
			else if (cPoint.Value < m_nMinValue)
				m_nMinValue = cPoint.Value;

			base.Add(cPoint);
		}

		public new void Sort()
		{
			this.Sort(new CSeriesPointComparer());
		}

		#endregion


		#region Private Methods


		#endregion


		#region Event Methods


		#endregion
	}
}
