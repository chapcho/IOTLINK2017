using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using UDM.General.Serialize;
using UDM.Common;

namespace UDM.Project
{
    public partial class UCProjectManager : Component
    {

        #region Member Variables

        protected bool m_bEditable = true;

        protected CProject m_cProject = new CProject();

        protected UCGroupTree m_ucGroupTree = null;
        protected UCTagTable m_ucTagTable = null;

        public event UEventHandlerProjectCreated UEventProjectCreated;
        public event UEventHandlerProjectOpened UEventProjectOpened;
        public event UEventHandlerProjectSaved UEventProjectSaved;
        public event UEventHandlerProjectCleared UEventProjectCleared;

        #endregion


        #region Initialize/Dispose

        public UCProjectManager()
        {
            InitializeComponent();
        }

        public UCProjectManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { SetEditable(value); }
        }

        public CProject Project
        {
            get { return m_cProject; }
            set { SetProject(value); }
        }

        public UCGroupTree GroupTreeView
        {
            get { return m_ucGroupTree; }
            set { SetGroupTreeView(value); }
        }

        public UCTagTable TagTableView
        {
            get { return m_ucTagTable; }
            set { SetTagTableView(value); }
        }

        #endregion


        #region Public Methods

        public void Create(string sName)
        {
            m_cProject.Name = sName;

            GenerateProjectCreateEvent();
        }

        public bool Open(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CProject cProject = (CProject)(cSerializer.Read(sPath));
            if (cProject != null)
            {
                cProject.Path = sPath;
                m_cProject = cProject;
                m_cProject.Compose();

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            GenerateProjectOpenEvent();

            return bOK;
        }

        public bool Save(string sPath)
        {
            bool bOK = true;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cProject);
            m_cProject.Path = sPath;

            cSerializer.Dispose();
            cSerializer = null;

            GenerateProjectSaveEvent();

            return bOK;
        }        

        public void Clear()
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.Clear();

            if (m_ucTagTable != null)
                m_ucTagTable.Clear();

            if (m_cProject != null)
                m_cProject.Clear();

            GenerateProjectClearEvent();
        }

        public void Refresh()
        {
            m_ucGroupTree.Project = m_cProject;
            m_ucTagTable.Project = m_cProject;

            m_ucTagTable.ShowTable();
            m_ucGroupTree.ShowTree();
        }

        internal CTagS GetSelectedTagS()
        {
            CTagS cTagS = null;
            if (m_ucTagTable != null)
                cTagS = m_ucTagTable.GetSelectedTagS();

            return cTagS;
        }

        #endregion


        #region Private Methods

        protected void SetProject(CProject cProject)
        {
            Clear();
            m_cProject = cProject;
        }

        protected void SetEditable(bool bEditable)
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.Editable = bEditable;

            if (m_ucTagTable != null)
                m_ucTagTable.Editable = bEditable;
        }

        protected void SetGroupTreeView(UCGroupTree ucTreeView)
        {
            if (m_ucGroupTree != null)
            {
                m_ucGroupTree.UEventSymbolAdded -= new UEventHandlerGroupTreeSymbolAdded(m_ucGroupTree_UEventSymbolAdded);
                m_ucGroupTree.UEventSymbolUpdated -= new UEventHandlerGroupTreeSymbolUpdated(m_ucGroupTree_UEventSymbolUpdated);
                m_ucGroupTree.UEventSymbolRemoved -= new UEventHandlerGroupTreeSymbolRemoved(m_ucGroupTree_UEventSymbolRemoved);
                m_ucGroupTree = null;
            }

            m_ucGroupTree = ucTreeView;
            if (m_ucGroupTree != null)
            {
                m_ucGroupTree.Manager = this;
                m_ucGroupTree.UEventSymbolAdded += new UEventHandlerGroupTreeSymbolAdded(m_ucGroupTree_UEventSymbolAdded);
                m_ucGroupTree.UEventSymbolUpdated += new UEventHandlerGroupTreeSymbolUpdated(m_ucGroupTree_UEventSymbolUpdated);
                m_ucGroupTree.UEventSymbolRemoved += new UEventHandlerGroupTreeSymbolRemoved(m_ucGroupTree_UEventSymbolRemoved);
            }
        }

        protected void SetTagTableView(UCTagTable ucTagTable)
        {
            if (m_ucTagTable != null)
            {
                m_ucTagTable.UEventTagAdded -= new UEventHandlerTagTableTagAdded(m_ucTagTable_UEventTagAdded);
                m_ucTagTable.UEventTagUpdated -= new UEventHandlerTagTableTagUpdated(m_ucTagTable_UEventTagUpdated);
                m_ucTagTable.UEventTagRemoved -= new UEventHandlerTagTableTagRemoved(m_ucTagTable_UEventTagRemoved);
                m_ucTagTable = null;
            }

            m_ucTagTable = ucTagTable;
            if (m_ucTagTable != null)
            {
                m_ucTagTable.UEventTagAdded += new UEventHandlerTagTableTagAdded(m_ucTagTable_UEventTagAdded);
                m_ucTagTable.UEventTagUpdated += new UEventHandlerTagTableTagUpdated(m_ucTagTable_UEventTagUpdated);
                m_ucTagTable.UEventTagRemoved += new UEventHandlerTagTableTagRemoved(m_ucTagTable_UEventTagRemoved);
            }
        }        

        private void GenerateProjectCreateEvent()
        {
            if (UEventProjectCreated != null)
                UEventProjectCreated(this);
        }

        private void GenerateProjectOpenEvent()
        {
            if (UEventProjectOpened != null)
                UEventProjectOpened(this);
        }

        private void GenerateProjectSaveEvent()
        {
            if (UEventProjectSaved != null)
                UEventProjectSaved(this);
        }

        private void GenerateProjectClearEvent()
        {
            if (UEventProjectCleared != null)
                UEventProjectCleared(this);
        }

        #endregion


        #region Event Methods

        #region Group Tree Event

        private void m_ucGroupTree_UEventSymbolAdded(object sender, string sGroup, CSymbolS cSymbolS)
        {

        }

        private void m_ucGroupTree_UEventSymbolUpdated(object sender, string sGroup, CSymbolS cSymbolS)
        {
            if (m_ucTagTable != null)
                m_ucTagTable.ShowTable();
        }

        private void m_ucGroupTree_UEventSymbolRemoved(object sender, string sGroup, CSymbolS cSymbolS)
        {

        }

        #endregion

        #region Tag Table Event

        private void m_ucTagTable_UEventTagAdded(object sender, CTagS cTagS)
        {

        }

        private void m_ucTagTable_UEventTagUpdated(object sender, CTagS cTagS)
        {

        }

        private void m_ucTagTable_UEventTagRemoved(object sender, CTagS cTagS)
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.RemoveAllSymbolS(cTagS);
        }

        #endregion

        #endregion
    }
}
