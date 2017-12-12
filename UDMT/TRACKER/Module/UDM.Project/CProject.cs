using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Flow;

using UDM.Monitor.Plc.Source.OPC;
using UDM.LogicViewer;
using UDM.Monitor.Plc.Source.LS;
using UDM.DDEA;
using UDM.Monitor.Plc.Source;

namespace UDM.Project
{
    [Serializable]
    public class CProject : IDisposable
    {
        
        #region Member Varaiables

        protected bool m_bEditable = true;
        protected bool m_bPlcMakerFix = false;
        protected string m_sName = "";
        protected string m_sPath = "";
        protected EMPLCMaker m_emPlcMaker = EMPLCMaker.LS;
        protected EMSourceType m_emCollectType = EMSourceType.DDEA;
        protected CSymbolS m_cSymbolS = new CSymbolS();
        protected CGroupS m_cGroupS = new CGroupS();
        protected CLsConfig m_cLsConfig = new CLsConfig();
        protected CDDEAConfigMS m_cMelsecConfig = new CDDEAConfigMS();
        protected COPCConfig m_cOPCConfig = new COPCConfig();
        protected CMasterPatternS m_cMasterPatternS = new CMasterPatternS();
        protected CStepS m_cStepS = new CStepS();
        protected CTagS m_cTagS = new CTagS();

        protected EMMonitorModeType m_emPatternItemStep = EMMonitorModeType.None;
        protected EMMonitorModeType m_emMasterPatternStep = EMMonitorModeType.None;

        #endregion


        #region Initialize/Dispose

        public CProject()
        {

        }

        public CProject(string sName)
        {
            m_sName = sName;
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }

        public bool PLCMakerFix
        {
            get { return m_bPlcMakerFix; }
            set { m_bPlcMakerFix = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Path
        {
            get { return m_sPath; }
            set { m_sPath = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPlcMaker; }
            set { m_emPlcMaker = value; }
        }

        public EMSourceType CollectType
        {
            get { return m_emCollectType; }
            set { m_emCollectType = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        public CGroupS GroupS
        {
            get { return m_cGroupS; }
            set { m_cGroupS = value; }
        }

        public CMasterPatternS MasterPatternS
        {
            get { return m_cMasterPatternS; }
            set { m_cMasterPatternS = value; }
        }

        public COPCConfig OPCConfig
        {
            get { return m_cOPCConfig; }
            set { m_cOPCConfig = value; }
        }

        public CDDEAConfigMS MelsecConfig
        {
            get { return m_cMelsecConfig; }
            set { m_cMelsecConfig = value; }
        }

        public CLsConfig LsConfig
        {
            get { return m_cLsConfig; }
            set { m_cLsConfig = value; }
        }

        public EMMonitorModeType PatternItemStep
        {
            get { return m_emPatternItemStep; }
            set { m_emPatternItemStep = value; }
        }

        public EMMonitorModeType MasterPatternStep
        {
            get { return m_emMasterPatternStep; }
            set { m_emMasterPatternStep = value; }
        }

        #endregion


        #region Public Methods


        #region Layout

        public void Clear()
        {
            if (m_cGroupS != null)
                m_cGroupS.Clear();
            else
                m_cGroupS = new CGroupS();

            if (m_cSymbolS != null)
                m_cSymbolS.Clear();
            else
                m_cSymbolS = new CSymbolS();

            if (m_cMasterPatternS != null)
                m_cMasterPatternS.Clear();
            else
                m_cMasterPatternS = new CMasterPatternS();

            if (m_cTagS != null)
                m_cTagS.Clear();
            else
                m_cTagS = new CTagS();

            if (m_cStepS != null)
                m_cStepS.Clear();
            else
                m_cStepS = new CStepS();
        }

        public void Compose()
        {
            if (m_cStepS == null || m_cTagS == null)
                return;

            m_cStepS.Compose(m_cTagS);
            m_cStepS.ComposeTagRoleS();

            string sGroupKey = "";
            CGroup cGroup;
            for (int i = 0; i < m_cGroupS.Count; i++)
            {
                cGroup = m_cGroupS[i];
                sGroupKey = cGroup.Key;
                cGroup.Key = sGroupKey;
                if (cGroup.Recipe == null)
                {
                    cGroup.Recipe = new CSymbol();
                    cGroup.Recipe.Key = "[RCP]" + cGroup.Key;
                    cGroup.Recipe.GroupKey = cGroup.Key;
                }

                if (cGroup.Product == null)
                {
                    cGroup.Product = new CSymbol();
                    cGroup.Product.Key = "[PRD]" + cGroup.Key;
                    cGroup.Product.GroupKey = cGroup.Key;
                }
            }
        }

        #endregion

        #region Step

        public List<CStep> GetStepList(string sKey)
        {
            List<CStep> lstStep = new List<CStep>();

            CStep cStep;
            for (int i = 0; i < m_cStepS.Count; i++)
            {
                cStep = m_cStepS.ElementAt(i).Value;
                if (cStep.RefTagS.KeyList.Contains(sKey))
                {
                    lstStep.Add(cStep);
                }
            }

            return lstStep;
        }

        public List<CStep> GetCoilStepList(CTag cTag)
        {
            List<CStep> lstStep = new List<CStep>();

            CStep cStep;
            CTagStepRole cRole;
            for(int i=0;i<cTag.StepRoleS.Count;i++)
            {
                cRole = cTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (m_cStepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = m_cStepS[cRole.StepKey];
                        lstStep.Add(cStep);
                    }
                }
            }

            return lstStep;
        }

        public List<CStep> GetEndCoilStepList()
        {
            List<CStep> lstStep = new List<CStep>();

            CStep cStep;
            CCoil cCoil;
            CTag cTag;
            for (int i = 0; i < m_cStepS.Count; i++)
            {
                cStep = m_cStepS.ElementAt(i).Value;
                if (cStep.CoilS.Count == 1)
                {
                    cCoil = cStep.CoilS[0];
                    if (cCoil.ContentS.Count == 1)
                    {
                        cTag = cCoil.ContentS[0].Tag;
                        if (cTag != null && cTag.IsEndCoil())
                            lstStep.Add(cStep);
                    }
                }
            }

            return lstStep;
        }

        #endregion

        #region Tag

        public CTag GetTag(string sAddress)
        {
            if (m_cTagS == null || m_cTagS.Count == 0)
                return null;

            CTag cTargetTag = null;
            CTag cTag;
            for (int i = 0; i < m_cTagS.Count; i++)
            {
                cTag = m_cTagS.ElementAt(i).Value;
                if (cTag.Address == sAddress)
                {
                    cTargetTag = cTag;
                    break;
                }
            }

            return cTargetTag;
        }

        public List<CTag> GetTagList(List<CStep> lstStep)
        {
            List<CTag> lstTag = new List<CTag>();

            CStep cStep;
            CTag cTag;
            for(int i=0;i<lstStep.Count;i++)
            {
                cStep = lstStep[i];
                for(int j=0;j<cStep.RefTagS.Count;j++)
                {
                    cTag = cStep.RefTagS[j];
                    if (lstTag.Contains(cTag) == false)
                        lstTag.Add(cTag);
                }
            }

            return lstTag;
        }

        public List<CTag> GetSubTagList(string sAddress, int iDepth)
        {
            if (m_cTagS == null || m_cTagS.Count == 0)
                return null;

            CTag cTag = GetTag(sAddress);
            if (cTag == null)
                return null;
            
            List<CStep> lstStep = GetCoilStepList(cTag);
            List<CTag> lstTag = GetTagList(lstStep);
            List<CStep> lstTotalStep = new List<CStep>();
            List<CTag> lstTotalTag = new List<CTag>();
            lstTotalStep.AddRange(lstStep);
            lstTotalTag.AddRange(lstTag);

            CStep cStep;
            List<CStep> lstAddedStep;
            int iTraceDepth = 0;
            while(iDepth > iTraceDepth)
            {
                lstAddedStep = new List<CStep>();
                for (int i = 0; i < lstStep.Count;i++ )
                {
                    cStep = lstStep[i];
                    if(lstTotalStep.Contains(cStep) == false)
                    {
                        lstAddedStep.Add(cStep);
                        lstTotalStep.Add(cStep);
                        for(int j=0;j<cStep.RefTagS.Count;j++)
                        {
                            cTag = cStep.RefTagS[j];
                            if (lstTotalTag.Contains(cTag) == false)
                                lstTotalTag.Add(cTag);
                        }
                    }
                }

                lstStep.Clear();
                lstStep = lstAddedStep;

                iTraceDepth += 1;
            }

            if (lstTag != null)
                lstTag.Clear();

            if (lstStep != null)
                lstStep.Clear();

            if(lstTotalStep != null)
                lstTotalStep.Clear();

            return lstTotalTag;
        }

        public List<CTag> GetEndContactList(CTag cBaseTag, EMDataType emDataType)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<CTag> lstTotalTag = new List<CTag>();

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseTag.StepRoleS.Count; i++)
            {
                cRole = cBaseTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (m_cStepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = m_cStepS[cRole.StepKey];
                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            TraceEndContact(lstTotalStep, lstTotalTag, cStep, emDataType);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTag;
        }

        #endregion


        #endregion


        #region Private Methods

        #region Step

        private List<CStep> GetSubStepList(List<CTag> lstTag, List<CStep> lstExitsStep)
        {
            List<CStep> lstTotalStep = new List<CStep>();

            CTag cTag;
            CStep cStep;
            List<CStep> lstStep;
            for(int i=0;i<lstTag.Count;i++)
            {
                cTag = lstTag[i];

                lstStep = GetCoilStepList(cTag);
                for(int j=0;j<lstStep.Count;j++)
                {
                    cStep = lstStep[j];
                    if (lstExitsStep.Contains(cStep) == false)
                        lstTotalStep.Add(cStep);
                }

                lstStep.Clear();
            }

            return lstTotalStep;
        }

        #endregion

        #region Tag

        private void TraceEndContact(List<CStep> lstTotalStep, List<CTag> lstTotalTag, CStep cBaseStep, EMDataType emDataType)
        {   
            CTag cTag;
            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
            {
                cTag = cBaseStep.RefTagS[i];
                if (cTag.DataType == emDataType && cTag.IsEndContact() )
                {
                    if(lstTotalTag.Contains(cTag) == false)
                        lstTotalTag.Add(cTag);
                }
                else
                {   
                    for(int j=0;j<cTag.StepRoleS.Count;j++)
                    {
                        cRole = cTag.StepRoleS[j];
                        if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                        {
                            if (m_cStepS.ContainsKey(cRole.StepKey))
                            {
                                cStep = m_cStepS[cRole.StepKey];
                                if (lstTotalStep.Contains(cStep) == false)
                                {
                                    lstTotalStep.Add(cStep);
                                    TraceEndContact(lstTotalStep, lstTotalTag, cStep, emDataType);
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<CTag> GetAddressList(List<CTag> lstTag)
        {
            List<CStep> lstStep = new List<CStep>();
            List<CTag> lstTagFinded = new List<CTag>();

            CStep cStep;
            CCoil cCoil;
            for (int i = 0; i < m_cStepS.Count; i++)
            {
                cStep = m_cStepS.ElementAt(i).Value;
                if (cStep.CoilS.Count > 0)
                {
                    cCoil = cStep.CoilS[0];
                    foreach (CContent cContent in cCoil.ContentS)
                    {
                        if (cContent.ArgumentType == EMArgumentType.Tag)
                        {
                            if (cContent.Tag != null && lstTag.Contains(cContent.Tag))
                            {
                                for (int itag = 0; itag < cStep.RefTagS.Count; itag++)
                                {
                                    if (!lstTagFinded.Contains(cStep.RefTagS.GetValueAt(itag)))
                                        lstTagFinded.Add(cStep.RefTagS.GetValueAt(itag));
                                }
                            }
                        }
                    }
                }
            }

            return lstTagFinded;
        }

        #endregion

        #endregion

    }
}
