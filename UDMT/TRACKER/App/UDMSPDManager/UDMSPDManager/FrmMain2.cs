using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using UDM.Common;
using TrackerCommon;
using UDM.General.Serialize;
using System.IO;
using DevExpress.XtraSplashScreen;
using UDM.Log;

namespace UDMSPDManager
{
    public partial class FrmMain2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Veriables

        private CServer<IMyService, CMyService> m_cServer = null;
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected Dictionary<string, CService> m_dicClient = new Dictionary<string, CService>();
        protected Dictionary<string, XtraTabPage> m_dicSPDTabPage = new Dictionary<string, XtraTabPage>();
        protected CClient<IMyService, CMyServiceCallBack> m_cClient = null;
        protected bool m_bConnect = false;
        protected bool m_bManagerClose = false;
        
        protected string m_sConfigFilePath = "";
        protected int m_iTabCount = 0;
        private string[] m_saTestString = null;
        private CTagS m_cTotalTagS = new CTagS();
        private Dictionary<string, CTagS> m_dicPLCTagS = new Dictionary<string, CTagS>();
        private Dictionary<string, List<string>> m_dicBitBundleSendString = new Dictionary<string, List<string>>();
        private CPlcConfigS m_cConfigS = null;

        protected Dictionary<string, CAllBitDevice> m_dicAllBitData = new Dictionary<string, CAllBitDevice>();
        protected Dictionary<string, CDWordDevice> m_dicDWordDevice = new Dictionary<string, CDWordDevice>();
        protected Dictionary<string, bool> m_dicMelsecOpcUse = new Dictionary<string, bool>();
        protected EMPLCMaker m_emMainPLCMaker = EMPLCMaker.ALL;

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

        #endregion


        #region Init

        public FrmMain2()
        {
            InitializeComponent();
        }

        #endregion


        #region Form Event

        private void FrmMain2_Load(object sender, System.EventArgs e)
        {
            //this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Size.Width / 2, Screen.PrimaryScreen.Bounds.Size.Height);
            //this.Location = new Point(0, 0);
            bool bOK = StartServer();

            Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
            foreach (Process pro in aProcess)
            {
                pro.Kill();
            }

            bOK = ClientConnect();
            UpdateSystemMessage("Load", "Client Connect");
            tabCollectApp.TabPages.Clear();

            chkSPDSingle.Enabled = false;

            if (bOK) chkTracker.Enabled = true;
            else chkTracker.Enabled = false;

            ClientRun();
            UpdateSystemMessage("Load", "Client Run");
        }

        private void FrmMain2_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopServer();

            ClientStop();
            ClientDisconnect();
        }

        private void FrmMain2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkTracker.Enabled  && !m_bManagerClose)
            {
                MessageBox.Show("The Tracker is connected and can not be closed.\r\nYou must disconnect the connection first.");
                e.Cancel = true;
            }
        }

        private void FrmMain2_Resize(object sender, System.EventArgs e)
        {
            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }
        }

        private void tabCollectApp_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (tabCollectApp.TabPages.Count > 0)
            {
                Process pro = (Process)e.Page.Tag;
                ResizeEmbeddedApp(pro, e.Page);
            }

        }

        private void sptMain_SplitterPositionChanged(object sender, System.EventArgs e)
        {
            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }

        }
        private void tabMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }
        }

        private void grvTotalTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void tmrReceiveAllTagS_Tick(object sender, System.EventArgs e)
        {
            tmrReceiveAllTagS.Enabled = false;

            foreach (var who in m_cTotalTagS)
            {
                CTag cTag = who.Value;
                if (m_dicPLCTagS.ContainsKey(cTag.Creator) == false)
                {
                    m_dicPLCTagS.Add(cTag.Creator, new CTagS());
                }
                m_dicPLCTagS[cTag.Creator].Add(cTag);
            }

            //All Tag 분석

            m_dicAllBitData.Clear();
            m_dicDWordDevice.Clear();

            if (m_cTotalTagS == null || m_cTotalTagS.Count == 0) return;
            if (m_emMainPLCMaker == EMPLCMaker.ALL) return;

            if (m_emMainPLCMaker == EMPLCMaker.Siemens)
                SetSiemensBundle();
            else if (m_emMainPLCMaker == EMPLCMaker.Mitsubishi)
            {
                return;
            }
            else if (m_emMainPLCMaker == EMPLCMaker.Rockwell)
            {
                return;
            }
            else
                return;

            //분석을 위해 필요함.
            //m_cLogWriter.WordDeviceList = m_dicWordDevice;

            //Bit 접점 묶어 만든 Word
            foreach (var who in m_dicAllBitData)
            {
                List<CTag> lstTag = new List<CTag>();
                who.Value.SendTextData.Add(who.Key);
                for (int i = 0; i < who.Value.InputWordDeviceList.Count; i++)
                {
                    CDWordDevice cWord = who.Value.InputWordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        who.Value.SendTextData.Add(sData);
                }
                for (int i = 0; i < who.Value.OutputWordDeviceList.Count; i++)
                {
                    CDWordDevice cWord = who.Value.OutputWordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        who.Value.SendTextData.Add(sData);
                }
                for (int i = 0; i < who.Value.M_WordDeviceList.Count; i++)
                {
                    CDWordDevice cWord = who.Value.M_WordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        who.Value.SendTextData.Add(sData);
                }
            }
            m_dicBitBundleSendString.Clear();
            foreach (var who in m_dicPLCTagS)
            {
                List<string> lstTotal = new List<string>();
                if (m_dicAllBitData.ContainsKey(who.Key))
                {
                    if (m_dicAllBitData[who.Key].SendTextData.Count > 0)
                        lstTotal.AddRange(m_dicAllBitData[who.Key].SendTextData);
                    else
                        lstTotal.Add(who.Key);
                }
                else
                    lstTotal.Add(who.Key);

                if (lstTotal.Count > 0)
                {
                    //전체 BIT 묶음은 준비 완료 에러발생시 모든 Bit 접점+하위 Depth Word접점추가로 해서 수집 요청해서 처리
                    m_dicBitBundleSendString.Add(who.Key, lstTotal);
                    //SendTagList(lstTotal.ToArray());
                    //UpdateSystemMessage("Send Tag List", string.Format("SPD ID : {0}, Send Tag Count : {1}", who.Key, lstTotal.Count - 1));
                }
            }
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
                System.Windows.Forms.MessageBox.Show("Connection to the Tracker is lost.", "Tracker Reader", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                chkTracker.Enabled = false;
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
                System.Windows.Forms.MessageBox.Show("Connection to the Tracker is lost.", "Tracker Manager", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                chkTracker.Enabled = false;
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
            if (saData[0] == "SaveAllTagS")
            {
                //프로젝트 Open시점, PLC 변경 시점에 들어옴.
                if (File.Exists(saData[1]))
                {
                    OpenTotalTagS(saData[1]);
                    File.Delete(saData[1]);
                    tmrReceiveAllTagS.Start();
                }
            }
            else if(saData[0] == "ClearTagS")
            {
                //프로젝트 Open시점, PLC 변경 시점에 들어옴.
                m_cTotalTagS.Clear();
                m_dicPLCTagS.Clear();

                grdTotalTagS.DataSource = m_cTotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
            }
            else
            {
                //기존 SPD Single로 전달하는 코드
                for (int i = 0; i < saData.Length; i++)
                    sData += saData[i] + ", ";
                UpdateSystemMessage("UEventReceiveTagList", sData);
                SendTagList(saData);
            }
        }

        void ServiceCallBack_UEventReceiveEmergTagList(object sender, string[] saData)
        {
            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveEmergTagList", sData);

            //긴급 처리 접점
            if (m_emMainPLCMaker == EMPLCMaker.Siemens)
            {
                List<string> lstTotal = SendEmergTagStringList(saData);
                SendEmergTagList(lstTotal.ToArray());
            }
            else
            {
                SendEmergTagList(saData);
            }
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
            if (m_cServer.IsRunning == false) return;
            string sData = "";
            for (int i = 0; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage("UEventReceiveCollectorList", sData);

            m_sConfigFilePath = saData[0];

            List<string> lstPlcID = new List<string>();
            for (int i = 1; i < saData.Length; i++)
                lstPlcID.Add(saData[i]);

            
            OpenConfigS(m_sConfigFilePath);

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

            if (sData.Equals("Manager Close"))
            {
                m_bManagerClose = true;
                this.Close();
            }
            else
                SendStopCommand(saData);

            //if (sData.Contains("Close"))
            //{
            //    this.Close();
            //}
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

        /// <summary>
        /// Tracker로부터 경로를 받아 프로젝트의 전체 tag정보를 모두 받아들임.
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        private bool OpenTotalTagS(string sFilePath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();
            CTagS cTagS = (CTagS)(cSerializer.Read(sFilePath));
            if (cTagS != null)
            {
                m_cTotalTagS = cTagS;
                bOK = true;
                if (m_cTotalTagS.Count > 0)
                {
                    m_emMainPLCMaker = m_cTotalTagS.Values.First().PLCMaker;
                }
                grdTotalTagS.DataSource = m_cTotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
            }

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private bool CompareFirstChar(string sAddress, char cCompare)
        {
            bool bOK = false;

            if (sAddress.Length > 0)
            {
                if (sAddress[0] == cCompare)
                    bOK = true;
            }

            return bOK;
        }

        private void SetSiemensBundle()
        {
            Dictionary<string, CBitDevice> dicBitDevice = new Dictionary<string, CBitDevice>();
            foreach (var who in m_dicPLCTagS)
            {
                CAllBitDevice cAllBitDevice = new CAllBitDevice();
                m_dicAllBitData.Add(who.Key, cAllBitDevice);
                CTagS cTagS = who.Value;
                string sChannel = "[" + cTagS.Values.First().Channel + "]";
                string sSize = "[1]";
                List<CTag> lstInputTag = new List<CTag>();
                List<CTag> lstOutputTag = new List<CTag>();
                List<CTag> lstM_Tag = new List<CTag>();

                lstInputTag = cTagS.Values.Where(b => CompareFirstChar(b.Address, 'I') && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();
                lstOutputTag = cTagS.Values.Where(b => CompareFirstChar(b.Address, 'Q') && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();
                lstM_Tag = cTagS.Values.Where(b => CompareFirstChar(b.Address, 'M') && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();

                if (lstInputTag != null)
                {
                    List<CBitDevice> lstInputBitTag = CreateBitTag(lstInputTag, "I");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstInputBitTag, "I");
                    List<CDWordDevice> lstDWordTag = CreateDWordTag(lstByteTag, "ID");
                    cAllBitDevice.InputWordDeviceList = lstDWordTag;
                    for (int i = 0; i < lstInputBitTag.Count; i++)
                        dicBitDevice.Add(lstInputBitTag[i].Tag.Key, lstInputBitTag[i]);
                    for (int i = 0; i < lstDWordTag.Count; i++)
                        m_dicDWordDevice.Add(sChannel + lstDWordTag[i].ReadAddress + sSize, lstDWordTag[i]);
                }
                if (lstOutputTag != null)
                {
                    List<CBitDevice> lstOutputBitTag = CreateBitTag(lstOutputTag, "Q");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstOutputBitTag, "Q");
                    List<CDWordDevice> lstDWordTag = CreateDWordTag(lstByteTag, "QD");
                    cAllBitDevice.OutputWordDeviceList = lstDWordTag;
                    for (int i = 0; i < lstOutputBitTag.Count; i++)
                        dicBitDevice.Add(lstOutputBitTag[i].Tag.Key, lstOutputBitTag[i]);
                    for (int i = 0; i < lstDWordTag.Count; i++)
                        m_dicDWordDevice.Add(sChannel + lstDWordTag[i].ReadAddress + sSize, lstDWordTag[i]);

                }
                if (lstM_Tag != null)
                {
                    List<CBitDevice> lstM_BitTag = CreateBitTag(lstM_Tag, "M");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstM_BitTag, "M");
                    List<CDWordDevice> lstDWordTag = CreateDWordTag(lstByteTag, "MD");
                    cAllBitDevice.M_WordDeviceList = lstDWordTag;
                    for (int i = 0; i < lstM_BitTag.Count; i++)
                        dicBitDevice.Add(lstM_BitTag[i].Tag.Key, lstM_BitTag[i]);
                    for (int i = 0; i < lstDWordTag.Count; i++)
                        m_dicDWordDevice.Add(sChannel + lstDWordTag[i].ReadAddress + sSize, lstDWordTag[i]);
                }
            }

        }

        /// <summary>
        /// 전체 Bit접점과 긴급 수집요청대상중 Word만 골라 수집요청
        /// </summary>
        /// <param name="saData"></param>
        /// <returns></returns>
        private List<string> SendEmergTagStringList(string[] saData)
        {
            string sID = saData[0];
            List<string> lstWordTagString = new List<string>();
            for (int i = 2; i < saData.Length; i++)
            {
                string[] sSplit = saData[i].Split(',');
                if (sSplit.Length != 4)
                {
                    UpdateSystemMessage("ReceiveTag", "Error : " + saData[i] + " 형식이 틀렸습니다.");
                    continue;
                }
                else
                {
                    int iLength = -1;
                    bool bOK = int.TryParse(sSplit[3], out iLength);
                    if (bOK)
                    {
                        string sKey = sSplit[0];
                        if (m_cTotalTagS.ContainsKey(sKey))
                        {
                            if (m_cTotalTagS[sKey].DataType != EMDataType.Bool)
                                lstWordTagString.Add(saData[i]);
                        }
                    }
                }
            }
            List<string> lstTotal = new List<string>();
            lstTotal.Add(sID);
            lstTotal.Add(saData[1]);
            lstTotal.AddRange(m_dicBitBundleSendString[sID]);
            lstTotal.AddRange(lstWordTagString);

            return lstTotal;
        }

        private bool OpenConfigS(string sPath)
        {
            bool bOK = false;
            CPlcConfigS cConfigS = new CPlcConfigS();
            m_cConfigS = cConfigS.OpenPlcConfigS(sPath);
            if (m_cConfigS != null)
            {
                bOK = true;
                UpdateSystemMessage("OpenConfigS", "열기 성공");
                //foreach (var who in m_cConfigS)
                //{
                //    if (who.Value.CollectType == EMCollectType.OPC)
                //        m_dicMelsecOpcUse.Add(who.Key, true);
                //    else
                //    {
                //        if (m_dicMelsecOpcUse.ContainsKey(who.Key) == false)
                //            m_dicMelsecOpcUse.Add(who.Key, false);
                //    }
                //}
            }
            else
                UpdateSystemMessage("OpenConfigS", "파일을 열수 없습니다. : " + sPath);
            return bOK;
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
            //지멘스 전체 Bit 분석해야함.
            if (m_emMainPLCMaker == EMPLCMaker.Siemens)
            {
                CAnalyzeEmergData cAnalyzeEmergData = new CAnalyzeEmergData();
                cAnalyzeEmergData.ReceiveData = (string[])saData.Clone();
                cAnalyzeEmergData.PLCMaker = m_emMainPLCMaker;
                cAnalyzeEmergData.DWordDevice = m_dicDWordDevice;
                cAnalyzeEmergData.TotalTagS = m_cTotalTagS;
                cAnalyzeEmergData.UEventSendLogStringArray += cAnalyzeEmergData_UEventSendLogStringArray;
                cAnalyzeEmergData.UEventMessage += cAnalyzeEmergData_UEventMessage;
                cAnalyzeEmergData.Run();
            }
            else
            {
                SendEmergTimeLogS(saData);
            }
        }

        void cAnalyzeEmergData_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        void cAnalyzeEmergData_UEventSendLogStringArray(string[] saSendData)
        {
            SendEmergTimeLogS(saSendData);
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
                tpSPDSingles.Text = string.Format("SPD Singles ( {0} )", sCount);
                UpdateSystemMessage("Disconnection", sClient);
                string[] saData = { sClient, "Error" };
                SendStatus(saData);
                if (m_dicClient.Count == 0)
                    chkSPDSingle.Enabled = false;
                else
                    chkSPDSingle.Enabled = true;
            }
        }

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            CService cService = (CService)sender;
            if (m_dicClient.ContainsKey(sClient) == false)
            {
                m_dicClient.Add(sClient, cService);
                string sCount = m_dicClient.Count.ToString();
                tpSPDSingles.Text = string.Format("SPD Singles ( {0} )", sCount);
                UpdateSystemMessage("Connection", sClient);
                if (m_dicClient.Count == 0)
                    chkSPDSingle.Enabled = false;
                else
                    chkSPDSingle.Enabled = true;
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


        #region 파생 함수

        private string GetByteAddress(string sHeader, string sAddress)
        {
            string[] saSplitDot = sAddress.Split('.');
            return saSplitDot[0].Replace(sHeader, "");
        }

        private int GetMajorNumber(string sHeader, string sAddress, bool bMajor)
        {
            string[] saSplitDot = sAddress.Split('.');
            string sMajor = saSplitDot[0].Replace(sHeader, "");
            
            int iValue = -1;

            bool bOK = false;
            if (bMajor == false)
            {
                bOK = int.TryParse(saSplitDot[1], out iValue);
                if (bOK == false)
                    return -1;
            }
            else
            {
                bOK = int.TryParse(sMajor, out iValue);
                if (bOK == false)
                    return -1;
            }
            return iValue;
        }

        /// <summary>
        /// BitTag 생성 및 Sort
        /// </summary>
        /// <param name="lstTag"></param>
        /// <param name="sHeader"></param>
        /// <returns></returns>
        private List<CBitDevice> CreateBitTag(List<CTag> lstTag, string sHeader)
        {
            List<CBitDevice> lstResult = new List<CBitDevice>();

            for (int i = 0; i < lstTag.Count; i++)
            {
                CBitDevice cTag = new CBitDevice();

                cTag.Tag = lstTag[i];
                cTag.MajorNumber = GetMajorNumber(sHeader, cTag.Tag.Address, true);
                cTag.MinorNumber = GetMajorNumber(sHeader, cTag.Tag.Address, false);

                lstResult.Add(cTag);
            }

            lstResult.Sort(new CBitTagComparer());
            return lstResult;
        }

        private List<CByteDevice> CreateByteTag(List<CBitDevice> lstBitTag, string sHeader)
        {
            List<CByteDevice> lstResult = new List<CByteDevice>();
            if (lstBitTag.Count == 0) return lstResult;

            int iBaseAddress = lstBitTag[0].MajorNumber;
            CByteDevice cByteTag = new CByteDevice();
            cByteTag.BitDeviceList.Add(lstBitTag[0]);
            cByteTag.MajorString = GetByteAddress(sHeader, lstBitTag[0].Tag.Address);
            cByteTag.MaskValue = (byte)(0x1 << lstBitTag[0].MinorNumber);
            cByteTag.MajorNumber = iBaseAddress;

            for (int i = 1; i < lstBitTag.Count; i++)
            {
                if (iBaseAddress != lstBitTag[i].MajorNumber)
                {
                    lstResult.Add(cByteTag);
                    iBaseAddress = lstBitTag[i].MajorNumber;
                    cByteTag = new CByteDevice();
                    cByteTag.BitDeviceList.Add(lstBitTag[i]);
                    cByteTag.MajorString = GetByteAddress(sHeader, lstBitTag[i].Tag.Address);
                    cByteTag.MaskValue = (byte)(0x1 << lstBitTag[i].MinorNumber);
                    cByteTag.MajorNumber = iBaseAddress;
                }
                else
                {
                    cByteTag.BitDeviceList.Add(lstBitTag[i]);
                    cByteTag.MaskValue += (byte)(0x1 << lstBitTag[i].MinorNumber);
                }
            }
            if (cByteTag.BitDeviceList.Count > 0)
            {
                lstResult.Add(cByteTag);
            }

            return lstResult;
        }

        private List<CDWordDevice> CreateDWordTag(List<CByteDevice> lstByteTag, string sHeader)
        {
            List<CDWordDevice> lstResult = new List<CDWordDevice>();

            if (lstByteTag.Count == 0) return lstResult;

            CDWordDevice cDwordTag = new CDWordDevice(); ;
            int iBaseNumber = lstByteTag[0].MajorNumber;
            lstByteTag[0].Used = true;
            cDwordTag.Byte1 = lstByteTag[0];
            cDwordTag.MajorNumber = lstByteTag[0].MajorNumber;
            cDwordTag.ReadMajor = lstByteTag[0].MajorString;
            cDwordTag.ReadAddress = sHeader + lstByteTag[0].MajorString;
            cDwordTag.Channel = lstByteTag[0].BitDeviceList[0].Tag.Channel;

            for (int i = 1; i < lstByteTag.Count; i++)
            {
                if (iBaseNumber + 3 < lstByteTag[i].MajorNumber)
                {
                    lstResult.Add(cDwordTag);
                    iBaseNumber = lstByteTag[i].MajorNumber;

                    cDwordTag = new CDWordDevice();
                    lstByteTag[i].Used = true;
                    cDwordTag.Byte1 = lstByteTag[i];
                    cDwordTag.MajorNumber = lstByteTag[i].MajorNumber;
                    cDwordTag.ReadMajor = lstByteTag[i].MajorString;
                    cDwordTag.ReadAddress = sHeader + lstByteTag[i].MajorString;
                    cDwordTag.Channel = lstByteTag[i].BitDeviceList[0].Tag.Channel;
                }
                else
                {
                    //워드 위치 분석
                    if (iBaseNumber + 1 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte2 = lstByteTag[i];
                    }
                    else if (iBaseNumber + 2 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte3 = lstByteTag[i];
                    }
                    else if (iBaseNumber + 3 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cDwordTag.Byte4 = lstByteTag[i];
                    }
                    else
                    {
                        int a = 0;
                    }

                }
            }

            if (cDwordTag.Byte1.Used || cDwordTag.Byte2.Used || cDwordTag.Byte3.Used || cDwordTag.Byte4.Used)
            {
                lstResult.Add(cDwordTag);
            }

            return lstResult;
        }


        private List<CWordDevice> CreateWordTag(List<CByteDevice> lstByteTag, string sHeader)
        {
            List<CWordDevice> lstResult = new List<CWordDevice>();

            if (lstByteTag.Count == 0) return lstResult;

            CWordDevice cWordTag = new CWordDevice(); ;
            int iBaseNumber = lstByteTag[0].MajorNumber;
            lstByteTag[0].Used = true;
            cWordTag.Byte1 = lstByteTag[0];
            cWordTag.MajorNumber = lstByteTag[0].MajorNumber;
            cWordTag.ReadMajor = lstByteTag[0].MajorString;
            cWordTag.ReadAddress = sHeader + lstByteTag[0].MajorString;
            cWordTag.Channel = lstByteTag[0].BitDeviceList[0].Tag.Channel;

            for (int i = 1; i < lstByteTag.Count; i++)
            {
                if (iBaseNumber + 1 < lstByteTag[i].MajorNumber)
                {
                    lstResult.Add(cWordTag);
                    iBaseNumber = lstByteTag[i].MajorNumber;

                    cWordTag = new CWordDevice();
                    lstByteTag[i].Used = true;
                    cWordTag.Byte1 = lstByteTag[i];
                    cWordTag.MajorNumber = lstByteTag[i].MajorNumber;
                    cWordTag.ReadMajor = lstByteTag[i].MajorString;
                    cWordTag.ReadAddress = sHeader + lstByteTag[i].MajorString;
                    cWordTag.Channel = lstByteTag[i].BitDeviceList[0].Tag.Channel;
                }
                else
                {
                    //워드 위치 분석
                    if (iBaseNumber + 1 == lstByteTag[i].MajorNumber)
                    {
                        lstByteTag[i].Used = true;
                        cWordTag.Byte2 = lstByteTag[i];
                    }
                    else
                    {
                        int a = 0;
                    }

                }
            }

            if (cWordTag.Byte1.Used || cWordTag.Byte2.Used)
            {
                lstResult.Add(cWordTag);
            }

            return lstResult;
        }

        public string CreateItem(string sChannel, string sSendAddress, EMDataType emDataType, int iSize)
        {
            if (sSendAddress.Trim() == "")
                return "";
            string sKey = "[" + sChannel + "]" + sSendAddress + "[1]";
            string sLine = sKey + "," + sSendAddress + "," + emDataType.ToString() + "," + iSize.ToString();

            return sLine;
        }

        public string CreateItem(CTag cTag)
        {
            if (cTag.Address.Trim() == "")
                return "";
            string sLine = cTag.Key + "," + cTag.Address + "," + cTag.DataType.ToString() + "," + cTag.Size.ToString();

            return sLine;
        }

        private CTag CreateTag(string sAddress, string sChannel)
        {
            CTag cTag = new CTag();
            cTag.Channel = sChannel;
            cTag.Address = sAddress;
            cTag.DataType = EMDataType.DWord;
            cTag.Key = "[" + sChannel + "]" + "." + sAddress;
            cTag.Size = 1;
            return cTag;
        }

        public List<CViewTag> GetSelectedTagS()
        {
            List<CViewTag> cTagS = new List<CViewTag>();

            int[] iaRowIndex = grvTotalTagS.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CViewTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CViewTag)grvTotalTagS.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        cTagS.Add(cTag);
                }
            }

            return cTagS;
        }

        public CTimeLog CreateTimeLog(string sLine)
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

        private CTimeLogS CreateTimeLogS(string[] saData)
        {
            string sClient = "";

            if (saData != null)
            {
                sClient = saData[saData.Length - 1];

                CTimeLogS cLogS = new CTimeLogS();
                CTimeLog cLog = null;

                for (int i = 0; i < saData.Length; i++)
                {
                    cLog = CreateTimeLog(saData[i]);

                    if (cLog != null)
                        cLogS.Add(cLog);
                }
                if (cLogS.Count > 0)
                    return cLogS;
            }
            return null;
        }

        private string[] CreateSendStringFromTimeLog(CTimeLogS cLogS, string sID)
        {
            string[] saSendData = new string[cLogS.Count + 1];

            saSendData[0] = sID;
            for (int i = 0; i < cLogS.Count; i++)
            {
                string sValue = "";
                CTimeLog cLog = cLogS[i];
                if (cLog.SValue.Trim() != "")
                    sValue = cLog.SValue;
                else
                    sValue = cLog.Value.ToString();

                string sSend = string.Format("{0},{1},{2}", cLog.Time.ToString("yyyyMMddHHmmss.fff"), cLog.Key, sValue);
                saSendData[i] = sSend;
            }
            saSendData[cLogS.Count] = sID;

            return saSendData;
        }

        #endregion

        private void chkSPDSingle_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //테스트 코드
            if (chkSPDSingle.Checked == true)
            {
                string[] saPath = { "6D9EE83C-0", m_sConfigFilePath };
                SendCollectorList(saPath);
            }
        }


    }
}