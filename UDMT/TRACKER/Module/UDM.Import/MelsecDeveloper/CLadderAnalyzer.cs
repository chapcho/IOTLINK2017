using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace USB_DataRead
{
    public class CLadderAnalyzer
    {
        #region Member Variables

        Dictionary<byte[], CMelsecCommand> _dicCommandDB = new Dictionary<byte[], CMelsecCommand>();

        private byte[] _iaAddressHeader = {     0x82, 0x90, 0x91, 0x92, 0x93, 0x94, 0x98, 0x99, 0x9C, 0x9D, 0x9E, 0x9F, 0xA0, 0xA1, 0xA2,
                                                0xA3, 0xA8, 0xA9, 0xAA, 0xAB, 0xAF, 0xB0, 0xB4, 0xB5, 0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5,
                                                0xC6, 0xC7, 0xC8, 0xCC, 0xCD, 0xD0, 0xD2, 0xD8, 0xD9, 0xDC, 0xE8, 0xE9, 0xEA, 0xEB, 0xEC,
                                                0xEE, 0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF6, 0xF8, 0xF9, 0xFC, 0x80 };
        private string[] _sAddressHeader = {     ";",  "M", "SM",  "L",  "F",  "V",  "S", "TR",  "X",  "Y", "FX", "FY",  "B", "SB", "DX",
                                                "DY",  "D", "SD", "FD",  "G",  "R", "ZR",  "W", "SW", "TC", "TS",  "T", "CC", "CS",  "C",
                                                "SC", "SS", "ST",  "Z",  "V",  "P",  "N",  "U",  "J", "BL",  "K",  "K",  "H",  "H",  "E",
                                                "\"",  "Z",  "K",  ".",  "@",  "V", "ZZ",  "U",  "J", "BL",  ";" };
        
        private string[] _saSpecialHeader = { "Un\\G", "Jn\\X", "Jn\\Y", "Jn\\B", "Jn\\SB",
                                              "Jn\\W", "Jn\\SW","BLn\\S", "BLn\\TR" };


        private List<byte[]> _lstSpecialByte = new List<byte[]>();
        private const string _CommandFileName = "USB_DataRead.MelsecLadderCommand.txt";
        #endregion


        #region Initialize

        public CLadderAnalyzer()
        {
            _lstSpecialByte.Add(new byte[] { 0xAB, 0xF8 });
            _lstSpecialByte.Add(new byte[] { 0x9C, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0x9D, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0xA0, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0xA1, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0xB4, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0xB5, 0xF9 });
            _lstSpecialByte.Add(new byte[] { 0x98, 0xFC });
            _lstSpecialByte.Add(new byte[] { 0x99, 0xFC });

        }

        #endregion


        #region Properties

        Dictionary<byte[], CMelsecCommand> CommandDB
        {
            get { return _dicCommandDB; }
        }

        #endregion


        #region Public Method

        public bool CommandOpen()
        {

            Assembly _assembly = Assembly.GetExecutingAssembly();
            //Stream _fileStream = _assembly.GetManifestResourceStream(_CommandFileName);
            StreamReader read = new StreamReader(_assembly.GetManifestResourceStream(_CommandFileName));
            string sLine = "";

            while ((sLine = read.ReadLine()) != null)
            {
                if (sLine.Contains("^"))
                {
                    CMelsecCommand cMCommand = new CMelsecCommand();

                    string[] sSplit = sLine.Split('^');
                    if (sSplit.Length != 4)
                    {
                        Console.WriteLine("명령어 오류 : " + sLine);
                        continue;
                    }
                    cMCommand.Command = sSplit[0];
                    string[] sSplit2 = sSplit[1].Split(',');
                    byte[] naSp = new byte[sSplit2.Length];

                    for (int i = 0; i < sSplit2.Length; i++)
                    {
                        int iValue = -1;
                        bool bOK = int.TryParse(sSplit2[i], out iValue);
                        if (bOK)
                            naSp[i] = (byte)iValue;
                        else
                            Console.WriteLine("변환 불가 : " + sLine);
                    }
                    cMCommand.FactorCount = Convert.ToInt32(sSplit[2]);
                    cMCommand.StepNumberCount = Convert.ToInt32(sSplit[3]);
                    _dicCommandDB.Add(naSp, cMCommand);
                }
            }
            read.Close();
            read.Dispose();
            read = null;

            return true;
        }

        private void AnalyzeCommand4ByteOver(CLogicBaseBlock cBlock)
        {
            byte[] naSource = cBlock.TargetByte;
            byte[] nBuffer = new byte[naSource.Length - 4];
            byte[] nREAD = { 0x52, 0x45, 0x41, 0x44 };
            byte[] nSWRITE = { 0x53, 0x57, 0x52, 0x49, 0x54, 0x45 };
            byte[] nDDRD = { 0x44, 0x44, 0x52, 0x44 };
            byte[] nDDWR = { 0x44, 0x44, 0x57, 0x52 };

            Dictionary<byte[], string> dicCheck = new Dictionary<byte[], string>();
            dicCheck.Add(nREAD, "READ");
            dicCheck.Add(nSWRITE, "SWRITE");
            dicCheck.Add(nDDRD, "DDRD");
            dicCheck.Add(nDDWR, "DDWR");

            foreach (var who in _dicCommandDB)
            {
                if (who.Key.Length == 4)
                {
                    if (who.Key[0] == naSource[0] && who.Key[3] == naSource[3])
                    {
                        cBlock.ResultString = who.Value.Command;
                        for (int i = 0; i < nBuffer.Length; i++)
                            nBuffer[i] = naSource[i + 4];
                        
                        foreach (var who2 in dicCheck)
                        {
                            bool bOK = nBuffer.SequenceEqual(who2.Key);
                            if (bOK)
                            {
                                cBlock.ResultString += who2.Value;
                                cBlock.StepNumberCount = who.Value.StepNumberCount;
                                cBlock.FactorCount = who.Value.FactorCount;
                                cBlock.AnalyzeComplete = true;
                            }
                        }
                        if (cBlock.AnalyzeComplete == false)
                            cBlock.ResultString = "";
                    }
                }
            }
        }

        private bool AnalyzeCommand4ByteOver(byte[] naSource, CMelsecCommand cCommand)
        {
            byte[] nBuffer = new byte[naSource.Length - 4];
            byte[] nREAD = { 0x52, 0x45, 0x41, 0x44 };
            byte[] nSWRITE = { 0x53, 0x57, 0x52, 0x49, 0x54, 0x45 };
            byte[] nDDRD = { 0x44, 0x44, 0x52, 0x44 };
            byte[] nDDWR = { 0x44, 0x44, 0x57, 0x52 };

            Dictionary<byte[], string> dicCheck = new Dictionary<byte[], string>();
            dicCheck.Add(nREAD, "READ");
            dicCheck.Add(nSWRITE, "SWRITE");
            dicCheck.Add(nDDRD, "DDRD");
            dicCheck.Add(nDDWR, "DDWR");

            bool bComp = false;

            foreach (var who in _dicCommandDB)
            {
                if (who.Key.Length == 4)
                {
                    if (who.Key[0] == naSource[0] && who.Key[3] == naSource[3])
                    {
                        cCommand.Command = who.Value.Command;
                        for (int i = 0; i < nBuffer.Length; i++)
                            nBuffer[i] = naSource[i + 4];

                        foreach (var who2 in dicCheck)
                        {
                            bool bOK = nBuffer.SequenceEqual(who2.Key);
                            if (bOK)
                            {
                                cCommand.Command += who2.Value;
                                cCommand.StepNumberCount = who.Value.StepNumberCount;
                                cCommand.FactorCount = who.Value.FactorCount;
                                bComp = true;
                            }
                        }
                        if (bComp == false)
                            cCommand.Command = "";
                    }
                }
            }
            return bComp;
        }

        private void ReanalyzeCommand(CLogicBaseBlock cBlock)
        {
            //4개중 1, 3번째만 맞을 경우
            Dictionary<byte, string> dicEndByteCompear = new Dictionary<byte, string>();
            dicEndByteCompear.Add(17, "AND");
            dicEndByteCompear.Add(18, "OR");
            dicEndByteCompear.Add(16, "LD");
            dicEndByteCompear.Add(2, "P");
            byte[] naSource = cBlock.TargetByte;

            foreach (var who in _dicCommandDB)
            {
                if (naSource.Length == 4)
                {
                    if (who.Key.Length == 3)
                    {
                        if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2])
                        {
                            foreach (var who2 in dicEndByteCompear)
                            {
                                if (naSource[3] == who2.Key && who2.Key != 2)
                                {
                                    cBlock.ResultString = who2.Value + who.Value.Command;
                                    cBlock.StepNumberCount = who.Value.StepNumberCount;
                                    cBlock.FactorCount = who.Value.FactorCount;
                                    cBlock.AnalyzeComplete = true;
                                    break;
                                }
                                else if (naSource[3] == who2.Key && who2.Key == 2)
                                {
                                    cBlock.ResultString = who.Value.Command + who2.Value;
                                    cBlock.StepNumberCount = who.Value.StepNumberCount;
                                    cBlock.FactorCount = who.Value.FactorCount;
                                    cBlock.AnalyzeComplete = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (naSource.Length == 2)
                {
                    if (who.Key.Length == 1)
                    {
                        if (who.Key[0] == naSource[0])
                        {
                            cBlock.ResultString = who.Value.Command;
                            cBlock.StepNumberCount = who.Value.StepNumberCount;
                            cBlock.FactorCount = who.Value.FactorCount;
                            cBlock.AnalyzeComplete = true;
                            break;
                        }
                    }
                }
            }
        }

        private bool ReanalyzeCommand(byte[] naSource, CMelsecCommand cCommand)
        {
            //4개중 1, 3번째만 맞을 경우
            Dictionary<byte, string> dicEndByteCompear = new Dictionary<byte, string>();
            dicEndByteCompear.Add(17, "AND");
            dicEndByteCompear.Add(18, "OR");
            dicEndByteCompear.Add(16, "LD");
            dicEndByteCompear.Add(2, "P");

            bool bComp = false;

            foreach (var who in _dicCommandDB)
            {
                if (naSource.Length == 4)
                {
                    if (who.Key.Length == 3)
                    {
                        if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2])
                        {
                            foreach (var who2 in dicEndByteCompear)
                            {
                                if (naSource[3] == who2.Key && who2.Key != 2)
                                {
                                    cCommand.Command = who2.Value + who.Value.Command;
                                    cCommand.StepNumberCount = who.Value.StepNumberCount;
                                    cCommand.FactorCount = who.Value.FactorCount;
                                    bComp = true;
                                    break;
                                }
                                else if (naSource[3] == who2.Key && who2.Key == 2)
                                {
                                    cCommand.Command = who.Value.Command + who2.Value;
                                    cCommand.StepNumberCount = who.Value.StepNumberCount;
                                    cCommand.FactorCount = who.Value.FactorCount;
                                    bComp = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (naSource.Length == 2)
                {
                    if (who.Key.Length == 1)
                    {
                        if (who.Key[0] == naSource[0])
                        {
                            cCommand.Command = who.Value.Command;
                            cCommand.StepNumberCount = who.Value.StepNumberCount;
                            cCommand.FactorCount = who.Value.FactorCount;
                            bComp = true;
                            break;
                        }
                    }
                }
            }
            return bComp;
        }

        public bool AnalyzeCommandByte(CLogicBaseBlock cBlock)
        {
            byte[] naSource = cBlock.TargetByte;
            foreach (var who in _dicCommandDB)
            {
                if (who.Key.Length == naSource.Length)
                {
                    bool bOK = naSource.SequenceEqual(who.Key);
                    if (bOK)
                    {
                        cBlock.ResultString = who.Value.Command;
                        cBlock.StepNumberCount = who.Value.StepNumberCount;
                        cBlock.FactorCount = who.Value.FactorCount;
                        cBlock.AnalyzeComplete = true;
                        break;
                    }
                    else
                    {
                        if (naSource.Length == 3)
                        {
                            if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2])
                            {
                                cBlock.ResultString = who.Value.Command;
                                cBlock.StepNumberCount = who.Value.StepNumberCount;
                                cBlock.FactorCount = who.Value.FactorCount;
                                cBlock.AnalyzeComplete = true;
                                break;
                            }
                        }
                        else if (naSource.Length == 4)
                        {
                            if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2] && who.Key[3] == naSource[3])
                            {
                                cBlock.ResultString = who.Value.Command;
                                cBlock.StepNumberCount = who.Value.StepNumberCount;
                                cBlock.FactorCount = who.Value.FactorCount;
                                cBlock.AnalyzeComplete = true;
                                break;
                            }
                            
                        }
                    }
                }
            }
            if (cBlock.AnalyzeComplete == false)
            {
                if (naSource.Length < 5)
                    ReanalyzeCommand(cBlock);
                else
                    AnalyzeCommand4ByteOver(cBlock);
            }
            if (cBlock.AnalyzeComplete)
                cBlock.BlockType = EMLadderBlockTpye.COMMAND;
            return cBlock.AnalyzeComplete;
        }

        public bool AnalyzeCommandByte(byte[] naSource, CMelsecCommand cCommand)
        {
            bool bComp = false;
            foreach (var who in _dicCommandDB)
            {
                if (who.Key.Length == naSource.Length)
                {
                    bool bOK = naSource.SequenceEqual(who.Key);
                    if (bOK)
                    {
                        cCommand.Command = who.Value.Command;
                        cCommand.StepNumberCount = who.Value.StepNumberCount;
                        cCommand.FactorCount = who.Value.FactorCount;
                        bComp = true;
                        break;
                    }
                    else
                    {
                        if (naSource.Length == 3)
                        {
                            if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2])
                            {
                                cCommand.Command = who.Value.Command;
                                cCommand.StepNumberCount = who.Value.StepNumberCount;
                                cCommand.FactorCount = who.Value.FactorCount;
                                bComp = true;
                                break;
                            }
                        }
                        else if (naSource.Length == 4)
                        {
                            if (who.Key[0] == naSource[0] && who.Key[2] == naSource[2] && who.Key[3] == naSource[3])
                            {
                                cCommand.Command = who.Value.Command;
                                cCommand.StepNumberCount = who.Value.StepNumberCount;
                                cCommand.FactorCount = who.Value.FactorCount;
                                bComp = true;
                                break;
                            }

                        }
                    }
                }
            }
            if (bComp == false)
            {
                if (naSource.Length < 5)
                    bComp = ReanalyzeCommand(naSource, cCommand);
                else
                    bComp = AnalyzeCommand4ByteOver(naSource, cCommand);
            }

            return bComp;
        }

        public string AnalyzeContactByte(byte[] naSource, out int iMajor)
        {
            string sHeader = "";
            iMajor = 0;
            for (int i = 0; i < _iaAddressHeader.Length; i++)
            {
                if (naSource[0] == _iaAddressHeader[i])
                {
                    sHeader = _sAddressHeader[i];
                }
            }

            if (sHeader != "" && sHeader != "\"")
            {
                int[] iaValue = { 0, 0, 0, 0 };
                if (naSource.Length == 5)
                {
                    iaValue[3] = naSource[4] << 24;
                    iaValue[2] = naSource[3] << 16;
                    iaValue[1] = naSource[2] << 8;
                    iaValue[0] = naSource[1];
                }
                else if (naSource.Length == 4)
                {
                    iaValue[2] = naSource[3] << 16;
                    iaValue[1] = naSource[2] << 8;
                    iaValue[0] = naSource[1];
                }
                else if (naSource.Length == 3)
                {
                    iaValue[1] = (short)naSource[2] << 8;
                    iaValue[0] = (short)naSource[1];
                }
                else if (naSource.Length == 2)
                {
                    iaValue[0] = naSource[1];
                }
                if (naSource.Length == 3 && sHeader == "K" && naSource[0] != 0xE9)  //16Bit 음수 변환
                {
                    int iSumValue = iaValue[1] + iaValue[0];
                    short aaaad = (short)iSumValue;
                    iMajor = aaaad;
                }
                else
                    iMajor = iaValue[3] + iaValue[2] + iaValue[1] + iaValue[0];

                //Hexa인지 아닌지 비교
                string sAddress = "";
                if (CheckEmptyHeader(sHeader))
                {
                    sAddress = sHeader;
                }
                else
                {
                    if (CheckHexaAdress(sHeader))
                    {
                        string sHexa = string.Format("{0:x}", iMajor).ToUpper();
                        string s1st = sHexa.Substring(0, 1);

                        if (CheckHexaZeroAdd(s1st) && sHeader != ".")
                            sHexa = "0" + sHexa;
                        sAddress = string.Format("{0}{1}", sHeader, sHexa);
                    }
                    else
                        sAddress = string.Format("{0}{1}", sHeader, iMajor);
                }

                return sAddress.ToUpper();
            }
            else
            {
                //$붙어 있는 $Mov
                byte[] nChar = new byte[naSource.Length - 1];
                for (int i = 0; i < nChar.Length; i++)
                    nChar[i] = naSource[i + 1];
                string sConvert = string.Format("\"\"\"{0}\"\"\"", Encoding.Default.GetString(nChar));
                return sConvert;

            }
            return "";
        }

        public string GetHeader(byte nHeader)
        {
            string sHeader = "";
            for (int i = 0; i < _iaAddressHeader.Length; i++)
            {
                if (nHeader == _iaAddressHeader[i])
                {
                    sHeader = _sAddressHeader[i];
                    break;
                }
            }
            return sHeader;
        }

        public int GetAddressCount(byte nFirst, byte nSecond, byte n3rd)
        {
            int[] iaValue = { 0, 0, 0 };
            int iResult = -1;
            iaValue[2] = n3rd << 16;
            iaValue[1] = nSecond << 8;
            iaValue[0] = nFirst;

            return iResult = iaValue[2] + iaValue[1] + iaValue[0];
        }

        public string GetSpecialHeader(byte nFirst, byte nSecond, byte nIndex)
        {
            string sResult = "";

            for (int i = 0; i < _lstSpecialByte.Count; i++)
            {
                if (_lstSpecialByte[i][0] == nFirst && _lstSpecialByte[i][1] == nSecond)
                    sResult = _saSpecialHeader[i];
            }
            string sHexa = string.Format("{0:x}", nIndex).ToUpper();
            string s1st = sHexa.Substring(0, 1);

            if (CheckHexaZeroAdd(s1st))
                sHexa = "0" + sHexa;

            return sResult.Replace("n", sHexa);
        }

        public bool CheckContactHeader(byte nHeader)
        {
            for (int i = 0; i < _iaAddressHeader.Length; i++)
            {
                if (nHeader == _iaAddressHeader[i])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSpecialHeader(byte nFirst, byte nSecond)
        {
            for (int i = 0; i < _lstSpecialByte.Count; i++)
            {
                if (_lstSpecialByte[i][0] == nFirst && _lstSpecialByte[i][1] == nSecond)
                    return true;
            }

            return false;
        }

        public bool CheckHexaZeroAdd(string sFirst)
        {
            string[] saValue = { "A", "B", "C", "D", "E", "F" };
            for (int i = 0; i < saValue.Length; i++)
            {
                if (saValue[i] == sFirst)
                    return true;
            }
            return false;
        }

        public bool CheckHexaAdress(string sHeader)
        {
            string[] saHexaHeader = { "X", "Y", "FX", "FY", "B", "SB", "DX", "DY", "W", "SW", "U", "H", ".", "U" };
            for (int i = 0; i < saHexaHeader.Length; i++)
            {
                if (saHexaHeader[i] == sHeader)
                    return true;
            }
            return false;
        }

        private bool CheckEmptyHeader(string sHeader)
        {
            string[] saHexaHeader = { "@" };
            for (int i = 0; i < saHexaHeader.Length; i++)
            {
                if (saHexaHeader[i] == sHeader)
                    return true;
            }
            return false;
        }

        #endregion

    }
}
