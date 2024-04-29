using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FestivalInstrumentMapper
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
        }

        // Exception.Message doesn't include the exception type
        public static string GetFirstLine(this Exception ex)
        {
            return ex.ToString().Split('\n')[0];
        }

        public static string WriteErrorFile(Exception ex)
        {
            // get root directory
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // combine roon with errors folder
            string errorFolderPath = Path.Combine(rootDirectory, "errors");

            // create errors folder if its not there
            if (!Directory.Exists(errorFolderPath))
            {
                Directory.CreateDirectory(errorFolderPath);
            }

            // generate error file name 
            string errorFileName = $"error_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";

            // combine erros path with the errors file name 
            string errorFilePath = Path.Combine(errorFolderPath, errorFileName);

            // write the errors details to the error file 
            File.WriteAllText(errorFilePath, ex.ToString());

            // display the error in the box 
            string errorMessage = $"Caught an unhandled mapping exception:\n\n{ex}\n\nError log saved to:\n{errorFilePath}";
            MessageBox.Show(
                errorMessage,
                "Mapping Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            // open the errors folder
            if (Directory.Exists(errorFolderPath))
            {
                Process.Start("explorer.exe", errorFolderPath);
            }
            else
            {
                MessageBox.Show("Error folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // return file path 
            return errorFilePath;
        }
    }
}
