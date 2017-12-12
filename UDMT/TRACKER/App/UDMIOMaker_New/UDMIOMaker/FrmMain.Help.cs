using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace UDMIOMaker
{
    partial class FrmMain
    {

        private void btnAboutIOMaker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrmMode frmMode = new FrmMode();
                frmMode.IsGroupPanelVisible = false;
                frmMode.ShowDialog();

                frmMode.Dispose();
                frmMode = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnFileExportGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMelsecGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\Guide\\Mitsubishi_File_Export_Guide.pdf";
                pdfViewer.LoadDocument(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSiemensGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\Guide\\Siemens_File_Export_Guide.pdf";
                pdfViewer.LoadDocument(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnABGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\Guide\\AB_File_Export_Guide.pdf";
                pdfViewer.LoadDocument(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnManual_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\Guide\\IOMaker_Manual_Guide.pdf";
                pdfViewer.LoadDocument(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnPDFClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                pdfViewer.CloseDocument();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }
}
