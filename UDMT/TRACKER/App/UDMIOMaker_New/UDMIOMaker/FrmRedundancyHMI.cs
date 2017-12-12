using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public delegate void UEventHandlerHMIGridDoubleClicked(string sHMIKey);

    public partial class FrmRedundancyHMI : DevExpress.XtraEditors.XtraForm
    {
        private List<string> m_lstMappedHMIKey = new List<string>(); 
        public event UEventHandlerHMIGridDoubleClicked UHMIGridDoubleClickEvent;

        public FrmRedundancyHMI()
        {
            InitializeComponent();
        }

        public List<string> MappedHMIKeyList
        {
            get { return m_lstMappedHMIKey; }
            set { m_lstMappedHMIKey = value; }
        }

        private void FrmRedundancyHMI_Load(object sender, EventArgs e)
        {
            try
            {
                CHMITagS cTagS = new CHMITagS();
                CHMITag cTag = null;

                foreach (string sKey in m_lstMappedHMIKey)
                {
                    cTag = CProjectManager.HMITagS[sKey];
                    cTagS.Add(sKey, cTag);
                }

                grdHMI.DataSource = cTagS.Values.ToList();
                grdHMI.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmRedundancyHMI Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvHMI_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iHandle = grvHMI.FocusedRowHandle;
                if (iHandle < 0)
                    return;

                object oData = grvHMI.GetRow(iHandle);
                if (oData.GetType() != typeof (CHMITag))
                    return;

                CHMITag cTag = (CHMITag) oData;

                if (UHMIGridDoubleClickEvent != null)
                    UHMIGridDoubleClickEvent(cTag.Name);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmRedundancyHMI DoubleClick Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}