using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTL.SWLockLicense
{
    public partial class FrmLicense : Form
    {

        #region Member Variables

        private LicenseInfo m_cInfo = null;

        private string m_sProduct = "";
        private string m_sCode = "";
        private int m_iTrialCount = 0;

        #endregion


        #region Initialize/Dispose

        internal FrmLicense(string sProduct, string sCode)
        {
            InitializeComponent();

            m_sProduct = sProduct;
            m_sCode = sCode;
        }

        #endregion


        #region Public Properties

        internal LicenseInfo LicenseInfo
        {
            get { return m_cInfo; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void ShowInfo()
        {
            txtProduct.Text = m_sProduct;
            txtProduct.Refresh();

            txtActivationCode.Text = m_sCode;
            txtActivationKey.Refresh();
        }

        private void CheckKey()
        {
            string sKeyInput = txtActivationKey.Text.Trim();
            LicenseInfo cInfo = LicenseActivator.AnalyseKey(sKeyInput);
            if (cInfo == null)
                return;

            if (m_sCode == cInfo.ActivationCode)
            {
                m_cInfo = cInfo;
                m_cInfo.Product = m_sProduct;
                m_cInfo.IsLicensed = true;

                if (m_cInfo.IsDemo)
                {
                    MessageBox.Show("[" + txtProduct.Text + "] Trial License Activated!!", "UDM License", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("[" + txtProduct.Text + "] Full License Activated!!", "UDM License", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    this.Close();
                }
            }

            cInfo = null;

            m_iTrialCount++;
            if (m_iTrialCount > 2)
            {
                m_iTrialCount = 0;

                MessageBox.Show("[" + txtProduct.Text + "] License  Failed to Activate!!", "UDM License", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lblAlertMessage.Text = "The Activation Key is not correct!! [" + m_iTrialCount + " / 3]";
            }
        }

        #endregion
        public FrmLicense()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckKey();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_cInfo = new LicenseInfo();
            m_cInfo.Product = m_sProduct;
            m_cInfo.ActivationCode = m_sCode;

            this.Close();
        }

        private void FrmLicense_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
    }
}
