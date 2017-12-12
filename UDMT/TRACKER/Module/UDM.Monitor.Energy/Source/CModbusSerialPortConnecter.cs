using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UDM.Monitor.Energy
{
    public class CModbusSerialPortConnecter
    {
        private System.IO.Ports.SerialPort m_IOSerialPort = null;
        protected CSerialPortConfig m_cSerialPortConfig = null;
        protected CMeterLogger m_cMeterLogger = null;
        protected int m_iDataSize = 0;
        protected Thread m_DataAnalysisThread = null;
        protected Queue<byte> m_qDataS = new Queue<byte>();
        protected bool m_bRun = false;

        #region Inialize/Dispose

        public CModbusSerialPortConnecter(CSerialPortConfig tempConfig)
        {
            m_cSerialPortConfig = tempConfig;

            m_IOSerialPort = new SerialPort();
            m_IOSerialPort.PortName = m_cSerialPortConfig.ComPortName;
            m_IOSerialPort.BaudRate = m_cSerialPortConfig.BaudRate;
            m_IOSerialPort.ReadTimeout = m_cSerialPortConfig.ReadTimeOut;
            m_IOSerialPort.WriteTimeout = m_cSerialPortConfig.WriteTimeOut;
            m_IOSerialPort.ReadBufferSize = m_cSerialPortConfig.ReadBufferSize;
            m_IOSerialPort.WriteBufferSize = m_cSerialPortConfig.WriteBufferSize;
            m_IOSerialPort.DataBits = m_cSerialPortConfig.DataBits;
            m_IOSerialPort.Parity = m_cSerialPortConfig.ParityS;
            m_IOSerialPort.StopBits = m_cSerialPortConfig.StopBit;

            m_IOSerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

            if (m_DataAnalysisThread != null && m_DataAnalysisThread.ThreadState != ThreadState.Stopped)
            {
                m_DataAnalysisThread.Abort();
                m_DataAnalysisThread = null;
            }
            m_bRun = true;

            m_DataAnalysisThread = new Thread(new ThreadStart(DoThreadWork));
            m_DataAnalysisThread.Start();
        }

        public void Dispose()
        {
            if (m_IOSerialPort.IsOpen)
                m_IOSerialPort.Close();

            m_IOSerialPort.Dispose();
            m_bRun = false;
        }

        #endregion

        #region Public Properties
        public CMeterLogger DataLogger
        {
            get { return m_cMeterLogger; }
            set { m_cMeterLogger = value; }
        }
        public string ComPortName
        {
            get { return m_IOSerialPort.PortName; }
            set { m_IOSerialPort.PortName = value; }
        }

        public int BaudRate
        {
            get { return m_IOSerialPort.BaudRate; }
            set { m_IOSerialPort.BaudRate = value; }
        }

        public int WriteBufferSize
        {
            get { return m_IOSerialPort.WriteBufferSize; }
            set { m_IOSerialPort.WriteBufferSize = value; }
        }

        public int ReadBufferSize
        {
            get { return m_IOSerialPort.ReadBufferSize; }
            set { m_IOSerialPort.ReadBufferSize = value; }
        }
        public int DataSize
        {
            get { return m_iDataSize; }
            set { m_iDataSize = value; }
        }
        #endregion

        #region Public MethodS

        public bool CheckSerialPortConnect()
        {
            return m_IOSerialPort.IsOpen;
        }

        public bool SerialPortConnect()
        {
            if (!m_IOSerialPort.IsOpen)
                m_IOSerialPort.Open();

            return m_IOSerialPort.IsOpen;
        }

        public bool ReConnectSerialPort(string ComPort, int BaudRate, int ReadBufferSize, int WriterBufferSize)
        {
            if (m_IOSerialPort.IsOpen)
                m_IOSerialPort.Close();

            m_IOSerialPort.PortName = ComPort;
            m_IOSerialPort.BaudRate = BaudRate;
            m_IOSerialPort.ReadBufferSize = ReadBufferSize;
            m_IOSerialPort.WriteBufferSize = WriterBufferSize;

            m_IOSerialPort.Open();

            return m_IOSerialPort.IsOpen;
        }

        public bool ReConnectSerialPort()
        {
            if (m_IOSerialPort.IsOpen)
                m_IOSerialPort.Close();

            m_IOSerialPort.Open();

            return m_IOSerialPort.IsOpen;
        }

        public void DisConnectSerialPort()
        {
            if (m_IOSerialPort.IsOpen)
                m_IOSerialPort.Close();
        }

        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            int iDataLenght = m_IOSerialPort.BytesToRead;

            byte[] DataS = new byte[iDataLenght];

            m_IOSerialPort.Read(DataS, 0, iDataLenght);

            for (int i = 0; i < iDataLenght; i++)
                m_qDataS.Enqueue(DataS[i]);
        }

        public bool SeriaPortDataSend(byte[] bDataS)
        {


            if (m_IOSerialPort.IsOpen)
            {
                this.m_IOSerialPort.Write(bDataS, 0, bDataS.Length);
                return true;
            }
            else
            {
                bool bOk = SerialPortConnect();
                int i = 0;
                while (bOk == false)
                {
                    bOk = ReConnectSerialPort();
                    System.Threading.Thread.Sleep(100);

                    if (i > 5)
                        break;
                }

                if (bOk == true)
                {
                    this.m_IOSerialPort.Write(bDataS, 0, bDataS.Length);
                    return true;
                }
                else
                    return false;
            }


        }

        #endregion

        #region Private MethodS

        private void ReceivedDataAnalysis(byte[] DataS)
        {
            try
            {
                int iLenght = DataS.Length;

                byte[] bCRC = new byte[2];

                byte[] bDatas = new byte[iLenght - 2];

                for (int i = 0; i < iLenght; i++)
                {
                    if (i < iLenght - 2)
                    {
                        bDatas[i] = DataS[i];
                    }
                    else if (i == iLenght - 2)
                        bCRC[0] = DataS[i];
                    else
                        bCRC[1] = DataS[i];
                }

                byte bCRCh = 0;
                byte bCRCl = 0;

                CModbusCRC16Checker.CalculateCRC(bDatas, iLenght - 2, out bCRCh, out bCRCl);

                if (bCRC[0] == bCRCl && bCRC[1] == bCRCh)
                {
                    byte[] RealDataS = new byte[iLenght - 5];

                    for (int i = 3; i < iLenght - 2; i++)
                    {
                        RealDataS[i - 3] = bDatas[i];
                    }

                    DateTime time = DateTime.Now;

                    CMeterData cData = new CMeterData(time, RealDataS);
                    cData.DeviceInfo = FindDeviceInfor(bDatas[0]);
                    cData.DeviceModel = EMMeterModule.Accura3300S;

                    DoDataRecieved(cData);
                }
                else
                {
                    m_IOSerialPort.DiscardInBuffer();
                    m_IOSerialPort.DiscardOutBuffer();
                    m_cMeterLogger.ClearQue();
                    Console.WriteLine("There are one data's CRC Code is Not Read.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void DoThreadWork()
        {
            while (m_bRun)
            {
                try
                {
                    if (m_qDataS.Count > m_iDataSize)
                    {
                        byte[] Data = new byte[m_iDataSize];

                        for (int i = 0; i < m_iDataSize; i++)
                        {
                            Data[i] = m_qDataS.Dequeue();
                        }

                        ReceivedDataAnalysis(Data);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                    ex.Data.Clear();
                }
            }
        }

        private void DoDataRecieved(CMeterData cData)
        {
            try
            {
                if (m_cMeterLogger.IsRunning)
                    m_cMeterLogger.EnQue(cData);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string FindDeviceInfor(byte data)
        {
            string sDeviceInfor = string.Empty;
            try
            {
                sDeviceInfor = "Device" + data.ToString("D");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sDeviceInfor;
        }

        #endregion
    }
}
