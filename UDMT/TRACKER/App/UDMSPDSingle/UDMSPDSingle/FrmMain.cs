using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrackerCommon;
using TrackerSPD.DDEA;
using TrackerSPD.OPC;
using TrackerSPD.LS;
using UDM.Log;
using UDM.Common;
using TrackerWCF;
using System.IO;
using System.Diagnostics;
using UDM.General.Remote;
using System.ServiceModel;

namespace UDMSPDSingle
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private bool m_bConnect = false;
        private bool m_bConfigOpen = false;
        private bool m_bRun = false;
        private bool m_bError = false;
        private bool m_bMonitorStop = false;
        private bool m_bMonitorStart = false;

        private string m_sPlcID = "";
        private string m_sConfigFilePath = "";
        private string m_sSysLogPath = Application.StartupPath + "\\DDEASystemLog";
        private string m_sMode = "Ready";
        private string m_sSender = "";

        private string[] m_saFirstTagListData = null;
        private string[] saParameter = null;
        private string[] m_saStartData = null;
        private string[] m_saStopData = null;

        private CClient<IMyService, CMyServiceCallBack> m_cClient = null;
        private delegate void UpdateTextCallBack(string sSender, string sMessage);
        private DataTable m_tblComInfo = new DataTable();
        private CSystemLog m_cSysLog = null;

        private CPlcConfig m_cPlcConfig = new CPlcConfig();

        private CDDEARead m_cDDEAReader = null;
        private COPCServer m_cOPCServer = null;
        private CLsReader m_cLsReader = null;
        private CTagS m_cReceiveTagS = new CTagS();
        private CTagS m_cSubReceiveTagS = new CTagS();
        private CDDEAProject m_cDDEAProject = null;

        private Dictionary<string, CViewTag> m_dicViewTag = new Dictionary<string, CViewTag>();

        private delegate void UpdateGridCallback();


        #endregion


        #region Initialize

        public FrmMain(string[] saInfo)
        {
            InitializeComponent();

            saParameter = saInfo;
            
        }

        #endregion


        #region Private Method

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

        private bool Connect()
        {
            bool bOK = true;

            try
            {
                if (m_cClient == null)
                {
                    m_cClient = new CClient<IMyService, CMyServiceCallBack>(m_sPlcID);
                }

                if (m_sSender == "")
                {
                    m_cClient.ServiceName = "SPDManager";
                    m_cClient.Port -= 1;
                }

                if (m_cClient.IsConnected == false)
                    bOK = m_cClient.Connect();

                if (bOK)
                {
                    m_bConnect = true;
                    m_cClient.ServiceCallBack.UEventTerminated += new EventHandler(ServiceCallBack_UEventTerminated);
                    UpdateSystemMessage("Connect", "서버와 연결 성공");
                }
                else
                {
                    UpdateSystemMessage("Connect", "서버와 연결 실패");
                    m_bConnect = false;
                }

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }


            if (bOK == false)
            {
                MessageBox.Show("Can't connect Manager", "SPD Single", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bOK;
        }

        private bool Disconnect()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return true;

            UpdateSystemMessage("ClientEventRemove", "Disconnection ~ing");

            m_cClient.ServiceCallBack.UEventTerminated -= new EventHandler(ServiceCallBack_UEventTerminated);
            m_cClient.Disconnect();
            //m_cClient.Dispose();
            m_cClient = null;

            m_bConnect = false;

            return true;
        }

        private bool ClientEventAdd()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return false;


            bool bOK = true;

            try
            {
                m_cClient.ServiceCallBack.UEventReceiveCommStart += ServiceCallBack_UEventReceiveCommStart;
                m_cClient.ServiceCallBack.UEventReceiveCommStop += ServiceCallBack_UEventReceiveCommStop;
                m_cClient.ServiceCallBack.UEventReceiveEmergTagList += ServiceCallBack_UEventReceiveEmergTagList;
                m_cClient.ServiceCallBack.UEventReceiveTagList += ServiceCallBack_UEventReceiveTagList;
                m_cClient.ServiceCallBack.UEventReceiveCollectorList += ServiceCallBack_UEventReceiveCollectorList;
                m_cClient.ServiceCallBack.UEventReceiveRecipeTagList += ServiceCallBack_UEventReceiveRecipeTagList;
                m_cClient.ServiceCallBack.UEventReceiveLadderViewTagList += ServiceCallBack_UVEventReceiveLadderViewTagList;
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
                MessageBox.Show("Can't connect SPD", "SPD Single", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSystemMessage("CreateEvent", "Event 생성에 실패했습니다.");
            }

            return bOK;
        }

        private bool ClientEventRemove()
        {
            if (m_cClient == null || m_cClient.IsConnected == false)
                return true;

            UpdateSystemMessage("ClientEventRemove", "Event Clear Start");

            m_cClient.ServiceCallBack.UEventReceiveCommStart -= ServiceCallBack_UEventReceiveCommStart;
            m_cClient.ServiceCallBack.UEventReceiveCommStop -= ServiceCallBack_UEventReceiveCommStop;
            m_cClient.ServiceCallBack.UEventReceiveEmergTagList -= ServiceCallBack_UEventReceiveEmergTagList;
            m_cClient.ServiceCallBack.UEventReceiveTagList -= ServiceCallBack_UEventReceiveTagList;
            m_cClient.ServiceCallBack.UEventReceiveCollectorList -= ServiceCallBack_UEventReceiveCollectorList;
            m_cClient.ServiceCallBack.UEventReceiveRecipeTagList -= ServiceCallBack_UEventReceiveRecipeTagList;
            m_cClient.ServiceCallBack.UEventReceiveLadderViewTagList -= ServiceCallBack_UVEventReceiveLadderViewTagList;
            m_cClient.ServiceCallBack.UEventReceiveAddTagList -= ServiceCallBack_UEventReceiveAddTagList;
            m_cClient.ServiceCallBack.UEventReceiveRemoveTagList -= ServiceCallBack_UEventReceiveRemoveTagList;

            UpdateSystemMessage("ClientEventRemove", "Event Clear End");
            UpdateSystemMessage("ClientEventRemove", "Disconnection Start");

            Disconnect();

            UpdateSystemMessage("ClientEventRemove", "Disconnection End");

            return true;
        }

        private void UpdateSystemMessage(string sSender, string sMessage)
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
                    SetSystemLog(sSender, sMessage);
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
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Group");
            m_tblComInfo.Columns.Add("Item");
            m_tblComInfo.Columns.Add("Value");

            m_tblComInfo.Rows.Add(new object[] { "Project", "ID", m_sPlcID });
            m_tblComInfo.Rows.Add(new object[] { "수집대상", "Symbol Count", m_cReceiveTagS.Count.ToString() });

            if (m_cPlcConfig != null)
            {
                m_tblComInfo.Rows.Add(new object[] { "PLC연결", "방식", m_cPlcConfig.CollectType.ToString() });
                string sGroup = "통신 설정";
                m_tblComInfo.Rows.Add(new object[] { sGroup, "PLC Maker", m_cPlcConfig.PLCMaker.ToString() });

                if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "Server Name", m_cPlcConfig.OPCConfig.ServerName });
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "Channel", m_cPlcConfig.OPCConfig.ChannelDevice });
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "Update Rate", m_cPlcConfig.OPCConfig.UpdateRate.ToString() });
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                {
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "Interface Type", m_cPlcConfig.LsConfig.InterfaceType.ToString() });
                    if (m_cPlcConfig.LsConfig.InterfaceType == EMLsInterfaceType.Ethernet)
                    {
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "IP", m_cPlcConfig.LsConfig.IP });
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "Port", m_cPlcConfig.LsConfig.Port });
                    }
                    m_tblComInfo.Rows.Add(new object[] { sGroup, "Update Rate", m_cPlcConfig.LsConfig.Interval.ToString() });
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                {
                    CDDEAConfigMS cConfig = m_cPlcConfig.MelsecConfig;
                    if (cConfig.SelectedItem != EMConnectTypeMS.None)
                    {
                        CPlcTypeConverter cType = new CPlcTypeConverter();
                        m_tblComInfo.Rows.Add(new object[] { sGroup, "Interface Type", cConfig.SelectedItem.ToString() });
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
                        if (m_cDDEAProject != null)
                        {
                            m_tblComInfo.Rows.Add(new object[] { "수집대상", "Packet Count", m_cDDEAProject.NormalBundleList.Count.ToString() });
                            if (m_cDDEAProject.NormalBundleList.Count > 0)
                            {
                                for (int i = 0; i < m_cDDEAProject.NormalBundleList.Count; i++)
                                {
                                    int iPacketCount = i + 1;
                                    string sPacket = string.Format("{0} Packet", iPacketCount);
                                    m_tblComInfo.Rows.Add(new object[] { sPacket, "Bit", m_cDDEAProject.NormalBundleList[i].BitSymbolList.Count.ToString() });
                                    m_tblComInfo.Rows.Add(new object[] { sPacket, "Word", m_cDDEAProject.NormalBundleList[i].WordSymbolList.Count.ToString() });
                                    m_tblComInfo.Rows.Add(new object[] { sPacket, "Index", m_cDDEAProject.NormalBundleList[i].IndexSymbolList.Count.ToString() });
                                }
                            }
                        }

                    }
                }
            }

            grdInfo.DataSource = m_tblComInfo;
            grdInfo.RefreshDataSource();
        }

        private List<string> CreateTimeLogS(CTimeLogS cLogS)
        {
            if (cLogS == null || cLogS.Count == 0) return null;

            List<string> lstResult = new List<string>();

            foreach (CTimeLog tLog in cLogS)
            {
                string sValue = "";
                if (tLog.SValue.Trim() != "")
                    sValue = tLog.SValue;
                else
                    sValue = tLog.Value.ToString();

                string sSend = string.Format("{0},{1},{2}", tLog.Time.ToString("yyyyMMddHHmmss.fff"), tLog.Key, sValue);
                lstResult.Add(sSend);
            }

            return lstResult;
        }

        /// <summary>
        /// 0 = Key, 1 = Channel, 2= Address, 3 = DataType, 4 = Size
        /// </summary>
        /// <param name="saData"></param>
        /// <returns></returns>
        private CTagS ChangeTagS(string[] saData)
        {
            CTagS cTagS = new CTagS();

            try
            {
                for (int i = 1; i < saData.Length; i++)
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
                            CTypeConvert cTypeConvert = new CTypeConvert();
                            CTag cTag = new CTag();
                            cTag.Key = sSplit[0];

                            int iAddressIndex = cTag.Key.IndexOf(sSplit[1]);
                            cTag.Channel = cTag.Key.Substring(1, iAddressIndex - 2);
                            cTag.Address = sSplit[1];
                            cTag.DataType = cTypeConvert.GetDataType(sSplit[2]);
                            cTag.Size = iLength;
                            cTag.PLCMaker = m_cPlcConfig.PLCMaker;
                            cTagS.Add(cTag);
                        }
                    }
                }
                UpdateSystemMessage("ChangeTagS", string.Format("변환된 Tag 수 : {0}", cTagS.Count));
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
            return cTagS;
        }

        private Dictionary<string, CViewTag> ChangeViewTagList(CTagS cTagS)
        {
            Dictionary<string, CViewTag> dicViewTag = new Dictionary<string, CViewTag>();
            foreach (var who in cTagS)
            {
                CViewTag cViewTag = new CViewTag();
                cViewTag.Address = who.Value.Address;
                cViewTag.DataType = who.Value.DataType;
                cViewTag.Description = who.Value.Description;
                cViewTag.Key = who.Key;
                cViewTag.CurrentValue = -1;
                cViewTag.ChangeCount = 0;
                cViewTag.CollectUse = who.Value.IsCollectUsed;

                if (dicViewTag.ContainsKey(cViewTag.Key) == false)
                    dicViewTag.Add(cViewTag.Key, cViewTag);
            }

            return dicViewTag;
        }

        private CDDEASymbolS CreateSymbolS(CTag cTag)
        {
            if (cTag == null) return null;
            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            if (cSymbol.DataType == EMDataType.Word)
                cSymbol.BaseAddress = cSymbol.Address;
            if (cTag.DataType == EMDataType.DWord)
                cSymbol.AddressCount = 2;
            else
                cSymbol.AddressCount = cTag.Size;

            cSymbolS.AddSymbol(cSymbol);
            if (cSymbol.DataType != EMDataType.Word)
                return cSymbolS;

            for (int i = 1; i < cSymbol.AddressCount; i++)
            {
                cSymbol.DataType = EMDataType.DWord;
                int iAddress = cSymbol.AddressMajor + i;
                string sSubAddress = cSymbol.AddressHeader + iAddress.ToString();
                if (cSymbol.CheckAddressHexa(sSubAddress))
                {
                    string sHexa = string.Format("{0:x}", iAddress);
                    sSubAddress = cSymbol.AddressHeader + sHexa;
                }

                CDDEASymbol cSubSymbol = new CDDEASymbol(sSubAddress, false);
                cSubSymbol.CreateMelsecDDEASymbol(sSubAddress);
                cSymbol.DWordSecondAddress = sSubAddress;
                cSubSymbol.BaseAddress = cSymbol.Address;
                cSubSymbol.AddressCount = 0;
                cSymbolS.AddSymbol(cSubSymbol);
            }

            return cSymbolS;
        }
        
        private CDDEASymbolS ChangeDDEASymbolS(CTagS cTagS)
        {
            if (cTagS == null || cTagS.Count == 0)
                return null;
            CDDEASymbolS cDDEASymbolS = new CDDEASymbolS();

            foreach (var who in cTagS)
            {
                CDDEASymbolS cSymbolS = CreateSymbolS(who.Value);
                if (cSymbolS != null && cSymbolS.Count > 0)
                    cDDEASymbolS.AddSymbolS(cSymbolS);
            }

            return cDDEASymbolS;
        }

        private string[] SendServerData(CTimeLogS cLogS)
        {
           // string[] saSendData = new string[cLogS.Count];
            string[] saSendData = new string[cLogS.Count+1];

            saSendData[0] = m_sPlcID;
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
            saSendData[cLogS.Count] = m_sPlcID;

            return saSendData;
        }

        private bool SetCollectModule()
        {
            bool bOK = false;
            if (m_cPlcConfig.CollectType == EMCollectType.OPC)
            {
                m_cOPCServer = new COPCServer();
                m_cOPCServer.Config = m_cPlcConfig.OPCConfig;
                m_cOPCServer.Config.Use = true;
                bOK = m_cOPCServer.Connect();
                if (bOK)
                {
                    bOK = m_cOPCServer.AddItemS(m_cReceiveTagS.Values.ToList());
                    if (bOK)
                    {
                        m_cOPCServer.UEventValueChanged += m_cOPCServer_UEventValueChanged;
                        bOK = m_cOPCServer.Run();
                        if (bOK)
                        {
                            m_cOPCServer.ValidateTagS(m_cReceiveTagS);
                            UpdateSystemMessage("OPC", "접속 성공");
                        }
                        else
                            UpdateSystemMessage("OPC", "Run 실패");
                    }
                    else
                        UpdateSystemMessage("OPC", "Item 추가에 실패했습니다");
                }
                else
                    UpdateSystemMessage("OPC", "연결에 실패했습니다");
            }
            else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
            {
                m_cLsReader = new CLsReader();
                UpdateSystemMessage("LS", "생성");
                m_cLsReader.Config = m_cPlcConfig.LsConfig;
                m_cLsReader.Config.Use = true;
                bOK = m_cLsReader.Connect();
                UpdateSystemMessage("LS", "Connect  " + bOK);
                if (bOK)
                {
                    bOK = m_cLsReader.AddItemS(m_cReceiveTagS.Values.ToList());
                    if (bOK)
                    {
                        m_cLsReader.UEventValueChanged += m_cLsReader_UEventValueChanged;
                        bOK = m_cLsReader.Run();
                        if (bOK)
                            UpdateSystemMessage("LS", "접속 성공");
                        else
                            UpdateSystemMessage("LS", "Run 실패");
                    }
                    else
                        UpdateSystemMessage("LS", "Item 추가에 실패했습니다");
                }
                else
                    UpdateSystemMessage("LS", "연결에 실패했습니다");
            }
            else
            {
                CDDEASymbolS cDDEASymbolS = ChangeDDEASymbolS(m_cReceiveTagS);

                //CReadFunction cReadFunc = new CReadFunction(m_cPlcConfig.MelsecConfig, EMPlcConnettionType.Melsec_Normal);
                //cReadFunc.VerifyTagS(m_cReceiveTagS);

                m_cDDEAProject = new CDDEAProject("Tracker");
                m_cDDEAProject.SetNormalBundleList(cDDEASymbolS);
                m_cDDEAProject.CollectMode = EMCollectMode.Normal;
                m_cDDEAProject.ConnectApp = EMConnectAppType.Tracker;
                m_cDDEAProject.Config = m_cPlcConfig.MelsecConfig;
                m_cDDEAReader = new CDDEARead(m_cDDEAProject, EMMelsecSeriesType.Melsec_Normal);
                m_cDDEAReader.UEventMessage += m_cDDEAReader_UEventMessage;
                m_cDDEAReader.UEventTrackerData += m_cDDEAReader_UEventTrackerData;
                bOK = m_cDDEAReader.Start();
                if (bOK)
                    UpdateSystemMessage("Melsec", "접속 성공");
                else
                    UpdateSystemMessage("Melsec", "Run 실패");
            }


            m_dicViewTag = ChangeViewTagList(m_cReceiveTagS);
            grdTag.DataSource = m_dicViewTag.Values.ToList();
            grdTag.RefreshDataSource();

            return bOK;
        }

        private bool Run()
        {
            try
            {
                if (m_bRun) return false;
                if (m_cPlcConfig.CollectType == EMCollectType.None) return false;
                m_bError = false;
                m_bRun = SetCollectModule();
                if (m_bRun == false)
                    m_bError = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
            return m_bRun;
        }

        private void Stop()
        {
            try
            {
                if (m_bRun == false) return;

                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                {
                    if (m_cDDEAReader == null)
                        return;

                    m_cDDEAReader.Stop();
                    m_cDDEAReader.UEventMessage -= m_cDDEAReader_UEventMessage;
                    m_cDDEAReader.UEventTrackerData -= m_cDDEAReader_UEventTrackerData;
                    m_cDDEAReader = null;
                    m_cDDEAProject.Clear();
                    m_cDDEAProject = null;
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                {
                    if (m_cLsReader == null)
                        return;

                    m_cLsReader.Stop();
                    m_cLsReader.Disconnect();
                    m_cLsReader.UEventValueChanged -= m_cLsReader_UEventValueChanged;
                    m_cLsReader = null;
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    if (m_cOPCServer == null)
                        return;

                    m_cOPCServer.Stop();
                    m_cOPCServer.Disconnect();
                    m_cOPCServer.UEventValueChanged -= m_cOPCServer_UEventValueChanged;
                    m_cOPCServer = null;
                }
                else
                    return;
                m_bRun = false;
                m_bError = false;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private CTimeLogS CollectSubDepthDDEA(List<string> lstLog)
        {
            CTimeLogS cLogS = new CTimeLogS();

            CDDEASymbolS cDDEASymbolS = ChangeDDEASymbolS(m_cSubReceiveTagS);
            List<CDDEASymbolList> lstSymbol = new List<CDDEASymbolList>();
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            Dictionary<string, int> dicSendData = new Dictionary<string, int>();
            int iCount = 0;
            string sAddressList = "";
            try
            {
                foreach (var who in cDDEASymbolS)
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
                CReadFunction cReadFunc = new CReadFunction(m_cPlcConfig.MelsecConfig);
                bool bOK = cReadFunc.Connect();

                if (bOK && m_bRun)
                {
                    m_cDDEAReader.Pause = true;
                    UpdateSystemMessage("하위 Depth 수집", "기존 수집대상을 일시정지 합니다.");
                    int iReadNumber = 0;

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
                    {
                        List<string>lstResult = CreateTimeLogS(cLogS);
                        lstLog.AddRange(lstResult);
                    }

                    m_cDDEAReader.Pause = false;
                    UpdateSystemMessage("하위 Depth 수집", "기존 수집대상으로 수집을 진행합니다.");
                }
                else
                    UpdateSystemMessage("하위 Depth 수집", "수집을 진행하고 있는 상태가 아닙니다.");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("수집", "하위 Depth 재수집에 문제가 있습니다. : " + ex.Message);
            }
            return cLogS;
        }

        private bool OpenConfig(string sPath, string sID)
        {
            CPlcConfigS cConfigS = new CPlcConfigS();
            m_cPlcConfig = cConfigS.OpenPlcConfigS(sPath, sID);
            if (m_cPlcConfig == null)
            {
                UpdateSystemMessage("Config", "해당 설정은 찾을 수 없습니다.");
                UpdateSystemMessage("Config", sPath);
                ShowHighErrorMessage("통신 설정 파일을 열 수 없습니다.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 0 = Error, 1=Run, 2 = ready
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="iStep"></param>
        private void SetLamp(string sText, int iStep)
        {
            if (iStep == 0)
            {
                btnLamp.Appearance.BackColor = Color.Red;
                btnLamp.Appearance.BackColor2 = Color.Tomato;
            }
            else if (iStep == 1)
            {
                btnLamp.Appearance.BackColor = Color.DarkGreen;
                btnLamp.Appearance.BackColor2 = Color.Lime;
            }
            else if (iStep == 2)
            {
                btnLamp.Appearance.BackColor = Color.DarkGoldenrod;
                btnLamp.Appearance.BackColor2 = Color.Yellow;
            }
            btnLamp.Text = sText;
        }

        private void UpdateGridView()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateGridCallback cUpdate = new UpdateGridCallback(UpdateGridView);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    m_dicViewTag = ChangeViewTagList(m_cReceiveTagS);
                    grdTag.DataSource = m_dicViewTag.Values.ToList();
                    grdTag.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ReadInstanceAfterStart()
        {
            try
            {
                if (m_saFirstTagListData == null || m_saFirstTagListData.Length == 0)
                {
                    UpdateSystemMessage("ERROR", "수집할 접점이 없습니다.");
                    return;
                }

                List<string> lstLogString = new List<string>();
                lstLogString.Add(m_saFirstTagListData[1]);
                m_cSubReceiveTagS.Clear();
                m_cSubReceiveTagS = ChangeTagS(m_saFirstTagListData);

                UpdateSystemMessage("ReadInstance After Start ReceviceTagList Count : ",
                    m_cSubReceiveTagS.Count.ToString());

                CTimeLogS cLogS = new CTimeLogS();
                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                    cLogS = CollectSubDepthDDEA(lstLogString);
                else if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    UpdateSystemMessage("SPD Single", "Log 생성 Start");

                    cLogS = m_cOPCServer.ReadInstant(m_cSubReceiveTagS.Values.ToList());

                    List<string> lstResult = CreateTimeLogS(cLogS);
                    if (lstResult != null)
                        lstLogString.AddRange(lstResult);
                    //Send LogData

                    UpdateSystemMessage("SPD Single", "Log 생성 End");
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                {
                    //묶음 처리 안됨.
                    cLogS = m_cLsReader.ReadInstant(m_cSubReceiveTagS.Values.ToList());
                    List<string> lstResult = CreateTimeLogS(cLogS);
                    if (lstResult != null)
                        lstLogString.AddRange(lstResult);
                }

                if (lstLogString != null && lstLogString.Count > 1)
                {
                    //Send LogData
                    SendTimeLogS(lstLogString.ToArray());
                }
                UpdateSystemMessage("SPD Single", "Log Send End");

                Dictionary<string, CViewTag> dicViewTag = ChangeViewTagList(m_cSubReceiveTagS);
                for (int i = 0; i < cLogS.Count; i++)
                {
                    if (dicViewTag.ContainsKey(cLogS[i].Key))
                    {
                        dicViewTag[cLogS[i].Key].CurrentValue = cLogS[i].Value;
                        dicViewTag[cLogS[i].Key].CollectTime = cLogS[i].Time;
                    }
                }

                UpdateSystemMessage("SPD Single", "화면 갱신 End");

                grdSubDepth.DataSource = dicViewTag.Values.ToList();
                grdSubDepth.RefreshDataSource();
                grdTag.RefreshDataSource();
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }
        #endregion


        #region Event Method

        private void ServiceCallBack_UEventReceiveCollectorList(object sender, string[] saData)
        {
            try
            {
                UpdateSystemMessage("Client", "Collector Config Open명령을 받았습니다.");
                if (m_sPlcID != saData[0]) return;
                if (saData.Length != 2) return;
                //Load 통신 설정
                if (m_sConfigFilePath == "" || m_cPlcConfig == null)
                {
                    m_sConfigFilePath = saData[1];

                    bool bOK = false;

                    if (m_sSender != "")
                    {
                        string[] saPlcID = m_sPlcID.Split(',');
                        bOK = OpenConfig(m_sConfigFilePath, saPlcID[1]);
                    }
                    else
                    {
                        bOK = OpenConfig(m_sConfigFilePath, m_sPlcID);
                    }

                    if (bOK == false)
                    {
                        string[] saCommand = {m_sPlcID, "Config Open", "Fail"};
                        SendMessage(saCommand);
                        m_bConfigOpen = false;
                        return;
                    }
                    else
                    {
                        string[] saCommand = {m_sPlcID, "Config Open", "Success"};
                        SendMessage(saCommand);
                        m_bConfigOpen = true;
                    }
                    CreateTable();
                }
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;

                m_cReceiveTagS.Clear();
                m_cReceiveTagS = ChangeTagS(saData);
                //Add
                m_saFirstTagListData = saData;

                CreateTable();

                //if (m_cReceiveTagS.Count > 0)
                {
                    grdTag.DataSource = m_cReceiveTagS.Values.ToList();
                    grdTag.RefreshDataSource();
                }

                string sData = string.Empty;
                for (int i = 0; i < saData.Length; i++)
                    sData += saData[i] + ", ";
                UpdateSystemMessage("EventTagList", sData);
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UVEventReceiveLadderViewTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;

                ServiceCallBack_UEventReceiveTagList(sender, saData);

                if (!m_bRun)
                {
                    // 실시간 Ladder View는 TagList 받으면 바로 실행하여 수집
                    string[] saStart = {"실시간 Ladder View 수집 시작"};
                    ServiceCallBack_UEventReceiveCommStart(sender, saStart);

                    if (m_bRun)
                    {
                        List<string> lstLogString = new List<string>();
                        //lstLogString.Add(saData[1]);
                        m_cSubReceiveTagS.Clear();
                        m_cSubReceiveTagS = ChangeTagS(saData);

                        CTimeLogS cLogS = new CTimeLogS();
                        if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                            cLogS = CollectSubDepthDDEA(lstLogString);
                        else if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                        {
                            UpdateSystemMessage("SPD Single", "Log 생성 Start");

                            cLogS = m_cOPCServer.ReadInstant(m_cReceiveTagS.Values.ToList());
                            List<string> lstResult = CreateTimeLogS(cLogS);
                            lstResult.Add(m_sPlcID);
                            lstLogString.AddRange(lstResult);

                            UpdateSystemMessage("SPD Single", "Log 생성 End");
                        }
                        else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                        {
                            //묶음 처리 안됨.
                            cLogS = m_cLsReader.ReadInstant(m_cReceiveTagS.Values.ToList());
                            List<string> lstResult = CreateTimeLogS(cLogS);
                            lstLogString.AddRange(lstResult);
                        }

                        if (lstLogString != null && lstLogString.Count > 1)
                        {
                            //Send LogData
                            SendTimeLogS(lstLogString.ToArray());
                        }

                        UpdateSystemMessage("SPD Single", "Log Send End");

                        Dictionary<string, CViewTag> dicViewTag = ChangeViewTagList(m_cSubReceiveTagS);
                        for (int i = 0; i < cLogS.Count; i++)
                        {
                            if (dicViewTag.ContainsKey(cLogS[i].Key))
                            {
                                dicViewTag[cLogS[i].Key].CurrentValue = cLogS[i].Value;
                                dicViewTag[cLogS[i].Key].CollectTime = cLogS[i].Time;
                            }
                        }

                        UpdateSystemMessage("SPD Single", "화면 갱신 End");

                        grdSubDepth.DataSource = dicViewTag.Values.ToList();
                        grdSubDepth.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveRecipeTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;
                List<string> lstLogString = new List<string>();
                lstLogString.Add(saData[1]);
                m_cSubReceiveTagS.Clear();
                m_cSubReceiveTagS = ChangeTagS(saData);

                UpdateSystemMessage("ReceviceRecipeTagList Count : ", m_cSubReceiveTagS.Count.ToString());

                CTimeLogS cLogS = new CTimeLogS();
                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                    cLogS = CollectSubDepthDDEA(lstLogString);
                else if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    UpdateSystemMessage("SPD Single", "Log 생성 Start");

                    cLogS = m_cOPCServer.ReadInstant(m_cSubReceiveTagS.Values.ToList());
                    List<string> lstResult = CreateTimeLogS(cLogS);

                    if(lstResult != null)
                        lstLogString.AddRange(lstResult);
                    //Send LogData

                    UpdateSystemMessage("SPD Single", "Log 생성 End");
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                {
                    //묶음 처리 안됨.
                    cLogS = m_cLsReader.ReadInstant(m_cSubReceiveTagS.Values.ToList());
                    List<string> lstResult = CreateTimeLogS(cLogS);
                    lstLogString.AddRange(lstResult);
                }

                if (lstLogString != null && lstLogString.Count > 1)
                {
                    SendRecipeTimeLogS(lstLogString.ToArray());
                }
                UpdateSystemMessage("SPD Single", "Log Send End");

                Dictionary<string, CViewTag> dicViewTag = ChangeViewTagList(m_cSubReceiveTagS);
                for (int i = 0; i < cLogS.Count; i++)
                {
                    if (dicViewTag.ContainsKey(cLogS[i].Key))
                    {
                        dicViewTag[cLogS[i].Key].CurrentValue = cLogS[i].Value;
                        dicViewTag[cLogS[i].Key].CollectTime = cLogS[i].Time;
                    }
                }

                UpdateSystemMessage("SPD Single", "화면 갱신 End");

                grdSubDepth.DataSource = dicViewTag.Values.ToList();
                grdSubDepth.RefreshDataSource();
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveEmergTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;
                List<string> lstLogString = new List<string>();
                lstLogString.Add(saData[1]);
                m_cSubReceiveTagS.Clear();
                m_cSubReceiveTagS = ChangeTagS(saData);

                UpdateSystemMessage("ReceviceEmergeTagList Count : ", m_cSubReceiveTagS.Count.ToString());

                CTimeLogS cLogS = new CTimeLogS();
                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                    cLogS = CollectSubDepthDDEA(lstLogString);
                else if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    UpdateSystemMessage("SPD Single", "Log 생성 Start");

                    cLogS = m_cOPCServer.ReadInstant(m_cSubReceiveTagS.Values.ToList());
                    List<string> lstResult = CreateTimeLogS(cLogS);

                    if(lstResult != null)
                        lstLogString.AddRange(lstResult);
                    //Send LogData

                    UpdateSystemMessage("SPD Single", "Log 생성 End");
                }
                else if (m_cPlcConfig.CollectType == EMCollectType.LSDDE)
                {
                    //묶음 처리 안됨.
                    cLogS = m_cLsReader.ReadInstant(m_cSubReceiveTagS.Values.ToList());
                    List<string> lstResult = CreateTimeLogS(cLogS);
                    lstLogString.AddRange(lstResult);
                }

                if (lstLogString != null && lstLogString.Count > 1)
                {
                    SendEmergTimeLogS(lstLogString.ToArray());
                }
                UpdateSystemMessage("SPD Single", "Log Send End");

                Dictionary<string, CViewTag> dicViewTag = ChangeViewTagList(m_cSubReceiveTagS);
                for (int i = 0; i < cLogS.Count; i++)
                {
                    if (dicViewTag.ContainsKey(cLogS[i].Key))
                    {
                        dicViewTag[cLogS[i].Key].CurrentValue = cLogS[i].Value;
                        dicViewTag[cLogS[i].Key].CollectTime = cLogS[i].Time;
                    }
                }

                UpdateSystemMessage("SPD Single", "화면 갱신 End");

                grdSubDepth.DataSource = dicViewTag.Values.ToList();
                grdSubDepth.RefreshDataSource();
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveCommStop(object sender, string[] saData)
        {
            try
            {
                m_saStopData = (string[]) saData.Clone();
                m_bMonitorStop = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveCommStart(object sender, string[] saData)
        {
            try
            {
                m_saStartData = (string[]) saData.Clone();
                m_bMonitorStart = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveAddTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;
                CTagS cAddTagS = ChangeTagS(saData);

                if (cAddTagS == null || cAddTagS.Count == 0)
                    return;

                if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    if (m_cOPCServer == null)
                        return;

                    if (m_cOPCServer.IsConnect)
                    {
                        List<string> lstLogString = new List<string>();
                        lstLogString.Add(saData[1]);

                        bool bOK = m_cOPCServer.AddItemS(cAddTagS.Values.ToList());

                        if (bOK)
                        {
                            UpdateSystemMessage("SPD Single", "Log 생성 Start");

                            CTimeLogS cLogS = m_cOPCServer.ReadInstant(cAddTagS.Values.ToList());
                            List<string> lstResult = CreateTimeLogS(cLogS);
                            lstLogString.AddRange(lstResult);
                            //Send LogData

                            UpdateSystemMessage("SPD Single", "Log 생성 End");
                            m_cReceiveTagS.AddRange(cAddTagS);
                            UpdateGridView();

                            UpdateSystemMessage("EventReceiveAddTagList", "Run 중 OPC Item 추가 성공!!");

                            string sData = string.Empty;
                            for (int i = 0; i < saData.Length; i++)
                                sData += saData[i] + ", ";
                            UpdateSystemMessage("EventReceiveAddTagList", sData);

                            if (lstLogString != null && lstLogString.Count > 1)
                            {
                                SendRecipeTimeLogS(lstLogString.ToArray());
                            }
                            UpdateSystemMessage("SPD Single", "Log Send End");
                        }
                        else
                            UpdateSystemMessage("EventReceiveAddTagList", "Run 중 OPC Item 추가 실패!!");
                    }
                    else
                        UpdateSystemMessage("EventReceiveAddTagList", "OPC 연결 실패");
                }
                else
                    UpdateSystemMessage("SPD Single", "Receive Add Tag List OPC Type이 아닙니다.");

                cAddTagS.Clear();
                cAddTagS = null;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventReceiveRemoveTagList(object sender, string[] saData)
        {
            try
            {
                if (saData.Length == 0) return;
                CTagS cRemoveTagS = ChangeTagS(saData);

                if (cRemoveTagS == null || cRemoveTagS.Count == 0)
                    return;

                if (m_cPlcConfig.CollectType == EMCollectType.OPC)
                {
                    if (m_cOPCServer == null)
                        return;

                    if (m_cOPCServer.IsConnect)
                    {
                        bool bOK = m_cOPCServer.RemoveItemS(cRemoveTagS.Values.ToList());

                        if (bOK)
                        {
                            foreach (string sKey in cRemoveTagS.Keys)
                            {
                                if (m_cReceiveTagS.ContainsKey(sKey))
                                    m_cReceiveTagS.Remove(sKey);
                            }

                            UpdateGridView();

                            UpdateSystemMessage("EventReceiveRemoveTagList", "Run 중 OPC Item 삭제 성공!!");

                            string sData = string.Empty;
                            for (int i = 0; i < saData.Length; i++)
                                sData += saData[i] + ", ";
                            UpdateSystemMessage("EventReceiveRemoveTagList", sData);
                        }
                        else
                            UpdateSystemMessage("EventReceiveRemoveTagList", "Run 중 OPC Item 삭제 실패!!");
                    }
                    else
                        UpdateSystemMessage("EventReceiveRemoveTagList", "OPC 연결 실패");
                }
                else
                    UpdateSystemMessage("SPD Single", "Receive Remove Tag List OPC Type이 아닙니다.");

                cRemoveTagS.Clear();
                cRemoveTagS = null;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
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
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        /// <summary>
        /// 첫번째 Data에서는 TagKey를 보냄
        /// </summary>
        /// <param name="saData"></param>
        private void SendEmergTimeLogS(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendEmergTimeLogSToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager로 Message가 전송되지 않았습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendRecipeTimeLogS(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendRecipeTimeLogSToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager로 Message가 전송되지 않았습니다." + ex.Message);
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
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager로 Message가 전송되지 않았습니다." + ex.Message);
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
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager로 Message가 전송되지 않았습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SendMessage(string[] saData)
        {
            if (m_cClient.IsConnected == false) return;
            try
            {
                m_cClient.Service.SendMessageToServer(saData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                Disconnect();
                Connect();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SPD Single", "SPD Manager로 Message가 전송되지 않았습니다." + ex.Message);
                ex.Data.Clear();
            }
        }

        private void ServiceCallBack_UEventTerminated(object sender, EventArgs e)
        {

        }

        #endregion


        #region Collect Event Method

        private void UpdateTagGrid(CTimeLogS cLogS)
        {
            try
            {
                for (int i = 0; i < cLogS.Count; i++)
                {
                    if (m_dicViewTag.ContainsKey(cLogS[i].Key))
                    {
                        m_dicViewTag[cLogS[i].Key].CurrentValue = cLogS[i].Value;
                        m_dicViewTag[cLogS[i].Key].ChangeCount++;
                    }
                }
                grdTag.RefreshDataSource();
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void m_cDDEAReader_UEventTrackerData(object sender, CTimeLogS cEventTimeLogS)
        {
            try
            {
                string[] saData = SendServerData(cEventTimeLogS);
                SendTimeLogS(saData);

                UpdateTagGrid(cEventTimeLogS);
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void m_cLsReader_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            try
            {
                UpdateSystemMessage("LS Event", "Log Count : " + cLogS.Count.ToString());

                string[] saData = SendServerData(cLogS);
                SendTimeLogS(saData);

                UpdateTagGrid(cLogS);
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void m_cOPCServer_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            try
            {
                string[] saData = SendServerData(cLogS);
                SendTimeLogS(saData);

                UpdateTagGrid(cLogS);
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void m_cDDEAReader_UEventMessage(object sender, string sSender, string sMessage)
        {
            try
            {
                UpdateSystemMessage(sSender, sMessage);
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        #endregion


        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {            
            //tmrFormStart.Start();
            tabMain.SelectedTabPage = tpSystemMessage;

            //테스트 코드
            string[] saData = { "5EFE4DBA-0" };
            if (saParameter == null || saParameter.Length != 1)
                saParameter = saData;
            if (saParameter == null || saParameter.Length == 0 || saParameter.Length != 1)
            {
                MessageBox.Show("정상실행되지 않았습니다.\r\nProgram을 종료합니다", "SPD Single", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                this.Close();
                return;
            }
            else
            {
                if (saParameter[0] == "" || saParameter[0].Contains("-") == false)
                {
                    MessageBox.Show("잘못된 ID 입니다.\r\nProgram을 종료합니다", "SPD Single", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (saParameter[0].Contains(','))
                {
                    string[] saTrackerPara = saParameter[0].Split(',');
                    m_sSender = saTrackerPara[0];
                }
                m_sPlcID = saParameter[0];
            }

            tabMain.SelectedTabPage = tpInformation;
            m_sSysLogPath += "\\" + m_sPlcID;
            m_cSysLog = new CSystemLog(m_sSysLogPath, m_sPlcID);
            tmrSystemLog.Start();
            SetLamp("Ready", 2);
            bool bOK = Connect();
            if (bOK == false)
                UpdateSystemMessage("Connect", "Manager와 연결에 실패했습니다.");
            else
            {
                ClientEventAdd();
                this.Text = string.Format("SPD Single ( ID : {0} )", m_sPlcID);
                UpdateSystemMessage("SetID", "ID : " + m_sPlcID);

                CreateTable();
            }

            if(m_sSender == "Tracker")
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.Opacity = 0;
            }

            tmrStateCheck.Start();
            tmrMonitorStart.Start();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bRun)
            {
                e.Cancel = true;
                MessageBox.Show("먼저 Stop해야만 합니다.");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
            ClientEventRemove();
            UpdateSystemMessage("FormClose", "정상 종료되었습니다.");
            tmrSystemLog.Stop();
        }

        private void tmrStatusReport_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrStatusReport.Enabled = false;

                if (m_bConnect)
                {
                    string sModeBuf = m_sMode;
                    if (m_bError)
                    {
                        sModeBuf = "Error";
                    }
                    else
                    {
                        if (m_bRun)
                            sModeBuf = "RUN";
                        else if (m_bRun == false)
                            sModeBuf = "Ready";
                    }
                    //if (m_sMode != sModeBuf)
                    {
                        m_sMode = sModeBuf;
                        string[] saData = {m_sPlcID, m_sMode};
                        SendStatus(saData);
                    }
                }

                tmrStatusReport.Enabled = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

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

                    m_cSysLog = new CSystemLog(m_sSysLogPath, m_sPlcID);

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

        private void btnRunDetailView_Click(object sender, EventArgs e)
        {
            if (m_bRun == false)
                return;
            Form frmOpenCheck = IsFormOpened(typeof(FrmDetailView));
            if (frmOpenCheck == null)
            {
                FrmDetailView frmDetailView = new FrmDetailView(m_cDDEAReader);

                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                {
                    if (m_cPlcConfig.MelsecConfig.SelectedItem == EMConnectTypeMS.MNetG || m_cPlcConfig.MelsecConfig.SelectedItem == EMConnectTypeMS.MNetH)
                    {
                        frmDetailView.DetailViewData.Add(ShowDetailData("통신 타입", m_cPlcConfig.MelsecConfig.SelectedItem.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert CPUType", m_cPlcConfig.MelsecConfig.MNet.CPUType.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert CpuNumber", m_cPlcConfig.MelsecConfig.MNet.CpuNumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert NetworkNumber", m_cPlcConfig.MelsecConfig.MNet.NetworkNumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert StationNumber", m_cPlcConfig.MelsecConfig.MNet.StationNumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert IONumber", m_cPlcConfig.MelsecConfig.MNet.IONumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert UnitNumber", m_cPlcConfig.MelsecConfig.MNet.UnitNumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert PortNumber", m_cPlcConfig.MelsecConfig.MNet.PortNumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert DestinationIONumber", m_cPlcConfig.MelsecConfig.MNet.DestinationIONumber.ToString()));
                        frmDetailView.DetailViewData.Add(ShowDetailData("MNert MultiDropChannelNumber", m_cPlcConfig.MelsecConfig.MNet.MultiDropChannelNumber.ToString()));
                    }
                }

                frmDetailView.Show();
            }
        }

        private CDetailViewData ShowDetailData(string sItem, string sValue)
        {
            CDetailViewData cData = new CDetailViewData();
            cData.Item = sItem;
            cData.Value = sValue;

            return cData;
        }

        #endregion

        private void lblMessage_DoubleClick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlBackGround.Visible = false;
        }

        private void ShowHighErrorMessage(string sText)
        {
            tmrError.Start();
            lblMessage.Text = sText;
            pnlBackGround.Visible = true;
            pnlBackGround.BringToFront();
        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Enabled = false;

            Color cColor1 = pnlBackGround.Appearance.BackColor;
            Color cColor2 = pnlBackGround.Appearance.BackColor2;

            pnlBackGround.Appearance.BackColor = cColor2;
            pnlBackGround.Appearance.BackColor2 = cColor1;

            pnlBackGround.Refresh();

            tmrError.Enabled = true;
        }

        private void btnOpenSystemMsg_Click(object sender, EventArgs e)
        {
            if (m_sSysLogPath != null && m_sSysLogPath != "")
            {
                if (!Directory.Exists(m_sSysLogPath))
                    Directory.CreateDirectory(m_sSysLogPath);

                Process.Start(m_sSysLogPath);
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            int iSptWidth = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.5);
            sptCurrentData.SplitterPosition = iSptWidth;
        }

        private void grvTag_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvSubDepth_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void btnTerminateStop_Click(object sender, EventArgs e)
        {
            m_cDDEAReader.Stop();
            btnTerminateStop.Enabled = false;
        }

        private void trmStateCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrStateCheck.Enabled = false;
                if (m_bMonitorStop)
                {
                    m_bMonitorStop = false;
                    if (m_saStopData == null)
                    {
                        UpdateSystemMessage("Stop Timer", "받은데이터가 없습니다.");
                    }
                    else
                    {
                        string sData = "";
                        for (int i = 0; i < m_saStopData.Length; i++)
                            sData += m_saStopData[i] + ", ";

                        sData = sData.Substring(0, sData.LastIndexOf(','));

                        UpdateSystemMessage("EventStopCommand", sData);

                        if (sData.Contains("Close"))
                        {
                            Stop();
                            this.Close();
                        }
                        else
                        {
                            Stop();
                            SetLamp("Ready", 2);
                        }
                    }

                }
                tmrStateCheck.Enabled = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

        private void tmrMonitorStart_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrMonitorStart.Enabled = false;
                if (m_bMonitorStart)
                {
                    m_bMonitorStart = false;
                    if (m_saStartData == null || m_cReceiveTagS.Count == 0)
                    {
                        if (m_cReceiveTagS.Count == 0)
                            UpdateSystemMessage("Start", "Collect Symbol Count = 0");
                        else
                            UpdateSystemMessage("Start Timer", "Message Fail");
                    }
                    else
                    {
                        string sData = "";
                        for (int i = 0; i < m_saStartData.Length; i++)
                            sData += m_saStartData[i] + ", ";
                        UpdateSystemMessage("EventStartCommand", sData);
                        if (m_bConfigOpen)
                        {

                            bool bOK = Run();
                            if (bOK)
                            {
                                SetLamp("Run", 1);
                                //실제 시작 구간
                                if (m_cPlcConfig.CollectType == EMCollectType.DDEA)
                                {
                                    m_cDDEAReader.DoWork();
                                    btnTerminateStop.Enabled = true;
                                }

                                ReadInstanceAfterStart();
                            }
                            else SetLamp("Error", 0);
                        }
                        else
                        {
                            UpdateSystemMessage("Config", "통신 설정이 없습니다.");
                            ShowHighErrorMessage("통신 설정이 없습니다.");
                            SetLamp("Error", 0);
                        }
                    }
                }
                tmrMonitorStart.Enabled = true;
            }
            catch (Exception ex)
            {
                string[] saError =
                {
                    "SPD Single ERROR",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message)
                };

                UpdateSystemMessage(saError[0], saError[1]);
                ex.Data.Clear();
            }
        }

    }
}
