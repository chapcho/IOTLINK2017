using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public class CSinglePhaseMidData
    {
        protected float m_nVoltage = 0f;
        protected float m_nCurrent = 0f;
        protected float m_nActive = 0f;
        protected float m_nReactive = 0f;
        protected float m_nApparent = 0f;
        protected float m_nPF = 0f;
        protected float m_nFrequency = 0f;
        protected int m_itotalKwh = 0;
        protected int m_iTotalKVARh = 0;

        #region Public Properties

        public float Voltage
        {
            get { return m_nVoltage; }
            set { m_nVoltage = value; }
        }

        public float Current
        {
            get { return m_nCurrent; }
            set { m_nCurrent = value; }
        }

        public float Active
        {
            get { return m_nActive; }
            set { m_nActive = value; }
        }

        public float Reactive
        {
            get { return m_nReactive; }
            set { m_nReactive = value; }
        }

        public float Apparent
        {
            get { return m_nApparent; }
            set { m_nApparent = value; }
        }

        public float PF
        {
            get { return m_nPF; }
            set { m_nPF = value; }
        }

        public float Frequency
        {
            get { return m_nFrequency; }
            set { m_nFrequency = value; }
        }

        public int TotalKwH
        {
            get { return m_itotalKwh; }
            set { m_itotalKwh = value; }
        }

        public int TotalKvarH
        {
            get { return m_iTotalKVARh; }
            set { m_iTotalKVARh = value; }
        }
        #endregion
    }
}
