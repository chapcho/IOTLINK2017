using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;

namespace UDM.Ladder
{
    public partial class FrmLadderValidationMultiple : Form
    {
        private CValidatorMultiple m_cValidatorMultiple = null;
        private const int m_nStepPerPage = 20;
        private int m_nPage = 0;
        private int m_nCurPage = 1;
        private int m_nPageOnlyProblem = 0;
        private int m_nCurPageOnlyProblem = 1;

        public FrmLadderValidationMultiple()
        {
            InitializeComponent();
            treeList.CustomDrawNodeCell += TreeListCustomDrawNodeCell;
            treeList.BeforeExpand += TreeListBeforeExpand;
            checkBoxShowProblemOnly.CheckedChanged += CheckBoxShowProblemOnlyCheckedChanged;
        }

        public void Validate(CStepS cStepS)
        {
            // The validation ( + result )
            m_cValidatorMultiple = new CValidatorMultiple(cStepS);
            
            // General
            m_nPage = (m_cValidatorMultiple.ResultData.Count / m_nStepPerPage) + 1;
            m_nCurPage = 1;
            
            // Only problem
            m_nPageOnlyProblem = (m_cValidatorMultiple.IndexProblemStep.Count / m_nStepPerPage) + 1;
            m_nCurPageOnlyProblem = 1;

            // Update info
            labelResult.Text = "Result :    Steps = " +
                cStepS.Count.ToString() + "     Problems = " +
                m_cValidatorMultiple.IndexProblemStep.Count.ToString();

            // Update
            UpdatePage();
        }

        private void UpdatePage()
        {
            if (checkBoxShowProblemOnly.Checked) { ShowProblemPage(m_nCurPageOnlyProblem); }
            else { ShowNormalPage(m_nCurPage); }
        }

        private void ShowNormalPage(int nPage)
        {
            if (m_cValidatorMultiple == null) { return; }
            int nStartIndex = (nPage - 1) * m_nStepPerPage;
            int nEndIndex = (nPage * m_nStepPerPage) - 1;
            nEndIndex = (m_cValidatorMultiple.ResultData.Count - 1) < nEndIndex ? (m_cValidatorMultiple.ResultData.Count - 1) : nEndIndex;
            ShowData(nStartIndex, nEndIndex);
            labelPage.Text = m_nCurPage.ToString();
        }

        private void ShowProblemPage(int nPage)
        {
            if (m_cValidatorMultiple == null) { return; }
            int nStartIndex = (nPage - 1) * m_nStepPerPage;
            int nEndIndex = (nPage * m_nStepPerPage) - 1;
            nEndIndex = (m_cValidatorMultiple.IndexProblemStep.Count - 1) < nEndIndex ? (m_cValidatorMultiple.IndexProblemStep.Count - 1) : nEndIndex;
            ShowData(nStartIndex, nEndIndex);
            labelPage.Text = m_nCurPageOnlyProblem.ToString();
        }

        private void ShowData(int nStartIndex, int nEndIndex)
        {
            treeList.ClearNodes();

            for (int i = nStartIndex; i < (nEndIndex + 1); i++)
            {
                System.Diagnostics.Debug.WriteLine("Node-" + i.ToString());
                DevExpress.XtraTreeList.Nodes.TreeListNode nodeStep = treeList.AppendNode(null, null);

                int index = checkBoxShowProblemOnly.Checked ? m_cValidatorMultiple.IndexProblemStep[i] : i;
                CValidatorSingle cValidatorSingle = m_cValidatorMultiple.ResultData[index];
                
                nodeStep.SetValue("Step", cValidatorSingle.Step.Key);
                nodeStep.Tag = cValidatorSingle;
                treeList.AppendNode(null, nodeStep); // Dummy node
            }
        }

        private void TreeListCustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (checkBoxShowProblemOnly.Checked) { CustomDrawNodeShowProblem(e); }
            else { /* NOTHING */ }

            CustomDrawNodeDefault(e);
        }

        private void CustomDrawNodeDefault(DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Column.FieldName == "Step") 
            {
                if (e.Node.Tag is CValidatorSingle)
                {
                    CValidatorSingle cValidatorSingle = e.Node.Tag as CValidatorSingle;
                    if (cValidatorSingle.IsProblem)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void CustomDrawNodeShowProblem(DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                if (e.CellText == "NOT OK")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void TreeListBeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            if (e.Node.Tag is CValidatorSingle)
            {
                if ((e.Node.Nodes.Count == 1) &&
                    (e.Node.GetValue("Contact") == null) &&
                    (e.Node.GetValue("ContactName") == null) &&
                    (e.Node.GetValue("ContactX") == null) &&
                    (e.Node.GetValue("ContactY") == null) &&
                    (e.Node.GetValue("Cell") == null) &&
                    (e.Node.GetValue("CellName") == null) &&
                    (e.Node.GetValue("CellRow") == null) &&
                    (e.Node.GetValue("CellColumn") == null) &&
                    (e.Node.GetValue("Status") == null))
                {
                    // Delete dummy node
                    treeList.DeleteNode(e.Node.Nodes[0]);

                    CValidatorSingle cValidatorSingle = e.Node.Tag as CValidatorSingle;
                    foreach (DataRow dtRow in cValidatorSingle.ResultData.Rows)
                    {
                        DevExpress.XtraTreeList.Nodes.TreeListNode node = treeList.AppendNode(null, e.Node);

                        node.SetValue("Contact", dtRow["ContactClass"]);
                        node.SetValue("ContactName", dtRow["ContactName"]);
                        node.SetValue("ContactX", dtRow["ContactX"]);
                        node.SetValue("ContactY", dtRow["ContactY"]);

                        node.SetValue("Cell", dtRow["CellClass"]);
                        node.SetValue("CellName", dtRow["CellName"]);
                        node.SetValue("CellRow", dtRow["CellRow"]);
                        node.SetValue("CellColumn", dtRow["CellColumn"]);

                        node.SetValue("Status", dtRow["Status"]);
                    }
                }
            }
        }

        private void ButtonBeginPageClick(object sender, EventArgs e)
        {
            if (checkBoxShowProblemOnly.Checked) { m_nCurPageOnlyProblem = 1; }
            else { m_nCurPage = 1; }
            
            UpdatePage();
        }

        private void ButtonDecreasePageClick(object sender, EventArgs e)
        {
            if (checkBoxShowProblemOnly.Checked) { m_nCurPageOnlyProblem = m_nCurPageOnlyProblem - 1 < 1 ? m_nCurPageOnlyProblem : m_nCurPageOnlyProblem - 1; }
            else { m_nCurPage = m_nCurPage - 1 < 1 ? m_nCurPage : m_nCurPage - 1; }
            
            UpdatePage();
        }

        private void ButtonIncreasePageClick(object sender, EventArgs e)
        {
            if (checkBoxShowProblemOnly.Checked) { m_nCurPageOnlyProblem = m_nCurPageOnlyProblem + 1 > m_nPageOnlyProblem ? m_nCurPageOnlyProblem : m_nCurPageOnlyProblem + 1; }
            else { m_nCurPage = m_nCurPage + 1 > m_nPage ? m_nCurPage : m_nCurPage + 1; }

            UpdatePage();
        }

        private void ButtonLastPageClick(object sender, EventArgs e)
        {
            if (checkBoxShowProblemOnly.Checked) { m_nCurPageOnlyProblem = m_nPageOnlyProblem; }
            else { m_nCurPage = m_nPage; }

            UpdatePage();
        }

        private void CheckBoxShowProblemOnlyCheckedChanged(object sender, EventArgs e)
        {
            UpdatePage();
        }
    }
}
