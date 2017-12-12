using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;
using UDM.Monitor;

namespace UDMTracker
{
    public partial class FrmPatternItemUpdater : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CProject m_cProject = null;
        private CMySqlLogReader m_cReader = null;
		private CCyclePresentOption m_cKeyOption = new CCyclePresentOption();
        private List<string> m_lstAddressFilter = null;
        private List<string> m_lstDescriptionFilter = null;

        #endregion


        #region Initialize/Dispose

        public FrmPatternItemUpdater()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public CMySqlLogReader DBReader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        public List<string> AddressFilterList
        {
            get { return m_lstAddressFilter; }
            set { m_lstAddressFilter = value; }
        }

        public List<string> DescriptionFilter
        {
            get { return m_lstDescriptionFilter; }
            set { m_lstDescriptionFilter = value; }
        }
        
        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (m_cProject == null)
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastGroupLogTime(EMMonitorType.PatternItem);

            if (dtLast == DateTime.MinValue)
            {
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
                dtpkTo.EditValue = (DateTime)dtLast;
            }

			ucKeyOptionProperty.SetUseFilterEditable(false);
			ucKeyOptionProperty.Option = m_cKeyOption;
			ucKeyOptionProperty.ShowProperty();
        }

        private void Clear()
        {   
            ucMonitorHistoryTable.Clear();
            
            ClearGridColumn();
            grdPatternItemHistory.DataSource = null;
            grdPatternItemHistory.Refresh();
        }

        private void CreateGridColumns(int iCount)
        {
            GridBand exBand;
            BandedGridColumn colActiveCount;
            BandedGridColumn colFirstValue;
            for (int i = 0; i < iCount;i++ )
            {   
                colActiveCount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                colActiveCount.AppearanceHeader.Options.UseTextOptions = true;
                colActiveCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                colActiveCount.Caption = "Count";
                colActiveCount.FieldName = "_Count_" + i.ToString();
                colActiveCount.UnboundType = DevExpress.Data.UnboundColumnType.String;                
                colActiveCount.Tag = i;
                colActiveCount.Name = "colCount" + i.ToString();
                colActiveCount.Visible = true;

                colFirstValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                colFirstValue.AppearanceHeader.Options.UseTextOptions = true;
                colFirstValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                colFirstValue.Caption = "Value";
                colFirstValue.FieldName = "_Value_" + i.ToString();
                colFirstValue.UnboundType = DevExpress.Data.UnboundColumnType.String;
                colFirstValue.Tag = i;
                colFirstValue.Name = "colValue" + i.ToString();
                colFirstValue.Visible = true;

                exBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                exBand.AppearanceHeader.Options.UseTextOptions = true;
                exBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                exBand.Caption = "#" + (i + 1).ToString() + " Cycle";
                exBand.Columns.Add(colActiveCount);
                exBand.Columns.Add(colFirstValue);
                exBand.Name = "bndCycle" + i.ToString();
                exBand.VisibleIndex = i+1;
                exBand.Width = 225;

                grvMain.Columns.Add(colActiveCount);
                grvMain.Columns.Add(colFirstValue);
                grvMain.Bands.Add(exBand);                
            }            
        }

        private void ClearGridColumn()
        {
            GridBand exBand;
            BandedGridColumn exColumn;
            for(int i=1;i<grvMain.Bands.Count;i++)
            {
                exBand = grvMain.Bands[i];
                for (int j = 0; j < exBand.Columns.Count; j++)
                {
                    exColumn = exBand.Columns[j];
                    exBand.Columns.Remove(exColumn);
                    grvMain.Columns.Remove(exColumn);
                    j--;
                }

                grvMain.Bands.Remove(exBand);
            }
        }

        private void ShowPatternItemHistory(DateTime dtFrom, DateTime dtTo, int iCount)
        {
            ClearGridColumn();

            List<CCyclePresentResult> lstResult = new List<CCyclePresentResult>();
            int iMaxCycleCount = 0;

            CCyclePresentResultS cResultS = null;
            CGroup cGroup;
            for (int i = 0; i < m_cProject.GroupS.Count; i++)
            {
                cGroup = m_cProject.GroupS[i];
                cResultS = CreateKeySymbolCyclePresentResultS(cGroup, dtFrom, dtTo);

                if (cResultS.TotalCycleCount > iMaxCycleCount)
                    iMaxCycleCount = cResultS.TotalCycleCount;

                lstResult.AddRange(cResultS.Values.ToList());
            }
            
            CreateGridColumns(iMaxCycleCount);

            grdPatternItemHistory.DataSource = lstResult;
            grdPatternItemHistory.Refresh();
        }

        private CCyclePresentResultS CreateKeySymbolCyclePresentResultS(CGroup cGroup, DateTime dtFrom, DateTime dtTo)
        {
            CGroupLogS cGroupLogS = m_cReader.GetGroupLogS(cGroup.Key, dtFrom, dtTo);
            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return null;

            //  Key 심볼 중 Coil로 쓰인 Bit 접점만
            CSymbol cSymbol;
			CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cGroup.KeySymbolS.Count; i++)
            {
                cSymbol = cGroup.KeySymbolS[i];
                if (cSymbol.RoleType == EMGroupRoleType.Key && cSymbol.DataType == EMDataType.Bool && cSymbol.Tag.IsEndContact() == false)
                    cCandiTagS.Add(cSymbol.Tag);
            }

            if (cGroupLogS.Count > 0)
                cGroupLogS.RemoveAt(0);

            CCyclePresentResultS cResultS = new CCyclePresentResultS(cCandiTagS);
            TimeSpan tsSpan;
            CGroupLog cGroupLog;
            for (int i = 0; i < cGroupLogS.Count; i++)
            {
                cGroupLog = cGroupLogS[i];
                if (cGroupLog.CycleStart == DateTime.MinValue || cGroupLog.CycleEnd == DateTime.MinValue)
                    continue;

                if (cGroupLog.StateType == EMGroupStateType.Error || cGroupLog.StateType == EMGroupStateType.ErrorEnd)
                    continue;

                tsSpan = cGroupLog.CycleEnd.Subtract(cGroupLog.CycleStart);
                if (tsSpan.TotalMilliseconds > cGroup.MaxCycleTime)
                    continue;

                // 너무 타이트함
                // if (tsSpan.TotalMilliseconds < cProcess.MaxCycleTime * 0.7)
                //     continue;

                UpdateCyclePresentResultS(cCandiTagS, cGroupLog, cResultS);
            }

            return cResultS;
        }

        private void UpdateCyclePresentResultS(CTagS cTagS, CGroupLog cGroupLog, CCyclePresentResultS cResultS)
        {
            List<string> lstKey = cTagS.Keys.ToList();
            CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstKey, cGroupLog.CycleStart, cGroupLog.CycleEnd);
            if (cTotalLogS == null || cTotalLogS.Count == 0)
                return;

            CTimeLogS cLogS;
            CTag cTag;
            CCyclePresentResult cResult;
            for (int i = 0; i < cTagS.Count; i++)
            {
                cTag = cTagS[i];
                cResult = cResultS[cTag.Key];

                cLogS = cTotalLogS.GetTimeLogS(cTag.Key);
                if (cLogS == null)
                    cLogS = new CTimeLogS();

                cResultS.UpdatePresentResult(cGroupLog.Recipe, cTag.Key, cLogS);

                cLogS.Clear();
                cLogS = null;
            }

            cTotalLogS.Clear();
            cTotalLogS = null;

            cResultS.TotalCycleCount += 1;
        }

        private void UpdateKeySymbolS()
        {
            List<CCyclePresentResult> lstResult = (List<CCyclePresentResult>)grvMain.DataSource;
            if (lstResult == null || lstResult.Count == 0)
                return;

            List<CTag> lstPatternItem = new List<CTag>();
            for(int i=0;i<lstResult.Count;i++)
            {
                if (lstResult[i].IsRegular(m_cKeyOption))
                    lstPatternItem.Add(lstResult[i].Tag);
            }

            CGroup cGroup;
            CSymbol cSymbol;
			CTag cTag;
			CTagS cGroupKeyTagS = null;
            for(int i=0;i<m_cProject.GroupS.Count;i++)
            {
                cGroup = m_cProject.GroupS[i];
				cGroupKeyTagS = cGroup.KeySymbolS.GetTagS();

                ClearGroupKeySymbol(cGroup);

                // Cycle Key Symbol
                for (int j = 0; j < cGroup.KeySymbolS.Count;j++)
                {
                    cSymbol = cGroup.KeySymbolS[j];
                    AddSubKeySymbolS(cGroup, cSymbol, m_lstAddressFilter, m_lstDescriptionFilter, true);
                }

                // Key Symbol
                for (int j = 0; j < lstPatternItem.Count; j++)
                {
					cTag = lstPatternItem[j];
					if (cGroupKeyTagS.ContainsKey(cTag.Key))
					{
						if (IsCycleSymbol(cGroup, cTag.Key) == false)
						{
							cSymbol = cGroup.AddSymbol(cTag, EMGroupRoleType.Key);
							if(cSymbol != null)
								AddSubKeySymbolS(cGroup, cSymbol, m_lstAddressFilter, m_lstDescriptionFilter, true);
						}
					}
                }
            }
        }

        private void ClearGroupKeySymbol(CGroup cGroup)
        {
			CSymbol cSymbol;
			for(int i=0;i<cGroup.KeySymbolS.Count;i++)
			{
				cSymbol = cGroup.KeySymbolS[i];
				if(cSymbol.SubSymbolS == null)
					cSymbol.SubSymbolS = new CSymbolS();
				else
					cSymbol.SubSymbolS.Clear();

				if (IsCycleSymbol(cGroup, cSymbol.Key) == false)
				{
					cGroup.KeySymbolS.Remove(cSymbol.Key);
					i--;
				}	
			}
        }

        private void AddSubKeySymbolS(CGroup cGroup, CSymbol cSymbol, List<string> lstAddressFilter, List<string> lstDescriptionFilter, bool bExceptCycleSymbol)
        {
            List<CTag> lstSubTag = m_cProject.GetEndContactList(cSymbol.Tag, EMDataType.Bool);

            CTag cTag;
            for(int i=0;i<lstSubTag.Count;i++)
            {
                cTag = lstSubTag[i];

                if (lstAddressFilter != null && lstAddressFilter.Count > 0)
                {
					if (CTrackerHelper.IsAddressFiltered(cTag, lstAddressFilter))
                        continue;
                }

                if (lstDescriptionFilter != null && lstDescriptionFilter.Count > 0)
                {
					if (CTrackerHelper.IsDescriptionFiltered(cTag, lstDescriptionFilter))
                        continue;
                }

                if(bExceptCycleSymbol)
                {
                    if (cGroup.CycleStartConditionS.ContainsKey(cTag.Key))
                        continue;

                    if (cGroup.CycleEndConditionS.ContainsKey(cTag.Key))
                        continue;
                }

				cGroup.AddSubSymbol(cSymbol, cTag);
            }
        }

        private bool IsCycleSymbol(CGroup cGroup, string sKey)
        {
            bool bOK = false;

			if (cGroup.CycleStartConditionS.ContainsKey(sKey) || cGroup.CycleEndConditionS.ContainsKey(sKey))
                bOK = true;

            return bOK;
        }

        #endregion


        #region Event Methods

        private void FrmPatternItemUpdater_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(m_bVerified == false)
                return;

            ucMonitorHistoryTable.Clear();

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CGroupLogS cLogS = m_cReader.GetGroupLogS(dtFrom, dtTo);
            if(cLogS != null)
            {
                ucMonitorHistoryTable.MonitorType = EMMonitorType.PatternItem;
                ucMonitorHistoryTable.GroupLogS = cLogS;
                ucMonitorHistoryTable.ShowTable();
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            Clear();
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                UpdateKeySymbolS();

				m_cProject.GroupS.Compose(m_cProject.TagS);
            }
            SplashScreenManager.CloseForm(false);

            this.Close();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

		private void grvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
		{
			if (e.Info.IsRowIndicator && e.RowHandle >= 0)
			{
				e.Info.DisplayText = e.RowHandle.ToString();
			}
		}

        private void grvMain_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {   
            if (e.Row == null)
                return;

            if (e.Column.FieldName.StartsWith("_Count") && e.IsGetData)
            {
                CCyclePresentResult cResult = (CCyclePresentResult)e.Row;
                int iIndex = (int)e.Column.Tag;
                if (iIndex < cResult.Count)
                    e.Value = cResult[iIndex].ActiveCount.ToString();
                else
                    e.Value = "-";
            }
            else if (e.Column.FieldName.StartsWith("_Value") && e.IsGetData)
            {
                CCyclePresentResult cResult = (CCyclePresentResult)e.Row;
                int iIndex = (int)e.Column.Tag;

                if (iIndex < cResult.Count)
                {
                    if (cResult[iIndex].FirstValue < 1)
                        e.Value = "OFF";
                    else
                        e.Value = "ON";
                }
                else
                    e.Value = "-";
            }
        }

        private void ucMonitorHistoryTable_UEventHistoryDoubleClicked(object sender, DateTime dtStart, DateTime dtEnd, int iCycleCount)
        {
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowPatternItemHistory(dtStart, dtEnd, iCycleCount);
            }
            SplashScreenManager.CloseForm(false);
        }

        #endregion
    }
}