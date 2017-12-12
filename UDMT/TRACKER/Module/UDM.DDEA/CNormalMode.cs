using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.DDEA
{
    [Serializable]
    public class CNormalMode
    {
        #region Memeber Veriables
        
        protected CDDEASymbolList m_cWordSymbolList = new CDDEASymbolList();
        protected CDDEASymbolList m_cBitSymbolList = new CDDEASymbolList();
        protected CDDEASymbolList m_cIndexSymbolList = new CDDEASymbolList();
        protected CDDEASymbolList m_cIncludeIndexSymbolList = new CDDEASymbolList();

        #endregion


        #region Initialize

        public CNormalMode()
        {

        }

        #endregion


        #region Properties

        public CDDEASymbolList BitSymbolList
        {
            get { return m_cBitSymbolList; }
            set { m_cBitSymbolList = value; }
        }

        public CDDEASymbolList WordSymbolList
        {
            get { return m_cWordSymbolList; }
            set { m_cWordSymbolList = value; }
        }

        /// <summary>
        /// 기본적으로 그냥 워드 인덱스를 추출 편하게 하기위해 분리
        /// </summary>
        public CDDEASymbolList IndexSymbolList
        {
            get { return m_cIndexSymbolList; }
            set { m_cIndexSymbolList = value; }
        }

        /// <summary>
        /// 인덱스 접점의 원래 주소 값을 읽기 위해따로 추출해서 수집을 해야함.
        /// </summary>
        public CDDEASymbolList IncludeIndexSymbolList
        {
            get { return m_cIncludeIndexSymbolList; }
            set { m_cIncludeIndexSymbolList = value; }
        }

        #endregion


        #region Public Method

        #endregion


        #region Protected Method

        #endregion
    }
}
