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

namespace UDMTrackerSimple
{
    public partial class UCRobotCycle : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private CTagS m_cTagS = null;
        private Dictionary<string, int> m_dicCycleCount = new Dictionary<string, int>();

        private delegate void CUpdateRobotCycleCallback(List<string> lstTagKey);


        #endregion


        #region Initialize

        public UCRobotCycle()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CTagS CycleTagS
        {
            get { return m_cTagS; }
            set
            {
                m_cTagS = value;
                Clear();
                SetGroup();
            }
        }

        public Dictionary<string, int> CycleCountList
        {
            get { return m_dicCycleCount; }
        }

        #endregion

        public void Clear()
        {
            if (pnlView.Controls.Count > 0)
            {
                foreach(Control control in pnlView.Controls)
                    control.Dispose();

                pnlView.Controls.Clear();
            }
        }

        private void SetGroup()
        {
            if (m_cTagS == null || m_cTagS.Count == 0) return;
            if (pnlView.Controls.Count > 0)
            {
                foreach (Control control in pnlView.Controls)
                    control.Dispose();

                pnlView.Controls.Clear();
                pnlView.Refresh();
            }

            foreach (var who in m_cTagS)
            {
                UCRobotCycleItem ucRbtItem = new UCRobotCycleItem();
                ucRbtItem.ClearData();
                ucRbtItem.RbtTag = who.Value;
                ucRbtItem.Dock = DockStyle.Top;
                pnlView.Controls.Add(ucRbtItem);
            }
            for (int i = 0; i < pnlView.Controls.Count; i++)
                pnlView.Controls[i].BringToFront();
        }

        public void SetActiveTagS(List<string> lstTagKey)
        {
            if (this.InvokeRequired)
            {
                CUpdateRobotCycleCallback cUpdate = new CUpdateRobotCycleCallback(SetActiveTagS);
                this.Invoke(cUpdate, new object[] { lstTagKey });
            }
            else
            {
                ControlCollection controls = pnlView.Controls;
                try
                {
                    Control control;
                    for (int i = 0; i < controls.Count; i++)
                    {
                        control = controls[i];
                        if (control.GetType() == typeof(UCRobotCycleItem))
                        {
                            UCRobotCycleItem ucRbtItem = (UCRobotCycleItem)control;
                            if (lstTagKey.Contains(ucRbtItem.RbtTag.Key))
                            {
                                ucRbtItem.SetActive();
                                if (m_dicCycleCount.ContainsKey(ucRbtItem.RbtTag.Key) == false)
                                    m_dicCycleCount.Add(ucRbtItem.RbtTag.Key, 0);
                                else
                                    m_dicCycleCount[ucRbtItem.RbtTag.Key]++;
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                }
            }
        }

        public void StopMonitor()
        {
            ControlCollection controls = pnlView.Controls;
            Control control;
            for (int i = 0; i < controls.Count; i++)
            {
                control = controls[i];
                if (control.GetType() == typeof(UCRobotCycleItem))
                {
                    UCRobotCycleItem ucRbtItem = (UCRobotCycleItem)control;
                    ucRbtItem.StopMonitor();
                }
            }
        }

        public void StopNotActiveTag(List<string> lstKey)
        {
            ControlCollection controls = pnlView.Controls;
            Control control;
            for (int i = 0; i < controls.Count; i++)
            {
                control = controls[i];
                if (control.GetType() == typeof(UCRobotCycleItem))
                {
                    UCRobotCycleItem ucRbtItem = (UCRobotCycleItem)control;
                    if (lstKey.Contains(ucRbtItem.RbtTag.Key))
                    {
                        ucRbtItem.StopNotActiveTag();
                    }
                }
            }
        }

        public void HideNotActiveControl(List<string> lstKey)
        {
            if (this.InvokeRequired)
            {
                CUpdateRobotCycleCallback cUpdate = new CUpdateRobotCycleCallback(HideNotActiveControl);
                this.Invoke(cUpdate, new object[] { lstKey });
            }
            else
            {
                ControlCollection controls = pnlView.Controls;
                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCRobotCycleItem))
                    {
                        UCRobotCycleItem ucRbtItem = (UCRobotCycleItem)control;
                        if (lstKey.Contains(ucRbtItem.RbtTag.Key))
                        {
                            ucRbtItem.Visible = false;
                        }
                    }
                }
            }
        }
    }
}
