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

namespace FTOPApp
{
    public partial class UCCPSViewer : UserControl
    {
        private PerformanceCounter cpuCounter;

        public UCCPSViewer()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick+=timer_Tick;


            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


            labelComponent1.Text = cpuCounter.NextValue().ToString() + "%";
            arcScaleComponent1.Value = cpuCounter.NextValue();
        }
    }
}
