using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDM.EnergyDaq.Config
{
    public partial class FrmConfigSetting : Form
    {

        protected UCSerialPortSetting m_ucSerial = null;
        protected UCEthernetSetting m_ucEthernet = null;
        protected CConfigS m_cConfigS = null;
        public event UEventHandlerMeterConfigEdited MeterConfigEdited;

        protected CPersetConfig m_cCurPersetConfig = null;

        #region Initilaize/Dispose
        public FrmConfigSetting()
        {
            m_cConfigS = new CConfigS();

            InitializeComponent();
            InformationSetting();
        }

        #endregion

        #region public Properties

        public CConfigS ConfigS
        {
            get { return m_cConfigS; }
            set { m_cConfigS = value; }
        }


        #endregion

        #region Public Methods

        public EMMeterModel GetMeterModel()
        {
            string sTemp = cbMeterModel.SelectedItem.ToString();

            EMMeterModel emTemp = EMMeterModel.DummyMeter;

            switch (sTemp)
            {
                case "DummyMeter": emTemp = EMMeterModel.DummyMeter; break;
                case "AcuRev2000": emTemp = EMMeterModel.AcuRev2000; break;
                case "Accura3300S": emTemp = EMMeterModel.Accura3300S; break;
                case "OtherModel": emTemp = EMMeterModel.OtherModel; break;
            }

            return emTemp;
        }

        #endregion

        #region Private Methods

        private void InformationSetting()
        {
            int iPanelHeightValue = pnlConfigKey.Size.Height;
            List<string> lstTempListString = new List<string>();

            var fields = typeof(EMMeterModel).GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach(var fi in fields)
            {
                lstTempListString.Add(fi.Name);
            }

            string[] tempModelS = lstTempListString.ToArray();
            this.cbMeterModel.Items.AddRange(tempModelS);
            this.cbMeterModel.SelectedIndex = 0;

            lstTempListString.Clear();

            fields = typeof(EMConnectType).GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach(var fi in fields)
            {
                lstTempListString.Add(fi.Name);
            }
    
            string[] tempConnectS = lstTempListString.ToArray();
            this.cbConnectType.Items.AddRange(tempConnectS);
            this.cbConnectType.SelectedIndex = 0;

            //this.lblMeterkey.Location =new Point( lblMeterkey.Location.X,(iPanelHeightValue - lblMeterkey.Size.Height) / 2);
            //this.lblModel.Location = new Point(lblModel.Location.X, (iPanelHeightValue - lblModel.Size.Height) / 2);
            //this.lblConnectType.Location = new Point(lblConnectType.Location.X, (iPanelHeightValue - lblConnectType.Size.Height) / 2);
            //this.txtMeterName.Location = new Point(txtMeterName.Location.X, (iPanelHeightValue - txtMeterName.Size.Height) / 2);
            //this.cbMeterModel.Location = new Point(cbMeterModel.Location.X, (iPanelHeightValue - cbMeterModel.Size.Height) / 2);
            //this.cbConnectType.Location = new Point(cbConnectType.Location.X, (iPanelHeightValue - cbConnectType.Size.Height) / 2);
        }

        private void SetUerControlForConnect()
        {
            string ConnectType = this.cbConnectType.SelectedText;

            if (ConnectType == "SerialPort")
            {
                
            }
            else if (ConnectType == "Ethernet")
            {

            }
        }

        private void GenerateConfigEditEvent()
        {
            try
            {
                if (MeterConfigEdited != null)
                    MeterConfigEdited(this, m_cConfigS);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void AddDummyMeterConfig()
        {
            CConfig tempConfig = new CConfig();

            tempConfig.MeterModel = EMMeterModel.DummyMeter;
            tempConfig.ConnectType = EMConnectType.DummyMeter;
            tempConfig.MeterKey = txtMeterName.Text;
            tempConfig.IntervalTime = Convert.ToInt32(txtIntervalTime.Text);
            tempConfig.ChannelCount = 1;

            m_cConfigS.Add(tempConfig);
        }

        private void AddEthernetMeterConfig()
        {
            CEthernetConfig tempConfig = m_ucEthernet.GetEthernetConfig();
            tempConfig.MeterModel = GetMeterModel();
            tempConfig.ConnectType = GetConnectType();
            tempConfig.MeterKey = txtMeterName.Text;
            tempConfig.IntervalTime = Convert.ToInt32(txtIntervalTime.Text);
           
        }

        private void AddSerialMeterConfig()
        {
            CSerialPortConfig tempConfig = m_ucSerial.GetSerialPortConfgi();
            tempConfig.MeterModel = GetMeterModel();
            tempConfig.ConnectType = GetConnectType();
            tempConfig.MeterKey = txtMeterName.Text;
            tempConfig.IntervalTime = Convert.ToInt32(txtIntervalTime.Text);
            tempConfig.ChannelCount = tempConfig.DeviceConfigList.Count;

            foreach(CSerialDeviceConfig cDeviceConfig in tempConfig.DeviceConfigList)
            {
                cDeviceConfig.MeterDeviceKey = tempConfig.MeterKey + "_" + cDeviceConfig.MeterDeviceKey;
            }

            m_cConfigS.Add(tempConfig);
        }

        private void AddUSBMeterConfig()
        {

        }


        private EMConnectType GetConnectType()
        {
            string sTemp = cbConnectType.SelectedItem.ToString();

            EMConnectType emTemp = EMConnectType.DummyMeter;

            switch (sTemp)
            {
                case "DummyMeter": emTemp = EMConnectType.DummyMeter; break;
                case "Ethernet": emTemp = EMConnectType.Ethernet; break;
                case "SerialPort": emTemp = EMConnectType.SerialPort; break;
                case "USB": emTemp = EMConnectType.USB; break;
            }

            return emTemp;
        }

        private void CleanConnectPanel()
        {
            if (pnlConnectSetting.Controls.Count > 0)
                pnlConnectSetting.Controls.Clear();
        }

        #endregion

        #region EventS

        private void cbMeterModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbMeterModel.SelectedItem.ToString() == "DummyMeter")
            {
                this.cbConnectType.Items.Clear();
                this.cbConnectType.Items.Add("DummyMeter");
            }
            else if (this.cbMeterModel.SelectedItem.ToString() == "Other")
            {

            }
            else
            {
                if(CPersetConfigS.PersetMeter.Keys.Contains(cbMeterModel.SelectedItem.ToString()))
                {
                    CPersetConfig ctempPerset = CPersetConfigS.PersetMeter[cbMeterModel.SelectedItem.ToString()];
                    m_cCurPersetConfig = ctempPerset;

                    this.cbConnectType.Items.Clear();

                    if(ctempPerset.ConnectType == "Ethernet&Serial")
                    {
                        this.cbConnectType.Items.Add("Ethernet");
                        this.cbConnectType.Items.Add("SerialPort");
                    }
                    else if(ctempPerset.ConnectType == "Ethernet")
                    {
                        this.cbConnectType.Items.Add("Ethernet");
                    }
                    else if(ctempPerset.ConnectType == "Serial")
                    {
                        this.cbConnectType.Items.Add("SerialPort");
                    }

                    this.cbConnectType.SelectedIndex = 0;    
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btAddConfig_Click(object sender, EventArgs e)
        {
            if (cbConnectType.SelectedItem.ToString() == "DummyMeter")
            {
                AddDummyMeterConfig();
            }
            else if (cbConnectType.SelectedItem.ToString() == "Ethernet")
            {
                AddEthernetMeterConfig();
            }
            else if (cbConnectType.SelectedItem.ToString() == "SerialPort")
            {
                AddSerialMeterConfig();
            }
            else if (cbConnectType.SelectedItem.ToString() == "USB")
            {
                AddUSBMeterConfig();
            }
        }

        private void btShowConfigs_Click(object sender, EventArgs e)
        {
            
        }

        private void cbConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleanConnectPanel();

            if(cbConnectType.SelectedItem.ToString() =="Ethernet")
            {
                m_ucEthernet = new UCEthernetSetting(m_cCurPersetConfig);
                m_ucEthernet.Dock = System.Windows.Forms.DockStyle.Fill;
                m_ucEthernet.Location = new System.Drawing.Point(5, 5);
                m_ucEthernet.Name = "m_ucEthernet";
                m_ucEthernet.Padding = new System.Windows.Forms.Padding(5);
                m_ucEthernet.TabIndex = 0;
                pnlConnectSetting.Controls.Add(m_ucEthernet);
            }
            else if (cbConnectType.SelectedItem.ToString() == "SerialPort")
            {
                m_ucSerial = new UCSerialPortSetting(this);
                m_ucSerial.Dock = System.Windows.Forms.DockStyle.Fill;
                m_ucSerial.Location = new System.Drawing.Point(5, 5);
                m_ucSerial.Name = "m_ucSerial";
                m_ucSerial.Padding = new System.Windows.Forms.Padding(5);
                m_ucSerial.TabIndex = 0;
                pnlConnectSetting.Controls.Add(m_ucSerial);
            }
        }

        #endregion

       

    }
}
