using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CVerifTag
    {
        private string m_sKey = string.Empty;
        private string m_sAddress = string.Empty;
        private string m_sName = string.Empty;
        private string m_sDescription = string.Empty;
        private EMDataType m_emDataType = EMDataType.None;
        private string m_sPLCName = string.Empty;
        private EMUsedLogic m_emUsedLogic = EMUsedLogic.NotUsed;
        private EMSymbolRole m_emSymbolRole = EMSymbolRole.NotUsed;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;
        private string m_sGroupKey = string.Empty;

        private bool m_bDoubleCoil = false;

        private List<string> m_lstDescParse = new List<string>(); 

        #region Initialize/Dispose

        #endregion


        #region Properties

        public bool IsDoubleCoil
        {
            get { return m_bDoubleCoil;}
            set { m_bDoubleCoil = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker;}
            set { m_emPLCMaker = value; }
        }

        public EMDataType DataType
        {
            get { return m_emDataType;}
            set { m_emDataType = value; }
        }

        public string GroupKey
        {
            get { return m_sGroupKey;}
            set { m_sGroupKey = value; }
        }

        public string Key
        {
            get { return m_sKey;}
            set { m_sKey = value; }
        }

        public string Address
        {
            get { return m_sAddress;}
            set { m_sAddress = value; }
        }

        public string Name
        {
            get { return m_sName;}
            set { m_sName = value; }
        }

        public string Description
        {
            get { return m_sDescription;}
            set
            {
                m_sDescription = value;
                SetDescParseS();
            }
        }

        public string Channel
        {
            get { return m_sPLCName;}
            set { m_sPLCName = value; }
        }

        public EMUsedLogic UsedLogic
        {
            get { return m_emUsedLogic; }
            set { m_emUsedLogic = value; }
        }

        public EMSymbolRole SymbolRole
        {
            get { return m_emSymbolRole;}
            set { m_emSymbolRole = value; }
        }

        #endregion

        #region Public Methods

        public bool IsDescContain(List<string> HMIParseS, bool bInsertBit)
        {
            bool bOK = true;

            if (HMIParseS.Count == 0)
                return false;

            foreach (string sParse in HMIParseS)
            {
                if (!bInsertBit)
                {
                    if (!m_lstDescParse.Contains(sParse))
                    {
                        bOK = false;
                        break;
                    }
                }
                else
                {
                    if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_emPLCMaker.Equals(EMPLCMaker.LS))
                    {
                        if (!m_sDescription.Contains(sParse))
                        {
                            bOK = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!m_sName.Contains(sParse))
                        {
                            bOK = false;
                            break;
                        }
                    }
                }
            }

            return bOK;
        }

        #endregion


        #region Private Methods

        private void SetDescParseS()
        {
            if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (m_sDescription == string.Empty)
                    return;

                m_lstDescParse = m_sDescription.Split('_').ToList();
            }
            else
            {
                if (m_sName == string.Empty)
                    return;

                m_lstDescParse = m_sName.Split('_').ToList();
            }
        }


        #endregion

    }
}
