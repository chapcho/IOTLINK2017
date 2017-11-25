using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;
using MySql.Data.MySqlClient;



namespace LTEMODEM_SERVER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        // 전역변수 설정
        TcpListener server = null;
        TcpClient clientSocket = null;
        static int counter = 0;

        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        // 쓰레드 
        Thread IOTServerth = null;
        
        // 크로스쓰레드 오류 처리를 위한 델리게이트
        delegate void mydele();


        private void ServerStartBT_Click(object sender, EventArgs e)
        {
            if (ServerStartBT.Text == "서버시작")
            {
                // 서버 쓰레드 실행
                IOTServerth = new Thread(new ThreadStart(IOTServerStart));
                IOTServerth.IsBackground = true;
                IOTServerth.Start();

                ServerStartBT.Text = "서버중지";
            }
            else if (ServerStartBT.Text == "서버중지")
            {
                // TcpListener 정지
                server.Stop();
                ServerStartBT.Text = "서버시작";

                // 쓰레드가 돌고 있으면 정지
                if (IOTServerth.IsAlive)
                    IOTServerth.Abort();
            }
        }

        // 데이터가 들어오면 디스플레이1 함수 호출
        private void OnControlMessage1(string message)
        {
            DisplayText1(message);
        }

        // 접속 해제시 접속리스트에서 삭제
        void h_client_OnDisconnected1(TcpClient clientSocket)
        {
            if (clientList.ContainsKey(clientSocket))
            {
                mydele dt = delegate ()
                {
                    listBox1.Items.Add("Client가 접속 해제 함" + "\r\n");
                };
                this.Invoke(dt);
                clientList.Remove(clientSocket);
            }
        }

        // 데이터가 왔을때 ListBox에 로그를 남기는 함수(델리게이트를 이용해서 크로스쓰레드 오류 처리)
        public void DisplayText1(string text)
        {
            mydele dt = delegate()
            {
                listBox1.Items.Add(text + "\r\n");

                if (checkBox1.Checked)
                {
                    SENDTB.Text = text;
                    SENDBT.PerformClick();
                    SENDTB.Text = "";
                }

                // 시작 : "S" // 1byte
                // 컴프레셔ID : "00000000" // 8byte
                // 컴프레셔정보번호 : "00" // 2byte
                // 데이터 : "0000" // 4byte (데이터당)
                // 끝 : "E" // 1byte

                // [시작],[컴프ID],[정보],[토출온도],[토출압력],[주위온도],[유회수기압력],[유회수기온도]],[유회수기차압],
                // [총운전시간],[모터운전시간],[모터운전횟수],[부하운전시간],[부하운전횟수],[인버터출력],[압력전송],[온도전송],[끝]
                // ex) "S,00000000,00,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,0000,E"

                // 컴프정보아이디 당 데이터 수
                // "00" : 14개
                // "01" : 10개
                // "02" : 7개
                // "04" : 6개
                // "05" : 5개
                // "06" : 6개
                // "07" : 2개
                // "08" : 9개

                if (text[0] == 'S' && text[text.Length-2] == 'E')
                {
                    // S,id,data1,data2,data3,data4
                    string[] RecvDatas = text.Split(',');

                    if(RecvDatas[2].ToString() == "00")
                    {
                        DBSave00("comp_00_tb", RecvDatas);
                    }
                    else if(RecvDatas[2].ToString() == "01")
                    {
                        DBSave01("comp_01_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "02")
                    {
                        DBSave02("comp_02_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "04")
                    {
                        DBSave04("comp_04_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "05")
                    {
                        DBSave05("comp_05_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "06")
                    {
                        DBSave06("comp_06_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "07")
                    {
                        DBSave07("comp_07_tb", RecvDatas);
                    }
                    else if (RecvDatas[2].ToString() == "08")
                    {
                        DBSave08("comp_08_tb", RecvDatas);
                    }

                    /*
                    string[] GotoDBData = new string[4];
                    GotoDBData[0] = RecvDatas[2];
                    GotoDBData[1] = RecvDatas[3];
                    GotoDBData[2] = RecvDatas[4];
                    GotoDBData[3] = RecvDatas[5];

                    DBSave(RecvDatas[1].ToString(), GotoDBData);
                    */
                }
                listBox1.SelectedIndex = listBox1.Items.Count - 1;

                if (listBox1.Items.Count == 10)
                    listBox1.Items.Clear();
            };
            this.Invoke(dt);
        }




        
        // DB접속 명령
        string connStr = "SERVER=127.0.0.1;DATABASE=compdata;UID=root;PASSWORD=amin!!";

        private void DBSave00(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data00_00 = RecvData[3].ToString();
                string data00_01 = RecvData[4].ToString();
                string data00_02 = RecvData[5].ToString();
                string data00_03 = RecvData[6].ToString();
                string data00_04 = RecvData[7].ToString();
                string data00_05 = RecvData[8].ToString();
                string data00_06 = RecvData[9].ToString();
                string data00_07 = RecvData[10].ToString();
                string data00_08 = RecvData[11].ToString();
                string data00_09 = RecvData[12].ToString();
                string data00_10 = RecvData[13].ToString();
                string data00_11 = RecvData[14].ToString();
                string data00_12 = RecvData[15].ToString();
                string data00_13 = RecvData[16].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 00_00, 00_01, 00_02, 00_03, 00_04, 00_05, 00_06, 00_07, 00_08, 00_09, 00_10, 00_11, 00_12, 00_13, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data00_00 + "," +
                    data00_01 + "," +
                    data00_02 + "," +
                    data00_03 + "," +
                    data00_04 + "," +
                    data00_05 + "," +
                    data00_06 + "," +
                    data00_07 + "," +
                    data00_08 + "," +
                    data00_09 + "," +
                    data00_10 + "," +
                    data00_11 + "," +
                    data00_12 + "," +
                    data00_13 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                //string errstring = ex.Message;

                //DisplayText1("데이터 에러 : 테이블이 없습니다.");
                MessageBox.Show("DBSave00 : " + ex.ToString());
            }
        }
        private void DBSave01(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data01_00 = RecvData[3].ToString();
                string data01_01 = RecvData[4].ToString();
                string data01_02 = RecvData[5].ToString();
                string data01_03 = RecvData[6].ToString();
                string data01_04 = RecvData[7].ToString();
                string data01_05 = RecvData[8].ToString();
                string data01_06 = RecvData[9].ToString();
                string data01_07 = RecvData[10].ToString();
                string data01_08 = RecvData[11].ToString();
                string data01_09 = RecvData[12].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 01_00, 01_01, 01_02, 01_03, 01_04, 01_05, 01_06, 01_07, 01_08, 01_09, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data01_00 + "," +
                    data01_01 + "," +
                    data01_02 + "," +
                    data01_03 + "," +
                    data01_04 + "," +
                    data01_05 + "," +
                    data01_06 + "," +
                    data01_07 + "," +
                    data01_08 + "," +
                    data01_09 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                //string errstring = ex.Message;

                //DisplayText1("데이터 에러 : 테이블이 없습니다.");
                MessageBox.Show("DBSave01 : " + ex.ToString());
            }
        }

        private void DBSave02(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data02_00 = RecvData[3].ToString();
                string data02_01 = RecvData[4].ToString();
                string data02_02 = RecvData[5].ToString();
                string data02_03 = RecvData[6].ToString();
                string data02_04 = RecvData[7].ToString();
                string data02_05 = RecvData[8].ToString();
                string data02_06 = RecvData[9].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 02_00, 02_01, 02_02, 02_03, 02_04, 02_05, 02_06, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data02_00 + "," +
                    data02_01 + "," +
                    data02_02 + "," +
                    data02_03 + "," +
                    data02_04 + "," +
                    data02_05 + "," +
                    data02_06 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBSave02 : " + ex.ToString());
            }
        }

        private void DBSave04(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data04_00 = RecvData[3].ToString();
                string data04_01 = RecvData[4].ToString();
                string data04_02 = RecvData[5].ToString();
                string data04_03 = RecvData[6].ToString();
                string data04_04 = RecvData[7].ToString();
                string data04_05 = RecvData[8].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 04_00, 04_01, 04_02, 04_03, 04_04, 04_05, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data04_00 + "," +
                    data04_01 + "," +
                    data04_02 + "," +
                    data04_03 + "," +
                    data04_04 + "," +
                    data04_05 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBSave04 : " + ex.ToString());
            }
        }

        private void DBSave05(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data05_00 = RecvData[3].ToString();
                string data05_01 = RecvData[4].ToString();
                string data05_02 = RecvData[5].ToString();
                string data05_03 = RecvData[6].ToString();
                string data05_04 = RecvData[7].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 05_00, 05_01, 05_02, 05_03, 05_04, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data05_00 + "," +
                    data05_01 + "," +
                    data05_02 + "," +
                    data05_03 + "," +
                    data05_04 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBSave05 : " + ex.ToString());
            }
        }

        private void DBSave06(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data06_00 = RecvData[3].ToString();
                string data06_01 = RecvData[4].ToString();
                string data06_02 = RecvData[5].ToString();
                string data06_03 = RecvData[6].ToString();
                string data06_04 = RecvData[7].ToString();
                string data06_05 = RecvData[8].ToString();

                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 06_00, 06_01, 06_02, 06_03, 06_04, 06_05, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data06_00 + "," +
                    data06_01 + "," +
                    data06_02 + "," +
                    data06_03 + "," +
                    data06_04 + "," +
                    data06_05 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBSave06 : " + ex.ToString());
            }
        }

        private void DBSave07(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data07_00 = RecvData[3].ToString();
                string data07_01 = RecvData[4].ToString();

                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 07_00, 07_01, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data07_00 + "," +
                    data07_01 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBSave07 : " + ex.ToString());
            }
        }

        private void DBSave08(string TableName, string[] RecvData)
        {
            try
            {
                string FK_Product_Number = RecvData[1].ToString();
                string Id = RecvData[1].ToString();
                string data08_00 = RecvData[3].ToString();
                string data08_01 = RecvData[4].ToString();
                string data08_02 = RecvData[5].ToString();
                string data08_03 = RecvData[6].ToString();
                string data08_04 = RecvData[7].ToString();
                string data08_05 = RecvData[8].ToString();
                string data08_06 = RecvData[9].ToString();
                string data08_07 = RecvData[10].ToString();
                string data08_08 = RecvData[11].ToString();
                
                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (FK_PRODUCT_NUMBER, ID, 08_00, 08_01, 08_02, 08_03, 08_04, 08_05, 08_06, 08_07, 08_08, SAVETIME) " +
                    " values (" +
                    FK_Product_Number + "," +
                    Convert.ToInt32(Id) + "," +
                    data08_00 + "," +
                    data08_01 + "," +
                    data08_02 + "," +
                    data08_03 + "," +
                    data08_04 + "," +
                    data08_05 + "," +
                    data08_06 + "," +
                    data08_07 + "," +
                    data08_08 + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                //string errstring = ex.Message;

                //DisplayText1("데이터 에러 : 테이블이 없습니다.");
                MessageBox.Show("DBSave01 : " + ex.ToString());
            }
        }

        private void DBSave(string TableName, string[] RecvData)
        {
            try
            {
                string outputairpressure = RecvData[0].ToString();
                string inoilpressure = RecvData[1].ToString();
                string outputairtemp = RecvData[2].ToString();
                string inoiltemp = RecvData[3].ToString();

                DateTime dateValue = DateTime.Now;
                string savetime = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

                string query = "INSERT INTO " + TableName +          // 쿼리 명령
                    " (outputairpressure, inoilpressure, outputairtemp, inoiltemp, savetime) " +
                    " values (" +
                    Convert.ToDouble(outputairpressure) + "," +
                    Convert.ToDouble(inoilpressure) + "," +
                    Convert.ToDouble(outputairtemp) + "," +
                    Convert.ToDouble(inoiltemp) + "," +
                    "'" + savetime + "')";

                MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
                conn.Open();                                            // 디비 오픈
                MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
                comm.ExecuteNonQuery();                                 // 쿼리 날리기
                conn.Close();                                           // 디비 닫기            
            }
            catch (Exception ex)
            {
                //string errstring = ex.Message;

                DisplayText1("데이터 에러 : 테이블이 없습니다.");
                //MessageBox.Show("DatabaseSave : " + ex.ToString());
            }
        }


        byte[] Databyte = new byte[512];
        string Recvdata = null;
        bool IsConnect = false;

        void IOTServerStart()
        {
            // 아이피, 포트 셋팅
            server = new TcpListener(IPAddress.Parse(IPTB.Text), Convert.ToInt32(PORTTB.Text));
            clientSocket = default(TcpClient);
            // TcpListener 실행
            server.Start();

            while (true)
            {
                try
                {
                    counter++;
                    // 접속대기
                    clientSocket = server.AcceptTcpClient();

                    // 접속시에 스트림 생성
                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[512]; // 512 바이트 배열 생성
                    
                    mydele dt = delegate ()
                    {
                        listBox1.Items.Add(clientSocket.Client.RemoteEndPoint.ToString() + " Client가 접속함" + "\r\n");
                    };
                    this.Invoke(dt);

                    int bytes = stream.Read(buffer, 0, buffer.Length); // 받은 데이터 넣기
                    string getclient = counter.ToString(); // 접속한 클라이언트 번호
                    clientList.Add(clientSocket, getclient); // 리스트에 클라이언트 소켓과 접속 번호 넣기

                    handleClient h_client = new handleClient(); // 클라이언트핸들 생성

                    h_client.OnControlMessageReceived += new handleClient.ControlMessageDisplayHandler(OnControlMessage1); // 메세지 처리 이벤트
                    h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected1); // 접속 해제 처리 이벤트
                    h_client.startClient(clientSocket, clientList); // 클라이언트 쓰레드 시작
                    
                    
                }
                catch (SocketException se)
                {
                    Trace.WriteLine(string.Format("InitSocket - SocketException : {0}", se.Message));
                    break;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("InitSocket - Exception : {0}", ex.Message));
                    break;
                }

            }

        }

        private void SENDBT_Click(object sender, EventArgs e)
        {
            // 보낼 데이터 바이트 배열로 변환(아스키 인코딩)
            byte[] SendData = Encoding.ASCII.GetBytes(SENDTB.Text+"\r\n");
            int SendDataSize = SendData.Length; // 데이터 길이
            
            // 접속중인 클라이언트들을 전부 찾아서 보냄
            foreach (var pair in clientList)
            {
                Trace.WriteLine(string.Format("{0}", pair.Key, pair.Value));

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();

                stream.Write(SendData, 0, SendData.Length);
                stream.Flush();
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        string ControlVal = "";

        void DBControl()
        {
            MySqlConnection conn = new MySqlConnection("SERVER=localhost;DATABASE=comp;UID=root;PASSWORD=amin!!");
            string query = "Select * from controls";
            MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ControlVal = dr["cmd"].ToString();
            }
            conn.Close();
        }

        void DBCON2()
        {
            string query = "update controls set cmd = '0'";

            MySqlConnection conn = new MySqlConnection(connStr);    // 커넥션
            conn.Open();                                            // 디비 오픈
            MySqlCommand comm = new MySqlCommand(query, conn);     // 쿼리 생성
            comm.ExecuteNonQuery();                                 // 쿼리 날리기
            conn.Close();                                           // 디비 닫기    
        }


        byte[] SendData;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                DBControl();

                if (clientList != null)
                {
                    // 접속중인 클라이언트들을 전부 찾아서 보냄
                    foreach (var pair in clientList)
                    {
                        if (ControlVal == "0")
                        {
                            return;
                            //SendData = Encoding.ASCII.GetBytes("C,0,E" + "\r\n");
                            //DBCON2();
                        }
                        else if (ControlVal == "1")
                        {
                            SendData = Encoding.ASCII.GetBytes("C,1,E"+"\r\n");
                            DBCON2();
                            DisplayText1("웹에서 운전 실행");
                        }
                        else if (ControlVal == "2")
                        {
                            SendData = Encoding.ASCII.GetBytes("C,2,E"+"\r\n");
                            DBCON2();
                            DisplayText1("웹에서 정지 실행");
                        }

                        int SendDataSize;
                        if (SendData != null)
                        {
                            SendDataSize = SendData.Length; // 데이터 길이


                            Trace.WriteLine(string.Format("{0}", pair.Key, pair.Value));

                            TcpClient client = pair.Key as TcpClient;
                            NetworkStream stream = client.GetStream();

                            stream.Write(SendData, 0, SendData.Length);
                            stream.Flush();
                        }
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



    }
}
