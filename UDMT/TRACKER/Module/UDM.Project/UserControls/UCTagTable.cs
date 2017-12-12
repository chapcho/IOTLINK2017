using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class UCTagTable : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = true;
        protected CProject m_cProject = null;
        protected UCProjectManager m_ucManager = null;

        public event UEventHandlerTagTableInputTextRequest UEventInputTextRequest;

        public event UEventHandlerTagTableTagAdded UEventTagAdded;
        public event UEventHandlerTagTableTagRemoved UEventTagRemoved;
        public event UEventHandlerTagTableTagUpdated UEventTagUpdated;
        public event UEventHandlerTagTableTagDoubleClicked UEventTagDoubleClicked;

        protected bool m_bDragDropReady = false;

        #endregion


        #region Initialize/Dipsose
        
        public UCTagTable()
        {
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

        public UCProjectManager Manager
        {
            get { return m_ucManager; }
            set { m_ucManager = value; }
        }

        #endregion


        #region Public Methods

        public CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CTag)exGridView.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        cTagS.Add(cTag.Key, cTag);
                }
            }

            return cTagS;
        }

        public void ShowTable()
        {
            Clear();

            if (m_cProject == null || m_cProject.Name == "")
                return;

            if (m_cProject != null && m_cProject.GroupS != null)
            {
                for (int i = 0; i < m_cProject.GroupS.Count; i++)
                    exEditorGroupCombo.Items.Add(m_cProject.GroupS[i].Name);
            }

            exGridMain.BeginUpdate();
            {
                List<CTag> lstViewTagS = new List<CTag>();
                lstViewTagS.AddRange(m_cProject.TagS.Values);

                exGridMain.DataSource = lstViewTagS;
            }
            exGridMain.EndUpdate();
        }

		public void ShowTable(CTagS cTagS)
		{
			Clear();

			if (m_cProject == null || m_cProject.Name == "")
				return;

			if (m_cProject != null && m_cProject.GroupS != null)
			{
				for (int i = 0; i < m_cProject.GroupS.Count; i++)
					exEditorGroupCombo.Items.Add(m_cProject.GroupS[i].Name);
			}

			exGridMain.BeginUpdate();
			{
				List<CTag> lstViewTagS = new List<CTag>();
				lstViewTagS.AddRange(cTagS.Values);

				exGridMain.DataSource = lstViewTagS;
			}
			exGridMain.EndUpdate();
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

        protected void SetEditable(bool bEditable)
        {
            m_bEditable = bEditable; 
            exGridView.OptionsBehavior.ReadOnly = !bEditable; 
            exGridView.OptionsBehavior.Editable = bEditable; 
        }

        protected void SetProject(CProject cProject)
        {
            m_cProject = cProject; 
            ShowTable();
        }

        protected void GenerateTagAddEvent(CTagS cTagS)
        {
            if (UEventTagAdded != null)
                UEventTagAdded(this, cTagS);
        }

        protected void GenerateTagUpdateEvent(CTagS cTagS)
        {
            if (UEventTagUpdated != null)
                UEventTagUpdated(this, cTagS);
        }

        protected void GenerateTagRemoveEvent(CTagS cTagS)
        {
            if (UEventTagRemoved != null)
                UEventTagRemoved(this, cTagS);
        }

        protected void GenerateTagDoubleClickEvent(CTag cTag)
        {
            if (UEventTagDoubleClicked != null)
                UEventTagDoubleClicked(this, cTag);
        }

        #endregion


        #region Event Methods

        #region Form Event

        private void UCTagTable_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Menu Event

        private void mnuDeleteTagS_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            List<CTag> lstViewTag = (List<CTag>)exGridMain.DataSource;
            if (lstViewTag == null || lstViewTag.Count == 0)
                return;

            CTagS cTagS = GetSelectedTagS();
            if(cTagS == null || cTagS.Count == 0)
                return;

            exGridMain.BeginUpdate();
            {
                CTag cTag;
                for(int i=0;i<cTagS.Count;i++)
                {
                    cTag = cTagS[i];
                    if(cTag.Creator != "System")
                        m_cProject.TagS.Remove(cTag.Key);

                    lstViewTag.Remove(cTag);
                }
            }
            exGridMain.EndUpdate();

            GenerateTagRemoveEvent(cTagS);
        }

        private void mnuSelectColumn_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn exColumn = exGridView.FocusedColumn;
            int iCount = exGridView.RowCount;
            if (exColumn != null)
            {
                exGridMain.BeginUpdate();
                exGridView.SelectCells(0, exColumn, iCount - 1, exColumn);
                exGridMain.EndUpdate();
            }
        }

        private void mnuFillCellValue_Click(object sender, EventArgs e)
        {
            string sText = "";

            if (UEventInputTextRequest != null)
                sText = UEventInputTextRequest(this);

            GridCell[] arCells = exGridView.GetSelectedCells();
            if (arCells == null)
                return;

            exGridMain.BeginUpdate();
            {
                GridCell exCell;
                for (int i = 0; i < arCells.Length; i++)
                {
                    exCell = arCells[i];
                    if (exCell.Column.OptionsColumn.AllowEdit && exCell.Column.ColumnEdit == null)
                    {
                        exGridView.SetRowCellValue(exCell.RowHandle, exCell.Column, sText);
                    }
                }
            }
            exGridMain.EndUpdate();
        }

        #endregion

        #region Grid Event

        private void exGridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void exGridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if(e.Column == colGroup)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].GroupKey + ";";

                e.Value = sText;
            }
            else if(e.Column == colGroupRoleType)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;                
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].RoleType.ToString() + ";";
                
                e.Value = sText;
            }
            else if(e.Column == colStepRoleType)
            {
                if (e.Row == null)
                    return;

                CTag cTag = (CTag)e.Row;
                if (cTag.IsEndContact())
                    e.Value = "Contact";
                else
                    e.Value = "Coil";
            }
        }

        private void exGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                mnuDeleteTagS_Click(this, EventArgs.Empty);
            }
        }

        private void exGridView_DoubleClick(object sender, EventArgs e)
        {
            int iHandle = exGridView.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = exGridView.GetRow(iHandle);
            if ((oData.GetType() == typeof(CTag)))
                GenerateTagDoubleClickEvent((CTag)oData);                
        }

        private void exGridView_MouseDown(object sender, MouseEventArgs e)
        {
            m_bDragDropReady = false;

            GridView exView = sender as GridView;
            GridHitInfo exHitInfo = exView.CalcHitInfo(new Point(e.X, e.Y));
            if (exHitInfo.InColumnPanel)
                return;

            if (Control.ModifierKeys != Keys.None)
                return;

            m_bDragDropReady = true;
        }

        private void exGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_bDragDropReady)
            {
                CTagS cTagS = GetSelectedTagS();
                if (cTagS == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                exGridMain.DoDragDrop(cTagS, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void exGridMain_DragOver(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exGridMain_DragDrop(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            bool bUpdated = false;

            if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                if (cTagS != null)
                {
                    List<CTag> lstViewData = (List<CTag>)exGridMain.DataSource;

                    CTag cTag;
                    for (int i = 0; i < cTagS.Count; i++)
                    {
                        cTag = cTagS[i];
                        if (m_cProject.TagS.ContainsKey(cTag.Key) == false)
                        {
                            m_cProject.TagS.Add(cTag.Key, cTag);
                            lstViewData.Add(cTag);

                            bUpdated = true;
                        }
                    }

                    exGridMain.RefreshDataSource();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                }

                if (bUpdated)
                    GenerateTagAddEvent(cTagS);
            }
        }

        private void exGridView_ShownEditor(object sender, EventArgs e)
        {
            if (exGridView.FocusedColumn == colAddress)
            {
                TextEdit edit = exGridView.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void exGridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colGroup)
            {
                if (exGridView.IsFilterRow(e.RowHandle))
                    e.RepositoryItem = exEditorGroupCombo;
                else
                    e.RepositoryItem = null;
            }
            else if (e.Column == colGroupRoleType)
            {
                if (exGridView.IsFilterRow(e.RowHandle))
                    e.RepositoryItem = exEditorGroupRoleCombo;
                else
                    e.RepositoryItem = null;
            }
            else if(e.Column == colStepRoleType)
            {
                if (exGridView.IsFilterRow(e.RowHandle))
                    e.RepositoryItem = exEditorStepRoleCombo;
                else
                    e.RepositoryItem = null;
            }
        }

        #endregion
    
        #endregion

    }
}
