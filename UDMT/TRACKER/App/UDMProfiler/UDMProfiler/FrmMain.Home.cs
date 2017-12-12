using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Log;

namespace UDMProfiler
{
    public partial class FrmMain
    {

        private void SaveProject(string sPath)
        {
            bool bOK = false;
            string sMessage = string.Empty;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                bOK = CProjectManager.Save(sPath, out sMessage);
            }
            SplashScreenManager.CloseForm(false);

            if (bOK)
            {
                UpdateSystemMessage("저장", "저장에 성공했습니다.");
                XtraMessageBox.Show("Save Success!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UpdateSystemMessage("저장실패", sMessage);
                XtraMessageBox.Show("Save Fail!!!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenProject(string sPath)
        {
            bool bOK = false;
            string sMessage = string.Empty;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                bOK = CProjectManager.Open(sPath, out sMessage);
            }
            SplashScreenManager.CloseForm(false);

            if (bOK)
            {
                UpdateSystemMessage("열기", "열기에 성공했습니다.");
                XtraMessageBox.Show("Open Success!!!", "Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UpdateSystemMessage("열기실패", sMessage);
                XtraMessageBox.Show("Open Fail!!!", "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected void ShowPLCInformation(bool bOK)
        {
            if (bOK)
            {
                if (dpnlPLC.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlPLC.Show();
            }
            else
            {
                if (dpnlPLC.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlPLC.Hide();
            }
        }

        protected void ShowSystemMessage(bool bOK)
        {
            if (bOK)
            {
                if (dpnlMessage.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlMessage.Show();
            }
            else
            {
                if (dpnlMessage.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlMessage.Hide();
            }
        }

        protected void ShowProjectInformation(bool bOK)
        {
            if (bOK)
            {
                if (dpnlProject.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlProject.Show();
            }
            else
            {
                if (dpnlProject.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlProject.Hide();
            }
        }


        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.Project != null)
                {
                    if (
                        XtraMessageBox.Show("작업 중인 프로젝트가 존재합니다.\r\n새로운 프로젝트를 생성하시겠습니까?", "New", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                CProjectManager.Clear();
                CProjectManager.Project = null;

                string sProjectName = GetUserInputText("Input Project Name", "프로젝트 이름을 입력하세요.");

                if (sProjectName == string.Empty)
                {
                    XtraMessageBox.Show("프로젝트 이름이 비었습니다.\r\n다시 입력 하세요.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                CProjectManager.Create(sProjectName);

                btnPLCSetting_ItemClick(null, null);

                CProjectManager.Refresh();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Frm New", "Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string sPath = string.Empty;

                if (CProjectManager.Project != null)
                {
                    if (
                        XtraMessageBox.Show("작업 중인 프로젝트가 존재합니다.\r\n다른 프로젝트를 불러오시겠습니까?", "Open", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                CProjectManager.Clear();
                CProjectManager.Project = null;

                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.Filter = "*.upr|*.upr";
                if (dlgOpenFile.ShowDialog() == DialogResult.Cancel)
                    return;

                sPath = dlgOpenFile.FileName;

                dlgOpenFile.Dispose();
                dlgOpenFile = null;

                UpdateSystemMessage("열기", "프러젝트 열기를 시작 : " + sPath);

                if (sPath != string.Empty)
                    OpenProject(sPath);
                else
                    UpdateSystemMessage("열기 실패", "경로가 없습니다");

                CProjectManager.Refresh();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Frm Open", "Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!CheckProjectExist())
                    return;

                string sPath = CProjectManager.ProjectPath;
                if (!File.Exists(sPath))
                {
                    SaveFileDialog dlgSaveFile = new SaveFileDialog();
                    dlgSaveFile.Filter = "*.upr|*.upr";
                    if (dlgSaveFile.ShowDialog() == DialogResult.Cancel)
                        return;

                    sPath = dlgSaveFile.FileName;

                    dlgSaveFile.Dispose();
                    dlgSaveFile = null;
                }

                UpdateSystemMessage("저장", "프러젝트 저장을 시작 : " + sPath);

                if (sPath != string.Empty)
                    SaveProject(sPath);
                else
                    UpdateSystemMessage("저장 실패", "경로가 없습니다");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Frm Save", "Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!CheckProjectExist())
                    return;

                string sPath = string.Empty;

                SaveFileDialog dlgSaveFile = new SaveFileDialog();
                dlgSaveFile.Filter = "*.upr|*.upr";
                if (dlgSaveFile.ShowDialog() == DialogResult.Cancel)
                    return;

                sPath = dlgSaveFile.FileName;

                dlgSaveFile.Dispose();
                dlgSaveFile = null;

                UpdateSystemMessage("저장", "프러젝트 저장을 시작 : " + sPath);

                if (sPath != string.Empty)
                    SaveProject(sPath);
                else
                    UpdateSystemMessage("저장 실패", "경로가 없습니다");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Frm Save As", "Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnPLCSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckProjectExist())
                return;

            FrmPlcSetWizard frmWizard = new FrmPlcSetWizard();
            frmWizard.ShowDialog();

            if (CProjectManager.PlcS.Count > 0 && frmWizard.ChangeFlag)
            {
                CProjectManager.TotalTagS.Clear();

                foreach(var who in CProjectManager.PlcS)
                    CProjectManager.TotalTagS.AddRange(who.Value.TagS);

                //Debug
                XtraMessageBox.Show(string.Format("Plc Setting OK!, Total Tag Count : {0}", CProjectManager.TotalTagS.Count));

                CProjectManager.Refresh();
            }

            frmWizard.Dispose();
            frmWizard = null;
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dlgResult = XtraMessageBox.Show("UDM Profiler를 종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlgResult == DialogResult.No)
                return;

            this.Close();
        }


        private void chkProjectView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowProjectInformation(chkProjectView.Checked);
        }

        private void chkPLCView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowPLCInformation(chkPLCView.Checked);
        }

        private void chkSystemMessage_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowSystemMessage(chkSystemMessage.Checked);
        }


    }
}
