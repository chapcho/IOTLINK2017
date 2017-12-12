using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.OPC
{
    public class COPCServer : CMonitorServerBase
    {

        #region Public Member

        protected COPCConfig m_cConfig = new COPCConfig();
		protected COPCGroupS m_cOPCGroupS = null;

        protected OPCAutomation.OPCServer m_exOPCServer = null;

        public event UEventHandlerMonitorValueChanged UEventValueChanged;

        //private Array m_aPropDataType = null;
        //private Array m_aPropAddress = null;
        //private Array m_aPropDescription = null;

        #endregion 


        #region Initialize/Dispose

        public COPCServer()
        {
            try
            {
                m_exOPCServer = new OPCAutomation.OPCServer();
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }            
        }

        public new void Dispose()
        {
            if (m_bRun)
                Stop();

            if (m_bConnect)
                Disconnect();

            Clear();
        }

        #endregion


        #region Pubilc Properties

        public COPCConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        #endregion


        #region Public Methods

        public override bool Connect()
        {
            if (m_cConfig.Use == false)
                return false;

            bool bOK = true;

			try
			{
				Clear();

				if (m_cConfig == null || m_cConfig.ServerName == "")
					return false;

				if (m_exOPCServer == null)
					m_exOPCServer = new OPCAutomation.OPCServer();

				m_exOPCServer.Connect(m_cConfig.ServerName, (string)"");

				if (m_cOPCGroupS == null)
					m_cOPCGroupS = new COPCGroupS(m_exOPCServer, m_cConfig.UpdateRate);

				bOK = m_cOPCGroupS.IsReady;
                m_bConnect = true;

                if (bOK == false)
                    Disconnect();
			}
			catch (System.Exception ex)
			{
				bOK = false;
				Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

            return bOK;
        }

		public override bool Disconnect()
        {
			if (m_bConnect == false)
				return false;

            bool bOK = false;

            try
            {
				Clear();

				m_exOPCServer.Disconnect();
				m_exOPCServer = null;

				m_bConnect = false;
				bOK = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return bOK;
        }

		public override bool AddItemS(List<CTag> lstTag)
		{
			if (m_bConnect == false)
				return false;

            bool bOK = m_cOPCGroupS.AddItemS(lstTag, m_cConfig.LsOpc);

			return bOK;
		}

		public override bool RemoveItemS(List<CTag> lstTag)
		{
			if (m_bConnect == false)
				return false;

            bool bOK = m_cOPCGroupS.RemoveItemS(lstTag, m_cConfig.LsOpc);

			return bOK;
		}
        
        public override List<string> ValidateItemS(List<CTag> lstTag)
        {
            if (m_bConnect == false)
                return null;

            return m_cOPCGroupS.ValidateItemS(lstTag, m_cConfig.LsOpc);
        }

		public override bool Run()
        {
            if (m_cConfig.Use == false)
                return false;

			if (m_exOPCServer == null || m_cOPCGroupS == null || m_cOPCGroupS.IsReady == false)
				return false;

            bool bOK = false;

            try
            {
				bOK = m_cOPCGroupS.Run();
                if (bOK)
                {   
                    m_cOPCGroupS.UEventValueChanged += m_cOPCGroupS_UEventValueChanged;
                    m_bRun = true;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

		public override bool Stop()
        {
			if (m_cConfig.Use == false)
				return false;

			if (m_exOPCServer == null || m_cOPCGroupS == null || m_cOPCGroupS.IsReady == false)
				return false;

            bool bOK = true;
            if (m_bRun == false)
                return true;

            try
            {
                m_cOPCGroupS.UEventValueChanged -= m_cOPCGroupS_UEventValueChanged;
				bOK = m_cOPCGroupS.Stop();

                m_bRun = false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = true;
            }

            return bOK;
        }

		public override CTimeLogS ReadInstant(List<CTag> lstTag)
		{
			if (m_cConfig.Use == false)
                return null;

			if (m_exOPCServer == null || m_cOPCGroupS == null || m_cOPCGroupS.IsReady == false)
				return null;

            CTimeLogS cLogS = m_cOPCGroupS.ReadInstant(lstTag, m_cConfig.LsOpc);

			return cLogS;
		}

		public override void Clear()
        {
			if (m_cOPCGroupS != null)
				m_cOPCGroupS.Clear();

			m_cOPCGroupS = null;
        }

        public List<string> GetOPCServerList()
        {
            if (m_exOPCServer == null)
                return null;

            List<string> lstServer = new List<string>();

            try
            {
				object oList = m_exOPCServer.GetOPCServers();
				if (oList == null)
					return null;

				Array array = (Array)oList;
				object oServer;
				string sServer;
				for(int i=0;i<array.Length;i++)
				{
					sServer = "";
					oServer = array.GetValue(i + 1);
					if (oServer != null)
						sServer = oServer.ToString().Trim();

					if(sServer != "")
						lstServer.Add(sServer);
				}	
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            
            return lstServer;
        }

        public List<string> GetChannelList(string sServer)
        {
            if (sServer == "") return null;

            sServer = sServer.Trim();
            
            List<string> lstResult = new List<string>();
            try
            {
                m_exOPCServer.Connect(sServer);
                OPCAutomation.OPCBrowser browser = m_exOPCServer.CreateBrowser();
                browser.ShowBranches();
                browser.ShowLeafs(true);
                List<string> lstBuf = new List<string>();
                foreach (object fqs in browser)     // fqs = fully qualiified symbol name
                {
                    string[] tok = ((string)fqs).Split('.');
                    string branch = string.Join(".", tok, 0, tok.Length - 1);
                    if (lstBuf.Contains(branch) == false)
                        lstBuf.Add(branch);
                }
                lstResult = lstBuf.Where(b => !b.Contains("_Hints") && !b.Contains("_System") && !b.Contains("_DataLogger")).ToList();
                m_exOPCServer.Disconnect();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return lstResult;
        }

        public Dictionary<string, List<string>> GetOPCChannelList()
        {
            if (m_exOPCServer == null)
                return null;

            Dictionary<string, List<string>> lstChannel = new Dictionary<string,List<string>>();

            try
            {
                object oList = m_exOPCServer.GetOPCServers();
                if (oList == null)
                    return null;

                Array array = (Array)oList;
                object oServer;
                string sServer;
                for (int i = 0; i < array.Length; i++)
                {
                    sServer = "";
                    oServer = array.GetValue(i + 1);
                    if (oServer != null)
                        sServer = oServer.ToString().Trim();

                    if (sServer != "")
                    {
                        
                        try
                        {
                            m_exOPCServer.Connect(sServer);
                            OPCAutomation.OPCBrowser browser = m_exOPCServer.CreateBrowser();
                            browser.ShowBranches();
                            browser.ShowLeafs(true);
                            List<string> lstBuf = new List<string>();
                            foreach (object fqs in browser)     // fqs = fully qualiified symbol name
                            {
                                string[] tok = ((string)fqs).Split('.');
                                string branch = string.Join(".", tok, 0, tok.Length - 1);
                                if (lstBuf.Contains(branch) == false)
                                    lstBuf.Add(branch);
                            }
                            lstChannel[sServer] = lstBuf.Where(b => !b.Contains("_Hints") && !b.Contains("_System") && !b.Contains("_DataLogger")).ToList();
                            m_exOPCServer.Disconnect();
                            lstChannel.Add(sServer, new List<string>());
                        }
                        catch(Exception ex)
                        {
                            ex.Data.Clear();
                        }
                        

                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return lstChannel;
        }


        #endregion


        #region Prvate Methods

        private void GenerateValueChangeEvent(CTimeLogS cLogS)
        {
            if (UEventValueChanged != null)
                UEventValueChanged(this, cLogS);
        }
		//private bool GetOPCItemProperty(string sOPCItemID, out EMDataType emDataType, out string sAddress, out string sDescription)
		//{
		//	Array aPropertyValues;
		//	Array aErrors;

		//	bool bOK = true;

		//	try
		//	{
		//		if (m_aPropDescription == null)
		//		{
		//			//----------------------------For Getting OPCItemProperty--------------//
		//			int iPropertyCount = 0;
		//			string sPropertyValue = "";

		//			Array arProperties;
		//			Array arDescriptions;
		//			Array arDataType;

		//			m_exOPCServer.QueryAvailableProperties(sOPCItemID, out iPropertyCount, out arProperties, out arDescriptions, out arDataType);

		//			for (int i = 0; i < iPropertyCount; i++)
		//			{
		//				sPropertyValue = (string)arDescriptions.GetValue(i + 1);

		//				if (sPropertyValue.Contains("Type"))
		//				{
		//					int[] ai = new int[2];
		//					ai[0] = 0;
		//					ai[1] = (int)arProperties.GetValue(i + 1);

		//					m_aPropDataType = ai.ToArray();
		//				}
		//				else if (sPropertyValue.Contains("Address"))
		//				{
		//					int[] ai = new int[2];
		//					ai[0] = 0;
		//					ai[1] = (int)arProperties.GetValue(i + 1);

		//					m_aPropAddress = ai.ToArray();
		//				}
		//				else if (sPropertyValue.Contains("Description"))
		//				{
		//					int[] ai = new int[2];
		//					ai[0] = 0;
		//					ai[1] = (int)arProperties.GetValue(i + 1);

		//					m_aPropDescription = ai.ToArray();
		//				}
		//			}
		//			//-------------------------------------------------------------//

		//		}

		//		short iDataType;

		//		m_exOPCServer.GetItemProperties(sOPCItemID, 1, ref m_aPropDataType, out aPropertyValues, out aErrors);
		//		iDataType = (short)aPropertyValues.GetValue(1);
		//		emDataType = (EMDataType)iDataType;

		//		if (m_aPropAddress != null)
		//		{
		//			m_exOPCServer.GetItemProperties(sOPCItemID, 1, ref m_aPropAddress, out aPropertyValues, out aErrors);
		//			sAddress = (string)aPropertyValues.GetValue(1);
		//		}
		//		else
		//			sAddress = string.Empty;

		//		m_exOPCServer.GetItemProperties(sOPCItemID, 1, ref m_aPropDescription, out aPropertyValues, out aErrors);
		//		sDescription = (string)aPropertyValues.GetValue(1);

		//		if (!IsHangul(sDescription))
		//			sDescription = ConvertEncoding(sDescription);

		//		sDescription = ModifyIllegalName(sDescription);

		//	}
		//	catch (System.Exception ex)
		//	{
		//		Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();

		//		emDataType = EMDataType.Bool;
		//		sAddress = "";
		//		sDescription = "";

		//		bOK = false;
		//	}

		//	return bOK;
		//}

        #endregion


        #region Event Methods

        private void m_cOPCGroupS_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
			GenerateValueChangeEvent(cLogS);
        }


        #endregion

    }
}
