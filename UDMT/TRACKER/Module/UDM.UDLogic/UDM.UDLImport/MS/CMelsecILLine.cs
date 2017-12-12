using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;

namespace UDM.UDLImport
{
    [Serializable]
    public class CMelsecILLine : ICloneable
    {
        private string m_sStep = string.Empty;
        private string m_sNote = string.Empty;
        private string m_sCommand = string.Empty;
        private string m_sCommandFull = string.Empty;

        private string m_sSource = string.Empty;
        private string m_sSource_Sub1 = string.Empty;
        private string m_sSource_Sub2 = string.Empty;
        private string m_sSource_Sub3 = string.Empty;
        private string m_sSource_Sub4 = string.Empty;

        private string m_sDestination = string.Empty;
        private string m_sDestination_Sub1 = string.Empty;
        private string m_sDestination_Sub2 = string.Empty;

        private string m_sNumeric = string.Empty;
        private string m_sNumeric_Sub1 = string.Empty;
        private string m_sNumeric_Sub2 = string.Empty;
        private string m_sNumeric_Sub3 = string.Empty;

        private string m_sSpecialParameter = string.Empty;
        private string m_sProgram = string.Empty;

        private EMCoilImport m_eILImportType = EMCoilImport.S0_D1_N0;

        #region Initialize/Dispose

        public CMelsecILLine(string strProgram, string strStep, string strNote, string strCommand, string strOperand, string[] arrOperandSub)
        {
            m_sProgram = strProgram.Replace(".txt", string.Empty).Replace(".csv",string.Empty);
            m_sStep = strStep;

            if (strNote == string.Empty)
            {
                GenerationCommand(strCommand);
                GenerationOperand(strOperand, arrOperandSub);
                m_sCommandFull = GetCommandFull(strCommand, strOperand, arrOperandSub);
            }
            else
                m_sNote = strNote;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {

        }

        #endregion

        #region Properties

        public string Step
        {
            get { return m_sStep; }
            set { m_sStep = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public EMCoilImport ImportType
        {
            get { return m_eILImportType; }
            set { m_eILImportType = value; }
        }

        public int StepNumber
        {
            get
            { return Convert.ToInt32(m_sStep); }
        }

        public string Command { get { return m_sCommand; } }
        public string CommandFull { get { return m_sCommandFull; } }

        public string Destination { get { return m_sDestination; } set { m_sDestination = value; } }
        public string Destination_Sub1 { get { return m_sDestination_Sub1; } set { m_sDestination_Sub1 = value; } }
        public string Destination_Sub2 { get { return m_sDestination_Sub2; } set { m_sDestination_Sub2 = value; } }

        public string Source { get { return m_sSource; } set { m_sSource = value; } }
        public string Source_Sub1 { get { return m_sSource_Sub1; } set { m_sSource_Sub1 = value; } }
        public string Source_Sub2 { get { return m_sSource_Sub2; } set { m_sSource_Sub2 = value; } }
        public string Source_Sub3 { get { return m_sSource_Sub3; } set { m_sSource_Sub3 = value; } }
        public string Source_Sub4 { get { return m_sSource_Sub4; } set { m_sSource_Sub4 = value; } }

        public string Numeric { get { return m_sNumeric; } }
        public string Numeric_Sub1 { get { return m_sNumeric_Sub1; } }
        public string Numeric_Sub2 { get { return m_sNumeric_Sub2; } }
        public string Numeric_Sub3 { get { return m_sNumeric_Sub3; } }

        public string SpecialParameter { get { return m_sSpecialParameter; } }

        public List<string> ItemArray
        {
            get
            {
                List<string> ListItem = new List<string>{
                     m_sStep
                    ,m_sNote
                    ,m_sCommand
                    ,m_sSource +"; " +m_sSource_Sub1 +"; " +m_sSource_Sub2
                    ,m_sDestination  +"; " +m_sDestination_Sub1 +"; " +m_sDestination_Sub2
                    ,m_sNumeric +"; " +m_sNumeric_Sub1 +"; " +m_sNumeric_Sub2 +"; " +m_sNumeric_Sub3
                    ,m_sSpecialParameter
                    ,m_eILImportType.ToString()
                                                        };
                return ListItem;
            }
        }

        public List<string> ListAddress
        {
            get
            {
                List<string> ListAddress = null;
                if (m_eILImportType != EMCoilImport.NONE)
                {
                    ListAddress = new List<string>{
                     m_sSource
                    ,m_sSource_Sub1
                    ,m_sSource_Sub2
                    ,m_sSource_Sub3
                    ,m_sDestination
                    ,m_sDestination_Sub1
                    ,m_sDestination_Sub2
                    ,m_sNumeric
                    ,m_sNumeric_Sub1
                    ,m_sNumeric_Sub2
                    ,m_sNumeric_Sub3
                    };
                }
                else
                    ListAddress = new List<string> { m_sSpecialParameter };

                return ListAddress;
            }
        }

        public string ItemAll
        {
            get
            {
                return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}"

                    , m_sProgram
                    , m_sStep
                    , m_sNote
                    , m_sCommand
                    , m_sSource + "; " + m_sSource_Sub1 + "; " + m_sSource_Sub2
                    , m_sDestination + "; " + m_sDestination_Sub1 + "; " + m_sDestination_Sub2
                    , m_sNumeric + "; " + m_sNumeric_Sub1 + "; " + m_sNumeric_Sub2 + "; " + m_sNumeric_Sub3
                    , m_sSpecialParameter
                    , m_eILImportType.ToString());

            }
        }

        public bool IsNote
        {
            get
            {
                if (Command == string.Empty && m_sNote != string.Empty)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        #region public Methods

        //예외 사항이 많이 존재한다(D*(P)의 경우는 Destination이 4Word -> 이런 것들은 SubDataType에서 분류!
        public bool CheckDoubleWord(List<string> lstCommandAll) // 원래 있는 명령어에 D가 붙었는지를 확인!
        {
            bool bDoubleWord = false;
            {
                if (m_sCommand.Contains("D"))
                {
                    string[] arrCommand = m_sCommand.Split('D');

                    if (arrCommand.Length == 2)  //DMOV
                    {
                        if (lstCommandAll.Contains(arrCommand[0] + arrCommand[1]))
                            return true;
                    }
                    else if (arrCommand.Length == 3)  //DBCD
                    {
                        if (lstCommandAll.Contains(arrCommand[0] + "D" + arrCommand[1] + arrCommand[2]))
                            return true;
                        if (lstCommandAll.Contains(arrCommand[0] + arrCommand[1] + "D" + arrCommand[2]))
                            return true;
                    }
                    else if (arrCommand.Length == 4)    // DDACBD
                    {
                        if (lstCommandAll.Contains(arrCommand[0] + "D" + arrCommand[1] + "D" + arrCommand[2] + arrCommand[3]))
                            return true;
                        if (lstCommandAll.Contains(arrCommand[0] + "D" + arrCommand[1] + arrCommand[2] + "D" + arrCommand[3]))
                            return true;
                        if (lstCommandAll.Contains(arrCommand[0] + arrCommand[1] + "D" + arrCommand[2] + "D" + arrCommand[3]))
                            return true;
                    }
                }
            }

            return bDoubleWord;
        }

        public List<string> GetUsedAddress()
        {
            List<string> ListUsedAddress = new List<string>();

            if (CMelsecPlc.IsMelsecAddress(Source))
                ListUsedAddress.Add(Source);
            if (CMelsecPlc.IsMelsecAddress(Source_Sub1))
                ListUsedAddress.Add(Source_Sub1);
            if (CMelsecPlc.IsMelsecAddress(Source_Sub2))
                ListUsedAddress.Add(Source_Sub2);
            if (CMelsecPlc.IsMelsecAddress(Source_Sub3))
                ListUsedAddress.Add(Source_Sub3);
            if (CMelsecPlc.IsMelsecAddress(Source_Sub4))
                ListUsedAddress.Add(Source_Sub4);
            if (CMelsecPlc.IsMelsecAddress(Destination))
                ListUsedAddress.Add(Destination);
            if (CMelsecPlc.IsMelsecAddress(Destination_Sub1))
                ListUsedAddress.Add(Destination_Sub1);
            if (CMelsecPlc.IsMelsecAddress(Destination_Sub2))
                ListUsedAddress.Add(Destination_Sub2);
            if (CMelsecPlc.IsMelsecAddress(Numeric))
                ListUsedAddress.Add(Numeric);
            if (CMelsecPlc.IsMelsecAddress(Numeric_Sub1))
                ListUsedAddress.Add(Numeric_Sub1);
            if (CMelsecPlc.IsMelsecAddress(Numeric_Sub2))
                ListUsedAddress.Add(Numeric_Sub2);
            if (CMelsecPlc.IsMelsecAddress(Numeric_Sub3))
                ListUsedAddress.Add(Numeric_Sub3);

            return ListUsedAddress;
        }

        #endregion

        #region Private Methods

        private void GenerationCommand(string strCommand)
        {
            m_sCommand = strCommand;
            m_eILImportType = CMelsecILImportType.GetmType(strCommand); //Coil Type을 반환
        }

        private string GetCommandFull(string strCommand, string strOperand, string[] arrOperandSub)
        {
            string sCommandFull = strCommand;

            if (strOperand != string.Empty)
                sCommandFull += "\t" + strOperand;

            foreach (string sItem in arrOperandSub)
            {
                if (sItem != null && sItem != string.Empty)
                {
                    sCommandFull += "\t" + sItem;
                }

            }

            return sCommandFull;
        }

        private void GenerationOperand(string strOperand, string[] arrOperandSub)
        {
            switch (m_eILImportType)
            {
                case EMCoilImport.S0_D0_N0: SetS0_D0_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D0_N1: SetS0_D0_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D1_N0: SetS0_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D1_N1: SetS0_D1_N1(strOperand, arrOperandSub); break;
                //case EMCoilImport.S0_D1_N2: SetS0_D1_N2(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D2_N0: SetS0_D2_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D2_N1: SetS0_D2_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_N1_D1: SetS0_N1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_N2_D1: SetS0_N2_D1(strOperand, arrOperandSub); break;
                //case EMCoilImport.S0_N4_D1: SetS0_N4_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D0_N0: SetS1_D0_N0(strOperand, arrOperandSub); break;
                //case EMCoilImport.S1_D0_N1: SetS1_D0_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N0: SetS1_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N1: SetS1_D1_N1(strOperand, arrOperandSub); break;
                //case EMCoilImport.S1_D1_N1_D1: SetS1_D1_N1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_S1: SetS1_D1_S1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D2_N0: SetS1_D2_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D2_N1: SetS1_D2_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_N1_D1: SetS1_N1_D1(strOperand, arrOperandSub); break;
                //case EMCoilImport.S1_N1_D2: SetS1_N1_D2(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_N1_S1_D2: SetS1_N1_S1_D2(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_N2_D1: SetS1_N2_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D0_N0: SetS2_D0_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D1_N0: SetS2_D1_N0(strOperand, arrOperandSub); break;
                //case EMCoilImport.S2_D2_N0: SetS2_D2_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D1_N1: SetS2_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S3_D1_N0: SetS3_D1_N0(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_D1_N1: SetN1_D1_N1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S1: SetN1_S1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S1_D1: SetN1_S1_D1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S1_D2: SetN1_S1_D2(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S2_D1: SetN1_S2_D1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S2_D2: SetN1_S2_D2(strOperand, arrOperandSub); break;
                //case EMCoilImport.N1_S3_D1: SetN1_S3_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.N2_D1_N1: SetN2_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.N2_D1_N1_D1: SetN2_D1_N1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.N2_S1_N1: SetN2_S1_N1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N3_S1_D1: SetN3_S1_D1(strOperand, arrOperandSub); break;
                //case EMCoilImport.N4_S1_D1: SetN4_S1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.Arithmetic: SetArithmetic(strOperand, arrOperandSub); break;
                //case EMCoilImport.File: SetFile(strOperand, arrOperandSub); break;
                //case EMCoilImport.Network: SetNetwork(strOperand, arrOperandSub); break;
                case EMCoilImport.Program: SetProgram(strOperand, arrOperandSub); break;
                case EMCoilImport.ProgramLabel: SetCall(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_N2_S1_D1: SetS1_N2_S1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D2_N0: SetS2_D2_N0(strOperand, arrOperandSub); break;

                case EMCoilImport.NONE: SetSpecial(strOperand, arrOperandSub);
                    Console.WriteLine("Not Support [{0}] Command EMCoilImport Type!", strOperand); break;
                default: break;
            }
        }

        #region 대응 O

        private bool SetS1_N2_S1_D1(string strOperand, string[] arrOperandSub) // ex) "MCR" : 마스터 컨드롤 해제
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sNumeric_Sub1 = arrOperandSub[1];
            m_sSource_Sub1 = arrOperandSub[2];
            m_sDestination = arrOperandSub[3];
            return true;
        }


        private bool SetSpecial(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;

            foreach(string sTemp in arrOperandSub)
            {
                if (sTemp == null)
                    break;

                string sTemp1 = string.Format(",{0}", sTemp);
                m_sSpecialParameter += sTemp1;
            }
            return true;
        }

        private bool SetS0_D0_N0(string strOperand, string[] arrOperandSub)
        {
            // Nothing to do..
            return true;
        }

        private bool SetS0_D0_N1(string strOperand, string[] arrOperandSub) // ex) "MCR" : 마스터 컨드롤 해제
        {
            m_sNumeric = strOperand;

            return true;
        }

        private bool SetS0_D1_N0(string strOperand, string[] arrOperandSub)   // ex) "SET" : 디바이스 세트
        {
            if ((m_sCommand == "OUT" || m_sCommand == "OUTH") && arrOperandSub[0] != null)  //  예외) OUT TIMER K24
            {
                m_eILImportType = EMCoilImport.S0_D1_N1;
                return SetS0_D1_N1(strOperand, arrOperandSub);
            }
            else
                m_sDestination = strOperand;

            return true;
        }
        
        private bool SetS0_D1_N1(string strOperand, string[] arrOperandSub)  // ex) "RFS" : IO 리플레쉬
        {
            m_sDestination = strOperand;
            m_sNumeric = arrOperandSub[0];

            return true;
        }

        private bool SetS0_D2_N0(string strOperand, string[] arrOperandSub)
        {
            m_sDestination = strOperand;
            m_sDestination_Sub1 = arrOperandSub[0];

            return true;
        }

        private bool SetS0_D2_N1(string strOperand, string[] arrOperandSub)
        {
            m_sDestination = strOperand;
            m_sDestination_Sub1 = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            return true;
        }

        private bool SetS1_D0_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;

            return true;
        }

        private bool SetS1_D0_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];

            return true;
        }

        private bool SetS1_D1_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            return true;
        }

        private bool SetS1_D1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            return true;
        }

        private bool SetS0_N1_D1(string strOperand, string[] arrOperandSub)   // ex) "MC" : 마스터 컨트롤 세트
        {
            m_sNumeric = strOperand;
            m_sDestination = arrOperandSub[0];

            return true;
        }

        private bool SetS2_D0_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];

            return true;
        }

        private bool SetS2_D1_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];

            return true;
        }

        private bool SetS2_D1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sNumeric = arrOperandSub[2];

            return true;
        }

        private bool SetS3_D1_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sSource_Sub2 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];

            return true;
        }

        private bool SetN2_D1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sNumeric_Sub2 = arrOperandSub[2];

            return true;
        }

        private bool SetN2_S1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sSource = arrOperandSub[1];
            m_sNumeric_Sub2 = arrOperandSub[2];

            return true;
        }

        private bool SetS1_N1_S1_D2(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];
            m_sDestination_Sub1 = arrOperandSub[3];

            return true;
        }

        private bool SetArithmetic(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            if (arrOperandSub[3] != null) //S2_D2_N1
            {
                m_sSource_Sub1 = arrOperandSub[0];
                m_sNumeric = arrOperandSub[1];
                m_sDestination_Sub1 = arrOperandSub[2];
                m_sDestination_Sub2 = arrOperandSub[3];
            }
            else if (arrOperandSub[1] != null) //S2_D1_N0
            {
                m_sSource_Sub1 = arrOperandSub[0];
                m_sDestination = arrOperandSub[1];
            }
            else if (arrOperandSub[0] != null)  //S1_D1_N0
            {
                m_sDestination = arrOperandSub[0];
            }

            return true;
        }
     
        private bool SetProgram(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand; //Label

            if (arrOperandSub[1] != null) //FCALL Parameter 2개짜리
                m_sSource = arrOperandSub[0];

            return true;
        }

        private bool SetCall(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = m_sCommand;
            m_sCommand = "LABEL";

            return true;
        }

        private bool SetS1_N2_D1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sNumeric_Sub1 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];

            return true;
        }

        private bool SetN2_D1_N1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sNumeric_Sub2 = arrOperandSub[2];
            m_sDestination_Sub1 = arrOperandSub[3];
            return true;
        }

        private bool SetS1_N1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];

            return true;
        }

        private bool SetS0_N2_D1(string strOperand, string[] arrOperandSub)   // ex) "PLSY": 펄스 출력
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];

            return true;
        }

        private bool SetS1_D2_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sDestination_Sub1 = arrOperandSub[1];
            m_sNumeric = arrOperandSub[2];

            return true;
        }

        private bool SetS1_D2_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sDestination_Sub1 = arrOperandSub[1];

            return true;
        }

        private bool SetS1_D1_S1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];

            return true;
        }

        #endregion


        #region 대응 X

        private bool SetN1_D1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric_Sub1 = arrOperandSub[1];

            return true;
        }

        private bool SetN1_S1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];

            return true;
        }

        private bool SetN1_S1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];

            return true;
        }

        private bool SetN1_S1_D2(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sDestination_Sub1 = arrOperandSub[2];

            return true;
        }

        private bool SetN1_S2_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];

            return true;
        }

        private bool SetN1_S2_D2(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];
            m_sDestination_Sub1 = arrOperandSub[3];

            return true;
        }

        private bool SetN1_S3_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sSource = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
            m_sSource_Sub2 = arrOperandSub[2];
            m_sDestination = arrOperandSub[3];

            return true;
        }
        

        private bool SetN3_S1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            m_sSource = arrOperandSub[2];
            m_sDestination_Sub1 = arrOperandSub[3];

            return true;
        }

        private bool SetN4_S1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            m_sNumeric_Sub3 = arrOperandSub[2];
            m_sSource = arrOperandSub[3];
            m_sDestination_Sub1 = arrOperandSub[4];

            return true;
        }

        private bool SetS2_D2_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sDestination_Sub1 = arrOperandSub[2];

            return true;
        }

        private bool SetS1_D1_N1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            m_sDestination_Sub1 = arrOperandSub[2];

            return true;
        }

        private bool SetS1_N1_D2(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            m_sDestination_Sub1 = arrOperandSub[2];

            return true;
        }
  
         
        private bool SetS0_N4_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            m_sNumeric_Sub3 = arrOperandSub[2];
            m_sDestination = arrOperandSub[3];

            return true;
        }

        private bool SetS0_D1_N2(string strOperand, string[] arrOperandSub)
        {
            m_sDestination = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sNumeric_Sub1 = arrOperandSub[1];

            return true;
        }

        private bool SetFile(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;

            return true;
        }

        private bool SetNetwork(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;
            List<string> ListTypeA = new List<string> { "J.ZCOM", "JP.ZCOM", "G.ZCOM", "GP.ZCOM" };
            List<string> ListTypeB = new List<string> { "J.ZNRD", "JP.ZNRD", "J.ZBWR", "JP.ZBWR", "J.ZNWR", "JP.ZNWR" };
            List<string> ListTypeC = new List<string> { "G.RTOP", "GP.RTOP", "G.RFRP", "GP.RFRP" };
            List<string> ListTypeD = new List<string> { "J.SEND", "JP.SEND", "J.RECV", "JP.RECV", "JP.ZNFR", "G.SEND", "GP.SEND", "G.RECV", "GP.RECV", "GP.ZNFR", "J.ZNTO", "JP.ZNTO", "G.ZNTO", "GP.ZNTO", "ZP.ZNTO" };
            List<string> ListTypeE = new List<string> { "J.READ", "JP.READ", "J.WRITE", "JP.WRITE", "J.REQ", "JP.REQ", "GP.READ", "G.READ", "G.WRITE", "GP.WRITE", "G.REQ", "GP.REQ" };
            List<string> ListTypeF = new List<string> { "J.SREAD", "JP.SREAD", "J.SWRITE", "JP.SWRITE", "G.SREAD", "GP.SREAD", "G.SWRITE", "GP.SWRITE" };
            List<string> ListTypeG = new List<string> { "G.RIRD", "GP.RIRD", "G.RIWT", "GP.RIWT" };
            List<string> ListTypeH = new List<string> { "G.RIRCV", "GP.RIRCV" };
            List<string> ListTypeI = new List<string> { "G.RISEND", "GP.RISEND" };
            List<string> ListTypeJ = new List<string> { "G.RIFR", "GP.RIFR", "G.RITO", "GP.RITO" };
            List<string> ListTypeK = new List<string> { "G.RLPASET", "GP.RLPASET" };



            if (ListTypeA.Contains(m_sCommand))                               // Nothing to do..
            {

            }
            else if (ListTypeB.Contains(m_sCommand))                          // N1 D1 S1 N2 D2
            {
                m_sNumeric = arrOperandSub[0];
                m_sDestination = arrOperandSub[1];
                m_sSource = arrOperandSub[2];
                m_sNumeric_Sub1 = arrOperandSub[3];
                m_sDestination_Sub1 = arrOperandSub[4];
            }
            else if (ListTypeC.Contains(m_sCommand))                          // N1 D1 N2 D2
            {
                m_sNumeric = arrOperandSub[0];
                m_sDestination = arrOperandSub[1];
                m_sNumeric_Sub1 = arrOperandSub[2];
                m_sDestination_Sub1 = arrOperandSub[3];
            }
            else if (ListTypeD.Contains(m_sCommand))                          // S1 S2 D1
            {
                m_sSource = arrOperandSub[0];
                m_sSource_Sub1 = arrOperandSub[1];
                m_sDestination = arrOperandSub[2];
            }
            else if (ListTypeE.Contains(m_sCommand))                          // S1 S2 D1 D2
            {
                m_sSource = arrOperandSub[0];
                m_sSource_Sub1 = arrOperandSub[1];
                m_sDestination = arrOperandSub[2];
                m_sDestination_Sub1 = arrOperandSub[3];

            }
            else if (ListTypeF.Contains(m_sCommand))                          // S1 S2 D1 D2 D3
            {
                m_sSource = arrOperandSub[0];
                m_sSource_Sub1 = arrOperandSub[1];
                m_sDestination = arrOperandSub[2];
                m_sDestination_Sub1 = arrOperandSub[3];
                m_sDestination_Sub2 = arrOperandSub[4];
            }

            else if (ListTypeG.Contains(m_sCommand))                          // S1 D1 D2
            {
                m_sSource = arrOperandSub[0];
                m_sDestination = arrOperandSub[1];
                m_sDestination_Sub1 = arrOperandSub[2];
            }

            else if (ListTypeH.Contains(m_sCommand))                          // S1 S2 S3 D1
            {
                m_sSource = arrOperandSub[0];
                m_sSource_Sub1 = arrOperandSub[1];
                m_sSource_Sub2 = arrOperandSub[2];
                m_sDestination = arrOperandSub[3];
            }

            else if (ListTypeI.Contains(m_sCommand))                          // S1 D1 S2 D2
            {
                m_sSource = arrOperandSub[0];
                m_sDestination = arrOperandSub[1];
                m_sSource_Sub1 = arrOperandSub[2];
                m_sDestination_Sub1 = arrOperandSub[3];
            }

            else if (ListTypeJ.Contains(m_sCommand))                          // N1 N2 D1 N3
            {
                m_sNumeric = arrOperandSub[0];
                m_sNumeric_Sub1 = arrOperandSub[1];
                m_sDestination = arrOperandSub[2];
                m_sNumeric_Sub2 = arrOperandSub[3];
            }

            else if (ListTypeK.Contains(m_sCommand))                          // S1 S2 S3 S4 S5 D1
            {
                m_sSource = arrOperandSub[0];
                m_sSource_Sub1 = arrOperandSub[1];
                m_sSource_Sub2 = arrOperandSub[2];
                m_sSource_Sub3 = arrOperandSub[3];
                m_sSource_Sub4 = arrOperandSub[4];
                m_sDestination = arrOperandSub[5];
            }

            else
                return false;

            return true;
        }
        

        #endregion


        #endregion
    }

}
