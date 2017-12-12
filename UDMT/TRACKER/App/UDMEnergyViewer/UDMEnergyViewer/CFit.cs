using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMEnergyViewer
{
    public class CFit
    {
        private CTag m_cTag = null;
        private DateTime m_dtPLCFrom = DateTime.MinValue;
        private DateTime m_dtPLCTo = DateTime.MinValue;
        private DateTime m_dtEnergyFrom = DateTime.MinValue;
        private DateTime m_dtEnergyTo = DateTime.MinValue;
        private int m_iCycleIndex = -1;

        #region Properties

        public int Cycle
        {
            get { return m_iCycleIndex; }
            set { m_iCycleIndex = value; }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public string Address
        {
            get { return m_cTag.Address; }
        }

        public string Description
        {
            get { return m_cTag.Description; }
        }

        public int Fit
        {
            get { return GetFit(); }
        }

        public int ErrorRange
        {
            get { return GetErrorRange(); }
        }

        public int Tolerance
        {
            get { return GetTolerance(); }
        }

        public DateTime PLCFrom
        {
            set { m_dtPLCFrom = value; }
        }

        public DateTime PLCTo
        {
            set { m_dtPLCTo = value; }
        }

        public DateTime EnergyFrom
        {
            set { m_dtEnergyFrom = value; }
        }

        public DateTime EnergyTo
        {
            set { m_dtEnergyTo = value; }
        }

        #endregion

        #region Private Methods

        private int GetErrorRange()
        {
            int iErrorRange = -1;

            int iFirstRange = Math.Abs((int)m_dtEnergyFrom.Subtract(m_dtPLCFrom).TotalMilliseconds);
            int iSecondRange = Math.Abs((int)m_dtEnergyTo.Subtract(m_dtPLCTo).TotalMilliseconds);

            iErrorRange = Math.Abs(iFirstRange - iSecondRange);

            return iErrorRange;
        }

        private int GetFit()
        {
            double dFit = -1;

            double dtPLCSpan = m_dtPLCTo.Subtract(m_dtPLCFrom).TotalMilliseconds;
            double dtEnergySpan = m_dtEnergyTo.Subtract(m_dtEnergyFrom).TotalMilliseconds;

            dFit = dtPLCSpan / dtEnergySpan * 100;

            return (int)dFit;
        }

        private int GetTolerance()
        {
            int iTolerance = -1;

            int iFirstRange = Math.Abs((int)m_dtEnergyFrom.Subtract(m_dtPLCFrom).TotalMilliseconds);
            int iSecondRange = Math.Abs((int)m_dtEnergyTo.Subtract(m_dtPLCTo).TotalMilliseconds);

            iTolerance = iFirstRange > iSecondRange ? iFirstRange : iSecondRange;

            return iTolerance;
        }

        #endregion
    }
}
