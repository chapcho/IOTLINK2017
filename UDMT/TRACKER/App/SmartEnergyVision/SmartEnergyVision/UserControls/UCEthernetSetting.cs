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

namespace SmartEnergyVision
{
    public partial class UCEthernetSetting : UserControl
    {
        protected List<CDataBlock> m_cDataBlock = new List<CDataBlock>();

        public UCEthernetSetting()
        {
            InitializeComponent();
            txtIpAddress.Text = "192.168.1.254";
            txtPort.Text = "254";
            txtStartAdd.Text = "8448";
            txtWordCount.Text = "108";
        }

        public CEthernetConfig GetEthernetConfig()
        {
            CEthernetConfig tempConfig = new CEthernetConfig();

            tempConfig.IP = txtIpAddress.Text;
            tempConfig.Port = txtPort.Text;

            return tempConfig;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CDataBlock cdatablock = new CDataBlock();

            cdatablock.StartAddress = Convert.ToInt32(txtStartAdd.Text);
            cdatablock.WordCount = Convert.ToInt32(txtWordCount.Text);

            m_cDataBlock.Add(cdatablock);
        }
    }
}
