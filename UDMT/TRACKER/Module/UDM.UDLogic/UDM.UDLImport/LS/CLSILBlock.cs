using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDLImport
{
    public class CLSILBlock
    {
        private List<string> m_lstJointOperator = new List<string>();
        private Dictionary<string, CLSILPiece> m_lstBufferPiece = new Dictionary<string, CLSILPiece>();
        private List<CLSILPiece> m_lstMergePiece = new List<CLSILPiece>();

        private bool m_bMergeStart = false;
        
        #region Initialize/Dispose

        #endregion


        #region Properties

        public bool IsMergeStartBlock
        {
            get { return m_bMergeStart; }
            set { m_bMergeStart = value; }
        }

        public List<string> lstJoinOperator
        {
            get { return m_lstJointOperator; }
            set { m_lstJointOperator = value; }
        }

        public Dictionary<string, CLSILPiece> BufferPiece
        {
            get { return m_lstBufferPiece; }
            set { m_lstBufferPiece = value; }
        }

        public List<CLSILPiece> MergePiece
        {
            get { return m_lstMergePiece; }
            set { m_lstMergePiece = value; }
        }

        #endregion



        #region Public Methods

        #endregion



        #region Private Methods

        #endregion


    }
}

