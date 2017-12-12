using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrackerCommon;
using TrackerWCF;
using UDM.Common;
using UDM.General.Remote;
using UDM.Log;
using UDM.Log.DB;

namespace UDMLadderTracker
{
    public class CTrackerServer
    {
        #region Member Varialbles

        private bool m_bRun = false;
        private bool m_bClientConnected = false;
        private CServer<IMyService, CMyService> m_cServer = null;
        private Dictionary<string, List<string>> m_dicPlcSendItem = new Dictionary<string, List<string>>();
        
        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerTrackerTimeLogS UEventTimeLogS = null;
        public event UEventHandlerTrackerEmergTimeLogS UEventEmergTimeLogS = null;        
        public event UEventHandlerTrackerSPDStatus UEventSPDStatus = null;
        public event UEventHandlerTrackerClientStatus UEventClientConnect = null;

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        #endregion


        #region Private Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
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

        public void SendCollectList()
        {
            List<string> lstSendData = new List<string>();
            lstSendData.Add(CMultiProject.ConfigFilePath);
            lstSendData.AddRange(CMultiProject.PlcLogicDataS.Select(b => b.Key).ToList());
            SendCollectorList(lstSendData.ToArray());
        }

        #region Client Send Command

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

        public void SendCollectorList(string[] saData)
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
                        UpdateSystemMessage("SendCollectorList", string.Format("CMyService SendToClient Error: {0}", ex.Message));
                        UpdateSystemMessage("SendCollectorList", string.Format("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name));
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

        public bool Run()
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

            //SendCollectList();

            //CollectTagList전송
            List<string> lstTagKey = CMultiProject.PlcProcS.GetCollectTagKeyList(CMultiProject.MonitorType);
            lstTagKey.AddRange(CMultiProject.ProjectInfo.GetCollectTagKeyList());

            List<string> lstFilterTagKey = new List<string>();
            for (int i = 0; i < lstTagKey.Count; i++)
            {
                if (lstFilterTagKey.Contains(lstTagKey[i]) == false)
                    lstFilterTagKey.Add(lstTagKey[i]);
            }

            m_dicPlcSendItem.Clear();

            foreach (string key in lstFilterTagKey)
            {
                if (CMultiProject.TotalTagS.ContainsKey(key))
                {
                    CTag cTag = CMultiProject.TotalTagS[key];
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

            System.Threading.Thread.Sleep(200);

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

            return true;
        }

        /// <summary>
        /// 수집중인 SPD 정지
        /// </summary>
        public void SPDStop()
        {
            foreach (var who in m_dicPlcSendItem)
            {
                string[] saSendData = { who.Key };
                UpdateSystemMessage("Server" + who.Key, string.Format("SPD 수집 정지 명령"));
                SendStopCommand(saSendData);
            }

            m_bRun = false;
        }

        public void GetSubDepthStateValue(CAbnormalSymbol cSymbol)
        {
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            if(dicPlcSendItem.ContainsKey(cSymbol.Tag.Creator) == false)
            {
                dicPlcSendItem.Add(cSymbol.Tag.Creator, new List<string>());
                dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Creator);
                dicPlcSendItem[cSymbol.Tag.Creator].Add(cSymbol.Tag.Key);
            }

            foreach (CTag cTag in cSymbol.AllSubDepthTagList)
            {
                string sItem = CreateItem(cTag);
                dicPlcSendItem[cTag.Creator].Add(sItem);
            }

            foreach (var who in dicPlcSendItem)
            {
                SendEmergTagList(who.Value.ToArray());
            }
        }

        public void GetSubDepthStateValue(string sMasterKey, List<CTag> lstTag)
        {
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            foreach (CTag cTag in lstTag)
            {
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
            {
                SendEmergTagList(who.Value.ToArray());
            }
        }

        public CTimeLogS GetSubDepthStateValue(CTagS cTagS)
        {
            CTimeLogS cLogS = new CTimeLogS();
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();

            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
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
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
        }

        private void Service_UEventReceiveErrorTagList(object sender, string[] saData)
        {
            string sData = "";
            for (int i = 1; i < saData.Length; i++)
                sData += saData[i] + ", ";
            UpdateSystemMessage(saData[0], sData);
        }

        private void Service_UEventReceiveStatus(object sender, string[] saData)
        {
            //string sData = "";
            //for (int i = 1; i < saData.Length; i++)
            //    sData += saData[i] + ", ";
            //UpdateSystemMessage(saData[0], sData);
            if (UEventSPDStatus != null)
                UEventSPDStatus(saData);
        }

        private void Service_UEventReceiveTimeLogS(object sender, string[] saData)
        {
            if (saData != null)
            {
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLog cLog = null;

                for (int i = 0; i < saData.Length; i++)
                {
                    cLog = CreateTimeLog(saData[i]);

                    if (cLog != null)
                        cLogS.Add(cLog);
                }

                if (UEventTimeLogS != null)
                    UEventTimeLogS(EMTrackerLogType.ContinueLog, cLogS);

                cLogS.Clear();
                cLogS = null;
            }
        }

        private void Service_UEventReceiveEmergTimeLogS(object sender, string[] saData)
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

        private void Service_UEventClientDisconnected(object sender, string sClient)
        {
            //LED상태 표시 (OFF)
            m_bClientConnected = false;
            UpdateSystemMessage("SPD Manager", "연결이 해제되었습니다.");
            if (UEventClientConnect != null)
                UEventClientConnect(false);
        }

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            //LED 상태 표시 (ON)
            m_bClientConnected = true;
            UpdateSystemMessage("SPD Manager", "연결 되었습니다.");
            if (UEventClientConnect != null)
                UEventClientConnect(true);
        }

        #endregion
    }
}
