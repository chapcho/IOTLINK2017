using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.LookAndFeel;

using UDM.General.AssemblyLoader;
using UDM.LicenseSW;

namespace UDMTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            // Load Assembly
            CAssemblyLoader.AppNameSpace = "UDMTracker";
            CAssemblyLoader.CurrentDomain = AppDomain.CurrentDomain;
            CAssemblyLoader.ExecutingAssembly = Assembly.GetExecutingAssembly();

            CLicense cLicense = new CLicense("UDMTracker", Application.StartupPath);

            bool bOK = true;

            //try
            //{
            //    bOK = cLicense.CheckLicense();
            //}
            //catch (Exception ex)
            //{
            //    bOK = false; Console.WriteLine("License Exception... Key Checking Please.." + ex);
            //    MessageBox.Show("License Exception... Key Checking Please..");
            //}

            if (bOK)
                Application.Run(new FrmMain());
            //else
            //    Application.Exit();


        }
    }
}
