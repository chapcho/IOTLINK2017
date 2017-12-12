using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public partial class FrmRecipeSectionItem : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        protected CRecipeSection m_cRecipeSection = null;

        #endregion


        #region Initialize

        public FrmRecipeSectionItem(CRecipeSection cRecipe)
        {
            InitializeComponent();
            m_cRecipeSection = cRecipe;
        }

        #endregion

        private void FrmRecipeSectionItem_Load(object sender, EventArgs e)
        {
            if (m_cRecipeSection == null) this.Close();

            this.Text = string.Format("Word Name : {0} / ItemName : {1} / Section : {2}", m_cRecipeSection.WordName, m_cRecipeSection.ItemName, m_cRecipeSection.BitPosString);
            grdSectionItem.DataSource = m_cRecipeSection.SectionItemList;
            grdSectionItem.RefreshDataSource();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            m_cRecipeSection.SectionItemList.Add(new CRecipeSectionItem());
            grdSectionItem.RefreshDataSource();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            List<CRecipeSectionItem> lstEmpty = m_cRecipeSection.SectionItemList.FindAll(b => b.ItemName == "" || b.ItemValue == -1);
            if (lstEmpty != null && lstEmpty.Count > 0)
            {
                for (int i = 0; i < lstEmpty.Count; i++)
                    m_cRecipeSection.SectionItemList.Remove(lstEmpty[i]);
            }
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            grvSectionItem.DeleteSelectedRows();
            //int[] iaHandle = grvSectionItem.GetSelectedRows();
            //if (iaHandle == null || iaHandle.Length == 0) return;

            //for (int i = 0; i < iaHandle.Length; i++)
            //{
                
            //}
        }
    }
}