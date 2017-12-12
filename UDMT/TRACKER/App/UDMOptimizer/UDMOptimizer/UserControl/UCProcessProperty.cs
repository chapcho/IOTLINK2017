using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Common;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class UCProcessProperty : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private CPlcProc m_cProcess = null;

        #endregion

        public UCProcessProperty()
        {
            InitializeComponent();
        }


        #region Properties

        public CPlcProc Process
        {
            get { return m_cProcess; }
            set { m_cProcess = value; }
        }

        #endregion

        #region Public Methods

        public void ShowProperty()
        {
            exProperty.SelectedObject = m_cProcess;

            if (m_cProcess == null)
                return;

            //grdStartConditionS.DataSource = m_cProcess.CycleStartConditionS;
            //grdEndConditionS.DataSource = m_cProcess.CycleEndConditionS;
            //grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.GetTagS().Values.ToList();

            grdStartConditionS.RefreshDataSource();
            grdEndConditionS.RefreshDataSource();
            grdKeySymbolS.RefreshDataSource();

            exProperty.Refresh();
        }

        public void Clear()
        {
            exProperty.SelectedObject = null;
            grdStartConditionS.DataSource = null;
            grdEndConditionS.DataSource = null;
            grdKeySymbolS.DataSource = null;

            grdStartConditionS.RefreshDataSource();
            grdEndConditionS.RefreshDataSource();
            grdKeySymbolS.RefreshDataSource();

            exProperty.Refresh();
        }

        #endregion

        #region Private Methods

        private bool CheckPlcOutputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.Address.Contains("Y"))
                return true;

            //Seimens
            if (cTag.PLCMaker.Equals(EMPLCMaker.Siemens) && cTag.Address.Contains("Q"))
                return true;

            //LS
            if (cTag.PLCMaker.Equals(EMPLCMaker.LS))
            {
                if (cTag.Address.StartsWith("%"))
                {
                    string sAddress = cTag.Address.Remove(0, 1);
                    if (sAddress.StartsWith("Q"))
                        return true;
                }
                else if ((cTag.Address.Contains("K") || cTag.Address.Contains("P")))
                    return true;
            }

            if (cTag.PLCMaker.Equals(EMPLCMaker.Rockwell))
                return true;

            return false;
        }

        #endregion



        private void exProperty_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {
            if (e.Row == rowCycleStartConditionS)
            {
                Rectangle rect = e.Bounds;
                grdStartConditionS.Left = rect.Left;
                grdStartConditionS.Top = rect.Top;
                grdStartConditionS.Width = rect.Width;
                grdStartConditionS.Height = rect.Height;
            }
            else if (e.Row == rowCycleEndConditionS)
            {
                Rectangle rect = e.Bounds;
                grdEndConditionS.Left = rect.Left;
                grdEndConditionS.Top = rect.Top;
                grdEndConditionS.Width = rect.Width;
                grdEndConditionS.Height = rect.Height;
            }
            else if (e.Row == rowKeySymbol)
            {
                Rectangle rect = e.Bounds;
                grdKeySymbolS.Left = rect.Left;
                grdKeySymbolS.Top = rect.Top;
                grdKeySymbolS.Width = rect.Width;
                grdKeySymbolS.Height = rect.Height;
            }
        }

        private void exProperty_ShownEditor(object sender, EventArgs e)
        {

        }

        private void UCProcessProperty_Load(object sender, EventArgs e)
        {
            ShowProperty();
        }

        private void grdStartConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (m_cProcess == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdStartConditionS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof (CTagS)))
                    {
                        CTagS cTagS = (CTagS) e.Data.GetData(typeof (CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        //foreach (var who in cTagS)
                        //{
                        //    CCondition cCondition = new CCondition(who.Key, who.Value.Address, 1, EMOperaterType.And);
                        //    m_cProcess.CycleStartConditionS.Add(cCondition);
                        //}

                        //if(m_cProcess.CycleStartConditionS.Count != 0)
                        //    m_cProcess.StartCompareCondition = m_cProcess.CycleStartConditionS.First();

                        grdStartConditionS.RefreshDataSource();

                        cTagS.Clear();
                        cTagS = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Property StartCondition Drag Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdEndConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (m_cProcess == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdEndConditionS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (m_cProcess == null)
                    return;

                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof(CTagS)))
                    {
                        CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        //foreach (var who in cTagS)
                        //{
                        //    CCondition cCondition = new CCondition(who.Key, who.Value.Address, 1, EMOperaterType.And);
                        //    m_cProcess.CycleEndConditionS.Add(cCondition);
                        //}

                        //if (m_cProcess.CycleEndConditionS.Count != 0)
                        //    m_cProcess.EndCompareCondition = m_cProcess.CycleEndConditionS.First();

                        grdEndConditionS.RefreshDataSource();

                        cTagS.Clear();
                        cTagS = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Property EndCondition Drag Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            if (cntxMenu.SourceControl == grdStartConditionS)
            {
                DialogResult dlgResult = XtraMessageBox.Show("사이클 시작 조건을 모두 지우시겠습니까?", "Cycle Start Condition Clear",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                //m_cProcess.CycleStartConditionS.Clear();
                //m_cProcess.StartCompareCondition = null;
                grdStartConditionS.RefreshDataSource();
            }
            else if (cntxMenu.SourceControl == grdEndConditionS)
            {
                DialogResult dlgResult = XtraMessageBox.Show("사이클 끝 조건을 모두 지우시겠습니까?", "Cycle End Condition Clear",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                //m_cProcess.CycleEndConditionS.Clear();
                //m_cProcess.EndCompareCondition = null;
                grdEndConditionS.RefreshDataSource();
            }
            
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (cntxMenu.SourceControl == grdStartConditionS)
            {
                DialogResult dlgResult = XtraMessageBox.Show("선택하신 사이클 시작 조건을 제거하시겠습니까?", "Cycle Start Condition Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                CCondition cCondition = (CCondition)grvStartConditionS.GetFocusedRow();

                if (cCondition == null)
                    return;

                //if (m_cProcess.CycleStartConditionS.ContainsKey(cCondition.Key))
                //    m_cProcess.CycleStartConditionS.Remove(cCondition);

                grdStartConditionS.RefreshDataSource();
            }
            else if (cntxMenu.SourceControl == grdEndConditionS)
            {
                DialogResult dlgResult = XtraMessageBox.Show("선택하신 사이클 끝 조건을 제거하시겠습니까?", "Cycle Start Condition Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                CCondition cCondition = (CCondition) grvEndConditionS.GetFocusedRow();

                if (cCondition == null)
                    return;

                //if (m_cProcess.CycleEndConditionS.ContainsKey(cCondition.Key))
                //    m_cProcess.CycleEndConditionS.Remove(cCondition);

                grdEndConditionS.RefreshDataSource();
            }
        }
    }
}
