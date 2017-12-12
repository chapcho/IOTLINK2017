using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;

namespace UDMProfiler
{
    public partial class UCProjectTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private const int IMG_INDEX_PROJECT = 0;
        private const int IMG_INDEX_PLC = 1;
        private const int IMG_INDEX_INFO = 5;

        private const int NODE_LEVEL_PROJECT = 0;
        private const int NODE_LEVEL_PLC = 1;
        private const int NODE_LEVEL_INFO = 2;

        #endregion

        #region Initialize/Displse

        public UCProjectTree()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public void Clear()
        {
            exTreeList.Nodes.Clear();
        }

        public void ShowTree()
        {
            if (CProjectManager.Project == null)
                return;

            TreeListNode trnProject;
            TreeListNode trnPlc;
            CPlc cPlc;

            exTreeList.BeginUpdate();
            {
                if (ExistTreeNode(null, CProjectManager.ProjectName))
                    trnProject = GetTreeNode(null, CProjectManager.ProjectName);
                else
                    trnProject = CreateTreeNode(null, CProjectManager.ProjectName, IMG_INDEX_PROJECT, CProjectManager.Project);

                foreach (var who in CProjectManager.PlcS)
                {
                    cPlc = who.Value;

                    if (ExistTreeNode(trnProject, cPlc.PlcName))
                        continue;

                    trnPlc = CreateTreeNode(trnProject, cPlc.PlcName, IMG_INDEX_PLC, cPlc);
                    UpdatePlcNode(cPlc, trnPlc);
                }
                trnProject.ExpandAll();
            }
            exTreeList.EndUpdate();
        }

        #endregion

        #region Private Methods

        private void UpdatePlcNode(CPlc cPlc, TreeListNode trnPlc)
        {
            //PLC Maker
            CreateTreeNode(trnPlc, cPlc.PlcMaker.ToString(), IMG_INDEX_INFO, null);

            //CollectType
            CreateTreeNode(trnPlc, cPlc.CollectType.ToString(), IMG_INDEX_INFO, null);
        }

        private bool ExistTreeNode(TreeListNode trnParent, string sText)
        {
            bool bOK = false;

            if (trnParent == null)
            {
                for (int i = 0; i < exTreeList.Nodes.Count; i++)
                {
                    if (sText == GetNodeText(exTreeList.Nodes[i]))
                    {
                        bOK = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < trnParent.Nodes.Count; i++)
                {
                    if (sText == GetNodeText(trnParent.Nodes[i]))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private string GetNodeText(TreeListNode trnNode)
        {
            string sName = trnNode.GetValue(0).ToString();

            return sName;
        }

        private TreeListNode GetTreeNode(TreeListNode trnParent, string sText)
        {
            TreeListNode trnNode = null;

            if (trnParent != null)
            {
                for (int i = 0; i < trnParent.Nodes.Count; i++)
                {
                    if (sText == GetNodeText(trnParent.Nodes[i]))
                    {
                        trnNode = trnParent.Nodes[i];
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < exTreeList.Nodes.Count; i++)
                {
                    if (sText == GetNodeText(exTreeList.Nodes[i]))
                    {
                        trnNode = exTreeList.Nodes[i];
                        break;
                    }
                }
            }

            return trnNode;
        }

        private TreeListNode CreateTreeNode(TreeListNode trnParent, string sName, int iImageIndex, object oData)
        {
            TreeListNode trnNode = null;

            if (trnParent == null)
                trnNode = exTreeList.Nodes.Add(new object[] {sName});
            else
                trnNode = trnParent.Nodes.Add(new object[] {sName});

            trnNode.ImageIndex = iImageIndex;
            trnNode.SelectImageIndex = iImageIndex;
            trnNode.Tag = oData;

            return trnNode;
        }

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }


        #endregion

        private void exTreeList_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            if (e.Menu is TreeListNodeMenu)
            {
                TreeListNode trnNode = ((TreeListNodeMenu) e.Menu).Node;

                exTreeList.FocusedNode = trnNode;
                object oData = trnNode.Tag;

                if (oData != null)
                {
                    Type tpNode = trnNode.Tag.GetType();
                    if (tpNode == typeof (CPlc))
                        exTreeList.ContextMenuStrip = cntxPlcMenu;
                    else if (tpNode == typeof (CProjectBase))
                        exTreeList.ContextMenuStrip = cntxProjectMenu;
                }
                else
                {
                    exTreeList.ContextMenuStrip = null;
                    e.Allow = false;
                }
            }
        }

        private void mnuDeleteProject_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = XtraMessageBox.Show("해당 프로젝트를 제거하시겠습니까?", "Delete Project", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlgResult == DialogResult.No)
                return;

            TreeListNode trnProject = exTreeList.FocusedNode;
            if (trnProject == null || trnProject.Tag == null | trnProject.Tag.GetType() != typeof (CProjectBase))
                return;

            CProjectManager.Clear();
            CProjectManager.Project = null;

            CProjectManager.Refresh();
        }

        private void mnuDeletePlc_Click(object sender, EventArgs e)
        {
            TreeListNode trnPlc = exTreeList.FocusedNode;
            if (trnPlc == null || trnPlc.Tag == null | trnPlc.Tag.GetType() != typeof(CPlc))
                return;

            CPlc cPlc = (CPlc)trnPlc.Tag;

            DialogResult dlgResult = XtraMessageBox.Show("해당 \"" + cPlc.PlcName + "\" PLC를 제거하시겠습니까?", "Delete PLC",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.No)
                return;

            CProjectManager.PlcS.Remove(cPlc.PlcID);
            CProjectManager.Project.PlcIDList.Remove(cPlc.PlcID);
            CProjectManager.TotalTagS.Clear();

            foreach(var who in CProjectManager.PlcS)
                CProjectManager.TotalTagS.AddRange(who.Value.TagS);

            CProjectManager.MainTree.Clear();
            CProjectManager.Refresh();

            //Debug
            XtraMessageBox.Show(string.Format("Total Tag Count : {0}", CProjectManager.TotalTagS.Count));

        }

        private void mnuRenamePlc_Click(object sender, EventArgs e)
        {
            TreeListNode trnPlc = exTreeList.FocusedNode;
            if (trnPlc == null || trnPlc.Tag == null | trnPlc.Tag.GetType() != typeof(CPlc))
                return;

            CPlc cPlc = (CPlc)trnPlc.Tag;

            string sName = GetUserInputText("Rename PLC", "변경할 PLC 이름을 입력하세요.");

            if (sName == string.Empty)
            {
                XtraMessageBox.Show("이름이 비었습니다.\r\n다시 입력해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cPlc.PlcName = sName;
            trnPlc.SetValue(colInfo, sName);

            exTreeList.Update();
        }

        private void exTreeList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                exTreeList.ContextMenuStrip = null;
            }
        }


    }
}
