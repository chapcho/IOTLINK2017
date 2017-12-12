using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Log;
using UDM.Log.Csv;

namespace UDMEnergyViewer
{
	partial class FrmMain
	{

		#region Private Methods

        private void AddPlcLog()
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.Multiselect = true;
            dlgOpenFile.ShowDialog();
            if (dlgOpenFile.FileNames == null || dlgOpenFile.FileNames.Length == 0)
                return;

            string[] saFile = dlgOpenFile.FileNames;

            CTagLogReader cLogReader = new CTagLogReader();
            bool bOK = cLogReader.Open(saFile);
            if (bOK)
            {
                m_cTagItemS = cLogReader.Read(CProjectManager.Project.TagS);
                if (m_cTagItemS != null)
                {
                    m_cTagItemS.UpdateTimeRange();
                    CProjectManager.Project.TagItemS = m_cTagItemS;
                }
            }
            else
            {
                UpdateSystemMessage("Stop", "수집한 로그를 열 수 없습니다.");
            }

            cLogReader.Close();
            cLogReader = null;
        }

        private void ClearPlcLog()
        {
            m_cTagItemS.Clear();
        }

        private void AddMeterLog()
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.ShowDialog();
            if (dlgOpenFile.FileName == "")
                return;

            string sFile = dlgOpenFile.FileName;
            CMeterLogReader cLogReader = new CMeterLogReader();
            bool bOK = cLogReader.Open(sFile);
            if (bOK)
            {
                m_cMeterItemS = cLogReader.Read();
                m_cMeterItemS.UpdateTimeRange();

                CProjectManager.Project.MeterItemS = m_cMeterItemS;
            }
            else
            {
                UpdateSystemMessage("Stop", "수집한 로그를 열 수 없습니다.");
            }
        }

        private void ClearMeterLog()
        {
            m_cMeterItemS.Clear();
        }

        private void ShowChart()
        {
            FrmChartViewer frmViewer = new FrmChartViewer();
            frmViewer.TagItemS = CProjectManager.Project.TagItemS;
            //frmViewer.CoilTagItemS = CProjectManager.Project.CoilTagItemS;
            frmViewer.MeterItemS = CProjectManager.Project.MeterItemS;
            frmViewer.Show();
        }

        private void ClassifyCoil()
        {
            FrmClassifySymbol frmSymbol = new FrmClassifySymbol();
            frmSymbol.TagItemS = CProjectManager.Project.TagItemS;
            frmSymbol.MeterItemS = CProjectManager.Project.MeterItemS;
            frmSymbol.ShowDialog();
        }

        private void EnergyAnalysis()
        {
            FrmAnalysis frmAnalysis = new FrmAnalysis();
            frmAnalysis.ShowDialog();
        }

        private bool Calibration()
        {
            bool bOK = false;

            if (CProjectManager.Project.TagItemS.Count == 0 || CProjectManager.Project.MeterItemS.Count == 0)
            {
                MessageBox.Show("Import PLC/Energy Data First!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bOK = false;
                return bOK;
            }

            FrmCalibration frmCalib = new FrmCalibration();
            frmCalib.TagItemS = CProjectManager.Project.TagItemS;
            frmCalib.MeterItemS = CProjectManager.Project.MeterItemS;
            if (frmCalib.ShowDialog() == DialogResult.OK)
                bOK = true;

            return bOK;
        }

		#endregion
	}
}
