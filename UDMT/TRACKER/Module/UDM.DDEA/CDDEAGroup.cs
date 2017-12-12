using System;
using System.Collections.Generic;

using UDM.Common;
using UDM.General.Threading;
using UDM.Log;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text;

namespace UDM.DDEA
{
    public class CDDEAGroup : CThreadWithQueBase<CDDEAPacketData>
    {
        #region Member Variables

        protected CDDEAProject m_cProject;
        protected CDDEAConfigMS m_cConfig = null;
        protected CDDEATask m_cTask = null;

        protected List<CDDEAPacketData> m_cPacketDataS = new List<CDDEAPacketData>();
        protected List<CDDEAPacketData> m_cFilterPacketDataS = new List<CDDEAPacketData>();

        protected EMCollectMode m_emCollectMode = EMCollectMode.Normal;

        protected Object m_oLock = new Object();

        protected bool m_bPause = false;
        protected long m_nCollectSpeed = 0;

        public event UEventHandlerMainMessage UEventGroupMessage;
        public event UEventHandlerDDEGroupDataChanged UEventGroupTrackerData;

        #endregion


        #region Intialize/Dispose

        public CDDEAGroup(CDDEAProject cProject)
        {
            m_cProject = cProject;
            m_cConfig = cProject.Config;

            if (cProject != null)
            {
                m_emCollectMode = cProject.CollectMode;
            }
        }

        #endregion


        #region Public Properties

        public List<CDDEAPacketData> PacketData
        {
            get { return m_cPacketDataS; }
        }

        public int QueueCount
        {
            get { return m_cQue.Count; }
        }

        public bool Pause
        {
            set 
            {
                m_bPause = value;
                if (m_bPause)
                    SetEventMessage("", "일시 정지 상태로 진입합니다.");
                else
                    SetEventMessage("", "정상 상태로 진입합니다.");
            }
        }

        #endregion


        #region Private Method
        
        /// <summary>
        /// NormalMode에서 사용
        /// </summary>
        /// <param name="cBitSymbolS"></param>
        /// <param name="cCycleSymbolS"></param>
        /// <returns></returns>
        private void GetReadAddressBitSymbolS(CDDEASymbolList cBitSymbolList, int iPacketNo)
        {
            if (m_cPacketDataS.Count < iPacketNo) return;

            CDDEAPacketData cPacket = m_cPacketDataS[iPacketNo];
            string sPacketAllAddress = "";
            List<string> lstHeadAddress = new List<string>();

            foreach (CDDEASymbol sym in cBitSymbolList)
            {
                string sHeadAddress = sym.BaseAddress;

                if (sym.AddressMinor == -1)
                {
                    if (!lstHeadAddress.Contains("K8" + sHeadAddress))
                    {
                        lstHeadAddress.Add("K8" + sHeadAddress);
                        sPacketAllAddress += "K8" + sHeadAddress + "\n";

                        CDDEAReadAddressData cData = new CDDEAReadAddressData();
                        cData.Address = sHeadAddress;
                        cData.AddressLength = sym.AddressCount;
                        cPacket.ReadDataList.Add(sHeadAddress, cData);
                    }
                }
                else
                {
                    if (!lstHeadAddress.Contains(sHeadAddress))
                    {
                        lstHeadAddress.Add(sHeadAddress);
                        sPacketAllAddress += sHeadAddress + "\n";

                        CDDEAReadAddressData cData = new CDDEAReadAddressData();
                        cData.Address = sHeadAddress;
                        cData.AddressLength = sym.AddressCount;
                        cPacket.ReadDataList.Add(sHeadAddress, cData);
                    }
                }
            }
            cPacket.PacketAddress += sPacketAllAddress;
            cPacket.PacketCount += lstHeadAddress.Count;

            return;
        }

        /// <summary>
        /// NormalMode에서 사용
        /// Index 제외한 나머지
        /// </summary>
        /// <param name="cWordSymbolS"></param>
        /// <param name="cRecipeSymbolS"></param>
        /// <param name="cIndexSymbolS"></param>
        /// <returns></returns>
        private void GetReadAddressWordSymbolS(CDDEASymbolList cWordSymbolList, CDDEASymbolList cIndexSymbolList, int iPacketNo)
        {
            if (m_cPacketDataS.Count < iPacketNo) return;

            List<string> lstHeadAddress = new List<string>();
            List<string> lstIndexAddress = new List<string>();
            CDDEAPacketData cPacket = m_cPacketDataS[iPacketNo];
            string sPacketAllAddress = "";

            foreach (CDDEASymbol sym in cIndexSymbolList)
            {
                lstIndexAddress.Add(sym.BaseAddress);
            }

            foreach (CDDEASymbol sym in cWordSymbolList)
            {
                string sHeadAddress = sym.Address;

                if (lstIndexAddress.Contains(sHeadAddress))
                    continue;

                if (cPacket.ReadDataList.ContainsKey(sHeadAddress))
                    continue;

                lstHeadAddress.Add(sHeadAddress);
                sPacketAllAddress += sHeadAddress + "\n";

                CDDEAReadAddressData cData = new CDDEAReadAddressData();
                cData.Address = sHeadAddress;
                cData.AddressLength = sym.AddressCount;
                cPacket.ReadDataList.Add(sHeadAddress, cData);
            }

            cPacket.PacketAddress += sPacketAllAddress;
            cPacket.PacketCount += lstHeadAddress.Count;

            m_cPacketDataS[iPacketNo] = cPacket;
        }

        private void GetReadAddressSymbolS(CDDEASymbolList cSymbolList, bool bBit, int iPacketNo)
        {
            if (m_cPacketDataS.Count < iPacketNo) return;

            List<string> lstHeadAddress = new List<string>();
            CDDEAPacketData cPacket =  m_cPacketDataS[iPacketNo];
            string sPacketAllAddress = "";

            foreach (CDDEASymbol sym in cSymbolList)
            {
                string sHeadAddress = "";
                if (bBit)
                    sHeadAddress = "K8" + sym.BaseAddress;
                else
                    sHeadAddress = sym.BaseAddress;

                if (cPacket.ReadDataList.ContainsKey(sHeadAddress))
                    continue;

                lstHeadAddress.Add(sHeadAddress);
                sPacketAllAddress += sHeadAddress + "\n";

                CDDEAReadAddressData cData = new CDDEAReadAddressData();
                cData.Address = sHeadAddress;
                cData.AddressLength = sym.AddressCount;
                cPacket.ReadDataList.Add(sHeadAddress, cData);

            }
            cPacket.PacketAddress += sPacketAllAddress;
            cPacket.PacketCount += lstHeadAddress.Count;

            return;
        }

        /// <summary>
        /// Normal Mode
        /// </summary>
        /// <param name="cNormalMode"></param>
        /// <param name="iBlockNum"></param>
        private void ExtractAddressFromBundle(CNormalMode cNormalMode, int iBlockNum)
        {
            CDDEAPacketData cPacket = new CDDEAPacketData();
            m_cPacketDataS.Add(cPacket);

            GetReadAddressBitSymbolS(cNormalMode.BitSymbolList, iBlockNum);
            GetReadAddressWordSymbolS(cNormalMode.WordSymbolList, cNormalMode.IndexSymbolList, iBlockNum);
            GetReadAddressSymbolS(cNormalMode.IncludeIndexSymbolList, false, iBlockNum);
            GetReadAddressSymbolS(cNormalMode.IndexSymbolList, false, iBlockNum);

        }

        private bool BrforeRunCollectMode()
        {
            //파라메터에서 Header에 해당하는 Size를 읽어 비교할때사용
            try
            {
                int iWordSize = 0;
                if (m_emCollectMode == EMCollectMode.Normal)
                {
                    for (int i = 0; i < m_cProject.NormalBundleList.Count; i++)
                    {
                        ExtractAddressFromBundle(m_cProject.NormalBundleList[i], i);
                        iWordSize += m_cPacketDataS[i].PacketCount;
                        //string sAddressList = "";
                        //for (int k = 0; k < m_cProject.NormalBundleList[i].BitSymbolList.Count; k++)
                        //{
                        //    sAddressList += m_cProject.NormalBundleList[i].BitSymbolList[k].Address + "\r\n";
                        //}
                        //sAddressList = "";
                        //for (int k = 0; k < m_cProject.NormalBundleList[i].WordSymbolList.Count; k++)
                        //{
                        //    sAddressList += m_cProject.NormalBundleList[i].WordSymbolList[k].Address + "\r\n";
                        //}
                        //sAddressList = "";
                    }

                    string sWordSize = string.Format("조합 후 Word수(필터제외) : {0}", iWordSize);
                    SetEventMessage("", sWordSize);

                    if (m_cFilterPacketDataS.Count > 0)
                    {
                        iWordSize = 0;
                        for (int i = 0; i < m_cFilterPacketDataS.Count; i++)
                            iWordSize += m_cFilterPacketDataS[i].PacketCount;
                        sWordSize = string.Format("필터된 접점 수 : {0}", iWordSize);
                        SetEventMessage("", sWordSize);
                    }
                }
            }
            catch (Exception ex)
            {
                SetEventMessage("", "초기 프로젝트 분석오류 : " + ex.Message);
            }
            return true;
        }

        #endregion


        #region Public Method

        public Dictionary<string, string> ShowDetailView()
        {
            Dictionary<string, string> dicReturn = new Dictionary<string, string>();

            //가동중인 정보를 볼수 있다.

            dicReturn.Add("현재 분석 중 남은 Queue", m_cQue.Count.ToString());
            dicReturn.Add("분석 가동 상태", m_bRun.ToString());
            dicReturn.Add("분석 속도(ms)", m_nCollectSpeed.ToString());
            dicReturn.Add("분석 일시정지 상태", m_bPause.ToString());

            return dicReturn;
        }

        #endregion


        #region Protected Method

        #region 일반함수

        protected void SetEventMessage(string sSender, string sMessage)
        {
            if (UEventGroupMessage != null)
            {
                if (sSender == "")
                    UEventGroupMessage(this, "수집분석", sMessage);
                else
                    UEventGroupMessage(this, sSender, sMessage);
            }
        }

        protected void SendTrackerData(CTimeLogS cLogS)
        {
            if (m_cProject.ConnectApp == EMConnectAppType.Tracker)
            {
                if (UEventGroupTrackerData != null)
                {
                    UEventGroupTrackerData(this, cLogS);
                }
            }
            else if (m_cProject.ConnectApp == EMConnectAppType.Profiler)
            {
                m_cTask.EventDataChanged(cLogS);
            }
        }

        #endregion

        #region TimeLog생성

        protected CTimeLog GetNormalTimeLog(string sKey, DateTime dtTime, int iValue)
        {
            CTimeLog cLog = new CTimeLog();

            cLog.Key = sKey;
            cLog.Value = iValue;
            cLog.Time = dtTime;

            return cLog;
        }

        protected CTimeLog GetNormalWordTimeLog(CDDEASymbol cSymbol, DateTime dtTime, short iValue)
        {
            int iResultVal = -1;
            iResultVal = (int)cSymbol.Mask & iValue;
            CTimeLog cLog = new CTimeLog();

            cLog.Key = cSymbol.Key;
            cLog.Value = (short)iResultVal;
            cLog.Time = dtTime;

            return cLog;
        }

        protected CTimeLog SetIndexLog(CDDEASymbol cSourceSymbol, CDDEASymbol cIndexSymbol, int iSourceValue, int iIndexValue, CDDEAPacketData cData)
        {
            CTimeLog cLog = new CTimeLog();

            cLog.Key = cSourceSymbol.Key;
            cLog.Value = iSourceValue;
            cLog.Time = cData.Time;
            string sNote = string.Format("{0}={1}", cIndexSymbol.Address, iIndexValue);
            cLog.Note = sNote;
            cSourceSymbol.IndexNote = sNote;
            cSourceSymbol.CurrentValue = iSourceValue;
            cSourceSymbol.ChangeCount++;
            return cLog;
        }

        #endregion

        #region TimeLog 전송

        protected void WriteNormalBitFirstLogS(List<CDDEASymbol> lstBitSymbol, int iValue, CDDEAPacketData cData, CTimeLogS cAddTimeLogS)
        {
            foreach (CDDEASymbol sym in lstBitSymbol)
            {
                CTimeLog cLog = new CTimeLog();
                int iMaskValue = iValue & (int)sym.Mask;
                if (iMaskValue != 0)
                {
                    cLog = GetNormalTimeLog(sym.Key, cData.Time, 1);
                    sym.CurrentValue = 1;
                }
                else
                {
                    cLog = GetNormalTimeLog(sym.Key, cData.Time, 0);
                    sym.CurrentValue = 0;
                }
                sym.ChangeCount++;
                cAddTimeLogS.Add(cLog);
            }
        }

        protected void WriteNormalWordFirstLogS(List<CDDEASymbol> lstWordSymbol, int iValue, CDDEAPacketData cData, CTimeLogS cAddTimeLogS)
        {
            foreach (CDDEASymbol sym in lstWordSymbol)
            {
                CTimeLog cLog = new CTimeLog();

                if (sym.AddressCount > 1)
                {
                    //Dword 처리
                    cData.GetDwordValue(sym.Address, sym.DWordSecondAddress);
                    cLog = GetNormalTimeLog(sym.Key, cData.Time, cData.ReadDataList[sym.Address].DWordValue);
                    cAddTimeLogS.Add(cLog);
                    sym.CurrentValue = cData.ReadDataList[sym.Address].DWordValue;
                }
                else
                {
                    cLog = GetNormalWordTimeLog(sym, cData.Time, (short)iValue);
                    cAddTimeLogS.Add(cLog);
                    sym.CurrentValue = iValue;
                }
                sym.ChangeCount++;
            }
        }

        protected void WriteNormalBitLogS(List<CDDEASymbol> lstBitSymbol, int iValue, int iLastValue, CDDEAPacketData cData, CTimeLogS cAddTimeLogS)
        {

            foreach (CDDEASymbol sym in lstBitSymbol)
            {
                CTimeLog cLog = new CTimeLog();

                int iMaskValue = iValue & (int)sym.Mask;
                int iLastMaskValue = iLastValue & (int)sym.Mask;

                if (iMaskValue == iLastMaskValue)
                    continue;

                if (iMaskValue != 0)
                {
                    cLog = GetNormalTimeLog(sym.Key, cData.Time, 1);
                    sym.CurrentValue = 1;
                }
                else
                {
                    cLog = GetNormalTimeLog(sym.Key, cData.Time, 0);
                    sym.CurrentValue = 0;
                }
                sym.ChangeCount++;
                cAddTimeLogS.Add(cLog);
            }
        }

        protected void WriteNormalWordLogS(List<CDDEASymbol> lstWordSymbol, short iValue, CDDEAPacketData cData, CDDEAPacketData cLastData, CTimeLogS cAddTimeLogS)
        {
            foreach (CDDEASymbol sym in lstWordSymbol)
            {
                CTimeLog cLog = new CTimeLog();

                if (sym.AddressCount > 1)
                {
                    //Dword 처리
                    cData.GetDwordValue(sym.Address, sym.DWordSecondAddress);
                    int iLastDword = cLastData.ReadDataList[sym.Address].DWordValue;
                    int iNowDword = cData.ReadDataList[sym.Address].DWordValue;

                    if (iNowDword == iLastDword)
                        continue;

                    cLog = GetNormalTimeLog(sym.Key, cData.Time, cData.ReadDataList[sym.Address].DWordValue);
                    cAddTimeLogS.Add(cLog);
                    sym.CurrentValue = cData.ReadDataList[sym.Address].DWordValue;
                }
                else
                {
                    if (sym.AddressCount == 0)
                        continue;
                    short iLastValue = (short)cLastData.ReadDataList[sym.Address].Value;
                    if (iValue == iLastValue)
                        continue;

                    cLog = GetNormalWordTimeLog(sym, cData.Time, iValue);
                    cAddTimeLogS.Add(cLog);
                    sym.CurrentValue = iValue;
                }
                sym.ChangeCount++;
            }
        }

        protected void WriteIndexLogS(List<CDDEASymbol> lstIncludeIndexSymbol, List<CDDEASymbol> lstIndexSymbol, int iValue, CDDEAPacketData cData, CTimeLogS cAddTimeLogS)
        {
            foreach (CDDEASymbol sym in lstIncludeIndexSymbol)
            {
                CTimeLog cLog = new CTimeLog();
                CDDEASymbol cFindSymbol = lstIndexSymbol.Find(b => b.AddressMajor == sym.IndexAddressNumber);
                if (cFindSymbol == null)
                    SetEventMessage("", sym.Address + "인덱스 심볼을 찾을 수 없음 " + sym.IndexAddressNumber);
                else
                {
                    cLog = SetIndexLog(sym, cFindSymbol, iValue, cData.ReadDataList[cFindSymbol.Address].Value, cData);
                    cAddTimeLogS.Add(cLog);
                }
            }
        }

        #endregion

        #region 모드별 분석

        /// <summary>
        /// Log는 Plus만 남김.
        /// </summary>
        /// <param name="cData"></param>
        /// <param name="cNormalMode"></param>
        protected void SetNormalFirstData(CDDEAPacketData cData, CNormalMode cNormalMode)
        {
            CTimeLogS cEventTimeLogS = new CTimeLogS();

            foreach (var who in cData.ReadDataList)
            {
                string sBaseAddress = who.Value.Address;
                List<CDDEASymbol> lstBitEqulSymbol = cNormalMode.BitSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                List<CDDEASymbol> lstWordEqulSymbol = cNormalMode.WordSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                List<CDDEASymbol> lstIndexIncludeEqulSymbol = cNormalMode.IncludeIndexSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                //List<CDDEASymbol> lstIndexEqulSymbol = cNormalMode.IndexSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);

                WriteNormalBitFirstLogS(lstBitEqulSymbol, who.Value.Value, cData, cEventTimeLogS);
                WriteNormalWordFirstLogS(lstWordEqulSymbol, who.Value.Value, cData, cEventTimeLogS);
                WriteIndexLogS(lstIndexIncludeEqulSymbol, cNormalMode.IndexSymbolList, who.Value.Value, cData, cEventTimeLogS);
            }
            if (cEventTimeLogS.Count > 0)
            {
                SendTrackerData(cEventTimeLogS);
            }
        }

        protected void SetNormalData(CDDEAPacketData cData, CDDEAPacketData cLastData, CNormalMode cNormal)
        {
            CTimeLogS cEventTimeLogS = new CTimeLogS();

            foreach (var who in cData.ReadDataList)
            {
                string sBaseAddress = who.Value.Address;
                int iNowValue = who.Value.Value;
                int iLastValue = cLastData.ReadDataList[sBaseAddress].Value;

                List<CDDEASymbol> lstWordEqulSymbol = cNormal.WordSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                WriteNormalWordLogS(lstWordEqulSymbol, (short)iNowValue, cData, cLastData, cEventTimeLogS);

                if (iNowValue == iLastValue)
                    continue;

                List<CDDEASymbol> lstBitEqulSymbol = cNormal.BitSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                List<CDDEASymbol> lstIndexIncludeEqulSymbol = cNormal.IncludeIndexSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);
                //List<CDDEASymbol> lstIndexEqulSymbol = cNormal.IndexSymbolList.FindEqulBaseAddressSymbol(sBaseAddress);

                WriteNormalBitLogS(lstBitEqulSymbol, iNowValue, iLastValue, cData, cEventTimeLogS);
                WriteIndexLogS(lstIndexIncludeEqulSymbol, cNormal.IndexSymbolList, who.Value.Value, cData, cEventTimeLogS);
            }
            if (cEventTimeLogS.Count > 0)
            {
                SendTrackerData(cEventTimeLogS);
            }

        }

        
        #endregion

        #endregion

        #region Thread Methods

        /// <summary>
        /// 수집전 Symbol List 정리
        /// </summary>
        /// <returns></returns>
        protected override bool BeforeRun()
        {
            if (m_cProject == null) return false;

            ClearQue();

            //초기화
            m_cPacketDataS.Clear();
            m_cFilterPacketDataS.Clear();

            m_bRun = BrforeRunCollectMode();
            if (m_bRun == false)
            {
                SetEventMessage("", "초기 프로젝트 분석에 문제가 있습니다.");
                SetEventMessage("", "StartError,");
                return false;
            }
            if (m_cProject.ConnectApp == EMConnectAppType.Profiler)
            {
                m_cTask = new CDDEATask(m_cProject);
                m_cTask.UEventMessage += new UEventHandlerMainMessage(m_cTask_UEventMessage);
                m_bRun = m_cTask.Run();
                if (m_bRun == false)
                {
                    SetEventMessage("", "LogWrite 시작 실패");
                    SetEventMessage("", "StartError,");
                }
            }
            return m_bRun;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            if (m_cQue.Count > 0) ClearQue();
            
            if (m_cTask != null)
            {
                m_cTask.Stop();
                m_cTask.UEventMessage -= new UEventHandlerMainMessage(m_cTask_UEventMessage);
                m_cTask = null;
            }

            m_bRun = false;
            return true;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            int iReadCount = m_cPacketDataS.Count;
            CDDEAReadAddressData[] cLastData = new CDDEAReadAddressData[iReadCount];
            Dictionary<int, CDDEAPacketData> dicDDEAData = new Dictionary<int, CDDEAPacketData>();

            try
            {
                while (m_bRun)
                {
                    Stopwatch swSpeedTest = new Stopwatch();
                    swSpeedTest.Start();
                    
                    Thread.Sleep(1);

                    if (m_bPause) continue;

                    if (m_cQue.Count <= 0)
                        continue;

                    CDDEAPacketData cData = m_cQue.DeQue();
                    
                    if (cData == null)
                        continue;

                    cData.SetValueParsing();

                    if (m_emCollectMode == EMCollectMode.Normal)
                    {
                        if (!dicDDEAData.ContainsKey(cData.GroupNumber))
                        {
                            dicDDEAData.Add(cData.GroupNumber, cData);
                            SetNormalFirstData(cData, m_cProject.NormalBundleList[cData.GroupNumber]);
                        }
                        else
                        {
                            if (dicDDEAData[cData.GroupNumber].Time == cData.Time)
                                cData.Time = cData.Time.AddMilliseconds(5);
                            SetNormalData(cData, dicDDEAData[cData.GroupNumber], m_cProject.NormalBundleList[cData.GroupNumber]);
                            dicDDEAData[cData.GroupNumber] = cData;
                        }
                    }
                    swSpeedTest.Stop();
                    m_nCollectSpeed = swSpeedTest.ElapsedMilliseconds;
                    //string sSpeed = string.Format("Speed,{0}", lSpeed);
                    //SetEventMessage(sSpeed);
                }
                SetEventMessage("", "연속 동작이 종료되었습니다");
            }
            catch (Exception ex)
            {
                SetEventMessage("", "수집 분석 중 문제가 발생했습니다 : " + ex.Message);
                SetEventMessage("", "StartError,");
            }
        }

        #endregion

        protected bool CheckValue(int[] aiNow, int[] aiOld)
        {
            bool bFind = false;
            for (int i = 0; i < aiNow.Length; i++)
            {
                if (aiNow[i] != aiOld[i])
                    bFind = true;

            }
            if (bFind) return false;
            return true;
        }

        #region Event Methods


        void m_cTask_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (UEventGroupMessage != null)
                SetEventMessage(sSender, sMessage);
        }

        public void ReadedDataEvent(CDDEAPacketData cData)
        {
            //lock (m_oLock)
            {
                EnQue(cData);
            }
        }

        #endregion

    }
}
