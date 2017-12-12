using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Monitor.Energy;
using UDM.Log.DB;

namespace SmartEnergyVision
{
    public partial class FrmSetting : DevExpress.XtraEditors.XtraForm
    {
        protected UCSerialPortSetting m_ucSerial = null;
        protected UCEthernetSetting m_ucEthernet = null;
        protected CEnergyConfig m_cEnergyConfig = null;

        public FrmSetting()
        {
            InitializeComponent();
            this.cbConnectType.SelectedIndex = 2;
            this.txtIntervalTime.Text = (1000).ToString();
            this.txtRunningRate.Text = (1000).ToString();
            this.txtStopRate.Text = (100).ToString();
        }

        #region Public properties

        public CEnergyConfig EnergyConfig
        {
            get { return m_cEnergyConfig; }
            set { m_cEnergyConfig = value; }
        }
        #endregion

        private void btnApp_Click(object sender, EventArgs e)
        {
            if (cbConnectType.SelectedIndex == 0)
            {
                m_cEnergyConfig = m_ucEthernet.GetEthernetConfig();            
                m_cEnergyConfig.ConnectType = EMConnectType.Ethernet;
                m_cEnergyConfig.MeterModule = EMMeterModule.AcuRev2000;
            }
            else if (cbConnectType.SelectedIndex == 1)
            {
                m_cEnergyConfig = m_ucSerial.GetSerialPortConfgi();
                m_cEnergyConfig.ConnectType = EMConnectType.SerialPort;
                m_cEnergyConfig.MeterModule = EMMeterModule.Accura3300S;
            }
            else
            {
                m_cEnergyConfig = new CEnergyConfig();
                m_cEnergyConfig.ConnectType = EMConnectType.Demo;
            }
            m_cEnergyConfig.FunctionCode = EMModbusFunctionCode.ReadMultipleRegister;
            m_cEnergyConfig.IntervalTime = Convert.ToInt32(txtIntervalTime.Text);
            m_cEnergyConfig.RunningPauseRate = Convert.ToInt32(txtRunningRate.Text);
            m_cEnergyConfig.PauseStopRate = Convert.ToInt32(txtStopRate.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbConnectType_SelectedIndexChanged(object sender, EventArgs e)
        {

            CleanConnectPanel();

            if(cbConnectType.SelectedIndex ==0)
            {
                m_ucEthernet = new UCEthernetSetting();
                m_ucEthernet.Dock = System.Windows.Forms.DockStyle.Fill;
                m_ucEthernet.Location = new System.Drawing.Point(5, 5);
                m_ucEthernet.Name = "m_ucEthernet";
                m_ucEthernet.Padding = new System.Windows.Forms.Padding(5);
                m_ucEthernet.TabIndex = 0;
                pnlConnectSetting.Controls.Add(m_ucEthernet);
            }
            else if(cbConnectType.SelectedIndex ==1)
            {
                m_ucSerial = new UCSerialPortSetting();
                m_ucSerial.Dock = System.Windows.Forms.DockStyle.Fill;
                m_ucSerial.Location = new System.Drawing.Point(5, 5);
                m_ucSerial.Name = "m_ucSerial";
                m_ucSerial.Padding = new System.Windows.Forms.Padding(5);
                m_ucSerial.TabIndex = 0;
                pnlConnectSetting.Controls.Add(m_ucSerial);
            }
        }

        private void CleanConnectPanel()
        {
            if (pnlConnectSetting.Controls.Count > 0)
                pnlConnectSetting.Controls.Clear();

            
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("Whole data will be removed!! Continue?", "Energy Visigion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlgResult == System.Windows.Forms.DialogResult.No)
                return;

            CPostSqlLogWriter cWriter = new CPostSqlLogWriter();
            bool bOK = cWriter.CreateDataBase();
            if (bOK)
                MessageBox.Show("Database is created!!", "Energy Vision", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Fail to create Database!!", "Energy Vision", MessageBoxButtons.OK, MessageBoxIcon.Error);

            cWriter.Dispose();
            cWriter = null;
        }
    }
}