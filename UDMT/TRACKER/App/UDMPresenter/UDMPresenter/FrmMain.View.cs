using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;

namespace UDMPresenter
{
	partial class FrmMain
	{

		#region Private Methods

        private bool SetLogCount(CTimeLogS cSourceLogS)
        {
            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            if (cSourceLogS == null || cSourceLogS.Count == 0)
            {
                MessageBox.Show("Please Import Log First!!", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cTagS == null || cTagS.Count == 0)
            {
                MessageBox.Show("Tag가 없습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MaxValue;
            List<string> lstSameKey = new List<string>();
            List<string> lstNotFoundKey = new List<string>();
            foreach (var who in cSourceLogS)
            {
                if (lstSameKey.Contains(who.Key) == false)
                {
                    if (cTagS.ContainsKey(who.Key))
                    {
                        CTimeLogS cLogS = cSourceLogS.GetTimeLogS(who.Key, dtFrom, dtTo);
                        cTagS[who.Key].LogCount = cLogS.Count;
                    }
                    else
                    {
                        lstNotFoundKey.Add(who.Key);
                    }
                    lstSameKey.Add(who.Key);
                }

            }
            if (lstNotFoundKey.Count > 0)
            {
                MessageBox.Show("Tag에서 찾지 못한 접점 = " + lstNotFoundKey.Count.ToString());
            }

            CProjectManager.UpdateView();
            return true;
        }

		#endregion


		#region Event Methods

        private void btnImportLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CProjectManager.SelectedProject == null)
            {
                UpdateSystemMessage("Log Chart", "해당 프로젝트를 찾을 수 없습니다.");
                return;
            }

            string[] saPath;
            DialogResult dlgResult;

            if (CProjectManager.SelectedProject.LogFilePathList != null && CProjectManager.SelectedProject.LogFilePathList.Count > 0)
            {
                dlgResult = MessageBox.Show("최근 수집한 Log 파일을 바로 불러 오시겠습니까?", "UDM Presenter", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    saPath = new string[CProjectManager.SelectedProject.LogFilePathList.Count];
                    for (int i = 0; i < saPath.Length; i++)
                        saPath[i] = CProjectManager.SelectedProject.LogFilePathList[i];
                }
                else
                {
                    OpenFileDialog dlgOpenFile = new OpenFileDialog();
                    dlgOpenFile.Multiselect = true;
                    dlgOpenFile.Filter = "*.csv|*.csv";
                    dlgOpenFile.InitialDirectory = CProjectManager.SelectedProject.SaveLogPath;
                    dlgResult = dlgOpenFile.ShowDialog();
                    if (dlgResult == DialogResult.Cancel) return;
                    saPath = dlgOpenFile.FileNames;
                }
            }
            else
            {
                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.Multiselect = true;
                dlgOpenFile.Filter = "*.csv|*.csv";
                dlgOpenFile.InitialDirectory = CProjectManager.SelectedProject.SaveLogPath;
                dlgResult = dlgOpenFile.ShowDialog();
                if (dlgResult == DialogResult.Cancel) return;
                saPath = dlgOpenFile.FileNames;
            }
            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Log Import");
            exScreenManager.SetWaitFormDescription("Presenter Log Import...");

            CCsvLogReader cLogReader = new CCsvLogReader();
            bool bOK = cLogReader.Open(saPath);
            if (bOK)
                CProjectManager.SelectedProject.TimeLogS = cLogReader.ReadTimeLogS();

            exScreenManager.CloseWaitForm();

            if (bOK == false)
                MessageBox.Show("Can't open log files!", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                UpdateSystemMessage("Log Chart", "파일 Log Count = " + CProjectManager.SelectedProject.TimeLogS.Count.ToString());
            SetLogCount(CProjectManager.SelectedProject.TimeLogS);
            UpdateSystemMessage("Log Chart", "Tag Table LogCount 적용 완료");
        }

		private void btnShowChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (CheckProjectAvailable() == false)
                return;

            if (CProjectManager.SelectedProject == null)
            {
                UpdateSystemMessage("Log Chart", "해당 프로젝트를 찾을 수 없습니다.");
                return;
            }
            CProject cProject = CProjectManager.SelectedProject;
            if (cProject.TimeLogS == null)
                cProject.TimeLogS = new CTimeLogS();
            //else
            //    cProject.TimeLogS.Clear();
            string[] saPath;

            if (cProject.TimeLogS.Count == 0 && cProject.LogFilePathList != null && cProject.LogFilePathList.Count > 0)
            {
                saPath = new string[cProject.LogFilePathList.Count];
                for (int i = 0; i < saPath.Length; i++)
                    saPath[i] = cProject.LogFilePathList[i];

                CCsvLogReader cLogReader = new CCsvLogReader();
                bool bOK = cLogReader.Open(saPath);
                if (bOK)
                    cProject.TimeLogS = cLogReader.ReadTimeLogS();
            }

            if (cProject.TimeLogS.Count == 0)
            {
                MessageBox.Show("최근 수집한 결과가 없습니다" + "기록된 최근 파일 수 : " + cProject.LogFilePathList.Count.ToString());
                return;
            }
            else
            {
                UpdateSystemMessage("Log Chart", "최근 10개 파일 Log Count = " + cProject.TimeLogS.Count.ToString());
            }
			FrmTimeChartViewer frmViewer = new FrmTimeChartViewer();
            
            frmViewer.TagS = cProject.TagS;
            frmViewer.TimeLogS = cProject.TimeLogS;
            frmViewer.StepTagList = cProject.StepTagList;
			frmViewer.Show();
		}

		#endregion
	}
}
