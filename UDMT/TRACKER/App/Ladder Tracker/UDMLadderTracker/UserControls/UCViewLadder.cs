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
using TrackerCommon;
using UDM.Ladder;
using UDM.Log;

namespace UDMLadderTracker
{


    public partial class UCViewLadder : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private CTag m_cMasterTag = null;
        private CStep m_cMasterStep = null;
        private CPlcLogicData m_cLogicData = null;
        private int m_iStepLevel = 0;
        private CTimeLogS m_cTimeLogS = new CTimeLogS();

        public event UEventHandlerSelectedCellData UEventSelectedCellData = null;

        private Point m_CurrentPosition = new Point(0, 0);

        #endregion


        #region Initialize

        public UCViewLadder()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CTag MasterTag
        {
            get { return m_cMasterTag; }
            set 
            { 
                m_cMasterTag = value;
                GetMasterStep(value);
            }
        }

        public CStep MasterStep
        {
            get { return m_cMasterStep; }
        }

        public CPlcLogicData LogciData
        {
            set { m_cLogicData = value; }
        }

        public string StepName
        {
            set
            {
                grpMain.Text = value;
                grpMain.Refresh();
            }
        }

        public int StepLevel
        {
            get { return m_iStepLevel; }
            set { m_iStepLevel = value; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        #endregion


        #region Private Method

        private void GetMasterStep(CTag cTag)
        {
            if (cTag == null) return;
            if (m_cLogicData == null) return;

            List<CStep> lstStep = m_cLogicData.StepS.Where(b => b.Value.Address == cTag.Address).Select(b=>b.Value).ToList();
            
            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    m_cMasterStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.ShowDialog();

                    m_cMasterStep = frmSelector.GetSelectedStep();

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
        }

        #endregion

        private void UCViewLadder_Load(object sender, EventArgs e)
        {
            if (m_cMasterStep == null) return;
            UCLadderStep ucStep = new UCLadderStep(m_cMasterStep, m_cTimeLogS, EditorBrand.Common);
            ucStep.Dock = DockStyle.Fill;
            ucStep.AutoSizeParent = true;
            ucStep.ScaleDefault = 0.7f;// 0.6f;
            ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
            pnlView.Controls.Add(ucStep);
            this.Size = ucStep.Size;
            //this.Size = new System.Drawing.Size(ucStep.Size.Width + 20, ucStep.Size.Height + 50);
            ucStep.Update();
            pnlView.Update();
        }

        void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            if (cTag == null) return;
            if (UEventSelectedCellData != null)
            {
                UEventSelectedCellData(cTag, m_iStepLevel, cLogS);
            }

        }

        public void ChangeLadder()
        {
            if (m_cMasterStep == null) return;
            pnlView.Controls.Clear();
            UCLadderStep ucStep = new UCLadderStep(m_cMasterStep, m_cTimeLogS, EditorBrand.Common);
            ucStep.Dock = DockStyle.Fill;
            ucStep.AutoSizeParent = true;
            //ucStep.ScaleDefault = 0.7f;// 0.6f;
            ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
            pnlView.Controls.Add(ucStep);
            pnlView.Update();
        }

    }
}
