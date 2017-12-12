using System;
using System.Collections.Generic;
using UDM.Common;
using UDM.DDEA;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.DDEA
{
    public class CDDEAServer : CMonitorServerBase
    {

        #region Member Variables

		protected CTagS m_cTagS = new CTagS();
		protected UDM.General.Remote.CClient<IMyService, CMyServiceCallBack> m_cClient = null;

        public event UEventHandlerMonitorValueChanged UEventValueChanged;

		#endregion


        #region Intialize/Dispose

        public CDDEAServer()
        {

        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

		public override bool Connect()
        {
            bool bOK = true;

            try
            {
                if (m_cClient == null)
                    m_cClient = new UDM.General.Remote.CClient<IMyService, CMyServiceCallBack>("UDMMonitor");

                if (m_cClient.IsConnected == false)
                    bOK = m_cClient.Connect();     
           
                if(bOK)
                {
                    m_bConnect = true;
                    m_cClient.ServiceCallBack.UEventTerminated += new EventHandler(ServiceCallBack_UEventTerminated);
                }                    
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }


            if (bOK == false)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect DDEA", "MonitorSource", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bOK;
        }

		public override bool Disconnect()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return true;
            
            m_cClient.ServiceCallBack.UEventTerminated -= new EventHandler(ServiceCallBack_UEventTerminated);
            m_cClient.Disconnect();
            m_cClient.Dispose();
            m_cClient = null;

            m_bConnect = false;

            return true;
        }

		public override bool AddItemS(List<CTag> lstTag)
		{
			if (m_cClient == null || m_cClient.IsConnected == false)
				return false;

			bool bOK = true;

			List<string> lstAddItem = new List<string>();

			string sItem;
			CTag cTag = null;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];
				if (m_cTagS.ContainsKey(cTag.Key) == false)
				{
					sItem = CreateItem(cTag);
					if (sItem != "")
						lstAddItem.Add(sItem);
				}
			}

			if (lstAddItem.Count == 0)
				return true;

			string[] saData = lstAddItem.ToArray();
			lstAddItem.Clear();

			m_cClient.Service.AddItems(saData);

			return bOK;
		}

		public override bool RemoveItemS(List<CTag> lstTag)
		{
			if (m_cClient == null || m_cClient.IsConnected == false)
				return false;

			bool bOK = true;

			CTag cTag = null;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];
				if (m_cTagS.ContainsKey(cTag.Key))
					m_cTagS.Remove(cTag.Key);
			}

			return bOK;
		}

        public override List<string> ValidateItemS(List<CTag> lstTag)
        {
            return null;
        }

		public override bool Run()
        {   
            if (m_cClient == null || m_cClient.IsConnected == false)
                return false;

            if (m_cTagS == null)
                return false;

            bool bOK = true;

            try
            {
                m_cClient.ServiceCallBack.UEventLogDataRecieved += new UDM.DDEA.UEventHandlerLogDataRecieved(ServiceCallBack_UEventLogDataRecieved);

                
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            if (bOK == false)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect DDEA", "DDEAServer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bOK;
        }

		public override bool Stop()
		{
			if (m_cClient == null || m_cClient.IsConnected == false)
				return true;

			m_cClient.ServiceCallBack.UEventLogDataRecieved -= new UDM.DDEA.UEventHandlerLogDataRecieved(ServiceCallBack_UEventLogDataRecieved);

			return true;
		}

		public override CTimeLogS ReadInstant(List<CTag> lstTag)
		{
			if (m_cClient == null || m_cClient.IsConnected == false)
				return null;

			if (lstTag == null)
				return null;

			CTimeLogS cLogS = new CTimeLogS();

			try
			{
				string[] saData = CreateItems(lstTag);
				string[] saLogData = m_cClient.Service.ReadInstant(saData);
				if (saLogData != null)
				{
					CTimeLog cLog = null;
					for (int i = 0; i < saLogData.Length; i++)
					{
						cLog = CreateTimeLog(saLogData[i]);

						if (cLog != null)
							cLogS.Add(cLog);
					}
				}
			}
			catch (System.Exception ex)
			{
				ex.Data.Clear();
			}

			return cLogS;
		}

		public override void Clear()
		{
			if (m_cTagS != null)
				m_cTagS.Clear();
		}

        #endregion


        #region Private Methods

		private string CreateItem(CTag cTag)
		{
			if (cTag.Address.Trim() == "")
				return "";

			string sLine = cTag.Key + "," + cTag.Address + "," + cTag.Size.ToString();

			return sLine;
		}

		private string[] CreateItems(List<CTag> lstTag)
		{
			List<string> lstItem = new List<string>();

			CTag cTag;
			string sLine;
			for (int i = 0; i < lstTag.Count; i++)
			{
				cTag = lstTag[i];
				sLine = CreateItem(cTag);
				if (sLine != "")
					lstItem.Add(sLine);
			}

			if (lstItem.Count == 0)
				return null;

			string[] saData = lstItem.ToArray();
			lstItem.Clear();

			return saData;
		}

        private CTimeLog CreateTimeLog(string sLine)
        {
            string[] saData = sLine.Split(',');
            if (saData.Length < 3)
                return null;

            int iValue = -1;
            CTimeLog cLog = new CTimeLog();
            cLog.Time = UDM.General.CTypeConverter.ToDateTime(saData[0]);
            cLog.Key = saData[1];

            if (int.TryParse(saData[2], out iValue))
                cLog.Value = iValue;
            else
                cLog.SValue = saData[2];

            return cLog;
        }

        private int[] ToValueArray(string sValue)
        {
            string[] saValue = sValue.Split('|');
            int iLength = saValue.Length;

            int[] iaValue = new int[iLength];

            for (int i = 0; i < iLength; i++)
            {
                iaValue[i] = UDM.General.CTypeConverter.ToInteger(saValue[i]);
            }

            return iaValue;
        }

        private void GenerateValueChangeEvent(CTimeLogS cLogS)
        {
            if (UEventValueChanged != null)
                UEventValueChanged(this, cLogS);
        }

        #endregion


        #region Event Methods

        private void ServiceCallBack_UEventTerminated(object sender, EventArgs e)
        {
			GenerateServerTerminateEvent();
        }

        private void ServiceCallBack_UEventLogDataRecieved(object sender, string[] saData)
        {
            if (saData != null)
            {
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLog cLog = null;

                for (int i = 0; i < saData.Length; i++)
                {
                    cLog = CreateTimeLog(saData[i]);

                    if (cLog != null)
                        cLogS.Add(cLog);
                }

                GenerateValueChangeEvent(cLogS);
            }
        }

        #endregion
    }
}
