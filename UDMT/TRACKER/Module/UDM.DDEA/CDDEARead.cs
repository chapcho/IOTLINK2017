using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using UDM.Log;
using UDM.General.Threading;

namespace UDM.DDEA
{
    public class CDDEARead : CThreadBase
    {
        #region Member Variables

        protected EMPlcConnettionType _emPlcType = EMPlcConnettionType.Melsec_Normal;
        protected CDDEAConfigMS m_cConfigMS = null;
        protected CDDEAProject m_cProject;
        protected CDDEAGroup m_cGroup = null;
        protected CReadFunction m_cReadFunction = null;
        protected EMConnectAppType m_emConnectApp = EMConnectAppType.None;
        protected EMCollectMode m_emCollectMode = EMCollectMode.Normal;

        protected List<CDDEAPacketData> m_cPacketDataS = new List<CDDEAPacketData>();
        //protected List<CDDEAPacketData> m_cFilterPacketDataS = new List<CDDEAPacketData>();

        protected int m_iBlockCount = 0;
        protected int m_iCycleCount = 0;

        protected bool m_bPause = false;
        protected long m_nCollectSpeed = 0;
        public event UEventHandlerMainMessage UEventMessage;
        public event UEventHandlerDDEReadDataChanged UEventTrackerData;
        
        #endregion


        #region Initialize / Dispose

        public CDDEARead(CDDEAProject cProject, EMPlcConnettionType emType)
        {
            m_cProject = cProject;
            m_cConfigMS = cProject.Config;
            m_cReadFunction = new CReadFunction(m_cProject.Config, emType);
            m_emConnectApp = cProject.ConnectApp;
            m_emCollectMode = cProject.CollectMode;
            _emPlcType = emType;
        }

        #endregion


        #region Properties

        public bool Pause
        {
            set 
            { 
                m_bPause = value;
                
                if (m_bPause)
                    SetEventMessage("", "일시 정지 상태로 진입합니다.");
                else
                    SetEventMessage("", "정상 상태로 진입합니다.");
                
                if (m_cGroup != null)
                    m_cGroup.Pause = value;
            }
        }

        public List<string> LogFilePathList
        {
            get { return m_cProject.LogFilePahtList; }
        }

        #endregion


        #region Public Method

        public Dictionary<string, string> ShowDetailView()
        {
            Dictionary<string, string> dicReturn = new Dictionary<string, string>();

            //가동중인 정보를 볼수 있다.

            dicReturn.Add("현재 수집 중인 Packet Address List", m_cPacketDataS[m_iBlockCount].PacketAddress);
            dicReturn.Add("현재 수집 중인 Packet Address Count", m_cPacketDataS[m_iBlockCount].PacketCount.ToString());
            dicReturn.Add("수집 가동 상태", m_bRun.ToString());
            dicReturn.Add("수집 속도(ms)", m_nCollectSpeed.ToString());
            dicReturn.Add("수집 일시정지 상태", m_bPause.ToString());

            Dictionary<string, string> dicGroup = m_cGroup.ShowDetailView();

            foreach (var who in dicGroup)
            {
                if (dicReturn.ContainsKey(who.Key) == false)
                    dicReturn.Add(who.Key, who.Value);
            }

            return dicReturn;
        }

        #endregion


        #region Private Method


        /// <summary>
        /// PLC로 부터 실제 수집 함수, 수집된 내용은 Group으로 보내 분석함.
        /// </summary>
        /// <param name="cPacket"></param>
        protected void CollectData(CDDEAPacketData cPacket, int iPacket, int iCycle)
        {
            Stopwatch swSpeedTest = new Stopwatch();
            swSpeedTest.Start();

            DateTime dtAdd = DateTime.Now;

            string sReadAddress = cPacket.PacketAddress;
            int iReadAddCount = cPacket.PacketCount;

            int[] iaReadData = m_cReadFunction.ReadRandomData(sReadAddress, iReadAddCount);

            swSpeedTest.Stop();
            m_nCollectSpeed = swSpeedTest.ElapsedMilliseconds;
            //string sSpeed = string.Format("CollectSpeed,{0}", m_nCollectSpeed);
            //SetEventMessage("", sSpeed);

            if (iaReadData != null && m_bRun)
            {
                CDDEAPacketData cData = new CDDEAPacketData();
                cData = cPacket;
                cData.GroupNumber = iPacket;
                cData.CycleNumber = iCycle;
                cData.PacketValues = iaReadData;
                DateTime dtRead = dtAdd.AddMilliseconds(m_nCollectSpeed);
                cData.Time = new DateTime(dtRead.Year, dtRead.Month, dtRead.Day, dtRead.Hour, dtRead.Minute, dtRead.Second, dtRead.Millisecond);
                cData.FilterRead = false;

                //분석 Thread로 Queue 전달
                if (m_cGroup != null)
                    m_cGroup.ReadedDataEvent((CDDEAPacketData)cData.Clone());
            }
            else
            {
                //같은 PLC에 다중연결 되어 있을 경우 다른 연결에서 해제를 하면 발생하는 에러로 중지가되지는 않으므로 넘긴다.
                if (m_cReadFunction.ReadErrorCode != 0x1801001)
                {
                    string sMsg = string.Format("ErrorCode : {0}", m_cReadFunction.ReadErrorCode);
                    SetEventMessage("", sMsg);
                    SetEventMessage("", "ALL STOP");
                }
            }

        }

        private void SetEventMessage(string sSender, string sMessage)
        {
            if (UEventMessage != null)
            {
                if (sSender == "")
                    UEventMessage(this, "Reader", sMessage);
                else
                    UEventMessage(this, sSender, sMessage);
            }

        }

        /// <summary>
        /// 수집 시작 전 모든 Packet이 수집이 가능한 상태인지 확인
        /// </summary>
        private bool VerifyBlock()
        {
            SetEventMessage("", "수집 전 Packet별 수집 테스트를 진행합니다.(1회)");
            //Block 수집 테스트
            bool bErr = false;
            for (int i = 0; i < m_cPacketDataS.Count; i++)
            {
                string sMessage = "";
                int[] iaTestData = m_cReadFunction.ReadRandomData(m_cPacketDataS[i].PacketAddress, m_cPacketDataS[i].PacketCount);
                if (iaTestData == null)
                {
                    bErr = true;
                    sMessage = string.Format("Packet {0} Fail", i);
                    SetEventMessage("", sMessage);
                    //SetEventMessage("", m_cPacketDataS[i].PacketAddress);
                    string[] sSplit = m_cPacketDataS[i].PacketAddress.Split('\n');
                    string sMsg = "";
                    List<string> lstErrorAddress = m_cReadFunction.FindErrorSymbol(sSplit);
                    foreach (string ss in lstErrorAddress)
                    {
                        if (ss == "")
                            continue;
                        string sss = ss.Substring(0, 1);
                        if (sss == "K")
                            sMsg += ss.Substring(2, ss.Length - 2) + " / ";
                        else
                            sMsg += ss + " / ";
                    }

                    sMsg = string.Format("수집이 불가능한 심볼입니다. → {0}", sMsg);
                    SetEventMessage("", sMsg);
                }
                Thread.Sleep(1);
                Application.DoEvents();
            }
            if (bErr)
            {
                SetEventMessage("", "수집이 불가능한 Packet 발견 심볼을 확인하세요! 수집을 멈춥니다.");
                SetEventMessage("", "ALL STOP");
                return false;
            }
            else
                SetEventMessage("", "전체 Packet이 수집 가능합니다.");
            return true;
        }

        #endregion

        #region Thread Method

        
        protected override bool BeforeRun()
        {
            if (m_emConnectApp == EMConnectAppType.None) return false;

            m_bRun = m_cReadFunction.Connect();
            if (m_bRun == false)
            {
                SetEventMessage("", "통신 접속 실패 시작할 수 없습니다.");
                SetEventMessage("", "StartError,");
                return false;
            }
            if (m_cGroup == null)
                m_cGroup = new CDDEAGroup(m_cProject);

            m_cGroup.UEventGroupMessage += new UEventHandlerMainMessage(m_cGroup_UEventGroupMessage);
            m_cGroup.UEventGroupTrackerData += new UEventHandlerDDEGroupDataChanged(m_cGroup_UEventGroupTrackerData);

            //분석 및 수집 Block 생성
            m_bRun = m_cGroup.Run();

            if (m_bRun)
            {
                m_cPacketDataS = m_cGroup.PacketData;
            }
            else
            {
                SetEventMessage("", "수집 분석 프로세스를 시작하지 못했습니다.");
                SetEventMessage("", "StartError,");

                return false;
            }

            bool bOK = VerifyBlock();
            if (bOK == false)
            {
                SetEventMessage("", "StartError,");
                return false;
            }

            return m_bRun;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            if (m_bRun == false)
                return false;
            m_bRun = false;
            SetEventMessage("", "정지하기 위해 남은 정보를 처리 중입니다.");
            SetEventMessage("", "남은 Queue " + m_cGroup.QueueCount);

            if (m_cGroup != null)
            {
                m_cGroup.Stop();
                m_cGroup.UEventGroupMessage -= new UEventHandlerMainMessage(m_cGroup_UEventGroupMessage);
            }
            SetEventMessage("", "정지 완료");
            SetEventMessage("", "Stop_State");
            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            SetEventMessage("", "수집을 시작합니다.");
            Stopwatch swSpeedTest = new Stopwatch();

            while (m_bRun)
            {
                try
                {
                    Thread.Sleep(30);

                    if (m_bPause) continue;
                    
                    CollectData(m_cPacketDataS[m_iBlockCount], m_iBlockCount, m_iCycleCount);

                    if (m_emCollectMode == EMCollectMode.Normal)
                    {
                        if (m_iBlockCount < m_cPacketDataS.Count - 1)
                            m_iBlockCount++;
                        else
                            m_iBlockCount = 0;
                    }
                }
                catch (Exception ex)
                {
                    SetEventMessage("", "수집중 문제 발생 : " + ex.Message);
                    SetEventMessage("", "StartError,");
                }
            }
            SetEventMessage("", "연속 동작이 종료되었습니다");
        }

        #endregion

        #region Event Method

        private void m_cGroup_UEventGroupTrackerData(object sender, CTimeLogS cEventTimeLogS)
        {
            if (UEventTrackerData != null)
                UEventTrackerData(this, cEventTimeLogS);
        }

        private void m_cGroup_UEventGroupMessage(object sender, string sSender, string sMessage)
        {
            if (UEventMessage != null)
            {
                SetEventMessage(sSender, sMessage);
            }
        }

        #endregion
    }
}
