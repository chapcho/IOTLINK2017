using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCAllErrorAlarmView : UserControl
    {
        #region Momber Variables

        private Dictionary<string, CPlcErrorView> m_dicPlcErrorView = new Dictionary<string, CPlcErrorView>();

        public UEventHandlerMonitorPanelDoubleClicked UEventPanelDoubleClick;
        public UEventHandlerMonitorPanelClicked UEventPanelClick;
        public UEventHandlerMonitorAllPanelDoubleClicked UEventAllPanelDoubleClick;

        private delegate void UpdateErrorViewCallback(CErrorInfo cInfo);
        private delegate void UpdateErrorViewCallback2(CErrorInfo cInfo, int iPriority);

        private int m_iMainSplitPos = 0;
        private int m_iErrorSplitPos = 0;

        #endregion


        public UCAllErrorAlarmView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            foreach (var who in m_dicPlcErrorView)
            {
                who.Value.LastErrorID = -1;
                who.Value.ProcessName = string.Empty;
                who.Value.TotalCount = 0;
            }
            grdLine.RefreshDataSource();

            ucErrorAlarmView.Run();
            ucErrorChartS.Run();
            ucErrorPanelS.ClearPanelS();
        }

        public void Stop()
        {
            ucErrorAlarmView.Stop();
            ucErrorPanelS.ClearPanelS();
        }

        public void Clear()
        {
            try
            {
                ucErrorAlarmView.ClearControls();
                ucErrorAlarmView.Dispose();
                ucErrorPanelS.ClearPanelS();
                ucErrorPanelS.Dispose();
                ucErrorChartS.Clear();
                ucErrorChartS.Dispose();

                m_dicPlcErrorView.Clear();
                grdLine.DataSource = null;
                grdLine.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearView()
        {
            try
            {
                ucErrorAlarmView.ClearControls();
                ucErrorPanelS.ClearPanelS();
                ucErrorChartS.Clear();

                m_dicPlcErrorView.Clear();
                grdLine.DataSource = null;
                grdLine.RefreshDataSource();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetView()
        {
            try
            {
                ClearView();
                SetPlcErrorViewS();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorViewCallback cUpdate = new UpdateErrorViewCallback(UpdateError);
                    this.Invoke(cUpdate, new object[] { cErrorInfo });
                }
                else
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                        return;

                    CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                    CPlcLogicData cData = CMultiProject.GetPlcLogicData(cTag);

                    if (cData != null)
                    {
                        ucErrorAlarmView.UpdatePlcError(cData.PlcName, cErrorInfo.GroupKey, cErrorInfo.ErrorMessage);
                        CPlcErrorView cView = m_dicPlcErrorView[cData.PLCID];
                        cView.ProcessName = cErrorInfo.GroupKey;
                        cView.LastTime = DateTime.Now;

                        if (cView.LastErrorID == -1)
                        {
                            cView.LastErrorID = cErrorInfo.ErrorID;
                            cView.TotalCount++;
                        }
                        else if(cView.LastErrorID != cErrorInfo.ErrorID)
                        {
                            cView.LastErrorID = cErrorInfo.ErrorID;
                            cView.TotalCount++;
                        }

                        grdLine.RefreshDataSource();

                        ucErrorPanelS.UpdatePlcErrorListPanelS(cData.PlcName, cErrorInfo);
                        ucErrorChartS.UpdateError();
                    }

                    cTag = null;
                    cData = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateError(CErrorInfo cErrorInfo, int iPriority)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorViewCallback2 cUpdate = new UpdateErrorViewCallback2(UpdateError);
                    this.Invoke(cUpdate, new object[] { cErrorInfo, iPriority });
                }
                else
                {
                    if (!CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                        return;

                    CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                    CPlcLogicData cData = CMultiProject.GetPlcLogicData(cTag);

                    if (cData != null)
                    {
                        ucErrorAlarmView.UpdatePlcError(cData.PlcName, cErrorInfo.GroupKey, cErrorInfo.ErrorMessage);
                        CPlcErrorView cView = m_dicPlcErrorView[cData.PLCID];
                        cView.ProcessName = cErrorInfo.GroupKey;
                        cView.LastTime = DateTime.Now;

                        if (cView.LastErrorID == -1)
                        {
                            cView.LastErrorID = cErrorInfo.ErrorID;
                            cView.TotalCount++;
                        }
                        else if (cView.LastErrorID != cErrorInfo.ErrorID)
                        {
                            cView.LastErrorID = cErrorInfo.ErrorID;
                            cView.TotalCount++;
                        }

                        grdLine.RefreshDataSource();

                        ucErrorPanelS.UpdatePlcErrorListPanelS(cData.PlcName, cErrorInfo);
                        ucErrorChartS.UpdateError();
                    }

                    cTag = null;
                    cData = null;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }


        public void UpdateCycleOverError(string sProcessKey)
        {
            //ucErrorAlarmView.UpdateCycleOverError(sProcessKey);
        }

        public void ClearError(string sProcessKey)
        {
            ucErrorPanelS.ClearErrorListPanelS(sProcessKey);
            ucErrorAlarmView.ClearPlcError(sProcessKey);
        }

        public void ClearAllError()
        {
            ucErrorAlarmView.ClearAllError();
        }

        private void SetPlcErrorViewS()
        {
            try
            {
                m_dicPlcErrorView.Clear();

                if (CMultiProject.PlcLogicDataS == null || CMultiProject.PlcLogicDataS.Count == 0)
                    return;

                List<string> lstPlcName = new List<string>();
                CPlcErrorView cView = null;
                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    lstPlcName.Add(who.Value.PlcName);

                    cView = new CPlcErrorView();
                    cView.PlcKey = who.Key;
                    cView.PlcName = who.Value.PlcName;
                    cView.TotalCount = 0;

                    m_dicPlcErrorView.Add(who.Key, cView);
                }

                grdLine.DataSource = m_dicPlcErrorView.Values.ToList();
                grdLine.RefreshDataSource();

                AdjustGridHeight();

                if (lstPlcName.Count > 0)
                {
                    ucErrorAlarmView.SetPlcView(lstPlcName);
                    ucErrorChartS.SetPlcViewS(lstPlcName);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("UCAllErrorAlarmView", ex.Message);
                ex.Data.Clear();
            }
        }

        private int GetRowHeight(int iRowHandle)
        {
            GridViewInfo viewInfo = grvLine.GetViewInfo() as GridViewInfo;
            return viewInfo.CalcRowHeight(CreateGraphics(), iRowHandle, 0);
        }

        private void AdjustGridHeight()
        {
            int iHeight = 0;
            int iRowCount = grvLine.RowCount + 1;

            iHeight = iRowCount * 35;

            grdLine.Height = iHeight;
            grdLine.Refresh();

            pnlGrid.Height = iHeight;
        }

        private void ucWidget_UEventErrorPanelDoubleClicked()
        {
            if (UEventPanelDoubleClick != null)
                UEventPanelDoubleClick();
        }

        private void ucWidget_UEventErrorPanelClicked(string sProcessKey)
        {
            if (UEventPanelClick != null)
                UEventPanelClick(sProcessKey);
        }

        private void ucWidget_UEventErrorAllPanelDoubleClicked(string sProcessKey)
        {
            if (UEventAllPanelDoubleClick != null)
                UEventAllPanelDoubleClick(sProcessKey);
        }

        private void btnErrorClear_Click(object sender, EventArgs e)
        {
            ucErrorAlarmView.ClearAllError();
            ucErrorPanelS.ClearPanelS();
        }

        private void UCAllErrorAlarmView_Load(object sender, EventArgs e)
        {
            ucErrorAlarmView.UEventAllPanelDoubleClick += ucWidget_UEventErrorAllPanelDoubleClicked;
            ucErrorAlarmView.UEventPanelClick += ucWidget_UEventErrorPanelClicked;
            ucErrorAlarmView.UEventPanelDoubleClick += ucWidget_UEventErrorPanelDoubleClicked;
            m_iMainSplitPos = sptMain.SplitterPosition;
            m_iErrorSplitPos = sptErrorInfo.SplitterPosition;
        }

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iMainSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iMainSplitPos;
        }

        private void sptErrorInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptErrorInfo.SplitterPosition > 0)
            {
                m_iErrorSplitPos = sptErrorInfo.SplitterPosition;
                sptErrorInfo.SplitterPosition = 0;
            }
            else
                sptErrorInfo.SplitterPosition = m_iErrorSplitPos;
        }
    }

    public class CPlcErrorView
    {
        private int m_iLastErrorID = -1;

        public string PlcKey { get; set; }
        public string PlcName { get; set; }
        public int TotalCount { get; set; }

        public int LastErrorID
        {
            get { return m_iLastErrorID; }
            set { m_iLastErrorID = value; }
        }

        public string ProcessName { get; set; }

        public DateTime LastTime { get; set; }
    }


}
