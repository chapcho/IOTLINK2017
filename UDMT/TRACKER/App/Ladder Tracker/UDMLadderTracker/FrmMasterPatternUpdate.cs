using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;
using TrackerCommon;

namespace UDMLadderTracker
{
    public partial class FrmMasterPatternUpdate : DevExpress.XtraEditors.XtraForm
    {
        private CMySqlLogReader m_cReader = null;
        private CCyclePresentOption m_cKeyOption = new CCyclePresentOption();
        private CCyclePresentOption m_cSubKeyOption = new CCyclePresentOption();
        private bool m_bMasterPatternOK = false;

        private string m_sCaption = string.Empty;
        private string m_sDescription = string.Empty;

        public FrmMasterPatternUpdate()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;

            if (m_cReader.IsConnected == false)
                m_cReader.Connect();
        }

        public bool MasterPastternOK
        {
            get { return m_bMasterPatternOK; }
            set { m_bMasterPatternOK = value; }
        }

        public void SetCaption(string caption)
        {
            m_sCaption = caption;
        }

        public void SetDescription(string description)
        {
            m_sDescription = description;
        }


        private void UpdateAbnormalSymbol()
        {
            //List<string> lstSymbolKey = null;
            //CTimeLogS cLogS = null;

            //foreach (var who in CMultiProject.PlcProcS)
            //{
            //    lstSymbolKey = who.Value.AbnormalSymbolS.GetAbnormalSymbolFirstSubDepthKeyList();

            //    foreach (string sKey in lstSymbolKey)
            //    {
            //        cLogS = m_cReader.GetTimeLogS(sKey);

            //        int iOnLogCount = cLogS.Where(x => x.Value == 1).Count();
            //        int iOffLogCount = cLogS.Where(x => x.Value == 0).Count();

            //        if(iOnLogCount >= 1 && iOffLogCount >= 1)
            //            who.Value.AbnormalSymbolS.RemoveSymbol(sKey);
            //    }

            //}
        }

        private bool CreateMasterPatternS()
        {
            bool bOK = true;
            CMasterPatternS cMasterPatternS = new CMasterPatternS();
            CFlowRule cFlowRule = new CFlowRule();

            cMasterPatternS.Rule = cFlowRule;

            CPlcProc cProcess;
            CMasterPattern cMasterPattern;

            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;
                cMasterPattern = CreateMasterPattern(cProcess, cFlowRule);

                if (cMasterPattern != null)
                    cMasterPatternS.Add(cProcess.Name, cMasterPattern);
                else
                {
                    MessageBox.Show(cProcess.Name + " 의 Flow Chart가 생성되지 않았습니다.\r\nCycle 수집을 더 진행해주세요.", "Warning!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bOK = false;
                    break;
                }
            }

            if (cMasterPatternS.Count == CMultiProject.PlcProcS.Count)
            {
                CMultiProject.MasterPatternS = cMasterPatternS;
                bOK = true;
            }

            return bOK;
        }

        private CMasterPattern CreateMasterPattern(CPlcProc cProcess, CFlowRule cRule)
        {
            CMasterPattern cMasterPattern = null;
            CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, cProcess.Name);

            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return null;

            UpdateKeySymbolS(cProcess, cCycleInfoS);

            cMasterPattern = new CMasterPattern();
            cMasterPattern.Key = cProcess.Name;

            CCycleInfo cInfo;
            CFlowItemS cItemS;
            CFlowItem cItem;
            CTimeNode cNode;

            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                bool bTimeNodeNone = false;

                if(i == 0)
                    continue;

                cInfo = cCycleInfoS.ElementAt(i).Value;

                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cProcess.Name, cProcess.KeySymbolS, cInfo, true);

                if (cItemS == null)
                    continue;

                for (int j = 0; j < cItemS.Count; j++)
                {
                    cItem = cItemS[j];

                    if (cItem.TimeNodeS.Count == 0)
                    {
                        bTimeNodeNone = true;
                        break;
                    }

                    for (int k = 0; k < cItem.TimeNodeS.Count; k++)
                    {
                        cNode = cItem.TimeNodeS[k];
                        cNode.IsEnd = true;
                        cNode.IsStart = true;
                    }
                }

                if (bTimeNodeNone)
                    continue;

                cMasterPattern.Update(cInfo.CurrentRecipe, cItemS, cRule);
            }

            cMasterPattern.FinalizeLinkS();

            return cMasterPattern;
        }

        private void UpdateEndSubDepthSymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateEndSubDepthSymbolCyclePresentResultS(cProcess, cCycleInfoS);
            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cSubKeyOption) == false)
                    RemoveEndSubDepthSymbol(cProcess, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private CCyclePresentResultS CreateEndSubDepthSymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return null;

            //  End SubDepth Key 심볼 만
            CKeySymbol cSymbol;
            CTagS cTempCandiTagS = new CTagS();
            CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                cSymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                cTempCandiTagS.AddRange(cSymbol.SubDepthTagList);
            }

            foreach (var who in cTempCandiTagS)
            {
                if (!cCandiTagS.ContainsKey(who.Key))
                    cCandiTagS.Add(who.Value);
            }

            CCyclePresentResultS cResultS = new CCyclePresentResultS(cCandiTagS);
            TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;
                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue)
                    continue;

                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                tsSpan = cInfo.CycleEnd.Subtract(cInfo.CycleStart);
                //if (tsSpan.TotalMilliseconds > cProcess.MaxTactTime)
                    //continue;

                UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);
            }

            return cResultS;
        }

        private void RemoveEndSubDepthSymbol(CPlcProc cProcess, CTag cTag)
        {
            cProcess.RemoveEndSubDepthSymbolS(cTag);
        }

        private void UpdateKeySymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateKeySymbolCyclePresentResultS(cProcess, cCycleInfoS);

            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if(!cResult.IsRegular(m_cKeyOption))
                    RemoveKeySymbol(cProcess, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private CCyclePresentResultS CreateKeySymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            CCyclePresentResultS cResultS = null;

            CKeySymbol cKeySymbol;
            CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                cKeySymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                if(cKeySymbol.Tag.IsEndContact() == false && cKeySymbol.Tag.DataType == EMDataType.Bool)
                    cCandiTagS.Add(cKeySymbol.Tag);
            }

            cResultS = new CCyclePresentResultS(cCandiTagS);
            TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;

                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue)
                    continue;

                if(cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                if(cInfo.CurrentRecipe != string.Empty)
                    UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);

            }
            return cResultS;
        }

        private void UpdateCyclePresentResultS(CTagS cTagS, CCycleInfo cCycleInfo, CCyclePresentResultS cResultS)
        {
            List<string> lstKey = cTagS.Keys.ToList();
            CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstKey, cCycleInfo.CycleStart, cCycleInfo.CycleEnd);
            if (cTotalLogS == null || cTotalLogS.Count == 0)
                return;

            CTimeLogS cLogS;
            CTag cTag;
            CCyclePresentResult cResult;
            for (int i = 0; i < cTagS.Count; i++)
            {
                cTag = cTagS[i];
                cResult = cResultS[cTag.Key];

                cLogS = cTotalLogS.GetTimeLogS(cTag.Key);
                if (cLogS == null)
                    cLogS = new CTimeLogS();

                cResultS.UpdatePresentResult(cCycleInfo.CurrentRecipe, cTag.Key, cLogS);

                cLogS.Clear();
                cLogS = null;
            }

            cTotalLogS.Clear();
            cTotalLogS = null;

            cResultS.TotalCycleCount += 1;
        }

        private void RemoveKeySymbol(CPlcProc cProcess, CTag cTag)
        {
            if (cProcess.KeySymbolS.ContainsKey(cTag.Key))
                cProcess.RemoveAllSymbolS(cTag.Key);
        }


        private void UpdateSubSymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateSubSymbolCyclePresentResultS(cProcess, cCycleInfoS);
            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cSubKeyOption) == false)
                    RemoveSubSymbol(cProcess, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private CCyclePresentResultS CreateSubSymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return null;

            //  SubKey 심볼 만
            CKeySymbol cSymbol;
            CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                cSymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                cCandiTagS.AddRange(cSymbol.FirstTagList);
            }

            CCyclePresentResultS cResultS = new CCyclePresentResultS(cCandiTagS);
            TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;
                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue)
                    continue;

                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                tsSpan = cInfo.CycleEnd.Subtract(cInfo.CycleStart);
                //if (tsSpan.TotalMilliseconds > cProcess.MaxTactTime)
                   // continue;

                UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);
            }

            return cResultS;
        }

        private void RemoveSubSymbol(CPlcProc cProcess, CTag cTag)
        {
            cProcess.RemoveSubSymbolS(cTag);
        }

        private void ShowEditMasterPattern()
        {
            FrmMasterPatternEditor frmEditor = new FrmMasterPatternEditor();
            frmEditor.TopMost = true;
            frmEditor.Show();
        }

        private void FrmMasterPatternUpdate_Load(object sender, EventArgs e)
        {
                if (CreateMasterPatternS())
                    m_bMasterPatternOK = true;
                else
                    m_bMasterPatternOK = false;

            //KeySymbol Sort
                //ShowEditMasterPattern();

            this.Close();
        }
    }
}