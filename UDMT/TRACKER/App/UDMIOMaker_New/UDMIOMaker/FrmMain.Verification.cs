using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Word;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Office.Interop.Excel;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;
using Cell = DevExpress.Spreadsheet.Cell;
using Worksheet = DevExpress.Spreadsheet.Worksheet;

namespace UDMIOMaker
{
    partial class FrmMain
    {
        private int m_iUserOptionCount = 1;


        private List<int> m_lstUsedSymbolIndex = new List<int>();

        private void ShowVerificationGrid()
        {
            grdVerifPLC.DataSource = null;
            grdVerifPLC.DataSource = CProjectManager.VerifTagS.Values.ToList();
            grdPLC.RefreshDataSource();
        }

        private void LoadVerificationExceltoSheet(string sPath)
        {
            try
            {

                var finfo = new FileInfo(sPath);
                if (finfo.Exists && !IsFileLocked(finfo))
                    sheetVerification.LoadDocument(sPath);
                else
                    ExceptionSheetLoad();

            }
            catch (Exception ex)
            {
                ExceptionSheetLoad();
                Console.WriteLine(ex.Message);
            }
        }

        private void AutoVerification()
        {
            CTag cTag = null;

            foreach (var who in CProjectManager.VerifTagS)
            {
                cTag = CProjectManager.PLCTagS[who.Value.Key];
                SetUsedLogic(cTag, who.Value);
                SetSymbolRole(cTag, who.Value);
            }

            grdVerifPLC.RefreshDataSource();

            VerificationList cList = new VerificationList();
            cList.coil = CProjectManager.VerifTagS.Values.Where(x => x.SymbolRole == EMSymbolRole.Coil).Count();
            cList.contact = CProjectManager.VerifTagS.Values.Where(x => x.SymbolRole == EMSymbolRole.Contact).Count();
            cList.contactboth = CProjectManager.VerifTagS.Values.Where(x => x.SymbolRole == EMSymbolRole.Both).Count();
            cList.symbol = CProjectManager.VerifTagS.Values.Where(x => x.UsedLogic == EMUsedLogic.NotUsed).Count();
            cList.logic = CProjectManager.VerifTagS.Values.Where(x => x.UsedLogic == EMUsedLogic.Used_OnlyLogic).Count();
            cList.memoryboth = CProjectManager.VerifTagS.Values.Where(x => x.UsedLogic == EMUsedLogic.Used).Count();



            //m_cVerifExport = new PLCVerificationExport(cList);
            LoadVerificationExceltoSheet(CProjectManager.VerifPathUser);
        }

        private bool WriteToExcelReport()
        {
            bool bOK = false;
            try
            {
                var app = new Microsoft.Office.Interop.Excel.Application {Visible = false, DisplayAlerts = false};
                if (File.Exists(CProjectManager.VerifPathUser))
                {
                    var workbook = app.Workbooks.Open(CProjectManager.VerifPath, 0, false, 5, "", "", false,
                        XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    MakeCoverSheet(workbook);
                    workbook.SaveAs(CProjectManager.VerifPathUser, XlFileFormat.xlWorkbookNormal,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                    workbook = null;
                }
                app.Quit();
                app = null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private bool MakeCoverSheet(Workbook xlWorkbook)
        {
            bool bOK = false;

            try
            {
                var sheets = xlWorkbook.Sheets;
                var sheet = (Microsoft.Office.Interop.Excel.Worksheet) sheets[1];

                int iNotUsedValue = CProjectManager.VerifTagS.Where(x => x.Value.UsedLogic == EMUsedLogic.NotUsed).Count();
                sheet.Cells[4, 4] = CProjectManager.VerifTagS.Count - iNotUsedValue;
                sheet.Cells[5, 4] = iNotUsedValue;
                sheet.Cells[6, 4] = CProjectManager.VerifTagS.Count;

                sheet.Cells[10, 4] = CProjectManager.VerifTagS.Where(x => x.Value.SymbolRole == EMSymbolRole.Contact).Count();
                sheet.Cells[11, 4] = CProjectManager.VerifTagS.Where(x => x.Value.SymbolRole == EMSymbolRole.Coil).Count();
                sheet.Cells[12, 4] = CProjectManager.VerifTagS.Where(x => x.Value.SymbolRole == EMSymbolRole.Both).Count();
                sheet.Cells[13, 4] = CProjectManager.VerifTagS.Count;

                sheet.Cells[34, 5] = DateTime.Now.ToString("yyyy-MM-dd");

                bOK = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }


        private void SetUsedLogic(CTag cTag, CVerifTag cVerifTag)
        {
            if(cTag.UseOnlyInLogic)
                cVerifTag.UsedLogic = EMUsedLogic.Used_OnlyLogic;
            else if(cTag.StepRoleS.Count == 0)
                cVerifTag.UsedLogic = EMUsedLogic.NotUsed;
            else if(cTag.StepRoleS.Count > 0)
                cVerifTag.UsedLogic = EMUsedLogic.Used;
        }

        private void SetSymbolRole(CTag cTag, CVerifTag cVerifTag)
        {
            if (cTag.Address.Equals("Q0205.2"))
            {
                int i = 0;
            }

            int iContactCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Contact).Count();
            int iCoilCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Coil).Count();
            int iBothCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Both).Count();

            if (iBothCount > 0 || (iContactCount > 0 && iCoilCount > 0))
                cVerifTag.SymbolRole = EMSymbolRole.Both;
            else
            {
                if(iContactCount == 0 && iCoilCount > 0)
                    cVerifTag.SymbolRole = EMSymbolRole.Coil;
                else if(iCoilCount == 0 && iContactCount > 0)
                    cVerifTag.SymbolRole = EMSymbolRole.Contact;
                else
                    cVerifTag.SymbolRole = EMSymbolRole.NotUsed;
            }
        }

        private void SetDoubleCoil(CTag cTag, CVerifTag cVerifTag)
        {
            int iCoilCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Coil).Count();
            int iBothCount = 0;
            List<string> lstBothStepKey = new List<string>();
            string sStepKey = string.Empty;

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType.Equals(EMStepRoleType.Both))
                {
                    sStepKey = who.StepKey;

                    if (sStepKey.Contains("["))
                        sStepKey = sStepKey.Split('[').First();

                    if (!lstBothStepKey.Contains(sStepKey))
                    {
                        lstBothStepKey.Add(sStepKey);
                        iBothCount++;
                    }
                }
            }

            int iCount = iCoilCount + iBothCount;


            if (iCount >= 2)
                cVerifTag.IsDoubleCoil = true;
        }
        
        private bool SetUserDefineExcelSheet()
        {
            bool bOK = false;

            try
            {
                bOK = WriteUserOptionToExcelReport();

                if(bOK)
                    LoadVerificationExceltoSheet(CProjectManager.VerifPathUser);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool WriteUserOptionToExcelReport()
        {
            bool bOK = true;

            try
            {
                string sElement = string.Empty;

                var app = new Microsoft.Office.Interop.Excel.Application { Visible = false, DisplayAlerts = false };
                if (File.Exists(CProjectManager.VerifPathUser))
                {
                    var workbook = app.Workbooks.Open(CProjectManager.VerifPathUser, 0, false, 5, "", "", false,
                                                       XlPlatform.xlWindows, "", true, false, 0, true, false, false);

                    Microsoft.Office.Interop.Excel.Worksheet sheet = null;

                    foreach (CReportElement cElement in CProjectManager.ReportElementS)
                    {
                        sElement = cElement.Element.Replace(" ", "_");

                        foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in workbook.Sheets)
                        {
                            if (worksheet.Name == sElement)
                            {
                                bOK = false;
                                break;
                            }
                        }

                        if (bOK)
                        {
                            sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[workbook.Sheets.Count];
                            sheet.Copy(Type.Missing, sheet);
                            sheet.Name = sElement;

                            TreeListNode trnElement = ucVerifyElemTree.GetElementTreeListNode(cElement.Element);

                            bOK = InputHyperLink(sElement, trnElement, (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1]);

                            if (bOK)
                                bOK = InputUserOptionData(sElement, trnElement, sheet);
                        }
                    }

                    var startSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                    startSheet.Select(Type.Missing);

                    workbook.SaveAs(CProjectManager.VerifPathUser, XlFileFormat.xlWorkbookNormal,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
                        Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                    sheet = null;
                    workbook = null;

                    bOK = true;
                }

                app.Quit();
                app = null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool InputUserOptionData(string sElement, TreeListNode trnElement, Microsoft.Office.Interop.Excel.Worksheet sheet)
        {
            bool bOK = false;

            try
            {
                int iStartRow = 5;

                sheet.Cells[2, 1] = sElement;

                foreach (TreeListNode trnPLC in trnElement.Nodes)
                {
                    sheet.Cells[iStartRow++, 1] = trnPLC.GetDisplayText(0);

                    foreach (TreeListNode trnTag in trnPLC.Nodes)
                    {
                        sheet.Cells[iStartRow, 1] = trnTag.GetDisplayText(0);
                        sheet.Cells[iStartRow, 2] = trnTag.GetDisplayText(1);
                        sheet.Cells[iStartRow, 3] = trnTag.GetDisplayText(2);
                        sheet.Cells[iStartRow, 4] = trnTag.GetDisplayText(3);
                        sheet.Cells[iStartRow, 5] = trnTag.GetDisplayText(4);

                        if(trnTag.GetDisplayText(5) == "Checked")
                            sheet.Cells[iStartRow, 6] = 1;
                        else
                            sheet.Cells[iStartRow, 6] = 0;

                        if(trnTag.GetDisplayText(6) == "Checked")
                            sheet.Cells[iStartRow, 7] = 1;
                        else
                            sheet.Cells[iStartRow, 7] = 0;

                        iStartRow++;
                    }
                }

                Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("A5", "A" + iStartRow);
                range.Columns.AutoFit();
                range = sheet.get_Range("B5", "B" + iStartRow);
                range.Columns.AutoFit();
                range = sheet.get_Range("C5", "C" + iStartRow);
                range.Columns.AutoFit();
                range = sheet.get_Range("D5", "D" + iStartRow);
                range.Columns.AutoFit();
                range = sheet.get_Range("E5", "E" + iStartRow);
                range.Columns.AutoFit();

                bOK = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool InputHyperLink(string sElement, TreeListNode trnElementNode, Microsoft.Office.Interop.Excel.Worksheet sheet)
        {
            bool bOK = false;
            try
            {
                int iTagCount = 0;

                foreach (TreeListNode trnNode in trnElementNode.Nodes)
                    iTagCount += trnNode.Nodes.Count;

                sheet.Cells[m_iUserOptionCount + 3, 7] = m_iUserOptionCount;
                sheet.Cells[m_iUserOptionCount + 3, 8] = sElement;
                sheet.Cells[m_iUserOptionCount + 3, 9] = iTagCount;

                var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[m_iUserOptionCount + 3, 8];
                sheet.Hyperlinks.Add(sheet.get_Range(cell, cell), "#" + sElement + "!A1", Type.Missing, Type.Missing,
                    Type.Missing);

                bOK = true;

                m_iUserOptionCount++;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private void ExceptionSheetLoad()
        {
            var workbook = sheetVerification.Document;
            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell1 = worksheet.Cells[0, 0];
            cell1.Value = "템플릿 파일로드에 실패 했습니다.";

            Cell cell2 = worksheet.Cells[1, 0];
            cell2.Value = "PLCVerification_Template.xls 파일이 사용 중이거나 파일이 없습니다. ";

            Cell cell3 = worksheet.Cells[2, 0];
            cell3.Value = "프로세스 종료 후 다시 시도해주세요.";
        }

        private bool ExportVerificationReport(bool bExcel)
        {
            bool bOK = false;

            try
            {
                sheetVerification.Options.Save.CurrentFileName = "(" +
                                                                 CProjectManager.PLCTagS.GetFirst().PLCMaker.ToString() +
                                                                 ")PLCVerificationReport_" +
                                                                 DateTime.Now.ToString("yyyy-MM-dd");

                if (bExcel)
                    sheetVerification.SaveDocumentAs();
                else
                {
                    SaveFileDialog dlgSave = new SaveFileDialog {Filter = @"*.pdf|*.pdf"};
                    dlgSave.FileName = "(" + CProjectManager.PLCTagS.GetFirst().PLCMaker.ToString() +
                                       ")PLCVerificationReport_" + DateTime.Now.ToString("yyyy-MM-dd");
                    if (dlgSave.ShowDialog() == DialogResult.OK)
                        sheetVerification.ExportToPdf(dlgSave.FileName);
                }

                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export PLC Report", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private List<CStep> GetStepList(string sKey)
        {
            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cData = GetUsedLogicData(sKey);

            if (cData == null)
                return lstStep;

            CStep cStep;
            for (int i = 0; i < cData.StepS.Count; i++)
            {
                cStep = cData.StepS.ElementAt(i).Value;
                if(cStep.RefTagS.KeyList.Contains(sKey))
                    lstStep.Add(cStep);
            }

            return lstStep;
        }

        private void SetLadderStep(CStep cStep, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
                    return;

                CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.AutoScroll = false;
                ucStep.ScaleDefault = 1f; // 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel;
                ucStep.IsViewStep = bView;
                ucStep.StepName =
                    string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlLadderView.Controls.Add(ucStep);
                //this.Size = ucStep.Size;
            }
        }

        private CPlcLogicData GetUsedLogicData(string sKey)
        {
            CPlcLogicData cData = null;

            foreach (var who in CProjectManager.LogicDataS)
            {
                if (who.Value.TagS.ContainsKey(sKey))
                {
                    cData = who.Value;
                    break;
                }
            }

            return cData;
        }

        private CStep GetMasterStep(CTag cTag)
        {
            CStep cStep;


            FrmStepSelector frmStepSelector = new FrmStepSelector();
            frmStepSelector.Tag = cTag;
            if (frmStepSelector.ShowDialog() != DialogResult.OK)
                return null;

            cStep = frmStepSelector.GetSelectedStep();

            frmStepSelector.Dispose();
            frmStepSelector = null;

            return cStep;
        }

        private CStep GetSelectedCoilStep(CStep cStep, string sCoilKey)
        {
            CStep cNewStep = null;
            string sKey = string.Empty;
            CContactS cRelatedContactS = null;

            if (cStep.CoilS.Count == 1)
                return cStep;

            foreach (CCoil cCoil in cStep.CoilS)
            {
                if (!cCoil.RefTagS.ContainsKey(sCoilKey))
                    continue;

                m_lstUsedSymbolIndex.Clear();

                cNewStep = new CStep();
                cNewStep.CoilS.Add(cCoil);

                cNewStep.Program = cStep.Program;
                cNewStep.StepIndex = cStep.StepIndex;
                sKey = string.Format("{0}.{1}[{2}]", cNewStep.Program, cNewStep.StepIndex, cNewStep.CoilS.GetFirstCoil().StepIndex);
                cNewStep.Key = sKey;
                cNewStep.CoilS.GetFirstCoil().Step = sKey;

                cRelatedContactS = new CContactS();
                CreateNewStepRelation(cNewStep, cStep.ContactS, cRelatedContactS, sKey);
                UpdateUsedContactIndex(cNewStep);
            }

            return cNewStep;
        }

        private void CreateNewStepRelation(CStep cSplitStep, CContactS cContactS, CContactS cRelatedContactS, string sStepKey)
        {
            try
            {
                CCoil cCoil = cSplitStep.CoilS.GetFirstCoil();

                if (cCoil.Relation.PrevContactS.Count != 0)
                {
                    foreach (int PreCont in cCoil.Relation.PrevContactS)
                        CreateContactRelatedCoil(PreCont, cContactS, cRelatedContactS, sStepKey);
                }

                cSplitStep.ContactS.AddRange(cRelatedContactS);
                m_lstUsedSymbolIndex.Add(cCoil.StepIndex);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateContactRelatedCoil(int StepIndex, CContactS cContactS, CContactS cRelatedContactS, string sStepKey)
        {
            try
            {
                CContact cRelatedContact = null;

                foreach (CContact cContact in cContactS)
                {
                    if (cContact.StepIndex == StepIndex)
                    {
                        cRelatedContact = ContactClone(cContact, sStepKey);

                        if (!m_lstUsedSymbolIndex.Contains(cRelatedContact.StepIndex))
                        {
                            m_lstUsedSymbolIndex.Add(cContact.StepIndex);
                            cRelatedContactS.Add(cRelatedContact);
                        }

                        if (cRelatedContact.Relation.PrevContactS.Count != 0)
                        {
                            foreach (int PrevCont in cRelatedContact.Relation.PrevContactS)
                                CreateContactRelatedCoil(PrevCont, cContactS, cRelatedContactS, sStepKey);
                        }
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private CContact ContactClone(CContact cContact, string sStepKey)
        {
            CContact cRelatedContact = new CContact();

            cRelatedContact.ContactType = cContact.ContactType;
            cRelatedContact.ContentS = cContact.ContentS;
            cRelatedContact.Instruction = cContact.Instruction;
            cRelatedContact.IsInitial = cContact.IsInitial;
            cRelatedContact.Operator = cContact.Operator;
            cRelatedContact.RefTagS = cContact.RefTagS;

            cRelatedContact.Relation.PrevCoilS.AddRange(cContact.Relation.PrevCoilS);
            cRelatedContact.Relation.PrevContactS.AddRange(cContact.Relation.PrevContactS);
            cRelatedContact.Relation.NextCoilS.AddRange(cContact.Relation.NextCoilS);
            cRelatedContact.Relation.NextContactS.AddRange(cContact.Relation.NextContactS);

            cRelatedContact.Step = sStepKey;
            cRelatedContact.StepIndex = cContact.StepIndex;

            return cRelatedContact;
        }

        private void UpdateUsedContactIndex(CStep cSplitStep)
        {
            try
            {
                List<int> lstPreCont = new List<int>();

                foreach (int PrevCont in cSplitStep.CoilS.GetFirstCoil().Relation.PrevContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(PrevCont))
                        lstPreCont.Add(PrevCont);
                }

                cSplitStep.CoilS.GetFirstCoil().Relation.PrevContactS = lstPreCont;

                foreach (CContact cContact in cSplitStep.ContactS)
                    UpdateUsedContactIndex(cContact);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void UpdateUsedContactIndex(CContact cContact)
        {
            try
            {
                List<int> lstPreCont = new List<int>();
                List<int> lstNextCont = new List<int>();
                List<int> lstNextCoil = new List<int>();

                foreach (int PrevCont in cContact.Relation.PrevContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(PrevCont))
                        lstPreCont.Add(PrevCont);
                }
                cContact.Relation.PrevContactS = lstPreCont;

                foreach (int NextCont in cContact.Relation.NextContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(NextCont))
                        lstNextCont.Add(NextCont);
                }
                cContact.Relation.NextContactS = lstNextCont;

                foreach (int NextCoil in cContact.Relation.NextCoilS)
                {
                    if (m_lstUsedSymbolIndex.Contains(NextCoil))
                        lstNextCoil.Add(NextCoil);
                }
                cContact.Relation.NextCoilS = lstNextCoil;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            try
            {
                if (cTag == null) return;
                CStep cStep = GetMasterStep(cTag);

                if (cStep != null)
                {
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlLadderView.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep) pnlLadderView.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                            lstRemove.Add(ucView);
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.");
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                        pnlLadderView.Controls.Remove(lstRemove[i]);

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.ScaleDefault = 1f; // 0.6f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel + 1;
                    ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                    pnlLadderView.Controls.Add(ucStep);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("UEvent Selected Cell Data Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void VerifyReportTree()
        {
            if (CProjectManager.ReportElementS.Count == 0)
            {
                XtraMessageBox.Show("설정된 리포트 항목이 존재하지 않습니다.\r\n리포트 항목을 먼저 설정해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            if (
                XtraMessageBox.Show("설정하신 항목대로 리포트 트리를 생성하시겠습니까?", "Create Report Tree", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ucVerifyElemTree.ClearTree();
                ucVerifyElemTree.ShowReportTree();
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnClearVerifPLC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (
                    XtraMessageBox.Show("Are you sure to clear All PLC Tag Information?", "Information",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ClearPLC();
                }
                else
                    return;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Clear Verification PLC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAutoVerification_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.PLCTagS.Count == 0)
                {
                    XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    WriteToExcelReport();
                    LoadVerificationExceltoSheet(CProjectManager.VerifPathUser);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("AutoPLCVerification Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOptionAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //if (m_cVerifExport == null)
                //{
                //    XtraMessageBox.Show("Auto Verification First!!!", "Error", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //    return;
                //}

                //string sOption = string.Empty;

                //sOption = (string) txtOptionName.EditValue;

                //if (sOption == null)
                //{
                //    XtraMessageBox.Show("Input User Define Option Name!!", "Error", MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //    return;
                //}

                //if (sOption.Contains(" "))
                //    sOption = sOption.Replace(" ", "_");

                //SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                //{
                //    SetUserDefineExcelSheet(sOption);
                //}
                //SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Option Add Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnVerificationExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;
                
                if (CProjectManager.PLCTagS.Count == 0)
                {
                    XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = ExportVerificationReport(true);
                }
                SplashScreenManager.CloseForm(false);

                if(bOK)
                    XtraMessageBox.Show("Export Success!!", "Report Export", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Export Fail!!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("export Verification Excel Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnVerificationPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;

                if (CProjectManager.PLCTagS.Count == 0)
                {
                    XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = ExportVerificationReport(false);
                }
                SplashScreenManager.CloseForm(false);

                if (bOK)
                    XtraMessageBox.Show("Export Success!!", "Report Export", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Export Fail!!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Verification PDF Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grdVerifPLC_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (CProjectManager.VerifTagS.Count == 0)
                    return;

                int iRowHandle = grvVerifPLC.FocusedRowHandle;

                object obj = grvVerifPLC.GetRow(iRowHandle);

                if (obj.GetType() != typeof (CVerifTag))
                    return;

                CVerifTag cVerifTag = (CVerifTag) obj;
                CTag cTag = CProjectManager.PLCTagS[cVerifTag.Key];

                FrmStepSelector frmStepSelector = new FrmStepSelector();
                frmStepSelector.Tag = cTag;
                if (frmStepSelector.ShowDialog() != DialogResult.OK)
                    return;

                CStep cStep = frmStepSelector.GetSelectedStep();

                if (frmStepSelector.IsCoil)
                    cStep = GetSelectedCoilStep(cStep, cTag.Key);

                pnlLadderView.Controls.Clear();
                tabPLCVerif.SelectedTabPage = tpLadderView;
                SetLadderStep(cStep, 0, true);

                frmStepSelector.Dispose();
                frmStepSelector = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Verification PLC Step Select", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void btnClearLadderView_Click(object sender, EventArgs e)
        {
            pnlLadderView.Controls.Clear();
        }

        private void btnReportElemSetting_Click(object sender, EventArgs e)
        {
            if (CProjectManager.PLCTagS.Count == 0)
            {
                XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmReportElementSetting frmSetting = new FrmReportElementSetting();
            frmSetting.TopMost = true;
            frmSetting.UEvenetApplyClicked += FrmReportElementSetting_ApplyClick;

            frmSetting.Show();
        }

        private void FrmReportElementSetting_ApplyClick()
        {
            VerifyReportTree();
        }

        private void btnVerifSettingApply_Click(object sender, EventArgs e)
        {
            bool bOK = false;

            if (CProjectManager.PLCTagS.Count == 0)
            {
                XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CProjectManager.ReportElementS.Count == 0)
            {
                XtraMessageBox.Show("리포트 항목이 존재하지 않습니다.\r\n리포트 항목을 먼저 설정해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (
                XtraMessageBox.Show("설정하신 " + CProjectManager.ReportElementS.Count + "개의 리포트 항목을 추가하시겠습니까?",
                    "Report Element Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                bOK = SetUserDefineExcelSheet();
            }
            SplashScreenManager.CloseForm(false);

            tabPLCVerif2.SelectedTabPage = tpReport;
        }

        private void btnReportTreeClear_Click(object sender, EventArgs e)
        {
            if (CProjectManager.PLCTagS.Count == 0)
            {
                XtraMessageBox.Show("Import PLC Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (
                XtraMessageBox.Show("리포트 트리를 지우시겠습니까?", "Clear Report Tree", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                return;

            ucVerifyElemTree.ClearTree();
        }

        private void btnReportInit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("리포트를 초기화하시겠습니까?", "Report Initialize", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.No)
                return;

            LoadVerificationExceltoSheet(CProjectManager.VerifPath);
        }
    }
}
