using IOTL.Common.AssemblyLoader;
using IOTL.SWLockLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTLManager
{
    static class Program
    {
        public const string APP_NAME = "IOTLink Event Manager";
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            // Load Assembly
            AssemblyLoader.AppNameSpace = APP_NAME;
            AssemblyLoader.CurrentDomain = AppDomain.CurrentDomain;
            AssemblyLoader.ExecutingAssembly = Assembly.GetExecutingAssembly();

            License cLicense = new License(APP_NAME, Application.StartupPath);

            bool bOK;

            //try
            //{
            //    bOK = cLicense.CheckLicense();
            //}
            //catch (Exception ex)
            //{
            //    bOK = false; Console.WriteLine("License Exception... Key Checking Please.." + ex);
            //    MessageBox.Show("License Exception... Key Checking Please..");
            //}

            // if (bOK)
            // Application.Run(new FrmMain());
            // else
            //    Application.Exit();

            try
            {
                Application.Run(new FrmMain());
            }
            catch(Exception ex)
            {
                ex.Data.Clear();
                // MessageBox.Show("License Exception... Key Checking Please..");
            }
        }
    }
}
