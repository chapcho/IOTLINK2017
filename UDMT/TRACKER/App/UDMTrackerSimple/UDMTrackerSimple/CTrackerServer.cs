using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using TrackerSPD.OPC;
using TrackerSPD.DDEA;
using TrackerWCF;
using UDM.Common;
using UDM.General.Remote;
using UDM.Log;
using UDM.Log.DB;
using DevExpress.XtraSplashScreen;
using System.ServiceModel;

namespace UDMTrackerSimple
{
    public class CTrackerServer
    {
        #region Member Varialbles

        private bool m_bRun = false;
        private bool m_bClientConnected = false;
        private bool m_bOptimizeMode = false;
        private string m_sSelectedProcess = string.Empty;

        private Dictionary<string, int> m_dicUnknownErrorClient = null;
        private CServer<IMyService, CMyService> m_cServer = null;
        private Dictionary<string, List<string>> m_dicPlcSendItem = new Dictionary<string, List<string>>();
        protected Dictionary<string, CService> m_dicClient = new Dictionary<string, CService>();

        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerTrackerTimeLogS UEventTimeLogS = null;
        public event UEventHandlerTrackerLadderViewTimeLogS UEventLadderViewTimeLogS = null;
        public event UEventHandlerTrackerEmergTimeLogS UEventEmergTimeLogS = null;        
        public event UEventHandlerTrackerSPDStatus UEventSPDStatus = null;
        public event UEventHandlerTrackerLadderViewSPDStatus UEventLadderViewSPDStatus = null;
        public event UEventHandlerTrackerClientStatus UEventClientConnect = null;
        public event UEventHandlerTrackerRecipeLogS UEventRecipeLogS = null;

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public bool IsOptimizeMode
        {
            get { return m_bOptimizeMode; }
            set { m_bOptimizeMode = value; }
        }

        public string SelectedProcess
        {
            get { return m_sSelectedProcess; }
            set { m_sSelectedProcess = value; }
        }

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public Dictionary<string, int> UnknownErrorClient
        {
            get { return m_dicUnknownErrorClient; }
            set { m_dicUnknownErrorClient = value; }
        }

        #endregion


        #region Private Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private Dictionary<string, CTagS> GetTagSDistributedPlc(List<string> lstTagKey)
        {
            Dictionary<string, CTagS> dicTagS = new Dictionary<string, CTagS>();
            CTagS cTagS = null;
            CTag cTag = null;

            foreach (string sKey in lstTagKey)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                    continue;

                cTag = CMultiProject.TotalTagS[sKey];

                if (dicTagS.ContainsKey(cTag.Creator))
                {
                    cTagS = dicTagS[cTag.Creator];
                    cTagS.Add(cTag.Key, cTag);
                }
                else
                {
                    cTagS = new CTagS();
                    cTagS.Add(cTag.Key, cTag);
                    dicTagS.Add(cTag.Creator, cTagS);
                }
            }
            return dicTagS;
        }

        private void ValidateCollectTagS()
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();

                //Detection일 때 AllSubDepthKeyList도 수집가능한지 모두 확인

                if (CMultiProject.PlcConfigS != null && CMultiProject.PlcConfigS.Count != 0)
                {
                    foreach (var who in CMultiProject.PlcConfigS)
                    {
                        if (who.Value.CollectType.Equals(EMCollectType.OPC))
                            ValidateOPC(who.Value, CMultiProject.PlcLogicDataS[who.Key].TagS);

                        else if (who.Value.CollectType.Equals(EMCollectType.DDEA))
                            ValidateDDEA(who.Value, CMultiProject.PlcLogicDataS[who.Key].TagS);
                    }
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("TrackerServer",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
            finally
            {
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }

        private List<string> ValidateDDEA(CPlcConfig cConfig, CTagS cTagS)
        {
            List<string> lstError = new List<string>();
            try
            {
                CReadFunction cRead = new CReadFunction(cConfig.MelsecConfig);
                cRead.VerifyTagS(cTagS);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("TrackerServer ValidateOPC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return lstError;
        }

        private List<string> ValidateOPC(CPlcConfig cConfig, CTagS cTagS)
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
                    XtraMessageBox.Show("OPC Server가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("TrackerServer ValidateOPC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return lstError;
        }

        private List<string> ValidateLadderViewTagS(CPlcConfig cPlcConfig, CTagS cTags)
        {
            List<string> lstSendTagS = new List<string>();
            List<string> lstErrTagS = null;

            try
            {
                if (cPlcConfig.CollectType.Equals(EMCollectType.OPC))
                {
                    lstErrTagS = ValidateOPC(cPlcConfig, cTags);
                }

                if (lstErrTagS != null)
                {
                    foreach (string sTag in lstErrTagS)
                    {
                        if (cTags.ContainsKey(sTag))
                            cTags.Remove(sTag);
                    }
                }

                lstSendTagS.Add("Tracker," + cPlcConfig.PlcID);
                foreach (CTag cTag in cTags.Values)
                {
                    string sItem = CreateItem(cTag);
                    lstSendTagS.Add(sItem);
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return lstSendTagS;
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

        public string CreateItem(CTag cTag)
        {
            if (cTag.Address.Trim() == "")
                return "";

            string sLine = cTag.Key +  "," + cTag.Address + "," + cTag.DataType.ToString() + "," + cTag.Size.ToString();

            return sLine;
        }

        public bool SendCollectList()
        {
            bool bOK = false;

            List<string> lstSendData = new List<string>();
            lstSendData.Add(CMultiProject.ConfigFilePath);
            lstSendData.AddRange(CMultiProject.PlcLogicDataS.Select(b => b.Key).ToList());
            bOK = SendCollectorList(lstSendData.ToArray());

            return bOK;
        }


        #region Client Send Command

        public void SendStartCommand(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendStartCommand", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendStartCommand", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name)); 
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendStopCommand(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendStopCommand", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendStopCommand", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public bool SendCollectorList(string[] saData)
        {
            bool bOK = false;

            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendCollectorListToClient(saData);
                        bOK = true;
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendCollectorList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendCollectorList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                        bOK = false;
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                    bOK = false;
                }
            }

            return bOK;
        }

        public void SendAddTagList(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendAddTagList", string.Format("CMyService SendAddTagListToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendAddTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendRemoveTagList(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendRemoveTagList", string.Format("CMyService SendRemoveTagListToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendRemoveTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendTagList(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendTagList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendLadderViewTagList(string[] saData)
        {

            if (m_cServer != null && m_cServer.IsRunning)
            {
                if (m_cServer.Service != null)
                {
                    try
                    {
                        m_cServer.Service.SendLadderViewTagListToClient(saData);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendTagList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendEmergTagList(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendEmergTagList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendEmergTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    UpdateSystemMessage("SendEmergTagList", "CMyService SendToClient Error: No Services !!!");
                }
            }
        }

        public void SendRecipeTagList(string[] saData)
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
                        UpdateSystemMessage("Server", "Tracker Reader와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        UpdateSystemMessage("SendRecipeTagList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendRecipeTagList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
                        ex.Data.Clear();
                    }
                }
                else
                {
                    UpdateSystemMessage("SendRecipeTagList", "CMyService SendToClient Error: No Services !!!");
                }
            }
        }


        #endregion


        #endregion


        #region Public Method

        public bool StartServer()
        {
            bool bOK = true;

            try
            {
                if (m_cServer == null)
                    m_cServer = new CServer<IMyService, CMyService>();

                if (m_cServer.IsRunning == false)
                    bOK = m_cServer.Start();

                if (bOK)
                {
                    m_cServer.Service.UEventReceiveTimeLogS += Service_UEventReceiveTimeLogS;
                    m_cServer.Service.UEventReceiveEmergTimeLogS += Service_UEventReceiveEmergTimeLogS;
                    m_cServer.Service.UEventReceiveStatus += Service_UEventReceiveStatus;
                    m_cServer.Service.UEventReceiveClientMessage += Service_UEventReceiveClientMessage;
                    m_cServer.Service.UEventReceiveErrorTagList += Service_UEventReceiveErrorTagList;
                    m_cServer.Service.UEventClientConnected += Service_UEventClientConnected;
                    m_cServer.Service.UEventClientDisconnected += Service_UEventClientDisconnected;
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
            try
            {
                if (m_cServer != null && m_cServer.IsRunning)
                {
                    m_cServer.Service.UEventReceiveTimeLogS -= Service_UEventReceiveTimeLogS;
                    m_cServer.Service.UEventReceiveEmergTimeLogS -= Service_UEventReceiveEmergTimeLogS;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public bool Run()
        {
            try
            {
                if (m_bClientConnected == false)
                {
                    UpdateSystemMessage("Manager", "연결된 Manager가 없습니다.");
                    return false;
                }

                //첫번째 값에는 통신 설정 Path,PLC ID List 전송
                if (CMultiProject.PlcIDList.Count == 0)
                {
                    UpdateSystemMessage("PLC", "시작할 PLC가 없습니다.");
                    return false;
                }

                if (File.Exists(CMultiProject.ConfigFilePath) == false)
                {
                    UpdateSystemMessage("Config", "통신 설정 파일이 존재하지 않습니다.");
                    return false;
                }

                //CollectTagList전송
                List<string> lstTagKey = CMultiProject.PlcProcS.GetCollectTagKeyList(CMultiProject.MonitorType, m_bOptimizeMode, m_sSelectedProcess);
                lstTagKey.AddRange(CMultiProject.ProjectInfo.GetCollectTagKeyList());

                if (CMultiProject.LineInfoS.AllSymbolListKeyList().Count != 0)
                    lstTagKey.AddRange(CMultiProject.LineInfoS.AllSymbolListKeyList());

                List<string> lstFilterTagKey = new List<string>();
                for (int i = 0; i < lstTagKey.Count; i++)
                {
                    if (lstFilterTagKey.Contains(lstTagKey[i]) == false)
                        lstFilterTagKey.Add(lstTagKey[i]);
                }

                ValidateCollectTagS();
                m_dicPlcSendItem.Clear();

                List<CTag> lstCollectTag = new List<CTag>();
                foreach (string key in lstFilterTagKey)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(key))
                    {
                        CTag cTag = CMultiProject.TotalTagS[key];
                        lstCollectTag.Add(cTag);
                        if (cTag.IsCollectUsed == false) continue;
                        string sItem = CreateItem(cTag);
                        if (m_dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                        {
                            m_dicPlcSendItem.Add(cTag.Creator, new List<string>());
                            m_dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                            m_dicPlcSendItem[cTag.Creator].Add(sItem);
                        }
                        else
                            m_dicPlcSendItem[cTag.Creator].Add(sItem);
                    }
                }
                //수집대상 상태 정보기록할 symbol 생성
                CMultiProject.CurrentCollectSymbolS.CreateCollectSymbolList(lstCollectTag);

                System.Threading.Thread.Sleep(2000);

                foreach (var who in m_dicPlcSendItem)
                {
                    UpdateSystemMessage("Server" + who.Key, string.Format("전송 Tag수 : {0}", who.Value.Count));
                    SendTagList(who.Value.ToArray());
                    System.Threading.Thread.Sleep(200);
                    string[] saSendData = { who.Key };
                    UpdateSystemMessage("Server" + who.Key, string.Format("SPD 수집 시작 명령"));
                    SendStartCommand(saSendData);
                }

                m_bRun = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return true;
        }

        public bool SendAddTagList(CTagS cTagS)
        {
            bool bOK = false;

            try
            {
                if (cTagS == null || cTagS.Count == 0)
                    return false;

                Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

                foreach (CTag cTag in cTagS.Values)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(cTag.Key) == false) continue;
                    if (CMultiProject.TotalTagS[cTag.Key].IsCollectUsed == false) continue;

                    string sItem = CreateItem(cTag);
                    if (dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                    {
                        dicPlcSendItem.Add(cTag.Creator, new List<string>());
                        dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                        dicPlcSendItem[cTag.Creator].Add(sItem);
                    }
                    else
                        dicPlcSendItem[cTag.Creator].Add(sItem);
                }

                foreach (var who in dicPlcSendItem)
                {
                    UpdateSystemMessage("Server" + who.Key, string.Format("전송 Add Tag수 : {0}", who.Value.Count));
                    SendAddTagList(who.Value.ToArray());
                    bOK = true;
                    System.Threading.Thread.Sleep(200);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool SendRemoveTagList(CTagS cTagS)
        {
            bool bOK = false;

            if (cTagS == null || cTagS.Count == 0)
                return false;

            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            foreach (CTag cTag in cTagS.Values)
            {
                string sItem = CreateItem(cTag);
                if (dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                {
                    dicPlcSendItem.Add(cTag.Creator, new List<string>());
                    dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                    dicPlcSendItem[cTag.Creator].Add(sItem);
                }
                else
                    dicPlcSendItem[cTag.Creator].Add(sItem);
            }

            foreach (var who in dicPlcSendItem)
            {
                UpdateSystemMessage("Server" + who.Key, string.Format("전송 Remove Tag수 : {0}", who.Value.Count));
                SendRemoveTagList(who.Value.ToArray());
                bOK = true;
                System.Threading.Thread.Sleep(200);
            }

            return bOK;
        }

        public bool SendLadderViewTagList(CPlcConfig cPlcConfig, CTagS cTagS, bool bAddTagS)
        {
            bool bOK = false;
            List<string> lstSendItem = ValidateLadderViewTagS(cPlcConfig, cTagS);
            string[] saData = lstSendItem.ToArray();

            UpdateSystemMessage("Server Tracker," + cPlcConfig.PlcID, string.Format("전송 Tag수 : {0}", lstSendItem.Count));

            Thread.Sleep(200);

            if (!bAddTagS)
                SendLadderViewTagList(saData);

            else
                SendAddTagList(saData);

            bOK = true;

            return bOK;
        }

        public bool SendLadderViewRemoveTagList(CPlcConfig cPlcConfig, CTagS cTagS)
        {
            bool bOK = false;

            if (cTagS == null || cTagS.Count == 0)
                return false;

            List<string> lstSendItem = ValidateLadderViewTagS(cPlcConfig, cTagS);
            string[] saData = lstSendItem.ToArray();

            UpdateSystemMessage("Server Tracker,", string.Format("전송 Remove Tag수 : {0}", lstSendItem.Count));
            SendRemoveTagList(saData);
            bOK = true;
            System.Threading.Thread.Sleep(200);
            
            return bOK;
        }

        /// <summary>
        /// 수집중인 SPD 정지
        /// </summary>
        public void SPDStop()
        {
            try
            {
                foreach (var who in CMultiProject.PlcConfigS)
                {
                    if (m_dicUnknownErrorClient != null && m_dicUnknownErrorClient.ContainsKey(who.Key) && m_dicUnknownErrorClient[who.Key] > 0)
                        continue;

                    string[] saSendData = { who.Key };
                    UpdateSystemMessage("Server" + who.Key, string.Format("SPD 수집 정지 명령"));
                    SendStopCommand(saSendData);
                }

                m_bRun = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SPDClose()
        {
            try
            {
                foreach (var who in CMultiProject.PlcConfigS)
                {
                    if (m_dicUnknownErrorClient != null && m_dicUnknownErrorClient.ContainsKey(who.Key) && m_dicUnknownErrorClient[who.Key] > 0)
                        continue;

                    string[] saSendData = {who.Key, "Close"};
                    UpdateSystemMessage("Server" + who.Key, string.Format("SPD 종료 명령"));

                    SendStopCommand(saSendData);
                }

                string[] saSendData1 = { "Manager Close" };
                SendStopCommand(saSendData1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void GetSubDepthStateValue(CAbnormalSymbol cSymbol)
        {
            try
            {
                Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

                if (dicPlcSendItem.ContainsKey(cSymbol.Tag.Creator) == false)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(cSymbol.Tag.Key))
                    {
                        if (CMultiProject.TotalTagS[cSymbol.Tag.Key].IsCollectUsed)
                        {
                            dicPlcSendItem.Add(cSymbol.Tag.Creator, new List<string>());
                            dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Creator);
                            dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Key);
                        }
                    }
                }

                CTag cTag;
                foreach (string sKey in cSymbol.AllSubDepthTagKeyList)
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                        continue;

                    cTag = CMultiProject.TotalTagS[sKey];
                    if (cTag.IsCollectUsed == false) continue;
                    string sItem = CreateItem(cTag);
                    dicPlcSendItem[cTag.Creator].Add(sItem);
                }

                foreach (var who in dicPlcSendItem)
                {
                    SendEmergTagList(who.Value.ToArray());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void GetSubDepthStateValue(CKeySymbol cSymbol)
        {
            try
            {
                Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

                if (dicPlcSendItem.ContainsKey(cSymbol.Tag.Creator) == false)
                {
                    if (CMultiProject.TotalTagS.ContainsKey(cSymbol.Tag.Key))
                    {
                        if (CMultiProject.TotalTagS[cSymbol.Tag.Key].IsCollectUsed)
                        {
                            dicPlcSendItem.Add(cSymbol.Tag.Creator, new List<string>());
                            dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Creator);
                            dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Key);
                        }
                    }
                }

                CTag cTag;
                foreach (string sKey in cSymbol.AllSubDepthTagKeyList)
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                        continue;

                    cTag = CMultiProject.TotalTagS[sKey];
                    if (cTag.IsCollectUsed == false) continue;
                    string sItem = CreateItem(cTag);
                    dicPlcSendItem[cTag.Creator].Add(sItem);
                }

                foreach (var who in dicPlcSendItem)
                    SendEmergTagList(who.Value.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void GetRecipeValue(CTagS cRecipeTagS)
        {
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            CTag cTag;
            for (int i = 0; i < cRecipeTagS.Count; i++)
            {
                cTag = cRecipeTagS[i];

                if (CMultiProject.TotalTagS.ContainsKey(cTag.Key) == false) continue;
                if (CMultiProject.TotalTagS[cTag.Key].IsCollectUsed == false) continue;
                
                string sItem = CreateItem(cTag);
                if (dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                {
                    dicPlcSendItem.Add(cTag.Creator, new List<string>());
                    dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                    dicPlcSendItem[cTag.Creator].Add(sItem);
                }
                else
                    dicPlcSendItem[cTag.Creator].Add(sItem);
            }

            foreach (var who in dicPlcSendItem)
                SendRecipeTagList(who.Value.ToArray());
        }

        public void GetSubDepthStateValue(string sMasterKey, List<string> lstTag)
        {
            try
            {
                Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

                CTag cTag;
                foreach (string sKey in lstTag)
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                        continue;
                    cTag = CMultiProject.TotalTagS[sKey];
                    if (cTag.IsCollectUsed == false) continue;
                    string sItem = CreateItem(cTag);
                    if (dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                    {
                        dicPlcSendItem.Add(cTag.Creator, new List<string>());
                        dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                        dicPlcSendItem[cTag.Creator].Add(sMasterKey);
                        dicPlcSendItem[cTag.Creator].Add(sItem);
                    }
                    else
                        dicPlcSendItem[cTag.Creator].Add(sItem);
                }

                foreach (var who in dicPlcSendItem)
                    SendEmergTagList(who.Value.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public CTimeLogS GetSubDepthStateValue(CTagS cTagS)
        {
            CTimeLogS cLogS = new CTimeLogS();
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;

                if (CMultiProject.TotalTagS.ContainsKey(cTag.Key) == false) continue;
                if (CMultiProject.TotalTagS[cTag.Key].IsCollectUsed == false) continue;

                string sItem = CreateItem(cTag);
                if (dicPlcSendItem.ContainsKey(cTag.Creator) == false)
                {
                    dicPlcSendItem.Add(cTag.Creator, new List<string>());
                    dicPlcSendItem[cTag.Creator].Add(cTag.Creator);
                    dicPlcSendItem[cTag.Creator].Add(sItem);
                }
                else
                    dicPlcSendItem[cTag.Creator].Add(sItem);
            }

            foreach (var who in dicPlcSendItem)
            {
                SendEmergTagList(who.Value.ToArray());
            }

            return cLogS;
        }


        #endregion


        #region Event Method

        private void Service_UEventReceiveClientMessage(object sender, string[] saData)
        {
            try
            {
                string sData = "";
                for (int i = 1; i < saData.Length; i++)
                    sData += saData[i] + ", ";
                UpdateSystemMessage(saData[0], sData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveErrorTagList(object sender, string[] saData)
        {
            try
            {
                string sData = "";
                for (int i = 1; i < saData.Length; i++)
                    sData += saData[i] + ", ";
                UpdateSystemMessage(saData[0], sData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveStatus(object sender, string[] saData)
        {
            try
            {
                //string sData = "";
                //for (int i = 1; i < saData.Length; i++)
                //    sData += saData[i] + ", ";
                //UpdateSystemMessage(saData[0], sData);

                string sClient = saData[0];

                if (sClient.Contains("Tracker"))
                {
                    if (UEventLadderViewSPDStatus != null)
                        UEventLadderViewSPDStatus(saData);
                }
                else
                {
                    if (UEventSPDStatus != null)
                        UEventSPDStatus(saData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveTimeLogS(object sender, string[] saData)
        {
            try
            { 
            CService cser = (CService)sender;
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

                    //실시간 Ladder View 수집일 경우 TimeLog
                    if (sClient.Contains("Tracker"))
                    {
                        if (UEventLadderViewTimeLogS != null)
                            UEventLadderViewTimeLogS(EMTrackerLogType.ContinueLog, cLogS);
                    }
                    else
                    {
                        if (UEventTimeLogS != null)
                            UEventTimeLogS(EMTrackerLogType.ContinueLog, cLogS);
                    }
                    cLogS.Clear();
                    cLogS = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveEmergTimeLogS(object sender, string[] saData)
        {
            try
            {
                //첫번째는 수집된 상위 TagKey
                if (saData != null)
                {
                    CTimeLogS cLogS = new CTimeLogS();
                    CTimeLog cLog = null;
                    string sKey = saData[0];
                    for (int i = 1; i < saData.Length; i++)
                    {
                        cLog = CreateTimeLog(saData[i]);

                        if (cLog != null)
                            cLogS.Add(cLog);
                    }

                    if (UEventEmergTimeLogS != null)
                        UEventEmergTimeLogS(EMTrackerLogType.SubDepthLog, sKey, cLogS);

                    cLogS.Clear();
                    cLogS = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveRecipeTimeLogS(object sender, string[] saData)
        {
            try
            {
                //첫번째는 수집된 상위 TagKey
                if (saData != null)
                {
                    CTimeLogS cLogS = new CTimeLogS();
                    CTimeLog cLog = null;
                    string sKey = saData[0];
                    for (int i = 1; i < saData.Length; i++)
                    {
                        cLog = CreateTimeLog(saData[i]);

                        if (cLog != null)
                            cLogS.Add(cLog);
                    }

                    if (UEventRecipeLogS != null)
                        UEventRecipeLogS(cLogS);

                    cLogS.Clear();
                    cLogS = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventClientDisconnected(object sender, string sClient)
        {
            try
            {
                if (m_dicClient.ContainsKey(sClient))
                {
                    m_dicClient.Remove(sClient);
                }

                if (sClient.Contains("Manager"))
                {
                    //LED상태 표시 (OFF)
                    m_bClientConnected = false;
                    UpdateSystemMessage("Tracker Reader", "연결이 해제되었습니다.");
                    if (UEventClientConnect != null)
                        UEventClientConnect(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            try
            {
                CService cService = (CService) sender;
                if (!m_dicClient.ContainsKey(sClient))
                {
                    m_dicClient.Add(sClient, cService);
                }

                if (sClient.Contains("Manager"))
                {
                    //LED 상태 표시 (ON)
                    m_bClientConnected = true;
                    UpdateSystemMessage("Tracker Reader", "연결 되었습니다.");
                    if (UEventClientConnect != null)
                        UEventClientConnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion
    }
}
