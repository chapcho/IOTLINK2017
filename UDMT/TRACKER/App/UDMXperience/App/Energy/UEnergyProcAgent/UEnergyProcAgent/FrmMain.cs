using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;

namespace UEnergyProcAgent
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Member Variables

        private CProject m_cProject = new CProject();
        private CMainClass m_cMain = new CMainClass();


        #endregion


        #region Initialize/Dispose

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

        private void InitEnv()
        {
            ucProjectView.Project = m_cProject;

            ucProjectView.UEventAddServerChannelClicked += ucProjectView_UEventAddServerChannelClicked;
            ucProjectView.UEventAddServerClicked += ucProjectView_UEventAddServerClicked;
            ucProjectView.UEventAddSummaryClicked += ucProjectView_UEventAddSummaryClicked;
            ucProjectView.UEventAddSummaryTargetClicked += ucProjectView_UEventAddSummaryTargetClicked;

            dpnlConfig.VisibilityChanged += dpnlConfig_VisibilityChanged;
        }


        #endregion


        #region Event Methods

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitEnv();
        }

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
            OnStartMonitor();
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnStopMonitor();
        }

        private void btnConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnConfig();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnExit();
        }

        private void ucProjectView_UEventAddServerChannelClicked(object sender)
        {

        }

        private void ucProjectView_UEventAddServerClicked(object sender)
        {

        }

        private void ucProjectView_UEventAddSummaryClicked(object sender)
        {

        }

        private void ucProjectView_UEventAddSummaryTargetClicked(object sender)
        {

        }

        private void dpnlConfig_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            if(e.Visibility == DockVisibility.Hidden)
            {
                ucProjectView.Refresh();
            }
        }

        #endregion

    }
}
