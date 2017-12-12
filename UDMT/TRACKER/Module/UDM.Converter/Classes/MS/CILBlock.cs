using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.General;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILBlock : ICloneable
    {
        private List<CILContact> m_ListBufferBlock = new List<CILContact>();
        private List<CILContact> m_ListBufferUnit = new List<CILContact>();

        private string m_sBlockStepNum = string.Empty;
        private string m_sLoadStepNum = string.Empty;
        private bool m_bUpdated = false;
        private bool m_bBranch = false;
        private bool m_bMerged = false;
        private bool m_bLast = false;

        #region Initialize/Dispose

        public CILBlock()
        {
        }

        public object Clone()
        {
            CILBlock cILBlock = (CILBlock)this.MemberwiseClone();
            cILBlock.m_ListBufferUnit = m_ListBufferUnit.Clone();
            cILBlock.m_ListBufferBlock = m_ListBufferBlock.Clone();

            return cILBlock;
        }

        public void Dispose()
        {

        }
        

        #endregion

        #region Public interface


        public List<CILContact> ILContactS
        {
            get {
                List<CILContact> lstContact = new List<CILContact>();
                lstContact.AddRange(m_ListBufferBlock);
                lstContact.AddRange(ILBufferUnit);
                return lstContact;
            }
        }

        public List<CILContact> ILBufferUnit
        {
            get { return m_ListBufferUnit; }
            set { m_ListBufferUnit = value; }
        }


        public List<CILContact> ILBufferBlock
        {
            get { return m_ListBufferBlock; }
            set { m_ListBufferBlock = value; }
        }

        public bool Updated
        {
            get { return m_bUpdated; }
            set { m_bUpdated = value; }
        }

        public bool IsBranch
        {
            get { return m_bBranch; }
            set { m_bBranch = value; }
        }

        public bool IsOrMerged
        {
            get { return m_bMerged; }
            set { m_bMerged = value; }
        }

        public bool IsLast
        {
            get { return m_bLast; }
            set { m_bLast = value; }
        }

        public string StepNumBlock
        {
            get { return m_sBlockStepNum; }
            set { m_sBlockStepNum = value; }
        }

        public string StepNumLoad
        {
            get { return m_sLoadStepNum; }
            set { m_sLoadStepNum = value; }
        }

        #endregion

        #region Public Method


        public void CleanBuffer()
        {
            m_ListBufferUnit.Clear();
            m_ListBufferBlock.Clear();
        }

        #endregion

        #region Private Method

      

        #endregion
    }

}
