using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using UDM.Common;

namespace UDMOptimizer
{
    public partial class FrmProcessUnitSetting : DevExpress.XtraEditors.XtraForm
    {
        #region Member Veriables

        protected bool m_bDragDropReady = false;
        protected bool m_bIsCancel = false;
        protected CUnitInfo m_cUnit = new CUnitInfo();
        protected CTagS m_cFilterTagS = new CTagS();

        #endregion


        #region Initialize

        public FrmProcessUnitSetting()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CUnitInfo Unit
        {
            get { return m_cUnit; }
            set { m_cUnit = value; }
        }

        public bool IsCancel
        {
            get { return m_bIsCancel; }
        }

        public CTagS FilterTagS
        {
            set { m_cFilterTagS = value; }
            get { return m_cFilterTagS; }
        }

        #endregion


        #region Form Event

        private void grvTotalTagS_MouseDown(object sender, MouseEventArgs e)
        {
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
                MessageBox.Show("Unit Setting", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grvTotalTagS_MouseMove(object sender, MouseEventArgs e)
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

        #endregion


        #region Private Method

        private CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

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

            return cTagS;
        }

        #endregion

        private void grdUnitAllTag_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                    if (cTagS != null)
                    {
                        if (m_cUnit.TotalTagS == null)
                            m_cUnit.TotalTagS = new CTagS();
                        int iCount = 0;
                        foreach (CTag cTag in cTagS.Values)
                        {
                            if (m_cUnit.TotalTagS.ContainsKey(cTag.Key) == false)
                            {
                                m_cUnit.TotalTagS.Add(cTag);
                                m_cUnit.TotalTagKeyList.Add(cTag.Key);
                                iCount++;
                            }
                        }
                        if (iCount > 0)
                        {
                            List<CTag> lstWordTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Word).ToList();
                            List<CTag> lstBitTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Bool).ToList();
                            txtBitCount.Text = lstBitTag.Count.ToString();
                            txtWordCount.Text = lstWordTag.Count.ToString();
                            grdUnitWordTag.DataSource = null;
                            grdUnitWordTag.DataSource = lstWordTag;
                            grdUnitWordTag.RefreshDataSource();
                            grdUnitBitTag.DataSource = null;
                            grdUnitBitTag.DataSource = lstBitTag;
                            grdUnitBitTag.RefreshDataSource();
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FrmModel", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdUnitAllTag_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            m_cUnit.Name = txtName.Text;
            if (m_cUnit.TotalTagS.Count == 0)
            {

            }
            if (m_cUnit.Name == "")
            {
                MessageBox.Show("이름을 입력하지 않았습니다.");
                return;
            }
            m_bIsCancel = false;
            this.Close();
        }

        private void FrmProcessUnitSetting_Load(object sender, EventArgs e)
        {
            //이름 입력

            grdTotalTagS.DataSource = m_cFilterTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            if (m_cUnit != null)
            {
                List<CTag> lstBitTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Bool).ToList();
                grdUnitBitTag.DataSource = lstBitTag;
                grdUnitBitTag.RefreshDataSource();

                List<CTag> lstwordTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Word).ToList();
                grdUnitWordTag.DataSource = lstwordTag;
                grdUnitWordTag.RefreshDataSource();

                foreach (CTag cTag in m_cUnit.TotalTagS.Values)
                {
                    if(m_cFilterTagS.ContainsKey(cTag.Key))
                    {
                        //색상 변경
                    }
                }
                txtName.Text = m_cUnit.Name;
                txtBitCount.Text = lstBitTag.Count.ToString();
                txtWordCount.Text = lstwordTag.Count.ToString();
            }
        }

        private void FrmProcessUnitSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_cUnit.Name = txtName.Text;
            if (m_cUnit.Name == "")
            {
                DialogResult dlgResult = MessageBox.Show("이름을 입력하지 않았습니다.\r\n이대로 종료하시겠습니까?", "Fail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                    m_bIsCancel = true;
                else
                    e.Cancel = true;
            }
        }

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            try
            {
                int[] iaRowIndex = grvUnitWordTag.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CTag cTag = (CTag)grvUnitWordTag.GetRow(iaRowIndex[i]);
                        if (m_cUnit.TotalTagS.ContainsKey(cTag.Key))
                            m_cUnit.TotalTagS.Remove(cTag.Key);
                    }
                    List<CTag> lstWordTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Word).ToList();
                    txtWordCount.Text = lstWordTag.Count.ToString();
                    grdUnitWordTag.DataSource = null;
                    grdUnitWordTag.DataSource = lstWordTag;
                    grdUnitWordTag.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProcessUint", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            m_cUnit.TotalTagS.Clear();
            grdUnitBitTag.DataSource = null;
            grdUnitBitTag.RefreshDataSource();
            grdUnitWordTag.DataSource = null;
            grdUnitWordTag.RefreshDataSource();
            txtBitCount.Text = "0";
            txtWordCount.Text = "0";
        }

        private void mnuDeleteBit_Click(object sender, EventArgs e)
        {
            try
            {
                int[] iaRowIndex = grvUnitBitTag.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CTag cTag = (CTag)grvUnitBitTag.GetRow(iaRowIndex[i]);
                        if (m_cUnit.TotalTagS.ContainsKey(cTag.Key))
                            m_cUnit.TotalTagS.Remove(cTag.Key);
                    }
                    List<CTag> lstBitTag = m_cUnit.TotalTagS.Values.Where(b => b.DataType == EMDataType.Bool).ToList();
                    txtBitCount.Text = lstBitTag.Count.ToString();
                    grdUnitBitTag.DataSource = null;
                    grdUnitBitTag.DataSource = lstBitTag;
                    grdUnitBitTag.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ProcessUint", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

    }
}