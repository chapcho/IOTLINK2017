using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCPlcCycle : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private int m_iMainSplitPos = 0;
        private int m_iRealSplitPos = 0;
        private List<string> m_lstContainProcessName = new List<string>();
        private delegate void UpdateNoneParameterCallback();

        #endregion


        #region Initialize

        public UCPlcCycle()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public List<string> ProcessNameList
        {
            get { return m_lstContainProcessName; }
        }

        #endregion


        #region Public Methods

        public void Run()
        {
            try
            {
                ucProcessCycleBoardS.ClearTimerValue();
                ucProcessCycleBoardS.Run();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                ucProcessCycleBoardS.Stop();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView(string sPlcKey)
        {
            try
            {
                ClearView();

                SetContainProcessName(sPlcKey);

                ucProcessCycleStatisticS.ClearControl();
                ucProcessCycleStatisticS.TotalCycleInfoS = CMultiProject.TotalCycleInfoS;
                ucProcessCycleStatisticS.ProcessS =
                    CMultiProject.PlcProcS.Where(x => x.Value.PlcLogicDataS.ContainsKey(sPlcKey))
                        .Select(x => x.Value)
                        .ToList();

                ucProcessCycleBoardS.ShowBoard(sPlcKey);

                ucCycleInfoDashBoard.ClearControl();
                ucCycleInfoDashBoard.PlcProcS = CMultiProject.PlcProcS.Where(x => x.Value.PlcLogicDataS.ContainsKey(sPlcKey))
                        .Select(x => x.Value)
                        .ToList();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                ClearView();

                m_lstContainProcessName.AddRange(CMultiProject.PlcProcS.Keys);

                ucProcessCycleStatisticS.ClearControl();
                ucProcessCycleStatisticS.TotalCycleInfoS = CMultiProject.TotalCycleInfoS;
                ucProcessCycleStatisticS.ProcessS = CMultiProject.PlcProcS.Values.ToList();

                ucProcessCycleBoardS.ShowBoard();

                ucCycleInfoDashBoard.ClearControl();
                ucCycleInfoDashBoard.PlcProcS = CMultiProject.PlcProcS.Values.ToList();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                ucProcessCycleStatisticS.ClearControl();
                //ucProcessCycleStatisticS.Dispose();
                ucProcessCycleBoardS.Clear();
                //ucProcessCycleBoardS.Dispose();
                ucCycleInfoDashBoard.ClearControl();
                //ucCycleInfoDashBoard.Dispose();

                m_lstContainProcessName.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearView()
        {
            try
            {
                ucProcessCycleBoardS.Clear();
                ucProcessCycleStatisticS.ClearControl();
                ucCycleInfoDashBoard.ClearControl();

                m_lstContainProcessName.Clear();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }


        public void UpdateCycleStatisticS(CCycleInfo cCycleInfo)
        {
            try
            {
                ucProcessCycleStatisticS.UpdateCycleStatisticInfo(cCycleInfo);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleOver(string sProcessKey)
        {
            try
            {
                ucProcessCycleBoardS.UpdateCycleOver(sProcessKey);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleStart(string sProcessKey, DateTime dtActTime)
        {
            try
            {
                ucProcessCycleBoardS.UpdateCycleStart(sProcessKey, dtActTime);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleEnd(string sProcessKey, DateTime dtActTime, bool bError, int iMaxTime)
        {
            try
            {
                ucProcessCycleBoardS.UpdateCycleEnd(sProcessKey, dtActTime, bError, iMaxTime);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleState(string sProcessKey, EMCycleRunType emCycleType)
        {
            try
            {
                ucCycleInfoDashBoard.UpdateCycleState(sProcessKey, emCycleType);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateCycleInfoS(string sProcessKey, CCycleInfo cCycleInfo)
        {
            try
            {
                ucCycleInfoDashBoard.UpdateCycleInfoS(sProcessKey, cCycleInfo);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }

        public void CycleResizePanel()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(CycleResizePanel);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    int iSptWidth = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.55);
                    sptCycleMain.SplitterPosition = iSptWidth;
                    sptRealTime.SplitterPosition = (int)(sptCycleMain.Panel1.Width * 0.6);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCPlcCycle", ex.Message);
                ex.Data.Clear();
            }
        }


        #endregion


        #region Private Methods


        private void SetContainProcessName(string sPlcKey)
        {
            m_lstContainProcessName.Clear();

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.PlcLogicDataS == null)
                    who.Value.PlcLogicDataS = new CPlcLogicDataS();

                if (who.Value.PlcLogicDataS.ContainsKey(sPlcKey))
                    m_lstContainProcessName.Add(who.Key);
            }
        }

        private void LoadPanel()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(LoadPanel);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    ucProcessCycleStatisticS.UEventScrollBarMoved += ucProcessStatisticS_ScrollMoved;
                    ucCycleInfoDashBoard.UEventScrollBarMoved += ucCycleInfoDashBoard_ScrollMoved;
                    ucProcessCycleBoardS.UEventScrollBarMoved += ucCycleBoard_ScrollMoved;

                    //int iSptWidth = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.55);
                    //sptCycleMain.SplitterPosition = iSptWidth;

                    //grpTotalCycleStatisticS.Width = (int)(sptCycleMain.Panel1.Width * 0.6);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion


        #region Form Events

        private void ucCycleBoard_ScrollMoved(int iYPosition)
        {
            try
            {
                ucProcessCycleStatisticS.SetScrollPosition(iYPosition);
                ucCycleInfoDashBoard.SetScrollPosition(iYPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucProcessStatisticS_ScrollMoved(int iYPosition)
        {
            try
            {
                ucCycleInfoDashBoard.SetScrollPosition(iYPosition);
                ucProcessCycleBoardS.SetScrollPosition(iYPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucCycleInfoDashBoard_ScrollMoved(int iYPosition)
        {
            try
            {
                ucProcessCycleBoardS.SetScrollPosition(iYPosition);
                ucProcessCycleStatisticS.SetScrollPosition(iYPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int iSelectIndex = radioGroup.SelectedIndex;
                ucProcessCycleStatisticS.GenerateStatisticViewEvent(iSelectIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCPlcCycle_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPanel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCPlcCycle_Resize(object sender, EventArgs e)
        {
            try
            {
                CycleResizePanel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void sptCycleMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptCycleMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptCycleMain.SplitterPosition;
                sptCycleMain.SplitterPosition = 0;
            }
            else
                sptCycleMain.SplitterPosition = m_iMainSplitPos;
        }

        private void sptRealTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptRealTime.SplitterPosition > 0)
            {
                m_iRealSplitPos = sptRealTime.SplitterPosition;
                sptRealTime.SplitterPosition = 0;
            }
            else
                sptRealTime.SplitterPosition = m_iRealSplitPos;
        }

        #endregion
    }
}
