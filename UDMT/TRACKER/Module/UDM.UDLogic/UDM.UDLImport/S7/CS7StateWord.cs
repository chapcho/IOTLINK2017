using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDLImport
{
    public class CS7StateWord
    {
        protected bool m_bBR = false;
        protected bool m_bCC1 = false;
        protected bool m_bCC0 = false;
        protected bool m_bOV = false;
        protected bool m_bOS = false;
        protected bool m_bOR = false;
        protected bool m_bSTA = false;
        protected bool m_bRLO = false;
        protected bool m_bFC = true;

        protected string m_sACCU1 = string.Empty;
        protected string m_sACCU2 = string.Empty;

        protected string m_sAR1 = string.Empty;
        protected string m_sAR2 = string.Empty;

        #region Intialize/Dispose

        #endregion

        #region Public Properties

        public bool BR
        {
            get { return m_bBR; }
            set { m_bBR = value; }
        }

        public bool CC1
        {
            get { return m_bCC1; }
            set { m_bCC1 = value; }
        }

        public bool CC0
        {
            get { return m_bCC0; }
            set { m_bCC0 = value; }
        }

        public bool OV
        {
            get { return m_bOV; }
            set { m_bOV = value; }
        }

        public bool OS
        {
            get { return m_bOS; }
            set { m_bOS = value; }
        }

        public bool OR
        {
            get { return m_bOR; }
            set { m_bOR = value; }
        }

        public bool STA
        {
            get { return m_bSTA; }
            set { m_bSTA = value; }
        }

        public bool RLO
        {
            get { return m_bRLO; }
            set { m_bRLO = value; }
        }

        public bool FC
        {
            get { return m_bFC; }
            set { m_bFC = value; }
        }

        public string ACCU1
        {
            get { return m_sACCU1; }
            set { m_sACCU1 = value; }
        }

        public string ACCU2
        {
            get { return m_sACCU2; }
            set { m_sACCU2 = value; }
        }

        public string AR1
        {
            get { return m_sAR1; }
            set { m_sAR1 = value; }
        }

        public string AR2
        {
            get { return m_sAR2; }
            set { m_sAR2 = value; }
        }

        public int STW
        {
            get { return GetSTW(); }
            set { SetSTW(value); }
        }

        #endregion

        #region Public MethodS

        public void ResetStateWord()
        {
            m_bBR = false;
            m_bCC1 = false;
            m_bCC0 = false;
            m_bOV = false;
            m_bOS = false;
            m_bOR = false;
            m_bSTA = false;
            m_bRLO = false;
            m_bFC = true;

            m_sACCU1 = string.Empty;
            m_sACCU2 = string.Empty;
            m_sAR1 = string.Empty;
            m_sAR2 = string.Empty;
        }

        public void ValueLoad(string sValue)
        {
            if (m_sACCU1 == string.Empty)
                m_sACCU1 = sValue;
            else
            {
                m_sACCU2 = m_sACCU1;
                m_sACCU1 = sValue;
            }
        }

        public void ResetLoadValue()
        {
            m_sACCU1 = string.Empty;
            m_sACCU2 = string.Empty;
        }

        public void ChangeAR()
        {
            string sTemp = m_sAR1;
            m_sAR1 = m_sAR2;
            m_sAR2 = sTemp;
        }

        public void ChangeACCU()
        {
            string sTemp = m_sACCU1;
            m_sACCU1 = m_sACCU2;
            m_sACCU2 = sTemp;
        }

        #endregion

        #region Private Metheds

        private int GetSTW()
        {
            int iTemp = 0;

            byte[] bBytes = new byte[2];

            bBytes[0] = Set_bit(bBytes[0], 1, m_bFC);
            bBytes[0] = Set_bit(bBytes[0], 2, m_bRLO);
            bBytes[0] = Set_bit(bBytes[0], 3, m_bSTA);
            bBytes[0] = Set_bit(bBytes[0], 4, m_bOR);
            bBytes[0] = Set_bit(bBytes[0], 5, m_bOS);
            bBytes[0] = Set_bit(bBytes[0], 6, m_bOV);
            bBytes[0] = Set_bit(bBytes[0], 7, m_bCC0);
            bBytes[0] = Set_bit(bBytes[0], 8, m_bCC1);
            bBytes[1] = Set_bit(bBytes[1], 1, m_bBR);

            iTemp = BitConverter.ToInt16(bBytes, 0);
            return iTemp;
        }
        
        private void SetSTW(int value)
        {
            byte[] bBytes = BitConverter.GetBytes(value);

            m_bFC = Get_bit(bBytes[0], 1);
            m_bRLO = Get_bit(bBytes[0], 2);
            m_bSTA = Get_bit(bBytes[0], 3);
            m_bOR = Get_bit(bBytes[0], 4);
            m_bOS = Get_bit(bBytes[0], 5);
            m_bOV = Get_bit(bBytes[0], 6);
            m_bCC0 = Get_bit(bBytes[0], 7);
            m_bCC1 = Get_bit(bBytes[0], 8);
            m_bBR = Get_bit(bBytes[1], 1);
        }

        private byte Set_bit(byte data,int index,bool flag)
        {
            if (index <= 8 && index >= 1)
            {
                int v = index < 2 ? index : (2 << (index - 2));
                return flag ? (byte)(data | v) : (byte)(data & ~v);
            }
            else
                return data;
        }

        private bool Get_bit(byte data, int index)
        {
            bool bValue = false;

            if(index<=8 && index>=1)
            {
                int test = index < 2 ? index : (2 << (index - 2));

                int v = (byte)(data & test);

                if (index == 1 && v == 1)
                    bValue = true;
                else if (index == 2 && v == 2)
                    bValue = true;
                else if (index == 3 && v == 4)
                    bValue = true;
                else if (index == 4 && v == 8)
                    bValue = true;
                else if (index == 5 && v == 16)
                    bValue = true;
                else if (index == 6 && v == 32)
                    bValue = true;
                else if (index == 7 && v == 64)
                    bValue = true;
                else if (index == 8 && v == 128)
                    bValue = true;
            }
            
            return bValue;
        }

        #endregion
    }    
}
