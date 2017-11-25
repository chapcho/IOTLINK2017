using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;


namespace LTEMODEM_SERVER
{
    class handleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> clientList = null;

        // 접속한 클라이언트들을 처리 하는건 쓰레드를 이용해서 처리함 
        public void startClient(TcpClient clientSocket, Dictionary<TcpClient, string> clientList)
        {
            this.clientSocket = clientSocket;
            this.clientList = clientList;

            Thread t_hanlder = new Thread(doChat);
            t_hanlder.IsBackground = true;
            t_hanlder.Start();


            
        }

        public delegate void ControlMessageDisplayHandler(string message);
        public event ControlMessageDisplayHandler OnControlMessageReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;



        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[512];
                string msg = string.Empty;
                int bytes = 0;
                int MessageCount = 0;

                char[] chars = null;

                while (true)
                {
                    MessageCount++;
                    stream = clientSocket.GetStream();
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    chars = new char[bytes];

                    chars = Encoding.ASCII.GetChars(buffer, 0, bytes);
                    msg = new string(chars);

                    // 클라이언트가 접속을 종료하면 while 에서 계속 빈 문자를 반환 한다.
                    // 이때 bytes 는 받은 데이터가 없기때문에 0 을 반환 하고 
                    // bytes가 0 이라면 clientSocket 과 stream을 닫아서 초기화 시켜준다.
                    // bytes가 0이 아니면 메세지 표시 
                    if (bytes == 0)
                    {
                        MessageCount = 0;

                        if (clientSocket != null)
                        {
                            if (OnDisconnected != null)
                                OnDisconnected(clientSocket);

                            clientSocket.Close();
                            stream.Close();
                        }
                    }
                    else
                    {
                        OnControlMessageReceived(msg);
                    }
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("doChat - SocketException : {0}", se.Message));

                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("doChat - Exception : {0}", ex.Message));

                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
        }
    }
}

