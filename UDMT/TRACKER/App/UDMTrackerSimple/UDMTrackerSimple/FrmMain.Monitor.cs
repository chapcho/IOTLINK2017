using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using UDM.Log.DB;
using UDM.Log;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;

namespace UDMTrackerSimple
{
    partial class FrmMain
    {

        #region Member Variables


        #endregion


        #region Private Methods


        private void CheckDBRealtedPath()
        {
            if (CMultiProject.ProjectInfo.DBPath == null || CMultiProject.ProjectInfo.DBPath == string.Empty)
                CMultiProject.ProjectInfo.DBPath = "C:\\Program Files\\MariaDB 10.1\\bin\\mysql.exe";

            chkMariaDB.Checked = true;
            //btnDBPath.EditValue = CMultiProject.ProjectInfo.DBPath;

            //if(CMultiProject.ProjectInfo.DBBackupPath == null || CMultiProject.ProjectInfo.DBBackupPath == string.Empty)
            //    CMultiProject.ProjectInfo.DBBackupPath = "C:\\Program Files\\MariaDB 10.1\\bin\\mysqldump.exe";

            //btnDBBackupPath.EditValue = CMultiProject.ProjectInfo.DBBackupPath;
        }

        private void DBBackup(string sDBPath, string sPath)
        {
            try
            {
                string sError = string.Empty;

                using (Process mysqlDump = new Process())
                {
                    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                    {
                        //Maria DB의 경우 Path 다름
                        //mysqlDump.StartInfo.FileName =
                        //    @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                        mysqlDump.StartInfo.FileName = sDBPath;
                        //@"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                        mysqlDump.StartInfo.UseShellExecute = false;
                        mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -r \"{0}\"", sPath);
                        mysqlDump.StartInfo.RedirectStandardInput = false;
                        mysqlDump.StartInfo.RedirectStandardOutput = false;
                        mysqlDump.StartInfo.RedirectStandardError = true;
                        mysqlDump.StartInfo.CreateNoWindow = true;
                        mysqlDump.Start();

                        sError = mysqlDump.StandardError.ReadToEnd();
                    }
                    SplashScreenManager.CloseForm(false);

                    if (sError != string.Empty)
                        XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        XtraMessageBox.Show("DB Backup Success!!", "DB Backup", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    mysqlDump.WaitForExit();
                    mysqlDump.Close();
                }

                string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                if (sError == string.Empty && Directory.Exists(sFolderPath))
                    Process.Start(sFolderPath);
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetDBPath(bool bMysql)
        {
            if(bMysql)
            {
                CMultiProject.ProjectInfo.DBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                CMultiProject.ProjectInfo.DBBackupPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
            }
            else
            {
                CMultiProject.ProjectInfo.DBPath = @"C:\Program Files\MariaDB 10.1\bin\mysql.exe";
                CMultiProject.ProjectInfo.DBBackupPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";

                if(!File.Exists(CMultiProject.ProjectInfo.DBPath))
                {
                    CMultiProject.ProjectInfo.DBPath = @"C:\Program Files (x86)\MariaDB 10.1\bin\mysql.exe";
                    CMultiProject.ProjectInfo.DBBackupPath = @"C:\Program Files (x86)\MariaDB 10.1\bin\mysqldump.exe";
                }
            }
        }

        private List<string> GetStepEndSymbolKey(CErrorInfo cCurInfo, CSubLogicPathS cLogicPathS, bool bOffError)
        {
            List<string> lstEndSymbolKey = new List<string>();

            try
            {
                bool bTranslate = true;

                CTimeLogS cLogS = null;
                CTimeLog cLog = null;
                CTag cTag = null;
                CSubContact cSubContact = null;
                List<string> lstTempEndSymbolKey = new List<string>();
                foreach (CSubLogicPath cPath in cLogicPathS)
                {
                    foreach (var who in cPath.SubContactS)
                    {
                        cSubContact = who.Value;
                        if (!cSubContact.IsEndContact)
                            continue;

                        if (!CMultiProject.TotalTagS.ContainsKey(cSubContact.Key))
                            continue;

                        cTag = CMultiProject.TotalTagS[cSubContact.Key];

                        if (cTag.Description.Equals("") || cTag.Description.ToUpper().Contains("RESET") || cTag.Description.ToUpper().ToUpper().Contains("RST") || cTag.Description.ToUpper().Contains("해제") || cTag.Description.ToUpper().Contains("리셋")
                            || cTag.Description.ToUpper().Contains("항상 OFF") || cTag.Description.ToUpper().Contains("항상 ON") || cTag.Description.ToUpper().Contains("항시ON"))
                            continue;

                        cLogS = cCurInfo.ErrorLogS.GetTimeLogS(cSubContact.Key);

                        if (cLogS == null || cLogS.Count == 0)
                            continue;

                        cLog = cLogS.Last();

                        if (CheckDetailErrorSymbol(cLog, cSubContact.IsASymbolState, cSubContact.IsInverse, bOffError) && !lstTempEndSymbolKey.Contains(cSubContact.Key))
                        {
                            lstTempEndSymbolKey.Add(cSubContact.Key);

                            if (cSubContact.IsInverse)
                                bTranslate = false;
                        }
                    }
                }

                if (bTranslate && lstTempEndSymbolKey.Count > 0)
                {
                    foreach (string sKey in lstTempEndSymbolKey)
                    {
                        cTag = CMultiProject.TotalTagS[sKey];

                        //Description이 Abnormal Filter 중 하나라도 포함하고 있으면 해석 X ( ex) 냉각수이상, 실러이상)
                        if (CheckAbnormalTag(cTag))
                        {
                            bTranslate = false;
                            break;
                        }
                    }
                }

                if (bTranslate)
                {
                    foreach (CSubLogicPath cPath in cLogicPathS)
                    {
                        foreach (var who in cPath.SubContactS)
                        {
                            cSubContact = who.Value;

                            if (!CMultiProject.TotalTagS.ContainsKey(cSubContact.Key))
                                continue;

                            cTag = CMultiProject.TotalTagS[cSubContact.Key];

                            if (cTag.Description.Equals("") || cTag.Description.ToUpper().Contains("RESET") || cTag.Description.ToUpper().ToUpper().Contains("RST") || cTag.Description.ToUpper().Contains("해제") || cTag.Description.ToUpper().Contains("리셋")
                                || cTag.Description.ToUpper().Contains("항상 OFF") || cTag.Description.ToUpper().Contains("항상 ON") || cTag.Description.ToUpper().Contains("항시ON"))
                                continue;

                            if (!CheckAbnormalTag(cTag) && !lstEndSymbolKey.Contains(cSubContact.Key))
                                lstEndSymbolKey.Add(cSubContact.Key);
                        }
                    }
                }
                else
                    lstEndSymbolKey.AddRange(lstTempEndSymbolKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                lstEndSymbolKey.Clear();
            }

            return lstEndSymbolKey;
        }

        private bool CheckDetailErrorSymbol(CTimeLog cLog, bool bASymbolState, bool bInverse, bool bOffError)
        {
            bool bOK = false;

            if (bASymbolState)
            {
                if (!bOffError)
                {
                    if (bInverse && cLog.Value == 0 || !bInverse && cLog.Value == 1)
                        bOK = true;
                }
                else
                {
                    if (bInverse && cLog.Value == 1 || !bInverse && cLog.Value == 0)
                        bOK = true;
                }
            }
            else
            {
                if (!bOffError)
                {
                    if (bInverse && cLog.Value == 1 || !bInverse && cLog.Value == 0)
                        bOK = true;
                }
                else
                {
                    if (bInverse && cLog.Value == 0 || !bInverse && cLog.Value == 1)
                        bOK = true;
                }
            }

            return bOK;
        }


        private bool CheckAbnormalTag(CTag cTag)
        {
            bool bOK = false;

            string sDescription = cTag.Description;

            foreach (string sFilter in CMultiProject.AbnormalFilter)
            {
                if (sDescription.ToUpper().Contains(sFilter))
                {
                    if (sFilter == "NG" && sDescription.Contains("ING"))
                        continue;

                    bOK = true;
                    break;
                }
            }

            return bOK;
        }


        private CErrorInfoS GetErrorS(CErrorInfo cInfo)
        {
            CErrorInfoS cDetailInfoS = new CErrorInfoS();
            bool bOffError = false;

            try
            {
                if (cInfo.ErrorLogS == null || cInfo.ErrorLogS.Count == 0)
                    return cDetailInfoS;

                CAbnormalSymbol cSymbol = null;
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.AbnormalSymbolS.IsContainKey(cInfo.SymbolKey))
                    {
                        cSymbol = who.Value.AbnormalSymbolS.GetAbnormalSymbol(cInfo.SymbolKey);
                        break;
                    }
                }

                if (cSymbol == null)
                    return cDetailInfoS;

                if (cInfo.Value == 0)
                    bOffError = true;

                if (cSymbol.SubCoil == null)
                    return null;

                CSubCoilS cSubCoilS = cSymbol.SubCoil.GetLastSubCoilS(cInfo.ErrorLogS, bOffError);

                CSubLogicPathS cErrorPathS = null;

                if (cSubCoilS == null || cSubCoilS.Count == 0)
                {
                    if (!cSymbol.SubCoil.IsFunction)
                    {
                        cErrorPathS = cSymbol.SubCoil.SubLogicPathS.GetErrorLogicPathS(cInfo.ErrorLogS,
                            bOffError);
                        cInfo.InputSymbolKeyList.Clear();

                        if (cErrorPathS != null && cErrorPathS.Count != 0)
                            cInfo.InputSymbolKeyList = GetStepEndSymbolKey(cInfo, cErrorPathS, bOffError);
                    }

                    SetDetailErrorS(cInfo, cDetailInfoS, cInfo.InputSymbolKeyList, cInfo.SymbolKey, cInfo.ErrorMessage);

                    if (cDetailInfoS.Count != 0)
                    {
                        cInfo.IsVisible = false;
                        cInfo.CoilKey = cInfo.SymbolKey;
                        cInfo.AbnormalSymbolKey = cInfo.SymbolKey;
                        cDetailInfoS.Add(cInfo);
                    }
                }
                else
                {
                    CErrorInfo cDetailInfo = null;
                    int iErrorCount = 0;
                    foreach (var who in cSubCoilS)
                    {
                        if (!who.IsFunction)
                            cErrorPathS = who.SubLogicPathS.GetErrorLogicPathS(cInfo.ErrorLogS, bOffError);

                        cDetailInfo = GetError(CMultiProject.TotalTagS[who.CoilKey], cErrorPathS, who.IsFunction, cInfo);
                        if (cDetailInfo != null)
                            cDetailInfoS.Add(cDetailInfo);

                        iErrorCount = cDetailInfoS.Count;
                        SetDetailErrorS(cInfo, cDetailInfoS, cDetailInfo.InputSymbolKeyList, cDetailInfo.SymbolKey, cDetailInfo.DetailErrorMessage);

                        if (iErrorCount == cDetailInfoS.Count)
                            cDetailInfo.IsVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }

            return cDetailInfoS;
        }

        private CErrorInfo GetError(CTag cErrorTag, CSubLogicPathS cErrorPathS, bool bFunction, CErrorInfo cCurInfo)
        {
            CErrorInfo cDetailInfo = new CErrorInfo();

            cDetailInfo.SymbolKey = cErrorTag.Key;
            cDetailInfo.ErrorMessage = cCurInfo.ErrorMessage;
            cDetailInfo.DetailErrorMessage = cErrorTag.Description;
            cDetailInfo.CurrentRecipe = cCurInfo.CurrentRecipe;
            cDetailInfo.CycleID = cCurInfo.CycleID;
            cDetailInfo.CycleStart = cCurInfo.CycleStart;
            cDetailInfo.ErrorID = cCurInfo.ErrorID;
            cDetailInfo.ErrorTime = cCurInfo.ErrorTime;
            cDetailInfo.ErrorType = cCurInfo.ErrorType;
            cDetailInfo.GroupKey = cCurInfo.GroupKey;
            cDetailInfo.ProjectID = cCurInfo.ProjectID;

            CTimeLog cLog = cCurInfo.ErrorLogS.GetFirstLog(cErrorTag.Key);
            cDetailInfo.Value = cLog.Value;
            cDetailInfo.AbnormalSymbolKey = cCurInfo.SymbolKey;
            cDetailInfo.CoilKey = cErrorTag.Key;

            if (!bFunction && cErrorPathS != null && cErrorPathS.Count != 0)
                cDetailInfo.InputSymbolKeyList = GetStepEndSymbolKey(cCurInfo, cErrorPathS, cLog.Value == 1 ? false : true);

            return cDetailInfo;
        }

        private void SetDetailErrorS(CErrorInfo cCurInfo, CErrorInfoS cInfoS, List<string> lstInputSymbolKeyList, string sCoilKey, string sErrorMessage)
        {
            CErrorInfo cInfo = null;
            CTag cTag = null;
            foreach (string sKey in lstInputSymbolKeyList)
            {
                cTag = CMultiProject.TotalTagS[sKey];
                cInfo = GetErrorNotContainInputSymbolList(cCurInfo, cTag, sCoilKey, sErrorMessage);

                cInfoS.Add(cInfo);
            }
        }

        private CErrorInfo GetErrorNotContainInputSymbolList(CErrorInfo cCurInfo, CTag cErrorTag, string sCoilKey, string sErrorMessage)
        {
            CErrorInfo cDetailInfo = new CErrorInfo();

            cDetailInfo.SymbolKey = cErrorTag.Key;
            cDetailInfo.ErrorMessage = sErrorMessage;
            cDetailInfo.DetailErrorMessage = cErrorTag.Description;
            cDetailInfo.CurrentRecipe = cCurInfo.CurrentRecipe;
            cDetailInfo.CycleID = cCurInfo.CycleID;
            cDetailInfo.CycleStart = cCurInfo.CycleStart;
            cDetailInfo.ErrorID = cCurInfo.ErrorID;
            cDetailInfo.ErrorTime = cCurInfo.ErrorTime;
            cDetailInfo.ErrorType = cCurInfo.ErrorType;
            cDetailInfo.GroupKey = cCurInfo.GroupKey;
            cDetailInfo.ProjectID = cCurInfo.ProjectID;
            cDetailInfo.Value = cCurInfo.Value;
            cDetailInfo.AbnormalSymbolKey = cCurInfo.SymbolKey;
            cDetailInfo.CoilKey = sCoilKey;
            cDetailInfo.IsVisible = true;

            return cDetailInfo;
        }



        private bool UpdateErrorDB()
        {
            bool bOK = false;
            CErrorInfoS cNewErrorS = new CErrorInfoS();
            CErrorInfoS cTotalErrorS = m_cReader.GetErrorInfoS(CMultiProject.ProjectID);

            if(cTotalErrorS == null || cTotalErrorS.Count == 0)
                return false;

            CErrorInfo cNewError = null;
            CErrorInfoS cNewErrorInfoS = null;
            CTimeLogS cErrorLogS = null;
            CTimeLog cErrorLog = null;
            string sAbnormalKey = string.Empty;
            List<int> lstErrorID = new List<int>();
            CPlcProc cProcess = null;

            foreach(CErrorInfo cInfo in cTotalErrorS)
            {
                if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(cInfo.ErrorTime)) continue;

                if (cInfo.ErrorType == "CycleOver")
                    cNewErrorS.Add(cInfo);
                else
                {
                    if (!lstErrorID.Contains(cInfo.ErrorID))
                    {
                        if (cInfo.AbnormalSymbolKey == string.Empty)
                            sAbnormalKey = cInfo.CoilKey;
                        else
                            sAbnormalKey = cInfo.AbnormalSymbolKey;

                        if (!CMultiProject.TotalTagS.ContainsKey(sAbnormalKey))
                            continue;

                        cErrorLogS = m_cReader.GetErrorLogS(cInfo.ErrorID);

                        if (cErrorLogS == null || cErrorLogS.Count == 0)
                            continue;

                        cErrorLog = cErrorLogS.GetLastLog(sAbnormalKey);

                        if (!CMultiProject.PlcProcS.ContainsKey(cInfo.GroupKey))
                            continue;

                        cProcess = CMultiProject.PlcProcS[cInfo.GroupKey];
                        CAbnormalSymbol cSymbol = cProcess.AbnormalSymbolS.GetAbnormalSymbol(cErrorLog);

                        if (cSymbol == null || cSymbol.TagKey != sAbnormalKey)
                            continue;

                        cNewError = new CErrorInfo();
                        cNewError.ProjectID = cInfo.ProjectID;
                        cNewError.CycleID = cInfo.CycleID;
                        cNewError.ErrorID = cInfo.ErrorID;
                        cNewError.GroupKey = cInfo.GroupKey;
                        cNewError.ErrorType = cInfo.ErrorType;
                        cNewError.ErrorMessage = CMultiProject.TotalTagS[sAbnormalKey].GetDescription();
                        cNewError.SymbolKey = sAbnormalKey;
                        cNewError.ErrorLogS = cErrorLogS;
                        cNewError.ErrorTime = cInfo.ErrorTime;
                        cNewError.CycleStart = cInfo.CycleStart;



                        if (cErrorLog != null)
                            cNewError.Value = cErrorLog.Value;

                        lstErrorID.Add(cInfo.ErrorID);
                        cNewErrorInfoS = GetErrorS(cNewError);

                        if (cNewError.ErrorLogS != null)
                            cNewError.ErrorLogS.Dispose();

                        cNewError.ErrorLogS = null;

                        if(cNewErrorInfoS == null || cNewErrorInfoS.Count == 0)
                        {
                            cNewError.IsVisible = true;
                            cNewError.CoilKey = cNewError.SymbolKey;
                            cNewErrorS.Add(cNewError);
                        }
                        else
                            cNewErrorS.AddRange(cNewErrorInfoS);
                    }
                }
            }

            if(cNewErrorS.Count > 0)
            {
                CMySqlLogWriter cWriter = new CMySqlLogWriter();
                cWriter.Connect();

                if (cWriter.IsConnected)
                {
                    cWriter.ClearErrorInfoS();

                    foreach (var who in cNewErrorS)
                        cWriter.WriteErrorInfo(who);
                }

                bOK = true;
            }

            return bOK;
        }

        #endregion


        #region Event Methods

        private void btnCreateDataBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string sMessage = "데이터 베이스를 새롭게 생성합니다.\r\n데이터 베이스 생성시 저장된 모든 데이터가 지워집니다.\r\n데이터 베이스를 생성하시겠습니까?";

                if (
                    XtraMessageBox.Show(sMessage, "UDM Tracker",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                bool bOK = true;

                CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
                bOK = cLogWriter.CreateDB();

                CMultiProject.ErrorIDCur = 0;
                if (CMultiProject.ErrorInfoS != null)
                    CMultiProject.ErrorInfoS.Clear();
                ucErrorLogTable.Clear();

                cLogWriter.Dispose();
                cLogWriter = null;

                if (bOK == false)
                {
                    XtraMessageBox.Show("DB를 생성할 수 없습니다. DB 설치를 다시 확인해주세요!!", "UDM Tracker",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show("DB 생성 성공!!\r\nUDM Tracker를 종료합니다.", "UDM Tracker",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (m_cReader != null)
                    {
                        m_cReader.Disconnect();
                        m_cReader.Dispose();
                        m_cReader = null;
                    }

                    this.Close();
                    m_cReader = new CMySqlLogReader();
                    m_cReader.Connect();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.Monitor",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnTestDBConnection_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CheckProjectEditable() == false)
                    return;

                if (m_cReader.IsConnected == false)
                    m_cReader.Connect();

                if (m_cReader.IsConnected)
                    XtraMessageBox.Show("DB 연결 확인 성공!!", "UDM Tracker", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("Can't Connect to DB. Please Check Mysql Installation!!", "UDM Tracker",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.Monitor",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnDBBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string sMessage = "축적된 데이터 베이스를 백업합니다.\r\n데이터 베이스 백업을 진행하시겠습니까?";

                if (XtraMessageBox.Show(sMessage, "DB 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                    return;

                //string sDBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                //string sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                string sDBPath = CMultiProject.ProjectInfo.DBBackupPath;

                if (!File.Exists(sDBPath))
                {
                    XtraMessageBox.Show("DB Path가 존재하지 않습니다.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = ".sql|*.sql";
                dlgSave.Title = "데이터 베이스 백업 파일 저장";
                dlgSave.FileName = string.Format("DB_Backup_{0}", DateTime.Now.ToString("yyyyMMdd"));

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                {
                    dlgSave.Dispose();
                    dlgSave = null;
                    return;
                }

                string sPath = dlgSave.FileName;

                if (sPath != string.Empty)
                {
                    DBBackup(sDBPath, sPath);
                }
                dlgSave.Dispose();
                dlgSave = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDBOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string sMessage = "저장된 데이터 베이스를 오픈합니다.\r\n오픈 시 기존 데이터 베이스는 모두 지워집니다.\r\n데이터 베이스 오픈을 진행하시겠습니까?";

                if (XtraMessageBox.Show(sMessage, "DB 오픈", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.No)
                    return;

                //string sDBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                //string sDBPath = @"C:\Program Files\MariaDB 10.1\bin\mysql.exe";
                //string sDBDumpPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                string sDBPath = CMultiProject.ProjectInfo.DBPath;
                string sDBDumpPath = CMultiProject.ProjectInfo.DBBackupPath;


                if (!File.Exists(sDBPath))
                {
                    XtraMessageBox.Show("DB Path가 존재하지 않습니다.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sMessage = "DB 불러오기를 진행하기 전 현재까지의 DB를 백업합니다.\r\n진행하시겠습니까?";
                if (XtraMessageBox.Show(sMessage, "DB 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (!Directory.Exists(m_sDBBackupPath))
                        Directory.CreateDirectory(m_sDBBackupPath);

                    DBBackup(sDBDumpPath, m_sDBBackupPath + "\\" + string.Format("DB_Backup_{0}.sql", DateTime.Now.ToString("yyyyMMdd")));
                }

                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = ".sql|*.sql";
                dlgOpen.Title = "데이터 베이스 백업 파일 열기";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return;
                }

                string sPath = dlgOpen.FileName;

                if (sPath != string.Empty)
                {
                    string sError = string.Empty;

                    using (Process mysql = new Process())
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            //Maria DB의 경우 Path 다름
                            mysql.StartInfo.FileName = sDBPath;
                            //mysql.StartInfo.FileName =
                                //@"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                            mysql.StartInfo.UseShellExecute = false;
                            mysql.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -e \"\\. {0}\"", sPath);
                            mysql.StartInfo.RedirectStandardInput = false;
                            mysql.StartInfo.RedirectStandardOutput = false;
                            mysql.StartInfo.RedirectStandardError = true;
                            mysql.StartInfo.CreateNoWindow = true;
                            mysql.Start();

                            sError = mysql.StandardError.ReadToEnd();
                        }
                        SplashScreenManager.CloseForm(false);

                        if (sError != string.Empty)
                            XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("DB Open Success!!", "DB Open", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        mysql.WaitForExit();
                        mysql.Close();
                    }
                }
                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLSOPCServerOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process[] arrOPCProcess = System.Diagnostics.Process.GetProcessesByName("LGOPCConfig");

                if (arrOPCProcess.Length > 0)
                {
                    XtraMessageBox.Show("LS OPC 서버가 이미 실행중입니다.\r\n작업 관리자를 통해 OPC 서버 실행 여부를 확인하세요.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(@"C:\LSIS_OPC\LGEDrv.exe") || !File.Exists(@"C:\LSIS_OPC\LGOPCConfig.EXE"))
                {
                    XtraMessageBox.Show("LS OPC 서버가 설치되지 않았습니다.\r\nLS OPC 서버를 설치해주세요.", "OPC 열기 에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (System.Diagnostics.Process cmd = new Process())
                {
                    cmd.StartInfo.FileName = @"cmd";
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardError = true;
                    cmd.StartInfo.RedirectStandardOutput = false;

                    cmd.Start();

                    cmd.StandardInput.Write(@"C:\LSIS_OPC\LGEDrv.exe" + Environment.NewLine);
                    cmd.StandardInput.Write(@"C:\LSIS_OPC\LGOPCConfig.EXE" + Environment.NewLine);

                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    cmd.Close();
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLSLogicExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Title = "LS 산전 프로젝트 파일 열기";
                dlgOpen.Filter = ".xgwx|*.xgwx";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return;
                }

                string sPath = dlgOpen.FileName;
                string sError = string.Empty;

                if (sPath != string.Empty)
                {
                    using (System.Diagnostics.Process cmd = new Process())
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            cmd.StartInfo.FileName = @"cmd";
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardError = true;
                            cmd.StartInfo.RedirectStandardOutput = true;

                            cmd.Start();

                            string sCommand = string.Format("C:\\XG5000\\XG5000.exe /convert:il {0}", sPath);

                            cmd.StandardInput.Write(sCommand + Environment.NewLine);

                            cmd.StandardInput.Close();
                            sError = cmd.StandardError.ReadToEnd();
                        }
                        SplashScreenManager.CloseForm(false);

                        if (sError != string.Empty)
                            XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Export Success!!", "Logic Export", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        cmd.WaitForExit();
                        cmd.Close();

                        string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                        if (sError == string.Empty && Directory.Exists(sFolderPath))
                            Process.Start(sFolderPath);
                    }
                }

                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CheckProjectEditable() == false)
                    return;

                if (m_cReader.IsConnected == false)
                    m_cReader.Connect();

                CTimeLogS cTimeLog = null;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    cTimeLog = m_cReader.GetTimeLogS((DateTime) dtpkExportFrom.EditValue,
                        (DateTime) dtpkExportTo.EditValue);
                }
                SplashScreenManager.CloseForm();

                if (cTimeLog != null && cTimeLog.Count > 1)
                {
                    SaveFileDialog dlgSaveFile = new SaveFileDialog();
                    dlgSaveFile.Filter = "*.csv|*.csv";
                    dlgSaveFile.ShowDialog();

                    string[] saFile = dlgSaveFile.FileNames;
                    int iIndex = dlgSaveFile.FilterIndex;
                    if (saFile != null && saFile.Length > 0)
                    {
                        bool bOK = true;

                        UDM.Log.Csv.CCsvLogWriter cWrite = new UDM.Log.Csv.CCsvLogWriter();

                        cWrite.Open(saFile[0]);
                        bOK = cWrite.WriteTimeLogS(cTimeLog);
                        cWrite.Close();

                        if (bOK)
                        {
                            MessageBox.Show("Export Time Log is OK!!!", "UDM Tracker", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Time Log Not Found!!!", "UDM Tracker", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain.Monitor",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnDBPath_ItemPress(object sender, ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Title = "Select DB Path";
                dlgOpen.Filter = "*.exe|*.exe";

                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    if (dlgOpen.FileName != null)
                    {
                        btnDBPath.EditValue = dlgOpen.FileName;
                        CMultiProject.ProjectInfo.DBPath = dlgOpen.FileName;
                    }
                }

                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDBBackupPath_ItemPress(object sender, ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Title = "Select DB Backup Path";
                dlgOpen.Filter = "*.exe|*.exe";

                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    if (dlgOpen.FileName != null)
                    {
                        btnDBBackupPath.EditValue = dlgOpen.FileName;
                        CMultiProject.ProjectInfo.DBBackupPath = dlgOpen.FileName;
                    }
                }

                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void chkMariaDB_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (chkMariaDB.Checked)
                    chkMysqlDB.Checked = false;
                else
                    chkMysqlDB.Checked = true;

                SetDBPath(chkMysqlDB.Checked);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkMysqlDB_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (chkMysqlDB.Checked)
                    chkMariaDB.Checked = false;
                else
                    chkMariaDB.Checked = true;

                SetDBPath(chkMysqlDB.Checked);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnUpdateErrorDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Error DB를 Update 하시겠습니까?", "Update DB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                bool bOK = false;

                SplashScreenManager.ShowDefaultWaitForm();
                {
                    bOK = UpdateErrorDB();
                }
                SplashScreenManager.CloseDefaultWaitForm();

                if(bOK)
                    XtraMessageBox.Show("Update Error DB Success!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion
    }
}
