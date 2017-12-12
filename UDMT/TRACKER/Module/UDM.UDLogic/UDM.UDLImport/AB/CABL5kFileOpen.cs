using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace UDM.UDLImport
{
    public class CABL5kFileOpen
    {
        protected List<string> m_lstL5kFile = new List<string>();

        #region Initialize/Dispose

        public CABL5kFileOpen()
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "L5X Files(*.L5K)|*.L5k";

            oFile.ShowDialog();

            StreamReader sL5kReader = new StreamReader(oFile.FileName, Encoding.Default);

            string strLine = sL5kReader.ReadLine();

            string sVersion = string.Empty;
            int iVersion = 0;
            bool isDatatype = false;
            bool isModule = false;
            bool isFunction = false;
            bool isTag = false;
            bool isProgram = false;
            bool isRoution = false;
            int iIndex = 0;

            while (strLine != "END_CONTROLLER")
            {

                if (iIndex == 3)
                {
                    sVersion = strLine;
                    iVersion = sVersion.IndexOf("5000 v");
                    sVersion = sVersion.Substring(iVersion + 6);
                    sVersion = sVersion.Remove(2);
                    iVersion = Convert.ToInt16(sVersion);
                }

                if (iVersion != 0 && iVersion < 21)
                {

                    if (strLine.StartsWith("\tDATATYPE"))
                    {
                        isDatatype = true;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tEND_DATATYPE"))
                    {
                        isDatatype = false;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tMODULE"))
                    {
                        isModule = true;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tEND_MODULE"))
                    {
                        isModule = false;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tADD_ON_INSTRUCTION_DEFINITION"))
                    {
                        isFunction = true;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tEND_ADD_ON_INSTRUCTION_DEFINITION"))
                    {
                        isFunction = false;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tTAG"))
                    {
                        isTag = true;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tEND_TAG"))
                    {
                        isTag = false;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tPROGRAM"))
                    {
                        isProgram = true;
                        strLine = strLine.Substring(1);
                    }
                    else if (strLine.StartsWith("\tEND_PROGRAM"))
                    {
                        isProgram = false;
                        strLine = strLine.Substring(1);
                    }
                    else
                    {
                        if (isDatatype)
                        {
                            if (strLine.Length > 0)
                                strLine = DatatypeFileEdit(strLine);
                        }
                        else if (isModule)
                        {
                            if (strLine.Length > 0)
                                strLine = MoudleFileEdit(strLine);
                        }
                        else if (isFunction)
                        {
                            strLine = FunctionFileEdit(strLine, isRoution);

                            if (strLine == "END_ROUTINE" || strLine == "END_FBD_ROUTINE" || strLine == "END_ST_ROUTINE" || strLine == "END_ST_ROUTINE")
                                isRoution = false;
                            else if (strLine.StartsWith("ST_ROUTINE") || strLine.StartsWith("ROUTINE") || strLine.StartsWith("SFC_ROUTINE") || strLine.StartsWith("FBD_ROUTINE"))
                                isRoution = true;
                        }
                        else if (isTag)
                        {
                            if (strLine.Length > 0)
                                strLine = TagFileEdit(strLine);
                        }
                        else if (isProgram)
                        {
                            strLine = ProgramFileEdit(strLine, isRoution);

                            if (strLine == "END_ROUTINE" || strLine == "END_FBD_ROUTINE" || strLine == "END_ST_ROUTINE" || strLine == "END_ST_ROUTINE")
                                isRoution = false;
                            else if (strLine.StartsWith("ST_ROUTINE") || strLine.StartsWith("ROUTINE") || strLine.StartsWith("SFC_ROUTINE") || strLine.StartsWith("FBD_ROUTINE"))
                                isRoution = true;
                        }
                    }
                }

                m_lstL5kFile.Add(strLine);
                iIndex = iIndex + 1;

                strLine = sL5kReader.ReadLine();
            }
            m_lstL5kFile.Add(strLine);
            sL5kReader.Close();
        }

        public CABL5kFileOpen(string path)
        {
            try
            {
                StreamReader sL5kReader = new StreamReader(path, Encoding.Default);

                string strLine = sL5kReader.ReadLine();

                string sVersion = string.Empty;
                int iVersion = 0;
                bool isDatatype = false;
                bool isModule = false;
                bool isFunction = false;
                bool isTag = false;
                bool isProgram = false;
                bool isRoution = false;
                int iIndex = 0;

                while (strLine != "END_CONTROLLER")
                {

                    if (iIndex == 3)
                    {
                        sVersion = strLine;
                        iVersion = sVersion.IndexOf("5000 v");
                        sVersion = sVersion.Substring(iVersion + 6);
                        sVersion = sVersion.Remove(2);
                        iVersion = Convert.ToInt16(sVersion);
                    }

                    if (iVersion != 0 && iVersion < 21)
                    {

                        if (strLine.StartsWith("\tDATATYPE"))
                        {
                            isDatatype = true;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tEND_DATATYPE"))
                        {
                            isDatatype = false;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tMODULE"))
                        {
                            isModule = true;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tEND_MODULE"))
                        {
                            isModule = false;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tADD_ON_INSTRUCTION_DEFINITION"))
                        {
                            isFunction = true;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tEND_ADD_ON_INSTRUCTION_DEFINITION"))
                        {
                            isFunction = false;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tTAG"))
                        {
                            isTag = true;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tEND_TAG"))
                        {
                            isTag = false;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tPROGRAM"))
                        {
                            isProgram = true;
                            strLine = strLine.Substring(1);
                        }
                        else if (strLine.StartsWith("\tEND_PROGRAM"))
                        {
                            isProgram = false;
                            strLine = strLine.Substring(1);
                        }
                        else
                        {
                            if (isDatatype)
                            {
                                if (strLine.Length > 0)
                                    strLine = DatatypeFileEdit(strLine);
                            }
                            else if (isModule)
                            {
                                if (strLine.Length > 0)
                                    strLine = MoudleFileEdit(strLine);
                            }
                            else if (isFunction)
                            {
                                strLine = FunctionFileEdit(strLine, isRoution);

                                if (strLine == "END_ROUTINE" || strLine == "END_FBD_ROUTINE" || strLine == "END_ST_ROUTINE" || strLine == "END_ST_ROUTINE")
                                    isRoution = false;
                                else if (strLine.StartsWith("ST_ROUTINE") || strLine.StartsWith("ROUTINE") || strLine.StartsWith("SFC_ROUTINE") || strLine.StartsWith("FBD_ROUTINE"))
                                    isRoution = true;
                            }
                            else if (isTag)
                            {
                                if (strLine.Length > 0)
                                    strLine = TagFileEdit(strLine);
                            }
                            else if (isProgram)
                            {
                                strLine = ProgramFileEdit(strLine, isRoution);

                                if (strLine == "END_ROUTINE" || strLine == "END_FBD_ROUTINE" || strLine == "END_ST_ROUTINE" || strLine == "END_ST_ROUTINE")
                                    isRoution = false;
                                else if (strLine.StartsWith("ST_ROUTINE") || strLine.StartsWith("ROUTINE") || strLine.StartsWith("SFC_ROUTINE") || strLine.StartsWith("FBD_ROUTINE"))
                                    isRoution = true;
                            }
                        }
                    }

                    m_lstL5kFile.Add(strLine);
                    iIndex = iIndex + 1;

                    strLine = sL5kReader.ReadLine();
                }
                m_lstL5kFile.Add(strLine);
                sL5kReader.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Public Properites

        public List<string> L5kFile
        {
            get { return m_lstL5kFile; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private string TagFileEdit(string temp)
        {
            try
            {
                while (temp.StartsWith("\t"))
                    temp = temp.Substring(1);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return temp;
        }

        private string MoudleFileEdit(string temp)
        {
            try
            {
                if (temp.Length > 0)
                {
                    if (temp[0] == '\t')
                        temp = temp.Substring(1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return temp;
        }

        private string DatatypeFileEdit(string temp)
        {
            try
            {
                if (temp.Length > 0)
                {
                    if (temp[0] == '\t')
                        temp = temp.Substring(1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return temp;
        }

        private string FunctionFileEdit(string temp, bool isRoution)
        {
            try
            {
                if (isRoution)
                {
                    if (temp.Length >= 2)
                        temp = temp.Substring(2);
                }
                else
                {
                    while (temp.StartsWith("\t"))
                        temp = temp.Substring(1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return temp;
        }

        private string ProgramFileEdit(string temp, bool isRoution)
        {
            try
            {
                if (isRoution)
                {
                    if (temp.Length >= 3)
                        temp = temp.Substring(3);
                }
                else
                {
                    while (temp.StartsWith("\t"))
                        temp = temp.Substring(1);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return temp;
        }

        #endregion
    }
}
