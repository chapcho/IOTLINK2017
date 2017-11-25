using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTLManager.UserControls
{
    public partial class UCClock : UserControl
    {
        System.Globalization.CultureInfo m_cCulture = new System.Globalization.CultureInfo("en-US");

        public UCClock()
        {
            InitializeComponent();
        }

        private void UCClock_Load(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            lblDate.Text = dtNow.ToString("yyyy/MM/dd", m_cCulture).ToUpper();
            lblTime.Text = dtNow.ToString("HH : mm : ss");

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            lblDate.Text = dtNow.ToString("yyyy/MM/dd", m_cCulture).ToUpper();
            lblTime.Text = dtNow.ToString("HH : mm : ss");

            lblDate.Refresh();
            lblTime.Refresh();
        }

        private void UCClock_Resize(object sender, EventArgs e)
        {
            float nSize = (this.Width > this.Height) ? this.Height : this.Width;
            FontFamily fontFamily = lblDate.Font.FontFamily;
            float nFontSize = (float)nSize / 100f;
            if (nFontSize < 0.1f)
                nFontSize = 0.1f;

            Font fontDate = new Font(fontFamily, nFontSize * 15f, FontStyle.Bold);
            lblDate.Font = fontDate;

            Font fontValue = new Font(fontFamily, nFontSize * 25f, FontStyle.Bold);
            lblTime.Font = fontValue;
        }
    }
}
