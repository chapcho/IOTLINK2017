using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using UDM.Log;
using UDM.Common;
using DevExpress.XtraSplashScreen;

namespace UDMTrackerSimple
{
    public partial class FrmCycleSelection : DevExpress.XtraEditors.XtraForm, IDisposable
    {
        Dictionary<string, bool> m_dicTabPageControl = new Dictionary<string, bool>();
        private bool m_bPageSelected = false;
        private string m_sSelectedPageKey = string.Empty;

        public event UEventHandlerTrackerMessage UEventMessage = null;

        public bool PageSelect
        {
            get { return m_bPageSelected; }
            set { m_bPageSelected = value; }
        }

        public string SelectedPageName
        {
            get { return m_sSelectedPageKey; }
            set { m_sSelectedPageKey = value; }
        }

        public FrmCycleSelection()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            XtraTabPage tpPage = null;
            UCProcessSetting ucSetting = null;
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                tpPage = tabMain.TabPages[i];

                if (tpPage.Controls == null || tpPage.Controls.Count == 0)
                    continue;

                ucSetting = (UCProcessSetting) tpPage.Controls[0];
                ucSetting.Dispose();

                ucSetting = null;
            }

            tabMain.TabPages.Clear();

            m_dicTabPageControl.Clear();
            m_dicTabPageControl = null;
        }

        private CTimeLogS GetTimeLogS(CTagS cTagS)
        {
            CTimeLogS cResultLog = new CTimeLogS();
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                CTimeLogS cLogS = CMultiProject.LogReader.GetTimeLogS(who.Key);
                cResultLog.AddRange(cLogS);
            }
            cResultLog.Sort();

            return cResultLog;
        }

        private void SetProcessUserControl(XtraTabPage tpPage)
        {
            bool bFileRead = false;

            if (!CMultiProject.PlcProcS.ContainsKey(tpPage.Text))
                return;

            CPlcProc cProcess = CMultiProject.PlcProcS[tpPage.Text];

            UCProcessSetting cProcessSet = new UCProcessSetting();
            cProcessSet.TotalTagS = CMultiProject.TotalTagS;
            cProcessSet.PlcProcess = cProcess;

            if (CMultiProject.LogReader.IsConnected == false)
                CMultiProject.LogReader.Connect();

            if (cProcess.ChartStartTime == DateTime.MinValue || cProcess.ChartEndTime == DateTime.MinValue)
            {
                DateTime dtLastTime = CMultiProject.LogReader.GetLastTimeLogTime();

                if (dtLastTime != DateTime.MinValue)
                    cProcessSet.TimeLogS = CMultiProject.LogReader.GetTimeLogS(cProcess.ChartViewTagS.Keys.ToList(), dtLastTime.AddMinutes(-15), dtLastTime);
            }
            else
                cProcessSet.TimeLogS = CMultiProject.LogReader.GetTimeLogS(cProcess.ChartViewTagS.Keys.ToList(), cProcess.ChartStartTime, cProcess.ChartEndTime);

            if (cProcessSet.TimeLogS == null || cProcessSet.TimeLogS.Count == 0)
            {
                bFileRead = true;
                cProcessSet.TimeLogS = CMultiProject.ReadTimeLogSForProcessSetting(cProcess.Name);
            }

            cProcessSet.PlcLogicDataS = CMultiProject.PlcLogicDataS;
            cProcessSet.Dock = DockStyle.Fill;

            tpPage.Controls.Add(cProcessSet);
            cProcessSet.InitialData();

            if (cProcessSet.TimeLogS != null && cProcessSet.TimeLogS.Count > 0 && bFileRead == false)
                CMultiProject.WriteTimeLogSForProcessSetting(cProcess.Name, cProcessSet.TimeLogS);
        }

        private void CreateTabPage()
        {
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

            int iCount = 0;
            bool bFirst = true;
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.IsErrorMonitoring)
                    continue;

                XtraTabPage tabPage = new XtraTabPage();
                
                tabPage.Name = "tp" + iCount.ToString();
                tabPage.Text = who.Value.Name;
                iCount++;
                tabMain.TabPages.Add(tabPage);

                if (bFirst)
                {
                    SetProcessUserControl(tabPage);
                    bFirst = false;
                    m_dicTabPageControl.Add(tabPage.Name, true);
                }
                else
                    m_dicTabPageControl.Add(tabPage.Name, false);


            }


            SplashScreenManager.CloseForm(false);
        }

        private void FrmCycleSelection_Load(object sender, EventArgs e)
        {
            try
            {
                if (CMultiProject.PlcProcS.Count > 0)
                {
                    CreateTabPage();

                    if (m_bPageSelected)
                        tabMain.SelectedTabPage = tabMain.TabPages.Where(x => x.Text == m_sSelectedPageKey).ToList()[0];
                }
                else
                {
                    MessageBox.Show("Process가 없습니다. 창을 종료합니다.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmCycleSelection",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void tabMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page == null)
                    return;

                if (m_dicTabPageControl.ContainsKey(e.Page.Name.ToString()))
                {
                    if (m_dicTabPageControl[e.Page.Name.ToString()]) return;
                }
                else
                    return;

                XtraTabPage tpPage = e.Page;
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true ,false);
                {
                    SetProcessUserControl(tpPage);
                }
                SplashScreenManager.CloseForm(false);

                m_dicTabPageControl[e.Page.Name.ToString()] = true;
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("FrmCycleSelection",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }
    }
}