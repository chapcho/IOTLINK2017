using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.UDL;


namespace UDM.UDLImport
{
    public class CABTagImport
    {
        protected List<CUDLTag> m_lstUdlTagS = null;
        protected List<string> m_lstFile = null;

        protected string m_sChannel = "[CH_DV]";

        #region Initialize/Dispose

        public CABTagImport(List<string> sfile)
        {
            m_lstUdlTagS = new List<CUDLTag>();

            m_lstFile = sfile;
        }
        #endregion

        #region Public Properties

        public List<CUDLTag> UDLTagList
        {
            get { return m_lstUdlTagS; }
            set { m_lstUdlTagS = value; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        #endregion

        #region Public Methods

        public void L5kTagAnalysis()
        {
            try
            {
                int iLineCount = m_lstFile.Count;

                for(int i =0;i<iLineCount;i++)
                {
                    if(m_lstFile[i]=="TAG")
                    {
                        List<string> FilePart = new List<string>();

                        FilePart.Add(m_lstFile[i]);

                        int j = i + 1;

                        while (m_lstFile[j]!= "END_TAG")
                        {
                            FilePart.Add(m_lstFile[j]);
                            j++;
                        }
                        i = j;
                        FilePart.Add(m_lstFile[i]);

                        GlobalTagAnalysis(FilePart);

                        FilePart.Clear();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public CTagS GetClassTags()
        {
            CTagS cTempTagS = new CTagS();
            
            try
            {
                int iCount = m_lstUdlTagS.Count;

                for(int i =0;i<iCount;i++)
                {
                    CTag tempTag = classTagGenerator(m_lstUdlTagS[i]);

                    if (!cTempTagS.ContainsKey(tempTag.Key))
                    {
                        cTempTagS.Add(tempTag.Key, tempTag);
                    }
                    else
                    {
                        Console.WriteLine("There are one tag using repetitive Symbel : Symbel is \"{0}\" , Address is \"{1}\" . ", tempTag.Key, tempTag.Address);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return cTempTagS;
        }

        #endregion

        #region Private Methods

        private void GlobalTagAnalysis(List<string> file)
        {
            try
            {
                int iCount = file.Count;
                string sRegionName = "Global";

                for(int i =1;i<iCount-1;i++)
                {
                    string nodedata = file[i];
                    string sDatatype = FindDatatype(nodedata);

                    int j = i;
                    while (!file[j].EndsWith(";"))
                    {
                        if (sDatatype.Contains("TIMER") || sDatatype.Contains("COUNTER"))
                            nodedata = nodedata + file[j + 1];
                        else
                        {
                            if (nodedata.Contains(" ("))
                            {
                                if (!nodedata.Contains(")"))
                                {
                                    while (!file[j + 1].Contains(")"))
                                    {
                                        j++;
                                        nodedata = nodedata + file[j];
                                    }
                                    nodedata = nodedata + file[j + 1];
                                }
                            }
                            else
                            {
                                if (!nodedata.Contains(":="))
                                {
                                    while (!file[j + 1].Contains(":="))
                                    {
                                        j++;
                                        nodedata = nodedata + file[j];
                                    }
                                    nodedata = nodedata + file[j + 1];
                                }
                            }
                        }
                        j++;

                    }
                    i = j;
                    TagAnalysis(nodedata, sRegionName);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }           

            file.Clear();
        }

        private string FindAddress(string nodedata)
        {

            string address = string.Empty;
            try
            {
                if (nodedata.IndexOf(" : ") > -1)
                {
                    int a = 0;
                    a = nodedata.IndexOf(" : ");
                    address = nodedata.Substring(0, a);
                }
                else if (nodedata.IndexOf(" OF ") > -1)
                {
                    int a = 0;
                    a = nodedata.IndexOf(" OF ");
                    address = nodedata.Substring(0, a);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return address;
        }

        private string FindDatatype(string nodedata)
        {

            string dataType = string.Empty;
            try
            {
                int a = 0;

                a = nodedata.IndexOf(" : ");
                nodedata = nodedata.Substring(a + 3);

                a = nodedata.IndexOf(" ");
                dataType = nodedata.Substring(0, a);
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return dataType;
        }

        private string FindAlias(string nodedata)
        {

            string aliasOf = string.Empty;
            try
            {
                int a = 0;

                a = nodedata.IndexOf(" OF ");
                nodedata = nodedata.Substring(a + 4);

                a = nodedata.IndexOf(" ");
                aliasOf = nodedata.Substring(0, a);
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return aliasOf;
        }

        private string FindDescription(string nodedata)
        {

            string description = string.Empty;
            try
            {
                int a = nodedata.IndexOf("Description := \"");
                if (a > 0)
                {
                    string temp = nodedata.Substring(a + 16);
                    a = temp.IndexOf("\"");
                    description = temp.Substring(0, a);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return description;
        }

        private void TagAnalysis(string nodedata, string sRegion)
        {
            string sDataType = string.Empty;
            string sAliasOf = string.Empty;
            try
            {
                int iDatatypeHad = nodedata.IndexOf(" : ");
                int iAliasHad = nodedata.IndexOf(" OF ");
                bool datatypeEffective = false;
                bool aliasEffective = false;

                if (iDatatypeHad > -1)
                    datatypeEffective = CheckEffective(nodedata, iDatatypeHad);
                if (iAliasHad > -1)
                    aliasEffective = CheckEffective(nodedata, iAliasHad); //찾은 위치는 실제 내용인지 이름 정의내용 인지 반단

                if (iDatatypeHad > -1 && datatypeEffective)
                {
                    sDataType = FindDatatype(nodedata);  //실 데이터 형식을 있음면
                }
                else if (iAliasHad > -1 && aliasEffective)
                {
                    sAliasOf = FindAlias(nodedata);  // 실 아리야스 이면
                }

                if (sAliasOf != string.Empty)
                    AliasTagAnalysis(nodedata, sRegion);
                else if (CheckIsSamplyDataType(sDataType))
                    SamplyDatatypeAnalysis(nodedata, sRegion);
                else
                    UserDefinitedDatatypeAnalysis(nodedata, sRegion);
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
        }

        private void SamplyDatatypeAnalysis(string nodedata, string sRegion)
        {
            try
            {
                CUDLTag cUDLTag = new CUDLTag();

                string sTagName = FindAddress(nodedata);
                string sTagName1 = sTagName;
                string sDataType = FindDatatype(nodedata);
                string sAlias = string.Empty;
                string sDescription = string.Empty;
                string sCommentDescription = string.Empty;
                string mutiArray = string.Empty;
                int iArrayNum = ArrayCheck(sDataType);

                if (iArrayNum == -100)
                    mutiArray = MutiArrayCheck(sDataType);

                if (iArrayNum > 0)
                {
                    sTagName = sTagName + "[" + iArrayNum.ToString() + "]";

                    cUDLTag.ArrayStartPoint = "0";
                    cUDLTag.ArrayEndPoint = (iArrayNum - 1).ToString();
                }
                else if (iArrayNum == -100)
                {
                    sTagName = sTagName + "[" + mutiArray + "]";                    
                    
                    List<string> sArrayName = MutiArrayCounte(mutiArray);
                    int arraycount = sArrayName.Count;

                    cUDLTag.ArrayStartPoint = sArrayName[0];
                    cUDLTag.ArrayEndPoint = sArrayName[arraycount - 1];
                }

                cUDLTag.Address = sTagName;
                cUDLTag.Name = sTagName;

                if (nodedata.Contains("Description := "))
                {
                    sDescription = FindDescription(nodedata);
                    cUDLTag.Description = sDescription;
                }  

                cUDLTag.Datatype = CheckEMDatatype(sDataType);
                cUDLTag.PLCMaker = EMPLCMaker.Rockwell;

                m_lstUdlTagS.Add(cUDLTag);

                if(nodedata.Contains("COMMENT"))
                {
                    TagCommentAnalysis(nodedata, sTagName1, cUDLTag.Datatype, sTagName1, sAlias);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
        }

        private void AliasTagAnalysis(string nodedata, string sRegion)
        {
            try
            {
                CUDLTag cUDLTag = new CUDLTag();
                string sTagName = FindAddress(nodedata);
                string sDescription = string.Empty;
                string sCommentDescription = string.Empty;
                string sAliasOf = FindAlias(nodedata);

                cUDLTag.Address = sAliasOf;
                cUDLTag.Name = sTagName;
                cUDLTag.Alias = sAliasOf;

                if (nodedata.Contains("Description := "))
                {
                    sDescription = FindDescription(nodedata);
                    cUDLTag.Description = sDescription;
                }

                cUDLTag.PLCMaker = EMPLCMaker.Rockwell;

                bool bAliasFouned = false;

                foreach(CUDLTag tempTag in m_lstUdlTagS)
                {
                    if(tempTag.Name == sAliasOf)
                    {
                        cUDLTag.Datatype = tempTag.Datatype;
                        bAliasFouned = true;
                        break;
                    }
                }

                if(!bAliasFouned)
                {
                    cUDLTag.Datatype = AliasTagDatatypeChecker(sAliasOf);
                }

                m_lstUdlTagS.Add(cUDLTag);

                if(nodedata.Contains("COMMENT"))
                {
                    TagCommentAnalysis(nodedata, sTagName, cUDLTag.Datatype, sAliasOf, sAliasOf);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
        }

        private EMDataType AliasTagDatatypeChecker(string sAliasName)
        {
            EMDataType Datatype = EMDataType.Bool;

            try
            {
                if(sAliasName.Contains("["))
                {
                    int iPos = sAliasName.IndexOf("[");
                    string sAlias = sAliasName.Remove(iPos);

                    foreach(CUDLTag tempTag in m_lstUdlTagS)
                    {
                        if(tempTag.Name.Contains(sAlias))
                        {
                            int iLenght = sAlias.Length;

                            if(tempTag.Name[iLenght]=='[')
                            {
                                Datatype = tempTag.Datatype;
                                break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }

            return Datatype;
        }

        private void UserDefinitedDatatypeAnalysis(string nodedata, string sRegion)
        {
            try
            {
                CUDLTag cUDLTag = new CUDLTag();

                string sTagName = FindAddress(nodedata);
                string sTagName1 = sTagName;
                string sDataType = FindDatatype(nodedata);
                string sAlias = string.Empty;
                string sDescription = string.Empty;
                string sCommentDescription = string.Empty;
                string mutiArray = string.Empty;
                int iArrayNum = 0;

                if (sDataType.Contains("["))
                {
                    iArrayNum = ArrayCheck(sDataType);

                    if (iArrayNum == -100)
                        mutiArray = MutiArrayCheck(sDataType);
                    sDataType = UDTDatatypeCheck(sDataType);
                }

                if (iArrayNum > 0)
                {
                    sTagName = sTagName + "[" + iArrayNum.ToString() + "]";

                    cUDLTag.ArrayStartPoint = 0.ToString();
                    cUDLTag.ArrayEndPoint = (iArrayNum - 1).ToString();
                }
                else if (iArrayNum == -100)
                {
                    sTagName = sTagName + "[" + mutiArray + "]";

                    List<string> sArrayName = MutiArrayCounte(mutiArray);
                    int arraycount = sArrayName.Count;

                    cUDLTag.ArrayStartPoint = sArrayName[0];
                    cUDLTag.ArrayEndPoint = sArrayName[arraycount - 1];
                }

                cUDLTag.Address = sTagName;
                cUDLTag.Name = sTagName;

                if (nodedata.Contains("Description := "))
                {
                    sDescription = FindDescription(nodedata);
                    cUDLTag.Description = sDescription;
                }

                cUDLTag.Datatype = EMDataType.UserDefDataType;
                cUDLTag.UDTType = sDataType;
                cUDLTag.PLCMaker = EMPLCMaker.Rockwell;

                m_lstUdlTagS.Add(cUDLTag);

                if(nodedata.Contains("COMMENT"))
                {
                    TagCommentAnalysis(nodedata, sTagName1, cUDLTag.Datatype, sTagName1, sAlias);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
        }

        private bool CheckEffective(string nodedata, int pos)
        {

            bool effective = true;
            try
            {
                int length = nodedata.Length;

                for (int i = pos + 1; i < length; i++)
                {
                    if (nodedata[i] == '\"')
                    {
                        if (nodedata[i + 1] == ',')
                            effective = false;
                        else
                            effective = true;

                        break;
                    }
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return effective;
        }

        private int ArrayCheck(string nodedata)
        {
            int arrayNum = 0;
            try
            {
                int a, b;
                a = nodedata.IndexOf("[");
                b = nodedata.IndexOf("]");
                if (a > 0)
                {
                    string temp = nodedata.Substring(a + 1, b - a - 1);

                    if (temp.Contains(","))
                        arrayNum = -100;
                    else
                        arrayNum = Convert.ToInt32(temp);
                }
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return arrayNum;
        }

        private string MutiArrayCheck(string nodedata)
        {
            string temp = string.Empty;
            try
            {
                int a = nodedata.IndexOf("[");
                int b = nodedata.IndexOf("]");

                temp = nodedata.Substring(a + 1, b - a - 1);
                Console.WriteLine("this tag had muti array" + temp);
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return temp;
        } // 다차원 배열 인수 체크

        private List<string> MutiArrayCounte(string nodedata)
        {

            List<string> mutiArray = new List<string>();
            try
            {
                int a = nodedata.IndexOf(",");
                string temp1 = nodedata.Substring(0, a);
                string temp2 = nodedata.Substring(a + 1);

                if (temp2.Contains(","))
                {
                    List<string> subMuti = MutiArrayCounte(temp2);
                    a = Convert.ToInt32(temp1);
                    int b = subMuti.Count;
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            string temp =  i.ToString() + "," + subMuti[j].Substring(1);
                            mutiArray.Add(temp);
                        }
                    }
                }
                else
                {
                    a = Convert.ToInt32(temp1);
                    int b = Convert.ToInt32(temp2);

                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            string temp = i.ToString() + "," + j.ToString() ;
                            mutiArray.Add(temp);
                        }
                    }

                }
                Console.WriteLine("this tag had " + mutiArray.Count.ToString() + "items"); ;
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }

            return mutiArray;

        }// 다차윈배열 계산

        private bool CheckIsSamplyDataType(string sDataType)
        {
            bool isSample = false;

            try
            {
                if (sDataType.Contains("BOOL"))
                    isSample = true;
                else if (sDataType.Contains("DINT"))
                    isSample = true;
                else if (sDataType.Contains("SINT"))
                    isSample = true;
                else if (sDataType.Contains("INT"))
                    isSample = true;
                else if (sDataType.Contains("REAL"))
                    isSample = true;
                else if (sDataType.Contains("CONTROL"))
                    isSample = true;
                else if (sDataType.Contains("COUNTER"))
                    isSample = true;
                else if (sDataType.Contains("TIMER"))
                    isSample = true;
                else if (sDataType.Contains("MESSAGE"))
                    isSample = true;
                else if (sDataType.Contains("STRING"))
                    isSample = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return isSample;
        }

        private EMDataType CheckEMDatatype(string sDataType)
        {
            EMDataType tempType=EMDataType.Bool;
            try
            {
                if (sDataType.Contains("BOOL"))
                    tempType = EMDataType.Bool;
                else if (sDataType.Contains("DINT"))
                    tempType = EMDataType.DInt;
                else if (sDataType.Contains("SINT"))
                    tempType = EMDataType.SInt;
                else if (sDataType.Contains("INT"))
                    tempType = EMDataType.Int;
                else if (sDataType.Contains("REAL"))
                    tempType = EMDataType.Real;
                else if (sDataType.Contains("CONTROL"))
                    tempType = EMDataType.Control;
                else if (sDataType.Contains("COUNTER"))
                    tempType = EMDataType.Counter;
                else if (sDataType.Contains("TIMER"))
                    tempType = EMDataType.Timer;
                else if (sDataType.Contains("MESSAGE"))
                    tempType = EMDataType.Message;
                else if (sDataType.Contains("STRING"))
                    tempType = EMDataType.String;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempType;
        }

        private string UDTDatatypeCheck(string nodedata)
        {

            string tempStr = string.Empty;
            try
            {
                int a = nodedata.IndexOf("[");
                tempStr = nodedata.Substring(0, a);
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return tempStr;
        }

        private CTag classTagGenerator(CUDLTag tagData)
        {
            CTag cTempTag = new CTag();
            try
            {
                cTempTag.Name = tagData.Name;
                cTempTag.Address = tagData.Address;
                cTempTag.Description = tagData.Description;
                cTempTag.DataType = tagData.Datatype;
                cTempTag.Size = 1;

                if(m_sChannel!="")
                {
                    cTempTag.Key = m_sChannel + cTempTag.Name + "[1]";
                }
  
                if (cTempTag.DataType == EMDataType.UserDefDataType || cTempTag.DataType == EMDataType.Block)
                {
                    cTempTag.UDTType = tagData.UDTType;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return cTempTag;
        }

        private void TagCommentAnalysis(string nodedata, string baseName, EMDataType datatype,string address,string sAlias)
        {
            try
            {
                while(nodedata.Contains("COMMENT"))
                {
                    int i = nodedata.IndexOf("COMMENT");

                    nodedata = nodedata.Substring(i + 7);

                    i = nodedata.IndexOf(" :=");

                    string sCommentName = nodedata.Remove(i);

                    nodedata = nodedata.Substring(i + 5);

                    i = nodedata.IndexOf("\",");

                    if (i == -1)
                        i = nodedata.IndexOf("\")");

                    string sCommentDes = nodedata.Remove(i);

                    nodedata = nodedata.Substring(i + 2);

                    CUDLTag tempTag = new CUDLTag();

                    tempTag.Name = baseName + sCommentName;
                    tempTag.Address = address + sCommentName;
                    tempTag.Description = sCommentDes;

                    if (sAlias != "")
                        tempTag.Alias = sAlias + sCommentName;

                    if (sCommentName.Contains("."))
                        tempTag.Datatype = EMDataType.Bool;
                    else
                        tempTag.Datatype = datatype;

                    m_lstUdlTagS.Add(tempTag);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion
    }
}
