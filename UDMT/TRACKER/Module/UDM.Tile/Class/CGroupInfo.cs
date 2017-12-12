using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using System.Timers;

namespace UDM.Tile
{
	public class CGroupInfo
	{
		#region Member Variables
		protected CMonitorEventArgs m_cMonitorEventArgs = null;
		protected string m_sName = string.Empty;
		protected bool m_bErrorCheck = false;
		protected bool m_bTimerOn = false;

		protected Timer m_tTimer = new Timer();
		protected int m_iInterval = 0;
		protected int m_iTimerElapsedCount = 0;

		protected DateTime m_dtStartDate = default(DateTime);

		public event UEventHandlerGroupInfoTimerTick UEventGroupInfoTimerTick;

		#endregion

		#region Properties
		public CMonitorEventArgs EventArgs
		{
			get { return m_cMonitorEventArgs; }
			set { m_cMonitorEventArgs = value; }
		}

		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}

		public Timer CurrentTimer
		{
			get { return m_tTimer; }
			set { m_tTimer = value; }
		}

		public int Interval
		{
			get { return m_iInterval; }
			set { m_iInterval = value; }
		}

		public int TimerElapsedCount
		{
			get { return m_iTimerElapsedCount; }
		}
		public bool IsTimerOn
		{
			get { return m_bTimerOn; }
			set { m_bTimerOn = value; }
		}
		public DateTime ItemStartDate
		{
			get { return m_dtStartDate; }
			set { m_dtStartDate = value; }
		}
		#endregion

		#region Initialize/Dipose
		#endregion

		#region Public Methods
		public void StartTimer()
		{
			CurrentTimer.Interval = Interval;
			CurrentTimer.Elapsed += new ElapsedEventHandler(CurrentTimer_Elapsed);
			CurrentTimer.Start();
		}

		public void StopTimer()
		{
			CurrentTimer.Stop();
			CurrentTimer.Elapsed -= new ElapsedEventHandler(CurrentTimer_Elapsed);
			if(!IsTimerOn)
				m_iTimerElapsedCount = 0;
		}
		#endregion

		#region Private Methods
		private void CurrentTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			m_iTimerElapsedCount++;
			if (UEventGroupInfoTimerTick != null)
				UEventGroupInfoTimerTick(this, this.Name);
		}
		#endregion
	}
}
