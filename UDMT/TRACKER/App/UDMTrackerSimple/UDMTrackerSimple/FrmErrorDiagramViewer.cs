using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.LogicViewer;
using UDM.Log;
using UDM.Common;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public partial class FrmErrorDiagramViewer : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private CLogicDiagram m_cDiagram = null;
        private CErrorInfo m_cErrorInfo = null;
        private CPlcLogicData m_cPlcLogicData = null;
        private CTag m_cInterlockTag = null;

        #endregion


        #region Initialize

        public FrmErrorDiagramViewer()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; }
        }
        
        public CPlcLogicData PlcLogicData
        {
            get { return m_cPlcLogicData; }
            set { m_cPlcLogicData = value; }
        }

        public CTag InterlockTag
        {
            get { return m_cInterlockTag; }
            set { m_cInterlockTag = value; }
        }

        #endregion


        #region Private Method

        private void InitDiagram()
        {
            if (m_cPlcLogicData != null)
            {
                if (m_cDiagram != null)
                {
                    m_cDiagram.UEventDrawDiagram -= new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
                    m_cDiagram.Dispose();
                    m_cDiagram = null;
                }

                m_cDiagram = new CLogicDiagram(m_cPlcLogicData.StepS, m_cPlcLogicData.TagS, ucLogicDiagramS);
                m_cDiagram.UEventDrawDiagram += new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
            }
        }

        private void ShowDiagram(CTimeLogS cErrorLogS)
        {
            if (m_cErrorInfo == null) return;

            List<CStep> lstStep = CMultiProject.GetCoilStepList(CMultiProject.TotalTagS[m_cErrorInfo.CoilKey]);
            if (lstStep == null || lstStep.Count == 0)
            {
                this.Close();
                MessageBox.Show("하위 조건 정보가 없습니다.");
                return;
            }

            CStep cStep = lstStep[0];
            CTimeLogS cLogS = cErrorLogS;

            if (cStep.Instruction.Contains("RST") && lstStep.Count > 1)
                cStep = lstStep[1];
            
            m_cDiagram.ShowDiagram(cStep, cLogS, true, true, true, true);
        }

        #endregion


        private void btnDiagramMaximize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(true);
        }

        private void btnDiagramMinimize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(false);
        }

        private void m_cDiagram_UEventDrawDiagram(DevComponents.Tree.Node selectNode, CLDRung cLDRung, DateTime dtCurrent)
        {

            if (cLDRung == null)
                return;
            if (m_cErrorInfo == null) return;

            cLDRung.TimeLogS = m_cErrorInfo.ErrorLogS;
        }

        private void FrmErrorDiagramViewer_Load(object sender, EventArgs e)
        {
            InitDiagram();
            ShowDiagram(m_cErrorInfo.ErrorLogS);
        }

    }
}