// #define INDIRECT_CONSIST
// #define STEPINCREASE_DEVICE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ComponentModel;
using UDM.Import.ME.DataStruct;
using System.Diagnostics;
using UDM.Import.ME.Translator.Define;
using UDM.Import.ME.Translator.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace UDM.Import.ME
{
    public sealed class UDMGXDevelopLadderTracer : LadderTranslator, ILadderTranslator, IDisposable
    {

        #region ladder translator variable define

        public PlcCommandS dicPlcCommandS;
        public Dictionary<String, PLCDeviceComment> dicPlcCommentS;
        public PLCLadderNodeS plcLadderNodsS;
        private PlcLadderNode nextProgramLine;
        public PlcLadderTracerRunningState ladderTraceState { get; private set; }
        public PlcLaddeInitialState ladderTraceInitialState { get; private set; }
        private string plcLadderProjectPath { get; set; }
        private byte[] _srcFileByteDumpArray;
        private int _idxFileReadPosition;
        private Int32 plcProgramFileHeadLength;
        private Int32 plcProgramLineNum;
        private int remainParamCount;
        private PLCDeviceComment plcComment;
        private string ladderProgramOutputFilePath = String.Empty;
        private string ladderProgramFilePath = String.Empty;

        private string m_sBitDirector = String.Empty;                 // 비트지정자
        private string m_sIndexDirector = String.Empty;          // 간접지정자
        private string m_sIndirectDirector = String.Empty;            // 특수레지스터지정자
        private string m_sPointDirector = String.Empty;             // 포인터지정자
        private string m_sSpecialDeviceDirector = String.Empty; // 특수 디바이스 지정자
        private string m_sLinkDeviceDirector = String.Empty;         // 링크 다이렉트 디바이스
        private string m_sSerialDeviceDirector = String.Empty;       // 연번 액세스 파일 레지스터

        private readonly int __PlcLangParameterArraySize = 10;
        private readonly int __GXDevelopAliasLength = 8;
        private readonly int __GXDevelopDeveiceTypeLength = 2;
        private readonly int __GXDevelopCommentLength = 32;
        private readonly int __GXDevelopCommentHeadLength = 72;

        public UDMGXDevelopLadderTracer()
        {
            ladderTraceInitialState = PlcLaddeInitialState.Init;
            dicPlcCommentS = new Dictionary<String, PLCDeviceComment>();
            plcLadderNodsS = new PLCLadderNodeS();
            dicPlcCommandS = new PlcCommandS();
            plcComment = new PLCDeviceComment();

            remainParamCount = 0;
            plcProgramLineNum = 0;
        }

        public void Dispose()
        {
            this.dicPlcCommandS.Clear();
            this.dicPlcCommentS.Clear();
            this.plcLadderNodsS.Clear();
        }

        #endregion

        #region ladderTranslator interface realize

        public string LadderPorgramOutputFilePath
        {
            get { return ladderProgramOutputFilePath; }
            set { ladderProgramOutputFilePath = value; }
        }

        public void SetLadderProgramOutputFilePath(string outputFilePath)
        {
            String sTargetPath = outputFilePath + "\\UDMImport.Output";

            if (!Directory.Exists(sTargetPath))
                Directory.CreateDirectory(sTargetPath);

            ladderProgramFilePath = outputFilePath;
            LadderPorgramOutputFilePath = sTargetPath;
        }

        public void TranslatorReportSave()
        {
            switch (GetTranslatorState())
            {
                case PlcLadderTracerRunningState.EndRead:
                    break;
                default:
                    break;
            }
        }

        public PlcLadderTracerRunningState GetTranslatorState()
        {
            return ladderTraceState;
        }

        #endregion

        #region ladder translator functions

        public String GetFileDataWithIndex(int idx)
        {
            if (_srcFileByteDumpArray == null || _srcFileByteDumpArray.Length == 0) return String.Empty;

            if (idx > _srcFileByteDumpArray.Length) return String.Empty;
            else
            {
                string fmt = String.Format("{0:X2}", _srcFileByteDumpArray[idx]);
                if (fmt.Length < 2) fmt = UDMImportCommon.Pad(fmt, 2);

                return fmt;
            }
        }

        public String GetFileDataWithIndex(int idx, int count)
        {
            if (_srcFileByteDumpArray == null || _srcFileByteDumpArray.Length == 0)
            {
                return String.Empty;
            }

            if (_srcFileByteDumpArray.Length == 0) return String.Empty;

            if (idx + count > _srcFileByteDumpArray.Length)
            {
#if __DEBUG
                String strMessage = String.Format("File Size {0} , Start {1}, ReadCnt {2}", plcProgramFileByteDump.Length, idx, count);
                Console.WriteLine(strMessage);
#endif
                return String.Empty;
            }
            else
            {
                return Encoding.Default.GetString(_srcFileByteDumpArray, idx, count);
            }
        }

        public String GetFileDataHexDumpWithIndex(int idx, int count)
        {
            string message = "";
            if (_srcFileByteDumpArray == null || _srcFileByteDumpArray.Length == 0)
            {
                return String.Empty;
            }

            if (_srcFileByteDumpArray.Length == 0) return String.Empty;

            if (idx + count > _srcFileByteDumpArray.Length)
            {
#if __DEBUG
                String strMessage = String.Format("File Size {0} , Start {1}, ReadCnt {2}", plcProgramFileByteDump.Length, idx, count);
                Console.WriteLine(strMessage);
#endif
                return String.Empty;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    String fmt = String.Format("{0:X2}", _srcFileByteDumpArray[idx + i]);
                    if (fmt.Length < 2) fmt = UDMImportCommon.Pad(fmt, 2);
                    message += fmt + " ";
                }
            }
            return message;
        }

        private String GetDeviceRadix(String addressPacket, out int radix)
        {
            PlcCommand plcSymbol;

            if (dicPlcCommandS.TryGetValue(addressPacket.Substring(0, 2), out plcSymbol))
            {
                radix = plcSymbol.Radix;   // Device stepCnt is Radix
                return plcSymbol.Command;
            }
            else
            {
                radix = 0;
                System.Console.WriteLine(" U.A.P : [" + addressPacket + "]");
                return addressPacket;
            }
        }

        private String ReGenHexDecimalAddress(String deviceAddress)
        {
            if (deviceAddress.Length < 1)
            {
                return "0";
            }
            else
            {
                if (deviceAddress[0] >= 'A' && deviceAddress[0] <= 'F')
                {
                    deviceAddress = "0" + deviceAddress;
                }
                else
                {
                    if (deviceAddress.Length >1 && deviceAddress[0] == '0' && (deviceAddress[1] >= '0' && deviceAddress[1] <= '9'))
                    {
                        deviceAddress = deviceAddress.Substring(1);
                    }
                }
            }
            return deviceAddress.ToUpper();
        }

        #endregion

        #region ladder translator body

        public void LoadHeadLength(int headerLength)
        {
            if (headerLength > 0)
            {
                plcProgramFileHeadLength = headerLength;
                ladderTraceInitialState |= PlcLaddeInitialState.HeaderLengthRead;
            }
        }

        public void LoadPlcSymbolFromXml(String plcPatternFilePath)
        {
            FileStream fs = new FileStream(plcPatternFilePath, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(PLCSymbolS));

            PLCSymbolS plcSymbolS = (PLCSymbolS)xmlSer.Deserialize(fs);
            fs.Close();

            foreach (PLCLadderSymbol symbol in plcSymbolS)
            {
                PlcCommand n = new PlcCommand();

                n.HexPrint = symbol.printedHex;
                n.ParameterTypes = symbol.paramTypeString;
                n.SymbolType = symbol.paramTypeString.Length > 0 && symbol.paramTypeString[0] == 'D' ? LanguageSymbolType.DEVICEADDRESS : LanguageSymbolType.RESERVESYMBOL;
                n.Radix = n.SymbolType == LanguageSymbolType.DEVICEADDRESS ? symbol.stepCnt : 0;
                n.Step = n.SymbolType == LanguageSymbolType.DEVICEADDRESS ? 0 : symbol.stepCnt == 0 ? symbol.paramTypeString.Length:symbol.stepCnt;
                n.DrawType = (StepDrawType)symbol.ndor;
                n.Command = UDMImportCommon.FromEntity(symbol.command);
                n.Description = UDMImportCommon.FromEntity(symbol.description);
                n.Producer = PlcProducer.MELSEC;
                n.Version = "1.0";

                dicPlcCommandS.ReplaceCommand(n);
            }

            /*
            FileStream nfs = new FileStream(@"PlcCommandDic.xml", FileMode.Open);
            XmlSerializer bf = new XmlSerializer(typeof(PlcCommandList), "PlcCommandList");
            PlcCommandList test = bf.Deserialize(nfs) as PlcCommandList;
            nfs.Close();
            test.SavePlcCommandList(@"PlcCommandDic.xml");
            */

            
            ladderTraceInitialState |= PlcLaddeInitialState.SymbolFileRead;
        }

        private string GeneratorCommentDictionary(string programPath)
        {   // UDMImportCommon
            int addressRadix;
            int commentBlockCount;
            List<PLCDeviceCommentBlock> listPlcCommentBlock = new List<PLCDeviceCommentBlock>();

            int idx = programPath.IndexOf("Resource");
            String strCommentFilePath = programPath.Substring(0, idx) + "Resource\\Others\\COMMENT.wcd";

            if (dicPlcCommentS.Count > 0) dicPlcCommentS.Clear();

            if (_srcFileByteDumpArray != null) _srcFileByteDumpArray.Initialize();
            _srcFileByteDumpArray = File.ReadAllBytes(strCommentFilePath);
            _idxFileReadPosition = 0;

            // Skip Comment HeadPosition 
            _idxFileReadPosition += __GXDevelopCommentHeadLength;

            commentBlockCount = (Int32)UDMImportCommon.Hex2Int(GetFileDataHexDumpWithIndex(_idxFileReadPosition, 2).Replace(" ", ""), true);

            // Make Comment Block Info List
            for (int i = 0; i < commentBlockCount; i++)
            {
                PLCDeviceCommentBlock plcCommentBlock = new PLCDeviceCommentBlock();

                _idxFileReadPosition += 2;  // Skip Comment Block Count Info

                String deviceAddressHexMapping = GetFileDataWithIndex(_idxFileReadPosition);
                String deviceAddress = GetDeviceRadix(deviceAddressHexMapping, out addressRadix);
                if (addressRadix == 0)
                {
                    Console.WriteLine(String.Format("Comment Generator ..[{0}]. UnKnown Address Error!!!!", deviceAddressHexMapping));
                    return deviceAddressHexMapping + ".Comment Address";
                }
                else
                {
                    plcCommentBlock.DeviceName = deviceAddress;
                    deviceAddressHexMapping = GetFileDataWithIndex(_idxFileReadPosition + 1);
                    switch (deviceAddressHexMapping)
                    {
                        case "F8":
                            deviceAddress = "U" + ReGenHexDecimalAddress(GetFileDataWithIndex(_idxFileReadPosition + 4)) + "\\" + deviceAddress;
                            plcCommentBlock.DeviceName = deviceAddress;
                            plcCommentBlock.Radix = addressRadix;
                            _idxFileReadPosition += __GXDevelopDeveiceTypeLength;  // Skip Device Type
                            plcCommentBlock.StartAddress = (Int32)UDMImportCommon.Hex2Int(GetFileDataHexDumpWithIndex(_idxFileReadPosition, 2).Replace(" ", ""), true);
                            break;
                        case "F9":
                            deviceAddress = "J" + ReGenHexDecimalAddress(GetFileDataWithIndex(_idxFileReadPosition + 4)) + "\\" + deviceAddress;
                            plcCommentBlock.DeviceName = deviceAddress;
                            plcCommentBlock.Radix = addressRadix;
                            _idxFileReadPosition += __GXDevelopDeveiceTypeLength;  // Skip Device Type
                            plcCommentBlock.StartAddress = (Int32)UDMImportCommon.Hex2Int(GetFileDataHexDumpWithIndex(_idxFileReadPosition, 2).Replace(" ", ""), true);
                            break;
                        default:
                            plcCommentBlock.Radix = addressRadix;
                            _idxFileReadPosition += __GXDevelopDeveiceTypeLength;  // Skip Device Type
                            plcCommentBlock.StartAddress = (Int32)UDMImportCommon.Hex2Int(GetFileDataHexDumpWithIndex(_idxFileReadPosition, 4).Replace(" ", ""), true);
                            break;
                    }

                    _idxFileReadPosition += 2;  // Skip Strat Address
                    _idxFileReadPosition += 2;  // Skip Strat Address
                    plcCommentBlock.NumOfComment = (Int32)UDMImportCommon.Hex2Int(GetFileDataHexDumpWithIndex(_idxFileReadPosition, 2).Replace(" ", ""), true);
                    _idxFileReadPosition += 2;  // Skip Num of Comment
                    try
                    {
                        listPlcCommentBlock.Add(plcCommentBlock);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Comment Block Generator Error : {0}", ex.Message);
                    }
                }
            }

            _idxFileReadPosition += 2;  // Skip Num of Comment
            // Make Comment , Alias Dictionary
            foreach (PLCDeviceCommentBlock commentBlock in listPlcCommentBlock)
            {
                Int64 startAddress = commentBlock.StartAddress;

                for (int i = 0; i < commentBlock.NumOfComment; i++)
                {
                    String commentAddress;
                    PLCDeviceComment plcComment = new PLCDeviceComment();

                    switch (commentBlock.Radix)
                    {
                        case 10:
                            commentAddress = String.Format("{0}{1:G}", commentBlock.DeviceName, startAddress);
                            break;
                        case 16:
                            commentAddress = String.Format("{0:X}", startAddress);
                            commentAddress = ReGenHexDecimalAddress(commentAddress);
                            commentAddress = String.Format("{0}{1}", commentBlock.DeviceName, commentAddress);
                            break;
                        default:
                            commentAddress = "";
                            return "undefined device m_sAddress";
                    }

                    plcComment.Address = commentAddress;
                    plcComment.Alias = GetFileDataWithIndex(_idxFileReadPosition, __GXDevelopAliasLength);
                    _idxFileReadPosition += __GXDevelopAliasLength;
                    plcComment.Comment = GetFileDataWithIndex(_idxFileReadPosition, __GXDevelopCommentLength);
                    _idxFileReadPosition += __GXDevelopCommentLength;
                    startAddress++;

                    try
                    {
                        dicPlcCommentS.Add(plcComment.Address, plcComment);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Comment Generator Error : {0}", ex.Message);
                        return "Comment Dictionary Key Duplicate Key Error! ";
                    }
                }
            }

            return String.Empty;
        }

        private string OpenDataFile(string strPath)
        {
            if (strPath == String.Empty) return "Path Error!";
            if (_srcFileByteDumpArray != null) _srcFileByteDumpArray.Initialize();
            _srcFileByteDumpArray = File.ReadAllBytes(strPath);
            _idxFileReadPosition = 0;
            plcProgramLineNum = 0;
            ladderTraceState = PlcLadderTracerRunningState.Wait;
            ladderTraceInitialState |= PlcLaddeInitialState.SourceFilePathRead;

            return String.Empty;
        }

        public string LadderImportInitialize(string symbolFilePath, string sourceFilePath)
        {
            SetLadderProgramOutputFilePath( UDMImportCommon.GetFilePath(sourceFilePath) );
            string srcFileFolder = UDMImportCommon.GetFilePath(sourceFilePath) + "\\Resource\\Pou\\";   // GXDevelop Project.
            return LadderTracerInitialize(symbolFilePath, srcFileFolder, 68);  // Head Length 68 is Melsec GXDevelop Project.
        }

        public override string LadderTracerInitialize(string symbolFilePath, string sourceFilePath, Int32 headBlockLength)
        {
            string strResult = String.Empty;

            LoadHeadLength(headBlockLength);
            // strResult = LoadPlcSymbolFromXml(symbolFilePath);
            LoadPlcSymbolFromXml(symbolFilePath);
            if (strResult == String.Empty)
            {
                String outPutFileName = UDMImportCommon.GetFileName(sourceFilePath);

                strResult = GeneratorCommentDictionary( sourceFilePath );
                if (strResult == String.Empty) ExportCommentCSVFormat(this.LadderPorgramOutputFilePath + "\\COMMENT.csv");
            }

            return strResult;
        }

        public string DoTranslate()
        {
            string strRet = "Success";

            String srcFileFolder = ladderProgramFilePath + "\\Resource\\Pou\\";
            DirectoryInfo plcPath = new DirectoryInfo(srcFileFolder);
            string searchFor = "Body";
            DirectoryInfo[] exact = plcPath.GetDirectories(searchFor, SearchOption.AllDirectories);

            ArrayList fileResult = new ArrayList();

            foreach (DirectoryInfo dir in exact)
            {
                foreach (FileInfo f in dir.GetFiles())
                {
                    if (f.Extension.ToUpper() == ".WPG")
                    {
                        FileFindResult ff = new FileFindResult();
                        ff.fileName = f.Name;
                        ff.filePath = f.FullName;
                        fileResult.Add(ff);
                    }
                }
            }

            foreach (FileFindResult f in fileResult)
            {
                strRet = LadderTracer(f.filePath);

                if (strRet != String.Empty) return f.filePath;
            }

            return strRet == String.Empty ? "Success" : strRet + "  Unknown Error!!!";
        }

        public override string LadderTracer(string sourceFilePath)
        {
            string returnPacket = "";
            int plcCommandLength;

            returnPacket = OpenDataFile(sourceFilePath);
            if (!returnPacket.Equals("")) return returnPacket;

            if (IsTranslatorRunnable_GxDevelop(out returnPacket) == false)
            {
                return returnPacket;
            }

            plcLadderProjectPath = sourceFilePath;
            plcLadderNodsS.Clear();

            _idxFileReadPosition += plcProgramFileHeadLength;

            while (_idxFileReadPosition < _srcFileByteDumpArray.Length)
            {
                plcCommandLength = (int)UDMImportCommon.Hex2Int(GetFileDataWithIndex(_idxFileReadPosition));
                if (plcCommandLength < 2)
                {
                    String strDump = GetFileDataHexDumpWithIndex(_idxFileReadPosition, 20);
                    Console.WriteLine("Command Length is Less Than 3[" + strDump + "]");
                    return "Command Length Error !! [" + strDump + "]";
                }

                if (plcCommandLength == 2) // NOP 처리
                {
                    nextProgramLine = new PlcLadderNode();
                    nextProgramLine.Parameters = new String[__PlcLangParameterArraySize];
                    nextProgramLine.PlcCommand = "NOP";
                    nextProgramLine.PlcCommandHexDump = "0X00";
                    nextProgramLine.Note += GetFileDataHexDumpWithIndex(_idxFileReadPosition, plcCommandLength);
                    nextProgramLine.LineNo = plcProgramLineNum;
                    plcProgramLineNum += 1;
                    plcLadderNodsS.Add(nextProgramLine);

                    _idxFileReadPosition += plcCommandLength;
                }
                else
                {
                    try
                    {
                        returnPacket = PlcTranslatorFromLadderProjectFile( plcCommandLength );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                        _idxFileReadPosition = _srcFileByteDumpArray.Length;
                    }
                }
            }

            return returnPacket;
        }

        #endregion

        #region translator body

        private void GetTargetPacket(int packetLength, out PlcTranslationBlock ds)
        {
            PlcTranslationBlock src = new PlcTranslationBlock();
            src.HexPrint = GetFileDataHexDumpWithIndex(_idxFileReadPosition+1, packetLength-2).Replace(" ", "");
            src.ReadIndex = _idxFileReadPosition;
            src.ParseType = (ladderTraceState == PlcLadderTracerRunningState.Wait) ? LanguageParseType.COMMAND : LanguageParseType.PARAMETER;
            src.DefinePacketDataType( src.ParseType );

            ds = src;
        }

        private bool PlcCommandPacketProcessor(PlcTranslationBlock srcBlock)
        {
            PlcCommand srcCommand = new PlcCommand();

            if (!dicPlcCommandS.TryGetValue(srcBlock.HexPrint, out srcCommand))
            {
                return false;
            }

            nextProgramLine = new PlcLadderNode();

            nextProgramLine.Parameters = new String[__PlcLangParameterArraySize];
            nextProgramLine.PlcCommand = srcCommand.Command;
            nextProgramLine.PlcCommandHexDump = srcBlock.HexPrint;
            nextProgramLine.Note += GetFileDataHexDumpWithIndex( srcBlock.ReadIndex, srcBlock.HexPrint.Length/2 + 2 );

            nextProgramLine.LineNo = plcProgramLineNum;
            plcProgramLineNum += srcCommand.Step;
            nextProgramLine.No = plcLadderNodsS.Count;
            nextProgramLine.Note += String.Format("({0})", srcCommand.Step);

            if(srcCommand.ParameterTypes.Length == 0)
            {
                plcLadderNodsS.Add(nextProgramLine);

                ladderTraceState = srcCommand.Command == "END" ? PlcLadderTracerRunningState.EndRead : PlcLadderTracerRunningState.Wait;

                return true;
            }

            remainParamCount = srcCommand.ParameterTypes.Length;
            ladderTraceState = PlcLadderTracerRunningState.ParameterWait;

            return true;
        }

        private bool PlcParameterPacketProcessor(PlcTranslationBlock srcBlock)
        {
            string strParameter = String.Empty;
            String strAddress = String.Empty;

            nextProgramLine.Note += GetFileDataHexDumpWithIndex(srcBlock.ReadIndex, srcBlock.HexPrint.Length / 2 + 2);

            switch (srcBlock.PacketType)
            {
                case PacketDataType.BIT_INDICATOR: // ## XXXX ##
                    m_sBitDirector = AddressTypeParameterIndicatorProcessor("K", srcBlock, 16, false);
                    break;
                case PacketDataType.LINK_DEVICE_INDICATOR: // F9 J
                    m_sLinkDeviceDirector = AddressTypeParameterIndicatorProcessor("J", srcBlock, 16, false);
                    plcProgramLineNum++;
                    break;
                case PacketDataType.INDEX_INDICATOR:
                    m_sIndexDirector = AddressTypeParameterIndicatorProcessor("Z", srcBlock, 10, false);
                    break;
                case PacketDataType.SPECIAL_DEVICE_INDICATOR:
                    m_sSpecialDeviceDirector = AddressTypeParameterIndicatorProcessor("U", srcBlock, 16, false);
                    break;
                case PacketDataType.INDIRECT_INDICATOR:
                    m_sIndirectDirector = AddressTypeParameterIndicatorProcessor("@", srcBlock, 16, false);
                    break;
                case PacketDataType.POINT_INDICATOR:
                    m_sPointDirector = AddressTypeParameterIndicatorProcessor(".", srcBlock, 16, false);
                    break;
                case PacketDataType.STRING_INDICATOR:
                    strParameter += m_sSpecialDeviceDirector != String.Empty ? m_sSpecialDeviceDirector + "\\" : "";
                    strParameter += m_sIndirectDirector;
                    strParameter += m_sBitDirector;
                    strParameter += m_sLinkDeviceDirector;
                    strParameter += m_sSerialDeviceDirector;
                    strParameter += "\"" + GetFileDataWithIndex(srcBlock.ReadIndex + 2, srcBlock.HexPrint.Length / 2 - 1) + "\"";
                    strParameter += m_sPointDirector;
                    strParameter += m_sIndexDirector;
                    InitializeAddressParameterDirector();
                    nextProgramLine.Parameters[dicPlcCommandS[nextProgramLine.PlcCommandHexDump].ParameterTypes.Length - remainParamCount] = strParameter;

                    // 파라미터가 문자열인 경우는 짝수시는 문자수/2, 홀수시는 (문자수 + 1)/2 만큼 스탭수가 증가한다.
                    plcProgramLineNum += (srcBlock.HexPrint.Length - 2) / 2 % 2 == 0 ? (srcBlock.HexPrint.Length - 2) / 2 / 2 : ((srcBlock.HexPrint.Length - 2) / 2 + 1) / 2;
                    remainParamCount--;

                    break;
                case PacketDataType.NUMERIC_INDICATOR:
                    if (m_sSpecialDeviceDirector != String.Empty)
                    {
                        if (m_sIndexDirector != String.Empty)
                        {
                            strParameter += m_sSpecialDeviceDirector + m_sIndexDirector + "\\";
                            m_sIndexDirector = String.Empty;
                        }
                        else
                        {
                            strParameter += m_sSpecialDeviceDirector + "\\";
                        }
                    }
                    strParameter += m_sIndirectDirector;
                    strParameter += m_sBitDirector;
                    strParameter += m_sLinkDeviceDirector;
                    strParameter += m_sSerialDeviceDirector;
                    strParameter += AddressTypeParameterIndicatorProcessor("K", srcBlock, 10, false);
                    strParameter += m_sPointDirector;
                    strParameter += m_sIndexDirector;
                    InitializeAddressParameterDirector();
                    nextProgramLine.Parameters[dicPlcCommandS[nextProgramLine.PlcCommandHexDump].ParameterTypes.Length - remainParamCount] = strParameter;
                    remainParamCount--;
                    break;
                case PacketDataType.ADDRESS_INDICATOR:
                    if (m_sSpecialDeviceDirector != String.Empty)
                    {
                        if (m_sIndexDirector != String.Empty)
                        {
                            strParameter += m_sSpecialDeviceDirector + m_sIndexDirector + "\\";
                            m_sIndexDirector = String.Empty;
                        }
                        else
                        {
                            strParameter += m_sSpecialDeviceDirector + "\\";
                        }
                    }
                    strParameter += m_sIndirectDirector;
                    strParameter += m_sBitDirector;
                    strParameter += m_sLinkDeviceDirector;
                    strParameter += m_sSerialDeviceDirector;
                    if (PacketAddressTypeParameterProcessor(srcBlock, out strAddress))
                    {
                        strParameter += strAddress;
                    }
                    else
                    {
                        return false;
                    }
                    
                    strParameter += m_sPointDirector;
                    strParameter += m_sIndexDirector;
                    InitializeAddressParameterDirector();
                    nextProgramLine.Parameters[dicPlcCommandS[nextProgramLine.PlcCommandHexDump].ParameterTypes.Length - remainParamCount] = strParameter;

                    if (dicPlcCommentS.TryGetValue(strParameter, out plcComment) == true)
                    {
                        if (nextProgramLine.Parameters[__PlcLangParameterArraySize - 1] != null)
                        {
                            nextProgramLine.Parameters[__PlcLangParameterArraySize - 1] += "\r\n" + plcComment.Address + " = " + plcComment.Comment;
                        }
                        else
                        {
                            nextProgramLine.Parameters[__PlcLangParameterArraySize - 1] += plcComment.Address + " = " + plcComment.Comment;
                        }
                    }

                    remainParamCount--;
                    break;
                default:
                    break;
            }

            if (remainParamCount == 0)
            {
                plcLadderNodsS.Add(nextProgramLine);
                ladderTraceState = PlcLadderTracerRunningState.Wait;
            }

            return true;
        }
        private bool PlcCommentPacketProcessor(int packetLength)
        {
            nextProgramLine = new PlcLadderNode();
            nextProgramLine.Parameters = new String[__PlcLangParameterArraySize]; //
            nextProgramLine.PlcCommand = "Comment";
            nextProgramLine.LineNo = plcProgramLineNum;
            plcProgramLineNum += (Int16)UDMImportCommon.Hex2Int(GetFileDataWithIndex(_idxFileReadPosition + 2));

            nextProgramLine.Parameters[0] = GetFileDataWithIndex(_idxFileReadPosition + 3, packetLength - 4);
            nextProgramLine.Note += GetFileDataHexDumpWithIndex(_idxFileReadPosition, packetLength);
            nextProgramLine.No = plcLadderNodsS.Count + 1;
            plcLadderNodsS.Add(nextProgramLine);
            _idxFileReadPosition += packetLength;
            ladderTraceState = PlcLadderTracerRunningState.Wait;
            return true;
        }

        private void InitializeAddressParameterDirector()
        {
            m_sBitDirector = String.Empty;
            m_sIndexDirector = String.Empty;
            m_sIndirectDirector = String.Empty;
            m_sPointDirector = String.Empty;
            m_sSpecialDeviceDirector = String.Empty;
            m_sLinkDeviceDirector = String.Empty;
            m_sSerialDeviceDirector = String.Empty;
        }

        String AddressTypeParameterIndicatorProcessor(String director, PlcTranslationBlock srcBlock, int iRadix, bool bAddress)
        {
            string strRet = String.Empty;
            Int64 i64Data = UDMImportCommon.Hex2Int(srcBlock.HexPrint.Substring(2), true);

            if (srcBlock.HexPrint.Substring(0, 2) == "E9")
            {
                Int32 i32Data = (Int32)UDMImportCommon.Hex2Int(srcBlock.HexPrint.Substring(2), true);
                strRet = String.Format("{0}{1}", director, i32Data);
            }
            else if ( srcBlock.HexPrint.Substring(0, 2) == "E8" ) //  K 음수 표현식
            {
                Int16 i16Data  = (Int16)UDMImportCommon.Hex2Int(srcBlock.HexPrint.Substring(2), true);
                strRet = String.Format("{0}{1}", director, i16Data);
            }
            else
            {
                if (iRadix == 10)
                    strRet = String.Format("{0}{1}", director, i64Data);
                else
                {
                    if (bAddress)
                    {
                        strRet = String.Format("{0:X}", i64Data);

                        if (strRet[0] <= '9' && strRet[0] >= '0')
                        {
                            strRet = String.Format("{0}{1:X}", director, i64Data);
                        }
                        else
                        {
                            strRet = String.Format("{0}0{1:X}", director, i64Data);
                        }
                    }
                    else
                    {
                        strRet = String.Format("{0}{1:X}", director, i64Data);
                    }
                }
            }

            return strRet;
        }

        bool PacketAddressTypeParameterProcessor(PlcTranslationBlock srcBlock, out String strRet)
        {
            string sRet = String.Empty;
            string sSource = String.Empty;

            PlcCommand srcCommand = new PlcCommand();
            if (srcBlock.HexPrint.Substring(0, 2) == "EC") // 소숫점 주소??? E
            {
                sSource = srcBlock.HexPrint.Substring(2);

                byte[] raw = new byte[sSource .Length / 2];

                for (int i = 0; i < sSource.Length; i+=2)
                {
                    raw[i / 2] = Convert.ToByte(sSource.Substring(i, 2), 16);
                }

                float fData = BitConverter.ToSingle(raw, 0);

                sRet = UDMImportCommon.CutOffPoint( String.Format("E{0:F5}", fData) );
            }
            else if (dicPlcCommandS.TryGetValue(srcBlock.HexPrint.Substring(0, 2), out srcCommand))
            {
                sRet = AddressTypeParameterIndicatorProcessor(srcCommand.Command,
                    srcBlock,
                    srcCommand.Radix, true);
            }
            else
            {
                strRet =  srcBlock.HexPrint.Substring(0, 2) + ".Device Not Found!!!";
                return false;
            }

            switch (srcBlock.HexPrint.Substring(0, 2))
            {
                case "B0":
                    break;
            }

            strRet = sRet;
            return true;
        }

        public string PlcTranslatorFromLadderProjectFile( int packetLength )
        {
            string strRet = String.Empty;

            PlcTranslationBlock srcTranslationBlock = new PlcTranslationBlock();
            GetTargetPacket(packetLength, out srcTranslationBlock);

            string packetHead = GetFileDataWithIndex(_idxFileReadPosition + 1);
            if ((srcTranslationBlock.ParseType == LanguageParseType.COMMAND) && (packetHead == "80" || packetHead == "82"))
            {
                PlcCommentPacketProcessor(packetLength);
                return String.Empty;
            }

            switch (srcTranslationBlock.ParseType)
            {
                case LanguageParseType.COMMAND:
                    if ( !PlcCommandPacketProcessor( srcTranslationBlock ) )
                    {
                        Console.WriteLine("UnKnown Command Error!...FileName : {0} / Line m_iNo:{1}", new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(), new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber());
                        strRet = GetFileDataHexDumpWithIndex( _idxFileReadPosition, packetLength ).Replace(" ","");
                        _idxFileReadPosition = _srcFileByteDumpArray.Length;
                        SaveResultFile();
                        return strRet;
                    }
                    else
                    {
                        if (ladderTraceState == PlcLadderTracerRunningState.EndRead)
                        {
                            SaveResultFile();
                        }
                    }
                    break;
                case LanguageParseType.PARAMETER:
                    if ( PlcParameterPacketProcessor( srcTranslationBlock ) != true)
                    {
                        Console.WriteLine("UnKnown Command Error!...FileName : {0} / Line m_iNo:{1}", new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(), new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber());
                        strRet = GetFileDataHexDumpWithIndex(_idxFileReadPosition, packetLength).Replace(" ","").Substring(2,2);
                        _idxFileReadPosition = _srcFileByteDumpArray.Length;
                        SaveResultFile();
                        return strRet + "...UnKnown Address";
                    }
                    break;
                default:
                    Console.WriteLine("UnKnown State Error!... FileName : {0} / Line m_iNo:{1}", new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName(), new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileLineNumber());
                    _idxFileReadPosition = _srcFileByteDumpArray.Length;
                    SaveResultFile();
                    return "ERROR";
            }

            _idxFileReadPosition += packetLength;

            return strRet;
        }

        private bool IsTranslatorRunnable_GxDevelop(out string message)
        {
            if ((ladderTraceInitialState 
                & (PlcLaddeInitialState.SourceFilePathRead 
                | PlcLaddeInitialState.SymbolFileRead 
                | PlcLaddeInitialState.HeaderLengthRead)) != 0)
            {
                message = "Success";
                return true;
            }
            else
            {
                PlcLaddeInitialState tempState = ladderTraceInitialState &= PlcLaddeInitialState.SymbolFileRead;

                if ((tempState & PlcLaddeInitialState.SymbolFileRead) != 0)
                {
                    tempState = ladderTraceInitialState &= PlcLaddeInitialState.HeaderLengthRead;
                    if ((tempState & PlcLaddeInitialState.HeaderLengthRead) != 0)
                    {
                        tempState = ladderTraceInitialState &= PlcLaddeInitialState.SourceFilePathRead;
                        if ((tempState & PlcLaddeInitialState.SourceFilePathRead) != 0)
                        {
                            message = "Success";
                            return true;
                        }
                        else
                        {
                            message = "Warnning Plc Program Load Error.";
                        }
                    }
                    else
                    {
                        message = "Warnning Plc Header Length Define Error";
                    }
                }
                else
                {
                    message = "Warnning Plc Symbol File Load Error";
                }
                return false;
            }
        }

        #endregion translator body end

        #region translator output
        private void SaveResultFile()
        {
            String outPutFileName = LadderPorgramOutputFilePath + "\\" + UDMImportCommon.GetFileName(plcLadderProjectPath);

            if (outPutFileName.Length > 0)
            {
                ExportPlcProgramCSVFormat(outPutFileName + "_ladder.csv");
            }
        }
        private void ExportCommentCSVFormat(string targetFileName)
        {
            using (CsvFileWriter writer = new CsvFileWriter(targetFileName))
            {
                List<KeyValuePair<String, PLCDeviceComment>> plcCommentList = dicPlcCommentS.ToList();

                CsvRow rowStart = new CsvRow();
                rowStart.Add("Device"); rowStart.Add("Label"); rowStart.Add("Comment");
                writer.WriteRow(rowStart);

                foreach (KeyValuePair<String, PLCDeviceComment> src in plcCommentList)
                {
                    CsvRow row = new CsvRow();
                    row.Add( src.Value.Address );
                    row.Add( src.Value.Alias.TrimEnd() );
                    row.Add( src.Value.Comment.TrimEnd() );
                    writer.WriteRow(row);
                }
            }
        }
        private void ExportPlcProgramCSVFormat(string sourceFileName)
        {
            Int64 realExcelFileLineCount = 0;
            using (CsvFileWriter writer = new CsvFileWriter(sourceFileName))
            {
                foreach (PlcLadderNode src in plcLadderNodsS)
                {
                    CsvRow row = new CsvRow();

                    src.No = (int)++realExcelFileLineCount;

                    row.Add(String.Format("{0}", src.LineNo)); 
                    if (src.PlcCommand == "Comment")
                    {
                        if (src.Parameters[0].Trim().Length > 0)
                        {
                            row.Add(src.Parameters[0]); row.Add(""); row.Add("");
                        }
                        else
                        {
                            row.Add("*"); row.Add(""); row.Add("");
                        }
                        row.Add(""); row.Add(""); row.Add(""); row.Add(""); row.Add("");                        
                    }
                    else if (src.PlcCommand == "LABEL")
                    {
                        row.Add("");
                        if (src.Parameters[0] != "" && src.Parameters[0] != null)
                        {
                            row.Add(src.Parameters[0]);
                        }
                        else
                        {
                            row.Add("");
                        }
                        row.Add(""); row.Add(""); row.Add(""); row.Add(""); row.Add(""); row.Add("");
                    }
                    else
                    {
                        row.Add("");
                        row.Add(src.PlcCommand);
                        if (src.Parameters[0] != "" && src.Parameters[0] != null)
                        {
                            row.Add(src.Parameters[0]);
                        }
                        else
                        {
                            row.Add("");
                        }
                        row.Add(""); row.Add(""); row.Add(""); row.Add(""); row.Add("");
                    }

                    
                    writer.WriteRow(row);

                    for (int i = 1; i < __PlcLangParameterArraySize - 1; i++)
                    {
                        if (src.Parameters[i] != "" && src.Parameters[i] != null)
                        {
                            CsvRow row2 = new CsvRow();
                            row2.Add(""); row2.Add(""); row2.Add("");
                            row2.Add( src.Parameters[i] );
                            row2.Add(""); row2.Add(""); row2.Add(""); row2.Add(""); row2.Add("");
                            writer.WriteRow(row2);
                            ++realExcelFileLineCount;
                        }
                    }
                }
                CsvRow rowEnd = new CsvRow();
                rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add(""); rowEnd.Add("");
                writer.WriteRow(rowEnd);
            }
        }
        #endregion translator output end
    }

    public class FileFindResult
    {
        public FileFindResult() { }
        public long fileSize;
        public string fileName;
        public string fileExt;
        public string filePath;
    }
}
