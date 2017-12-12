using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.TimeChart
{
	public class CSeriesPoint : IDisposable
	{

		#region Member Variables

		protected CSeriesItem m_cItem = null;
		protected DateTime m_dtTime = DateTime.MinValue;
		protected float m_nValue = 0;
        protected object m_oData = null;

		#endregion


		#region Initialize/Dispose

		public CSeriesPoint()
		{

		}

        public CSeriesPoint(DateTime dtTime, float nValue)
        {
            m_dtTime = dtTime;
            m_nValue = nValue;
        }

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public CSeriesItem Item
		{
			get { return m_cItem; }
			set { m_cItem = value; }
		}

		public DateTime Time
		{
			get { return m_dtTime; }
			set { m_dtTime = value; }
		}

		public float Value
		{
			get { return m_nValue; }
			set { m_nValue = value; }
		}

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
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
