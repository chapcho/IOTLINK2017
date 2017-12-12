using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;
using DevExpress.XtraTreeList.Menu;

namespace UDMTrackerSimple
{
    public partial class FrmAbnormalTreeViewer : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bEdit = false;

        public FrmAbnormalTreeViewer()
        {
            InitializeComponent();
        }

        private void ShowAbnormalTreeStructure()
        {
            if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                return;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                CreateAbnormalTree();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void CreateAbnormalTree()
        {
            exTreeList.BeginUpdate();
            {
                TreeListNode trnProcess = null;
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    if (cProcess.AbnormalSymbolS == null || cProcess.AbnormalSymbolS.Count == 0)
                        continue;

                    trnProcess = CreateTreeNode(null, cProcess.Name, string.Empty, -1, false, false, true, 0, -1, cProcess);
                    UpdateProcessNode(trnProcess, cProcess);

                    trnProcess.Expanded = true;
                }
            }
            exTreeList.EndUpdate();
        }


        private void UpdateProcessNode(TreeListNode trnProcess, CPlcProc cProcess)
        {
            TreeListNode trnAbnormalNode = null;
            foreach (var who in cProcess.AbnormalSymbolS)
            {
                if(who.Value.SubCoil != null)
                    trnAbnormalNode = CreateTreeNode(trnProcess, who.Key, CMultiProject.TotalTagS[who.Value.Tag.Key].Description, who.Value.SubCoil.CurDepth, who.Value.SubCoil.IsASymbolState, who.Value.SubCoil.IsInverse, false, 2, who.Value.Priority, who.Value);
                else
                    trnAbnormalNode = CreateTreeNode(trnProcess, who.Key, CMultiProject.TotalTagS[who.Value.Tag.Key].Description, -1, false, false, true, 2, who.Value.Priority, who.Value);

                if (who.Value.SubCoil == null || who.Value.SubCoil.SubCoilS == null)
                    continue;

                foreach(CSubCoil cSubCoil in who.Value.SubCoil.SubCoilS)
                    UpdateSubCoilS(trnAbnormalNode, cSubCoil);
            }
        }

        private void UpdateSubCoilS(TreeListNode trnNode, CSubCoil cSubCoil)
        {
            if (cSubCoil == null)
                return;

            TreeListNode trnSubNode = CreateTreeNode(trnNode, cSubCoil.CoilKey, CMultiProject.TotalTagS[cSubCoil.CoilKey].Description, cSubCoil.CurDepth, cSubCoil.IsASymbolState, cSubCoil.IsInverse, false, 2, -1, cSubCoil);

            if (cSubCoil.SubCoilS != null && cSubCoil.SubCoilS.Count != 0)
            {
                foreach(CSubCoil cSubSubCoil in cSubCoil.SubCoilS)
                    UpdateSubCoilS(trnSubNode, cSubSubCoil);
            }
        }

        private void RemoveSubCoilS(CAbnormalSymbol cSymbol, CSubCoil cTargetSubCoil)
        {
            bool bFind = false;

            foreach(CSubCoil cSubCoil in cSymbol.SubCoil.SubCoilS)
            {
                if (cSubCoil == cTargetSubCoil)
                {
                    bFind = true;
                    break;
                }
                else if (cSubCoil.SubCoilS != null && cSubCoil.SubCoilS.Count > 0)
                    RemoveSubCoilS(cSubCoil, cTargetSubCoil);
            }

            if (bFind)
                cSymbol.SubCoil.SubCoilS.Remove(cTargetSubCoil);
        }

        private void RemoveSubCoilS(CSubCoil cCoil, CSubCoil cTargetSubCoil)
        {
            bool bFind = false;

            foreach(CSubCoil cSubCoil in cCoil.SubCoilS)
            {
                if (cSubCoil == cTargetSubCoil)
                {
                    bFind = true;
                    break;
                }
                else if (cSubCoil.SubCoilS != null && cSubCoil.SubCoilS.Count > 0)
                    RemoveSubCoilS(cSubCoil, cTargetSubCoil);
            }

            if (bFind)
                cCoil.SubCoilS.Remove(cTargetSubCoil);
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sKey, string sDescription, int iDepth, bool bAStatus, bool bInverse, bool bNormal, int iImageIndex, int iPriority, object oData)
        {
            TreeListNode trnNode = null;

            if (!bNormal)
            {
                if (trnParent == null)
                    trnNode = exTreeList.Nodes.Add(new object[] { sKey, sDescription, iDepth, bAStatus, bInverse, iPriority });
                else
                    trnNode = trnParent.Nodes.Add(new object[] { sKey, sDescription, iDepth, bAStatus, bInverse, iPriority });
            }
            else
            {
                if (trnParent == null)
                    trnNode = exTreeList.Nodes.Add(new object[] { sKey, sDescription });
                else
                    trnNode = trnParent.Nodes.Add(new object[] { sKey, sDescription});
            }

            trnNode.Tag = oData;
            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;

            return trnNode;
        }

        private void FrmAbnormalTreeViewer_Load(object sender, EventArgs e)
        {
            ShowAbnormalTreeStructure();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbnormalTreeViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (m_bEdit)
                {
                    foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                    {
                        if (cProcess.AbnormalSymbolS == null || cProcess.AbnormalSymbolS.Count == 0)
                            continue;

                        foreach (var who in cProcess.AbnormalSymbolS)
                            cProcess.AbnormalSymbolPriority[who.Key] = who.Value.Priority;
                    }
                }

                exTreeList.Nodes.Clear();
                exTreeList.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tgsPriority_Toggled(object sender, EventArgs e)
        {
            if(tgsPriority.IsOn)
            {
                colPriority.OptionsColumn.ReadOnly = false;
                colPriority.OptionsColumn.AllowEdit = true;
            }
            else
            {
                colPriority.OptionsColumn.ReadOnly = true;
                colPriority.OptionsColumn.AllowEdit = false;
            }
        }

        private void exTreeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            try
            {
                //if (e.Menu is TreeListNodeMenu)
                //{
                //    TreeListNode trnNode = ((TreeListNodeMenu)e.Menu).Node;

                //    exTreeList.FocusedNode = trnNode;

                //    object oData = trnNode.Tag;

                //    if (oData != null)
                //    {
                //        Type tpNode = trnNode.Tag.GetType();
                //        if (tpNode == typeof(CSubCoil))
                //            exTreeList.ContextMenuStrip = cntxSubcoil;
                //        else
                //        {
                //            exTreeList.ContextMenuStrip = null;
                //            e.Allow = false;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            try
            {
                int iValue = Convert.ToInt32(e.Value);
                TreeListNode trnNode = e.Node;

                if (trnNode.Tag == null || trnNode.Tag.GetType() != typeof(CAbnormalSymbol))
                    return;

                CAbnormalSymbol cSymbol = (CAbnormalSymbol) trnNode.Tag;
                cSymbol.Priority = iValue;

                m_bEdit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void mnuSubCoilDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode trnSubCoil = exTreeList.FocusedNode;
                if (trnSubCoil == null || trnSubCoil.Tag == null || trnSubCoil.Tag.GetType() != typeof(CSubCoil))
                    return;

                CSubCoil cSubCoil = (CSubCoil)trnSubCoil.Tag;

                if (XtraMessageBox.Show("해당 Sub Coil을 삭제하시겠습니까?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;

                TreeListNode trnAbnormal = null;
                TreeListNode trnParent = null;
                TreeListNode trnTemp = null;

                for(int i = 0 ; i < cSubCoil.CurDepth + 1 ; i++)
                {
                    if (trnTemp == null)
                        trnTemp = trnSubCoil.ParentNode;
                    else
                        trnTemp = trnTemp.ParentNode;

                    if (i == 0)
                        trnParent = trnTemp;
                    else if (i == cSubCoil.CurDepth - 1)
                        trnAbnormal = trnTemp;
                }

                if (trnParent == null || trnAbnormal == null)
                    return;

                CAbnormalSymbol cSymbol = (CAbnormalSymbol)trnAbnormal.Tag;

                RemoveSubCoilS(cSymbol, cSubCoil);
                trnParent.Nodes.Remove(trnSubCoil);

                exTreeList.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void exTreeList_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            TreeListNode trnNode = e.Node;

            if (trnNode.Tag == null || trnNode.Tag.GetType() != typeof (CAbnormalSymbol))
            {
                trnNode.SetValue(-1, colPriority);
                exTreeList.RefreshCell(trnNode, colPriority);
                return;
            }
        }


    }
}