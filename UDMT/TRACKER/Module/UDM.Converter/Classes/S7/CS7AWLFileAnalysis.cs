using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using System.IO;
using System.Windows.Forms;

namespace UDM.Converter
{
    public class CS7AWLFileAnalysis
    {
        // Create by Qin Shiming at 2015.06.26
        // Second edit at 2015.07.05 by Qin Shiming
        //
        #region MemberVariables

        protected List<string> m_lFile = null;
        //protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;

        protected CStepS m_lStepList = null;
        protected Dictionary<string, CS7UDT> m_dUDTDic = null;
        protected Dictionary<string, CS7DataBlock> m_dDBDic = null;
        protected Dictionary<string, CS7Block> m_dBlockDic = null;

        protected CS7DBAnalysis m_cDBAnalysis = null;
        protected CS7UDTAnalysis m_cUDTAnalysis = null;
        protected CS7STLAnalysis m_cSTLAnalysis = null;
        protected CS7BlockAnalysis m_cBlockAnalysis = null;

        #endregion

        #region Initialze/Dispose

        public CS7AWLFileAnalysis(List<string> files,  CTagS AddressTags)
        {
            m_lFile = files;
            //m_dSymbolTags = SymbolTags;
            m_dAddressTags = AddressTags;

            m_cDBAnalysis = new CS7DBAnalysis();
            m_cUDTAnalysis = new CS7UDTAnalysis();
            m_cSTLAnalysis = new CS7STLAnalysis(m_dAddressTags);
            m_cBlockAnalysis = new CS7BlockAnalysis(m_dAddressTags);

            m_cDBAnalysis.AddressTags = AddressTags;
            //m_cDBAnalysis.SymbolTags = SymbolTags;
            m_cDBAnalysis.BlockDic = m_cBlockAnalysis.BlockDic;

            m_cUDTAnalysis.AddressTags = AddressTags;
            //m_cUDTAnalysis.SymbolTags = SymbolTags;

            m_cBlockAnalysis.DBDic = m_cDBAnalysis.DBDic;
            m_cBlockAnalysis.UDTDic = m_cUDTAnalysis.UDTDic;
            m_cBlockAnalysis.LogicAnalysis = m_cSTLAnalysis;

            m_cSTLAnalysis.DBDic = m_cDBAnalysis.DBDic;
            m_cSTLAnalysis.UDTDic = m_cUDTAnalysis.UDTDic;
            m_cSTLAnalysis.BlockDic = m_cBlockAnalysis.BlockDic;

            m_dUDTDic = m_cUDTAnalysis.UDTDic;
            m_dDBDic = m_cDBAnalysis.DBDic;
            m_dBlockDic = m_cBlockAnalysis.BlockDic;

            m_lStepList = m_cSTLAnalysis.TotalStep;
        }

        #endregion

        #region Public Properites

        public CStepS StepList
        {
            get { return m_lStepList; }
        }
        public Dictionary<string, CS7UDT> UDTDic
        {
            get { return m_dUDTDic; }
        }
        public Dictionary<string, CS7DataBlock> DBDic
        {
            get { return m_dDBDic; }
        }
        public Dictionary<string, CS7Block> BlockDic
        {
            get { return m_dBlockDic; }
        }
        public Dictionary<string, string> TagCoilUseDic
        {
            get { return m_cSTLAnalysis.TagCoilUseDic; }
        }
        public Dictionary<string, string> TagContactUseDic
        {
            get { return m_cSTLAnalysis.TagContactUseDic; }
        }
        #endregion

        #region Public Methods

        public void AWLFileAnalysis()
        {
            try
            {
                int count = m_lFile.Count;
                for (int i = 0; i < count; i++)
                {

                    if (m_lFile[i].StartsWith("DATA_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lFilePart = new List<string>();
                        lFilePart.Add(m_lFile[i]);

                        while (m_lFile[j] != "END_DATA_BLOCK")
                        {
                            lFilePart.Add(m_lFile[j]);
                            j++;
                        }
                        lFilePart.Add(m_lFile[j]);
                        i = j;

                        m_cDBAnalysis.UDTDic = m_dUDTDic;
                        m_cDBAnalysis.DBListAnalysis(lFilePart);

                        lFilePart.Clear();
                    }
                    else if (m_lFile[i].StartsWith("FUNCTION_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lFilePart = new List<string>();
                        lFilePart.Add(m_lFile[i]);
                        while (m_lFile[j] != "END_FUNCTION_BLOCK")
                        {

                            lFilePart.Add(m_lFile[j]);
                            j++;
                        }

                        lFilePart.Add(m_lFile[j]);
                        i = j;

                        m_cBlockAnalysis.FunctionAnalysis(lFilePart);

                        lFilePart.Clear();
                    }
                    else if (m_lFile[i].StartsWith("FUNCTION"))
                    {

                        int j = i + 1;
                        List<string> lFilePart = new List<string>();
                        lFilePart.Add(m_lFile[i]);
                        while (m_lFile[j] != "END_FUNCTION")
                        {
                            lFilePart.Add(m_lFile[j]);
                            j++;
                        }

                        lFilePart.Add(m_lFile[j]);
                        i = j;

                        m_cBlockAnalysis.FunctionAnalysis(lFilePart);

                        lFilePart.Clear();
                    }
                    else if (m_lFile[i].StartsWith("TYPE"))
                    {
                        int j = i + 1;
                        List<string> lFilePart = new List<string>();
                        lFilePart.Add(m_lFile[i]);
                        while (m_lFile[j] != "END_TYPE")
                        {
                            lFilePart.Add(m_lFile[j]);
                            j++;
                        }

                        lFilePart.Add(m_lFile[j]);
                        i = j;

                        m_cUDTAnalysis.DatatypeListAnalysis(lFilePart);

                        lFilePart.Clear();
                    }
                    else if (m_lFile[i].StartsWith("ORGANIZATION_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lFilePart = new List<string>();
                        lFilePart.Add(m_lFile[i]);
                        while (m_lFile[j] != "END_ORGANIZATION_BLOCK")
                        {
                            lFilePart.Add(m_lFile[j]);
                            j++;
                        }

                        lFilePart.Add(m_lFile[j]);
                        i = j;

                        m_cBlockAnalysis.FunctionAnalysis(lFilePart);

                        lFilePart.Clear();
                    }

                }

                List<string> unKnowBlockList = m_cSTLAnalysis.UnknowBlock;

                if (unKnowBlockList.Count>0)
                {
                    count = unKnowBlockList.Count;

                    string sTemp = string.Empty;

                    for (int i = 0; i < count; i++)
                    {
                        if (i == 0)
                            sTemp = unKnowBlockList[i];
                        else
                            sTemp = sTemp + " , " + unKnowBlockList[i];
                    }

                    //MessageBox.Show("There are some unknown Blocks : "+ sTemp);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
