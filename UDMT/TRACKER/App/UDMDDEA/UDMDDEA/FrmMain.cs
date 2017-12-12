using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using System.Reflection;
using System.IO;
using System.Linq;

using UDM.Log;
using UDM.Common;
using UDM.DDEA;
using System.Diagnostics;
using System.Threading;

namespace UDMDDEA
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Member Variables

        protected CMain m_cTrackerMain = new CMain();
        protected CMainControl m_cMainControl = null;
        protected CSystemLog m_cSysLog = null;
        protected CDDEARead m_cRead = null;
        
        protected string m_sSystemLogPath = Application.StartupPath + "\\DDEASystemLog";
        protected bool m_bRun = false;

        protected DataTable m_tblComInfo = new DataTable();
        
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected delegate void ShowTagListCallBack(CDDEASymbolS cSymbolS);
        #endregion


        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(exRibbonGallery, true);
        }

        #endregion

        

        #region Public Properties


        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// 1개의 Form만 Open하기 위해서 확인
        /// </summary>
        /// <param name="frmType"></param>
        /// <returns></returns>
        private Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
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
                    if (sMessage.Contains(","))
                    {
                        string[] sSplit = sMessage.Split(',');
                        if (sSplit.Length > 1)
                        {
                            switch (sSplit[0])
                            {
                                case "StartError":
                                    btnStop_ItemClick(null, null);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ucSystemMessage.AddMessage(DateTime.Now, sSender, sMessage);
                        SetSystemLog(sSender, sMessage);
                        if (sMessage.Contains("ALL STOP"))
                        {
                            btnStop_ItemClick(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        protected void SetSystemLog(string sSender, string sMessage)
        {
            if (m_cSysLog != null)
                m_cSysLog.WriteLog(sSender, sMessage);
        }

        protected void CreateTable()
        {
            CMainControl cMain = m_cMainControl;

            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Group");
            m_tblComInfo.Columns.Add("Item");
            m_tblComInfo.Columns.Add("Value");
            if (cMain.DDEAProject != null)
            {
                m_tblComInfo.Rows.Add(new object[] { "Project", "Name", "UDM DDEA New Project"});
                CDDEAConfigMS cConfig = m_cMainControl.DDEAProject.Config;
                if (cConfig.SelectedItem != EMConnectTypeMS.None)
                {
                    CPlcTypeConverter cType = new CPlcTypeConverter();
                    string sGroup = "통신 설정 ( " + cConfig.SelectedItem.ToString() + " )";
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "PLC Maker", "Mitsubishi" });
                    if (cConfig.SelectedItem == EMConnectTypeMS.GXSim)
                    {
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "CPU", cConfig.GxSim.CPUType.ToString() });
                    }
                    else if (cConfig.SelectedItem == EMConnectTypeMS.USB)
                    {
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "CPU", cConfig.USB.CPUType.ToString() });
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "Station Type", cConfig.USB.StationType.ToString() });
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "Network Number", cConfig.USB.NetworkNumber.ToString() });
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "Station Number", cConfig.USB.StationNumber.ToString() });
                    }
                    if (m_cMainControl.ReceiveDDEASymbolS != null)
                    {
                        m_tblComInfo.Rows.Add(new object[] { "수집대상", "Symbol Count", m_cMainControl.ReceiveDDEASymbolS.Count.ToString() });
                        m_tblComInfo.Rows.Add(new object[] { "수집대상", "Packet Count", m_cMainControl.DDEAProject.NormalBundleList.Count.ToString() });
                        if (m_cMainControl.DDEAProject.NormalBundleList.Count > 0)
                        {
                            for (int i = 0; i < m_cMainControl.DDEAProject.NormalBundleList.Count; i++)
                            {
                                int iPacketCount = i + 1;
                                string sPacket = string.Format("{0} Packet", iPacketCount);
                                m_tblComInfo.Rows.Add(new object[] { sPacket, "Bit", m_cMainControl.DDEAProject.NormalBundleList[i].BitSymbolList.Count.ToString() });
                                m_tblComInfo.Rows.Add(new object[] { sPacket, "Word", m_cMainControl.DDEAProject.NormalBundleList[i].WordSymbolList.Count.ToString() });
                                m_tblComInfo.Rows.Add(new object[] { sPacket, "Index", m_cMainControl.DDEAProject.NormalBundleList[i].IndexSymbolList.Count.ToString() });
                            }
                        }
                    }
                }
            }
        }

        private List<CDDEASymbol> FindShowDDEASymbolList(CDDEASymbolS cSymbolS)
        {
            List<CDDEASymbol> lstSymbol = cSymbolS.Select(x => x.Value).ToList();

            List<CDDEASymbol> lstReturnValue = lstSymbol.FindAll(b => b.AddressCount >= 1);

            return lstReturnValue;
        }

        protected void ShowTagList(CDDEASymbolS cSymbolS)
        {

            if (this.grdTag.InvokeRequired)
            {
                ShowTagListCallBack d = new ShowTagListCallBack(ShowTagList);
                this.Invoke(d, new object[] { cSymbolS });
            }
            else
            {
                try
                {
                    if (cSymbolS == null)
                        grdTag.DataSource = null;
                    else
                    {
                        grdTag.DataSource = FindShowDDEASymbolList(cSymbolS);
                    }

                    grdTag.RefreshDataSource();

                    CreateTable();

                    grdComInfo.DataSource = m_tblComInfo;
                    grdComInfo.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Tag", ex.Message);
                }
            }

        }

        private bool OpenUpmProject(string sPath)
        {
            bool bOK = false;

            if (sPath == "")
                return false;


            bOK = m_cMainControl.Open(sPath);

            if (bOK)
            {
                m_cMainControl.UpmSaveFilePath = sPath;
                m_cSysLog.WriteLog("Upm Open", "Path : " + sPath);

                UpdateSystemMessage("Project열기", "파일 열기에 성공했습니다.");

                ShowTagList(m_cMainControl.ReceiveDDEASymbolS);

            }

            return true;
        }

        private bool SaveUpmProject(string sPath)
        {
            bool bOK = false;

            if (sPath == "")
                return false;

            bOK = m_cMainControl.Save(m_cMainControl.UpmSaveFilePath);

            if (bOK)
            {
                UpdateSystemMessage("Project저장", "성공했습니다.");
                btnSave.Enabled = false;
                btnSaveAs.Enabled = false;

                ShowTagList(m_cMainControl.ReceiveDDEASymbolS);
            }
            else
            {
                UpdateSystemMessage("Project저장", "실패했습니다.");
                return false;
            }

            return true;
        }

        protected void SaveAs()
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Upm files (*.upm)|*.upm";
            DialogResult dlgResult = dlgSave.ShowDialog();

            if (dlgResult == DialogResult.Cancel) return;

            string sPath = dlgSave.FileName;
            if (sPath != "")
            {
                m_cMainControl.UpmSaveFilePath = sPath;
                m_cSysLog.WriteLog("Upm Save", "Path : " + sPath);

                bool bOK = SaveUpmProject(sPath);
                if (bOK)
                    UpdateSystemMessage("Upm Save", "파일 저장에 성공했습니다.");
                else
                    UpdateSystemMessage("Upm Save", "파일 저장에 실패했습니다.");
            }
        }

        protected void ShowErrorMessageBox(string sMessage)
        {
            MessageBox.Show(sMessage, "UDM Profiler2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            m_cSysLog.WriteLog("MessageBox", sMessage);
        }

        /// <summary>
        /// 동작중인 DDEA가 있는지 확인
        /// </summary>
        private void CheckRunDDEA()
        {
            Process[] aProcess = Process.GetProcessesByName("UDMDDEA");
            SetSystemLog("Initialize", "실행중인 DDEA가 있는지 확인합니다.");

            if (aProcess.Length > 0)
            {
                string sMsg = string.Format("실행 중인 DDEA가 {0}개 있습니다\r\n\r\nProfiler 수집하는데 영향을 줄 수 있습니다.\r\n\r\n전체 종료하려면 Yes\r\n\r\n무시하려면 No\r\n\r\n프로그램을 종료하려면 Cancel을 선택하세요", aProcess.Length);
                SetSystemLog("Initialize", sMsg);
                DialogResult dlgResult = MessageBox.Show(sMsg, "UDM DDEA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    foreach (Process pro in aProcess)
                        pro.Kill();
                    SetSystemLog("Initialize", "실행 중인 DDEA를 모두 종료했습니다.");
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        private bool Run()
        {
            try
            {
                if (m_bRun) return true;

                if (m_cRead != null)
                {
                    m_cRead.Stop();
                    m_cRead = null;
                }
                m_cMainControl.DDEAProject.ConnectApp = EMConnectAppType.Tracker;

                m_cRead = new CDDEARead(m_cMainControl.DDEAProject, EMPlcConnettionType.Melsec_Normal);
                m_cRead.UEventMessage += new UEventHandlerMainMessage(m_cRead_UEventMessage);
                m_cRead.UEventTrackerData += new UEventHandlerDDEReadDataChanged(m_cRead_UEventTrackerData);

                m_bRun = true;
                
                m_bRun = m_cRead.Run();

            }
            catch (Exception ex)
            {
                UpdateSystemMessage("수집시작", "수집 시작 분석 중 문제가 발생했습니다.\r\n" + ex.Message);
                
                return false;
            }
            return m_bRun;
        }

        private bool Stop()
        {
            if (m_bRun == false)
                return false;

            if (m_cRead != null)
            {
                m_cRead.Stop();
                m_cRead.UEventMessage -= new UEventHandlerMainMessage(m_cRead_UEventMessage);
                m_cRead.UEventTrackerData -= new UEventHandlerDDEReadDataChanged(m_cRead_UEventTrackerData);
                m_cRead = null;
            }

            m_bRun = false;
            return true;
        }

        private void ClearCurrentValue()
        {
            foreach (var who in m_cMainControl.ReceiveDDEASymbolS)
            {
                CDDEASymbol cSymbol = who.Value;
                cSymbol.CurrentValue = -1;
                cSymbol.ChangeCount = 0;
                cSymbol.IndexNote = "";
            }
            UpdateSystemMessage("접점 정보", "현재 값 및 변화 횟수를 초기화 합니다.");
        }

        private void CheckConnectSymbolTest()
        {
            Dictionary<string, int> dicCollectAddress = new Dictionary<string, int>();
            List<string> lstSameFilter = new List<string>();
            List<string> lstFailAddress = new List<string>();
            CReadFunction cReadFunction = new CReadFunction(m_cMainControl.DDEAProject.Config, EMPlcConnettionType.Melsec_Normal);

            bool bOK = cReadFunction.Connect();

            if (bOK)
            {
                //수집테스트
                string sAddressList = "";
                int iCount = 0;
                int iTestCount = 0;
                string sAddress = "";
                try
                {
                    foreach (var who in m_cMainControl.ReceiveDDEASymbolS)
                    {
                        if (lstSameFilter.Contains(who.Value.Address) == false)
                        {
                            lstSameFilter.Add(who.Value.Address);
                            sAddressList += who.Value.Address + "\n";
                            iCount++;
                        }
                        if (iCount >= 94)
                        {
                            dicCollectAddress.Add(sAddressList, iCount);
                            iCount = 0;
                            sAddressList = "";
                        }
                    }
                    if (iCount > 0)
                    {
                        dicCollectAddress.Add(sAddressList, iCount);
                    }
                    string sMessage = "";

                    foreach (var who in dicCollectAddress)
                    {
                        iTestCount = who.Value;
                        sAddress = who.Key;
                        int[] iaTestData = cReadFunction.ReadRandomData(sAddress, iTestCount);
                        if (iaTestData == null)
                        {
                            string[] sSplit = sAddress.Split('\n');
                            List<string> lstErrorAddress = cReadFunction.FindErrorSymbol(sSplit);
                            if (lstErrorAddress.Count > 0)
                            {
                                foreach (string add in lstErrorAddress)
                                {
                                    lstFailAddress.Add(add);
                                    sMessage += add + ", ";
                                    CDDEASymbol cSymbol = m_cMainControl.ReceiveDDEASymbolS.Where(x => x.Value.Address == add).FirstOrDefault().Value;
                                    if (cSymbol != null)
                                    {
                                        if (cSymbol.CollectUse)
                                            cSymbol.CollectUse = false;
                                    }
                                    else
                                    {
                                        UpdateSystemMessage("Symbol", "등록된 접점이 아닙니다.");
                                    }
                                }
                            }
                        }
                        Thread.Sleep(1);
                        Application.DoEvents();

                    }
                    if (lstFailAddress.Count > 0)
                    {
                        UpdateSystemMessage("접점확인", "수집 불가 접점 : " + sMessage);
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                cReadFunction.Disconnect();
            }
        }

        private void SendTimeLogS(CTimeLogS cLogS)
        {
            string[] sarrSendData = new string[cLogS.Count];
            int iCount = 0;

            foreach (CTimeLog tLog in cLogS)
            {
                string sValue = "";
                if (tLog.SValue.Trim() != "")
                    sValue = tLog.SValue;
                else
                    sValue = tLog.Value.ToString();

                string sSend = string.Format("{0},{1},{2}", tLog.Time.ToString("yyyyMMddHHmmss.fff"), tLog.Key, sValue);
                sarrSendData[iCount++] = sSend;
            }

            m_cTrackerMain.SendToClient(sarrSendData);
        }

        private string[] CreateTimeLogS(CTimeLogS cLogS)
        {
            string[] sarrSendData = new string[cLogS.Count];
            int iCount = 0;

            foreach (CTimeLog tLog in cLogS)
            {
                string sValue = "";
                if (tLog.SValue.Trim() != "")
                    sValue = tLog.SValue;
                else
                    sValue = tLog.Value.ToString();

                string sSend = string.Format("{0},{1},{2}", tLog.Time.ToString("yyyyMMddHHmmss.fff"), tLog.Key, sValue);
                sarrSendData[iCount++] = sSend;
            }

            return sarrSendData;
        }

        #endregion


        #region Event Methods


        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = AssemblyTitle + "  V" + AssemblyVersion;

            btnNew_ItemClick(null, null);

            m_cTrackerMain.UEventReceiveSymbolS += new UEventHandlerTrackerSymbolReceive(m_cTrackerMain_UEventReceiveSymbolS);
            m_cTrackerMain.UEventResearchSymbolS += new UEventHandlerTrackerResearchSymbolReceive(m_cTrackerMain_UEventResearchSymbolS);
            m_cTrackerMain.UEventMainMessage += new UEventHandlerMainMessage(m_cTrackerMain_UEventMainMessage); 

            bool bOK = m_cTrackerMain.StartServer();
            if (bOK)
                UpdateSystemMessage("Tracker 연결", "서버 실행중입니다.");
            else
                UpdateSystemMessage("Tracker 연결", "서버 실행 실패...");
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_cTrackerMain != null)
                m_cTrackerMain.StopServer();

        }

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_cMainControl == null)
            {
                m_cSysLog = new CSystemLog(m_sSystemLogPath, "DDEA");
                tmrSystemLog.Start();
                m_cMainControl = new CMainControl();
                m_cMainControl.DDEAProject.UEventProjectMessage += new UEventHandlerMainMessage(m_cMainControl_DDEAProject_Message);
                return;
            }
            string sMsg = string.Format("새로운 설정을 하시겠습니까?\r\n\r\n기존 정보는 모두 삭제됩니다.");
            DialogResult dlgResult = MessageBox.Show(sMsg, "UDMTek DDEA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                m_cMainControl.Clear();
                m_cMainControl = new CMainControl();
                m_cMainControl.DDEAProject.UEventProjectMessage += new UEventHandlerMainMessage(m_cMainControl_DDEAProject_Message);

                UpdateSystemMessage("New Project", "새로운 프로젝트가 생성되었습니다");
            }
        }

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Upm files (*.upm)|*.upm";
            DialogResult dlgResult = dlgOpen.ShowDialog();

            if (dlgResult == DialogResult.Cancel) return;

            string sPath = dlgOpen.FileName;
            if (sPath != "")
            {
                if (m_cMainControl == null)
                    m_cMainControl = new CMainControl();
                else
                {
                    m_cMainControl.ReceiveDDEASymbolS.Clear();
                    m_cMainControl.DDEAProject.Clear();
                }
                bool bOK = OpenUpmProject(sPath);

                CreateTable();

                grdComInfo.DataSource = m_tblComInfo;
                grdComInfo.RefreshDataSource();

                if (bOK == false)
                {
                    UpdateSystemMessage("OpenProject", "파일 열기에 실패 했습니다.");
                }
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_cMainControl.DDEAProject.Config.SelectedItem == EMConnectTypeMS.None)
            {
                ShowErrorMessageBox("통신 설정이 안되어 있습니다.");
                return;
            }

            if (m_cMainControl.UpmSaveFilePath == "")
                SaveAs();
            else
            {
                SaveUpmProject(m_cMainControl.UpmSaveFilePath);
            }
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_cMainControl.DDEAProject.Config.SelectedItem == EMConnectTypeMS.None)
            {
                ShowErrorMessageBox("통신 설정이 안되어 있습니다.");
                return;
            }
            SaveAs();
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_bRun)
            {
                ShowErrorMessageBox("현재 수집중입니다. 종료할 수 없습니다.");
                return;
            }
            if (m_cTrackerMain != null)
            {
                if (m_cTrackerMain.IsRunning)
                    m_cTrackerMain.StopServer();
                m_cTrackerMain = null;
            }
            if (m_cSysLog != null)
            {
                tmrSystemLog.Stop();
                m_cSysLog.WriteEndLog();
                m_cSysLog = null;
            }
            this.Close();
        }

        private void btnStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_cMainControl == null)
                return;

            if(m_cMainControl.PLCConfigTest == false)
            {
                UpdateSystemMessage("DDEA Start", "통신 연결이 원활하지 않습니다.");
                return;
            }

            if(m_cMainControl.ReceiveDDEASymbolS.Count == 0)
            {
                UpdateSystemMessage("DDEA Start", "수집할 접점이 없습니다.");
                return;
            }

            if (m_cMainControl.DDEAProject.Config.SelectedItem == EMConnectTypeMS.None)
            {
                UpdateSystemMessage("DDEA Start", "통신 설정이 없습니다.");
                return;
            }

            btnStop.Enabled = true;
            btnStart.Enabled = false;

            CheckConnectSymbolTest();

            ClearCurrentValue();
            m_cMainControl.DDEAProject.NormalBundleList.Clear();
            m_cMainControl.DDEAProject.SetNormalBundleList(m_cMainControl.ReceiveDDEASymbolS);

            UpdateSystemMessage("DDEA Start", "접점 리스트 갱신을 시작합니다.");
            tmrDataRefresh.Start();

            ShowTagList(m_cMainControl.ReceiveDDEASymbolS);

            Run();
            m_bRun = true;

            mnuHomeFile.Enabled = false;
            mnuExit.Enabled = false;
            mnuConfig.Enabled = false;

            tabMain.SelectedTabPageIndex = 1;
        }

        private void btnStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            tmrDataRefresh.Stop();
            tabMain.SelectedTabPageIndex = 0;
            Stop();
            m_bRun = false;
            mnuHomeFile.Enabled = true;
            mnuExit.Enabled = true;
            mnuConfig.Enabled = true;
        }

        private void btnPLCConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (chkDDEA.Checked && chkMelsecPlc.Checked)
            {
                FrmDDEAProperty frmDDEAProperty = new FrmDDEAProperty(m_cMainControl.DDEAProject.Config);
                frmDDEAProperty.ShowDialog();
                if (frmDDEAProperty.IsDataChange)
                {
                    m_cMainControl.DDEAProject.Config = frmDDEAProperty.Config;

                    CreateTable();

                    grdComInfo.DataSource = m_tblComInfo;
                    grdComInfo.RefreshDataSource();
                }
            }
            else if (chkDDEA.Checked && chkLsPlc.Checked)
            {

            }
            else
            {
                FrmOpcConfig frmOpcConfig = new FrmOpcConfig(m_cMainControl.OpcConfig);
                frmOpcConfig.ShowDialog();
            }
        }

        /// <summary>
        /// 1시간 마다 파일 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrSystemLog_Tick(object sender, EventArgs e)
        {
            tmrSystemLog.Enabled = false;

            try
            {
                if (m_cSysLog != null)
                {
                    m_cSysLog.WriteLog("SystemLog", "새로운 파일을 생성합니다.(주기 1시간)");
                    string sFileName = m_cSysLog.FileName;
                    m_cSysLog.WriteEndLog();

                    m_cSysLog = new CSystemLog(m_sSystemLogPath, "DDEA");

                    m_cSysLog.WriteLog("SystemLog", "이전 파일 : " + sFileName);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SystemLog", "Error : " + ex.Message);
                ex.Data.Clear();
            }
            tmrSystemLog.Enabled = true;
        }

        private void tmrDataRefresh_Tick(object sender, EventArgs e)
        {
            tmrDataRefresh.Enabled = false;

            grdTag.RefreshDataSource();
            grvTag.RefreshData();

            tmrDataRefresh.Enabled = true;
        }

        #endregion

        #endregion


        #region Event Method

        private void m_cTrackerMain_UEventMainMessage(object sender, string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void m_cTrackerMain_UEventResearchSymbolS(object sender, CDDEASymbolS cSymbolS, out string[] saLog)
        {
            saLog = null;

            List<CDDEASymbolList> lstSymbol = new List<CDDEASymbolList>();
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            Dictionary<string, int> dicSendData = new Dictionary<string, int>();
            int iCount = 0;
            string sAddressList = "";
            try
            {
                foreach (var who in cSymbolS)
                {
                    cSymbolList.AddSymbol(who.Value);
                    sAddressList += who.Value.Address + "\n";
                    iCount++;
                    if (iCount >= 90)
                    {
                        lstSymbol.Add(cSymbolList);
                        cSymbolList = new CDDEASymbolList();
                        dicSendData.Add(sAddressList, iCount);
                        sAddressList = "";
                        iCount = 0;
                    }
                }
                if (iCount > 0)
                {
                    lstSymbol.Add(cSymbolList);
                    dicSendData.Add(sAddressList, iCount);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("분석", "하위 Depth 재수집 접점분석에 문제가 있습니다. : " + ex.Message);
            }
            //수집 구간

            try
            {
                DateTime dtNow = DateTime.Now;
                CReadFunction cReadFunc = new CReadFunction(m_cMainControl.DDEAProject.Config, EMPlcConnettionType.Melsec_Normal);
                bool bOK = cReadFunc.Connect();

                if (bOK && m_bRun)
                {
                    m_cRead.Pause = true;
                    UpdateSystemMessage("하위 Depth 수집", "기존 수집대상을 일시정지 합니다.");
                    int iReadNumber = 0;
                    CTimeLogS cLogS = new CTimeLogS();

                    foreach (var who in dicSendData)
                    {
                        int[] iReadData = cReadFunc.ReadRandomData(who.Key, who.Value);
                        if (iReadData == null)
                            UpdateSystemMessage("하위 Depth 수집", "수집에 실패했습니다.");
                        else
                        {
                            //분석
                            string[] saAddress = who.Key.Split('\n');
                            for (int i = 0; i < saAddress.Length; i++)
                            {
                                if (saAddress[i] == "")
                                    continue;

                                CDDEASymbol cSymbol = lstSymbol[iReadNumber].FindEqulAddressSymbol(saAddress[i]);
                                if (cSymbol != null)
                                {
                                    CTimeLog cLog = new CTimeLog();
                                    cLog.Key = cSymbol.Key;
                                    cLog.Time = dtNow;
                                    cLog.Value = iReadData[i];
                                    cLog.SValue = "";
                                    cLogS.Add(cLog);
                                }
                                else
                                    UpdateSystemMessage("하위 Depth 수집분석", saAddress[i] + " 해당접점을 찾을 수 없습니다.");
                            }
                        }
                        iReadNumber++;
                    }

                    cReadFunc.Disconnect();
                    if (cLogS.Count > 0)
                        saLog = CreateTimeLogS(cLogS);

                    m_cRead.Pause = false;
                    UpdateSystemMessage("하위 Depth 수집", "기존 수집대상으로 수집을 진행합니다.");
                }
                else
                {
                    UpdateSystemMessage("하위 Depth 수집", "수집을 진행하고 있는 상태가 아닙니다.");
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("수집", "하위 Depth 재수집에 문제가 있습니다. : " + ex.Message);
            }
        }

        private void m_cTrackerMain_UEventReceiveSymbolS(object sender)
        {
            if (m_cMainControl.PLCConfigTest)
            {
                if (m_bRun)
                {
                    btnStop_ItemClick(null, null);
                    while (m_bRun)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }
                }
            }

            m_cMainControl.ReceiveDDEASymbolS = m_cTrackerMain.ReadSymbolS;
            ShowTagList(m_cTrackerMain.ReadSymbolS);

            if (m_cMainControl.DDEAProject.Config.SelectedItem != EMConnectTypeMS.None)
                btnStart_ItemClick(null, null);
        }

        private void m_cMainControl_DDEAProject_Message(object sender, string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        void m_cRead_UEventMessage(object sender, string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        void m_cRead_UEventTrackerData(object sender, CTimeLogS cEventTimeLogS)
        {
            SendTimeLogS(cEventTimeLogS);
        }

        #endregion

        private void btnDetailInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_bRun == false)
                return;
            Form frmOpenCheck = IsFormOpened(typeof(FrmDetailView));
            if (frmOpenCheck == null)
            {
                FrmDetailView frmDetailView = new FrmDetailView(m_cRead);
                frmDetailView.Show();
            }
        }

    }
}