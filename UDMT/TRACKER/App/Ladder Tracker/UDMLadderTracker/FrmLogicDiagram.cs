using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.Tree;

using UDM.Common;
using UDM.Log;
using UDM.LogicViewer;
using TrackerCommon;
using UDM.Log.DB;

namespace UDMLadderTracker
{
    public partial class FrmLogicDiagram : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;

        private CLogicDiagram m_cDiagram = null;
        private CTimeLogS m_cTimeLogS = null;
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Initialize/Dispose

        public FrmLogicDiagram()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        #endregion


        #region Public Properties

        public CMySqlLogReader LogReader
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

            return true;
        }

        private void InitPLC()
        {
            foreach (CPlcLogicData cLogic in CMultiProject.PlcLogicDataS.Values)
                exEditorPLC.Items.Add(cLogic.PlcName);

            cboPLC.EditValue = exEditorPLC.Items[0];
        }

        private void ShowTable(CPlcLogicData cData)
        {
            ucMultiStepTagTable.PlcLogicData = cData;
            ucMultiStepTagTable.ShowTable();
        }

        private void InitDiagram(CPlcLogicData cData)
        {
            if (cData != null)
            {
                if (m_cDiagram != null)
                {
                    m_cDiagram.UEventDrawDiagram -= new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
                    m_cDiagram.Dispose();
                    m_cDiagram = null;
                }

                m_cDiagram = new CLogicDiagram(cData.StepS, cData.TagS, ucLogicDiagramS);
                m_cDiagram.UEventDrawDiagram += new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
            }
        }

        private void ShowDiagram(CStep cStep)
        {
            if(m_cTimeLogS == null)
                m_cTimeLogS = new CTimeLogS();

            DateTime dtLastTime = m_cReader.GetLastTimeLogTime();
            m_cTimeLogS.AddRange(m_cReader.GetTimeLogS(cStep.RefTagS.KeyList, dtLastTime.AddMinutes(-30), dtLastTime));
            
            m_cDiagram.ShowDiagram(cStep, m_cTimeLogS, true, true, false, false);
        }

        #endregion


        #region Event Methods

        private void FrmLogicDiagram_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitPLC();            
        }
        
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sPLC = string.Empty;

            if (cboPLC.EditValue == null || (string)cboPLC.EditValue == string.Empty)
                return;

            sPLC = (string)cboPLC.EditValue;
            CPlcLogicData cData = null;

            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                if (who.Value.PlcName == sPLC)
                {
                    cData = who.Value;
                    break;
                }
            }

            if (cData == null)
                return;

            ShowTable(cData);
            InitDiagram(cData);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucMultiStepTagTable.Clear();
            ucLogicDiagramS.ClearTabs();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if(ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
        }

        private void btnMinimize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(false);
        }

        private void btnMaximize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(true);
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucStepTagTable_UEventStepDoubleClicked(object sender, CStep cStep)
        {
            if (m_bVerified == false)
                return;

            ShowDiagram(cStep);
        }

        private void ucStepTagTable_UEventTagDoubleClicked(object sender, CTag cTag)
        {
            if (m_bVerified == false)
                return;

            List<CStep> lstStep = CMultiProject.GetStepList(cTag.Key);

            CStep cStep = null;
            if (lstStep.Count == 0)
            {
                return;
            }
            else if (lstStep.Count == 1)
            {
                cStep = lstStep[0];
            }
            else
            {
                FrmStepSelector frmSelector = new FrmStepSelector();
                frmSelector.StepList = lstStep;
                frmSelector.ShowDialog();

                cStep = frmSelector.GetSelectedStep();

                frmSelector.Dispose();
                frmSelector = null;
            }

            if (cStep != null)
                ShowDiagram(cStep);          
        }

        private void m_cDiagram_UEventDrawDiagram(Node selectNode, CLDRung cLDRung, DateTime dtCurrent)
        {
            cLDRung.TimeLogS = m_cTimeLogS;
        }

        #endregion

        private void cboPLC_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}