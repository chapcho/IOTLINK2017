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

namespace FTOPApp
{
    public partial class FrmOPCSetting : DevExpress.XtraEditors.XtraForm
    {
        public string SelectedServer { get; set; }
        public EMClientNumber SelectedopcNum { get; set; }

        public FrmOPCSetting(List<string> severList)
        {
            InitializeComponent();
            this.Load += FrmOPCSetting_Load;

            try
            {
                foreach (var server in severList)
                    comboServer.Items.Add(server);

                comboServer.Text = severList[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("검색된 OPC Server가 없습니다. OPC Server를 확인하세요" + ex.Message);
            }
            
            this.Load += FrmOPCSetting_Load;
        }

        private void FrmOPCSetting_Load(object sender, EventArgs e)
        {
            btnConnect.Click += (o, s) => 
            {
                SelectedopcNum = GetOPCNumber(comboOPCNumber.Text);
                SelectedServer = comboServer.Text; 
                this.Close(); 
            };

            btnCancel.Click += (o, s) => 
            { 
                SelectedServer = string.Empty; this.Close();
            };
        }

        private EMClientNumber GetOPCNumber(string text)
        {
            if (text.Equals(EMClientNumber.FTOPClient1.ToString()))
                return EMClientNumber.FTOPClient1;
            else if (text.Equals(EMClientNumber.FTOPClient2.ToString()))
                return EMClientNumber.FTOPClient2;
            else if (text.Equals(EMClientNumber.DemoFactory.ToString()))
                return EMClientNumber.DemoFactory;
            else
                return EMClientNumber.FTOPClient1;
        }
    }
}