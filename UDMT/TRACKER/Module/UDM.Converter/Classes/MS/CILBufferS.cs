using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General;
using UDM.Common;
using System.Runtime.Serialization;

namespace UDM.Converter
{
    [Serializable]
    public class CILBufferS : Dictionary<int, CILBuffer>
    {
        private CPlcLogic m_cLogic = new CPlcLogic();
        private List<CILContact> m_ListMerge = new List<CILContact>();

        #region Initialize/Dispose

        public CILBufferS()
        {
        }

        protected CILBufferS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Public interface

        public CPlcLogic Logic
        {
            get { return m_cLogic; }
            set { m_cLogic = value; }
        }

        public List<CILContact> MergeContact
        {
            get { return m_ListMerge; }
            set { m_ListMerge = value; }
        }

        #endregion

        #region Public Method

        public void CreateBufferLogic(List<CILBlock> ListILBlock)
        {
            try
            {
                int nTotalBlock = m_cLogic.GetBlockCount();
                int nTotalLogic = m_cLogic.GetCount();

                int iOpen = 0;
                int iClose = 0;
                string sLogic = string.Empty;

                for (int i = 0; i < nTotalBlock; i++)
                {
                    for (int iLogic = 0; i < nTotalLogic; iLogic++)
                    {
                        if (m_cLogic.IsOpen(iLogic))
                            iOpen = iLogic;

                        if (m_cLogic.IsClose(iLogic))
                        {
                            iClose = iLogic;
                            SearchBuffer(iOpen, iClose, ListILBlock);
                            break;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

        #endregion

        #region Private Method


        private bool SearchBuffer(int iStart, int iEnd, List<CILBlock> ListILBlock)
        {
            CILBuffer cILBufferA = null;
            CILBuffer cILBufferB = null;

            string sOperator = string.Empty;

            for (int iLogic = iStart + 1; iLogic < iEnd; iLogic++)
            {
                if (cILBufferA == null)
                {
                    cILBufferA = GetSource(iLogic, ListILBlock);
                    continue;
                }

                if (sOperator == string.Empty)
                {
                    sOperator = m_cLogic.GetOperator(iLogic);
                    continue;
                }

                if (cILBufferB == null)
                {
                    cILBufferB = GetSource(iLogic, ListILBlock);
                    continue;
                }
            }

            m_cLogic.ModifyEmpty(iStart);
            m_cLogic.ModifyEmpty(iEnd);


            UpdateBuffer(cILBufferA, cILBufferB, iStart, sOperator);

            MergeBuffer();

            return true;
        }



        private CILBuffer GetSource(int iLogic, List<CILBlock> ListILBlock)
        {
            CILBuffer Source = null;
            int iBlock = 0;

            if (m_cLogic.IsSource(iLogic))
            {
                iBlock = m_cLogic.GetSource(iLogic);
                Source = new CILBuffer(ListILBlock[iBlock].ILBufferBlock);
                Source.ILBufferUnit = ListILBlock[iBlock].ILBufferUnit.Clone();
            }
            else if (m_cLogic.IsLocal(iLogic))
            {
                iBlock = m_cLogic.GetLocal(iLogic);
                Source = this[iBlock];
            }

            Source.MergeDepth = this.Count + 1;

            return Source;
        }

        private bool UpdateBuffer(CILBuffer SourceA, CILBuffer SourceB, int iStart, string sOperator)
        {
            if (m_cLogic.IsAnd(sOperator))
                m_ListMerge.AddRange(SourceA.AndBuffer(SourceB));

            else if (m_cLogic.IsOr(sOperator))
                m_ListMerge.AddRange(SourceA.OrBuffer(SourceB));

            this.Add(this.Count, SourceA);
            m_cLogic.AddLocal(iStart, this.Count - 1);

            return true;
        
        }

        private bool MergeBuffer()
        {
            if (this.Values.Count == 0)
                return false;
            
            List<CILContact> lstMergeContact = this.Values.Last().GetMergeContactS(m_ListMerge);

            this.Values.Last().UpdateBufferContactS(lstMergeContact);

            return true;
        }

        #endregion
    }
}
