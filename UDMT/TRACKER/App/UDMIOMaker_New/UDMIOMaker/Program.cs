using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using UDM.General.AssemblyLoader;
using UDM.LicenseSW;

namespace UDMIOMaker
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

             //Load Assembly
            //CAssemblyLoader.AppNameSpace = "UDMIOMaker";
            //CAssemblyLoader.CurrentDomain = AppDomain.CurrentDomain;
            //CAssemblyLoader.ExecutingAssembly = Assembly.GetExecutingAssembly();

            //CLicense cLicense = new CLicense("UDM NewIOMaker", Application.StartupPath);

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
               Application.Run(new FrmMain());
            //else
            //   Application.Exit();
        }
    }
}
