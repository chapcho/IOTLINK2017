using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using TrackerCommon;
using UDM.Log;
using UDM.General.Statistics;
using DevExpress.Utils.Menu;
using System.Reflection;
using System.IO;

namespace UDMTrackerSimple
{
    public partial class FrmProductionStateInfo : XtraForm
    {
        #region Member Variables

        private string m_sPlcProcName = "";

        protected delegate void ShowLineInfoCallBack();
        protected delegate void ShowCycleInfoCallBack(CCycleInfo cCycleInfo);

        #endregion

        #region Initialize

        public FrmProductionStateInfo()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string PlcProcName
        {
            get { return m_sPlcProcName; }
            set { m_sPlcProcName = value; }
        }

        #endregion

        #region Private Method

        protected void ShowLineInfo()
        {
            if (this.ucTextLimitCount.InvokeRequired)
            {
                ShowLineInfoCallBack d = new ShowLineInfoCallBack(ShowLineInfo);
                this.Invoke(d, new object[] {});
            }
            else
            {
                try
                {
                    if (CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount.Value == -1)
                        ucTextLimitCount.TextData = "0";
                    else
                        ucTextLimitCount.TextData = CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount.Value.ToString();


                    if (CMultiProject.LineInfoS[m_sPlcProcName].NowCount.Value == -1)
                        ucTextNowCount.TextData = "0";
                    else
                        ucTextNowCount.TextData = CMultiProject.LineInfoS[m_sPlcProcName].NowCount.Value.ToString();


                    if (CMultiProject.LineInfoS[m_sPlcProcName].GoodCount.Value == -1)
                        ucTextOKCount.TextData = "0";
                    else
                        ucTextOKCount.TextData = CMultiProject.LineInfoS[m_sPlcProcName].GoodCount.Value.ToString();


                    if (CMultiProject.LineInfoS[m_sPlcProcName].NGCount.Value == -1)
                        ucTextNGCount.TextData = "0";
                    else
                        ucTextNGCount.TextData = CMultiProject.LineInfoS[m_sPlcProcName].NGCount.Value.ToString();

                    GetAchievementRate();
                    GetGoodRate();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                    ex.Data.Clear();
                }
            }
        }

        protected void ShowCycleInfo(CCycleInfo cGetCycle)
        {
            if (this.ucTextAVGCTTime.InvokeRequired)
            {
                ShowCycleInfoCallBack d = new ShowCycleInfoCallBack(ShowCycleInfo);
                this.Invoke(d, new object[] { cGetCycle });
            }
            else
            {
                try
                {
                    int iTargetTime = CMultiProject.PlcProcS[m_sPlcProcName].TargetTactTime;
                    ucTextTargetCTTime.TextData = (iTargetTime / 1000).ToString();

                    if (cGetCycle != null)
                    {
                        if (cGetCycle.CycleType == EMCycleRunType.Complete)
                        {
                            double dCycleTime = double.Parse(cGetCycle.CycleTime);
                            double dTactTime = double.Parse(cGetCycle.TactTime);
                            double dIdleTime = double.Parse(cGetCycle.IdleTime);
                            double dMaxTactTime = (double)(CMultiProject.PlcProcS[m_sPlcProcName].MaxTactTime / 1000);

                            if (dCycleTime <= dMaxTactTime)
                            {
                                CMultiProject.LineInfoS[m_sPlcProcName].CycleTimeList.Add(dCycleTime);
                                CMultiProject.LineInfoS[m_sPlcProcName].TactTimeList.Add(dTactTime);
                                CMultiProject.LineInfoS[m_sPlcProcName].IdleTimeList.Add(dIdleTime);
                            }
                        }
                    }

                    if (CMultiProject.LineInfoS[m_sPlcProcName].CycleTimeList.Count > 0)
                        ucTextAVGCTTime.TextData = CStatics.Mean(CMultiProject.LineInfoS[m_sPlcProcName].CycleTimeList).ToString("#.00");
                    
                    ucTextCTTime.TextData = CMultiProject.LineInfoS[m_sPlcProcName].TotalCycleTime.ToString();
                    ucTextTactTime.TextData = CMultiProject.LineInfoS[m_sPlcProcName].TotalTactTime.ToString();
                    ucTextIdleTime.TextData = CMultiProject.LineInfoS[m_sPlcProcName].TotalIdleTime.ToString();

                    GetEfficiencyRate();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                    ex.Data.Clear();
                }
            }
        }

        private void GetAchievementRate()
        {
            float fRate = 0.0f;

            try 
            {
                float fLimit = float.Parse(ucTextLimitCount.TextData);
                float fNow = float.Parse(ucTextNowCount.TextData);
                fRate = fNow * 100 / fLimit;

                if (float.IsNaN(fRate) || float.IsInfinity(fRate))
                    fRate = 0.0f;

                arcScaleRangeBarAchieve.Value = fRate;
                lblGaugeAchieve.Text = Math.Round(fRate, 2).ToString() + " %";

                if (CMultiProject.IsRun && fLimit == fNow)
                    SetLineStatePanel("SS");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void GetGoodRate()
        {
            float fRate = 0.0f;

            try
            {
                float fOKCnt = float.Parse(ucTextOKCount.TextData);
                float fNGCnt = float.Parse(ucTextNGCount.TextData);
                fRate = fOKCnt * 100 / (fOKCnt + fNGCnt);

                if (float.IsNaN(fRate) || float.IsInfinity(fRate))
                    fRate = 0.0f;

                arcScaleRangeBarGood.Value = fRate;
                lblGaugeGood.Text = Math.Round(fRate, 2).ToString() + " %";

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void GetEfficiencyRate()
        {
            float fRate = 0.0f;

            try
            {
                float fTargetCTTime = float.Parse(ucTextTargetCTTime.TextData); //second
                float fAVGCTTime = float.Parse(ucTextAVGCTTime.TextData);  //second
                fRate = fTargetCTTime * 100 / fAVGCTTime;

                if (float.IsNaN(fRate) || float.IsInfinity(fRate))
                    fRate = 0.0f;

                arcScaleRangeBarEfficiency.Value = fRate;
                lblGaugeEfficiency.Text = Math.Round(fRate,2).ToString() + " %";
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                XtraMessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(m_sPlcProcName == "")
            {
                XtraMessageBox.Show("Process Name이 존재하지 않습니다.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

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
        
        private void SetLineState(EMCycleRunType emType)
        {
            CCycleInfo cCycleInfo = CMultiProject.TotalCycleInfoS[m_sPlcProcName].CurrentCycleInfo;

            try
            {
                if (CMultiProject.IsRun)
                {
                    if(emType == EMCycleRunType.Start)
                        SetLineStatePanel("RUN");

                    else if (emType == EMCycleRunType.End)
                        SetLineStatePanel("IDLE");

                    //if (emType != EMCycleRunType.Start && emType != EMCycleRunType.End && CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount != null && CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount.Value == 0)
                    //    SetLineStatePanel("SS");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void SetLineStatePanel(string sState)
        {
            if (sState == "RUN")
            {
                ucTextOper.TextBackColor1 = Color.GreenYellow;
                ucTextOper.TextBackColor2 = Color.YellowGreen;
                ucTextOper.TextColor = Color.WhiteSmoke;

                ucTextIdle.TextBackColor1 = Color.Black;
                ucTextIdle.TextBackColor2 = Color.Black;
                ucTextIdle.TextColor = Color.WhiteSmoke;

                ucTextStop.TextBackColor1 = Color.Black;
                ucTextStop.TextBackColor2 = Color.Black;
                ucTextStop.TextColor = Color.WhiteSmoke;
            }
            else if(sState == "IDLE")
            {
                ucTextOper.TextBackColor1 = Color.Black;
                ucTextOper.TextBackColor2 = Color.Black;
                ucTextOper.TextColor = Color.WhiteSmoke;

                ucTextIdle.TextBackColor1 = Color.LemonChiffon;
                ucTextIdle.TextBackColor2 = Color.Yellow;
                ucTextIdle.TextColor = Color.Silver;

                ucTextStop.TextBackColor1 = Color.Black;
                ucTextStop.TextBackColor2 = Color.Black;
                ucTextStop.TextColor = Color.WhiteSmoke;
            }

            else if( sState == "SS") //Scheduled Shutdown
            {
                ucTextOper.TextBackColor1 = Color.Black;
                ucTextOper.TextBackColor2 = Color.Black;
                ucTextOper.TextColor = Color.WhiteSmoke;

                ucTextIdle.TextBackColor1 = Color.Black;
                ucTextIdle.TextBackColor2 = Color.Black;
                ucTextIdle.TextColor = Color.WhiteSmoke;

                ucTextStop.TextBackColor1 = Color.Coral;
                ucTextStop.TextBackColor2 = Color.IndianRed;
                ucTextStop.TextColor = Color.WhiteSmoke;
            }

            else if (sState == "STOP")
            {
                ucTextOper.TextBackColor1 = Color.Black;
                ucTextOper.TextBackColor2 = Color.Black;
                ucTextOper.TextColor = Color.WhiteSmoke;

                ucTextIdle.TextBackColor1 = Color.Black;
                ucTextIdle.TextBackColor2 = Color.Black;
                ucTextIdle.TextColor = Color.WhiteSmoke;

                ucTextStop.TextBackColor1 = Color.Black;
                ucTextStop.TextBackColor2 = Color.Black;
                ucTextStop.TextColor = Color.WhiteSmoke;
            }
        }

        private void ReadProcessImage()
        {
            byte[] byteImage = null;
            MemoryStream ms = null;

            try
            {
                byteImage = CMultiProject.LineInfoS[m_sPlcProcName].ImageArry;

                if (byteImage != null)
                {
                    ms = new MemoryStream(byteImage, 0, byteImage.Length);
                    ms.Write(byteImage, 0, byteImage.Length);
                    Image imgMain = Image.FromStream(ms, true);

                    picProcess.EditValue = imgMain;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            finally
            {
                if (ms != null)
                {
                    ms.Close();
                    ms.Dispose();
                    ms = null;
                }
            }
        }
        #endregion

        #region Public Methoed

        public void UpdateProductionStateInfo()
        {
            ShowLineInfo();
            ShowCycleInfo(null);

            if (!CMultiProject.IsRun)
                SetLineStatePanel("STOP");
        }

        public void CycleInfoChangedForProductionInfo(CCycleInfo cGetCycle)
        {
            ShowCycleInfo(cGetCycle);
        }

        public void ChangedLineState(EMCycleRunType emType)
        {
            SetLineState(emType);
        }

        #endregion

        #region Form Event

        private void FrmProductionStateInfo_Load(object sender, EventArgs e)
        {
            if (VerifyParameter() == false)
            {
                this.Close();
                return;
            }

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Size.Width / 2, 0);

            txtOperName.TextData = m_sPlcProcName;
            ReadProcessImage();

            ShowLineInfo();
            ShowCycleInfo(null);

            if(CMultiProject.IsRun)
                SetLineStatePanel("RUN");

            ucTextLimitCount.UEventDoubleClick += ucTextLimitCount_UEventDoubleClick;
            ucTextNowCount.UEventDoubleClick += ucTextNowCount_UEventDoubleClick;
            ucTextOKCount.UEventDoubleClick += ucTextOKCount_UEventDoubleClick;
            ucTextNGCount.UEventDoubleClick += ucTextNGCount_UEventDoubleClick;
        }

        private void ucTextLimitCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount, null, "목표 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
                CMultiProject.LineInfoS[m_sPlcProcName].LimitSetCount = lstTag[0];
        }

        private void ucTextNowCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfoS[m_sPlcProcName].NowCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
                CMultiProject.LineInfoS[m_sPlcProcName].NowCount = lstTag[0];
        }
        private void ucTextOKCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfoS[m_sPlcProcName].GoodCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
                CMultiProject.LineInfoS[m_sPlcProcName].GoodCount = lstTag[0];
        }

        private void ucTextNGCount_UEventDoubleClick()
        {
            List<CLineInfoTag> lstTag = SelectSymbolForm(CMultiProject.LineInfoS[m_sPlcProcName].NGCount, null, "생산 수량 Symbol 설정", 1);

            if (lstTag != null && lstTag.Count == 1)
                CMultiProject.LineInfoS[m_sPlcProcName].NGCount = lstTag[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductionStateInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucTextLimitCount.UEventDoubleClick -= ucTextLimitCount_UEventDoubleClick;
            ucTextNowCount.UEventDoubleClick -= ucTextNowCount_UEventDoubleClick;
            ucTextOKCount.UEventDoubleClick -= ucTextOKCount_UEventDoubleClick;
            ucTextNGCount.UEventDoubleClick -= ucTextNGCount_UEventDoubleClick;
        }

        private void picProcess_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (CMultiProject.IsRun)
                    {
                        picProcess.Properties.ShowMenu = false;
                        return;
                    }

                    picProcess.Properties.ShowMenu = true;

                    PictureEdit picEdit = sender as PictureEdit;
                    DXPopupMenu menu = new DXPopupMenu();

                    PropertyInfo info = typeof(PictureEdit).GetProperty("Menu", BindingFlags.NonPublic | BindingFlags.Instance);
                    menu = info.GetValue(picEdit, null) as DXPopupMenu;
                    foreach (DXMenuItem item in menu.Items)
                    {
                        if (item.Caption != "Load")
                            item.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void picProcess_EditValueChanged(object sender, EventArgs e)
        {
            byte[] byteImage = null;
            MemoryStream ms = null;

            try
            {
                if (picProcess.EditValue != null && picProcess.EditValue is Image)
                {
                    Image img = picProcess.EditValue as Image;

                    ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteImage = ms.ToArray();

                    CMultiProject.LineInfoS[m_sPlcProcName].ImageArry = byteImage;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmProductionStateInfo", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            finally
            {
                ms.Close();
                ms.Dispose();
                ms = null;
            }
        }
        #endregion
    }
}
