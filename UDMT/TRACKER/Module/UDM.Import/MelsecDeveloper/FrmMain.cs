using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace USB_DataRead
{
    public partial class FrmMain : Form
    {
        private string _DeviceID = string.Empty;
        private string _PNPDeviceID = string.Empty;
        private string _Description = string.Empty;
        protected DataTable m_tblComInfo = new DataTable();

        CMelsecProjectAnalyzer _cAnalyze = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //CUSBDeviceInfo device = new CUSBDeviceInfo("", "", "");
            //List<CUSBDeviceInfo> lstDevice = device.GetUSBDeviceList();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();

            byte[] nReadData = File.ReadAllBytes(openDlg.FileName);

            if (nReadData == null) return;

            if (nReadData.Length == 0) return;

            byte[] nTilte = new byte[32];

            for (int i = 0; i < nTilte.Length; i++)
            {
                nTilte[i] = nReadData[i + 4];
            }

            byte[] nHeaderEnd = new byte[4];

            for (int i = 0; i < nHeaderEnd.Length; i++)
                nHeaderEnd[i] = nReadData[i + 64];

            string sTilte = "";
            if (nHeaderEnd[0] == 0x04 && nHeaderEnd[1] == 0x00 && nHeaderEnd[2] == 0xff && nHeaderEnd[3] == 0xff)
            {
                sTilte = Encoding.Default.GetString(nTilte);
            }
            //순서가 존재 명령어가 나오고 반드시 접점 혹은 상수가 나온다.

            sTilte = sTilte.Trim();

            //블럭 단위로 분리==============================================================OK
            
            Dictionary<int, CLogicBaseBlock> dicPassing = new Dictionary<int, CLogicBaseBlock>();
            //Block 형식
            //0x03, 0x90, 0x03첫번째 바이트가 자신을 포함한 총 Byte수를 뜻함.만약 0x0a....0x0a라고 한다면 10개 Byte를 뜻함.
            for (int i = 68; i < nReadData.Length; i++)
            {
                int iBlockCount = nReadData[i];
                CLogicBaseBlock cBlock = new CLogicBaseBlock();
                cBlock.BlockByteORG = new byte[iBlockCount];
                for (int k = 0; k < iBlockCount; k++)
                    cBlock.BlockByteORG[k] = nReadData[i + k];

                //앞뒤 제거(블럭 구분을 위해 했지만 불필요 함)
                cBlock.TargetByte = new byte[iBlockCount - 2];
                for (int k = 1; k < iBlockCount; k++)
                {
                    if (k < iBlockCount - 1)
                        cBlock.TargetByte[k - 1] = nReadData[i + k];
                }
                if (cBlock.TargetByte[0] == 0x80)
                {
                    cBlock.BlockType = EMLadderBlockTpye.STATEMENT;
                    cBlock.AnalyzeComplete = true;
                    if (cBlock.TargetByte[1] == 0x01 && cBlock.TargetByte.Length == 2)
                        cBlock.ResultString = "*";
                    else
                    {
                        byte[] nAscii = new byte[cBlock.TargetByte.Length - 2];
                        for (int k = 0; k < nAscii.Length; k++)
                            nAscii[k] = cBlock.TargetByte[k + 2];
                        cBlock.ResultString = Encoding.Default.GetString(nAscii);
                    }
                }
                dicPassing.Add(i, cBlock);
                i += iBlockCount - 1;
            }
            
            //==============================================================================OK

            CLadderAnalyzer cAnaly = new CLadderAnalyzer();
            cAnaly.CommandOpen();

            #region 블럭 단위 분석

            //블럭 단위 분석================================================================
            Dictionary<int, CLogicBaseBlock> dicNotMatchBlock = new Dictionary<int, CLogicBaseBlock>();
            List<CLogicStep> cStepList = new List<CLogicStep>();
            CLogicStep cLogicStep = new CLogicStep();

            txtNotMatch.Clear();
            int iStep = 0;
            int iAddDWordStep = 0;
            foreach (var who in dicPassing)
            {
                //명령어 구분
                CLogicBaseBlock cBlock = who.Value;
                if (cBlock.BlockType == EMLadderBlockTpye.STATEMENT)
                {
                    if (cLogicStep.BlockList.Count > 0)
                    {
                        //cLogicStep.StepString = AddComma(cLogicStep.StepString);
                        //if (cLogicStep.StepString == "")
                        //    txtNotMatch.AppendText("Error : " + cLogicStep.StepNumber.ToString());
                        cStepList.Add(cLogicStep);
                        cLogicStep = new CLogicStep();
                        iStep += iAddDWordStep;
                        iAddDWordStep = 0;
                    }
                    cLogicStep.BlockList.Add(cBlock);
                    cLogicStep.StepNumber = iStep;
                    cLogicStep.StepString = cBlock.ResultString + ",,,,,,,";
                    cStepList.Add(cLogicStep);
                    cLogicStep = new CLogicStep();
                    if (cBlock.ResultString != "*")
                        iStep += cBlock.TargetByte.Length / 2 + 2;  //소비 스텝(2+문자수/2) 2는 고정
                    else
                        iStep++;
                }
                else
                {
                    bool bOK = cAnaly.AnalyzeCommandByte(cBlock);
                    if (bOK == false)
                    {
                        int iValue = 0;
                        string sResult = cAnaly.AnalyzeContactByte(cBlock.TargetByte, out iValue);
                        if (sResult != "")
                        {
                            cBlock.ResultString = sResult;
                            if (cLogicStep.BlockList[0].ResultString == "OUT" && (sResult.Contains("T") || sResult.Contains("C")))
                            {
                                iAddDWordStep += 3;
                            }

                            if (ContactCheck(sResult))
                            {
                                if (CheckDWord(sResult, cLogicStep.BlockList[0].ResultString))
                                    iAddDWordStep++;
                                else if (cLogicStep.BlockList[0].ResultString.Contains("$"))
                                    iAddDWordStep += cBlock.TargetByte.Length / 2;
                                cBlock.BlockType = EMLadderBlockTpye.CONTACT;

                                
                            }
                            else
                            {
                                if (sResult.Contains("."))
                                    cBlock.BlockType = EMLadderBlockTpye.DOT;
                                else
                                    cBlock.BlockType = EMLadderBlockTpye.OTHER;
                            }
                            cLogicStep.BlockList.Add(cBlock);
                            //cLogicStep.StepString += cBlock.ResultString + ",";
                            cBlock.AnalyzeComplete = true;
                        }
                        else
                        {
                            dicNotMatchBlock.Add(who.Key, who.Value);
                            string sNotMatch = who.Key.ToString() + " : ";
                            for (int h = 0; h < cBlock.TargetByte.Length; h++)
                            {
                                string s = string.Format("{0:x2}", cBlock.TargetByte[h]);
                                sNotMatch += s + ", ";
                            }
                            sNotMatch += "\r\n";
                            txtNotMatch.AppendText(sNotMatch);
                        }
                    }
                    else
                    {
                        if (cLogicStep.BlockList.Count > 0)
                        {
                            //cLogicStep.StepString = AddComma(cLogicStep.StepString);
                            //if (cLogicStep.StepString == "")
                            //    txtNotMatch.AppendText("Error : " + cLogicStep.StepNumber.ToString());
                            //if (CheckOper(cLogicStep.BlockList[0].ResultString) && cLogicStep.BlockList.Count == 3)
                            //{
                            //    iAddDWordStep -= 1;
                            //}
                            //else 
                                if (cLogicStep.BlockList[0].ResultString == "MOV" && cLogicStep.BlockList[1].ResultString == "K2" && cLogicStep.BlockList.Count == 5)
                            {
                                iAddDWordStep++;
                            }

                            cStepList.Add(cLogicStep);
                            cLogicStep = new CLogicStep();
                            cLogicStep.BlockList.Add(cBlock);
                            

                            cLogicStep.StepNumber = iStep + iAddDWordStep;
                            //cLogicStep.StepString = cBlock.ResultString + ",";
                            iStep += cBlock.StepNumberCount + iAddDWordStep;
                            iAddDWordStep = 0;
                        }
                        else
                        {
                            //cLogicStep.StepString = AddComma(cLogicStep.StepString);
                            //if (cLogicStep.StepString == "")
                            //    txtNotMatch.AppendText("Error : " + cLogicStep.StepNumber.ToString());
                            cLogicStep.BlockList.Add(cBlock);
                            cLogicStep.StepNumber = iStep;
                            //cLogicStep.StepString = cBlock.ResultString + ",";
                            iStep += cBlock.StepNumberCount;
                        }

                    }
                }
            }
            if(cLogicStep.BlockList.Count >0)
                cStepList.Add(cLogicStep);

            foreach (CLogicStep step in cStepList)
            {
                if (step.BlockList[0].BlockType == EMLadderBlockTpye.COMMAND)
                {
                    step.CreateStepString();
                }
            }
            //List<CLogicBaseBlock> lstLogic = dicPassing.Select(x => x.Value).Where(x=> x.AnalyzeComplete == false).ToList();

            //==============================================================================

            #endregion

            #region 비교 파일 읽기

            openDlg.ShowDialog();

            string[] saCompareFileString = File.ReadAllLines(openDlg.FileName);
            List<string> lstStep = new List<string>();
            for (int i = 0; i < saCompareFileString.Length; i++)
            {
                int iStepNumberIndex = saCompareFileString[i].IndexOf(",") + 1;
                int iLength = saCompareFileString[i].Length - iStepNumberIndex;
                string sSSS = saCompareFileString[i].Substring(iStepNumberIndex, iLength);
                lstStep.Add(sSSS);
            }

            #endregion

            CreateTable(cStepList, lstStep);
            grdMain.DataSource = m_tblComInfo;
            grdMain.RefreshDataSource();

        }

        private string AddComma(string sSource)
        {
            if (sSource.Contains(",") == false)
                return "";
            string[] sSplit = sSource.Split(',');
            int iAddCount = 7 - sSplit.Length;

            for (int i = 0; i < iAddCount; i++)
            {
                sSource += ",";
            }

            return sSource;
        }

        private bool CheckOper(string sSource)
        {
            string[] sSumCommand = { "+", "-", "*" };
            for (int k = 0; k < sSumCommand.Length; k++)
            {
                if (sSource.Contains(sSumCommand[k]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDWord(string sHeader, string sCommand)
        {
            string[] sDWordHeader = { "ZR" };
            string[] sSumCommand = { "MOV", "LIMIT", "+", "-", "*", "DBL", "FOR" };
            for (int k = 0; k < sSumCommand.Length; k++)
            {
                if (sCommand.Contains(sSumCommand[k]))
                {
                    for (int i = 0; i < sDWordHeader.Length; i++)
                    {
                        if (sHeader.Contains(sDWordHeader[i]))
                            return true;
                    }
                }
            }

            return false;
        }

        private bool ContactCheck(string sSource)
        {
            string[] saHexaHeader = { "@", "K", "."};
            for (int i = 0; i < saHexaHeader.Length; i++)
            {
                if (sSource.Contains(saHexaHeader[i]) && sSource.Contains("\"\"\"") == false)
                    return false;
            }
            return true;
        }

        private void CreateTable(Dictionary<int, CLogicStep> dicLogic)
        {
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Step");
            m_tblComInfo.Columns.Add("Logic");

            foreach (var who in dicLogic)
            {
                m_tblComInfo.Rows.Add(new object[] { who.Key.ToString(), who.Value.StepString });
            }
        }

        private void CreateTable(List<CLogicStep> lstLogicStep, List<string> lstCompare)
        {
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Logic");
            m_tblComInfo.Columns.Add("ORG Logic");

            int iCount = 0;
            for (int i = 0; i < lstLogicStep.Count; i++)
            {
                CLogicStep step = lstLogicStep[i];
                string s = "";
                
                if (step.StepString.Contains("\r"))
                {
                    string[] saSplit = step.StepString.Split('\r');
                    bool bMinus = false;
                    for (int k = 0; k < saSplit.Length; k++)
                    {
                        if (saSplit[k] == "")
                            continue;
                        if (bMinus)
                        {
                            //saSplit[k] = saSplit[k].Replace(",,,,,", ",,,,,,,");
                        }
                        if (saSplit[k].Contains("K-"))
                        {
                            //saSplit[k] = saSplit[k].Replace(",,,,,", ",,,");
                            bMinus = true;
                        }
                        if (k == 0)
                            //s = string.Format("{0},,{1}", step.StepNumber, saSplit[i]);
                            s = string.Format(",{0}", saSplit[k]);
                        else
                            s = string.Format(",,{0}", saSplit[k]);
                        m_tblComInfo.Rows.Add(new object[] { s, lstCompare[iCount] });

                        if (s != lstCompare[iCount])
                        {
                            txtNotMatch.AppendText(iCount.ToString() + " : " + s + ":" + lstCompare[iCount] + "\r\n");
                        }
                        iCount++;
                    }
                }
                else
                {
                    if (step.BlockList[0].BlockType == EMLadderBlockTpye.STATEMENT)
                        //s = string.Format("{0},{1}", step.StepNumber, step.StepString);
                        s = string.Format("{0}", step.StepString);
                    else
                        s = string.Format(",{0}", step.StepString);
                    m_tblComInfo.Rows.Add(new object[] { s, lstCompare[iCount] });

                    if (s != lstCompare[iCount])
                    {
                        txtNotMatch.AppendText(iCount.ToString() + " : " + s + ":" + lstCompare[iCount] + "\r\n");
                    }
                    iCount++;
                }


            }
        }

        private void CreateTable(List<string> lstLogicStep, List<string> lstCompare)
        {
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Logic");
            m_tblComInfo.Columns.Add("ORG Logic");
            m_tblComInfo.Columns.Add("Compare");

            int iCount = 0;
            if (lstCompare.Count < lstLogicStep.Count)
                iCount = lstCompare.Count;
            else
                iCount = lstLogicStep.Count;

            for (int i = 0; i < iCount; i++)
            {
                bool bCompare = false;

                if (lstLogicStep[i] == lstCompare[i]) bCompare = true;

                m_tblComInfo.Rows.Add(new object[] { lstLogicStep[i], lstCompare[i], bCompare });
            }
        }


        private void CreateTable(Dictionary<int, CLogicBaseBlock> dicPassing)
        {
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("Step");
            m_tblComInfo.Columns.Add("Logic");

            List<CLogicBaseBlock> lstLogig = new List<CLogicBaseBlock>();
            foreach (var who in dicPassing)
                lstLogig.Add(who.Value);

            int iStepCount = -1;
            bool bSetpComp = false;
            string sLogic = "";
            for (int i = 0; i < lstLogig.Count; i++)
            {
                CLogicBaseBlock cBlock = lstLogig[i];
                CLogicBaseBlock cNextBlock = null;
                CLogicBaseBlock cBeforeBlock = null;

                if (cBlock.AnalyzeComplete == false)
                {
                    string sss = "";
                    for (int k = 0; k < cBlock.TargetByte.Length; k++)
                    {
                        sss += string.Format("{0:x2}", cBlock.TargetByte[k]);
                    }
                    Console.WriteLine(sss);
                    //break;
                    if (sLogic != "")
                    {
                        bSetpComp = false;
                        m_tblComInfo.Rows.Add(new object[] { iStepCount.ToString(), sLogic });
                        iStepCount++;
                    }
                    sLogic = "";
                    m_tblComInfo.Rows.Add(new object[] { iStepCount.ToString(), "!!!!!!!!!!NOT FOUND!!!!!!!!!!!!" });
                    iStepCount++;
                    continue;
                }

                if (lstLogig[i].ResultString == "SUB")
                    continue;

                if (i > 0 && i < lstLogig.Count - 1)
                {
                    cBeforeBlock = lstLogig[i - 1];
                    cNextBlock = lstLogig[i + 1];

                    if (cNextBlock.BlockType == EMLadderBlockTpye.COMMAND || cNextBlock.BlockType == EMLadderBlockTpye.STATEMENT)
                        bSetpComp = true;

                    sLogic += cBlock.ResultString + ", ";
                    //if (cNextBlock.BlockType != EMLadderBlockTpye.COMMAND)
                    iStepCount++;
                    if (cNextBlock.BlockType == EMLadderBlockTpye.COMMAND && cBeforeBlock.BlockType == EMLadderBlockTpye.COMMAND)
                        iStepCount -= 1;
                }
                else if (i == 0)
                {
                    cNextBlock = lstLogig[i + 1];
                    sLogic = cBlock.ResultString + ", ";
                    iStepCount = 0;
                    if (cNextBlock.BlockType == EMLadderBlockTpye.COMMAND || cNextBlock.BlockType == EMLadderBlockTpye.STATEMENT)
                        bSetpComp = true;
                }
                else if (i == lstLogig.Count - 1)
                {
                    sLogic = cBlock.ResultString;
                }

                if (bSetpComp)
                {
                    bSetpComp = false;
                    m_tblComInfo.Rows.Add(new object[] { iStepCount.ToString(), sLogic });
                    sLogic = "";
                }
            }
            if (sLogic != "")
            {
                m_tblComInfo.Rows.Add(new object[] { iStepCount.ToString(), sLogic });
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
            //File Open
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "*.gpj|*.gpj";
            openDlg.ShowDialog();
/*
            byte[] nReadData = File.ReadAllBytes(openDlg.FileName);

            if (nReadData == null) return;

            if (nReadData.Length == 0) return;

            byte[] nTilte = new byte[32];

            for (int i = 0; i < nTilte.Length; i++)
            {
                nTilte[i] = nReadData[i + 4];
            }

            byte[] nHeaderEnd = new byte[4];

            for (int i = 0; i < nHeaderEnd.Length; i++)
                nHeaderEnd[i] = nReadData[i + 64];

            string sTilte = "";
            if (nHeaderEnd[0] == 0x04 && nHeaderEnd[1] == 0x00 && nHeaderEnd[2] == 0xff && nHeaderEnd[3] == 0xff)
            {
                sTilte = Encoding.Default.GetString(nTilte);
                txtNotMatch.AppendText(sTilte + "\r\n");
            }
             */
            if (_cAnalyze != null)
            {
                _cAnalyze = null;
            }
            _cAnalyze = new CMelsecProjectAnalyzer();
            string[] sSplit = openDlg.FileName.Split('\\');
            string sBasePath = "";
            for (int i = 0; i < sSplit.Length - 1; i++)
                sBasePath += string.Format("{0}\\", sSplit[i]);
            
            _cAnalyze.OpenGPJ_File(openDlg.FileName, sBasePath);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 비교 파일 읽기

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "*.csv|*.csv";
            openDlg.ShowDialog();

            string[] saCompareFileString = File.ReadAllLines(openDlg.FileName);
            List<string> lstStep = new List<string>();
            for (int i = 0; i < saCompareFileString.Length; i++)
            {
                int iStepNumberIndex = saCompareFileString[i].IndexOf(",") + 1;
                int iLength = saCompareFileString[i].Length - iStepNumberIndex;
                string sSSS = saCompareFileString[i].Substring(iStepNumberIndex, iLength);
                lstStep.Add(sSSS);
            }

            #endregion

            string[] sSplit2 = openDlg.FileName.Split('\\');
            string[] sFileName = sSplit2[sSplit2.Length - 1].Split('.');

            List<string> lstLine = _cAnalyze.WPGAnalyzeResult[sFileName[0]].StepStringList;

            CreateTable(lstLine, lstStep);
            grdMain.DataSource = m_tblComInfo;
            grdMain.RefreshDataSource();
        }

    }
}
