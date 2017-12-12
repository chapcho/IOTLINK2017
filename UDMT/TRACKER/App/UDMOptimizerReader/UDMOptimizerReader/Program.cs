using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using UDM.General.AssemblyLoader;
using UDM.LicenseSW;
using System.Reflection;

namespace UDMOptimizerReader
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

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            // Load Assembly
            CAssemblyLoader.AppNameSpace = "Optimizer Reader";
            CAssemblyLoader.CurrentDomain = AppDomain.CurrentDomain;
            CAssemblyLoader.ExecutingAssembly = Assembly.GetExecutingAssembly();

            //CLicense cLicense = new CLicense("UDMOptimizer Reader", Application.StartupPath);

            //bool bOK;

            //try
            //{
            //    bOK = cLicense.CheckLicense();
            //}
            //catch (Exception ex)
            //{
            //    bOK = false; Console.WriteLine("License Exception... Key Checking Please.." + ex);
            //    MessageBox.Show("License Exception... Key Checking Please..");
            //}

            //if (bOK)
                Application.Run(new FrmMain2());
            //else
            //    Application.Exit();

        }
    }
}
