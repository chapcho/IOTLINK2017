using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using UDM.Log;

namespace FTOPApp
{
    public partial class FrmObserver : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public event UEventHandlerRibbonMenu RibbonMenuClick;
        public CSystemLog SystemLog = null;
        private UCObserver _observer;

        public string ReportCyleTime = string.Empty;
        public string ReportSendTime = string.Empty;

        public FrmObserver(string LogPath)
        {
            InitializeComponent();

            SystemLog = new CSystemLog(LogPath, "FTOP-Observer");
            _observer = new UCObserver(this, SystemLog);

            this.Load += FrmObserver_Load;
            ribbon.ItemClick += (s, e) => { RibbonMenuClick(s,e.Item.Caption); };
            repositoryItemComboBox1.SelectedValueChanged += repositoryItemComboBox1_SelectedValueChanged;
            repositoryItemComboBox2.SelectedValueChanged += repositoryItemComboBox2_SelectedValueChanged;
        }

        private void repositoryItemComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ReportCyleTime = repositoryItemComboBox1.NullText;
            ReportSendTime = repositoryItemComboBox2.NullText;
        }

        private void repositoryItemComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ReportCyleTime = repositoryItemComboBox1.NullText;
            ReportSendTime = repositoryItemComboBox2.NullText;
        }

        private void FrmObserver_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Add(_observer);
            _observer.Dock = DockStyle.Fill;

            _observer.ObserverStatus += (s, o) => { ObserverStatus.Caption = o; };

            ReportCyleTime = repositoryItemComboBox1.NullText;
            ReportSendTime = repositoryItemComboBox2.NullText;
        }
    }
}