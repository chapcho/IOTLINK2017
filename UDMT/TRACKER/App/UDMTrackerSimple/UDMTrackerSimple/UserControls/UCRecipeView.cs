using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCRecipeView : DevExpress.XtraEditors.XtraUserControl
    {
        private CTagS m_cRecipeTagS = null;
        private CTimeLogS m_cRecipeLogS = null;

        private List<CRecipeView> m_lstRecipeView = new List<CRecipeView>(); 

        public UCRecipeView()
        {
            InitializeComponent();
        }

        public CTagS RecipeTagS
        {
            get { return m_cRecipeTagS; }
            set { m_cRecipeTagS = value; }
        }

        public CTimeLogS RecipeLogS
        {
            get { return m_cRecipeLogS; }
            set { m_cRecipeLogS = value; }
        }

        public void Clear()
        {
            m_lstRecipeView.Clear();

            grdRecipeTagS.DataSource = null;
            vgrdRecipe.DataSource = null;

            grdRecipeTagS.RefreshDataSource();
            vgrdRecipe.RefreshDataSource();
        }

        public void SetRecipeWord(CTagS cRecipeTagS)
        {
            if (cRecipeTagS == null || cRecipeTagS.Count == 0)
                return;

            Clear();

            m_cRecipeTagS = cRecipeTagS;

            grdRecipeTagS.DataSource = m_cRecipeTagS.Values.ToList();
            grdRecipeTagS.RefreshDataSource();
        }

        public void SetRecipeInformation(CTimeLogS cRecipeLogS)
        {
            m_lstRecipeView.Clear();
            vgrdRecipe.DataSource = null;
            vgrdRecipe.RefreshDataSource();

            if (cRecipeLogS == null || cRecipeLogS.Count == 0)
                return;

            m_cRecipeLogS = cRecipeLogS;

            CreateRecipeInformation();

            vgrdRecipe.DataSource = m_lstRecipeView;
            vgrdRecipe.RefreshDataSource();
        }

        private void CreateRecipeInformation()
        {
            string sResult = string.Empty;
            CTimeLogS cLogS = null;
            CRecipeView cView = null;
            CTag cRecipeTag = null;

            if (CMultiProject.ProjectInfo.RecipeWordList == null)
                return;

            foreach (var who in CMultiProject.ProjectInfo.RecipeWordList)
            {
                foreach (var who2 in who.Value.RecipeSectionList)
                {
                    cRecipeTag = m_cRecipeTagS[who2.WordIndex];

                    cLogS = m_cRecipeLogS.GetTimeLogS(cRecipeTag.Key);

                    if(cLogS == null || cLogS.Count == 0)
                        continue;

                    sResult = cLogS.First().Value.ToString();// GetRecipeName(cLogS.First().Value, who2);

                    cView = new CRecipeView();
                    cView.BitPosString = who2.BitPosString;
                    cView.RecipeItem = who2.ItemName;
                    cView.RecipeValue = sResult;
                    cView.RecipeWord = cRecipeTag.Key;

                    m_lstRecipeView.Add(cView);
                }
            }
        }

        private string GetRecipeName(int iValue, CRecipeSection cRecipeSection)
        {
            string sResult = "";
            int iSumValue = 0;
            cRecipeSection.BitPosList.Sort();

            for (int i = 0; i < cRecipeSection.BitPosList.Count; i++)
            {
                int iBitValue = iValue & (0x1 << cRecipeSection.BitPosList[i]);
                if (iBitValue > 0)
                    iSumValue += 0x1 << i;
            }

            for (int i = 0; i < cRecipeSection.SectionItemList.Count; i++)
            {
                CRecipeSectionItem cItem = cRecipeSection.SectionItemList[i];
                if (cItem.ItemValue == iSumValue)
                {
                    sResult = cItem.ItemName;
                    break;
                }
            }
            return sResult;
        }

        private void grvRecipeTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void UCRecipeView_Load(object sender, EventArgs e)
        {
            int iUnitWidth = this.Width/2;

            grpRecipeWord.Width = iUnitWidth;
            //this.Height = 150;
        }

        private void vgrdRecipe_CustomDrawRowHeaderCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventArgs e)
        {

        }

        private void UCRecipeView_Resize(object sender, EventArgs e)
        {
            //this.Height = vgrdRecipe.Height;
        }
    }

    public class CRecipeView
    {
        public string RecipeItem { get; set; }
        public string RecipeValue { get; set; }
        public string BitPosString { get; set; }
        public string RecipeWord { get; set; }
    }
}
