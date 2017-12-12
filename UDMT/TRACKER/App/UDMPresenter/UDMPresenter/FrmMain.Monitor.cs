using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.General.Csv;
using UDM.Converter;
using System.ComponentModel;
using UDM.UI;
using UDM.General;
using UDM.UDLImport;
using UDM.Monitor.Plc.Source.OPC;

namespace UDMPresenter
{
	partial class FrmMain
	{

		#region Private Methods

        #region Melsec Import Logic Function

        private void CreateProjectFromLogic(CILConvert cILConvert, BackgroundWorker backgroundWorker)
        {
            backgroundWorker.ReportProgress(99, "Covert");

            CLCConvet cLCConvet = new CLCConvet(CProjectManager.SelectedProject.OpcConfig.ChannelDevice, cILConvert);

            CProjectManager.SelectedProject.TagS = cLCConvet.TagS;
            CProjectManager.SelectedProject.StepS = cLCConvet.StepS;
            
        }

        /// <summary>
        /// Only Melsec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportPLC(object sender, DoWorkEventArgs e)
        {
            OpenFileDialog openDialog = (OpenFileDialog)e.Argument;

            string[] sArrFiles = openDialog.FileNames;
            if (sArrFiles.Length == 0)
                return;

            bool bWorks2 = false;
            if (openDialog.FilterIndex == 2)
                bWorks2 = true;

            CILConvert cILConvert = LoadPLC(sArrFiles, bWorks2, (BackgroundWorker)sender);
            CreateProjectFromLogic(cILConvert, (BackgroundWorker)sender);

            //로직 변환이 완료 되어 DDEA Project 생성
            UpdateSystemMessage("Logic Import", "Logic Import Success");

            
        }

        private DataSet OpenCSVfiles(string[] sArrPath, bool bTabSplitter)
        {
            DataSet dbCSV = new DataSet();

            for (int iTable = 0; iTable < sArrPath.Length; iTable++)
            {
                dbCSV.Tables.Add(Path.GetFileName(sArrPath[iTable]));
                CCsvReader cHelper = new CCsvReader();

                if (bTabSplitter)
                    cHelper.CsvType = EMCsvType.Tab;

                bool bOK = false;

                if (dbCSV.Tables[iTable].TableName.Contains("COMMENT"))
                {
                    bOK = cHelper.Open(sArrPath[iTable], true, 1);
                }
                else
                {
                    if (bTabSplitter)
                        bOK = cHelper.Open(sArrPath[iTable], true, 2);  // works2 format
                    else
                        bOK = cHelper.Open(sArrPath[iTable], false); // Developer format
                }

                if (bOK)
                    bOK = cHelper.Fill(dbCSV.Tables[iTable]);

                cHelper.Dispose();
                cHelper = null;
            }

            return dbCSV;
        }

        private CILConvert LoadPLC(string[] sFileNames, bool bTabSplitter, BackgroundWorker backgroundWorker)
        {
            CILConvert cILConvert = new CILConvert();
            CILImport cILImport = new CILImport();
            DataSet dbCSV = new DataSet();

            dbCSV = OpenCSVfiles(sFileNames, bTabSplitter);
            //  dbCSV = OpenExcelfiles(sFileNames, bTabSplitter);

            cILImport.ImportIL(dbCSV);
            cILConvert.ConvertIL(cILImport.DicILLINE, backgroundWorker);
            cILConvert.SymbolS = ImportSymbol(dbCSV, bTabSplitter);

            return cILConvert;
        }

        private CILSymbolS ImportSymbol(DataSet DS, bool bTabSplitter)
        {
            CILSymbolS cLcSymbolS = new CILSymbolS();

            foreach (DataTable DT in DS.Tables)
            {
                if (DT.Columns.Count > 3)
                    continue;

                int iColAddress = 0;
                int iColSymbol = 2;

                if (bTabSplitter)
                    iColSymbol = 1;

                string sProgram = DT.TableName.Replace(".csv", string.Empty).ToUpper();
                for (int nRow = 1; nRow < DT.Rows.Count; nRow++)
                {
                    string sAddress = DT.Rows[nRow].ItemArray[iColAddress].ToString().ToUpper();
                    string sName = DT.Rows[nRow].ItemArray[iColSymbol].ToString();

                    CILSymbol cLcSymbol = new CILSymbol(sName, sAddress, sProgram);

                    cLcSymbolS.Add(cLcSymbol.Key, cLcSymbol);
                }
            }

            return cLcSymbolS;
        }

        /// <summary>
        /// Only Melsec
        /// </summary>
        /// <param name="saFiles"></param>
        /// <param name="iFilterIndex"></param>
        /// <returns></returns>
        public List<string> GetErrorFileList(string[] saFiles, int iFilterIndex)
        {
            List<string> lstErrorFile = new List<string>();

            foreach (string sPath in saFiles)
            {
                CCsvReader cHelper = new CCsvReader();
                if (iFilterIndex == 2)
                    cHelper.CsvType = EMCsvType.Tab;

                bool bOK = cHelper.Open(sPath, true, 2);

                if (!bOK || cHelper.Header.Count < 2)
                {
                    lstErrorFile.Add(sPath);
                }

                cHelper.Close();
                cHelper.Dispose();
                cHelper = null;
            }

            return lstErrorFile;
        }

        #endregion

        /// <summary>
        /// Only Siemens
        /// </summary>
        /// <param name="cStepS"></param>
        private void GetUsedStep(CStepS cStepS)
        {
            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            CTagS cUsedTagS = new CTagS();
            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    foreach (CContent cont in cStep.CoilS[i].ContentS)
                    {
                        if (cont.Tag == null) continue;
                        
                        if(cTagS.ContainsKey(cont.Tag.Key))
                        {
                            if (cUsedTagS.ContainsKey(cont.Tag.Key) == false) cUsedTagS.Add(cont.Tag);

                            if (CProjectManager.SelectedProject.StepS.ContainsKey(who.Key) == false)
                                CProjectManager.SelectedProject.StepS.Add(who.Key, cStep);
                        }
                    }
                }
                foreach (CContact cont in cStep.ContactS)
                {
                    for(int i = 0; i<cont.RefTagS.KeyList.Count; i++)
                    {
                        if (cTagS.ContainsKey(cont.RefTagS.KeyList[i]))
                        {
                            if (cUsedTagS.ContainsKey(cont.RefTagS.KeyList[i]) == false) cUsedTagS.Add(cTagS[cont.RefTagS.KeyList[i]]);
                        }
                    }
                }
            }
            CProjectManager.SelectedProject.TagS = cUsedTagS;
        }

        private CStepS GetUsedStep(CStepS cStepS, CTagS cTagS)
        {
            CStepS cRetStepS = new CStepS();
            CTagS cUsedTagS = new CTagS();
            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    foreach (CContent cont in cStep.CoilS[i].ContentS)
                    {
                        if (cont.Tag == null) continue;

                        if (cTagS.ContainsKey(cont.Tag.Key))
                        {
                            if (cUsedTagS.ContainsKey(cont.Tag.Key) == false) cUsedTagS.Add(cont.Tag);

                            if (cRetStepS.ContainsKey(who.Key) == false)
                                cRetStepS.Add(who.Key, cStep);
                        }
                    }
                }
                foreach (CContact cont in cStep.ContactS)
                {
                    for (int i = 0; i < cont.RefTagS.KeyList.Count; i++)
                    {
                        if (cTagS.ContainsKey(cont.RefTagS.KeyList[i]))
                        {
                            if (cUsedTagS.ContainsKey(cont.RefTagS.KeyList[i]) == false) cUsedTagS.Add(cTagS[cont.RefTagS.KeyList[i]]);
                        }
                    }
                }
            }
            cTagS = cUsedTagS;

            return cRetStepS;
        }
        /// <summary>
        /// Only siemnes
        /// </summary>
        /// <param name="cTagS"></param>
        /// <param name="sChannel"></param>
        private void GetUsedTagS(CTagS cTagS)
        {
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                if (cTag.Address == "") continue;
                if (cTag.Address.Contains("FC") || cTag.Address.Contains("FB") || cTag.Address.Contains("SFB") || cTag.Address.Contains("SFC"))
                    continue;
                //if (cTag.Address.Contains("DB")) continue;
                if (cTag.DataType == EMDataType.Block) continue;
                if (cTag.DataType == EMDataType.Date_And_Time) continue;
                if (cTag.DataType == EMDataType.Int) cTag.DataType = EMDataType.Word;
                
                if (cTag.Address.Contains("T")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MD")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MW")) cTag.DataType = EMDataType.Word;
                else if (cTag.Address.Contains("MB")) cTag.DataType = EMDataType.Byte;

                cTag.Key = cTag.Key;
                cTag.Channel = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;
                cTag.Description = cTag.Name;

                CProjectManager.SelectedProject.TagS.Add(cTag);
            }
            ValidateTag(CProjectManager.SelectedProject.TagS);
        }

        private bool GetSiemensLogic(string sChannel)
        {
            CUDLImport cSiemensLogic = new CUDLImport(UDM.Common.EMPLCMaker.Siemens, false);
            cSiemensLogic.Channel = sChannel;
            bool bOK = cSiemensLogic.UDLGenerate();
            if (bOK == false)
                return false;
            if (CProjectManager.SelectedProject.TagS.Count > 0)
                CProjectManager.SelectedProject.TagS.Clear();
            GetUsedTagS(cSiemensLogic.GlobalTags);
            //GetUsedTagS(cSiemensLogic.LocalTags);

            if (CProjectManager.SelectedProject.StepS.Count > 0)
                CProjectManager.SelectedProject.StepS.Clear();

            GetUsedStep(cSiemensLogic.StepS);

            CProjectManager.UpdateView();

            return true;
        }

        private bool GetMelsecCSVLogic(string sChannel)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "PLC Developer Files|*.csv|PLC Works2 Files|*.csv";
            dlgOpenFile.RestoreDirectory = true;
            dlgOpenFile.Multiselect = true;

            if (dlgOpenFile.ShowDialog() != DialogResult.OK) return false;
            if (dlgOpenFile.FileNames.Length == 0) return false;

            int iFormat = dlgOpenFile.FilterIndex;

            string[] saFile = dlgOpenFile.FileNames;

            List<string> lstError = GetErrorFileList(saFile, iFormat);
            if (lstError.Count > 0 && lstError.Count < dlgOpenFile.FileNames.Length)
            {
                string s = "";
                for (int i = 0; i < lstError.Count; i++)
                {
                    s += Path.GetFileName(lstError[i]) + ", \r\n";
                }
                //UpdateSystemMessage(string.Format("Selected [ {0} ] files wrong format!!", s));
                s = string.Format("Open Error, Selected files wrong format!!");
                UpdateSystemMessage("Logic Import", s);
                return false;
            }
            else if (lstError.Count == dlgOpenFile.FileNames.Length)
            {
                dlgOpenFile.FilterIndex = 2;
                UpdateSystemMessage("Logic Import", "Open Works2 Format");
            }
            else
            {
                UpdateSystemMessage("Logic Import", "Open Developer Format");
            }

            BackgroundWorker BGW = new BackgroundWorker();
            BGW.DoWork += new DoWorkEventHandler(ImportPLC);
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BackgroundThread BGT = new BackgroundThread(BGW, "Import PLC Program", dlgOpenFile);
            return true;
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (CProjectManager.SelectedProject.TagS.Count > 0 && CProjectManager.SelectedProject.StepS.Count > 0)
            {
                CreateStepTagList();
                SetRadioItemDescription();
            }
            else
                UpdateSystemMessage("Logic Import", "변환할 내용이 없습니다.");

            CProjectManager.UpdateView();
        }

        private void CreateStepTagList()
        {
            List<CTag> lstTag = new List<CTag>();
            CStepS cStepS = CProjectManager.SelectedProject.StepS;
            CTagS cTagS = CProjectManager.SelectedProject.TagS;
            CProjectManager.SelectedProject.StepTagList.Clear();
            
            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    for (int k = 0; k < cStep.CoilS[i].RefTagS.KeyList.Count; k++)
                    {
                        string sKey = cStep.CoilS[i].RefTagS.KeyList[k];
                        if (cTagS.ContainsKey(sKey))
                        {
                            CStepTagList cStepTagList = new CStepTagList();
                            cStepTagList.StepKey = who.Key;
                            cStepTagList.Program = cStep.Program;
                            cStepTagList.StepNumber = cStep.CoilS[i].StepIndex;
                            cStepTagList.NetworkNumber = cStep.StepIndex;
                            cStepTagList.CoilTag = cTagS[sKey];
                            cStepTagList.Command = cStep.CoilS[i].Command;
                            for (int u = 0; u < cStep.RefTagS.KeyList.Count; u++)
                            {
                                sKey = cStep.RefTagS.KeyList[u];
                                if (cTagS.ContainsKey(sKey))
                                {
                                    cStepTagList.ContactTagList.Add(cTagS[sKey]);
                                }
                            }
                            if (CProjectManager.SelectedProject.StepTagList.Contains(cStepTagList) == false)
                                CProjectManager.SelectedProject.StepTagList.Add(cStepTagList);
                        }
                    }
                }
            }
        }

        private bool ValidateTag(CTagS cTagS)
        {
            if (cTagS.Count == 0) return false;

            COPCServer cOPCServer = new COPCServer();
            cOPCServer.Config = new COPCConfig();
            cOPCServer.Config.Use = true;
            cOPCServer.Config.ServerName = CProjectManager.SelectedProject.OpcConfig.ServerName;
            cOPCServer.Config.ChannelDevice = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;
            cOPCServer.Config.UpdateRate = CProjectManager.SelectedProject.OpcConfig.UpdateRate;

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

        private CTagS GetUsedTagS(CTagS cTagS, string sChannel)
        {
            CTagS cRetTagS = new CTagS();
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                if (cTag.Address == "") continue;
                if (cTag.Address.Contains("FC") || cTag.Address.Contains("FB") || cTag.Address.Contains("SFB") || cTag.Address.Contains("SFC"))
                    continue;
                //if (cTag.Address.Contains("DB")) continue;
                if (cTag.DataType == EMDataType.Block) continue;
                if (cTag.DataType == EMDataType.Date_And_Time) continue;
                if (cTag.DataType == EMDataType.Int) cTag.DataType = EMDataType.Word;

                if (cTag.Address.Contains("T")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MD")) cTag.DataType = EMDataType.DWord;
                else if (cTag.Address.Contains("MW")) cTag.DataType = EMDataType.Word;
                else if (cTag.Address.Contains("MB")) cTag.DataType = EMDataType.Byte;

                cTag.Key = cTag.Key;
                cTag.Channel = sChannel;
                cTag.Description = cTag.Description;

                cRetTagS.Add(cTag);
            }

            bool bOK = ValidateTag(cRetTagS);
            if (bOK == false) return null;
            return cRetTagS;
        }

        private bool ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker, false);

            if (!cLogic.FileOpenCheck)
                return false;
            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import " + emPLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (emPLCMaker != UDM.Common.EMPLCMaker.Siemens)
            {

                CProjectManager.SelectedProject.TagS = cLogic.GlobalTags;
                CProjectManager.SelectedProject.StepS = cLogic.StepS;
                CStepExtract.SplitStepS(cLogic.StepS, cLogic.GlobalTags);
            }
            else
            {
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel);
                if (cTagS == null)
                    return false;

                CProjectManager.SelectedProject.TagS = cTagS;
                CProjectManager.SelectedProject.StepS = GetUsedStep(cLogic.StepS, cTagS);
            }

            CProjectManager.SelectedProject.StepS.Compose(CProjectManager.SelectedProject.TagS);
            CProjectManager.SelectedProject.PlcMaker = emPLCMaker;

            return true;
        }

		#endregion


		#region Event Methods

		private void btnImportLogic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            if (CheckProjectAvailable() == false)
                return;

            if (CProjectManager.SelectedProject.OpcConfig.ChannelDevice == "")
            {
                MessageBox.Show("OPC 통신 설정을 먼저 진행하세요", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool bOK = false;
            if (CProjectManager.SelectedProject.PlcMaker == UDM.Common.EMPLCMaker.Siemens)
            {
                exScreenManager.ShowWaitForm();
                exScreenManager.SetWaitFormCaption("Convert Logic");
                exScreenManager.SetWaitFormDescription("Siemens Logic Converting...");

                bOK = GetSiemensLogic(CProjectManager.SelectedProject.OpcConfig.ChannelDevice);

                if (bOK)
                {
                    if (CProjectManager.SelectedProject.TagS.Count > 0 && CProjectManager.SelectedProject.StepS.Count > 0)
                    {
                        CreateStepTagList();
                        SetRadioItemDescription();
                    }
                    else
                        UpdateSystemMessage("Logic Import", "변환할 내용이 없습니다.");

                }
                exScreenManager.CloseWaitForm();
            }
            else if(CProjectManager.SelectedProject.PlcMaker == UDM.Common.EMPLCMaker.LS)
            {
                bOK = ImportPLC(UDM.Common.EMPLCMaker.LS, CProjectManager.SelectedProject.OpcConfig.ChannelDevice);
                if (bOK)
                {
                    CreateStepTagList();
                    CProjectManager.UpdateView();
                }
            }
            else
            {
                if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC)
                    bOK = GetMelsecCSVLogic(CProjectManager.SelectedProject.OpcConfig.ChannelDevice);
                else
                    bOK = GetMelsecCSVLogic("CH.DV");
            }

            if (bOK == false)
            {
                UpdateSystemMessage("Logic Import", "변환이 불가능합니다.");
                return;
            }
            
		}


		private void btnImportTagNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (CheckProjectAvailable() == false)
                return;
			
			//CProjectManager.Clear();

			btnImportTagAdd_ItemClick(this, null);
		}

		private void btnImportTagAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (CheckProjectAvailable() == false)
				return;
            if (CProjectManager.SelectedProject.PlcMaker != UDM.Common.EMPLCMaker.Mitsubishi)
            {
                UpdateSystemMessage("Add Tag", "Melsec Works3만 가능 합니다.");
                return;
            }

			OpenFileDialog dlgOpenFile = new OpenFileDialog();
			dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.Multiselect = true;
			dlgOpenFile.ShowDialog();

            string[] sPathLst = dlgOpenFile.FileNames;
            if (sPathLst.Length >0)
            {
                string sChannel = "";
                if (CProjectManager.SelectedProject.OpcConfig.ChannelDevice == "")
                {
                    MessageBox.Show("OPC 통신 설정을 먼저 진행하세요", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sChannel = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;

                bool bOK = CProjectManager.ImportTagS(sPathLst, sChannel);
                if (bOK == false)
                {
                    MessageBox.Show("Can't Open file!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateSystemMessage("Open", "Can't Open file!!");
                }
                else
                    SetRadioItemDescription();
            }
		}

        private void btnClearAllTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.SelectedProject.TagS.Count > 0)
            {
                CProjectManager.SelectedProject.TagS.Clear();
                CProjectManager.SelectedProject.SymbolS.Clear();
                CProjectManager.UpdateView();
                UpdateSystemMessage("Tag", "Clear All Tag / Symbol");
            }
        }

		private void btnExportTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (CheckProjectAvailable() == false)
				return;

			SaveFileDialog dlgSaveFile = new SaveFileDialog();
			dlgSaveFile.Filter = "*.csv|*.csv";
			dlgSaveFile.ShowDialog();
			string sPath = dlgSaveFile.FileName;
			if (sPath != "")
			{
				bool bOK = CProjectManager.ExportTagS(sPath);
				if (bOK == false)
					MessageBox.Show("Can't save file!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
					MessageBox.Show("File saved!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

        private void btnAddTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;
            if (CProjectManager.SelectedProject.PlcMaker != UDM.Common.EMPLCMaker.Mitsubishi)
            {
                UpdateSystemMessage("Add Tag", "사용자 Tag입력은 Melsec만 추가 합니다.");
                return;
            }
            Form frmCheck = IsFormOpened(typeof(FrmAddTag));
            if (frmCheck != null)
            {
                MessageBox.Show("이미 창이 열려 있습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sChannel = "";
            int iAddCount = 0;
            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC)
            {
                if (CProjectManager.SelectedProject.OpcConfig.ChannelDevice == "")
                {
                    MessageBox.Show("OPC 통신 설정을 먼저 진행하세요", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sChannel = CProjectManager.SelectedProject.OpcConfig.ChannelDevice;
            }
            else
            {
                sChannel = GetUserInputText("Input Channel", "Please enter text below...\r\nex) \"Channel.Device\"");
                if (sChannel == "")
                {
                    MessageBox.Show("Please Channel Set Frist !!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            iAddCount += CProjectManager.SelectedProject.TagS.Count;
            SetRadioItemDescription();

            FrmAddTag frmAddTag = new FrmAddTag();
            frmAddTag.Channel = sChannel;
            frmAddTag.ShowDialog();
        }

		#endregion
	}
}
