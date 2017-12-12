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

namespace UDMEnergyViewer
{
    public partial class UCSymbolTable : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = true;
		protected bool m_bDragDropReady = false;
        protected List<string> m_lstUserAddSymbol = new List<string>();
		protected CSymbolS m_cSymbolS = null;

		public event UEventHandlerSymbolTableInputTextRequest UEventInputTextRequest;
		public event UEventHandlerSymbolTableSymbolAdded UEventSymbolAdded;
		public event UEventHandlerSymbolTableSymbolRemoved UEventSymbolRemoved;
		public event UEventHandlerSymbolTableSymbolUpdated UEventSymbolUpdated;
		public event UEventHandlerSymbolTableSymbolDoubleClicked UEventSymbolDoubleClicked;

        #endregion


        #region Initialize/Dipsose
        
        public UCSymbolTable()
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

        public List<string> UserAddSymbolList
        {
            get { return m_lstUserAddSymbol; }
            set { m_lstUserAddSymbol = value; }
        }

        #endregion


        #region Public Methods

        public List<CSymbol> GetSelectedSymbolList()
        {
			List<CSymbol> lstSymbol = new List<CSymbol>();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CSymbol cSymbol;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cSymbol = (CSymbol)exGridView.GetRow(iaRowIndex[i]);
                    if (cSymbol != null)
                        lstSymbol.Add(cSymbol);
                }
            }

            return lstSymbol;
        }

		public void ShowTable(CSymbolS cSymbolS)
		{
			Clear();

			exGridMain.BeginUpdate();
			{
				m_cSymbolS = cSymbolS;

				List<CSymbol> lstViewSymbolS = new List<CSymbol>();
				lstViewSymbolS.AddRange(cSymbolS.Values);

				exGridMain.DataSource = lstViewSymbolS;
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

        protected void GenerateSymbolAddEvent(List<CSymbol> lstSymbol)
        {
            if (UEventSymbolAdded != null)
				UEventSymbolAdded(this, lstSymbol);
        }

		protected void GenerateSymbolUpdateEvent(List<CSymbol> lstSymbol)
        {
            if (UEventSymbolUpdated != null)
				UEventSymbolUpdated(this, lstSymbol);
        }

		protected void GenerateSymbolRemoveEvent(List<CSymbol> lstSymbol)
        {
            if (UEventSymbolRemoved != null)
				UEventSymbolRemoved(this, lstSymbol);
        }

		protected void GenerateSymbolDoubleClickEvent(CSymbol cSymbol)
        {
            if (UEventSymbolDoubleClicked != null)
				UEventSymbolDoubleClicked(this, cSymbol);
        }

        #endregion


        #region Event Methods

        #region Form Event

        private void UCSymbolTable_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Menu Event

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            if (m_bEditable == false)
                return;

            List<CSymbol> lstViewSymbol = (List<CSymbol>)exGridMain.DataSource;
            if (lstViewSymbol == null || lstViewSymbol.Count == 0)
                return;

            List<CSymbol> lstSymbol = GetSelectedSymbolList();
            if(lstSymbol == null || lstSymbol.Count == 0)
                return;

            exGridMain.BeginUpdate();
            {
                CSymbol cSymbol;
                for(int i=0;i<lstSymbol.Count;i++)
                {
                    cSymbol = lstSymbol[i];
                    cSymbol.Tag.IsCollectUsed = false;
					if (m_cSymbolS != null)
						m_cSymbolS.Remove(cSymbol.Key);

                    lstViewSymbol.Remove(cSymbol);
                }
            }
            exGridMain.EndUpdate();

            GenerateSymbolRemoveEvent(lstSymbol);
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
                mnuDeleteSymbolS_Click(this, EventArgs.Empty);
            }
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
                List<CSymbol> lstSymbol = GetSelectedSymbolList();
				if (lstSymbol == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

				exGridMain.DoDragDrop(lstSymbol, DragDropEffects.Move);
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
                List<CSymbol> lstAddSymbol = new List<CSymbol>();
				//List<CSymbol> lstSymbol = (List<CSymbol>)e.Data.GetData(typeof(List<CSymbol>));
                if (lstTag != null)
                {
                    List<CSymbol> lstViewData = (List<CSymbol>)exGridMain.DataSource;

                    //CSymbol cSymbol;
                    CTag cTag;
                    for (int i = 0; i < lstTag.Count; i++)
                    {
                        cTag = lstTag[i];
                        //cSymbol = lstSymbol[i];
                        if (m_cSymbolS.ContainsKey(cTag.Key) == false)
                        {
                            CSymbol cSymbol = new CSymbol(cTag);
                            cTag.IsCollectUsed = true;
							m_cSymbolS.Add(cSymbol.Key, cSymbol);
                            lstAddSymbol.Add(cSymbol);
                            lstViewData.Add(cSymbol);
                            m_lstUserAddSymbol.Add(cSymbol.Key);
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
                    GenerateSymbolAddEvent(lstAddSymbol);
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
			CSymbol cSymbol = (CSymbol)exGridView.GetRow(e.RowHandle);
			if (cSymbol != null)
			{
				List<CSymbol> lstSymbol = new List<CSymbol>();
				lstSymbol.Add(cSymbol);

				GenerateSymbolUpdateEvent(lstSymbol);
			}
		}

        #endregion
    
        #endregion

    }
}
