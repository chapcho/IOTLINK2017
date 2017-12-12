using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class UCProcessStatisticS : DevExpress.XtraEditors.XtraUserControl
    {
        private List<CStatisticsViewRow> m_lstStatisticView = null; 

        public UCProcessStatisticS()
        {
            InitializeComponent();
        }

        public List<CStatisticsViewRow> lstStatisticView
        {
            get { return m_lstStatisticView; }
            set
            {
                m_lstStatisticView = value;
                SetProcessStatistic();
            }
        }

        public void Clear()
        {
            if (this.Controls.Count > 0)
                this.Controls.Clear();
        }

        private void SetProcessStatistic()
        {
            Clear();

            if (m_lstStatisticView == null || m_lstStatisticView.Count == 0)
                return;

            UCProcessStatistic ucView = null;
            foreach (CStatisticsViewRow cView in m_lstStatisticView)
            {
                ucView = new UCProcessStatistic();
                ucView.StatisticView = cView;
                ucView.Dock = DockStyle.Top;
                ucView.Height = 250;

                this.Controls.Add(ucView);
            }
            for (int i = 0; i < this.Controls.Count; i++)
                this.Controls[i].BringToFront();
        }

    }
}
