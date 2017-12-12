using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.OPC
{
	public class COPCGroupS : Dictionary<string, COPCGroup>, IDisposable
	{

		#region Member Variables

		protected bool m_bReady = false;

		protected OPCAutomation.OPCGroups m_exOPCGroupS = null;

		public event UEventHandlerMonitorValueChanged UEventValueChanged;

		#endregion


		#region Intialize/Dispose

		public COPCGroupS(OPCAutomation.OPCServer exOPCServer, int iUpdateRate)
		{	
			m_bReady = Initialize(exOPCServer, iUpdateRate);
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

		public bool IsReady
		{
			get { return m_bReady; }
			set { m_bReady = value; }
		}

		#endregion


		#region Public Methods
		
		public bool AddItemS(List<CTag> lstTag, bool bLsOpc)
		{
			if (m_bReady == false)
				return false;

			if (lstTag == null || lstTag.Count == 0)
				return true;

			COPCGroup cOPCGroup = this["ForEvent"];
            bool bOK = cOPCGroup.AddItemS(lstTag, bLsOpc);

			return bOK;
		}

		public bool RemoveItemS(List<CTag> lstTag, bool bLsOpc)
		{
			if (m_bReady == false)
				return false;

			if (lstTag == null || lstTag.Count == 0)
				return true;

			COPCGroup cOPCGroup = this["ForEvent"];
			bool bOK = cOPCGroup.RemoveItemS(lstTag, bLsOpc);

			return bOK;
		}

        public List<string> ValidateItemS(List<CTag> lstTag, bool bLsOpc)
        {
            if (m_bReady == false)
                return null;

            if (lstTag == null || lstTag.Count == 0)
                return null;

            COPCGroup cOPCGroup = this["ForEvent"];
            return cOPCGroup.ValidateItemS(lstTag, bLsOpc);
        }

		public bool Run()
		{
			if (m_bReady == false)
				return false;

			bool bOK = false;

			try
			{
				COPCGroup cOPCGroup;
				for (int i = 0; i < this.Count; i++)
				{
					cOPCGroup = (COPCGroup)this.ElementAt(i).Value;
					cOPCGroup.UEventValueChanged += new UEventHandlerMonitorValueChanged(cGroup_UEventValueChanged);
					bOK = cOPCGroup.Run();
					
					if (!bOK)
						break;
				}

				bOK = true;
			}
			catch(System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			return bOK;
		}

		public bool Stop()
		{
			if (m_bReady == false)
				return false;

			bool bOK = false;

			try
			{
				COPCGroup cOPCGroup;
				for (int i = 0; i < this.Count; i++)
				{
					cOPCGroup = (COPCGroup)this.ElementAt(i).Value;
					cOPCGroup.UEventValueChanged -= new UEventHandlerMonitorValueChanged(cGroup_UEventValueChanged);
					bOK = cOPCGroup.Stop();

					if (!bOK)
						break;
				}

				bOK = true;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			return bOK;
		}

        public CTimeLogS ReadInstant(List<CTag> lstTag, bool bLsOpc)
		{
			if (m_bReady == false)
				return null;

			if (lstTag == null || lstTag.Count == 0)
				return new CTimeLogS();

			COPCGroup cOPCGroup = this["ForInstant"];
			CTimeLogS cLogS = cOPCGroup.ReadInstant(lstTag, bLsOpc);

			return cLogS;
		}

		public new void Clear()
		{
			if (m_bReady == false)
				return;

			try
			{
				if (m_exOPCGroupS != null)
				{
					m_exOPCGroupS.RemoveAll();
					m_exOPCGroupS = null;
				}

				base.Clear();
			}
			catch(System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		#endregion


		#region Private Methods

		protected bool Initialize(OPCAutomation.OPCServer exOPCServer, int iUpdateRate)
		{
			bool bOK = false;

			try
			{
				Clear();

				m_exOPCGroupS = (OPCAutomation.OPCGroups)exOPCServer.OPCGroups;
				if (m_exOPCGroupS == null)
					return false;

				m_exOPCGroupS.DefaultGroupIsActive = true;
				m_exOPCGroupS.DefaultGroupUpdateRate = iUpdateRate;
				m_exOPCGroupS.DefaultGroupDeadband = (float)0;

				//Add Instant Read Group Initially
				COPCGroup cOPCInstantGroup = new COPCGroup("ForInstant", m_exOPCGroupS, iUpdateRate, false);
				bOK = cOPCInstantGroup.IsReady;
				if (bOK)
					this.Add("ForInstant", cOPCInstantGroup);
				else
					return false;

				//Add Event Read Group Initially
				COPCGroup cOPCEventGroup = new COPCGroup("ForEvent", m_exOPCGroupS, iUpdateRate, true);
				bOK = cOPCEventGroup.IsReady;
				if (bOK)
					this.Add("ForEvent", cOPCEventGroup);
				else
					return false;

				bOK = true;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			return bOK;
		}


		protected void GenerateValueChangeEvent(CTimeLogS cLogS)
		{
			if (UEventValueChanged != null)
				UEventValueChanged(this, cLogS);
		}

		#endregion


		#region Event Methods

		private void cGroup_UEventValueChanged(object sender, CTimeLogS cLogS)
		{
			GenerateValueChangeEvent(cLogS);
		}

		#endregion
	}
}
