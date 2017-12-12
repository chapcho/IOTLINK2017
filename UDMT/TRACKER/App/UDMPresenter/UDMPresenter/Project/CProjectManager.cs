using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.General.Serialize;
using UDM.General.Csv;
using UDM.Common;

namespace UDMPresenter
{
	public static class CProjectManager
	{

		#region Member Varialbes

        private static Dictionary<string, CProject> m_dicProject = new Dictionary<string, CProject>();

        private static CProject m_cSelectedProject = null;
		private static UCTagTable m_ucTagTable = null;
		private static UCSymbolTable m_ucSymbolTable = null;

		#endregion


		#region Inialize/Dispose


		#endregion


		#region Public Properties
        
        public static Dictionary<string, CProject> ProjectList
		{
			get { return m_dicProject; }
		}

		public static UCTagTable TagTable
		{
			get { return m_ucTagTable; }
			set { m_ucTagTable = value; }
		}

		public static UCSymbolTable SymbolTable
		{
			get { return m_ucSymbolTable; }
			set { m_ucSymbolTable = value; }
		}
        
        public static CProject SelectedProject
        {
            get { return m_cSelectedProject; }
            set { m_cSelectedProject = value; }
        }


		#endregion


		#region Public Methods

		public static bool New(string sName)
		{
			Clear();
            
            CProject cProject = new CProject();
            cProject.Name = sName;

            m_dicProject.Add(sName, cProject);
            m_cSelectedProject = cProject;

			UpdateView();
            
            return true;
		}

		public static bool Open(string sPath)
		{
			Clear();

			bool bOK = false;

			CNetSerializer cSerializer = new CNetSerializer();
            object oData = cSerializer.Read(sPath);
            if (oData == null) return false;
            try
            {
                m_dicProject = (Dictionary<string, CProject>)(oData);
                if (m_dicProject != null)
                bOK = true;
            }
            catch(Exception ex)
            {
                return false;
            }

            foreach (var who in m_dicProject)
            {
                if (who.Value.StepS != null)
                    who.Value.StepS.Compose(who.Value.TagS);
            }

            if (m_dicProject.Count == 0) return false;

            m_cSelectedProject = m_dicProject.First().Value;

			cSerializer.Dispose();
			cSerializer = null;

			UpdateView();
            
			return bOK;
		}

		public static bool Save(string sPath)
		{
			bool bOK = false;
            foreach (var who in m_dicProject)
                who.Value.Path = sPath;

			CNetSerializer cSerializer = new CNetSerializer();
			bOK = cSerializer.Write(sPath, m_dicProject);

			cSerializer.Dispose();
			cSerializer = null;

			UpdateView();

			return bOK;
		}

		public static void Clear()
		{
			m_dicProject.Clear();

			UpdateView();

            RemoveTagTable();
		}

        public static bool AddProject(CProject cProject)
        {
            if (cProject == null) return false;
            if (cProject.Name == "") return false;
            if (m_dicProject.ContainsKey(cProject.Name)) return false;

            m_dicProject.Add(cProject.Name, cProject);
            m_cSelectedProject = cProject;

            UpdateView();

            return true;
        }

        public static bool DeleteSelectedProject()
        {
            m_dicProject.Remove(m_cSelectedProject.Name);
            if (m_dicProject.Count > 0)
                m_cSelectedProject = m_dicProject.First().Value;
            else
                m_cSelectedProject.Clear();
            
            UpdateView();
            return true;
        }

		public static void UpdateView()
		{
            if (m_cSelectedProject == null) return;
			if (m_ucTagTable != null)
                m_ucTagTable.ShowTable(m_cSelectedProject.TagS);

			if (m_ucSymbolTable != null)
                m_ucSymbolTable.ShowTable(m_cSelectedProject.SymbolS);
		}

		public static bool ImportTagS(string sPath, string sChannel)
		{
			bool bOK = true;
			CCsvReader cReader = null;

			try
			{
				cReader = new CCsvReader();
				bOK = cReader.Open(sPath, true);
				if (bOK == false)
					return false;

				CTag cTag;
				string sKey = string.Empty;
				List<string> lstValue = null;
				while (cReader.EOF == false)
				{
					lstValue = cReader.ReadLine();
					if (lstValue != null && lstValue.Count > 2)
					{
						sKey = string.Format("{0}.{1}[{2}]", sChannel, lstValue[0], 1);
						if (m_cSelectedProject.TagS.ContainsKey(sKey))
							continue;

						cTag = new CTag();
						cTag.Key = sKey;
						cTag.Address = lstValue[0].ToUpper();
						cTag.DataType = CCommonUtil.ToMelsecDataType(lstValue[0]);
						cTag.Description = lstValue[2];
						cTag.Channel = sChannel;
                        m_cSelectedProject.TagS.Add(sKey, cTag);

						lstValue.Clear();
						lstValue = null;
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				bOK = false;
			}
			finally
			{
				if (cReader != null)
				{
					cReader.Close();
					cReader.Dispose();
					cReader = null;
				}
			}

			UpdateView();

			return bOK;
		}

        public static bool ImportTagS(string[] sPathList, string sChannel)
        {
            bool bOK = true;
            CCsvReader cReader = null;

            try
            {
                cReader = new CCsvReader();
                cReader.CsvType = UDM.General.EMCsvType.Tab;
                for (int i = 0; i < sPathList.Length; i++)
                {
                    string sPath = sPathList[i];
                    bOK = cReader.Open(sPath, true);
                    if (bOK == false)
                        return false;
                    CTag cTag;
                    string sKey = string.Empty;
                    List<string> lstValue = null;
                    int iContunueCount = 0;
                    while (cReader.EOF == false)
                    {
                        lstValue = cReader.ReadLine();
                        iContunueCount++;
                        if (iContunueCount < 3) continue;
                        
                        if (lstValue != null && lstValue.Count > 5)
                        {
                            if (lstValue[5] == "") continue;
                            string sAddress = lstValue[5].ToUpper();
                            if (m_cSelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC)
                            {
                                if (sAddress.Contains(".A")) sAddress = sAddress.Replace(".A", ".10");
                                else if (sAddress.Contains(".B")) sAddress = sAddress.Replace(".B", ".11");
                                else if (sAddress.Contains(".C")) sAddress = sAddress.Replace(".C", ".12");
                                else if (sAddress.Contains(".D")) sAddress = sAddress.Replace(".D", ".13");
                                else if (sAddress.Contains(".E")) sAddress = sAddress.Replace(".E", ".14");
                                else if (sAddress.Contains(".F")) sAddress = sAddress.Replace(".F", ".15");
                            }
                            sKey = string.Format("{0}.{1}[{2}]", sChannel, sAddress, 1);
                            if (m_cSelectedProject.TagS.ContainsKey(sKey))
                                continue;
                            if (lstValue[2] == "") continue;
                            string sType = lstValue[2];
                            if (sType == "INT")
                                sType = "Word";
                            else if (sType.Contains("Array")) continue;
                            cTag = new CTag();
                            cTag.Key = sKey;
                            cTag.Address = sAddress;
                            cTag.DataType = CCommonUtil.ToDataType(sType);
                            cTag.Description = lstValue[1];     //Label 이름으로 대체
                            cTag.Channel = sChannel;
                            m_cSelectedProject.TagS.Add(sKey, cTag);

                            lstValue.Clear();
                            lstValue = null;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                if (cReader != null)
                {
                    cReader.Close();
                    cReader.Dispose();
                    cReader = null;
                }
            }

            UpdateView();

            return bOK;
        }

		public static bool ExportTagS(string sPath)
		{
			bool bOK = true;
			CCsvWriter cWriter = null;

			try
			{
				cWriter = new CCsvWriter(false);
				cWriter.Header.Add("Address");
				cWriter.Header.Add("DataType");
				cWriter.Header.Add("Description");

				bOK = cWriter.Open(sPath);
				if (bOK == false)
					return false;

				string sLine;
				CTag cTag;
                for (int i = 0; i < m_cSelectedProject.TagS.Count; i++)
				{
                    cTag = m_cSelectedProject.TagS[i];
					sLine = cTag.Address;
					sLine += "," + cTag.DataType.ToString();
					sLine += "," + cTag.Description;

					cWriter.WriteLine(sLine);
                }
                if (cWriter != null)
                {
                    cWriter.Close();
                    cWriter.Dispose();
                    cWriter = null;
                }
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				bOK = false;
			}

			return bOK;
		}

        public static bool CheckSameProject(string sName)
        {
            if (m_dicProject.Where(b => b.Value.Name == sName).Count() > 0)
                return true;
            return false;
        }

		#endregion


		#region Private Methods

		public static void SetTagTable()
		{
			if(m_ucTagTable != null)
			{
				m_ucTagTable.UEventTagUpdated += m_ucTagTable_UEventTagUpdated;
				m_ucTagTable.UEventTagRemoved += m_ucTagTable_UEventTagRemoved;
			}
		}

        private static void RemoveTagTable()
        {
            if (m_ucTagTable != null)
            {
                m_ucTagTable.UEventTagUpdated -= m_ucTagTable_UEventTagUpdated;
                m_ucTagTable.UEventTagRemoved -= m_ucTagTable_UEventTagRemoved;
            }
        }

		private static void SetSymbolTable()
		{
			if (m_ucSymbolTable != null)
			{
				m_ucSymbolTable.UEventSymbolRemoved += m_ucSymbolTable_UEventSymbolRemoved;
			}
		}

        public static CProject GetProject(int iIndex)
        {
            CProject cProject = null;

            if (m_dicProject.Count > iIndex)
                cProject = m_dicProject.ElementAt(iIndex).Value;

            return cProject;
        }

        public static void SelectProject(int iIndex)
        {
            m_cSelectedProject = GetProject(iIndex);
        }

		#endregion


		#region Event Methods

		private static void m_ucTagTable_UEventTagUpdated(object sender, List<CTag> lstTag)
		{
			if (m_ucSymbolTable != null)
				m_ucSymbolTable.Refresh();
		}

		private static void m_ucTagTable_UEventTagRemoved(object sender, List<CTag> lstTag )
		{
			CTag cTag;
            for (int i = 0; i < lstTag.Count; i++)
            {
                cTag = lstTag[i];
                if (m_cSelectedProject.SymbolS.ContainsKey(cTag.Key))
                    m_cSelectedProject.SymbolS.Remove(cTag.Key);
            }

			if (m_ucSymbolTable != null)
                m_ucSymbolTable.ShowTable(m_cSelectedProject.SymbolS);
		}

		private static void m_ucSymbolTable_UEvenSymbolUpdated(object sender, List<CSymbol> lstSymbol)
		{
			if (m_ucTagTable != null)
				m_ucTagTable.Refresh();
		}

		private static void m_ucSymbolTable_UEventSymbolRemoved(object sender, List<CSymbol> lstSymbol)
		{

		}

		#endregion
	}
}
