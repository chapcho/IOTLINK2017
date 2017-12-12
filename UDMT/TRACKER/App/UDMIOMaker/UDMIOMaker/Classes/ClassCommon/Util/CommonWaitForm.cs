using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    public class CommonWaitForm
    {
        private static SplashScreenManager m_exManager = null;
        private static int m_iMaxValue = 100;
        private static string m_sTitle = "";
        private static string m_sMessage = "";
        private static bool m_bShow = false;


        #region Public Properties

        public static SplashScreenManager ScreenManager
        {
            get { return m_exManager; }
            set { m_exManager = value; }
        }

        public static bool IsShowing
        {
            get { return m_bShow; }
        }

        public static int MaxValue
        {
            get { return m_iMaxValue; }
            set { m_iMaxValue = value; }
        }

        public static string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; }
        }

        public static string Message
        {
            get { return m_sMessage; }
            set { m_sMessage = value; }
        }

        #endregion

        #region Public Methods

        public static void ShowWaitForm()
        {
            if (m_exManager != null && m_exManager.IsSplashFormVisible == false)
            {
                m_bShow = true;
                m_exManager.ShowWaitForm();
            }
        }

        public static void ShowWaitForm(string sTitle, string sMessage)
        {
            if (m_exManager != null && m_exManager.IsSplashFormVisible == false)
            {
                m_sTitle = sTitle;
                m_sMessage = sMessage;

                m_bShow = true;
                m_exManager.ShowWaitForm();
                m_exManager.SetWaitFormCaption(sTitle);
                m_exManager.SetWaitFormDescription(sMessage);
            }
        }

        public static void CloseWaitForm()
        {
            if (m_exManager != null && m_exManager.IsSplashFormVisible)
            {
                m_bShow = false;
                m_exManager.CloseWaitForm();
            }
        }

        public static void SetTitle(string sText)
        {
            m_sTitle = sText;

            if (m_exManager != null && m_exManager.IsSplashFormVisible)
                m_exManager.SetWaitFormCaption(sText);
        }

        public static void SetMessage(string sText)
        {
            m_sMessage = sText;

            if (m_exManager != null && m_exManager.IsSplashFormVisible)
                m_exManager.SetWaitFormDescription(sText);
        }

        public static void SetProgress(int iValue)
        {
            SetMessage(iValue.ToString() + "/" + m_iMaxValue.ToString());
        }

        #endregion
    }
}
