using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FTOPApp
{
    public partial class UCCpuViewer : UserControl
    {
        private PerformanceCounter _p;
        public Timer _timer;
        public int Interval = 1000;
 
        public UCCpuViewer()
        {
            InitializeComponent();
            this.Load += (o, e) => 
            {             
                SetCpuPerformanceCounter();
                SetTimer();
            };

            this.Disposed += (o, e) => { _timer.Stop(); };
        }

        private void SetCpuPerformanceCounter()
        {
            _p = new PerformanceCounter();
            _p.CategoryName = "Processor";
            _p.CounterName = "% Processor Time";
            _p.InstanceName = "_Total";
        }

        private void SetTimer()
        {
            _timer = new Timer();
            _timer.Interval = Interval;
            _timer.Tick += (o, e) => { progressBarControl1.EditValue = (int)_p.NextValue(); };
            _timer.Start();
        }
    }
}
