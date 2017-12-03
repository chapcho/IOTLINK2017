using IOTL.Common.Framework;
using IOTL.Common.Log;
using IOTL.Socket;
using IOTL.Socket.ClientSession;
using IOTL.Socket.CustomEventArgs;
using SuperSocket.SocketBase.Config;
using System;
using System.Net;
using System.Windows.Forms;

namespace IOTL.Common.UserControls
{
    /// <summary>
    /// 소켓 서버를 위한 컨트롤
    /// Parameter : ip, port
    /// </summary>
    public partial class UCSocketServer : UserControl
    {
        public const int MAX_REQUEST_LENGTH = 4096;
        private claServer socketServer;

        private int connectedClientCount = 0;
        private int receivedPacketCount = 0;
        private int sendPacketCount = 0;

        public event UEventHandlerIOTLMessage UEventMessage = null;
        public event UEventHandlerMachineStateTimeLog UEventMachineStateTimeLog = null;
        public event UEventHandlerFileLog UEventFileLog = null;

        public UCSocketServer()
        {
            InitializeComponent();
        }

        public int ConnectedClientCount
        {
            get { return connectedClientCount; }
            set
            {
                if (value != connectedClientCount)
                {
                    connectedClientCount = value;
                    UpdateConnectedClientCount("Client", value.ToString());
                }
            }
        }
        public int ReceivedPacketCount
        {
            get { return receivedPacketCount; }
            set
            {
                if (value != receivedPacketCount)
                {
                    receivedPacketCount = value;
                    UpdateReceivePacketCount("ReceivePacket", value.ToString());
                }
            }
        }
        public int SendPacketCount
        {
            get { return sendPacketCount; }
            set
            {
                if (value != sendPacketCount)
                {
                    sendPacketCount = value;
                    UpdateSendPacketCount("SendPacket", value.ToString());
                }
            }
        }

        private void SetMonitorNumBinding()
        {
            // 아래 코드가 동작하지 않는데, 원인을 좀더 찾아 봐야 겠다.
            ConnectedClientCount++;
            ReceivedPacketCount++;
            SendPacketCount++;

            ConnectedClientCount--;
            ReceivedPacketCount--;
            SendPacketCount--;
        }

        private string GetLocalIP()
        {
            IPHostEntry getIpInfo = Dns.GetHostEntry(Dns.GetHostName());
            // string ipAddr = string.Empty;

            for (int i = 0; i < getIpInfo.AddressList.Length; i++)
            {
                if (getIpInfo.AddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // ipAddr = getIpInfo.AddressList[i].ToString();
                    return getIpInfo.AddressList[i].ToString();
                }
            }

            return @"127.0.0.1";
        }

        public void InitializeSocketServer()
        {
            if (socketServer.State == SuperSocket.SocketBase.ServerState.Initializing)
            {
                MessageBox.Show("소켓서버가 이미 초기화 되었습니다.", "Error");
                UpdateSystemMessage("SocketServer", "소켓서버가 이미 초기화 되었습니다.");
                return;
            }

            string ipAddress = GetLocalIP();

            ServerConfig serverConfig = new ServerConfig
            {
                Ip = ipAddress,
                Port = Int32.Parse(txtServerPort.Text),
                MaxRequestLength = MAX_REQUEST_LENGTH,
            };

            txtServerPort.Enabled = false;

            // 소켓 서버에 대한 초기화는 1번만...
            try
            {
                socketServer.Setup(serverConfig);
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SocketServer", ex.Message);
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public claServer ServerSocket
        {
            get { return socketServer; }
        }

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            UEventMessage?.Invoke(sSender, sMessage);
        }

        private void SaveLogToFile(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string sLogMessage)
        {
            UEventFileLog?.Invoke(emFileLogType, emFileLogDepth, sLogMessage);
        }

        private void SaveLogToMonitor(String clientID, LocalMessageEventArgs objReceiveData)
        {
            if (UEventMachineStateTimeLog != null)
            {
                CTimeLog log = new CTimeLog(clientID, ConstantDef.NIY);
                // 로그를 수신한 시간을 기록한다. 설비에서 보낸 시간은 데이터에 기록되어야 한다.
                log.LogTime = DateTime.Now;

                log.ReceiveData = objReceiveData.receiveData;

                // 설비의 상태를 받아서 전달할 수 있다면 상태를 바꾸어서 전달해야 합니다.
                UEventMachineStateTimeLog(log);
            }
        }

        #region Form Event area

        public bool StartServerSocket()
        {
            if(socketServer != null)
            {
                UpdateSystemMessage("SocketServer", "소켓서버를 초기화 될수 없습니다.");
                return false;
            }

            socketServer = new claServer();
            if (socketServer.State == SuperSocket.SocketBase.ServerState.NotInitialized) InitializeSocketServer();

            btnServerStop.Enabled = false;

            socketServer.NewSessionConnected += socketServer_NewSessionConnected;
            socketServer.SessionClosed += socketServer_SessionClosed;

            socketServer.OnLoginUser += socketServer_OnLoginUser;
            socketServer.OnLogoutUser += SocketServer_OnLogoutUser;
            socketServer.OnMessaged += socketServer_OnMessaged;

            if (socketServer.State == SuperSocket.SocketBase.ServerState.NotStarted)
            {
                if (btnSeverStart.Enabled)
                {
                    try
                    {
                        if (true == socketServer.Start())
                        {
                            btnSeverStart.Enabled = false;
                            btnServerStop.Enabled = true;
                            btnSeverStart.Text = "Starting...";

                            UpdateSystemMessage("SocketServer", string.Format("IP:{0} , Port:{1} , Socket Server Starting!", GetLocalIP(), txtServerPort.Text));
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                        UpdateSystemMessage("SocketServer", "서버 시작에 문제가 있습니다.");
                        MessageBox.Show("서버 시작에 문제가 있습니다.", "Error");
                    }

                    return false;
                }
                else
                {
                    UpdateSystemMessage("SocketServer", "서버가 이미 기동되어 있습니다.");
                    MessageBox.Show("서버 기동중입니다. 재시작하기 위해 서버를 중지하세요.", "Warnning");
                }

                return false;
            }
            else
            {
                UpdateSystemMessage("SocketServer", "서버가 이미 기동되어 있습니다.");
                MessageBox.Show("서버 기동 상태 확인이 필요합니다.", "Warnning");
            }
            return false;
        }

        private void btnSeverStart_Click(object sender, EventArgs e)
        {
            StartServerSocket();
            socketServer.DummySocketServer = chkSocketTransparent.Checked;
        }

        private void btnServerStop_Click(object sender, EventArgs e)
        {
            if (socketServer.State == SuperSocket.SocketBase.ServerState.Running)
            {

                socketServer.NewSessionConnected -= socketServer_NewSessionConnected;
                socketServer.SessionClosed -= socketServer_SessionClosed;

                socketServer.OnLoginUser -= socketServer_OnLoginUser;
                socketServer.OnLogoutUser -= SocketServer_OnLogoutUser;
                socketServer.OnMessaged -= socketServer_OnMessaged;

                socketServer.Stop();
                socketServer = null;

                txtServerPort.Enabled = true;
                UpdateSystemMessage("SocketServer", "소켓서버 종료");
            }
            else
            {
                UpdateSystemMessage("SocketServer", "서버 기동 상태 확인이 필요합니다.");
                MessageBox.Show("서버 기동 상태 확인이 필요합니다.", "Warnning");
            }

            btnSeverStart.Enabled = true;
            btnServerStop.Enabled = false;
            btnSeverStart.Text = "서버시작";
        }

        private void chkSocketTransparent_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkSocketTransparent.Checked)
            {
                UpdateSystemMessage("SocketServer", "Transparent Mode Socket!");
            }
            else
            {
                UpdateSystemMessage("SocketServer", "SuperSocket Chatting Mode!");
            }
        }

        #endregion

        #region Socket Event Handler

        private void socketServer_OnMessaged(claClientSession session, LocalMessageEventArgs e)
        {
            ReceivedPacketCount++;
            // 수신한 내용을 화면에 표시(데이터량이 많으면 표시 할수 없다.)
            UpdateSystemMessage("SocketServer", session.UserID + " : " + e.Message);
            // 처리전에 로그에 기록
            SaveLogToFile(EMFileLogType.CommunicationLog, EMFileLogDepth.Info, e.Message);
            // Monitor에게 보내는 메시지(DB저장등 App에서 해야 할 처리)
            SaveLogToMonitor(session.UserID, e);
        }

        private void SocketServer_OnLogoutUser(claClientSession session, LocalMessageEventArgs e)
        {
            UpdateSystemMessage("SocketServer", "Session Closed :" + session.UserID);
        }

        private void socketServer_OnLoginUser(claClientSession session, LocalMessageEventArgs e)
        {
            UpdateSystemMessage("SocketServer", "Session Connected :" + session.UserID);

            SaveLogToFile(EMFileLogType.CommunicationLog, EMFileLogDepth.Info, session.UserID + "Session Connected!");
        }

        private void socketServer_SessionClosed(claClientSession session, SuperSocket.SocketBase.CloseReason value)
        {
            ConnectedClientCount--;
            UpdateClientList(false,session.SessionID,session.SecureProtocol.ToString());

            UpdateSystemMessage("SocketServer", "Session Closed :" + session.UserID);

            SaveLogToFile(EMFileLogType.CommunicationLog, EMFileLogDepth.Info, session.UserID + "Session Closed!");
        }

        /// <summary>
        /// 새로운 소켓 세션 연결
        /// 
        /// </summary>
        /// <param name="session"></param>
        private void socketServer_NewSessionConnected(claClientSession session)
        {
            ConnectedClientCount++;
            UpdateClientList(true, session.SessionID, session.SecureProtocol.ToString());

            // 수펴소켓에서 제공하는 세션ID를 이용해서 특정단말에 데이터를 전송할 수 있다.
            UpdateSystemMessage("SocketServer", "Session Connected!! : " + session.SessionID);
        }
        #endregion

        public bool SendMessageToClient(string clientId, string message)
        {
            bool bRet = false;
            SendPacketCount++;

            try
            {
                bRet = socketServer.SendMsgToClient(clientId, message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                // 단말로의 데이어 전송이 실패한 여러가지 경우 단말 접속정보를 삭제할것인지 검토 필요
                ex.Data.Clear();
            }
            
            return bRet;
        }

        private void UCSocketServer_Load(object sender, EventArgs e)
        {
            SetMonitorNumBinding();
            txtServerIPAddress.Text = GetLocalIP();
            InitialClientListLayout();
        }

        private void InitialClientListLayout()
        {
            lvClientList.BeginUpdate();
            lvClientList.Columns.Add("SessionID", 50,HorizontalAlignment.Left);
            lvClientList.Columns.Add("Type", 50,HorizontalAlignment.Center);
            lvClientList.Columns.Add("Time", 200,HorizontalAlignment.Left);

            lvClientList.View = View.Details;
            lvClientList.GridLines = true;
            lvClientList.FullRowSelect = true;
            lvClientList.CheckBoxes = false;
            lvClientList.EndUpdate();
        }

        protected delegate void UpdateTextCallBack(string sSender, string sMessage);

        public void UpdateReceivePacketCount(object sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateReceivePacketCount);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    txtReceivePacket.Text = sMessage;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        public void UpdateConnectedClientCount(object sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateConnectedClientCount);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    txtConnected.Text = sMessage;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        public void UpdateSendPacketCount(object sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateSendPacketCount);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    txtSendPacket.Text = sMessage;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected delegate void UpdateClientListCallBack(bool bIn, string sessionId, string clientType);

        public void UpdateClientList(bool bIsConnection, string sessionId, string clientType)
        {
            if(this.InvokeRequired)
            {
                UpdateClientListCallBack deleCallback = new UpdateClientListCallBack(UpdateClientList);
                this.Invoke(deleCallback, new object[] { bIsConnection, sessionId,clientType });
            }
            else
            {
                lvClientList.BeginUpdate();
                switch(bIsConnection)
                {
                    case true:
                        string eventDt = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff");
                        String[] newRecord = { sessionId, clientType, eventDt };
                        ListViewItem newItem = new ListViewItem(newRecord);
                        this.lvClientList.Items.Add(newItem);
                        break;
                    case false:
                        foreach(ListViewItem item in lvClientList.Items)
                        {
                            if (item.SubItems[0].Text.Equals(sessionId))
                            {
                                lvClientList.Items.Remove(item);
                            }
                        }
                        break;
                }
                lvClientList.EndUpdate();
            }
        }


    }
}
