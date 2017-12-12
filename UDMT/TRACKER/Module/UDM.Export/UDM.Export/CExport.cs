using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.General;
using UDM.General.Csv;

namespace UDM.Export
{
    public delegate void UEventHandlerExcelExportProcess(object sender, int nProcess);

    public class CExport
    {
        public event UEventHandlerExcelExportProcess UEventExcelExportProcess;

        public CExport()
        {
            
        }
        public bool ExportExcel(CTagS cTagS, string sPath, eExcelListType ExcelListType, string sPLCMaker)
        {
            if (sPLCMaker == ePLC_MAKER.MITSUBISHI_WORKS3)
                sPLCMaker = ePLC_MAKER.MITSUBISHI_WORKS2;


            PlcHelper._PLCMAKER = sPLCMaker;
            CUIODataSet cUIODataSet = new CUIODataSet(ExcelListType);
            DataSet ds = cUIODataSet.CreateDataSet(cTagS);

            if (ExcelExport(sPath, ds, ExcelListType))
                return true;
            else
                return false;
        }

        private bool ExcelExport(string strOutPath, DataSet ds, eExcelListType ExcelListType)
        {
            string strInputPath = string.Empty;
            string OutPath = (string)strOutPath;

            if (ExcelListType == eExcelListType.IO)
                strInputPath = PlcHelper.GetExcelTemplatePathIOLIST();
            if (ExcelListType == eExcelListType.DUMMY)
                strInputPath = PlcHelper.GetExcelTemplatePathDUMMYLIST();
            if (ExcelListType == eExcelListType.LINK)
                strInputPath = PlcHelper.GetExcelTemplatePathLINKLIST();
            if (ExcelListType == eExcelListType.TIMECOUNT)
                strInputPath = PlcHelper.GetExcelTemplatePathTIMECOUNTERLIST();

            var finfo = new FileInfo(strInputPath);
            if (!finfo.Exists)
                return false;
                
            string strCoverName = "Project";
            ExcelHelper.UEventProcessChanged += ExcelHelper_UEventProcessChanged;
            ExcelHelper.ExportToExcel(ds, strInputPath, OutPath, 0, strCoverName, PlcHelper.GetTypeOutput());
            Console.WriteLine("Export Success Open file \r\n" + OutPath);

            ExcelHelper.UEventProcessChanged -= ExcelHelper_UEventProcessChanged;

            return true;
        }

        private void ExcelHelper_UEventProcessChanged(object sender, int nProcess)
        {
            if (UEventExcelExportProcess != null)
            {
                if (nProcess > 99)
                    nProcess = 99;

                UEventExcelExportProcess(null, nProcess);
            }
        }

    }

}
