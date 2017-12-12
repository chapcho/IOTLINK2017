using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public partial class FrmSymbolSelect : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private CTagS m_cSelectedTagS = new CTagS();
        private List<CLineInfoTag> m_lstSelectedSymbol = new List<CLineInfoTag>();
        private string m_sMainText = "";
        private bool m_bDragDropReady = false;

        private int m_iLimitSymbolCount = 0;

        #endregion


        #region Properties
        public List<CLineInfoTag> SelectedSymbolList
        {
            get { return m_lstSelectedSymbol; }
            set { m_lstSelectedSymbol = value; }
        }

        public string MainText
        {
            set { m_sMainText = value; }
        }

        public int LimitSymbolCount
        {
            set { m_iLimitSymbolCount = value; }
        }

        #endregion

        #region Initialize

        public FrmSymbolSelect()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Method

        private CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

            try
            {
                int[] iaRowIndex = grvTotalTagS.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    CTag cTag;
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        cTag = (CTag)grvTotalTagS.GetRow(iaRowIndex[i]);
                        if (cTag != null)
                            cTagS.Add(cTag.Key, cTag);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmSymbolSelect", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return cTagS;
        }

        private List<CLineInfoTag> GetListLineTagsFromSelectedSymbolS(CTagS cTagS)
        {
            List<CLineInfoTag> lstLineTagS = new List<CLineInfoTag>();

            foreach (CTag cTag in cTagS.Values)
            {
                CLineInfoTag cLTag = new CLineInfoTag();
                cLTag.Tag = cTag;
                lstLineTagS.Add(cLTag);
            }
            return lstLineTagS;
        }

        private CTagS GetTagsFromSelectedSymbol()
        {
            CTagS cTagS = new CTagS();
            
            foreach(CLineInfoTag cLineTag in m_lstSelectedSymbol)
            {
                if (cLineTag.Tag != null && !cTagS.ContainsKey(cLineTag.Tag.Key))
                    cTagS.Add(cLineTag.Tag);
            }

            return cTagS;
        }

        #endregion

        #region Public Method
        #endregion


        #region Form Event
        private void FrmSymbolSelect_Load(object sender, EventArgs e)
        {
            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            m_cSelectedTagS = GetTagsFromSelectedSymbol();
            m_lstSelectedSymbol = GetListLineTagsFromSelectedSymbolS(m_cSelectedTagS);

            grdSelectedSymbol.DataSource = m_cSelectedTagS.Values; //m_lstSelectedSymbol;
            grdSelectedSymbol.RefreshDataSource();

            lblMainText.Text = m_sMainText;

        }

        private void grvTotalTagS_MouseMove(object sender, MouseEventArgs e)
        {
            if (CMultiProject.IsRun) return;

            if (grvTotalTagS.DataSource == null || grvTotalTagS.DataRowCount == 0) return;

            try
            {
                if (e.Button == MouseButtons.Left && m_bDragDropReady)
                {
                    CTagS cTagS = GetSelectedTagS();
                    if (cTagS == null)
                    {
                        m_bDragDropReady = false;
                        return;
                    }

                    grdTotalTagS.DoDragDrop(cTagS, DragDropEffects.Move);
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                    m_bDragDropReady = false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmSymbolSelect", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_MouseDown(object sender, MouseEventArgs e)
        {
            if (CMultiProject.IsRun) return;

            try
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
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmSymbolSelect", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdSelectedSymbol_DragDrop(object sender, DragEventArgs e)
        {
            if (CMultiProject.IsRun) return;

            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                    if (cTagS != null)
                    {
                        if (m_lstSelectedSymbol.Count >= m_iLimitSymbolCount || (m_lstSelectedSymbol.Count + cTagS.Count > m_iLimitSymbolCount))
                        {
                            XtraMessageBox.Show(string.Format("설정할 수 있는 개수를 넘었습니다.( 설정 : {0} )", m_iLimitSymbolCount), "Symbol Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //foreach (CTag cTag in cTagS.Values)
                        //{
                        //    CLineInfoTag cLTag = new CLineInfoTag();
                        //    cLTag.Tag = cTag;
                        //    m_lstSelectedSymbol.Add(cLTag);
                        //}

                        m_lstSelectedSymbol = GetListLineTagsFromSelectedSymbolS(cTagS);

                        m_cSelectedTagS = cTagS;

                        grdSelectedSymbol.DataSource = null;
                        grdSelectedSymbol.DataSource = m_cSelectedTagS.Values; //m_lstSelectedSymbol;
                        grdSelectedSymbol.RefreshDataSource();
                    }
                    else
                    {
                        XtraMessageBox.Show("Can't assign this node!!", "Symbol Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmSymbolSelect", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdSelectedSymbol_DragOver(object sender, DragEventArgs e)
        {
            if (CMultiProject.IsRun) return;

            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            if (CMultiProject.IsRun) return;

            try
            {
                int[] iaRowIndex = grvSelectedSymbol.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CTag cRobotTag = (CTag)grvSelectedSymbol.GetRow(iaRowIndex[i]);
                        if (CMultiProject.ProjectInfo.RobotCycleTagS.ContainsKey(cRobotTag.Key))
                            CMultiProject.ProjectInfo.RobotCycleTagS.Remove(cRobotTag.Key);

                        if (m_cSelectedTagS.ContainsKey(cRobotTag.Key))
                            m_cSelectedTagS.Remove(cRobotTag.Key);
                    }

                    m_lstSelectedSymbol = GetListLineTagsFromSelectedSymbolS(m_cSelectedTagS);

                    grdSelectedSymbol.DataSource = null;
                    grdSelectedSymbol.DataSource = m_cSelectedTagS.Values; //m_lstSelectedSymbol;
                    grdSelectedSymbol.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmSymbolSelect", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }
        #endregion
    }
}