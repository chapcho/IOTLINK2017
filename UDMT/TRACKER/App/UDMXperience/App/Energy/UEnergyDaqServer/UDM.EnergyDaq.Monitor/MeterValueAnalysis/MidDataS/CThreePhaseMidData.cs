using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public class CThreePhaseMidData
    {
        protected float m_nVoltageA = 0f;
        protected float m_nVoltageB = 0f;
        protected float m_nVoltageC = 0f;
        protected float m_nVoltageAB = 0f;
        protected float m_nVoltageBC = 0f;
        protected float m_nVoltageCA = 0f;
        protected float m_nCurrentA = 0f;
        protected float m_nCurrentB = 0f;
        protected float m_nCurrentC = 0f;
        protected float m_nActiveA = 0f;
        protected float m_nActiveB = 0f;
        protected float m_nActiveC = 0f;
        protected float m_nActiveTotal = 0f;
        protected float m_nReactiveA = 0f;
        protected float m_nReactiveB = 0f;
        protected float m_nReactiveC = 0f;
        protected float m_nReactiveTotal = 0f;
        protected float m_nApparentA = 0f;
        protected float m_nApparentB = 0f;
        protected float m_nApparentC = 0f;
        protected float m_nApparentTotal = 0f;
        protected float m_nPFa = 0f;
        protected float m_nPFb = 0f;
        protected float m_nPFc = 0f;
        protected float m_nTotalPF = 0f;
        protected float m_nFrequency = 0f;
        protected int m_itotalKwh = 0;
        protected int m_iTotalKVARh = 0;


        #region Public Properties

        public float VoltageA
        {
            get { return m_nVoltageA; }
            set { m_nVoltageA = value; }
        }

        public float VoltageB
        {
            get { return m_nVoltageB; }
            set { m_nVoltageB = value; }
        }

        public float VoltageC
        {
            get { return m_nVoltageC; }
            set { m_nVoltageC = value; }
        }

        public float VoltageAB
        {
            get { return m_nVoltageAB; }
            set { m_nVoltageAB = value; }
        }

        public float VoltageBC
        {
            get { return m_nVoltageBC; }
            set { m_nVoltageBC = value; }
        }

        public float VoltageCA
        {
            get { return m_nVoltageCA; }
            set { m_nVoltageCA = value; }
        }

        public float CurrentA
        {
            get { return m_nCurrentA; }
            set { m_nCurrentA = value; }
        }

        public float CurrentB
        {
            get { return m_nCurrentB; }
            set { m_nCurrentB = value; }
        }

        public float CurrentC
        {
            get { return m_nCurrentC; }
            set { m_nCurrentC = value; }
        }

        public float ActiveA
        {
            get { return m_nActiveA; }
            set { m_nActiveA = value; }
        }

        public float ActiveB
        {
            get { return m_nActiveB; }
            set { m_nActiveB = value; }
        }

        public float ActiveC
        {
            get { return m_nActiveC; }
            set { m_nActiveC = value; }
        }

        public float ActiveTotal
        {
            get { return m_nActiveTotal; }
            set { m_nActiveTotal = value; }
        }

        public float ReactiveA
        {
            get { return m_nReactiveA; }
            set { m_nReactiveA = value; }
        }

        public float ReactiveB
        {
            get { return m_nReactiveB; }
            set { m_nReactiveB = value; }
        }

        public float ReactiveC
        {
            get { return m_nReactiveC; }
            set { m_nReactiveC = value; }
        }

        public float ReactiveTotal
        {
            get { return m_nReactiveTotal; }
            set { m_nReactiveTotal = value; }
        }

        public float ApparentA
        {
            get { return m_nApparentA; }
            set { m_nApparentA = value; }
        }

        public float ApparentB
        {
            get { return m_nApparentB; }
            set { m_nApparentB = value; }
        }

        public float ApparentC
        {
            get { return m_nApparentC; }
            set { m_nApparentC = value; }
        }

        public float ApparentTotal
        {
            get { return m_nApparentTotal; }
            set { m_nApparentTotal = value; }
        }

        public float PFa
        {
            get { return m_nPFa; }
            set { m_nPFa = value; }
        }

        public float PFb
        {
            get { return m_nPFb; }
            set { m_nPFb = value; }
        }

        public float PFc
        {
            get { return m_nPFc; }
            set { m_nPFc = value; }
        }

        public float TotalPF
        {
            get { return m_nTotalPF; }
            set { m_nTotalPF = value; }
        }

        public float Frequency
        {
            get { return m_nFrequency; }
            set { m_nFrequency = value; }
        }

        public int TotalKwh
        {
            get { return m_itotalKwh; }
            set { m_itotalKwh = value; }
        }

        public int TotalKvarh
        {
            get { return m_iTotalKVARh; }
            set { m_iTotalKVARh = value; }
        }


        #endregion
    }
}
