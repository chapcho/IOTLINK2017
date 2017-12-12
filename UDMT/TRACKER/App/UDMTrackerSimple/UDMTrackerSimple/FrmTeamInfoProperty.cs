using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class FrmTeamInfoProperty : DevExpress.XtraEditors.XtraForm
    {
        private CTeamInfoS m_cTeamInfoS = null;
        private bool m_bDragDropReady = false;
        private bool m_bSaved = false;

        public FrmTeamInfoProperty()
        {
            InitializeComponent();

            m_cTeamInfoS = CMultiProject.TeamInfoS;
        }

        public bool IsSaved
        {
            get { return m_bSaved; }
            set { m_bSaved = value; }
        }

        private void ShowTabPageS()
        {
            tabMain.TabPages.Clear();

            foreach (var who in m_cTeamInfoS)
            {
                if (tabMain.Controls.ContainsKey(who.Key))
                    continue;

                XtraTabPage tabPage = new XtraTabPage();

                UCTeamInfo ucTeamInfo = new UCTeamInfo();
                ucTeamInfo.TeamInfo = who.Value;
                ucTeamInfo.Dock = DockStyle.Fill;

                tabPage.Name = "tp" + who.Key;
                tabPage.Text = who.Key;
                tabPage.Tag = who.Value;

                tabMain.TabPages.Add(tabPage);
                tabPage.Controls.Add(ucTeamInfo);
            }
        }

        private void ShowGrid()
        {
            if (m_cTeamInfoS == null || m_cTeamInfoS.Count == 0)
                return;

            List<CTag> lstView = new List<CTag>();

            if (m_cTeamInfoS.ElementAt(0).Value.TagKey != string.Empty)
                lstView.Add(CMultiProject.TotalTagS[m_cTeamInfoS.ElementAt(0).Value.TagKey]);

            grdEndTag.DataSource = lstView;
            grdEndTag.RefreshDataSource();

            if (m_cTeamInfoS.RecipeWordS == null)
                m_cTeamInfoS.RecipeWordS = new CTagS();

            grdRecipeTagS.DataSource = m_cTeamInfoS.RecipeWordS.Values.ToList();
            grdRecipeTagS.RefreshDataSource();
        }

        private void ShowOperationTime()
        {
            if (CMultiProject.OperStartTime != DateTime.MinValue && CMultiProject.OperEndTime != DateTime.MinValue)
            {
                dtpkOperStart.EditValue = CMultiProject.OperStartTime;
                dtpkOperEnd.EditValue = CMultiProject.OperEndTime;
            }
            else
            {
                dtpkOperStart.EditValue = DateTime.MinValue;
                dtpkOperEnd.EditValue = DateTime.MinValue;
            }
        }

        private void AddTeamInfo()
        {
            string sTeamName = GetUserInputText("근무 조", "추가하고자 하는 근무 조의 이름을 입력하시오.");

            if (sTeamName == "")
                return;

            if (m_cTeamInfoS.ContainsKey(sTeamName))
            {
                MessageBox.Show("해당 근무 조의 이름은 이미 추가되어있습니다.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else
            {
                CTeamInfo cInfo = new CTeamInfo();
                cInfo.TeamName = sTeamName;

                m_cTeamInfoS.Add(cInfo.TeamName, cInfo);

                ShowTabPageS();
            }
        }

        private void SetOperationTime()
        {
            if (dtpkOperStart.EditValue != null)
                CMultiProject.OperStartTime = (DateTime) dtpkOperStart.EditValue;

            if (dtpkOperEnd.EditValue != null)
                CMultiProject.OperEndTime = (DateTime)dtpkOperEnd.EditValue;
        }

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        private void ClearTagPageS()
        {
            tabMain.TabPages.Clear();
            CMultiProject.TeamInfoS.Clear();
        }

        private CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

            int[] iaRowIndex = grvTag.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CTag) grvTag.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        cTagS.Add(cTag.Key, cTag);
                }
            }

            return cTagS;
        }

        private void FrmTeamInfoProperty_Load(object sender, EventArgs e)
        {
            try
            {
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Size.Width/2,
                    Screen.PrimaryScreen.Bounds.Size.Height);
                this.Location = new Point(0, 0);
                grdTag.DataSource = CMultiProject.TotalTagS.Values;
                grdTag.RefreshDataSource();

                if (m_cTeamInfoS == null)
                {
                    m_cTeamInfoS = new CTeamInfoS();
                    return;
                }

                ShowTabPageS();
                ShowGrid();
                ShowOperationTime();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnAddTeam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_cTeamInfoS == null)
                    m_cTeamInfoS = new CTeamInfoS();

                AddTeamInfo();

                m_bSaved = true;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ClearTagPageS();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetOperationTime();
            this.Close();
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetOperationTime();
                this.Close();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTag_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                m_bDragDropReady = false;

                GridView exView = sender as GridView;
                GridHitInfo exHitInfo = exView.CalcHitInfo(new Point(e.X, e.Y));
                if (exHitInfo.InColumnPanel)
                    return;

                if (Control.ModifierKeys != Keys.None)
                    return;

                m_bDragDropReady = true;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTag_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && m_bDragDropReady)
                {
                    CTagS cTagS = GetSelectedTagS();
                    if (cTagS == null)
                    {
                        m_bDragDropReady = false;
                        return;
                    }

                    grdTag.DoDragDrop(cTagS, DragDropEffects.Move);
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                    m_bDragDropReady = false;
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmTeamInfoProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            CMultiProject.TeamInfoS.RecipeWordS = m_cTeamInfoS.RecipeWordS;
        }

        private void grdEndTag_DragOver(object sender, DragEventArgs e)
        {
            if (m_cTeamInfoS == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdEndTag_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (m_cTeamInfoS == null)
                    return;

                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof (CTagS)))
                    {
                        e.Effect = DragDropEffects.Move;

                        CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        CTag cTag = cTagS[0];

                        foreach (var who in m_cTeamInfoS)
                            who.Value.TagKey = cTag.Key;

                        ShowGrid();
                        cTagS.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdRecipeTagS_DragOver(object sender, DragEventArgs e)
        {
            if (m_cTeamInfoS == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdRecipeTagS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (m_cTeamInfoS == null)
                    return;

                if (CMultiProject.ProjectInfo.ViewRecipe == null)
                {
                    MessageBox.Show("Project Setting 창에서 Recipe Setting을 먼저 진행하세요.", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof (CTagS)))
                    {
                        e.Effect = DragDropEffects.Move;

                        CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        CTag cTag;
                        for (int i = 0; i < cTagS.Count; i++)
                        {
                            cTag = cTagS[i];

                            if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord ||
                                cTag.DataType == EMDataType.Int || cTag.DataType == EMDataType.DInt)
                            {
                                if (!m_cTeamInfoS.RecipeWordS.ContainsKey(cTag.Key))
                                    m_cTeamInfoS.RecipeWordS.Add(cTag);
                                if (i == CMultiProject.ProjectInfo.ViewRecipe.WordIndex)
                                    CMultiProject.ProjectInfo.TeamInfoS.SelectRecipeWord = cTag;

                                foreach (var who in m_cTeamInfoS)
                                {
                                    if (who.Value.RecipeWordKeyS == null)
                                        who.Value.RecipeWordKeyS = new List<string>();

                                    who.Value.RecipeWordKeyS.Add(cTag.Key);

                                    if (i == CMultiProject.ProjectInfo.ViewRecipe.WordIndex)
                                        who.Value.SelectedRecipeKey = cTag.Key;
                                }
                            }
                        }
                        ShowGrid();
                        cTagS.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cTeamInfoS == null)
                    return;

                foreach (var who in m_cTeamInfoS)
                {
                    if (cntxTag.SourceControl == grdEndTag)
                        who.Value.TagKey = string.Empty;
                    else if (cntxTag.SourceControl == grdRecipeTagS)
                    {
                        if (m_cTeamInfoS.First().Value == who.Value)
                        {
                            m_cTeamInfoS.RecipeWordS.Clear();
                            m_cTeamInfoS.SelectRecipeWord = null;
                        }

                        who.Value.RecipeWordKeyS.Clear();
                        who.Value.SelectedRecipeKey = string.Empty;
                    }
                }

                ShowGrid();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTeamInfoProperty",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvRecipeTagS_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btnOperationReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = XtraMessageBox.Show("라인 구동 시간을 리셋하시겠습니까?", "Reset", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlgResult == DialogResult.No)
                return;

            CMultiProject.OperStartTime = DateTime.MinValue;
            CMultiProject.OperEndTime = DateTime.MinValue;

            dtpkOperStart.EditValue = DateTime.MinValue;
            dtpkOperEnd.EditValue = DateTime.MinValue;
        }
    }
}