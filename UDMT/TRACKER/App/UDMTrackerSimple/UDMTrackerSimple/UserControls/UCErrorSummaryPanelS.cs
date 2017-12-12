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
    public partial class UCErrorSummaryPanelS : DevExpress.XtraEditors.XtraUserControl
    {
        private delegate void CUpdateErrorListPanelSCallback(CErrorInfo cInfo);
        private delegate void CUpdateErrorListPanelSCallback2(string sProcessKey);
        private delegate void CUpdateErrorListPanelSCallback3(string sProcessKey, CErrorInfo cInfo);

        public event UEventHandlerErrorLogGridDoubleClick UEventErrorPanelDoubleClicked = null;
        public event UEventHandlerMonitorPanelDoubleClicked UEventErrorDoubleClicked = null;

        public UCErrorSummaryPanelS()
        {
            InitializeComponent();
        }

        public void ClearPanelS()
        {
            if (this.Controls.Count > 0)
            {
                foreach (Control control in this.Controls)
                    control.Dispose();

                this.Controls.Clear();
            }
        }

        public void SetErrorListPanelS()
        {
            //UCErrorListPanel ucPanel = null;
            //SplitterControl stp = null;

            //int iCount = 0;

            //foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            //{
            //    stp = new SplitterControl();
            //    stp.Dock = DockStyle.Top;

            //    ucPanel = new UCErrorListPanel();
            //    ucPanel.Name = cProcess.Name;
            //    ucPanel.SetErrorListPanel(cProcess.Name);
            //    ucPanel.UEventErrorPanelDoubleClicked += ucErrorListPanel_GridDoubleClick;
            //    ucPanel.Dock = DockStyle.Top;

            //    if (iCount%2 == 0)
            //    {
            //        panel1.Controls.Add(stp);
            //        panel1.Controls.Add(ucPanel);
            //    }
            //    else
            //    {
            //        panel2.Controls.Add(stp);
            //        panel2.Controls.Add(ucPanel);
            //    }
            //    iCount++;
            //}
        }

        public void UpdateErrorListPanelS(CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorListPanelSCallback cUpdate = new CUpdateErrorListPanelSCallback(UpdateErrorListPanelS);
                this.Invoke(cUpdate, new object[] {cInfo});
            }
            else
            {
                if (!cInfo.IsVisible)
                    return;

                UCErrorListPanel ucPanel = null;

                if (!this.Controls.ContainsKey(cInfo.GroupKey))
                {
                    SplitterControl stp = null;

                    stp = new SplitterControl();
                    stp.Name = cInfo.GroupKey + "_stp";
                    stp.Dock = DockStyle.Top;

                    ucPanel = new UCErrorListPanel();
                    ucPanel.Name = cInfo.GroupKey;
                    ucPanel.Dock = DockStyle.Top;
                    ucPanel.UEventErrorDoubleClicked += ucErrorListPanel_ErrorGridDoubleClick;

                    this.Controls.Add(stp);
                    this.Controls.Add(ucPanel);
                }
                else
                {
                    ucPanel = (UCErrorListPanel) this.Controls[cInfo.GroupKey];

                    foreach (Control control in this.Controls)
                    {
                        if (control.Name != cInfo.GroupKey)
                            control.BringToFront();
                    }
                }

                ucPanel.SetErrorListPanel(cInfo.GroupKey);
                ucPanel.UpdateErrorListPanel(cInfo);
            }
        }

        public void UpdatePlcErrorListPanelS(string sPlcName, CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorListPanelSCallback3 cUpdate = new CUpdateErrorListPanelSCallback3(UpdatePlcErrorListPanelS);
                this.Invoke(cUpdate, new object[] { sPlcName, cInfo });
            }
            else
            {
                if (!cInfo.IsVisible)
                    return;

                UCErrorListPanel ucPanel = null;

                if (!this.Controls.ContainsKey(cInfo.GroupKey))
                {
                    SplitterControl stp = null;

                    stp = new SplitterControl();
                    stp.Name = cInfo.GroupKey + "_stp";
                    stp.Dock = DockStyle.Top;

                    ucPanel = new UCErrorListPanel();
                    ucPanel.Name = cInfo.GroupKey;
                    ucPanel.Dock = DockStyle.Top;
                    ucPanel.UEventErrorDoubleClicked += ucErrorListPanel_ErrorGridDoubleClick;

                    this.Controls.Add(stp);
                    this.Controls.Add(ucPanel);
                }
                else
                    ucPanel = (UCErrorListPanel)this.Controls[cInfo.GroupKey];

                ucPanel.SetErrorListPanel(sPlcName, cInfo.GroupKey);
                ucPanel.UpdateErrorListPanel(cInfo);
            }
        }

        public void ClearErrorListPanelS(string sProcessKey)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorListPanelSCallback2 cUpdate = new CUpdateErrorListPanelSCallback2(ClearErrorListPanelS);
                this.Invoke(cUpdate, new object[] {sProcessKey});
            }
            else
            {
                UCErrorListPanel ucPanel = null;

                if(this.Controls.ContainsKey(sProcessKey))
                    ucPanel = (UCErrorListPanel)this.Controls[sProcessKey];

                if (ucPanel != null)
                {
                    ucPanel.Clear();
                    ucPanel.Dispose();
                }

                this.Controls.RemoveByKey(sProcessKey);
                this.Controls.RemoveByKey(sProcessKey + "_stp");
            }
        }

        private void ucErrorListPanel_ErrorGridDoubleClick()
        {
            if (UEventErrorDoubleClicked != null)
                UEventErrorDoubleClicked();

        }
    }
}
