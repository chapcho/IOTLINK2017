using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.UI.TimeChart;
using UDM.Log;

namespace UDMEnergyViewer
{
    public partial class FrmTagRecommand : DevExpress.XtraEditors.XtraForm
    {
        private List<CFit> m_lstFitData = new List<CFit>();
        private List<string> m_lstSelectedTagKey = new List<string>();
        private List<CRowItem> m_lstAllItem = null;
        private CMeterUnit m_cMeterUnit = null;
        private CTimeLogS m_cEnergyLogS = null;
        private CTagItemS m_cAllCoilTagItemS = null;
        private DateTime m_dtStartTime = DateTime.MinValue;
        private int m_iTolerance = 2000;

        private float m_fBaseEnergy = 0;

        public FrmTagRecommand()
        {
            InitializeComponent();
        }

        #region Properties

        public CTagItemS AllCoilTagItemS
        {
            get { return m_cAllCoilTagItemS; }
            set { m_cAllCoilTagItemS = value; }
        }

        public CMeterUnit MeterUnit
        {
            get { return m_cMeterUnit; }
            set { m_cMeterUnit = value; }
        }

        public List<CRowItem> AllItem
        {
            get { return m_lstAllItem; }
            set { m_lstAllItem = value; }
        }

        public DateTime StartTime
        {
            get { return m_dtStartTime; }
            set { m_dtStartTime = value; }
        }

        public List<CFit> FitDataS
        {
            get { return m_lstFitData; }
            set { m_lstFitData = value; }
        }

        public List<string> SelectedTagKeyS
        {
            get { return m_lstSelectedTagKey; }
        }

        public float BaseEnergy
        {
            get { return m_fBaseEnergy; }
            set { m_fBaseEnergy = value; }
        }

        #endregion

        private void CreateTagRealtedEnergy()
        {
            CTimeLog cEnergyConsumeStartLog = null;
            CTimeLog cEnergyConsumeEndLog = null;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                    cEnergyConsumeStartLog = m_cEnergyLogS.GetFirstLog(m_cMeterUnit.Key, m_dtStartTime, m_fBaseEnergy, true);
                else
                    cEnergyConsumeStartLog = m_cEnergyLogS.GetFirstLog(m_cMeterUnit.Key, cEnergyConsumeEndLog.Time, m_fBaseEnergy, true);

                if (cEnergyConsumeStartLog == null)
                    continue;

                cEnergyConsumeEndLog = m_cEnergyLogS.GetFirstLog(m_cMeterUnit.Key, cEnergyConsumeStartLog.Time, m_fBaseEnergy, false);
                if (cEnergyConsumeEndLog == null)
                    continue;

                m_lstFitData.AddRange(GetFitDataRelatedEnergy(cEnergyConsumeStartLog.Time, cEnergyConsumeEndLog.Time, i + 1));
            }

            if (m_lstFitData.Count == 0)
                return;
        }

        private List<CFit> GetFitDataRelatedEnergy(DateTime dtFrom, DateTime dtTo, int iCycleIndex)
        {
            List<CFit> lstFitDataRelatedEnergy = new List<CFit>();
            CFit cFitData = null;
            CTagItem cPLCTagItem = null;
            CTimeLog cPLCStartLog = null;
            CTimeLog cPLCEndLog = null;
            bool bLaybackPLCLog = false;

            foreach (CRowItem cItem in m_lstAllItem)
            {
                cPLCTagItem = (CTagItem)cItem.Data;
                cPLCStartLog = cPLCTagItem.LogS.GetLastLog(cPLCTagItem.Key, dtFrom, 1);

                if (cPLCStartLog == null)
                {
                    cPLCStartLog = cPLCTagItem.LogS.GetFirstLog(cPLCTagItem.Key, dtFrom, 1);

                    if (cPLCStartLog == null)
                        continue;
                    else
                        bLaybackPLCLog = true;
                }
                else
                    bLaybackPLCLog = false;

                if (bLaybackPLCLog)
                    cPLCEndLog = cPLCTagItem.LogS.GetFirstLog(cPLCTagItem.Key, dtTo, 0);
                else
                    cPLCEndLog = cPLCTagItem.LogS.GetLastLog(cPLCTagItem.Key, dtTo, 0);

                if (cPLCEndLog == null)
                    continue;

                if (!bLaybackPLCLog && cPLCEndLog.Time < dtFrom)
                    continue;
                else if (bLaybackPLCLog && dtTo < cPLCStartLog.Time)
                    continue;

                cFitData = new CFit();
                cFitData.Tag = cPLCTagItem.Tag;
                cFitData.Cycle = iCycleIndex;
                cFitData.PLCFrom = cPLCStartLog.Time;
                cFitData.PLCTo = cPLCEndLog.Time;
                cFitData.EnergyFrom = dtFrom;
                cFitData.EnergyTo = dtTo;

                if (cFitData.Tolerance < m_iTolerance && cFitData.ErrorRange < 3000 && cFitData.Fit > 80 && cFitData.Fit < 120)
                    lstFitDataRelatedEnergy.Add(cFitData);
                else
                    cFitData = null;
            }

            return lstFitDataRelatedEnergy;
        }

        private void ClearGrid()
        {
            if (gvTag.DataSource == null)
                return;

            List<CFit> lstFit = gvTag.DataSource as List<CFit>;

            lstFit.Clear();

            gcTag.RefreshDataSource();
        }

        private void FrmTagSelector_Load(object sender, EventArgs e)
        {
            ClearGrid();

            m_cEnergyLogS = m_cMeterUnit.LogS;

            CreateTagRealtedEnergy();

            gcTag.DataSource = m_lstFitData;
            gcTag.RefreshDataSource();

            btnUpdate.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int[] SelectedRowsArr = gvTag.GetSelectedRows();

            if (SelectedRowsArr == null || SelectedRowsArr.Length == 0)
                return;

            string sKey = string.Empty;

            foreach (int i in SelectedRowsArr)
            {
                sKey = m_lstFitData[i].Tag.Key;
                m_lstSelectedTagKey.Add(sKey);
            }

            MessageBox.Show("Apply Success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmTagSelector_Load(sender, e);
        }

        private void spnTolerance_EditValueChanged(object sender, EventArgs e)
        {
            m_iTolerance = Int32.Parse(spnTolerance.EditValue.ToString()) * 1000;
            btnUpdate.Enabled = true;
        }
    }
}