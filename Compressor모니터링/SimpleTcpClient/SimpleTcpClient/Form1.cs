using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SimpleTcpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient("192.168.168.103", 9595);

            string msg = txtMessage.Text;

            byte[] buff = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);

            // (4) 스트림으로부터 바이트 데이타 읽기
            //byte[] outbuf = new byte[1024];
            //int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            //string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);

            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            //Console.WriteLine($"{nbytes} bytes: {output}");            

        }
    }
}
