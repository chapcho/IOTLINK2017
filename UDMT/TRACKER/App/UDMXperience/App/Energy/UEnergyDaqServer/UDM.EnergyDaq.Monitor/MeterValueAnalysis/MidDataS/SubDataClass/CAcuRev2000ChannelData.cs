using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public class CAcuRev2000ChannelData
    {
        protected int m_iChannelNum = 0;
        protected float m_dCurrent = (Single)(-0.1);
        protected float m_dRealPower = (Single)(-0.1);
        protected float m_dReactivePower = (Single)(-0.1);
        protected float m_dApparentPower = (Single)(-0.1);
        protected float m_dPowerFactor = (Single)(-0.1);
        protected float m_dLoadNature = (Single)(-0.1);

        #region Public Properties

        public int ChannelNum
        {
            get { return m_iChannelNum; }
            set { m_iChannelNum = value; }
        }

        public float Current
        {
            get { return m_dCurrent; }
            set { m_dCurrent = value; }
        }

        public float RealPower
        {
            get { return m_dRealPower; }
            set { m_dRealPower = value; }
        }

        public float ReactivePower
        {
            get { return m_dReactivePower; }
            set { m_dReactivePower = value; }
        }

        public float ApparentPower
        {
            get { return m_dApparentPower; }
            set { m_dApparentPower = value; }
        }

        public float PowerFactor
        {
            get { return m_dPowerFactor; }
            set { m_dPowerFactor = value; }
        }

        public float LoadNature
        {
            get { return m_dLoadNature; }
            set { m_dLoadNature = value; }
        }
        #endregion
    }
}
