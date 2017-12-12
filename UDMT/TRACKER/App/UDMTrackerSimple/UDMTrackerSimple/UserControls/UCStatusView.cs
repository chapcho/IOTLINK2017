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
    public partial class UCStatusView : DevExpress.XtraEditors.XtraUserControl
    {
        #region

        Dictionary<string, CRobotCycleStatus> m_dicRobotStatus = new Dictionary<string, CRobotCycleStatus>();
        Dictionary<string, CProcessStatus> m_dicProcessStatus = new Dictionary<string, CProcessStatus>();
        Dictionary<string, CSPDStatus> m_dicSPDStatus = new Dictionary<string, CSPDStatus>();

        #endregion


        #region Initialize

        public UCStatusView()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        

        #endregion


        #region Public Method

        public void SetRobotCycleTag(CTagS cTagS)
        {
            m_dicRobotStatus.Clear();
            foreach (var who in cTagS)
            {
                CRobotCycleStatus cStatus = new CRobotCycleStatus();
                cStatus.Key = who.Key;
                cStatus.Name = who.Value.Description;
                cStatus.Status = "WAIT";
                m_dicRobotStatus.Add(who.Key, cStatus);
            }
            grdRobotStatus.DataSource = m_dicRobotStatus.Values.ToList();
            grdRobotStatus.RefreshDataSource();
        }

        public void SetProcessList(CPlcProcS cProS)
        {
            m_dicProcessStatus.Clear();
            foreach (var who in cProS)
            {
                CProcessStatus cStatus = new CProcessStatus();
                cStatus.Key = who.Key;
                cStatus.Name = who.Value.Name;
                cStatus.Status = "WAIT";
                m_dicProcessStatus.Add(who.Key, cStatus);
            }
            grdProcessStatus.DataSource = m_dicProcessStatus.Values.ToList();
            grdProcessStatus.RefreshDataSource();
        }

        public void SetSPDList(List<string> lstPlcKey)
        {
            m_dicSPDStatus.Clear();
            for (int i = 0; i < lstPlcKey.Count; i++)
            {
                CSPDStatus cStatus = new CSPDStatus();
                cStatus.Key = lstPlcKey[i];
                cStatus.Name = lstPlcKey[i];
                cStatus.Status = "WAIT";
                m_dicSPDStatus.Add(lstPlcKey[i], cStatus);
            }

            grdSpdStatus.DataSource = m_dicSPDStatus.Values.ToList();
            grdSpdStatus.RefreshDataSource();
        }

        public void ClearData()
        {
            foreach (var who in m_dicProcessStatus)
            {
                who.Value.Status = "WAIT";
            }
            foreach (var who in m_dicRobotStatus)
            {
                who.Value.Status = "WAIT";
            }
            foreach (var who in m_dicSPDStatus)
            {
                who.Value.Status = "WAIT";
            }
            grdProcessStatus.RefreshDataSource();
            grdSpdStatus.RefreshDataSource();
            grdRobotStatus.RefreshDataSource();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sKey"></param>
        public void UpdateRobotCycle(string sKey, string sState)
        {
            if (m_dicRobotStatus.ContainsKey(sKey))
            {
                m_dicRobotStatus[sKey].Status = sState;
                grdRobotStatus.RefreshDataSource();
            }
        }

        public void UpdateProcessStatus(string sKey, EMCycleRunType emType)
        {
            if (m_dicProcessStatus.ContainsKey(sKey))
            {
                m_dicProcessStatus[sKey].Status = emType.ToString();
                grdProcessStatus.RefreshDataSource();
            }
        }

        public void UpdateSpdStatus(string sKey, string sStateMode)
        {
            if (m_dicSPDStatus.ContainsKey(sKey))
            {
                m_dicSPDStatus[sKey].Status = sStateMode;
                grdSpdStatus.RefreshDataSource();
            }
        }

        #endregion


        #region Event Method

        private void grvProcessStatus_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colProcessStatus)
            {
                if (e.CellValue.ToString() == "WAIT")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (e.CellValue.ToString() == EMCycleRunType.Start.ToString())
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                else if (e.CellValue.ToString() == EMCycleRunType.End.ToString())
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if (e.CellValue.ToString() == EMCycleRunType.Error.ToString())
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void grvSpdStatus_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colSpdStatus)
            {
                if (e.CellValue.ToString() == "WAIT")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (e.CellValue.ToString() == "RUN")
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                else if (e.CellValue.ToString() == "Error")
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else if (e.CellValue.ToString() == "Ready")
                {
                    e.Appearance.BackColor = Color.YellowGreen;
                }
            }
        }

        private void grvRobotStatus_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colRobotStatus)
            {
                if (e.CellValue.ToString() == "WAIT")
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                else if (e.CellValue.ToString() == "RUN")
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                else if (e.CellValue.ToString() == "No Active")
                {
                    e.Appearance.BackColor = Color.YellowGreen;
                }
            }
        }

        #endregion

        private void grvSpdStatus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvProcessStatus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvRobotStatus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }
    }

    class CRobotCycleStatus
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    class CSPDStatus
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    class CProcessStatus
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
