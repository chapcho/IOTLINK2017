using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrackerCommon;
using UDM.Common;
using UDM.Ladder;

namespace UDMPLCLogicAnalyzer
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Member Variables

        private FrmLadderView m_frmLadderView = null;
        private int m_iShowDoubleCoilFirst = 0;
        #endregion


        #region Initialize

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion


        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            m_frmLadderView = new FrmLadderView();
            m_frmLadderView.TopMost = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_frmLadderView != null)
            {
                m_frmLadderView.Dispose();
                m_frmLadderView = null;
            }
        }

        #region File Button

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("설정된 정보를 모두 지우겠습니까?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                //Clear
                CProject.Clear();

                MessageBox.Show("해당 정보가 모두 지워졌습니다.\r\n다시 설정하세요");
            }
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.umpp|*.umpp";
            dlgOpenFile.ShowDialog();

            string sPath = dlgOpenFile.FileName;
            string sMessage = "Path가 존재하지 않습니다.";
            bool bOK = false;
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                CProject.Clear();
                if (sPath != "")
                    bOK = CProject.Open(sPath, out sMessage);

                if (bOK == false)
                    Console.WriteLine(sMessage);
             
                grdTotalTagS.DataSource = CProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
                grvTotalTagS.ExpandAllGroups();

                btnLogicAnalysis_ItemClick(null, null);
                btnCompareDouble_Click(null, null);
            }

            SplashScreenManager.CloseForm(false);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.umpp|*.umpp";
            dlgSaveFile.ShowDialog();

            string sPath = dlgSaveFile.FileName;
            string sMessage = "Path가 존재하지 않습니다.";
            bool bOK = false;
            if (sPath != "")
                bOK = CProject.Save(sPath, out sMessage);

            if (bOK == false)
                Console.WriteLine(sMessage);
        }

        private void btnAddPLC_Click(object sender, EventArgs e)
        {
            if (CProject.BaseData.ProjectID == "" || CProject.BaseData.ProjectID == "00000000")
            {
                FrmInputDialog frmInputText = new FrmInputDialog("Create Project ID", "Project ID를 입력하세요\r\n최대한 단순하게 입력하세요");
                frmInputText.StartPosition = FormStartPosition.CenterParent;
                frmInputText.ShowDialog();

                if (frmInputText.InputText == "") return;
                CProject.BaseData.ProjectID = frmInputText.InputText;
            }

            FrmPlcSetWizard frmWizard = new FrmPlcSetWizard();
            frmWizard.ShowDialog();

            if (CProject.PLCLogicDataS.Count > 0 && frmWizard.ChangeFlag)
            {
                CProject.TotalTagS.Clear();
                CProject.BaseData.PLCIDList.Clear();
                foreach (var who in CProject.PLCLogicDataS)
                {
                    CProject.TotalTagS.AddRange(who.Value.TagS);
                    CProject.BaseData.PLCIDList.Add(who.Key);
                }

                SetUsedCoil();

                grdTotalTagS.DataSource = CProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
                grvTotalTagS.ExpandAllGroups();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnLadderView_Click(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvTotalTagS.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvTotalTagS.GetRow(iRowHandle);

                if (obj.GetType() != typeof(CTag))
                    return;

                CTag cTag = (CTag)obj;

                if (cTag == null) return;
                CPlcLogicData cLogic = CProject.PLCLogicDataS[cTag.Creator];
                CStep cStep = GetMasterStep(cTag, cLogic);

                if (cStep == null)
                    return;

                if (!m_frmLadderView.IsLoad)
                {
                    //m_frmLadderView.StartPosition = FormStartPosition.
                    m_frmLadderView.Show();
                    m_frmLadderView.IsLoad = true;
                }

                m_frmLadderView.SetLadderStep(cLogic, cStep, 0, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnLadderView_Click Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion


        #region Private Method

        private void SetUsedCoil()
        {
            if (CProject.TotalTagS.Count == 0)
                return;

            foreach (CTag cTag in CProject.TotalTagS.Values)
            {
                if (cTag.StepRoleS != null)
                {
                    if (cTag.StepRoleS.Count != 0)
                    {
                        cTag.UseOnlyInLogic = true;
                        foreach (CTagStepRole cRole in cTag.StepRoleS)
                        {
                            if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                            {
                                cTag.IsHMIMapping = true;
                                break;
                            }
                        }
                    }
                    else //Not Used
                        cTag.UseOnlyInLogic = false;
                }
            }
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell) && cTag.Address.Contains(".DN"))
            {
                string sKey = cTag.Key.Replace(".DN", string.Empty);

                if (CProject.TotalTagS.ContainsKey(sKey))
                    cTag = CProject.TotalTagS[sKey];
            }

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(cLogic.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (cLogic.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = cLogic.StepS[who.StepKey];

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
            {

                MessageBox.Show("해당 접점은 출력 접점으로 사용되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return cStep;
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

        #endregion


        #region User Event

        #endregion

        private bool CheckCompareData()
        {
            bool bCheck = true;

            foreach (var who in CProject.PLCLogicDataS)
            {
                if (CProject.LoogicSCompare1.ContainsKey(who.Key) == false)
                {
                    bCheck = false;
                    break;
                }
            }

            return bCheck;
        }

        private void sptLogicCompare_SplitterMoved(object sender, EventArgs e)
        {
            sptTagStepRole.SplitterPosition = (int)(sptLogicCompare.SplitterPosition / 2);
        }

        private void grvTagCompare_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ShowGridView(grvTagCompare, e.RowHandle);
        }

        private void grvAddLogicCheck_RowClick(object sender, RowClickEventArgs e)
        {
            ShowGridView(grvAfterChangeLogic, e.RowHandle);
        }

        private void grvAfterAddLogic_RowClick(object sender, RowClickEventArgs e)
        {
            ShowGridView(grvAfterAddLogic, e.RowHandle);
        }

        private void grvBaseTagStep_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //GridView View = sender as GridView;
            //string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Type"]);
            //if (category == "Both" || category == "Coil")
            //{
            //    e.Appearance.BackColor = Color.Lime;
            //    e.Appearance.BackColor = Color.Green;
            //    e.Appearance.ForeColor = Color.Black;
            //}
            //else
            //{
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.BackColor = Color.White;
            //    e.Appearance.ForeColor = Color.Black;
            //}
        }

        private void btnAnalyzer_Click(object sender, EventArgs e)
        {
            //일단 이중코일 부터 정리
            int iFindCount = 1;
            foreach (var who in CProject.PLCLogicDataS)
            {
                if (CProject.AnalyzeDataS.ContainsKey(who.Key) == false)
                    CProject.AnalyzeDataS.Add(who.Key, new CAnalyzeData());
                else
                    CProject.AnalyzeDataS[who.Key].FirstDoubleCoilDataS.Clear();

                CAnalyzeData cAnalyzeData = CProject.AnalyzeDataS[who.Key];

                CPlcLogicData cLogicData = who.Value;
                foreach (CTag cTag in cLogicData.TagS.Values)
                {
                    if (cTag.StepRoleS != null && cTag.StepRoleS.Count != 0)
                    {
                        List<CTagStepRole> lstCoilStep = cTag.StepRoleS.Where(b => b.RoleType == EMStepRoleType.Coil || b.RoleType == EMStepRoleType.Both).ToList();
                        if (lstCoilStep.Count > 1)
                        {
                            List<CStep> lstStep = new List<CStep>();
                            foreach (CTagStepRole cRole in lstCoilStep)
                                lstStep.Add(cLogicData.StepS[cRole.StepKey]);

                            //CoilS에 해당 Address가 존재하는지 확인
                            int iSameCoilCnt = 0;
                            List<CStep> lstFindStep = new List<CStep>();
                            for (int i = 0; i < lstStep.Count; i++)
                            {
                                List<CCoil> lstCoil = lstStep[i].CoilS.ToList();
                                foreach (CCoil coil in lstCoil)
                                {
                                    //if (coil.Command == "SET" || coil.Command == "RST") continue;
                                    //if (coil.Command.Contains(".DB")) continue;
                                    if (coil.Command != "OUT") continue;
                                    foreach (CContent content in coil.ContentS)
                                    {
                                        if (content.Tag == null) continue;
                                        if (content.Tag.DataType != EMDataType.Bool) continue;
                                        if (content.Tag.Address.Contains("[AR")) continue;
                                        if (content.Tag.Address == cTag.Address)
                                        {
                                            lstFindStep.Add(lstStep[i]);
                                            iSameCoilCnt++;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (iSameCoilCnt > 1)
                            {
                                List<CDoubleCoilData> lstDoubleCoil = new List<CDoubleCoilData>();
                                for (int i = 0; i < lstFindStep.Count; i++)
                                {
                                    CDoubleCoilData cDoubleCoilData = new CDoubleCoilData();
                                    cDoubleCoilData.Number = iFindCount;
                                    cDoubleCoilData.Program = lstFindStep[i].Program;
                                    cDoubleCoilData.StepNumber = lstFindStep[i].Key;
                                    cDoubleCoilData.TagKey = cTag.Key;
                                    cDoubleCoilData.Step = lstFindStep[i];
                                    cDoubleCoilData.Tag = cTag;
                                    lstDoubleCoil.Add(cDoubleCoilData);
                                }
                                cAnalyzeData.FirstDoubleCoilDataS.Add(cTag.Key, lstDoubleCoil);
                                iFindCount++;
                            }
                        }
                    }
                }
            }

            //찾기 완료
            if (iFindCount > 0)
            {
                CProject.AnalyzeDataS.UpdateTotalDoubleCoilData();

                List<CDoubleCoilData> lstData = new List<CDoubleCoilData>();
                foreach(var who in CProject.AnalyzeDataS.TotalFirstDoubleCoilS)
                    lstData.AddRange(who.Value);
                grdData.DataSource = lstData;
                grdData.RefreshDataSource();
                grvData.ExpandAllGroups();
                m_iShowDoubleCoilFirst = 1;
            }
        }

        private void btnCompareDouble_Click(object sender, EventArgs e)
        {
            //일단 이중코일 부터 정리
            int iFindCount = 1;
            foreach (var who in CProject.LoogicSCompare1)
            {
                if (CProject.AnalyzeDataS.ContainsKey(who.Key) == false)
                    CProject.AnalyzeDataS.Add(who.Key, new CAnalyzeData());
                else
                    CProject.AnalyzeDataS[who.Key].SecondDoubleCoilDataS.Clear();
                CAnalyzeData cAnalyzeData = CProject.AnalyzeDataS[who.Key];

                CPlcLogicData cLogicData = who.Value;
                foreach (CTag cTag in cLogicData.TagS.Values)
                {
                    if (cTag.StepRoleS != null && cTag.StepRoleS.Count != 0)
                    {
                        List<CTagStepRole> lstCoilStep = cTag.StepRoleS.Where(b => b.RoleType == EMStepRoleType.Coil || b.RoleType == EMStepRoleType.Both).ToList();
                        if (lstCoilStep.Count > 1)
                        {
                            List<CStep> lstStep = new List<CStep>();
                            foreach (CTagStepRole cRole in lstCoilStep)
                                lstStep.Add(cLogicData.StepS[cRole.StepKey]);

                            //CoilS에 해당 Address가 존재하는지 확인
                            int iSameCoilCnt = 0;
                            List<CStep> lstFindStep = new List<CStep>();
                            for (int i = 0; i < lstStep.Count; i++)
                            {
                                List<CCoil> lstCoil = lstStep[i].CoilS.ToList();
                                foreach (CCoil coil in lstCoil)
                                {
                                    //if (coil.Command == "SET" || coil.Command == "RST") continue;
                                    //if (coil.Command.Contains(".DB")) continue;
                                    if (coil.Command != "OUT") continue;
                                    foreach (CContent content in coil.ContentS)
                                    {
                                        if (content.Tag == null) continue;
                                        if (content.Tag.DataType != EMDataType.Bool) continue;
                                        if (content.Tag.Address.Contains("[AR")) continue;
                                        if (content.Tag.Address == cTag.Address)
                                        {
                                            lstFindStep.Add(lstStep[i]);
                                            iSameCoilCnt++;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (iSameCoilCnt > 1)
                            {
                                List<CDoubleCoilData> lstDoubleCoil = new List<CDoubleCoilData>();
                                for (int i = 0; i < lstFindStep.Count; i++)
                                {
                                    CDoubleCoilData cDoubleCoilData = new CDoubleCoilData();
                                    cDoubleCoilData.Number = iFindCount;
                                    cDoubleCoilData.Program = lstFindStep[i].Program;
                                    cDoubleCoilData.StepNumber = lstFindStep[i].Key;
                                    cDoubleCoilData.TagKey = cTag.Key;
                                    cDoubleCoilData.Step = lstFindStep[i];
                                    cDoubleCoilData.Tag = cTag;
                                    lstDoubleCoil.Add(cDoubleCoilData);
                                }
                                cAnalyzeData.SecondDoubleCoilDataS.Add(cTag.Key, lstDoubleCoil);
                                iFindCount++;
                            }
                        }
                    }
                }
            }

            //찾기 완료
            if (iFindCount > 0)
            {
                CProject.AnalyzeDataS.UpdateTotalDoubleCoilData();

                List<CDoubleCoilData> lstData = new List<CDoubleCoilData>();
                foreach (var who in CProject.AnalyzeDataS.TotalSecondDoubleCoilS)
                    lstData.AddRange(who.Value);
                grdData.DataSource = lstData;
                grdData.RefreshDataSource();
                grvData.ExpandAllGroups();
                m_iShowDoubleCoilFirst = 2;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int iRowHandle = grvData.FocusedRowHandle;
            if (iRowHandle < 0)
                return;

            object obj = grvData.GetRow(iRowHandle);

            if (obj.GetType() != typeof(CDoubleCoilData))
                return;

            CDoubleCoilData cData = (CDoubleCoilData)obj;
            if (cData == null) return;

            string sKey = cData.TagKey;
            CDoubleCoilDataS cDoubleCoilS = null;
            if (m_iShowDoubleCoilFirst == 1)
                cDoubleCoilS = CProject.AnalyzeDataS.TotalFirstDoubleCoilS;
            else if (m_iShowDoubleCoilFirst == 2)
                cDoubleCoilS = CProject.AnalyzeDataS.TotalSecondDoubleCoilS;
            else
                return;

            if (cDoubleCoilS.ContainsKey(sKey) == false)
                return;
            List<CStep> lstStep = new List<CStep>();
            foreach (CDoubleCoilData coil in cDoubleCoilS[sKey])
            {
                lstStep.Add(coil.Step);
            }

            ShowDoubleCoilLadderView(sKey, lstStep);
        }


        private void ShowDoubleCoilLadderView(string sTagKey, List<CStep> lstStep)
        {
            if (!m_frmLadderView.IsLoad)
            {
                m_frmLadderView.Show();
                m_frmLadderView.IsLoad = true;
            }
            CTag cTag = CProject.TotalTagS[sTagKey];
            for (int i = 0; i < lstStep.Count; i++)
                m_frmLadderView.SetLadderStep(CProject.PLCLogicDataS[cTag.Creator], lstStep[i], 0, true);
        }

        private void btnLogicAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckCompareData() == false)
            {
                //폼을 띄워 1:1 매칭
                FrmCompareLogicImport frmCompare = new FrmCompareLogicImport();
                frmCompare.ShowDialog();
            }
            //완료 되면Tag 비교 시작
            
            List<CCompareTag> lstTotal = new List<CCompareTag>();
            List<CCompareTag> lstAfterChangeLogic = new List<CCompareTag>();
            List<CCompareTag> lstAfterAddLogic = new List<CCompareTag>();
            txtAnalysisResult.Clear();
            foreach (var who in CProject.PLCLogicDataS)
            {
                txtAnalysisResult.AppendText("==================================================================================\r\n");
                CTagS cBaseTagS = who.Value.TagS;
                if (CProject.AnalyzeDataS.ContainsKey(who.Key) == false)
                    CProject.AnalyzeDataS.Add(who.Key, new CAnalyzeData());
                else
                {
                    CProject.AnalyzeDataS[who.Key].CompareTagList.Clear();
                    CProject.AnalyzeDataS[who.Key].LogicAnalysisResultList.Clear();
                }
                if (CProject.LoogicSCompare1.ContainsKey(who.Key))
                {
                    List<CCompareTag> lstTotalCompareTag = new List<CCompareTag>();
                    CTagS cCompareTagS = CProject.LoogicSCompare1[who.Key].TagS;
                    foreach (CTag cTag in cBaseTagS.Values)
                    {
                        CCompareTag cComTag = null;
                        if (cCompareTagS.ContainsKey(cTag.Key))
                        {
                            cComTag = new CCompareTag(cTag, cCompareTagS[cTag.Key]);
                            if (cComTag.IsCoil)
                                cComTag.SetMatchPersent(who.Value, CProject.LoogicSCompare1[who.Key]);
                        }
                        else
                        {
                            cComTag = new CCompareTag(cTag, true);
                            //lstSetBeforeTag.Add(cComTag);
                        }
                        lstTotalCompareTag.Add(cComTag);
                    }

                    foreach (CTag cTag in cCompareTagS.Values)
                    {

                        if (cBaseTagS.ContainsKey(cTag.Key) == false && lstTotalCompareTag.FindAll(b => b.Key == cTag.Key).Count() == 0)
                        {
                            CCompareTag cComTag = new CCompareTag(cTag, false);
                            lstTotalCompareTag.Add(cComTag);
                            if (cComTag.IsCoil)
                                lstAfterAddLogic.Add(cComTag);
                        }
                    }

                    lstTotal.AddRange(lstTotalCompareTag);
                    CProject.AnalyzeDataS[who.Key].CompareTagList = lstTotalCompareTag;
                    int iCount = 0;
                    double nSumData = 0.0;
                    List<CCompareTag> lstLogicChange = new List<CCompareTag>();
                    foreach (CCompareTag tag in lstTotalCompareTag)
                    {
                        if (tag.MatchPersent.Count > 0)
                        {
                            iCount += tag.MatchPersent.Count();
                            for (int i = 0; i < tag.MatchPersent.Count; i++)
                            {
                                nSumData += tag.MatchPersent[i];
                                if (lstLogicChange.Contains(tag) == false)
                                {
                                    if (tag.MatchPersent[i] != 0 && tag.MatchPersent[i] < 100)
                                    {
                                        lstLogicChange.Add(tag);
                                    }
                                }
                            }
                        }
                    }
                    double nResult = nSumData / iCount;
                    string sResult = string.Format("PLC Name : {0}\r\n- Coil 수 : {1}\r\n- 전체 결과 : {2:.00} %\r\n", who.Key, iCount, nResult);
                    txtAnalysisResult.AppendText(sResult);
                    CProject.AnalyzeDataS[who.Key].LogicAnalysisResultList.Add(sResult);
                    sResult = string.Format("시운전 후 추가된 로직\r\n- Count : {0}\r\n", lstAfterAddLogic.Count);
                    txtAnalysisResult.AppendText(sResult);
                    CProject.AnalyzeDataS[who.Key].LogicAnalysisResultList.Add(sResult);

                    nResult = (100.0 / iCount) * lstLogicChange.Count;

                    sResult = string.Format("시운전 후 변경된 로직\r\n- Count : {0}\r\n- 변경률 : {1:.00} %\r\n", lstLogicChange.Count, nResult);
                    txtAnalysisResult.AppendText(sResult);
                    CProject.AnalyzeDataS[who.Key].LogicAnalysisResultList.Add(sResult);
                    lstAfterChangeLogic.AddRange(lstLogicChange);
                }
            }
            grdTagCompare.DataSource = lstTotal;
            grdTagCompare.RefreshDataSource();
            grdAfterChangeLogic.DataSource = lstAfterChangeLogic;
            grdAfterChangeLogic.RefreshDataSource();
            grdAfterAddLogic.DataSource = lstAfterAddLogic;
            grdAfterAddLogic.RefreshDataSource();

            grvTagCompare.ExpandAllGroups();
            grvAfterAddLogic.ExpandAllGroups();
            grvAfterChangeLogic.ExpandAllGroups();
        }

        private void ShowGridView(GridView gridObj, int iRowHandle)
        {
            if (iRowHandle < 0) return;
            object obj = gridObj.GetRow(iRowHandle);
            if (obj.GetType() != typeof(CCompareTag)) return;
            CCompareTag cTag = (CCompareTag)obj;

            grdBaseTagStep.DataSource = null;
            grdCompareTagStep.DataSource = null;

            ucLadderPanelBase.ClearLadder();
            ucLadderPanelCompare.ClearLadder();

            if (cTag.IsBaseTagIn)
            {
                grdBaseTagStep.DataSource = cTag.BaseTag.StepRoleS.ToList();
                if (cTag.BaseCoilStepKeyList.Count > 0)
                {
                    for (int i = 0; i < cTag.BaseCoilStepKeyList.Count; i++)
                    {
                        CPlcLogicData cLogic = CProject.PLCLogicDataS[cTag.BaseTag.Creator];
                        CStep cStep = cLogic.StepS[cTag.BaseCoilStepKeyList[i]];
                        ucLadderPanelBase.SetLadderStep(cLogic, cStep, 0, true);
                    }
                }
            }
            if (cTag.IsCompareTagIn)
            {
                grdCompareTagStep.DataSource = cTag.CompareTag.StepRoleS.ToList();
                if (cTag.CompareCoilStepKeyList.Count > 0)
                {
                    for (int i = 0; i < cTag.CompareCoilStepKeyList.Count; i++)
                    {
                        CPlcLogicData cLogic = CProject.LoogicSCompare1[cTag.CompareTag.Creator];
                        CStep cStep = cLogic.StepS[cTag.CompareCoilStepKeyList[i]];
                        ucLadderPanelCompare.SetLadderStep(cLogic, cStep, 0, true);
                    }
                }
            }

            grdBaseTagStep.RefreshDataSource();
            grdCompareTagStep.RefreshDataSource();

            grvBaseTagStep.ExpandAllGroups();
            grvCompareTagStep.ExpandAllGroups();
        }

        private void grvTagCompare_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void grvAddLogicCheck_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void grvTotalTagS_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void grvAfterAddLogic_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void tabCompare_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabCompare.SelectedTabPage == tpAddLogic)
            {
                sptLadderView.SplitterPosition = 20;
            }
            else
            {
                sptLadderView.SplitterPosition = (int)(sptLadderView.Size.Width / 2);
            }
        }

    }
}
