using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using TrackerCommon;
using System.IO;
using UDM.UDLImport;
using UDM.Common;

namespace UDMPLCLogicAnalyzer
{
    public partial class FrmCompareLogicImport : DevExpress.XtraEditors.XtraForm
    {
        public FrmCompareLogicImport()
        {
            InitializeComponent();
        }

        private void FrmCompareLogicImport_Load(object sender, EventArgs e)
        {
            if (CProject.PLCLogicDataS.Count == 0)
            {
                this.Close();
                return;
            }
            rdgLogicList.Properties.Items.Clear();
            foreach (var who in CProject.PLCLogicDataS)
            {
                RadioGroupItem rdItem = new RadioGroupItem(who.Value, who.Key);
                rdgLogicList.Properties.Items.Add(rdItem);
            }
        }

        private void rdgLogicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = rdgLogicList.SelectedIndex;
            RadioGroupItem rdItem = rdgLogicList.Properties.Items.ElementAt(iSelectedIndex);

            exPropertyView.SelectedObject = null;
            exPropertyView.Refresh();
            
            if (CProject.LoogicSCompare1.ContainsKey(rdItem.Description))
            {
                //if (File.Exists(CProject.LoogicSCompare1[rdItem.Description].LogicFilePath) && File.Exists(CProject.LoogicSCompare1[rdItem.Description].SymbolFilePath))
                {
                    exPropertyView.SelectedObject = CProject.LoogicSCompare1[rdItem.Description];
                    exPropertyView.Refresh();
                }
                //CProject.LoogicSCompare1.Remove(rdItem.Description);
            }
            else
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                
                CPlcLogicData cBaseLogic = (CPlcLogicData)rdItem.Value;
                CPlcLogicData cLogic = ImportPLC(cBaseLogic.Maker, cBaseLogic.PlcChannel);
                
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                if (cLogic == null)
                    MessageBox.Show("Logic변환 실패");
                else
                {
                    cLogic.PLCID = cBaseLogic.PLCID;
                    cLogic.PlcName = cBaseLogic.PlcName;
                    cLogic.PlcChannel = cBaseLogic.PlcChannel;
                    CProject.LoogicSCompare1.Add(rdItem.Description, cLogic);
                }
            }
        }


        private CPlcLogicData ImportPLC(UDM.Common.EMPLCMaker emPLCMaker, string sChannel)
        {
            CUDLImport cLogic = new CUDLImport(emPLCMaker, false);
            CPlcLogicData cPlcLogicData = new CPlcLogicData();
            cPlcLogicData.Maker = emPLCMaker;
            if (emPLCMaker.Equals(EMPLCMaker.LS))
                cLogic.LsDDEAConnect = false;

            if (!cLogic.FileOpenCheck)
                return null;
            cLogic.Channel = sChannel;
            bool bOK = cLogic.UDLGenerate();

            if (!bOK)
            {
                XtraMessageBox.Show("Can't Convert Logic", "Import " + emPLCMaker.ToString() + " Logic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (emPLCMaker != EMPLCMaker.Siemens)
            {
                cPlcLogicData.TagS = cLogic.GlobalTags;
                cPlcLogicData.StepS = cLogic.StepS;
            }
            else
            {
                //cPlcLogicData.ConvertFilePath.AddRange(cLogic.FileOpenClass.AWLFile);
                //cPlcLogicData.ConvertFilePath.AddRange(cLogic.FileOpenClass.SDFFile);
                
                CTagS cTagS = GetUsedTagS(cLogic.GlobalTags, sChannel);
                if (cTagS == null)
                    return null;

                cPlcLogicData.TagS = cTagS;
                //m_cPlcLogicData.StepS = GetUsedStep(cLogic.StepS, m_cPlcLogicData.TagS);
                cPlcLogicData.StepS = cLogic.StepS;
            }

            if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensContactTimerConstant(cPlcLogicData);

            CStepExtract.SplitStepS(cPlcLogicData.StepS, cPlcLogicData.TagS);
            cPlcLogicData.Compose();

            // Contact 으로 쓰인 Timer, Counter에 상수 값 Setting
            //SetContactTimerCounterConstant();

            return cPlcLogicData;
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

                cTag.Channel = sChannel;

                if (cTag.Description == string.Empty)
                    cTag.Description = cTag.Name;
                else
                    cTag.Description = string.Format("{0} ({1})", cTag.Name, cTag.Description);

                cRetTagS.Add(cTag);
            }

            return cRetTagS;
        }

        private void SetSiemensContactTimerConstant(CPlcLogicData cPlcLogicData)
        {
            try
            {
                CStepS cContactStepS = new CStepS();
                CStep cContactStep = null;
                CContent cConstantContent = null;

                foreach (
                    CTag cTag in
                        cPlcLogicData.TagS.Values.Where(x => x.Address.StartsWith("T")))
                {
                    cContactStepS.Clear();
                    cContactStep = null;
                    cConstantContent = null;

                    if (cTag.StepRoleS != null && cTag.StepRoleS.Count > 0)
                    {
                        foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        {
                            if (cTagStepRole.RoleType == EMStepRoleType.Both ||
                                cTagStepRole.RoleType == EMStepRoleType.Coil)
                            {
                                if (!cPlcLogicData.StepS.ContainsKey(cTagStepRole.StepKey))
                                    continue;

                                CStep cCoilStep = cPlcLogicData.StepS[cTagStepRole.StepKey];
                                CCoil cCoil = GetCoil(cCoilStep.CoilS, cTag.Key);

                                if (cCoil == null) continue;

                                if (cCoil.ContentS != null && cCoil.ContentS.Count > 1)
                                    cConstantContent = cCoil.ContentS[1];

                                if (cTagStepRole.RoleType == EMStepRoleType.Both && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                                {
                                    cContactStep = cPlcLogicData.StepS[cTagStepRole.StepKey];
                                    cContactStepS.Add(cContactStep);
                                }
                            }
                            else if (cTagStepRole.RoleType == EMStepRoleType.Contact && !cContactStepS.ContainsKey(cTagStepRole.StepKey))
                            {
                                cContactStep = cPlcLogicData.StepS[cTagStepRole.StepKey];
                                cContactStepS.Add(cContactStep);
                            }
                        }
                    }

                    if (cConstantContent != null && cContactStepS.Count > 0)
                    {
                        foreach (CStep cStep in cContactStepS.Values)
                        {
                            foreach (CContact cContact in cStep.ContactS)
                            {
                                if (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF")
                                    || cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF"))
                                {
                                    foreach (CContent cContent in cContact.ContentS)
                                    {
                                        if (cContent.Tag != null && cContent.Tag == cTag)
                                        {
                                            cContact.ContentS.Add(cConstantContent);

                                            if (cConstantContent.Tag != null)
                                            {
                                                cContact.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                                cStep.RefTagS.Add(cConstantContent.Tag.Key, cConstantContent.Tag);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                cConstantContent = null;
                cContactStep = null;
                cContactStepS.Clear();
                cContactStepS = null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                ex.Data.Clear();
            }
        }

        private CCoil GetCoil(CCoilS cCoilS, string sTagKey)
        {
            CCoil cCoil = null;

            foreach (var who in cCoilS)
            {
                if (who.RefTagS.ContainsKey(sTagKey))
                {
                    cCoil = who;
                    break;
                }
            }

            return cCoil;
        }

        private void FrmCompareLogicImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool bCheck = true;
            string sMessage = "";
            foreach (var who in CProject.PLCLogicDataS)
            {
                if (CProject.LoogicSCompare1.ContainsKey(who.Key) == false)
                {
                    bCheck = false;
                    sMessage = who.Key;
                    break;
                }
            }

            if (bCheck == false)
            {
                MessageBox.Show("아직 처리되지 않은 PLC 로직이 있습니다. PLC : " + sMessage);
                e.Cancel = true;
            }

        }

    }

}