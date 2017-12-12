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
using TrackerCommon;
using UDM.Log;

namespace UDMLadderTracker
{
    public partial class FrmLadderView : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private CTag m_cMasterTag = null;
        private CStep m_cMasterStep = null;
        private CPlcLogicData m_cLogicData = null;

        #endregion

        public CTag MasterTag
        {
            get { return m_cMasterTag; }
            set { m_cMasterTag = value; }
        }

        public CStep MasterStep
        {
            get { return m_cMasterStep; }
        }

        public CPlcLogicData LogicData
        {
            get { return m_cLogicData; }
            set { m_cLogicData = value; }
        }


        public FrmLadderView()
        {
            InitializeComponent();
        }

        private void FrmLadderView_Load(object sender, EventArgs e)
        {
            UCViewLadder ucViewLadder = new UCViewLadder();
            ucViewLadder.LogciData = m_cLogicData;
            ucViewLadder.MasterTag = m_cMasterTag;
            ucViewLadder.StepName = string.Format("Program : {0} / Network : {1} / Coil : {2}", ucViewLadder.MasterStep.Program, ucViewLadder.MasterStep.StepIndex, m_cMasterTag.Address);
            ucViewLadder.Dock = DockStyle.Top;
            //if (ucViewLadder.Size.Width > this.Size.Width)
            {
                this.Size = new Size(ucViewLadder.Size.Width, this.Size.Height);
            }
            ucViewLadder.UEventSelectedCellData += ucViewLadder_UEventSelectedCellData;
            pnlView.Controls.Add(ucViewLadder);
            
            //this.BringToFront();
        }

        void ucViewLadder_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            UCViewLadder ucViewLadder = null;
            List<UCViewLadder> lstRemove = new List<UCViewLadder>();
            //List<UCViewLadder> lstView = new List<UCViewLadder>();
            //bool bSameStepFind = false;
            for (int i = 0; i < pnlView.Controls.Count; i++)
            {
                UCViewLadder ucView = (UCViewLadder)pnlView.Controls[i];
                if (ucView.StepLevel > iStepLevel)
                    lstRemove.Add(ucView);
                //else
                //    lstView.Add(ucView);
                //if (ucView.MasterStep.Address == cTag.Address)
                //    bSameStepFind = true;
            }
            for (int i = 0; i < lstRemove.Count; i++)
                pnlView.Controls.Remove(lstRemove[i]);
            //pnlView.Controls.Clear();
            //for (int i = 0; i < lstView.Count; i++)
            //    pnlView.Controls.Add(lstView[i]);
            //if (bSameStepFind)
            //{
            //    MessageBox.Show("이미 같은 Step이 열려 있습니다.");
            //    return;
            //}
            //새로 생성
            ucViewLadder = new UCViewLadder();
            ucViewLadder.LogciData = m_cLogicData;
            ucViewLadder.StepLevel = iStepLevel + 1;
            ucViewLadder.MasterTag = cTag;
            ucViewLadder.TimeLogS = cLogS;

            if (ucViewLadder.MasterStep == null)
            {
                MessageBox.Show("하위조건을 찾을 수 없습니다.");
                return;
            }
            ucViewLadder.StepName = string.Format("Program : {0} / Network : {1} / Coil : {2}", ucViewLadder.MasterStep.Program, ucViewLadder.MasterStep.StepIndex, cTag.Address);
            ucViewLadder.Dock = DockStyle.Top;
            //if (ucViewLadder.Size.Width > this.Size.Width)
            {
                this.Size = new Size(ucViewLadder.Size.Width, this.Size.Height);
            }
            ucViewLadder.UEventSelectedCellData += ucViewLadder_UEventSelectedCellData;
            pnlView.Controls.Add(ucViewLadder);

            //for (int i = 0; i < pnlView.Controls.Count; i++)
            //    pnlView.Controls[i].BringToFront();
        }
    }
}