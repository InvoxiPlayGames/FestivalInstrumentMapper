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
            if (!Directory.Exists("Log"))
                Directory.CreateDirectory("Log");

            string fileName = $"Log/error_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
            File.WriteAllText(fileName, ex.ToString());
            return fileName;
        }
    }
}