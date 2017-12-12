using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDMEnergyViewer
{
    public class cModBusTCPIPWrapper: IDisposable
    {
        protected static short m_sStartingAddress = 8448;// Channel 1 Current Value Start address     
        private cSocketWrapper m_cSocketWrapper = null;
        protected bool m_bConnected = false;
        protected byte m_byteDataIndex = 0;
        protected int m_iChannelS = 0;

        #region Initialze/Dispose

        public cModBusTCPIPWrapper(string iPAddress, int port, int ChannelS)
        {
            m_cSocketWrapper = new cSocketWrapper(iPAddress, port);
            m_iChannelS = ChannelS;
            m_bConnected = m_cSocketWrapper.Connect();
        }

        public void Dispose()
        {
            m_cSocketWrapper.Dispose();
        }
        #endregion    
    
        #region Public MethodS

        public bool ConnectCheck()
        {

            if (!m_cSocketWrapper.m_cSocket.Connected)
                m_cSocketWrapper.Connect();

            return m_cSocketWrapper.SocketConCheck();
        }

        public byte[] Receive(out bool bBroken)
        {
            bBroken = false;

            byte[] result = null;
            bBroken = this.ConnectCheck();
            if (bBroken == false)
                return null;
            else
            {
                List<byte> sendData = new List<byte>(50);

                //[1].Send
                sendData.AddRange(cValueHelper.Instance.GetBytes(this.NextDataIndex()));//1~2.(Transaction Identifier)
                sendData.AddRange(new Byte[] { 0, 0 });//3~4:Protocol Identifier,0 = MODBUS protocol
                sendData.AddRange(cValueHelper.Instance.GetBytes((short)6));//5~6:Followed bytes
                sendData.Add(1);//7:Unit Identifier:This field is used for intra-system routing purpose.
                sendData.Add((byte)emFunctionCode.ReadData);
                sendData.AddRange(cValueHelper.Instance.GetBytes(m_sStartingAddress));//9~10.Start Address
                sendData.AddRange(cValueHelper.Instance.GetBytes((short)(m_iChannelS*12)));//11~12.Numbers

                ////메터기 성능때문에 1초 간격으로 수집
                System.Threading.Thread.Sleep(1000);
           
                this.m_cSocketWrapper.Write(sendData.ToArray()); //Send recive

                Application.DoEvents();
                byte[] receiveData = this.m_cSocketWrapper.Read(1024);
                short identifier = (short)((((short)receiveData[0]) << 8) + receiveData[1]);

                //if (identifier != this.CurrentDataIndex) 
                //{
                //    return new Byte[0];

                //}
                byte length = receiveData[8];
                result = new byte[length];
                Array.Copy(receiveData, 9, result, 0, length);

                return result;
            }
            
        }


        public void DisConnect()
        {
            m_cSocketWrapper.DisConnect();
        }

        #endregion

        #region Transaction Identifier
        /// <summary>
        /// Send Message Identifier
        /// </summary>
        protected byte CurrentDataIndex
        {
            get { return this.m_byteDataIndex; }
        }

        protected byte NextDataIndex()
        {
            return ++this.m_byteDataIndex;
        }
        #endregion

    }
}
