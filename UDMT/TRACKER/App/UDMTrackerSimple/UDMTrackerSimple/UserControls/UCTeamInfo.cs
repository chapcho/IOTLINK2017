using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCTeamInfo : DevExpress.XtraEditors.XtraUserControl
    {
        private CTeamInfo m_cTeamInfo = null;

        public UCTeamInfo()
        {
            InitializeComponent();
        }

        public CTeamInfo TeamInfo
        {
            get { return m_cTeamInfo; }
            set { m_cTeamInfo = value; }
        }

        private void ShowProperty()
        {
            exProperty.SelectedObject = m_cTeamInfo;
            exProperty.Refresh();
        }

        private void UCTeamInfo_Load(object sender, EventArgs e)
        {
            ShowProperty();
        }

        private void exProperty_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {
            
        }

        private void exEditorFrom_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.MinValue;
            bool bOK = true;
            int iToHour = 0;

            var exEditor = sender as TimeEdit;

            if (exEditor == null)
                return;

            dtTime = (DateTime) exEditor.Time;
            //m_cTeamInfo.From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dtTime.Hour, dtTime.Minute, 0);

            foreach (var who in CMultiProject.TeamInfoS)
            {
                if (who.Value == m_cTeamInfo)
                    continue;

                iToHour = who.Value.To.Hour;

                if (who.Value.From.Hour > who.Value.To.Hour && who.Value.To.Hour == 0)
                    iToHour = 24;

                if (who.Value.From.Hour <= dtTime.Hour && iToHour > dtTime.Hour)
                {
                    bOK = false;
                    break;
                }
                else if (iToHour == dtTime.Hour && who.Value.To.Minute > dtTime.Minute)
                {
                    bOK = false;
                    break;
                }
            }

            if (!bOK)
                MessageBox.Show("기간 설정이 중복됩니다. 다시 설정하세요", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void exEditorTo_EditValueChanged(object sender, EventArgs e)
        {
            DateTime dtTime = DateTime.MinValue;
            bool bOK = true;
            int iToHour = 0;

            var exEditor = sender as TimeEdit;

            if (exEditor == null)
                return;

            dtTime = (DateTime)exEditor.Time;
            //m_cTeamInfo.To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, dtTime.Hour, dtTime.Minute, 0);

            foreach (var who in CMultiProject.TeamInfoS)
            {
                if (who.Value == m_cTeamInfo)
                    continue;

                iToHour = who.Value.To.Hour;

                if (who.Value.From.Hour > who.Value.To.Hour && who.Value.To.Hour == 0)
                    iToHour = 24;

                if (who.Value.From.Hour < dtTime.Hour && iToHour >= dtTime.Hour)
                {
                    bOK = false;
                    break;
                }
                else if (who.Value.From.Hour == dtTime.Hour && who.Value.From.Minute < dtTime.Minute)
                {
                    bOK = false;
                    break;
                }
            }

            if (!bOK)
                MessageBox.Show("기간 설정이 중복됩니다. 다시 설정하세요", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void exProperty_DragOver(object sender, DragEventArgs e)
        {
            if (m_cTeamInfo == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exProperty_DragDrop(object sender, DragEventArgs e)
        {

        }

    }
}
