using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDLImport
{
    public class CMelsecILBlock
    {

        private List<string> m_lstJoinOperator = new List<string>();
        private Dictionary<string, CMelsecILPiece> m_lstBufferPiece = new Dictionary<string, CMelsecILPiece>();
        private List<CMelsecILPiece> m_lstMergePiece = new List<CMelsecILPiece>();


        #region Initialize/Dispose

        #endregion


        #region Properties

        public List<string> lstJoinOperator
        {
            get { return m_lstJoinOperator; }
            set { m_lstJoinOperator = value; }
        }

        public Dictionary<string, CMelsecILPiece> BufferPiece
        {
            get { return m_lstBufferPiece; }
            set { m_lstBufferPiece = value; }
        }

        public List<CMelsecILPiece> MergePiece
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
