using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using UDM.Common;

namespace UDMPresenter
{
    public partial class UCTagTable : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = true;
		protected bool m_bDragDropReady = false;

		protected CTagS m_cTagS = null;

		public event UEventHandlerTagTableInputTextRequest UEventInputTextRequest;
		public event UEventHandlerTagTableTagAdded UEventTagAdded;
		public event UEventHandlerTagTableTagRemoved UEventTagRemoved;
		public event UEventHandlerTagTableTagUpdated UEventTagUpdated;
		public event UEventHandlerTagTableTagDoubleClicked UEventTagDoubleClicked;

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

		public DevExpress.XtraGrid.Columns.GridColumn ColKey
		{
			get { return colKey; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColAddress
		{
			get { return colAddress; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColDataType
		{
			get { return colDataType; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColDescription
		{
			get { return colDescription; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColSize
		{
			get { return colSize; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColChannel
		{
			get { return colChannel; }
		}

		public DevExpress.XtraGrid.Columns.GridColumn ColLogCount
		{
			get { return colLogCount; }
		}

		
        #endregion


        #region Public Methods

        public List<CTag> GetSelectedTagList()
        {
			List<CTag> lstTag = new List<CTag>();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CTag)exGridView.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        lstTag.Add(cTag);
                }
            }

            return lstTag;
        }

		public void ShowTable(CTagS cTagS)
		{
			Clear();

			exGridMain.BeginUpdate();
			{
				m_cTagS = cTagS;
                exGridMain.DataSource = cTagS.Select(x => x.Value).ToList();
			}
			exGridMain.EndUpdate();
		}


        public void Clear()
        {
            if (exEditorGroupCombo.Items.Count > 0)
            {
                exEditorGroupCombo.Items.Clear();
                exEditorGroupCombo.Items.Add("");
            }

            exGridMain.DataSource = null;
            exGridMain.RefreshDataSource();
        }

        public void SelectAll()
        {
            exGridView.SelectAll();
        }

        public void RefreshDataSource()
        {
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

        protected void GenerateTagAddEvent(List<CTag> lstTag)
        {
            if (UEventTagAdded != null)
				UEventTagAdded(this, lstTag);
        }

		protected void GenerateTagUpdateEvent(List<CTag> lstTag)
        {
            if (UEventTagUpdated != null)
				UEventTagUpdated(this, lstTag);
        }

		protected void GenerateTagRemoveEvent(List<CTag> lstTag)
        {
            if (UEventTagRemoved != null)
				UEventTagRemoved(this, lstTag);
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
            //if (m_bEditable == false)
            //    return;

            List<CTag> lstViewTag = (List<CTag>)exGridMain.DataSource;
            if (lstViewTag == null || lstViewTag.Count == 0)
                return;

            List<CTag> lstTag = GetSelectedTagList();
            if(lstTag == null || lstTag.Count == 0)
                return;

            exGridMain.BeginUpdate();
            {
                CTag cTag;
                for (int i = 0; i < lstTag.Count; i++)
                {
                    cTag = lstTag[i];
                    if (m_cTagS != null)
                        m_cTagS.Remove(cTag.Key);

                    lstViewTag.Remove(cTag);
                }
                if (UEventTagRemoved != null && lstTag.Count > 0)
                    UEventTagRemoved(sender, lstTag);
            }
            exGridMain.EndUpdate();

            GenerateTagRemoveEvent(lstTag);
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
            if (oData == null) return;
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
                List<CTag> lstTag = GetSelectedTagList();
                if (lstTag == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                exGridMain.DoDragDrop(lstTag, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void exGridMain_DragOver(object sender, DragEventArgs e)
        {
            if (m_bEditable == false)
                return;

            if (e.Data.GetDataPresent(typeof(List<CTag>)))
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

            if (e.Data != null && e.Data.GetDataPresent(typeof(List<CTag>)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
				List<CTag> lstTag = (List<CTag>)e.Data.GetData(typeof(List<CTag>));
                if (lstTag != null)
                {
                    List<CTag> lstViewData = (List<CTag>)exGridMain.DataSource;

                    CTag cTag;
                    for (int i = 0; i < lstTag.Count; i++)
                    {
                        cTag = lstTag[i];
                        if (m_cTagS.ContainsKey(cTag.Key) == false)
                        {
							m_cTagS.Add(cTag.Key, cTag);
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
                    GenerateTagAddEvent(lstTag);
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
           
        }

		private void exGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			CTag cTag = (CTag)exGridView.GetRow(e.RowHandle);
			if(cTag != null)
			{
				List<CTag> lstTag = new List<CTag>();
				lstTag.Add(cTag);

				GenerateTagUpdateEvent(lstTag);
			}
				
		}

        #endregion
    
        #endregion

    }
}
