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
using System.Diagnostics;

namespace FTOPApp
{
    public partial class FrmServerOption : DevExpress.XtraEditors.XtraForm
    {
        public int Interval;
        public bool UseCPS;
        public bool UseMES;
        public bool UseACS;
        public int SendCount;
        public EMFTOPServerSendMode TransportMode;

        public FrmServerOption(int i, EMFTOPServerSendMode s , bool CPS , bool MES ,bool ACS , int sendCount)
        {
            InitializeComponent();

            Interval = i;
            TransportMode = s;
            UseCPS = CPS;
            UseMES = MES;
            UseACS = ACS;
            TrancCount.Text = sendCount.ToString();

            comboInterval.Text = i.ToString();
            comboMode.Text = GetSendMode(s);
            checkUseCPS.Checked = CPS;
            checkUseMES.Checked = MES;
            checkUseACS.Checked = ACS;

            btnOK.Click += (o, e) => 
            {
                Interval = int.Parse(comboInterval.Text);
                if (comboMode.Text.Contains("Sequence"))
                    TransportMode = EMFTOPServerSendMode.SequenceMode;
                else if (comboMode.Text.Contains("Thread"))
                    TransportMode = EMFTOPServerSendMode.ThreadMode;

                if (checkUseCPS.CheckState == CheckState.Checked)
                    UseCPS = true;
                else
                    UseCPS = false;

                if (checkUseMES.CheckState == CheckState.Checked)
                    UseMES = true;
                else
                    UseMES = false;

                if (checkUseACS.CheckState == CheckState.Checked)
                    UseACS = true;
                else
                    UseACS = false;

                SendCount = int.Parse(TrancCount.Text);

                this.Close(); 
            };

            btnCancel.Click += (o, e) => { this.Close(); };
        }

        private string GetSendMode(EMFTOPServerSendMode SendMode)
        {
            if(SendMode == EMFTOPServerSendMode.SequenceMode)
            {
                return "Sequence Mode";
            }
            else
            {
                return "Thread Que Mode";
            }
        }

        #region Test Mode

        public Stopwatch Watch = new Stopwatch();
        public CbCpsIotDataManager.CpsIotDataManagerClient CpsClient = new CbCpsIotDataManager.CpsIotDataManagerClient("172.17.2.22");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var aa = new List<string>();
            aa.Add("111");
            aa.Add("222");
            aa.Add("333");
            aa.Add("111");
            aa.Add("222");
            aa.Add("333");
            aa.Add("111");
            aa.Add("222");
            aa.Add("333");
            aa.Add("333");

            for (int i = 0; i < 100000; i++)
            {
                Watch.Start();
                CpsClient.SendIotStatus(aa.ToArray(), aa.ToArray(), aa.ToArray());
                Watch.Stop();
                Console.WriteLine("Time : " + Watch.ElapsedMilliseconds.ToString());
                Watch.Reset();
            }
        }

        public DYPServiceReference.DYP_WebserviceSoapClient SoapClient = new DYPServiceReference.DYP_WebserviceSoapClient();    
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var aa = new List<string>();
            aa.Add("111");
            aa.Add("222");
            aa.Add("111");
            aa.Add("222");
            aa.Add("333");
            aa.Add("111");
            aa.Add("222");
            aa.Add("333");
            aa.Add("333");

            for (int i = 0; i < 100000; i++)
            {

                Watch.Start();
                SoapClient.Set_LogData2(aa.ToArray(),aa.ToArray(),aa.ToArray());
                //SoapClient.Set_LogData("111", "111", "111");
                Watch.Stop();
                Console.WriteLine("Time : " + Watch.ElapsedMilliseconds.ToString());
                Watch.Reset();
            }
        }

        int count = 1;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CpsClient.SendIotStatus(count.ToString(), "22", "33");
            count++;
        }

        #endregion
    }
}