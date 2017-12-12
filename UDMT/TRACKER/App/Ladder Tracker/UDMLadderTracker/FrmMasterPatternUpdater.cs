using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Flow;
using UDM.Project;
using System.Diagnostics;

namespace UDMTrackerSimple
{
    public partial class FrmMasterPatternUpdater : Form
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;
		private CCyclePresentOption m_cKeyOption = new CCyclePresentOption();
		private CCyclePresentOption m_cSubKeyOption = new CCyclePresentOption();
        private CMasterPatternS m_cViewMasterPatternS = null;

        #endregion


        #region Initialize/Dispose

        public FrmMasterPatternUpdater()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "")
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastGroupLogTime(EMMonitorType.MasterPattern);

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

			ucSubKeyOptionProperty.SetUseFilterEditable(false);
			ucSubKeyOptionProperty.Option = m_cSubKeyOption;
			ucSubKeyOptionProperty.ShowProperty();

			ucFlowRuleProperty.Rule = new CFlowRule();
			ucFlowRuleProperty.ShowProperty();
        }

        private void ShowResult(CMasterPatternS cMasterPatternS)
        {
            CGroupPatternInfoS cRowS = new CGroupPatternInfoS();
            CGroupPatternInfo cRow;

            string sGroup;
            string sRecipe;
            int iCount;
            CMasterPattern cMasterPattern;
            for (int i = 0; i < cMasterPatternS.Count; i++)
            {
                sGroup = cMasterPatternS[i].Key;
                cMasterPattern = cMasterPatternS[i];

                for (int j = 0; j < cMasterPattern.Count; j++)
                {
                    sRecipe = cMasterPattern.ElementAt(j).Key;
                    iCount = cMasterPattern.ElementAt(j).Value.Count;
                    cRow = new CGroupPatternInfo(sGroup, sRecipe, iCount);
                    cRowS.Add(cRow);
                }
            }

            grdPatternList.DataSource = cRowS;
            grdPatternList.RefreshDataSource();
        }

        private CMasterPatternS CreateMasterPatternS(CFlowRule cRule, DateTime dtFrom, DateTime dtTo)
        {  
            CMasterPatternS cMasterPatternS = new CMasterPatternS();
            cMasterPatternS.Rule = cRule;

            CPlcProc cProcess;
            CMasterPattern cMasterPattern;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;
                cMasterPattern = CreateMasterPattern(cProcess, cRule, dtFrom, dtTo);
                if (cMasterPattern != null)
                    cMasterPatternS.Add(cProcess.Name, cMasterPattern);
            }

            return cMasterPatternS;
        }

        private CMasterPattern CreateMasterPattern(CGroup cGroup, CFlowRule cRule,  DateTime dtFrom, DateTime dtTo)
        {
            CGroupLogS cGroupLogS = m_cReader.GetGroupLogS(cGroup.Key, dtFrom, dtTo);
            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return null;

            for (int i = 0; i < cGroupLogS.Count;i++ )
            {
                if(cGroupLogS[i].MonitorType != EMMonitorType.MasterPattern)
                {
                    cGroupLogS.RemoveAt(i);
                    i--;
                }
            }

            if (cGroupLogS.Count > 0)
                cGroupLogS.RemoveAt(0);

            if(m_cKeyOption.UseFilter)
                UpdateKeySymbolS(cGroup, cGroupLogS);
                
            UpdateSubSymbolS(cGroup, cGroupLogS);

            CMasterPattern cMasterPattern = new CMasterPattern();
            cMasterPattern.Key = cGroup.Key;

            CGroupLog cGroupLog;
            CFlowItemS cItemS;
            CFlowItem cItem;
            CTimeNode cNode;
            for (int i = 0; i < cGroupLogS.Count; i++)
            {
                if (i == 0)
                    continue;

                cGroupLog = cGroupLogS[i];
                if (i == 0)
                    continue;

                if (cGroupLog.StateType == EMGroupStateType.Error || cGroupLog.StateType == EMGroupStateType.ErrorEnd)
                    continue;

                cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cGroup.Key, cGroup.KeySymbolS, cGroupLog, true);
                if (cItemS == null)
                    continue;

                for (int j = 0; j < cItemS.Count; j++)
                {
                    cItem = cItemS[j];
                    for (int k = 0; k < cItem.TimeNodeS.Count; k++)
                    {
                        cNode = cItem.TimeNodeS[k];
                        cNode.IsEnd = true;
                        cNode.IsStart = true;
                    }
                }

                cMasterPattern.Update(cGroupLog.Recipe, cItemS, cRule);
            }

            cMasterPattern.FinalizeLinkS();

            return cMasterPattern;
        }

        private void Clear()
        {
            ucMonitorHistoryTable.Clear();
            grdPatternList.DataSource = null;
            grdPatternList.Refresh();
        }

        private void UpdateKeySymbolS(CGroup cGroup, CGroupLogS cGroupLogS)
        {
            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateKeySymbolCyclePresentResultS(cGroup, cGroupLogS);
            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cKeyOption) == false)
                    RemoveKeySymbol(cGroup, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

		private void RemoveKeySymbol(CGroup cGroup, CTag cTag)
        {
            if (IsCycleSymbol(cGroup, cTag))
                return;

			if (cGroup.KeySymbolS.ContainsKey(cTag.Key))
				cGroup.RemoveAllSymbolS(cTag.Key);
        }

        private void UpdateSubSymbolS(CGroup cGroup, CGroupLogS cGroupLogS)
        {
            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateSubSymbolCyclePresentResultS(cGroup, cGroupLogS);
            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cSubKeyOption) == false)
                    RemoveSubSymbol(cGroup, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private void RemoveSubSymbol(CGroup cGroup, CTag cTag)
        {
			cGroup.RemoveAllSymbolS(cTag.Key);
        }

        private CCyclePresentResultS CreateKeySymbolCyclePresentResultS(CGroup cGroup, CGroupLogS cGroupLogS)
        {
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

        private CCyclePresentResultS CreateSubSymbolCyclePresentResultS(CGroup cGroup, CGroupLogS cGroupLogS)
        {   
            if (cGroupLogS == null || cGroupLogS.Count == 0)
                return null;

            //  SubKey 심볼 만
            CSymbol cSymbol;
			CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cGroup.KeySymbolS.Count; i++)
            {
				cSymbol = cGroup.KeySymbolS[i];
				cCandiTagS.AddRange(cSymbol.SubSymbolS.GetTotalTagS());
            }

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

        private bool IsCycleSymbol(CGroup cGroup, CTag cTag)
        {
            bool bOK = false;

            if (cGroup.CycleStartConditionS.ContainsKey(cTag.Key) || cGroup.CycleEndConditionS.ContainsKey(cTag.Key))
                bOK = true;

            return bOK;
        }

        #endregion


        #region Event Methods

        private void FrmPatternGenerator_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();
            ShowResult(m_cProject.MasterPatternS);
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucMonitorHistoryTable.Clear();

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CGroupLogS cLogS = m_cReader.GetGroupLogS(dtFrom, dtTo);
            if (cLogS != null)
            {
                ucMonitorHistoryTable.MonitorType = EMMonitorType.MasterPattern;
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

        private void ucMonitorHistoryTable_UEventHistoryDoubleClicked(object sender, DateTime dtStart, DateTime dtEnd, int iCycleCount)
        {
            if (m_bVerified == false)
                return;

            CFlowRule cRule = ucFlowRuleProperty.Rule;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            if (m_cViewMasterPatternS != null)
            {
                m_cViewMasterPatternS.Clear();
                m_cViewMasterPatternS = null;
            }

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                m_cViewMasterPatternS = CreateMasterPatternS(cRule, dtFrom, dtTo);

                ShowResult(m_cViewMasterPatternS);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (m_cViewMasterPatternS == null)
                m_cViewMasterPatternS = new CMasterPatternS();

            m_cProject.MasterPatternS.Clear();
            m_cProject.MasterPatternS = m_cViewMasterPatternS;
			m_cProject.GroupS.Compose(m_cProject.TagS);
            m_cProject.MasterPatternStep = EMMonitorModeType.UpdateEnd;

            this.Close();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion
    }

    #region View Class

    class CGroupPatternInfo
    {
        private string m_sGroup = "";
        private string m_sRecipe = "";
        private int m_iCount = 0;

        public CGroupPatternInfo(string sGroup, string sRecipe, int iCount)
        {
            m_sGroup = sGroup;
            m_sRecipe = sRecipe;
            m_iCount = iCount;
        }

        public string Group
        {
            get { return m_sGroup; }
            set { m_sGroup = value; }
        }

        public string Recipe
        {
            get { return m_sRecipe; }
            set { m_sRecipe = value; }
        }

        public int Count
        {
            get { return m_iCount; }
            set { m_iCount = value; }
        }
    }

    class CGroupPatternInfoS : List<CGroupPatternInfo>
    {

    }

    #endregion
}
