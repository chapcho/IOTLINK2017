using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using UDM.General.AssemblyLoader;
using System.Reflection;
using UDM.LicenseSW;

namespace UDMPresenter
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

            CAssemblyLoader.AppNameSpace = "UDM Presenter";
            CAssemblyLoader.CurrentDomain = AppDomain.CurrentDomain;
            CAssemblyLoader.ExecutingAssembly = Assembly.GetExecutingAssembly();

            CLicense cLicense = new CLicense("UDM Presenter", Application.StartupPath);

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
            //{
            //    BonusSkins.Register();
            //    SkinManager.EnableFormSkins();
                Application.Run(new FrmMain());
            //}
            //else
            //    Application.Exit();
		}
	}
}
