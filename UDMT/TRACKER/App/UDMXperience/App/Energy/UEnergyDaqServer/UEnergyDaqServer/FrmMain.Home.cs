using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UEnergyDaqServer
{
    partial class FrmMain
    {
        #region Project

        private void OnNewProject()
        {
            
        }

        private void OnOpenProject()
        {
            
        }

        private void OnSaveProject()
        {

        }

        private void OnSaveAsProject()
        {

        }

        #endregion


        #region Control

        private void OnStartMonitor()
        {
            bool bOK = m_cMain.Start();
        }

        private void OnStopMonitor()
        {
            bool bOK = m_cMain.Stop();
        }

        private void OnExit()
        {
            Application.Exit();            
        }

        #endregion
    }
}
