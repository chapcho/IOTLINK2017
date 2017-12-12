using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Text.RegularExpressions;
using UDM.General.Serialize;
using Microsoft.Office.Interop.Excel;

namespace UDMIOMaker
{
    public delegate void UEventHandlerAutoMappingOKClick();

    public partial class FrmMappingOption : DevExpress.XtraEditors.XtraForm
    {
        private List<string> m_lstHMIGroup = null; 
        private double m_dMappingCount = -1;
        private double m_dTotalCount = -1;

        private string m_sSelectedGroup = string.Empty;
        private bool m_bOptionSetting = false;

        public UEventHandlerAutoMappingOKClick UEventAutoMappingOK;

        public FrmMappingOption()
        {
            InitializeComponent();
        }

        public List<string> HMIGroupS
        {
            get { return m_lstHMIGroup; }
            set { m_lstHMIGroup = value; }
        }

        public bool IsOptionSetting
        {
            get { return m_bOptionSetting; }
            set { m_bOptionSetting = value; }
        }

        public string SelectedGroup
        {
            get { return m_sSelectedGroup; }
            set { m_sSelectedGroup = value; }
        }

        private void ClearGroupUnitS()
        {
            CProjectManager.GroupConvertUnitS.Clear();
        }

        private DataSet GetDataSet()
        {
            if (m_lstHMIGroup.Count == 0)
                return null;

            DataSet DS = new DataSet();
            System.Data.DataTable DT;
            foreach (string sGroup in m_lstHMIGroup)
            {
                DT = new System.Data.DataTable();
                DT.Columns.Add("Current");
                DT.Columns.Add("Target");
                DT.TableName = sGroup;

                DataRow drRow;
                foreach (var who in CProjectManager.GroupConvertUnitS[sGroup])
                {
                    drRow = DT.NewRow();
                    drRow[0] = who.Current;
                    drRow[1] = who.Target;

                    DT.Rows.Add(drRow);
                }

                DS.Tables.Add(DT);
            }

            return DS;
        }

        private System.Data.DataTable GetDataTable(Worksheet ws)
        {
            System.Data.DataTable DT = null;

            string sTableName = ws.Cells[1, 1].ToString();

            if (sTableName.Contains("System"))
                return null;

            DT = new System.Data.DataTable();
            DT.TableName = sTableName;
            DT.Columns.Add("Current");
            DT.Columns.Add("Target");

            DataRow drRow = null;
            for (int i = 3; i < ws.Rows.Count; i++)
            {
                drRow = DT.NewRow();

                drRow[0] = ws.Rows[i][0];
                drRow[1] = ws.Rows[i][1];

                DT.Rows.Add(drRow);
            }

            return DT;
        }

        private void SetSheetData(Worksheet ws, System.Data.DataTable DT)
        {
            ws.Cells[1, 1] = DT.TableName;
            ws.Cells[2, 1] = "Current";
            ws.Cells[2, 2] = "Target";

            int iRowIndex = 3;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                ws.Cells[iRowIndex, 1] = DT.Rows[i][0];
                ws.Cells[iRowIndex, 2] = DT.Rows[i][1];

                iRowIndex++;
            }
        }

        private bool ExportToText(DataSet DS)
        {
            bool bOK = false;

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "*.csv|*.csv";
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return false;

            string sPath = dlgSave.FileName;

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = excelApp.Workbooks.Add(true);

            bOK = true;

            Worksheet worksheet = null;
            for (int i = 0; i < DS.Tables.Count; i++)
            {
                worksheet = (Worksheet) excelWorkbook.Sheets.Add();
                SetSheetData(worksheet, DS.Tables[i]);
            }

            excelWorkbook.SaveAs(sPath, XlFileFormat.xlWorkbookNormal, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;

            // Release the Application object   
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            excelApp = null;

            // Collect the unreferenced objects
            GC.Collect();
            GC.WaitForPendingFinalizers();
            

            return bOK;
        }

        private bool ImportToText()
        {
            bool bOK = false;

            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "*.xls|*.xls";
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return false;

            string sPath = dlgOpen.FileName;

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook excelWorkbook = excelApp.Workbooks.Open(sPath, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            DataSet DS = new DataSet();
            System.Data.DataTable DT;
            for (int i = 1; i <= excelWorkbook.Sheets.Count; i++)
            {
                DT = GetDataTable(excelWorkbook.Sheets[i]);

                if (DT == null)
                    continue;

                if (!m_lstHMIGroup.Contains(DT.TableName))
                {
                    XtraMessageBox.Show("Import하는 해당 Setting 파일의 HMI 그룹 " + DT.TableName
                                        + " Setting이 현재 HMI 태그 그룹에 존재하지 않습니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    bOK = false;
                    break;
                }
                DS.Tables.Add(DT);

                bOK = true;
            }

            if (bOK)
            {
                ClearGroupUnitS();
                SetGroupUnitS(DS);
            }

            excelWorkbook.Close(true, Type.Missing, Type.Missing);
            excelWorkbook = null;

            // Release the Application object   
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            excelApp = null;

            return bOK;
        }

        private void SetGroupUnitS(DataSet DS)
        {

            CConvertUnitS cUnitS;
            for (int i = 0; i < DS.Tables.Count; i++)
            {
                if (CProjectManager.GroupConvertUnitS.ContainsKey(DS.Tables[i].TableName))
                    continue;

                cUnitS = new CConvertUnitS();
                CProjectManager.GroupConvertUnitS.Add(DS.Tables[i].TableName, cUnitS);

                CConvertUnit cUnit;
                for (int j = 0; j < DS.Tables[i].Rows.Count; j++)
                {
                    cUnit = new CConvertUnit(DS.Tables[i].Rows[j][0].ToString(), DS.Tables[i].Rows[j][1].ToString());
                    cUnitS.Add(cUnit);
                }
            }
        }

        private bool ImportSetting()
        {
            bool bOK = false;

            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "*.uims|*.uims";
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return false;

            string sPath = dlgOpen.FileName;

            Dictionary<string, CConvertUnitS> cGroupUnitS = null;

            CNetSerializer cSerializer = new CNetSerializer();
            cGroupUnitS = (Dictionary<string, CConvertUnitS>)(cSerializer.Read(sPath));

            foreach (var who in cGroupUnitS)
            {
                if (!m_lstHMIGroup.Contains(who.Key))
                {
                    XtraMessageBox.Show(
                        "Import한 Setting의 " + who.Key +
                        "Group이 해당 HMI 태그 그룹에 존재하지 않는 그룹입니다.\r\n다른 Setting 파일을 Import 하세요.", "Import Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                    break;
                }
                bOK = true;
            }

            if (bOK)
            {
                ClearGroupUnitS();
                CProjectManager.GroupConvertUnitS = cGroupUnitS;
            }

            return bOK;
        }

        private bool ExportSetting()
        {
            bool bOK = false;

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "*.uims|*.uims";
            if (dlgSave.ShowDialog() != DialogResult.OK)
                return false;

            string sPath = dlgSave.FileName;

            CNetSerializer cSerializer = new CNetSerializer();
            bOK = cSerializer.Write(sPath, CProjectManager.GroupConvertUnitS);

            if (!bOK)
                return false;

            cSerializer.Dispose();
            cSerializer = null;
            bOK = true;

            return bOK;
        }

        private void FrmMappingOption_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string sGroup in m_lstHMIGroup)
                {
                    if (!cboGroupList.Properties.Items.Contains(sGroup))
                        cboGroupList.Properties.Items.Add(sGroup);
                }

                if (m_sSelectedGroup != string.Empty)
                {
                    cboGroupList.EditValue = m_sSelectedGroup;
                    grdConvertUnit.DataSource = CProjectManager.GroupConvertUnitS[m_sSelectedGroup];
                    grdConvertUnit.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CConvertUnit cUnit = new CConvertUnit("", "");
                CProjectManager.GroupConvertUnitS[m_sSelectedGroup].Add(cUnit);

                grdConvertUnit.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option Unit Add Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvConvertUnit.SelectedRowsCount > 1)
                {
                    XtraMessageBox.Show("하나의 Row만 선택하세요.", "Select Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvConvertUnit.FocusedRowHandle;

                if (iRowHandle < -1)
                    return;

                object obj = grvConvertUnit.GetRow(iRowHandle);

                if (obj == null)
                    return;

                if (obj.GetType() != typeof (CConvertUnit))
                    return;

                CConvertUnit cUnit = (CConvertUnit) obj;
                CProjectManager.GroupConvertUnitS[m_sSelectedGroup].Remove(cUnit);
                grdConvertUnit.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option Delete Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvConvertUnit.SelectedRowsCount > 1)
                {
                    XtraMessageBox.Show("하나의 Row만 선택하세요.", "Select Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvConvertUnit.FocusedRowHandle;

                if (iRowHandle <= 0)
                    return;

                CConvertUnit cUnit = (CConvertUnit) grvConvertUnit.GetRow(iRowHandle);
                CConvertUnitS cUnitS = (CConvertUnitS) grdConvertUnit.DataSource;

                cUnitS.Remove(cUnit);

                cUnitS.Insert(iRowHandle - 1, cUnit);
                grdConvertUnit.RefreshDataSource();

                grvConvertUnit.FocusedRowHandle = iRowHandle - 1;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("mapping Option Item Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvConvertUnit.SelectedRowsCount > 1)
                {
                    XtraMessageBox.Show("하나의 Row만 선택하세요.", "Select Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvConvertUnit.FocusedRowHandle;

                if (iRowHandle >= CProjectManager.GroupConvertUnitS[m_sSelectedGroup].Count - 1)
                    return;

                CConvertUnit cUnit = (CConvertUnit) grvConvertUnit.GetRow(iRowHandle);
                CConvertUnitS cUnitS = (CConvertUnitS) grdConvertUnit.DataSource;

                cUnitS.Remove(cUnit);

                cUnitS.Insert(iRowHandle + 1, cUnit);
                grdConvertUnit.RefreshDataSource();

                grvConvertUnit.FocusedRowHandle = iRowHandle + 1;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option Item Down Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bOptionSetting)
                {
                    if (
                        XtraMessageBox.Show("해당 \"" + m_sSelectedGroup + "\" 그룹의 자동 매핑을 진행하시겠습니까?", "Information",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (UEventAutoMappingOK != null)
                            UEventAutoMappingOK();

                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboGroupList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboGroupList.EditValue == null)
                    return;

                string sGroup = (string) cboGroupList.EditValue;

                if (sGroup == string.Empty)
                    return;

                m_sSelectedGroup = sGroup;

                grdConvertUnit.DataSource = CProjectManager.GroupConvertUnitS[sGroup];
                grdConvertUnit.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option Group Value Change Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnImportSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImportSetting())
                {
                    XtraMessageBox.Show("Import Setting Success!!", "Import", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    cboGroupList.EditValue = string.Empty;

                }
                else
                {
                    XtraMessageBox.Show("Import Setting Fail!!", "Import", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Import Setting Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExportSetting())
                {
                    XtraMessageBox.Show("Export Setting Success!!", "Export", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Export Setting Fail!!", "Export", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export Setting Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


    }
}