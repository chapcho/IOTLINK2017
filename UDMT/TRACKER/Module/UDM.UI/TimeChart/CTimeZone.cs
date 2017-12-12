using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.TimeChart
{
	public class CTimeZone : IDisposable
	{
		#region Member Variables

		protected DateTime m_dtFrom = DateTime.MinValue;
		protected DateTime m_dtTo = DateTime.MinValue;
		protected Color m_cColor = Color.Yellow;
		protected string m_sText = "";

		#endregion


		#region Initialize/Dispose

		public CTimeZone()
		{

		}

		public CTimeZone(DateTime dtFrom, DateTime dtTo, Color cColor, string sText)
		{
			m_dtFrom = dtFrom;
			m_dtTo = dtTo;
			m_cColor = cColor;
			m_sText = sText;
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public DateTime From
		{
			get { return m_dtFrom; }
			set { m_dtFrom = value; }
		}

		public DateTime To
		{
			get { return m_dtTo; }
			set { m_dtTo = value; }
		}

		public Color Color
		{
			get { return m_cColor; }
			set { m_cColor = value; }
		}

		public string Text
		{
			get { return m_sText; }
			set { m_sText = value; }
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
