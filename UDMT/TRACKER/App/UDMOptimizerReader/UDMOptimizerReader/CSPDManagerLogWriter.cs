using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.Common;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMOptimizerReader
{
    public class CSPDManagerLogWriter : CThreadWithQueBase<object>
    {
        #region Member Variables

        protected CMySqlLogWriter m_cWriter = new CMySqlLogWriter();
        protected Dictionary<string, CWordDevice> m_dicWordDevice = new Dictionary<string, CWordDevice>();
        protected Dictionary<string, CTag> m_dicUserAddTag = new Dictionary<string, CTag>();
        public event UEventHandlerTrackerMessage UEventMessage = null;
        public event UEventHandlerLogWriteTimeLog UEventLogWriteTimeLogS = null;
        #endregion

        #region Properties

        public CMySqlLogWriter LogWriter
        {
            get { return m_cWriter; }
        }

        public bool IsConnected
        {
            get
            {
                if (m_cWriter == null)
                    return false;
                return m_cWriter.IsConnected;
            }
        }

        public Dictionary<string, CWordDevice> WordDeviceList
        {
            set { m_dicWordDevice = value; }
        }

        public Dictionary<string, CTag> UserAddTagList
        {
            set { m_dicUserAddTag = value; }
        }

        #endregion

        #region Privete Method

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
        #endregion

        protected override bool BeforeRun()
        {
            m_bRun = m_cWriter.Connect();
            if (m_bRun == false)
            {
                UpdateSystemMessage("LogWriter", "DB연결에 실패했습니다.");
                return false;
            }
            UpdateSystemMessage("LogWriter", "DB연결에 성공했습니다.");

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

            m_cWriter.Disconnect();

            return m_bRun;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            int iGCCount = 0;
            Stopwatch swMain = new Stopwatch();
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    object oData = m_cQue.DeQue();

                    if (oData == null) continue;

                    if (!m_cWriter.IsConnected)
                        m_cWriter.Connect();

                    if(oData.GetType() == typeof(CTimeLogS))
                    {
                        CTimeLogS cLogS = (CTimeLogS)oData;
                        m_cWriter.WriteTimeLogS(cLogS);
                        cLogS.Dispose();
                        cLogS = null;
                    }
                    else if (oData.GetType() == typeof(string[]))
                    {
                        string[] saData = (string[])oData;
                        CTimeLogS cLogS = CreateTimeLogS(saData);
                        CTimeLogS cPasingLogS = new CTimeLogS();
                        if (cLogS != null)
                        {
                            m_cWriter.WriteOrgTimeLogS(cLogS);

                            for (int i = 0; i < cLogS.Count; i++)
                            {
                                CTimeLog cLog = cLogS[i];
                                if (m_dicWordDevice.ContainsKey(cLog.Key))
                                {
                                    CWordDevice cWordDevice = m_dicWordDevice[cLog.Key];
                                    cPasingLogS.AddRange(cWordDevice.GetTimeLogSChangedTag(cLog));
                                }
                                if (m_dicUserAddTag.ContainsKey(cLog.Key))
                                    cPasingLogS.Add(cLog);
                            }
                            if (cPasingLogS != null && cPasingLogS.Count > 0)
                            {
                                m_cWriter.WriteTimeLogS(cPasingLogS);
                                if (UEventLogWriteTimeLogS != null)
                                    UEventLogWriteTimeLogS((CTimeLogS)cPasingLogS.Clone());
                            }
                        }
                    }
                    iGCCount++;

                    if (iGCCount % 100000 == 0)
                    {
                        Thread.Sleep(1);
                        UpdateSystemMessage("Log Writer", string.Format("GC Collect 수행 Start {0:N0}", GC.GetTotalMemory(false)));
                        GC.Collect();
                        UpdateSystemMessage("Log Writer", string.Format("GC Collect 수행 End {0:N0}", GC.GetTotalMemory(true)));
                    }

                    oData = null;
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("LogWriter", string.Format("Error Main Roof = {0}", ex.Message));
                    ex.Data.Clear();
                }
            }
        }

    }
}
