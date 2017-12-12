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
using UDM.Common;

namespace UDMLadderTracker
{
    public partial class FrmInputProcess : DevExpress.XtraEditors.XtraForm
    {
        List<CCommentSplit> m_lstText = new List<CCommentSplit>();
        private string m_sFixFilter = string.Empty;
        private string m_sFixAbnormalFilter = string.Empty;

        public FrmInputProcess()
        {
            InitializeComponent();
        }

        private void FrmInputProcess_Load(object sender, EventArgs e)
        {
            if (CMultiProject.TotalTagS.Count == 0)
            {
                MessageBox.Show("분석할 내용이 없습니다.");
                this.Close();
            }

            SplashScreenManager.ShowDefaultWaitForm();
            {
                m_sFixFilter = txtFilter.EditValue.ToString();
                m_sFixAbnormalFilter = txtAbnormalFilter.EditValue.ToString();

                ucProcessTree.AbnormalFilter = GetAbnormalFilter();

                //Tag불러와서 분석
                AnalyzeinitText();

                if (CMultiProject.PlcProcS.Count != 0)
                {
                    ucProcessTree.Clear();
                    ucProcessTree.ShowTree();
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void FrmInputProcess_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AnalyzeSameFilterText(List<string> lstSameFilter)
        {
            CCommentSplit cSplit = null;
            string sFilterText = string.Empty;
            bool bContain = false;

            for (int i = 0; i < lstSameFilter.Count; i++)
            {
                bContain = true;
                sFilterText = lstSameFilter[i];

                //for (int j = 0; j < lstSameFilter.Count; j++)
                //{
                //    if (!lstSameFilter[j].Equals(sFilterText) && lstSameFilter[j].Contains(sFilterText))
                //    {
                //        bContain = true;
                //        break;
                //    }
                //}

                if (bContain)
                {
                    cSplit = new CCommentSplit();
                    cSplit.Text = sFilterText;
                    m_lstText.Add(cSplit);
                }
            }
        }

        private void AnalyzeinitText()
        {
            List<string> lstSameFilter = new List<string>();
            List<string> lstFilter = new List<string>();
            string sLine = "";
            if (txtFilter.Lines != null)
            {
                for (int i = 0; i < txtFilter.Lines.Length; i++)
                {
                    sLine = txtFilter.Lines[i].Trim();
                    if (sLine != "")
                        lstFilter.Add(sLine);
                }
            }

            foreach (var who in CMultiProject.TotalTagS)
            {
                if (who.Value.DataType != UDM.Common.EMDataType.Bool) continue;
                string sBase = who.Value.Description;
                if (sBase == "") continue;
                bool bFind = false;
                for (int i = 0; i < lstFilter.Count; i++)
                {
                    if (sBase.Contains(lstFilter[i]))
                    {
                        bFind = true;
                        break;
                    }
                }
                if (bFind) continue;
                string[] sSpaceSplit = sBase.Split(' ');
                //string[] s_Split = sBase.Split('_');

                for (int i = 0; i < sSpaceSplit.Length; i++)
                {
                    string[] s_SubSplit = sSpaceSplit[i].Split('_');

                    for (int j = 0; j < s_SubSplit.Length; j++)
                    {
                        string[] sDashSubSplit = s_SubSplit[j].Split('-');

                        for (int k = 0; k < sDashSubSplit.Length; k++)
                        {
                            string[] sCommaSubSplit = sDashSubSplit[k].Split(',');

                            for (int l = 0; l < sCommaSubSplit.Length; l++)
                            {
                                if (lstSameFilter.Contains(sCommaSubSplit[l]) == false)
                                    lstSameFilter.Add(sCommaSubSplit[l]);
                            }
                        }
                    }
                }
            }

            AnalyzeSameFilterText(lstSameFilter);

            grdCommentSplit.DataSource = m_lstText;
            grdCommentSplit.RefreshDataSource();
        }

        private List<string> GetAbnormalFilter()
        {
            List<string> lstAbnormalFilter = new List<string>();
            string sLine = "";
            if (txtAbnormalFilter.Lines != null)
            {
                for (int i = 0; i < txtAbnormalFilter.Lines.Length; i++)
                {
                    sLine = txtAbnormalFilter.Lines[i].Trim();
                    if (sLine != "")
                        lstAbnormalFilter.Add(sLine);
                }
            }

            return lstAbnormalFilter;
        }

        private void grvCommentSplit_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            m_lstText.Clear();
            AnalyzeinitText();

            if ((string) txtAbnormalFilter.EditValue != m_sFixAbnormalFilter)
            {
                ucProcessTree.AbnormalFilter = GetAbnormalFilter();

                if(CMultiProject.PlcProcS.Count > 0)
                    ucProcessTree.UpdateTree();
            }
        }

        private void btnInitText_Click(object sender, EventArgs e)
        {
            m_lstText.Clear();

            txtFilter.EditValue = m_sFixFilter;
            txtAbnormalFilter.EditValue = m_sFixAbnormalFilter;

            AnalyzeinitText();
        }

        private void grdCommentSplit_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<CCommentSplit>)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grvCommentSplit_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                List<CCommentSplit> lstComment = new List<CCommentSplit>();
                int[] iaRowIndex = grvCommentSplit.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    CCommentSplit cText = new CCommentSplit();
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        cText = (CCommentSplit)grvCommentSplit.GetRow(iaRowIndex[i]);
                        if (cText != null)
                            lstComment.Add(cText);
                    }
                }
                if (lstComment == null || lstComment.Count ==0)
                {
                    return;
                }

                grdCommentSplit.DoDragDrop(lstComment, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProcessName.EditValue == null || txtProcessName.Text == "")
                return;

            CCommentSplit cText = new CCommentSplit();

            cText.Text = txtProcessName.Text;

            m_lstText.Insert(0, cText);

            grdCommentSplit.RefreshDataSource();
        }

        private void btnResetAbnormal_Click(object sender, EventArgs e)
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                ucProcessTree.ResetAbnormal(who.Value);
            }
            ucProcessTree.ShowTree();
        }

    }

    public class CCommentSplit
    {
        public string Text { get; set; }
    }
}