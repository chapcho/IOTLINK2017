using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerScrollBarMoved(int iYPosition);
    public delegate void UEventHandlerScrollBarManualMoved(int iDelta);

    public partial class UCProcessCycleBoardS : DevExpress.XtraEditors.XtraUserControl
    {
        protected Timer m_tmrTicker = new Timer();
        protected int m_iRowCount = -1;
        protected int m_iMinHeight = 205;
        private List<string> m_lstProcessKey = new List<string>();

        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;

        public event UEventHandlerScrollBarMoved UEventScrollBarMoved = null;

        private delegate void UpdateScrollMoveCallback(int iPosition);
        private delegate void UpdateScrollMoveCallback2(object sender, MouseEventArgs e);

        public UCProcessCycleBoardS()
        {
            InitializeComponent();
        }

        #region Public Properties

        #endregion

        #region Public Methods

        public void ShowBoard(string sPlcKey)
        {
            Clear();
            SetGroupS(sPlcKey);
        }

        public void ShowBoard()
        {
            Clear();
            SetGroupS();
        }

        public void Clear()
        {
            if (pnlView.Controls.Count > 0)
            {
                foreach(Control control in pnlView.Controls)
                    control.Dispose();

                pnlView.Controls.Clear();
            }

            pnlView.Refresh();
        }

        public void Run()
        {
            try
            {
                m_tmrTicker.Interval = 1000;
                m_tmrTicker.Tick += m_tmrTicker_Tick;
                m_tmrTicker.Start();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void ClearTimerValue()
        {
            try
            {
                UCProcessCycleBoard ucUnit = null;
                foreach (string sKey in m_lstProcessKey)
                {
                    if (!pnlView.Controls.ContainsKey(sKey))
                        continue;

                    ucUnit = (UCProcessCycleBoard)pnlView.Controls[sKey];
                    ucUnit.Clear();
                }

                ucUnit = null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                if (m_tmrTicker.Enabled)
                    m_tmrTicker.Stop();

                m_tmrTicker.Tick -= m_tmrTicker_Tick;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void SetScrollPosition(int iYPosition)
        {
            if (this.InvokeRequired)
            {
                UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(SetScrollPosition);
                this.Invoke(cUpdate, new object[] {iYPosition});
            }
            else
            {
                pnlView.VerticalScroll.Value = iYPosition;
            }
        }

        #endregion

        #region Private Methods

        private void AddGroup(CPlcProc cProcess)
        {
            try
            {
                UCProcessCycleBoard ucViewer = new UCProcessCycleBoard();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Top;
                pnlSplitter.Height = 5;

                ucViewer.Name = cProcess.Name;
                ucViewer.Title = cProcess.Name;
                ucViewer.Dock = DockStyle.Top;
                ucViewer.MaxCycleTime = cProcess.TargetTactTime / 1000;
                ucViewer.Height = m_iMinHeight;
                ucViewer.MouseDown += ucProcessCycleBoard_MouseDown;
                ucViewer.MouseUp += ucProcessCycleBoard_MouseUp;
                ucViewer.MouseMove += ucProcessCycleBoard_MouseMove;
                ucViewer.MouseWheel += UCProcessCycleBoard_MouseWheel;

                pnlView.Controls.Add(pnlSplitter);
                pnlView.Controls.Add(ucViewer);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UCProcessCycleBoard_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(UCProcessCycleBoard_MouseWheel);
                    this.Invoke(cUpdate, new object[] {sender, e});
                }
                else
                {
                    int iPosition = pnlView.VerticalScroll.Value - e.Delta;

                    if (iPosition > pnlView.VerticalScroll.Maximum)
                        iPosition = pnlView.VerticalScroll.Maximum;
                    else if (iPosition < pnlView.VerticalScroll.Minimum)
                        iPosition = pnlView.VerticalScroll.Minimum;

                    pnlView.VerticalScroll.Value = iPosition;

                    if (UEventScrollBarMoved != null)
                        UEventScrollBarMoved(pnlView.VerticalScroll.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucProcessCycleBoard_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucProcessCycleBoard_MouseDown);
                    this.Invoke(cUpdate, new object[] {sender, e});
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

        private void ucProcessCycleBoard_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucProcessCycleBoard_MouseUp);
                    this.Invoke(cUpdate, new object[] {sender, e});
                }
                else
                {
                    m_bScrollMove = false;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = pnlView.VerticalScroll.Value + iDelta;

                    if (iPosition > pnlView.VerticalScroll.Maximum)
                        iPosition = pnlView.VerticalScroll.Maximum;
                    else if (iPosition < pnlView.VerticalScroll.Minimum)
                        iPosition = pnlView.VerticalScroll.Minimum;

                    pnlView.VerticalScroll.Value = iPosition;
                    //m_iScrollPosition = iPosition;

                    if (UEventScrollBarMoved != null)
                        UEventScrollBarMoved(pnlView.VerticalScroll.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucProcessCycleBoard_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(ucProcessCycleBoard_MouseMove);
                    this.Invoke(cUpdate, new object[] {sender, e});
                }
                else
                {
                    if (!m_bScrollMove)
                        return;

                    int iDelta = m_iScrollPosition - Cursor.Position.Y;
                    int iPosition = pnlView.VerticalScroll.Value + iDelta;

                    if (iPosition > pnlView.VerticalScroll.Maximum)
                        iPosition = pnlView.VerticalScroll.Maximum;
                    else if (iPosition < pnlView.VerticalScroll.Minimum)
                        iPosition = pnlView.VerticalScroll.Minimum;

                    pnlView.VerticalScroll.Value = iPosition;
                    m_iScrollPosition = Cursor.Position.Y;

                    if (UEventScrollBarMoved != null)
                        UEventScrollBarMoved(pnlView.VerticalScroll.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void RemoveGroup(string sName)
        {
            pnlView.Controls.RemoveByKey(sName);
        }

        private void SetGroupS(string sPlcKey)
        {
            try
            {
                m_lstProcessKey.Clear();

                CPlcProc cProcess;
                for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
                {
                    cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                    if (!cProcess.PlcLogicDataS.ContainsKey(sPlcKey))
                        continue;

                    if (!cProcess.IsErrorMonitoring)
                    {
                        m_lstProcessKey.Add(cProcess.Name);
                        AddGroup(cProcess);
                    }
                }
                for (int i = 0; i < pnlView.Controls.Count; i++)
                    pnlView.Controls[i].BringToFront();

                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void SetGroupS()
        {
            try
            {
                m_lstProcessKey.Clear();

                CPlcProc cProcess;
                for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
                {
                    cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                    if (!cProcess.IsErrorMonitoring)
                    {
                        m_lstProcessKey.Add(cProcess.Name);
                        AddGroup(cProcess);
                    }
                }
                for (int i = 0; i < pnlView.Controls.Count; i++)
                    pnlView.Controls[i].BringToFront();

                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        private void SetUnitSize()
        {
            ControlCollection controls = pnlView.Controls;
            if (controls.Count == 0)
                return;

            try
            {
                //int iUnitHeight = 0;
                //if (controls.Count > 7)
                //    iUnitHeight = this.Height * 2 / controls.Count;
                //else
                //    iUnitHeight = this.Height * 2 / 8;
                //if (iUnitHeight < m_iMinHeight)
                //    iUnitHeight = m_iMinHeight;

                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessCycleBoard))
                        control.Height = m_iMinHeight - 5;
                }

                pnlView.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Event Methods

        private void UCGroupStateChart_Load(object sender, EventArgs e)
        {

        }

        private void UCGroupStateChart_Resize(object sender, EventArgs e)
        {
            try
            {
                //SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void UpdateCycleStart(string sProcessKey, DateTime dtStart)
        {
            if (pnlView.Controls.ContainsKey(sProcessKey) == false) return;

            UCProcessCycleBoard ucUnit = (UCProcessCycleBoard)pnlView.Controls[sProcessKey];
            
            ucUnit.CycleStartTime = dtStart;
            ucUnit.SetGroupStatus(EMGroupStateType.Start, 0);
        }

        public void UpdateCycleEnd(string sProcessKey, DateTime dtEnd, bool bCycleOver, int iMaxTime)
        {
            if (pnlView.Controls.ContainsKey(sProcessKey) == false) return;

            UCProcessCycleBoard ucUnit = (UCProcessCycleBoard)pnlView.Controls[sProcessKey];
            if (ucUnit.CycleStartTime == DateTime.MinValue) return;
            try
            {
                EMGroupStateType emType = EMGroupStateType.End;

                int iMaxTimeSecond = iMaxTime/1000;

                //Error 표시
                double nDuration = dtEnd.Subtract(ucUnit.CycleStartTime).TotalSeconds;

                if (bCycleOver || iMaxTimeSecond < nDuration)
                    ucUnit.SetGroupStatus(EMGroupStateType.ErrorEnd, 0);
                else
                    ucUnit.SetGroupStatus(emType, nDuration);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void UpdateCycleOver(string sProcessKey)
        {
            if (pnlView.Controls.ContainsKey(sProcessKey) == false) return;

            UCProcessCycleBoard ucUnit = (UCProcessCycleBoard)pnlView.Controls[sProcessKey];
            ucUnit.SetGroupStatus(EMGroupStateType.Error, 0);
        }

        private void m_tmrTicker_Tick(object sender, EventArgs e)
        {
            m_tmrTicker.Stop();

            double nElapseTime = (double)m_tmrTicker.Interval / 1000;

            try
            {
                UCProcessCycleBoard ucUnit = null;
                foreach(string sKey in m_lstProcessKey)
                {
                    if (!pnlView.Controls.ContainsKey(sKey))
                        continue;

                    ucUnit = (UCProcessCycleBoard)pnlView.Controls[sKey];
                    ucUnit.ElapseTime();
                }

                ucUnit = null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            m_tmrTicker.Start();
        }

        #endregion

        private void pnlView_Scroll(object sender, ScrollEventArgs e)
        {
            if (UEventScrollBarMoved != null)
                UEventScrollBarMoved(pnlView.VerticalScroll.Value);
        }
    }
}

