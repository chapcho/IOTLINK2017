using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace FTOPApp
{
    public partial class UCNetworkViewer : UserControl
    {
        private PerformanceCounter _p;
        private Timer _timer;
        public int Interval = 1000;

        public UCNetworkViewer()
        {
            InitializeComponent();

            this.Load += (o, e) => 
            {
                SetNetWorkAdapter();
                SetTimer();
            };
        }

        private void SetNetWorkAdapter()
        {
            var pcg = new PerformanceCounterCategory("Network Interface");
            var instance = pcg.GetInstanceNames()[0];

            _p = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);

            //_p = new PerformanceCounter();
            //_p.CategoryName = "Network Interface";
            //_p.CounterName = "Bytes Sent/sec";
            //_p.InstanceName = instance;
        }

        /// <summary>
        /// 아직 구현 안함.... 1~15랜덤 생성 중..
        /// </summary>
        private void SetTimer()
        {
            _timer = new Timer();
            _timer.Interval = Interval;
            _timer.Tick += (o, e) => 
            {  
                //var aa = _p.NextValue();
                var rnd = new Random();
                progressBarControl1.EditValue = rnd.Next(0, 15);
            };
            _timer.Start();
        }


    }
}
