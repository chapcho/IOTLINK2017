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
using UDM.Log;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace UDMEnergyViewer
{
	public partial class FrmClassifySymbol : DevExpress.XtraEditors.XtraForm
    {
        private CMeterItemS m_cMeterItemS = null;
        private CTagItemS m_cTagItemS = null;
        private int m_iMeterItemCount = -1;

        private Dictionary<string, CTagS> m_DicMeterTagS = new Dictionary<string, CTagS>();
        private Dictionary<string, CTagItemS> m_DicUnitTagItemS = null;
        private Dictionary<string, string> m_DicMeterNameS = new Dictionary<string, string>();

        private GridHitInfo m_gridHitInfo;

        #region Initialize/Dispose

        public FrmClassifySymbol()
		{
            InitializeComponent();
        }

        #endregion

        #region Properties

        public CTagItemS TagItemS
        {
            get { return m_cTagItemS; }
            set { m_cTagItemS = value; }
        }

        public CMeterItemS MeterItemS
        {
            get { return m_cMeterItemS; }
            set { m_cMeterItemS = value; }
        }

        #endregion

        #region Event

        private void FrmClassifySymbol_Load(object sender, EventArgs e)
        {
            m_iMeterItemCount = m_cMeterItemS.Count;

            if (m_cMeterItemS.Count != 0)
                cboMeterItemS.Properties.Items.AddRange(m_cMeterItemS.Keys);

            gcAllCoilTable.DataSource = CProjectManager.Project.StepCoilList;
            gcAllCoilTable.RefreshDataSource();

            m_DicUnitTagItemS = CProjectManager.Project.UnitTagItemS;

            btnApply.Enabled = false;
        }

        private void cboMeterItemS_SelectedValueChanged(object sender, EventArgs e)
        {
            string sMeterItem = cboMeterItemS.EditValue.ToString();
            txtMachineName.Text = "";
            ClearGrid();

            if (sMeterItem == string.Empty)
                return;

            btnApply.Enabled = true;

            if (!m_DicMeterNameS.ContainsKey(sMeterItem))
                return;

            string sMachineName = m_DicMeterNameS[sMeterItem];
            txtMachineName.Text = sMachineName;

            if (m_DicMeterTagS[sMeterItem] != null)
                UpdateMachineTable(m_DicMeterTagS[sMeterItem]);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //if(txtMachineName.Text == string.Empty)
            //{
            //    MessageBox.Show("Machine 이름을 입력하시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            List<CTag> lstTag = GetlstTag();

            string sMachineName = txtMachineName.Text;
            string sMeterItem = cboMeterItemS.EditValue.ToString();
            CTagS cTagS = CreateTagS(lstTag);

            if (m_DicMeterNameS.ContainsKey(sMeterItem))
                m_DicMeterNameS[sMeterItem] = sMachineName;
            else if(m_DicMeterTagS.ContainsKey(sMeterItem))
            {
                m_DicMeterTagS[sMeterItem].Clear();
                m_DicMeterTagS[sMeterItem] = cTagS;
            }
            else
            {
                m_DicMeterNameS.Add(sMeterItem, sMachineName);
                m_DicMeterTagS.Add(sMeterItem, cTagS);
            }

            btnApply.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int iApplyCount = m_DicMeterNameS.Count;

            //if (m_iMeterItemCount != iApplyCount || iApplyCount == 0)
            //{
            //    MessageBox.Show("모든 Energy Meter Items에 Unit Name을 할당하시오.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}            

            string sKey = string.Empty;
            CTagItemS cTagItemS = null;
            CTagItem cTagItem = null;

            //foreach(var who in m_DicMeterTagS)
            //{
            //    cTagItemS = new CTagItemS();
            //    sKey = who.Key;

            //    foreach(CTag cTag in who.Value.Values)
            //    {
            //        cTagItem = m_cTagItemS[cTag.Key];
            //        cTagItemS.Add(cTagItem.Key, cTagItem);
            //    }

            //    cTagItemS.UpdateTimeRange();
            //    m_DicUnitTagItemS.Add(sKey, cTagItemS);
            //}

            //UpdateMeterItemS();

            foreach(var who in m_DicMeterTagS)
            {
                cTagItemS = new CTagItemS();
                sKey = who.Key;
                foreach(CTag cTag in who.Value.Values)
                {
                    cTagItem = m_cTagItemS[cTag.Key];

                    if (!cTagItemS.ContainsKey(cTagItem.Key))
                        cTagItemS.Add(cTagItem.Key, cTagItem);
                }
                cTagItemS.UpdateTimeRange();
                m_DicUnitTagItemS.Add(sKey, cTagItemS);
            }

            CProjectManager.Project.UnitTagItemS = m_DicUnitTagItemS;

            MessageBox.Show("Save Success!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       #region Drag&Drop Event

        private void MachineTagTable_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            m_gridHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                m_gridHitInfo = hitInfo;
        }

        private void MachineTagTable_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && m_gridHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(m_gridHitInfo.HitPoint.X - dragSize.Width / 2, m_gridHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                    m_gridHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private List<CTag> GetDragData(GridView view)
        {
            int[] m_gridHitInfo = view.GetSelectedRows();
            if (m_gridHitInfo == null) return null;
            int iCount = m_gridHitInfo.Length;
            List<CTag> lstTagS = new List<CTag>();

            for (int i = 0; i < iCount; i++)
                lstTagS.Add((CTag)view.GetRow(m_gridHitInfo[i]));

            return lstTagS;
        }

        private void MachineTagTable_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MachineTagTable_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            List<CTag> lstTag = e.Data.GetData(typeof(List<CTag>)) as List<CTag>;

            grid.DataSource = lstTag;
            grid.RefreshDataSource();

            btnApply.Enabled = true;
        }

        #endregion

        #endregion 

        private List<CTag> GetlstTag()
        {
            List<CTag> lstTag = new List<CTag>();
            try
            {
                if (gvUnitCoilTable.DataSource == null)
                    return lstTag;

                lstTag = gvUnitCoilTable.DataSource as List<CTag>;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return lstTag;
        }

        private CTagS CreateTagS(List<CTag> lstTag)
        {
            CTagS cTagS = null;
            try
            {
                cTagS = new CTagS();

                foreach(CTag cTag in lstTag)
                    cTagS.Add(cTag.Key, cTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTagS;
        }

        private void UpdateMachineTable(CTagS cTagS)
        {
            ClearGrid();

            List<CTag> lstTag = new List<CTag>();

            foreach(CTag cTag in cTagS.Values)
                lstTag.Add(cTag);

            gcUnitCoilTable.DataSource = lstTag;
            gcUnitCoilTable.RefreshDataSource();
        }

        private void ClearGrid()
        {
            if (gvUnitCoilTable.DataSource == null)
                return;

            List<CTag> lstTag = gvUnitCoilTable.DataSource as List<CTag>;

            lstTag.Clear();

            gcUnitCoilTable.RefreshDataSource();
        }

        private void UpdateMeterItemS()
        {
            CMeterItemS cMeterItemS = new CMeterItemS();
            CMeterItem cMeterItem = null;
            string sMahineName = string.Empty;

            foreach (string sMeterItem in m_DicMeterNameS.Keys)
            {
                sMahineName = m_DicMeterNameS[sMeterItem];
                cMeterItem = m_cMeterItemS[sMeterItem];
                cMeterItem.UnitName = sMahineName;

                cMeterItemS.Add(sMahineName, cMeterItem);
            }

            m_cMeterItemS = null;
            m_cMeterItemS = cMeterItemS;
        }


    }
}