using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Flow;
using UDM.UI.TimeChart;
using TrackerCommon;

namespace UDMLadderTracker
{
    public partial class FrmMasterPatternEditor : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CMasterPatternS m_cViewMasterPatternS = null;

        #endregion


        #region Initialize/Dispose

        public FrmMasterPatternEditor()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.PlcProcS == null)
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(CMultiProject.PlcProcS.Count == 0)
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {

        }

        private void ShowGroupList()
        {
            cmbGroup.EditValue = null;
            cmbIndex.EditValue = null;
            exEditorGroup.Items.Clear();
            exEditorRecipe.Items.Clear();
            exEditorIndex.Items.Clear();

            if (CMultiProject.PlcProcS == null)
                return;

            foreach(var who in CMultiProject.PlcProcS)
            {
                exEditorGroup.Items.Add(who.Key);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private void ShowRecipeList(string sGroup)
        {
            cmbRecipe.EditValue = null;
            exEditorRecipe.Items.Clear();

            if (m_cViewMasterPatternS.ContainsKey(sGroup) == false)
                return;

            CMasterPattern cMasterPattern = m_cViewMasterPatternS[sGroup];
            for(int i = 0; i < cMasterPattern.Count; i++)
                exEditorRecipe.Items.Add(cMasterPattern.ElementAt(i).Key);

            if (exEditorRecipe.Items.Count > 0)
                cmbRecipe.EditValue = exEditorRecipe.Items[0];
        }

        private void ShowIndexList(string sGroup, string sRecipe)
        {
            cmbIndex.EditValue = null;
            exEditorIndex.Items.Clear();

            if (m_cViewMasterPatternS.ContainsKey(sGroup) == false)
                return;

            CMasterPattern cMasterPattern = m_cViewMasterPatternS[sGroup];
            if (cMasterPattern.ContainsKey(sRecipe) == false)
                return;

            CFlowS cFlowS = cMasterPattern[sRecipe];
            for (int i = 0; i < cFlowS.Count; i++)
            {
                exEditorIndex.Items.Add(i.ToString());
            }
            
            if (exEditorIndex.Items.Count > 0)
                cmbIndex.EditValue = exEditorIndex.Items[0];
        }

        private void RemoveMasterFlow(CGanttItem cGanttItem)
        {
			CGanttItem cRecipeItem = (CGanttItem)cGanttItem.Parent;
			CGanttItem cGroupItem = (CGanttItem)cRecipeItem.Parent;
			if (cRecipeItem == null)
                return;

            CFlow cFlow = (CFlow)cGanttItem.Data;
            CMasterPattern cMasterPattern = m_cViewMasterPatternS[cGroupItem.Data.ToString()];
            CFlowS cFlowS = cMasterPattern[cRecipeItem.Data.ToString()];
            cFlowS.Remove(cFlow);

			cRecipeItem.ItemS.Remove(cGanttItem);
        }

        #endregion


        #region Event Methods

        private void FrmPatternEditor_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            m_cViewMasterPatternS = (CMasterPatternS)CMultiProject.MasterPatternS.Clone();

            InitComponent();
            ShowGroupList();
        }

        private void cmbGroup_EditValueChanged(object sender, EventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (cmbGroup.EditValue == null)
                return;

            string sGroup = cmbGroup.EditValue.ToString();
            ShowRecipeList(sGroup);
        }

        private void cmbRecipe_EditValueChanged(object sender, EventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (cmbRecipe.EditValue == null)
                return;

            string sGroup = cmbGroup.EditValue.ToString();
            string sRecipe = cmbRecipe.EditValue.ToString();
            ShowIndexList(sGroup, sRecipe);
        }

        private void btnRemovePattern_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

			List<CRowItem> lstItem = ucFlowEditor.GetSelectedItemList();
			if (lstItem == null)
				return;

			CGanttItem cGanttItem;
			for (int i = 0; i < lstItem.Count; i++)
			{
				cGanttItem = (CGanttItem)lstItem[i];
				if (cGanttItem.Data == null)
					continue;

				if (cGanttItem.Data.GetType() == typeof(CFlow))
					RemoveMasterFlow(cGanttItem);
			}

			string sGroup = cmbGroup.EditValue.ToString();
			string sRecipe = cmbRecipe.EditValue.ToString();
			ShowIndexList(sGroup, sRecipe);
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (cmbIndex.EditValue == null) return;


            string sGroup = cmbGroup.EditValue.ToString();
            string sRecipe = cmbRecipe.EditValue.ToString();
            string sIndex = cmbIndex.EditValue.ToString();

            if (sIndex == null || sIndex == "")
                return;

            int iIndex = int.Parse(sIndex);

            CMasterPattern cMasterPattern = m_cViewMasterPatternS[sGroup];
            if (cMasterPattern.ContainsKey(sRecipe) == false)
                return;

            if (cMasterPattern[sRecipe].Count > iIndex)
            {
                CFlow cFlow = cMasterPattern[sRecipe][iIndex];
                ucFlowEditor.ShowChart(sGroup, sRecipe, iIndex, cFlow);
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucFlowEditor.Clear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucFlowEditor.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucFlowEditor.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucFlowEditor.ItemUp();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucFlowEditor.ItemDown();
        }

        private void btnCreatePattern_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            string sProcessKey = cmbGroup.EditValue.ToString();
            string sRecipe = cmbGroup.EditValue.ToString();

            CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];
			CSymbolS cSymbolS = cProcess.KeySymbolS.GetFlowViewSymbolS(sProcessKey);

            CFlow cFlow = new CFlow();
            cFlow.Create(cSymbolS);
            cFlow.Key = sProcessKey;

            m_cViewMasterPatternS.Add(sProcessKey, sRecipe, cFlow);

            CMasterPattern cMasterPattern = m_cViewMasterPatternS[sProcessKey];

            ucFlowEditor.ShowChart(sProcessKey, sRecipe, cMasterPattern[sRecipe].Count - 1, cFlow);
            ShowIndexList(sProcessKey, sRecipe);
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (m_cViewMasterPatternS == null)
                m_cViewMasterPatternS = new CMasterPatternS();

            CMultiProject.MasterPatternS.Clear();
            CMultiProject.MasterPatternS = m_cViewMasterPatternS;

            this.Close();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}