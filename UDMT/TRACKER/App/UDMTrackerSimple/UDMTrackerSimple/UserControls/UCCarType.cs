using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class UCCarType : DevExpress.XtraEditors.XtraUserControl
    {
        private string m_sProcessKey = string.Empty;

        private delegate void CUpdateCarTypeCallback(string sRecipe);

        public string ProcessKey
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public UCCarType()
        {
            InitializeComponent();
        }

        public void SetCarType(string sRecipe)
        {
            if (this.InvokeRequired)
            {
                CUpdateCarTypeCallback cUpdate = new CUpdateCarTypeCallback(SetCarType);
                this.Invoke(cUpdate, new object[] {sRecipe});
            }
            else
            {
                lblCarType.Text = sRecipe;
            }
        }

        private void UCCarType_Resize(object sender, EventArgs e)
        {
            float nSize = (this.Width > this.Height) ? this.Height : this.Width;
            FontFamily fontFamily = lblCarType.Font.FontFamily;
            float nFontSize = (float)nSize / 100f;
            if (nFontSize < 0.1f)
                nFontSize = 0.1f;

            Font fontValue = new Font(fontFamily, nFontSize * 30.25f, FontStyle.Bold);
            lblCarType.Font = fontValue;
        }

    }
}
