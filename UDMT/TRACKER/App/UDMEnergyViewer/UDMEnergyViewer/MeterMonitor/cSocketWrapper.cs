using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;

namespace UDMEnergyViewer
{
    internal class cSocketWrapper:IDisposable
    {
        protected string m_sIP = string.Empty;
        protected int m_iPort = 0;
        protected IPEndPoint m_IP = null;
        public Socket m_cSocket = null;

        //private static ManualResetEvent connectDone = new ManualResetEvent(false);
        //private static ManualResetEvent sendDone = new ManualResetEvent(false);
        //private static ManualResetEvent receiveDone = new ManualResetEvent(false);
                
        #region Initialze/Dispose
        public cSocketWrapper(string sIpAddress, int sPort)
        {
            m_sIP = sIpAddress;
            m_iPort = sPort;            
            m_IP = new IPEndPoint(IPAddress.Parse(m_sIP), m_iPort);
        }

        public void Dispose()
        {
            if (this.m_cSocket != null)
            {
                this.m_cSocket.Close();
            }
        }
        #endregion

        #region Public Properites

        public Socket UsingSocket
        {
            get { return m_cSocket; }
        }

        public string UsingIPAddress
        {
            get { return m_sIP; }
            set { m_sIP = value; }
        }
        public int UsingPort
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }
        #endregion

        public bool CheckSocketConnect()
        {
            bool isConnected = false;

            try
            {
                m_cSocket.Connect(m_IP);
                isConnected = true;
                return isConnected;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("There are one failed read from energy meter. ");
                ex.Data.Clear();
                return false;
            }
            finally
            {
                if(m_cSocket.Connected)
                    m_cSocket.Disconnect(true);
            }          

        }

        public bool SocketConCheck()
        {
            bool isConnected = false;
            bool bOK = true;
            bool isError = false;

            bOK = CheckSocket(ref isConnected,  ref isError);

            if(!bOK||!isConnected||isError)
            {
                int i = 0;
                while (i < 5)
                {
                    if(m_cSocket.Connected)
                    {
                        m_cSocket.Disconnect(false);
                    }
                    m_cSocket.Close();
                    m_cSocket = null;
                    System.Threading.Thread.Sleep(100);

                    CreateClientSocket();
                    try
                    {
                        m_cSocket.Connect(m_IP);
                    }
                    catch(System.Exception ex)
                    {
                        Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                        Console.WriteLine("There are one failed read from energy meter. ");
                        ex.Data.Clear();
                    }

                    bOK = CheckSocket(ref isConnected, ref isError);
                    if(bOK|| isConnected||!isError)
                    {
                        break;
                    }
                    i++;
                }
            }
      

            if(isConnected == false)
            {
                MessageBox.Show("Socket is disconnneted. Please check meter config.");
            }
            return isConnected;
        }

        public byte[] Read(int length)
        {
            byte[] data = new byte[length];
            try
            {
                bool bOK = m_cSocket.Connected;

                if(!bOK)
                {
                    bOK = SocketConCheck();
                }
                
                if(bOK)
                {
                    bOK = m_cSocket.Poll(30, SelectMode.SelectRead);

                    if (bOK)
                        this.m_cSocket.Receive(data);
                    else
                    {
                        int i = 0;
                        while (i < 5)
                        {
                            System.Threading.Thread.Sleep(100);
                            bOK = m_cSocket.Poll(30, SelectMode.SelectRead);

                            if (bOK)
                            {
                                this.m_cSocket.Receive(data);
                                break;
                            }
                            //this.m_cSocket.Connect(m_IP);

                            i++;
                        }
                    }
                }                   
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("There are one failed read from energy meter. ");
                ex.Data.Clear();
            }

            return data;            
        }

        public void Write(byte[] data)
        {
            try
            {
                bool bOK = SocketConCheck();
                if (bOK)
                    this.m_cSocket.Send(data);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                Console.WriteLine("There are one failed wirte to energy meter. ");
                ex.Data.Clear();
            }
                   
        }

        public bool Connect()
        {
            bool bOK = false;

            CreateClientSocket();
            try
            {
                m_cSocket.Connect(m_IP);
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                

                ex.Data.Clear();
            }

            //m_cSocket.BeginConnect(m_IP, new AsyncCallback(ConnectCallback), m_cSocket);
            if (m_cSocket.Connected)
            {
                
                bOK = true;
            }
            else
            {
                m_cSocket.Close();
              
                bOK = false;
            }

            return bOK;
        }

        public bool DisConnect()
        {
            bool bOK = false;
            if(m_cSocket.Connected)
            {
                m_cSocket.Shutdown(SocketShutdown.Both);
                m_cSocket.Disconnect(true);
            }               

            return bOK;
        }

        private void CreateClientSocket()
        {
            m_cSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_cSocket.Blocking = true;
        }

        private bool CheckSocket(ref bool isConnected,ref bool isError)
        {
            bool bOK = true;
            try
            {
                isConnected = m_cSocket.Connected;
                //isRead = m_cSocket.Poll(15, SelectMode.SelectRead);
                //isWrite = m_cSocket.Poll(15, SelectMode.SelectWrite);
                isError = m_cSocket.Poll(15, SelectMode.SelectError);
            }
            catch(System.Exception ex)
            {
                bOK = false;
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return bOK;
        }

        //private static void ConnectCallback(IAsyncResult ar)
        //{
        //    Socket tempSocket = (Socket)ar.AsyncState;

        //    tempSocket.EndConnect(ar);
        //    Console.WriteLine("Socket sonnected to {0}", tempSocket.RemoteEndPoint.ToString());

        //    connectDone.Set();
        //}

        //private static void ReceiveCallback(IAsyncResult ar)
        //{
            
        //}

    }
}
