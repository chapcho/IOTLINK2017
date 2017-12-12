using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.General.Statistics;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public partial class UCOperatingRatio : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private CTeamInfoS m_cTeamInfoS = null;
        private CTeamInfo m_cTeamInfoCur = null;
        private CMySqlLogWriter m_cWriter = null;

        private List<DateTime> m_lstProductionTime = new List<DateTime>(); 
        private List<double> m_lstCycle = new List<double>();

        private bool m_bRunning = false;
        private bool m_bOperFirst = true;

        private delegate void UpdateProductionInfoCallback(string sTagKey, DateTime dtActTime);
        private delegate void UpdateRecipeCallBack(string sRecipe);

        public UEventHandlerTrackerMessage UEventMessage = null;
        //public UEventHandlerOperationTimeChecker UEventOperationTimeCheck = null;

        #endregion


        #region Initialize

        public UCOperatingRatio()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool IsRunning
        {
            get { return m_bRunning; }
            set { m_bRunning = value; }
        }

        public bool IsOperFirst
        {
            get { return m_bOperFirst; }
            set 
            {
                m_bOperFirst = value;
                //ucClock2.IsOperFirst = m_bOperFirst; //Auto Monitoring Mod
            }
        }
        #endregion


        #region Public Method

        public void UpdateProductionInfo(string sTagKey, DateTime dtActTime)
        {
            if (this.InvokeRequired)
            {
                UpdateProductionInfoCallback cUpdate = new UpdateProductionInfoCallback(UpdateProductionInfo);
                this.Invoke(cUpdate, new object[] {sTagKey, dtActTime});
            }
            else
            {
                if (m_cTeamInfoCur == null)
                    return;

                if (sTagKey != m_cTeamInfoCur.TagKey)
                    return;

                m_cTeamInfoCur.CurrentCount += 1;

                if (m_lstProductionTime.Count != 0)
                {
                    DateTime dtLast = m_lstProductionTime.Last();
                    m_lstCycle.Add(dtActTime.Subtract(dtLast).TotalMilliseconds);
                }

                m_lstProductionTime.Add(dtActTime);

                if (m_lstCycle.Count != 0)
                {
                    double dCycleMean = CStatics.Mean(m_lstCycle);
                    m_cTeamInfoCur.UPH = Math.Round(3600000/dCycleMean, 2);
                }

                SetTeam(m_cTeamInfoCur);
                WriteProductionInfoLog(dtActTime);
            }
        }

        public void UpdateRecipe(string sRecipe)
        {
            if (this.InvokeRequired)
            {
                UpdateRecipeCallBack cUpdate = new UpdateRecipeCallBack(UpdateRecipe);
                this.Invoke(cUpdate, new object[] { sRecipe });
            }
            else
            {
                lblMessage.Text = sRecipe;
                this.Refresh();
            }
        }

        public void RefreshProductionInfo()
        {
            //if (CMultiProject.TeamInfoS == null)
            //    CMultiProject.TeamInfoS = new CTeamInfoS();

            //m_cTeamInfoS = CMultiProject.TeamInfoS;

            //if (m_cTeamInfoS.Count != 0)
            //{
            //    CTeamInfo cInfo = m_cTeamInfoS.GetTeamInfo(DateTime.Now);

            //    if (cInfo != null)
            //    {
            //        Clear(cInfo);
            //        SetTeam(cInfo);
            //    }
            //}
            //else
            //    ChageTeamTextView(2);
        }

        #endregion


        #region Private Method

        private void Clear(CTeamInfo cInfo)
        {
            cInfo.Clear();
            m_lstCycle.Clear();
            m_lstProductionTime.Clear();
        }

        private void ChangeTextBox(UCTextView ucView, bool bActive)
        {
            if (bActive)
            {
                ucView.TextBackColor1 = Color.LimeGreen;
                ucView.TextBackColor2 = Color.Lime;
            }
            else
            {
                ucView.TextBackColor1 = Color.DarkGray;
                ucView.TextBackColor2 = Color.Silver;
            }
        }

        private void ChageTeamTextView(int iStep)
        {
            //0 = Team A Start
            //1 = Team B Start
            //2 = End

            ucTextAGoal.TextData = "목표\r\n수량";
            ucTextANow.TextData = "생산\r\n수량";
            if (iStep == 0)
            {
                ChangeTextBox(ucTextAGoal, true);
                ChangeTextBox(ucTextAGoalCount, true);
                ChangeTextBox(ucTextANow, true);
                ChangeTextBox(ucTextANowCount, true);
                ChangeTextBox(ucTextATeam, true);
                ChangeTextBox(ucTextATime, true);
                gaugeAGoal.ColorScheme.Color = Color.Red;
                ucTextATeam.TextData = "주간";
                ucTextATime.TextData = "07시~\r\n15시  ";
                ucTextTeam.TextData = "주간";
            }
            else if (iStep == 1)
            {
                ChangeTextBox(ucTextAGoal, true);
                ChangeTextBox(ucTextAGoalCount, true);
                ChangeTextBox(ucTextANow, true);
                ChangeTextBox(ucTextANowCount, true);
                ChangeTextBox(ucTextATeam, true);
                ChangeTextBox(ucTextATime, true);
                gaugeAGoal.ColorScheme.Color = Color.Red;
                ucTextATeam.TextData = "야간";
                ucTextATime.TextData = "15시~\r\n01시  ";
                ucTextTeam.TextData = "야간";
            }
            else
            {
                ChangeTextBox(ucTextAGoal, false);
                ChangeTextBox(ucTextAGoalCount, false);
                ChangeTextBox(ucTextANow, false);
                ChangeTextBox(ucTextANowCount, false);
                ChangeTextBox(ucTextATeam, false);
                ChangeTextBox(ucTextATime, false);
                gaugeAGoal.ColorScheme.Color = Color.DimGray;
                ucTextATeam.TextData = "작업\r\n대기";
                ucTextATime.TextData = "01시~\r\n07시  ";
                ucTextTeam.TextData = "작업 대기";
            }
        }

        private void SetTeam(CTeamInfo cInfo)
        {
            ucTextAGoal.TextData = "목표\r\n수량";
            ucTextANow.TextData = "생산\r\n수량";
            ChangeTextBox(ucTextAGoal, true);
            ChangeTextBox(ucTextAGoalCount, true);
            ChangeTextBox(ucTextANow, true);
            ChangeTextBox(ucTextANowCount, true);
            ChangeTextBox(ucTextATeam, true);
            ChangeTextBox(ucTextATime, true);
            gaugeAGoal.ColorScheme.Color = Color.Red;
            arcScaleTeamA.Value = cInfo.Ratio;
            lblTeamA.Text = cInfo.Ratio.ToString("#.00");
            ucTextATeam.TextData = cInfo.TeamName;
            ucTextATime.TextData = cInfo.Duration;
            ucTextTeam.TextData = cInfo.TeamName;
            ucTextAGoalCount.TextData = cInfo.TargetCount.ToString();
            ucTextANowCount.TextData = cInfo.CurrentCount.ToString();
            ucTextUPH.TextData = cInfo.UPH.ToString("#.00");
            ucTextEndTime.TextData = cInfo.EndTime;

            m_cTeamInfoCur = cInfo;
        }

        private void WriteProductionInfoLog(DateTime dtActTime)
        {
            if (m_cWriter == null || m_cWriter.IsConnected == false)
            {
                m_cWriter = new CMySqlLogWriter();
                m_cWriter.Connect();
            }

            CProductionInfo cInfo = new CProductionInfo();
            cInfo.CurrentCount = m_cTeamInfoCur.CurrentCount;
            cInfo.ProductionTime = dtActTime;
            cInfo.Ratio = m_cTeamInfoCur.Ratio;
            cInfo.TagKey = m_cTeamInfoCur.TagKey;
            cInfo.TargetCount = m_cTeamInfoCur.TargetCount;
            cInfo.TeamName = m_cTeamInfoCur.TeamName;
            cInfo.UPH = m_cTeamInfoCur.UPH;
            cInfo.CurrentRecipe = m_cTeamInfoCur.CurrentRecipe;

            m_cWriter.WriteProductionInfo(cInfo, CMultiProject.ProjectID);

            cInfo = null;
        }

        #endregion


        #region User Event

        private void ucClock2_UEventChangeTime(DateTime dtTime, CTeamInfo cTeamInfo)
        {
            Clear(cTeamInfo);
            SetTeam(cTeamInfo);
        }

        private void ucClock2_UEventMessage(string sSender, string sMessage)
        {
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private void ucClock2_UEventOperationTimeChecker(bool bStartTime)
        {
            //if (UEventOperationTimeCheck != null)
            //    UEventOperationTimeCheck(bStartTime);
        }

        #endregion


        #region Form Event

        private void UCOperatingRatio_Load(object sender, EventArgs e)
        {            
            //ucClock2.TeamInfoS = m_cTeamInfoS;
            //ucClock2.UEventChangeTime += ucClock2_UEventChangeTime;
            //ucClock2.UEventMessage += ucClock2_UEventMessage;
            //ucClock2.UEventOperationTimeChecker += ucClock2_UEventOperationTimeChecker;
            if (m_cTeamInfoS == null || m_cTeamInfoS.Count == 0)
                ChageTeamTextView(2);
        }

        private void btnSettingEdit_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}

