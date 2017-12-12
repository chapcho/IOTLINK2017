using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCCycleInfo : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private int m_iSplitPos = 0;
        protected string m_sGroupName = "";
        protected CCycleInfo m_cCycleInfo = new CCycleInfo();
        protected delegate void UpdateGrid(CCycleInfo cCycleInfo);

        #endregion


        #region initialize

        public UCCycleInfo()
        {
            InitializeComponent();

            grpMain.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grdCycleInfo.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grvCycleInfo.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grdCycleInfo2.MouseWheel += new MouseEventHandler(All_MouseWheel);
            grvCycleInfo2.MouseWheel += new MouseEventHandler(All_MouseWheel);
            gaugeStart.MouseWheel += new MouseEventHandler(All_MouseWheel);
            gaugeStop.MouseWheel += new MouseEventHandler(All_MouseWheel);
        }

        #endregion


        #region Properties

        public string GroupName
        {
            get { return m_sGroupName; }
            set
            {
                m_sGroupName = value;
                grpMain.Text = "  "+m_sGroupName;
            }
        }

        public CCycleInfo CycleInfo
        {
            get { return m_cCycleInfo; }
            set 
            { 
                m_cCycleInfo = value;
                m_cCycleInfo.GroupKey = m_sGroupName;
                UpdateGridView(m_cCycleInfo);
            }
        }

        public EMCycleRunType RunType
        {
            set
            {
                EMCycleRunType emType = value;
                if (emType == EMCycleRunType.Start)
                {
                    stateIndicatorStart.StateIndex = 3;
                    stateIndicatorStop.StateIndex = 0;
                }
                else if (emType == EMCycleRunType.End)
                {
                    stateIndicatorStart.StateIndex = 0;
                    stateIndicatorStop.StateIndex = 2;
                }
            }
        }

        #endregion


        #region Public Method

        private void UpdateGridView(CCycleInfo cCycleInfo)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateGrid cbUpdateText = new UpdateGrid(UpdateGridView);
                    this.Invoke(cbUpdateText, new object[] {cCycleInfo});
                }
                else
                {
                    List<CCycleInfo> lstCycleInfo = new List<CCycleInfo>();
                    lstCycleInfo.Add(cCycleInfo);
                    grdCycleInfo.DataSource = lstCycleInfo;
                    grdCycleInfo2.DataSource = lstCycleInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void RefreshGrid()
        {
            try
            {
                grdCycleInfo.RefreshDataSource();
                grdCycleInfo2.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void All_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseWheel(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grpMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                HatchBrush brush = new HatchBrush(HatchStyle.LargeGrid, Color.YellowGreen, Color.YellowGreen);
                Rectangle rect = grpMain.ClientRectangle;
                rect.Height = 22;
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.DrawString(grpMain.Text, grpMain.AppearanceCaption.Font, Brushes.Black, rect);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }
    }
}
