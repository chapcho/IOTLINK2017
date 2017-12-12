using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Log.Energy;
using UDM.EnergyDaq.Service;
using UDM.EnergyProcAgent.Config;

namespace UEnergyProcAgent
{
    internal class CMainClass : IDisposable
    {
        #region Member Variables

        protected bool m_bRun = false;
        protected CProject m_cProject = null;
        protected List<CEnergyDaqClient> m_lstClient = null;
        protected CEnergyLogger m_cLogger = null;

        #endregion


        #region Initilaize/Dispose

        public CMainClass()
        {

        }

        public void Dispose()
        {
            Stop();
        }

        #endregion


        #region Public Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        #endregion
        

        #region Public Methods        
            
        public bool Start()
        {
            if (m_lstClient != null)
                return true;

            bool bOK = true;

            try
            {
                bOK = RunLogger();
                if (bOK)
                    return false;

                m_lstClient = CreateClientList();                
                ConnectClientList(m_lstClient);                

                m_bRun = true;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Stop()
        {
            if (m_lstClient == null)
                return true;

            bool bOK = true;

            try
            {
                DisconnectClientList(m_lstClient);
                m_lstClient = null;

                StopLogger();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            m_bRun = false;

            return bOK;
        }

        #endregion


        #region Private Methods

        private bool IsAvailable(CServerInfo cInfo)
        {
            if (cInfo.ServiceName.Trim() == "" || cInfo.IP.Trim() == "" || cInfo.Port == 0)
                return false;

            return true;
        }

        private CEnergyDaqClient CreateClient(string sClientName, CServerInfo cInfo)
        {
            CEnergyDaqClient cClient = new CEnergyDaqClient(sClientName);
            cClient.ServiceName = cInfo.ServiceName;
            cClient.IP = cInfo.IP;
            cClient.Port = cInfo.Port;

            return cClient;
        }

        private bool RunLogger()
        {
            m_cLogger = new CEnergyLogger(m_cProject.Config.LoggerInfo.IP, m_cProject.Config.LoggerInfo.Port);

            bool bOK = m_cLogger.Run();
            if (bOK == false)
            {
                m_cLogger.Dispose();
                m_cLogger = null;
            }

            return bOK;
        }

        private void StopLogger()
        {
            if (m_cLogger != null)
            {
                m_cLogger.Stop();
                m_cLogger.Dispose();
                m_cLogger = null;
            }
        }

        private List<CEnergyDaqClient> CreateClientList()
        {
            List<CEnergyDaqClient> lstClient = new List<CEnergyDaqClient>();

            CServerInfo cInfo = null;
            CEnergyDaqClient cClient = null;
            for (int i = 0; i < m_cProject.Config.ServerInfoS.Count; i++)
            {
                cInfo = m_cProject.Config.ServerInfoS[i];
                if (IsAvailable(cInfo) == false)
                    continue;

                cClient = CreateClient(m_cProject.Name, cInfo);
                lstClient.Add(cClient);
            }

            return lstClient;
        }

        private void ConnectClientList(List<CEnergyDaqClient> lstClient)
        {
            bool bOK = true;
            CEnergyDaqClient cClient = null;
            for (int i = 0; i < lstClient.Count; i++)
            {
                cClient = lstClient[i];
                cClient.UEventDataRecieved += cClient_UEventDataRecieved;
                cClient.UEventTerminated += cClient_UEventTerminated;

                bOK = cClient.Connect();
                if (bOK == false)
                {
                    cClient.UEventDataRecieved -= cClient_UEventDataRecieved;
                    cClient.UEventTerminated -= cClient_UEventTerminated;
                    lstClient.RemoveAt(i);
                    i--;
                }
            }
        }

        private void DisconnectClientList(List<CEnergyDaqClient> lstClient)
        {
            CEnergyDaqClient cClient = null;
            for (int i = 0; i < lstClient.Count; i++)
            {
                cClient = lstClient[i];
                cClient.Disconnect();

                cClient.UEventDataRecieved -= cClient_UEventDataRecieved;
                cClient.UEventTerminated -= cClient_UEventTerminated;
            }

            lstClient.Clear();
            lstClient = null;
        }

        private void ChangeLogKey(string sIP, CEnergyLogS cLogS)
        {
            string sChannel = "";
            string sLayer = "";



            CEnergyLog cLog;
            for(int i=0;i<cLogS.Count;i++)
            {
                cLog = cLogS[i];
                
            }
        }

        #endregion


        #region Event Methods

        private void cClient_UEventDataRecieved(object sender, CEnergyLogS cLogS)
        {
            if (m_cLogger != null)
            {
                
                m_cLogger.EnQue(cLogS);
            }
        }

        private void cClient_UEventTerminated(object sender)
        {
            //Nothing
            //CEnergyDaqClient did disconnect already!!
        }

        #endregion
    }
}
