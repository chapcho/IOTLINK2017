using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TrackerWCF;
using UDM.General.Remote;

namespace UDMSPDManager
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private CServer<IMyService, CMyService> m_cServer = null;
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected Dictionary<string, CService> m_dicClient = new Dictionary<string, CService>();
        protected Dictionary<string, XtraTabPage> m_dicSPDTabPage = new Dictionary<string, XtraTabPage>();
        protected CClient<IMyService, CMyServiceCallBack> m_cClient = null;
        protected bool m_bConnect = false;
        protected string m_sConfigFilePath = "";
        protected int m_iTabCount = 0;
        private string[] m_saTestString = null;
        #region Embedded DDEA

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

        [DllImport("user32")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            //this.ShowInTaskbar = false;
            //notifyIcon.Visible = true;
        }


        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Size.Width / 2, Screen.PrimaryScreen.Bounds.Size.Height);
            this.Location = new Point(0, 0);
            bool bOK = StartServer();
            if (bOK) SetManagerLamp(false, "OK");
            else SetManagerLamp(true, "");

            Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
            foreach (Process pro in aProcess)
            {
                pro.Kill();
            }

            bOK = ClientConnect();
            UpdateSystemMessage("Load", "Client Connect");
            tabCollectApp.TabPages.Clear();

            if (bOK) SetTrackerLamp(false, "OK");
            else SetTrackerLamp(true, "");

            ClientRun();
            UpdateSystemMessage("Load", "Client Run");
            tmrTrackerCheck.Start();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

            StopServer();

            ClientStop();
            ClientDisconnect();

            //notifyIcon.Visible = false;
            //notifyIcon.Dispose();
        }

        private void tabCollectApp_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (tabCollectApp.TabPages.Count > 0)
            {
                Process pro = (Process)e.Page.Tag;
                ResizeEmbeddedApp(pro, e.Page);
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }
        }

        private void chkShowSysLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSysLog.Checked == false)
            {
                if (dpnlSystemMessage.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlSystemMessage.Hide();
            }
            else
            {
                if (dpnlSystemMessage.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlSystemMessage.Show();
            }

            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string sData = "";
            for (int i = 0; i < m_saTestString.Length; i++)
            {
                sData += string.Format("{0}, ", m_saTestString[i]);
            }
            UpdateSystemMessage("테스트 중", sData);
            SendStopCommand(m_saTestString);
            UpdateSystemMessage("테스트 중", "전송 완료");
            //string[] saData = { "00128D5B-0", "[CH.DV]SM412[1],SM412,Bool,1" };
            //SendTagList(saData);

            //string sPath = @"C:\Users\LG\Desktop\20161115_SYMC\OPTRA_작업_노트북\bin\01BFC14D\PLC 통신설정.plccfg";

            //string[] saConfig = { "01BFC14D-0", sPath };
            //SendCollectorList(saConfig);


            //System.Threading.Thread.Sleep(3000);

            //string[] saStart = { "238C98BD-0" };
            //SendStartCommand(saStart);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void mnuHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Activate();
        }
        #endregion


        #region Tracker -> Manager Private Method

        public bool ClientConnect()
        {
            bool bOK = true;

            try
            {
                if (m_cClient == null)
                {
                    m_cClient = new CClient<IMyService, CMyServiceCallBack>("Manager");
                }

                //m_cClient.ServiceName = "Tracker";
                //m_cClient.Port += 1;
                if (m_cClient.IsConnected == false)
                    bOK = m_cClient.Connect();

                if (bOK)
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
                System.Windows.Forms.MessageBox.Show("Can't connect", "SPD Manager", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bOK;
        }

        public bool ClientDisconnect()
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

        public bool ClientRun()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return false;


            bool bOK = true;

            try
            {
                m_cClient.ServiceCallBack.UEventReceiveCommStart += ServiceCallBack_UEventReceiveCommStart;
                m_cClient.ServiceCallBack.UEventReceiveCommStop += ServiceCallBack_UEventReceiveCommStop;
                m_cClient.ServiceCallBack.UEventReceiveCollectorList += ServiceCallBack_UEventReceiveCollectorList;
                m_cClient.ServiceCallBack.UEventReceiveEmergTagList += ServiceCallBack_UEventReceiveEmergTagList;
                m_cClient.ServiceCallBack.UEventReceiveTagList += ServiceCallBack_UEventReceiveTagList;
                m_cClient.ServiceCallBack.UEventReceiveRecipeTagList += ServiceCallBack_UEventReceiveRecipeTagList;
                m_cClient.ServiceCallBack.UEventReceiveAddTagList += ServiceCallBack_UEventReceiveAddTagList;
                m_cClient.ServiceCallBack.UEventReceiveRemoveTagList += ServiceCallBack_UEventReceiveRemoveTagList;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            if (bOK == false)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect", "SPD Manager", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bOK;
        }

        public bool ClientStop()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return true;
            try
            {
                m_cClient.ServiceCallBack.UEventReceiveCommStart -= ServiceCallBack_UEventReceiveCommStart;
                m_cClient.ServiceCallBack.UEventReceiveCommStop -= ServiceCallBack_UEventReceiveCommStop;
                m_cClient.ServiceCallBack.UEventReceiveCollectorList -= ServiceCallBack_UEventReceiveCollectorList;
                m_cClient.ServiceCallBack.UEventReceiveEmergTagList -= ServiceCallBack_UEventReceiveEmergTagList;
                m_cClient.ServiceCallBack.UEventReceiveTagList -= ServiceCallBack_UEventReceiveTagList;
                m_cClient.ServiceCallBack.UEventReceiveRecipeTagList -= ServiceCallBack_UEventReceiveRecipeTagList;
                m_cClient.ServiceCallBack.UEventReceiveAddTagList -= ServiceCallBack_UEventReceiveAddTagList;
                m_cClient.ServiceCallBack.UEventReceiveRemoveTagList -= ServiceCallBack_UEventReceiveRemoveTagList;

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                return false;
            }
            return true;
        }

        #region User Event

        private void ServiceCallBack_UEventReceiveAddTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = string.Empty;

            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveAddTagList", sData);
            SendAddTagList(saData);
        }

        private void ServiceCallBack_UEventReceiveRemoveTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = string.Empty;

            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveRemoveTagList", sData);
            SendRemoveTagList(saData);
        }


        void ServiceCallBack_UEventReceiveTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = string.Empty;
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveTagList", sData);
            SendTagList(saData);
        }

        void ServiceCallBack_UEventReceiveEmergTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveEmergTagList", sData);
            SendEmergTagList(saData);
        }

        void ServiceCallBack_UEventReceiveRecipeTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveRecipeTagList", sData);
            SendRecipeTagList(saData);
        }

        /// <summary>
        /// Collector Application 객체 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="saData"></param>
        void ServiceCallBack_UEventReceiveCollectorList(object sender, string[] saData)
        {
            //if (m_dicClient.Count > 0)
            //{
            //    m_cServer.Service.Dispose();
            //    //foreach (string sKey in m_dicClient.Keys)
            //    //{
            //    //    string[] saClose = { sKey, "Close" };
            //    //    m_cServer.Service.SendStopCommandToClient(saClose);
            //    //}
            //}

            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveCollectorList", sData);

            m_sConfigFilePath = saData[0];

            List<string> lstPlcID = new List<string>();
            for (int i = 1; i < saData.Length; i++)
                lstPlcID.Add(saData[i]);

            ArrangeSPD(lstPlcID);
        }

        void ServiceCallBack_UEventReceiveCommStop(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";

            sData = sData.Substring(0, sData.LastIndexOf(','));

            UpdateSystemMessage("UEventReceiveCommStop", sData);
            SendStopCommand(saData);
            m_saTestString = (string[])saData.Clone();
            if (sData.Contains("Close"))
            {
                this.Close();
            }
        }

        void ServiceCallBack_UEventReceiveCommStart(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;

            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveCommStart", sData);

            SendStartCommand(saData);
        }

        private void SendTimeLogS(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendTimeLogSToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendEmergTimeLogS(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendEmergTimeLogSToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendRecipeLogS(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendRecipeTimeLogSToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }


        private void SendStatus(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendStatusToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendClientMessge(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendMessageToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendErrorTagList(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendErrorTagListToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Client", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                ClientDisconnect();
                ClientConnect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("WCFClient", "Sevice가 종료되어 전송되지 않습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventTerminated(object sender, EventArgs e)
        {
            bool bOK = false;
        }

        #endregion



        #endregion


        #region Private Method

        private void ResizeEmbeddedApp(Process _process, XtraTabPage tpApp)
        {
            if (_process == null)
                return;

            SetWindowPos(_process.MainWindowHandle, IntPtr.Zero, 0, 0, (int)tpApp.ClientSize.Width, (int)tpApp.ClientSize.Height, SWP_NOZORDER | SWP_NOACTIVATE);
        }

        protected void UpdateSystemMessage(string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateSystemMessage);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public bool StartServer()
        {
            bool bOK = true;

            try
            {
                if (m_cServer == null)
                    m_cServer = new CServer<IMyService, CMyService>();

                m_cServer.ServiceName = "SPDManager";
                m_cServer.Port -= 1;
                if (m_cServer.IsRunning == false)
                    bOK = m_cServer.Start();

                if (bOK)
                {
                    m_cServer.Service.UEventReceiveTimeLogS += Service_UEventReceiveTimeLogS;
                    m_cServer.Service.UEventReceiveEmergTimeLogS += Service_UEventReceiveEmergTimeLogS;
                    m_cServer.Service.UEventReceiveRecipeLogS += Service_UEventReceiveRecipeLogS;
                    m_cServer.Service.UEventReceiveStatus += Service_UEventReceiveStatus;
                    m_cServer.Service.UEventReceiveErrorTagList += Service_UEventReceiveErrorTagList;
                    m_cServer.Service.UEventClientConnected += Service_UEventClientConnected;
                    m_cServer.Service.UEventClientDisconnected += Service_UEventClientDisconnected;
                    m_cServer.Service.UEventReceiveClientMessage += Service_UEventReceiveClientMessage;
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public void StopServer()
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                m_cServer.Service.UEventReceiveTimeLogS -= Service_UEventReceiveTimeLogS;
                m_cServer.Service.UEventReceiveEmergTimeLogS -= Service_UEventReceiveEmergTimeLogS;
                m_cServer.Service.UEventReceiveRecipeLogS -= Service_UEventReceiveRecipeLogS;
                m_cServer.Service.UEventReceiveStatus -= Service_UEventReceiveStatus;
                m_cServer.Service.UEventReceiveErrorTagList -= Service_UEventReceiveErrorTagList;
                m_cServer.Service.UEventClientConnected -= Service_UEventClientConnected;
                m_cServer.Service.UEventClientDisconnected -= Service_UEventClientDisconnected;
                m_cServer.Service.UEventReceiveClientMessage -= Service_UEventReceiveClientMessage;

                m_cServer.Stop();
                m_cServer.Dispose();
                m_cServer = null;
            }
        }

        private void CreateSPD(string sID)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = Application.StartupPath + "\\UDMSPDSingle.exe";
            pro.StartInfo.Arguments = sID;
            pro.Start();

            XtraTabPage tabPage = new XtraTabPage();
            m_iTabCount++;
            tabPage.Name = "tp" + m_iTabCount.ToString();
            tabPage.Text = "SPD " + sID;
            tabPage.Tag = pro;
            tabCollectApp.TabPages.Add(tabPage);

            tabCollectApp.SelectedTabPage = tabPage;
            m_dicSPDTabPage.Add(sID, tabPage);
            EmbeddedApplication(sID, pro, tabPage);
        }

        private void ArrangeSPD(List<string> lstPlcID)
        {
            Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
            foreach (Process pro in aProcess)
            {
                pro.Kill();
            }


            tabCollectApp.TabPages.Clear();
            UpdateSystemMessage("SPDSingle", "모든 실행을 종료하고 다시 시작합니다.");
            m_dicClient.Clear();
            m_dicSPDTabPage.Clear();
            for (int i = 0; i < lstPlcID.Count; i++)
            {
                if (m_dicSPDTabPage.ContainsKey(lstPlcID[i]) == false)
                {
                    CreateSPD(lstPlcID[i]);
                    while (true)
                    {
                        if (m_dicClient.ContainsKey(lstPlcID[i]))
                            break;
                    }
                }

                string[] saPath = { lstPlcID[i], m_sConfigFilePath };
                SendCollectorList(saPath);
                UpdateSystemMessage("Send", lstPlcID[i] + "의 ConfigPath가 전달되었습니다");
            }
            this.SendToBack();
        }

        private void EmbeddedApplication(string sID, Process pro, XtraTabPage tpApp)
        {
            while (true)
            {
                if (m_dicClient.ContainsKey(sID))
                {
                    UpdateSystemMessage("SPDSingle", "Find Id : " + sID);
                    break;
                }
                Application.DoEvents();
            }
            this.Focus();
            this.BringToFront();
            System.Threading.Thread.Sleep(500);
            UpdateSystemMessage("SPDSingle", "Embedded App");
            SetParent(pro.MainWindowHandle, tpApp.Handle);

            //// remove control box(WinForm일때만)
            //int style = GetWindowLong(pro.MainWindowHandle, GWL_STYLE);
            //style = style & ~WS_CAPTION & ~WS_THICKFRAME;
            //SetWindowLong(pro.MainWindowHandle, GWL_STYLE, style);

            // resize embedded application & refresh
            ResizeEmbeddedApp(pro, tpApp);
        }

        private void SetTrackerLamp(bool bFail, string sText)
        {
            if (bFail)
            {
                btnTrackerConnect.Appearance.BackColor = Color.Red;
                btnTrackerConnect.Appearance.BackColor2 = Color.OrangeRed;
                btnTrackerConnect.Text = "NG";
            }
            else
            {
                btnTrackerConnect.Appearance.BackColor = Color.Lime;
                btnTrackerConnect.Appearance.BackColor2 = Color.Green;
                btnTrackerConnect.Text = sText;
            }
        }

        private void SetManagerLamp(bool bFail, string sText)
        {
            if (bFail)
            {
                btnManagerServer.Appearance.BackColor = Color.Red;
                btnManagerServer.Appearance.BackColor2 = Color.OrangeRed;
                btnManagerServer.Text = "NG";
            }
            else
            {
                btnManagerServer.Appearance.BackColor = Color.Lime;
                btnManagerServer.Appearance.BackColor2 = Color.Green;
                btnManagerServer.Text = sText;
            }
        }

        #endregion

        #region User Event

        private void Service_UEventReceiveEmergTagList(object sender, string[] saData, out string[] saLog)
        {
            saLog = null;
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
            SendEmergTagList(saData);
        }

        private void Service_UEventReceiveErrorTagList(object sender, string[] saData)
        {
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
            SendErrorTagList(saData);
        }

        private void Service_UEventReceiveStatus(object sender, string[] saData)
        {
            if (saData.Length < 2) return;
            SendStatus(saData);
        }

        private void Service_UEventReceiveTimeLogS(object sender, string[] saData)
        {
            SendTimeLogS(saData);
        }

        private void Service_UEventReceiveEmergTimeLogS(object sender, string[] saData)
        {
            SendEmergTimeLogS(saData);
        }

        private void Service_UEventReceiveRecipeLogS(object sender, string[] saData)
        {
            SendRecipeLogS(saData);
        }

        private void Service_UEventClientDisconnected(object sender, string sClient)
        {
            if (m_dicClient.ContainsKey(sClient))
            {
                m_dicClient.Remove(sClient);
                string sCount = m_dicClient.Count.ToString();
                SetManagerLamp(false, sCount);
                UpdateSystemMessage("Disconnection", sClient);
                string[] saData = { sClient, "Error" };
                SendStatus(saData);
            }
        }

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            CService cService = (CService)sender;
            if (m_dicClient.ContainsKey(sClient) == false)
            {
                m_dicClient.Add(sClient, cService);
                string sCount = m_dicClient.Count.ToString();
                SetManagerLamp(false, sCount);
                UpdateSystemMessage("Connection", sClient);
            }
        }

        private void SendCollectorList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendCollectorListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }
        /// <summary>
        /// Manager -> Collector
        /// </summary>
        /// <param name="saData"></param>
        private void SendStartCommand(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendStartCommandToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        private void SendCollector(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendCollectorListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        /// <summary>
        /// Manager -> Collector
        /// </summary>
        /// <param name="saData"></param>
        private void SendStopCommand(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendStopCommandToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        /// <summary>
        /// Manager -> Collector
        /// </summary>
        /// <param name="saData"></param>
        private void SendTagList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        private void SendAddTagList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendAddTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendAddTagListToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendAddTagListToClient Error: No Services !!!");
                }
            }
        }

        private void SendRemoveTagList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendRemoveTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendRemoveTagListToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendRemoveTagListToClient Error: No Services !!!");
                }
            }
        }

        /// <summary>
        /// Manager -> Collector
        /// </summary>
        /// <param name="saData"></param>
        private void SendEmergTagList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendEmergTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        private void SendRecipeTagList(string[] saData)
        {
            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendRecipeTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "SPD Single와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CMyService SendRecipeToClient Error: {0}", ex.Message);
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendRecipeToClient Error: No Services !!!");
                }
            }
        }

        private void Service_UEventReceiveClientMessage(object sender, string[] saData)
        {
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
            SendClientMessge(saData);
        }

        #endregion
    }
}
