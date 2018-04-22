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
            try
            {
                TcpClient tc = new TcpClient(txtSeverAddress.Text, Int32.Parse(txtServerPort.Text));
                string msg = txtMessage.Text;
                byte[] buff = Encoding.ASCII.GetBytes(msg);
                NetworkStream stream = tc.GetStream();
                stream.Write(buff, 0, buff.Length);
                stream.Close();
                tc.Close();
            }
            catch(Exception ex)
            {
                ex.Data.Clear();

                MessageBox.Show("전송에 실패 했습니다. 서버 주소와 포트를 확인하세요!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeSampleDataSelection();
        }

        private void MakeSampleDataSelection()
        {
            cmbTestData.DisplayMember = "Text";
            cmbTestData.ValueMember = "Value";

            var items = new[]
            {
                new {Text = "Regist 0", Value = "S,0,2018040001,01064407941,E"},
                new {Text = "RunStatus 1,00", Value = "S,1,2018040001,00,12.0,13.2,12.3,22.3,11.2,11.2,123,23,43,22,11,32.1,12,13,E"},
                new {Text = "BasicSet 1,01", Value = "S,1,2018040001,01,12,11,13,12,1,21,23,12.0,13.0,E"},
                new {Text = "RunPlan 1,02", Value = "S,1,2018040001,02,00002359,00002359,00002359,00002359,00002359,00002359,00002359,E"},
                new {Text = "ASInfo 1,03", Value = "S,1,2018040001,03,200,200,200,200,200,200,200,200,200,200,200,200,E"},
                new {Text = "Trip 1,04", Value = "S,1,2018040001,04,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,1.2,E"},
                new {Text = "RunType 1,05", Value = "S,1,2018040001,05,20,40,20,20,10,10,10,127.0.0.1,19200,E"},
                new {Text = "Alarm 1,06", Value = "S,1,2018040001,06,00000123,00000123,00000123,E"},
            };

            cmbTestData.DataSource = items;
            cmbTestData.SelectedIndex = 0;
        }

        private void cmbTestData_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMessage.Text = cmbTestData.SelectedValue.ToString();
        }
    }
}
