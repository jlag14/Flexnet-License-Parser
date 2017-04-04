using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LicenseCleaner
{
    static class Program
    {
        public static Form1 obj;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            obj = new Form1();
            Application.Run(obj);
        }
    }
}
