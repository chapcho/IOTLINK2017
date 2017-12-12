using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace USB_DataRead
{
    public class CMelsecProjectAnalyzer
    {
        #region Member Variables

        protected string _sGPJ_FilePath = string.Empty;
        protected string _sBaseFolderPath = string.Empty;
        protected const string _WPGAddPath = @"Resource\Pou\Body";
        protected const string _CommentAddPath = @"Resource\Others";
        //protected const string _MelsecCommadPath = @"C:\Users\ktw\Documents\Visual Studio 2008\Projects\USB_DataRead\USB_DataRead\bin\Debug\MelsecLadderCommand.txt";

        protected Dictionary<string, CILStepDataS> _dicILStepDataS = new Dictionary<string, CILStepDataS>();
        protected string _sCPUType = string.Empty;
        protected string _sProjectName = string.Empty;
        protected string _sProjectComment = string.Empty;
        protected Dictionary<string, int> _dicDieviceMaxSize = new Dictionary<string, int>();
        protected List<string> _lstProgramName = new List<string>();
        protected Dictionary<string, CCommentData> _dicCommentData = new Dictionary<string, CCommentData>();

        #endregion


        #region Initialze

        #endregion


        #region Properties

        public string GPJFilePath
        {
            get { return _sGPJ_FilePath; }
        }

        public string WPGFolderPath
        {
            get { return _sBaseFolderPath + _WPGAddPath; }
        }

        public string CommentFolderPath
        {
            get { return _sBaseFolderPath + _CommentAddPath; }
        }

        public string ConvertFolderPath
        {
            get { return _sBaseFolderPath + "\\ConvertCSV"; }
        }

        public Dictionary<string, CILStepDataS> WPGAnalyzeResult
        {
            get { return _dicILStepDataS; }
        }

        public Dictionary<string, CCommentData> CommentList
        {
            get { return _dicCommentData; }
        }

        #endregion


        #region Public Method

        /// <summary>
        /// 프로젝트파일 열기(경로는 사용자 입력)
        /// 프로젝트 파일에 정보추출, Comment, Logic을 전체 분석한다.
        /// GPJ,GPS, WPG, WCD를 분석함.
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public bool OpenGPJ_File(string sFilePath, string sBaseFolderPath)
        {
            //GPJ 파일 추출 내용
            //CPU Type, Project Comment

            StreamReader read = new StreamReader(sFilePath);
            string sLine = "";

            _sGPJ_FilePath = sFilePath;
            _sBaseFolderPath = sBaseFolderPath;

            while ((sLine = read.ReadLine()) != null)
            {
                if (sLine.Contains("CpuType	TYPE_STRING"))
                    _sCPUType = GetIncludeValue(sLine);
                else if (sLine.Contains("ProjectComment	TYPE_STRING"))
                    _sProjectComment = GetIncludeValue(sLine);
            }
            read.Close();
            read.Dispose();
            read = null;

            //GPS 파일 추출 내용
            //통신 연결 설정정보도 있음, 프로그램 리스트,
            string[] saFileS = Directory.GetFiles(sBaseFolderPath, "*.gps");
            if (saFileS.Length == 0) return false;

            read = new StreamReader(saFileS[0]);

            bool bProjList = false;

            while ((sLine = read.ReadLine()) != null)
            {
                if (sLine.Contains("ProjectName	TYPE_STRING"))
                    _sProjectName = GetIncludeValue(sLine);
                else if (sLine == "	PrgList:")
                    bProjList = true;
                else if (bProjList)
                {
                    if (sLine.Contains("PrgCount"))
                        bProjList = false;
                    else
                        _lstProgramName.Add(GetIncludeValue(sLine));
                }
            }

            read.Close();
            read.Dispose();
            read = null;

            bool bOK = OpenComment_File(CommentFolderPath + "\\COMMENT.wcd");
            if (bOK == false)
            {
                Console.WriteLine("File Name : " + CommentFolderPath + "\\COMMENT.wcd" + "   파일이분석되지 않습니다");
            }

            string[] saWPGFile = Directory.GetFiles(WPGFolderPath, "*.wpg");
            if (saWPGFile.Length != _lstProgramName.Count)
            {
                Console.WriteLine("프로젝트 파일갯수가 다릅니다");
                return false;
            }

            for (int i = 0; i < saWPGFile.Length; i++)
            {
                bOK = OpenWPG_File(saWPGFile[i]);
                if (bOK == false)
                {
                    Console.WriteLine("File Name : " + saWPGFile[i] + "   파일이분석되지 않습니다");
                }
            }

            return true;
        }

        /// <summary>
        /// 개별로하나씩 열때사용 할 수 있음.
        /// 경로는 GPJ 파일 Path + _WPGAddPath
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public bool OpenWPG_File(string sFilePath)
        {
            CILStepData cStepData = new CILStepData();
            CILStepDataS cStepDataS = new CILStepDataS();

            byte[] nReadData = File.ReadAllBytes(sFilePath);

            if (nReadData == null) return false;

            if (nReadData.Length == 0) return false;

            byte[] nTilte = new byte[32];

            for (int i = 0; i < nTilte.Length; i++)
                nTilte[i] = nReadData[i + 4];

            byte[] nHeaderEnd = new byte[4];

            for (int i = 0; i < nHeaderEnd.Length; i++)
                nHeaderEnd[i] = nReadData[i + 64];

            string sTilte = "";
            if (nHeaderEnd[0] == 0x04 && nHeaderEnd[1] == 0x00 && nHeaderEnd[2] == 0xff && nHeaderEnd[3] == 0xff)
            {
                sTilte = Encoding.Default.GetString(nTilte);
                cStepDataS.Tilte = sTilte.Trim();
            }
            //----Step 분할

            CLadderAnalyzer cAnalyzer = new CLadderAnalyzer();
            cAnalyzer.CommandOpen();

            bool bPass = true;

            for (int i = 68; i < nReadData.Length; i++)
            {
                int iBlockCount = nReadData[i];
                byte[] BlockByteORG = new byte[iBlockCount];
                for (int k = 0; k < iBlockCount; k++)
                    BlockByteORG[k] = nReadData[i + k];
                
                //앞뒤 제거(블럭 구분을 위해 했지만 불필요 함)
                byte[] TargetByte = new byte[iBlockCount - 2];
                for (int k = 1; k < iBlockCount; k++)
                {
                    if (k < iBlockCount - 1)
                        TargetByte[k - 1] = nReadData[i + k];
                }

                if (TargetByte[0] == 0x80)
                {
                    if (cStepData.Command != null)
                    {
                        ArrangeContact(cStepData);

                        cStepDataS.Add(cStepData);
                        cStepData = new CILStepData();
                    }
                    cStepData.StepType = EMStepType.STATEMENT;
                    cStepData.AnalyzeComp = true;
                    if (TargetByte[1] == 0x01 && TargetByte.Length == 2)
                    {
                        cStepData.StepGapNumber = 1;
                        cStepData.FinalStringList.Add("*,,,,,,,");
                    }
                    else
                    {
                        byte[] nAscii = new byte[TargetByte.Length - 2];
                        for (int k = 0; k < nAscii.Length; k++)
                            nAscii[k] = TargetByte[k + 2];
                        string sResult = Encoding.Default.GetString(nAscii);
                        cStepData.FinalStringList.Add("" + sResult + ",,,,,,,");
                        cStepData.StepGapNumber = TargetByte.Length / 2 + 2;  //소비 스텝(2+문자수/2) 2는 고정
                    }
                    cStepData.StepORGByteList.Add(BlockByteORG);
                    cStepDataS.Add(cStepData);

                    cStepData = new CILStepData();
                    bPass = true;
                }
                else
                {
                    CMelsecCommand cCommand = new CMelsecCommand();
                    //Command Check
                    bool bOK = cAnalyzer.AnalyzeCommandByte(TargetByte, cCommand);
                    if (bOK)
                    {
                        if (bPass)
                            bPass = false;
                        else
                        {
                            ArrangeContact(cStepData);

                            cStepDataS.Add(cStepData);
                            cStepData = new CILStepData();
                        }
                        cStepData.StepType = EMStepType.COMMAND;
                        cStepData.Command = cCommand;
                        cStepData.StepORGByteList.Add(BlockByteORG);
                    }
                    else
                    {
                        cStepData.StepORGByteList.Add(BlockByteORG);
                        CContactData cContact = new CContactData();

                        cContact.HeadExcludeByte = TargetByte;
                        string sNote = "";
                        bOK = cContact.SetAnanlyze(out sNote);

                        if (bOK == false)
                        {
                            if (sNote == "")
                            {
                                string sNotMatch = "";
                                for (int h = 0; h < TargetByte.Length; h++)
                                {
                                    string s = string.Format("{0:x2}", TargetByte[h]);
                                    sNotMatch += s + ", ";
                                }
                                Console.WriteLine(sNotMatch);
                            }
                            else
                            {
                                cStepData.ContactList[cStepData.ContactList.Count - 1].LadderNote = sNote;
                            }

                        }
                        else
                        {
                            cStepData.ContactList.Add(cContact);
                        }
                    }
                }
                i += iBlockCount - 1;
            }

            if (cStepData.StepORGByteList.Count > 0)
            {
                cStepDataS.Add(cStepData);
                List<CILStepData> lstNotAnalyzeStep = cStepDataS.FindAll(b=> b.AnalyzeComp == false);
                ArrangeContact(lstNotAnalyzeStep);
                foreach (CILStepData cData in cStepDataS)
                {
                    for (int i = 0; i < cData.ContactList.Count; i++)
                    {
                        if (cData.ContactList[i].FusionResultString != "" && cData.ContactList[i].ContactType == EMContactType.Header_K || cData.ContactList[i].ContactType == EMContactType.Index_Z)
                        {
                            cData.ContactList[i].FusionResultString = "";
                        }
                    }
                }
                lstNotAnalyzeStep.Clear();
                lstNotAnalyzeStep = cStepDataS.FindAll(b => b.AnalyzeComp == false);
                if (lstNotAnalyzeStep.Count > 0)
                    Console.WriteLine("일부 분석 실패");
                else
                {
                    WriteFinalLine(cStepDataS);
                }
                string[] sSplit = sFilePath.Split('\\');
                string[] sFileName = sSplit[sSplit.Length - 1].Split('.');
                _dicILStepDataS.Add(sFileName[0], cStepDataS);
            }

            return true;
        }

        /// <summary>
        /// 개별로 하나씩 열때 사용가능
        /// 경로는 GPJ 파일 Path + _CommentAddPath
        /// Comment가 있는 폴더에 csv를 생성하고 Dictionary에 갖고 있음 Step에서 Comment찾기 쉽도록 Key는 Address
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public bool OpenComment_File(string sFilePath)
        {
            byte[] nReadData = File.ReadAllBytes(sFilePath);
            byte[] nChange = new byte[10];
            int iCnt = 0;
            int iCommentCount = 0;
            List<string> lstCommentData = new List<string>();
            CLadderAnalyzer cAnaly = new CLadderAnalyzer();
            cAnaly.CommandOpen();

            bool bEndAddressLength = false;
            List<CCommentData> lstComment = new List<CCommentData>();
            for (int i = 74; i < nReadData.Length; i++)
            {
                string sUpper = string.Format("{0:x2},", nReadData[i]);
                nChange[iCnt] = nReadData[i];
                if (iCnt >= 9 && bEndAddressLength == false)
                {
                    if (cAnaly.CheckContactHeader(nChange[0]))
                    {
                        string sHeader = cAnaly.GetHeader(nChange[0]);
                        bool bSpecialHeader = cAnaly.CheckSpecialHeader(nChange[0], nChange[1]);
                        bool bHexa = cAnaly.CheckHexaAdress(sHeader);

                        int iAddressCount = cAnaly.GetAddressCount(nChange[6], nChange[7], 0);
                        int iAddressMajor = 0;
                        if (bSpecialHeader)
                        {
                            sHeader = cAnaly.GetSpecialHeader(nChange[0], nChange[1], nChange[4]);
                            iAddressMajor = cAnaly.GetAddressCount(nChange[2], nChange[3], 0);
                        }
                        else
                            iAddressMajor = cAnaly.GetAddressCount(nChange[2], nChange[3], nChange[4]);

                        for (int k = 0; k < iAddressCount; k++)
                        {
                            CCommentData cData = new CCommentData();
                            string sAddress = "";
                            string sMajor = "";
                            int iMajor = iAddressMajor + k;
                            if (bHexa)
                            {
                                string sHexa = string.Format("{0:x}", iMajor).ToUpper();
                                string s1st = sHexa.Substring(0, 1);

                                if (cAnaly.CheckHexaZeroAdd(s1st))
                                    sHexa = "0" + sHexa;
                                sMajor = string.Format("{0}", sHexa);
                            }
                            else
                                sMajor = string.Format("{0}", iMajor);

                            sAddress = string.Format("{0}{1}", sHeader, sMajor);
                            cData.Address = sAddress;
                            cData.Header = sHeader;
                            lstComment.Add(cData);
                        }

                        iCnt = 0;
                        nChange = new byte[10];
                    }
                    else
                    {
                        bEndAddressLength = true;
                        byte[] nCon = (byte[])nChange.Clone();

                        nChange = new byte[40];

                        for (int a = 0; a < nCon.Length; a++)
                            nChange[a] = nCon[a];

                        iCnt++;
                    }
                }
                else
                {
                    if (iCnt >= 39)
                    {
                        byte[] nLabel = new byte[8];
                        byte[] nComment = new byte[32];
                        for (int a = 0; a < nLabel.Length; a++)
                            nLabel[a] = nChange[a];

                        for (int a = 0; a < nComment.Length; a++)
                            nComment[a] = nChange[a + 8];

                        string sLabel = Encoding.Default.GetString(nLabel);
                        string sComment = Encoding.Default.GetString(nComment);

                        lstComment[iCommentCount].LabelOrgByte = nLabel;
                        lstComment[iCommentCount].CommentOrgByte = nComment;
                        lstComment[iCommentCount].Label = sLabel.Trim();
                        lstComment[iCommentCount].Comment = sComment.Trim();

                        _dicCommentData.Add(lstComment[iCommentCount].Address, lstComment[iCommentCount]);
                        nChange = new byte[40];
                        iCnt = 0;
                        iCommentCount++;

                    }
                    else
                        iCnt++;
                }
            }
            string[] sLine = new string[lstComment.Count + 1];
            sLine[0] = "Device,Label,Comment";
            for (int i = 1; i <= lstComment.Count; i++)
                sLine[i] = string.Format("{0},{1},{2}", lstComment[i - 1].Address, lstComment[i - 1].Label, lstComment[i - 1].Comment);

            if (Directory.Exists(ConvertFolderPath) == false)
                Directory.CreateDirectory(ConvertFolderPath);

            //string sFileSavePath = ConvertFolderPath + "\\COMMENT.csv";
            //File.WriteAllLines(sFileSavePath, sLine);

            return true;
        }

        #endregion

        #region Protected Method

        protected string GetIncludeValue(string sSource)
        {
            int iIndex = sSource.IndexOf("\"") + 1;
            int iIndex2 = sSource.IndexOf("\"", iIndex);
            int iMul = (iIndex2 - iIndex);

            return sSource.Substring(iIndex, iMul);
        }

        /// <summary>
        /// 일부 확실한 타입과 내용들만 처리
        /// </summary>
        /// <param name="cStepData"></param>
        /// <returns></returns>
        protected void ArrangeContact(CILStepData cStepData)
        {
            List<CContactData> lstFindContact = cStepData.ContactList.FindAll(a => a.ContactType == EMContactType.NONE);
            if (lstFindContact.Count == 0 && cStepData.Command.FactorCount == cStepData.ContactList.Count)
            {
                for (int i = 0; i < cStepData.ContactList.Count; i++)
                    cStepData.ContactList[i].FusionResultString = cStepData.ContactList[i].ResultString;
                cStepData.AnalyzeComp = true;
            }
            else if (cStepData.Command.FactorCount == 2 && cStepData.ContactList.Count == 5)
            {
                for (int i = 0; i < cStepData.ContactList.Count; i++)
                {
                    if (cStepData.ContactList[i].Header == "K" && cStepData.ContactList[i + 1].Header == "Z" && cStepData.ContactList[i + 2].ContactType == EMContactType.Address)
                    {
                        cStepData.ContactList[i + 2].FusionResultString = cStepData.ContactList[i].ResultString + cStepData.ContactList[i + 2].ResultString + cStepData.ContactList[i + 1].ResultString;
                        cStepData.ContactList[i + 1].ContactType = EMContactType.Index_Z;
                        cStepData.ContactList[i].ContactType = EMContactType.Header_K;
                        i += 2;
                    }
                    else if (cStepData.ContactList[i].Header == "K" && cStepData.ContactList[i + 1].ContactType == EMContactType.Address)
                    {
                        cStepData.ContactList[i + 1].FusionResultString = cStepData.ContactList[i].ResultString + cStepData.ContactList[i + 1].ResultString;
                        cStepData.ContactList[i].ContactType = EMContactType.Header_K;
                        i++;
                    }
                    else if (cStepData.ContactList[i].Header == "Z" && cStepData.ContactList[i + 1].ContactType == EMContactType.Address)
                    {
                        cStepData.ContactList[i + 1].FusionResultString = cStepData.ContactList[i + 1].ResultString + cStepData.ContactList[i].ResultString;
                        cStepData.ContactList[i].ContactType = EMContactType.Index_Z;
                        i++;
                    }
                }
                cStepData.AnalyzeComp = true;
            }
            else if (cStepData.Command.FactorCount == 2 && cStepData.ContactList.Count == 6)
            {
                for (int i = 0; i < cStepData.ContactList.Count; i++)
                {
                    if (cStepData.ContactList[i].Header == "K" && cStepData.ContactList[i + 1].Header == "Z" && cStepData.ContactList[i + 2].ContactType == EMContactType.Address)
                    {
                        cStepData.ContactList[i + 2].FusionResultString = cStepData.ContactList[i].ResultString + cStepData.ContactList[i + 2].ResultString + cStepData.ContactList[i + 1].ResultString;
                        cStepData.ContactList[i + 1].ContactType = EMContactType.Index_Z;
                        cStepData.ContactList[i].ContactType = EMContactType.Header_K;
                        i += 2;
                    }
                }
                cStepData.AnalyzeComp = true;
            }
            else if (lstFindContact.Count == 0 && cStepData.Command.FactorCount < cStepData.ContactList.Count)
            {
                for (int i = 0; i < cStepData.ContactList.Count; i++)
                {
                    if (cStepData.ContactList[i].ContactType == EMContactType.DOT)
                    {
                        cStepData.ContactList[i + 1].FusionResultString = cStepData.ContactList[i + 1].ResultString + cStepData.ContactList[i].ResultString;
                        i++;
                    }
                    else if (cStepData.ContactList[i].ContactType == EMContactType.Header_AT && cStepData.ContactList[i + 1].ContactType == EMContactType.Address)
                    {
                        cStepData.ContactList[i + 1].FusionResultString = cStepData.ContactList[i].ResultString + cStepData.ContactList[i + 1].ResultString;
                        i++;
                    }
                    else
                    {
                        cStepData.ContactList[i].FusionResultString = cStepData.ContactList[i].ResultString;
                    }
                }
                cStepData.AnalyzeComp = true;
            }
            else if (lstFindContact.Count != 0 && cStepData.Command.FactorCount == cStepData.ContactList.Count)
            {
                foreach (CContactData cData in lstFindContact)
                {
                    if (cData.Header == "K")
                        cData.ContactType = EMContactType.Constant_K;
                    else if (cData.Header == "Z")
                        cData.ContactType = EMContactType.Address;
                    else
                        Console.WriteLine("상수 K 에 속하지 않는다." + cData.ResultString);
                }
                for (int i = 0; i < cStepData.ContactList.Count; i++)
                    cStepData.ContactList[i].FusionResultString = cStepData.ContactList[i].ResultString;
                cStepData.AnalyzeComp = true;
            }
        }


        protected void ArrangeContact(List<CILStepData> lstStep)
        {
            foreach (CILStepData cStep in lstStep)
            {
                int iFactor = cStep.Command.FactorCount;
                if (iFactor == 0)
                {
                    cStep.AnalyzeComp = true;
                    continue;
                }
                List<CContactData> lstAddress = cStep.ContactList.FindAll(b => b.ContactType == EMContactType.Address || b.ContactType == EMContactType.Constant_K);
                List<CContactData> lstNone = cStep.ContactList.FindAll(b => b.ContactType == EMContactType.NONE);
                if (iFactor == lstAddress.Count)        //인자와 Address가 같으면 나머지는 상수 K 또는 Z인덱스
                {
                    for (int i = 0; i < cStep.ContactList.Count; i++)
                    {
                        if (cStep.ContactList[i].ContactType == EMContactType.NONE)
                        {
                            if (cStep.ContactList[i].Header == "K")
                            {
                                cStep.ContactList[i].ContactType = EMContactType.Header_K;
                                cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i].ResultString + cStep.ContactList[i + 1].ResultString;
                                i++;
                            }
                            else if (cStep.ContactList[i].Header == "Z")
                            {
                                cStep.ContactList[i].ContactType = EMContactType.Index_Z;
                                cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i + 1].ResultString + cStep.ContactList[i].ResultString;
                                i++;
                            }
                            else
                                Console.WriteLine("상수 K 에 속하지 않는다." + cStep.ContactList[i].ResultString);
                        }
                        else
                        {
                            if (cStep.ContactList[i].ContactType == EMContactType.Header_AT && cStep.ContactList[i + 1].ContactType == EMContactType.Address)
                            {
                                cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i].ResultString + cStep.ContactList[i + 1].ResultString;
                                i++;
                            }
                            else
                                cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                        }
                    }
                    cStep.AnalyzeComp = true;
                }
                else// if (iFactor == lstAddress.Count + 1)
                {
                    string sIndex = "";
                    for (int i = 0; i < cStep.ContactList.Count; i++)
                    {
                        if (cStep.Command.FactorCount < cStep.ContactList.Count)
                        {
                            if (cStep.ContactList[i].ContactType == EMContactType.DOT)
                            {
                                cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i + 1].ResultString + cStep.ContactList[i].ResultString;
                                i++;
                            }
                            else if (cStep.ContactList[i].ContactType == EMContactType.Header_AT && cStep.ContactList[i + 1].ContactType == EMContactType.Address)
                            {
                                cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i].ResultString + cStep.ContactList[i + 1].ResultString;
                                i++;
                            }
                            else
                            {
                                cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                            }
                            cStep.AnalyzeComp = true;
                        }
                        
                    }
                    for (int i = 0; i < cStep.ContactList.Count; i++)
                    {
                        if (cStep.ContactList[i].ContactType == EMContactType.NONE)
                        {
                            if (i < cStep.ContactList.Count - 1)
                            {
                                if (cStep.ContactList[i].Header == "Z" && cStep.ContactList[i + 1].Header == "K")
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Index_Z;
                                    cStep.ContactList[i + 1].ContactType = EMContactType.Constant_K;
                                    cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i + 1].ResultString + cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i + 1].FusionResultString + ", ";
                                    i++;
                                }
                                else if (cStep.ContactList[i].Header == "K" && cStep.ContactList[i + 1].Header == "K")
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Constant_K;
                                    cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i].FusionResultString + ", ";
                                }
                                else if (cStep.ContactList[i].Header == "K" && cStep.ContactList[i + 1].Header == "Z")
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Constant_K;
                                    cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i].FusionResultString + ", ";
                                }
                                else if (cStep.ContactList[i].Header == "K" && cStep.ContactList[i + 1].ContactType == EMContactType.Header_AT)
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Constant_K;
                                    cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i].FusionResultString + ", ";
                                }
                                else if (cStep.ContactList[i].Header == "Z" && cStep.ContactList[i + 1].Header == "Z")
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Address;
                                    cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i].FusionResultString + ", ";
                                }
                                else if (cStep.ContactList[i].Header == "K" && cStep.ContactList[i + 1].ContactType == EMContactType.Address)
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Header_K;
                                    cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i].ResultString + cStep.ContactList[i + 1].ResultString;
                                    sIndex += cStep.ContactList[i + 1].FusionResultString + ", ";
                                    i++;
                                }
                                else if (cStep.ContactList[i].Header == "Z" && cStep.ContactList[i + 1].ContactType == EMContactType.Address)
                                {
                                    cStep.ContactList[i].ContactType = EMContactType.Index_Z;
                                    cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i + 1].ResultString + cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i + 1].FusionResultString + ", ";
                                    i++;
                                }
                                else if (cStep.ContactList[i].ContactType == EMContactType.Header_AT && cStep.ContactList[i + 1].ContactType == EMContactType.Address)
                                {
                                    cStep.ContactList[i + 1].FusionResultString = cStep.ContactList[i].ResultString + cStep.ContactList[i + 1].ResultString;
                                    sIndex += cStep.ContactList[i + 1].FusionResultString + ", ";
                                    i++;
                                }
                                else
                                {
                                    cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                    sIndex += cStep.ContactList[i].FusionResultString + ", ";
                                }
                            }
                            else
                            {
                                if (cStep.ContactList[i].ContactType == EMContactType.NONE)
                                {
                                    if (cStep.ContactList[i].Header == "K")
                                        cStep.ContactList[i].ContactType = EMContactType.Constant_K;
                                    else if (cStep.ContactList[i].Header == "Z")
                                        cStep.ContactList[i].ContactType = EMContactType.Address;
                                    else
                                        Console.WriteLine("");
                                }
                                cStep.ContactList[i].FusionResultString = cStep.ContactList[i].ResultString;
                                sIndex += cStep.ContactList[i].FusionResultString + ", ";
                            }
                        }                        
                    }
                    lstNone.Clear();
                    lstNone = cStep.ContactList.FindAll(b => b.ContactType == EMContactType.NONE);
                    if (lstNone.Count > 0)
                    {
                        int aao = 0;
                    }
                    cStep.AnalyzeComp = true;
                }
                //else
                //{
                //    int a = 0;
                //}
            }
        }

        protected void WriteFinalLine(CILStepDataS cStepS)
        {
            int iStepCount = 0;
            foreach (CILStepData cStep in cStepS)
            {
                if (cStep.StepType == EMStepType.STATEMENT)
                {
                    //string sBuf = string.Format("{0}{1}",iStepCount, cStep.FinalStringList[0]);
                    string sBuf = string.Format("{0}", cStep.FinalStringList[0]);
                    cStep.FinalStringList[0] = sBuf;
                    cStepS.StepStringList.Add(sBuf);
                    iStepCount += cStep.StepGapNumber;
                }
                else
                {
                    List<CContactData> lstFinalContact = cStep.ContactList.FindAll(b => b.FusionResultString != "");
                    string sLine = "";
                    if (cStep.Command.FactorCount == 0 && lstFinalContact.Count == 0)
                    {
                        //sLine = string.Format("{0},,{1},,,,,,", iStepCount, cStep.Command.Command);
                        sLine = string.Format(",{0},,,,,,", cStep.Command.Command);
                        iStepCount += cStep.Command.FactorCount;
                        cStep.FinalStringList.Add(sLine);
                        cStepS.StepStringList.Add(sLine);
                    }
                    else if (cStep.Command.FactorCount == 0 && lstFinalContact.Count == 1)
                    {
                        sLine = string.Format(",{0},,,,,,", lstFinalContact[0].FusionResultString);
                        cStep.FinalStringList.Add(sLine);
                        cStepS.StepStringList.Add(sLine);
                        iStepCount += cStep.Command.FactorCount;
                    }
                    else if (cStep.Command.FactorCount == lstFinalContact.Count)
                    {
                        sLine = string.Format(",{0},{1},,,,,", cStep.Command.Command, lstFinalContact[0].FusionResultString);
                        iStepCount += cStep.Command.FactorCount;
                        cStepS.StepStringList.Add(sLine);
                        cStep.FinalStringList.Add(sLine);
                        bool bFirst = true;
                        for (int i = 0; i < cStep.ContactList.Count; i++)
                        {
                            if (cStep.ContactList[i].FusionResultString != "")
                            {
                                if (bFirst == false)
                                {
                                    sLine = string.Format(",,{0},,,,,", cStep.ContactList[i].FusionResultString);
                                    cStep.FinalStringList.Add(sLine);
                                    cStepS.StepStringList.Add(sLine);
                                }
                                else
                                    bFirst = false;
                            }
                            if (cStep.ContactList[i].LadderNote != "")
                            {
                                cStep.FinalStringList.Add(cStep.ContactList[i].LadderNote);
                                cStepS.StepStringList.Add(cStep.ContactList[i].LadderNote);
                            }
                        }
                    }
                    else
                        continue;
                }
            }
            cStepS.StepStringList.Add(",,,,,,,");
        }

        #endregion
    }
}
