using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILBuffer : ICloneable
    {
        private List<CILContact> m_ListContact = new List<CILContact>();
        private List<CILContact> m_ListBufferContact = new List<CILContact>();
        private List<CILContact> m_LinkHead = new List<CILContact>();
        private List<CILContact> m_LinkTail = new List<CILContact>();
        private int m_MergeDepth = 0;

        #region Initialize/Dispose

        public CILBuffer(List<CILContact> ListContact)
        {
            m_ListContact = ListContact.Clone();

            UpdateLink(m_ListContact);

            m_LinkHead = GetLinkHead(m_ListContact);
            m_LinkTail = GetLinkTail(m_ListContact);
        }

        public object Clone()
        {
            CILBuffer cILBuffer = (CILBuffer)this.MemberwiseClone();
            cILBuffer.m_ListContact = m_ListContact.Clone();
            cILBuffer.m_ListBufferContact = m_ListBufferContact.Clone();
            cILBuffer.m_LinkHead = m_LinkHead.Clone();
            cILBuffer.m_LinkTail = m_LinkTail.Clone();

            return cILBuffer;
        }

        #endregion


        #region Public interface

        public List<CILContact> ILContactS
        {
            get { return m_ListContact; }
            set { m_ListContact = value; }
        }

        public List<CILContact> ILBufferUnit
        {
            get { return m_ListBufferContact; }
            set { m_ListBufferContact = value; }
        }

        public List<CILContact> LinkHead
        {
            get { return m_LinkHead; }
        }

        public List<CILContact> LinkTail
        {
            get { return m_LinkTail; }
        }

        public int MergeDepth
        {
            get { return m_MergeDepth; }
            set { m_MergeDepth = value; }
        }

        #endregion

        #region Public Method

        public List<CILContact> AndBuffer(CILBuffer cILBuffer)
        {
            m_ListContact.AddRange(cILBuffer.ILContactS);

            foreach (CILContact cILContactHead in cILBuffer.LinkHead)
                foreach (CILContact cILContact in m_LinkTail)
                    cILContact.RelationS.Add(cILContactHead.ContactNum);

            m_LinkTail = cILBuffer.LinkTail;

            List<CILContact> lstMergeContact = GetUnMergeContactS(cILBuffer.ILBufferUnit);

            UpdateBufferContactS(cILBuffer.ILBufferUnit);

            return lstMergeContact;
        }

        public List<CILContact> OrBuffer(CILBuffer cILBuffer)
        {
            m_ListContact.AddRange(cILBuffer.ILContactS);
            m_LinkHead.AddRange(cILBuffer.LinkHead);
            m_LinkTail.AddRange(cILBuffer.LinkTail);

            List<CILContact> lstMergeContact = GetUnMergeContactS(cILBuffer.ILBufferUnit);

            UpdateBufferContactS(cILBuffer.ILBufferUnit);

            return lstMergeContact;
        }

        public void UpdateBufferContactS(List<CILContact> ListContact)
        {
            
            List<CILContact> lstMergeContact = new List<CILContact>();

            foreach (CILContact cILContact in ListContact)
            {
                m_ListContact.Add(cILContact);

                if (cILContact.eILOperator == EMOperaterType.Or)
                {
                    m_LinkHead.Add(cILContact);
                    m_LinkTail.Add(cILContact);
                }
                else
                {
                    foreach (CILContact cILContactTail in m_LinkTail)
                        cILContactTail.RelationS.Add(cILContact.ContactNum);

                    m_LinkTail.Clear();
                    m_LinkTail.Add(cILContact);
                }
            }

        }

        public List<CILContact> GetUnMergeContactS(List<CILContact> ListContact)
        {
            List<CILContact> lstUnMergeContact = new List<CILContact>();

            foreach (CILContact cILContact in ListContact)
            {
                if (m_MergeDepth != cILContact.MergeDepth)
                {
                    lstUnMergeContact.Add(cILContact);
                    continue;
                }
            }

            foreach (CILContact cILContact in lstUnMergeContact)
            {
                ListContact.Remove(cILContact);
            }

            return lstUnMergeContact;
        }


        public List<CILContact> GetMergeContactS(List<CILContact> ListContact)
        {
            List<CILContact> lstMergeContact = new List<CILContact>();

            foreach (CILContact cILContact in ListContact)
            {
                if (m_MergeDepth == cILContact.MergeDepth)
                {
                    lstMergeContact.Add(cILContact);
                    continue;
                }
            }

            foreach (CILContact cILContact in lstMergeContact)
            {
                ListContact.Remove(cILContact);
            }

            return lstMergeContact;
        }

        #endregion

        #region Private Method

        private bool UpdateLink(List<CILContact> ListContact)
        {
            List<CILContact> BufferPre = new List<CILContact>();
            List<CILContact> BufferCur = new List<CILContact>();

            int nCurrentCol = 0;

            if (ListContact.Count > 0)
                nCurrentCol = ListContact[0].CELL_COL;

            foreach (CILContact cILContact in ListContact)
            {
                if (cILContact.eILType == EILType.LINE)
                    continue;

                if (cILContact.IsLaod || cILContact.eILOperator == EMOperaterType.Or)
                {
                    BufferPre.Add(cILContact);
                }
                else
                {
                    foreach (CILContact cContactTemp in BufferPre)
                        cContactTemp.RelationS.Add(cILContact.ContactNum);

                    BufferCur.Add(cILContact);
                }

                if (cILContact.CELL_COL > nCurrentCol)
                {
                    BufferPre.Clear();
                    BufferPre.AddRange(BufferCur);
                    BufferCur.Clear();
                    nCurrentCol = cILContact.CELL_COL;
                }
            }

            return true;
        }

     

        private List<CILContact> GetLinkHead(List<CILContact> ListILContact)
        {
            List<CILContact> ContactS = new List<CILContact>();
            foreach (CILContact cILContact in ListILContact)
            {
                if (cILContact.eILType == EILType.LINE)
                    continue;

                if (cILContact.IsLaod || cILContact.eILOperator == EMOperaterType.Or)
                    ContactS.Add(cILContact);
            }

            return ContactS;
        }


        private List<CILContact> GetLinkTail(List<CILContact> ListILContact)
        {
            List<CILContact> ContactS = new List<CILContact>();
            foreach (CILContact cILContact in ListILContact)
            {
                if (cILContact.eILType == EILType.LINE)
                    continue;

                if (cILContact.IsLaod || cILContact.eILOperator == EMOperaterType.Or)
                    ContactS.Add(cILContact);
                else if (cILContact.eILOperator == EMOperaterType.And || cILContact.eILType == EILType.CONNECT_OPERATION)
                {
                    ContactS.Clear();
                    ContactS.Add(cILContact);
                }
            }

            return ContactS;
        }

        #endregion
    }
}
