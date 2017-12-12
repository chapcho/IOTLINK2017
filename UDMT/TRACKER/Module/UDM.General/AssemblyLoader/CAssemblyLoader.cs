using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace UDM.General.AssemblyLoader
{
    public static class CAssemblyLoader
    {

        #region Member Variables

        private static List<string> m_lstResult = new List<string>();
        private static AppDomain m_appDomain = null;
        private static Assembly m_cAssemblyExecuting = null;
        private static string m_sAppNameSpace = "";

        #endregion


        #region Public Properties

        public static AppDomain CurrentDomain
        {
            get { return m_appDomain; }
            set { SetAppDomain(value); }
        }

        public static Assembly ExecutingAssembly
        {
            get { return m_cAssemblyExecuting; }
            set { m_cAssemblyExecuting = value; }
        }

        public static string AppNameSpace
        {
            get { return m_sAppNameSpace; }
            set { m_sAppNameSpace = value; }
        }
        
        public static List<string> Result
        {
            get { return m_lstResult; }
        }

        #endregion


        #region Public Methods

        public static void Load(List<string> lstLibrary)
        {
            if (lstLibrary == null)
                return;

            string sLibrary;
            Assembly cAssembly;
            for (int i = 0; i < lstLibrary.Count; i++)
            {
                sLibrary = lstLibrary[i];
                sLibrary = m_sAppNameSpace + "." + sLibrary;
                cAssembly = LoadLibrary(sLibrary);
                if (cAssembly != null)
                    m_lstResult.Add(sLibrary);
            }
        }

        #endregion


        #region Private Methods

        private static void SetAppDomain(AppDomain appDomain)
        {
            if (m_appDomain != null)
                m_appDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            m_appDomain = appDomain;
            if (m_appDomain != null)
                m_appDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            string[] saInfo = e.Name.Split(',');
            string sName = saInfo[0].Trim();
            string sLibrary = m_sAppNameSpace + "." + sName + ".dll";

            Assembly cAssembly = LoadLibrary(sLibrary);
            if (cAssembly != null)
                m_lstResult.Add(sLibrary);

            return cAssembly;
        }

        private static Assembly LoadLibrary(string sLibrary)
        {
            if (m_cAssemblyExecuting == null)
                return null;

            Assembly cAssembly = null;

            string[] saNames = m_cAssemblyExecuting.GetManifestResourceNames();
            try
            {
                using (var memStream = m_cAssemblyExecuting.GetManifestResourceStream(sLibrary))
                {
                    if (memStream == null)
                        return null;

                    byte[] memData = new byte[memStream.Length];
                    memStream.Read(memData, 0, memData.Length);
                    
                    cAssembly = Assembly.Load(memData);
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return cAssembly;
        }

        #endregion

    }
}
