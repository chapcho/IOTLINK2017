using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

using XGCommLib;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc.Source.LS
{
    public class CLsReader : IDisposable
	{

		#region Member Variables

        protected bool m_bConnected = false;
        protected bool m_bRun = false;
        protected byte[] m_byaBuffer = null;
        protected int m_iScanTime = -1;

        protected CLsConfig m_cConfig = new CLsConfig();
        private CLsPacketS m_cPacketS = null;
        protected Thread m_Thread = null;
        protected CommObjectFactory m_exFactory = null;
        protected CommObject m_exComm = null;

		public event UEventHandlerMonitorValueChanged UEventValueChanged = null;

		#endregion


		#region Intialize/Dispose

		public CLsReader()
		{

		}

		public void Dispose()
		{
			if (m_bRun)
				Stop();

			if (m_bConnected)
				Disconnect();
		}

		#endregion


		#region Public Properties

        public bool IsConnected
        {
            get { return m_bConnected; }
        }

        public bool IsRuning
        {
            get { return m_bRun; }
        }

        public CLsConfig Config
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

		#endregion


		#region Public Methods

        public bool Connect()
        {
            if (m_bConnected)
                return true;

            if (m_cConfig == null)
                return false;

            bool bOK = false;
            if (m_cConfig.InterfaceType == EMLsInterfaceType.USB)
            {
                bOK = ConnectUSB();
            }
            else if (m_cConfig.InterfaceType == EMLsInterfaceType.Ethernet)
            {
                if (m_cConfig.IP.Trim() != "" && m_cConfig.Port.Trim() != "")
                    bOK = ConnectEthernet(m_cConfig.IP + ":" + m_cConfig.Port);
            }

            return bOK;

        }

        public bool Disconnect()
        {
            if (m_bConnected == false)
                return true;
            try
            {
                m_exComm.Disconnect();

                m_exComm = null;
                m_exFactory = null;

                m_bConnected = false;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return m_bConnected;
        }

		public bool AddItemS(List<CTag> lstTag)
		{
			if (m_bConnected == false)
				return false;

			if (m_bRun)
				return false;

			if (InitPacketS(lstTag) == false)
				return false;

			if (AddExItems(m_cPacketS) == false)
				return false;

			return true;
		}

		public bool Run()
		{
			if (m_bConnected == false || m_cPacketS == null || m_cPacketS.Count == 0)
				return true;

			bool bOK = false;

			try
			{
				if (m_bRun)
					Stop();

				ThreadStart cThreadInfo = new ThreadStart(DoWork);
				m_Thread = new Thread(cThreadInfo);
				m_Thread.Start();

				m_bRun = true;

				bOK = true;
			}
			catch(System.Exception ex)
			{
				ex.Data.Clear();
			}

			return bOK;
		}

		public bool Stop()
		{
			if (m_bRun == false)
				return true;

			try
			{
				m_bRun = false;
				m_Thread.Join(1000);

				while (m_Thread.IsAlive)
				{
					m_Thread.Abort();
					Thread.Sleep(10);
				}
			}
			catch(System.Exception ex)
			{
				ex.Data.Clear();
			}

			return true;
		}

		public int GetWordSize(List<CTag> lstTag)
		{
			CLsPacketS cPacketS = new CLsPacketS(lstTag);
			if (m_cPacketS == null)
				return 0;

			int iSize = (int)(cPacketS.BufferSize / 2);

			return iSize;
		}

		#endregion


		#region Private Methods

        protected bool ConnectUSB()
        {
            try
            {
                m_exFactory = new CommObjectFactory();
                m_exComm = m_exFactory.GetUSBCommObject("");
                int iResult = m_exComm.Connect();

                if (iResult == 1)
                    m_bConnected = true;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return m_bConnected;
        }

        protected bool ConnectEthernet(string sIPAddress)
        {
            try
            {
                m_exFactory = new CommObjectFactory();
                m_exComm = m_exFactory.GetMLDPCommObject(sIPAddress);

                int iResult = m_exComm.Connect();
                if (iResult == 1)
                    m_bConnected = true;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return m_bConnected;
        }

		private bool InitPacketS(List<CTag> lstTag)
		{
			m_iScanTime = -1;
			if (m_cPacketS != null)
				m_cPacketS.Clear();

			m_cPacketS = new CLsPacketS(lstTag);
			if (m_cPacketS == null || m_cPacketS.Count == 0)
				return false;

			m_byaBuffer = new byte[m_cPacketS.BufferSize];

			return true;
		}

		private bool AddExItems(CLsPacketS cPacketS)
		{
			m_exComm.RemoveAll();

			DeviceInfo cInfo = m_exFactory.CreateDevice();
			cInfo.ucDataType = (byte)'B';

			CLsPacket cPacket;
			for (int i = 0; i < cPacketS.Count; i++)
			{
				cPacket = cPacketS[i];
				cInfo.ucDeviceType = (byte)(cPacket.Header[0]);
				cInfo.lOffset = cPacket.AddressIndex * 2 ;
				cInfo.lSize = cPacket.BufferSize;

				m_exComm.AddDeviceInfo(cInfo);
			}

			return true;
		}

		private void DoWork()
		{
			Stopwatch cWatch = new Stopwatch();

			List<CLsSymbol> lstSymbol = null;
			while (m_bRun)
			{
				cWatch.Reset();
				cWatch.Start();
				{
					lstSymbol = ReadPacketS(m_cPacketS);
					if (lstSymbol != null && lstSymbol.Count > 0)
					{
						GenerateValueChangedEvent(lstSymbol);
						lstSymbol.Clear();
						lstSymbol = null;
					}

					Thread.Sleep(m_cConfig.Interval);
				}
				cWatch.Stop();
				m_iScanTime = (int)cWatch.ElapsedMilliseconds;
			}
		}

		private List<CLsSymbol> ReadPacketS(CLsPacketS cPacketS)
		{
			List<CLsSymbol> lstSymbolChanged = new List<CLsSymbol>();

            try
            {
                int iResult = m_exComm.ReadRandomDevice(m_byaBuffer);
                if (iResult == 1)
                {
                    List<CLsSymbol> lstSymbol = null;
                    CLsPacket cPacket;
                    int iValue = 0;
                    for (int i = 0; i < cPacketS.Count; i++)
                    {
                        iValue = 0;
                        cPacket = cPacketS[i];
                        for (int j = cPacket.BufferIndex + cPacket.BufferSize - 1; j > cPacket.BufferIndex - 1; j--)
                        {
                            iValue = iValue << 8;
                            iValue = iValue + m_byaBuffer[j];
                        }

                        lstSymbol = cPacket.UpdateValue(iValue);

                        if (lstSymbol != null && lstSymbol.Count > 0)
                            lstSymbolChanged.AddRange(lstSymbol);
                    }
                }
            }
            catch(System.Exception ex)
            {
                ex.Data.Clear();
                lstSymbolChanged = null;
            }

			return lstSymbolChanged;
		}

		private void GenerateValueChangedEvent(List<CLsSymbol> lstSymbol)
		{	
			if (UEventValueChanged != null)
			{
				DateTime dtTime = DateTime.Now;

				CTimeLogS cLogS = new CTimeLogS();
				CTimeLog cLog;

				CLsSymbol cSymbol;
				for(int i=0;i<lstSymbol.Count;i++)
				{
					cSymbol = lstSymbol[i];

					cLog = new CTimeLog(cSymbol.Key);
					cLog.Time = dtTime;
					cLog.Value = cSymbol.Value;

					cLogS.Add(cLog);
				}

				UEventValueChanged(this, cLogS);
			}
		}

		#endregion
	}
}
