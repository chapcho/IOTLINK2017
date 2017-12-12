using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Threading;

namespace FTOPApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNew;
            var mtxName = "ED9731EF-A984-4D80-8414-C2A0ECA43A64";
            //var mtx = new Mutex(true, mtxName, out isNew);

            //test mode
            isNew = true;

            if (isNew)
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);

                //SkinManager.EnableFormSkins();
                //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                Application.Run(new FrmMain());
                //mtx.ReleaseMutex();
                
            }
            else
            {
                MessageBox.Show("이미 프로그램이 실행 중입니다.");
            }

        }
    }
}
