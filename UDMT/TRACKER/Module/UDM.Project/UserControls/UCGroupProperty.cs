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
    public partial class UCGroupProperty : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = false;
        protected CGroup m_cGroup = null;

        #endregion


        #region Initialize/Dispose
        
        public UCGroupProperty()
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

        public CGroup Group
        {
            get { return m_cGroup; }
            set { m_cGroup = value; }
        }

        #endregion


        #region Public Methods

        public void ShowProperty()
        {
            //Clear();

            exProperty.SelectedObject = m_cGroup;
            if (m_cGroup == null)
                return;

            exGridCycleStartConditionS.DataSource = m_cGroup.CycleStartConditionS;
            exGridCycleEndConditionS.DataSource = m_cGroup.CycleEndConditionS;
            exGridCycleStartConditionS.RefreshDataSource();
            exGridCycleEndConditionS.RefreshDataSource();

            exProperty.Refresh();
        }

        public void Clear()
        {
            m_cGroup = null;

            exProperty.SelectedObject = null;
            exGridCycleStartConditionS.DataSource = null;
            exGridCycleEndConditionS.DataSource = null;
            exGridCycleStartConditionS.RefreshDataSource();
            exGridCycleEndConditionS.RefreshDataSource();

            exProperty.Refresh();
        }

        #endregion


        #region Private Methods

        protected void SetEditable(bool bEditable)
        {
            m_bEditable = bEditable;

            exGridViewCycleStartConditionS.OptionsBehavior.Editable = bEditable;
            exGridViewCycleStartConditionS.OptionsBehavior.ReadOnly = !bEditable;
            exGridViewCycleEndConditionS.OptionsBehavior.Editable = bEditable;
            exGridViewCycleEndConditionS.OptionsBehavior.ReadOnly = !bEditable;
            exProperty.Enabled = bEditable;
        }

        #endregion


        #region Event Methods

        private void UCGroupProperty_Load(object sender, EventArgs e)
        {
            ShowProperty();
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (cntxMenu.SourceControl == exGridCycleStartConditionS)
            {
                m_cGroup.CycleStartConditionS.Clear();
                exGridCycleStartConditionS.RefreshDataSource();                
            }
            else if (cntxMenu.SourceControl == exGridCycleEndConditionS)
            {
                m_cGroup.CycleEndConditionS.Clear();
                exGridCycleEndConditionS.RefreshDataSource();
            }
        }

        private void mnuMoveUp_Click(object sender, EventArgs e)
        {
            if (cntxMenu.SourceControl == exGridCycleStartConditionS)
            {
                int iHandle = exGridViewCycleStartConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleStartConditionS.GetRow(iHandle);
                if (m_cGroup.CycleStartConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleStartConditionS.MoveUp(cCondition);
                    exGridCycleStartConditionS.RefreshDataSource();
                }
            }
            else if (cntxMenu.SourceControl == exGridCycleEndConditionS)
            {
                int iHandle = exGridViewCycleEndConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleEndConditionS.GetRow(iHandle);
                if (m_cGroup.CycleEndConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleEndConditionS.MoveUp(cCondition);
                    exGridCycleEndConditionS.RefreshDataSource();
                }
            }            
        }

        private void mnuMoveDown_Click(object sender, EventArgs e)
        {
            if (cntxMenu.SourceControl == exGridCycleStartConditionS)
            {
                int iHandle = exGridViewCycleStartConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleStartConditionS.GetRow(iHandle);
                if (m_cGroup.CycleStartConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleStartConditionS.MoveDown(cCondition);
                    exGridCycleStartConditionS.RefreshDataSource();
                }
            }
            else if (cntxMenu.SourceControl == exGridCycleEndConditionS)
            {
                int iHandle = exGridViewCycleEndConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleEndConditionS.GetRow(iHandle);
                if (m_cGroup.CycleEndConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleEndConditionS.MoveDown(cCondition);
                    exGridCycleEndConditionS.RefreshDataSource();
                }
            }   
        }

        private void exGridViewCycleStartConditionS_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Subtract)
            {
                int iHandle = exGridViewCycleStartConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleStartConditionS.GetRow(iHandle);
                if (m_cGroup.CycleStartConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleStartConditionS.MoveUp(cCondition);
                    exGridCycleStartConditionS.RefreshDataSource();
                }
            }
            else if (e.KeyCode == Keys.Add)
            {
                int iHandle = exGridViewCycleStartConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleStartConditionS.GetRow(iHandle);
                if (m_cGroup.CycleStartConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleStartConditionS.MoveDown(cCondition);
                    exGridCycleStartConditionS.RefreshDataSource();
                }
            }
        }

        private void exGridViewCycleEndConditionS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                int iHandle = exGridViewCycleEndConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleEndConditionS.GetRow(iHandle);
                if (m_cGroup.CycleEndConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleEndConditionS.MoveUp(cCondition);
                    exGridCycleEndConditionS.RefreshDataSource();
                }
            }
            else if (e.KeyCode == Keys.Add)
            {
                int iHandle = exGridViewCycleEndConditionS.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                CCondition cCondition = (CCondition)exGridViewCycleEndConditionS.GetRow(iHandle);
                if (m_cGroup.CycleEndConditionS.Contains(cCondition))
                {
                    m_cGroup.CycleEndConditionS.MoveDown(cCondition);
                    exGridCycleEndConditionS.RefreshDataSource();
                }
            }            
        }

        private void exGridCycleStartConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)) || e.Data.GetDataPresent(typeof(CSymbol)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exGridCycleStartConditionS_DragDrop(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data != null)
            {
                if(e.Data.GetDataPresent(typeof(CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                    if (cTagS == null || cTagS.Count == 0)
                        return;

                    CTag cTag;
                    for (int i = 0; i < cTagS.Count; i++)
                    {
                        cTag = cTagS[i];
                        if(m_cGroup.KeySymbolS.ContainsKey(cTag.Key))
                        {
                            if (m_cGroup.CycleStartConditionS.ContainsKey(cTag.Key) == false)
                            {
                                CCondition cCondition = new CCondition(cTag.Key, cTag.Address, 1, EMOperaterType.And);
                                m_cGroup.CycleStartConditionS.Add(cCondition);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Symbol must exist in this group and be the KEY(not GENERAL) Symbol");
                        }
                    }
                    ShowProperty();

                    exGridCycleStartConditionS.RefreshDataSource();
                    
                    cTagS.Clear();
                }
                else if(e.Data.GetDataPresent(typeof(CSymbol)))
                {
                    e.Effect = DragDropEffects.Move;

                    CSymbol cSymbol = (CSymbol)e.Data.GetData(typeof(CSymbol));
                    if (cSymbol == null)
                        return;

                    if (m_cGroup.KeySymbolS.ContainsKey(cSymbol.Key))
                    {
                        if (m_cGroup.CycleStartConditionS.ContainsKey(cSymbol.Key) == false)
                        {
                            CCondition cCondition = new CCondition(cSymbol.Key, cSymbol.Address, 1, EMOperaterType.And);
                            m_cGroup.CycleStartConditionS.Add(cCondition);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Symbol must exist in this group and be the KEY(not GENERAL) Symbol");
                    }

                    exGridCycleStartConditionS.RefreshDataSource();
                }
            }
        }        

        private void exGridCycleEndConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)) || e.Data.GetDataPresent(typeof(CSymbol)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exGridCycleEndConditionS_DragDrop(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(typeof(CTagS)))
                {
                    e.Effect = DragDropEffects.Move;

                    CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                    if (cTagS == null || cTagS.Count == 0)
                        return;

                    CTag cTag;
                    for (int i = 0; i < cTagS.Count; i++)
                    {
                        cTag = cTagS[i];

                        cTag = cTagS[i];
                        if (m_cGroup.KeySymbolS.ContainsKey(cTag.Key))
                        {
                            if (m_cGroup.CycleEndConditionS.ContainsKey(cTag.Key) == false)
                            {
                                CCondition cCondition = new CCondition(cTag.Key, cTag.Address, 1, EMOperaterType.And);
                                m_cGroup.CycleEndConditionS.Add(cCondition);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Symbol must exist in this group and be the KEY(not GENERAL) Symbol");
                        }
                    }

                    ShowProperty();

                    exGridCycleEndConditionS.RefreshDataSource();

                    cTagS.Clear();
                }
                else if(e.Data.GetDataPresent(typeof(CSymbol)))
                {
                    e.Effect = DragDropEffects.Move;

                    CSymbol cSymbol = (CSymbol)e.Data.GetData(typeof(CSymbol));
                    if (cSymbol == null)
                        return;

                    if (m_cGroup.KeySymbolS.ContainsKey(cSymbol.Key))
                    {
                        if (m_cGroup.CycleEndConditionS.ContainsKey(cSymbol.Key) == false)
                        {
                            CCondition cCondition = new CCondition(cSymbol.Key, cSymbol.Address, 1, EMOperaterType.And);
                            m_cGroup.CycleEndConditionS.Add(cCondition);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Symbol must exist in this group and be the KEY(not GENERAL) Symbol");
                    }

                    exGridCycleEndConditionS.RefreshDataSource();
                }
            }
        }

        private void exProperty_DragOver(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data.GetDataPresent(typeof(CTagS)) || e.Data.GetDataPresent(typeof(CSymbol)))
            {
                Point point = exProperty.PointToClient(new Point(e.X, e.Y));
                DevExpress.XtraVerticalGrid.VGridHitInfo exHitInfo = exProperty.CalcHitInfo(point);
                if (exHitInfo != null && (exHitInfo.Row == rowProduct || exHitInfo.Row == rowRecipe))
                    e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void exProperty_DragDrop(object sender, DragEventArgs e)
        {
            if (m_cGroup == null)
                return;

            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(typeof(CTagS)))
                {
                    Point point = exProperty.PointToClient(new Point(e.X, e.Y));
                    DevExpress.XtraVerticalGrid.VGridHitInfo exHitInfo = exProperty.CalcHitInfo(point);
                    if (exHitInfo != null && (exHitInfo.Row == rowProduct || exHitInfo.Row == rowRecipe))
                    {
                        e.Effect = DragDropEffects.Move;

                        CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                        if (cTagS == null || cTagS.Count == 0)
                            return;

                        CTag cTag = cTagS[0];
                        if (exHitInfo.Row == rowProduct)
                        {
                            m_cGroup.Product.Address = cTag.Address;
                            m_cGroup.Product.Size = cTag.Size;
                        }
                        else
                        {
                            m_cGroup.Recipe.Address = cTag.Address;
                            m_cGroup.Recipe.Size = cTag.Size;
                        }

                        exProperty.Refresh();
                    }
                }
                else if(e.Data.GetDataPresent(typeof(CSymbol)))
                {
                    Point point = exProperty.PointToClient(new Point(e.X, e.Y));
                    DevExpress.XtraVerticalGrid.VGridHitInfo exHitInfo = exProperty.CalcHitInfo(point);
                    if (exHitInfo != null && (exHitInfo.Row == rowProduct || exHitInfo.Row == rowRecipe))
                    {
                        e.Effect = DragDropEffects.Move;

                        CSymbol cSymbol = (CSymbol)e.Data.GetData(typeof(CSymbol));
                        if (cSymbol == null)
                            return;

                        if (exHitInfo.Row == rowProduct)
                        {
                            m_cGroup.Product.Address = cSymbol.Address;
                            m_cGroup.Product.Size = cSymbol.Size;
                        }
                        else
                        {
                            m_cGroup.Recipe.Address = cSymbol.Address;
                            m_cGroup.Recipe.Size = cSymbol.Size;
                        }

                        exProperty.Refresh();
                    }
                }
            }
        }        
        
        private void exProperty_CustomDrawRowValueCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs e)
        {
            if (e.Row == rowCycleStartConditionS)
            {
                Rectangle rect = e.Bounds;
                exGridCycleStartConditionS.Left = rect.Left;
                exGridCycleStartConditionS.Top = rect.Top;
                exGridCycleStartConditionS.Width = rect.Width;
                exGridCycleStartConditionS.Height = rect.Height;
            }
            else if (e.Row == rowCycleEndConditionS)
            {
                Rectangle rect = e.Bounds;
                exGridCycleEndConditionS.Left = rect.Left;
                exGridCycleEndConditionS.Top = rect.Top;
                exGridCycleEndConditionS.Width = rect.Width;
                exGridCycleEndConditionS.Height = rect.Height;
            }
        }

        private void exProperty_ShownEditor(object sender, EventArgs e)
        {
            if (exProperty.ActiveEditor == null)
                return;

            if (exProperty.ActiveEditor.GetType() != typeof(DevExpress.XtraEditors.TextEdit))
                return;

            ((DevExpress.XtraEditors.TextEdit)(exProperty.ActiveEditor)).Properties.CharacterCasing = CharacterCasing.Upper;
        }

        #endregion 

        
    }
}
