using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;

namespace UDM.Project
{
    public partial class UCStepTagTable : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Veriables

        private CProject m_cProject = null;

        public event UEventHandlerStepDoubleClicked UEventStepDoubleClicked;
        public event UEventHandlerTagDoubleClicked UEventTagDoubleClicked;

        #endregion


        #region Initialize

        public UCStepTagTable()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public ContextMenuStrip ContextStepMenuStrip
        {
            get { return grdStepList.ContextMenuStrip; }
            set { grdStepList.ContextMenuStrip = value; }
        }

        public ContextMenuStrip ContextTagMenuStrip
        {
            get { return grdTagList.ContextMenuStrip; }
            set { grdTagList.ContextMenuStrip = value; }
        }

        public bool AllowMultiSelect
        {
            get { return grvStepList.OptionsSelection.MultiSelect; }
            set { grvStepList.OptionsSelection.MultiSelect = value; grvStepList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect; }
        }

        #endregion


        #region Public Method

        public void ShowTable()
        {
            if (m_cProject == null)
                return;

            ClearTable();
            ShowTable(m_cProject);
        }

        public void Clear()
        {
            ClearTable();
        }

        public List<CStep> GetSelectedStepList()
        {
            List<CStep> lstStep = new List<CStep>();

            int[] iaHandles = grvStepList.GetSelectedRows();
            if (iaHandles == null)
                return lstStep;

            int iHandle;

            CStep cStep;
            for (int i = 0; i < iaHandles.Length; i++)
            {
                iHandle = iaHandles[i];
                if (iHandle > -1)
                {
                    cStep = (CStep)grvStepList.GetRow(iHandle);
                    lstStep.Add(cStep);
                }
            }

            return lstStep;
        }

        public List<CTag> GetSelectedTagList()
        {
            List<CTag> lstTag = new List<CTag>();

            int[] iaHandles = grvTagList.GetSelectedRows();
            if (iaHandles == null)
                return lstTag;

            int iHandle;

            CTag cTag;
            for (int i = 0; i < iaHandles.Length; i++)
            {
                iHandle = iaHandles[i];
                if (iHandle > -1)
                {
                    cTag = (CTag)grvTagList.GetRow(iHandle);
                    lstTag.Add(cTag);
                }
            }

            return lstTag;

        }        

        #endregion


        #region Private Method

        private void ShowTable(CProject cProject)
        {   
            grdStepList.DataSource = cProject.StepS.Select(x=>x.Value).ToList();
            grdTagList.DataSource = cProject.TagS.Select(x => x.Value).ToList();
        }

        private void ClearTable()
        {
            grdStepList.DataSource = null;
            grdTagList.DataSource = null;
        }        

        private int SortResult(string sValue1, string sValue2)
        {
            int iResult = -9999;

            try
            {
                if (sValue1.Length > 0 && sValue2.Length > 0)
                {
                    bool bComparable = false;
                    bool bS1Digit = false;
                    bool bS2Digit = false;
                    while (true)
                    {
                        if (sValue1[0] != sValue2[0])
                            break;

                        bS1Digit = char.IsDigit(sValue1[1]);
                        bS2Digit = char.IsDigit(sValue2[1]);
                        if (bS1Digit && bS2Digit)
                        {
                            if (sValue1.Length > 3 && sValue1[sValue1.Length - 2] == 'Z')
                                sValue1 = sValue1.Remove(sValue1.Length - 2);

                            if (sValue2.Length > 3 && sValue2[sValue2.Length - 2] == 'Z')
                                sValue2 = sValue2.Remove(sValue2.Length - 2);

                            sValue1 = sValue1.Remove(0, 1);
                            sValue2 = sValue2.Remove(0, 1);

                            bComparable = true;
                            break;
                        }
                        else if (bS1Digit != bS2Digit)
                        {
                            break;
                        }
                        else if (sValue1[1] == sValue2[1])
                        {
                            sValue1 = sValue1.Remove(0, 1);
                            sValue2 = sValue2.Remove(0, 1);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (bComparable)
                    {
                        double iAddr1 = ParseDouble(sValue1);
                        double iAddr2 = ParseDouble(sValue2);

                        if (iAddr1 != -1 && iAddr2 != -1)
                            iResult = System.Collections.Comparer.Default.Compare(iAddr1, iAddr2);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return iResult;
        }

        private double ParseDouble(string sValue)
        {
            double nValue = -1;

            bool bOK = double.TryParse(sValue, out nValue);
            if (bOK == false)
                nValue = -1;

            return nValue;
        }

        #endregion


        #region Event Method

        private void grvStepList_DoubleClick(object sender, EventArgs e)
        {
            int iHandle =  grvStepList.FocusedRowHandle;
            if (iHandle < 0)
                return;

            CStep cStep = (CStep)grvStepList.GetRow(iHandle);
            if (cStep == null)
                return;

            if (UEventStepDoubleClicked != null)
                UEventStepDoubleClicked(this, cStep);
        }        

        private void grvTagList_DoubleClick(object sender, EventArgs e)
        {
            int iHandle = grvTagList.FocusedRowHandle;
            if (iHandle < 0)
                return;

            CTag cTag = (CTag)grvTagList.GetRow(iHandle);
            if (cTag == null)
                return;

            if (UEventTagDoubleClicked != null)
                UEventTagDoubleClicked(this, cTag);
        }

        private void grvStepList_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            if (e.Value1 == null || e.Value2 == null)
                return;

            string sValue1 = (string)e.Value1;
            string sValue2 = (string)e.Value2;

            int iResult = SortResult(sValue1, sValue2);
            if (iResult != -9999)
            {
                e.Result = iResult;
                e.Handled = true;
            }
        }

        private void grvTagList_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            if (e.Value1 == null || e.Value2 == null)
                return;

            string sValue1 = (string)e.Value1;
            string sValue2 = (string)e.Value2;

            int iResult = SortResult(sValue1, sValue2);
            if (iResult != -9999)
            {
                e.Result = iResult;
                e.Handled = true;
            }
        }       

        private void grvStepList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle + 1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void grvTagList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle + 1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void grvStepList_ShownEditor(object sender, EventArgs e)
        {
            if (grvStepList.FocusedColumn == colStepAddress)
            {
                TextEdit edit = grvStepList.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
            else if (grvStepList.FocusedColumn == colStepCommand)
            {
                TextEdit edit = grvStepList.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void grvTagList_ShownEditor(object sender, EventArgs e)
        {
            if (grvTagList.FocusedColumn == colTagAddress)
            {
                TextEdit edit = grvTagList.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
        }

        #endregion
        
    }
}
