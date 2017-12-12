using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace FTOPApp
{
    public partial class UCOpcViewer : UserControl
    {
        private OPCWorker _opcWorker;

        public UCOpcViewer()
        {
            InitializeComponent();

            this.Load += UCOpcViewer_Load;

            btnGenerate.Click += (o, e) => { GenerateOPCXML(); };
            btnTagView.Click += (o, e) => { TagViewer(); };
        }

        private void UCOpcViewer_Load(object sender, EventArgs e)
        {
            _opcWorker = new OPCWorker();

            SetNetworkAdapter();
        }

        private void GenerateOPCXML()
        {
            _opcWorker.GenerateOPCWorkXML();
        }

        private void TagViewer()
        {
            exGrid.DataSource = _opcWorker.GetTags(GetClientNumber(), GetScanInterval(), GetAdapter());
        }

        private EMClientNumber GetClientNumber()
        {
            if (comboClient.Text == EMClientNumber.FTOPClient1.ToString())
                return EMClientNumber.FTOPClient1;
            else if (comboClient.Text == EMClientNumber.FTOPClient2.ToString())
                return EMClientNumber.FTOPClient2;
            else
                return EMClientNumber.FTOPClient1;
        }

        private int GetScanInterval()
        {
            try
            {
                int interval = int.Parse(comboInterval.Text);

                return interval;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return 50; };

        }

        private string GetAdapter()
        {
            try
            {
                var temp = comboBoxNetworkAdapter.Text;
                if (temp.Contains('('))
                    return temp.Split('(')[0];
                else
                    return temp;
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; };
        }

        private void SetNetworkAdapter()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            comboBoxNetworkAdapter.Items.Add(ip.Address.ToString() + "(" + ni.Name + ")");
                            comboBoxNetworkAdapter.Text = ip.Address.ToString() + "(" + ni.Name + ")";
                        }
                    }
                }
            }

            
        }

    }
}
