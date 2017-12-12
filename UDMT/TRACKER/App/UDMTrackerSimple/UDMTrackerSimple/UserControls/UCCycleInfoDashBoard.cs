using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCCycleInfoDashBoard : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected int m_iMinHeight = 200;
        protected List<CPlcProc> m_cPlcProcS = null;

        public event UEventHandlerScrollBarMoved UEventScrollBarMoved = null;
        private delegate void UpdateScrollMoveCallback(int iPosition);
        private delegate void UpdateScrollMoveCallback2(object sender, MouseEventArgs e);

        #endregion


        #region Initialize

        public UCCycleInfoDashBoard()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public List<CPlcProc> PlcProcS
        {
            get { return m_cPlcProcS; }
            set
            {
                m_cPlcProcS = value;
                ClearControl();
                SetGroupS();
            }
        }

        #endregion


        #region Private Methods

        private void AddGroup(string sGroupKey)
        {
            try
            {
                UCCycleInfo ucViewer = new UCCycleInfo();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Top;
                pnlSplitter.Height = 5;

                ucViewer.GroupName = sGroupKey;
                ucViewer.CycleInfo = new CCycleInfo();
                ucViewer.Dock = DockStyle.Top;
                ucViewer.Height = m_iMinHeight;
                ucViewer.Name = sGroupKey;
                ucViewer.RefreshGrid();
                ucViewer.MouseWheel += UCCycleBoard_MouseWheel;

                pnlView.Controls.Add(pnlSplitter);
                pnlView.Controls.Add(ucViewer);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UCCycleBoard_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(UCCycleBoard_MouseWheel);
                    this.Invoke(cUpdate, new object[] { sender, e });
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


        private void RemoveGroup(string sName)
        {
            pnlView.Controls.RemoveByKey(sName);
        }


        private void SetGroupS()
        {
            try
            {
                if (m_cPlcProcS == null) return;
                foreach (var who in m_cPlcProcS)
                {
                    if(!who.IsErrorMonitoring)
                        AddGroup(who.Name);
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
                int iUnitHeight = 0;
                if (controls.Count > 7)
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / controls.Count;
                else
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / 8;
                if (iUnitHeight < m_iMinHeight)
                    iUnitHeight = m_iMinHeight;

                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessErrorTagGrid))
                        control.Height = iUnitHeight - 5;
                }

                pnlView.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion


        #region Public Method

        public void SetScrollPosition(int iYPosition)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
        public void UpdateCycleInfoS(string sProcessKey, CCycleInfo cCycleInfo)
        {
            //ControlCollection controls = pnlView.Controls;
            try
            {
                if (!pnlView.Controls.ContainsKey(sProcessKey))
                    return;

                Control control = pnlView.Controls[sProcessKey];

                UCCycleInfo ucView = (UCCycleInfo)control;
                ucView.CycleInfo = cCycleInfo;
                ucView.RefreshGrid();

                //for (int i = 0; i < controls.Count; i++)
                //{
                //    control = controls[i];
                //    if (control.GetType() == typeof(UCCycleInfo))
                //    {
                //        UCCycleInfo ucView = (UCCycleInfo)control;
                //        if (ucView.GroupName == sProcessKey)
                //        {
                //            ucView.CycleInfo = cCycleInfo;
                //            ucView.RefreshGrid();
                //            break;
                //        }
                        
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void UpdateCycleState(string sProcessKey, EMCycleRunType emType)
        {
            //ControlCollection controls = pnlView.Controls;
            try
            {
                if (!pnlView.Controls.ContainsKey(sProcessKey))
                    return;

                Control control = pnlView.Controls[sProcessKey];
                UCCycleInfo ucView = (UCCycleInfo)control;
                ucView.RunType = emType;

                //Production State Info에 CycleInfo 전달
                //foreach (Form frm in Application.OpenForms)
                //{
                //    if (frm.GetType() == typeof(FrmProductionStateInfo))
                //    {
                //        FrmProductionStateInfo frmProductioninfo = (FrmProductionStateInfo)frm;
                //        if (frmProductioninfo.PlcProcName == sProcessKey)
                //            frmProductioninfo.ChangedLineState(emType);
                //    }
                //}

                //for (int i = 0; i < controls.Count; i++)
                //{
                //    control = controls[i];
                //    if (control.GetType() == typeof(UCCycleInfo))
                //    {
                //        UCCycleInfo ucView = (UCCycleInfo)control;
                //        if (ucView.GroupName == sProcessKey)
                //        {
                //            ucView.RunType = emType;
                //            break;
                //        }

                //    }
                //}
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void ClearControl()
        {
            try
            {
                if (pnlView.Controls != null && pnlView.Controls.Count > 0)
                {
                    foreach (Control control in pnlView.Controls)
                        control.Dispose();

                    pnlView.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void pnlView_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (UEventScrollBarMoved != null)
                    UEventScrollBarMoved(pnlView.VerticalScroll.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
        
    }
}
