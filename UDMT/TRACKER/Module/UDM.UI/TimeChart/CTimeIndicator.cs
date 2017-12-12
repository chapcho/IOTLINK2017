using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.TimeChart
{
	public class CTimeIndicator : IDisposable
	{
		#region Member Variables

		protected DateTime m_dtTime = DateTime.MinValue;
		protected Color m_cColor = Color.OrangeRed;
        protected EMTimeLineType m_emTimeLineType = EMTimeLineType.Duration;

		#endregion


		#region Initialize/Dispose

		public CTimeIndicator()
		{

		}

		public CTimeIndicator(DateTime dtTime, Color cColor)
		{
			m_dtTime = dtTime;
			m_cColor = cColor;
		}

        public CTimeIndicator(DateTime dtTime, Color cColor, EMTimeLineType emType)
        {
            m_dtTime = dtTime;
            m_cColor = cColor;
            m_emTimeLineType = emType;
        }

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public DateTime Time
		{
			get { return m_dtTime;}
			set { m_dtTime = value; }
		}

		public Color Color
		{
			get { return m_cColor; }
			set { m_cColor = value; }
		}

        public EMTimeLineType TimeLineType
        {
            get { return m_emTimeLineType; }
            set { m_emTimeLineType = value; }
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
