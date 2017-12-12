using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.UDL;

namespace UDM.UDLImport
{
    public class CLSILLine
    {
        private string m_sStep = string.Empty;
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
        private string m_sNumeric_Sub4 = string.Empty;

        private string m_sSpecialParameter = string.Empty;
        private string m_sProgram = string.Empty;

        private EMCoilImport m_eILImportType = EMCoilImport.S0_D1_N0;


        #region Initialize/Dispose

        public CLSILLine(string sProgram, string sStep, string sCommand, string sOperand, string[] arrOperandSub)
        {
            m_sProgram = sProgram.Replace(".csv", string.Empty).Replace(".il", string.Empty);
            m_sStep = sStep;

            GenerationCommand(sCommand);
            GenerationOperand(sOperand, arrOperandSub);
            //m_sCommandFull = GetCommandFull(sCommand, sOperand, arrOperandSub);

        }

        /// <summary>
        /// XGI Series
        /// </summary>
        /// <param name="sProgram"></param>
        /// <param name="iStep"></param>
        /// <param name="sCommand"></param>
        /// <param name="sOperand"></param>
        public CLSILLine(string sProgram, int iStep, string sCommand, string sOperand)
        {
            m_sProgram = sProgram.Replace(".csv", string.Empty).Replace(".il", string.Empty);
            m_sStep = iStep.ToString();

            GenerationXGICommand(sCommand);

            if (sOperand.Contains("^"))
            {
                List<string> lstOperand = GetXGIOperand(sCommand, sOperand);

                if (lstOperand.Count == 0)
                    return;

                string sFirstOperand = lstOperand[0];
                lstOperand.RemoveAt(0);
                string[] arrOperand = lstOperand.ToArray();

                GenerationOperand(sFirstOperand, arrOperand);
            }
            else
                GenerationOperand(sOperand, null);
        }

        public CLSILLine(string sProgram, string sStep, string sFBName, string sOperand)
        {
            m_eILImportType = EMCoilImport.FunctionBlock;

            m_sProgram = sProgram.Replace(".csv", string.Empty).Replace(".il", string.Empty);
            m_sStep = sStep;
            m_sCommand = sFBName;

            m_sSpecialParameter = GenerationParameter(sOperand);
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

        public string Command { get { return m_sCommand; } set { m_sCommand = value; } }
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
        public string NUmeric_Sub4 { get { return m_sNumeric_Sub4; } }

        public string SpecialParameter { get { return m_sSpecialParameter; } }

        public List<string> ItemArray
        {
            get
            {
                List<string> ListItem = new List<string>{
                     m_sStep
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
                    ,m_sNumeric_Sub4
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
                return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}"

                    , m_sProgram
                    , m_sStep
                    , m_sCommand
                    , m_sSource + "; " + m_sSource_Sub1 + "; " + m_sSource_Sub2
                    , m_sDestination + "; " + m_sDestination_Sub1 + "; " + m_sDestination_Sub2
                    , m_sNumeric + "; " + m_sNumeric_Sub1 + "; " + m_sNumeric_Sub2 + "; " + m_sNumeric_Sub3
                    , m_sSpecialParameter
                    , m_eILImportType.ToString());

            }
        }

        #endregion

        #region Public Methods

        public List<string> GetUsedAddress()
        {
            List<string> ListUsedAddress = new List<string>();

            if (CLSPlc.IsLSAddress(Source))
                ListUsedAddress.Add(Source);
            if (CLSPlc.IsLSAddress(Source_Sub1))
                ListUsedAddress.Add(Source_Sub1);
            if (CLSPlc.IsLSAddress(Source_Sub2))
                ListUsedAddress.Add(Source_Sub2);
            if (CLSPlc.IsLSAddress(Source_Sub3))
                ListUsedAddress.Add(Source_Sub3);
            if (CLSPlc.IsLSAddress(Source_Sub4))
                ListUsedAddress.Add(Source_Sub4);
            if (CLSPlc.IsLSAddress(Destination))
                ListUsedAddress.Add(Destination);
            if (CLSPlc.IsLSAddress(Destination_Sub1))
                ListUsedAddress.Add(Destination_Sub1);
            if (CLSPlc.IsLSAddress(Destination_Sub2))
                ListUsedAddress.Add(Destination_Sub2);
            if (CLSPlc.IsLSAddress(Numeric))
                ListUsedAddress.Add(Numeric);
            if (CLSPlc.IsLSAddress(Numeric_Sub1))
                ListUsedAddress.Add(Numeric_Sub1);
            if (CLSPlc.IsLSAddress(Numeric_Sub2))
                ListUsedAddress.Add(Numeric_Sub2);
            if (CLSPlc.IsLSAddress(Numeric_Sub3))
                ListUsedAddress.Add(Numeric_Sub3);

            return ListUsedAddress;
        }

        #endregion

        #region Private Methods

        //새로운 FB 들어오면 여기부터 Change!!!!!!!
        private List<string> GetXGIOperand(string sCommand, string sOperand)
        {
            List<string> lstOperand = new List<string>();

            List<string> lstTemp = sOperand.Split(',').ToList();

            if (sCommand.Contains("_"))
            {
                for (int i = 1; i < lstTemp.Count; i++)
                    lstOperand.Add(lstTemp[i]);
            }
            else
            {
                lstOperand.Add(lstTemp[2]);
                lstOperand.Add(lstTemp[1]);
            }

            //for (int i = 0; i < lstOperand.Count; i++)
            //{
            //    if (lstOperand[i].Contains("LINEIN") || lstOperand[i].Contains("LINEOUT") ||
            //        lstOperand[i].Contains("EMPTY"))
            //        lstOperand[i] = string.Empty;
            //}

            return lstOperand;
        }

        private void GenerationCommand(string sCommand)
        {
            try
            {
                m_sCommand = sCommand;
                m_eILImportType = CLSILImportType.GetLSType(sCommand); //Coil Type을 반환
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void GenerationXGICommand(string sCommand)
        {
            try
            {
                m_sCommand = sCommand;

                if (sCommand.Contains("."))
                {
                    if(sCommand.StartsWith("T"))
                        m_eILImportType = EMCoilImport.S0_D1_N1;
                    else if (sCommand.StartsWith("C"))
                        m_eILImportType = EMCoilImport.S1_N1_D1;
                }
                else
                    m_eILImportType = CLSILImportType.GetLSType(sCommand); //Coil Type을 반환
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetCommandFull(string sCommand, string sOperand, string[] arrOperandSub)
        {
            string sCommandFull = sCommand;

            if (sOperand != string.Empty)
                sCommandFull += "\t" + sOperand;

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
                case EMCoilImport.S0_D1_N0: SetS0_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D1_N1: SetS0_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D2_N0: SetS0_D2_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D2_N1: SetS0_D2_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D0_N1: SetS0_D0_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D0_N2: SetS0_D0_N2(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D0_N3: SetS0_D0_N3(strOperand, arrOperandSub); break;
                case EMCoilImport.S0_D0_N5: SetS0_D0_N5(strOperand, arrOperandSub); break;

                case EMCoilImport.S0_N3_D1: SetS0_N3_D1(strOperand, arrOperandSub); break;
  
                case EMCoilImport.S1_D0_N0: SetS1_D0_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D0_N1: SetS1_D0_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N0: SetS1_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N1: SetS1_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N2: SetS1_D1_N2(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N3: SetS1_D1_N3(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N4: SetS1_D1_N4(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D1_N5: SetS1_D1_N5(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_D2_N0: SetS1_D2_N0(strOperand, arrOperandSub); break;

                case EMCoilImport.S1_N1_D1: SetS1_N1_D1(strOperand, arrOperandSub); break;
                case EMCoilImport.S1_N2_D2: SetS1_N2_D2(strOperand, arrOperandSub); break;

                case EMCoilImport.S2_D0_N0: SetS2_D0_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D1_N0: SetS2_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D1_N1: SetS2_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S2_D0_N1: SetS2_D0_N1(strOperand, arrOperandSub); break;

                case EMCoilImport.S3_D0_N0: SetS3_D0_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S3_D0_N1: SetS3_D0_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S3_D1_N0: SetS3_D1_N0(strOperand, arrOperandSub); break;
                case EMCoilImport.S3_D1_N1: SetS3_D1_N1(strOperand, arrOperandSub); break;
                case EMCoilImport.S4_D1_N0: SetS4_D1_N0(strOperand, arrOperandSub); break;

                case EMCoilImport.S1_D1_S1: SetS1_D1_S1(strOperand, arrOperandSub); break;
 
                case EMCoilImport.N2_D1_N1_D1: SetN2_D1_N1_D1(strOperand, arrOperandSub); break;

                case EMCoilImport.D1_S2_N1: SetD1_S2_N1(strOperand, arrOperandSub); break;

                case EMCoilImport.Program: SetProgram(strOperand, arrOperandSub); break;
                case EMCoilImport.ProgramLabel: SetCall(strOperand, arrOperandSub); break;

                case EMCoilImport.NONE: SetSpecial(strOperand, arrOperandSub);
                    Console.WriteLine("Not Support [{0}] Command EMCoilImport Type!", strOperand); break;
                default: break;
            }
        }

        private string GenerationParameter(string sOperand)
        {
            string sParameter = string.Empty;

            string[] sSplitParameter = sOperand.Split(',');

            for (int i = 0; i < sSplitParameter.Length; i++)
            {
                if (sSplitParameter[i].Contains("^EMPTY")) 
                    sSplitParameter[i] = " ";

                sParameter += sSplitParameter[i].Replace("^", string.Empty);

                if(i != (sSplitParameter.Length - 1))
                sParameter += ",";
            }

            return sParameter;
        }

        private bool SetSpecial(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;

            foreach (string sTemp in arrOperandSub)
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
            //Nothing to do...
            return true;
        }

        private bool SetS0_D1_N0(string strOperand, string[] arrOperandSub)
        {
            m_sDestination = strOperand;
            return true;
        }

        private bool SetS0_D1_N1(string strOperand, string[] arrOperandSub)
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

        private bool SetS0_D0_N1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            return true;
        }

        private bool SetS0_D0_N2(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            return true;
        }

        private bool SetS0_D0_N3(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            return true;
        }

        private bool SetS0_D0_N5(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            m_sNumeric_Sub3 = arrOperandSub[2];
            m_sNumeric_Sub4 = arrOperandSub[3];
            return true;
        }

        private bool SetS0_N3_D1(string strOperand, string[] arrOperandSub)
        {
            m_sNumeric = strOperand;
            m_sNumeric_Sub1 = arrOperandSub[0];
            m_sNumeric_Sub2 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];
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

        private bool SetS1_D1_N2(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            m_sNumeric_Sub1 = arrOperandSub[2];
            return true;
        }

        private bool SetS1_D1_N3(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            m_sNumeric_Sub1 = arrOperandSub[2];
            m_sNumeric_Sub2 = arrOperandSub[3];
            return true;
        }

        private bool SetS1_D1_N4(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            m_sNumeric_Sub1 = arrOperandSub[2];
            m_sNumeric_Sub2 = arrOperandSub[3];
            m_sNumeric_Sub3 = arrOperandSub[4];
            return true;
        }

        private bool SetS1_D1_N5(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
            m_sNumeric_Sub1 = arrOperandSub[2];
            m_sNumeric_Sub2 = arrOperandSub[3];
            m_sNumeric_Sub3 = arrOperandSub[4];
            m_sNumeric_Sub4 = arrOperandSub[5];
            return true;
        }

        private bool SetS1_D2_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sDestination_Sub1 = arrOperandSub[1];
            return true;
        }

        private bool SetS1_N1_D1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sDestination = arrOperandSub[1];
            return true;
        }

        private bool SetS1_N2_D2(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sNumeric = arrOperandSub[0];
            m_sNumeric_Sub1 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];
            m_sDestination_Sub1 = arrOperandSub[3];
            return true;
        }

        private bool SetS2_D0_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            return true;
        }

        private bool SetS2_D0_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sNumeric = arrOperandSub[1];
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

        private bool SetS3_D0_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sSource_Sub2 = arrOperandSub[1];
            return true;
        }

        private bool SetS3_D0_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sSource_Sub2 = arrOperandSub[1];
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

        private bool SetS3_D1_N1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sSource_Sub2 = arrOperandSub[1];
            m_sDestination = arrOperandSub[2];
            m_sNumeric = arrOperandSub[3];
            return true;
        }

        private bool SetS4_D1_N0(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sSource_Sub1 = arrOperandSub[0];
            m_sSource_Sub2 = arrOperandSub[1];
            m_sSource_Sub3 = arrOperandSub[2];
            m_sDestination = arrOperandSub[3];
            return true;
        }

        private bool SetS1_D1_S1(string strOperand, string[] arrOperandSub)
        {
            m_sSource = strOperand;
            m_sDestination = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
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

        private bool SetD1_S2_N1(string strOperand, string[] arrOperandSub)
        {
            m_sDestination = strOperand;
            m_sSource = arrOperandSub[0];
            m_sSource_Sub1 = arrOperandSub[1];
            m_sNumeric = arrOperandSub[2];
            return true;
        }

        private bool SetProgram(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;

            return true;
        }

        private bool SetCall(string strOperand, string[] arrOperandSub)
        {
            m_sSpecialParameter = strOperand;
            m_sCommand = "LABEL";

            return true;
        }

        #endregion

    }
}
