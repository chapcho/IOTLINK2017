using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;

using UDM.General.Csv;
using UDM.Common;
using System.IO;
using UDM.General;
using System.ComponentModel;
using UDM.UI;
using UDM.Converter;
using UDM.LogicViewer;
using System.Data;
using UDM.Import.ME;
using UDM.Log;
using UDM.Project;
using UDM.UDLImport;

namespace UDMTracker
{
    partial class FrmMain
    {
        #region Member Variables

        private delegate void deleBackgroundThreadRungS(CLDRungS cLDRungS);
        private delegate void deleBackgroundThreadTagS(CTagS cTagS);
        
        #endregion


        #region Private Methods

        private bool ImportTagNew(string sPath)
        {
            bool bOK = true;

            ucProjectManager.Clear();
            bOK = ImportTagAdd(sPath);

            return bOK;
        }

        private bool ImportTagAdd(string sPath)
        {
			string sChannel = GetUserInputText("Input Channel", "Please enter text below...");

            bool bOK = true;
            CCsvReader cReader = null;
			
            try
            {
                cReader = new CCsvReader();
                bOK = cReader.Open(sPath, true);
                if (bOK == false)
                    return false;

                CTag cTag;
                string sKey = string.Empty;
                List<string> lstValue = null;
                while (cReader.EOF == false)
                {
                    lstValue = cReader.ReadLine();
                    if (lstValue != null && lstValue.Count > 2)
                    {
						sKey = string.Format("{0}.{1}[{2}]", sChannel, lstValue[0], 1);
                        if (ucProjectManager.Project.TagS.ContainsKey(sKey))
                            continue;

                        cTag = new CTag();
                        cTag.Key = sKey;
                        cTag.Address = lstValue[0].ToUpper();
                        cTag.DataType = CCommonUtil.ToDataType(lstValue[1]);
                        cTag.Description = lstValue[2];
						cTag.Channel = sChannel;
                        ucProjectManager.Project.TagS.Add(sKey, cTag);

                        lstValue.Clear();
                        lstValue = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (cReader != null)
                {
                    cReader.Close();
                    cReader.Dispose();
                    cReader = null;
                }
            }

            if(ucProjectManager.TagTableView != null)
                ucProjectManager.TagTableView.ShowTable();

            return bOK;
        }
        
        private string GetErrorFormatPath(OpenFileDialog openDialog)
        {
            string[] openFiles = openDialog.FileNames;

            CCsvReader cHelper = new CCsvReader();
            if (openDialog.FilterIndex == 2)
                cHelper.CsvType = EMCsvType.Tab;

            foreach (string sPath in openFiles)
            {
                bool bOK = cHelper.Open(sPath, true, 1);

                if (!bOK || cHelper.Header.Count < 2)
                {
                    return sPath;
                }
            }

            cHelper.Close();
            cHelper.Dispose();
            cHelper = null;

            return string.Empty;
        }

        private void ImportPLC(OpenFileDialog openDialog, string sChannel)
        {
            string[] sArrFiles = openDialog.FileNames;
            if (sArrFiles.Length == 0)
                return;

            bool bWorks2 = false;
            if (openDialog.FilterIndex == 2)
                bWorks2 = true;

			

            CILConvert cILConvert = LoadPLC(sArrFiles, bWorks2, null);
			CLCConvet cLCConvet = new CLCConvet(sChannel, cILConvert);
            CLDConvet cLDConvet = new CLDConvet(cLCConvet.StepS, null);

            ucProjectManager.Clear();
            ucProjectManager.Project.StepS = cLCConvet.StepS;
            ucProjectManager.Project.TagS = cLCConvet.TagS;
            ucProjectManager.Project.Compose();

            ucProjectManager.Refresh();
            
            //ucTagTable.ShowTable();
        }

        private CILConvert LoadPLC(string[] sFileNames, bool bTabSplitter, BackgroundWorker backgroundWorker)
        {
            CILConvert cILConvert = new CILConvert();
            CILImport cILImport = new CILImport();
            DataSet dbCSV = new DataSet();

            dbCSV = OpenCSVfiles(sFileNames, bTabSplitter);

            cILImport.ImportIL(dbCSV);
            cILConvert.ConvertIL(cILImport.DicILLINE, backgroundWorker);
            cILConvert.SymbolS = ImportSymbol(dbCSV, bTabSplitter);

            return cILConvert;
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
                    if (bTabSplitter)
                        bOK = cHelper.Open(sArrPath[iTable], true, 1);
                    else
                        bOK = cHelper.Open(sArrPath[iTable], false); // Developer format
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



        private bool ExportTag(string sPath)
        {
            bool bOK = true;
            CCsvWriter cWriter = null;

            try
            {
                cWriter = new CCsvWriter(false);
                cWriter.Header.Add("Address");
                cWriter.Header.Add("DataType");
                cWriter.Header.Add("Description");

                bOK = cWriter.Open(sPath);
                if (bOK == false)
                    return false;

                string sLine;
                CTag cTag;
                for (int i = 0; i < ucProjectManager.Project.TagS.Count; i++)
                {
                    cTag = ucProjectManager.Project.TagS[i];
                    sLine = cTag.Address;
                    sLine += "," + cTag.DataType.ToString();
                    sLine += "," + cTag.Description;

                    cWriter.WriteLine(sLine);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (cWriter != null)
                {
                    cWriter.Close();
                    cWriter.Dispose();
                    cWriter = null;
                }
            }

            return bOK;
        }

        private bool ExportTagForKepware(string sPath)
        {
            bool bOK = true;
            CCsvWriter cWriter = null;

            try
            {
                cWriter = new CCsvWriter(false);
                cWriter.Header.Add("Tag Name");
                cWriter.Header.Add("Address");
                cWriter.Header.Add("Data Type");
                cWriter.Header.Add("Client Access");
                cWriter.Header.Add("Scan Rate");
                cWriter.Header.Add("Description");

                bOK = cWriter.Open(sPath);
                if (bOK == false)
                    return false;

                CTag cTag;
                string sLine;
                for (int i = 0; i < ucProjectManager.Project.TagS.Count; i++)
                {
                    cTag = ucProjectManager.Project.TagS[i];
                    if (cTag.GroupRoleS.Count > 0)
                    {
                        sLine = cTag.Key;
                        sLine += "," + cTag.Address;
                        if (cTag.DataType == EMDataType.Bool)
                            sLine += ",Boolean";
                        else
                            sLine += ",Word";

                        sLine += ",RO";
                        sLine += ",30";
                        sLine += "," + cTag.Description;

                        cWriter.WriteLine(sLine);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (cWriter != null)
                {
                    cWriter.Close();
                    cWriter.Dispose();
                    cWriter = null;
                }
            }

            return bOK;
        }

        private void UpdateAddressFilter()
        {
            List<string> lstAddressFilter = ParseLine(txtAddressFilter.EditValue.ToString(), false);

            m_lstAddressFilter.Clear();
            m_lstAddressFilter.AddRange(lstAddressFilter);
        }

        private void UpdateDescriptionFilter()
        {
            List<string> lstDescriptionFilter = ParseLine(txtDescriptionFilter.EditValue.ToString(), true);

            m_lstDescriptionFilter.Clear();
            m_lstDescriptionFilter.AddRange(lstDescriptionFilter);
        }

		private void ApplyFilter()
		{
			CTagS cFitlerTagS = new CTagS();
			CTag cTag;
			for(int i=0;i<ucProjectManager.Project.TagS.Count;i++)
			{
				cTag = ucProjectManager.Project.TagS[i];
				if(cTag.GroupRoleS.Count > 0)
				{

				}
			}
			
		}

        private List<string> ParseLine(string sLine, bool bLower)
        {
            string[] saToken = sLine.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (saToken == null)
                return null;

            List<string> lstLine = new List<string>();
            for (int i = 0; i < saToken.Length; i++)
            {
                if (bLower)
                    lstLine.Add(saToken[i].ToLower());
                else
                    lstLine.Add(saToken[i]);
            }

            return lstLine;
        }

        private void ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker);

            if (!cLogic.FileOpenCheck)
                return;
            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import " + cLogic.PLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucProjectManager.Clear();
            ucProjectManager.Project.Clear();
            ucProjectManager.Project.TagS = cLogic.GlobalTags;

            ucProjectManager.Project.StepS = cLogic.StepS;
            CStepExtract.SplitStepS(ucProjectManager.Project.StepS, ucProjectManager.Project.TagS);

            ucProjectManager.Project.Compose();
            ucProjectManager.Refresh();
        }

        private void GetUsedStepS(CStepS cStepS)
        {
            CTagS cTagS = ucProjectManager.Project.TagS;

            foreach(var who in cStepS)
            {
                CStep cStep = who.Value;
                for (int i = 0; i < cStep.CoilS.Count; i++)
                {
                    foreach (CContent cont in cStep.CoilS[i].ContentS)
                    {
                        if (cont.Tag == null) continue;
                        if (cTagS.ContainsKey(cont.Tag.Key))
                        {
                            if (ucProjectManager.Project.StepS.ContainsKey(who.Key) == false)
                                ucProjectManager.Project.StepS.Add(who.Key, cStep);
                        }
                    }
                }
            }
        }

        private void ImportMelsecPLC(string sChannel)
        {
            CUDLImport cMelsecLogic = new CUDLImport(UDM.Common.EMPLCMaker.Mitsubishi);

            if (!cMelsecLogic.FileOpenCheck)
                return;

            cMelsecLogic.Channel = sChannel;
            bool bOK = cMelsecLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import Melsec Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucProjectManager.Clear();
            ucProjectManager.Project.TagS = cMelsecLogic.GlobalTags;
            ucProjectManager.Project.StepS = cMelsecLogic.StepS;
            
            CStepExtract.SplitStepS(ucProjectManager.Project.StepS, ucProjectManager.Project.TagS);

            ucProjectManager.Project.Compose();
            ucProjectManager.Refresh();
        }

        private void ImportLogic()
        {
            CUDLImport cLogic = new CUDLImport(UDM.Common.EMPLCMaker.ALL);
            string sChannel = string.Empty;

            if (!cLogic.FileOpenCheck)
                return;

            if (cLogic.PLCMaker != UDM.Common.EMPLCMaker.LS)
            {
                sChannel = GetUserInputText("Input " + cLogic.PLCMaker.ToString() + " Tag Header", "Please enter text below...");
                cLogic.Channel = sChannel;
            }

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                MessageBox.Show("Can't Convert Logic", "Import Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucProjectManager.Clear();
            ucProjectManager.Project.TagS = cLogic.GlobalTags;
            ucProjectManager.Project.StepS = cLogic.StepS;
            CStepExtract.SplitStepS(ucProjectManager.Project.StepS, ucProjectManager.Project.TagS);

            ucProjectManager.Project.Compose();
            ucProjectManager.Refresh();
        }

        private void ImportTag(bool bNew)
        {
            try
            {
                CUDLImport cLogic = new CUDLImport(UDM.Common.EMPLCMaker.ALL);
                string sChannel = string.Empty;

                if (!cLogic.FileOpenCheck)
                    return;

                if (cLogic.PLCMaker != UDM.Common.EMPLCMaker.LS)
                {
                    sChannel = GetUserInputText("Input " + cLogic.PLCMaker.ToString() + " Tag Header", "Please enter text below...");
                    cLogic.Channel = sChannel;
                }

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                bool bOK = cLogic.MakeGlobelAndLocalTags();

                if (!bOK)
                {
                    MessageBox.Show("Can't Import Tag", "Import Tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(bNew)
                    ucProjectManager.Clear();

                ImportTagAdd(cLogic.GlobalTags);
                ucProjectManager.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); 
                ex.Data.Clear();
            }
        }

        private void ImportTagAdd(CTagS cTagS)
        {
            try
            {
                foreach (CTag cTag in cTagS.Values)
                {
                    if (!ucProjectManager.Project.TagS.ContainsKey(cTag.Key))
                        ucProjectManager.Project.TagS.Add(cTag);
                }

                if (ucProjectManager.TagTableView != null)
                    ucProjectManager.TagTableView.ShowTable();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }


        #endregion


        #region Event Methods

        private void btnImportTagNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            ImportTag(true);
            SplashScreenManager.CloseForm(false);
        }

        private void btnImportTagAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            ImportTag(false);
            SplashScreenManager.CloseForm(false);
        }

        private void btnImportLogic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            if (chkLsPlc.Checked) 
                btnLSImportLogic_ItemClick(sender, e);
            else if (chkMelsecPlc.Checked) 
                btnMelsecImportLogic_ItemClick(sender, e);
            else if (chkSiemens.Checked) 
                btnSiemensImportLogic_ItemClick(sender, e);
            else 
                ImportLogic();

            
            SplashScreenManager.CloseForm(false);
        }

        private void btnLSImportLogic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            string sChannel = GetUserInputText("Input LS Tag Header", "Please enter text below...");

            if (sChannel == "") return;
            
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            ImportPLC(UDM.Common.EMPLCMaker.LS, sChannel);
            SplashScreenManager.CloseForm(false);
        }

        private void btnMelsecImportLogic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            string sChannel = GetUserInputText("Input LS Tag Header", "Please enter text below...");

            if (sChannel == "") return;
            
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            ImportMelsecPLC(sChannel);
            SplashScreenManager.CloseForm(false);
        }

        private void btnSiemensImportLogic_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            string sChannel = GetUserInputText("Input Siemens Tag Header", "Please enter text below...");

            if (sChannel == "") return;
            
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            ImportPLC(UDM.Common.EMPLCMaker.Siemens, sChannel);
            SplashScreenManager.CloseForm(false);
        }


        private void btnExportTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();
            string sPath = dlgSaveFile.FileName;
            if (sPath != "")
            {
                bool bOK = ExportTag(sPath);
                if (bOK == false)
                    MessageBox.Show("Can't save file!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("File saved!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
        }

        private void btnExportTagForKepware_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CheckProjectEditable() == false)
                return;

            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";

            string sPath = dlgSaveFile.FileName;
            if (sPath != "")
            {
                bool bOK = ExportTagForKepware(sPath);
                if (bOK == false)
                    MessageBox.Show("Can't save file!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("File saved!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdatePatternItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPatternItemUpdater frmUpdater = new FrmPatternItemUpdater();
            frmUpdater.Project = ucProjectManager.Project;
            frmUpdater.DBReader = m_cReader;
            frmUpdater.AddressFilterList = m_lstAddressFilter;
            frmUpdater.DescriptionFilter = m_lstDescriptionFilter;

            frmUpdater.ShowDialog();

            ucGroupTree.ShowTree();
            ucTagTable.ShowTable();
        }

        private void btnUpdateMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMasterPatternUpdater frmGenerator = new FrmMasterPatternUpdater();
            frmGenerator.Project = ucProjectManager.Project;
            frmGenerator.Reader = m_cReader;
            frmGenerator.ShowDialog();

            ucGroupTree.ShowTree();
            ucTagTable.ShowTable();
        }

        private void btnEditMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMasterPatternEditor frmEditor = new FrmMasterPatternEditor();
            frmEditor.Project = ucProjectManager.Project;
            // frmEditor.ShowDialog();
            frmEditor.Show();
        }

        private void btnApplyFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateAddressFilter();
            UpdateDescriptionFilter();
        }

        #endregion
    }
}
