using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;
using DevExpress.XtraTab;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerManualCycleOver(string sProcess);
    public delegate void UEventHandlerManualCycleOverTagKey(string sProcessKey, string sTagKey);


    public partial class UCFlowPanelS : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private bool m_bRun = false;
        private int m_iScrollPos = 0;
        private CPlcProc m_cProcess = null;
        private List<UCFlowPanel> m_lstFlowPanel = new List<UCFlowPanel>();

        private bool m_bCycleStart = false;

        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;

        private delegate void CShowFlowChartCallback();
        private delegate void CClearFlowChartCallback();
        private delegate void CCycleOverCallback();
        private delegate void CUpdateFlowChartCallback(CTimeLogS cLogS);
        private delegate void CUpdateRecipeCallback(string sRecipe);
        private delegate void CUpdateRecipePanelCallback(UCFlowPanel ucPanel);
        private delegate void UpdateScrollMoveCallback(object sender, MouseEventArgs e);

        public UEventHandlerManualCycleOver UEventManualCycleOverClicked = null;
        public UEventHandlerManualCycleOverTagKey UEventManualCycleOverTagKeyClicked = null;

        #endregion


        #region Initialize

        public UCFlowPanelS()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CPlcProc PlcProcess
        {
            get { return m_cProcess; }
            set { m_cProcess = value; }
        }

        public bool IsRunning
        {
            get { return m_bRun; }
            set { m_bRun = value; }
        }

        #endregion


        #region Public Method
        
        public void Clear()
        {
            try
            {
                if (tabFlow.TabPages.Count > 0)
                {
                    foreach (XtraTabPage tpPage in tabFlow.TabPages)
                    {
                        foreach (Control control in tpPage.Controls)
                            control.Dispose();
                    }

                    tabFlow.TabPages.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ShowFlowChartInit()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CShowFlowChartCallback cUpdate = new CShowFlowChartCallback(ShowFlowChartInit);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    Clear();
                    bool bFirst = true;
                    int iNumber = 0;
                    int iCount = 0;
                    CFlowChartItem cPrevChartItem = null;

                    foreach (var who in m_cProcess.RecipeFlowItemS)
                    {
                        XtraTabPage tabPage = new XtraTabPage();
                        tabPage.Name = "tpFlow" + iNumber.ToString();
                        iNumber++;

                        tabPage.Text = who.Key;
                        tabPage.AutoScroll = true;
                        tabPage.Appearance.Header.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        tabPage.Appearance.HeaderActive.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        tabPage.Appearance.HeaderDisabled.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        tabPage.Appearance.HeaderHotTracked.Font = new Font("Tahoma", 9, FontStyle.Bold);

                        tabFlow.TabPages.Add(tabPage);

                        bFirst = true;
                        iCount = 0;

                        for (int i = 0; i < who.Value.Count; i++)
                        {
                            UCFlowPanel ucFlowPanel = new UCFlowPanel();
                            ucFlowPanel.UEventManualCycleOver += ucFlowPanel_ManualCycleOver;
                            ucFlowPanel.Dock = DockStyle.Top;
                            ucFlowPanel.FlowItem = who.Value[i];
                            ucFlowPanel.ArrowVisible = !bFirst;

                            if (!bFirst)
                            {
                                cPrevChartItem = who.Value[i - 1];
                                double dDuration =
                                    Math.Abs(
                                        who.Value[i].FlowStartTime.Subtract(cPrevChartItem.FlowStartTime)
                                            .TotalMilliseconds);

                                if (dDuration <= 500)
                                    ucFlowPanel.ArrowPanelVisible = false;
                                else
                                    ucFlowPanel.PanelCount = iCount++;
                            }
                            else
                                ucFlowPanel.PanelCount = iCount++;

                            bFirst = false;
                            ucFlowPanel.MouseWheel += ucFlowPanel_MouseWheel;
                            ucFlowPanel.MouseDown += ucFlowPanel_MouseDown;
                            ucFlowPanel.MouseMove += ucFlowPanel_MouseMove;
                            ucFlowPanel.MouseUp += ucFlowPanel_MouseUp;
                            ucFlowPanel.SetInit();
                            tabPage.Controls.Add(ucFlowPanel);
                            m_lstFlowPanel.Add(ucFlowPanel);
                        }

                        for (int i = 0; i < tabPage.Controls.Count; i++)
                            tabPage.Controls[i].BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private int m_iScrollCount = 0;

        /// <summary>
        /// KeySymbol과 연관 있는 로그만 추출해서 받은 것
        /// </summary>
        /// <param name="cLogS"></param>
        public void UpdateFlowChart(CTimeLogS cLogS)
        {
            try
            {
                //m_cTimeLoGS 이용
                if (this.InvokeRequired)
                {
                    CUpdateFlowChartCallback cUpdate = new CUpdateFlowChartCallback(UpdateFlowChart);
                    this.Invoke(cUpdate, new object[] {cLogS});
                }
                else
                {
                    if (CheckCycleEnd(cLogS))
                        ClearActive();

                    if (!m_bCycleStart)
                    {
                        if (CheckCycleStart(cLogS))
                            m_bCycleStart = true;
                        else
                            return;
                    }

                    int iCount = 0;
                    bool bFirst = true;

                    for (int i = 0; i < cLogS.Count; i++)
                    {
                        if (!m_lstFlowPanel.Any(b => b.FlowItem.Key == cLogS[i].Key)) continue;

                        bFirst = true;

                        UCFlowPanel ucPanel =
                            m_lstFlowPanel.Where(x => x.FlowItem.Key == cLogS[i].Key)
                                .ToList()
                                .Find(x => x.FlowItem.TargetValue == cLogS[i].Value);

                        if (ucPanel == null)
                            continue;

                        if (ucPanel.FlowItem.IsComplete == false)
                        {
                            ucPanel.FlowItem.IsComplete = true;
                            ucPanel.SetActiveColor();

                            if (bFirst)
                            {
                                iCount++;
                                bFirst = false;
                            }
                        }
                        else
                        {
                            if (ucPanel.FlowItem.ConditionElement)
                            {
                                ucPanel.FlowItem.IsComplete = false;
                                ucPanel.SetOffColor();
                            }
                        }
                    }

                    m_iScrollCount += iCount;
                    if (m_iScrollCount > 3)
                    {
                        m_iScrollPos += (iCount*59);
                    }
                    this.tabFlow.SelectedTabPage.AutoScrollPosition =
                        new Point(this.tabFlow.SelectedTabPage.AutoScrollPosition.X, m_iScrollPos);

                    //this.Refresh();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateFlowChart(CTimeLog cLog)
        {
            try
            {
                if (CheckCycleEnd(cLog))
                    m_bCycleStart = false;
                //    ClearActive();

                if (!m_bCycleStart)
                {
                    if (CheckCycleStart(cLog))
                    {
                        ClearActive();
                        m_bCycleStart = true;
                    }
                    //else
                    //    return;
                }

                if (!m_lstFlowPanel.Any(x => x.FlowItem.Key == cLog.Key)) return;

                List<UCFlowPanel> ucPanelS =
                    m_lstFlowPanel.Where(x => x.FlowItem.Key == cLog.Key)//.Where(x => x.FlowItem.TargetValue == cLog.Value)
                        .ToList();

                if (ucPanelS == null || ucPanelS.Count == 0)
                    return;

                bool bScrollMove = false;
                bool bArrowVisible = false;

                foreach (UCFlowPanel ucPanel in ucPanelS)
                {
                    if (ucPanel.FlowItem.IsComplete == false)
                    {
                        ucPanel.FlowItem.IsComplete = true;
                        ucPanel.SetActiveColor();

                        if (ucPanel.ArrowPanelVisible)
                            bArrowVisible = true;

                        m_iScrollCount += 1;
                        bScrollMove = true;
                    }
                    else
                    {
                        if (ucPanel.FlowItem.ConditionElement)
                        {
                            ucPanel.FlowItem.IsComplete = false;
                            ucPanel.SetOffColor();
                        }

                        bScrollMove = false;
                    }

                    if (ucPanel.FlowItem.RecipeElement && ucPanel.FlowItem.IsComplete)
                        UpdateFlowPanelRecipe(ucPanel);
                }

                if (bScrollMove && m_iScrollCount > 5)
                {
                    if (bArrowVisible)
                        m_iScrollPos += 59;
                    else
                        m_iScrollPos += 29;
                }
                this.tabFlow.SelectedTabPage.AutoScrollPosition = new Point(this.tabFlow.SelectedTabPage.AutoScrollPosition.X, m_iScrollPos);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearActive()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CClearFlowChartCallback cUpdate = new CClearFlowChartCallback(ClearActive);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    foreach (var who in m_lstFlowPanel)
                    {
                        who.SetOffColor();
                        who.FlowItem.IsComplete = false;
                    }

                    m_bCycleStart = false;
                    m_iScrollPos = 0;
                    m_iScrollCount = 0;
                    this.AutoScrollPosition = new Point(this.AutoScrollPosition.X, 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateRecipe(string sRecipe)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateRecipeCallback cUpdate = new CUpdateRecipeCallback(UpdateRecipe);
                    this.Invoke(cUpdate, new object[] {sRecipe});
                }
                else
                {
                    for (int i = 0; i < tabFlow.TabPages.Count; i++)
                    {
                        if (tabFlow.TabPages[i].Text == sRecipe && tabFlow.SelectedTabPage != tabFlow.TabPages[i])
                        {
                            if (tabFlow.TabPages[i].Controls.Count == 0) continue;
                            tabFlow.SelectedTabPage = tabFlow.TabPages[i];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UpdateFlowPanelRecipe(UCFlowPanel ucPanel)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    CUpdateRecipePanelCallback cUpdate = new CUpdateRecipePanelCallback(UpdateFlowPanelRecipe);
                    this.Invoke(cUpdate, new object[] {ucPanel});
                }
                else
                {
                    XtraTabPage tpSelectedPage = null;

                    foreach (XtraTabPage tpPage in tabFlow.TabPages)
                    {
                        if (tpPage.Controls.Contains(ucPanel))
                        {
                            tpSelectedPage = tpPage;
                            break;
                        }
                    }

                    if (tpSelectedPage != null)
                        tabFlow.SelectedTabPage = tpSelectedPage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucFlowPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucFlowPanel_MouseWheel);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    SetScrollPosition(e.Delta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucFlowPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucFlowPanel_MouseUp);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    m_bScrollMove = false;

                    XtraTabPage tpPage = tabFlow.SelectedTabPage;

                    if (tpPage == null)
                        return;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = tpPage.VerticalScroll.Value + iDelta;

                    if (iPosition > tpPage.VerticalScroll.Maximum)
                        iPosition = tpPage.VerticalScroll.Maximum;
                    else if (iPosition < tpPage.VerticalScroll.Minimum)
                        iPosition = tpPage.VerticalScroll.Minimum;

                    tpPage.VerticalScroll.Value = iPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucFlowPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucFlowPanel_MouseMove);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    if (!m_bScrollMove)
                        return;

                    XtraTabPage tpPage = tabFlow.SelectedTabPage;

                    if (tpPage == null)
                        return;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = tpPage.VerticalScroll.Value + iDelta;

                    if (iPosition > tpPage.VerticalScroll.Maximum)
                        iPosition = tpPage.VerticalScroll.Maximum;
                    else if (iPosition < tpPage.VerticalScroll.Minimum)
                        iPosition = tpPage.VerticalScroll.Minimum;

                    tpPage.VerticalScroll.Value = iPosition;
                    m_iScrollPosition = Cursor.Position.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucFlowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(ucFlowPanel_MouseDown);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    m_bScrollMove = true;
                    m_iScrollPosition = Cursor.Position.Y;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetScrollPosition(int iDelta)
        {
            try
            {
                XtraTabPage tpPage = tabFlow.SelectedTabPage;

                if (tpPage == null)
                    return;

                int iPosition = tpPage.VerticalScroll.Value - iDelta;

                if (iPosition > tpPage.VerticalScroll.Maximum)
                    iPosition = tpPage.VerticalScroll.Maximum;
                else if (iPosition < tpPage.VerticalScroll.Minimum)
                    iPosition = tpPage.VerticalScroll.Minimum;

                tpPage.VerticalScroll.Value = iPosition;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private bool CheckCycleEnd(CTimeLogS cLogS)
        {
            bool bOK = false;

            if (m_cProcess.CycleEndConditionS.Count == 0)
                return false;

            if (!cLogS.Any(x => m_cProcess.CycleEndConditionS.ContainsKey(x.Key)))
                return false;

            CTimeLog cLog = cLogS.SingleOrDefault(x => m_cProcess.CycleEndConditionS.ContainsKey(x.Key));

            if (cLog == null)
                return false;

            CCondition cCondition = m_cProcess.CycleEndConditionS.GetSelectedKeyData(cLog.Key);

            if (cLogS.Where(x => x.Key == cCondition.Key).Where(x => x.Value == cCondition.TargetValue).Count() > 0)
                bOK = true;

            cLog = null;
            cCondition = null;

            return bOK;
        }

        private bool CheckCycleEnd(CTimeLog cLog)
        {
            bool bOK = false;

            if (m_cProcess.CycleEndConditionS.Count == 0)
                return false;

            CCondition cCondition = null;
            if (m_cProcess.CycleEndConditionS.ContainsKey(cLog.Key))
            {
                cCondition = m_cProcess.CycleEndConditionS.GetSelectedKeyData(cLog.Key);

                if (cCondition.TargetValue == 100 && cLog.Value > 0)
                    bOK = true;
                else if (cLog.Value == cCondition.TargetValue)
                    bOK = true;
            }

            cCondition = null;

            return bOK;
        }

        private bool CheckCycleStart(CTimeLog cLog)
        {
            bool bOK = false;

            if (m_cProcess.CycleStartConditionS.Count == 0)
                return false;

            CCondition cCondition = null;
            if (m_cProcess.CycleStartConditionS.ContainsKey(cLog.Key))
            {
                cCondition = m_cProcess.CycleStartConditionS.GetSelectedKeyData(cLog.Key);

                if (cCondition.TargetValue == 100 && cLog.Value > 0)
                    bOK = true;
                else if (cLog.Value == cCondition.TargetValue)
                    bOK = true;
            }

            cCondition = null;

            return bOK;
        }

        private bool CheckCycleStart(CTimeLogS cLogS)
        {
            bool bOK = false;

            if (m_cProcess.CycleStartConditionS.Count == 0)
                return false;

            if (!cLogS.Any(x => m_cProcess.CycleStartConditionS.ContainsKey(x.Key)))
                return false;

            CTimeLog cLog = cLogS.SingleOrDefault(x => m_cProcess.CycleStartConditionS.ContainsKey(x.Key));

            if (cLog == null)
                return false;

            CCondition cCondition = m_cProcess.CycleStartConditionS.GetSelectedKeyData(cLog.Key);

            if (cLogS.Where(x => x.Key == cCondition.Key).Where(x => x.Value == cCondition.TargetValue).Count() > 0)
                bOK = true;

            cLog = null;
            cCondition = null;

            return bOK;
        }

        public void SetProcessCycleOver()
        {
            if (this.InvokeRequired)
            {
                CCycleOverCallback cUpdate = new CCycleOverCallback(SetProcessCycleOver);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                if (m_cProcess == null)
                    return;

                if (!m_bRun)
                {
                    XtraMessageBox.Show("해당 " + m_cProcess.Name + " 공정의 모니터링이 시작되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!m_bCycleStart)
                {
                    XtraMessageBox.Show("해당 " + m_cProcess.Name + " 공정의 Cycle이 시작되지 않았습니다.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult dlgResult = XtraMessageBox.Show("해당 " + m_cProcess.Name + " 공정의 무언 정지 상황을 수동으로 인지하시겠습니까?",
                    "무언 정지", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                if (UEventManualCycleOverClicked != null)
                    UEventManualCycleOverClicked(m_cProcess.Name);
            }
        }

        private void ucFlowPanel_ManualCycleOver(string sProcessKey, string sTagKey)
        {
            if (m_cProcess == null)
                return;

            if (!m_bRun)
            {
                XtraMessageBox.Show("해당 " + m_cProcess.Name + " 공정의 모니터링이 시작되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //if (!m_bCycleStart)
            //{
            //    XtraMessageBox.Show("해당 " + m_cProcess.Name + " 공정의 Cycle이 시작되지 않았습니다.", "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (UEventManualCycleOverTagKeyClicked != null)
                UEventManualCycleOverTagKeyClicked(m_cProcess.Name, sTagKey);
        }


        #endregion

        private void btnCycleOver_Click(object sender, EventArgs e)
        {
            try
            {
                SetProcessCycleOver();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}
