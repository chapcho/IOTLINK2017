using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMLadderTracker
{
    public partial class UCProcessLogTable : DevExpress.XtraEditors.XtraUserControl
    {
        protected CCycleInfoS m_cCycleInfoS = null;
        public event UEventHandlerProcessLogTableRowDoubleClicked UEventRowDoubleClicked;

        public UCProcessLogTable()
        {
            InitializeComponent();
        }

        #region Public Properties

        public CCycleInfoS SelectedItemS
        {
            get { return GetSelectedItemS(); }
        }

        public CCycleInfoS CycleInfoS
        {
            get { return m_cCycleInfoS; }
            set { m_cCycleInfoS = value; }
        }

        #endregion


        #region Public Methods

        public void ShowTable()
        {
            Clear();

            if (m_cCycleInfoS == null)
                return;

            exGridMain.DataSource = m_cCycleInfoS.Values;
            exGridMain.Refresh();
        }

        public void Clear()
        {
            exGridMain.DataSource = null;
            exGridMain.RefreshDataSource();
        }

        #endregion


        #region Private Methods

        protected CCycleInfoS GetSelectedItemS()
        {
            CCycleInfoS cCycleInfoS = new CCycleInfoS();

            int[] iaRowIndex = exGridView.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CCycleInfo cCycleInfo;
                int iIndex;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    iIndex = iaRowIndex[i];
                    cCycleInfo = (CCycleInfo)exGridView.GetRow(iIndex);
                    if (cCycleInfo != null)
                        cCycleInfoS.Add(cCycleInfo.CycleID, cCycleInfo);
                }
            }

            return cCycleInfoS;
        }

        protected void GenerateDoubleClickEvent(CCycleInfo cInfo)
        {
            if (UEventRowDoubleClicked != null)
                UEventRowDoubleClicked(this, cInfo);
        }

        #endregion


        #region Event Methods

        private void UCProcessLogTable_Load(object sender, EventArgs e)
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
            if ((oData.GetType() == typeof(CCycleInfo)))
                GenerateDoubleClickEvent((CCycleInfo)oData);
        }

        #endregion


    }
}
