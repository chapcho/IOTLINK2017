using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDPLC:CObject,IDisposable,ICloneable
    {
        #region Member Variables

        protected string m_sProjectName = string.Empty;
        protected string m_sPLCModel = string.Empty;
        protected CLDModuleS m_cModuleS = null;
        protected CLDBlockS m_cBlockS = null;
        protected EMPLCMaker m_emPLCMaker = EMPLCMaker.Mitsubishi;
        protected CTagS m_cTagS = null;

        #endregion

        #region Initialize/Dispose

        public CLDPLC()
        {
            m_cBlockS = new CLDBlockS();
            m_cModuleS = new CLDModuleS();
            m_cTagS = new CTagS();
        }

        public new void Dispose()
        {
            m_cBlockS.Clear();
            m_cModuleS.Clear();
            m_cTagS.Clear();

            base.Dispose();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Project Name
        /// </summary>
        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }

        /// <summary>
        /// PLC Model 
        /// </summary>
        public string PLCModel
        {
            get { return m_sPLCModel; }
            set { m_sPLCModel = value; }
        }


        public CLDBlockS BlockS
        {
            get { return m_cBlockS; }
            set { m_cBlockS = value; }
        }

        public CLDModuleS ModuleS
        {
            get { return m_cModuleS; }
            set { m_cModuleS = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CLDPLC tempPLC = new CLDPLC();

            tempPLC.Key = m_sKey;
            tempPLC.ProjectName = m_sProjectName;
            tempPLC.PLCModel = m_sPLCModel;
            tempPLC.PLCMaker = m_emPLCMaker;
            tempPLC.TagS = (CTagS)m_cTagS.Clone();
            tempPLC.ModuleS = (CLDModuleS)m_cModuleS.Clone();
            tempPLC.BlockS = (CLDBlockS)m_cBlockS.Clone();

            return tempPLC;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
