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
    public partial class UCProcessCycleStatisticS : DevExpress.XtraEditors.XtraUserControl
    {
        private Dictionary<string, CCycleInfoS> m_dicTotalCycleInfoS = null;
        private List<CPlcProc> m_cProcessS = null;

        public event UEventHandlerScrollBarMoved UEventScrollBarMoved = null;

        private delegate void UpdateStatisticViewCallback(int iIndex);
        private delegate void UpdateScrollMoveCallback(int iPosition);
        private delegate void UpdateScrollMoveCallback2(object sender, MouseEventArgs e);

        protected int m_iMinHeight = 200;

        public UCProcessCycleStatisticS()
        {
            InitializeComponent();
        }

        public Dictionary<string, CCycleInfoS> TotalCycleInfoS
        {
            get { return m_dicTotalCycleInfoS; }
            set { m_dicTotalCycleInfoS = value; }
        }

        public List<CPlcProc> ProcessS
        {
            get { return m_cProcessS; }
            set
            {
                m_cProcessS = value;
                ClearControl();
                SetGroupS();
            }
        }

        public void ClearControl()
        {
            if (this.Controls != null && this.Controls.Count > 0)
            {
                foreach (Control control in this.Controls)
                    control.Dispose();

                this.Controls.Clear();
            }
        }

        public void SetScrollPosition(int iYPosition)
        {
            if (this.InvokeRequired)
            {
                UpdateScrollMoveCallback cUpdate = new UpdateScrollMoveCallback(SetScrollPosition);
                this.Invoke(cUpdate, new object[] { iYPosition });
            }
            else
            {
                this.VerticalScroll.Value = iYPosition;
            }
        }

        public void GenerateStatisticViewEvent(int iSelectedIndex)
        {
            if (this.InvokeRequired)
            {
                UpdateStatisticViewCallback cUpdate = new UpdateStatisticViewCallback(GenerateStatisticViewEvent);
                this.Invoke(cUpdate, new object[] {iSelectedIndex});
            }
            else
            {
                ControlCollection controls = this.Controls;

                Control control;
                UCProcessCycleStatistic ucView = null;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof (UCProcessCycleStatistic))
                    {
                        ucView = (UCProcessCycleStatistic) control;
                        ucView.GenerateStatisticViewEvent(iSelectedIndex);
                    }
                }

                ucView = null;
            }
        }

        public void UpdateCycleStatisticInfo(CCycleInfo cInfo)
        {
            try
            {
                if (!this.Controls.ContainsKey(cInfo.GroupKey))
                    return;

                Control control = this.Controls[cInfo.GroupKey];

                UCProcessCycleStatistic ucView = (UCProcessCycleStatistic)control;

                if (ucView.GroupKey == cInfo.GroupKey)
                    ucView.UpdateCycleInfoStatistic(cInfo);

                //for (int i = 0; i < controls.Count; i++)
                //{
                //    control = controls[i];
                //    if (control.GetType() == typeof(UCProcessCycleStatistic))
                //    {
                //        UCProcessCycleStatistic ucView = (UCProcessCycleStatistic) control;

                //        if (ucView.GroupKey == cInfo.GroupKey)
                //        {
                //            ucView.UpdateCycleInfoStatistic(cInfo);
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

        private void SetGroupS()
        {
            if (m_cProcessS == null)
                return;

            foreach (var who in m_cProcessS)
            {
                if(!who.IsErrorMonitoring)
                    AddGroup(who.Name);
            }
            for (int i = 0; i < this.Controls.Count; i++)
                this.Controls[i].BringToFront();

        }

        private void AddGroup(string sGroupKey)
        {
            try
            {
                if (m_dicTotalCycleInfoS == null)
                    return;

                UCProcessCycleStatistic ucViewer = new UCProcessCycleStatistic();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Top;
                pnlSplitter.Height = 5;

                ucViewer.GroupKey = sGroupKey;
                ucViewer.Dock = DockStyle.Top;
                ucViewer.Name = sGroupKey;
                ucViewer.MouseWheel += UCGroupCycleStatisticS_MouseWheel;

                if(m_dicTotalCycleInfoS.ContainsKey(sGroupKey))
                    ucViewer.CycleInfoS = m_dicTotalCycleInfoS[sGroupKey];

                ucViewer.Height = m_iMinHeight;

                this.Controls.Add(pnlSplitter);
                this.Controls.Add(ucViewer);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UCGroupCycleStatisticS_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateScrollMoveCallback2 cUpdate = new UpdateScrollMoveCallback2(UCGroupCycleStatisticS_MouseWheel);
                    this.Invoke(cUpdate, new object[] { sender, e });
                }
                else
                {
                    int iPosition = this.VerticalScroll.Value - e.Delta;

                    if (iPosition > this.VerticalScroll.Maximum)
                        iPosition = this.VerticalScroll.Maximum;
                    else if (iPosition < this.VerticalScroll.Minimum)
                        iPosition = this.VerticalScroll.Minimum;

                    this.VerticalScroll.Value = iPosition;

                    if (UEventScrollBarMoved != null)
                        UEventScrollBarMoved(this.VerticalScroll.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCGroupCycleStatisticS_Load(object sender, EventArgs e)
        {

        }

        private void UCProcessCycleStatisticS_Scroll(object sender, ScrollEventArgs e)
        {
            if (UEventScrollBarMoved != null)
                UEventScrollBarMoved(this.VerticalScroll.Value);
        }


    }
}
