using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source
{
	public abstract class CMonitorServerBase : IDisposable
	{

		#region Member Variables

		protected bool m_bRun = false;
		protected bool m_bConnect = false;

		public event EventHandler UEventTerminated;
        public event UEventHandlerMonitorValueChanged UEventValueChanged;

		#endregion


		#region Initialize/Dispose

        public CMonitorServerBase()
		{

		}

		public void Dispose()
		{
			if (m_bRun)
				Stop();

			Clear();
		}

		#endregion


		#region Public Properties

		public bool IsConnected
		{
			get { return m_bConnect; }
		}

		public bool IsRunning
		{
			get { return m_bRun; }
		}

		#endregion


		#region Public Methdos

		public abstract bool Connect();
		public abstract bool Disconnect();
		public abstract bool Run();
		public abstract bool Stop();
		public abstract void Clear();
        public abstract bool AddItemS(List<CTag> lstTag);
        public abstract bool RemoveItemS(List<CTag> lstTag);
        public abstract List<string> ValidateItemS(List<CTag> lstTag);
        public abstract CTimeLogS ReadInstant(List<CTag> lstTag);

		#endregion


		#region Private Methods

		protected void GenerateServerTerminateEvent()
		{
			if (UEventTerminated != null)
				UEventTerminated(this, EventArgs.Empty);
		}

        protected void GenerateValueChangeEvent(CTimeLogS cLogS)
        {
            if (UEventValueChanged != null)
                UEventValueChanged(this, cLogS);
        }

		#endregion

	}
}
