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
    public partial class UCSummaryCycleInfoGrid : DevExpress.XtraEditors.XtraUserControl
    {
        protected Dictionary<string, CCycleInfo> m_DicGroupCycleInfo = new Dictionary<string, CCycleInfo>();

        public UCSummaryCycleInfoGrid()
        {
            InitializeComponent();
        }

        public Dictionary<string, CCycleInfo> GroupCycleInfo
        {
            get { return m_DicGroupCycleInfo; }
            set
            {
                m_DicGroupCycleInfo = value;
                grdSummary.DataSource = m_DicGroupCycleInfo.Values;
                grdSummary.RefreshDataSource();
            }
        }


        public void ClearGrid()
        {
            grdSummary.DataSource = null;
        }

        public void UpdateCycle()
        {
            grdSummary.DataSource = null;

            grdSummary.DataSource = m_DicGroupCycleInfo.Values;
            grdSummary.RefreshDataSource();
        }

        private void grvSummary_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //Log의 GroupState로 할 수도 있음
            if (e.Column == colState)
            {
                if (e.CellValue.ToString().ToUpper() == "WAIT")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (e.CellValue.ToString().ToUpper() == "START")
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                else if (e.CellValue.ToString().ToUpper() == "COMPLETE")
                    e.Appearance.BackColor = Color.LightYellow;
                else
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
            }
        }

    }
}
