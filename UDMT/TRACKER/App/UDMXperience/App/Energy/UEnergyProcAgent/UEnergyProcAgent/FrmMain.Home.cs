using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.EnergyProcAgent.Config;

namespace UEnergyProcAgent
{
    partial class FrmMain
    {

        #region Project

        private void OnNewProject()
        {
            
        }

        private void OnOpenProject()
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.uap|*.uap";
            dlgOpenFile.ShowDialog();

            string sFile = dlgOpenFile.FileName;
            if (sFile == "")
                return;

            m_cProject.Dispose();
            m_cProject = null;

            m_cProject = CProjectManager.Open(sFile);
        }

        private void OnSaveProject()
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.uap|*.uap";
            dlgSaveFile.ShowDialog();

            string sFile = dlgSaveFile.FileName;
            if (sFile == "")
                return;

            bool bOK = CProjectManager.Save(sFile, m_cProject);
            if (bOK)
                MessageBox.Show("File saved!!", "UEnergyProcAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Fail to save!!", "UEnergyProcAgent", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void OnConfig()
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog();
        }

        private void OnExit()
        {
            Application.Exit();
        }

        #endregion

    }
}
