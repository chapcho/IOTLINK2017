using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CBlockUnit
    {
        private int m_iBlockIndex = -1;
        private string m_sAddressHeader = string.Empty;
        private string m_sAddressRange = string.Empty;
        private string m_sChannel = string.Empty;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        //Module Information
        private string m_sIOType = string.Empty;
        private bool m_bInputType = false;
        private bool m_bOutputType = false;
        private bool m_bMixType = false;
        private string m_sModule = string.Empty;
        private string m_sDescription = string.Empty;
        private string m_sNetwork = string.Empty;
        private string m_sSlot = string.Empty;

        private bool m_bForceAssign = false;

        private bool m_bHexa = false;
        private bool m_bUsed = false;
        private bool m_bFullUsed = false;
        private bool m_bDelete = false;
        private bool m_bInsert = false;

        private int m_iMaxItemLimit = -1;
        private CTagItemS m_cTagItemS = new CTagItemS();

        [NonSerialized] private string m_sWordAddress = string.Empty;
        [NonSerialized] private string m_sTempKey = string.Empty;
        [NonSerialized] private bool m_bWordContain = false;

        #region Initialize/Dispose


        public CBlockUnit(int iBlockIndex, string sAddressHeader, string sAddressRange, string sChannel, bool bHexa, EMPLCMaker emPLCMaker)
        {
            m_iBlockIndex = iBlockIndex;
            m_sAddressHeader = sAddressHeader;
            m_sAddressRange = sAddressRange;
            m_sChannel = sChannel;
            m_bHexa = bHexa;
            m_emPLCMaker = emPLCMaker;

            SetMakerTagItemS();

            if(m_cTagItemS.Count != 0)
                m_cTagItemS.Sort((x, y) => string.Compare(x.Address, y.Address));
        }


        #endregion

        #region Properties

        public bool IsHexa
        {
            get { return m_bHexa; }
            set { m_bHexa = value; }
        }

        public bool IsForceAssigned
        {
            get { return m_bForceAssign;}
            set { m_bForceAssign = value; }
        }

        public int RangeIndex
        {
            get { return m_iBlockIndex;}
            set { m_iBlockIndex = value; }
        }

        public bool IsDelete
        {
            get { return m_bDelete;}
            set { m_bDelete = value; }
        }

        public string AddressHeader
        {
            get { return m_sAddressHeader;}
            set { m_sAddressHeader = value; }
        }

        public CTagItemS TagItemS
        {
            get { return m_cTagItemS;}
            set { m_cTagItemS = value; }
        }

        public int MaximumItemLimit
        {
            get { return m_iMaxItemLimit;}
            set { m_iMaxItemLimit = value; }
        }

        public string AddressRange
        {
            get { return m_sAddressRange;}
            set { m_sAddressRange = value; }
        }

        public string Module
        {
            get { return m_sModule;}
            set { m_sModule = value; }
        }

        public string Description
        {
            get { return m_sDescription;}
            set { m_sDescription = value; }
        }

        public string Network
        {
            get { return m_sNetwork;}
            set { m_sNetwork = value; }
        }

        public string Slot
        {
            get { return m_sSlot; }
            set { m_sSlot = value; }
        }

        public string IOType
        {
            get { return m_sIOType; }
            set { m_sIOType = value; }
        }


        /// <summary>
        /// Input Module
        /// </summary>
        public bool IsInputType
        {
            get { return m_bInputType;}
            set { m_bInputType = value; }
        }

        /// <summary>
        /// Mix Module
        /// </summary>
        public bool IsMixType
        {
            get { return m_bMixType;}
            set { m_bMixType = value; }
        }

        /// <summary>
        /// Output Module
        /// </summary>
        public bool IsOutputType
        {
            get { return m_bOutputType;}
            set { m_bOutputType = value; }
        }

        public bool IsUsed
        {
            get { return m_bUsed;}
            set { m_bUsed = value; }
        }

        public bool IsFullUsed
        {
            get { return m_bFullUsed;}
            set { m_bFullUsed = value; }
        }

        public bool IsInsertArea
        {
            get { return m_bInsert;}
            set { m_bInsert = value; }
        }


        #endregion

        #region Public Methods

        public CBlockUnit Clone()
        {
            CBlockUnit cUnit = new CBlockUnit(m_iBlockIndex, m_sAddressHeader, m_sAddressRange, m_sChannel, m_bHexa, m_emPLCMaker);

            cUnit.IOType = m_sIOType;
            cUnit.IsInputType = m_bInputType;
            cUnit.IsOutputType = m_bOutputType;
            cUnit.IsMixType = m_bMixType;
            cUnit.Module = m_sModule;
            cUnit.Description = m_sDescription;
            cUnit.Network = m_sNetwork;
            cUnit.Slot = m_sSlot;

            cUnit.IsForceAssigned = m_bForceAssign;
            cUnit.IsUsed = m_bUsed;
            cUnit.IsFullUsed = m_bFullUsed;
            cUnit.IsDelete = m_bDelete;
            cUnit.IsInsertArea = m_bInsert;
            cUnit.MaximumItemLimit = m_iMaxItemLimit;

            return cUnit;
        }

        #endregion

        #region Private Methods

        private void SetMakerTagItemS()
        {
            try
            {
                if (m_sAddressHeader.Equals("IO"))
                    return;

                if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                    SetSiemensPLC();
                else if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
                    SetABPLC();
                else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    SetMelsecPLC();
                else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                    SetLSPLC();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSPLC()
        {
            if (m_sAddressHeader.Equals("T") || m_sAddressHeader.Equals("C") || m_sAddressHeader.Contains("N"))
            {
                m_iMaxItemLimit = 10;
                m_sAddressRange = m_sAddressRange.Remove(0, 1);
            }
            else
                m_iMaxItemLimit = 16;

            if (SetLSTagItemS())
            {
                if (m_cTagItemS.Where(x => x.IsInsertTag == true).Count() > 0)
                    m_bInsert = true;

                m_bUsed = true;

                if (m_bWordContain)
                {
                    if (m_cTagItemS.Count - 1 == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }
                else
                {
                    if (m_cTagItemS.Count == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }

               // if(!m_sAddressHeader.Equals("N") && !m_sAddressHeader.Equals("T") && !m_sAddressHeader.Equals("C"))
                    SetLSEmptyTagItemS();
            }
        }


        private void SetMelsecPLC()
        {
            if (m_sAddressHeader.Equals("M") || m_sAddressHeader.Equals("L") || m_sAddressHeader.Contains("T") || m_sAddressHeader.Contains("C"))
                m_iMaxItemLimit = 10;
            else
                m_iMaxItemLimit = 16;

            if (SetMelsecTagItemS())
            {
                if (m_cTagItemS.Where(x => x.IsInsertTag == true).Count() > 0)
                    m_bInsert = true;

                m_bUsed = true;

                if (m_bWordContain)
                {
                    if (m_cTagItemS.Count - 1 == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }
                else
                {
                    if (m_cTagItemS.Count == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }

                SetMelsecEmptyTagItemS();
            }
        }

        private void SetSiemensPLC()
        {
            if (m_sAddressHeader.Equals("I") || m_sAddressHeader.Equals("Q") || m_sAddressHeader.Equals("M"))
                m_iMaxItemLimit = 8;
            else
                m_iMaxItemLimit = 10;

            if (SetSiemensTagItemS())
            {
                if (m_cTagItemS.Where(x => x.IsInsertTag == true).Count() > 0)
                    m_bInsert = true;

                m_bUsed = true;

                if (m_cTagItemS.Count == m_iMaxItemLimit)
                    m_bFullUsed = true;
                else
                    m_bFullUsed = false;

                SetSiemensEmptyTagItemS();
            }
        }

        private void SetABPLC()
        {
            m_iMaxItemLimit = 32;

            if (SetABTagItemS())
            {
                m_bUsed = true;

                if (m_bWordContain)
                {
                    if (m_cTagItemS.Count - 1 == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }
                else
                {
                    if (m_cTagItemS.Count == m_iMaxItemLimit)
                        m_bFullUsed = true;
                    else
                        m_bFullUsed = false;
                }
            }
        }


        private void SetMelsecEmptyTagItemS()
        {
            string sAddress = string.Empty;
            CTagItem cItem;

            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetMelsecNextAddress(m_sAddressHeader, m_sAddressRange, i);
                if (!CheckContainTagItemS(sAddress))
                {
                    cItem = new CTagItem();
                    cItem.Address = sAddress;
                    cItem.Key = string.Format("[{0}]{1}[1]", m_sChannel, sAddress);
                    cItem.Description = string.Empty;

                    if(m_sAddressHeader.Equals("T") || m_sAddressHeader.Equals("C"))
                        cItem.DataType = EMDataType.Word;
                    else
                        cItem.DataType = EMDataType.Bool;

                    m_cTagItemS.Add(cItem);
                }
            }
        }

        private void SetLSEmptyTagItemS()
        {
            string sAddress = string.Empty;
            CTagItem cItem;

            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetLSNextAddress(m_sAddressHeader, m_sAddressRange, i);

                if (!CheckContainTagItemS(sAddress))
                {
                    cItem = new CTagItem();
                    cItem.Address = sAddress;
                    cItem.Key = string.Format("[{0}]{1}[1]", m_sChannel, sAddress);
                    cItem.Description = string.Empty;
                    cItem.Name = string.Empty;

                    if (m_sAddressHeader.Equals("T") || m_sAddressHeader.Equals("C") || m_sAddressHeader.Equals("N"))
                        cItem.DataType = EMDataType.Word;
                    else
                        cItem.DataType = EMDataType.Bool;

                    m_cTagItemS.Add(cItem);
                }
            }
        }

        private void SetSiemensEmptyTagItemS()
        {
            string sAddress = string.Empty;
            CTagItem cItem;

            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetSiemensNextAddress(m_sAddressHeader, m_sAddressRange, i);
                if (!CheckContainTagItemS(sAddress))
                {
                    cItem = new CTagItem();
                    cItem.Address = sAddress;
                    cItem.Key = string.Format("[{0}]{1}[1]", m_sChannel, sAddress);
                    cItem.Description = string.Empty;

                    if (m_sAddressHeader.Equals("T"))
                        cItem.DataType = EMDataType.Timer;
                    else if (m_sAddressHeader.Equals("C"))
                        cItem.DataType = EMDataType.Counter;
                    else if(m_sAddressHeader.Equals("DB"))
                        cItem.DataType = EMDataType.Block;
                    else
                        cItem.DataType = EMDataType.Bool;

                    m_cTagItemS.Add(cItem);
                }
            }
        }

        private bool CheckContainTagItemS(string sAddress)
        {
            bool bOK = false;

            foreach (var who in m_cTagItemS)
            {
                if (who.Address == sAddress)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool SetSiemensTagItemS()
        {
            bool bOK = false;

            string sAddress = string.Empty;
            CTagItem cItem;
            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetSiemensNextAddress(m_sAddressHeader, m_sAddressRange, i);
                m_sTempKey = CUtil.CheckSiemensAddressExist(sAddress, m_sChannel);

                if (m_sTempKey != string.Empty)
                {
                    bOK = true;
                    cItem = CUtil.GetSiemensTagItem(sAddress, m_sTempKey);
                    m_cTagItemS.Add(cItem);
                }
            }

            return bOK;
        }

        private bool SetMelsecTagItemS()
        {
            bool bOK = false;

            string sAddress = string.Empty;
            CTagItem cItem;
            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetMelsecNextAddress(m_sAddressHeader, m_sAddressRange, i);
                m_sTempKey = CUtil.CheckMelsecAddressExist(sAddress, m_sChannel, m_sAddressHeader, m_bHexa);

                if (m_sTempKey != string.Empty)
                {
                    bOK = true;
                    cItem = CUtil.GetMelsecTagItem(sAddress, m_sTempKey);
                    m_cTagItemS.Add(cItem);
                }

                m_sWordAddress = CUtil.CheckMelsecWordAddressExist(m_sChannel, m_sAddressHeader, m_sAddressRange, m_bHexa);

                if (!m_bWordContain && m_sWordAddress != string.Empty)
                {
                    bOK = true;
                    m_sTempKey = string.Format("[{0}]{1}[1]", m_sChannel, m_sWordAddress);
                    cItem = CUtil.GetMelsecTagItem(m_sWordAddress, m_sTempKey);
                    m_cTagItemS.Add(cItem);

                    m_bWordContain = true;
                }
            }

            return bOK;
        }

        private bool SetLSTagItemS()
        {
            bool bOK = false;

            string sAddress = string.Empty;
            CTagItem cItem;
            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sAddress = CUtil.GetLSNextAddress(m_sAddressHeader, m_sAddressRange, i);
                m_sTempKey = CUtil.CheckLSAddressExist(sAddress, m_sChannel);

                if (m_sTempKey != string.Empty)
                {
                    bOK = true;
                    cItem = CUtil.GetLSTagItem(m_sTempKey);
                    m_cTagItemS.Add(cItem);
                }


                if (m_sAddressHeader.Equals("T") || m_sAddressHeader.Equals("C") || m_sAddressHeader.Contains("N"))
                    continue;

                m_sWordAddress = CUtil.CheckLSWordAddressExist(m_sChannel, m_sAddressHeader, m_sAddressRange);

                if (!m_bWordContain && m_sWordAddress != string.Empty)
                {
                    bOK = true;
                    m_sTempKey = m_sWordAddress;
                    cItem = CUtil.GetLSTagItem(m_sTempKey);
                    m_cTagItemS.Add(cItem);

                    m_bWordContain = true;
                }
            }

            return bOK;
        }

        private bool SetABTagItemS()
        {
            bool bOK = false;

            string sNormalAddress = string.Empty;
            string sAliasAddress = string.Empty;

            CTagItem cItem;
            for (int i = 0; i < m_iMaxItemLimit; i++)
            {
                sNormalAddress = CUtil.GetABNextNormalAddress(m_sAddressHeader, m_sAddressRange, i);
                sAliasAddress = CUtil.GetABNextAliasAddress(m_sAddressHeader, m_sAddressRange, i);
                m_sTempKey = CUtil.CheckABSymbolExist(sNormalAddress, sAliasAddress, m_sChannel);

                if (m_sTempKey != string.Empty)
                {
                    bOK = true;
                    cItem = CUtil.GetABTagItem(m_sTempKey);
                    m_cTagItemS.Add(cItem);
                }

                m_sWordAddress = CUtil.CheckABWordAddressExist(m_sChannel, m_sAddressHeader, m_sAddressRange);

                if (!m_bWordContain && m_sWordAddress != string.Empty)
                {
                    bOK = true;
                    m_sTempKey = m_sWordAddress;
                    cItem = CUtil.GetABTagItem(m_sTempKey);
                    m_cTagItemS.Add(cItem);

                    m_bWordContain = true;
                }
            }

            return bOK;
        }

        private void SetTagItem(CTagItem cItem)
        {
            string sAddress = cItem.Address;
            string sKey = string.Empty;
            string sIndex = string.Empty;
            string sTemp = string.Empty;
            int iValue = -1;

            sIndex = sAddress.Replace(m_sAddressHeader, string.Empty); //Header 제외 대문자 (자릿수 0포함)
            sKey = string.Format("[{0}]{1}{2}[1]", m_sChannel, m_sAddressHeader, sIndex);

            if (CheckTagItemExist(cItem, sKey))
                return;

            if (sAddress.Contains("."))
            {
                sTemp = sIndex.Split('.')[1];
                sIndex = sIndex.Split('.')[0];

                if (m_bHexa)
                {
                    iValue = Convert.ToInt32(sIndex, 16);
                    sKey = string.Format("[{0}]{1}{2}.{3}[1]", m_sChannel, m_sAddressHeader, iValue.ToString("X").ToUpper(), sTemp);
                }
                else
                {
                    iValue = Convert.ToInt32(sIndex);
                    sKey = string.Format("[{0}]{1}{2}.{3}[1]", m_sChannel, m_sAddressHeader, iValue.ToString().ToUpper(), sTemp);
                }
            }
            else
            {
                if (m_bHexa)
                {
                    iValue = Convert.ToInt32(sIndex, 16);
                    sKey = string.Format("[{0}]{1}{2}[1]", m_sChannel, m_sAddressHeader, iValue.ToString("X").ToUpper());
                }
                else
                {
                    iValue = Convert.ToInt32(sIndex);
                    sKey = string.Format("[{0}]{1}{2}[1]", m_sChannel, m_sAddressHeader, iValue.ToString().ToUpper());
                }
            }

            if (CheckTagItemExist(cItem, sKey))
                return;
        }

        private bool CheckTagItemExist(CTagItem cItem, string sKey)
        {
            bool bOK = false;

            if (CProjectManager.PLCTagS.ContainsKey(sKey))
            {
                cItem.Key = sKey;
                cItem.Description = CProjectManager.PLCTagS[sKey].Description;
                bOK = true;
            }

            return bOK;
        }

        #endregion
    }
}
