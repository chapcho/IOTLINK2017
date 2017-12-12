using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
//추가
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace UDM.UI.DevGrid
{
    public partial class UCGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private DataTable m_dbTable = new DataTable();

        public event UEventHandlerDevGridDoubleClick UEventDoubleClick;
        public event UEventHandlerDevGridRowCellClick UEventRowCellClick;
        //추가
        private GridHitInfo m_gridHitInfo = null;
        
        #endregion


        #region Initialize/Dispose

        public UCGrid()
        {
            InitializeComponent();
            InitializeGridStyle();
        }

        #endregion


        #region Public Properties

        public DataTable DataTable
        {
            get { return m_dbTable; }
        }

        public GridView GridView
        {
            get { return exGridView; }
        }

        public object DataSource
        {
            get { return exGridControl.DataSource; }
            set { exGridControl.DataSource = value; }
        }

        public DataRowCollection Rows
        {
            get { return m_dbTable.Rows; }
        }

        public DataColumnCollection Columns
        {
            get { return m_dbTable.Columns; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            if (m_dbTable != null)
                m_dbTable.Clear();

            exGridControl.DataSource = m_dbTable;
            exGridControl.Refresh();
        }
   
        #endregion


        #region Private Methods

        private void InitializeGridStyle()
        {

        }

        #endregion


        #region Event Methods

        private void exGridView_DoubleClick(object sender, EventArgs e)
        {
            if (UEventDoubleClick != null)
            {
                GridView gridView = (GridView)sender;
                if (gridView.SelectedRowsCount > 0)
                {
                    int[] iaHandle = gridView.GetSelectedRows();
                    DataRow dbRow = gridView.GetDataRow(iaHandle[0]);
                    if (dbRow != null)
                        UEventDoubleClick(sender, dbRow);
                }
            }
        }

        private void exGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (UEventRowCellClick != null)
            {
                GridView gridView = (GridView)sender;
                if (gridView.SelectedRowsCount > 0)
                {
                    int[] iaHandle = gridView.GetSelectedRows();
                    DataRow dbRow = gridView.GetDataRow(iaHandle[0]);
                    if (dbRow != null)
                        UEventRowCellClick(sender, dbRow);
                }
            }
        }

        private void exGridView_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);

        }

        


        
        #endregion

    }
}
