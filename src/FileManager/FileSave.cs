using System;
using System.IO;

namespace AutomatedW3cValidator.FileManager
{
    public static class FileSave
    {
        public static void SaveTheResponse(string validationSummary, string reportName)
        {
            var reportsFolder = Path.Combine(Environment.CurrentDirectory, "Reports");
            if (!Directory.Exists(reportsFolder))
            {
                Directory.CreateDirectory(reportsFolder);
            }

            var fileName = Path.Combine(reportsFolder, reportName);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (TextWriter tw = new StreamWriter(fileName))
            {
                tw.WriteLine(validationSummary);
            }

        }
    }
}
