using System;
using System.Windows.Forms;

namespace ReferenceDllCopier
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

            MessageBox.Show("This program does nothing.  Just copies dlls.");
        }
    }
}