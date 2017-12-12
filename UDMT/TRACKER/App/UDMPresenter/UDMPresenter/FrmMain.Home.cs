using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.DDEA;
using UDM.Log;
using UDM.Log.Csv;
using UDM.Monitor;
using UDM.Monitor.Plc.Source.OPC;
using UDM.UI;

namespace UDMPresenter
{
	partial class FrmMain
	{

		#region Private Methods

        private bool m_bFirstProgram = true;

        protected void ShowTagList(CDDEASymbolS cSymbolS)
        {
            if (cSymbolS == null) return;
            if (this.grdRunSymbolView.InvokeRequired)
            {
                ShowTagListCallBack d = new ShowTagListCallBack(ShowTagList);
                this.Invoke(d, new object[] { cSymbolS });
            }
            else
            {
                try
                {
                    if (cSymbolS == null)
                        grdRunSymbolView.DataSource = null;
                    else
                        grdRunSymbolView.DataSource = FindShowDDEASymbolList(cSymbolS);

                    grdRunSymbolView.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Tag", ex.Message);
                }
            }
        }

        private void ShowSymbolStatusTable(CSymbolS cSymbolS)
        {
            if (this.grdRunSymbolView.InvokeRequired)
            {
                ShowSymbolListCallBack d = new ShowSymbolListCallBack(ShowSymbolStatusTable);
                this.Invoke(d, new object[] { cSymbolS });
            }
            else
            {
                try
                {
                    if (cSymbolS == null)
                        grdRunSymbolView.DataSource = null;
                    else
                        grdRunSymbolView.DataSource = cSymbolS.Select(x => x.Value).ToList();

                    grdRunSymbolView.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Tag", ex.Message);
                }
            }
        }

        private bool SaveAs()
        {
            string sPath = "";
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Presenter Project File|*.upm";

            if (dlgSave.ShowDialog() != DialogResult.OK) return false;
            if (dlgSave.FileNames.Length == 0) return false;
            sPath = dlgSave.FileName;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Save");
            exScreenManager.SetWaitFormDescription("Presenter Project File Saving...");

            bool bOK = CProjectManager.Save(sPath);

            exScreenManager.CloseWaitForm();

            if (bOK == false)
                UpdateSystemMessage("Project저장", "파일 저장에 실패!!!");
            else
                UpdateSystemMessage("Project저장", "파일 저장에 성공했습니다.");

            return true;
        }
        
        private void OpenProjectLogPath(CProject cProject)
        {
            cProject.TimeLogS = new CTimeLogS();
            if (cProject.LogFilePathList == null) return;
            CCsvLogReader cLogReader = new CCsvLogReader();
            bool bOK = cLogReader.Open(cProject.LogFilePathList.ToArray());
            if (bOK)
            {
                cProject.TimeLogS = cLogReader.ReadTimeLogS();
                UpdateSystemMessage("OpenLog", "최근 수집한 로그 " + cProject.TimeLogS.Count.ToString() + " 개를 열었습니다.");
            }
            else
            {
                UpdateSystemMessage("OpenLog", "최근 수집한 로그를 열 수 없습니다.");
            }
        }

        private void ActiveIconNew(bool bActive)
        {
            mnuPlcSetting.Enabled = bActive;
            mnuDDEAControl.Enabled = bActive;
            mnuSymbols.Enabled = bActive;
            mnuLog.Enabled = bActive;
            btnSave.Enabled = bActive;
            btnSaveAs.Enabled = bActive;
        }

        private string GetRadioItemDescription()
        {
            if (CProjectManager.SelectedProject.OpcConfig == null) return "";
            string sServer = CProjectManager.SelectedProject.OpcConfig.ServerName;
            string sChannel = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;
            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
            {
                sServer = CProjectManager.SelectedProject.PLCConfig.SelectedItem.ToString();
                sChannel = "";
            }
            else if(CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.LS)
            {
                sServer = CProjectManager.SelectedProject.LsConfig.InterfaceType.ToString();
                sChannel = "";
            }
            string sDescription = string.Format("Name : {0}\r\nType : {1} / {2}\r\nServer : {3}\r\nChannel : {4}", 
                                  CProjectManager.SelectedProject.Name, 
                                  CProjectManager.SelectedProject.PlcMaker, 
                                  CProjectManager.SelectedProject.CollectorType,
                                  sServer,
                                  sChannel
                                  );

            return sDescription;
        }

        private string GetRadioItemDescription(CProject cProject)
        {
            if (cProject.OpcConfig == null) return "";
            string sServer = cProject.OpcConfig.ServerName;
            string sChannel = cProject.OpcConfig.ChannelDevice;
            if (cProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
            {
                sServer = "DDEA";
                sChannel = "";
            }
            string sDescription = string.Format("Name : {0}\r\nType : {1} / {2}\r\nServer : {3}\r\nChannel : {4}",
                                  cProject.Name,
                                  cProject.PlcMaker,
                                  cProject.CollectorType,
                                  sServer,
                                  sChannel
                                  );

            return sDescription;
        }

        private void SetRadioItemDescription()
        {
            int iIndex = radioGroupProjectList.SelectedIndex;
            if (iIndex < 0) return;
            string sDescription = GetRadioItemDescription();
            radioGroupProjectList.Properties.Items[iIndex].Description = sDescription;
        }

        private void WriteLogFile()
        {
            foreach (var who in CProjectManager.ProjectList)
            {
                string sPrjPath = who.Value.SaveLogPath;
                if (m_dicProjectLogPath.ContainsKey(sPrjPath))
                    m_dicProjectLogPath[sPrjPath].Clear();
                else
                    m_dicProjectLogPath.Add(sPrjPath, new List<string>());
                
                m_dicProjectLogPath[sPrjPath] = who.Value.LogFilePathList;
            }

            if (m_dicProjectLogPath.Count > 0)
            {
                StreamWriter writer = new StreamWriter(m_sLogSavePathFile);
                foreach (var who in m_dicProjectLogPath)
                {
                    writer.WriteLine("ProjectPath=" + who.Key);

                    for (int i = 0; i < who.Value.Count; i++)
                        writer.WriteLine("LogPath=" + who.Value[i]);
                }

                writer.Dispose();
                writer = null;
            }
        }

        private void OpenFileLogPath()
        {
            if (File.Exists(m_sLogSavePathFile) == false)
            {
                FileStream stream = File.Create(m_sLogSavePathFile);
                stream.Dispose();
                stream = null;
            }
            else
            {
                string sSaveLogPath = "";
                if (m_dicProjectLogPath.Count == 0)
                {
                    StreamReader reader = new StreamReader(m_sLogSavePathFile);
                    string sLine = "";
                    while ((sLine = reader.ReadLine()) != null)
                    {
                        if (sLine.Contains("ProjectPath="))
                        {
                            string[] saSplit = sLine.Split('=');
                            sSaveLogPath = saSplit[1];
                            m_dicProjectLogPath.Add(sSaveLogPath, new List<string>());
                        }
                        else if (sLine.Contains("LogPath="))
                        {
                            string[] saSplit = sLine.Split('=');
                            if (m_dicProjectLogPath.ContainsKey(sSaveLogPath))
                                m_dicProjectLogPath[sSaveLogPath].Add(saSplit[1]);
                        }
                    }
                    reader.Dispose();
                    reader = null;
                }
                foreach (var who in CProjectManager.ProjectList)
                {
                    string sLogPath = who.Value.SaveLogPath + "\\" + who.Value.Name;
                    if (m_dicProjectLogPath.ContainsKey(sLogPath))
                        who.Value.LogFilePathList = m_dicProjectLogPath[sLogPath];
                }
            }
        }

        private bool ValidateTag(CProject cProject, CTagS cTagS)
        {
            if (cProject.CollectorType != UDM.Monitor.Plc.Source.EMSourceType.OPC) return false;
            if (cTagS.Count == 0) return false;

            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = cProject.OpcConfig;
            cOPCServer.Config.Use = true;
            bool bCheck = false;
            bool bOK = cOPCServer.Connect();
            if (bOK)
            {
                List<string> lstResult = cOPCServer.ValidateItemS(cTagS.Values.ToList());
                if (lstResult != null && lstResult.Count != 0)
                {
                    string sDeleteTag = "";
                    //삭제 구문
                    for (int i = 0; i < lstResult.Count; i++)
                    {
                        if (cTagS.ContainsKey(lstResult[i]))
                            cTagS.Remove(lstResult[i]);
                        //sDeleteTag += string.Format("{0}, ", lstResult[i]);
                    }
                    //sDeleteTag += string.Format("\r\n\r\n제외 Tag : {0}ea", lstResult.Count);
                    sDeleteTag = string.Format("수집 불가능한 Tag : {0}ea", lstResult.Count);
                    MessageBox.Show(sDeleteTag);

                    if (cTagS.Count == 0)
                        MessageBox.Show("변환된 Tag가 없습니다. OPC 설정이나 입력한 Channel.Device정보가 틀렸을 수 있습니다.\r\n확인하세요.", "UDM Tracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        bCheck = true;
                }
            }

            cOPCServer.Disconnect();
            cOPCServer.Dispose();
            cOPCServer = null;

            return bCheck;
        }

		#endregion


		#region Event Methods

        private void btnAddProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmInputDialog dlgInput = new FrmInputDialog("Input Text", "Please input new project name below..");
            dlgInput.ShowDialog();

            string sText = dlgInput.InputText;
            if (sText == "") return;

            if (CProjectManager.CheckSameProject(sText))
            {
                MessageBox.Show("같은 Name이 존재합니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CProjectManager.ProjectList.Count >= 5)
            {
                MessageBox.Show("5개를 초과할 수 없습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CProject cProject = new CProject();
            cProject.Name = sText;

            CProjectManager.SelectedProject = cProject;

            FrmPlcSetWizard frmWizard = new FrmPlcSetWizard();
            frmWizard.Project = CProjectManager.SelectedProject;
            frmWizard.ShowDialog();

            if (CProjectManager.ProjectList.Count > 0)
            {
                radioGroupProjectList.Properties.Items.Clear();
                foreach (var who in CProjectManager.ProjectList)
                {
                    string sComment = GetRadioItemDescription(who.Value);
                    RadioGroupItem rGroupItem = new RadioGroupItem(who.Value, sComment);
                    radioGroupProjectList.Properties.Items.Add(rGroupItem);
                }
                radioGroupProjectList.SelectedIndex = radioGroupProjectList.Properties.Items.Count - 1;
            }
            //UpdateSystemMessage("Project 생성", sText + " 프로젝트가 생성되었습니다.");
            btnRemoveProject.Enabled = true;

            ActiveIconNew(true);
        }

        private void btnRemoveProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (radioGroupProjectList.SelectedIndex < 0) return;
            radioGroupProjectList.Properties.Items.RemoveAt(radioGroupProjectList.SelectedIndex);
            radioGroupProjectList.SelectedIndex = radioGroupProjectList.Properties.Items.Count - 1;
            //CProjectManager.SelectedProject.UEventMessage -= SelectedProject_UEventMessage;
            
            CProjectManager.DeleteSelectedProject();
            if (CProjectManager.ProjectList.Count == 0)
            {
                btnRemoveProject.Enabled = false;
                ActiveIconNew(false);
            }
        }

		private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Presenter Project File|*.upm";

            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            if (dlgOpen.FileNames.Length == 0) return;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Open");
            exScreenManager.SetWaitFormDescription("Presenter Project File Opening...");
            
            bool bOK = CProjectManager.Open(dlgOpen.FileName);

            exScreenManager.CloseWaitForm();

            if (bOK == false || CProjectManager.ProjectList == null || CProjectManager.ProjectList.Count == 0)
                UpdateSystemMessage("Project열기", "파일 열기에 실패!!!");
            else
            {
                OpenFileLogPath();
                radioGroupProjectList.Properties.Items.Clear();
                foreach (var who in CProjectManager.ProjectList)
                {
                    OpenProjectLogPath(who.Value);
                    RadioGroupItem rGroupItem = new RadioGroupItem(who.Value.Name, GetRadioItemDescription(who.Value));
                    radioGroupProjectList.Properties.Items.Add(rGroupItem);
                }
                if (CProjectManager.ProjectList.Count > 0)
                {
                    radioGroupProjectList.SelectedIndex = 0;
                    btnRemoveProject.Enabled = true;
                }
                
                if (CProjectManager.TagTable != null && CProjectManager.SymbolTable != null)
                    CProjectManager.UpdateView();
                else
                {
                    CProjectManager.TagTable = ucTagTable;
                    CProjectManager.SymbolTable = ucSymbolTable;
                    CProjectManager.UpdateView();
                    CProjectManager.SetTagTable();
                }

                ActiveIconNew(true);
                
                UpdateSystemMessage("Project열기", "파일 열기에 성공했습니다.");
            }
		}

		private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (CheckProjectAvailable() == false) return;

            string sPath = CProjectManager.SelectedProject.Path;
            if (CProjectManager.SelectedProject.Path == "")
            {
                SaveAs();
            }
            else
            {
                exScreenManager.ShowWaitForm();
                exScreenManager.SetWaitFormCaption("Save");
                exScreenManager.SetWaitFormDescription("Presenter Project File Saving...");

                bool bOK = CProjectManager.Save(sPath);
                if (bOK == false)
                    UpdateSystemMessage("Project저장", "파일 저장에 실패!!!");
                else
                    UpdateSystemMessage("Project저장", "파일 저장에 성공했습니다.");
                exScreenManager.CloseWaitForm();

            }
		}

		private void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (CheckProjectAvailable() == false) return;

            SaveAs();
		}

        private void btnStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false) return;
            if (m_bRun == true) return;
            if (CProjectManager.SelectedProject.Path == "")
            {
                MessageBox.Show("Please Save First!!");
                bool bOK = SaveAs();
                if (bOK == false) return;
            }

            if (CProjectManager.SelectedProject.SymbolS.Count == 0)
            {
                UpdateSystemMessage("수집", "수집대상이 없습니다");
                return;
            }
            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Start");
            exScreenManager.SetWaitFormDescription("Running...");

            //각 Project 시작
            int iCount = 0;
            foreach (var who in CProjectManager.ProjectList)
            {
                who.Value.UEventMessage += SelectedProject_UEventMessage;
                who.Value.CollectStart();
                
                for (int i = 0; i < 50; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                }
                if (who.Value.Run == false)
                {
                    UpdateSystemMessage("수집 시작", string.Format("{0} 프로젝트 수집을 시작하지 못했습니다.", who.Value.Name));
                    radioGroupProjectList.Properties.Items[iCount].Enabled = false;
                    who.Value.UEventMessage -= SelectedProject_UEventMessage;
                    who.Value.CollectStop();
                }
                else
                    iCount++;                        
            }

            exScreenManager.CloseWaitForm();

            if (iCount == 0)
            {
                m_bRun = false;
                foreach (RadioGroupItem item in radioGroupProjectList.Properties.Items)
                    item.Enabled = true;
                return;
            }
            m_bRun = true;

            foreach (var who in CProjectManager.ProjectList)
                who.Value.SaveLogPath += "\\" + who.Value.Name;

            CProjectManager.SelectedProject.LogFilePathList.Clear();
            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC || 
                CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.LS)
                ShowSymbolStatusTable(CProjectManager.SelectedProject.SymbolS);
            else
                ShowTagList(CProjectManager.SelectedProject.DDEASymbolS);
            tmrDataRefresh.Start();

            grdRunSymbolView.Enabled = true;
            ucSymbolTable.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            mnuPlcSetting.Enabled = false;
            mnuProject.Enabled = false;
            mnuSymbols.Enabled = false;
            btnImportLog.Enabled = false;
            tabCollectView.SelectedTabPage = tpRealTagView;
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bRun == false) return;

            tmrDataRefresh.Stop();

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Stop");
            exScreenManager.SetWaitFormDescription("......");
            tabCollectView.SelectedTabPage = tpTagList;
            //각 Project 정지
            foreach (var who in CProjectManager.ProjectList)
            {
                if (who.Value.Run)
                {
                    who.Value.CollectStop();
                    who.Value.UEventMessage -= SelectedProject_UEventMessage;
                }
            }

            exScreenManager.CloseWaitForm();

            WriteLogFile();

            grdRunSymbolView.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            m_bRun = false;
            ucSymbolTable.Enabled = true;
            mnuPlcSetting.Enabled = true;
            mnuProject.Enabled = true;
            mnuSymbols.Enabled = true;
            btnImportLog.Enabled = true;
        }

		#endregion


        #region Event Method

        void ucSymbolTable_UEventSymbolAdded(object sender, List<CSymbol> lstSymbol)
        {
            CProjectManager.TagTable.RefreshDataSource();
            List<string> lstAddKey = lstSymbol.Select(b=> b.Key).ToList();
            CProjectManager.SelectedProject.UserAddSymbol.AddRange(lstAddKey);
        }

        void ucSymbolTable_UEventSymbolRemoved(object sender, List<CSymbol> lstSymbol)
        {
            CProjectManager.TagTable.RefreshDataSource();
            List<string> lstRemoveKey = lstSymbol.Select(b => b.Key).ToList();
            for(int i=0; i<lstRemoveKey.Count; i++)
                CProjectManager.SelectedProject.UserAddSymbol.Remove(lstRemoveKey[i]);
        }

        void SelectedProject_UEventMessage(object sender, string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        #endregion
    }
}
