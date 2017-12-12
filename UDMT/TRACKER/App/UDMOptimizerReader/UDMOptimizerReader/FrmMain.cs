using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TrackerCommon;
using TrackerSPD.OPC;
using TrackerWCF;
using UDM.Common;
using UDM.General.Remote;
using UDM.General.Serialize;
using UDM.Log;
using UDM.Log.DB;

namespace UDMOptimizerReader
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private CServer<IMyService, CMyService> m_cServer = null;
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected Dictionary<string, CService> m_dicClient = new Dictionary<string, CService>();
        protected Dictionary<string, XtraTabPage> m_dicSPDTabPage = new Dictionary<string, XtraTabPage>();
        protected Dictionary<string, CAllBitDevice> m_dicAllBitData = new Dictionary<string, CAllBitDevice>();
        protected Dictionary<string, CWordDevice> m_dicWordDevice = new Dictionary<string, CWordDevice>();
        protected Dictionary<string, CTag> m_dicUserAddTag = new Dictionary<string, CTag>();
        protected CSPDManagerLogWriter m_cLogWriter = new CSPDManagerLogWriter();
        protected CDB_Control m_cDBControl = new CDB_Control();

        protected CProject m_cProject = new CProject();

        protected string m_sDBBackupPath = Application.StartupPath + "\\TrackerDBBackup";
        //protected string m_sConfigFilePath = "";
        protected int m_iTabCount = 0;
        protected string[] m_saTestString = null;
        protected bool m_bStart = false;
        protected bool m_bDragDropReady = false;
        protected bool m_bSPDOpenComp = false;
        protected bool m_bConnect = false;

        #region Embedded

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
        }


        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bool bOK = StartServer();
            
            //전체 실행 중인 SPD Single을 종료시킴
            Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
            foreach (Process pro in aProcess)
            {
                pro.Kill();
            }

            tabCollectApp.TabPages.Clear();

            m_cLogWriter.UEventMessage += m_cLogWriter_UEventMessage;
            m_cLogWriter.UEventLogWriteTimeLogS += m_cLogWriter_UEventLogWriteTimeLogS;
            m_cDBControl.ActiveStep = 0;
            m_cDBControl.Run();
        }

        private void m_cLogWriter_UEventLogWriteTimeLogS(CTimeLogS cLogS)
        {
            if (cLogS != null && cLogS.Count > 0)
            {
                foreach (CTimeLog cLog in cLogS)
                {
                    if (m_cProject.ViewTagS != null && m_cProject.ViewTagS.Count > 0)
                    {
                        if (m_cProject.ViewTagS.ContainsKey(cLog.Key))
                        {
                            m_cProject.ViewTagS[cLog.Key].CurrentValue = cLog.Value;
                        }
                    }
                }
                //grdBitDevice.RefreshDataSource();
            }
        }

        private void m_cLogWriter_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrAutoMode.Stop();
            m_cDBControl.Stop();
            m_cLogWriter.UEventMessage -= m_cLogWriter_UEventMessage;
            m_cLogWriter.UEventLogWriteTimeLogS -= m_cLogWriter_UEventLogWriteTimeLogS;
            if (m_bStart)
                btnSPDStop_Click(null, null);
            StopServer();

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

        #region User Event

        private void SendTimeLogS(string[] saData)
        {
            try
            {
                //m_cClient.Service.SendTimeLogSToServer(saData);
                CTimeLogS cLogS = CreateTimeLogS(saData);
                CTimeLogS cPasingLogS = new CTimeLogS();
                if (cLogS != null)
                {
                    //UpdateSystemMessage("SendTimeLogS", "LogCount : " + cLogS.Count.ToString());
                    for (int i = 0; i < cLogS.Count; i++)
                    {
                        CTimeLog cLog = cLogS[i];
                        if (m_dicWordDevice.ContainsKey(cLog.Key))
                        {
                            CWordDevice cWordDevice = m_dicWordDevice[cLog.Key];
                            cPasingLogS.AddRange(cWordDevice.GetTimeLogSChangedTag(cLog));
                        }
                    }
                    if (cPasingLogS != null && cPasingLogS.Count > 0)
                    {
                        //UpdateSystemMessage("SendTimeLogS", "cPasingLogS : " + cPasingLogS.Count.ToString());
                        m_cLogWriter.EnQue((CTimeLogS)cPasingLogS.Clone());

                        //grdBitDevice.RefreshDataSource();
                    }
                }
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
                    //m_cServer.Service.SendTrackerStatusTOSPDManager +=  
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

                string[] saPath = { lstPlcID[i], m_cProject.AutoConfigPath };
                SendCollectorList(saPath);
                UpdateSystemMessage("Send", lstPlcID[i] + "의 ConfigPath가 전달되었습니다");
            }
            //this.SendToBack();

            for (int i = 0; i < tabCollectApp.TabPages.Count; i++)
            {
                Process pro = (Process)tabCollectApp.TabPages[i].Tag;
                ResizeEmbeddedApp(pro, tabCollectApp.TabPages[i]);
            }
            if (lstPlcID.Count > 0)
                m_bSPDOpenComp = true;
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

        private void SetTrackerLamp(bool bFail)
        {
            //if (bFail)
            //{
            //    btnTrackerConnect.Appearance.BackColor = Color.Red;
            //    btnTrackerConnect.Appearance.BackColor2 = Color.OrangeRed;
            //}
            //else
            //{
            //    btnTrackerConnect.Appearance.BackColor = Color.Lime;
            //    btnTrackerConnect.Appearance.BackColor2 = Color.Green;
            //}
        }

        private void SetManagerLamp(bool bFail)
        {
            //if (bFail)
            //{
            //    btnManagerServer.Appearance.BackColor = Color.Red;
            //    btnManagerServer.Appearance.BackColor2 = Color.OrangeRed;
            //}
            //else
            //{
            //    btnManagerServer.Appearance.BackColor = Color.Lime;
            //    btnManagerServer.Appearance.BackColor2 = Color.Green;
            //}
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
            //SendEmergTagList(saData);
        }

        private void Service_UEventReceiveErrorTagList(object sender, string[] saData)
        {
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
            //SendErrorTagList(saData);
        }

        private void Service_UEventReceiveStatus(object sender, string[] saData)
        {
            //if (saData.Length < 2) return;
            //SendStatus(saData);
        }

        private void Service_UEventReceiveTimeLogS(object sender, string[] saData)
        {
            //SendTimeLogS(saData);
            if (m_cLogWriter.IsRunning)
                m_cLogWriter.EnQue((string[])saData.Clone());
        }

        private void Service_UEventReceiveEmergTimeLogS(object sender, string[] saData)
        {
            //SendEmergTimeLogS(saData);
        }

        private void Service_UEventReceiveRecipeLogS(object sender, string[] saData)
        {
            //SendRecipeLogS(saData);
        }

        private void Service_UEventClientDisconnected(object sender, string sClient)
        {
            if (m_dicClient.ContainsKey(sClient))
            {
                m_dicClient.Remove(sClient);
                string sCount = m_dicClient.Count.ToString();
                //SetManagerLamp(false, sCount);
                UpdateSystemMessage("Disconnection", sClient);
                string[] saData = { sClient, "Error" };
                //SendStatus(saData);
            }
        }

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            CService cService = (CService)sender;
            if (m_dicClient.ContainsKey(sClient) == false)
            {
                m_dicClient.Add(sClient, cService);
                string sCount = m_dicClient.Count.ToString();
                //SetManagerLamp(false, sCount);
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
            if (bMajor == false)
                return Convert.ToInt32(saSplitDot[1]);
            return Convert.ToInt32(sMajor);
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
            string sKey = "[" + sChannel + "]"  + sSendAddress + "[1]";
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
                    {
                        cLogS.Add(cLog);
                        if (m_cProject.ViewTagS != null && m_cProject.ViewTagS.Count > 0)
                        {
                            if (m_cProject.ViewTagS.ContainsKey(cLog.Key))
                            {
                                m_cProject.ViewTagS[cLog.Key].CurrentValue = cLog.Value;
                            }
                        }
                    }
                }
                if (cLogS.Count > 0)
                {
                    return cLogS;
                }
            }
            return null;
        }

        public void DBBackup(string sDBPath, string sPath)
        {
            try
            {
                string sError = string.Empty;

                using (Process mysqlDump = new Process())
                {
                    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                    {
                        //Maria DB의 경우 Path 다름
                        //mysqlDump.StartInfo.FileName =
                        //    @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                        mysqlDump.StartInfo.FileName = sDBPath;
                        //@"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                        mysqlDump.StartInfo.UseShellExecute = false;
                        mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -r \"{0}\"", sPath);
                        mysqlDump.StartInfo.RedirectStandardInput = false;
                        mysqlDump.StartInfo.RedirectStandardOutput = false;
                        mysqlDump.StartInfo.RedirectStandardError = true;
                        mysqlDump.StartInfo.CreateNoWindow = true;
                        mysqlDump.Start();

                        sError = mysqlDump.StandardError.ReadToEnd();
                    }
                    SplashScreenManager.CloseForm(false);
                    if (m_cProject.IsAutoMode == false)
                    {
                        if (sError != string.Empty)
                            MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("DB Backup Success!!", "DB Backup", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    mysqlDump.WaitForExit();
                    mysqlDump.Close();
                }

                string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                if (sError == string.Empty && Directory.Exists(sFolderPath))
                    Process.Start(sFolderPath);
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private List<string> ValidateOPC(CPlcConfig cConfig, List<CTag> lstTag)
        {
            List<string> lstError = new List<string>();

            try
            {
                COPCServer cOPCServer = new COPCServer();
                cOPCServer.Config = new COPCConfig();
                cOPCServer.Config.Use = true;
                cOPCServer.Config.ABOpc = cConfig.OPCConfig.ABOpc;
                cOPCServer.Config.LsOpc = cConfig.OPCConfig.LsOpc;
                cOPCServer.Config.ServerName = cConfig.OPCConfig.ServerName;
                cOPCServer.Config.ChannelDevice = cConfig.OPCConfig.ChannelDevice;
                cOPCServer.Config.UpdateRate = cConfig.OPCConfig.UpdateRate;

                bool bOK = cOPCServer.Connect();

                if (bOK)
                {
                    List<string> lstResult = cOPCServer.ValidateItemS(lstTag);
                    if (lstResult != null && lstResult.Count != 0)
                        lstError.AddRange(lstResult);
                }
                else
                    MessageBox.Show("OPC Server가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);


                cOPCServer.Disconnect();
                cOPCServer.Dispose();
                cOPCServer = null;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
            return lstError;
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

        private bool OpenConfig(string sPath, string sID)
        {
            CPlcConfigS cConfigS = new CPlcConfigS();
            if (m_cProject.SPDConfigS.ContainsKey(sID) == false)
            {
                CPlcConfig cConfigBuf = cConfigS.OpenPlcConfigS(sPath, sID);
                if (cConfigBuf != null)
                    m_cProject.SPDConfigS.Add(sID, cConfigBuf);
                else
                {
                    UpdateSystemMessage("Config", sID + " 해당 설정은 찾을 수 없습니다.");
                    UpdateSystemMessage("Config", sPath);

                    return false;
                }
            }
            
            return true;
        }

        private void ValidateOPC(CPlcConfig cConfig, CTagS cTagS)
        {
            List<string> lstError = new List<string>();

            try
            {
                COPCServer cOPCServer = new COPCServer();
                cOPCServer.Config = new COPCConfig();
                cOPCServer.Config.Use = true;
                cOPCServer.Config.ABOpc = cConfig.OPCConfig.ABOpc;
                cOPCServer.Config.LsOpc = cConfig.OPCConfig.LsOpc;
                cOPCServer.Config.ServerName = cConfig.OPCConfig.ServerName;
                cOPCServer.Config.ChannelDevice = cConfig.OPCConfig.ChannelDevice;
                cOPCServer.Config.UpdateRate = cConfig.OPCConfig.UpdateRate;

                bool bOK = cOPCServer.Connect();

                if (bOK)
                {
                    List<string> lstResult = cOPCServer.ValidateItemS(cTagS.Values.ToList());
                    if (lstResult != null && lstResult.Count != 0)
                        lstError.AddRange(lstResult);
                }
                else
                {
                    XtraMessageBox.Show("OPC Server가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var who in cTagS)
                {
                    if (lstError.Contains(who.Key))
                        who.Value.IsCollectUsed = false;
                    else
                        who.Value.IsCollectUsed = true;
                }
                cOPCServer.Disconnect();
                cOPCServer.Dispose();
                cOPCServer = null;
                UpdateSystemMessage("TagValidate", "적용완료");
            }
            catch (System.Exception ex)
            {
                UpdateSystemMessage("ValidateOPC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        #endregion

        private void btnOpenLogic_Click(object sender, EventArgs e)
        {
            if (m_cProject.LogicTagS == null)
                m_cProject.LogicTagS = new Dictionary<string, CTagS>();
            else
                m_cProject.LogicTagS.Clear();

            List<string> lstPlcID = new List<string>();
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Multiselect = true;
            dlgOpen.Filter = ".pcd|*.pcd";
            DialogResult dlgResult = dlgOpen.ShowDialog();
            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            m_cProject.AutoLogicFilePathList = dlgOpen.FileNames.ToList();
            
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            for (int i = 0; i < dlgOpen.FileNames.Length; i++)
            {
                string sFilePath = dlgOpen.FileNames[i];
                CNetSerializer cSerializer = new CNetSerializer();
                try
                {
                    CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sFilePath));
                    if (cPlcLogicData != null)
                    {
                        cPlcLogicData.Compose();
                        m_cProject.LogicTagS.Add(cPlcLogicData.PLCID, cPlcLogicData.TagS);
                    }

                    cSerializer.Dispose();
                    cSerializer = null;

                    foreach (CTag cTag in cPlcLogicData.TagS.Values)
                    {
                        CViewTag cViewTag = new CViewTag();
                        cViewTag.CollectUse = false;
                        cViewTag.Tag = cTag;

                        m_cProject.ViewTagS.Add(cTag.Key, cViewTag);
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
            }
            grdTotalTagS.DataSource = m_cProject.ViewTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            SplashScreenManager.CloseForm(false);
        }

        private void btnLoadSPD_Click(object sender, EventArgs e)
        {
            //string sConfigPath = @"C:\2017\프로젝트\염성\염성\SIDE_LH_TEST\PLC 통신설정.plccfg";
            if (m_cProject.SPDConfigS == null)
                m_cProject.SPDConfigS = new Dictionary<string, CPlcConfig>();
            else
                m_cProject.SPDConfigS.Clear();
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Multiselect = false;
            dlgOpen.Filter = ".plccfg|*.plccfg";
            DialogResult dlgResult = dlgOpen.ShowDialog();
            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            m_cProject.AutoConfigPath = dlgOpen.FileName;
            List<string> lstPlcID = new List<string>();
            foreach (var who in m_cProject.LogicTagS)
            {
                lstPlcID.Add(who.Key);
                bool bOK = OpenConfig(m_cProject.AutoConfigPath, who.Key);
                if (bOK)
                {
                    ValidateOPC(m_cProject.SPDConfigS[who.Key], who.Value);
                    grdTotalTagS.RefreshDataSource();
                }
            }
            ArrangeSPD(lstPlcID);
        }

        private void btnSendTag_Click(object sender, EventArgs e)
        {
            
            m_dicAllBitData.Clear();
            Dictionary<string, CBitDevice> dicBitDevice = new Dictionary<string, CBitDevice>();
            m_dicWordDevice.Clear();
            m_dicUserAddTag.Clear();
            foreach (var who in m_cProject.ViewTagS.Values.Where(b => b.CollectUse && b.Tag.DataType == EMDataType.Bool).ToList())
                who.CollectUse = false;

            foreach (var who in m_cProject.LogicTagS)
            {
                
                CAllBitDevice cAllBitDevice = new CAllBitDevice();
                m_dicAllBitData.Add(who.Key, cAllBitDevice);
                CTagS cTagS = who.Value;
                string sChannel = "[" + cTagS.Values.First().Channel + "]";
                string sSize = "[1]";
                List<CTag> lstInputTag = new List<CTag>();
                List<CTag> lstOutputTag = new List<CTag>();
                List<CTag> lstM_Tag = new List<CTag>();

                if (chkUseOnlyInLogic.Checked)
                {
                    lstInputTag = cTagS.Values.Where(b => b.Address.Contains("I") && b.IsCollectUsed && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();
                    lstOutputTag = cTagS.Values.Where(b => b.Address.Contains("Q") && b.IsCollectUsed && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();
                    lstM_Tag = cTagS.Values.Where(b => b.Address.Contains("M") && b.IsCollectUsed && b.DataType == EMDataType.Bool && b.UseOnlyInLogic == true).ToList();
                }
                else
                {
                    lstInputTag = cTagS.Values.Where(b => b.Address.Contains("I") && b.IsCollectUsed && b.DataType == EMDataType.Bool).ToList();
                    lstOutputTag = cTagS.Values.Where(b => b.Address.Contains("Q") && b.IsCollectUsed && b.DataType == EMDataType.Bool).ToList();
                    lstM_Tag = cTagS.Values.Where(b => b.Address.Contains("M") && b.IsCollectUsed && b.DataType == EMDataType.Bool).ToList();
                }
                if (lstInputTag != null && chkInput.Checked)
                {
                    List<CBitDevice> lstInputBitTag = CreateBitTag(lstInputTag, "I");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstInputBitTag, "I");
                    List<CWordDevice> lstWordTag = CreateWordTag(lstByteTag, "IW");
                    cAllBitDevice.InputWordDeviceList = lstWordTag;
                    for (int i = 0; i < lstInputBitTag.Count; i++)
                        dicBitDevice.Add(lstInputBitTag[i].Tag.Key, lstInputBitTag[i]);
                    for (int i = 0; i < lstWordTag.Count; i++)
                        m_dicWordDevice.Add(sChannel + lstWordTag[i].ReadAddress + sSize, lstWordTag[i]);
                }
                if (lstOutputTag != null && chkOutput.Checked)
                {
                    List<CBitDevice> lstOutputBitTag = CreateBitTag(lstOutputTag, "Q");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstOutputBitTag, "Q");
                    List<CWordDevice> lstWordTag = CreateWordTag(lstByteTag, "QW");
                    cAllBitDevice.OutputWordDeviceList = lstWordTag;
                    for (int i = 0; i < lstOutputBitTag.Count; i++)
                        dicBitDevice.Add(lstOutputBitTag[i].Tag.Key, lstOutputBitTag[i]);
                    for (int i = 0; i < lstWordTag.Count; i++)
                        m_dicWordDevice.Add(sChannel + lstWordTag[i].ReadAddress + sSize, lstWordTag[i]);

                }
                if (lstM_Tag != null&& chkMemory.Checked)
                {
                    List<CBitDevice> lstM_BitTag = CreateBitTag(lstM_Tag, "M");
                    List<CByteDevice> lstByteTag = CreateByteTag(lstM_BitTag, "M");
                    List<CWordDevice> lstWordTag = CreateWordTag(lstByteTag, "MW");
                    cAllBitDevice.M_WordDeviceList = lstWordTag;
                    for (int i = 0; i < lstM_BitTag.Count; i++)
                        dicBitDevice.Add(lstM_BitTag[i].Tag.Key, lstM_BitTag[i]);
                    for (int i = 0; i < lstWordTag.Count; i++)
                        m_dicWordDevice.Add(sChannel + lstWordTag[i].ReadAddress + sSize, lstWordTag[i]);
                }
            }

            //분석을 위해 필요함.
            m_cLogWriter.WordDeviceList = m_dicWordDevice;
            
            foreach (var who in m_dicAllBitData)
            {
                List<string> lstTotal = new List<string>();
                List<CTag> lstTag = new List<CTag>();
                lstTotal.Add(who.Key);
                for (int i = 0; i < who.Value.InputWordDeviceList.Count; i++)
                {
                    CWordDevice cWord = who.Value.InputWordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        lstTotal.Add(sData);
                }
                for (int i = 0; i < who.Value.OutputWordDeviceList.Count; i++)
                {
                    CWordDevice cWord = who.Value.OutputWordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        lstTotal.Add(sData);
                }
                for (int i = 0; i < who.Value.M_WordDeviceList.Count; i++)
                {
                    CWordDevice cWord = who.Value.M_WordDeviceList[i];
                    lstTag.Add(CreateTag(cWord.ReadAddress, cWord.Channel));
                    string sData = CreateItem(cWord.Channel, cWord.ReadAddress, EMDataType.Word, 1);
                    if (sData != "")
                        lstTotal.Add(sData);
                }

                List<CViewTag> lstUserTag = m_cProject.ViewTagS.Values.Where(b => b.CollectUse && b.Tag.DataType != EMDataType.Bool).ToList();
                for (int i = 0; i < lstUserTag.Count; i++)
                {
                    CTag cTag = lstUserTag[i].Tag;
                    List<CTag> lstFindTag = m_cProject.LogicTagS[who.Key].Values.Where(b => b.Key == cTag.Key && b.IsCollectUsed).ToList();
                    if (lstFindTag == null || lstFindTag.Count == 0)
                        continue;
                    m_dicUserAddTag.Add(cTag.Key, cTag);
                    string sData = CreateItem(cTag);
                    if (sData != "")
                        lstTotal.Add(sData);
                }
                m_cLogWriter.UserAddTagList = m_dicUserAddTag;

                foreach (var who2 in dicBitDevice)
                {
                    if (m_cProject.ViewTagS.ContainsKey(who2.Key))
                        m_cProject.ViewTagS[who2.Key].CollectUse = true;
                }
                //수집 가능 여부 판단
                SendTagList(lstTotal.ToArray());
            }
            grdBitDevice.DataSource = m_cProject.ViewTagS.Values.Where(b => b.CollectUse).ToList();
            grdBitDevice.RefreshDataSource();

        }

        private void btnSPDStart_Click(object sender, EventArgs e)
        {
            bool bOK = m_cLogWriter.Run();
            if (bOK == false)
            {
                UpdateSystemMessage("시작실패", "LogWriter 시작 실패");
                return;
            }

            foreach (var who in m_cProject.LogicTagS)
            {
                string[] saData = { who.Key };
                SendStartCommand(saData);
                m_bStart = true;
            }
            btnSPDStart.Enabled = false;
            btnSPDStop.Enabled = true;
            if (m_cDBControl.IsRunning)
            {
                m_cDBControl.ActiveStep = 0;
                m_cDBControl.Stop();
            }
            if (m_cProject.IsAutoMode)
            {
                tmrAutoMode.Start();
            }
        }

        private void btnSPDStop_Click(object sender, EventArgs e)
        {

            foreach (var who in m_cProject.LogicTagS)
            {
                string[] saData = { who.Key };
                SendStopCommand(saData);
                m_bStart = false;
            }

            m_cLogWriter.Stop();
            if (m_cProject.IsAutoMode)
            {
                m_cDBControl.ActiveStep = 0;
                m_cDBControl.Run();
            }
            btnSPDStart.Enabled = true;
            btnSPDStop.Enabled = false;
        }

        private void btnDBClera_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "데이터 베이스를 새롭게 생성합니다.\r\n데이터 베이스 생성시 저장된 모든 데이터가 지워집니다.\r\n데이터 베이스를 생성하시겠습니까?";

                if (m_cProject.IsAutoMode == false)
                {
                    if (MessageBox.Show(sMessage, "UDM Optimizer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;
                }
                bool bOK = true;

                CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
                bOK = cLogWriter.CreateDB();

                cLogWriter.Dispose();
                cLogWriter = null;

                if (m_cProject.IsAutoMode == false)
                {
                    if (bOK == false)
                        MessageBox.Show("DB를 생성할 수 없습니다. DB 설치를 다시 확인해주세요!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("DB 생성 성공!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDBBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "축적된 데이터 베이스를 백업합니다.\r\n데이터 베이스 백업을 진행하시겠습니까?";
                if (m_cProject.IsAutoMode == false)
                {
                    if (MessageBox.Show(sMessage, "DB 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.No)
                        return;
                }
                string sDBPath = "";
                if (rbMysql.Checked)
                    sDBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                else
                    sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                //string sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                string sPath = m_cProject.DBBackupPath + "\\" + string.Format("DB_Backup_{0}", DateTime.Now.ToString("yyyyMMdd") + ".sql");
                
                if (!File.Exists(sDBPath))
                {
                    if (m_cProject.IsAutoMode == false)
                        MessageBox.Show("DB Path가 존재하지 않습니다.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (m_cProject.IsAutoMode == false)
                {
                    SaveFileDialog dlgSave = new SaveFileDialog();
                    dlgSave.Filter = ".sql|*.sql";
                    dlgSave.Title = "데이터 베이스 백업 파일 저장";
                    dlgSave.FileName = string.Format("DB_Backup_{0}", DateTime.Now.ToString("yyyyMMdd"));

                    if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    {
                        dlgSave.Dispose();
                        dlgSave = null;
                        return;
                    }
                    sPath = dlgSave.FileName;

                    dlgSave.Dispose();
                    dlgSave = null;
                }

                if (sPath != string.Empty)
                {
                    if (m_cProject.IsAutoMode == false)
                    {
                        DBBackup(sDBPath, sPath);
                    }
                    else
                    {
                        if (m_cDBControl.IsRunning)
                        {
                            m_cDBControl.DBDumpPath = sDBPath;
                            m_cDBControl.SaveFilePath = sPath;
                            m_cDBControl.ActiveStep = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOpenDB_Click(object sender, EventArgs e)
        {
            try
            {
                string sMessage = "저장된 데이터 베이스를 오픈합니다.\r\n오픈 시 기존 데이터 베이스는 모두 지워집니다.\r\n데이터 베이스 오픈을 진행하시겠습니까?";

                if (MessageBox.Show(sMessage, "DB 오픈", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.No)
                    return;

                string sDBPath = "";
                string sDBDumpPath = "";

                if (rbMysql.Checked)
                {
                    sDBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                    sDBDumpPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\mysqldump.exe";
                }
                else
                {
                    sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysql.exe";
                    sDBDumpPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                }


                if (!File.Exists(sDBPath))
                {
                    bool bCheck = false;
                    if (rbMysql.Checked)
                    {
                        sDBPath = @"C:\Program Files\MySQL\MySQL Server 5.5\bin\mysql.exe";
                        sDBDumpPath = @"C:\Program Files\MySQL\MySQL Server 5.5\mysqldump.exe";
                        if (File.Exists(sDBPath))
                            bCheck = true;
                    }
                    if (bCheck == false)
                    {
                        MessageBox.Show("DB Path가 존재하지 않습니다.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                sMessage = "DB 불러오기를 진행하기 전 현재까지의 DB를 백업합니다.\r\n진행하시겠습니까?";
                if (MessageBox.Show(sMessage, "DB 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (!Directory.Exists(m_sDBBackupPath))
                        Directory.CreateDirectory(m_sDBBackupPath);

                    DBBackup(sDBDumpPath, m_sDBBackupPath + "\\" + string.Format("DB_Backup_{0}.sql", DateTime.Now.ToString("yyyyMMdd")));
                }

                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = ".sql|*.sql";
                dlgOpen.Title = "데이터 베이스 백업 파일 열기";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return;
                }

                string sPath = dlgOpen.FileName;

                if (sPath != string.Empty)
                {
                    string sError = string.Empty;

                    using (Process mysql = new Process())
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            //Maria DB의 경우 Path 다름
                            mysql.StartInfo.FileName = sDBPath;
                            //mysql.StartInfo.FileName =
                            //@"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                            mysql.StartInfo.UseShellExecute = false;
                            mysql.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -e \"\\. {0}\"", sPath);
                            mysql.StartInfo.RedirectStandardInput = false;
                            mysql.StartInfo.RedirectStandardOutput = false;
                            mysql.StartInfo.RedirectStandardError = true;
                            mysql.StartInfo.CreateNoWindow = true;
                            mysql.Start();

                            sError = mysql.StandardError.ReadToEnd();
                        }
                        SplashScreenManager.CloseForm(false);

                        if (sError != string.Empty)
                            MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("DB Open Success!!", "DB Open", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        mysql.WaitForExit();
                        mysql.Close();
                    }
                }
                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCreateOptraDB_Click(object sender, EventArgs e)
        {

            //CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
            //bool bOK = cLogWriter.CreateOptimizerDB();
            //if (bOK == false)
            //{
            //    UpdateSystemMessage("Create", "OptraDB Fail");
            //}

        }

        private void grdUserSelectTag_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof(List<CViewTag>)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    List<CViewTag> cTagS = (List<CViewTag>)e.Data.GetData(typeof(List<CViewTag>));
                    if (cTagS != null)
                    {
                        foreach (CViewTag who in cTagS)
                        {
                            if (who.Tag.DataType == EMDataType.Bool) continue;
                            if (m_cProject.ViewTagS.ContainsKey(who.Tag.Key))
                            {
                                m_cProject.ViewTagS[who.Tag.Key].CollectUse = true;
                                m_cProject.ViewTagS[who.Tag.Key].UserSymbol = true;
                            }
                        }

                        grdUserSelectTag.DataSource = m_cProject.ViewTagS.Values.Where(b => b.UserSymbol == true).ToList();
                        grdUserSelectTag.RefreshDataSource();
                        grdTotalTagS.RefreshDataSource();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdUserSelectTag_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<CViewTag>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grvTotalTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
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

        private void grvTotalTagS_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_bDragDropReady)
            {
                List<CViewTag> cTagS = GetSelectedTagS();
                if (cTagS == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                grdTotalTagS.DoDragDrop(cTagS, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void grvTotalTagS_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                m_bDragDropReady = false;

                GridView exView = sender as GridView;
                GridHitInfo exHitInfo = exView.CalcHitInfo(new Point(e.X, e.Y));
                if (exHitInfo.InColumnPanel)
                    return;

                if (Control.ModifierKeys != Keys.None)
                    return;

                m_bDragDropReady = true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Main", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvUserSelectTag_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void btnAutoCollect_Click(object sender, EventArgs e)
        {
            FrmAutoModeSetting frmAuto = new FrmAutoModeSetting();
            frmAuto.Project = m_cProject;
            frmAuto.ShowDialog();

            if (frmAuto.IsChanged)
                btnSaveProject_Click(null, null);
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "*.umpor|*.umpor";
            DialogResult dlgResult = dlgOpen.ShowDialog();

            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

            bool bOK = m_cProject.Open(dlgOpen.FileName);
            if (bOK == false)
                MessageBox.Show("파일 열기에 실패했습니다");
            else
            {
                //적용
                chkInput.Checked = m_cProject.InputBitAddCheck;
                chkOutput.Checked = m_cProject.OutputBitAddCheck;
                chkMemory.Checked = m_cProject.M_BitAddCheck;
                chkUseOnlyInLogic.Checked = m_cProject.UseOnlyInLogicCheck;

                grdTotalTagS.DataSource = m_cProject.ViewTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();

                //foreach (string sKey in m_cProject.UserAddTagKeyList)
                //{
                //    if (m_cProject.ViewTagS.ContainsKey(sKey))
                //    {
                //        m_cProject.ViewTagS[sKey].CollectUse = true;
                //        m_cProject.ViewTagS[sKey].UserSymbol = true;
                //    }
                //}

                grdUserSelectTag.DataSource = m_cProject.ViewTagS.Values.Where(b => b.UserSymbol == true).ToList();
                grdUserSelectTag.RefreshDataSource();
                grdTotalTagS.RefreshDataSource();
                Thread.Sleep(1000);

                List<string> lstPlcID = new List<string>();

                foreach (var who in m_cProject.LogicTagS)
                {
                    ValidateOPC(m_cProject.SPDConfigS[who.Key], who.Value);
                    lstPlcID.Add(who.Key);
                }
                grdTotalTagS.RefreshDataSource();
                ArrangeSPD(lstPlcID);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            //적용
            m_cProject.UserAddTagKeyList.Clear();
            m_cProject.AutoAddTagKeyList.Clear();

            foreach (CViewTag tag in m_cProject.ViewTagS.Values.Where(b => b.CollectUse && b.Tag.DataType == EMDataType.Bool).ToList())
                m_cProject.AutoAddTagKeyList.Add(tag.Tag.Key);

            foreach (CViewTag tag in m_cProject.ViewTagS.Values.Where(b => b.CollectUse && b.Tag.DataType != EMDataType.Bool).ToList())
                m_cProject.UserAddTagKeyList.Add(tag.Tag.Key);

            m_cProject.InputBitAddCheck = chkInput.Checked;
            m_cProject.OutputBitAddCheck = chkOutput.Checked;
            m_cProject.M_BitAddCheck = chkMemory.Checked;
            m_cProject.UseOnlyInLogicCheck = chkUseOnlyInLogic.Checked;

            if (m_cProject.AutoOpenPath == "")
            {
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "*.umpor|*.umpor";
                DialogResult dlgResult = dlgSave.ShowDialog();

                if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

                m_cProject.AutoOpenPath = dlgSave.FileName;
                bool bOK = m_cProject.Save(dlgSave.FileName);
                if (bOK == false)
                    MessageBox.Show("파일 저장에 실패했습니다");
            }
            else
            {
                bool bOK = m_cProject.Save(m_cProject.AutoOpenPath);
                if (bOK == false)
                    MessageBox.Show("파일 저장에 실패했습니다");
            }

        }

        private void tmrAutoMode_Tick(object sender, EventArgs e)
        {
            tmrAutoMode.Enabled = false;
            if (m_cProject.IsAutoMode)
            {
                int iNowHour = DateTime.Now.Hour;
                int iNowMin = DateTime.Now.Minute;
                int iCmpHour = 0;
                int iCmpMin = 0;

                if (btnSPDStart.Enabled  == false)
                {
                    //작동중
                    iCmpHour = m_cProject.AutoStartTime.Hour;
                    iCmpMin = m_cProject.AutoStartTime.Minute;
                    if (iNowHour == iCmpHour && iNowMin == iCmpMin)
                    {
                        //정지
                        UpdateSystemMessage("AutoMode", "자동정지합니다");
                        btnSPDStop_Click(null, null);
                    }
                }
                else
                {
                    //정지 중
                    iCmpHour = m_cProject.AutoStopTime.Hour;
                    iCmpMin = m_cProject.AutoStopTime.Minute;
                    if (iNowHour == iCmpHour && iNowMin == iCmpMin)
                    {
                        UpdateSystemMessage("AutoMode", "재시작합니다");
                        //정지
                        btnSPDStart_Click(null, null);
                    }
                    else if (iNowHour == (iCmpHour + 2) && iNowMin == iCmpMin)
                    {
                        //정지 2시간 후 
                        //DB Backup Thread호출
                        UpdateSystemMessage("DBBackup", "DB 백업 시작");
                        btnDBBackup_Click(null, null);

                    }
                    if (m_cDBControl.ActiveStep > 0)
                    {
                        if (m_cDBControl.ActiveStep == 2) // DB Backup완료
                        {
                            //Clear 수행
                            UpdateSystemMessage("DBBackup", "DB 백업에 성공");
                            m_cDBControl.ActiveStep = 3;
                        }
                        else if (m_cDBControl.ActiveStep == 2) // DB Clear완료
                        {
                            UpdateSystemMessage("DBBackup", "DB 백업에 성공");
                            m_cDBControl.ActiveStep = 0;
                        }
                        else if (m_cDBControl.ActiveStep == 12 || m_cDBControl.ActiveStep == 14)
                        {
                            UpdateSystemMessage("DBBackup", "백업 Error : " + m_cDBControl.ActiveStep.ToString());
                            UpdateSystemMessage("DBBackup", "자동 모드 종료");
                            m_cProject.IsAutoMode = false; 
                            //정지는 되어도 다시 시작은 해라.
                            btnSPDStart_Click(null, null);
                        }
                    }
                }
            }
            tmrAutoMode.Enabled = true;
        }

    }
}
