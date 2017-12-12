using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTOPApp
{
    public partial class UCDBViewer : UserControl
    {
        public UCDBViewer()
        {
            InitializeComponent();

            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += timer_Tick;


            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var rValue = new Random();
            var value = rValue.Next(50, 70);

            labelComponent1.Text = value.ToString() + "%";
            arcScaleComponent1.Value = value;
        }
    }
}
