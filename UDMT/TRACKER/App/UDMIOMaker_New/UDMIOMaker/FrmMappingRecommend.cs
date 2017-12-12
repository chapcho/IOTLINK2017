using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmMappingRecommend : DevExpress.XtraEditors.XtraForm
    {
        private CHMITag m_cHMITag = null;
        private CTagS m_cTagS = null;

        public FrmMappingRecommend()
        {
            InitializeComponent();
        }

        public CHMITag HMITag
        {
            get { return m_cHMITag; }
            set { m_cHMITag = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }


        private void SetPLCTagMapping()
        {
            int iRowHandle = grvPLC.FocusedRowHandle;

            if (iRowHandle < 0)
                return;

            CTag cTag = (CTag)grvPLC.GetRow(iRowHandle);

            if (CProjectManager.HMITagS.CheckPLCTagMapping(cTag.Key))
            {
                List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Key);

                if (lstHMIKey.Count < 2)
                {
                    foreach (string sKey in lstHMIKey)
                        CProjectManager.HMITagS[sKey].IsRedundancy = true;

                    m_cHMITag.IsRedundancy = true;
                }
            }

            m_cHMITag.PLCTagKey = cTag.Key;
            m_cHMITag.Address = cTag.Address;

            if (cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || cTag.PLCMaker.Equals(EMPLCMaker.LS))
                m_cHMITag.Description = cTag.Description;
            else
                m_cHMITag.Description = cTag.Name;

            CProjectManager.PLCTagS[cTag.Key].IsHMIMapping = true;
            m_cHMITag.IsMatch = true;
        }


        private void FrmMappingRecommend_Load(object sender, EventArgs e)
        {
            try
            {
                txtHMIName.EditValue = m_cHMITag.Name;

                grdPLC.DataSource = TagS.Values.ToList();
                grdPLC.RefreshDataSource();

                grdPLC.Focus();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Recommend Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grdPLC_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                SetPLCTagMapping();

                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Recommend DoubleClick Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                SetPLCTagMapping();

                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Recommend OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void grvPLC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.DialogResult = DialogResult.OK;
                    SetPLCTagMapping();

                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Recommend KeyDown Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }
}