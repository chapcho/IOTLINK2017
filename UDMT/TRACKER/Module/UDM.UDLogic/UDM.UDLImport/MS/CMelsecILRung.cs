using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDLImport
{
    public class CMelsecILRung
    {

        private List<CMelsecILBlock> m_lstBlock = new List<CMelsecILBlock>();
        private List<CMelsecILPiece> m_lstILPiece = new List<CMelsecILPiece>();

        private string m_sProgram = string.Empty;
        private string DEBUG_UDL = string.Empty;
        private string m_sStepNum = string.Empty;

        private bool m_bMergePairCheck = false;
        private int m_iValidILSymbolCount = 0;
        private bool m_bCheckValidSymbolCount = false;


        #region Initialize/Dispose

        #endregion


        #region Properties

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public string StepNum
        {
            get { return m_sStepNum; }
            set { m_sStepNum = value; }
        }

        public string UDL
        {
            get { return DEBUG_UDL; }
            set { DEBUG_UDL = value; }
        }

        public List<CMelsecILBlock> BLOCKS
        {
            get { return m_lstBlock; }
            set { m_lstBlock = value; }
        }

        public List<CMelsecILPiece> Logic
        {
            get { return m_lstILPiece; }
            set { m_lstILPiece = value; }
        }

        public bool MergePairCheck
        {
            get { return m_bMergePairCheck; }
            set { m_bMergePairCheck = value; }
        }

        public bool ValidSymbolCountCheck
        {
            get { return m_bCheckValidSymbolCount; }
            set { m_bCheckValidSymbolCount = value; }
        }

        public int ValidILSymbolCount
        {
            get { return m_iValidILSymbolCount; }
            set { m_iValidILSymbolCount = value; }
        }
        
        #endregion

        #region Public Methods

        public void MakeUDL()
        {
            foreach (CMelsecILPiece ILPiece in Logic)
                DEBUG_UDL += ILPiece.UDL;

            CheckMergePair();
            CheckValidateSymbolCount();
        }

        #endregion


        #region Private Methods

        private void CheckMergePair()
        {
            int iMergeOpenCount = 0;
            int iMergeCloseCount = 0;

            for(int i = 0 ; i < DEBUG_UDL.Length ; i++)
            {
                if (DEBUG_UDL[i].Equals('['))
                    iMergeOpenCount++;
                else if (DEBUG_UDL[i].Equals(']'))
                    iMergeCloseCount++;
            }

            if (iMergeCloseCount == iMergeOpenCount)
                m_bMergePairCheck = true;
            else
                m_bMergePairCheck = false;
        }

        private void CheckValidateSymbolCount()
        {
            int iValidUDLSymbolCount = 0;

            for (int i = 0; i < DEBUG_UDL.Length; i++)
            {
                if (DEBUG_UDL[i].Equals('('))
                    iValidUDLSymbolCount++;
            }

            if (m_iValidILSymbolCount == iValidUDLSymbolCount)
                m_bCheckValidSymbolCount = true;
            else
                m_bCheckValidSymbolCount = false;

        }


        #endregion
    }
}
