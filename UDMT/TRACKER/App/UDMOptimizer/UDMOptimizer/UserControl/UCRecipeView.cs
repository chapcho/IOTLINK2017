using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMOptimizer
{
    public partial class UCRecipeView : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Varialbes

        private int m_iSplitPos = 0;
        private CTagS m_cRecipeTagS = null;
        private CCycleAnalyzedData m_cCycleAnalyzedData = new CCycleAnalyzedData();

        #endregion


        #region Initialize

        public UCRecipeView()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CTagS RecipeTagS
        {
            get { return m_cRecipeTagS; }
            set { m_cRecipeTagS = value; }
        }

        public CCycleAnalyzedData CycleAnalyzedData
        {
            get { return m_cCycleAnalyzedData; }
            set 
            {
                m_cCycleAnalyzedData = value;
                SetAnalyzeData(value);
            }
        }

        #endregion


        #region Public Method

        public void Clear()
        {
            grdRecipeTagS.DataSource = null;
            grdRecipeTagS.RefreshDataSource();
        }

        public void SetRecipeWord(CTagS cRecipeTagS)
        {
            if (cRecipeTagS == null || cRecipeTagS.Count == 0)
                return;

            Clear();

            m_cRecipeTagS = cRecipeTagS;

            grdRecipeTagS.DataSource = m_cRecipeTagS.Values.ToList();
            grdRecipeTagS.RefreshDataSource();
        }

        public void SetAnalyzeData(CCycleAnalyzedData cData)
        {
            if (cData == null) return;
            m_cCycleAnalyzedData = cData;

            txtAverage.Text = string.Format("{0}", cData.Average.TotalSeconds);
            txtCycleMin.Text = string.Format("{0}", cData.MinCycle.TotalSeconds);
            txtCycleMax.Text = string.Format("{0}", cData.MaxCycle.TotalSeconds);
            txtCycleOver.Text = cData.OverCount.ToString();
        }

        #endregion


        #region Form Event

        private void grvRecipeTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void UCRecipeView_Load(object sender, EventArgs e)
        {
            int iUnitWidth = this.Width/2;

            grdRecipeTagS.DataSource = null;
            grdRecipeTagS.RefreshDataSource();
            txtAverage.Text = "0.0";
            txtCycleMin.Text = "0.0";
            txtCycleMax.Text = "0.0";
            txtCycleOver.Text = "0";
        }

        private void UCRecipeView_Resize(object sender, EventArgs e)
        {
            //this.Height = vgrdRecipe.Height;
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

        #endregion
    }

}
