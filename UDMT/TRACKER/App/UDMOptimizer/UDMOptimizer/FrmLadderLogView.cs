using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;
using DevExpress.XtraEditors.Repository;
using UDM.Log.DB;

namespace UDMOptimizer
{
    public partial class FrmLadderLogView : DevExpress.XtraEditors.XtraForm
    {
        #region Member Veriables

        private CStep m_cStep = null;
        private CPlcLogicData m_cData = null;
        private bool m_bLoad = false;
        private int m_iStepLevel = -1;
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private DateTime m_dtSelectTime = DateTime.MinValue;
        private CTimeLogS m_cLogS = new CTimeLogS();
        private CTimeLogS m_cOpenStepTimeLogS = new CTimeLogS();

        private CTimeLogS m_cBaseTimeLogS = new CTimeLogS();

        private List<string> m_lstOpenKey = new List<string>();
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Initialize

        public FrmLadderLogView()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool IsLoad
        {
            get { return m_bLoad; }
            set { m_bLoad = value; }
        }

        public CPlcLogicData LogicData
        {
            get { return m_cData; }
            set { m_cData = value; }
        }

        public CStep Step
        {
            get { return m_cStep; }
            set { m_cStep = value; }
        }

        public DateTime StartTime
        {
            set { m_dtStart = value; }
        }

        public DateTime EndTime
        {
            set { m_dtEnd = value; }
        }

        public CTimeLogS TimeLogS
        {
            set { m_cLogS = value; }
        }

        public CMySqlLogReader ReaderDB
        {
            set { m_cReader = value; }
        }

        #endregion


        #region Public Method

        public void SetLadderStep(CPlcLogicData cData, CStep cStep, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                m_cData = cData;

                m_iStepLevel = iStepLevel;

                UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.AutoScroll = true;
                ucStep.ScaleDefault = 1f; // 0.6f;
                ucStep.Scrollable = true;
                ucStep.StepLevel = iStepLevel;
                ucStep.IsViewStep = bView;
                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag != null)
                {
                    CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                    string sDesc = cTag.Name != string.Empty ? cTag.Name : cTag.Description;

                    ucStep.StepName =
                        string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                            cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
                }
                else
                {
                    CCoil cCoil = cStep.CoilS.GetFirstCoil();

                    ucStep.StepName =
                        string.Format("CPU : {3} / Program : {0} / Network : {1} / 설명 : {2}",
                            cStep.Program, cStep.StepIndex, cCoil.Instruction.Replace("\t", "  "), m_cData.PlcChannel);
                }

                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlLadder.Controls.Add(ucStep);

                FindOpenStepTimeLogS();
                InitTrackBar(true);
            }
        }

        #endregion


        #region Private Method
        
        private void InitTrackBar(bool bFirst)
        {
            if (m_cOpenStepTimeLogS == null || m_cOpenStepTimeLogS.Count == 0) return;
            string sTime;
            List<TrackBarLabel> lstLabel = new List<TrackBarLabel>();
            try
            {
                List<IGrouping<string, CTimeLog>> lstLogS = m_cOpenStepTimeLogS.OrderBy(x => x.Time).GroupBy(x => x.Time.ToString("yyyy-MM-dd HH:mm:ss.fff")).ToList();

                int iCount = lstLogS.Count - 1;
                int iFindStartPos = 0;
                List<string> lstSameFilter = new List<string>();
                for (int i = 0; i < lstLogS.Count; i++)
                {
                    sTime = lstLogS[i].Key;//.Split(' ')[1];
                    if (lstSameFilter.Contains(sTime)) continue;
                    lstSameFilter.Add(sTime);
                    TrackBarLabel cLabel = new DevExpress.XtraEditors.Repository.TrackBarLabel(sTime, i);
                    lstLabel.Add(cLabel);
                    if (bFirst)
                    {
                        if (sTime == m_dtStart.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                        {
                            iFindStartPos = i;
                            m_dtSelectTime = m_dtStart;
                        }
                    }
                    else
                    {
                        if (sTime == m_dtSelectTime.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                            iFindStartPos = i;
                    }
                }

                trbLogTime.Properties.Labels.Clear();
                trbLogTime.Properties.Labels.AddRange(lstLabel.ToArray());
                trbLogTime.Properties.Minimum = 0;
                trbLogTime.Properties.Maximum = iCount;
                trbLogTime.Properties.TickFrequency = iCount / 10;

                trbLogTime.Value = iFindStartPos + 1;


                trbLogTime.Refresh();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private CStep GetMasterStep(CTag cTag)
        {
            if (cTag == null) return null;
            if (m_cData == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();


            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if (m_cData.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(m_cData.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (m_cData.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = m_cData.StepS[who.StepKey];

                        if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                            lstStep.Add(cStep);
                    }
                }
            }


            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.TopMost = true;
                    frmSelector.ShowDialog();

                    if (frmSelector.IsSelectStep)
                    {
                        cStep = frmSelector.GetSelectedStep();
                    }

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            else
                XtraMessageBox.Show("해당 태그는 출력 접점으로 사용되지 않았습니다.");

            return cStep;
        }

        private bool CheckDoubleCoil(CTag cTag)
        {
            bool bOK = false;

            int iCoilCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Coil).Count();
            int iBothCount = 0;
            List<string> lstBothStepKey = new List<string>();
            string sStepKey = string.Empty;

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType.Equals(EMStepRoleType.Both))
                {
                    sStepKey = who.StepKey;

                    if (sStepKey.Contains("["))
                        sStepKey = sStepKey.Split('[').First();

                    if (!lstBothStepKey.Contains(sStepKey))
                    {
                        lstBothStepKey.Add(sStepKey);
                        iBothCount++;
                    }
                }
            }

            int iCount = iCoilCount + iBothCount;

            if (iCount >= 2)
                bOK = true;

            return bOK;
        }

        private bool CheckContainCoilTag(CCoil cCoil, CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cCoil.ContentS)
            {
                if (who.Tag != null && who.Tag.Key == cTag.Key)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private void FindOpenStepTimeLogS()
        {
            m_lstOpenKey.Clear();
            m_cBaseTimeLogS.Clear();
            foreach (Control con in pnlLadder.Controls)
            {
                UCLadderStep ucLadder = (UCLadderStep)con;
                if (ucLadder.Step != null)
                    m_lstOpenKey.AddRange(ucLadder.Step.RefTagS.KeyList);
            }
            m_cOpenStepTimeLogS.Clear();
            List<string> lstNotFoundKey = new List<string>();
            foreach (string sKey in m_lstOpenKey)
            {
                List<CTimeLog> lstLog = m_cLogS.FindAll(b => b.Key == sKey).ToList();
                if (lstLog.Count > 0)
                    m_cOpenStepTimeLogS.AddRange(lstLog);
                else
                {
                    //전체검색
                    lstNotFoundKey.Add(sKey);
                    //CTimeLogS cFindLogS = m_cReader.GetTimeLogS(sKey, 1, m_dtStart);
                    //if (cFindLogS != null && cFindLogS.Count > 0)
                    //{
                    //    foreach (CTimeLog cLog in cFindLogS)
                    //    {
                    //        if (m_dtStart > cLog.Time)
                    //        {
                    //            m_cBaseTimeLogS.Add(cLog);
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }
            m_cBaseTimeLogS = m_cReader.GetTimeLogS(lstNotFoundKey, 1, m_dtStart);
            //foreach (string sKey in lstNotFoundKey)
            //{
            //    int iCount = m_cBaseTimeLogS.Where(b => b.Key == sKey).Count();
            //    if (iCount == 0)
            //    {
            //        //TimeLog
            //        int a = 0;
            //    }
            //}
        }

        #endregion


        #region Form Event

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlLadder.Controls.Clear();
            this.Hide();
            m_bLoad = false;
        }

        private void FrmLadderView_Load(object sender, EventArgs e)
        {

        }

        private void btnLadderStepDelete_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl == null || this.ActiveControl.GetType() != typeof(UCLadderStep))
                return;

            UCLadderStep ucStep = (UCLadderStep) this.ActiveControl;
            pnlLadder.Controls.Remove(ucStep);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnlLadder.Controls.Clear();
        }

        private void FrmLadderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bLoad = false;
        }

        private void FrmLadderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            pnlLadder.Controls.Clear();
            this.Hide();
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            m_bLoad = false;
        }

        private void trbLogTime_Properties_ValueChanged(object sender, EventArgs e)
        {
            if (m_cLogS == null || m_cLogS.Count == 0) return;
            if (m_cOpenStepTimeLogS == null || m_cOpenStepTimeLogS.Count == 0) return;
            string sTime = "";
            CTimeLogS cLogS = new CTimeLogS();
            try
            {
                if (trbLogTime.Value != 0)
                {
                    
                    sTime = trbLogTime.Properties.Labels[trbLogTime.Value - 1].Label;
                    DateTime dtTrbTime = DateTime.Parse(sTime);
                    m_dtSelectTime = dtTrbTime;
                    decimal dcTime = decimal.Parse(dtTrbTime.ToString("yyyyMMddHHmmss.fff"));

                    List<CTimeLog> lstTimeLog = m_cOpenStepTimeLogS.Where(x => decimal.Parse(x.Time.ToString("yyyyMMddHHmmss.fff")) <= dcTime).ToList();

                    foreach (CTimeLog cLog in lstTimeLog)
                    {
                        List<CTimeLog> lstLog = cLogS.Where(x => x.Key == cLog.Key).ToList();

                        if (lstLog.Count > 0)
                        {
                            foreach (CTimeLog cTimeLog in cLogS)
                            {
                                if (cTimeLog.Key == cLog.Key)
                                {
                                    if (cTimeLog.Value != cLog.Value)
                                    {
                                        cTimeLog.Value = cLog.Value;
                                        cTimeLog.Time = cLog.Time;
                                    }
                                }
                            }
                        }
                        else
                            cLogS.Add(cLog);
                    }
                }
                cLogS.AddRange(m_cBaseTimeLogS);
                foreach (Control con in pnlLadder.Controls)
                {
                    UCLadderStep ucLadder = (UCLadderStep)con;
                    if (ucLadder.Step != null)
                    {
                        ucLadder.SymbolLogS = cLogS;
                        ucLadder.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            try
            {
                if (cTag == null) return;
                CStep cStep = GetMasterStep(cTag);

                if (cStep != null)
                {
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlLadder.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep)pnlLadder.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                        {
                            lstRemove.Add(ucView);
                        }
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.");
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                        pnlLadder.Controls.Remove(lstRemove[i]);

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.ScaleDefault = 1f; // 0.6f;
                    ucStep.Scrollable = true;
                    ucStep.StepLevel = iStepLevel + 1;

                    string sDesc = cTag.Name != string.Empty ? cTag.Name : cTag.Description;

                    ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                    pnlLadder.Controls.Add(ucStep);

                    FindOpenStepTimeLogS();
                    InitTrackBar(false);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void trbLogTime_Properties_BeforeShowValueToolTip(object sender, TrackBarValueToolTipEventArgs e)
        {
            if (trbLogTime.Value != 0)
                e.ShowArgs.ToolTip = m_cLogS[trbLogTime.Value - 1].Time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            else
                e.ShowArgs.Show = false;
        }

    }
}