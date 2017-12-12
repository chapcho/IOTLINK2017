using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log.DB;
using UDM.Common;
using UDM.Log;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;


namespace UDMOptimizer
{
    public partial class FrmAnovaAddGroup : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private bool m_bApply = false;
        private string m_sProcess = "";
        private string m_sSubject = ""; // P = Pattern, C = Cycle
        private string m_sPatternItem = "";

        private DataTable m_tbGroup = new DataTable();
        private DateTime m_dtFrom = new DateTime();
        private DateTime m_dtTo = new DateTime();

        private List<CCycleAnalyData> m_lstCycleData = new List<CCycleAnalyData>();

        private CMySqlLogReader m_cReader = null;

        #endregion

        #region Initialize

        public FrmAnovaAddGroup()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }
        #endregion

        #region Properties
        public bool Apply
        {
            get { return m_bApply; }
        }
        public string Process
        {
            get { return m_sProcess; }
            set { m_sProcess = value; }
        }
        public string Subject
        {
            get { return m_sSubject; }
            set { m_sSubject = value; }
        }
        public string PatternItem
        {
            get { return m_sPatternItem; }
            set { m_sPatternItem = value; }
        }
        public DataTable GroupTable
        {
            get { return m_tbGroup; }
            set { m_tbGroup = value; }
        }

        #endregion

        #region Private Method
        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
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
            try
            {
                DateTime dtLast = m_cReader.GetLastTimeLogTime();

                if (dtLast == DateTime.MinValue)
                {
                    dtpkFrom.EditValue = null;
                    dtpkTo.EditValue = null;

                    XtraMessageBox.Show("현재 DB에 로그가 존재하지 않습니다!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dtpkFrom.EditValue = (DateTime)dtLast.AddDays(-2);
                    dtpkTo.EditValue = (DateTime)dtLast;
                }

                if (m_sProcess != "")
                    txtProcess.EditValue = m_sProcess;

                if (m_sSubject != "")
                {
                    txtSubject.Tag = m_sSubject;

                    if (m_sSubject == "P")
                    {
                        txtSubject.EditValue = "Pattern Item";
                        grpcSubject.Text = "Key Symbols";
                        grdKey.Visible = true;
                        grdCycleData.Visible = false;

                        txtPatternItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        txtPatternItem.EditValue = m_sPatternItem;
                        //txtPatternItem.Tag = m_sPatternItem.Replace(" ","").Split(':')[0];
                    }
                    else
                    {
                        txtSubject.EditValue = "Cycle Time";
                        grpcSubject.Text = "Cycles";
                        grdKey.Visible = false;
                        grdCycleData.Visible = true;
                    }
                }

                if (m_tbGroup != null)
                    grdGroup.DataSource = m_tbGroup;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAddGroup", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void SetPatternItemGrid(string sRecipe)
        {
            try
            {
                grdKey.DataSource = null;
                grdKey.RefreshDataSource();

                string sKey = txtPatternItem.EditValue.ToString();

                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(sKey, m_dtFrom, m_dtTo);

                if (cTotalLogS == null || cTotalLogS.Count == 0)
                    return;

                CTimeLogS cRecipeLogS = new CTimeLogS();
                CTimeLogS cLogS = null;

                foreach(CCycleAnalyData cCycleData in m_lstCycleData)
                {
                    string sCycleRecipe = cCycleData.RecipeValue.ToString();

                    if (sCycleRecipe != sRecipe)
                        continue;

                    cLogS = cTotalLogS.GetTimeLogS(sKey, cCycleData.StartTime, cCycleData.EndTime);

                    if (cLogS == null || cLogS.Count == 0)
                        continue;

                    if (cLogS.Count == 1)
                    {
                        CTimeLog cTempLog = cTotalLogS.GetFirstLog(sKey, cLogS.First().Time);

                        if (cTempLog != null)
                            cLogS.Add(cTempLog);
                    }
                    cRecipeLogS.AddRange(cLogS);

                    cLogS.Clear();
                    cLogS = null;
                }

                CTimeNodeS cTimeNodeS = new CTimeNodeS(CMultiProject.TotalTagS[sKey], cRecipeLogS, m_dtFrom, m_dtTo);

                if (cTimeNodeS == null || cTimeNodeS.Count == 0)
                    return;

                //grdKey.DataSource = cTimeNodeS.Where(x => x.Duration < CMultiProject.PlcProcS[m_sProcess].MaxTactTime).ToList();
                grdKey.DataSource = cTimeNodeS;
                grdKey.RefreshDataSource();

                cTotalLogS.Clear();
                cTotalLogS = null;
                cRecipeLogS.Clear();
                cRecipeLogS = null;

                txtCount.Text = cTimeNodeS.Count.ToString("##,###");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAddGroup", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void SetCycleGrid(string sRecipe)
        {
            try
            {
                List<CCycleAnalyData> lstData = m_lstCycleData.Where(x => x.RecipeValue.ToString() == sRecipe).Select(x => x).ToList();

                if (lstData == null || lstData.Count == 0)
                {
                    XtraMessageBox.Show("해당 기간의 \'" + sRecipe + "\' 레시피에 대한 Cycle 정보가 존재하지 않습니다.\r\n기간을 확인해주세요.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                grdCycleData.DataSource = lstData;
                grdCycleData.RefreshDataSource();

                txtCount.Text = lstData.Count.ToString("##,###");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAddGroup", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void InitRecipeList()
        {
            List<string> lstRecipe = new List<string>();

            foreach(CCycleAnalyData cData in m_lstCycleData)
            {
                if (!lstRecipe.Contains(cData.RecipeValue.ToString()))
                    lstRecipe.Add(cData.RecipeValue.ToString());
            }

            foreach (string sRecipe in lstRecipe)
            {
                if (!cboRecipe.Properties.Items.Contains(sRecipe))
                    cboRecipe.Properties.Items.Add(sRecipe);
            }

            cboRecipe.EditValue = lstRecipe.First();
        }

        private void GroupCountApply()
        {

            CTimeLogS cLogS = null;
            CTimeNodeS cNodeS = null;
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;

            string sRecipe = (string)cboRecipe.EditValue;

            for (int i = 0; i < m_tbGroup.Rows.Count; i++)
            {
                dtFrom = DateTime.Parse(m_tbGroup.Rows[i]["From"].ToString());
                dtTo = DateTime.Parse(m_tbGroup.Rows[i]["To"].ToString());

                if (m_sSubject == "P")
                {
                    cLogS = m_cReader.GetTimeLogS(m_sPatternItem, dtFrom, dtTo);

                    if (cLogS != null)
                    {
                        cNodeS = new CTimeNodeS(CMultiProject.TotalTagS[m_sPatternItem], cLogS, dtFrom, dtTo);

                        if (cNodeS != null)
                            m_tbGroup.Rows[i]["Count"] = cNodeS.Count;
                            //m_tbGroup.Rows[i]["Count"] = cNodeS.Where(x => x.Duration < CMultiProject.PlcProcS[m_sProcess].MaxTactTime).Count();
                    }
                }
                else
                {
                    //cInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, m_sProcess, dtFrom, dtTo);
                    //if (cInfoS != null)
                    //    m_tbGroup.Rows[i]["Count"] = cInfoS.Where(x => x.Value.CurrentRecipe == sRecipe).Count();

                    CCycleAnalyDataList cCycleList = CMultiProject.CycleAnalyDataS[m_sProcess];
                    List<CCycleAnalyData> lstData = cCycleList.Where(x => x.StartTime >= dtFrom && x.EndTime <= dtTo).ToList();

                    if (lstData != null)
                        m_tbGroup.Rows[i]["Count"] = lstData.Where(x => x.RecipeValue.ToString() == sRecipe).Count();
                }

                if (cLogS != null)
                    cLogS.Clear();
                cLogS = null;

                if (cNodeS != null)
                    cNodeS.Clear();
                cNodeS = null;

                //if (cInfoS != null)
                //    cInfoS.Clear();
                //cInfoS = null;
            }

        }

        #endregion

        #region Form Event
        private void FrmAnovaAddGroup_Load(object sender, EventArgs e)
        {
            bool bOK = VerifyParameter();

            if (!bOK) return;

            InitComponent();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cboRecipe.EditValue = null;
            cboRecipe.Properties.Items.Clear();

            grdGroup.DataSource = null;
            grdGroup.RefreshDataSource();

            grdKey.DataSource = null;
            grdKey.RefreshDataSource();

            grdCycleData.DataSource = null;
            grdCycleData.RefreshDataSource();
            
            m_tbGroup.Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_tbGroup == null || (m_tbGroup.Columns.Count == 0 && m_tbGroup.Rows.Count == 0))
                {
                    m_tbGroup = new DataTable();

                    m_tbGroup.Columns.Add("GroupName");
                    m_tbGroup.Columns.Add("From", typeof(DateTime));
                    m_tbGroup.Columns.Add("To", typeof(DateTime));
                    m_tbGroup.Columns.Add("Recipe", typeof(string));
                    m_tbGroup.Columns.Add("Count", typeof(int));
                }
                else
                    m_tbGroup = (DataTable)grdGroup.DataSource;

                if (m_tbGroup == null)
                    return;

                DataRow dr = m_tbGroup.NewRow();
                dr["GroupName"] = string.Empty;
                dr["From"] = (DateTime)dtpkFrom.EditValue;
                dr["To"] = (DateTime)dtpkTo.EditValue;
                dr["Recipe"] = (string)cboRecipe.EditValue;
                m_tbGroup.Rows.Add(dr);

                for (int i = 0; i < m_tbGroup.Rows.Count; i++)
                    m_tbGroup.Rows[i]["GroupName"] = "Group" + i.ToString();

                grdGroup.DataSource = m_tbGroup;
                grdGroup.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAddGroup", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                cboRecipe.EditValue = null;
                cboRecipe.Properties.Items.Clear();

                grdGroup.DataSource = null;
                grdGroup.RefreshDataSource();

                grdKey.DataSource = null;
                grdKey.RefreshDataSource();

                grdCycleData.DataSource = null;
                grdCycleData.RefreshDataSource();

                m_dtFrom = (DateTime)dtpkFrom.EditValue;
                m_dtTo = (DateTime)dtpkTo.EditValue;


                if (m_dtFrom > m_dtTo)
                {
                    XtraMessageBox.Show("조회기간을 확인해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CCycleAnalyDataList cCycleData = CMultiProject.CycleAnalyDataS[m_sProcess];
                m_lstCycleData = cCycleData.Where(x => x.StartTime >= m_dtFrom && x.EndTime <= m_dtTo).ToList();

                if (m_lstCycleData == null || m_lstCycleData.Count == 0)
                {
                    XtraMessageBox.Show("해당 기간에 수집된 로그가 존재하지 않습니다.\r\n기간을 다시 설정해주세요!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    InitRecipeList();
                }
                SplashScreenManager.CloseDefaultWaitForm();
                //if (m_sSubject == "P")
                //    SetPatternItemGrid();
                //else
                //    SetCycleGrid();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmAnovaAddGroup", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (grvGroup.FocusedRowHandle > 0)
            {
                grvGroup.DeleteRow(grvGroup.FocusedRowHandle);
            }
            else
            {
                if (grvGroup.DataRowCount > 0)
                    grvGroup.DeleteRow(0);
            }

            m_tbGroup = (DataTable)grdGroup.DataSource;

            for (int i = 0; i < m_tbGroup.Rows.Count; i++)
                m_tbGroup.Rows[i]["GroupName"] = "Group" + i.ToString();

            grdGroup.DataSource = m_tbGroup;
        }

        private void FrmAnovaAddGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grdGroup.DataSource == null) return;

            DialogResult dlgResult = XtraMessageBox.Show("그룹 변경사항을 적용하시겠습니까?", "UDM Tracker Simple",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dlgResult == DialogResult.Yes)
            {
                SplashScreenManager.ShowDefaultWaitForm();
                {
                    m_bApply = true;
                    grvGroup.FocusedRowHandle = 0;
                    grvGroup.FocusedRowHandle = grvGroup.DataRowCount; // Cell Value Change 적용을 위해 강제로 Focus 이동
                    m_tbGroup = (DataTable)grdGroup.DataSource;

                    GroupCountApply();
                }
                SplashScreenManager.CloseDefaultWaitForm();

                //그룹 명 값이 Int 값인지 확인!!!!!!!!!!!
            }
        }

        #endregion

        private void grvCycleData_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnGridRefresh_Click(object sender, EventArgs e)
        {
            if (cboRecipe.EditValue == null)
                return;

            string sRecipe = (string)cboRecipe.EditValue;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                if (m_sSubject == "P")
                    SetPatternItemGrid(sRecipe);
                else
                    SetCycleGrid(sRecipe);
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnCountSetting_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                GroupCountApply();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }
    }
}
