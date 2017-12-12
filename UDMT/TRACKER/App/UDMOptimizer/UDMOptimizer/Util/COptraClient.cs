using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using TrackerCommon;
using TrackerProject;
using TrackerWCF;
using UDM.General.Remote;

namespace UDMOptimizer
{
    public class COptraClient
    {
        #region Member Varialbles

        private bool m_bConnect = false;
        private COptraManagerInfo m_cOptraManagerInfo = null;

        protected CClient<IMyService, CMyServiceCallBack> m_cClient = null;

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerTrackerMonitoringStart UEventMonitoringStart = null;
        public event UEventHandlerTrackerMonitoringStop UEventMonitoringStop = null;

        private Timer tmrConnect = new Timer();

        #endregion

        #region Initialize

        #endregion

        #region Properties

        public bool IsConnected
        {
            get { return m_bConnect; }
        }
        #endregion

        #region Private Method
        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }
        #endregion

        private void SetOptraManagerInfo()
        {
            List<string> lstPlcProcName = new List<string>();

            m_cOptraManagerInfo = new COptraManagerInfo();

            m_cOptraManagerInfo.ProjectName = CMultiProject.ProjectName;
            m_cOptraManagerInfo.ProjectPath = CMultiProject.ProjectPath;
            //m_cOptraManagerInfo.PlcConfigS = CMultiProject.PlcConfigS;

            foreach (CPlcProc cPlc in CMultiProject.PlcProcS.Values)
                lstPlcProcName.Add(cPlc.Name);

            //m_cOptraManagerInfo.PlcProcList = lstPlcProcName;
        }

        #region Public Method
        public bool ClientConnect()
        {
            bool bOK = true;

            try
            {
                if (m_cClient == null)
                {
                    m_cClient = new CClient<IMyService, CMyServiceCallBack>("Tracker");
                }

                m_cClient.ServiceName = "SPDManager"; 
                m_cClient.Port -= 1;
                if (m_cClient.IsConnected == false)
                    bOK = m_cClient.Connect();

                if (bOK)
                {
                    m_bConnect = true;
                    m_cClient.ServiceCallBack.UEventReceiveCommStart += ServiceCallBack_UEventReceiveCommStart;
                    m_cClient.ServiceCallBack.UEventReceiveCommStop += ServiceCallBack_UEventReceiveCommStop;
                    m_cClient.ServiceCallBack.UEventTerminated += ServiceCallBack_UEventTerminated;
                    UpdateSystemMessage("Tracker", "SPDManager와 연결되었습니다.");

                    string[] saData = { "Tracker", "SPDManager와 연결되었습니다." };
                    SendMessageToServer(saData);

                    tmrConnect.Interval = 180000; // 3분마다 Message 전달
                    tmrConnect.Tick += tmrConnect_Tick;
                    tmrConnect.Start();
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private void tmrConnect_Tick(object sender, EventArgs e)
        {
            string[] saData = { "Tracker", "ALIVE" };
            SendMessageToServer(saData);
        }

        public bool ClientDisconnect()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return true;

            //string[] saData = { "Tracker", "Tracker Manager와 연결이 끊겼습니다." };
            //SendMessageToServer(saData);

            m_cClient.ServiceCallBack.UEventReceiveCommStart -= ServiceCallBack_UEventReceiveCommStart;
            m_cClient.ServiceCallBack.UEventReceiveCommStop -= ServiceCallBack_UEventReceiveCommStop;
            m_cClient.ServiceCallBack.UEventTerminated -= ServiceCallBack_UEventTerminated;

            m_cClient.Disconnect();
            m_cClient.Dispose();
            m_cClient = null;

            m_bConnect = false;

            tmrConnect.Stop();

            UpdateSystemMessage("Tracker", "Tracker Manager와 연결이 끊겼습니다.");
            return true;
        }

        public void SendMessageToServer(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {                       
                m_cClient.Service.SendMessageToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Manager에 Message가 전송되지 않았습니다." + ex.Message);                
                ex.Data.Clear();
            }
        }

        public void SendStatusToServer(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendStatusToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Manager에 Tracker 상태가 전송되지 않았습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        public void SendProjectInfoToServer()
        {
            /*if (m_cClient.IsConnected == false) return;
            try
            {
                // Optra Manager로 Project 정보 전달
                string sInfo = string.Format("{0},{1},{2},{3},{4},{5}",
                                    CMultiProject.ProjectName, CMultiProject.ProjectPath, CMultiProject.MonitorType.ToString(),
                                    CMultiProject.PlcProcS.Count.ToString(), CMultiProject.PlcIDList.Count.ToString(), Application.StartupPath);

                string[] saData = { "Tracker", sInfo };
                m_cClient.Service.SendProjectInfoToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Tracker", "Tracker Project 정보가 전송되지 않았습니다." + ex.Message);
                ex.Data.Clear();
            }*/
        }
        #endregion

        #region Event Method
        
        #region User Event
        private void ServiceCallBack_UEventReceiveCommStop(object sender, string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] +" ";
            UpdateSystemMessage(saData[0], "Get Message : " + sData);

            string[] saMess = { "Tracker", "ReceiveCommStop 수행" };
            SendMessageToServer(saMess);

            if(UEventMonitoringStop != null)
                UEventMonitoringStop(true);
        }

        private void ServiceCallBack_UEventReceiveCommStart(object sender, string[] saData)
        {
            if (m_cClient.IsConnected == false) return;

            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] +" ";
            UpdateSystemMessage(saData[0], "Get Message : " + sData);

            string[] saMess = { "Tracker", "ReceiveCommStart 수행" };
            SendMessageToServer(saMess);

            if (UEventMonitoringStart != null)
                UEventMonitoringStart(true);
        }

        private void ServiceCallBack_UEventTerminated(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Tracker Manager가 종료되었습니다.", "Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            UpdateSystemMessage("Tracker", "Tracker Manager가 종료되었습니다.");
        }

        #endregion
        
        #endregion

    }
}
