using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    public class CModbusRTUConnecter
    {
        protected CSerialPortConfig m_cSerialConfig = null;

        protected CModbusSerialPortConnecter m_cSerialPortConnecter = null;

        #region Initialze/Dispose

        public CModbusRTUConnecter(CSerialPortConfig tempConfig)
        {
            m_cSerialConfig = tempConfig;
            m_cSerialPortConnecter = new CModbusSerialPortConnecter(tempConfig);
        }

        public void Dispose()
        {
            m_cSerialPortConnecter.Dispose();
        }

        #endregion

        #region Public Properties

        public CSerialPortConfig SerialConfig
        {
            get { return m_cSerialConfig; }
            set { m_cSerialConfig = value; }
        }

        public CMeterLogger DataLogger
        {
            get { return m_cSerialPortConnecter.DataLogger; }
            set { m_cSerialPortConnecter.DataLogger = value; }
        }
        #endregion

        #region Public Methods

        public bool Connect()
        {
            return m_cSerialPortConnecter.SerialPortConnect();
        }

        public bool ReadDataS()
        {
            bool bOk = true;

            foreach (CSerialDeviceConfig tempDeviceCon in m_cSerialConfig.DeviceConfigList)
            {
                bool tempCheck = ReadMeterData(tempDeviceCon.SlaveIndex, tempDeviceCon.StartAddress, tempDeviceCon.WordCount);

                if (tempCheck == false)
                {
                    bOk = false;
                    break;
                }
                System.Threading.Thread.Sleep(50);
            }

            return bOk;
        }

        #endregion

        #region Private Methods

        private bool ReadMeterData(int iSlaveIndex, int iStartAddress, int iWordCount)
        {
            byte[] bSendDataS = new byte[6];

            bSendDataS[0] = (CValueHelper.Instance.GetBytes((short)iSlaveIndex))[1];
            bSendDataS[1] = (CValueHelper.Instance.GetBytes((short)EMModbusFunctionCode.ReadMultipleRegister))[1];

            byte[] tempByteS = CValueHelper.Instance.GetBytes((short)iStartAddress);
            bSendDataS[2] = tempByteS[0];
            bSendDataS[3] = tempByteS[1];

            tempByteS = CValueHelper.Instance.GetBytes((short)iWordCount);
            bSendDataS[4] = tempByteS[0];
            bSendDataS[5] = tempByteS[1];

            byte bCRCh = 0;
            byte bCRCl = 0;
            m_cSerialPortConnecter.DataSize = iWordCount * 2 + 5;

            CModbusCRC16Checker.CalculateCRC(bSendDataS, 6, out bCRCh, out bCRCl);

            byte[] bSendByteS = new byte[8];

            for (int i = 0; i < 6; i++)
            {
                bSendByteS[i] = bSendDataS[i];
            }

            bSendByteS[6] = bCRCl;
            bSendByteS[7] = bCRCh;

            bool bOK = m_cSerialPortConnecter.SeriaPortDataSend(bSendByteS);

            return bOK;
        }

        #endregion
    }
}
