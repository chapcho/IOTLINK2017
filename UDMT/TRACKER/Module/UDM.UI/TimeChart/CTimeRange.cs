using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UDM.UI.TimeChart
{
	public class CTimeRange : IDisposable
	{
		#region Member Variables

		protected DateTime m_dtFirst = DateTime.MinValue;
		protected DateTime m_dtLast = DateTime.MinValue;

		internal event UEVentHandlerTimeRangeChanged UEventTimeRangeChanged;

		#endregion


		#region Initialize/Dispose

		public CTimeRange()
		{

		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties

		public DateTime First
		{
			get { return m_dtFirst; }
			set { m_dtFirst = value; GenerateTimeRangeChangedEvent(); }
		}

		public DateTime Last
		{
			get { return m_dtLast; }
			set { m_dtLast = value; GenerateTimeRangeChangedEvent(); }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		protected void GenerateTimeRangeChangedEvent()
		{
			if (UEventTimeRangeChanged != null)
				UEventTimeRangeChanged(this);
		}

		#endregion


		#region Event Methods


		#endregion
	}
}
