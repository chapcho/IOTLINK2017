using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class FrmNewRecipeViewer : DevExpress.XtraEditors.XtraForm
    {
        private List<CNewRecipeView> m_lstRecipeView = null;

        private delegate void UpdateNoneParameterCallback();

        public FrmNewRecipeViewer()
        {
            InitializeComponent();
        }

        public List<CNewRecipeView> RecipeViewS
        {
            get { return m_lstRecipeView; }
            set
            {
                m_lstRecipeView = value;
                SetView();
            }
        }

        public void SetMasterPatternGenPanel()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetMasterPatternGenPanel);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    lblText.Text = "새로운 Recipe 마스터 패턴 자동 생성 중!!!";
                    lblText.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    pnlBackground.Appearance.BackColor = Color.LimeGreen;
                    pnlBackground.Appearance.BackColor2 = Color.NavajoWhite; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetView()
        {
            if (this.InvokeRequired)
            {
                UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(SetView);
                this.Invoke(cUpdate, new object[] {});
            }
            else
            {
                grdRecipe.DataSource = m_lstRecipeView;
                grdRecipe.RefreshDataSource();
            }
        }

        private void FrmNewRecipeViewer_Load(object sender, EventArgs e)
        {
            pnlBackground.Appearance.BackColor = Color.FromArgb(255, 128, 0);
            pnlBackground.Appearance.BackColor2 = Color.Red;

            lblText.Text = "새로운 Recipe 감지!!!";
            lblText.Font = new Font("Tahoma", 25, FontStyle.Bold);

            tmrTimer.Start();
        }

        private void FrmNewRecipeViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrTimer.Stop();
            tmrTimer.Dispose();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            Color cColor1 = pnlBackground.Appearance.BackColor;
            Color cColor2 = pnlBackground.Appearance.BackColor2;

            pnlBackground.Appearance.BackColor = cColor2;
            pnlBackground.Appearance.BackColor2 = cColor1;

            pnlBackground.Refresh();
        }
    }
}