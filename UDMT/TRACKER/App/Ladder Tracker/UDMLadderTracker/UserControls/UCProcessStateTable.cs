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
    public partial class UCProcessStateTable : DevExpress.XtraEditors.XtraUserControl
    {
        private bool m_bRun = false;
        private DataTable m_dbTable = new DataTable();

        private const int m_COL_NAME = 0;
        private const int m_COL_TACKTIME = 1;
        private const int m_COL_IDLETIME = 2;
        private const int m_COL_STATE = 3;

        private delegate void UpdateGroupStateCallback(string sGroup, int iColIndex, double nValue, string sState);

        public UCProcessStateTable()
        {
            InitializeComponent();
        }

        #region Public Properties

        #endregion

        #region Public Methods

        public void Run()
        {
            if (m_bRun == false)
            {
                m_bRun = true;
            }
        }

        public void Stop()
        {
            if (m_bRun)
            {
                m_bRun = false;
            }

            Clear();
        }

        public void Clear()
        {
            for (int i = 0; i < m_dbTable.Rows.Count; i++)
            {
                m_dbTable.Rows[i][m_COL_TACKTIME] = "0.00";
                m_dbTable.Rows[i][m_COL_IDLETIME] = "0.00";
                m_dbTable.Rows[i][m_COL_STATE] = "WAIT";
            }

            exGridControl.Refresh();
        }

        public void ShowTable()
        {
            m_dbTable.Rows.Clear();

            DataRow dbRow;
            CPlcProc cProcess;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                dbRow = m_dbTable.NewRow();
                dbRow[m_COL_NAME] = cProcess.Name;
                dbRow[m_COL_TACKTIME] = "0.00";
                dbRow[m_COL_IDLETIME] = "0.00";
                dbRow[m_COL_STATE] = "WAIT";

                m_dbTable.Rows.Add(dbRow);
            }

            exGridControl.DataSource = m_dbTable;
            exGridControl.Refresh();
        }

        #endregion

        #region Private Methods

        private void CreateScheme()
        {
            if (m_dbTable == null)
                m_dbTable = new DataTable();

            m_dbTable.Columns.Clear();

            for (int i = 0; i < exGridView.Columns.Count; i++)
            {
                m_dbTable.Columns.Add(exGridView.Columns[i].FieldName);
            }
        }

        private void UpdateGroupState(string sGroup, int iColIndex, double nValue, string sState)
        {
            if (this.InvokeRequired)
            {
                UpdateGroupStateCallback cbUpdateState = new UpdateGroupStateCallback(UpdateGroupState);
                this.Invoke(cbUpdateState, new object[] { sGroup, iColIndex, nValue, sState });
            }
            else
            {
                DataRow[] dbRowS = m_dbTable.Select("Group ='" + sGroup + "'");
                if (dbRowS != null && dbRowS.Length > 0)
                {
                    if (nValue == 0)
                        dbRowS[0][iColIndex] = "0.00";
                    else
                        dbRowS[0][iColIndex] = nValue.ToString("##.##");

                    dbRowS[0][m_COL_STATE] = sState;

                    exGridControl.Refresh();
                }
            }
        }

        #endregion

        #region Event Methods

        private void m_cMonitorViewer_UEventCycleStateChanged(object sender, CGroupLog cLog)
        {

            if (cLog.StateType == EMGroupStateType.Start)
            {
                if (cLog.CycleEnd != DateTime.MinValue)
                {
                    TimeSpan tsSpan = cLog.CycleStart.Subtract(cLog.CycleEnd);
                    UpdateGroupState(cLog.Key, m_COL_IDLETIME, tsSpan.TotalSeconds, "RUN");
                }
                else
                {
                    UpdateGroupState(cLog.Key, m_COL_IDLETIME, 0, "RUN");
                }
            }
            else if (cLog.StateType == EMGroupStateType.End)
            {
                TimeSpan tsSpan = cLog.CycleEnd.Subtract(cLog.CycleStart);
                UpdateGroupState(cLog.Key, m_COL_TACKTIME, tsSpan.TotalSeconds, "WAIT");
            }
            else
            {
                TimeSpan tsSpan = DateTime.Now.Subtract(cLog.CycleStart);
                UpdateGroupState(cLog.Key, m_COL_TACKTIME, tsSpan.TotalSeconds, "ERROR");
            }
        }

        #endregion

        private void exGridControl_Load(object sender, EventArgs e)
        {
            CreateScheme();
        }

        private void exGridView_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colState)
            {
                if (e.CellValue.ToString() == "WAIT")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (e.CellValue.ToString() == "RUN")
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
