using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.General.Threading;
using UDM.Log;

namespace UDMSPDManager
{
    public class CAnalyzeEmergData : CThreadBase
    {
        #region Member Variables

        private string[] m_saReceiveData = null;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.Siemens;
        private Dictionary<string, CDWordDevice> m_dicDWordDevice = new Dictionary<string, CDWordDevice>();
        private CTagS m_cTotalTagS = null;

        public event UEventHandlerSendLogStringArray UEventSendLogStringArray = null;
        public event UEventHandlerMessage UEventMessage = null;

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public string[] ReceiveData
        {
            set { m_saReceiveData = value; }
        }

        public EMPLCMaker PLCMaker
        {
            set { m_emPLCMaker = value; }
        }

        public Dictionary<string, CDWordDevice> DWordDevice
        {
            set { m_dicDWordDevice = value; }
        }
        public CTagS TotalTagS
        {
            set { m_cTotalTagS = value; }
        }

        #endregion

        #region Private Method

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

        private string[] CreateSendStringFromTimeLog(CTimeLogS cLogS, string sErrorKey)
        {
            string[] saSendData = new string[cLogS.Count + 1];

            saSendData[0] = sErrorKey;
            for (int i = 0; i < cLogS.Count; i++)
            {
                string sValue = "";
                CTimeLog cLog = cLogS[i];
                if (cLog.SValue.Trim() != "")
                    sValue = cLog.SValue;
                else
                    sValue = cLog.Value.ToString();

                string sSend = string.Format("{0},{1},{2}", cLog.Time.ToString("yyyyMMddHHmmss.fff"), cLog.Key, sValue);
                saSendData[i + 1] = sSend;
            }

            return saSendData;
        }

        #endregion


        #region Thread Override

        protected override bool BeforeRun()
        {
            return true;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            return true;
        }

        protected override bool AfterStop()
        {
            return true;
        }

        protected override void DoThreadWork()
        {
            //처리 구문
            if (m_saReceiveData != null)
            {
                if (m_emPLCMaker == EMPLCMaker.Siemens)
                {

                    CTimeLogS cLogS = CreateTimeLogS(m_saReceiveData);
                    CTimeLogS cPasingLogS = new CTimeLogS();
                    if (cLogS != null)
                    {
                        int iCount = 0;
                        for (int i = 0; i < cLogS.Count; i++)
                        {
                            CTimeLog cLog = cLogS[i];
                            if (m_dicDWordDevice.ContainsKey(cLog.Key))
                            {
                                CDWordDevice cDWordDevice = m_dicDWordDevice[cLog.Key];
                                cPasingLogS.AddRange(cDWordDevice.GetTimeLogSChangedTag(cLog, true));
                            }

                            //워드일 경우 아래 구문에서 추가 될것 임.
                            if (m_cTotalTagS.ContainsKey(cLog.Key))
                            {
                                cPasingLogS.Add(cLog);
                                iCount++;
                            }
                        }
                        if (cPasingLogS != null && cPasingLogS.Count > 0)
                        {
                            //배열로 재생성
                            string[] saSendData = CreateSendStringFromTimeLog(cPasingLogS, m_saReceiveData[0]);
                            if (UEventSendLogStringArray != null)
                                UEventSendLogStringArray((string[])saSendData.Clone());
                            if(UEventMessage != null)
                                UEventMessage("ReceiveEmergTimeLogS", string.Format("Create Log Success All = {0}, Word = {1}", cPasingLogS.Count, iCount));
                        }
                    }
                    else
                    {
                        if (UEventMessage != null)
                            UEventMessage("ReceiveEmergTimeLogS", string.Format("Log create Fail {0}", m_saReceiveData[0]));
                    }
                }
            }
            Stop();
        }

        #endregion

    }
}
