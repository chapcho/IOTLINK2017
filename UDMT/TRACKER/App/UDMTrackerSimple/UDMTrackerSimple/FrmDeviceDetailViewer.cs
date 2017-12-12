using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using UDM.General.Statistics;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public partial class FrmDeviceDetailViewer : DevExpress.XtraEditors.XtraForm
    {
        private DateTime m_dtTime = DateTime.MinValue;
        private CMySqlLogReader m_cReader = null;

        private CErrorInfoS m_cErrorInfoS = null;
        private Dictionary<string, CCycleInfoS> m_dicCurrentCycleInfo = new Dictionary<string, CCycleInfoS>();
        private Dictionary<string, CCycleInfoS> m_dicTotalCycleInfo = new Dictionary<string, CCycleInfoS>();

        private List<CDeviceView> m_lstView = new List<CDeviceView>(); 
        private List<double> m_lstDelay = new List<double>(); 

        public FrmDeviceDetailViewer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        public DateTime Time
        {
            get { return m_dtTime; }
            set { m_dtTime = value; }
        }

        private void InitTime()
        {
            dtpkTime.EditValue = m_dtTime;
        }

        private void CreateCycleInfo()
        {
            if (m_cReader.IsConnected == false)
                m_cReader.Connect();

            List<double> m_lstCycle = new List<double>();
            List<double> m_lstTact = new List<double>();
            List<double> m_lstIdle = new List<double>();
            CCycleInfoS cInfoS;
            CDeviceView cView;

            m_lstView.Clear();
            m_dicCurrentCycleInfo.Clear();
            m_dicTotalCycleInfo.Clear();
            m_lstDelay.Clear();

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (!m_dicCurrentCycleInfo.ContainsKey(who.Key))
                {
                    cInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.Key, m_dtTime);

                    if (cInfoS == null || cInfoS.Count == 0)
                        continue;

                    m_dicCurrentCycleInfo.Add(who.Key, cInfoS);
                }
            }

            foreach (var who in m_dicCurrentCycleInfo)
            {
                if (!m_dicTotalCycleInfo.ContainsKey(who.Key))
                {
                    cInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.Key);

                    if (cInfoS == null || cInfoS.Count == 0)
                        continue;

                    m_dicTotalCycleInfo.Add(who.Key, cInfoS);

                    m_lstCycle.Clear();
                    m_lstTact.Clear();
                    m_lstIdle.Clear();

                    foreach (CCycleInfo cInfo in cInfoS.Values)
                    {
                        if (cInfoS.Last().Value == cInfo) continue;
                        if (cInfo.CycleType == EMCycleRunType.Error) continue;
                        if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue) continue;

                        m_lstTact.Add(cInfo.TactTimeValue.TotalMilliseconds);
                        m_lstCycle.Add(cInfo.CycleTimeValue.TotalMilliseconds);
                        m_lstIdle.Add(cInfo.IdleTimeValue.TotalMilliseconds);
                    }

                    cView = new CDeviceView();
                    cView.ProcessName = who.Key;
                    cView.CycleAvr = CStatics.Mean(m_lstCycle)/1000;
                    cView.TactAvr = CStatics.Mean(m_lstTact)/1000;
                    cView.IdleAvr = CStatics.Mean(m_lstIdle)/1000;
                    cView.Min = m_lstCycle.Min()/1000;
                    cView.Max = m_lstCycle.Max()/1000;
                    cView.Cycle = who.Value.First().Value.CycleTime;
                    cView.Tact = who.Value.First().Value.TactTime;
                    cView.Idle = who.Value.First().Value.IdleTime;
                    cView.CycleStart = who.Value.First().Value.CycleStart;
                    cView.CycleInfo = who.Value.First().Value;

                    m_lstView.Add(cView);
                    m_lstDelay.Add(Math.Abs((cView.CycleAvr - Convert.ToDouble(cView.Cycle))));
                }
            }

            if (m_lstDelay.Count == 0)
                return;

            int iDelayIndex = m_lstDelay.IndexOf(m_lstDelay.Max());
            cView = m_lstView[iDelayIndex];
            cView.DelayCheck = true;

            grdCycle.DataSource = m_lstView;
            grdCycle.RefreshDataSource();
        }

        private void CreateErrorInfo()
        {
            CErrorInfoS cInfoS = m_cReader.GetErrorInfoS(CMultiProject.ProjectID);

            if (cInfoS == null || cInfoS.Count == 0)
                return;

            m_cErrorInfoS = cInfoS.GetErrorInfoS(m_dtTime.AddMinutes(-1), m_dtTime.AddMinutes(1));

            ucError.UpdateView(m_cErrorInfoS);
        }

        private void CheckErroInfoLogS(CErrorInfo cInfo)
        {
            if (cInfo.ErrorLogS != null && cInfo.ErrorLogS.Count != 0)
                return;

            cInfo.ErrorLogS = m_cReader.GetErrorLogS(cInfo.ErrorID);
        }

        private void ShowErrorAnalysis(CErrorInfo cErrorInfo)
        {
            CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
            CPlcProc cProcess = CMultiProject.PlcProcS[cErrorInfo.GroupKey];
            
            CheckErroInfoLogS(cErrorInfo);

            FrmErrorAnalysisViewer frmViewer = new FrmErrorAnalysisViewer();
            frmViewer.ErrorInfo = cErrorInfo;
            frmViewer.Tag = cTag;
            frmViewer.PlcLogicData = CMultiProject.GetPlcLogicData(cTag);
            frmViewer.Process = cProcess;
            frmViewer.Show();
        }

        private void ShowErrorDiagram(CErrorInfo cErrorInfo)
        {
            CTag cInterlockTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
            CPlcLogicData cData = CMultiProject.GetPlcLogicData(cInterlockTag);

            CheckErroInfoLogS(cErrorInfo);

            FrmErrorDiagramViewer frmViewer = new FrmErrorDiagramViewer();
            frmViewer.ErrorInfo = cErrorInfo;
            frmViewer.InterlockTag = cInterlockTag;
            frmViewer.PlcLogicData = cData;
            frmViewer.Show();
        }

        private void FrmDeviceDetailViewer_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Size.Width / 2, Screen.PrimaryScreen.Bounds.Size.Height);
            SplashScreenManager.ShowDefaultWaitForm();
            {
                InitTime();
                CreateCycleInfo();
                CreateErrorInfo();

                ucError.UErrorLogGridDoubleClickEvent += ucErrorGrid_UEventDoubleClick;
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Index = 0 은 Cycle
            if (tabMain.SelectedTabPageIndex == 0)
            {
                ShowDelayCycleLog();
            }
            else
            {
                ucError.ShowError();
            }
        }

        private void ShowDelayCycleLog()
        {
            CDeviceView cView = null;
            CCycleInfo cInfo = null;

            int iHandle = grvCycle.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = grvCycle.GetRow(iHandle);
            if ((oData.GetType() == typeof(CDeviceView)))
            {
                cView = (CDeviceView)oData;
                cInfo = cView.CycleInfo;
            }

            if (cInfo == null)
                return;

            FrmDelayCycleLogViewer cViewer = new FrmDelayCycleLogViewer();
            cViewer.CycleInfo = cInfo;
            cViewer.Show();
        }

        private void ucErrorGrid_UEventDoubleClick(object sender, CErrorInfo cErrorInfo)
        {
            if (cErrorInfo.ErrorType == "CycleOver")
                ShowErrorAnalysis(cErrorInfo);
            else if (cErrorInfo.ErrorType == "Interlock")
                ShowErrorDiagram(cErrorInfo);
        }

        private void grvCycle_DoubleClick(object sender, EventArgs e)
        {
            ShowDelayCycleLog();
        }

        private void grvCycle_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                CDeviceView cView = (CDeviceView)grvCycle.GetRow(e.RowHandle);

                if (cView.DelayCheck)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }

    public class CDeviceView
    {
        private double m_dCycleAvr = 0;
        private double m_dTactAvr = 0;
        private double m_dIdleAvr = 0;
        private double m_dMin = 0;
        private double m_dMax = 0;
        private string m_sCycle = string.Empty;
        private string m_sTact = string.Empty;
        private string m_sIdle = string.Empty;
        private string m_sProcessName = string.Empty;
        private DateTime m_dtCycleStart = DateTime.MinValue;
        private bool m_bDelayCheck = false;
        private CCycleInfo m_cCycleInfo = null;


        public CCycleInfo CycleInfo
        {
            get { return m_cCycleInfo; }
            set { m_cCycleInfo = value; }
        }

        public bool DelayCheck
        {
            get { return m_bDelayCheck; }
            set { m_bDelayCheck = value; }
        }

        public string ProcessName
        {
            get { return m_sProcessName;}
            set { m_sProcessName = value; }
        }

        public DateTime CycleStart
        {
            get { return m_dtCycleStart; }
            set { m_dtCycleStart = value; }
        }

        public double CycleAvr
        {
            get { return Math.Round(m_dCycleAvr, 2);}
            set { m_dCycleAvr = value; }
        }

        public double TactAvr
        {
            get { return Math.Round(m_dTactAvr, 2); }
            set { m_dTactAvr = value; }
        }

        public double IdleAvr
        {
            get { return Math.Round(m_dIdleAvr, 2); }
            set { m_dIdleAvr = value; }
        }

        public double Min
        {
            get { return Math.Round(m_dMin, 2); }
            set { m_dMin = value; }
        }

        public double Max
        {
            get { return Math.Round(m_dMax, 2); }
            set { m_dMax = value; }
        }

        public string Cycle
        {
            get { return m_sCycle; }
            set { m_sCycle = value; }
        }

        public string Tact
        {
            get { return m_sTact; }
            set { m_sTact = value; }
        }

        public string Idle
        {
            get { return m_sIdle; }
            set { m_sIdle = value; }
        }
    }
}
