using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;
using UDM.Log;

namespace UDM.Project.UserControls
{
    public partial class UCMonitorHistoryTable : UserControl
    {

        #region Member Variables

        private EMMonitorType m_emdMonitorType = EMMonitorType.Detection;
        private CGroupLogS m_cGroupLogS = null;

        public event UEventHandlerMonitorHistoryTableRowDoubleClicked UEventHistoryDoubleClicked;

        #endregion


        #region Initialize/Dispose

        public UCMonitorHistoryTable()
        {
            InitializeComponent();
        }


        #endregion


        #region Public Properties

        public EMMonitorType MonitorType
        {
            get { return m_emdMonitorType; }
            set { m_emdMonitorType = value; }
        }

        public CGroupLogS GroupLogS
        {
            get { return m_cGroupLogS; }
            set { m_cGroupLogS = value; }
        }

        #endregion


        #region Public Methods

        public void ShowTable()
        {
            Clear();

            grdMain.DataSource = GetHistoryItemList(m_cGroupLogS, m_emdMonitorType);
            grdMain.Refresh();
        }

        public void Clear()
        {
            grdMain.DataSource = null;
            grdMain.Refresh();
        }

        #endregion


        #region Private Methods
                
        private List<CMonitorHistoryItem> GetHistoryItemList(CGroupLogS cLogS, EMMonitorType emMonitorType)
        {
            if (cLogS == null)
                return null;

            List<CMonitorHistoryItem> lstItem = new List<CMonitorHistoryItem>();
            CMonitorHistoryItem cItem = null;

            CGroupLog cLog;
            for(int i=0;i<cLogS.Count;i++)
            {
                cLog = cLogS[i];
                if (cLog.MonitorType == emMonitorType)
                {
                    if (cItem == null)
                    {
                        cItem = new CMonitorHistoryItem(cLog.CycleStart);
                        lstItem.Add(cItem);
                    }

                    cItem.CycleCount += 1;
                    cItem.EndTime = cLog.CycleEnd;
                }
                else
                {
                    if (cItem != null)
                        cItem = null;
                }
            }

            return lstItem;
        }

        private void GenerateDoubleClickEvent(CMonitorHistoryItem cItem)
        {
            if (UEventHistoryDoubleClicked != null)
                UEventHistoryDoubleClicked(this, cItem.StartTime, cItem.EndTime, cItem.CycleCount);
        }

        #endregion


        #region Event Methods

        private void UCMonitorHistoryTable_Load(object sender, EventArgs e)
        {

        }

        private void grvMain_DoubleClick(object sender, EventArgs e)
        {
            int iRowHandle = grvMain.FocusedRowHandle;
            if (iRowHandle < 0)
                return;

            CMonitorHistoryItem cItem = (CMonitorHistoryItem)grvMain.GetRow(iRowHandle);
            GenerateDoubleClickEvent(cItem);
        }

        #endregion

    }

    #region View Class

    class CMonitorHistoryItem
    {
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private int m_iCycleCount = 0;

        public CMonitorHistoryItem(DateTime dtStart)
        {
            m_dtStart = dtStart;
        }

        public CMonitorHistoryItem(DateTime dtStart, DateTime dtEnd, int iCycleCount)
        {
            m_dtStart = dtStart;
            m_dtEnd = dtEnd;
            m_iCycleCount = iCycleCount;
        }

        public DateTime StartTime
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public DateTime EndTime
        {
            get { return m_dtEnd; }
            set { m_dtEnd = value; }
        }

        public int CycleCount
        {
            get { return m_iCycleCount; }
            set { m_iCycleCount = value; }
        }
    }

    #endregion
}
