using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7TestHelper
    {
        // Create by Qin Shiming at 2015.07.05
        //
        #region MemberVariables
        List<string> m_lsSDFFile = null;
        List<string> m_lsAWLFile = null;
        CS7TagAnalysis m_cTagAnalysis = null;
        CS7AWLFileAnalysis m_cAWLfileAnalysis = null;

        //CTagS m_dSymbolTags = null;
        CTagS m_dAddressTags = null;
        CTagS m_dKeyListTags = null;
        Dictionary<string, CS7UDT> m_dUDTDic = null;
        Dictionary<string, CS7DataBlock> m_dDBDic = null;
        Dictionary<string, CS7Block> m_dBlockDic = null;

        CStepS m_dTotalStep = null;

        string m_sChannel = "";

        #endregion

        #region  Initialze/Dispose
        public CS7TestHelper()
        {

        }
        #endregion

        #region Public Properites
        public List<string> SDFFile
        {
            get { return m_lsSDFFile; }
        }
        public List<string> AWLFile
        {
            get { return m_lsAWLFile; }
        }

        //public CTagS SymbolTags
        //{
        //    get { return m_dSymbolTags; }
        //}
        public CTagS KeyListTags
        {
            get { return m_dKeyListTags; }
        }
        public CTagS AddressTags
        {
            get { return m_dAddressTags; }
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
        public CStepS TotalStepS
        {
            get { return m_dTotalStep; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        #endregion


        #region Public Methods

        public void S7ProjectAnalysis()
        {
            CS7FileOpen cS7File = new CS7FileOpen();

            m_lsAWLFile = cS7File.AWLFile;
            m_lsSDFFile = cS7File.SDFFile;

            m_cTagAnalysis = new CS7TagAnalysis(m_lsSDFFile);
            m_cTagAnalysis.Channel = m_sChannel;
            m_cTagAnalysis.TagFileAnalysis();

            m_dAddressTags = m_cTagAnalysis.AddressTagDic;
            //m_dSymbolTags = m_cTagAnalysis.SymbolTagDic;

            m_cAWLfileAnalysis = new CS7AWLFileAnalysis(m_lsAWLFile, m_dAddressTags);
            m_cAWLfileAnalysis.AWLFileAnalysis();

            m_dUDTDic = m_cAWLfileAnalysis.UDTDic;
            m_dDBDic = m_cAWLfileAnalysis.DBDic;
            m_dBlockDic = m_cAWLfileAnalysis.BlockDic;

            m_dTotalStep = m_cAWLfileAnalysis.StepList;
            GetKeyListCtagS();
        }
        #endregion

        #region Private Methods

        public void GetKeyListCtagS()
        {
            try
            {
                m_dKeyListTags = new CTagS();

                foreach(CTag tempTag in m_dAddressTags.Values)
                {
                    m_dKeyListTags.Add(tempTag.Key, tempTag);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        #endregion
    }
}
