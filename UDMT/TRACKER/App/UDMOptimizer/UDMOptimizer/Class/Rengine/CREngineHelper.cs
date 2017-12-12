using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDotNet;
using System.Diagnostics;
using System.Data;


namespace UDMOptimizer
{
    public static class CREngineHelper
    {

        #region Member Variables

        private static bool m_bConnect = false;
        private static REngine m_cEngine = null;

        #endregion

        #region Public Properties

        public static bool IsConnected
        {
            get { return m_bConnect; }
        }

        #endregion

        #region Public Methods

        public static bool Connect()
        {
            if (m_bConnect)
                return true;

            REngine.SetEnvironmentVariables();
            m_cEngine = REngine.GetInstance();
            m_cEngine.Initialize();

            m_bConnect = true;

            return true;
        }
        public static void Disconnect()
        {
            if (m_bConnect)
            {
                m_bConnect = false;
                m_cEngine.Dispose();
                m_cEngine = null;
            }
        }

        public static CRLeveneResult DoLeveneTest(double[][] nGroupValues)
        {
            CRLeveneResult cResult = new CRLeveneResult();

            try
            {
                if (m_bConnect == false || nGroupValues == null || nGroupValues.Length < 2)
                    return null;

                NumericVector cVector = null;
                for (int i = 0; i < nGroupValues.Length; i++)
                {
                    cVector = m_cEngine.CreateNumericVector(nGroupValues[i]);
                    m_cEngine.SetSymbol("Group" + (i + 1).ToString(), cVector);
                }

                string sCommand = "";

                sCommand = " y <- c(";
                {
                    for (int i = 0; i < nGroupValues.Length; i++)
                        sCommand += "Group" + (i + 1).ToString() + ", ";

                    sCommand = sCommand.Substring(0, sCommand.Length - 2);
                    sCommand += ")";
                    m_cEngine.Evaluate(sCommand);
                }

                sCommand = " group <- as.factor(c(";
                {
                    for (int i = 0; i < nGroupValues.Length; i++)
                        sCommand += "rep(" + (i + 1).ToString() + ", " + "length(Group" + (i + 1).ToString() + ")), ";

                    sCommand = sCommand.Substring(0, sCommand.Length - 2);
                    sCommand += "))";
                    m_cEngine.Evaluate(sCommand);
                }

                sCommand = "library(lawstat)";
                m_cEngine.Evaluate(sCommand);

                NumericVector vtValue = null;

                sCommand = "levene.test(y, group)";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();

                cResult.Statistic = (float)vtValue[0];
                cResult.PValue = (float)vtValue[1];

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("CREngineHelper", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
            return cResult;
        }
        public static CRAnovaResult DoAnovaTest(double[][] nGroupValues)
        {
            CRAnovaResult cResult = new CRAnovaResult();
            try
            {
                if (m_bConnect == false || nGroupValues == null || nGroupValues.Length < 2)
                    return null;

                NumericVector cVector = null;
                for (int i = 0; i < nGroupValues.Length; i++)
                {
                    cVector = m_cEngine.CreateNumericVector(nGroupValues[i]);
                    m_cEngine.SetSymbol("Group" + i.ToString(), cVector);
                }

                string sCommand = "";
                sCommand = "all.scores = c(Group0";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", Group" + i.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "Group = c('Group0'";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", 'Group" + i.ToString() + "'";

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "N = c(" + nGroupValues[0].Length;
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", " + nGroupValues[i].Length.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "GroupS = rep(Group, N)";
                m_cEngine.Evaluate(sCommand);

                sCommand = "result = aov(all.scores ~ factor(GroupS))";
                m_cEngine.Evaluate(sCommand);

                NumericVector vtValue = null;
                sCommand = "summary(result)[[1]][['Df']]";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();
                cResult.GroupDF = (float)vtValue[0];
                cResult.ErrorDF = (float)vtValue[1];

                sCommand = "summary(result)[[1]][['Sum Sq']]";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();
                cResult.GroupSS = (float)vtValue[0];
                cResult.ErrorSS = (float)vtValue[1];

                sCommand = "summary(result)[[1]][['Mean Sq']]";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();
                cResult.GroupMS = (float)vtValue[0];
                cResult.ErrorMS = (float)vtValue[1];

                sCommand = "summary(result)[[1]][['F value']]";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();
                cResult.FValue = (float)vtValue[0];

                sCommand = "summary(result)[[1]][['Pr(>F)']]";
                vtValue = m_cEngine.Evaluate(sCommand).AsNumeric();
                cResult.PValue = (float)vtValue[0];
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("CREngineHelper", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
            return cResult;
        }
        public static CRScheffeResult DoScheffeTest(double[][] nGroupValues)
        {
            CRScheffeResult cResult = new CRScheffeResult();
            try
            {
                if (m_bConnect == false || nGroupValues == null || nGroupValues.Length < 2)
                    return null;

                NumericVector cVector = null;
                for (int i = 0; i < nGroupValues.Length; i++)
                {
                    cVector = m_cEngine.CreateNumericVector(nGroupValues[i]);
                    m_cEngine.SetSymbol("Group" + i.ToString(), cVector);
                }

                string sCommand = "";

                sCommand = "library(agricolae)";
                m_cEngine.Evaluate(sCommand);

                sCommand = "all.scores = c(Group0";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", Group" + i.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "Group = c('Group0'";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", 'Group" + i.ToString() + "'";

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "N = c(" + nGroupValues[0].Length;
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", " + nGroupValues[i].Length.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "GroupS = rep(Group, N)";
                m_cEngine.Evaluate(sCommand);

                sCommand = "model = aov(lm(all.scores~GroupS))";
                m_cEngine.Evaluate(sCommand);

                sCommand = "result = scheffe.test(model, 'GroupS', group=TRUE, main = NULL)";
                m_cEngine.Evaluate(sCommand);


                sCommand = "result2 = scheffe.test(model, 'GroupS', group=FALSE, main = NULL)";
                m_cEngine.Evaluate(sCommand).AsList();

                GenericVector vtComparisonValue = null;
                CharacterVector vtGroupName = null;
                NumericVector vtDiff = null;
                NumericVector vtPvalue = null;
                NumericVector vtSig = null;
                NumericVector vtLCL = null;
                NumericVector vtUCL = null;

                sCommand = "rownames(result2$comparison)";
                vtComparisonValue = m_cEngine.Evaluate(sCommand).AsList();
                vtGroupName = vtComparisonValue.AsCharacter();

                sCommand = "result2$comparison";
                vtComparisonValue = m_cEngine.Evaluate(sCommand).AsList();

                vtDiff = vtComparisonValue[0].AsNumeric(); // Diff
                vtPvalue = vtComparisonValue[1].AsNumeric(); // Pvalue
                vtSig = vtComparisonValue[2].AsNumeric(); // sig
                vtLCL = vtComparisonValue[3].AsNumeric(); // LCL
                vtUCL = vtComparisonValue[4].AsNumeric(); // UCL

                cResult.GroupName = new string[vtGroupName.Length];
                cResult.GroupDiff = new float[vtGroupName.Length];
                cResult.GroupPValue = new float[vtGroupName.Length];
                cResult.GroupSig = new int[vtGroupName.Length];
                cResult.GroupLCL = new float[vtGroupName.Length];
                cResult.GroupUCL = new float[vtGroupName.Length];

                for (int i = 0; i < vtGroupName.Length; i++)
                {
                    cResult.GroupName[i] = (string)vtGroupName[i];
                    cResult.GroupDiff[i] = (float)vtDiff[i];
                    cResult.GroupPValue[i] = (float)vtPvalue[i];
                    cResult.GroupSig[i] = (int)vtSig[i];
                    cResult.GroupLCL[i] = (float)vtLCL[i];
                    cResult.GroupUCL[i] = (float)vtUCL[i];
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("CREngineHelper", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
            return cResult;
        }
        public static CRDunnettT3Result DoDunnettT3Test(double[][] nGroupValues)
        {
            CRDunnettT3Result cResult = new CRDunnettT3Result();
            try
            {
                if (m_bConnect == false || nGroupValues == null || nGroupValues.Length < 2)
                    return null;

                NumericVector cVector = null;
                for (int i = 0; i < nGroupValues.Length; i++)
                {
                    cVector = m_cEngine.CreateNumericVector(nGroupValues[i]);
                    m_cEngine.SetSymbol("Group" + i.ToString(), cVector);
                }

                string sCommand = "";

                sCommand = "library(DTK)";
                m_cEngine.Evaluate(sCommand);

                sCommand = "all.scores = c(Group0";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", Group" + i.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "Group = c('Group0'";
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", 'Group" + i.ToString() + "'";

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "N = c(" + nGroupValues[0].Length;
                {
                    for (int i = 1; i < nGroupValues.Length; i++)
                        sCommand += ", " + nGroupValues[i].Length.ToString();

                    sCommand += ")";
                }
                m_cEngine.Evaluate(sCommand);

                sCommand = "GroupS = rep(Group, N)";
                m_cEngine.Evaluate(sCommand);

                sCommand = "result = DTK.test(all.scores, GroupS)";
                m_cEngine.Evaluate(sCommand);

                GenericVector vtValue = null;
                CharacterVector vtGroupName = null;

                sCommand = "rownames(result[[2]])";
                vtValue = m_cEngine.Evaluate(sCommand).AsList();
                vtGroupName = vtValue.AsCharacter();

                sCommand = "result[[2]]";
                vtValue = m_cEngine.Evaluate(sCommand).AsList();

                int iRowCnt = vtGroupName.Length;

                cResult.GroupName = new string[iRowCnt];
                cResult.GroupDiff = new float[iRowCnt];
                cResult.GroupLowerCI = new float[iRowCnt];
                cResult.GroupUpperCI = new float[iRowCnt];

                for (int i = 0; i < iRowCnt; i++)
                {
                    cResult.GroupName[i] = (string)vtGroupName[i];
                    cResult.GroupDiff[i] = (float)vtValue[i].AsNumeric().First();
                    cResult.GroupLowerCI[i] = (float)vtValue[i + iRowCnt].AsNumeric().First();
                    cResult.GroupUpperCI[i] = (float)vtValue[i + (iRowCnt * 2)].AsNumeric().First();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("CREngineHelper", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                throw ex;
            }
            return cResult;
        }

        #endregion
    }
}
