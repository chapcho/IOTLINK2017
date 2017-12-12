using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts.Design;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;
using DevExpress.XtraTab;

namespace UDMLadderTracker
{
    public partial class UCFlowPanelS : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private int m_iScrollPos = 0;
        private CPlcProc m_cProcess = null;
        private List<UCFlowPanel> m_lstFlowPanel = new List<UCFlowPanel>();
        private delegate void CShowFlowChartCallback();
        private delegate void CClearFlowChartCallback();
        private delegate void CUpdateFlowChartCallback(CTimeLogS cLogS);
        private delegate void CUpdateRecipeCallback(string sRecipe);

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

        #endregion


        #region Public Method

        public void Clear()
        {
            tabFlow.TabPages.Clear();
        }

        public void ShowFlowChartInit()
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

                foreach (var who in m_cProcess.RecipeFlowChartItemS)
                {
                    XtraTabPage tabPage = new XtraTabPage();
                    tabPage.Name = "tpFlow" + iNumber.ToString();
                    iNumber++;

                    tabPage.Text = who.Key;
                    tabPage.AutoScroll = true;
                    tabFlow.TabPages.Add(tabPage);

                    bFirst = true;

                    foreach (var who2 in who.Value)
                    {
                        UCFlowPanel ucFlowPanel = new UCFlowPanel();
                        ucFlowPanel.Dock = DockStyle.Top;
                        ucFlowPanel.FlowItem = who2.Value;
                        ucFlowPanel.ArrowVisible = !bFirst;
                        bFirst = false;
                        ucFlowPanel.PanelCount = who2.Key;
                        ucFlowPanel.SetInit();
                        tabPage.Controls.Add(ucFlowPanel);

                        m_lstFlowPanel.Add(ucFlowPanel);
                    }
                    for (int i = 0; i < tabPage.Controls.Count; i++)
                        tabPage.Controls[i].BringToFront();
                }
            }
        }

        private int m_iScrollCount =0 ;

        /// <summary>
        /// KeySymbol과 연관 있는 로그만 추출해서 받은 것
        /// </summary>
        /// <param name="cLogS"></param>
        public void UpdateFlowChart(CTimeLogS cLogS)
        {
            //m_cTimeLoGS 이용
            if (this.InvokeRequired)
            {
                CUpdateFlowChartCallback cUpdate = new CUpdateFlowChartCallback(UpdateFlowChart);
                this.Invoke(cUpdate, new object[] {cLogS });
            }
            else
            {
                int iCount = 0;
                for (int i = 0; i < cLogS.Count; i++)
                {
                    if (m_lstFlowPanel.Where(b => b.FlowItem.Key == cLogS[i].Key).Count() == 0) continue;

                    foreach (UCFlowPanel ucPanel in m_lstFlowPanel.Where( x=> x.FlowItem.Key == cLogS[i].Key))
                    {
                        if (ucPanel.FlowItem.Key == cLogS[i].Key && ucPanel.FlowItem.TargetValue == cLogS[i].Value)
                        {
                            if (ucPanel.FlowItem.IsComplete == false)
                            {
                                ucPanel.FlowItem.IsComplete = true;
                                ucPanel.SetActiveColor();
                                iCount++;
                            }
                        }  
                    }
                }
                m_iScrollCount += iCount;
                if (m_iScrollCount > 3)
                {
                    m_iScrollPos += (iCount * 59);
                }
                this.tabFlow.SelectedTabPage.AutoScrollPosition = new Point(this.tabFlow.SelectedTabPage.AutoScrollPosition.X, m_iScrollPos);

                //this.Refresh();
            }
        }

        public void ClearActive()
        {
            if (this.InvokeRequired)
            {
                CClearFlowChartCallback cUpdate = new CClearFlowChartCallback(ClearActive);
                this.Invoke(cUpdate, new object[] { });
            }
            else
            {
                foreach(var who in m_lstFlowPanel)
                {
                    who.SetOffColor();
                    who.FlowItem.IsComplete = false;
                }

                m_iScrollPos = 0;
                m_iScrollCount = 0;
                this.AutoScrollPosition = new Point(this.AutoScrollPosition.X, 0);
                //this.Refresh();
            }
        }

        public void UpdateRecipe(string sRecipe)
        {
            if (this.InvokeRequired)
            {
                CUpdateRecipeCallback cUpdate = new CUpdateRecipeCallback(UpdateRecipe);
                this.Invoke(cUpdate, new object[] { sRecipe });
            }
            else
            {
                for (int i = 0; i < tabFlow.TabPages.Count; i++)
                {
                    if (tabFlow.TabPages[i].Text == sRecipe)
                    {
                        if (tabFlow.TabPages[i].Controls.Count == 0) continue;
                        tabFlow.SelectedTabPage = tabFlow.TabPages[i];
                        break;
                    }
                }
            }
        }

        #endregion
    }
}
