using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDLRoutine:IDisposable
    {

        protected List<CUDLLogic> m_lstLogic = new List<CUDLLogic>();
        protected string m_sRoutionName = string.Empty;
        protected Dictionary<string,CUDLLogic> m_dicJumpLogic = new Dictionary<string,CUDLLogic>();

        #region Intialize/Dispose

        public CUDLRoutine()
        {
        }

        public void Dispose()
        {
            m_lstLogic.Clear();
            m_dicJumpLogic.Clear();
        }
        #endregion

        #region Public Properties

        public List<CUDLLogic> Logics
        {
            get { return m_lstLogic; }
            set { m_lstLogic = value; }
        }

        public string RoutineName
        {
            get { return m_sRoutionName; }
            set { m_sRoutionName = value; }
        }
        
        public Dictionary<string,CUDLLogic> JumpLabalS
        {
            get { return m_dicJumpLogic; }
            set { m_dicJumpLogic = value; }
        }
        #endregion

        #region Public Methods

        public List<string> GetStringsRotineLogicS()
        {
            List<string> FullFile = new List<string>();
            try
            {
                int iCount = m_lstLogic.Count;
                FullFile.Add("ROUTINE  " + m_sRoutionName);

                string sTemp = string.Empty;
                
                for (int i = 0; i < iCount; i++)
                {
                    sTemp = "\tN" + m_lstLogic[i].StepIndex.ToString() + " : ";
                    sTemp = sTemp + m_lstLogic[i].Logic + ";";

                    FullFile.Add(sTemp);

                }
                FullFile.Add("END_ROUTINE");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return FullFile;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
