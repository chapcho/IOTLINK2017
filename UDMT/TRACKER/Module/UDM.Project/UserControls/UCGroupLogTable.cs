using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Log;

namespace UDM.Project
{
    public partial class UCGroupLogTable : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected CGroupLogS m_cGroupLogS = null;
        public event UEventHandlerGroupLogTableRowDoubleClicked UEventRowDoubleClicked;

        #endregion


        #region Initialize/Dispose

        public UCGroupLogTable()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CGroupLogS SelectedItemS
        {
            get { return GetSelectedItemS(); }
        }

        public CGroupLogS GroupLogS
        {
            get { return m_cGroupLogS; }
            set { m_cGroupLogS = value; }
        }

        #endregion


        #region Public Methods

        public void ShowTable()
        {
            Clear();

            if (m_cGroupLogS == null)
                return;

            exGridMain.DataSource = m_cGroupLogS;
            exGridMain.Refresh();
        }

        public void Clear()
        {
            exGridMain.DataSource = null;
            exGridMain.RefreshDataSource();
        }

        #endregion


        #region Private Methods

        protected CGroupLogS GetSelectedItemS()
        {
            CGroupLogS cGroupLogS = new CGroupLogS();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CGroupLog cGroupLog;
                int iIndex;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    iIndex = iaRowIndex[i];
                    cGroupLog = (CGroupLog)exGridView.GetRow(iIndex);
                    if (cGroupLog != null)
                        cGroupLogS.Add(cGroupLog);
                }
            }

            return cGroupLogS;
        }

        protected void GenerateDoubleClickEvent(CGroupLog cLog)
        {
            if (UEventRowDoubleClicked != null)
                UEventRowDoubleClicked(this, cLog);
        }

        #endregion


        #region Event Methods

        private void UCGroupLogTable_Load(object sender, EventArgs e)
        {

        }

        private void exGridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void exGridMain_DoubleClick(object sender, EventArgs e)
        {
            int iHandle = exGridView.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = exGridView.GetRow(iHandle);
            if ((oData.GetType() == typeof(CGroupLog)))
                GenerateDoubleClickEvent((CGroupLog)oData);
        }

        #endregion


    }
}
