//
// Copyright (c) 2012 Timothy Baxendale
//
using System;
using System.IO;
using System.Windows.Forms;

namespace Musical_Mouse_Customizer
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
            Application.Run(new MainForm());
        }

        public static string SaveTempFile(byte[] data, string name)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), name);
            File.WriteAllBytes(tempFile, data);
            return tempFile;
        }
    }
}
