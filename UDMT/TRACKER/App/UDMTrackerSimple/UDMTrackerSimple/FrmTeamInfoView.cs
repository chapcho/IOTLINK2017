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
using UDM.General.Statistics;

namespace UDMTrackerSimple
{
    public partial class FrmTeamInfoView : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private List<double> m_lstCycleTime = new List<double>();
        protected delegate void ShowLineInfoCallBack(List<CLineInfoTag> lstLineTag);
        protected delegate void ShowCycleInfoCallBack(CCycleInfo cCycleInfo);

        #endregion

        #region Initialize

        public FrmTeamInfoView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Private Method

        private Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
        }

        private List<CLineInfoTag> SelectSymbolForm(CLineInfoTag cTag, List<CLineInfoTag> lstTag, string sMainText, int iLimit)
        {
            List<CLineInfoTag> lstOutTag = null;
            try
            {
                FrmSymbolSelect frmSymbol = (FrmSymbolSelect)IsFormOpened(typeof(FrmSymbolSelect));
                if (frmSymbol != null)
                    return lstOutTag;

                frmSymbol = new FrmSymbolSelect();
                frmSymbol.MainText = sMainText;
                frmSymbol.LimitSymbolCount = iLimit;


                if (lstTag != null)
                {
                    frmSymbol.SelectedSymbolList = lstTag;
                    frmSymbol.ShowDialog();
                    lstOutTag = frmSymbol.SelectedSymbolList;
                }
                else
                {
                    if (cTag != null)
                        frmSymbol.SelectedSymbolList.Add(cTag);

                    frmSymbol.ShowDialog();
                    lstOutTag = frmSymbol.SelectedSymbolList;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return lstOutTag;
        }

        protected void ShowLineInfo(List<CLineInfoTag> lstLineTag)
        {
            if (lstLineTag == null) return;
            if (this.ucTextLimitCount.InvokeRequired)
            {
                ShowLineInfoCallBack d = new ShowLineInfoCallBack(ShowLineInfo);
                this.Invoke(d, new object[] { lstLineTag });
            }
            else
            {
                try
                {
                    foreach (CLineInfoTag cLineTag in lstLineTag)
                    {
                        if (cLineTag.Value == -1)
                            cLineTag.Value = 0;

                        if (cLineTag.Tag.Key == CMultiProject.LineInfo.LimitSetCount.Tag.Key)
                        {
                            CMultiProject.LineInfo.LimitSetCount = cLineTag;
                            ChangeCountBox(ucTextLimitCount, true); 
                        }

                        else if (cLineTag.Tag.Key == CMultiProject.LineInfo.NowCount.Tag.Key)
                        {
                            CMultiProject.LineInfo.NowCount = cLineTag;
                            ChangeCountBox(ucTextNowCount, true);
                        }

                        else if (cLineTag.Tag.Key == CMultiProject.LineInfo.GoodCount.Tag.Key)
                        {
                            CMultiProject.LineInfo.GoodCount = cLineTag;
                            ChangeCountBox(ucTextOKCount, true);
                        }

                        else if (cLineTag.Tag.Key == CMultiProject.LineInfo.NGCount.Tag.Key)
                        {
                            CMultiProject.LineInfo.NGCount = cLineTag;
                            ChangeCountBox(ucTextNGCount, true);
                        }
                    }

                    ucTextLimitCount.TextData = CMultiProject.LineInfo.LimitSetCount.Value.ToString();
                    ucTextNowCount.TextData = CMultiProject.LineInfo.NowCount.Value.ToString();
                    ucTextOKCount.TextData = CMultiProject.LineInfo.GoodCount.Value.ToString();
                    ucTextNGCount.TextData = CMultiProject.LineInfo.NGCount.Value.ToString();
                    
                    gaugeAGoal.ColorScheme.Color = Color.GreenYellow;
                    arcScaleRangeBarComponent2.Value = GetAchievementRate();
                    labelComponent3.Text = GetAchievementRate().ToString("#.00");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                    ex.Data.Clear();
                }
            }
        }

        protected void ShowCycleInfo(CCycleInfo cGetCycle)
        {
            if (cGetCycle == null) return;
            if (this.ucTextAVGCycleTime.InvokeRequired)
            {
                ShowCycleInfoCallBack d = new ShowCycleInfoCallBack(ShowCycleInfo);
                this.Invoke(d, new object[] { cGetCycle });
            }
            else
            {
                try
                {
                    double dTargetTime = double.Parse(ucTextCycleTime.TextData);

                    if (cGetCycle.CycleType != EMCycleRunType.Complete) return;

                    double dCycleTime = double.Parse(cGetCycle.CycleTime);
                    if (dCycleTime > dTargetTime) return;

                    m_lstCycleTime.Add(dCycleTime);
                    ucTextAVGCycleTime.TextData = dCycleTime.ToString("#.00");
                    ChangeCountBox(ucTextAVGCycleTime, true);

                    ucTextUPHCount.TextData = GetUPH();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                    ex.Data.Clear();
                }
            }
        }

        private void ChangeTextBox(UCTextView ucView, bool bActive)
        {
            if (bActive)
            {
                if (ucView == ucTextNG)
                {
                    ucView.TextBackColor1 = Color.IndianRed;
                    ucView.TextBackColor2 = Color.Red;
                }
                   
                else if (ucView == ucTextTitle)
                {
                    ucView.TextBackColor1 = Color.YellowGreen;
                    ucView.TextBackColor2 = Color.GreenYellow;
                }
                else
                {
                    ucView.TextBackColor1 = Color.LimeGreen;
                    ucView.TextBackColor2 = Color.Lime;
                }
            }
            else
            {
                ucView.TextBackColor1 = Color.DarkGray;
                ucView.TextBackColor2 = Color.Silver;
            }
        }

        private void ChangeCountBox(UCTextView ucView, bool bActive)
        {
            if (bActive)
            {
                ucView.TextBackColor1 = Color.LavenderBlush;
                ucView.TextBackColor2 = Color.Snow;
            }
            else
            {
                ucView.TextBackColor1 = Color.DarkGray;
                ucView.TextBackColor2 = Color.Silver;
            }
        }

        private string GetUPH()
        {
            string sUPH = "0";
            try
            {
                if (m_lstCycleTime.Count != 0)
                {
                    double dCycleMean = CStatics.Mean(m_lstCycleTime);

                    if (dCycleMean == 0)
                        sUPH = "0";
                    else
                        sUPH = Math.Round(3600 / dCycleMean, 2).ToString();

                    ChangeCountBox(ucTextUPHCount, true);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return sUPH;
        }

        private float GetAchievementRate()
        {
            float fAchRate = 0.0f;

            try
            {
                float fLimit = float.Parse(ucTextLimitCount.TextData);
                float fNow = float.Parse(ucTextNowCount.TextData);
                fAchRate = fNow * 100 / fLimit;//(fNow / fLimit) * 100;

                if (float.IsNaN(fAchRate) || float.IsInfinity(fAchRate))
                    fAchRate = 0.0f;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return fAchRate;
        }

        private void SetTargetCycleTime()
        {
            try
            {
                int iTargetTime = 0;

                foreach (CPlcProc cProc in CMultiProject.PlcProcS.Values)
                {
                    int iTempTime = cProc.TargetTactTime;
                    if (iTargetTime < iTempTime)
                        iTargetTime = iTempTime;
                }

                ucTextCycleTime.TextData = (iTargetTime / 1000).ToString();

                if (iTargetTime != 0)
                {
                    ChangeCountBox(ucTextCycleTime, true);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoView", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion

        #region Public Methoed
        public void UpdateProductionInfo()
        {
            SetTargetCycleTime();
            ShowLineInfo(CMultiProject.LineInfo.ReadSymbolList);

            if(CMultiProject.IsRun)
            {
                ChangeTextBox(ucTextLimit, true);
                ChangeTextBox(ucTextNow, true);
                ChangeTextBox(ucTextOK, true);
                ChangeTextBox(ucTextNG, true);
                ChangeTextBox(ucTextCycle, true);
                ChangeTextBox(ucTextAVGCycle, true);
                ChangeTextBox(ucTextUPH, true);
            }
            else
            {
                ChangeTextBox(ucTextLimit, false);
                ChangeTextBox(ucTextNow, false);
                ChangeTextBox(ucTextOK, false);
                ChangeTextBox(ucTextNG, false);
                ChangeTextBox(ucTextCycle, false);
                ChangeTextBox(ucTextAVGCycle, false);
                ChangeTextBox(ucTextUPH, false);
            }
        }

        public void CycleInfoChangedForProductionInfo(CCycleInfo cGetCycle)
        {
            ShowCycleInfo(cGetCycle);
        }

        public void LineInfoValueChanged(List<CLineInfoTag> lstLineTag)
        {
            ShowLineInfo(lstLineTag);
        }

        #endregion

        #region Form Event
        private void FrmTeamInfoView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Size.Width / 2, Screen.PrimaryScreen.Bounds.Size.Height);
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Size.Width / 2, 0);

            ucTextCycle.TextData = "목표\r\nCycle\r\nTime(s)";
            ucTextAVGCycle.TextData = "평균\r\nCycle\r\nTime(s)";

            ucTextLimitCount.UEventDoubleClick += ucTextLimitCount_UEventDoubleClick;
            ucTextNowCount.UEventDoubleClick += ucTextNowCount_UEventDoubleClick;
            ucTextOKCount.UEventDoubleClick += ucTextOKCount_UEventDoubleClick;
            ucTextNGCount.UEventDoubleClick += ucTextNGCount_UEventDoubleClick;

            UpdateProductionInfo();
        }

        private void ucTextLimitCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfo.LimitSetCount, null, "목표 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
            {
                CMultiProject.LineInfo.LimitSetCount = lstTag[0];
                ChangeCountBox(ucTextLimitCount, true);
            }
            else
                ChangeCountBox(ucTextLimitCount, false);
        }

        private void ucTextNowCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfo.NowCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
            { 
                CMultiProject.LineInfo.NowCount = lstTag[0];
                ChangeCountBox(ucTextNowCount, true);
            }
            else
                ChangeCountBox(ucTextNowCount, false);
        }
        private void ucTextOKCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfo.GoodCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
            { 
                CMultiProject.LineInfo.GoodCount = lstTag[0];
                ChangeCountBox(ucTextOKCount, true);
            }
            else
                ChangeCountBox(ucTextOKCount, false);
        }

        private void ucTextNGCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfo.NGCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
            {
                CMultiProject.LineInfo.NGCount = lstTag[0];
                ChangeCountBox(ucTextNGCount, true);
            }
            else
                ChangeCountBox(ucTextNGCount, false);
        }

        private void FrmTeamInfoView_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_lstCycleTime.Clear();

            ucTextLimitCount.UEventDoubleClick -= ucTextLimitCount_UEventDoubleClick;
            ucTextNowCount.UEventDoubleClick -= ucTextNowCount_UEventDoubleClick;
            ucTextOKCount.UEventDoubleClick -= ucTextOKCount_UEventDoubleClick;
            ucTextNGCount.UEventDoubleClick -= ucTextNGCount_UEventDoubleClick;
        }
        #endregion
    }
}