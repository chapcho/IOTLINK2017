using System;
using UDM.Common;

namespace UDM.DDEA
{
    [Serializable]
    public class CDDEASymbol
    {
        #region Member Variables

        protected string m_sKey = string.Empty;
        protected EMDataType m_emDataType = EMDataType.Bool;
        protected EMAddressTypeMS m_emPLC_AddressType = EMAddressTypeMS.Decimal;        //주소 타입마다 10진수 혹은 16진수를 쓴것인지 판단.(B,X,Y를 제외한 나머지는 10진수)
        protected string m_sAddress = string.Empty;
        protected string m_sAddressHeadRemainder = string.Empty;
        protected string m_sAddressHeader = string.Empty;     //Header만 분리(K붙으면 K+숫자까지 제외)
        protected int m_iAddressMajor = -1;         //Header & Dot 이하 제외한 주소 번호 Hexa면 Decimal로 변경
        protected int m_iAddressMinor = -1;         //Dot 이하 Hexa값을 Decimal로 변경
        protected int m_iBitCollectNum = -1;        //K가 붙었을 때 다음에 오는 숫자 값(Decimal 1~8) - Logic에서 사용할때.
        protected UInt32 m_uiMask = 0xFFFFFFF;
        protected EMReadBitHeader m_emReadBitHeader = EMReadBitHeader.None;

        protected string m_sIndexKey = "";
        protected string m_sIndexNote = "";
        protected int m_iIndexAddressNumber = -1;
        protected string m_sIndexHeader = "";
        protected EMIndexTypeMS m_emIndexType = EMIndexTypeMS.None;

        protected int m_iAddresCount = 1;           //현재 주소부터 몇개까지 해야하는지.
        protected string m_sAddedBaseAddress = "";
        protected bool m_bCollectUse = true;
        protected string m_sDWordSecondAddress = "";
        protected DateTime m_dtMCSCRisingTime = DateTime.MinValue;
        protected int m_iCurrentValue = -1;
        protected int m_iChangeCount = 0;

        #endregion


        #region Initialize

        /// <summary>
        /// 파라메터에서 사용
        /// </summary>
        public CDDEASymbol()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="bCreate">Key에 채널과 디바이스를 자동 생성하려면 True [CH_DV]</param>
        public CDDEASymbol(string sKey, bool bCreate)
        {
            if (bCreate)
                m_sKey = CreateKey(sKey);
            else
                m_sKey = sKey;
        }

        public CDDEASymbol(CTag cTag)
        {
            m_sKey = cTag.Key;
            CreateSymbolFromTag(cTag);
        }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        /// <summary>
        /// 전체 주소 값(K, Z인덱스 등 포함)
        /// set할때 주소를 입력하면 자동으로 내용 전체 삽입됨
        /// </summary>
        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        /// <summary>
        /// Bit, Byte, Word, DWord
        /// </summary>
        public EMDataType DataType
        {
            get { return m_emDataType; }
            set { m_emDataType = value; }
        }

        public EMAddressTypeMS PLCAddressType
        {
            get { return m_emPLC_AddressType; }
            set { m_emPLC_AddressType = value; }
        }

        /// <summary>
        /// Header와 .및 이하를 제외한 값
        /// Z인덱스등 특수모듈일때 사용
        /// </summary>
        public string AddressHeadRemainder
        {
            get { return m_sAddressHeadRemainder; }
            set { m_sAddressHeadRemainder = value; }
        }

        /// <summary>
        /// K가 붙었을 때 다음에 오는 숫자 값(Decimal 1~8) K가 없으면 -1
        /// </summary>
        public int BitCollectNumber
        {
            get { return m_iBitCollectNum; }
            set { m_iBitCollectNum = value; }
        }

        /// <summary>
        /// Address Header만
        /// </summary>
        public string AddressHeader
        {
            get { return m_sAddressHeader; }
            set { m_sAddressHeader = value; }
        }

        /// <summary>
        /// Header와 .및 이하 숫자를 제외한 값을 int로 변경
        /// </summary>
        public int AddressMajor
        {
            get { return m_iAddressMajor; }
            set { m_iAddressMajor = value; }
        }

        /// <summary>
        /// .이하 숫자를 int로 변경한 값
        /// </summary>
        public int AddressMinor
        {
            get { return m_iAddressMinor; }
            set { m_iAddressMinor = value; }
        }

        /// <summary>
        /// 초기 값은 None
        /// Bit일경우 묶음으로 수집하기 위해 앞에 붙이는 Header
        /// ex) X100 -> K8X100 = X100 ~ X11F까지 수집이 가능
        /// </summary>
        public EMReadBitHeader ReadBitHeader
        {
            get { return m_emReadBitHeader; }
            set { m_emReadBitHeader = value; }
        }

        /// <summary>
        /// Bit 일 경우 해당하는 주소에 대한 마스크만 갖음.
        /// </summary>
        public UInt32 Mask
        {
            get { return m_uiMask; }
            set { m_uiMask = value; }
        }

        /// <summary>
        /// 인덱스를 포함한 접점일 경우 인덱스 접점의 Key를 갖고 없으면 비어있다.
        /// </summary>
        public string IndexKey
        {
            get { return m_sIndexKey; }
            set { m_sIndexKey = value; }
        }

        /// <summary>
        /// 인덱스를 포함한 경우에만 사용
        /// </summary>
        public string IndexNote
        {
            get { return m_sIndexNote; }
            set { m_sIndexNote = value; }
        }

        public int IndexAddressNumber
        {
            get { return m_iIndexAddressNumber; }
            set { m_iIndexAddressNumber = value; }
        }

        public string IndexHeader
        {
            get { return m_sIndexHeader; }
            set { m_sIndexHeader = value; }
        }

        /// <summary>
        /// 인덱스 값일 경우 
        /// 인덱스심볼이 아닌 경우 None
        /// 이미 Z값이 List에 존재할 때 읽기만 하면 되므로 Read,
        /// Z값이 없을 경우 Z값을 새로 생성해야하므로 CreateIndex
        /// </summary>
        public EMIndexTypeMS IndexType
        {
            get { return m_emIndexType; }
            set { m_emIndexType = value; }
        }

        /// <summary>
        /// Word일 경우만 사용
        /// </summary>
        public int AddressCount
        {
            get { return m_iAddresCount; }
            set { m_iAddresCount = value; }
        }

        /// <summary>
        /// Word연속된 값의 Log를 남기기 위해 새로 생긴 접점의 Base접점 Address를 표시
        /// Address Count가 1이면 Address와 동일
        /// Bit일 경우 Mask되어 선두 주소를 표시
        /// </summary>
        public string BaseAddress
        {
            get { return m_sAddedBaseAddress; }
            set { m_sAddedBaseAddress = value; }
        }

        public bool CollectUse
        {
            get { return m_bCollectUse; }
            set { m_bCollectUse = value; }
        }

        /// <summary>
        /// Length가 2일 경우 2번째 주소를 갖는다.(ex 자신이 D10 쓰여질 주소는 D11)
        /// </summary>
        public string DWordSecondAddress
        {
            get { return m_sDWordSecondAddress; }
            set { m_sDWordSecondAddress = value; }
        }

        /// <summary>
        /// Bit 접점 일 경우만 사용
        /// 1되는 시점의 시간을 기록 로그를 남긴 후는 다시 MinTime으로..
        /// </summary>
        public DateTime MCSCBitRisingTime
        {
            get { return m_dtMCSCRisingTime; }
            set { m_dtMCSCRisingTime = value; }
        }

        public int CurrentValue
        {
            get { return m_iCurrentValue; }
            set { m_iCurrentValue = value; }
        }

        public int ChangeCount
        {
            get { return m_iChangeCount; }
            set { m_iChangeCount = value; }
        }

        #endregion


        #region Public Method

        /// <summary>
        /// Tag의 멤버변수를 자동으로 채워 준다(단, Index의 Z값은 따로 추출하여 TagS생성시 추가해 주어야한다.)
        /// </summary>
        /// <param name="sAddress"></param>
        public bool CreateMelsecDDEASymbol(string sAddress)
        {
            m_sAddress = sAddress.ToUpper();
            string sUpper = m_sAddress;
            string sHeaderNumberCheck = sUpper.Substring(0, 1);
            string sErrorSymbolName = sUpper;

            try
            {
                if (sHeaderNumberCheck == "K")                       //무조건 32Bit단위로 읽음.K7일경우는 28bit -> k1 4bit Mask에서 확인
                {
                    m_iBitCollectNum = Convert.ToInt32(sUpper.Substring(1, 1));
                    sUpper = sUpper.Substring(2, sUpper.Length - 2);
                    m_emDataType = EMDataType.DWord;
                }
                else if (sHeaderNumberCheck == "@")
                {
                    sUpper = sUpper.Substring(1, sUpper.Length - 1);
                    m_emDataType = EMDataType.Word;
                }
                else if (CheckSymbolBit(sUpper))
                    m_emDataType = EMDataType.Bool;
                else
                    m_emDataType = EMDataType.Word;

                if (CheckAddressHexa(sUpper))
                    m_emPLC_AddressType = EMAddressTypeMS.Hexa;
                else
                    m_emPLC_AddressType = EMAddressTypeMS.Decimal;

                m_sAddressHeader = DivideAddress(sUpper, EMAddressDivisionTypeMS.Header);
                m_sAddressHeadRemainder = DivideAddress(sUpper, EMAddressDivisionTypeMS.AddressNumber);

                if (m_sAddressHeadRemainder.Contains("Z"))
                {
                    //Z인덱스 값은 자동으로 해당하는 주소에 값이 전달되므로 따로 읽을 필요가 없지만 해당 주소의 Value만 가지므로 어디주소 인지 모름.
                    //그러므로 주소확인을 위해 Z영역을 읽어 해당 주소의 Tag에 "+ XXX"로 표시한다.
                    if (!CheckIndexReadErrorSymbol(m_sAddressHeader))
                    {
                        string[] sZIndex = m_sAddressHeadRemainder.Split('Z');
                        int iAddressNum = Convert.ToInt32(sZIndex[1]);
                        string sZIndexAddress = "Z" + sZIndex[1];

                        //if(!cTagS.ContainsKey(sZIndexAddress))
                        //{
                        //    CTag Zsym = new CTag(sZIndexAddress);

                        //    Zsym.AddressHeader = "Z";
                        //    Zsym.AddressHeadRemainder = iAddressNum.ToString();
                        //    Zsym.AddressMajor = iAddressNum;
                        //    Zsym.PLCAddressType = EMPLCAddressType.Decimal;
                        //    Zsym.DataType = EMDataType.Word;
                        //    Zsym.IndexType = EMIndexType.IndexSource;

                        //    cTagS.Add(sZIndexAddress, Zsym);
                        //}
                        //Z인덱스가 붙으며 무조건 워드인데 Header가 X등의 비트로 먼저 판단되므로 다시 Word로 변경
                        m_emDataType = EMDataType.Word;
                        m_emIndexType = EMIndexTypeMS.IncludeAddress;
                        m_sIndexHeader = "Z";
                        m_iIndexAddressNumber = iAddressNum;
                        if (m_emPLC_AddressType == EMAddressTypeMS.Hexa)
                            m_iAddressMajor = Convert.ToInt32(sZIndex[0], 16);
                        else
                            m_iAddressMajor = Convert.ToInt32(sZIndex[0]);
                    }

                }
                else
                {
                    if (sUpper.Contains("."))
                    {
                        if (CheckSymbolBit(sUpper)) return false;
                        string sDot = DivideAddress(sUpper, EMAddressDivisionTypeMS.DotNumber);

                        if (m_emPLC_AddressType == EMAddressTypeMS.Hexa)
                            m_iAddressMajor = Convert.ToInt32(m_sAddressHeadRemainder, 16);
                        else
                            m_iAddressMajor = Convert.ToInt32(m_sAddressHeadRemainder);

                        //cDDESym.AddressBitNumber = Convert.ToUInt32(SymbolDivision(sUpper, false, false, true), 16);
                        m_iAddressMinor = Convert.ToInt32(sDot, 16);
                    }
                    else
                    {
                        if (m_emPLC_AddressType == EMAddressTypeMS.Hexa)
                            m_iAddressMajor = Convert.ToInt32(m_sAddressHeadRemainder, 16);
                        else
                            m_iAddressMajor = Convert.ToInt32(m_sAddressHeadRemainder);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", error.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, sErrorSymbolName);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Header에 따라 Z 인덱스 제외시킬 심볼
        /// </summary>
        /// <param name="sSource"></param>
        /// <returns>true면 제외</returns>
        public bool CheckIndexReadErrorSymbol(string sSource)
        {
            try
            {
                bool bOK = false;
                string[] sOneSize = { "T", "C", "S", "Z" };

                for (int i = 0; i < sOneSize.Length; i++)
                {
                    if (sOneSize[i] == sSource)
                    {
                        bOK = true;
                        break;
                    }
                }
                return bOK;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", ex.InnerException);
            }
        }

        /// <summary>
        /// Header Address에 따라 Address Number값이 Hexa인지 decimal인지 판단
        /// </summary>
        /// <param name="sSymName"></param>
        /// <returns></returns>
        public bool CheckAddressHexa(string sSymName)
        {
            try
            {
                bool bHexa = false;
                int iData = 0;
                string sResult = sSymName.Substring(0, 1);

                if (sSymName.Length < 2)
                {
                    if (int.TryParse(sResult, out iData))
                        return false;
                }

                string[] sHexaValue = { "X", "Y", "B", "W" };
                string[] sHexaTwoValue = { "SW", "SB", "DX", "DY" };
                for (int i = 0; i < sHexaValue.Length; i++)
                {
                    if (sResult == sHexaValue[i])
                    {
                        bHexa = true;
                        break;
                    }
                }
                if (!bHexa)
                {
                    sResult = sSymName.Substring(0, 2);
                    for (int i = 0; i < sHexaTwoValue.Length; i++)
                    {
                        if (sResult == sHexaTwoValue[i])
                        {
                            bHexa = true;
                            break;
                        }
                    }
                }
                return bHexa;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", ex.InnerException);
            }
        }

        /// <summary>
        /// 2개 이상은 안됨
        /// </summary>
        /// <param name="cSymbol"></param>
        /// <returns></returns>
        public string GetDwordAddress()
        {
            int iAddress = this.AddressMajor + 1;
            string sAddress = this.AddressHeader + iAddress.ToString();
            if (this.CheckAddressHexa(sAddress))
            {
                string sHexa = string.Format("{0:x}", iAddress);
                sAddress = this.AddressHeader + sHexa;
            }

            return sAddress;
        }

        public object Clone()
        {
            CDDEASymbol cSymbol = new CDDEASymbol();
            cSymbol.Key = m_sKey;
            cSymbol.DataType = m_emDataType;
            cSymbol.PLCAddressType = m_emPLC_AddressType;
            cSymbol.Address = m_sAddress;
            cSymbol.AddressHeadRemainder = m_sAddressHeadRemainder;
            cSymbol.AddressHeader = m_sAddressHeader;
            cSymbol.AddressMajor = m_iAddressMajor;
            cSymbol.AddressMinor = m_iAddressMinor;
            cSymbol.BitCollectNumber = m_iBitCollectNum;
            cSymbol.BaseAddress = m_sAddedBaseAddress;
            cSymbol.Mask = m_uiMask;
            cSymbol.ReadBitHeader = m_emReadBitHeader;

            cSymbol.IndexNote = m_sIndexNote;
            cSymbol.IndexAddressNumber = m_iIndexAddressNumber;
            cSymbol.IndexHeader = m_sIndexHeader;
            cSymbol.IndexType = m_emIndexType;

            cSymbol.AddressCount = m_iAddresCount;
            cSymbol.CollectUse = m_bCollectUse;
            cSymbol.DWordSecondAddress = m_sDWordSecondAddress;

            return cSymbol;
        }

        #endregion


        #region Protected Method

        /// <summary>
        /// Key생성 Address를 넣는데 고유해야함.("."나올 시에는 "_"처리)
        /// </summary>
        /// <param name="sAddressName"></param>
        /// <returns></returns>
        protected string CreateKey(string sAddressName)
        {
            string sResult = "[CH_DV]" + sAddressName;

            if (sResult.Contains("."))
            {
                sResult = sResult.Replace('.', '_');
            }

            return sResult;
        }

        /// <summary>
        /// Header Address를 보고 Bit인지 Word인지 판단
        /// </summary>
        /// <param name="sSymName"></param>
        /// <returns></returns>
        protected bool CheckSymbolBit(string sSymName)
        {
            try
            {
                bool bBitOk = false;
                int iData = 0;

                string sResult = string.Empty;

                if (sSymName.Length < 2)
                {
                    sResult = sSymName.Substring(0, 1);
                    if (int.TryParse(sResult, out iData))
                        return false;
                }


                //Dot가 있으면 무조건 비트.
                if ((sSymName.Contains(".")) && (!bBitOk))
                {
                    bBitOk = true;
                    return bBitOk;
                }

                string[] sBitArr = { "B", "M", "X", "Y", "L", "F", "V", "S" };
                string[] sBitTwoArr = { "SB", "FX", "FY", "SM" };

                sResult = sSymName.Substring(0, 2);

                string sIndex = sSymName.Substring(2, sSymName.Length - 2);
                if (sResult == "ST" || sResult == "SD" || sResult == "SW" || sResult == "FD")
                    return false;
                if (sIndex.Contains("Z"))
                    return false;
                for (int i = 0; i < sBitTwoArr.Length; i++)
                {
                    if (sResult == sBitTwoArr[i])
                    {
                        bBitOk = true;
                        break;
                    }
                }


                if (!bBitOk)
                {
                    sResult = sSymName.Substring(0, 1);
                    for (int i = 0; i < sBitArr.Length; i++)
                    {
                        if (sResult == sBitArr[i])
                        {
                            bBitOk = true;
                            break;
                        }
                    }

                }

                return bBitOk;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", ex.InnerException);
            }
        }

        /// <summary>
        /// 심볼 분리하기 Header, Address Number, Dot값 중 1개리턴
        /// </summary>
        /// <param name="sSymName">Symbol 1ea </param>
        /// <param name="emSymDiviType">분리 타입지정</param>
        /// <returns></returns>
        protected string DivideAddress(string sSymName, EMAddressDivisionTypeMS emSymDiviType)
        {
            string sResult = sSymName.Substring(0, 2);
            string[] sOneSize = { "B", "M", "X", "Y", "S", "L", "F", "V", "D", "W", "T", "C", "Z", "R" };
            string[] sTwoSize = { "ZR", "SM", "SB", "SW", "SD", "DX", "DY", "FX", "FY", "ST", "FD" };

            bool bFind = false;
            try
            {
                for (int i = 0; i < sTwoSize.Length; i++)
                {
                    if (sResult == sTwoSize[i])
                    {
                        bFind = true;
                        string[] split = null;

                        if (emSymDiviType != EMAddressDivisionTypeMS.Header)
                        {
                            sResult = sSymName.Substring(2, sSymName.Length - 2);
                            if (sResult.Contains("."))
                            {
                                split = sResult.Split('.');
                                sResult = split[0];
                            }
                            if (emSymDiviType == EMAddressDivisionTypeMS.DotNumber)
                                sResult = split[1];
                        }
                        break;
                    }
                }

                if (!bFind)
                {
                    sResult = sSymName.Substring(0, 1);
                    for (int i = 0; i < sOneSize.Length; i++)
                    {
                        if (sResult == sOneSize[i])
                        {
                            bFind = true;
                            string[] split = null;
                            if (emSymDiviType != EMAddressDivisionTypeMS.Header)
                            {
                                sResult = sSymName.Substring(1, sSymName.Length - 1);
                                if (sResult.Contains("."))
                                {
                                    split = sResult.Split('.');
                                    sResult = split[0];

                                }
                                if (emSymDiviType == EMAddressDivisionTypeMS.DotNumber)
                                    sResult = split[1];
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                string s = string.Format("Function(SymbolDivision) 변환 안되는 심볼 : {0} ", sSymName);
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine(s);
            }
            if (!bFind)
                return string.Empty;
            return sResult;
        }

        protected void CreateSymbolFromTag(CTag cTag)
        {
            m_sKey = cTag.Key;
            m_iAddresCount = cTag.Size;
            CreateMelsecDDEASymbol(cTag.Address);
        }

        #endregion
    }
}
