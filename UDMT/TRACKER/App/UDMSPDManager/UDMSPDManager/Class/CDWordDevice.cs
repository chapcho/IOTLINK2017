using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDMSPDManager
{
    public class CDWordDevice
    {
        #region Member Veriavles

        private string m_sReadMajor = "";
        private string m_sChannel = "";
        private string m_sReadAddress = "";
        private int m_iMajorNumber = 0;
        private CByteDevice m_cByte1 = new CByteDevice();
        private CByteDevice m_cByte2 = new CByteDevice();
        private CByteDevice m_cByte3 = new CByteDevice();
        private CByteDevice m_cByte4 = new CByteDevice();
        private int m_iCurrentValue = 0;

        #endregion


        #region Properties

        public int MajorNumber
        {
            get { return m_iMajorNumber; }
            set { m_iMajorNumber = value; }
        }

        public string ReadMajor
        {
            get { return m_sReadMajor; }
            set { m_sReadMajor = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public string ReadAddress
        {
            get { return m_sReadAddress; }
            set { m_sReadAddress = value; }
        }

        public CByteDevice Byte1
        {
            get { return m_cByte1; }
            set { m_cByte1 = value; }
        }

        public CByteDevice Byte2
        {
            get { return m_cByte2; }
            set { m_cByte2 = value; }
        }

        public CByteDevice Byte3
        {
            get { return m_cByte3; }
            set { m_cByte3 = value; }
        }

        public CByteDevice Byte4
        {
            get { return m_cByte4; }
            set { m_cByte4 = value; }
        }

        public int CurrentValue
        {
            get { return m_iCurrentValue; }
        }

        #endregion


        #region Private Method

        private byte SplitByte(int iPos, int iReadValue, byte nMask)
        {
            byte nResult = 0;

            if (iPos == 1)
                nResult = (byte)((iReadValue & 0xFF000000) >> 24);
            else if (iPos == 2)
                nResult = (byte)((iReadValue & 0x00FF0000) >> 16);
            else if (iPos == 3)
                nResult = (byte)((iReadValue & 0x0000FF00) >> 8);
            else
                nResult = (byte)((iReadValue & 0x000000FF));

            return (byte)(nResult & nMask);
        }

        private UDM.Log.CTimeLogS GetTimeLogSChangeTag(CByteDevice cBaseByte, byte nReadValue, DateTime dtTime)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            if (cBaseByte.CurrentValue != nReadValue)
            {
                cBaseByte.CurrentValue = nReadValue;
                int iValue = 0;
                foreach (CBitDevice cTag in cBaseByte.BitDeviceList)
                {
                    byte nValue = (byte)(nReadValue & (0x1 << cTag.MinorNumber));

                    if (nValue != 0) iValue = 1;
                    else iValue = 0;
                    if (cTag.CurrentValue != iValue)
                    {
                        cTag.CurrentValue = iValue;

                        //로그 생성
                        UDM.Log.CTimeLog cLog = new UDM.Log.CTimeLog();
                        cLog.Time = dtTime;
                        cLog.Key = cTag.Tag.Key;
                        cLog.Value = (int)iValue;
                        cLog.SValue = iValue.ToString();
                        cLogS.Add(cLog);
                    }
                }
            }
            return cLogS;
        }

        private UDM.Log.CTimeLogS GetTimeLogSAllTag(CByteDevice cBaseByte, byte nReadValue, DateTime dtTime)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            cBaseByte.CurrentValue = nReadValue;
            int iValue = 0;
            foreach (CBitDevice cTag in cBaseByte.BitDeviceList)
            {
                byte nValue = (byte)(nReadValue & (0x1 << cTag.MinorNumber));

                if (nValue != 0) iValue = 1;
                else iValue = 0;
                //if (cTag.CurrentValue != iValue)
                //{
                    cTag.CurrentValue = iValue;

                    //로그 생성
                    UDM.Log.CTimeLog cLog = new UDM.Log.CTimeLog();
                    cLog.Time = dtTime;
                    cLog.Key = cTag.Tag.Key;
                    cLog.Value = (int)iValue;
                    cLog.SValue = iValue.ToString();
                    cLogS.Add(cLog);
                //}
            }
            return cLogS;
        }

        #endregion


        #region Public Method

        public UDM.Log.CTimeLogS GetTimeLogSChangedTag(CTimeLog cLog)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            //sMsg = "";
            int iReadValue = cLog.Value;
            if (m_iCurrentValue == iReadValue)
                return cLogS;
            //sMsg = string.Format("O : {0} N: {1}\r\n", m_iCurrentValue, iReadValue);
            m_iCurrentValue = iReadValue;

            byte nData1 = SplitByte(1, m_iCurrentValue, m_cByte1.MaskValue);
            byte nData2 = SplitByte(2, m_iCurrentValue, m_cByte2.MaskValue);
            byte nData3 = SplitByte(3, m_iCurrentValue, m_cByte3.MaskValue);
            byte nData4 = SplitByte(4, m_iCurrentValue, m_cByte4.MaskValue);
            //sMsg += string.Format("B1 : {0} B2 : {1} B3 : {2} B4 : {3}", nData1, nData2, nData3, nData4);
            //값 분석을 통해 변경된 값은 TimeLog를 만들어 Return

            if (m_cByte1.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte1, nData1, cLog.Time));
            if (m_cByte2.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte2, nData2, cLog.Time));
            if (m_cByte3.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte3, nData3, cLog.Time));
            if (m_cByte4.Used) cLogS.AddRange(GetTimeLogSChangeTag(m_cByte4, nData4, cLog.Time));
            
            return cLogS;
        }

        public UDM.Log.CTimeLogS GetTimeLogSChangedTag(CTimeLog cLog, bool bAllTag)
        {
            UDM.Log.CTimeLogS cLogS = new UDM.Log.CTimeLogS();
            //sMsg = "";
            int iReadValue = cLog.Value;
            if (bAllTag == false && m_iCurrentValue == iReadValue)
                return cLogS;
            //sMsg = string.Format("O : {0} N: {1}\r\n", m_iCurrentValue, iReadValue);
            m_iCurrentValue = iReadValue;

            byte nData1 = SplitByte(1, m_iCurrentValue, m_cByte1.MaskValue);
            byte nData2 = SplitByte(2, m_iCurrentValue, m_cByte2.MaskValue);
            byte nData3 = SplitByte(3, m_iCurrentValue, m_cByte3.MaskValue);
            byte nData4 = SplitByte(4, m_iCurrentValue, m_cByte4.MaskValue);
            //sMsg += string.Format("B1 : {0} B2 : {1} B3 : {2} B4 : {3}", nData1, nData2, nData3, nData4);
            //값 분석을 통해 변경된 값은 TimeLog를 만들어 Return

            if (m_cByte1.Used) cLogS.AddRange(GetTimeLogSAllTag(m_cByte1, nData1, cLog.Time));
            if (m_cByte2.Used) cLogS.AddRange(GetTimeLogSAllTag(m_cByte2, nData2, cLog.Time));
            if (m_cByte3.Used) cLogS.AddRange(GetTimeLogSAllTag(m_cByte3, nData3, cLog.Time));
            if (m_cByte4.Used) cLogS.AddRange(GetTimeLogSAllTag(m_cByte4, nData4, cLog.Time));
            Console.WriteLine(string.Format("Log {0}, Count = {1}", cLog.Key, cLogS.Count));
            return cLogS;
        }

        #endregion
    }
}
