using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace FTOPApp
{
	public class COPCGroupS : Dictionary<string, COPCGroup>, IDisposable
	{

		#region Member Variables

		protected bool m_bReady = false;

        public OPCAutomation.OPCGroups m_exOPCGroupS = null;

        public event UEventHandlerValueChanged UEventValueChanged;

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

        public bool AddItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return false;

			if (lstTag == null || lstTag.Count == 0)
				return true;

			COPCGroup cOPCGroup = this["ForEvent"];
			bool bOK = cOPCGroup.AddItemS(lstTag, bLsOpc, bABOpc);

			return bOK;
		}

        public bool RemoveItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return false;

			if (lstTag == null || lstTag.Count == 0)
				return true;

			COPCGroup cOPCGroup = this["ForEvent"];
            bool bOK = cOPCGroup.RemoveItemS(lstTag, bLsOpc, bABOpc);

			return bOK;
		}

        public List<string> ValidateItemS(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
        {
            if (m_bReady == false)
                return null;

            if (lstTag == null || lstTag.Count == 0)
                return null;

            COPCGroup cOPCGroup = this["ForEvent"];
            return cOPCGroup.ValidateItemS(lstTag, bLsOpc, bABOpc);
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
                    cOPCGroup.UEventValueChanged += new UEventHandlerValueChanged(cGroup_UEventValueChanged);
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
                    cOPCGroup.UEventValueChanged -= new UEventHandlerValueChanged(cGroup_UEventValueChanged);
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

        public List<FTag> ReadInstant(List<FTOPTagFull> lstTag, bool bLsOpc, bool bABOpc)
		{
			if (m_bReady == false)
				return null;

			if (lstTag == null || lstTag.Count == 0)
                return new List<FTag>();

			COPCGroup cOPCGroup = this["ForEvent"];
            List<FTag> cLogS = cOPCGroup.ReadInstant(lstTag, bLsOpc, bABOpc);

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


        protected void GenerateValueChangeEvent(DateTime makeTime, string key, object value)
		{
			if (UEventValueChanged != null)
                UEventValueChanged(makeTime, key, value);
		}

		#endregion


		#region Event Methods

        private void cGroup_UEventValueChanged(DateTime makeTime, string key, object value)
		{
            GenerateValueChangeEvent(makeTime, key, value);
		}

		#endregion
	}
}
