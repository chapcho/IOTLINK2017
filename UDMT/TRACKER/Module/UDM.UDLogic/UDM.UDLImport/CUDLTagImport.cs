using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;
using System.Data;

namespace UDM.UDLImport
{
    public class CUDLTagImport
    {
        protected List<string> m_lstFile = null;

        protected DataSet m_dbMelsecCSV = null;
        protected CMelsecILConvert m_cMelsecILConvert = null;

        protected DataSet m_dbLS = null;
        protected CLSILConvert m_cLSILConvert = null;

        protected EMPLCMaker m_emPLCMaker;
        protected bool m_bFileOpenCheck = false;

        protected CTagS m_cTagS = null;

        #region Intialize/Dispose

        public CUDLTagImport()
        {
            //CFileOpen fileOpen = new CFileOpen();

            //m_bFileOpenCheck = fileOpen.FileOpenCheck;

            //if (m_bFileOpenCheck)
            //{

            //    m_emPLCMaker = fileOpen.PLCMaker;

            //    if (m_emPLCMaker == EMPLCMaker.Siemens)
            //    {
            //        m_lstFile = fileOpen.SDFFile;

            //        CS7TagImport cS7TagImprot = new CS7TagImport(m_lstFile);
            //        cS7TagImprot.TagFileAnalysis();

            //        /// <summary>
            //        /// GetAddressListTagS  will take a dictionary using address to dictionary key
            //        /// GetSymbelListTagS will take a dictionary using symbel to dictionary key
            //        /// </summary>

            //        m_cTagS = cS7TagImprot.GetKeyListTagS();
            //    }
            //    else if (m_emPLCMaker == EMPLCMaker.LS)
            //    {
            //        m_dbLS = fileOpen.dbLS;

            //        //m_cLSILConvert = new CLSILConvert(m_dbLS);
            //        m_cTagS = m_cLSILConvert.CreateLSTagS();
            //    }
            //    else if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi))
            //    {
            //        m_dbMelsecCSV = fileOpen.dbMelsecCSV;

            //        //m_cMelsecILConvert = new CMelsecILConvert(m_dbMelsecCSV);
            //        m_cTagS = m_cMelsecILConvert.CreateMelsecTagS();
            //    }
            //    else if (m_emPLCMaker == EMPLCMaker.Rockwell)
            //    {
            //        m_lstFile = fileOpen.L5kFile;

            //        CABTagImport cABTagImport = new CABTagImport(m_lstFile);

            //        cABTagImport.L5kTagAnalysis();

            //        m_cTagS = cABTagImport.GetClassTags();
            //    }
            //}
        }

        #endregion

        #region Public Properites

        public CTagS CtagS
        {
            get { return m_cTagS; }
        }

        public bool FileOpenCheck
        {
            get { return m_bFileOpenCheck; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
        }

        #endregion


    }
}