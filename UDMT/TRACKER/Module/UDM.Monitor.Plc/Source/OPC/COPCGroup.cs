using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.OPC
{
    public class COPCGroup : IDisposable
    {

        #region Member Variables

		protected string m_sKey = "";
		protected bool m_bReady = false;
		protected bool m_bUseEvent = true;
		protected bool m_bFirstEvent = true;		
		protected COPCItemS m_cOPCItemS = null;

		protected OPCAutomation.OPCGroup m_exOPCGroup = null;

        public event UEventHandlerMonitorValueChanged UEventValueChanged;

        #endregion


        #region Initialize/Dispose

		public COPCGroup(string sKey, OPCAutomation.OPCGroups exOPCGroupS, int iUpdateRate, bool bUseEvent)
        {
			m_sKey = sKey;
			m_bUseEvent = bUseEvent;
			m_bReady = Initialize(exOPCGroupS, iUpdateRate);
        }

        public void Dispose()
        {
            Stop();
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

            bool bOK = m_cOPCItemS.AddItemS(lstTag, bLsOpc);
			if (bOK == false)
				m_cOPCItemS.Clear();

			return bOK;
		}

		public bool RemoveItemS(List<CTag> lstTag, bool bLsOpc)
		{
			if (m_bReady == false)
				return false;

            return m_cOPCItemS.RemoveItemS(lstTag, bLsOpc);
		}

        public List<string> ValidateItemS(List<CTag> lstTag, bool bLsOpc)
        {
            if (m_bReady == false)
                return null;

            return m_cOPCItemS.ValidateItemS(lstTag, bLsOpc);
        }
		
        public bool Run()
		{
			if (m_bReady == false)
				return false;

			m_bFirstEvent = true;

			if(m_bUseEvent)
				m_exOPCGroup.DataChange += new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(m_exOPCGroup_DataChange);

			return true;
		}

		public bool Stop()
		{
			if (m_bReady == false)
				return false;

			if(m_bUseEvent)
				m_exOPCGroup.DataChange -= new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(m_exOPCGroup_DataChange);

			return true;
		}

        public CTimeLogS ReadInstant(List<CTag> lstTag, bool bLsOpc)
		{
			if (m_bReady == false)
				return null;

			List<COPCItem> lstOPCItem = m_cOPCItemS.AddInstantItemS(lstTag, bLsOpc);
			if (lstOPCItem == null)
				return null;

			CTimeLogS cLogS = new CTimeLogS();

			try
			{
				Array arServerHandle = GetServerHandleArray(lstOPCItem);
				Array arValue = null;
				Array arResult = null;
				object oQuality = null;
				object oTimeStamp = null;
				
				m_exOPCGroup.SyncRead((short)OPCAutomation.OPCDataSource.OPCDevice, lstOPCItem.Count, ref arServerHandle, out arValue, out arResult, out oQuality, out oTimeStamp);

				DateTime dtNow = DateTime.Now;

				COPCItem cItem;
				object oValue;
				int iResult = 0;
				for(int i=0;i<lstOPCItem.Count;i++)
				{
					cItem = lstOPCItem[i];

					iResult = (int)arResult.GetValue(i + 1);
					if(iResult == 0)
					{
						oValue = arValue.GetValue(i + 1);
						if (oValue != null)
						{
							CTimeLog cLog = new CTimeLog(cItem.TagKey);
							cLog.Time = dtNow;
							cLog.Value = GetValue(oValue);
							cLogS.Add(cLog);
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			m_cOPCItemS.RemoveInstantItemS(lstOPCItem);

			return cLogS;
		}

		public void Clear()
		{
			if (m_bReady == false)
				return;

			if (m_cOPCItemS != null)
				m_cOPCItemS.Clear();

			m_exOPCGroup = null;
			m_cOPCItemS = null;
		}

        #endregion


        #region Private Methods

		protected bool Initialize(OPCAutomation.OPCGroups exOPCGroupS, int iUpdateRate)
		{
			bool bOK = false;

			try
			{
				Clear();

				m_exOPCGroup = exOPCGroupS.Add(m_sKey);
				if (m_exOPCGroup != null)
				{
					m_exOPCGroup.IsSubscribed = true;
					m_exOPCGroup.IsActive = true;
					m_exOPCGroup.UpdateRate = iUpdateRate;
					m_exOPCGroup.DeadBand = (float)0;

					if (m_cOPCItemS == null)
						m_cOPCItemS = new COPCItemS(m_exOPCGroup);

					bOK = m_cOPCItemS.IsReady;
					if (bOK == false)
						m_cOPCItemS = null;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			return bOK;
		}

		private Array GetServerHandleArray(List<COPCItem> lstItem)
		{
			Array arHandles = Array.CreateInstance(typeof(int), lstItem.Count + 1);
			arHandles.SetValue(0, 0);

			for (int i = 0; i < lstItem.Count; i++)
				arHandles.SetValue(lstItem[i].ServerHandle, i + 1);

			return arHandles;
		}

		private void GenerateValueChangeEvent(CTimeLogS cLogS)
		{
			if (UEventValueChanged != null)
				UEventValueChanged(this, cLogS);
		}

		private int GetValue(object oValue)
		{	
			int iValue = -1;

			string sValue = oValue.ToString();
			if (sValue == "True" || sValue == "true")
				iValue = 1;
			else if (sValue == "False" || sValue == "false")
				iValue = 0;
			else
				iValue = Convert.ToInt32(sValue);

			return iValue;
		}

        #endregion


        #region Event Methods

        private void m_exOPCGroup_DataChange(int iTransactionID, int iCount, ref System.Array arClientHandles, ref System.Array arItemValues, ref System.Array arItemQuality, ref System.Array arTimeStamp)
        {
			if (m_exOPCGroup == null || m_cOPCItemS == null)
				return;

            if (m_bFirstEvent)
            {
                m_bFirstEvent = false;
                return;
            }

            try
            {   
				string sKey = "";
                object oValue = 0;
				int iHandle = 0;
                CTimeLogS cLogS = new CTimeLogS();
                for (int i = 0; i < iCount; i++)
                {
                    iHandle = (int)arClientHandles.GetValue(i + 1);
					sKey = m_cOPCItemS.GetHandleKey(iHandle);
					if(sKey != "")
					{
						oValue = (object)arItemValues.GetValue(i + 1);
						if (oValue != null)
						{
							CTimeLog cLog = new CTimeLog(sKey);
							cLog.Time = ((DateTime)arTimeStamp.GetValue(i + 1)).ToLocalTime();
							cLog.Value = GetValue(oValue);
							cLogS.Add(cLog);
						}
					}
                }

				GenerateValueChangeEvent(cLogS);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion
    }
}
