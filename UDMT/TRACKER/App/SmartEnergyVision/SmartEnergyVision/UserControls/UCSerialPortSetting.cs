using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.Monitor.Energy;
using System.IO.Ports;

namespace SmartEnergyVision
{
    public partial class UCSerialPortSetting : UserControl
    {
        protected List<CSerialDeviceConfig> m_lstSerialDeviceS = new List<CSerialDeviceConfig>();

        #region Public Properties

        public List<CSerialDeviceConfig> SerialDeviceS
        {
            get { return m_lstSerialDeviceS; }
        }

        #endregion

        public UCSerialPortSetting()
        {
            InitializeComponent();

            string[] sPortName = System.IO.Ports.SerialPort.GetPortNames();
            this.cbPortName.Items.AddRange(sPortName);

            for (int i = 0; i < sPortName.Length; i++)
            {
                this.cbPortName.Items.Add(sPortName[i]);
            }
            this.cbPortName.SelectedIndex = 0;

            this.cbBaudRate.Items.Add(1200);
            this.cbBaudRate.Items.Add(2400);
            this.cbBaudRate.Items.Add(4800);
            this.cbBaudRate.Items.Add(9600);
            this.cbBaudRate.Items.Add(19200);
            this.cbBaudRate.Items.Add(38400);
            this.cbBaudRate.Items.Add(57600);
            this.cbBaudRate.SelectedIndex = 4;

            this.cbReadBufSize.TabIndex = 5;
            this.cbReadBufSize.Items.Add(64);
            this.cbReadBufSize.Items.Add(128);
            this.cbReadBufSize.Items.Add(256);
            this.cbReadBufSize.Items.Add(512);
            this.cbReadBufSize.Items.Add(1024);
            this.cbReadBufSize.SelectedIndex = 4;

            this.cbWriteBufSize.Items.Add(32);
            this.cbWriteBufSize.Items.Add(64);
            this.cbWriteBufSize.Items.Add(128);
            this.cbWriteBufSize.Items.Add(256);
            this.cbWriteBufSize.Items.Add(512);
            this.cbWriteBufSize.SelectedIndex = 2;

            this.cbReadTime.Items.Add(100);
            this.cbReadTime.Items.Add(200);
            this.cbReadTime.Items.Add(300);
            this.cbReadTime.Items.Add(400);
            this.cbReadTime.Items.Add(500);
            this.cbReadTime.SelectedIndex = 4;

            this.cbWriteTimeOut.Items.Add(50);
            this.cbWriteTimeOut.Items.Add(100);
            this.cbWriteTimeOut.Items.Add(150);
            this.cbWriteTimeOut.Items.Add(200);
            this.cbWriteTimeOut.SelectedIndex = 2;

            this.cbParity.Items.Add(System.IO.Ports.Parity.Even.ToString());
            this.cbParity.Items.Add(System.IO.Ports.Parity.Odd.ToString());
            this.cbParity.Items.Add(System.IO.Ports.Parity.Mark.ToString());
            this.cbParity.Items.Add(System.IO.Ports.Parity.Space.ToString());
            this.cbParity.Items.Add(System.IO.Ports.Parity.None.ToString());
            this.cbParity.SelectedIndex = 0;

            this.cbStopBit.Items.Add(System.IO.Ports.StopBits.One.ToString());
            this.cbStopBit.Items.Add(System.IO.Ports.StopBits.OnePointFive.ToString());
            this.cbStopBit.Items.Add(System.IO.Ports.StopBits.Two.ToString());
            this.cbStopBit.Items.Add(System.IO.Ports.StopBits.None.ToString());
            this.cbStopBit.SelectedIndex = 0;

            this.txtDeviceIndex.Text = (1).ToString();
            this.txtStartAddress.Text = (9000).ToString();
            this.txtWordCount.Text = (53).ToString();
        }        

        #region Public Methods

        public CSerialPortConfig GetSerialPortConfgi()
        {
            CSerialPortConfig cPortConfig = new CSerialPortConfig();

            cPortConfig.ComPortName = cbPortName.SelectedItem.ToString();
            cPortConfig.BaudRate = Convert.ToInt32(cbBaudRate.SelectedItem.ToString());
            cPortConfig.ReadBufferSize = Convert.ToInt32(cbReadBufSize.SelectedItem.ToString());
            cPortConfig.ReadTimeOut = Convert.ToInt32(cbReadTime.SelectedItem.ToString());
            cPortConfig.WriteBufferSize = Convert.ToInt32(cbWriteBufSize.SelectedItem.ToString());
            cPortConfig.WriteTimeOut = Convert.ToInt32(cbWriteTimeOut.SelectedItem.ToString());

            string sParity = cbParity.SelectedItem.ToString();
            string sStopBit = cbStopBit.SelectedItem.ToString();

            switch(sParity)
            {
                case "Even": cPortConfig.ParityS = Parity.Even; break;
                case "Odd": cPortConfig.ParityS = Parity.Odd; break;
                case "Mark": cPortConfig.ParityS = Parity.Mark; break;
                case "Space": cPortConfig.ParityS = Parity.Space; break;
                case "None": cPortConfig.ParityS = Parity.None; break;
            }

            switch(sStopBit)
            {
                case "One": cPortConfig.StopBit = StopBits.One; break;
                case "OnePointFive": cPortConfig.StopBit = StopBits.OnePointFive; break;
                case "Two": cPortConfig.StopBit = StopBits.Two; break;
                case "None": cPortConfig.StopBit = StopBits.None; break;
            }

            cPortConfig.DeviceConfigList = m_lstSerialDeviceS;

            return cPortConfig;
        }

        #endregion

        #region Event Methods

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            CSerialDeviceConfig cDeviceConfig = new CSerialDeviceConfig();

            cDeviceConfig.SlaveIndex = Convert.ToInt32(txtDeviceIndex.Text.ToString());
            cDeviceConfig.StartAddress = Convert.ToInt32(txtStartAddress.Text.ToString());
            cDeviceConfig.WordCount = Convert.ToInt32(txtWordCount.Text.ToString());

            m_lstSerialDeviceS.Add(cDeviceConfig);
        }

        #endregion
    }
}
