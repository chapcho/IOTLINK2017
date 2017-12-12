using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.Common;
using UDM.Log;
using UDM.UDLImport;
using UDM.Project;
using UDM.UDL;

namespace UDM.UDLImport.Demo
{
    public partial class Form1 : Form
    {
        private CProject m_cProject = new CProject();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTagGenerate_Click(object sender, EventArgs e)
        {
            CUDLImport cTagImport = new CUDLImport(EMPLCMaker.ALL, false);

            if (cTagImport.FileOpenCheck)
            {
                cTagImport.MakeGlobelAndLocalTags();
                CTagS cTagS = cTagImport.GlobalTags;

                gcTag.DataSource = CreateTagSDatatype(cTagS);
                gcTag.RefreshDataSource();
            }
        }

        private void ViewSiemensUDLLogic(CUDLImport cLogic)
        {
            CMelsecILRung cView = null;
            List<CMelsecILRung> lstView = new List<CMelsecILRung>();
            string sProgram = string.Empty;

            foreach (var who in cLogic.CUDL.Blocks)
            {
                sProgram = who.Key;

                foreach (CUDLRoutine cRoutine in who.Value.Routines)
                {
                    foreach (CUDLLogic cUDLLogic in cRoutine.Logics)
                    {
                        cView = new CMelsecILRung();
                        cView.StepNum = cUDLLogic.StepIndex.ToString();
                        cView.Program = sProgram;
                        cView.UDL = cUDLLogic.Logic;

                        lstView.Add(cView);
                    }
                }
            }

            gcLogic.DataSource = lstView;
            gcLogic.RefreshDataSource();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CUDLImport cLogicImport = new CUDLImport(EMPLCMaker.ALL, false);
            cLogicImport.LsDDEAConnect = true;

            if (cLogicImport.FileOpenCheck)
            {
                cLogicImport.UDLGenerate();

                m_cProject.TagS = cLogicImport.GlobalTags;
                m_cProject.StepS = cLogicImport.StepS;

                gcTag.DataSource = m_cProject.TagS.Values.ToList(); //CreateTagSDatatype(m_cProject.TagS);
                gcTag.RefreshDataSource();

                if(cLogicImport.PLCMaker == EMPLCMaker.LS)
                {
                    gcLogic.DataSource = cLogicImport.DEBUG_LS.lstILRung;
                    gcLogic.RefreshDataSource();
                }
                else if (cLogicImport.PLCMaker == EMPLCMaker.Mitsubishi)
                {
                    gcLogic.DataSource = cLogicImport.DEBUG_Melsec.lstILRung;
                    gcLogic.RefreshDataSource();
                }
                else
                    ViewSiemensUDLLogic(cLogicImport);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CInstruXmlOpen cXMLOpen = new CInstruXmlOpen(EMPLCMaker.LS);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            CStepExtract.SplitStepS(m_cProject.StepS, m_cProject.TagS);

            FrmLadderView frmView = new FrmLadderView();
            frmView.TagS = m_cProject.TagS;
            frmView.StepS = m_cProject.StepS;
            frmView.ShowDialog();

            frmView.Dispose();
            frmView = null;
        }

        private DataTable CreateTagSDatatype(CTagS tempTagS)
        {
            DataTable cTempDT = new DataTable();

            try
            {
                DataColumn colKey = new DataColumn("Key", System.Type.GetType("System.String"));
                DataColumn colDatatype = new DataColumn("DataType", System.Type.GetType("System.String"));
                DataColumn colAddress = new DataColumn("Address", System.Type.GetType("System.String"));
                DataColumn colDescription= new DataColumn("Description", System.Type.GetType("System.String"));

                cTempDT.Columns.Add(colKey);
                cTempDT.Columns.Add(colDatatype);
                cTempDT.Columns.Add(colAddress);
                cTempDT.Columns.Add(colDescription);

                foreach (CTag tempTag in tempTagS.Values)
                {
                    DataRow tempRow = cTempDT.NewRow();

                    tempRow[0] = tempTag.Key;
                    tempRow[1] = tempTag.DataType.ToString();
                    tempRow[2] = tempTag.Address;
                    tempRow[3] = tempTag.Description;

                    cTempDT.Rows.Add(tempRow);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                return null;
            }
            return cTempDT;
        }

        private void btnOpenAll_Click(object sender, EventArgs e)
        {
            ////CUDLNewCommonImport cLogicImport = new CUDLNewCommonImport();


            //cLogicImport.AllPLCAnalysis();


            //if (cLogicImport.FileOpenCheck)
            //{
            //    //m_cProject.TagS = cLogicImport.PLC.TagS;
                
            //    //gcTag.DataSource = CreateTagSDatatype(m_cProject.TagS);
            //    //gcTag.RefreshDataSource();

            //    //if (cLogicImport.PLCMaker == EMPLCMaker.LS)
            //    //{
            //    //    gcLogic.DataSource = cLogicImport.DEBUG_LS.lstILRung;
            //    //    gcLogic.RefreshDataSource();
            //    //}
            //    //else if (cLogicImport.PLCMaker == EMPLCMaker.Mitsubishi)
            //    //{
            //    //    gcLogic.DataSource = cLogicImport.DEBUG_Melsec.lstILRung;
            //    //    gcLogic.RefreshDataSource();
            //    //}
            //}
        }
    }
}
