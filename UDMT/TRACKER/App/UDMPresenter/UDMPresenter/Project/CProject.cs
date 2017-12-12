using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.DDEA;
using UDM.Log;
using UDM.Log.Csv;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source;
using UDM.Monitor.Plc.Source.LS;
using UDM.Monitor.Plc.Source.OPC;

namespace UDMPresenter
{
    [Serializable]
	public class CProject : IDisposable
	{

		#region Member Varialbes

		protected string m_sName = "";
		protected string m_sPath = "";
        protected string m_sSaveLogPath = @"C:\PresenterLog";
        protected int m_iKey = -1;
        protected int m_iSaveLogTime = 1;
        protected int m_iMaxLogfileCount = 10;
        protected CTagS m_cTagS = new CTagS();
        protected CStepS m_cStepS = new CStepS();
		protected CSymbolS m_cSymbolS = new CSymbolS();
        protected CDDEAConfigMS m_cConfig = null;
        protected COPCConfig m_cOPCConfig = new COPCConfig();
        protected CLsConfig m_cLsConfig = new CLsConfig();
        protected EMSourceType m_emEMCollectorType = EMSourceType.OPC;
        protected EMPLCMaker m_emPlcMaker = EMPLCMaker.LS;
        protected CFilterOption m_cFilterOption = new CFilterOption();
        protected List<CStepTagList> m_lstStepTagList = new List<CStepTagList>();
        protected List<string> m_lstUserAddSymbol = new List<string>();
        protected List<string> m_lstLogFilePath = new List<string>();
        
        [NonSerialized]
        protected bool m_bRun = false;
        [NonSerialized]
        protected CDDEARead m_cReader = null;
        [NonSerialized]
        protected CLsReader m_cLsReader = null;
        [NonSerialized]
        protected CMonitor m_cMonitor = null;
        [NonSerialized]
        protected CDDEATask m_cLogTask = null;
        [NonSerialized]
        protected CTimeLogS m_cTimeLogS = null;
        [NonSerialized]
        protected CDDEASymbolS m_cDDEASymbolS = null;

        public event UEventHandlerMainMessage UEventMessage;

		#endregion


		#region Inialize/Dispose

		public CProject()
		{
            m_cConfig = new CDDEAConfigMS(EMPlcConnettionType.Melsec_Normal);
            m_cOPCConfig = new COPCConfig();
            m_cLsConfig = new CLsConfig();
		}

		public void Dispose()
		{
			Clear();
		}

		#endregion


		#region Public Properties

        public int Key
        {
            get { return m_iKey; }
            set { m_iKey = value; }
        }

		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}

		public string Path
		{
			get { return m_sPath; }
			set { m_sPath = value; }
		}

        public string SaveLogPath
        {
            get { return m_sSaveLogPath; }
            set { m_sSaveLogPath = value; }
        }

        public int SaveLogFileTime
        {
            get { return m_iSaveLogTime; }
            set { m_iSaveLogTime = value; }
        }

        public int MaxLogFileCount
        {
            get { return m_iMaxLogfileCount; }
            set { m_iMaxLogfileCount = value; }
        }

		public CTagS TagS
		{
			get { return m_cTagS; }
			set { m_cTagS = value; }
		}

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

		public CSymbolS SymbolS
		{
			get { return m_cSymbolS; }
			set { m_cSymbolS = value; }
		}

        public CDDEAConfigMS PLCConfig
        {
            get { return m_cConfig; }
            set { m_cConfig = value; }
        }

        public COPCConfig OpcConfig
        {
            get { return m_cOPCConfig; }
            set { m_cOPCConfig = value; }
        }

        public CLsConfig LsConfig
        {
            get { return m_cLsConfig; }
            set { m_cLsConfig = value; }
        }

        public List<string> LogFilePathList
        {
            get { return m_lstLogFilePath; }
            set { m_lstLogFilePath = value; }
        }

        public EMSourceType CollectorType
        {
            get { return m_emEMCollectorType; }
            set { m_emEMCollectorType = value; }
        }

        public EMPLCMaker PlcMaker
        {
            get { return m_emPlcMaker; }
            set { m_emPlcMaker = value; }
        }

        public CFilterOption FilterOption
        {
            get { return m_cFilterOption; }
            set { m_cFilterOption = value; }
        }

        public List<CStepTagList> StepTagList
        {
            get { return m_lstStepTagList; }
            set { m_lstStepTagList = value; }
        }

        public List<string> UserAddSymbol
        {
            get { return m_lstUserAddSymbol; }
            set { m_lstUserAddSymbol = value; }
        }

        public bool Run
        {
            get { return m_bRun; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        public CDDEASymbolS DDEASymbolS
        {
            get { return m_cDDEASymbolS; }
        }

		#endregion


		#region Public Methods

		public void Clear()
		{
			m_cTagS.Clear();
			m_cSymbolS.Clear();
		}

        public List<CStep> GetEndCoilStepList()
        {
            List<CStep> lstStep = new List<CStep>();

            CStep cStep;
            CCoil cCoil;
            CTag cTag;
            for (int i = 0; i < m_cStepS.Count; i++)
            {
                cStep = m_cStepS.ElementAt(i).Value;
                if (cStep.CoilS.Count == 1)
                {
                    cCoil = cStep.CoilS[0];
                    if (cCoil.ContentS.Count == 1)
                    {
                        cTag = cCoil.ContentS[0].Tag;
                        if (cTag == null) continue;
                        if (cTag.DataType == EMDataType.Bool)
                        {
                            bool bEndCoil = IsEndCoilTag(cTag);
                            if (bEndCoil)
                                lstStep.Add(cStep);
                        }
                    }
                }
            }

            return lstStep;
        }

        public List<CStep> GetSelectStepList(List<string> lstStepKey)
        {
            List<CStep> lstStep = new List<CStep>();

            for (int i = 0; i < lstStepKey.Count; i++)
            {
                if (m_cStepS.ContainsKey(lstStepKey[i]))
                    lstStep.Add(m_cStepS[lstStepKey[i]]);
            }

            return lstStep;
        }

        public List<CStep> GetCoilStepList(List<string> lstAddress)
        {
            List<CStep> lstStep = new List<CStep>();

            List<string> lstAddressClone = new List<string>();
            for (int i = 0; i < lstAddress.Count; i++)
                lstAddressClone.Add(lstAddress[i]);

            CStep cStep;
            CCoil cCoil;
            for (int i = 0; i < m_cStepS.Count; i++)
            {
                cStep = m_cStepS.ElementAt(i).Value;

                if (lstStep.Contains(cStep) == false)
                {
                    if (cStep.CoilS.Count == 1)
                    {
                        cCoil = cStep.CoilS[0];
                        for (int j = 0; j < cCoil.RefTagS.Count; j++)
                        {
                            if (lstAddressClone.Contains(cCoil.RefTagS[j].Address))
                            {
                                if (lstStep.Contains(cStep) == false)
                                    lstStep.Add(cStep);

                                lstAddressClone.Remove(cCoil.RefTagS[j].Address);
                            }
                        }
                    }
                }
            }

            return lstStep;
        }

        public List<CTag> GetModeTagList(List<string> lstAddress)
        {
            List<CTag> lstResult = new List<CTag>();

            for (int i = 0; i < lstAddress.Count; i++)
            {
                foreach (var who in m_cTagS)
                {
                    if (who.Value.Address == lstAddress[i])
                    {
                        if (who.Value.IsCollectUsed == false)
                        {
                            lstResult.Add(who.Value);
                            who.Value.IsCollectUsed = true;
                        }
                        break;
                    }
                }
            }

            return lstResult;
        }

        public int GetWordSize(List<CTag> lstTag)
        {
            CDDEASymbolList lstSymbol = ToSymbolList(lstTag);

            int iBitToWord = 0;
            int iWordCount = 0;
            int iDWordCount = 0;
            int iIndexCount = 0;

            List<string> lstHeader = new List<string>();
            CTagS cFilterTagS = new CTagS();
            List<CDDEASymbol> lstSub = new List<CDDEASymbol>();

            //인덱스 접점 포함
            iIndexCount = GetIndexSymbolCount(lstSymbol);

            foreach (CDDEASymbol sym in lstSymbol)
            {
                if (sym.DataType == EMDataType.Bool)
                {
                    if (!lstHeader.Contains("B_" + sym.AddressHeader))
                    {
                        lstHeader.Add("B_" + sym.AddressHeader);

                        lstSub = new List<CDDEASymbol>();
                        lstSub = lstSymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.Bool);
                        lstSub.Sort(new CSymbolComparer());
                        if (sym.AddressMinor != -1)
                            iBitToWord += GetWordCountFromWordDot(lstSub);
                        else
                            iBitToWord += GetWordCountFromBit(lstSub);
                    }
                }
                else if (sym.DataType == EMDataType.Word)
                {
                    if (!lstHeader.Contains("W_" + sym.AddressHeader))
                    {
                        lstHeader.Add("W_" + sym.AddressHeader);

                        lstSub = new List<CDDEASymbol>();
                        lstSub = lstSymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.Word);
                        lstSub.Sort(new CSymbolComparer());
                        iWordCount += lstSub.Count;
                    }
                }
                else if (sym.DataType == EMDataType.DWord)
                {
                    if (!lstHeader.Contains("DW_" + sym.AddressHeader))
                    {
                        lstHeader.Add("DW_" + sym.AddressHeader);

                        lstSub = new List<CDDEASymbol>();
                        lstSub = lstSymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.DWord);
                        lstSub.Sort(new CSymbolComparer());
                        iDWordCount += lstSub.Count;
                    }
                }
            }

            int iCnt = iBitToWord + iWordCount + iDWordCount + iIndexCount;

            return iCnt;

        }

        private void ClearSymbolCurrentValue()
        {
            foreach (var who in this.SymbolS)
            {
                who.Value.CurrentValue = "0";
                who.Value.ChangeCount = 0;
            }
        }

        public bool CollectStart()
        {
            if (m_bRun) return false;

            if (m_emEMCollectorType == EMSourceType.DDEA)
            {
                m_bRun = RunDDEACollect();
            }
            else if(m_emEMCollectorType == EMSourceType.LS)
            {
                m_bRun = RunLsDDEACollect();
            }
            else
            {
                m_bRun = RunOPCCollect();
            }

            ClearSymbolCurrentValue();

            return m_bRun;
        }

        public bool CollectStop()
        {
            if (m_bRun == false) return false;

            if (m_emEMCollectorType == EMSourceType.OPC)
            {
                m_cLogTask.Stop();

                m_cLogTask.UEventMessage -= m_cLogTask_UEventMessage;
                m_cLogTask.Dispose();

                m_lstLogFilePath = m_cLogTask.NowLogFilePathList;

                m_cLogTask = null;

                if (m_cMonitor != null)
                {
                    m_cMonitor.Stop();
                    m_cMonitor.Source.UEventValueChanged += Source_UEventValueChanged;
                    //m_cMonitor.Logger.UEventValueChanged -= new UEventHandlerMonitorValueChanged(MonitorLogger_UEventValueChanged);
                    m_cMonitor.Dispose();
                    m_cMonitor = null;
                }
            }
            else if (m_emEMCollectorType == EMSourceType.LS)
            {
                m_cLogTask.Stop();

                m_cLogTask.UEventMessage -= m_cLogTask_UEventMessage;
                m_cLogTask.Dispose();

                m_lstLogFilePath = m_cLogTask.NowLogFilePathList;

                m_cLogTask = null;

                if(m_cLsReader !=null)
                {
                    m_cLsReader.Stop();
                    m_cLsReader.UEventValueChanged -= m_cLsReader_UEventValueChanged;
                    m_cLsReader.Dispose();
                    m_cLsReader = null;
                }
            }
            else
            {
                m_cReader.Stop();
                m_cReader.UEventMessage -= m_cReader_UEventMessage;
                m_cReader.Dispose();

                m_lstLogFilePath = m_cReader.LogFilePathList;

                m_cReader = null;
            }
            m_bRun = false;

            GetTimeLogS(m_lstLogFilePath.ToArray());

            return true;
        }

		#endregion


		#region Private Methods

        private void GetTimeLogS(string[] saPath)
        {
            CCsvLogReader cLogReader = new CCsvLogReader();
            bool bOK = cLogReader.Open(saPath);
            if (bOK)
                m_cTimeLogS = cLogReader.ReadTimeLogS();
            else
                m_cTimeLogS = null;
        }

        private bool IsEndCoilTag(CTag cTag)
        {
            if (cTag == null)
                return false;

            bool bOK = true;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                if (cTag.StepRoleS[i].RoleType != EMStepRoleType.Coil && cTag.StepRoleS[i].RoleType != EMStepRoleType.Both)
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }
        
        private CDDEASymbolList ToSymbolList(List<CTag> lstTag)
        {
            CDDEASymbolList lstSymbol = new CDDEASymbolList();

            CTag cTag;
            CDDEASymbol cSymbol;
            for (int i = 0; i < lstTag.Count; i++)
            {
                try
                {
                    cTag = lstTag[i];
                    cSymbol = new CDDEASymbol(cTag);

                    lstSymbol.AddSymbol(cSymbol);
                    lstSymbol.CreateWordLength(cSymbol);

                }
                catch (System.Exception ex)
                {
                    ex.Data.Clear();
                }
            }

            return lstSymbol;
        }

        private int GetIndexSymbolCount(CDDEASymbolList lstSymbol)
        {
            List<CDDEASymbol> lstSub = lstSymbol.FindAll(b => b.IndexAddressNumber != -1);
            CDDEASymbolList lstResult = new CDDEASymbolList();
            foreach (CDDEASymbol sym in lstSub)
            {
                //새로 생성
                CDDEASymbol cAddSymbol = AddIndexSymbol(sym);
                string sIndexAddress = sym.IndexHeader + sym.IndexAddressNumber.ToString();
                CDDEASymbol cFindSymbol = lstSymbol.Find(b => b.Address == sIndexAddress);
                if (cFindSymbol == null)
                    lstResult.AddSymbol(cAddSymbol);
            }
            return lstResult.Count;
        }

        private CDDEASymbol AddIndexSymbol(CDDEASymbol cSymbol)
        {
            //새로 생성
            string sAddSymbolName = cSymbol.IndexHeader + cSymbol.IndexAddressNumber.ToString();
            string sKeyName = "[Created]" + sAddSymbolName;
            CDDEASymbol cAddSymbol = new CDDEASymbol(sKeyName, true);
            cAddSymbol.CreateMelsecDDEASymbol(sAddSymbolName);
            cAddSymbol.IndexType = EMIndexTypeMS.CreateIndex;
            cAddSymbol.BaseAddress = sAddSymbolName;

            return cAddSymbol;
        }

        private int GetWordCountFromWordDot(List<CDDEASymbol> lstSymbol)
        {
            int iCount = 0;
            int iLeaderAddress = 0;
            List<int> lstSym = new List<int>();
            List<CDDEASymbol> lstSub = null;

            foreach (CDDEASymbol sym in lstSymbol)
            {
                iLeaderAddress = sym.AddressMajor;
                if (!lstSym.Contains(iLeaderAddress))
                {
                    lstSym.Add(iLeaderAddress);
                    lstSub = new List<CDDEASymbol>();
                    lstSub = lstSymbol.FindAll(b => b.AddressMajor == sym.AddressMajor);
                    lstSub.Sort(new CSymbolMinorComparer());
                    if (lstSub.Count > 0)
                        iCount++;
                }
            }

            return iCount;
        }

        private int GetWordCountFromBit(List<CDDEASymbol> lstSymbol)
        {
            int iCount = 0;
            int iLeaderAddress = 0;
            int iLastSymbolMajor = -1;
            string sAddress = "";
            foreach (CDDEASymbol sym in lstSymbol)
            {
                if (iLastSymbolMajor >= sym.AddressMajor)
                    continue;
                iLeaderAddress = sym.AddressMajor;
                int iLoofCount = 0;
                foreach (CDDEASymbol sub in lstSymbol)
                {
                    if (((iLeaderAddress + 31) >= sub.AddressMajor) && (iLeaderAddress <= sub.AddressMajor))
                    {
                        iLastSymbolMajor = sub.AddressMajor;
                    }
                    if (iLoofCount > 31)
                    {
                        sAddress += sym.Address + "/";
                        break;
                    }
                    if (iLeaderAddress <= sub.AddressMajor)
                        iLoofCount = sub.AddressMajor - iLeaderAddress;
                }
                iCount++;
            }
            return iCount;
        }


        private bool RunDDEACollect()
        {
            CDDEAProject cDDEAProject = new CDDEAProject(m_sName);
            cDDEAProject.Config = m_cConfig;
            cDDEAProject.SetNormalBundleList(m_cSymbolS);
            cDDEAProject.CollectMode = EMCollectMode.Normal;
            cDDEAProject.ConnectApp = EMConnectAppType.Profiler;
            cDDEAProject.LogSavePath = CProjectManager.SelectedProject.SaveLogPath;
            cDDEAProject.LogSaveTime = 1;

            CDDEASymbolS cSymbolS = new CDDEASymbolS();
            foreach (CNormalMode nor in cDDEAProject.NormalBundleList)
            {
                cSymbolS.AddSymbolList(nor.BitSymbolList);
                cSymbolS.AddSymbolList(nor.WordSymbolList);
                cSymbolS.AddSymbolList(nor.IndexSymbolList);
                cSymbolS.AddSymbolList(nor.IncludeIndexSymbolList);
            }
            if (cDDEAProject.NormalBundleList.Count == 0)
                return false;

            m_cReader = new UDM.DDEA.CDDEARead(cDDEAProject, m_cConfig.MelsecCpuType);
            m_cReader.UEventMessage += m_cReader_UEventMessage;
            bool bOK = m_cReader.Run();
            if (bOK == false)
            {
                return false;
            }

            m_cDDEASymbolS = cSymbolS;

            return true;


        }

        private bool RunLsDDEACollect()
        {
            if (m_cLsReader == null)
                m_cLsReader = new CLsReader();

            if (m_cLogTask == null)
                m_cLogTask = new CDDEATask(m_sName, m_sSaveLogPath, m_iSaveLogTime, m_iMaxLogfileCount);

            m_cLogTask.UEventMessage += m_cLogTask_UEventMessage;
            bool bOK = m_cLogTask.Run();
            if (bOK == false)
                return false;

            m_cLsReader.Config = m_cLsConfig;
            bOK = m_cLsReader.Connect();

            if (m_cSymbolS.Count == 0) return false;

            m_cLsReader.AddItemS(m_cSymbolS.Values.Select(b=>b.Tag).ToList());
            m_cLsReader.UEventValueChanged += m_cLsReader_UEventValueChanged;

            if (bOK)
                bOK = m_cLsReader.Run();

            if (bOK == false)
            {
                m_cLsReader.UEventValueChanged -= m_cLsReader_UEventValueChanged;
                m_cLsReader.Dispose();
                m_cLsReader = null;

                return false;
            }
            return true;
        }

        private bool RunOPCCollect()
        {
            if (CProjectManager.SelectedProject.OpcConfig.ServerName == "")
            {
                return false;
            }
            if (m_cMonitor == null)
                m_cMonitor = new CMonitor();

            if (m_cLogTask == null)
                m_cLogTask = new CDDEATask(m_sName, m_sSaveLogPath, m_iSaveLogTime, m_iMaxLogfileCount);

            m_cLogTask.UEventMessage += m_cLogTask_UEventMessage;
            bool bOK = m_cLogTask.Run();
            if (bOK == false)
                return false;

            this.OpcConfig.Use = true;
            m_cMonitor.Source.SourceType = UDM.Monitor.Plc.Source.EMSourceType.OPC;
            m_cMonitor.Source.OPCConfig = this.OpcConfig;
            CTagS cTotalTagS = new CTagS();
            foreach (var who in this.SymbolS)
                cTotalTagS.Add(who.Value.Tag);

            m_cMonitor.TagS = cTotalTagS;
            m_cMonitor.Source.UEventValueChanged += Source_UEventValueChanged;
            //m_cMonitor.Logger.UEventValueChanged += MonitorLogger_UEventValueChanged;

            bOK = m_cMonitor.Run();
            if (bOK == false)
            {
                m_cMonitor.Stop();
                m_cLogTask.Stop();
                return false;
            }

            return bOK;
        }

		#endregion


		#region Event Method


        void m_cReader_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (m_cReader != null && UEventMessage != null)
            {
                if (sSender == "NewLogPath")
                    m_lstLogFilePath.Add(sMessage);
                else
                    UEventMessage(sender, sSender, sMessage);
            }
        }

        void Source_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            if (m_cLogTask != null)
            {
                m_cLogTask.EventDataChanged(cLogS);

                foreach (CTimeLog log in cLogS)
                {
                    if (this.SymbolS.ContainsKey(log.Key))
                    {
                        this.SymbolS[log.Key].ChangeCount++;
                        this.SymbolS[log.Key].CurrentValue = log.Value.ToString();
                    }
                }
            }
        }


        void m_cLsReader_UEventValueChanged(object sender, CTimeLogS cLogS)
        {
            if (m_cLogTask != null)
            {
                m_cLogTask.EventDataChanged(cLogS);

                foreach (CTimeLog log in cLogS)
                {
                    if (this.SymbolS.ContainsKey(log.Key))
                    {
                        this.SymbolS[log.Key].ChangeCount++;
                        this.SymbolS[log.Key].CurrentValue = log.Value.ToString();
                    }
                }
            }
        }


        void MonitorLogger_UEventValueChanged(object sender, UDM.Log.CTimeLogS cLogS)
        {
            if (m_cLogTask != null)
            {
                m_cLogTask.EventDataChanged(cLogS);

                foreach (CTimeLog log in cLogS)
                {
                    if (this.SymbolS.ContainsKey(log.Key))
                    {
                        this.SymbolS[log.Key].ChangeCount++;
                        this.SymbolS[log.Key].CurrentValue = log.Value.ToString();
                    }
                }
            }

            cLogS.Clear();
            cLogS = null;
        }

        void m_cLogTask_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (m_cLogTask != null && UEventMessage != null)
            {
                UEventMessage(sender, sSender, sMessage);
            }
        }

		#endregion
	}
}
