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

namespace UDMLadderTracker
{
    public partial class UCErrorListPanelS : DevExpress.XtraEditors.XtraUserControl
    {
        private int m_iScrollPos = -1;

        private delegate void CUpdateErrorListPanelSCallback(CErrorInfo cInfo);
        private delegate void CUpdateErrorListPanelSCallback2(string sProcessKey);

        public event UEventHandlerErrorLogGridDoubleClick UEventErrorPanelDoubleClicked = null;

        public UCErrorListPanelS()
        {
            InitializeComponent();
        }

        public void ClearPanelS()
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
        }

        public void SetErrorListPanelS()
        {
            UCErrorListPanel ucPanel = null;
            SplitterControl stp = null;

            int iCount = 0;

            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                stp = new SplitterControl();
                stp.Dock = DockStyle.Top;

                ucPanel = new UCErrorListPanel();
                ucPanel.SetErrorListPanel(cProcess.Name);
                ucPanel.UEventErrorPanelDoubleClicked += ucErrorListPanel_GridDoubleClick;
                ucPanel.Dock = DockStyle.Top;

                if (iCount%2 == 0)
                {
                    panel1.Controls.Add(stp);
                    panel1.Controls.Add(ucPanel);
                }
                else
                {
                    panel2.Controls.Add(stp);
                    panel2.Controls.Add(ucPanel);
                }
                iCount++;
            }
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
                bool bFind = false;
                UCErrorListPanel ucPanel = null;

                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].GetType() != typeof(UCErrorListPanel))
                        continue;

                    ucPanel = (UCErrorListPanel)panel1.Controls[i];

                    if (ucPanel.ProcessKey == cInfo.GroupKey)
                    {
                        ucPanel.UpdateErrorListPanel(cInfo);

                        m_iScrollPos = ucPanel.Location.Y;
                        panel1.AutoScrollPosition = new Point(panel1.AutoScrollPosition.X, m_iScrollPos);
                        bFind = true;
                        break;
                    }
                }

                if (!bFind)
                {
                    for (int i = 0; i < panel2.Controls.Count; i++)
                    {
                        if (panel2.Controls[i].GetType() != typeof(UCErrorListPanel))
                            continue;

                        ucPanel = (UCErrorListPanel)panel2.Controls[i];

                        if (ucPanel.ProcessKey == cInfo.GroupKey)
                        {
                            ucPanel.UpdateErrorListPanel(cInfo);
                            m_iScrollPos = ucPanel.Location.Y;
                            panel2.AutoScrollPosition = new Point(panel2.AutoScrollPosition.X, m_iScrollPos);
                            break;
                        }
                    }
                }
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
                bool bFind = false;
                UCErrorListPanel ucPanel = null;

                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    if (panel1.Controls[i].GetType() != typeof(UCErrorListPanel))
                        continue;

                    ucPanel = (UCErrorListPanel)panel1.Controls[i];

                    if (ucPanel.ProcessKey == sProcessKey)
                    {
                        ucPanel.Clear();
                        bFind = true;
                        break;
                    }
                }

                if (!bFind)
                {
                    for (int i = 0; i < panel2.Controls.Count; i++)
                    {
                        if (panel2.Controls[i].GetType() != typeof(UCErrorListPanel))
                            continue;

                        ucPanel = (UCErrorListPanel)panel2.Controls[i];

                        if (ucPanel.ProcessKey == sProcessKey)
                        {
                            ucPanel.Clear();
                            break;
                        }
                    }
                }
            }
        }

        private void ucErrorListPanel_GridDoubleClick(object sender, CErrorInfo cInfo)
        {
            if (UEventErrorPanelDoubleClicked != null)
                UEventErrorPanelDoubleClicked(sender, cInfo);
        }

        private void UCErrorListPanelS_Load(object sender, EventArgs e)
        {
            panel1.Width = (this.Width - 5)/2;
        }

        private void UCErrorListPanelS_Resize(object sender, EventArgs e)
        {
            panel1.Width = (this.Width - 5) / 2;
        }
    }
}
