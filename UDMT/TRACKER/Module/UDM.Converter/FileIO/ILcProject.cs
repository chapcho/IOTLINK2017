using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace UDM.Converter
{
//     #region Interface
// 
//     public interface ILcProject : IBaseProject, IFoXmlIO
//     {
//         CILRungS ILRungS { get; set; }
// 
//         CILSymbolS SymbolS { get; set; }
// 
//         DataSet LogicDataSet { get; set; }
// 
//         List<CILRung> FindAllRung(string strAddress);
// 
//         Dictionary<CILContact, CILRung> FindAllLogic(string strAddress);
// 
//         Dictionary<CILContact, bool> FindAllContact(string strAddress);
// 
//         string GetProgramSize(string sProgram);
// 
//         bool ConvertRung(string[] strFileName, BackgroundWorker backgroundWorker);
// 
//         bool CreateColorRowSub();
// 
//         void Clear();
//     }
// 
//     #endregion
// 
// 
//     public class CLcProject : ILcProject
//     {
// 
//         #region Member Variables
// 
//         
//         protected CILRungS m_cILRungS = null;
//         protected CILSymbolS m_cLcSymbolS = null;
//         protected DataSet m_dsLogic = null;
// 
//         #endregion
// 
// 
//         #region Initialize/Dispose
// 
//         public CLcProject()
//         {
//         }
// 
//         public void Dispose()
//         {
//             Clear();
//         }
// 
//         #endregion
// 
// 
//         #region Public Properties
// 
//         public string FilePath
//         {
//             get { return FilePath; }
//             set { FilePath = value; }
//         }
// 
//         public string Name
//         {
//             get { return Name; }
//             set { Name = value; }
//         }
// 
//         public CILRungS ILRungS
//         {
//             get { return m_cILRungS; }
//             set { m_cILRungS = value; }
//         }
// 
//         public CILSymbolS SymbolS
//         {
//             get { return m_cLcSymbolS; }
//             set { m_cLcSymbolS = value; }
//         }
// 
//         public DataSet LogicDataSet
//         {
//             get { return m_dsLogic; }
//             set { m_dsLogic = value; }
//         }
// 
//         #endregion
// 
// 
//         #region Pubilc Methods
// 
//         public void Clear()
//         {
// 
//         }
// 
//         #region Read/Write Properties
// 
//         public bool Read(string sFilePath)
//         {
//             CFoXmlHelper cHelper = new CFoXmlHelper(EMFileMode.Read);
// 
//             bool bOK = cHelper.Open(sFilePath);
//             if (bOK == false)
//             {
//                 cHelper.Dispose();
//                 return false;
//             }
// 
//             try
//             {
//             //    ReadProject(cHelper, "Project");
//             }
// 
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//                 bOK = false;
//             }
// 
//             cHelper.Close();
//             cHelper.Dispose();
// 
//             return bOK;
//         }
// 
//         protected void ReadSymbolList(CFoXmlHelper cHelper, IFoElement cElement, string sElement)
//         {
//             try
//             {
//                 if (cElement.IsEmpty)
//                     return;
// 
//                 IFoElement cElementChild;
//                 while (cHelper.EOF == false)
//                 {
//                     cElementChild = cHelper.Read();
// 
//                     if (cElementChild == null)
//                         continue;
// 
//                     if (cElementChild.NodeType == XmlNodeType.EndElement && cElementChild.Name == sElement)
//                         break;
// 
//                     if (cElementChild.NodeType == XmlNodeType.Element && cElementChild.Name == "Symbol")
//                     {
//                         CILSymbolS cSymbol = ReadSymbol(cElementChild, "Symbol");
//                         if (cSymbol != null)
//                             m_cLcSymbolS.Add(cSymbol.Key, cSymbol);
//                     }
// 
//                     cElementChild.Clear();
//                     cElementChild = null;
//                 }
//             }
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//             }
//         }
// 
//         protected CILSymbolS ReadSymbol(IFoElement cElement, string sElement)
//         {
//             CILSymbolS CILSymbolS = null;
// 
//             try
//             {
//                 if (cElement.NodeType == XmlNodeType.Element && cElement.Name == sElement)
//                 {
//                     string sName = cElement.GetValue("Name").Trim();
//                     string sIFChannel = cElement.GetValue("IFChannel").Trim();
//                     string sIFDevice = cElement.GetValue("IFDevice").Trim();
// 
//                     object oValue;
// 
//                     CILSymbolS = new CILSymbolS(sIFChannel, sIFDevice, sName);
//             
//                     CILSymbolS.Key = cElement.GetValue("Key");
//                     CILSymbolS.Name = sName;
//                     CILSymbolS.Address = cElement.GetValue("Address").Trim();
// 
//                     oValue = cElement.GetValue("AddressType", typeof(EMAddressType));
//                     if (oValue != null)
//                         CILSymbolS.AddressType = (EMAddressType)oValue;
// 
//                     oValue = cElement.GetValue("DataType", typeof(EMDataType));
//                     if (oValue != null)
//                         CILSymbolS.DataType = (EMDataType)oValue;
// 
//                     CILSymbolS.Description = cElement.GetValue("Description").Trim();
// 
//                     oValue = cElement.GetValue("Color", typeof(Color));
//                     if (oValue != null)
//                         CILSymbolS.Color = (Color)oValue;
// 
//                 }
//             }
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//                 CILSymbolS = null;
//             }
// 
//             return CILSymbolS;
//         }
// 
//         public bool Write(string sFilePath)
//         {
//             CFoXmlHelper cHelper = new CFoXmlHelper(EMFileMode.Write);
// 
//             bool bOK = cHelper.Open(sFilePath);
//             if (bOK == false)
//             {
//                 cHelper.Dispose();
//                 return false;
//             }
// 
//             try
//             {
//                 IFoElement cRoot = new CFoElement("Project");
//                 cRoot.Add("Name", Name);
//                 cHelper.WriteStart(cRoot);
// 
//                 //    WriteProject(cHelper);
// 
//                 cHelper.WriteEnd();
//                 cRoot.Clear();
//             }
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//                 bOK = false;
//             }
// 
//             cHelper.Close();
//             cHelper.Dispose();
// 
//             FilePath = sFilePath;
// 
//             return bOK;
//         }
// 
//         public bool Read(CFoXmlHelper cHelper, string sElement)
//         {
//             bool bOK = true;
// 
//             if (cHelper.Readable == false)
//                 return false;
// 
//             try
//             {
//                 //  ReadProject(cHelper, sElement);
//             }
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//                 bOK = false;
//             }
// 
//             return bOK;
//         }
// 
//         public bool Write(CFoXmlHelper cHelper, string sElement)
//         {
//             if (cHelper.Writable == false)
//                 return false;
// 
//             bool bOK = true;
// 
//             try
//             {
//                 //  WriteProject(cHelper, sElement);
//             }
//             catch (System.Exception ex)
//             {
//                 Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
//                 bOK = false;
//             }
// 
//             return bOK;
//         }
// 
//         #endregion
//         
//         public List<CILRung> FindAllRung(string strAddress)
//         {
//             List<CILRung> FindListRung = ILRungS.LIST_RUNG.FindAll(delegate(CILRung cILRung)
//             {
//                 return cILRung.CoilAddress == strAddress
//                         || (cILRung.ILSubData != null && cILRung.ILSubData.SubDataList.Contains(strAddress));
//             });
// 
//             return FindListRung;
//         }
// 
//         public CILRung FindRung(string strAddress)
//         {
//             CILRung FindRung = ILRungS.LIST_RUNG.Find(delegate(CILRung cILRung)
//             {
//                 return cILRung.CoilAddress == strAddress
//                    || (cILRung.ILSubData != null && cILRung.ILSubData.SubDataList.Contains(strAddress));
//             });
// 
//             return FindRung;
//         }
// 
//         public CILRung FindDelayTimerRung(CILRung cILRungTimer)
//         {
//             CILRung FindRung = ILRungS.LIST_RUNG.Find(delegate(CILRung cILRung)
//             {
//                 return cILRung.STEP.IsSameFirstStepProgram(cILRungTimer); 
//             });
// 
//             return FindRung;
//         }
// 
//         public Dictionary<CILContact, CILRung> FindAllLogic(string strAddress)
//         {
//             Dictionary<CILContact, CILRung> DicLogic = new Dictionary<CILContact, CILRung>();
// 
//             foreach (var whoRung in ILRungS)
//             {
//                 CILRung cILRung = (CILRung)whoRung.Value;
//                 foreach (var who in cILRung.DIAGRAM_HEADS)
//                 {
//                     foreach (CILNodeBody cILNode in cILRung.DIAGRAM_HEADS[who.Key])
//                     {
//                         foreach (CILNodeRow cILNodeRow in cILNode.ListILNodeRow)
//                         {
//                             if (cILNodeRow.ILContact.Address == strAddress
//                                 || cILRung.CoilAddress == strAddress)
//                                 DicLogic.Add(cILNodeRow.ILContact, cILRung);
//                         }
//                     }
// 
//                 }
//             }
// 
//             return DicLogic;
//         }
// 
// 
//         public Dictionary<CILContact, bool> FindAllContact(string strAddress)
//         {
//             Dictionary<CILContact, bool> DicLogic = new Dictionary<CILContact, bool>();
// 
//             foreach (var whoRung in ILRungS)
//             {
//                 CILRung cILRung = (CILRung)whoRung.Value;
// 
//                 if (cILRung.CoilAddress == strAddress)
//                 {
//                     foreach (var who in cILRung.DIAGRAM_HEADS)
//                     {
//                         foreach (CILNodeBody cILNode in cILRung.DIAGRAM_HEADS[who.Key])
//                         {
//                             foreach (CILNodeRow cILNodeRow in cILNode.ListILNodeRow)
//                             {
//                                 if (cILNodeRow.eILConnect == EMContactType.Open
//                                     || cILNodeRow.eILConnect == EMContactType.PulseOffClose
//                                     || cILNodeRow.eILConnect == EMContactType.PulseOnOpen)
//                                     DicLogic.Add(cILNodeRow.ILContact, true);
//                                 else
//                                     DicLogic.Add(cILNodeRow.ILContact, false);
// 
//                             }
// 
//                         }
//                     }
//                 }
// 
//             }
// 
//             return DicLogic;
// 
//         }
// 
//         public string GetProgramSize(string sProgram)
//         {
//             CILSymbolS CILSymbolS = new CILSymbolS();
//             int nBit = 0;
//             int nWord = 0;
// 
//             foreach (var whoRung in ILRungS)
//             {
//                 CILRung cILRung = (CILRung)whoRung.Value;
// 
//                 if (cILRung.CoilProgram != sProgram)
//                     continue;
// 
//                 CILSymbolS = CILHelper.GetUsedSymbols(cILRung);
//                 nBit += CILSymbolS.GetTotalSize(EMDataType.Bool);
//                 nWord += CILSymbolS.GetTotalSize(EMDataType.Word);
//             }
// 
//             return string.Format("Word :{1}\t Bit :{0}\t ", nBit, nWord);
//         }
// 
//         private CILConvert LoadPLC(string[] sFileNames, BackgroundWorker backgroundWorker)
//         {
//             CILConvert cILConvert = new CILConvert();
//             CILImport cILImport = new CILImport();
// 
//             m_dsLogic = CExcelHelper.OpenCSVfiles(sFileNames, false, false);
//             cILImport.ImportIL(m_dsLogic);
//             cILConvert.ConvertIL(cILImport.DicILLINE, backgroundWorker);
// 
//             m_cLcSymbolS = CSymbolHelper.ConvertSymbol(sFileNames);
// 
//             return cILConvert;
//         }
// 
//         private CILConvert LoadUPM(DataSet dsPLC, BackgroundWorker backgroundWorker)
//         {
//             CILConvert cILConvert = new CILConvert();
//             CILImport cILImport = new CILImport();
// 
//             cILImport.ImportIL(dsPLC);
//             cILConvert.ConvertIL(cILImport.DicILLINE, backgroundWorker);
// 
//             m_cLcSymbolS = CSymbolHelper.ImportSymbol(dsPLC);
// 
//             return cILConvert;
//         }
// 
//         private void CreateRungS(CILConvert cILConvert, BackgroundWorker backgroundWorker)
//         {
//             m_cILRungS = new CILRungS();
// 
//             List<CILStep> ListILStep = cILConvert.LIST_COIL;
//             Dictionary<string, string> DicsAddressUsed = cILConvert.USED_ADDRESS;
// 
//             SetILSymbol(cILConvert);
// 
//             int nCountItem = 0;
// 
//             foreach (CILStep ILStep in ListILStep)
//             {
//                 backgroundWorker.ReportProgress(nCountItem++ * 100 / ListILStep.Count, "Convert " + ILStep.Program);
//                 CILRung cILRung = new CILRung(ILStep);
//                 if (!DicsAddressUsed.ContainsKey(cILRung.CoilAddress))
//                     cILRung.IsEndCoil = true;
// 
//                 m_cILRungS.Add(cILRung.CoilKey, cILRung);
//             }
// 
//             m_cILRungS.CreateListRung();
// 
//             CreateColorRowSub();
//         }
// 
//         public bool ConvertRung(string[] sFileNames, BackgroundWorker backgroundWorker)
//         {
//             CILStep cILDebug = new CILStep();
// 
//             try
//             {
//                 CILConvert cILConvert = LoadPLC(sFileNames, backgroundWorker);
// 
//                 CreateRungS(cILConvert, backgroundWorker);
// 
//                 return true;
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("ConvertRung :" + cILDebug.Program + cILDebug.CoilAddress); ex.Data.Clear();
//                 return false;
//             }
//         }
// 
// 
//         public bool ConvertRung(DataSet dsLogic, BackgroundWorker backgroundWorker)
//         {
//             CILStep cILDebug = new CILStep();
// 
//             try
//             {
//                 CILConvert cILConvert = LoadUPM(dsLogic, backgroundWorker); ;
// 
//                 CreateRungS(cILConvert, backgroundWorker);
// 
//                 return true;
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("ConvertRung :" + cILDebug.Program + cILDebug.CoilAddress); ex.Data.Clear();
//                 return false;
//             }
//         }
// 
// 
//         public bool CreateColorRowSub()
//         {
//             string strError = string.Empty;
//             try
//             {
//                 if (ILRungS == null || ILRungS.Count == 0)
//                     return false;
// 
//                 Random r = new Random();
//                 Dictionary<string, Color> DicColor = new Dictionary<string, Color>();
// 
//                 foreach (var whoRung in ILRungS)
//                 {
//                     CILRung cILRung = (CILRung)whoRung.Value;
//                     if (cILRung.CoilAddress == string.Empty)
//                         continue;
// 
//                     CreateUsedRung(cILRung.CoilAddress, r, DicColor);
// 
//                     if (cILRung.ILSubData != null)
//                         foreach (string sAddress in cILRung.ILSubData.SubDataList)
//                             CreateUsedRung(sAddress, r, DicColor);
//                 }
// 
//                 foreach (var whoRung in ILRungS)
//                 {
//                     CILRung cILRung = (CILRung)whoRung.Value;
//                     foreach (var who in cILRung.DIAGRAM_HEADS)
//                     {
//                         foreach (CILNodeBody cILNode in cILRung.DIAGRAM_HEADS[who.Key])
//                         {
//                             foreach (CILNodeRow cILNodeRow in cILNode.ListILNodeRow)
//                             {
//                                 if (cILNodeRow.ILContact.Command.Contains("=") || cILNodeRow.ILContact.Command.Contains("<")
//                                       || cILNodeRow.ILContact.Command.Contains(">") || cILNodeRow.ILContact.Command.Contains("$"))
//                                 {
//                                     SetColorSubLink(cILNodeRow, cILNodeRow.ILContact.ILLine.Source, DicColor);
//                                     SetColorSubLink(cILNodeRow, cILNodeRow.ILContact.ILLine.Source_Sub1, DicColor);
//                                     SetColorSubLink(cILNodeRow, cILNodeRow.ILContact.ILLine.Source_Sub2, DicColor);
//                                 }
//                                 else
//                                     SetColorSubLink(cILNodeRow, cILNodeRow.Address, DicColor);
// 
//                             }
//                         }
// 
//                     }
//                 }
// 
//                 return true;
//             }
//             catch (Exception error)
//             {
//                 throw new Exception(error.Message + "\r\n Error CreateRung : " + strError + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
//             }
//         }
//     
//         #endregion
// 
// 
//         #region Private Methods
// 
//         private void SetColorSubLink(CILNodeRow cILNodeRow, string strAddress, Dictionary<string, Color> DicColor)
//         {
//             if (DicColor.ContainsKey(strAddress))
//                 cILNodeRow.ColorSubLink = DicColor[strAddress];
//         }
//         
//         private void CreateUsedRung(string strAddress, Random r, Dictionary<string, Color> DicColor)
//         {
//             if (!DicColor.ContainsKey(strAddress))
//                 DicColor.Add(strAddress, Color.FromArgb(r.Next(50, 250), r.Next(50, 250), r.Next(50, 250)));
//         }
// 
//         public string GetSymbol(string sProgram, string sAddress)
//         {
//             if (sAddress.StartsWith("K"))
//                 sAddress = sAddress.Substring(2, sAddress.Length - 2);
//             if (sAddress.Contains('.'))
//                 sAddress = sAddress.Split('.')[0];
// 
//             string sKey = string.Format("{0}.{1}", sProgram, sAddress);
//             string sCommonKey = string.Format("{0}.{1}", "COMMENT", sAddress);
// 
//             if (m_cLcSymbolS.ContainsKey(sKey))
//                 return string.Format("[{0}]{1}", sProgram, m_cLcSymbolS[sKey].Name);
//             else if (m_cLcSymbolS.ContainsKey(sCommonKey))
//                 return m_cLcSymbolS[sCommonKey].Name;
//             else
//                 return string.Empty;
//         }
// 
//         public string GetAddressNSymbol(string sProgram, string sAddress)
//         {
//             string sAddressNSymbol = string.Empty;
//             string sSymbol = GetSymbol(sProgram, sAddress);
//             if (sSymbol == string.Empty)
//                 sAddressNSymbol = sAddress;
//             else
//                 sAddressNSymbol = string.Format("{0} :{1}", sAddress, sSymbol);
// 
//             return sAddressNSymbol;
//         }
// 
//         private void SetILSymbol(CILConvert cILConvert)
//         {
//             try
//             {
//                 foreach (CILStep cILStep in cILConvert.LIST_COIL)
//                 {
//                     cILStep.CoilSymbol = GetSymbol( cILStep.ILLine.Program, cILStep.CoilAddress);
// 
//                     foreach (CILBlock cILBlock in cILStep.BLOCKS)
//                         foreach (CILContact LP in cILBlock.LOGICS)
//                         {
//                             LP.Symbol = GetSymbol( LP.ILLine.Program, LP.Address);
//                         }
//                 }
//             }
//             catch (Exception error)
//             {
//                 throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
//             }
//         }
// 
// 
//         #endregion
// 
//     }
}
