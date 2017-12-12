using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Monitor.Plc.Source.DDEA;
using UDM.Monitor.Plc.Source.OPC;
using UDM.Monitor.Plc.Source.LS;
using UDM.Monitor.Plc.Source.Simulator;
using System.Windows.Forms;

namespace UDM.Monitor.Plc.Source
{   
    public class CMonitorSource : IDisposable
    {

        #region Member Variables

        private bool m_bRun = false;        
        private CTagS m_cTagS = null;
        private EMSourceType m_emSouceType = EMSourceType.OPC;

        private CDDEAServer m_cDDEAServer = new CDDEAServer();

		private COPCServer m_cOPCServer = null;
        private COPCConfig m_cOPCConfig = new COPCConfig();

		private CLsReader m_cLsReader = null;
		private CLsConfig m_cLsConfig = new CLsConfig();

		private CSimulator m_cSimulator = null;        
        private CSimulatorConfig m_cSimulatorConfig = new CSimulatorConfig();        

        public event EventHandler UEventTerminated;
        public event UEventHandlerMonitorValueChanged UEventValueChanged;

        #endregion


        #region Initialize/Dispose

        public CMonitorSource()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        public EMSourceType SourceType
        {
            get { return m_emSouceType; }
            set { m_emSouceType = value; }
        }

        public COPCServer OPCServer
        {
            get { return m_cOPCServer; }
        }

        public COPCConfig OPCConfig
        {
            get { return m_cOPCConfig; }
            set { m_cOPCConfig = value; }
        }

		public CLsConfig LsConfig
		{
			get { return m_cLsConfig; }
			set { m_cLsConfig = value; }
		}

        public CSimulatorConfig SimulatorConfig
        {
            get { return m_cSimulatorConfig; }
            set { m_cSimulatorConfig = value; }
        }        

        #endregion


        #region Public Methods

        public bool Run()
        {
            Stop();

            bool bOK = true;

            if (m_emSouceType == EMSourceType.DDEA)
            {
                bOK = RunDDEA();
            }
            else if (m_emSouceType == EMSourceType.OPC)
            {
                bOK = RunOPC();
            }
			else if (m_emSouceType == EMSourceType.LS)
			{
				bOK = RunLS();
			}
            else if (m_emSouceType == EMSourceType.Simulator)
            {
                bOK = RunSimulator();
            }
			
            m_bRun = bOK;

            return bOK;
        }

        public void Stop()
        {
			if (m_emSouceType == EMSourceType.DDEA)
				StopDDEA();
			else if (m_emSouceType == EMSourceType.OPC)
				StopOPC();
			else if (m_emSouceType == EMSourceType.LS)
				StopLS();
			else if (m_emSouceType == EMSourceType.Simulator)
				StopSimulator();

            m_bRun = false;
        }

        public CTimeLogS ReadInstant(List<CTag> lstTag)
        {
			if (m_bRun == false)
				return null;

			if (m_emSouceType == EMSourceType.Simulator)
				return null;

			if (m_emSouceType == EMSourceType.LS)
				return null;

			CTimeLogS cLogS = null;
			if (m_emSouceType == EMSourceType.DDEA && m_cDDEAServer.IsConnected)
				cLogS = m_cDDEAServer.ReadInstant(lstTag);
			else if (m_emSouceType == EMSourceType.OPC && m_cOPCServer.IsConnected)
				cLogS = m_cOPCServer.ReadInstant(lstTag);

			return cLogS;
        }

        #endregion


        #region Private Methods

        #region DDEA

        protected bool RunDDEA()
        {
            if (m_cTagS == null)
                return false;

            if (m_cDDEAServer == null)
                m_cDDEAServer = new CDDEAServer();

            bool bOK = m_cDDEAServer.Connect();
            if (bOK)
            {	
				m_cDDEAServer.AddItemS(m_cTagS.Values.ToList());
                m_cDDEAServer.UEventTerminated += new EventHandler(m_cDDEAServer_UEventTerminated);
                m_cDDEAServer.UEventValueChanged += new UEventHandlerMonitorValueChanged(m_cDDEAServer_UEventValueChanged);
                m_cDDEAServer.Run();
            }

            return bOK;
        }

        protected void StopDDEA()
        {
            if (m_cDDEAServer == null || m_cDDEAServer.IsRunning == false)
                return;

            m_cDDEAServer.Stop();
            m_cDDEAServer.UEventTerminated -= new EventHandler(m_cDDEAServer_UEventTerminated);
            m_cDDEAServer.UEventValueChanged -= new UEventHandlerMonitorValueChanged(m_cDDEAServer_UEventValueChanged);
            m_cDDEAServer.Disconnect();
            m_cDDEAServer.Dispose();
            m_cDDEAServer = null;
        }

        #endregion

        #region OPC

        protected bool RunOPC()
        {
            if (m_cOPCConfig == null)
                return false;

            if (m_cTagS == null)
                return false;

            if (m_cOPCServer == null)
                m_cOPCServer = new COPCServer();

            m_cOPCServer.Config = m_cOPCConfig;
            bool bOK = m_cOPCServer.Connect();
            if (bOK)
            {
				bOK = m_cOPCServer.AddItemS(m_cTagS.Values.ToList());
				if (bOK)
				{
					CMonitorStatus.OPCConnected = true;
					m_cOPCServer.UEventValueChanged += new UEventHandlerMonitorValueChanged(m_cOPCServer_UEventValueChanged);
					m_cOPCServer.Run();
				}
            }

            return bOK;
        }

        protected void StopOPC()
        {
            if (m_cOPCServer == null)
                return;

            m_cOPCServer.Stop();
            m_cOPCServer.Disconnect();
            m_cOPCServer.UEventValueChanged -= new UEventHandlerMonitorValueChanged(m_cOPCServer_UEventValueChanged);
            m_cOPCServer = null;

            CMonitorStatus.OPCConnected = false;
        }

        #endregion

		#region LS

        protected bool ConnectLS()
        {
            if (m_cLsConfig == null)
                return false;

            if (m_cLsReader == null)
                m_cLsReader = new CLsReader();

            m_cLsReader.Config = m_cLsConfig;
            bool bOK = m_cLsReader.Connect();

            return bOK;
        }

		protected bool RunLS()
		{
			if (m_cLsConfig == null)
				return false;

			if (m_cTagS == null)
				return false;

            if (m_cLsReader == null)
                m_cLsReader = new CLsReader();

			m_cLsReader.Config = m_cLsConfig;
			bool bOK = m_cLsReader.Connect();
			if (bOK)
			{
				bOK = m_cLsReader.AddItemS(m_cTagS.Values.ToList());
				if (bOK)
				{
                    m_cLsReader.UEventValueChanged += new UEventHandlerMonitorValueChanged(m_cLsReader_UEventValueChanged);
					m_cLsReader.Run();
				}
			}

			return bOK;
		}

		protected void StopLS()
		{
			if (m_cLsReader == null || m_cLsReader.IsRuning == false)
				return;

			m_cLsReader.Stop();
			m_cLsReader.Disconnect();
            m_cLsReader.UEventValueChanged -= new UEventHandlerMonitorValueChanged(m_cLsReader_UEventValueChanged);
			m_cLsReader = null;
		}


		#region Simulator

		protected bool RunSimulator()
		{
			if (m_cSimulatorConfig == null)
				return false;

			if (m_cSimulator == null)
				m_cSimulator = new CSimulator();

			m_cSimulator.Config = m_cSimulatorConfig;
            m_cSimulator.UEventValueChanged += new UEventHandlerMonitorValueChanged(m_cSimulator_UEventValueChanged);

			m_cSimulator.Run();

			return true;
		}

		protected void StopSimulator()
		{
			if (m_cSimulator == null)
				return;

			m_cSimulator.Stop();
            m_cSimulator.UEventValueChanged -= new UEventHandlerMonitorValueChanged(m_cSimulator_UEventValueChanged);
			m_cSimulator = null;
		}

		#endregion

		#endregion

		#region Etc

		protected void GenerateValueChangeEvent(CTimeLogS cLogS)
        {
            if(UEventValueChanged != null)
                UEventValueChanged(this, cLogS);
        }

        #endregion

        #endregion

        #region Event Methods

        private void m_cDDEAServer_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            GenerateValueChangeEvent(cLogS);
        }

        private void m_cOPCServer_UEventValueChanged(object sender, CTimeLogS cLogS)
        {   
            GenerateValueChangeEvent(cLogS);
        }

		private void m_cLsReader_UEventValueChanged(object sender, CTimeLogS cLogS)
		{
			GenerateValueChangeEvent(cLogS);
		}

        private void m_cSimulator_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            GenerateValueChangeEvent(cLogS);
        }

        private void m_cDDEAServer_UEventTerminated(object sender, EventArgs e)
        {
            StopDDEA();

            if (UEventTerminated != null)
                UEventTerminated(this, e);
        }

        #endregion
    }
}
