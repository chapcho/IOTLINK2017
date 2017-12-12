using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.General.Csv;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source;
using UDM.Monitor.Plc.Source.LS;
using UDM.UDLImport;
using UDM.Common;

namespace UDMEnergyViewer
{
	partial class FrmMain
	{

		#region Private Methods

		private void ShowModelConfig()
		{
			ShowPlcConfig();
			ShowLogConfig();
            ShowEnergyConfig();
		}

		private void ShowPlcConfig()
		{
			txtPlcIP.EditValue = CProjectManager.Project.PlcConfig.IP;
            txtPlcPort.EditValue = CProjectManager.Project.PlcConfig.Port;
            spnPlcInterval.EditValue = CProjectManager.Project.PlcConfig.Interval;
            cmbPlcSourceType.EditValue = CProjectManager.Project.PlcConfig.InterfaceType;
		}

        private void ShowEnergyConfig()
        {
            txtEnergyIP.EditValue = CProjectManager.Project.MeterConfig.IP;
            txtEnergyPort.EditValue = CProjectManager.Project.MeterConfig.Port;
            spnEnergyChannelS.EditValue = CProjectManager.Project.MeterConfig.ChannelNum.ToString();
        }


		private void ShowLogConfig()
		{
			txtLogPath.EditValue = CProjectManager.Project.LogConfig.SavePath;
            //txtEnergyLogPath.EditValue = CProjectManager.Project.LogConfig.EnergySavePath;
		}

		private void ApplyPlcConfig()
		{
            CProjectManager.Project.PlcConfig.Use = true;
            CProjectManager.Project.PlcConfig.IP = (string)txtPlcIP.EditValue;
            CProjectManager.Project.PlcConfig.Port = (string)txtPlcPort.EditValue;
            CProjectManager.Project.PlcConfig.Interval = int.Parse(spnPlcInterval.EditValue.ToString());

			string sSourceType = cmbPlcSourceType.EditValue.ToString();
			if(sSourceType != "")
			{
                if (sSourceType.StartsWith("USB"))
                    CProjectManager.Project.PlcConfig.InterfaceType = EMLsInterfaceType.USB;
                else
                    CProjectManager.Project.PlcConfig.InterfaceType = EMLsInterfaceType.Ethernet;
			}

            UpdateSystemMessage("PLC Interface", "PLC Interface Apply Success!");
		}

        private void ApplyEnergyConfig()
        {
            CProjectManager.Project.MeterConfig.IP = (string)txtEnergyIP.EditValue;
            CProjectManager.Project.MeterConfig.Port = txtEnergyPort.EditValue.ToString();
            CProjectManager.Project.MeterConfig.ChannelNum= int.Parse(spnEnergyChannelS.EditValue.ToString());

            UpdateSystemMessage("Energy Interface", "Energy Interface Apply Success!");
        }

		private void TestPlcConnect()
		{
            if(CheckProjectAvailable() == false)
                return ;

            UDM.Monitor.Plc.Source.LS.CLsReader cReader = new CLsReader();
            cReader.Config = CProjectManager.Project.PlcConfig;
            bool bOK = cReader.Connect();
            cReader.Disconnect();
            cReader.Dispose();

            if (bOK)
                MessageBox.Show("Connection OK!!");
            else
                MessageBox.Show("Fail to connect!!");
		}

        private void TestEnergyConnect()
        {
            CMeterReader cReader = new CMeterReader();
            cReader.Config = CProjectManager.Project.MeterConfig;

            bool bOK = cReader.Connect();

            cReader.Disconnect();
            cReader.Dispose();

            if (bOK)
                MessageBox.Show("Connection OK!!");
            else
                MessageBox.Show("Fail to connect!!");
        }

		private void ApplyLogConfig()
		{
			CProjectManager.Project.LogConfig.SavePath = (string)txtLogPath.EditValue;
            //CProjectManager.Project.LogConfig.EnergySavePath = (string)txtEnergyLogPath.EditValue;

            UpdateSystemMessage("Data Logging", "Log File Path Apply Success!");
		}

		private void ChangeLogPath()
		{
			FolderBrowserDialog dlgOpenFolder = new FolderBrowserDialog();
			dlgOpenFolder.ShowDialog();

			string sPath = dlgOpenFolder.SelectedPath;
			if (sPath.Trim() == "")
				return;

			txtLogPath.EditValue = sPath;
		}

        private void ImportLogic()
        {
            if (CheckProjectAvailable() == false)
                return;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Convert Logic");
            exScreenManager.SetWaitFormDescription("LS Logic Converting...");

            GetLSLogic();
            exScreenManager.CloseWaitForm();
        }

        private void ImportMelsecTag()
        {
            if (CheckProjectAvailable() == false)
                return;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Import Tag");
            exScreenManager.SetWaitFormDescription("Tag Converting...");

            GetMeselecTag();
            exScreenManager.CloseWaitForm();
        }

        private void ImportTag()
        {
            if (CheckProjectAvailable() == false)
                return;

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.ShowDialog();

            string sFile = dlgOpenFile.FileName;
            if (sFile == "")
                return;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Import Tag");
            exScreenManager.SetWaitFormDescription("LS Tag Creating...");
            {
                CCsvReader cReader = new CCsvReader();
                bool bOK = cReader.Open(sFile, true);
                if(bOK)
                {
                    CTagS cTagS = new CTagS();
                    CTag cTag;
                    List<string> lstValue;
                    while(cReader.EOF == false)
                    {
                        lstValue = cReader.ReadLine();
                        if (lstValue == null || lstValue.Count == 0)
                            continue;

                        cTag = new CTag();
                        cTag.Key = "[CH_DV]" + lstValue[0];
                        cTag.Address = lstValue[0];
                        if (cTag.Address.Contains(".") || cTag.Address.Length == 6)
                            cTag.DataType = EMDataType.Bool;
                        else
                            cTag.DataType = EMDataType.Word;

                        cTag.Description = lstValue[1];

                        cTagS.Add(cTag);
                    }

                    cReader.Close();
                    cReader.Dispose();

                    CProjectManager.Project.TagS = cTagS;
                    CProjectManager.UpdateView();
                }
            }
            exScreenManager.CloseWaitForm();
        }

        private void ExportTag()
        {
            if (CheckProjectAvailable() == false)
                return;

            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string sFile = dlgSaveFile.FileName;
            if (sFile == "")
                return;

            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Export Tag");
            exScreenManager.SetWaitFormDescription("Writing Tag...");
            {

                CCsvWriter cWriter = new CCsvWriter(false);
                cWriter.Open(sFile);

                string sLine = "Address,Description";
                cWriter.WriteLine(sLine);

                CTag cTag;
                for (int i = 0; i < CProjectManager.Project.TagS.Count; i++)
                {
                    cTag = CProjectManager.Project.TagS[i];
                    sLine = cTag.Address + "," + cTag.Description;

                    cWriter.WriteLine(sLine);
                }

                cWriter.Close();
                cWriter.Dispose();
            }
            exScreenManager.CloseWaitForm();
        }

        private void GetLSLogic()
        {
            CUDLImport cLSLogic = new CUDLImport(UDM.Common.EMPLCMaker.LS);

            if (!cLSLogic.FileOpenCheck)
                return;

            bool bOK = cLSLogic.UDLGenerate();

            if (!bOK)
            {
                UpdateSystemMessage("Logic Import", "변환이 불가능합니다.");
                return;
            }

            if (CProjectManager.Project.TagS.Count > 0)
                CProjectManager.Project.TagS.Clear();
            GetUsedTagS(cLSLogic.GlobalTags);

            if (CProjectManager.Project.StepS.Count > 0)
                CProjectManager.Project.StepS.Clear();
            GetUsedLSStepS(cLSLogic.StepS);

            CProjectManager.UpdateView();

            if(CProjectManager.Project.TagS.Count > 0 && CProjectManager.Project.StepS.Count > 0)
                CreateStepCoilList();
        }

        private void GetMeselecTag()
        {
            CUDLImport cMelsecTag = new CUDLImport(UDM.Common.EMPLCMaker.Mitsubishi);

            if (!cMelsecTag.FileOpenCheck)
                return;

            bool bOK = cMelsecTag.MakeGlobelAndLocalTags();

            if (!bOK)
            {
                UpdateSystemMessage("Tag Import", "변환이 불가능합니다.");
                return;
            }

            if (CProjectManager.Project.TagS.Count > 0)
                CProjectManager.Project.TagS.Clear();
            GetUsedMelsecTagS(cMelsecTag.GlobalTags);

            CProjectManager.UpdateView();
        }

        private void CreateStepCoilList()
        {
            List<CTag> lstTag = new List<CTag>();
            CStepS cStepS = CProjectManager.Project.StepS;
            CTagS cTagS = CProjectManager.Project.TagS;
            CProjectManager.Project.StepCoilList.Clear();
            foreach (var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    for (int k = 0; k < cStep.CoilS[i].RefTagS.KeyList.Count; k++)
                    {
                        string sKey = cStep.CoilS[i].RefTagS.KeyList[k];
                        if (cTagS.ContainsKey(sKey))
                            CProjectManager.Project.StepCoilList.Add(cTagS[sKey]);
                    }
                }
            }
        }

        private void GetUsedMelsecTagS(CTagS cTagS)
        {
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                if (cTag.Address == string.Empty) continue;

                cTag.Key = string.Format("TEST.MPC5.{0}[{1}]", cTag.Address, cTag.Size);

                CProjectManager.Project.TagS.Add(cTag);
            }
        }

        private void GetUsedTagS(CTagS cTagS)
        {
            foreach (var who in cTagS)
            {
                CTag cTag = who.Value;
                if (cTag.Address == string.Empty) continue;

                //cTag.Key = string.Format("{0}[{1}]", cTag.Address, cTag.Size);

                CProjectManager.Project.TagS.Add(cTag);
            }
        }



        private void GetUsedLSStepS(CStepS cStepS)
        {
            CTagS cTagS = CProjectManager.Project.TagS;

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
                            if (CProjectManager.Project.StepS.ContainsKey(who.Key) == false)
                                CProjectManager.Project.StepS.Add(who.Key, cStep);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
