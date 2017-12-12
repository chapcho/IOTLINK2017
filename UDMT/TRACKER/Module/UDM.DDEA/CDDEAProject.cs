using System.Collections.Generic;
using System;
using System.IO;
using UDM.Common;
using UDM.General.Serialize;

namespace UDM.DDEA
{
    [Serializable]
    public class CDDEAProject
    {
        #region Member Variables

        protected string m_sPath = string.Empty;
        protected string m_sName = string.Empty;
        protected string m_sMachineName = string.Empty;
        protected string m_sMachineDescription = string.Empty;
        protected string m_sLogSavePath = string.Empty;

        protected int m_iCycleCount = 2;
        protected int m_iStartBlock = 1;
        protected int m_iLogSaveTime = 10;
        protected int m_iParamReadTime = 4;
        protected int m_iMasterRecipeValue = 0;

        protected bool m_bServerRunFlag = false;
        protected bool m_bParaFileChagne = false;
        protected CDDEASymbolList m_cRecipeSymbolList = new CDDEASymbolList();
        protected CDDEAConfigMS m_cDDEAConfig = new CDDEAConfigMS();
        protected List<CNormalMode> m_cNormalBundleList = new List<CNormalMode>();

        protected EMCollectMode m_emCollectMode = EMCollectMode.Normal;
        protected EMConnectAppType m_emConnectAppType = EMConnectAppType.None;
        protected Dictionary<string, int> m_dicHeaderSize = new Dictionary<string, int>();

        protected List<string> m_lstFailCollectAddress = new List<string>();
        protected Dictionary<string, int> m_dicParameterValue = null;

        public event UEventHandlerMainMessage UEventProjectMessage;

        [NonSerialized]
        protected List<string> m_lstLogFilePath = new List<string>();

        #endregion


        #region Initialize

        public CDDEAProject(string sName)
        {
            m_sName = sName;
        }
        public CDDEAProject()
        {
            m_sName = "None";
        }

        #endregion


        #region Public Properties

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

        public string MachineName
        {
            get { return m_sMachineName; }
            set { m_sMachineName = value; }
        }

        public string MachineDescription
        {
            get { return m_sMachineDescription; }
            set { m_sMachineDescription = value; }
        }

        public string LogSavePath
        {
            get { return m_sLogSavePath; }
            set { m_sLogSavePath = value; }
        }

        public int CycleCount
        {
            get { return m_iCycleCount; }
            set { m_iCycleCount = value; }
        }

        public int StartBlock
        {
            get { return m_iStartBlock; }
            set { m_iStartBlock = value; }
        }

        public int LogSaveTime
        {
            get { return m_iLogSaveTime; }
            set { m_iLogSaveTime = value; }
        }

        public int ParamReadTime
        {
            get { return m_iParamReadTime; }
            set { m_iParamReadTime = value; }
        }

        public int MasterRecipeValue
        {
            get { return m_iMasterRecipeValue; }
            set { m_iMasterRecipeValue = value; }
        }

        /// <summary>
        /// Only word(1개)
        /// </summary>
        public CDDEASymbolList RecipeSymbolList
        {
            get { return m_cRecipeSymbolList; }
            set { m_cRecipeSymbolList = value; }
        }

        public List<CNormalMode> NormalBundleList
        {
            get { return m_cNormalBundleList; }
            set { m_cNormalBundleList = value; }
        }
        
        public CDDEAConfigMS Config
        {
            get { return m_cDDEAConfig; }
            set { m_cDDEAConfig = value; }
        }

        public EMCollectMode CollectMode
        {
            get { return m_emCollectMode; }
            set { m_emCollectMode = value; }
        }

        public EMConnectAppType ConnectApp
        {
            get { return m_emConnectAppType; }
            set { m_emConnectAppType = value; }
        }

        public Dictionary<string, int> HeaderSize
        {
            get { return m_dicHeaderSize; }
            set { m_dicHeaderSize = value; }
        }

        public bool ServerRunFlag
        {
            get { return m_bServerRunFlag; }
            set { m_bServerRunFlag = value; }
        }

        public List<string> FailAddressList
        {
            get { return m_lstFailCollectAddress; }
            set { m_lstFailCollectAddress = value; }
        }

        public bool ParaFileChange
        {
            get { return m_bParaFileChagne; }
            set { m_bParaFileChagne = value; }
        }

        public Dictionary<string, int> DeviceParameterSize
        {
            get { return m_dicParameterValue; }
            set { m_dicParameterValue = value; }
        }

        public List<string> LogFilePahtList
        {
            get { return m_lstLogFilePath; }
            set { m_lstLogFilePath = value; }
        }

        #region Symbol이 있는지 확인

        public bool IsRecipeSymbolS
        {
            get
            {
                if (m_cRecipeSymbolList.Count > 0)
                    return true;
                return false;
            }
        }

        #endregion

        #endregion


        #region Public Method

        public bool Open(string sPath)
        {
            bool bOK = true;

            FileInfo file = new FileInfo(sPath);
            if (file.Exists == false)
                return false;

            m_sPath = sPath;

            Clear();

            CNetSerializer cSerializer = new CNetSerializer();
            object oProject = cSerializer.Read(sPath);

            if (oProject != null)
            {
                CDDEAProject cProject = (CDDEAProject)oProject;
                m_sName = cProject.Name;
                m_sPath = cProject.Path;
                m_cDDEAConfig = cProject.Config;
                m_iCycleCount = cProject.CycleCount;
                m_cRecipeSymbolList = cProject.RecipeSymbolList;
                m_cNormalBundleList = cProject.NormalBundleList;
                m_iStartBlock = cProject.StartBlock;
                m_emCollectMode = cProject.CollectMode;
                m_emConnectAppType = cProject.ConnectApp;
                m_iLogSaveTime = cProject.LogSaveTime;
                m_iMasterRecipeValue = cProject.MasterRecipeValue;
            }
            else
            {
                bOK = false;
            }
            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public bool Save(string sPath)
        {
            bool bOK = true;

            m_sPath = sPath;

            CDDEAProject cProject = new CDDEAProject(m_sName);
            cProject.Path = sPath;
            cProject.Config = m_cDDEAConfig;
            cProject.CycleCount = m_iCycleCount;
            cProject.RecipeSymbolList = m_cRecipeSymbolList;
            cProject.NormalBundleList = m_cNormalBundleList;
            cProject.StartBlock = m_iStartBlock;
            cProject.CollectMode = m_emCollectMode;
            cProject.ConnectApp = m_emConnectAppType;
            cProject.LogSaveTime = m_iLogSaveTime;
            cProject.MasterRecipeValue = m_iMasterRecipeValue;

            CNetSerializer cSerializer = new CNetSerializer();
            bOK = cSerializer.Write(sPath, cProject);
            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public void Clear()
        {
            GC.Collect();
        }

        public void SetDDEARecipeSymbolS(CTag cTag)
        {
            if (cTag.Address == "") return;
            m_cRecipeSymbolList = ChangeTagToDDEASymbolList(cTag);
        }

        public void SetNormalBundleList(CPacketInfoS cPacketInfoS, CTagS cAllTags)
        {
            foreach (CPacketInfo packet in cPacketInfoS)
            {
                CNormalMode cNormal = new CNormalMode();
                List<CDDEASymbol> lstSymbol = GetCollectDDEASymbolList(packet.RefTagS, cAllTags);

                cNormal = CreateNormalBundle(lstSymbol);
                foreach (CDDEASymbol sym in lstSymbol)
                {
                    if (sym.BaseAddress == "" && sym.CollectUse)
                        SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                }
                m_cNormalBundleList.Add(cNormal);
            }
        }

        public void SetNormalBundleList(CDDEASymbolS cSymbolS)
        {
            List<CDDEASymbol> cSymbolList = GetCollectDDEASymbolList(cSymbolS);
            CNormalMode cNormal = new CNormalMode();

            if (cSymbolList != null)
            {
                cNormal = CreateNormalBundle(cSymbolList);
                foreach (CDDEASymbol sym in cSymbolList)
                {
                    if (sym.BaseAddress == "" && sym.CollectUse)
                        SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                }
                m_cNormalBundleList.Add(cNormal);
            }
            else
            {
                //94 워드 초과시 다시 리스트를 만들어야함.
                List<CDDEASymbolList> lstSymbolS = DivideBaseWordSize(cSymbolS);
                foreach (CDDEASymbolList syms in lstSymbolS)
                {
                    cNormal = CreateNormalBundle(syms);
                    foreach (CDDEASymbol sym in syms)
                    {
                        if (sym.BaseAddress == "" && sym.CollectUse)
                        {
                            SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                        }
                    }
                    m_cNormalBundleList.Add(cNormal);
                }
            }
        }

        public void SetNormalBundleList(CSymbolS cSymbolS)
        {
            List<CDDEASymbol> cSymbolList = GetCollectDDEASymbolList(cSymbolS);
            CNormalMode cNormal = new CNormalMode();

            if (cSymbolList != null)
            {
                cNormal = CreateNormalBundle(cSymbolList);
                foreach (CDDEASymbol sym in cSymbolList)
                {
                    if (sym.BaseAddress == "" && sym.CollectUse)
                        SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                }
                m_cNormalBundleList.Add(cNormal);
            }
            else
            {
                //94 워드 초과시 다시 리스트를 만들어야함.
                List<CDDEASymbolList> lstSymbolS = DivideBaseWordSize(cSymbolS);
                foreach (CDDEASymbolList syms in lstSymbolS)
                {
                    cNormal = CreateNormalBundle(syms);
                    foreach (CDDEASymbol sym in syms)
                    {
                        if (sym.BaseAddress == "" && sym.CollectUse)
                        {
                            SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                        }
                    }
                    m_cNormalBundleList.Add(cNormal);
                }
            }
        }


        public void SetNormalBundleList(CTagS cTagS)
        {
            List<CDDEASymbol> cSymbolList = GetCollectDDEASymbolList(cTagS);
            CNormalMode cNormal = new CNormalMode();

            if (cSymbolList != null)
            {
                cNormal = CreateNormalBundle(cSymbolList);
                foreach (CDDEASymbol sym in cSymbolList)
                {
                    if (sym.BaseAddress == "" && sym.CollectUse)
                        SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                }
                m_cNormalBundleList.Add(cNormal);
            }
            else
            {
                //94 워드 초과시 다시 리스트를 만들어야함.
                List<CDDEASymbolList> lstSymbolS = DivideBaseWordSize(cTagS);
                foreach (CDDEASymbolList syms in lstSymbolS)
                {
                    cNormal = CreateNormalBundle(syms);
                    foreach (CDDEASymbol sym in syms)
                    {
                        if (sym.BaseAddress == "" && sym.CollectUse)
                        {
                            SetEventMessage("CreateBundle", "Error : " + sym.Address + " 접점의 BaseAddress가 없다.");
                        }
                    }
                    m_cNormalBundleList.Add(cNormal);
                }
            }
        }


        private List<CDDEASymbolList> DivideBaseWordSize(CDDEASymbolS cSymbolS)
        {
            CDDEASymbolList cAddSymbolList = new CDDEASymbolList();
            List<CDDEASymbolList> lstSymbolList = new List<CDDEASymbolList>();

            int iSize = 0;

            foreach (var who in cSymbolS)
            {
                cAddSymbolList.AddSymbol(who.Value);
                iSize++;
                if (iSize >= 94)
                {
                    iSize = GetWordSize(cAddSymbolList.ChangeToDDEASymbolS());
                    if (iSize >= 94)
                    {
                        iSize = 0;
                        lstSymbolList.Add(cAddSymbolList);
                        cAddSymbolList = new CDDEASymbolList();
                    }
                }
            }
            if (iSize > 0)
            {
                lstSymbolList.Add(cAddSymbolList);
            }

            return lstSymbolList;

        }

        private List<CDDEASymbolList> DivideBaseWordSize(CSymbolS cSymbolS)
        {
            CDDEASymbolList cAddSymbolList = new CDDEASymbolList();
            List<CDDEASymbolList> lstSymbolList = new List<CDDEASymbolList>();

            int iSize = 0;

            foreach (var who in cSymbolS)
            {
                CDDEASymbolList lstCreate = CreateDDEASymbolList(who.Value);
                cAddSymbolList.AddSymbolList(lstCreate);
                iSize += lstCreate.Count;
                if (iSize >= 94)
                {
                    iSize = GetWordSize(cAddSymbolList.ChangeToDDEASymbolS());
                    if (iSize >= 94)
                    {
                        iSize = 0;
                        lstSymbolList.Add(cAddSymbolList);
                        cAddSymbolList = new CDDEASymbolList();
                    }
                }
            }
            if (iSize > 0)
            {
                lstSymbolList.Add(cAddSymbolList);
            }

            return lstSymbolList;

        }

        private List<CDDEASymbolList> DivideBaseWordSize(CTagS cTagS)
        {
            CDDEASymbolList cAddSymbolList = new CDDEASymbolList();
            List<CDDEASymbolList> lstSymbolList = new List<CDDEASymbolList>();

            int iSize = 0;

            foreach (var who in cTagS)
            {
                CDDEASymbolList lstCreate = CreateDDEASymbolList(who.Value);
                cAddSymbolList.AddSymbolList(lstCreate);
                iSize += lstCreate.Count;
                if (iSize >= 94)
                {
                    iSize = GetWordSize(cAddSymbolList.ChangeToDDEASymbolS());
                    if (iSize >= 94)
                    {
                        iSize = 0;
                        lstSymbolList.Add(cAddSymbolList);
                        cAddSymbolList = new CDDEASymbolList();
                    }
                }
            }
            if (iSize > 0)
            {
                lstSymbolList.Add(cAddSymbolList);
            }

            return lstSymbolList;

        }

        #endregion


        #region Protected Method

        protected void AddCycleSymbol(CConditionS cCycleCondition, CDDEASymbolList cSymbolList)
        {
            foreach (CCondition condi in cCycleCondition)
            {
                CDDEASymbol cFindSym = cSymbolList.Find(b => b.Key == condi.Key);
                if (cFindSym == null)
                {
                    //리스트에 Cycle 접점이 없어 추가해 줘야함.
                    CDDEASymbol cCycleSymbol = new CDDEASymbol(condi.Key, false);
                    cCycleSymbol.CreateMelsecDDEASymbol(condi.Address);
                    cSymbolList.AddSymbol(cCycleSymbol);
                }
            }
        }

        /// <summary>
        /// Bit -> 32Bit묶음 최적화 및 Bit, Word, DWord 비교 할 요소 분리
        /// </summary>
        /// <param name="clstDDESymbol"></param>
        /// <returns></returns>
        protected CNormalMode CreateNormalBundle(List<CDDEASymbol> clstDDESymbol)
        {
            //중복된걸 확인

            List<string> lstHeader = new List<string>();
            List<CDDEASymbol> lstSub = null;
            CNormalMode cBundleResult = new CNormalMode();

            //FragMode == true일 경우 Index를 포함한 주소에서 인덱스를 추출하여 Index SymbolS에 삽입(인덱스를 포함한 주소, 인덱스)
            //false일경우 이미 Tag List에 포함 되었으므로 그냥 분류만 한다.
            List<CDDEASymbol> lstIndexSymbol = InsertIncludeIndexSymbol(clstDDESymbol);
            cBundleResult.IncludeIndexSymbolList.AddSymbolList(lstIndexSymbol);

            lstIndexSymbol = InsertIndexSymbol(clstDDESymbol);
            cBundleResult.IndexSymbolList.AddSymbolList(lstIndexSymbol);

            foreach (CDDEASymbol sym in clstDDESymbol)
            {
                if (m_lstFailCollectAddress.Contains(sym.Address))
                    sym.CollectUse = false;
            }

            foreach (CDDEASymbol sym in clstDDESymbol)
            {
                if (sym.IndexAddressNumber != -1)
                    continue;
                if (sym.IndexType == EMIndexTypeMS.IncludeAddress)
                    continue;
                if (sym.DataType == EMDataType.Bool)
                {
                    if (!lstHeader.Contains("B_" + sym.AddressHeader))
                    {
                        lstHeader.Add("B_" + sym.AddressHeader);
                        //같은 헤더를 갖는 접점들을 추출
                        lstSub = new List<CDDEASymbol>();
                        lstSub = clstDDESymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.Bool && b.CollectUse == true);
                        lstSub.Sort(new CSymbolComparer());
                        List<CDDEASymbol> lstAddSymbol = null;
                        //Word에 dot 붙었을 경우와 일반 Bit접점을 구분해서 Mask 입력 처리해야함.
                        if (sym.AddressMinor != -1)
                            lstAddSymbol = InsertWordDotSymbol(lstSub);
                        else
                            lstAddSymbol = InsertBitSymbol(lstSub);
                        cBundleResult.BitSymbolList.AddSymbolList(lstAddSymbol);
                    }
                }
                else if (sym.DataType == EMDataType.Word)
                {
                    if (!lstHeader.Contains("W_" + sym.AddressHeader))
                    {
                        lstHeader.Add("W_" + sym.AddressHeader);
                        lstSub = new List<CDDEASymbol>();
                        lstSub = clstDDESymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.Word && b.IndexAddressNumber == -1 && b.IndexType != EMIndexTypeMS.IncludeAddress && b.CollectUse == true);
                        lstSub.Sort(new CSymbolComparer());
                        //List<CDDEASymbol> lstAddSymbol = InsertWordSymbol(lstSub);
                        cBundleResult.WordSymbolList.AddSymbolList(lstSub);
                    }

                }
                else if (sym.DataType == EMDataType.DWord)
                {
                    if (!lstHeader.Contains("DW_" + sym.AddressHeader))
                    {
                        lstHeader.Add("DW_" + sym.AddressHeader);
                        lstSub = new List<CDDEASymbol>();
                        lstSub = clstDDESymbol.FindAll(b => b.AddressHeader == sym.AddressHeader && b.DataType == EMDataType.DWord && b.CollectUse == true);
                        lstSub.Sort(new CSymbolComparer());
                        List<CDDEASymbol> lstAddSymbol = InsertDWordSymbol(lstSub);
                        cBundleResult.WordSymbolList.AddSymbolList(lstAddSymbol);
                    }
                }
            }

            return cBundleResult;
        }

        #region Bundle Method

        protected List<CDDEASymbol> InsertIncludeIndexSymbol(List<CDDEASymbol> lstSymbol)
        {
            List<CDDEASymbol> lstSub = lstSymbol.FindAll(b => b.IndexAddressNumber != -1);
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();
            foreach (CDDEASymbol sym in lstSub)
            {
                sym.BaseAddress = sym.Address;

                string sIndexAddress = sym.IndexHeader + sym.IndexAddressNumber.ToString();
                CDDEASymbol cFindSymbol = lstSymbol.Find(b => b.Address == sIndexAddress);
                if (cFindSymbol != null)
                {
                    sym.IndexKey = cFindSymbol.Key;
                }
                lstResult.Add(sym);

            }
            return lstResult;
        }

        protected List<CDDEASymbol> InsertIndexSymbol(List<CDDEASymbol> lstSymbol)
        {
            List<CDDEASymbol> lstSub = lstSymbol.FindAll(b => b.IndexAddressNumber != -1);
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();
            foreach (CDDEASymbol sym in lstSub)
            {
                //새로 생성
                CDDEASymbol cAddSymbol = AddIndexSymbol(sym);
                string sIndexAddress = sym.IndexHeader + sym.IndexAddressNumber.ToString();
                CDDEASymbol cFindSymbol = lstSymbol.Find(b => b.Address == sIndexAddress);
                if (cFindSymbol != null)
                    sym.IndexKey = cFindSymbol.Key;

                lstResult.Add(cAddSymbol);
            }
            return lstResult;
        }

        protected CDDEASymbol AddIndexSymbol(CDDEASymbol cSymbol)
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

        /// <summary>
        /// Word심볼에Dot가 있는 것에 한해서 32bit단위로 최적 묶기
        /// </summary>
        /// <param name="lstSource"></param>
        /// <returns></returns>
        protected List<CDDEASymbol> InsertWordDotSymbol(List<CDDEASymbol> lstSource)
        {
            int iLeaderAddress = 0;
            List<int> lstSym = new List<int>();
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();
            List<CDDEASymbol> lstSub = null;
            foreach (CDDEASymbol sym in lstSource)
            {
                if (m_lstFailCollectAddress.Contains(sym.Address))
                {
                    sym.CollectUse = false;
                    continue;
                }
                iLeaderAddress = sym.AddressMajor;
                if (!lstSym.Contains(iLeaderAddress))
                {
                    lstSym.Add(iLeaderAddress);
                    lstSub = new List<CDDEASymbol>();
                    lstSub = lstSource.FindAll(b => b.AddressMajor == sym.AddressMajor);
                    lstSub.Sort(new CSymbolMinorComparer());

                    foreach (CDDEASymbol sub in lstSub)
                    {
                        sub.Mask = (UInt32)(0x01 << sub.AddressMinor);
                        sub.BaseAddress = sub.AddressHeader + sub.AddressHeadRemainder;
                        lstResult.Add(sub);
                    }
                }
            }
            return lstResult;
        }

        /// <summary>
        /// Bit심볼에 한해서 32bit단위로 최적 묶기
        /// </summary>
        /// <param name="lstSource"></param>
        /// <returns></returns>
        protected List<CDDEASymbol> InsertBitSymbol(List<CDDEASymbol> lstSource)
        {
            int iLeaderAddress = 0;
            int iLastSymbolMajor = -1;
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();
            foreach (CDDEASymbol sym in lstSource)
            {
                if (iLastSymbolMajor >= sym.AddressMajor)
                    continue;

                int iLoofCount = 0;
                bool bPass = false;
                if (m_dicParameterValue != null)
                {
                    if (m_dicParameterValue.ContainsKey(sym.AddressHeader))
                    {
                        int iSize = m_dicParameterValue[sym.AddressHeader] - 32;
                        int iMaxSize = m_dicParameterValue[sym.AddressHeader];
                        if (iMaxSize <= sym.AddressMajor)
                        {
                            sym.CollectUse = false;
                            continue;
                        }
                        if (iSize < sym.AddressMajor)
                        {
                            //끝부분에 가까워져 K8로 묶을 수 없음.
                            bPass = true;
                            string sAddress = sym.AddressHeader + iSize.ToString();
                            if (sym.CheckAddressHexa(sAddress))
                            {
                                string sHexa = string.Format("{0:x}", iSize);
                                sAddress = sym.AddressHeader + sHexa.ToUpper();
                            }
                            foreach (CDDEASymbol sub in lstSource)
                            {
                                if (((iSize + 31) >= sub.AddressMajor) && (iSize <= sub.AddressMajor))
                                {
                                    int isum = sub.AddressMajor - iSize;
                                    sub.Mask = (UInt32)(0x01 << isum);
                                    sub.BaseAddress = sAddress;
                                    lstResult.Add(sub);
                                    iLastSymbolMajor = sub.AddressMajor;
                                }
                                if (iLoofCount > 31)
                                {
                                    break;
                                }
                                if (iSize <= sub.AddressMajor)
                                    iLoofCount++;
                            }
                        }
                    }
                }

                if (bPass == false)
                {
                    iLoofCount = 0;
                    iLeaderAddress = sym.AddressMajor;
                    foreach (CDDEASymbol sub in lstSource)
                    {
                        if (((iLeaderAddress + 31) >= sub.AddressMajor) && (iLeaderAddress <= sub.AddressMajor))
                        {
                            int isum = sub.AddressMajor - iLeaderAddress;
                            sub.Mask = (UInt32)(0x01 << isum);
                            sub.BaseAddress = sym.Address;
                            lstResult.Add(sub);
                            iLastSymbolMajor = sub.AddressMajor;
                        }
                        if (iLoofCount > 31)
                        {
                            break;
                        }
                        if (iLeaderAddress <= sub.AddressMajor)
                            iLoofCount++;
                    }
                }
            }
            return lstResult;
        }


        /// <summary>
        /// DWord값일 경우 Dictionary에 삽입
        /// </summary>
        /// <param name="lstSource"></param>
        /// <returns></returns>
        protected List<CDDEASymbol> InsertDWordSymbol(List<CDDEASymbol> lstSource)
        {
            List<CDDEASymbol> lstResult = new List<CDDEASymbol>();
            foreach (CDDEASymbol sym in lstSource)
            {
                sym.Mask = MaskValueExtraction(sym.BitCollectNumber);
                sym.BaseAddress = sym.Address;
                lstResult.Add(sym);
            }
            return lstResult;
        }

        /// <summary>
        /// DWord Mask 값 찾기 K8 == 0xFFFFFFFF(32Bit) K1 == 0xF
        /// </summary>
        /// <param name="sSource">ex)K8</param>
        /// <returns></returns>
        protected UInt32 MaskValueExtraction(int sSource)
        {
            UInt32 iResult = 0;
            switch (sSource)
            {
                case 8:
                    iResult = 0xFFFFFFFF;
                    break;
                case 7:
                    iResult = 0x0FFFFFFF;
                    break;
                case 6:
                    iResult = 0x00FFFFFF;
                    break;
                case 5:
                    iResult = 0x000FFFFF;
                    break;
                case 4:
                    iResult = 0x0000FFFF;
                    break;
                case 3:
                    iResult = 0x00000FFF;
                    break;
                case 2:
                    iResult = 0x000000FF;
                    break;
                case 1:
                    iResult = 0x0000000F;
                    break;
            }

            return iResult;
        }

        #endregion

        protected CDDEASymbolList GetCollectDDEASymbolList(CRefTagS cCollectTagS, CTagS cAllTagS)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            foreach (string sKey in cCollectTagS.KeyList)
            {
                if (cAllTagS.ContainsKey(sKey))
                {
                    CDDEASymbol cSymbol = new CDDEASymbol(cAllTagS[sKey]);
                    cSymbolList.Add(cSymbol);
                    cSymbolList.CreateWordLength(cSymbol);
                }
            }
            return cSymbolList;
        }

        protected CDDEASymbolList GetCollectDDEASymbolList(CSymbolS cSymbolS)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            foreach (var who in cSymbolS)
            {
                if (cSymbolList.Count < 95)
                {
                    CDDEASymbol cSymbol = new CDDEASymbol(who.Value.Key, false);
                    cSymbol.CreateMelsecDDEASymbol(who.Value.Address);
                    cSymbolList.Add(cSymbol);
                    cSymbolList.CreateWordLength(cSymbol);
                }
                else
                {
                    cSymbolList = null;
                    break;
                }
            }
            return cSymbolList;
        }

        protected CDDEASymbolList GetCollectDDEASymbolList(CTagS cTagS)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();
            foreach (var who in cTagS)
            {
                if (cSymbolList.Count < 95)
                {
                    CDDEASymbol cSymbol = new CDDEASymbol(who.Value.Key, false);
                    cSymbol.CreateMelsecDDEASymbol(who.Value.Address);
                    cSymbolList.Add(cSymbol);
                    cSymbolList.CreateWordLength(cSymbol);
                }
                else
                {
                    cSymbolList = null;
                    break;
                }
            }
            return cSymbolList;
        }

        protected CDDEASymbolList CreateDDEASymbolList(CSymbol cSourceSymbol)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();

            CDDEASymbol cSymbol = new CDDEASymbol(cSourceSymbol.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cSourceSymbol.Address);
            cSymbolList.Add(cSymbol);
            cSymbolList.CreateWordLength(cSymbol);

            return cSymbolList;
        }

        protected CDDEASymbolList CreateDDEASymbolList(CTag cTag)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();

            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            cSymbolList.Add(cSymbol);
            cSymbolList.CreateWordLength(cSymbol);

            return cSymbolList;
        }

        protected CDDEASymbolList GetCollectDDEASymbolList(CDDEASymbolS cTrackerSymbolS)
        {
            CDDEASymbolList cSymbolList = new CDDEASymbolList();

            int iSize = GetWordSize(cTrackerSymbolS);
            if (iSize <= 94)
            {
                foreach (var who in cTrackerSymbolS)
                {
                    cSymbolList.Add(who.Value);
                }
            }
            else
                cSymbolList = null;
            return cSymbolList;
        }

        protected CDDEASymbolS ChangeTagSToDDEASymbolS(List<CTag> lstTag)
        {
            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            foreach (CTag sym in lstTag)
            {
                CDDEASymbol cSymbol = new CDDEASymbol(sym.Key, false);
                cSymbol.CreateMelsecDDEASymbol(sym.Address);
                cSymbol.AddressCount = sym.Size;
                if (cSymbolS.ContainsKey(cSymbol.Key) == false)
                    cSymbolS.AddSymbol(cSymbol);

                //Length가 1이상 일경우 새로운Word를 생성한다 단, 새로 생성된 접점은 Length가 0이다.
                if (cSymbol.DataType == EMDataType.Word && sym.Size > 1)
                {
                    cSymbolS.CreateWordLength(cSymbol);
                }
            }

            return cSymbolS;
        }

        /// <summary>
        /// 워드에 포함된 Length를 새로 생성해서 DDEASymbolS로 만들어줌.
        /// </summary>
        /// <param name="cTag"></param>
        /// <returns></returns>
        protected CDDEASymbolS ChangeTagToDDEASymbolS(CTag cTag)
        {
            CDDEASymbolS cSymbolS = new CDDEASymbolS();

            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            cSymbol.AddressCount = cTag.Size;
            cSymbol.BaseAddress = cSymbol.Address;
            if (cSymbolS.ContainsKey(cSymbol.Key) == false)
                cSymbolS.AddSymbol(cSymbol);

            //Length가 1이상 일경우 새로운Word를 생성한다 단, 새로 생성된 접점은 Length가 0이다.
            if (cSymbol.DataType == EMDataType.Word && cTag.Size > 1)
            {
                cSymbolS.CreateWordLength(cSymbol);
            }

            return cSymbolS;
        }


        /// <summary>
        /// 워드에 포함된 Length를 새로 생성해서 DDEASymbolS로 만들어줌.
        /// </summary>
        /// <param name="cTag"></param>
        /// <returns></returns>
        protected CDDEASymbolList ChangeTagToDDEASymbolList(CTag cTag)
        {
            CDDEASymbolList cSymbolS = new CDDEASymbolList();

            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            cSymbol.AddressCount = cTag.Size;
            cSymbol.BaseAddress = cSymbol.Address;
            if (cSymbolS.Contains(cSymbol) == false)
                cSymbolS.AddSymbol(cSymbol);

            //Length가 1이상 일경우 새로운Word를 생성한다 단, 새로 생성된 접점은 Length가 0이다.
            if (cSymbol.DataType == EMDataType.Word && cTag.Size > 1)
            {
                cSymbolS.CreateWordLength(cSymbol);
            }

            return cSymbolS;
        }

        protected CDDEASymbol ChangeTagToDDEASymbol(CTag cTag)
        {
            CDDEASymbol cSymbol = new CDDEASymbol(cTag.Key, false);
            cSymbol.CreateMelsecDDEASymbol(cTag.Address);
            cSymbol.AddressCount = cTag.Size;
            cSymbol.BaseAddress = cTag.Address;

            return cSymbol;
        }

        /// <summary>
        /// 최적의 WordSize를 찾기 위한 함수
        /// </summary>
        /// <param name="cSymbolS">Bit, word등 수집할때 Word Size를 맞출 접점리스트</param>
        /// <returns></returns>
        protected int GetWordSize(CDDEASymbolS cSymbolS)
        {
            int iBitToWord = 0;
            int iWordCount = 0;
            int iDWordCount = 0;
            int iIndexAddCount = 0;
            List<CDDEASymbol> lstSymbol;

            if (cSymbolS != null)
                lstSymbol = ChangeFromSymbolSToListSymbol(cSymbolS);
            else
                return -1;

            List<CDDEASymbol> lstIndexInclude = lstSymbol.FindAll(a => a.IndexAddressNumber != -1);
            foreach (CDDEASymbol sym in lstIndexInclude)
            {
                //인덱스를 따로 수집해야 할 경우에 새로운 접점을 생성한다.(Length는 1이지만 IndexType이 CreateIndex이다.
                string sIndexSymbolName = sym.IndexHeader + sym.IndexAddressNumber.ToString();
                //string sKeyName = "[Created]" + sIndexSymbolName;
                CDDEASymbol cIndexSymbol = new CDDEASymbol(sIndexSymbolName, true);
                cIndexSymbol.CreateMelsecDDEASymbol(sIndexSymbolName);
                cIndexSymbol.IndexType = EMIndexTypeMS.CreateIndex;
                if (cSymbolS.ContainsKey(cIndexSymbol.Key) == false)
                    iIndexAddCount++;//lstResult.Add(cIndexSymbol);
            }
            List<string> lstHeader = new List<string>();
            CTagS cFilterTagS = new CTagS();
            List<CDDEASymbol> lstSub = new List<CDDEASymbol>();

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

            int iCnt = iBitToWord + iWordCount + iDWordCount + iIndexAddCount;

            return iCnt;

        }

        protected int GetWordCountFromWordDot(List<CDDEASymbol> lstSymbol)
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

        protected int GetWordCountFromBit(List<CDDEASymbol> lstSymbol)
        {
            int iCount = 0;
            int iLeaderAddress = 0;
            int iLastSymbolMajor = -1;
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
                        break;
                    }
                    if (iLeaderAddress <= sub.AddressMajor)
                        iLoofCount++;
                }
                if (iLoofCount > 0)
                    iCount++;
            }
            return iCount;
        }

        protected List<CDDEASymbol> ChangeFromSymbolSToListSymbol(CDDEASymbolS cSymbolS)
        {
            List<CDDEASymbol> lstSymbol = new List<CDDEASymbol>();

            foreach (var who in cSymbolS)
            {
                lstSymbol.Add(who.Value);
            }

            return lstSymbol;
        }
        protected void SetEventMessage(string sSender, string sMessage)
        {
            if (UEventProjectMessage != null)
            {
                if (sSender == "")
                    UEventProjectMessage(this, "DDEAProject", sMessage);
                else
                    UEventProjectMessage(this, sSender, sMessage);
            }
        }

        #endregion
    }
}
