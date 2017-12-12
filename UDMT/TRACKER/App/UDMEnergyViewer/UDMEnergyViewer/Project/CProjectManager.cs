using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.General.Serialize;
using UDM.General.Csv;
using UDM.Common;

namespace UDMEnergyViewer
{
	public static class CProjectManager
	{

		#region Member Varialbes

		private static CProject m_cProject = new CProject();

		private static UCTagTable m_ucTagTable = null;
		private static UCSymbolTable m_ucSymbolTable = null;

		#endregion


		#region Inialize/Dispose


		#endregion


		#region Public Properties

		public static CProject Project
		{
			get { return m_cProject; }
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

		#endregion


		#region Public Methods

		public static bool New(string sName)
		{
			Clear();

			m_cProject.Name = sName;

			UpdateView();

			return true;
		}

		public static bool Open(string sPath)
		{
			Clear();

			bool bOK = false;

			CNetSerializer cSerializer = new CNetSerializer();
			m_cProject = (CProject)(cSerializer.Read(sPath));
			if (m_cProject != null)
				bOK = true;
			else
				m_cProject = new CProject();

            m_cProject.StepS.Compose(m_cProject.TagS);
			cSerializer.Dispose();
			cSerializer = null;

			UpdateView();

			return bOK;
		}

		public static bool Save(string sPath)
		{
			bool bOK = false;
            m_cProject.Path = sPath;
			CNetSerializer cSerializer = new CNetSerializer();
			bOK = cSerializer.Write(sPath, m_cProject);

			cSerializer.Dispose();
			cSerializer = null;

			UpdateView();

			return bOK;
		}

		public static void Clear()
		{
			m_cProject.Clear();

			UpdateView();
		}

		public static void UpdateView()
		{
			if (m_ucTagTable != null)
				m_ucTagTable.ShowTable(m_cProject.TagS);

			if (m_ucSymbolTable != null)
				m_ucSymbolTable.ShowTable(m_cProject.SymbolS);
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
						if (CProjectManager.Project.TagS.ContainsKey(sKey))
							continue;

						cTag = new CTag();
						cTag.Key = sKey;
						cTag.Address = lstValue[0].ToUpper();
						cTag.DataType = CCommonUtil.ToMelsecDataType(lstValue[0]);
						cTag.Description = lstValue[2];
						cTag.Channel = sChannel;
						CProjectManager.Project.TagS.Add(sKey, cTag);

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
                            sKey = string.Format("{0}.{1}[{2}]", sChannel, lstValue[5], 1);
                            if (CProjectManager.Project.TagS.ContainsKey(sKey))
                                continue;

                            cTag = new CTag();
                            cTag.Key = sKey;
                            cTag.Address = lstValue[5].ToUpper();
                            cTag.DataType = CCommonUtil.ToDataType(lstValue[2]);
                            cTag.Description = lstValue[1];     //Label 이름으로 대체
                            cTag.Channel = sChannel;
                            CProjectManager.Project.TagS.Add(sKey, cTag);

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
				for (int i = 0; i < m_cProject.TagS.Count; i++)
				{
					cTag = m_cProject.TagS[i];
					sLine = cTag.Address;
					sLine += "," + cTag.DataType.ToString();
					sLine += "," + cTag.Description;

					cWriter.WriteLine(sLine);
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				bOK = false;
			}
			finally
			{
				if (cWriter != null)
				{
					cWriter.Close();
					cWriter.Dispose();
					cWriter = null;
				}
			}

			return bOK;
		}

		

		#endregion


		#region Private Methods

		private static void SetTagTable(UCTagTable ucTagTable)
		{
			if(m_ucTagTable != null)
			{
				m_ucTagTable.UEventTagRemoved -= m_ucTagTable_UEventTagRemoved;
			}

			m_ucTagTable = ucTagTable;
			if(m_ucTagTable != null)
			{
				m_ucTagTable.UEventTagUpdated += m_ucTagTable_UEventTagUpdated;
				m_ucTagTable.UEventTagRemoved += m_ucTagTable_UEventTagRemoved;
			}
		}

		private static void SetSymbolTable(UCSymbolTable ucSymbolTable)
		{
			if (m_ucSymbolTable != null)
			{
				m_ucSymbolTable.UEventSymbolRemoved -= m_ucSymbolTable_UEventSymbolRemoved;
			}

			m_ucSymbolTable = ucSymbolTable;
			if (m_ucSymbolTable != null)
			{
				m_ucSymbolTable.UEventSymbolRemoved += m_ucSymbolTable_UEventSymbolRemoved;
			}
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
			for(int i=0;i<lstTag.Count;i++)
			{
				cTag = lstTag[i];
				if(m_cProject.SymbolS.ContainsKey(cTag.Key))
					m_cProject.SymbolS.Remove(cTag.Key);
			}

			if (m_ucSymbolTable != null)
				m_ucSymbolTable.ShowTable(m_cProject.SymbolS);
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
