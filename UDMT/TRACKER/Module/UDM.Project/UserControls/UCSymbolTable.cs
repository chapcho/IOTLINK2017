using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


using UDM.Common;

namespace UDM.Project
{
    public partial class UCSymbolTable : UserControl
    {

        #region Member Variables

        protected CProject m_cProject = null;

        public event UEventHandlerSymbolTableRowDoubleClicked UEventSymbolDouleClicked;

        #endregion


        #region Intialize/Dispose

        public UCSymbolTable()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties


        public CProject Project
        {
            get { return m_cProject; }
            set { SetProject(value); }
        }

        #endregion


        #region Public Methods

        public void ShowTable()
        {
            Clear();

            if (m_cProject == null || m_cProject.Name == "")
                return;

			List<CTag> lstViewTag = new List<CTag>();
            
            if (m_cProject != null && m_cProject.GroupS != null)
            {
                CGroup cGroup;
                for (int i = 0; i < m_cProject.GroupS.Count; i++)
                {
                    cGroup = m_cProject.GroupS[i];
                    exEditorGroupCombo.Items.Add(cGroup.Name);
					
					CTagS cTotalTagS = cGroup.GetTotalTagS();
					for (int j = 0; j < cTotalTagS.Count; j++)
						lstViewTag.Add(cTotalTagS[j]);

					cTotalTagS.Clear();
                }
            }

            exGridMain.BeginUpdate();
            {
                exGridMain.DataSource = lstViewTag;
            }
            exGridMain.EndUpdate();
        }

        public CSymbolS GetSelectedSymbolS()
        {
            CSymbolS cSymbolS = new CSymbolS();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CSymbol cSymbol;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cSymbol = (CSymbol)exGridView.GetRow(iaRowIndex[i]);
                    if (cSymbol != null)
                        cSymbolS.Add(cSymbol);
                }
            }

            return cSymbolS;
        }

        public void Clear()
        {
            exEditorGroupCombo.Items.Clear();
            exEditorGroupCombo.Items.Add("");

            exGridMain.DataSource = null;
            exGridMain.RefreshDataSource();
        }

        #endregion


        #region Private Methods

        protected void SetProject(CProject cProject)
        {
            m_cProject = cProject;
            ShowTable();
        }

        protected void GenerateSymbolDoubleClickEvent(CSymbol cSymbol)
        {
            if (UEventSymbolDouleClicked != null)
                UEventSymbolDouleClicked(this, cSymbol);
        }

        #endregion


        #region Event Methods

        private void UCSymbolTable_Load(object sender, EventArgs e)
        {

        }

		private void exGridView_DoubleClick(object sender, EventArgs e)
		{
			int iHandle = exGridView.FocusedRowHandle;
			if (iHandle < 0)
				return;

			object oData = exGridView.GetRow(iHandle);
			if ((oData.GetType() == typeof(CSymbol)))
				GenerateSymbolDoubleClickEvent((CSymbol)oData);
		}

		private void exGridView_ShownEditor(object sender, EventArgs e)
		{
			if (exGridView.FocusedColumn == colAddress)
			{
				TextEdit edit = exGridView.ActiveEditor as TextEdit;
				edit.Properties.CharacterCasing = CharacterCasing.Upper;
			}
		}

        #endregion
    }
}
