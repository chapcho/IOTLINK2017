using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDM.EnergyDaq.Config
{
    public partial class UCEthernetSetting : UserControl
    {
        protected List<CDataBlock> m_cDataBlock = new List<CDataBlock>();
        protected CPersetConfig m_cPersetConfig = null;

        public UCEthernetSetting(CPersetConfig tempConfig)
        {
            InitializeComponent();
            m_cPersetConfig = tempConfig;

            txtIpAddress.Text = tempConfig.IPAddress;
            txtPort.Text = tempConfig.Port.ToString();
            txtStartAdd.Text = tempConfig.StartAddress.ToString();
            NUDChannel.Value = tempConfig.ChannelCount;

            if(tempConfig.ChannelCount>0)
            {
                txtWordCount.Text = (tempConfig.WordCountPreChannel * tempConfig.ChannelCount).ToString();
            }
            else
                txtWordCount.Text = "108";
        }

        public CEthernetConfig GetEthernetConfig()
        {
            CEthernetConfig tempConfig = new CEthernetConfig();

            tempConfig.IP = txtIpAddress.Text;
            tempConfig.Port = txtPort.Text;
            tempConfig.ChannelCount = (int)NUDChannel.Value;

            foreach(CDataBlock cTemp in m_cDataBlock)
            {
                tempConfig.DataBlockS.Add(cTemp);
            }

            return tempConfig;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CDataBlock cdatablock = new CDataBlock();

            cdatablock.StartAddress = Convert.ToInt32(txtStartAdd.Text);
            cdatablock.WordCount = Convert.ToInt32(txtWordCount.Text);

            m_cDataBlock.Add(cdatablock);
        }

        private void NUDChannel_ValueChanged(object sender, EventArgs e)
        {
            if (m_cPersetConfig!= null)
            {
                txtWordCount.Text = (m_cPersetConfig.WordCountPreChannel * NUDChannel.Value).ToString();
            }
            else
                txtWordCount.Text = "0";
        }

     
    }
}
