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
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmAbnormalTreeViewer : XtraForm
    {
        public FrmAbnormalTreeViewer()
        {
            InitializeComponent();
        }

        private void ShowAbnormalTreeStructure()
        {
            if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                return;

            SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format(""), "Create Abnormal Tree");
            {
                CreateAbnormalTree();
            }
            SplashScreenManager.CloseDefaultSplashScreen();
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

                    trnProcess = CreateTreeNode(null, cProcess.Name, string.Empty, -1, false, false, true, 0);
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
                if (who.Value.SubCoil != null)
                    trnAbnormalNode = CreateTreeNode(trnProcess, who.Key, CMultiProject.TotalTagS[who.Value.Tag.Key].Description, who.Value.SubCoil.CurDepth, who.Value.SubCoil.IsASymbolState, who.Value.SubCoil.IsInverse, false, 2);
                else
                    trnAbnormalNode = CreateTreeNode(trnProcess, who.Key, CMultiProject.TotalTagS[who.Value.Tag.Key].Description, -1, false, false, true, 2);

                if (who.Value.SubCoil == null || who.Value.SubCoil.SubCoilS == null)
                    continue;

                foreach (CSubCoil cSubCoil in who.Value.SubCoil.SubCoilS)
                    UpdateSubCoilS(trnAbnormalNode, cSubCoil);
            }
        }

        private void UpdateSubCoilS(TreeListNode trnNode, CSubCoil cSubCoil)
        {
            if (cSubCoil == null)
                return;

            TreeListNode trnSubNode = CreateTreeNode(trnNode, cSubCoil.CoilKey, CMultiProject.TotalTagS[cSubCoil.CoilKey].Description, cSubCoil.CurDepth, cSubCoil.IsASymbolState, cSubCoil.IsInverse, false, 2);

            if (cSubCoil.SubCoilS != null && cSubCoil.SubCoilS.Count != 0)
            {
                foreach (CSubCoil cSubSubCoil in cSubCoil.SubCoilS)
                    UpdateSubCoilS(trnSubNode, cSubSubCoil);
            }
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sKey, string sDescription, int iDepth, bool bAStatus, bool bInverse, bool bNormal, int iImageIndex)
        {
            TreeListNode trnNode = null;

            if (!bNormal)
            {
                if (trnParent == null)
                    trnNode = exTreeList.Nodes.Add(new object[] { sKey, sDescription, iDepth, bAStatus, bInverse });
                else
                    trnNode = trnParent.Nodes.Add(new object[] { sKey, sDescription, iDepth, bAStatus, bInverse });
            }
            else
            {
                if (trnParent == null)
                    trnNode = exTreeList.Nodes.Add(new object[] { sKey, sDescription });
                else
                    trnNode = trnParent.Nodes.Add(new object[] { sKey, sDescription });
            }

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
    }
}
