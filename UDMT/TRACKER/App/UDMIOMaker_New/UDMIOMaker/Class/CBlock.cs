using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CBlock
    {
        private string m_sBlockName = string.Empty;
        private bool m_bHexa = false;
        private int m_iMaximumLimit = -1;
        private string m_sChannel = string.Empty;
        CBlockUnitS m_cBlockUnitS = new CBlockUnitS();
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;


        #region Initialize/Dispose

        public CBlock()
        {
            
        }

        public CBlock(string sName, int iMaximumLimit, bool bHexa, string sChannel, EMPLCMaker emPLCMaker)
        {
            m_sBlockName = sName;
            m_iMaximumLimit = iMaximumLimit;
            m_bHexa = bHexa;
            m_sChannel = sChannel;
            m_emPLCMaker = emPLCMaker;

            CreateBlockUnitS();
        }

        #endregion

        #region Properties


        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker;}
            set { m_emPLCMaker = value; }
        }

        public string BlockName
        {
            get { return m_sBlockName;}
            set { m_sBlockName = value; }
        }

        public bool IsHexa
        {
            get { return m_bHexa; }
            set { m_bHexa = value; }
        }

        public int MaximumLimit
        {
            get { return m_iMaximumLimit; }
            set { m_iMaximumLimit = value; }
        }

        public CBlockUnitS UnitS
        {
            get { return m_cBlockUnitS; }
            set { m_cBlockUnitS = value; }
        }

        #endregion

        #region Public Methods

        public string GetFirstBlockUnit()
        {
            string sFirst = string.Empty;

            List<CBlockUnit> lstUnit = m_cBlockUnitS.Values.Where(x => x.IsUsed).ToList();

            if (lstUnit.Count != 0)
            {
                sFirst = lstUnit.First().AddressRange;

                if (m_sBlockName.Equals("D"))
                    sFirst = sFirst.Substring(0, sFirst.Length - 1);
                if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                {
                    if (m_sBlockName.Equals("T") || m_sBlockName.Equals("C") || m_sBlockName.Equals("DB"))
                        sFirst = sFirst.Replace(".", string.Empty);
                }
            }

            lstUnit.Clear();
            lstUnit = null;

            return sFirst;
        }

        public string GetLastBlockUnit()
        {
            string sLast = string.Empty;

            List<CBlockUnit> lstUnit = m_cBlockUnitS.Values.Where(x => x.IsUsed).ToList();

            if (lstUnit.Count != 0)
            {
                sLast = lstUnit.Last().AddressRange;

                if (m_sBlockName.Equals("D"))
                    sLast = sLast.Substring(0, sLast.Length - 1);

                if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                {
                    if (m_sBlockName.Equals("T") || m_sBlockName.Equals("C") || m_sBlockName.Equals("DB"))
                        sLast = sLast.Replace(".", string.Empty);
                }
            }

            lstUnit.Clear();
            lstUnit = null;

            return sLast;
        }

        public int GetLastBlockRangeIndex()
        {
            int iIndex = -1;

            List<CBlockUnit> lstUnit = m_cBlockUnitS.Values.Where(x => x.IsUsed).ToList();

            if (lstUnit.Count != 0)
                iIndex = lstUnit.Last().RangeIndex;

            lstUnit.Clear();
            lstUnit = null;

            return iIndex;
        }


        #endregion

        #region Private Methods

        private void CreateBlockUnitS()
        {

            CBlockUnit cUnit = null;
            for (int i = 0; i <= m_iMaximumLimit; i++)
            {
                if(m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    cUnit = new CBlockUnit(i, m_sBlockName, CUtil.ConvertMelsecAddressRange(i, m_bHexa), m_sChannel, m_bHexa, m_emPLCMaker);
                else if (m_emPLCMaker.Equals(EMPLCMaker.Siemens))
                    cUnit = new CBlockUnit(i, m_sBlockName, CUtil.ConvertSiemensAddressRange(i), m_sChannel, m_bHexa, m_emPLCMaker);
                else if (m_emPLCMaker.Equals(EMPLCMaker.Rockwell))
                    cUnit = new CBlockUnit(i, m_sBlockName, CUtil.ConvertABAddressRange(i), m_sChannel, m_bHexa, m_emPLCMaker);
                else if(m_emPLCMaker.Equals(EMPLCMaker.LS))
                    cUnit = new CBlockUnit(i, m_sBlockName, CUtil.ConvertLSAddressRange(i), m_sChannel, m_bHexa, m_emPLCMaker);

                if (!m_cBlockUnitS.ContainsKey(i))
                    m_cBlockUnitS.Add(i, cUnit);
            }
        }

        #endregion

    }
}
