using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.EnergyDaq.Config;

namespace UEnergyDaqServer
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Member Variables

        private CMainClass m_cMain = new CMainClass();
        private FrmConfigSetting m_FrmSetting = new FrmConfigSetting();
        private CConfigS m_lstConfigS = null;

        #endregion


        #region Intialize/Dispose

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void m_cConfigSetting_ConfigEdited(object sender,CConfigS cConfigS)
        {
            m_lstConfigS = cConfigS;
        }

        #endregion


        #region Event Methods

        #region Form

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Home

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnNewProject();
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnOpenProject();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveProject();
        }

        private void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnSaveAsProject();
        }

        private void btnStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_lstConfigS = m_FrmSetting.ConfigS;
            m_cMain.ConfigS = m_lstConfigS;
            OnStartMonitor();
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnStopMonitor();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnExit();
        }

        private void btnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_FrmSetting.Show();
            m_FrmSetting.MeterConfigEdited += m_cConfigSetting_ConfigEdited;
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_lstConfigS = m_FrmSetting.ConfigS;
        }


        #endregion      
              

        #endregion
    }
}
